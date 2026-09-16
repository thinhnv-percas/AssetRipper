using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
	[Token(Token = "0x2000017")]
	internal class InitializationStatusClient : IInitializationStatusClient
	{
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x10")]
		private AndroidJavaObject status;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x18")]
		private AndroidJavaObject statusMap;

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x1347E50", Offset = "0x1347E50", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, status, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, status, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = \"getAdapterStatusMap\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, status, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A367BD]) = v41;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tthis.status = status;\n\tgoto L_002C;\n\tv54 = 0xB3490C(Il2CppMethodInfo, 0, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tgoto L_0031;\n\tv63 = 0xB348B0(v58, v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tgoto L_0039;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v64, v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tgoto L_0046;\n\tv76 = 0xB348B0(v71, v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tv88 = UnityEngine.AndroidJavaObject::Call(status, \"getAdapterStatusMap\", v81.Value);\n\tthis.statusMap = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public InitializationStatusClient(AndroidJavaObject status)
		{
			this.status = status;
			statusMap = (AndroidJavaObject)status.Call<object>("getAdapterStatusMap", Array.Empty<object>());
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x1347F40", Offset = "0x1347F40", Length = "0x3D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\n\tv32 = GoogleMobileAds.Api.AdapterStatus;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv57 = UnityEngine.AndroidJavaClass;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv61 = Il2CppMethodInfo;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv116 = Il2CppMethodInfo;\n\tv117 = \"il2cpp_codegen_initialize_runtime_metadata\"(v116, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv144 = Il2CppMethodInfo;\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv167 = Il2CppMethodInfo;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv180 = Il2CppMethodInfo;\n\tv181 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv184 = Il2CppMethodInfo;\n\tv185 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv242 = System.Object[];\n\tv243 = \"il2cpp_codegen_initialize_runtime_metadata\"(v242, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv255 = \"getLatency\";\n\tv256 = \"il2cpp_codegen_initialize_runtime_metadata\"(v255, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv263 = \"READY\";\n\tv264 = \"il2cpp_codegen_initialize_runtime_metadata\"(v263, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv278 = \"getInitializationState\";\n\tv279 = \"il2cpp_codegen_initialize_runtime_metadata\"(v278, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv289 = \"equals\";\n\tv290 = \"il2cpp_codegen_initialize_runtime_metadata\"(v289, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv296 = \"com.google.android.gms.ads.initialization.AdapterStatus$State\";\n\tv297 = \"il2cpp_codegen_initialize_runtime_metadata\"(v296, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv309 = \"get\";\n\tv310 = \"il2cpp_codegen_initialize_runtime_metadata\"(v309, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv317 = \"getDescription\";\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v317, className, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A367BE]) = v51;\nL_004A:\n\t// 74 NewArr v55 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv64 = className == 0;\n\tif (v64) goto L_0059;\n\t// 83 IsInst v121 @ X0_v69, typeof(System.Object), className @ X1 (System.String)\n\tv123 = v121 == 0;\n\tif (v123) goto L_012C;\nL_0059:\n\tv55[0] = className;\n\tv176 = UnityEngine.AndroidJavaObject::Call(this.statusMap, \"get\", v55);\n\tv182 = v176 == 0;\n\tif (v182) goto L_0129;\n\tgoto L_0077;\n\tv245 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"get\", v55);\nL_0077:\n\tgoto L_007C;\n\tv257 = UnityEngine.AndroidJavaObject::Call(v249, v174, v173, v175);\nL_007C:\n\tgoto L_FFFFFFFF;\n\tv265 = \"il2cpp_codegen_runtime_class_init\"(v258, v174, v173, v175, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_008A;\n\tv280 = UnityEngine.AndroidJavaObject::Call(v270, v174, v173, v175);\nL_008A:\n\tv282 = *([v281 @ X0_v21+B8]);\n\tv287 = UnityEngine.AndroidJavaObject::Call(v176, \"getDescription\", *([v282 @ X8_v17]));\n\tgoto L_009E;\n\tv299 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"getDescription\", *([v282 @ X8_v17]));\nL_009E:\n\tgoto L_00A3;\n\tv311 = UnityEngine.AndroidJavaObject::Call(v303, v283, v286, v284);\nL_00A3:\n\tgoto L_FFFFFFFF;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v312, v283, v286, v284, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00B5;\n\tv332 = UnityEngine.AndroidJavaObject::Call(v324, v283, v286, v284);\nL_00B5:\n\tv334 = *([v333 @ X0_v29+B8]);\n\tv338 = UnityEngine.AndroidJavaObject::Call(v176, \"getLatency\", *([v334 @ X8_v24]));\n\tv94 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v94, \"com.google.android.gms.ads.initialization.AdapterStatus$State\");\n\tv346 = UnityEngine.AndroidJavaObject::GetStatic(v94, \"READY\");\n\tgoto L_00DB;\n\tv352 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, \"READY\", Il2CppMethodInfo);\nL_00DB:\n\tgoto L_00E0;\n\tv361 = UnityEngine.AndroidJavaObject::Call(v356, v344, v345, v80);\nL_00E0:\n\tgoto L_FFFFFFFF;\n\tv366 = \"il2cpp_codegen_runtime_class_init\"(v362, v344, v345, v80, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00EC;\n\tv375 = UnityEngine.AndroidJavaObject::Call(v370, v344, v345, v80);\nL_00EC:\n\tv377 = *([v376 @ X0_v41+B8]);\n\tv380 = UnityEngine.AndroidJavaObject::Call(v176, \"getInitializationState\", *([v377 @ X8_v34]));\n\t// 246 NewArr v95 @ X0_v45 (System.Object[]), typeof(System.Object[]), 1\n\tv382 = v346 == 0;\n\tif (v382) goto L_0105;\n\t// 255 IsInst v157 @ X0_v52, typeof(System.Object), v346 @ X0_v35 (System.Object)\n\tv159 = v157 == 0;\n\tif (v159) goto L_012C;\nL_0105:\n\tv95[0] = v346;\n\tv393 = UnityEngine.AndroidJavaObject::Call(v380, \"equals\", v95);\n\tv205 = new GoogleMobileAds.Api.AdapterStatus();\n\tSystem.Object::.ctor(v205);\n\t*([v205 @ X0_v50 (System.Object)+10]) = v393;\n\t*([v205 @ X0_v50 (System.Object)+18]) = v287;\n\t*([v205 @ X0_v50 (System.Object)+20]) = v338;\nL_0129:\n\treturn v208;\n\tv114 = new System.NullReferenceException();\n\tv142 = new System.IndexOutOfRangeException();\nL_012C:\n\tv165 = new System.ArrayTypeMismatchException();\n\tthrow v165;\n\treturn returnVal1;\n// 207 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdapterStatus getAdapterStatusForClassName(string className)
		{
			//IL_00c9: Expected O, but got I
			//IL_00de: Expected O, but got I
			//IL_011d: Expected O, but got I
			//IL_0132: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_01af: Expected O, but got I
			object[] array = new object[1];
			if (className != null)
			{
				object obj = className as object;
				if (obj == null)
				{
					goto IL_0272;
				}
			}
			array[0] = className;
			object obj2 = statusMap.Call<object>("get", array);
			bool flag = obj2 == null;
			object result = obj2;
			if (!flag)
			{
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X0_v21+B8]");
				object args = 0;
				object obj4 = ((AndroidJavaObject)obj2).Call<object>("getDescription", (object[])args);
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v333 @ X0_v29+B8]");
				object args2 = 0;
				int num = ((AndroidJavaObject)obj2).Call<int>("getLatency", (object[])args2);
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.google.android.gms.ads.initialization.AdapterStatus$State");
				object obj6 = androidJavaClass.GetStatic<object>("READY");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v376 @ X0_v41+B8]");
				object args3 = 0;
				object obj8 = ((AndroidJavaObject)obj2).Call<object>("getInitializationState", (object[])args3);
				object[] array2 = new object[1];
				if (obj6 != null)
				{
					object obj9 = obj6 as object;
					if (obj9 == null)
					{
						goto IL_0272;
					}
				}
				array2[0] = obj6;
				bool flag2 = ((AndroidJavaObject)obj8).Call<bool>("equals", array2);
				object obj10 = null;
				result = obj10;
			}
			return (AdapterStatus)result;
			IL_0272:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x1348318", Offset = "0x1348318", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = System.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A367BF]) = v48;\nL_0020:\n\tv50 = new System.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>::.ctor(v50);\n\tv59 = GoogleMobileAds.Android.InitializationStatusClient::getKeys(this);\n\tv73 = v59.Length < 1;\n\tif (v73) goto L_0068;\nL_0048:\n\tv116 = GoogleMobileAds.Android.InitializationStatusClient::getAdapterStatusForClassName(this, v59[v81 @ X23_v5 (System.Int32)]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, GoogleMobileAds.Api.AdapterStatus>::Add(v50, v59[v81 @ X23_v5 (System.Int32)], v116);\n\tv81 = v81 + 1;\n\tv139 = v81 < v59.Length;\n\tif (v139) goto L_0048;\nL_0068:\n\treturn v50;\n\tv115 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Dictionary<string, AdapterStatus> getAdapterStatusMap()
		{
			Dictionary<string, AdapterStatus> dictionary = new Dictionary<string, AdapterStatus>();
			string[] keys = getKeys();
			if (keys.Length >= 1)
			{
				int num = 0;
				do
				{
					AdapterStatus adapterStatusForClassName = getAdapterStatusForClassName(keys[num]);
					dictionary.Add(keys[num], adapterStatusForClassName);
					num++;
				}
				while (num < keys.Length);
			}
			return dictionary;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x1348418", Offset = "0x1348418", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tv28 = UnityEngine.AndroidJavaClass;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv195 = System.Int32;\n\tv196 = \"il2cpp_codegen_initialize_runtime_metadata\"(v195, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv234 = System.Object[];\n\tv235 = \"il2cpp_codegen_initialize_runtime_metadata\"(v234, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv278 = \"newInstance\";\n\tv279 = \"il2cpp_codegen_initialize_runtime_metadata\"(v278, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv286 = \"size\";\n\tv287 = \"il2cpp_codegen_initialize_runtime_metadata\"(v286, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv290 = \"keySet\";\n\tv291 = \"il2cpp_codegen_initialize_runtime_metadata\"(v290, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv335 = \"java.lang.String\";\n\tv336 = \"il2cpp_codegen_initialize_runtime_metadata\"(v335, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv338 = \"java.lang.reflect.Array\";\n\tv339 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv342 = \"toArray\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v342, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A367C0]) = v48;\nL_0044:\n\tgoto L_004D;\n\tthis = 0xB3490C(Il2CppMethodInfo, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004D:\n\tgoto L_0052;\n\tv70 = 0xB348B0(v62, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0052:\n\tgoto L_005A;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_005A:\n\tgoto L_006F;\n\tv89 = 0xB348B0(v81, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_006F:\n\tv112 = UnityEngine.AndroidJavaObject::Call(this.statusMap, \"keySet\", v98.Value);\n\tv199 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v199, \"java.lang.reflect.Array\");\n\t// 122 NewArr v282 @ X0_v20 (System.Object[]), typeof(System.Object[]), 2\n\tv172 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v172, \"java.lang.String\");\n\tv340 = v172 == 0;\n\tif (v340) goto L_0090;\n\t// 138 IsInst this @ X0 (GoogleMobileAds.Android.InitializationStatusClient), typeof(System.Object), v172 @ X0_v22 (UnityEngine.AndroidJavaClass)\n\tv266 = this == 0;\n\tif (v266) goto L_010C;\nL_0090:\n\tv282[0] = v172;\n\tgoto L_009E;\n\tv351 = UnityEngine.AndroidJavaObject::Call(Il2CppMethodInfo, v217, 0);\nL_009E:\n\tgoto L_00A3;\n\tv360 = UnityEngine.AndroidJavaObject::Call(v355, v217, v156, v104);\nL_00A3:\n\tgoto L_FFFFFFFF;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v361, v217, v156, v104, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00B3;\n\tv376 = UnityEngine.AndroidJavaObject::Call(v371, v217, v156, v104);\nL_00B3:\n\tv378 = *([this @ X0 (GoogleMobileAds.Android.InitializationStatusClient)+B8]);\n\tv381 = UnityEngine.AndroidJavaObject::Call(this.statusMap, \"size\", *([v378 @ X8_v24]));\n\t// 189 Box this @ X0 (GoogleMobileAds.Android.InitializationStatusClient), typeof(System.Int32), &v381 @ X0_v31 (System.Int32)\n\tv386 = this == 0;\n\tif (v386) goto L_00D4;\n\t// 196 IsInst this @ X0 (GoogleMobileAds.Android.InitializationStatusClient), typeof(System.Object), this @ X0 (GoogleMobileAds.Android.InitializationStatusClient)\n\tv267 = this == 0;\n\tif (v267) goto L_010C;\nL_00D4:\n\tv282[1] = this;\n\tv396 = UnityEngine.AndroidJavaObject::CallStatic(v199, \"newInstance\", v282);\n\t// 228 NewArr v174 @ X0_v38 (System.Object[]), typeof(System.Object[]), 1\n\tv398 = v396 == 0;\n\tif (v398) goto L_00F3;\n\t// 237 IsInst this @ X0 (GoogleMobileAds.Android.InitializationStatusClient), typeof(System.Object), v396 @ X0_v36 (System.Object)\n\tv268 = this == 0;\n\tif (v268) goto L_010C;\nL_00F3:\n\tv174[0] = v396;\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v112, \"toArray\", v174);\n\treturn returnVal2;\n\tv193 = new System.NullReferenceException();\n\tv232 = new System.IndexOutOfRangeException();\nL_010C:\n\tv276 = new System.ArrayTypeMismatchException();\n\tthrow v276;\n\treturn returnVal1;\n// 189 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string[] getKeys()
		{
			//IL_0109: Expected O, but got I
			//IL_011e: Expected O, but got I
			object obj = statusMap.Call<object>("keySet", Array.Empty<object>());
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.lang.reflect.Array");
			object[] array = new object[2];
			AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("java.lang.String");
			bool flag = androidJavaClass2 == null;
			string text = "java.lang.String";
			InitializationStatusClient initializationStatusClient;
			if (!flag)
			{
				initializationStatusClient = (InitializationStatusClient)(androidJavaClass2 as object);
				bool flag2 = this == null;
				text = (string)(object)typeof(object);
				if (flag2)
				{
					goto IL_0239;
				}
			}
			array[0] = androidJavaClass2;
			initializationStatusClient = (InitializationStatusClient)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (GoogleMobileAds.Android.InitializationStatusClient)+B8]");
			object args = 0;
			int num = statusMap.Call<int>("size", (object[])args);
			initializationStatusClient = (InitializationStatusClient)(object)num;
			if (this != null)
			{
				initializationStatusClient = (InitializationStatusClient)(this as object);
				if (this == null)
				{
					goto IL_0239;
				}
			}
			array[1] = this;
			object obj2 = androidJavaClass.CallStatic<object>("newInstance", array);
			object[] array2 = new object[1];
			if (obj2 != null)
			{
				initializationStatusClient = (InitializationStatusClient)(obj2 as object);
				if (this == null)
				{
					goto IL_0239;
				}
			}
			array2[0] = obj2;
			return (string[])((AndroidJavaObject)obj).Call<object>("toArray", array2);
			IL_0239:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}
	}
}
