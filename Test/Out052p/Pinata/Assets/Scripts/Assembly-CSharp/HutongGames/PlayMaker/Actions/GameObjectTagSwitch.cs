using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758DA8", Offset = "0x758DA8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758DA8", Offset = "0x758DA8")]
	[Token(Token = "0x200026C")]
	public class GameObjectTagSwitch : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6B84", Offset = "0x7B6B84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6B84", Offset = "0x7B6B84")]
		[Token(Token = "0x400164D")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7B6BE4", Offset = "0x7B6BE4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6BE4", Offset = "0x7B6BE4")]
		[Token(Token = "0x400164E")]
		[FieldOffset(Offset = "0x58")]
		public FsmString[] compareTo;

		[Token(Token = "0x400164F")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent[] sendEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6C64", Offset = "0x7B6C64")]
		[Token(Token = "0x4001650")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000C16")]
		[Address(RVA = "0xB7D2E8", Offset = "0xB7D2E8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0FF20]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202297F]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.compareTo = v43;\n\t// 30 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 1\n\tthis.sendEvent = v48;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString[] array = new FsmString[1];
			compareTo = array;
			FsmEvent[] array2 = new FsmEvent[1];
			sendEvent = array2;
			everyFrame = false;
		}

		[Token(Token = "0x6000C17")]
		[Address(RVA = "0xB7D360", Offset = "0xB7D360", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectTagSwitch::DoTagSwitch(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoTagSwitch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C18")]
		[Address(RVA = "0xB7D508", Offset = "0xB7D508", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectTagSwitch::DoTagSwitch(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoTagSwitch();
		}

		[Token(Token = "0x6000C19")]
		[Address(RVA = "0xB7D39C", Offset = "0xB7D39C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EFF8D8]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022980]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_002C;\n\tv137 = *([v133 @ X8_v6+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_002C;\n\tv205 = v133;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v205, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv147 = UnityEngine.Object::op_Equality(v48, 0);\n\tv207 = v147 == 0;\n\tv208 = ~v207;\n\tif (v208) goto L_0074;\n\tv270 = this.compareTo;\nL_003F:\n\tv50 = v102 >= v270.Length;\n\tif (v50) goto L_0074;\n\tv253 = UnityEngine.GameObject::get_tag(v48);\n\tv259 = this.compareTo;\n\tv273 = v102 < v259.Length;\n\tv96 = ~v273;\n\tif (v96) goto L_0094;\n\tv279 = HutongGames.PlayMaker.FsmString::get_Value(v259[v102 @ X22_v6 (System.Int32)]);\n\tv252 = System.String::op_Equality(v253, v279);\n\tv282 = v252 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_0075;\n\tv270 = this.compareTo;\n\tv102 = v102 + 1;\n\tv284 = this.compareTo == 0;\n\tv254 = ~v284;\n\tif (v254) goto L_003F;\n\tthrow System.NullReferenceException;\nL_0074:\n\treturn;\nL_0075:\n\tv127 = this.sendEvent;\n\tv285 = v102 < v127.Length;\n\tv97 = ~v285;\n\tif (v97) goto L_0094;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v127[v102 @ X22_v6 (System.Int32)]);\n\treturn;\nL_0094:\n\tv277 = new System.IndexOutOfRangeException();\n\tthrow v277;\n\tthrow System.NullReferenceException;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoTagSwitch()
		{
			GameObject value = gameObject.Value;
			if (value == null)
			{
				return;
			}
			FsmString[] array = compareTo;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				string tag = value.tag;
				FsmString[] array2 = compareTo;
				if (num >= array2.Length)
				{
					break;
				}
				string value2 = array2[num].Value;
				if (!(tag == value2))
				{
					array = compareTo;
					num++;
					if (compareTo == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				FsmEvent[] array3 = sendEvent;
				if (num >= array3.Length)
				{
					break;
				}
				Fsm.Event(array3[num]);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000C1A")]
		[Address(RVA = "0xB7D50C", Offset = "0xB7D50C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectTagSwitch()
		{
		}
	}
}
