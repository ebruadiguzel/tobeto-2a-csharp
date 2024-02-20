using Business.Abstract;
using Business.Requests.Users;
using Business.Responses.Users;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc;
using Core.Utilities.Security.JWT;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    public void Register([FromBody] RegisterRequest request)
    {
        _userService.Register(request);
    }
    [HttpPost]
    public AccessToken Login([FromBody] LoginRequest request)
    {
        return _userService.Login(request);
    }
    
    [HttpGet]
    public GetUserListResponse GetList([FromQuery] GetUserListRequest request)
    {
        GetUserListResponse response = _userService.GetList(request);
        return response; 
    }
    
    [HttpPost] // POST 
    public ActionResult<AddUserResponse> Add(AddUserRequest request)
    {
        AddUserResponse response = _userService.Add(request);
        
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id},
            value:response 
        ); 
    }
    
    [HttpPut("{Id}")] // PUT 
    public ActionResult<UpdateUserResponse> Update([FromRoute] int Id,[FromBody]UpdateUserRequest request)
    {
        if (Id != request.Id)
        {
            return BadRequest();
        }
        
        UpdateUserResponse response = _userService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public DeleteUserResponse Delete(DeleteUserRequest request)
    {
        DeleteUserResponse response = _userService.Delete(request);
        return response;
    }
    
    [HttpGet("{Id}")] // GET http://localhost:5245/api/userss/{Id}
    public GetUserByIdResponse GetById([FromRoute] GetUserByIdRequest request)
    {
        GetUserByIdResponse response = _userService.GetById(request);
        return response;
    }
}