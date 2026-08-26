using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.Documentation;

[Serializable]
public class GetPotentiallyNestedClassTypeReference : ITypeReference
{
	private readonly string typeName;

	private readonly int typeParameterCount;

	public GetPotentiallyNestedClassTypeReference(string typeName, int typeParameterCount)
	{
		this.typeName = typeName;
		this.typeParameterCount = typeParameterCount;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		string[] parts = typeName.Split(new char[1] { '.' });
		IEnumerable<IModule> enumerable = Enumerable.Concat<IModule>((IEnumerable<IModule>)new IModule[1] { context.CurrentModule }, (IEnumerable<IModule>)context.Compilation.Modules);
		checked
		{
			for (int num = parts.Length - 1; num >= 0; num--)
			{
				string namespaceName = string.Join(".", parts, 0, num);
				string name = parts[num];
				int num2 = ((num == parts.Length - 1) ? typeParameterCount : 0);
				foreach (IModule item in enumerable)
				{
					if (item == null)
					{
						continue;
					}
					ITypeDefinition typeDefinition = item.GetTypeDefinition(new TopLevelTypeName(namespaceName, name, num2));
					for (int j = num + 1; j < parts.Length; j++)
					{
						if (typeDefinition == null)
						{
							break;
						}
						int tpc = ((j == parts.Length - 1) ? typeParameterCount : 0);
						typeDefinition = Enumerable.FirstOrDefault<ITypeDefinition>((IEnumerable<ITypeDefinition>)typeDefinition.NestedTypes, (Func<ITypeDefinition, bool>)((ITypeDefinition n) => n.Name == parts[j] && n.TypeParameterCount == tpc));
					}
					if (typeDefinition == null)
					{
						continue;
					}
					return typeDefinition;
				}
			}
			int num3 = typeName.LastIndexOf('.');
			if (num3 < 0)
			{
				return new UnknownType("", typeName, typeParameterCount);
			}
			return new UnknownType(typeName.Substring(0, num3), typeName.Substring(num3 + 1), typeParameterCount);
		}
	}

	public EntityHandle ResolveInPEFile(PEFile module)
	{
		string[] array = typeName.Split(new char[1] { '.' });
		checked
		{
			for (int num = array.Length - 1; num >= 0; num--)
			{
				string namespaceName = string.Join(".", array, 0, num);
				string name = array[num];
				int num2 = ((num == array.Length - 1) ? typeParameterCount : 0);
				TopLevelTypeName topLevelTypeName = new TopLevelTypeName(namespaceName, name, num2);
				TypeDefinitionHandle typeDefinitionHandle = module.GetTypeDefinition(topLevelTypeName);
				for (int i = num + 1; i < array.Length; i++)
				{
					if (typeDefinitionHandle.IsNil)
					{
						break;
					}
					int num3 = ((i == array.Length - 1) ? typeParameterCount : 0);
					TypeDefinition typeDefinition = module.Metadata.GetTypeDefinition(typeDefinitionHandle);
					string lookupName = array[i] + ((num3 > 0) ? ("`" + num3) : "");
					typeDefinitionHandle = typeDefinition.GetNestedTypes().FirstOrDefault((TypeDefinitionHandle n) => IsEqualShortName(n, module.Metadata, lookupName));
				}
				if (!typeDefinitionHandle.IsNil)
				{
					return typeDefinitionHandle;
				}
				FullTypeName fullTypeName = topLevelTypeName;
				for (int num4 = num + 1; num4 < array.Length; num4++)
				{
					int additionalTypeParameterCount = ((num4 == array.Length - 1) ? typeParameterCount : 0);
					fullTypeName = fullTypeName.NestedType(array[num4], additionalTypeParameterCount);
				}
				ExportedTypeHandle typeForwarder = module.GetTypeForwarder(fullTypeName);
				if (!typeForwarder.IsNil)
				{
					return typeForwarder;
				}
			}
			return default(EntityHandle);
		}
		static bool IsEqualShortName(TypeDefinitionHandle h, MetadataReader metadata, string value)
		{
			TypeDefinition typeDefinition2 = metadata.GetTypeDefinition(h);
			return metadata.StringComparer.Equals(typeDefinition2.Name, value);
		}
	}
}
