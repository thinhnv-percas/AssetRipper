using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace com.adjust.sdk
{
	[Token(Token = "0x200000A")]
	public class AdjustAndroid
	{
		[Token(Token = "0x200001E")]
		private class AttributionChangeListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000A6")]
			[FieldOffset(Offset = "0x20")]
			private Action<AdjustAttribution> callback;

			[Token(Token = "0x6000162")]
			[Address(RVA = "0x156A1D8", Offset = "0x156A1D8", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDB080]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290A3]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnAttributionChangedListener\");\n\tthis.callback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AttributionChangeListener(Action<AdjustAttribution> pCallback)
				: base("com.adjust.sdk.OnAttributionChangedListener")
			{
				callback = pCallback;
			}

			[Token(Token = "0x6000163")]
			[Address(RVA = "0x156B21C", Offset = "0x156B21C", Length = "0x4AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EC9840]);\n\tv29 = *([v28 @ X8_v93]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, attribution, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20290A4]) = v47;\nL_0019:\n\tv49 = this.callback == 0;\n\tif (v49) goto L_0197;\n\tv53 = new com.adjust.sdk.AdjustAttribution();\n\tSystem.Object::.ctor(v53);\n\tgoto L_0037;\n\tv103 = *([v99 @ X0_v4+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\t// 44 ConditionalJump @b10, v105 @ TEMP_v121\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v99, v62, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0037:\n\tv118 = UnityEngine.AndroidJavaObject::Get(attribution, v114.KeyTrackerName);\n\tv136 = System.String::op_Equality(v118, \"\");\n\tv144 = v136 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0055;\n\tgoto L_0052;\n\tv156 = *([v146 @ X0_v121 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_0052;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v146, v135, v134, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv160 = com.adjust.sdk.AdjustUtils;\nL_0052:\n\tv127 = UnityEngine.AndroidJavaObject::Get(attribution, v155.KeyTrackerName);\nL_0055:\n\tv53.<trackerName>k__BackingField = v127;\n\tgoto L_0065;\n\tv168 = *([v163 @ X0_v15 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0065;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v163, v125, v122, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv172 = com.adjust.sdk.AdjustUtils;\nL_0065:\n\tv179 = UnityEngine.AndroidJavaObject::Get(attribution, v175.KeyTrackerToken);\n\tv183 = System.String::op_Equality(v179, \"\");\n\tv187 = v183 == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_007F;\n\tgoto L_007E;\n\tv207 = *([v189 @ X0_v113 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_007E;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v189, v181, v182, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv211 = com.adjust.sdk.AdjustUtils;\nL_007E:\n\tv197 = UnityEngine.AndroidJavaObject::Get(attribution, v202.KeyTrackerToken);\nL_007F:\n\tv53.<trackerToken>k__BackingField = v197;\n\tgoto L_008F;\n\tv214 = *([v203 @ X0_v22 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_008F;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v203, v195, v193, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv218 = com.adjust.sdk.AdjustUtils;\nL_008F:\n\tv225 = UnityEngine.AndroidJavaObject::Get(attribution, v221.KeyNetwork);\n\tv230 = System.String::op_Equality(v225, \"\");\n\tv234 = v230 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_00A9;\n\tgoto L_00A8;\n\tv254 = *([v236 @ X0_v105 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv255 = v254 == 0;\n\tv256 = ~v255;\n\tif (v256) goto L_00A8;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v236, v228, v229, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv258 = com.adjust.sdk.AdjustUtils;\nL_00A8:\n\tv244 = UnityEngine.AndroidJavaObject::Get(attribution, v249.KeyNetwork);\nL_00A9:\n\tv53.<network>k__BackingField = v244;\n\tgoto L_00B9;\n\tv261 = *([v250 @ X0_v29 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv262 = v261 == 0;\n\tv263 = ~v262;\n\tif (v263) goto L_00B9;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v250, v242, v240, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv265 = com.adjust.sdk.AdjustUtils;\nL_00B9:\n\tv272 = UnityEngine.AndroidJavaObject::Get(attribution, v268.KeyCampaign);\n\tv277 = System.String::op_Equality(v272, \"\");\n\tv281 = v277 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_00D3;\n\tgoto L_00D2;\n\tv301 = *([v283 @ X0_v97 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv302 = v301 == 0;\n\tv303 = ~v302;\n\tif (v303) goto L_00D2;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v283, v275, v276, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv305 = com.adjust.sdk.AdjustUtils;\nL_00D2:\n\tv291 = UnityEngine.AndroidJavaObject::Get(attribution, v296.KeyCampaign);\nL_00D3:\n\tv53.<campaign>k__BackingField = v291;\n\tgoto L_00E3;\n\tv308 = *([v297 @ X0_v36 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv309 = v308 == 0;\n\tv310 = ~v309;\n\tif (v310) goto L_00E3;\n\tv321 = \"il2cpp_codegen_runtime_class_init\"(v297, v289, v287, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv312 = com.adjust.sdk.AdjustUtils;\nL_00E3:\n\tv319 = UnityEngine.AndroidJavaObject::Get(attribution, v315.KeyAdgroup);\n\tv324 = System.String::op_Equality(v319, \"\");\n\tv328 = v324 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_00FD;\n\tgoto L_00FC;\n\tv348 = *([v330 @ X0_v89 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv349 = v348 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_00FC;\n\tv367 = \"il2cpp_codegen_runtime_class_init\"(v330, v322, v323, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv352 = com.adjust.sdk.AdjustUtils;\nL_00FC:\n\tv338 = UnityEngine.AndroidJavaObject::Get(attribution, v343.KeyAdgroup);\nL_00FD:\n\tv53.<adgroup>k__BackingField = v338;\n\tgoto L_010D;\n\tv355 = *([v344 @ X0_v43 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv356 = v355 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_010D;\n\tv368 = \"il2cpp_codegen_runtime_class_init\"(v344, v336, v334, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv359 = com.adjust.sdk.AdjustUtils;\nL_010D:\n\tv366 = UnityEngine.AndroidJavaObject::Get(attribution, v362.KeyCreative);\n\tv371 = System.String::op_Equality(v366, \"\");\n\tv375 = v371 == 0;\n\tv376 = ~v375;\n\tif (v376) goto L_0127;\n\tgoto L_0126;\n\tv395 = *([v377 @ X0_v81 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv396 = v395 == 0;\n\tv397 = ~v396;\n\tif (v397) goto L_0126;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v377, v369, v370, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv399 = com.adjust.sdk.AdjustUtils;\nL_0126:\n\tv385 = UnityEngine.AndroidJavaObject::Get(attribution, v390.KeyCreative);\nL_0127:\n\tv53.<creative>k__BackingField = v385;\n\tgoto L_0137;\n\tv402 = *([v391 @ X0_v50 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv403 = v402 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_0137;\n\tv415 = \"il2cpp_codegen_runtime_class_init\"(v391, v383, v381, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv406 = com.adjust.sdk.AdjustUtils;\nL_0137:\n\tv413 = UnityEngine.AndroidJavaObject::Get(attribution, v409.KeyClickLabel);\n\tv418 = System.String::op_Equality(v413, \"\");\n\tv422 = v418 == 0;\n\tv423 = ~v422;\n\tif (v423) goto L_0151;\n\tgoto L_0150;\n\tv442 = *([v424 @ X0_v73 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv443 = v442 == 0;\n\tv444 = ~v443;\n\tif (v444) goto L_0150;\n\tv461 = \"il2cpp_codegen_runtime_class_init\"(v424, v416, v417, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv446 = com.adjust.sdk.AdjustUtils;\nL_0150:\n\tv432 = UnityEngine.AndroidJavaObject::Get(attribution, v437.KeyClickLabel);\nL_0151:\n\tv53.<clickLabel>k__BackingField = v432;\n\tgoto L_0161;\n\tv449 = *([v438 @ X0_v57 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv450 = v449 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_0161;\n\tv462 = \"il2cpp_codegen_runtime_class_init\"(v438, v430, v428, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv453 = com.adjust.sdk.AdjustUtils;\nL_0161:\n\tv460 = UnityEngine.AndroidJavaObject::Get(attribution, v456.KeyAdid);\n\tv465 = System.String::op_Equality(v460, \"\");\n\tv469 = v465 == 0;\n\tv470 = ~v469;\n\tif (v470) goto L_017B;\n\tgoto L_017A;\n\tv482 = *([v471 @ X0_v65 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv483 = v482 == 0;\n\tv484 = ~v483;\n\tif (v484) goto L_017A;\n\tv490 = \"il2cpp_codegen_runtime_class_init\"(v471, v463, v464, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv486 = com.adjust.sdk.AdjustUtils;\nL_017A:\n\tv477 = UnityEngine.AndroidJavaObject::Get(attribution, v481.KeyAdid);\nL_017B:\n\tv53.<adid>k__BackingField = v477;\n\tSystem.Action`1<com.adjust.sdk.AdjustAttribution>::Invoke(this.callback, v53);\n\treturn;\nL_0197:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 229 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onAttributionChanged(AndroidJavaObject attribution)
			{
				if (callback != null)
				{
					AdjustAttribution adjustAttribution = new AdjustAttribution();
					string text = attribution.Get<string>(AdjustUtils.KeyTrackerName);
					bool flag = text == "";
					bool flag2 = !flag;
					bool flag3 = !flag2;
					string trackerName = null;
					if (!flag3)
					{
						trackerName = attribution.Get<string>(AdjustUtils.KeyTrackerName);
					}
					adjustAttribution.trackerName = trackerName;
					string text2 = attribution.Get<string>(AdjustUtils.KeyTrackerToken);
					bool flag4 = text2 == "";
					bool flag5 = !flag4;
					bool flag6 = !flag5;
					string trackerToken = null;
					if (!flag6)
					{
						trackerToken = attribution.Get<string>(AdjustUtils.KeyTrackerToken);
					}
					adjustAttribution.trackerToken = trackerToken;
					string text3 = attribution.Get<string>(AdjustUtils.KeyNetwork);
					bool flag7 = text3 == "";
					bool flag8 = !flag7;
					bool flag9 = !flag8;
					string network = null;
					if (!flag9)
					{
						network = attribution.Get<string>(AdjustUtils.KeyNetwork);
					}
					adjustAttribution.network = network;
					string text4 = attribution.Get<string>(AdjustUtils.KeyCampaign);
					bool flag10 = text4 == "";
					bool flag11 = !flag10;
					bool flag12 = !flag11;
					string campaign = null;
					if (!flag12)
					{
						campaign = attribution.Get<string>(AdjustUtils.KeyCampaign);
					}
					adjustAttribution.campaign = campaign;
					string text5 = attribution.Get<string>(AdjustUtils.KeyAdgroup);
					bool flag13 = text5 == "";
					bool flag14 = !flag13;
					bool flag15 = !flag14;
					string adgroup = null;
					if (!flag15)
					{
						adgroup = attribution.Get<string>(AdjustUtils.KeyAdgroup);
					}
					adjustAttribution.adgroup = adgroup;
					string text6 = attribution.Get<string>(AdjustUtils.KeyCreative);
					bool flag16 = text6 == "";
					bool flag17 = !flag16;
					bool flag18 = !flag17;
					string creative = null;
					if (!flag18)
					{
						creative = attribution.Get<string>(AdjustUtils.KeyCreative);
					}
					adjustAttribution.creative = creative;
					string text7 = attribution.Get<string>(AdjustUtils.KeyClickLabel);
					bool flag19 = text7 == "";
					bool flag20 = !flag19;
					bool flag21 = !flag20;
					string clickLabel = null;
					if (!flag21)
					{
						clickLabel = attribution.Get<string>(AdjustUtils.KeyClickLabel);
					}
					adjustAttribution.clickLabel = clickLabel;
					string text8 = attribution.Get<string>(AdjustUtils.KeyAdid);
					bool flag22 = text8 == "";
					bool flag23 = !flag22;
					bool flag24 = !flag23;
					string adid = null;
					if (!flag24)
					{
						adid = attribution.Get<string>(AdjustUtils.KeyAdid);
					}
					adjustAttribution.adid = adid;
					callback(adjustAttribution);
				}
			}
		}

		[Token(Token = "0x200001F")]
		private class DeferredDeeplinkListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000A7")]
			[FieldOffset(Offset = "0x20")]
			private Action<string> callback;

			[Token(Token = "0x6000164")]
			[Address(RVA = "0x156A480", Offset = "0x156A480", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEE238]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290A5]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnDeeplinkResponseListener\");\n\tthis.callback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public DeferredDeeplinkListener(Action<string> pCallback)
				: base("com.adjust.sdk.OnDeeplinkResponseListener")
			{
				callback = pCallback;
			}

			[Token(Token = "0x6000165")]
			[Address(RVA = "0x156B6C8", Offset = "0x156B6C8", Length = "0x160")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F03078]);\n\tv25 = *([v24 @ X8_v33]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, deeplink, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290A6]) = v43;\nL_0017:\n\tv45 = this.callback == 0;\n\tif (v45) goto L_0065;\n\tv50 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0026;\n\tv82 = v50;\n\tv83 = 0x8907BC(v82, deeplink, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv86 = *([v50 @ X21_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0026:\n\tv87 = *([v50 @ X21_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv88 = v87 == 0;\n\tif (v88) goto L_0047;\n\tv108 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0033;\n\tv151 = v108;\n\tv152 = 0x8907BC(v151, deeplink, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0033:\n\tv153 = *([v108 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv118 = ~v153;\n\tif (v118) goto L_0047;\n\tgoto L_0047;\n\tv171 = v123;\n\tv172 = 0x8907BC(v171, deeplink, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0047:\n\tgoto L_0055;\n\tv154 = v75;\n\tv155 = 0x8907BC(v154, deeplink, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0055:\n\tv168 = UnityEngine.AndroidJavaObject::Call(deeplink, \"toString\", v163.Value);\n\tSystem.Action`1<System.String>::Invoke(this.callback, v168);\nL_0065:\n\tgoto L_0077;\n\tv89 = *([v78 @ X0_v3+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0077;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v78, v57, v59, v55, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0077:\n\treturn v103.launchDeferredDeeplink;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool launchReceivedDeeplink(AndroidJavaObject deeplink)
			{
				if (callback != null)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X21_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					string obj = deeplink.Call<string>("toString", Array.Empty<object>());
					callback(obj);
				}
				return launchDeferredDeeplink;
			}
		}

		[Token(Token = "0x2000020")]
		private class EventTrackingSucceededListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000A8")]
			[FieldOffset(Offset = "0x20")]
			private Action<AdjustEventSuccess> callback;

			[Token(Token = "0x6000166")]
			[Address(RVA = "0x156A260", Offset = "0x156A260", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EFFAE0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290AC]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnEventTrackingSucceededListener\");\n\tthis.callback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public EventTrackingSucceededListener(Action<AdjustEventSuccess> pCallback)
				: base("com.adjust.sdk.OnEventTrackingSucceededListener")
			{
				callback = pCallback;
			}

			[Token(Token = "0x6000167")]
			[Address(RVA = "0x156BF88", Offset = "0x156BF88", Length = "0x4BC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EC1348]);\n\tv29 = *([v28 @ X8_v86]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, eventSuccessData, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20290AD]) = v47;\nL_0018:\n\tv48 = eventSuccessData == 0;\n\tif (v48) goto L_016C;\n\tv50 = this.callback == 0;\n\tif (v50) goto L_016C;\n\tv64 = new com.adjust.sdk.AdjustEventSuccess();\n\tSystem.Object::.ctor(v64);\n\tgoto L_0037;\n\tv155 = *([v151 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0037;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v151, v148, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv159 = com.adjust.sdk.AdjustUtils;\nL_0037:\n\tv168 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v163.KeyAdid);\n\tv173 = System.String::op_Equality(v168, \"\");\n\tv177 = v173 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0055;\n\tgoto L_0052;\n\tv194 = *([v179 @ X0_v117 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0052;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v179, v172, v171, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv198 = com.adjust.sdk.AdjustUtils;\nL_0052:\n\tv187 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v192.KeyAdid);\nL_0055:\n\tv64.<Adid>k__BackingField = v187;\n\tgoto L_0065;\n\tv208 = *([v201 @ X0_v33 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0065;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v201, v185, v183, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv212 = com.adjust.sdk.AdjustUtils;\nL_0065:\n\tv219 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v215.KeyMessage);\n\tv250 = System.String::op_Equality(v219, \"\");\n\tv281 = v250 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_007F;\n\tgoto L_007E;\n\tv303 = *([v283 @ X0_v109 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_007E;\n\tv334 = \"il2cpp_codegen_runtime_class_init\"(v283, v248, v249, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv307 = com.adjust.sdk.AdjustUtils;\nL_007E:\n\tv291 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v296.KeyMessage);\nL_007F:\n\tv64.<Message>k__BackingField = v291;\n\tgoto L_008F;\n\tv310 = *([v297 @ X0_v40 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_008F;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v297, v289, v287, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv314 = com.adjust.sdk.AdjustUtils;\nL_008F:\n\tv321 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v317.KeyTimestamp);\n\tv338 = System.String::op_Equality(v321, \"\");\n\tv348 = v338 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_00A9;\n\tgoto L_00A8;\n\tv372 = *([v351 @ X0_v101 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv373 = v372 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_00A8;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v351, v336, v337, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv376 = com.adjust.sdk.AdjustUtils;\nL_00A8:\n\tv359 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v364.KeyTimestamp);\nL_00A9:\n\tv64.<Timestamp>k__BackingField = v359;\n\tgoto L_00B9;\n\tv379 = *([v365 @ X0_v47 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_00B9;\n\tv394 = \"il2cpp_codegen_runtime_class_init\"(v365, v357, v355, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv383 = com.adjust.sdk.AdjustUtils;\nL_00B9:\n\tv390 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v386.KeyEventToken);\n\tv397 = System.String::op_Equality(v390, \"\");\n\tv410 = v397 == 0;\n\tv411 = ~v410;\n\tif (v411) goto L_00D3;\n\tgoto L_00D2;\n\tv431 = *([v413 @ X0_v93 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv432 = v431 == 0;\n\tv433 = ~v432;\n\tif (v433) goto L_00D2;\n\tv450 = \"il2cpp_codegen_runtime_class_init\"(v413, v395, v396, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv435 = com.adjust.sdk.AdjustUtils;\nL_00D2:\n\tv421 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v426.KeyEventToken);\nL_00D3:\n\tv64.<EventToken>k__BackingField = v421;\n\tgoto L_00E3;\n\tv438 = *([v427 @ X0_v54 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv439 = v438 == 0;\n\tv440 = ~v439;\n\tif (v440) goto L_00E3;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v427, v419, v417, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv442 = com.adjust.sdk.AdjustUtils;\nL_00E3:\n\tv449 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v445.KeyCallbackId);\n\tv454 = System.String::op_Equality(v449, \"\");\n\tv458 = v454 == 0;\n\tv459 = ~v458;\n\tif (v459) goto L_00FD;\n\tgoto L_00FC;\n\tv478 = *([v460 @ X0_v85 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv479 = v478 == 0;\n\tv480 = ~v479;\n\tif (v480) goto L_00FC;\n\tv496 = \"il2cpp_codegen_runtime_class_init\"(v460, v452, v453, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv482 = com.adjust.sdk.AdjustUtils;\nL_00FC:\n\tv468 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v473.KeyCallbackId);\nL_00FD:\n\tv64.<CallbackId>k__BackingField = v468;\n\tgoto L_010F;\n\tv485 = *([v474 @ X0_v61 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv486 = v485 == 0;\n\tv487 = ~v486;\n\tif (v487) goto L_010F;\n\tv497 = \"il2cpp_codegen_runtime_class_init\"(v474, v466, v464, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv489 = com.adjust.sdk.AdjustUtils;\nL_010F:\n\tv495 = UnityEngine.AndroidJavaObject::Get(eventSuccessData, v492.KeyJsonResponse);\n\tv501 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_011E;\n\tv506 = v501;\n\tv507 = UnityEngine.AndroidJavaObject::Get(v506, v267, v264);\n\tv510 = *([v501 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_011E:\n\tv511 = *([v501 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv512 = v511 == 0;\n\tif (v512) goto L_013F;\n\tv514 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_012B;\n\tv534 = v514;\n\tv535 = UnityEngine.AndroidJavaObject::Get(v534, v267, v264);\nL_012B:\n\tv536 = *([v514 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv526 = ~v536;\n\tif (v526) goto L_013F;\n\tgoto L_013F;\n\tv547 = v520;\n\tv548 = UnityEngine.AndroidJavaObject::Get(v547, v267, v264);\nL_013F:\n\tgoto L_0142;\n\tv537 = v265;\n\tv538 = UnityEngine.AndroidJavaObject::Get(v537, v267, v264);\nL_0142:\n\tv271 = v495 == 0;\n\tif (v271) goto L_0171;\n\tv546 = UnityEngine.AndroidJavaObject::Call(v495, \"toString\", v406.Value);\n\tcom.adjust.sdk.AdjustEventSuccess::BuildJsonResponseFromString(v64, v546);\nL_0161:\n\tSystem.Action`1<com.adjust.sdk.AdjustEventSuccess>::Invoke(this.callback, v64);\n\treturn;\nL_016C:\n\treturn;\n\tv206 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0171:\n\tv277 = new System.NullReferenceException();\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_0180;\n\tgoto L_0180;\nL_0180:\n\tv68 = v128 != 1;\n\tif (v68) goto L_019B;\n\tv323 = UnityEngine.AndroidJavaObject::Get(v277, v128);\n\tv341 = *([v323 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv344 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v341 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]), v119, v105, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv350 = v344 & 1;\n\tv329 = v350 == 0;\n\tif (v329) goto L_0191;\n\tv369 = UnityEngine.AndroidJavaObject::Get(v344, *([v341 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\tgoto L_0161;\nL_0191:\n\tv371 = UnityEngine.AndroidJavaObject::Get(8, *([v341 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\t*([v371 @ X0_v23 (UnityEngine.AndroidJavaObject)]) = *([v323 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv128 = 0x1E8A000 + 0x870;\n\tv392 = UnityEngine.AndroidJavaObject::Get(v371, v128);\n\tv328 = UnityEngine.AndroidJavaObject::Get(v392, v128);\nL_019B:\n\tv333 = UnityEngine.AndroidJavaObject::Get(v139, v128);\n\tv131 = UnityEngine.AndroidJavaObject::Get(v333, v128);\n\treturn;\n// 236 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onFinishedEventTrackingSucceeded(AndroidJavaObject eventSuccessData)
			{
				//IL_0196: Expected I, but got O
				//IL_01fa: Expected O, but got I
				//IL_01fa: Expected O, but got I4
				//IL_0215: Expected O, but got I4
				//IL_01e3: Expected O, but got I
				if (eventSuccessData == null || callback == null)
				{
					return;
				}
				AdjustEventSuccess adjustEventSuccess = new AdjustEventSuccess();
				string text = eventSuccessData.Get<string>(AdjustUtils.KeyAdid);
				bool flag = text == "";
				bool flag2 = !flag;
				bool flag3 = !flag2;
				string adid = null;
				if (!flag3)
				{
					adid = eventSuccessData.Get<string>(AdjustUtils.KeyAdid);
				}
				adjustEventSuccess.Adid = adid;
				string text2 = eventSuccessData.Get<string>(AdjustUtils.KeyMessage);
				bool flag4 = text2 == "";
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				string message = null;
				if (!flag6)
				{
					message = eventSuccessData.Get<string>(AdjustUtils.KeyMessage);
				}
				adjustEventSuccess.Message = message;
				string text3 = eventSuccessData.Get<string>(AdjustUtils.KeyTimestamp);
				bool flag7 = text3 == "";
				bool flag8 = !flag7;
				bool flag9 = !flag8;
				string timestamp = null;
				if (!flag9)
				{
					timestamp = eventSuccessData.Get<string>(AdjustUtils.KeyTimestamp);
				}
				adjustEventSuccess.Timestamp = timestamp;
				string text4 = eventSuccessData.Get<string>(AdjustUtils.KeyEventToken);
				bool flag10 = text4 == "";
				bool flag11 = !flag10;
				bool flag12 = !flag11;
				string eventToken = null;
				if (!flag12)
				{
					eventToken = eventSuccessData.Get<string>(AdjustUtils.KeyEventToken);
				}
				adjustEventSuccess.EventToken = eventToken;
				string text5 = eventSuccessData.Get<string>(AdjustUtils.KeyCallbackId);
				bool flag13 = text5 == "";
				bool flag14 = !flag13;
				bool flag15 = !flag14;
				string callbackId = null;
				if (!flag15)
				{
					callbackId = eventSuccessData.Get<string>(AdjustUtils.KeyCallbackId);
				}
				adjustEventSuccess.CallbackId = callbackId;
				AndroidJavaObject androidJavaObject = eventSuccessData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v501 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (androidJavaObject != null)
				{
					string jsonResponseString = androidJavaObject.Call<string>("toString", Array.Empty<object>());
					adjustEventSuccess.BuildJsonResponseFromString(jsonResponseString);
					goto IL_0136;
				}
				NullReferenceException ex = new NullReferenceException();
				string text6 = default(string);
				bool flag16 = (IntPtr)text6 != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag16)
				{
					AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)(object)ex).Get<AndroidJavaObject>(text6);
					IntPtr intPtr3 = (IntPtr)androidJavaObject2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					AndroidJavaObject androidJavaObject3 = default(AndroidJavaObject);
					if ((uint)((ulong)(long)(IntPtr)androidJavaObject3 & 1uL) != 0)
					{
						AndroidJavaObject androidJavaObject4 = androidJavaObject3.Get<AndroidJavaObject>((string)(long)intPtr3);
						goto IL_0136;
					}
					AndroidJavaObject androidJavaObject5 = ((AndroidJavaObject)8).Get<AndroidJavaObject>((string)(long)intPtr3);
					androidJavaObject5 = androidJavaObject2;
					text6 = (string)(32022528 + 2160);
					NullReferenceException ex3 = (NullReferenceException)(object)androidJavaObject5.Get<AndroidJavaObject>(text6);
					AndroidJavaObject androidJavaObject6 = ((AndroidJavaObject)(object)ex3).Get<AndroidJavaObject>(text6);
					ex2 = ex3;
				}
				AndroidJavaObject androidJavaObject7 = ((AndroidJavaObject)(object)ex2).Get<AndroidJavaObject>(text6);
				AndroidJavaObject androidJavaObject8 = androidJavaObject7.Get<AndroidJavaObject>(text6);
				return;
				IL_0136:
				callback(adjustEventSuccess);
			}
		}

		[Token(Token = "0x2000021")]
		private class EventTrackingFailedListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000A9")]
			[FieldOffset(Offset = "0x20")]
			private Action<AdjustEventFailure> callback;

			[Token(Token = "0x6000168")]
			[Address(RVA = "0x156A2E8", Offset = "0x156A2E8", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDB008]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290AA]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnEventTrackingFailedListener\");\n\tthis.callback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public EventTrackingFailedListener(Action<AdjustEventFailure> pCallback)
				: base("com.adjust.sdk.OnEventTrackingFailedListener")
			{
				callback = pCallback;
			}

			[Token(Token = "0x6000169")]
			[Address(RVA = "0x156B9AC", Offset = "0x156B9AC", Length = "0x4E4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EB0028]);\n\tv29 = *([v28 @ X8_v89]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, eventFailureData, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20290AB]) = v47;\nL_0018:\n\tv48 = eventFailureData == 0;\n\tif (v48) goto L_0176;\n\tv50 = this.callback == 0;\n\tif (v50) goto L_0176;\n\tv64 = new com.adjust.sdk.AdjustEventFailure();\n\tSystem.Object::.ctor(v64);\n\tgoto L_0037;\n\tv155 = *([v151 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0037;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v151, v148, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv159 = com.adjust.sdk.AdjustUtils;\nL_0037:\n\tv168 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v163.KeyAdid);\n\tv173 = System.String::op_Equality(v168, \"\");\n\tv177 = v173 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0055;\n\tgoto L_0052;\n\tv194 = *([v179 @ X0_v119 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0052;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v179, v172, v171, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv198 = com.adjust.sdk.AdjustUtils;\nL_0052:\n\tv187 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v192.KeyAdid);\nL_0055:\n\tv64.<Adid>k__BackingField = v187;\n\tgoto L_0065;\n\tv208 = *([v201 @ X0_v33 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0065;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v201, v185, v183, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv212 = com.adjust.sdk.AdjustUtils;\nL_0065:\n\tv219 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v215.KeyMessage);\n\tv250 = System.String::op_Equality(v219, \"\");\n\tv281 = v250 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_007F;\n\tgoto L_007E;\n\tv303 = *([v283 @ X0_v111 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_007E;\n\tv336 = \"il2cpp_codegen_runtime_class_init\"(v283, v248, v249, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv307 = com.adjust.sdk.AdjustUtils;\nL_007E:\n\tv291 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v296.KeyMessage);\nL_007F:\n\tv64.<Message>k__BackingField = v291;\n\tgoto L_0091;\n\tv310 = *([v297 @ X0_v40 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_0091;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v297, v289, v287, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv314 = com.adjust.sdk.AdjustUtils;\nL_0091:\n\tv323 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v318.KeyWillRetry);\n\tv64.<WillRetry>k__BackingField = v323;\n\tv344 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v342.KeyTimestamp);\n\tv353 = System.String::op_Equality(v344, \"\");\n\tv358 = v353 == 0;\n\tv359 = ~v358;\n\tif (v359) goto L_00B3;\n\tgoto L_00B2;\n\tv383 = *([v363 @ X0_v103 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_00B2;\n\tv411 = \"il2cpp_codegen_runtime_class_init\"(v363, v351, v352, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv387 = com.adjust.sdk.AdjustUtils;\nL_00B2:\n\tv371 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v376.KeyTimestamp);\nL_00B3:\n\tv64.<Timestamp>k__BackingField = v371;\n\tgoto L_00C3;\n\tv390 = *([v377 @ X0_v49 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv391 = v390 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00C3;\n\tv412 = \"il2cpp_codegen_runtime_class_init\"(v377, v369, v367, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv394 = com.adjust.sdk.AdjustUtils;\nL_00C3:\n\tv401 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v397.KeyEventToken);\n\tv415 = System.String::op_Equality(v401, \"\");\n\tv420 = v415 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_00DD;\n\tgoto L_00DC;\n\tv440 = *([v422 @ X0_v95 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv441 = v440 == 0;\n\tv442 = ~v441;\n\tif (v442) goto L_00DC;\n\tv459 = \"il2cpp_codegen_runtime_class_init\"(v422, v413, v414, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv444 = com.adjust.sdk.AdjustUtils;\nL_00DC:\n\tv430 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v435.KeyEventToken);\nL_00DD:\n\tv64.<EventToken>k__BackingField = v430;\n\tgoto L_00ED;\n\tv447 = *([v436 @ X0_v56 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_00ED;\n\tv460 = \"il2cpp_codegen_runtime_class_init\"(v436, v428, v426, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv451 = com.adjust.sdk.AdjustUtils;\nL_00ED:\n\tv458 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v454.KeyCallbackId);\n\tv463 = System.String::op_Equality(v458, \"\");\n\tv467 = v463 == 0;\n\tv468 = ~v467;\n\tif (v468) goto L_0107;\n\tgoto L_0106;\n\tv487 = *([v469 @ X0_v87 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv488 = v487 == 0;\n\tv489 = ~v488;\n\tif (v489) goto L_0106;\n\tv505 = \"il2cpp_codegen_runtime_class_init\"(v469, v461, v462, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv491 = com.adjust.sdk.AdjustUtils;\nL_0106:\n\tv477 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v482.KeyCallbackId);\nL_0107:\n\tv64.<CallbackId>k__BackingField = v477;\n\tgoto L_0119;\n\tv494 = *([v483 @ X0_v63 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv495 = v494 == 0;\n\tv496 = ~v495;\n\tif (v496) goto L_0119;\n\tv506 = \"il2cpp_codegen_runtime_class_init\"(v483, v475, v473, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv498 = com.adjust.sdk.AdjustUtils;\nL_0119:\n\tv504 = UnityEngine.AndroidJavaObject::Get(eventFailureData, v501.KeyJsonResponse);\n\tv510 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0128;\n\tv515 = v510;\n\tv516 = UnityEngine.AndroidJavaObject::Get(v515, v267, v264);\n\tv519 = *([v510 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0128:\n\tv520 = *([v510 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv521 = v520 == 0;\n\tif (v521) goto L_0149;\n\tv523 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0135;\n\tv543 = v523;\n\tv544 = UnityEngine.AndroidJavaObject::Get(v543, v267, v264);\nL_0135:\n\tv545 = *([v523 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv535 = ~v545;\n\tif (v535) goto L_0149;\n\tgoto L_0149;\n\tv556 = v529;\n\tv557 = UnityEngine.AndroidJavaObject::Get(v556, v267, v264);\nL_0149:\n\tgoto L_014C;\n\tv546 = v265;\n\tv547 = UnityEngine.AndroidJavaObject::Get(v546, v267, v264);\nL_014C:\n\tv271 = v504 == 0;\n\tif (v271) goto L_017B;\n\tv555 = UnityEngine.AndroidJavaObject::Call(v504, \"toString\", v410.Value);\n\tcom.adjust.sdk.AdjustEventFailure::BuildJsonResponseFromString(v64, v555);\nL_016B:\n\tSystem.Action`1<com.adjust.sdk.AdjustEventFailure>::Invoke(this.callback, v64);\n\treturn;\nL_0176:\n\treturn;\n\tv206 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_017B:\n\tv277 = new System.NullReferenceException();\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\n\tgoto L_018A;\nL_018A:\n\tv68 = v128 != 1;\n\tif (v68) goto L_01A5;\n\tv325 = UnityEngine.AndroidJavaObject::Get(v277, v128);\n\tv347 = *([v325 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv350 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v347 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]), v119, v105, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv354 = v350 & 1;\n\tv331 = v354 == 0;\n\tif (v331) goto L_019B;\n\tv360 = UnityEngine.AndroidJavaObject::Get(v350, *([v347 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\tgoto L_016B;\nL_019B:\n\tv362 = UnityEngine.AndroidJavaObject::Get(8, *([v347 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\t*([v362 @ X0_v23 (UnityEngine.AndroidJavaObject)]) = *([v325 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv128 = 0x1E8A000 + 0x870;\n\tv382 = UnityEngine.AndroidJavaObject::Get(v362, v128);\n\tv330 = UnityEngine.AndroidJavaObject::Get(v382, v128);\nL_01A5:\n\tv335 = UnityEngine.AndroidJavaObject::Get(v139, v128);\n\tv131 = UnityEngine.AndroidJavaObject::Get(v335, v128);\n\treturn;\n// 244 bookkeeping instructions om\n// ... truncated")]
			public void onFinishedEventTrackingFailed(AndroidJavaObject eventFailureData)
			{
				//IL_01c3: Expected I, but got O
				//IL_0227: Expected O, but got I
				//IL_0227: Expected O, but got I4
				//IL_0242: Expected O, but got I4
				//IL_0210: Expected O, but got I
				if (eventFailureData == null || callback == null)
				{
					return;
				}
				AdjustEventFailure adjustEventFailure = new AdjustEventFailure();
				string text = eventFailureData.Get<string>(AdjustUtils.KeyAdid);
				bool flag = text == "";
				bool flag2 = !flag;
				bool flag3 = !flag2;
				string adid = null;
				if (!flag3)
				{
					adid = eventFailureData.Get<string>(AdjustUtils.KeyAdid);
				}
				adjustEventFailure.Adid = adid;
				string text2 = eventFailureData.Get<string>(AdjustUtils.KeyMessage);
				bool flag4 = text2 == "";
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				string message = null;
				if (!flag6)
				{
					message = eventFailureData.Get<string>(AdjustUtils.KeyMessage);
				}
				adjustEventFailure.Message = message;
				bool _003CWillRetry_003Ek__BackingField = eventFailureData.Get<bool>(AdjustUtils.KeyWillRetry);
				adjustEventFailure.WillRetry = _003CWillRetry_003Ek__BackingField;
				string text3 = eventFailureData.Get<string>(AdjustUtils.KeyTimestamp);
				bool flag7 = text3 == "";
				bool flag8 = !flag7;
				bool flag9 = !flag8;
				string timestamp = null;
				if (!flag9)
				{
					timestamp = eventFailureData.Get<string>(AdjustUtils.KeyTimestamp);
				}
				adjustEventFailure.Timestamp = timestamp;
				string text4 = eventFailureData.Get<string>(AdjustUtils.KeyEventToken);
				bool flag10 = text4 == "";
				bool flag11 = !flag10;
				bool flag12 = !flag11;
				string eventToken = null;
				if (!flag12)
				{
					eventToken = eventFailureData.Get<string>(AdjustUtils.KeyEventToken);
				}
				adjustEventFailure.EventToken = eventToken;
				string text5 = eventFailureData.Get<string>(AdjustUtils.KeyCallbackId);
				bool flag13 = text5 == "";
				bool flag14 = !flag13;
				bool flag15 = !flag14;
				string callbackId = null;
				if (!flag15)
				{
					callbackId = eventFailureData.Get<string>(AdjustUtils.KeyCallbackId);
				}
				adjustEventFailure.CallbackId = callbackId;
				AndroidJavaObject androidJavaObject = eventFailureData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (androidJavaObject != null)
				{
					string jsonResponseString = androidJavaObject.Call<string>("toString", Array.Empty<object>());
					adjustEventFailure.BuildJsonResponseFromString(jsonResponseString);
					goto IL_0163;
				}
				NullReferenceException ex = new NullReferenceException();
				string text6 = default(string);
				bool flag16 = (IntPtr)text6 != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag16)
				{
					AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)(object)ex).Get<AndroidJavaObject>(text6);
					IntPtr intPtr3 = (IntPtr)androidJavaObject2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					AndroidJavaObject androidJavaObject3 = default(AndroidJavaObject);
					if ((uint)((ulong)(long)(IntPtr)androidJavaObject3 & 1uL) != 0)
					{
						AndroidJavaObject androidJavaObject4 = androidJavaObject3.Get<AndroidJavaObject>((string)(long)intPtr3);
						goto IL_0163;
					}
					AndroidJavaObject androidJavaObject5 = ((AndroidJavaObject)8).Get<AndroidJavaObject>((string)(long)intPtr3);
					androidJavaObject5 = androidJavaObject2;
					text6 = (string)(32022528 + 2160);
					NullReferenceException ex3 = (NullReferenceException)(object)androidJavaObject5.Get<AndroidJavaObject>(text6);
					AndroidJavaObject androidJavaObject6 = ((AndroidJavaObject)(object)ex3).Get<AndroidJavaObject>(text6);
					ex2 = ex3;
				}
				AndroidJavaObject androidJavaObject7 = ((AndroidJavaObject)(object)ex2).Get<AndroidJavaObject>(text6);
				AndroidJavaObject androidJavaObject8 = androidJavaObject7.Get<AndroidJavaObject>(text6);
				return;
				IL_0163:
				callback(adjustEventFailure);
			}
		}

		[Token(Token = "0x2000022")]
		private class SessionTrackingSucceededListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000AA")]
			[FieldOffset(Offset = "0x20")]
			private Action<AdjustSessionSuccess> callback;

			[Token(Token = "0x600016A")]
			[Address(RVA = "0x156A370", Offset = "0x156A370", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED23B0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290B0]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnSessionTrackingSucceededListener\");\n\tthis.callback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SessionTrackingSucceededListener(Action<AdjustSessionSuccess> pCallback)
				: base("com.adjust.sdk.OnSessionTrackingSucceededListener")
			{
				callback = pCallback;
			}

			[Token(Token = "0x600016B")]
			[Address(RVA = "0x156CA20", Offset = "0x156CA20", Length = "0x3C4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EC4048]);\n\tv29 = *([v28 @ X8_v66]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, sessionSuccessData, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20290B1]) = v47;\nL_0018:\n\tv48 = sessionSuccessData == 0;\n\tif (v48) goto L_0118;\n\tv50 = this.callback == 0;\n\tif (v50) goto L_0118;\n\tv64 = new com.adjust.sdk.AdjustSessionSuccess();\n\tSystem.Object::.ctor(v64);\n\tgoto L_0037;\n\tv155 = *([v151 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0037;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v151, v148, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv159 = com.adjust.sdk.AdjustUtils;\nL_0037:\n\tv168 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v163.KeyAdid);\n\tv173 = System.String::op_Equality(v168, \"\");\n\tv177 = v173 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0055;\n\tgoto L_0052;\n\tv194 = *([v179 @ X0_v87 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0052;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v179, v172, v171, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv198 = com.adjust.sdk.AdjustUtils;\nL_0052:\n\tv187 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v192.KeyAdid);\nL_0055:\n\tv64.<Adid>k__BackingField = v187;\n\tgoto L_0065;\n\tv208 = *([v201 @ X0_v33 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0065;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v201, v185, v183, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv212 = com.adjust.sdk.AdjustUtils;\nL_0065:\n\tv219 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v215.KeyMessage);\n\tv250 = System.String::op_Equality(v219, \"\");\n\tv281 = v250 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_007F;\n\tgoto L_007E;\n\tv303 = *([v283 @ X0_v79 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_007E;\n\tv334 = \"il2cpp_codegen_runtime_class_init\"(v283, v248, v249, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv307 = com.adjust.sdk.AdjustUtils;\nL_007E:\n\tv291 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v296.KeyMessage);\nL_007F:\n\tv64.<Message>k__BackingField = v291;\n\tgoto L_008F;\n\tv310 = *([v297 @ X0_v40 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_008F;\n\tv335 = \"il2cpp_codegen_runtime_class_init\"(v297, v289, v287, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv314 = com.adjust.sdk.AdjustUtils;\nL_008F:\n\tv321 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v317.KeyTimestamp);\n\tv338 = System.String::op_Equality(v321, \"\");\n\tv348 = v338 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_00A9;\n\tgoto L_00A8;\n\tv372 = *([v351 @ X0_v71 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv373 = v372 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_00A8;\n\tv392 = \"il2cpp_codegen_runtime_class_init\"(v351, v336, v337, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv376 = com.adjust.sdk.AdjustUtils;\nL_00A8:\n\tv359 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v364.KeyTimestamp);\nL_00A9:\n\tv64.<Timestamp>k__BackingField = v359;\n\tgoto L_00BB;\n\tv379 = *([v365 @ X0_v47 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_00BB;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v365, v357, v355, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv383 = com.adjust.sdk.AdjustUtils;\nL_00BB:\n\tv389 = UnityEngine.AndroidJavaObject::Get(sessionSuccessData, v386.KeyJsonResponse);\n\tv397 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00CA;\n\tv411 = v397;\n\tv412 = UnityEngine.AndroidJavaObject::Get(v411, v267, v264);\n\tv415 = *([v397 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00CA:\n\tv416 = *([v397 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv417 = v416 == 0;\n\tif (v417) goto L_00EB;\n\tv420 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00D7;\n\tv440 = v420;\n\tv441 = UnityEngine.AndroidJavaObject::Get(v440, v267, v264);\nL_00D7:\n\tv442 = *([v420 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv432 = ~v442;\n\tif (v432) goto L_00EB;\n\tgoto L_00EB;\n\tv453 = v426;\n\tv454 = UnityEngine.AndroidJavaObject::Get(v453, v267, v264);\nL_00EB:\n\tgoto L_00EE;\n\tv443 = v265;\n\tv444 = UnityEngine.AndroidJavaObject::Get(v443, v267, v264);\nL_00EE:\n\tv271 = v389 == 0;\n\tif (v271) goto L_011D;\n\tv452 = UnityEngine.AndroidJavaObject::Call(v389, \"toString\", v410.Value);\n\tcom.adjust.sdk.AdjustSessionSuccess::BuildJsonResponseFromString(v64, v452);\nL_010D:\n\tSystem.Action`1<com.adjust.sdk.AdjustSessionSuccess>::Invoke(this.callback, v64);\n\treturn;\nL_0118:\n\treturn;\n\tv206 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_011D:\n\tv277 = new System.NullReferenceException();\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\n\tgoto L_012C;\nL_012C:\n\tv68 = v128 != 1;\n\tif (v68) goto L_0147;\n\tv323 = UnityEngine.AndroidJavaObject::Get(v277, v128);\n\tv341 = *([v323 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv344 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v341 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]), v119, v105, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv350 = v344 & 1;\n\tv329 = v350 == 0;\n\tif (v329) goto L_013D;\n\tv369 = UnityEngine.AndroidJavaObject::Get(v344, *([v341 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\tgoto L_010D;\nL_013D:\n\tv371 = UnityEngine.AndroidJavaObject::Get(8, *([v341 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\t*([v371 @ X0_v23 (UnityEngine.AndroidJavaObject)]) = *([v323 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv128 = 0x1E8A000 + 0x870;\n\tv391 = UnityEngine.AndroidJavaObject::Get(v371, v128);\n\tv328 = UnityEngine.AndroidJavaObject::Get(v391, v128);\nL_0147:\n\tv333 = UnityEngine.AndroidJavaObject::Get(v139, v128);\n\tv131 = UnityEngine.AndroidJavaObject::Get(v333, v128);\n\treturn;\n// 194 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onFinishedSessionTrackingSucceeded(AndroidJavaObject sessionSuccessData)
			{
				//IL_0168: Expected I, but got O
				//IL_01cc: Expected O, but got I
				//IL_01cc: Expected O, but got I4
				//IL_01e7: Expected O, but got I4
				//IL_01b5: Expected O, but got I
				if (sessionSuccessData == null || callback == null)
				{
					return;
				}
				AdjustSessionSuccess adjustSessionSuccess = new AdjustSessionSuccess();
				string text = sessionSuccessData.Get<string>(AdjustUtils.KeyAdid);
				bool flag = text == "";
				bool flag2 = !flag;
				bool flag3 = !flag2;
				string adid = null;
				if (!flag3)
				{
					adid = sessionSuccessData.Get<string>(AdjustUtils.KeyAdid);
				}
				adjustSessionSuccess.Adid = adid;
				string text2 = sessionSuccessData.Get<string>(AdjustUtils.KeyMessage);
				bool flag4 = text2 == "";
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				string message = null;
				if (!flag6)
				{
					message = sessionSuccessData.Get<string>(AdjustUtils.KeyMessage);
				}
				adjustSessionSuccess.Message = message;
				string text3 = sessionSuccessData.Get<string>(AdjustUtils.KeyTimestamp);
				bool flag7 = text3 == "";
				bool flag8 = !flag7;
				bool flag9 = !flag8;
				string timestamp = null;
				if (!flag9)
				{
					timestamp = sessionSuccessData.Get<string>(AdjustUtils.KeyTimestamp);
				}
				adjustSessionSuccess.Timestamp = timestamp;
				AndroidJavaObject androidJavaObject = sessionSuccessData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (androidJavaObject != null)
				{
					string jsonResponseString = androidJavaObject.Call<string>("toString", Array.Empty<object>());
					adjustSessionSuccess.BuildJsonResponseFromString(jsonResponseString);
					goto IL_0108;
				}
				NullReferenceException ex = new NullReferenceException();
				string text4 = default(string);
				bool flag10 = (IntPtr)text4 != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag10)
				{
					AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)(object)ex).Get<AndroidJavaObject>(text4);
					IntPtr intPtr3 = (IntPtr)androidJavaObject2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					AndroidJavaObject androidJavaObject3 = default(AndroidJavaObject);
					if ((uint)((ulong)(long)(IntPtr)androidJavaObject3 & 1uL) != 0)
					{
						AndroidJavaObject androidJavaObject4 = androidJavaObject3.Get<AndroidJavaObject>((string)(long)intPtr3);
						goto IL_0108;
					}
					AndroidJavaObject androidJavaObject5 = ((AndroidJavaObject)8).Get<AndroidJavaObject>((string)(long)intPtr3);
					androidJavaObject5 = androidJavaObject2;
					text4 = (string)(32022528 + 2160);
					NullReferenceException ex3 = (NullReferenceException)(object)androidJavaObject5.Get<AndroidJavaObject>(text4);
					AndroidJavaObject androidJavaObject6 = ((AndroidJavaObject)(object)ex3).Get<AndroidJavaObject>(text4);
					ex2 = ex3;
				}
				AndroidJavaObject androidJavaObject7 = ((AndroidJavaObject)(object)ex2).Get<AndroidJavaObject>(text4);
				AndroidJavaObject androidJavaObject8 = androidJavaObject7.Get<AndroidJavaObject>(text4);
				return;
				IL_0108:
				callback(adjustSessionSuccess);
			}
		}

		[Token(Token = "0x2000023")]
		private class SessionTrackingFailedListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000AB")]
			[FieldOffset(Offset = "0x20")]
			private Action<AdjustSessionFailure> callback;

			[Token(Token = "0x600016C")]
			[Address(RVA = "0x156A3F8", Offset = "0x156A3F8", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC5F70]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290AE]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnSessionTrackingFailedListener\");\n\tthis.callback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SessionTrackingFailedListener(Action<AdjustSessionFailure> pCallback)
				: base("com.adjust.sdk.OnSessionTrackingFailedListener")
			{
				callback = pCallback;
			}

			[Token(Token = "0x600016D")]
			[Address(RVA = "0x156C53C", Offset = "0x156C53C", Length = "0x3EC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1F0D928]);\n\tv29 = *([v28 @ X8_v69]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, sessionFailureData, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20290AF]) = v47;\nL_0018:\n\tv48 = sessionFailureData == 0;\n\tif (v48) goto L_0122;\n\tv50 = this.callback == 0;\n\tif (v50) goto L_0122;\n\tv64 = new com.adjust.sdk.AdjustSessionFailure();\n\tSystem.Object::.ctor(v64);\n\tgoto L_0037;\n\tv155 = *([v151 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv156 = v155 == 0;\n\tv157 = ~v156;\n\tif (v157) goto L_0037;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v151, v148, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv159 = com.adjust.sdk.AdjustUtils;\nL_0037:\n\tv168 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v163.KeyAdid);\n\tv173 = System.String::op_Equality(v168, \"\");\n\tv177 = v173 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_0055;\n\tgoto L_0052;\n\tv194 = *([v179 @ X0_v89 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0052;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v179, v172, v171, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv198 = com.adjust.sdk.AdjustUtils;\nL_0052:\n\tv187 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v192.KeyAdid);\nL_0055:\n\tv64.<Adid>k__BackingField = v187;\n\tgoto L_0065;\n\tv208 = *([v201 @ X0_v33 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_0065;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v201, v185, v183, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv212 = com.adjust.sdk.AdjustUtils;\nL_0065:\n\tv219 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v215.KeyMessage);\n\tv250 = System.String::op_Equality(v219, \"\");\n\tv281 = v250 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_007F;\n\tgoto L_007E;\n\tv303 = *([v283 @ X0_v81 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv304 = v303 == 0;\n\tv305 = ~v304;\n\tif (v305) goto L_007E;\n\tv336 = \"il2cpp_codegen_runtime_class_init\"(v283, v248, v249, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv307 = com.adjust.sdk.AdjustUtils;\nL_007E:\n\tv291 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v296.KeyMessage);\nL_007F:\n\tv64.<Message>k__BackingField = v291;\n\tgoto L_0091;\n\tv310 = *([v297 @ X0_v40 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_0091;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v297, v289, v287, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv314 = com.adjust.sdk.AdjustUtils;\nL_0091:\n\tv323 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v318.KeyWillRetry);\n\tv64.<WillRetry>k__BackingField = v323;\n\tv344 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v342.KeyTimestamp);\n\tv353 = System.String::op_Equality(v344, \"\");\n\tv358 = v353 == 0;\n\tv359 = ~v358;\n\tif (v359) goto L_00B3;\n\tgoto L_00B2;\n\tv383 = *([v363 @ X0_v73 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv384 = v383 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_00B2;\n\tv410 = \"il2cpp_codegen_runtime_class_init\"(v363, v351, v352, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv387 = com.adjust.sdk.AdjustUtils;\nL_00B2:\n\tv371 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v376.KeyTimestamp);\nL_00B3:\n\tv64.<Timestamp>k__BackingField = v371;\n\tgoto L_00C5;\n\tv390 = *([v377 @ X0_v49 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv391 = v390 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00C5;\n\tv411 = \"il2cpp_codegen_runtime_class_init\"(v377, v369, v367, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv394 = com.adjust.sdk.AdjustUtils;\nL_00C5:\n\tv400 = UnityEngine.AndroidJavaObject::Get(sessionFailureData, v397.KeyJsonResponse);\n\tv415 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00D4;\n\tv421 = v415;\n\tv422 = UnityEngine.AndroidJavaObject::Get(v421, v267, v264);\n\tv425 = *([v415 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00D4:\n\tv426 = *([v415 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv427 = v426 == 0;\n\tif (v427) goto L_00F5;\n\tv429 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00E1;\n\tv449 = v429;\n\tv450 = UnityEngine.AndroidJavaObject::Get(v449, v267, v264);\nL_00E1:\n\tv451 = *([v429 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv441 = ~v451;\n\tif (v441) goto L_00F5;\n\tgoto L_00F5;\n\tv462 = v435;\n\tv463 = UnityEngine.AndroidJavaObject::Get(v462, v267, v264);\nL_00F5:\n\tgoto L_00F8;\n\tv452 = v265;\n\tv453 = UnityEngine.AndroidJavaObject::Get(v452, v267, v264);\nL_00F8:\n\tv271 = v400 == 0;\n\tif (v271) goto L_0127;\n\tv461 = UnityEngine.AndroidJavaObject::Call(v400, \"toString\", v409.Value);\n\tcom.adjust.sdk.AdjustSessionFailure::BuildJsonResponseFromString(v64, v461);\nL_0117:\n\tSystem.Action`1<com.adjust.sdk.AdjustSessionFailure>::Invoke(this.callback, v64);\n\treturn;\nL_0122:\n\treturn;\n\tv206 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0127:\n\tv277 = new System.NullReferenceException();\n\tgoto L_0136;\n\tgoto L_0136;\n\tgoto L_0136;\n\tgoto L_0136;\nL_0136:\n\tv68 = v128 != 1;\n\tif (v68) goto L_0151;\n\tv325 = UnityEngine.AndroidJavaObject::Get(v277, v128);\n\tv347 = *([v325 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv350 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v347 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]), v119, v105, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv354 = v350 & 1;\n\tv331 = v354 == 0;\n\tif (v331) goto L_0147;\n\tv360 = UnityEngine.AndroidJavaObject::Get(v350, *([v347 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\tgoto L_0117;\nL_0147:\n\tv362 = UnityEngine.AndroidJavaObject::Get(8, *([v347 @ X8_v14 (Il2CppClass<UnityEngine.AndroidJavaObject>)]));\n\t*([v362 @ X0_v23 (UnityEngine.AndroidJavaObject)]) = *([v325 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv128 = 0x1E8A000 + 0x870;\n\tv382 = UnityEngine.AndroidJavaObject::Get(v362, v128);\n\tv330 = UnityEngine.AndroidJavaObject::Get(v382, v128);\nL_0151:\n\tv335 = UnityEngine.AndroidJavaObject::Get(v139, v128);\n\tv131 = UnityEngine.AndroidJavaObject::Get(v335, v128);\n\treturn;\n// 202 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onFinishedSessionTrackingFailed(AndroidJavaObject sessionFailureData)
			{
				//IL_0195: Expected I, but got O
				//IL_01f9: Expected O, but got I
				//IL_01f9: Expected O, but got I4
				//IL_0214: Expected O, but got I4
				//IL_01e2: Expected O, but got I
				if (sessionFailureData == null || callback == null)
				{
					return;
				}
				AdjustSessionFailure adjustSessionFailure = new AdjustSessionFailure();
				string text = sessionFailureData.Get<string>(AdjustUtils.KeyAdid);
				bool flag = text == "";
				bool flag2 = !flag;
				bool flag3 = !flag2;
				string adid = null;
				if (!flag3)
				{
					adid = sessionFailureData.Get<string>(AdjustUtils.KeyAdid);
				}
				adjustSessionFailure.Adid = adid;
				string text2 = sessionFailureData.Get<string>(AdjustUtils.KeyMessage);
				bool flag4 = text2 == "";
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				string message = null;
				if (!flag6)
				{
					message = sessionFailureData.Get<string>(AdjustUtils.KeyMessage);
				}
				adjustSessionFailure.Message = message;
				bool _003CWillRetry_003Ek__BackingField = sessionFailureData.Get<bool>(AdjustUtils.KeyWillRetry);
				adjustSessionFailure.WillRetry = _003CWillRetry_003Ek__BackingField;
				string text3 = sessionFailureData.Get<string>(AdjustUtils.KeyTimestamp);
				bool flag7 = text3 == "";
				bool flag8 = !flag7;
				bool flag9 = !flag8;
				string timestamp = null;
				if (!flag9)
				{
					timestamp = sessionFailureData.Get<string>(AdjustUtils.KeyTimestamp);
				}
				adjustSessionFailure.Timestamp = timestamp;
				AndroidJavaObject androidJavaObject = sessionFailureData.Get<AndroidJavaObject>(AdjustUtils.KeyJsonResponse);
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ X22_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X22_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				if (androidJavaObject != null)
				{
					string jsonResponseString = androidJavaObject.Call<string>("toString", Array.Empty<object>());
					adjustSessionFailure.BuildJsonResponseFromString(jsonResponseString);
					goto IL_0135;
				}
				NullReferenceException ex = new NullReferenceException();
				string text4 = default(string);
				bool flag10 = (IntPtr)text4 != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag10)
				{
					AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)(object)ex).Get<AndroidJavaObject>(text4);
					IntPtr intPtr3 = (IntPtr)androidJavaObject2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					AndroidJavaObject androidJavaObject3 = default(AndroidJavaObject);
					if ((uint)((ulong)(long)(IntPtr)androidJavaObject3 & 1uL) != 0)
					{
						AndroidJavaObject androidJavaObject4 = androidJavaObject3.Get<AndroidJavaObject>((string)(long)intPtr3);
						goto IL_0135;
					}
					AndroidJavaObject androidJavaObject5 = ((AndroidJavaObject)8).Get<AndroidJavaObject>((string)(long)intPtr3);
					androidJavaObject5 = androidJavaObject2;
					text4 = (string)(32022528 + 2160);
					NullReferenceException ex3 = (NullReferenceException)(object)androidJavaObject5.Get<AndroidJavaObject>(text4);
					AndroidJavaObject androidJavaObject6 = ((AndroidJavaObject)(object)ex3).Get<AndroidJavaObject>(text4);
					ex2 = ex3;
				}
				AndroidJavaObject androidJavaObject7 = ((AndroidJavaObject)(object)ex2).Get<AndroidJavaObject>(text4);
				AndroidJavaObject androidJavaObject8 = androidJavaObject7.Get<AndroidJavaObject>(text4);
				return;
				IL_0135:
				callback(adjustSessionFailure);
			}
		}

		[Token(Token = "0x2000024")]
		private class DeviceIdsReadListener : AndroidJavaProxy
		{
			[Token(Token = "0x40000AC")]
			[FieldOffset(Offset = "0x20")]
			private Action<string> onPlayAdIdReadCallback;

			[Token(Token = "0x600016E")]
			[Address(RVA = "0x156A510", Offset = "0x156A510", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECAC38]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290A7]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, pCallback, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.adjust.sdk.OnDeviceIdsRead\");\n\tthis.onPlayAdIdReadCallback = pCallback;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public DeviceIdsReadListener(Action<string> pCallback)
				: base("com.adjust.sdk.OnDeviceIdsRead")
			{
				onPlayAdIdReadCallback = pCallback;
			}

			[Token(Token = "0x600016F")]
			[Address(RVA = "0x156B828", Offset = "0x156B828", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE0D98]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, playAdId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290A8]) = v41;\nL_0016:\n\tv43 = this.onPlayAdIdReadCallback == 0;\n\tif (v43) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(this.onPlayAdIdReadCallback, playAdId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onGoogleAdIdRead(string playAdId)
			{
				if (onPlayAdIdReadCallback != null)
				{
					onPlayAdIdReadCallback(playAdId);
				}
			}

			[Token(Token = "0x6000170")]
			[Address(RVA = "0x156B89C", Offset = "0x156B89C", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EFC9A0]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, ajoAdId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20290A9]) = v43;\nL_0016:\n\tv44 = ajoAdId == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tv49 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0025;\n\tv56 = v49;\n\tv57 = 0x8907BC(v56, ajoAdId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv60 = *([v49 @ X21_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0025:\n\tv61 = *([v49 @ X21_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv62 = v61 == 0;\n\tif (v62) goto L_0046;\n\tv91 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0032;\n\tv111 = v91;\n\tv112 = 0x8907BC(v111, ajoAdId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0032:\n\tv113 = *([v91 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv101 = ~v113;\n\tif (v101) goto L_0046;\n\tgoto L_0046;\n\tv125 = v106;\n\tv126 = 0x8907BC(v125, ajoAdId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0046:\n\tgoto L_0052;\n\tv114 = v83;\n\tv115 = 0x8907BC(v114, ajoAdId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0052:\n\tv121 = UnityEngine.AndroidJavaObject::Call(ajoAdId, \"toString\", v81.Value);\n\tgoto L_005F;\nL_005F:\n\tcom.adjust.sdk.AdjustAndroid+DeviceIdsReadListener::onGoogleAdIdRead(v76, v65);\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void onGoogleAdIdRead(AndroidJavaObject ajoAdId)
			{
				string playAdId;
				if (ajoAdId != null)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X21_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					string text = ajoAdId.Call<string>("toString", Array.Empty<object>());
					playAdId = text;
				}
				else
				{
					playAdId = null;
				}
				onGoogleAdIdRead(playAdId);
			}
		}

		[Token(Token = "0x4000018")]
		private const string sdkPrefix = "unity4.19.1";

		[Token(Token = "0x4000019")]
		private static bool launchDeferredDeeplink = true;

		[Token(Token = "0x400001A")]
		private static AndroidJavaClass ajcAdjust;

		[Token(Token = "0x400001B")]
		private static AndroidJavaObject ajoCurrentActivity;

		[Token(Token = "0x400001C")]
		private static DeferredDeeplinkListener onDeferredDeeplinkListener;

		[Token(Token = "0x400001D")]
		private static AttributionChangeListener onAttributionChangedListener;

		[Token(Token = "0x400001E")]
		private static EventTrackingFailedListener onEventTrackingFailedListener;

		[Token(Token = "0x400001F")]
		private static EventTrackingSucceededListener onEventTrackingSucceededListener;

		[Token(Token = "0x4000020")]
		private static SessionTrackingFailedListener onSessionTrackingFailedListener;

		[Token(Token = "0x4000021")]
		private static SessionTrackingSucceededListener onSessionTrackingSucceededListener;

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x1566074", Offset = "0x1566074", Length = "0xF14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1F0C6B8]);\n\tv31 = *([v30 @ X8_v281]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029087]) = v50;\nL_001B:\n\tv52 = adjustConfig.environment;\n\tv69 = adjustConfig.environment != 1;\n\tif (v69) goto L_FFFFFFFF;\n\tgoto L_0034;\nL_0034:\n\tv443 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+97]) == 0;\n\tif (v443) goto L_00A4;\n\t// 55 NewArr v444 @ X0_v276 (System.Object[]), typeof(System.Object[]), 4\n\tgoto L_004B;\n\tv507 = *([v498 @ X8_v260 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv508 = v507 == 0;\n\tv509 = ~v508;\n\t// 67 ConditionalJump @b303, v509 @ TEMP_v250\n\tv519 = v498;\n\tv510 = \"il2cpp_codegen_runtime_class_init\"(v519, v184, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv512 = com.adjust.sdk.AdjustAndroid;\nL_004B:\n\tv522 = v520.ajoCurrentActivity == 0;\n\tif (v522) goto L_0053;\n\t// 80 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), v520.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\nL_0053:\n\tv52 = v444.Length;\n\tv537 = v444.Length == 0;\n\tif (v537) goto L_04ED;\n\tv444[0] = v520.ajoCurrentActivity;\n\tv550 = adjustConfig.appToken == 0;\n\tif (v550) goto L_0061;\n\t// 93 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), adjustConfig.appToken (System.String)\n\tv52 = v444.Length;\nL_0061:\n\tv922 = v52 < 1;\n\tv694 = ~v922;\n\tv684 = v52 - 1;\n\tv664 = v684 == 0;\n\tv923 = ~v694;\n\tv571 = v923 | v664;\n\tif (v571) goto L_04ED;\n\tv444[1] = adjustConfig.appToken;\n\tv931 = *([v441 @ X8_v6 (System.String)]) == 0;\n\tif (v931) goto L_0077;\n\t// 115 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), [v441 @ X8_v6 (System.String)]\n\tv52 = v444.Length;\nL_0077:\n\tv935 = v52 < 2;\n\tv695 = ~v935;\n\tv685 = v52 - 2;\n\tv665 = v685 == 0;\n\tv936 = ~v695;\n\tv572 = v936 | v665;\n\tif (v572) goto L_04ED;\n\tv444[2] = *([v441 @ X8_v6 (System.String)]);\n\tv942 = adjustConfig.allowSuppressLogLevel;\n\t// 138 Box adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Nullable`1<System.Boolean>), &v942 @ X8_v267 (System.Nullable`1<System.Boolean>)\n\tv946 = adjustConfig == 0;\n\tif (v946) goto L_0094;\n\t// 145 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)\nL_0094:\n\tv52 = v444.Length;\n\tv959 = v444.Length < 3;\n\tv689 = ~v959;\n\tv679 = v444.Length - 3;\n\tv659 = v679 == 0;\n\tv960 = ~v689;\n\tv566 = v960 | v659;\n\tif (v566) goto L_04ED;\n\tv444[3] = adjustConfig;\n\tgoto L_00F4;\nL_00A4:\n\t// 164 NewArr v445 @ X0_v263 (System.Object[]), typeof(System.Object[]), 3\n\tgoto L_00B8;\n\tv513 = *([v503 @ X8_v247 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv514 = v513 == 0;\n\tv515 = ~v514;\n\t// 176 ConditionalJump @b307, v515 @ TEMP_v231\n\tv523 = v503;\n\tv516 = \"il2cpp_codegen_runtime_class_init\"(v523, v185, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv518 = com.adjust.sdk.AdjustAndroid;\nL_00B8:\n\tv526 = v524.ajoCurrentActivity == 0;\n\tif (v526) goto L_00C0;\n\t// 189 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), v524.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\nL_00C0:\n\tv52 = v445.Length;\n\tv548 = v445.Length == 0;\n\tif (v548) goto L_04ED;\n\tv445[0] = v524.ajoCurrentActivity;\n\tv784 = adjustConfig.appToken == 0;\n\tif (v784) goto L_00CE;\n\t// 202 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), adjustConfig.appToken (System.String)\n\tv52 = v445.Length;\nL_00CE:\n\tv926 = v52 < 1;\n\tv696 = ~v926;\n\tv686 = v52 - 1;\n\tv666 = v686 == 0;\n\tv927 = ~v696;\n\tv573 = v927 | v666;\n\tif (v573) goto L_04ED;\n\tv445[1] = adjustConfig.appToken;\n\tv932 = *([v441 @ X8_v6 (System.String)]) == 0;\n\tif (v932) goto L_00E4;\n\t// 224 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), [v441 @ X8_v6 (System.String)]\n\tv52 = v445.Length;\nL_00E4:\n\tv939 = v52 < 2;\n\tv697 = ~v939;\n\tv687 = v52 - 2;\n\tv667 = v687 == 0;\n\tv940 = ~v697;\n\tv574 = v940 | v667;\n\tif (v574) goto L_04ED;\n\tv445[2] = *([v441 @ X8_v6 (System.String)]);\nL_00F4:\n\tv956 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v956, \"com.adjust.sdk.AdjustConfig\", v947);\n\tgoto L_010B;\n\tv970 = *([v966 @ X0_v10 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv971 = v970 == 0;\n\tv972 = ~v971;\n\tgoto L_010B;\n\tv979 = \"il2cpp_codegen_runtime_class_init\"(v966, v963, v327, v108, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv974 = com.adjust.sdk.AdjustAndroid;\nL_010B:\n\tv977.launchDeferredDeeplink = adjustConfig.launchDeferredDeeplink;\n\tv52 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+A0]);\n\tv978 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+A0]) == 0;\n\tif (v978) goto L_015F;\n\tv146 = adjustConfig + 0x9C;\n\tv982 = System.Nullable`1<com.adjust.sdk.AdjustLogLevel>::get_Value(v146);\n\tv393 = com.adjust.sdk.AdjustLogLevelExtension::ToUppercaseString(v982);\n\tv1003 = System.String::Equals(v393, \"SUPPRESS\");\n\tv253 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v253, \"com.adjust.sdk.LogLevel\");\n\tv1016 = v1003 == 0;\n\tif (v1016) goto L_0137;\n\tgoto L_0140;\nL_0137:\n\tv1021 = System.Nullable`1<com.adjust.sdk.AdjustLogLevel>::get_Value(v146);\n\tv254 = com.adjust.sdk.AdjustLogLevelExtension::ToUppercaseString(v1021);\nL_0140:\n\tv991 = UnityEngine.AndroidJavaObject::GetStatic(v253, v988);\n\tv993 = v991 == 0;\n\tif (v993) goto L_015F;\n\t// 326 NewArr v394 @ X0_v248 (System.Object[]), typeof(System.Object[]), 1\n\t// 333 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), v991 @ X0_v246 (UnityEngine.AndroidJavaObject)\n\tv52 = v394.Length;\n\tv728 = v394.Length == 0;\n\tif (v728) goto L_04ED;\n\tv394[0] = v991;\n\tUnityEngine.AndroidJavaObject::Call(v956, \"setLogLevel\", v394);\nL_015F:\n\t// 351 NewArr v395 @ X0_v14 (System.Object[]), typeof(System.Object[]), 1\n\tv998 = \"unity4.19.1\" == 0;\n\tif (v998) goto L_016D;\n\t// 362 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), \"unity4.19.1\"\nL_016D:\n\tv52 = v395.Length;\n\tv729 = v395.Length == 0;\n\tif (v729) goto L_04ED;\n\tv395[0] = \"unity4.19.1\";\n\tUnityEngine.AndroidJavaObject::Call(v956, \"setSdkPrefix\", v395);\n\tv52 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+88]);\n\tv1018 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+88]) == 0;\n\tif (v1018) goto L_01A1;\n\t// 384 NewArr v1024 @ X0_v230 (System.Object[]), typeof(System.Object[]), 1\n\tv290 = adjustConfig.delayStart;\n\t// 394 Box adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Nullable`1<System.Double>), &v290 @ X8_v220 (System.Nullable`1<System.Double>)\n\tv1093 = adjustConfig == 0;\n\tif (v1093) goto L_0196;\n\t// 403 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)\nL_0196:\n\tv52 = v1024.Length;\n\tv730 = v1024.Length == 0;\n\tif (v730) goto L_04ED;\n\tv1024[0] = adjustConfig;\n\tUnityEngine.AndroidJavaObject::Call(v956, \"setDelayStart\", v1024);\nL_01A1:\n\tv52 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+95]);\n\tv1039 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+95]) == 0;\n\tif (v1039) goto L_01E9;\n\tv1050 = adjustConfig + 0x94;\n\t// 423 NewArr v1051 @ X0_v213 (System.Object[]), typeof(System.Object[]), 1\n\tv1076 = System.Nullable`1<System.Boolean>::get_Value(v1050);\n\t// 437 Box adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Boolean), &v1076 @ X0_v215 (System.Boolean)\n\tv1126 = adjustConfig == 0;\n\tif (v1126) goto L_01C1;\n\t// 446 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)\nL_01C1:\n\tv52 = v1051.Length;\n\tv731 = v1051.Length == 0;\n\tif (v731) goto L_04ED;\n\tv1051[0] = adjustConfig;\n\tv1167 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v1167, \"java.lang.Boolean\", v1051);\n\t// 466 NewArr v396 @ X0_v222 (System.Object[]), typeof(System.Object[]), 1\n\tv1235 = v1167 == 0;\n\tif (v1235) goto L_01DE;\n\t// 475 IsInst adjustConfig @ X0 (com.adjust.sdk.AdjustConfig), typeof(System.Object), v1167 @ X0_v220 (UnityEngine.AndroidJavaOb\n// ... truncated")]
		public unsafe static void Start(AdjustConfig adjustConfig)
		{
			//IL_1734: Expected O, but got I4
			//IL_1662: Expected O, but got I4
			//IL_1791: Expected O, but got I4
			//IL_16bf: Expected O, but got I4
			//IL_0201: Expected O, but got I4
			//IL_03a0: Expected O, but got I
			//IL_067e: Expected O, but got I
			//IL_080c: Expected O, but got I
			//IL_0b7d: Expected O, but got I
			//IL_0fd0: Expected O, but got I
			//IL_0c1a: Expected O, but got I
			//IL_0c9e: Expected O, but got I4
			//IL_0cf4: Expected O, but got I
			//IL_0d78: Expected O, but got I4
			//IL_0dce: Expected O, but got I
			//IL_0e52: Expected O, but got I4
			//IL_0ea8: Expected O, but got I
			//IL_0f2c: Expected O, but got I4
			AdjustEnvironment environment = adjustConfig.environment;
			string text = ((adjustConfig.environment != AdjustEnvironment.Production) ? "sandbox" : "production");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+97]");
			object[] args;
			AdjustConfig adjustConfig2;
			if ((IntPtr)0 != (IntPtr)0)
			{
				object[] array = new object[4];
				if (ajoCurrentActivity != null)
				{
					adjustConfig2 = (AdjustConfig)(ajoCurrentActivity as object);
				}
				environment = (AdjustEnvironment)array.Length;
				if (array.Length != 0)
				{
					array[0] = ajoCurrentActivity;
					if (adjustConfig.appToken != null)
					{
						adjustConfig2 = (AdjustConfig)(adjustConfig.appToken as object);
						environment = (AdjustEnvironment)array.Length;
					}
					bool flag = environment < AdjustEnvironment.Production;
					bool flag2 = !flag;
					object obj = environment - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = adjustConfig.appToken;
						if (text != null)
						{
							adjustConfig2 = (AdjustConfig)(text as object);
							environment = (AdjustEnvironment)array.Length;
						}
						bool flag5 = environment < (AdjustEnvironment)2;
						bool flag6 = !flag5;
						object obj2 = environment - 2;
						bool flag7 = obj2 == null;
						bool flag8 = !flag6;
						if (!(flag8 || flag7))
						{
							array[2] = text;
							bool? allowSuppressLogLevel = adjustConfig.allowSuppressLogLevel;
							adjustConfig2 = (AdjustConfig)(object)allowSuppressLogLevel;
							if (adjustConfig != null)
							{
								adjustConfig2 = (AdjustConfig)(adjustConfig as object);
							}
							environment = (AdjustEnvironment)array.Length;
							bool flag9 = array.Length < 3;
							bool flag10 = !flag9;
							object obj3 = array.Length - 3;
							bool flag11 = obj3 == null;
							bool flag12 = !flag10;
							if (!(flag12 || flag11))
							{
								array[3] = adjustConfig;
								args = array;
								goto IL_16f4;
							}
						}
					}
				}
			}
			else
			{
				object[] array2 = new object[3];
				if (ajoCurrentActivity != null)
				{
					adjustConfig2 = (AdjustConfig)(ajoCurrentActivity as object);
				}
				environment = (AdjustEnvironment)array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = ajoCurrentActivity;
					if (adjustConfig.appToken != null)
					{
						adjustConfig2 = (AdjustConfig)(adjustConfig.appToken as object);
						environment = (AdjustEnvironment)array2.Length;
					}
					bool flag13 = environment < AdjustEnvironment.Production;
					bool flag14 = !flag13;
					object obj4 = environment - 1;
					bool flag15 = obj4 == null;
					bool flag16 = !flag14;
					if (!(flag16 || flag15))
					{
						array2[1] = adjustConfig.appToken;
						if (text != null)
						{
							adjustConfig2 = (AdjustConfig)(text as object);
							environment = (AdjustEnvironment)array2.Length;
						}
						bool flag17 = environment < (AdjustEnvironment)2;
						bool flag18 = !flag17;
						object obj5 = environment - 2;
						bool flag19 = obj5 == null;
						bool flag20 = !flag18;
						if (!(flag20 || flag19))
						{
							array2[2] = text;
							args = array2;
							goto IL_16f4;
						}
					}
				}
			}
			goto IL_1602;
			IL_07c8:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+93]");
			environment = AdjustEnvironment.Sandbox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+93]");
			AndroidJavaObject androidJavaObject;
			if ((IntPtr)0 != (IntPtr)0)
			{
				bool? flag21 = (bool?)(object)((long)(IntPtr)adjustConfig + 146L);
				object[] array3 = new object[1];
				bool value = ((bool?*)flag21)->Value;
				adjustConfig2 = (AdjustConfig)(object)value;
				if (adjustConfig != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig as object);
				}
				environment = (AdjustEnvironment)array3.Length;
				if (array3.Length == 0)
				{
					goto IL_1602;
				}
				array3[0] = adjustConfig;
				androidJavaObject.Call("setSendInBackground", array3);
			}
			if (adjustConfig.userAgent != null)
			{
				object[] array4 = new object[1];
				if (adjustConfig.userAgent != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig.userAgent as object);
				}
				environment = (AdjustEnvironment)array4.Length;
				if (array4.Length == 0)
				{
					goto IL_1602;
				}
				array4[0] = adjustConfig.userAgent;
				androidJavaObject.Call("setUserAgent", array4);
			}
			if (!string.IsNullOrEmpty(adjustConfig.processName))
			{
				object[] array5 = new object[1];
				if (adjustConfig.processName != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig.processName as object);
				}
				environment = (AdjustEnvironment)array5.Length;
				if (array5.Length == 0)
				{
					goto IL_1602;
				}
				array5[0] = adjustConfig.processName;
				androidJavaObject.Call("setProcessName", array5);
			}
			if (adjustConfig.defaultTracker != null)
			{
				object[] array6 = new object[1];
				if (adjustConfig.defaultTracker != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig.defaultTracker as object);
				}
				environment = (AdjustEnvironment)array6.Length;
				if (array6.Length == 0)
				{
					goto IL_1602;
				}
				array6[0] = adjustConfig.defaultTracker;
				androidJavaObject.Call("setDefaultTracker", array6);
			}
			if (!IsAppSecretSet(adjustConfig))
			{
				goto IL_0f8c;
			}
			object[] array7 = new object[5];
			long? num = (long?)(object)((long)(IntPtr)adjustConfig + 112L);
			long value2 = ((long?*)num)->Value;
			adjustConfig2 = (AdjustConfig)(object)value2;
			if (adjustConfig != null)
			{
				adjustConfig2 = (AdjustConfig)(adjustConfig as object);
			}
			environment = (AdjustEnvironment)array7.Length;
			if (array7.Length != 0)
			{
				array7[0] = adjustConfig;
				long? num2 = (long?)(object)((long)(IntPtr)adjustConfig + 48L);
				long value3 = ((long?*)num2)->Value;
				adjustConfig2 = (AdjustConfig)(object)value3;
				if (adjustConfig != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig as object);
				}
				environment = (AdjustEnvironment)array7.Length;
				bool flag22 = array7.Length < 1;
				bool flag23 = !flag22;
				object obj6 = array7.Length - 1;
				bool flag24 = obj6 == null;
				bool flag25 = !flag23;
				if (!(flag25 || flag24))
				{
					array7[1] = adjustConfig;
					long? num3 = (long?)(object)((long)(IntPtr)adjustConfig + 64L);
					long value4 = ((long?*)num3)->Value;
					adjustConfig2 = (AdjustConfig)(object)value4;
					if (adjustConfig != null)
					{
						adjustConfig2 = (AdjustConfig)(adjustConfig as object);
					}
					environment = (AdjustEnvironment)array7.Length;
					bool flag26 = array7.Length < 2;
					bool flag27 = !flag26;
					object obj7 = array7.Length - 2;
					bool flag28 = obj7 == null;
					bool flag29 = !flag27;
					if (!(flag29 || flag28))
					{
						array7[2] = adjustConfig;
						long? num4 = (long?)(object)((long)(IntPtr)adjustConfig + 80L);
						long value5 = ((long?*)num4)->Value;
						adjustConfig2 = (AdjustConfig)(object)value5;
						if (adjustConfig != null)
						{
							adjustConfig2 = (AdjustConfig)(adjustConfig as object);
						}
						environment = (AdjustEnvironment)array7.Length;
						bool flag30 = array7.Length < 3;
						bool flag31 = !flag30;
						object obj8 = array7.Length - 3;
						bool flag32 = obj8 == null;
						bool flag33 = !flag31;
						if (!(flag33 || flag32))
						{
							array7[3] = adjustConfig;
							long? num5 = (long?)(object)((long)(IntPtr)adjustConfig + 96L);
							long value6 = ((long?*)num5)->Value;
							adjustConfig2 = (AdjustConfig)(object)value6;
							if (adjustConfig != null)
							{
								adjustConfig2 = (AdjustConfig)(adjustConfig as object);
							}
							environment = (AdjustEnvironment)array7.Length;
							bool flag34 = array7.Length < 4;
							bool flag35 = !flag34;
							object obj9 = array7.Length - 4;
							bool flag36 = obj9 == null;
							bool flag37 = !flag35;
							if (!(flag37 || flag36))
							{
								array7[4] = adjustConfig;
								androidJavaObject.Call("setAppSecret", array7);
								goto IL_0f8c;
							}
						}
					}
				}
			}
			goto IL_1602;
			IL_16f4:
			androidJavaObject = new AndroidJavaObject("com.adjust.sdk.AdjustConfig", args);
			launchDeferredDeeplink = adjustConfig.launchDeferredDeeplink;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+A0]");
			environment = AdjustEnvironment.Sandbox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+A0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				AdjustLogLevel? adjustLogLevel = (AdjustLogLevel?)(object)((long)(IntPtr)adjustConfig + 156L);
				AdjustLogLevel value7 = ((AdjustLogLevel?*)adjustLogLevel)->Value;
				string text2 = value7.ToUppercaseString();
				bool flag38 = text2.Equals("SUPPRESS");
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.LogLevel");
				string fieldName;
				if (flag38)
				{
					fieldName = "SUPRESS";
				}
				else
				{
					AdjustLogLevel value8 = ((AdjustLogLevel?*)adjustLogLevel)->Value;
					string text3 = value8.ToUppercaseString();
					fieldName = text3;
				}
				AndroidJavaObject androidJavaObject2 = androidJavaClass.GetStatic<AndroidJavaObject>(fieldName);
				if (androidJavaObject2 != null)
				{
					object[] array8 = new object[1];
					adjustConfig2 = (AdjustConfig)(androidJavaObject2 as object);
					environment = (AdjustEnvironment)array8.Length;
					if (array8.Length == 0)
					{
						goto IL_1602;
					}
					array8[0] = androidJavaObject2;
					androidJavaObject.Call("setLogLevel", array8);
				}
			}
			object[] array9 = new object[1];
			if ("unity4.19.1" != null)
			{
				adjustConfig2 = (AdjustConfig)("unity4.19.1" as object);
			}
			environment = (AdjustEnvironment)array9.Length;
			if (array9.Length != 0)
			{
				array9[0] = "unity4.19.1";
				androidJavaObject.Call("setSdkPrefix", array9);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+88]");
				environment = AdjustEnvironment.Sandbox;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+88]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					object[] array10 = new object[1];
					double? delayStart = adjustConfig.delayStart;
					adjustConfig2 = (AdjustConfig)(object)delayStart;
					if (adjustConfig != null)
					{
						adjustConfig2 = (AdjustConfig)(adjustConfig as object);
					}
					environment = (AdjustEnvironment)array10.Length;
					if (array10.Length == 0)
					{
						goto IL_1602;
					}
					array10[0] = adjustConfig;
					androidJavaObject.Call("setDelayStart", array10);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+95]");
				environment = AdjustEnvironment.Sandbox;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+95]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_07c8;
				}
				bool? flag39 = (bool?)(object)((long)(IntPtr)adjustConfig + 148L);
				object[] array11 = new object[1];
				bool value9 = ((bool?*)flag39)->Value;
				adjustConfig2 = (AdjustConfig)(object)value9;
				if (adjustConfig != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig as object);
				}
				environment = (AdjustEnvironment)array11.Length;
				if (array11.Length != 0)
				{
					array11[0] = adjustConfig;
					AndroidJavaObject androidJavaObject3 = new AndroidJavaObject("java.lang.Boolean", array11);
					object[] array12 = new object[1];
					if (androidJavaObject3 != null)
					{
						adjustConfig2 = (AdjustConfig)(androidJavaObject3 as object);
					}
					environment = (AdjustEnvironment)array12.Length;
					if (array12.Length != 0)
					{
						array12[0] = androidJavaObject3;
						androidJavaObject.Call("setEventBufferingEnabled", array12);
						goto IL_07c8;
					}
				}
			}
			goto IL_1602;
			IL_1602:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0f8c:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+91]");
			environment = AdjustEnvironment.Sandbox;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+91]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				bool? flag40 = (bool?)(object)((long)(IntPtr)adjustConfig + 144L);
				object[] array13 = new object[1];
				bool value10 = ((bool?*)flag40)->Value;
				adjustConfig2 = (AdjustConfig)(object)value10;
				if (adjustConfig != null)
				{
					adjustConfig2 = (AdjustConfig)(adjustConfig as object);
				}
				environment = (AdjustEnvironment)array13.Length;
				if (array13.Length == 0)
				{
					goto IL_1602;
				}
				array13[0] = adjustConfig;
				androidJavaObject.Call("setDeviceKnown", array13);
			}
			if (adjustConfig.attributionChangedDelegate != null)
			{
				AttributionChangeListener attributionChangeListener = new AttributionChangeListener(adjustConfig.attributionChangedDelegate);
				onAttributionChangedListener = attributionChangeListener;
				object[] array14 = new object[1];
				if (onAttributionChangedListener != null)
				{
					adjustConfig2 = (AdjustConfig)(onAttributionChangedListener as object);
				}
				environment = (AdjustEnvironment)array14.Length;
				if (array14.Length == 0)
				{
					goto IL_1602;
				}
				array14[0] = onAttributionChangedListener;
				androidJavaObject.Call("setOnAttributionChangedListener", array14);
			}
			if (adjustConfig.eventSuccessDelegate != null)
			{
				EventTrackingSucceededListener eventTrackingSucceededListener = new EventTrackingSucceededListener(adjustConfig.eventSuccessDelegate);
				onEventTrackingSucceededListener = eventTrackingSucceededListener;
				object[] array15 = new object[1];
				if (onEventTrackingSucceededListener != null)
				{
					adjustConfig2 = (AdjustConfig)(onEventTrackingSucceededListener as object);
				}
				environment = (AdjustEnvironment)array15.Length;
				if (array15.Length == 0)
				{
					goto IL_1602;
				}
				array15[0] = onEventTrackingSucceededListener;
				androidJavaObject.Call("setOnEventTrackingSucceededListener", array15);
			}
			if (adjustConfig.eventFailureDelegate != null)
			{
				EventTrackingFailedListener eventTrackingFailedListener = new EventTrackingFailedListener(adjustConfig.eventFailureDelegate);
				onEventTrackingFailedListener = eventTrackingFailedListener;
				object[] array16 = new object[1];
				if (onEventTrackingFailedListener != null)
				{
					adjustConfig2 = (AdjustConfig)(onEventTrackingFailedListener as object);
				}
				environment = (AdjustEnvironment)array16.Length;
				if (array16.Length == 0)
				{
					goto IL_1602;
				}
				array16[0] = onEventTrackingFailedListener;
				androidJavaObject.Call("setOnEventTrackingFailedListener", array16);
			}
			if (adjustConfig.sessionSuccessDelegate != null)
			{
				SessionTrackingSucceededListener sessionTrackingSucceededListener = new SessionTrackingSucceededListener(adjustConfig.sessionSuccessDelegate);
				onSessionTrackingSucceededListener = sessionTrackingSucceededListener;
				object[] array17 = new object[1];
				if (onSessionTrackingSucceededListener != null)
				{
					adjustConfig2 = (AdjustConfig)(onSessionTrackingSucceededListener as object);
				}
				environment = (AdjustEnvironment)array17.Length;
				if (array17.Length == 0)
				{
					goto IL_1602;
				}
				array17[0] = onSessionTrackingSucceededListener;
				androidJavaObject.Call("setOnSessionTrackingSucceededListener", array17);
			}
			if (adjustConfig.sessionFailureDelegate != null)
			{
				SessionTrackingFailedListener sessionTrackingFailedListener = new SessionTrackingFailedListener(adjustConfig.sessionFailureDelegate);
				onSessionTrackingFailedListener = sessionTrackingFailedListener;
				object[] array18 = new object[1];
				if (onSessionTrackingFailedListener != null)
				{
					adjustConfig2 = (AdjustConfig)(onSessionTrackingFailedListener as object);
				}
				environment = (AdjustEnvironment)array18.Length;
				if (array18.Length == 0)
				{
					goto IL_1602;
				}
				array18[0] = onSessionTrackingFailedListener;
				androidJavaObject.Call("setOnSessionTrackingFailedListener", array18);
			}
			if (adjustConfig.deferredDeeplinkDelegate != null)
			{
				DeferredDeeplinkListener deferredDeeplinkListener = new DeferredDeeplinkListener(adjustConfig.deferredDeeplinkDelegate);
				onDeferredDeeplinkListener = deferredDeeplinkListener;
				object[] array19 = new object[1];
				if (onDeferredDeeplinkListener != null)
				{
					adjustConfig2 = (AdjustConfig)(onDeferredDeeplinkListener as object);
				}
				environment = (AdjustEnvironment)array19.Length;
				if (array19.Length == 0)
				{
					goto IL_1602;
				}
				array19[0] = onDeferredDeeplinkListener;
				androidJavaObject.Call("setOnDeeplinkResponseListener", array19);
			}
			object[] array20 = new object[1];
			adjustConfig2 = (AdjustConfig)(androidJavaObject as object);
			environment = (AdjustEnvironment)array20.Length;
			if (array20.Length != 0)
			{
				array20[0] = androidJavaObject;
				ajcAdjust.CallStatic("onCreate", array20);
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				environment = AdjustEnvironment.Sandbox;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1537 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1555 @ X20_v11 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				ajcAdjust.CallStatic("onResume");
				return;
			}
			goto IL_1602;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x156702C", Offset = "0x156702C", Length = "0x508")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EF3F78]);\n\tv31 = *([v30 @ X8_v88]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029088]) = v50;\nL_001D:\n\t// 29 NewArr v55 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv258 = adjustEvent.eventToken == 0;\n\tif (v258) goto L_002D;\n\t// 41 IsInst v327 @ X0_v86, typeof(System.Object), adjustEvent.eventToken (System.String)\nL_002D:\n\tv334 = v55.Length == 0;\n\tif (v334) goto L_01DF;\n\tv55[0] = adjustEvent.eventToken;\n\tv382 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v382, \"com.adjust.sdk.AdjustEvent\", v55);\n\tv477 = *([adjustEvent @ X0 (com.adjust.sdk.AdjustEvent)+38]) == 0;\n\tif (v477) goto L_007D;\n\tv480 = adjustEvent + 0x30;\n\t// 65 NewArr v481 @ X0_v73 (System.Object[]), typeof(System.Object[]), 2\n\tv553 = System.Nullable`1<System.Double>::get_Value(v480);\n\t// 77 Box v218 @ X0_v77, typeof(System.Double), &v40 @ V0\n\tv650 = v218 == 0;\n\tif (v650) goto L_0059;\n\t// 86 IsInst v413 @ X0_v84, typeof(System.Object), v218 @ X0_v77\nL_0059:\n\tv246 = v481.Length;\n\tv363 = v481.Length == 0;\n\tif (v363) goto L_01DF;\n\tv481[0] = v218;\n\tv702 = adjustEvent.currency == 0;\n\tif (v702) goto L_0067;\n\t// 99 IsInst v414 @ X0_v82, typeof(System.Object), adjustEvent.currency (System.String)\n\tv246 = v481.Length;\nL_0067:\n\tv727 = v246 < 1;\n\tv151 = ~v727;\n\tv143 = v246 - 1;\n\tv127 = v143 == 0;\n\tv728 = ~v151;\n\tv87 = v728 | v127;\n\tif (v87) goto L_01DF;\n\tv481[1] = adjustEvent.currency;\n\tUnityEngine.AndroidJavaObject::Call(v382, \"setRevenue\", v481);\nL_007D:\n\tv681 = adjustEvent.callbackList;\n\tv505 = adjustEvent.callbackList == 0;\n\tif (v505) goto L_00F3;\nL_008D:\n\tv561 = v168 >= v681._size;\n\tif (v561) goto L_00F3;\n\tv625 = v681._size < v168;\n\tv152 = ~v625;\n\tv144 = v681._size - v168;\n\tv128 = v144 == 0;\n\tv626 = ~v152;\n\tv88 = v626 | v128;\n\tif (v88) goto L_00A0;\n\tv652 = v168 << 3;\n\tv685 = v681._items + v652;\n\tgoto L_00A8;\nL_00A0:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv680 = v168 << 3;\n\tv685 = v681._items + v680;\nL_00A8:\n\tv687 = v685 + 0x20;\n\tv61 = v168 + 1;\n\tv688 = v681._size < v61;\n\tv288 = ~v688;\n\tv285 = v681._size - v61;\n\tv279 = v285 == 0;\n\tv689 = ~v279;\n\tv264 = v288 & v689;\n\tif (v264) goto L_00BA;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00BA:\n\tv705 = v681._items;\n\t// 192 NewArr v304 @ X0_v62 (System.Object[]), typeof(System.Object[]), 2\n\tv737 = *([v687 @ X8_v60]) == 0;\n\tif (v737) goto L_00CC;\n\t// 201 IsInst v415 @ X0_v69, typeof(System.Object), [v687 @ X8_v60]\nL_00CC:\n\tv248 = v304.Length;\n\tv364 = v304.Length == 0;\n\tif (v364) goto L_01DF;\n\tv304[0] = *([v687 @ X8_v60]);\n\tv748 = v705[v61 @ X26_v12 (System.Int32)] == 0;\n\tif (v748) goto L_00D9;\n\t// 213 IsInst v416 @ X0_v67, typeof(System.Object), v705[v61 @ X26_v12 (System.Int32)]\n\tv248 = v304.Length;\nL_00D9:\n\tv755 = v248 < 1;\n\tv153 = ~v755;\n\tv145 = v248 - 1;\n\tv129 = v145 == 0;\n\tv756 = ~v153;\n\tv89 = v756 | v129;\n\tif (v89) goto L_01DF;\n\tv304[1] = v705[v61 @ X26_v12 (System.Int32)];\n\tUnityEngine.AndroidJavaObject::Call(v382, \"addCallbackParameter\", v304);\n\tv681 = adjustEvent.callbackList;\n\tv168 = v61 + 1;\n\tv762 = adjustEvent.callbackList == 0;\n\tv234 = ~v762;\n\tif (v234) goto L_008D;\n\tgoto L_01DE;\nL_00F3:\n\tv711 = adjustEvent.partnerList;\n\tv591 = adjustEvent.partnerList == 0;\n\tif (v591) goto L_016A;\nL_0103:\n\tv607 = v171 >= v711._size;\n\tif (v607) goto L_016A;\n\tv654 = v711._size < v171;\n\tv154 = ~v654;\n\tv146 = v711._size - v171;\n\tv130 = v146 == 0;\n\tv655 = ~v154;\n\tv90 = v655 | v130;\n\tif (v90) goto L_0116;\n\tv691 = v171 << 3;\n\tv715 = v711._items + v691;\n\tgoto L_011E;\nL_0116:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv710 = v171 << 3;\n\tv715 = v711._items + v710;\nL_011E:\n\tv717 = v715 + 0x20;\n\tv63 = v171 + 1;\n\tv718 = v711._size < v63;\n\tv289 = ~v718;\n\tv286 = v711._size - v63;\n\tv280 = v286 == 0;\n\tv719 = ~v280;\n\tv265 = v289 & v719;\n\tif (v265) goto L_0130;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0130:\n\tv731 = v711._items;\n\t// 310 NewArr v305 @ X0_v48 (System.Object[]), typeof(System.Object[]), 2\n\tv746 = *([v717 @ X8_v44]) == 0;\n\tif (v746) goto L_0142;\n\t// 319 IsInst v417 @ X0_v55, typeof(System.Object), [v717 @ X8_v44]\nL_0142:\n\tv250 = v305.Length;\n\tv365 = v305.Length == 0;\n\tif (v365) goto L_01DF;\n\tv305[0] = *([v717 @ X8_v44]);\n\tv757 = v731[v63 @ X26_v10 (System.Int32)] == 0;\n\tif (v757) goto L_014F;\n\t// 331 IsInst v418 @ X0_v53, typeof(System.Object), v731[v63 @ X26_v10 (System.Int32)]\n\tv250 = v305.Length;\nL_014F:\n\tv760 = v250 < 1;\n\tv155 = ~v760;\n\tv147 = v250 - 1;\n\tv131 = v147 == 0;\n\tv761 = ~v155;\n\tv91 = v761 | v131;\n\tif (v91) goto L_01DF;\n\tv305[1] = v731[v63 @ X26_v10 (System.Int32)];\n\tUnityEngine.AndroidJavaObject::Call(v382, \"addPartnerParameter\", v305);\n\tv711 = adjustEvent.partnerList;\n\tv171 = v63 + 1;\n\tv763 = adjustEvent.partnerList == 0;\n\tv237 = ~v763;\n\tif (v237) goto L_0103;\n\tgoto L_01DE;\nL_016A:\n\tv624 = adjustEvent.transactionId == 0;\n\tif (v624) goto L_0189;\n\t// 366 NewArr v306 @ X0_v39 (System.Object[]), typeof(System.Object[]), 1\n\tv693 = adjustEvent.transactionId == 0;\n\tif (v693) goto L_017C;\n\t// 376 IsInst v419 @ X0_v43, typeof(System.Object), adjustEvent.transactionId (System.String)\nL_017C:\n\tv366 = v306.Length == 0;\n\tif (v366) goto L_01DF;\n\tv306[0] = adjustEvent.transactionId;\n\tUnityEngine.AndroidJavaObject::Call(v382, \"setOrderId\", v306);\nL_0189:\n\tv649 = adjustEvent.callbackId == 0;\n\tif (v649) goto L_01AD;\n\t// 397 NewArr v307 @ X0_v33 (System.Object[]), typeof(System.Object[]), 1\n\tv723 = adjustEvent.callbackId == 0;\n\tif (v723) goto L_019B;\n\t// 407 IsInst v420 @ X0_v37, typeof(System.Object), adjustEvent.callbackId (System.String)\nL_019B:\n\tv367 = v307.Length == 0;\n\tif (v367) goto L_01DF;\n\tv307[0] = adjustEvent.callbackId;\n\tUnityEngine.AndroidJavaObject::Call(v382, \"setCallbackId\", v307);\nL_01AD:\n\tgoto L_01B8;\n\tv694 = *([v670 @ X0_v22 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv695 = v694 == 0;\n\tv696 = ~v695;\n\tif (v696) goto L_01B8;\n\tv724 = \"il2cpp_codegen_runtime_class_init\"(v670, v659, v193, v184, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv698 = com.adjust.sdk.AdjustAndroid;\nL_01B8:\n\t// 440 NewArr v308 @ X0_v25 (System.Object[]), typeof(System.Object[]), 1\n\tv736 = v382 == 0;\n\tif (v736) goto L_01C5;\n\t// 449 IsInst v421 @ X0_v29, typeof(System.Object), v382 @ X0_v16 (UnityEngine.AndroidJavaObject)\nL_01C5:\n\tv368 = v308.Length == 0;\n\tif (v368) goto L_01DF;\n\tv308[0] = v382;\n\tUnityEngine.AndroidJavaObject::CallStatic(v321.ajcAdjust, \"trackEvent\", v308);\n\treturn;\nL_01DE:\n\tv323 = new System.NullReferenceException();\nL_01DF:\n\tv378 = new System.IndexOutOfRangeException();\n\tgoto L_01E4;\n\tv444 = new System.ArrayTypeMismatchException();\nL_01E4:\n\tthrow v468;\n// 292 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void TrackEvent(AdjustEvent adjustEvent)
		{
			//IL_00c2: Expected O, but got I
			//IL_00eb: Expected F8, but got O
			//IL_012d: Expected O, but got I4
			//IL_029e: Expected O, but got I
			//IL_0904: Expected O, but got I
			//IL_050a: Expected O, but got I
			//IL_0948: Expected O, but got I
			//IL_0a5a: Expected O, but got I
			//IL_01a1: Expected O, but got I4
			//IL_0345: Expected O, but got I4
			//IL_05b1: Expected O, but got I4
			//IL_09f2: Expected O, but got I
			//IL_0af6: Expected O, but got I
			//IL_03c1: Expected O, but got I4
			//IL_062d: Expected O, but got I4
			object[] array = new object[1];
			if (adjustEvent.eventToken != null)
			{
				object obj = adjustEvent.eventToken as object;
			}
			AndroidJavaObject androidJavaObject;
			if (array.Length != 0)
			{
				array[0] = adjustEvent.eventToken;
				androidJavaObject = new AndroidJavaObject("com.adjust.sdk.AdjustEvent", array);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustEvent @ X0 (com.adjust.sdk.AdjustEvent)+38]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_01db;
				}
				double? num = (double?)(object)((long)(IntPtr)adjustEvent + 48L);
				object[] array2 = new object[2];
				double value = ((double?*)num)->Value;
				object obj3 = default(object);
				object obj2 = (double)obj3;
				if (obj2 != null)
				{
					object obj4 = obj2 as object;
				}
				object obj5 = array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = obj2;
					if (adjustEvent.currency != null)
					{
						object obj6 = adjustEvent.currency as object;
						obj5 = array2.Length;
					}
					bool flag = (long)(IntPtr)obj5 < 1L;
					bool flag2 = !flag;
					object obj7 = (long)(IntPtr)obj5 - 1L;
					bool flag3 = obj7 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array2[1] = adjustEvent.currency;
						androidJavaObject.Call("setRevenue", array2);
						goto IL_01db;
					}
				}
			}
			goto IL_08b5;
			IL_01db:
			List<string> callbackList = adjustEvent.callbackList;
			if (adjustEvent.callbackList != null)
			{
				int num2 = 0;
				while (num2 < callbackList.Count)
				{
					bool flag5 = callbackList.Count < num2;
					bool flag6 = !flag5;
					int num3 = callbackList.Count - num2;
					bool flag7 = num3 == 0;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						int num4 = num2 << 3;
						object obj8 = (long)(IntPtr)callbackList._items + (long)num4;
						object obj9 = (long)(IntPtr)obj8 + 32L;
						int num5 = num2 + 1;
						bool flag9 = callbackList.Count < num5;
						bool flag10 = !flag9;
						int num6 = callbackList.Count - num5;
						bool flag11 = num6 == 0;
						bool flag12 = !flag11;
						if (!(flag10 && flag12))
						{
							throw new ArgumentOutOfRangeException();
						}
						string[] items = callbackList._items;
						object[] array3 = new object[2];
						if (obj9 != null)
						{
							object obj10 = obj9 as object;
						}
						object obj11 = array3.Length;
						if (array3.Length != 0)
						{
							array3[0] = obj9;
							if (items[num5] != null)
							{
								object obj12 = items[num5] as object;
								obj11 = array3.Length;
							}
							bool flag13 = (long)(IntPtr)obj11 < 1L;
							bool flag14 = !flag13;
							object obj13 = (long)(IntPtr)obj11 - 1L;
							bool flag15 = obj13 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array3[1] = items[num5];
								androidJavaObject.Call("addCallbackParameter", array3);
								callbackList = adjustEvent.callbackList;
								num2 = num5 + 1;
								if (adjustEvent.callbackList != null)
								{
									continue;
								}
								goto IL_09bb;
							}
						}
						goto IL_08b5;
					}
					throw new ArgumentOutOfRangeException();
				}
			}
			List<string> partnerList = adjustEvent.partnerList;
			if (adjustEvent.partnerList != null)
			{
				int num7 = 0;
				while (num7 < partnerList.Count)
				{
					bool flag17 = partnerList.Count < num7;
					bool flag18 = !flag17;
					int num8 = partnerList.Count - num7;
					bool flag19 = num8 == 0;
					bool flag20 = !flag18;
					if (!(flag20 || flag19))
					{
						int num9 = num7 << 3;
						object obj14 = (long)(IntPtr)partnerList._items + (long)num9;
						object obj15 = (long)(IntPtr)obj14 + 32L;
						int num10 = num7 + 1;
						bool flag21 = partnerList.Count < num10;
						bool flag22 = !flag21;
						int num11 = partnerList.Count - num10;
						bool flag23 = num11 == 0;
						bool flag24 = !flag23;
						if (!(flag22 && flag24))
						{
							throw new ArgumentOutOfRangeException();
						}
						string[] items2 = partnerList._items;
						object[] array4 = new object[2];
						if (obj15 != null)
						{
							object obj16 = obj15 as object;
						}
						object obj17 = array4.Length;
						if (array4.Length != 0)
						{
							array4[0] = obj15;
							if (items2[num10] != null)
							{
								object obj18 = items2[num10] as object;
								obj17 = array4.Length;
							}
							bool flag25 = (long)(IntPtr)obj17 < 1L;
							bool flag26 = !flag25;
							object obj19 = (long)(IntPtr)obj17 - 1L;
							bool flag27 = obj19 == null;
							bool flag28 = !flag26;
							if (!(flag28 || flag27))
							{
								array4[1] = items2[num10];
								androidJavaObject.Call("addPartnerParameter", array4);
								partnerList = adjustEvent.partnerList;
								num7 = num10 + 1;
								if (adjustEvent.partnerList != null)
								{
									continue;
								}
								goto IL_09bb;
							}
						}
						goto IL_08b5;
					}
					throw new ArgumentOutOfRangeException();
				}
			}
			if (adjustEvent.transactionId != null)
			{
				object[] array5 = new object[1];
				if (adjustEvent.transactionId != null)
				{
					object obj20 = adjustEvent.transactionId as object;
				}
				if (array5.Length == 0)
				{
					goto IL_08b5;
				}
				array5[0] = adjustEvent.transactionId;
				androidJavaObject.Call("setOrderId", array5);
			}
			if (adjustEvent.callbackId != null)
			{
				object[] array6 = new object[1];
				if (adjustEvent.callbackId != null)
				{
					object obj21 = adjustEvent.callbackId as object;
				}
				if (array6.Length == 0)
				{
					goto IL_08b5;
				}
				array6[0] = adjustEvent.callbackId;
				androidJavaObject.Call("setCallbackId", array6);
			}
			object[] array7 = new object[1];
			if (androidJavaObject != null)
			{
				object obj22 = androidJavaObject as object;
			}
			if (array7.Length != 0)
			{
				array7[0] = androidJavaObject;
				ajcAdjust.CallStatic("trackEvent", array7);
				return;
			}
			goto IL_08b5;
			IL_08b5:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_09bb:
			NullReferenceException ex3 = new NullReferenceException();
			goto IL_08b5;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x1567704", Offset = "0x1567704", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB32A8]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029089]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv122 = v79;\n\tv123 = 0x8907BC(v122, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0064;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"isEnabled\", v107.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsEnabled()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return ajcAdjust.CallStatic<bool>("isEnabled", Array.Empty<object>());
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x1567598", Offset = "0x1567598", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F06850]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202908A]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = com.adjust.sdk.AdjustAndroid;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &enabled @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"setEnabled\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetEnabled(bool enabled)
		{
			object[] array = new object[1];
			array = (object[])(object)enabled;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				ajcAdjust.CallStatic("setEnabled", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x156788C", Offset = "0x156788C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF2F68]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202908B]) = v40;\nL_001A:\n\tgoto L_0027;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = com.adjust.sdk.AdjustAndroid;\nL_0027:\n\t// 39 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\t// 46 Box v60 @ X0_v5 (System.Object[]), typeof(System.Boolean), &enabled @ X0 (System.Boolean)\n\tv71 = v60 == 0;\n\tif (v71) goto L_003B;\n\t// 55 IsInst v60 @ X0_v5 (System.Object[]), typeof(System.Object), v60 @ X0_v5 (System.Object[])\nL_003B:\n\tv89 = v60.Length == 0;\n\tif (v89) goto L_0050;\n\tv60[0] = v60;\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"setOfflineMode\", v60);\n\treturn;\n\tv81 = new System.NullReferenceException();\nL_0050:\n\tv94 = new System.IndexOutOfRangeException();\n\tgoto L_0055;\n\tv95 = new System.ArrayTypeMismatchException();\nL_0055:\n\tthrow v103;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetOfflineMode(bool enabled)
		{
			object[] array = new object[1];
			array = (object[])(object)enabled;
			if (array != null)
			{
				array = (object[])(array as object);
			}
			if (array.Length != 0)
			{
				array[0] = array;
				ajcAdjust.CallStatic("setOfflineMode", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x1568058", Offset = "0x1568058", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDB520]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202908C]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv119 = v79;\n\tv120 = 0x8907BC(v119, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0062;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"sendFirstPackages\", v106.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SendFirstPackages()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ajcAdjust.CallStatic("sendFirstPackages");
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x1567A00", Offset = "0x1567A00", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDDE28]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202908D]) = v42;\nL_001B:\n\tgoto L_0028;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0028;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = com.adjust.sdk.AdjustAndroid;\nL_0028:\n\t// 40 NewArr v62 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv66 = deviceToken == 0;\n\tif (v66) goto L_0034;\n\t// 49 IsInst v112 @ X0_v23, typeof(System.Object), deviceToken @ X0 (System.String)\nL_0034:\n\tv150 = v62.Length;\n\tv119 = v62.Length == 0;\n\tif (v119) goto L_0062;\n\tv62[0] = deviceToken;\n\tv154 = v140.ajoCurrentActivity == 0;\n\tif (v154) goto L_0044;\n\t// 64 IsInst v176 @ X0_v21, typeof(System.Object), v140.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\n\tv150 = v62.Length;\nL_0044:\n\tv185 = v150 < 1;\n\tv137 = ~v185;\n\tv135 = v150 - 1;\n\tv131 = v135 == 0;\n\tv186 = ~v137;\n\tv121 = v186 | v131;\n\tif (v121) goto L_0062;\n\tv62[1] = v140.ajoCurrentActivity;\n\tUnityEngine.AndroidJavaObject::CallStatic(v57.ajcAdjust, \"setPushToken\", v62);\n\treturn;\nL_0062:\n\tv171 = new System.IndexOutOfRangeException();\n\tgoto L_0067;\n\tv182 = new System.ArrayTypeMismatchException();\nL_0067:\n\tthrow v221;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetDeviceToken(string deviceToken)
		{
			//IL_003e: Expected O, but got I4
			//IL_012f: Expected O, but got I
			//IL_00aa: Expected O, but got I4
			object[] array = new object[2];
			if (deviceToken != null)
			{
				object obj = deviceToken as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = deviceToken;
				if (ajoCurrentActivity != null)
				{
					object obj3 = ajoCurrentActivity as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = ajoCurrentActivity;
					ajcAdjust.CallStatic("setPushToken", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x1568FAC", Offset = "0x1568FAC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEEDB0]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202908E]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv122 = v79;\n\tv123 = 0x8907BC(v122, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0064;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"getAdid\", v107.Value);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetAdid()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			return ajcAdjust.CallStatic<string>("getAdid", Array.Empty<object>());
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x1567B84", Offset = "0x1567B84", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDE818]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202908F]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\t// 38 NewArr v59 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv66 = v64.ajoCurrentActivity == 0;\n\tif (v66) goto L_0036;\n\t// 50 IsInst v71 @ X0_v18, typeof(System.Object), v64.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\nL_0036:\n\tv78 = v59.Length == 0;\n\tif (v78) goto L_004A;\n\tv59[0] = v64.ajoCurrentActivity;\n\tUnityEngine.AndroidJavaObject::CallStatic(v54.ajcAdjust, \"gdprForgetMe\", v59);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_004A:\n\tv84 = new System.IndexOutOfRangeException();\n\tgoto L_0051;\n\tv88 = new System.NullReferenceException();\n\tv91 = new System.ArrayTypeMismatchException();\nL_0051:\n\tthrow v106;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GdprForgetMe()
		{
			object[] array = new object[1];
			if (ajoCurrentActivity != null)
			{
				object obj = ajoCurrentActivity as object;
			}
			if (array.Length != 0)
			{
				array[0] = ajoCurrentActivity;
				ajcAdjust.CallStatic("gdprForgetMe", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x1567CDC", Offset = "0x1567CDC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8E40]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029090]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\t// 38 NewArr v59 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv66 = v64.ajoCurrentActivity == 0;\n\tif (v66) goto L_0036;\n\t// 50 IsInst v71 @ X0_v18, typeof(System.Object), v64.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\nL_0036:\n\tv78 = v59.Length == 0;\n\tif (v78) goto L_004A;\n\tv59[0] = v64.ajoCurrentActivity;\n\tUnityEngine.AndroidJavaObject::CallStatic(v54.ajcAdjust, \"disableThirdPartySharing\", v59);\n\treturn;\n\tv67 = new System.NullReferenceException();\nL_004A:\n\tv84 = new System.IndexOutOfRangeException();\n\tgoto L_0051;\n\tv88 = new System.NullReferenceException();\n\tv91 = new System.ArrayTypeMismatchException();\nL_0051:\n\tthrow v106;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DisableThirdPartySharing()
		{
			object[] array = new object[1];
			if (ajoCurrentActivity != null)
			{
				object obj = ajoCurrentActivity as object;
			}
			if (array.Length != 0)
			{
				array[0] = ajoCurrentActivity;
				ajcAdjust.CallStatic("disableThirdPartySharing", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x156912C", Offset = "0x156912C", Length = "0x684")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF3A20]);\n\tv23 = *([v22 @ X8_v103]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2029091]) = v43;\nL_001B:\n\tgoto L_0028;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0028;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = com.adjust.sdk.AdjustAndroid;\nL_0028:\n\tv63 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv69 = v63;\n\tv70 = UnityEngine.AndroidJavaObject::CallStatic(v69, v25, v26, v27);\n\tv73 = *([v63 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0031:\n\tv74 = *([v63 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv75 = v74 == 0;\n\tif (v75) goto L_0052;\n\tv77 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003E;\n\tv99 = v77;\n\tv100 = UnityEngine.AndroidJavaObject::CallStatic(v99, v25, v26, v27);\nL_003E:\n\tv101 = *([v77 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv89 = ~v101;\n\tif (v89) goto L_0052;\n\tgoto L_0052;\n\tv121 = v83;\n\tv122 = UnityEngine.AndroidJavaObject::CallStatic(v121, v25, v26, v27);\nL_0052:\n\tgoto L_0060;\n\tv102 = v94;\n\tv103 = UnityEngine.AndroidJavaObject::CallStatic(v102, v25, v26, v27);\nL_0060:\n\tv118 = UnityEngine.AndroidJavaObject::CallStatic(v59.ajcAdjust, \"getAttribution\", v110.Value);\n\tv126 = v118 == 0;\n\tif (v126) goto L_FFFFFFFF;\n\tv160 = new com.adjust.sdk.AdjustAttribution();\n\tSystem.Object::.ctor(v160);\n\tgoto L_007F;\n\tv293 = *([v248 @ X0_v33 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_007F;\n\tv308 = \"il2cpp_codegen_runtime_class_init\"(v248, v209, v114, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv297 = com.adjust.sdk.AdjustUtils;\nL_007F:\n\tv304 = UnityEngine.AndroidJavaObject::Get(v118, v151.KeyTrackerName);\n\tv310 = System.String::op_Equality(v304, \"\");\n\tv313 = v310 == 0;\n\tif (v313) goto L_0091;\n\tv316 = v160 == 0;\n\tv148 = ~v316;\n\tif (v148) goto L_009F;\n\tgoto L_01C3;\nL_0091:\n\tgoto L_009C;\n\tv332 = *([v317 @ X0_v144 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv333 = v332 == 0;\n\tv334 = ~v333;\n\tif (v334) goto L_009C;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v317, v135, v138, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv336 = com.adjust.sdk.AdjustUtils;\nL_009C:\n\tv325 = UnityEngine.AndroidJavaObject::Get(v118, v152.KeyTrackerName);\n\tv149 = v160 == 0;\n\tif (v149) goto L_01C3;\nL_009F:\n\tv160.<trackerName>k__BackingField = v325;\n\tgoto L_00AF;\n\tv340 = *([v328 @ X0_v39 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv341 = v340 == 0;\n\tv342 = ~v341;\n\tif (v342) goto L_00AF;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v328, v323, v324, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv344 = com.adjust.sdk.AdjustUtils;\nL_00AF:\n\tv351 = UnityEngine.AndroidJavaObject::Get(v118, v347.KeyTrackerToken);\n\tv356 = System.String::op_Equality(v351, \"\");\n\tv358 = v356 == 0;\n\tif (v358) goto L_00BC;\n\tgoto L_00C8;\nL_00BC:\n\tgoto L_00C7;\n\tv378 = *([v360 @ X0_v135 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_00C7;\n\tv397 = \"il2cpp_codegen_runtime_class_init\"(v360, v354, v355, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv382 = com.adjust.sdk.AdjustUtils;\nL_00C7:\n\tv368 = UnityEngine.AndroidJavaObject::Get(v118, v373.KeyTrackerToken);\nL_00C8:\n\tv160.<trackerToken>k__BackingField = v368;\n\tgoto L_00D8;\n\tv385 = *([v374 @ X0_v45 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv386 = v385 == 0;\n\tv387 = ~v386;\n\tif (v387) goto L_00D8;\n\tv398 = \"il2cpp_codegen_runtime_class_init\"(v374, v364, v366, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv389 = com.adjust.sdk.AdjustUtils;\nL_00D8:\n\tv396 = UnityEngine.AndroidJavaObject::Get(v118, v392.KeyNetwork);\n\tv401 = System.String::op_Equality(v396, \"\");\n\tv403 = v401 == 0;\n\tif (v403) goto L_00E5;\n\tgoto L_00F1;\nL_00E5:\n\tgoto L_00F0;\n\tv423 = *([v405 @ X0_v126 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv424 = v423 == 0;\n\tv425 = ~v424;\n\tif (v425) goto L_00F0;\n\tv442 = \"il2cpp_codegen_runtime_class_init\"(v405, v399, v400, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv427 = com.adjust.sdk.AdjustUtils;\nL_00F0:\n\tv413 = UnityEngine.AndroidJavaObject::Get(v118, v418.KeyNetwork);\nL_00F1:\n\tv160.<network>k__BackingField = v413;\n\tgoto L_0101;\n\tv430 = *([v419 @ X0_v51 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv431 = v430 == 0;\n\tv432 = ~v431;\n\tif (v432) goto L_0101;\n\tv443 = \"il2cpp_codegen_runtime_class_init\"(v419, v409, v411, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv434 = com.adjust.sdk.AdjustUtils;\nL_0101:\n\tv441 = UnityEngine.AndroidJavaObject::Get(v118, v437.KeyCampaign);\n\tv446 = System.String::op_Equality(v441, \"\");\n\tv448 = v446 == 0;\n\tif (v448) goto L_010E;\n\tgoto L_011A;\nL_010E:\n\tgoto L_0119;\n\tv468 = *([v450 @ X0_v117 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv469 = v468 == 0;\n\tv470 = ~v469;\n\tif (v470) goto L_0119;\n\tv487 = \"il2cpp_codegen_runtime_class_init\"(v450, v444, v445, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv472 = com.adjust.sdk.AdjustUtils;\nL_0119:\n\tv458 = UnityEngine.AndroidJavaObject::Get(v118, v463.KeyCampaign);\nL_011A:\n\tv160.<campaign>k__BackingField = v458;\n\tgoto L_012A;\n\tv475 = *([v464 @ X0_v57 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv476 = v475 == 0;\n\tv477 = ~v476;\n\tif (v477) goto L_012A;\n\tv488 = \"il2cpp_codegen_runtime_class_init\"(v464, v454, v456, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv479 = com.adjust.sdk.AdjustUtils;\nL_012A:\n\tv486 = UnityEngine.AndroidJavaObject::Get(v118, v482.KeyAdgroup);\n\tv491 = System.String::op_Equality(v486, \"\");\n\tv493 = v491 == 0;\n\tif (v493) goto L_0137;\n\tgoto L_0143;\nL_0137:\n\tgoto L_0142;\n\tv513 = *([v495 @ X0_v108 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv514 = v513 == 0;\n\tv515 = ~v514;\n\tif (v515) goto L_0142;\n\tv532 = \"il2cpp_codegen_runtime_class_init\"(v495, v489, v490, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv517 = com.adjust.sdk.AdjustUtils;\nL_0142:\n\tv503 = UnityEngine.AndroidJavaObject::Get(v118, v508.KeyAdgroup);\nL_0143:\n\tv160.<adgroup>k__BackingField = v503;\n\tgoto L_0153;\n\tv520 = *([v509 @ X0_v63 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv521 = v520 == 0;\n\tv522 = ~v521;\n\tif (v522) goto L_0153;\n\tv533 = \"il2cpp_codegen_runtime_class_init\"(v509, v499, v501, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv524 = com.adjust.sdk.AdjustUtils;\nL_0153:\n\tv531 = UnityEngine.AndroidJavaObject::Get(v118, v527.KeyCreative);\n\tv536 = System.String::op_Equality(v531, \"\");\n\tv538 = v536 == 0;\n\tif (v538) goto L_0160;\n\tgoto L_016C;\nL_0160:\n\tgoto L_016B;\n\tv558 = *([v540 @ X0_v99 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv559 = v558 == 0;\n\tv560 = ~v559;\n\tif (v560) goto L_016B;\n\tv577 = \"il2cpp_codegen_runtime_class_init\"(v540, v534, v535, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv562 = com.adjust.sdk.AdjustUtils;\nL_016B:\n\tv548 = UnityEngine.AndroidJavaObject::Get(v118, v553.KeyCreative);\nL_016C:\n\tv160.<creative>k__BackingField = v548;\n\tgoto L_017C;\n\tv565 = *([v554 @ X0_v69 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv566 = v565 == 0;\n\tv567 = ~v566;\n\tif (v567) goto L_017C;\n\tv578 = \"il2cpp_codegen_runtime_class_init\"(v554, v544, v546, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv569 = com.adjust.sdk.AdjustUtils;\nL_017C:\n\tv576 = UnityEngine.AndroidJavaObject::Get(v118, v572.KeyClickLabel);\n\tv581 = System.String::op_Equality(v576, \"\");\n\tv583 = v581 == 0;\n\tif (v583) goto L_0189;\n\tgoto L_0195;\nL_0189:\n\tgoto L_0194;\n\tv603 = *([v585 @ X0_v90 (Il2CppClass<com.adjust.sdk.AdjustUtils>)+E0]);\n\tv604 = v603 == 0;\n\tv605 = ~v604;\n\tif (v605) goto L_0194;\n\tv622 = \"il2cpp_codegen_runtime_class_init\"(v585, v579, v580, v116, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv607 = com.adjust.s\n// ... truncated")]
		public static AdjustAttribution GetAttribution()
		{
			//IL_039e: Expected I, but got O
			//IL_02fb: Expected O, but got I
			//IL_0310: Expected O, but got I
			//IL_0212: Expected O, but got I
			//IL_021e: Expected I, but got O
			//IL_0294: Expected O, but got I
			//IL_0294: Expected O, but got I
			//IL_0294: Expected O, but got I4
			//IL_02af: Expected O, but got I4
			//IL_02dd: Expected I, but got O
			//IL_026f: Expected O, but got I
			//IL_026f: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X20_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = ajcAdjust.CallStatic<AndroidJavaObject>("getAttribution", Array.Empty<object>());
			AdjustAttribution adjustAttribution;
			string trackerName;
			if (androidJavaObject != null)
			{
				adjustAttribution = new AdjustAttribution();
				string text = androidJavaObject.Get<string>(AdjustUtils.KeyTrackerName);
				string text2 = default(string);
				IntPtr intPtr3 = default(IntPtr);
				if (text == "")
				{
					bool flag = adjustAttribution == null;
					bool flag2 = !flag;
					trackerName = null;
					if (flag2)
					{
						goto IL_00ca;
					}
				}
				else
				{
					trackerName = androidJavaObject.Get<string>(AdjustUtils.KeyTrackerName);
					bool flag3 = adjustAttribution == null;
					text2 = "";
					intPtr3 = (IntPtr)null;
					if (!flag3)
					{
						goto IL_00ca;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				bool flag4 = (IntPtr)text2 != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag4)
				{
					AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)(object)ex).CallStatic<AndroidJavaObject>(text2, (object[])(long)intPtr3);
					IntPtr intPtr4 = (IntPtr)androidJavaObject2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					AndroidJavaObject androidJavaObject3 = default(AndroidJavaObject);
					if ((uint)((ulong)(long)(IntPtr)androidJavaObject3 & 1uL) != 0)
					{
						AndroidJavaObject androidJavaObject4 = androidJavaObject3.CallStatic<AndroidJavaObject>((string)(long)intPtr4, (object[])(long)intPtr3);
						goto IL_0278;
					}
					AndroidJavaObject androidJavaObject5 = ((AndroidJavaObject)8).CallStatic<AndroidJavaObject>((string)(long)intPtr4, (object[])(long)intPtr3);
					androidJavaObject5 = androidJavaObject2;
					text2 = (string)(32022528 + 2160);
					AndroidJavaObject androidJavaObject6 = androidJavaObject5.CallStatic<AndroidJavaObject>(text2, (object[])null);
					AndroidJavaObject androidJavaObject7 = androidJavaObject6.CallStatic<AndroidJavaObject>(text2, (object[])null);
					intPtr3 = (IntPtr)null;
					ex2 = (NullReferenceException)(object)androidJavaObject6;
				}
				AndroidJavaObject androidJavaObject8 = ((AndroidJavaObject)(object)ex2).CallStatic<AndroidJavaObject>(text2, (object[])(long)intPtr3);
				return (AdjustAttribution)(object)androidJavaObject8.CallStatic<AndroidJavaObject>(text2, (object[])(long)intPtr3);
			}
			goto IL_0278;
			IL_00ca:
			adjustAttribution.trackerName = trackerName;
			string text3 = androidJavaObject.Get<string>(AdjustUtils.KeyTrackerToken);
			string trackerToken = ((!(text3 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyTrackerToken) : null);
			adjustAttribution.trackerToken = trackerToken;
			string text4 = androidJavaObject.Get<string>(AdjustUtils.KeyNetwork);
			string network = ((!(text4 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyNetwork) : null);
			adjustAttribution.network = network;
			string text5 = androidJavaObject.Get<string>(AdjustUtils.KeyCampaign);
			string campaign = ((!(text5 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyCampaign) : null);
			adjustAttribution.campaign = campaign;
			string text6 = androidJavaObject.Get<string>(AdjustUtils.KeyAdgroup);
			string adgroup = ((!(text6 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyAdgroup) : null);
			adjustAttribution.adgroup = adgroup;
			string text7 = androidJavaObject.Get<string>(AdjustUtils.KeyCreative);
			string creative = ((!(text7 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyCreative) : null);
			adjustAttribution.creative = creative;
			string text8 = androidJavaObject.Get<string>(AdjustUtils.KeyClickLabel);
			string clickLabel = ((!(text8 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyClickLabel) : null);
			adjustAttribution.clickLabel = clickLabel;
			string text9 = androidJavaObject.Get<string>(AdjustUtils.KeyAdid);
			string adid = ((!(text9 == "")) ? androidJavaObject.Get<string>(AdjustUtils.KeyAdid) : null);
			adjustAttribution.adid = adid;
			return adjustAttribution;
			IL_0278:
			return null;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x15681E8", Offset = "0x15681E8", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDD1B0]);\n\tv25 = *([v24 @ X8_v36]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029092]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = com.adjust.sdk.AdjustAndroid;\nL_0025:\n\tv59 = v57.ajcAdjust == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0042;\n\tv65 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v65, \"com.adjust.sdk.Adjust\");\n\tgoto L_003E;\n\tv104 = *([v97 @ X0_v31 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_003E;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v97, v67, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv107 = com.adjust.sdk.AdjustAndroid;\nL_003E:\n\tv75.ajcAdjust = v65;\nL_0042:\n\tgoto L_004F;\n\tv83 = *([v70 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tgoto L_004F;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v70, v66, v68, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv87 = com.adjust.sdk.AdjustAndroid;\nL_004F:\n\t// 79 NewArr v96 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\tv109 = key == 0;\n\tif (v109) goto L_005B;\n\t// 88 IsInst v152 @ X0_v25, typeof(System.Object), key @ X0 (System.String)\nL_005B:\n\tv186 = v96.Length;\n\tv159 = v96.Length == 0;\n\tif (v159) goto L_0086;\n\tv96[0] = key;\n\tv189 = value == 0;\n\tif (v189) goto L_0068;\n\t// 100 IsInst v208 @ X0_v23, typeof(System.Object), value @ X1 (System.String)\n\tv186 = v96.Length;\nL_0068:\n\tv216 = v186 < 1;\n\tv177 = ~v216;\n\tv175 = v186 - 1;\n\tv171 = v175 == 0;\n\tv217 = ~v177;\n\tv161 = v217 | v171;\n\tif (v161) goto L_0086;\n\tv96[1] = value;\n\tUnityEngine.AndroidJavaObject::CallStatic(v91.ajcAdjust, \"addSessionPartnerParameter\", v96);\n\treturn;\nL_0086:\n\tv204 = new System.IndexOutOfRangeException();\n\tgoto L_008B;\n\tv213 = new System.ArrayTypeMismatchException();\nL_008B:\n\tthrow v251;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddSessionPartnerParameter(string key, string value)
		{
			//IL_0057: Expected O, but got I4
			//IL_017c: Expected O, but got I
			//IL_00c1: Expected O, but got I4
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			object[] array = new object[2];
			if (key != null)
			{
				object obj = key as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = key;
				if (value != null)
				{
					object obj3 = value as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = value;
					ajcAdjust.CallStatic("addSessionPartnerParameter", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x15683EC", Offset = "0x15683EC", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0C538]);\n\tv25 = *([v24 @ X8_v36]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029093]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = com.adjust.sdk.AdjustAndroid;\nL_0025:\n\tv59 = v57.ajcAdjust == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0042;\n\tv65 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v65, \"com.adjust.sdk.Adjust\");\n\tgoto L_003E;\n\tv104 = *([v97 @ X0_v31 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_003E;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v97, v67, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv107 = com.adjust.sdk.AdjustAndroid;\nL_003E:\n\tv75.ajcAdjust = v65;\nL_0042:\n\tgoto L_004F;\n\tv83 = *([v70 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tgoto L_004F;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v70, v66, v68, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv87 = com.adjust.sdk.AdjustAndroid;\nL_004F:\n\t// 79 NewArr v96 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\tv109 = key == 0;\n\tif (v109) goto L_005B;\n\t// 88 IsInst v152 @ X0_v25, typeof(System.Object), key @ X0 (System.String)\nL_005B:\n\tv186 = v96.Length;\n\tv159 = v96.Length == 0;\n\tif (v159) goto L_0086;\n\tv96[0] = key;\n\tv189 = value == 0;\n\tif (v189) goto L_0068;\n\t// 100 IsInst v208 @ X0_v23, typeof(System.Object), value @ X1 (System.String)\n\tv186 = v96.Length;\nL_0068:\n\tv216 = v186 < 1;\n\tv177 = ~v216;\n\tv175 = v186 - 1;\n\tv171 = v175 == 0;\n\tv217 = ~v177;\n\tv161 = v217 | v171;\n\tif (v161) goto L_0086;\n\tv96[1] = value;\n\tUnityEngine.AndroidJavaObject::CallStatic(v91.ajcAdjust, \"addSessionCallbackParameter\", v96);\n\treturn;\nL_0086:\n\tv204 = new System.IndexOutOfRangeException();\n\tgoto L_008B;\n\tv213 = new System.ArrayTypeMismatchException();\nL_008B:\n\tthrow v251;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddSessionCallbackParameter(string key, string value)
		{
			//IL_0057: Expected O, but got I4
			//IL_017c: Expected O, but got I
			//IL_00c1: Expected O, but got I4
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			object[] array = new object[2];
			if (key != null)
			{
				object obj = key as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = key;
				if (value != null)
				{
					object obj3 = value as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = value;
					ajcAdjust.CallStatic("addSessionCallbackParameter", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x15685E0", Offset = "0x15685E0", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC3AE8]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029094]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = com.adjust.sdk.AdjustAndroid;\nL_0023:\n\tv56 = v54.ajcAdjust == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0040;\n\tv62 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v62, \"com.adjust.sdk.Adjust\");\n\tgoto L_003C;\n\tv101 = *([v94 @ X0_v26 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_003C;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v94, v64, v66, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = com.adjust.sdk.AdjustAndroid;\nL_003C:\n\tv72.ajcAdjust = v62;\nL_0040:\n\tgoto L_004D;\n\tv80 = *([v67 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_004D;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v67, v63, v65, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv84 = com.adjust.sdk.AdjustAndroid;\nL_004D:\n\t// 77 NewArr v93 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\tv106 = key == 0;\n\tif (v106) goto L_005A;\n\t// 86 IsInst v112 @ X0_v20, typeof(System.Object), key @ X0 (System.String)\nL_005A:\n\tv119 = v93.Length == 0;\n\tif (v119) goto L_006E;\n\tv93[0] = key;\n\tUnityEngine.AndroidJavaObject::CallStatic(v88.ajcAdjust, \"removeSessionPartnerParameter\", v93);\n\treturn;\n\tv107 = new System.NullReferenceException();\nL_006E:\n\tv124 = new System.IndexOutOfRangeException();\n\tgoto L_0075;\n\tv128 = new System.NullReferenceException();\n\tv131 = new System.ArrayTypeMismatchException();\nL_0075:\n\tthrow v145;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveSessionPartnerParameter(string key)
		{
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
			}
			if (array.Length != 0)
			{
				array[0] = key;
				ajcAdjust.CallStatic("removeSessionPartnerParameter", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x15687A8", Offset = "0x15687A8", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB14E8]);\n\tv21 = *([v20 @ X8_v31]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029095]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = com.adjust.sdk.AdjustAndroid;\nL_0023:\n\tv56 = v54.ajcAdjust == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0040;\n\tv62 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v62, \"com.adjust.sdk.Adjust\");\n\tgoto L_003C;\n\tv101 = *([v94 @ X0_v26 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_003C;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v94, v64, v66, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv104 = com.adjust.sdk.AdjustAndroid;\nL_003C:\n\tv72.ajcAdjust = v62;\nL_0040:\n\tgoto L_004D;\n\tv80 = *([v67 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_004D;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v67, v63, v65, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv84 = com.adjust.sdk.AdjustAndroid;\nL_004D:\n\t// 77 NewArr v93 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\tv106 = key == 0;\n\tif (v106) goto L_005A;\n\t// 86 IsInst v112 @ X0_v20, typeof(System.Object), key @ X0 (System.String)\nL_005A:\n\tv119 = v93.Length == 0;\n\tif (v119) goto L_006E;\n\tv93[0] = key;\n\tUnityEngine.AndroidJavaObject::CallStatic(v88.ajcAdjust, \"removeSessionCallbackParameter\", v93);\n\treturn;\n\tv107 = new System.NullReferenceException();\nL_006E:\n\tv124 = new System.IndexOutOfRangeException();\n\tgoto L_0075;\n\tv128 = new System.NullReferenceException();\n\tv131 = new System.ArrayTypeMismatchException();\nL_0075:\n\tthrow v145;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveSessionCallbackParameter(string key)
		{
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			object[] array = new object[1];
			if (key != null)
			{
				object obj = key as object;
			}
			if (array.Length != 0)
			{
				array[0] = key;
				ajcAdjust.CallStatic("removeSessionCallbackParameter", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x1568968", Offset = "0x1568968", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB3848]);\n\tv19 = *([v18 @ X8_v37]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029096]) = v39;\nL_0019:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0022:\n\tv55 = v53.ajcAdjust == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_003F;\n\tv61 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v61, \"com.adjust.sdk.Adjust\");\n\tgoto L_003B;\n\tv109 = *([v97 @ X0_v29 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_003B;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v97, v63, v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv112 = com.adjust.sdk.AdjustAndroid;\nL_003B:\n\tv71.ajcAdjust = v61;\nL_003F:\n\tgoto L_004C;\n\tv79 = *([v66 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_004C;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v66, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv83 = com.adjust.sdk.AdjustAndroid;\nL_004C:\n\tv92 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0055;\n\tv102 = v92;\n\tv103 = 0x8907BC(v102, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv106 = *([v92 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0055:\n\tv107 = *([v92 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv108 = v107 == 0;\n\tif (v108) goto L_0076;\n\tv115 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0062;\n\tv138 = v115;\n\tv139 = 0x8907BC(v138, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tv140 = *([v115 @ X20_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv127 = ~v140;\n\tif (v127) goto L_0076;\n\tgoto L_0076;\n\tv162 = v121;\n\tv163 = 0x8907BC(v162, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0076:\n\tgoto L_0088;\n\tv141 = v132;\n\tv142 = 0x8907BC(v141, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0088:\n\tUnityEngine.AndroidJavaObject::CallStatic(v88.ajcAdjust, \"resetSessionPartnerParameters\", v149.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResetSessionPartnerParameters()
		{
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ajcAdjust.CallStatic("resetSessionPartnerParameters");
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x1568B50", Offset = "0x1568B50", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0F540]);\n\tv19 = *([v18 @ X8_v37]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029097]) = v39;\nL_0019:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0022:\n\tv55 = v53.ajcAdjust == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_003F;\n\tv61 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v61, \"com.adjust.sdk.Adjust\");\n\tgoto L_003B;\n\tv109 = *([v97 @ X0_v29 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_003B;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v97, v63, v65, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv112 = com.adjust.sdk.AdjustAndroid;\nL_003B:\n\tv71.ajcAdjust = v61;\nL_003F:\n\tgoto L_004C;\n\tv79 = *([v66 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_004C;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v66, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv83 = com.adjust.sdk.AdjustAndroid;\nL_004C:\n\tv92 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0055;\n\tv102 = v92;\n\tv103 = 0x8907BC(v102, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv106 = *([v92 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0055:\n\tv107 = *([v92 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv108 = v107 == 0;\n\tif (v108) goto L_0076;\n\tv115 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0062;\n\tv138 = v115;\n\tv139 = 0x8907BC(v138, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tv140 = *([v115 @ X20_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv127 = ~v140;\n\tif (v127) goto L_0076;\n\tgoto L_0076;\n\tv162 = v121;\n\tv163 = 0x8907BC(v162, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0076:\n\tgoto L_0088;\n\tv141 = v132;\n\tv142 = 0x8907BC(v141, v62, v64, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0088:\n\tUnityEngine.AndroidJavaObject::CallStatic(v88.ajcAdjust, \"resetSessionCallbackParameters\", v149.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ResetSessionCallbackParameters()
		{
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ajcAdjust.CallStatic("resetSessionCallbackParameters");
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x1567E3C", Offset = "0x1567E3C", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EA3E28]);\n\tv25 = *([v24 @ X8_v31]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029098]) = v44;\nL_0019:\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"android.net.Uri\");\n\t// 36 NewArr v58 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv61 = url == 0;\n\tif (v61) goto L_0031;\n\t// 45 IsInst v89 @ X0_v33, typeof(System.Object), url @ X0 (System.String)\nL_0031:\n\tv96 = v58.Length == 0;\n\tif (v96) goto L_008D;\n\tv58[0] = url;\n\tv196 = UnityEngine.AndroidJavaObject::CallStatic(v48, \"parse\", v58);\n\tgoto L_0052;\n\tv225 = *([v221 @ X8_v16 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv226 = v225 == 0;\n\tv227 = ~v226;\n\tif (v227) goto L_0052;\n\tv269 = v221;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v269, v195, v74, v65, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv232 = com.adjust.sdk.AdjustAndroid;\nL_0052:\n\t// 82 NewArr v76 @ X0_v22 (System.Object[]), typeof(System.Object[]), 2\n\tv270 = v196 == 0;\n\tif (v270) goto L_005E;\n\t// 91 IsInst v108 @ X0_v29, typeof(System.Object), v196 @ X0_v19 (UnityEngine.AndroidJavaObject)\nL_005E:\n\tv164 = v76.Length;\n\tv159 = v76.Length == 0;\n\tif (v159) goto L_008D;\n\tv76[0] = v196;\n\tv275 = v100.ajoCurrentActivity == 0;\n\tif (v275) goto L_006E;\n\t// 106 IsInst v109 @ X0_v27, typeof(System.Object), v100.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\n\tv164 = v76.Length;\nL_006E:\n\tv278 = v164 < 1;\n\tv146 = ~v278;\n\tv143 = v164 - 1;\n\tv137 = v143 == 0;\n\tv279 = ~v146;\n\tv122 = v279 | v137;\n\tif (v122) goto L_008D;\n\tv76[1] = v100.ajoCurrentActivity;\n\tUnityEngine.AndroidJavaObject::CallStatic(v82.ajcAdjust, \"appWillOpenUrl\", v76);\n\treturn;\nL_008D:\n\tv166 = new System.IndexOutOfRangeException();\n\tgoto L_0093;\n\tv85 = new System.NullReferenceException();\n\tv118 = new System.ArrayTypeMismatchException();\nL_0093:\n\tthrow v182;\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AppWillOpenUrl(string url)
		{
			//IL_00be: Expected O, but got I4
			//IL_01cc: Expected O, but got I
			//IL_012a: Expected O, but got I4
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.net.Uri");
			object[] array = new object[1];
			if (url != null)
			{
				object obj = url as object;
			}
			if (array.Length != 0)
			{
				array[0] = url;
				AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("parse", array);
				object[] array2 = new object[2];
				if (androidJavaObject != null)
				{
					object obj2 = androidJavaObject as object;
				}
				object obj3 = array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = androidJavaObject;
					if (ajoCurrentActivity != null)
					{
						object obj4 = ajoCurrentActivity as object;
						obj3 = array2.Length;
					}
					bool flag = (long)(IntPtr)obj3 < 1L;
					bool flag2 = !flag;
					object obj5 = (long)(IntPtr)obj3 - 1L;
					bool flag3 = obj5 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array2[1] = ajoCurrentActivity;
						ajcAdjust.CallStatic("appWillOpenUrl", array2);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x1568D50", Offset = "0x1568D50", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EDD3B0]);\n\tv27 = *([v26 @ X8_v43]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, payload, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029099]) = v45;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, payload, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv56 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv61 = v59.ajcAdjust == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0044;\n\tv67 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v67, \"com.adjust.sdk.Adjust\");\n\tgoto L_003F;\n\tv113 = *([v89 @ X0_v39 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_003F;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v89, v69, v71, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv116 = com.adjust.sdk.AdjustAndroid;\nL_003F:\n\tv77.ajcAdjust = v67;\nL_0044:\n\t// 68 NewArr v84 @ X0_v6 (System.Object[]), typeof(System.Object[]), 1\n\tv93 = payload == 0;\n\tif (v93) goto L_0051;\n\t// 77 IsInst v121 @ X0_v35, typeof(System.Object), payload @ X1 (System.String)\nL_0051:\n\tv128 = v84.Length == 0;\n\tif (v128) goto L_00A6;\n\tv84[0] = payload;\n\tv151 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v151, \"org.json.JSONObject\", v84);\n\tgoto L_006E;\n\tv246 = *([v242 @ X0_v21 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_006E;\n\tv288 = \"il2cpp_codegen_runtime_class_init\"(v242, v220, v101, v97, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv250 = com.adjust.sdk.AdjustAndroid;\nL_006E:\n\t// 110 NewArr v103 @ X0_v24 (System.Object[]), typeof(System.Object[]), 2\n\tv289 = source == 0;\n\tif (v289) goto L_007A;\n\t// 119 IsInst v136 @ X0_v31, typeof(System.Object), source @ X0 (System.String)\nL_007A:\n\tv194 = v103.Length;\n\tv189 = v103.Length == 0;\n\tif (v189) goto L_00A6;\n\tv103[0] = source;\n\tv293 = v151 == 0;\n\tif (v293) goto L_0087;\n\t// 131 IsInst v137 @ X0_v29, typeof(System.Object), v151 @ X0_v20 (UnityEngine.AndroidJavaObject)\n\tv194 = v103.Length;\nL_0087:\n\tv296 = v194 < 1;\n\tv178 = ~v296;\n\tv175 = v194 - 1;\n\tv169 = v175 == 0;\n\tv297 = ~v178;\n\tv154 = v297 | v169;\n\tif (v154) goto L_00A6;\n\tv103[1] = v151;\n\tUnityEngine.AndroidJavaObject::CallStatic(v109.ajcAdjust, \"trackAdRevenue\", v103);\n\treturn;\nL_00A6:\n\tv196 = new System.IndexOutOfRangeException();\n\tgoto L_00AC;\n\tv112 = new System.NullReferenceException();\n\tv146 = new System.ArrayTypeMismatchException();\nL_00AC:\n\tthrow v210;\n\tthrow System.NullReferenceException;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void TrackAdRevenue(string source, string payload)
		{
			//IL_00d4: Expected O, but got I4
			//IL_01f9: Expected O, but got I
			//IL_013e: Expected O, but got I4
			if (ajcAdjust == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
				ajcAdjust = androidJavaClass;
			}
			object[] array = new object[1];
			if (payload != null)
			{
				object obj = payload as object;
			}
			if (array.Length != 0)
			{
				array[0] = payload;
				AndroidJavaObject androidJavaObject = new AndroidJavaObject("org.json.JSONObject", array);
				object[] array2 = new object[2];
				if (source != null)
				{
					object obj2 = source as object;
				}
				object obj3 = array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = source;
					if (androidJavaObject != null)
					{
						object obj4 = androidJavaObject as object;
						obj3 = array2.Length;
					}
					bool flag = (long)(IntPtr)obj3 < 1L;
					bool flag2 = !flag;
					object obj5 = (long)(IntPtr)obj3 - 1L;
					bool flag3 = obj5 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array2[1] = androidJavaObject;
						ajcAdjust.CallStatic("trackAdRevenue", array2);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x1565E3C", Offset = "0x1565E3C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFE9A0]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202909A]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv119 = v79;\n\tv120 = 0x8907BC(v119, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0062;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"onPause\", v106.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnPause()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ajcAdjust.CallStatic("onPause");
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x1565F58", Offset = "0x1565F58", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F051C0]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202909B]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv119 = v79;\n\tv120 = 0x8907BC(v119, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_0062;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tUnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"onResume\", v106.Value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnResume()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			ajcAdjust.CallStatic("onResume");
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x1569AB8", Offset = "0x1569AB8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB6D88]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202909C]) = v42;\nL_001B:\n\tgoto L_0028;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0028;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = com.adjust.sdk.AdjustAndroid;\nL_0028:\n\t// 40 NewArr v62 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv66 = referrer == 0;\n\tif (v66) goto L_0034;\n\t// 49 IsInst v112 @ X0_v23, typeof(System.Object), referrer @ X0 (System.String)\nL_0034:\n\tv150 = v62.Length;\n\tv119 = v62.Length == 0;\n\tif (v119) goto L_0062;\n\tv62[0] = referrer;\n\tv154 = v140.ajoCurrentActivity == 0;\n\tif (v154) goto L_0044;\n\t// 64 IsInst v176 @ X0_v21, typeof(System.Object), v140.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\n\tv150 = v62.Length;\nL_0044:\n\tv185 = v150 < 1;\n\tv137 = ~v185;\n\tv135 = v150 - 1;\n\tv131 = v135 == 0;\n\tv186 = ~v137;\n\tv121 = v186 | v131;\n\tif (v121) goto L_0062;\n\tv62[1] = v140.ajoCurrentActivity;\n\tUnityEngine.AndroidJavaObject::CallStatic(v57.ajcAdjust, \"setReferrer\", v62);\n\treturn;\nL_0062:\n\tv171 = new System.IndexOutOfRangeException();\n\tgoto L_0067;\n\tv182 = new System.ArrayTypeMismatchException();\nL_0067:\n\tthrow v221;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetReferrer(string referrer)
		{
			//IL_003e: Expected O, but got I4
			//IL_012f: Expected O, but got I
			//IL_00aa: Expected O, but got I4
			object[] array = new object[2];
			if (referrer != null)
			{
				object obj = referrer as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = referrer;
				if (ajoCurrentActivity != null)
				{
					object obj3 = ajoCurrentActivity as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = ajoCurrentActivity;
					ajcAdjust.CallStatic("setReferrer", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x1569C44", Offset = "0x1569C44", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EC4EA0]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202909D]) = v42;\nL_0018:\n\tv46 = new com.adjust.sdk.AdjustAndroid+DeviceIdsReadListener();\n\tcom.adjust.sdk.AdjustAndroid+DeviceIdsReadListener::.ctor(v46, onDeviceIdsRead);\n\tgoto L_002F;\n\tv55 = *([v51 @ X0_v4 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002F;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v51, v47, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv59 = com.adjust.sdk.AdjustAndroid;\nL_002F:\n\t// 47 NewArr v68 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\tv75 = v73.ajoCurrentActivity == 0;\n\tif (v75) goto L_003E;\n\t// 59 IsInst v118 @ X0_v25, typeof(System.Object), v73.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\nL_003E:\n\tv153 = v68.Length;\n\tv125 = v68.Length == 0;\n\tif (v125) goto L_0069;\n\tv68[0] = v73.ajoCurrentActivity;\n\tv156 = v46 == 0;\n\tif (v156) goto L_004B;\n\t// 71 IsInst v175 @ X0_v23, typeof(System.Object), v46 @ X0_v3 (com.adjust.sdk.AdjustAndroid+DeviceIdsReadListener)\n\tv153 = v68.Length;\nL_004B:\n\tv183 = v153 < 1;\n\tv143 = ~v183;\n\tv141 = v153 - 1;\n\tv137 = v141 == 0;\n\tv184 = ~v143;\n\tv127 = v184 | v137;\n\tif (v127) goto L_0069;\n\tv68[1] = v46;\n\tUnityEngine.AndroidJavaObject::CallStatic(v63.ajcAdjust, \"getGoogleAdId\", v68);\n\treturn;\nL_0069:\n\tv171 = new System.IndexOutOfRangeException();\n\tgoto L_006E;\n\tv180 = new System.ArrayTypeMismatchException();\nL_006E:\n\tthrow v218;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetGoogleAdId(Action<string> onDeviceIdsRead)
		{
			//IL_0040: Expected O, but got I4
			//IL_013d: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			DeviceIdsReadListener deviceIdsReadListener = new DeviceIdsReadListener(onDeviceIdsRead);
			object[] array = new object[2];
			if (ajoCurrentActivity != null)
			{
				object obj = ajoCurrentActivity as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = ajoCurrentActivity;
				if (deviceIdsReadListener != null)
				{
					object obj3 = deviceIdsReadListener as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = deviceIdsReadListener;
					ajcAdjust.CallStatic("getGoogleAdId", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x1569DE4", Offset = "0x1569DE4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC8818]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202909E]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\t// 38 NewArr v59 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv66 = v64.ajoCurrentActivity == 0;\n\tif (v66) goto L_0036;\n\t// 50 IsInst v71 @ X0_v19, typeof(System.Object), v64.ajoCurrentActivity (UnityEngine.AndroidJavaObject)\nL_0036:\n\tv78 = v59.Length == 0;\n\tif (v78) goto L_004C;\n\tv59[0] = v64.ajoCurrentActivity;\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v54.ajcAdjust, \"getAmazonAdId\", v59);\n\treturn returnVal1;\n\tv67 = new System.NullReferenceException();\nL_004C:\n\tv84 = new System.IndexOutOfRangeException();\n\tgoto L_0053;\n\tv88 = new System.NullReferenceException();\n\tv91 = new System.ArrayTypeMismatchException();\nL_0053:\n\tthrow v109;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetAmazonAdId()
		{
			object[] array = new object[1];
			if (ajoCurrentActivity != null)
			{
				object obj = ajoCurrentActivity as object;
			}
			if (array.Length != 0)
			{
				array[0] = ajoCurrentActivity;
				return ajcAdjust.CallStatic<string>("getAmazonAdId", array);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x1569914", Offset = "0x1569914", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC0A18]);\n\tv19 = *([v18 @ X8_v26]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202909F]) = v39;\nL_0019:\n\tgoto L_0026;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0026;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = com.adjust.sdk.AdjustAndroid;\nL_0026:\n\tv59 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002F;\n\tv65 = v59;\n\tv66 = 0x8907BC(v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv69 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_002F:\n\tv70 = *([v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv71 = v70 == 0;\n\tif (v71) goto L_0050;\n\tv73 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003C;\n\tv95 = v73;\n\tv96 = 0x8907BC(v95, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv97 = *([v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv85 = ~v97;\n\tif (v85) goto L_0050;\n\tgoto L_0050;\n\tv117 = v79;\n\tv118 = 0x8907BC(v117, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0050:\n\tgoto L_005E;\n\tv98 = v90;\n\tv99 = 0x8907BC(v98, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005E:\n\tv114 = UnityEngine.AndroidJavaObject::CallStatic(v55.ajcAdjust, \"getSdkVersion\", v107.Value);\n\treturnVal2 = System.String::Concat(\"unity4.19.1@\", v114);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetSdkVersion()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X20_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X20_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			string text = ajcAdjust.CallStatic<string>("getSdkVersion", Array.Empty<object>());
			return "unity4.19.1@" + text;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x1569F4C", Offset = "0x1569F4C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EE6A70]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20290A0]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<com.adjust.sdk.AdjustAndroid>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = com.adjust.sdk.AdjustAndroid;\nL_0029:\n\tgoto L_0032;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0032;\n\tv73 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v73, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0032:\n\tv72 = com.adjust.sdk.AdjustUtils::TestOptionsMap2AndroidJavaObject(testOptions, v56.ajoCurrentActivity);\n\t// 60 NewArr v83 @ X0_v8 (System.Object[]), typeof(System.Object[]), 1\n\tv86 = v72 == 0;\n\tif (v86) goto L_0049;\n\t// 69 IsInst v91 @ X0_v21, typeof(System.Object), v72 @ X0_v6 (UnityEngine.AndroidJavaObject)\nL_0049:\n\tv98 = v83.Length == 0;\n\tif (v98) goto L_005D;\n\tv83[0] = v72;\n\tUnityEngine.AndroidJavaObject::CallStatic(v78.ajcAdjust, \"setTestOptions\", v83);\n\treturn;\n\tv87 = new System.NullReferenceException();\nL_005D:\n\tv103 = new System.IndexOutOfRangeException();\n\tgoto L_0064;\n\tv107 = new System.NullReferenceException();\n\tv110 = new System.ArrayTypeMismatchException();\nL_0064:\n\tthrow v124;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetTestOptions(Dictionary<string, string> testOptions)
		{
			AndroidJavaObject androidJavaObject = AdjustUtils.TestOptionsMap2AndroidJavaObject(testOptions, ajoCurrentActivity);
			object[] array = new object[1];
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
			}
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				ajcAdjust.CallStatic("setTestOptions", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x156A158", Offset = "0x156A158", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EAE9F0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290A1]) = v38;\nL_0016:\n\tv41 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+78]) == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tv45 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+38]) == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tv47 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+48]) == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv48 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+58]) == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv70 = *([adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+68]) == 0;\n\tv55 = ~v70;\n\tgoto L_0034;\nL_0034:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsAppSecretSet(AdjustConfig adjustConfig)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+78]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+38]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+48]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+58]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [adjustConfig @ X0 (com.adjust.sdk.AdjustConfig)+68]");
							bool flag = (IntPtr)0 == (IntPtr)0;
							return !flag;
						}
					}
				}
			}
			return false;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x156B12C", Offset = "0x156B12C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustAndroid()
		{
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x156B134", Offset = "0x156B134", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC00B0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20290A2]) = v39;\nL_0019:\n\tv45.launchDeferredDeeplink = 1;\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.adjust.sdk.Adjust\");\n\tv55.ajcAdjust = v48;\n\tv57 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v57, \"com.unity3d.player.UnityPlayer\");\n\tv71 = UnityEngine.AndroidJavaObject::GetStatic(v57, \"currentActivity\");\n\tv75.ajoCurrentActivity = v71;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AdjustAndroid()
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.adjust.sdk.Adjust");
			ajcAdjust = androidJavaClass;
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject androidJavaObject = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
			ajoCurrentActivity = androidJavaObject;
		}
	}
}
