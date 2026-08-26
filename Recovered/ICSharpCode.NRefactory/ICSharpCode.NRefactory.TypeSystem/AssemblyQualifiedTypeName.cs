using System;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public struct AssemblyQualifiedTypeName : IEquatable<AssemblyQualifiedTypeName>
	{
		public readonly string AssemblyName;

		public readonly FullTypeName TypeName;

		public AssemblyQualifiedTypeName(FullTypeName typeName, string assemblyName)
		{
			AssemblyName = assemblyName;
			TypeName = typeName;
		}

		public AssemblyQualifiedTypeName(ITypeDefinition typeDefinition)
		{
			AssemblyName = typeDefinition.ParentAssembly.AssemblyName;
			TypeName = typeDefinition.FullTypeName;
		}

		public override string ToString()
		{
			if (string.IsNullOrEmpty(AssemblyName))
			{
				return TypeName.ToString();
			}
			return TypeName.ToString() + ", " + AssemblyName;
		}

		public override bool Equals(object obj)
		{
			if (obj is AssemblyQualifiedTypeName)
			{
				return Equals((AssemblyQualifiedTypeName)obj);
			}
			return false;
		}

		public bool Equals(AssemblyQualifiedTypeName other)
		{
			if (AssemblyName == other.AssemblyName)
			{
				return TypeName == other.TypeName;
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 0;
			if (AssemblyName != null)
			{
				num += 1000000007 * AssemblyName.GetHashCode();
			}
			return num + TypeName.GetHashCode();
		}

		public static bool operator ==(AssemblyQualifiedTypeName lhs, AssemblyQualifiedTypeName rhs)
		{
			return lhs.Equals(rhs);
		}

		public static bool operator !=(AssemblyQualifiedTypeName lhs, AssemblyQualifiedTypeName rhs)
		{
			return !lhs.Equals(rhs);
		}
	}
}
