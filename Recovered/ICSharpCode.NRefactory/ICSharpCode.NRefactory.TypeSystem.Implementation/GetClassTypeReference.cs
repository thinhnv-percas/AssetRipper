using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public sealed class GetClassTypeReference : ITypeReference, ISymbolReference, ISupportsInterning
	{
		private readonly IAssemblyReference assembly;

		private readonly FullTypeName fullTypeName;

		public IAssemblyReference Assembly => assembly;

		public FullTypeName FullTypeName => fullTypeName;

		[Obsolete("Use the FullTypeName property instead. GetClassTypeReference now supports nested types, where the Namespace/Name/TPC tripel isn't sufficient for identifying the type.")]
		public string Namespace => fullTypeName.TopLevelTypeName.Namespace;

		[Obsolete("Use the FullTypeName property instead. GetClassTypeReference now supports nested types, where the Namespace/Name/TPC tripel isn't sufficient for identifying the type.")]
		public string Name => fullTypeName.Name;

		[Obsolete("Use the FullTypeName property instead. GetClassTypeReference now supports nested types, where the Namespace/Name/TPC tripel isn't sufficient for identifying the type.")]
		public int TypeParameterCount => fullTypeName.TypeParameterCount;

		public GetClassTypeReference(FullTypeName fullTypeName, IAssemblyReference assembly = null)
		{
			this.fullTypeName = fullTypeName;
			this.assembly = assembly;
		}

		public GetClassTypeReference(string namespaceName, string name, int typeParameterCount = 0)
		{
			fullTypeName = new TopLevelTypeName(namespaceName, name, typeParameterCount);
		}

		public GetClassTypeReference(IAssemblyReference assembly, string namespaceName, string name, int typeParameterCount = 0)
		{
			this.assembly = assembly;
			fullTypeName = new TopLevelTypeName(namespaceName, name, typeParameterCount);
		}

		private IType ResolveInAllAssemblies(ITypeResolveContext context)
		{
			foreach (IAssembly assembly2 in context.Compilation.Assemblies)
			{
				IType typeDefinition = assembly2.GetTypeDefinition(fullTypeName);
				if (typeDefinition != null)
				{
					return typeDefinition;
				}
			}
			return null;
		}

		public IType Resolve(ITypeResolveContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			IType type = null;
			if (this.assembly == null)
			{
				if (context.CurrentAssembly != null)
				{
					type = context.CurrentAssembly.GetTypeDefinition(fullTypeName);
				}
				if (type == null)
				{
					type = ResolveInAllAssemblies(context);
				}
			}
			else
			{
				IAssembly assembly = this.assembly.Resolve(context);
				type = ((assembly == null) ? ResolveInAllAssemblies(context) : assembly.GetTypeDefinition(fullTypeName));
			}
			return type ?? new UnknownType(fullTypeName);
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			IType type = Resolve(context);
			if (type is ITypeDefinition)
			{
				return (ISymbol)type;
			}
			return null;
		}

		public override string ToString()
		{
			return fullTypeName.ToString() + ((assembly != null) ? (", " + assembly.ToString()) : null);
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return 33 * assembly.GetHashCode() + fullTypeName.GetHashCode();
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			GetClassTypeReference getClassTypeReference = other as GetClassTypeReference;
			if (getClassTypeReference != null && assembly == getClassTypeReference.assembly)
			{
				return fullTypeName == getClassTypeReference.fullTypeName;
			}
			return false;
		}
	}
}
