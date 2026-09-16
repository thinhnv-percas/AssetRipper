using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200004F")]
	public class AtlasRegionAttacher : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000050")]
		public class SlotRegionPair
		{
			[SpineSlot(null, null, false, true, false)]
			[Token(Token = "0x40001AC")]
			[FieldOffset(Offset = "0x10")]
			public string slot;

			[SpineAtlasRegion(null)]
			[Token(Token = "0x40001AD")]
			[FieldOffset(Offset = "0x18")]
			public string region;

			[Token(Token = "0x6000151")]
			[Address(RVA = "0x151715C", Offset = "0x151715C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SlotRegionPair()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x20")]
		protected SpineAtlasAsset atlasAsset;

		[SerializeField]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x28")]
		protected bool inheritProperties;

		[SerializeField]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x30")]
		protected List<SlotRegionPair> attachments;

		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x38")]
		private Atlas atlas;

		[Token(Token = "0x600014E")]
		[Address(RVA = "0x1516D68", Offset = "0x1516D68", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv58 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A6F]) = v46;\nL_0021:\n\tv49 = UnityEngine.Component::GetComponent(this);\n\tv56 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v56, this, Il2CppMethodInfo);\n\tv63 = v49 == 0;\n\tif (v63) goto L_0047;\n\tSpine.Unity.SkeletonRenderer::add_OnRebuild(v49, v56);\n\tv69 = ~v49.valid;\n\tif (v69) goto L_0046;\n\tSpine.Unity.Examples.AtlasRegionAttacher::Apply(this, v49);\n\treturn;\nL_0046:\n\treturn;\nL_0047:\n\tthrow v56;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			SkeletonRenderer.SkeletonRendererDelegate skeletonRendererDelegate = Apply;
			if ((object)component != null)
			{
				component.OnRebuild += skeletonRendererDelegate;
				if (component.valid)
				{
					Apply(component);
				}
				return;
			}
			throw skeletonRendererDelegate;
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0x1516E40", Offset = "0x1516E40", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, skeletonRenderer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, skeletonRenderer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, skeletonRenderer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv163 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, skeletonRenderer, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37A70]) = v45;\nL_0024:\n\tv51 = UnityEngine.Behaviour::get_enabled(this);\n\tv56 = v51 == 0;\n\tif (v56) goto L_0093;\n\tv60 = this.atlasAsset;\n\tv61 = this.atlasAsset == 0;\n\tif (v61) goto L_0098;\n\tv149 = *([v60 @ X0_v5 (Spine.Unity.SpineAtlasAsset)]);\n\tv137 = Spine.Unity.SpineAtlasAsset::GetAtlas(this.atlasAsset);\n\tthis.atlas = v137;\n\tv141 = v137 == 0;\n\tif (v141) goto L_0093;\n\tv173 = skeletonRenderer == 0;\n\tif (v173) goto L_0098;\n\tv178 = skeletonRenderer.skeletonDataAsset;\n\tv174 = skeletonRenderer.skeletonDataAsset == 0;\n\tif (v174) goto L_0098;\n\tv175 = this.attachments == 0;\n\tif (v175) goto L_0098;\n\tv229 = System.Collections.Generic.List`1<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>::GetEnumerator(this.attachments);\nL_0048:\n\tv266 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v120 @ stack_-78_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv140 = v266 == 0;\n\tif (v140) goto L_0089;\n\tv276 = Spine.Unity.SkeletonRenderer::get_Skeleton(skeletonRenderer);\n\tv290 = Spine.Skeleton::FindSlot(v276, *([v235 @ stack_-68+10]));\n\tv298 = Spine.Atlas::FindRegion(this.atlas, *([v235 @ stack_-68+18]));\n\tv260 = v298 == 0;\n\tif (v260) goto L_0078;\n\tv300 = v290.attachment == 0;\n\tif (v300) goto L_007F;\n\tv259 = ~this.inheritProperties;\n\tif (v259) goto L_007F;\n\tv308 = Spine.Unity.AttachmentTools.AttachmentCloneExtensions::GetRemappedClone(v290.attachment, v298, 1, 1, v178.scale);\n\tSpine.Slot::set_Attachment(v290, v308);\n\tgoto L_0048;\nL_0078:\n\tSpine.Slot::set_Attachment(v290, 0);\n\tgoto L_0048;\nL_007F:\n\tv304 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(v298, v298.name, v178.scale, 0f);\n\tSpine.Slot::set_Attachment(v290, v304);\n\tgoto L_0048;\nL_0089:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v120 @ stack_-78_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0093:\n\treturn;\n\tv295 = new System.NullReferenceException();\n\tv285 = new System.NullReferenceException();\n\tv289 = new System.NullReferenceException();\n\tv169 = new System.NullReferenceException();\nL_0098:\n\tv180 = new System.NullReferenceException();\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\n\tgoto L_00AE;\nL_00AE:\n\tv64 = v166 != 1;\n\tif (v64) goto L_00BE;\n\tv218 = 0x1854E70(v180, v166, v103, v97, v94, v31, v32, v33, v118, v91, v36, v37, v38, v39, v40, v41);\n\tv230 = 0x1854E80(v218, v166, v103, v97, v94, v31, v32, v33, v118, v91, v36, v37, v38, v39, v40, v41);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v112 @ stack_-60_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv142 = *([v218 @ X0_v17]) == 0;\n\tif (v142) goto L_0093;\n\tthrow System.OutOfMemoryException;\nL_00BE:\n\tgoto L_00C4;\n\tX19 = X0;\nL_00C4:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v112 @ stack_-60_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00CB;\n\tv268 = System.Collections.Generic.List`1<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>+Enumerator<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>::Dispose(v180);\nL_00CB:\n\tv271 = new System.OutOfMemoryException();\n\tv207 = System.Collections.Generic.List`1<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>+Enumerator<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>::Dispose(v271);\n\treturn;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Apply(SkeletonRenderer skeletonRenderer)
		{
			//IL_003e: Expected I, but got O
			//IL_00be: Expected O, but got I4
			//IL_012f: Expected O, but got I
			//IL_0190: Expected O, but got I
			//IL_01d9: Expected O, but got I
			//IL_01f9: Expected O, but got I
			//IL_029b: Expected O, but got I4
			if (!base.enabled)
			{
				return;
			}
			SpineAtlasAsset spineAtlasAsset = atlasAsset;
			bool flag = (object)atlasAsset == null;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator = enumerator2;
			object obj5 = default(object);
			if (!flag)
			{
				nint num = (nint)spineAtlasAsset;
				if ((atlas = atlasAsset.GetAtlas()) == null)
				{
					return;
				}
				bool flag2 = (object)skeletonRenderer == null;
				float num3 = default(float);
				float num2 = num3;
				object obj2 = default(object);
				object obj = obj2;
				bool flag4 = default(bool);
				bool flag3 = flag4;
				IntPtr intPtr2 = default(IntPtr);
				IntPtr intPtr = intPtr2;
				enumerator = default(List<object>.Enumerator);
				object obj4 = default(object);
				object obj3 = obj4;
				obj5 = 0;
				if (!flag2)
				{
					SkeletonDataAsset skeletonDataAsset = skeletonRenderer.skeletonDataAsset;
					bool flag5 = (object)skeletonRenderer.skeletonDataAsset == null;
					num2 = num3;
					obj = obj2;
					flag3 = flag4;
					intPtr = intPtr2;
					enumerator = default(List<object>.Enumerator);
					obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v10 (Il2CppClass<Spine.Unity.SpineAtlasAsset>)+1D0]");
					obj5 = 0;
					if (!flag5)
					{
						bool flag6 = attachments == null;
						num2 = num3;
						obj = obj2;
						flag3 = flag4;
						intPtr = intPtr2;
						enumerator = default(List<object>.Enumerator);
						obj3 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v10 (Il2CppClass<Spine.Unity.SpineAtlasAsset>)+1D0]");
						obj5 = 0;
						if (!flag6)
						{
							List<SlotRegionPair>.Enumerator enumerator3 = attachments.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								Skeleton skeleton = skeletonRenderer.Skeleton;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ stack_-68+10]");
								Slot slot = skeleton.FindSlot((string)0);
								Atlas obj6 = atlas;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ stack_-68+18]");
								AtlasRegion atlasRegion = obj6.FindRegion((string)0);
								if (atlasRegion != null)
								{
									if (slot.Attachment != null && inheritProperties)
									{
										Attachment remappedClone = slot.Attachment.GetRemappedClone(atlasRegion, cloneMeshAsLinked: true, useOriginalRegionSize: true, skeletonDataAsset.scale);
										slot.Attachment = remappedClone;
										obj = 0;
										flag3 = true;
									}
									else
									{
										RegionAttachment attachment = atlasRegion.ToRegionAttachment(atlasRegion.name, skeletonDataAsset.scale);
										slot.Attachment = attachment;
										num2 = 0f;
									}
								}
								else
								{
									slot.Attachment = null;
								}
							}
							enumerator2.Dispose();
							return;
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((nint)obj5 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj7 = default(object);
				if (obj7 != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<SlotRegionPair>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0x15170D8", Offset = "0x15170D8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.List`1<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A71]) = v42;\nL_001A:\n\tthis.inheritProperties = 1;\n\tv45 = new System.Collections.Generic.List`1<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>();\n\tSystem.Collections.Generic.List`1<Spine.Unity.Examples.AtlasRegionAttacher+SlotRegionPair>::.ctor(v45);\n\tthis.attachments = v45;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AtlasRegionAttacher()
		{
			inheritProperties = true;
			List<SlotRegionPair> list = new List<SlotRegionPair>();
			attachments = list;
		}
	}
}
