using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758A50", Offset = "0x758A50")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x758A50", Offset = "0x758A50")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758A50", Offset = "0x758A50")]
	[Token(Token = "0x2000264")]
	public class FsmStateTest : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5FF4", Offset = "0x7B5FF4")]
		[Token(Token = "0x4001620")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6040", Offset = "0x7B6040")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6040", Offset = "0x7B6040")]
		[Token(Token = "0x4001621")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6090", Offset = "0x7B6090")]
		[Token(Token = "0x4001622")]
		[FieldOffset(Offset = "0x60")]
		public FsmString stateName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B60DC", Offset = "0x7B60DC")]
		[Token(Token = "0x4001623")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6114", Offset = "0x7B6114")]
		[Token(Token = "0x4001624")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B614C", Offset = "0x7B614C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B614C", Offset = "0x7B614C")]
		[Token(Token = "0x4001625")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B619C", Offset = "0x7B619C")]
		[Token(Token = "0x4001626")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x4001627")]
		[FieldOffset(Offset = "0x88")]
		private GameObject previousGo;

		[Token(Token = "0x4001628")]
		[FieldOffset(Offset = "0x90")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x6000BF0")]
		[Address(RVA = "0xB77A6C", Offset = "0xB77A6C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.stateName = 0;\n\tthis.falseEvent = 0;\n\tthis.gameObject = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			stateName = null;
			falseEvent = null;
			gameObject = null;
		}

		[Token(Token = "0x6000BF1")]
		[Address(RVA = "0xB77A80", Offset = "0xB77A80", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmStateTest::DoFsmStateTest(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFsmStateTest();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BF2")]
		[Address(RVA = "0xB77C7C", Offset = "0xB77C7C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FsmStateTest::DoFsmStateTest(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFsmStateTest();
		}

		[Token(Token = "0x6000BF3")]
		[Address(RVA = "0xB77ABC", Offset = "0xB77ABC", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F10C68]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202293A]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_002C;\n\tv111 = *([v78 @ X8_v5+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_002C;\n\tv121 = v78;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v121, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv120 = UnityEngine.Object::op_Equality(v48, 0);\n\tv123 = v120 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0096;\n\tgoto L_003F;\n\tv160 = *([v151 @ X0_v13+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_003F;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v151, v118, v119, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003F:\n\tv167 = UnityEngine.Object::op_Inequality(v48, this.previousGo);\n\tv169 = v167 == 0;\n\tif (v169) goto L_0053;\n\tv174 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv182 = HutongGames.PlayMaker.ActionHelpers::GetGameObjectFsm(v48, v174);\n\tv50 = this + 0x90;\n\tthis.fsm = v182;\n\tthis.previousGo = v48;\n\tgoto L_0059;\nL_0053:\n\tv50 = this + 0x90;\nL_0059:\n\tgoto L_0062;\n\tv189 = *([v184 @ X0_v18+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tgoto L_0062;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v184, v179, v177, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0062:\n\tv157 = UnityEngine.Object::op_Equality(v53, 0);\n\tv198 = v157 == 0;\n\tv158 = ~v198;\n\tif (v158) goto L_0096;\n\tv95 = PlayMakerFSM::get_ActiveStateName(*([v50 @ X23_v5]));\n\tv201 = HutongGames.PlayMaker.FsmString::get_Value(this.stateName);\n\tv96 = System.String::op_Equality(v95, v201);\n\tv204 = v96 == 0;\n\tif (v204) goto L_0088;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.trueEvent);\n\tgoto L_008A;\nL_0088:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.falseEvent);\nL_008A:\n\tv88 = this.storeResult;\n\tv88.value = v106;\nL_0096:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFsmStateTest()
		{
			//IL_00e2: Expected O, but got I
			//IL_00b5: Expected O, but got I
			GameObject value = gameObject.Value;
			if (value == null)
			{
				return;
			}
			object obj;
			UnityEngine.Object obj2;
			if (value != previousGo)
			{
				string value2 = fsmName.Value;
				PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(value, value2);
				obj = (long)(IntPtr)this + 144L;
				fsm = gameObjectFsm;
				previousGo = value;
				obj2 = gameObjectFsm;
			}
			else
			{
				obj = (long)(IntPtr)this + 144L;
				obj2 = fsm;
			}
			if (!(obj2 == null))
			{
				string activeStateName = ((PlayMakerFSM)obj).ActiveStateName;
				string value3 = stateName.Value;
				int value4;
				if (activeStateName == value3)
				{
					Fsm.Event(trueEvent);
					value4 = 1;
				}
				else
				{
					Fsm.Event(falseEvent);
					value4 = 0;
				}
				FsmBool fsmBool = storeResult;
				fsmBool.value = (byte)value4 != 0;
			}
		}

		[Token(Token = "0x6000BF4")]
		[Address(RVA = "0xB77C80", Offset = "0xB77C80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmStateTest()
		{
		}
	}
}
