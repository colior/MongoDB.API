using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cyclist.DataModel.GenericRepository
{
    public class Repository<T> where T : class
    {
        protected MongoDatabase _database;
        protected string _tableName;
        protected MongoCollection<T> _collection;

        // constructor to initialise database and table/collection  
        public Repository(MongoDatabase db, string tblName)
        {
            _database = db;
            _tableName = tblName;
            _collection = _database.GetCollection<T>(tblName);
        }


        /// <summary>
        /// Generic Get method to get record on the basis of id
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public T Get(String i)
        {
            return _collection.FindOneById(i);

        }

        /// <summary>
        /// Get all records 
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            MongoCursor<T> cursor = _collection.FindAll();
            return cursor.AsQueryable();

        }

        /// <summary>
        /// Generic add method to insert enities to collection 
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _collection.Insert(entity);
        }

        /// <summary>
        /// Generic delete method to delete record on the basis of id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(String id)
        {
            var query = Query.EQ("_id", id);
            _collection.Remove(query);
        }

        /// <summary>
        ///  Generic update method to delete record on the basis of id
        /// </summary>
        /// <param name="queryExpression"></param>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        public void Update(String id, T entity)
        {
            var query = Query.EQ("_id", id);
            _collection.Update(query, Update<T>.Replace(entity));
        }

    }
}
