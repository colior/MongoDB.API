using System;
using System.Collections.Generic;
using System.Linq;
using Cyclist.DataModel.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Cyclist.DataModel.GenericRepository.Repositories
{
    public class ReportsRepository : Repository<Report>
    {
        public ReportsRepository(MongoDatabase db, string tblName) : base(db, tblName) { }

        public IQueryable<Report> GetByUserId(String userId){
            return _collection.Find(Query.EQ("userId", userId)).AsQueryable();
        }
    }
}
