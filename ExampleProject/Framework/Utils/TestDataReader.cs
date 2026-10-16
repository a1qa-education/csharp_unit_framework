using ExampleProject.Framework.Models;
using Newtonsoft.Json;

namespace ExampleProject.Framework.Utils
{
    public static class TestDataReader
    {
        private static readonly string TestDataPath = Path.Combine(AppContext.BaseDirectory, "Resources", "TestData");
        private static readonly string EmailDataFilePath = Path.Combine(TestDataPath, "emailData.json");

        public static EmailData GetEmailData()
        {
            return JsonConvert.DeserializeObject<EmailData>(File.ReadAllText(EmailDataFilePath))
                ?? throw new InvalidOperationException($"Failed to deserialize test data from {EmailDataFilePath}");
        }
    }
}