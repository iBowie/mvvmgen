// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

#nullable enable

using System;

namespace MvvmLightGen
{
    /// <summary>
    /// Specifies that a class is an Observable Object. With this attribute set on a class, a partial class definition is generated.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ObservableObjectAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableObjectAttribute"/> class.
        /// </summary>
        public ObservableObjectAttribute() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableObjectAttribute"/> class.
        /// </summary>
        /// <param name="modelType">The type of the model that is wrapped by the Observable Object. All properties of the model type will be generated in the Observable Object.</param>
        public ObservableObjectAttribute(Type modelType)
        {
            ModelType = modelType;
        }

        /// <summary>
        /// Gets or sets the type of the model that is wrapped by the Observable Object. All properties of the model type will be generated in the Observable Object.
        /// </summary>
        public Type? ModelType { get; set; }

        /// <summary>
        /// Gets or sets if a constructor is generated. Default value is false.
        /// </summary>
        public bool GenerateConstructor { get; set; } = false;
    }
}
