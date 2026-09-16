using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x200001A")]
	public class RequestConfigurationClient
	{
		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x134A100", Offset = "0x134A100", Length = "0x670")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0065;\n\tv26 = UnityEngine.AndroidJavaClass;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv75 = UnityEngine.AndroidJavaObject;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv106 = Il2CppMethodInfo;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv333 = Il2CppMethodInfo;\n\tv334 = \"il2cpp_codegen_initialize_runtime_metadata\"(v333, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv375 = Il2CppMethodInfo;\n\tv376 = \"il2cpp_codegen_initialize_runtime_metadata\"(v375, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv423 = Il2CppMethodInfo;\n\tv424 = \"il2cpp_codegen_initialize_runtime_metadata\"(v423, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv447 = Il2CppMethodInfo;\n\tv448 = \"il2cpp_codegen_initialize_runtime_metadata\"(v447, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv479 = System.Nullable`1<System.Int32>;\n\tv480 = \"il2cpp_codegen_initialize_runtime_metadata\"(v479, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv549 = System.Object[];\n\tv550 = \"il2cpp_codegen_initialize_runtime_metadata\"(v549, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv573 = \"TAG_FOR_UNDER_AGE_OF_CONSENT_UNSPECIFIED\";\n\tv574 = \"il2cpp_codegen_initialize_runtime_metadata\"(v573, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv613 = \"setMaxAdContentRating\";\n\tv614 = \"il2cpp_codegen_initialize_runtime_metadata\"(v613, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv650 = \"TAG_FOR_CHILD_DIRECTED_TREATMENT_FALSE\";\n\tv651 = \"il2cpp_codegen_initialize_runtime_metadata\"(v650, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv677 = \"com.google.android.gms.ads.RequestConfiguration$Builder\";\n\tv678 = \"il2cpp_codegen_initialize_runtime_metadata\"(v677, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv699 = \"setTagForUnderAgeOfConsent\";\n\tv700 = \"il2cpp_codegen_initialize_runtime_metadata\"(v699, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv705 = \"setTagForChildDirectedTreatment\";\n\tv706 = \"il2cpp_codegen_initialize_runtime_metadata\"(v705, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv712 = \"setTestDeviceIds\";\n\tv713 = \"il2cpp_codegen_initialize_runtime_metadata\"(v712, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv718 = \"build\";\n\tv719 = \"il2cpp_codegen_initialize_runtime_metadata\"(v718, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv723 = \"TAG_FOR_UNDER_AGE_OF_CONSENT_FALSE\";\n\tv724 = \"il2cpp_codegen_initialize_runtime_metadata\"(v723, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv728 = \"TAG_FOR_UNDER_AGE_OF_CONSENT_TRUE\";\n\tv729 = \"il2cpp_codegen_initialize_runtime_metadata\"(v728, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv731 = \"com.google.android.gms.ads.RequestConfiguration\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v731, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A367E7]) = v46;\nL_0065:\n\tgoto L_006E;\n\tv57 = 0xB3490C(Il2CppMethodInfo, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_006E:\n\tgoto L_0073;\n\tv69 = 0xB348B0(v61, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0073:\n\tgoto L_007F;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_007F:\n\tgoto L_0084;\n\tv92 = 0xB348B0(v82, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0084:\n\tv97 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v97, \"com.google.android.gms.ads.RequestConfiguration$Builder\", v94.Value);\n\tv117 = requestConfiguration.<MaxAdContentRating>k__BackingField == 0;\n\tif (v117) goto L_00B3;\n\t// 149 NewArr v271 @ X0_v84 (System.Object[]), typeof(System.Object[]), 1\n\tv312 = requestConfiguration.<MaxAdContentRating>k__BackingField;\n\tv449 = v312.<Value>k__BackingField == 0;\n\tif (v449) goto L_00A8;\n\t// 162 IsInst v405 @ X0_v89, typeof(System.Object), v312.<Value>k__BackingField (System.String)\n\tv410 = v405 == 0;\n\tif (v410) goto L_0208;\nL_00A8:\n\tv271[0] = v312.<Value>k__BackingField;\n\tv340 = UnityEngine.AndroidJavaObject::Call(v97, \"setMaxAdContentRating\", v271);\nL_00B3:\n\tv286 = requestConfiguration.<TestDeviceIds>k__BackingField;\n\tv140 = v286._size < 1;\n\tif (v140) goto L_00E3;\n\tv425 = GoogleMobileAds.Android.Utils::GetJavaListObject(v286);\n\t// 200 NewArr v273 @ X0_v77 (System.Object[]), typeof(System.Object[]), 1\n\tv551 = v425 == 0;\n\tif (v551) goto L_00D7;\n\t// 209 IsInst v406 @ X0_v82, typeof(System.Object), v425 @ X0_v75 (UnityEngine.AndroidJavaObject)\n\tv411 = v406 == 0;\n\tif (v411) goto L_0208;\nL_00D7:\n\tv273[0] = v425;\n\tv433 = UnityEngine.AndroidJavaObject::Call(v330, \"setTestDeviceIds\", v273);\nL_00E3:\n\tv439 = requestConfiguration.<TagForUnderAgeOfConsent>k__BackingField & 0xFF;\n\tv441 = v439 == 0;\n\tif (v441) goto L_015D;\n\tv451 = requestConfiguration.<TagForUnderAgeOfConsent>k__BackingField >> 0x20;\n\tv452 = v451 + 1;\n\tv182 = v452 == 0;\n\tif (v182) goto L_0110;\n\tv181 = v451 == 1;\n\tif (v181) goto L_011F;\n\tv552 = v451 == 0;\n\tv553 = ~v552;\n\tif (v553) goto L_0137;\n\tv275 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v275, \"com.google.android.gms.ads.RequestConfiguration\");\n\tgoto L_012F;\nL_0110:\n\tv276 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v276, \"com.google.android.gms.ads.RequestConfiguration\");\n\tgoto L_012F;\nL_011F:\n\tv277 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v277, \"com.google.android.gms.ads.RequestConfiguration\");\nL_012F:\n\tv668 = UnityEngine.AndroidJavaObject::GetStatic(v594, *([v661 @ X8_v62 (System.String)]));\n\tSystem.Nullable`1<System.Int32>::.ctor(&v136 @ stack_-48_v8 (System.Nullable`1<System.Int32>), v668);\nL_0137:\n\tv468 = 0 == 0;\n\tif (v468) goto L_015D;\n\t// 315 NewArr v618 @ X0_v61 (System.Object[]), typeof(System.Object[]), 1\n\t// 323 Box v278 @ X0_v63, typeof(System.Nullable`1<System.Int32>), &v136 @ stack_-48_v8 (System.Nullable`1<System.Int32>)\n\tv701 = v278 == 0;\n\tif (v701) goto L_0152;\n\t// 332 IsInst v407 @ X0_v68, typeof(System.Object), v278 @ X0_v63\n\tv412 = v407 == 0;\n\tif (v412) goto L_0208;\nL_0152:\n\tv618[0] = v278;\n\tv465 = UnityEngine.AndroidJavaObject::Call(v330, \"setTagForUnderAgeOfConsent\", v618);\nL_015D:\n\tv473 = requestConfiguration.<TagForChildDirectedTreatment>k__BackingField & 0xFF;\n\tv475 = v473 == 0;\n\tif (v475) goto L_01DA;\n\tv488 = requestConfiguration.<TagForChildDirectedTreatment>k__BackingField >> 0x20;\n\tv489 = v488 + 1;\n\tv185 = v489 == 0;\n\tif (v185) goto L_018A;\n\tv184 =\n// ... truncated")]
		public static AndroidJavaObject BuildRequestConfiguration(RequestConfiguration requestConfiguration)
		{
			//IL_0659: Unknown result type (might be due to invalid IL or missing references)
			//IL_065e: Expected I4, but got Unknown
			//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
			//IL_03f2: Expected I4, but got Unknown
			//IL_021e: Expected I4, but got O
			//IL_0422: Expected I4, but got O
			//IL_069f: Expected O, but got I
			//IL_06a7: Expected O, but got I4
			//IL_06d0: Expected O, but got I
			//IL_06d8: Expected O, but got I4
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.google.android.gms.ads.RequestConfiguration$Builder");
			bool flag = requestConfiguration.MaxAdContentRating == null;
			object[] array = Array.Empty<object>();
			string text = "com.google.android.gms.ads.RequestConfiguration$Builder";
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			if (!flag)
			{
				object[] array2 = new object[1];
				MaxAdContentRating maxAdContentRating = requestConfiguration.MaxAdContentRating;
				if (maxAdContentRating.Value != null)
				{
					object obj = maxAdContentRating.Value as object;
					if (obj == null)
					{
						goto IL_0626;
					}
				}
				array2[0] = maxAdContentRating.Value;
				object obj2 = androidJavaObject.Call<object>("setMaxAdContentRating", array2);
				array = array2;
				text = "setMaxAdContentRating";
				androidJavaObject2 = (AndroidJavaObject)obj2;
			}
			List<string> testDeviceIds = requestConfiguration.TestDeviceIds;
			if (testDeviceIds.Count >= 1)
			{
				AndroidJavaObject javaListObject = Utils.GetJavaListObject(testDeviceIds);
				object[] array3 = new object[1];
				if (javaListObject != null)
				{
					object obj3 = javaListObject as object;
					if (obj3 == null)
					{
						goto IL_0626;
					}
				}
				array3[0] = javaListObject;
				object obj4 = androidJavaObject2.Call<object>("setTestDeviceIds", array3);
				array = array3;
				text = "setTestDeviceIds";
				androidJavaObject2 = (AndroidJavaObject)obj4;
			}
			int? num2;
			if (((_003F?)requestConfiguration.TagForUnderAgeOfConsent & 0xFF) != 0)
			{
				int num = (object?)requestConfiguration.TagForUnderAgeOfConsent >> 32;
				AndroidJavaClass androidJavaClass2;
				string fieldName;
				if (num + 1 != 0)
				{
					if (num != 1)
					{
						bool flag2 = num == 0;
						bool flag3 = !flag2;
						num2 = null;
						if (flag3)
						{
							goto IL_0316;
						}
						AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.RequestConfiguration");
						androidJavaClass2 = androidJavaClass;
						fieldName = "TAG_FOR_UNDER_AGE_OF_CONSENT_FALSE";
					}
					else
					{
						AndroidJavaClass androidJavaClass3 = new AndroidJavaClass("com.google.android.gms.ads.RequestConfiguration");
						androidJavaClass2 = androidJavaClass3;
						fieldName = "TAG_FOR_UNDER_AGE_OF_CONSENT_TRUE";
					}
				}
				else
				{
					AndroidJavaClass androidJavaClass4 = new AndroidJavaClass("com.google.android.gms.ads.RequestConfiguration");
					androidJavaClass2 = androidJavaClass4;
					fieldName = "TAG_FOR_UNDER_AGE_OF_CONSENT_UNSPECIFIED";
				}
				int num3 = androidJavaClass2.GetStatic<int>(fieldName);
				num2 = num3;
				array = (object[])0;
				text = (string)num3;
				goto IL_0316;
			}
			goto IL_03df;
			IL_051a:
			int? num4;
			if (false)
			{
				object[] array4 = new object[1];
				object obj5 = num4;
				if (obj5 != null)
				{
					object obj6 = obj5 as object;
					if (obj6 == null)
					{
						goto IL_0626;
					}
				}
				array4[0] = obj5;
				object obj7 = androidJavaObject2.Call<object>("setTagForChildDirectedTreatment", array4);
				array = array4;
				text = "setTagForChildDirectedTreatment";
			}
			goto IL_060a;
			IL_03df:
			if (((_003F?)requestConfiguration.TagForChildDirectedTreatment & 0xFF) != 0)
			{
				int num5 = (object?)requestConfiguration.TagForChildDirectedTreatment >> 32;
				AndroidJavaClass androidJavaClass6;
				string fieldName2;
				if (num5 + 1 != 0)
				{
					if (num5 != 1)
					{
						bool flag4 = num5 == 0;
						bool flag5 = !flag4;
						num4 = null;
						if (flag5)
						{
							goto IL_051a;
						}
						AndroidJavaClass androidJavaClass5 = new AndroidJavaClass("com.google.android.gms.ads.RequestConfiguration");
						androidJavaClass6 = androidJavaClass5;
						fieldName2 = "TAG_FOR_CHILD_DIRECTED_TREATMENT_FALSE";
					}
					else
					{
						AndroidJavaClass androidJavaClass7 = new AndroidJavaClass("com.google.android.gms.ads.RequestConfiguration");
						androidJavaClass6 = androidJavaClass7;
						fieldName2 = "TAG_FOR_UNDER_AGE_OF_CONSENT_TRUE";
					}
				}
				else
				{
					AndroidJavaClass androidJavaClass8 = new AndroidJavaClass("com.google.android.gms.ads.RequestConfiguration");
					androidJavaClass6 = androidJavaClass8;
					fieldName2 = "TAG_FOR_UNDER_AGE_OF_CONSENT_UNSPECIFIED";
				}
				int num6 = androidJavaClass6.GetStatic<int>(fieldName2);
				num4 = num6;
				array = (object[])0;
				text = (string)num6;
				goto IL_051a;
			}
			goto IL_060a;
			IL_0626:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
			IL_060a:
			return (AndroidJavaObject)androidJavaObject2.Call<object>("build", Array.Empty<object>());
			IL_0316:
			if (false)
			{
				object[] array5 = new object[1];
				object obj8 = num2;
				if (obj8 != null)
				{
					object obj9 = obj8 as object;
					if (obj9 == null)
					{
						goto IL_0626;
					}
				}
				array5[0] = obj8;
				object obj10 = androidJavaObject2.Call<object>("setTagForUnderAgeOfConsent", array5);
				array = array5;
				text = "setTagForUnderAgeOfConsent";
			}
			goto IL_03df;
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x134A884", Offset = "0x134A884", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv86 = GoogleMobileAds.Api.RequestConfiguration+Builder;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv139 = Il2CppMethodInfo;\n\tv140 = \"il2cpp_codegen_initialize_runtime_metadata\"(v139, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv146 = \"getTagForChildDirectedTreatment\";\n\tv147 = \"il2cpp_codegen_initialize_runtime_metadata\"(v146, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv193 = \"getMaxAdContentRating\";\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv201 = \"getTagForUnderAgeOfConsent\";\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv214 = \"getTestDeviceIds\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v214, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A367E8]) = v48;\nL_003A:\n\tgoto L_0043;\n\tv57 = 0xB3490C(Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0043:\n\tgoto L_0048;\n\tv69 = 0xB348B0(v61, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0048:\n\tgoto L_0050;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v70, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0050:\n\tgoto L_005D;\n\tv88 = 0xB348B0(v80, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_005D:\n\tv103 = UnityEngine.AndroidJavaObject::Call(androidRequestConfiguration, \"getTagForChildDirectedTreatment\", v96.Value);\n\tgoto L_006C;\n\tv149 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getTagForChildDirectedTreatment\", v96.Value);\nL_006C:\n\tgoto L_0071;\n\tv195 = UnityEngine.AndroidJavaObject::Call(v153, v101, v100, v102);\nL_0071:\n\tgoto L_FFFFFFFF;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v196, v101, v100, v102, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_007D;\n\tv215 = UnityEngine.AndroidJavaObject::Call(v207, v101, v100, v102);\nL_007D:\n\tv217 = *([v216 @ X0_v17+B8]);\n\tv222 = UnityEngine.AndroidJavaObject::Call(androidRequestConfiguration, \"getTagForUnderAgeOfConsent\", *([v217 @ X8_v17]));\n\tgoto L_0091;\n\tv228 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getTagForUnderAgeOfConsent\", *([v217 @ X8_v17]));\nL_0091:\n\tgoto L_0096;\n\tv237 = UnityEngine.AndroidJavaObject::Call(v232, v218, v221, v219);\nL_0096:\n\tgoto L_FFFFFFFF;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v238, v218, v221, v219, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00A4;\n\tv254 = UnityEngine.AndroidJavaObject::Call(v247, v218, v221, v219);\nL_00A4:\n\tv256 = *([v255 @ X0_v25+B8]);\n\tv261 = UnityEngine.AndroidJavaObject::Call(androidRequestConfiguration, \"getMaxAdContentRating\", *([v256 @ X8_v24]));\n\tv262 = GoogleMobileAds.Api.MaxAdContentRating::ToMaxAdContentRating(v261);\n\tgoto L_00B9;\n\tv268 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getMaxAdContentRating\", *([v256 @ X8_v24]));\nL_00B9:\n\tgoto L_00BE;\n\tv277 = UnityEngine.AndroidJavaObject::Call(v272, v257, v260, v258);\nL_00BE:\n\tgoto L_FFFFFFFF;\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v278, v257, v260, v258, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00D0;\n\tv295 = UnityEngine.AndroidJavaObject::Call(v288, v257, v260, v258);\nL_00D0:\n\tv297 = *([v296 @ X0_v34+B8]);\n\tv301 = UnityEngine.AndroidJavaObject::Call(androidRequestConfiguration, \"getTestDeviceIds\", *([v297 @ X8_v31]));\n\tv302 = GoogleMobileAds.Android.Utils::GetCsTypeList(v301);\n\tv304 = new GoogleMobileAds.Api.RequestConfiguration+Builder();\n\tGoogleMobileAds.Api.RequestConfiguration+Builder::.ctor(v304);\n\tv106 = 0;\n\tSystem.Nullable`1<System.Int32Enum>::.ctor(&v106 @ stack_-48_v2 (System.Nullable`1<System.Int32Enum>), v103);\n\tv304.<TagForChildDirectedTreatment>k__BackingField = 0;\n\tv161 = 0;\n\tSystem.Nullable`1<System.Int32Enum>::.ctor(&v161 @ stack_-58_v1 (System.Nullable`1<System.Int32Enum>), v222);\n\tv304.<MaxAdContentRating>k__BackingField = v262;\n\tv304.<TagForUnderAgeOfConsent>k__BackingField = 0;\n\tv304.<TestDeviceIds>k__BackingField = v302;\n\treturnVal2 = GoogleMobileAds.Api.RequestConfiguration+Builder::build(v304);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static RequestConfiguration GetRequestConfiguration(AndroidJavaObject androidRequestConfiguration)
		{
			//IL_005f: Expected O, but got I
			//IL_0074: Expected O, but got I
			//IL_00b3: Expected O, but got I
			//IL_00c8: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_012e: Expected O, but got I
			int value = androidRequestConfiguration.Call<int>("getTagForChildDirectedTreatment", Array.Empty<object>());
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v17+B8]");
			object args = 0;
			int value2 = androidRequestConfiguration.Call<int>("getTagForUnderAgeOfConsent", (object[])args);
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ X0_v25+B8]");
			object args2 = 0;
			object value3 = androidRequestConfiguration.Call<object>("getMaxAdContentRating", (object[])args2);
			MaxAdContentRating _003CMaxAdContentRating_003Ek__BackingField = MaxAdContentRating.ToMaxAdContentRating((string)value3);
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v296 @ X0_v34+B8]");
			object args3 = 0;
			object javaTypeList = androidRequestConfiguration.Call<object>("getTestDeviceIds", (object[])args3);
			List<string> csTypeList = Utils.GetCsTypeList((AndroidJavaObject)javaTypeList);
			RequestConfiguration.Builder builder = new RequestConfiguration.Builder();
			System.Int32Enum? int32Enum = null;
			int32Enum = (System.Int32Enum)value;
			builder.TagForChildDirectedTreatment = null;
			System.Int32Enum? int32Enum2 = null;
			int32Enum2 = (System.Int32Enum)value2;
			builder.MaxAdContentRating = _003CMaxAdContentRating_003Ek__BackingField;
			builder.TagForUnderAgeOfConsent = null;
			builder.TestDeviceIds = csTypeList;
			return builder.build();
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x134B598", Offset = "0x134B598", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RequestConfigurationClient()
		{
		}
	}
}
