#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

internal sealed class ManifestResourceMD : ManifestResource, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	public uint OrigRid => origRid;

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.ManifestResource, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), default(GenericParamContext), list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	public ManifestResourceMD(ModuleDefMD readerModule, uint rid)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.ManifestResourceTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"ManifestResource rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		bool condition = readerModule.TablesStream.TryReadManifestResourceRow(origRid, out var row);
		Debug.Assert(condition);
		offset = row.Offset;
		attributes = (int)row.Flags;
		name = readerModule.StringsStream.ReadNoNull(row.Name);
		implementation = readerModule.ResolveImplementation(row.Implementation);
	}
}
