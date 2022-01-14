using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Prism.Services.Dialogs;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinEntity.Helpers;
using XamarinEntity.Models;
using XamarinEntity.Services;

namespace XamarinEntity.ViewModels
{
    public class StudentPageViewModel : ViewModelBase
    {
        private IStudentService _studentService;
        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>();

        private DelegateCommand<Student> _onNavigationCommand;
        public DelegateCommand<Student> OnNavigationCommand =>
            _onNavigationCommand ?? (_onNavigationCommand = new DelegateCommand<Student>(async (student) => await ExecuteNavigation(student)));

        private DelegateCommand<Student> _onDeleteStudentCommand;
        public DelegateCommand<Student> OnDeleteStudentCommand =>
            _onDeleteStudentCommand ?? (_onDeleteStudentCommand = new DelegateCommand<Student>(async (student) => await ExecuteDeleteStudent(student)));

        public StudentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
            IPopupNavigation popupNavigation, IStudentService studentService) : 
            base(navigationService, pageDialogService)
        {
            Title = "Manager Student";
            _studentService = studentService;
        }
        async Task LoadData()
        {
            StudentList.Clear();
            var result = await _studentService.GetStudentAsync();
            foreach (var item in result)
            {
                StudentList.Add(item);
            }
        }
        private async Task ExecuteDeleteStudent(Student student)
        {
            var result = await PageDialogService.DisplayAlertAsync("Thông báo", "Bạn có muốn xóa không?", "Đồng ý", "Hủy bỏ");
            if (result)
            {
                var isSuccess = await _studentService.DeleteStudentAsync(student.Id);
                if (isSuccess)
                {
                    // sửa lỗi remove tại đây 
                    await LoadData();
                }
            }
        }
        public async override void OnAppearing()
        {
            await LoadData();
        }
        private async Task ExecuteNavigation(Student student)
        {
            if (student == null) return;
            var navigationParams = new NavigationParameters();
            navigationParams.Add(Constant.StudentKey, student);
            var result = await NavigationService.NavigateAsync("AddStudentPage", navigationParams);
            if (!result.Success)
            {
                Console.WriteLine("Fail !");
            }
        }
    }
}
