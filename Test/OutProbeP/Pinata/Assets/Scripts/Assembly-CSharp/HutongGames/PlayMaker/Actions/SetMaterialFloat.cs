using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7591B8", Offset = "0x7591B8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7591B8", Offset = "0x7591B8")]
	[Token(Token = "0x2000279")]
	public class SetMaterialFloat : ComponentAction<Renderer>
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B789C", Offset = "0x7B789C")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B789C", Offset = "0x7B789C")]
		[Token(Token = "0x400168B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7924", Offset = "0x7B7924")]
		[Token(Token = "0x400168C")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B795C", Offset = "0x7B795C")]
		[Token(Token = "0x400168D")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial material;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7994", Offset = "0x7B7994")]
		[Token(Token = "0x400168E")]
		[FieldOffset(Offset = "0x78")]
		public FsmString namedFloat;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B79E0", Offset = "0x7B79E0")]
		[Token(Token = "0x400168F")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat floatValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7A2C", Offset = "0x7B7A2C")]
		[Token(Token = "0x4001690")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x6000C53")]
		[Address(RVA = "0x99755C", Offset = "0x99755C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ECFE98]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202177B]) = v38;\nL_0015:\n\tthis.gameObject = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v41;\n\tthis.material = 0;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.namedFloat = v46;\n\tv49 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.floatValue = v49;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			material = null;
			FsmString fsmString = "";
			namedFloat = fsmString;
			FsmFloat fsmFloat = 0f;
			floatValue = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000C54")]
		[Address(RVA = "0x9975DC", Offset = "0x9975DC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetMaterialFloat::DoSetMaterialFloat(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetMaterialFloat();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C55")]
		[Address(RVA = "0x9978F4", Offset = "0x9978F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetMaterialFloat::DoSetMaterialFloat(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetMaterialFloat();
		}

		[Token(Token = "0x6000C56")]
		[Address(RVA = "0x997618", Offset = "0x997618", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1ED1790]);\n\tv25 = *([v24 @ X8_v23]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202177C]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\n\tgoto L_002C;\n\tv207 = *([v135 @ X8_v6+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_002C;\n\tv239 = v135;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v239, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv214 = UnityEngine.Object::op_Inequality(v48, 0);\n\tv241 = v214 == 0;\n\tif (v241) goto L_0057;\n\tv180 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\nL_003B:\n\tv181 = HutongGames.PlayMaker.FsmString::get_Value(this.namedFloat);\n\tv165 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tUnityEngine.Material::SetFloat(v180, v181, v165);\n\treturn;\nL_0057:\n\tv249 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetMaterialFloat)+30]), this.gameObject);\n\tv336 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v249);\n\tv339 = v336 == 0;\n\tif (v339) goto L_00F9;\n\tv117 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv347 = UnityEngine.Renderer::get_material(v117);\n\tgoto L_0079;\n\tv351 = *([v137 @ X8_v10+E0]);\n\tv352 = v351 == 0;\n\tv353 = ~v352;\n\tif (v353) goto L_0079;\n\tv359 = v137;\n\tv355 = \"il2cpp_codegen_runtime_class_init\"(v359, v346, v95, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0079:\n\tv358 = UnityEngine.Object::op_Equality(v347, 0);\n\tv307 = v358 == 0;\n\tif (v307) goto L_0090;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing Material!\");\n\treturn;\nL_0090:\n\tv363 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv119 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv330 = v363 == 0;\n\tif (v330) goto L_00FB;\n\tv120 = UnityEngine.Renderer::get_materials(v119);\n\tv344 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv54 = v344 >= v120.Length;\n\tif (v54) goto L_00F9;\n\tv122 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv183 = UnityEngine.Renderer::get_materials(v122);\n\tv184 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv368 = v184 < v183.Length;\n\tv86 = ~v368;\n\tif (v86) goto L_0100;\n\tv185 = HutongGames.PlayMaker.FsmString::get_Value(this.namedFloat);\n\tv92 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatValue);\n\tUnityEngine.Material::SetFloat(v183[v184 @ X0_v38 (System.Int32)], v185, v92);\n\tv123 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v123, v183);\n\treturn;\nL_00F9:\n\treturn;\nL_00FB:\n\tv180 = UnityEngine.Renderer::get_material(v119);\n\tgoto L_003B;\n\tthrow System.NullReferenceException;\n\tv206 = new System.NullReferenceException();\nL_0100:\n\tv238 = new System.IndexOutOfRangeException();\n\tthrow v238;\n\treturn;\n// 193 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetMaterialFloat()
		{
			//IL_00a9: Expected O, but got I
			Material value = this.material.Value;
			Material value2;
			if (value != null)
			{
				value2 = this.material.Value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetMaterialFloat)+30]");
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
				int value3 = materialIndex.Value;
				Renderer renderer2 = base.renderer;
				if (value3 != 0)
				{
					Material[] materials = renderer2.materials;
					int value4 = materialIndex.Value;
					if (value4 < materials.Length)
					{
						Renderer renderer3 = base.renderer;
						Material[] materials2 = renderer3.materials;
						int value5 = materialIndex.Value;
						if (value5 >= materials2.Length)
						{
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						string value6 = namedFloat.Value;
						float value7 = floatValue.Value;
						materials2[value5].SetFloat(value6, value7);
						Renderer renderer4 = base.renderer;
						renderer4.materials = materials2;
					}
					return;
				}
				value2 = renderer2.material;
			}
			string value8 = namedFloat.Value;
			float value9 = floatValue.Value;
			value2.SetFloat(value8, value9);
		}

		[Token(Token = "0x6000C57")]
		[Address(RVA = "0x9978F8", Offset = "0x9978F8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0C748]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202177D]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetMaterialFloat()
		{
		}
	}
}
