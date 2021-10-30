using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;

namespace MongoLearning
{
    class 管理操作
    {
        public static void 删除数据库()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.DropDatabase("testRepo2");
        }
        /// <summary>
        /// 需要创建合集才能创建数据库
        /// </summary>
        public static void 创建数据库()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.GetDatabase("testRepo2").CreateCollection("d");
        }
        public static void 创建合集()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.GetDatabase("testRepo2").CreateCollection("d");
        }
        public static void 删除合集()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            client.GetDatabase("testRepo2").DropCollection("d");
        }
    }
}
