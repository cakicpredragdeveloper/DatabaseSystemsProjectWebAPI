using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;


namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("/api/organizacione-jedinice/radna-tela")]
    public class RadnoTeloController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetRadnaTela()
        {
            try
            {
                return new JsonResult(DataProvider.ReadRadnaTela());
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("{radnoTeloId}")]
        public IActionResult GetRadnoTelo(int radnoTeloId, [FromQuery] string sluzbeneProstorije)   // TODO add from query logic
        {
            try
            {
                return new JsonResult(DataProvider.ReadRadnoTelo(radnoTeloId)); // TODO vrati i Predsednika i Zamenika
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddRadnoTelo([FromBody] RadnoTeloView radnoTelo)
        {
            try
            {
                DataProvider.CreateRadnoTelo(radnoTelo);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{radnoTeloId}")]
        public IActionResult UpdateRadnoTelo([FromBody] RadnoTeloView radnoTelo)
        {
            try
            {
                DataProvider.UpdateRadnoTelo(radnoTelo);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{radnoTeloId}")]
        public IActionResult DeleteRadnoTelo(int radnoTeloId)
        {
            try
            {
                DataProvider.DeleteRadnoTelo(radnoTeloId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        /*
        [HttpGet]
        [Route("{radnoTeloId/clanovi}")]
        public IActionResult GetClanovi(int radnoTeloId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadRadnoTeloClanovi(radnoTeloId));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("{radnoTeloId/sluzbene-prostorije}")]
        public IActionResult GetSluzbeneProstorije(int radnoTeloId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadRadnoTeloSluzbeneProstorije(radnoTeloId));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
        */
        
    }
}
