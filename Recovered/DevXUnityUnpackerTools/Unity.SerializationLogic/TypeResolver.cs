using Mono.Cecil;
using System;
using System.Collections.Generic;

namespace Unity.SerializationLogic
{
	public class TypeResolver
	{
		private int _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020;

		private readonly IGenericInstance _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A;

		private readonly IGenericInstance _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020;

		private readonly Dictionary<string, _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A> _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A = new Dictionary<string, _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A>();

		public TypeResolver()
		{
		}

		public TypeResolver(IGenericInstance typeDefinitionContext)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A = typeDefinitionContext;
		}

		public TypeResolver(GenericInstanceMethod methodDefinitionContext)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 = methodDefinitionContext;
		}

		public TypeResolver(IGenericInstance typeDefinitionContext, IGenericInstance methodDefinitionContext)
		{
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A = typeDefinitionContext;
			_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 = methodDefinitionContext;
		}

		public void Add(GenericInstanceType genericInstanceType)
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020(genericInstanceType).FullName, genericInstanceType);
		}

		public void Remove(GenericInstanceType genericInstanceType)
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020(genericInstanceType.ElementType.FullName, genericInstanceType);
		}

		public void Add(GenericInstanceMethod genericInstanceMethod)
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020(genericInstanceMethod).FullName, genericInstanceMethod);
		}

		private static MemberReference _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020(TypeSpecification _0020)
		{
			return _0020.ElementType;
		}

		private static MemberReference _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020(MethodSpecification _0020)
		{
			return _0020.ElementMethod;
		}

		public void Remove(GenericInstanceMethod genericInstanceMethod)
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020(genericInstanceMethod.ElementMethod.FullName, genericInstanceMethod);
		}

		public TypeReference Resolve(TypeReference typeReference)
		{
			if (_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 > 10)
			{
				return typeReference;
			}
			_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020++;
			try
			{
				GenericParameter genericParameter = typeReference as GenericParameter;
				if (genericParameter != null)
				{
					TypeReference typeReference2 = _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A(genericParameter);
					if (genericParameter == typeReference2)
					{
						return typeReference2;
					}
					return Resolve(typeReference2);
				}
				ArrayType arrayType = typeReference as ArrayType;
				if (arrayType != null)
				{
					return new ArrayType(Resolve(arrayType.ElementType), arrayType.Rank);
				}
				PointerType pointerType = typeReference as PointerType;
				if (pointerType != null)
				{
					return new PointerType(Resolve(pointerType.ElementType));
				}
				ByReferenceType byReferenceType = typeReference as ByReferenceType;
				if (byReferenceType != null)
				{
					return new ByReferenceType(Resolve(byReferenceType.ElementType));
				}
				GenericInstanceType genericInstanceType = typeReference as GenericInstanceType;
				if (genericInstanceType != null)
				{
					GenericInstanceType genericInstanceType2 = new GenericInstanceType(Resolve(genericInstanceType.ElementType));
					foreach (TypeReference genericArgument in genericInstanceType.GenericArguments)
					{
						genericInstanceType2.GenericArguments.Add(Resolve(genericArgument));
					}
					return genericInstanceType2;
				}
				PinnedType pinnedType = typeReference as PinnedType;
				if (pinnedType != null)
				{
					return new PinnedType(Resolve(pinnedType.ElementType));
				}
				RequiredModifierType requiredModifierType = typeReference as RequiredModifierType;
				if (requiredModifierType != null)
				{
					return Resolve(requiredModifierType.ElementType);
				}
				OptionalModifierType optionalModifierType = typeReference as OptionalModifierType;
				if (optionalModifierType != null)
				{
					return new OptionalModifierType(Resolve(optionalModifierType.ModifierType), Resolve(optionalModifierType.ElementType));
				}
				SentinelType sentinelType = typeReference as SentinelType;
				if (sentinelType != null)
				{
					return new SentinelType(Resolve(sentinelType.ElementType));
				}
				if (typeReference is FunctionPointerType)
				{
					throw new NotSupportedException("Function pointer types are not supported by the SerializationWeaver");
				}
				if (typeReference is TypeSpecification)
				{
					throw new NotSupportedException();
				}
				return typeReference;
			}
			finally
			{
				_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020--;
			}
		}

		private TypeReference _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A(GenericParameter _0020)
		{
			if (_0020.Owner == null)
			{
				throw new NotSupportedException();
			}
			MemberReference obj = _0020.Owner as MemberReference;
			if (obj == null)
			{
				throw new NotSupportedException();
			}
			string fullName = obj.FullName;
			if (!_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A.ContainsKey(fullName))
			{
				if (_0020.Type == GenericParameterType.Type)
				{
					if (_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A != null)
					{
						return _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A.GenericArguments[_0020.Position];
					}
					return _0020;
				}
				if (_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 != null)
				{
					return _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020.GenericArguments[_0020.Position];
				}
				return _0020;
			}
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020(fullName, _0020.Position);
		}

		private TypeReference _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020(string _0020, int _0020_000A)
		{
			return _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A[_0020].GenericInstance.GenericArguments[_0020_000A];
		}

		private void _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A(string _0020, IGenericInstance _0020_000A)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A.TryGetValue(_0020, out _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A value))
			{
				MemberReference memberReference = _0020_000A as MemberReference;
				if (memberReference == null)
				{
					throw new NotSupportedException();
				}
				if (((MemberReference)value.GenericInstance).FullName != memberReference.FullName)
				{
					throw new ArgumentException("Duplicate key!", "key");
				}
				value.Count++;
			}
			else
			{
				_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A.Add(_0020, new _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A
				{
					Count = 1,
					GenericInstance = _0020_000A
				});
			}
		}

		private void _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020(string _0020, IGenericInstance _0020_000A)
		{
			if (_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A.TryGetValue(_0020, out _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A value))
			{
				MemberReference memberReference = _0020_000A as MemberReference;
				if (memberReference == null)
				{
					throw new NotSupportedException();
				}
				if (((MemberReference)value.GenericInstance).FullName != memberReference.FullName)
				{
					throw new ArgumentException("Invalid value!", "value");
				}
				value.Count--;
				if (value.Count == 0)
				{
					_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A.Remove(_0020);
				}
				return;
			}
			throw new ArgumentException("Invalid key!", "key");
		}
	}
}
