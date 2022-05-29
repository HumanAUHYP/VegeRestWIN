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
        [HttpPost("{clientName}, {tableNum}")]
        public ActionResult Post([FromBody] Order order, string clientName, string tableNum)
        {
            try
            {
                ClientStorage.Add(new Client($"{1};{clientName};{tableNum}"));
                orderStorage.Add(order);
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
            return orderStorage.Orders;
        }

        // PUT api/<ClientController>
        [HttpPut("{id}")]
        public ActionResult<Order> Put(string id, [FromBody] Order order)
        {
            order.Id = int.Parse(id);
            if (orderStorage.FindById(id) == null)
                return BadRequest();
            try
            {
                orderStorage.Change(order);
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

