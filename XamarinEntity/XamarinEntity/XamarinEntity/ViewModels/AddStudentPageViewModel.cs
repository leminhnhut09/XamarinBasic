using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinEntity.Helpers;
using XamarinEntity.Models;
using XamarinEntity.Services;

namespace XamarinEntity.ViewModels
{
    public class AddStudentPageViewModel : ViewModelBase
    {
        private IStudentService _studentService;

        private bool _isUpdate = false;
        public bool IsUpdate
        {
            get { return _isUpdate; }
            set { SetProperty(ref _isUpdate, value); }
        }

        private Student _currentStudent;
        public Student CurrentStudent
        {
            get { return _currentStudent; }
            set { SetProperty(ref _currentStudent, value); }
        }

        private DelegateCommand _onAddStudentCommand;
        public DelegateCommand OnAddStudentCommand =>
            _onAddStudentCommand ?? (_onAddStudentCommand = new DelegateCommand(async () => await ExecuteAddStudent()));

        private DelegateCommand _onUpdateStudentCommand;
        public DelegateCommand OnUpdateStudentCommand =>
            _onUpdateStudentCommand ?? (_onUpdateStudentCommand = new DelegateCommand(async () => await ExecuteUpdateStudent()));

        private DelegateCommand _onChoosePhotoCommand;
        public DelegateCommand OnChoosePhotoCommand =>
            _onChoosePhotoCommand ?? (_onChoosePhotoCommand = new DelegateCommand(async () => await ExecuteChoosePhoto()));

        public AddStudentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IStudentService studentService)
        : base(navigationService, pageDialogService)
        {
            _studentService = studentService;
            CurrentStudent = new Student();
        }

        private async Task ExecuteAddStudent()
        {
            if (CurrentStudent != null)
            {
                var result = await _studentService.AddStudentAsync(CurrentStudent);
                if (result)
                {
                    await NavigationService.GoBackAsync();
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync("Thông báo", "Sinh viên đã tồn tại", "Ok");
                }
            }
        }

        private async Task ExecuteUpdateStudent()
        {
            var result = await _studentService.UpdateStudentAsync(CurrentStudent);
            if (result)
            {
                await NavigationService.GoBackAsync();
            }
            else
            {
                Console.WriteLine("update fail");
            }
        }

        private async Task ExecuteChoosePhoto()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(
                    new MediaPickerOptions
                    {
                        Title = "Vui lòng chọn hình ảnh"
                    });
                await LoadPhotoAsync(result);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature is not supported on the device
                await PageDialogService.DisplayAlertAsync("Thông báo", "Thiết bị không hỗ trợ", "Đóng");
            }
            catch (PermissionException pEx)
            {
                // Permissions not granted
                await PageDialogService.DisplayAlertAsync("Thông báo", "Ứng dụng chưa được cấp quyền", "Đóng");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            if (photo == null)
            {
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);
            CurrentStudent.Avatar = newFile;
            RaisePropertyChanged("CurrentStudent");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(Constant.StudentKey))
            {
                CurrentStudent = parameters.GetValue<Student>(Constant.StudentKey);
                IsUpdate = true;
            }
        }
    }
}
