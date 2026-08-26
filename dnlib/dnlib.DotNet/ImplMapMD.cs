#define DEBUG
using System;
using System.Diagnostics;

namespace dnlib.DotNet;

internal sealed class ImplMapMD : ImplMap, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly uint origRid;

	public uint OrigRid => origRid;

	public ImplMapMD(ModuleDefMD readerModule, uint rid)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.ImplMapTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"ImplMap rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		bool condition = readerModule.TablesStream.TryReadImplMapRow(origRid, out var row);
		Debug.Assert(condition);
		attributes = row.MappingFlags;
		name = readerModule.StringsStream.ReadNoNull(row.ImportName);
		module = readerModule.ResolveModuleRef(row.ImportScope);
	}
}
