using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateSaleHandlerTest
    {
        private readonly ISaleRepository _repository = Substitute.For<ISaleRepository>();
        private readonly IMapper _mapper = Substitute.For<IMapper>();
        private readonly ILogger<CreateSaleHandler> _logger = Substitute.For<ILogger<CreateSaleHandler>>();

        [Fact]
        public async Task Handle_Should_Create_Sale_And_Return_Id()
        {
            // Arrange
            var request = new CreateSaleCommand
            {
                SaleNumber = "123456",
                SaleDate = DateTime.UtcNow,
                Customer = "Customer",
                Branch = "Branch",
                Items = new List<CreateSaleItemDto>
            {
                new()
                {
                    ProductId = Guid.NewGuid(),
                    ProductDescription = "ProductDescription",
                    Qtd = 10,
                    Price = 15.00m
                }
            }
            };

            var sale = new Sale(request.SaleNumber, request.SaleDate, request.Customer, request.Branch);

            _mapper.Map<Sale>(request).Returns(sale);

            var handler = new CreateSaleHandler(_repository, _mapper, _logger);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            await _repository.Received(1).CreateAsync(Arg.Is<Sale>(s => s.SaleNumber == request.SaleNumber));
            Assert.Equal(sale.Id, result.Id);
        }
    }
}
