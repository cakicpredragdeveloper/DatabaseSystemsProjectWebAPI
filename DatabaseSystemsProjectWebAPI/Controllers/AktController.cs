using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess;
using DatabaseAccess.DTOs;

namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AktController : ControllerBase
    {
        [HttpGet("aktNarodnihPoslanika/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktNarodnihPoslanika(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiAktNarodnihPoslanika(Id));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("aktNarodnihPoslanika/{Id}/predlagaci")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktNarodnihPoslanikaPredlagaci(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPredlagace(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("aktNarodnihPoslanika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostAktNarodnihPoslanika(AktNarodnihPoslanikaView akt) //podrazumeva se da je [FromBody] :)
        {
            try
            {
                DataProvider.DodajAktNarodnihPoslanika(akt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        
        [HttpPut("aktNarodnihPoslanika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutAktNarodnihPoslanika(AktNarodnihPoslanikaView akt)
        {
            try
            {
                DataProvider.AzurirajAktNarodnihPoslanika(akt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("aktNarodnihPoslanika/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAktNarodnihPoslanika(int Id)
        {
            try
            {
                DataProvider.ObrisiAktNarodnihPoslanika(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("aktViseOd1500Biraca/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktViseOd1500Biraca(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiAktViseOd1500Biraca(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("aktViseOd1500Biraca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostAktViseOD1500Biraca(AktViseOd1500BiracaView akt)
        {
            try
            {
                DataProvider.DodajAktViseOd1500Biraca(akt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("aktViseOd1500Biraca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutAktViseOd1500Biraca(AktViseOd1500BiracaView akt)
        {
            try
            {
                DataProvider.AzurirajAktViseOd1500Biraca(akt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("aktViseOd1500Biraca/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAktViseOd1500Biraca(int Id)
        {
            try
            {
                DataProvider.ObrisiAktViseOd1500Biraca(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("aktVlade/{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAktVlade(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.VratiAktVlade(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost("aktVlade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostAktVlade(AktVladeView akt)
        {
            try
            {
                DataProvider.DodajAktVlade(akt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut("aktVlade")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PutAktVlade(AktVladeView akt)
        {
            try
            {
                DataProvider.AzurirajAktVlade(akt);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("aktVlade/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAktVlade(int Id)
        {
            try
            {
                DataProvider.ObrisiAktVlade(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}