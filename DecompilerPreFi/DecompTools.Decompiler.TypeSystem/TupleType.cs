#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem;

public sealed class TupleType : AbstractType, ICompilationProvider
{
	public const int RestPosition = 8;

	private const int RestIndex = 7;

	public ICompilation Compilation { get; }

	public ParameterizedType UnderlyingType { get; }

	public ImmutableArray<IType> ElementTypes { get; }

	public ImmutableArray<string> ElementNames { get; }

	public override TypeKind Kind => TypeKind.Tuple;

	public override bool? IsReferenceType => UnderlyingType.IsReferenceType;

	public override int TypeParameterCount => 0;

	public override IReadOnlyList<ITypeParameter> TypeParameters => EmptyList<ITypeParameter>.Instance;

	public override IReadOnlyList<IType> TypeArguments => EmptyList<IType>.Instance;

	public override IEnumerable<IType> DirectBaseTypes => UnderlyingType.DirectBaseTypes;

	public override string FullName => UnderlyingType.FullName;

	public override string Name => UnderlyingType.Name;

	public override string ReflectionName => UnderlyingType.ReflectionName;

	public override string Namespace => UnderlyingType.Namespace;

	public TupleType(ICompilation compilation, ImmutableArray<IType> elementTypes, ImmutableArray<string> elementNames = default(ImmutableArray<string>), IModule valueTupleAssembly = null)
	{
		Compilation = compilation;
		UnderlyingType = CreateUnderlyingType(compilation, elementTypes, valueTupleAssembly);
		ElementTypes = elementTypes;
		if (elementNames.IsDefault)
		{
			ElementNames = Enumerable.Repeat<string>((string)null, elementTypes.Length).ToImmutableArray();
			return;
		}
		Debug.Assert(elementNames.Length == elementTypes.Length);
		ElementNames = elementNames;
	}

	private static ParameterizedType CreateUnderlyingType(ICompilation compilation, ImmutableArray<IType> elementTypes, IModule valueTupleAssembly)
	{
		checked
		{
			int num = unchecked(checked(elementTypes.Length - 1) % 7) + 1;
			Debug.Assert(num >= 1 && num < 8);
			int num2 = elementTypes.Length - num;
			ParameterizedType parameterizedType = new ParameterizedType(FindValueTupleType(compilation, valueTupleAssembly, num), elementTypes.Slice(num2));
			while (num2 > 0)
			{
				num2 -= 7;
				parameterizedType = new ParameterizedType(FindValueTupleType(compilation, valueTupleAssembly, 8), Enumerable.Concat<IType>(elementTypes.Slice(num2, 7), (IEnumerable<IType>)new ParameterizedType[1] { parameterizedType }));
			}
			Debug.Assert(num2 == 0);
			return parameterizedType;
		}
	}

	private static IType FindValueTupleType(ICompilation compilation, IModule valueTupleAssembly, int tpc)
	{
		TopLevelTypeName topLevelTypeName = new TopLevelTypeName("System", "ValueTuple", tpc);
		if (valueTupleAssembly != null)
		{
			ITypeDefinition typeDefinition = valueTupleAssembly.GetTypeDefinition(topLevelTypeName);
			if (typeDefinition != null)
			{
				return typeDefinition;
			}
		}
		return compilation.FindType(topLevelTypeName);
	}

	public static bool IsTupleCompatible(IType type, out int tupleCardinality)
	{
		checked
		{
			switch (type.Kind)
			{
			case TypeKind.Tuple:
				tupleCardinality = ((TupleType)type).ElementTypes.Length;
				return true;
			case TypeKind.Class:
			case TypeKind.Struct:
				if (type.Namespace == "System" && type.Name == "ValueTuple")
				{
					int typeParameterCount = type.TypeParameterCount;
					if (typeParameterCount > 0 && typeParameterCount < 8)
					{
						tupleCardinality = typeParameterCount;
						return true;
					}
					if (typeParameterCount == 8 && type is ParameterizedType parameterizedType && IsTupleCompatible(parameterizedType.TypeArguments[7], out tupleCardinality))
					{
						tupleCardinality += 7;
						return true;
					}
				}
				break;
			}
			tupleCardinality = 0;
			return false;
		}
	}

