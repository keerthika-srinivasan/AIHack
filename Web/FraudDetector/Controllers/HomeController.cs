using common.Model.v1;
using Common.Model;
using CoreEngine.Repository;
using CoreEngine.Repository.v1;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace FraudDetector.Controllers
{
    public class HomeController : Controller
    { 
        public HomeController()
        {

        }
        public bool Validate(TransactionRequest request)
        {
            //Test commit process
           return request.CardNumber == "1";
           
        }
        [System.Web.Mvc.HttpPost]
        public bool ValidatePost(TransactionRequest request)
        {
            return request.CardNumber == "1";

        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            CustomerRepository repository = new CustomerRepository();
            repository.GetCustomerDetails(1);
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [System.Web.Mvc.HttpPost]
        public bool ProcessTransactionRecord(ProcessRecordRequest request)
        {
            InsertOperation _insertOperation = new InsertOperation();
            _insertOperation.UpdateFraudStatus(request.TransactionId, (request.IsFraud == "y"));
            return true;
           
        }

        public JsonResult Getcategories()
        {
            
            CategoryRepository repository = new CategoryRepository();
             string response=repository.GetCategories("Test", 1);
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetcategorySegment()
        {
            CategorySegmentRepository repository = new CategorySegmentRepository(); 
            CategorySegment segment = new CategorySegment();
            segment.CategoryId = 1;
            string response = repository.GetCategorySegment(segment);
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GerMerchantDetails()
        {
            MerchantRepositary repositary = new MerchantRepositary();
            string response=repositary.GetMerchantDetails(1, false, 1);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerDetails()
        { CustomerRepository repository = new CustomerRepository();
            CustomerDetails details = new CustomerDetails();
            var l = repository.GetCustomerDetails(1);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public string response(string id)
        {
            //  DashBoardResponse _response = new DashBoardResponse();
            List<DashBoardResponse> _response = new List<DashBoardResponse>();
            SelectOperation _selectOperation = new SelectOperation();
            _response= _selectOperation.GetPendingTransactions(id);

            //List<DashBoardResponse> _response = new List<DashBoardResponse>()
            //{
            //    new DashBoardResponse
            //    {
            //        CardNumber="fgdffgdgdf",
            //        TransactionId="sdfhsdjf",
            //        TransDt="23-09-1222",
            //        UniqueId="456"
            //    },
            //    new DashBoardResponse
            //    {
            //        CardNumber="sdgjhdf",
            //        TransactionId="634785634785",
            //          TransDt="23-09-1222",
            //        UniqueId="4567"
            //    },
            //    new DashBoardResponse
            //    {
            //        CardNumber="dshfgsdf",
            //        TransactionId="347865378456",
            //          TransDt="23-09-1222",
            //        UniqueId="4560"
            //    },
            //    new DashBoardResponse
            //    {
            //        CardNumber="gffgdfsdfs",
            //        TransactionId="15244523423",
            //          TransDt="23-09-1222",
            //        UniqueId="4564"
            //    },
            //    new DashBoardResponse
            //    {
            //        CardNumber="5476754",
            //        TransactionId="5423554",
            //          TransDt="23-09-1222",
            //        UniqueId="45687"
            //    },


            //};
           return Newtonsoft.Json.JsonConvert.SerializeObject(_response);
        }
    }
}