// Copyright (c) .NET Foundation and contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET452 || NETCOREAPP1_0 || NETCOREAPP2_0

using System.IO;

namespace Internal.Microsoft.Extensions.DependencyModel.Resolution
{
    internal static class ResolverUtils
    {
        internal static bool TryResolvePackagePath(IFileSystem fileSystem, CompilationLibrary library, string basePath, out string packagePath)
        {
            var path = library.Path;
            if (string.IsNullOrEmpty(path))
            {
                path = Path.Combine(library.Name.ToLowerInvariant(), library.Version.ToLowerInvariant());
            }

            packagePath = Path.Combine(basePath, path);

            if (fileSystem.Directory.Exists(packagePath))
            {
                return true;
            }
            return false;
        }

        internal static bool TryResolveAssemblyFile(IFileSystem fileSystem, string basePath, string assemblyPath, out string fullName)
        {
            fullName = Path.GetFullPath(Path.Combine(basePath, assemblyPath));
            if (fileSystem.File.Exists(fullName))
            {
                return true;
            }
            return false;
        }
    }
}

#endif
