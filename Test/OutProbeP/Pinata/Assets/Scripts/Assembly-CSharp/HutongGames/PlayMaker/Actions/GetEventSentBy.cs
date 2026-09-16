using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D940", Offset = "0x75D940")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D940", Offset = "0x75D940")]
	[Token(Token = "0x2000352")]
	public class GetEventSentBy : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9814", Offset = "0x7C9814")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9814", Offset = "0x7C9814")]
		[Token(Token = "0x4001B20")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject sentByGameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C9864", Offset = "0x7C9864")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9864", Offset = "0x7C9864")]
		[Token(Token = "0x4001B21")]
		[FieldOffset(Offset = "0x58")]
		public FsmString gameObjectName;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C98B4", Offset = "0x7C98B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C98B4", Offset = "0x7C98B4")]
		[Token(Token = "0x4001B22")]
		[FieldOffset(Offset = "0x60")]
		public FsmString fsmName;

		[Token(Token = "0x600108F")]
		[Address(RVA = "0xA2B534", Offset = "0xA2B534", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObjectName = 0;\n\tthis.fsmName = 0;\n\tthis.sentByGameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObjectName = null;
			fsmName = null;
			sentByGameObject = null;
		}

		[Token(Token = "0x6001090")]
		[Address(RVA = "0xA2B540", Offset = "0xA2B540", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFADD8]);\n\tv25 = *([v24 @ X8_v36]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021DB4]) = v44;\nL_001C:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\tv59 = v58.EventData;\n\tgoto L_0037;\n\tv125 = *([v65 @ X0_v8+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_0037;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0037:\n\tv133 = UnityEngine.Object::op_Inequality(v59.SentByGameObject, 0);\n\tv161 = v133 == 0;\n\tif (v161) goto L_0058;\n\tv72 = this + 0x50;\n\tgoto L_004A;\n\tv194 = *([v163 @ X0_v35 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_004A;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v163, v79, v74, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv197 = HutongGames.PlayMaker.Fsm;\nL_004A:\n\tv112 = v200.EventData;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.sentByGameObject, v112.SentByGameObject);\n\tgoto L_00A1;\nL_0058:\n\tgoto L_0060;\n\tv201 = *([v167 @ X0_v25 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0060;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v167, v79, v74, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv204 = HutongGames.PlayMaker.Fsm;\nL_0060:\n\tv114 = v207.EventData;\n\tv72 = this + 0x50;\n\tv211 = v114.SentByFsm == 0;\n\tif (v211) goto L_0095;\n\tgoto L_007B;\n\tv84 = *([v96 @ X0_v26 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv218 = v84 == 0;\n\tv219 = ~v218;\n\t// 112 ConditionalJump @b29, v219 @ TEMP_v44 (System.Boolean)\n\tv229 = HutongGames.PlayMaker.Fsm;\n\tv230 = *([v229 @ X8_v23 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+B8]);\n\tv113 = v230.EventData;\nL_007B:\n\tv94 = HutongGames.PlayMaker.Fsm::get_GameObject(v114.SentByFsm);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.sentByGameObject, v94);\n\tv115 = v245.EventData;\n\tv116 = v115.SentByFsm;\n\tv86 = this.fsmName;\n\tv86.value = v116.name;\n\tgoto L_00A1;\nL_0095:\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.sentByGameObject, 0);\n\tv118 = this.fsmName;\n\tv118.value = \"\";\nL_00A1:\n\tv228 = HutongGames.PlayMaker.FsmGameObject::get_Value(*([v72 @ X22_v3]));\n\tgoto L_00B1;\n\tv236 = *([v119 @ X8_v11+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_00B1;\n\tv246 = v119;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v246, v227, v136, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00B1:\n\tv243 = UnityEngine.Object::op_Inequality(v228, 0);\n\tv248 = v243 == 0;\n\tif (v248) goto L_00CC;\n\tv123 = this.gameObjectName;\n\tv147 = HutongGames.PlayMaker.FsmGameObject::get_Value(*([v72 @ X22_v3]));\n\tv98 = UnityEngine.Object::get_name(v147);\n\tv123.value = v98;\nL_00CC:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_0046: Expected O, but got I
			//IL_0075: Expected O, but got I
			FsmEventData eventData = Fsm.EventData;
			object obj;
			if (eventData.SentByGameObject != null)
			{
				obj = (long)(IntPtr)this + 80L;
				FsmEventData eventData2 = Fsm.EventData;
				sentByGameObject.Value = eventData2.SentByGameObject;
			}
			else
			{
				FsmEventData eventData3 = Fsm.EventData;
				obj = (long)(IntPtr)this + 80L;
				if (eventData3.SentByFsm != null)
				{
					GameObject gameObject = eventData3.SentByFsm.GameObject;
					sentByGameObject.Value = gameObject;
					FsmEventData eventData4 = Fsm.EventData;
					Fsm sentByFsm = eventData4.SentByFsm;
					FsmString fsmString = fsmName;
					fsmString.Value = sentByFsm.Name;
				}
				else
				{
					sentByGameObject.Value = null;
					FsmString fsmString2 = fsmName;
					fsmString2.Value = "";
				}
			}
			GameObject value = ((FsmGameObject)obj).Value;
			if (value != null)
			{
				FsmString fsmString3 = gameObjectName;
				GameObject value2 = ((FsmGameObject)obj).Value;
				string value3 = value2.name;
				fsmString3.Value = value3;
			}
			Finish();
		}

		[Token(Token = "0x6001091")]
		[Address(RVA = "0xA2B794", Offset = "0xA2B794", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetEventSentBy()
		{
		}
	}
}
