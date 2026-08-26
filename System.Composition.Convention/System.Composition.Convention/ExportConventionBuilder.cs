using System.Collections.Generic;
using Microsoft.Internal;

namespace System.Composition.Convention;

public sealed class ExportConventionBuilder
{
	private string _contractName;

	private Type _contractType;

	private List<Tuple<string, object>> _metadataItems;

	private List<Tuple<string, Func<Type, object>>> _metadataItemFuncs;

	private Func<Type, string> _getContractNameFromPartType;

	internal ExportConventionBuilder()
	{
	}

	public ExportConventionBuilder AsContractType<T>()
	{
		return AsContractType(typeof(T));
	}

	public ExportConventionBuilder AsContractType(Type type)
	{
		Microsoft.Internal.Requires.NotNull(type, "type");
		_contractType = type;
		return this;
	}

	public ExportConventionBuilder AsContractName(string contractName)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(contractName, "contractName");
		_contractName = contractName;
		return this;
	}

	public ExportConventionBuilder AsContractName(Func<Type, string> getContractNameFromPartType)
	{
		Microsoft.Internal.Requires.NotNull(getContractNameFromPartType, "getContractNameFromPartType");
		_getContractNameFromPartType = getContractNameFromPartType;
		return this;
	}

	public ExportConventionBuilder AddMetadata(string name, object value)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(name, "name");
		if (_metadataItems == null)
		{
			_metadataItems = new List<Tuple<string, object>>();
		}
		_metadataItems.Add(Tuple.Create(name, value));
		return this;
	}

	public ExportConventionBuilder AddMetadata(string name, Func<Type, object> getValueFromPartType)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(name, "name");
		Microsoft.Internal.Requires.NotNull(getValueFromPartType, "getValueFromPartType");
		if (_metadataItemFuncs == null)
		{
			_metadataItemFuncs = new List<Tuple<string, Func<Type, object>>>();
		}
		_metadataItemFuncs.Add(Tuple.Create(name, getValueFromPartType));
		return this;
	}

	internal void BuildAttributes(Type type, ref List<Attribute> attributes)
	{
		if (attributes == null)
		{
			attributes = new List<Attribute>();
		}
		string contractName = ((_getContractNameFromPartType != null) ? _getContractNameFromPartType(type) : _contractName);
		attributes.Add(new ExportAttribute(contractName, _contractType));
		if (_metadataItems != null)
		{
			foreach (Tuple<string, object> metadataItem in _metadataItems)
			{
				attributes.Add(new ExportMetadataAttribute(metadataItem.Item1, metadataItem.Item2));
			}
		}
		if (_metadataItemFuncs == null)
		{
			return;
		}
		foreach (Tuple<string, Func<Type, object>> metadataItemFunc in _metadataItemFuncs)
		{
			string item = metadataItemFunc.Item1;
			object value = ((metadataItemFunc.Item2 != null) ? metadataItemFunc.Item2(type) : null);
			attributes.Add(new ExportMetadataAttribute(item, value));
		}
	}
}
