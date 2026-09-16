using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D214", Offset = "0x75D214")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D214", Offset = "0x75D214")]
	[Token(Token = "0x200033F")]
	public class AddScript : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C868C", Offset = "0x7C868C")]
		[Token(Token = "0x4001AB8")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C86D8", Offset = "0x7C86D8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C86D8", Offset = "0x7C86D8")]
		[Token(Token = "0x4001AB9")]
		[FieldOffset(Offset = "0x58")]
		public FsmString script;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8738", Offset = "0x7C8738")]
		[Token(Token = "0x4001ABA")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool removeOnExit;

		[Token(Token = "0x4001ABB")]
		[FieldOffset(Offset = "0x68")]
		private Component addedComponent;

		[Token(Token = "0x6001040")]
		[Address(RVA = "0xA134EC", Offset = "0xA134EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.script = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			script = null;
		}

		[Token(Token = "0x6001041")]
		[Address(RVA = "0xA134F4", Offset = "0xA134F4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0015;\nL_0013:\n\tv40 = this.owner;\nL_0015:\n\tHutongGames.PlayMaker.Actions.AddScript::DoAddComponent(this, v40);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			DoAddComponent(go);
			Finish();
		}

		[Token(Token = "0x6001042")]
		[Address(RVA = "0xA13688", Offset = "0xA13688", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F0D3C8]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021D22]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmBool::get_Value(this.removeOnExit);\n\tv47 = v44 == 0;\n\tif (v47) goto L_004B;\n\tgoto L_002C;\n\tv91 = *([v51 @ X0_v6+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002C;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v51, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv61 = UnityEngine.Object::op_Inequality(this.addedComponent, 0);\n\tv63 = v61 == 0;\n\tif (v63) goto L_004B;\n\tgoto L_0043;\n\tv104 = *([v99 @ X0_v10+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0043;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v99, v59, v56, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0043:\n\tUnityEngine.Object::Destroy(this.addedComponent);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (removeOnExit.Value && addedComponent != null)
			{
				UnityEngine.Object.Destroy(addedComponent);
			}
		}

		[Token(Token = "0x6001043")]
		[Address(RVA = "0xA13554", Offset = "0xA13554", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB59A0]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021D23]) = v41;\nL_0019:\n\tv45 = HutongGames.PlayMaker.FsmString::get_Value(this.script);\n\tgoto L_002A;\n\tv83 = *([v66 @ X8_v7+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002A;\n\tv91 = v66;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v91, v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tv75 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v45);\n\tv121 = UnityEngine.GameObject::AddComponent(go, v75);\n\tthis.addedComponent = v121;\n\tgoto L_0042;\n\tv128 = *([v124 @ X0_v14+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0042;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v124, v73, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0042:\n\tv102 = UnityEngine.Object::op_Equality(v121, 0);\n\tv104 = v102 == 0;\n\tif (v104) goto L_0063;\n\tv137 = HutongGames.PlayMaker.FsmString::get_Value(this.script);\n\tv143 = System.String::Concat(\"Can't add script: \", v137);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v143);\n\treturn;\nL_0063:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddComponent(GameObject go)
		{
			string value = script.Value;
			Type globalType = ReflectionUtils.GetGlobalType(value);
			if ((addedComponent = go.AddComponent(globalType)) == null)
			{
				string value2 = script.Value;
				string text = "Can't add script: " + value2;
				LogError(text);
			}
		}

		[Token(Token = "0x6001044")]
		[Address(RVA = "0xA13754", Offset = "0xA13754", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddScript()
		{
		}
	}
}