	public static TupleType FromUnderlyingType(ICompilation compilation, IType type)
	{
		ImmutableArray<IType> tupleElementTypes = GetTupleElementTypes(type);
		if (tupleElementTypes.Length > 0)
		{
			return new TupleType(compilation, tupleElementTypes, default(ImmutableArray<string>), type.GetDefinition()?.ParentModule);
		}
		return null;
	}

	public static ImmutableArray<IType> GetTupleElementTypes(IType tupleType)
	{
		List<IType> output = null;
		if (Collect(tupleType))
		{
			return output.ToImmutableArray();
		}
		return default(ImmutableArray<IType>);
		bool Collect(IType type)
		{
			switch (type.Kind)
			{
			case TypeKind.Tuple:
				if (output == null)
				{
					output = new List<IType>();
				}
				output.AddRange(((TupleType)type).ElementTypes);
				return true;
			case TypeKind.Class:
			case TypeKind.Struct:
				if (type.Namespace == "System" && type.Name == "ValueTuple")
				{
					if (output == null)
					{
						output = new List<IType>();
					}
					int typeParameterCount = type.TypeParameterCount;
					if (typeParameterCount > 0 && typeParameterCount < 8)
					{
						output.AddRange(type.TypeArguments);
						return true;
					}
					if (typeParameterCount == 8)
					{
						output.AddRange(Enumerable.Take<IType>((IEnumerable<IType>)type.TypeArguments, 7));
						return Collect(type.TypeArguments[7]);
					}
				}
				break;
			}
			return false;
		}
	}

	public override bool Equals(IType other)
	{
		if (!(other is TupleType tupleType))
		{
			return false;
		}
		if (!UnderlyingType.Equals(tupleType.UnderlyingType))
		{
			return false;
		}
		return UnderlyingType.Equals(tupleType.UnderlyingType) && ElementNames.SequenceEqual(tupleType.ElementNames);
	}

	public override int GetHashCode()
	{
		int num = UnderlyingType.GetHashCode();
		foreach (string elementName in ElementNames)
		{
			num *= 31;
			num += elementName?.GetHashCode() ?? 0;
		}
		return num;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('(');
		for (int i = 0; i < ElementTypes.Length; i = checked(i + 1))
		{
			if (i > 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(ElementTypes[i]);
			if (ElementNames[i] != null)
			{
				stringBuilder.Append(' ');
				stringBuilder.Append(ElementNames[i]);
			}
		}
		stringBuilder.Append(')');
		return stringBuilder.ToString();
	}

	public override IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitTupleType(this);
	}

	public override IType VisitChildren(TypeVisitor visitor)
	{
		IType[] array = null;
		for (int i = 0; i < ElementTypes.Length; i = checked(i + 1))
		{
			IType type = ElementTypes[i];
			IType type2 = type.AcceptVisitor(visitor);
			if (type2 != type)
			{
				if (array == null)
				{
					array = ElementTypes.ToArray();
				}
				array[i] = type2;
			}
		}
		if (array != null)
		{
			return new TupleType(Compilation, array.ToImmutableArray(), ElementNames, GetDefinition()?.ParentModule);
		}
		return this;
	}

	public override IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetAccessors(filter, options);
	}

	public override IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
	{
		return EmptyList<IMethod>.Instance;
	}

	public override ITypeDefinition GetDefinition()
	{
		return UnderlyingType.GetDefinition();
	}

	public override IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetEvents(filter, options);
	}

	public override IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		foreach (IField field in UnderlyingType.GetFields(filter, options))
		{
			yield return field;
		}
	}

	public override IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetMethods(filter, options);
	}

	public override IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetMethods(typeArguments, filter, options);
	}

	public override IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetNestedTypes(filter, options);
	}

	public override IEnumerable<IType> GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetNestedTypes(typeArguments, filter, options);
	}

	public override IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		return UnderlyingType.GetProperties(filter, options);
	}
}
