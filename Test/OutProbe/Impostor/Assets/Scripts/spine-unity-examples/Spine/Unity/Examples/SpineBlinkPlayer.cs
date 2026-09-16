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
	[Token(Token = "0x200001F")]
	public class SpineBlinkPlayer : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000020")]
		private sealed class _003CStart_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000AB")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000AC")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000AD")]
			[FieldOffset(Offset = "0x20")]
			public SpineBlinkPlayer _003C_003E4__this;

			[Token(Token = "0x40000AE")]
			[FieldOffset(Offset = "0x28")]
			private SkeletonAnimation _003CskeletonAnimation_003E5__2;

			[Token(Token = "0x17000010")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000072")]
				[Address(RVA = "0x150C84C", Offset = "0x150C84C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000011")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000074")]
				[Address(RVA = "0x150C88C", Offset = "0x150C88C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600006F")]
			[Address(RVA = "0x150C6B8", Offset = "0x150C6B8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000070")]
			[Address(RVA = "0x150C6F4", Offset = "0x150C6F4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000071")]
			[Address(RVA = "0x150C6F8", Offset = "0x150C6F8", Length = "0x154")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv53 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv59 = UnityEngine.WaitForSeconds;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A06]) = v40;\nL_001A:\n\tv42 = this.<>4__this;\n\tv47 = this.<>1__state == 1;\n\tif (v47) goto L_0045;\n\tv55 = this.<>1__state == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv87 = UnityEngine.Component::GetComponent(v42);\n\tthis.<skeletonAnimation>5__2 = v87;\n\tgoto L_003E;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v134, v86, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003E:\n\tv69 = UnityEngine.Object::op_Equality(v87, 0);\n\tv71 = v69 == 0;\n\tif (v71) goto L_0046;\n\tgoto L_006F;\nL_0045:\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0046:\n\tv81 = this.<skeletonAnimation>5__2;\n\tv95 = Spine.Unity.AnimationReferenceAsset::op_Implicit(*([v42 @ X20_v2 (UnityEngine.Component)+20]));\n\tv159 = Spine.AnimationState::SetAnimation(v81.state, 1, v95, 0);\n\tv162 = UnityEngine.Random::Range(*([v42 @ X20_v2 (UnityEngine.Component)+28]), *([v42 @ X20_v2 (UnityEngine.Component)+2C]));\n\tv119 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v119, v162);\n\tthis.<>2__current = v119;\n\tthis.<>1__state = 1;\nL_006F:\n\treturn v114;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_00b5: Expected O, but got I
				//IL_00fb: Expected F4, but got I
				//IL_00fb: Expected F4, but got I
				Component component = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						if (!((_003CskeletonAnimation_003E5__2 = component.GetComponent<SkeletonAnimation>()) == null))
						{
							goto IL_0163;
						}
					}
					return false;
				}
				_003C_003E1__state = -1;
				goto IL_0163;
				IL_0163:
				SkeletonAnimation skeletonAnimation = _003CskeletonAnimation_003E5__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X20_v2 (UnityEngine.Component)+20]");
				Animation animation = (AnimationReferenceAsset)0;
				TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(1, animation, loop: false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X20_v2 (UnityEngine.Component)+28]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X20_v2 (UnityEngine.Component)+2C]");
				float seconds = UnityEngine.Random.Range(num, 0f);
				WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = 1;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x150C854", Offset = "0x150C854", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40000A7")]
		private const int BlinkTrack = 1;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x20")]
		public AnimationReferenceAsset blinkAnimation;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x28")]
		public float minimumDelay;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x2C")]
		public float maximumDelay;

		[IteratorStateMachine(typeof(_003CStart_003Ed__4))]
		[Token(Token = "0x600006D")]
		[Address(RVA = "0x150C658", Offset = "0x150C658", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpineBlinkPlayer+<Start>d__4;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A05]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpineBlinkPlayer+<Start>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__4 _003CStart_003Ed__5 = null;
			_003CStart_003Ed__5._003C_003E1__state = 0;
			_003CStart_003Ed__5._003C_003E4__this = this;
			return _003CStart_003Ed__5;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x150C6E0", Offset = "0x150C6E0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.minimumDelay = 32.000007402896884d;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineBlinkPlayer()
		{
			minimumDelay = 0.15f;
			maximumDelay = 3f;
		}
	}
}
