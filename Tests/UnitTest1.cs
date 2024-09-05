using Application.Services.Rabbit;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Moq;
using Presentation.Controllers;
using Xunit;

public class QueControllerTests
{
    private readonly Mock<RabbitService> _rabbitServiceMock;
    private readonly Mock<IHostApplicationLifetime> _applicationLifetimeMock;
    private readonly QueController _controller;

    public QueControllerTests()
    {
        _rabbitServiceMock = new Mock<RabbitService>();
        _applicationLifetimeMock = new Mock<IHostApplicationLifetime>();
        _controller = new QueController(_rabbitServiceMock.Object, _applicationLifetimeMock.Object);
    }

    [Fact]
    public void StartListening_ReturnsOk()
    {
        var result = _controller.StartListening();
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Started listening for messages", okResult.Value);
    }

    [Fact]
    public void StopListening_ReturnsOk()
    {
        var result = _controller.StopListening();
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Stopped listening for messages", okResult.Value);
    }

    [Fact]
    public void PublishMessage_ReturnsOk()
    {
        var persona = new Persona("John","Doe");
        var result = _controller.PublishMessage(persona);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Message published to the queue", okResult.Value);
    }

    [Fact]
    public void PublishMessage_ReturnsBadRequest_WhenPersonaIsNull()
    {
        var result = _controller.PublishMessage(null);
        var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        Assert.Equal("Message cannot be null or empty", badRequestResult.Value);
    }
}