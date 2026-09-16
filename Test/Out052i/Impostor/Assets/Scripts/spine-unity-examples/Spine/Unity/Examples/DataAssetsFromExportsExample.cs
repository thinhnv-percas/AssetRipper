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
	[Token(Token = "0x2000013")]
	public class DataAssetsFromExportsExample : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000014")]
		private sealed class _003CStart_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000059")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400005A")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400005B")]
			[FieldOffset(Offset = "0x20")]
			public DataAssetsFromExportsExample _003C_003E4__this;

			[Token(Token = "0x17000008")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600003E")]
				[Address(RVA = "0x150AF74", Offset = "0x150AF74", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000009")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000040")]
				[Address(RVA = "0x150AFB4", Offset = "0x150AFB4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x150AD40", Offset = "0x150AD40", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CStart_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x150AD70", Offset = "0x150AD70", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600003D")]
			[Address(RVA = "0x150AD74", Offset = "0x150AD74", Length = "0x200")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv47 = UnityEngine.WaitForSeconds;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv54 = \"base\";\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv145 = \"run\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A379F2]) = v34;\nL_001A:\n\tv36 = this.<>4__this;\n\tv41 = this.<>1__state == 1;\n\tif (v41) goto L_0041;\n\tv49 = this.<>1__state == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tSpine.Unity.Examples.DataAssetsFromExportsExample::CreateRuntimeAssetsAndGameObject(v36);\n\tv189 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(v36.runtimeSkeletonDataAsset, 0);\n\tv192 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v192, 0.5f);\n\tthis.<>2__current = v192;\n\tthis.<>1__state = 1;\n\tgoto L_00A2;\nL_0041:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv93 = Spine.Unity.SkeletonAnimation::NewSkeletonAnimationGameObject(v36.runtimeSkeletonDataAsset);\n\tv36.runtimeSkeletonAnimation = v93;\n\tv187 = Spine.Unity.SkeletonAnimation::Initialize(v93, 0);\n\tv114 = Spine.Unity.SkeletonRenderer::get_Skeleton(v36.runtimeSkeletonAnimation);\n\tSpine.Skeleton::SetSkin(v114, \"base\");\n\tv116 = Spine.Unity.SkeletonRenderer::get_Skeleton(v36.runtimeSkeletonAnimation);\n\tSpine.Skeleton::SetSlotsToSetupPose(v116);\n\tv138 = v36.runtimeSkeletonAnimation;\n\tv195 = Spine.AnimationState::SetAnimation(v138.state, 0, \"run\", 1);\n\tv119 = UnityEngine.Component::GetComponent(v36.runtimeSkeletonAnimation);\n\tUnityEngine.Renderer::set_sortingOrder(v119, 0xA);\n\tv197 = UnityEngine.Component::get_transform(v36.runtimeSkeletonAnimation);\n\tgoto L_0093;\n\tv202 = UnityEngine.Vector3;\n\tv203 = \"il2cpp_codegen_initialize_runtime_metadata\"(v202, v110, v77, v70, v68, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv204 = 1;\n\t*([1A37A9D]) = v204;\nL_0093:\n\tv207 = UnityEngine.Vector3;\n\tv87 = *([v207 @ X8_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv62 = *([v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]) + *([v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]);\n\tv66 = *([v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+28]) + *([v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+28]);\n\tv75 = v87.downVector + v87.downVector;\n\t// 155 MakeStruct v59 @ AGG150EF5C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v75 @ V0_v4 (System.Single), v66 @ V1_v4, v62 @ V2_v3\n\tUnityEngine.Transform::Translate(v197, v59);\nL_00A2:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_01b3: Expected I, but got O
				//IL_01bc: Expected I, but got O
				//IL_01d9: Expected O, but got I
				//IL_01f6: Expected O, but got I
				//IL_022b: Expected F4, but got O
				//IL_0238: Expected F4, but got O
				DataAssetsFromExportsExample dataAssetsFromExportsExample = _003C_003E4__this;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						dataAssetsFromExportsExample.CreateRuntimeAssetsAndGameObject();
						SkeletonData skeletonData = dataAssetsFromExportsExample.runtimeSkeletonDataAsset.GetSkeletonData(quiet: false);
						WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);
						_003C_003E2__current = waitForSeconds;
						_003C_003E1__state = 1;
						return true;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					(dataAssetsFromExportsExample.runtimeSkeletonAnimation = SkeletonAnimation.NewSkeletonAnimationGameObject(dataAssetsFromExportsExample.runtimeSkeletonDataAsset)).Initialize(overwrite: false);
					Skeleton skeleton = dataAssetsFromExportsExample.runtimeSkeletonAnimation.Skeleton;
					skeleton.SetSkin("base");
					Skeleton skeleton2 = dataAssetsFromExportsExample.runtimeSkeletonAnimation.Skeleton;
					skeleton2.SetSlotsToSetupPose();
					SkeletonAnimation runtimeSkeletonAnimation = dataAssetsFromExportsExample.runtimeSkeletonAnimation;
					TrackEntry trackEntry = runtimeSkeletonAnimation.state.SetAnimation(0, "run", loop: true);
					MeshRenderer component = dataAssetsFromExportsExample.runtimeSkeletonAnimation.GetComponent<MeshRenderer>();
					component.sortingOrder = 10;
					Transform transform = dataAssetsFromExportsExample.runtimeSkeletonAnimation.transform;
					nint num = (nint)typeof(Vector3);
					nint num2 = (nint)Vector3.zero;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
					object obj = num3 + 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X8_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
					object obj2 = num4 + 0;
					float x = Vector3.down.x + Vector3.down.x;
					Vector3 translation = default(Vector3);
					translation.x = x;
					translation.y = (float)obj2;
					translation.z = (float)obj;
					transform.Translate(translation);
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x150AF7C", Offset = "0x150AF7C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x20")]
		public TextAsset skeletonJson;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x28")]
		public TextAsset atlasText;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x30")]
		public Texture2D[] textures;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x38")]
		public Material materialPropertySource;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x40")]
		private SpineAtlasAsset runtimeAtlasAsset;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x48")]
		private SkeletonDataAsset runtimeSkeletonDataAsset;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x50")]
		private SkeletonAnimation runtimeSkeletonAnimation;

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x150AC94", Offset = "0x150AC94", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Spine.Unity.SpineAtlasAsset::CreateRuntimeInstance(this.atlasText, this.textures, this.materialPropertySource, 1);\n\tthis.runtimeAtlasAsset = v11;\n\tv19 = Spine.Unity.SkeletonDataAsset::CreateRuntimeInstance(this.skeletonJson, v11, 1, 0.01f);\n\tthis.runtimeSkeletonDataAsset = v19;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateRuntimeAssetsAndGameObject()
		{
			SkeletonDataAsset skeletonDataAsset = SkeletonDataAsset.CreateRuntimeInstance(atlasAsset: runtimeAtlasAsset = SpineAtlasAsset.CreateRuntimeInstance(atlasText, textures, materialPropertySource, initialize: true), skeletonDataFile: skeletonJson, initialize: true);
			runtimeSkeletonDataAsset = skeletonDataAsset;
		}

		[IteratorStateMachine(typeof(_003CStart_003Ed__8))]
		[Token(Token = "0x6000039")]
		[Address(RVA = "0x150ACE0", Offset = "0x150ACE0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.DataAssetsFromExportsExample+<Start>d__8;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A379F1]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.DataAssetsFromExportsExample+<Start>d__8();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			_003CStart_003Ed__8 _003CStart_003Ed__9 = null;
			_003CStart_003Ed__9._003C_003E1__state = 0;
			_003CStart_003Ed__9._003C_003E4__this = this;
			return _003CStart_003Ed__9;
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x150AD68", Offset = "0x150AD68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DataAssetsFromExportsExample()
		{
		}
	}
}
