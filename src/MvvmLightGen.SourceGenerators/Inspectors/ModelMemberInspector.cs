﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using MvvmLightGen.Model;

namespace MvvmLightGen.Inspectors
{
    internal static class ModelMemberInspector
    {
        internal static string? Inspect(AttributeData viewModelAttributeData, IList<PropertyToGenerate> propertiesToGenerate)
        {
            string? wrappedModelType = null;

            var modelTypedConstant = (TypedConstant?)viewModelAttributeData.ConstructorArguments.FirstOrDefault();

            foreach (var arg in viewModelAttributeData.NamedArguments)
            {
                if (arg.Key == "ModelType")
                {
                    modelTypedConstant = arg.Value;
                }
            }

            if (modelTypedConstant?.Value is not null)
            {
                if (modelTypedConstant.Value.Value is INamedTypeSymbol model)
                {
                    wrappedModelType = $"{model}";
                    var members = model.GetMembers();
                    foreach (var member in members)
                    {
                        if (member is IMethodSymbol { MethodKind: MethodKind.PropertyGet } methodSymbol)
                        {
                            var propertySymbol = (IPropertySymbol?)methodSymbol.AssociatedSymbol;
                            if (propertySymbol is not null)
                            {
                                propertiesToGenerate.Add(new PropertyToGenerate(
                                  propertySymbol.Name, propertySymbol.Type.ToString(), $"Model.{propertySymbol.Name}", propertySymbol.IsReadOnly));
                            }
                        }
                    }
                }
            }

            return wrappedModelType;
        }
    }
}
