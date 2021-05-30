using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.AirCraftFeatures.Commands;
using Application.Features.AirCraftFeatures.Queries;
using Domain.Entities;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Models;
using WebApi.FluventValidators;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class AirCraftController : BaseApiController
    {
        private static ILogger<AirCraftController> _logger;

        public AirCraftController(ILogger<AirCraftController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates a New Aircraft.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateAirCraftCommand command)
        {
            //Implement fluvent validation
            AirCraftValidator validator = new AirCraftValidator();
            List<string> ValidationMessages = new List<string>();

            var aircraft = new AirCraft
            {
                Make = command.Make,
                Model = command.Model,
                Location = command.Location,
                Registration = command.Registration
            };
            var validationResult = validator.Validate(aircraft);
            var response = new ResponseModel();
            //*********************

            if (validationResult.IsValid == true)
            {               
                try
                {
                    return Ok(await Mediator.Send(command));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception Caught");                    
                    return NotFound(ex);
                }
            }
            else
            {
                response.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.ValidationMessages = ValidationMessages;
                //return Ok(response);
                return NotFound(ValidationMessages);
            }

        }

        /// <summary>
        /// Gets all Aircrafts.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Requested a Web API - GetAll Data");
            try
            {
                return Ok(await Mediator.Send(new GetAllAirCraftsQuery()));
                
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Exception Caught");
                return NotFound(ex);
            }

        }

        /// <summary>
        /// Gets Aircraft Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Requested a Web API - GetById Data");
            try
            {
                return Ok(await Mediator.Send(new GetAirCraftByIdQuery { Id = id }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Deletes Aircraft Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {            
            try
            {
                return Ok(await Mediator.Send(new DeleteAirCraftByIdCommand { Id = id }));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Caught");
                return NotFound(ex);
            }
        }

        /// <summary>
        /// Updates the Aircraft Entity based on Id.   
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateAirCraftCommand command)
        {
            //Implement fluvent validation
            AirCraftValidator validator = new AirCraftValidator();
            List<string> ValidationMessages = new List<string>();

            var aircraft = new AirCraft
            {
                Make = command.Make,
                Model = command.Model,
                Location = command.Location,
                Registration = command.Registration
            };
            var validationResult = validator.Validate(aircraft);
            var response = new ResponseModel();
            //****************************

            if (validationResult.IsValid == true)
            {               
                try
                {
                    if (id != command.Id)
                    {
                        return BadRequest();
                    }
                    return Ok(await Mediator.Send(command));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception Caught");
                    return NotFound(ex);
                    //throw;
                }
            }
            else
            {
                response.IsValid = false;
                foreach (ValidationFailure failure in validationResult.Errors)
                {
                    ValidationMessages.Add(failure.ErrorMessage);
                }
                response.ValidationMessages = ValidationMessages;
                return Ok(response);
            }
        }
    }
}
