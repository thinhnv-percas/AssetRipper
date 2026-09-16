using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x753E74", Offset = "0x753E74")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x753E74", Offset = "0x753E74")]
	[Obsolete]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x753E74", Offset = "0x753E74")]
	[Token(Token = "0x2000180")]
	public class FsmArraySet : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA59C", Offset = "0x7AA59C")]
		[Token(Token = "0x400127F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AA5E8", Offset = "0x7AA5E8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA5E8", Offset = "0x7AA5E8")]
		[Token(Token = "0x4001280")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA638", Offset = "0x7AA638")]
		[Token(Token = "0x4001281")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA684", Offset = "0x7AA684")]
		[Token(Token = "0x4001282")]
		[FieldOffset(Offset = "0x68")]
		public FsmString setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AA6BC", Offset = "0x7AA6BC")]
		[Token(Token = "0x4001283")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001284")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001285")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600084D")]
		[Address(RVA = "0xB77388", Offset = "0xB77388", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF8BB0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022936]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.setValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x600084E")]
		[Address(RVA = "0xB773E8", Offset = "0xB773E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmArraySet::DoSetFsmString(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetFsmString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600084F")]
		[Address(RVA = "0xB77424", Offset = "0xB77424", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EDE6E8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022937]) = v42;\nL_0016:\n\tv44 = this.setValue == 0;\n\tif (v44) goto L_0093;\n\tv80 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002F;\n\tv153 = *([v68 @ X8_v7+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_002F;\n\tv160 = v68;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v160, v78, v79, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv62 = UnityEngine.Object::op_Equality(v80, 0);\n\tv162 = v62 == 0;\n\tv65 = ~v162;\n\tif (v65) goto L_0093;\n\tgoto L_0042;\n\tv167 = *([v163 @ X0_v13+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_0042;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v163, v59, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv174 = UnityEngine.Object::op_Inequality(v80, this.goLastFrame);\n\tv176 = v174 == 0;\n\tif (v176) goto L_0056;\n\tthis.goLastFrame = v80;\n\tv181 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv188 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v80, v181);\n\tv48 = this + 0x80;\n\tthis.fsm = v188;\n\tgoto L_005C;\nL_0056:\n\tv48 = this + 0x80;\nL_005C:\n\tgoto L_0065;\n\tv196 = *([v191 @ X0_v18+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tgoto L_0065;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v191, v185, v183, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0065:\n\tv203 = UnityEngine.Object::op_Equality(v107, 0);\n\tv206 = v203 == 0;\n\tif (v206) goto L_0075;\n\tv214 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tgoto L_009F;\nL_0075:\n\tv147 = PlayMakerFSM::get_FsmVariables(*([v48 @ X21_v6]));\n\tv148 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv226 = HutongGames.PlayMaker.FsmVariables::GetFsmString(v147, v148);\n\tv227 = v226 == 0;\n\tif (v227) goto L_0098;\n\tv61 = HutongGames.PlayMaker.FsmString::get_Value(this.setValue);\n\tv226.value = v61;\nL_0093:\n\treturn;\nL_0098:\n\tv214 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\nL_009F:\n\tv222 = System.String::Concat(*([v216 @ X8_v12 (System.String)]), v214);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v222);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetFsmString()
		{
			//IL_00ed: Expected O, but got I
			//IL_00ca: Expected O, but got I
			if (setValue == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			UnityEngine.Object obj2;
			if (ownerDefaultTarget != goLastFrame)
			{
				goLastFrame = ownerDefaultTarget;
				string value = fsmName.Value;
				PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value);
				obj = (long)(IntPtr)this + 128L;
				fsm = gameObjectFsm;
				obj2 = gameObjectFsm;
			}
			else
			{
				obj = (long)(IntPtr)this + 128L;
				obj2 = fsm;
			}
			string value2;
			string text;
			if (obj2 == null)
			{
				value2 = fsmName.Value;
				text = "Could not find FSM: ";
			}
			else
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value3 = variableName.Value;
				FsmString fsmString = fsmVariables.GetFsmString(value3);
				if (fsmString != null)
				{
					string value4 = setValue.Value;
					fsmString.Value = value4;
					return;
				}
				value2 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value2;
			LogWarning(text2);
		}

		[Token(Token = "0x6000850")]
		[Address(RVA = "0xB77624", Offset = "0xB77624", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmArraySet::DoSetFsmString(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetFsmString();
		}

		[Token(Token = "0x6000851")]
		[Address(RVA = "0xB77628", Offset = "0xB77628", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmArraySet()
		{
		}
	}
}
