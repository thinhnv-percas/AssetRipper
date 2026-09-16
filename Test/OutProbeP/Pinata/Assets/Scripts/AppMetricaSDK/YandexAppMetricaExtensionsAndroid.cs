using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000012")]
public static class YandexAppMetricaExtensionsAndroid
{
	[Token(Token = "0x600007E")]
	[Address(RVA = "0x15BE1E4", Offset = "0x15BE1E4", Length = "0x1068")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = &v25 @ X29;\n\tv33 = &v25 @ X29 - 0x90;\n\tgoto L_0021;\n\tv38 = *([1EEEC20]);\n\tv39 = *([v38 @ X8_v259]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2029965]) = v58;\nL_0021:\n\t*([v25 @ X29-80]) = 0;\n\t*([v25 @ X29-94]) = 0;\n\t*([v25 @ X29-A0]) = 0;\n\t*([v25 @ X29-B0]) = 0;\n\t*([v25 @ X29-D0]) = 0;\n\t*([v33 @ X23_v1 (UnityEngine.AndroidJavaObject)]) = 0;\n\t*([v25 @ X29-C0]) = 0;\n\t*([v25 @ X29-F0]) = 0;\n\t*([v25 @ X29-E0]) = 0;\n\tv66 = new UnityEngine.AndroidJavaClass();\n\tv69 = &v25 @ X29 - 0x20;\n\t*([v69 @ X19_v2-100]) = v66;\n\tUnityEngine.AndroidJavaClass::.ctor(v66, \"com.yandex.metrica.YandexMetricaConfig\");\n\t// 58 NewArr v76 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv80 = self.<ApiKey>k__BackingField == 0;\n\tif (v80) goto L_0048;\n\t// 68 IsInst v157 @ X0_v394, typeof(System.Object), self.<ApiKey>k__BackingField (System.String)\n\tv161 = v157 == 0;\n\tif (v161) goto L_02C5;\nL_0048:\n\tv164 = v76.Length == 0;\n\tif (v164) goto L_02C0;\n\tv76[0] = self.<ApiKey>k__BackingField;\n\tv196 = &v25 @ X29 - 0x20;\n\tv270 = UnityEngine.AndroidJavaObject::CallStatic(*([v196 @ X30_v61-100]), \"newConfigBuilder\", v76);\n\t*([v25 @ X29-80]) = *([self @ X0 (YandexAppMetricaConfig)+20]);\n\tv277 = *([self @ X0 (YandexAppMetricaConfig)+20]) & 0xFF;\n\t*([v33 @ X23_v1 (UnityEngine.AndroidJavaObject)]) = self.<Location>k__BackingField;\n\tv278 = v277 == 0;\n\tif (v278) goto L_008D;\n\t*([v25 @ X29-80]) = *([self @ X0 (YandexAppMetricaConfig)+20]);\n\t*([v33 @ X23_v1 (UnityEngine.AndroidJavaObject)]) = self.<Location>k__BackingField;\n\tv326 = &v25 @ X29 - 0x90;\n\tv327 = UnityEngine.AndroidJavaObject::CallStatic(v326, Il2CppMethodInfo, v76);\n\t// 109 NewArr v384 @ X0_v386 (System.Object[]), typeof(System.Object[]), 1\n\tv312 = YandexAppMetricaExtensionsAndroid::ToAndroidLocation(v384);\n\tv552 = v312 == 0;\n\tif (v552) goto L_007E;\n\tv642 = v384.<Latitude>k__BackingField;\n\tv645 = \"il2cpp_codegen_object_is_inst\"(v312, *([v642 @ X8_v256 (System.Double)+40]), v76, Il2CppMethodInfo, v44, v45, v46, v47, self.<Location>k__BackingField, v1404, v50, v51, v52, v53, v54, v55);\n\tv647 = v645 == 0;\n\tif (v647) goto L_030D;\nL_007E:\n\tv377 = v384.Length == 0;\n\tif (v377) goto L_02CB;\n\tv384[0] = v312;\n\tv340 = UnityEngine.AndroidJavaObject::Call(v270, \"withLocation\", v384);\nL_008D:\n\tv347 = self.<AppVersion>k__BackingField == 0;\n\tif (v347) goto L_00AE;\n\t// 145 NewArr v387 @ X0_v377 (System.Object[]), typeof(System.Object[]), 1\n\tv479 = self.<AppVersion>k__BackingField == 0;\n\tif (v479) goto L_009F;\n\t// 155 IsInst v556 @ X0_v382, typeof(System.Object), self.<AppVersion>k__BackingField (System.String)\n\tv560 = v556 == 0;\n\tif (v560) goto L_0311;\nL_009F:\n\tv563 = v387.Length == 0;\n\tif (v563) goto L_02D3;\n\tv387[0] = self.<AppVersion>k__BackingField;\n\tv399 = UnityEngine.AndroidJavaObject::Call(v270, \"withAppVersion\", v387);\nL_00AE:\n\tv407 = self.<LocationTracking>k__BackingField < 0x100;\n\tv408 = ~v407;\n\t*([v25 @ X29-94]) = self.<LocationTracking>k__BackingField;\n\tv416 = ~v408;\n\tif (v416) goto L_00E9;\n\t// 188 NewArr v423 @ X0_v366 (System.Object[]), typeof(System.Object[]), 1\n\t*([v25 @ X29-94]) = self.<LocationTracking>k__BackingField;\n\tv484 = &v25 @ X29 - 0x94;\n\tv485 = System.Nullable`1<System.Boolean>::get_Value(v484);\n\tv443 = &v25 @ X29 - 0x18;\n\t*([v443 @ X19_v77-100]) = v485;\n\tv568 = &v25 @ X29 - 0x118;\n\t// 205 Box v570 @ X0_v370 (UnityEngine.AndroidJavaObject), typeof(System.Boolean), v568 @ X1_v171\n\tv793 = v570 == 0;\n\tif (v793) goto L_00DA;\n\t// 214 IsInst v981 @ X0_v375, typeof(System.Object), v570 @ X0_v370 (UnityEngine.AndroidJavaObject)\n\tv985 = v981 == 0;\n\tif (v985) goto L_031D;\nL_00DA:\n\tv988 = v423.Length == 0;\n\tif (v988) goto L_02ED;\n\tv423[0] = v570;\n\tv435 = UnityEngine.AndroidJavaObject::Call(v270, \"withLocationTracking\", v423);\nL_00E9:\n\tv445 = self.<SessionTimeout>k__BackingField & 0xFF00000000;\n\t*([v25 @ X29-A0]) = self.<SessionTimeout>k__BackingField;\n\tv446 = v445 == 0;\n\tif (v446) goto L_011B;\n\t// 239 NewArr v488 @ X0_v355 (System.Object[]), typeof(System.Object[]), 1\n\t*([v25 @ X29-A0]) = self.<SessionTimeout>k__BackingField;\n\tv575 = &v25 @ X29 - 0xA0;\n\tv576 = System.Nullable`1<System.Int32>::get_Value(v575);\n\tv508 = &v25 @ X29 - 0x18;\n\t*([v508 @ X19_v76-100]) = v576;\n\tv653 = &v25 @ X29 - 0x118;\n\t// 255 Box v655 @ X0_v359 (UnityEngine.AndroidJavaObject), typeof(System.Int32), v653 @ X1_v165\n\tv1020 = v655 == 0;\n\tif (v1020) goto L_010C;\n\t// 264 IsInst v1089 @ X0_v364, typeof(System.Object), v655 @ X0_v359 (UnityEngine.AndroidJavaObject)\n\tv1091 = v1089 == 0;\n\tif (v1091) goto L_0315;\nL_010C:\n\tv1126 = v488.Length == 0;\n\tif (v1126) goto L_02DB;\n\tv488[0] = v655;\n\tv500 = UnityEngine.AndroidJavaObject::Call(v270, \"withSessionTimeout\", v488);\nL_011B:\n\tv510 = self.<CrashReporting>k__BackingField < 0x100;\n\tv511 = ~v510;\n\t*([v25 @ X29-94]) = self.<CrashReporting>k__BackingField;\n\tv519 = ~v511;\n\tif (v519) goto L_0156;\n\t// 297 NewArr v579 @ X0_v344 (System.Object[]), typeof(System.Object[]), 1\n\t*([v25 @ X29-94]) = self.<CrashReporting>k__BackingField;\n\tv660 = &v25 @ X29 - 0x94;\n\tv661 = System.Nullable`1<System.Boolean>::get_Value(v660);\n\tv599 = &v25 @ X29 - 0x18;\n\t*([v599 @ X19_v75-100]) = v661;\n\tv861 = &v25 @ X29 - 0x118;\n\t// 314 Box v863 @ X0_v348 (UnityEngine.AndroidJavaObject), typeof(System.Boolean), v861 @ X1_v159\n\tv1138 = v863 == 0;\n\tif (v1138) goto L_0147;\n\t// 323 IsInst v1321 @ X0_v353, typeof(System.Object), v863 @ X0_v348 (UnityEngine.AndroidJavaObject)\n\tv1325 = v1321 == 0;\n\tif (v1325) goto L_0321;\nL_0147:\n\tv1328 = v579.Length == 0;\n\tif (v1328) goto L_02F5;\n\tv579[0] = v863;\n\tv591 = UnityEngine.AndroidJavaObject::Call(v270, \"withCrashReporting\", v579);\nL_0156:\n\tv601 = self.<Logs>k__BackingField < 0x100;\n\tv602 = ~v601;\n\t*([v25 @ X29-94]) = self.<Logs>k__BackingField;\n\tv610 = ~v602;\n\tif (v610) goto L_01A3;\n\tv662 = self.<Logs>k__BackingField & 0xFF;\n\tv663 = v662 == 0;\n\tif (v663) goto L_01A3;\n\tv867 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0172;\n\tv1022 = v867;\n\tv1023 = UnityEngine.AndroidJavaObject::Call(v1022, v586, v588, v582);\n\tv1026 = *([v867 @ X22_v70 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0172:\n\tv1027 = *([v867 @ X22_v70 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv1028 = v1027 == 0;\n\tif (v1028) goto L_0193;\n\tv1202 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_017F;\n\tv1360 = v1202;\n\tv1361 = UnityEngine.AndroidJavaObject::Call(v1360, v586, v588, v582);\nL_017F:\n\tv1362 = *([v1202 @ X22_v73 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv1214 = ~v1362;\n\tif (v1214) goto L_0193;\n\tgoto L_0193;\n\tv1704 = v1208;\n\tv1705 = UnityEngine.AndroidJavaObject::Call(v1704, v586, v588, v582);\nL_0193:\n\tgoto L_019D;\n\tv1363 = v670;\n\tv1364 = UnityEngine.AndroidJavaObject::Call(v1363, v586, v588, v582);\nL_019D:\n\t;\n\tv676 = UnityEngine.AndroidJavaObject::Call(v270, \"withLogs\", v680.Value);\nL_01A3:\n\tv684 = self.<InstalledAppCollecting>k__BackingField < 0x100;\n\tv685 = ~v684;\n\t*([v25 @ X29-94]) = self.<InstalledAppCollecting>k__BackingField;\n\tv693 = ~v685;\n\tif (v693) goto L_01DE;\n\t// 433 NewArr v874 @ X0_v316 (System.Object[]), typeof(System.Object[]), 1\n\t*([v25 @ X29-94]) = self.<InstalledAppCollecting>k__BackingField;\n\tv1033 = &v25 @ X29 - 0x94;\n\tv1034 = System.Nullable`1<System.Boolean>::get_Value(v1033);\n\tv894 = &v25 @ X29 - 0x18;\n\t*([v894 @ X19_v73-100]) = v1034;\n\tv1227 = &v25 @ X29 - 0x118;\n\t// 450 Box v1229 @ X0_v320 (UnityEngine.AndroidJavaObject), typeof(System.Boolean), v1227 @ X1_v152\n\tv1539 = v1229 == 0;\n\tif (v1539) goto L_01CF;\n\t// 459 IsInst v1711 @ X0_v325, typeof(System.Object), v1229 @ X0_v320 (UnityEngine.AndroidJavaObject)\n\tv1715 = v1711 == 0;\n\tif (v1715) goto L_0325;\nL_01CF:\n\tv1718 = v874.Length == 0;\n\tif (v1718) goto L_02FF;\n\tv874[0] = v1229;\n\tv886 = UnityEngine.AndroidJavaObject::Call(v270, \"withInstalledAppCollecting\", v874);\nL_01DE:\n\tv896 = self.<HandleFirstActivationAsUpdate>k__BackingField < 0x100;\n\tv897 = ~v896;\n\t*([v25 @ X29-94]) = self.<HandleFirstActivationAsUpdate>k__BackingField;\n\tv905 = ~v897;\n\tif (v905) goto L_0219;\n\t// 492 NewArr v1037 @ X0_v305\n// ... truncated")]
	public unsafe static AndroidJavaObject ToAndroidAppMetricaConfig(this YandexAppMetricaConfig self)
	{
		//IL_0017: Expected O, but got I
		//IL_1456: Expected O, but got I4
		//IL_1485: Expected O, but got I
		//IL_00b2: Expected O, but got I
		//IL_00d1: Expected O, but got I
		//IL_014f: Expected O, but got I
		//IL_015e: Expected O, but got I
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046f: Expected I4, but got Unknown
		//IL_0377: Expected O, but got I
		//IL_04bd: Expected O, but got I
		//IL_0398: Expected O, but got I
		//IL_03ac: Expected O, but got I
		//IL_03b5: Expected I4, but got O
		//IL_0607: Expected O, but got I
		//IL_04de: Expected O, but got I
		//IL_04f2: Expected O, but got I
		//IL_04fb: Expected I4, but got O
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_073d: Expected I4, but got Unknown
		//IL_0628: Expected O, but got I
		//IL_063c: Expected O, but got I
		//IL_0645: Expected I4, but got O
		//IL_0831: Expected O, but got I
		//IL_0d5b: Expected I, but got O
		//IL_0d69: Expected I, but got O
		//IL_097b: Expected O, but got I
		//IL_0852: Expected O, but got I
		//IL_0866: Expected O, but got I
		//IL_086f: Expected I4, but got O
		//IL_0acd: Expected O, but got I
		//IL_0adc: Expected O, but got I
		//IL_099c: Expected O, but got I
		//IL_09b0: Expected O, but got I
		//IL_09b9: Expected I4, but got O
		//IL_1205: Expected O, but got I
		//IL_121a: Expected O, but got I
		//IL_1223: Expected I4, but got O
		//IL_1107: Expected O, but got I
		//IL_1128: Expected O, but got I
		//IL_113c: Expected O, but got I
		//IL_1145: Expected I4, but got O
		//IL_0bb4: Expected O, but got I
		//IL_0bc7: Expected O, but got I
		//IL_0bd6: Expected O, but got I
		//IL_153e: Expected O, but got I
		//IL_0d85: Expected O, but got I
		//IL_0d95: Expected O, but got I
		//IL_0d9e: Expected O, but got I4
		//IL_0db2: Expected I, but got O
		//IL_161f: Expected O, but got I
		//IL_0f02: Expected O, but got I
		//IL_0f46: Expected O, but got I
		//IL_0f56: Expected O, but got I
		//IL_0c78: Expected O, but got I4
		//IL_0c4d: Expected O, but got I
		//IL_0cb1: Expected O, but got I
		//IL_14fa: Expected O, but got I
		//IL_0ce7: Expected O, but got I
		//IL_0d31: Expected O, but got I
		//IL_0d12: Expected O, but got I4
		//IL_10c9: Expected O, but got I
		object obj = obj;
		AndroidJavaObject androidJavaObject = (AndroidJavaObject)((long)(IntPtr)obj - 144L);
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		androidJavaObject = (AndroidJavaObject)0;
		_ = 0;
		_ = 0;
		_ = 0;
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.yandex.metrica.YandexMetricaConfig");
		object obj2 = (long)(IntPtr)obj - 32L;
		object[] array = new object[1];
		if (self.ApiKey != null)
		{
			object obj3 = self.ApiKey as object;
			if (obj3 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		int num5;
		IntPtr intPtr4;
		AndroidJavaObject androidJavaObject21;
		if (array.Length != 0)
		{
			array[0] = self.ApiKey;
			object obj4 = (long)(IntPtr)obj - 32L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X30_v61-100]");
			AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)0).CallStatic<AndroidJavaObject>("newConfigBuilder", array);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (YandexAppMetricaConfig)+20]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (YandexAppMetricaConfig)+20]");
			int num = 0;
			androidJavaObject = (AndroidJavaObject)self.Location;
			if (num != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (YandexAppMetricaConfig)+20]");
				_ = 0;
				androidJavaObject = (AndroidJavaObject)self.Location;
				AndroidJavaObject androidJavaObject3 = (AndroidJavaObject)((long)(IntPtr)obj - 144L);
				AndroidJavaObject androidJavaObject4 = androidJavaObject3.CallStatic<AndroidJavaObject>((string)0, array);
				object[] array2 = new object[1];
				AndroidJavaObject androidJavaObject5 = ((YandexAppMetricaConfig.Coordinates)array2).ToAndroidLocation();
				if (androidJavaObject5 != null)
				{
					double latitude = ((YandexAppMetricaConfig.Coordinates*)(&array2))->Latitude;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj5 = default(object);
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
						throw ex2;
					}
				}
				if (array2.Length == 0)
				{
					IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
					throw ex3;
				}
				array2[0] = androidJavaObject5;
				AndroidJavaObject androidJavaObject6 = androidJavaObject2.Call<AndroidJavaObject>("withLocation", array2);
			}
			if (self.AppVersion != null)
			{
				object[] array3 = new object[1];
				if (self.AppVersion != null)
				{
					object obj6 = self.AppVersion as object;
					if (obj6 == null)
					{
						ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
						throw ex4;
					}
				}
				if (array3.Length == 0)
				{
					IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
					throw ex5;
				}
				array3[0] = self.AppVersion;
				AndroidJavaObject androidJavaObject7 = androidJavaObject2.Call<AndroidJavaObject>("withAppVersion", array3);
			}
			bool flag = (long)(IntPtr)(void*)self.LocationTracking < 256L;
			bool flag2 = !flag;
			_ = self.LocationTracking;
			if (flag2)
			{
				object[] array4 = new object[1];
				_ = self.LocationTracking;
				bool? flag3 = (bool?)(object)((long)(IntPtr)obj - 148L);
				bool value = ((bool?*)flag3)->Value;
				object obj7 = (long)(IntPtr)obj - 24L;
				object obj8 = (long)(IntPtr)obj - 280L;
				AndroidJavaObject androidJavaObject8 = (AndroidJavaObject)(object)((byte)(int)obj8 != 0);
				if (androidJavaObject8 != null)
				{
					object obj9 = androidJavaObject8 as object;
					if (obj9 == null)
					{
						ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
						throw ex6;
					}
				}
				if (array4.Length == 0)
				{
					IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
					throw ex7;
				}
				array4[0] = androidJavaObject8;
				AndroidJavaObject androidJavaObject9 = androidJavaObject2.Call<AndroidJavaObject>("withLocationTracking", array4);
			}
			int num2 = (int)((_003F?)self.SessionTimeout & 0xFF00000000L);
			_ = self.SessionTimeout;
			if (num2 != 0)
			{
				object[] array5 = new object[1];
				_ = self.SessionTimeout;
				int? num3 = (int?)(object)((long)(IntPtr)obj - 160L);
				int value2 = ((int?*)num3)->Value;
				object obj10 = (long)(IntPtr)obj - 24L;
				object obj11 = (long)(IntPtr)obj - 280L;
				AndroidJavaObject androidJavaObject10 = (AndroidJavaObject)(object)(int)obj11;
				if (androidJavaObject10 != null)
				{
					object obj12 = androidJavaObject10 as object;
					if (obj12 == null)
					{
						ArrayTypeMismatchException ex8 = new ArrayTypeMismatchException();
						throw ex8;
					}
				}
				if (array5.Length == 0)
				{
					IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
					throw ex9;
				}
				array5[0] = androidJavaObject10;
				AndroidJavaObject androidJavaObject11 = androidJavaObject2.Call<AndroidJavaObject>("withSessionTimeout", array5);
			}
			bool flag4 = (long)(IntPtr)(void*)self.CrashReporting < 256L;
			bool flag5 = !flag4;
			_ = self.CrashReporting;
			if (flag5)
			{
				object[] array6 = new object[1];
				_ = self.CrashReporting;
				bool? flag6 = (bool?)(object)((long)(IntPtr)obj - 148L);
				bool value3 = ((bool?*)flag6)->Value;
				object obj13 = (long)(IntPtr)obj - 24L;
				object obj14 = (long)(IntPtr)obj - 280L;
				AndroidJavaObject androidJavaObject12 = (AndroidJavaObject)(object)((byte)(int)obj14 != 0);
				if (androidJavaObject12 != null)
				{
					object obj15 = androidJavaObject12 as object;
					if (obj15 == null)
					{
						ArrayTypeMismatchException ex10 = new ArrayTypeMismatchException();
						throw ex10;
					}
				}
				if (array6.Length == 0)
				{
					IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
					throw ex11;
				}
				array6[0] = androidJavaObject12;
				AndroidJavaObject androidJavaObject13 = androidJavaObject2.Call<AndroidJavaObject>("withCrashReporting", array6);
			}
			bool flag7 = (long)(IntPtr)(void*)self.Logs < 256L;
			bool flag8 = !flag7;
			_ = self.Logs;
			if (flag8 && ((_003F?)self.Logs & 0xFF) != 0)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v867 @ X22_v70 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ X22_v73 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				AndroidJavaObject androidJavaObject14 = androidJavaObject2.Call<AndroidJavaObject>("withLogs", Array.Empty<object>());
			}
			bool flag9 = (long)(IntPtr)(void*)self.InstalledAppCollecting < 256L;
			bool flag10 = !flag9;
			_ = self.InstalledAppCollecting;
			if (flag10)
			{
				object[] array7 = new object[1];
				_ = self.InstalledAppCollecting;
				bool? flag11 = (bool?)(object)((long)(IntPtr)obj - 148L);
				bool value4 = ((bool?*)flag11)->Value;
				object obj16 = (long)(IntPtr)obj - 24L;
				object obj17 = (long)(IntPtr)obj - 280L;
				AndroidJavaObject androidJavaObject15 = (AndroidJavaObject)(object)((byte)(int)obj17 != 0);
				if (androidJavaObject15 != null)
				{
					object obj18 = androidJavaObject15 as object;
					if (obj18 == null)
					{
						ArrayTypeMismatchException ex12 = new ArrayTypeMismatchException();
						throw ex12;
					}
				}
				if (array7.Length == 0)
				{
					IndexOutOfRangeException ex13 = new IndexOutOfRangeException();
					throw ex13;
				}
				array7[0] = androidJavaObject15;
				AndroidJavaObject androidJavaObject16 = androidJavaObject2.Call<AndroidJavaObject>("withInstalledAppCollecting", array7);
			}
			bool flag12 = (long)(IntPtr)(void*)self.HandleFirstActivationAsUpdate < 256L;
			bool flag13 = !flag12;
			_ = self.HandleFirstActivationAsUpdate;
			if (flag13)
			{
				object[] array8 = new object[1];
				_ = self.HandleFirstActivationAsUpdate;
				bool? flag14 = (bool?)(object)((long)(IntPtr)obj - 148L);
				bool value5 = ((bool?*)flag14)->Value;
				object obj19 = (long)(IntPtr)obj - 24L;
				object obj20 = (long)(IntPtr)obj - 280L;
				AndroidJavaObject androidJavaObject17 = (AndroidJavaObject)(object)((byte)(int)obj20 != 0);
				if (androidJavaObject17 != null)
				{
					object obj21 = androidJavaObject17 as object;
					if (obj21 == null)
					{
						ArrayTypeMismatchException ex14 = new ArrayTypeMismatchException();
						throw ex14;
					}
				}
				if (array8.Length == 0)
				{
					IndexOutOfRangeException ex15 = new IndexOutOfRangeException();
					throw ex15;
				}
				array8[0] = androidJavaObject17;
				AndroidJavaObject androidJavaObject18 = androidJavaObject2.Call<AndroidJavaObject>("handleFirstActivationAsUpdate", array8);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (YandexAppMetricaConfig)+50]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (YandexAppMetricaConfig)+50]");
			int num4 = 0;
			_ = self.PreloadInfo;
			if (num4 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (YandexAppMetricaConfig)+50]");
				_ = 0;
				_ = self.PreloadInfo;
				YandexAppMetricaPreloadInfo? yandexAppMetricaPreloadInfo = (YandexAppMetricaPreloadInfo?)(object)((long)(IntPtr)obj - 192L);
				object obj22 = (long)(IntPtr)obj - 40L;
				YandexAppMetricaPreloadInfo value6 = ((YandexAppMetricaPreloadInfo?*)yandexAppMetricaPreloadInfo)->Value;
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.yandex.metrica.PreloadInfo");
				object[] array9 = new object[1];
				if ((object)value6 != null)
				{
					object obj23 = value6 as object;
					if (obj23 == null)
					{
						ArrayTypeMismatchException ex16 = new ArrayTypeMismatchException();
						throw ex16;
					}
				}
				if (array9.Length != 0)
				{
					array9[0] = value6;
					AndroidJavaObject androidJavaObject19 = androidJavaClass2.CallStatic<AndroidJavaObject>("newBuilder", array9);
					Dictionary<string, string>.Enumerator enumerator = ((Dictionary<string, string>)0).GetEnumerator();
					object obj24 = (long)(IntPtr)obj - 8L;
					object obj25 = (long)(IntPtr)obj - 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-F8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X30_v63-100]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2376 @ X30_v62-100]");
					_ = 0;
					while (true)
					{
						Dictionary<string, string>.Enumerator enumerator2 = (Dictionary<string, string>.Enumerator)((long)(IntPtr)obj - 240L);
						if (!((Dictionary<string, string>.Enumerator*)enumerator2)->MoveNext())
						{
							break;
						}
						object[] array10 = new object[2];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-E0]");
							object obj26 = 0 as object;
							if (obj26 == null)
							{
								ArrayTypeMismatchException ex17 = new ArrayTypeMismatchException();
								throw ex17;
							}
						}
						object obj27 = array10.Length;
						if (array10.Length != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-E0]");
							array10[0] = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-D8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-D8]");
								object obj28 = 0 as object;
								if (obj28 == null)
								{
									ArrayTypeMismatchException ex18 = new ArrayTypeMismatchException();
									throw ex18;
								}
								obj27 = array10.Length;
							}
							bool flag15 = (long)(IntPtr)obj27 < 1L;
							bool flag16 = !flag15;
							object obj29 = (long)(IntPtr)obj27 - 1L;
							bool flag17 = obj29 == null;
							bool flag18 = !flag16;
							if (!(flag18 || flag17))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X29-D8]");
								array10[1] = 0;
								AndroidJavaObject androidJavaObject20 = androidJavaObject19.Call<AndroidJavaObject>("setAdditionalParams", array10);
								continue;
							}
							IndexOutOfRangeException ex19 = new IndexOutOfRangeException();
							throw ex19;
						}
						IndexOutOfRangeException ex20 = new IndexOutOfRangeException();
						throw ex20;
					}
					object obj30 = (long)(IntPtr)obj - 40L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2478 @ X30_v64-100]");
					object obj31 = 0;
					obj31 = 653;
					IntPtr intPtr3 = (IntPtr)0;
					num5 = 0;
					intPtr4 = (IntPtr)null;
					androidJavaObject21 = androidJavaObject2;
					Dictionary<string, string>.Enumerator enumerator3 = (Dictionary<string, string>.Enumerator)((long)(IntPtr)obj - 240L);
					((Dictionary<string, string>.Enumerator*)enumerator3)->Dispose();
					if (true)
					{
						object obj32 = (long)(IntPtr)obj - 40L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2618 @ X30_v22-100]");
						object obj33 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2619 @ X8_v92+v1416 @ X28_v4 (System.Int32)*4]");
						if ((IntPtr)0 == (IntPtr)653)
						{
							num5 = -1;
							goto IL_0fb4;
						}
					}
					if (intPtr4 == (IntPtr)0)
					{
						goto IL_0fb4;
					}
					TypeLoadException ex21 = new TypeLoadException();
					AndroidJavaObject androidJavaObject22 = ((AndroidJavaObject)(object)ex21).CallStatic<AndroidJavaObject>((string)null, (object[])null);
					goto IL_1413;
				}
				IndexOutOfRangeException ex22 = new IndexOutOfRangeException();
				throw ex22;
			}
			object obj34 = default(object);
			IntPtr intPtr5 = (IntPtr)obj34;
			num5 = -1;
			intPtr4 = (IntPtr)null;
			androidJavaObject21 = androidJavaObject2;
			goto IL_1568;
		}
		IndexOutOfRangeException ex23 = new IndexOutOfRangeException();
		throw ex23;
		IL_1386:
		throw new TypeLoadException();
		IL_1568:
		bool flag19 = (long)(IntPtr)(void*)self.StatisticsSending < 256L;
		bool flag20 = !flag19;
		_ = self.StatisticsSending;
		if (flag20)
		{
			object[] array11 = new object[1];
			_ = self.StatisticsSending;
			bool? flag21 = (bool?)(object)((long)(IntPtr)obj - 148L);
			bool value7 = ((bool?*)flag21)->Value;
			object obj35 = (long)(IntPtr)obj - 24L;
			object obj36 = (long)(IntPtr)obj - 280L;
			object obj37 = (byte)(int)obj36 != 0;
			if (obj37 != null)
			{
				object obj38 = obj37 as object;
				if (obj38 == null)
				{
					goto IL_1413;
				}
			}
			if (array11.Length == 0)
			{
				IndexOutOfRangeException ex24 = new IndexOutOfRangeException();
				throw ex24;
			}
			array11[0] = obj37;
			AndroidJavaObject androidJavaObject23 = androidJavaObject21.Call<AndroidJavaObject>("withStatisticsSending", array11);
		}
		object[] array12 = new object[1];
		object obj39 = (long)(IntPtr)obj - 24L;
		_ = 0;
		object obj40 = (long)(IntPtr)obj - 280L;
		object obj41 = (byte)(int)obj40 != 0;
		if (obj41 != null)
		{
			object obj42 = obj41 as object;
			if (obj42 == null)
			{
				ArrayTypeMismatchException ex25 = new ArrayTypeMismatchException();
				throw ex25;
			}
		}
		if (array12.Length != 0)
		{
			array12[0] = obj41;
			AndroidJavaObject androidJavaObject24 = androidJavaObject21.Call<AndroidJavaObject>("withNativeCrashReporting", array12);
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2231 @ X21_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2430 @ X21_v13 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject result = androidJavaObject21.Call<AndroidJavaObject>("build", Array.Empty<object>());
			int num6 = num5 + 1;
			_ = 807;
			object obj43 = (long)(IntPtr)obj - 32L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2716 @ X30_v4-100]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				((IDisposable)null).Dispose();
			}
			if (num6 + 1 != 0)
			{
				if (intPtr4 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2685 @ X26_v4 (Il2CppMethodInfo)+v2704 @ X28_v2 (System.Int32)*4]");
					if ((IntPtr)0 != (IntPtr)807)
					{
						goto IL_1386;
					}
				}
			}
			else if (intPtr4 != (IntPtr)0)
			{
				goto IL_1386;
			}
			return result;
		}
		IndexOutOfRangeException ex26 = new IndexOutOfRangeException();
		throw ex26;
		IL_1413:
		ArrayTypeMismatchException ex27 = new ArrayTypeMismatchException();
		throw ex27;
		IL_0fb4:
		object[] array13 = new object[1];
		IntPtr intPtr8 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2787 @ X25_v14 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr9 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2958 @ X25_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		Il2CppRuntime.Boundary("MANAGED", "Method not found @14F79A0 (UnityEngine.AndroidJavaObject::Call, and 2 more at this address)");
		object obj44 = default(object);
		if (obj44 != null)
		{
			object obj45 = obj44 as object;
			if (obj45 == null)
			{
				ArrayTypeMismatchException ex28 = new ArrayTypeMismatchException();
				throw ex28;
			}
		}
		if (array13.Length != 0)
		{
			array13[0] = obj44;
			AndroidJavaObject androidJavaObject25 = androidJavaObject21.Call<AndroidJavaObject>("withPreloadInfo", array13);
			object obj46 = (long)(IntPtr)obj - 40L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1419 @ X30_v20-100]");
			IntPtr intPtr5 = (IntPtr)0;
			goto IL_1568;
		}
		IndexOutOfRangeException ex29 = new IndexOutOfRangeException();
		throw ex29;
	}

	[Token(Token = "0x600007F")]
	[Address(RVA = "0x15BFBEC", Offset = "0x15BFBEC", Length = "0x1E0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EE9470]);\n\tv31 = *([v30 @ X8_v28]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v25, v23, v40, v41, v42, v43, v44, v45);\n\tv49 = 0 | 1;\n\t*([2029966]) = v49;\nL_001D:\n\t// 29 NewArr v54 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv60 = \"\" == 0;\n\tif (v60) goto L_002C;\n\t// 40 IsInst v90 @ X0_v36, typeof(System.Object), \"\"\nL_002C:\n\tv97 = v54.Length == 0;\n\tif (v97) goto L_0089;\n\tv54[0] = \"\";\n\tv102 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v102, \"android.location.Location\", v54);\n\t// 61 NewArr v205 @ X0_v17 (System.Object[]), typeof(System.Object[]), 1\n\t// 68 Box v209 @ X0_v19, typeof(System.Double), &v25 @ V0\n\tv211 = v209 == 0;\n\tif (v211) goto L_0051;\n\t// 77 IsInst v187 @ X0_v35, typeof(System.Object), v209 @ X0_v19\nL_0051:\n\tv136 = v205.Length == 0;\n\tif (v136) goto L_0089;\n\tv205[0] = v209;\n\tUnityEngine.AndroidJavaObject::Call(v102, \"setLatitude\", v205);\n\t// 95 NewArr v227 @ X0_v26 (System.Object[]), typeof(System.Object[]), 1\n\t// 100 Box v214 @ X0_v28, typeof(System.Double), &v23 @ V1\n\tv229 = v214 == 0;\n\tif (v229) goto L_0071;\n\t// 109 IsInst v188 @ X0_v33, typeof(System.Object), v214 @ X0_v28\nL_0071:\n\tv137 = v227.Length == 0;\n\tif (v137) goto L_0089;\n\tv227[0] = v214;\n\tUnityEngine.AndroidJavaObject::Call(v102, \"setLongitude\", v227);\n\treturn v102;\n\tv131 = new System.NullReferenceException();\nL_0089:\n\tv144 = new System.IndexOutOfRangeException();\n\tgoto L_008E;\n\tv196 = new System.ArrayTypeMismatchException();\nL_008E:\n\tthrow v202;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static AndroidJavaObject ToAndroidLocation(this YandexAppMetricaConfig.Coordinates self)
	{
		//IL_0097: Expected F8, but got O
		//IL_0133: Expected F8, but got O
		object[] array = new object[1];
		if ("" != null)
		{
			object obj = "" as object;
		}
		if (array.Length != 0)
		{
			array[0] = "";
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.location.Location", array);
			object[] array2 = new object[1];
			object obj3 = default(object);
			object obj2 = (double)obj3;
			if (obj2 != null)
			{
				object obj4 = obj2 as object;
			}
			if (array2.Length != 0)
			{
				array2[0] = obj2;
				androidJavaObject.Call("setLatitude", array2);
				object[] array3 = new object[1];
				object obj6 = default(object);
				object obj5 = (double)obj6;
				if (obj5 != null)
				{
					object obj7 = obj5 as object;
				}
				if (array3.Length != 0)
				{
					array3[0] = obj5;
					androidJavaObject.Call("setLongitude", array3);
					return androidJavaObject;
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000080")]
	[Address(RVA = "0x15C236C", Offset = "0x15C236C", Length = "0x154")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0A4F0]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029967]) = v42;\nL_0015:\n\tv43 = self == 0;\n\tif (v43) goto L_006C;\n\tv47 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v47, \"com.yandex.metrica.profile.GenderAttribute$Gender\");\n\tv194 = UnityEngine.AndroidJavaObject::GetStatic(v47, self);\nL_0032:\n\tgoto L_0059;\n\tv245 = *([v239 @ X8_v9+B0]);\n\tv246 = 0;\n\tv247 = v245 + 8;\n\tv249 = *([v287 @ X11_v7-8]);\n\tv292 = v249 == v242;\n\tif (v292) goto L_0052;\n\tv269 = v286 + 1;\n\tv297 = v269 < v241;\n\tv267 = ~v297;\n\tv271 = v287 + 0x10;\n\tv251 = ~v267;\n\tif (v251) goto L_FFFFFFFF;\n\tv272 = v129;\n\tv273 = 0;\n\tv274 = 0x8909C4(v272, v242, v273, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0059;\nL_0052:\n\tv298 = *([v287 @ X11_v7]);\n\tv299 = v298 << 4;\n\tv300 = v239 + v299;\n\tv301 = v300 + 0x130;\nL_0059:\n\tSystem.IDisposable::Dispose(v47);\n\tv121 = v106 + 1;\n\tv83 = v121 == 0;\n\tv63 = ~v83;\n\tif (v63) goto L_006C;\nL_0061:\n\tv311 = v108 == 0;\n\tv120 = ~v311;\n\tif (v120) goto L_0072;\nL_006C:\n\treturn v122;\n\tthrow System.NullReferenceException;\nL_0072:\n\tv213 = new System.TypeLoadException();\n\tgoto L_0086;\n\tv275 = 0x6D2BC0(v213, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv108 = *([v275 @ X0_v17]);\n\tv233 = 0x6D2490(v275, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv235 = v47 == 0;\n\tif (v235) goto L_0061;\n\tgoto L_0032;\nL_0086:\n\treturnVal2 = 0x6D2380(v213, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static AndroidJavaObject ToAndroidGender(this string self)
	{
		bool flag = self == null;
		string result = self;
		if (!flag)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.yandex.metrica.profile.GenderAttribute$Gender");
			AndroidJavaObject androidJavaObject = androidJavaClass.GetStatic<AndroidJavaObject>(self);
			int num = 0;
			int num2 = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			((IDisposable)androidJavaClass).Dispose();
			int num3 = num + 1;
			bool flag2 = num3 == 0;
			bool flag3 = !flag2;
			result = (string)(object)androidJavaObject2;
			if (!flag3)
			{
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				result = (string)(object)androidJavaObject2;
				if (flag5)
				{
					TypeLoadException ex = new TypeLoadException();
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					AndroidJavaObject result2 = default(AndroidJavaObject);
					return result2;
				}
			}
		}
		return (AndroidJavaObject)(object)result;
	}

	[Token(Token = "0x6000081")]
	[Address(RVA = "0x15C24C0", Offset = "0x15C24C0", Length = "0x370")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED7B40]);\n\tv27 = *([v26 @ X8_v61]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029968]) = v46;\nL_0017:\n\tv47 = &v48 @ stack_-50;\n\tv53 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v53, \"com.yandex.metrica.profile.Attribute\");\n\tv61 = self.<Key>k__BackingField == 0;\n\tif (v61) goto L_004B;\n\t// 43 NewArr v66 @ X0_v63 (System.Object[]), typeof(System.Object[]), 1\n\tv86 = self.<Key>k__BackingField == 0;\n\tif (v86) goto L_0039;\n\t// 53 IsInst v115 @ X0_v79, typeof(System.Object), self.<Key>k__BackingField (System.String)\n\tv119 = v115 == 0;\n\tif (v119) goto L_00D2;\nL_0039:\n\tv122 = v66.Length == 0;\n\tif (v122) goto L_00CC;\n\tv66[0] = self.<Key>k__BackingField;\n\tv182 = UnityEngine.AndroidJavaObject::CallStatic(v53, self.<AttributeName>k__BackingField, v66);\n\tgoto L_0086;\nL_004B:\n\tv71 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0054;\n\tv78 = v71;\n\tv79 = UnityEngine.AndroidJavaObject::CallStatic(v78, v58, v56, v31);\n\tv82 = *([v71 @ X22_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0054:\n\tv83 = *([v71 @ X22_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv84 = v83 == 0;\n\tif (v84) goto L_0075;\n\tv90 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0061;\n\tv129 = v90;\n\tv130 = UnityEngine.AndroidJavaObject::CallStatic(v129, v58, v56, v31);\nL_0061:\n\tv131 = *([v90 @ X22_v19 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv102 = ~v131;\n\tif (v102) goto L_0075;\n\tgoto L_0075;\n\tv185 = v96;\n\tv186 = UnityEngine.AndroidJavaObject::CallStatic(v185, v58, v56, v31);\nL_0075:\n\tgoto L_0078;\n\tv132 = v107;\n\tv133 = UnityEngine.AndroidJavaObject::CallStatic(v132, v58, v56, v31);\nL_0078:\n\tv135 = v53 == 0;\n\tif (v135) goto L_00D7;\n\tv150 = UnityEngine.AndroidJavaObject::CallStatic(v53, self.<AttributeName>k__BackingField, v144.Value);\nL_0086:\n\t*([v47 @ X24_v1]) = 0x55;\nL_008D:\n\tgoto L_00B4;\n\tv311 = *([v249 @ X8_v9+B0]);\n\tv312 = 0;\n\tv313 = v311 + 8;\n\tv315 = *([v352 @ X11_v5-8]);\n\tv357 = v315 == v252;\n\tif (v357) goto L_00AD;\n\tv335 = v351 + 1;\n\tv420 = v335 < v251;\n\tv333 = ~v420;\n\tv337 = v352 + 0x10;\n\tv317 = ~v333;\n\tif (v317) goto L_FFFFFFFF;\n\tv338 = v57;\n\tv339 = 0;\n\tv340 = 0x8909C4(v338, v252, v339, v234, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00B4;\nL_00AD:\n\tv421 = *([v352 @ X11_v5]);\n\tv422 = v421 << 4;\n\tv423 = v249 + v422;\n\tv424 = v423 + 0x130;\nL_00B4:\n\tSystem.IDisposable::Dispose(v53);\n\tv446 = v235 + 1;\n\tv448 = v446 == 0;\n\tif (v448) goto L_00EE;\n\tv476 = v467 == 0;\n\tif (v476) goto L_00F6;\n\tv486 = *([v47 @ X24_v1+v235 @ X23_v1 (System.Int32)*4]) == 0x55;\n\tif (v486) goto L_00F6;\nL_00C9:\n\tgoto L_0143;\n\tv88 = new System.NullReferenceException();\nL_00CC:\n\tv128 = new System.IndexOutOfRangeException();\n\tthrow v128;\n\tv172 = new System.NullReferenceException();\nL_00D2:\n\tv175 = new System.ArrayTypeMismatchException();\n\tthrow v175;\nL_00D7:\n\tv165 = new System.NullReferenceException();\n\tgoto L_00E4;\n\tgoto L_00E4;\n\tgoto L_00E4;\nL_00E4:\n\tv214 = \"com.yandex.metrica.profile.Attribute\" != 1;\n\tif (v214) goto L_0144;\n\tv254 = UnityEngine.AndroidJavaObject::CallStatic(v165, \"com.yandex.metrica.profile.Attribute\", 0);\n\tv467 = *([v254 @ X0_v41 (UnityEngine.AndroidJavaObject)]);\n\tv244 = UnityEngine.AndroidJavaObject::CallStatic(v254, \"com.yandex.metrica.profile.Attribute\", 0);\n\tv246 = v53 == 0;\n\tif (v246) goto L_00EE;\n\tgoto L_008D;\nL_00EE:\n\tv474 = v467 == 0;\n\tv475 = ~v474;\n\tif (v475) goto L_00C9;\nL_00F6:\n\tv510 = System.String::op_Equality(self.<AttributeName>k__BackingField, \"gender\");\n\tv537 = v510 == 0;\n\tif (v537) goto L_013A;\n\tv560 = self.<Values>k__BackingField;\n\tv583 = v560.Length == 0;\n\tif (v583) goto L_013A;\n\tv610 = v560.Length == 0;\n\tif (v610) goto L_013E;\n\tv612 = v560[0];\n\tv613 = v560[0] == 0;\n\tif (v613) goto L_FFFFFFFF;\n\tv627 = *([v612 @ X8_v27 (System.Object)]) != System.String;\n\tif (v627) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_011A;\nL_011A:\n\tv633 = YandexAppMetricaExtensionsAndroid::ToAndroidGender(v631);\n\tv634 = v633 == 0;\n\tif (v634) goto L_0125;\n\t// 289 IsInst v636 @ X0_v31, typeof(System.Object), v633 @ X0_v28 (UnityEngine.AndroidJavaObject)\nL_0125:\n\tv582 = v560.Length == 0;\n\tif (v582) goto L_013E;\n\tv560[0] = v633;\nL_013A:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(v498, self.<MethodName>k__BackingField, self.<Values>k__BackingField);\n\treturn returnVal2;\n\tv607 = new System.NullReferenceException();\nL_013E:\n\tv568 = new System.IndexOutOfRangeException();\n\tgoto L_0143;\n\tv567 = new System.ArrayTypeMismatchException();\nL_0143:\n\tv303 = new System.TypeLoadException();\nL_0144:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v302, v298, v300);\n\treturn returnVal1;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static AndroidJavaObject ToAndroidUserProfileUpdate(this YandexAppMetricaUserProfileUpdate self)
	{
		//IL_04af: Expected O, but got I4
		//IL_04bd: Expected I, but got O
		//IL_0230: Expected I, but got O
		object obj2 = default(object);
		object obj = obj2;
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.yandex.metrica.profile.Attribute");
		AndroidJavaObject androidJavaObject2;
		string text;
		object[] array2;
		AndroidJavaObject androidJavaObject3;
		IntPtr intPtr3;
		int num;
		if (self.Key != null)
		{
			object[] array = new object[1];
			if (self.Key != null)
			{
				object obj3 = self.Key as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					text = null;
					array2 = null;
					throw ex;
				}
			}
			if (array.Length == 0)
			{
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}
			array[0] = self.Key;
			AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>(self.AttributeName, array);
			androidJavaObject2 = androidJavaObject;
		}
		else
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X22_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X22_v19 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			bool flag = androidJavaClass == null;
			text = "com.yandex.metrica.profile.Attribute";
			array2 = null;
			if (flag)
			{
				NullReferenceException ex3 = new NullReferenceException();
				bool flag2 = (IntPtr)"com.yandex.metrica.profile.Attribute" != (IntPtr)1;
				androidJavaObject3 = (AndroidJavaObject)(object)ex3;
				if (flag2)
				{
					goto IL_0453;
				}
				AndroidJavaObject androidJavaObject4 = ((AndroidJavaObject)(object)ex3).CallStatic<AndroidJavaObject>("com.yandex.metrica.profile.Attribute", (object[])null);
				intPtr3 = (IntPtr)androidJavaObject4;
				AndroidJavaObject androidJavaObject5 = androidJavaObject4.CallStatic<AndroidJavaObject>("com.yandex.metrica.profile.Attribute", (object[])null);
				bool flag3 = androidJavaClass == null;
				androidJavaObject2 = null;
				if (flag3)
				{
					goto IL_027d;
				}
				num = -1;
				androidJavaObject2 = null;
				goto IL_04f5;
			}
			AndroidJavaObject androidJavaObject6 = androidJavaClass.CallStatic<AndroidJavaObject>(self.AttributeName, Array.Empty<object>());
			androidJavaObject2 = androidJavaObject6;
		}
		obj = 85;
		num = 0;
		intPtr3 = (IntPtr)null;
		goto IL_04f5;
		IL_0400:
		return androidJavaObject2.Call<AndroidJavaObject>(self.MethodName, self.Values);
		IL_027d:
		if (intPtr3 != (IntPtr)0)
		{
			goto IL_0433;
		}
		goto IL_02a6;
		IL_04f5:
		((IDisposable)androidJavaClass).Dispose();
		if (num + 1 == 0)
		{
			goto IL_027d;
		}
		if (intPtr3 != (IntPtr)0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X24_v1+v235 @ X23_v1 (System.Int32)*4]");
			if ((IntPtr)0 != (IntPtr)85)
			{
				goto IL_0433;
			}
		}
		goto IL_02a6;
		IL_0453:
		return androidJavaObject3.CallStatic<AndroidJavaObject>(text, array2);
		IL_02a6:
		if (self.AttributeName == "gender")
		{
			object[] values = self.Values;
			if (values.Length != 0)
			{
				if (values.Length != 0)
				{
					object obj4 = values[0];
					string self2;
					if (values[0] != null)
					{
						object obj5 = (((object)obj4.GetType() != typeof(string)) ? null : values[0]);
						self2 = (string)obj5;
					}
					else
					{
						self2 = null;
					}
					AndroidJavaObject androidJavaObject7 = self2.ToAndroidGender();
					if (androidJavaObject7 != null)
					{
						object obj6 = androidJavaObject7 as object;
					}
					if (values.Length != 0)
					{
						values[0] = androidJavaObject7;
						goto IL_0400;
					}
				}
				IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
				goto IL_0433;
			}
		}
		goto IL_0400;
		IL_0433:
		TypeLoadException ex5 = new TypeLoadException();
		text = null;
		array2 = null;
		androidJavaObject3 = (AndroidJavaObject)(object)ex5;
		goto IL_0453;
	}

	[Token(Token = "0x6000082")]
	[Address(RVA = "0x15C0174", Offset = "0x15C0174", Length = "0x4A4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001D;\n\tv33 = *([1EBD388]);\n\tv34 = *([v33 @ X8_v73]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029969]) = v53;\nL_001D:\n\tv55 = &v56 @ stack_-120;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-A0]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\t*([v21 @ X29-B0]) = 0;\n\tv58 = self == 0;\n\tif (v58) goto L_FFFFFFFF;\n\tv62 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v62, \"com.yandex.metrica.profile.UserProfile\");\n\tv198 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003D;\n\tv203 = v198;\n\tv204 = UnityEngine.AndroidJavaObject::CallStatic(v203, v68, v66, v38);\n\tv207 = *([v198 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003D:\n\tv208 = *([v198 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv209 = v208 == 0;\n\tif (v209) goto L_005E;\n\tv211 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004A;\n\tv233 = v211;\n\tv234 = UnityEngine.AndroidJavaObject::CallStatic(v233, v68, v66, v38);\nL_004A:\n\tv235 = *([v211 @ X20_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv223 = ~v235;\n\tif (v223) goto L_005E;\n\tgoto L_005E;\n\tv291 = v217;\n\tv292 = UnityEngine.AndroidJavaObject::CallStatic(v291, v68, v66, v38);\nL_005E:\n\tgoto L_0068;\n\tv236 = v228;\n\tv237 = UnityEngine.AndroidJavaObject::CallStatic(v236, v68, v66, v38);\nL_0068:\n\tv410 = v244.Value;\n\tv252 = UnityEngine.AndroidJavaObject::CallStatic(v62, \"newBuilder\", v244.Value);\n\tv296 = YandexAppMetricaUserProfile::GetUserProfileUpdates(self);\n\tv314 = v296 == 0;\n\tif (v314) goto L_00C7;\n\tv322 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>::GetEnumerator(v296);\n\t*([v21 @ X29-80]) = *([v21 @ X29-D0]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-C0]);\n\t*([v21 @ X29-90]) = *([v21 @ X29-E0]);\n\tv339 = &v21 @ X29 - 0x90;\n\tv254 = v339 + 0x10;\nL_0088:\n\tv358 = &v21 @ X29 - 0x90;\n\tv359 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>+Enumerator<YandexAppMetricaUserProfileUpdate>::MoveNext(v358);\n\tv430 = v359 == 0;\n\tif (v430) goto L_00B7;\n\t*([v21 @ X29-B0]) = *([v254 @ X24_v12]);\n\t*([v21 @ X29-A0]) = *([v254 @ X24_v12+10]);\n\t// 147 NewArr v490 @ X0_v67 (System.Object[]), typeof(System.Object[]), 1\n\t*([v21 @ X29-100]) = *([v21 @ X29-B0]);\n\t*([v21 @ X29-F0]) = *([v21 @ X29-A0]);\n\tv498 = &v21 @ X29 - 0x100;\n\tv499 = YandexAppMetricaExtensionsAndroid::ToAndroidUserProfileUpdate(v498);\n\tv621 = v499 == 0;\n\tif (v621) goto L_00A7;\n\t// 163 IsInst v679 @ X0_v85, typeof(System.Object), v499 @ X0_v69 (UnityEngine.AndroidJavaObject)\n\tv683 = v679 == 0;\n\tif (v683) goto L_00C1;\nL_00A7:\n\tv685 = v490.Length == 0;\n\tif (v685) goto L_00BB;\n\tv490[0] = v499;\n\tv351 = UnityEngine.AndroidJavaObject::Call(v252, \"apply\", v490);\n\tgoto L_0088;\n\tgoto L_01A8;\nL_00B7:\n\t*([v55 @ X23_v1]) = 0x70;\n\tgoto L_00E2;\n\tv623 = new System.NullReferenceException();\nL_00BB:\n\tv690 = new System.IndexOutOfRangeException();\n\tthrow v690;\n\tv760 = new System.NullReferenceException();\nL_00C1:\n\tv763 = new System.ArrayTypeMismatchException();\n\tthrow v763;\n\tv290 = new System.NullReferenceException();\nL_00C7:\n\tv411 = new System.NullReferenceException();\n\tgoto L_00D9;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00D9;\n\tgoto L_00D9;\n\tgoto L_00D9;\nL_00D9:\n\tv332 = \"newBuilder\" != 1;\n\tif (v332) goto L_FFFFFFFF;\n\tv340 = UnityEngine.AndroidJavaObject::CallStatic(v411, \"newBuilder\", v244.Value);\n\tv588 = *([v340 @ X0_v53 (UnityEngine.AndroidJavaObject)]);\n\tv362 = UnityEngine.AndroidJavaObject::CallStatic(v340, \"newBuilder\", v244.Value);\nL_00E2:\n\tv465 = &v21 @ X29 - 0x90;\n\tv466 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>+Enumerator<YandexAppMetricaUserProfileUpdate>::Dispose(v465);\n\tv491 = v567 + 1;\n\tv493 = v491 == 0;\n\tif (v493) goto L_00F8;\n\tv510 = *([v55 @ X23_v1+v567 @ X26_v6 (System.Int32)*4]) != 0x70;\n\tif (v510) goto L_00F8;\n\tgoto L_00FF;\nL_00F8:\n\tv521 = v588 == 0;\n\tv522 = ~v521;\n\tif (v522) goto L_01AE;\nL_00FF:\n\tv543 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0108;\n\tv624 = v543;\n\tv625 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>+Enumerator<YandexAppMetricaUserProfileUpdate>::Dispose(v624, v464);\n\tv628 = *([v543 @ X22_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0108:\n\tv629 = *([v543 @ X22_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv630 = v629 == 0;\n\tif (v630) goto L_0129;\n\tv692 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0115;\n\tv741 = v692;\n\tv742 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>+Enumerator<YandexAppMetricaUserProfileUpdate>::Dispose(v741, v464);\nL_0115:\n\tv743 = *([v692 @ X22_v13 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv704 = ~v743;\n\tif (v704) goto L_0129;\n\tgoto L_0129;\n\tv774 = v698;\n\tv775 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>+Enumerator<YandexAppMetricaUserProfileUpdate>::Dispose(v774, v464);\nL_0129:\n\tgoto L_0135;\n\tv744 = v548;\n\tv745 = System.Collections.Generic.List`1<YandexAppMetricaUserProfileUpdate>+Enumerator<YandexAppMetricaUserProfileUpdate>::Dispose(v744, v464);\nL_0135:\n\tv585 = UnityEngine.AndroidJavaObject::Call /* +2 sharing this address */(v452, \"build\", v771.Value, *([v441 @ X25_v7 (Il2CppMethodInfo)]));\n\tv567 = v567 + 1;\n\t*([v55 @ X23_v1+v567 @ X26_v6 (System.Int32)*4]) = 0x8D;\n\tv779 = v62 == 0;\n\tv587 = ~v779;\n\tif (v587) goto L_0157;\n\tgoto L_017F;\nL_0149:\n\tv428 = v408 != 1;\n\tif (v428) goto L_01AF;\n\tv467 = UnityEngine.AndroidJavaObject::CallStatic(v411, v408, v410);\n\tv588 = *([v467 @ X0_v10 (UnityEngine.AndroidJavaObject)]);\n\tv497 = UnityEngine.AndroidJavaObject::CallStatic(v467, v408, v410);\n\tv524 = v62 == 0;\n\tif (v524) goto L_017F;\nL_0157:\n\tgoto L_017E;\n\tv631 = *([v592 @ X8_v23+B0]);\n\tv632 = 0;\n\tv633 = v631 + 8;\n\tv635 = *([v713 @ X11_v7-8]);\n\tv728 = v635 == v595;\n\tif (v728) goto L_0177;\n\tv657 = v723 + 1;\n\tv747 = v657 < v594;\n\tv655 = ~v747;\n\tv637 = v713 + 0x10;\n\tv639 = ~v655;\n\tif (v639) goto L_FFFFFFFF;\n\tv658 = v67;\n\tv659 = 0;\n\tv660 = 0x8909C4(v658, v595, v659, v572, v39, v40, v41, v42, v570, v571, v569, v46, v47, v48, v49, v50);\n\tgoto L_017E;\nL_0177:\n\tv748 = *([v713 @ X11_v7]);\n\tv749 = v748 << 4;\n\tv750 = v592 + v749;\n\tv751 = v750 + 0x130;\nL_017E:\n\tSystem.IDisposable::Dispose(v62);\nL_017F:\n\tv620 = v130 + 1;\n\tv104 = v620 == 0;\n\tif (v104) goto L_0196;\n\tv160 = v162 == 0;\n\tif (v160) goto L_01A8;\n\tv105 = *([v55 @ X23_v1+v130 @ X26_v4 (System.Int32)*4]) == 0x8D;\n\tif (v105) goto L_01A8;\nL_0195:\n\tthrow System.TypeLoadException;\nL_0196:\n\tv675 = v162 == 0;\n\tv159 = ~v675;\n\tif (v159) goto L_0195;\nL_01A8:\n\treturn v145;\n\tthrow System.NullReferenceException;\nL_01AE:\n\tv483 = new System.TypeLoadException();\nL_01AF:\n\tv412 = UnityEngine.AndroidJavaObject::CallStatic(v482, v408, v410);\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\tgoto L_0149;\n\treturn X0;\n// 255 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe static AndroidJavaObject ToAndroidUserProfile(this YandexAppMetricaUserProfile self)
	{
		//IL_0115: Expected O, but got I
		//IL_0124: Expected O, but got I
		//IL_0607: Expected O, but got I
		//IL_02c4: Expected I, but got O
		//IL_0239: Expected O, but got I4
		//IL_0255: Expected I, but got O
		//IL_02f8: Expected O, but got I
		//IL_0173: Expected O, but got I
		//IL_0475: Expected I, but got O
		//IL_04b8: Expected I, but got O
		object obj = obj;
		object obj3 = default(object);
		object obj2 = obj3;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		AndroidJavaClass androidJavaClass;
		string text;
		object[] args;
		int num;
		IntPtr intPtr4;
		NullReferenceException ex3;
		AndroidJavaObject androidJavaObject7;
		if (self != null)
		{
			androidJavaClass = new AndroidJavaClass("com.yandex.metrica.profile.UserProfile");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X20_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			args = Array.Empty<object>();
			AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("newBuilder", Array.Empty<object>());
			List<YandexAppMetricaUserProfileUpdate> userProfileUpdates = self.GetUserProfileUpdates();
			bool flag = userProfileUpdates == null;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			text = "newBuilder";
			if (!flag)
			{
				List<YandexAppMetricaUserProfileUpdate>.Enumerator enumerator = userProfileUpdates.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-D0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E0]");
				_ = 0;
				object obj4 = (long)(IntPtr)obj - 144L;
				object obj5 = (long)(IntPtr)obj4 + 16L;
				while (true)
				{
					List<YandexAppMetricaUserProfileUpdate>.Enumerator enumerator2 = (List<YandexAppMetricaUserProfileUpdate>.Enumerator)((long)(IntPtr)obj - 144L);
					if (!((List<YandexAppMetricaUserProfileUpdate>.Enumerator*)enumerator2)->MoveNext())
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X24_v12+10]");
					_ = 0;
					object[] array = new object[1];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A0]");
					_ = 0;
					YandexAppMetricaUserProfileUpdate self2 = (YandexAppMetricaUserProfileUpdate)((long)(IntPtr)obj - 256L);
					AndroidJavaObject androidJavaObject3 = self2.ToAndroidUserProfileUpdate();
					if (androidJavaObject3 != null)
					{
						object obj6 = androidJavaObject3 as object;
						if (obj6 == null)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							throw ex;
						}
					}
					if (array.Length != 0)
					{
						array[0] = androidJavaObject3;
						AndroidJavaObject androidJavaObject4 = androidJavaObject.Call<AndroidJavaObject>("apply", array);
						args = array;
						continue;
					}
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				obj2 = 112;
				IntPtr intPtr3 = (IntPtr)0;
				num = 0;
				androidJavaObject2 = androidJavaObject;
				intPtr4 = (IntPtr)null;
			}
			else
			{
				ex3 = new NullReferenceException();
				if ((IntPtr)"newBuilder" != (IntPtr)1)
				{
					num = -1;
					goto IL_06b5;
				}
				AndroidJavaObject androidJavaObject5 = ((AndroidJavaObject)(object)ex3).CallStatic<AndroidJavaObject>("newBuilder", Array.Empty<object>());
				intPtr4 = (IntPtr)androidJavaObject5;
				AndroidJavaObject androidJavaObject6 = androidJavaObject5.CallStatic<AndroidJavaObject>("newBuilder", Array.Empty<object>());
				num = -1;
			}
			List<YandexAppMetricaUserProfileUpdate>.Enumerator enumerator3 = (List<YandexAppMetricaUserProfileUpdate>.Enumerator)((long)(IntPtr)obj - 144L);
			((List<YandexAppMetricaUserProfileUpdate>.Enumerator*)enumerator3)->Dispose();
			if (num + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X23_v1+v567 @ X26_v6 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)112)
				{
					num = -1;
					goto IL_038a;
				}
			}
			if (intPtr4 == (IntPtr)0)
			{
				goto IL_038a;
			}
			TypeLoadException ex4 = new TypeLoadException();
			text = null;
			args = null;
			androidJavaObject7 = (AndroidJavaObject)(object)ex4;
			goto IL_0560;
		}
		AndroidJavaObject result = null;
		goto IL_053b;
		IL_0560:
		AndroidJavaObject androidJavaObject8 = androidJavaObject7.CallStatic<AndroidJavaObject>(text, args);
		ex3 = (NullReferenceException)(object)androidJavaObject8;
		goto IL_06b5;
		IL_038a:
		IntPtr intPtr5 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X22_v10 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v692 @ X22_v13 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		Il2CppRuntime.Boundary("MANAGED", "Method not found @14F79A0 (UnityEngine.AndroidJavaObject::Call, and 2 more at this address)");
		num++;
		_ = 141;
		bool flag2 = androidJavaClass == null;
		bool flag3 = !flag2;
		AndroidJavaObject androidJavaObject10 = default(AndroidJavaObject);
		AndroidJavaObject androidJavaObject9 = androidJavaObject10;
		int num2;
		IntPtr intPtr7;
		if (!flag3)
		{
			num2 = num;
			result = androidJavaObject10;
			intPtr7 = intPtr4;
			goto IL_0664;
		}
		goto IL_068f;
		IL_0664:
		if (num2 + 1 != 0)
		{
			if (intPtr7 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X23_v1+v130 @ X26_v4 (System.Int32)*4]");
				if ((IntPtr)0 != (IntPtr)141)
				{
					goto IL_050d;
				}
			}
		}
		else if (intPtr7 != (IntPtr)0)
		{
			goto IL_050d;
		}
		goto IL_053b;
		IL_06b5:
		bool flag4 = (IntPtr)text != (IntPtr)1;
		androidJavaObject7 = (AndroidJavaObject)(object)ex3;
		if (flag4)
		{
			goto IL_0560;
		}
		AndroidJavaObject androidJavaObject11 = ((AndroidJavaObject)(object)ex3).CallStatic<AndroidJavaObject>(text, args);
		intPtr4 = (IntPtr)androidJavaObject11;
		AndroidJavaObject androidJavaObject12 = androidJavaObject11.CallStatic<AndroidJavaObject>(text, args);
		bool flag5 = androidJavaClass == null;
		androidJavaObject9 = null;
		num2 = num;
		result = null;
		intPtr7 = (IntPtr)androidJavaObject11;
		if (flag5)
		{
			goto IL_0664;
		}
		goto IL_068f;
		IL_068f:
		((IDisposable)androidJavaClass).Dispose();
		num2 = num;
		result = androidJavaObject9;
		intPtr7 = intPtr4;
		goto IL_0664;
		IL_053b:
		return result;
		IL_050d:
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000083")]
	[Address(RVA = "0x15C28A0", Offset = "0x15C28A0", Length = "0x414")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1ED4CE0]);\n\tv31 = *([v30 @ X8_v63]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202996A]) = v50;\nL_001A:\n\tv52 = *([self @ X0 (System.Nullable`1<YandexAppMetricaReceipt>)+18]) == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv56 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v56, \"com.yandex.metrica.Revenue$Receipt\");\n\tv176 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0033;\n\tv239 = v176;\n\tv240 = 0x8907BC(v239, v62, v60, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv243 = *([v176 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0033:\n\tv244 = *([v176 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv245 = v244 == 0;\n\tif (v245) goto L_0054;\n\tv247 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0040;\n\tv269 = v247;\n\tv270 = 0x8907BC(v269, v62, v60, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0040:\n\tv271 = *([v247 @ X20_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv259 = ~v271;\n\tif (v259) goto L_0054;\n\tgoto L_0054;\n\tv291 = v253;\n\tv292 = 0x8907BC(v291, v62, v60, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0054:\n\tgoto L_0062;\n\tv272 = v264;\n\tv273 = 0x8907BC(v272, v62, v60, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0062:\n\tv288 = UnityEngine.AndroidJavaObject::CallStatic(v56, \"newBuilder\", v280.Value);\n\t// 104 NewArr v300 @ X0_v49 (System.Object[]), typeof(System.Object[]), 1\n\tv316 = UnityEngine.AndroidJavaObject::CallStatic(self, Il2CppMethodInfo, v280.Value);\n\tv348 = v302 == 0;\n\tif (v348) goto L_007C;\n\t// 120 IsInst v369 @ X0_v82, typeof(System.Object), v302 @ stack_-68_v12\n\tv371 = v369 == 0;\n\tif (v371) goto L_0139;\nL_007C:\n\tv341 = v300.Length == 0;\n\tif (v341) goto L_012D;\n\tv300[0] = v302;\n\tv442 = UnityEngine.AndroidJavaObject::Call(v288, \"withData\", v300);\n\t// 140 NewArr v448 @ X0_v56 (System.Object[]), typeof(System.Object[]), 1\n\tv390 = UnityEngine.AndroidJavaObject::Call(self, Il2CppMethodInfo, v300);\n\tv489 = v488 == 0;\n\tif (v489) goto L_009E;\n\t// 154 IsInst v462 @ X0_v80, typeof(System.Object), v488 @ stack_-78\n\tv464 = v462 == 0;\n\tif (v464) goto L_013D;\nL_009E:\n\tv412 = v448.Length == 0;\n\tif (v412) goto L_0135;\n\tv448[0] = v488;\n\tv500 = UnityEngine.AndroidJavaObject::Call(v288, \"withSignature\", v448);\n\tv504 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00B3;\n\tv511 = v504;\n\tv512 = UnityEngine.AndroidJavaObject::Call(v511, v497, v499, v496);\n\tv515 = *([v504 @ X21_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00B3:\n\tv516 = *([v504 @ X21_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv517 = v516 == 0;\n\tif (v517) goto L_00D4;\n\tv521 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00C0;\n\tv546 = v521;\n\tv547 = UnityEngine.AndroidJavaObject::Call(v546, v497, v499, v496);\nL_00C0:\n\tv548 = *([v521 @ X21_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv531 = ~v548;\n\tif (v531) goto L_00D4;\n\tgoto L_00D4;\n\tv621 = v533;\n\tv622 = UnityEngine.AndroidJavaObject::Call(v621, v497, v499, v496);\nL_00D4:\n\tgoto L_00DE;\n\tv549 = v538;\n\tv550 = UnityEngine.AndroidJavaObject::Call(v549, v497, v499, v496);\nL_00DE:\n\tv559 = UnityEngine.AndroidJavaObject::Call(v288, \"build\", v553.Value);\nL_00E8:\n\tgoto L_0111;\n\tv591 = *([v583 @ X8_v16+B0]);\n\tv592 = 0;\n\tv593 = v591 + 8;\n\tv595 = *([v635 @ X11_v7-8]);\n\tv641 = v595 == v586;\n\tif (v641) goto L_010A;\n\tv617 = v636 + 1;\n\tv646 = v617 < v585;\n\tv613 = ~v646;\n\tv615 = v635 + 0x10;\n\tv597 = ~v613;\n\tif (v597) goto L_FFFFFFFF;\n\tv618 = v61;\n\tv619 = 0;\n\tv620 = 0x8909C4(v618, v586, v619, v126, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0111;\n\tgoto L_0128;\nL_010A:\n\tv647 = *([v635 @ X11_v7]);\n\tv648 = v647 << 4;\n\tv649 = v583 + v648;\n\tv650 = v649 + 0x130;\nL_0111:\n\tSystem.IDisposable::Dispose(v56);\n\tv154 = v140 + 1;\n\tv94 = v154 == 0;\n\tv74 = ~v94;\n\tif (v74) goto L_0128;\nL_0119:\n\tv545 = v156 == 0;\n\tv153 = ~v545;\n\tif (v153) goto L_0144;\nL_0128:\n\treturn v135;\n\tthrow System.NullReferenceException;\n\tv322 = new System.NullReferenceException();\nL_012D:\n\tv344 = new System.IndexOutOfRangeException();\n\tthrow v344;\n\tthrow System.NullReferenceException;\n\tv396 = new System.NullReferenceException();\nL_0135:\n\tv417 = new System.IndexOutOfRangeException();\n\tthrow v417;\nL_0139:\n\tv436 = new System.ArrayTypeMismatchException();\n\tthrow v436;\nL_013D:\n\tv468 = new System.ArrayTypeMismatchException();\n\tthrow v468;\nL_0144:\n\tv487 = new System.TypeLoadException();\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\n\tgoto L_0158;\nL_0158:\n\tgoto L_0161;\n\tv501 = UnityEngine.AndroidJavaObject::CallStatic(v487, 0, 0);\n\tv156 = *([v501 @ X0_v20 (UnityEngine.AndroidJavaObject)]);\n\tv510 = UnityEngine.AndroidJavaObject::CallStatic(v501, 0, 0);\n\tv519 = v56 == 0;\n\tif (v519) goto L_0119;\n\tgoto L_00E8;\nL_0161:\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v487, 0, 0);\n\treturn returnVal2;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static AndroidJavaObject ToAndroidReceipt(this YandexAppMetricaReceipt? self)
	{
		//IL_00a3: Expected O, but got I
		//IL_0162: Expected O, but got I
		//IL_0279: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [self @ X0 (System.Nullable`1<YandexAppMetricaReceipt>)+18]");
		AndroidJavaObject result;
		if ((IntPtr)0 != (IntPtr)0)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.yandex.metrica.Revenue$Receipt");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ X20_v20 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("newBuilder", Array.Empty<object>());
			object[] array = new object[1];
			AndroidJavaObject androidJavaObject2 = ((AndroidJavaObject)self).CallStatic<AndroidJavaObject>((string)0, Array.Empty<object>());
			object obj = default(object);
			if (obj != null)
			{
				object obj2 = obj as object;
				if (obj2 == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length == 0)
			{
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}
			array[0] = obj;
			AndroidJavaObject androidJavaObject3 = androidJavaObject.Call<AndroidJavaObject>("withData", array);
			object[] array2 = new object[1];
			AndroidJavaObject androidJavaObject4 = ((AndroidJavaObject)self).Call<AndroidJavaObject>((string)0, array);
			object obj3 = default(object);
			if (obj3 != null)
			{
				object obj4 = obj3 as object;
				if (obj4 == null)
				{
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
				}
			}
			if (array2.Length == 0)
			{
				IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
				throw ex4;
			}
			array2[0] = obj3;
			AndroidJavaObject androidJavaObject5 = androidJavaObject.Call<AndroidJavaObject>("withSignature", array2);
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X21_v12 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v521 @ X21_v16 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject6 = androidJavaObject.Call<AndroidJavaObject>("build", Array.Empty<object>());
			AndroidJavaObject androidJavaObject7 = androidJavaObject6;
			int num = 0;
			IntPtr intPtr5 = (IntPtr)null;
			((IDisposable)androidJavaClass).Dispose();
			int num2 = num + 1;
			bool flag = num2 == 0;
			bool flag2 = !flag;
			result = androidJavaObject7;
			if (!flag2)
			{
				bool flag3 = intPtr5 == (IntPtr)0;
				bool flag4 = !flag3;
				result = androidJavaObject7;
				if (flag4)
				{
					TypeLoadException ex5 = new TypeLoadException();
					return ((AndroidJavaObject)(object)ex5).CallStatic<AndroidJavaObject>((string)null, (object[])null);
				}
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	[Token(Token = "0x6000084")]
	[Address(RVA = "0x15C2CB4", Offset = "0x15C2CB4", Length = "0x200")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEF8F0]);\n\tv23 = *([v22 @ X8_v30]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202996B]) = v42;\nL_0015:\n\tv43 = self & 0xFF00000000;\n\tv44 = v43 == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"java.lang.Integer\");\n\t// 38 NewArr v153 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\t// 45 Box self @ X0 (System.Nullable`1<System.Int32>), typeof(System.Nullable`1<System.Int32>), &self @ X0 (System.Nullable`1<System.Int32>)\n\tv212 = self == 0;\n\tif (v212) goto L_003A;\n\t// 54 IsInst self @ X0 (System.Nullable`1<System.Int32>), typeof(System.Object), self @ X0 (System.Nullable`1<System.Int32>)\n\tv222 = self == 0;\n\tif (v222) goto L_0096;\nL_003A:\n\tv225 = v153.Length == 0;\n\tif (v225) goto L_0090;\n\tv153[0] = self;\n\tv254 = UnityEngine.AndroidJavaObject::CallStatic(v48, \"valueOf\", v153);\nL_0051:\n\tgoto L_007A;\n\tv307 = *([v302 @ X8_v14+B0]);\n\tv308 = 0;\n\tv309 = v307 + 8;\n\tv311 = *([v349 @ X11_v7-8]);\n\tv354 = v311 == v305;\n\tif (v354) goto L_0073;\n\tv331 = v348 + 1;\n\tv360 = v331 < v304;\n\tv329 = ~v360;\n\tv333 = v349 + 0x10;\n\tv313 = ~v329;\n\tif (v313) goto L_FFFFFFFF;\n\tv334 = v53;\n\tv335 = 0;\n\tv336 = 0x8909C4(v334, v305, v335, v112, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_007A;\n\tgoto L_008D;\nL_0073:\n\tv361 = *([v349 @ X11_v7]);\n\tv362 = v361 << 4;\n\tv363 = v302 + v362;\n\tv364 = v363 + 0x130;\nL_007A:\n\tSystem.IDisposable::Dispose(v48);\n\tv134 = v109 + 1;\n\tv86 = v134 == 0;\n\tv66 = ~v86;\n\tif (v66) goto L_008D;\nL_0082:\n\tv374 = v136 == 0;\n\tv133 = ~v374;\n\tif (v133) goto L_009D;\nL_008D:\n\treturn v120;\n\tv214 = new System.NullReferenceException();\nL_0090:\n\tv230 = new System.IndexOutOfRangeException();\n\tthrow v230;\n\tv240 = new System.NullReferenceException();\nL_0096:\n\tv245 = new System.ArrayTypeMismatchException();\n\tthrow v245;\nL_009D:\n\tv276 = new System.TypeLoadException();\n\tgoto L_00AA;\n\tgoto L_00AA;\nL_00AA:\n\tgoto L_00B3;\n\tv359 = UnityEngine.AndroidJavaObject::CallStatic(v276, 0, 0);\n\tv136 = *([v359 @ X0_v21 (UnityEngine.AndroidJavaObject)]);\n\tv296 = UnityEngine.AndroidJavaObject::CallStatic(v359, 0, 0);\n\tv298 = v48 == 0;\n\tif (v298) goto L_0082;\n\tgoto L_0051;\nL_00B3:\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v276, 0, 0);\n\treturn returnVal2;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static AndroidJavaObject ToAndroidInteger(this int? self)
	{
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Expected I4, but got Unknown
		//IL_00e2: Expected I, but got O
		AndroidJavaObject result;
		if ((int)((_003F?)self & 0xFF00000000L) != 0)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.lang.Integer");
			object[] array = new object[1];
			int? num = (int?)(object)self;
			if ((object)self != null)
			{
				num = (int?)(self as object);
				if ((object)self == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length == 0)
			{
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}
			array[0] = self;
			AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("valueOf", array);
			int num2 = 0;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			IntPtr intPtr = (IntPtr)null;
			((IDisposable)androidJavaClass).Dispose();
			int num3 = num2 + 1;
			bool flag = num3 == 0;
			bool flag2 = !flag;
			result = androidJavaObject2;
			if (!flag2)
			{
				bool flag3 = intPtr == (IntPtr)0;
				bool flag4 = !flag3;
				result = androidJavaObject2;
				if (flag4)
				{
					TypeLoadException ex3 = new TypeLoadException();
					return ((AndroidJavaObject)(object)ex3).CallStatic<AndroidJavaObject>((string)null, (object[])null);
				}
			}
		}
		else
		{
			result = null;
		}
		return result;
	}

	[Token(Token = "0x6000085")]
	[Address(RVA = "0x15C2EB4", Offset = "0x15C2EB4", Length = "0x1C8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBC3A8]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202996C]) = v42;\nL_0015:\n\tv43 = self == 0;\n\tif (v43) goto L_0081;\n\tv47 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v47, \"java.util.Currency\");\n\t// 37 NewArr v197 @ X0_v7 (System.Object[]), typeof(System.Object[]), 1\n\t// 44 IsInst v203 @ X0_v34, typeof(System.Object), self @ X0 (System.String)\n\tv206 = v203 == 0;\n\tif (v206) goto L_0084;\n\tv213 = v197.Length == 0;\n\tif (v213) goto L_0088;\n\tv197[0] = self;\n\tv232 = UnityEngine.AndroidJavaObject::CallStatic(v47, \"getInstance\", v197);\nL_0047:\n\tgoto L_006E;\n\tv290 = *([v285 @ X8_v11+B0]);\n\tv291 = 0;\n\tv292 = v290 + 8;\n\tv294 = *([v332 @ X11_v7-8]);\n\tv337 = v294 == v288;\n\tif (v337) goto L_0067;\n\tv314 = v331 + 1;\n\tv343 = v314 < v287;\n\tv312 = ~v343;\n\tv316 = v332 + 0x10;\n\tv296 = ~v312;\n\tif (v296) goto L_FFFFFFFF;\n\tv317 = v132;\n\tv318 = 0;\n\tv319 = 0x8909C4(v317, v288, v318, v105, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_006E;\nL_0067:\n\tv344 = *([v332 @ X11_v7]);\n\tv345 = v344 << 4;\n\tv346 = v285 + v345;\n\tv347 = v346 + 0x130;\nL_006E:\n\tSystem.IDisposable::Dispose(v47);\n\tv124 = v102 + 1;\n\tv79 = v124 == 0;\n\tv59 = ~v79;\n\tif (v59) goto L_0081;\nL_0076:\n\tv357 = v111 == 0;\n\tv123 = ~v357;\n\tif (v123) goto L_0091;\nL_0081:\n\treturn v125;\n\tv205 = new System.NullReferenceException();\nL_0084:\n\tv211 = new System.ArrayTypeMismatchException();\n\tthrow v211;\nL_0088:\n\tv223 = new System.IndexOutOfRangeException();\n\tthrow v223;\n\tthrow System.NullReferenceException;\nL_0091:\n\tv259 = new System.TypeLoadException();\n\tgoto L_009D;\nL_009D:\n\tgoto L_00A6;\n\tv342 = UnityEngine.AndroidJavaObject::CallStatic(v259, 0, 0);\n\tv111 = *([v342 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv279 = UnityEngine.AndroidJavaObject::CallStatic(v342, 0, 0);\n\tv281 = v47 == 0;\n\tif (v281) goto L_0076;\n\tgoto L_0047;\nL_00A6:\n\treturnVal2 = UnityEngine.AndroidJavaObject::CallStatic(v259, 0, 0);\n\treturn returnVal2;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static AndroidJavaObject ToAndroidCurrency(this string self)
	{
		//IL_00b0: Expected I, but got O
		bool flag = self == null;
		string result = self;
		if (!flag)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.util.Currency");
			object[] array = new object[1];
			object obj = self as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
			if (array.Length == 0)
			{
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}
			array[0] = self;
			AndroidJavaObject androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("getInstance", array);
			int num = 0;
			IntPtr intPtr = (IntPtr)null;
			AndroidJavaObject androidJavaObject2 = androidJavaObject;
			((IDisposable)androidJavaClass).Dispose();
			int num2 = num + 1;
			bool flag2 = num2 == 0;
			bool flag3 = !flag2;
			result = (string)(object)androidJavaObject2;
			if (!flag3)
			{
				bool flag4 = intPtr == (IntPtr)0;
				bool flag5 = !flag4;
				result = (string)(object)androidJavaObject2;
				if (flag5)
				{
					TypeLoadException ex3 = new TypeLoadException();
					return ((AndroidJavaObject)(object)ex3).CallStatic<AndroidJavaObject>((string)null, (object[])null);
				}
			}
		}
		return (AndroidJavaObject)(object)result;
	}

	[Token(Token = "0x6000086")]
	[Address(RVA = "0x15C0708", Offset = "0x15C0708", Length = "0x56C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EC9070]);\n\tv29 = *([v28 @ X8_v79]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202996D]) = v48;\nL_001B:\n\tv52 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v52, \"com.yandex.metrica.Revenue\");\n\t// 38 NewArr v62 @ X0_v5 (System.Object[]), typeof(System.Object[]), 2\n\tv65 = self.<Price>k__BackingField;\n\t// 46 Box v70 @ X0_v7, typeof(System.Double), &v65 @ X8_v7 (System.Double)\n\tv73 = v70 == 0;\n\tif (v73) goto L_003A;\n\t// 55 IsInst v79 @ X0_v138, typeof(System.Object), v70 @ X0_v7\n\tv83 = v79 == 0;\n\tif (v83) goto L_017D;\nL_003A:\n\tv65 = v62.Length;\n\tv86 = v62.Length == 0;\n\tif (v86) goto L_0159;\n\tv62[0] = v70;\n\tv93 = YandexAppMetricaExtensionsAndroid::ToAndroidCurrency(self.<Currency>k__BackingField);\n\tv158 = v93 == 0;\n\tif (v158) goto L_0049;\n\t// 70 IsInst v194 @ X0_v136, typeof(System.Object), v93 @ X0_v82 (UnityEngine.AndroidJavaObject)\n\tv195 = v194 == 0;\n\tif (v195) goto L_0181;\nL_0049:\n\tv65 = v62.Length;\n\tv197 = v62.Length < 1;\n\tv176 = ~v197;\n\tv174 = v62.Length - 1;\n\tv170 = v174 == 0;\n\tv198 = ~v176;\n\tv160 = v198 | v170;\n\tif (v160) goto L_015D;\n\tv62[1] = v93;\n\tv256 = UnityEngine.AndroidJavaObject::CallStatic(v52, \"newBuilder\", v62);\n\t// 101 NewArr v314 @ X0_v87 (System.Object[]), typeof(System.Object[]), 1\n\tv278 = YandexAppMetricaExtensionsAndroid::ToAndroidInteger(self.<Quantity>k__BackingField);\n\tv405 = v278 == 0;\n\tif (v405) goto L_0074;\n\t// 113 IsInst v306 @ X0_v134, typeof(System.Object), v278 @ X0_v89 (UnityEngine.AndroidJavaObject)\n\tv308 = v306 == 0;\n\tif (v308) goto L_0185;\nL_0074:\n\tv65 = v314.Length;\n\tv335 = v314.Length == 0;\n\tif (v335) goto L_0165;\n\tv314[0] = v278;\n\tv539 = UnityEngine.AndroidJavaObject::Call(v256, \"withQuantity\", v314);\n\t// 133 NewArr v425 @ X0_v94 (System.Object[]), typeof(System.Object[]), 1\n\tv662 = self.<ProductID>k__BackingField == 0;\n\tif (v662) goto L_0092;\n\t// 143 IsInst v373 @ X0_v132, typeof(System.Object), self.<ProductID>k__BackingField (System.String)\n\tv375 = v373 == 0;\n\tif (v375) goto L_0189;\nL_0092:\n\tv65 = v425.Length;\n\tv489 = v425.Length == 0;\n\tif (v489) goto L_016D;\n\tv425[0] = self.<ProductID>k__BackingField;\n\tv719 = UnityEngine.AndroidJavaObject::Call(v256, \"withProductID\", v425);\n\t// 159 NewArr v559 @ X0_v99 (System.Object[]), typeof(System.Object[]), 1\n\tv820 = self.<Payload>k__BackingField == 0;\n\tif (v820) goto L_00AC;\n\t// 169 IsInst v458 @ X0_v130, typeof(System.Object), self.<Payload>k__BackingField (System.String)\n\tv460 = v458 == 0;\n\tif (v460) goto L_018D;\nL_00AC:\n\tv65 = v559.Length;\n\tv591 = v559.Length == 0;\n\tif (v591) goto L_0173;\n\tv559[0] = self.<Payload>k__BackingField;\n\tv898 = UnityEngine.AndroidJavaObject::Call(v256, \"withPayload\", v559);\n\t// 185 NewArr v921 @ X0_v104 (System.Object[]), typeof(System.Object[]), 1\n\tv38 = self.<Receipt>k__BackingField;\n\tv685 = YandexAppMetricaExtensionsAndroid::ToAndroidReceipt(&v38 @ V0 (System.Nullable`1<YandexAppMetricaReceipt>));\n\tv937 = v685 == 0;\n\tif (v937) goto L_00CC;\n\t// 201 IsInst v527 @ X0_v128, typeof(System.Object), v685 @ X0_v106 (UnityEngine.AndroidJavaObject)\n\tv529 = v527 == 0;\n\tif (v529) goto L_0191;\nL_00CC:\n\tv65 = v921.Length;\n\tv711 = v921.Length == 0;\n\tif (v711) goto L_0179;\n\tv921[0] = v685;\n\tv947 = UnityEngine.AndroidJavaObject::Call(v256, \"withReceipt\", v921);\n\tv952 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tv65 = *([v952 @ X21_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\n\tgoto L_00E4;\n\tv957 = v952;\n\tv958 = UnityEngine.AndroidJavaObject::Call(v957, v944, v946, v943);\n\tv961 = *([v952 @ X21_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_00E4:\n\tv962 = *([v952 @ X21_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv963 = v962 == 0;\n\tif (v963) goto L_0105;\n\tv965 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_00F1;\n\tv986 = v965;\n\tv987 = UnityEngine.AndroidJavaObject::Call(v986, v944, v946, v943);\nL_00F1:\n\tv988 = *([v965 @ X21_v21 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv975 = ~v988;\n\tif (v975) goto L_0105;\n\tgoto L_0105;\n\tv997 = v977;\n\tv998 = UnityEngine.AndroidJavaObject::Call(v997, v944, v946, v943);\nL_0105:\n\tgoto L_010F;\n\tv989 = v982;\n\tv990 = UnityEngine.AndroidJavaObject::Call(v989, v944, v946, v943);\nL_010F:\n\tv844 = UnityEngine.AndroidJavaObject::Call(v256, \"build\", v849.Value);\nL_0119:\n\tgoto L_0140;\n\tv865 = *([v851 @ X8_v9+B0]);\n\tv866 = 0;\n\tv867 = v865 + 8;\n\tv869 = *([v901 @ X11_v6-8]);\n\tv915 = v869 == v854;\n\tif (v915) goto L_0139;\n\tv871 = v900 + 1;\n\tv922 = v871 < v853;\n\tv891 = ~v922;\n\tv873 = v901 + 0x10;\n\tv875 = ~v891;\n\tif (v875) goto L_FFFFFFFF;\n\tv892 = v56;\n\tv893 = 0;\n\tv894 = 0x8909C4(v892, v854, v893, v799, v34, v35, v36, v37, v796, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0140;\nL_0139:\n\tv923 = *([v901 @ X11_v6]);\n\tv924 = v923 << 4;\n\tv925 = v851 + v924;\n\tv926 = v925 + 0x130;\nL_0140:\n\tSystem.IDisposable::Dispose(v52);\n\tv816 = v809 + 1;\n\tv805 = v816 == 0;\n\tv800 = ~v805;\n\tif (v800) goto L_0156;\nL_0148:\n\tv819 = v652 == 0;\n\tv650 = ~v819;\n\tif (v650) goto L_0198;\nL_0156:\n\treturn v859;\n\tv75 = new System.NullReferenceException();\nL_0159:\n\tv91 = new System.IndexOutOfRangeException();\n\tthrow v91;\nL_015D:\n\tv187 = new System.IndexOutOfRangeException();\n\tthrow v187;\n\tthrow System.NullReferenceException;\n\tv283 = new System.NullReferenceException();\nL_0165:\n\tv338 = new System.IndexOutOfRangeException();\n\tthrow v338;\n\tthrow System.NullReferenceException;\n\tv431 = new System.NullReferenceException();\nL_016D:\n\tv492 = new System.IndexOutOfRangeException();\n\tthrow v492;\n\tv565 = new System.NullReferenceException();\nL_0173:\n\tv594 = new System.IndexOutOfRangeException();\n\tthrow v594;\n\tv692 = new System.NullReferenceException();\nL_0179:\n\tv713 = new System.IndexOutOfRangeException();\n\tthrow v713;\nL_017D:\n\tv156 = new System.ArrayTypeMismatchException();\n\tthrow v156;\nL_0181:\n\tv226 = new System.ArrayTypeMismatchException();\n\tthrow v226;\nL_0185:\n\tv312 = new System.ArrayTypeMismatchException();\n\tthrow v312;\nL_0189:\n\tv379 = new System.ArrayTypeMismatchException();\n\tthrow v379;\nL_018D:\n\tv464 = new System.ArrayTypeMismatchException();\n\tthrow v464;\nL_0191:\n\tv534 = new System.ArrayTypeMismatchException();\n\tthrow v534;\nL_0198:\n\tv658 = new System.TypeLoadException();\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\n\tgoto L_01B3;\nL_01B3:\n\tgoto L_01BC;\n\tv714 = UnityEngine.AndroidJavaObject::CallStatic(v658, 0, 0);\n\tv652 = *([v714 @ X0_v19 (UnityEngine.AndroidJavaObject)]);\n\tv721 = UnityEngine.AndroidJavaObject::CallStatic(v714, 0, 0);\n\tv724 = v52 == 0;\n\tif (v724) goto L_0148;\n\tgoto L_0119;\nL_01BC:\n\treturnVal1 = UnityEngine.AndroidJavaObject::CallStatic(v658, 0, 0);\n\treturn returnVal1;\n// 253 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe static AndroidJavaObject ToAndroidRevenue(this YandexAppMetricaRevenue self)
	{
		//IL_0077: Expected F8, but got I4
		//IL_010b: Expected F8, but got I4
		//IL_0137: Expected O, but got I4
		//IL_0215: Expected F8, but got I4
		//IL_02d0: Expected F8, but got I4
		//IL_038b: Expected F8, but got I4
		//IL_0400: Expected O, but got Ref
		//IL_045b: Expected F8, but got I4
		//IL_04b9: Expected F8, but got I
		//IL_0531: Expected I, but got O
		AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.yandex.metrica.Revenue");
		object[] array = new object[2];
		double price = self.Price;
		object obj = price;
		if (obj != null)
		{
			object obj2 = obj as object;
			if (obj2 == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		price = array.Length;
		if (array.Length != 0)
		{
			array[0] = obj;
			AndroidJavaObject androidJavaObject = self.Currency.ToAndroidCurrency();
			if (androidJavaObject != null)
			{
				object obj3 = androidJavaObject as object;
				if (obj3 == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					throw ex2;
				}
			}
			price = array.Length;
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj4 = array.Length - 1;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = androidJavaObject;
				AndroidJavaObject androidJavaObject2 = androidJavaClass.CallStatic<AndroidJavaObject>("newBuilder", array);
				object[] array2 = new object[1];
				AndroidJavaObject androidJavaObject3 = self.Quantity.ToAndroidInteger();
				if (androidJavaObject3 != null)
				{
					object obj5 = androidJavaObject3 as object;
					if (obj5 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				price = array2.Length;
				if (array2.Length != 0)
				{
					array2[0] = androidJavaObject3;
					AndroidJavaObject androidJavaObject4 = androidJavaObject2.Call<AndroidJavaObject>("withQuantity", array2);
					object[] array3 = new object[1];
					if (self.ProductID != null)
					{
						object obj6 = self.ProductID as object;
						if (obj6 == null)
						{
							ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
							throw ex4;
						}
					}
					price = array3.Length;
					if (array3.Length != 0)
					{
						array3[0] = self.ProductID;
						AndroidJavaObject androidJavaObject5 = androidJavaObject2.Call<AndroidJavaObject>("withProductID", array3);
						object[] array4 = new object[1];
						if (self.Payload != null)
						{
							object obj7 = self.Payload as object;
							if (obj7 == null)
							{
								ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
								throw ex5;
							}
						}
						price = array4.Length;
						if (array4.Length != 0)
						{
							array4[0] = self.Payload;
							AndroidJavaObject androidJavaObject6 = androidJavaObject2.Call<AndroidJavaObject>("withPayload", array4);
							object[] array5 = new object[1];
							YandexAppMetricaReceipt? yandexAppMetricaReceipt = self.Receipt;
							AndroidJavaObject androidJavaObject7 = ((YandexAppMetricaReceipt?)(object)(&yandexAppMetricaReceipt)).ToAndroidReceipt();
							if (androidJavaObject7 != null)
							{
								object obj8 = androidJavaObject7 as object;
								if (obj8 == null)
								{
									ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
									throw ex6;
								}
							}
							price = array5.Length;
							if (array5.Length != 0)
							{
								array5[0] = androidJavaObject7;
								AndroidJavaObject androidJavaObject8 = androidJavaObject2.Call<AndroidJavaObject>("withReceipt", array5);
								IntPtr intPtr = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ X21_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
								price = 0.0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v952 @ X21_v17 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
								if (0u != 0)
								{
									IntPtr intPtr2 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v965 @ X21_v21 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
									if ((IntPtr)0 != (IntPtr)0)
									{
									}
								}
								AndroidJavaObject androidJavaObject9 = androidJavaObject2.Call<AndroidJavaObject>("build", Array.Empty<object>());
								int num = 0;
								AndroidJavaObject androidJavaObject10 = androidJavaObject9;
								IntPtr intPtr3 = (IntPtr)null;
								((IDisposable)androidJavaClass).Dispose();
								int num2 = num + 1;
								bool flag5 = num2 == 0;
								bool flag6 = !flag5;
								AndroidJavaObject result = androidJavaObject10;
								if (!flag6)
								{
									bool flag7 = intPtr3 == (IntPtr)0;
									bool flag8 = !flag7;
									result = androidJavaObject10;
									if (flag8)
									{
										TypeLoadException ex7 = new TypeLoadException();
										return ((AndroidJavaObject)(object)ex7).CallStatic<AndroidJavaObject>((string)null, (object[])null);
									}
								}
								return result;
							}
							IndexOutOfRangeException ex8 = new IndexOutOfRangeException();
							throw ex8;
						}
						IndexOutOfRangeException ex9 = new IndexOutOfRangeException();
						throw ex9;
					}
					IndexOutOfRangeException ex10 = new IndexOutOfRangeException();
					throw ex10;
				}
				IndexOutOfRangeException ex11 = new IndexOutOfRangeException();
				throw ex11;
			}
			IndexOutOfRangeException ex12 = new IndexOutOfRangeException();
			throw ex12;
		}
		IndexOutOfRangeException ex13 = new IndexOutOfRangeException();
		throw ex13;
	}
}
