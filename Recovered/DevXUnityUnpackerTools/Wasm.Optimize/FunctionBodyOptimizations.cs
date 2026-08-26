using System.Collections.Generic;

namespace Wasm.Optimize
{
	public static class FunctionBodyOptimizations
	{
		public static void CompressLocalEntries(this FunctionBody body)
		{
			List<LocalEntry> list = new List<LocalEntry>();
			LocalEntry item = new LocalEntry(WasmValueType.Int32, 0u);
			for (int i = 0; i < body.Locals.Count; i++)
			{
				LocalEntry localEntry = body.Locals[i];
				if (localEntry.LocalType == item.LocalType)
				{
					item = new LocalEntry(item.LocalType, item.LocalCount + localEntry.LocalCount);
					continue;
				}
				if (item.LocalCount != 0)
				{
					list.Add(item);
				}
				item = localEntry;
			}
			if (item.LocalCount != 0)
			{
				list.Add(item);
			}
			body.Locals.Clear();
			body.Locals.AddRange(list);
		}

		public static void ExpandLocalEntries(this FunctionBody body)
		{
			List<LocalEntry> list = new List<LocalEntry>();
			for (int i = 0; i < body.Locals.Count; i++)
			{
				LocalEntry localEntry = body.Locals[i];
				for (uint num = 0u; num < localEntry.LocalCount; num++)
				{
					list.Add(new LocalEntry(localEntry.LocalType, 1u));
				}
			}
			body.Locals.Clear();
			body.Locals.AddRange(list);
		}
	}
}
