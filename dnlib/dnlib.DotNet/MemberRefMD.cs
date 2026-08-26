#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

internal sealed class MemberRefMD : MemberRef, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	private readonly GenericParamContext gpContext;

	public uint OrigRid => origRid;

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.MemberRef, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), gpContext, list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	public MemberRefMD(ModuleDefMD readerModule, uint rid, GenericParamContext gpContext)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.MemberRefTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"MemberRef rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		this.gpContext = gpContext;
		module = readerModule;
		bool condition = readerModule.TablesStream.TryReadMemberRefRow(origRid, out var row);
		Debug.Assert(condition);
		name = readerModule.StringsStream.ReadNoNull(row.Name);
		@class = readerModule.ResolveMemberRefParent(row.Class, gpContext);
		signature = readerModule.ReadSignature(row.Signature, MemberRef.GetSignatureGenericParamContext(gpContext, @class));
	}
}
