using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758B5C", Offset = "0x758B5C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758B5C", Offset = "0x758B5C")]
	[Token(Token = "0x2000266")]
	public class GameObjectCompare : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B62BC", Offset = "0x7B62BC")]
		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7B62BC", Offset = "0x7B62BC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B62BC", Offset = "0x7B62BC")]
		[Token(Token = "0x400162D")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObjectVariable;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B6340", Offset = "0x7B6340")]
		[Token(Token = "0x400162E")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject compareTo;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B638C", Offset = "0x7B638C")]
		[Token(Token = "0x400162F")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent equalEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B63C4", Offset = "0x7B63C4")]
		[Token(Token = "0x4001630")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent notEqualEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B63FC", Offset = "0x7B63FC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B63FC", Offset = "0x7B63FC")]
		[Token(Token = "0x4001631")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B644C", Offset = "0x7B644C")]
		[Token(Token = "0x4001632")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000BF9")]
		[Address(RVA = "0xB7CA6C", Offset = "0xB7CA6C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeResult = 0;\n\tthis.gameObjectVariable = 0;\n\tthis.equalEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeResult = null;
			gameObjectVariable = null;
			equalEvent = null;
		}

		[Token(Token = "0x6000BFA")]
		[Address(RVA = "0xB7CA80", Offset = "0xB7CA80", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectCompare::DoGameObjectCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGameObjectCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BFB")]
		[Address(RVA = "0xB7CBB4", Offset = "0xB7CBB4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectCompare::DoGameObjectCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGameObjectCompare();
		}

		[Token(Token = "0x6000BFC")]
		[Address(RVA = "0xB7CABC", Offset = "0xB7CABC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ED20E8]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022977]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObjectVariable);\n\tv75 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.compareTo);\n\tgoto L_0032;\n\tv112 = *([v108 @ X8_v8+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_0032;\n\tv119 = v108;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v119, v74, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tv79 = UnityEngine.Object::op_Equality(v45, v75);\n\tv67 = this.storeResult;\n\tv67.value = v79;\n\tv121 = v79 == 0;\n\tif (v121) goto L_004A;\n\tv58 = this.equalEvent;\n\tv123 = this.equalEvent == 0;\n\tif (v123) goto L_0054;\nL_0048:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v58);\n\treturn;\nL_004A:\n\tv58 = this.notEqualEvent;\n\tv125 = this.notEqualEvent == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0048;\nL_0054:\n\treturn;\n\tv60 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGameObjectCompare()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObjectVariable);
			GameObject value = compareTo.Value;
			bool flag = ownerDefaultTarget == value;
			FsmBool fsmBool = storeResult;
			fsmBool.value = flag;
			FsmEvent fsmEvent;
			if (flag)
			{
				fsmEvent = equalEvent;
				if (equalEvent == null)
				{
					return;
				}
			}
			else
			{
				fsmEvent = notEqualEvent;
				if (notEqualEvent == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000BFD")]
		[Address(RVA = "0xB7CBB8", Offset = "0xB7CBB8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectCompare()
		{
		}
	}
}
