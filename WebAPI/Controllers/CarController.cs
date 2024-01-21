using Business.Abstract;
using Business.Requests.Car;
using Business.Responses.Car;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }
    
    [HttpGet]
    public ICollection<Car> GetList()
    {
        IList<Car> carList = _carService.GetList();
        return carList; 
    }
    
    [HttpPost] 
    public ActionResult<AddCarResponse> Add(AddCarRequest request)
    {
        AddCarResponse response = _carService.Add(request);
        
        return CreatedAtAction(nameof(Add), response); 
    }
    
    [HttpPut]
    public ActionResult<UpdateCarResponse> Update(UpdateCarRequest request)
    {
        UpdateCarResponse response = _carService.Update(request);
        return Ok(response);
    }

    [HttpDelete]
    public ActionResult<bool> Delete(DeleteCarRequest request)
    {
        bool response = _carService.Delete(request);
        return Ok(response);
    }
    
    [HttpGet]
    public ActionResult<Car> GetById(int id)
    {
        Car response = _carService.GetById(id);
        return Ok(response);
    }
}