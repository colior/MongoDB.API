using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cyclist.DataModel.Models;
using Cyclist.Services;

namespace MongoAPI.Controllers
{
    [RoutePrefix("Cyclist/History")]
    public class HistoryController : ApiController
    {
        private readonly HistoryService historyService;

        public HistoryController()
        {
            historyService = new HistoryService();
        }

        [Route("History/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(String id)
        {
            var history = historyService.Get(id);
            if (history != null)
                return Request.CreateResponse(HttpStatusCode.OK, history);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "History not found for provided id.");
        }

        [Route("UserId/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetByUserId(String userId)
        {
            var report = historyService.GetHistoryByUserId(userId);
            if (report.Any())
                return Request.CreateResponse(HttpStatusCode.OK, report);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Report not found for provided id.");
        }

        [Route("All")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var history = historyService.GetAll();
            if (history.Any())
                return Request.CreateResponse(HttpStatusCode.OK, history);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No history found.");
        }

        [Route("NewHistory")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]History history)
        {
            historyService.Insert(history);
            return Request.CreateResponse(HttpStatusCode.OK, "History added successfuly");
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(String id)
        {
            historyService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "History " + id + " deleted successfuly");
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]History history)
        {
            historyService.Update(history);
            return Request.CreateResponse(HttpStatusCode.OK, "History " + history.Id + " updated successfuly");
        }
    }
}
