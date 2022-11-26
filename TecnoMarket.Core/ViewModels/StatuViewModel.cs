namespace TecnoMarket.Core.ViewModels
{
    public class StatuViewModel: BaseEntityViewModel
    {
        public string Description { get; set; }

        public virtual ICollection<CategoryViewModel> Categories { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}