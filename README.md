# NetUtilityKit.LibraryNuget

[![MIT License][license-shield]][license-url]

It allows you to develop your projects quickly. It contains many supporting structures.
Contact us if you want to support.

# Install 
```
  dotnet add package 
```


# Package Included


# ResponseModel:
```
It ensures that the controller is clean and legible.
It allows you to give a stronger and different response. Different Overloads are available.
There is no need to do if else in the controller. You can manage this situation from a different layer.
If you don't want to repeat yourself, you can manage the controller part with a base class.
A simple example is presented.
```


## Use ResponseModel


```
Example- Service
    public async Task<ResponseModel<bool>> CreateItemAsync(CreateItemDto createItemDto, CancellationToken cancellationToken)
    {
        try
        {
            await AddItemAsync(createItemDto, cancellationToken);

            return ResponseModel<bool>.SuccessResponse(true, 201);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);

            return ResponseModel<bool>.ErrorResponse($"{ex.Message}", 500);
        }
    }

Example- Controller

  [HttpPost]
    public async Task<IActionResult> Create(CreateItemDto createItemDto, CancellationToken cancellationToken)
    {
        var response = await _itemService.CreateItemAsync(createItemDto, cancellationToken);

        return new ObjectResult(response)
        {
            StatusCode = response.StatusCode
        };
    }

```

  


[license-shield]: https://img.shields.io/github/license/othneildrew/Best-README-Template.svg?style=for-the-badge
[license-url]: https://github.com/berjcode/GenericRepositoryPatternNugetPackageV1.0.1/blob/main/LICENSE
                                                                                                                      
   ###    By Abdullah Balikci - berjcode

