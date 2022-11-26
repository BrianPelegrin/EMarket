namespace TecnoMarket.Core.ViewModels
{
    public class ProductViewModel : BaseEntityViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual StatuViewModel Statu { get; set; }
        public virtual CategoryViewModel Category { get; set; }
    }
}
