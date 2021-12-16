﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using MvvmLightGen.Model;

namespace MvvmLightGen
{
    internal static class CommandInitializeMethodGenerator
    {
        internal static void GenerateCommandInitializeMethod(this ViewModelBuilder vmBuilder, IEnumerable<CommandToGenerate>? commandsToGenerate)
        {
            if (commandsToGenerate is not null && commandsToGenerate.Any())
            {
                vmBuilder.AppendLineBeforeMember();
                vmBuilder.AppendLine("private void InitializeCommands()");
                vmBuilder.AppendLine("{");
                vmBuilder.IncreaseIndent();
                foreach (var commandToGenerate in commandsToGenerate)
                {
                    vmBuilder.Append($"{commandToGenerate.PropertyName} = new RelayCommand({GetMethodCall(commandToGenerate.ExecuteMethod)}");
                    if (commandToGenerate.CanExecuteMethod.HasValue)
                    {
                        vmBuilder.Append($", {GetMethodCall(commandToGenerate.CanExecuteMethod.Value)}");
                    }
                    vmBuilder.AppendLine(");");
                }
                vmBuilder.DecreaseIndent();
                vmBuilder.AppendLine("}");
            }
        }

        private static object GetMethodCall(MethodInfo methodInfo)
        {
            return methodInfo switch
            {
                { IsAwaitable: true, HasParameter: true } => $"async x => await {methodInfo.Name}(x)",
                { IsAwaitable: true, HasParameter: false } => $"async _ => await {methodInfo.Name}()",
                { IsAwaitable: false, HasParameter: true } => $"{methodInfo.Name}",
                { IsAwaitable: false, HasParameter: false } => $"_ => {methodInfo.Name}()",
            };
        }
    }
}
