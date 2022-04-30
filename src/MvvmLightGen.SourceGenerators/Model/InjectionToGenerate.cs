// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Model
{
    internal class InjectionToGenerate
    {
        public InjectionToGenerate(string type, string propertyName)
        {
            Type = type;
            PropertyName = propertyName;
        }
        public string Type { get; }

        public string PropertyName { get; }

        public string PropertyAccessModifier { get; set; } = "protected";

        public string SetterAccessModifier => PropertyAccessModifier == "private" ? "" : "private";
    }
}

