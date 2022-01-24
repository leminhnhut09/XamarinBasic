
using System;
using System.IO;
using Xamarin.Essentials;

namespace XamarinEntity.Helpers
{
    public static class Constant
    {
        public static string DBPath = Path.Combine(FileSystem.AppDataDirectory, "student.db3");
        public static string DBPathBackup = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ,"studentBackup.db3");
        //public static string DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "student.db3");
        public static string StudentKey = "student";
        public static string GradeKey = "grade";
    }
}
