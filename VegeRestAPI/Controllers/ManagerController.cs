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
    }
}
