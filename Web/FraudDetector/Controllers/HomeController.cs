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

        public JsonResult Getcategories(string categoryname = "", int categoryid = 0)
        {

            CategoryRepository repository = new CategoryRepository();
            string response = repository.GetCategories(categoryname, categoryid);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetcategorySegment(int CategoryId = 0)
        {
            CategorySegmentRepository repository = new CategorySegmentRepository();
            CategorySegment segment = new CategorySegment();
            segment.CategoryId = CategoryId;
            string response = repository.GetCategorySegment(segment);
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GerMerchantDetails(int merchantId = 0, bool mode = false, int riskScore = 0)
        {
            MerchantRepositary repositary = new MerchantRepositary();
            string response = repositary.GetMerchantDetails(merchantId, mode, riskScore);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustomerDetails(long customerId = 0)
        {
            CustomerRepository repository = new CustomerRepository();
            var l = repository.GetCustomerDetails(customerId);
            return Json(l, JsonRequestBehavior.AllowGet);
        }
        public JsonResult response(string id)
        {
            SelectOperation _selectOperation = new SelectOperation();
            var _response = _selectOperation.GetPendingTransactions(id);
            return Json(_response, JsonRequestBehavior.AllowGet);

        }
    }
}