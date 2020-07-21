using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;

namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("/api/stalno-zaposleni")]
    public class StalnoZaposlenController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetStalnoZaposleni()
        {
            try
            {
                return new JsonResult(DataProvider.ReadStalnoZaposleni());
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("{stalnoZaposlenId}")]
        public IActionResult GetStalnoZaposlen(int stalnoZaposlenId, [FromQuery] string telefoni)
        {
            try
            {
                if(telefoni == "true")
                {
                    return new JsonResult(DataProvider.ReadStalnoZaposlen(stalnoZaposlenId, true));
                }
                else
                {
                    return new JsonResult(DataProvider.ReadStalnoZaposlen(stalnoZaposlenId, false));
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddStalnoZaposlen([FromBody]StalnoZaposlenView stalnoZaposlen)
        {
            try
            {
                DataProvider.CreateStalnoZaposlen(stalnoZaposlen);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{stalnoZaposlenId}")]
        public IActionResult UpdateStalnoZaposlen(int stalnoZaposlenId, [FromBody]StalnoZaposlenView stalnoZaposlenView)
        {
            try
            {
                DataProvider.UpdateStalnoZaposlen(stalnoZaposlenId, stalnoZaposlenView);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{stalnoZaposlenId}")]
        public IActionResult DeleteStalnoZaposlen(int stalnoZaposlenId)
        {
            try
            {
                DataProvider.DeleteNarodniPoslanik(stalnoZaposlenId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
        
    }
}
