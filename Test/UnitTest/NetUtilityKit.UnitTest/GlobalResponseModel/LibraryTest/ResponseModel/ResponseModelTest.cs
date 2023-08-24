using NetUtilityKit.NugetPackage.GlobalResponseModel;
using Xunit;

namespace NetUtilityKit.UnitTest.GlobalResponseModel.LibraryTest.ResponseModel;

public class ResponseModelTest
{
    [Fact]

    public void SuccessResponse_ShouldCreateSuccessfulResponseWithMessage()
    {
        // Arrange
        var statusCode = 200;
        var message = "Success message";

        // Act
        var response = ResponseModel<bool>.SuccessResponse(true, statusCode, message);

        // Assert
        Assert.True(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Equal(message, response.Message);
    }

    [Fact]
    public void ErrorResponse_ShouldCreateErrorResponseWithErrors()
    {
        // Arrange
        var statusCode = 500;
        var error = "An error occurred";

        // Act
        var response = ResponseModel<int>.ErrorResponse(error, statusCode);

        // Assert
        Assert.False(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Contains(error, response.Errors);
    }

    [Fact]
    public void SuccessResponse_WithNullData_ShouldCreateSuccessfulResponse()
    {
        // Arrange
        var statusCode = 200;

        // Act
        var response = ResponseModel<string>.SuccessResponse(null, statusCode);

        // Assert
        Assert.True(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Null(response.Result);
    }

    [Fact]
    public void SuccessResponse_WithNullDataAndMessage_ShouldCreateSuccessfulResponse()
    {
        // Arrange
        var statusCode = 200;
        var message = "Success message";

        // Act
        var response = ResponseModel<string>.SuccessResponse(null, statusCode, message);

        // Assert
        Assert.True(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Equal(message, response.Message);
        Assert.Null(response.Result);
    }

    [Fact]
    public void ErrorResponse_WithNullError_ShouldCreateErrorResponse()
    {
        // Arrange
        var statusCode = 500;

        // Act
        var response = ResponseModel<string>.ErrorResponse((List<string>)null, statusCode);

        // Assert
        Assert.False(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Null(response.Errors);
    }

    [Fact]
    public void ErrorResponse_WithNullErrorAndStatusCode_ShouldCreateErrorResponse()
    {
        // Act
        var response = ResponseModel<string>.ErrorResponse((List<string>)null, 0);

        // Assert
        Assert.False(response.IsSuccessful);
        Assert.Equal(0, response.StatusCode);
        Assert.Null(response.Errors);
    }

    [Fact]
    public void SuccessResponse_WithStatusCode_ShouldCreateSuccessfulResponse()
    {
        // Arrange
        var statusCode = 200;

        // Act
        var response = ResponseModel<string>.SuccessResponse(statusCode);

        // Assert
        Assert.True(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Null(response.Result);
    }


    [Fact]
    public void IsSuccessResponse_ReturnsResponseResultAndTrue_ShouldCreateSuccessfulResponse()
    {
        // Arrange
        var statusCode = 200;
        var message = "Success message";

        // Act
        var response = ResponseModel<string>.IsSuccessResponse("data", statusCode, message);

        // Assert
        Assert.True(response.IsSuccessful);
        Assert.Equal(statusCode, response.StatusCode);
        Assert.Null(response.Result);
    }
}
