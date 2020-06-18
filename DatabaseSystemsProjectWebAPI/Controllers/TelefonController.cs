using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;


namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("/api")]
    public class TelefonController : ControllerBase
    {

        [HttpGet]
        [Route("narodni-poslanici/{narodniPoslanikId}/telefoni")]
        public IActionResult GetTelefoni(int narodniPoslanikId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadTelefoni(narodniPoslanikId));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("telefoni/{telefonId}")]
        public IActionResult GetTelefon(int telefonId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadTelefon(telefonId));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        [Route("narodni-poslanici/{narodniPoslanikId}/telefoni")]
        public IActionResult AddTelefon(int narodniPoslanikId, [FromBody] TelefonView telefon)
        {
            try
            {
                DataProvider.CreateTelefon(narodniPoslanikId, telefon);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("telefoni/{telefonId}")]
        public IActionResult UpdateTelefon(int telefonId, [FromBody]TelefonView telefon)
        {
            try
            {
                DataProvider.UpdateTelefon(telefonId, telefon);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("telefoni/{telefonId}")]
        public IActionResult DeleteTelefon(int telefonId)
        {
            try
            {
                DataProvider.DeleteTelefon(telefonId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    }
}
