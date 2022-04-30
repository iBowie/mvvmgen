// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string str)
        {
            return str.Substring(0, 1).ToLower() + str.Substring(1);
        }
    }
}
