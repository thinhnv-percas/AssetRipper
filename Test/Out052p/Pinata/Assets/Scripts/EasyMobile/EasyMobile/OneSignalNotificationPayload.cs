using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000080")]
	public class OneSignalNotificationPayload
	{
		[Token(Token = "0x40002F5")]
		[FieldOffset(Offset = "0x10")]
		public string notificationID;

		[Token(Token = "0x40002F6")]
		[FieldOffset(Offset = "0x18")]
		public string sound;

		[Token(Token = "0x40002F7")]
		[FieldOffset(Offset = "0x20")]
		public string title;

		[Token(Token = "0x40002F8")]
		[FieldOffset(Offset = "0x28")]
		public string body;

		[Token(Token = "0x40002F9")]
		[FieldOffset(Offset = "0x30")]
		public string subtitle;

		[Token(Token = "0x40002FA")]
		[FieldOffset(Offset = "0x38")]
		public string launchURL;

		[Token(Token = "0x40002FB")]
		[FieldOffset(Offset = "0x40")]
		public Dictionary<string, object> additionalData;

		[Token(Token = "0x40002FC")]
		[FieldOffset(Offset = "0x48")]
		public Dictionary<string, object> actionButtons;

		[Token(Token = "0x40002FD")]
		[FieldOffset(Offset = "0x50")]
		public bool contentAvailable;

		[Token(Token = "0x40002FE")]
		[FieldOffset(Offset = "0x54")]
		public int badge;

		[Token(Token = "0x40002FF")]
		[FieldOffset(Offset = "0x58")]
		public string smallIcon;

		[Token(Token = "0x4000300")]
		[FieldOffset(Offset = "0x60")]
		public string largeIcon;

		[Token(Token = "0x4000301")]
		[FieldOffset(Offset = "0x68")]
		public string bigPicture;

		[Token(Token = "0x4000302")]
		[FieldOffset(Offset = "0x70")]
		public string smallIconAccentColor;

		[Token(Token = "0x4000303")]
		[FieldOffset(Offset = "0x78")]
		public string ledColor;

		[Token(Token = "0x4000304")]
		[FieldOffset(Offset = "0x80")]
		public int lockScreenVisibility;

		[Token(Token = "0x4000305")]
		[FieldOffset(Offset = "0x88")]
		public string groupKey;

		[Token(Token = "0x4000306")]
		[FieldOffset(Offset = "0x90")]
		public string groupMessage;

		[Token(Token = "0x4000307")]
		[FieldOffset(Offset = "0x98")]
		public string fromProjectNumber;

		[Token(Token = "0x60005A8")]
		[Address(RVA = "0xFD17C4", Offset = "0xFD17C4", Length = "0x6F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = *([1EEA768]);\n\tv37 = *([v36 @ X8_v98]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, jsonDict, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20256A1]) = v55;\nL_001F:\n\tv59 = jsonDict == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv64 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(jsonDict);\n\tv68 = v64 == 0;\n\tif (v68) goto L_FFFFFFFF;\n\tv257 = new EasyMobile.OneSignalNotificationPayload();\n\tv257.lockScreenVisibility = 1;\n\tSystem.Object::.ctor(v257);\n\tv257.notificationID = id;\n\tv309 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(jsonDict, \"aps\");\n\tv415 = v309 == 0;\n\tif (v415) goto L_017A;\n\tv396 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(jsonDict, \"aps\");\n\tgoto L_FFFFFFFF;\n\tv606 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v396, \"sound\");\n\tv614 = v606 == 0;\n\tif (v614) goto L_0094;\n\tv622 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v396, \"sound\");\n\tv646 = v622 == 0;\n\tif (v646) goto L_FFFFFFFF;\n\tv684 = *([v622 @ X0_v102 (System.String)]) != System.String;\n\tif (v684) goto L_FFFFFFFF;\n\tgoto L_008A;\nL_008A:\n\tgoto L_008E;\n\tgoto L_02D5;\nL_008E:\n\tv257.sound = v648;\nL_0094:\n\tv654 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v396, \"content-available\");\n\tv665 = v654 == 0;\n\tif (v665) goto L_00BE;\n\tv689 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v396, \"content-available\");\n\tgoto L_00AC;\n\tv752 = *([v745 @ X8_v86+E0]);\n\tv753 = v752 == 0;\n\tv754 = ~v753;\n\tif (v754) goto L_00AC;\n\tv815 = v745;\n\tv756 = \"il2cpp_codegen_runtime_class_init\"(v815, v686, v687, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00AC:\n\tv706 = System.Convert::ToInt32(v689);\n\tv697 = v706 == 0;\n\tv692 = ~v697;\n\tv257.contentAvailable = v692;\nL_00BE:\n\tv715 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v396, \"alert\");\n\tv750 = v715 == 0;\n\tif (v750) goto L_015B;\n\tv397 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v396, \"alert\");\n\tgoto L_FFFFFFFF;\n\tv887 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v397, \"title\");\n\tv901 = v887 == 0;\n\tif (v901) goto L_0111;\n\tv939 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v397, \"title\");\n\tv964 = v939 == 0;\n\tif (v964) goto L_FFFFFFFF;\n\tv991 = *([v939 @ X0_v93 (System.String)]) != System.String;\n\tif (v991) goto L_FFFFFFFF;\n\tgoto L_0109;\nL_0109:\n\tgoto L_010B;\nL_010B:\n\tv257.title = v966;\nL_0111:\n\tv972 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v397, \"body\");\n\tv975 = v972 == 0;\n\tif (v975) goto L_0136;\n\tv996 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v397, \"body\");\n\tv1011 = v996 == 0;\n\tif (v1011) goto L_FFFFFFFF;\n\tv1036 = *([v996 @ X0_v91 (System.String)]) != System.String;\n\tif (v1036) goto L_FFFFFFFF;\n\tgoto L_012E;\nL_012E:\n\tgoto L_0130;\nL_0130:\n\tv257.body = v1012;\nL_0136:\n\tv789 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v397, \"subtitle\");\n\tv792 = v789 == 0;\n\tif (v792) goto L_015B;\n\tv788 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v397, \"subtitle\");\n\tv791 = v788 == 0;\n\tif (v791) goto L_FFFFFFFF;\n\tv1061 = *([v788 @ X0_v89 (System.String)]) != System.String;\n\tif (v1061) goto L_FFFFFFFF;\n\tgoto L_0153;\nL_0153:\n\tgoto L_0155;\nL_0155:\n\tv257.subtitle = v793;\nL_015B:\n\tv497 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v396, \"badge\");\n\tv500 = v497 == 0;\n\tif (v500) goto L_017A;\n\tv825 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v396, \"badge\");\n\tgoto L_0173;\n\tv888 = *([v504 @ X8_v56+E0]);\n\tv889 = v888 == 0;\n\tv890 = ~v889;\n\tif (v890) goto L_0173;\n\tv902 = v504;\n\tv892 = \"il2cpp_codegen_runtime_class_init\"(v902, v823, v490, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0173:\n\tv496 = System.Convert::ToInt32(v825);\n\tv257.badge = v496;\nL_017A:\n\tv511 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(jsonDict, \"custom\");\n\tv513 = v511 == 0;\n\tif (v513) goto L_0204;\n\tv522 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(jsonDict, \"custom\");\n\tv582 = v522 == 0;\n\tif (v582) goto L_0204;\n\tgoto L_FFFFFFFF;\n\tv528 = v528_asT == 0;\n\tif (v528) goto L_0204;\n\tv660 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v522, \"u\");\n\tv667 = v660 == 0;\n\tif (v667) goto L_01D1;\n\tv719 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v522, \"u\");\n\tv734 = v719 == 0;\n\tif (v734) goto L_FFFFFFFF;\n\tv810 = *([v719 @ X0_v57 (System.String)]) != System.String;\n\tif (v810) goto L_FFFFFFFF;\n\tgoto L_01C9;\nL_01C9:\n\tgoto L_01CB;\nL_01CB:\n\tv257.launchURL = v735;\nL_01D1:\n\tv579 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(v522, \"a\");\n\tv583 = v579 == 0;\n\tif (v583) goto L_0204;\n\tv578 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v522, \"a\");\n\tv581 = v578 == 0;\n\tif (v581) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01FE;\n\tv873 = v873_asT == 0;\n\tif (v873) goto L_FFFFFFFF;\n\tgoto L_01FE;\nL_01FE:\n\tv257.additionalData = v586;\nL_0204:\n\tv218 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::ContainsKey(jsonDict, \"buttons\");\n\tv223 = v218 == 0;\n\tif (v223) goto L_02D5;\n\tv219 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(jsonDict, \"buttons\");\n\tv224 = v219 == 0;\n\tif (v224) goto L_02D5;\n\tgoto L_FFFFFFFF;\n\tv101 = v101_asT == 0;\n\tif (v101) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv118 = v118_asT == 0;\n\tif (v118) goto L_02D5;\n\tv398 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v398);\n\tv257.actionButtons = v398;\n\tv881 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(v233);\nL_0256:\n\tv928 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v95 @ stack_-98_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv225 = v928 == 0;\n\tif (v225) goto L_02A7;\n\tv931 = v895 == 0;\n\tif (v931) goto L_0256;\n\tgoto L_FFFFFFFF;\n\tv419 = v419_asT == 0;\n\tif (v419) goto L_0256;\n\tv1042 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v895, \"i\");\n\tv443 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v895, \"n\");\n\tv445 = v257.actionButtons == 0;\n\tif (v445) goto L_02AC;\n\tv932 = v1042 == 0;\n\tif (v932) goto L_FFFFFFFF;\n\tv1079 = *([v1042 @ X0_v43 (System.String)]) != System.String;\n\tif (v1079) goto L_FFFFFFFF;\n\tgoto L_029D;\nL_029D:\n\tgoto L_02A1;\nL_02A1:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v257.actionButtons, v926, v443);\n\tgoto L_0256;\nL_02A7:\n\tv220 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v95 @ stack_-98_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_02D5;\n\tthrow System.NullReferenceException;\nL_02AC:\n\tv452 = new System.NullReferenceException();\n\tgoto L_02BA;\n\tgoto L_02BA;\n\tgoto L_02BA;\n\tgoto L_02BA;\nL_02BA:\n\tv113 = \"n\" != 1;\n\tif (v113) goto L_02D6;\n\tv591 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v452, \"n\", v443);\n\tv597 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v591, \"n\", v443);\n\tv217 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v75 @ stack_-80_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv618 = *([v591 @ X0_v16]) == 0;\n\tv222 = ~v618;\n\tif (v222) goto L_02DA;\nL_02D5:\n\treturn v239;\nL_02D6:\n\tv592 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v452, \"n\"\n// ... truncated")]
		public static OneSignalNotificationPayload FromJSONDict(string id, Dictionary<string, object> jsonDict)
		{
			//IL_0555: Expected I4, but got O
			//IL_0590: Expected O, but got I4
			//IL_09b9: Expected O, but got I4
			//IL_05f6: Expected O, but got I4
			OneSignalNotificationPayload result;
			if (jsonDict != null && jsonDict.Count != 0)
			{
				OneSignalNotificationPayload oneSignalNotificationPayload = new OneSignalNotificationPayload();
				oneSignalNotificationPayload.lockScreenVisibility = 1;
				oneSignalNotificationPayload.notificationID = id;
				if (jsonDict.ContainsKey("aps"))
				{
					object obj = jsonDict.get_Item("aps");
					Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
					if (((Dictionary<string, object>)obj).ContainsKey("sound"))
					{
						string text = (string)((Dictionary<string, object>)obj).get_Item("sound");
						string text2 = ((text == null) ? null : (((object)text.GetType() != typeof(string)) ? null : text));
						oneSignalNotificationPayload.sound = text2;
					}
					if (((Dictionary<string, object>)obj).ContainsKey("content-available"))
					{
						object value = ((Dictionary<string, object>)obj).get_Item("content-available");
						int num = Convert.ToInt32(value);
						bool flag = num == 0;
						bool flag2 = !flag;
						oneSignalNotificationPayload.contentAvailable = flag2;
					}
					if (((Dictionary<string, object>)obj).ContainsKey("alert"))
					{
						object obj2 = ((Dictionary<string, object>)obj).get_Item("alert");
						Dictionary<string, object> dictionary2 = obj2 as Dictionary<string, object>;
						if (((Dictionary<string, object>)obj2).ContainsKey("title"))
						{
							string text3 = (string)((Dictionary<string, object>)obj2).get_Item("title");
							string text4 = ((text3 == null) ? null : (((object)text3.GetType() != typeof(string)) ? null : text3));
							oneSignalNotificationPayload.title = text4;
						}
						if (((Dictionary<string, object>)obj2).ContainsKey("body"))
						{
							string text5 = (string)((Dictionary<string, object>)obj2).get_Item("body");
							string text6 = ((text5 == null) ? null : (((object)text5.GetType() != typeof(string)) ? null : text5));
							oneSignalNotificationPayload.body = text6;
						}
						if (((Dictionary<string, object>)obj2).ContainsKey("subtitle"))
						{
							string text7 = (string)((Dictionary<string, object>)obj2).get_Item("subtitle");
							string text8 = ((text7 == null) ? null : (((object)text7.GetType() != typeof(string)) ? null : text7));
							oneSignalNotificationPayload.subtitle = text8;
						}
					}
					if (((Dictionary<string, object>)obj).ContainsKey("badge"))
					{
						object value2 = ((Dictionary<string, object>)obj).get_Item("badge");
						int num2 = Convert.ToInt32(value2);
						oneSignalNotificationPayload.badge = num2;
					}
				}
				if (jsonDict.ContainsKey("custom"))
				{
					object obj3 = jsonDict.get_Item("custom");
					if (obj3 != null)
					{
						Dictionary<string, object> dictionary3 = obj3 as Dictionary<string, object>;
						if (dictionary3 != null)
						{
							if (((Dictionary<string, object>)obj3).ContainsKey("u"))
							{
								string text9 = (string)((Dictionary<string, object>)obj3).get_Item("u");
								string text10 = ((text9 == null) ? null : (((object)text9.GetType() != typeof(string)) ? null : text9));
								oneSignalNotificationPayload.launchURL = text10;
							}
							if (((Dictionary<string, object>)obj3).ContainsKey("a"))
							{
								Dictionary<string, object> dictionary4 = (Dictionary<string, object>)((Dictionary<string, object>)obj3).get_Item("a");
								Dictionary<string, object> dictionary5;
								if (dictionary4 == null)
								{
									dictionary5 = null;
								}
								else
								{
									Dictionary<string, object> dictionary6 = dictionary4 as Dictionary<string, object>;
									dictionary5 = ((dictionary6 == null) ? null : dictionary4);
								}
								oneSignalNotificationPayload.additionalData = dictionary5;
							}
						}
					}
				}
				bool flag3 = jsonDict.ContainsKey("buttons");
				bool flag4 = !flag3;
				result = oneSignalNotificationPayload;
				if (!flag4)
				{
					int num3 = (int)jsonDict.get_Item("buttons");
					bool flag5 = num3 == 0;
					result = oneSignalNotificationPayload;
					if (!flag5)
					{
						result = oneSignalNotificationPayload;
						List<object> list = num3 as List<object>;
						int num4 = ((list != null) ? num3 : 0);
						List<object> list2 = num3 as List<object>;
						bool flag6 = list2 == null;
						result = oneSignalNotificationPayload;
						if (!flag6)
						{
							Dictionary<string, object> dictionary7 = new Dictionary<string, object>();
							oneSignalNotificationPayload.actionButtons = dictionary7;
							object enumerator = ((List<object>)num4).GetEnumerator();
							List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
							object obj4 = default(object);
							object obj5 = default(object);
							while (true)
							{
								if (enumerator2.MoveNext())
								{
									if (obj4 == null)
									{
										continue;
									}
									Dictionary<string, object> dictionary8 = obj4 as Dictionary<string, object>;
									if (dictionary8 == null)
									{
										continue;
									}
									string text11 = (string)((Dictionary<string, object>)obj4).get_Item("i");
									object value3 = ((Dictionary<string, object>)obj4).get_Item("n");
									bool flag7 = oneSignalNotificationPayload.actionButtons == null;
									List<object>.Enumerator enumerator3 = enumerator2;
									if (flag7)
									{
										NullReferenceException ex = new NullReferenceException();
										if ((IntPtr)"n" == (IntPtr)1)
										{
											((Dictionary<string, object>)(object)ex).Add("n", value3);
											((Dictionary<string, object>)obj5).Add("n", value3);
											enumerator3.Dispose();
											bool flag8 = obj5 == null;
											bool flag9 = !flag8;
											result = oneSignalNotificationPayload;
											if (!flag9)
											{
												break;
											}
										}
										else
										{
											((Dictionary<string, object>)(object)ex).Add("n", value3);
										}
										return (OneSignalNotificationPayload)(object)new TypeLoadException();
									}
									string key = ((text11 == null) ? null : (((object)text11.GetType() != typeof(string)) ? null : text11));
									oneSignalNotificationPayload.actionButtons.Add(key, value3);
									continue;
								}
								enumerator2.Dispose();
								result = oneSignalNotificationPayload;
								break;
							}
						}
					}
				}
			}
			else
			{
				result = null;
			}
			return result;
		}

		[Token(Token = "0x60005A9")]
		[Address(RVA = "0xFD1EC4", Offset = "0xFD1EC4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBACA0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256A2]) = v38;\nL_0016:\n\tv42 = new EasyMobile.NotificationContent();\n\tEasyMobile.NotificationContent::.ctor(v42);\n\tv42.title = this.title;\n\tv42.subtitle = this.subtitle;\n\tv42.body = this.body;\n\tv42.badge = this.badge;\n\tv42.userInfo = this.additionalData;\n\tv42.smallIcon = this.smallIcon;\n\tv42.largeIcon = this.largeIcon;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal NotificationContent ToNotificationContent()
		{
			NotificationContent notificationContent = new NotificationContent();
			notificationContent.title = title;
			notificationContent.subtitle = subtitle;
			notificationContent.body = body;
			notificationContent.badge = badge;
			notificationContent.userInfo = additionalData;
			notificationContent.smallIcon = smallIcon;
			notificationContent.largeIcon = largeIcon;
			return notificationContent;
		}

		[Token(Token = "0x60005AA")]
		[Address(RVA = "0xFD1EB4", Offset = "0xFD1EB4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lockScreenVisibility = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public OneSignalNotificationPayload()
		{
			lockScreenVisibility = 1;
		}
	}
}
