using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.ResourceSystem
{
	[CreateAssetMenu(fileName = "ResourceConfig", menuName = "ScriptableObjects/ResourceSystem/ResourceConfig", order = 1)]
	[Token(Token = "0x2000005")]
	public class ResourceConfig : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x2000006")]
		public struct InitialAmount
		{
			[Token(Token = "0x400000A")]
			[FieldOffset(Offset = "0x0")]
			public ResourceType Type;

			[Token(Token = "0x400000B")]
			[FieldOffset(Offset = "0x8")]
			public double Amount;
		}

		[CompilerGenerated]
		[Token(Token = "0x2000008")]
		private sealed class _003C_003Ec__DisplayClass13_0
		{
			[Token(Token = "0x400000D")]
			[FieldOffset(Offset = "0x10")]
			public ResourceType type;

			[Token(Token = "0x600000E")]
			[Address(RVA = "0x81D08B8", Offset = "0x81D08B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass13_0()
			{
			}

			internal bool _003COnValidate_003Eb__0(InitialAmount x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ResourceConfig._003C_003Ec__DisplayClass13_0::_003COnValidate_003Eb__0");
				return default;
			}
		}

		[Header("Initial Balances")]
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x18")]
		private List<InitialAmount> m_initialAmounts;

		[Header("Validation")]
		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x20")]
		private bool m_allowNegativeAmounts;

		[SerializeField]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x28")]
		private double m_maxAmount;

		[NonSerialized]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x30")]
		public Dictionary<ResourceType, double> _remoteOverrides;

		[Token(Token = "0x17000001")]
		public IReadOnlyList<InitialAmount> InitialAmounts
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x81D0280", Offset = "0x81D0280", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_initialAmounts;\n")]
			get
			{
				return m_initialAmounts;
			}
		}

		[Token(Token = "0x17000002")]
		public bool AllowNegativeAmounts
		{
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x81D0288", Offset = "0x81D0288", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.AllowNegativeAmounts;\n")]
			get
			{
				return m_allowNegativeAmounts;
			}
		}

		[Token(Token = "0x17000003")]
		public double MaxAmount
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x81D0290", Offset = "0x81D0290", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxAmount;\n")]
			get
			{
				return m_maxAmount;
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81D0298", Offset = "0x81D0298", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._remoteOverrides = overrides;\n\treturn;\n")]
		public void ApplyRemoteOverrides(Dictionary<ResourceType, double> overrides)
		{
			_remoteOverrides = overrides;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x81D02A0", Offset = "0x81D02A0", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv48.resourceType = resourceType;\n\tv62 = this._remoteOverrides == 0;\n\tif (v62) goto L_0046;\n\tv92 = System.Collections.Generic.Dictionary`2<Unco.ResourceSystem.ResourceType, System.Double>::TryGetValue(this._remoteOverrides, resourceType, &v90 @ stack_-38_v4 (System.Double));\n\tv98 = ~v92;\n\tif (v98) goto L_0046;\n\treturn v90;\nL_0046:\n\tv72 = new System.Predicate`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>();\n\tSystem.Predicate`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::.ctor(v72, v48, Il2CppMethodInfo);\n\tv116 = System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::Find(this.m_initialAmounts, v72);\n\treturn v72;\nL_0025:\n\tv48 = new Unco.ResourceSystem.ResourceConfig+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v48);\n")]
		public double GetInitialAmount(ResourceType resourceType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceConfig::GetInitialAmount");
			return default;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81D03E0", Offset = "0x81D03E0", Length = "0x4D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv86 = System.Type::GetTypeFromHandle(Unco.ResourceSystem.ResourceType);\n\tv74 = *([v60 @ X21_v3 (System.Int32)+98]);\n\tv76 = *([v74 @ X8_v52+E4]) == 0;\n\tv95 = v86;\n\tif (v76) goto L_0148;\nL_004A:\n\tv114 = System.Enum::GetValues(v86);\nL_004E:\n\tv120 = System.Array::GetEnumerator(v114);\n\tv139 = v120 == 0;\n\tif (v139) goto L_014D;\n\tv253 = v120;\n\tgoto L_006F;\nL_0067:\n\tUnityEngine.Debug::Log(v809);\nL_0069:\n\tv212 = v134 == 0;\n\tv253 = v134;\n\tif (v212) goto L_014D;\nL_006F:\n\tgoto L_0095;\n\tv521 = new Unco.ResourceSystem.ResourceConfig+<>c__DisplayClass13_0();\n\tSystem.Object::.ctor(v521);\n\tv351 = v134 == 0;\n\tif (v351) goto L_014F;\n\tgoto L_00CC;\n\tv352 = v745 == 0;\n\tif (v352) goto L_0153;\n\t// -1 IsInst v157_asT @ TEMPCOND_v14 (Unco.ResourceSystem.ResourceType), typeof(Unco.ResourceSystem.ResourceType), v745 @ X0_v45 (System.Object)\n\tv157 = v157_asT == 0;\n\tif (v157) goto L_0151;\n\tv749 = \"il2cpp_vm_object_unbox\"(v745, Unco.ResourceSystem.ResourceType, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv521.type = *([v749 @ X0_v48]);\n\tv300 = *([v749 @ X0_v48]) == -1;\n\tif (v300) goto L_0069;\n\tv753 = new System.Predicate`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>();\n\tSystem.Predicate`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::.ctor(v753, v521, Il2CppMethodInfo);\n\tv354 = this.m_initialAmounts == 0;\n\tif (v354) goto L_0155;\n\tv772 = System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::Exists(this.m_initialAmounts, v753);\n\tv781 = v772 == 0;\n\tv775 = ~v781;\n\tv147 = 0;\n\tif (v775) goto L_0069;\n\tv782 = this.m_initialAmounts;\n\tgoto L_0124;\nL_0124:\n\tSystem.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::Add(v782, v521.type);\n\tv147 = Il2CppMethodInfo;\n\tv754 = v521.type;\n\t// 297 Box v804 @ X0_v57 (System.Object), typeof(Unco.ResourceSystem.ResourceType), &v754 @ stack_-8C_v6 (Unco.ResourceSystem.ResourceType)\n\tv809 = System.String::Format(\"[ResourceConfig] Added missing resource type {0} with initial amount 0\", v804);\n\tgoto L_0067;\nL_013D:\n\tv86 = System.Type::GetTypeFromHandle(Unco.ResourceSystem.ResourceType);\n\tv90 = *([v60 @ X21_v3 (System.Int32)+98]);\n\tv101 = *([v90 @ X8_v19+E4]) == 0;\n\tv88 = ~v101;\n\tv95 = v86;\n\tif (v88) goto L_004A;\nL_0148:\n\tv114 = System.Enum::GetValues(v95);\n\tv128 = v114 == 0;\n\tv116 = ~v128;\n\tif (v116) goto L_004E;\n\tv127 = new System.NullReferenceException();\nL_014D:\n\tv219 = new System.NullReferenceException();\n\tv147 = 0;\n\tv555 = Il2CppMethodInfo;\n\tv477 = &v57 @ stack_-70_v1;\n\tv479 = &v134 @ stack_-68_v6 (System.Collections.IEnumerator);\n\tv330 = 0;\n\tgoto L_0158;\nL_014F:\n\tthrow v521;\nL_0151:\n\tv346 = new System.InvalidCastException();\n\tv555 = 0;\n\tv477 = &v57 @ stack_-70_v1;\n\tv479 = &v134 @ stack_-68_v6 (System.Collections.IEnumerator);\n\tv330 = 0;\n\tv337 = 0;\n\tgoto L_0158;\nL_0153:\n\tv347 = new System.NullReferenceException();\n\tv555 = 0;\n\tv477 = &v57 @ stack_-70_v1;\n\tv479 = &v134 @ stack_-68_v6 (System.Collections.IEnumerator);\n\tv330 = 0;\n\tv337 = Unco.ResourceSystem.ResourceType;\n\tv488 = v346;\n\tgoto L_0158;\nL_0155:\n\tthrow v753;\nL_0158:\n\t// 344 Interrupt\n\tgoto L_016E;\nL_016E:\n\tv407 = v337 != 1;\n\tif (v407) goto L_01BF;\n\tv431 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv517 = 0x8BF5BF4(v431, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv330 = *([v431 @ X0_v20]);\nL_0179:\n\tv735 = 0x21C11D0(*([v479 @ stack_-80_v2]), System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v477 @ stack_-78_v2]) = v735;\n\tv548 = v735 == 0;\n\tif (v548) goto L_01AB;\n\tv550 = *([v735 @ X0_v15 (System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>)]);\n\tv696 = *([v550 @ X8_v9 (Il2CppClass<System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>>)+12E]);\n\tv552 = *([v550 @ X8_v9 (Il2CppClass<System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>>)+12E]) == 0;\n\tif (v552) goto L_019F;\n\tv695 = *([v550 @ X8_v9 (Il2CppClass<System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>>)+B0]) + 8;\n\tv695 = v695 + 0x10;\n\tv652 = v696 - 1;\n\tv632 = v696 != 1;\n\tv696 = v652;\n\tif (v632) goto L_0185;\nL_019F:\n\tv655 = System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::Exists(v735, System.IDisposable);\n\tv555 = 0;\n\tv571 = v655;\n\tgoto L_01A9;\nL_01A4:\n\tv731 = *([v695 @ X10_v8]) << 4;\n\tv732 = v550 + v731;\n\tv571 = v732 + 0x138;\n\treturn;\nL_01BC:\n\tv488 = new System.OutOfMemoryException();\nL_01BF:\n\tv502 = 0x3173D6C(&v330 @ stack_-88_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv519 = 0x8BF0368(v488, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv546 = 0x7C03E68(v519, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_003A:\n\tv57 = 0;\n\tv60 = 0xB7D5000 + 0x538;\n\tv61 = *([v60 @ X21_v3 (System.Int32)+E0]);\n\tv63 = *([v61 @ X0_v2+E4]) == 0;\n\tif (v63) goto L_013D;\nL_0095:\n\tv512 = System.Collections.IEnumerator::MoveNext(v253);\n\tv514 = v512 == 0;\n\tv555 = 0;\n\tv477 = &v57 @ stack_-70_v1;\n\tv479 = &v134 @ stack_-68_v6 (System.Collections.IEnumerator);\n\tv330 = 0;\n\tif (v514) goto L_0179;\nL_00CC:\n\tv745 = System.Collections.IEnumerator::get_Current(v134);\n\tv746 = v521 == 0;\n\tif (v746) goto L_0153;\nL_01AB:\n\tv574 = v330 == 0;\n\tv491 = ~v574;\n\tif (v491) goto L_01BC;\nL_0185:\n\t;\n\tv701 = *([v695 @ X10_v8-8]) == System.IDisposable;\n\tif (v701) goto L_01A4;\nL_01A9:\n\tv571.m_value(v569, v735, *([v571 @ X8_v10 (System.Boolean)+8]), v555, v147, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ResourceConfig::OnValidate");
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81D08C0", Offset = "0x81D08C0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tthis.MaxAmount = 1000000000000000d;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>();\n\tSystem.Collections.Generic.List`1<Unco.ResourceSystem.ResourceConfig+InitialAmount>::.ctor(v48);\n\tthis.m_initialAmounts = v48;\n")]
		public ResourceConfig()
		{
			List<InitialAmount> initialAmounts = new List<InitialAmount>();
			m_initialAmounts = initialAmounts;
			m_maxAmount = 1000000000000000.0;
		}
	}
}
