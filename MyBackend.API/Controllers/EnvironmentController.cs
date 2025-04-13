using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBackend.WebApi.DTOs;
using MyBackend.WebApi.Repositories;

namespace MyBackend.WebApi.Controllers;
[ApiController]
[Route("Environment")]
public class EnvironmentController(IEnvironmentRepository environmentRepository) : ControllerBase
{
    //send environment to database
    [HttpPost]
    public async Task<ActionResult> Create(EnvironmentCreateDto environmentCreateDto)
    {
        try
        {
            await environmentRepository.Create(environmentCreateDto);
        }
        catch (SqlException)
        {
            #if DEBUG
                throw;
            #endif 
                return Problem();
        }
        return Created();
    }
    
    //get a list of environments or a specific environment from database
    [HttpGet]
    public async Task<ActionResult<EnvironmentReadDtoWrapper>> Read([FromQuery] string email)
    {
        var result = await environmentRepository.Read(email);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(new EnvironmentReadDtoWrapper { getEnvironmentResponseDtoList = result });
    }
    
    //delete a environment in database
    [HttpDelete]
    public async Task<ActionResult> Delete([FromQuery] string environmentId)
    {
        try
        {
            await environmentRepository.Delete(environmentId);
        }
        catch (SqlException)
        {
            #if DEBUG
                throw;
            #endif 
                return Problem();
        }
        return NoContent();
    }
    
}