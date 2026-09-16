using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200004A")]
	public class CombinedSkin : MonoBehaviour
	{
		[SpineSkin(null, null, true, false, false)]
		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x20")]
		public List<string> skinsToCombine;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x28")]
		private Skin combinedSkin;

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x1515244", Offset = "0x1515244", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv174 = Il2CppMethodInfo;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv259 = Spine.Unity.IAnimationStateComponent;\n\tv260 = \"il2cpp_codegen_initialize_runtime_metadata\"(v259, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv283 = Spine.Unity.ISkeletonComponent;\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv295 = Il2CppMethodInfo;\n\tv296 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv301 = Spine.Skin;\n\tv302 = \"il2cpp_codegen_initialize_runtime_metadata\"(v301, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv321 = \"combined\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A60]) = v42;\nL_0032:\n\tv48 = UnityEngine.Component::GetComponent(this);\n\tv52 = v48 == 0;\n\tif (v52) goto L_00E7;\n\tgoto L_0063;\n\tv176 = *([v57 @ X8_v4+B0]);\n\tv177 = v176 + 8;\n\tv179 = *([v272 @ X10_v16-8]);\n\tv277 = v179 == v61;\n\tif (v277) goto L_005B;\n\tv199 = v271 - 1;\n\tv201 = v272 + 0x10;\n\tv181 = v271 != 1;\n\tif (v181) goto L_FFFFFFFF;\n\tv202 = 1;\n\tv203 = v59;\n\tv204 = 0xB349B4(v203, v61, v202, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0063;\nL_005B:\n\tv286 = *([v272 @ X10_v16]);\n\tv287 = v286 + 1;\n\tv288 = v287 << 4;\n\tv289 = v57 + v288;\n\tv290 = v289 + 0x138;\nL_0063:\n\tv152 = Spine.Unity.ISkeletonComponent::get_Skeleton(v48);\n\tv156 = v152 == 0;\n\tif (v156) goto L_00E7;\n\tv307 = this.combinedSkin;\n\tv298 = this.combinedSkin == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_007A;\n\tv306 = new Spine.Skin();\n\tSpine.Skin::.ctor(v306, \"combined\");\n\tthis.combinedSkin = v306;\n\tv315 = v306 == 0;\n\tif (v315) goto L_00E9;\nL_007A:\n\tSpine.Skin::Clear(v307);\n\tv324 = this.skinsToCombine == 0;\n\tif (v324) goto L_00E9;\n\tv330 = System.Collections.Generic.List`1<System.String>::GetEnumerator(this.skinsToCombine);\nL_008B:\n\tv371 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v329 @ stack_-68_v4 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv374 = v371 == 0;\n\tif (v374) goto L_00A0;\n\tv366 = Spine.SkeletonData::FindSkin(v152.data, v359);\n\tv369 = v366 == 0;\n\tif (v369) goto L_008B;\n\tSpine.Unity.AttachmentTools.SkinUtilities::AddAttachments(this.combinedSkin, v366);\n\tgoto L_008B;\nL_00A0:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v329 @ stack_-68_v4 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00A4:\n\tSpine.Skeleton::SetSkin(v152, v159.combinedSkin);\n\tSpine.Skeleton::SetToSetupPose(v152);\n\t// 172 IsInst v151 @ X0_v28 (Spine.Unity.IAnimationStateComponent), typeof(Spine.Unity.IAnimationStateComponent), v48 @ X0_v3 (Spine.Unity.ISkeletonComponent)\n\tv155 = v151 == 0;\n\tif (v155) goto L_00E7;\n\tgoto L_00DA;\n\tv420 = *([v416 @ X8_v14+B0]);\n\tv421 = v420 + 8;\n\tv423 = *([v460 @ X10_v11-8]);\n\tv465 = v423 == v417;\n\tif (v465) goto L_00D3;\n\tv443 = v459 - 1;\n\tv445 = v460 + 0x10;\n\tv425 = v459 != 1;\n\tif (v425) goto L_FFFFFFFF;\n\tv446 = v158;\n\tv447 = 0;\n\tv448 = 0xB349B4(v446, v417, v447, v26, v27, v28, v29, v30, v75, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00DA;\nL_00D3:\n\tv471 = *([v460 @ X10_v11]);\n\tv472 = v471 << 4;\n\tv473 = v416 + v472;\n\tv474 = v473 + 0x138;\nL_00DA:\n\tv353 = Spine.Unity.IAnimationStateComponent::get_AnimationState(v151);\n\tv154 = v353 == 0;\n\tif (v154) goto L_00E9;\n\tv150 = Spine.AnimationState::Apply(v353, v152);\nL_00E7:\n\treturn;\n\tv352 = new System.NullReferenceException();\nL_00E9:\n\tv358 = new System.NullReferenceException();\n\tgoto L_00F7;\n\tgoto L_00F7;\n\tgoto L_00F7;\nL_00F7:\n\tv225 = v348 != 1;\n\tif (v225) goto L_0107;\n\tv376 = 0x1854E70(v358, v348, v223, v26, v27, v28, v29, v30, v215, v32, v33, v34, v35, v36, v37, v38);\n\tv392 = 0x1854E80(v376, v348, v223, v26, v27, v28, v29, v30, v215, v32, v33, v34, v35, v36, v37, v38);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v213 @ stack_-50_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv384 = *([v376 @ X0_v19]) == 0;\n\tif (v384) goto L_00A4;\n\tthrow System.OutOfMemoryException;\nL_0107:\n\tgoto L_010D;\n\tX22 = X0;\nL_010D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v213 @ stack_-50_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0114;\n\tv409 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(v358);\nL_0114:\n\tv412 = new System.OutOfMemoryException();\n\tv249 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(v412);\n\treturn;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Start()
		{
			//IL_009b: Expected O, but got I
			//IL_0345: Expected O, but got I4
			ISkeletonComponent component = GetComponent<ISkeletonComponent>();
			if (component == null)
			{
				return;
			}
			Skeleton skeleton = component.Skeleton;
			if (skeleton == null)
			{
				return;
			}
			Skin skin = this.combinedSkin;
			bool flag = this.combinedSkin == null;
			bool flag2 = !flag;
			int num = 0;
			List<object>.Enumerator enumerator;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			object obj;
			CombinedSkin combinedSkin;
			List<object>.Enumerator enumerator3;
			if (!flag2)
			{
				Skin skin2 = (this.combinedSkin = new Skin("combined"));
				bool flag3 = skin2 == null;
				skin = skin2;
				num = 0;
				enumerator = enumerator2;
				enumerator3 = enumerator2;
				obj = 0;
				combinedSkin = this;
				if (flag3)
				{
					goto IL_01ed;
				}
			}
			skin.Clear();
			bool flag4 = skinsToCombine == null;
			enumerator = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator4 = default(List<object>.Enumerator);
			enumerator3 = enumerator4;
			int num2 = 0;
			obj = "combined";
			combinedSkin = this;
			if (!flag4)
			{
				List<string>.Enumerator enumerator5 = skinsToCombine.GetEnumerator();
				num2 = num;
				string skinName = default(string);
				while (enumerator2.MoveNext())
				{
					Skin skin3 = skeleton.Data.FindSkin(skinName);
					bool flag5 = skin3 == null;
					num2 = 0;
					if (!flag5)
					{
						this.combinedSkin.AddAttachments(skin3);
						num2 = 0;
					}
				}
				enumerator2.Dispose();
				combinedSkin = this;
				goto IL_0187;
			}
			goto IL_01ed;
			IL_0187:
			skeleton.SetSkin(combinedSkin.combinedSkin);
			skeleton.SetToSetupPose();
			IAnimationStateComponent animationStateComponent = component as IAnimationStateComponent;
			if (animationStateComponent == null)
			{
				return;
			}
			AnimationState animationState = animationStateComponent.AnimationState;
			bool flag6 = animationState == null;
			enumerator = default(List<object>.Enumerator);
			enumerator3 = enumerator4;
			num2 = num;
			obj = 0;
			combinedSkin = this;
			if (!flag6)
			{
				bool flag7 = animationState.Apply(skeleton);
				return;
			}
			goto IL_01ed;
			IL_01ed:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)obj == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj2 = default(object);
				if (obj2 != null)
				{
					throw new OutOfMemoryException();
				}
				goto IL_0187;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((List<string>.Enumerator*)ex2)->Dispose();
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0x151556C", Offset = "0x151556C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CombinedSkin()
		{
		}
	}
}
