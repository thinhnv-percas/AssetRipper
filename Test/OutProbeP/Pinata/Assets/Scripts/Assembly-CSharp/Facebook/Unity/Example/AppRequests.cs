using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x200005C")]
	internal class AppRequests : MenuBase
	{
		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x60")]
		private string requestMessage;

		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x68")]
		private string requestTo;

		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x70")]
		private string requestFilter;

		[Token(Token = "0x4000273")]
		[FieldOffset(Offset = "0x78")]
		private string requestExcludes;

		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0x80")]
		private string requestMax;

		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0x88")]
		private string requestData;

		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0x90")]
		private string requestTitle;

		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0x98")]
		private string requestObjectID;

		[Token(Token = "0x4000278")]
		[FieldOffset(Offset = "0xA0")]
		private int selectedAction;

		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0xA8")]
		private string[] actionTypeStrings;

		[Token(Token = "0x600028A")]
		[Address(RVA = "0xA064F4", Offset = "0xA064F4", Length = "0x9B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EB6AA0]);\n\tv35 = *([v34 @ X8_v174]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021C96]) = v54;\nL_0020:\n\tv60 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Select - Filter None\");\n\tv62 = v60 == 0;\n\tif (v62) goto L_004F;\n\tv66 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppRequestResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppRequestResult>::.ctor(v66, this, Il2CppMethodInfo);\n\tgoto L_004A;\n\tv157 = *([v111 @ X0_v166+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_004A;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v111, v104, v105, v106, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_004A:\n\tFacebook.Unity.FB::AppRequest(\"Test Message\", 0, 0, 0, 0, \"\", \"\", v66);\nL_004F:\n\tv99 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Select - Filter app_users\");\n\tv108 = v99 == 0;\n\tif (v108) goto L_009B;\n\tv118 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v118);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v118, \"app_users\");\n\tv124 = 0;\n\tv366 = System.Nullable`1<System.Int32>::.ctor(&v124 @ stack_-70_v10 (System.Nullable`1<System.Int32>), 0);\n\tv422 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppRequestResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppRequestResult>::.ctor(v422, this, Il2CppMethodInfo);\n\tgoto L_0096;\n\tv590 = *([v573 @ X0_v159+E0]);\n\tv591 = v590 == 0;\n\tv592 = ~v591;\n\tif (v592) goto L_0096;\n\tv594 = \"il2cpp_codegen_runtime_class_init\"(v573, v487, v488, v489, v74, v76, v70, v72, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0096:\n\tFacebook.Unity.FB::AppRequest(\"Test Message\", 0, v118, 0, 0, v419.Empty, v419.Empty, v422);\nL_009B:\n\tv156 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Select - Filter app_non_users\");\n\tv169 = v156 == 0;\n\tif (v169) goto L_00E5;\n\tv174 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v174);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v174, \"app_non_users\");\n\tv124 = 0;\n\tv565 = System.Nullable`1<System.Int32>::.ctor(&v124 @ stack_-70_v10 (System.Nullable`1<System.Int32>), 0);\n\tv584 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppRequestResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IAppRequestResult>::.ctor(v584, this, Il2CppMethodInfo);\n\tgoto L_00E2;\n\tv683 = *([v675 @ X0_v148+E0]);\n\tv684 = v683 == 0;\n\tv685 = ~v684;\n\tif (v685) goto L_00E2;\n\tv687 = \"il2cpp_codegen_runtime_class_init\"(v675, v665, v666, v667, v132, v134, v128, v130, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00E2:\n\tFacebook.Unity.FB::AppRequest(\"Test Message\", 0, v174, 0, 0, v581.Empty, v581.Empty, v584);\nL_00E5:\n\tv209 = this + 0x60;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Message: \", v209);\n\tv285 = this + 0x68;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"To (optional): \", v285);\n\tv290 = this + 0x70;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Filter (optional): \", v290);\n\tv295 = this + 0x78;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Exclude Ids (optional): \", v295);\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Filters: \", v295);\n\tv352 = this + 0x80;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Max Recipients (optional): \", v352);\n\tv670 = this + 0x88;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Data (optional): \", v670);\n\tv309 = this + 0x90;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Title (optional): \", v309);\n\tv694 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0124;\n\tv699 = v694;\n\tv700 = 0x8907BC(v699, v682, v309, v191, v187, v189, v183, v185, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv703 = *([v694 @ X24_v5 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0124:\n\tv704 = *([v694 @ X24_v5 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv705 = v704 == 0;\n\tif (v705) goto L_0145;\n\tv707 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0131;\n\tv729 = v707;\n\tv730 = 0x8907BC(v729, v682, v309, v191, v187, v189, v183, v185, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0131:\n\tv731 = *([v707 @ X24_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv719 = ~v731;\n\tif (v719) goto L_0145;\n\tgoto L_0145;\n\tv743 = v713;\n\tv744 = 0x8907BC(v743, v682, v309, v191, v187, v189, v183, v185, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0145:\n\tgoto L_014B;\n\tv732 = v724;\n\tv733 = 0x8907BC(v732, v682, v309, v191, v187, v189, v183, v185, v44, v45, v46, v47, v48, v49, v50, v51);\nL_014B:\n\tUnityEngine.GUILayout::BeginHorizontal(v735.Value);\n\tv742 = Facebook.Unity.Example.ConsoleBase::get_LabelStyle(this);\n\t// 340 NewArr v750 @ X0_v34 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tv752 = Facebook.Unity.Example.ConsoleBase::get_ScaleFactor(this);\n\tv268 = v752 * 200f;\n\tv329 = UnityEngine.GUILayout::MaxWidth(v268);\n\tv754 = v329 == 0;\n\tif (v754) goto L_0169;\n\t// 357 IsInst this @ X0 (Facebook.Unity.Example.AppRequests), typeof(UnityEngine.GUILayoutOption), v329 @ X0_v37 (UnityEngine.GUILayoutOption)\nL_0169:\n\tv761 = v750.Length == 0;\n\tif (v761) goto L_02E2;\n\tv750[0] = v329;\n\tUnityEngine.GUILayout::Label(\"Request Action (optional): \", v742, v750);\n\tv784 = Facebook.Unity.Example.ConsoleBase::get_ButtonStyle(this);\n\t// 379 NewArr v787 @ X0_v45 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 2\n\tgoto L_018B;\n\tv794 = *([v790 @ X8_v51+E0]);\n\tv795 = v794 == 0;\n\tv796 = ~v795;\n\tif (v796) goto L_018B;\n\tv802 = v790;\n\tv798 = \"il2cpp_codegen_runtime_class_init\"(v802, v317, v310, v306, v187, v189, v183, v185, v268, v265, v46, v47, v48, v49, v50, v51);\nL_018B:\n\tv801 = Facebook.Unity.Constants::get_IsMobile();\n\tv805 = Facebook.Unity.Example.ConsoleBase::get_ScaleFactor(this);\n\tv252 = v801 == 0;\n\tv238 = ~v252;\n\tv235 = ~v238;\n\tif (v235) goto L_FFFFFFFF;\n\tgoto L_019F;\nL_019F:\n\tv269 = v266 * v805;\n\tv330 = UnityEngine.GUILayout::MinHeight(v269);\n\tv811 = v330 == 0;\n\tif (v811) goto L_01AD;\n\t// 425 IsInst this @ X0 (Facebook.Unity.Example.AppRequests), typeof(UnityEngine.GUILayoutOption), v330 @ X0_v51 (UnityEngine.GUILayoutOption)\nL_01AD:\n\tv775 = v787.Length == 0;\n\tif (v775) goto L_02E2;\n\tv787[0] = v330;\n\tv816 = Facebook.Unity.Constants::get_IsMobile();\n\tv818 = v816 == 0;\n\tif (v818) goto L_FFFFFFFF;\n\tv820 = UnityEngine.Screen::get_width();\n\tv824 = v820 - 0x1E;\n\tgoto L_01BA;\nL_01BA:\n\tv825 = v824 - 0x96;\n\tv827 = UnityEngine.GUILayout::MaxWidth(v825);\n\tv828 = v827 == 0;\n\tif (v828) goto L_01C8;\n\t// 452 IsInst this @ X0 (Facebook.Unity.Example.AppRequests), typeof(UnityEngine.GUILayoutOption), v827 @ X0_v57 (UnityEngine.GUILayoutOption)\nL_01C8:\n\tv831 = v787.Length < 1;\n\tv249 = ~v831;\n\tv232 = v787.Length - 1;\n\tv253 = v232 == 0;\n\tv832 = ~v249;\n\tv239 = v832 | v253;\n\tif (v239) goto L_02E2;\n\tv787[1] = v827;\n\tv836 = UnityEngine.GUILayout::Toolbar(this.selectedAction, this.actionTypeStrings, v784, v787);\n\tthis.selectedAction = v836;\n\tUnityEngine.GUILayout::EndHorizontal();\n\tv281 = this + 0x98;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Request Object ID (optional): \", v281);\n\tv846 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Custom App Request\");\n\tv848 = v846 == 0;\n\tif (v848) goto L_02E1;\n\tv850 = Facebook.Unity.Example.AppRequests::GetSelectedOGActionType(this);\n\tv890 = v850 & 0xFF00000000;\n\tv891 = v890 == 0;\n\tif (v891) goto L_0240;\n\tv896 = System.Nullable`1<Facebook.Unity.OGActionType>::get_Value(&v850 @ X0_v67 (System.Nullable`1<Facebook.Unity.OGActionType>));\n\tv903 = System.String::IsNullOrEmpty(*([v285 @ X23_v5 (System.String&)]));\n\tv909 = v903 == 0;\n\tv910 = ~v909;\n\tif (v910) goto L_021E;\n\t// 521 NewArr v331 @ X0_v116 (System.Char[]), typeof(System.Char[]), 1\n\tv777 = v331.Length == 0;\n\tif (v777) goto L_02E2;\n\tv331[0] = 0x2C;\n\tv936 = System.String::Split(*([v285 @ X23_v5 (System.String&)]), v331);\nL_0\n// ... truncated")]
		protected unsafe override void GetGui()
		{
			//IL_0534: Expected O, but got I4
			//IL_060f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0614: Expected I4, but got Unknown
			if (Button("Select - Filter None"))
			{
				FacebookDelegate<IAppRequestResult> callback = base.HandleResult;
				FB.AppRequest("Test Message", null, null, null, null, "", "", callback);
			}
			if (Button("Select - Filter app_users"))
			{
				List<object> list = new List<object>();
				list.Add("app_users");
				int? num = null;
				num = 0;
				FacebookDelegate<IAppRequestResult> callback2 = base.HandleResult;
				FB.AppRequest("Test Message", null, list, null, null, string.Empty, string.Empty, callback2);
			}
			if (Button("Select - Filter app_non_users"))
			{
				List<object> list2 = new List<object>();
				list2.Add("app_non_users");
				int? num = null;
				num = 0;
				FacebookDelegate<IAppRequestResult> callback3 = base.HandleResult;
				FB.AppRequest("Test Message", null, list2, null, null, string.Empty, string.Empty, callback3);
			}
			LabelAndTextField("Message: ", ref *(string*)((long)(IntPtr)this + 96L));
			ref string reference = ref *(string*)((long)(IntPtr)this + 104L);
			LabelAndTextField("To (optional): ", ref reference);
			ref string reference2 = ref *(string*)((long)(IntPtr)this + 112L);
			LabelAndTextField("Filter (optional): ", ref reference2);
			ref string reference3 = ref *(string*)((long)(IntPtr)this + 120L);
			LabelAndTextField("Exclude Ids (optional): ", ref reference3);
			LabelAndTextField("Filters: ", ref reference3);
			ref string reference4 = ref *(string*)((long)(IntPtr)this + 128L);
			LabelAndTextField("Max Recipients (optional): ", ref reference4);
			LabelAndTextField("Data (optional): ", ref *(string*)((long)(IntPtr)this + 136L));
			LabelAndTextField("Title (optional): ", ref *(string*)((long)(IntPtr)this + 144L));
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v694 @ X24_v5 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ X24_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginHorizontal();
			GUIStyle style = base.LabelStyle;
			GUILayoutOption[] array = new GUILayoutOption[1];
			float num2 = base.ScaleFactor;
			float maxWidth = num2 * 200f;
			GUILayoutOption gUILayoutOption = GUILayout.MaxWidth(maxWidth);
			if (gUILayoutOption != null)
			{
				AppRequests appRequests = (AppRequests)(object)(gUILayoutOption as GUILayoutOption);
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				GUILayout.Label("Request Action (optional): ", style, array);
				GUIStyle style2 = base.ButtonStyle;
				GUILayoutOption[] array2 = new GUILayoutOption[2];
				bool isMobile = Constants.IsMobile;
				float num3 = base.ScaleFactor;
				float num4 = ((!isMobile) ? 24f : 60f);
				float minHeight = num4 * num3;
				GUILayoutOption gUILayoutOption2 = GUILayout.MinHeight(minHeight);
				if (gUILayoutOption2 != null)
				{
					AppRequests appRequests = (AppRequests)(object)(gUILayoutOption2 as GUILayoutOption);
				}
				if (array2.Length != 0)
				{
					array2[0] = gUILayoutOption2;
					int num5;
					if (Constants.IsMobile)
					{
						int width = Screen.width;
						num5 = width - 30;
					}
					else
					{
						num5 = 700;
					}
					int num6 = num5 - 150;
					GUILayoutOption gUILayoutOption3 = GUILayout.MaxWidth(num6);
					if (gUILayoutOption3 != null)
					{
						AppRequests appRequests = (AppRequests)(object)(gUILayoutOption3 as GUILayoutOption);
					}
					bool flag = array2.Length < 1;
					bool flag2 = !flag;
					object obj = array2.Length - 1;
					bool flag3 = obj == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array2[1] = gUILayoutOption3;
						int num7 = GUILayout.Toolbar(selectedAction, actionTypeStrings, style2, array2);
						selectedAction = num7;
						GUILayout.EndHorizontal();
						ref string reference5 = ref *(string*)((long)(IntPtr)this + 152L);
						LabelAndTextField("Request Object ID (optional): ", ref reference5);
						if (!Button("Custom App Request"))
						{
							return;
						}
						OGActionType? selectedOGActionType = GetSelectedOGActionType();
						if ((int)((_003F?)selectedOGActionType & 0xFF00000000L) != 0)
						{
							OGActionType value = selectedOGActionType.Value;
							bool flag5 = string.IsNullOrEmpty(reference);
							bool flag6 = !flag5;
							bool flag7 = !flag6;
							IEnumerable<string> to = null;
							if (!flag7)
							{
								char[] array3 = new char[1];
								if (array3.Length == 0)
								{
									goto IL_0915;
								}
								array3[0] = ',';
								string[] array4 = reference.Split(array3);
								to = array4;
							}
							FacebookDelegate<IAppRequestResult> callback4 = base.HandleResult;
							FB.AppRequest(requestMessage, value, reference5, to, requestData, requestTitle, callback4);
							return;
						}
						bool flag8 = string.IsNullOrEmpty(reference);
						bool flag9 = !flag8;
						bool flag10 = !flag9;
						IEnumerable<string> to2 = null;
						if (!flag10)
						{
							char[] array5 = new char[1];
							if (array5.Length == 0)
							{
								goto IL_0915;
							}
							array5[0] = ',';
							string[] array6 = reference.Split(array5);
							to2 = array6;
						}
						bool flag11 = string.IsNullOrEmpty(reference2);
						bool flag12 = !flag11;
						bool flag13 = !flag12;
						IEnumerable<object> filters = null;
						if (!flag13)
						{
							char[] array7 = new char[1];
							if (array7.Length == 0)
							{
								goto IL_0915;
							}
							array7[0] = ',';
							string[] source = reference2.Split(array7);
							IEnumerable<object> source2 = source.OfType<object>();
							List<object> list3 = source2.ToList();
							filters = list3;
						}
						bool flag14 = string.IsNullOrEmpty(reference3);
						bool flag15 = !flag14;
						bool flag16 = !flag15;
						IEnumerable<string> excludeIds = null;
						if (!flag16)
						{
							char[] array8 = new char[1];
							if (array8.Length == 0)
							{
								goto IL_0915;
							}
							array8[0] = ',';
							string[] array9 = reference3.Split(array8);
							excludeIds = array9;
						}
						int value2;
						if (string.IsNullOrEmpty(reference4))
						{
							value2 = 0;
						}
						else
						{
							int num8 = int.Parse(reference4);
							value2 = num8;
						}
						int? num = null;
						num = value2;
						FacebookDelegate<IAppRequestResult> callback5 = base.HandleResult;
						FB.AppRequest(requestMessage, to2, filters, excludeIds, null, requestData, requestTitle, callback5);
						return;
					}
				}
			}
			goto IL_0915;
			IL_0915:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0xA073A8", Offset = "0xA073A8", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F0B3E0]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021C97]) = v42;\nL_0016:\n\tv44 = this.actionTypeStrings;\n\tv46 = this.selectedAction;\n\tv48 = this.selectedAction < v44.Length;\n\tv49 = ~v48;\n\tif (v49) goto L_0093;\n\tv106 = 0;\n\t// 45 Box v108 @ X0_v9, typeof(Facebook.Unity.OGActionType), &v106 @ stack_-3C_v4\n\tv44 = *([v108 @ X0_v9]);\n\tv44[40](v140, v108, v44[41], v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv143 = \"il2cpp_vm_object_unbox\"(v108, v44[41], v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv165 = System.String::op_Equality(v44[v46 @ X9_v3 (System.Int32)], v140);\n\tv206 = v165 == 0;\n\tif (v206) goto L_0049;\n\tgoto L_0086;\nL_0049:\n\tv157 = 1;\n\t// 76 Box v153 @ X0_v23, typeof(Facebook.Unity.OGActionType), &v157 @ X8_v12 (System.Int32)\n\tv44 = *([v153 @ X0_v23]);\n\tv44[40](v251, v153, v44[41], 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv253 = \"il2cpp_vm_object_unbox\"(v153, v44[41], 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv257 = System.String::op_Equality(v44[v46 @ X9_v3 (System.Int32)], v251);\n\tv234 = v257 == 0;\n\tif (v234) goto L_0068;\n\tgoto L_0086;\nL_0068:\n\tv158 = 2;\n\t// 107 Box v154 @ X0_v31, typeof(Facebook.Unity.OGActionType), &v158 @ X8_v15 (System.Int32)\n\tv44 = *([v154 @ X0_v31]);\n\tv44[40](v265, v154, v44[41], 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv267 = \"il2cpp_vm_object_unbox\"(v154, v44[41], 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv245 = System.String::op_Equality(v44[v46 @ X9_v3 (System.Int32)], v265);\n\tv233 = v245 == 0;\n\tif (v233) goto L_008F;\nL_0086:\n\tv240 = 0x115C1AC(v229, v224, *([v235 @ X8_v10 (Il2CppMethodInfo)]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008F:\n\treturn 0;\n\tthrow System.NullReferenceException;\n\tv102 = new System.NullReferenceException();\nL_0093:\n\tv130 = new System.IndexOutOfRangeException();\n\tthrow v130;\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private OGActionType? GetSelectedOGActionType()
		{
			//IL_0043: Expected O, but got I4
			//IL_004c: Expected I4, but got O
			string[] array = actionTypeStrings;
			int num = selectedAction;
			if (selectedAction < array.Length)
			{
				object obj = 0;
				object obj2 = (OGActionType)obj;
				array = (string[])obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v44[40] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string text = default(string);
				OGActionType? oGActionType = default(OGActionType?);
				if (array[num] == text)
				{
					int num2 = 0;
					object obj3 = oGActionType;
					IntPtr intPtr = (IntPtr)0;
				}
				else
				{
					int num3 = 1;
					object obj4 = (OGActionType)num3;
					array = (string[])obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v44[40] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					string text2 = default(string);
					if (array[num] == text2)
					{
						int num2 = 1;
						object obj3 = oGActionType;
						IntPtr intPtr = (IntPtr)0;
					}
					else
					{
						int num4 = 2;
						object obj5 = (OGActionType)num4;
						array = (string[])obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v44[40] (should have been resolved before IL gen)");
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						string text3 = default(string);
						bool flag = array[num] == text3;
						bool flag2 = !flag;
						oGActionType = null;
						if (flag2)
						{
							goto IL_0200;
						}
						int num2 = 2;
						object obj3 = oGActionType;
						IntPtr intPtr = (IntPtr)0;
					}
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115C1AC (inside System.Nullable`1<System.Int32>::Unbox +0xA8)");
				goto IL_0200;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_0200:
			return null;
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0xA07588", Offset = "0xA07588", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EAF310]);\n\tv25 = *([v24 @ X8_v37]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021C98]) = v44;\nL_001D:\n\tthis.requestMessage = v50.Empty;\n\tthis.requestTo = v52.Empty;\n\tthis.requestFilter = v54.Empty;\n\tthis.requestExcludes = v56.Empty;\n\tthis.requestMax = v58.Empty;\n\tthis.requestData = v60.Empty;\n\tthis.requestTitle = v62.Empty;\n\tthis.requestObjectID = v64.Empty;\n\t// 54 NewArr v69 @ X0_v3 (System.String[]), typeof(System.String[]), 4\n\tv75 = \"NONE\" == 0;\n\tif (v75) goto L_0044;\n\t// 65 IsInst v147 @ X0_v42, typeof(System.String), \"NONE\"\nL_0044:\n\tv64 = v69.Length;\n\tv154 = v69.Length == 0;\n\tif (v154) goto L_00CF;\n\tv69[0] = \"NONE\";\n\tv120 = 0;\n\t// 78 Box v133 @ X0_v15, typeof(Facebook.Unity.OGActionType), &v120 @ stack_-34_v6\n\tv64 = *([v133 @ X0_v15]);\n\t*([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+160])(v257, v133, *([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv259 = \"il2cpp_vm_object_unbox\"(v133, *([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv261 = v257 == 0;\n\tif (v261) goto L_0064;\n\t// 97 IsInst v221 @ X0_v41, typeof(System.String), v257 @ X0_v17\nL_0064:\n\tv64 = v69.Length;\n\tv295 = v69.Length < 1;\n\tv110 = ~v295;\n\tv106 = v69.Length - 1;\n\tv98 = v106 == 0;\n\tv296 = ~v110;\n\tv78 = v296 | v98;\n\tif (v78) goto L_00CF;\n\tv69[1] = v257;\n\tv142 = 1;\n\t// 118 Box v134 @ X0_v22, typeof(Facebook.Unity.OGActionType), &v142 @ X8_v21 (System.Int32)\n\tv64 = *([v134 @ X0_v22]);\n\t*([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+160])(v301, v134, *([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv303 = \"il2cpp_vm_object_unbox\"(v134, *([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv305 = v301 == 0;\n\tif (v305) goto L_008C;\n\t// 137 IsInst v222 @ X0_v39, typeof(System.String), v301 @ X0_v24\nL_008C:\n\tv64 = v69.Length;\n\tv308 = v69.Length < 2;\n\tv111 = ~v308;\n\tv107 = v69.Length - 2;\n\tv99 = v107 == 0;\n\tv309 = ~v111;\n\tv79 = v309 | v99;\n\tif (v79) goto L_00CF;\n\tv69[2] = v301;\n\tv143 = 2;\n\t// 158 Box v135 @ X0_v29, typeof(Facebook.Unity.OGActionType), &v143 @ X8_v26 (System.Int32)\n\tv64 = *([v135 @ X0_v29]);\n\t*([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+160])(v314, v135, *([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv316 = \"il2cpp_vm_object_unbox\"(v135, *([v64 @ X8_v6 (Il2CppStaticFields<System.String>)+168]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv318 = v314 == 0;\n\tif (v318) goto L_00B5;\n\t// 177 IsInst v223 @ X0_v37, typeof(System.String), v314 @ X0_v31\nL_00B5:\n\tv321 = v69.Length < 3;\n\tv172 = ~v321;\n\tv170 = v69.Length - 3;\n\tv166 = v170 == 0;\n\tv322 = ~v172;\n\tv156 = v322 | v166;\n\tif (v156) goto L_00CF;\n\tv69[3] = v314;\n\tthis.actionTypeStrings = v69;\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n\tv144 = new System.NullReferenceException();\nL_00CF:\n\tv199 = new System.IndexOutOfRangeException();\n\tgoto L_00D4;\n\tv232 = new System.ArrayTypeMismatchException();\nL_00D4:\n\tthrow v248;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppRequests()
		{
			//IL_0081: Expected O, but got I4
			//IL_008a: Expected I4, but got O
			//IL_009b: Expected I, but got O
			//IL_0119: Expected O, but got I4
			//IL_0183: Expected I, but got O
			//IL_0201: Expected O, but got I4
			//IL_026b: Expected I, but got O
			//IL_02e1: Expected O, but got I4
			base._002Ector();
			requestMessage = string.Empty;
			requestTo = string.Empty;
			requestFilter = string.Empty;
			requestExcludes = string.Empty;
			requestMax = string.Empty;
			requestData = string.Empty;
			requestTitle = string.Empty;
			requestObjectID = string.Empty;
			string[] array = new string[4];
			if ("NONE" != null)
			{
				object obj = "NONE" as string;
			}
			IntPtr intPtr = (IntPtr)array.Length;
			if (array.Length != 0)
			{
				array[0] = "NONE";
				object obj2 = 0;
				object obj3 = (OGActionType)obj2;
				intPtr = (IntPtr)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ X8_v6 (Il2CppStaticFields<System.String>)+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object obj4 = default(object);
				if (obj4 != null)
				{
					object obj5 = obj4 as string;
				}
				intPtr = (IntPtr)array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj6 = array.Length - 1;
				bool flag3 = obj6 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = (string)obj4;
					int num = 1;
					object obj7 = (OGActionType)num;
					intPtr = (IntPtr)obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ X8_v6 (Il2CppStaticFields<System.String>)+160] (should have been resolved before IL gen)");
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj8 = default(object);
					if (obj8 != null)
					{
						object obj9 = obj8 as string;
					}
					intPtr = (IntPtr)array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj10 = array.Length - 2;
					bool flag7 = obj10 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = (string)obj8;
						int num2 = 2;
						object obj11 = (OGActionType)num2;
						intPtr = (IntPtr)obj11;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v64 @ X8_v6 (Il2CppStaticFields<System.String>)+160] (should have been resolved before IL gen)");
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						object obj12 = default(object);
						if (obj12 != null)
						{
							object obj13 = obj12 as string;
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj14 = array.Length - 3;
						bool flag11 = obj14 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = (string)obj12;
							actionTypeStrings = array;
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
