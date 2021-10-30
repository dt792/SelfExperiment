using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoLearning
{
    public enum Health
    {
        Good,Bad
    }
    public class Cat
    {
        [BsonIgnoreIfNull]
        public ObjectId _id { get; set; }

        public string Name { get; set; } = "新猫";
        [BsonIgnore]
        //不保存数据库也不查询 类似地[BsonIgnoreIfNull]
        public double KG = 3;
        //private字段也会序列化
        [BsonElement]
        private Health health { get; set; } = Health.Good;
    }

}
