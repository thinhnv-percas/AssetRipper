using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D354", Offset = "0x75D354")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D354", Offset = "0x75D354")]
	[Token(Token = "0x2000343")]
	public class EnableBehaviour : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8C60", Offset = "0x7C8C60")]
		[Token(Token = "0x4001ADD")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8CAC", Offset = "0x7C8CAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8CAC", Offset = "0x7C8CAC")]
		[Token(Token = "0x4001ADE")]
		[FieldOffset(Offset = "0x58")]
		public FsmString behaviour;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8CFC", Offset = "0x7C8CFC")]
		[Token(Token = "0x4001ADF")]
		[FieldOffset(Offset = "0x60")]
		public Component component;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8D34", Offset = "0x7C8D34")]
		[Token(Token = "0x4001AE0")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool enable;

		[Token(Token = "0x4001AE1")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001AE2")]
		[FieldOffset(Offset = "0x78")]
		private Behaviour componentTarget;

		[Token(Token = "0x6001057")]
		[Address(RVA = "0xB73D6C", Offset = "0xB73D6C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.behaviour = 0;\n\tthis.component = 0;\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.enable = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.resetOnExit = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			behaviour = null;
			component = null;
			gameObject = null;
			FsmBool fsmBool = true;
			enable = fsmBool;
			FsmBool fsmBool2 = true;
			resetOnExit = fsmBool2;
		}

		[Token(Token = "0x6001058")]
		[Address(RVA = "0xB73DB0", Offset = "0xB73DB0", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tHutongGames.PlayMaker.Actions.EnableBehaviour::DoEnableBehaviour(this, v14);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			DoEnableBehaviour(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x6001059")]
		[Address(RVA = "0xB73DF8", Offset = "0xB73DF8", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EE4638]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, go, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022915]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, go, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(go, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0036;\n\treturn;\nL_0036:\n\tgoto L_003F;\n\tv180 = *([v69 @ X0_v6+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_003F;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v69, v58, v59, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003F:\n\tv190 = UnityEngine.Object::op_Inequality(this.component, 0);\n\tv192 = v190 == 0;\n\tif (v192) goto L_006F;\n\tv194 = this.component == 0;\n\tif (v194) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv296 = v296_asT == 0;\n\tif (v296) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_009A;\nL_006F:\n\tv253 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tgoto L_0080;\n\tv334 = *([v248 @ X8_v20+E0]);\n\tv335 = v334 == 0;\n\tv336 = ~v335;\n\tif (v336) goto L_0080;\n\tv345 = v248;\n\tv338 = \"il2cpp_codegen_runtime_class_init\"(v345, v252, v189, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0080:\n\tv342 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v253);\n\tv243 = UnityEngine.GameObject::GetComponent(go, v342);\n\tv245 = v243 == 0;\n\tif (v245) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_009A:\n\tthis.componentTarget = v282;\n\tgoto L_00A8;\n\tv326 = *([v315 @ X0_v11+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tgoto L_00A8;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v315, v309, v308, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A8:\n\tv333 = UnityEngine.Object::op_Equality(v282, 0);\n\tv344 = v333 == 0;\n\tif (v344) goto L_00D4;\n\tv352 = UnityEngine.Object::get_name(go);\n\tv364 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tv374 = System.String::Concat(\" \", v352, \" missing behaviour: \", v364);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v374);\n\treturn;\nL_00D4:\n\tv353 = HutongGames.PlayMaker.FsmBool::get_Value(this.enable);\n\tUnityEngine.Behaviour::set_enabled(this.componentTarget, v353);\n\treturn;\n\tv297 = v297_asT == 0;\n\tif (v297) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_009A;\n\tv274 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 181 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoEnableBehaviour(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			UnityEngine.Object obj;
			if (this.component != null)
			{
				if ((object)this.component == null)
				{
					goto IL_0125;
				}
				Behaviour behaviour = this.component as Behaviour;
				Component component = (((object)behaviour == null) ? null : this.component);
				obj = component;
			}
			else
			{
				string value = this.behaviour.Value;
				Type globalType = ReflectionUtils.GetGlobalType(value);
				Component component2 = go.GetComponent(globalType);
				if ((object)component2 == null)
				{
					goto IL_0125;
				}
				Behaviour behaviour2 = component2 as Behaviour;
				Component component3 = (((object)behaviour2 == null) ? null : component2);
				obj = component3;
			}
			goto IL_022a;
			IL_0125:
			obj = null;
			goto IL_022a;
			IL_022a:
			componentTarget = (Behaviour)obj;
			if (obj == null)
			{
				string text = go.name;
				string value2 = this.behaviour.Value;
				string text2 = " " + text + " missing behaviour: " + value2;
				LogWarning(text2);
			}
			else
			{
				bool value3 = enable.Value;
				componentTarget.enabled = value3;
			}
		}

		[Token(Token = "0x600105A")]
		[Address(RVA = "0xB74060", Offset = "0xB74060", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F0DF40]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022916]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.componentTarget, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0049;\n\tv65 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetOnExit);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0049;\n\tv103 = HutongGames.PlayMaker.FsmBool::get_Value(this.enable);\n\tv89 = ~v103;\n\tUnityEngine.Behaviour::set_enabled(this.componentTarget, v89);\n\treturn;\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (!(componentTarget == null) && resetOnExit.Value)
			{
				bool value = enable.Value;
				bool flag = !value;
				componentTarget.enabled = flag;
			}
		}

		[Token(Token = "0x600105B")]
		[Address(RVA = "0xB7412C", Offset = "0xB7412C", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE3070]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022917]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv97 = *([v75 @ X8_v5+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_002C;\n\tv107 = v75;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v107, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv106 = UnityEngine.Object::op_Equality(v47, 0);\n\tv109 = v106 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_FFFFFFFF;\n\tgoto L_003F;\n\tv191 = *([v174 @ X0_v15+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_003F;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v174, v104, v105, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003F:\n\tv183 = UnityEngine.Object::op_Inequality(this.component, 0);\n\tv222 = v183 == 0;\n\tv187 = ~v222;\n\tif (v187) goto L_FFFFFFFF;\n\tv184 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.behaviour);\n\tv224 = v184 == 0;\n\tv188 = ~v224;\n\tif (v188) goto L_FFFFFFFF;\n\tv226 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tv182 = System.String::IsNullOrEmpty(v226);\n\tv186 = v182 == 0;\n\tif (v186) goto L_0064;\nL_005F:\n\treturn returnVal2;\nL_0064:\n\tv229 = HutongGames.PlayMaker.FsmString::get_Value(this.behaviour);\n\tgoto L_0075;\n\tv235 = *([v93 @ X8_v12+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0075;\n\tv243 = v93;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v243, v228, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0075:\n\tv87 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v229);\n\tv246 = UnityEngine.GameObject::GetComponent(v47, v87);\n\tgoto L_0088;\n\tv251 = *([v247 @ X8_v13+E0]);\n\tv252 = v251 == 0;\n\tv253 = ~v252;\n\tif (v253) goto L_0088;\n\tv259 = v247;\n\tv256 = \"il2cpp_codegen_runtime_class_init\"(v259, v85, v245, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0088:\n\tv258 = v246 == 0;\n\tif (v258) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00B1;\n\tv301 = v301_asT == 0;\n\tif (v301) goto L_FFFFFFFF;\n\tgoto L_00B1;\nL_00B1:\n\tv311 = UnityEngine.Object::op_Inequality(v307, 0);\n\tv205 = v311 == 0;\n\tv198 = ~v205;\n\tv199 = ~v198;\n\tif (v199) goto L_FFFFFFFF;\n\tgoto L_00C1;\nL_00C1:\n\tgoto L_005F;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null) && !(this.component != null) && !this.behaviour.IsNone)
			{
				string value = this.behaviour.Value;
				if (!string.IsNullOrEmpty(value))
				{
					string value2 = this.behaviour.Value;
					Type globalType = ReflectionUtils.GetGlobalType(value2);
					Component component = ownerDefaultTarget.GetComponent(globalType);
					UnityEngine.Object obj;
					if ((object)component == null)
					{
						obj = null;
					}
					else
					{
						Behaviour behaviour = component as Behaviour;
						obj = (((object)behaviour == null) ? null : component);
					}
					if (obj != null)
					{
						return null;
					}
					return "Behaviour missing";
				}
			}
			return null;
		}

		[Token(Token = "0x600105C")]
		[Address(RVA = "0xB74310", Offset = "0xB74310", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnableBehaviour()
		{
		}
	}
}
