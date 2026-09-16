using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7590C8", Offset = "0x7590C8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7590C8", Offset = "0x7590C8")]
	[Token(Token = "0x2000276")]
	public class GetMaterialTexture : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B7470", Offset = "0x7B7470")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7470", Offset = "0x7B7470")]
		[Token(Token = "0x400167D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7508", Offset = "0x7B7508")]
		[Token(Token = "0x400167E")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B7540", Offset = "0x7B7540")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7540", Offset = "0x7B7540")]
		[Token(Token = "0x400167F")]
		[FieldOffset(Offset = "0x70")]
		public FsmString namedTexture;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B7590", Offset = "0x7B7590")]
		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x7B7590", Offset = "0x7B7590")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7590", Offset = "0x7B7590")]
		[Token(Token = "0x4001680")]
		[FieldOffset(Offset = "0x78")]
		public FsmTexture storedTexture;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7614", Offset = "0x7B7614")]
		[Token(Token = "0x4001681")]
		[FieldOffset(Offset = "0x80")]
		public bool getFromSharedMaterial;

		[Token(Token = "0x6000C46")]
		[Address(RVA = "0xA2FBC4", Offset = "0xA2FBC4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0A430]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DE8]) = v38;\nL_0015:\n\tthis.gameObject = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v41;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"_MainTex\");\n\tthis.namedTexture = v46;\n\tthis.storedTexture = 0;\n\tthis.getFromSharedMaterial = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			FsmString fsmString = "_MainTex";
			namedTexture = fsmString;
			storedTexture = null;
			getFromSharedMaterial = false;
		}

		[Token(Token = "0x6000C47")]
		[Address(RVA = "0xA2FC34", Offset = "0xA2FC34", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMaterialTexture::DoGetMaterialTexture(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetMaterialTexture();
			Finish();
		}

		[Token(Token = "0x6000C48")]
		[Address(RVA = "0xA2FC5C", Offset = "0xA2FC5C", Length = "0x31C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EA7C10]);\n\tv27 = *([v26 @ X8_v34]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021DE9]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.GetMaterialTexture)+30]), this.gameObject);\n\tv201 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v51);\n\tv255 = v201 == 0;\n\tif (v255) goto L_00AB;\n\tv315 = HutongGames.PlayMaker.FsmString::get_Value(this.namedTexture);\n\tv240 = System.String::op_Equality(v315, \"\");\n\tv117 = v240 == 0;\n\tv96 = ~v117;\n\tv93 = ~v96;\n\tif (v93) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tv370 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_0050;\n\tv374 = ~this.getFromSharedMaterial;\n\tif (v374) goto L_00BE;\nL_0050:\n\tv379 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv380 = v379 == 0;\n\tif (v380) goto L_00AD;\nL_0057:\n\tv151 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv152 = UnityEngine.Renderer::get_materials(v151);\n\tv394 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv97 = v394 >= v152.Length;\n\tif (v97) goto L_0075;\n\tv397 = ~this.getFromSharedMaterial;\n\tif (v397) goto L_00DE;\nL_0075:\n\tv154 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv155 = UnityEngine.Renderer::get_materials(v154);\n\tv297 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv98 = v297 >= v155.Length;\n\tif (v98) goto L_00AB;\n\tv299 = ~this.getFromSharedMaterial;\n\tif (v299) goto L_00AB;\n\tv157 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv415 = UnityEngine.Renderer::get_sharedMaterials(v157);\n\tv60 = this.storedTexture;\n\tv158 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv237 = UnityEngine.Renderer::get_sharedMaterials(v158);\n\tgoto L_00F2;\nL_00AB:\n\treturn;\nL_00AD:\n\tv382 = ~this.getFromSharedMaterial;\n\tif (v382) goto L_0057;\n\tv214 = this.storedTexture;\n\tv159 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv389 = UnityEngine.Renderer::get_sharedMaterial(v159);\n\tv392 = v389 == 0;\n\tv179 = ~v392;\n\tif (v179) goto L_00CB;\n\tgoto L_0120;\nL_00BE:\n\tv214 = this.storedTexture;\n\tv161 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv389 = UnityEngine.Renderer::get_material(v161);\nL_00CB:\n\tv236 = UnityEngine.Material::GetTexture(v389, v197);\n\tHutongGames.PlayMaker.FsmTexture::set_Value(v214, v236);\n\treturn;\nL_00DE:\n\tv163 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv402 = UnityEngine.Renderer::get_materials(v163);\n\tv60 = this.storedTexture;\n\tv164 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv237 = UnityEngine.Renderer::get_materials(v164);\nL_00F2:\n\tv238 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv413 = v238 < v237.Length;\n\tv114 = ~v413;\n\tif (v114) goto L_0123;\n\tv239 = UnityEngine.Material::GetTexture(v237[v238 @ X0_v35 (System.Int32)], v197);\n\tHutongGames.PlayMaker.FsmTexture::set_Value(v60, v239);\n\tv166 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v166, v88);\n\treturn;\nL_0120:\n\tthrow System.NullReferenceException;\n\tv253 = new System.NullReferenceException();\nL_0123:\n\tv279 = new System.IndexOutOfRangeException();\n\tthrow v279;\n\treturn;\n// 215 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetMaterialTexture()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GetMaterialTexture)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			string value = namedTexture.Value;
			string text = ((!(value == "")) ? value : "_MainTex");
			FsmTexture fsmTexture2;
			Material material;
			if (materialIndex.Value != 0 || getFromSharedMaterial)
			{
				if (materialIndex.Value != 0 || !getFromSharedMaterial)
				{
					Renderer renderer = base.renderer;
					Material[] materials = renderer.materials;
					int value2 = materialIndex.Value;
					FsmTexture fsmTexture;
					Material[] array;
					Material[] materials3;
					if (value2 >= materials.Length || getFromSharedMaterial)
					{
						Renderer renderer2 = base.renderer;
						Material[] materials2 = renderer2.materials;
						int value3 = materialIndex.Value;
						if (value3 >= materials2.Length || !getFromSharedMaterial)
						{
							return;
						}
						Renderer renderer3 = base.renderer;
						Material[] sharedMaterials = renderer3.sharedMaterials;
						fsmTexture = storedTexture;
						Renderer renderer4 = base.renderer;
						array = renderer4.sharedMaterials;
						materials3 = sharedMaterials;
					}
					else
					{
						Renderer renderer5 = base.renderer;
						Material[] materials4 = renderer5.materials;
						fsmTexture = storedTexture;
						Renderer renderer6 = base.renderer;
						array = renderer6.materials;
						materials3 = materials4;
					}
					int value4 = materialIndex.Value;
					if (value4 < array.Length)
					{
						Texture texture = array[value4].GetTexture(text);
						fsmTexture.Value = texture;
						Renderer renderer7 = base.renderer;
						renderer7.materials = materials3;
						return;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				fsmTexture2 = storedTexture;
				Renderer renderer8 = base.renderer;
				material = renderer8.sharedMaterial;
				if ((object)material == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				fsmTexture2 = storedTexture;
				Renderer renderer9 = base.renderer;
				material = renderer9.material;
			}
			Texture texture2 = material.GetTexture(text);
			fsmTexture2.Value = texture2;
		}

		[Token(Token = "0x6000C49")]
		[Address(RVA = "0xA2FF78", Offset = "0xA2FF78", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE3E78]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DEA]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMaterialTexture()
		{
		}
	}
}
