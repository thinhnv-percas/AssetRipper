using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759078", Offset = "0x759078")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759078", Offset = "0x759078")]
	[Token(Token = "0x2000275")]
	public class GetMaterial : ComponentAction<Renderer>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B7308", Offset = "0x7B7308")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7308", Offset = "0x7B7308")]
		[Token(Token = "0x4001679")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B73A0", Offset = "0x7B73A0")]
		[Token(Token = "0x400167A")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B73D8", Offset = "0x7B73D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B73D8", Offset = "0x7B73D8")]
		[Token(Token = "0x400167B")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial material;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7438", Offset = "0x7B7438")]
		[Token(Token = "0x400167C")]
		[FieldOffset(Offset = "0x78")]
		public bool getSharedMaterial;

		[Token(Token = "0x6000C42")]
		[Address(RVA = "0xA2F844", Offset = "0xA2F844", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.material = 0;\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v12;\n\tthis.getSharedMaterial = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			material = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			getSharedMaterial = false;
		}

		[Token(Token = "0x6000C43")]
		[Address(RVA = "0xA2F87C", Offset = "0xA2F87C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetMaterial::DoGetMaterial(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetMaterial();
			Finish();
		}

		[Token(Token = "0x6000C44")]
		[Address(RVA = "0xA2F8A4", Offset = "0xA2F8A4", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1F0A098]);\n\tv23 = *([v22 @ X8_v31]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DE6]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.GetMaterial)+30]), this.gameObject);\n\tv177 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v47);\n\tv222 = v177 == 0;\n\tif (v222) goto L_00AF;\n\tv270 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv316 = v270 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_0033;\n\tv319 = ~this.getSharedMaterial;\n\tif (v319) goto L_00BF;\nL_0033:\n\tv324 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv325 = v324 == 0;\n\tif (v325) goto L_00B1;\nL_003A:\n\tv129 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv130 = UnityEngine.Renderer::get_materials(v129);\n\tv340 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv57 = v340 >= v130.Length;\n\tif (v57) goto L_0058;\n\tv343 = ~this.getSharedMaterial;\n\tif (v343) goto L_00D8;\nL_0058:\n\tv132 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv133 = UnityEngine.Renderer::get_materials(v132);\n\tv255 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv58 = v255 >= v133.Length;\n\tif (v58) goto L_00AF;\n\tv257 = ~this.getSharedMaterial;\n\tif (v257) goto L_00AF;\n\tv135 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv198 = UnityEngine.Renderer::get_sharedMaterials(v135);\n\tv199 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv355 = v199 < v198.Length;\n\tv105 = ~v355;\n\tif (v105) goto L_010D;\n\tHutongGames.PlayMaker.FsmMaterial::set_Value(this.material, v198[v199 @ X0_v38 (System.Int32)]);\n\tv136 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_sharedMaterials(v136, v198);\n\treturn;\nL_00AF:\n\treturn;\nL_00B1:\n\tv329 = ~this.getSharedMaterial;\n\tif (v329) goto L_003A;\n\tv218 = this.material;\n\tv137 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv200 = UnityEngine.Renderer::get_sharedMaterial(v137);\n\tgoto L_00D4;\nL_00BF:\n\tv218 = this.material;\n\tv138 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv200 = UnityEngine.Renderer::get_material(v138);\nL_00D4:\n\tHutongGames.PlayMaker.FsmMaterial::set_Value(v218, v200);\n\treturn;\nL_00D8:\n\tv139 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv201 = UnityEngine.Renderer::get_materials(v139);\n\tv202 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv349 = v202 < v201.Length;\n\tv106 = ~v349;\n\tif (v106) goto L_010D;\n\tHutongGames.PlayMaker.FsmMaterial::set_Value(this.material, v201[v202 @ X0_v46 (System.Int32)]);\n\tv140 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v140, v201);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv220 = new System.NullReferenceException();\nL_010D:\n\tv241 = new System.IndexOutOfRangeException();\n\tthrow v241;\n\treturn;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetMaterial()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GetMaterial)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!UpdateCache(ownerDefaultTarget))
			{
				return;
			}
			FsmMaterial fsmMaterial;
			Material sharedMaterial;
			if (materialIndex.Value != 0 || getSharedMaterial)
			{
				if (materialIndex.Value != 0 || !getSharedMaterial)
				{
					Renderer renderer = base.renderer;
					Material[] materials = renderer.materials;
					int value = materialIndex.Value;
					if (value >= materials.Length || getSharedMaterial)
					{
						Renderer renderer2 = base.renderer;
						Material[] materials2 = renderer2.materials;
						int value2 = materialIndex.Value;
						if (value2 >= materials2.Length || !getSharedMaterial)
						{
							return;
						}
						Renderer renderer3 = base.renderer;
						Material[] sharedMaterials = renderer3.sharedMaterials;
						int value3 = materialIndex.Value;
						if (value3 < sharedMaterials.Length)
						{
							material.Value = sharedMaterials[value3];
							Renderer renderer4 = base.renderer;
							renderer4.sharedMaterials = sharedMaterials;
							return;
						}
					}
					else
					{
						Renderer renderer5 = base.renderer;
						Material[] materials3 = renderer5.materials;
						int value4 = materialIndex.Value;
						if (value4 < materials3.Length)
						{
							material.Value = materials3[value4];
							Renderer renderer6 = base.renderer;
							renderer6.materials = materials3;
							return;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				fsmMaterial = material;
				Renderer renderer7 = base.renderer;
				sharedMaterial = renderer7.sharedMaterial;
			}
			else
			{
				fsmMaterial = material;
				Renderer renderer8 = base.renderer;
				sharedMaterial = renderer8.material;
			}
			fsmMaterial.Value = sharedMaterial;
		}

		[Token(Token = "0x6000C45")]
		[Address(RVA = "0xA2FB74", Offset = "0xA2FB74", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC71C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DE7]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetMaterial()
		{
		}
	}
}
