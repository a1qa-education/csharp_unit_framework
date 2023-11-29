namespace ExampleProject.Framework.Tests
{
    internal class FileUploadTests : BaseTest
    {
        private static readonly string fileName = testdata.GetValue<string>("fileDownload.folderPath");
        private static readonly string filePath = testdata.GetValue<string>("fileDownload.fileName") + fileName;
    }
}
