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
       
        #region BASIC_CRUD
        
        [HttpGet]
        public IActionResult GetNarodniPoslanici()
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
                if(telefoni == "true")
                {
                    return new JsonResult(DataProvider.ReadNarodniPoslanik(narodniPoslanikId, true));
                }
                else
                {
                    return new JsonResult(DataProvider.ReadNarodniPoslanik(narodniPoslanikId, false));
                }
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
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion
        
        #region JE_CLAN
        
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

        [HttpPost]
        [Route("{narodniPoslanikId}/postani-clan/{organizacionaJedinicaId}")]
        public IActionResult AddPostaniClan(int narodniPoslanikId, int organizacionaJedinicaId)
        {
            try
            {
                DataProvider.CreateNarodniPoslanikPostaniClan(narodniPoslanikId, organizacionaJedinicaId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{narodniPoslanikId}/ukloni-clanstvo/{organizacionaJedinicaId}")]
        public IActionResult DeleteClanstvo(int narodniPoslanikId, int organizacionaJedinicaId)
        {
            try
            {
                DataProvider.DeleteNarodniPoslanikClanstvo(narodniPoslanikId, organizacionaJedinicaId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

        #region JE_PREDLOZIO

        [HttpGet]
        [Route("{narodniPoslanikId}/predlozeni-akti")]
        public IActionResult GetPredlozeniAkti(int narodniPoslanikId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadNarodniPoslanikPredlozeniAkti(narodniPoslanikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpPost]
        [Route("{narodniPoslanikId}/predlozi-akt/{aktId}")]
        public IActionResult AddPredloziAkt(int narodniPoslanikId, int aktId)
        {
            try
            {
                DataProvider.CreateNarodniPoslanikPredloziAkt(narodniPoslanikId, aktId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{narodniPoslanikId}/ukloni-predlog-akta/{aktId}")]
        public IActionResult DeletePredlogAkta(int narodniPoslanikId, int aktId)
        {
            try
            {
                DataProvider.DeleteNarodniPoslanikPredlogAkta(narodniPoslanikId, aktId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

        #region JE_SAZVAO
        
        [HttpGet]
        [Route("{narodniPoslanikId}/sazvane-sednice")]
        public IActionResult GetSazvaneSednice(int narodniPoslanikId)
        {
            try
            {
                return new JsonResult(DataProvider.ReadNarodniPoslanikSazvaneSednice(narodniPoslanikId));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }
        
        [HttpPost]
        [Route("{narodniPoslanikId}/sazovi-sednicu/{sednicaId}")]
        public IActionResult AddSazoviSednicu(int narodniPoslanikId, int sednicaId)
        {
            try
            {
                DataProvider.CreateNarodniPoslanikSazoviSednicu(narodniPoslanikId, sednicaId);
                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        [HttpDelete]
        [Route("{narodniPoslanikId}/ukloni-sazivanje-sednice/{sednicaId}")]
        public IActionResult DeleteSazivanjeSednice(int narodniPoslanikId, int sednicaId)
        {
            try
            {
                DataProvider.DeleteNarodniPoslanikSazivanjeSednice(narodniPoslanikId, sednicaId);
                return NoContent();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        #endregion

    }
}
