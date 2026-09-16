using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.Notifications.Android
{
	[Token(Token = "0x20000F0")]
	internal static class AndroidNotificationNative
	{
		[Token(Token = "0x4000447")]
		private const string ANDROID_JAVA_CLASS = "com.sglib.easymobile.androidnative.notification.NotificationUnityInterface";

		[Token(Token = "0x60008AC")]
		[Address(RVA = "0xC03520", Offset = "0xC03520", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1F0B910]);\n\tv35 = *([v34 @ X8_v28]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, categoriesJson, listenerName, backgroundNotificationMethodName, foregroundNotificationMethodName, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022FC0]) = v50;\nL_001F:\n\t// 31 NewArr v55 @ X0_v3 (System.Object[]), typeof(System.Object[]), 5\n\tv58 = categoryGroupsJson == 0;\n\tif (v58) goto L_002B;\n\t// 40 IsInst v100 @ X0_v27, typeof(System.Object), categoryGroupsJson @ X0 (System.String)\nL_002B:\n\tv173 = v55.Length;\n\tv107 = v55.Length == 0;\n\tif (v107) goto L_0099;\n\tv55[0] = categoryGroupsJson;\n\tv108 = categoriesJson == 0;\n\tif (v108) goto L_0038;\n\t// 52 IsInst v227 @ X0_v25, typeof(System.Object), categoriesJson @ X1 (System.String)\n\tv173 = v55.Length;\nL_0038:\n\tv244 = v173 < 1;\n\tv150 = ~v244;\n\tv145 = v173 - 1;\n\tv135 = v145 == 0;\n\tv245 = ~v150;\n\tv110 = v245 | v135;\n\tif (v110) goto L_0099;\n\tv55[1] = categoriesJson;\n\tv248 = listenerName == 0;\n\tif (v248) goto L_004E;\n\t// 74 IsInst v228 @ X0_v23, typeof(System.Object), listenerName @ X2 (System.String)\n\tv173 = v55.Length;\nL_004E:\n\tv251 = v173 < 2;\n\tv151 = ~v251;\n\tv146 = v173 - 2;\n\tv136 = v146 == 0;\n\tv252 = ~v151;\n\tv111 = v252 | v136;\n\tif (v111) goto L_0099;\n\tv55[2] = listenerName;\n\tv253 = backgroundNotificationMethodName == 0;\n\tif (v253) goto L_0064;\n\t// 96 IsInst v229 @ X0_v21, typeof(System.Object), backgroundNotificationMethodName @ X3 (System.String)\n\tv173 = v55.Length;\nL_0064:\n\tv256 = v173 < 3;\n\tv152 = ~v256;\n\tv147 = v173 - 3;\n\tv137 = v147 == 0;\n\tv257 = ~v152;\n\tv112 = v257 | v137;\n\tif (v112) goto L_0099;\n\tv55[3] = backgroundNotificationMethodName;\n\tv258 = foregroundNotificationMethodName == 0;\n\tif (v258) goto L_007A;\n\t// 118 IsInst v230 @ X0_v19, typeof(System.Object), foregroundNotificationMethodName @ X4 (System.String)\n\tv173 = v55.Length;\nL_007A:\n\tv261 = v173 < 4;\n\tv153 = ~v261;\n\tv148 = v173 - 4;\n\tv138 = v148 == 0;\n\tv262 = ~v153;\n\tv113 = v262 | v138;\n\tif (v113) goto L_0099;\n\tv55[4] = foregroundNotificationMethodName;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.notification.NotificationUnityInterface\", \"_Init\", v55);\n\treturn;\nL_0099:\n\tv174 = new System.IndexOutOfRangeException();\n\tgoto L_009E;\n\tv241 = new System.ArrayTypeMismatchException();\nL_009E:\n\tthrow v247;\n\tthrow System.NullReferenceException;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void _InitNativeClient(string categoryGroupsJson, string categoriesJson, string listenerName, string backgroundNotificationMethodName, string foregroundNotificationMethodName)
		{
			//IL_003e: Expected O, but got I4
			//IL_0212: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_0270: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			//IL_02ce: Expected O, but got I
			//IL_0148: Expected O, but got I4
			//IL_032c: Expected O, but got I
			//IL_0198: Expected O, but got I4
			object[] array = new object[5];
			if (categoryGroupsJson != null)
			{
				object obj = categoryGroupsJson as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = categoryGroupsJson;
				if (categoriesJson != null)
				{
					object obj3 = categoriesJson as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = categoriesJson;
					if (listenerName != null)
					{
						object obj5 = listenerName as object;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = listenerName;
						if (backgroundNotificationMethodName != null)
						{
							object obj7 = backgroundNotificationMethodName as object;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = backgroundNotificationMethodName;
							if (foregroundNotificationMethodName != null)
							{
								object obj9 = foregroundNotificationMethodName as object;
								obj2 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj2 < 4L;
							bool flag14 = !flag13;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = foregroundNotificationMethodName;
								AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.notification.NotificationUnityInterface", "_Init", array);
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008AD")]
		[Address(RVA = "0xC03698", Offset = "0xC03698", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_0025;\n\tv46 = *([1F06660]);\n\tv47 = *([v46 @ X8_v40]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, delaySecs, repeatSecs, title, body, userInfoJson, categoryId, smallIcon, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2022FC1]) = v59;\nL_0025:\n\t// 37 NewArr v64 @ X0_v3 (System.Object[]), typeof(System.Object[]), 9\n\tv67 = id == 0;\n\tif (v67) goto L_0032;\n\t// 46 IsInst v123 @ X0_v43, typeof(System.Object), id @ X0 (System.String)\nL_0032:\n\tv130 = v64.Length == 0;\n\tif (v130) goto L_0107;\n\tv64[0] = id;\n\t// 58 Box v136 @ X0_v14, typeof(System.Int64), &delaySecs @ X1 (System.Int64)\n\tv362 = v136 == 0;\n\tif (v362) goto L_0045;\n\t// 65 IsInst v331 @ X0_v41, typeof(System.Object), v136 @ X0_v14\nL_0045:\n\tv367 = v64.Length < 1;\n\tv212 = ~v367;\n\tv203 = v64.Length - 1;\n\tv185 = v203 == 0;\n\tv368 = ~v212;\n\tv140 = v368 | v185;\n\tif (v140) goto L_0107;\n\tv64[1] = v136;\n\t// 85 Box v371 @ X0_v17, typeof(System.Int64), &repeatSecs @ X2 (System.Int64)\n\tv372 = v371 == 0;\n\tif (v372) goto L_005F;\n\t// 92 IsInst v332 @ X0_v39, typeof(System.Object), v371 @ X0_v17\nL_005F:\n\tv263 = v64.Length;\n\tv375 = v64.Length < 2;\n\tv213 = ~v375;\n\tv204 = v64.Length - 2;\n\tv186 = v204 == 0;\n\tv376 = ~v213;\n\tv141 = v376 | v186;\n\tif (v141) goto L_0107;\n\tv64[2] = v371;\n\tv377 = title == 0;\n\tif (v377) goto L_0076;\n\t// 114 IsInst v333 @ X0_v37, typeof(System.Object), title @ X3 (System.String)\n\tv263 = v64.Length;\nL_0076:\n\tv380 = v263 < 3;\n\tv214 = ~v380;\n\tv205 = v263 - 3;\n\tv187 = v205 == 0;\n\tv381 = ~v214;\n\tv142 = v381 | v187;\n\tif (v142) goto L_0107;\n\tv64[3] = title;\n\tv382 = body == 0;\n\tif (v382) goto L_008C;\n\t// 136 IsInst v334 @ X0_v35, typeof(System.Object), body @ X4 (System.String)\n\tv263 = v64.Length;\nL_008C:\n\tv385 = v263 < 4;\n\tv215 = ~v385;\n\tv206 = v263 - 4;\n\tv188 = v206 == 0;\n\tv386 = ~v215;\n\tv143 = v386 | v188;\n\tif (v143) goto L_0107;\n\tv64[4] = body;\n\tv387 = userInfoJson == 0;\n\tif (v387) goto L_00A2;\n\t// 158 IsInst v335 @ X0_v33, typeof(System.Object), userInfoJson @ X5 (System.String)\n\tv263 = v64.Length;\nL_00A2:\n\tv390 = v263 < 5;\n\tv216 = ~v390;\n\tv207 = v263 - 5;\n\tv189 = v207 == 0;\n\tv391 = ~v216;\n\tv144 = v391 | v189;\n\tif (v144) goto L_0107;\n\tv64[5] = userInfoJson;\n\tv392 = categoryId == 0;\n\tif (v392) goto L_00B8;\n\t// 180 IsInst v336 @ X0_v31, typeof(System.Object), categoryId @ X6 (System.String)\n\tv263 = v64.Length;\nL_00B8:\n\tv395 = v263 < 6;\n\tv217 = ~v395;\n\tv208 = v263 - 6;\n\tv190 = v208 == 0;\n\tv396 = ~v217;\n\tv145 = v396 | v190;\n\tif (v145) goto L_0107;\n\tv64[6] = categoryId;\n\tv397 = smallIcon == 0;\n\tif (v397) goto L_00CE;\n\t// 202 IsInst v337 @ X0_v29, typeof(System.Object), smallIcon @ X7 (System.String)\n\tv263 = v64.Length;\nL_00CE:\n\tv400 = v263 < 7;\n\tv218 = ~v400;\n\tv209 = v263 - 7;\n\tv191 = v209 == 0;\n\tv401 = ~v218;\n\tv146 = v401 | v191;\n\tif (v146) goto L_0107;\n\tv64[7] = smallIcon;\n\tv402 = *([v22 @ X29_v1+10]) == 0;\n\tif (v402) goto L_00E5;\n\t// 225 IsInst v338 @ X0_v27, typeof(System.Object), [v22 @ X29_v1+10]\n\tv263 = v64.Length;\nL_00E5:\n\tv405 = v263 < 8;\n\tv219 = ~v405;\n\tv210 = v263 - 8;\n\tv192 = v210 == 0;\n\tv406 = ~v219;\n\tv147 = v406 | v192;\n\tif (v147) goto L_0107;\n\tv64[8] = *([v22 @ X29_v1+10]);\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.notification.NotificationUnityInterface\", \"_ScheduleLocalNotification\", v64);\n\treturn;\nL_0107:\n\tv264 = new System.IndexOutOfRangeException();\n\tgoto L_010C;\n\tv361 = new System.ArrayTypeMismatchException();\nL_010C:\n\tthrow v364;\n\tthrow System.NullReferenceException;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void _ScheduleLocalNotification(string id, long delaySecs, long repeatSecs, string title, string body, string userInfoJson, string categoryId, string smallIcon, string largeIcon)
		{
			//IL_00d5: Expected O, but got I4
			//IL_0162: Expected O, but got I4
			//IL_018e: Expected O, but got I4
			//IL_0430: Expected O, but got I
			//IL_020e: Expected O, but got I4
			//IL_048e: Expected O, but got I
			//IL_025e: Expected O, but got I4
			//IL_04ec: Expected O, but got I
			//IL_02ae: Expected O, but got I4
			//IL_054a: Expected O, but got I
			//IL_02fe: Expected O, but got I4
			//IL_05a8: Expected O, but got I
			//IL_034e: Expected O, but got I4
			//IL_0606: Expected O, but got I
			//IL_039b: Expected O, but got I
			//IL_03cd: Expected O, but got I
			//IL_03ae: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			object[] array = new object[9];
			if (id != null)
			{
				object obj3 = id as object;
			}
			if (array.Length != 0)
			{
				array[0] = id;
				object obj4 = delaySecs;
				if (obj4 != null)
				{
					object obj5 = obj4 as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj6 = array.Length - 1;
				bool flag3 = obj6 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = obj4;
					object obj7 = repeatSecs;
					if (obj7 != null)
					{
						object obj8 = obj7 as object;
					}
					object obj9 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj10 = array.Length - 2;
					bool flag7 = obj10 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = obj7;
						if (title != null)
						{
							object obj11 = title as object;
							obj9 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj9 < 3L;
						bool flag10 = !flag9;
						object obj12 = (long)(IntPtr)obj9 - 3L;
						bool flag11 = obj12 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = title;
							if (body != null)
							{
								object obj13 = body as object;
								obj9 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj9 < 4L;
							bool flag14 = !flag13;
							object obj14 = (long)(IntPtr)obj9 - 4L;
							bool flag15 = obj14 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = body;
								if (userInfoJson != null)
								{
									object obj15 = userInfoJson as object;
									obj9 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj9 < 5L;
								bool flag18 = !flag17;
								object obj16 = (long)(IntPtr)obj9 - 5L;
								bool flag19 = obj16 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = userInfoJson;
									if (categoryId != null)
									{
										object obj17 = categoryId as object;
										obj9 = array.Length;
									}
									bool flag21 = (long)(IntPtr)obj9 < 6L;
									bool flag22 = !flag21;
									object obj18 = (long)(IntPtr)obj9 - 6L;
									bool flag23 = obj18 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = categoryId;
										if (smallIcon != null)
										{
											object obj19 = smallIcon as object;
											obj9 = array.Length;
										}
										bool flag25 = (long)(IntPtr)obj9 < 7L;
										bool flag26 = !flag25;
										object obj20 = (long)(IntPtr)obj9 - 7L;
										bool flag27 = obj20 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[7] = smallIcon;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+10]");
											if ((IntPtr)0 != (IntPtr)0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+10]");
												object obj21 = 0 as object;
												obj9 = array.Length;
											}
											bool flag29 = (long)(IntPtr)obj9 < 8L;
											bool flag30 = !flag29;
											object obj22 = (long)(IntPtr)obj9 - 8L;
											bool flag31 = obj22 == null;
											bool flag32 = !flag30;
											if (!(flag32 || flag31))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1+10]");
												array[8] = 0;
												AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.notification.NotificationUnityInterface", "_ScheduleLocalNotification", array);
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
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008AE")]
		[Address(RVA = "0xC0390C", Offset = "0xC0390C", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EE9B80]);\n\tv27 = *([v26 @ X8_v45]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022FC2]) = v46;\nL_001E:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0028:\n\tcallback = EasyMobile.Internal.Util::NullArgumentTest(callback);\n\tv69 = new System.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>();\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::.ctor(v69);\n\tv78 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_003F;\n\tv83 = v78;\n\tv84 = System.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::.ctor(v83, v73);\n\tv87 = *([v78 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_003F:\n\tv88 = *([v78 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv89 = v88 == 0;\n\tif (v89) goto L_0060;\n\tv91 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_004C;\n\tv113 = v91;\n\tv114 = System.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::.ctor(v113, v73);\nL_004C:\n\tv115 = *([v91 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv103 = ~v115;\n\tif (v103) goto L_0060;\n\tgoto L_0060;\n\tv136 = v97;\n\tv137 = System.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::.ctor(v136, v73);\nL_0060:\n\tgoto L_006E;\n\tv116 = v108;\n\tv117 = System.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::.ctor(v116, v73);\nL_006E:\n\tv130 = EasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.notification.NotificationUnityInterface\", \"_GetPendingNotificationRequestsJson\", v122.Value);\n\tv142 = UnityEngine.AndroidJavaObject::GetRawObject(v130);\n\tv199 = EasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(&v142 @ X0_v16 (System.IntPtr), 0, v122.Value);\n\tv200 = v199 == 0;\n\tif (v200) goto L_00BC;\n\tv250 = UnityEngine.AndroidJavaObject::GetRawObject(v130);\n\tv189 = UnityEngine.AndroidJNIHelper::ConvertFromJNIArray(v250);\n\tv315 = v189.Length;\n\tv257 = v189.Length < 1;\n\tif (v257) goto L_00BC;\nL_0095:\n\tv332 = v296 < v315;\n\tv305 = ~v332;\n\tif (v305) goto L_00D6;\n\tv312 = EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest::FromJson(v189[v296 @ X23_v6 (System.Int32)]);\n\tv336 = v312 == 0;\n\tif (v336) goto L_00AC;\n\tSystem.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::Add(v69, v312);\nL_00AC:\n\tv315 = v189.Length;\n\tv296 = v296 + 1;\n\tv256 = v296 < v189.Length;\n\tif (v256) goto L_0095;\nL_00BC:\n\tUnityEngine.AndroidJavaObject::Dispose(v130);\n\tv294 = System.Collections.Generic.List`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest>::ToArray(v69);\n\tSystem.Action`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest[]>::Invoke(callback, v294);\n\treturn;\nL_00D6:\n\tv335 = new System.IndexOutOfRangeException();\n\tthrow v335;\n\tv188 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void _GetPendingLocalNotifications(Action<AndroidNotificationRequest[]> callback)
		{
			//IL_00aa: Expected O, but got I
			Action<AndroidNotificationRequest[]> action = Util.NullArgumentTest(callback);
			List<AndroidNotificationRequest> list = new List<AndroidNotificationRequest>();
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X21_v1 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X21_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidJavaObject androidJavaObject = AndroidUtil.CallJavaStaticMethod<AndroidJavaObject>("com.sglib.easymobile.androidnative.notification.NotificationUnityInterface", "_GetPendingNotificationRequestsJson", Array.Empty<object>());
			IntPtr rawObject = androidJavaObject.GetRawObject();
			AndroidJavaObject androidJavaObject2 = AndroidUtil.CallJavaStaticMethod<AndroidJavaObject>((string)(long)rawObject, null, Array.Empty<object>());
			if (androidJavaObject2 != null)
			{
				IntPtr rawObject2 = androidJavaObject.GetRawObject();
				string[] array = AndroidJNIHelper.ConvertFromJNIArray<string[]>(rawObject2);
				int num = array.Length;
				if (array.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							AndroidNotificationRequest androidNotificationRequest = AndroidNotificationRequest.FromJson(array[num2]);
							if (androidNotificationRequest != null)
							{
								list.Add(androidNotificationRequest);
							}
							num = array.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < array.Length);
				}
			}
			androidJavaObject.Dispose();
			AndroidNotificationRequest[] obj = list.ToArray();
			callback(obj);
		}

		[Token(Token = "0x60008AF")]
		[Address(RVA = "0xC03C08", Offset = "0xC03C08", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA5780]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FC3]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv46 = id == 0;\n\tif (v46) goto L_0024;\n\t// 32 IsInst v51 @ X0_v12, typeof(System.Object), id @ X0 (System.String)\nL_0024:\n\tv58 = v43.Length == 0;\n\tif (v58) goto L_0036;\n\tv43[0] = id;\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.notification.NotificationUnityInterface\", \"_CancelPendingLocalNotificationRequest\", v43);\n\treturn;\n\tv47 = new System.NullReferenceException();\nL_0036:\n\tv63 = new System.IndexOutOfRangeException();\n\tgoto L_003B;\n\tv75 = new System.ArrayTypeMismatchException();\nL_003B:\n\tthrow v77;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void _CancelPendingLocalNotificationRequest(string id)
		{
			object[] array = new object[1];
			if (id != null)
			{
				object obj = id as object;
			}
			if (array.Length != 0)
			{
				array[0] = id;
				AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.notification.NotificationUnityInterface", "_CancelPendingLocalNotificationRequest", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60008B0")]
		[Address(RVA = "0xC03CC0", Offset = "0xC03CC0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EEA118]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FC4]) = v37;\nL_0016:\n\tv42 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_001F;\n\tv47 = v42;\n\tv48 = 0x8907BC(v47, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv51 = *([v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_001F:\n\tv52 = *([v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv53 = v52 == 0;\n\tif (v53) goto L_0040;\n\tv55 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002C;\n\tv77 = v55;\n\tv78 = 0x8907BC(v77, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002C:\n\tv79 = *([v55 @ X19_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv65 = ~v79;\n\tif (v65) goto L_0040;\n\tgoto L_0040;\n\tv98 = v70;\n\tv99 = 0x8907BC(v98, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0040:\n\tgoto L_0050;\n\tv80 = v72;\n\tv81 = 0x8907BC(v80, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0050:\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.notification.NotificationUnityInterface\", \"_CancelAllPendingLocalNotificationRequests\", v85.Value);\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void _CancelAllPendingLocalNotificationRequests()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X19_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.notification.NotificationUnityInterface", "_CancelAllPendingLocalNotificationRequests");
		}

		[Token(Token = "0x60008B1")]
		[Address(RVA = "0xC03DA0", Offset = "0xC03DA0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ED2E58]);\n\tv17 = *([v16 @ X8_v19]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022FC5]) = v37;\nL_0016:\n\tv42 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_001F;\n\tv47 = v42;\n\tv48 = 0x8907BC(v47, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv51 = *([v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_001F:\n\tv52 = *([v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv53 = v52 == 0;\n\tif (v53) goto L_0040;\n\tv55 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_002C;\n\tv77 = v55;\n\tv78 = 0x8907BC(v77, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002C:\n\tv79 = *([v55 @ X19_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv65 = ~v79;\n\tif (v65) goto L_0040;\n\tgoto L_0040;\n\tv98 = v70;\n\tv99 = 0x8907BC(v98, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0040:\n\tgoto L_0050;\n\tv80 = v72;\n\tv81 = 0x8907BC(v80, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0050:\n\tEasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.notification.NotificationUnityInterface\", \"_CancelAllShownNotifications\", v85.Value);\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void _CancelAllShownNotifications()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X19_v2 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X19_v6 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			AndroidUtil.CallJavaStaticMethod("com.sglib.easymobile.androidnative.notification.NotificationUnityInterface", "_CancelAllShownNotifications");
		}
	}
}
