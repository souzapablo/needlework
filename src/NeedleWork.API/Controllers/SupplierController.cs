using Microsoft.AspNetCore.Mvc;

namespace NeedleWork.API.Controllers;

[ApiController]
[Route("api/v1/suppliers")]
public class SupplierController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id:long}")]
    public IActionResult GetById(long id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPut("{id:long}")]
    public IActionResult Update(long id)
    {
        return Ok();
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id) 
    {
        return Ok();
    }
}
