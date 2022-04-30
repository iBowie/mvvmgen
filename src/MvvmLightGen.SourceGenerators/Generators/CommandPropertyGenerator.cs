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
    internal static class CommandPropertyGenerator
    {
        internal static void GenerateCommandProperties(this ViewModelBuilder vmBuilder, IEnumerable<CommandToGenerate>? commandsToGenerate)
        {
            if (commandsToGenerate is not null)
            {
                foreach (var commandToGenerate in commandsToGenerate)
                {
                    vmBuilder.AppendLineBeforeMember();
                    vmBuilder.AppendLine($"public RelayCommand {commandToGenerate.PropertyName} {{ get; private set; }}");
                }
            }
        }
    }
}
