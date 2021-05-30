using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using WebApi.Controllers.v1;
using Xunit;
using Application.Features;
using Application.Features.AirCraftFeatures.Queries;
using WebApi.Controllers;

namespace WebApi_Test.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AirCraftControllerTest: BaseApiController
    {
         private readonly AirCraftController _controller;
         private IMediator _mediator;
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
           
            var result =  Mediator.Send(new GetAllAirCraftsQuery());
            Assert.IsType<ViewResult>(result);
        }       
    }
}

