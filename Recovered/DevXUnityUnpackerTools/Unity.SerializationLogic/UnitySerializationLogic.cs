using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.CecilTools;
using Unity.CecilTools.Extensions;

namespace Unity.SerializationLogic
{
	public static class UnitySerializationLogic
	{
		[CompilerGenerated]
		private sealed class _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A
		{
			public TypeDefinition _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;

			internal bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A(KeyValuePair<FieldDefinition, TypeResolver> _0020)
			{
				return _0020.Value.Resolve(_0020.Key.FieldType).Resolve() != _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;
			}

			internal bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(KeyValuePair<FieldDefinition, TypeResolver> _0020)
			{
				return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A, _0020.Key, _0020.Value);
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020
		{
			public static readonly _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020 _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020();

			public static Func<CustomAttribute, TypeReference> _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020;

			public static Func<CustomAttribute, bool> _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A;

			public static Func<CustomAttribute, bool> _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020;

			internal TypeReference _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A(CustomAttribute _0020)
			{
				return _0020.AttributeType;
			}

			internal bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020(CustomAttribute _0020)
			{
				return _0020.AttributeType.FullName == "System.Runtime.CompilerServices.FixedBufferAttribute";
			}

			internal bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A(CustomAttribute _0020)
			{
				return _0020.AttributeType.FullName.Contains("System.Runtime.CompilerServices.CompilerGenerated");
			}
		}

		public static bool WillUnitySerialize(FieldDefinition fieldDefinition)
		{
			return WillUnitySerialize(fieldDefinition, new TypeResolver(null));
		}

