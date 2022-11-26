namespace TecnoMarket.Core.ViewModels
{
    public class CategoryViewModel: BaseEntityViewModel
    {
        public string Description { get; set; }

        public virtual StatuViewModel Statu { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; } = null!;
    }
}