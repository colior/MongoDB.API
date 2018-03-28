using System;
using System.Linq;
using Cyclist.DataModel.Models;
using Cyclist.DataModel.UnitOfWork;

namespace Cyclist.Services
{
    public class HistoryService : IService<History>
    {
        public readonly UnitOfWork unitOfwork;

        public HistoryService()
        {
            unitOfwork = UnitOfWork.UnitOfWorkInstance();
        }

        public History Get(String id)
        {
            return unitOfwork.HistoryRepository.Get(id);
        }

        public IQueryable<History> GetAll()
        {
            return unitOfwork.HistoryRepository.GetAll();
        }

        public IQueryable<History> GetHistoryByUserId(String userId)
        {
            return unitOfwork.HistoryRepository.GetByUserId(userId);
        }

        public void Delete(String id)
        {
            unitOfwork.HistoryRepository.Delete(id);
        }

        public void Insert(History history)
        {
            unitOfwork.HistoryRepository.Add(history);
        }

        public void Update(History history)
        {
            unitOfwork.HistoryRepository.Update(history.Id, history);
        }

    }
}
