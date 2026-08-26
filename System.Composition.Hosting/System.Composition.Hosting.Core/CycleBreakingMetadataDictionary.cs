using System.Collections;
using System.Collections.Generic;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

internal class CycleBreakingMetadataDictionary : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable
{
	private readonly Lazy<ExportDescriptor> _exportDescriptor;

	private IDictionary<string, object> ActualMetadata
	{
		get
		{
			if (!_exportDescriptor.IsValueCreated)
			{
				throw ThrowHelper.NotImplemented_MetadataCycles();
			}
			return _exportDescriptor.Value.Metadata;
		}
	}

	public ICollection<string> Keys => ActualMetadata.Keys;

	public ICollection<object> Values => ActualMetadata.Values;

	public object this[string key]
	{
		get
		{
			return ActualMetadata[key];
		}
		set
		{
			ActualMetadata[key] = value;
		}
	}

	public int Count => ActualMetadata.Count;

	public bool IsReadOnly => ActualMetadata.IsReadOnly;

	public CycleBreakingMetadataDictionary(Lazy<ExportDescriptor> exportDescriptor)
	{
		_exportDescriptor = exportDescriptor;
	}

	public void Add(string key, object value)
	{
		ActualMetadata.Add(key, value);
	}

	public bool ContainsKey(string key)
	{
		return ActualMetadata.ContainsKey(key);
	}

	public bool Remove(string key)
	{
		return ActualMetadata.Remove(key);
	}

	public bool TryGetValue(string key, out object value)
	{
		return ActualMetadata.TryGetValue(key, out value);
	}

	public void Add(KeyValuePair<string, object> item)
	{
		ActualMetadata.Add(item);
	}

	public void Clear()
	{
		ActualMetadata.Clear();
	}

	public bool Contains(KeyValuePair<string, object> item)
	{
		return ActualMetadata.Contains(item);
	}

	public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
	{
		ActualMetadata.CopyTo(array, arrayIndex);
	}

	public bool Remove(KeyValuePair<string, object> item)
	{
		return ActualMetadata.Remove(item);
	}

	public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
	{
		return ActualMetadata.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)ActualMetadata).GetEnumerator();
	}
}
