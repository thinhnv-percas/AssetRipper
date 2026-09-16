using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75659C", Offset = "0x75659C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75659C", Offset = "0x75659C")]
	[Token(Token = "0x20001F3")]
	public class HasComponent : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001470")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1578", Offset = "0x7B1578")]
		[Token(Token = "0x4001471")]
		[FieldOffset(Offset = "0x58")]
		public FsmString component;

		[Token(Token = "0x4001472")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool removeOnExit;

		[Token(Token = "0x4001473")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent trueEvent;

		[Token(Token = "0x4001474")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B15B4", Offset = "0x7B15B4")]
		[Token(Token = "0x4001475")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool store;

		[Token(Token = "0x4001476")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x4001477")]
		[FieldOffset(Offset = "0x88")]
		private Component aComponent;

		[Token(Token = "0x6000A3E")]
		[Address(RVA = "0xA37D20", Offset = "0xA37D20", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.aComponent = 0;\n\tthis.gameObject = 0;\n\tthis.component = 0;\n\tthis.falseEvent = 0;\n\tthis.store = 0;\n\tthis.everyFrame = 0;\n\tthis.trueEvent = 0;\n\treturn;\n")]
		public override void Reset()
		{
			aComponent = null;
			gameObject = null;
			component = null;
			falseEvent = null;
			store = null;
			everyFrame = false;
			trueEvent = null;
		}

		[Token(Token = "0x6000A3F")]
		[Address(RVA = "0xA37D38", Offset = "0xA37D38", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0015;\nL_0013:\n\tv40 = this.owner;\nL_0015:\n\tHutongGames.PlayMaker.Actions.HasComponent::DoHasComponent(this, v40);\n\tv46 = ~this.everyFrame;\n\tif (v46) goto L_0024;\n\treturn;\nL_0024:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				go = Owner;
			}
			DoHasComponent(go);
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A40")]
		[Address(RVA = "0xA37F68", Offset = "0xA37F68", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0019;\nL_0013:\n\tv40 = this.owner;\nL_0019:\n\tHutongGames.PlayMaker.Actions.HasComponent::DoHasComponent(this, v40);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				go = Owner;
			}
			DoHasComponent(go);
		}

		[Token(Token = "0x6000A41")]
		[Address(RVA = "0xA37FBC", Offset = "0xA37FBC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F10C08]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E26]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmBool::get_Value(this.removeOnExit);\n\tv47 = v44 == 0;\n\tif (v47) goto L_004B;\n\tgoto L_002C;\n\tv91 = *([v51 @ X0_v6+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002C;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v51, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv61 = UnityEngine.Object::op_Inequality(this.aComponent, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_004B;\n\tgoto L_0043;\n\tv104 = *([v99 @ X0_v10+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0043;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v99, v59, v56, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tUnityEngine.Object::Destroy(this.aComponent);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (removeOnExit.Value && aComponent != null)
			{
				UnityEngine.Object.Destroy(aComponent);
			}
		}

		[Token(Token = "0x6000A42")]
		[Address(RVA = "0xA37DAC", Offset = "0xA37DAC", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC9DB0]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, go, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021E27]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, go, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(go, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_003F;\n\tv68 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.store);\n\tv93 = v68 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0036;\n\tv102 = this.store;\n\tv102.value = 0;\nL_0036:\n\tv134 = this.fsm;\n\tv132 = this.falseEvent;\n\tgoto L_00A0;\nL_003F:\n\tv91 = HutongGames.PlayMaker.FsmString::get_Value(this.component);\n\tgoto L_0050;\n\tv147 = *([v98 @ X8_v10+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0050;\n\tv180 = v98;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v180, v90, v59, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0050:\n\tv156 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v91);\n\tv164 = UnityEngine.GameObject::GetComponent(go, v156);\n\tthis.aComponent = v164;\n\tv198 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.store);\n\tv200 = v198 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_007C;\n\tv176 = this.store;\n\tgoto L_0071;\n\tv218 = *([v202 @ X0_v28+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_0071;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v202, v197, v157, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0071:\n\tv165 = UnityEngine.Object::op_Inequality(this.aComponent, 0);\n\tv176.value = v165;\nL_007C:\n\tgoto L_0085;\n\tv225 = *([v214 @ X0_v22+E0]);\n\tv226 = v225 == 0;\n\tv227 = ~v226;\n\tgoto L_0085;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v214, v207, v206, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0085:\n\tv166 = UnityEngine.Object::op_Inequality(this.aComponent, 0);\n\tv193 = this + 0x68;\n\tv187 = this + 0x70;\n\tv185 = v166 == 0;\n\tv182 = ~v185;\n\tv181 = ~v182;\n\tif (v181) goto L_FFFFFFFF;\n\tgoto L_0096;\nL_0096:\n\tv132 = this.trueEvent;\nL_00A0:\n\tHutongGames.PlayMaker.Fsm::Event(v134, v132);\n\treturn;\n\tv77 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoHasComponent(GameObject go)
		{
			//IL_016c: Expected O, but got I
			//IL_0178: Expected O, but got I
			Fsm fsm;
			FsmEvent fsmEvent;
			if (go == null)
			{
				if (!store.IsNone)
				{
					FsmBool fsmBool = store;
					fsmBool.value = false;
				}
				fsm = Fsm;
				fsmEvent = falseEvent;
			}
			else
			{
				string value = this.component.Value;
				Type globalType = ReflectionUtils.GetGlobalType(value);
				Component component = go.GetComponent(globalType);
				aComponent = component;
				if (!store.IsNone)
				{
					FsmBool fsmBool2 = store;
					bool value2 = aComponent != null;
					fsmBool2.value = value2;
				}
				bool flag = aComponent != null;
				object obj = (long)(IntPtr)this + 104L;
				object obj2 = (long)(IntPtr)this + 112L;
				if (!flag)
				{
					obj = obj2;
				}
				fsmEvent = (FsmEvent)obj;
				fsm = Fsm;
			}
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000A43")]
		[Address(RVA = "0xA38088", Offset = "0xA38088", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HasComponent()
		{
		}
	}
}
