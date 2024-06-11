using Dapper;
using DapperTest.Models;
using DapperTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DapperTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteServices services;
        public NoteController(INoteServices service)
        {
            this.services = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var result = await services.GetAll();
            if(result == null)
            {
                return NotFound("something went wrong");
            }
            return Ok(result);
        }

        [HttpGet("GetBYID")]
        public async Task<IActionResult> GetByID(int Id)
        {
            var result = await services.GetbyID(Id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewNote(NoteDTO model)
        {
            var result = await services.AddNew(model);
            if(result)
            {
                return Ok("Added Successfully");
            }
            return BadRequest("Something went wrong");
        }

        [HttpPut]
        public async Task<IActionResult> EditNote(int id, NoteDTO model)
        {
            var result = await services.EditNote(id, model);
            if(result)
            {
                return Ok("Edited Successfully");
            }
            return BadRequest("Something Went Wrong. Please Check the Input ID");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var result = await services.DeleteNote(id);
            if(result)
            {
                return Ok("Delete success");
            }
            return BadRequest("Something went wrong. Please Check the Input ID");
        }
        
        

    }
}
