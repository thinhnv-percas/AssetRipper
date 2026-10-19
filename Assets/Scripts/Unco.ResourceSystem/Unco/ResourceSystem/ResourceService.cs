using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x200000E")]
	public class ResourceService : IResourceService, IResourceQuery, IResourceCommand
	{
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x10")]
		private readonly IResourceRepository _repository;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x18")]
		private readonly IResourceAnalytics _analytics;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x20")]
		private readonly ResourceConfig _config;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x28")]
		private readonly Dictionary<ResourceType, double> _runtimeCache;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x30")]
		private readonly List<ResourceChangedEvent> _mutedEvents;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x38")]
		private bool _isMuted;

		[CompilerGenerated]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x40")]
		private Action<ResourceChangedEvent> _003COnResourceChanged_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x48")]
		private Action<ResourceChangedEvent> _003COnResourceChanged_MuteIgnored_003Ek__BackingField;

		[Token(Token = "0x14000003")]
		public event Action<ResourceChangedEvent> OnResourceChanged
		{
			[CompilerGenerated]
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x81D097C", Offset = "0x81D097C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnResourceChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnResourceChanged (System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::add_OnResourceChanged");
			}
			[CompilerGenerated]
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x81D0A30", Offset = "0x81D0A30", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnResourceChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnResourceChanged (System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::remove_OnResourceChanged");
			}
		}

		[Token(Token = "0x14000004")]
		public event Action<ResourceChangedEvent> OnResourceChanged_MuteIgnored
		{
			[CompilerGenerated]
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x81D0AE4", Offset = "0x81D0AE4", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnResourceChanged_MuteIgnored;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnResourceChanged_MuteIgnored (System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::add_OnResourceChanged_MuteIgnored");
			}
			[CompilerGenerated]
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x81D0B98", Offset = "0x81D0B98", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnResourceChanged_MuteIgnored;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnResourceChanged_MuteIgnored (System.Action`1<Unco.ResourceSystem.ResourceChangedEvent>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::remove_OnResourceChanged_MuteIgnored");
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x81D0C4C", Offset = "0x81D0C4C", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tthis._repository = repository;\n\tv71 = analytics == 0;\n\tif (v71) goto L_006C;\n\tthis._analytics = analytics;\n\tv91 = config == 0;\n\tif (v91) goto L_0074;\n\tthis._config = config;\n\tv119 = new System.Collections.Generic.Dictionary`2<Unco.ResourceSystem.ResourceType, System.Double>();\n\tSystem.Collections.Generic.Dictionary`2<Unco.ResourceSystem.ResourceType, System.Double>::.ctor(v119);\n\tthis._runtimeCache = v119;\n\tv154 = new System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>();\n\tSystem.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>::.ctor(v154);\n\tthis._mutedEvents = v154;\n\treturn;\nL_0063:\n\tv61 = 0xB28B000 + 0x600;\n\tv70 = new v61();\n\tv87 = 0xB30F000 + 0x408;\n\tv92 = v70;\n\tgoto L_007E;\nL_006C:\n\tv76 = 0xB28B000 + 0x600;\n\tv85 = new v76();\n\tv87 = 0xB307000 + 0x850;\n\tv92 = v85;\n\tgoto L_007E;\nL_0074:\n\tv113 = 0xB28B000 + 0x600;\n\tv120 = new v113();\n\tv87 = 0xB308000 + 0xEB0;\n\tv92 = v120;\n\tthrow v92;\nL_0024:\n\tSystem.Object::.ctor(this);\n\tv55 = repository == 0;\n\tif (v55) goto L_0063;\nL_007E:\n\tSystem.ArgumentNullException::.ctor(v92, v87);\n")]
		public ResourceService(IResourceRepository repository, IResourceAnalytics analytics, ResourceConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::.ctor");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600002B")]
		[Address(RVA = "0x81D0E04", Offset = "0x81D0E04", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = type - 0x1F3;\n\tv4 = v3 < 0;\n\tv5 = v3 == 0;\n\tv6 = type ^ 0x1F3;\n\tv7 = type ^ v3;\n\tv8 = v6 & v7;\n\tv9 = v8 < 0;\n\tv10 = v4 == v9;\n\tv11 = ~v5;\n\tv12 = v10 & v11;\n\treturn v12;\n")]
		private static bool IsBaseLayerResource(ResourceType type)
		{
			int num = (int)(type - 499);
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = (int)(type ^ (ResourceType)499);
			int num3 = (int)type ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x81D0E10", Offset = "0x81D0E10", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\treturn 0x7FEFFFFFFFFFFFFF;\nL_0033:\n\tv70 = resourceType < 0x1F4;\n\tif (v70) goto L_0061;\n\tv144 = System.Collections.Generic.Dictionary`2<Unco.ResourceSystem.ResourceType, System.Double>::TryGetValue(this._runtimeCache, resourceType, &v92 @ stack_-38_v2 (System.Double));\n\tv121 = v144 == 0;\n\tv101 = ~v121;\n\tv85 = ~v101;\n\tif (v85) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal3 = v92;\n\tgoto L_0057;\nL_FFFFFFFF:\n\treturnVal3 = 0;\nL_0061:\n\tgoto L_008F;\nL_001B:\n\tv47 = Unco.ResourceSystem.ResourceService::IsInfinite(this, resourceType);\n\tv51 = v47 == 0;\n\tif (v51) goto L_0033;\nL_0057:\n\treturn returnVal3;\nL_008F:\n\tinterfaceTailCallResult = Unco.ResourceSystem.IResourceRepository::Load(this._repository, resourceType);\nL_FFFFFFFF:\n\treturn interfaceTailCallResult;\n")]
		public double GetAmount(ResourceType resourceType)
		{
			//IL_000f: Expected F8, but got I8
			if (IsInfinite(resourceType))
			{
				return 9.218868437227405E+18;
			}
			if (resourceType >= ResourceType.LevelUpResource)
			{
				if (_runtimeCache.TryGetValue(resourceType, out var value))
				{
					return value;
				}
				return 0.0;
			}
			return _repository.Load(resourceType);
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x81D10B4", Offset = "0x81D10B4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = Unco.ResourceSystem.ResourceService::IsInfinite(this, resourceType);\n\tv23 = v20 == 0;\n\tif (v23) goto L_001A;\n\treturn 1;\nL_001A:\n\tv33 = Unco.ResourceSystem.ResourceService::GetAmount(this, resourceType);\n\tv54 = v33 < amount;\n\tv72 = v33 == v33;\n\tv42 = amount == amount;\n\tv45 = v72 & v42;\n\tv39 = ~v45;\n\tv36 = v54 == v39;\n\treturn v36;\n")]
		public bool IsEnough(ResourceType resourceType, double amount)
		{
			if (IsInfinite(resourceType))
			{
				return true;
			}
			double amount2 = GetAmount(resourceType);
			bool flag = amount2 < amount;
			bool flag2 = amount2 == amount2;
			bool flag3 = amount == amount;
			bool flag4 = flag2 && flag3;
			bool flag5 = !flag4;
			return flag == flag5;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81D0F54", Offset = "0x81D0F54", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv64 = resourceType;\n\t// 51 Box v67 @ X0_v9 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v64 @ stack_-34_v1 (Unco.ResourceSystem.ResourceType)\n\tv124 = System.String::Format(\"[ResourceService] BaseLayer resources do not support infinite mode: {0}\", v67);\n\tgoto L_0042;\nL_0055:\n\tgoto L_0084;\nL_0028:\n\tv54 = resourceType < 0x1F4;\n\tif (v54) goto L_0055;\nL_0042:\n\tUnityEngine.Debug::LogWarning(v124);\n\treturn 0;\nL_0084:\n\tinterfaceTailCallResult = Unco.ResourceSystem.IResourceRepository::LoadInfiniteFlag(this._repository, resourceType);\n\treturn interfaceTailCallResult;\n")]
		public bool IsInfinite(ResourceType resourceType)
		{
			if (resourceType >= ResourceType.LevelUpResource)
			{
				object arg = resourceType;
				string message = $"[ResourceService] BaseLayer resources do not support infinite mode: {arg}";
				Debug.LogWarning(message);
				return false;
			}
			return _repository.LoadInfiniteFlag(resourceType);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81D1110", Offset = "0x81D1110", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = Unco.ResourceSystem.ResourceService::GetAmount(this, resourceType);\n\tv33 = Unco.ResourceSystem.ResourceService::IsInfinite(this, resourceType);\n\treturnBuffer.Amount = 0d;\n\treturnBuffer.IsInfinite = 0;\n\treturnBuffer.ResourceType = 0;\n\tgoto L_0025;\nL_002F:\n\treturnVal1 = System.DateTime::get_UtcNow();\n\treturnBuffer.Timestamp = returnVal1;\n\treturn returnBuffer;\nL_0025:\n\treturnBuffer.ResourceType = resourceType;\n\treturnBuffer.Amount = v28;\n\treturnBuffer.IsInfinite = v33;\n\tgoto L_002F;\n")]
		public ResourceSnapshot GetSnapshot(ResourceType resourceType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::GetSnapshot");
			return default;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81D124C", Offset = "0x81D124C", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv68 = this._config;\n\tv71 = v68.AllowNegativeAmounts == 0;\n\tif (v71) goto L_00AF;\nL_0037:\n\tv76 = Unco.ResourceSystem.ResourceService::GetAmount(this, resourceType);\n\tv132 = this._config;\n\tgoto L_0045;\nL_0045:\n\tv253 = v76 + amount;\n\tv256 = System.Math::Min(v253, v132.MaxAmount);\n\tUnco.ResourceSystem.ResourceService::SaveAmount(this, resourceType, v256);\n\tv112 = context.Source;\n\tUnco.ResourceSystem.ResourceService::PublishEvent(this, resourceType, v76, v256, &v112 @ stack_-80_v3 (System.String));\n\tv288 = amount == 0x7FF0000000000000;\n\tv296 = ~v288;\n\tif (v296) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv139 = 0x8000000000000000;\n\tgoto L_006F;\nL_FFFFFFFF:\n\tv139 = amount;\nL_FFFFFFFF:\n\tv135 = 0x8000000000000000;\n\tgoto L_0081;\nL_FFFFFFFF:\n\tv135 = v256;\nL_0090:\n\tgoto L_00D7;\nL_00AF:\n\tv143 = amount;\n\tv145 = 0xB7D5000 + 0x538;\n\tv148 = \"il2cpp_vm_object_box\"(*([v145 @ X8_v24 (System.Int32)+80]), &v143 @ stack_-80_v5 (System.Double), context, methodInfo, v43, v44, v45, v46, amount, v47, v48, v49, v50, v51, v52, v53);\n\tv157 = resourceType;\n\t// 187 Box v162 @ X0_v25 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v157 @ stack_-84_v2 (Unco.ResourceSystem.ResourceType)\n\tv279 = System.String::Format(\"[ResourceService] Negative amount not allowed: {0} for {1}\", v148, v162);\n\tgoto L_00CF;\nL_0026:\n\tv58 = amount < 0;\n\tv64 = ~v58;\n\tif (v64) goto L_0037;\nL_006F:\n\tv96 = v256 == 0x7FF0000000000000;\n\tv85 = ~v96;\n\tif (v85) goto L_FFFFFFFF;\nL_0081:\n\tgoto L_0090;\nL_00D7:\n\tv317 = context.Source;\n\tUnco.ResourceSystem.IResourceAnalytics::RecordTransaction(this._analytics, resourceType, v139, v135, &v317 @ stack_-80_v4 (System.String));\nL_00CF:\n\tUnityEngine.Debug::LogError(v279);\n\tgoto L_00EE;\nL_00EE:\n\treturn;\n")]
		public unsafe void AddResource(ResourceType resourceType, double amount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::AddResource");
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81D18A0", Offset = "0x81D18A0", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = Unco.ResourceSystem.ResourceService::IsInfinite(this, v166);\n\tv35 = ~v34;\n\tif (v35) goto L_006C;\n\tv37 = context.Source;\n\tUnco.ResourceSystem.ResourceService::PublishEvent(this, v166, 1.7976931348623157E+308d, 1.7976931348623157E+308d, &v37 @ stack_-80_v6 (System.String));\n\tv179 = context.Source;\n\tv58 = amount == 0x7FF0000000000000;\n\tv66 = ~v58;\n\tif (v66) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv83 = 0x8000000000000000;\n\tgoto L_003B;\nL_FFFFFFFF:\n\tv83 = amount;\n\tv302 = 0 - v83;\n\tv306 = *([v214 @ X20_v7 (Unco.ResourceSystem.IResourceAnalytics)]);\n\tv369 = *([v306 @ X8_v25 (Il2CppClass<Unco.ResourceSystem.IResourceAnalytics>)+12E]);\n\tv308 = *([v306 @ X8_v25 (Il2CppClass<Unco.ResourceSystem.IResourceAnalytics>)+12E]) == 0;\n\tif (v308) goto L_0068;\n\tv362 = *([v306 @ X8_v25 (Il2CppClass<Unco.ResourceSystem.IResourceAnalytics>)+B0]) + 8;\n\tv362 = v362 + 0x10;\n\tv352 = v369 - 1;\n\tv332 = v369 != 1;\nL_FFFFFFFF:\n\tv369 = v352;\n\tif (v332) goto L_0053;\nL_0068:\n\tv401 = 0x220C5E0(v214, Unco.ResourceSystem.IResourceAnalytics, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, 0x7FF0000000000000, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00E5;\nL_006C:\n\tv49 = Unco.ResourceSystem.ResourceService::GetAmount(this, v166);\n\tv67 = v49 < amount;\n\tif (v67) goto L_FFFFFFFF;\n\tv77 = v49 - amount;\n\tUnco.ResourceSystem.ResourceService::SaveAmount(this, v166, v77);\n\tv37 = context.Source;\n\tUnco.ResourceSystem.ResourceService::PublishEvent(this, v166, v49, v77, &v37 @ stack_-80_v6 (System.String));\n\tv179 = context.Source;\n\tv224 = amount == 0x7FF0000000000000;\n\tv232 = ~v224;\n\tif (v232) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv310 = 0x8000000000000000;\n\tgoto L_009E;\nL_FFFFFFFF:\n\tv310 = amount;\nL_FFFFFFFF:\n\tv324 = 0x8000000000000000;\n\tgoto L_00B0;\nL_FFFFFFFF:\n\tv324 = v77;\n\tv422 = 0 - v310;\n\tv451 = *([v323 @ X20_v6 (Unco.ResourceSystem.IResourceAnalytics)]);\n\tv493 = *([v451 @ X8_v12 (Il2CppClass<Unco.ResourceSystem.IResourceAnalytics>)+12E]);\n\tv440 = *([v451 @ X8_v12 (Il2CppClass<Unco.ResourceSystem.IResourceAnalytics>)+12E]) == 0;\n\tif (v440) goto L_00DD;\n\tv486 = *([v451 @ X8_v12 (Il2CppClass<Unco.ResourceSystem.IResourceAnalytics>)+B0]) + 8;\n\tv486 = v486 + 0x10;\n\tv478 = v493 - 1;\n\tv458 = v493 != 1;\nL_FFFFFFFF:\n\tv493 = v478;\n\tif (v458) goto L_00C8;\nL_00DD:\n\t;\n\tgoto L_00F5;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_010F;\nL_00E2:\n\t;\nL_00F2:\n\t;\nL_003B:\n\tgoto L_0041;\nL_0053:\n\tv374 = *([v362 @ X10_v13-8]) == Unco.ResourceSystem.IResourceAnalytics;\n\tif (v374) goto L_00E2;\nL_00E5:\n\t;\n\tv37 = v179;\nL_FFFFFFFF:\n\tv101 = 0x7FFFFFFFFFFFFFFF;\nL_FFFFFFFF:\n\tv103 = &v37 @ stack_-80_v6 (System.String);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv168 = v302;\nL_FFFFFFFF:\n\tv441 = v214;\n\tgoto L_0100;\nL_009E:\n\tv316 = v77 == 0x7FF0000000000000;\n\tv311 = ~v316;\n\tif (v311) goto L_FFFFFFFF;\nL_00B0:\n\tgoto L_00B6;\nL_00C8:\n\tv498 = *([v486 @ X10_v7-8]) == Unco.ResourceSystem.IResourceAnalytics;\n\tif (v498) goto L_00F2;\nL_00F5:\n\t;\n\tv37 = v179;\nL_FFFFFFFF:\n\tv101 = v324;\nL_FFFFFFFF:\n\tv103 = &v37 @ stack_-80_v6 (System.String);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv168 = v422;\nL_FFFFFFFF:\n\tv441 = v323;\nL_010F:\n\treturn returnVal1;\nL_0041:\n\tv214 = this._analytics;\nL_0100:\n\tv443 = Unco.ResourceSystem.IResourceAnalytics::RecordTransaction(v441, v166, v168, v101, v103);\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_00B6:\n\tv323 = this._analytics;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool ConsumeResource(ResourceType resourceType, double amount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::ConsumeResource");
			return default;
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81D1B44", Offset = "0x81D1B44", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv63 = this._config;\n\tv66 = v63.AllowNegativeAmounts == 0;\n\tif (v66) goto L_0098;\nL_002F:\n\tv71 = Unco.ResourceSystem.ResourceService::GetAmount(this, resourceType);\n\tUnco.ResourceSystem.ResourceService::SaveAmount(this, resourceType, amount);\n\tv109 = context.Source;\n\tUnco.ResourceSystem.ResourceService::PublishEvent(this, resourceType, v71, amount, &v109 @ stack_-70_v3 (System.String));\n\tv113 = amount - v71;\n\tv235 = v113 == 0x7FF0000000000000;\n\tv243 = ~v235;\n\tif (v243) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv127 = 0x8000000000000000;\n\tgoto L_0058;\nL_FFFFFFFF:\n\tv127 = v113;\nL_FFFFFFFF:\n\tv123 = 0x8000000000000000;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv123 = amount;\nL_0079:\n\tgoto L_00B8;\nL_0098:\n\tv132 = amount;\n\tv134 = 0xB7D5000 + 0x538;\n\tv137 = \"il2cpp_vm_object_box\"(*([v134 @ X8_v22 (System.Int32)+80]), &v132 @ stack_-70_v5 (System.Double), context, methodInfo, v39, v40, v41, v42, amount, v43, v44, v45, v46, v47, v48, v49);\n\tv255 = System.String::Format(\"[ResourceService] Negative amount not allowed: {0}\", v137);\n\tgoto L_00B0;\nL_001E:\n\tv54 = amount < 0;\n\tv60 = ~v54;\n\tif (v60) goto L_002F;\nL_0058:\n\tv88 = amount == 0x7FF0000000000000;\n\tv77 = ~v88;\n\tif (v77) goto L_FFFFFFFF;\nL_006A:\n\tgoto L_0079;\nL_00B8:\n\tv109 = context.Source;\n\tUnco.ResourceSystem.IResourceAnalytics::RecordTransaction(this._analytics, resourceType, v127, v123, &v109 @ stack_-70_v3 (System.String));\nL_00B0:\n\tUnityEngine.Debug::LogError(v255);\n\tgoto L_00CD;\nL_00CD:\n\treturn;\n")]
		public unsafe void SetResource(ResourceType resourceType, double amount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::SetResource");
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81D1D60", Offset = "0x81D1D60", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv64 = resourceType;\n\t// 51 Box v69 @ X0_v26 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v64 @ stack_-60_v5 (Unco.ResourceSystem.ResourceType)\n\tv117 = System.String::Format(\"[ResourceService] BaseLayer resources do not support infinite mode: {0}\", v69);\n\tgoto L_0046;\nL_0050:\n\treturn;\nL_0053:\n\tv72 = Unco.ResourceSystem.ResourceService::IsInfinite(this, resourceType);\n\tv86 = v72 == v335;\n\tif (v86) goto L_0050;\n\tv99 = this._repository;\n\tv137 = *([v99 @ X23_v2 (Unco.ResourceSystem.IResourceRepository)]);\n\tv288 = *([v137 @ X8_v4 (Il2CppClass<Unco.ResourceSystem.IResourceRepository>)+12E]);\n\tv139 = *([v137 @ X8_v4 (Il2CppClass<Unco.ResourceSystem.IResourceRepository>)+12E]) == 0;\n\tif (v139) goto L_0086;\n\tv279 = *([v137 @ X8_v4 (Il2CppClass<Unco.ResourceSystem.IResourceRepository>)+B0]) + 8;\n\tv279 = v279 + 0x10;\n\tv273 = v288 - 1;\n\tv253 = v288 != 1;\n\tv288 = v273;\n\tif (v253) goto L_006F;\nL_0086:\n\t;\n\tv303 = Unco.ResourceSystem.IResourceRepository::SaveInfiniteFlag(v99, resourceType, v335);\n\tv305 = v335 == 0;\n\tif (v305) goto L_00AE;\nL_0090:\n\tv195 = Unco.ResourceSystem.ResourceService::GetAmount(this, resourceType);\n\tv193 = 0x7FEFFFFFFFFFFFFF;\n\tv229 = context.Source;\n\tgoto L_00E0;\nL_0099:\n\tv308 = *([v279 @ X10_v14]) + 3;\n\tv309 = v308 << 4;\n\tv310 = v137 + v309;\n\tv311 = v310 + 0x138;\n\t*([v311 @ X0_v21])(v317, v99, resourceType, v335, *([v311 @ X0_v21+8]), methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv319 = v335 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_0090;\nL_00AE:\n\tgoto L_00D5;\nL_002C:\n\tv60 = resourceType < 0x1F4;\n\tif (v60) goto L_0053;\nL_0046:\n\tUnityEngine.Debug::LogError(v117);\nL_006F:\n\tv293 = *([v279 @ X10_v14-8]) == Unco.ResourceSystem.IResourceRepository;\n\tif (v293) goto L_0099;\nL_00E0:\n\tUnco.ResourceSystem.ResourceService::PublishEvent(this, resourceType, v195, v193, &v229 @ stack_-60_v1 (System.String));\n\treturn;\nL_00D5:\n\tv376 = Unco.ResourceSystem.IResourceRepository::Load(this._repository, resourceType);\n\tv193 = v38;\n\tv195 = 0x7FEFFFFFFFFFFFFF;\n\tv229 = context.Source;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetInfinite(ResourceType resourceType, bool infinite, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::SetInfinite");
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81D1FBC", Offset = "0x81D1FBC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = context.Source;\n\tUnco.ResourceSystem.ResourceService::SetResource(this, resourceType, 0d, &v8 @ stack_-30_v1 (System.String));\n\treturn;\n")]
		public unsafe void ResetResource(ResourceType resourceType, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::ResetResource");
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81D1FF0", Offset = "0x81D1FF0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._isMuted = 1;\n\treturn;\n")]
		public void Mute()
		{
			_isMuted = true;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81D1FFC", Offset = "0x81D1FFC", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv118 = 0xB2A7000 + 0x1A0;\n\tv60 = System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>::GetEnumerator(this._mutedEvents);\n\tv132 = v60._list;\n\tv154 = this.OnResourceChanged == 0;\n\tif (v154) goto L_003B;\n\tSystem.Action`1<Unco.ResourceSystem.ResourceChangedEvent>::Invoke(this.OnResourceChanged, v60.Current);\n\tgoto L_003B;\nL_004A:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v132 @ stack_-48_v4 (System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>));\n\tv98 = 0;\n\tv116 = Il2CppMethodInfo;\nL_004B:\n\tv125 = this._mutedEvents;\n\tv123 = this._mutedEvents == 0;\n\tif (v123) goto L_006B;\n\tSystem.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>::Clear(v125);\n\tv211 = v125.Count < 1;\n\tif (v211) goto L_006A;\nL_006A:\n\treturn;\nL_006B:\n\tv128 = new System.NullReferenceException();\n\tgoto L_0077;\nL_0077:\n\tv168 = v116 != 1;\n\tv183 = v128;\n\tif (v168) goto L_0087;\n\tv174 = 0x8BF5BC4(v128, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv190 = 0x8BF5BF4(v174, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv116 = *([v118 @ X21_v1 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v132 @ stack_-48_v4 (System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>));\n\tv182 = *([v174 @ X0_v12]) == 0;\n\tv98 = *([v174 @ X0_v12]);\n\tif (v182) goto L_004B;\n\tv180 = new System.OutOfMemoryException();\n\tv98 = *([v174 @ X0_v12]);\n\tv183 = v180;\n\treturn;\nL_0020:\n\tv132 = 0;\n\tthis._isMuted = 0;\n\tv47 = this._mutedEvents == 0;\n\tif (v47) goto L_006B;\nL_003B:\n\tv151 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v132 @ stack_-48_v4 (System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>));\n\tv172 = v151 == 0;\n\tif (v172) goto L_004A;\nL_0087:\n\tv186 = 0x3968058(&v98 @ stack_-58 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv192 = 0x8BF0368(v183, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv197 = 0x7C03E68(v192, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Unmute()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::Unmute");
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81D2178", Offset = "0x81D2178", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.OnResourceChanged = 0;\n\tthis.OnResourceChanged_MuteIgnored = 0;\n\treturn;\n")]
		public void Dispose()
		{
			_003COnResourceChanged_003Ek__BackingField = null;
			_003COnResourceChanged_MuteIgnored_003Ek__BackingField = null;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81D14D8", Offset = "0x81D14D8", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tSystem.Collections.Generic.Dictionary`2<Unco.ResourceSystem.ResourceType, System.Double>::set_Item(this._runtimeCache, resourceType, amount);\n\treturn;\nL_0043:\n\tgoto L_0075;\nL_0025:\n\tv59 = resourceType < 0x1F4;\n\tif (v59) goto L_0043;\nL_0075:\n\tUnco.ResourceSystem.IResourceRepository::Save(this._repository, resourceType, amount);\n\treturn;\n")]
		private void SaveAmount(ResourceType resourceType, double amount)
		{
			if (resourceType >= ResourceType.LevelUpResource)
			{
				_runtimeCache[resourceType] = amount;
			}
			else
			{
				_repository.Save(resourceType, amount);
			}
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x81D15E4", Offset = "0x81D15E4", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_002A:\n\treturn;\nL_0032:\n\tv119 = new Unco.ResourceSystem.ResourceChangedEvent();\n\tSystem.Object::.ctor(v119);\n\tv119.ResourceType = resourceType;\n\tv119.PreviousAmount = prev;\n\tv119.NewAmount = newAmt;\n\tv206 = newAmt - prev;\n\tv119.Delta = v206;\n\tv119.<Context>k__BackingField = context.Source;\n\tv119.<Context>k__BackingField.SuppressEvents = context.SuppressEvents;\n\tv212 = this.OnResourceChanged_MuteIgnored == 0;\n\tif (v212) goto L_0054;\n\tSystem.Action`1<Unco.ResourceSystem.ResourceChangedEvent>::Invoke(this.OnResourceChanged_MuteIgnored, v119);\n\tv168 = this._mutedEvents;\n\tgoto L_009E;\nL_0080:\n\t;\n\tv101 = this.OnResourceChanged == 0;\n\tif (v101) goto L_002A;\n\tSystem.Action`1<Unco.ResourceSystem.ResourceChangedEvent>::Invoke(this.OnResourceChanged, v119);\n\treturn;\nL_009E:\n\tSystem.Collections.Generic.List`1<Unco.ResourceSystem.ResourceChangedEvent>::Add(v168, v119);\n\treturn;\nL_001F:\n\tv53 = context.SuppressEvents == 0;\n\tif (v53) goto L_0032;\nL_0054:\n\tv58 = this._isMuted != 1;\n\tif (v58) goto L_0080;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PublishEvent(ResourceType resourceType, double prev, double newAmt, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::PublishEvent");
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81D179C", Offset = "0x81D179C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tgoto L_004C;\nL_004C:\n\tv136 = context.Source;\n\tUnco.ResourceSystem.IResourceAnalytics::RecordTransaction(this._analytics, resourceType, delta, newAmount, &v136 @ stack_-60_v1 (System.String));\n\treturn;\n")]
		private unsafe void RecordAnalytics(ResourceType resourceType, long delta, long newAmount, TransactionContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceService::RecordAnalytics");
		}
	}
}
