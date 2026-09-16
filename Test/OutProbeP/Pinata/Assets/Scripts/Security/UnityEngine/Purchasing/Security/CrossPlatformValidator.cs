using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200001B")]
	public class CrossPlatformValidator
	{
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x10")]
		private GooglePlayValidator google;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x18")]
		private AppleValidator apple;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x20")]
		private string googleBundleId;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x28")]
		private string appleBundleId;

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x15D3778", Offset = "0x15D3778", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.Security.CrossPlatformValidator::.ctor(this, googlePublicKey, appleRootCert, appBundleId, appBundleId, appBundleId, v6);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CrossPlatformValidator(byte[] googlePublicKey, byte[] appleRootCert, string appBundleId)
		{
			string xiaomiBundleId_not_used = default(string);
			this._002Ector(googlePublicKey, appleRootCert, (byte[])(object)appBundleId, appBundleId, appBundleId, xiaomiBundleId_not_used);
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x15D3784", Offset = "0x15D3784", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1ED4A08]);\n\tv35 = *([v34 @ X8_v10]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, googlePublicKey, appleRootCert, unityChannelPublicKey_not_used, googleBundleId, appleBundleId, xiaomiBundleId_not_used, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029A23]) = v50;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tv53 = googlePublicKey == 0;\n\tif (v53) goto L_0029;\n\tv57 = new UnityEngine.Purchasing.Security.GooglePlayValidator();\n\tUnityEngine.Purchasing.Security.GooglePlayValidator::.ctor(v57, googlePublicKey);\n\tthis.google = v57;\nL_0029:\n\tv65 = appleRootCert == 0;\n\tif (v65) goto L_0034;\n\tv69 = new UnityEngine.Purchasing.Security.AppleValidator();\n\tUnityEngine.Purchasing.Security.AppleValidator::.ctor(v69, appleRootCert);\n\tthis.apple = v69;\nL_0034:\n\tthis.googleBundleId = googleBundleId;\n\tthis.appleBundleId = appleBundleId;\n\treturn;\n\tgoto L_0043;\n\tgoto L_0043;\n\tgoto L_0043;\nL_0043:\n\tX19 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0087;\n\tX0 = X19;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tX19 = *([X20]);\n\tX8 = *([1EDD7C0]);\n\tX1 = *([X19]);\n\tX0 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_007D;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tX0 = 0x846A20(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX0 = X19;\n\tX9 = *([X8+160]);\n\tX1 = *([X8+168]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F0AA88]);\n\tX9 = *([1ED6038]);\n\tX1 = X0;\n\tX8 = *([X8]);\n\tX3 = 0;\n\tX2 = *([X9]);\n\tX0 = X8;\n\tX0 = System.String::Concat(X0, X1, X2, X3);\n\tX8 = *([1EFF338]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X19;\n\tX20 = X0;\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(X0, X1, X2);\n\tX8 = *([1EC8940]);\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = *([X8]);\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_007D:\n\tX0 = 0 | 8;\n\tX0 = 0x6D1E60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0x870;\n\tX2 = 0;\n\tX0 = 0x6D2A00(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0087:\n\tX0 = X19;\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CrossPlatformValidator(byte[] googlePublicKey, byte[] appleRootCert, byte[] unityChannelPublicKey_not_used, string googleBundleId, string appleBundleId, string xiaomiBundleId_not_used)
		{
			if (googlePublicKey != null)
			{
				google = new GooglePlayValidator(googlePublicKey);
			}
			if (appleRootCert != null)
			{
				apple = new AppleValidator(appleRootCert);
			}
			this.googleBundleId = googleBundleId;
			this.appleBundleId = appleBundleId;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x15D39B8", Offset = "0x15D39B8", Length = "0x68C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EE9918]);\n\tv29 = *([v28 @ X8_v119]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, unityIAPReceipt, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029A24]) = v47;\nL_001A:\n\tv50 = UnityEngine.Purchasing.MiniJson::JsonDecode(unityIAPReceipt);\n\tv52 = v50 == 0;\n\tif (v52) goto L_0150;\n\tgoto L_FFFFFFFF;\n\tv141 = v141_asT == 0;\n\tif (v141) goto L_0137;\n\tv164 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v50, \"Store\");\n\tv205 = v164 == 0;\n\tif (v205) goto L_005D;\n\tv274 = *([v164 @ X0_v113 (System.String)]) != System.String;\n\tif (v274) goto L_015D;\nL_005D:\n\tv182 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v50, \"Payload\");\n\tv317 = v182 == 0;\n\tif (v317) goto L_006E;\n\tv325 = *([v182 @ X0_v115 (System.String)]) != System.String;\n\tif (v325) goto L_015F;\nL_006E:\n\tv184 = v164 == 0;\n\tif (v184) goto L_013D;\n\tv376 = System.String::op_Equality(v164, \"GooglePlay\");\n\tv397 = v376 == 0;\n\tif (v397) goto L_00F6;\n\tv378 = this.google == 0;\n\tif (v378) goto L_0163;\n\tv251 = UnityEngine.Purchasing.MiniJson::JsonDecode(v182);\n\tgoto L_FFFFFFFF;\n\tv218 = v218_asT == 0;\n\tif (v218) goto L_015B;\n\tv542 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v251, \"json\");\n\tv571 = v542 == 0;\n\tif (v571) goto L_00BB;\n\tv614 = *([v542 @ X0_v139 (System.String)]) != System.String;\n\tif (v614) goto L_01AE;\nL_00BB:\n\tv631 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v251, \"signature\");\n\tv683 = v631 == 0;\n\tif (v683) goto L_00D1;\n\tv695 = *([v631 @ X0_v141 (System.String)]) != System.String;\n\tif (v695) goto L_01B0;\nL_00D1:\n\tv767 = UnityEngine.Purchasing.Security.GooglePlayValidator::Validate(this.google, v542, v631);\n\tv914 = System.String::Equals(this.googleBundleId, v767.<packageName>k__BackingField);\n\tv916 = v914 == 0;\n\tif (v916) goto L_0199;\n\t// 226 NewArr v989 @ X0_v147 (UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt[]), typeof(UnityEngine.Purchasing.Security.IPurchaseReceipt[]), 1\n\t// 233 IsInst v877 @ X0_v149, typeof(UnityEngine.Purchasing.Security.AppleInAppPurchaseReceipt), v767 @ X0_v143 (UnityEngine.Purchasing.Security.GooglePlayReceipt)\n\tv1039 = v877 == 0;\n\tif (v1039) goto L_01A5;\n\tv879 = v989.Length == 0;\n\tif (v879) goto L_01A9;\n\tv989[0] = v767;\n\tgoto L_0135;\nL_00F6:\n\tv409 = System.String::op_Equality(v164, \"AppleAppStore\");\n\tv438 = v409 == 0;\n\tv439 = ~v438;\n\tif (v439) goto L_0105;\n\tv183 = System.String::op_Equality(v164, \"MacAppStore\");\n\tv185 = v183 == 0;\n\tif (v185) goto L_013D;\nL_0105:\n\tv462 = this.apple == 0;\n\tif (v462) goto L_0175;\n\tgoto L_0115;\n\tv498 = *([v485 @ X0_v123+E0]);\n\tv499 = v498 == 0;\n\tv500 = ~v499;\n\tif (v500) goto L_0115;\n\tv502 = \"il2cpp_codegen_runtime_class_init\"(v485, v457, v442, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0115:\n\tv507 = System.Convert::FromBase64String(v182);\n\tv527 = UnityEngine.Purchasing.Security.AppleValidator::Validate(this.apple, v507);\n\tv592 = System.String::Equals(this.appleBundleId, v527.<bundleID>k__BackingField);\n\tv594 = v592 == 0;\n\tif (v594) goto L_0188;\n\tv772 = System.Linq.Enumerable::ToArray(v527.inAppPurchaseReceipts);\nL_0135:\n\treturn v880;\nL_0137:\n\tthrow System.InvalidCastException;\nL_013D:\n\tv197 = System.String::Concat(\"Store not supported: \", v186);\n\tv209 = new UnityEngine.Purchasing.Security.StoreNotSupportedException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v209, v197);\n\tthrow v209;\nL_0150:\n\tv127 = new UnityEngine.Purchasing.Security.InvalidReceiptDataException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v127);\n\tthrow v127;\nL_015B:\n\tthrow System.InvalidCastException;\nL_015D:\n\tthrow System.InvalidCastException;\nL_015F:\n\tthrow System.InvalidCastException;\nL_0163:\n\tv387 = new UnityEngine.Purchasing.Security.MissingStoreSecretException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v387, \"Cannot validate a Google Play receipt without a Google Play public key.\");\n\tthrow v387;\n\tthrow System.NullReferenceException;\nL_0175:\n\tv472 = new UnityEngine.Purchasing.Security.MissingStoreSecretException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v472, \"Cannot validate an Apple receipt without supplying an Apple root certificate\");\n\tthrow v472;\n\tv536 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0188:\n\tv602 = new UnityEngine.Purchasing.Security.InvalidBundleIdException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v602);\n\tthrow v602;\n\tthrow System.NullReferenceException;\n\tv799 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0199:\n\tv924 = new UnityEngine.Purchasing.Security.InvalidBundleIdException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v924);\n\tthrow v924;\n\tv1015 = new System.NullReferenceException();\nL_01A5:\n\tv1045 = new System.ArrayTypeMismatchException();\n\tthrow v1045;\nL_01A9:\n\tv1066 = new System.IndexOutOfRangeException();\n\tthrow v1066;\nL_01AE:\n\tthrow System.InvalidCastException;\nL_01B0:\n\tv725 = new System.InvalidCastException();\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\n\tgoto L_01DB;\nL_01DB:\n\tv810 = System.String != 1;\n\tif (v810) goto L_0228;\n\tv839 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v725, System.String);\n\tv927 = *([v839 @ X0_v12 (System.String)]);\n\tv931 = \"il2cpp_vm_class_is_assignable_from\"(UnityEngine.Purchasing.Security.IAPSecurityException, *([v927 @ X19_v5 (Il2CppClass<System.String>)]), Il2CppMethodInfo, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv961 = v931 & 1;\n\tv962 = v961 == 0;\n\tif (v962) goto L_01F1;\n\tv970 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v931, *([v927 @ X19_v5 (Il2CppClass<System.String>)]));\n\tthrow System.TypeLoadException;\nL_01F1:\n\tv980 = *([v839 @ X0_v12 (System.String)]);\n\tv984 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v980 @ X8_v8 (Il2CppClass<System.String>)]), Il2CppMethodInfo, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv1018 = v984 & 1;\n\tv1019 = v1018 == 0;\n\tif (v1019) goto L_0203;\n\tv1046 = 0x6D2490(v984, *([v980 @ X8_v8 (Il2CppClass<System.String>)]), v1068, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv1056 = v927 == 0;\n\tv1057 = ~v1056;\n\tif (v1057) goto L_020A;\n\tgoto L_0215;\nL_0203:\n\tv1048 = 0x6D1E60(8, *([v980 @ X8_v8 (Il2CppClass<System.String>)]), Il2CppMethodInfo, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\t*([v1048 @ X0_v30]) = *([v839 @ X0_v12 (System.String)]);\n\tv1060 = 0x1E8A000 + 0x870;\n\tv1062 = 0x6D2A00(v1048, v1060, 0, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_020A:\n\tv1074 = *([v927 @ X19_v5 (Il2CppClass<System.String>)]);\n\t*([v1074 @ X8_v18+160])(v1078, v927, *([v1074 @ X8_v18+168]), v1068, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0215:\n\tv1089 = System.String::Concat(v1083, v1081, \")\");\n\tv1095 = new UnityEngine.Purchasing.Security.GenericValidationException();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v1095, v1089);\n\tthrow v1095;\nL_0228:\n\tv859 = 0x6D2380(v725, System.String, Il2CppMethodInfo, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturnVal2 = 0x846AA4(v859, System.String, Il2CppMethodInfo, v840, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn returnVal2;\n// 377 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IPurchaseReceipt[] Validate(string unityIAPReceipt)
		{
			//IL_0566: Expected I, but got O
			//IL_0507: Expected I, but got O
			//IL_05cb: Expected I, but got O
			//IL_0693: Expected I, but got O
			//IL_05b3: Expected O, but got I
			//IL_06a8: Expected O, but got I
			object obj = MiniJson.JsonDecode(unityIAPReceipt);
			string text3;
			string text7;
			string text8;
			if (obj != null)
			{
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				if (dictionary != null)
				{
					string text = (string)((Dictionary<string, object>)obj).get_Item("Store");
					if (text == null || (object)text.GetType() == typeof(string))
					{
						string text2 = (string)((Dictionary<string, object>)obj).get_Item("Payload");
						if (text2 == null || (object)text2.GetType() == typeof(string))
						{
							bool flag = text == null;
							text3 = text;
							if (!flag)
							{
								if (text == "GooglePlay")
								{
									if (google != null)
									{
										object obj2 = MiniJson.JsonDecode(text2);
										Dictionary<string, object> dictionary2 = obj2 as Dictionary<string, object>;
										if (dictionary2 != null)
										{
											string text4 = (string)((Dictionary<string, object>)obj2).get_Item("json");
											if (text4 != null)
											{
												bool flag2 = (object)text4.GetType() != typeof(string);
												IntPtr intPtr = (IntPtr)0;
												if (flag2)
												{
													throw new InvalidCastException();
												}
											}
											string text5 = (string)((Dictionary<string, object>)obj2).get_Item("signature");
											if (text5 != null)
											{
												bool flag3 = (object)text5.GetType() != typeof(string);
												IntPtr intPtr = (IntPtr)0;
												if (flag3)
												{
													InvalidCastException ex = new InvalidCastException();
													if ((IntPtr)typeof(string) == (IntPtr)1)
													{
														string text6 = (string)((Dictionary<string, object>)(object)ex).get_Item((string)(object)typeof(string));
														IntPtr intPtr2 = (IntPtr)text6;
														Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
														object obj3 = default(object);
														if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
														{
															object obj4 = ((Dictionary<string, object>)obj3).get_Item((string)(long)intPtr2);
															intPtr = (IntPtr)0;
															throw new TypeLoadException();
														}
														IntPtr intPtr3 = (IntPtr)text6;
														Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
														object obj5 = default(object);
														if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
														{
															Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
															bool flag4 = intPtr2 == (IntPtr)0;
															bool flag5 = !flag4;
															text7 = "Cannot validate due to unhandled exception. (";
															if (!flag5)
															{
																text8 = null;
																text7 = "Cannot validate due to unhandled exception. (";
																goto IL_071b;
															}
														}
														else
														{
															Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
															object obj6 = text6;
															int num = 32022528 + 2160;
															Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
															intPtr = (IntPtr)null;
															text7 = text6;
														}
														object obj7 = (long)intPtr2;
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1074 @ X8_v18+160] (should have been resolved before IL gen)");
														string text9 = default(string);
														text8 = text9;
														goto IL_071b;
													}
													Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
													Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
													IPurchaseReceipt[] result = default(IPurchaseReceipt[]);
													return result;
												}
											}
											GooglePlayReceipt googlePlayReceipt = google.Validate(text4, text5);
											if (googleBundleId.Equals(googlePlayReceipt.packageName))
											{
												AppleInAppPurchaseReceipt[] array = (AppleInAppPurchaseReceipt[])new IPurchaseReceipt[1];
												object obj8 = googlePlayReceipt as AppleInAppPurchaseReceipt;
												if (obj8 != null)
												{
													if (array.Length != 0)
													{
														array[0] = (AppleInAppPurchaseReceipt)(object)googlePlayReceipt;
														return array;
													}
													IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
													IntPtr intPtr = (IntPtr)null;
													throw ex2;
												}
												ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
												throw ex3;
											}
											InvalidBundleIdException ex4 = (InvalidBundleIdException)new IAPSecurityException();
											throw ex4;
										}
										throw new InvalidCastException();
									}
									MissingStoreSecretException ex5 = (MissingStoreSecretException)new IAPSecurityException("Cannot validate a Google Play receipt without a Google Play public key.");
									throw ex5;
								}
								if (!(text == "AppleAppStore"))
								{
									bool flag6 = text == "MacAppStore";
									bool flag7 = !flag6;
									text3 = text;
									if (flag7)
									{
										goto IL_043f;
									}
								}
								if (apple != null)
								{
									byte[] receiptData = Convert.FromBase64String(text2);
									AppleReceipt appleReceipt = apple.Validate(receiptData);
									if (appleBundleId.Equals(appleReceipt.bundleID))
									{
										return appleReceipt.inAppPurchaseReceipts.ToArray();
									}
									InvalidBundleIdException ex6 = (InvalidBundleIdException)new IAPSecurityException();
									throw ex6;
								}
								MissingStoreSecretException ex7 = (MissingStoreSecretException)new IAPSecurityException("Cannot validate an Apple receipt without supplying an Apple root certificate");
								throw ex7;
							}
							goto IL_043f;
						}
						throw new InvalidCastException();
					}
					throw new InvalidCastException();
				}
				throw new InvalidCastException();
			}
			InvalidReceiptDataException ex8 = (InvalidReceiptDataException)new IAPSecurityException();
			throw ex8;
			IL_071b:
			string message = text7 + text8 + ")";
			IAPSecurityException ex9 = new IAPSecurityException(message);
			throw ex9;
			IL_043f:
			string message2 = "Store not supported: " + text3;
			StoreNotSupportedException ex10 = (StoreNotSupportedException)new IAPSecurityException(message2);
			throw ex10;
		}
	}
}
