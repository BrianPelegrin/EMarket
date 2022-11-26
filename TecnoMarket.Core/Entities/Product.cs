namespace TecnoMarket.Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public virtual Statu Statu { get; set; }
        public virtual Category Category { get; set; }
    }
}
