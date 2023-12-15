namespace Ensek.TechTest.MeterRead.Api.Util
{
    public static class UploadControllerHelper
    {
        public static async Task<MemoryStream> BuildMemoryStream(IFormFile formFile)
        {
            var targetStream = new MemoryStream();
            await formFile.CopyToAsync(targetStream);
            targetStream.Seek(0, SeekOrigin.Begin);
            return targetStream;
        }
    }
}
