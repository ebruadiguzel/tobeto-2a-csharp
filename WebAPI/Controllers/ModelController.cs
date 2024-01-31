using Business.Abstract;
using Business.Requests.Model;
using Business.Responses.Model;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class ModelController : ControllerBase
{
    private readonly IModelService _modelService;

    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }
    
    [HttpGet]
    public GetModelListResponse GetList([FromQuery] GetModelListRequest request)
    {
        GetModelListResponse response = _modelService.GetList(request);
        return response; 
    }
    
    [HttpPost] // POST http://localhost:5245/api/models
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        AddModelResponse response = _modelService.Add(request);
        
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { Id = response.Id}, // Anonymous object // REsponse Header: Location = http://localhost:5245/api/models/1
            value:response // REsponse body
            ); 
    }
    
    [HttpPut("{Id}")] // PUT http://localhost:5245/api/models/1
    public ActionResult<UpdateModelResponse> Update([FromRoute] int Id,[FromBody]UpdateModelRequest request)
    {
        if (Id != request.Id)
        {
            return BadRequest();
        }
        
        UpdateModelResponse response = _modelService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public DeleteModelResponse Delete(DeleteModelRequest request)
    {
        DeleteModelResponse response = _modelService.Delete(request);
        return response;
    }
    
    [HttpGet("{Id}")] // GET http://localhost:5245/api/models/{Id}
    public GetModelByIdResponse GetById([FromRoute] GetModelByIdRequest request)
    {
        GetModelByIdResponse response = _modelService.GetById(request);
        return response;
    }
    
        
    [HttpGet]
    public ICollection<Model> GetListByFuelName(string fuelName)
    {
        IList<Model> modelList = _modelService.GetListByFuelName(fuelName);
        return modelList; 
    }
    
            
    [HttpGet]
    public ICollection<Model> GetListByTransmissionName(string transmissionName)
    {
        IList<Model> modelList = _modelService.GetListByTransmissionName(transmissionName);
        return modelList; 
    }
    
            
    [HttpGet]
    public ICollection<Model> GetListByBrandName(string brandName)
    {
        IList<Model> modelList = _modelService.GetListByBrandName(brandName);
        return modelList; 
    }

}