namespace TecnoMarket.Core.ViewModels
{
    public class ProductPictureViewModel: PictureViewModel
    {
        public int ProductId { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}
