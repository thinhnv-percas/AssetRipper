using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759208", Offset = "0x759208")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759208", Offset = "0x759208")]
	[Token(Token = "0x200027A")]
	public class SetMaterialTexture : ComponentAction<Renderer>
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7A64", Offset = "0x7B7A64")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B7A64", Offset = "0x7B7A64")]
		[Token(Token = "0x4001691")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7AEC", Offset = "0x7B7AEC")]
		[Token(Token = "0x4001692")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7B24", Offset = "0x7B7B24")]
		[Token(Token = "0x4001693")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial material;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B7B5C", Offset = "0x7B7B5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7B5C", Offset = "0x7B7B5C")]
		[Token(Token = "0x4001694")]
		[FieldOffset(Offset = "0x78")]
		public FsmString namedTexture;

		[Token(Token = "0x4001695")]
		[FieldOffset(Offset = "0x80")]
		public FsmTexture texture;

		[Token(Token = "0x6000C58")]
		[Address(RVA = "0x997948", Offset = "0x997948", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EFBAC8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202177E]) = v38;\nL_0015:\n\tthis.gameObject = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v41;\n\tthis.material = 0;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"_MainTex\");\n\tthis.namedTexture = v46;\n\tthis.texture = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			material = null;
			FsmString fsmString = "_MainTex";
			namedTexture = fsmString;
			texture = null;
		}

		[Token(Token = "0x6000C59")]
		[Address(RVA = "0x9979B4", Offset = "0x9979B4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetMaterialTexture::DoSetMaterialTexture(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetMaterialTexture();
			Finish();
		}

		[Token(Token = "0x6000C5A")]
		[Address(RVA = "0x9979DC", Offset = "0x9979DC", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EB4A88]);\n\tv25 = *([v24 @ X8_v26]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202177F]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.namedTexture);\n\tv160 = System.String::op_Equality(v48, \"\");\n\tv104 = v160 == 0;\n\tv85 = ~v104;\n\tv82 = ~v85;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tv248 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\n\tgoto L_0047;\n\tv331 = *([v147 @ X8_v11+E0]);\n\tv332 = v331 == 0;\n\tv333 = ~v332;\n\tif (v333) goto L_0047;\n\tv339 = v147;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v339, v247, v157, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0047:\n\tv338 = UnityEngine.Object::op_Inequality(v248, 0);\n\tv341 = v338 == 0;\n\tif (v341) goto L_006C;\n\tv191 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\nL_0056:\n\tv192 = HutongGames.PlayMaker.FsmTexture::get_Value(this.texture);\n\tUnityEngine.Material::SetTexture(v191, v153, v192);\n\treturn;\nL_006C:\n\tv346 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetMaterialTexture)+30]), this.gameObject);\n\tv355 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v346);\n\tv358 = v355 == 0;\n\tif (v358) goto L_0108;\n\tv129 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv366 = UnityEngine.Renderer::get_material(v129);\n\tgoto L_008E;\n\tv370 = *([v149 @ X8_v15+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_008E;\n\tv378 = v149;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v378, v365, v115, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_008E:\n\tv377 = UnityEngine.Object::op_Equality(v366, 0);\n\tv307 = v377 == 0;\n\tif (v307) goto L_00A5;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing Material!\");\n\treturn;\nL_00A5:\n\tv382 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv131 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv350 = v382 == 0;\n\tif (v350) goto L_010A;\n\tv132 = UnityEngine.Renderer::get_materials(v131);\n\tv364 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv86 = v364 >= v132.Length;\n\tif (v86) goto L_0108;\n\tv134 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv193 = UnityEngine.Renderer::get_materials(v134);\n\tv194 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv387 = v194 < v193.Length;\n\tv101 = ~v387;\n\tif (v101) goto L_010F;\n\tv195 = HutongGames.PlayMaker.FsmTexture::get_Value(this.texture);\n\tUnityEngine.Material::SetTexture(v193[v194 @ X0_v41 (System.Int32)], v153, v195);\n\tv135 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v135, v193);\n\treturn;\nL_0108:\n\treturn;\nL_010A:\n\tv191 = UnityEngine.Renderer::get_material(v131);\n\tgoto L_0056;\n\tthrow System.NullReferenceException;\n\tv212 = new System.NullReferenceException();\nL_010F:\n\tv240 = new System.IndexOutOfRangeException();\n\tthrow v240;\n\treturn;\n// 203 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetMaterialTexture()
		{
			//IL_0109: Expected O, but got I
			string value = namedTexture.Value;
			string text = ((!(value == "")) ? value : "_MainTex");
			Material value2 = this.material.Value;
			Material value3;
			if (value2 != null)
			{
				value3 = this.material.Value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetMaterialTexture)+30]");
				GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
				if (!UpdateCache(ownerDefaultTarget))
				{
					return;
				}
				Renderer renderer = base.renderer;
				Material material = renderer.material;
				if (material == null)
				{
					LogError("Missing Material!");
					return;
				}
				int value4 = materialIndex.Value;
				Renderer renderer2 = base.renderer;
				if (value4 != 0)
				{
					Material[] materials = renderer2.materials;
					int value5 = materialIndex.Value;
					if (value5 < materials.Length)
					{
						Renderer renderer3 = base.renderer;
						Material[] materials2 = renderer3.materials;
						int value6 = materialIndex.Value;
						if (value6 >= materials2.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						Texture value7 = texture.Value;
						materials2[value6].SetTexture(text, value7);
						Renderer renderer4 = base.renderer;
						renderer4.materials = materials2;
					}
					return;
				}
				value3 = renderer2.material;
			}
			Texture value8 = texture.Value;
			value3.SetTexture(text, value8);
		}

		[Token(Token = "0x6000C5B")]
		[Address(RVA = "0x997CD0", Offset = "0x997CD0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFDD20]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021780]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetMaterialTexture()
		{
		}
	}
}
