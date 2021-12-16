﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Inspectors
{
    internal static class ViewModelAttributeInspector
    {
        internal static bool Inspect(Microsoft.CodeAnalysis.AttributeData viewModelAttributeData)
        {
            var generateConstructor = false;

            foreach (var arg in viewModelAttributeData.NamedArguments)
            {
                if (arg.Key == "GenerateConstructor")
                {
                    generateConstructor = (bool?)arg.Value.Value == true;
                }
            }

            return generateConstructor;
        }
    }
}
