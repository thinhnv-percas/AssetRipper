using System;
using System.Text;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public readonly struct TopLevelTypeName : IEquatable<TopLevelTypeName>
{
	private readonly string namespaceName;

	private readonly string name;

	private readonly int typeParameterCount;

	public string Namespace => namespaceName;

	public string Name => name;

	public int TypeParameterCount => typeParameterCount;

	public string ReflectionName
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (!string.IsNullOrEmpty(namespaceName))
			{
				stringBuilder.Append(namespaceName);
				stringBuilder.Append('.');
			}
			stringBuilder.Append(name);
			if (typeParameterCount > 0)
			{
				stringBuilder.Append('`');
				stringBuilder.Append(typeParameterCount);
			}
			return stringBuilder.ToString();
		}
	}

	public TopLevelTypeName(string namespaceName, string name, int typeParameterCount = 0)
	{
		if (namespaceName == null)
		{
			throw new ArgumentNullException("namespaceName");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		this.namespaceName = namespaceName;
		this.name = name;
		this.typeParameterCount = typeParameterCount;
	}

	public TopLevelTypeName(string reflectionName)
	{
		int num = reflectionName.LastIndexOf('.');
		if (num < 0)
		{
			namespaceName = string.Empty;
			name = reflectionName;
		}
		else
		{
			namespaceName = reflectionName.Substring(0, num);
			name = reflectionName.Substring(checked(num + 1));
		}
		name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(name, out typeParameterCount);
	}

	public override string ToString()
	{
		return ReflectionName;
	}

	public override bool Equals(object obj)
	{
		return obj is TopLevelTypeName && Equals((TopLevelTypeName)obj);
	}

	public bool Equals(TopLevelTypeName other)
	{
		return namespaceName == other.namespaceName && name == other.name && typeParameterCount == other.typeParameterCount;
	}

	public override int GetHashCode()
	{
		return ((name != null) ? name.GetHashCode() : 0) ^ ((namespaceName != null) ? namespaceName.GetHashCode() : 0) ^ typeParameterCount;
	}

	public static bool operator ==(TopLevelTypeName lhs, TopLevelTypeName rhs)
	{
		return lhs.Equals(rhs);
	}

	public static bool operator !=(TopLevelTypeName lhs, TopLevelTypeName rhs)
	{
		return !lhs.Equals(rhs);
	}
}
