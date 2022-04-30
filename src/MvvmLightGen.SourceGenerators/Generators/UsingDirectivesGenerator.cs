// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Generators
{
    internal static class UsingDirectivesGenerator
    {
        internal static void GenerateUsingDirectives(this ViewModelBuilder vmBuilder)
        {
            vmBuilder.AppendLine("using GalaSoft.MvvmLight;");
            vmBuilder.AppendLine("using GalaSoft.MvvmLight.Command;");
            vmBuilder.AppendLine("using MvvmLightGen.Events;");
        }
    }
}
