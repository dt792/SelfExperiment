using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeLearning.Models
{
    class GeoObject
    {
        public string Name;
        public ColorEnum Color;
        public double Area;
        public override string ToString()
        {
            return $"名称：{Name},颜色：{Color},面积：{Area},";
        }
    }
}
