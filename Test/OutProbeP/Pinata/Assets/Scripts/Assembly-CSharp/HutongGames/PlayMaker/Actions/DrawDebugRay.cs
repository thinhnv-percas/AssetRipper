using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755550", Offset = "0x755550")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x755550", Offset = "0x755550")]
	[Token(Token = "0x20001C2")]
	public class DrawDebugRay : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE830", Offset = "0x7AE830")]
		[Token(Token = "0x400138F")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject fromObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE868", Offset = "0x7AE868")]
		[Token(Token = "0x4001390")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 fromPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE8A0", Offset = "0x7AE8A0")]
		[Token(Token = "0x4001391")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 direction;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7AE8D8", Offset = "0x7AE8D8")]
		[Token(Token = "0x4001392")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor color;

		[Token(Token = "0x600096E")]
		[Address(RVA = "0xB70998", Offset = "0xB70998", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EAE4E0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20228FA]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromObject = v46;\n\tv54 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.fromPosition = v54;\n\tv61 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.direction = v61;\n\tv82 = UnityEngine.Color::get_white();\n\tv89 = HutongGames.PlayMaker.FsmColor::op_Implicit(v82);\n\tthis.color = v89;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = true;
			fromObject = fsmGameObject;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			direction = fsmVector2;
			Color white = Color.white;
			FsmColor fsmColor = white;
			color = fsmColor;
		}

		[Token(Token = "0x600096F")]
		[Address(RVA = "0xB70A74", Offset = "0xB70A74", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1ECE860]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20228FB]) = v54;\nL_001E:\n\tv58 = HutongGames.PlayMaker.ActionHelpers::GetPosition(this.fromObject, this.fromPosition);\n\tv67 = HutongGames.PlayMaker.FsmVector3::get_Value(this.direction);\n\tv71 = this.color;\n\tgoto L_004E;\n\tv103 = *([v99 @ X0_v8+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_004E;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v99, v63, v57, v39, v40, v41, v42, v43, v67, v69, v70, v47, v48, v49, v50, v51);\nL_004E:\n\tUnityEngine.Debug::DrawRay(v58, v67, v71.value);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			Vector3 position = ActionHelpers.GetPosition(fromObject, fromPosition);
			Vector3 value = direction.Value;
			FsmColor fsmColor = color;
			Debug.DrawRay(position, value, fsmColor.value);
		}

		[Token(Token = "0x6000970")]
		[Address(RVA = "0xB70B6C", Offset = "0xB70B6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DrawDebugRay()
		{
		}
	}
}
