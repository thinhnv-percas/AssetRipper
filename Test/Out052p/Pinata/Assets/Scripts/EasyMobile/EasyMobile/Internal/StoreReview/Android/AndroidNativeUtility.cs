using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal.StoreReview.Android
{
	[Token(Token = "0x20000D2")]
	internal static class AndroidNativeUtility
	{
		[Token(Token = "0x40003C0")]
		private static readonly string ANDROID_JAVA_UTILITY_CLASS = "com.sglib.easymobile.androidnative.EMUtility";

		[Token(Token = "0x600079A")]
		[Address(RVA = "0xB52A44", Offset = "0xB52A44", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EADC28]);\n\tv27 = *([v26 @ X8_v46]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, settings, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20227A1]) = v45;\nL_001E:\n\tgoto L_002B;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<EasyMobile.Internal.StoreReview.Android.AndroidNativeUtility>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v49, settings, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = EasyMobile.Internal.StoreReview.Android.AndroidNativeUtility;\nL_002B:\n\t// 43 NewArr v66 @ X0_v5 (System.Object[]), typeof(System.Object[]), 10\n\tv134 = content.mTitle == 0;\n\tif (v134) goto L_003A;\n\t// 55 IsInst v138 @ X0_v47, typeof(System.Object), content.mTitle (System.String)\nL_003A:\n\tv61 = v66.Length;\n\tv145 = v66.Length == 0;\n\tif (v145) goto L_0124;\n\tv66[0] = content.mTitle;\n\tv193 = content.mMessage == 0;\n\tif (v193) goto L_0048;\n\t// 68 IsInst v335 @ X0_v45, typeof(System.Object), content.mMessage (System.String)\n\tv61 = v66.Length;\nL_0048:\n\tv369 = v61 < 1;\n\tv259 = ~v369;\n\tv251 = v61 - 1;\n\tv235 = v251 == 0;\n\tv370 = ~v259;\n\tv195 = v370 | v235;\n\tif (v195) goto L_0124;\n\tv66[1] = content.mMessage;\n\tv373 = content.mLowRatingMessage == 0;\n\tif (v373) goto L_005F;\n\t// 91 IsInst v336 @ X0_v43, typeof(System.Object), content.mLowRatingMessage (System.String)\n\tv61 = v66.Length;\nL_005F:\n\tv376 = v61 < 2;\n\tv260 = ~v376;\n\tv252 = v61 - 2;\n\tv236 = v252 == 0;\n\tv377 = ~v260;\n\tv196 = v377 | v236;\n\tif (v196) goto L_0124;\n\tv66[2] = content.mLowRatingMessage;\n\tv378 = content.mHighRatingMessage == 0;\n\tif (v378) goto L_0076;\n\t// 114 IsInst v337 @ X0_v41, typeof(System.Object), content.mHighRatingMessage (System.String)\n\tv61 = v66.Length;\nL_0076:\n\tv381 = v61 < 3;\n\tv261 = ~v381;\n\tv253 = v61 - 3;\n\tv237 = v253 == 0;\n\tv382 = ~v261;\n\tv197 = v382 | v237;\n\tif (v197) goto L_0124;\n\tv66[3] = content.mHighRatingMessage;\n\tv383 = content.mPostponeButtonText == 0;\n\tif (v383) goto L_008D;\n\t// 137 IsInst v338 @ X0_v39, typeof(System.Object), content.mPostponeButtonText (System.String)\n\tv61 = v66.Length;\nL_008D:\n\tv386 = v61 < 4;\n\tv262 = ~v386;\n\tv254 = v61 - 4;\n\tv238 = v254 == 0;\n\tv387 = ~v262;\n\tv198 = v387 | v238;\n\tif (v198) goto L_0124;\n\tv66[4] = content.mPostponeButtonText;\n\tv388 = content.mRefuseButtonText == 0;\n\tif (v388) goto L_00A4;\n\t// 160 IsInst v339 @ X0_v37, typeof(System.Object), content.mRefuseButtonText (System.String)\n\tv61 = v66.Length;\nL_00A4:\n\tv391 = v61 < 5;\n\tv263 = ~v391;\n\tv255 = v61 - 5;\n\tv239 = v255 == 0;\n\tv392 = ~v263;\n\tv199 = v392 | v239;\n\tif (v199) goto L_0124;\n\tv66[5] = content.mRefuseButtonText;\n\tv393 = content.mCancelButtonText == 0;\n\tif (v393) goto L_00BB;\n\t// 183 IsInst v340 @ X0_v35, typeof(System.Object), content.mCancelButtonText (System.String)\n\tv61 = v66.Length;\nL_00BB:\n\tv396 = v61 < 6;\n\tv264 = ~v396;\n\tv256 = v61 - 6;\n\tv240 = v256 == 0;\n\tv397 = ~v264;\n\tv200 = v397 | v240;\n\tif (v200) goto L_0124;\n\tv66[6] = content.mCancelButtonText;\n\tv398 = content.mFeedbackButtonText == 0;\n\tif (v398) goto L_00D2;\n\t// 206 IsInst v341 @ X0_v33, typeof(System.Object), content.mFeedbackButtonText (System.String)\n\tv61 = v66.Length;\nL_00D2:\n\tv401 = v61 < 7;\n\tv265 = ~v401;\n\tv257 = v61 - 7;\n\tv241 = v257 == 0;\n\tv402 = ~v265;\n\tv201 = v402 | v241;\n\tif (v201) goto L_0124;\n\tv66[7] = content.mFeedbackButtonText;\n\tv403 = content.mRateButtonText == 0;\n\tif (v403) goto L_00E9;\n\t// 229 IsInst v342 @ X0_v31, typeof(System.Object), content.mRateButtonText (System.String)\n\tv61 = v66.Length;\nL_00E9:\n\tv406 = v61 < 8;\n\tv108 = ~v406;\n\tv104 = v61 - 8;\n\tv96 = v104 == 0;\n\tv407 = ~v108;\n\tv76 = v407 | v96;\n\tif (v76) goto L_0124;\n\tv66[8] = content.mRateButtonText;\n\tv408 = settings.mMinimumAcceptedStars;\n\tv411 = 0x13CBF58(&v408 @ X8_v20 (System.UInt32), 0, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv412 = v411 == 0;\n\tif (v412) goto L_0106;\n\t// 259 IsInst v343 @ X0_v29, typeof(System.Object), v411 @ X0_v25\nL_0106:\n\tv61 = v66.Length;\n\tv415 = v66.Length < 9;\n\tv169 = ~v415;\n\tv167 = v66.Length - 9;\n\tv163 = v167 == 0;\n\tv416 = ~v169;\n\tv153 = v416 | v163;\n\tif (v153) goto L_0124;\n\tv66[9] = v411;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(v61.ANDROID_JAVA_UTILITY_CLASS, \"RequestReview\", v66);\n\treturn;\nL_0124:\n\tv312 = new System.IndexOutOfRangeException();\n\tgoto L_0129;\n\tv366 = new System.ArrayTypeMismatchException();\nL_0129:\n\tthrow v372;\n\tthrow System.NullReferenceException;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void RequestRating(RatingDialogContent content, RatingRequestSettings settings)
		{
			//IL_04a6: Expected O, but got I
			//IL_0504: Expected O, but got I
			//IL_0562: Expected O, but got I
			//IL_05c0: Expected O, but got I
			//IL_061e: Expected O, but got I
			//IL_067c: Expected O, but got I
			//IL_06da: Expected O, but got I
			//IL_0738: Expected O, but got I
			//IL_03f7: Expected O, but got I4
			object[] array = new object[10];
			if (content.Title != null)
			{
				object obj = content.Title as object;
			}
			IntPtr intPtr = (IntPtr)array.Length;
			if (array.Length != 0)
			{
				array[0] = content.Title;
				if (content.Message != null)
				{
					object obj2 = content.Message as object;
					intPtr = (IntPtr)array.Length;
				}
				bool flag = (long)intPtr < 1L;
				bool flag2 = !flag;
				object obj3 = (long)intPtr - 1L;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = content.Message;
					if (content.LowRatingMessage != null)
					{
						object obj4 = content.LowRatingMessage as object;
						intPtr = (IntPtr)array.Length;
					}
					bool flag5 = (long)intPtr < 2L;
					bool flag6 = !flag5;
					object obj5 = (long)intPtr - 2L;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = content.LowRatingMessage;
						if (content.HighRatingMessage != null)
						{
							object obj6 = content.HighRatingMessage as object;
							intPtr = (IntPtr)array.Length;
						}
						bool flag9 = (long)intPtr < 3L;
						bool flag10 = !flag9;
						object obj7 = (long)intPtr - 3L;
						bool flag11 = obj7 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = content.HighRatingMessage;
							if (content.PostponeButtonText != null)
							{
								object obj8 = content.PostponeButtonText as object;
								intPtr = (IntPtr)array.Length;
							}
							bool flag13 = (long)intPtr < 4L;
							bool flag14 = !flag13;
							object obj9 = (long)intPtr - 4L;
							bool flag15 = obj9 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = content.PostponeButtonText;
								if (content.RefuseButtonText != null)
								{
									object obj10 = content.RefuseButtonText as object;
									intPtr = (IntPtr)array.Length;
								}
								bool flag17 = (long)intPtr < 5L;
								bool flag18 = !flag17;
								object obj11 = (long)intPtr - 5L;
								bool flag19 = obj11 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = content.RefuseButtonText;
									if (content.CancelButtonText != null)
									{
										object obj12 = content.CancelButtonText as object;
										intPtr = (IntPtr)array.Length;
									}
									bool flag21 = (long)intPtr < 6L;
									bool flag22 = !flag21;
									object obj13 = (long)intPtr - 6L;
									bool flag23 = obj13 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = content.CancelButtonText;
										if (content.FeedbackButtonText != null)
										{
											object obj14 = content.FeedbackButtonText as object;
											intPtr = (IntPtr)array.Length;
										}
										bool flag25 = (long)intPtr < 7L;
										bool flag26 = !flag25;
										object obj15 = (long)intPtr - 7L;
										bool flag27 = obj15 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[7] = content.FeedbackButtonText;
											if (content.RateButtonText != null)
											{
												object obj16 = content.RateButtonText as object;
												intPtr = (IntPtr)array.Length;
											}
											bool flag29 = (long)intPtr < 8L;
											bool flag30 = !flag29;
											object obj17 = (long)intPtr - 8L;
											bool flag31 = obj17 == null;
											bool flag32 = !flag30;
											if (!(flag32 || flag31))
											{
												array[8] = content.RateButtonText;
												uint minimumAcceptedStars = settings.MinimumAcceptedStars;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13CBF58 (inside System.UInt16::TryParse +0x8C8)");
												object obj18 = default(object);
												if (obj18 != null)
												{
													object obj19 = obj18 as object;
												}
												intPtr = (IntPtr)array.Length;
												bool flag33 = array.Length < 9;
												bool flag34 = !flag33;
												object obj20 = array.Length - 9;
												bool flag35 = obj20 == null;
												bool flag36 = !flag34;
												if (!(flag36 || flag35))
												{
													array[9] = obj18;
													AndroidUtil.CallJavaStaticMethod(ANDROID_JAVA_UTILITY_CLASS, "RequestReview", array);
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
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
