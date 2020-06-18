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
        public IActionResult AddPoslanickaGrupa([FromBody]PoslanickaGrupaView poslanickaGrupa)
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

        /*
        [HttpGet]
        [Route("{poslanickaGrupaId/sluzbene-prostorije}")]
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
        */
        
    }
}
