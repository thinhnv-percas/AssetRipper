using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x2000056")]
	internal class ConsoleBase : MonoBehaviour
	{
		[Token(Token = "0x4000262")]
		private const int DpiScalingFactor = 160;

		[Token(Token = "0x4000263")]
		internal static Stack<string> menuStack;

		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x18")]
		internal string status;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x20")]
		internal string lastResponse;

		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x28")]
		internal Vector2 scrollPosition;

		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x30")]
		private float? scaleFactor;

		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x38")]
		private GUIStyle textStyle;

		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x40")]
		private GUIStyle buttonStyle;

		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x48")]
		private GUIStyle textInputStyle;

		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x50")]
		private GUIStyle labelStyle;

		[Token(Token = "0x17000046")]
		protected static int ButtonHeight
		{
			[Token(Token = "0x6000259")]
			[Address(RVA = "0xA07350", Offset = "0xA07350", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = Facebook.Unity.Constants::get_IsMobile();\n\tv10 = v7 == 0;\n\tv15 = ~v10;\n\tv16 = ~v15;\n\tif (v16) goto L_FFFFFFFF;\n\tgoto L_0017;\nL_0017:\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Constants.IsMobile)
				{
					return 60;
				}
				return 24;
			}
		}

		[Token(Token = "0x17000047")]
		protected static int MainWindowWidth
		{
			[Token(Token = "0x600025A")]
			[Address(RVA = "0xA07378", Offset = "0xA07378", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = Facebook.Unity.Constants::get_IsMobile();\n\tv9 = v7 == 0;\n\tif (v9) goto L_FFFFFFFF;\n\tv11 = UnityEngine.Screen::get_width();\n\treturnVal1 = v11 - 0x1E;\n\tgoto L_0011;\nL_0011:\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Constants.IsMobile)
				{
					int width = Screen.width;
					return width - 30;
				}
				return 700;
			}
		}

		[Token(Token = "0x17000048")]
		protected static int MainWindowFullWidth
		{
			[Token(Token = "0x600025B")]
			[Address(RVA = "0xA077F8", Offset = "0xA077F8", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = Facebook.Unity.Constants::get_IsMobile();\n\tv9 = v7 == 0;\n\tif (v9) goto L_0013;\n\treturnVal2 = UnityEngine.Screen::get_width();\n\treturn returnVal2;\nL_0013:\n\treturn 0x2F8;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Constants.IsMobile)
				{
					return Screen.width;
				}
				return 760;
			}
		}

		[Token(Token = "0x17000049")]
		protected static int MarginFix
		{
			[Token(Token = "0x600025C")]
			[Address(RVA = "0xA07824", Offset = "0xA07824", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = Facebook.Unity.Constants::get_IsMobile();\n\tv10 = v7 == 0;\n\tv14 = ~v10;\n\tv15 = ~v14;\n\tif (v15) goto L_FFFFFFFF;\n\tgoto L_0016;\nL_0016:\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (Constants.IsMobile)
				{
					return 0;
				}
				return 48;
			}
		}

		[Token(Token = "0x1700004A")]
		protected static Stack<string> MenuStack
		{
			[Token(Token = "0x600025D")]
			[Address(RVA = "0xA07848", Offset = "0xA07848", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED4388]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021C99]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Example.ConsoleBase>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.Example.ConsoleBase;\nL_0024:\n\treturn v49.menuStack;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return menuStack;
			}
			[Token(Token = "0x600025E")]
			[Address(RVA = "0xA078B0", Offset = "0xA078B0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF8B20]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C9A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Facebook.Unity.Example.ConsoleBase>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Facebook.Unity.Example.ConsoleBase;\nL_0021:\n\tv52.menuStack = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				menuStack = value;
			}
		}

		[Token(Token = "0x1700004B")]
		protected string Status
		{
			[Token(Token = "0x600025F")]
			[Address(RVA = "0xA0791C", Offset = "0xA0791C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.status;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return status;
			}
			[Token(Token = "0x6000260")]
			[Address(RVA = "0xA07924", Offset = "0xA07924", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.status = value;\n\treturn;\n")]
			set
			{
				status = value;
			}
		}

		[Token(Token = "0x1700004C")]
		[field: Token(Token = "0x400026C")]
		[field: FieldOffset(Offset = "0x58")]
		protected Texture2D LastResponseTexture
		{
			[Token(Token = "0x6000261")]
			[Address(RVA = "0xA0792C", Offset = "0xA0792C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastResponseTexture>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000262")]
			[Address(RVA = "0xA07934", Offset = "0xA07934", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastResponseTexture>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x1700004D")]
		protected string LastResponse
		{
			[Token(Token = "0x6000263")]
			[Address(RVA = "0xA0793C", Offset = "0xA0793C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.lastResponse;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return lastResponse;
			}
			[Token(Token = "0x6000264")]
			[Address(RVA = "0xA07944", Offset = "0xA07944", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lastResponse = value;\n\treturn;\n")]
			set
			{
				lastResponse = value;
			}
		}

		[Token(Token = "0x1700004E")]
		protected Vector2 ScrollPosition
		{
			[Token(Token = "0x6000265")]
			[Address(RVA = "0xA0794C", Offset = "0xA0794C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.scrollPosition;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return scrollPosition;
			}
			[Token(Token = "0x6000266")]
			[Address(RVA = "0xA07954", Offset = "0xA07954", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.scrollPosition = value;\n\tthis.scrollPosition.y = value.y;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				scrollPosition = value;
				scrollPosition.y = value.y;
			}
		}

		[Token(Token = "0x1700004F")]
		protected internal unsafe float ScaleFactor
		{
			[Token(Token = "0x6000267")]
			[Address(RVA = "0xA071D8", Offset = "0xA071D8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EB69C0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C9B]) = v38;\nL_0014:\n\tv40 = this + 0x30;\n\tv41 = *([this @ X0 (Facebook.Unity.Example.ConsoleBase)+34]) == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0029;\n\tv44 = UnityEngine.Screen::get_dpi();\n\treturnVal1 = v44 / 160f;\n\tv48 = 0;\n\tv55 = 0x115CA98(&v48 @ stack_-28_v2, Il2CppMethodInfo, v22, v23, v24, v25, v26, v27, returnVal1, 160f, v30, v31, v32, v33, v34, v35);\n\t*([v40 @ X19_v2 (System.Nullable`1<System.Single>)]) = 0;\nL_0029:\n\tv62 = System.Nullable`1<System.Single>::get_Value(v40);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0050: Expected O, but got I
				//IL_0027: Expected O, but got I4
				//IL_003f: Expected O, but got I4
				float? num = (float?)(object)((long)(IntPtr)this + 48L);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Facebook.Unity.Example.ConsoleBase)+34]");
				float result = default(float);
				if ((IntPtr)0 == (IntPtr)0)
				{
					float dpi = Screen.dpi;
					result = dpi / 160f;
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115CA98 (inside System.Nullable`1<System.Int64>::Unbox +0xA8)");
					num = (float?)(object)0;
				}
				float value = ((float?*)num)->Value;
				return result;
			}
		}

		[Token(Token = "0x17000050")]
		protected int FontSize
		{
			[Token(Token = "0x6000268")]
			[Address(RVA = "0xA0795C", Offset = "0xA0795C", Length = "0xF4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F02AC0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021C9C]) = v42;\nL_0016:\n\tv44 = Facebook.Unity.Example.ConsoleBase::get_ScaleFactor(this);\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v3+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v44, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv60 = v44 * 16f;\n\tv65 = 0x6D1ED0(&v63 @ stack_-38_v1 (System.Double), methodInfo, v26, v27, v28, v29, v30, v31, v60, v33, v34, v35, v36, v37, v38, v39);\n\tv75 = v60 >= 0;\n\tif (v75) goto L_004E;\n\tv86 = v60 != -0.5d;\n\tif (v86) goto L_0060;\n\tgoto L_0053;\nL_004E:\n\tv97 = v60 != 0.5d;\n\tif (v97) goto L_0063;\nL_0053:\n\tv118 = v137 + v106;\n\tv119 = v137 & 1;\n\tv121 = v119 == 0;\n\tv124 = ~v121;\n\tif (v124) goto L_FFFFFFFF;\n\tgoto L_005F;\nL_005F:\n\tgoto L_006D;\nL_0060:\n\tv100 = v60 + -0.5d;\n\tv137 = System.Math::Ceiling(v100);\n\tgoto L_006D;\nL_0063:\n\tv104 = v60 + 0.5d;\n\tv137 = System.Math::Floor(v104);\nL_006D:\n\treturn v137;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0124: Expected I4, but got F8
				//IL_014b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0150: Expected I4, but got Unknown
				float num = ScaleFactor;
				float num2 = num * 16f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1ED0 (native modf)");
				double num3;
				double num4;
				double num5 = default(double);
				if (num2 < 0f)
				{
					if ((double)num2 != -0.5)
					{
						double a = (double)num2 + -0.5;
						num3 = Math.Ceiling(a);
						goto IL_011f;
					}
					num4 = -1.0;
					num3 = num5;
				}
				else
				{
					if ((double)num2 != 0.5)
					{
						double d = (double)num2 + 0.5;
						num3 = Math.Floor(d);
						goto IL_011f;
					}
					num4 = 1.0;
					num3 = num5;
				}
				double num6 = num3 + num4;
				if ((num3 & 1) != 0)
				{
					num3 = num6;
				}
				goto IL_011f;
				IL_011f:
				return (int)num3;
			}
		}

		[Token(Token = "0x17000051")]
		protected internal GUIStyle TextStyle
		{
			[Token(Token = "0x6000269")]
			[Address(RVA = "0xA07A50", Offset = "0xA07A50", Length = "0x174")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EF1D10]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C9D]) = v40;\nL_0014:\n\treturnVal1 = this.textStyle;\n\tv42 = this.textStyle == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_006F;\n\tgoto L_0025;\n\tv75 = *([v46 @ X0_v4+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0025;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv83 = UnityEngine.GUI::get_skin();\n\tv109 = UnityEngine.GUISkin::get_textArea(v83);\n\tv140 = new UnityEngine.GUIStyle();\n\tUnityEngine.GUIStyle::.ctor(v140, v109);\n\tthis.textStyle = v140;\n\tUnityEngine.GUIStyle::set_alignment(v140, 0);\n\tUnityEngine.GUIStyle::set_wordWrap(this.textStyle, 1);\n\tv147 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v147, 0xA, 0xA, 0xA, 0xA);\n\tUnityEngine.GUIStyle::set_padding(this.textStyle, v147);\n\tUnityEngine.GUIStyle::set_stretchHeight(this.textStyle, 1);\n\tUnityEngine.GUIStyle::set_stretchWidth(this.textStyle, 0);\n\tv148 = Facebook.Unity.Example.ConsoleBase::get_FontSize(this);\n\tUnityEngine.GUIStyle::set_fontSize(this.textStyle, v148);\n\treturnVal1 = this.textStyle;\nL_006F:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GUIStyle result = textStyle;
				if (textStyle == null)
				{
					GUISkin skin = GUI.skin;
					GUIStyle textArea = skin.textArea;
					(textStyle = new GUIStyle(textArea)).alignment = default(TextAnchor);
					textStyle.wordWrap = true;
					RectOffset padding = new RectOffset(10, 10, 10, 10);
					textStyle.padding = padding;
					textStyle.stretchHeight = true;
					textStyle.stretchWidth = false;
					int fontSize = FontSize;
					textStyle.fontSize = fontSize;
					result = textStyle;
				}
				return result;
			}
		}

		[Token(Token = "0x17000052")]
		protected internal GUIStyle ButtonStyle
		{
			[Token(Token = "0x600026A")]
			[Address(RVA = "0xA07274", Offset = "0xA07274", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB9BE0]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C9E]) = v40;\nL_0014:\n\treturnVal1 = this.buttonStyle;\n\tv42 = this.buttonStyle == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0044;\n\tgoto L_0025;\n\tv69 = *([v46 @ X0_v4+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0025;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv77 = UnityEngine.GUI::get_skin();\n\tv97 = UnityEngine.GUISkin::get_button(v77);\n\tv102 = new UnityEngine.GUIStyle();\n\tUnityEngine.GUIStyle::.ctor(v102, v97);\n\tthis.buttonStyle = v102;\n\tv105 = Facebook.Unity.Example.ConsoleBase::get_FontSize(this);\n\tUnityEngine.GUIStyle::set_fontSize(v102, v105);\n\treturnVal1 = this.buttonStyle;\nL_0044:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GUIStyle result = buttonStyle;
				if (buttonStyle == null)
				{
					GUISkin skin = GUI.skin;
					GUIStyle button = skin.button;
					GUIStyle gUIStyle = (buttonStyle = new GUIStyle(button));
					int fontSize = FontSize;
					gUIStyle.fontSize = fontSize;
					result = buttonStyle;
				}
				return result;
			}
		}

		[Token(Token = "0x17000053")]
		protected GUIStyle TextInputStyle
		{
			[Token(Token = "0x600026B")]
			[Address(RVA = "0xA07BC4", Offset = "0xA07BC4", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFE308]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C9F]) = v40;\nL_0014:\n\treturnVal1 = this.textInputStyle;\n\tv42 = this.textInputStyle == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0044;\n\tgoto L_0025;\n\tv69 = *([v46 @ X0_v4+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0025;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv77 = UnityEngine.GUI::get_skin();\n\tv97 = UnityEngine.GUISkin::get_textField(v77);\n\tv102 = new UnityEngine.GUIStyle();\n\tUnityEngine.GUIStyle::.ctor(v102, v97);\n\tthis.textInputStyle = v102;\n\tv105 = Facebook.Unity.Example.ConsoleBase::get_FontSize(this);\n\tUnityEngine.GUIStyle::set_fontSize(v102, v105);\n\treturnVal1 = this.textInputStyle;\nL_0044:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GUIStyle result = textInputStyle;
				if (textInputStyle == null)
				{
					GUISkin skin = GUI.skin;
					GUIStyle textField = skin.textField;
					GUIStyle gUIStyle = (textInputStyle = new GUIStyle(textField));
					int fontSize = FontSize;
					gUIStyle.fontSize = fontSize;
					result = textInputStyle;
				}
				return result;
			}
		}

		[Token(Token = "0x17000054")]
		protected internal GUIStyle LabelStyle
		{
			[Token(Token = "0x600026C")]
			[Address(RVA = "0xA070FC", Offset = "0xA070FC", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFDCD0]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021CA0]) = v40;\nL_0014:\n\treturnVal1 = this.labelStyle;\n\tv42 = this.labelStyle == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0044;\n\tgoto L_0025;\n\tv69 = *([v46 @ X0_v4+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0025;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv77 = UnityEngine.GUI::get_skin();\n\tv97 = UnityEngine.GUISkin::get_label(v77);\n\tv102 = new UnityEngine.GUIStyle();\n\tUnityEngine.GUIStyle::.ctor(v102, v97);\n\tthis.labelStyle = v102;\n\tv105 = Facebook.Unity.Example.ConsoleBase::get_FontSize(this);\n\tUnityEngine.GUIStyle::set_fontSize(v102, v105);\n\treturnVal1 = this.labelStyle;\nL_0044:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GUIStyle result = labelStyle;
				if (labelStyle == null)
				{
					GUISkin skin = GUI.skin;
					GUIStyle label = skin.label;
					GUIStyle gUIStyle = (labelStyle = new GUIStyle(label));
					int fontSize = FontSize;
					gUIStyle.fontSize = fontSize;
					result = labelStyle;
				}
				return result;
			}
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0xA07CA0", Offset = "0xA07CA0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Application::set_targetFrameRate(0x3C);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Awake()
		{
			Application.targetFrameRate = 60;
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0xA05EDC", Offset = "0xA05EDC", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EBFE38]);\n\tv27 = *([v26 @ X8_v25]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, label, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2021CA1]) = v45;\nL_0018:\n\tv47 = Facebook.Unity.Example.ConsoleBase::get_ButtonStyle(this);\n\t// 31 NewArr v54 @ X0_v5 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 2\n\tgoto L_002F;\n\tv62 = *([v58 @ X8_v8+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_002F;\n\tv71 = v58;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v71, v51, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_002F:\n\tv70 = Facebook.Unity.Constants::get_IsMobile();\n\tv74 = Facebook.Unity.Example.ConsoleBase::get_ScaleFactor(this);\n\tv79 = v70 == 0;\n\tv84 = ~v79;\n\tv85 = ~v84;\n\tif (v85) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tv89 = v88 * v74;\n\tv90 = UnityEngine.GUILayout::MinHeight(v89);\n\tv93 = v90 == 0;\n\tif (v93) goto L_0051;\n\t// 77 IsInst v135 @ X0_v35, typeof(UnityEngine.GUILayoutOption), v90 @ X0_v11 (UnityEngine.GUILayoutOption)\nL_0051:\n\tv142 = v54.Length == 0;\n\tif (v142) goto L_0087;\n\tv54[0] = v90;\n\tv144 = Facebook.Unity.Constants::get_IsMobile();\n\tv222 = v144 == 0;\n\tif (v222) goto L_FFFFFFFF;\n\tv226 = UnityEngine.Screen::get_width();\n\tv229 = v226 - 0x1E;\n\tgoto L_0061;\nL_0061:\n\tv234 = UnityEngine.GUILayout::MaxWidth(v164);\n\tv235 = v234 == 0;\n\tif (v235) goto L_006C;\n\t// 104 IsInst v214 @ X0_v31, typeof(UnityEngine.GUILayoutOption), v234 @ X0_v26 (UnityEngine.GUILayoutOption)\nL_006C:\n\tv238 = v54.Length < 1;\n\tv158 = ~v238;\n\tv152 = v54.Length - 1;\n\tv160 = v152 == 0;\n\tv239 = ~v158;\n\tv154 = v239 | v160;\n\tif (v154) goto L_0087;\n\tv54[1] = v234;\n\treturnVal2 = UnityEngine.GUILayout::Button(label, v47, v54);\n\treturn returnVal2;\nL_0087:\n\tv175 = new System.IndexOutOfRangeException();\n\tgoto L_008C;\n\tv220 = new System.ArrayTypeMismatchException();\nL_008C:\n\tthrow v224;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal bool Button(string label)
		{
			//IL_0163: Expected O, but got I4
			GUIStyle style = ButtonStyle;
			GUILayoutOption[] array = new GUILayoutOption[2];
			bool isMobile = Constants.IsMobile;
			float num = ScaleFactor;
			float num2 = ((!isMobile) ? 24f : 60f);
			float minHeight = num2 * num;
			GUILayoutOption gUILayoutOption = GUILayout.MinHeight(minHeight);
			if (gUILayoutOption != null)
			{
				object obj = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				float maxWidth;
				if (Constants.IsMobile)
				{
					int width = Screen.width;
					int num3 = width - 30;
					maxWidth = num3;
				}
				else
				{
					maxWidth = 700f;
				}
				GUILayoutOption gUILayoutOption2 = GUILayout.MaxWidth(maxWidth);
				if (gUILayoutOption2 != null)
				{
					object obj2 = gUILayoutOption2 as GUILayoutOption;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj3 = array.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = gUILayoutOption2;
					return GUILayout.Button(label, style, array);
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0xA06EA4", Offset = "0xA06EA4", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EEBE90]);\n\tv33 = *([v32 @ X8_v39]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, label, text, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021CA2]) = v50;\nL_001E:\n\tv55 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0027;\n\tv60 = v55;\n\tv61 = 0x8907BC(v60, label, text, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv64 = *([v55 @ X22_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0027:\n\tv65 = *([v55 @ X22_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv66 = v65 == 0;\n\tif (v66) goto L_0048;\n\tv68 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0034;\n\tv90 = v68;\n\tv91 = 0x8907BC(v90, label, text, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0034:\n\tv92 = *([v68 @ X22_v13 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv78 = ~v92;\n\tif (v78) goto L_0048;\n\tgoto L_0048;\n\tv104 = v83;\n\tv105 = 0x8907BC(v104, label, text, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0048:\n\tgoto L_004E;\n\tv93 = v85;\n\tv94 = 0x8907BC(v93, label, text, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_004E:\n\tUnityEngine.GUILayout::BeginHorizontal(v96.Value);\n\tv103 = Facebook.Unity.Example.ConsoleBase::get_LabelStyle(this);\n\t// 87 NewArr v114 @ X0_v9 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tv117 = Facebook.Unity.Example.ConsoleBase::get_ScaleFactor(this);\n\tv121 = v117 * 200f;\n\tv122 = UnityEngine.GUILayout::MaxWidth(v121);\n\tv125 = v122 == 0;\n\tif (v125) goto L_006C;\n\t// 104 IsInst v156 @ X0_v45, typeof(UnityEngine.GUILayoutOption), v122 @ X0_v12 (UnityEngine.GUILayoutOption)\nL_006C:\n\tv163 = v114.Length == 0;\n\tif (v163) goto L_00BC;\n\tv114[0] = v122;\n\tUnityEngine.GUILayout::Label(label, v103, v114);\n\tv201 = Facebook.Unity.Example.ConsoleBase::get_TextInputStyle(this);\n\t// 123 NewArr v219 @ X0_v27 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tgoto L_008B;\n\tv256 = *([v222 @ X8_v23+E0]);\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_008B;\n\tv264 = v222;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v264, v138, v132, v130, v36, v37, v38, v39, v121, v119, v42, v43, v44, v45, v46, v47);\nL_008B:\n\tv263 = Facebook.Unity.Constants::get_IsMobile();\n\tv266 = v263 == 0;\n\tif (v266) goto L_FFFFFFFF;\n\tv268 = UnityEngine.Screen::get_width();\n\tv271 = v268 - 0xB4;\n\tgoto L_0097;\nL_0097:\n\tv140 = UnityEngine.GUILayout::MaxWidth(v134);\n\tv275 = v140 == 0;\n\tif (v275) goto L_00A4;\n\t// 160 IsInst v191 @ X0_v39, typeof(UnityEngine.GUILayoutOption), v140 @ X0_v33 (UnityEngine.GUILayoutOption)\nL_00A4:\n\tv174 = v219.Length == 0;\n\tif (v174) goto L_00BC;\n\tv219[0] = v140;\n\tv280 = UnityEngine.GUILayout::TextField(*([text @ X2 (System.String&)]), v201, v219);\n\t*([text @ X2 (System.String&)]) = v280;\n\tUnityEngine.GUILayout::EndHorizontal();\n\treturn;\n\tv152 = new System.NullReferenceException();\nL_00BC:\n\tv180 = new System.IndexOutOfRangeException();\n\tgoto L_00C1;\n\tv199 = new System.ArrayTypeMismatchException();\nL_00C1:\n\tthrow v208;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal unsafe void LabelAndTextField(string label, ref string text)
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X22_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X22_v13 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginHorizontal();
			GUIStyle style = LabelStyle;
			GUILayoutOption[] array = new GUILayoutOption[1];
			float num = ScaleFactor;
			float maxWidth = num * 200f;
			GUILayoutOption gUILayoutOption = GUILayout.MaxWidth(maxWidth);
			if (gUILayoutOption != null)
			{
				object obj = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				GUILayout.Label(label, style, array);
				GUIStyle style2 = TextInputStyle;
				GUILayoutOption[] array2 = new GUILayoutOption[1];
				float maxWidth2;
				if (Constants.IsMobile)
				{
					int width = Screen.width;
					int num2 = width - 180;
					maxWidth2 = num2;
				}
				else
				{
					maxWidth2 = 550f;
				}
				GUILayoutOption gUILayoutOption2 = GUILayout.MaxWidth(maxWidth2);
				if (gUILayoutOption2 != null)
				{
					object obj2 = gUILayoutOption2 as GUILayoutOption;
				}
				if (array2.Length != 0)
				{
					array2[0] = gUILayoutOption2;
					string text2 = GUILayout.TextField(text, style2, array2);
					ref string reference = ref *(string*)text2;
					GUILayout.EndHorizontal();
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0xA07CAC", Offset = "0xA07CAC", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Screen::get_orientation();\n\tv10 = v7 - 3;\n\tv12 = v10 == 0;\n\treturn v12;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected bool IsHorizontalLayout()
		{
			ScreenOrientation orientation = Screen.orientation;
			int num = (int)(orientation - 3);
			return num == 0;
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0xA07CCC", Offset = "0xA07CCC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB9868]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, menuClass, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021CA3]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Facebook.Unity.Example.ConsoleBase>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v44, menuClass, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Facebook.Unity.Example.ConsoleBase;\nL_0026:\n\tv59 = System.Object::GetType(this);\n\tv65 = System.Reflection.MemberInfo::get_Name(v59);\n\tSystem.Collections.Generic.Stack`1<System.String>::Push(v55.menuStack, v65);\n\tv95 = System.Reflection.MemberInfo::get_Name(menuClass);\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v95);\n\treturn;\n\tv74 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void SwitchMenu(Type menuClass)
		{
			Type type = GetType();
			string item = type.Name;
			menuStack.Push(item);
			string sceneName = menuClass.Name;
			SceneManager.LoadScene(sceneName);
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0xA07DA0", Offset = "0xA07DA0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDC498]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021CA4]) = v35;\nL_0017:\n\tgoto L_0023;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.Example.ConsoleBase>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Facebook.Unity.Example.ConsoleBase;\nL_0023:\n\tv54 = System.Linq.Enumerable::Any(v50.menuStack);\n\tv57 = v54 == 0;\n\tif (v57) goto L_0045;\n\tgoto L_0039;\n\tv65 = *([v58 @ X0_v6 (Il2CppClass<Facebook.Unity.Example.ConsoleBase>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\t// 47 ConditionalJump @b21, v67 @ TEMP_v14\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v58, v53, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv69 = Facebook.Unity.Example.ConsoleBase;\nL_0039:\n\tv80 = System.Collections.Generic.Stack`1<System.String>::Pop(v72.menuStack);\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(v80);\n\treturn;\nL_0045:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void GoBack()
		{
			if (menuStack.Any())
			{
				string sceneName = menuStack.Pop();
				SceneManager.LoadScene(sceneName);
			}
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0xA07E68", Offset = "0xA07E68", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA3B68]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CA5]) = v38;\nL_0018:\n\tthis.status = \"Ready\";\n\tthis.lastResponse = v45.Empty;\n\tgoto L_002A;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002A;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv61 = UnityEngine.Vector2::get_zero();\n\tthis.scrollPosition = v61;\n\tthis.scrollPosition.y = v61.y;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConsoleBase()
		{
			status = "Ready";
			lastResponse = string.Empty;
			Vector2 vector = (scrollPosition = Vector2.zero);
			scrollPosition.y = vector.y;
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0xA07F04", Offset = "0xA07F04", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EDF750]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021CA6]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Stack`1<System.String>();\n\tSystem.Collections.Generic.Stack`1<System.String>::.ctor(v39);\n\tv47.menuStack = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ConsoleBase()
		{
			Stack<string> stack = new Stack<string>();
			menuStack = stack;
		}
	}
}
