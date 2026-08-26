using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace DecompTools.Decompiler.Util;

public sealed class CacheManager
{
	private readonly ConcurrentDictionary<object, object> sharedDict = new ConcurrentDictionary<object, object>((IEqualityComparer<object>)ReferenceComparer.Instance);

	public object GetShared(object key)
	{
		object result = default(object);
		sharedDict.TryGetValue(key, ref result);
		return result;
	}

	public object GetOrAddShared(object key, Func<object, object> valueFactory)
	{
		return sharedDict.GetOrAdd(key, valueFactory);
	}

	public object GetOrAddShared(object key, object value)
	{
		return sharedDict.GetOrAdd(key, value);
	}

	public void SetShared(object key, object value)
	{
		sharedDict[key] = value;
	}
}
