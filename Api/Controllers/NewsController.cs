using Application.Auth;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.News;
using Application.News.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ApiControllerBase
    {
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var result = await Mediator.Send(new GetNewsQuery { Id = id });

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //[HttpGet]
        //public async Task<IActionResult> GetAllNewsWithPagination([FromQuery] GetAllNewsRequest request)
        //{
        //    var result = await Mediator.Send(new GetAllNewsWithPaginationQuery(request));

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(result);
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateNewsRequest request)
        //{
        //    if (request == null)
        //    {
        //        return BadRequest("Param is null.");
        //    }

        //    var result = await Mediator.Send(new CreateNewsCommand(request));

        //    return CreatedAtRoute(nameof(Get), new { result.Id }, result);
        //}        

        //[Authorize]
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody]UpdateNewsRequest request)
        //{
        //    if (request == null)
        //    {
        //        return BadRequest("Param is null.");
        //    }

        //    if (id != request.Id)
        //    {
        //        return BadRequest("Wrong params.");
        //    }

        //    await Mediator.Send(new UpdateNewsCommand(request));

        //    return NoContent();
        //}

        //[Authorize]
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await Mediator.Send(new DeleteNewsCommand { Id = id });

        //    return NoContent();
        //}       

    }
}
