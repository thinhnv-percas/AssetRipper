using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;

namespace HighlightPlus
{
	[DefaultExecutionOrder(100)]
	[ExecuteInEditMode]
	[Token(Token = "0x200002A")]
	public class HighlightEffectBlocker : MonoBehaviour
	{
		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x20")]
		public BlockerTargetOptions include;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x24")]
		public LayerMask layerMask;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x28")]
		public string nameFilter;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x30")]
		public bool useRegEx;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x31")]
		public bool blockOutlineAndGlow;

		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x32")]
		public bool blockOverlay;

		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x38")]
		private List<Renderer> renderers;

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x7725A24", Offset = "0x7725A24", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B7951CD]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0024;\n\tHighlightPlus.HighlightEffectBlocker::Refresh(this);\n\tgoto L_001E;\nL_001E:\n\tHighlightPlus.HighlightPlusRenderPassFeature::RegisterBlocker(this);\n\treturn;\nL_0024:\n\t*([B7951CD]) = 1;\n\tHighlightPlus.HighlightEffectBlocker::Refresh(this);\n\tgoto L_001E;\n")]
		private void OnEnable()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951CD]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Refresh();
			}
			else
			{
				_ = 1;
				Refresh();
			}
			HighlightPlusRenderPassFeature.RegisterBlocker(this);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x7726094", Offset = "0x7726094", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_002C;\nL_002C:\n\tv113 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffectBlocker>::Remove(v85.outlineAndGlowOccluders, this);\n\treturn;\n")]
		private void OnDisable()
		{
			bool flag = HighlightPlusRenderPassFeature.outlineAndGlowOccluders.Remove(this);
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x7725AB4", Offset = "0x7725AB4", Length = "0x490")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v57);\n\tv75 = v57.Count < 1;\n\tif (v75) goto L_0055;\nL_0055:\n\tv133 = this.include;\n\tv94 = this.include == 2;\n\tif (v94) goto L_009F;\nL_0064:\n\tv139 = v133 == 1;\n\tif (v139) goto L_0112;\n\tv170 = v133 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0115;\n\tv187 = UnityEngine.Component::GetComponent(this);\n\tgoto L_007C;\nL_007C:\n\tv393 = UnityEngine.Object::op_Inequality(v187, 0);\n\tv548 = ~v393;\n\tv447 = ~v548;\n\tif (v447) goto L_0180;\n\tgoto L_01BB;\nL_0084:\n\tv79 = new System.Collections.Generic.List`1<UnityEngine.Renderer>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::.ctor(v79);\n\tthis.renderers = v79;\n\tv133 = this.include;\n\tv111 = this.include != 2;\n\tif (v111) goto L_0064;\nL_009F:\n\tv165 = UnityEngine.Component::GetComponentsInChildren(this, 1);\n\tv215 = v165.Length < 1;\n\tif (v215) goto L_0115;\n\tv277 = 0;\n\tgoto L_00CD;\nL_00BB:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Add(v343, v165[v277 @ X24_v8 (System.Int32)]);\nL_00BC:\n\tv277 = v277 + 1;\n\tv216 = v277 >= v165.Length;\n\tif (v216) goto L_0115;\nL_00CD:\n\tgoto L_00D1;\nL_00D1:\n\tv554 = UnityEngine.Object::op_Inequality(v165[v277 @ X24_v8 (System.Int32)], 0);\n\tv564 = ~v554;\n\tif (v564) goto L_00BC;\n\tgoto L_00E0;\nL_00E0:\n\tv342 = UnityEngine.Component::get_gameObject(v165[v277 @ X24_v8 (System.Int32)]);\n\tv618 = UnityEngine.GameObject::get_layer(v342);\n\tv600 = UnityEngine.LayerMask::op_Implicit(this.layerMask);\n\tv363 = v600 >> v618;\n\tv633 = v363 & 1;\n\tv603 = v633 == 0;\n\tif (v603) goto L_00BC;\n\tv343 = this.renderers;\n\tgoto L_00BB;\nL_0112:\n\tUnityEngine.Component::GetComponentsInChildren(this, 1, this.renderers);\nL_0115:\n\tv254 = System.String::IsNullOrEmpty(this.nameFilter);\n\tv382 = v254 == 0;\n\tv383 = ~v382;\n\tif (v383) goto L_01BB;\n\tv365 = this.renderers;\n\tv281 = v365.Count;\n\tv430 = v365.Count < 1;\n\tif (v430) goto L_01BB;\n\tgoto L_0145;\nL_0134:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::RemoveAt(this.renderers, v281);\nL_0140:\n\tv413 = v281 <= 0;\n\tif (v413) goto L_01BB;\nL_0145:\n\tv281 = v281 - 1;\n\tv346 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.renderers, v281);\n\tv347 = UnityEngine.Object::get_name(v346);\n\tv294 = this.useRegEx != 1;\n\tif (v294) goto L_0169;\n\tgoto L_0160;\nL_0160:\n\tv626 = System.Text.RegularExpressions.Regex::IsMatch(v347, this.nameFilter);\n\tv635 = v626 == 0;\n\tif (v635) goto L_0134;\n\tgoto L_0140;\nL_0169:\n\tv632 = System.String::Contains(v347, this.nameFilter);\n\tv641 = v632 == 0;\n\tif (v641) goto L_0134;\n\tgoto L_0140;\nL_0180:\n\tv348 = this.renderers;\n\tgoto L_01CD;\nL_01BB:\n\treturn;\nL_01CD:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Add(v348, v187);\n\treturn;\nL_003D:\n\tv57 = this.renderers;\n\tv58 = this.renderers == 0;\n\tif (v58) goto L_0084;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Refresh()
		{
			List<Renderer> list = renderers;
			BlockerTargetOptions blockerTargetOptions;
			if (renderers != null)
			{
				list.Clear();
				if (list.Count >= 1)
				{
				}
				blockerTargetOptions = include;
				if (include != BlockerTargetOptions.LayerInChildren)
				{
					goto IL_0061;
				}
			}
			else
			{
				List<Renderer> list2 = new List<Renderer>();
				renderers = list2;
				blockerTargetOptions = include;
				if (include != BlockerTargetOptions.LayerInChildren)
				{
					goto IL_0061;
				}
			}
			Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>(includeInactive: true);
			if (componentsInChildren.Length >= 1)
			{
				int num = 0;
				do
				{
					if (componentsInChildren[num] != null)
					{
						GameObject gameObject = componentsInChildren[num].gameObject;
						int layer = gameObject.layer;
						int num2 = layerMask;
						int num3 = num2 >> layer;
						if ((num3 & 1) != 0)
						{
							List<Renderer> list3 = renderers;
							list3.Add(componentsInChildren[num]);
						}
					}
					num++;
				}
				while (num < componentsInChildren.Length);
			}
			goto IL_029f;
			IL_0061:
			switch (blockerTargetOptions)
			{
			case BlockerTargetOptions.OnlyThisObject:
			{
				Renderer component = GetComponent<Renderer>();
				if (component != null)
				{
					List<Renderer> list4 = renderers;
					list4.Add(component);
				}
				return;
			}
			case BlockerTargetOptions.Children:
				GetComponentsInChildren(includeInactive: true, renderers);
				break;
			}
			goto IL_029f;
			IL_029f:
			if (string.IsNullOrEmpty(nameFilter))
			{
				return;
			}
			List<Renderer> list5 = renderers;
			int num4 = list5.Count;
			if (list5.Count < 1)
			{
				return;
			}
			do
			{
				num4--;
				UnityEngine.Object obj = renderers[num4];
				string text = obj.name;
				if (useRegEx)
				{
					if (!Regex.IsMatch(text, nameFilter))
					{
						goto IL_0319;
					}
				}
				else if (!text.Contains(nameFilter))
				{
					goto IL_0319;
				}
				continue;
				IL_0319:
				renderers.RemoveAt(num4);
			}
			while (num4 > 0);
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x7726224", Offset = "0x7726224", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv73 = v57.Count < 1;\n\tif (v73) goto L_00F7;\n\tv186 = cmd == 0;\n\tif (v186) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv212 = 0;\n\tgoto L_004A;\nL_003A:\n\tv212 = v212 + 1;\n\tv131 = v212 == v57.Count;\n\tif (v131) goto L_00F7;\nL_004A:\n\tv235 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.renderers, v212);\n\tgoto L_0053;\nL_0053:\n\tv278 = UnityEngine.Object::op_Equality(v235, 0);\n\tv286 = v278 == 0;\n\tv287 = ~v286;\n\tif (v287) goto L_003A;\n\tgoto L_0066;\nL_0066:\n\tv333 = UnityEngine.Renderer::get_enabled(v235);\n\tv337 = ~v333;\n\tif (v337) goto L_003A;\n\tv256 = UnityEngine.Component::get_gameObject(v235);\n\tv334 = UnityEngine.GameObject::get_activeInHierarchy(v256);\n\tv338 = ~v334;\n\tif (v338) goto L_003A;\n\tv257 = UnityEngine.Renderer::get_sharedMaterials(v235);\n\tv307 = v257.Length < 1;\n\tif (v307) goto L_003A;\nL_FFFFFFFF:\n\tv376 = 0;\n\tgoto L_003A;\nL_FFFFFFFF:\n\tv230 = 0;\n\tgoto L_00AE;\nL_009E:\n\tv230 = v230 + 1;\n\tv132 = v57.Count == v230;\n\tif (v132) goto L_00F7;\nL_00AE:\n\tv270 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.renderers, v230);\n\tgoto L_00B7;\nL_00B7:\n\tv283 = UnityEngine.Object::op_Equality(v270, 0);\n\tv293 = v283 == 0;\n\tv294 = ~v293;\n\tif (v294) goto L_009E;\n\tgoto L_00CA;\nL_00CA:\n\tv352 = UnityEngine.Renderer::get_enabled(v270);\n\tv355 = ~v352;\n\tif (v355) goto L_009E;\n\tv259 = UnityEngine.Component::get_gameObject(v270);\n\tv353 = UnityEngine.GameObject::get_activeInHierarchy(v259);\n\tv356 = ~v353;\n\tif (v356) goto L_009E;\n\tv254 = UnityEngine.Renderer::get_sharedMaterials(v270);\n\tv244 = v254.Length <= 0;\n\tif (v244) goto L_009E;\n\tthrow System.NullReferenceException;\nL_00F7:\n\treturn;\nL_0022:\n\tv57 = this.renderers;\n\tv58 = this.renderers == 0;\n\tif (v58) goto L_00F7;\nL_008A:\n\tUnityEngine.Rendering.CommandBuffer::DrawRenderer(cmd, v235, mat, v376);\n\tv376 = v376 + 1;\n\tv308 = v257.Length != v376;\n\tif (v308) goto L_008A;\n")]
		public void BuildCommandBuffer(CommandBuffer cmd, Material mat)
		{
			List<Renderer> list = renderers;
			if (renderers == null || list.Count < 1)
			{
				return;
			}
			if (cmd != null)
			{
				int num = 0;
				do
				{
					UnityEngine.Object obj = renderers[num];
					if (!(obj == null) && ((Renderer)obj).enabled)
					{
						GameObject gameObject = ((Component)obj).gameObject;
						if (gameObject.activeInHierarchy)
						{
							Material[] sharedMaterials = ((Renderer)obj).sharedMaterials;
							if (sharedMaterials.Length >= 1)
							{
								int num2 = 0;
								do
								{
									cmd.DrawRenderer((Renderer)obj, mat, num2);
									num2++;
								}
								while (sharedMaterials.Length != num2);
							}
						}
					}
					num++;
				}
				while (num != list.Count);
				return;
			}
			int num3 = 0;
			do
			{
				UnityEngine.Object obj2 = renderers[num3];
				if (!(obj2 == null) && ((Renderer)obj2).enabled)
				{
					GameObject gameObject2 = ((Component)obj2).gameObject;
					if (gameObject2.activeInHierarchy)
					{
						Material[] sharedMaterials2 = ((Renderer)obj2).sharedMaterials;
						if (sharedMaterials2.Length > 0)
						{
							throw new NullReferenceException();
						}
					}
				}
				num3++;
			}
			while (list.Count != num3);
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x7726470", Offset = "0x7726470", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.layerMask = v14;\n\tthis.blockOutlineAndGlow = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HighlightEffectBlocker()
		{
			LayerMask layerMask = -1;
			this.layerMask = layerMask;
			blockOutlineAndGlow = true;
			blockOverlay = true;
		}
	}
}
