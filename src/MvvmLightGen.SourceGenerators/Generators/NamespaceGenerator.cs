// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using Microsoft.CodeAnalysis;

namespace MvvmLightGen.Generators
{
    internal static class NamespaceGenerator
    {
        internal static void GenerateNamespace(this ViewModelBuilder vmBuilder, INamedTypeSymbol viewModelClassSymbol)
        {
            vmBuilder.AppendLine();

            // Add namespace declaration
            if (viewModelClassSymbol.ContainingNamespace is null)
            {
                return;
                // TODO: Show an error here. ViewModel class must be top-level within a namespace
            }

            vmBuilder.AppendLine($"namespace {viewModelClassSymbol.ContainingNamespace}");
            vmBuilder.AppendLine("{");
            vmBuilder.IncreaseIndent();
        }
    }
}
