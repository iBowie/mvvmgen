﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Generators
{
    internal static class CommentHeaderGenerator
    {
        internal static void GenerateCommentHeader(this ViewModelBuilder vmBuilder, string versionString)
        {
            vmBuilder.AppendLine("// <auto-generated>");
            vmBuilder.AppendLine("//   This code was generated for you by");
            vmBuilder.AppendLine("//   ⚡ MvvmLightGen, a tool created by Thomas Claudius Huber (https://www.thomasclaudiushuber.com)");
            vmBuilder.AppendLine($"//   Generator version: {versionString}");
            vmBuilder.AppendLine("// </auto-generated>");
        }
    }
}
