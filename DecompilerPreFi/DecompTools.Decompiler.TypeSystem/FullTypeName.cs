using System;
using System.Text;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public readonly struct FullTypeName : IEquatable<FullTypeName>
{
	[Serializable]
	private readonly struct NestedTypeName
	{
		public readonly string Name;

		public readonly int AdditionalTypeParameterCount;

		public NestedTypeName(string name, int additionalTypeParameterCount)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			Name = name;
			AdditionalTypeParameterCount = additionalTypeParameterCount;
		}
	}

	private readonly TopLevelTypeName topLevelType;

	private readonly NestedTypeName[] nestedTypes;

	public TopLevelTypeName TopLevelTypeName => topLevelType;

	public bool IsNested => nestedTypes != null;

	public int NestingLevel => (nestedTypes != null) ? nestedTypes.Length : 0;

	public string Name
	{
		get
		{
			if (nestedTypes != null)
			{
				return nestedTypes[checked(nestedTypes.Length - 1)].Name;
			}
			return topLevelType.Name;
		}
	}

	public string ReflectionName
	{
		get
		{
			if (nestedTypes == null)
			{
				return topLevelType.ReflectionName;
			}
			StringBuilder stringBuilder = new StringBuilder(topLevelType.ReflectionName);
			NestedTypeName[] array = nestedTypes;
			for (int i = 0; i < array.Length; i++)
			{
				NestedTypeName nestedTypeName = array[i];
				stringBuilder.Append('+');
				stringBuilder.Append(nestedTypeName.Name);
				if (nestedTypeName.AdditionalTypeParameterCount > 0)
				{
					stringBuilder.Append('`');
					stringBuilder.Append(nestedTypeName.AdditionalTypeParameterCount);
				}
			}
			return stringBuilder.ToString();
		}
	}

	public int TypeParameterCount
	{
		get
		{
			int num = topLevelType.TypeParameterCount;
			if (nestedTypes != null)
			{
				NestedTypeName[] array = nestedTypes;
				for (int i = 0; i < array.Length; i++)
				{
					NestedTypeName nestedTypeName = array[i];
					num = checked(num + nestedTypeName.AdditionalTypeParameterCount);
				}
			}
			return num;
		}
	}

	private FullTypeName(TopLevelTypeName topLevelTypeName, NestedTypeName[] nestedTypes)
	{
		topLevelType = topLevelTypeName;
		this.nestedTypes = nestedTypes;
	}

	public FullTypeName(TopLevelTypeName topLevelTypeName)
	{
		topLevelType = topLevelTypeName;
		nestedTypes = null;
	}

	public FullTypeName(string reflectionName)
	{
		int num = reflectionName.IndexOf('+');
		if (num < 0)
		{
			topLevelType = new TopLevelTypeName(reflectionName);
			nestedTypes = null;
			return;
		}
		string[] array = reflectionName.Split(new char[1] { '+' });
		topLevelType = new TopLevelTypeName(array[0]);
		checked
		{
			nestedTypes = new NestedTypeName[array.Length - 1];
			for (int i = 0; i < nestedTypes.Length; i++)
			{
				string name = ReflectionHelper.SplitTypeParameterCountFromReflectionName(array[i + 1], out var typeParameterCount);
				nestedTypes[i] = new NestedTypeName(name, typeParameterCount);
			}
		}
	}

	public string GetNestedTypeName(int nestingLevel)
	{
		if (nestedTypes == null)
		{
			throw new InvalidOperationException();
		}
		return nestedTypes[nestingLevel].Name;
	}

	public int GetNestedTypeAdditionalTypeParameterCount(int nestingLevel)
	{
		if (nestedTypes == null)
		{
			throw new InvalidOperationException();
		}
		return nestedTypes[nestingLevel].AdditionalTypeParameterCount;
	}

	public FullTypeName GetDeclaringType()
	{
		if (nestedTypes == null)
		{
			throw new InvalidOperationException();
		}
		if (nestedTypes.Length == 1)
		{
			return topLevelType;
		}
		NestedTypeName[] array = new NestedTypeName[checked(nestedTypes.Length - 1)];
		Array.Copy(nestedTypes, 0, array, 0, array.Length);
		return new FullTypeName(topLevelType, array);
	}

	public FullTypeName NestedType(string name, int additionalTypeParameterCount)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		NestedTypeName nestedTypeName = new NestedTypeName(name, additionalTypeParameterCount);
		if (nestedTypes == null)
		{
			return new FullTypeName(topLevelType, new NestedTypeName[1] { nestedTypeName });
		}
		checked
		{
			NestedTypeName[] array = new NestedTypeName[nestedTypes.Length + 1];
			nestedTypes.CopyTo(array, 0);
			array[array.Length - 1] = nestedTypeName;
			return new FullTypeName(topLevelType, array);
		}
	}

	public static implicit operator FullTypeName(TopLevelTypeName topLevelTypeName)
	{
		return new FullTypeName(topLevelTypeName);
	}

	public override string ToString()
	{
		return ReflectionName;
	}

	public override bool Equals(object obj)
	{
		return obj is FullTypeName && Equals((FullTypeName)obj);
	}

	public bool Equals(FullTypeName other)
	{
		return FullTypeNameComparer.Ordinal.Equals(this, other);
	}

	public override int GetHashCode()
	{
		return FullTypeNameComparer.Ordinal.GetHashCode(this);
	}

	public static bool operator ==(FullTypeName left, FullTypeName right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(FullTypeName left, FullTypeName right)
	{
		return !left.Equals(right);
	}
}
