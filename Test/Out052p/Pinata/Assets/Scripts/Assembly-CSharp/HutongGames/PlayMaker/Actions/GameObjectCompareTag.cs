using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758BAC", Offset = "0x758BAC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758BAC", Offset = "0x758BAC")]
	[Token(Token = "0x2000267")]
	public class GameObjectCompareTag : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6484", Offset = "0x7B6484")]
		[Token(Token = "0x4001633")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B64D0", Offset = "0x7B64D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B64D0", Offset = "0x7B64D0")]
		[Token(Token = "0x4001634")]
		[FieldOffset(Offset = "0x58")]
		public FsmString tag;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6530", Offset = "0x7B6530")]
		[Token(Token = "0x4001635")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6568", Offset = "0x7B6568")]
		[Token(Token = "0x4001636")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B65A0", Offset = "0x7B65A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B65A0", Offset = "0x7B65A0")]
		[Token(Token = "0x4001637")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B65F0", Offset = "0x7B65F0")]
		[Token(Token = "0x4001638")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000BFE")]
		[Address(RVA = "0xB7CBC0", Offset = "0xB7CBC0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED37F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022978]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Untagged\");\n\tthis.everyFrame = 0;\n\tthis.tag = v43;\n\tthis.trueEvent = 0;\n\tthis.falseEvent = 0;\n\tthis.storeResult = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "Untagged";
			everyFrame = false;
			tag = fsmString;
			trueEvent = null;
			falseEvent = null;
			storeResult = null;
		}

		[Token(Token = "0x6000BFF")]
		[Address(RVA = "0xB7CC24", Offset = "0xB7CC24", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectCompareTag::DoCompareTag(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoCompareTag();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C00")]
		[Address(RVA = "0xB7CD70", Offset = "0xB7CD70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectCompareTag::DoCompareTag(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoCompareTag();
		}

		[Token(Token = "0x6000C01")]
		[Address(RVA = "0xB7CC60", Offset = "0xB7CC60", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC3AB8]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022979]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0029;\n\tv71 = *([v61 @ X8_v6+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0029;\n\tv120 = v61;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v120, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv78 = UnityEngine.Object::op_Inequality(v42, 0);\n\tv122 = v78 == 0;\n\tif (v122) goto L_FFFFFFFF;\n\tv125 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tv144 = HutongGames.PlayMaker.FsmString::get_Value(this.tag);\n\tv130 = UnityEngine.GameObject::CompareTag(v125, v144);\n\tgoto L_0041;\nL_0041:\n\tv138 = this.storeResult;\n\tv138.value = v130;\n\tv105 = this + 0x60;\n\tv100 = this + 0x68;\n\tv94 = v130 == 0;\n\tv85 = ~v94;\n\tv82 = ~v85;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_005F;\nL_005F:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v105 @ X9_v6]));\n\treturn;\n\tv54 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoCompareTag()
		{
			//IL_00ae: Expected O, but got I
			//IL_00ba: Expected O, but got I
			GameObject value = gameObject.Value;
			bool flag;
			if (value != null)
			{
				GameObject value2 = gameObject.Value;
				string value3 = tag.Value;
				flag = value2.CompareTag(value3);
			}
			else
			{
				flag = false;
			}
			FsmBool fsmBool = storeResult;
			fsmBool.value = flag;
			object fsmEvent = (long)(IntPtr)this + 96L;
			object obj = (long)(IntPtr)this + 104L;
			if (!flag)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
		}

		[Token(Token = "0x6000C02")]
		[Address(RVA = "0xB7CD74", Offset = "0xB7CD74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectCompareTag()
		{
		}
	}
}
