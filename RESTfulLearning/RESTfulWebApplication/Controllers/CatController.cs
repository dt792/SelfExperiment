using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using RESTfulWebApplication.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTfulWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : Controller
    {
        static List<Cat> cats = new List<Cat>() { new Cat() { Discription="老猫"} };
        //获取所有猫猫
        // GET: api/<CatController>
        [HttpGet]
        public IEnumerable<Cat> Get()
        {
            return cats;
        }
        //获取指定猫猫
        // GET api/<CatController>/5
        [HttpGet("{id}")]
        public Cat Get(int id)
        {
            return cats[id];
        }

        // POST api/<CatController> 新建
        [HttpPost]
        public void Post([FromBody] Cat cat)
        {
            cats.Add(cat);
        }
        //更新猫猫
        // PUT api/<CatController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Cat cat)
        {
            cats[id] = cat;
        }
        //放跑猫猫
        // DELETE api/<CatController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cats.RemoveAt(id);
        }
    }
}
