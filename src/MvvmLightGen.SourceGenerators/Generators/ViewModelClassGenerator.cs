// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using Microsoft.CodeAnalysis;

namespace MvvmLightGen.Generators
{
    internal static class ClassGenerator
    {
        internal static void GenerateClass(this ViewModelBuilder vmBuilder, INamedTypeSymbol viewModelClassSymbol, INamedTypeSymbol viewModelBaseSymbol)
        {
            vmBuilder.AppendLine($"partial class {viewModelClassSymbol.Name}");
            vmBuilder.AppendLine("{");
            vmBuilder.IncreaseIndent();
        }
    }
}
