
namespace EasyCash.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public Guid CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
        public string Description { get; set; }
        public Guid? SenderID { get; set; }
        public Guid? ReceiverID { get; set; }
        public CustomerAccount SenderCustomer { get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }
    }
}
