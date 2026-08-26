using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class LazyMetadataWrapper : ExportProvider.IMetadataDictionary, IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>
{
	internal enum Direction
	{
		ToSubstitutedValue,
		ToOriginalValue
	}

	internal interface ISubstitutedValue
	{
		object ActualValue { get; }
	}

	internal class Enum32Substitution : ISubstitutedValue, IEquatable<Enum32Substitution>
	{
		public object ActualValue => Enum.ToObject(EnumType.Resolve(), RawValue);

		internal TypeRef EnumType { get; private set; }

		internal int RawValue { get; private set; }

		internal Enum32Substitution(TypeRef enumType, int rawValue)
		{
			Requires.NotNull(enumType, "enumType");
			EnumType = enumType;
			RawValue = rawValue;
		}

		internal static bool TrySubstituteValue(object value, Resolver resolver, out ISubstitutedValue substitutedValue)
		{
			Requires.NotNull(resolver, "resolver");
			if (value != null)
			{
				Type type = value.GetType();
				if (type.GetTypeInfo().IsEnum && Enum.GetUnderlyingType(type) == typeof(int) && IsTypeWorthDeferring(type))
				{
					substitutedValue = new Enum32Substitution(TypeRef.Get(type, resolver), (int)value);
					return true;
				}
			}
			substitutedValue = null;
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is Enum32Substitution)
			{
				return Equals((Enum32Substitution)obj);
			}
			if (TrySubstituteValue(obj, EnumType.Resolver, out var substitutedValue))
			{
				return Equals((Enum32Substitution)substitutedValue);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return EnumType.GetHashCode() ^ RawValue;
		}

		public bool Equals(Enum32Substitution other)
		{
			if (other == null)
			{
				return false;
			}
			if (EnumType.Equals(other.EnumType))
			{
				return RawValue == other.RawValue;
			}
			return false;
		}
	}

	internal class TypeSubstitution : ISubstitutedValue, IEquatable<TypeSubstitution>
	{
		internal TypeRef TypeRef { get; private set; }

		public object ActualValue => TypeRef.Resolve();

		internal TypeSubstitution(TypeRef typeRef)
		{
			Requires.NotNull(typeRef, "typeRef");
			TypeRef = typeRef;
		}

		internal static bool TrySubstituteValue(object value, Resolver resolver, out ISubstitutedValue substitutedValue)
		{
			if (value is Type)
			{
				substitutedValue = new TypeSubstitution(TypeRef.Get((Type)value, resolver));
				return true;
			}
			substitutedValue = null;
			return false;
		}

		public override int GetHashCode()
		{
			return TypeRef.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is TypeSubstitution)
			{
				return Equals((TypeSubstitution)obj);
			}
			if (TrySubstituteValue(obj, TypeRef.Resolver, out var substitutedValue))
			{
				return Equals((TypeSubstitution)substitutedValue);
			}
			return false;
		}

		public bool Equals(TypeSubstitution other)
		{
			if (other == null)
			{
				return false;
			}
			return TypeRef.Equals(other.TypeRef);
		}
	}

	internal class TypeArraySubstitution : ISubstitutedValue, IEquatable<TypeArraySubstitution>
	{
		private readonly Resolver resolver;

		internal IReadOnlyList<TypeRef> TypeRefArray { get; private set; }

		public object ActualValue => TypeRefArray.Select(ResolverExtensions.Resolve).ToArray();

		internal TypeArraySubstitution(IReadOnlyList<TypeRef> typeRefArray, Resolver resolver)
		{
			Requires.NotNull(typeRefArray, "typeRefArray");
			Requires.NotNull(resolver, "resolver");
			TypeRefArray = typeRefArray;
			this.resolver = resolver;
		}

		internal static bool TrySubstituteValue(object value, Resolver resolver, out ISubstitutedValue substitutedValue)
		{
			if (value is Type[])
			{
				substitutedValue = new TypeArraySubstitution(((Type[])value).Select((Type t) => TypeRef.Get(t, resolver)).ToImmutableArray(), resolver);
				return true;
			}
			substitutedValue = null;
			return false;
		}

		public override int GetHashCode()
		{
			if (TypeRefArray.Count <= 0)
			{
				return 0;
			}
			return TypeRefArray[0].GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (obj is TypeArraySubstitution)
			{
				return Equals((TypeArraySubstitution)obj);
			}
			if (TrySubstituteValue(obj, resolver, out var substitutedValue))
			{
				return Equals((TypeArraySubstitution)substitutedValue);
			}
			return false;
		}

		public bool Equals(TypeArraySubstitution other)
		{
			if (other == null)
			{
				return false;
			}
			return TypeRefArray.SequenceEqual(other.TypeRefArray);
		}
	}

	private static readonly HashSet<Assembly> AlwaysLoadedAssemblies = new HashSet<Assembly>(new Assembly[2]
	{
		typeof(CreationPolicy).GetTypeInfo().Assembly,
		typeof(string).GetTypeInfo().Assembly
	});

	private readonly Direction direction;

	private readonly Resolver resolver;

	protected ImmutableDictionary<string, object> underlyingMetadata;

	public IEnumerable<string> Keys => underlyingMetadata.Keys;

	ICollection<string> IDictionary<string, object>.Keys => ((IDictionary<string, object>)underlyingMetadata).Keys;

	public IEnumerable<object> Values => from pair in this
		let value = SubstituteValueIfRequired(pair.Key, pair.Value)
		select value;

	ICollection<object> IDictionary<string, object>.Values => Values.ToImmutableArray();

	public int Count => underlyingMetadata.Count;

	public bool IsReadOnly => true;

	public object this[string key]
	{
		get
		{
			return SubstituteValueIfRequired(key, underlyingMetadata[key]);
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	internal LazyMetadataWrapper(ImmutableDictionary<string, object> metadata, Direction direction, Resolver resolver)
	{
		Requires.NotNull(metadata, "metadata");
		Requires.NotNull(resolver, "resolver");
		this.direction = direction;
		underlyingMetadata = metadata;
		this.resolver = resolver;
	}

	public bool ContainsKey(string key)
	{
		return underlyingMetadata.ContainsKey(key);
	}

	public bool TryGetValue(string key, out object value)
	{
		if (underlyingMetadata.TryGetValue(key, out var value2))
		{
			value = SubstituteValueIfRequired(key, value2);
			return true;
		}
		value = null;
		return false;
	}

	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		return underlyingMetadata.Select((KeyValuePair<string, object> pair) => new KeyValuePair<string, object>(pair.Key, SubstituteValueIfRequired(pair.Key, pair.Value))).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(string key, object value)
	{
		throw new NotSupportedException();
	}

	public bool Remove(string key)
	{
		throw new NotSupportedException();
	}

	public void Add(KeyValuePair<string, object> item)
	{
		throw new NotSupportedException();
	}

	public void Clear()
	{
		throw new NotSupportedException();
	}

	public bool Contains(KeyValuePair<string, object> item)
	{
		if (underlyingMetadata.TryGetValue(item.Key, out var value))
		{
			value = SubstituteValueIfRequired(item.Key, value);
			return item.Value == value;
		}
		return false;
	}

	public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
	{
		using IEnumerator<KeyValuePair<string, object>> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			KeyValuePair<string, object> current = enumerator.Current;
			array[arrayIndex++] = current;
		}
	}

	public bool Remove(KeyValuePair<string, object> item)
	{
		throw new NotSupportedException();
	}

	internal static IReadOnlyDictionary<string, object> TryUnwrap(IReadOnlyDictionary<string, object> metadata)
	{
		if (metadata is LazyMetadataWrapper lazyMetadataWrapper)
		{
			return lazyMetadataWrapper.underlyingMetadata;
		}
		return metadata;
	}

	internal static IReadOnlyDictionary<string, object> Rewrap(IReadOnlyDictionary<string, object> originalWrapper, IReadOnlyDictionary<string, object> updatedMetadata)
	{
		if (originalWrapper is LazyMetadataWrapper lazyMetadataWrapper)
		{
			return lazyMetadataWrapper.Clone(lazyMetadataWrapper, updatedMetadata);
		}
		return updatedMetadata;
	}

	protected virtual LazyMetadataWrapper Clone(LazyMetadataWrapper oldVersion, IReadOnlyDictionary<string, object> newMetadata)
	{
		return new LazyMetadataWrapper(newMetadata.ToImmutableDictionary(), oldVersion.direction, resolver);
	}

	protected object SubstituteValueIfRequired(string key, object value)
	{
		Requires.NotNull(key, "key");
		if (value == null)
		{
			return null;
		}
		value = SubstituteValueIfRequired(value);
		underlyingMetadata = underlyingMetadata.SetItem(key, value);
		return value;
	}

	protected virtual object SubstituteValueIfRequired(object value)
	{
		Requires.NotNull(value, "value");
		switch (direction)
		{
		case Direction.ToSubstitutedValue:
		{
			if (Enum32Substitution.TrySubstituteValue(value, resolver, out var substitutedValue2) || TypeSubstitution.TrySubstituteValue(value, resolver, out substitutedValue2) || TypeArraySubstitution.TrySubstituteValue(value, resolver, out substitutedValue2))
			{
				value = substitutedValue2;
			}
			break;
		}
		case Direction.ToOriginalValue:
			if (value is ISubstitutedValue substitutedValue)
			{
				value = substitutedValue.ActualValue;
			}
			break;
		default:
			throw Assumes.NotReachable();
		}
		return value;
	}

	private static bool IsTypeWorthDeferring(Type typeOfValue)
	{
		Requires.NotNull(typeOfValue, "typeOfValue");
		return !AlwaysLoadedAssemblies.Contains(typeOfValue.GetTypeInfo().Assembly);
	}
}
