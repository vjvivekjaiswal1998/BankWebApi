using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.BLL;
using BankManagement.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    public class BankController : Controller
    {
        private readonly IBank _bank;
        public BankController(IBank bank)
        {
            _bank = bank;
        }

        public IActionResult Index()
        {
        //    ViewData["Message"] = "Welcome";
            ViewBag.Welcome = "Welcome to this website . This website is for Bank Management system";
            ViewData["Message"] = "Hello Vivek R Jaiswal!";
            return View();
        }
        BankDetail bankDetail = new BankDetail();

        //To Show All Bank Detail.
        [HttpGet]
        public IActionResult ShowAllBankDetail()
        {
            List<BankDetail> BankList = new List<BankDetail>();
            BankList = _bank.ShowAllBankDetail();

            return View(BankList);

        }
        // To Show Single Bank Detail.
        [HttpGet]
        public IActionResult GetBankDetail(int accountNumber)
        {
            
            bankDetail = _bank.GetSingleBankAccountDetail(accountNumber);

            return View(bankDetail);
           
        }
        //To Insert The Data In Bank Data Base.
        //[httpGet]

        public IActionResult Add(BankDetail bankDetail)
        {
            _bank.AddBankDetail(bankDetail);
            return View("AddBankDetail");
        }
        public IActionResult AddBankDetail()
        {        
            return View();
        }
        //To Update The Data In Bank Data Base.
        //[HttpPut]
        public IActionResult UpdateBankDetail(int accountNumber, string CustomerEmail , string CustomerPhoneNumber)
        {
            _bank.UpdatebankDetail(accountNumber , CustomerEmail , CustomerPhoneNumber);
            return View(bankDetail);        
        }
        //To Delete The Data In BanK Data Base.
    //    [HttpDelete]
        public IActionResult DeleteBankDetail(int accountNumber)
        {
            _bank.DeleteBankDetail(accountNumber);
            return View(bankDetail);
          
        }
     
    }
}