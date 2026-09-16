using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Unity.AttachmentTools;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000051")]
	public class SpriteAttacher : MonoBehaviour
	{
		[Token(Token = "0x40001AE")]
		public const string DefaultPMAShader = "Spine/Skeleton";

		[Token(Token = "0x40001AF")]
		public const string DefaultStraightAlphaShader = "Sprites/Default";

		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0x20")]
		public bool attachOnStart;

		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0x21")]
		public bool overrideAnimation;

		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0x28")]
		public Sprite sprite;

		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x30")]
		public string slot;

		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x38")]
		private RegionAttachment attachment;

		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x40")]
		private Slot spineSlot;

		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x48")]
		private bool applyPMA;

		[Token(Token = "0x40001B7")]
		private static Dictionary<Texture, AtlasPage> atlasPageCache;

		[Token(Token = "0x6000152")]
		[Address(RVA = "0x1517164", Offset = "0x1517164", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv22 = Spine.Unity.AttachmentTools.AtlasUtilities;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv112 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, Spine.AtlasPage>;\n\tv113 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv141 = UnityEngine.Material;\n\tv142 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv150 = Spine.Unity.Examples.SpriteAttacher;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v150, shader, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37A72]) = v41;\nL_002A:\n\tv57 = v44.atlasPageCache;\n\tv46 = v44.atlasPageCache == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0044;\n\tv54 = new System.Collections.Generic.Dictionary`2<UnityEngine.Texture, Spine.AtlasPage>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Texture, Spine.AtlasPage>::.ctor(v54);\n\tv84.atlasPageCache = v54;\n\tv57 = v62.atlasPageCache;\nL_0044:\n\tv71 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, Spine.AtlasPage>::TryGetValue(v57, texture, &v68 @ stack_-28_v3 (System.Object));\n\tv78 = v68 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_006F;\n\tv89 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v89, shader);\n\tgoto L_005B;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v145, v126, v127, v70, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005B:\n\treturnVal1 = Spine.Unity.AttachmentTools.AtlasUtilities::ToSpineAtlasPage(v89);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Texture, Spine.AtlasPage>::set_Item(v123.atlasPageCache, texture, returnVal1);\nL_006F:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static AtlasPage GetPageFor(Texture texture, Shader shader)
		{
			Dictionary<Texture, AtlasPage> dictionary = atlasPageCache;
			if (atlasPageCache == null)
			{
				Dictionary<Texture, AtlasPage> dictionary2 = new Dictionary<Texture, AtlasPage>();
				atlasPageCache = dictionary2;
				dictionary = atlasPageCache;
			}
			object value;
			bool flag = dictionary.TryGetValue(texture, out *(AtlasPage*)(&value));
			bool flag2 = value == null;
			bool flag3 = !flag2;
			AtlasPage atlasPage = (AtlasPage)value;
			if (!flag3)
			{
				Material m = new Material(shader);
				atlasPage = m.ToSpineAtlasPage();
				atlasPageCache[texture] = atlasPage;
			}
			return atlasPage;
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0x15172E4", Offset = "0x15172E4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.SpriteAttacher::Initialize(this, 0);\n\tv9 = ~this.attachOnStart;\n\tif (v9) goto L_0016;\n\tv11 = this.spineSlot == 0;\n\tif (v11) goto L_0016;\n\tSpine.Slot::set_Attachment(this.spineSlot, this.attachment);\n\treturn;\nL_0016:\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Initialize(overwrite: false);
			if (attachOnStart && spineSlot != null)
			{
				spineSlot.Attachment = attachment;
			}
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0x1517794", Offset = "0x1517794", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = ~this.overrideAnimation;\n\tif (v6) goto L_0019;\n\tv9 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv16 = v9 == 0;\n\tif (v16) goto L_0019;\n\tv17 = this.spineSlot == 0;\n\tif (v17) goto L_0019;\n\tSpine.Slot::set_Attachment(this.spineSlot, this.attachment);\n\treturn;\nL_0019:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AnimationOverrideSpriteAttach(ISkeletonAnimation animated)
		{
			if (overrideAnimation && base.isActiveAndEnabled && spineSlot != null)
			{
				spineSlot.Attachment = attachment;
			}
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0x151731C", Offset = "0x151731C", Length = "0x45C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv52 = Spine.Unity.ISkeletonAnimation;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv67 = Spine.Unity.ISkeletonComponent;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv154 = UnityEngine.Object;\n\tv155 = \"il2cpp_codegen_initialize_runtime_metadata\"(v154, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv243 = Spine.Unity.SkeletonGraphic;\n\tv244 = \"il2cpp_codegen_initialize_runtime_metadata\"(v243, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv281 = Spine.Unity.SkeletonRenderer;\n\tv282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv290 = Il2CppMethodInfo;\n\tv291 = \"il2cpp_codegen_initialize_runtime_metadata\"(v290, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv295 = Spine.Unity.UpdateBonesDelegate;\n\tv296 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv300 = \"Spine/Skeleton\";\n\tv301 = \"il2cpp_codegen_initialize_runtime_metadata\"(v300, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv404 = \"Sprites/Default\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v404, overwrite, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37A73]) = v47;\nL_0033:\n\tv49 = overwrite == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0040;\n\tv55 = this.attachment == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_01BB;\nL_0040:\n\tv65 = UnityEngine.Component::GetComponent(this);\n\tv152 = v65 == 0;\n\tif (v152) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006D;\n\tv258 = v258_asT == 0;\n\tif (v258) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tgoto L_0072;\n\tv283 = \"il2cpp_codegen_runtime_class_init\"(v276, v63, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0072:\n\tv288 = UnityEngine.Object::op_Inequality(v273, 0);\n\tv293 = v288 == 0;\n\tif (v293) goto L_007A;\n\tv422 = v273 + 0x56;\n\tgoto L_00B5;\nL_007A:\n\tv298 = v65 == 0;\n\tif (v298) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A5;\n\tv439 = v439_asT == 0;\n\tif (v439) goto L_FFFFFFFF;\n\tgoto L_00A5;\nL_00A5:\n\tgoto L_00AA;\n\tv467 = \"il2cpp_codegen_runtime_class_init\"(v443, v286, v287, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00AA:\n\tv355 = UnityEngine.Object::op_Inequality(v372, 0);\n\tv462 = v355 == 0;\n\tif (v462) goto L_00B7;\n\tv422 = *([v372 @ X21_v14 (UnityEngine.Object)+180]) + 0x18;\nL_00B5:\n\tthis.applyPMA = *([v422 @ X8_v33]);\nL_00B7:\n\tv466 = ~this.overrideAnimation;\n\tif (v466) goto L_012E;\n\t// 189 IsInst v474 @ X0_v37 (Spine.Unity.ISkeletonAnimation), typeof(Spine.Unity.ISkeletonAnimation), v65 @ X0_v4 (Spine.Unity.ISkeletonComponent)\n\tv497 = v474 == 0;\n\tif (v497) goto L_012E;\n\tv506 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v506, this, Il2CppMethodInfo);\n\tgoto L_00F8;\n\tv598 = *([v570 @ X8_v25+B0]);\n\tv599 = v598 + 8;\n\tv621 = *([v649 @ X10_v26-8]);\n\tv656 = v621 == v571;\n\tif (v656) goto L_00EF;\n\tv623 = v651 - 1;\n\tv619 = v649 + 0x10;\n\tv601 = v651 != 1;\n\tif (v601) goto L_FFFFFFFF;\n\tv624 = 5;\n\tv625 = v500;\n\tv626 = 0xB349B4(v625, v571, v624, v536, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00F8;\nL_00EF:\n\tv667 = *([v649 @ X10_v26]);\n\tv668 = v667 + 5;\n\tv669 = v668 << 4;\n\tv670 = v570 + v669;\n\tv671 = v670 + 0x138;\nL_00F8:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateComplete(v474, v506);\n\tv694 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v694, this, Il2CppMethodInfo);\n\tgoto L_012C;\n\tv718 = *([v714 @ X8_v28+B0]);\n\tv719 = v718 + 8;\n\tv741 = *([v759 @ X10_v21-8]);\n\tv766 = v741 == v715;\n\tif (v766) goto L_0123;\n\tv743 = v761 - 1;\n\tv739 = v759 + 0x10;\n\tv721 = v761 != 1;\n\tif (v721) goto L_FFFFFFFF;\n\tv744 = 4;\n\tv745 = v500;\n\tv746 = 0xB349B4(v745, v715, v744, v477, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_012C;\nL_0123:\n\tv774 = *([v759 @ X10_v21]);\n\tv775 = v774 + 4;\n\tv776 = v775 << 4;\n\tv777 = v714 + v776;\n\tv778 = v777 + 0x138;\nL_012C:\n\tSpine.Unity.ISkeletonAnimation::add_UpdateComplete(v474, v694);\nL_012E:\n\tv501 = this.spineSlot == 0;\n\tif (v501) goto L_013A;\n\tgoto L_017A;\nL_013A:\n\tgoto L_0161;\n\tv541 = *([v529 @ X8_v21+B0]);\n\tv542 = v541 + 8;\n\tv564 = *([v586 @ X10_v14-8]);\n\tv593 = v564 == v532;\n\tif (v593) goto L_0159;\n\tv566 = v588 - 1;\n\tv562 = v586 + 0x10;\n\tv544 = v588 != 1;\n\tif (v544) goto L_FFFFFFFF;\n\tv567 = 1;\n\tv568 = v151;\n\tv569 = 0xB349B4(v568, v532, v567, v305, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0161;\nL_0159:\n\tv632 = *([v586 @ X10_v14]);\n\tv633 = v632 + 1;\n\tv634 = v633 << 4;\n\tv635 = v529 + v634;\n\tv636 = v635 + 0x138;\nL_0161:\n\tv359 = Spine.Unity.ISkeletonComponent::get_Skeleton(v65);\n\tv519 = Spine.Skeleton::FindSlot(v359, this.slot);\nL_017A:\n\tthis.spineSlot = v519;\n\tif (this.applyPMA) goto L_FFFFFFFF;\n\tgoto L_0183;\nL_0183:\n\tv576 = UnityEngine.Shader::Find(*([v574 @ X8_v14 (System.String)]));\n\tgoto L_0190;\n\tv661 = v627;\n\tv662 = \"il2cpp_codegen_runtime_class_init\"(v661, v527, v507, v305, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0190:\n\tv665 = UnityEngine.Object::op_Equality(this.sprite, 0);\n\tv697 = v665 == 0;\n\tv698 = ~v697;\n\tif (v698) goto L_01B0;\n\tv701 = ~this.applyPMA;\n\tif (v701) goto L_01A8;\n\tv133 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachmentPMAClone(this.sprite, v576, 4, 0, 0, 0f);\n\tgoto L_01B0;\nL_01A8:\n\tv749 = UnityEngine.Sprite::get_texture(this.sprite);\n\tv772 = Spine.Unity.Examples.SpriteAttacher::GetPageFor(v749, v576);\n\tv133 = Spine.Unity.AttachmentTools.AttachmentRegionExtensions::ToRegionAttachment(this.sprite, v772, 0f);\nL_01B0:\n\tthis.attachment = v133;\nL_01BB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 293 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(bool overwrite = true)
		{
			//IL_00e0: Expected O, but got I
			//IL_0348: Expected I4, but got O
			//IL_0193: Expected O, but got I
			if (!overwrite && attachment != null)
			{
				return;
			}
			ISkeletonComponent component = GetComponent<ISkeletonComponent>();
			Object obj;
			if (component == null)
			{
				obj = null;
			}
			else
			{
				SkeletonRenderer skeletonRenderer = component as SkeletonRenderer;
				obj = (Object)(((object)skeletonRenderer == null) ? null : component);
			}
			object obj2;
			if (obj != null)
			{
				obj2 = (nint)obj + 86;
			}
			else
			{
				Object obj3;
				if (component == null)
				{
					obj3 = null;
				}
				else
				{
					SkeletonGraphic skeletonGraphic = component as SkeletonGraphic;
					obj3 = (Object)(((object)skeletonGraphic == null) ? null : component);
				}
				if (!(obj3 != null))
				{
					goto IL_0352;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ X21_v14 (UnityEngine.Object)+180]");
				obj2 = (nint)0 + (nint)24;
			}
			applyPMA = (byte)(int)obj2 != 0;
			goto IL_0352;
			IL_0352:
			if (overrideAnimation)
			{
				ISkeletonAnimation skeletonAnimation = component as ISkeletonAnimation;
				if (skeletonAnimation != null)
				{
					UpdateBonesDelegate value = AnimationOverrideSpriteAttach;
					skeletonAnimation.UpdateComplete -= value;
					UpdateBonesDelegate value2 = AnimationOverrideSpriteAttach;
					skeletonAnimation.UpdateComplete += value2;
				}
			}
			Slot slot;
			if (spineSlot != null)
			{
				slot = spineSlot;
			}
			else
			{
				Skeleton skeleton = component.Skeleton;
				slot = skeleton.FindSlot(this.slot);
			}
			spineSlot = slot;
			string text = (applyPMA ? "Spine/Skeleton" : "Sprites/Default");
			Shader shader = Shader.Find(text);
			bool flag = sprite == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			RegionAttachment regionAttachment = null;
			if (!flag3)
			{
				if (applyPMA)
				{
					regionAttachment = sprite.ToRegionAttachmentPMAClone(shader);
				}
				else
				{
					Texture2D texture = sprite.texture;
					AtlasPage pageFor = GetPageFor(texture, shader);
					regionAttachment = sprite.ToRegionAttachment(pageFor);
				}
			}
			attachment = regionAttachment;
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0x15177D0", Offset = "0x15177D0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Spine.Unity.ISkeletonAnimation;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv66 = Spine.Unity.UpdateBonesDelegate;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A74]) = v40;\nL_001F:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tv47 = v43 == 0;\n\tif (v47) goto L_0059;\n\tv59 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v59, this, Il2CppMethodInfo);\n\tgoto L_0069;\n\tv135 = *([v132 @ X8_v5+B0]);\n\tv136 = v135 + 8;\n\tv138 = *([v174 @ X10_v5-8]);\n\tv180 = v138 == v133;\n\tif (v180) goto L_005A;\n\tv160 = v175 - 1;\n\tv158 = v174 + 0x10;\n\tv140 = v175 != 1;\n\tif (v140) goto L_FFFFFFFF;\n\tv161 = 5;\n\tv162 = v53;\n\tv163 = 0xB349B4(v162, v133, v161, v69, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0069;\nL_0059:\n\treturn;\nL_005A:\n\tv186 = *([v174 @ X10_v5]);\n\tv187 = v186 + 5;\n\tv188 = v187 << 4;\n\tv189 = v132 + v188;\n\tv190 = v189 + 0x138;\nL_0069:\n\tSpine.Unity.ISkeletonAnimation::remove_UpdateComplete(v43, v59);\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			ISkeletonAnimation component = GetComponent<ISkeletonAnimation>();
			if (component != null)
			{
				UpdateBonesDelegate value = AnimationOverrideSpriteAttach;
				component.UpdateComplete -= value;
			}
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x1517778", Offset = "0x1517778", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.spineSlot == 0;\n\tif (v3) goto L_0008;\n\tSpine.Slot::set_Attachment(this.spineSlot, this.attachment);\n\treturn;\nL_0008:\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Attach()
		{
			if (spineSlot != null)
			{
				spineSlot.Attachment = attachment;
			}
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x15178F0", Offset = "0x15178F0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.attachOnStart = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpriteAttacher()
		{
			attachOnStart = true;
			overrideAnimation = true;
		}
	}
}
