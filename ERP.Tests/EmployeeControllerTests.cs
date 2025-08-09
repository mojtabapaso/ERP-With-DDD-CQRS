using ERP.Application.DTOs.EmployeeDTOs;
using ERP.Application.Features.Commands.Employee.CreateEmployee;
using ERP.Domain.Enums;
using ERP.Presentation.Controllers;
using ERP.Shared.Common.ResultPattern;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ERP.Tests.Controllers;

public class EmployeeControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly EmployeeController _controller;

    public EmployeeControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new EmployeeController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Index_Should_Return_Ok_When_Creation_Is_Successful()
    {
        // Arrange
        var inputDto = new CreateEmployeeDto
        {
            FirstName = "Mojtaba",
            LastName = "Ataei",
            NationalCode = "123",
            BirthDate = new DateTime(2300, 1, 1),
            EmployeePosition = EmployeePosition.Developer,
            CompanyId = 1,
            DegreeLevel = DegreeLevel.Bachelor
        };

        var expectedResponse = Result<string>.Success("Created");

        _mediatorMock
            .Setup(x => x.Send(It.IsAny<CreateEmployeeRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _controller.Create(inputDto);

        // Assert
        var okResult = result as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult!.StatusCode.Should().Be(200);
        okResult.Value.Should().BeEquivalentTo(expectedResponse);

        _mediatorMock.Verify(x =>
            x.Send(It.Is<CreateEmployeeRequest>(req => req.CreateEmployeeDto == inputDto),
                   It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact]
    public async Task CreateEmployee_Should_Return_BadRequest_When_NationalCode_Is_Invalid()
    {
        // Arrange
        var invalidDto = new CreateEmployeeDto
        {
            FirstName = "Mojtaba",
            LastName = "Ataei",
            NationalCode = "123", // Invalid: should be 10 digits
            BirthDate = new DateTime(2300, 1, 1),
            EmployeePosition = EmployeePosition.Developer,
            CompanyId = 1,
            DegreeLevel = DegreeLevel.Bachelor
        };

        _mediatorMock
      .Setup(x => x.Send(It.IsAny<CreateEmployeeRequest>(), It.IsAny<CancellationToken>()))
      .ReturnsAsync(Result<string>.Error("National code must be 10 digits"));

        // Act
        var result = await _controller.Create(invalidDto);

        // Assert
        result.Should().BeOfType<BadRequestObjectResult>();
        var badRequest = result as BadRequestObjectResult;
        badRequest!.StatusCode.Should().Be(400);

        _mediatorMock.Verify(x => x.Send(It.IsAny<CreateEmployeeRequest>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}
