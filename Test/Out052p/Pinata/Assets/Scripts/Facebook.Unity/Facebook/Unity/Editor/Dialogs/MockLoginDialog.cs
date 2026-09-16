using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;
using UnityEngine;

namespace Facebook.Unity.Editor.Dialogs
{
	[Token(Token = "0x200005B")]
	internal class MockLoginDialog : EditorFacebookMockDialog
	{
		[CompilerGenerated]
		[Token(Token = "0x200005C")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x400009E")]
			[FieldOffset(Offset = "0x10")]
			public string facebookID;

			[Token(Token = "0x400009F")]
			[FieldOffset(Offset = "0x18")]
			public MockLoginDialog _003C_003E4__this;

			[Token(Token = "0x600022E")]
			[Address(RVA = "0xD25FA8", Offset = "0xD25FA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal void _003CSendSuccessResult_003Eb__1(IGraphResult permResult)
			{
				//IL_0030: Expected I, but got O
				//IL_006b: Expected O, but got I
				//IL_092f: Expected I4, but got O
				//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
				//IL_00fb: Expected O, but got Unknown
				//IL_0118: Expected O, but got I
				//IL_0127: Expected O, but got I
				//IL_00b7: Expected O, but got I
				//IL_015d: Expected O, but got I4
				//IL_0182: Expected O, but got I4
				//IL_093d: Expected O, but got I4
				//IL_04f9: Expected I, but got O
				//IL_09e7: Expected I, but got O
				//IL_0534: Expected O, but got I
				//IL_05fd: Expected O, but got I
				//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
				//IL_05b6: Expected O, but got Unknown
				//IL_05d3: Expected O, but got I
				//IL_05e2: Expected O, but got I
				//IL_0580: Expected O, but got I
				//IL_067a: Unknown result type (might be due to invalid IL or missing references)
				//IL_067f: Expected O, but got Unknown
				//IL_069c: Expected O, but got I
				//IL_06ab: Expected O, but got I
				//IL_0649: Expected O, but got I
				//IL_0712: Expected I, but got O
				//IL_074d: Expected O, but got I
				//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_07cf: Expected O, but got Unknown
				//IL_07ec: Expected O, but got I
				//IL_07fb: Expected O, but got I
				//IL_0799: Expected O, but got I
				string text = permResult.Error;
				List<string> list;
				List<string> list2;
				int num4;
				if (string.IsNullOrEmpty(text))
				{
					list = new List<string>();
					list2 = new List<string>();
					IntPtr intPtr = (IntPtr)permResult;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X8_v20 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00d0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X8_v20 (Il2CppClass<Facebook.Unity.IGraphResult>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X11_v45-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IResult))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X8_v20 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00d0;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					text = (string)((long)(IntPtr)obj3 + 304L);
					num4 = 0;
					goto IL_08ea;
				}
				text = permResult.Error;
				text = "Graph API error: " + text;
				_003C_003E4__this.SendErrorResult(text);
				return;
				IL_0a37:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
				_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_1;
				MockLoginDialog mockLoginDialog = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
				text = mockLoginDialog.CallbackID;
				if (string.IsNullOrEmpty(mockLoginDialog.CallbackID))
				{
					goto IL_0a53;
				}
				MockLoginDialog mockLoginDialog2 = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
				IDictionary<string, object> dictionary;
				IntPtr intPtr2 = (IntPtr)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ X8_v59 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_07b2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ X8_v59 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
				object obj4 = 0L + 8L;
				int num5 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ X11_v25-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
					{
						break;
					}
					num5++;
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ X8_v59 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
					bool flag3 = (long)num6 < 0L;
					bool flag4 = !flag3;
					obj4 = (long)(IntPtr)obj4 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_07b2;
				}
				object obj5 = obj4 + 1;
				int num7 = (int)((long)(IntPtr)obj5 << 4);
				object obj6 = (long)intPtr2 + (long)num7;
				text = (string)((long)(IntPtr)obj6 + 304L);
				goto IL_0a90;
				IL_08ea:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
				int num8 = (int)((IDictionary<string, object>)(object)text).get_Item("data");
				List<object> list3 = num8 as List<object>;
				List<object> list4 = num8 as List<object>;
				if (list4 == null)
				{
					num8 = 0;
				}
				text = (string)((List<object>)num8).GetEnumerator();
				List<object>.Enumerator enumerator = default(List<object>.Enumerator);
				object obj7 = default(object);
				List<string> list6 = default(List<string>);
				DateTime expirationTime = default(DateTime);
				while (true)
				{
					string item2;
					List<string> list5;
					if (enumerator.MoveNext())
					{
						Dictionary<string, object> dictionary2 = obj7 as Dictionary<string, object>;
						if (dictionary2 == null)
						{
							throw new InvalidCastException();
						}
						text = (string)((Dictionary<string, object>)obj7).get_Item("status");
						if (text != null && (object)text.GetType() != typeof(string))
						{
							text = null;
						}
						if (!(text == "granted"))
						{
							text = (string)((Dictionary<string, object>)obj7).get_Item("permission");
							string item = ((text == null) ? null : (((object)text.GetType() != typeof(string)) ? null : text));
							list2.Add(item);
							continue;
						}
						text = (string)((Dictionary<string, object>)obj7).get_Item("permission");
						bool flag5 = list == null;
						item2 = "permission";
						if (!flag5)
						{
							string item3 = ((text == null) ? null : (((object)text.GetType() != typeof(string)) ? null : text));
							list.Add(item3);
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						bool flag6 = (IntPtr)"permission" != (IntPtr)1;
						list5 = (List<string>)(object)ex;
						if (flag6)
						{
							goto IL_0871;
						}
						((List<string>)(object)ex).Add("permission");
						list6.Add("permission");
						enumerator.Dispose();
						bool flag7 = list6 == null;
						bool flag8 = !flag7;
						_003C_003Ec__DisplayClass4_1 = this;
						if (flag8)
						{
							goto IL_0883;
						}
					}
					else
					{
						enumerator.Dispose();
						_003C_003Ec__DisplayClass4_1 = this;
					}
					MockLoginDialog mockLoginDialog3 = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
					DateTime utcNow = DateTime.UtcNow;
					((List<string>)utcNow).Add((string)null);
					DateTime utcNow2 = DateTime.UtcNow;
					DateTime? dateTime = null;
					dateTime = utcNow2;
					AccessToken accessToken = new AccessToken(mockLoginDialog3.accessToken, _003C_003Ec__DisplayClass4_1.facebookID, expirationTime, list, null);
					text = accessToken.ToJson();
					object obj8 = Json.Parser.Parse(text);
					dictionary = obj8 as IDictionary<string, object>;
					if (dictionary != null)
					{
						IntPtr intPtr3 = (IntPtr)dictionary;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v46 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v46 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
							object obj9 = 0L + 8L;
							int num9 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1322 @ X11_v35-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
								{
									break;
								}
								num9++;
								int num10 = num9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v46 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
								bool flag9 = (long)num10 < 0L;
								bool flag10 = !flag9;
								obj9 = (long)(IntPtr)obj9 + 16L;
								if (!flag10)
								{
									continue;
								}
								goto IL_0599;
							}
							object obj10 = obj9 + 4;
							int num11 = (int)((long)(IntPtr)obj10 << 4);
							object obj11 = (long)intPtr3 + (long)num11;
							text = (string)((long)(IntPtr)obj11 + 304L);
							break;
						}
						goto IL_0599;
					}
					InvalidCastException ex2 = new InvalidCastException();
					item2 = (string)(object)typeof(IDictionary<string, object>);
					list5 = (List<string>)(object)ex2;
					goto IL_0871;
					IL_0883:
					throw new TypeLoadException();
					IL_0599:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					break;
					IL_0871:
					list5.Add(item2);
					goto IL_0883;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
				IntPtr intPtr4 = (IntPtr)dictionary;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ X8_v49 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0662;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ X8_v49 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
				object obj12 = 0L + 8L;
				int num12 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1408 @ X11_v30-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
					{
						break;
					}
					num12++;
					int num13 = num12;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ X8_v49 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
					bool flag11 = (long)num13 < 0L;
					bool flag12 = !flag11;
					obj12 = (long)(IntPtr)obj12 + 16L;
					if (!flag12)
					{
						continue;
					}
					goto IL_0662;
				}
				object obj13 = obj12 + 4;
				int num14 = (int)((long)(IntPtr)obj13 << 4);
				object obj14 = (long)intPtr4 + (long)num14;
				text = (string)((long)(IntPtr)obj14 + 304L);
				goto IL_0a37;
				IL_07b2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0a90;
				IL_0a53:
				MockLoginDialog mockLoginDialog4 = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
				if (mockLoginDialog4.Callback != null)
				{
					ResultContainer obj15 = new ResultContainer(dictionary);
					mockLoginDialog4.Callback(obj15);
				}
				return;
				IL_0662:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0a37;
				IL_0a90:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
				goto IL_0a53;
				IL_00d0:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num4 = 1;
				goto IL_08ea;
			}
		}

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x40")]
		private string accessToken;

