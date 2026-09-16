using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7584E4", Offset = "0x7584E4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7584E4", Offset = "0x7584E4")]
	[Token(Token = "0x2000254")]
	public class SetLightType : ComponentAction<Light>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B4E8C", Offset = "0x7B4E8C")]
		[Token(Token = "0x40015D8")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7B4F00", Offset = "0x7B4F00")]
		[Token(Token = "0x40015D9")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum lightType;

		[Token(Token = "0x6000BA1")]
		[Address(RVA = "0x9968D8", Offset = "0x9968D8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA5740]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202176E]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv44 = 2;\n\t// 26 Box v45 @ X0_v3 (System.Enum), typeof(UnityEngine.LightType), &v44 @ X8_v5 (System.Int32)\n\tv47 = HutongGames.PlayMaker.FsmEnum::op_Implicit(v45);\n\tthis.lightType = v47;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			int num = 2;
			Enum obj = (LightType)num;
			FsmEnum fsmEnum = obj;
			lightType = fsmEnum;
		}

		[Token(Token = "0x6000BA2")]
		[Address(RVA = "0x99694C", Offset = "0x99694C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetLightType::DoSetLightType(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetLightType();
			Finish();
		}

		[Token(Token = "0x6000BA3")]
		[Address(RVA = "0x996974", Offset = "0x996974", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE4770]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202176F]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetLightType)+30]), this.gameObject);\n\tv61 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::UpdateCache(this, v43);\n\tv75 = v61 == 0;\n\tif (v75) goto L_0053;\n\tv66 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::get_light(this);\n\tv49 = HutongGames.PlayMaker.FsmEnum::get_Value(this.lightType);\n\tv78 = v78_asT == 0;\n\tif (v78) goto L_0057;\n\tv153 = \"il2cpp_vm_object_unbox\"(v49, UnityEngine.LightType, Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tUnityEngine.Light::set_type(v66, *([v153 @ X0_v17]));\n\treturn;\nL_0053:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv73 = new System.NullReferenceException();\nL_0057:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetLightType()
		{
			//IL_001c: Expected O, but got I
			//IL_0080: Expected I4, but got O
			//IL_00b9: Expected I4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetLightType)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				Light light = base.light;
				Enum value = lightType.Value;
				if ((int)((value is LightType) ? value : null) == 0)
				{
					throw new InvalidCastException();
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj = default(object);
				light.type = (LightType)obj;
			}
		}

		[Token(Token = "0x6000BA4")]
		[Address(RVA = "0x996A64", Offset = "0x996A64", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFABC8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021770]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Light>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetLightType()
		{
		}
	}
}
