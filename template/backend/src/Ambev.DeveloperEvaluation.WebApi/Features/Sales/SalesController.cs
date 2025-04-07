using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Exceptions;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSaleRequest request)
        {
            var command = _mapper.Map<CreateSaleCommand>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<CreateSaleResponse>(result);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSaleRequest request)
        {
            var command = _mapper.Map<UpdateSaleCommand>(request);
            var result = await _mediator.Send(command);
            var response = _mapper.Map<UpdateSaleResponse>(result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteSaleRequest request)
        {
            var command = _mapper.Map<DeleteSaleCommand>(request);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var result = await _mediator.Send(new GetSaleQuery { Id = id });
                return Ok(result);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
