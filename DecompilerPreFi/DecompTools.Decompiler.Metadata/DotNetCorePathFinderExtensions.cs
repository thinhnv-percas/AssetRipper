using System;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace DecompTools.Decompiler.Metadata;

public static class DotNetCorePathFinderExtensions
{
	private static readonly string RefPathPattern = "(Reference Assemblies[/\\\\]Microsoft[/\\\\]Framework[/\\\\](?<1>.NETFramework)[/\\\\]v(?<2>[^/\\\\]+)[/\\\\])|(NuGetFallbackFolder[/\\\\](?<1>[^/\\\\]+)\\\\(?<2>[^/\\\\]+)([/\\\\].*)?[/\\\\]ref[/\\\\])";

	public static string DetectTargetFrameworkId(this PEReader assembly, string assemblyPath = null)
	{
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		MetadataReader metadataReader = assembly.GetMetadataReader();
		foreach (CustomAttributeHandle customAttribute2 in metadataReader.GetCustomAttributes(Handle.AssemblyDefinition))
		{
			CustomAttribute customAttribute = metadataReader.GetCustomAttribute(customAttribute2);
			if (!(customAttribute.GetAttributeType(metadataReader).GetFullTypeName(metadataReader).ToString() != "System.Runtime.Versioning.TargetFrameworkAttribute"))
			{
				BlobReader blobReader = metadataReader.GetBlobReader(customAttribute.Value);
				if (blobReader.ReadUInt16() == 1)
				{
					return blobReader.ReadSerializedString();
				}
			}
		}
		if (assemblyPath != null)
		{
			Match val = Regex.Match(assemblyPath, RefPathPattern, (RegexOptions)13);
			if (((Group)val).Success)
			{
				string value = ((Capture)val.Groups[1]).Value;
				string value2 = ((Capture)val.Groups[2]).Value;
				if (value == ".NETFramework")
				{
					return ".NETFramework,Version=v" + value2;
				}
				if (value.Contains("netcore"))
				{
					return ".NETCoreApp,Version=v" + value2;
				}
				if (value.Contains("netstandard"))
				{
					return ".NETStandard,Version=v" + value2;
				}
			}
		}
		return string.Empty;
	}
}
