using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Essentials;

namespace XamarinPrism.src._15_Essential.ViewModels
{
    public class FileSystemHelpersViewModel : BindableBase
    {
        private string _file = "FileSystemHelpes.txt";
        private string _fileSave = "FileSave.txt";
        private string _localPath; 
        private string _text;
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        private string _textFile;
        public string TextFile
        {
            get { return _textFile; }
            set { SetProperty(ref _textFile, value); }
        }

        private DelegateCommand _onFileCommand;
        public DelegateCommand OnFileCommand =>
            _onFileCommand ?? (_onFileCommand = new DelegateCommand(ExecuteReadFileCommand));

        private DelegateCommand _onSaveFileCommand;
        public DelegateCommand OnSaveFileCommand =>
            _onSaveFileCommand ?? (_onSaveFileCommand = new DelegateCommand(ExecuteSaveFileCommand));
       
        private DelegateCommand _onUploadFileCommand;
        public DelegateCommand OnUploadFileCommand =>
            _onUploadFileCommand ?? (_onUploadFileCommand = new DelegateCommand(ExecuteUploadFileCommand));

        public FileSystemHelpersViewModel()
        {
            _localPath = Path.Combine(FileSystem.CacheDirectory, _fileSave);
        }
        private void ExecuteUploadFileCommand()
        {
            TextFile = File.ReadAllText(_localPath);
        }

        void ExecuteSaveFileCommand()
        {
            File.WriteAllText(_localPath, TextFile);
        }

        async void ExecuteReadFileCommand()
        {
            using (var stream = await FileSystem.OpenAppPackageFileAsync(_file))
            {
                using (var reader = new StreamReader(stream))
                {
                    Text = await reader.ReadToEndAsync();
                }
            }
        }
    }
}
