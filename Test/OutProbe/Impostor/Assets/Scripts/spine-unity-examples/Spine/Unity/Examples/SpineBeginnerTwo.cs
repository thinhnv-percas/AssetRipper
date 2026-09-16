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
	[Token(Token = "0x200001D")]
	public class SpineBeginnerTwo : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200001E")]
		private sealed class _003CDoDemoRoutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000A4")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000A5")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000A6")]
			[FieldOffset(Offset = "0x20")]
			public SpineBeginnerTwo _003C_003E4__this;

			[Token(Token = "0x1700000E")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600006A")]
				[Address(RVA = "0x150C610", Offset = "0x150C610", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000F")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600006C")]
				[Address(RVA = "0x150C650", Offset = "0x150C650", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000067")]
			[Address(RVA = "0x150C3B8", Offset = "0x150C3B8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CDoDemoRoutine_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000068")]
			[Address(RVA = "0x150C3F0", Offset = "0x150C3F0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000069")]
			[Address(RVA = "0x150C3F4", Offset = "0x150C3F4", Length = "0x21C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = UnityEngine.WaitForSeconds;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A04]) = v37;\nL_0012:\n\tv38 = v35.<>1__state;\n\tv39 = v35.<>1__state < 5;\n\tv40 = ~v39;\n\tv41 = v35.<>1__state - 5;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_0037;\n\tv52 = 0x44C000 + 0xCD1;\n\tv55 = *([v52 @ X9_v2 (System.Int32)+v38 @ X8_v3 (System.Int32)]) << 2;\n\tv56 = 0x151044C + v55;\n\t// 38 IndirectJump v56 @ X10_v2 (System.Int32), v35 @ X0_v1 (Spine.Unity.Examples.SpineBeginnerTwo+<DoDemoRoutine>d__11), v35 @ X0_v1 (Spine.Unity.Examples.SpineBeginnerTwo+<DoDemoRoutine>d__11), methodInfo @ X1 (Il2CppMethodInfo), v21 @ X2, v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00A9;\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+30]);\n\tX3 = 1;\n\tX1 = 0;\n\tX4 = 0;\n\tX21 = 1;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tV8 = *([X20+50]);\n\tgoto L_0097;\nL_0037:\n\tgoto L_00A8;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00A9;\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+20]);\n\tX3 = 1;\n\tX1 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tV8 = *([X20+50]);\n\tX21 = 2;\n\tgoto L_0097;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00A9;\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+48]);\n\tX1 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+28]);\n\tV0 = 0;\n\tX3 = 1;\n\tX1 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::AddAnimation(X0, X1, X2, X3, V0, X4);\n\tX21 = 3;\n\tV8 = 1f;\n\tgoto L_0097;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00A9;\n\tX8 = *([X20+68]);\n\tif (TEMP) goto L_00A9;\n\t*([X8+74]) = X9;\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+40]);\n\tX1 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+28]);\n\tV0 = 0;\n\tX3 = 1;\n\tX1 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::AddAnimation(X0, X1, X2, X3, V0, X4);\n\tX21 = 4;\n\tgoto L_0096;\n\tX8 = 0xFFFFFFFF;\n\t*([X19+10]) = X8;\n\tif (TEMP) goto L_00A9;\n\tX8 = *([X20+68]);\n\tif (TEMP) goto L_00A9;\n\t*([X8+74]) = X9;\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+40]);\n\tX1 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::SetAnimation(X0, X1, X2, X3, X4);\n\tX0 = *([X20+60]);\n\tif (TEMP) goto L_00A9;\n\tX2 = *([X20+28]);\n\tV0 = 0;\n\tX3 = 1;\n\tX1 = 0;\n\tX4 = 0;\n\tX0 = Spine.AnimationState::AddAnimation(X0, X1, X2, X3, V0, X4);\n\tX21 = 5;\nL_0096:\n\tV8 = 0.5f;\nL_0097:\n\tX8 = 0x1935000;\n\tX8 = *([19359A0]);\n\tX0 = *([X8]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V8;\n\tX1 = 0;\n\tX20 = X0;\n\tUnityEngine.WaitForSeconds::.ctor(X0, V0, X1);\n\tX0 = 1;\n\t*([X19+18]) = X20;\n\t*([X19+10]) = X21;\nL_00A8:\n\treturn 0;\nL_00A9:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state;
				bool flag = _003C_003E1__state < 5;
				bool flag2 = !flag;
				int num2 = _003C_003E1__state - 5;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 4505600 + 3281;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v38 @ X8_v3 (System.Int32)]");
					int num4 = (int)((nint)0 << 2);
					int num5 = 22086732 + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x150C618", Offset = "0x150C618", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x20")]
		public string runAnimationName;

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x28")]
		public string idleAnimationName;

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x30")]
		public string walkAnimationName;

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x38")]
		public string shootAnimationName;

		[SpineAnimation(null, null, true, false)]
		[Header("Transitions")]
		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x40")]
		public string idleTurnAnimationName;

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x48")]
		public string runToIdleAnimationName;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x50")]
		public float runWalkDuration;

		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x58")]
		private SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x60")]
		public AnimationState spineAnimationState;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x68")]
		public Skeleton skeleton;

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x150C2D8", Offset = "0x150C2D8", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A02]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v40;\n\tthis.spineAnimationState = v40.state;\n\tv44 = Spine.Unity.SkeletonRenderer::get_Skeleton(v40);\n\tthis.skeleton = v44;\n\tv47 = Spine.Unity.Examples.SpineBeginnerTwo::DoDemoRoutine(this);\n\tv55 = UnityEngine.MonoBehaviour::StartCoroutine(this, v47);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			SkeletonAnimation skeletonAnimation = (this.skeletonAnimation = GetComponent<SkeletonAnimation>());
			spineAnimationState = skeletonAnimation.state;
			Skeleton skeleton = skeletonAnimation.Skeleton;
			this.skeleton = skeleton;
			IEnumerator routine = DoDemoRoutine();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[IteratorStateMachine(typeof(_003CDoDemoRoutine_003Ed__11))]
		[Token(Token = "0x6000065")]
		[Address(RVA = "0x150C358", Offset = "0x150C358", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpineBeginnerTwo+<DoDemoRoutine>d__11;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A03]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpineBeginnerTwo+<DoDemoRoutine>d__11();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator DoDemoRoutine()
		{
			_003CDoDemoRoutine_003Ed__11 _003CDoDemoRoutine_003Ed__12 = null;
			_003CDoDemoRoutine_003Ed__12._003C_003E1__state = 0;
			_003CDoDemoRoutine_003Ed__12._003C_003E4__this = this;
			return _003CDoDemoRoutine_003Ed__12;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x150C3E0", Offset = "0x150C3E0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.runWalkDuration = 1.5f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineBeginnerTwo()
		{
			runWalkDuration = 1.5f;
		}
	}
}
