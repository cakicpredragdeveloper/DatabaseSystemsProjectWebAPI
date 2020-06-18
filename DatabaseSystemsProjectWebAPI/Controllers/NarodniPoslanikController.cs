using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess.DTOs;
using DatabaseAccess;


namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("/api/narodni-poslanici")]
    public class NarodniPoslanikController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult GetNarodniPoslanici()  // TODO probaj asinhrono
        {
            try
            {
                return new JsonResult(DataProvider.ReadNarodniPoslanici());
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("{narodniPoslanikId}")]
        public IActionResult GetNarodniPoslanik(int narodniPoslanikId, [FromQuery] string telefoni)
        {
            try
            {
                return new JsonResult(DataProvider.ReadNarodniPoslanik(narodniPoslanikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddNarodniPoslanik([FromBody]NarodniPoslanikView narodniPoslanik)
        {
            try
            {
                DataProvider.CreateNarodniPoslanik(narodniPoslanik);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{narodniPoslanikId}")]
        public IActionResult UpdateNarodniPoslanik(int narodniPoslanikId, [FromBody]NarodniPoslanikView narodniPoslanik)
        {
            try
            {
                DataProvider.UpdateNarodniPoslanik(narodniPoslanikId, narodniPoslanik);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{narodniPoslanikId}")]
        public IActionResult DeleteNarodniPoslanik(int narodniPoslanikId)
        {
            try
            {
                DataProvider.DeleteNarodniPoslanik(narodniPoslanikId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        
        [HttpGet]
        [Route("{narodniPoslanikId}/clanstva")]
        public IActionResult GetClanstva(int narodniPoslanikId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadNarodniPoslanikClanstva(narodniPoslanikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        // [HttpGet]
        // [Route("{narodniPoslanikId}/predlozeni-akti")]
        // public IActionResult GetPredlozeniAkti(int narodniPoslanikId)
        // {
        //     try
        //     {
        //         return new JsonResult(DataProvider.ReadNarodniPoslanikPredlozeniAkti(narodniPoslanik));
        //     }
        //     catch (Exception exception)
        //     {
        //         return BadRequest(exception.ToString());
        //     }
        // }
    }
}
