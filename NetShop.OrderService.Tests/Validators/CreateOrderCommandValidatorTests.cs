using FluentValidation.TestHelper;
using NetShop.OrderService.Application.Commands;
using NetShop.OrderService.Application.Dtos;
using NetShop.OrderService.Application.Validators;

namespace NetShop.OrderService.Tests.Validators
{
    public class CreateOrderCommandValidatorTests
    {
        private readonly CreateOrderCommandValidator _validator;

        public CreateOrderCommandValidatorTests()
        {
            _validator = new CreateOrderCommandValidator();
        }

        [Fact]
        public void Should_Have_Error_When_CustomerId_Is_Empty()
        {
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.Empty,
                OrderItems = new List<OrderItemDto>
                {
                    new OrderItemDto
                    {
                        ProductId = Guid.NewGuid(),
                        Quantity = 1
                    }
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.CustomerId);
        }

        [Fact]
        public void Should_Have_Error_When_OrderItems_Is_Empty()
        {
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                OrderItems = new List<OrderItemDto>()
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor(c => c.OrderItems);
        }

        [Fact]
        public void Should_Have_Error_When_OrderItem_Has_Invalid_Quantity()
        {
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                OrderItems = new List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 0 }
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldHaveValidationErrorFor("OrderItems[0].Quantity");
        }

        [Fact]
        public void Should_Not_Have_Error_When_Command_Is_Valid()
        {
            var command = new CreateOrderCommand
            {
                CustomerId = Guid.NewGuid(),
                OrderItems = new List<OrderItemDto>
                {
                    new OrderItemDto { ProductId = Guid.NewGuid(), Quantity = 2 }
                }
            };

            var result = _validator.TestValidate(command);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
