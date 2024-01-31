using Business.Abstract;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;
    
    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    
    [HttpGet]
    public GetCustomersListResponse GetList([FromQuery] GetCustomersListRequest request)
    {
        GetCustomersListResponse response = _customerService.GetList(request);
        return response; 
    }
    
    [HttpPost] // POST 
    public ActionResult<AddCustomersResponse> Add(AddCustomersRequest request)
    {
        AddCustomersResponse response = _customerService.Add(request);
        
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id},
            value:response 
        ); 
    }
    
    [HttpPut("{Id}")] // PUT 
    public ActionResult<UpdateCustomersResponse> Update([FromRoute] int Id,[FromBody]UpdateCustomersRequest request)
    {
        if (Id != request.Id)
        {
            return BadRequest();
        }
        
        UpdateCustomersResponse response = _customerService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public DeleteCustomersResponse Delete(DeleteCustomersRequest request)
    {
        DeleteCustomersResponse response = _customerService.Delete(request);
        return response;
    }
    
    [HttpGet("{Id}")] // 
    public GetCustomersByIdResponse GetById([FromRoute] GetCustomersByIdRequest request)
    {
        GetCustomersByIdResponse response = _customerService.GetById(request);
        return response;
    }
}