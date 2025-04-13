using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MyBackend.WebApi.DTOs;
using MyBackend.WebApi.Repositories;

namespace MyBackend.WebApi.Controllers;
[ApiController]
[Route("Object")]
public class ObjectController(IObjectRepository objectRepository) : ControllerBase
{
    //send objects to database
    [HttpPost]
    public async Task<ActionResult> Create(ObjectCreateDtoWrapper objectCreateDtoWrapper)
    {
        try
        {
            await objectRepository.Create(objectCreateDtoWrapper.postObjectRequestDtoList);
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

    //get objects from database
    [HttpGet]
    public async Task<ActionResult<ObjectReadDtoWrapper>> Read([FromQuery] string environmentId)
    {
        var result = await objectRepository.Read(environmentId);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(new ObjectReadDtoWrapper { getObjectResponseDtoList = result});
    }
    
    //update objects in database
    [HttpPut]
    public async Task<ActionResult> Update(ObjectUpdateDtoWrapper objectUpdateDtoWrapper)
    {
        try
        {
            await objectRepository.Update(objectUpdateDtoWrapper.putObjectRequestDtoList);
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

    [HttpDelete]
    public async Task<ActionResult> Delete(ObjectIdListWrapper objectIdListWrapper)
    {
        try
        {
            await objectRepository.Delete(objectIdListWrapper.objectIdList);
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
}