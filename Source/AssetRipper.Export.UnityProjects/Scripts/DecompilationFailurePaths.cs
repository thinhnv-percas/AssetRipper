using ICSharpCode.Decompiler.Metadata;
using MetadataTypeDefinition = System.Reflection.Metadata.TypeDefinition;
using MetadataTypeDefinitionHandle = System.Reflection.Metadata.TypeDefinitionHandle;
using System.Text.RegularExpressions;

namespace AssetRipper.Export.UnityProjects.Scripts;

/// <summary>
/// Which types a failed whole-project decompilation names, so <see cref="ScriptDecompiler"/> can leave them out and
/// decompile the assembly again.
/// </summary>
public static class DecompilationFailurePaths
{
	/// <summary>The source paths ILSpy names in a decompilation failure, without their extension.</summary>
	public static IEnumerable<string> FailingFilePaths(Exception exception)
	{
		foreach (Match match in Regex.Matches(exception.ToString(), @"Error decompiling for '([^']+)'"))
		{
			string path = match.Groups[1].Value.Replace('\\', '/');

			if (path.EndsWith(".cs", StringComparison.OrdinalIgnoreCase))
			{
				path = path[..^3];
			}

			if (path.Length > 0)
			{
				yield return path;
			}
		}
	}

	/// <summary>
	/// The types declaring the methods ILSpy names in a method-level failure, as the paths
	/// <see cref="PathFor"/> gives them.
	/// </summary>
	/// <remarks>
	/// A file-level failure reads "Error decompiling for 'path.cs'", but a transform that throws inside one method can
	/// escape the parallel loop as "Error decompiling @06000ACA Namespace.Type.Method" with no file named at all - which
	/// <see cref="FailingFilePaths"/> does not read, so nothing was skipped and the retry stopped at once. On SandOut that
	/// was <c>LocalFunctionDecompiler</c> throwing on one closure, and it cost every Assembly-CSharp script not yet
	/// written. The token is exact where the printed name is not (a nested type prints with dots), and it is looked up in
	/// the very module ILSpy read, so the type skipped is the type that failed: the top-level one, since that is the file.
	/// </remarks>
	public static IEnumerable<string> FailingMethodTypePaths(Exception exception, MetadataFile module)
	{
		HashSet<string> named = new(StringComparer.OrdinalIgnoreCase); // an AggregateException prints its inner failure twice
		foreach (Match match in Regex.Matches(exception.ToString(), @"Error decompiling @([0-9A-Fa-f]{8})\b"))
		{
			int token = int.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.HexNumber);
			if (token >> 24 != 0x06)
			{
				continue; // only a MethodDef names a body
			}

			int row = token & 0xFFFFFF;
			if (row < 1 || row > module.Metadata.MethodDefinitions.Count)
			{
				continue;
			}

			MetadataTypeDefinitionHandle type = module.Metadata.GetMethodDefinition(System.Reflection.Metadata.Ecma335.MetadataTokens.MethodDefinitionHandle(row)).GetDeclaringType();
			while (!type.IsNil && module.Metadata.GetTypeDefinition(type).GetDeclaringType() is { IsNil: false } outer)
			{
				type = outer;
			}

			if (!type.IsNil && named.Add(PathFor(module, type)))
			{
				yield return PathFor(module, type);
			}
		}
	}

	/// <summary>Where ILSpy would put this type, as namespace directories and the type's own name.</summary>
	public static string PathFor(MetadataFile module, MetadataTypeDefinitionHandle handle)
	{
		MetadataTypeDefinition definition = module.Metadata.GetTypeDefinition(handle);
		string name = module.Metadata.GetString(definition.Name);
		string containingNamespace = module.Metadata.GetString(definition.Namespace);

		int arity = name.IndexOf('`');
		if (arity >= 0)
		{
			name = name[..arity];
		}

		return string.IsNullOrEmpty(containingNamespace) ? name : containingNamespace.Replace('.', '/') + '/' + name;
	}
}
