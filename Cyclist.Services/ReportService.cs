using System;
using System.Collections.Generic;
using System.Linq;
using Cyclist.DataModel.Models;
using Cyclist.DataModel.UnitOfWork;
using MongoDB.Driver;

namespace Cyclist.Services
{
    public class ReportService : IService<Report>
    {
        public readonly UnitOfWork unitOfwork;

        public ReportService()
        {
            unitOfwork = UnitOfWork.UnitOfWorkInstance();
        }

        public Report Get(String id)
        {
            return unitOfwork.ReportsRepository.Get(id);
        }

        public IQueryable<Report> GetReportsByUserId(String userId){
            return unitOfwork.ReportsRepository.GetByUserId(userId);
        }

        public IQueryable<Report> GetAll()
        {
            return unitOfwork.ReportsRepository.GetAll();
        }

        public void Delete(String id)
        {
            unitOfwork.ReportsRepository.Delete(id);
        }

        public void Insert(Report report)
        {
            unitOfwork.ReportsRepository.Add(report);
        }

        public void Update(Report report)
        {
            unitOfwork.ReportsRepository.Update(report.ReportId, report);
        }

    }
}
