using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cyclist.DataModel.Models;
using Cyclist.Services;

namespace MongoAPI.Controllers
{
    [RoutePrefix("Cyclist/Reports")]
    public class ReportsController : ApiController
    {
        private readonly ReportService reportService;

        public ReportsController()
        {
            reportService = new ReportService();
        }

        [Route("UserId/{userId}")]
        [HttpGet]
        public HttpResponseMessage GetByUserId(String userId)
        {
            var report = reportService.GetReportsByUserId(userId);
            if (report.Any())
                return Request.CreateResponse(HttpStatusCode.OK, report);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Report not found for provided id.");
        }

        [Route("Report/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(String id)
        {
            var report = reportService.Get(id);
            if (report != null)
                return Request.CreateResponse(HttpStatusCode.OK, report);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Report not found for provided id.");
        }

        [Route("All")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var report = reportService.GetAll();
            if (report.Any())
                return Request.CreateResponse(HttpStatusCode.OK, report);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No report found.");
        }

        [Route("NewReport")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Report report)
        {
            reportService.Insert(report);
            return Request.CreateResponse(HttpStatusCode.OK, "Report added successfuly");
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(String id)
        {
            reportService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Report " + id + " deleted successfuly");
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Put([FromBody]Report report)
        {
            reportService.Update(report);
            return Request.CreateResponse(HttpStatusCode.OK, "Report " + report.ReportId + " updated successfuly");
        }
    }
}
