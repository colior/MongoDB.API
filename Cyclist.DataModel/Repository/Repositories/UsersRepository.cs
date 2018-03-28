using System;
using Cyclist.DataModel.Models;
using MongoDB.Driver;

namespace Cyclist.DataModel.GenericRepository.Repositories
{
    public class UsersRepository : Repository<User>
    {
        public UsersRepository(MongoDatabase db, string tblName) : base(db, tblName){}
    }
}
