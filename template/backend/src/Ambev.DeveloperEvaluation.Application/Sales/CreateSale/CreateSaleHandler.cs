using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    // : IRequestHandler<CreateUserCommand, CreateUserResult>
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<CreateSaleHandler> _logger;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository repository, IMapper mapper, ILogger<CreateSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var sale = _mapper.Map<Sale>(command);

            foreach (var item in command.Items)
            {
                sale.AddItem(item.ProductId, item.ProductDescription, item.Qtd, item.Price);
            }

            await _repository.CreateAsync(sale);

            _logger.LogInformation("[EVENT] SaleCreated: {SaleId}", sale.Id);

            return new CreateSaleResult() { Id = sale.Id };
        }
    }
}
