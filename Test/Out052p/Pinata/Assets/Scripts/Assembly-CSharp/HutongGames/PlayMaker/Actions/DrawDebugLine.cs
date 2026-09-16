using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755500", Offset = "0x755500")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755500", Offset = "0x755500")]
	[Token(Token = "0x20001C1")]
	public class DrawDebugLine : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE718", Offset = "0x7AE718")]
		[Token(Token = "0x400138A")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject fromObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE750", Offset = "0x7AE750")]
		[Token(Token = "0x400138B")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 fromPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE788", Offset = "0x7AE788")]
		[Token(Token = "0x400138C")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject toObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE7C0", Offset = "0x7AE7C0")]
		[Token(Token = "0x400138D")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 toPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE7F8", Offset = "0x7AE7F8")]
		[Token(Token = "0x400138E")]
		[FieldOffset(Offset = "0x70")]
		public FsmColor color;

		[Token(Token = "0x600096B")]
		[Address(RVA = "0xB7079C", Offset = "0xB7079C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1ECFA68]);\n\tv25 = *([v24 @ X8_v4]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20228F8]) = v44;\nL_0019:\n\tv48 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.fromObject = v48;\n\tv56 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v56);\n\tv56.useVariable = 1;\n\tthis.fromPosition = v56;\n\tv66 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v66);\n\tv66.useVariable = 1;\n\tthis.toObject = v66;\n\tv67 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v67);\n\tv67.useVariable = 1;\n\tthis.toPosition = v67;\n\tv90 = UnityEngine.Color::get_white();\n\tv99 = HutongGames.PlayMaker.FsmColor::op_Implicit(v90);\n\tthis.color = v99;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			fromObject = fsmGameObject;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			FsmGameObject fsmGameObject2 = new FsmGameObject();
			fsmGameObject2.useVariable = true;
			toObject = fsmGameObject2;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			toPosition = fsmVector2;
			Color white = Color.white;
			FsmColor fsmColor = white;
			color = fsmColor;
		}

		[Token(Token = "0x600096C")]
		[Address(RVA = "0xB708A0", Offset = "0xB708A0", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EC4968]);\n\tv35 = *([v34 @ X8_v8]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20228F9]) = v54;\nL_001E:\n\tv58 = HutongGames.PlayMaker.ActionHelpers::GetPosition(this.fromObject, this.fromPosition);\n\tv67 = HutongGames.PlayMaker.ActionHelpers::GetPosition(this.toObject, this.toPosition);\n\tv70 = this.color;\n\tgoto L_004D;\n\tv87 = *([v81 @ X0_v6+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_004D;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v81, v64, v65, v39, v40, v41, v42, v43, v67, v68, v69, v47, v48, v49, v50, v51);\nL_004D:\n\tUnityEngine.Debug::DrawLine(v58, v67, v70.value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			Vector3 position = ActionHelpers.GetPosition(fromObject, fromPosition);
			Vector3 position2 = ActionHelpers.GetPosition(toObject, toPosition);
			FsmColor fsmColor = color;
			Debug.DrawLine(position, position2, fsmColor.value);
		}

		[Token(Token = "0x600096D")]
		[Address(RVA = "0xB70990", Offset = "0xB70990", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DrawDebugLine()
		{
		}
	}
}
