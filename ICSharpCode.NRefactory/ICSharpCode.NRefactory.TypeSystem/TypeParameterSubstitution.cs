using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem;

public class TypeParameterSubstitution : TypeVisitor
{
	public static readonly TypeParameterSubstitution Identity = new TypeParameterSubstitution(null, null);

	private readonly IList<IType> classTypeArguments;

	private readonly IList<IType> methodTypeArguments;

	public IList<IType> ClassTypeArguments => classTypeArguments;

	public IList<IType> MethodTypeArguments => methodTypeArguments;

	public TypeParameterSubstitution(IList<IType> classTypeArguments, IList<IType> methodTypeArguments)
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
		IList<IType> list = ((f.classTypeArguments != null) ? GetComposedTypeArguments(f.classTypeArguments, g) : g.classTypeArguments);
		IList<IType> list2 = ((f.methodTypeArguments != null) ? GetComposedTypeArguments(f.methodTypeArguments, g) : g.methodTypeArguments);
		return new TypeParameterSubstitution(list, list2);
	}

	private static IList<IType> GetComposedTypeArguments(IList<IType> input, TypeParameterSubstitution substitution)
	{
		IType[] array = new IType[input.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = input[i].AcceptVisitor(substitution);
		}
		return array;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TypeParameterSubstitution typeParameterSubstitution))
		{
			return false;
		}
		if (TypeListEquals(classTypeArguments, typeParameterSubstitution.classTypeArguments))
		{
			return TypeListEquals(methodTypeArguments, typeParameterSubstitution.methodTypeArguments);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return 1124131 * TypeListHashCode(classTypeArguments) + 1821779 * TypeListHashCode(methodTypeArguments);
	}

	private static bool TypeListEquals(IList<IType> a, IList<IType> b)
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
		for (int i = 0; i < a.Count; i++)
		{
			if (!a[i].Equals(b[i]))
			{
				return false;
			}
		}
		return true;
	}

	private static int TypeListHashCode(IList<IType> obj)
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
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}
}
