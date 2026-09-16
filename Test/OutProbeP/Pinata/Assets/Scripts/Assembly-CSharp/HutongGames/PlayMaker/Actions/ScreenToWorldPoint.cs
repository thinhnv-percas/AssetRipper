using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7547BC", Offset = "0x7547BC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7547BC", Offset = "0x7547BC")]
	[Token(Token = "0x2000195")]
	public class ScreenToWorldPoint : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABA44", Offset = "0x7ABA44")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABA44", Offset = "0x7ABA44")]
		[Token(Token = "0x40012D3")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 screenVector;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABA94", Offset = "0x7ABA94")]
		[Token(Token = "0x40012D4")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat screenX;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABACC", Offset = "0x7ABACC")]
		[Token(Token = "0x40012D5")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat screenY;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABB04", Offset = "0x7ABB04")]
		[Token(Token = "0x40012D6")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat screenZ;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABB3C", Offset = "0x7ABB3C")]
		[Token(Token = "0x40012D7")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool normalized;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABB74", Offset = "0x7ABB74")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABB74", Offset = "0x7ABB74")]
		[Token(Token = "0x40012D8")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector3 storeWorldVector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABBC4", Offset = "0x7ABBC4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABBC4", Offset = "0x7ABBC4")]
		[Token(Token = "0x40012D9")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat storeWorldX;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABC14", Offset = "0x7ABC14")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABC14", Offset = "0x7ABC14")]
		[Token(Token = "0x40012DA")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat storeWorldY;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ABC64", Offset = "0x7ABC64")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABC64", Offset = "0x7ABC64")]
		[Token(Token = "0x40012DB")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat storeWorldZ;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ABCB4", Offset = "0x7ABCB4")]
		[Token(Token = "0x40012DC")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x60008A6")]
		[Address(RVA = "0xB26004", Offset = "0xB26004", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED62A8]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20225DB]) = v42;\nL_0015:\n\tthis.screenVector = 0;\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.screenX = v46;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.screenY = v52;\n\tv83 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.screenZ = v83;\n\tv74 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.everyFrame = 0;\n\tthis.normalized = v74;\n\tthis.storeWorldVector = 0;\n\tthis.storeWorldY = 0;\n\tthis.storeWorldZ = 0;\n\tthis.storeWorldX = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			screenVector = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			screenX = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			screenY = fsmFloat2;
			FsmFloat fsmFloat3 = 1f;
			screenZ = fsmFloat3;
			FsmBool fsmBool = false;
			everyFrame = false;
			normalized = fsmBool;
			storeWorldVector = null;
			storeWorldY = null;
			storeWorldZ = null;
			storeWorldX = null;
		}

		[Token(Token = "0x60008A7")]
		[Address(RVA = "0xB260D0", Offset = "0xB260D0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ScreenToWorldPoint::DoScreenToWorldPoint(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoScreenToWorldPoint();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008A8")]
		[Address(RVA = "0xB26344", Offset = "0xB26344", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ScreenToWorldPoint::DoScreenToWorldPoint(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoScreenToWorldPoint();
		}

		[Token(Token = "0x60008A9")]
		[Address(RVA = "0xB2610C", Offset = "0xB2610C", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAED28]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225DC]) = v44;\nL_0017:\n\tv46 = UnityEngine.Camera::get_main();\n\tgoto L_0029;\n\tv54 = *([v50 @ X8_v5+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv65 = v50;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0029:\n\tv64 = UnityEngine.Object::op_Equality(v46, 0);\n\tv67 = v64 == 0;\n\tif (v67) goto L_0045;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"No MainCamera defined!\");\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0045:\n\tgoto L_004C;\n\tv88 = *([v75 @ X0_v7+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_004C;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v75, v62, v63, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004C:\n\tv96 = UnityEngine.Vector3::get_zero();\n\tv148 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenVector);\n\tv200 = v148 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0069;\n\tv212 = HutongGames.PlayMaker.FsmVector3::get_Value(this.screenVector);\nL_0069:\n\tv219 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenX);\n\tv221 = v219 == 0;\n\tv222 = ~v221;\n\tif (v222) goto L_0078;\n\tv223 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenX);\nL_0078:\n\tv228 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenY);\n\tv230 = v228 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_0087;\n\tv232 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenY);\nL_0087:\n\tv237 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.screenZ);\n\tv239 = v237 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_0096;\n\tv241 = HutongGames.PlayMaker.FsmFloat::get_Value(this.screenZ);\nL_0096:\n\tv246 = HutongGames.PlayMaker.FsmBool::get_Value(this.normalized);\n\tv248 = v246 == 0;\n\tif (v248) goto L_00A3;\n\tv250 = UnityEngine.Screen::get_width();\n\tv252 = v164 * v250;\n\tv255 = UnityEngine.Screen::get_height();\n\tv169 = v169 * v255;\nL_00A3:\n\tv133 = UnityEngine.Camera::get_main();\n\t// 170 MakeStruct v106 @ AGGB262EC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v164 @ V8_v5 (UnityEngine.Vector3), v169 @ V9_v6 (System.Single), v161 @ V10_v5 (System.Single)\n\tv115 = UnityEngine.Camera::ScreenToWorldPoint(v133, v106);\n\tv206 = this.storeWorldVector;\n\tv206.value = v115;\n\tv206.value.y = v115.y;\n\tv206.value.z = v115.z;\n\tv207 = this.storeWorldX;\n\tv207.value = v115;\n\tv208 = this.storeWorldY;\n\tv208.value = v115.y;\n\tv141 = this.storeWorldZ;\n\tv141.value = v115.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoScreenToWorldPoint()
		{
			//IL_0137: Expected O, but got F4
			//IL_0252: Expected O, but got F4
			Camera main = Camera.main;
			if (main == null)
			{
				LogError("No MainCamera defined!");
				Finish();
				return;
			}
			Vector3 zero = Vector3.zero;
			bool isNone = screenVector.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float z = zero.z;
			Vector3 vector = zero;
			float num = zero.y;
			if (!flag2)
			{
				Vector3 value = screenVector.Value;
				z = value.z;
				vector = value;
				num = value.y;
			}
			if (!screenX.IsNone)
			{
				float value2 = screenX.Value;
				vector = (Vector3)value2;
			}
			if (!screenY.IsNone)
			{
				float value3 = screenY.Value;
				num = value3;
			}
			if (!screenZ.IsNone)
			{
				float value4 = screenZ.Value;
				z = value4;
			}
			if (normalized.Value)
			{
				int width = Screen.width;
				float num2 = vector.x * (float)width;
				int height = Screen.height;
				num *= (float)height;
				vector = (Vector3)num2;
			}
			Camera main2 = Camera.main;
			Vector3 position = default(Vector3);
			position.x = vector.x;
			position.y = num;
			position.z = z;
			Vector3 value5 = main2.ScreenToWorldPoint(position);
			FsmVector3 fsmVector = storeWorldVector;
			fsmVector.value = value5;
			fsmVector.value.y = value5.y;
			fsmVector.value.z = value5.z;
			FsmFloat fsmFloat = storeWorldX;
			fsmFloat.Value = value5.x;
			FsmFloat fsmFloat2 = storeWorldY;
			fsmFloat2.Value = value5.y;
			FsmFloat fsmFloat3 = storeWorldZ;
			fsmFloat3.Value = value5.z;
		}

		[Token(Token = "0x60008AA")]
		[Address(RVA = "0xB26348", Offset = "0xB26348", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ScreenToWorldPoint()
		{
		}
	}
}
