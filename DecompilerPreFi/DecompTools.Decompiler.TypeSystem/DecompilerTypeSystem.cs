using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

public class DecompilerTypeSystem : SimpleCompilation, IDecompilerTypeSystem, ICompilation
{
	public new MetadataModule MainModule { get; }

	public static TypeSystemOptions GetOptions(DecompilerSettings settings)
	{
		TypeSystemOptions typeSystemOptions = TypeSystemOptions.None;
		if (settings.Dynamic)
		{
			typeSystemOptions |= TypeSystemOptions.Dynamic;
		}
		if (settings.TupleTypes)
		{
			typeSystemOptions |= TypeSystemOptions.Tuple;
		}
		if (settings.ExtensionMethods)
		{
			typeSystemOptions |= TypeSystemOptions.ExtensionMethods;
		}
		if (settings.DecimalConstants)
		{
			typeSystemOptions |= TypeSystemOptions.DecimalConstants;
		}
		if (settings.IntroduceRefModifiersOnStructs)
		{
			typeSystemOptions |= TypeSystemOptions.RefStructs;
		}
		if (settings.IntroduceReadonlyAndInModifiers)
		{
			typeSystemOptions |= TypeSystemOptions.ReadOnlyStructsAndParameters;
		}
		if (settings.IntroduceUnmanagedConstraint)
		{
			typeSystemOptions |= TypeSystemOptions.UnmanagedConstraints;
		}
		if (settings.NullableReferenceTypes)
		{
			typeSystemOptions |= TypeSystemOptions.NullabilityAnnotations;
		}
		return typeSystemOptions;
	}

	public DecompilerTypeSystem(PEFile mainModule, IAssemblyResolver assemblyResolver)
		: this(mainModule, assemblyResolver, TypeSystemOptions.Default)
	{
	}

	public DecompilerTypeSystem(PEFile mainModule, IAssemblyResolver assemblyResolver, DecompilerSettings settings)
		: this(mainModule, assemblyResolver, GetOptions(settings ?? throw new ArgumentNullException("settings")))
	{
	}

	public DecompilerTypeSystem(PEFile mainModule, IAssemblyResolver assemblyResolver, TypeSystemOptions typeSystemOptions)
	{
		if (mainModule == null)
		{
			throw new ArgumentNullException("mainModule");
		}
		if (assemblyResolver == null)
		{
			throw new ArgumentNullException("assemblyResolver");
		}
		List<PEFile> referencedAssemblies = new List<PEFile>();
		Queue<(bool, PEFile, object)> queue = new Queue<(bool, PEFile, object)>();
		MetadataReader metadata = mainModule.Metadata;
		foreach (ModuleReferenceHandle moduleReference in metadata.GetModuleReferences())
		{
			string text = metadata.GetString(metadata.GetModuleReference(moduleReference).Name);
			foreach (AssemblyFileHandle assemblyFile2 in metadata.AssemblyFiles)
			{
				AssemblyFile assemblyFile = metadata.GetAssemblyFile(assemblyFile2);
				if (metadata.StringComparer.Equals(assemblyFile.Name, text) && assemblyFile.ContainsMetadata)
				{
					queue.Enqueue((false, mainModule, text));
					break;
				}
			}
		}
		foreach (DecompTools.Decompiler.Metadata.AssemblyReference assemblyReference in mainModule.AssemblyReferences)
		{
			queue.Enqueue((true, mainModule, assemblyReference));
		}
		KeyComparer<(bool, PEFile, object), string> keyComparer = KeyComparer.Create(((bool IsAssembly, PEFile MainModule, object Reference) reference) => reference.IsAssembly ? ("A:" + ((DecompTools.Decompiler.Metadata.AssemblyReference)reference.Reference).FullName) : ("M:" + reference.Reference));
		HashSet<(bool, PEFile, object)> val = new HashSet<(bool, PEFile, object)>((IEqualityComparer<(bool, PEFile, object)>)keyComparer);
		while (queue.Count > 0)
		{
			(bool, PEFile, object) tuple = queue.Dequeue();
			if (!val.Add(tuple))
			{
				continue;
			}
			PEFile pEFile = ((!tuple.Item1) ? assemblyResolver.ResolveModule(tuple.Item2, (string)tuple.Item3) : assemblyResolver.Resolve((DecompTools.Decompiler.Metadata.AssemblyReference)tuple.Item3));
			if (pEFile == null)
			{
				continue;
			}
			referencedAssemblies.Add(pEFile);
			MetadataReader metadata2 = pEFile.Metadata;
			foreach (ExportedTypeHandle exportedType2 in metadata2.ExportedTypes)
			{
				ExportedType exportedType = metadata2.GetExportedType(exportedType2);
				switch (exportedType.Implementation.Kind)
				{
				case HandleKind.AssemblyReference:
					queue.Enqueue((true, pEFile, new DecompTools.Decompiler.Metadata.AssemblyReference(pEFile, (AssemblyReferenceHandle)exportedType.Implementation)));
					break;
				case HandleKind.AssemblyFile:
					queue.Enqueue((false, pEFile, metadata2.GetString(metadata2.GetAssemblyFile((AssemblyFileHandle)exportedType.Implementation).Name)));
					break;
				}
			}
		}
		IModuleReference mainAssembly = mainModule.WithOptions(typeSystemOptions);
		IEnumerable<IModuleReference> enumerable = Enumerable.Select<PEFile, IModuleReference>((IEnumerable<PEFile>)referencedAssemblies, (Func<PEFile, IModuleReference>)((PEFile file) => file.WithOptions(typeSystemOptions)));
		if (!HasType(KnownTypeCode.Void) || !HasType(KnownTypeCode.Int32))
		{
			Init(mainModule.WithOptions(typeSystemOptions), Enumerable.Concat<IModuleReference>(enumerable, (IEnumerable<IModuleReference>)new IModuleReference[1] { MinimalCorlib.Instance }));
		}
		else
		{
			Init(mainAssembly, enumerable);
		}
		MainModule = (MetadataModule)base.MainModule;
		bool HasType(KnownTypeCode code)
		{
			TopLevelTypeName typeName = KnownTypeReference.Get(code).TypeName;
			if (!mainModule.GetTypeDefinition(typeName).IsNil)
			{
				return true;
			}
			foreach (PEFile item in referencedAssemblies)
			{
				if (!item.GetTypeDefinition(typeName).IsNil)
				{
					return true;
				}
			}
			return false;
		}
	}
}
