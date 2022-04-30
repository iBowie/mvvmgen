// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

#if MVVMGEN_PURECODEGENERATION

using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace MvvmLightGen
{
    internal static class PureCodeGenerationLibraryLoader
    {
        internal static void AddLibraryFilesToContext(GeneratorPostInitializationContext context)
        {
            var libraryPath = "MvvmLightGen.SourceGenerators.MvvmLightGenLib";
            var assembly = typeof(PureCodeGenerationLibraryLoader).Assembly;
            var embeddedLibraryCodeFiles = assembly.GetManifestResourceNames().Where(x => x.StartsWith(libraryPath));

            foreach (var codeFile in embeddedLibraryCodeFiles)
            {
                var codeFileContent = GetContentOfEmbeddedResource(assembly, codeFile);
                var fileNameHint = codeFile.Replace(libraryPath, "MvvmLightGen").Replace(".cs", ".g.cs");
                context.AddSource(fileNameHint, codeFileContent);
            }
        }

        private static string GetContentOfEmbeddedResource(Assembly assembly, string resourceName)
        {
            using var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using var streamReader = new StreamReader(resourceStream);
            return streamReader.ReadToEnd();
        }
    }
}

#endif
