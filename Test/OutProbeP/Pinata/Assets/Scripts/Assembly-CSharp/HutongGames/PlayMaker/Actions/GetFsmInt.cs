using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75DE2C", Offset = "0x75DE2C")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75DE2C", Offset = "0x75DE2C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75DE2C", Offset = "0x75DE2C")]
	[Token(Token = "0x200035B")]
	public class GetFsmInt : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001B4E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9EB0", Offset = "0x7C9EB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9EB0", Offset = "0x7C9EB0")]
		[Token(Token = "0x4001B4F")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9F00", Offset = "0x7C9F00")]
		[Token(Token = "0x4001B50")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9F3C", Offset = "0x7C9F3C")]
		[Token(Token = "0x4001B51")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt storeValue;

		[Token(Token = "0x4001B52")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B53")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001B54")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001B55")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010B4")]
		[Address(RVA = "0xA2CCDC", Offset = "0xA2CCDC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0A3C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DC6]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeValue = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeValue = null;
		}

		[Token(Token = "0x60010B5")]
		[Address(RVA = "0xA2CD3C", Offset = "0xA2CD3C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmInt::DoGetFsmInt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmInt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010B6")]
		[Address(RVA = "0xA2CF48", Offset = "0xA2CF48", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmInt::DoGetFsmInt(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmInt();
		}

		[Token(Token = "0x60010B7")]
		[Address(RVA = "0xA2CD78", Offset = "0xA2CD78", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EAF0A0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021DC7]) = v42;\nL_0016:\n\tv44 = this.storeValue == 0;\n\tif (v44) goto L_009E;\n\tv91 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002F;\n\tv151 = *([v77 @ X8_v7+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_002F;\n\tv158 = v77;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v158, v89, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002F:\n\tv65 = UnityEngine.Object::op_Equality(v91, 0);\n\tv160 = v65 == 0;\n\tv70 = ~v160;\n\tif (v70) goto L_009E;\n\tgoto L_0042;\n\tv165 = *([v161 @ X0_v13+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0042;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v161, v60, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv172 = UnityEngine.Object::op_Inequality(v91, this.goLastFrame);\n\tv174 = v172 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_0053;\n\tv183 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv179 = System.String::op_Inequality(v183, this.fsmNameLastFrame);\n\tv181 = v179 == 0;\n\tif (v181) goto L_0069;\nL_0053:\n\tthis.goLastFrame = v91;\n\tv143 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tthis.fsmNameLastFrame = v143;\n\tv187 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv194 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v91, v187);\n\tv48 = this + 0x88;\n\tthis.fsm = v194;\n\tgoto L_006F;\nL_0069:\n\tv48 = this + 0x88;\n\tv82 = this.fsm;\nL_006F:\n\tgoto L_0078;\n\tv207 = *([v202 @ X0_v18+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tgoto L_0078;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v202, v197, v196, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0078:\n\tv66 = UnityEngine.Object::op_Equality(v82, 0);\n\tv215 = v66 == 0;\n\tv71 = ~v215;\n\tif (v71) goto L_009E;\n\tv144 = PlayMakerFSM::get_FsmVariables(*([v48 @ X21_v6]));\n\tv145 = HutongGames.PlayMaker.FsmString::get_Value(this.variableName);\n\tv67 = HutongGames.PlayMaker.FsmVariables::GetFsmInt(v144, v145);\n\tv72 = v67 == 0;\n\tif (v72) goto L_009E;\n\tv74 = this.storeValue;\n\tv64 = HutongGames.PlayMaker.FsmInt::get_Value(v67);\n\tv74.value = v64;\nL_009E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmInt()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
			if (storeValue == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			PlayMakerFSM playMakerFSM;
			if (!(ownerDefaultTarget != goLastFrame))
			{
				string value = fsmName.Value;
				if (!(value != fsmNameLastFrame))
				{
					obj = (long)(IntPtr)this + 136L;
					playMakerFSM = fsm;
					goto IL_0169;
				}
			}
			goLastFrame = ownerDefaultTarget;
			string value2 = fsmName.Value;
			fsmNameLastFrame = value2;
			string value3 = fsmName.Value;
			PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value3);
			obj = (long)(IntPtr)this + 136L;
			fsm = gameObjectFsm;
			playMakerFSM = gameObjectFsm;
			goto IL_0169;
			IL_0169:
			if (!(playMakerFSM == null))
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value4 = variableName.Value;
				FsmInt fsmInt = fsmVariables.GetFsmInt(value4);
				if (fsmInt != null)
				{
					FsmInt fsmInt2 = storeValue;
					int value5 = fsmInt.Value;
					fsmInt2.Value = value5;
				}
			}
		}

		[Token(Token = "0x60010B8")]
		[Address(RVA = "0xA2CF4C", Offset = "0xA2CF4C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmInt()
		{
		}
	}
}
