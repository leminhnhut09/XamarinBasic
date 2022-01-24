using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using XamarinEntity.Helpers;
using XamarinEntity.Models;
using XamarinEntity.Services;

namespace XamarinEntity.ViewModels
{
    public class GradePageViewModel : ViewModelBase
    {
        private IGradeService _gradeService;

        private Grade _currentGrade = new Grade();
        public Grade CurrentGrade
        {
            get { return _currentGrade; }
            set { SetProperty(ref _currentGrade, value); }
        }
        public ObservableCollection<Grade> GradeList { get; set; } = new ObservableCollection<Grade>();

        private DelegateCommand _onAddGradeCommand;

        public DelegateCommand OnAddGradeCommand =>
            _onAddGradeCommand ?? (_onAddGradeCommand = new DelegateCommand(async () => await ExecuteAddGrade()));

        private DelegateCommand _onUpdateCommand;
        public DelegateCommand OnUpdateCommand =>
            _onUpdateCommand ?? (_onUpdateCommand = new DelegateCommand(async ()=> await ExecuteUpdateGrade()));

        private DelegateCommand<Grade> _onDeleteCommand;
        public DelegateCommand<Grade> OnDeleteCommand =>
            _onDeleteCommand ?? (_onDeleteCommand = new DelegateCommand<Grade>(async (grade) => await ExecuteDeleteGrade(grade)));

        private DelegateCommand<Grade> _onBindingUpdateCommand;
        public DelegateCommand<Grade> OnBindingUpdateCommand =>
            _onBindingUpdateCommand ?? (_onBindingUpdateCommand = new DelegateCommand<Grade>((grade) => ExecuteBindingGrade(grade)));

        private DelegateCommand<Grade> _onNavigationCommand;
        public DelegateCommand<Grade> OnNavigationCommand =>
            _onNavigationCommand ?? (_onNavigationCommand = new DelegateCommand<Grade>(async (grade) => await ExecuteNavigation(grade)));

        private DelegateCommand _backupCommand;
        public DelegateCommand BackupCommand =>
            _backupCommand ?? (_backupCommand = new DelegateCommand(async () => await ExcuteBackUp()));

        private DelegateCommand _restoreCommand;
        public DelegateCommand RestoreCommand =>
            _restoreCommand ?? (_restoreCommand = new DelegateCommand(async () => await ExecuteRestore()));

        private async Task ExecuteNavigation(Grade grade)
        {
            if (grade == null) return;
            var navigationParams = new NavigationParameters();
            navigationParams.Add(Constant.GradeKey, grade);
            var result = await NavigationService.NavigateAsync("StudentPage", navigationParams);
            if (!result.Success)
            {
                Console.WriteLine("Fail !");
            }
        }

        private void ExecuteBindingGrade(Grade grade)
        {
            CurrentGrade = grade;
        }

        public GradePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IGradeService gradeService
            ) :
            base(navigationService, pageDialogService)
        {
            _gradeService = gradeService;
        }

        async Task LoadData()
        {
            GradeList.Clear();
            var result = await _gradeService.GetAsync();
            foreach (var item in result)
            {
                GradeList.Add(item);
            }
        }

        private async Task ExecuteAddGrade()
        {
            await _gradeService.AddAsync(CurrentGrade);
            CurrentGrade = new Grade();
            await LoadData();
        }
        private async Task ExecuteUpdateGrade()
        {
            await _gradeService.UpdateAsync(CurrentGrade);
            await LoadData();
        }

        private async Task ExecuteDeleteGrade(Grade grade)
        {
            var result = await PageDialogService.DisplayAlertAsync("Thông báo", "Bạn có muốn xóa lớp (sinh viên thuộc lớp)", "Đồng ý", "Từ chối");
            if (result)
            {
                await _gradeService.DeleteAsync(grade);
                await LoadData();
            }
        }
        public async override void OnAppearing()
        {
            await LoadData();
        }

        private async Task ExcuteBackUp()
        {
            try
            {
                File.Copy(Constant.DBPath, Constant.DBPathBackup, true);
                Console.WriteLine(Constant.DBPathBackup);
                await PageDialogService.DisplayAlertAsync("Thông báo", "Sao lưu thành công", "Đóng");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private async Task ExecuteRestore()
        {
            if (File.Exists(Constant.DBPathBackup))
            {
                if (File.Exists(Constant.DBPath))
                {
                    File.Delete(Constant.DBPath);
                }
                File.Copy(Constant.DBPathBackup, Constant.DBPath);
                await LoadData();
                await PageDialogService.DisplayAlertAsync("Thông báo", "Khôi phục thành công", "Đóng");
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Thông báo", "Bạn chưa có bản sao lưu", "Đóng");
            }
        }
    }
}
