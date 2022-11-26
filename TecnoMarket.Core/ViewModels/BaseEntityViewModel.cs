namespace TecnoMarket.Core.ViewModels
{
    public class BaseEntityViewModel
    {
        public int Id { get; set; }
        public string UserCreator { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int StatuId { get; set; }
    }
}
