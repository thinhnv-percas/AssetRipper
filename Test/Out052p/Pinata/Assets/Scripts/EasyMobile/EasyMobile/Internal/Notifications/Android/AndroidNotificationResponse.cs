using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.MiniJSON;

namespace EasyMobile.Internal.Notifications.Android
{
	[Serializable]
	[Token(Token = "0x20000EE")]
	internal class AndroidNotificationResponse
	{
		[Token(Token = "0x400043B")]
		[FieldOffset(Offset = "0x10")]
		public string actionId;

		[Token(Token = "0x400043C")]
		[FieldOffset(Offset = "0x18")]
		public AndroidNotificationRequest request;

		[Token(Token = "0x60008A7")]
		[Address(RVA = "0xC040C8", Offset = "0xC040C8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.actionId = actionId;\n\tthis.request = request;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AndroidNotificationResponse(string actionId, AndroidNotificationRequest request)
		{
			this.actionId = actionId;
			this.request = request;
		}

		[Token(Token = "0x60008A8")]
		[Address(RVA = "0xC04100", Offset = "0xC04100", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EC6498]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022FC8]) = v42;\nL_0017:\n\tv45 = EasyMobile.MiniJSON.Json::Deserialize(jsonData);\n\tgoto L_FFFFFFFF;\n\tv156 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v45, \"actionId\");\n\tv158 = v156 == 0;\n\tif (v158) goto L_FFFFFFFF;\n\tv209 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v45, \"actionId\");\n\tv214 = v209 == 0;\n\tif (v214) goto L_FFFFFFFF;\n\tv217 = *([v209 @ X0_v22 (System.String)]) != System.String;\n\tif (v217) goto L_FFFFFFFF;\n\tgoto L_0061;\nL_0061:\n\tgoto L_0068;\nL_0068:\n\tv246 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v45, \"request\");\n\tv251 = v246 == 0;\n\tif (v251) goto L_FFFFFFFF;\n\tv142 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v45, \"request\");\n\tv144 = v142 == 0;\n\tif (v144) goto L_0083;\n\tv120 = *([v142 @ X0_v18 (System.String)]) != System.String;\n\tif (v120) goto L_009B;\nL_0083:\n\tv271 = EasyMobile.Internal.Notifications.Android.AndroidNotificationRequest::FromJson(v142);\n\tgoto L_008A;\nL_008A:\n\tv278 = new EasyMobile.Internal.Notifications.Android.AndroidNotificationResponse();\n\tSystem.Object::.ctor(v278);\n\tv278.actionId = v117;\n\tv278.request = v272;\n\treturn v278;\n\tv103 = new System.NullReferenceException();\nL_009B:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidNotificationResponse FromJson(string jsonData)
		{
			object obj = Json.Deserialize(jsonData);
			Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
			string text2;
			if (((Dictionary<string, object>)obj).ContainsKey("actionId"))
			{
				string text = (string)((Dictionary<string, object>)obj).get_Item("actionId");
				if (text != null)
				{
					text2 = (((object)text.GetType() != typeof(string)) ? null : text);
					goto IL_0190;
				}
			}
			text2 = null;
			goto IL_0190;
			IL_0190:
			AndroidNotificationRequest androidNotificationRequest2;
			if (((Dictionary<string, object>)obj).ContainsKey("request"))
			{
				string text3 = (string)((Dictionary<string, object>)obj).get_Item("request");
				if (text3 != null && (object)text3.GetType() != typeof(string))
				{
					return (AndroidNotificationResponse)(object)new InvalidCastException();
				}
				AndroidNotificationRequest androidNotificationRequest = AndroidNotificationRequest.FromJson(text3);
				androidNotificationRequest2 = androidNotificationRequest;
			}
			else
			{
				androidNotificationRequest2 = null;
			}
			return new AndroidNotificationResponse(text2, androidNotificationRequest2);
		}
	}
}
