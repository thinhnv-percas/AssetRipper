using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000072")]
	public class SpineboyFreeze : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000073")]
		private sealed class _003CStart_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000295")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000296")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000297")]
			[FieldOffset(Offset = "0x20")]
			public SpineboyFreeze _003C_003E4__this;

			[Token(Token = "0x4000298")]
			[FieldOffset(Offset = "0x28")]
			private AnimationState _003Cstate_003E5__2;

			[Token(Token = "0x1700003F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001FC")]
				[Address(RVA = "0x152043C", Offset = "0x152043C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000040")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001FE")]
				[Address(RVA = "0x152047C", Offset = "0x152047C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0x152009C", Offset = "0x152009C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001FA")]
			[Address(RVA = "0x152013C", Offset = "0x152013C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001FB")]
			[Address(RVA = "0x1520140", Offset = "0x1520140", Length = "0x2FC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = UnityEngine.MaterialPropertyBlock;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv64 = UnityEngine.WaitForSeconds;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37ABE]) = v38;\nL_0019:\n\tv40 = v35.<>1__state;\n\tv41 = v35.<>1__state < 4;\n\tv42 = ~v41;\n\tv43 = v35.<>1__state - 4;\n\tv45 = v43 == 0;\n\tv50 = ~v45;\n\tv51 = v42 & v50;\n\tif (v51) goto L_005C;\n\tv57 = 0x44C000 + 0xCDF;\n\tv60 = *([v57 @ X9_v2 (System.Int32)+v40 @ X8_v3 (System.Int32)]) << 2;\n\tv61 = 0x15241B4 + v60;\n\t// 45 IndirectJump v61 @ X10_v2 (System.Int32), v35 @ X0_v1 (Spine.Unity.Examples.SpineboyFreeze+<Start>d__11), v35 @ X0_v1 (Spine.Unity.Examples.SpineboyFreeze+<Start>d__11), methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tX8 = *([1945948]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX21 = X0;\n\tUnityEngine.MaterialPropertyBlock::.ctor(X0, X1);\n\tif (TEMP) goto L_00EB;\n\t*([X20+78]) = X21;\n\tX8 = *([1945940]);\n\tX0 = X20;\n\tX1 = *([X8]);\n\tX0 = UnityEngine.Component::GetComponent /* +1 sharing this address */(X0, X1);\n\tX8 = *([X20+58]);\n\t*([X20+80]) = X0;\n\tif (TEMP) goto L_00EB;\n\tX0 = X8;\n\tX1 = 0;\n\tUnityEngine.ParticleSystem::Stop(X0, X1);\n\tX0 = *([X20+58]);\n\tif (TEMP) goto L_00EB;\n\tX1 = 0;\n\tUnityEngine.ParticleSystem::Clear(X0, X1);\n\tX0 = *([X20+58]);\n\tif (TEMP) goto L_00EB;\n\tX1 = 0;\n\tX0 = UnityEngine.ParticleSystem::get_main(X0, X1);\n\tstack[8] = X0;\n\tX0 = &stack[8];\n\tX1 = 0;\n\tX2 = 0;\n\tUnityEngine.ParticleSystem+MainModule::set_loop(X0, X1, X2);\n\tX8 = *([X20+20]);\n\tif (TEMP) goto L_00EB;\n\tX8 = *([X8+E8]);\n\t*([X19+28]) = X8;\n\tgoto L_00D8;\nL_005C:\n\tgoto L_00EA;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00EB;\n\tX0 = *([X20+28]);\n\tX21 = *([X19+28]);\n\tX1 = 0;\n\tX0 = Spine.Unity.AnimationReferenceAsset::op_Implicit(X0, X1);\n\tif (TEMP) goto L_00EB;\n\tX2 = X0;\n\tX0 = X21;\n\tX1 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tV8 = *([X20+60]);\n\tX8 = *([19359A0]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V8;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX8 = 2;\n\tgoto L_00E1;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00EB;\n\tX0 = *([X20+58]);\n\tif (TEMP) goto L_00EB;\n\tX1 = 0;\n\tUnityEngine.ParticleSystem::Play(X0, X1);\n\tX0 = *([X20+78]);\n\tif (TEMP) goto L_00EB;\n\tV2 = *([X20+40]);\n\tV3 = *([X20+44]);\n\tV0 = *([X20+38]);\n\tV1 = *([X20+3C]);\n\tX1 = *([X20+68]);\n\tX2 = 0;\n\t// 138 MakeStruct AGG15242F4_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tUnityEngine.MaterialPropertyBlock::SetColor(X0, X1, AGG15242F4_2, X2);\n\tX0 = *([X20+78]);\n\tif (TEMP) goto L_00EB;\n\tV2 = *([X20+50]);\n\tV3 = *([X20+54]);\n\tV0 = *([X20+48]);\n\tV1 = *([X20+4C]);\n\tX1 = *([X20+70]);\n\tX2 = 0;\n\t// 149 MakeStruct AGG1524310_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tUnityEngine.MaterialPropertyBlock::SetColor(X0, X1, AGG1524310_2, X2);\n\tX0 = *([X20+80]);\n\tif (TEMP) goto L_00EB;\n\tX1 = *([X20+78]);\n\tX2 = 0;\n\tUnityEngine.Renderer::SetPropertyBlock(X0, X1, X2);\n\tX8 = *([19359A0]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = 2f;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX8 = 3;\n\tgoto L_00E1;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00EB;\n\tX0 = *([X20+30]);\n\tX21 = *([X19+28]);\n\tX1 = 0;\n\tX0 = Spine.Unity.AnimationReferenceAsset::op_Implicit(X0, X1);\n\tif (TEMP) goto L_00EB;\n\tX2 = X0;\n\tX3 = 1;\n\tX0 = X21;\n\tX1 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tX0 = *([X20+78]);\n\tif (TEMP) goto L_00EB;\n\tX1 = *([X20+68]);\n\tV0 = 1f;\n\tV1 = 1f;\n\tV2 = 1f;\n\tV3 = 1f;\n\tX2 = 0;\n\t// 192 MakeStruct AGG15243A8_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tUnityEngine.MaterialPropertyBlock::SetColor(X0, X1, AGG15243A8_2, X2);\n\tX0 = *([X20+78]);\n\tif (TEMP) goto L_00EB;\n\tX1 = *([X20+70]);\n\tV0 = 0;\n\tV1 = 0;\n\tV2 = 0;\n\tV3 = 1f;\n\tX2 = 0;\n\t// 203 MakeStruct AGG15243CC_2, typeof(UnityEngine.Color), V0, V1, V2, V3\n\tUnityEngine.MaterialPropertyBlock::SetColor(X0, X1, AGG15243CC_2, X2);\n\tX0 = *([X20+80]);\n\tif (TEMP) goto L_00EB;\n\tX1 = *([X20+78]);\n\tX2 = 0;\n\tUnityEngine.Renderer::SetPropertyBlock(X0, X1, X2);\n\tX20 = 0;\n\tX8 = 4;\n\tgoto L_00E1;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\nL_00D8:\n\tX8 = 0x1935000;\n\tX8 = *([19359A0]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = 1f;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX8 = 1;\nL_00E1:\n\tX0 = 1;\n\t*([X19+18]) = X20;\n\t*([X19+10]) = X8;\nL_00EA:\n\treturn 0;\nL_00EB:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 4;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 4;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 4505600 + 3295;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X9_v2 (System.Int32)+v40 @ X8_v3 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 22167988 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v61 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001FD")]
			[Address(RVA = "0x1520444", Offset = "0x1520444", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400028A")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x400028B")]
		[FieldOffset(Offset = "0x28")]
		public AnimationReferenceAsset freeze;

		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x30")]
		public AnimationReferenceAsset idle;

		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0x38")]
		public Color freezeColor;

		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x48")]
		public Color freezeBlackColor;

		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x58")]
		public ParticleSystem particles;

		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x60")]
		public float freezePoint;

		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x68")]
		public string colorProperty;

		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x70")]
		public string blackTintProperty;

		[Token(Token = "0x4000293")]
		[FieldOffset(Offset = "0x78")]
		private MaterialPropertyBlock block;

		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x80")]
		private MeshRenderer meshRenderer;

		[IteratorStateMachine(typeof(_003CStart_003Ed__11))]
		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x152003C", Offset = "0x152003C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpineboyFreeze+<Start>d__11;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37ABC]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpineboyFreeze+<Start>d__11();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__11 _003CStart_003Ed__12 = null;
			_003CStart_003Ed__12._003C_003E1__state = 0;
			_003CStart_003Ed__12._003C_003E4__this = this;
			return _003CStart_003Ed__12;
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x15200C4", Offset = "0x15200C4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = \"_Color\";\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = \"_Black\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37ABD]) = v42;\nL_001A:\n\tthis.freezePoint = 0.5f;\n\tthis.colorProperty = \"_Color\";\n\tthis.blackTintProperty = \"_Black\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyFreeze()
		{
			freezePoint = 0.5f;
			colorProperty = "_Color";
			blackTintProperty = "_Black";
		}
	}
}
