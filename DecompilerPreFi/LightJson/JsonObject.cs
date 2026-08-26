using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace LightJson;

[DebuggerDisplay("Count = {Count}")]
[DebuggerTypeProxy(typeof(JsonObjectDebugView))]
internal sealed class JsonObject : IEnumerable<KeyValuePair<string, JsonValue>>, IEnumerable, IEnumerable<JsonValue>
{
	[ExcludeFromCodeCoverage]
	private class JsonObjectDebugView
	{
		[DebuggerDisplay("{value.ToString(),nq}", Name = "{key}", Type = "JsonValue({Type})")]
		public class KeyValuePair
		{
			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private string key;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private JsonValue value;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public object View
			{
				get
				{
					if (value.IsJsonObject)
					{
						return (JsonObject)value;
					}
					if (value.IsJsonArray)
					{
						return (JsonArray)value;
					}
					return value;
				}
			}

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			private JsonValueType Type => value.Type;

			public KeyValuePair(string key, JsonValue value)
			{
				this.key = key;
				this.value = value;
			}
		}

		private JsonObject jsonObject;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair[] Keys
		{
			get
			{
				KeyValuePair[] array = new KeyValuePair[jsonObject.Count];
				int num = 0;
				foreach (KeyValuePair<string, JsonValue> item in jsonObject)
				{
					array[num] = new KeyValuePair(item.Key, item.Value);
					num = checked(num + 1);
				}
				return array;
			}
		}

		public JsonObjectDebugView(JsonObject jsonObject)
		{
			this.jsonObject = jsonObject;
		}
	}

	private IDictionary<string, JsonValue> properties;

	public int Count => properties.Count;

	public JsonValue this[string key]
	{
		get
		{
			if (properties.TryGetValue(key, out var value))
			{
				return value;
			}
			return JsonValue.Null;
		}
		set
		{
			properties[key] = value;
		}
	}

	public JsonObject()
	{
		properties = new Dictionary<string, JsonValue>();
	}

	public JsonObject Add(string key)
	{
		return Add(key, JsonValue.Null);
	}

	public JsonObject Add(string key, JsonValue value)
	{
		properties.Add(key, value);
		return this;
	}

	public bool Remove(string key)
	{
		return properties.Remove(key);
	}

	public JsonObject Clear()
	{
		properties.Clear();
		return this;
	}

	public JsonObject Rename(string oldKey, string newKey)
	{
		if (oldKey == newKey)
		{
			return this;
		}
		if (properties.TryGetValue(oldKey, out var value))
		{
			this[newKey] = value;
			Remove(oldKey);
		}
		return this;
	}

	public bool ContainsKey(string key)
	{
		return properties.ContainsKey(key);
	}

	public bool Contains(JsonValue value)
	{
		return properties.Values.Contains(value);
	}

	public IEnumerator<KeyValuePair<string, JsonValue>> GetEnumerator()
	{
		return properties.GetEnumerator();
	}

	IEnumerator<JsonValue> IEnumerable<JsonValue>.GetEnumerator()
	{
		return properties.Values.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
