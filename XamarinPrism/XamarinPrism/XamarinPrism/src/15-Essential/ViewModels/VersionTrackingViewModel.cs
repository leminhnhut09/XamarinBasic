using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class VersionTrackingViewModel : BindableBase
    {
        private bool _firstLaunch;
        public bool FirstLaunch
        {
            get { return _firstLaunch; }
            set { SetProperty(ref _firstLaunch, value); }
        }

        private bool _firstLaunchCurrent;
        public bool FirstLaunchCurrent
        {
            get { return _firstLaunchCurrent; }
            set { SetProperty(ref _firstLaunchCurrent, value); }
        }

        private bool _firstLaunchBuild;
        public bool FirstLaunchBuild
        {
            get { return _firstLaunchBuild; }
            set { SetProperty(ref _firstLaunchBuild, value); }
        }

        private string _currentVersion;
        public string CurrentVersion
        {
            get { return _currentVersion; }
            set { SetProperty(ref _currentVersion, value); }
        }

        private string _currentBuild;
        public string CurrentBuild
        {
            get { return _currentBuild; }
            set { SetProperty(ref _currentBuild, value); }
        }

        private string _previousVersion;
        public string PreviousVersion
        {
            get { return _previousVersion; }
            set { SetProperty(ref _previousVersion, value); }
        }

        private string _previousBuild;
        public string PreviousBuild
        {
            get { return _previousBuild; }
            set { SetProperty(ref _previousBuild, value); }
        }

        private string _firstVersion;
        public string FirstVersion
        {
            get { return _firstVersion; }
            set { SetProperty(ref _firstVersion, value); }
        }

        private string _firstBuild;
        public string FirstBuild
        {
            get { return _firstBuild; }
            set { SetProperty(ref _firstBuild, value); }
        }

        private string _versionHistory;
        public string VersionHistory
        {
            get { return _versionHistory; }
            set { SetProperty(ref _versionHistory, value); }
        }

        private string _buildHistory;
        public string BuildHistory
        {
            get { return _buildHistory; }
            set { SetProperty(ref _buildHistory, value); }
        }
        public VersionTrackingViewModel()
        {
            // Lần đầu tiên ứng dụng được khởi chạy
            FirstLaunch = VersionTracking.IsFirstLaunchEver;
            // Lần đầu tiên khởi chạy phiên bản hiện tại
            FirstLaunchCurrent = VersionTracking.IsFirstLaunchForCurrentVersion;
            // Lần đầu tiên khởi chạy bản dựng hiện tại
            FirstLaunchBuild = VersionTracking.IsFirstLaunchForCurrentBuild;
            // Phiên bản ứng dụng hiện tại (2.0.0)
            CurrentVersion = VersionTracking.CurrentVersion;
            // Bản dựng hiện tại (2)
            CurrentBuild = VersionTracking.CurrentBuild;
            // Phiên bản ứng dụng trước (1.0.0)
            PreviousVersion = VersionTracking.PreviousVersion;
            // Bản dựng ứng dụng trước đó (1)
            PreviousBuild = VersionTracking.PreviousBuild;
            // Phiên bản đầu tiên của ứng dụng được cài đặt (1.0.0)
            FirstVersion = VersionTracking.FirstInstalledVersion;
            // Bản dựng ứng dụng đầu tiên được cài đặt (1)
            FirstBuild = VersionTracking.FirstInstalledBuild;
            // Danh sách các phiên bản đã cài đặt (1.0.0, 2.0.0)
            foreach (var item in VersionTracking.VersionHistory)
            {
                VersionHistory += " - " + item.ToString() + "\n";
            }
            // Danh sách các bản dựng đã cài đặt (1, 2)
            foreach (var item in VersionTracking.BuildHistory)
            {
                BuildHistory += " - " + item.ToString() + "\n";
            }
        }
    }
}
