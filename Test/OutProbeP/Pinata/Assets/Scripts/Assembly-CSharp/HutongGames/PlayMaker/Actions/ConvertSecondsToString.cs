using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75507C", Offset = "0x75507C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75507C", Offset = "0x75507C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75507C", Offset = "0x75507C")]
	[Token(Token = "0x20001B2")]
	public class ConvertSecondsToString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ADDFC", Offset = "0x7ADDFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADDFC", Offset = "0x7ADDFC")]
		[Token(Token = "0x4001364")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat secondsVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ADE5C", Offset = "0x7ADE5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADE5C", Offset = "0x7ADE5C")]
		[Token(Token = "0x4001365")]
		[FieldOffset(Offset = "0x58")]
		public FsmString stringVariable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADEBC", Offset = "0x7ADEBC")]
		[Token(Token = "0x4001366")]
		[FieldOffset(Offset = "0x60")]
		public FsmString format;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ADF08", Offset = "0x7ADF08")]
		[Token(Token = "0x4001367")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000938")]
		[Address(RVA = "0xA929F0", Offset = "0xA929F0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED22C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022203]) = v38;\nL_0013:\n\tthis.everyFrame = 0;\n\tthis.secondsVariable = 0;\n\tthis.stringVariable = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"{1:D2}h:{2:D2}m:{3:D2}s:{10}ms\");\n\tthis.format = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			secondsVariable = null;
			stringVariable = null;
			FsmString fsmString = "{1:D2}h:{2:D2}m:{3:D2}s:{10}ms";
			format = fsmString;
		}

		[Token(Token = "0x6000939")]
		[Address(RVA = "0xA92A50", Offset = "0xA92A50", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertSecondsToString::DoConvertSecondsToString(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertSecondsToString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600093A")]
		[Address(RVA = "0xA92F1C", Offset = "0xA92F1C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertSecondsToString::DoConvertSecondsToString(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertSecondsToString();
		}

		[Token(Token = "0x600093B")]
		[Address(RVA = "0xA92A8C", Offset = "0xA92A8C", Length = "0x490")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_0018;\n\tv28 = *([1EE5A68]);\n\tv29 = *([v28 @ X8_v59]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022204]) = v48;\nL_0018:\n\t*([v18 @ X29_v1-38]) = 0;\n\tv53 = HutongGames.PlayMaker.FsmFloat::get_Value(this.secondsVariable);\n\tgoto L_002E;\n\tv230 = *([v154 @ X0_v8+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_002E;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v154, v52, v32, v33, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\nL_002E:\n\tv238 = System.TimeSpan::FromSeconds(v53);\n\t*([v18 @ X29_v1-38]) = v238;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tthis = 0x9BD0F0(this, 0, v32, v33, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\tv138 = 0xDC3590(&this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), \"D3\", 0, v33, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\tv139 = System.String::PadLeft(v138, 2, 0x30);\n\tv215 = System.String::Substring(v139, 0, 2);\n\tv118 = this.stringVariable;\n\tv291 = HutongGames.PlayMaker.FsmString::get_Value(this.format);\n\t// 84 NewArr v297 @ X0_v21 (System.Object[]), typeof(System.Object[]), 11\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tthis = 0x9BD07C(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 95 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Int32), &this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\n\tv303 = this == 0;\n\tif (v303) goto L_006C;\n\t// 104 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_006C:\n\tv314 = v297.Length == 0;\n\tif (v314) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[0] = this;\n\tthis = 0x9BD0A8(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 118 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Int32), &this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\n\tv542 = this == 0;\n\tif (v542) goto L_0081;\n\t// 125 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_0081:\n\tv545 = v297.Length < 1;\n\tv407 = ~v545;\n\tv397 = v297.Length - 1;\n\tv377 = v397 == 0;\n\tv546 = ~v407;\n\tv327 = v546 | v377;\n\tif (v327) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[1] = this;\n\tthis = 0x9BD13C(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 149 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Int32), &this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\n\tv554 = this == 0;\n\tif (v554) goto L_00A0;\n\t// 156 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_00A0:\n\tv557 = v297.Length < 2;\n\tv408 = ~v557;\n\tv398 = v297.Length - 2;\n\tv378 = v398 == 0;\n\tv558 = ~v408;\n\tv328 = v558 | v378;\n\tif (v328) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[2] = this;\n\tthis = 0x9BD184(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 180 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Int32), &this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\n\tv566 = this == 0;\n\tif (v566) goto L_00BF;\n\t// 187 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_00BF:\n\tv569 = v297.Length < 3;\n\tv409 = ~v569;\n\tv399 = v297.Length - 3;\n\tv379 = v399 == 0;\n\tv570 = ~v409;\n\tv329 = v570 | v379;\n\tif (v329) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[3] = this;\n\tthis = 0x9BD0F0(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 211 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Int32), &this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\n\tv578 = this == 0;\n\tif (v578) goto L_00DE;\n\t// 218 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_00DE:\n\tv581 = v297.Length < 4;\n\tv410 = ~v581;\n\tv400 = v297.Length - 4;\n\tv380 = v400 == 0;\n\tv582 = ~v410;\n\tv330 = v582 | v380;\n\tif (v330) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[4] = this;\n\tthis = 0x9BD1D0(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 243 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Double), &v53 @ V0_v3 (System.Single)\n\tv590 = this == 0;\n\tif (v590) goto L_00FE;\n\t// 250 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_00FE:\n\tv593 = v297.Length < 5;\n\tv411 = ~v593;\n\tv401 = v297.Length - 5;\n\tv381 = v401 == 0;\n\tv594 = ~v411;\n\tv331 = v594 | v381;\n\tif (v331) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[5] = this;\n\tthis = 0x9BD1E8(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 273 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Double), &v53 @ V0_v3 (System.Single)\n\tv601 = this == 0;\n\tif (v601) goto L_011C;\n\t// 280 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_011C:\n\tv604 = v297.Length < 6;\n\tv412 = ~v604;\n\tv402 = v297.Length - 6;\n\tv382 = v402 == 0;\n\tv605 = ~v412;\n\tv332 = v605 | v382;\n\tif (v332) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[6] = this;\n\tthis = 0x9BD200(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 303 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Double), &v53 @ V0_v3 (System.Single)\n\tv612 = this == 0;\n\tif (v612) goto L_013A;\n\t// 310 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_013A:\n\tv615 = v297.Length < 7;\n\tv413 = ~v615;\n\tv403 = v297.Length - 7;\n\tv383 = v403 == 0;\n\tv616 = ~v413;\n\tv333 = v616 | v383;\n\tif (v333) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[7] = this;\n\tthis = 0x9BD218(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 333 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Double), &v53 @ V0_v3 (System.Single)\n\tv623 = this == 0;\n\tif (v623) goto L_0158;\n\t// 340 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_0158:\n\tv626 = v297.Length < 8;\n\tv414 = ~v626;\n\tv404 = v297.Length - 8;\n\tv384 = v404 == 0;\n\tv627 = ~v414;\n\tv334 = v627 | v384;\n\tif (v334) goto L_01AB;\n\tthis = &v19 @ stack_-10_v2 - 0x38;\n\tv297[8] = this;\n\tthis = 0x9B7F4C(this, 0, 2, 0, v34, v35, v36, v37, v53, v39, v40, v41, v42, v43, v44, v45);\n\t// 363 Box this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Double), &v53 @ V0_v3 (System.Single)\n\tv634 = this == 0;\n\tif (v634) goto L_0175;\n\t// 370 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString)\nL_0175:\n\tv226 = v297.Length;\n\tv637 = v297.Length < 9;\n\tv415 = ~v637;\n\tv405 = v297.Length - 9;\n\tv385 = v405 == 0;\n\tv638 = ~v415;\n\tv335 = v638 | v385;\n\tif (v335) goto L_01AB;\n\tv297[9] = this;\n\tv639 = v215 == 0;\n\tif (v639) goto L_018C;\n\t// 392 IsInst this @ X0 (HutongGames.PlayMaker.Actions.ConvertSecondsToString), typeof(System.Object), v215 @ X0_v17 (System.String)\n\tv226 = v297.Length;\nL_018C:\n\tv642 = v226 < 0xA;\n\tv191 = ~v642;\n\tv189 = v226 - 0xA;\n\tv185 = v189 == 0;\n\tv643 = ~v191;\n\tv175 = v643 | v185;\n\tif (v175) goto L_01AB;\n\tv297[10] = v215;\n\tv217 = System.String::Fo\n// ... truncated")]
		private void DoConvertSecondsToString()
		{
			//IL_0042: Expected O, but got I
			//IL_00dd: Expected O, but got I
			//IL_00f2: Expected I4, but got O
			//IL_0152: Expected O, but got I
			//IL_0176: Expected I4, but got O
			//IL_01d4: Expected O, but got I4
			//IL_0218: Expected O, but got I
			//IL_023c: Expected I4, but got O
			//IL_029a: Expected O, but got I4
			//IL_02de: Expected O, but got I
			//IL_0302: Expected I4, but got O
			//IL_0360: Expected O, but got I4
			//IL_03a4: Expected O, but got I
			//IL_03c8: Expected I4, but got O
			//IL_0426: Expected O, but got I4
			//IL_046a: Expected O, but got I
			//IL_04ef: Expected O, but got I4
			//IL_0533: Expected O, but got I
			//IL_05b8: Expected O, but got I4
			//IL_05fc: Expected O, but got I
			//IL_0681: Expected O, but got I4
			//IL_06c5: Expected O, but got I
			//IL_074a: Expected O, but got I4
			//IL_078e: Expected O, but got I
			//IL_07f1: Expected O, but got I4
			//IL_081d: Expected O, but got I4
			//IL_091c: Expected O, but got I
			//IL_089a: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			float value = secondsVariable.Value;
			TimeSpan timeSpan = TimeSpan.FromSeconds(value);
			ConvertSecondsToString convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD0F0 (inside System.TimeSpan::TimeToTicks +0x170)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3590 (inside System.InvalidCastException::.ctor +0x2B8)");
			string text2 = default(string);
			string text = text2.PadLeft(2, '0');
			string text3 = text.Substring(0, 2);
			FsmString fsmString = stringVariable;
			string value2 = format.Value;
			object[] array = new object[11];
			convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD07C (inside System.TimeSpan::TimeToTicks +0xFC)");
			convertSecondsToString = (ConvertSecondsToString)(object)(int)this;
			if (this != null)
			{
				convertSecondsToString = (ConvertSecondsToString)(this as object);
			}
			if (array.Length != 0)
			{
				convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
				array[0] = this;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD0A8 (inside System.TimeSpan::TimeToTicks +0x128)");
				convertSecondsToString = (ConvertSecondsToString)(object)(int)this;
				if (this != null)
				{
					convertSecondsToString = (ConvertSecondsToString)(this as object);
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj3 = array.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
					array[1] = this;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD13C (inside System.TimeSpan::TimeToTicks +0x1BC)");
					convertSecondsToString = (ConvertSecondsToString)(object)(int)this;
					if (this != null)
					{
						convertSecondsToString = (ConvertSecondsToString)(this as object);
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj4 = array.Length - 2;
					bool flag7 = obj4 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
						array[2] = this;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD184 (inside System.TimeSpan::TimeToTicks +0x204)");
						convertSecondsToString = (ConvertSecondsToString)(object)(int)this;
						if (this != null)
						{
							convertSecondsToString = (ConvertSecondsToString)(this as object);
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj5 = array.Length - 3;
						bool flag11 = obj5 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
							array[3] = this;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD0F0 (inside System.TimeSpan::TimeToTicks +0x170)");
							convertSecondsToString = (ConvertSecondsToString)(object)(int)this;
							if (this != null)
							{
								convertSecondsToString = (ConvertSecondsToString)(this as object);
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj6 = array.Length - 4;
							bool flag15 = obj6 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
								array[4] = this;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD1D0 (inside System.TimeSpan::TimeToTicks +0x250)");
								convertSecondsToString = (ConvertSecondsToString)(object)(double)value;
								if (this != null)
								{
									convertSecondsToString = (ConvertSecondsToString)(this as object);
								}
								bool flag17 = array.Length < 5;
								bool flag18 = !flag17;
								object obj7 = array.Length - 5;
								bool flag19 = obj7 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
									array[5] = this;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD1E8 (inside System.TimeSpan::TimeToTicks +0x268)");
									convertSecondsToString = (ConvertSecondsToString)(object)(double)value;
									if (this != null)
									{
										convertSecondsToString = (ConvertSecondsToString)(this as object);
									}
									bool flag21 = array.Length < 6;
									bool flag22 = !flag21;
									object obj8 = array.Length - 6;
									bool flag23 = obj8 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
										array[6] = this;
										Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD200 (inside System.TimeSpan::TimeToTicks +0x280)");
										convertSecondsToString = (ConvertSecondsToString)(object)(double)value;
										if (this != null)
										{
											convertSecondsToString = (ConvertSecondsToString)(this as object);
										}
										bool flag25 = array.Length < 7;
										bool flag26 = !flag25;
										object obj9 = array.Length - 7;
										bool flag27 = obj9 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
											array[7] = this;
											Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD218 (inside System.TimeSpan::TimeToTicks +0x298)");
											convertSecondsToString = (ConvertSecondsToString)(object)(double)value;
											if (this != null)
											{
												convertSecondsToString = (ConvertSecondsToString)(this as object);
											}
											bool flag29 = array.Length < 8;
											bool flag30 = !flag29;
											object obj10 = array.Length - 8;
											bool flag31 = obj10 == null;
											bool flag32 = !flag30;
											if (!(flag32 || flag31))
											{
												convertSecondsToString = (ConvertSecondsToString)((long)(IntPtr)obj2 - 56L);
												array[8] = this;
												Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9B7F4C (inside System.Threading.ThreadPool::RegisterWaitForSingleObject +0x134)");
												convertSecondsToString = (ConvertSecondsToString)(object)(double)value;
												if (this != null)
												{
													convertSecondsToString = (ConvertSecondsToString)(this as object);
												}
												object obj11 = array.Length;
												bool flag33 = array.Length < 9;
												bool flag34 = !flag33;
												object obj12 = array.Length - 9;
												bool flag35 = obj12 == null;
												bool flag36 = !flag34;
												if (!(flag36 || flag35))
												{
													array[9] = this;
													if (text3 != null)
													{
														convertSecondsToString = (ConvertSecondsToString)(text3 as object);
														obj11 = array.Length;
													}
													bool flag37 = (long)(IntPtr)obj11 < 10L;
													bool flag38 = !flag37;
													object obj13 = (long)(IntPtr)obj11 - 10L;
													bool flag39 = obj13 == null;
													bool flag40 = !flag38;
													if (!(flag40 || flag39))
													{
														array[10] = text3;
														string value3 = string.Format(value2, array);
														fsmString.Value = value3;
														return;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600093C")]
		[Address(RVA = "0xA92F20", Offset = "0xA92F20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertSecondsToString()
		{
		}
	}
}
