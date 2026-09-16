using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

[Attribute(Type = typeof(RequireComponent), RVA = "0x74C9E4", Offset = "0x74C9E4")]
[Token(Token = "0x200001E")]
public class FPSDisplay : MonoBehaviour
{
	[Token(Token = "0x40000CF")]
	[FieldOffset(Offset = "0x18")]
	public float updateInterval;

	[Token(Token = "0x40000D0")]
	[FieldOffset(Offset = "0x1C")]
	public bool showMedian;

	[Token(Token = "0x40000D1")]
	[FieldOffset(Offset = "0x20")]
	public float medianLearnrate;

	[Token(Token = "0x40000D2")]
	[FieldOffset(Offset = "0x24")]
	private float accum;

	[Token(Token = "0x40000D3")]
	[FieldOffset(Offset = "0x28")]
	private int frames;

	[Token(Token = "0x40000D4")]
	[FieldOffset(Offset = "0x2C")]
	private float timeleft;

	[Token(Token = "0x40000D5")]
	[FieldOffset(Offset = "0x30")]
	private float currentFPS;

	[Token(Token = "0x40000D6")]
	[FieldOffset(Offset = "0x34")]
	private float median;

	[Token(Token = "0x40000D7")]
	[FieldOffset(Offset = "0x38")]
	private float average;

	[Token(Token = "0x40000D8")]
	[FieldOffset(Offset = "0x40")]
	private Text uguiText;

	[Token(Token = "0x17000008")]
	public float CurrentFPS
	{
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0xA05BBC", Offset = "0xA05BBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.currentFPS;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return CurrentFPS;
		}
	}

	[Token(Token = "0x17000009")]
	public float FPSMedian
	{
		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xA05BC4", Offset = "0xA05BC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.median;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return FPSMedian;
		}
	}

	[Token(Token = "0x1700000A")]
	public float FPSAverage
	{
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xA05BCC", Offset = "0xA05BCC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.average;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return FPSAverage;
		}
	}

	[Token(Token = "0x60000B6")]
	[Address(RVA = "0xA05BD4", Offset = "0xA05BD4", Length = "0x60")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF6F50]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C91]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.uguiText = v43;\n\tthis.timeleft = this.updateInterval;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		Text component = GetComponent<Text>();
		uguiText = component;
		timeleft = updateInterval;
	}

	[Token(Token = "0x60000B7")]
	[Address(RVA = "0xA05C34", Offset = "0xA05C34", Length = "0x1E4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EAB1E0]);\n\tv29 = *([v28 @ X8_v21]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021C92]) = v48;\nL_0018:\n\tv49 = this.timeleft;\n\tv51 = UnityEngine.Time::get_deltaTime();\n\tv51 = this.timeleft - v51;\n\tthis.timeleft = v51;\n\tv51 = UnityEngine.Time::get_timeScale();\n\tv51 = UnityEngine.Time::get_deltaTime();\n\tv51 = v51 / v51;\n\tv51 = this.accum + v51;\n\tv63 = this.frames + 1;\n\tv64 = this.timeleft < 0;\n\tv65 = ~v64;\n\tv68 = this.timeleft == 0;\n\tthis.accum = v51;\n\tthis.frames = v63;\n\tv73 = ~v68;\n\tv74 = v65 & v73;\n\tif (v74) goto L_0095;\n\tv49 = v51 / v63;\n\tthis.currentFPS = v49;\n\tgoto L_004F;\n\tv135 = *([v81 @ X0_v6+E0]);\n\tv136 = v76;\n\tv137 = v79;\n\tv138 = v135 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_004F;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v32, v33, v34, v35, v36, v37, v136, v137, v40, v41, v42, v43, v44, v45);\n\tv141 = *([v22 @ X19_v1 (FPSDisplay)+38]);\n\tv143 = *([v22 @ X19_v1 (FPSDisplay)+30]);\nL_004F:\n\tv150 = UnityEngine.Mathf::Abs(v49);\n\tv176 = v150 - this.average;\n\tv177 = v176 * 0.1f;\n\tv178 = this.average + v177;\n\tv51 = v51 - this.median;\n\tthis.average = v178;\n\tv51 = UnityEngine.Mathf::Sign(v51);\n\tv51 = this.currentFPS;\n\tv51 = v51 - this.median;\n\tv112 = UnityEngine.Mathf::Abs(v51);\n\tv51 = this.average * this.medianLearnrate;\n\tv51 = UnityEngine.Mathf::Min(v51, v112);\n\tv51 = v51 * v51;\n\tv49 = this.median + v51;\n\tthis.median = v49;\n\tv192 = ~this.showMedian;\n\tv193 = ~v192;\n\tif (v193) goto L_006F;\n\tv49 = this.currentFPS;\nL_006F:\n\t// 111 Box v198 @ X0_v11 (System.Object), typeof(System.Single), &v49 @ V8_v1 (System.Single)\n\tv51 = 1000f / v49;\n\t// 119 Box v203 @ X0_v13 (System.Object), typeof(System.Single), &v51 @ V0_v1 (System.Single)\n\tv208 = System.String::Format(\"{0:F2} FPS ({1:F1} ms)\", v198, v203);\n\tv119 = UnityEngine.UI.Text::set_text(this.uguiText, v208);\n\tthis.accum = 0f;\n\tthis.timeleft = this.updateInterval;\nL_0095:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		float num = timeleft;
		float deltaTime = Time.deltaTime;
		deltaTime = timeleft - deltaTime;
		timeleft = deltaTime;
		deltaTime = Time.timeScale;
		deltaTime = Time.deltaTime;
		deltaTime /= deltaTime;
		deltaTime = accum + deltaTime;
		int num2 = frames + 1;
		bool flag = timeleft < 0f;
		bool flag2 = !flag;
		bool flag3 = timeleft == 0f;
		accum = deltaTime;
		frames = num2;
		bool flag4 = !flag3;
		if (!(flag2 && flag4))
		{
			num = (currentFPS = deltaTime / (float)num2);
			deltaTime = num;
			float num3 = Mathf.Abs(num);
			float num4 = num3 - FPSAverage;
			float num5 = num4 * 0.1f;
			float num6 = FPSAverage + num5;
			deltaTime -= FPSMedian;
			average = num6;
			deltaTime = Mathf.Sign(deltaTime);
			deltaTime = CurrentFPS;
			deltaTime -= FPSMedian;
			float b = Mathf.Abs(deltaTime);
			deltaTime = FPSAverage * medianLearnrate;
			deltaTime = Mathf.Min(deltaTime, b);
			deltaTime *= deltaTime;
			num = (median = FPSMedian + deltaTime);
			if (!showMedian)
			{
				num = CurrentFPS;
			}
			object arg = num;
			deltaTime = 1000f / num;
			object arg2 = deltaTime;
			string text = $"{arg:F2} FPS ({arg2:F1} ms)";
			uguiText.text = text;
			accum = 0f;
			timeleft = updateInterval;
		}
	}

	[Token(Token = "0x60000B8")]
	[Address(RVA = "0xA05E18", Offset = "0xA05E18", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.median = 0f;\n\treturn;\n")]
	public void ResetMedianAndAverage()
	{
		median = 0f;
	}

	[Token(Token = "0x60000B9")]
	[Address(RVA = "0xA05E20", Offset = "0xA05E20", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateInterval = 0.5f;\n\tthis.medianLearnrate = 0.05f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public FPSDisplay()
	{
		updateInterval = 0.5f;
		medianLearnrate = 0.05f;
	}
}
