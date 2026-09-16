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
	[Token(Token = "0x2000067")]
	public class SpawnFromSkeletonDataExample : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000068")]
		private sealed class _003CStart_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400023E")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400023F")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000240")]
			[FieldOffset(Offset = "0x20")]
			public SpawnFromSkeletonDataExample _003C_003E4__this;

			[Token(Token = "0x4000241")]
			[FieldOffset(Offset = "0x28")]
			private Animation _003CspineAnimation_003E5__2;

			[Token(Token = "0x4000242")]
			[FieldOffset(Offset = "0x30")]
			private int _003Ci_003E5__3;

			[Token(Token = "0x17000038")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001D2")]
				[Address(RVA = "0x151EB88", Offset = "0x151EB88", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000039")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001D4")]
				[Address(RVA = "0x151EBC8", Offset = "0x151EBC8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001CF")]
			[Address(RVA = "0x151E890", Offset = "0x151E890", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__3(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D0")]
			[Address(RVA = "0x151E9A4", Offset = "0x151E9A4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001D1")]
			[Address(RVA = "0x151E9A8", Offset = "0x151E9A8", Length = "0x1E0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv51 = UnityEngine.WaitForSeconds;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37AAC]) = v38;\nL_0016:\n\tv40 = this.<>4__this;\n\tv45 = this.<>1__state == 2;\n\tif (v45) goto L_0057;\n\tv56 = this.<>1__state == 1;\n\tif (v56) goto L_005F;\n\tv66 = this.<>1__state == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_003E;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v168, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003E:\n\tv121 = UnityEngine.Object::op_Equality(v40.skeletonDataAsset, 0);\n\tv232 = v121 == 0;\n\tv123 = ~v232;\n\tif (v123) goto L_FFFFFFFF;\n\tv238 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(v40.skeletonDataAsset, 0);\n\tv241 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v241, 1f);\n\tthis.<>2__current = v241;\n\tthis.<>1__state = 1;\n\tgoto L_00A8;\nL_0057:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv88 = this.<i>5__3 + 1;\n\tthis.<i>5__3 = v88;\n\tv64 = this.<>4__this == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_007A;\n\tgoto L_00A9;\nL_005F:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv152 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(v40.skeletonDataAsset, 0);\n\tv85 = Spine.SkeletonData::FindAnimation(v152, v40.startingAnimation);\n\tthis.<spineAnimation>5__2 = v85;\n\tthis.<i>5__3 = 0;\nL_007A:\n\tv100 = v88 >= v40.count;\n\tif (v100) goto L_FFFFFFFF;\n\tv165 = Spine.Unity.SkeletonAnimation::NewSkeletonAnimationGameObject(v40.skeletonDataAsset);\n\tSpine.Unity.Examples.SpawnFromSkeletonDataExample::DoExtraStuff(this.<>4__this, v165, this.<spineAnimation>5__2);\n\tv131 = this + 0x30;\n\tv235 = UnityEngine.Component::get_gameObject(v165);\n\tv154 = System.Int32::ToString(v131);\n\tUnityEngine.Object::set_name(v235, v154);\n\tv247 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v247, 0.125f);\n\tthis.<>2__current = v247;\n\tthis.<>1__state = 2;\n\tgoto L_00A8;\nL_00A8:\n\treturn returnVal1;\nL_00A9:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				//IL_025c: Expected I4, but got O
				SpawnFromSkeletonDataExample spawnFromSkeletonDataExample = _003C_003E4__this;
				int num;
				if (_003C_003E1__state != 2)
				{
					if (_003C_003E1__state != 1)
					{
						if (_003C_003E1__state == 0)
						{
							_003C_003E1__state = -1;
							if (!(spawnFromSkeletonDataExample.skeletonDataAsset == null))
							{
								SkeletonData skeletonData = spawnFromSkeletonDataExample.skeletonDataAsset.GetSkeletonData(quiet: false);
								WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
								_003C_003E2__current = waitForSeconds;
								_003C_003E1__state = 1;
								return true;
							}
						}
						goto IL_0240;
					}
					_003C_003E1__state = -1;
					SkeletonData skeletonData2 = spawnFromSkeletonDataExample.skeletonDataAsset.GetSkeletonData(quiet: false);
					Animation animation = skeletonData2.FindAnimation(spawnFromSkeletonDataExample.startingAnimation);
					_003CspineAnimation_003E5__2 = animation;
					_003Ci_003E5__3 = 0;
					num = 0;
				}
				else
				{
					_003C_003E1__state = -1;
					num = ++_003Ci_003E5__3;
					if ((object)_003C_003E4__this == null)
					{
						NullReferenceException ex = new NullReferenceException();
						return (byte)(int)ex != 0;
					}
				}
				if (num < spawnFromSkeletonDataExample.count)
				{
					SkeletonAnimation skeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(spawnFromSkeletonDataExample.skeletonDataAsset);
					_003C_003E4__this.DoExtraStuff(skeletonAnimation, _003CspineAnimation_003E5__2);
					int num2 = (int)((nint)this + 48);
					GameObject gameObject = skeletonAnimation.gameObject;
					string name = ((int*)num2)->ToString();
					gameObject.name = name;
					WaitForSeconds waitForSeconds2 = new WaitForSeconds(0.125f);
					_003C_003E2__current = waitForSeconds2;
					_003C_003E1__state = 2;
					return true;
				}
				goto IL_0240;
				IL_0240:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D3")]
			[Address(RVA = "0x151EB90", Offset = "0x151EB90", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonDataAsset skeletonDataAsset;

		[Range(0f, 100f)]
		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x28")]
		public int count;

		[SpineAnimation(null, "skeletonDataAsset", true, false)]
		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x30")]
		public string startingAnimation;

		[IteratorStateMachine(typeof(_003CStart_003Ed__3))]
		[Token(Token = "0x60001CC")]
		[Address(RVA = "0x151E830", Offset = "0x151E830", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpawnFromSkeletonDataExample+<Start>d__3;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AAB]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpawnFromSkeletonDataExample+<Start>d__3();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__3 _003CStart_003Ed__4 = null;
			_003CStart_003Ed__4._003C_003E1__state = 0;
			_003CStart_003Ed__4._003C_003E4__this = this;
			return _003CStart_003Ed__4;
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0x151E8B8", Offset = "0x151E8B8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.Component::get_transform(sa);\n\tv43 = UnityEngine.Random::get_insideUnitCircle();\n\tv40 = v43.y * 6f;\n\tv44 = v43 * 6f;\n\t// 26 MakeStruct v33 @ AGG1522908_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v44 @ V0_v3 (System.Single), v40 @ V1_v3 (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(v19, v33);\n\tv113 = UnityEngine.Component::get_transform(sa);\n\tv54 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v113, v54, 0);\n\tv107 = spineAnimation == 0;\n\tif (v107) goto L_0047;\n\tv116 = Spine.Unity.SkeletonAnimation::Initialize(sa, 0);\n\tv98 = Spine.AnimationState::SetAnimation(sa.state, 0, spineAnimation, 1);\n\treturn;\nL_0047:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoExtraStuff(SkeletonAnimation sa, Animation spineAnimation)
		{
			Transform transform = sa.transform;
			Vector2 insideUnitCircle = UnityEngine.Random.insideUnitCircle;
			float y = insideUnitCircle.y * 6f;
			float x = insideUnitCircle.x * 6f;
			Vector3 localPosition = default(Vector3);
			localPosition.x = x;
			localPosition.y = y;
			localPosition.z = 0f;
			transform.localPosition = localPosition;
			Transform transform2 = sa.transform;
			Transform parent = base.transform;
			transform2.SetParent(parent, worldPositionStays: false);
			if (spineAnimation != null)
			{
				sa.Initialize(overwrite: false);
				TrackEntry trackEntry = sa.state.SetAnimation(0, spineAnimation, loop: true);
			}
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0x151E994", Offset = "0x151E994", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.count = 0x14;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpawnFromSkeletonDataExample()
		{
			count = 20;
		}
	}
}
