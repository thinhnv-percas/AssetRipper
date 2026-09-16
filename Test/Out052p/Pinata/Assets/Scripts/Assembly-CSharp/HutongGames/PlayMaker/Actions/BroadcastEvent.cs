using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Obsolete]
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D5B4", Offset = "0x75D5B4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D5B4", Offset = "0x75D5B4")]
	[Token(Token = "0x2000349")]
	public class BroadcastEvent : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001AFF")]
		[FieldOffset(Offset = "0x50")]
		public FsmString broadcastEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C932C", Offset = "0x7C932C")]
		[Token(Token = "0x4001B00")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9364", Offset = "0x7C9364")]
		[Token(Token = "0x4001B01")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool sendToChildren;

		[Token(Token = "0x4001B02")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool excludeSelf;

		[Token(Token = "0x6001073")]
		[Address(RVA = "0xA8C648", Offset = "0xA8C648", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.broadcastEvent = 0;\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.sendToChildren = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.excludeSelf = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			broadcastEvent = null;
			gameObject = null;
			FsmBool fsmBool = false;
			sendToChildren = fsmBool;
			FsmBool fsmBool2 = false;
			excludeSelf = fsmBool2;
		}

		[Token(Token = "0x6001074")]
		[Address(RVA = "0xA8C688", Offset = "0xA8C688", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EB9488]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221CE]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.broadcastEvent);\n\tv70 = System.String::IsNullOrEmpty(v48);\n\tv110 = v70 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_007D;\n\tv161 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0037;\n\tv168 = *([v66 @ X8_v8+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0037;\n\tv176 = v66;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v176, v160, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0037:\n\tv175 = UnityEngine.Object::op_Inequality(v161, 0);\n\tv178 = v175 == 0;\n\tif (v178) goto L_0064;\n\tv88 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tv89 = HutongGames.PlayMaker.FsmString::get_Value(this.broadcastEvent);\n\tv90 = HutongGames.PlayMaker.FsmBool::get_Value(this.sendToChildren);\n\tv91 = HutongGames.PlayMaker.FsmBool::get_Value(this.excludeSelf);\n\tHutongGames.PlayMaker.Fsm::BroadcastEventToGameObject(this.fsm, v88, v89, v90, v91);\n\tgoto L_007D;\nL_0064:\n\tv92 = HutongGames.PlayMaker.FsmString::get_Value(this.broadcastEvent);\n\tv93 = HutongGames.PlayMaker.FsmBool::get_Value(this.excludeSelf);\n\tHutongGames.PlayMaker.Fsm::BroadcastEvent(this.fsm, v92, v93);\nL_007D:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = broadcastEvent.Value;
			if (!string.IsNullOrEmpty(value))
			{
				GameObject value2 = gameObject.Value;
				if (value2 != null)
				{
					GameObject value3 = gameObject.Value;
					string value4 = broadcastEvent.Value;
					bool value5 = sendToChildren.Value;
					bool value6 = excludeSelf.Value;
					Fsm.BroadcastEventToGameObject(value3, value4, value5, value6);
				}
				else
				{
					string value7 = broadcastEvent.Value;
					bool value8 = excludeSelf.Value;
					Fsm.BroadcastEvent(value7, value8);
				}
			}
			Finish();
		}

		[Token(Token = "0x6001075")]
		[Address(RVA = "0xA8C814", Offset = "0xA8C814", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BroadcastEvent()
		{
		}
	}
}
