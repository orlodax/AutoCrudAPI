using Microsoft.AspNetCore.Mvc;
using SampleLibrary;

namespace AutoCrudAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class GenericController<T> : Controller where T : BaseModel
{
    private readonly ILogger<T> logger;

    public GenericController(ILogger<T> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public ActionResult<List<T>> Get()
    {
        logger.Log(LogLevel.Information, "Get {typeName}", typeof(T).Name);

        return Ok(new List<T>());
    }

    [HttpPost]
    public ActionResult<T> Post([FromBody] T obj)
    {
        logger.Log(LogLevel.Information, "Post {typeName}", typeof(T).Name);

        return Ok(obj);
    }

    [HttpPut]
    public ActionResult Put([FromBody] T obj)
    {
        logger.Log(LogLevel.Information, "Put {typeName}", typeof(T).Name);

        return Ok();
    }

    [HttpDelete]
    public ActionResult Delete([FromBody] int id)
    {
        logger.Log(LogLevel.Information, "Delete {typeName}", typeof(T).Name);

        return Ok();
    }
}
