using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using EasyMobile.Internal.Notifications;
using UnityEngine;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x731310", Offset = "0x731310")]
	[Token(Token = "0x200007B")]
	public class Notifications : MonoBehaviour
	{
		[Token(Token = "0x40002D6")]
		private const string LOCAL_NOTIF_ID_PREFIX = "";

		[Token(Token = "0x40002D7")]
		private const string LOCAL_NOTIF_CURRENT_ID_PPKEY = "EM_LOCAL_NOTIF_CURRENT_ID";

		[CompilerGenerated]
		[Token(Token = "0x40002D8")]
		private static Action<string> m_PushTokenReceived;

		[CompilerGenerated]
		[Token(Token = "0x40002D9")]
		private static Action<RemoteNotification> m_RemoteNotificationOpened;

		[CompilerGenerated]
		[Token(Token = "0x40002DA")]
		private static Action<LocalNotification> m_LocalNotificationOpened;

		[Token(Token = "0x40002DC")]
		private static ILocalNotificationClient sLocalNotificationClient;

		[Token(Token = "0x40002DD")]
		private static INotificationListener sListener;

		[Token(Token = "0x40002DE")]
		private static bool sIsInitialized;

		[Token(Token = "0x17000198")]
		[field: Token(Token = "0x40002D5")]
		public static Notifications Instance
		{
			[Token(Token = "0x600056A")]
			[Address(RVA = "0xFCFA48", Offset = "0xFCFA48", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F05358]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025683]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Notifications;\nL_0024:\n\treturn v49.<Instance>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600056B")]
			[Address(RVA = "0xFCFAB0", Offset = "0xFCFAB0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE3850]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025684]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Notifications;\nL_0021:\n\tv52.<Instance>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000199")]
		public static PushNotificationProvider CurrentPushNotificationService
		{
			[Token(Token = "0x600056C")]
			[Address(RVA = "0xFCFB1C", Offset = "0xFCFB1C", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.EM_Settings::get_Notifications();\n\treturn v7.mPushNotificationService;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NotificationsSettings notifications = EM_Settings.Notifications;
				return notifications.PushNotificationService;
			}
		}

		[Token(Token = "0x1700019A")]
		[field: Token(Token = "0x40002DB")]
		public static string PushToken
		{
			[Token(Token = "0x6000573")]
			[Address(RVA = "0xFD00E0", Offset = "0xFD00E0", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED8AF8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202568B]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Notifications;\nL_0024:\n\treturn v49.<PushToken>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000574")]
			[Address(RVA = "0xFD0148", Offset = "0xFD0148", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC6520]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202568C]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Notifications;\nL_0021:\n\tv52.<PushToken>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x1700019B")]
		private static ILocalNotificationClient LocalNotificationClient
		{
			[Token(Token = "0x6000575")]
			[Address(RVA = "0xFD01B4", Offset = "0xFD01B4", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB0E98]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202568D]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X8_v3 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv55 = v38;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v55, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv50 = EasyMobile.Notifications;\nL_0021:\n\tv53 = v51.sLocalNotificationClient == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0035;\n\tgoto L_002E;\n\tv70 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002E;\n\tv90 = v49;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v90, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002E:\n\tv62 = EasyMobile.Notifications::GetLocalNotificationClient();\n\tv60.sLocalNotificationClient = v62;\nL_0035:\n\tgoto L_0043;\n\tv76 = *([v65 @ X8_v5 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tgoto L_0043;\n\tv91 = v65;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v91, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv84 = EasyMobile.Notifications;\nL_0043:\n\treturn v85.sLocalNotificationClient;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (sLocalNotificationClient == null)
				{
					ILocalNotificationClient localNotificationClient = GetLocalNotificationClient();
					sLocalNotificationClient = localNotificationClient;
				}
				return sLocalNotificationClient;
			}
		}

		[Token(Token = "0x1700019C")]
		public static ConsentStatus DataPrivacyConsent
		{
			[Token(Token = "0x6000583")]
			[Address(RVA = "0xFD0F08", Offset = "0xFD0F08", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.NotificationsConsentManager::get_Instance();\n\tv9 = *([v6 @ X0_v1 (EasyMobile.NotificationsConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1C0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1C8]);\n\t// 13 IndirectJump v10 @ X2_v1, v6 @ X0_v1 (EasyMobile.NotificationsConsentManager), v6 @ X0_v1 (EasyMobile.NotificationsConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0016: Expected I, but got O
				//IL_0026: Expected O, but got I
				//IL_0036: Expected O, but got I
				NotificationsConsentManager instance = NotificationsConsentManager.Instance;
				IntPtr intPtr = (IntPtr)instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
				return ConsentStatus.Unknown;
			}
		}

		[Token(Token = "0x1400002C")]
		public static event Action<string> PushTokenReceived
		{
			[CompilerGenerated]
			[Token(Token = "0x600056D")]
			[Address(RVA = "0xFCFB40", Offset = "0xFCFB40", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F04670]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025685]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Notifications;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Notifications;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Notifications.m_PushTokenReceived;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600056E")]
			[Address(RVA = "0xFCFC30", Offset = "0xFCFC30", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0A8C0]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025686]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Notifications;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Notifications;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 8;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Notifications.m_PushTokenReceived;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 8L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002D")]
		public static event Action<RemoteNotification> RemoteNotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x600056F")]
			[Address(RVA = "0xFCFD20", Offset = "0xFCFD20", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA3AC8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025687]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Notifications;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.RemoteNotification>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Notifications;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Notifications.m_RemoteNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<RemoteNotification>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000570")]
			[Address(RVA = "0xFCFE10", Offset = "0xFCFE10", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1F0FC80]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025688]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Notifications;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.RemoteNotification>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Notifications;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x10;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Notifications.m_RemoteNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<RemoteNotification>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002E")]
		public static event Action<LocalNotification> LocalNotificationOpened
		{
			[CompilerGenerated]
			[Token(Token = "0x6000571")]
			[Address(RVA = "0xFCFF00", Offset = "0xFCFF00", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EFADE8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2025689]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Notifications;\nL_002A:\n\tv107 = System.Delegate::Combine(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.LocalNotification>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Notifications;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Notifications.m_LocalNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Combine(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<LocalNotification>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000572")]
			[Address(RVA = "0xFCFFF0", Offset = "0xFCFFF0", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF2D60]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202568A]) = v44;\nL_001C:\n\tgoto L_FFFFFFFF;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = EasyMobile.Notifications;\nL_002A:\n\tv107 = System.Delegate::Remove(v102, value);\n\tv108 = v107 == 0;\n\tif (v108) goto L_003F;\n\tv120 = *([v107 @ X0_v6 (System.Delegate)]) != System.Action`1<EasyMobile.LocalNotification>;\n\tif (v120) goto L_0061;\nL_003F:\n\tgoto L_0049;\n\tv138 = *([v132 @ X0_v7 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0049;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v132, v130, v106, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv142 = EasyMobile.Notifications;\nL_0049:\n\tv144 = v141.<Instance>k__BackingField + 0x18;\n\tv97 = 0x874190(v144, v107, v102, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv67 = v102 != v97;\n\tif (v67) goto L_002A;\n\treturn;\nL_0061:\n\tthrow System.InvalidCastException;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_005e: Expected O, but got I
				Delegate obj = Notifications.m_LocalNotificationOpened;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj2 = Delegate.Remove(obj, value);
					if (obj2 != null && (object)obj2.GetType() != typeof(Action<LocalNotification>))
					{
						break;
					}
					object obj3 = (long)(IntPtr)Instance + 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj != obj4;
					obj = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002F")]
		public static event Action<ConsentStatus> DataPrivacyConsentUpdated
		{
			[Token(Token = "0x6000581")]
			[Address(RVA = "0xFD0E10", Offset = "0xFD0E10", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.NotificationsConsentManager::get_Instance();\n\tEasyMobile.ConsentManager::add_DataPrivacyConsentUpdated(v10, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				NotificationsConsentManager instance = NotificationsConsentManager.Instance;
				instance.DataPrivacyConsentUpdated += value;
			}
			[Token(Token = "0x6000582")]
			[Address(RVA = "0xFD0ED8", Offset = "0xFD0ED8", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.NotificationsConsentManager::get_Instance();\n\tEasyMobile.ConsentManager::remove_DataPrivacyConsentUpdated(v10, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				NotificationsConsentManager instance = NotificationsConsentManager.Instance;
				instance.DataPrivacyConsentUpdated -= value;
			}
		}

		[Token(Token = "0x6000576")]
		[Address(RVA = "0xFD02CC", Offset = "0xFD02CC", Length = "0x3B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA3DD0]);\n\tv21 = *([v20 @ X8_v70]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202568E]) = v41;\nL_001A:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = EasyMobile.Notifications;\nL_0023:\n\tv57 = ~v55.sIsInitialized;\n\tif (v57) goto L_0041;\n\tgoto L_003C;\n\tv68 = *([v61 @ X0_v58+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_003C;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v61, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003C:\n\tUnityEngine.Debug::Log(\"Notifications module has been initialized. Ignoring this call.\");\n\treturn;\nL_0041:\n\tgoto L_0048;\n\tv85 = *([v51 @ X0_v3 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0048;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v51, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0048:\n\tv93 = EasyMobile.Internal.Notifications.AndroidNotificationListener::GetListener();\n\tv95.sListener = v93;\n\tv98 = v96.sListener == 0;\n\tif (v98) goto L_00DC;\n\tgoto L_0060;\n\tv239 = *([v94 @ X8_v9 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv240 = v239 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0060;\n\tv255 = v94;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v255, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv303 = EasyMobile.Notifications;\n\tv247 = *([v303 @ X8_v57+B8]);\n\tv249 = *([v247 @ X8_v58+30]);\nL_0060:\n\tv253 = new System.Action`1<EasyMobile.LocalNotification>();\n\tSystem.Action`1<EasyMobile.LocalNotification>::.ctor(v253, 0, Il2CppMethodInfo);\n\tgoto L_009A;\n\tv365 = *([v319 @ X8_v45+B0]);\n\tv366 = 0;\n\tv367 = v365 + 8;\n\tv369 = *([v408 @ X11_v22-8]);\n\tv413 = v369 == v321;\n\tif (v413) goto L_0092;\n\tv389 = v407 + 1;\n\tv435 = v389 < v320;\n\tv387 = ~v435;\n\tv391 = v408 + 0x10;\n\tv371 = ~v387;\n\tif (v371) goto L_FFFFFFFF;\n\tv392 = v248;\n\tv393 = 0;\n\tv394 = 0x8909C4(v392, v321, v393, v263, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_009A;\nL_0092:\n\tv436 = *([v408 @ X11_v22]);\n\tv437 = v436 << 4;\n\tv438 = v319 + v437;\n\tv439 = v438 + 0x130;\nL_009A:\n\tEasyMobile.Internal.Notifications.INotificationListener::add_LocalNotificationOpened(v96.sListener, v253);\n\tv236 = v451.sListener;\n\tv351 = new System.Action`1<EasyMobile.RemoteNotification>();\n\tSystem.Action`1<EasyMobile.RemoteNotification>::.ctor(v351, 0, Il2CppMethodInfo);\n\tv471 = *([v236 @ X19_v9 (System.Action`1<EasyMobile.RemoteNotification>)]);\n\tv232 = *([v471 @ X8_v52 (Il2CppClass<System.Action`1<EasyMobile.RemoteNotification>>)+126]) == 0;\n\tif (v232) goto L_00CF;\n\tv553 = *([v471 @ X8_v52 (Il2CppClass<System.Action`1<EasyMobile.RemoteNotification>>)+B0]) + 8;\nL_00BA:\n\tv558 = *([v553 @ X11_v17-8]) == EasyMobile.Internal.Notifications.INotificationListener;\n\tif (v558) goto L_00D2;\n\tv552 = v552 + 1;\n\tv584 = v552 < *([v471 @ X8_v52 (Il2CppClass<System.Action`1<EasyMobile.RemoteNotification>>)+126]);\n\tv504 = ~v584;\n\tv553 = v553 + 0x10;\n\tv488 = ~v504;\n\tif (v488) goto L_00BA;\nL_00CF:\n\tv591 = System.Action`1<EasyMobile.RemoteNotification>::.ctor(v236, EasyMobile.Internal.Notifications.INotificationListener, 2);\n\tgoto L_00DA;\nL_00D2:\n\tv586 = *([v553 @ X11_v17]) + 2;\n\tv587 = v586 << 4;\n\tv588 = v471 + v587;\n\tv591 = v588 + 0x130;\nL_00DA:\n\t*([v591 @ X0_v46 (System.Action`1<EasyMobile.RemoteNotification>)])(v230, v236, v351, *([v591 @ X0_v46 (System.Action`1<EasyMobile.RemoteNotification>)+8]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00DC:\n\tv238 = EasyMobile.EM_Settings::get_Notifications();\n\tv274 = v238.mPushNotificationService != 1;\n\tif (v274) goto L_00FD;\n\tgoto L_00FB;\n\tv358 = *([v307 @ X0_v32+E0]);\n\tv359 = v358 == 0;\n\tv360 = ~v359;\n\tif (v360) goto L_00FB;\n\tv362 = \"il2cpp_codegen_runtime_class_init\"(v307, v225, v219, v217, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00FB:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import OneSignal plugin for Unity.\");\nL_00FD:\n\tv297 = EasyMobile.EM_Settings::get_Notifications();\n\tv326 = v297.mPushNotificationService != 2;\n\tif (v326) goto L_0121;\n\tgoto L_011C;\n\tv454 = *([v420 @ X0_v28+E0]);\n\tv455 = v454 == 0;\n\tv456 = ~v455;\n\tif (v456) goto L_011C;\n\tv458 = \"il2cpp_codegen_runtime_class_init\"(v420, v293, v219, v217, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_011C:\n\tUnityEngine.Debug::LogError(\"SDK missing. Please import FirebaseMessaging plugin for Unity.\");\nL_0121:\n\tgoto L_0127;\n\tv461 = *([v431 @ X0_v16 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv462 = v461 == 0;\n\tv463 = ~v462;\n\tif (v463) goto L_0127;\n\tv465 = \"il2cpp_codegen_runtime_class_init\"(v431, v348, v219, v217, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0127:\n\tv467 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv352 = EasyMobile.EM_Settings::get_Notifications();\n\tgoto L_0160;\n\tv512 = *([v476 @ X8_v18+B0]);\n\tv513 = 0;\n\tv514 = v512 + 8;\n\tv516 = *([v574 @ X11_v9-8]);\n\tv579 = v516 == v481;\n\tif (v579) goto L_0157;\n\tv536 = v573 + 1;\n\tv594 = v536 < v479;\n\tv534 = ~v594;\n\tv538 = v574 + 0x10;\n\tv518 = ~v534;\n\tif (v518) goto L_FFFFFFFF;\n\tv539 = v357;\n\tv540 = 0;\n\tv541 = 0x8909C4(v539, v481, v540, v217, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0160;\nL_0157:\n\tv595 = *([v574 @ X11_v9]);\n\tv596 = v595 << 4;\n\tv597 = v476 + v596;\n\tv598 = v597 + 0x130;\nL_0160:\n\tEasyMobile.Internal.Notifications.ILocalNotificationClient::Init(v467, v352, v477.sListener);\n\tv181.sIsInitialized = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 225 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			//IL_005c: Expected I, but got O
			//IL_0097: Expected O, but got I
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_012c: Expected O, but got I
			//IL_013b: Expected O, but got I
			//IL_00e3: Expected O, but got I
			if (sIsInitialized)
			{
				Debug.Log("Notifications module has been initialized. Ignoring this call.");
				return;
			}
			AndroidNotificationListener listener = AndroidNotificationListener.GetListener();
			sListener = listener;
			if (sListener != null)
			{
				Action<LocalNotification> value = InternalOnLocalNotificationOpened;
				sListener.LocalNotificationOpened += value;
				Action<RemoteNotification> action = (Action<RemoteNotification>)(object)sListener;
				Action<RemoteNotification> action2 = InternalOnRemoteNotificationOpened;
				IntPtr intPtr = (IntPtr)action;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v52 (Il2CppClass<System.Action`1<EasyMobile.RemoteNotification>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v52 (Il2CppClass<System.Action`1<EasyMobile.RemoteNotification>>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v553 @ X11_v17-8]");
						if ((IntPtr)0 != (IntPtr)typeof(INotificationListener))
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v471 @ X8_v52 (Il2CppClass<System.Action`1<EasyMobile.RemoteNotification>>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj = (long)(IntPtr)obj + 16L;
							continue;
						}
						object obj2 = obj + 2;
						int num3 = (int)((long)(IntPtr)obj2 << 4);
						object obj3 = (long)intPtr + (long)num3;
						Action<RemoteNotification> action3 = (Action<RemoteNotification>)((long)(IntPtr)obj3 + 304L);
						break;
					}
					while (!flag2);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v591 @ X0_v46 (System.Action`1<EasyMobile.RemoteNotification>)] (should have been resolved before IL gen)");
			}
			NotificationsSettings notifications = EM_Settings.Notifications;
			if (notifications.PushNotificationService == PushNotificationProvider.OneSignal)
			{
				Debug.LogError("SDK missing. Please import OneSignal plugin for Unity.");
			}
			NotificationsSettings notifications2 = EM_Settings.Notifications;
			if (notifications2.PushNotificationService == PushNotificationProvider.Firebase)
			{
				Debug.LogError("SDK missing. Please import FirebaseMessaging plugin for Unity.");
			}
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			NotificationsSettings notifications3 = EM_Settings.Notifications;
			localNotificationClient.Init(notifications3, sListener);
			sIsInitialized = true;
		}

		[Token(Token = "0x6000577")]
		[Address(RVA = "0xFD068C", Offset = "0xFD068C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB0408]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202568F]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Notifications;\nL_0024:\n\treturn v49.sIsInitialized;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInitialized()
		{
			return sIsInitialized;
		}

		[Token(Token = "0x6000578")]
		[Address(RVA = "0xFD06F4", Offset = "0xFD06F4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EBE4F0]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, content, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2025690]) = v43;\nL_001C:\n\tgoto L_0022;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, content, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0022:\n\tv57 = EasyMobile.Notifications::NextLocalNotificationId();\n\tv59 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv63 = *([v59 @ X0_v5 (EasyMobile.Internal.Notifications.ILocalNotificationClient)]);\n\tv67 = *([v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]) == 0;\n\tif (v67) goto L_004C;\n\tv120 = *([v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]) + 8;\nL_0037:\n\tv126 = *([v120 @ X11_v5-8]) == EasyMobile.Internal.Notifications.ILocalNotificationClient;\n\tif (v126) goto L_004F;\n\tv121 = v121 + 1;\n\tv187 = v121 < *([v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]);\n\tv100 = ~v187;\n\tv120 = v120 + 0x10;\n\tv76 = ~v100;\n\tif (v76) goto L_0037;\nL_004C:\n\tv194 = 0x8909C4(v59, EasyMobile.Internal.Notifications.ILocalNotificationClient, 2, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0059;\nL_004F:\n\tv189 = *([v120 @ X11_v5]) + 2;\n\tv190 = v189 << 4;\n\tv191 = v63 + v190;\n\tv194 = v191 + 0x130;\nL_0059:\n\t*([v194 @ X0_v7])(v197, v59, v57, triggerDate, content, *([v194 @ X0_v7+8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v57;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ScheduleLocalNotification(DateTime triggerDate, NotificationContent content)
		{
			//IL_0024: Expected I, but got O
			//IL_005f: Expected O, but got I
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00fe: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_00ab: Expected O, but got I
			string result = NextLocalNotificationId();
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			IntPtr intPtr = (IntPtr)localNotificationClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalNotificationClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c4;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0141;
			IL_00c4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0141;
			IL_0141:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ X0_v7] (should have been resolved before IL gen)");
			return result;
		}

		[Token(Token = "0x6000579")]
		[Address(RVA = "0xFD0894", Offset = "0xFD0894", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDE148]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, content, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2025691]) = v43;\nL_001C:\n\tgoto L_0022;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0022;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, content, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0022:\n\tv57 = EasyMobile.Notifications::NextLocalNotificationId();\n\tv59 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv63 = *([v59 @ X0_v5 (EasyMobile.Internal.Notifications.ILocalNotificationClient)]);\n\tv67 = *([v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]) == 0;\n\tif (v67) goto L_004C;\n\tv120 = *([v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]) + 8;\nL_0037:\n\tv126 = *([v120 @ X11_v5-8]) == EasyMobile.Internal.Notifications.ILocalNotificationClient;\n\tif (v126) goto L_004F;\n\tv121 = v121 + 1;\n\tv187 = v121 < *([v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]);\n\tv100 = ~v187;\n\tv120 = v120 + 0x10;\n\tv76 = ~v100;\n\tif (v76) goto L_0037;\nL_004C:\n\tv194 = 0x8909C4(v59, EasyMobile.Internal.Notifications.ILocalNotificationClient, 3, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0059;\nL_004F:\n\tv189 = *([v120 @ X11_v5]) + 3;\n\tv190 = v189 << 4;\n\tv191 = v63 + v190;\n\tv194 = v191 + 0x130;\nL_0059:\n\t*([v194 @ X0_v7])(v197, v59, v57, delay, content, *([v194 @ X0_v7+8]), v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn v57;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ScheduleLocalNotification(TimeSpan delay, NotificationContent content)
		{
			//IL_0024: Expected I, but got O
			//IL_005f: Expected O, but got I
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00fe: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_00ab: Expected O, but got I
			string result = NextLocalNotificationId();
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			IntPtr intPtr = (IntPtr)localNotificationClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalNotificationClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c4;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0141;
			IL_00c4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0141;
			IL_0141:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v194 @ X0_v7] (should have been resolved before IL gen)");
			return result;
		}

		[Token(Token = "0x600057A")]
		[Address(RVA = "0xFD0994", Offset = "0xFD0994", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EBD6C0]);\n\tv29 = *([v28 @ X8_v14]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, content, repeat, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2025692]) = v46;\nL_001E:\n\tgoto L_0024;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, content, repeat, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\tv60 = EasyMobile.Notifications::NextLocalNotificationId();\n\tv62 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv66 = *([v62 @ X0_v5 (EasyMobile.Internal.Notifications.ILocalNotificationClient)]);\n\tv70 = *([v66 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]) == 0;\n\tif (v70) goto L_004E;\n\tv123 = *([v66 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]) + 8;\nL_0039:\n\tv129 = *([v123 @ X11_v5-8]) == EasyMobile.Internal.Notifications.ILocalNotificationClient;\n\tif (v129) goto L_0051;\n\tv124 = v124 + 1;\n\tv194 = v124 < *([v66 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]);\n\tv103 = ~v194;\n\tv123 = v123 + 0x10;\n\tv79 = ~v103;\n\tif (v79) goto L_0039;\nL_004E:\n\tv201 = 0x8909C4(v62, EasyMobile.Internal.Notifications.ILocalNotificationClient, 4, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_005C;\nL_0051:\n\tv196 = *([v123 @ X11_v5]) + 4;\n\tv197 = v196 << 4;\n\tv198 = v66 + v197;\n\tv201 = v198 + 0x130;\nL_005C:\n\t*([v201 @ X0_v7])(v204, v62, v60, delay, content, repeat, *([v201 @ X0_v7+8]), v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn v60;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ScheduleLocalNotification(TimeSpan delay, NotificationContent content, NotificationRepeat repeat)
		{
			//IL_0024: Expected I, but got O
			//IL_005f: Expected O, but got I
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected O, but got Unknown
			//IL_00fe: Expected O, but got I
			//IL_010d: Expected O, but got I
			//IL_00ab: Expected O, but got I
			string result = NextLocalNotificationId();
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			IntPtr intPtr = (IntPtr)localNotificationClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalNotificationClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c4;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0141;
			IL_00c4:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0141;
			IL_0141:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v201 @ X0_v7] (should have been resolved before IL gen)");
			return result;
		}

		[Token(Token = "0x600057B")]
		[Address(RVA = "0xFD0AA4", Offset = "0xFD0AA4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF4368]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025693]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tgoto L_0057;\n\tv62 = *([v56 @ X8_v7+B0]);\n\tv63 = 0;\n\tv64 = v62 + 8;\n\tv66 = *([v113 @ X11_v5-8]);\n\tv119 = v66 == v59;\n\tif (v119) goto L_0049;\n\tv99 = v114 + 1;\n\tv174 = v99 < v58;\n\tv93 = ~v174;\n\tv96 = v113 + 0x10;\n\tv69 = ~v93;\n\tif (v69) goto L_FFFFFFFF;\n\tv100 = 5;\n\tv101 = v53;\n\tv102 = 0x8909C4(v101, v59, v100, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0057;\nL_0049:\n\tv175 = *([v113 @ X11_v5]);\n\tv176 = v175 + 5;\n\tv177 = v176 << 4;\n\tv178 = v56 + v177;\n\tv179 = v178 + 0x130;\nL_0057:\n\tEasyMobile.Internal.Notifications.ILocalNotificationClient::GetPendingLocalNotifications(v52, callback);\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GetPendingLocalNotifications(Action<NotificationRequest[]> callback)
		{
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			localNotificationClient.GetPendingLocalNotifications(callback);
		}

		[Token(Token = "0x600057C")]
		[Address(RVA = "0xFD0B80", Offset = "0xFD0B80", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F102B8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025694]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv56 = *([v52 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient)]);\n\tv60 = *([v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]) == 0;\n\tif (v60) goto L_0047;\n\tv113 = *([v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]) + 8;\nL_0032:\n\tv119 = *([v113 @ X11_v5-8]) == EasyMobile.Internal.Notifications.ILocalNotificationClient;\n\tif (v119) goto L_004A;\n\tv114 = v114 + 1;\n\tv174 = v114 < *([v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]);\n\tv93 = ~v174;\n\tv113 = v113 + 0x10;\n\tv69 = ~v93;\n\tif (v69) goto L_0032;\nL_0047:\n\tv181 = 0x8909C4(v52, EasyMobile.Internal.Notifications.ILocalNotificationClient, 6, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004E;\nL_004A:\n\tv176 = *([v113 @ X11_v5]) + 6;\n\tv177 = v176 << 4;\n\tv178 = v56 + v177;\n\tv181 = v178 + 0x130;\nL_004E:\n\tv127 = *([v181 @ X0_v6]);\n\tv134 = *([v181 @ X0_v6+8]);\n\t// 87 IndirectJump v127 @ X3_v1, v52 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient), v52 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient), id @ X0 (System.String), v134 @ X2_v2, v127 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void CancelPendingLocalNotification(string id)
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			IntPtr intPtr = (IntPtr)localNotificationClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalNotificationClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600057D")]
		[Address(RVA = "0xFD0C5C", Offset = "0xFD0C5C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF58D0]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025695]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv53 = *([v49 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient)]);\n\tv57 = *([v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]) == 0;\n\tif (v57) goto L_0045;\n\tv110 = *([v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]) + 8;\nL_0030:\n\tv116 = *([v110 @ X11_v5-8]) == EasyMobile.Internal.Notifications.ILocalNotificationClient;\n\tif (v116) goto L_0048;\n\tv111 = v111 + 1;\n\tv167 = v111 < *([v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]);\n\tv90 = ~v167;\n\tv110 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_0030;\nL_0045:\n\tv174 = 0x8909C4(v49, EasyMobile.Internal.Notifications.ILocalNotificationClient, 7, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004C;\nL_0048:\n\tv169 = *([v110 @ X11_v5]) + 7;\n\tv170 = v169 << 4;\n\tv171 = v53 + v170;\n\tv174 = v171 + 0x130;\nL_004C:\n\tv129 = *([v174 @ X0_v6]);\n\tv151 = *([v174 @ X0_v6+8]);\n\t// 83 IndirectJump v129 @ X2_v2, v49 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient), v49 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient), v151 @ X1_v2, v129 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void CancelAllPendingLocalNotifications()
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			IntPtr intPtr = (IntPtr)localNotificationClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalNotificationClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 7;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600057E")]
		[Address(RVA = "0xFD0D30", Offset = "0xFD0D30", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED3680]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025696]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = EasyMobile.Notifications::get_LocalNotificationClient();\n\tv53 = *([v49 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient)]);\n\tv57 = *([v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]) == 0;\n\tif (v57) goto L_0045;\n\tv110 = *([v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]) + 8;\nL_0030:\n\tv116 = *([v110 @ X11_v5-8]) == EasyMobile.Internal.Notifications.ILocalNotificationClient;\n\tif (v116) goto L_0048;\n\tv111 = v111 + 1;\n\tv167 = v111 < *([v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]);\n\tv90 = ~v167;\n\tv110 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_0030;\nL_0045:\n\tv174 = 0x8909C4(v49, EasyMobile.Internal.Notifications.ILocalNotificationClient, 8, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004C;\nL_0048:\n\tv169 = *([v110 @ X11_v5]) + 8;\n\tv170 = v169 << 4;\n\tv171 = v53 + v170;\n\tv174 = v171 + 0x130;\nL_004C:\n\tv129 = *([v174 @ X0_v6]);\n\tv151 = *([v174 @ X0_v6+8]);\n\t// 83 IndirectJump v129 @ X2_v2, v49 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient), v49 @ X0_v4 (EasyMobile.Internal.Notifications.ILocalNotificationClient), v151 @ X1_v2, v129 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ClearAllDeliveredNotifications()
		{
			//IL_001b: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00a2: Expected O, but got I
			ILocalNotificationClient localNotificationClient = LocalNotificationClient;
			IntPtr intPtr = (IntPtr)localNotificationClient;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bb;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ILocalNotificationClient))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<EasyMobile.Internal.Notifications.ILocalNotificationClient>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bb;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00bb:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600057F")]
		[Address(RVA = "0xFD0E04", Offset = "0xFD0E04", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int GetAppIconBadgeNumber()
		{
			return 0;
		}

		[Token(Token = "0x6000580")]
		[Address(RVA = "0xFD0E0C", Offset = "0xFD0E0C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetAppIconBadgeNumber(int value)
		{
		}

		[Token(Token = "0x6000584")]
		[Address(RVA = "0xFD0F2C", Offset = "0xFD0F2C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.NotificationsConsentManager::get_Instance();\n\tv9 = *([v6 @ X0_v1 (EasyMobile.NotificationsConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1D0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1D8]);\n\t// 13 IndirectJump v10 @ X2_v1, v6 @ X0_v1 (EasyMobile.NotificationsConsentManager), v6 @ X0_v1 (EasyMobile.NotificationsConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GrantDataPrivacyConsent()
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			NotificationsConsentManager instance = NotificationsConsentManager.Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000585")]
		[Address(RVA = "0xFD0F50", Offset = "0xFD0F50", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.NotificationsConsentManager::get_Instance();\n\tv9 = *([v6 @ X0_v1 (EasyMobile.NotificationsConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1E0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1E8]);\n\t// 13 IndirectJump v10 @ X2_v1, v6 @ X0_v1 (EasyMobile.NotificationsConsentManager), v6 @ X0_v1 (EasyMobile.NotificationsConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RevokeDataPrivacyConsent()
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			NotificationsConsentManager instance = NotificationsConsentManager.Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.NotificationsConsentManager>)+1E8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000586")]
		[Address(RVA = "0xFD0F74", Offset = "0xFD0F74", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EBBA48]);\n\tv23 = *([v22 @ X8_v32]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2025697]) = v42;\nL_001B:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tgoto L_0030;\n\tv61 = *([1EF53F8]);\n\tv62 = *([v61 @ X8_v28]);\n\tv63 = \"il2cpp_codegen_initialize_method\"(v62, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv66 = 0 | 1;\n\t*([20256FA]) = v66;\nL_0030:\n\tgoto L_003F;\n\tv71 = *([v67 @ X0_v5 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = EasyMobile.Notifications;\nL_003F:\n\tgoto L_0049;\n\tv87 = *([v81 @ X8_v9+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_0049;\n\tv98 = v81;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v98, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0049:\n\tv97 = UnityEngine.Object::op_Inequality(v80.<Instance>k__BackingField, 0);\n\tv100 = v97 == 0;\n\tif (v100) goto L_0066;\n\tgoto L_0060;\n\tv109 = *([v101 @ X0_v20+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v101, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0060:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\nL_0066:\n\tgoto L_0070;\n\tv124 = *([v105 @ X0_v10+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0070;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v105, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0070:\n\tgoto L_007B;\n\tv136 = *([1F02608]);\n\tv137 = *([v136 @ X8_v19]);\n\tv138 = \"il2cpp_codegen_initialize_method\"(v137, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv141 = 0 | 1;\n\t*([20256FB]) = v141;\nL_007B:\n\tgoto L_0083;\n\tv165 = *([v142 @ X0_v13 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tgoto L_0083;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v142, v95, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv168 = EasyMobile.Notifications;\nL_0083:\n\tv160.<Instance>k__BackingField = this;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(this);
			}
			else
			{
				Instance = this;
			}
		}

		[Token(Token = "0x6000587")]
		[Address(RVA = "0xFD10EC", Offset = "0xFD10EC", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = EasyMobile.EM_Settings::get_Notifications();\n\tv14 = ~v11.mAutoInit;\n\tif (v14) goto L_0020;\n\tv20 = EasyMobile.EM_Settings::get_Notifications();\n\tv57 = EasyMobile.Notifications::CRAutoInit(v20, v20.mAutoInitDelay);\n\tv52 = UnityEngine.MonoBehaviour::StartCoroutine(this, v57);\n\treturn;\nL_0020:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			NotificationsSettings notifications = EM_Settings.Notifications;
			if (notifications.IsAutoInit)
			{
				NotificationsSettings notifications2 = EM_Settings.Notifications;
				IEnumerator routine = ((Notifications)(object)notifications2).CRAutoInit(notifications2.AutoInitDelay);
				Coroutine coroutine = StartCoroutine(routine);
			}
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x734E9C", Offset = "0x734E9C")]
		[Token(Token = "0x6000588")]
		[Address(RVA = "0xFD114C", Offset = "0xFD114C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB3928]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, delay, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2025698]) = v38;\nL_0016:\n\tv42 = new EasyMobile.Notifications+<CRAutoInit>d__46();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.delay = delay;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CRAutoInit(float delay)
		{
			_003CCRAutoInit_003Ed__46 _003CCRAutoInit_003Ed__47 = null;
			_003CCRAutoInit_003Ed__47._003C_003E1__state = 0;
			_003CCRAutoInit_003Ed__47.delay = delay;
			return _003CCRAutoInit_003Ed__47;
		}

		[Token(Token = "0x6000589")]
		[Address(RVA = "0xFD11F4", Offset = "0xFD11F4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = EasyMobile.NotificationsConsentManager::get_Instance();\n\treturnVal2 = EasyMobile.ConsentManager::get_DataPrivacyConsent(v8);\n\tv31 = EasyMobile.GlobalConsentManager::get_Instance();\n\tv46 = EasyMobile.ConsentManager::get_DataPrivacyConsent(v31);\n\tv53 = returnVal2 == 0;\n\tv58 = ~v53;\n\tv59 = ~v58;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0029;\nL_0029:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ConsentStatus GetApplicableDataPrivacyConsent()
		{
			NotificationsConsentManager instance = NotificationsConsentManager.Instance;
			ConsentStatus consentStatus = instance.DataPrivacyConsent;
			GlobalConsentManager instance2 = GlobalConsentManager.Instance;
			ConsentStatus dataPrivacyConsent = instance2.DataPrivacyConsent;
			if (consentStatus == ConsentStatus.Unknown)
			{
				consentStatus = dataPrivacyConsent;
			}
			return consentStatus;
		}

		[Token(Token = "0x600058A")]
		[Address(RVA = "0xFD0684", Offset = "0xFD0684", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.Internal.Notifications.AndroidNotificationListener::GetListener();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static INotificationListener GetNotificationListener()
		{
			return AndroidNotificationListener.GetListener();
		}

		[Token(Token = "0x600058B")]
		[Address(RVA = "0xFD0270", Offset = "0xFD0270", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1F0DE60]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2025699]) = v35;\nL_0014:\n\tv39 = new EasyMobile.Internal.Notifications.AndroidLocalNotificationClient();\n\tEasyMobile.Internal.Notifications.AndroidLocalNotificationClient::.ctor(v39);\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ILocalNotificationClient GetLocalNotificationClient()
		{
			return new AndroidLocalNotificationClient();
		}

		[Token(Token = "0x600058C")]
		[Address(RVA = "0xFD07F4", Offset = "0xFD07F4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = &v7 @ stack_-10_v2;\n\tgoto L_0016;\n\tv14 = *([1EDB050]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202569A]) = v35;\nL_0016:\n\tv41 = EasyMobile.Internal.StorageUtil::GetInt(\"EM_LOCAL_NOTIF_CURRENT_ID\", 0);\n\tv54 = v41 != 0x7FFFFFFF;\n\tif (v54) goto L_0027;\n\tgoto L_002B;\nL_0027:\n\tv57 = v41 + 1;\nL_002B:\n\t*([v6 @ X29_v1-4]) = v57;\n\tEasyMobile.Internal.StorageUtil::SetInt(\"EM_LOCAL_NOTIF_CURRENT_ID\", v57);\n\tEasyMobile.Internal.StorageUtil::Save();\n\tv61 = &v7 @ stack_-10_v2 - 4;\n\treturnVal1 = 0xDC3560(v61, 0, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv78 = returnVal1 != 0;\n\tif (v78) goto L_0048;\n\tgoto L_0048;\nL_0048:\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string NextLocalNotificationId()
		{
			//IL_00b6: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			int num = StorageUtil.GetInt("EM_LOCAL_NOTIF_CURRENT_ID", 0);
			int value = ((num == int.MaxValue) ? 1 : (num + 1));
			StorageUtil.SetInt("EM_LOCAL_NOTIF_CURRENT_ID", value);
			StorageUtil.Save();
			object obj3 = (long)(IntPtr)obj2 - 4L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			string text = default(string);
			if (text == null)
			{
				return "";
			}
			return text;
		}

		[Token(Token = "0x600058D")]
		[Address(RVA = "0xFD1248", Offset = "0xFD1248", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED3220]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202569B]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Notifications;\nL_0022:\n\tv54 = v52.LocalNotificationOpened == 0;\n\tif (v54) goto L_0043;\n\tgoto L_003C;\n\tv63 = *([v48 @ X0_v3 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_003C;\n\tv94 = EasyMobile.Notifications;\n\tv95 = *([v94 @ X8_v8 (Il2CppClass<EasyMobile.Notifications>)+B8]);\n\tv72 = v95.LocalNotificationOpened;\nL_003C:\n\tSystem.Action`1<EasyMobile.LocalNotification>::Invoke(v52.LocalNotificationOpened, delivered);\n\treturn;\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InternalOnLocalNotificationOpened(LocalNotification delivered)
		{
			if (Notifications.LocalNotificationOpened != null)
			{
				Notifications.LocalNotificationOpened(delivered);
			}
		}

		[Token(Token = "0x600058E")]
		[Address(RVA = "0xFD1304", Offset = "0xFD1304", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDF608]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202569C]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Notifications;\nL_0022:\n\tv54 = v52.RemoteNotificationOpened == 0;\n\tif (v54) goto L_0043;\n\tgoto L_003C;\n\tv63 = *([v48 @ X0_v3 (Il2CppClass<EasyMobile.Notifications>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_003C;\n\tv94 = EasyMobile.Notifications;\n\tv95 = *([v94 @ X8_v8 (Il2CppClass<EasyMobile.Notifications>)+B8]);\n\tv72 = v95.RemoteNotificationOpened;\nL_003C:\n\tSystem.Action`1<EasyMobile.RemoteNotification>::Invoke(v52.RemoteNotificationOpened, delivered);\n\treturn;\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void InternalOnRemoteNotificationOpened(RemoteNotification delivered)
		{
			if (Notifications.RemoteNotificationOpened != null)
			{
				Notifications.RemoteNotificationOpened(delivered);
			}
		}

		[Token(Token = "0x600058F")]
		[Address(RVA = "0xFD13C0", Offset = "0xFD13C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Notifications()
		{
		}
	}
}
