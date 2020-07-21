using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [Route("Sednica/{sednicaId}/[controller]")]
    [ApiController]
    public class RadniDanController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRadniDani(int sednicaId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadRadniDani(sednicaId));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetRadniDan(int sednicaId, int Id)
        {
            try
            {
                return new JsonResult(DataProvider.ReadRadniDan(sednicaId, Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult CreateRadniDan(int sednicaId, RadniDanView radniDanView)
        {
            try
            {
                if (radniDanView.DatumIVremePocetka.Date != radniDanView.DatumIVremeZavrsetka.Date)
                    return BadRequest("Uneti su nevalidni podaci za datum radnog dana!");
                if (DataProvider.CreateRadniDan(sednicaId, radniDanView))
                    return Ok();
                else return BadRequest("Dodati su svi potrebni radni dani za sednicu!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult UpdateRadniDan(int sednicaId, RadniDanView radniDanView)
        { 
            try
            {
                if (radniDanView.DatumIVremePocetka.Date != radniDanView.DatumIVremeZavrsetka.Date)
                    return BadRequest("Uneti su nevalidni podaci za datum radnog dana!");

                DataProvider.UpdateRadniDan(sednicaId, radniDanView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteRadniDan(int sednicaId, int Id)
        {
            try
            {

                DataProvider.DeleteRadniDan(sednicaId, Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
