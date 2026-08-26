using System.Collections;
using System.Collections.Generic;
using System.Composition.Properties;
using System.Composition.Runtime.Util;
using System.Linq;

namespace System.Composition.Hosting.Core;

public sealed class CompositionContract
{
	private readonly Type _contractType;

	private readonly string _contractName;

	private readonly IDictionary<string, object> _metadataConstraints;

	public Type ContractType => _contractType;

	public string ContractName => _contractName;

	public IEnumerable<KeyValuePair<string, object>> MetadataConstraints => _metadataConstraints;

	public CompositionContract(Type contractType)
		: this(contractType, null)
	{
	}

	public CompositionContract(Type contractType, string contractName)
		: this(contractType, contractName, null)
	{
	}

	public CompositionContract(Type contractType, string contractName, IDictionary<string, object> metadataConstraints)
	{
		if ((object)contractType == null)
		{
			throw new ArgumentNullException("contractType");
		}
		if (metadataConstraints != null && metadataConstraints.Count == 0)
		{
			throw new ArgumentOutOfRangeException("metadataConstraints");
		}
		_contractType = contractType;
		_contractName = contractName;
		_metadataConstraints = metadataConstraints;
	}

	public override bool Equals(object obj)
	{
		if (obj is CompositionContract compositionContract && compositionContract._contractType.Equals(_contractType) && ((_contractName == null) ? (compositionContract._contractName == null) : _contractName.Equals(compositionContract._contractName)))
		{
			return ConstraintEqual(_metadataConstraints, compositionContract._metadataConstraints);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = _contractType.GetHashCode();
		if (_contractName != null)
		{
			num ^= _contractName.GetHashCode();
		}
		if (_metadataConstraints != null)
		{
			num ^= ConstraintHashCode(_metadataConstraints);
		}
		return num;
	}

	public override string ToString()
	{
		string text = Formatters.Format(_contractType);
		if (_contractName != null)
		{
			text = text + " " + Formatters.Format(_contractName);
		}
		if (_metadataConstraints != null)
		{
			text += string.Format(" {{ {0} }}", new object[1] { string.Join(System.Composition.Properties.Resources.Formatter_ListSeparatorWithSpace, _metadataConstraints.Select((KeyValuePair<string, object> kv) => string.Format("{0} = {1}", new object[2]
			{
				kv.Key,
				Formatters.Format(kv.Value)
			}))) });
		}
		return text;
	}

	public CompositionContract ChangeType(Type newContractType)
	{
		if ((object)newContractType == null)
		{
			throw new ArgumentNullException("newContractType");
		}
		return new CompositionContract(newContractType, _contractName, _metadataConstraints);
	}

	public bool TryUnwrapMetadataConstraint<T>(string constraintName, out T constraintValue, out CompositionContract remainingContract)
	{
		if (constraintName == null)
		{
			throw new ArgumentNullException("constraintName");
		}
		constraintValue = default(T);
		remainingContract = null;
		if (_metadataConstraints == null)
		{
			return false;
		}
		if (!_metadataConstraints.TryGetValue(constraintName, out var value))
		{
			return false;
		}
		if (!(value is T))
		{
			return false;
		}
		constraintValue = (T)value;
		if (_metadataConstraints.Count == 1)
		{
			remainingContract = new CompositionContract(_contractType, _contractName);
		}
		else
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>(_metadataConstraints);
			dictionary.Remove(constraintName);
			remainingContract = new CompositionContract(_contractType, _contractName, dictionary);
		}
		return true;
	}

	internal static bool ConstraintEqual(IDictionary<string, object> first, IDictionary<string, object> second)
	{
		if (first == second)
		{
			return true;
		}
		if (first == null || second == null)
		{
			return false;
		}
		if (first.Count != second.Count)
		{
			return false;
		}
		foreach (KeyValuePair<string, object> item in first)
		{
			if (!second.TryGetValue(item.Key, out var value))
			{
				return false;
			}
			if ((item.Value == null && value != null) || (value == null && item.Value != null))
			{
				return false;
			}
			if (item.Value is IEnumerable enumerable && !(enumerable is string))
			{
				if (!(value is IEnumerable source) || !enumerable.Cast<object>().SequenceEqual(source.Cast<object>()))
				{
					return false;
				}
			}
			else if (!item.Value.Equals(value))
			{
				return false;
			}
		}
		return true;
	}

	private static int ConstraintHashCode(IDictionary<string, object> metadata)
	{
		int num = -1;
		foreach (KeyValuePair<string, object> item in metadata)
		{
			num ^= item.Key.GetHashCode();
			if (item.Value == null)
			{
				continue;
			}
			if (item.Value is string text)
			{
				num ^= text.GetHashCode();
			}
			else if (item.Value is IEnumerable enumerable)
			{
				foreach (object item2 in enumerable)
				{
					if (item2 != null)
					{
						num ^= item2.GetHashCode();
					}
				}
			}
			else
			{
				num ^= item.Value.GetHashCode();
			}
		}
		return num;
	}
}
