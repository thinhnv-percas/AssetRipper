using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200000E")]
public class TCP2_Demo : MonoBehaviour
{
	[Token(Token = "0x4000047")]
	[FieldOffset(Offset = "0x18")]
	public Material[] AffectedMaterials;

	[Token(Token = "0x4000048")]
	[FieldOffset(Offset = "0x20")]
	public Texture2D[] RampTextures;

	[Token(Token = "0x4000049")]
	[FieldOffset(Offset = "0x28")]
	public GUISkin GuiSkin;

	[Token(Token = "0x400004A")]
	[FieldOffset(Offset = "0x30")]
	public Light DirLight;

	[Token(Token = "0x400004B")]
	[FieldOffset(Offset = "0x38")]
	public GameObject Robot;

	[Token(Token = "0x400004C")]
	[FieldOffset(Offset = "0x40")]
	public GameObject Ethan;

	[Token(Token = "0x400004D")]
	[FieldOffset(Offset = "0x48")]
	private bool mUnityShader;

	[Token(Token = "0x400004E")]
	[FieldOffset(Offset = "0x49")]
	private bool mShaderSpecular;

	[Token(Token = "0x400004F")]
	[FieldOffset(Offset = "0x4A")]
	private bool mShaderBump;

	[Token(Token = "0x4000050")]
	[FieldOffset(Offset = "0x4B")]
	private bool mShaderReflection;

	[Token(Token = "0x4000051")]
	[FieldOffset(Offset = "0x4C")]
	private bool mShaderRim;

	[Token(Token = "0x4000052")]
	[FieldOffset(Offset = "0x4D")]
	private bool mShaderRimOutline;

	[Token(Token = "0x4000053")]
	[FieldOffset(Offset = "0x4E")]
	private bool mShaderOutline;

	[Token(Token = "0x4000054")]
	[FieldOffset(Offset = "0x50")]
	private float mRimMin;

	[Token(Token = "0x4000055")]
	[FieldOffset(Offset = "0x54")]
	private float mRimMax;

	[Token(Token = "0x4000056")]
	[FieldOffset(Offset = "0x58")]
	private bool mRampTextureFlag;

	[Token(Token = "0x4000057")]
	[FieldOffset(Offset = "0x60")]
	private Texture2D mRampTexture;

	[Token(Token = "0x4000058")]
	[FieldOffset(Offset = "0x68")]
	private float mRampSmoothing;

	[Token(Token = "0x4000059")]
	[FieldOffset(Offset = "0x6C")]
	private float mLightRotationX;

	[Token(Token = "0x400005A")]
	[FieldOffset(Offset = "0x70")]
	private float mLightRotationY;

	[Token(Token = "0x400005B")]
	[FieldOffset(Offset = "0x74")]
	private bool mViewRobot;

	[Token(Token = "0x400005C")]
	[FieldOffset(Offset = "0x75")]
	private bool mRobotOutlineNormals;

	[Token(Token = "0x400005D")]
	[FieldOffset(Offset = "0x78")]
	private TCP2_Demo_View DemoView;

