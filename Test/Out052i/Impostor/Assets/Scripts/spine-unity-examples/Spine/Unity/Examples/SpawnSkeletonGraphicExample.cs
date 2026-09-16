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
	[Token(Token = "0x2000069")]
	public class SpawnSkeletonGraphicExample : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200006A")]
		private sealed class _003CStart_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000247")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000248")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000249")]
			[FieldOffset(Offset = "0x20")]
			public SpawnSkeletonGraphicExample _003C_003E4__this;

			[Token(Token = "0x1700003A")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001DA")]
				[Address(RVA = "0x151EE40", Offset = "0x151EE40", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700003B")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001DC")]
				[Address(RVA = "0x151EE80", Offset = "0x151EE80", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D7")]
			[Address(RVA = "0x151EC30", Offset = "0x151EC30", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D8")]
			[Address(RVA = "0x151ECA8", Offset = "0x151ECA8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001D9")]
			[Address(RVA = "0x151ECAC", Offset = "0x151ECAC", Length = "0x194")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = UnityEngine.Object;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv49 = UnityEngine.WaitForSeconds;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv56 = \"SkeletonGraphic Instance\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37AAF]) = v36;\nL_0018:\n\tv38 = this.<>4__this;\n\tv43 = this.<>1__state == 1;\n\tif (v43) goto L_004E;\n\tv51 = this.<>1__state == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_0036;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v118, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0036:\n\tv73 = UnityEngine.Object::op_Equality(*([v38 @ X19_v2 (UnityEngine.Component)+20]), 0);\n\tv159 = v73 == 0;\n\tv76 = ~v159;\n\tif (v76) goto L_FFFFFFFF;\n\tv161 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(*([v38 @ X19_v2 (UnityEngine.Component)+20]), 0);\n\tv167 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v167, 1f);\n\tthis.<>2__current = v167;\n\tthis.<>1__state = 1;\n\tgoto L_0083;\nL_004E:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv86 = UnityEngine.Component::get_transform(this.<>4__this);\n\tv102 = Spine.Unity.SkeletonGraphic::NewSkeletonGraphicGameObject(*([v38 @ X19_v2 (UnityEngine.Component)+20]), v86, *([v38 @ X19_v2 (UnityEngine.Component)+38]));\n\tv103 = UnityEngine.Component::get_gameObject(v102);\n\tUnityEngine.Object::set_name(v103, \"SkeletonGraphic Instance\");\n\tSpine.Unity.SkeletonGraphic::Initialize(v102, 0);\n\tSpine.Skeleton::SetSkin(v102.skeleton, *([v38 @ X19_v2 (UnityEngine.Component)+30]));\n\tSpine.Skeleton::SetSlotsToSetupPose(v102.skeleton);\n\tv72 = Spine.AnimationState::SetAnimation(v102.state, 0, *([v38 @ X19_v2 (UnityEngine.Component)+28]), 1);\nL_0083:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0113: Expected O, but got I
				//IL_0113: Expected O, but got I
				//IL_0169: Expected O, but got I
				//IL_0056: Expected O, but got I
				//IL_01a5: Expected O, but got I
				//IL_0098: Expected O, but got I
				Component component = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X19_v2 (UnityEngine.Component)+20]");
						if (!((UnityEngine.Object)0 == null))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X19_v2 (UnityEngine.Component)+20]");
							SkeletonData skeletonData = ((SkeletonDataAsset)0).GetSkeletonData(quiet: false);
							WaitForSeconds waitForSeconds = new WaitForSeconds(1f);
							_003C_003E2__current = waitForSeconds;
							_003C_003E1__state = 1;
							return true;
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					Transform transform = _003C_003E4__this.transform;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X19_v2 (UnityEngine.Component)+20]");
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X19_v2 (UnityEngine.Component)+38]");
					SkeletonGraphic skeletonGraphic = SkeletonGraphic.NewSkeletonGraphicGameObject((SkeletonDataAsset)num, transform, (Material)0);
					GameObject gameObject = skeletonGraphic.gameObject;
					gameObject.name = "SkeletonGraphic Instance";
					skeletonGraphic.Initialize(overwrite: false);
					Skeleton skeleton = skeletonGraphic.Skeleton;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X19_v2 (UnityEngine.Component)+30]");
					skeleton.SetSkin((string)0);
					skeletonGraphic.Skeleton.SetSlotsToSetupPose();
					AnimationState animationState = skeletonGraphic.AnimationState;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X19_v2 (UnityEngine.Component)+28]");
					TrackEntry trackEntry = animationState.SetAnimation(0, (string)0, loop: true);
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001DB")]
			[Address(RVA = "0x151EE48", Offset = "0x151EE48", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000243")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonDataAsset skeletonDataAsset;

		[SpineAnimation(null, "skeletonDataAsset", true, false)]
		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x28")]
		public string startingAnimation;

		[SpineSkin(null, "skeletonDataAsset", true, false, false)]
		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x30")]
		public string startingSkin;

		[Token(Token = "0x4000246")]
		[FieldOffset(Offset = "0x38")]
		public Material skeletonGraphicMaterial;

		[IteratorStateMachine(typeof(_003CStart_003Ed__4))]
		[Token(Token = "0x60001D5")]
		[Address(RVA = "0x151EBD0", Offset = "0x151EBD0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SpawnSkeletonGraphicExample+<Start>d__4;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AAD]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SpawnSkeletonGraphicExample+<Start>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__4 _003CStart_003Ed__5 = null;
			_003CStart_003Ed__5._003C_003E1__state = 0;
			_003CStart_003Ed__5._003C_003E4__this = this;
			return _003CStart_003Ed__5;
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0x151EC58", Offset = "0x151EC58", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = \"base\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AAE]) = v37;\nL_0016:\n\tthis.startingSkin = \"base\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpawnSkeletonGraphicExample()
		{
			startingSkin = "base";
		}
	}
}
