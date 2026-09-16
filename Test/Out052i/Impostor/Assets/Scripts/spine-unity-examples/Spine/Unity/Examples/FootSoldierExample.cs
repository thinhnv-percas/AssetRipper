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
	[Token(Token = "0x2000016")]
	public class FootSoldierExample : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000017")]
		private sealed class _003CBlink_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400006B")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400006C")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400006D")]
			[FieldOffset(Offset = "0x20")]
			public FootSoldierExample _003C_003E4__this;

			[Token(Token = "0x1700000A")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600004D")]
				[Address(RVA = "0x150B47C", Offset = "0x150B47C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000B")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600004F")]
				[Address(RVA = "0x150B4BC", Offset = "0x150B4BC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600004A")]
			[Address(RVA = "0x150B304", Offset = "0x150B304", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CBlink_003Ed__15(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600004B")]
			[Address(RVA = "0x150B358", Offset = "0x150B358", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600004C")]
			[Address(RVA = "0x150B35C", Offset = "0x150B35C", Length = "0x120")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = UnityEngine.WaitForSeconds;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379F5]) = v37;\nL_0013:\n\tv39 = this.<>4__this;\n\tv44 = this.<>1__state == 2;\n\tif (v44) goto L_002F;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_0045;\n\tv60 = this.<>1__state == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_0040;\nL_002F:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv78 = Spine.Unity.SkeletonRenderer::get_Skeleton(v39.skeletonAnimation);\n\tSpine.Skeleton::SetAttachment(v78, v39.eyesSlot, v39.eyesOpenAttachment);\nL_0040:\n\tv109 = UnityEngine.Random::Range(0.25f, 3f);\n\tgoto L_0058;\nL_0045:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv80 = Spine.Unity.SkeletonRenderer::get_Skeleton(v39.skeletonAnimation);\n\tSpine.Skeleton::SetAttachment(v80, v39.eyesSlot, v39.blinkAttachment);\n\tv113 = v39.blinkDuration;\nL_0058:\n\tv187 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v187, v113);\n\tthis.<>2__current = v187;\n\tthis.<>1__state = v111;\n\tgoto L_0068;\nL_0068:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				FootSoldierExample footSoldierExample = _003C_003E4__this;
				float seconds;
				int num;
				if (_003C_003E1__state != 2)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						Skeleton skeleton = footSoldierExample.skeletonAnimation.Skeleton;
						skeleton.SetAttachment(footSoldierExample.eyesSlot, footSoldierExample.blinkAttachment);
						seconds = footSoldierExample.blinkDuration;
						num = 2;
						goto IL_0162;
					}
					if (_003C_003E1__state != 0)
					{
						return false;
					}
					_003C_003E1__state = -1;
				}
				else
				{
					_003C_003E1__state = -1;
					Skeleton skeleton2 = footSoldierExample.skeletonAnimation.Skeleton;
					skeleton2.SetAttachment(footSoldierExample.eyesSlot, footSoldierExample.eyesOpenAttachment);
				}
				float num2 = UnityEngine.Random.Range(0.25f, 3f);
				num = 1;
				seconds = num2;
				goto IL_0162;
				IL_0162:
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
			[Token(Token = "0x600004E")]
			[Address(RVA = "0x150B484", Offset = "0x150B484", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[SpineAnimation("Idle", null, true, false)]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x20")]
		public string idleAnimation;

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x28")]
		public string attackAnimation;

		[SpineAnimation(null, null, true, false)]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x30")]
		public string moveAnimation;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x38")]
		public string eyesSlot;

		[SpineAttachment(true, false, false, "eyesSlot", null, null, true, false)]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x40")]
		public string eyesOpenAttachment;

		[SpineAttachment(true, false, false, "eyesSlot", null, null, true, false)]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x48")]
		public string blinkAttachment;

		[Range(0f, 0.2f)]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x50")]
		public float blinkDuration;

		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x54")]
		public KeyCode attackKey;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x58")]
		public KeyCode rightKey;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x5C")]
		public KeyCode leftKey;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x60")]
		public float moveSpeed;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x68")]
		private SkeletonAnimation skeletonAnimation;

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x150B090", Offset = "0x150B090", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A379F3]) = v46;\nL_0021:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v49;\n\tv55 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v55, this, Il2CppMethodInfo);\n\tv62 = v49 == 0;\n\tif (v62) goto L_0039;\n\tSpine.Unity.SkeletonRenderer::add_OnRebuild(v49, v55);\n\treturn;\nL_0039:\n\tthrow v55;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			SkeletonAnimation skeletonAnimation = (this.skeletonAnimation = GetComponent<SkeletonAnimation>());
			SkeletonRenderer.SkeletonRendererDelegate skeletonRendererDelegate = Apply;
			if ((object)skeletonAnimation != null)
			{
				skeletonAnimation.OnRebuild += skeletonRendererDelegate;
				return;
			}
			throw skeletonRendererDelegate;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x150B144", Offset = "0x150B144", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Spine.Unity.Examples.FootSoldierExample::Blink(this);\n\tv13 = UnityEngine.MonoBehaviour::StartCoroutine(this, v6);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Apply(SkeletonRenderer skeletonRenderer)
		{
			IEnumerator routine = Blink();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x150B1C4", Offset = "0x150B1C4", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.Input::GetKey(this.attackKey);\n\tv12 = v10 == 0;\n\tif (v12) goto L_0018;\n\tv84 = this.skeletonAnimation;\n\tv82 = this.attackAnimation;\nL_0014:\n\tSpine.Unity.SkeletonAnimation::set_AnimationName(v84, v82);\n\treturn;\nL_0018:\n\tv17 = UnityEngine.Input::GetKey(this.rightKey);\n\tv79 = v17 == 0;\n\tif (v79) goto L_0039;\n\tSpine.Unity.SkeletonAnimation::set_AnimationName(this.skeletonAnimation, this.moveAnimation);\n\tv56 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv56.scaleX = 1f;\n\tv117 = UnityEngine.Component::get_transform(this);\n\tv21 = UnityEngine.Time::get_deltaTime();\n\tv98 = this.moveSpeed * v21;\n\tgoto L_0060;\nL_0039:\n\tv58 = UnityEngine.Input::GetKey(this.leftKey);\n\tv114 = v58 == 0;\n\tif (v114) goto L_0064;\n\tSpine.Unity.SkeletonAnimation::set_AnimationName(this.skeletonAnimation, this.moveAnimation);\n\tv60 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv60.scaleX = -1f;\n\tv119 = UnityEngine.Component::get_transform(this);\n\tv22 = UnityEngine.Time::get_deltaTime();\n\tv123 = -this.moveSpeed;\n\tv98 = v22 * v123;\nL_0060:\n\tUnityEngine.Transform::Translate(v129, v98, v96, 0f);\n\treturn;\nL_0064:\n\tv82 = this.idleAnimation;\n\tgoto L_0014;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0174: Expected O, but got F4
			SkeletonAnimation skeletonAnimation;
			string animationName;
			if (Input.GetKey(attackKey))
			{
				skeletonAnimation = this.skeletonAnimation;
				animationName = attackAnimation;
				goto IL_01c9;
			}
			float x;
			float y;
			Transform transform2;
			if (Input.GetKey(rightKey))
			{
				this.skeletonAnimation.AnimationName = moveAnimation;
				Skeleton skeleton = this.skeletonAnimation.Skeleton;
				skeleton.ScaleX = 1f;
				Transform transform = base.transform;
				float deltaTime = Time.deltaTime;
				x = moveSpeed * deltaTime;
				y = 0f;
				transform2 = transform;
			}
			else
			{
				if (!Input.GetKey(leftKey))
				{
					animationName = idleAnimation;
					skeletonAnimation = this.skeletonAnimation;
					goto IL_01c9;
				}
				this.skeletonAnimation.AnimationName = moveAnimation;
				Skeleton skeleton2 = this.skeletonAnimation.Skeleton;
				skeleton2.ScaleX = -1f;
				Transform transform3 = base.transform;
				float deltaTime2 = Time.deltaTime;
				object obj = 0f - moveSpeed;
				x = deltaTime2 * (float)obj;
				y = 0f;
				transform2 = transform3;
			}
			transform2.Translate(x, y, 0f);
			return;
			IL_01c9:
			skeletonAnimation.AnimationName = animationName;
		}

		[IteratorStateMachine(typeof(_003CBlink_003Ed__15))]
		[Token(Token = "0x6000048")]
		[Address(RVA = "0x150B164", Offset = "0x150B164", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.FootSoldierExample+<Blink>d__15;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379F4]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.FootSoldierExample+<Blink>d__15();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Blink()
		{
			_003CBlink_003Ed__15 _003CBlink_003Ed__16 = null;
			_003CBlink_003Ed__16._003C_003E1__state = 0;
			_003CBlink_003Ed__16._003C_003E4__this = this;
			return _003CBlink_003Ed__16;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x150B32C", Offset = "0x150B32C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.blinkDuration = 0.05f;\n\tthis.attackKey = 2.12199579256E-312d;\n\tthis.leftKey = 0x4040000000000061;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FootSoldierExample()
		{
			//IL_0020: Expected I4, but got F8
			//IL_002f: Expected I4, but got I8
			base._002Ector();
			blinkDuration = 0.05f;
			attackKey = KeyCode.None;
			leftKey = KeyCode.A;
		}
	}
}
