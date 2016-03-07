using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using WebAPIMvc5.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIMvc5.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        /// <summary>
        /// This defines an empty controller class. In the next sections, we’ll add methods to implement the API. 
        /// The [FromServices] attribute tells MVC to inject the ITodoRepository that we registered in the Startup class.
        /// </summary>
        [FromServices]
        public ITodoRepository TodoItems { get; set; }


        [HttpGet]
        public IEnumerable<TodoItem> GetAll()
        {
            return TodoItems.GetAll();
        }

        //注意，这儿的Name指的是路由名称，参见下面的CreateAtRoute
        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(string id)
        {
            var item = TodoItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return HttpBadRequest();
            }
            TodoItems.Add(item);

            //The CreatedAtRoute method returns a 201 response, which is the standard response for an HTTP POST method that creates a new resource on the server. CreateAtRoute also adds a Location header to the response. The Location header specifies the URI of the newly created to-do item. See 10.2.2 201 Created.
            return CreatedAtRoute("GetTodo", new { controller = "Todo", id = item.Key }, item);
        }

        /// <summary>
        /// Update is similar to Create, but uses HTTP PUT. 
        /// The response is 204 (No Content).
        ///  According to the HTTP spec, a PUT request requires the client to send the entire updated entity, not just the deltas. 
        /// To support partial updates, use HTTP PATCH.
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] TodoItem item)
        {
            //如果参数中的Id和Item中的Key不同时，返回400，提示：请求无效 (Bad request)
            if (item == null || item.Key != id)
            {
                return HttpBadRequest();
            }


            var todo = TodoItems.Find(id);
            if (todo == null)
            {
                //404 
                return HttpNotFound();
            }

            TodoItems.Update(item);
            return new NoContentResult(); //204 更新不提供结果
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            TodoItems.Remove(id);
        }


    }
}

