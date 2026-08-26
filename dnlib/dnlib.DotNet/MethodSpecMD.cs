#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

internal sealed class MethodSpecMD : MethodSpec, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	private readonly GenericParamContext gpContext;

	public uint OrigRid => origRid;

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.MethodSpec, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), gpContext, list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	public MethodSpecMD(ModuleDefMD readerModule, uint rid, GenericParamContext gpContext)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.MethodSpecTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"MethodSpec rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		this.gpContext = gpContext;
		bool condition = readerModule.TablesStream.TryReadMethodSpecRow(origRid, out var row);
		Debug.Assert(condition);
		method = readerModule.ResolveMethodDefOrRef(row.Method, gpContext);
		instantiation = readerModule.ReadSignature(row.Instantiation, gpContext);
	}
}
