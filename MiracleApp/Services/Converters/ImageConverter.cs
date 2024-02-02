namespace MiracleApp.Services.Converters
{
    public static class ImageConverter
    {
        public static byte[] ImageSourceToByteArray(ImageSource imageSource)
        {
            byte[] imageBytes;
            if (imageSource is StreamImageSource streamImageSource)
            {
                using MemoryStream ms = new();
                Task<Stream> task = streamImageSource.Stream.Invoke(CancellationToken.None);
                Stream stream = task.Result;
                stream.CopyTo(ms);
                imageBytes = ms.ToArray();
            }
            else
            {
                if (imageSource is FileImageSource fileImageSource)
                {
                    string filePath = fileImageSource.File;
                    imageBytes = File.ReadAllBytes(filePath);
                }
                else
                {
                    return null;
                }
            }
            return imageBytes;
        }


        public static Stream FileResultToStream(FileResult fileResult)
        {
            byte[] imageBytes;
            using MemoryStream ms = new();
            Task<Stream> task = fileResult.OpenReadAsync();
            return task.Result;
        }
    }
}
