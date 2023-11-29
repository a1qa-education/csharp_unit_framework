using Aquality.Selenium.Core.Utilities;
using System.IO;
using System.Threading.Tasks;

namespace ExampleProject.Framework.Utils
{
    internal class FileUtils
    {
        protected static readonly JsonSettingsFile settings = new("config.json");

        public static bool IsFileExists(string filePath)
        {
            var task = new Task<bool>(() =>
            {
                var file = new FileInfo(filePath);
                return file.Exists;
            });
            task.Start();
            return task.Wait(settings.GetValue<int>("fileExistsTimeout")) && task.Result;
        }

        public static void DeleteFileIfExists(FileInfo fileName)
        {
          //to implement
        }
    }
}
