using FluentValidation;
using dotnetwebapi8.Model;
using dotnetwebapi8.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dotnetwebapi8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurHeroController : ControllerBase
    {
        private readonly IOurHeroService _heroService;

        public OurHeroController(IOurHeroService heroService)
        {
            _heroService = heroService;
        }

        private readonly IValidator<OurHero> _validator;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] bool? isActive = null)
        {
            //return Ok(_heroService.GetAllHeros(isActive));
            var heros = await _heroService.GetAllHeros(isActive);
            return Ok(heros);
        }

        //[HttpGet]
        //[Route("{id}")]
        [HttpGet("{id}")]
        //[Route("{id}")] // /api/OurHero/:id
        public async Task<IActionResult> Get(int id)
        {
            //var hero = _heroService.GetHerosByID(id);
            var hero = await _heroService.GetHerosByID(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddUpdateOurHero heroObject)
        {
            //var hero = _heroService.AddOurHero(heroObject);
            var hero = await _heroService.AddOurHero(heroObject);
            if (hero == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Super Hero Created Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AddUpdateOurHero heroObject)
        {
            //var hero = _heroService.UpdateOurHero(id, heroObject);
            var hero = await _heroService.UpdateOurHero(id, heroObject);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Updated Successfully!!!",
                id = hero!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //if (!_heroService.DeleteHerosByID(id))
            if (!await _heroService.DeleteHerosByID(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Super Hero Deleted Successfully!!!",
                id = id
            });
        }
    }
}
