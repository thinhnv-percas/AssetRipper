using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.Metadata;

public class PEFile : IDisposable, IModuleReference
{
	private class PEFileWithOptions : IModuleReference
	{
		private readonly PEFile peFile;

		private readonly TypeSystemOptions options;

		public PEFileWithOptions(PEFile peFile, TypeSystemOptions options)
		{
			this.peFile = peFile;
			this.options = options;
		}

		IModule IModuleReference.Resolve(ITypeResolveContext context)
		{
			return new MetadataModule(context.Compilation, peFile, options);
		}
	}

	private Dictionary<TopLevelTypeName, TypeDefinitionHandle> typeLookup;

	private Dictionary<FullTypeName, ExportedTypeHandle> typeForwarderLookup;

	private MethodSemanticsLookup methodSemanticsLookup;

	public string FileName { get; }

	public PEReader Reader { get; }

	public MetadataReader Metadata { get; }

	public bool IsAssembly => Metadata.IsAssembly;

	public string Name => GetName();

	public string FullName => IsAssembly ? Metadata.GetFullAssemblyName() : Name;

	public ImmutableArray<AssemblyReference> AssemblyReferences => Enumerable.Select<AssemblyReferenceHandle, AssemblyReference>((IEnumerable<AssemblyReferenceHandle>)Metadata.AssemblyReferences, (Func<AssemblyReferenceHandle, AssemblyReference>)((AssemblyReferenceHandle r) => new AssemblyReference(this, r))).ToImmutableArray();

	public ImmutableArray<Resource> Resources => GetResources().ToImmutableArray();

	internal MethodSemanticsLookup MethodSemanticsLookup
	{
		get
		{
			MethodSemanticsLookup methodSemanticsLookup = LazyInit.VolatileRead(ref this.methodSemanticsLookup);
			if (methodSemanticsLookup != null)
			{
				return methodSemanticsLookup;
			}
			return LazyInit.GetOrSet(ref this.methodSemanticsLookup, new MethodSemanticsLookup(Metadata));
		}
	}

	public PEFile(string fileName, PEStreamOptions streamOptions = PEStreamOptions.Default, MetadataReaderOptions metadataOptions = MetadataReaderOptions.Default)
		: this(fileName, new PEReader(new FileStream(fileName, FileMode.Open, FileAccess.Read), streamOptions), metadataOptions)
	{
	}

	public PEFile(string fileName, Stream stream, PEStreamOptions streamOptions = PEStreamOptions.Default, MetadataReaderOptions metadataOptions = MetadataReaderOptions.Default)
		: this(fileName, new PEReader(stream, streamOptions), metadataOptions)
	{
	}

	public PEFile(string fileName, PEReader reader, MetadataReaderOptions metadataOptions = MetadataReaderOptions.Default)
	{
		FileName = fileName ?? throw new ArgumentNullException("fileName");
		Reader = reader ?? throw new ArgumentNullException("reader");
		if (!reader.HasMetadata)
		{
			throw new PEFileNotSupportedException("PE file does not contain any managed metadata.");
		}
		Metadata = reader.GetMetadataReader(metadataOptions);
	}

	public TargetRuntime GetRuntime()
	{
		string metadataVersion = Metadata.MetadataVersion;
		switch (metadataVersion[1])
		{
		case '1':
			if (metadataVersion[3] == '\u0001')
			{
				return TargetRuntime.Net_1_0;
			}
			return TargetRuntime.Net_1_1;
		case '2':
			return TargetRuntime.Net_2_0;
		case '4':
			return TargetRuntime.Net_4_0;
		default:
			return TargetRuntime.Unknown;
		}
	}

	private string GetName()
	{
		MetadataReader metadata = Metadata;
		if (metadata.IsAssembly)
		{
			return metadata.GetString(metadata.GetAssemblyDefinition().Name);
		}
		return metadata.GetString(metadata.GetModuleDefinition().Name);
	}

	private IEnumerable<Resource> GetResources()
	{
		MetadataReader metadata = Metadata;
		foreach (ManifestResourceHandle h in metadata.ManifestResources)
		{
			yield return new Resource(this, h);
		}
	}

	public void Dispose()
	{
		Reader.Dispose();
	}

	public TypeDefinitionHandle GetTypeDefinition(TopLevelTypeName typeName)
	{
		Dictionary<TopLevelTypeName, TypeDefinitionHandle> dictionary = LazyInit.VolatileRead(ref typeLookup);
		if (dictionary == null)
		{
			dictionary = new Dictionary<TopLevelTypeName, TypeDefinitionHandle>();
			foreach (TypeDefinitionHandle typeDefinition2 in Metadata.TypeDefinitions)
			{
				TypeDefinition typeDefinition = Metadata.GetTypeDefinition(typeDefinition2);
				if (typeDefinition.GetDeclaringType().IsNil)
				{
					StringHandle handle = typeDefinition.Namespace;
					string namespaceName = (handle.IsNil ? string.Empty : Metadata.GetString(handle));
					string name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(Metadata.GetString(typeDefinition.Name), out var typeParameterCount);
					dictionary[new TopLevelTypeName(namespaceName, name, typeParameterCount)] = typeDefinition2;
				}
			}
			dictionary = LazyInit.GetOrSet(ref typeLookup, dictionary);
		}
		if (dictionary.TryGetValue(typeName, out var value))
		{
			return value;
		}
		return default(TypeDefinitionHandle);
	}

	public ExportedTypeHandle GetTypeForwarder(FullTypeName typeName)
	{
		Dictionary<FullTypeName, ExportedTypeHandle> dictionary = LazyInit.VolatileRead(ref typeForwarderLookup);
		if (dictionary == null)
		{
			dictionary = new Dictionary<FullTypeName, ExportedTypeHandle>();
			foreach (ExportedTypeHandle exportedType2 in Metadata.ExportedTypes)
			{
				ExportedType exportedType = Metadata.GetExportedType(exportedType2);
				dictionary[exportedType.GetFullTypeName(Metadata)] = exportedType2;
			}
			dictionary = LazyInit.GetOrSet(ref typeForwarderLookup, dictionary);
		}
		if (dictionary.TryGetValue(typeName, out var value))
		{
			return value;
		}
		return default(ExportedTypeHandle);
	}

	public IModuleReference WithOptions(TypeSystemOptions options)
	{
		return new PEFileWithOptions(this, options);
	}

	IModule IModuleReference.Resolve(ITypeResolveContext context)
	{
		return new MetadataModule(context.Compilation, this, TypeSystemOptions.Default);
	}
}
