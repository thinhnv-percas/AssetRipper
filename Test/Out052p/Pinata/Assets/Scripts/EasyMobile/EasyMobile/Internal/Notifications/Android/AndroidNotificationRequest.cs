using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.MiniJSON;
using UnityEngine;

namespace EasyMobile.Internal.Notifications.Android
{
	[Serializable]
	[Token(Token = "0x20000EF")]
	internal class AndroidNotificationRequest
	{
		[Token(Token = "0x400043D")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x400043E")]
		[FieldOffset(Offset = "0x18")]
		public string title;

		[Token(Token = "0x400043F")]
		[FieldOffset(Offset = "0x20")]
		public string message;

		[Token(Token = "0x4000440")]
		[FieldOffset(Offset = "0x28")]
		public string userInfo;

		[Token(Token = "0x4000441")]
		[FieldOffset(Offset = "0x30")]
		public string categoryId;

		[Token(Token = "0x4000442")]
		[FieldOffset(Offset = "0x38")]
		public string smallIcon;

		[Token(Token = "0x4000443")]
		[FieldOffset(Offset = "0x40")]
		public string largeIcon;

		[Token(Token = "0x4000444")]
		[FieldOffset(Offset = "0x48")]
		public long fireTimeMillis;

		[Token(Token = "0x4000445")]
		[FieldOffset(Offset = "0x50")]
		public long repeatSecs;

		[Token(Token = "0x4000446")]
		[FieldOffset(Offset = "0x58")]
		public int requestCode;

		[Token(Token = "0x60008A9")]
		[Address(RVA = "0xC03E80", Offset = "0xC03E80", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tSystem.Object::.ctor(this);\n\tthis.id = id;\n\tthis.title = title;\n\tthis.message = message;\n\tthis.userInfo = infoJson;\n\tthis.categoryId = categoryId;\n\tthis.smallIcon = smallIcon;\n\tthis.repeatSecs = *([v24 @ X29_v1+18]);\n\tthis.requestCode = *([v24 @ X29_v1+20]);\n\tthis.largeIcon = largeIcon;\n\tthis.fireTimeMillis = *([v24 @ X29_v1+10]);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AndroidNotificationRequest(string id, string title, string message, string infoJson, string categoryId, string smallIcon, string largeIcon, long fireTimeMillis, long repeatSecs, int requestCode)
		{
			//IL_005c: Expected I8, but got I
			//IL_008a: Expected I8, but got I
			base._002Ector();
			object obj2 = default(object);
			object obj = obj2;
			this.id = id;
			this.title = title;
			this.message = message;
			userInfo = infoJson;
			this.categoryId = categoryId;
			this.smallIcon = smallIcon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+18]");
			this.repeatSecs = 0L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			this.requestCode = 0;
			this.largeIcon = largeIcon;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			this.fireTimeMillis = 0L;
		}

		[Token(Token = "0x60008AA")]
		[Address(RVA = "0xC03F0C", Offset = "0xC03F0C", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EAB4A8]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022FC6]) = v44;\nL_001A:\n\tv49 = new EasyMobile.NotificationContent();\n\tEasyMobile.NotificationContent::.ctor(v49);\n\tv49.title = this.title;\n\tv49.body = this.message;\n\tv57 = System.String::IsNullOrEmpty(this.userInfo);\n\tv61 = v57 == 0;\n\tif (v61) goto L_0036;\n\tv65 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v65);\n\tgoto L_005E;\nL_0036:\n\tv68 = EasyMobile.MiniJSON.Json::Deserialize(this.userInfo);\n\tv146 = v68 == 0;\n\tif (v146) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_005E;\n\tv175 = v175_asT == 0;\n\tif (v175) goto L_FFFFFFFF;\n\tgoto L_005E;\nL_005E:\n\tv49.userInfo = v186;\n\tv49.categoryId = this.categoryId;\n\tv49.smallIcon = this.smallIcon;\n\tv49.largeIcon = this.largeIcon;\n\tgoto L_0075;\n\tv207 = *([v200 @ X0_v9+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tgoto L_0075;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v200, v189, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0075:\n\tv215 = EasyMobile.Internal.Util::FromMillisSinceUnixEpoch(this.fireTimeMillis);\n\tv218 = 0xE95E98(&v215 @ X0_v12 (System.DateTime), 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv222 = EasyMobile.NotificationRepeatExtension::FromExactSecondInterval(this.repeatSecs);\n\tv227 = new EasyMobile.NotificationRequest();\n\tEasyMobile.NotificationRequest::.ctor(v227, this.id, v49, v218, v222);\n\treturn v227;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal NotificationRequest ToCrossPlatformNotificationRequest()
		{
			//IL_0110: Expected F8, but got I8
			NotificationContent notificationContent = new NotificationContent();
			notificationContent.title = title;
			notificationContent.body = message;
			Dictionary<string, object> dictionary2;
			if (string.IsNullOrEmpty(userInfo))
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary2 = dictionary;
			}
			else
			{
				object obj = Json.Deserialize(userInfo);
				if (obj == null)
				{
					dictionary2 = null;
				}
				else
				{
					Dictionary<string, object> dictionary3 = obj as Dictionary<string, object>;
					dictionary2 = (Dictionary<string, object>)((dictionary3 == null) ? null : obj);
				}
			}
			notificationContent.userInfo = dictionary2;
			notificationContent.categoryId = categoryId;
			notificationContent.smallIcon = smallIcon;
			notificationContent.largeIcon = largeIcon;
			DateTime dateTime = Util.FromMillisSinceUnixEpoch(fireTimeMillis);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E95E98 (inside System.DateTime::ParseExact +0x1D0)");
			NotificationRepeat repeat = NotificationRepeatExtension.FromExactSecondInterval(repeatSecs);
			DateTime nextTriggerDate = default(DateTime);
			return new NotificationRequest(id, notificationContent, nextTriggerDate, repeat);
		}

		[Token(Token = "0x60008AB")]
		[Address(RVA = "0xC03B74", Offset = "0xC03B74", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA8AA0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022FC7]) = v38;\nL_0017:\n\tv43 = UnityEngine.JsonUtility::FromJson(jsonData);\n\tv45 = v43 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0033;\n\tgoto L_002C;\n\tv66 = *([v49 @ X0_v6+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002C;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v49, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002C:\n\tUnityEngine.Debug::Log(\"Failed to construct AndroidNotificationRequest: invalid JSON data.\");\nL_0033:\n\treturn v43;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidNotificationRequest FromJson(string jsonData)
		{
			AndroidNotificationRequest androidNotificationRequest = JsonUtility.FromJson<AndroidNotificationRequest>(jsonData);
			if (androidNotificationRequest == null)
			{
				Debug.Log("Failed to construct AndroidNotificationRequest: invalid JSON data.");
			}
			return androidNotificationRequest;
		}
	}
}
