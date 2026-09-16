using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000020")]
	internal class Utils
	{
		[Token(Token = "0x400006D")]
		public const string AdListenerClassName = "com.google.android.gms.ads.AdListener";

		[Token(Token = "0x400006E")]
		public const string AdRequestClassName = "com.google.android.gms.ads.AdRequest";

		[Token(Token = "0x400006F")]
		public const string AdRequestBuilderClassName = "com.google.android.gms.ads.AdRequest$Builder";

		[Token(Token = "0x4000070")]
		public const string AdSizeClassName = "com.google.android.gms.ads.AdSize";

		[Token(Token = "0x4000071")]
		public const string AdMobExtrasClassName = "com.google.android.gms.ads.mediation.admob.AdMobExtras";

		[Token(Token = "0x4000072")]
		public const string PlayStorePurchaseListenerClassName = "com.google.android.gms.ads.purchase.PlayStorePurchaseListener";

		[Token(Token = "0x4000073")]
		public const string MobileAdsClassName = "com.google.android.gms.ads.MobileAds";

		[Token(Token = "0x4000074")]
		public const string RequestConfigurationClassName = "com.google.android.gms.ads.RequestConfiguration";

		[Token(Token = "0x4000075")]
		public const string RequestConfigurationBuilderClassName = "com.google.android.gms.ads.RequestConfiguration$Builder";

		[Token(Token = "0x4000076")]
		public const string ServerSideVerificationOptionsClassName = "com.google.android.gms.ads.rewarded.ServerSideVerificationOptions";

		[Token(Token = "0x4000077")]
		public const string ServerSideVerificationOptionsBuilderClassName = "com.google.android.gms.ads.rewarded.ServerSideVerificationOptions$Builder";

		[Token(Token = "0x4000078")]
		public const string UnityAdSizeClassName = "com.google.unity.ads.UnityAdSize";

		[Token(Token = "0x4000079")]
		public const string BannerViewClassName = "com.google.unity.ads.Banner";

		[Token(Token = "0x400007A")]
		public const string InterstitialClassName = "com.google.unity.ads.Interstitial";

		[Token(Token = "0x400007B")]
		public const string RewardBasedVideoClassName = "com.google.unity.ads.RewardBasedVideo";

		[Token(Token = "0x400007C")]
		public const string UnityRewardedAdClassName = "com.google.unity.ads.UnityRewardedAd";

		[Token(Token = "0x400007D")]
		public const string NativeAdLoaderClassName = "com.google.unity.ads.NativeAdLoader";

		[Token(Token = "0x400007E")]
		public const string UnityAdListenerClassName = "com.google.unity.ads.UnityAdListener";

		[Token(Token = "0x400007F")]
		public const string UnityRewardBasedVideoAdListenerClassName = "com.google.unity.ads.UnityRewardBasedVideoAdListener";

		[Token(Token = "0x4000080")]
		public const string UnityRewardedAdCallbackClassName = "com.google.unity.ads.UnityRewardedAdCallback";

		[Token(Token = "0x4000081")]
		public const string UnityAdapterStatusEnumName = "com.google.android.gms.ads.initialization.AdapterStatus$State";

		[Token(Token = "0x4000082")]
		public const string OnInitializationCompleteListenerClassName = "com.google.android.gms.ads.initialization.OnInitializationCompleteListener";

		[Token(Token = "0x4000083")]
		public const string UnityAdLoaderListenerClassName = "com.google.unity.ads.UnityAdLoaderListener";

		[Token(Token = "0x4000084")]
		public const string UnityPaidEventListenerClassName = "com.google.unity.ads.UnityPaidEventListener";

		[Token(Token = "0x4000085")]
		public const string UnityRewardedInterstitialAdClassName = "com.google.unity.ads.UnityRewardedInterstitialAd";

		[Token(Token = "0x4000086")]
		public const string UnityRewardedInterstitialAdCallbackClassName = "com.google.unity.ads.UnityRewardedInterstitialAdCallback";

		[Token(Token = "0x4000087")]
		public const string PluginUtilsClassName = "com.google.unity.ads.PluginUtils";

		[Token(Token = "0x4000088")]
		public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";

		[Token(Token = "0x4000089")]
		public const string BundleClassName = "android.os.Bundle";

		[Token(Token = "0x400008A")]
		public const string DateClassName = "java.util.Date";

		[Token(Token = "0x400008B")]
		public const string DisplayMetricsClassName = "android.util.DisplayMetrics";

		[Token(Token = "0x600015A")]
		[Address(RVA = "0x1345A74", Offset = "0x1345A74", Length = "0x548")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\n\tv22 = UnityEngine.AndroidJavaClass;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = UnityEngine.AndroidJavaObject;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv210 = Il2CppMethodInfo;\n\tv211 = \"il2cpp_codegen_initialize_runtime_metadata\"(v210, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv277 = System.Int32;\n\tv278 = \"il2cpp_codegen_initialize_runtime_metadata\"(v277, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv338 = System.Object[];\n\tv339 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv373 = \"com.google.android.gms.ads.AdSize\";\n\tv374 = \"il2cpp_codegen_initialize_runtime_metadata\"(v373, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv388 = \"com.google.unity.ads.UnityAdSize\";\n\tv389 = \"il2cpp_codegen_initialize_runtime_metadata\"(v388, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv408 = \"com.unity3d.player.UnityPlayer\";\n\tv409 = \"il2cpp_codegen_initialize_runtime_metadata\"(v408, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv448 = \"getSmartBannerAdSize\";\n\tv449 = \"il2cpp_codegen_initialize_runtime_metadata\"(v448, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv459 = \"getLandscapeAnchoredAdaptiveBannerAdSize\";\n\tv460 = \"il2cpp_codegen_initialize_runtime_metadata\"(v459, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv487 = \"getPortraitAnchoredAdaptiveBannerAdSize\";\n\tv488 = \"il2cpp_codegen_initialize_runtime_metadata\"(v487, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv503 = \"getCurrentOrientationAnchoredAdaptiveBannerAdSize\";\n\tv504 = \"il2cpp_codegen_initialize_runtime_metadata\"(v503, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv565 = \"currentActivity\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v565, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A36848]) = v42;\nL_0041:\n\tv44 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v44, \"com.google.unity.ads.UnityAdSize\");\n\tv59 = adSize.type == 0;\n\tif (v59) goto L_0095;\n\tv118 = adSize.type == 2;\n\tif (v118) goto L_00D6;\n\tv74 = adSize.type != 1;\n\tif (v74) goto L_01BC;\n\tgoto L_006F;\n\tv376 = System.Array::Empty();\nL_006F:\n\tgoto L_0074;\n\tv390 = 0xB348B0(v380, v48, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0074:\n\tgoto L_007C;\n\tv410 = \"il2cpp_codegen_runtime_class_init\"(v391, v48, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_007C:\n\tgoto L_008F;\n\tv450 = 0xB348B0(v413, v48, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_008F:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v44, \"getSmartBannerAdSize\", v463.Value);\n\treturn returnVal1;\nL_0095:\n\t// 149 NewArr v217 @ X0_v29 (System.Object[]), typeof(System.Object[]), 2\n\tv190 = adSize.width;\n\t// 157 Box v165 @ X0_v31, typeof(System.Int32), &v190 @ X8_v12 (System.Int32)\n\tv386 = v165 == 0;\n\tif (v386) goto L_00AC;\n\t// 166 IsInst v306 @ X0_v41, typeof(System.Object), v165 @ X0_v31\n\tv315 = v306 == 0;\n\tif (v315) goto L_01B6;\nL_00AC:\n\tv217[0] = v165;\n\tv443 = adSize.height;\n\t// 177 Box v446 @ X0_v34, typeof(System.Int32), &v443 @ X8_v15 (System.Int32)\n\tv457 = v446 == 0;\n\tif (v457) goto L_00C8;\n\t// 184 IsInst v307 @ X0_v39, typeof(System.Object), v446 @ X0_v34\n\tv316 = v307 == 0;\n\tif (v316) goto L_01B6;\nL_00C8:\n\tv217[1] = v446;\n\tv501 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v501, \"com.google.android.gms.ads.AdSize\", v217);\n\tgoto L_01B3;\nL_00D6:\n\tv166 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v166, \"com.unity3d.player.UnityPlayer\");\n\tv403 = UnityEngine.AndroidJavaObject::GetStatic(v166, \"currentActivity\");\n\tv434 = adSize.orientation == 0;\n\tif (v434) goto L_013B;\n\tv122 = adSize.orientation == 2;\n\tif (v122) goto L_0172;\n\tv75 = adSize.orientation != 1;\n\tif (v75) goto L_01C4;\n\t// 260 NewArr v167 @ X0_v76 (System.Object[]), typeof(System.Object[]), 2\n\tv566 = v403 == 0;\n\tif (v566) goto L_0113;\n\t// 269 IsInst v308 @ X0_v84, typeof(System.Object), v403 @ X0_v45 (System.Object)\n\tv317 = v308 == 0;\n\tif (v317) goto L_01B6;\nL_0113:\n\tv167[0] = v403;\n\tv610 = adSize.width;\n\t// 282 Box v613 @ X0_v79, typeof(System.Int32), &v610 @ X8_v56 (System.Int32)\n\tv619 = v613 == 0;\n\tif (v619) goto L_0131;\n\t// 289 IsInst v309 @ X0_v82, typeof(System.Object), v613 @ X0_v79\n\tv318 = v309 == 0;\n\tif (v318) goto L_01B6;\nL_0131:\n\tv167[1] = v613;\n\tgoto L_01AA;\nL_013B:\n\t// 315 NewArr v169 @ X0_v50 (System.Object[]), typeof(System.Object[]), 2\n\tv497 = v403 == 0;\n\tif (v497) goto L_014A;\n\t// 324 IsInst v310 @ X0_v58, typeof(System.Object), v403 @ X0_v45 (System.Object)\n\tv319 = v310 == 0;\n\tif (v319) goto L_01B6;\nL_014A:\n\tv169[0] = v403;\n\tv572 = adSize.width;\n\t// 337 Box v575 @ X0_v53, typeof(System.Int32), &v572 @ X8_v34 (System.Int32)\n\tv584 = v575 == 0;\n\tif (v584) goto L_0168;\n\t// 344 IsInst v311 @ X0_v56, typeof(System.Object), v575 @ X0_v53\n\tv320 = v311 == 0;\n\tif (v320) goto L_01B6;\nL_0168:\n\tv169[1] = v575;\n\tgoto L_01AA;\nL_0172:\n\t// 370 NewArr v171 @ X0_v60 (System.Object[]), typeof(System.Object[]), 2\n\tv554 = v403 == 0;\n\tif (v554) goto L_0181;\n\t// 379 IsInst v312 @ X0_v68, typeof(System.Object), v403 @ X0_v45 (System.Object)\n\tv321 = v312 == 0;\n\tif (v321) goto L_01B6;\nL_0181:\n\tv171[0] = v403;\n\tv580 = adSize.width;\n\t// 392 Box v583 @ X0_v63, typeof(System.Int32), &v580 @ X8_v45 (System.Int32)\n\tv614 = v583 == 0;\n\tif (v614) goto L_019F;\n\t// 399 IsInst v313 @ X0_v66, typeof(System.Object), v583 @ X0_v63\n\tv322 = v313 == 0;\n\tif (v322) goto L_01B6;\nL_019F:\n\tv171[1] = v583;\nL_01AA:\n\tv600 = UnityEngine.AndroidJavaObject::CallStatic(v44, *([v604 @ X8_v29 (System.String)]), v608);\nL_01B3:\n\treturn v602;\n\tv208 = new System.NullReferenceException();\n\tv275 = new System.IndexOutOfRangeException();\nL_01B6:\n\tv336 = new System.ArrayTypeMismatchException();\n\tthrow v336;\nL_01BC:\n\tv385 = new System.ArgumentException();\n\tgoto L_01CC;\nL_01C4:\n\tv553 = new System.ArgumentException();\nL_01CC:\n\tSystem.ArgumentException::.ctor(v438, v431);\n\tthrow v438;\n// 330 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AndroidJavaObject GetAdSizeJavaObject(AdSize adSize)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.unity.ads.UnityAdSize");
			ArgumentException ex2;
			if (adSize.AdType != AdSize.Type.Standard)
			{
				if (adSize.AdType != AdSize.Type.AnchoredAdaptive)
				{
					if (adSize.AdType == AdSize.Type.SmartBanner)
					{
						return (AndroidJavaObject)androidJavaClass.CallStatic<object>("getSmartBannerAdSize", Array.Empty<object>());
					}
					ArgumentException ex = new ArgumentException();
					string text = "Invalid AdSize.Type provided for ad size.";
					ex2 = ex;
					goto IL_0598;
				}
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
				object obj = androidJavaClass2.GetStatic<object>("currentActivity");
				string methodName;
				object[] args;
				if (adSize.orientation != Orientation.Current)
				{
					if (adSize.orientation != Orientation.Portrait)
					{
						if (adSize.orientation != Orientation.Landscape)
						{
							ArgumentException ex3 = new ArgumentException();
							string text = "Invalid Orientation provided for ad size.";
							ex2 = ex3;
							goto IL_0598;
						}
						object[] array = new object[2];
						if (obj != null)
						{
							object obj2 = obj as object;
							if (obj2 == null)
							{
								goto IL_0542;
							}
						}
						array[0] = obj;
						int width = adSize.Width;
						object obj3 = width;
						if (obj3 != null)
						{
							object obj4 = obj3 as object;
							if (obj4 == null)
							{
								goto IL_0542;
							}
						}
						array[1] = obj3;
						methodName = "getLandscapeAnchoredAdaptiveBannerAdSize";
						args = array;
					}
					else
					{
						object[] array2 = new object[2];
						if (obj != null)
						{
							object obj5 = obj as object;
							if (obj5 == null)
							{
								goto IL_0542;
							}
						}
						array2[0] = obj;
						int width2 = adSize.Width;
						object obj6 = width2;
						if (obj6 != null)
						{
							object obj7 = obj6 as object;
							if (obj7 == null)
							{
								goto IL_0542;
							}
						}
						array2[1] = obj6;
						methodName = "getPortraitAnchoredAdaptiveBannerAdSize";
						args = array2;
					}
				}
				else
				{
					object[] array3 = new object[2];
					if (obj != null)
					{
						object obj8 = obj as object;
						if (obj8 == null)
						{
							goto IL_0542;
						}
					}
					array3[0] = obj;
					int width3 = adSize.Width;
					object obj9 = width3;
					if (obj9 != null)
					{
						object obj10 = obj9 as object;
						if (obj10 == null)
						{
							goto IL_0542;
						}
					}
					array3[1] = obj9;
					methodName = "getCurrentOrientationAnchoredAdaptiveBannerAdSize";
					args = array3;
				}
				return (AndroidJavaObject)androidJavaClass.CallStatic<object>(methodName, args);
			}
			object[] array4 = new object[2];
			int width4 = adSize.Width;
			object obj11 = width4;
			if (obj11 != null)
			{
				object obj12 = obj11 as object;
				if (obj12 == null)
				{
					goto IL_0542;
				}
			}
			array4[0] = obj11;
			int height = adSize.Height;
			object obj13 = height;
			if (obj13 != null)
			{
				object obj14 = obj13 as object;
				if (obj14 == null)
				{
					goto IL_0542;
				}
			}
			array4[1] = obj13;
			return new AndroidJavaObject("com.google.android.gms.ads.AdSize", array4);
			IL_0598:
			throw ex2;
			IL_0542:
			ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
			throw ex4;
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x134ADB4", Offset = "0x134ADB4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = GoogleMobileAds.Android.DisplayMetrics;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36849]) = v34;\nL_0012:\n\tv36 = new GoogleMobileAds.Android.DisplayMetrics();\n\tGoogleMobileAds.Android.DisplayMetrics::.ctor(v36);\n\tv46 = v36.<WidthPixels>k__BackingField / v36.<Density>k__BackingField;\n\tv58 = v46 != 0x7F800000;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int GetScreenWidth()
		{
			//IL_0056: Expected I4, but got F4
			DisplayMetrics displayMetrics = new DisplayMetrics();
			float num = (float)displayMetrics.WidthPixels / displayMetrics.Density;
			if (num == float.PositiveInfinity)
			{
				return int.MinValue;
			}
			return (int)num;
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x13437B4", Offset = "0x13437B4", Length = "0x168C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00F1;\n\tv34 = UnityEngine.AndroidJavaClass;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv88 = Il2CppMethodInfo;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv96 = Il2CppMethodInfo;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv109 = Il2CppMethodInfo;\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv120 = UnityEngine.AndroidJavaObject;\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv127 = Il2CppMethodInfo;\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv131 = System.Boolean;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv523 = System.DateTime;\n\tv524 = \"il2cpp_codegen_initialize_runtime_metadata\"(v523, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv621 = Il2CppMethodInfo;\n\tv622 = \"il2cpp_codegen_initialize_runtime_metadata\"(v621, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv631 = Il2CppMethodInfo;\n\tv632 = \"il2cpp_codegen_initialize_runtime_metadata\"(v631, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv716 = Il2CppMethodInfo;\n\tv717 = \"il2cpp_codegen_initialize_runtime_metadata\"(v716, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv766 = Il2CppMethodInfo;\n\tv767 = \"il2cpp_codegen_initialize_runtime_metadata\"(v766, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv778 = Il2CppMethodInfo;\n\tv779 = \"il2cpp_codegen_initialize_runtime_metadata\"(v778, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv833 = Il2CppMethodInfo;\n\tv834 = \"il2cpp_codegen_initialize_runtime_metadata\"(v833, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1018 = Il2CppMethodInfo;\n\tv1019 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1018, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1135 = Il2CppMethodInfo;\n\tv1136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1135, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1256 = Il2CppMethodInfo;\n\tv1257 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1256, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1436 = Il2CppMethodInfo;\n\tv1437 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1436, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1554 = Il2CppMethodInfo;\n\tv1555 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1554, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1709 = Il2CppMethodInfo;\n\tv1710 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1709, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1839 = Il2CppMethodInfo;\n\tv1840 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1839, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1952 = Il2CppMethodInfo;\n\tv1953 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1952, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2098 = System.Int32;\n\tv2099 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2098, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2277 = Il2CppMethodInfo;\n\tv2278 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2277, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2576 = Il2CppMethodInfo;\n\tv2577 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2576, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2696 = Il2CppMethodInfo;\n\tv2697 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2696, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2726 = Il2CppMethodInfo;\n\tv2727 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2726, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2792 = Il2CppMethodInfo;\n\tv2793 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2792, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2829 = Il2CppMethodInfo;\n\tv2830 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2829, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2918 = Il2CppMethodInfo;\n\tv2919 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2918, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2935 = Il2CppMethodInfo;\n\tv2936 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2935, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv2992 = Il2CppMethodInfo;\n\tv2993 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2992, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3006 = Il2CppMethodInfo;\n\tv3007 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3006, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3022 = Il2CppMethodInfo;\n\tv3023 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3022, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3047 = Il2CppMethodInfo;\n\tv3048 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3047, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3065 = System.Nullable`1<System.Int32>;\n\tv3066 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3065, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3077 = System.Object[];\n\tv3078 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3077, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3092 = \"com.google.android.gms.ads.AdRequest$Builder\";\n\tv3093 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3092, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3141 = \"java.util.Date\";\n\tv3142 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3141, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3230 = \"setBirthday\";\n\tv3231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3230, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3247 = \"com.google.android.gms.ads.AdRequest\";\n\tv3248 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3247, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3274 = \"setGender\";\n\tv3275 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3274, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3385 = \"unity-5.4.0\";\n\tv3386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3385, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3400 = \"GENDER_FEMALE\";\n\tv3401 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3400, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3415 = \"DEVICE_ID_EMULATOR\";\n\tv3416 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3415, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3438 = \"SIMULATOR\";\n\tv3439 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3438, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv3457 = \"tagForChildDirectedTreatment\";\n\tv3458 \n// ... truncated")]
		public unsafe static AndroidJavaObject GetAdRequestJavaObject(AdRequest request)
		{
			//IL_0053: Expected I, but got O
			//IL_0161: Expected I, but got O
			//IL_066b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0670: Expected I4, but got Unknown
			//IL_02b4: Expected O, but got I
			//IL_0377: Expected O, but got I
			//IL_037f: Expected O, but got I
			//IL_09e7: Expected O, but got I
			//IL_06a0: Expected I4, but got O
			//IL_03a9: Expected I4, but got O
			//IL_08b0: Expected O, but got I
			//IL_08ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_08f1: Expected O, but got Unknown
			//IL_0207: Expected O, but got I
			//IL_0a52: Expected I, but got O
			//IL_1e90: Expected O, but got I
			//IL_0407: Expected I, but got O
			//IL_1c5c: Expected I, but got O
			//IL_097f: Expected I, but got O
			//IL_04a3: Expected I, but got O
			//IL_07b0: Expected O, but got I
			//IL_0587: Expected O, but got I
			//IL_053f: Expected I, but got O
			//IL_0ae5: Expected I, but got O
			//IL_0aea: Expected I, but got O
			//IL_0826: Expected I, but got O
			//IL_05f0: Expected I, but got O
			//IL_05f5: Expected I, but got O
			//IL_0c3c: Expected O, but got I
			//IL_0b00: Expected O, but got I
			//IL_0d37: Expected O, but got I
			//IL_0be5: Expected I, but got O
			//IL_0bea: Expected I, but got O
			//IL_0d6c: Expected I, but got O
			//IL_0dbc: Expected O, but got I
			//IL_0e0e: Expected I, but got O
			//IL_19a2: Expected O, but got I
			//IL_0e90: Expected I, but got O
			//IL_0e9c: Expected O, but got I
			//IL_0ea0: Expected O, but got I4
			//IL_0ea8: Expected O, but got I
			//IL_210e: Expected O, but got I
			//IL_1ed5: Expected O, but got I
			//IL_19f3: Expected O, but got I
			//IL_0f01: Expected O, but got I
			//IL_1a4b: Expected O, but got I
			//IL_1a1d: Expected O, but got I
			//IL_0f61: Expected O, but got I
			//IL_0f33: Expected O, but got I
			//IL_1ad5: Expected O, but got I
			//IL_0fef: Expected O, but got I
			//IL_1aaa: Expected O, but got I
			//IL_1001: Expected O, but got I
			//IL_0fc8: Expected O, but got I
			//IL_1f33: Expected O, but got I
			//IL_109e: Expected O, but got I
			//IL_111f: Expected O, but got I
			//IL_1137: Expected O, but got I4
			//IL_1140: Expected I, but got O
			//IL_1148: Expected O, but got I
			//IL_1155: Expected O, but got I
			//IL_1906: Expected I, but got O
			//IL_191f: Expected O, but got I
			//IL_1955: Expected I, but got O
			//IL_11d1: Expected I, but got O
			//IL_1faa: Expected O, but got I
			//IL_1dd8: Expected O, but got I
			//IL_187a: Expected I, but got O
			//IL_1e03: Expected O, but got I
			//IL_18c0: Expected I, but got O
			//IL_1279: Expected I, but got O
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.android.gms.ads.AdRequest$Builder");
			HashSet<string>.Enumerator enumerator = request.Keywords.GetEnumerator();
			nint num = unchecked((nint)null);
			object[] array = Array.Empty<object>();
			AdRequest adRequest = request;
			HashSet<object>.Enumerator enumerator2 = default(HashSet<object>.Enumerator);
			string text = default(string);
			List<object>.Enumerator enumerator7 = default(List<object>.Enumerator);
			object[] array3 = default(object[]);
			object[] array4 = default(object[]);
			object[] array5 = default(object[]);
			object[] array6 = default(object[]);
			Dictionary<string, string>.Enumerator enumerator9;
			Dictionary<string, string>.Enumerator enumerator10 = default(Dictionary<string, string>.Enumerator);
			List<object>.Enumerator enumerator3;
			object[] array7 = default(object[]);
			object[] array8 = default(object[]);
			Dictionary<object, object>.Enumerator enumerator12 = default(Dictionary<object, object>.Enumerator);
			object[] array9 = default(object[]);
			object obj9 = default(object);
			object[] array10 = default(object[]);
			object[] array11 = default(object[]);
			object[] array12 = default(object[]);
			List<object>.Enumerator enumerator15 = default(List<object>.Enumerator);
			Dictionary<object, object>.Enumerator enumerator16 = default(Dictionary<object, object>.Enumerator);
			object[] array13 = default(object[]);
			while (true)
			{
				object[] array2;
				if (enumerator2.MoveNext())
				{
					array2 = new object[1];
					if (text == null)
					{
						goto IL_00c3;
					}
					androidJavaObject = (AndroidJavaObject)(text as object);
					if (androidJavaObject != null)
					{
						goto IL_00c3;
					}
					goto IL_1bbd;
				}
				enumerator2.Dispose();
				enumerator3 = default(List<object>.Enumerator);
				Dictionary<object, object>.Enumerator enumerator4 = default(Dictionary<object, object>.Enumerator);
				HashSet<object>.Enumerator enumerator5 = enumerator2;
				string methodName = "put";
				string methodName2 = "addTestDevice";
				nint num2 = 0;
				string text2 = "SIMULATOR";
				nint num3 = (nint)typeof(object[]);
				List<string>.Enumerator enumerator6 = request.TestDevices.GetEnumerator();
				while (enumerator7.MoveNext())
				{
					if (text == text2)
					{
						AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.AdRequest");
						bool flag = androidJavaClass == null;
						androidJavaObject = androidJavaClass;
						if (!flag)
						{
							object obj = androidJavaClass.GetStatic<object>("DEVICE_ID_EMULATOR");
							androidJavaObject = (AndroidJavaObject)num3;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
							if (obj != null)
							{
								androidJavaObject = (AndroidJavaObject)(obj as object);
								if (androidJavaObject == null)
								{
									ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
									throw ex;
								}
							}
							array3[0] = obj;
							num = num2;
							object obj2 = androidJavaObject.Call<object>(methodName2, array3);
							array = array3;
							adRequest = (AdRequest)(object)array3;
							continue;
						}
						throw androidJavaClass;
					}
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					if (text != null)
					{
						androidJavaObject = (AndroidJavaObject)(text as object);
						if (androidJavaObject == null)
						{
							ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
							throw ex2;
						}
					}
					array4[0] = text;
					num = num2;
					object obj3 = androidJavaObject.Call<object>(methodName2, array4);
					array = array4;
					adRequest = (AdRequest)(object)array4;
				}
				enumerator7.Dispose();
				List<object>.Enumerator enumerator8;
				nint num4;
				nint num5;
				if ((object)request.Birthday != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v518 @ X20_v3 (GoogleMobileAds.Api.AdRequest)+28]");
					DateTime dateTime = (DateTime)0;
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					int year = dateTime.Year;
					AdRequest adRequest2 = (AdRequest)(object)(int)enumerator2;
					if (adRequest2 != null)
					{
						androidJavaObject = (AndroidJavaObject)(adRequest2 as object);
						bool flag2 = androidJavaObject == null;
						enumerator8 = enumerator7;
						num4 = 0;
						num5 = (nint)typeof(int);
						adRequest = adRequest2;
						if (flag2)
						{
							goto IL_1c4e;
						}
					}
					array5[0] = adRequest2;
					int month = dateTime.Month;
					AdRequest adRequest3 = (AdRequest)(object)month;
					if (adRequest3 != null)
					{
						androidJavaObject = (AndroidJavaObject)(adRequest3 as object);
						bool flag3 = androidJavaObject == null;
						enumerator8 = enumerator7;
						num4 = 0;
						num5 = (nint)typeof(int);
						adRequest = adRequest3;
						if (flag3)
						{
							goto IL_1c4e;
						}
					}
					array5[1] = adRequest3;
					int day = dateTime.Day;
					AdRequest adRequest4 = (AdRequest)(object)day;
					if (adRequest4 != null)
					{
						androidJavaObject = (AndroidJavaObject)(adRequest4 as object);
						bool flag4 = androidJavaObject == null;
						enumerator8 = enumerator7;
						num4 = 0;
						num5 = (nint)typeof(int);
						adRequest = adRequest4;
						if (flag4)
						{
							goto IL_1c4e;
						}
					}
					array5[2] = adRequest4;
					androidJavaObject = new AndroidJavaObject("java.util.Date", array5);
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					if (num3 != 0)
					{
						androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
						bool flag5 = androidJavaObject == null;
						enumerator8 = enumerator7;
						num4 = 0;
						num5 = (nint)typeof(int);
						num = unchecked((nint)null);
						array = array5;
						adRequest = (AdRequest)(object)androidJavaObject;
						if (flag5)
						{
							goto IL_1c4e;
						}
					}
					array6[0] = androidJavaObject;
					num = num2;
					object obj4 = androidJavaObject.Call<object>("setBirthday", array6);
					array = array6;
					adRequest = (AdRequest)(object)androidJavaObject;
				}
				int? num7;
				if (((_003F?)request.Gender & 0xFF) != 0)
				{
					int num6 = (object?)request.Gender >> 32;
					AndroidJavaClass androidJavaClass3;
					string fieldName;
					if (num6 != 2)
					{
						if (num6 != 1)
						{
							bool flag6 = num6 == 0;
							bool flag7 = !flag6;
							num7 = null;
							if (flag7)
							{
								goto IL_078a;
							}
							AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.google.android.gms.ads.AdRequest");
							androidJavaClass3 = androidJavaClass2;
							fieldName = "GENDER_UNKNOWN";
						}
						else
						{
							AndroidJavaClass androidJavaClass4 = new AndroidJavaClass("com.google.android.gms.ads.AdRequest");
							androidJavaClass3 = androidJavaClass4;
							fieldName = "GENDER_MALE";
						}
					}
					else
					{
						AndroidJavaClass androidJavaClass5 = new AndroidJavaClass("com.google.android.gms.ads.AdRequest");
						androidJavaClass3 = androidJavaClass5;
						fieldName = "GENDER_FEMALE";
					}
					int value = androidJavaClass3.GetStatic<int>(fieldName);
					num7 = value;
					array = (object[])0;
					goto IL_078a;
				}
				goto IL_0886;
				IL_1c4e:
				ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
				nint num8 = unchecked((nint)null);
				throw ex3;
				IL_215c:
				nint num9;
				if (num8 == 1)
				{
					((Dictionary<string, string>.Enumerator*)enumerator9)->Dispose();
					((Dictionary<string, string>.Enumerator*)enumerator10)->Dispose();
					enumerator3.Dispose();
					bool flag8 = (object)enumerator10 == null;
					num9 = 0;
					if (!flag8)
					{
						throw new OutOfMemoryException();
					}
					goto IL_199a;
				}
				break;
				IL_00c3:
				array2[0] = text;
				object obj5 = androidJavaObject.Call<object>("addKeyword", array2);
				num = 0;
				array = array2;
				adRequest = (AdRequest)(object)text;
				continue;
				IL_0886:
				if ((object)request.TagForChildDirectedTreatment != null)
				{
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					bool flag9 = (nint)request.TagForChildDirectedTreatment < 255;
					bool flag10 = !flag9;
					object obj6 = (_003F?)request.TagForChildDirectedTreatment - 255;
					bool flag11 = obj6 == null;
					bool flag12 = !flag11;
					flag12 = flag10 && flag12;
					AdRequest adRequest5 = (AdRequest)(object)flag12;
					if (adRequest5 != null)
					{
						androidJavaObject = (AndroidJavaObject)(adRequest5 as object);
						bool flag13 = androidJavaObject == null;
						enumerator8 = enumerator7;
						num4 = 0;
						num5 = (nint)typeof(int);
						adRequest = adRequest5;
						if (flag13)
						{
							goto IL_1c4e;
						}
					}
					array7[0] = adRequest5;
					num = num2;
					object obj7 = androidJavaObject.Call<object>("tagForChildDirectedTreatment", array7);
					array = array7;
					adRequest = adRequest5;
				}
				androidJavaObject = (AndroidJavaObject)num3;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
				if ("unity-5.4.0" != null)
				{
					androidJavaObject = (AndroidJavaObject)("unity-5.4.0" as object);
					bool flag14 = androidJavaObject == null;
					enumerator8 = enumerator7;
					num4 = 0;
					num5 = (nint)typeof(int);
					if (flag14)
					{
						goto IL_1c4e;
					}
				}
				array8[0] = "unity-5.4.0";
				object obj8 = androidJavaObject.Call<object>("setRequestAgent", array8);
				androidJavaObject = new AndroidJavaObject("android.os.Bundle");
				Dictionary<string, string>.Enumerator enumerator11 = request.Extras.GetEnumerator();
				num5 = (nint)typeof(int);
				num = unchecked((nint)null);
				array = Array.Empty<object>();
				while (enumerator12.MoveNext())
				{
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					if (text != null)
					{
						androidJavaObject = (AndroidJavaObject)(text as object);
						if (androidJavaObject == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					array9[0] = text;
					if (obj9 != null)
					{
						androidJavaObject = (AndroidJavaObject)(obj9 as object);
						if (androidJavaObject == null)
						{
							ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
							throw ex5;
						}
					}
					array9[1] = obj9;
					androidJavaObject.Call("putString", array9);
					num5 = (nint)text;
					num = unchecked((nint)null);
					array = array9;
				}
				enumerator12.Dispose();
				enumerator4 = enumerator12;
				string text3 = text;
				enumerator8 = (List<object>.Enumerator)enumerator12;
				num4 = 0;
				AndroidJavaObject androidJavaObject2 = androidJavaObject;
				string methodName3 = "putString";
				androidJavaObject = (AndroidJavaObject)num3;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
				if ("is_unity" != null)
				{
					androidJavaObject = (AndroidJavaObject)("is_unity" as object);
					bool flag15 = androidJavaObject == null;
					adRequest = (AdRequest)(object)androidJavaObject2;
					if (flag15)
					{
						goto IL_1c4e;
					}
				}
				array10[0] = "is_unity";
				if ("1" != null)
				{
					androidJavaObject = (AndroidJavaObject)("1" as object);
					bool flag16 = androidJavaObject == null;
					adRequest = (AdRequest)(object)androidJavaObject2;
					if (flag16)
					{
						goto IL_1c4e;
					}
				}
				array10[1] = "1";
				androidJavaObject2.Call(methodName3, array10);
				androidJavaObject = (AndroidJavaObject)num3;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
				androidJavaObject = (AndroidJavaObject)(androidJavaObject2 as object);
				bool flag17 = androidJavaObject == null;
				num = unchecked((nint)null);
				array = array10;
				adRequest = (AdRequest)(object)androidJavaObject2;
				nint num11;
				if (!flag17)
				{
					array11[0] = androidJavaObject2;
					androidJavaObject = new AndroidJavaObject("com.google.android.gms.ads.mediation.admob.AdMobExtras", array11);
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					if (num3 != 0)
					{
						androidJavaObject = (AndroidJavaObject)(androidJavaObject as object);
						bool flag18 = androidJavaObject == null;
						num = unchecked((nint)null);
						array = array11;
						adRequest = (AdRequest)(object)array12;
						if (flag18)
						{
							goto IL_1c4e;
						}
					}
					array12[0] = androidJavaObject;
					num = num2;
					object obj10 = androidJavaObject.Call<object>("addNetworkExtras", array12);
					List<GoogleMobileAds.Api.Mediation.MediationExtras>.Enumerator enumerator13 = request.MediationExtras.GetEnumerator();
					List<object>.Enumerator enumerator14 = enumerator15;
					array = array12;
					if (enumerator15.MoveNext())
					{
						nint num10 = (nint)text;
						string className = (string)text.CompareTo(0);
						AndroidJavaObject androidJavaObject3 = (AndroidJavaObject)num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3569 @ X20_v59 (UnityEngine.AndroidJavaObject)+38]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3569 @ X20_v59 (UnityEngine.AndroidJavaObject)+38]");
						if ((nint)0 == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3565 @ X8_v230 (Il2CppClass<System.String>)+180]");
							androidJavaObject = androidJavaObject3.Call<AndroidJavaObject>((string)0, array);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3569 @ X20_v59 (UnityEngine.AndroidJavaObject)+38]");
							num11 = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v9 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+10]");
						androidJavaObject = (AndroidJavaObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						if ((int)((nint)0 & (nint)1) == 0)
						{
							AndroidJavaObject androidJavaObject4 = androidJavaObject;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3565 @ X8_v230 (Il2CppClass<System.String>)+180]");
							androidJavaObject = androidJavaObject4.Call<AndroidJavaObject>((string)0, array);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3569 @ X20_v59 (UnityEngine.AndroidJavaObject)+38]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v9 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+10]");
						androidJavaObject = (AndroidJavaObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						if ((int)((nint)0 & (nint)1) == 0)
						{
							AndroidJavaObject androidJavaObject5 = androidJavaObject;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3565 @ X8_v230 (Il2CppClass<System.String>)+180]");
							androidJavaObject = androidJavaObject5.Call<AndroidJavaObject>((string)0, array);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+B8]");
						num11 = 0;
						androidJavaObject = new AndroidJavaObject(className, (object[])num11);
						object obj11 = num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3608 @ X22_v68+38]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3608 @ X22_v68+38]");
						if ((nint)0 == 0)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3608 @ X22_v68+38]");
							num11 = 0;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v9 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+10]");
						androidJavaObject = (AndroidJavaObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						if ((int)((nint)0 & (nint)1) == 0)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B348B0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3608 @ X22_v68+38]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v9 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+10]");
						androidJavaObject = (AndroidJavaObject)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						num11 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
						if ((int)((nint)0 & (nint)1) == 0)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B348B0");
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+B8]");
						num11 = 0;
						androidJavaObject = new AndroidJavaObject("java.util.HashMap", (object[])num11);
						androidJavaObject = (AndroidJavaObject)((Dictionary<object, object>)text.Length).GetEnumerator();
						num = unchecked((nint)null);
						array = (object[])num11;
						while (enumerator16.MoveNext())
						{
							androidJavaObject = (AndroidJavaObject)num3;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
							if (array13 != null)
							{
								bool flag19 = text == null;
								num8 = 2;
								if (!flag19)
								{
									androidJavaObject = (AndroidJavaObject)(text as object);
									bool flag20 = androidJavaObject == null;
									num8 = (nint)typeof(object);
									if (flag20)
									{
										ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
										throw ex6;
									}
								}
								num11 = array13.Length;
								if (array13.Length != 0)
								{
									array13[0] = text;
									if (obj9 != null)
									{
										androidJavaObject = (AndroidJavaObject)(obj9 as object);
										if (androidJavaObject == null)
										{
											ArrayTypeMismatchException ex7 = new ArrayTypeMismatchException();
											throw ex7;
										}
										num11 = array13.Length;
										num8 = (nint)typeof(object);
									}
									bool flag21 = num11 < 1;
									bool flag22 = !flag21;
									object obj12 = num11 - 1;
									bool flag23 = obj12 == null;
									bool flag12 = !flag22;
									if (!(flag12 || flag23))
									{
										array13[1] = obj9;
										if (androidJavaObject != null)
										{
											num = num2;
											object obj13 = androidJavaObject.Call<object>(methodName, array13);
											array = array13;
											continue;
										}
										NullReferenceException ex8 = new NullReferenceException();
										enumerator3 = enumerator15;
										enumerator4 = enumerator16;
										text3 = text;
										enumerator8 = (List<object>.Enumerator)enumerator16;
										num5 = (nint)text;
										enumerator9 = (Dictionary<string, string>.Enumerator)ex8;
										adRequest = (AdRequest)(object)androidJavaObject;
									}
									else
									{
										IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
										enumerator3 = enumerator15;
										enumerator4 = enumerator16;
										text3 = text;
										enumerator8 = (List<object>.Enumerator)enumerator16;
										num5 = (nint)text;
										enumerator9 = (Dictionary<string, string>.Enumerator)ex9;
										adRequest = (AdRequest)(object)androidJavaObject;
									}
								}
								else
								{
									IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
									enumerator3 = enumerator15;
									enumerator4 = enumerator16;
									text3 = text;
									enumerator8 = (List<object>.Enumerator)enumerator16;
									num5 = (nint)text;
									enumerator9 = (Dictionary<string, string>.Enumerator)ex10;
									adRequest = (AdRequest)(object)androidJavaObject;
								}
							}
							else
							{
								NullReferenceException ex11 = new NullReferenceException();
								enumerator3 = enumerator15;
								enumerator4 = enumerator16;
								text3 = text;
								enumerator8 = (List<object>.Enumerator)enumerator16;
								num5 = (nint)text;
								num8 = 2;
								enumerator9 = (Dictionary<string, string>.Enumerator)ex11;
								adRequest = (AdRequest)num3;
							}
							enumerator4.Dispose();
							if (num5 != 0)
							{
								OutOfMemoryException ex12 = new OutOfMemoryException();
								NullReferenceException ex13 = new NullReferenceException();
								NullReferenceException ex14 = new NullReferenceException();
								IndexOutOfRangeException ex15 = new IndexOutOfRangeException();
								IndexOutOfRangeException ex16 = new IndexOutOfRangeException();
								NullReferenceException ex17 = new NullReferenceException();
								NullReferenceException ex18 = new NullReferenceException();
								IndexOutOfRangeException ex19 = new IndexOutOfRangeException();
								NullReferenceException ex20 = new NullReferenceException();
								throw new NullReferenceException();
							}
							goto IL_215c;
						}
						enumerator16.Dispose();
						OutOfMemoryException ex21 = new OutOfMemoryException();
						NullReferenceException ex22 = new NullReferenceException();
						IndexOutOfRangeException ex23 = new IndexOutOfRangeException();
						NullReferenceException ex24 = new NullReferenceException();
						goto IL_1bbd;
					}
					enumerator15.Dispose();
					num9 = 0;
					goto IL_199a;
				}
				goto IL_1c4e;
				IL_078a:
				if (false)
				{
					androidJavaObject = (AndroidJavaObject)num3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					AdRequest adRequest6 = (AdRequest)(object)num7;
					if (adRequest6 != null)
					{
						androidJavaObject = (AndroidJavaObject)(adRequest6 as object);
						bool flag24 = androidJavaObject == null;
						enumerator8 = enumerator7;
						num4 = 0;
						num5 = (nint)typeof(int);
						adRequest = adRequest6;
						if (flag24)
						{
							goto IL_1c4e;
						}
					}
					object[] array14;
					array14[0] = adRequest6;
					num = num2;
					object obj14 = androidJavaObject.Call<object>("setGender", array14);
					array = array14;
					adRequest = adRequest6;
				}
				goto IL_0886;
				IL_199a:
				AndroidJavaObject androidJavaObject6 = (AndroidJavaObject)num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3193 @ X20_v55 (UnityEngine.AndroidJavaObject)+38]");
				num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3193 @ X20_v55 (UnityEngine.AndroidJavaObject)+38]");
				if ((nint)0 == 0)
				{
					androidJavaObject = androidJavaObject6.Call<AndroidJavaObject>((string)num9, array);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3193 @ X20_v55 (UnityEngine.AndroidJavaObject)+38]");
					num11 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v9 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+10]");
				androidJavaObject = (AndroidJavaObject)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
				num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
				if ((int)((nint)0 & (nint)1) == 0)
				{
					androidJavaObject = androidJavaObject.Call<AndroidJavaObject>((string)num9, array);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3193 @ X20_v55 (UnityEngine.AndroidJavaObject)+38]");
				num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v9 (Il2CppStaticFields<System.EmptyArray`1<System.Object>>)+10]");
				androidJavaObject = (AndroidJavaObject)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
				num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+135]");
				if ((int)((nint)0 & (nint)1) == 0)
				{
					androidJavaObject = androidJavaObject.Call<AndroidJavaObject>((string)num9, array);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X0_v9 (UnityEngine.AndroidJavaObject)+B8]");
				num11 = 0;
				return (AndroidJavaObject)androidJavaObject.Call<object>("build", (object[])num11);
				IL_1bbd:
				ArrayTypeMismatchException ex25 = new ArrayTypeMismatchException();
				throw ex25;
			}
			enumerator3.Dispose();
			nint num12 = 0;
			Dictionary<string, string>.Enumerator enumerator17 = enumerator9;
			androidJavaObject = ((AndroidJavaObject)enumerator17).Call<AndroidJavaObject>((string)num12, array);
			IntPtr intPtr = num12;
			OutOfMemoryException ex26 = new OutOfMemoryException();
			return ((AndroidJavaObject)(object)ex26).Call<AndroidJavaObject>((string)(nint)intPtr, array);
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x134AF10", Offset = "0x134AF10", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = UnityEngine.AndroidJavaObject;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv78 = Il2CppMethodInfo;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv102 = Il2CppMethodInfo;\n\tv103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v102, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv109 = Il2CppMethodInfo;\n\tv110 = \"il2cpp_codegen_initialize_runtime_metadata\"(v109, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv113 = System.Object[];\n\tv114 = \"il2cpp_codegen_initialize_runtime_metadata\"(v113, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv163 = \"add\";\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv168 = \"java.util.ArrayList\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A3684B]) = v48;\nL_003A:\n\tgoto L_0043;\n\tv60 = 0xB3490C(Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0043:\n\tgoto L_0048;\n\tv72 = 0xB348B0(v64, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0048:\n\tgoto L_0054;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v73, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0054:\n\tgoto L_0059;\n\tv95 = 0xB348B0(v85, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0059:\n\tv100 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v100, \"java.util.ArrayList\", v97.Value);\n\tv111 = csTypeList == 0;\n\tif (v111) goto L_00AB;\n\tv131 = System.Collections.Generic.List`1<System.String>::GetEnumerator(csTypeList);\nL_0077:\n\tv183 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v129 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv196 = v183 == 0;\n\tif (v196) goto L_0098;\n\t// 126 NewArr v210 @ X0_v35 (System.Object[]), typeof(System.Object[]), 1\n\tv265 = v166 == 0;\n\tif (v265) goto L_008D;\n\t// 135 IsInst v310 @ X0_v48, typeof(System.Object), v166 @ stack_-78\n\tv313 = v310 == 0;\n\tif (v313) goto L_00A8;\nL_008D:\n\tv210[0] = v166;\n\tv174 = UnityEngine.AndroidJavaObject::Call(v100, \"add\", v210);\n\tgoto L_0077;\nL_0098:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v129 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00A4:\n\treturn v100;\n\tv269 = new System.NullReferenceException();\n\tv272 = new System.NullReferenceException();\n\tv320 = new System.IndexOutOfRangeException();\nL_00A8:\n\tv324 = new System.ArrayTypeMismatchException();\n\tthrow v324;\nL_00AB:\n\tv161 = new System.NullReferenceException();\n\tgoto L_00BA;\n\tgoto L_00BA;\n\tgoto L_00BA;\n\tgoto L_00BA;\nL_00BA:\n\tv194 = \"java.util.ArrayList\" != 1;\n\tif (v194) goto L_00C8;\n\tv198 = UnityEngine.AndroidJavaObject::Call(v161, \"java.util.ArrayList\", v97.Value);\n\tv213 = UnityEngine.AndroidJavaObject::Call(v198, \"java.util.ArrayList\", v97.Value);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v134 @ stack_-70_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv204 = ~v198.m_value;\n\tif (v204) goto L_00A4;\n\tthrow System.OutOfMemoryException;\nL_00C8:\n\tgoto L_00CC;\n\tX20 = X0;\nL_00CC:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v134 @ stack_-70_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00D3;\n\tv303 = UnityEngine.AndroidJavaObject::Call(v161, *([v150 @ X22_v3]), v97.Value);\nL_00D3:\n\tv306 = new System.OutOfMemoryException();\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v306, *([v150 @ X22_v3]), v146);\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static AndroidJavaObject GetJavaListObject(List<string> csTypeList)
		{
			//IL_01ad: Expected O, but got I4
			//IL_0221: Expected O, but got I4
			//IL_014f: Expected O, but got I
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.util.ArrayList");
			bool flag = csTypeList == null;
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			object[] args = Array.Empty<object>();
			object typeFromHandle = typeof(AndroidJavaObject);
			if (!flag)
			{
				List<string>.Enumerator enumerator2 = csTypeList.GetEnumerator();
				args = Array.Empty<object>();
				List<object>.Enumerator enumerator3 = default(List<object>.Enumerator);
				object obj = default(object);
				while (enumerator3.MoveNext())
				{
					object[] array = new object[1];
					if (obj != null)
					{
						object obj2 = obj as object;
						if (obj2 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							typeFromHandle = 0;
							throw ex;
						}
					}
					array[0] = obj;
					bool flag2 = androidJavaObject.Call<bool>("add", array);
					args = array;
				}
				enumerator3.Dispose();
			}
			else
			{
				NullReferenceException ex2 = new NullReferenceException();
				if (unchecked((nint)"java.util.ArrayList") != 1)
				{
					enumerator.Dispose();
					OutOfMemoryException ex3 = new OutOfMemoryException();
					return (AndroidJavaObject)((AndroidJavaObject)(object)ex3).Call<bool>((string)typeFromHandle, args);
				}
				bool flag3 = ((AndroidJavaObject)(object)ex2).Call<bool>("java.util.ArrayList", Array.Empty<object>());
				bool flag4 = ((AndroidJavaObject)flag3).Call<bool>("java.util.ArrayList", Array.Empty<object>());
				enumerator.Dispose();
				if (((bool*)(flag3 ? 1 : 0))->m_value)
				{
					throw new OutOfMemoryException();
				}
			}
			return androidJavaObject;
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x134B218", Offset = "0x134B218", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv74 = System.Int32;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv106 = System.Collections.Generic.List`1<System.String>;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv112 = System.Object[];\n\tv113 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv209 = \"size\";\n\tv210 = \"il2cpp_codegen_initialize_runtime_metadata\"(v209, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv256 = \"get\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A3684C]) = v58;\nL_003B:\n\tv60 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v60);\n\tgoto L_004C;\n\tv77 = System.Collections.Generic.List`1<System.String>::.ctor(Il2CppMethodInfo);\nL_004C:\n\tgoto L_0051;\n\tv89 = System.Collections.Generic.List`1<System.String>::.ctor(v81, v64);\nL_0051:\n\tgoto L_FFFFFFFF;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v90, v64, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tgoto L_005F;\n\tv108 = System.Collections.Generic.List`1<System.String>::.ctor(v100, v64);\nL_005F:\n\tv116 = *([v109 @ X0_v9+B8]);\n\tv123 = UnityEngine.AndroidJavaObject::Call(javaTypeList, \"size\", *([v116 @ X8_v12]));\n\tv221 = v123 < 1;\n\tif (v221) goto L_00D6;\nL_0081:\n\t// 129 NewArr v364 @ X0_v23 (System.Object[]), typeof(System.Object[]), 1\n\t// 134 Box v190 @ X0_v25, typeof(System.Int32), &v134 @ X24_v7 (System.Int32)\n\tv400 = v190 == 0;\n\tif (v400) goto L_0095;\n\t// 143 IsInst v348 @ X0_v32, typeof(System.Object), v190 @ X0_v25\n\tv350 = v348 == 0;\n\tif (v350) goto L_00D9;\nL_0095:\n\tv364[0] = v190;\n\tv191 = UnityEngine.AndroidJavaObject::Call(javaTypeList, \"get\", v364);\n\tv199 = v60._items;\n\tv181 = v60._version + 1;\n\tv60._version = v181;\n\tv297 = v60._size;\n\tv406 = v60._size < v199.Length;\n\tv407 = ~v406;\n\tif (v407) goto L_00BB;\n\tv415 = v60._size + 1;\n\tv60._size = v415;\n\tv199[v297 @ X10_v10 (System.Int32)] = v191;\n\tgoto L_00BC;\nL_00BB:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v60, v191);\nL_00BC:\n\tv134 = v134 + 1;\n\tv276 = v123 != v134;\n\tif (v276) goto L_0081;\nL_00D6:\n\treturn v60;\n\tv207 = new System.NullReferenceException();\n\tv254 = new System.IndexOutOfRangeException();\nL_00D9:\n\tv356 = new System.ArrayTypeMismatchException();\n\tthrow v356;\n\treturn returnVal2;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<string> GetCsTypeList(AndroidJavaObject javaTypeList)
		{
			//IL_0015: Expected O, but got I
			//IL_002a: Expected O, but got I
			List<string> list = new List<string>();
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X0_v9+B8]");
			object args = 0;
			int num = javaTypeList.Call<int>("size", (object[])args);
			if (num >= 1)
			{
				int num2 = 0;
				do
				{
					object[] array = new object[1];
					object obj2 = num2;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
						if (obj3 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					array[0] = obj2;
					object obj4 = javaTypeList.Call<object>("get", array);
					string[] items = list._items;
					int version = list._version + 1;
					list._version = version;
					int count = list.Count;
					if (list.Count < items.Length)
					{
						int size = list.Count + 1;
						list._size = size;
						items[count] = (string)obj4;
					}
					else
					{
						list.Add((string)obj4);
					}
					num2++;
				}
				while (num != num2);
			}
			return list;
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x134DB08", Offset = "0x134DB08", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = UnityEngine.AndroidJavaObject;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv71 = System.Object[];\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv88 = \"setCustomData\";\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv97 = \"setUserId\";\n\tv98 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv104 = \"build\";\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv110 = \"com.google.android.gms.ads.rewarded.ServerSideVerificationOptions$Builder\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A3684D]) = v44;\nL_002F:\n\tgoto L_0038;\n\tv53 = 0xB3490C(Il2CppMethodInfo, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0038:\n\tgoto L_003D;\n\tv65 = 0xB348B0(v57, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003D:\n\tgoto L_004B;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004B:\n\tgoto L_0050;\n\tv90 = 0xB348B0(v79, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0050:\n\tv95 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v95, \"com.google.android.gms.ads.rewarded.ServerSideVerificationOptions$Builder\", v92.Value);\n\t// 88 NewArr v108 @ X0_v11 (System.Object[]), typeof(System.Object[]), 1\n\tv135 = serverSideVerificationOptions.<UserId>k__BackingField == 0;\n\tif (v135) goto L_006A;\n\t// 100 IsInst v156 @ X0_v43, typeof(System.Object), serverSideVerificationOptions.<UserId>k__BackingField (System.String)\n\tv158 = v156 == 0;\n\tif (v158) goto L_00BF;\nL_006A:\n\tv108[0] = serverSideVerificationOptions.<UserId>k__BackingField;\n\tv180 = UnityEngine.AndroidJavaObject::Call(v95, \"setUserId\", v108);\n\t// 120 NewArr v127 @ X0_v23 (System.Object[]), typeof(System.Object[]), 1\n\tv208 = serverSideVerificationOptions.<CustomData>k__BackingField == 0;\n\tif (v208) goto L_008A;\n\t// 130 IsInst v167 @ X0_v41, typeof(System.Object), serverSideVerificationOptions.<CustomData>k__BackingField (System.String)\n\tv169 = v167 == 0;\n\tif (v169) goto L_00BF;\nL_008A:\n\tv127[0] = serverSideVerificationOptions.<CustomData>k__BackingField;\n\tv218 = UnityEngine.AndroidJavaObject::Call(v95, \"setCustomData\", v127);\n\tgoto L_009D;\n\tv224 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"setCustomData\", v127);\nL_009D:\n\tgoto L_00A2;\n\tv233 = UnityEngine.AndroidJavaObject::Call(v228, v216, v217, v214);\nL_00A2:\n\tgoto L_FFFFFFFF;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v234, v216, v217, v214, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00AE;\n\tv247 = UnityEngine.AndroidJavaObject::Call(v242, v216, v217, v214);\nL_00AE:\n\tv203 = *([v248 @ X0_v32+B8]);\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v95, \"build\", *([v203 @ X8_v27]));\n\treturn returnVal2;\n\tv134 = new System.NullReferenceException();\n\tv152 = new System.IndexOutOfRangeException();\nL_00BF:\n\tv173 = new System.ArrayTypeMismatchException();\n\tthrow v173;\n\treturn returnVal1;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AndroidJavaObject GetServerSideVerificationOptionsJavaObject(ServerSideVerificationOptions serverSideVerificationOptions)
		{
			//IL_018c: Expected O, but got I
			//IL_01a1: Expected O, but got I
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.android.gms.ads.rewarded.ServerSideVerificationOptions$Builder");
			object[] array = new object[1];
			if (serverSideVerificationOptions.UserId != null)
			{
				object obj = serverSideVerificationOptions.UserId as object;
				if (obj == null)
				{
					goto IL_01bc;
				}
			}
			array[0] = serverSideVerificationOptions.UserId;
			object obj2 = androidJavaObject.Call<object>("setUserId", array);
			object[] array2 = new object[1];
			if (serverSideVerificationOptions.CustomData != null)
			{
				object obj3 = serverSideVerificationOptions.CustomData as object;
				if (obj3 == null)
				{
					goto IL_01bc;
				}
			}
			array2[0] = serverSideVerificationOptions.CustomData;
			object obj4 = androidJavaObject.Call<object>("setCustomData", array2);
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ X0_v32+B8]");
			object args = 0;
			return (AndroidJavaObject)androidJavaObject.Call<object>("build", (object[])args);
			IL_01bc:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x134F888", Offset = "0x134F888", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Utils()
		{
		}
	}
}
