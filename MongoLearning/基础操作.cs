using System.Collections.Generic;
using System.Linq;

using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoLearning
{
    class 基础操作
    {
        FilterDefinition<Cat> EmptyFilter = Builders<Cat>.Filter.Empty;
        public static IMongoCollection<Cat> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("testDB");
            var collection = database.GetCollection<Cat>("testRepo");
            return collection;
        }
        public static void 连接数据库()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("testDB");
            var collection = database.GetCollection<BsonDocument>("testRepo");
        }
        public static void 插入()
        {
            var collection = GetCollection();
            collection.InsertOne(new Cat());
        }
        public static void 插入多项()
        {
            List<Cat> cats = new List<Cat>() { new Cat(), new Cat() { Name = "gg" } };
            var collection = GetCollection();
            collection.InsertMany(cats);
        }
        public static void 查询()
        {
            var collection = GetCollection();
            var cats = collection.Find(FilterDefinition<Cat>.Empty).ToList();
        }
        public static void 条件查询()
        {
            var collection = GetCollection();
            var filter = Builders<Cat>.Filter;
            var cats = collection.Find(filter.Eq(nameof(Cat.Name), "新猫")).ToList();
        }
        public static void 查询排序()
        {
            var collection = GetCollection();
            var cats = collection.Find(FilterDefinition<Cat>.Empty)
                .Sort(Builders<Cat>.Sort.Ascending("Name")).ToList();
        }
        public static void 范围查询()
        {
            int start = 0;
            int size = 1;
            var collection = GetCollection();
            var cats = collection.Find(FilterDefinition<Cat>.Empty).Skip(start).Limit(size).ToList();
        }
        public static void 内容部分查询()
        {
            var collection = GetCollection();
        }
        public static void 更新()
        {
            var collection = GetCollection();
           
            var cat = collection.Find(FilterDefinition<Cat>.Empty).ToList().First();
            cat.Name = "20";
            //收集修改的内容
            List<UpdateDefinition<Cat>> updateDefinitions = new();
            foreach (var propInfo in cat.GetType().GetProperties())
            {
                if (propInfo.Name == "_id") continue;
                var update = Builders<Cat>.Update.Set(propInfo.Name, propInfo.GetValue(cat));
                updateDefinitions.Add(update);
            }
            foreach (var update in updateDefinitions)
            {
                collection.UpdateOne(Builders<Cat>.Filter.Eq(nameof(Cat._id), cat._id), update);
            }
        }
        public static void 删除()
        {
            var collection = GetCollection();
            collection.DeleteOne(FilterDefinition<Cat>.Empty);
        }
        public static void 删除多项()
        {
            var collection = GetCollection();
            collection.DeleteMany(FilterDefinition<Cat>.Empty);
        }

    }
}
