using System.Collections.Generic;

namespace Wasm.Optimize
{
	public static class FunctionTypeOptimizations
	{
		public static void MakeFunctionTypesDistinct(IEnumerable<FunctionType> types, out IList<FunctionType> newTypes, out IDictionary<uint, uint> typeMapping)
		{
			List<FunctionType> list = new List<FunctionType>();
			Dictionary<FunctionType, uint> dictionary = new Dictionary<FunctionType, uint>(ConstFunctionTypeComparer.Instance);
			Dictionary<uint, uint> dictionary2 = new Dictionary<uint, uint>();
			uint num = 0u;
			foreach (FunctionType type in types)
			{
				if (dictionary.TryGetValue(type, out uint value))
				{
					dictionary2[num] = value;
				}
				else
				{
					value = (dictionary2[num] = (dictionary[type] = (uint)list.Count));
					list.Add(type);
				}
				num++;
			}
			newTypes = list;
			typeMapping = dictionary2;
		}

		public static void RewriteFunctionTypeReferences(this WasmFile file, IDictionary<uint, uint> rewriteMap)
		{
			IList<ImportSection> sections = file.GetSections<ImportSection>();
			for (int i = 0; i < sections.Count; i++)
			{
				ImportSection importSection = sections[i];
				for (int j = 0; j < importSection.Imports.Count; j++)
				{
					ImportedFunction importedFunction = importSection.Imports[j] as ImportedFunction;
					if (importedFunction != null && rewriteMap.TryGetValue(importedFunction.TypeIndex, out uint value))
					{
						importedFunction.TypeIndex = value;
					}
				}
			}
			IList<FunctionSection> sections2 = file.GetSections<FunctionSection>();
			for (int k = 0; k < sections2.Count; k++)
			{
				FunctionSection functionSection = sections2[k];
				for (int l = 0; l < functionSection.FunctionTypes.Count; l++)
				{
					if (rewriteMap.TryGetValue(functionSection.FunctionTypes[l], out uint value2))
					{
						functionSection.FunctionTypes[l] = value2;
					}
				}
			}
		}

		public static void CompressFunctionTypes(this WasmFile file)
		{
			TypeSection firstSectionOrNull = file.GetFirstSectionOrNull<TypeSection>();
			if (firstSectionOrNull != null)
			{
				MakeFunctionTypesDistinct(firstSectionOrNull.FunctionTypes, out IList<FunctionType> newTypes, out IDictionary<uint, uint> typeMapping);
				firstSectionOrNull.FunctionTypes.Clear();
				firstSectionOrNull.FunctionTypes.AddRange(newTypes);
				file.RewriteFunctionTypeReferences(typeMapping);
			}
		}
	}
}
