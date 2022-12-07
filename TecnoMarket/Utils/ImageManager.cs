namespace TecnoMarket.Utils
{
    public class ImageManager
    {
        public static List<string> ImageToBase64(IFormFileCollection formFiles)
        {
            List<string> images = new List<string>();
            using (var ms = new MemoryStream())
            {
                foreach (var file in formFiles)
                {
                    if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                    {
                        file.OpenReadStream().CopyTo(ms);
                        images.Add(Convert.ToBase64String(ms.GetBuffer()));
                    }
                }
            }
            return images;
        }
        public bool ImageBase64Comparer(string firstImage, string secondImage)
        {
            if (firstImage.Equals(secondImage))
            {
                return true;
            }
            else
            {
                 return true;
            }
        }
        public static List<string> ImageToBase64(IFormFileCollection formFiles, List<string> oldPictures)
        {
            List<string> images = new List<string>();
            using (var ms = new MemoryStream())
            {
                foreach (var file in formFiles)
                {
                    if (file.ContentType == "image/jpg" || file.ContentType == "image/jpeg" || file.ContentType == "image/png")
                    {
                        file.OpenReadStream().CopyTo(ms);
                        var convertedImage = Convert.ToBase64String(ms.GetBuffer());
                        foreach(var oldImage in oldPictures)
                        {
                            if (oldImage.Equals(convertedImage))
                            {
                                images.Add(convertedImage);
                            }
                        }
                    }
                }
            }
            return images;
        }
    }
}
