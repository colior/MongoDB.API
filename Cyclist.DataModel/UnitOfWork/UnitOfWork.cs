using MongoDB.Driver;
using Cyclist.DataModel.GenericRepository.Repositories;
using Cyclist.DataModel.Models;

namespace Cyclist.DataModel.UnitOfWork
{
    public class UnitOfWork
    {
        private MongoDatabase database;  
        protected UsersRepository usersRepository;
        protected ReportsRepository reportsRepository;
        protected HistoryRepository historyRepository;
        private static UnitOfWork unitOfWork;

        public static UnitOfWork UnitOfWorkInstance(){
            
            if(unitOfWork == null){
                unitOfWork = new UnitOfWork();
            }

            return unitOfWork;
        }

        private UnitOfWork(){
            var client = new MongoClient("mongodb://Cyclist01:K3d-LS3-s8P-4Re@cyclist-shard-00-00-jomwu.mongodb.net:27017,cyclist-shard-00-01-jomwu.mongodb.net:27017,cyclist-shard-00-02-jomwu.mongodb.net:27017/test?ssl=true&replicaSet=Cyclist-shard-0&authSource=admin");
            var server = client.GetServer();
            database = server.GetDatabase("Cyclist");
        }

        public UsersRepository UsersRepository
        {
            get
            {
                if (usersRepository == null) usersRepository = new UsersRepository(database, "Users");
                return usersRepository;
            }
        }

        public ReportsRepository ReportsRepository
        {
            get
            {
                if (reportsRepository == null) reportsRepository = new ReportsRepository(database, "Reports");
                return reportsRepository;
            }
        }

        public HistoryRepository HistoryRepository
        {
            get
            {
                if (historyRepository == null) historyRepository = new HistoryRepository(database, "History");
                return historyRepository;
            }
        }
    }
}
