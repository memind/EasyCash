
namespace EasyCash.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        public Guid CustomerAccountID { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set; }
        public decimal CustomerAccountBalance { get; set; }
        public string BankBranch { get; set; }

        // Nav Props
        public Guid AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
