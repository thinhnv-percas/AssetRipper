using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758B0C", Offset = "0x758B0C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758B0C", Offset = "0x758B0C")]
	[Token(Token = "0x2000265")]
	public class GameObjectChanged : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B61D4", Offset = "0x7B61D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B61D4", Offset = "0x7B61D4")]
		[Token(Token = "0x4001629")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObjectVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B6234", Offset = "0x7B6234")]
		[Token(Token = "0x400162A")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent changedEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B626C", Offset = "0x7B626C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B626C", Offset = "0x7B626C")]
		[Token(Token = "0x400162B")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool storeResult;

		[Token(Token = "0x400162C")]
		[FieldOffset(Offset = "0x68")]
		private GameObject previousValue;

		[Token(Token = "0x6000BF5")]
		[Address(RVA = "0xB7C920", Offset = "0xB7C920", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.changedEvent = 0;\n\tthis.storeResult = 0;\n\tthis.gameObjectVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			changedEvent = null;
			storeResult = null;
			gameObjectVariable = null;
		}

		[Token(Token = "0x6000BF6")]
		[Address(RVA = "0xB7C92C", Offset = "0xB7C92C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.gameObjectVariable);\n\tv36 = v13 == 0;\n\tif (v36) goto L_001A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectVariable);\n\tthis.previousValue = v48;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (gameObjectVariable.IsNone)
			{
				Finish();
				return;
			}
			GameObject value = gameObjectVariable.Value;
			previousValue = value;
		}

		[Token(Token = "0x6000BF7")]
		[Address(RVA = "0xB7C988", Offset = "0xB7C988", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EA6048]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022976]) = v40;\nL_0014:\n\tv41 = this.storeResult;\n\tv41.value = 0;\n\tv64 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObjectVariable);\n\tgoto L_002F;\n\tv83 = *([v79 @ X8_v8+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_002F;\n\tv114 = v79;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v114, v63, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tv55 = UnityEngine.Object::op_Inequality(v64, this.previousValue);\n\tv103 = v55 == 0;\n\tif (v103) goto L_004B;\n\tv59 = this.storeResult;\n\tv59.value = 1;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.changedEvent);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			FsmBool fsmBool = storeResult;
			fsmBool.value = false;
			GameObject value = gameObjectVariable.Value;
			if (value != previousValue)
			{
				FsmBool fsmBool2 = storeResult;
				fsmBool2.value = true;
				Fsm.Event(changedEvent);
			}
		}

		[Token(Token = "0x6000BF8")]
		[Address(RVA = "0xB7CA64", Offset = "0xB7CA64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectChanged()
		{
		}
	}
}
