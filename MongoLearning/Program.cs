using System;

using MongoDB.Bson.Serialization;

namespace MongoLearning
{
    class Program
    {
        //Builders<T> 是操作的关键 包含映射，过滤，跟新，判断等
        static void Main(string[] args)
        {
            //注册
            //BsonClassMap.RegisterClassMap<Cat>(cm =>
            //{
            //    cm.MapProperty(c => c.Name);
            //    cm.MapProperty(c => c.KG);
            //    cm.MapProperty(c => c._id);
            //});

            基础操作.删除多项();
            
            基础操作.插入多项();
            基础操作.查询();
            //基础操作.更新();
            //基础操作.删除多项();
            //管理操作.创建数据库();
            //管理操作.删除数据库();
        }
    }
}
