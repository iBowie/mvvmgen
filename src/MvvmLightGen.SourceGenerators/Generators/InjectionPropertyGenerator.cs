// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using System.Collections.Generic;
using MvvmLightGen.Model;

namespace MvvmLightGen
{
    internal static class InjectionPropertyGenerator
    {
        internal static void GenerateInjectionProperties(this ViewModelBuilder vmBuilder, IEnumerable<InjectionToGenerate>? injectionsToGenerate)
        {
            if (injectionsToGenerate is not null)
            {
                foreach (var injectionToGenerate in injectionsToGenerate)
                {
                    vmBuilder.AppendLineBeforeMember();
                    vmBuilder.AppendLine($"{injectionToGenerate.PropertyAccessModifier} {injectionToGenerate.Type} {injectionToGenerate.PropertyName} {{ get; {injectionToGenerate.SetterAccessModifier} set; }}");
                }
            }
        }
    }
}
