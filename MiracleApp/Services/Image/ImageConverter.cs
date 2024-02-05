namespace MiracleApp.Services.Converters
{
    public static class ImageConverter
    {
        public static async Task<byte[]> FileResultToByteArray(FileResult fileResult)
        {
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                Task<Stream> stream = fileResult.OpenReadAsync();
                stream.Result.CopyTo(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            return imageBytes;
        }
    }
}
