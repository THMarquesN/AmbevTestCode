using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
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
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;

        public SalesController(IMediator mediator, ISaleRepository repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<SaleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSale([FromBody] SaleRequest request, CancellationToken cancellationToken)
        {
            var validator = new SaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<SaleResponse>
            {
                Success = true,
                Message = "Sale created successfully",
                Data = _mapper.Map<SaleResponse>(response)
            });
        }

        [HttpGet("GetById/{id:guid}")]
        [ProducesResponseType(typeof(ApiResponseWithData<SaleResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var sale = await _repository.GetByIdAsync(id);
            if (sale is null)
                return NotFound();

            return Ok(new ApiResponseWithData<SaleResponse>
            {
                Success = true,
                Message = "Sale retrieved successfully",
                Data = _mapper.Map<SaleResponse>(sale)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sales = await _repository.GetAllAsync();
            return Ok(sales);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _repository.DeleteAsync(id);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "User deleted successfully"
            });
        }

        [HttpGet("GetByCustomer/{customer}")]
        public async Task<IActionResult> GetAllByCustomer(string customer)
        {
            var sales = await _repository.GetAllByCustomerAsync(customer);
            return Ok(sales);
        }
    }
}
