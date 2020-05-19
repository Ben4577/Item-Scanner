using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemScanner.Models;
using ItemScanner.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ItemScanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanningController : ControllerBase
    {

        private readonly IScanService _scanService;
        string sessionKey = "sk";
        ScannedItems scannedList;

        public ScanningController(IScanService scanService)
        {
            _scanService = scanService;
        }

        [HttpGet("getItems")]
        public async Task<IActionResult> GetItems()
        {
            var items = await _scanService.GetItems();
            return Ok(items);
        }


        [HttpPost("scanItem")]
        public async Task<IActionResult> ScanItem([FromBody] Item item)
        {
         
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var savedScannedItems = HttpContext.Session.GetString(sessionKey);
            if(savedScannedItems != null)
            {
               scannedList = JsonConvert.DeserializeObject<ScannedItems>(savedScannedItems);
            }
            else
            {
                scannedList = new ScannedItems();
            }

            var scannedItems = await _scanService.ScanItem(item, scannedList);

            //Save scanned list to session state
            HttpContext.Session.SetString(sessionKey, JsonConvert.SerializeObject(scannedItems));

            return Ok(scannedItems);
        }


    }
}