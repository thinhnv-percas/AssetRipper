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
	[Token(Token = "0x200002E")]
	public class DummyMecanimControllerExample : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200002F")]
		private sealed class _003CFakeJump_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000104")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000105")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000106")]
			[FieldOffset(Offset = "0x20")]
			public DummyMecanimControllerExample _003C_003E4__this;

			[Token(Token = "0x4000107")]
			[FieldOffset(Offset = "0x28")]
			private float _003CdurationLeft_003E5__2;

			[Token(Token = "0x17000014")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000B7")]
				[Address(RVA = "0x150ED44", Offset = "0x150ED44", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000015")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000B9")]
				[Address(RVA = "0x150ED84", Offset = "0x150ED84", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B4")]
			[Address(RVA = "0x150EB20", Offset = "0x150EB20", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CFakeJump_003Ed__12(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B5")]
			[Address(RVA = "0x150EBE8", Offset = "0x150EBE8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000B6")]
			[Address(RVA = "0x150EBEC", Offset = "0x150EBEC", Length = "0x158")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = UnityEngine.WaitForSeconds;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A2A]) = v37;\nL_0012:\n\tv38 = this.<>1__state;\n\tv40 = this.<>1__state < 3;\n\tv41 = ~v40;\n\tv42 = this.<>1__state - 3;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_0079;\n\tv53 = 0x44C000 + 0xCD7;\n\tv56 = *([v53 @ X9_v2 (System.Int32)+v38 @ X8_v3 (System.Int32)]) << 2;\n\tv57 = 0x1512C4C + v56;\n\t// 40 IndirectJump v57 @ X10_v2 (System.Int32), 0, 0, methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_007A;\n\tV0 = *([X21+50]);\n\tV1 = 0.5f;\n\t*([X21+5C]) = 0;\n\tV8 = V0 * V1;\n\t*([X21+58]) = X8;\n\t*([X19+28]) = V8;\n\tgoto L_0038;\n\tV8 = *([X19+28]);\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\nL_0038:\n\tC = V8 < 0;\n\tC = ~C;\n\tTEMP1 = V8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ 0;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_005E;\n\tX0 = 0;\n\tV0 = UnityEngine.Time::get_deltaTime(X0);\n\tV0 = V8 - V0;\n\t*([X19+28]) = V0;\n\tif (TEMP) goto L_007A;\n\tX0 = *([X21+34]);\n\tX1 = 0;\n\tX0 = UnityEngine.Input::GetKey(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0060;\n\tX20 = 0;\n\tX8 = 1;\n\tgoto L_0070;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_007A;\n\tX8 = 1;\n\tX20 = 0;\n\t*([X21+5C]) = X8;\n\tX8 = 3;\n\t*([X21+58]) = 0;\n\tgoto L_0070;\nL_005E:\n\tTEMP = X21 == 0;\n\tif (TEMP) goto L_007A;\nL_0060:\n\tX8 = 0xC1200000;\n\t*([X21+58]) = X8;\n\tV0 = *([X21+50]);\n\tV1 = *([X19+28]);\n\tX8 = *([19359A0]);\n\tV2 = 0.5f;\n\tV0 = V0 * V2;\n\tV8 = V0 - V1;\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V8;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX8 = 2;\nL_0070:\n\tX0 = 1;\n\t*([X19+18]) = X20;\n\t*([X19+10]) = X8;\nL_0079:\n\treturn 0;\nL_007A:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				while (true)
				{
					int num = _003C_003E1__state;
					bool flag = _003C_003E1__state < 3;
					bool flag2 = !flag;
					int num2 = _003C_003E1__state - 3;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (flag2 && flag4)
					{
						break;
					}
					int num3 = 4505600 + 3287;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v2 (System.Int32)+v38 @ X8_v3 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 22096972 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B8")]
			[Address(RVA = "0x150ED4C", Offset = "0x150ED4C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x20")]
		public Animator logicAnimator;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x28")]
		public SkeletonAnimationHandleExample animationHandle;

		[Header("Controls")]
		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x30")]
		public KeyCode walkButton;

		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x34")]
		public KeyCode jumpButton;

		[Header("Animator Properties")]
		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x38")]
		public string horizontalSpeedProperty;

		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x40")]
		public string verticalSpeedProperty;

		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x48")]
		public string groundedProperty;

		[Header("Fake Physics")]
		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x50")]
		public float jumpDuration;

		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x54")]
		public Vector2 speed;

		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x5C")]
		public bool isGrounded;

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x150E9A8", Offset = "0x150E9A8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isGrounded = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			isGrounded = true;
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x150E9B4", Offset = "0x150E9B4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = \"Horizontal\";\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37A27]) = v39;\nL_0016:\n\tv42 = UnityEngine.Input::GetAxisRaw(\"Horizontal\");\n\tv46 = UnityEngine.Input::GetKey(this.walkButton);\n\tv51 = v46 == 0;\n\tv59 = v42 * 0.4f;\n\tv55 = ~v51;\n\tv56 = ~v55;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\tv64 = v59 == 0;\n\tthis.speed.x = v59;\n\tif (v64) goto L_003B;\n\tSpine.Unity.Examples.SkeletonAnimationHandleExample::SetFlip(this.animationHandle, v59);\nL_003B:\n\tv75 = UnityEngine.Input::GetKeyDown(this.jumpButton);\n\tv99 = v75 == 0;\n\tif (v99) goto L_004E;\n\tv101 = ~this.isGrounded;\n\tif (v101) goto L_004E;\n\tv128 = Spine.Unity.Examples.DummyMecanimControllerExample::FakeJump(this);\n\tv105 = UnityEngine.MonoBehaviour::StartCoroutine(this, v128);\nL_004E:\n\tv81 = UnityEngine.Mathf::Abs(this.speed);\n\tUnityEngine.Animator::SetFloat(this.logicAnimator, this.horizontalSpeedProperty, v81);\n\tUnityEngine.Animator::SetFloat(this.logicAnimator, this.verticalSpeedProperty, this.speed.y);\n\tUnityEngine.Animator::SetBool(this.logicAnimator, this.groundedProperty, this.isGrounded);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			float axisRaw = Input.GetAxisRaw("Horizontal");
			bool key = Input.GetKey(walkButton);
			bool flag = !key;
			float num = axisRaw * 0.4f;
			if (flag)
			{
				num = axisRaw;
			}
			bool flag2 = num == 0f;
			speed.x = num;
			if (!flag2)
			{
				animationHandle.SetFlip(num);
			}
			if (Input.GetKeyDown(jumpButton) && isGrounded)
			{
				IEnumerator routine = FakeJump();
				Coroutine coroutine = StartCoroutine(routine);
			}
			float value = Mathf.Abs(speed.x);
			logicAnimator.SetFloat(horizontalSpeedProperty, value);
			logicAnimator.SetFloat(verticalSpeedProperty, speed.y);
			logicAnimator.SetBool(groundedProperty, isGrounded);
		}

		[IteratorStateMachine(typeof(_003CFakeJump_003Ed__12))]
		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x150EAC0", Offset = "0x150EAC0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.DummyMecanimControllerExample+<FakeJump>d__12;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A28]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.DummyMecanimControllerExample+<FakeJump>d__12();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator FakeJump()
		{
			_003CFakeJump_003Ed__12 _003CFakeJump_003Ed__13 = null;
			_003CFakeJump_003Ed__13._003C_003E1__state = 0;
			_003CFakeJump_003Ed__13._003C_003E4__this = this;
			return _003CFakeJump_003Ed__13;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x150EB48", Offset = "0x150EB48", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = \"Speed\";\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv62 = \"VerticalSpeed\";\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv65 = \"Grounded\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A29]) = v46;\nL_0023:\n\tthis.walkButton = 6.7903865461E-313d;\n\tthis.horizontalSpeedProperty = \"Speed\";\n\tthis.verticalSpeedProperty = \"VerticalSpeed\";\n\tthis.jumpDuration = 1.5f;\n\tthis.groundedProperty = \"Grounded\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DummyMecanimControllerExample()
		{
			//IL_001a: Expected I4, but got F8
			base._002Ector();
			walkButton = KeyCode.None;
			horizontalSpeedProperty = "Speed";
			verticalSpeedProperty = "VerticalSpeed";
			jumpDuration = 1.5f;
			groundedProperty = "Grounded";
		}
	}
}
