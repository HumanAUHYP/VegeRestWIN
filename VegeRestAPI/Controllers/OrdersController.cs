using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class OrdersController : ControllerBase
    {
        MenuStorage orderStorage;
        public OrdersController(IMenuStorage _projectStorage)
        {
            orderStorage = (MenuStorage)_projectStorage;
        }

        //GET all action
        [HttpGet]
        public ActionResult<List<Menu>> GetAll() => orderStorage.GetAll();

        [HttpGet("{orderNum}")]
        public ActionResult<Menu> Get(string orderNum)
        {
            var project = orderStorage.Get(orderNum);

            if (project == null)
                return NotFound();

            return project;
        }

        [HttpPost]
        public IActionResult Create(Menu order)
        {
            orderStorage.Add(order);
            return CreatedAtAction(nameof(Create), new { orderNum = order.OrderNumber }, order);
        }

        [HttpPut("{orderNum}")]
        public IActionResult Update(string orderNum, Menu order)
        {
            if (orderNum != order.OrderNumber)
                return BadRequest();

            var existingProject = orderStorage.Get(orderNum);
            if (existingProject is null)
                return NotFound();

            orderStorage.ReadyByNumber(orderNum);

            return NoContent();
        }

        [HttpDelete("{orderNum}")]
        public IActionResult Delete(string orderNum)
        {
            var project = orderStorage.Get(orderNum);

            if (project is null)
                return NotFound();

            orderStorage.RemoveById(orderNum);

            return NoContent();
        }

    }
}
