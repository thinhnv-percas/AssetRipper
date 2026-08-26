using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public class UnknownType : AbstractType, ITypeReference
	{
		private readonly bool namespaceKnown;

		private readonly FullTypeName fullTypeName;

		public override TypeKind Kind => TypeKind.Unknown;

		public override string Name => fullTypeName.Name;

		public override string Namespace => fullTypeName.TopLevelTypeName.Namespace;

		public override string ReflectionName
		{
			get
			{
				if (!namespaceKnown)
				{
					return "?";
				}
				return fullTypeName.ReflectionName;
			}
		}

		public override int TypeParameterCount => fullTypeName.TypeParameterCount;

		public override bool? IsReferenceType => null;

		public UnknownType(string namespaceName, string name, int typeParameterCount = 0)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			namespaceKnown = (namespaceName != null);
			fullTypeName = new TopLevelTypeName(namespaceName ?? string.Empty, name, typeParameterCount);
		}

		public UnknownType(FullTypeName fullTypeName)
		{
			if (fullTypeName.Name == null)
			{
				namespaceKnown = false;
				this.fullTypeName = new TopLevelTypeName(string.Empty, "?");
			}
			else
			{
				namespaceKnown = true;
				this.fullTypeName = fullTypeName;
			}
		}

		public override ITypeReference ToTypeReference()
		{
			return this;
		}

		IType ITypeReference.Resolve(ITypeResolveContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			return this;
		}

		public override int GetHashCode()
		{
			return (namespaceKnown ? 812571 : 12651) ^ fullTypeName.GetHashCode();
		}

		public override bool Equals(IType other)
		{
			UnknownType unknownType = other as UnknownType;
			if (unknownType == null)
			{
				return false;
			}
			if (namespaceKnown == unknownType.namespaceKnown)
			{
				return fullTypeName == unknownType.fullTypeName;
			}
			return false;
		}

		public override string ToString()
		{
			return "[UnknownType " + fullTypeName.ReflectionName + "]";
		}
	}
}
