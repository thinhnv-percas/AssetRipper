#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb;
using dnlib.PE;

namespace dnlib.DotNet;

public class ModuleDefMD2 : ModuleDef, IMDTokenProviderMD, IMDTokenProvider
{
	private readonly ModuleDefMD readerModule;

	private readonly uint origRid;

	public uint OrigRid => origRid;

	protected override void InitializeCustomAttributes()
	{
		RidList list = readerModule.Metadata.GetCustomAttributeRidList(Table.Module, origRid);
		CustomAttributeCollection value = new CustomAttributeCollection(list.Count, list, (object obj, int index) => readerModule.ReadCustomAttribute(list[index]));
		Interlocked.CompareExchange(ref customAttributes, value, null);
	}

	protected override void InitializeCustomDebugInfos()
	{
		List<PdbCustomDebugInfo> list = new List<PdbCustomDebugInfo>();
		readerModule.InitializeCustomDebugInfos(new MDToken(base.MDToken.Table, origRid), default(GenericParamContext), list);
		Interlocked.CompareExchange(ref customDebugInfos, list, null);
	}

	protected override RVA GetNativeEntryPoint_NoLock()
	{
		return readerModule.GetNativeEntryPoint();
	}

	protected override IManagedEntryPoint GetManagedEntryPoint_NoLock()
	{
		return readerModule.GetManagedEntryPoint();
	}

	internal ModuleDefMD2(ModuleDefMD readerModule, uint rid)
	{
		if (rid == 1 && readerModule == null)
		{
			readerModule = (ModuleDefMD)this;
		}
		if (readerModule == null)
		{
			throw new ArgumentNullException("readerModule");
		}
		if (rid != 1 && readerModule.TablesStream.ModuleTable.IsInvalidRID(rid))
		{
			throw new BadImageFormatException($"Module rid {rid} does not exist");
		}
		origRid = rid;
		base.rid = rid;
		this.readerModule = readerModule;
		if (rid != 1)
		{
			base.Kind = ModuleKind.Windows;
			base.Characteristics = Characteristics.ExecutableImage | Characteristics._32BitMachine;
			base.DllCharacteristics = DllCharacteristics.DynamicBase | DllCharacteristics.NxCompat | DllCharacteristics.NoSeh | DllCharacteristics.TerminalServerAware;
			base.RuntimeVersion = "v2.0.50727";
			base.Machine = Machine.I386;
			cor20HeaderFlags = 1;
			base.Cor20HeaderRuntimeVersion = 131077u;
			base.TablesHeaderVersion = (ushort)512;
			corLibTypes = new CorLibTypes(this);
			location = string.Empty;
			InitializeFromRawRow();
		}
	}

	protected void InitializeFromRawRow()
	{
		bool condition = readerModule.TablesStream.TryReadModuleRow(origRid, out var row);
		Debug.Assert(condition);
		generation = row.Generation;
		mvid = readerModule.GuidStream.Read(row.Mvid);
		encId = readerModule.GuidStream.Read(row.EncId);
		encBaseId = readerModule.GuidStream.Read(row.EncBaseId);
		name = readerModule.StringsStream.ReadNoNull(row.Name);
		if (origRid == 1)
		{
			assembly = readerModule.ResolveAssembly(origRid);
		}
	}
}
