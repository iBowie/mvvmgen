﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Generators
{
    internal static class ModelPropertyGenerator
    {
        internal static void GenerateModelProperty(this ViewModelBuilder vmBuilder, string? wrappedModelType)
        {
            if (wrappedModelType is { Length: > 0 })
            {
                vmBuilder.AppendLineBeforeMember();
                vmBuilder.AppendLine($"protected {wrappedModelType} Model {{ get; set; }}");
            }
        }
    }
}
