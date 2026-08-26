using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal static class Utilities
{
	internal static ComposablePartDefinition GetMetadataViewProviderPartDefinition(Type providerType, int orderPrecedence, Resolver resolver)
	{
		Requires.NotNull(providerType, "providerType");
		Requires.NotNull(resolver, "resolver");
		ExportDefinition exportDefinition = new ExportDefinition(ContractNameServices.GetTypeIdentity(typeof(IMetadataViewProvider)), PartCreationPolicyConstraint.GetExportMetadata(CreationPolicy.Shared).AddRange(ExportTypeIdentityConstraint.GetExportMetadata(typeof(IMetadataViewProvider))).SetItem("OrderPrecedence", orderPrecedence));
		return new ComposablePartDefinition(TypeRef.Get(providerType, resolver), ImmutableDictionary<string, object>.Empty.Add("VsMEFDgmlCategories", new string[1] { "VsMEFBuiltIn" }), new ExportDefinition[1] { exportDefinition }, ImmutableDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>>.Empty, ImmutableList<ImportDefinitionBinding>.Empty, string.Empty, default(MethodRef), ConstructorRef.Get(providerType.GetTypeInfo().GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Single((ConstructorInfo c) => c.GetParameters().Length == 0), resolver), ImmutableList<ImportDefinitionBinding>.Empty, CreationPolicy.Shared);
	}

	internal static TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
	{
		if (!dictionary.TryGetValue(key, out var value))
		{
			return defaultValue;
		}
		return value;
	}

	internal static bool EqualsByValue<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> expected, IReadOnlyDictionary<TKey, TValue> actual, IEqualityComparer<TValue> valueComparer = null)
	{
		Requires.NotNull(expected, "expected");
		Requires.NotNull(actual, "actual");
		valueComparer = valueComparer ?? EqualityComparer<TValue>.Default;
		if (expected.Count != actual.Count)
		{
			return false;
		}
		foreach (KeyValuePair<TKey, TValue> item in expected)
		{
			if (!actual.TryGetValue(item.Key, out var value))
			{
				return false;
			}
			if (!valueComparer.Equals(item.Value, value))
			{
				return false;
			}
		}
		return true;
	}

	internal static bool TryGetValue<TValue>(this IReadOnlyDictionary<string, object> metadata, string key, out TValue value)
	{
		if (metadata.TryGetValue(key, out var value2) && value2 is TValue)
		{
			value = (TValue)value2;
			return true;
		}
		value = default(TValue);
		return false;
	}

	internal static string MakeIdentifierNameSafe(string value)
	{
		return value.Replace('`', '_').Replace('.', '_').Replace('+', '_')
			.Replace('{', '_')
			.Replace('}', '_')
			.Replace('(', '_')
			.Replace(')', '_')
			.Replace(',', '_')
			.Replace('-', '_');
	}

	internal static bool Contains<T>(this ImmutableStack<T> stack, T value)
	{
		Requires.NotNull(stack, "stack");
		while (!stack.IsEmpty)
		{
			if (EqualityComparer<T>.Default.Equals(value, stack.Peek()))
			{
				return true;
			}
			stack = stack.Pop();
		}
		return false;
	}

	internal static bool EqualsByValue<T>(this ImmutableArray<T> array, ImmutableArray<T> other) where T : IEquatable<T>
	{
		if (array.Length != other.Length)
		{
			return false;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].Equals(other[i]))
			{
				return false;
			}
		}
		return true;
	}

	internal static void ToString(this IReadOnlyDictionary<string, object> metadata, IndentingTextWriter writer)
	{
		Requires.NotNull(metadata, "metadata");
		Requires.NotNull(writer, "writer");
		foreach (KeyValuePair<string, object> item in metadata)
		{
			writer.WriteLine("{0} = {1}", item.Key, item.Value);
		}
	}

	internal static void ToString(this object value, TextWriter writer)
	{
		Requires.NotNull(value, "value");
		Requires.NotNull(writer, "writer");
		if (value is IDescriptiveToString descriptiveToString)
		{
			descriptiveToString.ToString(writer);
		}
		else
		{
			writer.WriteLine(value);
		}
	}

	internal static object SpecifyIfNull(this object value)
	{
		if (value != null)
		{
			return value;
		}
		return "<null>";
	}

	internal static void ReportNullSafe<T>(this IProgress<T> progress, T value)
	{
		progress?.Report(value);
	}

	internal static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<TValue> source, Func<TValue, TKey> keySelector, int capacity)
	{
		Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>(capacity);
		foreach (TValue item in source)
		{
			dictionary.Add(keySelector(item), item);
		}
		return dictionary;
	}
}
