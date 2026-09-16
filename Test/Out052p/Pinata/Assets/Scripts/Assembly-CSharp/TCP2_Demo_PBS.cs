using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

[Token(Token = "0x200000F")]
public class TCP2_Demo_PBS : MonoBehaviour
{
	[Serializable]
	[Token(Token = "0x2000454")]
	public class SkyboxSetting
	{
		[Token(Token = "0x400205C")]
		[FieldOffset(Offset = "0x10")]
		public Material SkyMaterial;

		[Token(Token = "0x400205D")]
		[FieldOffset(Offset = "0x18")]
		public Color lightColor;

		[Token(Token = "0x400205E")]
		[FieldOffset(Offset = "0x28")]
		public Vector3 DirLightEuler;

		[Token(Token = "0x600154A")]
		[Address(RVA = "0xB0735C", Offset = "0xB0735C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkyboxSetting()
		{
		}
	}

	[Token(Token = "0x400005E")]
	[FieldOffset(Offset = "0x18")]
	public Light DirLight;

	[Token(Token = "0x400005F")]
	[FieldOffset(Offset = "0x20")]
	public GameObject PointLights;

	[Token(Token = "0x4000060")]
	[FieldOffset(Offset = "0x28")]
	public MeshRenderer Robot;

	[Token(Token = "0x4000061")]
	[FieldOffset(Offset = "0x30")]
	public GameObject Canvas;

	[Token(Token = "0x4000062")]
	[FieldOffset(Offset = "0x38")]
	public SkyboxSetting[] SkySettings;

	[Token(Token = "0x4000063")]
	[FieldOffset(Offset = "0x40")]
	public bool FlipLight;

	[Token(Token = "0x4000064")]
	[FieldOffset(Offset = "0x48")]
	public Texture2D[] RampTextures;

	[Token(Token = "0x4000065")]
	[FieldOffset(Offset = "0x50")]
	public Slider SmoothnessSlider;

	[Token(Token = "0x4000066")]
	[FieldOffset(Offset = "0x58")]
	public Text SmoothnessValue;

	[Token(Token = "0x4000067")]
	[FieldOffset(Offset = "0x60")]
	public Slider MetallicSlider;

	[Token(Token = "0x4000068")]
	[FieldOffset(Offset = "0x68")]
	public Text MetallicValue;

	[Token(Token = "0x4000069")]
	[FieldOffset(Offset = "0x70")]
	public Text BumpScaleValue;

	[Token(Token = "0x400006A")]
	[FieldOffset(Offset = "0x78")]
	public Text ShaderText;

	[Token(Token = "0x400006B")]
	[FieldOffset(Offset = "0x80")]
	public Text SkyboxValue;

	[Token(Token = "0x400006C")]
	[FieldOffset(Offset = "0x88")]
	public Text RampValue;

	[Token(Token = "0x400006D")]
	[FieldOffset(Offset = "0x90")]
	public Slider RampThresholdSlider;

	[Token(Token = "0x400006E")]
	[FieldOffset(Offset = "0x98")]
	public Text RampThresholdValue;

	[Token(Token = "0x400006F")]
	[FieldOffset(Offset = "0xA0")]
	public Slider RampSmoothSlider;

	[Token(Token = "0x4000070")]
	[FieldOffset(Offset = "0xA8")]
	public Text RampSmoothValue;

	[Token(Token = "0x4000071")]
	[FieldOffset(Offset = "0xB0")]
	public Slider RampSmoothAddSlider;

	[Token(Token = "0x4000072")]
	[FieldOffset(Offset = "0xB8")]
	public Text RampSmoothAddValue;

	[Token(Token = "0x4000073")]
	[FieldOffset(Offset = "0xC0")]
	public RawImage RampImage;

	[Token(Token = "0x4000074")]
	[FieldOffset(Offset = "0xC8")]
	private int currentSky;

	[Token(Token = "0x4000075")]
	[FieldOffset(Offset = "0xCC")]
	private int currentRamp;

	[Token(Token = "0x4000076")]
	[FieldOffset(Offset = "0xD0")]
	private Material robotMaterial;

	[Token(Token = "0x4000077")]
	[FieldOffset(Offset = "0xD8")]
	private bool mUseOutline;

	[Token(Token = "0x4000078")]
	[FieldOffset(Offset = "0xD9")]
	private bool mRotatePointLights;

	[Token(Token = "0x17000001")]
	public bool ShowPointLights
	{
		[Token(Token = "0x6000060")]
		[Address(RVA = "0xB06290", Offset = "0xB06290", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.GameObject::SetActive(this.PointLights, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PointLights.SetActive(value);
		}
	}

	[Token(Token = "0x17000002")]
	public bool ShowDirLight
	{
		[Token(Token = "0x6000061")]
		[Address(RVA = "0xB062B0", Offset = "0xB062B0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Behaviour::set_enabled(this.DirLight, value);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			DirLight.enabled = value;
		}
	}

	[Token(Token = "0x17000003")]
	public bool RotatePointLights
	{
		[Token(Token = "0x6000062")]
		[Address(RVA = "0xB062D0", Offset = "0xB062D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mRotatePointLights;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return RotatePointLights;
		}
		[Token(Token = "0x6000063")]
		[Address(RVA = "0xB062D8", Offset = "0xB062D8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mRotatePointLights = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			mRotatePointLights = value;
		}
	}

	[Token(Token = "0x17000004")]
	public bool UseOutline
	{
		[Token(Token = "0x6000064")]
		[Address(RVA = "0xB062E4", Offset = "0xB062E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mUseOutline;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return UseOutline;
		}
		[Token(Token = "0x6000065")]
		[Address(RVA = "0xB062EC", Offset = "0xB062EC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EC7DB0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20224D5]) = v41;\nL_0017:\n\tthis.mUseOutline = value;\n\tv46 = UnityEngine.Material::get_shader(this.robotMaterial);\n\tv50 = UnityEngine.Object::get_name(v46);\n\tv64 = System.String::Contains(v50, \"Toony\");\n\tv66 = v64 == 0;\n\tif (v66) goto L_0039;\n\tTCP2_Demo_PBS::ShowTCP2Shader(this);\n\treturn;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			mUseOutline = value;
			Shader shader = robotMaterial.shader;
			string text = shader.name;
			if (text.Contains("Toony"))
			{
				ShowTCP2Shader();
			}
		}
	}

	[Token(Token = "0x17000005")]
	public bool UseRampTexture
	{
		[Token(Token = "0x6000066")]
		[Address(RVA = "0xB06454", Offset = "0xB06454", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EFECB0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20224D6]) = v41;\nL_001C:\n\tv48 = value == 0;\n\tv54 = ~v48;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_TCP2_RAMPTEXT\", v65);\n\tv99 = value == 0;\n\tif (v99) goto L_0043;\n\tUnityEngine.Material::EnableKeyword(this.robotMaterial, \"TCP2_RAMPTEXT\");\n\treturn;\nL_0043:\n\tUnityEngine.Material::DisableKeyword(this.robotMaterial, \"TCP2_RAMPTEXT\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			float value2 = ((!value) ? 0f : 1f);
			robotMaterial.SetFloat("_TCP2_RAMPTEXT", value2);
			if (value)
			{
				robotMaterial.EnableKeyword("TCP2_RAMPTEXT");
			}
			else
			{
				robotMaterial.DisableKeyword("TCP2_RAMPTEXT");
			}
		}
	}

	[Token(Token = "0x17000006")]
	public bool UseStylizedFresnel
	{
		[Token(Token = "0x6000067")]
		[Address(RVA = "0xB064FC", Offset = "0xB064FC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EC5A10]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20224D7]) = v41;\nL_001C:\n\tv48 = value == 0;\n\tv54 = ~v48;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_TCP2_STYLIZED_FRESNEL\", v65);\n\tv99 = value == 0;\n\tif (v99) goto L_0043;\n\tUnityEngine.Material::EnableKeyword(this.robotMaterial, \"TCP2_STYLIZED_FRESNEL\");\n\treturn;\nL_0043:\n\tUnityEngine.Material::DisableKeyword(this.robotMaterial, \"TCP2_STYLIZED_FRESNEL\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			float value2 = ((!value) ? 0f : 1f);
			robotMaterial.SetFloat("_TCP2_STYLIZED_FRESNEL", value2);
			if (value)
			{
				robotMaterial.EnableKeyword("TCP2_STYLIZED_FRESNEL");
			}
			else
			{
				robotMaterial.DisableKeyword("TCP2_STYLIZED_FRESNEL");
			}
		}
	}

	[Token(Token = "0x17000007")]
	public bool UseStylizedSpecular
	{
		[Token(Token = "0x6000068")]
		[Address(RVA = "0xB065A4", Offset = "0xB065A4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ED5C18]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20224D8]) = v41;\nL_001C:\n\tv48 = value == 0;\n\tv54 = ~v48;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_TCP2_SPEC_TOON\", v65);\n\tv99 = value == 0;\n\tif (v99) goto L_0043;\n\tUnityEngine.Material::EnableKeyword(this.robotMaterial, \"TCP2_SPEC_TOON\");\n\treturn;\nL_0043:\n\tUnityEngine.Material::DisableKeyword(this.robotMaterial, \"TCP2_SPEC_TOON\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			float value2 = ((!value) ? 0f : 1f);
			robotMaterial.SetFloat("_TCP2_SPEC_TOON", value2);
			if (value)
			{
				robotMaterial.EnableKeyword("TCP2_SPEC_TOON");
			}
			else
			{
				robotMaterial.DisableKeyword("TCP2_SPEC_TOON");
			}
		}
	}

	[Token(Token = "0x6000069")]
	[Address(RVA = "0xB0664C", Offset = "0xB0664C", Length = "0x1C0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED1B90]);\n\tv19 = *([v18 @ X8_v23]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224D9]) = v38;\nL_0017:\n\tv42 = UnityEngine.Renderer::get_material(this.Robot);\n\tthis.robotMaterial = v42;\n\tv67 = UnityEngine.Material::get_shader(v42);\n\tv68 = UnityEngine.Object::get_name(v67);\n\tv108 = System.String::Contains(v68, \"Outline\");\n\tthis.mUseOutline = v108;\n\tv44 = UnityEngine.Material::GetFloat(this.robotMaterial, \"_Metallic\");\n\tv150 = UnityEngine.UI.Slider::set_value(this.MetallicSlider, v44);\n\tv45 = UnityEngine.Material::GetFloat(this.robotMaterial, \"_Glossiness\");\n\tv153 = UnityEngine.UI.Slider::set_value(this.SmoothnessSlider, v45);\n\tv46 = UnityEngine.Material::GetFloat(this.robotMaterial, \"_RampThreshold\");\n\tv156 = UnityEngine.UI.Slider::set_value(this.RampThresholdSlider, v46);\n\tv47 = UnityEngine.Material::GetFloat(this.robotMaterial, \"_RampSmooth\");\n\tv159 = UnityEngine.UI.Slider::set_value(this.RampSmoothSlider, v47);\n\tv124 = this.RampSmoothAddSlider;\n\tv93 = UnityEngine.Material::GetFloat(this.robotMaterial, \"_RampSmoothAdd\");\n\tv162 = UnityEngine.UI.Slider::set_value(v124, v93);\n\tTCP2_Demo_PBS::UpdateSky(this);\n\tTCP2_Demo_PBS::UpdateRamp(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		Shader shader = (robotMaterial = Robot.material).shader;
		string text = shader.name;
		bool flag = text.Contains("Outline");
		mUseOutline = flag;
		float value = robotMaterial.GetFloat("_Metallic");
		MetallicSlider.value = value;
		float value2 = robotMaterial.GetFloat("_Glossiness");
		SmoothnessSlider.value = value2;
		float value3 = robotMaterial.GetFloat("_RampThreshold");
		RampThresholdSlider.value = value3;
		float value4 = robotMaterial.GetFloat("_RampSmooth");
		RampSmoothSlider.value = value4;
		Slider rampSmoothAddSlider = RampSmoothAddSlider;
		float value5 = robotMaterial.GetFloat("_RampSmoothAdd");
		rampSmoothAddSlider.value = value5;
		UpdateSky();
		UpdateRamp();
	}

	[Token(Token = "0x600006A")]
	[Address(RVA = "0xB06B60", Offset = "0xB06B60", Length = "0x164")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDEFC8]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20224DA]) = v44;\nL_0017:\n\tv46 = ~this.mRotatePointLights;\n\tif (v46) goto L_004C;\n\tv89 = UnityEngine.GameObject::get_transform(this.PointLights);\n\tgoto L_002D;\n\tv146 = *([v82 @ X8_v11+E0]);\n\tv147 = v146 == 0;\n\tv148 = ~v147;\n\tif (v148) goto L_002D;\n\tv200 = v82;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v200, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv153 = UnityEngine.Vector3::get_up();\n\tv205 = UnityEngine.Vector3::op_Multiply(v153, 20f);\n\tv212 = UnityEngine.Time::get_deltaTime();\n\tv71 = UnityEngine.Vector3::op_Multiply(v205, v212);\n\tUnityEngine.Transform::Rotate(v89, v71);\nL_004C:\n\tv87 = UnityEngine.Input::GetKeyDown(0x68);\n\tv124 = v87 == 0;\n\tif (v124) goto L_005E;\n\tv194 = UnityEngine.GameObject::get_activeSelf(this.Canvas);\n\tv139 = ~v194;\n\tUnityEngine.GameObject::SetActive(this.Canvas, v139);\nL_005E:\n\tv145 = UnityEngine.Input::GetKeyDown(0x113);\n\tv199 = v145 == 0;\n\tif (v199) goto L_0066;\n\tTCP2_Demo_PBS::NextSky(this);\nL_0066:\n\tv179 = UnityEngine.Input::GetKeyDown(0x114);\n\tv181 = v179 == 0;\n\tif (v181) goto L_007D;\n\tTCP2_Demo_PBS::PrevSky(this);\n\treturn;\nL_007D:\n\treturn;\n\tv115 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (RotatePointLights)
		{
			Transform transform = PointLights.transform;
			Vector3 up = Vector3.up;
			Vector3 vector = up * 20f;
			float deltaTime = Time.deltaTime;
			Vector3 eulers = vector * deltaTime;
			transform.Rotate(eulers);
		}
		if (Input.GetKeyDown(KeyCode.H))
		{
			bool activeSelf = Canvas.activeSelf;
			bool active = !activeSelf;
			Canvas.SetActive(active);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			NextSky();
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			PrevSky();
		}
	}

	[Token(Token = "0x600006B")]
	[Address(RVA = "0xB06D38", Offset = "0xB06D38", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED8CA8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224DB]) = v38;\nL_0017:\n\tv42 = UnityEngine.Material::get_shader(this.robotMaterial);\n\tv49 = UnityEngine.Object::get_name(v42);\n\tv84 = System.String::Contains(v49, \"Toony\");\n\tv86 = v84 == 0;\n\tif (v86) goto L_0030;\n\tTCP2_Demo_PBS::ShowUnityStandardShader(this);\n\tv72 = this.ShaderText;\n\tv78 = *([v72 @ X0_v8 (UnityEngine.UI.Text)]);\n\tgoto L_0037;\nL_0030:\n\tTCP2_Demo_PBS::ShowTCP2Shader(this);\n\tv72 = this.ShaderText;\n\tv78 = *([v72 @ X0_v8 (UnityEngine.UI.Text)]);\nL_0037:\n\tv70 = *([v65 @ X9_v1 (System.String)]);\n\tv63 = *([v78 @ X8_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv68 = *([v78 @ X8_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 63 IndirectJump v63 @ X3_v1, v72 @ X0_v8 (UnityEngine.UI.Text), v72 @ X0_v8 (UnityEngine.UI.Text), v70 @ X1_v5 (Il2CppClass<System.String>), v68 @ X2_v3, v63 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ToggleShader()
	{
		//IL_00a2: Expected I, but got O
		//IL_00b8: Expected I, but got O
		//IL_00c8: Expected O, but got I
		//IL_00d8: Expected O, but got I
		//IL_0077: Expected I, but got O
		Shader shader = robotMaterial.shader;
		string text = shader.name;
		string text2;
		if (text.Contains("Toony"))
		{
			ShowUnityStandardShader();
			Text shaderText = ShaderText;
			IntPtr intPtr = (IntPtr)shaderText;
			text2 = "View with TCP2 PBS shader";
		}
		else
		{
			ShowTCP2Shader();
			Text shaderText = ShaderText;
			IntPtr intPtr = (IntPtr)shaderText;
			text2 = "View with Unity Standard shader";
		}
		IntPtr intPtr2 = (IntPtr)text2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ X8_v6 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x600006C")]
	[Address(RVA = "0xB06CC4", Offset = "0xB06CC4", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.SkySettings;\n\tv3 = this.currentSky + 1;\n\tthis.currentSky = v3;\n\tv16 = v3 < v2.Length;\n\tif (v16) goto L_0014;\n\tthis.currentSky = 0;\nL_0014:\n\tTCP2_Demo_PBS::UpdateSky(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void NextSky()
	{
		SkyboxSetting[] skySettings = SkySettings;
		if (++currentSky >= skySettings.Length)
		{
			currentSky = 0;
		}
		UpdateSky();
	}

	[Token(Token = "0x600006D")]
	[Address(RVA = "0xB06CFC", Offset = "0xB06CFC", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentSky - 1;\n\tthis.currentSky = v2;\n\tv3 = v2 & 0x80000000;\n\tv4 = v3 == 0;\n\tv5 = ~v4;\n\tif (v5) goto L_0009;\n\tTCP2_Demo_PBS::UpdateSky(this);\n\treturn;\nL_0009:\n\tv7 = this.SkySettings;\n\tv10 = v7.Length - 1;\n\tthis.currentSky = v10;\n\tTCP2_Demo_PBS::UpdateSky(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PrevSky()
	{
		//IL_002c: Expected I4, but got I8
		if ((int)(--currentSky & 0x80000000L) == 0)
		{
			UpdateSky();
			return;
		}
		SkyboxSetting[] skySettings = SkySettings;
		int num = skySettings.Length - 1;
		currentSky = num;
		UpdateSky();
	}

	[Token(Token = "0x600006E")]
	[Address(RVA = "0xB06E6C", Offset = "0xB06E6C", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.RampTextures;\n\tv3 = this.currentRamp + 1;\n\tthis.currentRamp = v3;\n\tv16 = v3 < v2.Length;\n\tif (v16) goto L_0014;\n\tthis.currentRamp = 0;\nL_0014:\n\tTCP2_Demo_PBS::UpdateRamp(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void NextRamp()
	{
		Texture2D[] rampTextures = RampTextures;
		if (++currentRamp >= rampTextures.Length)
		{
			currentRamp = 0;
		}
		UpdateRamp();
	}

	[Token(Token = "0x600006F")]
	[Address(RVA = "0xB06EA4", Offset = "0xB06EA4", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.currentRamp - 1;\n\tthis.currentRamp = v2;\n\tv3 = v2 & 0x80000000;\n\tv4 = v3 == 0;\n\tv5 = ~v4;\n\tif (v5) goto L_0009;\n\tTCP2_Demo_PBS::UpdateRamp(this);\n\treturn;\nL_0009:\n\tv7 = this.RampTextures;\n\tv10 = v7.Length - 1;\n\tthis.currentRamp = v10;\n\tTCP2_Demo_PBS::UpdateRamp(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void PrevRamp()
	{
		//IL_002c: Expected I4, but got I8
		if ((int)(--currentRamp & 0x80000000L) == 0)
		{
			UpdateRamp();
			return;
		}
		Texture2D[] rampTextures = RampTextures;
		int num = rampTextures.Length - 1;
		currentRamp = num;
		UpdateRamp();
	}

	[Token(Token = "0x6000070")]
	[Address(RVA = "0xB06EE0", Offset = "0xB06EE0", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv23 = *([1EB47F0]);\n\tv24 = *([v23 @ X8_v11]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224DC]) = v42;\nL_001E:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_Metallic\", f);\n\tv57 = 0xBCCF34(&f @ V0 (System.Single), \"0.00\", 0, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = UnityEngine.UI.Text::set_text(this.MetallicValue, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetMetallic(float f)
	{
		robotMaterial.SetFloat("_Metallic", f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
		string text = default(string);
		MetallicValue.text = text;
	}

	[Token(Token = "0x6000071")]
	[Address(RVA = "0xB06F94", Offset = "0xB06F94", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv23 = *([1EF6858]);\n\tv24 = *([v23 @ X8_v11]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224DD]) = v42;\nL_001E:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_Glossiness\", f);\n\tv57 = 0xBCCF34(&f @ V0 (System.Single), \"0.00\", 0, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = UnityEngine.UI.Text::set_text(this.SmoothnessValue, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetSmoothness(float f)
	{
		robotMaterial.SetFloat("_Glossiness", f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
		string text = default(string);
		SmoothnessValue.text = text;
	}

	[Token(Token = "0x6000072")]
	[Address(RVA = "0xB07048", Offset = "0xB07048", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv23 = *([1F0F1B8]);\n\tv24 = *([v23 @ X8_v11]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224DE]) = v42;\nL_001E:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_BumpScale\", f);\n\tv57 = 0xBCCF34(&f @ V0 (System.Single), \"0.00\", 0, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = UnityEngine.UI.Text::set_text(this.BumpScaleValue, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetBumpScale(float f)
	{
		robotMaterial.SetFloat("_BumpScale", f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
		string text = default(string);
		BumpScaleValue.text = text;
	}

	[Token(Token = "0x6000073")]
	[Address(RVA = "0xB070FC", Offset = "0xB070FC", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv23 = *([1F0DD18]);\n\tv24 = *([v23 @ X8_v11]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224DF]) = v42;\nL_001E:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_RampThreshold\", f);\n\tv57 = 0xBCCF34(&f @ V0 (System.Single), \"0.00\", 0, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = UnityEngine.UI.Text::set_text(this.RampThresholdValue, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetRampThreshold(float f)
	{
		robotMaterial.SetFloat("_RampThreshold", f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
		string text = default(string);
		RampThresholdValue.text = text;
	}

	[Token(Token = "0x6000074")]
	[Address(RVA = "0xB071B0", Offset = "0xB071B0", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv23 = *([1F00D68]);\n\tv24 = *([v23 @ X8_v11]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224E0]) = v42;\nL_001E:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_RampSmooth\", f);\n\tv57 = 0xBCCF34(&f @ V0 (System.Single), \"0.00\", 0, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = UnityEngine.UI.Text::set_text(this.RampSmoothValue, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetRampSmooth(float f)
	{
		robotMaterial.SetFloat("_RampSmooth", f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
		string text = default(string);
		RampSmoothValue.text = text;
	}

	[Token(Token = "0x6000075")]
	[Address(RVA = "0xB07264", Offset = "0xB07264", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv23 = *([1F02F20]);\n\tv24 = *([v23 @ X8_v11]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224E1]) = v42;\nL_001E:\n\tUnityEngine.Material::SetFloat(this.robotMaterial, \"_RampSmoothAdd\", f);\n\tv57 = 0xBCCF34(&f @ V0 (System.Single), \"0.00\", 0, v28, v29, v30, v31, v32, f, v33, v34, v35, v36, v37, v38, v39);\n\tv73 = UnityEngine.UI.Text::set_text(this.RampSmoothAddValue, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetRampSmoothAdd(float f)
	{
		robotMaterial.SetFloat("_RampSmoothAdd", f);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BCCF34 (inside System.Single::IsNaN +0x31C)");
		string text = default(string);
		RampSmoothAddValue.text = text;
	}

	[Token(Token = "0x6000076")]
	[Address(RVA = "0xB06A08", Offset = "0xB06A08", Length = "0x158")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC4468]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20224E2]) = v42;\nL_0015:\n\tv43 = this.RampTextures;\n\tv45 = this.currentRamp;\n\tv47 = this.currentRamp < v43.Length;\n\tv48 = ~v47;\n\tif (v48) goto L_0072;\n\tUnityEngine.Material::SetTexture(this.robotMaterial, \"_Ramp\", v43[v45 @ X9_v4 (System.Int32)]);\n\tv185 = this.currentRamp + 1;\n\t// 55 Box v102 @ X0_v12 (System.Object), typeof(System.Int32), &v185 @ X8_v9 (System.Int32)\n\tv43 = this.RampTextures;\n\tv43 = v43.Length;\n\t// 64 Box v225 @ X0_v14 (System.Object), typeof(System.Int32), &v43 @ X8_v3 (UnityEngine.Texture2D[])\n\tv103 = System.String::Format(\"{0}/{1}\", v102, v225);\n\tv104 = UnityEngine.UI.Text::set_text(this.RampValue, v103);\n\tv43 = this.RampTextures;\n\tv146 = this.currentRamp;\n\tv232 = this.currentRamp < v43.Length;\n\tv142 = ~v232;\n\tif (v142) goto L_0072;\n\tUnityEngine.UI.RawImage::set_texture(this.RampImage, v43[v146 @ X9_v8 (System.Int32)]);\n\treturn;\n\tv116 = new System.NullReferenceException();\nL_0072:\n\tv151 = new System.IndexOutOfRangeException();\n\tthrow v151;\n\tthrow System.NullReferenceException;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateRamp()
	{
		//IL_0092: Expected O, but got I4
		//IL_009b: Expected I4, but got O
		Texture2D[] rampTextures = RampTextures;
		int num = currentRamp;
		if (currentRamp < rampTextures.Length)
		{
			robotMaterial.SetTexture("_Ramp", rampTextures[num]);
			int num2 = currentRamp + 1;
			object arg = num2;
			rampTextures = RampTextures;
			rampTextures = (Texture2D[])rampTextures.Length;
			object arg2 = (int)rampTextures;
			string text = $"{arg}/{arg2}";
			RampValue.text = text;
			rampTextures = RampTextures;
			int num3 = currentRamp;
			if (currentRamp < rampTextures.Length)
			{
				RampImage.texture = rampTextures[num3];
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000077")]
	[Address(RVA = "0xB0680C", Offset = "0xB0680C", Length = "0x1FC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB0BD8]);\n\tv21 = *([v20 @ X8_v30]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20224E3]) = v40;\nL_0014:\n\tv41 = this.SkySettings;\n\tv43 = this.currentSky;\n\tv45 = this.currentSky < v41.Length;\n\tv46 = ~v45;\n\tif (v46) goto L_00B2;\n\tv104 = v41[v43 @ X9_v3 (System.Int32)];\n\tv143 = UnityEngine.Component::get_transform(this.DirLight);\n\t// 51 MakeStruct v83 @ AGGB06888_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v104.DirLightEuler (UnityEngine.Vector3), v104.DirLightEuler.y (System.Single), v104.DirLightEuler.z (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(v143, v83);\n\tv267 = ~this.FlipLight;\n\tif (v267) goto L_0060;\n\tv276 = UnityEngine.Component::get_transform(this.DirLight);\n\tgoto L_004C;\n\tv284 = *([v158 @ X8_v26+E0]);\n\tv285 = v284 == 0;\n\tv286 = ~v285;\n\tif (v286) goto L_004C;\n\tv290 = v158;\n\tv288 = \"il2cpp_codegen_runtime_class_init\"(v290, v99, v24, v25, v26, v27, v28, v29, v206, v204, v202, v33, v34, v35, v36, v37);\nL_004C:\n\tv94 = UnityEngine.Vector3::get_up();\n\tUnityEngine.Transform::Rotate(v276, v94, 180f, 1);\nL_0060:\n\t// 96 MakeStruct v68 @ AGGB06904_1_v4 (UnityEngine.Color), typeof(UnityEngine.Color), v104.lightColor (UnityEngine.Color), v104.lightColor.g (System.Single), v104.lightColor.b (System.Single), v104.lightColor.a (System.Single)\n\tUnityEngine.Light::set_color(this.DirLight, v68);\n\tUnityEngine.RenderSettings::set_skybox(v104.SkyMaterial);\n\tv294 = UnityEngine.Material::GetTexture(v104.SkyMaterial, \"_Tex\");\n\tv295 = v294 == 0;\n\tif (v295) goto L_0083;\n\tv309 = *([v294 @ X0_v16 (UnityEngine.Texture)]) != UnityEngine.Cubemap;\n\tif (v309) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_0083:\n\tUnityEngine.RenderSettings::set_customReflection(v310);\n\tUnityEngine.DynamicGI::UpdateEnvironment();\n\tv318 = this.currentSky + 1;\n\t// 142 Box v145 @ X0_v20 (System.Object), typeof(System.Int32), &v318 @ X8_v14 (System.Int32)\n\tv41 = this.SkySettings;\n\tv41 = v41.Length;\n\t// 151 Box v323 @ X0_v22 (System.Object), typeof(System.Int32), &v41 @ X8_v3 (SkyboxSetting[])\n\tv146 = System.String::Format(\"{0}/{1}\", v145, v323);\n\tv257 = UnityEngine.UI.Text::set_text(this.SkyboxValue, v146);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv166 = new System.NullReferenceException();\nL_00B2:\n\tv199 = new System.IndexOutOfRangeException();\n\tthrow v199;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void UpdateSky()
	{
		//IL_021e: Expected O, but got I4
		//IL_0227: Expected I4, but got O
		SkyboxSetting[] skySettings = SkySettings;
		int num = currentSky;
		if (currentSky < skySettings.Length)
		{
			SkyboxSetting skyboxSetting = skySettings[num];
			Transform transform = DirLight.transform;
			Vector3 eulerAngles = default(Vector3);
			eulerAngles.x = skyboxSetting.DirLightEuler.x;
			eulerAngles.y = skyboxSetting.DirLightEuler.y;
			eulerAngles.z = skyboxSetting.DirLightEuler.z;
			transform.eulerAngles = eulerAngles;
			if (FlipLight)
			{
				Transform transform2 = DirLight.transform;
				Vector3 up = Vector3.up;
				transform2.Rotate(up, 180f, Space.Self);
			}
			Color color = default(Color);
			color.r = skyboxSetting.lightColor.r;
			color.g = skyboxSetting.lightColor.g;
			color.b = skyboxSetting.lightColor.b;
			color.a = skyboxSetting.lightColor.a;
			DirLight.color = color;
			RenderSettings.skybox = skyboxSetting.SkyMaterial;
			Texture texture = skyboxSetting.SkyMaterial.GetTexture("_Tex");
			bool flag = (object)texture == null;
			Cubemap customReflection = (Cubemap)texture;
			if (!flag)
			{
				customReflection = (Cubemap)(((object)texture.GetType() != typeof(Cubemap)) ? null : texture);
			}
			RenderSettings.customReflection = customReflection;
			DynamicGI.UpdateEnvironment();
			int num2 = currentSky + 1;
			object arg = num2;
			skySettings = SkySettings;
			skySettings = (SkyboxSetting[])skySettings.Length;
			object arg2 = (int)skySettings;
			string text = $"{arg}/{arg2}";
			SkyboxValue.text = text;
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000078")]
	[Address(RVA = "0xB06DFC", Offset = "0xB06DFC", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF9BE8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224E4]) = v38;\nL_0018:\n\tv44 = UnityEngine.Shader::Find(\"Standard\");\n\tUnityEngine.Material::set_shader(this.robotMaterial, v44);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void ShowUnityStandardShader()
	{
		Shader shader = Shader.Find("Standard");
		robotMaterial.shader = shader;
	}

	[Token(Token = "0x6000079")]
	[Address(RVA = "0xB06390", Offset = "0xB06390", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBFC90]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20224E5]) = v38;\nL_001C:\n\tv48 = this.mUseOutline == 0;\n\tv54 = ~v48;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tv60 = UnityEngine.Shader::Find(*([v58 @ X8_v4 (System.String)]));\n\tgoto L_003C;\n\tv68 = *([v64 @ X8_v7+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_003C;\n\tv79 = v64;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v79, v53, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tv78 = UnityEngine.Object::op_Inequality(v60, 0);\n\tv81 = v78 == 0;\n\tif (v81) goto L_0051;\n\tUnityEngine.Material::set_shader(this.robotMaterial, v60);\n\treturn;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ShowTCP2Shader()
	{
		string text = ((!UseOutline) ? "Toony Colors Pro 2/Standard PBS" : "Hidden/Toony Colors Pro 2/Standard PBS Outline");
		Shader shader = Shader.Find(text);
		if (shader != null)
		{
			robotMaterial.shader = shader;
		}
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0xB07318", Offset = "0xB07318", Length = "0x30")]
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

	[Token(Token = "0x600007B")]
	[Address(RVA = "0xB07348", Offset = "0xB07348", Length = "0x14")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.FlipLight = 1;\n\tthis.mRotatePointLights = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TCP2_Demo_PBS()
	{
		FlipLight = true;
		mRotatePointLights = true;
	}
}