		public static bool WillUnitySerialize(FieldDefinition fieldDefinition, TypeResolver typeResolver)
		{
			if (fieldDefinition == null)
			{
				return false;
			}
			if (fieldDefinition.IsStatic || _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020(fieldDefinition) || fieldDefinition.IsNotSerialized || fieldDefinition.IsInitOnly)
			{
				return false;
			}
			if (ShouldNotTryToResolve(fieldDefinition.FieldType))
			{
				return false;
			}
			bool flag = HasSerializeFieldAttribute(fieldDefinition);
			if (!fieldDefinition.IsPublic && !flag && !_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020(fieldDefinition))
			{
				return false;
			}
			if (fieldDefinition.FullName == "UnityScript.Lang.Array")
			{
				return false;
			}
			if (!_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(typeResolver.Resolve(fieldDefinition.FieldType), fieldDefinition))
			{
				return false;
			}
			if (_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(typeResolver.Resolve(fieldDefinition.FieldType)))
			{
				return false;
			}
			return true;
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A(TypeReference _0020)
		{
			return _0020.IsAssignableTo("System.Delegate");
		}

		public static bool ShouldFieldBePPtrRemapped(FieldDefinition fieldDefinition)
		{
			return ShouldFieldBePPtrRemapped(fieldDefinition, new TypeResolver(null));
		}

		public static bool ShouldFieldBePPtrRemapped(FieldDefinition fieldDefinition, TypeResolver typeResolver)
		{
			if (!WillUnitySerialize(fieldDefinition, typeResolver))
			{
				return false;
			}
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(typeResolver.Resolve(fieldDefinition.FieldType));
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(TypeReference _0020)
		{
			if (_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(_0020))
			{
				return true;
			}
			if (_0020.IsEnum())
			{
				return false;
			}
			if (_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A(_0020))
			{
				return false;
			}
			if (IsSupportedCollection(_0020))
			{
				return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(CecilUtils.ElementTypeOfCollection(_0020));
			}
			TypeDefinition typeDefinition = _0020.Resolve();
			if (typeDefinition == null)
			{
				return false;
			}
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(typeDefinition, new TypeResolver(_0020 as GenericInstanceType));
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(TypeDefinition _0020, TypeResolver _0020_000A)
		{
			_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A = new _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A();
			_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A = _0020;
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A, _0020_000A).Where(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A).Any(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020);
		}

		private static IEnumerable<KeyValuePair<FieldDefinition, TypeResolver>> _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020(TypeDefinition _0020, TypeResolver _0020_000A)
		{
			TypeReference baseType = _0020.BaseType;
			if (baseType != null)
			{
				GenericInstanceType genericInstanceType = baseType as GenericInstanceType;
				if (genericInstanceType != null)
				{
					_0020_000A.Add(genericInstanceType);
				}
				foreach (KeyValuePair<FieldDefinition, TypeResolver> item in _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020(baseType.Resolve(), _0020_000A))
				{
					yield return item;
				}
				if (genericInstanceType != null)
				{
					_0020_000A.Remove(genericInstanceType);
				}
			}
			foreach (FieldDefinition field in _0020.Fields)
			{
				yield return new KeyValuePair<FieldDefinition, TypeResolver>(field, _0020_000A);
			}
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(TypeReference _0020, FieldDefinition _0020_000A, TypeResolver _0020_0020)
		{
			if (_0020_0020.Resolve(_0020_000A.FieldType) == _0020)
			{
				return false;
			}
			if (!WillUnitySerialize(_0020_000A, _0020_0020))
			{
				return false;
			}
			if (UnityEngineTypePredicates.IsUnityEngineValueType(_0020))
			{
				return false;
			}
			return true;
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020(FieldDefinition _0020)
		{
			if (_0020.IsLiteral)
			{
				return !_0020.IsInitOnly;
			}
			return false;
		}

		public static bool HasSerializeFieldAttribute(FieldDefinition field)
		{
			foreach (TypeReference item in _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A(field))
			{
				if (UnityEngineTypePredicates.IsSerializeFieldAttribute(item))
				{
					return true;
				}
			}
			return false;
		}

		private static IEnumerable<TypeReference> _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A(FieldDefinition _0020)
		{
			return _0020.CustomAttributes.Select(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A);
		}

		public static bool ShouldNotTryToResolve(TypeReference typeReference)
		{
			if (typeReference.Scope.Name == "Windows")
			{
				return true;
			}
			if (typeReference.Scope.Name == "mscorlib")
			{
				return typeReference.Resolve() == null;
			}
			try
			{
				typeReference.Resolve();
			}
			catch
			{
				return true;
			}
			return false;
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020(TypeReference _0020, FieldDefinition _0020_000A)
		{
			if (!_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A(_0020) && !IsSupportedCollection(_0020))
			{
				return IsFixedBuffer(_0020_000A);
			}
			return true;
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A(TypeReference _0020)
		{
			if (_0020.IsAssignableTo("UnityScript.Lang.Array"))
			{
				return false;
			}
			if (_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(_0020))
			{
				return false;
			}
			if (!_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A(_0020) && !_0020.IsEnum() && !_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(_0020) && !UnityEngineTypePredicates.IsSerializableUnityStruct(_0020))
			{
				return ShouldImplementIDeserializable(_0020);
			}
			return true;
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(TypeReference _0020)
		{
			if (_0020 != null && CecilUtils.IsGenericDictionary(_0020))
			{
				return true;
			}
			return false;
		}

		public static bool IsFixedBuffer(FieldDefinition fieldDefinition)
		{
			return GetFixedBufferAttribute(fieldDefinition) != null;
		}

		public static CustomAttribute GetFixedBufferAttribute(FieldDefinition fieldDefinition)
		{
			if (!fieldDefinition.HasCustomAttributes)
			{
				return null;
			}
			return fieldDefinition.CustomAttributes.SingleOrDefault(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020);
		}

		public static int GetFixedBufferLength(FieldDefinition fieldDefinition)
		{
			CustomAttribute fixedBufferAttribute = GetFixedBufferAttribute(fieldDefinition);
			if (fixedBufferAttribute == null)
			{
				throw new ArgumentException($"Field '{fieldDefinition.FullName}' is not a fixed buffer field.");
			}
			return (int)fixedBufferAttribute.ConstructorArguments[1].Value;
		}

		public static int PrimitiveTypeSize(TypeReference type)
		{
			switch (type.MetadataType)
			{
			case MetadataType.Boolean:
			case MetadataType.SByte:
			case MetadataType.Byte:
				return 1;
			case MetadataType.Char:
			case MetadataType.Int16:
			case MetadataType.UInt16:
				return 2;
			case MetadataType.Int32:
			case MetadataType.UInt32:
			case MetadataType.Single:
				return 4;
			case MetadataType.Int64:
			case MetadataType.UInt64:
			case MetadataType.Double:
				return 8;
			default:
				throw new ArgumentException($"Unsupported {type.MetadataType}");
			}
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A(TypeReference _0020)
		{
			MetadataType metadataType = _0020.MetadataType;
			if (metadataType - 2 <= MetadataType.Single)
			{
				return true;
			}
			return false;
		}

		public static bool IsSupportedCollection(TypeReference typeReference)
		{
			if (!(typeReference is ArrayType) && !CecilUtils.IsGenericList(typeReference))
			{
				return false;
			}
			if (typeReference.IsArray && ((ArrayType)typeReference).Rank > 1)
			{
				return false;
			}
			return _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A(CecilUtils.ElementTypeOfCollection(typeReference));
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020(FieldDefinition _0020)
		{
			return UnityEngineTypePredicates.IsUnityEngineValueType(_0020.DeclaringType);
		}

		private static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A(TypeReference _0020)
		{
			return UnityEngineTypePredicates.IsUnityEngineObject(_0020);
		}

		public static bool IsNonSerialized(TypeReference typeDeclaration)
		{
			if (typeDeclaration == null)
			{
				return true;
			}
			if (typeDeclaration.IsEnum())
			{
				return true;
			}
			if (typeDeclaration.HasGenericParameters)
			{
				return true;
			}
			if (typeDeclaration.MetadataType == MetadataType.Object)
			{
				return true;
			}
			if (typeDeclaration.FullName.StartsWith("System."))
			{
				return true;
			}
			if (typeDeclaration.IsArray)
			{
				return true;
			}
			if (typeDeclaration.FullName == "UnityEngine.MonoBehaviour")
			{
				return true;
			}
			if (typeDeclaration.FullName == "UnityEngine.ScriptableObject")
			{
				return true;
			}
			return false;
		}

		public static bool ShouldImplementIDeserializable(TypeReference typeDeclaration)
		{
			if (typeDeclaration.FullName == "UnityEngine.ExposedReference`1")
			{
				return true;
			}
			if (IsNonSerialized(typeDeclaration))
			{
				return false;
			}
			GenericInstanceType genericInstanceType = typeDeclaration as GenericInstanceType;
			if (genericInstanceType != null)
			{
				if (genericInstanceType.ElementType.FullName == "UnityEngine.ExposedReference`1")
				{
					return true;
				}
				return false;
			}
			try
			{
				return UnityEngineTypePredicates.IsMonoBehaviour(typeDeclaration) || UnityEngineTypePredicates.IsScriptableObject(typeDeclaration) || (typeDeclaration.CheckedResolve().IsSerializable && !typeDeclaration.CheckedResolve().IsAbstract && !typeDeclaration.CheckedResolve().CustomAttributes.Any(_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A)) || UnityEngineTypePredicates.ShouldHaveHadSerializableAttribute(typeDeclaration);
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
