using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.Analysis
{
	public class TypeGraph
	{
		private Dictionary<AssemblyQualifiedTypeName, TypeGraphNode> dict;

		public TypeGraph(IEnumerable<IAssembly> assemblies)
		{
			if (assemblies == null)
			{
				throw new ArgumentNullException("assemblies");
			}
			dict = new Dictionary<AssemblyQualifiedTypeName, TypeGraphNode>();
			foreach (IAssembly assembly in assemblies)
			{
				foreach (ITypeDefinition allTypeDefinition in assembly.GetAllTypeDefinitions())
				{
					dict[new AssemblyQualifiedTypeName(allTypeDefinition)] = new TypeGraphNode(allTypeDefinition);
				}
			}
			foreach (IAssembly assembly2 in assemblies)
			{
				foreach (ITypeDefinition allTypeDefinition2 in assembly2.GetAllTypeDefinitions())
				{
					TypeGraphNode typeGraphNode = dict[new AssemblyQualifiedTypeName(allTypeDefinition2)];
					foreach (IType directBaseType in allTypeDefinition2.DirectBaseTypes)
					{
						ITypeDefinition definition = directBaseType.GetDefinition();
						if (definition != null && dict.TryGetValue(new AssemblyQualifiedTypeName(definition), out TypeGraphNode value))
						{
							typeGraphNode.BaseTypes.Add(value);
							value.DerivedTypes.Add(typeGraphNode);
						}
					}
				}
			}
		}

		public TypeGraphNode GetNode(ITypeDefinition typeDefinition)
		{
			if (typeDefinition == null)
			{
				return null;
			}
			return GetNode(new AssemblyQualifiedTypeName(typeDefinition));
		}

		public TypeGraphNode GetNode(AssemblyQualifiedTypeName typeName)
		{
			if (dict.TryGetValue(typeName, out TypeGraphNode value))
			{
				return value;
			}
			return null;
		}
	}
}
