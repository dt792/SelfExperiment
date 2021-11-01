using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SerializeLearning.Models;

namespace SerializeLearning
{
    class Json序列化
    {
        public static void 枚举序列化()
        {
            //直接系列化
            var str = JsonConvert.SerializeObject(ColorEnum.Black);
            Console.WriteLine(str);
            //包含在对象内序列化
            GeoObject geoObject = new GeoObject() { Name = "A", Color = ColorEnum.Black, Area = 0.5 };
            str = JsonConvert.SerializeObject(geoObject);
            Console.WriteLine(str);
        }
        public static void 枚举反序列化()
        {
            ColorEnum color =(ColorEnum) JsonConvert.DeserializeObject<ColorEnum>("5");
            Console.WriteLine(color);
            GeoObject geoObject = (GeoObject)JsonConvert.DeserializeObject<GeoObject>("{\"Name\":\"A\",\"Color\":5,\"Area\":0.5}");
            Console.WriteLine(geoObject);
        }
    }
}
