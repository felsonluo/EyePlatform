using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB;
using System.Configuration;
using System.Linq.Expressions;

namespace Eye.Common
{
    /// <summary>
    /// Mongo帮助类
    /// </summary>
    public class MongoDBHelper<T> where T: BaseModel
    {

        private IMongoDatabase database;
        private MongoClient client;
        private IMongoCollection<T> collection;

        private static string _connectionString;
        private static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    _connectionString = ConfigurationManager.AppSettings["MongoDBConnction"];
                }
                return _connectionString;
            }
        }


        /// <summary>
        /// 默认构造函数
        /// </summary>
        public MongoDBHelper()
        {
            client = new MongoClient(ConnectionString);
            database = client.GetDatabase(new MongoUrl(ConnectionString).DatabaseName);
            collection = database.GetCollection<T>(typeof(T).Name);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="databaseName"></param>
        public MongoDBHelper(string connection)
        {
            client = new MongoClient(connection);
            database = client.GetDatabase(new MongoUrl(ConnectionString).DatabaseName);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="databaseName"></param>
        public MongoDBHelper(string connection, string databaseName)
        {
            client = new MongoClient(connection);
            database = client.GetDatabase(databaseName);
        }


        /// <summary>
        /// 获取集合
        /// </summary>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public virtual IMongoCollection<T> GetCollection(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }


        /// <summary>
        /// 根据条件查询数据库,如果存在返回第一个对象
        /// </summary>
        /// <param name="filter">条件表达式</param>
        /// <returns>存在则返回指定的第一个对象,否则返回默认值</returns>
        public virtual T FindSingle(FilterDefinition<T> filter)
        {
            return collection.Find(filter).FirstOrDefault();
        }


        /// <summary>
        /// 插入多条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(IEnumerable<T> list)
        {
            if (this.database == null) return false;

            try
            {
                //批量插入
                collection.InsertMany(list);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 插入单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Insert(T t)
        {
            if (this.database == null) return false;

            try
            {
                //批量插入
                collection.InsertOne(t);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// 返回可查询的记录源
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetQueryable()
        {
            IQueryable<T> query = collection.AsQueryable();

            return query;
        }

        /// <summary>
        /// 根据条件表达式返回可查询的记录源
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="sortPropertyName">排序表达式</param>
        /// <param name="isDescending">如果为true则为降序，否则为升序</param>
        /// <returns></returns>
        public virtual IFindFluent<T, T> GetQueryable(FilterDefinition<T> query)
        {
            IFindFluent<T, T> queryable = collection.Find(query);

            return queryable;
        }

        /// <summary>
        /// 根据条件表达式返回可查询的记录源
        /// </summary>
        /// <param name="match">查询条件</param>
        /// <param name="orderByProperty">排序表达式</param>
        /// <param name="isDescending">如果为true则为降序，否则为升序</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetQueryable<TKey>(Expression<Func<T, bool>> match)
        {
            IQueryable<T> query = collection.AsQueryable();

            if (match != null)
            {
                query = query.Where(match);
            }

            return query;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public List<T> FindAll()
        {
            return GetQueryable().ToList();
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> Find(Expression<Func<T, bool>> match)
        {
            return GetQueryable(match).ToList();
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <returns>指定对象的集合</returns>
        public virtual IList<T> Find(FilterDefinition<T> query)
        {
            return GetQueryable(query).ToList();
        }


        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <param name="id">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Update(T t, string id)
        {

            bool result = false;
            //使用 IsUpsert = true ，如果没有记录则写入
            var update = collection.ReplaceOne(s => s.EId == id, t, new UpdateOptions() { IsUpsert = true });
            result = update != null && update.ModifiedCount > 0;

            return result;
        }

        /// <summary>
        /// 封装处理更新的操作(部分字段更新)
        /// </summary>
        /// <param name="id">主键的值</param>
        /// <param name="update">更新对象</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Update(string id, UpdateDefinition<T> update)
        {
            
            var result = collection.UpdateOne(s => s.EId == id, update, new UpdateOptions() { IsUpsert = true });
            return result != null && result.ModifiedCount > 0;
        }


        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定对象
        /// </summary>
        /// <param name="id">对象的ID</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool Delete(string id)
        {
            var result = collection.DeleteOne(s => s.EId == id);
            return result != null && result.DeletedCount > 0;
        }

        /// <summary>
        /// 根据指定对象的ID,从数据库中删除指定指定的对象
        /// </summary>
        /// <param name="idList">对象的ID集合</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteBatch(List<string> idList)
        {
            
            var result = collection.DeleteMany(s => idList.Contains(s.EId));
            return result != null && result.DeletedCount > 0;
        }

        /// <summary>
        /// 根据指定条件,从数据库中删除指定对象
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteByExpression(Expression<Func<T, bool>> match)
        {
            collection.AsQueryable().Where(match).ToList().ForEach(s => collection.DeleteOne(t => t.EId == s.EId));
            return true;
        }

        /// <summary>
        /// 根据指定条件,从数据库中删除指定对象
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c>。</returns>
        public virtual bool DeleteByQuery(FilterDefinition<T> query)
        {
            var result = collection.DeleteMany(query);
            return result != null && result.DeletedCount > 0;
        }
    }
}
