// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
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
