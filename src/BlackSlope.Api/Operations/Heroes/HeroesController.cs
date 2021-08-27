using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackSlope.Api.Common.Controllers;
using BlackSlope.Api.Operations.Heroes.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlackSlope.Api.Operations.Heroes
{
    public class HeroesController : BaseController
    {

        /// <summary>
        /// Return a list of all heroes
        /// </summary>
        /// <remarks>
        /// Use this operation to return a list of all heroes
        /// </remarks>
        /// <response code="200">Returns a list of all heroes</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="500">Internal Server Error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        [Route("api/v1/heroes")]
        public async Task<ActionResult<List<HeroViewModel>>> GetHeroes()
        {
            return HandleSuccessResponse(GetAllHeroes());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("api/v1/heroes/{id}")]
        public async Task<ActionResult<HeroViewModel>> GetHero(int id)
        {
            var hero = GetAllHeroes().FirstOrDefault(x => x.Id == id);
            return HandleSuccessResponse(hero);
        }

        private List<HeroViewModel> GetAllHeroes()
        {
            return new List<HeroViewModel> {
                new HeroViewModel { Id = 1, Name = "Wondergirl" },
                new HeroViewModel { Id = 2, Name = "Super Penny"},
            };
        }
    }
}
