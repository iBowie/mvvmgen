﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
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

