using TecnoMarket.Core.Entities.SecurityEntities;

namespace TecnoMarket.Core.ViewModels
{
    public class TransactionViewModel : BaseEntityViewModel
    {
        public string ApplicationUserId { get; set; }
        public int ProductId { get; set; }
        public Guid TransactionIdentifier { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
