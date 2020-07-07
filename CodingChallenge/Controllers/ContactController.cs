using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Net;
using CodingChallenge.Models;
using CodingChallenge.Commands.GetContact;
using Microsoft.Azure.Cosmos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using CodingChallenge.Commands.CreateContact;
using CodingChallenge.Commands.UpdateContact;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodingChallenge.Controllers
{
    [ApiController]
    [Route("/contacts/")]
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{contactId}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ContactDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get(Guid contactId)
        {
            try
            {
                var result = await _mediator.Send<ContactDto>(new GetContactQuery { Id = contactId });
                return Ok(result);
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return new InternalServerErrorObjectResult(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post(CreateContactRequest request)
        {
            try
            {
                var cmd = _mapper.Map<CreateContactCommand>(request);
                await _mediator.Send(cmd);
                return Ok();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return new InternalServerErrorObjectResult(ex);
            }
        }

        [HttpPut("{contactId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put(Guid contactId, UpdateContactRequest request)
        {
            try
            {
                var cmd = _mapper.Map<UpdateContactCommand>(request);
                await _mediator.Send(cmd);
                return Ok();
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            catch (ValidationException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return new InternalServerErrorObjectResult(ex);
            }
        }


        public class InternalServerErrorObjectResult : ObjectResult
        {
            public InternalServerErrorObjectResult(object error)
                : base(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
            }
        }
    }
}
