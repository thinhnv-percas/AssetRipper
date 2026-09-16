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
	[Token(Token = "0x200001B")]
	public class Raptor : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200001C")]
		private sealed class _003CGunGrabRoutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000097")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000098")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000099")]
			[FieldOffset(Offset = "0x20")]
			public Raptor _003C_003E4__this;

			[Token(Token = "0x1700000C")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000061")]
				[Address(RVA = "0x150C290", Offset = "0x150C290", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000D")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000063")]
				[Address(RVA = "0x150C2D0", Offset = "0x150C2D0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600005E")]
			[Address(RVA = "0x150C0E8", Offset = "0x150C0E8", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGunGrabRoutine_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x150C118", Offset = "0x150C118", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000060")]
			[Address(RVA = "0x150C11C", Offset = "0x150C11C", Length = "0x174")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = UnityEngine.WaitForSeconds;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A01]) = v37;\nL_0013:\n\tv39 = this.<>4__this;\n\tv44 = this.<>1__state == 2;\n\tif (v44) goto L_003F;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_0054;\n\tv60 = this.<>1__state == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv72 = v39.skeletonAnimation;\n\tv83 = Spine.Unity.AnimationReferenceAsset::op_Implicit(v39.walk);\n\tgoto L_0051;\nL_003F:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv64 = v39.skeletonAnimation;\n\tv84 = Spine.Unity.AnimationReferenceAsset::op_Implicit(v39.gunkeep);\nL_0051:\n\tv202 = Spine.AnimationState::SetAnimation(v197, v186, v184, v182);\n\tgoto L_006C;\nL_0054:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv73 = v39.skeletonAnimation;\n\tv85 = Spine.Unity.AnimationReferenceAsset::op_Implicit(v39.gungrab);\n\tv179 = Spine.AnimationState::SetAnimation(v73.state, 1, v85, 0);\nL_006C:\n\tv211 = UnityEngine.Random::Range(0.5f, 3f);\n\tv213 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v213, v211);\n\tthis.<>2__current = v213;\n\tthis.<>1__state = v109;\n\tgoto L_007F;\nL_007F:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				Raptor raptor = _003C_003E4__this;
				int num;
				bool loop;
				Animation animation3;
				int trackIndex;
				AnimationState state;
				if (_003C_003E1__state != 2)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						SkeletonAnimation skeletonAnimation = raptor.skeletonAnimation;
						Animation animation = raptor.gungrab;
						TrackEntry trackEntry = skeletonAnimation.state.SetAnimation(1, animation, loop: false);
						num = 2;
						goto IL_0208;
					}
					if (_003C_003E1__state != 0)
					{
						return false;
					}
					_003C_003E1__state = -1;
					SkeletonAnimation skeletonAnimation2 = raptor.skeletonAnimation;
					Animation animation2 = raptor.walk;
					num = 1;
					loop = true;
					animation3 = animation2;
					trackIndex = 0;
					state = skeletonAnimation2.state;
				}
				else
				{
					_003C_003E1__state = -1;
					SkeletonAnimation skeletonAnimation3 = raptor.skeletonAnimation;
					Animation animation4 = raptor.gunkeep;
					num = 1;
					loop = false;
					animation3 = animation4;
					trackIndex = 1;
					state = skeletonAnimation3.state;
				}
				TrackEntry trackEntry2 = state.SetAnimation(trackIndex, animation3, loop);
				goto IL_0208;
				IL_0208:
				float seconds = UnityEngine.Random.Range(0.5f, 3f);
				WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);
				_003C_003E2__current = waitForSeconds;
				_003C_003E1__state = num;
				return true;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000062")]
			[Address(RVA = "0x150C298", Offset = "0x150C298", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x20")]
		public AnimationReferenceAsset walk;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x28")]
		public AnimationReferenceAsset gungrab;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x30")]
		public AnimationReferenceAsset gunkeep;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x38")]
		private SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x150C024", Offset = "0x150C024", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379FF]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v40;\n\tv42 = Spine.Unity.Examples.Raptor::GunGrabRoutine(this);\n\tv50 = UnityEngine.MonoBehaviour::StartCoroutine(this, v42);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			SkeletonAnimation component = GetComponent<SkeletonAnimation>();
			skeletonAnimation = component;
			IEnumerator routine = GunGrabRoutine();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[IteratorStateMachine(typeof(_003CGunGrabRoutine_003Ed__5))]
		[Token(Token = "0x600005C")]
		[Address(RVA = "0x150C088", Offset = "0x150C088", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.Raptor+<GunGrabRoutine>d__5;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A00]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.Raptor+<GunGrabRoutine>d__5();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator GunGrabRoutine()
		{
			_003CGunGrabRoutine_003Ed__5 _003CGunGrabRoutine_003Ed__6 = null;
			_003CGunGrabRoutine_003Ed__6._003C_003E1__state = 0;
			_003CGunGrabRoutine_003Ed__6._003C_003E4__this = this;
			return _003CGunGrabRoutine_003Ed__6;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x150C110", Offset = "0x150C110", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Raptor()
		{
		}
	}
}
