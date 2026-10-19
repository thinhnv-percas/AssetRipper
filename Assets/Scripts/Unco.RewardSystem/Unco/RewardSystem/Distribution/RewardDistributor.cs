using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ResourceSystem;
using Unco.RewardSystem.SequenceElements;
using Unco.RewardSystem.SimpleSequenceSystem;

namespace Unco.RewardSystem.Distribution
{
	[Token(Token = "0x2000032")]
	public static class RewardDistributor
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000033")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000062")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000063")]
			public static Func<ShopItemData, int> _003C_003E9__0_0;

			[Token(Token = "0x60000D0")]
			[Address(RVA = "0x81DCBEC", Offset = "0x81DCBEC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.RewardSystem.Distribution.RewardDistributor+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60000D1")]
			[Address(RVA = "0x81DCC50", Offset = "0x81DCC50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal int _003CDistribute_003Eb__0_0(ShopItemData itemData)
			{
				if (itemData != null)
				{
					int num = 1;
					if (itemData is ResourceItemData)
					{
						return 1 + 1;
					}
					return 1;
				}
				return 1;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000034")]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x4000064")]
			[FieldOffset(Offset = "0x10")]
			public ResourceItemData resource;

			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x81DCBAC", Offset = "0x81DCBAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass2_0()
			{
			}

			internal bool _003CMergeItems_003Eb__0(ResourceItemData i)
			{
				ResourceItemData resourceItemData = resource;
				int num = i.ResourceType - resourceItemData.ResourceType;
				return num == 0;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000035")]
		private sealed class _003CExtract_003Ed__3 : IEnumerable<ShopItemData>, IEnumerable, IEnumerator<ShopItemData>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000065")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000066")]
			[FieldOffset(Offset = "0x18")]
			private ShopItemData _003C_003E2__current;

			[Token(Token = "0x4000067")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x4000068")]
			[FieldOffset(Offset = "0x28")]
			private IEnumerable<ShopItemData> data;

			[Token(Token = "0x4000069")]
			[FieldOffset(Offset = "0x30")]
			public IEnumerable<ShopItemData> _003C_003E3__data;

			[Token(Token = "0x400006A")]
			[FieldOffset(Offset = "0x38")]
			private IEnumerator<ShopItemData> _003C_003E7__wrap1;

			[Token(Token = "0x400006B")]
			[FieldOffset(Offset = "0x40")]
			private List<ShopItemData>.Enumerator _003C_003E7__wrap2;

			[Token(Token = "0x1700000E")]
			ShopItemData IEnumerator<ShopItemData>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000DA")]
				[Address(RVA = "0x81DD4B0", Offset = "0x81DD4B0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000F")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000DC")]
				[Address(RVA = "0x81DD4F8", Offset = "0x81DD4F8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x81DCBB4", Offset = "0x81DCBB4", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CExtract_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x81DCD10", Offset = "0x81DCD10", Length = "0x1B4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this;\n\tv17 = this.<>1__state + 4;\n\tv18 = v17 < 6;\n\tv19 = ~v18;\n\tv20 = v17 - 6;\n\tv22 = v20 == 0;\n\tv28 = 1 << v17;\n\tv30 = v28 & 0x63;\n\tv31 = ~v19;\n\tv32 = v31 | v22;\n\tv33 = ~v32;\n\tif (v33) goto L_FFFFFFFF;\n\tv51 = v30 == 0;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv51 = 1;\n\tv55 = &v14 @ stack_-38_v1 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3);\n\tv60 = this.<>1__state - 1;\n\tv62 = v60 == 0;\n\tv67 = ~v62;\n\tv68 = ~v67;\n\tif (v68) goto L_FFFFFFFF;\n\tv130 = this.<>1__state - -4;\n\tv183 = v130 == 0;\n\tgoto L_004A;\nL_FFFFFFFF:\n\tv183 = 1;\n\tgoto L_005B;\nL_FFFFFFFF:\n\tv228 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv237 = *([v284 @ X8_v24]);\nL_FFFFFFFF:\n\tv91 = 0;\nL_FFFFFFFF:\n\tv95 = 0;\n\tgoto L_0076;\nL_0069:\n\tv237 = *([v55 @ X8_v5]);\nL_FFFFFFFF:\n\tv91 = 0;\nL_FFFFFFFF:\n\tv95 = 0;\n\tgoto L_0076;\nL_0074:\n\t*([B79A143]) = 1;\n\tgoto L_00A6;\nL_00B1:\n\treturn;\nL_00B3:\n\tv341 = new System.OutOfMemoryException();\n\tv158 = v79 != 1;\n\tif (v158) goto L_00CF;\n\tv373 = 0x8BF5BC4(v341, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv233 = 0x8BF5BF4(v373, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv378 = &v14 @ stack_-38_v1 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3);\n\tv379 = *([B79A143]) & 1;\n\tv236 = v379 == 0;\nL_FFFFFFFF:\n\tv228 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv237 = *([v284 @ X8_v24]);\nL_FFFFFFFF:\n\tv91 = 0;\nL_FFFFFFFF:\n\tv95 = 0;\n\tif (v236) goto L_0074;\nL_FFFFFFFF:\n\tv228 = v79;\nL_FFFFFFFF:\n\tv237 = *([v378 @ X8_v9]);\nL_FFFFFFFF:\n\tv91 = *([v373 @ X0_v12]);\nL_FFFFFFFF:\n\tv95 = *([v373 @ X0_v12]);\n\tgoto L_0076;\n\treturn;\nL_002B:\n\tif (v51) goto L_00B1;\nL_004A:\n\tv187 = ~v183;\n\tif (v187) goto L_0069;\nL_005B:\n\tthis.<>1__state = -3;\n\tv224 = this + 0x40;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v224);\n\tv284 = &v14 @ stack_-38_v1 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3);\n\tv285 = *([B79A143]) & 1;\n\tv235 = v285 == 0;\nL_FFFFFFFF:\n\tv91 = 0;\nL_FFFFFFFF:\n\tv95 = 0;\n\tif (v235) goto L_0074;\nL_0076:\n\t*([v237 @ X20_v6+10]) = -1;\n\tv283 = *([v237 @ X20_v6+38]) == 0;\nL_FFFFFFFF:\n\tv79 = v228;\n\tif (v283) goto L_00A7;\nL_00A6:\n\tSystem.IDisposable::Dispose(*([v237 @ X20_v6+38]));\nL_FFFFFFFF:\n\tv79 = 0;\nL_00CF:\n\tv375 = 0x3968AB4(&v95 @ stack_-48_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = 0x8BF0368(v341, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv149 = 0x7C03E68(v377, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00A7:\n\tv310 = v91 == 0;\n\tv86 = ~v310;\n\tif (v86) goto L_00B3;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RewardDistributor._003CExtract_003Ed__3::Dispose");
			}

			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x81DCEC4", Offset = "0x81DCEC4", Length = "0x4CC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tv83 = this.<>1__state == 1;\nL_FFFFFFFF:\n\tv206 = this;\n\tif (v83) goto L_00FF;\n\tv138 = this.<>1__state == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_FFFFFFFF;\n\tthis.<>1__state = -1;\n\tv289 = this.data == 0;\n\tif (v289) goto L_0092;\n\tgoto L_0083;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_01C0;\nL_0090:\n\tv249 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv577 = v247;\n\tgoto L_0097;\nL_0092:\n\tv332 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv577 = this.data;\n\tgoto L_0097;\nL_0097:\n\t// 151 Interrupt\n\tgoto L_00C5;\n\tv495 = Unco.RewardSystem.MultiPackData;\n\tv725 = *([v495 @ X8_v12 (Il2CppClass<Unco.RewardSystem.MultiPackData>)+130]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v177_asT @ TEMPCOND_v6 (Unco.RewardSystem.MultiPackData), typeof(Unco.RewardSystem.MultiPackData), v861 @ X0_v11 (Unco.RewardSystem.ShopItemData)\n\tv177 = v177_asT == 0;\n\tif (v177) goto L_0188;\n\tv203 = *([v861 @ X0_v11 (Unco.RewardSystem.ShopItemData)+40]) == 0;\n\tif (v203) goto L_01C3;\n\tv911 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(*([v861 @ X0_v11 (Unco.RewardSystem.ShopItemData)+40]));\n\tv911.<>7__wrap2 = *([v911 @ X0_v18 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3)]);\n\t*([v911 @ X0_v18 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3)+50]) = v911.<>1__state;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv206 = v911;\n\tgoto L_0116;\nL_0125:\n\tgoto L_014B;\n\tgoto L_015D;\n\tv750 = *([v753 @ X19_v19 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>)]);\n\tv728 = *([v750 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)+12E]);\n\tv749 = *([v750 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)+12E]) == 0;\nL_FFFFFFFF:\n\tv797 = 0;\n\tif (v749) goto L_FFFFFFFF;\n\tv725 = *([v750 @ X8_v28 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)+B0]) + 8;\n\tv797 = v725 + 0x10;\n\tv867 = v728 - 1;\n\tv865 = v728 != 1;\nL_FFFFFFFF:\n\tv725 = v797;\nL_FFFFFFFF:\n\tv728 = v867;\n\tif (v865) goto L_016F;\nL_FFFFFFFF:\n\t;\n\tgoto L_01AA;\nL_0188:\n\tv63.<>2__current = v861;\n\tv63.<>1__state = 2;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_01C0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv753 = 0;\n\tgoto L_019E;\nL_0192:\n\t;\n\tv63.<>2__current = *([v63 @ stack_-58_v2 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3)+50]);\n\tv63.<>1__state = 1;\nL_FFFFFFFF:\n\tv753 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_01C0;\nL_019E:\n\tv644 = &v63 @ stack_-58_v2 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3);\n\tv646 = Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3::System.IDisposable.Dispose(*([v644 @ X8_v31 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)]));\nL_FFFFFFFF:\n\tv750 = &v63 @ stack_-58_v2 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3);\n\tthrow System.OutOfMemoryException;\nL_01A4:\n\t;\nL_FFFFFFFF:\n\t;\nL_01C0:\n\treturn returnVal1;\nL_01C1:\n\tv489 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv577 = v577.<>7__wrap1;\n\tgoto L_0097;\nL_01C3:\n\tv490 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv577 = v577.<>7__wrap1;\n\tgoto L_0097;\nL_003D:\n\tv71 = this.<>1__state == 2;\nL_FFFFFFFF:\n\tv129 = this;\n\tif (v71) goto L_008B;\nL_00FF:\n\tv206.<>1__state = -4;\n\tv210 = v206 + 0x40;\n\tv211 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(v210);\n\tv293 = v211 == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_0192;\nL_0083:\n\tv665 = System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>::GetEnumerator(this.data);\n\tv63.<>7__wrap1 = v665;\nL_FFFFFFFF:\n\tv129 = v63;\nL_00C5:\n\tv861 = System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>::get_Current(v577.<>7__wrap1);\n\tv862 = v861 == 0;\nL_FFFFFFFF:\n\tv725 = 0;\n\tif (v862) goto L_0188;\nL_0116:\n\tv63.<>1__state = -3;\n\tv242 = v63 + 0x40;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v242);\n\t*([v63 @ stack_-58_v2 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3)+48]) = 0;\n\t*([v63 @ stack_-58_v2 (Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3)+50]) = 0;\n\tv63.<>7__wrap2 = 0;\n\tv247 = v63.<>7__wrap1;\n\tv244 = v63.<>7__wrap1 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv279 = v63.<>7__wrap1;\n\tif (v244) goto L_0090;\nL_014B:\n\tv573 = System.Collections.IEnumerator::MoveNext(v279);\n\tv588 = v573 == 0;\n\tv575 = ~v588;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv577 = v63;\n\tif (v575) goto L_0099;\nL_015D:\n\tv63.<>1__state = -1;\n\tv753 = v63.<>7__wrap1;\n\tv707 = v63.<>7__wrap1 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv725 = 0;\n\tif (v707) goto L_01AD;\nL_016F:\n\tv740 = *([v725 @ X10_v15 (System.Int32)-8]) == System.IDisposable;\nL_FFFFFFFF:\n\t;\n\tif (v740) goto L_01A4;\nL_01AA:\n\tv810 = System.IDisposable::Dispose(v753);\nL_008B:\n\tv129.<>1__state = -3;\n\tv247 = v129.<>7__wrap1;\n\tv133 = v129.<>7__wrap1 == 0;\n\tv134 = ~v133;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv279 = v129.<>7__wrap1;\n\tif (v134) goto L_0125;\nL_0099:\n\tv492 = v577.<>7__wrap1 == 0;\n\tif (v492) goto L_01C1;\nL_01AD:\n\tv63.<>7__wrap1 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv753 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_019E;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RewardDistributor._003CExtract_003Ed__3::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x81DD3EC", Offset = "0x81DD3EC", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv44 = *([v39 @ X19_v2 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>)]);\n\tv151 = *([v44 @ X8_v6 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)+12E]);\n\tv46 = *([v44 @ X8_v6 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)+12E]) == 0;\n\tif (v46) goto L_0043;\n\tv120 = *([v44 @ X8_v6 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>>)+B0]) + 8;\n\tv120 = v120 + 0x10;\n\tv87 = v151 - 1;\n\tv57 = v151 != 1;\n\tv151 = v87;\n\tif (v57) goto L_0025;\nL_0043:\n\tSystem.IDisposable::Dispose(this.<>7__wrap1);\nL_0043:\n\treturn;\nL_0049:\n\treturn;\nL_004B:\n\tv94 = *([v120 @ X10_v4]) << 4;\n\tv132 = v44 + v94;\n\tv154 = v132 + 0x138;\n\t// 86 IndirectJump [v154 @ X0_v5], this.<>7__wrap1 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>), this.<>7__wrap1 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>), [v154 @ X0_v5+8], [v154 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0013:\n\tthis.<>1__state = -1;\n\tv39 = this.<>7__wrap1;\n\tv40 = this.<>7__wrap1 == 0;\n\tif (v40) goto L_0049;\nL_0025:\n\tv112 = *([v120 @ X10_v4-8]) == System.IDisposable;\n\tif (v112) goto L_004B;\n")]
			private void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RewardDistributor._003CExtract_003Ed__3::_003C_003Em__Finally1");
			}

			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x81DD390", Offset = "0x81DD390", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -3;\n\tv46 = this + 0x40;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally2()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RewardDistributor._003CExtract_003Ed__3::_003C_003Em__Finally2");
			}

			[DebuggerHidden]
			[Token(Token = "0x60000DB")]
			[Address(RVA = "0x81DD4B8", Offset = "0x81DD4B8", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000DD")]
			[Address(RVA = "0x81DD500", Offset = "0x81DD500", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv52 = System.Environment::get_CurrentManagedThreadId();\n\tv54 = this.<>l__initialThreadId != v52;\n\tif (v54) goto L_0033;\n\tthis.<>1__state = 0;\n\tv95 = this;\n\tgoto L_003E;\nL_0033:\n\tv76 = new Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv82 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v82;\n\tv95 = v76;\nL_001D:\n\tv49 = this.<>1__state != -2;\n\tif (v49) goto L_0033;\nL_003E:\n\tv95.data = this.<>3__data;\n\treturn v95;\n")]
			IEnumerator<ShopItemData> IEnumerable<ShopItemData>.GetEnumerator()
			{
				_003CExtract_003Ed__3 _003CExtract_003Ed__4;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CExtract_003Ed__4 = this;
						goto IL_00b5;
					}
				}
				_003CExtract_003Ed__3 _003CExtract_003Ed__5 = (_003CExtract_003Ed__3)FormatterServices.GetUninitializedObject(typeof(_003CExtract_003Ed__3));
				_003CExtract_003Ed__5._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CExtract_003Ed__5._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CExtract_003Ed__4 = _003CExtract_003Ed__5;
				goto IL_00b5;
				IL_00b5:
				_003CExtract_003Ed__4.data = _003C_003E3__data;
				return _003CExtract_003Ed__4;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000DE")]
			[Address(RVA = "0x81DD5A8", Offset = "0x81DD5A8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3::System.Collections.Generic.IEnumerable<Unco.RewardSystem.ShopItemData>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ShopItemData>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x81DBDD8", Offset = "0x81DBDD8", Length = "0x4B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0047;\n\tgoto L_0065;\nL_0076:\n\tv121 = System.Linq.Enumerable::OrderBy(data, v116);\n\tv134 = System.Linq.Enumerable::ToList(v121);\n\tv142 = Unco.RewardSystem.Distribution.RewardDistributor::MergeItems(v134);\n\tv148 = v142 == 0;\n\tif (v148) goto L_0175;\n\tv160 = System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::GetEnumerator(v142);\n\tv264 = v160.Current;\n\tv267 = v160._list;\n\tv274 = animateCurrency == 0;\n\tif (v274) goto L_00E6;\n\tv278 = v69 == 0;\n\tif (v278) goto L_0130;\n\tv388 = v160.Current == 0;\n\tif (v388) goto L_00A0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v339_asT @ TEMPCOND_v11 (Unco.RewardSystem.ResourceItemData), typeof(Unco.RewardSystem.ResourceItemData), v160.Current (Unco.RewardSystem.ShopItemData)\n\tv339 = v339_asT == 0;\n\tif (v339) goto L_00A0;\n\tv633 = new Unco.RewardSystem.SequenceElements.ResourceAnim();\n\tSystem.Object::.ctor(v633);\n\tv357 = v264.Amount == 0x7FF0000000000000;\n\tv330 = ~v357;\n\tif (v330) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv391 = 0xFFFFFFFF80000000;\n\tgoto L_00DC;\nL_FFFFFFFF:\n\tv391 = v264.Amount;\nL_00EE:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v267 @ stack_-90_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>));\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv520 = v142;\nL_00F1:\n\tv524 = callOnPurchase == 0;\n\tif (v524) goto L_0129;\n\tv532 = System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::GetEnumerator(v520);\n\tv267 = v532._list;\n\tv644 = Unco.RewardSystem.ShopItemData::OnPurchase(v532.Current);\n\tgoto L_010A;\nL_0118:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v267 @ stack_-90_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>));\nL_0129:\n\treturn v69;\n\tv438 = v160.Current == 0;\n\tif (v438) goto L_0130;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v399_asT @ TEMPCOND_v8 (Unco.RewardSystem.ResourceItemData), typeof(Unco.RewardSystem.ResourceItemData), v160.Current (Unco.RewardSystem.ShopItemData)\n\tv399 = v399_asT == 0;\n\tif (v399) goto L_0130;\n\tv639 = new Unco.RewardSystem.SequenceElements.ResourceAnim();\n\tSystem.Object::.ctor(v639);\n\tv662 = v264.Amount == 0x7FF0000000000000;\n\tv670 = ~v662;\n\tif (v670) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv678 = 0xFFFFFFFF80000000;\n\tgoto L_016F;\nL_FFFFFFFF:\n\tv678 = v264.Amount;\nL_01A4:\n\tv291 = Il2CppMethodInfo != 1;\nL_FFFFFFFF:\n\tv325 = v256;\n\tif (v291) goto L_01B5;\n\tv314 = 0x8BF5BC4(v256, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv445 = 0x8BF5BF4(v314, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v228);\n\tv322 = *([v314 @ X0_v20]) == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv520 = data;\n\tif (v322) goto L_00F1;\n\tv320 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv159 = *([v314 @ X0_v20]);\nL_FFFFFFFF:\n\tv325 = v320;\n\treturn returnVal1;\nL_0047:\n\tv69 = new Unco.RewardSystem.SimpleSequenceSystem.USequence();\n\tUnco.RewardSystem.SimpleSequenceSystem.USequence::.ctor(v69);\n\tgoto L_0057;\nL_0057:\n\tv93 = v91.<>9__0_0 == 0;\n\tv94 = ~v93;\nL_FFFFFFFF:\n\tv116 = v91.<>9__0_0;\n\tif (v94) goto L_0076;\nL_0065:\n\tv132 = new System.Func`2<Unco.RewardSystem.ShopItemData, System.Int32>();\n\tSystem.Func`2<Unco.RewardSystem.ShopItemData, System.Int32>::.ctor(v132, v127.<>9, Il2CppMethodInfo);\n\tv146.<>9__0_0 = v132;\nL_FFFFFFFF:\n\tv116 = v132;\nL_0175:\n\tv256 = new System.NullReferenceException();\n\tgoto L_01A4;\nL_00A0:\n\tv385 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v267 @ stack_-90_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>));\n\tv449 = v385 == 0;\n\tif (v449) goto L_00EE;\nL_00DC:\n\tv633.ResourceType = *([v264 @ stack_-98_v6 (Unco.RewardSystem.ShopItemData)+40]);\n\tv633.Amount = v391;\n\tv386 = Unco.RewardSystem.SimpleSequenceSystem.USequence::Append(v69, v633);\n\tgoto L_00A0;\nL_00E6:\n\tv309 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v267 @ stack_-90_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>));\n\tv443 = v309 == 0;\n\tv311 = ~v443;\n\tif (v311) goto L_00E6;\nL_010A:\n\tv650 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v267 @ stack_-90_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>));\n\tv560 = v650 == 0;\n\tif (v560) goto L_0118;\nL_0130:\n\tv436 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v267 @ stack_-90_v7 (System.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>));\n\tv450 = ~v436;\n\tif (v450) goto L_00EE;\nL_016F:\n\tv639.ResourceType = *([v264 @ stack_-98_v6 (Unco.RewardSystem.ShopItemData)+40]);\n\tv639.Amount = v678;\n\tthrow v639;\nL_01B5:\n\tv328 = 0x31872E4(&v159 @ stack_-A8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv447 = 0x8BF0368(v325, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v447, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static USequence Distribute(IEnumerable<ShopItemData> data, bool callOnPurchase = true, bool animateCurrency = true)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardDistributor::Distribute");
			return default;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x81DCA84", Offset = "0x81DCA84", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv51.<>l__initialThreadId = v56;\n\tv51.<>3__data = data;\n\treturnVal1 = Unco.RewardSystem.Distribution.RewardDistributor::Distribute(v51, callOnPurchase, animateCurrency);\n\treturn returnVal1;\nL_001B:\n\tv51 = new Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3();\n\tSystem.Object::.ctor(v51);\n\tv51.<>1__state = -2;\n\tv56 = System.Environment::get_CurrentManagedThreadId();\n")]
		public static USequence ExtractAndDistribute(IEnumerable<ShopItemData> data, bool callOnPurchase = true, bool animateCurrency = true)
		{
			_003CExtract_003Ed__3 _003CExtract_003Ed__4 = new _003CExtract_003Ed__3(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CExtract_003Ed__4._003C_003El__initialThreadId = currentManagedThreadId;
			_003CExtract_003Ed__4._003C_003E3__data = data;
			return Distribute(_003CExtract_003Ed__4, callOnPurchase, animateCurrency);
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x81DC288", Offset = "0x81DC288", Length = "0x7FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv86 = *([v75 @ X0_v5 (System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>)]);\n\tv309 = *([v86 @ X8_v52 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+12E]);\n\tv89 = *([v86 @ X8_v52 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+12E]) == 0;\n\tif (v89) goto L_007A;\n\tv308 = *([v86 @ X8_v52 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+B0]) + 8;\n\tv308 = v308 + 0x10;\n\tv240 = v309 - 1;\n\tv220 = v309 != 1;\nL_FFFFFFFF:\n\tv309 = v240;\n\tif (v220) goto L_0065;\nL_007A:\n\tv243 = System.Linq.Enumerable::FirstOrDefault(v75, System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>);\n\t*([v243 @ X0_v108 (Unco.RewardSystem.ResourceItemData)])(v428, v75, *([v243 @ X0_v108 (Unco.RewardSystem.ResourceItemData)+8]), 0, v455, v43, v44, v45, v46, v452, v449, v49, v50, v51, v52, v53, v54);\n\tv329 = v428 == 0;\n\tv330 = ~v329;\nL_FFFFFFFF:\n\tv412 = &v326 @ stack_-68_v11 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ResourceItemData>);\nL_FFFFFFFF:\n\tv413 = 0;\n\tif (v330) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv413 = 0;\nL_FFFFFFFF:\n\tv352 = 0;\n\tgoto L_02B7;\nL_0089:\n\tv398 = *([v308 @ X10_v61]) << 4;\n\tv399 = v86 + v398;\n\tv400 = v399 + 0x138;\n\tv377 = *([v400 @ X8_v82+8]);\n\t*([v400 @ X8_v82])(v428, v75, *([v400 @ X8_v82+8]), v352, v455, v43, v44, v45, v46, v452, v449, v49, v50, v51, v52, v53, v54);\n\tv409 = v428 == 0;\nL_FFFFFFFF:\n\tv412 = &v326 @ stack_-68_v11 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ResourceItemData>);\nL_FFFFFFFF:\n\tv413 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv413 = 0;\n\tif (v409) goto L_02B7;\nL_FFFFFFFF:\n\tv450 = v449;\nL_FFFFFFFF:\n\tv453 = v452;\nL_FFFFFFFF:\n\tv766 = v455;\nL_FFFFFFFF:\n\tv546 = v428;\n\tgoto L_00AD;\nL_00A5:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::Add(v62, v1258);\nL_FFFFFFFF:\n\tv352 = Il2CppMethodInfo;\n\tv513 = v326 == 0;\nL_FFFFFFFF:\n\tv766 = 0;\nL_FFFFFFFF:\n\tv546 = v326;\nL_FFFFFFFF:\n\tv455 = 0;\nL_FFFFFFFF:\n\tv377 = v1258;\n\tif (v513) goto L_02B7;\nL_00AD:\n\tgoto L_00D3;\n\tv753 = new Unco.RewardSystem.Distribution.RewardDistributor+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v753);\n\tv680 = v326 == 0;\n\tif (v680) goto L_02BB;\n\tgoto L_010B;\n\tv753.resource = v1032;\n\tv1075 = System.Linq.Enumerable::OfType(v62);\n\tv1109 = new System.Func`2<Unco.RewardSystem.ResourceItemData, System.Boolean>();\n\tSystem.Func`2<Unco.RewardSystem.ResourceItemData, System.Boolean>::.ctor(v1109, v753, Il2CppMethodInfo);\n\tv1190 = System.Linq.Enumerable::FirstOrDefault(v1075, v1109);\n\tv511 = v753.resource;\n\tv1220 = v1190 == 0;\n\tif (v1220) goto L_0139;\n\tv684 = v753.resource == 0;\n\tif (v684) goto L_02C3;\n\tv450 = v511.Amount;\n\tv453 = *([v1190 @ X0_v91 (System.Object)+20]) + v511.Amount;\n\t*([v1190 @ X0_v91 (System.Object)+20]) = v453;\n\tv1254 = v326 == 0;\n\tv514 = ~v1254;\nL_FFFFFFFF:\n\tv766 = 0;\nL_FFFFFFFF:\n\tv546 = v326;\n\tif (v514) goto L_00AD;\nL_FFFFFFFF:\n\tv455 = 0;\nL_FFFFFFFF:\n\tv352 = Il2CppMethodInfo;\n\tgoto L_02B7;\nL_0139:\n\tv1258 = Unco.RewardSystem.ResourceItemData::Copy(v753.resource);\n\tv1259 = v62 == 0;\n\tif (v1259) goto L_02BD;\n\tv1266 = v62._version + 1;\n\tv62._version = v1266;\n\tv1267 = v62._items == 0;\n\tif (v1267) goto L_02BD;\n\tgoto L_00A5;\nL_015C:\n\tv756 = &v326 @ stack_-68_v11 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ResourceItemData>);\n\tv768 = 0xB28F000 + 0x8D0;\n\tv796 = *([v756 @ X8_v59]);\n\tv761 = *([v756 @ X8_v59]) == 0;\nL_FFFFFFFF:\n\tv332 = 0;\nL_FFFFFFFF:\n\tv764 = v450;\nL_FFFFFFFF:\n\tv765 = v453;\nL_FFFFFFFF:\n\tv767 = data;\nL_FFFFFFFF:\n\tv774 = v412;\nL_FFFFFFFF:\n\tv777 = 0;\nL_FFFFFFFF:\n\tv788 = data;\nL_FFFFFFFF:\n\tv793 = 5;\nL_FFFFFFFF:\n\tv795 = 0;\nL_FFFFFFFF:\n\tv332 = 0;\nL_FFFFFFFF:\n\tv335 = v450;\nL_FFFFFFFF:\n\tv336 = v453;\nL_FFFFFFFF:\n\tv337 = v766;\nL_FFFFFFFF:\n\tv108 = data;\nL_FFFFFFFF:\n\tv111 = v768;\nL_FFFFFFFF:\n\tv347 = v412;\nL_FFFFFFFF:\n\tv352 = 0;\nL_FFFFFFFF:\n\tv374 = data;\nL_FFFFFFFF:\n\tv377 = 0;\nL_FFFFFFFF:\n\tv288 = 5;\nL_FFFFFFFF:\n\tv207 = 0;\n\tif (v761) goto L_018E;\nL_0164:\n\tv798 = *([v796 @ X22_v13 (System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>)]);\n\tv937 = *([v798 @ X8_v46 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+12E]);\n\tv800 = *([v798 @ X8_v46 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+12E]) == 0;\n\tif (v800) goto L_0184;\n\tv936 = *([v798 @ X8_v46 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+B0]) + 8;\n\tv936 = v936 + 0x10;\n\tv848 = v937 - 1;\n\tv828 = v937 != 1;\nL_FFFFFFFF:\n\tv937 = v848;\n\tif (v828) goto L_016F;\nL_0184:\n\tv964 = System.Linq.Enumerable::FirstOrDefault(v796, *([v768 @ X23_v9 (System.Int32)]));\nL_FFFFFFFF:\n\tv352 = 0;\n\tgoto L_018B;\nL_0187:\n\tv961 = *([v936 @ X10_v40]) << 4;\n\tv962 = v798 + v961;\n\tv964 = v962 + 0x138;\nL_FFFFFFFF:\n\tv352 = v777;\n\tv165 = v288 == 5;\n\tif (v165) goto L_01A4;\n\tv951 = v288 == 0;\n\tv952 = ~v951;\n\tif (v952) goto L_02B4;\nL_01A4:\n\tv958 = System.Linq.Enumerable::OfType(v108);\n\tv195 = System.Linq.Enumerable::Except(v108, v958);\n\tv1036 = *([v195 @ X0_v12 (System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>)]);\n\tv1087 = *([v1036 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>>)+12E]);\n\tv1038 = *([v1036 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>>)+12E]) == 0;\n\tif (v1038) goto L_01CE;\n\tv1086 = *([v1036 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>>)+B0]) + 8;\n\tv1086 = v1086 + 0x10;\n\tv1067 = v1087 - 1;\n\tv1047 = v1087 != 1;\nL_FFFFFFFF:\n\tv1087 = v1067;\n\tif (v1047) goto L_01B9;\nL_01CE:\n\tv1070 = System.Linq.Enumerable::Except(v195, System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>);\n\t*([v1070 @ X0_v43 (System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>)])(v1138, v195, *([v1070 @ X0_v43 (System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ShopItemData>)+8]), 0, v337, v43, v44, v45, v46, v336, v335, v49, v50, v51, v52, v53, v54);\n\tv1106 = v1138 == 0;\n\tv1107 = ~v1106;\nL_FFFFFFFF:\n\tv332 = v1138;\nL_FFFFFFFF:\n\tv347 = &v332 @ stack_-70_v5 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>);\nL_FFFFFFFF:\n\tv413 = 0;\n\tif (v1107) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv332 = v1138;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv413 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_02BF;\nL_01DD:\n\tv1112 = *([v1086 @ X10_v29]) << 4;\n\tv1113 = v1036 + v1112;\n\tv1114 = v1113 + 0x138;\n\t*([v1114 @ X8_v38])(v1138, v195, *([v1114 @ X8_v38+8]), Il2CppMethodInfo, v337, v43, v44, v45, v46, v336, v335, v49, v50, v51, v52, v53, v54);\n\tv1122 = v1138 == 0;\nL_FFFFFFFF:\n\tv332 = v1138;\nL_FFFFFFFF:\n\tv347 = &v332 @ stack_-70_v5 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>);\nL_FFFFFFFF:\n\tv413 = 0;\nL_FFFFFFFF:\n\tv332 = v1138;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv413 = 0;\nL_FFFFFFFF:\n\t;\n\tif (v1122) goto L_02BF;\nL_FFFFFFFF:\n\tv1183 = v1138;\n\tgoto L_01FD;\nL_01F5:\n\tSystem.Collections.Generic.List`1<Unco.RewardSystem.ShopItemData>::Add(v62, v1416);\nL_FFFFFFFF:\n\t;\n\tv1163 = v332 == 0;\nL_FFFFFFFF:\n\tv1183 = v332;\n\tif (v1163) goto L_02BF;\nL_01FD:\n\tgoto L_0223;\n\tv683 = v332 == 0;\n\tif (v683) goto L_02C1;\n\tgoto L_0254;\n\tv1428 = v62._version + 1;\n\tv62._version = v1428;\n\tv1429 = v62._items == 0;\n\tif (v1429) goto L_02B5;\n\tgoto L_01F5;\nL_0274:\n\tv1260 = &v332 @ stack_-70_v5 (System.Collections.Generic.IEnumerator`1<Unco.RewardSystem.ShopItemData>);\n\tv388 = *([v1260 @ X8_v18]);\n\tv1261 = *([v1260 @ X8_v18]) == 0;\nL_FFFFFFFF:\n\tv352 = 0;\nL_FFFFFFFF:\n\tv377 = 0;\n\tif (v1261) goto L_02A5;\n\tv1273 = *([v388 @ X21_v8 (System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>)]);\n\tv1395 = *([v1273 @ X8_v20 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+12E]);\n\tv1275 = *([v1273 @ X8_v20 (Il2CppClass<System.Collections.Generic.IEnumerable`1<Unco.RewardSystem.ResourceItemData>>)+12E]) == 0;\n\tif (v1275) goto L_0299;\n\tv1394 = *([v1273 @ X8_v20 (Il2CppClass<System.Collecti\n// ... truncated")]
		public static List<ShopItemData> MergeItems(IEnumerable<ShopItemData> data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RewardDistributor::MergeItems");
			return default;
		}

		[IteratorStateMachine(typeof(_003CExtract_003Ed__3))]
		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x81DCB24", Offset = "0x81DCB24", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.<>l__initialThreadId = v50;\n\tv45.<>3__data = data;\n\treturn v45;\nL_0017:\n\tv45 = new Unco.RewardSystem.Distribution.RewardDistributor+<Extract>d__3();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = -2;\n\tv50 = System.Environment::get_CurrentManagedThreadId();\n")]
		public static IEnumerable<ShopItemData> Extract(IEnumerable<ShopItemData> data)
		{
			_003CExtract_003Ed__3 _003CExtract_003Ed__4 = new _003CExtract_003Ed__3(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CExtract_003Ed__4._003C_003El__initialThreadId = currentManagedThreadId;
			_003CExtract_003Ed__4._003C_003E3__data = data;
			return _003CExtract_003Ed__4;
		}
	}
}
