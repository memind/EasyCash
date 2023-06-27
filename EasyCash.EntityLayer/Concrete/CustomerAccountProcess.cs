
namespace EasyCash.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public Guid CustomerAccountProcessID { get; set; }
        public string ProcessType { get; set; }
        public decimal Amount { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