		[Token(Token = "0x17000079")]
		protected override string DialogTitle
		{
			[Token(Token = "0x6000229")]
			[Address(RVA = "0xD258C4", Offset = "0xD258C4", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE2E98]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023BAC]) = v35;\nL_0018:\n\treturn \"Mock Login Dialog\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "Mock Login Dialog";
			}
		}

		[Token(Token = "0x600022A")]
		[Address(RVA = "0xD2590C", Offset = "0xD2590C", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED1220]);\n\tv27 = *([v26 @ X8_v37]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023BAD]) = v46;\nL_001B:\n\t// 27 NewArr v51 @ X0_v3 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tUnityEngine.GUILayout::BeginHorizontal(v51);\n\t// 32 NewArr v55 @ X0_v5 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tUnityEngine.GUILayout::Label(\"User Access Token:\", v55);\n\tgoto L_0036;\n\tv69 = *([v65 @ X0_v7+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0036;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v58, v59, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0036:\n\tv77 = UnityEngine.GUI::get_skin();\n\tv80 = UnityEngine.GUISkin::get_textArea(v77);\n\t// 63 NewArr v86 @ X0_v21 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tv96 = UnityEngine.GUILayout::MinWidth(400f);\n\tv117 = v96 == 0;\n\tif (v117) goto L_0051;\n\t// 77 IsInst v134 @ X0_v48, typeof(UnityEngine.GUILayoutOption), v96 @ X0_v23 (UnityEngine.GUILayoutOption)\nL_0051:\n\tv113 = v86.Length == 0;\n\tif (v113) goto L_00A7;\n\tv86[0] = v96;\n\tv141 = UnityEngine.GUILayout::TextField(this.accessToken, v80, v86);\n\tthis.accessToken = v141;\n\tUnityEngine.GUILayout::EndHorizontal();\n\tUnityEngine.GUILayout::Space(10f);\n\t// 97 NewArr v179 @ X0_v30 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tv186 = UnityEngine.GUILayout::Button(\"Find Access Token\", v179);\n\tv188 = v186 == 0;\n\tif (v188) goto L_00A2;\n\tgoto L_007C;\n\tv205 = *([v191 @ X0_v35+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_007C;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v191, v182, v183, v140, v32, v33, v34, v35, v175, v37, v38, v39, v40, v41, v42, v43);\nL_007C:\n\tgoto L_0087;\n\tv216 = *([1EDE4B8]);\n\tv217 = *([v216 @ X8_v30]);\n\tv218 = \"il2cpp_codegen_initialize_method\"(v217, v182, v183, v140, v32, v33, v34, v35, v175, v37, v38, v39, v40, v41, v42, v43);\n\tv221 = 0 | 1;\n\t*([2021D31]) = v221;\nL_0087:\n\tgoto L_0094;\n\tv226 = *([v222 @ X0_v38 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv227 = v226 == 0;\n\tv228 = ~v227;\n\tgoto L_0094;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v222, v182, v183, v140, v32, v33, v34, v35, v175, v37, v38, v39, v40, v41, v42, v43);\n\tv230 = Facebook.Unity.FB;\nL_0094:\n\tv199 = System.String::Format(\"https://developers.facebook.com/tools/accesstoken/?app_id={0}\", v202.<AppId>k__BackingField);\n\tUnityEngine.Application::OpenURL(v199);\nL_00A2:\n\tUnityEngine.GUILayout::Space(20f);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv102 = new System.NullReferenceException();\nL_00A7:\n\tv116 = new System.IndexOutOfRangeException();\n\tgoto L_00AC;\n\tv125 = new System.ArrayTypeMismatchException();\nL_00AC:\n\tthrow v124;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void DoGui()
		{
			GUILayoutOption[] options = new GUILayoutOption[0];
			GUILayout.BeginHorizontal(options);
			GUILayoutOption[] options2 = new GUILayoutOption[0];
			GUILayout.Label("User Access Token:", options2);
			GUISkin skin = GUI.skin;
			GUIStyle textArea = skin.textArea;
			GUILayoutOption[] array = new GUILayoutOption[1];
			GUILayoutOption gUILayoutOption = GUILayout.MinWidth(400f);
			if (gUILayoutOption != null)
			{
				object obj = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				string text = GUILayout.TextField(accessToken, textArea, array);
				accessToken = text;
				GUILayout.EndHorizontal();
				GUILayout.Space(10f);
				GUILayoutOption[] options3 = new GUILayoutOption[0];
				if (GUILayout.Button("Find Access Token", options3))
				{
					string url = $"https://developers.facebook.com/tools/accesstoken/?app_id={FB.AppId}";
					Application.OpenURL(url);
				}
				GUILayout.Space(20f);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0xD25B34", Offset = "0xD25B34", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EF0A10]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BAE]) = v40;\nL_0016:\n\tv43 = System.String::IsNullOrEmpty(this.accessToken);\n\tv45 = v43 == 0;\n\tif (v45) goto L_002D;\n\tv47 = this->klass;\n\tv52 = this->klass->vtable[8];\n\tv53 = this->klass->vtable[8];\n\t// 39 IndirectJump v52 @ X3_v3, this @ X0 (Facebook.Unity.Editor.Dialogs.MockLoginDialog), this @ X0 (Facebook.Unity.Editor.Dialogs.MockLoginDialog), \"Empty Access token string\", v53 @ X2_v4, v52 @ X3_v3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\nL_002D:\n\tv63 = System.String::Concat(\"/me?fields=id&access_token=\", this.accessToken);\n\tv93 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>::.ctor(v93, this, Il2CppMethodInfo);\n\tgoto L_0053;\n\tv107 = *([v103 @ X0_v8+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0053;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v103, v97, v99, v100, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0053:\n\tFacebook.Unity.FB::API(v63, 0, v93, 0);\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void SendSuccessResult()
		{
			//IL_000a: Expected I, but got O
			//IL_001a: Expected O, but got I
			//IL_002a: Expected O, but got I
			if (string.IsNullOrEmpty(accessToken))
			{
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v15 (Il2CppClass<Facebook.Unity.Editor.Dialogs.MockLoginDialog>)+1B0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v15 (Il2CppClass<Facebook.Unity.Editor.Dialogs.MockLoginDialog>)+1B8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v52 @ X3_v3 (should have been resolved before IL gen)");
			}
			string query = "/me?fields=id&access_token=" + accessToken;
			FacebookDelegate<IGraphResult> callback = delegate(IGraphResult graphResult)
			{
				//IL_026b: Expected I, but got O
				//IL_030f: Expected I, but got O
				//IL_031f: Expected O, but got I
				//IL_032f: Expected O, but got I
				//IL_010c: Expected O, but got I
				//IL_0054: Expected O, but got I
				//IL_0158: Expected O, but got I
				//IL_0189: Unknown result type (might be due to invalid IL or missing references)
				//IL_018e: Expected O, but got Unknown
				//IL_01ab: Expected O, but got I
				//IL_01ba: Expected O, but got I
				//IL_00a0: Expected O, but got I
				_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass4_0();
				CS_0024_003C_003E8__locals5._003C_003E4__this = this;
				string error = graphResult.Error;
				bool flag = string.IsNullOrEmpty(error);
				IntPtr intPtr2 = (IntPtr)graphResult;
				int num4;
				if (flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v9 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00b9;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v9 (Il2CppClass<Facebook.Unity.IGraphResult>)+B0]");
					object obj3 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v353 @ X11_v19-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IResult))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v9 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
						bool flag2 = (long)num2 < 0L;
						bool flag3 = !flag2;
						obj3 = (long)(IntPtr)obj3 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_00b9;
					}
					object obj4 = obj3 + 1;
					int num3 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)intPtr2 + (long)num3;
					object obj6 = (long)(IntPtr)obj5 + 304L;
					num4 = 0;
					goto IL_02b2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v9 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0171;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v9 (Il2CppClass<Facebook.Unity.IGraphResult>)+B0]");
				object obj7 = 0L + 8L;
				int num5 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v374 @ X11_v7-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IResult))
					{
						break;
					}
					num5++;
					int num6 = num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v9 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
					bool flag4 = (long)num6 < 0L;
					bool flag5 = !flag4;
					obj7 = (long)(IntPtr)obj7 + 16L;
					if (!flag5)
					{
						continue;
					}
					goto IL_0171;
				}
				goto IL_02eb;
				IL_02eb:
				string error2 = graphResult.Error;
				string text = "Graph API error: " + error2;
				IntPtr intPtr3 = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X8_v15 (Il2CppClass<Facebook.Unity.Editor.Dialogs.MockLoginDialog>)+1B0]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v240 @ X8_v15 (Il2CppClass<Facebook.Unity.Editor.Dialogs.MockLoginDialog>)+1B8]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v174 @ X3_v1 (should have been resolved before IL gen)");
				goto IL_0339;
				IL_0339:
				object obj10 = default(object);
				string text2 = (string)((IDictionary<string, object>)obj10).get_Item("id");
				string facebookID = ((text2 == null) ? null : (((object)text2.GetType() != typeof(string)) ? null : text2));
				CS_0024_003C_003E8__locals5.facebookID = facebookID;
				string query2 = "/me/permissions?access_token=" + accessToken;
				FacebookDelegate<IGraphResult> callback2 = delegate(IGraphResult permResult)
				{
					//IL_0030: Expected I, but got O
					//IL_006b: Expected O, but got I
					//IL_092f: Expected I4, but got O
					//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
					//IL_00fb: Expected O, but got Unknown
					//IL_0118: Expected O, but got I
					//IL_0127: Expected O, but got I
					//IL_00b7: Expected O, but got I
					//IL_015d: Expected O, but got I4
					//IL_0182: Expected O, but got I4
					//IL_093d: Expected O, but got I4
					//IL_04f9: Expected I, but got O
					//IL_09e7: Expected I, but got O
					//IL_0534: Expected O, but got I
					//IL_05fd: Expected O, but got I
					//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
					//IL_05b6: Expected O, but got Unknown
					//IL_05d3: Expected O, but got I
					//IL_05e2: Expected O, but got I
					//IL_0580: Expected O, but got I
					//IL_067a: Unknown result type (might be due to invalid IL or missing references)
					//IL_067f: Expected O, but got Unknown
					//IL_069c: Expected O, but got I
					//IL_06ab: Expected O, but got I
					//IL_0649: Expected O, but got I
					//IL_0712: Expected I, but got O
					//IL_074d: Expected O, but got I
					//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
					//IL_07cf: Expected O, but got Unknown
					//IL_07ec: Expected O, but got I
					//IL_07fb: Expected O, but got I
					//IL_0799: Expected O, but got I
					string text3 = permResult.Error;
					if (!string.IsNullOrEmpty(text3))
					{
						text3 = permResult.Error;
						text3 = "Graph API error: " + text3;
						CS_0024_003C_003E8__locals5._003C_003E4__this.SendErrorResult(text3);
						return;
					}
					List<string> list = new List<string>();
					List<string> list2 = new List<string>();
					IntPtr intPtr4 = (IntPtr)permResult;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X8_v20 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00d0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X8_v20 (Il2CppClass<Facebook.Unity.IGraphResult>)+B0]");
					object obj11 = 0L + 8L;
					int num7 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X11_v45-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IResult))
						{
							break;
						}
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v780 @ X8_v20 (Il2CppClass<Facebook.Unity.IGraphResult>)+126]");
						bool flag6 = (long)num8 < 0L;
						bool flag7 = !flag6;
						obj11 = (long)(IntPtr)obj11 + 16L;
						if (!flag7)
						{
							continue;
						}
						goto IL_00d0;
					}
					object obj12 = obj11 + 1;
					int num9 = (int)((long)(IntPtr)obj12 << 4);
					object obj13 = (long)intPtr4 + (long)num9;
					text3 = (string)((long)(IntPtr)obj13 + 304L);
					int num10 = 0;
					goto IL_08ea;
					IL_0a37:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
					_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_1;
					MockLoginDialog mockLoginDialog = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
					text3 = mockLoginDialog.CallbackID;
					if (string.IsNullOrEmpty(mockLoginDialog.CallbackID))
					{
						goto IL_0a53;
					}
					MockLoginDialog mockLoginDialog2 = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
					IDictionary<string, object> dictionary;
					IntPtr intPtr5 = (IntPtr)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ X8_v59 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_07b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ X8_v59 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
					object obj14 = 0L + 8L;
					int num11 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ X11_v25-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
						{
							break;
						}
						num11++;
						int num12 = num11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1458 @ X8_v59 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
						bool flag8 = (long)num12 < 0L;
						bool flag9 = !flag8;
						obj14 = (long)(IntPtr)obj14 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_07b2;
					}
					object obj15 = obj14 + 1;
					int num13 = (int)((long)(IntPtr)obj15 << 4);
					object obj16 = (long)intPtr5 + (long)num13;
					text3 = (string)((long)(IntPtr)obj16 + 304L);
					goto IL_0a90;
					IL_08ea:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
					int num14 = (int)((IDictionary<string, object>)(object)text3).get_Item("data");
					List<object> list3 = num14 as List<object>;
					List<object> list4 = num14 as List<object>;
					if (list4 == null)
					{
						num14 = 0;
					}
					text3 = (string)((List<object>)num14).GetEnumerator();
					List<object>.Enumerator enumerator = default(List<object>.Enumerator);
					object obj17 = default(object);
					List<string> list6 = default(List<string>);
					DateTime expirationTime = default(DateTime);
					while (true)
					{
						string item2;
						List<string> list5;
						if (enumerator.MoveNext())
						{
							Dictionary<string, object> dictionary2 = obj17 as Dictionary<string, object>;
							if (dictionary2 == null)
							{
								throw new InvalidCastException();
							}
							text3 = (string)((Dictionary<string, object>)obj17).get_Item("status");
							if (text3 != null && (object)text3.GetType() != typeof(string))
							{
								text3 = null;
							}
							if (!(text3 == "granted"))
							{
								text3 = (string)((Dictionary<string, object>)obj17).get_Item("permission");
								string item = ((text3 == null) ? null : (((object)text3.GetType() != typeof(string)) ? null : text3));
								list2.Add(item);
								continue;
							}
							text3 = (string)((Dictionary<string, object>)obj17).get_Item("permission");
							bool flag10 = list == null;
							item2 = "permission";
							if (!flag10)
							{
								string item3 = ((text3 == null) ? null : (((object)text3.GetType() != typeof(string)) ? null : text3));
								list.Add(item3);
								continue;
							}
							NullReferenceException ex = new NullReferenceException();
							bool flag11 = (IntPtr)"permission" != (IntPtr)1;
							list5 = (List<string>)(object)ex;
							if (flag11)
							{
								goto IL_0871;
							}
							((List<string>)(object)ex).Add("permission");
							list6.Add("permission");
							enumerator.Dispose();
							bool flag12 = list6 == null;
							bool flag13 = !flag12;
							_003C_003Ec__DisplayClass4_1 = CS_0024_003C_003E8__locals5;
							if (flag13)
							{
								goto IL_0883;
							}
						}
						else
						{
							enumerator.Dispose();
							_003C_003Ec__DisplayClass4_1 = CS_0024_003C_003E8__locals5;
						}
						MockLoginDialog mockLoginDialog3 = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
						DateTime utcNow = DateTime.UtcNow;
						((List<string>)utcNow).Add((string)null);
						DateTime utcNow2 = DateTime.UtcNow;
						DateTime? dateTime = null;
						dateTime = utcNow2;
						AccessToken accessToken = new AccessToken(mockLoginDialog3.accessToken, _003C_003Ec__DisplayClass4_1.facebookID, expirationTime, list, null);
						text3 = accessToken.ToJson();
						object obj18 = Json.Parser.Parse(text3);
						dictionary = obj18 as IDictionary<string, object>;
						if (dictionary != null)
						{
							IntPtr intPtr6 = (IntPtr)dictionary;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v46 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v46 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
								object obj19 = 0L + 8L;
								int num15 = 0;
								while (true)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1322 @ X11_v35-8]");
									if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
									{
										break;
									}
									num15++;
									int num16 = num15;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1276 @ X8_v46 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
									bool flag14 = (long)num16 < 0L;
									bool flag15 = !flag14;
									obj19 = (long)(IntPtr)obj19 + 16L;
									if (!flag15)
									{
										continue;
									}
									goto IL_0599;
								}
								object obj20 = obj19 + 4;
								int num17 = (int)((long)(IntPtr)obj20 << 4);
								object obj21 = (long)intPtr6 + (long)num17;
								text3 = (string)((long)(IntPtr)obj21 + 304L);
								break;
							}
							goto IL_0599;
						}
						InvalidCastException ex2 = new InvalidCastException();
						item2 = (string)(object)typeof(IDictionary<string, object>);
						list5 = (List<string>)(object)ex2;
						goto IL_0871;
						IL_0883:
						throw new TypeLoadException();
						IL_0599:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						break;
						IL_0871:
						list5.Add(item2);
						goto IL_0883;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
					IntPtr intPtr7 = (IntPtr)dictionary;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ X8_v49 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0662;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ X8_v49 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
					object obj22 = 0L + 8L;
					int num18 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1408 @ X11_v30-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
						{
							break;
						}
						num18++;
						int num19 = num18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1362 @ X8_v49 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
						bool flag16 = (long)num19 < 0L;
						bool flag17 = !flag16;
						obj22 = (long)(IntPtr)obj22 + 16L;
						if (!flag17)
						{
							continue;
						}
						goto IL_0662;
					}
					object obj23 = obj22 + 4;
					int num20 = (int)((long)(IntPtr)obj23 << 4);
					object obj24 = (long)intPtr7 + (long)num20;
					text3 = (string)((long)(IntPtr)obj24 + 304L);
					goto IL_0a37;
					IL_07b2:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0a90;
					IL_0a53:
					MockLoginDialog mockLoginDialog4 = _003C_003Ec__DisplayClass4_1._003C_003E4__this;
					if (mockLoginDialog4.Callback != null)
					{
						ResultContainer obj25 = new ResultContainer(dictionary);
						mockLoginDialog4.Callback(obj25);
					}
					return;
					IL_0662:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_0a37;
					IL_0a90:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v494 @ X0_v16 (System.String)] (should have been resolved before IL gen)");
					goto IL_0a53;
					IL_00d0:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num10 = 1;
					goto IL_08ea;
				};
				FB.API(query2, default(HttpMethod), callback2);
				return;
				IL_00b9:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				num4 = 1;
				goto IL_02b2;
				IL_02b2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v390 @ X0_v20] (should have been resolved before IL gen)");
				goto IL_0339;
				IL_0171:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_02eb;
			};
			FB.API(query, default(HttpMethod), callback);
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0xD25C38", Offset = "0xD25C38", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F07870]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023BAF]) = v38;\nL_001A:\n\tthis.accessToken = v44.Empty;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MockLoginDialog()
		{
			accessToken = string.Empty;
		}
	}
}
