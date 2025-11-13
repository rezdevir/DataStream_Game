using UnityEngine;
using System;
using System.Linq.Expressions;
static public class Log
{
   public static void Show<T>(Expression<Func<T>> expr)
    {
        string name = GetName(expr.Body);
        T value = expr.Compile().Invoke();
        Debug.Log($"{name} : {value}");
    }

    private static string GetName(Expression expr)
    {
        return expr switch
        {
            MemberExpression member => member.ToString(),
            UnaryExpression unary when unary.Operand is MemberExpression member => member.ToString(),
            _ => "Unknown"
        };
    }
}

