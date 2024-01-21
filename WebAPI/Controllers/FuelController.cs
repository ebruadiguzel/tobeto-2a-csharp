using Business.Abstract;
using Business.Requests.Fuel;
using Business.Responses.Fuel;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class FuelController : ControllerBase
{
    private readonly IFuelService _fuelService;

    public FuelController(IFuelService fuelService)
    {
        _fuelService = fuelService;
    }
    
    [HttpGet]
    public ICollection<Fuel> GetList()
    {
        IList<Fuel> fuelList = _fuelService.GetList();
        return fuelList; 
    }
    
    [HttpPost] 
    public ActionResult<AddFuelResponse> Add(AddFuelRequest request)
    {
        AddFuelResponse response = _fuelService.Add(request);
        
        return CreatedAtAction(nameof(Add), response); 
    }
    
    [HttpPut]
    public ActionResult<UpdateFuelResponse> Update(UpdateFuelRequest request)
    {
        UpdateFuelResponse response = _fuelService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public ActionResult<bool> Delete(DeleteFuelRequest request)
    {
        bool response = _fuelService.Delete(request);
        return Ok(response);
    }
    
    [HttpGet]
    public ActionResult<Fuel> GetById(int id)
    {
        Fuel response = _fuelService.GetById(id);
        return Ok(response);
    }
}