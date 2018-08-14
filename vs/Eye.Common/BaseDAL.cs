using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB;
using System.Configuration;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Eye.Common
{
    /// <summary>
    /// Mongo帮助类
    /// </summary>
    public class BaseDAL<T> where T : BaseModel, new()
    {

        private IMongoDatabase database;
        private MongoClient client;
        private IMongoCollection<T> collection;


        public bool IsDescending { get; set; }

        public Expression<Func<T, bool>> SortPropertyName { get; set; }

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
        public BaseDAL()
        {
            client = new MongoClient(ConnectionString);
            database = client.GetDatabase(new MongoUrl(ConnectionString).DatabaseName);
            var collectionName = ("c" + "_" + typeof(T).Name.Replace("Model", "")).ToLower();

            var cList = database.ListCollectionNames()?.ToList();

            if (cList == null || !cList.Contains(collectionName))
            {
                database.CreateCollection(collectionName);
            }

            collection = database.GetCollection<T>(collectionName);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="databaseName"></param>
        public BaseDAL(string connection)
        {
            client = new MongoClient(connection);
            database = client.GetDatabase(new MongoUrl(ConnectionString).DatabaseName);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="databaseName"></param>
        public BaseDAL(string connection, string databaseName)
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
        /// 查询数据库,检查是否存在指定ID的对象
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        public virtual T FindByID(string id)
        {
            return collection.Find(s => s.EId == id).FirstOrDefault();
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
        /// 查询数据库,检查是否存在指定ID的对象（异步）
        /// </summary>
        /// <param name="key">对象的ID值</param>
        /// <returns>存在则返回指定的对象,否则返回Null</returns>
        public virtual async Task<T> FindByIDAsync(string id)
        {
            return await collection.FindAsync(s => s.EId == id).Result.FirstOrDefaultAsync();
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
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="match"></param>
        /// <param name="orderByProperty"></param>
        /// <param name="isDescending"></param>
        /// <returns></returns>
        public virtual IQueryable<T> GetQueryable<TKey>(Expression<Func<T, bool>> match)
        {
            return GetQueryable(match, this.SortPropertyName, this.IsDescending);
        }


        /// <summary>
        /// 根据条件表达式返回可查询的记录源
        /// </summary>
        /// <param name="match">查询条件</param>
        /// <param name="orderByProperty">排序表达式</param>
        /// <param name="isDescending">如果为true则为降序，否则为升序</param>
        /// <returns></returns>
        public virtual IQueryable<T> GetQueryable<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        {
            IQueryable<T> query = collection.AsQueryable();

            if (match != null)
            {
                query = query.Where(match);
            }

            if (orderByProperty != null)
            {
                query = isDescending ? query.OrderByDescending(orderByProperty) : query.OrderBy(orderByProperty);
            }
            else
            {
                query = isDescending ? query.OrderByDescending(this.SortPropertyName) : query.OrderBy(this.SortPropertyName);
            }
            return query;
        }

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public virtual List<T> FindAll()
        {
            return GetQueryable().ToList();
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <param name="orderByProperty">排序表达式</param>
        /// <param name="isDescending">如果为true则为降序，否则为升序</param>
        /// <returns></returns>
        public virtual IList<T> Find<TKey>(Expression<Func<T, bool>> match, Expression<Func<T, TKey>> orderByProperty, bool isDescending = true)
        {
            return GetQueryable<TKey>(match, orderByProperty, isDescending).ToList();
        }

        /// <summary>
        /// 根据条件查询数据库,并返回对象集合(用于分页数据显示)
        /// </summary>
        /// <param name="match">条件表达式</param>
        /// <param name="info">分页实体</param>
        /// <returns>指定对象的集合</returns>
        public virtual IList<T> FindWithPager(Expression<Func<T, bool>> match, PagerInfo info)
        {
            int pageindex = (info.CurrentPageIndex < 1) ? 1 : info.CurrentPageIndex;
            int pageSize = (info.PageSize <= 0) ? 20 : info.PageSize;

            int excludedRows = (pageindex - 1) * pageSize;

            IQueryable<T> query = GetQueryable<string>(match);
            info.RecordCount = query.Count();

            return query.Skip(excludedRows).Take(pageSize).ToList();
        }

        /// <summary>
        /// 插入单条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool Insert(T t)
        {

            //批量插入
            collection.InsertOne(t);

            return true;
        }

        /// <summary>
        /// 插入多条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertBatch(IEnumerable<T> list)
        {
            //批量插入
            if (list != null && list.Any())
                collection.InsertMany(list);

            return true;
        }

        /// <summary>
        /// 插入多条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool InsertOrUpdateBatch(IEnumerable<T> list)
        {
            var newItems = list.Where(x => x.EIsNew);

            var oldItems = list.Where(x => !x.EIsNew);
            //批量插入
            if (newItems != null && newItems.Any())
                collection.InsertMany(newItems);

            if (oldItems != null && oldItems.Any())
                UpdateBatch(oldItems);

            return true;
        }

        /// <summary>
        /// 更新对象属性到数据库中
        /// </summary>
        /// <param name="t">指定的对象</param>
        /// <param name="id">主键的值</param>
        /// <returns>执行成功返回<c>true</c>，否则为<c>false</c></returns>
        public virtual bool Update(T t)
        {

            bool result = false;
            //使用 IsUpsert = true ，如果没有记录则写入
            var update = collection.ReplaceOne(s => s._id == t._id, t, new UpdateOptions() { IsUpsert = true });
            result = update != null && update.ModifiedCount > 0;

            return result;
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public virtual bool UpdateBatch(IEnumerable<T> ts)
        {
            foreach (var x in ts)
            {
                if (!Update(x))
                    return false;
            }

            return true;
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
