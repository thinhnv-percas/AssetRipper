using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000018")]
	public abstract class ObiActorBlueprint : ScriptableObject, IObiParticleCollection
	{
		[Token(Token = "0x200009D")]
		public delegate void BlueprintCallback(ObiActorBlueprint blueprint);

		[Serializable]
		[Token(Token = "0x200009E")]
		public class ObiDistanceConstraintsData : ObiConstraints<ObiDistanceConstraintsBatch>
		{
			[Token(Token = "0x6000522")]
			[Address(RVA = "0xE3CD68", Offset = "0xE3CD68", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EF58E8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E4]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiDistanceConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiDistanceConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiDistanceConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200009F")]
		public class ObiBendConstraintsData : ObiConstraints<ObiBendConstraintsBatch>
		{
			[Token(Token = "0x6000523")]
			[Address(RVA = "0xE3CC60", Offset = "0xE3CC60", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EAE978]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E1]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiBendConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiBendConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiBendConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A0")]
		public class ObiPinConstraintsData : ObiConstraints<ObiPinConstraintsBatch>
		{
			[Token(Token = "0x6000524")]
			[Address(RVA = "0xE3CDC0", Offset = "0xE3CDC0", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EEF0C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E5]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiPinConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiPinConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiPinConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A1")]
		public class ObiSkinConstraintsData : ObiConstraints<ObiSkinConstraintsBatch>
		{
			[Token(Token = "0x6000525")]
			[Address(RVA = "0xE3CE70", Offset = "0xE3CE70", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1ECC830]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E7]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiSkinConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiSkinConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiSkinConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A2")]
		public class ObiTetherConstraintsData : ObiConstraints<ObiTetherConstraintsBatch>
		{
			[Token(Token = "0x6000526")]
			[Address(RVA = "0xE3CF20", Offset = "0xE3CF20", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EDAF18]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E9]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiTetherConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiTetherConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiTetherConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A3")]
		public class ObiShapeMatchingConstraintsData : ObiConstraints<ObiShapeMatchingConstraintsBatch>
		{
			[Token(Token = "0x6000527")]
			[Address(RVA = "0xE3CE18", Offset = "0xE3CE18", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EEF5B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E6]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiShapeMatchingConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiShapeMatchingConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiShapeMatchingConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A4")]
		public class ObiBendTwistConstraintsData : ObiConstraints<ObiBendTwistConstraintsBatch>
		{
			[Token(Token = "0x6000528")]
			[Address(RVA = "0xE3CCB8", Offset = "0xE3CCB8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1F06F90]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E2]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiBendTwistConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiBendTwistConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiBendTwistConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A5")]
		public class ObiStretchShearConstraintsData : ObiConstraints<ObiStretchShearConstraintsBatch>
		{
			[Token(Token = "0x6000529")]
			[Address(RVA = "0xE3CEC8", Offset = "0xE3CEC8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EEA570]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E8]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiStretchShearConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiStretchShearConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiStretchShearConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A6")]
		public class ObiAerodynamicConstraintsData : ObiConstraints<ObiAerodynamicConstraintsBatch>
		{
			[Token(Token = "0x600052A")]
			[Address(RVA = "0xE3CC08", Offset = "0xE3CC08", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EC3530]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E0]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiAerodynamicConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiAerodynamicConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiAerodynamicConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A7")]
		public class ObiChainConstraintsData : ObiConstraints<ObiChainConstraintsBatch>
		{
			[Token(Token = "0x600052B")]
			[Address(RVA = "0xE3CD10", Offset = "0xE3CD10", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EE9168]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246E3]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiChainConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiChainConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiChainConstraintsBatch>)null)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000A8")]
		public class ObiVolumeConstraintsData : ObiConstraints<ObiVolumeConstraintsBatch>
		{
			[Token(Token = "0x600052C")]
			[Address(RVA = "0xE3CF78", Offset = "0xE3CF78", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EA5CD8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246EA]) = v38;\nL_001E:\n\tObi.ObiConstraints`1<Obi.ObiVolumeConstraintsBatch>::.ctor(this, 0, 0);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiVolumeConstraintsData()
				: base((ObiActor)null, (ObiConstraints<ObiVolumeConstraintsBatch>)null)
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20000A9")]
		private sealed class _003CGetConstraints_003Ed__59 : IEnumerable<IObiConstraints>, IEnumerable, IEnumerator<IObiConstraints>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40002DD")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40002DE")]
			[FieldOffset(Offset = "0x18")]
			private IObiConstraints _003C_003E2__current;

			[Token(Token = "0x40002DF")]
			[FieldOffset(Offset = "0x20")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40002E0")]
			[FieldOffset(Offset = "0x28")]
			public ObiActorBlueprint _003C_003E4__this;

			[Token(Token = "0x170000CF")]
			IObiConstraints IEnumerator<IObiConstraints>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000530")]
				[Address(RVA = "0xE3CAB0", Offset = "0xE3CAB0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170000D0")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000532")]
				[Address(RVA = "0xE3CB1C", Offset = "0xE3CB1C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600052D")]
			[Address(RVA = "0xE3927C", Offset = "0xE3927C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetConstraints_003Ed__59(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x600052E")]
			[Address(RVA = "0xE3C7B0", Offset = "0xE3C7B0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600052F")]
			[Address(RVA = "0xE3C7B4", Offset = "0xE3C7B4", Length = "0x2FC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFB728]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246DD]) = v38;\nL_0013:\n\tv39 = v36.<>1__state;\n\tv40 = v36.<>1__state < 0xB;\n\tv41 = ~v40;\n\tv42 = v36.<>1__state - 0xB;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_014F;\n\tv52 = 0x181C000 + 0x6E4;\n\tv55 = *([v52 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v52;\n\t// 37 IndirectJump v55 @ X8_v5, v36 @ X0_v1 (Obi.ObiActorBlueprint+<GetConstraints>d__59), v36 @ X0_v1 (Obi.ObiActorBlueprint+<GetConstraints>d__59), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\n\tX0 = *([X20+A0]);\n\tif (TEMP) goto L_0046;\n\tX8 = *([1EAA970]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0046;\n\tX8 = *([X20+A0]);\n\tX0 = 0 | 1;\n\t*([X19+10]) = X0;\n\t*([X19+18]) = X8;\n\tgoto L_014D;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_0046:\n\tX0 = *([X20+A8]);\n\tif (TEMP) goto L_0060;\n\tX8 = *([1F02B20]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0060;\n\tX8 = *([X20+A8]);\n\tX9 = 0 | 2;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_0060:\n\tX0 = *([X20+B0]);\n\tif (TEMP) goto L_007A;\n\tX8 = *([1EB8748]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_007A;\n\tX8 = *([X20+B0]);\n\tX9 = 0 | 3;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_007A:\n\tX0 = *([X20+B8]);\n\tif (TEMP) goto L_0094;\n\tX8 = *([1F0E2C0]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0094;\n\tX8 = *([X20+B8]);\n\tX9 = 0 | 4;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_0094:\n\tX0 = *([X20+C0]);\n\tif (TEMP) goto L_00AE;\n\tX8 = *([1EBF8D8]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00AE;\n\tX8 = *([X20+C0]);\n\tX9 = 5;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_00AE:\n\tX0 = *([X20+C8]);\n\tif (TEMP) goto L_00C8;\n\tX8 = *([1F06F20]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00C8;\n\tX8 = *([X20+C8]);\n\tX9 = 0 | 6;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_00C8:\n\tX0 = *([X20+D0]);\n\tif (TEMP) goto L_00E2;\n\tX8 = *([1EBB028]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00E2;\n\tX8 = *([X20+D0]);\n\tX9 = 0 | 7;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_00E2:\n\tX0 = *([X20+D8]);\n\tif (TEMP) goto L_00FC;\n\tX8 = *([1ED5638]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_00FC;\n\tX8 = *([X20+D8]);\n\tX9 = 0 | 8;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_00FC:\n\tX0 = *([X20+E0]);\n\tif (TEMP) goto L_0116;\n\tX8 = *([1EF8938]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0116;\n\tX8 = *([X20+E0]);\n\tX9 = 9;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_0116:\n\tX0 = *([X20+E8]);\n\tif (TEMP) goto L_0130;\n\tX8 = *([1F103C0]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0130;\n\tX8 = *([X20+E8]);\n\tX9 = 0xA;\n\tgoto L_0145;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_0154;\nL_0130:\n\tX0 = *([X20+F0]);\n\tif (TEMP) goto L_014D;\n\tX8 = *([1F0ED00]);\n\tX1 = *([X8]);\n\tX0 = Obi.ObiConstraints`1::GetBatchCount /* +12 sharing this address */(X0, X1);\n\tC = X0 < 1;\n\tC = ~C;\n\tTEMP1 = X0 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X0 ^ 1;\n\tTEMP3 = X0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_014F;\n\tX8 = *([X20+F0]);\n\tX9 = 0xB;\nL_0145:\n\t*([X19+10]) = X9;\n\t*([X19+18]) = X8;\n\tX0 = 0 | 1;\nL_014D:\n\treturn 0;\nL_014F:\n\tgoto L_014D;\n\tX0 = 0;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tgoto L_014D;\nL_0154:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0029: Expected O, but got I
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 11;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 11;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25280512 + 1764;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ X8_v5 (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000531")]
			[Address(RVA = "0xE3CAB8", Offset = "0xE3CAB8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1ED37C0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20246DE]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw new TypeLoadException();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000533")]
			[Address(RVA = "0xE3CB24", Offset = "0xE3CB24", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED4DB0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246DF]) = v38;\nL_0014:\n\tv40 = this.<>1__state + 2;\n\tv42 = v40 == 0;\n\tv45 = ~v42;\n\tif (v45) goto L_002E;\n\tv48 = System.Environment::get_CurrentManagedThreadId();\n\tv50 = this.<>l__initialThreadId != v48;\n\tif (v50) goto L_002E;\n\tthis.<>1__state = 0;\n\tgoto L_0041;\nL_002E:\n\tv76 = new Obi.ObiActorBlueprint+<GetConstraints>d__59();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv76.<>l__initialThreadId = v81;\n\tv76.<>4__this = this.<>4__this;\nL_0041:\n\treturn v95;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			IEnumerator<IObiConstraints> IEnumerable<IObiConstraints>.GetEnumerator()
			{
				if (_003C_003E1__state + 2 == 0)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CGetConstraints_003Ed__59 _003CGetConstraints_003Ed__60 = null;
				_003CGetConstraints_003Ed__60._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetConstraints_003Ed__60._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetConstraints_003Ed__60._003C_003E4__this = _003C_003E4__this;
				return _003CGetConstraints_003Ed__60;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000534")]
			[Address(RVA = "0xE3CBD4", Offset = "0xE3CBD4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Obi.ObiActorBlueprint+<GetConstraints>d__59::System.Collections.Generic.IEnumerable<Obi.IObiConstraints>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IObiConstraints>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x18")]
		private BlueprintCallback m_OnBlueprintGenerate;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x20")]
		protected bool m_Empty;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x24")]
		protected int m_ActiveParticleCount;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x28")]
		protected int m_InitialActiveParticleCount;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x2C")]
		protected Bounds _bounds;

		[HideInInspector]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x48")]
		public Vector3[] positions;

		[HideInInspector]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x50")]
		public Vector4[] restPositions;

		[HideInInspector]
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x58")]
		public Quaternion[] orientations;

		[HideInInspector]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x60")]
		public Quaternion[] restOrientations;

		[HideInInspector]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x68")]
		public Vector3[] velocities;

		[HideInInspector]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x70")]
		public Vector3[] angularVelocities;

		[HideInInspector]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x78")]
		public float[] invMasses;

		[HideInInspector]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x80")]
		public float[] invRotationalMasses;

		[HideInInspector]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x88")]
		public int[] phases;

		[HideInInspector]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x90")]
		public Vector3[] principalRadii;

		[HideInInspector]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x98")]
		public Color[] colors;

		[HideInInspector]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0xA0")]
		public ObiDistanceConstraintsData distanceConstraintsData;

		[HideInInspector]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0xA8")]
		public ObiBendConstraintsData bendConstraintsData;

		[HideInInspector]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0xB0")]
		public ObiPinConstraintsData pinConstraintsData;

		[HideInInspector]
		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0xB8")]
		public ObiSkinConstraintsData skinConstraintsData;

		[HideInInspector]
		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0xC0")]
		public ObiTetherConstraintsData tetherConstraintsData;

		[HideInInspector]
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0xC8")]
		public ObiStretchShearConstraintsData stretchShearConstraintsData;

		[HideInInspector]
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0xD0")]
		public ObiBendTwistConstraintsData bendTwistConstraintsData;

		[HideInInspector]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0xD8")]
		public ObiShapeMatchingConstraintsData shapeMatchingConstraintsData;

		[HideInInspector]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0xE0")]
		public ObiAerodynamicConstraintsData aerodynamicConstraintsData;

		[HideInInspector]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0xE8")]
		public ObiChainConstraintsData chainConstraintsData;

		[HideInInspector]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0xF0")]
		public ObiVolumeConstraintsData volumeConstraintsData;

		[HideInInspector]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0xF8")]
		public List<ObiParticleGroup> groups;

		[Token(Token = "0x17000025")]
		public int particleCount
		{
			[Token(Token = "0x60001BE")]
			[Address(RVA = "0xE31FB8", Offset = "0xE31FB8", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.positions;\n\tv2 = this.positions == 0;\n\tif (v2) goto L_0006;\n\treturn v0.Length;\nL_0006:\n\treturn 0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Vector3[] array = positions;
				if (positions != null)
				{
					return array.Length;
				}
				return 0;
			}
		}

		[Token(Token = "0x17000026")]
		public int activeParticleCount
		{
			[Token(Token = "0x60001BF")]
			[Address(RVA = "0xE38F54", Offset = "0xE38F54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ActiveParticleCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return activeParticleCount;
			}
		}

		[Token(Token = "0x17000027")]
		public bool usesOrientedParticles
		{
			[Token(Token = "0x60001C0")]
			[Address(RVA = "0xE38F5C", Offset = "0xE38F5C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.invRotationalMasses;\n\tv2 = this.invRotationalMasses == 0;\n\tif (v2) goto L_001D;\n\tv4 = v0.Length == 0;\n\tif (v4) goto L_001D;\n\tv10 = this.orientations;\n\tv6 = this.orientations == 0;\n\tif (v6) goto L_001D;\n\tv7 = v10.Length == 0;\n\tif (v7) goto L_001D;\n\tv12 = this.restOrientations;\n\tv8 = this.restOrientations == 0;\n\tif (v8) goto L_001D;\n\tv32 = v12.Length == 0;\n\tv17 = ~v32;\n\treturn v17;\nL_001D:\n\treturn 0;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float[] array = invRotationalMasses;
				if (invRotationalMasses != null && array.Length != 0)
				{
					Quaternion[] array2 = orientations;
					if (orientations != null && array2.Length != 0)
					{
						Quaternion[] array3 = restOrientations;
						if (restOrientations != null)
						{
							bool flag = array3.Length == 0;
							return !flag;
						}
					}
				}
				return false;
			}
		}

		[Token(Token = "0x17000028")]
		public virtual bool usesTethers
		{
			[Token(Token = "0x60001C1")]
			[Address(RVA = "0xE38F9C", Offset = "0xE38F9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000029")]
		public bool empty
		{
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0xE391CC", Offset = "0xE391CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Empty;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return empty;
			}
		}

		[Token(Token = "0x1700002A")]
		public unsafe Bounds bounds
		{
			[Token(Token = "0x60001C8")]
			[Address(RVA = "0xE39268", Offset = "0xE39268", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+10]) = this._bounds.m_Extents.y;\n\treturnBuffer.m_Center = this._bounds;\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001b: Expected native int or pointer, but got O
				_ = _bounds.m_Extents.y;
				Bounds bounds = default(Bounds);
				((Bounds*)(IntPtr)bounds)->m_Center = (Vector3)_bounds;
				return (Bounds)this;
			}
		}

		[Token(Token = "0x14000007")]
		public event BlueprintCallback OnBlueprintGenerate
		{
			[CompilerGenerated]
			[Token(Token = "0x60001BC")]
			[Address(RVA = "0xE32830", Offset = "0xE32830", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB5DE8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20246C6]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActorBlueprint+BlueprintCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_OnBlueprintGenerate;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(BlueprintCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60001BD")]
			[Address(RVA = "0xE328D4", Offset = "0xE328D4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB47F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20246C7]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActorBlueprint+BlueprintCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_OnBlueprintGenerate;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(BlueprintCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xE38FA4", Offset = "0xE38FA4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.m_ActiveParticleCount - index;\n\tv6 = v5 < 0;\n\tv7 = v5 == 0;\n\tv8 = this.m_ActiveParticleCount ^ index;\n\tv9 = this.m_ActiveParticleCount ^ v5;\n\tv10 = v8 & v9;\n\tv11 = v10 < 0;\n\tv12 = v6 == v11;\n\tv13 = ~v7;\n\tv14 = v12 & v13;\n\treturn v14;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsParticleActive(int index)
		{
			int num = activeParticleCount - index;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = activeParticleCount ^ index;
			int num3 = activeParticleCount ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xE38FB4", Offset = "0xE38FB4", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EF3FE0]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20246C8]) = v45;\nL_001F:\n\tgoto L_002B;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002B;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, index, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_002B:\n\tObi.ObiUtils::Swap(this.positions, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.restPositions, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.orientations, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.restOrientations, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.velocities, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.angularVelocities, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.invMasses, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.invRotationalMasses, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.phases, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.principalRadii, index, this.m_ActiveParticleCount);\n\tObi.ObiUtils::Swap(this.colors, index, this.m_ActiveParticleCount);\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SwapWithFirstInactiveParticle(int index)
		{
			positions.Swap(index, activeParticleCount);
			restPositions.Swap(index, activeParticleCount);
			orientations.Swap(index, activeParticleCount);
			restOrientations.Swap(index, activeParticleCount);
			velocities.Swap(index, activeParticleCount);
			angularVelocities.Swap(index, activeParticleCount);
			invMasses.Swap(index, activeParticleCount);
			invRotationalMasses.Swap(index, activeParticleCount);
			phases.Swap(index, activeParticleCount);
			principalRadii.Swap(index, activeParticleCount);
			colors.Swap(index, activeParticleCount);
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0xE39138", Offset = "0xE39138", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = this.m_ActiveParticleCount <= index;\n\tif (v23) goto L_001A;\n\tgoto L_0023;\nL_001A:\n\tv29 = Obi.ObiActorBlueprint::SwapWithFirstInactiveParticle(this, index);\n\tv45 = this.m_ActiveParticleCount + 1;\n\tthis.m_ActiveParticleCount = v45;\nL_0023:\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ActivateParticle(int index)
		{
			if (activeParticleCount > index)
			{
				return false;
			}
			SwapWithFirstInactiveParticle(index);
			int num = activeParticleCount + 1;
			m_ActiveParticleCount = num;
			return true;
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0xE3918C", Offset = "0xE3918C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_ActiveParticleCount <= index;\n\tif (v14) goto L_001E;\n\tv22 = this.m_ActiveParticleCount - 1;\n\tthis.m_ActiveParticleCount = v22;\n\tv25 = Obi.ObiActorBlueprint::SwapWithFirstInactiveParticle(this, index);\n\treturn 1;\nL_001E:\n\treturn 0;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool DeactivateParticle(int index)
		{
			if (activeParticleCount > index)
			{
				int num = activeParticleCount - 1;
				m_ActiveParticleCount = num;
				SwapWithFirstInactiveParticle(index);
				return true;
			}
			return false;
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0xE391D4", Offset = "0xE391D4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this + 0x2C;\n\tthis._bounds = 0;\n\tv17 = this.positions;\n\tthis._bounds.m_Center.z = 0f;\n\tthis._bounds.m_Extents.y = 0f;\n\tv83 = v17.Length;\n\tv30 = v17.Length < 1;\n\tif (v30) goto L_0047;\nL_001F:\n\tv153 = v53 < v83;\n\tv80 = ~v153;\n\tif (v80) goto L_0048;\n\tv136 = v53 * 0xC;\n\tv178 = v17 + v136;\n\tv103 = 0x100E858(v16, 0, v33, v89, v90, v91, v92, v93, *([v178 @ X8_v5+20]), v17[v53 @ X8_v4 (System.Int32)].y, v17[v53 @ X8_v4 (System.Int32)].z, v94, v95, v96, v97, v98);\n\tv83 = v17.Length;\n\tv53 = v53 + 1;\n\tv116 = v53 < v17.Length;\n\tif (v116) goto L_001F;\nL_0047:\n\treturn;\nL_0048:\n\tv180 = new System.IndexOutOfRangeException();\n\tthrow v180;\n\tthrow System.NullReferenceException;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RecalculateBounds()
		{
			//IL_000c: Expected O, but got I
			//IL_00ac: Expected O, but got I
			object obj = (long)(IntPtr)this + 44L;
			_bounds = default(Bounds);
			Vector3[] array = positions;
			_bounds.m_Center.z = 0f;
			_bounds.m_Extents.y = 0f;
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				int num3 = num2 * 12;
				object obj2 = (long)(IntPtr)array + (long)num3;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E858 (inside UnityEngine.Bounds::op_Inequality +0x138)");
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x747054", Offset = "0x747054")]
		[Token(Token = "0x60001C9")]
		[Address(RVA = "0xE376DC", Offset = "0xE376DC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED57F0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246C9]) = v38;\nL_0016:\n\tv42 = new Obi.ObiActorBlueprint+<GetConstraints>d__59();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0xFFFFFFFE;\n\tv47 = System.Environment::get_CurrentManagedThreadId();\n\tv42.<>l__initialThreadId = v47;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerable<IObiConstraints> GetConstraints()
		{
			_003CGetConstraints_003Ed__59 _003CGetConstraints_003Ed__60 = new _003CGetConstraints_003Ed__59(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetConstraints_003Ed__60._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetConstraints_003Ed__60._003C_003E4__this = this;
			return _003CGetConstraints_003Ed__60;
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0xE392B4", Offset = "0xE392B4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = type < 0xD;\n\tv4 = ~v2;\n\tv5 = type - 0xD;\n\tv7 = v5 == 0;\n\tv13 = ~v7;\n\tv14 = v4 & v13;\n\tif (v14) goto L_0017;\n\tv17 = 0x181C000 + 0x6AC;\n\tv19 = *([v17 @ X10_v2 (System.Int32)+type @ X1 (Oni+ConstraintType)*4]) + v17;\n\t// 19 IndirectJump v19 @ X9_v3, 0, 0, type @ X1 (Oni+ConstraintType), methodInfo @ X2 (Il2CppMethodInfo), v21 @ X3, v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\n\tX0 = *([X8+C0]);\n\treturn X0;\n\tX0 = *([X8+F0]);\nL_0017:\n\treturn 0;\n\tX0 = *([X8+E8]);\n\treturn X0;\n\tX0 = *([X8+A8]);\n\treturn X0;\n\tX0 = *([X8+A0]);\n\treturn X0;\n\tX0 = *([X8+D8]);\n\treturn X0;\n\tX0 = *([X8+D0]);\n\treturn X0;\n\tX0 = *([X8+C8]);\n\treturn X0;\n\tX0 = *([X8+B0]);\n\treturn X0;\n\tX0 = *([X8+B8]);\n\treturn X0;\n\tX0 = *([X8+E0]);\n\treturn X0;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IObiConstraints GetConstraintsByType(Oni.ConstraintType type)
		{
			//IL_0081: Expected O, but got I
			bool flag = type < Oni.ConstraintType.Aerodynamics;
			bool flag2 = !flag;
			int num = (int)(type - 13);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25280512 + 1708;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X10_v2 (System.Int32)+type @ X1 (Oni+ConstraintType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v19 @ X9_v3 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0xE39334", Offset = "0xE39334", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn blueprintIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetParticleRuntimeIndex(int blueprintIndex)
		{
			return blueprintIndex;
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0xE3933C", Offset = "0xE3933C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAD180]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, returnVal3, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246CA]) = v41;\nL_0015:\n\tv42 = this.positions;\n\tv43 = this.positions == 0;\n\tif (v43) goto L_0046;\n\tv56 = v42.Length <= index;\n\tif (v56) goto L_0046;\n\tv83 = v42.Length < index;\n\tv84 = ~v83;\n\tv85 = v42.Length - index;\n\tv87 = v85 == 0;\n\tv92 = ~v84;\n\tv93 = v92 | v87;\n\tif (v93) goto L_0057;\n\tv110 = index * 0xC;\n\tv111 = this.positions + v110;\n\treturn *([v111 @ X8_v9+20]);\nL_0046:\n\tgoto L_0053;\n\tv94 = *([v79 @ X0_v2+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0053;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v79, index, methodInfo, v26, v27, v28, v29, v30, returnVal3, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\treturnVal2 = UnityEngine.Vector3::get_zero();\n\treturn returnVal2;\nL_0057:\n\tv120 = new System.IndexOutOfRangeException();\n\tthrow v120;\n\treturn returnVal3;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 GetParticlePosition(int index)
		{
			//IL_00a3: Expected O, but got I
			//IL_00b0: Expected O, but got I
			Vector3[] array = positions;
			if (positions != null && array.Length > index)
			{
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = index * 12;
					object obj = (long)(IntPtr)positions + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X8_v9+20]");
					return (Vector3)0;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return Vector3.zero;
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xE393FC", Offset = "0xE393FC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF3C78]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, returnVal3, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246CB]) = v41;\nL_0015:\n\tv42 = this.orientations;\n\tv43 = this.orientations == 0;\n\tif (v43) goto L_0046;\n\tv56 = v42.Length <= index;\n\tif (v56) goto L_0046;\n\tv83 = v42.Length < index;\n\tv84 = ~v83;\n\tv85 = v42.Length - index;\n\tv87 = v85 == 0;\n\tv92 = ~v84;\n\tv93 = v92 | v87;\n\tif (v93) goto L_0058;\n\tv109 = index << 4;\n\tv110 = this.orientations + v109;\n\treturn *([v110 @ X8_v9+20]);\nL_0046:\n\tgoto L_0053;\n\tv94 = *([v79 @ X0_v2+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0053;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v79, index, methodInfo, v26, v27, v28, v29, v30, returnVal3, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\treturnVal2 = UnityEngine.Quaternion::get_identity();\n\treturn returnVal2;\nL_0058:\n\tv120 = new System.IndexOutOfRangeException();\n\tthrow v120;\n\treturn returnVal3;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Quaternion GetParticleOrientation(int index)
		{
			//IL_00a3: Expected O, but got I
			//IL_00b0: Expected O, but got I
			Quaternion[] array = orientations;
			if (orientations != null && array.Length > index)
			{
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = index << 4;
					object obj = (long)(IntPtr)orientations + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v9+20]");
					return (Quaternion)0;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return Quaternion.identity;
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xE394B8", Offset = "0xE394B8", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv48 = *([1F0A8D0]);\n\tv49 = *([v48 @ X8_v30]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, index, b1, b2, b3, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([20246CC]) = v64;\nL_0022:\n\tv65 = this.orientations;\n\tv66 = this.orientations == 0;\n\tif (v66) goto L_0114;\n\tv79 = v65.Length <= index;\n\tif (v79) goto L_0114;\n\tv102 = v65.Length < index;\n\tv103 = ~v102;\n\tv104 = v65.Length - index;\n\tv106 = v104 == 0;\n\tv111 = ~v103;\n\tv112 = v111 | v106;\n\tif (v112) goto L_014B;\n\tv213 = index << 4;\n\tv278 = this.orientations + v213;\n\tgoto L_0053;\n\tv305 = *([v279 @ X0_v17+E0]);\n\tv306 = v305 == 0;\n\tv307 = ~v306;\n\tif (v307) goto L_0053;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v279, index, b1, b2, b3, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\nL_0053:\n\tv313 = UnityEngine.Vector3::get_right();\n\tgoto L_006D;\n\tv429 = *([v420 @ X0_v20+E0]);\n\tv430 = v429 == 0;\n\tv431 = ~v430;\n\tif (v431) goto L_006D;\n\tv433 = \"il2cpp_codegen_runtime_class_init\"(v420, index, b1, b2, b3, methodInfo, v52, v53, v313, v413, v414, v57, v58, v59, v60, v61);\nL_006D:\n\t// 109 MakeStruct v167 @ AGGE395B4_0_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v278 @ X8_v9+20], v65[index @ X1 (System.Int32)].y (System.Single), v65[index @ X1 (System.Int32)].z (System.Single), v65[index @ X1 (System.Int32)].w (System.Single)\n\tv444 = UnityEngine.Quaternion::op_Multiply(v167, v313);\n\tgoto L_0086;\n\tv472 = *([v452 @ X0_v23+E0]);\n\tv473 = v472 == 0;\n\tv474 = ~v473;\n\tif (v474) goto L_0086;\n\tv476 = \"il2cpp_codegen_runtime_class_init\"(v452, index, b1, b2, b3, methodInfo, v52, v53, v444, v448, v449, v439, v440, v441, v442, v61);\nL_0086:\n\tv483 = UnityEngine.Vector4::op_Implicit(v444);\n\t*([b1 @ X2 (UnityEngine.Vector4&)]) = v483;\n\t*([b1 @ X2 (UnityEngine.Vector4&)+4]) = v483.y;\n\t*([b1 @ X2 (UnityEngine.Vector4&)+8]) = v483.z;\n\t*([b1 @ X2 (UnityEngine.Vector4&)+C]) = v483.w;\n\tv488 = UnityEngine.Vector3::get_up();\n\t// 154 MakeStruct v155 @ AGGE39628_0_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v278 @ X8_v9+20], v65[index @ X1 (System.Int32)].y (System.Single), v65[index @ X1 (System.Int32)].z (System.Single), v65[index @ X1 (System.Int32)].w (System.Single)\n\tv499 = UnityEngine.Quaternion::op_Multiply(v155, v488);\n\tv503 = UnityEngine.Vector4::op_Implicit(v499);\n\t*([b2 @ X3 (UnityEngine.Vector4&)]) = v503;\n\t*([b2 @ X3 (UnityEngine.Vector4&)+4]) = v503.y;\n\t*([b2 @ X3 (UnityEngine.Vector4&)+8]) = v503.z;\n\t*([b2 @ X3 (UnityEngine.Vector4&)+C]) = v503.w;\n\tv508 = UnityEngine.Vector3::get_forward();\n\t// 181 MakeStruct v143 @ AGGE39664_0_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v278 @ X8_v9+20], v65[index @ X1 (System.Int32)].y (System.Single), v65[index @ X1 (System.Int32)].z (System.Single), v65[index @ X1 (System.Int32)].w (System.Single)\n\tv516 = UnityEngine.Quaternion::op_Multiply(v143, v508);\n\tv198 = UnityEngine.Vector4::op_Implicit(v516);\n\t*([b3 @ X4 (UnityEngine.Vector4&)]) = v198;\n\t*([b3 @ X4 (UnityEngine.Vector4&)+4]) = v198.y;\n\t*([b3 @ X4 (UnityEngine.Vector4&)+8]) = v198.z;\n\t*([b3 @ X4 (UnityEngine.Vector4&)+C]) = v198.w;\n\tv268 = this.principalRadii;\n\tv519 = v268.Length < index;\n\tv249 = ~v519;\n\tv245 = v268.Length - index;\n\tv237 = v245 == 0;\n\tv520 = ~v249;\n\tv217 = v520 | v237;\n\tif (v217) goto L_014B;\n\tthrow System.TypeLoadException;\n\tv269 = this.principalRadii;\n\tv294 = *([v269 @ X8_v21 (UnityEngine.Vector3[])+18]);\n\tv528 = v294 < index;\n\tv250 = ~v528;\n\tv246 = v294 - index;\n\tv238 = v246 == 0;\n\tv529 = ~v250;\n\tv218 = v529 | v238;\n\tif (v218) goto L_014B;\n\tthrow System.TypeLoadException;\n\tv270 = this.principalRadii;\n\tv295 = *([v270 @ X8_v23 (UnityEngine.Vector3[])+18]);\n\tv537 = v295 < index;\n\tv292 = ~v537;\n\tv291 = v295 - index;\n\tv289 = v291 == 0;\n\tv538 = ~v292;\n\tv284 = v538 | v289;\n\tif (v284) goto L_014B;\n\tthrow System.TypeLoadException;\nL_0114:\n\tv100 = this.principalRadii;\n\tv114 = v100.Length < index;\n\tv115 = ~v114;\n\tv116 = v100.Length - index;\n\tv118 = v116 == 0;\n\tv123 = ~v115;\n\tv124 = v123 | v118;\n\tif (v124) goto L_014B;\n\tthrow System.TypeLoadException;\n\tv428 = 0x158BB44(b2, 3, 0, b2, b3, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv394 = 0x158BB44(v467, v324, 0, b2, b3, methodInfo, v52, v53, v362, v360, v358, v350, v348, v346, v344, v61);\n\treturn;\nL_014B:\n\tv297 = new System.IndexOutOfRangeException();\n\tthrow v297;\n\tthrow System.NullReferenceException;\n// 232 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void GetParticleAnisotropy(int index, ref Vector4 b1, ref Vector4 b2, ref Vector4 b3)
		{
			//IL_00a3: Expected O, but got I
			//IL_00cb: Expected F4, but got I
			//IL_0188: Expected F4, but got I
			//IL_0240: Expected F4, but got I
			Quaternion[] array = orientations;
			if (orientations != null && array.Length > index)
			{
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = index << 4;
					object obj = (long)(IntPtr)orientations + (long)num2;
					Vector3 right = Vector3.right;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v9+20]");
					Quaternion quaternion = default(Quaternion);
					quaternion.x = 0f;
					quaternion.y = array[index].y;
					quaternion.z = array[index].z;
					quaternion.w = array[index].w;
					Vector3 vector = quaternion * right;
					Vector4 vector2 = vector;
					ref Vector4 reference = ref *(Vector4*)vector2;
					_ = vector2.y;
					_ = vector2.z;
					_ = vector2.w;
					Vector3 up = Vector3.up;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v9+20]");
					Quaternion quaternion2 = default(Quaternion);
					quaternion2.x = 0f;
					quaternion2.y = array[index].y;
					quaternion2.z = array[index].z;
					quaternion2.w = array[index].w;
					Vector3 vector3 = quaternion2 * up;
					Vector4 vector4 = vector3;
					ref Vector4 reference2 = ref *(Vector4*)vector4;
					_ = vector4.y;
					_ = vector4.z;
					_ = vector4.w;
					Vector3 forward = Vector3.forward;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v9+20]");
					Quaternion quaternion3 = default(Quaternion);
					quaternion3.x = 0f;
					quaternion3.y = array[index].y;
					quaternion3.z = array[index].z;
					quaternion3.w = array[index].w;
					Vector3 vector5 = quaternion3 * forward;
					Vector4 vector6 = vector5;
					ref Vector4 reference3 = ref *(Vector4*)vector6;
					_ = vector6.y;
					_ = vector6.z;
					_ = vector6.w;
					Vector3[] array2 = principalRadii;
					bool flag5 = array2.Length < index;
					bool flag6 = !flag5;
					int num3 = array2.Length - index;
					bool flag7 = num3 == 0;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						throw new TypeLoadException();
					}
				}
			}
			else
			{
				Vector3[] array3 = principalRadii;
				bool flag9 = array3.Length < index;
				bool flag10 = !flag9;
				int num4 = array3.Length - index;
				bool flag11 = num4 == 0;
				bool flag12 = !flag10;
				if (!(flag12 || flag11))
				{
					throw new TypeLoadException();
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xE397C8", Offset = "0xE397C8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.principalRadii;\n\tv2 = this.principalRadii == 0;\n\tif (v2) goto L_001D;\n\tv4 = v0.Length < index;\n\tv6 = ~v4;\n\tv7 = v0.Length - index;\n\tv9 = v7 == 0;\n\tv16 = v0.Length <= index;\n\tif (v16) goto L_001D;\n\tv38 = ~v6;\n\tv39 = v38 | v9;\n\tif (v39) goto L_0022;\n\tthrow System.TypeLoadException;\nL_001D:\n\treturn 0;\nL_0022:\n\tv90 = new System.IndexOutOfRangeException();\n\tthrow v90;\n\treturn returnVal3;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetParticleMaxRadius(int index)
		{
			Vector3[] array = principalRadii;
			if (principalRadii != null)
			{
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				if (array.Length > index)
				{
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						throw new TypeLoadException();
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			return 0f;
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xE39818", Offset = "0xE39818", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.colors;\n\tv2 = this.colors == 0;\n\tif (v2) goto L_0026;\n\tv16 = v0.Length <= index;\n\tif (v16) goto L_0026;\n\tv39 = v0.Length < index;\n\tv40 = ~v39;\n\tv41 = v0.Length - index;\n\tv43 = v41 == 0;\n\tv48 = ~v40;\n\tv49 = v48 | v43;\n\tif (v49) goto L_002F;\n\tv54 = index << 4;\n\tv55 = this.colors + v54;\n\treturn *([v55 @ X8_v2+20]);\nL_0026:\n\treturnVal1 = UnityEngine.Color::get_white();\n\treturn returnVal1;\nL_002F:\n\tv65 = new System.IndexOutOfRangeException();\n\tthrow v65;\n\treturn returnVal3;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color GetParticleColor(int index)
		{
			//IL_00c7: Expected O, but got I
			//IL_00d4: Expected O, but got I
			Color[] array = colors;
			if (colors != null && array.Length > index)
			{
				bool flag = array.Length < index;
				bool flag2 = !flag;
				int num = array.Length - index;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = index << 4;
					object obj = (long)(IntPtr)colors + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v2+20]");
					return (Color)0;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return Color.white;
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0xE39868", Offset = "0xE39868", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0E100]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246CD]) = v38;\nL_0014:\n\tv40 = Obi.ObiActorBlueprint::Generate(this);\nL_001E:\n\tgoto L_0045;\n\tv102 = *([v98 @ X8_v4+B0]);\n\tv103 = 0;\n\tv104 = v102 + 8;\n\tv106 = *([v170 @ X11_v6-8]);\n\tv175 = v106 == v99;\n\tif (v175) goto L_003E;\n\tv126 = v169 + 1;\n\tv180 = v126 < v100;\n\tv124 = ~v180;\n\tv128 = v170 + 0x10;\n\tv108 = ~v124;\n\tif (v108) goto L_FFFFFFFF;\n\tv129 = v41;\n\tv130 = 0;\n\tv131 = 0x8909C4(v129, v99, v130, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0045;\nL_003E:\n\tv181 = *([v170 @ X11_v6]);\n\tv182 = v181 << 4;\n\tv183 = v98 + v182;\n\tv184 = v183 + 0x130;\nL_0045:\n\tv93 = System.Collections.IEnumerator::MoveNext(v40);\n\tv189 = v93 == 0;\n\tv95 = ~v189;\n\tif (v95) goto L_001E;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GenerateImmediate()
		{
			IEnumerator enumerator = Generate();
			while (enumerator.MoveNext())
			{
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7470B8", Offset = "0x7470B8")]
		[Token(Token = "0x60001D2")]
		[Address(RVA = "0xE39928", Offset = "0xE39928", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAF2E0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246CE]) = v38;\nL_0016:\n\tv42 = new Obi.ObiActorBlueprint+<Generate>d__68();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator Generate()
		{
			_003CGenerate_003Ed__68 _003CGenerate_003Ed__69 = null;
			_003CGenerate_003Ed__69._003C_003E1__state = 0;
			_003CGenerate_003Ed__69._003C_003E4__this = this;
			return _003CGenerate_003Ed__69;
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xE399C8", Offset = "0xE399C8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ECA948]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, index, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246CF]) = v44;\nL_0017:\n\tv45 = index & 0x80000000;\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_FFFFFFFF;\n\tv48 = this.groups;\n\tv51 = v48._size >= index;\n\tif (v51) goto L_002F;\n\tgoto L_0049;\nL_002F:\n\tv116 = UnityEngine.ScriptableObject::CreateInstance();\n\tv116.m_Blueprint = this;\n\tUnityEngine.Object::set_name(v116, name);\n\tSystem.Collections.Generic.List`1<Obi.ObiParticleGroup>::Insert(this.groups, index, v116);\nL_0049:\n\treturn v104;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleGroup InsertNewParticleGroup(string name, int index)
		{
			//IL_00a3: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0)
			{
				List<ObiParticleGroup> list = groups;
				if (list.Count >= index)
				{
					ObiParticleGroup obiParticleGroup = ScriptableObject.CreateInstance<ObiParticleGroup>();
					obiParticleGroup.m_Blueprint = this;
					obiParticleGroup.name = name;
					groups.Insert(index, obiParticleGroup);
					return obiParticleGroup;
				}
			}
			return null;
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0xE39A90", Offset = "0xE39A90", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEA870]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246D0]) = v41;\nL_0015:\n\tv42 = this.groups;\n\treturnVal1 = Obi.ObiActorBlueprint::InsertNewParticleGroup(this, name, v42._size);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleGroup AppendNewParticleGroup(string name)
		{
			List<ObiParticleGroup> list = groups;
			return InsertNewParticleGroup(name, list.Count);
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0xE39AF8", Offset = "0xE39AF8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAE4B8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246D1]) = v41;\nL_0015:\n\tv42 = index & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\n\tv136 = this.groups;\n\tv79 = v136._size < index;\n\tv72 = ~v79;\n\tv69 = v136._size - index;\n\tv63 = v69 == 0;\n\tv48 = v136._size <= index;\n\tif (v48) goto L_FFFFFFFF;\n\tv143 = ~v72;\n\tv83 = v143 | v63;\n\tif (v83) goto L_003B;\n\tv166 = index << 3;\n\tv172 = v136._items + v166;\n\tgoto L_0043;\nL_0039:\n\treturn v129;\nL_003B:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv169 = index << 3;\n\tv172 = v136._items + v169;\nL_0043:\n\tv175 = v172 + 0x20;\n\tSystem.Collections.Generic.List`1<Obi.ObiParticleGroup>::RemoveAt(v136, index);\n\tgoto L_005A;\n\tv187 = *([v183 @ X0_v9+E0]);\n\tv188 = v187 == 0;\n\tv189 = ~v188;\n\tgoto L_005A;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v183, v179, v180, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005A:\n\tv123 = UnityEngine.Object::op_Inequality(*([v175 @ X8_v8]), 0);\n\tv126 = v123 == 0;\n\tif (v126) goto L_FFFFFFFF;\n\tgoto L_006C;\n\tv199 = *([v195 @ X0_v13+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_006C;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v195, v105, v102, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006C:\n\tUnityEngine.Object::DestroyImmediate(*([v175 @ X8_v8]), 1);\n\tgoto L_0039;\n\tgoto L_0039;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool RemoveParticleGroupAt(int index)
		{
			//IL_0178: Expected I4, but got I8
			//IL_00be: Expected O, but got I
			//IL_01af: Expected O, but got I
			if ((int)(index & 0x80000000L) == 0)
			{
				List<ObiParticleGroup> list = groups;
				bool flag = list.Count < index;
				bool flag2 = !flag;
				int num = list.Count - index;
				bool flag3 = num == 0;
				if (list.Count > index)
				{
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						int num2 = index << 3;
						object obj = (long)(IntPtr)list._items + (long)num2;
						object obj2 = (long)(IntPtr)obj + 32L;
						list.RemoveAt(index);
						if ((UnityEngine.Object)obj2 != null)
						{
							UnityEngine.Object.DestroyImmediate((UnityEngine.Object)obj2, allowDestroyingAssets: true);
							return true;
						}
						return true;
					}
					throw new ArgumentOutOfRangeException();
				}
			}
			return false;
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0xE39C24", Offset = "0xE39C24", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB9C10]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, index, name, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246D2]) = v44;\nL_0017:\n\tv45 = index & 0x80000000;\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_FFFFFFFF;\n\tv48 = this.groups;\n\tv82 = v48._size < index;\n\tv75 = ~v82;\n\tv72 = v48._size - index;\n\tv66 = v72 == 0;\n\tv51 = v48._size <= index;\n\tif (v51) goto L_FFFFFFFF;\n\tv116 = ~v66;\n\tv94 = v75 & v116;\n\tif (v94) goto L_0031;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0031:\n\tv155 = v48._items;\n\tUnityEngine.Object::set_name(v155[index @ X1 (System.Int32)], name);\n\tgoto L_0044;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool SetParticleGroupName(int index, string name)
		{
			//IL_00fe: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0)
			{
				List<ObiParticleGroup> list = groups;
				bool flag = list.Count < index;
				bool flag2 = !flag;
				int num = list.Count - index;
				bool flag3 = num == 0;
				if (list.Count > index)
				{
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiParticleGroup[] items = list._items;
					items[index].name = name;
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0xE39CC8", Offset = "0xE39CC8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F0AE60]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246D3]) = v44;\nL_0016:\n\tv168 = this.groups;\nL_0026:\n\tv148 = v105 >= v168._size;\n\tif (v148) goto L_0083;\n\tv180 = v168._size < v105;\n\tv101 = ~v180;\n\tv97 = v168._size - v105;\n\tv89 = v97 == 0;\n\tv181 = ~v89;\n\tv69 = v101 & v181;\n\tif (v69) goto L_0036;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0036:\n\tv184 = v168._items;\n\tgoto L_0047;\n\tv190 = *([v185 @ X0_v9+E0]);\n\tv191 = v190 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_0047;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v185, v122, v121, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0047:\n\tv109 = UnityEngine.Object::op_Inequality(v184[v105 @ X21_v5 (System.Int32)], 0);\n\tv198 = v109 == 0;\n\tif (v198) goto L_0071;\n\tv118 = this.groups;\n\tv221 = v118._size < v105;\n\tv212 = ~v221;\n\tv211 = v118._size - v105;\n\tv209 = v211 == 0;\n\tv222 = ~v209;\n\tv204 = v212 & v222;\n\tif (v204) goto L_005E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005E:\n\tv225 = v118._items;\n\tgoto L_006F;\n\tv230 = *([v226 @ X0_v15+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_006F;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v226, v58, v55, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006F:\n\tUnityEngine.Object::DestroyImmediate(v225[v105 @ X21_v5 (System.Int32)], 1);\nL_0071:\n\tv105 = v105 + 1;\n\tv219 = this.groups == 0;\n\tv111 = ~v219;\n\tif (v111) goto L_0026;\n\tthrow System.NullReferenceException;\nL_0083:\n\tSystem.Collections.Generic.List`1<Obi.ObiParticleGroup>::Clear(v168);\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearParticleGroups()
		{
			List<ObiParticleGroup> list = groups;
			int num = 0;
			while (num < list.Count)
			{
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				ObiParticleGroup[] items = list._items;
				if (items[num] != null)
				{
					List<ObiParticleGroup> list2 = groups;
					bool flag5 = list2.Count < num;
					bool flag6 = !flag5;
					int num3 = list2.Count - num;
					bool flag7 = num3 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiParticleGroup[] items2 = list2._items;
					UnityEngine.Object.DestroyImmediate(items2[num], allowDestroyingAssets: true);
				}
				num++;
				bool flag9 = groups == null;
				bool flag10 = !flag9;
				list = groups;
				if (!flag10)
				{
					throw new NullReferenceException();
				}
			}
			list.Clear();
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0xE39DF8", Offset = "0xE39DF8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1ECEA68]);\n\tv35 = *([v34 @ X8_v22]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, index, particles, selected, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([20246D4]) = v52;\nL_001D:\n\tv254 = particles._size;\n\tv65 = particles._size < 1;\n\tif (v65) goto L_FFFFFFFF;\nL_002D:\n\tv199 = v254 < v114;\n\tv200 = ~v199;\n\tv201 = v254 - v114;\n\tv203 = v201 == 0;\n\tv208 = ~v203;\n\tv209 = v200 & v208;\n\tif (v209) goto L_003C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv254 = particles._size;\nL_003C:\n\tv256 = particles._items;\n\tv262 = v256[v114 @ X22_v8 (System.Int32)] - index;\n\tv264 = v262 == 0;\n\tv269 = v254 < v114;\n\tv105 = ~v269;\n\tv102 = v254 - v114;\n\tv96 = v102 == 0;\n\tv270 = ~v96;\n\tv81 = v105 & v270;\n\tif (v81) goto L_0060;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv302 = particles._items;\nL_0060:\n\tv303 = v69 < selected.Length;\n\tv176 = ~v303;\n\tif (v176) goto L_009C;\n\tv77 = v77 | v264;\n\tv226 = selected[v69 @ X9_v9 (System.Int32)] == 0;\n\tv79 = v79 | v226;\n\tv237 = v77 & v79;\n\tv308 = v237 & 1;\n\tv309 = v308 == 0;\n\tv148 = ~v309;\n\tif (v148) goto L_FFFFFFFF;\n\tv254 = particles._size;\n\tv114 = v114 + 1;\n\tv129 = v114 < particles._size;\n\tif (v129) goto L_002D;\n\tgoto L_0099;\nL_0099:\n\treturn returnVal1;\n\tv116 = new System.NullReferenceException();\nL_009C:\n\tv182 = new System.IndexOutOfRangeException();\n\tthrow v182;\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool IsParticleSharedInConstraint(int index, List<int> particles, bool[] selected)
		{
			int count = particles.Count;
			if (particles.Count >= 1)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				do
				{
					bool flag = count < num3;
					bool flag2 = !flag;
					int num4 = count - num3;
					bool flag3 = num4 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items = particles._items;
					int num5 = items[num3] - index;
					bool flag5 = num5 == 0;
					bool flag6 = count < num3;
					bool flag7 = !flag6;
					int num6 = count - num3;
					bool flag8 = num6 == 0;
					bool flag9 = !flag8;
					bool flag10 = flag7 && flag9;
					int num7 = items[num3];
					if (!flag10)
					{
						throw new ArgumentOutOfRangeException();
					}
					if (num7 < selected.Length)
					{
						num |= (flag5 ? 1 : 0);
						bool flag11 = !selected[num7];
						num2 |= (flag11 ? 1 : 0);
						int num8 = num & num2;
						if ((num8 & 1) == 0)
						{
							count = particles.Count;
							num3++;
							continue;
						}
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num3 < particles.Count);
			}
			return false;
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0xE39F20", Offset = "0xE39F20", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv40 = *([1EABFE8]);\n\tv41 = *([v40 @ X8_v47]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, constraints, index, particles, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 0 | 1;\n\t*([20246D5]) = v57;\nL_001E:\n\tv58 = &v59 @ stack_-70;\n\tv63 = constraints->klass;\n\tv67 = *([v63 @ X8_v17 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v67) goto L_0046;\n\tv222 = *([v63 @ X8_v17 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_0031:\n\tv228 = *([v222 @ X11_v49-8]) == Obi.IObiConstraints;\n\tif (v228) goto L_0049;\n\tv223 = v223 + 1;\n\tv279 = v223 < *([v63 @ X8_v17 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv157 = ~v279;\n\tv222 = v222 + 0x10;\n\tv141 = ~v157;\n\tif (v141) goto L_0031;\nL_0046:\n\tv285 = 0x8909C4(constraints, Obi.IObiConstraints, 2, particles, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0050;\nL_0049:\n\tv281 = *([v222 @ X11_v49]) + 2;\n\tv282 = v281 << 4;\n\tv283 = v63 + v282;\n\tv285 = v283 + 0x130;\nL_0050:\n\t*([v285 @ X0_v28])(v203, constraints, *([v285 @ X0_v28+8]), v175, particles, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0081;\n\tv343 = *([v338 @ X8_v20+B0]);\n\tv344 = 0;\n\tv345 = v343 + 8;\n\tv347 = *([v393 @ X11_v44-8]);\n\tv399 = v347 == v341;\n\tif (v399) goto L_007A;\n\tv369 = v394 + 1;\n\tv406 = v369 < v340;\n\tv365 = ~v406;\n\tv367 = v393 + 0x10;\n\tv349 = ~v365;\n\tif (v349) goto L_FFFFFFFF;\n\tv370 = v207;\n\tv371 = 0;\n\tv372 = 0x8909C4(v370, v341, v371, particles, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0081;\nL_007A:\n\tv407 = *([v393 @ X11_v44]);\n\tv408 = v407 << 4;\n\tv409 = v338 + v408;\n\tv410 = v409 + 0x130;\nL_0081:\n\tv271 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraintsBatch>::GetEnumerator(v203);\nL_008F:\n\tgoto L_00B6;\n\tv638 = *([v508 @ X8_v24+B0]);\n\tv639 = 0;\n\tv640 = v638 + 8;\n\tv642 = *([v737 @ X11_v39-8]);\n\tv743 = v642 == v509;\n\tif (v743) goto L_00AF;\n\tv664 = v738 + 1;\n\tv785 = v664 < v510;\n\tv660 = ~v785;\n\tv662 = v737 + 0x10;\n\tv644 = ~v660;\n\tif (v644) goto L_FFFFFFFF;\n\tv665 = v129;\n\tv666 = 0;\n\tv667 = 0x8909C4(v665, v509, v666, v289, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00B6;\nL_00AF:\n\tv786 = *([v737 @ X11_v39]);\n\tv787 = v786 << 4;\n\tv788 = v508 + v787;\n\tv789 = v788 + 0x130;\nL_00B6:\n\tv569 = System.Collections.IEnumerator::MoveNext(v271);\n\tv795 = v569 == 0;\n\tif (v795) goto L_016D;\n\tgoto L_00E7;\n\tv811 = *([v804 @ X8_v28+B0]);\n\tv812 = 0;\n\tv813 = v811 + 8;\n\tv815 = *([v851 @ X11_v34-8]);\n\tv857 = v815 == v808;\n\tif (v857) goto L_00E0;\n\tv837 = v852 + 1;\n\tv862 = v837 < v806;\n\tv833 = ~v862;\n\tv835 = v851 + 0x10;\n\tv817 = ~v833;\n\tif (v817) goto L_FFFFFFFF;\n\tv838 = v129;\n\tv839 = 0;\n\tv840 = 0x8909C4(v838, v808, v839, v289, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00E7;\nL_00E0:\n\tv863 = *([v851 @ X11_v34]);\n\tv864 = v863 << 4;\n\tv865 = v804 + v864;\n\tv866 = v865 + 0x130;\nL_00E7:\n\tv328 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraintsBatch>::get_Current(v271);\n\tv330 = v328 == 0;\n\tif (v330) goto L_0178;\nL_00EC:\n\tv892 = *([v328 @ X0_v40 (Obi.IObiConstraintsBatch)]);\n\tv505 = *([v892 @ X8_v32 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v505) goto L_010E;\n\tv935 = *([v892 @ X8_v32 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_00F9:\n\tv941 = *([v935 @ X11_v29-8]) == Obi.IObiConstraintsBatch;\n\tif (v941) goto L_0111;\n\tv936 = v936 + 1;\n\tv946 = v936 < *([v892 @ X8_v32 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv917 = ~v946;\n\tv935 = v935 + 0x10;\n\tv901 = ~v917;\n\tif (v901) goto L_00F9;\nL_010E:\n\tv961 = 0x8909C4(v328, Obi.IObiConstraintsBatch, 1, v69, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0118;\nL_0111:\n\tv948 = *([v935 @ X11_v29]) + 1;\n\tv949 = v948 << 4;\n\tv950 = v892 + v949;\n\tv961 = v950 + 0x130;\nL_0118:\n\t*([v961 @ X0_v42])(v503, v328, *([v961 @ X0_v42+8]), v873, v69, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv87 = v74 >= v503;\n\tif (v87) goto L_008F;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(particles);\n\tv968 = *([v328 @ X0_v40 (Obi.IObiConstraintsBatch)]);\n\tv971 = *([v968 @ X8_v35 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v971) goto L_014B;\n\tv1012 = *([v968 @ X8_v35 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_0136:\n\tv1018 = *([v1012 @ X11_v24-8]) == Obi.IObiConstraintsBatch;\n\tif (v1018) goto L_014E;\n\tv1013 = v1013 + 1;\n\tv1023 = v1013 < *([v968 @ X8_v35 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv994 = ~v1023;\n\tv1012 = v1012 + 0x10;\n\tv978 = ~v994;\n\tif (v978) goto L_0136;\nL_014B:\n\tv1030 = 0x8909C4(v328, Obi.IObiConstraintsBatch, 0xF, v69, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0157;\nL_014E:\n\tv1025 = *([v1012 @ X11_v24]) + 0xF;\n\tv1026 = v1025 << 4;\n\tv1027 = v968 + v1026;\n\tv1030 = v1027 + 0x130;\nL_0157:\n\t*([v1030 @ X0_v48])(v1036, v328, v74, particles, *([v1030 @ X0_v48+8]), selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv568 = Obi.ObiActorBlueprint::IsParticleSharedInConstraint(v1036, index, particles, selected);\n\tv74 = v74 + 1;\n\tv889 = v568 == 0;\n\tif (v889) goto L_00EC;\n\t*([v58 @ X25_v1]) = 0x5F;\n\tv1038 = v271 == 0;\n\tv571 = ~v1038;\n\tif (v571) goto L_0199;\n\tgoto L_01C1;\nL_016D:\n\t*([v58 @ X25_v1]) = 0x5F;\n\tv810 = v271 == 0;\n\tv572 = ~v810;\n\tif (v572) goto L_0199;\n\tgoto L_01C1;\n\tthrow System.NullReferenceException;\n\tv211 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0178:\n\tv336 = new System.NullReferenceException();\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\nL_018A:\n\tv382 = v321 != 1;\n\tif (v382) goto L_01EB;\n\tv404 = 0x6D2BC0(v336, v321, v299, v288, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv580 = *([v404 @ X0_v22]);\n\tv415 = 0x6D2490(v404, v321, v299, v288, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv421 = v573 == 0;\n\tif (v421) goto L_01C1;\nL_0199:\n\tgoto L_01C0;\n\tv668 = *([v588 @ X8_v10+B0]);\n\tv669 = 0;\n\tv670 = v668 + 8;\n\tv672 = *([v758 @ X11_v8-8]);\n\tv764 = v672 == v591;\n\tif (v764) goto L_01B9;\n\tv694 = v759 + 1;\n\tv796 = v694 < v590;\n\tv690 = ~v796;\n\tv692 = v758 + 0x10;\n\tv674 = ~v690;\n\tif (v674) goto L_FFFFFFFF;\n\tv695 = v573;\n\tv696 = 0;\n\tv697 = 0x8909C4(v695, v591, v696, v512, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_01C0;\nL_01B9:\n\tv797 = *([v758 @ X11_v8]);\n\tv798 = v797 << 4;\n\tv799 = v588 + v798;\n\tv800 = v799 + 0x130;\nL_01C0:\n\tSystem.IDisposable::Dispose(v573);\nL_01C1:\n\tv633 = v627 + 1;\n\tv635 = v633 == 0;\n\tif (v635) goto L_01D8;\n\tv698 = v629 == 0;\n\tif (v698) goto L_01EA;\n\tv774 = *([v58 @ X25_v1+v627 @ X22_v2 (System.Int32)*4]) == 0x5F;\n\tif (v774) goto L_01EA;\nL_01D7:\n\tthrow System.TypeLoadException;\nL_01D8:\n\tv725 = v629 == 0;\n\tv726 = ~v725;\n\tif (v726) goto L_01D7;\nL_01EA:\n\treturn v628;\nL_01EB:\n\treturnVal1 = 0x6D2380(v336, v321, v299, v288, selected, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal1;\n// 287 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoesParticleShareConstraints(IObiConstraints constraints, int index, List<int> particles, bool[] selected)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0393: Expected O, but got I4
			//IL_06bd: Expected I, but got O
			//IL_0443: Expected I4, but got O
			//IL_01ce: Expected O, but got I4
			//IL_0492: Expected I4, but got O
			//IL_0151: Expected O, but got I
			//IL_0223: Expected I, but got O
			//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01e1: Expected O, but got Unknown
			//IL_01fe: Expected O, but got I
			//IL_020d: Expected O, but got I
			//IL_019d: Expected O, but got I
			//IL_025e: Expected O, but got I
			//IL_031f: Expected O, but got I4
			//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e5: Expected O, but got Unknown
			//IL_0302: Expected O, but got I
			//IL_0311: Expected O, but got I
			//IL_02aa: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			IntPtr intPtr = (IntPtr)constraints;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v17 (Il2CppClass<Obi.IObiConstraints>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v17 (Il2CppClass<Obi.IObiConstraints>)+B0]");
			object obj3 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X11_v49-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v17 (Il2CppClass<Obi.IObiConstraints>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj4 = obj3 + 2;
			int num3 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)intPtr + (long)num3;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			int num4 = index;
			goto IL_0565;
			IL_04e7:
			throw new TypeLoadException();
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 2;
			goto IL_0565;
			IL_0565:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v285 @ X0_v28] (should have been resolved before IL gen)");
			IEnumerable<IObiConstraintsBatch> enumerable = default(IEnumerable<IObiConstraintsBatch>);
			IEnumerator<IObiConstraintsBatch> enumerator = enumerable.GetEnumerator();
			List<int> list = particles;
			IEnumerator<IObiConstraintsBatch> enumerator2 = default(IEnumerator<IObiConstraintsBatch>);
			int num8;
			bool result;
			int num9;
			int num14 = default(int);
			ObiActorBlueprint obiActorBlueprint = default(ObiActorBlueprint);
			int num18 = default(int);
			bool result2 = default(bool);
			object obj15 = default(object);
			while (true)
			{
				int num5;
				int num6;
				int num7;
				if (!enumerator.MoveNext())
				{
					obj = 95;
					bool flag3 = enumerator == null;
					bool flag4 = !flag3;
					enumerator2 = enumerator;
					num5 = 0;
					num6 = 0;
					num7 = 0;
					if (!flag4)
					{
						num8 = 0;
						result = false;
						num9 = 0;
						break;
					}
				}
				else
				{
					IObiConstraintsBatch current = enumerator.Current;
					if (current != null)
					{
						int num10 = 0;
						List<int> list2 = null;
						while (true)
						{
							IntPtr intPtr2 = (IntPtr)current;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v32 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_01b6;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v32 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
							object obj7 = 0L + 8L;
							int num11 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v935 @ X11_v29-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
								{
									break;
								}
								num11++;
								int num12 = num11;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v32 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
								bool flag5 = (long)num12 < 0L;
								bool flag6 = !flag5;
								obj7 = (long)(IntPtr)obj7 + 16L;
								if (!flag6)
								{
									continue;
								}
								goto IL_01b6;
							}
							object obj8 = obj7 + 1;
							int num13 = (int)((long)(IntPtr)obj8 << 4);
							object obj9 = (long)intPtr2 + (long)num13;
							object obj10 = (long)(IntPtr)obj9 + 304L;
							goto IL_0604;
							IL_0604:
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v961 @ X0_v42] (should have been resolved before IL gen)");
							if (num10 >= num14)
							{
								break;
							}
							particles.Clear();
							IntPtr intPtr3 = (IntPtr)current;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ X8_v35 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_02c3;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ X8_v35 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
							object obj11 = 0L + 8L;
							int num15 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1012 @ X11_v24-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
								{
									break;
								}
								num15++;
								int num16 = num15;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ X8_v35 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
								bool flag7 = (long)num16 < 0L;
								bool flag8 = !flag7;
								obj11 = (long)(IntPtr)obj11 + 16L;
								if (!flag8)
								{
									continue;
								}
								goto IL_02c3;
							}
							object obj12 = obj11 + 15;
							int num17 = (int)((long)(IntPtr)obj12 << 4);
							object obj13 = (long)intPtr3 + (long)num17;
							object obj14 = (long)(IntPtr)obj13 + 304L;
							goto IL_0657;
							IL_02c3:
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
							goto IL_0657;
							IL_0657:
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1030 @ X0_v48] (should have been resolved before IL gen)");
							bool flag9 = obiActorBlueprint.IsParticleSharedInConstraint(index, particles, selected);
							num10++;
							bool flag10 = !flag9;
							list = (List<int>)(object)selected;
							list2 = particles;
							if (flag10)
							{
								continue;
							}
							goto IL_0316;
							IL_01b6:
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
							list2 = (List<int>)1;
							goto IL_0604;
						}
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
					if (num18 != 1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						return result2;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					num7 = (int)obj15;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					bool flag11 = enumerator2 == null;
					num5 = -1;
					num6 = 0;
					num8 = -1;
					result = false;
					num9 = (int)obj15;
					if (flag11)
					{
						break;
					}
				}
				goto IL_070d;
				IL_0316:
				obj = 95;
				bool flag12 = enumerator == null;
				bool flag13 = !flag12;
				enumerator2 = enumerator;
				num5 = 0;
				num6 = 1;
				num7 = 0;
				if (!flag13)
				{
					num8 = 0;
					result = true;
					num9 = 0;
					break;
				}
				goto IL_070d;
				IL_070d:
				enumerator2.Dispose();
				num8 = num5;
				result = (byte)num6 != 0;
				num9 = num7;
				break;
			}
			if (num8 + 1 != 0)
			{
				if (num9 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X25_v1+v627 @ X22_v2 (System.Int32)*4]");
					if ((IntPtr)0 != (IntPtr)95)
					{
						goto IL_04e7;
					}
				}
			}
			else if (num9 != 0)
			{
				goto IL_04e7;
			}
			return result;
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0xE3A3A0", Offset = "0xE3A3A0", Length = "0x4D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1EC26B8]);\n\tv39 = *([v38 @ X8_v53]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, constraints, particles, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20246D6]) = v56;\nL_0020:\n\tv59 = constraints->klass;\n\tv63 = *([v59 @ X8_v13 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v63) goto L_0043;\n\tv224 = *([v59 @ X8_v13 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_002E:\n\tv230 = *([v224 @ X11_v57-8]) == Obi.IObiConstraints;\n\tif (v230) goto L_0046;\n\tv225 = v225 + 1;\n\tv283 = v225 < *([v59 @ X8_v13 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv157 = ~v283;\n\tv224 = v224 + 0x10;\n\tv141 = ~v157;\n\tif (v141) goto L_002E;\nL_0043:\n\tv289 = 0x8909C4(constraints, Obi.IObiConstraints, 2, v485, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_004D;\nL_0046:\n\tv285 = *([v224 @ X11_v57]) + 2;\n\tv286 = v285 << 4;\n\tv287 = v59 + v286;\n\tv289 = v287 + 0x130;\nL_004D:\n\t*([v289 @ X0_v22])(v205, constraints, *([v289 @ X0_v22+8]), v177, v485, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_007E;\n\tv308 = *([v293 @ X8_v16+B0]);\n\tv309 = 0;\n\tv310 = v308 + 8;\n\tv312 = *([v410 @ X11_v52-8]);\n\tv416 = v312 == v296;\n\tif (v416) goto L_0077;\n\tv334 = v411 + 1;\n\tv423 = v334 < v295;\n\tv330 = ~v423;\n\tv332 = v410 + 0x10;\n\tv314 = ~v330;\n\tif (v314) goto L_FFFFFFFF;\n\tv335 = v209;\n\tv336 = 0;\n\tv337 = 0x8909C4(v335, v296, v336, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_007E;\nL_0077:\n\tv424 = *([v410 @ X11_v52]);\n\tv425 = v424 << 4;\n\tv426 = v293 + v425;\n\tv427 = v426 + 0x130;\nL_007E:\n\tv275 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraintsBatch>::GetEnumerator(v205);\n\tv277 = v275 == 0;\n\tif (v277) goto L_01CB;\n\tgoto L_0193;\nL_008F:\n\tgoto L_00B6;\n\tv764 = *([v760 @ X8_v23+B0]);\n\tv765 = 0;\n\tv766 = v764 + 8;\n\tv768 = *([v804 @ X11_v42-8]);\n\tv810 = v768 == v761;\n\tif (v810) goto L_00AF;\n\tv790 = v805 + 1;\n\tv815 = v790 < v762;\n\tv786 = ~v815;\n\tv788 = v804 + 0x10;\n\tv770 = ~v786;\n\tif (v770) goto L_FFFFFFFF;\n\tv791 = v129;\n\tv792 = 0;\n\tv793 = 0x8909C4(v791, v761, v792, v486, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00B6;\nL_00AF:\n\tv816 = *([v804 @ X11_v42]);\n\tv817 = v816 << 4;\n\tv818 = v760 + v817;\n\tv819 = v818 + 0x130;\nL_00B6:\n\tv840 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraintsBatch>::get_Current(v275);\n\tv842 = *([v840 @ X0_v34 (Obi.IObiConstraintsBatch)]);\n\tv845 = *([v842 @ X8_v27 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v845) goto L_00DC;\n\tv910 = *([v842 @ X8_v27 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_00C7:\n\tv916 = *([v910 @ X11_v37-8]) == Obi.IObiConstraintsBatch;\n\tif (v916) goto L_00DF;\n\tv911 = v911 + 1;\n\tv921 = v911 < *([v842 @ X8_v27 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv892 = ~v921;\n\tv910 = v910 + 0x10;\n\tv876 = ~v892;\n\tif (v876) goto L_00C7;\nL_00DC:\n\tv927 = 0x8909C4(v840, Obi.IObiConstraintsBatch, 1, v485, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_00E6;\nL_00DF:\n\tv923 = *([v910 @ X11_v37]) + 1;\n\tv924 = v923 << 4;\n\tv925 = v842 + v924;\n\tv927 = v925 + 0x130;\nL_00E6:\n\t*([v927 @ X0_v38])(v625, v840, *([v927 @ X0_v38+8]), v583, v485, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv848 = v625 - 1;\n\tv930 = v848 & 0x80000000;\n\tv931 = v930 == 0;\n\tv628 = ~v931;\n\tif (v628) goto L_0193;\nL_00F0:\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(particles);\n\tv937 = *([v840 @ X0_v34 (Obi.IObiConstraintsBatch)]);\n\tv940 = *([v937 @ X8_v31 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v940) goto L_0113;\n\tv981 = *([v937 @ X8_v31 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_00FE:\n\tv987 = *([v981 @ X11_v32-8]) == Obi.IObiConstraintsBatch;\n\tif (v987) goto L_0116;\n\tv982 = v982 + 1;\n\tv992 = v982 < *([v937 @ X8_v31 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv963 = ~v992;\n\tv981 = v981 + 0x10;\n\tv947 = ~v963;\n\tif (v947) goto L_00FE;\nL_0113:\n\tv1013 = 0x8909C4(v840, Obi.IObiConstraintsBatch, 0xF, v846, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_011B;\nL_0116:\n\tv994 = *([v981 @ X11_v32]) + 0xF;\n\tv995 = v994 << 4;\n\tv996 = v937 + v995;\n\tv1013 = v996 + 0x130;\nL_011B:\n\tv846 = *([v1013 @ X0_v45+8]);\n\t*([v1013 @ X0_v45])(v1019, v840, v848, particles, *([v1013 @ X0_v45+8]), v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv1081 = particles._size;\n\tv1031 = particles._size < 1;\n\tif (v1031) goto L_018B;\nL_012E:\n\tv1082 = v1081 < v1034;\n\tv1083 = ~v1082;\n\tv1084 = v1081 - v1034;\n\tv1086 = v1084 == 0;\n\tv1091 = ~v1086;\n\tv1092 = v1083 & v1091;\n\tif (v1092) goto L_013C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_013C:\n\tv1094 = particles._items;\n\tv1108 = this.m_ActiveParticleCount <= v1094[v1034 @ X28_v13 (System.Int32)];\n\tif (v1108) goto L_0161;\n\tv1081 = particles._size;\n\tv1034 = v1034 + 1;\n\tv1040 = v1034 < particles._size;\n\tif (v1040) goto L_012E;\n\tgoto L_018B;\nL_0161:\n\tgoto L_018A;\n\tv1114 = *([v1111 @ X8_v40+B0]);\n\tv1115 = 0;\n\tv1116 = v1114 + 8;\n\tv1118 = *([v1154 @ X11_v27-8]);\n\tv1160 = v1118 == v1112;\n\tif (v1160) goto L_0181;\n\tv1140 = v1155 + 1;\n\tv1165 = v1140 < v1113;\n\tv1136 = ~v1165;\n\tv1138 = v1154 + 0x10;\n\tv1120 = ~v1136;\n\tif (v1120) goto L_FFFFFFFF;\n\tv1141 = 0xA;\n\tv1142 = v133;\n\tv1143 = 0x8909C4(v1142, v1112, v1141, v571, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_018A;\nL_0181:\n\tv1166 = *([v1154 @ X11_v27]);\n\tv1167 = v1166 + 0xA;\n\tv1168 = v1167 << 4;\n\tv1169 = v1111 + v1168;\n\tv1170 = v1169 + 0x130;\nL_018A:\n\tv1062 = Obi.IObiConstraintsBatch::DeactivateConstraint(v840, v848);\nL_018B:\n\tv848 = v848 - 1;\n\tv1068 = v848 & 0x80000000;\n\tv627 = v1068 == 0;\n\tif (v627) goto L_00F0;\nL_0193:\n\tgoto L_01BA;\n\tv667 = *([v632 @ X8_v20+B0]);\n\tv668 = 0;\n\tv669 = v667 + 8;\n\tv671 = *([v729 @ X11_v47-8]);\n\tv735 = v671 == v633;\n\tif (v735) goto L_01B3;\n\tv693 = v730 + 1;\n\tv748 = v693 < v634;\n\tv689 = ~v748;\n\tv691 = v729 + 0x10;\n\tv673 = ~v689;\n\tif (v673) goto L_FFFFFFFF;\n\tv694 = v129;\n\tv695 = 0;\n\tv696 = 0x8909C4(v694, v633, v695, v486, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_01BA;\nL_01B3:\n\tv749 = *([v729 @ X11_v47]);\n\tv750 = v749 << 4;\n\tv751 = v632 + v750;\n\tv752 = v751 + 0x130;\nL_01BA:\n\tv528 = System.Collections.IEnumerator::MoveNext(v275);\n\tv757 = v528 == 0;\n\tv758 = ~v757;\n\tif (v758) goto L_008F;\n\tv759 = v275 == 0;\n\tv530 = ~v759;\n\tif (v530) goto L_01EC;\n\tgoto L_0214;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv213 = new System.NullReferenceException();\nL_01CB:\n\tv282 = new System.NullReferenceException();\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\n\tgoto L_01DE;\nL_01DE:\n\tv307 = v379 != 1;\n\tif (v307) goto L_0230;\n\tv338 = 0x6D2BC0(v282, v379, v357, v340, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv534 = *([v338 @ X0_v18]);\n\tv422 = 0x6D2490(v338, v379, v357, v340, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv432 = v533 == 0;\n\tif (v432) goto L_0214;\nL_01EC:\n\tgoto L_0213;\n\tv636 = *([v541 @ X8_v7+B0]);\n\tv637 = 0;\n\tv638 = v636 + 8;\n\tv640 = *([v707 @ X11_v9-8]);\n\tv713 = v640 == v544;\n\tif (v713) goto L_020C;\n\tv662 = v708 + 1;\n\tv740 = v662 < v543;\n\tv658 = ~v740;\n\tv660 = v707 + 0x10;\n\tv642 = ~v658;\n\tif (v642) goto L_FFFFFFFF;\n\tv663 = v533;\n\tv664 = 0;\n\tv665 = 0x8909C4(v663, v544, v664, v485, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0213;\nL_020C:\n\tv741 = *([v707 @ X11_v9]);\n\tv742 = v741 << 4;\n\tv743 = v541 + v742;\n\tv744 = v743 + 0x130;\nL_0213:\n\tSystem.IDisposable::Dispose(v275);\nL_0214:\n\tv570 = v390 + 1;\n\tv370 = v570 == 0;\n\tv360 = ~v370;\n\tif (v360) goto L_022B;\n\tv666 = v394 == 0;\n\tv388 = ~v666;\n\tif (v388) goto L_022F;\nL_022B:\n\treturn;\nL_022F:\n\tv386 = new System.TypeLoadException();\nL_0230:\n\tv399 = 0x6D2380(v282, 0, 0, v340, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn;\n// 317 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DeactivateConstraintsWithInactiveParticles(IObiConstraints constraints, List<int> particles)
		{
			//IL_000d: Expected I, but got O
			//IL_00c5: Expected O, but got I4
			//IL_0048: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_046a: Expected I4, but got O
			//IL_04af: Expected I4, but got O
			//IL_0128: Expected I, but got O
			//IL_05db: Expected I4, but got I8
			//IL_0163: Expected O, but got I
			//IL_023e: Expected I, but got O
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			//IL_0210: Expected O, but got I
			//IL_021f: Expected O, but got I
			//IL_01af: Expected O, but got I
			//IL_0279: Expected O, but got I
			//IL_06f9: Expected I4, but got I8
			//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
			//IL_0300: Expected O, but got Unknown
			//IL_031d: Expected O, but got I
			//IL_032c: Expected O, but got I
			//IL_02c5: Expected O, but got I
			IntPtr intPtr = (IntPtr)constraints;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v13 (Il2CppClass<Obi.IObiConstraints>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v13 (Il2CppClass<Obi.IObiConstraints>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ X11_v57-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v13 (Il2CppClass<Obi.IObiConstraints>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			object obj5 = particles;
			goto IL_053b;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			obj5 = 2;
			goto IL_053b;
			IL_053b:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v289 @ X0_v22] (should have been resolved before IL gen)");
			IEnumerable<IObiConstraintsBatch> enumerable = default(IEnumerable<IObiConstraintsBatch>);
			IEnumerator<IObiConstraintsBatch> enumerator = enumerable.GetEnumerator();
			int num5;
			IntPtr intPtr2 = default(IntPtr);
			int num6;
			int num7;
			int num8;
			IntPtr intPtr3 = default(IntPtr);
			NullReferenceException ex;
			if (enumerator == null)
			{
				ex = new NullReferenceException();
				int num4 = default(int);
				if (num4 != 1)
				{
					goto IL_0501;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj6 = default(object);
				num5 = (int)obj6;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator<IObiConstraintsBatch> enumerator2 = default(IEnumerator<IObiConstraintsBatch>);
				bool flag3 = enumerator2 == null;
				intPtr2 = intPtr3;
				num6 = -1;
				num7 = -1;
				num8 = (int)obj6;
				if (flag3)
				{
					goto IL_0769;
				}
			}
			else
			{
				object obj11 = default(object);
				while (enumerator.MoveNext())
				{
					IObiConstraintsBatch current = enumerator.Current;
					IntPtr intPtr4 = (IntPtr)current;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ X8_v27 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01c8;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ X8_v27 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
					object obj7 = 0L + 8L;
					int num9 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v910 @ X11_v37-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
						{
							break;
						}
						num9++;
						int num10 = num9;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v842 @ X8_v27 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
						bool flag4 = (long)num10 < 0L;
						bool flag5 = !flag4;
						obj7 = (long)(IntPtr)obj7 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_01c8;
					}
					object obj8 = obj7 + 1;
					int num11 = (int)((long)(IntPtr)obj8 << 4);
					object obj9 = (long)intPtr4 + (long)num11;
					object obj10 = (long)(IntPtr)obj9 + 304L;
					int num12 = 0;
					goto IL_05b0;
					IL_01c8:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					num12 = 1;
					goto IL_05b0;
					IL_05b0:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v927 @ X0_v38] (should have been resolved before IL gen)");
					int num13 = (int)((long)(IntPtr)obj11 - 1L);
					int num14 = (int)(num13 & 0x80000000L);
					bool flag6 = num14 == 0;
					bool flag7 = !flag6;
					IntPtr intPtr5 = intPtr2;
					if (flag7)
					{
						continue;
					}
					bool flag15;
					do
					{
						particles.Clear();
						IntPtr intPtr6 = (IntPtr)current;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ X8_v31 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_02de;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ X8_v31 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
						object obj12 = 0L + 8L;
						int num15 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v981 @ X11_v32-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
							{
								break;
							}
							num15++;
							int num16 = num15;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v937 @ X8_v31 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
							bool flag8 = (long)num16 < 0L;
							bool flag9 = !flag8;
							obj12 = (long)(IntPtr)obj12 + 16L;
							if (!flag9)
							{
								continue;
							}
							goto IL_02de;
						}
						object obj13 = obj12 + 15;
						int num17 = (int)((long)(IntPtr)obj13 << 4);
						object obj14 = (long)intPtr6 + (long)num17;
						object obj15 = (long)(IntPtr)obj14 + 304L;
						goto IL_0635;
						IL_0635:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1013 @ X0_v45+8]");
						intPtr5 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1013 @ X0_v45] (should have been resolved before IL gen)");
						int count = particles.Count;
						if (particles.Count >= 1)
						{
							int num18 = 0;
							do
							{
								bool flag10 = count < num18;
								bool flag11 = !flag10;
								int num19 = count - num18;
								bool flag12 = num19 == 0;
								bool flag13 = !flag12;
								if (!(flag11 && flag13))
								{
									throw new ArgumentOutOfRangeException();
								}
								int[] items = particles._items;
								if (activeParticleCount > items[num18])
								{
									count = particles.Count;
									num18++;
									continue;
								}
								bool flag14 = current.DeactivateConstraint(num13);
								break;
							}
							while (num18 < particles.Count);
						}
						num13--;
						int num20 = (int)(num13 & 0x80000000L);
						flag15 = num20 == 0;
						intPtr2 = intPtr5;
						continue;
						IL_02de:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						goto IL_0635;
					}
					while (flag15);
				}
				bool flag16 = enumerator == null;
				bool flag17 = !flag16;
				num6 = 0;
				num5 = 0;
				if (!flag17)
				{
					intPtr3 = intPtr2;
					num7 = 0;
					num8 = 0;
					goto IL_0769;
				}
			}
			enumerator.Dispose();
			intPtr3 = intPtr2;
			num7 = num6;
			num8 = num5;
			goto IL_0769;
			IL_0769:
			if (num7 + 1 != 0 || num8 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			ex = (NullReferenceException)(object)ex2;
			goto IL_0501;
			IL_0501:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0xE3A878", Offset = "0xE3A878", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EB1128]);\n\tv35 = *([v34 @ X8_v31]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, index, newIndex, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20246D7]) = v52;\nL_001F:\n\tv57 = this.groups == 0;\n\tif (v57) goto L_00AA;\n\tv63 = System.Collections.Generic.List`1<Obi.ObiParticleGroup>::GetEnumerator(this.groups);\nL_0030:\n\tv177 = System.Collections.Generic.List`1<Obi.ObiParticleGroup>+Enumerator<Obi.ObiParticleGroup>::MoveNext(&v62 @ stack_-88_v3 (System.Collections.Generic.List`1<Obi.ObiParticleGroup>+Enumerator<Obi.ObiParticleGroup>));\n\tv189 = v177 == 0;\n\tif (v189) goto L_00A1;\n\tv161 = *([v131 @ stack_-78+18]);\nL_0045:\n\tv143 = v170 >= v161._size;\n\tif (v143) goto L_0030;\n\tv378 = v161._size < v170;\n\tv379 = ~v378;\n\tv380 = v161._size - v170;\n\tv382 = v380 == 0;\n\tv388 = ~v382;\n\tv389 = v379 & v388;\n\tif (v389) goto L_0057;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv271 = *([v131 @ stack_-78+18]);\nL_0057:\n\tv393 = v161._items;\n\tv406 = v393[v170 @ X21_v10 (System.Int32)] != newIndex;\n\tif (v406) goto L_0071;\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(v271, v170, index);\n\tgoto L_0096;\nL_0071:\n\tv416 = v271._size < v170;\n\tv417 = ~v416;\n\tv418 = v271._size - v170;\n\tv420 = v418 == 0;\n\tv425 = ~v420;\n\tv426 = v417 & v425;\n\tif (v426) goto L_007F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_007F:\n\tv433 = v271._items;\n\tv447 = v433[v170 @ X21_v10 (System.Int32)] != index;\n\tif (v447) goto L_0096;\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(*([v131 @ stack_-78+18]), v170, newIndex);\nL_0096:\n\tv161 = *([v131 @ stack_-78+18]);\n\tv170 = v170 + 1;\n\tv455 = *([v131 @ stack_-78+18]) == 0;\n\tv293 = ~v455;\n\tif (v293) goto L_0045;\n\tthrow System.NullReferenceException;\nL_00A1:\n\tv238 = System.Collections.Generic.List`1<Obi.ObiParticleGroup>+Enumerator<Obi.ObiParticleGroup>::Dispose(&v62 @ stack_-88_v3 (System.Collections.Generic.List`1<Obi.ObiParticleGroup>+Enumerator<Obi.ObiParticleGroup>));\n\tgoto L_00D5;\n\tthrow System.NullReferenceException;\n\tv430 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv120 = new System.NullReferenceException();\nL_00AA:\n\tv129 = new System.NullReferenceException();\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\n\tgoto L_00BD;\nL_00BD:\n\tv187 = v117 != 1;\n\tif (v187) goto L_00D6;\n\tv190 = 0x6D2BC0(v129, v117, v70, v72, v38, v39, v40, v41, v62, v43, v44, v45, v46, v47, v48, v49);\n\tv240 = 0x6D2490(v190, v117, v70, v72, v38, v39, v40, v41, v62, v43, v44, v45, v46, v47, v48, v49);\n\tv244 = System.Collections.Generic.List`1<Obi.ObiParticleGroup>+Enumerator<Obi.ObiParticleGroup>::Dispose(&v107 @ stack_-70_v3 (System.Collections.Generic.List`1<Obi.ObiParticleGroup>+Enumerator<Obi.ObiParticleGroup>));\n\tv335 = *([v190 @ X0_v10]) == 0;\n\tv246 = ~v335;\n\tif (v246) goto L_00DA;\nL_00D5:\n\treturn;\nL_00D6:\n\tv191 = 0x6D2380(v129, v117, v70, v72, v38, v39, v40, v41, v62, v43, v44, v45, v46, v47, v48, v49);\nL_00DA:\n\tthrow System.TypeLoadException;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ParticlesSwappedInGroups(int index, int newIndex)
		{
			//IL_0029: Expected O, but got I
			//IL_01b3: Expected O, but got I
			//IL_019e: Expected O, but got I
			bool flag = groups == null;
			List<ObiParticleGroup>.Enumerator enumerator2 = default(List<ObiParticleGroup>.Enumerator);
			List<ObiParticleGroup>.Enumerator enumerator = enumerator2;
			if (!flag)
			{
				List<ObiParticleGroup>.Enumerator enumerator3 = groups.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-78+18]");
					List<int> list = (List<int>)0;
					int num = 0;
					while (num < list.Count)
					{
						bool flag2 = list.Count < num;
						bool flag3 = !flag2;
						int num2 = list.Count - num;
						bool flag4 = num2 == 0;
						bool flag5 = !flag4;
						bool flag6 = flag3 && flag5;
						List<int> list2 = list;
						if (!flag6)
						{
							throw new ArgumentOutOfRangeException();
						}
						int[] items = list._items;
						if (items[num] == newIndex)
						{
							list2.set_Item(num, index);
						}
						else
						{
							bool flag7 = list2.Count < num;
							bool flag8 = !flag7;
							int num3 = list2.Count - num;
							bool flag9 = num3 == 0;
							bool flag10 = !flag9;
							if (!(flag8 && flag10))
							{
								throw new ArgumentOutOfRangeException();
							}
							int[] items2 = list2._items;
							if (items2[num] == index)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-78+18]");
								((List<int>)0).set_Item(num, newIndex);
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-78+18]");
						list = (List<int>)0;
						num++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ stack_-78+18]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							throw new NullReferenceException();
						}
					}
				}
				enumerator2.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			int num4 = default(int);
			if (num4 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0xE3AA94", Offset = "0xE3AA94", Length = "0x9F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001F;\n\tv37 = *([1F0C670]);\n\tv38 = *([v37 @ X8_v115]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, selected, optimize, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20246D8]) = v55;\nL_001F:\n\t*([v21 @ X29-60]) = &v57 @ stack_-80;\n\tv62 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v62);\n\tv134 = this.m_ActiveParticleCount - 1;\n\tv70 = v134 & 0x80000000;\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0035;\n\t*([v21 @ X29-54]) = 0xFFFFFFFF;\n\tgoto L_02D3;\nL_0035:\n\t*([v21 @ X29-54]) = 0xFFFFFFFF;\n\tgoto L_0317;\nL_0038:\n\tv667 = this.m_ActiveParticleCount - 1;\n\tthis.m_ActiveParticleCount = v667;\n\tv672 = Obi.ObiActorBlueprint::SwapWithFirstInactiveParticle(this, v134);\n\tgoto L_0053;\n\tv719 = *([v676 @ X0_v56+E0]);\n\tv720 = v719 == 0;\n\tv721 = ~v720;\n\tif (v721) goto L_0053;\n\tv723 = \"il2cpp_codegen_runtime_class_init\"(v676, v671, v670, v333, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0053:\n\tObi.ObiUtils::Swap(*([selected @ X1 (System.Boolean[]&)]), v134, this.m_ActiveParticleCount);\n\tv300 = Obi.ObiActorBlueprint::GetConstraints(this);\n\tgoto L_0086;\n\tv988 = *([v862 @ X8_v55+B0]);\n\tv989 = 0;\n\tv990 = v988 + 8;\n\tv992 = *([v1073 @ X11_v99-8]);\n\tv1079 = v992 == v866;\n\tif (v1079) goto L_007F;\n\tv1014 = v1074 + 1;\n\tv1140 = v1014 < v864;\n\tv1010 = ~v1140;\n\tv1012 = v1073 + 0x10;\n\tv994 = ~v1010;\n\tif (v994) goto L_FFFFFFFF;\n\tv1015 = v288;\n\tv1016 = 0;\n\tv1017 = 0x8909C4(v1015, v866, v1016, v286, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0086;\nL_007F:\n\tv1141 = *([v1073 @ X11_v99]);\n\tv1142 = v1141 << 4;\n\tv1143 = v862 + v1142;\n\tv1144 = v1143 + 0x130;\nL_0086:\n\tv1148 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraints>::GetEnumerator(v300);\n\tv630 = v1148 == 0;\n\tif (v630) goto L_0269;\nL_0090:\n\tgoto L_00B7;\n\tv1249 = *([v1222 @ X8_v59+B0]);\n\tv1250 = 0;\n\tv1251 = v1249 + 8;\n\tv1253 = *([v1300 @ X11_v94-8]);\n\tv1306 = v1253 == v1226;\n\tif (v1306) goto L_00B0;\n\tv1275 = v1301 + 1;\n\tv1311 = v1275 < v1224;\n\tv1271 = ~v1311;\n\tv1273 = v1300 + 0x10;\n\tv1255 = ~v1271;\n\tif (v1255) goto L_FFFFFFFF;\n\tv1276 = v337;\n\tv1277 = 0;\n\tv1278 = 0x8909C4(v1276, v1226, v1277, v334, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00B7;\nL_00B0:\n\tv1312 = *([v1300 @ X11_v94]);\n\tv1313 = v1312 << 4;\n\tv1314 = v1222 + v1313;\n\tv1315 = v1314 + 0x130;\nL_00B7:\n\tv1336 = System.Collections.IEnumerator::MoveNext(v1148);\n\tv1338 = v1336 == 0;\n\tif (v1338) goto L_025A;\n\tgoto L_00E8;\n\tv1351 = *([v1339 @ X8_v74+B0]);\n\tv1352 = 0;\n\tv1353 = v1351 + 8;\n\tv1355 = *([v1397 @ X11_v89-8]);\n\tv1403 = v1355 == v1343;\n\tif (v1403) goto L_00E1;\n\tv1377 = v1398 + 1;\n\tv1473 = v1377 < v1341;\n\tv1373 = ~v1473;\n\tv1375 = v1397 + 0x10;\n\tv1357 = ~v1373;\n\tif (v1357) goto L_FFFFFFFF;\n\tv1378 = v337;\n\tv1379 = 0;\n\tv1380 = 0x8909C4(v1378, v1343, v1379, v334, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_00E8;\nL_00E1:\n\tv1474 = *([v1397 @ X11_v89]);\n\tv1475 = v1474 << 4;\n\tv1476 = v1339 + v1475;\n\tv1477 = v1476 + 0x130;\nL_00E8:\n\tv1481 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraints>::get_Current(v1148);\n\tv628 = v1481 == 0;\n\tif (v628) goto L_0264;\n\tv1516 = *([v1481 @ X0_v79 (Obi.IObiConstraints)]);\n\tv1521 = *([v1516 @ X8_v77 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v1521) goto L_0110;\n\tv1574 = *([v1516 @ X8_v77 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_00FB:\n\tv1580 = *([v1574 @ X11_v84-8]) == Obi.IObiConstraints;\n\tif (v1580) goto L_0113;\n\tv1575 = v1575 + 1;\n\tv1585 = v1575 < *([v1516 @ X8_v77 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv1556 = ~v1585;\n\tv1574 = v1574 + 0x10;\n\tv1540 = ~v1556;\n\tif (v1540) goto L_00FB;\nL_0110:\n\tv1591 = Obi.ObiUtils::Swap(v1481, Obi.IObiConstraints, 2);\n\tgoto L_0118;\nL_0113:\n\tv1587 = *([v1574 @ X11_v84]) + 2;\n\tv1588 = v1587 << 4;\n\tv1589 = v1516 + v1588;\n\tv1591 = v1589 + 0x130;\nL_0118:\n\tv610 = *([v1591 @ X0_v82+8]);\n\t*([v1591 @ X0_v82])(v1594, v1481, *([v1591 @ X0_v82+8]), v593, v587, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv629 = v1594 == 0;\n\tif (v629) goto L_0267;\n\tgoto L_014B;\n\tv1602 = *([v1595 @ X8_v80+B0]);\n\tv1603 = 0;\n\tv1604 = v1602 + 8;\n\tv1606 = *([v1642 @ X11_v79-8]);\n\tv1648 = v1606 == v1599;\n\tif (v1648) goto L_0144;\n\tv1628 = v1643 + 1;\n\tv1653 = v1628 < v1597;\n\tv1624 = ~v1653;\n\tv1626 = v1642 + 0x10;\n\tv1608 = ~v1624;\n\tif (v1608) goto L_FFFFFFFF;\n\tv1629 = v592;\n\tv1630 = 0;\n\tv1631 = 0x8909C4(v1629, v1599, v1630, v334, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_014B;\nL_0144:\n\tv1654 = *([v1642 @ X11_v79]);\n\tv1655 = v1654 << 4;\n\tv1656 = v1595 + v1655;\n\tv1657 = v1656 + 0x130;\nL_014B:\n\tv1678 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraintsBatch>::GetEnumerator(v1594);\nL_014D:\n\tv625 = v1678 == 0;\n\tif (v625) goto L_01F0;\n\tgoto L_017C;\n\tv1709 = *([v1702 @ X8_v84+B0]);\n\tv1710 = 0;\n\tv1711 = v1709 + 8;\n\tv1713 = *([v1749 @ X11_v74-8]);\n\tv1755 = v1713 == v1706;\n\tif (v1755) goto L_0175;\n\tv1735 = v1750 + 1;\n\tv1760 = v1735 < v1704;\n\tv1731 = ~v1760;\n\tv1733 = v1749 + 0x10;\n\tv1715 = ~v1731;\n\tif (v1715) goto L_FFFFFFFF;\n\tv1736 = v590;\n\tv1737 = 0;\n\tv1738 = 0x8909C4(v1736, v1706, v1737, v587, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_017C;\nL_0175:\n\tv1761 = *([v1749 @ X11_v74]);\n\tv1762 = v1761 << 4;\n\tv1763 = v1702 + v1762;\n\tv1764 = v1763 + 0x130;\nL_017C:\n\tv1785 = System.Collections.IEnumerator::MoveNext(v1678);\n\tv1787 = v1785 == 0;\n\tif (v1787) goto L_01E5;\n\tgoto L_01AD;\n\tv1800 = *([v1788 @ X8_v98+B0]);\n\tv1801 = 0;\n\tv1802 = v1800 + 8;\n\tv1804 = *([v1846 @ X11_v69-8]);\n\tv1852 = v1804 == v1792;\n\tif (v1852) goto L_01A6;\n\tv1826 = v1847 + 1;\n\tv1921 = v1826 < v1790;\n\tv1822 = ~v1921;\n\tv1824 = v1846 + 0x10;\n\tv1806 = ~v1822;\n\tif (v1806) goto L_FFFFFFFF;\n\tv1827 = v590;\n\tv1828 = 0;\n\tv1829 = 0x8909C4(v1827, v1792, v1828, v587, v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_01AD;\nL_01A6:\n\tv1922 = *([v1846 @ X11_v69]);\n\tv1923 = v1922 << 4;\n\tv1924 = v1788 + v1923;\n\tv1925 = v1924 + 0x130;\nL_01AD:\n\tv1929 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraintsBatch>::get_Current(v1678);\n\tv626 = v1929 == 0;\n\tif (v626) goto L_01F3;\n\tv1954 = *([v1929 @ X0_v107 (Obi.IObiConstraintsBatch)]);\n\tv1700 = *([v1954 @ X8_v101 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v1700) goto L_01D6;\n\tv2010 = *([v1954 @ X8_v101 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_01C1:\n\tv2016 = *([v2010 @ X11_v64-8]) == Obi.IObiConstraintsBatch;\n\tif (v2016) goto L_01D9;\n\tv2011 = v2011 + 1;\n\tv2021 = v2011 < *([v1954 @ X8_v101 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv1992 = ~v2021;\n\tv2010 = v2010 + 0x10;\n\tv1976 = ~v1992;\n\tif (v1976) goto L_01C1;\nL_01D6:\n\tv2028 = Obi.ObiUtils::Swap(v1929, Obi.IObiConstraintsBatch, 0x10);\n\tgoto L_01DE;\nL_01D9:\n\tv2023 = *([v2010 @ X11_v64]) + 0x10;\n\tv2024 = v2023 << 4;\n\tv2025 = v1954 + v2024;\n\tv2028 = v2025 + 0x130;\nL_01DE:\n\tv587 = *([v2028 @ X0_v110+8]);\n\t*([v2028 @ X0_v110])(v1698, v1929, v134, this.m_ActiveParticleCount, *([v2028 @ X0_v110+8]), v261, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_014D;\nL_01E5:\n\tv1795 = *([v21 @ X29-60]);\n\tv1797 = *([v21 @ X29-54]) + 1;\n\t*([v21 @ X29-54]) = v1797;\n\t*([v1795 @ X8_v87+v1797 @ X9_v51*4]) = 0xC4;\n\tv1798 = v1678 == 0;\n\tv1799 = ~v1798;\n\tif (v1799) goto L_020F;\n\tgoto L_0237;\nL_01F0:\n\tv618 = new System.NullReferenceException();\n\tgoto L_03C1;\nL_01F3:\n\tv619 = new System.NullReferenceException();\n\tgoto L_03C1;\n\tgoto L_01F9;\n\tgoto L_01F9;\n\tgoto L_01F9;\n\tgoto L_01F9;\nL_01F9:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0274;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX27 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0237;\nL_020F:\n\tgoto L_0236;\n\tv1891 = *([v1830 @ X8_v94+B0]);\n\tv1892 = 0;\n\tv1893 = v1891 + 8;\n\tv1895 = *([v1943 @ X11_v57-8]);\n\tv1949 = v1895 == v1834;\n\tif (v1949) goto L_022F;\n\tv1917 = v1944 \n// ... truncated")]
		public void RemoveSelectedParticles(ref bool[] selected, bool optimize = true)
		{
			//IL_09cc: Expected I4, but got I8
			//IL_003a: Expected I, but got O
			//IL_001c: Expected I, but got O
			//IL_07ab: Expected I4, but got I8
			//IL_0800: Expected O, but got I
			//IL_0816: Expected O, but got I
			//IL_066e: Expected O, but got I4
			//IL_069c: Expected O, but got I4
			//IL_06c2: Expected I, but got O
			//IL_06cb: Expected O, but got I4
			//IL_0cb9: Expected O, but got I
			//IL_06fb: Expected I, but got O
			//IL_0704: Expected O, but got I4
			//IL_0734: Expected I, but got O
			//IL_073d: Expected O, but got I4
			//IL_0745: Expected I, but got O
			//IL_074e: Expected O, but got I4
			//IL_0936: Expected O, but got I
			//IL_087c: Expected O, but got I
			//IL_0449: Expected O, but got I
			//IL_045f: Expected O, but got I
			//IL_08b5: Expected I, but got O
			//IL_08de: Expected O, but got I4
			//IL_08e6: Expected I, but got O
			//IL_08f6: Expected O, but got I
			//IL_0c0d: Expected O, but got I
			//IL_0c23: Expected O, but got I
			//IL_00a4: Expected I, but got O
			//IL_0530: Expected O, but got I
			//IL_015c: Expected I4, but got O
			//IL_00df: Expected O, but got I
			//IL_0572: Expected I4, but got I8
			//IL_0587: Expected O, but got I
			//IL_0173: Unknown result type (might be due to invalid IL or missing references)
			//IL_0178: Expected O, but got Unknown
			//IL_0195: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_012b: Expected O, but got I
			//IL_02d5: Expected O, but got I
			//IL_02eb: Expected O, but got I
			//IL_0bbc: Expected O, but got I
			//IL_0bd2: Expected O, but got I
			//IL_03fb: Expected I, but got O
			//IL_01c9: Expected I, but got O
			//IL_0386: Expected O, but got I
			//IL_0281: Expected I4, but got O
			//IL_0204: Expected O, but got I
			//IL_03c8: Expected I4, but got I8
			//IL_03dd: Expected O, but got I
			//IL_028f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0294: Expected O, but got Unknown
			//IL_02b1: Expected O, but got I
			//IL_02c0: Expected O, but got I
			//IL_0250: Expected O, but got I
			object obj = obj;
			List<int> list = new List<int>();
			int num = activeParticleCount - 1;
			bool[] source;
			bool flag11;
			int index;
			int num2;
			IntPtr intPtr4;
			object obj22;
			if ((int)(num & 0x80000000L) == 0)
			{
				_ = 4294967295L;
				IntPtr intPtr = (IntPtr)null;
				ObiActorBlueprint obiActorBlueprint = (ObiActorBlueprint)(object)list;
				IEnumerable<IObiConstraintsBatch> enumerable = default(IEnumerable<IObiConstraintsBatch>);
				IntPtr intPtr3 = default(IntPtr);
				while (true)
				{
					bool[] array = selected;
					IntPtr intPtr2;
					ObiActorBlueprint obiActorBlueprint2;
					if (array[num])
					{
						bool flag = !optimize;
						intPtr2 = intPtr3;
						obiActorBlueprint2 = obiActorBlueprint;
						if (flag)
						{
							goto IL_075c;
						}
						bool flag2 = obiActorBlueprint.DoesParticleShareConstraints(distanceConstraintsData, num, list, array);
						bool flag3 = ((ObiActorBlueprint)flag2).DoesParticleShareConstraints(bendConstraintsData, num, list, selected);
						array = selected;
						bool flag4 = ((ObiActorBlueprint)flag3).DoesParticleShareConstraints(shapeMatchingConstraintsData, num, list, selected);
						bool flag5 = !flag2;
						bool flag6 = !flag5;
						intPtr3 = (IntPtr)list;
						obiActorBlueprint = (ObiActorBlueprint)flag4;
						if (!flag6)
						{
							bool flag7 = !flag3;
							bool flag8 = !flag7;
							intPtr3 = (IntPtr)list;
							obiActorBlueprint = (ObiActorBlueprint)flag4;
							if (!flag8)
							{
								bool flag9 = !flag4;
								bool flag10 = !flag9;
								intPtr2 = (IntPtr)list;
								obiActorBlueprint2 = (ObiActorBlueprint)flag4;
								intPtr3 = (IntPtr)list;
								obiActorBlueprint = (ObiActorBlueprint)flag4;
								if (!flag10)
								{
									goto IL_075c;
								}
							}
						}
					}
					goto IL_078b;
					IL_0323:
					NullReferenceException ex = new NullReferenceException();
					source = (bool[])(object)ex;
					flag11 = optimize;
					goto IL_086c;
					IL_04c7:
					NullReferenceException ex2 = new NullReferenceException();
					source = (bool[])(object)ex2;
					flag11 = optimize;
					goto IL_086c;
					IL_0497:
					NullReferenceException ex3 = new NullReferenceException();
					index = 0;
					num2 = 0;
					source = (bool[])(object)ex3;
					flag11 = optimize;
					goto IL_086c;
					IL_078b:
					num--;
					int num3 = (int)(num & 0x80000000L);
					bool flag12 = num3 == 0;
					intPtr4 = intPtr;
					if (flag12)
					{
						continue;
					}
					goto IL_07d2;
					IL_075c:
					bool flag13 = activeParticleCount > num;
					intPtr3 = intPtr2;
					obiActorBlueprint = obiActorBlueprint2;
					if (flag13)
					{
						int num4 = activeParticleCount - 1;
						m_ActiveParticleCount = num4;
						SwapWithFirstInactiveParticle(num);
						selected.Swap(num, activeParticleCount);
						IEnumerable<IObiConstraints> constraints = GetConstraints();
						IEnumerator<IObiConstraints> enumerator = constraints.GetEnumerator();
						bool flag14 = enumerator == null;
						intPtr3 = (IntPtr)0;
						if (!flag14)
						{
							while (enumerator.MoveNext())
							{
								IObiConstraints current = enumerator.Current;
								if (current == null)
								{
									goto IL_0497;
								}
								IntPtr intPtr5 = (IntPtr)current;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1516 @ X8_v77 (Il2CppClass<Obi.IObiConstraints>)+126]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									goto IL_0144;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1516 @ X8_v77 (Il2CppClass<Obi.IObiConstraints>)+B0]");
								object obj2 = 0L + 8L;
								int num5 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1574 @ X11_v84-8]");
									if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
									{
										break;
									}
									num5++;
									int num6 = num5;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1516 @ X8_v77 (Il2CppClass<Obi.IObiConstraints>)+126]");
									bool flag15 = (long)num6 < 0L;
									bool flag16 = !flag15;
									obj2 = (long)(IntPtr)obj2 + 16L;
									if (!flag16)
									{
										continue;
									}
									goto IL_0144;
								}
								object obj3 = obj2 + 2;
								int num7 = (int)((long)(IntPtr)obj3 << 4);
								object obj4 = (long)intPtr5 + (long)num7;
								object obj5 = (long)(IntPtr)obj4 + 304L;
								index = 0;
								goto IL_0aa2;
								IL_0aa2:
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1591 @ X0_v82+8]");
								num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1591 @ X0_v82] (should have been resolved before IL gen)");
								IEnumerator<IObiConstraintsBatch> enumerator2;
								if (enumerable != null)
								{
									enumerator2 = enumerable.GetEnumerator();
									index = 0;
									for (num2 = 0; enumerator2 != null; Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2028 @ X0_v110+8]"), intPtr3 = (IntPtr)0, Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2028 @ X0_v110] (should have been resolved before IL gen)"), index = activeParticleCount, num2 = num)
									{
										if (!enumerator2.MoveNext())
										{
											goto IL_02c5;
										}
										IObiConstraintsBatch current2 = enumerator2.Current;
										if (current2 != null)
										{
											IntPtr intPtr6 = (IntPtr)current2;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1954 @ X8_v101 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
											if ((IntPtr)0 != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1954 @ X8_v101 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
												object obj6 = 0L + 8L;
												int num8 = 0;
												while (true)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2010 @ X11_v64-8]");
													if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
													{
														break;
													}
													num8++;
													int num9 = num8;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1954 @ X8_v101 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
													bool flag17 = (long)num9 < 0L;
													bool flag18 = !flag17;
													obj6 = (long)(IntPtr)obj6 + 16L;
													if (!flag18)
													{
														continue;
													}
													goto IL_0269;
												}
												object obj7 = obj6 + 16;
												int num10 = (int)((long)(IntPtr)obj7 << 4);
												object obj8 = (long)intPtr6 + (long)num10;
												object obj9 = (long)(IntPtr)obj8 + 304L;
												continue;
											}
											goto IL_0269;
										}
										goto IL_0341;
										IL_0269:
										((bool[])(object)current2).Swap((int)typeof(IObiConstraintsBatch), 16);
									}
									goto IL_0323;
								}
								goto IL_04c7;
								IL_02c5:
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
								object obj10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
								object obj11 = 0L + 1L;
								_ = 196;
								enumerator2?.Dispose();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
								object obj12 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
								object obj13 = 0L + 1L;
								if (obj13 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
									object obj14 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1930 @ X8_v90+v603 @ X9_v53*4]");
									if ((IntPtr)0 == (IntPtr)196)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
										int num11 = -1;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
										object obj15 = 0L + (long)num11;
										continue;
									}
								}
								bool flag19 = intPtr == (IntPtr)0;
								intPtr = (IntPtr)null;
								if (flag19)
								{
									continue;
								}
								goto IL_0409;
								IL_0144:
								((bool[])(object)current).Swap((int)typeof(IObiConstraints), 2);
								index = 2;
								goto IL_0aa2;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
							object obj16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
							object obj17 = 0L + 1L;
							_ = 216;
							enumerator?.Dispose();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
							object obj18 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
							object obj19 = 0L + 1L;
							if (obj19 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
								object obj20 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1482 @ X8_v66+v1129 @ X9_v35*4]");
								if ((IntPtr)0 == (IntPtr)216)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
									int num12 = -1;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
									object obj21 = 0L + (long)num12;
									goto IL_05b9;
								}
							}
							if (intPtr == (IntPtr)0)
							{
								goto IL_05b9;
							}
							break;
						}
						NullReferenceException ex4 = new NullReferenceException();
						intPtr3 = (IntPtr)0;
						index = 0;
						num2 = 0;
						source = (bool[])(object)ex4;
						flag11 = optimize;
						goto IL_086c;
					}
					goto IL_078b;
					IL_05b9:
					ParticlesSwappedInGroups(num, activeParticleCount);
					obiActorBlueprint = this;
					goto IL_078b;
					IL_086c:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
					obj22 = 0;
					if (num2 == 1)
					{
						goto IL_089c;
					}
					source.Swap(num2, index);
					return;
					IL_0341:
					NullReferenceException ex5 = new NullReferenceException();
					index = 0;
					num2 = 0;
					source = (bool[])(object)ex5;
					flag11 = optimize;
					goto IL_086c;
					IL_0409:
					TypeLoadException ex6 = new TypeLoadException();
					index = 0;
					num2 = 0;
					source = (bool[])(object)ex6;
					flag11 = optimize;
					goto IL_086c;
				}
				goto IL_0861;
			}
			_ = 4294967295L;
			intPtr4 = (IntPtr)null;
			goto IL_07d2;
			IL_0861:
			throw new TypeLoadException();
			IL_089c:
			source.Swap(num2, index);
			bool[] array2 = default(bool[]);
			intPtr4 = (IntPtr)array2;
			array2.Swap(num2, index);
			bool flag20 = !flag11;
			IEnumerator<IObiConstraints> enumerator3 = (IEnumerator<IObiConstraints>)flag11;
			IntPtr intPtr7 = (IntPtr)array2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
			object obj23 = 0;
			if (flag20)
			{
				goto IL_0caa;
			}
			goto IL_0cd6;
			IL_0caa:
			object obj24 = (long)(IntPtr)obj23 + 1L;
			if (obj24 != null)
			{
				if (intPtr7 == (IntPtr)0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
				object obj25 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1105 @ X8_v11+v957 @ X19_v2*4]");
				if ((IntPtr)0 == (IntPtr)291)
				{
					return;
				}
			}
			else if (intPtr7 == (IntPtr)0)
			{
				return;
			}
			goto IL_0861;
			IL_0cd6:
			enumerator3.Dispose();
			intPtr7 = intPtr4;
			obj23 = obj22;
			goto IL_0caa;
			IL_07d2:
			IEnumerable<IObiConstraints> constraints2 = GetConstraints();
			IEnumerator<IObiConstraints> enumerator4 = constraints2.GetEnumerator();
			while (enumerator4.MoveNext())
			{
				IObiConstraints current3 = enumerator4.Current;
				DeactivateConstraintsWithInactiveParticles(current3, list);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
			object obj26 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-54]");
			obj22 = 0L + 1L;
			_ = 291;
			bool flag21 = enumerator4 == null;
			bool flag22 = !flag21;
			enumerator3 = enumerator4;
			if (!flag22)
			{
				intPtr7 = intPtr4;
				obj23 = obj22;
				goto IL_0caa;
			}
			goto IL_0cd6;
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xE3B484", Offset = "0xE3B484", Length = "0x674")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EAC128]);\n\tv35 = *([v34 @ X8_v70]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20246D9]) = v54;\nL_001B:\n\tv55 = &v56 @ stack_-70;\n\tthis.m_ActiveParticleCount = this.m_InitialActiveParticleCount;\n\tv60 = Obi.ObiActorBlueprint::GetConstraints(this);\n\tgoto L_0051;\n\tv140 = *([v64 @ X8_v17+B0]);\n\tv141 = 0;\n\tv142 = v140 + 8;\n\tv144 = *([v228 @ X11_v75-8]);\n\tv234 = v144 == v67;\n\tif (v234) goto L_004A;\n\tv166 = v229 + 1;\n\tv310 = v166 < v66;\n\tv162 = ~v310;\n\tv164 = v228 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_FFFFFFFF;\n\tv167 = v61;\n\tv168 = 0;\n\tv169 = 0x8909C4(v167, v67, v168, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0051;\nL_004A:\n\tv311 = *([v228 @ X11_v75]);\n\tv312 = v311 << 4;\n\tv313 = v64 + v312;\n\tv314 = v313 + 0x130;\nL_0051:\n\tv210 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraints>::GetEnumerator(v60);\nL_0061:\n\tgoto L_0088;\n\tv396 = *([v390 @ X8_v21+B0]);\n\tv397 = 0;\n\tv398 = v396 + 8;\n\tv400 = *([v499 @ X11_v70-8]);\n\tv505 = v400 == v391;\n\tif (v505) goto L_0081;\n\tv422 = v500 + 1;\n\tv613 = v422 < v392;\n\tv418 = ~v613;\n\tv420 = v499 + 0x10;\n\tv402 = ~v418;\n\tif (v402) goto L_FFFFFFFF;\n\tv423 = v134;\n\tv424 = 0;\n\tv425 = 0x8909C4(v423, v391, v424, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0088;\nL_0081:\n\tv614 = *([v499 @ X11_v70]);\n\tv615 = v614 << 4;\n\tv616 = v390 + v615;\n\tv617 = v616 + 0x130;\nL_0088:\n\tv638 = System.Collections.IEnumerator::MoveNext(v210);\n\tv640 = v638 == 0;\n\tif (v640) goto L_024A;\n\tgoto L_00B9;\n\tv749 = *([v700 @ X8_v26+B0]);\n\tv750 = 0;\n\tv751 = v749 + 8;\n\tv753 = *([v797 @ X11_v65-8]);\n\tv803 = v753 == v704;\n\tif (v803) goto L_00B2;\n\tv775 = v798 + 1;\n\tv808 = v775 < v702;\n\tv771 = ~v808;\n\tv773 = v797 + 0x10;\n\tv755 = ~v771;\n\tif (v755) goto L_FFFFFFFF;\n\tv776 = v134;\n\tv777 = 0;\n\tv778 = 0x8909C4(v776, v704, v777, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00B9;\nL_00B2:\n\tv809 = *([v797 @ X11_v65]);\n\tv810 = v809 << 4;\n\tv811 = v700 + v810;\n\tv812 = v811 + 0x130;\nL_00B9:\n\tv833 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraints>::get_Current(v210);\n\tv836 = *([v833 @ X0_v35 (Obi.IObiConstraints)]);\n\tv841 = *([v836 @ X8_v30 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v841) goto L_00E1;\n\tv906 = *([v836 @ X8_v30 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_00CC:\n\tv912 = *([v906 @ X11_v60-8]) == Obi.IObiConstraints;\n\tif (v912) goto L_00E4;\n\tv907 = v907 + 1;\n\tv917 = v907 < *([v836 @ X8_v30 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv866 = ~v917;\n\tv906 = v906 + 0x10;\n\tv850 = ~v866;\n\tif (v850) goto L_00CC;\nL_00E1:\n\tv923 = 0x8909C4(v833, Obi.IObiConstraints, 2, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00EB;\nL_00E4:\n\tv919 = *([v906 @ X11_v60]) + 2;\n\tv920 = v919 << 4;\n\tv921 = v836 + v920;\n\tv923 = v921 + 0x130;\nL_00EB:\n\t*([v923 @ X0_v41])(v892, v833, *([v923 @ X0_v41+8]), v877, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_011C;\n\tv932 = *([v926 @ X8_v33+B0]);\n\tv933 = 0;\n\tv934 = v932 + 8;\n\tv936 = *([v972 @ X11_v55-8]);\n\tv978 = v936 == v930;\n\tif (v978) goto L_0115;\n\tv958 = v973 + 1;\n\tv983 = v958 < v928;\n\tv954 = ~v983;\n\tv956 = v972 + 0x10;\n\tv938 = ~v954;\n\tif (v938) goto L_FFFFFFFF;\n\tv959 = v875;\n\tv960 = 0;\n\tv961 = 0x8909C4(v959, v930, v960, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_011C;\nL_0115:\n\tv984 = *([v972 @ X11_v55]);\n\tv985 = v984 << 4;\n\tv986 = v926 + v985;\n\tv987 = v986 + 0x130;\nL_011C:\n\tv1008 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraintsBatch>::GetEnumerator(v892);\nL_011E:\n\tv302 = v1008 == 0;\n\tif (v302) goto L_01E4;\n\tgoto L_014B;\n\tv1036 = *([v1031 @ X8_v37+B0]);\n\tv1037 = 0;\n\tv1038 = v1036 + 8;\n\tv1040 = *([v1076 @ X11_v50-8]);\n\tv1082 = v1040 == v1032;\n\tif (v1082) goto L_0144;\n\tv1062 = v1077 + 1;\n\tv1087 = v1062 < v1033;\n\tv1058 = ~v1087;\n\tv1060 = v1076 + 0x10;\n\tv1042 = ~v1058;\n\tif (v1042) goto L_FFFFFFFF;\n\tv1063 = v245;\n\tv1064 = 0;\n\tv1065 = 0x8909C4(v1063, v1032, v1064, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_014B;\nL_0144:\n\tv1088 = *([v1076 @ X11_v50]);\n\tv1089 = v1088 << 4;\n\tv1090 = v1031 + v1089;\n\tv1091 = v1090 + 0x130;\nL_014B:\n\tv1112 = System.Collections.IEnumerator::MoveNext(v1008);\n\tv1114 = v1112 == 0;\n\tif (v1114) goto L_01DB;\n\tgoto L_017A;\n\tv1122 = *([v1115 @ X8_v50+B0]);\n\tv1123 = 0;\n\tv1124 = v1122 + 8;\n\tv1126 = *([v1168 @ X11_v45-8]);\n\tv1174 = v1126 == v1116;\n\tif (v1174) goto L_0173;\n\tv1148 = v1169 + 1;\n\tv1242 = v1148 < v1117;\n\tv1144 = ~v1242;\n\tv1146 = v1168 + 0x10;\n\tv1128 = ~v1144;\n\tif (v1128) goto L_FFFFFFFF;\n\tv1149 = v245;\n\tv1150 = 0;\n\tv1151 = 0x8909C4(v1149, v1116, v1150, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_017A;\nL_0173:\n\tv1243 = *([v1168 @ X11_v45]);\n\tv1244 = v1243 << 4;\n\tv1245 = v1115 + v1244;\n\tv1246 = v1245 + 0x130;\nL_017A:\n\tv1250 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraintsBatch>::get_Current(v1008);\n\tv303 = v1250 == 0;\n\tif (v303) goto L_01E7;\n\tv1274 = *([v1250 @ X0_v64 (Obi.IObiConstraintsBatch)]);\n\tv1277 = *([v1274 @ X8_v53 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v1277) goto L_01A0;\n\tv1329 = *([v1274 @ X8_v53 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_018B:\n\tv1335 = *([v1329 @ X11_v40-8]) == Obi.IObiConstraintsBatch;\n\tif (v1335) goto L_01A3;\n\tv1330 = v1330 + 1;\n\tv1340 = v1330 < *([v1274 @ X8_v53 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv1311 = ~v1340;\n\tv1329 = v1329 + 0x10;\n\tv1295 = ~v1311;\n\tif (v1295) goto L_018B;\nL_01A0:\n\tv1361 = 0x8909C4(v1250, Obi.IObiConstraintsBatch, 3, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01AA;\nL_01A3:\n\tv1342 = *([v1329 @ X11_v40]) + 3;\n\tv1343 = v1342 << 4;\n\tv1344 = v1274 + v1343;\n\tv1361 = v1344 + 0x130;\nL_01AA:\n\t*([v1361 @ X0_v67])(v1366, v1250, *([v1361 @ X0_v67+8]), v1348, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1367 = *([v1250 @ X0_v64 (Obi.IObiConstraintsBatch)]);\n\tv1029 = *([v1367 @ X8_v56 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]) == 0;\n\tif (v1029) goto L_01CE;\n\tv1410 = *([v1367 @ X8_v56 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]) + 8;\nL_01B9:\n\tv1416 = *([v1410 @ X11_v35-8]) == Obi.IObiConstraintsBatch;\n\tif (v1416) goto L_01D1;\n\tv1411 = v1411 + 1;\n\tv1421 = v1411 < *([v1367 @ X8_v56 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]);\n\tv1392 = ~v1421;\n\tv1410 = v1410 + 0x10;\n\tv1376 = ~v1392;\n\tif (v1376) goto L_01B9;\nL_01CE:\n\tv1428 = 0x8909C4(v1250, Obi.IObiConstraintsBatch, 2, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01D6;\nL_01D1:\n\tv1423 = *([v1410 @ X11_v35]) + 2;\n\tv1424 = v1423 << 4;\n\tv1425 = v1367 + v1424;\n\tv1428 = v1425 + 0x130;\nL_01D6:\n\tv257 = *([v1428 @ X0_v70+8]);\n\t*([v1428 @ X0_v70])(v1027, v1250, v1366, *([v1428 @ X0_v70+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_011E;\nL_01DB:\n\tv706 = v706 + 1;\n\t*([v55 @ X24_v1+v706 @ X25_v10*4]) = 0x52;\n\tv1120 = v1008 == 0;\n\tv1121 = ~v1120;\n\tif (v1121) goto L_0204;\n\tgoto L_022C;\nL_01E4:\n\tv299 = new System.NullReferenceException();\n\tgoto L_0258;\nL_01E7:\n\tv300 = new System.NullReferenceException();\n\tgoto L_0258;\n\tgoto L_01EE;\n\tgoto L_01EE;\n\tgoto L_01EE;\n\tgoto L_01EE;\n\tgoto L_01EE;\nL_01EE:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_026A;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_022C;\nL_0204:\n\tgoto L_022B;\n\tv1212 = *([v1152 @ X8_v46+B0]);\n\tv1213 = 0;\n\tv1214 = v1212 + 8;\n\tv1216 = *([v1263 @ X11_v27-8]);\n\tv1269 = v1216 == v1156;\n\tif (v1269) goto L_0224;\n\tv1238 = v1264 + 1;\n\tv1281 = v1238 < v1154;\n\tv1234 = ~v1281;\n\tv1236 = v1263 + 0x10;\n\tv1218 = ~v1234;\n\tif (v1218) goto L_FFFFFFFF;\n\tv1239 = v245;\n\tv1240 = 0;\n\tv1241 = 0x8909C4(v1239, v1156, v1240, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_022B;\nL_\n// ... truncated")]
		public void RestoreRemovedParticles()
		{
			//IL_0017: Expected O, but got I8
			//IL_041e: Expected O, but got I
			//IL_07a0: Expected O, but got I
			//IL_0032: Expected I, but got O
			//IL_006d: Expected O, but got I
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_011a: Expected O, but got I
			//IL_0129: Expected O, but got I
			//IL_00b9: Expected O, but got I
			//IL_0330: Expected O, but got I
			//IL_04a5: Expected I4, but got O
			//IL_04d5: Expected O, but got I8
			//IL_04e2: Expected O, but got I8
			//IL_04ea: Expected I4, but got O
			//IL_0761: Expected O, but got I
			//IL_014e: Expected I, but got O
			//IL_06dc: Expected I, but got O
			//IL_0189: Expected O, but got I
			//IL_03c7: Expected I4, but got I8
			//IL_03d5: Expected O, but got I
			//IL_0269: Expected O, but got I
			//IL_0214: Unknown result type (might be due to invalid IL or missing references)
			//IL_0219: Expected O, but got Unknown
			//IL_0236: Expected O, but got I
			//IL_0245: Expected O, but got I
			//IL_01d5: Expected O, but got I
			//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_02f0: Expected O, but got Unknown
			//IL_030d: Expected O, but got I
			//IL_031c: Expected O, but got I
			//IL_02b5: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			m_ActiveParticleCount = m_InitialActiveParticleCount;
			IEnumerable<IObiConstraints> constraints = GetConstraints();
			IEnumerator<IObiConstraints> enumerator = constraints.GetEnumerator();
			object obj3 = 4294967295L;
			int num = 0;
			IEnumerator<IObiConstraints> enumerator2 = default(IEnumerator<IObiConstraints>);
			object obj5;
			int num2;
			IEnumerable<IObiConstraintsBatch> enumerable = default(IEnumerable<IObiConstraintsBatch>);
			int num13 = default(int);
			object obj19 = default(object);
			while (true)
			{
				object obj4;
				if (!enumerator.MoveNext())
				{
					obj4 = (long)(IntPtr)obj3 + 1L;
					_ = 102;
					bool flag = enumerator == null;
					bool flag2 = !flag;
					enumerator2 = enumerator;
					if (!flag2)
					{
						obj5 = obj4;
						num2 = num;
						break;
					}
					goto IL_07bd;
				}
				IObiConstraints current = enumerator.Current;
				IntPtr intPtr = (IntPtr)current;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ X8_v30 (Il2CppClass<Obi.IObiConstraints>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00d2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ X8_v30 (Il2CppClass<Obi.IObiConstraints>)+B0]");
				object obj6 = 0L + 8L;
				int num3 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v906 @ X11_v60-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
					{
						break;
					}
					num3++;
					int num4 = num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ X8_v30 (Il2CppClass<Obi.IObiConstraints>)+126]");
					bool flag3 = (long)num4 < 0L;
					bool flag4 = !flag3;
					obj6 = (long)(IntPtr)obj6 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_00d2;
				}
				object obj7 = obj6 + 2;
				int num5 = (int)((long)(IntPtr)obj7 << 4);
				object obj8 = (long)intPtr + (long)num5;
				object obj9 = (long)(IntPtr)obj8 + 304L;
				int num6 = 0;
				goto IL_0619;
				IL_00d2:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				num6 = 2;
				goto IL_0619;
				IL_0619:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v923 @ X0_v41] (should have been resolved before IL gen)");
				IEnumerator<IObiConstraintsBatch> enumerator3 = enumerable.GetEnumerator();
				int num7 = 0;
				int num8 = 0;
				while (true)
				{
					IObiConstraintsBatch current2;
					int num12;
					if (enumerator3 == null)
					{
						NullReferenceException ex = new NullReferenceException();
					}
					else
					{
						if (!enumerator3.MoveNext())
						{
							break;
						}
						current2 = enumerator3.Current;
						if (current2 != null)
						{
							IntPtr intPtr2 = (IntPtr)current2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ X8_v53 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_01ee;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ X8_v53 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
							object obj10 = 0L + 8L;
							int num9 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1329 @ X11_v40-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
								{
									break;
								}
								num9++;
								int num10 = num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1274 @ X8_v53 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
								bool flag5 = (long)num10 < 0L;
								bool flag6 = !flag5;
								obj10 = (long)(IntPtr)obj10 + 16L;
								if (!flag6)
								{
									continue;
								}
								goto IL_01ee;
							}
							object obj11 = obj10 + 3;
							int num11 = (int)((long)(IntPtr)obj11 << 4);
							object obj12 = (long)intPtr2 + (long)num11;
							object obj13 = (long)(IntPtr)obj12 + 304L;
							num12 = 0;
							goto IL_06ca;
						}
						NullReferenceException ex2 = new NullReferenceException();
						enumerator2 = enumerator;
					}
					if (num8 == 1)
					{
						goto IL_048e;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					return;
					IL_072b:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1428 @ X0_v70+8]");
					num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1428 @ X0_v70] (should have been resolved before IL gen)");
					num8 = num13;
					continue;
					IL_06ca:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1361 @ X0_v67] (should have been resolved before IL gen)");
					IntPtr intPtr3 = (IntPtr)current2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ X8_v56 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ X8_v56 (Il2CppClass<Obi.IObiConstraintsBatch>)+B0]");
						object obj14 = 0L + 8L;
						int num14 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1410 @ X11_v35-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiConstraintsBatch))
							{
								break;
							}
							num14++;
							int num15 = num14;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1367 @ X8_v56 (Il2CppClass<Obi.IObiConstraintsBatch>)+126]");
							bool flag7 = (long)num15 < 0L;
							bool flag8 = !flag7;
							obj14 = (long)(IntPtr)obj14 + 16L;
							if (!flag8)
							{
								continue;
							}
							goto IL_02ce;
						}
						object obj15 = obj14 + 2;
						int num16 = (int)((long)(IntPtr)obj15 << 4);
						object obj16 = (long)intPtr3 + (long)num16;
						object obj17 = (long)(IntPtr)obj16 + 304L;
						goto IL_072b;
					}
					goto IL_02ce;
					IL_01ee:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					num12 = 3;
					goto IL_06ca;
					IL_02ce:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_072b;
				}
				obj3 = (long)(IntPtr)obj3 + 1L;
				_ = 82;
				enumerator3?.Dispose();
				object obj18 = (long)(IntPtr)obj3 + 1L;
				if (obj18 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X24_v1+v706 @ X25_v10*4]");
					if ((IntPtr)0 == (IntPtr)82)
					{
						int num17 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj3);
						obj3 = (long)(IntPtr)obj3 + (long)num17;
						continue;
					}
				}
				bool flag9 = num == 0;
				num = 0;
				if (!flag9)
				{
					num = 0;
					throw new TypeLoadException();
				}
				continue;
				IL_048e:
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				num = (int)obj19;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag10 = enumerator2 == null;
				obj4 = 4294967295L;
				obj5 = 4294967295L;
				num2 = (int)obj19;
				if (flag10)
				{
					break;
				}
				goto IL_07bd;
				IL_07bd:
				enumerator2.Dispose();
				obj5 = obj4;
				num2 = num;
				break;
			}
			object obj20 = (long)(IntPtr)obj5 + 1L;
			if (obj20 != null)
			{
				if (num2 == 0)
				{
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X24_v1+v572 @ X25_v1*4]");
				if ((IntPtr)0 == (IntPtr)102)
				{
					return;
				}
			}
			else if (num2 == 0)
			{
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0xE3BAF8", Offset = "0xE3BAF8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void GenerateTethers(bool[] selected)
		{
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0xE3BAFC", Offset = "0xE3BAFC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void ClearTethers()
		{
		}

		[Token(Token = "0x60001E0")]
		protected abstract IEnumerator Initialize();

		[Token(Token = "0x60001E1")]
		[Address(RVA = "0xE3BB00", Offset = "0xE3BB00", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEE568]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246DA]) = v38;\nL_0014:\n\tthis.m_Empty = 1;\n\tv43 = new System.Collections.Generic.List`1<Obi.ObiParticleGroup>();\n\tSystem.Collections.Generic.List`1<Obi.ObiParticleGroup>::.ctor(v43);\n\tthis.groups = v43;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiActorBlueprint()
		{
			m_Empty = true;
			List<ObiParticleGroup> list = new List<ObiParticleGroup>();
			groups = list;
		}
	}
}
