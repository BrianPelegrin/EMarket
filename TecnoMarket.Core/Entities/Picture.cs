namespace TecnoMarket.Core.Entities
{
    public  class Picture: BaseEntity
    {
        public string Image { get; set; }
        public virtual Statu Statu { get; set; }
    }
}
