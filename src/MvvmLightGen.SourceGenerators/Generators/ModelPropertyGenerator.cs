// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
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
