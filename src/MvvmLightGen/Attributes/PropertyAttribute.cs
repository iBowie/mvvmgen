﻿// ***********************************************************************
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
    /// Specifies that a property in the ViewModel should be generated for a field. Set this attribute on a field of a class that has the <see cref="ViewModelAttribute"/> or <see cref="ObservableObjectAttribute"> set.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class PropertyAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAttribute"/> class.
        /// </summary>
        public PropertyAttribute() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">The name of the property to generate</param>
        public PropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }

        /// <summary>
        /// Gets or sets the name of property to generate.
        /// </summary>
        public string? PropertyName { get; set; }
    }
}
