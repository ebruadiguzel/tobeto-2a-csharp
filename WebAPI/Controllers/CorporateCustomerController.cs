using Business.Abstract;
using Business.Requests.CorporateCustomer;
using Business.Responses.CorporateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CorporateCustomerController : ControllerBase
{
    private readonly ICorporateCustomerService _corporateCustomerService;
    
    public CorporateCustomerController(ICorporateCustomerService corporateCustomerService)
    {
        _corporateCustomerService = corporateCustomerService;
    }
    
    [HttpGet]
    public GetCorporateCustomerListResponse GetList([FromQuery] GetCorporateCustomerListRequest request)
    {
        GetCorporateCustomerListResponse response = _corporateCustomerService.GetList(request);
        return response; 
    }
    
    [HttpPost] 
    public ActionResult<AddCorporateCustomerResponse> Add(AddCorporateCustomerRequest request)
    {
        AddCorporateCustomerResponse response = _corporateCustomerService.Add(request);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id},
            value:response 
        ); 
    }
    
    [HttpPut("{Id}")]
    public ActionResult<UpdateCorporateCustomerResponse> Update([FromRoute] int Id, [FromBody]UpdateCorporateCustomerRequest request)
    {
        if (Id != request.Id)
        {
            return BadRequest();
        }
        
        UpdateCorporateCustomerResponse response = _corporateCustomerService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public DeleteCorporateCustomerResponse Delete(DeleteCorporateCustomerRequest request)
    {
        DeleteCorporateCustomerResponse response = _corporateCustomerService.Delete(request);
        return response;
    }
    
    [HttpGet("{Id}")] // 
    public GetCorporateCustomerByIdResponse GetById([FromRoute] GetCorporateCustomerByIdRequest request)
    {
        GetCorporateCustomerByIdResponse response = _corporateCustomerService.GetById(request);
        return response;
    }
    
}