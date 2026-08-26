using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.Convention;

public sealed class ImportConventionBuilder
{
	private static readonly Type[] s_supportedImportManyTypes = new Type[3]
	{
		typeof(IList<>),
		typeof(ICollection<>),
		typeof(IEnumerable<>)
	};

	private string _contractName;

	private bool? _asMany;

	private bool _allowDefault;

	private Func<Type, string> _getContractNameFromPartType;

	private List<Tuple<string, object>> _metadataConstraintItems;

	private List<Tuple<string, Func<Type, object>>> _metadataConstraintItemFuncs;

	internal ImportConventionBuilder()
	{
	}

	public ImportConventionBuilder AsContractName(string contractName)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(contractName, "contractName");
		_contractName = contractName;
		return this;
	}

	public ImportConventionBuilder AsContractName(Func<Type, string> getContractNameFromPartType)
	{
		Microsoft.Internal.Requires.NotNull(getContractNameFromPartType, "getContractNameFromPartType");
		_getContractNameFromPartType = getContractNameFromPartType;
		return this;
	}

	public ImportConventionBuilder AsMany()
	{
		return AsMany(isMany: true);
	}

	public ImportConventionBuilder AsMany(bool isMany)
	{
		_asMany = isMany;
		return this;
	}

	public ImportConventionBuilder AllowDefault()
	{
		_allowDefault = true;
		return this;
	}

	public ImportConventionBuilder AddMetadataConstraint(string name, object value)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(name, "name");
		if (_metadataConstraintItems == null)
		{
			_metadataConstraintItems = new List<Tuple<string, object>>();
		}
		_metadataConstraintItems.Add(Tuple.Create(name, value));
		return this;
	}

	public ImportConventionBuilder AddMetadataConstraint(string name, Func<Type, object> getConstraintValueFromPartType)
	{
		Microsoft.Internal.Requires.NotNullOrEmpty(name, "name");
		Microsoft.Internal.Requires.NotNull(getConstraintValueFromPartType, "getConstraintValueFromPartType");
		if (_metadataConstraintItemFuncs == null)
		{
			_metadataConstraintItemFuncs = new List<Tuple<string, Func<Type, object>>>();
		}
		_metadataConstraintItemFuncs.Add(Tuple.Create(name, getConstraintValueFromPartType));
		return this;
	}

	internal void BuildAttributes(Type type, ref List<Attribute> attributes)
	{
		string contractName = ((_getContractNameFromPartType != null) ? _getContractNameFromPartType(type) : _contractName);
		Attribute item = ((_asMany ?? IsSupportedImportManyType(type.GetTypeInfo())) ? ((Attribute)new ImportManyAttribute(contractName)) : ((Attribute)new ImportAttribute(contractName)
		{
			AllowDefault = _allowDefault
		}));
		if (attributes == null)
		{
			attributes = new List<Attribute>();
		}
		attributes.Add(item);
		if (_metadataConstraintItems != null)
		{
			foreach (Tuple<string, object> metadataConstraintItem in _metadataConstraintItems)
			{
				attributes.Add(new ImportMetadataConstraintAttribute(metadataConstraintItem.Item1, metadataConstraintItem.Item2));
			}
		}
		if (_metadataConstraintItemFuncs == null)
		{
			return;
		}
		foreach (Tuple<string, Func<Type, object>> metadataConstraintItemFunc in _metadataConstraintItemFuncs)
		{
			string item2 = metadataConstraintItemFunc.Item1;
			object value = ((metadataConstraintItemFunc.Item2 != null) ? metadataConstraintItemFunc.Item2(type) : null);
			attributes.Add(new ImportMetadataConstraintAttribute(item2, value));
		}
	}

	private bool IsSupportedImportManyType(TypeInfo typeInfo)
	{
		if (!typeInfo.IsArray && (!typeInfo.IsGenericTypeDefinition || !s_supportedImportManyTypes.Contains(typeInfo.AsType())))
		{
			if (typeInfo.AsType().IsConstructedGenericType)
			{
				return s_supportedImportManyTypes.Contains(typeInfo.GetGenericTypeDefinition());
			}
			return false;
		}
		return true;
	}
}
