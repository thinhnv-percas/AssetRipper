using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.Documentation;

[Serializable]
internal class GetPotentiallyNestedClassTypeReference : ITypeReference
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
		string[] parts = typeName.Split('.');
		IEnumerable<IAssembly> enumerable = new IAssembly[1] { context.CurrentAssembly }.Concat(context.Compilation.Assemblies);
		for (int num = parts.Length - 1; num >= 0; num--)
		{
			string namespaceName = string.Join(".", parts, 0, num);
			string name = parts[num];
			int num2 = ((num == parts.Length - 1) ? typeParameterCount : 0);
			foreach (IAssembly item in enumerable)
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
					typeDefinition = typeDefinition.NestedTypes.FirstOrDefault((ITypeDefinition n) => n.Name == parts[j] && n.TypeParameterCount == tpc);
				}
				if (typeDefinition != null)
				{
					return typeDefinition;
				}
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
