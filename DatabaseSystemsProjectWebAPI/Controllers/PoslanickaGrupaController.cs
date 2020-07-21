using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;


namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("/api/organizacione-jedinice/poslanicke-grupe")]
    public class PoslanickaGrupaController : ControllerBase
    {

        #region BASIC_CRUD

        [HttpGet]
        public IActionResult GetPoslanickeGrupe()
        {
            try
            {
                return new JsonResult(DataProvider.ReadPoslanickeGrupe());
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpGet]
        [Route("{poslanickaGrupaId}")]
        public IActionResult GetPoslanickaGrupa(int poslanickaGrupaId, [FromQuery] string sluzbeneProstorije)   // TODO add from query logic
        {
            try
            {
                return new JsonResult(DataProvider.ReadPoslanickaGrupa(poslanickaGrupaId)); // TODO vrati i Predsednika i Zamenika
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        public IActionResult AddPoslanickaGrupa(PoslanickaGrupaPost poslanickaGrupa)
        {
            try
            {
                DataProvider.CreatePoslanickaGrupa(poslanickaGrupa);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{poslanickaGrupaId}")]
        public IActionResult UpdatePoslanickaGrupa(int poslanickaGrupaId, [FromBody]PoslanickaGrupaView poslanickaGrupa)
        {
            try
            {
                DataProvider.UpdatePoslanickaGrupa(poslanickaGrupaId, poslanickaGrupa);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{poslanickaGrupaId}")]
        public IActionResult DeletePoslanickaGrupa(int poslanickaGrupaId)
        {
            try
            {
                DataProvider.DeletePoslanickaGrupa(poslanickaGrupaId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

        #region SLUZBENE_PROSTORIJE

        [HttpGet]
        [Route("{poslanickaGrupaId}/sluzbene-prostorije")]
        public IActionResult GetSluzbeneProstorije(int poslanickaGrupaId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadPoslanickaGrupaSluzbeneProstorije(poslanickaGrupaId));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        [Route("{poslanickaGrupaId}/dodeli-sluzbenu-prostoriju")]
        public IActionResult AddSluzbenaProstorija(int poslanickaGrupaId, [FromBody] int sluzbenaProstorijaId)
        {
            try
            {
                DataProvider.AddPoslanickaGrupaSluzbenaProstorija(poslanickaGrupaId, sluzbenaProstorijaId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{poslanickaGrupaId}/ukloni-sluzbenu-prostoriju")]
        public IActionResult DeleteRadnoTeloSluzbenaProstorija(int poslanickaGrupaId, [FromBody] int sluzbenaProstorijaId)
        {
            try
            {
                if (DataProvider.DeletePoslanickaGrupaSluzbenaProstorija(poslanickaGrupaId, sluzbenaProstorijaId))
                    return Ok();
                else return BadRequest("Poslanicka trenutno nema dodeljenu sluzbenu prostoriju!");
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

        #region NARODNI_POSLANICI

        [HttpGet]
        [Route("{poslanickaGrupaId}/clanovi")]
        public IActionResult GetClanovi(int poslanickaGrupaId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadPoslanickaGrupaClanovi(poslanickaGrupaId));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{poslanickaGrupaId}/azuriraj-predsednika")]
        public IActionResult UpdatePoslanickaGrupaPredsednik(int poslanickaGrupaId, [FromBody] int predsednikId)
        {
            try
            {
                return new JsonResult(DataProvider.UpdatePoslanickaGrupaPredsednik(poslanickaGrupaId, predsednikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPut]
        [Route("{poslanickaGrupaId}/azuriraj-zamenika")]
        public IActionResult UpdatePoslanickaGrupaZamenik(int poslanickaGrupaId, [FromBody] int zamenikId)
        {
            try
            {
                return new JsonResult(DataProvider.UpdatePoslanickaGrupaZamenik(poslanickaGrupaId, zamenikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
    
        #endregion
    }
}
