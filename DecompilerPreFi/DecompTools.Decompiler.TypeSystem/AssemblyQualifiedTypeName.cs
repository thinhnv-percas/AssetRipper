using System;

namespace DecompTools.Decompiler.TypeSystem;

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
		AssemblyName = typeDefinition.ParentModule.AssemblyName;
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
		return obj is AssemblyQualifiedTypeName && Equals((AssemblyQualifiedTypeName)obj);
	}

	public bool Equals(AssemblyQualifiedTypeName other)
	{
		return AssemblyName == other.AssemblyName && TypeName == other.TypeName;
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
