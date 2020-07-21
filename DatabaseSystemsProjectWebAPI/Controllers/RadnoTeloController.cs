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

        #region BASIC_CRUD

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
        public IActionResult AddRadnoTelo([FromBody] RadnoTeloPost radnoTelo)
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
        public IActionResult UpdateRadnoTelo(int radnoTeloId, [FromBody] RadnoTeloView radnoTelo)
        {
            try
            {
                DataProvider.UpdateRadnoTelo(radnoTeloId, radnoTelo);
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
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

        #region SLUZBENE_PROSTORIJE

        [HttpGet]
        [Route("{radnoTeloId}/sluzbene-prostorije")]
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

        [HttpPost]
        [Route("{radnoTeloId}/dodeli-sluzbenu-prostoriju")]
        public IActionResult AddRadnoTeloSluzbenaProstorija(int radnoTeloId, [FromBody] int sluzbenaProstorijaId)
        {
            try
            {
                if (DataProvider.AddRadnoTeloSluzbenaProstorija(radnoTeloId, sluzbenaProstorijaId))
                    return Ok();
                else return BadRequest("Radnom telu je vec dodeljena sluzbena prostorija!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{radnoTeloId}/ukloni-sluzbenu-prostoriju")]
        public IActionResult DeleteRadnoTeloSluzbenaProstorija(int radnoTeloId)
        {
            try
            {
                if (DataProvider.DeleteRadnoTeloSluzbenaProstorija(radnoTeloId))
                    return Ok();
                else return BadRequest("Radno telo trenutno nema dodeljenu sluzbenu prostoriju!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

        #region NARODNI_POSLANICI

        [HttpGet]
        [Route("{radnoTeloId}/clanovi")]
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
        
        [HttpPut]
        [Route("{radnoTeloId}/azuriraj-predsednika")]
        public IActionResult UpdateRadnoTeloPredsednik(int radnoTeloId, [FromBody] int predsednikId)
        {
            try
            {
                return new JsonResult(DataProvider.UpdateRadnoTeloPredsednik(radnoTeloId, predsednikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{radnoTeloId}/azuriraj-zamenika")]
        public IActionResult UpdateRadnoTeloZamenik(int radnoTeloId, [FromBody] int zamenikId)
        {
            try
            {
                return new JsonResult(DataProvider.UpdateRadnoTeloZamenik(radnoTeloId, zamenikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    
        #endregion
    }
}
