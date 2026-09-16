using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal.Notifications.Android;
using EasyMobile.MiniJSON;
using UnityEngine;

namespace EasyMobile.Internal.Notifications
{
	[Token(Token = "0x20000E8")]
	internal class AndroidLocalNotificationClient : ILocalNotificationClient
	{
		[Token(Token = "0x4000428")]
		[FieldOffset(Offset = "0x10")]
		private bool mIsInitialized;

		[Token(Token = "0x4000429")]
		[FieldOffset(Offset = "0x18")]
		private NotificationsSettings mSettings;

		[Token(Token = "0x6000881")]
		[Address(RVA = "0xC04280", Offset = "0xC04280", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF3A60]);\n\tv31 = *([v30 @ X8_v31]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, settings, listener, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022FC9]) = v48;\nL_0019:\n\tthis.mSettings = settings;\n\tv51 = EasyMobile.Internal.Notifications.Android.AndroidNotificationHelper::ToJson(settings.mCategoryGroups);\n\tv60 = new System.Collections.Generic.List`1<EasyMobile.NotificationCategory>();\n\tSystem.Collections.Generic.List`1<EasyMobile.NotificationCategory>::.ctor(v60);\n\tSystem.Collections.Generic.List`1<EasyMobile.NotificationCategory>::Add(v60, settings.mDefaultCategory);\n\tv157 = settings.mUserCategories == 0;\n\tif (v157) goto L_003D;\n\tSystem.Collections.Generic.List`1<EasyMobile.NotificationCategory>::AddRange(v60, settings.mUserCategories);\nL_003D:\n\tv166 = System.Collections.Generic.List`1<EasyMobile.NotificationCategory>::ToArray(v60);\n\tv61 = EasyMobile.Internal.Notifications.Android.AndroidNotificationHelper::ToJson(v166);\n\tv168 = listener->klass;\n\tv172 = *([v168 @ X8_v14 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]) == 0;\n\tif (v172) goto L_0066;\n\tv214 = *([v168 @ X8_v14 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+B0]) + 8;\nL_0051:\n\tv219 = *([v214 @ X11_v17-8]) == EasyMobile.Internal.Notifications.INotificationListener;\n\tif (v219) goto L_0069;\n\tv213 = v213 + 1;\n\tv224 = v213 < *([v168 @ X8_v14 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]);\n\tv195 = ~v224;\n\tv214 = v214 + 0x10;\n\tv179 = ~v195;\n\tif (v179) goto L_0051;\nL_0066:\n\tv245 = 0x8909C4(listener, EasyMobile.Internal.Notifications.INotificationListener, 4, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0070;\nL_0069:\n\tv226 = *([v214 @ X11_v17]) + 4;\n\tv227 = v226 << 4;\n\tv228 = v168 + v227;\n\tv245 = v228 + 0x130;\nL_0070:\n\t*([v245 @ X0_v14])(v250, listener, *([v245 @ X0_v14+8]), v327, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv251 = listener->klass;\n\tv255 = *([v251 @ X8_v17 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]) == 0;\n\tif (v255) goto L_0094;\n\tv297 = *([v251 @ X8_v17 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+B0]) + 8;\nL_007F:\n\tv302 = *([v297 @ X11_v12-8]) == EasyMobile.Internal.Notifications.INotificationListener;\n\tif (v302) goto L_0097;\n\tv296 = v296 + 1;\n\tv307 = v296 < *([v251 @ X8_v17 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]);\n\tv278 = ~v307;\n\tv297 = v297 + 0x10;\n\tv262 = ~v278;\n\tif (v262) goto L_007F;\nL_0094:\n\tv328 = 0x8909C4(listener, EasyMobile.Internal.Notifications.INotificationListener, 6, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_009E;\nL_0097:\n\tv309 = *([v297 @ X11_v12]) + 6;\n\tv310 = v309 << 4;\n\tv311 = v251 + v310;\n\tv328 = v311 + 0x130;\nL_009E:\n\t*([v328 @ X0_v17])(v333, listener, *([v328 @ X0_v17+8]), v327, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv335 = EasyMobile.Internal.ReflectionUtil::GetMethodName(v333);\n\tgoto L_00CE;\n\tv340 = *([v336 @ X8_v20+B0]);\n\tv341 = 0;\n\tv342 = v340 + 8;\n\tv344 = *([v381 @ X11_v7-8]);\n\tv386 = v344 == v337;\n\tif (v386) goto L_00C6;\n\tv364 = v380 + 1;\n\tv391 = v364 < v339;\n\tv362 = ~v391;\n\tv366 = v381 + 0x10;\n\tv346 = ~v362;\n\tif (v346) goto L_FFFFFFFF;\n\tv367 = 5;\n\tv368 = v20;\n\tv369 = 0x8909C4(v368, v337, v367, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00CE;\nL_00C6:\n\tv392 = *([v381 @ X11_v7]);\n\tv393 = v392 + 5;\n\tv394 = v393 << 4;\n\tv395 = v336 + v394;\n\tv396 = v395 + 0x130;\nL_00CE:\n\tv403 = EasyMobile.Internal.Notifications.INotificationListener::get_NativeNotificationFromForegroundHandler(listener);\n\tv405 = EasyMobile.Internal.ReflectionUtil::GetMethodName(v403);\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationNative::_InitNativeClient(v51, v61, v250, v335, v405);\n\tthis.mIsInitialized = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init(NotificationsSettings settings, INotificationListener listener)
		{
			//IL_00a9: Expected I, but got O
			//IL_02cf: Expected I, but got O
			//IL_00e4: Expected O, but got I
			//IL_01c3: Expected O, but got I
			//IL_016f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0174: Expected O, but got Unknown
			//IL_0191: Expected O, but got I
			//IL_01a0: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_024e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0253: Expected O, but got Unknown
			//IL_0270: Expected O, but got I
			//IL_027f: Expected O, but got I
			//IL_020f: Expected O, but got I
			mSettings = settings;
			string categoryGroupsJson = AndroidNotificationHelper.ToJson(settings.CategoryGroups);
			List<NotificationCategory> list = new List<NotificationCategory>();
			list.Add(settings.DefaultCategory);
			bool flag = settings.UserCategories == null;
			IntPtr intPtr = (IntPtr)0;
			if (!flag)
			{
				list.AddRange(settings.UserCategories);
				intPtr = (IntPtr)0;
			}
			NotificationCategory[] categories = list.ToArray();
			string categoriesJson = AndroidNotificationHelper.ToJson(categories);
			IntPtr intPtr2 = (IntPtr)listener;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v14 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0149;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v14 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X11_v17-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INotificationListener))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v14 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]");
				bool flag2 = (long)num2 < 0L;
				bool flag3 = !flag2;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag3)
				{
					continue;
				}
				goto IL_0149;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr2 + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			int num4 = (int)(long)intPtr;
			goto IL_02bd;
			IL_0228:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 6;
			goto IL_031e;
			IL_031e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v328 @ X0_v17] (should have been resolved before IL gen)");
			Delegate method = default(Delegate);
			string methodName = ReflectionUtil.GetMethodName(method);
			NativeNotificationHandler nativeNotificationFromForegroundHandler = listener.NativeNotificationFromForegroundHandler;
			string methodName2 = ReflectionUtil.GetMethodName(nativeNotificationFromForegroundHandler);
			string listenerName = default(string);
			AndroidNotificationNative._InitNativeClient(categoryGroupsJson, categoriesJson, listenerName, methodName, methodName2);
			mIsInitialized = true;
			return;
			IL_0149:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 4;
			goto IL_02bd;
			IL_02bd:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v245 @ X0_v14] (should have been resolved before IL gen)");
			IntPtr intPtr3 = (IntPtr)listener;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v17 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0228;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v17 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+B0]");
			object obj5 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v297 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INotificationListener))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ X8_v17 (Il2CppClass<EasyMobile.Internal.Notifications.INotificationListener>)+126]");
				bool flag4 = (long)num6 < 0L;
				bool flag5 = !flag4;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag5)
				{
					continue;
				}
				goto IL_0228;
			}
			object obj6 = obj5 + 6;
			int num7 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr3 + (long)num7;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_031e;
		}

		[Token(Token = "0x6000882")]
		[Address(RVA = "0xC044E0", Offset = "0xC044E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsInitialized;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsInitialized()
		{
			return mIsInitialized;
		}

		[Token(Token = "0x6000883")]
		[Address(RVA = "0xC044E8", Offset = "0xC044E8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1ED0078]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, id, fireDate, content, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022FCA]) = v47;\nL_001B:\n\tv50 = 0xE95E98(&fireDate @ X2 (System.DateTime), 0, fireDate, content, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_002C;\n\tv59 = *([v55 @ X8_v3+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002C;\n\tv68 = v55;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v68, v49, fireDate, content, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002C:\n\tv67 = System.DateTime::get_Now();\n\tv72 = System.DateTime::op_LessThanOrEqual(v50, v67);\n\tv74 = v72 == 0;\n\tif (v74) goto L_0049;\n\tgoto L_0042;\n\tv86 = *([v77 @ X0_v18 (Il2CppClass<System.TimeSpan>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0042;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v77, v69, v71, content, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv90 = System.TimeSpan;\nL_0042:\n\tv105 = v93.Zero;\n\tgoto L_005A;\nL_0049:\n\tgoto L_0050;\n\tv95 = *([v81 @ X0_v11+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0050;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v81, v69, v71, content, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0050:\n\tv103 = System.DateTime::get_Now();\n\tv110 = System.DateTime::op_Subtraction(v50, v103);\nL_005A:\n\tEasyMobile.Internal.Notifications.AndroidLocalNotificationClient::ScheduleLocalNotification(this, id, v105, content, 0);\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ScheduleLocalNotification(string id, DateTime fireDate, NotificationContent content)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E95E98 (inside System.DateTime::ParseExact +0x1D0)");
			DateTime now = DateTime.Now;
			DateTime dateTime = default(DateTime);
			TimeSpan delay;
			if (!(dateTime <= now))
			{
				DateTime now2 = DateTime.Now;
				TimeSpan timeSpan = dateTime - now2;
				delay = timeSpan;
			}
			else
			{
				delay = TimeSpan.Zero;
			}
			ScheduleLocalNotification(id, delay, content, default(NotificationRepeat));
		}

		[Token(Token = "0x6000884")]
		[Address(RVA = "0xC04614", Offset = "0xC04614", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Notifications.AndroidLocalNotificationClient::ScheduleLocalNotification(this, id, delay, content, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ScheduleLocalNotification(string id, TimeSpan delay, NotificationContent content)
		{
			ScheduleLocalNotification(id, delay, content, default(NotificationRepeat));
		}

		[Token(Token = "0x6000885")]
		[Address(RVA = "0xC0461C", Offset = "0xC0461C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv40 = *([1ED5D58]);\n\tv41 = *([v40 @ X8_v21]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, id, delay, content, repeat, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022FCB]) = v56;\nL_001F:\n\tv58 = ~this.mIsInitialized;\n\tif (v58) goto L_0035;\n\tv61 = 0x9BD218(&delay @ X2 (System.TimeSpan), 0, delay, content, repeat, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv69 = repeat == 0;\n\tif (v69) goto L_FFFFFFFF;\n\tv94 = EasyMobile.NotificationRepeatExtension::ToSecondInterval(repeat);\n\tv98 = content == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0053;\n\tgoto L_0084;\nL_0035:\n\tgoto L_004B;\n\tv70 = *([v64 @ X0_v2+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_004B;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v64, id, delay, content, repeat, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004B:\n\tUnityEngine.Debug::Log(\"Please initialize first.\");\n\treturn;\nL_0053:\n\tv108 = content.userInfo == 0;\n\tif (v108) goto L_FFFFFFFF;\n\tv176 = EasyMobile.MiniJSON.Json::Serialize(content.userInfo);\n\tgoto L_005D;\nL_005D:\n\tv188 = content + 0x38;\n\tv118 = System.String::IsNullOrEmpty(content.categoryId);\n\tv187 = v118 == 0;\n\tif (v187) goto L_0075;\n\tv124 = this.mSettings;\n\tv188 = v124.mDefaultCategory + 0x10;\nL_0075:\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationNative::_ScheduleLocalNotification(id, v46, v104, content.title, content.body, v110, *([v188 @ X26_v5]), content.smallIcon, content.largeIcon);\n\treturn;\nL_0084:\n\tthrow System.NullReferenceException;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ScheduleLocalNotification(string id, TimeSpan delay, NotificationContent content, NotificationRepeat repeat)
		{
			//IL_008c: Expected F8, but got I4
			//IL_0138: Expected O, but got I
			//IL_01a4: Expected I8, but got F8
			//IL_0103: Expected O, but got I
			if (mIsInitialized)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD218 (inside System.TimeSpan::TimeToTicks +0x298)");
				double num2;
				if (repeat != NotificationRepeat.None)
				{
					double num = repeat.ToSecondInterval();
					bool flag = content == null;
					bool flag2 = !flag;
					num2 = num;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					num2 = -1.0;
				}
				string userInfoJson;
				if (content.userInfo != null)
				{
					string text = Json.Serialize(content.userInfo);
					userInfoJson = text;
				}
				else
				{
					userInfoJson = "";
				}
				object categoryId = (long)(IntPtr)content + 56L;
				if (string.IsNullOrEmpty(content.categoryId))
				{
					NotificationsSettings notificationsSettings = mSettings;
					categoryId = (long)(IntPtr)notificationsSettings.DefaultCategory + 16L;
				}
				long delaySecs = default(long);
				AndroidNotificationNative._ScheduleLocalNotification(id, delaySecs, (long)num2, content.title, content.body, userInfoJson, (string)categoryId, content.smallIcon, content.largeIcon);
			}
			else
			{
				Debug.Log("Please initialize first.");
			}
		}

		[Token(Token = "0x6000886")]
		[Address(RVA = "0xC047A4", Offset = "0xC047A4", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC0158]);\n\tv19 = *([v18 @ X8_v25]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, callback, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022FCC]) = v38;\nL_0016:\n\tv42 = new EasyMobile.Internal.Notifications.AndroidLocalNotificationClient+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v42);\n\tv42.callback = callback;\n\tgoto L_002D;\n\tv54 = *([v48 @ X0_v6+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_002D;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v48, v43, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002D:\n\tv65 = EasyMobile.Internal.Util::NullArgumentTest(callback);\n\tgoto L_003F;\n\tv96 = *([v69 @ X0_v10+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_003F;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v69, v64, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003F:\n\tv106 = EasyMobile.Internal.RuntimeHelper::ToMainThread(v42.callback);\n\tv42.callback = v106;\n\tv110 = new System.Action`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest[]>();\n\tSystem.Action`1<EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest[]>::.ctor(v110, v42, Il2CppMethodInfo);\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationNative::_GetPendingLocalNotifications(v110);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GetPendingLocalNotifications(Action<NotificationRequest[]> callback)
		{
			Action<NotificationRequest[]> callback2 = callback;
			Action<NotificationRequest[]> action = Util.NullArgumentTest(callback);
			Action<NotificationRequest[]> action2 = RuntimeHelper.ToMainThread(callback2);
			callback2 = action2;
			Action<AndroidNotificationRequest[]> callback3 = delegate(AndroidNotificationRequest[] androidRequests)
			{
				NotificationRequest[] array = new NotificationRequest[androidRequests.Length];
				int num = androidRequests.Length;
				if (androidRequests.Length >= 1)
				{
					int num2 = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						if (num2 < num)
						{
							NotificationRequest notificationRequest = androidRequests[num2].ToCrossPlatformNotificationRequest();
							if (notificationRequest != null)
							{
								object obj = notificationRequest as NotificationRequest;
							}
							if (num2 < array.Length)
							{
								array[num2] = notificationRequest;
								num = androidRequests.Length;
								num2++;
								if (num2 >= androidRequests.Length)
								{
									break;
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex2;
					}
				}
				callback2(array);
			};
			AndroidNotificationNative._GetPendingLocalNotifications(callback3);
		}

		[Token(Token = "0x6000887")]
		[Address(RVA = "0xC048C0", Offset = "0xC048C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationNative::_CancelPendingLocalNotificationRequest(id);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CancelPendingLocalNotification(string id)
		{
			AndroidNotificationNative._CancelPendingLocalNotificationRequest(id);
		}

		[Token(Token = "0x6000888")]
		[Address(RVA = "0xC048C8", Offset = "0xC048C8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationNative::_CancelAllPendingLocalNotificationRequests();\n\treturn;\n")]
		public void CancelAllPendingLocalNotifications()
		{
			AndroidNotificationNative._CancelAllPendingLocalNotificationRequests();
		}

		[Token(Token = "0x6000889")]
		[Address(RVA = "0xC048CC", Offset = "0xC048CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.Internal.Notifications.Android.AndroidNotificationNative::_CancelAllShownNotifications();\n\treturn;\n")]
		public void RemoveAllDeliveredNotifications()
		{
			AndroidNotificationNative._CancelAllShownNotifications();
		}

		[Token(Token = "0x600088A")]
		[Address(RVA = "0xC048D0", Offset = "0xC048D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidLocalNotificationClient()
		{
		}
	}
}