	[Token(Token = "0x6000055")]
	[Address(RVA = "0xB0322C", Offset = "0xB0322C", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDEE00]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224CD]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tv44 = this.RampTextures;\n\tthis.DemoView = v43;\n\tv47 = v44.Length == 0;\n\tif (v47) goto L_002B;\n\tthis.mRampTexture = v44[0];\n\tTCP2_Demo::UpdateShader(this);\n\treturn;\n\tv49 = new System.NullReferenceException();\nL_002B:\n\tv60 = new System.IndexOutOfRangeException();\n\tthrow v60;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		TCP2_Demo_View component = GetComponent<TCP2_Demo_View>();
		Texture2D[] rampTextures = RampTextures;
		DemoView = component;
		if (rampTextures.Length != 0)
		{
			mRampTexture = rampTextures[0];
			UpdateShader();
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000056")]
	[Address(RVA = "0xB037BC", Offset = "0xB037BC", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTCP2_Demo::RestoreRimColors(this);\n\tTCP2_Demo::UpdateShader(this);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDestroy()
	{
		RestoreRimColors();
		UpdateShader();
	}

	[Token(Token = "0x6000057")]
	[Address(RVA = "0xB03944", Offset = "0xB03944", Length = "0x213C")]
	private void OnGUI()
	{
		//IL_0035: Expected O, but got I4
		//IL_0048: Expected O, but got I4
		//IL_0072: Expected F4, but got O
		//IL_008d: Expected F4, but got O
		//IL_03ee: Expected O, but got I4
		//IL_0406: Expected O, but got I4
		//IL_042b: Expected F4, but got O
		//IL_0446: Expected F4, but got O
		//IL_0615: Expected O, but got I4
		//IL_062d: Expected O, but got I4
		//IL_0652: Expected F4, but got O
		//IL_066d: Expected F4, but got O
		//IL_09c5: Expected O, but got I4
		//IL_09ea: Expected F4, but got O
		//IL_0a05: Expected F4, but got O
		//IL_16d0: Expected F4, but got O
		GUI.skin = GuiSkin;
		int width = Screen.width;
		int num = width - 310;
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF7C (inside UnityEngine.RangeAttribute::.ctor +0x2A8)");
		Rect screenRect = default(Rect);
		screenRect.x = 0f;
		object obj3 = default(object);
		screenRect.y = (float)obj3;
		screenRect.width = 0f;
		object obj4 = default(object);
		screenRect.height = (float)obj4;
		GUILayout.BeginArea(screenRect);
		IntPtr intPtr = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X20_v3 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X20_v153 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		GUILayout.BeginHorizontal();
		IntPtr intPtr3 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X20_v6 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X20_v151 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		GUILayout.Label("Demo Character:");
		string text = ((!mViewRobot) ? "ButtonOn" : "Button");
		GUIStyle style = text;
		IntPtr intPtr5 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X22_v1 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr6 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X22_v28 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		if (GUILayout.Button("Ethan", style))
		{
			mViewRobot = false;
			Robot.SetActive(value: false);
			Ethan.SetActive(value: true);
			TCP2_Demo_View demoView = DemoView;
			Transform characterTransform = Ethan.transform;
			demoView.CharacterTransform = characterTransform;
		}
		string text2 = ((!mViewRobot) ? "Button" : "ButtonOn");
		GUIStyle style2 = text2;
		IntPtr intPtr7 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v669 @ X22_v4 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v682 @ X22_v21 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		GUILayoutOption[] array = Array.Empty<GUILayoutOption>();
		if (GUILayout.Button("Robot Kyle", style2))
		{
			mViewRobot = true;
			Robot.SetActive(value: true);
			Ethan.SetActive(value: false);
			TCP2_Demo_View demoView2 = DemoView;
			Transform characterTransform2 = Robot.transform;
			demoView2.CharacterTransform = characterTransform2;
			array = null;
		}
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		int width2 = Screen.width;
		int height = Screen.height;
		int num2 = width2 - 310;
		int num3 = height - 130;
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
		obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF7C (inside UnityEngine.RangeAttribute::.ctor +0x2A8)");
		Rect screenRect2 = default(Rect);
		screenRect2.x = 0f;
		screenRect2.y = (float)obj3;
		screenRect2.width = 0f;
		screenRect2.height = (float)obj4;
		GUILayout.BeginArea(screenRect2);
		if (mViewRobot)
		{
			IntPtr intPtr9 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1123 @ X20_v129 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1139 @ X20_v142 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.Label("Outline Normals");
			IntPtr intPtr11 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1193 @ X20_v132 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr12 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ X20_v140 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			bool value = !mRobotOutlineNormals;
			bool flag = GUILayout.Toggle(value, "Regular Normals");
			int num4 = (flag ? 1 : 0) ^ 1;
			int num5 = num4 & 1;
			mRobotOutlineNormals = (byte)num5 != 0;
			IntPtr intPtr13 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1272 @ X20_v135 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr14 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1322 @ X20_v138 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					bool flag2 = default(bool);
					flag = flag2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B178C0 (inside Tayx.Graphy.Ram.G_RamGraph::.ctor +0x14)");
			return;
		}
		GUILayout.EndArea();
		int width3 = Screen.width;
		int height2 = Screen.height;
		int num6 = width3 - 210;
		int num7 = height2 - 60;
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
		obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF7C (inside UnityEngine.RangeAttribute::.ctor +0x2A8)");
		Rect screenRect3 = default(Rect);
		screenRect3.x = 0f;
		screenRect3.y = (float)obj3;
		screenRect3.width = 0f;
		screenRect3.height = (float)obj4;
		GUILayout.BeginArea(screenRect3);
		IntPtr intPtr15 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1243 @ X20_v15 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr16 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1278 @ X20_v127 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		GUILayout.Label("Quality Settings:");
		IntPtr intPtr17 = (IntPtr)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1347 @ X20_v18 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
		if (0u != 0)
		{
			IntPtr intPtr18 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1373 @ X20_v125 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
		}
		GUILayout.BeginHorizontal();
		GUILayoutOption[] array2 = new GUILayoutOption[1];
		GUILayoutOption gUILayoutOption = GUILayout.Width(26f);
		if (gUILayoutOption != null)
		{
			object obj5 = gUILayoutOption as GUILayoutOption;
		}
		if (array2.Length != 0)
		{
			array2[0] = gUILayoutOption;
			if (GUILayout.Button("<", array2))
			{
				QualitySettings.DecreaseLevel(applyExpensiveChanges: true);
			}
			string[] names = QualitySettings.names;
			int qualityLevel = QualitySettings.GetQualityLevel();
			if (qualityLevel < names.Length)
			{
				GUIStyle style3 = "LabelCenter";
				IntPtr intPtr19 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1507 @ X22_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr20 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1520 @ X22_v17 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.Label(names[qualityLevel], style3);
				GUILayoutOption[] array3 = new GUILayoutOption[1];
				GUILayoutOption gUILayoutOption2 = GUILayout.Width(26f);
				if (gUILayoutOption2 != null)
				{
					object obj6 = gUILayoutOption2 as GUILayoutOption;
				}
				if (array3.Length != 0)
				{
					array3[0] = gUILayoutOption2;
					if (GUILayout.Button(">", array3))
					{
						QualitySettings.IncreaseLevel(applyExpensiveChanges: true);
					}
					GUILayout.EndHorizontal();
					GUILayout.EndArea();
					int width4 = Screen.width;
					int height3 = Screen.height;
					int num8 = width4 - 40;
					int num9 = height3 - 40;
					obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
					Rect screenRect4 = default(Rect);
					screenRect4.x = 0f;
					object obj7 = default(object);
					screenRect4.y = (float)obj7;
					screenRect4.width = 0f;
					object obj8 = default(object);
					screenRect4.height = (float)obj8;
					GUILayout.BeginArea(screenRect4);
					string text3 = ((!mViewRobot) ? "\"Bumped Specular\"" : "\"Diffuse Specular\"");
					string text4 = "View with Unity " + text3;
					IntPtr intPtr21 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1619 @ X21_v13 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr22 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1632 @ X21_v68 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					bool flag3 = !mUnityShader;
					bool value2 = !flag3;
					bool flag4 = GUILayout.Toggle(value2, text4);
					mUnityShader = flag4;
					GUILayout.Space(10f);
					bool flag5 = !mUnityShader;
					GUI.enabled = flag5;
					IntPtr intPtr23 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1711 @ X20_v29 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr24 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1724 @ X20_v123 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					GUILayout.Label("Toony Colors Pro 2 Settings");
					IntPtr intPtr25 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1764 @ X20_v32 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr26 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1781 @ X20_v121 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					bool flag6 = !mShaderSpecular;
					bool value3 = !flag6;
					bool flag7 = GUILayout.Toggle(value3, "Specular");
					mShaderSpecular = flag7;
					bool flag8 = !mViewRobot;
					GUI.enabled = flag8;
					if (GUI.enabled)
					{
						IntPtr intPtr27 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1854 @ X20_v116 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
						if (0u != 0)
						{
							IntPtr intPtr28 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1881 @ X20_v119 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
							if ((IntPtr)0 != (IntPtr)0)
							{
							}
						}
						bool flag9 = !mShaderBump;
						bool value4 = !flag9;
						bool flag10 = GUILayout.Toggle(value4, "Bump");
						mShaderBump = flag10;
					}
					else
					{
						IntPtr intPtr29 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1861 @ X20_v111 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
						if (0u != 0)
						{
							IntPtr intPtr30 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1904 @ X20_v114 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
							if ((IntPtr)0 != (IntPtr)0)
							{
							}
						}
						bool flag11 = GUILayout.Toggle(false, "Bump");
					}
					bool flag12 = !mUnityShader;
					GUI.enabled = flag12;
					IntPtr intPtr31 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2024 @ X20_v37 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr32 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2037 @ X20_v109 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					bool flag13 = !mShaderReflection;
					bool value5 = !flag13;
					bool flag14 = GUILayout.Toggle(value5, "Reflection");
					mShaderReflection = flag14;
					IntPtr intPtr33 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2090 @ X20_v40 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr34 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2107 @ X20_v107 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					bool flag15 = !mShaderRim;
					bool flag16 = !flag15;
					bool flag17 = (mShaderRim = GUILayout.Toggle(flag16, "Rim Lighting"));
					bool flag18 = flag16 ^ flag17;
					if (flag17 && flag18 && mShaderRimOutline)
					{
						mShaderRimOutline = false;
					}
					if (flag18 && flag17)
					{
						RestoreRimColors();
					}
					IntPtr intPtr35 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2178 @ X20_v44 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr36 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2191 @ X20_v105 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					bool flag19 = !mShaderRimOutline;
					bool flag20 = !flag19;
					bool flag21 = (mShaderRimOutline = GUILayout.Toggle(flag20, "Rim Outline"));
					bool flag22 = flag20 ^ flag21;
					if (flag21 && flag22 && mShaderRim)
					{
						mShaderRim = false;
					}
					if (flag22 && flag21)
					{
						RimOutlineColor();
					}
					bool flag23 = GUI.enabled;
					int num10 = ((mShaderRim || mShaderRimOutline) ? 1 : 0);
					int num11 = num10 & (flag23 ? 1 : 0);
					bool flag24 = (byte)(num11 & 1) != 0;
					GUI.enabled = flag24;
					IntPtr intPtr37 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2283 @ X20_v49 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr38 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2296 @ X20_v103 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					GUILayout.BeginHorizontal();
					GUILayoutOption[] array4 = new GUILayoutOption[1];
					GUILayoutOption gUILayoutOption3 = GUILayout.Width(70f);
					if (gUILayoutOption3 != null)
					{
						object obj9 = gUILayoutOption3 as GUILayoutOption;
					}
					if (array4.Length != 0)
					{
						array4[0] = gUILayoutOption3;
						GUILayout.Label("Rim Min", array4);
						GUILayoutOption[] array5 = new GUILayoutOption[1];
						GUILayoutOption gUILayoutOption4 = GUILayout.Width(130f);
						if (gUILayoutOption4 != null)
						{
							object obj10 = gUILayoutOption4 as GUILayoutOption;
						}
						if (array5.Length != 0)
						{
							array5[0] = gUILayoutOption4;
							float num12 = GUILayout.HorizontalSlider(mRimMin, 0f, 1f, array5);
							mRimMin = num12;
							GUILayout.EndHorizontal();
							IntPtr intPtr39 = (IntPtr)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2359 @ X20_v54 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
							if (0u != 0)
							{
								IntPtr intPtr40 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2372 @ X20_v101 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
								if ((IntPtr)0 != (IntPtr)0)
								{
								}
							}
							GUILayout.BeginHorizontal();
							GUILayoutOption[] array6 = new GUILayoutOption[1];
							GUILayoutOption gUILayoutOption5 = GUILayout.Width(70f);
							if (gUILayoutOption5 != null)
							{
								object obj11 = gUILayoutOption5 as GUILayoutOption;
							}
							if (array6.Length != 0)
							{
								array6[0] = gUILayoutOption5;
								GUILayout.Label("Rim Max", array6);
								GUILayoutOption[] array7 = new GUILayoutOption[1];
								GUILayoutOption gUILayoutOption6 = GUILayout.Width(130f);
								if (gUILayoutOption6 != null)
								{
									object obj12 = gUILayoutOption6 as GUILayoutOption;
								}
								if (array7.Length != 0)
								{
									array7[0] = gUILayoutOption6;
									num12 = GUILayout.HorizontalSlider(mRimMax, 0f, 1f, array7);
									mRimMax = num12;
									GUILayout.EndHorizontal();
									bool flag25 = !mUnityShader;
									GUI.enabled = flag25;
									IntPtr intPtr41 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2446 @ X20_v59 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
									if (0u != 0)
									{
										IntPtr intPtr42 = (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X20_v99 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
										if ((IntPtr)0 != (IntPtr)0)
										{
										}
									}
									bool flag26 = !mShaderOutline;
									bool value6 = !flag26;
									bool flag27 = GUILayout.Toggle(value6, "Outline");
									mShaderOutline = flag27;
									GUILayout.Space(6f);
									IntPtr intPtr43 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2516 @ X20_v62 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
									if (0u != 0)
									{
										IntPtr intPtr44 = (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2529 @ X20_v97 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
										if ((IntPtr)0 != (IntPtr)0)
										{
										}
									}
									GUILayout.Label("Ramp Settings");
									IntPtr intPtr45 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2568 @ X20_v65 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
									if (0u != 0)
									{
										IntPtr intPtr46 = (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2585 @ X20_v95 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
										if ((IntPtr)0 != (IntPtr)0)
										{
										}
									}
									bool flag28 = !mRampTextureFlag;
									bool value7 = !flag28;
									bool flag29 = GUILayout.Toggle(value7, "Textured Ramp");
									mRampTextureFlag = flag29;
									bool flag30 = GUI.enabled;
									bool flag31 = !mRampTextureFlag;
									bool flag32 = !flag31;
									bool flag33 = flag30 && flag32;
									GUI.enabled = flag33;
									IntPtr intPtr47 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2645 @ X20_v68 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
									if (0u != 0)
									{
										IntPtr intPtr48 = (IntPtr)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2658 @ X20_v93 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
										if ((IntPtr)0 != (IntPtr)0)
										{
										}
									}
									GUILayout.BeginHorizontal();
									GUILayoutOption[] array8 = new GUILayoutOption[1];
									GUILayoutOption gUILayoutOption7 = GUILayout.ExpandWidth(expand: false);
									if (gUILayoutOption7 != null)
									{
										object obj13 = gUILayoutOption7 as GUILayoutOption;
									}
									if (array8.Length != 0)
									{
										array8[0] = gUILayoutOption7;
										Rect rect = GUILayoutUtility.GetRect(200f, 20f, array8);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
										num12 = rect.x + 4f;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCFCC (inside UnityEngine.Rect::MinMaxRect +0x30)");
										Rect position = default(Rect);
										object obj14 = default(object);
										position.x = (float)obj14;
										position.y = rect.y;
										position.width = rect.width;
										position.height = rect.height;
										GUI.DrawTexture(position, mRampTexture);
										GUILayoutOption[] array9 = new GUILayoutOption[1];
										GUILayoutOption gUILayoutOption8 = GUILayout.Width(26f);
										if (gUILayoutOption8 != null)
										{
											object obj15 = gUILayoutOption8 as GUILayoutOption;
										}
										if (array9.Length != 0)
										{
											array9[0] = gUILayoutOption8;
											if (GUILayout.Button("<", array9))
											{
												PrevRamp();
											}
											GUILayoutOption[] array10 = new GUILayoutOption[1];
											GUILayoutOption gUILayoutOption9 = GUILayout.Width(26f);
											if (gUILayoutOption9 != null)
											{
												object obj16 = gUILayoutOption9 as GUILayoutOption;
											}
											if (array10.Length != 0)
											{
												array10[0] = gUILayoutOption9;
												if (GUILayout.Button(">", array10))
												{
													NextRamp();
												}
												GUILayout.EndHorizontal();
												bool flag34 = !mUnityShader;
												GUI.enabled = flag34;
												bool flag35 = GUI.enabled;
												bool flag36 = !mRampTextureFlag;
												bool flag37 = flag35 && flag36;
												GUI.enabled = flag37;
												IntPtr intPtr49 = (IntPtr)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2797 @ X20_v75 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
												if (0u != 0)
												{
													IntPtr intPtr50 = (IntPtr)0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2810 @ X20_v91 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
													if ((IntPtr)0 != (IntPtr)0)
													{
													}
												}
												GUILayout.BeginHorizontal();
												GUILayoutOption[] array11 = new GUILayoutOption[1];
												GUILayoutOption gUILayoutOption10 = GUILayout.Width(85f);
												if (gUILayoutOption10 != null)
												{
													object obj17 = gUILayoutOption10 as GUILayoutOption;
												}
												if (array11.Length != 0)
												{
													array11[0] = gUILayoutOption10;
													GUILayout.Label("Smoothing", array11);
													GUILayoutOption[] array12 = new GUILayoutOption[1];
													GUILayoutOption gUILayoutOption11 = GUILayout.Width(115f);
													if (gUILayoutOption11 != null)
													{
														object obj18 = gUILayoutOption11 as GUILayoutOption;
													}
													if (array12.Length != 0)
													{
														array12[0] = gUILayoutOption11;
														num12 = GUILayout.HorizontalSlider(mRampSmoothing, 0.01f, 1f, array12);
														mRampSmoothing = num12;
														GUILayout.EndHorizontal();
														if (GUI.changed)
														{
															if (mUnityShader)
															{
																UnityDiffuseShader();
															}
															else
															{
																UpdateShader();
															}
														}
														GUI.enabled = true;
														GUILayout.Space(10f);
														IntPtr intPtr51 = (IntPtr)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2900 @ X20_v80 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
														if (0u != 0)
														{
															IntPtr intPtr52 = (IntPtr)0;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2913 @ X20_v89 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
															if ((IntPtr)0 != (IntPtr)0)
															{
															}
														}
														GUILayout.Label("Light Rotation");
														GUILayoutOption[] array13 = new GUILayoutOption[1];
														GUILayoutOption gUILayoutOption12 = GUILayout.Width(200f);
														if (gUILayoutOption12 != null)
														{
															object obj19 = gUILayoutOption12 as GUILayoutOption;
														}
														if (array13.Length != 0)
														{
															array13[0] = gUILayoutOption12;
															num12 = GUILayout.HorizontalSlider(mLightRotationX, 0f, 360f, array13);
															mLightRotationX = num12;
															GUILayoutOption[] array14 = new GUILayoutOption[1];
															GUILayoutOption gUILayoutOption13 = GUILayout.Width(200f);
															if (gUILayoutOption13 != null)
															{
																object obj20 = gUILayoutOption13 as GUILayoutOption;
															}
															if (array14.Length != 0)
															{
																array14[0] = gUILayoutOption13;
																num12 = GUILayout.HorizontalSlider(mLightRotationY, 0f, 360f, array14);
																mLightRotationY = num12;
																GUILayout.Space(4f);
																GUIStyle style4 = "SmallLabelShadow";
																IntPtr intPtr53 = (IntPtr)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2996 @ X21_v42 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
																if (0u != 0)
																{
																	IntPtr intPtr54 = (IntPtr)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3009 @ X21_v62 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
																	if ((IntPtr)0 != (IntPtr)0)
																	{
																	}
																}
																GUILayout.Label("Hold Left mouse button to rotate character", style4);
																Rect lastRect = GUILayoutUtility.GetLastRect();
																GUIStyle style5 = "SmallLabel";
																GUI.Label(lastRect, "Hold Left mouse button to rotate character", style5);
																GUIStyle style6 = "SmallLabelShadow";
																IntPtr intPtr55 = (IntPtr)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3092 @ X21_v47 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
																if (0u != 0)
																{
																	IntPtr intPtr56 = (IntPtr)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3105 @ X21_v60 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
																	if ((IntPtr)0 != (IntPtr)0)
																	{
																	}
																}
																GUILayout.Label("Hold Right/Middle mouse button to scroll", style6);
																Rect lastRect2 = GUILayoutUtility.GetLastRect();
																GUIStyle style7 = "SmallLabel";
																GUI.Label(lastRect2, "Hold Right/Middle mouse button to scroll", style7);
																GUIStyle style8 = "SmallLabelShadow";
																IntPtr intPtr57 = (IntPtr)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3175 @ X21_v52 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
																if (0u != 0)
																{
																	IntPtr intPtr58 = (IntPtr)0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3188 @ X21_v58 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
																	if ((IntPtr)0 != (IntPtr)0)
																	{
																	}
																}
																GUILayout.Label("Use mouse scroll wheel or up/down keys to zoom", style8);
																Rect lastRect3 = GUILayoutUtility.GetLastRect();
																GUIStyle style9 = "SmallLabel";
																GUI.Label(lastRect3, "Use mouse scroll wheel or up/down keys to zoom", style9);
																if (GUI.changed)
																{
																	Transform transform = DirLight.transform;
																	Vector3 eulerAngles = transform.eulerAngles;
																	Transform transform2 = DirLight.transform;
																	Vector3 eulerAngles2 = default(Vector3);
																	eulerAngles2.x = mLightRotationY;
																	eulerAngles2.y = mLightRotationX;
																	eulerAngles2.z = eulerAngles.z;
																	transform2.eulerAngles = eulerAngles2;
																}
																GUILayout.EndArea();
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
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000058")]
	[Address(RVA = "0xB05D18", Offset = "0xB05D18", Length = "0x11C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EB4E78]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20224CF]) = v46;\nL_001B:\n\tv51 = UnityEngine.Shader::Find(\"Bumped Specular\");\n\tv58 = UnityEngine.Shader::Find(\"Specular\");\n\tv59 = this.AffectedMaterials;\n\tv125 = v59.Length;\n\tv73 = v59.Length < 1;\n\tif (v73) goto L_006F;\nL_0037:\n\tv201 = v85 < v125;\n\tv113 = ~v201;\n\tif (v113) goto L_0070;\n\tv188 = UnityEngine.Object::get_name(v59[v85 @ X23_v6 (System.Int32)]);\n\tv229 = System.String::Contains(v188, \"Robot\");\n\tv160 = v229 == 0;\n\tif (v160) goto L_FFFFFFFF;\n\tgoto L_0057;\nL_0057:\n\tUnityEngine.Material::set_shader(v158, v156);\n\tv125 = v59.Length;\n\tv85 = v85 + 1;\n\tv138 = v85 < v59.Length;\n\tif (v138) goto L_0037;\nL_006F:\n\treturn;\nL_0070:\n\tv225 = new System.IndexOutOfRangeException();\n\tthrow v225;\n\tthrow System.NullReferenceException;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UnityDiffuseShader()
	{
		Shader shader = Shader.Find("Bumped Specular");
		Shader shader2 = Shader.Find("Specular");
		Material[] affectedMaterials = AffectedMaterials;
		int num = affectedMaterials.Length;
		if (affectedMaterials.Length < 1)
		{
			return;
		}
		int num2 = 0;
		while (num2 < num)
		{
			string text = affectedMaterials[num2].name;
			Shader shader3;
			Material material;
			if (text.Contains("Robot"))
			{
				shader3 = shader2;
				material = affectedMaterials[num2];
			}
			else
			{
				shader3 = shader;
				material = affectedMaterials[num2];
			}
			material.shader = shader3;
			num = affectedMaterials.Length;
			num2++;
			if (num2 >= affectedMaterials.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000059")]
	[Address(RVA = "0xB032B8", Offset = "0xB032B8", Length = "0x504")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EEDDF8]);\n\tv35 = *([v34 @ X8_v74]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20224D0]) = v54;\nL_001B:\n\tv55 = v52.AffectedMaterials;\n\tv68 = v55.Length < 1;\n\tif (v68) goto L_00AE;\nL_004A:\n\tTCP2_Demo::ToggleKeyword(v209, v55[v111 @ X22_v10 (System.Int32)], v52.mShaderSpecular, \"TCP2_SPEC\");\n\tv294 = UnityEngine.Object::get_name(v55[v111 @ X22_v10 (System.Int32)]);\n\tv602 = System.String::Contains(v294, \"Robot\");\n\tv607 = v602 == 0;\n\tv608 = ~v607;\n\tif (v608) goto L_0064;\n\tTCP2_Demo::ToggleKeyword(v602, v55[v111 @ X22_v10 (System.Int32)], v52.mShaderBump, \"TCP2_BUMP\");\nL_0064:\n\tTCP2_Demo::ToggleKeyword(v602, v55[v111 @ X22_v10 (System.Int32)], v52.mShaderReflection, \"TCP2_REFLECTION_MASKED\");\n\tTCP2_Demo::ToggleKeyword(v602, v55[v111 @ X22_v10 (System.Int32)], v52.mShaderRim, \"TCP2_RIM\");\n\tTCP2_Demo::ToggleKeyword(v602, v55[v111 @ X22_v10 (System.Int32)], v52.mShaderRimOutline, \"TCP2_RIMO\");\n\tTCP2_Demo::ToggleKeyword(v602, v55[v111 @ X22_v10 (System.Int32)], v52.mShaderOutline, \"OUTLINES\");\n\tTCP2_Demo::ToggleKeyword(v602, v55[v111 @ X22_v10 (System.Int32)], v52.mRampTextureFlag, \"TCP2_RAMPTEXT\");\n\tUnityEngine.Material::SetFloat(v55[v111 @ X22_v10 (System.Int32)], \"_RampSmooth\", v52.mRampSmoothing);\n\tUnityEngine.Material::SetTexture(v55[v111 @ X22_v10 (System.Int32)], \"_Ramp\", v52.mRampTexture);\n\tUnityEngine.Material::SetFloat(v55[v111 @ X22_v10 (System.Int32)], \"_RimMin\", v52.mRimMin);\n\tUnityEngine.Material::SetFloat(v55[v111 @ X22_v10 (System.Int32)], \"_RimMax\", v52.mRimMax);\n\tv295 = UnityEngine.Object::get_name(v55[v111 @ X22_v10 (System.Int32)]);\n\tv258 = System.String::Contains(v295, \"Robot\");\n\tv260 = v258 == 0;\n\tif (v260) goto L_00A1;\n\tTCP2_Demo::ToggleKeyword(v258, v55[v111 @ X22_v10 (System.Int32)], v52.mRobotOutlineNormals, \"TCP2_TANGENT_AS_NORMALS\");\nL_00A1:\n\tv111 = v111 + 1;\n\tv249 = v111 < v55.Length;\n\tif (v249) goto L_004A;\nL_00AE:\n\tv112 = v52.AffectedMaterials;\n\tv341 = v112.Length < 1;\n\tif (v341) goto L_01F2;\nL_00D8:\n\tgoto L_00DF;\n\tv591 = *([v586 @ X0_v15+E0]);\n\tv592 = v591 == 0;\n\tv593 = ~v592;\n\tif (v593) goto L_00DF;\n\tv595 = \"il2cpp_codegen_runtime_class_init\"(v586, v425, v435, v87, v40, v41, v42, v43, v76, v45, v46, v47, v48, v49, v50, v51);\nL_00DF:\n\tv599 = TCP2_RuntimeUtils::GetShaderWithKeywords(v112[v138 @ X23_v10 (System.Int32)]);\n\tgoto L_00EF;\n\tv609 = *([v227 @ X8_v15+E0]);\n\tv610 = v609 == 0;\n\tv611 = ~v610;\n\tif (v611) goto L_00EF;\n\tv630 = v227;\n\tv613 = \"il2cpp_codegen_runtime_class_init\"(v630, v425, v435, v87, v40, v41, v42, v43, v76, v45, v46, v47, v48, v49, v50, v51);\nL_00EF:\n\tv211 = UnityEngine.Object::op_Equality(v599, 0);\n\tv632 = v211 == 0;\n\tif (v632) goto L_01D6;\n\tv296 = UnityEngine.Material::get_shaderKeywords(v112[v138 @ X23_v10 (System.Int32)]);\n\tv684 = v296.Length < 1;\n\tif (v684) goto L_0130;\nL_011C:\n\tv706 = System.String::Concat(v506, v296[v448 @ X25_v13 (System.Int32)], \",\");\n\tv448 = v448 + 1;\n\tv696 = v448 < v296.Length;\n\tif (v696) goto L_011C;\nL_0130:\n\t// 304 NewArr v212 @ X0_v28 (System.Char[]), typeof(System.Char[]), 1\n\tv212[0] = 0x2C;\n\tv738 = System.String::TrimEnd(v234, v212);\n\t// 325 NewArr v297 @ X0_v32 (System.String[]), typeof(System.String[]), 5\n\tv748 = \"[TCP2 Demo] Can't find shader for keywords: \\\"\" == 0;\n\tif (v748) goto L_0159;\n\t// 336 IsInst v400 @ X0_v55, typeof(System.String), \"[TCP2 Demo] Can't find shader for keywords: \"\"\n\tv406 = v400 == 0;\n\tif (v406) goto L_01F9;\nL_0159:\n\tv297[0] = \"[TCP2 Demo] Can't find shader for keywords: \\\"\";\n\tv761 = v738 == 0;\n\tif (v761) goto L_016F;\n\t// 351 IsInst v401 @ X0_v54, typeof(System.String), v738 @ X0_v30 (System.String)\n\tv407 = v401 == 0;\n\tif (v407) goto L_01F9;\nL_016F:\n\tv297[1] = v738;\n\tv768 = \"\\\" in material \\\"\" == 0;\n\tif (v768) goto L_018C;\n\t// 375 IsInst v402 @ X0_v52, typeof(System.String), \"\" in material \"\"\n\tv408 = v402 == 0;\n\tif (v408) goto L_01F9;\nL_018C:\n\tv297[2] = \"\\\" in material \\\"\";\n\tv777 = UnityEngine.Object::get_name(v112[v138 @ X23_v10 (System.Int32)]);\n\tv778 = v777 == 0;\n\tif (v778) goto L_01A4;\n\t// 404 IsInst v403 @ X0_v51, typeof(System.String), v777 @ X0_v39 (System.String)\n\tv409 = v403 == 0;\n\tif (v409) goto L_01F9;\nL_01A4:\n\tv297[3] = v777;\n\tv784 = \"\\\"\\nThe missing shaders probably need to be unpacked. See TCP2 Documentation!\" == 0;\n\tif (v784) goto L_01BD;\n\t// 426 IsInst v404 @ X0_v49, typeof(System.String), \"\"\nThe missing shaders probably need to be unpacked. See TCP2 Documentation!\"\n\tv410 = v404 == 0;\n\tif (v410) goto L_01F9;\nL_01BD:\n\tv297[4] = \"\\\"\\nThe missing shaders probably need to be unpacked. See TCP2 Documentation!\";\n\tv791 = System.String::Concat(v297);\n\tgoto L_01CF;\n\tv797 = *([v667 @ X8_v43+E0]);\n\tv798 = v797 == 0;\n\tv799 = ~v798;\n\tif (v799) goto L_01CF;\n\tv802 = v667;\n\tv801 = \"il2cpp_codegen_runtime_class_init\"(v802, v790, v274, v88, v40, v41, v42, v43, v76, v45, v46, v47, v48, v49, v50, v51);\nL_01CF:\n\tUnityEngine.Debug::LogError(v791);\n\tgoto L_01D8;\nL_01D6:\n\tUnityEngine.Material::set_shader(v112[v138 @ X23_v10 (System.Int32)], v599);\nL_01D8:\n\tv138 = v138 + 1;\n\tv534 = v138 < v112.Length;\n\tif (v534) goto L_00D8;\nL_01F2:\n\treturn;\n\tv507 = new System.IndexOutOfRangeException();\nL_01F6:\n\tthrow System.TypeLoadException;\n\tv312 = new System.NullReferenceException();\nL_01F9:\n\tv420 = new System.ArrayTypeMismatchException();\n\tgoto L_01F6;\n\treturn;\n// 392 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateShader()
	{
		//IL_00f9: Expected O, but got I4
		//IL_011a: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0161: Expected O, but got I4
		//IL_00d3: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		//IL_029f: Expected O, but got I4
		//IL_0272: Expected O, but got I4
		Material[] affectedMaterials = AffectedMaterials;
		if (affectedMaterials.Length >= 1)
		{
			int num = 0;
			TCP2_Demo tCP2_Demo = this;
			bool flag3;
			do
			{
				tCP2_Demo.ToggleKeyword(affectedMaterials[num], mShaderSpecular, "TCP2_SPEC");
				string text = affectedMaterials[num].name;
				bool flag = text.Contains("Robot");
				if (!flag)
				{
					((TCP2_Demo)flag).ToggleKeyword(affectedMaterials[num], mShaderBump, "TCP2_BUMP");
				}
				((TCP2_Demo)flag).ToggleKeyword(affectedMaterials[num], mShaderReflection, "TCP2_REFLECTION_MASKED");
				((TCP2_Demo)flag).ToggleKeyword(affectedMaterials[num], mShaderRim, "TCP2_RIM");
				((TCP2_Demo)flag).ToggleKeyword(affectedMaterials[num], mShaderRimOutline, "TCP2_RIMO");
				((TCP2_Demo)flag).ToggleKeyword(affectedMaterials[num], mShaderOutline, "OUTLINES");
				((TCP2_Demo)flag).ToggleKeyword(affectedMaterials[num], mRampTextureFlag, "TCP2_RAMPTEXT");
				affectedMaterials[num].SetFloat("_RampSmooth", mRampSmoothing);
				affectedMaterials[num].SetTexture("_Ramp", mRampTexture);
				affectedMaterials[num].SetFloat("_RimMin", mRimMin);
				affectedMaterials[num].SetFloat("_RimMax", mRimMax);
				string text2 = affectedMaterials[num].name;
				bool flag2 = text2.Contains("Robot");
				if (flag2)
				{
					((TCP2_Demo)flag2).ToggleKeyword(affectedMaterials[num], mRobotOutlineNormals, "TCP2_TANGENT_AS_NORMALS");
				}
				num++;
				flag3 = num < affectedMaterials.Length;
				tCP2_Demo = (TCP2_Demo)flag2;
			}
			while (flag3);
		}
		Material[] affectedMaterials2 = AffectedMaterials;
		if (affectedMaterials2.Length < 1)
		{
			return;
		}
		int num2 = 0;
		while (true)
		{
			Shader shaderWithKeywords = TCP2_RuntimeUtils.GetShaderWithKeywords(affectedMaterials2[num2]);
			if (shaderWithKeywords == null)
			{
				string[] shaderKeywords = affectedMaterials2[num2].shaderKeywords;
				bool flag4 = shaderKeywords.Length < 1;
				string text3 = "";
				if (!flag4)
				{
					int num3 = 0;
					string text4 = "";
					bool flag5;
					do
					{
						string text5 = text4 + shaderKeywords[num3] + ",";
						num3++;
						flag5 = num3 < shaderKeywords.Length;
						text3 = text5;
						text4 = text5;
					}
					while (flag5);
				}
				string text6 = text3.TrimEnd(',');
				string[] array = new string[5];
				if ("[TCP2 Demo] Can't find shader for keywords: \"" != null)
				{
					object obj = "[TCP2 Demo] Can't find shader for keywords: \"" as string;
					if (obj == null)
					{
						break;
					}
				}
				array[0] = "[TCP2 Demo] Can't find shader for keywords: \"";
				if (text6 != null)
				{
					object obj2 = text6 as string;
					if (obj2 == null)
					{
						break;
					}
				}
				array[1] = text6;
				if ("\" in material \"" != null)
				{
					object obj3 = "\" in material \"" as string;
					if (obj3 == null)
					{
						break;
					}
				}
				array[2] = "\" in material \"";
				string text7 = affectedMaterials2[num2].name;
				if (text7 != null)
				{
					object obj4 = text7 as string;
					if (obj4 == null)
					{
						break;
					}
				}
				array[3] = text7;
				if ("\"\nThe missing shaders probably need to be unpacked. See TCP2 Documentation!" != null)
				{
					object obj5 = "\"\nThe missing shaders probably need to be unpacked. See TCP2 Documentation!" as string;
					if (obj5 == null)
					{
						break;
					}
				}
				array[4] = "\"\nThe missing shaders probably need to be unpacked. See TCP2 Documentation!";
				string message = string.Concat(array);
				Debug.LogError(message);
			}
			else
			{
				affectedMaterials2[num2].shader = shaderWithKeywords;
			}
			num2++;
			if (num2 < affectedMaterials2.Length)
			{
				continue;
			}
			return;
		}
		ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
		throw new TypeLoadException();
	}

	[Token(Token = "0x600005A")]
	[Address(RVA = "0xB05A80", Offset = "0xB05A80", Length = "0xBC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFEBC0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224D1]) = v42;\nL_0015:\n\tv43 = this.AffectedMaterials;\n\tv123 = v43.Length;\n\tv56 = v43.Length < 1;\n\tif (v56) goto L_0056;\nL_0028:\n\tv182 = v83 < v123;\n\tv111 = ~v182;\n\tif (v111) goto L_0057;\n\tv77 = UnityEngine.Color::get_black();\n\tUnityEngine.Material::SetColor(v43[v83 @ X21_v5 (System.Int32)], \"_RimColor\", v77);\n\tv123 = v43.Length;\n\tv83 = v83 + 1;\n\tv144 = v83 < v43.Length;\n\tif (v144) goto L_0028;\nL_0056:\n\treturn;\nL_0057:\n\tv209 = new System.IndexOutOfRangeException();\n\tthrow v209;\n\tthrow System.NullReferenceException;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void RimOutlineColor()
	{
		Material[] affectedMaterials = AffectedMaterials;
		int num = affectedMaterials.Length;
		if (affectedMaterials.Length < 1)
		{
			return;
		}
		int num2 = 0;
		while (num2 < num)
		{
			Color black = Color.black;
			affectedMaterials[num2].SetColor("_RimColor", black);
			num = affectedMaterials.Length;
			num2++;
			if (num2 >= affectedMaterials.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x600005B")]
	[Address(RVA = "0xB037E0", Offset = "0xB037E0", Length = "0x164")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EC8318]);\n\tv35 = *([v34 @ X8_v12]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20224D2]) = v54;\nL_001B:\n\tv55 = this.AffectedMaterials;\n\tv155 = v55.Length;\n\tv68 = v55.Length < 1;\n\tif (v68) goto L_0086;\nL_0037:\n\tv273 = v103 < v155;\n\tv143 = ~v273;\n\tif (v143) goto L_0087;\n\tv259 = UnityEngine.Object::get_name(v55[v103 @ X21_v6 (System.Int32)]);\n\tv314 = System.String::Contains(v259, \"Robot\");\n\tv212 = v314 == 0;\n\tif (v212) goto L_005E;\n\tgoto L_0061;\nL_005E:\n\tv319 = 0;\nL_0061:\n\tv337 = 0x101059C(v335, 0, 0, v39, v40, v41, v42, v43, v334, v333, v332, v331, v48, v49, v50, v51);\n\t// 105 MakeStruct v162 @ AGGB038F4_2_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v319 @ stack_-70_v8, v338 @ stack_-6C, v172 @ stack_-68_v5 (System.Int32), v339 @ stack_-64\n\tUnityEngine.Material::SetColor(v55[v103 @ X21_v6 (System.Int32)], \"_RimColor\", v162);\n\tv155 = v55.Length;\n\tv103 = v103 + 1;\n\tv192 = v103 < v55.Length;\n\tif (v192) goto L_0037;\nL_0086:\n\treturn;\nL_0087:\n\tv310 = new System.IndexOutOfRangeException();\n\tthrow v310;\n\tthrow System.NullReferenceException;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void RestoreRimColors()
	{
		//IL_00c9: Expected O, but got I4
		//IL_00ff: Expected O, but got I4
		//IL_0141: Expected F4, but got O
		//IL_014e: Expected F4, but got O
		//IL_0169: Expected F4, but got O
		Material[] affectedMaterials = AffectedMaterials;
		int num = affectedMaterials.Length;
		if (affectedMaterials.Length < 1)
		{
			return;
		}
		int num2 = 0;
		object obj2 = default(object);
		Color value = default(Color);
		object obj3 = default(object);
		object obj4 = default(object);
		while (num2 < num)
		{
			string text = affectedMaterials[num2].name;
			int num7;
			if (text.Contains("Robot"))
			{
				float num3 = 0.5f;
				float num4 = 1f;
				float num5 = 0.6f;
				float num6 = 0.2f;
				num7 = 0;
				object obj = obj2;
			}
			else
			{
				obj2 = 0;
				float num3 = 0.25f;
				float num4 = 1f;
				float num5 = 1f;
				float num6 = 1f;
				num7 = 0;
				obj2 = 0;
				object obj = obj2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			value.r = (float)obj2;
			value.g = (float)obj3;
			value.b = num7;
			value.a = (float)obj4;
			affectedMaterials[num2].SetColor("_RimColor", value);
			num = affectedMaterials.Length;
			num2++;
			if (num2 >= affectedMaterials.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x600005C")]
	[Address(RVA = "0xB05E34", Offset = "0xB05E34", Length = "0x30")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = enabled == 0;\n\tif (v7) goto L_000B;\n\tUnityEngine.Material::EnableKeyword(m, keyword);\n\treturn;\nL_000B:\n\tUnityEngine.Material::DisableKeyword(m, keyword);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void ToggleKeyword(Material m, bool enabled, string keyword)
	{
		if (enabled)
		{
			m.EnableKeyword(keyword);
		}
		else
		{
			m.DisableKeyword(keyword);
		}
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0xB05B3C", Offset = "0xB05B3C", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC8A10]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224D3]) = v40;\nL_0019:\n\tv46 = System.Array::IndexOf(this.RampTextures, this.mRampTexture);\n\tv47 = this.RampTextures;\n\tgoto L_002E;\n\tv74 = *([v52 @ X0_v10+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_002E;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v52, v43, v45, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv60 = v47.Length - 1;\n\tv66 = UnityEngine.Mathf::Clamp(v46, 0, v60);\n\tv71 = this.RampTextures;\n\tv111 = v66 - 1;\n\tv120 = v111 & 0x80000000;\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_003D;\n\tv126 = v71 == 0;\n\tv68 = ~v126;\n\tif (v68) goto L_003F;\n\tgoto L_0055;\nL_003D:\n\tv111 = v71.Length - 1;\nL_003F:\n\tv128 = v111 < v71.Length;\n\tv106 = ~v128;\n\tif (v106) goto L_0056;\n\tthis.mRampTexture = v71[v111 @ X9_v4 (System.Int32)];\n\treturn;\nL_0055:\n\tv73 = new System.NullReferenceException();\nL_0056:\n\tv119 = new System.IndexOutOfRangeException();\n\tthrow v119;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void PrevRamp()
	{
		//IL_005a: Expected I4, but got I8
		int value = Array.IndexOf(RampTextures, mRampTexture);
		Texture2D[] rampTextures = RampTextures;
		int max = rampTextures.Length - 1;
		int num = Mathf.Clamp(value, 0, max);
		Texture2D[] rampTextures2 = RampTextures;
		int num2 = num - 1;
		if ((int)(num2 & 0x80000000L) == 0)
		{
			if (rampTextures2 == null)
			{
				NullReferenceException ex = new NullReferenceException();
				goto IL_00e6;
			}
		}
		else
		{
			num2 = rampTextures2.Length - 1;
		}
		if (num2 < rampTextures2.Length)
		{
			mRampTexture = rampTextures2[num2];
			return;
		}
		goto IL_00e6;
		IL_00e6:
		IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
		throw ex2;
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0xB05C30", Offset = "0xB05C30", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EF1960]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224D4]) = v40;\nL_0019:\n\tv46 = System.Array::IndexOf(this.RampTextures, this.mRampTexture);\n\tv47 = this.RampTextures;\n\tgoto L_002E;\n\tv70 = *([v52 @ X0_v10+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002E;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v52, v43, v45, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tv57 = v47.Length - 1;\n\tv63 = UnityEngine.Mathf::Clamp(v46, 0, v57);\n\tv67 = this.RampTextures;\n\tv111 = v63 + 1;\n\tv128 = v111 - v67.Length;\n\tv129 = v128 < 0;\n\tv131 = v111 ^ v67.Length;\n\tv132 = v111 ^ v128;\n\tv133 = v131 & v132;\n\tv134 = v133 < 0;\n\tv135 = v129 == v134;\n\tv84 = ~v135;\n\tv81 = ~v84;\n\tif (v81) goto L_FFFFFFFF;\n\tgoto L_0046;\nL_0046:\n\tv170 = v111 < v67.Length;\n\tv108 = ~v170;\n\tif (v108) goto L_005D;\n\tthis.mRampTexture = v67[v111 @ X9_v3 (System.Int32)];\n\treturn;\n\tv69 = new System.NullReferenceException();\nL_005D:\n\tv121 = new System.IndexOutOfRangeException();\n\tthrow v121;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void NextRamp()
	{
		int value = Array.IndexOf(RampTextures, mRampTexture);
		Texture2D[] rampTextures = RampTextures;
		int max = rampTextures.Length - 1;
		int num = Mathf.Clamp(value, 0, max);
		Texture2D[] rampTextures2 = RampTextures;
		int num2 = num + 1;
		int num3 = num2 - rampTextures2.Length;
		bool flag = num3 < 0;
		int num4 = num2 ^ rampTextures2.Length;
		int num5 = num2 ^ num3;
		int num6 = num4 & num5;
		bool flag2 = num6 < 0;
		if (flag == flag2)
		{
			num2 = 0;
		}
		if (num2 < rampTextures2.Length)
		{
			mRampTexture = rampTextures2[num2];
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x600005F")]
	[Address(RVA = "0xB0624C", Offset = "0xB0624C", Length = "0x44")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mShaderSpecular = 0x101;\n\tthis.mShaderRim = 1;\n\tthis.mShaderOutline = 1;\n\tthis.mRimMin = 1f;\n\tthis.mRampSmoothing = 0.15f;\n\tthis.mLightRotationY = 25f;\n\tthis.mRobotOutlineNormals = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_Demo()
	{
		mShaderSpecular = true;
		mShaderBump = true;
		mShaderRim = true;
		mShaderOutline = true;
		mRimMin = 1f;
		mRampSmoothing = 0.15f;
		mLightRotationY = 25f;
		mRobotOutlineNormals = true;
	}
}
