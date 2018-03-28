using System;
using System.Linq;
using Cyclist.DataModel.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Cyclist.DataModel.GenericRepository.Repositories
{
    public class HistoryRepository : Repository<History>
    {
        public HistoryRepository(MongoDatabase db, string tblName) : base(db, tblName) { }

        public IQueryable<History> GetByUserId(String userId){
            return _collection.Find(Query.EQ("userId", userId)).AsQueryable();
        }
    }
}
