using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757AF8", Offset = "0x757AF8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757AF8", Offset = "0x757AF8")]
	[Token(Token = "0x2000236")]
	public class GetAxis : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B317C", Offset = "0x7B317C")]
		[Token(Token = "0x4001554")]
		[FieldOffset(Offset = "0x50")]
		public FsmString axisName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B31C8", Offset = "0x7B31C8")]
		[Token(Token = "0x4001555")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat multiplier;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3200", Offset = "0x7B3200")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3200", Offset = "0x7B3200")]
		[Token(Token = "0x4001556")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat store;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3260", Offset = "0x7B3260")]
		[Token(Token = "0x4001557")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000B1C")]
		[Address(RVA = "0xB831D8", Offset = "0xB831D8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED84B0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229D1]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.axisName = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.multiplier = v46;\n\tthis.store = 0;\n\tthis.everyFrame = 1;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "";
			axisName = fsmString;
			FsmFloat fsmFloat = 1f;
			multiplier = fsmFloat;
			store = null;
			everyFrame = true;
		}

		[Token(Token = "0x6000B1D")]
		[Address(RVA = "0xB83248", Offset = "0xB83248", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAxis::DoGetAxis(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetAxis();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B1E")]
		[Address(RVA = "0xB83314", Offset = "0xB83314", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetAxis::DoGetAxis(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetAxis();
		}

		[Token(Token = "0x6000B1F")]
		[Address(RVA = "0xB83284", Offset = "0xB83284", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmString::IsNullOrEmpty(this.axisName);\n\tv16 = v14 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_002E;\n\tv39 = HutongGames.PlayMaker.FsmString::get_Value(this.axisName);\n\tv43 = UnityEngine.Input::GetAxis(v39);\n\tv84 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.multiplier);\n\tv86 = v84 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0025;\n\tv89 = HutongGames.PlayMaker.FsmFloat::get_Value(this.multiplier);\n\tv24 = v43 * v89;\nL_0025:\n\tv21 = this.store;\n\tv21.value = v24;\nL_002E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetAxis()
		{
			if (!FsmString.IsNullOrEmpty(axisName))
			{
				string value = axisName.Value;
				float axis = Input.GetAxis(value);
				bool isNone = multiplier.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				float value2 = axis;
				if (!flag2)
				{
					float value3 = multiplier.Value;
					value2 = axis * value3;
				}
				FsmFloat fsmFloat = store;
				fsmFloat.Value = value2;
			}
		}

		[Token(Token = "0x6000B20")]
		[Address(RVA = "0xB83318", Offset = "0xB83318", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAxis()
		{
		}
	}
}
