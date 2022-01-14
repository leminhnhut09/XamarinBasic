
using System.IO;
using Xamarin.Essentials;

namespace XamarinEntity.Helpers
{
    public static class Constant
    {
        public static string DBPath = Path.Combine(FileSystem.AppDataDirectory, "student.db3");
        public static string StudentKey = "student";
    }
}
