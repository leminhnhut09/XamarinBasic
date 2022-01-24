using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Rg.Plugins.Popup.Contracts;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinEntity.Helpers;
using XamarinEntity.Models;
using XamarinEntity.Services;

namespace XamarinEntity.ViewModels
{
    public class StudentPageViewModel : ViewModelBase
    {
        private IStudentService _studentService;
        private bool _isLoad = false;

        private Grade _currentGrade = new Grade();
        public Grade CurrentGrade
        {
            get { return _currentGrade; }
            set { SetProperty(ref _currentGrade, value); }
        }
        public ObservableCollection<Student> StudentList { get; set; } = new ObservableCollection<Student>();

        private DelegateCommand<Student> _onNavigationCommand;
        public DelegateCommand<Student> OnNavigationCommand =>
            _onNavigationCommand ?? (_onNavigationCommand = new DelegateCommand<Student>(async (student) => await ExecuteNavigation(student)));

        private DelegateCommand<Student> _onDeleteStudentCommand;
        public DelegateCommand<Student> OnDeleteStudentCommand =>
            _onDeleteStudentCommand ?? (_onDeleteStudentCommand = new DelegateCommand<Student>(async (student) => await ExecuteDeleteStudent(student)));

        private DelegateCommand _onAddNavigationCommand;
        public DelegateCommand OnAddNavigationCommand =>
            _onAddNavigationCommand ?? (_onAddNavigationCommand = new DelegateCommand(async () => await ExecuteAddNavigation()));

        private async Task ExecuteAddNavigation()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add(Constant.GradeKey, CurrentGrade);
            var result = await NavigationService.NavigateAsync("AddStudentPage", navigationParams);
            if (!result.Success)
            {
                Console.WriteLine("Fail !");
            }
        }

        public StudentPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService,
            IPopupNavigation popupNavigation, IStudentService studentService) : 
            base(navigationService, pageDialogService)
        {
            Title = "Manager Student";
            _studentService = studentService;
        }
        async Task LoadData(int idGrade)
        {
            StudentList.Clear();
            var result = await _studentService.GetListStudentAsync(idGrade);
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
                var isSuccess = await _studentService.DeleteAsync(student);
                if (isSuccess)
                {
                    // sửa lỗi remove tại đây 
                    await LoadData(CurrentGrade.GradeId);
                }
            }
        }
        public async override void OnAppearing()
        {
            await LoadData(CurrentGrade.GradeId);
            Console.WriteLine("OnAppearing");
        }
        private async Task ExecuteNavigation(Student student)
        {
            if (student == null) return;
            var navigationParams = new NavigationParameters();
            navigationParams.Add(Constant.StudentKey, student);
            navigationParams.Add(Constant.GradeKey, CurrentGrade);
            var result = await NavigationService.NavigateAsync("AddStudentPage", navigationParams);
            if (!result.Success)
            {
                Console.WriteLine("Fail !");
            }
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey(Constant.GradeKey))
            {
                CurrentGrade = parameters.GetValue<Grade>(Constant.GradeKey);
                await LoadData(CurrentGrade.GradeId);
                _isLoad = true;
            }
        }
    }
}
