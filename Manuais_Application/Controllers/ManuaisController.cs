using Manuais_Data.Repositories.Interfaces;
using Manuais_Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Manuais_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManuaisController : ControllerBase
    {
        private readonly IManuaisRepository _manuaisRepository;
        public ManuaisController(IManuaisRepository manuaisRepository)
        {
            _manuaisRepository = manuaisRepository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var values = await _manuaisRepository.GetAll();
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet("getAllbyId/{id}")]
        public async Task<IActionResult> GetAllbyId(int id)
        {
            try
            {
                var values = await _manuaisRepository.GetAllById(id);
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] Manuais obj)
        {
            try
            {
                var values = await _manuaisRepository.InsertOrUpdate(obj);
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var values = await _manuaisRepository.Delete(id);
                return Ok(values);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
