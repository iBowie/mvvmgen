﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MvvmLightGen.Extensions
{
    public static class AttributeArgumentSyntaxExtensions
    {
        public static string GetStringValueFromAttributeArgument(this AttributeArgumentSyntax attributeArgumentSyntax)
        {
            var stringValue = attributeArgumentSyntax.Expression switch
            {
                InvocationExpressionSyntax invocationExpressionSyntax => invocationExpressionSyntax.ArgumentList.Arguments[0].ToString(),
                LiteralExpressionSyntax literalExpressionSyntax => literalExpressionSyntax.Token.ValueText,
                _ => attributeArgumentSyntax.Expression.ToString()
            };

            return stringValue;
        }
    }
}
