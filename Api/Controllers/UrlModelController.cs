using Application.Auth;
using Application.Common.Dtos;
using Application.Common.Models;
using Application.News;
using Application.News.Queries;
using Application.UrlModels;
using Application.UrlModels.Queries;
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
    [Route("api/Url")]
    [ApiController]
    public class UrlModelController : ApiControllerBase
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUrlModelRequest request)
        {
            if (request == null)
            {
                return BadRequest("Param is null.");
            }

            var result = await Mediator.Send(new CreateUrlModelCommand(request));

            return CreatedAtRoute(nameof(Get), new { result.Id }, result);
        }

        [Authorize]
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await Mediator.Send(new GetUrlModelQuery { Id = id });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUrlModelCommand { Id = id });

            return NoContent();
        }

        //[HttpGet("{url}", Name = "Redirect")]       
        //public async Task<IActionResult> GetRedirect(string url)
        //{
        //    //var result = await Mediator.Send(url);

        //    //if (result == null)
        //    //{
        //    //    return NotFound();
        //    //}



        //    return RedirectToRoute("https://github.com/jasontaylordev/CleanArchitecture");
        //}

    }
}
