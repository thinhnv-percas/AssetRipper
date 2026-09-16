using System;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.State;
using UnityEngine;

namespace GameAnalyticsSDK.Validators
{
	[Token(Token = "0x2000010")]
	internal static class GAValidator
	{
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x15A81D0", Offset = "0x15A81D0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB8AA8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pattern, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202983E]) = v41;\nL_0015:\n\tv42 = s == 0;\n\tif (v42) goto L_0037;\n\tv43 = pattern == 0;\n\tif (v43) goto L_0037;\n\tgoto L_002E;\n\tv77 = *([v53 @ X0_v3+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002E;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v53, pattern, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002E:\n\treturnVal2 = System.Text.RegularExpressions.Regex::IsMatch(s, pattern);\n\treturn returnVal2;\nL_0037:\n\treturn 0;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool StringMatch(string s, string pattern)
		{
			if (s != null && pattern != null)
			{
				return Regex.IsMatch(s, pattern);
			}
			return false;
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x15A8264", Offset = "0x15A8264", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EDC338]);\n\tv31 = *([v30 @ X8_v23]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, amount, cartType, itemType, itemId, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202983F]) = v47;\nL_001A:\n\tv49 = GameAnalyticsSDK.Validators.GAValidator::ValidateCurrency(currency);\n\tv51 = v49 == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv54 = GameAnalyticsSDK.Validators.GAValidator::ValidateShortString(cartType, 1);\n\tv60 = v54 == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tv80 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(itemType, 0);\n\tv90 = v80 == 0;\n\tif (v90) goto L_FFFFFFFF;\n\tv101 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(itemType);\n\tv107 = v101 == 0;\n\tif (v107) goto L_FFFFFFFF;\n\tv129 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(itemId, 0);\n\tv132 = v129 == 0;\n\tif (v132) goto L_FFFFFFFF;\n\tv134 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(itemId);\n\tv118 = v134 == 0;\n\tif (v118) goto L_FFFFFFFF;\n\tgoto L_0069;\n\tgoto L_004E;\n\tgoto L_004E;\n\tgoto L_FFFFFFFF;\nL_004E:\n\tv77 = System.String::Concat(v65, v61);\n\tgoto L_005F;\n\tv91 = *([v85 @ X8_v6+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tgoto L_005F;\n\tv104 = v85;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v104, v61, v76, itemType, itemId, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_005F:\n\tUnityEngine.Debug::Log(v77);\nL_0069:\n\treturn returnVal1;\n\tgoto L_FFFFFFFF;\n\tgoto L_004E;\n\treturn X0;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateBusinessEvent(string currency, int amount, string cartType, string itemType, string itemId)
		{
			string text2;
			string text3;
			if (ValidateCurrency(currency))
			{
				if (ValidateShortString(cartType, canBeEmpty: true))
				{
					string text4;
					if (ValidateEventPartLength(itemType, allowNull: false))
					{
						if (ValidateEventPartCharacters(itemType))
						{
							string text;
							if (ValidateEventPartLength(itemId, allowNull: false))
							{
								if (ValidateEventPartCharacters(itemId))
								{
									return true;
								}
								text = "Validation fail - business event - itemId: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
							}
							else
							{
								text = "Validation fail - business event - itemId. Cannot be (null), empty or above 64 characters. String: ";
							}
							text2 = itemId;
							text3 = text;
							goto IL_019e;
						}
						text4 = "Validation fail - business event - itemType: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
					}
					else
					{
						text4 = "Validation fail - business event - itemType: Cannot be (null), empty or above 64 characters. String: ";
					}
					text2 = itemType;
					text3 = text4;
				}
				else
				{
					text2 = cartType;
					text3 = "Validation fail - business event - cartType. Cannot be above 32 length. String: ";
				}
			}
			else
			{
				text2 = currency;
				text3 = "Validation fail - business event - currency: Cannot be (null) and need to be A-Z, 3 characters and in the standard at openexchangerates.org. Failed currency: ";
			}
			goto IL_019e;
			IL_019e:
			string message = text3 + text2;
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x15A8550", Offset = "0x15A8550", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1EE6D70]);\n\tv35 = *([v34 @ X8_v53]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, currency, itemType, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029840]) = v50;\nL_001D:\n\tv53 = System.String::IsNullOrEmpty(v201);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0031;\n\tgoto L_FFFFFFFF;\n\tv64 = *([v58 @ X0_v48+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_FFFFFFFF;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v58, v52, itemType, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\nL_002F:\n\tv167 = *([v125 @ X8_v4 (System.String)]);\n\tgoto L_007B;\nL_0031:\n\tv62 = flowType == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0046;\n\tgoto L_0044;\n\tv128 = *([v75 @ X0_v44+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0044;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v75, v52, itemType, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\nL_0044:\n\tUnityEngine.Debug::Log(\"Validation fail - resource event - flowType: Invalid flowType\");\nL_0046:\n\tv88 = GameAnalyticsSDK.State.GAState::HasAvailableResourceCurrency(v201);\n\tv136 = v88 == 0;\n\tif (v136) goto L_FFFFFFFF;\n\tv94 = amount > 0;\n\tif (v94) goto L_0089;\n\t// 92 Box v188 @ X0_v41 (System.Object), typeof(System.Single), &amount @ V0 (System.Single)\n\tv253 = System.String::Concat(\"Validation fail - resource event - amount: Float amount cannot be 0 or negative. Value: \", v188);\n\tgoto L_0072;\nL_006A:\n\tv253 = System.String::Concat(v204, v201);\nL_0072:\n\tgoto L_FFFFFFFF;\n\tv270 = *([v174 @ X8_v11+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_FFFFFFFF;\n\tv283 = v174;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v283, v166, v141, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\nL_007B:\n\tUnityEngine.Debug::Log(v167);\nL_0086:\n\treturn returnVal1;\nL_0089:\n\tv190 = System.String::IsNullOrEmpty(itemType);\n\tv252 = v190 == 0;\n\tif (v252) goto L_009E;\n\tgoto L_FFFFFFFF;\n\tv275 = *([v263 @ X0_v37+E0]);\n\tv276 = v275 == 0;\n\tv277 = ~v276;\n\tif (v277) goto L_FFFFFFFF;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v263, v120, itemType, itemId, methodInfo, v38, v39, v40, amount, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_002F;\nL_009E:\n\tv269 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(itemType, 0);\n\tv282 = v269 == 0;\n\tif (v282) goto L_FFFFFFFF;\n\tv285 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(itemType);\n\tv289 = v285 == 0;\n\tif (v289) goto L_FFFFFFFF;\n\tv291 = GameAnalyticsSDK.State.GAState::HasAvailableResourceItemType(itemType);\n\tv292 = v291 == 0;\n\tif (v292) goto L_FFFFFFFF;\n\tv299 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(itemId, 0);\n\tv302 = v299 == 0;\n\tif (v302) goto L_FFFFFFFF;\n\tv304 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(itemId);\n\tv233 = v304 == 0;\n\tif (v233) goto L_FFFFFFFF;\n\tgoto L_0086;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006A;\n\tgoto L_FFFFFFFF;\n\tgoto L_006A;\n\treturn X0;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateResourceEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId)
		{
			//IL_029e: Expected I, but got O
			//IL_0288: Expected O, but got I
			//IL_00e3: Expected I, but got O
			string text = default(string);
			string text2;
			if (string.IsNullOrEmpty(text))
			{
				text2 = "Validation fail - resource event - currency: Cannot be (null)";
				goto IL_0296;
			}
			if (flowType == GAResourceFlowType.Undefined)
			{
				Debug.Log("Validation fail - resource event - flowType: Invalid flowType");
			}
			string text3;
			string text5;
			if (GAState.HasAvailableResourceCurrency(text))
			{
				if (!(amount > 0f))
				{
					object obj = amount;
					text3 = "Validation fail - resource event - amount: Float amount cannot be 0 or negative. Value: " + obj;
					goto IL_00db;
				}
				if (string.IsNullOrEmpty(itemType))
				{
					text2 = "Validation fail - resource event - itemType: Cannot be (null)";
					goto IL_0296;
				}
				string text6;
				if (ValidateEventPartLength(itemType, allowNull: false))
				{
					if (ValidateEventPartCharacters(itemType))
					{
						if (GAState.HasAvailableResourceItemType(itemType))
						{
							string text4;
							if (ValidateEventPartLength(itemId, allowNull: false))
							{
								if (ValidateEventPartCharacters(itemId))
								{
									return true;
								}
								text4 = "Validation fail - resource event - itemId: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
							}
							else
							{
								text4 = "Validation fail - resource event - itemId: Cannot be (null), empty or above 64 characters. String: ";
							}
							text = itemId;
							text5 = text4;
							goto IL_02d2;
						}
						text6 = "Validation fail - resource event - itemType: Not found in list of pre-defined available resource itemTypes. String: ";
					}
					else
					{
						text6 = "Validation fail - resource event - itemType: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
					}
				}
				else
				{
					text6 = "Validation fail - resource event - itemType: Cannot be (null), empty or above 64 characters. String: ";
				}
				text = itemType;
				text5 = text6;
			}
			else
			{
				text5 = "Validation fail - resource event - currency: Not found in list of pre-defined resource currencies. String: ";
			}
			goto IL_02d2;
			IL_00db:
			IntPtr intPtr = (IntPtr)text3;
			goto IL_027f;
			IL_027f:
			Debug.Log((long)intPtr);
			return false;
			IL_0296:
			intPtr = (IntPtr)text2;
			goto IL_027f;
			IL_02d2:
			text3 = text5 + text;
			goto IL_00db;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x15A87A8", Offset = "0x15A87A8", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EB67F0]);\n\tv31 = *([v30 @ X8_v54]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, progression01, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029841]) = v47;\nL_0019:\n\tv48 = progressionStatus == 0;\n\tif (v48) goto L_0065;\n\tv51 = System.String::IsNullOrEmpty(progression03);\n\tv59 = v51 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0030;\n\tv72 = System.String::IsNullOrEmpty(progression02);\n\tv79 = v72 == 0;\n\tif (v79) goto L_0030;\n\tv76 = System.String::IsNullOrEmpty(v109);\n\tv78 = v76 == 0;\n\tif (v78) goto L_009C;\nL_0030:\n\tv82 = System.String::IsNullOrEmpty(progression02);\n\tv101 = v82 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_004C;\n\tv121 = System.String::IsNullOrEmpty(v109);\n\tv125 = v121 == 0;\n\tif (v125) goto L_004C;\n\tgoto L_FFFFFFFF;\n\tv177 = *([v158 @ X0_v54+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_FFFFFFFF;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v158, v84, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_006D;\nL_004C:\n\tv127 = System.String::IsNullOrEmpty(v109);\n\tv132 = v127 == 0;\n\tif (v132) goto L_007C;\n\tgoto L_FFFFFFFF;\n\tv183 = *([v164 @ X0_v49+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_FFFFFFFF;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v164, v85, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_006D;\nL_0065:\n\tgoto L_FFFFFFFF;\n\tv61 = *([v54 @ X0_v7+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_FFFFFFFF;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v54, progression01, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_006D:\n\tv110 = *([v94 @ X8_v5 (System.String)]);\nL_006F:\n\tUnityEngine.Debug::Log(v110);\nL_0079:\n\treturn returnVal1;\nL_007C:\n\tv170 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(v109, 0);\n\tv190 = v170 == 0;\n\tif (v190) goto L_FFFFFFFF;\n\tv192 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(v109);\n\tv196 = v192 == 0;\n\tif (v196) goto L_FFFFFFFF;\n\tv205 = System.String::IsNullOrEmpty(progression02);\n\tv220 = v205 == 0;\n\tif (v220) goto L_00BD;\nL_008D:\n\tv234 = System.String::IsNullOrEmpty(progression03);\n\tv243 = v234 == 0;\n\tif (v243) goto L_00CC;\n\tgoto L_0079;\n\tgoto L_FFFFFFFF;\nL_009C:\n\tgoto L_FFFFFFFF;\n\tv171 = *([v152 @ X0_v61+E0]);\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_FFFFFFFF;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v152, v74, progression02, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_006D;\nL_00AA:\n\tv218 = System.String::Concat(v209, v109);\n\tgoto L_FFFFFFFF;\n\tv237 = *([v117 @ X8_v16+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tgoto L_FFFFFFFF;\n\tv246 = v117;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v246, v109, v104, progression03, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_006F;\nL_00BD:\n\tv236 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(progression02, 1);\n\tv245 = v236 == 0;\n\tif (v245) goto L_FFFFFFFF;\n\tv229 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(progression02);\n\tv259 = v229 == 0;\n\tv231 = ~v259;\n\tif (v231) goto L_008D;\n\tgoto L_FFFFFFFF;\nL_00CC:\n\tv252 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartLength(progression03, 1);\n\tv257 = v252 == 0;\n\tif (v257) goto L_FFFFFFFF;\n\tv249 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(progression03);\n\tv267 = v249 == 0;\n\tv250 = ~v267;\n\tif (v250) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00AA;\n\tgoto L_00AA;\n\treturn X0;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateProgressionEvent(GAProgressionStatus progressionStatus, string progression01, string progression02, string progression03)
		{
			//IL_036c: Expected I, but got O
			//IL_038c: Expected O, but got I
			//IL_0242: Expected I, but got O
			string text = default(string);
			string text2;
			string text4;
			if (progressionStatus != GAProgressionStatus.Undefined)
			{
				if (string.IsNullOrEmpty(progression03) || !string.IsNullOrEmpty(progression02) || string.IsNullOrEmpty(text))
				{
					if (!string.IsNullOrEmpty(progression02) && string.IsNullOrEmpty(text))
					{
						text2 = "Validation fail - progression event: 02 found but not 01. Progression must be set as either 01, 01+02 or 01+02+03";
					}
					else
					{
						if (!string.IsNullOrEmpty(text))
						{
							string text5;
							if (ValidateEventPartLength(text, allowNull: false))
							{
								if (ValidateEventPartCharacters(text))
								{
									if (string.IsNullOrEmpty(progression02))
									{
										goto IL_01d3;
									}
									string text3;
									if (ValidateEventPartLength(progression02, allowNull: true))
									{
										if (ValidateEventPartCharacters(progression02))
										{
											goto IL_01d3;
										}
										text3 = "Validation fail - progression event - progression02: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
									}
									else
									{
										text3 = "Validation fail - progression event - progression02: Cannot be empty or above 64 characters. String: ";
									}
									text = progression02;
									text4 = text3;
									goto IL_03c4;
								}
								text5 = "Validation fail - progression event - progression01: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
							}
							else
							{
								text5 = "Validation fail - progression event - progression01: Cannot be (null), empty or above 64 characters. String: ";
							}
							text4 = text5;
							goto IL_03c4;
						}
						text2 = "Validation fail - progression event: progression01 not valid. Progressions must be set as either 01, 01+02 or 01+02+03";
					}
				}
				else
				{
					text2 = "Validation fail - progression event: 03 found but 01+02 are invalid. Progression must be set as either 01, 01+02 or 01+02+03.";
				}
			}
			else
			{
				text2 = "Validation fail - progression event: Invalid progression status.";
			}
			IntPtr intPtr = (IntPtr)text2;
			goto IL_0383;
			IL_0383:
			Debug.Log((long)intPtr);
			return false;
			IL_01fd:
			return true;
			IL_03c4:
			string text6 = text4 + text;
			intPtr = (IntPtr)text6;
			goto IL_0383;
			IL_01d3:
			if (string.IsNullOrEmpty(progression03))
			{
				goto IL_01fd;
			}
			string text7;
			if (ValidateEventPartLength(progression03, allowNull: true))
			{
				if (ValidateEventPartCharacters(progression03))
				{
					goto IL_01fd;
				}
				text7 = "Validation fail - progression event - progression03: Cannot contain other characters than A-z, 0-9, -_., ()!?. String: ";
			}
			else
			{
				text7 = "Validation fail - progression event - progression03: Cannot be empty or above 64 characters. String: ";
			}
			text = progression03;
			text4 = text7;
			goto IL_03c4;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x15A8A34", Offset = "0x15A8A34", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F00B10]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029842]) = v38;\nL_0014:\n\tv40 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventIdLength(eventId);\n\tv42 = v40 == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv44 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventIdCharacters(eventId);\n\tv48 = v44 == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tgoto L_003F;\n\tgoto L_0027;\nL_0027:\n\tv56 = System.String::Concat(*([v51 @ X8_v3 (System.String)]), eventId);\n\tgoto L_0038;\n\tv82 = *([v62 @ X8_v6+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_0038;\n\tv88 = v62;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v88, v54, v55, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0038:\n\tUnityEngine.Debug::Log(v56);\nL_003F:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateDesignEvent(string eventId)
		{
			string text;
			if (ValidateEventIdLength(eventId))
			{
				if (ValidateEventIdCharacters(eventId))
				{
					return true;
				}
				text = "Validation fail - design event - eventId: Non valid characters. Only allowed A-z, 0-9, -_., ()!?. String: ";
			}
			else
			{
				text = "Validation fail - design event - eventId: Cannot be (null) or empty. Only 5 event parts allowed seperated by :. Each part need to be 32 characters or less. String: ";
			}
			string message = text + eventId;
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15A8BD0", Offset = "0x15A8BD0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC16B0]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029843]) = v41;\nL_0015:\n\tv42 = severity == 0;\n\tif (v42) goto L_0034;\n\tv46 = GameAnalyticsSDK.Validators.GAValidator::ValidateLongString(message, 1);\n\tv54 = v46 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0047;\n\tgoto L_FFFFFFFF;\n\tv93 = *([v67 @ X0_v11+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_FFFFFFFF;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v67, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_003E;\nL_0034:\n\tgoto L_FFFFFFFF;\n\tv56 = *([v49 @ X0_v6+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_FFFFFFFF;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v49, message, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003E:\n\tUnityEngine.Debug::Log(*([v80 @ X8_v3 (System.String)]));\nL_0047:\n\treturn v77;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateErrorEvent(GAErrorSeverity severity, string message)
		{
			int result;
			string message2;
			if (severity != GAErrorSeverity.Undefined)
			{
				bool flag = ValidateLongString(message, canBeEmpty: true);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				result = 1;
				if (flag3)
				{
					goto IL_008b;
				}
				message2 = "Validation fail - error event - message: Message cannot be above 8192 characters.";
			}
			else
			{
				message2 = "Validation fail - error event - severity: Severity was unsupported value.";
			}
			Debug.Log(message2);
			result = 0;
			goto IL_008b;
			IL_008b:
			return (byte)result != 0;
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x15A8D04", Offset = "0x15A8D04", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F07B00]);\n\tv31 = *([v30 @ X8_v34]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029844]) = v47;\nL_0019:\n\tv48 = adAction == 0;\n\tif (v48) goto L_0031;\n\tv49 = adType == 0;\n\tif (v49) goto L_0040;\n\tv58 = GameAnalyticsSDK.Validators.GAValidator::ValidateShortString(adSdkName, 0);\n\tv75 = v58 == 0;\n\tif (v75) goto L_004F;\n\tv99 = GameAnalyticsSDK.Validators.GAValidator::ValidateString(adPlacement, 0);\n\tv108 = v99 == 0;\n\tif (v108) goto L_005E;\n\tgoto L_0072;\nL_0031:\n\tgoto L_FFFFFFFF;\n\tv65 = *([v52 @ X0_v6+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v52, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0068;\nL_0040:\n\tgoto L_FFFFFFFF;\n\tv76 = *([v61 @ X0_v9+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v61, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0068;\nL_004F:\n\tgoto L_FFFFFFFF;\n\tv109 = *([v102 @ X0_v14+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_FFFFFFFF;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v102, v57, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0068;\nL_005E:\n\tgoto L_FFFFFFFF;\n\tv133 = *([v129 @ X0_v19+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_FFFFFFFF;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v129, v86, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0068:\n\tUnityEngine.Debug::Log(*([v93 @ X8_v3 (System.String)]));\nL_0072:\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateAdEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
			string message;
			if (adAction != GAAdAction.Undefined)
			{
				if (adType != GAAdType.Undefined)
				{
					if (ValidateShortString(adSdkName, canBeEmpty: false))
					{
						if (ValidateString(adPlacement, canBeEmpty: false))
						{
							return true;
						}
						message = "Validation fail - ad event - message: Ad placement cannot be above 64 characters.";
					}
					else
					{
						message = "Validation fail - ad event - message: Ad SDK name cannot be above 32 characters.";
					}
				}
				else
				{
					message = "Validation fail - ad event - adType: Ad type was unsupported value.";
				}
			}
			else
			{
				message = "Validation fail - ad event - adAction: Ad action was unsupported value.";
			}
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x15A8EB4", Offset = "0x15A8EB4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F01FB0]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, gameSecret, type, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029845]) = v44;\nL_0019:\n\tv47 = GameAnalyticsSDK.Validators.GAValidator::ValidateKeys(gameKey, gameSecret);\n\tv49 = v47 == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tv50 = type == 0;\n\tif (v50) goto L_0027;\n\tgoto L_003A;\nL_0027:\n\tgoto L_0031;\n\tv77 = *([v63 @ X0_v7+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0031;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v63, v46, type, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0031:\n\tUnityEngine.Debug::Log(\"Validation fail - sdk error event - type: Type was unsupported value.\");\nL_003A:\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateSdkErrorEvent(string gameKey, string gameSecret, GAErrorSeverity type)
		{
			if (ValidateKeys(gameKey, gameSecret))
			{
				if (type != GAErrorSeverity.Undefined)
				{
					return true;
				}
				Debug.Log("Validation fail - sdk error event - type: Type was unsupported value.");
			}
			return false;
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15A8F58", Offset = "0x15A8F58", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB5890]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, gameSecret, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029846]) = v41;\nL_0019:\n\tv46 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(gameKey, \"^[A-z0-9]{32}$\");\n\tv48 = v46 == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv53 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(gameSecret, \"^[A-z0-9]{40}$\");\n\tv57 = v53 == 0;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateKeys(string gameKey, string gameSecret)
		{
			if (StringMatch(gameKey, "^[A-z0-9]{32}$") && StringMatch(gameSecret, "^[A-z0-9]{40}$"))
			{
				return true;
			}
			return false;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x15A83C0", Offset = "0x15A83C0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC4810]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029847]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(currency);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0029;\n\treturn 0;\nL_0029:\n\treturnVal2 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(currency, \"^[A-Z]{3}$\");\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateCurrency(string currency)
		{
			if (string.IsNullOrEmpty(currency))
			{
				return false;
			}
			return StringMatch(currency, "^[A-Z]{3}$");
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x15A8498", Offset = "0x15A8498", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = allowNull == 0;\n\tif (v12) goto L_0013;\n\tv15 = System.String::IsNullOrEmpty(eventPart);\n\tv19 = v15 == 0;\n\tif (v19) goto L_0013;\n\tgoto L_002C;\nL_0013:\n\tv22 = System.String::IsNullOrEmpty(eventPart);\n\tv25 = v22 == 0;\n\tif (v25) goto L_001E;\n\tgoto L_002C;\nL_001E:\n\tv51 = eventPart.m_stringLength - 0x41;\n\tv48 = v51 < 0;\n\tv42 = eventPart.m_stringLength ^ 0x41;\n\tv39 = eventPart.m_stringLength ^ v51;\n\tv36 = v42 & v39;\n\tv33 = v36 < 0;\n\tv67 = v48 == v33;\n\tv30 = ~v67;\nL_002C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateEventPartLength(string eventPart, bool allowNull)
		{
			if (allowNull && string.IsNullOrEmpty(eventPart))
			{
				return true;
			}
			if (string.IsNullOrEmpty(eventPart))
			{
				return false;
			}
			int num = eventPart.Length - 65;
			bool flag = num < 0;
			int num2 = eventPart.Length ^ 0x41;
			int num3 = eventPart.Length ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x15A8500", Offset = "0x15A8500", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC56B0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029848]) = v38;\nL_001C:\n\treturnVal1 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(eventPart, \"^[A-Za-z0-9\\\\s\\\\-_\\\\.\\\\(\\\\)\\\\!\\\\?]{1,64}$\");\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateEventPartCharacters(string eventPart)
		{
			return StringMatch(eventPart, "^[A-Za-z0-9\\s\\-_\\.\\(\\)\\!\\?]{1,64}$");
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x15A8AF0", Offset = "0x15A8AF0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EB0738]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029849]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(eventId);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0029;\n\treturn 0;\nL_0029:\n\treturnVal2 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(eventId, \"^[^:]{1,64}(?::[^:]{1,64}){0,4}$\");\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateEventIdLength(string eventId)
		{
			if (string.IsNullOrEmpty(eventId))
			{
				return false;
			}
			return StringMatch(eventId, "^[^:]{1,64}(?::[^:]{1,64}){0,4}$");
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15A8B60", Offset = "0x15A8B60", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF2318]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202984A]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(eventId);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0029;\n\treturn 0;\nL_0029:\n\treturnVal2 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(eventId, \"^[A-Za-z0-9\\\\s\\\\-_\\\\.\\\\(\\\\)\\\\!\\\\?]{1,64}(:[A-Za-z0-9\\\\s\\\\-_\\\\.\\\\(\\\\)\\\\!\\\\?]{1,64}){0,4}$\");\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateEventIdCharacters(string eventId)
		{
			if (string.IsNullOrEmpty(eventId))
			{
				return false;
			}
			return StringMatch(eventId, "^[A-Za-z0-9\\s\\-_\\.\\(\\)\\!\\?]{1,64}(:[A-Za-z0-9\\s\\-_\\.\\(\\)\\!\\?]{1,64}){0,4}$");
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x15A8FE0", Offset = "0x15A8FE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = GameAnalyticsSDK.Validators.GAValidator::ValidateShortString(build, 0);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateBuild(string build)
		{
			return ValidateShortString(build, canBeEmpty: false);
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x15A8FE8", Offset = "0x15A8FE8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EB9718]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202984B]) = v38;\nL_0015:\n\tv41 = GameAnalyticsSDK.Validators.GAValidator::ValidateString(uId, 0);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0021;\n\tgoto L_0032;\nL_0021:\n\tgoto L_002B;\n\tv63 = *([v47 @ X0_v5+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v47, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Debug::Log(\"Validation fail - user id: id cannot be (null), empty or above 64 characters.\");\nL_0032:\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateUserId(string uId)
		{
			if (ValidateString(uId, canBeEmpty: false))
			{
				return true;
			}
			Debug.Log("Validation fail - user id: id cannot be (null), empty or above 64 characters.");
			return false;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x15A8430", Offset = "0x15A8430", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = canBeEmpty == 0;\n\tif (v12) goto L_0013;\n\tv15 = System.String::IsNullOrEmpty(shortString);\n\tv19 = v15 == 0;\n\tif (v19) goto L_0013;\n\tgoto L_002C;\nL_0013:\n\tv22 = System.String::IsNullOrEmpty(shortString);\n\tv25 = v22 == 0;\n\tif (v25) goto L_001E;\n\tgoto L_002C;\nL_001E:\n\tv51 = shortString.m_stringLength - 0x21;\n\tv48 = v51 < 0;\n\tv42 = shortString.m_stringLength ^ 0x21;\n\tv39 = shortString.m_stringLength ^ v51;\n\tv36 = v42 & v39;\n\tv33 = v36 < 0;\n\tv67 = v48 == v33;\n\tv30 = ~v67;\nL_002C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateShortString(string shortString, bool canBeEmpty)
		{
			if (canBeEmpty && string.IsNullOrEmpty(shortString))
			{
				return true;
			}
			if (string.IsNullOrEmpty(shortString))
			{
				return false;
			}
			int num = shortString.Length - 33;
			bool flag = num < 0;
			int num2 = shortString.Length ^ 0x21;
			int num3 = shortString.Length ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x15A8E4C", Offset = "0x15A8E4C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = canBeEmpty == 0;\n\tif (v12) goto L_0013;\n\tv15 = System.String::IsNullOrEmpty(s);\n\tv19 = v15 == 0;\n\tif (v19) goto L_0013;\n\tgoto L_002C;\nL_0013:\n\tv22 = System.String::IsNullOrEmpty(s);\n\tv25 = v22 == 0;\n\tif (v25) goto L_001E;\n\tgoto L_002C;\nL_001E:\n\tv51 = s.m_stringLength - 0x41;\n\tv48 = v51 < 0;\n\tv42 = s.m_stringLength ^ 0x41;\n\tv39 = s.m_stringLength ^ v51;\n\tv36 = v42 & v39;\n\tv33 = v36 < 0;\n\tv67 = v48 == v33;\n\tv30 = ~v67;\nL_002C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateString(string s, bool canBeEmpty)
		{
			if (canBeEmpty && string.IsNullOrEmpty(s))
			{
				return true;
			}
			if (string.IsNullOrEmpty(s))
			{
				return false;
			}
			int num = s.Length - 65;
			bool flag = num < 0;
			int num2 = s.Length ^ 0x41;
			int num3 = s.Length ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			bool flag3 = flag == flag2;
			return !flag3;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x15A8C9C", Offset = "0x15A8C9C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = canBeEmpty == 0;\n\tif (v12) goto L_0013;\n\tv15 = System.String::IsNullOrEmpty(longString);\n\tv19 = v15 == 0;\n\tif (v19) goto L_0013;\n\tgoto L_002D;\nL_0013:\n\tv22 = System.String::IsNullOrEmpty(longString);\n\tv25 = v22 == 0;\n\tif (v25) goto L_001E;\n\tgoto L_002D;\nL_001E:\n\tv51 = longString.m_stringLength - 0x2000;\n\tv48 = v51 < 0;\n\tv45 = v51 == 0;\n\tv42 = longString.m_stringLength ^ 0x2000;\n\tv39 = longString.m_stringLength ^ v51;\n\tv36 = v42 & v39;\n\tv33 = v36 < 0;\n\tv67 = v48 == v33;\n\tv68 = ~v67;\n\tv30 = v68 | v45;\nL_002D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateLongString(string longString, bool canBeEmpty)
		{
			if (canBeEmpty && string.IsNullOrEmpty(longString))
			{
				return true;
			}
			if (string.IsNullOrEmpty(longString))
			{
				return false;
			}
			int num = longString.Length - 8192;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = longString.Length ^ 0x2000;
			int num3 = longString.Length ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag4;
			return flag5 || flag2;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x15A9078", Offset = "0x15A9078", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF79F8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202984C]) = v38;\nL_001C:\n\treturnVal1 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(connectionType, \"^(wwan|wifi|lan|offline)$\");\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateConnectionType(string connectionType)
		{
			return StringMatch(connectionType, "^(wwan|wifi|lan|offline)$");
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x15A0FEC", Offset = "0x15A0FEC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = *([1EACB78]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202984D]) = v38;\nL_001F:\n\treturnVal1 = GameAnalyticsSDK.Validators.GAValidator::ValidateArrayOfStrings(0x14, 0x20, 0, \"custom dimensions\", customDimensions);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateCustomDimensions(params string[] customDimensions)
		{
			//IL_0022: Expected I8, but got I4
			//IL_0022: Expected I8, but got I4
			return ValidateArrayOfStrings(20L, 32L, allowNoValues: false, "custom dimensions", customDimensions);
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x15A1370", Offset = "0x15A1370", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EB8FC8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202984E]) = v42;\nL_001C:\n\tv50 = GameAnalyticsSDK.Validators.GAValidator::ValidateArrayOfStrings(0x14, 0x40, 0, \"resource currencies\", resourceCurrencies);\n\tv54 = v50 == 0;\n\tif (v54) goto L_0076;\n\tv164 = resourceCurrencies.Length;\n\tv141 = resourceCurrencies.Length < 1;\n\tif (v141) goto L_FFFFFFFF;\nL_0034:\n\tv218 = v69 < v164;\n\tv107 = ~v218;\n\tif (v107) goto L_0077;\n\tv205 = GameAnalyticsSDK.Validators.GAValidator::StringMatch(resourceCurrencies[v69 @ X21_v6 (System.Int32)], \"^[A-Za-z]+$\");\n\tv206 = v205 == 0;\n\tif (v206) goto L_005C;\n\tv164 = resourceCurrencies.Length;\n\tv69 = v69 + 1;\n\tv195 = v69 < resourceCurrencies.Length;\n\tif (v195) goto L_0034;\n\tgoto L_0076;\nL_005C:\n\tv229 = System.String::Concat(\"resource currencies validation failed: a resource currency can only be A-Z, a-z. String was: \", resourceCurrencies[v69 @ X21_v6 (System.Int32)]);\n\tgoto L_006D;\n\tv235 = *([v119 @ X8_v16+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_006D;\n\tv241 = v119;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v241, v227, v60, v48, v49, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006D:\n\tUnityEngine.Debug::Log(v229);\nL_0076:\n\treturn returnVal1;\nL_0077:\n\tv221 = new System.IndexOutOfRangeException();\n\tthrow v221;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateResourceCurrencies(params string[] resourceCurrencies)
		{
			//IL_011a: Expected I8, but got I4
			//IL_011a: Expected I8, but got I4
			bool flag = ValidateArrayOfStrings(20L, 64L, allowNoValues: false, "resource currencies", resourceCurrencies);
			bool flag2 = !flag;
			bool result = false;
			if (!flag2)
			{
				int num = resourceCurrencies.Length;
				if (resourceCurrencies.Length < 1)
				{
					goto IL_00aa;
				}
				int num2 = 0;
				while (true)
				{
					if (num2 < num)
					{
						if (!StringMatch(resourceCurrencies[num2], "^[A-Za-z]+$"))
						{
							break;
						}
						num = resourceCurrencies.Length;
						num2++;
						if (num2 < resourceCurrencies.Length)
						{
							continue;
						}
						goto IL_00aa;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				string message = "resource currencies validation failed: a resource currency can only be A-Z, a-z. String was: " + resourceCurrencies[num2];
				Debug.Log(message);
				result = false;
			}
			goto IL_0144;
			IL_0144:
			return result;
			IL_00aa:
			result = true;
			goto IL_0144;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x15A15AC", Offset = "0x15A15AC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EBD6A0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202984F]) = v40;\nL_001B:\n\tv48 = GameAnalyticsSDK.Validators.GAValidator::ValidateArrayOfStrings(0x14, 0x20, 0, \"resource item types\", resourceItemTypes);\n\tv52 = v48 == 0;\n\tif (v52) goto L_0071;\n\tv156 = resourceItemTypes.Length;\n\tv134 = resourceItemTypes.Length < 1;\n\tif (v134) goto L_FFFFFFFF;\nL_0031:\n\tv206 = v66 < v156;\n\tv101 = ~v206;\n\tif (v101) goto L_0072;\n\tv194 = GameAnalyticsSDK.Validators.GAValidator::ValidateEventPartCharacters(resourceItemTypes[v66 @ X21_v6 (System.Int32)]);\n\tv195 = v194 == 0;\n\tif (v195) goto L_0058;\n\tv156 = resourceItemTypes.Length;\n\tv66 = v66 + 1;\n\tv184 = v66 < resourceItemTypes.Length;\n\tif (v184) goto L_0031;\n\tgoto L_0071;\nL_0058:\n\tv217 = System.String::Concat(\"resource item types validation failed: a resource item type cannot contain other characters than A-z, 0-9, -_., ()!?. String was: \", resourceItemTypes[v66 @ X21_v6 (System.Int32)]);\n\tgoto L_0069;\n\tv223 = *([v113 @ X8_v16+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_0069;\n\tv229 = v113;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v229, v215, v58, v46, v47, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0069:\n\tUnityEngine.Debug::Log(v217);\nL_0071:\n\treturn returnVal1;\nL_0072:\n\tv209 = new System.IndexOutOfRangeException();\n\tthrow v209;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateResourceItemTypes(params string[] resourceItemTypes)
		{
			//IL_0115: Expected I8, but got I4
			//IL_0115: Expected I8, but got I4
			bool flag = ValidateArrayOfStrings(20L, 32L, allowNoValues: false, "resource item types", resourceItemTypes);
			bool flag2 = !flag;
			bool result = false;
			if (!flag2)
			{
				int num = resourceItemTypes.Length;
				if (resourceItemTypes.Length < 1)
				{
					goto IL_00a5;
				}
				int num2 = 0;
				while (true)
				{
					if (num2 < num)
					{
						if (!ValidateEventPartCharacters(resourceItemTypes[num2]))
						{
							break;
						}
						num = resourceItemTypes.Length;
						num2++;
						if (num2 < resourceItemTypes.Length)
						{
							continue;
						}
						goto IL_00a5;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				string message = "resource item types validation failed: a resource item type cannot contain other characters than A-z, 0-9, -_., ()!?. String was: " + resourceItemTypes[num2];
				Debug.Log(message);
				result = false;
			}
			goto IL_013f;
			IL_013f:
			return result;
			IL_00a5:
			result = true;
			goto IL_013f;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x15A94D8", Offset = "0x15A94D8", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F03700]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029850]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(dimension01);\n\tv43 = v41 == 0;\n\tif (v43) goto L_002A;\n\tgoto L_FFFFFFFF;\n\tv52 = *([v46 @ X0_v16+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_FFFFFFFF;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v46, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0046;\nL_002A:\n\tv51 = GameAnalyticsSDK.State.GAState::HasAvailableCustomDimensions01(dimension01);\n\tv63 = v51 == 0;\n\tif (v63) goto L_0035;\n\tgoto L_004D;\nL_0035:\n\tv71 = System.String::Concat(\"Validation failed - custom dimension 01 - value was not found in list of custom dimensions 01 in the Settings object. \\nGiven dimension value: \", dimension01);\n\tgoto L_0046;\n\tv102 = *([v78 @ X8_v9+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\t// 65 ConditionalJump @b17, v104 @ TEMP_v14\n\tv107 = v78;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v107, v70, v68, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0046:\n\tUnityEngine.Debug::Log(v71);\nL_004D:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateDimension01(string dimension01)
		{
			string message;
			if (string.IsNullOrEmpty(dimension01))
			{
				message = "Validation failed - custom dimension01 - value cannot be empty.";
			}
			else
			{
				if (GAState.HasAvailableCustomDimensions01(dimension01))
				{
					return true;
				}
				message = "Validation failed - custom dimension 01 - value was not found in list of custom dimensions 01 in the Settings object. \nGiven dimension value: " + dimension01;
			}
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x15A95BC", Offset = "0x15A95BC", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE9208]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029851]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(dimension02);\n\tv43 = v41 == 0;\n\tif (v43) goto L_002A;\n\tgoto L_FFFFFFFF;\n\tv52 = *([v46 @ X0_v16+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_FFFFFFFF;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v46, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0046;\nL_002A:\n\tv51 = GameAnalyticsSDK.State.GAState::HasAvailableCustomDimensions02(dimension02);\n\tv63 = v51 == 0;\n\tif (v63) goto L_0035;\n\tgoto L_004D;\nL_0035:\n\tv71 = System.String::Concat(\"Validation failed - custom dimension 02 - value was not found in list of custom dimensions 02 in the Settings object. \\nGiven dimension value: \", dimension02);\n\tgoto L_0046;\n\tv102 = *([v78 @ X8_v9+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\t// 65 ConditionalJump @b17, v104 @ TEMP_v14\n\tv107 = v78;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v107, v70, v68, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0046:\n\tUnityEngine.Debug::Log(v71);\nL_004D:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateDimension02(string dimension02)
		{
			string message;
			if (string.IsNullOrEmpty(dimension02))
			{
				message = "Validation failed - custom dimension01 - value cannot be empty.";
			}
			else
			{
				if (GAState.HasAvailableCustomDimensions02(dimension02))
				{
					return true;
				}
				message = "Validation failed - custom dimension 02 - value was not found in list of custom dimensions 02 in the Settings object. \nGiven dimension value: " + dimension02;
			}
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x15A96A0", Offset = "0x15A96A0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF4600]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029852]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(dimension03);\n\tv43 = v41 == 0;\n\tif (v43) goto L_002A;\n\tgoto L_FFFFFFFF;\n\tv52 = *([v46 @ X0_v16+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_FFFFFFFF;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v46, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0046;\nL_002A:\n\tv51 = GameAnalyticsSDK.State.GAState::HasAvailableCustomDimensions03(dimension03);\n\tv63 = v51 == 0;\n\tif (v63) goto L_0035;\n\tgoto L_004D;\nL_0035:\n\tv71 = System.String::Concat(\"Validation failed - custom dimension 03 - value was not found in list of custom dimensions 03 in the Settings object. \\nGiven dimension value: \", dimension03);\n\tgoto L_0046;\n\tv102 = *([v78 @ X8_v9+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\t// 65 ConditionalJump @b17, v104 @ TEMP_v14\n\tv107 = v78;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v107, v70, v68, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0046:\n\tUnityEngine.Debug::Log(v71);\nL_004D:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateDimension03(string dimension03)
		{
			string message;
			if (string.IsNullOrEmpty(dimension03))
			{
				message = "Validation failed - custom dimension01 - value cannot be empty.";
			}
			else
			{
				if (GAState.HasAvailableCustomDimensions03(dimension03))
				{
					return true;
				}
				message = "Validation failed - custom dimension 03 - value was not found in list of custom dimensions 03 in the Settings object. \nGiven dimension value: " + dimension03;
			}
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x15A90C8", Offset = "0x15A90C8", Length = "0x410")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1EEA6E8]);\n\tv35 = *([v34 @ X8_v73]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, maxStringLength, allowNoValues, logTag, arrayOfStrings, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029853]) = v50;\nL_001D:\n\tv53 = System.String::IsNullOrEmpty(logTag);\n\tv58 = v53 == 0;\n\tv62 = ~v58;\n\tv63 = ~v62;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_002D:\n\tv67 = arrayOfStrings == 0;\n\tif (v67) goto L_FFFFFFFF;\n\tv69 = allowNoValues == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0041;\n\tv127 = arrayOfStrings.Length;\n\tv74 = arrayOfStrings.Length == 0;\n\tif (v74) goto L_FFFFFFFF;\nL_0041:\n\tv88 = maxCount < 1;\n\tif (v88) goto L_00FA;\n\tv147 = arrayOfStrings.Length <= maxCount;\n\tif (v147) goto L_00FA;\n\t// 85 NewArr v740 @ X0_v13 (System.Object[]), typeof(System.Object[]), 6\n\tv316 = v66 == 0;\n\tif (v316) goto L_0061;\n\t// 94 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), v66 @ X22_v2 (System.String)\nL_0061:\n\tv127 = v740.Length;\n\tv508 = v740.Length == 0;\n\tif (v508) goto L_01D6;\n\tv740[0] = v66;\n\tv583 = \" validation failed: array cannot exceed \" == 0;\n\tif (v583) goto L_0070;\n\t// 108 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), \" validation failed: array cannot exceed \"\n\tv127 = v740.Length;\nL_0070:\n\tv659 = v127 < 1;\n\tv470 = ~v659;\n\tv440 = v127 - 1;\n\tv480 = v440 == 0;\n\tv660 = ~v470;\n\tv450 = v660 | v480;\n\tif (v450) goto L_01D6;\n\tv740[1] = \" validation failed: array cannot exceed \";\n\t// 131 Box v53 @ X0_v3 (System.Boolean), typeof(System.Int64), &maxCount @ X0 (System.Int64)\n\tv682 = v53 == 0;\n\tif (v682) goto L_008D;\n\t// 138 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), v53 @ X0_v3 (System.Boolean)\nL_008D:\n\tv127 = v740.Length;\n\tv685 = v740.Length < 2;\n\tv466 = ~v685;\n\tv436 = v740.Length - 2;\n\tv476 = v436 == 0;\n\tv686 = ~v466;\n\tv446 = v686 | v476;\n\tif (v446) goto L_01D6;\n\tv740[2] = v53;\n\tv690 = \" values. It has \" == 0;\n\tif (v690) goto L_00A6;\n\t// 162 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), \" values. It has \"\n\tv127 = v740.Length;\nL_00A6:\n\tv695 = v127 < 3;\n\tv471 = ~v695;\n\tv441 = v127 - 3;\n\tv481 = v441 == 0;\n\tv696 = ~v471;\n\tv451 = v696 | v481;\n\tif (v451) goto L_01D6;\n\tv740[3] = \" values. It has \";\n\tv127 = arrayOfStrings.Length;\n\t// 186 Box v53 @ X0_v3 (System.Boolean), typeof(System.Int32), &v127 @ X8_v7 (System.String)\n\tv709 = v53 == 0;\n\tif (v709) goto L_00C4;\n\t// 193 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), v53 @ X0_v3 (System.Boolean)\nL_00C4:\n\tv127 = v740.Length;\n\tv718 = v740.Length < 4;\n\tv467 = ~v718;\n\tv437 = v740.Length - 4;\n\tv477 = v437 == 0;\n\tv719 = ~v467;\n\tv447 = v719 | v477;\n\tif (v447) goto L_01D6;\n\tv740[4] = v53;\n\tv723 = \" values.\" == 0;\n\tif (v723) goto L_00DD;\n\t// 217 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), \" values.\"\n\tv127 = v740.Length;\nL_00DD:\n\tv729 = v127 < 5;\n\tv472 = ~v729;\n\tv442 = v127 - 5;\n\tv482 = v442 == 0;\n\tv730 = ~v472;\n\tv452 = v730 | v482;\n\tif (v452) goto L_01D6;\n\tv740[5] = \" values.\";\n\tgoto L_01B9;\n\tgoto L_013E;\nL_00FA:\n\tv168 = arrayOfStrings.Length < 1;\n\tif (v168) goto L_FFFFFFFF;\nL_00FE:\n\tv273 = v99 < arrayOfStrings.Length;\n\tv118 = ~v273;\n\tif (v118) goto L_01D6;\n\tv126 = arrayOfStrings[v99 @ X9_v15 (System.Int64)];\n\tv381 = arrayOfStrings[v99 @ X9_v15 (System.Int64)] == 0;\n\tif (v381) goto L_FFFFFFFF;\n\tv201 = v126.m_stringLength == 0;\n\tif (v201) goto L_FFFFFFFF;\n\tv594 = maxStringLength < 1;\n\tif (v594) goto L_0127;\n\tv349 = v126.m_stringLength > maxStringLength;\n\tif (v349) goto L_0144;\nL_0127:\n\tv99 = v99 + 1;\n\tv191 = v99 < arrayOfStrings.Length;\n\tif (v191) goto L_00FE;\n\tgoto L_01D5;\n\tgoto L_013E;\nL_013E:\n\tv239 = System.String::Concat(v66, *([v127 @ X8_v7 (System.String)]));\n\tgoto L_01C1;\nL_0144:\n\t// 324 NewArr v740 @ X0_v13 (System.Object[]), typeof(System.Object[]), 5\n\tv687 = v66 == 0;\n\tif (v687) goto L_0150;\n\t// 333 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), v66 @ X22_v2 (System.String)\nL_0150:\n\tv127 = v740.Length;\n\tv511 = v740.Length == 0;\n\tif (v511) goto L_01D6;\n\tv740[0] = v66;\n\tv699 = \" validation failed: a string exceeded max allowed length (which is: \" == 0;\n\tif (v699) goto L_015F;\n\t// 347 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), \" validation failed: a string exceeded max allowed length (which is: \"\n\tv127 = v740.Length;\nL_015F:\n\tv707 = v127 < 1;\n\tv473 = ~v707;\n\tv443 = v127 - 1;\n\tv483 = v443 == 0;\n\tv708 = ~v473;\n\tv453 = v708 | v483;\n\tif (v453) goto L_01D6;\n\tv740[1] = \" validation failed: a string exceeded max allowed length (which is: \";\n\t// 370 Box v53 @ X0_v3 (System.Boolean), typeof(System.Int64), &maxStringLength @ X1 (System.Int64)\n\tv720 = v53 == 0;\n\tif (v720) goto L_017C;\n\t// 377 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), v53 @ X0_v3 (System.Boolean)\nL_017C:\n\tv127 = v740.Length;\n\tv726 = v740.Length < 2;\n\tv468 = ~v726;\n\tv438 = v740.Length - 2;\n\tv478 = v438 == 0;\n\tv727 = ~v468;\n\tv448 = v727 | v478;\n\tif (v448) goto L_01D6;\n\tv740[2] = v53;\n\tv733 = \"). String was: \" == 0;\n\tif (v733) goto L_0195;\n\t// 401 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), \"). String was: \"\n\tv127 = v740.Length;\nL_0195:\n\tv737 = v127 < 3;\n\tv474 = ~v737;\n\tv444 = v127 - 3;\n\tv484 = v444 == 0;\n\tv738 = ~v474;\n\tv454 = v738 | v484;\n\tif (v454) goto L_01D6;\n\tv740[3] = \"). String was: \";\n\t// 422 IsInst v53 @ X0_v3 (System.Boolean), typeof(System.Object), arrayOfStrings[v99 @ X9_v15 (System.Int64)]\n\tv743 = v740.Length < 4;\n\tv469 = ~v743;\n\tv439 = v740.Length - 4;\n\tv479 = v439 == 0;\n\tv744 = ~v469;\n\tv449 = v744 | v479;\n\tif (v449) goto L_01D6;\n\tv740[4] = arrayOfStrings[v99 @ X9_v15 (System.Int64)];\nL_01B9:\n\tv239 = System.String::Concat(v740);\nL_01C1:\n\tgoto L_01CA;\n\tv310 = *([v256 @ X8_v11+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_01CA;\n\tv572 = v256;\n\tv314 = \"il2cpp_codegen_runtime_class_init\"(v572, v217, v204, logTag, arrayOfStrings, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_01CA:\n\tUnityEngine.Debug::Log(v239);\nL_01D5:\n\treturn v53;\nL_01D6:\n\tv543 = new System.IndexOutOfRangeException();\n\tgoto L_01DB;\n\tv613 = new System.ArrayTypeMismatchException();\nL_01DB:\n\tthrow v612;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 290 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateArrayOfStrings(long maxCount, long maxStringLength, bool allowNoValues, string logTag, params string[] arrayOfStrings)
		{
			//IL_0052: Expected O, but got I4
			//IL_03dc: Expected I8, but got I4
			//IL_00fb: Expected O, but got I4
			//IL_00ec: Expected I4, but got O
			//IL_07fb: Expected O, but got I
			//IL_0158: Expected I4, but got O
			//IL_018c: Expected I4, but got O
			//IL_0167: Expected O, but got I4
			//IL_01c5: Expected O, but got I4
			//IL_01f1: Expected O, but got I4
			//IL_01b2: Expected O, but got I4
			//IL_01b6: Expected I4, but got O
			//IL_0238: Expected O, but got I4
			//IL_051a: Expected O, but got I4
			//IL_0859: Expected O, but got I
			//IL_050b: Expected I4, but got O
			//IL_0264: Expected I4, but got O
			//IL_0295: Expected O, but got I4
			//IL_029e: Expected I4, but got O
			//IL_02a2: Expected I4, but got O
			//IL_0273: Expected O, but got I4
			//IL_096b: Expected O, but got I
			//IL_02db: Expected O, but got I4
			//IL_0307: Expected O, but got I4
			//IL_0577: Expected I4, but got O
			//IL_02c8: Expected O, but got I4
			//IL_02cc: Expected I4, but got O
			//IL_05ab: Expected I4, but got O
			//IL_0586: Expected O, but got I4
			//IL_034e: Expected O, but got I4
			//IL_05e4: Expected O, but got I4
			//IL_0610: Expected O, but got I4
			//IL_08b7: Expected O, but got I
			//IL_05d1: Expected O, but got I4
			//IL_05d5: Expected I4, but got O
			//IL_037a: Expected I4, but got O
			//IL_0657: Expected O, but got I4
			//IL_0389: Expected O, but got I4
			//IL_09c9: Expected O, but got I
			//IL_0683: Expected I4, but got O
			//IL_06c0: Expected I4, but got O
			//IL_0692: Expected O, but got I4
			//IL_06f1: Expected O, but got I4
			string text = ((!string.IsNullOrEmpty(logTag)) ? logTag : "Array");
			object[] array;
			long num;
			string text2;
			if (arrayOfStrings != null)
			{
				if (!allowNoValues)
				{
					text2 = (string)arrayOfStrings.Length;
					if (arrayOfStrings.Length == 0)
					{
						text2 = " validation failed: array cannot be empty. ";
						goto IL_08fe;
					}
				}
				if (maxCount >= 1 && arrayOfStrings.Length > maxCount)
				{
					array = new object[6];
					if (text != null)
					{
						bool flag = (byte)(int)(text as object) != 0;
					}
					text2 = (string)array.Length;
					if (array.Length != 0)
					{
						array[0] = text;
						if (" validation failed: array cannot exceed " != null)
						{
							bool flag = (byte)(int)(" validation failed: array cannot exceed " as object) != 0;
							text2 = (string)array.Length;
						}
						bool flag2 = (long)(IntPtr)text2 < 1L;
						bool flag3 = !flag2;
						object obj = (long)(IntPtr)text2 - 1L;
						bool flag4 = obj == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array[1] = " validation failed: array cannot exceed ";
							bool flag = (byte)(int)(object)maxCount != 0;
							if (flag)
							{
								flag = (byte)(int)(flag as object) != 0;
							}
							text2 = (string)array.Length;
							bool flag6 = array.Length < 2;
							bool flag7 = !flag6;
							object obj2 = array.Length - 2;
							bool flag8 = obj2 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								array[2] = flag;
								if (" values. It has " != null)
								{
									flag = (byte)(int)(" values. It has " as object) != 0;
									text2 = (string)array.Length;
								}
								bool flag10 = (long)(IntPtr)text2 < 3L;
								bool flag11 = !flag10;
								object obj3 = (long)(IntPtr)text2 - 3L;
								bool flag12 = obj3 == null;
								bool flag13 = !flag11;
								if (!(flag13 || flag12))
								{
									array[3] = " values. It has ";
									text2 = (string)arrayOfStrings.Length;
									flag = (byte)(int)(object)(int)text2 != 0;
									if (flag)
									{
										flag = (byte)(int)(flag as object) != 0;
									}
									text2 = (string)array.Length;
									bool flag14 = array.Length < 4;
									bool flag15 = !flag14;
									object obj4 = array.Length - 4;
									bool flag16 = obj4 == null;
									bool flag17 = !flag15;
									if (!(flag17 || flag16))
									{
										array[4] = flag;
										if (" values." != null)
										{
											flag = (byte)(int)(" values." as object) != 0;
											text2 = (string)array.Length;
										}
										bool flag18 = (long)(IntPtr)text2 < 5L;
										bool flag19 = !flag18;
										object obj5 = (long)(IntPtr)text2 - 5L;
										bool flag20 = obj5 == null;
										bool flag21 = !flag19;
										if (!(flag21 || flag20))
										{
											array[5] = " values.";
											goto IL_08ec;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					if (arrayOfStrings.Length < 1)
					{
						goto IL_04a4;
					}
					num = 0L;
					while (num < arrayOfStrings.Length)
					{
						string text3 = arrayOfStrings[num];
						if (arrayOfStrings[num] == null || text3.Length == 0)
						{
							goto IL_04c0;
						}
						if (maxStringLength < 1 || text3.Length <= maxStringLength)
						{
							num++;
							if (num < arrayOfStrings.Length)
							{
								continue;
							}
							goto IL_04a4;
						}
						goto IL_04ce;
					}
				}
				goto IL_0762;
			}
			text2 = " validation failed: array cannot be null. ";
			goto IL_08fe;
			IL_08fe:
			string message = text + text2;
			goto IL_074b;
			IL_0762:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_074b:
			Debug.Log(message);
			return false;
			IL_04a4:
			return true;
			IL_04ce:
			array = new object[5];
			if (text != null)
			{
				bool flag = (byte)(int)(text as object) != 0;
			}
			text2 = (string)array.Length;
			if (array.Length != 0)
			{
				array[0] = text;
				if (" validation failed: a string exceeded max allowed length (which is: " != null)
				{
					bool flag = (byte)(int)(" validation failed: a string exceeded max allowed length (which is: " as object) != 0;
					text2 = (string)array.Length;
				}
				bool flag22 = (long)(IntPtr)text2 < 1L;
				bool flag23 = !flag22;
				object obj6 = (long)(IntPtr)text2 - 1L;
				bool flag24 = obj6 == null;
				bool flag25 = !flag23;
				if (!(flag25 || flag24))
				{
					array[1] = " validation failed: a string exceeded max allowed length (which is: ";
					bool flag = (byte)(int)(object)maxStringLength != 0;
					if (flag)
					{
						flag = (byte)(int)(flag as object) != 0;
					}
					text2 = (string)array.Length;
					bool flag26 = array.Length < 2;
					bool flag27 = !flag26;
					object obj7 = array.Length - 2;
					bool flag28 = obj7 == null;
					bool flag29 = !flag27;
					if (!(flag29 || flag28))
					{
						array[2] = flag;
						if ("). String was: " != null)
						{
							flag = (byte)(int)("). String was: " as object) != 0;
							text2 = (string)array.Length;
						}
						bool flag30 = (long)(IntPtr)text2 < 3L;
						bool flag31 = !flag30;
						object obj8 = (long)(IntPtr)text2 - 3L;
						bool flag32 = obj8 == null;
						bool flag33 = !flag31;
						if (!(flag33 || flag32))
						{
							array[3] = "). String was: ";
							flag = (byte)(int)(arrayOfStrings[num] as object) != 0;
							bool flag34 = array.Length < 4;
							bool flag35 = !flag34;
							object obj9 = array.Length - 4;
							bool flag36 = obj9 == null;
							bool flag37 = !flag35;
							if (!(flag37 || flag36))
							{
								array[4] = arrayOfStrings[num];
								goto IL_08ec;
							}
						}
					}
				}
			}
			goto IL_0762;
			IL_08ec:
			message = string.Concat(array);
			goto IL_074b;
			IL_04c0:
			text2 = " validation failed: contained an empty string.";
			goto IL_08fe;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x15A9784", Offset = "0x15A9784", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ED8780]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029854]) = v38;\nL_0015:\n\tv41 = GameAnalyticsSDK.Validators.GAValidator::ValidateString(facebookId, 0);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0021;\n\tgoto L_0032;\nL_0021:\n\tgoto L_002B;\n\tv63 = *([v47 @ X0_v5+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v47, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Debug::Log(\"Validation fail - facebook id: id cannot be (null), empty or above 64 characters.\");\nL_0032:\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateFacebookId(string facebookId)
		{
			if (ValidateString(facebookId, canBeEmpty: false))
			{
				return true;
			}
			Debug.Log("Validation fail - facebook id: id cannot be (null), empty or above 64 characters.");
			return false;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x15A9814", Offset = "0x15A9814", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB9CF8]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029855]) = v42;\nL_001B:\n\tv49 = System.String::op_Equality(gender, \"\");\n\tv51 = v49 == 0;\n\tif (v51) goto L_003A;\nL_0024:\n\tv78 = System.String::Concat(\"Validation fail - gender: Has to be 'male' or 'female'.Given gender:\", gender);\n\tgoto L_0035;\n\tv94 = *([v88 @ X8_v19+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0035;\n\tv127 = v88;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v127, v75, v76, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tUnityEngine.Debug::Log(v78);\n\tgoto L_0075;\nL_003A:\n\tv80 = 1;\n\t// 62 Box v84 @ X0_v6, typeof(GameAnalyticsSDK.GAGender), &v80 @ X8_v6 (System.Int32)\n\tv80 = *([v84 @ X0_v6]);\n\t*([v80 @ X8_v6 (System.Int32)+160])(v107, v84, *([v80 @ X8_v6 (System.Int32)+168]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv110 = \"il2cpp_vm_object_unbox\"(v84, *([v80 @ X8_v6 (System.Int32)+168]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv133 = System.String::op_Equality(gender, v107);\n\tv161 = v133 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_FFFFFFFF;\n\tv80 = 2;\n\t// 88 Box v120 @ X0_v18, typeof(GameAnalyticsSDK.GAGender), &v80 @ X8_v6 (System.Int32)\n\tv80 = *([v120 @ X0_v18]);\n\t*([v80 @ X8_v6 (System.Int32)+160])(v181, v120, *([v80 @ X8_v6 (System.Int32)+168]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv183 = \"il2cpp_vm_object_unbox\"(v120, *([v80 @ X8_v6 (System.Int32)+168]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = System.String::op_Equality(gender, v181);\n\tv68 = v66 == 0;\n\tif (v68) goto L_0024;\nL_0075:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateGender(string gender)
		{
			//IL_0056: Expected I4, but got O
			//IL_00cb: Expected I4, but got O
			if (!(gender == ""))
			{
				int num = 1;
				object obj = (GAGender)num;
				num = (int)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ X8_v6 (System.Int32)+160] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string text = default(string);
				if (!(gender == text))
				{
					num = 2;
					object obj2 = (GAGender)num;
					num = (int)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v80 @ X8_v6 (System.Int32)+160] (should have been resolved before IL gen)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					string text2 = default(string);
					if (!(gender == text2))
					{
						goto IL_0005;
					}
				}
				return true;
			}
			goto IL_0005;
			IL_0005:
			string message = "Validation fail - gender: Has to be 'male' or 'female'.Given gender:" + gender;
			Debug.Log(message);
			return false;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x15A9990", Offset = "0x15A9990", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFBBB0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029856]) = v38;\nL_0013:\n\tv39 = birthYear >> 4;\n\tv40 = v39 < 0x271;\n\tv41 = ~v40;\n\tv49 = ~v41;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_002F;\n\tv57 = *([v52 @ X0_v4+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002F;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tUnityEngine.Debug::Log(\"Validation fail - birthYear: Cannot be (null) or invalid range.\");\n\tgoto L_0038;\nL_0038:\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateBirthyear(int birthYear)
		{
			int num = birthYear >> 4;
			if (num >= 625)
			{
				Debug.Log("Validation fail - birthYear: Cannot be (null) or invalid range.");
				return false;
			}
			return true;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x15A9A1C", Offset = "0x15A9A1C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = clientTs != 0x8000000000000000;\n\tif (v11) goto L_0011;\n\treturn 0;\nL_0011:\n\tv16 = clientTs - 0x7FFFFFFFFFFFFFFF;\n\tv18 = v16 == 0;\n\tv23 = ~v18;\n\treturn v23;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ValidateClientTs(long clientTs)
		{
			if (clientTs == long.MinValue)
			{
				return false;
			}
			long num = clientTs - long.MaxValue;
			bool flag = num == 0;
			return !flag;
		}
	}
}
