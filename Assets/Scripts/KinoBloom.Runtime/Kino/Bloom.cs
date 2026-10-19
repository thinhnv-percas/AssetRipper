using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Kino
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(Camera))]
	[ImageEffectAllowedInSceneView]
	[Token(Token = "0x2000004")]
	public class Bloom : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Filters out pixels under this level of brightness.")]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private float _threshold;

		[SerializeField]
		[Range(0f, 1f)]
		[Tooltip("Makes transition between under/over-threshold gradual.")]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x24")]
		private float _softKnee;

		[SerializeField]
		[Range(1f, 7f)]
		[Tooltip("Changes extent of veiling effects\nin a screen resolution-independent fashion.")]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x28")]
		private float _radius;

		[SerializeField]
		[Tooltip("Blend factor of the result image.")]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x2C")]
		private float _intensity;

		[SerializeField]
		[Tooltip("Controls filter quality and buffer resolution.")]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x30")]
		private bool _highQuality;

		[SerializeField]
		[Tooltip("Reduces flashing noise with an additional filter.")]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x31")]
		private bool _antiFlicker;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x38")]
		private Shader _shader;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x40")]
		private Material _material;

		[Token(Token = "0x400000E")]
		private const int kMaxIterations = 16;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x48")]
		private RenderTexture[] _blurBuffer1;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x50")]
		private RenderTexture[] _blurBuffer2;

		[Token(Token = "0x17000001")]
		public float thresholdGamma
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x7734A2C", Offset = "0x7734A2C", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Mathf::Max(this._threshold, 0f);\n\treturn returnVal1;\n")]
			get
			{
				return Mathf.Max(_threshold, 0f);
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x7734A3C", Offset = "0x7734A3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._threshold = value;\n\treturn;\n")]
			set
			{
				_threshold = value;
			}
		}

		[Token(Token = "0x17000002")]
		public float thresholdLinear
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x7734A44", Offset = "0x7734A44", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = UnityEngine.Mathf::Max(this._threshold, 0f);\n\treturnVal1 = UnityEngine.Mathf::GammaToLinearSpace(v3);\n\treturn returnVal1;\n")]
			get
			{
				float value = Mathf.Max(_threshold, 0f);
				return Mathf.GammaToLinearSpace(value);
			}
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x7734A60", Offset = "0x7734A60", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Mathf::LinearToGammaSpace(value);\n\tthis._threshold = v13;\n\treturn;\n")]
			set
			{
				float num = Mathf.LinearToGammaSpace(value);
				thresholdGamma = num;
			}
		}

		[Token(Token = "0x17000003")]
		public float softKnee
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x7734A90", Offset = "0x7734A90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.softKnee;\n")]
			get
			{
				return _softKnee;
			}
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x7734A98", Offset = "0x7734A98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.softKnee = value;\n\treturn;\n")]
			set
			{
				_softKnee = value;
			}
		}

		[Token(Token = "0x17000004")]
		public float radius
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x7734AA0", Offset = "0x7734AA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.radius;\n")]
			get
			{
				return _radius;
			}
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x7734AA8", Offset = "0x7734AA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.radius = value;\n\treturn;\n")]
			set
			{
				_radius = value;
			}
		}

		[Token(Token = "0x17000005")]
		public float intensity
		{
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x7734AB0", Offset = "0x7734AB0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Mathf::Max(this._intensity, 0f);\n\treturn returnVal1;\n")]
			get
			{
				return Mathf.Max(_intensity, 0f);
			}
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x7734AC0", Offset = "0x7734AC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._intensity = value;\n\treturn;\n")]
			set
			{
				_intensity = value;
			}
		}

		[Token(Token = "0x17000006")]
		public bool highQuality
		{
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x7734AC8", Offset = "0x7734AC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.highQuality;\n")]
			get
			{
				return _highQuality;
			}
			[Token(Token = "0x600000E")]
			[Address(RVA = "0x7734AD0", Offset = "0x7734AD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.highQuality = value;\n\treturn;\n")]
			set
			{
				_highQuality = value;
			}
		}

		[Token(Token = "0x17000007")]
		public bool antiFlicker
		{
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x7734AD8", Offset = "0x7734AD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.antiFlicker;\n")]
			get
			{
				return _antiFlicker;
			}
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x7734AE0", Offset = "0x7734AE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.antiFlicker = value;\n\treturn;\n")]
			set
			{
				_antiFlicker = value;
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x7734A88", Offset = "0x7734A88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Mathf::LinearToGammaSpace(x);\n\treturn returnVal1;\n")]
		private float LinearToGamma(float x)
		{
			return Mathf.LinearToGammaSpace(x);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x7734A58", Offset = "0x7734A58", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Mathf::GammaToLinearSpace(x);\n\treturn returnVal1;\n")]
		private float GammaToLinear(float x)
		{
			return Mathf.GammaToLinearSpace(x);
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x7734AE8", Offset = "0x7734AE8", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0016;\nL_0016:\n\tv101 = 0xB291000 + 0x8C8;\n\tv56 = UnityEngine.Object::op_Implicit(this._shader);\n\tv66 = v56 == 0;\n\tif (v66) goto L_003E;\n\tv103 = this._shader;\n\tgoto L_0041;\nL_003E:\n\tv93 = UnityEngine.Shader::Find(\"Hidden/Kino/Bloom\");\n\tv101 = v101;\n\tv103 = v93;\n\tUnityEngine.Object::set_hideFlags(this._material, 0x34);\n\treturn;\nL_0041:\n\tv106 = new *([v101 @ X21_v3 (System.Int32)])();\n\tUnityEngine.Material::.ctor(v106, v103);\n\tthis._material = v106;\n")]
		private void OnEnable()
		{
			int num = 187240448 + 2248;
			Shader shader;
			if ((bool)_shader)
			{
				shader = _shader;
			}
			else
			{
				Shader shader2 = Shader.Find("Hidden/Kino/Bloom");
				num = num;
				shader = shader2;
			}
			Material material = new Material(shader);
			_material = material;
			_material.hideFlags = HideFlags.DontSave;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x7734BFC", Offset = "0x7734BFC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_001E;\nL_001E:\n\tUnityEngine.Object::DestroyImmediate(this._material);\n\treturn;\n")]
		private void OnDisable()
		{
			UnityEngine.Object.DestroyImmediate(_material);
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x7734C8C", Offset = "0x7734C8C", Length = "0x858")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tgoto L_001F;\nL_001F:\n\tv83 = UnityEngine.Application::get_isMobilePlatform();\n\tv76 = source == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0050;\n\tgoto L_0389;\nL_0050:\n\tv92 = UnityEngine.RenderTexture::get_width(source);\n\tv98 = UnityEngine.RenderTexture::get_height(source);\n\tv100 = v92 >> 0x1F;\n\tv101 = v92 + v100;\n\tv102 = v101 >> 1;\n\tv103 = v98 >> 0x1F;\n\tv104 = v98 + v103;\n\tv105 = v104 >> 1;\n\tv108 = this.highQuality == 0;\n\tv111 = ~v108;\n\tv112 = ~v111;\n\tif (v112) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv285 = v98;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv285 = v105;\nL_FFFFFFFF:\n\tv397 = v92;\n\tgoto L_0075;\nL_FFFFFFFF:\n\tv397 = v102;\nL_FFFFFFFF:\n\tv449 = 7;\n\tgoto L_008A;\nL_FFFFFFFF:\n\tv449 = 9;\nL_009A:\n\tv858 = System.Math::Log(v285, 2d);\n\tv861 = this.radius + v858;\n\tv272 = v861 + -8f;\n\tv867 = v272 == 0x7F800000;\n\tv874 = ~v867;\n\tif (v874) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv503 = 0xFFFFFFFF80000000;\n\tgoto L_00B4;\nL_FFFFFFFF:\n\tv503 = v272;\nL_FFFFFFFF:\n\tv510 = v503;\n\tgoto L_00C6;\nL_FFFFFFFF:\n\tv510 = 0x10;\nL_FFFFFFFF:\n\tv228 = v510;\n\tgoto L_00D8;\nL_FFFFFFFF:\n\tv228 = 1;\n\tUnityEngine.Material::SetFloat(this._material, \"_Threshold\", v279);\n\tv903 = v279 * this.softKnee;\n\tv906 = v903 + 0x3727C5AC;\n\tv201 = 0.25f / v906;\n\tv908 = v906 + v906;\n\tv909 = v279 - v906;\n\t// 247 MakeStruct v197 @ AGG7734EDC_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v909 @ V0_v15 (System.Single), v908 @ V1_v10 (System.Single), v201 @ V2_v4 (System.Single), 0\n\tUnityEngine.Material::SetVector(this._material, \"_Curve\", v197);\n\tv913 = this.highQuality == 0;\n\tv914 = ~v913;\nL_FFFFFFFF:\n\tv226 = 0;\n\tif (v914) goto L_0118;\n\tif (this.antiFlicker) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv226 = 0;\n\tgoto L_0118;\nL_FFFFFFFF:\n\tv226 = -0.5f;\nL_0118:\n\tUnityEngine.Material::SetFloat(this._material, \"_PrefilterOffs\", v226);\n\tv933 = v272 + 0.5f;\n\tv281 = v933 - v503;\n\tUnityEngine.Material::SetFloat(this._material, \"_SampleScale\", v281);\n\tv282 = UnityEngine.Mathf::Max(this._intensity, 0f);\n\tUnityEngine.Material::SetFloat(this._material, \"_Intensity\", v282);\n\tv945 = UnityEngine.RenderTexture::GetTemporary(v397, v285, 0, v449);\n\tgoto L_0148;\nL_0148:\n\tUnityEngine.Graphics::Blit(source, v945, this._material, this.antiFlicker);\n\tv399 = this._blurBuffer1;\n\tv955 = UnityEngine.RenderTexture::get_width(v945);\n\tv960 = UnityEngine.RenderTexture::get_height(v945);\n\tv961 = v955 >> 0x1F;\n\tv962 = v955 + v961;\n\tv515 = v962 >> 1;\n\tv388 = v960 >> 0x1F;\n\tv432 = v960 + v388;\n\tv409 = v432 >> 1;\n\tv457 = UnityEngine.RenderTexture::GetTemporary(v515, v409, 0, v449);\n\tv964 = v457 == 0;\n\tif (v964) goto L_0173;\n\tv723 = 0x21C11D0(v457, UnityEngine.RenderTexture, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv727 = v723 == 0;\n\tif (v727) goto L_038B;\nL_0173:\n\tv399[0] = v457;\n\tv350 = this.antiFlicker == 0;\n\tv302 = ~v350;\n\tv294 = ~v302;\n\tif (v294) goto L_FFFFFFFF;\n\tv400 = 2 + 1;\n\tgoto L_0189;\nL_FFFFFFFF:\n\tv400 = 2;\n\tgoto L_019C;\nL_019C:\n\tUnityEngine.Graphics::Blit(v945, v532[0], this._material, v400);\n\tv545 = this._blurBuffer1;\n\tv993 = v503 < 2;\nL_FFFFFFFF:\n\tv403 = v545[0];\n\tif (v993) goto L_02BA;\nL_FFFFFFFF:\n\tv286 = 0x28;\nL_FFFFFFFF:\n\tv401 = v545[0];\nL_FFFFFFFF:\n\tv504 = 1;\nL_01BA:\n\tv1031 = UnityEngine.Texture::get_width(v401);\n\tv1037 = UnityEngine.Texture::get_height(v401);\n\tv1038 = v1031 >> 0x1F;\n\tv1039 = v1031 + v1038;\n\tv1040 = v1039 >> 1;\n\tv390 = v1037 >> 0x1F;\n\tv435 = v1037 + v390;\n\tv1041 = v435 >> 1;\n\tv1043 = UnityEngine.RenderTexture::GetTemporary(v1040, v1041, 0, v449);\n\tv1056 = v1043 == 0;\n\tif (v1056) goto L_01E0;\n\tv724 = 0x21C11D0(v1043, UnityEngine.RenderTexture, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv728 = v724 == 0;\n\tif (v728) goto L_038B;\nL_01E0:\n\t*([v545 @ X26_v9 (UnityEngine.RenderTexture[])+v286 @ X22_v11 (System.Int32)]) = v1043;\n\tv518 = this._blurBuffer1;\n\tgoto L_01FF;\nL_01FF:\n\tUnityEngine.Graphics::Blit(v401, *([v518 @ X8_v62 (UnityEngine.RenderTexture[])+v286 @ X22_v11 (System.Int32)]), this._material, 4);\n\tv545 = this._blurBuffer1;\n\tv504 = v504 + 1;\n\tv286 = v286 + 8;\n\tv1016 = v228 != v504;\nL_FFFFFFFF:\n\tv401 = *([v545 @ X26_v9 (UnityEngine.RenderTexture[])+v286 @ X22_v11 (System.Int32)]);\n\tif (v1016) goto L_01BA;\n\tv505 = v228 - 1;\nL_FFFFFFFF:\n\tv402 = *([v545 @ X26_v9 (UnityEngine.RenderTexture[])+v286 @ X22_v11 (System.Int32)]);\n\tv505 = v505 - 1;\n\tUnityEngine.Material::SetTexture(this._material, \"_BaseTex\", v520[v505 @ X21_v20 (System.Double)]);\n\tv230 = this._blurBuffer2;\n\tv1139 = UnityEngine.Texture::get_width(v520[v505 @ X21_v20 (System.Double)]);\n\tv1142 = UnityEngine.Texture::get_height(v520[v505 @ X21_v20 (System.Double)]);\n\tv464 = UnityEngine.RenderTexture::GetTemporary(v1139, v1142, 0, v449);\n\tv1150 = v464 == 0;\n\tif (v1150) goto L_0264;\n\tv725 = 0x21C11D0(v464, UnityEngine.RenderTexture, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv729 = v725 == 0;\n\tif (v729) goto L_038B;\nL_0264:\n\tv230[v505 @ X21_v20 (System.Double)] = v464;\n\tv364 = this.highQuality == 0;\n\tv305 = ~v364;\n\tv296 = ~v305;\n\tif (v296) goto L_FFFFFFFF;\n\tv560 = 5 + 1;\n\tgoto L_0278;\nL_FFFFFFFF:\n\tv560 = 5;\n\tgoto L_0295;\nL_0295:\n\tUnityEngine.Graphics::Blit(v402, v533[v505 @ X21_v20 (System.Double)], this._material, v560);\n\tv523 = this._blurBuffer2;\n\tv1001 = v505 > 0;\nL_FFFFFFFF:\n\tv403 = v523[v505 @ X21_v20 (System.Double)];\nL_FFFFFFFF:\n\tv402 = v523[v505 @ X21_v20 (System.Double)];\n\tif (v1001) goto L_021E;\nL_02BA:\n\tUnityEngine.Material::SetTexture(this._material, \"_BaseTex\", source);\n\tv1049 = this.highQuality == 0;\n\tv1055 = ~v1049;\n\tv298 = ~v1055;\n\tif (v298) goto L_FFFFFFFF;\n\tv1062 = 7 + 1;\n\tgoto L_02D2;\nL_FFFFFFFF:\n\tv1062 = 7;\nL_02DB:\n\tUnityEngine.Graphics::Blit(v403, destination, this._material, v1062);\nL_FFFFFFFF:\n\tv289 = 0x20;\n\tgoto L_02F4;\nL_02F4:\n\tv1096 = UnityEngine.Object::op_Inequality(*([v525 @ X8_v45 (UnityEngine.RenderTexture[])+v289 @ X22_v7 (System.Int32)]), 0);\n\tv1099 = ~v1096;\n\tv1100 = ~v1099;\n\tif (v1100) goto L_0300;\n\tgoto L_0311;\nL_0300:\n\tv526 = this._blurBuffer1;\n\tUnityEngine.RenderTexture::ReleaseTemporary(*([v526 @ X8_v54 (UnityEngine.RenderTexture[])+v289 @ X22_v7 (System.Int32)]));\nL_0311:\n\tv527 = this._blurBuffer2;\n\tgoto L_0326;\nL_0326:\n\tv1123 = UnityEngine.Object::op_Inequality(*([v527 @ X8_v48 (UnityEngine.RenderTexture[])+v289 @ X22_v7 (System.Int32)]), 0);\n\tv1127 = ~v1123;\n\tv1128 = ~v1127;\n\tif (v1128) goto L_0334;\n\tgoto L_0345;\nL_0334:\n\tv528 = this._blurBuffer2;\n\tUnityEngine.RenderTexture::ReleaseTemporary(*([v528 @ X8_v53 (UnityEngine.RenderTexture[])+v289 @ X22_v7 (System.Int32)]));\nL_0345:\n\tv529 = this._blurBuffer1;\n\t*([v529 @ X8_v51 (UnityEngine.RenderTexture[])+v289 @ X22_v7 (System.Int32)]) = 0;\n\tv530 = this._blurBuffer2;\n\t*([v530 @ X8_v52 (UnityEngine.RenderTexture[])+v289 @ X22_v7 (System.Int32)]) = 0;\n\tv289 = v289 + 8;\n\tv801 = v289 != 0xA0;\n\tif (v801) goto L_02DE;\n\tUnityEngine.RenderTexture::ReleaseTemporary(v945);\n\treturn;\nL_0389:\n\tv564 = new System.NullReferenceException();\n\tv680 = new System.IndexOutOfRangeException();\nL_038B:\n\tv738 = new System.ArrayTypeMismatchException();\n\tthrow v738;\nL_006A:\n\tv681 = ~v108;\n\tv682 = ~v681;\n\tif (v682) goto L_FFFFFFFF;\nL_0075:\n\tv750 = v83 == 0;\n\tv757 = ~v750;\n\tv758 = ~v757;\n\tif (v758) goto L_FFFFFFFF;\nL_008A:\n\tgoto L_0095;\nL_00B4:\n\tv879 = v503 - 0x10;\n\tv880 = v879 < 0;\n\tv882 = v503 ^ 0x10;\n\tv883 = v503 ^ v879;\n\tv884 = v882 & v883;\n\tv885 = v884 < 0;\n\tv887 = v880 == v885;\n\tv888 = ~v887;\n\tv889 = ~v888;\n\tif (v889) goto L_FFFFFFFF;\nL_00C6:\n\tv254 = v510 - 1;\n\tv367 = v254 < 0;\n\tv348 = v254 == 0;\n\tv235 = v510 ^ 1;\n\tv178 = v510 ^ v254;\n\tv159 = v235 & v178;\n\tv310 = v159 < 0;\n\tv893 = v367 == v310;\n\tv118 = ~v348;\n\tv301 = v893 & v118;\n\tv292 = ~v301;\n\tif (v292) goto L_FFFFFFFF;\nL_00D8:\n\tv897 = UnityEngine.Mathf::Max(this._threshold, 0f);\n\tv279 = UnityEngine.Mathf::GammaToLi\n// ... truncated")]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Bloom::OnRenderImage");
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x77354E4", Offset = "0x77354E4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tthis._blurBuffer2 = v56;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0018:\n\tthis._threshold = *([93AF840]);\n\tthis.highQuality = 0x101;\n\t// 29 NewArr v49 @ X0_v3 (UnityEngine.RenderTexture[]), typeof(UnityEngine.RenderTexture[]), 16\n\tthis._blurBuffer1 = v49;\n\t// 37 NewArr v56 @ X0_v8 (UnityEngine.RenderTexture[]), typeof(UnityEngine.RenderTexture[]), 16\n")]
		public Bloom()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [93AF840]");
			thresholdGamma = 0f;
			_highQuality = true;
			_antiFlicker = true;
			RenderTexture[] blurBuffer = new RenderTexture[16];
			_blurBuffer1 = blurBuffer;
			RenderTexture[] blurBuffer2 = new RenderTexture[16];
			_blurBuffer2 = blurBuffer2;
		}
	}
}
