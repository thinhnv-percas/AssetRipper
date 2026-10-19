using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace AssetRipper.Export.UnityProjects.Scripts.AssemblyDefinitions;

/// <summary>
/// The names in an assembly's AssemblyRef table, read from the image that is actually written out.
/// </summary>
/// <remarks>
/// An IL2Cpp game's assemblies are built in memory by Cpp2IL, and an in-memory AsmResolver module has an empty
/// <c>AssemblyReferences</c> collection: its type references point at assembly references that were never added to
/// it, and the AssemblyRef table only comes into being when the module is written. So the module says the assembly
/// references nothing, every exported <c>.asmdef</c> had <c>"references": []</c>, and Unity compiled each one blind
/// to the others - a CS0246 cascade that ends with Assembly-CSharp skipped altogether because an asmdef it depends on
/// failed. The written image has the table, and it is the image the project ships.
/// </remarks>
public static class AssemblyReferenceNames
{
	public static IReadOnlyList<string> Read(Stream image)
	{
		ArgumentNullException.ThrowIfNull(image);
		long position = image.CanSeek ? image.Position : 0;
		try
		{
			if (image.CanSeek)
			{
				image.Position = 0;
			}
			// PEReader takes the stream over unless told otherwise, and this one belongs to the assembly manager.
			using PEReader reader = new(image, PEStreamOptions.LeaveOpen | PEStreamOptions.PrefetchEntireImage);
			if (!reader.HasMetadata)
			{
				return [];
			}

			MetadataReader metadata = reader.GetMetadataReader();
			List<string> names = new(metadata.AssemblyReferences.Count);
			foreach (AssemblyReferenceHandle handle in metadata.AssemblyReferences)
			{
				string name = metadata.GetString(metadata.GetAssemblyReference(handle).Name);
				if (name.Length > 0 && !names.Contains(name))
				{
					names.Add(name);
				}
			}
			return names;
		}
		catch (BadImageFormatException)
		{
			return [];
		}
		finally
		{
			if (image.CanSeek)
			{
				image.Position = position;
			}
		}
	}
}
