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
    public ICollection<Model> GetList()
    {
        IList<Model> modelList = _modelService.GetList();
        return modelList; 
    }
    
    [HttpPost] 
    public ActionResult<AddModelResponse> Add(AddModelRequest request)
    {
        AddModelResponse response = _modelService.Add(request);
        
        return CreatedAtAction(nameof(Add), response); 
    }
    
    [HttpPut]
    public ActionResult<UpdateModelResponse> Update(UpdateModelRequest request)
    {
        UpdateModelResponse response = _modelService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public ActionResult<bool> Delete(DeleteModelRequest request)
    {
        bool response = _modelService.Delete(request);
        return Ok(response);
    }
    
    [HttpGet]
    public ActionResult<Model> GetById(int id)
    {
        Model response = _modelService.GetById(id);
        return Ok(response);
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