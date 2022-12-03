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
    }
}
