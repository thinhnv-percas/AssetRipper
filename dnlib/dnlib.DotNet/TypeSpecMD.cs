#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

internal sealed class TypeSpecMD : TypeSpec, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	private readonly GenericParamContext gpContext;

	private readonly uint signatureOffset;

	public uint OrigRid => origRid;

	protected override TypeSig GetTypeSigAndExtraData_NoLock(out byte[] extraData)
	{
		TypeSig typeSig = readerModule.ReadTypeSignature(signatureOffset, gpContext, out extraData);
		if (typeSig != null)
		{
			typeSig.Rid = origRid;
		}
		return typeSig;
	}

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.TypeSpec, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), gpContext, list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	public TypeSpecMD(ModuleDefMD readerModule, uint rid, GenericParamContext gpContext)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.TypeSpecTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"TypeSpec rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		this.gpContext = gpContext;
		bool condition = readerModule.TablesStream.TryReadTypeSpecRow(origRid, out var row);
		Debug.Assert(condition);
		signatureOffset = row.Signature;
	}
}
