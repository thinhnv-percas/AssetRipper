using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755780", Offset = "0x755780")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755780", Offset = "0x755780")]
	[Token(Token = "0x20001C9")]
	public class GetDeviceRoll : FsmStateAction
	{
		[Token(Token = "0x2000487")]
		public enum BaseOrientation
		{
			[Token(Token = "0x4002167")]
			Portrait = 0,
			[Token(Token = "0x4002168")]
			LandscapeLeft = 1,
			[Token(Token = "0x4002169")]
			LandscapeRight = 2
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AEBF4", Offset = "0x7AEBF4")]
		[Token(Token = "0x40013A3")]
		[FieldOffset(Offset = "0x4C")]
		public BaseOrientation baseOrientation;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7AEC2C", Offset = "0x7AEC2C")]
		[Token(Token = "0x40013A4")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat storeAngle;

		[Token(Token = "0x40013A5")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat limitAngle;

		[Token(Token = "0x40013A6")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat smoothing;

		[Token(Token = "0x40013A7")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x40013A8")]
		[FieldOffset(Offset = "0x6C")]
		private float lastZAngle;

		[Token(Token = "0x6000987")]
		[Address(RVA = "0xA2AA60", Offset = "0xA2AA60", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EEDB98]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021DAD]) = v40;\nL_0015:\n\tthis.storeAngle = 0;\n\tthis.baseOrientation = 1;\n\tv45 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v45);\n\tv45.useVariable = 1;\n\tthis.limitAngle = v45;\n\tv51 = HutongGames.PlayMaker.FsmFloat::op_Implicit(5f);\n\tthis.smoothing = v51;\n\tthis.everyFrame = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			storeAngle = null;
			baseOrientation = BaseOrientation.LandscapeLeft;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			limitAngle = fsmFloat;
			FsmFloat fsmFloat2 = 5f;
			smoothing = fsmFloat2;
			everyFrame = true;
		}

		[Token(Token = "0x6000988")]
		[Address(RVA = "0xA2AAF8", Offset = "0xA2AAF8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetDeviceRoll::DoGetDeviceRoll(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetDeviceRoll();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000989")]
		[Address(RVA = "0xA2AD54", Offset = "0xA2AD54", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetDeviceRoll::DoGetDeviceRoll(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetDeviceRoll();
		}

		[Token(Token = "0x600098A")]
		[Address(RVA = "0xA2AB34", Offset = "0xA2AB34", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EB37D0]);\n\tv27 = *([v26 @ X8_v39]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021DAE]) = v46;\nL_0018:\n\tv48 = UnityEngine.Input::get_acceleration();\n\tv53 = UnityEngine.Input::get_acceleration();\n\tv62 = this.baseOrientation == 2;\n\tif (v62) goto L_FFFFFFFF;\n\tv71 = this.baseOrientation == 1;\n\tif (v71) goto L_0060;\n\tv83 = this.baseOrientation == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_006E;\n\tgoto L_0046;\n\tv154 = *([v102 @ X0_v37 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0046;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v102, methodInfo, v30, v31, v32, v33, v34, v35, v53, v54, v55, v39, v40, v41, v42, v43);\nL_0046:\n\tv130 = -v53.y;\n\tgoto L_0057;\n\tgoto L_FFFFFFFF;\n\tv91 = *([v78 @ X0_v30 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_FFFFFFFF;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v78, methodInfo, v30, v31, v32, v33, v34, v35, v53, v54, v55, v39, v40, v41, v42, v43);\nL_0057:\n\tv133 = 0x6D29A0(v150, methodInfo, v30, v31, v32, v33, v34, v35, v127, v130, v53.z, v39, v40, v41, v42, v43);\n\tv220 = -v127;\n\tgoto L_006E;\nL_0060:\n\tgoto L_0066;\n\tv142 = *([v87 @ X0_v33 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0066;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v30, v31, v32, v33, v34, v35, v53, v54, v55, v39, v40, v41, v42, v43);\nL_0066:\n\tv129 = -v48;\n\tv132 = 0x6D29A0(UnityEngine.Mathf, methodInfo, v30, v31, v32, v33, v34, v35, v53.y, v129, v53.z, v39, v40, v41, v42, v43);\nL_006E:\n\tv159 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.limitAngle);\n\tv212 = v159 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_0097;\n\tv188 = HutongGames.PlayMaker.FsmFloat::get_Value(this.limitAngle);\n\tv293 = HutongGames.PlayMaker.FsmFloat::get_Value(this.limitAngle);\n\tgoto L_008D;\n\tv314 = *([v309 @ X0_v25+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_008D;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v309, v247, v30, v31, v32, v33, v34, v35, v293, v128, v55, v39, v40, v41, v42, v43);\nL_008D:\n\tv252 = -v188;\n\tv321 = v220 * 57.29578f;\n\tv250 = UnityEngine.Mathf::Clamp(v321, v252, v293);\nL_0097:\n\tv189 = HutongGames.PlayMaker.FsmFloat::get_Value(this.smoothing);\n\tv162 = v189 <= 0;\n\tif (v162) goto L_00C1;\n\tv313 = HutongGames.PlayMaker.FsmFloat::get_Value(this.smoothing);\n\tv323 = UnityEngine.Time::get_deltaTime();\n\tgoto L_00BB;\n\tv330 = *([v326 @ X0_v19+E0]);\n\tv331 = v330 == 0;\n\tv332 = ~v331;\n\tif (v332) goto L_00BB;\n\tv334 = \"il2cpp_codegen_runtime_class_init\"(v326, v295, v30, v31, v32, v33, v34, v35, v323, v197, v195, v39, v40, v41, v42, v43);\nL_00BB:\n\tv300 = v313 * v323;\n\tv298 = UnityEngine.Mathf::LerpAngle(this.lastZAngle, v220, v300);\nL_00C1:\n\tv244 = this.storeAngle;\n\tthis.lastZAngle = v220;\n\tv244.value = v220;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetDeviceRoll()
		{
			//IL_0098: Expected I, but got O
			//IL_00c0: Unsupported input type for neg.
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c5: Expected O, but got Unknown
			//IL_0065: Expected I, but got O
			//IL_0078: Expected O, but got F4
			Vector3 acceleration = Input.acceleration;
			Vector3 acceleration2 = Input.acceleration;
			float num;
			float num2;
			IntPtr intPtr;
			Vector3 vector;
			if (baseOrientation != BaseOrientation.LandscapeRight)
			{
				if (baseOrientation != BaseOrientation.LandscapeLeft)
				{
					bool flag = baseOrientation == BaseOrientation.Portrait;
					bool flag2 = !flag;
					num = 0f;
					if (!flag2)
					{
						intPtr = (IntPtr)typeof(Mathf);
						vector = (Vector3)(0f - acceleration2.y);
						num2 = acceleration.x;
						goto IL_0245;
					}
				}
				else
				{
					object obj = 0 - acceleration;
					Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
					num = acceleration2.y;
				}
				goto IL_00e6;
			}
			intPtr = (IntPtr)typeof(Mathf);
			num2 = acceleration2.y;
			vector = acceleration;
			goto IL_0245;
			IL_00e6:
			if (!limitAngle.IsNone)
			{
				float value = limitAngle.Value;
				float value2 = limitAngle.Value;
				float min = 0f - value;
				float value3 = num * 57.29578f;
				float num3 = Mathf.Clamp(value3, min, value2);
				num = num3;
			}
			float value4 = smoothing.Value;
			if (value4 > 0f)
			{
				float value5 = smoothing.Value;
				float deltaTime = Time.deltaTime;
				float t = value5 * deltaTime;
				float num4 = Mathf.LerpAngle(lastZAngle, num, t);
				num = num4;
			}
			FsmFloat fsmFloat = storeAngle;
			lastZAngle = num;
			fsmFloat.Value = num;
			return;
			IL_0245:
			Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
			num = 0f - num2;
			goto IL_00e6;
		}

		[Token(Token = "0x600098B")]
		[Address(RVA = "0xA2AD58", Offset = "0xA2AD58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetDeviceRoll()
		{
		}
	}
}
