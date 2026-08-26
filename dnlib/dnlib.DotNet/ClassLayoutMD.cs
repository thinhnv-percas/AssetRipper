#define DEBUG
using System;
using System.Diagnostics;

namespace dnlib.DotNet;

internal sealed class ClassLayoutMD : ClassLayout, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly uint origRid;

	public uint OrigRid => origRid;

	public ClassLayoutMD(ModuleDefMD readerModule, uint rid)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.ClassLayoutTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"ClassLayout rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		bool condition = readerModule.TablesStream.TryReadClassLayoutRow(origRid, out var row);
		Debug.Assert(condition);
		classSize = row.ClassSize;
		packingSize = row.PackingSize;
	}
}
