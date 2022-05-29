using Microsoft.AspNetCore.Mvc;
using CoreLibrary;
using System.Collections.Generic;

namespace VegeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private string orderPath = @"..\CoreLibrary\data\orders.txt";
        private OrderStorage orderStorage = new OrderStorage();

        // POST api/<ManagerController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            try
            {
                orderStorage.ReadFromFile(orderPath);
                orderStorage.Add(order);
                orderStorage.WriteInFile(orderPath);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<ClientController>/order
        [HttpGet]
        public ActionResult<ICollection<Order>> GetOrder()
        {
            orderStorage.ReadFromFile(orderPath);
            return orderStorage.Orders;
        }

        // PUT api/<ClientController>
        [HttpPut("{id}")]
        public ActionResult<Order> Put(string id, [FromBody] Order order)
        {
            orderStorage.ReadFromFile(orderPath);
            order.Id = int.Parse(id);
            if (orderStorage.FindById(id) == null)
                return BadRequest();
            try
            {
                orderStorage.Change(order);
                orderStorage.WriteInFile(orderPath);
                return Ok(orderStorage.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<ClientController>
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            var order = orderStorage.FindById(id);
            if (order == null)
                return BadRequest();
            orderStorage.RemoveById(id);
            orderStorage.WriteInFile(orderPath);
            return Ok();
        }
    }  
}

