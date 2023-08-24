using NetUtilityKit.NugetPackage.ExpressionParser;
using NetUtilityKit.UnitTest.ItemsForTest.Entities;
using Xunit;

namespace NetUtilityKit.UnitTest.ExpressionParserClass.LibraryTest;

public class ExpressionParserTest
{
    [Theory]
    [InlineData("Price > 18 ",1)]
    public void TestExpressionParsing(string expression,int exceptedCount)
    {
        //Arrange
        var parseExpression = ExpressionParser.ParseExpression<Product>(expression);

        var products = new[]
        {
                new Product { Id = 1, Name = "Masa", Price = 12 },
                new Product { Id = 2, Name = "Klasik Masa", Price = 20 },
                new Product { Id = 3, Name = "Sandalye", Price = 10 }
            };
        //Act
        int count = products.Count(product => parseExpression.Compile()(product));
        //Assert
        Assert.Equal(exceptedCount, count);
    }
}
