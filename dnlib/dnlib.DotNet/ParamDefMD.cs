#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;

namespace dnlib.DotNet;

internal sealed class ParamDefMD : ParamDef, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	public uint OrigRid => origRid;

	protected override MarshalType GetMarshalType_NoLock()
	{
		return readerModule.ReadMarshalType(Table.Param, origRid, GenericParamContext.Create(declaringMethod));
	}

	protected override Constant GetConstant_NoLock()
	{
		return readerModule.ResolveConstant(readerModule.Metadata.GetConstantRid(Table.Param, origRid));
	}

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.Param, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), GenericParamContext.Create(declaringMethod), list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	public ParamDefMD(ModuleDefMD readerModule, uint rid)
	{
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (readerModule.TablesStream.ParamTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"Param rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		bool condition = readerModule.TablesStream.TryReadParamRow(origRid, out var row);
		Debug.Assert(condition);
		attributes = row.Flags;
		sequence = row.Sequence;
		name = readerModule.StringsStream.ReadNoNull(row.Name);
		declaringMethod = readerModule.GetOwner(this);
	}

	internal ParamDefMD InitializeAll()
	{
		MemberMDInitializer.Initialize(base.DeclaringMethod);
		MemberMDInitializer.Initialize(base.Attributes);
		MemberMDInitializer.Initialize(base.Sequence);
		MemberMDInitializer.Initialize(base.Name);
		MemberMDInitializer.Initialize(base.MarshalType);
		MemberMDInitializer.Initialize(base.Constant);
		MemberMDInitializer.Initialize(base.CustomAttributes);
		return this;
	}
}
