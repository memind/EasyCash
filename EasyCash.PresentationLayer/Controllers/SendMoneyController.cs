using EasyCash.BusinessLayer.Abstract;
using EasyCash.DataAccessLayer.Concrete;
using EasyCash.DtoLayer.Dtos.CustomerAccountProcessDTOs;
using EasyCash.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCash.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string myCurrency)
        {
            ViewBag.Currency = myCurrency;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto model)
        {
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == model.ReceiverAccountNumber).Select(y => y.CustomerAccountID).FirstOrDefault();

            var senderAccountNumberID = context.CustomerAccounts.Where(x => x.AppUserId == user.Id).Where(y => y.CustomerAccountCurrency == "TL").Select(z => z.CustomerAccountID).FirstOrDefault();

            var values = new CustomerAccountProcess()
            {
                ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                SenderID = senderAccountNumberID,
                ProcessType = "Havale",
                ReceiverID = receiverAccountNumberID,
                Amount = model.Amount,
                Description = model.Description
            };

            _customerAccountProcessService.TInsert(values);

            return RedirectToAction("Index", "Deneme");
        }
    }
}
