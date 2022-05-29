using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using CoreLibrary;
using System.Net;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace VegeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private string menuPath = @"..\CoreLibrary\data\menu.txt";
        private readonly MenuStorage menuStorage;

        private readonly ILogger<ManagerController> _logger;
        public ManagerController(ILogger<ManagerController> logger)
        {
            _logger = logger;
            menuStorage = new MenuStorage();
            menuStorage.ReadFromFile(menuPath);
        }

        // GET api/<ManagerController>/menu
        [HttpGet]
        public ActionResult<ICollection<Menu>> GetAllMenu()
        {
            return menuStorage.Menues;
        }
        [HttpGet("{Id}")]
        public ActionResult<Menu> GetMenuById(string id)
        {
            return menuStorage.FindById(id);
        }

        // POST api/<ManagerController>
        [HttpPost]
        public ActionResult Post([FromBody] Menu menu)
        {
            try
            {
                menuStorage.Add(menu);
                menuStorage.WriteInFile(menuPath);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<ManagerController>
        [HttpPut("{id}")]
        public ActionResult<Menu> Put(string id, [FromBody] Menu menu)
        {
            menu.Id = int.Parse(id);
            if (menuStorage.FindById(id) == null)
                return BadRequest();
            try
            {
                menuStorage.Change(menu);
                menuStorage.WriteInFile(menuPath);
                return Ok(menuStorage.FindById(id));
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<ManagerController>
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var menu = menuStorage.FindById(id);
            if (menu == null)
                return BadRequest();
            menuStorage.RemoveById(id);
            menuStorage.WriteInFile(menuPath);
            return Ok();
        }
    }
}
