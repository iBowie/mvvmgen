// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Model
{
    internal class CommandToGenerate
    {
        public CommandToGenerate(MethodInfo executeMethod, string propertyName)
        {
            ExecuteMethod = executeMethod;
            PropertyName = propertyName;
        }

        public MethodInfo ExecuteMethod { get; }

        public string PropertyName { get; }

        public MethodInfo? CanExecuteMethod { get; set; }

        public string[]? CanExecuteAffectingProperties { get; set; }
    }

    internal struct MethodInfo
    {
        public MethodInfo(string name) : this()
        {
            Name = name;
        }

        public string Name { get; set; }

        public bool IsAwaitable { get; set; }

        public bool HasParameter { get; set; }
    }
}
