using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E1D8", Offset = "0x75E1D8")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x75E1D8", Offset = "0x75E1D8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E1D8", Offset = "0x75E1D8")]
	[Token(Token = "0x2000360")]
	public class GetFsmState : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA4A8", Offset = "0x7CA4A8")]
		[Token(Token = "0x4001B76")]
		[FieldOffset(Offset = "0x50")]
		public PlayMakerFSM fsmComponent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA4E0", Offset = "0x7CA4E0")]
		[Token(Token = "0x4001B77")]
		[FieldOffset(Offset = "0x58")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CA518", Offset = "0x7CA518")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA518", Offset = "0x7CA518")]
		[Token(Token = "0x4001B78")]
		[FieldOffset(Offset = "0x60")]
		public FsmString fsmName;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CA568", Offset = "0x7CA568")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA568", Offset = "0x7CA568")]
		[Token(Token = "0x4001B79")]
		[FieldOffset(Offset = "0x68")]
		public FsmString storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA5C8", Offset = "0x7CA5C8")]
		[Token(Token = "0x4001B7A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001B7B")]
		[FieldOffset(Offset = "0x78")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x60010CD")]
		[Address(RVA = "0xA2D9A4", Offset = "0xA2D9A4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBCD08]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DD0]) = v38;\nL_0013:\n\tthis.fsmComponent = 0;\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fsmComponent = null;
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x60010CE")]
		[Address(RVA = "0xA2DA04", Offset = "0xA2DA04", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmState::DoGetFsmState(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetFsmState();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010CF")]
		[Address(RVA = "0xA2DBDC", Offset = "0xA2DBDC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetFsmState::DoGetFsmState(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetFsmState();
		}

		[Token(Token = "0x60010D0")]
		[Address(RVA = "0xA2DA40", Offset = "0xA2DA40", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1F0D958]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DD1]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(this.fsm, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_007D;\n\tgoto L_0036;\n\tv83 = *([v61 @ X0_v15+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0036;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v61, v56, v57, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0036:\n\tv93 = UnityEngine.Object::op_Inequality(this.fsmComponent, 0);\n\tv115 = v93 == 0;\n\tif (v115) goto L_0041;\n\tv154 = this.fsmComponent;\n\tgoto L_005F;\nL_0041:\n\tv158 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0051;\n\tv192 = *([v110 @ X8_v18+E0]);\n\tv193 = v192 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0051;\n\tv200 = v110;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v200, v156, v157, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\tv173 = UnityEngine.Object::op_Inequality(v158, 0);\n\tv175 = v173 == 0;\n\tif (v175) goto L_FFFFFFFF;\n\tv204 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv151 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v158, v204);\nL_005F:\n\tthis.fsm = v154;\n\tgoto L_0066;\nL_0066:\n\tgoto L_006F;\n\tv185 = *([v178 @ X0_v20+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tgoto L_006F;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v178, v171, v170, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006F:\n\tv74 = UnityEngine.Object::op_Equality(v80, 0);\n\tv76 = v74 == 0;\n\tif (v76) goto L_007D;\n\tv136 = this.storeResult;\n\tgoto L_0082;\nL_007D:\n\tv136 = this.storeResult;\n\tv133 = PlayMakerFSM::get_ActiveStateName(this.fsm);\nL_0082:\n\tv136.value = v133;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetFsmState()
		{
			Object obj;
			if (fsm == null)
			{
				PlayMakerFSM playMakerFSM;
				if (fsmComponent != null)
				{
					playMakerFSM = fsmComponent;
				}
				else
				{
					GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
					if (!(ownerDefaultTarget != null))
					{
						obj = fsm;
						goto IL_00f9;
					}
					string value = fsmName.Value;
					PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value);
					playMakerFSM = gameObjectFsm;
				}
				fsm = playMakerFSM;
				obj = playMakerFSM;
				goto IL_00f9;
			}
			goto IL_0141;
			IL_0141:
			FsmString fsmString = storeResult;
			string value2 = fsm.ActiveStateName;
			goto IL_015f;
			IL_00f9:
			if (!(obj == null))
			{
				goto IL_0141;
			}
			fsmString = storeResult;
			value2 = "";
			goto IL_015f;
			IL_015f:
			fsmString.Value = value2;
		}

		[Token(Token = "0x60010D1")]
		[Address(RVA = "0xA2DBE0", Offset = "0xA2DBE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetFsmState()
		{
		}
	}
}
