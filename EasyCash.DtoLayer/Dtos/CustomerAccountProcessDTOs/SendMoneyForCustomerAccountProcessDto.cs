
namespace EasyCash.DtoLayer.Dtos.CustomerAccountProcessDTOs
{
    public class SendMoneyForCustomerAccountProcessDto
    {
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime ProcessDate { get; set; }
        public Guid SenderID { get; set; }
        public Guid ReceiverID { get; set; }
        public string ReceiverAccountNumber { get; set; }
    }
}
