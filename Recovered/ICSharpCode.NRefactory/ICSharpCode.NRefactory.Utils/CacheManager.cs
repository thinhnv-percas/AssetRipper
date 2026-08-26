using System;
using System.Collections.Concurrent;

namespace ICSharpCode.NRefactory.Utils
{
	public sealed class CacheManager
	{
		private readonly ConcurrentDictionary<object, object> sharedDict = new ConcurrentDictionary<object, object>(ReferenceComparer.Instance);

		public object GetShared(object key)
		{
			sharedDict.TryGetValue(key, out object value);
			return value;
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
}
