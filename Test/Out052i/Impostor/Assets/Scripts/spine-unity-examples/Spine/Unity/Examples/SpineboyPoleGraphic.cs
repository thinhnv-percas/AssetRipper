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
	[Token(Token = "0x2000076")]
	public class SpineboyPoleGraphic : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000077")]
		private sealed class _003CStart_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40002AC")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40002AD")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40002AE")]
			[FieldOffset(Offset = "0x20")]
			public SpineboyPoleGraphic _003C_003E4__this;

			[Token(Token = "0x40002AF")]
			[FieldOffset(Offset = "0x28")]
			private AnimationState _003Cstate_003E5__2;

			[Token(Token = "0x17000043")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600020E")]
				[Address(RVA = "0x1520BA8", Offset = "0x1520BA8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000044")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000210")]
				[Address(RVA = "0x1520BE8", Offset = "0x1520BE8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600020B")]
			[Address(RVA = "0x15208A0", Offset = "0x15208A0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600020C")]
			[Address(RVA = "0x1520934", Offset = "0x1520934", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600020D")]
			[Address(RVA = "0x1520938", Offset = "0x1520938", Length = "0x270")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = UnityEngine.WaitForSeconds;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv54 = Spine.Unity.WaitForSpineAnimationComplete;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37AC2]) = v40;\nL_0016:\n\tv41 = v37.<>1__state;\n\tv42 = v37.<>1__state < 3;\n\tv43 = ~v42;\n\tv44 = v37.<>1__state - 3;\n\tv46 = v44 == 0;\n\tv51 = ~v46;\n\tv52 = v43 & v51;\n\tif (v52) goto L_0036;\n\tv57 = 0x44C000 + 0xCE4;\n\tv60 = *([v57 @ X9_v2 (System.Int32)+v41 @ X8_v3 (System.Int32)]) << 2;\n\tv61 = 0x152499C + v60;\n\t// 42 IndirectJump v61 @ X10_v2 (System.Int32), v37 @ X0_v1 (Spine.Unity.Examples.SpineboyPoleGraphic+<Start>d__7), v37 @ X0_v1 (Spine.Unity.Examples.SpineboyPoleGraphic+<Start>d__7), methodInfo @ X1 (Il2CppMethodInfo), v23 @ X2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00CB;\n\tX8 = *([X20+20]);\n\tif (TEMP) goto L_00CB;\n\tX8 = *([X8+178]);\n\t*([X19+28]) = X8;\n\tgoto L_004D;\nL_0036:\n\tgoto L_00CA;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0065;\n\tgoto L_00CB;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tX8 = *([19359A0]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = 1f;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX8 = 3;\n\tgoto L_00C0;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00CB;\nL_004D:\n\tV0 = *([X20+38]);\n\tX0 = X20;\n\tSpine.Unity.Examples.SpineboyPoleGraphic::SetXPosition(X0, V0, X1);\n\tX8 = *([X20+20]);\n\tif (TEMP) goto L_00CB;\n\t*([X8+128]) = 0;\n\tX0 = *([X20+28]);\n\tX21 = *([X19+28]);\n\tX1 = 0;\n\tX0 = Spine.Unity.AnimationReferenceAsset::op_Implicit(X0, X1);\n\tif (TEMP) goto L_00CB;\n\tX2 = X0;\n\tX3 = 1;\n\tX0 = X21;\n\tX1 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_00CB;\n\t*([X8+6C]) = X9;\nL_0065:\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_transform(X0, X1);\n\tif (TEMP) goto L_00CB;\n\tX1 = 0;\n\tV0 = UnityEngine.Transform::get_localPosition(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV1 = *([X20+3C]);\n\tC = V0 < V1;\n\tC = ~C;\n\tTEMP1 = V0 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V1;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_00A0;\n\tX0 = X20;\n\tX1 = 0;\n\tX0 = UnityEngine.Component::get_transform(X0, X1);\n\tX8 = *([1A37AC6]);\n\tX20 = X0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0088;\n\tX0 = *([1935418]);\n\tX0 = 0xAD9498(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 1;\n\t*([1A37AC6]) = X8;\nL_0088:\n\tX8 = 0x1935000;\n\tX8 = *([1935418]);\n\tX0 = 0;\n\tX8 = *([X8]);\n\tX8 = *([X8+B8]);\n\tV8 = *([X8+3C]);\n\tV9 = *([X8+44]);\n\tV0 = UnityEngine.Time::get_deltaTime(X0);\n\tif (TEMP) goto L_00CB;\n\tV1 = 18f;\n\tV2 = 0;\n\tV1 = V9 * V1;\n\tV3 = V8 * V2;\n\tV2 = V1 * V0;\n\tV0 = V3 * V0.S0;\n\tV1 = V0.S1;\n\tX0 = X20;\n\tX1 = 0;\n\t// 155 MakeStruct AGG1524B00_1, typeof(UnityEngine.Vector3), V0, V1, V2\n\tUnityEngine.Transform::Translate(X0, AGG1524B00_1, X1);\n\tX20 = 0;\n\tX8 = 1;\n\tgoto L_00C0;\nL_00A0:\n\tX0 = X20;\n\tV0 = V1;\n\tSpine.Unity.Examples.SpineboyPoleGraphic::SetXPosition(X0, V0, X1);\n\tX8 = *([X20+20]);\n\tif (TEMP) goto L_00CB;\n\tX9 = 1;\n\t*([X8+128]) = X9;\n\tX0 = *([X20+30]);\n\tX21 = *([X19+28]);\n\tX1 = 0;\n\tX0 = Spine.Unity.AnimationReferenceAsset::op_Implicit(X0, X1);\n\tif (TEMP) goto L_00CB;\n\tX2 = X0;\n\tX0 = X21;\n\tX1 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tX8 = *([1946630]);\n\tX21 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X21;\n\tX2 = 0;\n\tX3 = 0;\n\tX20 = X0;\n\tSpine.Unity.WaitForSpineAnimationComplete::.ctor(X0, X1, X2, X3);\n\tX8 = 2;\nL_00C0:\n\tX0 = 1;\n\t*([X19+18]) = X20;\n\t*([X19+10]) = X8;\nL_00CA:\n\treturn 0;\nL_00CB:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 3;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 4505600 + 3300;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X9_v2 (System.Int32)+v41 @ X8_v3 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 22170012 + num4;
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
			[Token(Token = "0x600020F")]
			[Address(RVA = "0x1520BB0", Offset = "0x1520BB0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40002A5")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonGraphic skeletonGraphic;

		[Space(18f)]
		[Token(Token = "0x40002A6")]
		[FieldOffset(Offset = "0x28")]
		public AnimationReferenceAsset run;

		[Token(Token = "0x40002A7")]
		[FieldOffset(Offset = "0x30")]
		public AnimationReferenceAsset pole;

		[Token(Token = "0x40002A8")]
		[FieldOffset(Offset = "0x38")]
		public float startX;

		[Token(Token = "0x40002A9")]
		[FieldOffset(Offset = "0x3C")]
		public float endX;

		[Token(Token = "0x40002AA")]
		private const float Speed = 18f;

		[Token(Token = "0x40002AB")]
		private const float RunTimeScale = 1.5f;

		[IteratorStateMachine(typeof(_003CStart_003Ed__7))]
		[Token(Token = "0x6000208")]
		[Address(RVA = "0x1520840", Offset = "0x1520840", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpineboyPoleGraphic+<Start>d__7;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AC1]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpineboyPoleGraphic+<Start>d__7();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__7 _003CStart_003Ed__8 = null;
			_003CStart_003Ed__8._003C_003E1__state = 0;
			_003CStart_003Ed__8._003C_003E4__this = this;
			return _003CStart_003Ed__8;
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x15208C8", Offset = "0x15208C8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_transform(this);\n\tv18 = UnityEngine.Transform::get_localPosition(v15);\n\tv33 = UnityEngine.Component::get_transform(this);\n\t// 33 MakeStruct v50 @ AGG1524924_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), x @ V0 (System.Single), v18.y (System.Single), v18.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v33, v50);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetXPosition(float x)
		{
			Transform transform = base.transform;
			Vector3 localPosition = transform.localPosition;
			Transform transform2 = base.transform;
			Vector3 localPosition2 = default(Vector3);
			localPosition2.x = x;
			localPosition2.y = localPosition.y;
			localPosition2.z = localPosition.z;
			transform2.localPosition = localPosition2;
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x152092C", Offset = "0x152092C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyPoleGraphic()
		{
		}
	}
}
