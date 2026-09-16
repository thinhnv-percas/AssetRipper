using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759168", Offset = "0x759168")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759168", Offset = "0x759168")]
	[Token(Token = "0x2000278")]
	public class SetMaterialColor : ComponentAction<Renderer>
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B76D0", Offset = "0x7B76D0")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B76D0", Offset = "0x7B76D0")]
		[Token(Token = "0x4001685")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7758", Offset = "0x7B7758")]
		[Token(Token = "0x4001686")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt materialIndex;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7790", Offset = "0x7B7790")]
		[Token(Token = "0x4001687")]
		[FieldOffset(Offset = "0x70")]
		public FsmMaterial material;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B77C8", Offset = "0x7B77C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B77C8", Offset = "0x7B77C8")]
		[Token(Token = "0x4001688")]
		[FieldOffset(Offset = "0x78")]
		public FsmString namedColor;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7818", Offset = "0x7B7818")]
		[Token(Token = "0x4001689")]
		[FieldOffset(Offset = "0x80")]
		public FsmColor color;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B7864", Offset = "0x7B7864")]
		[Token(Token = "0x400168A")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x6000C4E")]
		[Address(RVA = "0x997154", Offset = "0x997154", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDF338]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021778]) = v38;\nL_0015:\n\tthis.gameObject = 0;\n\tv41 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.materialIndex = v41;\n\tthis.material = 0;\n\tv46 = HutongGames.PlayMaker.FsmString::op_Implicit(\"_Color\");\n\tthis.namedColor = v46;\n\tv48 = UnityEngine.Color::get_black();\n\tv54 = HutongGames.PlayMaker.FsmColor::op_Implicit(v48);\n\tthis.color = v54;\n\tthis.everyFrame = 0;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmInt fsmInt = 0;
			materialIndex = fsmInt;
			material = null;
			FsmString fsmString = "_Color";
			namedColor = fsmString;
			Color black = Color.black;
			FsmColor fsmColor = black;
			color = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x6000C4F")]
		[Address(RVA = "0x9971D8", Offset = "0x9971D8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetMaterialColor::DoSetMaterialColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetMaterialColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C50")]
		[Address(RVA = "0x997508", Offset = "0x997508", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetMaterialColor::DoSetMaterialColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetMaterialColor();
		}

		[Token(Token = "0x6000C51")]
		[Address(RVA = "0x997214", Offset = "0x997214", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EDD8B8]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021779]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.color);\n\tv177 = v48 == 0;\n\tif (v177) goto L_002B;\nL_0026:\n\treturn;\nL_002B:\n\tv355 = HutongGames.PlayMaker.FsmString::get_Value(this.namedColor);\n\tv207 = System.String::op_Equality(v355, \"\");\n\tv102 = v207 == 0;\n\tv83 = ~v102;\n\tv80 = ~v83;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_0046;\nL_0046:\n\tv366 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\n\tgoto L_0058;\n\tv371 = *([v167 @ X8_v11+E0]);\n\tv372 = v371 == 0;\n\tv373 = ~v372;\n\tif (v373) goto L_0058;\n\tv379 = v167;\n\tv375 = \"il2cpp_codegen_runtime_class_init\"(v379, v365, v197, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0058:\n\tv378 = UnityEngine.Object::op_Inequality(v366, 0);\n\tv381 = v378 == 0;\n\tif (v381) goto L_007C;\n\tv333 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.material);\n\tv344 = this.color;\nL_0074:\n\t// 116 MakeStruct v289 @ AGG997340_2_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v344.value (UnityEngine.Color), v344.value.g (System.Single), v344.value.b (System.Single), v344.value.a (System.Single)\n\tUnityEngine.Material::SetColor(v333, v174, v289);\n\treturn;\nL_007C:\n\tv384 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetMaterialColor)+30]), this.gameObject);\n\tv240 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::UpdateCache(this, v384);\n\tv243 = v240 == 0;\n\tif (v243) goto L_0026;\n\tv143 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv395 = UnityEngine.Renderer::get_material(v143);\n\tgoto L_009E;\n\tv399 = *([v170 @ X8_v14+E0]);\n\tv400 = v399 == 0;\n\tv401 = ~v400;\n\tif (v401) goto L_009E;\n\tv407 = v170;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v407, v394, v114, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_009E:\n\tv406 = UnityEngine.Object::op_Equality(v395, 0);\n\tv338 = v406 == 0;\n\tif (v338) goto L_00B5;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing Material!\");\n\treturn;\nL_00B5:\n\tv411 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv145 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv413 = v411 == 0;\n\tif (v413) goto L_0111;\n\tv146 = UnityEngine.Renderer::get_materials(v145);\n\tv241 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv85 = v241 >= v146.Length;\n\tif (v85) goto L_0026;\n\tv148 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tv205 = UnityEngine.Renderer::get_materials(v148);\n\tv206 = HutongGames.PlayMaker.FsmInt::get_Value(this.materialIndex);\n\tv418 = v206 < v205.Length;\n\tv100 = ~v418;\n\tif (v100) goto L_011B;\n\tv172 = this.color;\n\t// 253 MakeStruct v51 @ AGG9974A8_2_v4 (UnityEngine.Color), typeof(UnityEngine.Color), v172.value (UnityEngine.Color), v172.value.g (System.Single), v172.value.b (System.Single), v172.value.a (System.Single)\n\tUnityEngine.Material::SetColor(v205[v206 @ X0_v42 (System.Int32)], v174, v51);\n\tv150 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::get_renderer(this);\n\tUnityEngine.Renderer::set_materials(v150, v205);\n\treturn;\nL_0111:\n\tv333 = UnityEngine.Renderer::get_material(v145);\n\tv344 = this.color;\n\tv414 = v333 == 0;\n\tv152 = ~v414;\n\tif (v152) goto L_0074;\n\tthrow System.NullReferenceException;\n\tv220 = new System.NullReferenceException();\nL_011B:\n\tv280 = new System.IndexOutOfRangeException();\n\tthrow v280;\n\treturn;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetMaterialColor()
		{
			//IL_0188: Expected O, but got I
			if (color.IsNone)
			{
				return;
			}
			string value = namedColor.Value;
			string text = ((!(value == "")) ? value : "_Color");
			Material value2 = this.material.Value;
			Material value3;
			FsmColor fsmColor;
			if (value2 != null)
			{
				value3 = this.material.Value;
				fsmColor = color;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetMaterialColor)+30]");
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
						FsmColor fsmColor2 = color;
						Color value7 = default(Color);
						value7.r = fsmColor2.value.r;
						value7.g = fsmColor2.value.g;
						value7.b = fsmColor2.value.b;
						value7.a = fsmColor2.value.a;
						materials2[value6].SetColor(text, value7);
						Renderer renderer4 = base.renderer;
						renderer4.materials = materials2;
					}
					return;
				}
				value3 = renderer2.material;
				fsmColor = color;
				if ((object)value3 == null)
				{
					throw new NullReferenceException();
				}
			}
			Color value8 = default(Color);
			value8.r = fsmColor.value.r;
			value8.g = fsmColor.value.g;
			value8.b = fsmColor.value.b;
			value8.a = fsmColor.value.a;
			value3.SetColor(text, value8);
		}

		[Token(Token = "0x6000C52")]
		[Address(RVA = "0x99750C", Offset = "0x99750C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE5770]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202177A]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Renderer>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetMaterialColor()
		{
		}
	}
}
