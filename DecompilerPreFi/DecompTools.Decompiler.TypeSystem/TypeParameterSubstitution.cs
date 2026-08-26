using System.Collections.Generic;
using System.Text;

namespace DecompTools.Decompiler.TypeSystem;

public class TypeParameterSubstitution : TypeVisitor
{
	public static readonly TypeParameterSubstitution Identity = new TypeParameterSubstitution(null, null);

	private readonly IReadOnlyList<IType> classTypeArguments;

	private readonly IReadOnlyList<IType> methodTypeArguments;

	public IReadOnlyList<IType> ClassTypeArguments => classTypeArguments;

	public IReadOnlyList<IType> MethodTypeArguments => methodTypeArguments;

	public TypeParameterSubstitution(IReadOnlyList<IType> classTypeArguments, IReadOnlyList<IType> methodTypeArguments)
	{
		this.classTypeArguments = classTypeArguments;
		this.methodTypeArguments = methodTypeArguments;
	}

	public static TypeParameterSubstitution Compose(TypeParameterSubstitution g, TypeParameterSubstitution f)
	{
		if (g == null)
		{
			return f;
		}
		if (f == null || (f.classTypeArguments == null && f.methodTypeArguments == null))
		{
			return g;
		}
		IReadOnlyList<IType> readOnlyList = ((f.classTypeArguments != null) ? GetComposedTypeArguments(f.classTypeArguments, g) : g.classTypeArguments);
		IReadOnlyList<IType> readOnlyList2 = ((f.methodTypeArguments != null) ? GetComposedTypeArguments(f.methodTypeArguments, g) : g.methodTypeArguments);
		return new TypeParameterSubstitution(readOnlyList, readOnlyList2);
	}

	private static IReadOnlyList<IType> GetComposedTypeArguments(IReadOnlyList<IType> input, TypeParameterSubstitution substitution)
	{
		IType[] array = new IType[input.Count];
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			array[i] = input[i].AcceptVisitor(substitution);
		}
		return array;
	}

	public bool Equals(TypeParameterSubstitution other, TypeVisitor normalization)
	{
		if (other == null)
		{
			return false;
		}
		return TypeListEquals(classTypeArguments, other.classTypeArguments, normalization) && TypeListEquals(methodTypeArguments, other.methodTypeArguments, normalization);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TypeParameterSubstitution typeParameterSubstitution))
		{
			return false;
		}
		return TypeListEquals(classTypeArguments, typeParameterSubstitution.classTypeArguments) && TypeListEquals(methodTypeArguments, typeParameterSubstitution.methodTypeArguments);
	}

	public override int GetHashCode()
	{
		return 1124131 * TypeListHashCode(classTypeArguments) + 1821779 * TypeListHashCode(methodTypeArguments);
	}

	private static bool TypeListEquals(IReadOnlyList<IType> a, IReadOnlyList<IType> b)
	{
		if (a == b)
		{
			return true;
		}
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Count != b.Count)
		{
			return false;
		}
		for (int i = 0; i < a.Count; i = checked(i + 1))
		{
			if (!a[i].Equals(b[i]))
			{
				return false;
			}
		}
		return true;
	}

	private static bool TypeListEquals(IReadOnlyList<IType> a, IReadOnlyList<IType> b, TypeVisitor normalization)
	{
		if (a == b)
		{
			return true;
		}
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Count != b.Count)
		{
			return false;
		}
		for (int i = 0; i < a.Count; i = checked(i + 1))
		{
			IType type = a[i].AcceptVisitor(normalization);
			IType other = b[i].AcceptVisitor(normalization);
			if (!type.Equals(other))
			{
				return false;
			}
		}
		return true;
	}

	private static int TypeListHashCode(IReadOnlyList<IType> obj)
	{
		if (obj == null)
		{
			return 0;
		}
		int num = 1;
		foreach (IType item in obj)
		{
			num *= 27;
			num += item.GetHashCode();
		}
		return num;
	}

	public override IType VisitTypeParameter(ITypeParameter type)
	{
		int index = type.Index;
		if (classTypeArguments != null && type.OwnerType == SymbolKind.TypeDefinition)
		{
			if (index >= 0 && index < classTypeArguments.Count)
			{
				return classTypeArguments[index];
			}
			return SpecialType.UnknownType;
		}
		if (methodTypeArguments != null && type.OwnerType == SymbolKind.Method)
		{
			if (index >= 0 && index < methodTypeArguments.Count)
			{
				return methodTypeArguments[index];
			}
			return SpecialType.UnknownType;
		}
		return base.VisitTypeParameter(type);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('[');
		bool flag = true;
		checked
		{
			if (classTypeArguments != null)
			{
				for (int i = 0; i < classTypeArguments.Count; i++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append('`');
					stringBuilder.Append(i);
					stringBuilder.Append(" -> ");
					stringBuilder.Append(classTypeArguments[i].ReflectionName);
				}
				if (classTypeArguments.Count == 0)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append("[]");
				}
			}
			if (methodTypeArguments != null)
			{
				for (int j = 0; j < methodTypeArguments.Count; j++)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append("``");
					stringBuilder.Append(j);
					stringBuilder.Append(" -> ");
					stringBuilder.Append(methodTypeArguments[j].ReflectionName);
				}
				if (methodTypeArguments.Count == 0)
				{
					if (flag)
					{
						flag = false;
					}
					else
					{
						stringBuilder.Append(", ");
					}
					stringBuilder.Append("[]");
				}
			}
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
	}
}
