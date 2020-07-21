using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatabaseAccess.DTOs;
using DatabaseAccess;
using Microsoft.AspNetCore.Http;

namespace DatabaseSystemsProjectWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SluzbenaProstorijaController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSluzbeneProstorije()
        {
            try
            {
                return new JsonResult(DataProvider.ReadSluzbeneProstorije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddSluzbenaProstorija(SluzbenaProstorijaView sluzbenaProstorijaView)
        {
            try
            {
                DataProvider.CreateSluzbenaProstorija(sluzbenaProstorijaView);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSluzbenaProstorija(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.ReadSluzbenaProstorija(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{Id}/organizacioneJedinice")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetOrganizacioneJedinice(int Id)
        {
            try
            {
                return new JsonResult(DataProvider.ReadOrgaznizacioneJedinice(Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSluzbenaProstorija(SluzbenaProstorijaView sluzbenaProstorijaView)
        {
            try
            {
                DataProvider.UpdateSluzbenaProstorija(sluzbenaProstorijaView);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateSluzbenaProstorija(int Id)
        {
            try
            {
                DataProvider.DeleteSluzbenaProstorija(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
