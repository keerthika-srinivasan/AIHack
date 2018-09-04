using common.Model.v1;
using Common.Model;
using CoreEngine.Repository;
using CoreEngine.Repository.v1;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace FraudDetector.Controllers
{
    public class DashboardController : ApiController
    {
        public DashboardController()
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

        [System.Web.Mvc.HttpPost]
        public bool ProcessTransactionRecord(ProcessRecordRequest request)
        {
            InsertOperation _insertOperation = new InsertOperation();
            _insertOperation.UpdateFraudStatus(request.TransactionId, (request.IsFraud == "y"));
            return true;

        }

        public IHttpActionResult Getcategories()
        {
            CategoryRepository repository = new CategoryRepository();
            var s = repository.GetCategories("Test", 1);
            return Ok(new { results = s });
        }

        public IHttpActionResult GetcategorySegment()
        {
            CategorySegmentRepository repository = new CategorySegmentRepository();
            CategorySegment segment = new CategorySegment();
            segment.CategoryId = 1;
            var l = repository.GetCategorySegment(segment);
            return Ok(new { results = l });

        }

        public IHttpActionResult GerMerchantDetails()
        {
            MerchantRepositary repositary = new MerchantRepositary();
            var l = repositary.GetMerchantDetails(1, false, 1);
            return Ok(new { results = l });
        }

        public IHttpActionResult GetCustomerDetails()
        {
            CustomerRepository repository = new CustomerRepository();
            CustomerDetails details = new CustomerDetails();
            var l = repository.GetCustomerDetails(1);
            return Ok(new { results = l });
        }
        public IHttpActionResult response(string id)
        {
            //  DashBoardResponse _response = new DashBoardResponse();
            List<DashBoardResponse> _response = new List<DashBoardResponse>();
            SelectOperation _selectOperation = new SelectOperation();
            _response = _selectOperation.GetPendingTransactions(id);

            return Ok(new { results = _response });
        }
    }
}