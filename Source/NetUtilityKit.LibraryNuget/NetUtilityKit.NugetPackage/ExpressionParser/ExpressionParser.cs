using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace NetUtilityKit.NugetPackage.ExpressionParser;

public static class ExpressionParser
{
    public static Expression<Func<T, bool>> ParseExpression<T>(string expression)
    {
        var parameter = Expression.Parameter(typeof(T));
        var lambda = DynamicExpressionParser.ParseLambda(new[] { parameter }, typeof(bool), expression);

        return (Expression<Func<T, bool>>)lambda;
    }
}
