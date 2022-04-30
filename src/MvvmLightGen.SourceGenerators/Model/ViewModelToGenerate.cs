// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace MvvmLightGen.Model
{
    /// <summary>
    /// Contains all the details that must be generated for a class that is decorated with the MvvmLightGen.ViewModelAttribute.
    /// </summary>
    internal class ViewModelToGenerate
    {
        public ViewModelToGenerate(INamedTypeSymbol viewModelClassSymbol)
        {
            ViewModelClassSymbol = viewModelClassSymbol;
        }

        public INamedTypeSymbol ViewModelClassSymbol { get; }

        public string? WrappedModelType { get; set; }

        public bool IsEventSubscriber { get; set; }

        public bool GenerateConstructor { get; set; }

        public IEnumerable<CommandToGenerate>? CommandsToGenerate { get; set; }

        public IList<PropertyToGenerate>? PropertiesToGenerate { get; set; }

        public IEnumerable<InjectionToGenerate>? InjectionsToGenerate { get; set; }
    }
}
