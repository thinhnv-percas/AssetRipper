using System;
using System.Collections.Generic;
using System.Xml;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Security;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000077")]
	public class SubscriptionInfo
	{
		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x10")]
		private Result is_subscribed;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x14")]
		private Result is_expired;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x18")]
		private Result is_cancelled;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x1C")]
		private Result is_free_trial;

		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0x20")]
		private Result is_auto_renewing;

		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0x24")]
		private Result is_introductory_price_period;

		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0x28")]
		private string productId;

		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x30")]
		private DateTime purchaseDate;

		[Token(Token = "0x40001D4")]
		[FieldOffset(Offset = "0x38")]
		private DateTime subscriptionExpireDate;

		[Token(Token = "0x40001D5")]
		[FieldOffset(Offset = "0x40")]
		private DateTime subscriptionCancelDate;

		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x48")]
		private TimeSpan remainedTime;

		[Token(Token = "0x40001D7")]
		[FieldOffset(Offset = "0x50")]
		private string introductory_price;

		[Token(Token = "0x40001D8")]
		[FieldOffset(Offset = "0x58")]
		private TimeSpan introductory_price_period;

		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x60")]
		private long introductory_price_cycles;

		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x68")]
		private TimeSpan freeTrialPeriod;

		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x70")]
		private TimeSpan subscriptionPeriod;

		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x78")]
		private string free_trial_period_string;

		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x80")]
		private string sku_details;

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x15AE5DC", Offset = "0x15AE5DC", Length = "0x784")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EE8538]);\n\tv31 = *([v30 @ X8_v115]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, r, intro_json, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20298AB]) = v48;\nL_001F:\n\tSystem.Object::.ctor(this);\n\tgoto L_0031;\n\tv64 = *([v57 @ X0_v3+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0031;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v57, v50, intro_json, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0031:\n\tv73 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.AppleStoreProductType);\n\tv76 = r.<productType>k__BackingField;\n\tv80 = 0xDC3560(&v76 @ X8_v74 (System.Int32), 0, intro_json, v341, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_004B;\n\tv153 = *([v85 @ X8_v77+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_004B;\n\tv196 = v85;\n\tv157 = \"il2cpp_codegen_runtime_class_init\"(v196, v79, intro_json, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_004B:\n\tv141 = System.Enum::Parse(v73, v80);\n\tv165 = v165_asT == 0;\n\tif (v165) goto L_0250;\n\tv226 = \"il2cpp_vm_object_unbox\"(v141, UnityEngine.Purchasing.AppleStoreProductType, 0, v341, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv247 = *([v226 @ X0_v88]) < 1;\n\tv219 = ~v247;\n\tv217 = *([v226 @ X0_v88]) - 1;\n\tv213 = v217 == 0;\n\tv248 = ~v219;\n\tv203 = v248 | v213;\n\tif (v203) goto L_0254;\n\tv296 = System.String::IsNullOrEmpty(intro_json);\n\tv298 = v296 == 0;\n\tif (v298) goto L_008B;\n\tthis.introductory_price = \"not available\";\n\tgoto L_0086;\n\tv312 = *([v305 @ X0_v113 (Il2CppClass<System.TimeSpan>)+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_0086;\n\tv339 = \"il2cpp_codegen_runtime_class_init\"(v305, v295, v128, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv316 = System.TimeSpan;\nL_0086:\n\tthis.introductory_price_period = v319.Zero;\n\tthis.introductory_price_cycles = 0;\n\tgoto L_016A;\nL_008B:\n\tv284 = UnityEngine.Purchasing.MiniJson::JsonDecode(intro_json);\n\tv286 = v284 == 0;\n\tif (v286) goto L_00B4;\n\tgoto L_FFFFFFFF;\n\tv254 = v254_asT == 0;\n\tif (v254) goto L_025F;\nL_00B4:\n\tv426 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v284, \"introductoryPrice\");\n\tv450 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v284, \"introductoryPriceLocale\");\n\tv470 = System.String::Concat(v426, v450);\n\tthis.introductory_price = v470;\n\tv547 = System.String::IsNullOrEmpty(v470);\n\tv611 = v547 == 0;\n\tif (v611) goto L_00D2;\n\tthis.introductory_price = \"not available\";\n\tgoto L_00FC;\nL_00D2:\n\tv644 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v284, \"introductoryPriceNumberOfPeriods\");\n\tgoto L_00E2;\n\tv762 = *([v738 @ X0_v102+E0]);\n\tv763 = v762 == 0;\n\tv764 = ~v763;\n\tif (v764) goto L_00E2;\n\tv766 = \"il2cpp_codegen_runtime_class_init\"(v738, v641, v643, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00E2:\n\tv770 = System.Convert::ToInt64(v644);\n\tthis.introductory_price_cycles = v770;\n\tv825 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v284, \"numberOfUnits\");\n\tv862 = System.Convert::ToInt32(v825);\n\tv882 = UnityEngine.Purchasing.SerializationExtensions::TryGetString(v284, \"unit\");\n\tv719 = System.Convert::ToInt32(v882);\nL_00FC:\n\tgoto L_0103;\n\tv756 = *([v731 @ X0_v41+E0]);\n\tv757 = v756 == 0;\n\tv758 = ~v757;\n\tgoto L_0103;\n\tv760 = \"il2cpp_codegen_runtime_class_init\"(v731, v383, v377, v341, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0103:\n\tv387 = System.DateTime::get_Now();\n\tv818 = v397 < 4;\n\tv375 = ~v818;\n\tv373 = v397 - 4;\n\tv369 = v373 == 0;\n\tv819 = ~v369;\n\tv359 = v375 & v819;\n\tif (v359) goto L_016A;\n\tv520 = 0x183B000 + 0xBE4;\n\tv76 = *([v520 @ X9_v12 (System.Int32)+v397 @ X22_v6 (System.Int32)*4]);\n\tv76 = v76 + v520;\n\t// 278 IndirectJump v76 @ X8_v74 (System.Int32), v387 @ X0_v44 (System.DateTime), v387 @ X0_v44 (System.DateTime), v383 @ X1_v17 (System.String), v376 @ X2_v1 (Il2CppMethodInfo), 0, v34 @ X4, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0123;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0123;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0123:\n\tV0 = 1d;\n\tgoto L_015D;\n\tX0 = &stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = 0xE94CC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_012E;\n\tX0 = &stack[18];\n\tX1 = 0 | 1;\n\tX2 = 0;\n\tX0 = 0xE946C8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_012E:\n\tX8 = *([X23]);\n\tX22 = stack[18];\n\tX23 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_013B;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_013B;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013B:\n\tX0 = X23;\n\tX1 = X22;\n\tX2 = 0;\n\tX0 = System.DateTime::op_Subtraction(X0, X1, X2);\n\tX8 = *([1ED4850]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_014D;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014D;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014D:\n\tX8 = X21;\n\tX0 = X22 * X8;\n\tgoto L_0161;\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_015C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_015C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_015C:\n\tV0 = 4.000000000698492d;\nL_015D:\n\tX0 = 0;\n\tX0 = System.TimeSpan::FromDays(V0, X0);\n\tX8 = X21;\n\tX0 = X0 * X8;\nL_0161:\n\tX1 = 0;\n\tX0 = System.TimeSpan::FromTicks(X0, X1);\n\t*([X19+58]) = X0;\nL_016A:\n\tgoto L_0171;\n\tv432 = *([v400 @ X0_v8+E0]);\n\tv433 = v432 == 0;\n\tv434 = ~v433;\n\tgoto L_0171;\n\tv436 = \"il2cpp_codegen_runtime_class_init\"(v400, v382, v376, v340, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0171:\n\tv440 = System.DateTime::get_UtcNow();\n\tv390.purchaseDate = r.<purchaseDate>k__BackingField;\n\tv390.productId = r.<productID>k__BackingField;\n\tv390.subscriptionExpireDate = r.<subscriptionExpirationDate>k__BackingField;\n\tv390.subscriptionCancelDate = r.<cancellationDate>k__BackingField;\n\tv466 = *([v226 @ X0_v88]) != 2;\n\tif (v466) goto L_018B;\n\tv390.is_subscribed = 2;\n\tv390.is_auto_renewing = 0x200000002;\n\tgoto L_0233;\nL_018B:\n\tv541 = r.<cancellationDate>k__BackingField;\n\tv545 = 0xE95580(&v541 @ X8_v23 (System.DateTime), 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv609 = v545 < 1;\n\tif (v609) goto L_FFFFFFFF;\n\tv628 = r.<cancellationDate>k__BackingField;\n\tv632 = 0xE95580(&v628 @ X8_v42 (System.DateTime), 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv657 = 0xE95580(&v655 @ stack_-48_v9, 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv675 = v632 - v657;\n\tv673 = v675 < 0;\n\tv669 = v632 ^ v657;\n\tv667 = v632 ^ v675;\n\tv665 = v669 & v667;\n\tv663 = v665 < 0;\n\tv661 = v673 == v663;\n\tgoto L_01B2;\nL_01B2:\n\tv390.is_cancelled = v681;\n\tv683 = r.<subscriptionExpirationDate>k__BackingField;\n\tv687 = 0xE95580(&v683 @ X8_v25 (System.DateTime), 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv755 = 0xE95580(&v655 @ stack_-48_v9, 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv803 = v687 - v755;\n\tv804 = v803 < 0;\n\tv806 = v687 ^ v755;\n\tv807 = v687 ^ v803;\n\tv808 = v806 & v807;\n\tv809 = v808 < 0;\n\tv810 = v804 == v809;\n\tv811 = ~v810;\n\tv390.is_subscribed = v811;\n\tv813 = r.<subscriptionExpirationDate>k__BackingField;\n\tv817 = 0xE95580(&v813 @ X8_v27 (System.DateTime), 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv857 = v817 < 1;\n\tif (v857) goto L_FFFFFFFF;\n\tv873 = r.<subscriptionExpirationDate>k__BackingField;\n\tv877 = 0xE95580(&v873 @ X8_v39 (System.DateTime), 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv887 = 0xE95580(&v655 @ stack_-48_v9, 0, v376, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv903 = v877 - v887;\n\tv901 = v903 < 0;\n\tv897 = v877 ^ v887;\n\tv895 = v877 ^ v903;\n\tv893 =\n// ... truncated")]
		public SubscriptionInfo(AppleInAppPurchaseReceipt r, string intro_json)
		{
			//IL_0057: Expected I4, but got O
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected O, but got Unknown
			//IL_0631: Expected I, but got O
			//IL_0144: Expected I, but got O
			//IL_0152: Expected I, but got O
			//IL_073f: Expected I8, but got I4
			//IL_0744: Expected I, but got O
			//IL_017d: Expected I, but got O
			//IL_018b: Expected I, but got O
			//IL_0221: Expected I, but got O
			//IL_03f8: Expected I4, but got I8
			//IL_02b4: Expected I, but got O
			//IL_0795: Expected O, but got I
			//IL_0466: Expected O, but got I
			//IL_06f7: Expected I, but got O
			//IL_052a: Expected O, but got I
			//IL_08ea: Expected I, but got O
			base._002Ector();
			Type typeFromHandle = typeof(AppleStoreProductType);
			int productType = r.productType;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string value = default(string);
			object obj = Enum.Parse(typeFromHandle, value);
			object obj2 = default(object);
			SubscriptionInfo subscriptionInfo;
			int num;
			if ((int)((obj is AppleStoreProductType) ? obj : null) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				IntPtr intPtr2;
				IntPtr intPtr3;
				if (!((long)(IntPtr)obj2 < 1L || (object)(obj2 - 1) == null))
				{
					if (string.IsNullOrEmpty(intro_json))
					{
						introductory_price = "not available";
						introductory_price_period = TimeSpan.Zero;
						introductory_price_cycles = 0L;
						IntPtr intPtr = (IntPtr)null;
						subscriptionInfo = this;
						goto IL_0367;
					}
					object obj3 = MiniJson.JsonDecode(intro_json);
					if (obj3 != null)
					{
						intPtr2 = (IntPtr)null;
						intPtr3 = (IntPtr)typeof(Dictionary<string, object>);
						subscriptionInfo = this;
						bool flag = !(obj3 is Dictionary<string, object>);
						intPtr2 = (IntPtr)null;
						intPtr3 = (IntPtr)typeof(Dictionary<string, object>);
						subscriptionInfo = this;
						if (flag)
						{
							InvalidCastException ex = new InvalidCastException();
							bool flag2 = intPtr3 != (IntPtr)1;
							InvalidCastException ex2 = ex;
							if (!flag2)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
								object obj5 = default(object);
								object obj4 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
								object obj6 = default(object);
								if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
									Debug.unityLogger.Log("Unable to parse introductory period cycles and duration, this product does not have configuration of introductory price period", obj4);
									IntPtr intPtr = (IntPtr)obj4;
									string text = "Unable to parse introductory period cycles and duration, this product does not have configuration of introductory price period";
									num = 4;
									goto IL_02cb;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
								object obj7 = obj5;
								intPtr3 = (IntPtr)(32022528 + 2160);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								intPtr2 = (IntPtr)null;
								InvalidCastException ex3 = default(InvalidCastException);
								ex2 = ex3;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
							return;
						}
					}
					if (string.IsNullOrEmpty(introductory_price = ((Dictionary<string, object>)obj3).TryGetString("introductoryPrice") + ((Dictionary<string, object>)obj3).TryGetString("introductoryPriceLocale")))
					{
						introductory_price = "not available";
						IntPtr intPtr = (IntPtr)null;
						string text = null;
						subscriptionInfo = this;
						num = 4;
					}
					else
					{
						introductory_price_cycles = Convert.ToInt64(((Dictionary<string, object>)obj3).TryGetString("introductoryPriceNumberOfPeriods"));
						int num2 = Convert.ToInt32(((Dictionary<string, object>)obj3).TryGetString("numberOfUnits"));
						int num3 = Convert.ToInt32(((Dictionary<string, object>)obj3).TryGetString("unit"));
						IntPtr intPtr = (IntPtr)null;
						string text = null;
						subscriptionInfo = this;
						num = num3;
					}
					goto IL_02cb;
				}
				InvalidProductTypeException ex4 = new InvalidProductTypeException();
				intPtr2 = (IntPtr)0;
				intPtr3 = (IntPtr)null;
				throw ex4;
			}
			throw new InvalidCastException();
			IL_089a:
			TimeSpan zero = default(TimeSpan);
			subscriptionInfo.remainedTime = zero;
			return;
			IL_02cb:
			DateTime now = DateTime.Now;
			if (!(num >= 4 && num - 4 != 0))
			{
				int num4 = 25407488 + 3044;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X9_v12 (System.Int32)+v397 @ X22_v6 (System.Int32)*4]");
				productType = 0 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X8_v74 (System.Int32) (should have been resolved before IL gen)");
			}
			goto IL_0367;
			IL_0367:
			DateTime utcNow = DateTime.UtcNow;
			subscriptionInfo.purchaseDate = r.purchaseDate;
			subscriptionInfo.productId = r.productID;
			subscriptionInfo.subscriptionExpireDate = r.subscriptionExpirationDate;
			subscriptionInfo.subscriptionCancelDate = r.cancellationDate;
			if ((IntPtr)obj2 == (IntPtr)2)
			{
				subscriptionInfo.is_subscribed = Result.Unsupported;
				subscriptionInfo.is_auto_renewing = Result.Unsupported;
			}
			else
			{
				DateTime cancellationDate = r.cancellationDate;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
				object obj8 = default(object);
				Result result;
				if ((long)(IntPtr)obj8 >= 1L)
				{
					DateTime cancellationDate2 = r.cancellationDate;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
					object obj10 = default(object);
					object obj11 = default(object);
					object obj9 = (long)(IntPtr)obj10 - (long)(IntPtr)obj11;
					result = (((long)(IntPtr)obj9 < 0L == ((int)((long)(IntPtr)obj10 ^ (long)(IntPtr)obj11) & (int)((long)(IntPtr)obj10 ^ (long)(IntPtr)obj9)) < 0) ? Result.False : Result.True);
				}
				else
				{
					result = Result.False;
				}
				subscriptionInfo.is_cancelled = result;
				DateTime subscriptionExpirationDate = r.subscriptionExpirationDate;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
				object obj13 = default(object);
				object obj14 = default(object);
				object obj12 = (long)(IntPtr)obj13 - (long)(IntPtr)obj14;
				bool flag3 = (long)(IntPtr)obj12 < 0L;
				int num5 = (int)((long)(IntPtr)obj13 ^ (long)(IntPtr)obj14);
				int num6 = (int)((long)(IntPtr)obj13 ^ (long)(IntPtr)obj12);
				int num7 = num5 & num6;
				bool flag4 = num7 < 0;
				bool flag5 = flag3 == flag4;
				bool flag6 = !flag5;
				subscriptionInfo.is_subscribed = (flag6 ? Result.False : Result.True);
				DateTime subscriptionExpirationDate2 = r.subscriptionExpirationDate;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
				object obj15 = default(object);
				Result result2;
				if ((long)(IntPtr)obj15 >= 1L)
				{
					DateTime subscriptionExpirationDate3 = r.subscriptionExpirationDate;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95580 (inside System.DateTime::SpecifyKind +0xB8)");
					object obj17 = default(object);
					object obj18 = default(object);
					object obj16 = (long)(IntPtr)obj17 - (long)(IntPtr)obj18;
					result2 = (((long)(IntPtr)obj16 < 0L == ((int)((long)(IntPtr)obj17 ^ (long)(IntPtr)obj18) & (int)((long)(IntPtr)obj17 ^ (long)(IntPtr)obj16)) < 0) ? Result.False : Result.True);
				}
				else
				{
					result2 = Result.False;
				}
				subscriptionInfo.is_expired = result2;
				int num8 = r.isFreeTrial - 1;
				bool flag7 = num8 == 0;
				bool flag8 = !flag7;
				subscriptionInfo.is_free_trial = (flag8 ? Result.False : Result.True);
				if ((IntPtr)obj2 == (IntPtr)3)
				{
					productType = (int)(result2 ^ Result.False);
					if (subscriptionInfo.is_cancelled != Result.False)
					{
						productType = 1;
					}
				}
				else
				{
					productType = 1;
				}
				subscriptionInfo.is_auto_renewing = (Result)productType;
				int num9 = r.isIntroductoryPricePeriod - 1;
				bool flag9 = num9 == 0;
				bool flag10 = !flag9;
				subscriptionInfo.is_introductory_price_period = (flag10 ? Result.False : Result.True);
				if (subscriptionInfo.is_subscribed == Result.True)
				{
					DateTime subscriptionExpirationDate4 = r.subscriptionExpirationDate;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95DA0 (inside System.DateTime::ParseExact +0xD8)");
					goto IL_089a;
				}
			}
			zero = TimeSpan.Zero;
			goto IL_089a;
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0x15AED60", Offset = "0x15AED60", Length = "0x768")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv51 = *([1F0CBC0]);\n\tv52 = *([v51 @ X8_v97]);\n\tv53 = \"il2cpp_codegen_initialize_method\"(v52, skuDetails, isAutoRenewing, purchaseDate, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([20298AC]) = v64;\nL_002A:\n\tSystem.Object::.ctor(this);\n\tv73 = UnityEngine.Purchasing.MiniJson::JsonDecode(skuDetails);\n\tgoto L_FFFFFFFF;\n\tv202 = v202_asT == 0;\n\tif (v202) goto L_0280;\n\tv282 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v73, \"type\", &v111 @ stack_-78_v5 (System.Object));\n\tv297 = v282 == 0;\n\tif (v297) goto L_0284;\n\tv265 = v111 == 0;\n\tif (v265) goto L_0073;\n\tv230 = *([v111 @ stack_-78_v5 (System.Object)]) != System.String;\n\tif (v230) goto L_028F;\nL_0073:\n\tv296 = System.String::op_Equality(v111, \"inapp\");\n\tv386 = v296 == 0;\n\tv298 = ~v386;\n\tif (v298) goto L_0284;\n\tv392 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v73, \"productId\", &v105 @ stack_-80_v4 (System.Object));\n\tthis.productId = 0;\n\tv394 = v392 == 0;\n\tif (v394) goto L_0098;\n\tv396 = v105 == 0;\n\tif (v396) goto L_0097;\n\tv442 = *([v105 @ stack_-80_v4 (System.Object)]) != System.String;\n\tif (v442) goto L_FFFFFFFF;\n\tgoto L_0097;\nL_0097:\n\tthis.productId = v420;\nL_0098:\n\tthis.purchaseDate = purchaseDate;\n\tv421 = ~isAutoRenewing;\n\tthis.is_subscribed = 0x100000000;\n\tthis.is_cancelled = isAutoRenewing;\n\tthis.is_free_trial = 1;\n\tthis.is_auto_renewing = v421;\n\tv430 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v73, \"subscriptionPeriod\");\n\tv446 = v430 == 0;\n\tif (v446) goto L_FFFFFFFF;\n\tv452 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v73, \"subscriptionPeriod\");\n\tv475 = v452 == 0;\n\tif (v475) goto L_00CC;\n\tv463 = *([v452 @ X0_v151 (System.String)]) == System.String;\n\tif (v463) goto L_00CC;\n\tthrow System.InvalidCastException;\nL_00CC:\n\tv499 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v73, \"freeTrialPeriod\");\n\tv502 = v499 == 0;\n\tif (v502) goto L_FFFFFFFF;\n\tv509 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v73, \"freeTrialPeriod\");\n\tv532 = v509 == 0;\n\tif (v532) goto L_00ED;\n\tv520 = *([v509 @ X0_v146 (System.String)]) == System.String;\n\tif (v520) goto L_00ED;\n\tthrow System.InvalidCastException;\nL_00ED:\n\tv556 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v73, \"introductoryPrice\");\n\tv559 = v556 == 0;\n\tif (v559) goto L_FFFFFFFF;\n\tv566 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v73, \"introductoryPrice\");\n\tv589 = v566 == 0;\n\tif (v589) goto L_010F;\n\tv577 = *([v566 @ X0_v141 (System.String)]) == System.String;\n\tif (v577) goto L_010F;\n\tthrow System.InvalidCastException;\nL_010F:\n\tv613 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v73, \"introductoryPricePeriod\");\n\tv616 = v613 == 0;\n\tif (v616) goto L_FFFFFFFF;\n\tv623 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v73, \"introductoryPricePeriod\");\n\tv646 = v623 == 0;\n\tif (v646) goto L_0130;\n\tv634 = *([v623 @ X0_v136 (System.String)]) == System.String;\n\tif (v634) goto L_0130;\n\tthrow System.InvalidCastException;\nL_0130:\n\tv661 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v73, \"introductoryPriceCycles\");\n\tv664 = v661 == 0;\n\tif (v664) goto L_FFFFFFFF;\n\tthis = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v73, \"introductoryPriceCycles\");\n\tv231 = v231_asT == 0;\n\tif (v231) goto L_028F;\n\tthis = \"il2cpp_vm_object_unbox\"(this, System.Int64, Il2CppMethodInfo, Il2CppMethodInfo, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv670 = *([this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)]);\n\tgoto L_0153;\nL_0153:\n\tthis.free_trial_period_string = v176;\n\tv680 = UnityEngine.Purchasing.SubscriptionInfo::parsePeriodTimeSpanUnits(this, v180);\n\tv686 = UnityEngine.Purchasing.SubscriptionInfo::computePeriodTimeSpan(v680, v680);\n\tthis.subscriptionPeriod = v686;\n\tgoto L_0165;\n\tv693 = *([v689 @ X0_v40 (Il2CppClass<System.TimeSpan>)+E0]);\n\tv694 = v693 == 0;\n\tv695 = ~v694;\n\tgoto L_0165;\n\tv705 = \"il2cpp_codegen_runtime_class_init\"(v689, v685, v669, v108, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv697 = System.TimeSpan;\nL_0165:\n\tv700 = *([this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)+B8]);\n\tthis.freeTrialPeriod = *([v700 @ X8_v32]);\n\tv704 = isFreeTrial == 0;\n\tif (v704) goto L_0170;\n\tv707 = UnityEngine.Purchasing.SubscriptionInfo::parseTimeSpan(this, v176);\n\tthis.freeTrialPeriod = v707;\nL_0170:\n\tthis.introductory_price = v178;\n\tthis.introductory_price_cycles = v670;\n\tgoto L_017C;\n\tv714 = *([v709 @ X0_v42 (UnityEngine.Purchasing.SubscriptionInfo)+E0]);\n\tv715 = v714 == 0;\n\tv716 = ~v715;\n\tgoto L_017C;\n\tv726 = \"il2cpp_codegen_runtime_class_init\"(v709, v708, v669, v108, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv718 = System.TimeSpan;\nL_017C:\n\tv721 = *([this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)+B8]);\n\tthis.is_introductory_price_period = 1;\n\tthis.introductory_price_period = *([v721 @ X8_v37]);\n\tv725 = hasIntroductoryPriceTrial == 0;\n\tif (v725) goto L_018F;\n\tv727 = v182 == 0;\n\tif (v727) goto L_019B;\n\tv734 = System.String::Equals(v182, v180);\n\tv739 = v734 == 0;\n\tif (v739) goto L_019B;\n\tv766 = v734.subscriptionPeriod;\n\tgoto L_019C;\nL_018F:\n\tv728 = *([this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)+B8]);\n\tv744 = *([v728 @ X8_v66]);\n\tv730 = updateMetadata == 0;\n\tif (v730) goto L_FFFFFFFF;\nL_0193:\n\tthis = this + 0x70;\n\tv755 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(this, 0, v742);\n\tv773 = UnityEngine.Purchasing.SubscriptionInfo::computeExtraTime(v755, updateMetadata, v54);\n\tgoto L_01AC;\nL_019B:\n\tv766 = UnityEngine.Purchasing.SubscriptionInfo::parseTimeSpan(this, v182);\nL_019C:\n\tthis.introductory_price_period = v766;\n\tv771 = UnityEngine.Purchasing.SubscriptionInfo::parsePeriodTimeSpanUnits(this, v182);\n\tv749 = UnityEngine.Purchasing.SubscriptionInfo::accumulateIntroductoryDuration(v771, v771, this.introductory_price_cycles);\n\tv796 = updateMetadata == 0;\n\tv751 = ~v796;\n\tif (v751) goto L_0193;\nL_01AC:\n\tgoto L_01B4;\n\tv787 = *([v783 @ X0_v45+E0]);\n\tv788 = v787 == 0;\n\tv789 = ~v788;\n\tgoto L_01B4;\n\tv791 = \"il2cpp_codegen_runtime_class_init\"(v783, v779, v777, v108, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v776, v55, v56, v57, v58, v59, v60, v61);\nL_01B4:\n\tv795 = System.TimeSpan::FromSeconds(v774);\n\tgoto L_01C4;\n\tv804 = *([v800 @ X8_v42+E0]);\n\tv805 = v804 == 0;\n\tv806 = ~v805;\n\tif (v806) goto L_01C4;\n\tv813 = v800;\n\tv809 = \"il2cpp_codegen_runtime_class_init\"(v813, v779, v777, v108, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v318, v55, v56, v57, v58, v59, v60, v61);\nL_01C4:\n\tv812 = System.DateTime::get_UtcNow();\n\tv817 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(&v812 @ X0_v51 (System.DateTime), purchaseDate, 0);\n\tv821 = System.TimeSpan::op_LessThanOrEqual(v817, v795);\n\tv823 = v821 == 0;\n\tif (v823) goto L_01D4;\n\tgoto L_01F4;\nL_01D4:\n\tv826 = this + 0x68;\n\tv830 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v826, v795, 0);\n\tgoto L_01E8;\n\tv851 = *([v845 @ X8_v61+E0]);\n\tv852 = v851 == 0;\n\tv853 = ~v852;\n\tif (v853) goto L_01E8;\n\tv890 = v845;\n\tv855 = \"il2cpp_codegen_runtime_class_init\"(v890, v828, v829, v108, isFreeTrial, hasIntroductoryPriceTrial, purchaseHistorySupported, updateMetadata, v318, v55, v56, v57, v58, v59, v60, v61);\nL_01E8:\n\tv860 = System.TimeSpan::op_LessThanOrEqual(v817, v830);\n\tv842 = v860 == 0;\n\tif (v842) goto L_01F9;\n\tthis.is_free_trial = 0;\n\tv903 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v\n// ... truncated")]
		public unsafe SubscriptionInfo(string skuDetails, bool isAutoRenewing, DateTime purchaseDate, bool isFreeTrial, bool hasIntroductoryPriceTrial, bool purchaseHistorySupported, string updateMetadata)
		{
			//IL_0894: Expected I4, but got I8
			//IL_03c7: Expected I8, but got I4
			//IL_0a03: Expected O, but got I
			//IL_0381: Expected I8, but got O
			//IL_0a3a: Expected O, but got I
			//IL_03ad: Expected I8, but got O
			//IL_0476: Expected O, but got I
			//IL_04b7: Expected O, but got I
			//IL_04d7: Expected O, but got I4
			//IL_0439: Expected I, but got O
			//IL_0441: Expected O, but got I4
			//IL_05d7: Expected O, but got I4
			//IL_0458: Expected O, but got I4
			//IL_0461: Expected I, but got O
			//IL_0619: Expected O, but got I
			//IL_063d: Expected O, but got I4
			//IL_063d: Expected O, but got I4
			//IL_06b9: Expected O, but got I4
			//IL_0a88: Expected O, but got I4
			//IL_068c: Expected O, but got I4
			//IL_07bd: Expected O, but got I
			//IL_06d4: Expected O, but got I4
			//IL_06d4: Expected O, but got I4
			//IL_0760: Expected O, but got I
			//IL_0780: Expected O, but got I4
			//IL_07f6: Expected O, but got I4
			//IL_0797: Expected O, but got I4
			//IL_0715: Expected O, but got I
			//IL_0735: Expected O, but got I4
			//IL_0aac: Expected O, but got I4
			base._002Ector();
			object obj = MiniJson.JsonDecode(skuDetails);
			string text2;
			string text7;
			TimeSpan timeSpan2;
			TimeSpan timeSpan3;
			ref object value3;
			TimeSpan timeSpan4;
			SubscriptionInfo subscriptionInfo;
			if (obj is Dictionary<string, object>)
			{
				if (((Dictionary<string, object>)obj).TryGetValue("type", out object value))
				{
					if (value != null && (object)value.GetType() != typeof(string))
					{
						goto IL_0852;
					}
					if (!((string)value == "inapp"))
					{
						bool flag = ((Dictionary<string, object>)obj).TryGetValue("productId", out object value2);
						productId = null;
						if (flag)
						{
							bool flag2 = value2 == null;
							object obj2 = value2;
							if (!flag2)
							{
								obj2 = (((object)value2.GetType() != typeof(string)) ? null : value2);
							}
							productId = (string)obj2;
						}
						this.purchaseDate = purchaseDate;
						bool flag3 = !isAutoRenewing;
						is_subscribed = Result.True;
						is_cancelled = (isAutoRenewing ? Result.False : Result.True);
						is_free_trial = Result.False;
						is_auto_renewing = (flag3 ? Result.False : Result.True);
						if (((Dictionary<string, object>)obj).ContainsKey("subscriptionPeriod"))
						{
							string text = (string)((Dictionary<string, object>)obj).get_Item("subscriptionPeriod");
							bool flag4 = text == null;
							text2 = text;
							if (!flag4)
							{
								bool flag5 = (object)text.GetType() == typeof(string);
								text2 = text;
								if (!flag5)
								{
									throw new InvalidCastException();
								}
							}
						}
						else
						{
							text2 = null;
						}
						string period_string;
						if (((Dictionary<string, object>)obj).ContainsKey("freeTrialPeriod"))
						{
							string text3 = (string)((Dictionary<string, object>)obj).get_Item("freeTrialPeriod");
							bool flag6 = text3 == null;
							period_string = text3;
							if (!flag6)
							{
								bool flag7 = (object)text3.GetType() == typeof(string);
								period_string = text3;
								if (!flag7)
								{
									throw new InvalidCastException();
								}
							}
						}
						else
						{
							period_string = null;
						}
						string text5;
						if (((Dictionary<string, object>)obj).ContainsKey("introductoryPrice"))
						{
							string text4 = (string)((Dictionary<string, object>)obj).get_Item("introductoryPrice");
							bool flag8 = text4 == null;
							text5 = text4;
							if (!flag8)
							{
								bool flag9 = (object)text4.GetType() == typeof(string);
								text5 = text4;
								if (!flag9)
								{
									throw new InvalidCastException();
								}
							}
						}
						else
						{
							text5 = null;
						}
						if (((Dictionary<string, object>)obj).ContainsKey("introductoryPricePeriod"))
						{
							string text6 = (string)((Dictionary<string, object>)obj).get_Item("introductoryPricePeriod");
							bool flag10 = text6 == null;
							text7 = text6;
							if (!flag10)
							{
								bool flag11 = (object)text6.GetType() == typeof(string);
								text7 = text6;
								if (!flag11)
								{
									throw new InvalidCastException();
								}
							}
						}
						else
						{
							text7 = null;
						}
						long num;
						IntPtr intPtr;
						if (((Dictionary<string, object>)obj).ContainsKey("introductoryPriceCycles"))
						{
							subscriptionInfo = (SubscriptionInfo)((Dictionary<string, object>)obj).get_Item("introductoryPriceCycles");
							if ((long)((this is long) ? this : null) == 0)
							{
								goto IL_0852;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							num = (long)this;
							intPtr = (IntPtr)0;
						}
						else
						{
							intPtr = (IntPtr)0;
							num = 0L;
						}
						free_trial_period_string = period_string;
						TimeSpanUnits timeSpanUnits = parsePeriodTimeSpanUnits(text2);
						TimeSpan timeSpan = ((SubscriptionInfo)(object)timeSpanUnits).computePeriodTimeSpan(timeSpanUnits);
						subscriptionPeriod = timeSpan;
						subscriptionInfo = (SubscriptionInfo)(object)typeof(TimeSpan);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)+B8]");
						object obj3 = 0;
						freeTrialPeriod = (TimeSpan)obj3;
						if (isFreeTrial)
						{
							freeTrialPeriod = parseTimeSpan(period_string);
							subscriptionInfo = (SubscriptionInfo)(object)typeof(TimeSpan);
						}
						introductory_price = text5;
						introductory_price_cycles = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)+B8]");
						object obj4 = 0;
						is_introductory_price_period = Result.False;
						introductory_price_period = (TimeSpan)obj4;
						if (hasIntroductoryPriceTrial)
						{
							if (text7 != null)
							{
								bool flag12 = text7.Equals(text2);
								bool flag13 = !flag12;
								intPtr = (IntPtr)null;
								subscriptionInfo = (SubscriptionInfo)flag12;
								if (!flag13)
								{
									timeSpan2 = ((SubscriptionInfo)flag12).subscriptionPeriod;
									intPtr = (IntPtr)null;
									goto IL_0508;
								}
							}
							timeSpan2 = parseTimeSpan(text7);
							goto IL_0508;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (UnityEngine.Purchasing.SubscriptionInfo)+B8]");
						object obj5 = 0;
						timeSpan3 = (TimeSpan)obj5;
						bool flag14 = updateMetadata == null;
						value3 = ref *(object*)intPtr;
						timeSpan4 = (TimeSpan)obj5;
						if (!flag14)
						{
							goto IL_04ab;
						}
						goto IL_057e;
					}
				}
				throw new InvalidProductTypeException();
			}
			throw new InvalidCastException();
			IL_0508:
			introductory_price_period = timeSpan2;
			TimeSpanUnits timeSpanUnits2 = parsePeriodTimeSpanUnits(text7);
			TimeSpan timeSpan5 = ((SubscriptionInfo)(object)timeSpanUnits2).accumulateIntroductoryDuration(timeSpanUnits2, introductory_price_cycles);
			bool flag15 = updateMetadata != null;
			value3 = ref *(object*)introductory_price_cycles;
			timeSpan3 = timeSpan5;
			timeSpan4 = timeSpan5;
			if (flag15)
			{
				goto IL_04ab;
			}
			goto IL_057e;
			IL_0852:
			throw new InvalidCastException();
			IL_04ab:
			subscriptionInfo = (SubscriptionInfo)((long)(IntPtr)this + 112L);
			double new_sku_period_in_seconds = default(double);
			double value4 = ((SubscriptionInfo)((Dictionary<string, object>)this).TryGetValue((string)null, out value3)).computeExtraTime(updateMetadata, new_sku_period_in_seconds);
			string key = (string)timeSpan3;
			goto IL_0598;
			IL_0598:
			TimeSpan timeSpan6 = TimeSpan.FromSeconds(value4);
			bool flag16 = ((Dictionary<string, object>)DateTime.UtcNow).TryGetValue((string)purchaseDate, out *(object*)null);
			string key2;
			DateTime dateTime;
			if ((TimeSpan)flag16 <= timeSpan6)
			{
				key2 = (string)timeSpan6;
				subscriptionInfo = (SubscriptionInfo)purchaseDate;
			}
			else
			{
				object obj6 = (long)(IntPtr)this + 104L;
				if (!((TimeSpan)flag16 <= (TimeSpan)((Dictionary<string, object>)obj6).TryGetValue((string)timeSpan6, out *(object*)null)))
				{
					string time_span;
					bool flag18;
					if ((TimeSpan)flag16 < (TimeSpan)((Dictionary<string, object>)((Dictionary<string, object>)obj6).TryGetValue((string)timeSpan6, out *(object*)null)).TryGetValue(key, out *(object*)null))
					{
						is_introductory_price_period = default(Result);
						bool flag17 = ((Dictionary<string, object>)((long)(IntPtr)this + 48L)).TryGetValue((string)((Dictionary<string, object>)obj6).TryGetValue((string)timeSpan6, out *(object*)null), out *(object*)null);
						time_span = text7;
						flag18 = flag17;
					}
					else
					{
						bool flag19 = ((Dictionary<string, object>)((long)(IntPtr)this + 48L)).TryGetValue((string)((Dictionary<string, object>)((Dictionary<string, object>)obj6).TryGetValue((string)timeSpan6, out *(object*)null)).TryGetValue(key, out *(object*)null), out *(object*)null);
						time_span = text2;
						flag18 = flag19;
					}
					TimeSpanUnits timeSpanUnits3 = parsePeriodTimeSpanUnits(time_span);
					dateTime = ((SubscriptionInfo)(object)timeSpanUnits3).nextBillingDate((DateTime)flag18, timeSpanUnits3);
					goto IL_07b1;
				}
				is_free_trial = default(Result);
				key2 = (string)((Dictionary<string, object>)obj6).TryGetValue((string)timeSpan6, out *(object*)null);
				subscriptionInfo = (SubscriptionInfo)purchaseDate;
			}
			bool flag20 = ((Dictionary<string, object>)this).TryGetValue(key2, out *(object*)null);
			dateTime = (DateTime)flag20;
			goto IL_07b1;
			IL_057e:
			value4 = 0.0;
			key = (string)timeSpan4;
			goto IL_0598;
			IL_07b1:
			object obj7 = (long)(IntPtr)this + 56L;
			subscriptionExpireDate = dateTime;
			remainedTime = (TimeSpan)((Dictionary<string, object>)obj7).TryGetValue((string)DateTime.UtcNow, out *(object*)null);
			sku_details = skuDetails;
			if (!purchaseHistorySupported)
			{
				is_free_trial = Result.Unsupported;
				subscriptionExpireDate = DateTime.MaxValue;
				is_introductory_price_period = Result.Unsupported;
				remainedTime = TimeSpan.MaxValue;
			}
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x15AFCF8", Offset = "0x15AFCF8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFF658]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, productId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20298AD]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tthis.productId = productId;\n\tthis.is_auto_renewing = 2;\n\tthis.is_subscribed = *([183BC00]);\n\tgoto L_002D;\n\tv53 = *([v49 @ X0_v3 (Il2CppClass<System.TimeSpan>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002D;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v49, v43, methodInfo, v26, v27, v28, v29, v30, v45, v32, v33, v34, v35, v36, v37, v38);\n\tv57 = System.TimeSpan;\nL_002D:\n\tthis.is_introductory_price_period = 2;\n\tthis.remainedTime = v60.MaxValue;\n\tthis.introductory_price_cycles = 0;\n\tthis.introductory_price = 0;\n\tthis.introductory_price_period = v62.MaxValue;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SubscriptionInfo(string productId)
		{
			//IL_0058: Expected I8, but got I4
			base._002Ector();
			this.productId = productId;
			is_auto_renewing = Result.Unsupported;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183BC00]");
			is_subscribed = Result.True;
			is_introductory_price_period = Result.Unsupported;
			remainedTime = TimeSpan.MaxValue;
			introductory_price_cycles = 0L;
			introductory_price = null;
			introductory_price_period = TimeSpan.MaxValue;
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x15AFDAC", Offset = "0x15AFDAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.is_subscribed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Result isSubscribed()
		{
			return is_subscribed;
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x15AFDB4", Offset = "0x15AFDB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.is_expired;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Result isExpired()
		{
			return is_expired;
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x15AFDBC", Offset = "0x15AFDBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.is_cancelled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Result isCancelled()
		{
			return is_cancelled;
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x15AFDC4", Offset = "0x15AFDC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.remainedTime;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TimeSpan getRemainingTime()
		{
			return remainedTime;
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x15AFBB8", Offset = "0x15AFBB8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0015;\n\tv22 = *([1EA5C88]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, billing_begin_date, units, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20298AE]) = v41;\nL_0015:\n\t*([v10 @ X29_v1-18]) = 0;\n\tv54 = units.days != 0;\n\tif (v54) goto L_004D;\n\tv58 = units.months == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_004D;\n\tv102 = units.years == 0;\n\tv90 = ~v102;\n\tif (v90) goto L_004D;\n\tv182 = 0;\n\tv109 = 0xE93EDC(&v182 @ stack_-40_v2 (System.DateTime), 0x7B2, 1, 1, 0, 0, 0, 0, units.days, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0071;\nL_003D:\n\tv109 = &v11 @ stack_-10_v2 - 0x18;\n\tv109 = 0xE946B4(v109, 0, 0, methodInfo, v26, v27, v28, v29, units.days, v31, v32, v33, v34, v35, v36, v37);\n\tv109 = 0xE946C8(&v109 @ X0_v9 (System.DateTime), units.months, 0, methodInfo, v26, v27, v28, v29, units.days, v31, v32, v33, v34, v35, v36, v37);\n\tv109 = 0xE94CC0(&v109 @ X0_v9 (System.DateTime), units.years, 0, methodInfo, v26, v27, v28, v29, units.days, v31, v32, v33, v34, v35, v36, v37);\nL_004D:\n\t*([v10 @ X29_v1-18]) = v91;\n\tgoto L_0059;\n\tv103 = *([v98 @ X0_v6+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tgoto L_0059;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v98, v64, v62, methodInfo, v26, v27, v28, v29, v84, v31, v32, v33, v34, v35, v36, v37);\nL_0059:\n\tv109 = System.DateTime::get_UtcNow();\n\tv196 = System.DateTime::Compare(v91, v109);\n\tv67 = v196 < 1;\n\tif (v67) goto L_003D;\n\tv109 = *([v10 @ X29_v1-18]);\nL_0071:\n\treturn v109;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private DateTime nextBillingDate(DateTime billing_begin_date, TimeSpanUnits units)
		{
			//IL_00dc: Expected O, but got I
			//IL_0158: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			bool flag = units.days != 0.0;
			DateTime t = billing_begin_date;
			if (!flag)
			{
				bool flag2 = units.months == 0;
				bool flag3 = !flag2;
				t = billing_begin_date;
				if (!flag3)
				{
					bool flag4 = units.years == 0;
					bool flag5 = !flag4;
					t = billing_begin_date;
					if (!flag5)
					{
						DateTime dateTime = default(DateTime);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E93EDC (inside System.DateTime::TimeToTicks +0x454)");
						return default(DateTime);
					}
				}
			}
			while (true)
			{
				DateTime utcNow = DateTime.UtcNow;
				int num = DateTime.Compare(t, utcNow);
				if (num < 1)
				{
					utcNow = (DateTime)((long)(IntPtr)obj2 - 24L);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E946B4 (inside System.DateTime::TimeToTicks +0xC2C)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E946C8 (inside System.DateTime::TimeToTicks +0xC40)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E94CC0 (inside System.DateTime::DaysInMonth +0x178)");
					t = utcNow;
					continue;
				}
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ X29_v1-18]");
			return (DateTime)0;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x15AF924", Offset = "0x15AF924", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EB4250]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, units, cycles, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([20298AF]) = v41;\nL_001C:\n\tgoto L_002D;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<System.TimeSpan>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v45, units, cycles, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv53 = System.TimeSpan;\nL_002D:\n\treturnVal1 = v56.Zero;\n\tv69 = v73 < 1;\n\tif (v69) goto L_0043;\nL_0033:\n\tv84 = UnityEngine.Purchasing.SubscriptionInfo::computePeriodTimeSpan(v77, units);\n\tv77 = 0x9BD230(&v71 @ stack_-28_v4 (System.TimeSpan), v84, 0, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv82 = v81 - 1;\n\tv80 = v81 != 1;\n\tif (v80) goto L_0033;\nL_0043:\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TimeSpan accumulateIntroductoryDuration(TimeSpanUnits units, long cycles)
		{
			TimeSpan result = TimeSpan.Zero;
			long num = default(long);
			bool flag = num < 1;
			TimeSpan zero = TimeSpan.Zero;
			SubscriptionInfo zero2 = (SubscriptionInfo)TimeSpan.Zero;
			long num2 = num;
			if (!flag)
			{
				bool flag2;
				do
				{
					TimeSpan timeSpan = zero2.computePeriodTimeSpan(units);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9BD230 (inside System.TimeSpan::TimeToTicks +0x2B0)");
					long num3 = num2 - 1;
					flag2 = num2 != 1;
					zero = (TimeSpan)zero2;
					num2 = num3;
					result = (TimeSpan)zero2;
				}
				while (flag2);
			}
			return result;
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x15AF6D4", Offset = "0x15AF6D4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1F0D1D0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, units, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298B0]) = v38;\nL_001B:\n\tgoto L_0022;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0022;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, units, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\tv55 = System.DateTime::get_Now();\n\tv55 = 0xE946B4(&v60 @ stack_-28_v3, 0, methodInfo, v22, v23, v24, v25, v26, units.days, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = 0xE946C8(&v55 @ X0_v5 (System.DateTime), units.months, 0, v22, v23, v24, v25, v26, units.days, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = 0xE94CC0(&v55 @ X0_v5 (System.DateTime), units.years, 0, v22, v23, v24, v25, v26, units.days, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal2 = 0xE95DA0(&v55 @ X0_v5 (System.DateTime), v60, 0, v22, v23, v24, v25, v26, units.days, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TimeSpan computePeriodTimeSpan(TimeSpanUnits units)
		{
			DateTime now = DateTime.Now;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E946B4 (inside System.DateTime::TimeToTicks +0xC2C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E946C8 (inside System.DateTime::TimeToTicks +0xC40)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E94CC0 (inside System.DateTime::DaysInMonth +0x178)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95DA0 (inside System.DateTime::ParseExact +0xD8)");
			TimeSpan result = default(TimeSpan);
			return result;
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x15AF9D0", Offset = "0x15AF9D0", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EAD260]);\n\tv31 = *([v30 @ X8_v30]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, metadata, methodInfo, v34, v35, v36, v37, v38, new_sku_period_in_seconds, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([20298B1]) = v49;\nL_001C:\n\tv53 = UnityEngine.Purchasing.MiniJson::JsonDecode(metadata);\n\tgoto L_FFFFFFFF;\n\tv91 = v91_asT == 0;\n\tif (v91) goto L_00C2;\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v53, \"old_sku_remaining_seconds\");\n\tv92 = v92_asT == 0;\n\tif (v92) goto L_00C0;\n\tv53 = \"il2cpp_vm_object_unbox\"(v53, System.Int64, Il2CppMethodInfo, v34, v35, v36, v37, v38, new_sku_period_in_seconds, v39, v40, v41, v42, v43, v44, v45);\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v53, \"old_sku_price_in_micros\");\n\tv212 = v212_asT == 0;\n\tif (v212) goto L_00C0;\n\tv53 = \"il2cpp_vm_object_unbox\"(v53, System.Int64, Il2CppMethodInfo, v34, v35, v36, v37, v38, new_sku_period_in_seconds, v39, v40, v41, v42, v43, v44, v45);\n\tv245 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v53, \"old_sku_period_string\");\n\tv246 = v245 == 0;\n\tif (v246) goto L_008E;\n\tv213 = *([v245 @ X0_v18 (UnityEngine.Purchasing.SubscriptionInfo)]) != System.String;\n\tif (v213) goto L_00C0;\nL_008E:\n\tv316 = UnityEngine.Purchasing.SubscriptionInfo::parseTimeSpan(v245, v245);\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(&v316 @ X0_v19 (System.TimeSpan), 0);\n\tv53 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v53, \"new_sku_price_in_micros\");\n\tv214 = v214_asT == 0;\n\tif (v214) goto L_00C0;\n\tv53 = \"il2cpp_vm_object_unbox\"(v53, System.Int64, Il2CppMethodInfo, v34, v35, v36, v37, v38, new_sku_period_in_seconds, v39, v40, v41, v42, v43, v44, v45);\n\tv326 = *([v53 @ X0_v3 (System.Object)]) / new_sku_period_in_seconds;\n\tv327 = v326 * *([v53 @ X0_v3 (System.Object)]);\n\tv328 = v327 / *([v53 @ X0_v3 (System.Object)]);\n\treturnVal2 = v328 * new_sku_period_in_seconds;\n\treturn returnVal2;\n\tv158 = new System.NullReferenceException();\nL_00C0:\n\tthrow System.InvalidCastException;\nL_00C2:\n\tthrow System.InvalidCastException;\n// 159 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private double computeExtraTime(string metadata, double new_sku_period_in_seconds)
		{
			//IL_0058: Expected I8, but got O
			//IL_00a3: Expected I8, but got O
			//IL_0170: Expected I8, but got O
			object obj = MiniJson.JsonDecode(metadata);
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			if (dictionary != null)
			{
				obj = ((Dictionary<string, object>)obj).get_Item("old_sku_remaining_seconds");
				long num = (long)((obj is long) ? obj : null);
				if (num != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					obj = ((Dictionary<string, object>)obj).get_Item("old_sku_price_in_micros");
					long num2 = (long)((obj is long) ? obj : null);
					if (num2 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						SubscriptionInfo subscriptionInfo = (SubscriptionInfo)((Dictionary<string, object>)obj).get_Item("old_sku_period_string");
						if (subscriptionInfo == null || (object)subscriptionInfo.GetType() == typeof(string))
						{
							TimeSpan timeSpan = subscriptionInfo.parseTimeSpan((string)(object)subscriptionInfo);
							obj = ((Dictionary<string, object>)timeSpan).get_Item((string)null);
							obj = ((Dictionary<string, object>)obj).get_Item("new_sku_price_in_micros");
							long num3 = (long)((obj is long) ? obj : null);
							if (num3 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
								double num4 = (double)obj / new_sku_period_in_seconds;
								double num5 = num4 * (double)obj;
								double num6 = num5 / (double)obj;
								return num6 * new_sku_period_in_seconds;
							}
						}
					}
				}
				throw new InvalidCastException();
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0x15AF7A4", Offset = "0x15AF7A4", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE6558]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, period_string, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20298B2]) = v38;\nL_001A:\n\tgoto L_002A;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_002A;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v42, period_string, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002A:\n\tgoto L_0032;\n\tv63 = *([v58 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0032;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v58, period_string, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0032:\n\treturnVal1 = System.Xml.XmlConvert::ToTimeSpan(period_string);\nL_0033:\n\t;\nL_0039:\n\treturn returnVal1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_007D;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX8 = *([X20]);\n\tX9 = *([1EDD7C0]);\n\tX1 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0073;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_0061;\n\tX8 = *([X19+10]);\n\tif (TEMP) goto L_0061;\n\tX0 = &stack[8];\n\tX1 = 0 | 7;\n\tX2 = 0;\n\tX3 = 0;\n\tX4 = 0;\n\tX5 = 0;\n\tX0 = 0x9BD06C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = stack[8];\n\tgoto L_0039;\nL_0061:\n\tX8 = 0x1ED4000;\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0070;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0070;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\nL_0070:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8]);\n\tgoto L_0033;\nL_0073:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007D:\n\tX0 = X20;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TimeSpan parseTimeSpan(string period_string)
		{
			return XmlConvert.ToTimeSpan(period_string);
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x15AF4C8", Offset = "0x15AF4C8", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F0F0D8]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, time_span, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([20298B3]) = v40;\nL_0015:\n\tv42 = time_span == 0;\n\tif (v42) goto L_007C;\n\tv48 = System.String::op_Equality(time_span, \"P1W\");\n\tv62 = v48 == 0;\n\tif (v62) goto L_0030;\n\tv70 = new UnityEngine.Purchasing.TimeSpanUnits();\n\tSystem.Object::.ctor(v70);\n\tgoto L_008D;\nL_0030:\n\tv76 = System.String::op_Equality(time_span, \"P1M\");\n\tv86 = v76 == 0;\n\tif (v86) goto L_0044;\n\tv96 = new UnityEngine.Purchasing.TimeSpanUnits();\n\tSystem.Object::.ctor(v96);\n\tgoto L_008D;\nL_0044:\n\tv102 = System.String::op_Equality(time_span, \"P3M\");\n\tv128 = v102 == 0;\n\tif (v128) goto L_0058;\n\tv124 = new UnityEngine.Purchasing.TimeSpanUnits();\n\tSystem.Object::.ctor(v124);\n\tgoto L_008D;\nL_0058:\n\tv155 = System.String::op_Equality(time_span, \"P6M\");\n\tv129 = v155 == 0;\n\tif (v129) goto L_006C;\n\tv125 = new UnityEngine.Purchasing.TimeSpanUnits();\n\tSystem.Object::.ctor(v125);\n\tgoto L_008D;\nL_006C:\n\tv54 = System.String::op_Equality(time_span, \"P1Y\");\n\tv56 = v54 == 0;\n\tif (v56) goto L_007C;\n\tv126 = new UnityEngine.Purchasing.TimeSpanUnits();\n\tSystem.Object::.ctor(v126);\n\tgoto L_008D;\nL_007C:\n\tv60 = UnityEngine.Purchasing.SubscriptionInfo::parseTimeSpan(v54, time_span);\n\tv66 = 0x9BD07C(&v60 @ X0_v5 (System.TimeSpan), 0, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv82 = new UnityEngine.Purchasing.TimeSpanUnits();\n\tSystem.Object::.ctor(v82);\nL_008D:\n\tv130.days = v106;\n\tv130.months = v111;\n\tv130.years = v135;\n\treturn v130;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TimeSpanUnits parsePeriodTimeSpanUnits(string time_span)
		{
			//IL_020b: Expected O, but got I4
			if (time_span == null)
			{
				goto IL_01fe;
			}
			switch (time_span)
			{
			case "P1W":
				break;
			case "P1M":
				goto IL_0099;
			case "P3M":
				goto IL_00fe;
			case "P6M":
				goto IL_0163;
			default:
				goto IL_0199;
			}
			TimeSpanUnits timeSpanUnits = null;
			double days = 4.000000000698492;
			int months = 0;
			TimeSpanUnits timeSpanUnits2 = timeSpanUnits;
			int years = 0;
			goto IL_026c;
			IL_01fe:
			bool flag = default(bool);
			TimeSpan timeSpan = ((SubscriptionInfo)flag).parseTimeSpan(time_span);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9BD07C (inside System.TimeSpan::TimeToTicks +0xFC)");
			object obj = null;
			double num = default(double);
			days = num;
			months = 0;
			timeSpanUnits2 = (TimeSpanUnits)obj;
			years = 0;
			goto IL_026c;
			IL_026c:
			timeSpanUnits2.days = days;
			timeSpanUnits2.months = months;
			timeSpanUnits2.years = years;
			return timeSpanUnits2;
			IL_0099:
			TimeSpanUnits timeSpanUnits3 = null;
			days = 0.0;
			months = 1;
			timeSpanUnits2 = timeSpanUnits3;
			years = 0;
			goto IL_026c;
			IL_00fe:
			TimeSpanUnits timeSpanUnits4 = null;
			days = 0.0;
			months = 3;
			timeSpanUnits2 = timeSpanUnits4;
			years = 0;
			goto IL_026c;
			IL_0163:
			TimeSpanUnits timeSpanUnits5 = null;
			days = 0.0;
			months = 6;
			timeSpanUnits2 = timeSpanUnits5;
			years = 0;
			goto IL_026c;
			IL_0199:
			flag = time_span == "P1Y";
			if (!flag)
			{
				goto IL_01fe;
			}
			TimeSpanUnits timeSpanUnits6 = null;
			days = 0.0;
			months = 0;
			timeSpanUnits2 = timeSpanUnits6;
			years = 1;
			goto IL_026c;
		}
	}
}
