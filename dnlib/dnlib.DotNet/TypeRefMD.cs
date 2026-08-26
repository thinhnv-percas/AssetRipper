#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

internal sealed class TypeRefMD : TypeRef, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	private readonly uint resolutionScopeCodedToken;

	public uint OrigRid => origRid;

	protected override IResolutionScope GetResolutionScope_NoLock()
	{
		return readerModule.ResolveResolutionScope(resolutionScopeCodedToken);
	}

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.TypeRef, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), default(GenericParamContext), list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	public TypeRefMD(ModuleDefMD readerModule, uint rid)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.TypeRefTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"TypeRef rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		module = readerModule;
		bool condition = readerModule.TablesStream.TryReadTypeRefRow(origRid, out var row);
		Debug.Assert(condition);
		name = readerModule.StringsStream.ReadNoNull(row.Name);
		@namespace = readerModule.StringsStream.ReadNoNull(row.Namespace);
		resolutionScopeCodedToken = row.ResolutionScope;
	}
}
