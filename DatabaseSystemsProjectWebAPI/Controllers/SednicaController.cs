using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess.DTOs;

namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SednicaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSednice()
        {
            try
            {
                return new JsonResult(DataProvider.ReadSednice());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("redovnaSednica")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRedovneSednice()
        {
            try
            {
                return new JsonResult(DataProvider.ReadRedovneSednice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("redovnaSednica/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetRedovnaSednica(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.ReadRedovnaSednica(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("redovnaSednica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddRedovnaSednica(RedovnaSednicaView redovnaSednica)
        {
            try
            {
                DataProvider.CreateRedovnaSednica(redovnaSednica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString()); 
            }
        }

        [HttpPut("redovnaSednica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateRedovnaSednica(RedovnaSednicaView redovnaSednica)
        {
            try
            {
                DataProvider.UpdateRedovnaSednica(redovnaSednica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("redovnaSednica/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteRedovnaSednica(int Id)
        {
            try
            {
                DataProvider.DeleteRedovnaSednica(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("vanrednaSednica")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVanredneSednice()
        {
            try
            {
                return new JsonResult(DataProvider.ReadVanredneSednice());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("vanrednaSednica/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVanrednaSednica(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.ReadVanrednaSednica(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("vanrednaSednica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddVanrednaSednica(VanrednaSednicaView vanrednaSednica)
        {
            try
            {
                DataProvider.CreateVanrednaSednica(vanrednaSednica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("vanrednaSednica")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVanrednaSednica(VanrednaSednicaView vanrednaSednica)
        {
            try
            {
                DataProvider.UpdateVanrednaSednica(vanrednaSednica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("vanrednaSednica/{Id}/sazivaoci")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetVanrednaSednicaSazivaoci(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.ReadSazivaoci(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("vanrednaSednica/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVanrednaSednica(int Id)
        {
            try
            {
                DataProvider.DeleteVanrednaSednica(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
