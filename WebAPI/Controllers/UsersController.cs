using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet]
    public GetUsersListResponse GetList([FromQuery] GetUsersListRequest request)
    {
        GetUsersListResponse response = _usersService.GetList(request);
        return response; 
    }
    
    [HttpPost] // POST 
    public ActionResult<AddUsersResponse> Add(AddUsersRequest request)
    {
        AddUsersResponse response = _usersService.Add(request);
        
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id},
            value:response 
        ); 
    }
    
    [HttpPut("{Id}")] // PUT 
    public ActionResult<UpdateUsersResponse> Update([FromRoute] int Id,[FromBody]UpdateUsersRequest request)
    {
        if (Id != request.Id)
        {
            return BadRequest();
        }
        
        UpdateUsersResponse response = _usersService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public DeleteUsersResponse Delete(DeleteUsersRequest request)
    {
        DeleteUsersResponse response = _usersService.Delete(request);
        return response;
    }
    
    [HttpGet("{Id}")] // GET http://localhost:5245/api/userss/{Id}
    public GetUsersByIdResponse GetById([FromRoute] GetUsersByIdRequest request)
    {
        GetUsersByIdResponse response = _usersService.GetById(request);
        return response;
    }
}