using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755E6C", Offset = "0x755E6C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755E6C", Offset = "0x755E6C")]
	[Token(Token = "0x20001DC")]
	public class DestroyComponent : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B05C0", Offset = "0x7B05C0")]
		[Token(Token = "0x400142C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B060C", Offset = "0x7B060C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B060C", Offset = "0x7B060C")]
		[Token(Token = "0x400142D")]
		[FieldOffset(Offset = "0x58")]
		public FsmString component;

		[Token(Token = "0x400142E")]
		[FieldOffset(Offset = "0x60")]
		private Component aComponent;

		[Token(Token = "0x60009DE")]
		[Address(RVA = "0xA8618C", Offset = "0xA8618C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.component = 0;\n\tthis.aComponent = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			component = null;
			aComponent = null;
			gameObject = null;
		}

		[Token(Token = "0x60009DF")]
		[Address(RVA = "0xA86198", Offset = "0xA86198", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.gameObject;\n\tv13 = v10.ownerOption == 0;\n\tif (v13) goto L_0013;\n\tv39 = HutongGames.PlayMaker.FsmGameObject::get_Value(v10.gameObject);\n\tgoto L_0015;\nL_0013:\n\tv40 = this.owner;\nL_0015:\n\tHutongGames.PlayMaker.Actions.DestroyComponent::DoDestroyComponent(this, v40);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			DoDestroyComponent(go);
			Finish();
		}

		[Token(Token = "0x60009E0")]
		[Address(RVA = "0xA861F8", Offset = "0xA861F8", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ECFDD8]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, go, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022198]) = v41;\nL_0019:\n\tv45 = HutongGames.PlayMaker.FsmString::get_Value(this.component);\n\tgoto L_002A;\n\tv84 = *([v67 @ X8_v7+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_002A;\n\tv92 = v67;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v92, v44, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tv76 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v45);\n\tv124 = UnityEngine.GameObject::GetComponent(go, v76);\n\tthis.aComponent = v124;\n\tgoto L_0042;\n\tv130 = *([v126 @ X0_v14+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_0042;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v126, v74, v123, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0042:\n\tv137 = UnityEngine.Object::op_Equality(v124, 0);\n\tv139 = v137 == 0;\n\tif (v139) goto L_0062;\n\tv146 = HutongGames.PlayMaker.FsmString::get_Value(this.component);\n\tv157 = System.String::Concat(\"No such component: \", v146);\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, v157);\n\treturn;\nL_0062:\n\tgoto L_0070;\n\tv147 = *([v140 @ X0_v18+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tif (v149) goto L_0070;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v140, v52, v47, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0070:\n\tUnityEngine.Object::Destroy(this.aComponent);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoDestroyComponent(GameObject go)
		{
			string value = component.Value;
			Type globalType = ReflectionUtils.GetGlobalType(value);
			if ((aComponent = go.GetComponent(globalType)) == null)
			{
				string value2 = component.Value;
				string text = "No such component: " + value2;
				LogError(text);
			}
			else
			{
				UnityEngine.Object.Destroy(aComponent);
			}
		}

		[Token(Token = "0x60009E1")]
		[Address(RVA = "0xA86350", Offset = "0xA86350", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DestroyComponent()
		{
		}
	}
}
