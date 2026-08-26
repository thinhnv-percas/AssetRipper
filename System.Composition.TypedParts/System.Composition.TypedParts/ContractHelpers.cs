using System.Collections.Generic;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Composition.Properties;
using System.Linq;
using System.Reflection;

namespace System.Composition.TypedParts;

internal static class ContractHelpers
{
	private const string ImportManyImportMetadataConstraintName = "IsImportMany";

	public static bool TryGetExplicitImportInfo(Type memberType, object[] attributes, object site, out ImportInfo importInfo)
	{
		if (attributes.Any((object a) => a is ImportAttribute || a is ImportManyAttribute))
		{
			importInfo = GetImportInfo(memberType, attributes, site);
			return true;
		}
		importInfo = null;
		return false;
	}

	public static ImportInfo GetImportInfo(Type memberType, object[] attributes, object site)
	{
		CompositionContract compositionContract = new CompositionContract(memberType);
		IDictionary<string, object> dictionary = null;
		bool allowDefault = false;
		int num = 0;
		foreach (object obj in attributes)
		{
			if (obj is ImportAttribute importAttribute)
			{
				compositionContract = new CompositionContract(memberType, importAttribute.ContractName);
				allowDefault = importAttribute.AllowDefault;
				num++;
			}
			else if (obj is ImportManyAttribute importManyAttribute)
			{
				dictionary = dictionary ?? new Dictionary<string, object>();
				dictionary.Add("IsImportMany", true);
				compositionContract = new CompositionContract(memberType, importManyAttribute.ContractName);
				num++;
			}
			else if (obj is ImportMetadataConstraintAttribute importMetadataConstraintAttribute)
			{
				dictionary = dictionary ?? new Dictionary<string, object>();
				dictionary.Add(importMetadataConstraintAttribute.Name, importMetadataConstraintAttribute.Value);
			}
			Type attrType = obj.GetType();
			if (attrType.GetTypeInfo().GetCustomAttribute<MetadataAttributeAttribute>(inherit: true) == null)
			{
				continue;
			}
			foreach (PropertyInfo item in from p in attrType.GetRuntimeProperties()
				where p.GetMethod.IsPublic && (object)p.DeclaringType == attrType && p.CanRead
				select p)
			{
				dictionary = dictionary ?? new Dictionary<string, object>();
				dictionary.Add(item.Name, item.GetValue(obj, null));
			}
		}
		if (num > 1)
		{
			string message = string.Format(System.Composition.Properties.Resources.ContractHelpers_TooManyImports, new object[1] { site });
			throw new CompositionFailedException(message);
		}
		if (dictionary != null)
		{
			compositionContract = new CompositionContract(compositionContract.ContractType, compositionContract.ContractName, dictionary);
		}
		return new ImportInfo(compositionContract, allowDefault);
	}

	public static bool IsShared(IDictionary<string, object> partMetadata)
	{
		return partMetadata.ContainsKey("SharingBoundary");
	}
}
