using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.CecilTools.Extensions;

namespace Unity.CecilTools
{
	public class CecilUtils
	{
		[CompilerGenerated]
		internal sealed class _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020
		{
			public MethodDefinition _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020;

			public Func<MethodReference, bool> _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A;

			internal bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020(MethodDefinition _0020)
			{
				return _0020.Overrides.Any(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A);
			}

			internal bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A(MethodReference _0020)
			{
				return _0020.CheckedResolve().SameAs(_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020);
			}
		}

		[Serializable]
		[CompilerGenerated]
		internal sealed class _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A
		{
			public static readonly _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A();

			public static Func<TypeDefinition, IEnumerable<TypeReference>> _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A;

			public static Func<TypeReference, TypeDefinition> _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020;

			internal IEnumerable<TypeReference> _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A(TypeDefinition _0020)
			{
				return _0020.Interfaces;
			}

			internal TypeDefinition _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020(TypeReference _0020)
			{
				return _0020.CheckedResolve();
			}
		}

		public static MethodDefinition FindInTypeExplicitImplementationFor(MethodDefinition interfaceMethod, TypeDefinition typeDefinition)
		{
			_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020 _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020 = new _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020();
			_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020._0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 = interfaceMethod;
			return typeDefinition.Methods.SingleOrDefault(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020);
		}

		public static IEnumerable<TypeDefinition> AllInterfacesImplementedBy(TypeDefinition typeDefinition)
		{
			return TypeAndBaseTypesOf(typeDefinition).SelectMany(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A).Select(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020).Distinct();
		}

		public static IEnumerable<TypeDefinition> TypeAndBaseTypesOf(TypeReference typeReference)
		{
			while (typeReference != null)
			{
				TypeDefinition typeDefinition = typeReference.CheckedResolve();
				yield return typeDefinition;
				typeReference = typeDefinition.BaseType;
			}
		}

		public static IEnumerable<TypeDefinition> BaseTypesOf(TypeReference typeReference)
		{
			return TypeAndBaseTypesOf(typeReference).Skip(1);
		}

		public static bool IsGenericList(TypeReference type)
		{
			if (type.Name == "List`1")
			{
				return type.SafeNamespace() == "System.Collections.Generic";
			}
			return false;
		}

		public static bool IsGenericDictionary(TypeReference type)
		{
			if (type is GenericInstanceType)
			{
				type = ((GenericInstanceType)type).ElementType;
			}
			if (type.Name == "Dictionary`2")
			{
				return type.SafeNamespace() == "System.Collections.Generic";
			}
			return false;
		}

		public static TypeReference ElementTypeOfCollection(TypeReference type)
		{
			ArrayType arrayType = type as ArrayType;
			if (arrayType != null)
			{
				return arrayType.ElementType;
			}
			if (IsGenericList(type))
			{
				return ((GenericInstanceType)type).GenericArguments.Single();
			}
			throw new ArgumentException();
		}
	}
}
