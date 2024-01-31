using Business.Abstract;
using Business.Requests.IndividualCustomer;
using Business.Responses.IndividualCustomer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class IndividualCustomerController : ControllerBase
{
    private readonly IIndividualCustomerService _individualCustomerService;
    
    public IndividualCustomerController(IIndividualCustomerService individualCustomerService)
    {
        _individualCustomerService = individualCustomerService;
    }
    
    [HttpGet]
    public GetIndividualCustomerListResponse GetList([FromQuery] GetIndividualCustomerListRequest request)
    {
        GetIndividualCustomerListResponse response = _individualCustomerService.GetList(request);
        return response; 
    }
    
    [HttpPost] // POST 
    public ActionResult<AddIndividualCustomerResponse> Add(AddIndividualCustomerRequest request)
    {
        AddIndividualCustomerResponse response = _individualCustomerService.Add(request);
        
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id},
            value:response 
        ); 
    }
    
    [HttpPut("{Id}")] // PUT 
    public ActionResult<UpdateIndividualCustomerResponse> Update([FromRoute] int Id,[FromBody]UpdateIndividualCustomerRequest request)
    {
        if (Id != request.Id)
        {
            return BadRequest();
        }
        
        UpdateIndividualCustomerResponse response = _individualCustomerService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public DeleteIndividualCustomerResponse Delete(DeleteIndividualCustomerRequest request)
    {
        DeleteIndividualCustomerResponse response = _individualCustomerService.Delete(request);
        return response;
    }
    
    [HttpGet("{Id}")] // 
    public GetIndividualCustomerByIdResponse GetById([FromRoute] GetIndividualCustomerByIdRequest request)
    {
        GetIndividualCustomerByIdResponse response = _individualCustomerService.GetById(request);
        return response;
    }
}