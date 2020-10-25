using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Model;
using RestApi.Service;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shippderService;

        public ShipperController(IShipperService shipperService)
        {
            _shippderService = shipperService;
        }

        // GET: api/Shipper
        [HttpGet]
        public async Task<IEnumerable<ShipperModel>> Get()
        {
            return await _shippderService.GetShipper();
        }

        // GET: api/Shipper/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IEnumerable<ShipperModel>> Get(int id)
        {
            return await _shippderService.GetShipperByID(id);
        }

        // POST: api/Shipper
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ShipperModel Model)
        {
            var result =  await _shippderService.InsertShipper(Model);

            if(result > 0)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT: api/Shipper/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ShipperModel Model)
        {
            Model.ShipperID = id;
            var result = await _shippderService.UpdateShipper(Model);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _shippderService.DeleteShipper(id);
            if (result > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
