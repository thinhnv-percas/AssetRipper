using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Tayx.Graphy.Audio
{
	[Token(Token = "0x2000040")]
	public class G_AudioMonitor : MonoBehaviour
	{
		[Token(Token = "0x40001C2")]
		private const float m_refValue = 1f;

		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x18")]
		private GraphyManager m_graphyManager;

		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x20")]
		private AudioListener m_audioListener;

		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x28")]
		private GraphyManager.LookForAudioListener m_findAudioListenerInCameraIfNull;

		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x2C")]
		private FFTWindow m_FFTWindow;

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x30")]
		private int m_spectrumSize;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x38")]
		private float[] m_spectrum;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x40")]
		private float[] m_spectrumHighestValues;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x48")]
		private float m_maxDB;

		[Token(Token = "0x17000041")]
		public float[] Spectrum
		{
			[Token(Token = "0x60001C4")]
			[Address(RVA = "0xB0E528", Offset = "0xB0E528", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_spectrum;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Spectrum;
			}
		}

		[Token(Token = "0x17000042")]
		public float[] SpectrumHighestValues
		{
			[Token(Token = "0x60001C5")]
			[Address(RVA = "0xB0E530", Offset = "0xB0E530", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_spectrumHighestValues;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SpectrumHighestValues;
			}
		}

		[Token(Token = "0x17000043")]
		public float MaxDB
		{
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0xB0E538", Offset = "0xB0E538", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_maxDB;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxDB;
			}
		}

		[Token(Token = "0x17000044")]
		public bool SpectrumDataAvailable
		{
			[Token(Token = "0x60001C7")]
			[Address(RVA = "0xB0C9A4", Offset = "0xB0C9A4", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ED3738]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022503]) = v38;\nL_001A:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\treturnVal1 = UnityEngine.Object::op_Inequality(this.m_audioListener, 0);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return m_audioListener != null;
			}
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0xB0E540", Offset = "0xB0E540", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.Audio.G_AudioMonitor::Init(this);\n\treturn;\n")]
		private void Awake()
		{
			Init();
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0xB0E5FC", Offset = "0xB0E5FC", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1EDD050]);\n\tv33 = *([v32 @ X8_v28]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022504]) = v52;\nL_0021:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_002A:\n\tv70 = UnityEngine.Object::op_Inequality(this.m_audioListener, 0);\n\tv72 = v70 == 0;\n\tif (v72) goto L_0065;\n\tUnityEngine.AudioListener::GetOutputData(this.m_spectrum, 0);\n\tv81 = this.m_spectrum;\n\tv105 = v81.Length < 1;\n\tif (v105) goto L_FFFFFFFF;\nL_0045:\n\tv305 = v285 < v81.Length;\n\tv306 = ~v305;\n\tif (v306) goto L_0116;\n\tv286 = v285 + 1;\n\tv282 = v81[v285 @ X9_v13 (System.Int32)] * v81[v285 @ X9_v13 (System.Int32)];\n\tv143 = v143 + v282;\n\tv288 = v286 < v81.Length;\n\tif (v288) goto L_0045;\n\tgoto L_FFFFFFFF;\nL_0065:\n\tgoto L_006E;\n\tv83 = *([v76 @ X0_v7+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_006E;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v76, v68, v69, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_006E:\n\tv93 = UnityEngine.Object::op_Equality(this.m_audioListener, 0);\n\tv221 = v93 == 0;\n\tif (v221) goto L_0115;\n\tv280 = this.m_findAudioListenerInCameraIfNull == 0;\n\tv264 = ~v280;\n\tif (v264) goto L_0115;\n\tv262 = Tayx.Graphy.Audio.G_AudioMonitor::FindAudioListener(v93);\n\tthis.m_audioListener = v262;\n\tgoto L_0115;\n\tgoto L_0088;\n\tv424 = *([v326 @ X0_v17 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv425 = v424 == 0;\n\tv426 = ~v425;\n\tgoto L_0088;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v326, v74, v75, v37, v38, v39, v40, v41, v314, v43, v44, v45, v46, v47, v48, v49);\n\tv431 = *([v81 @ X21_v5 (System.Single[])+18]);\nL_0088:\n\tv433 = v143 / v81.Length;\n\tv438 = UnityEngine.Mathf::Sqrt(v433);\n\tv190 = v438 - v438;\n\tv175 = v438 ^ v438;\n\tv170 = v438 ^ v190;\n\tv165 = v175 & v170;\n\tv160 = v165 < 0;\n\tv155 = ~v160;\n\tif (v155) goto L_0097;\n\tv439 = 0x6D2F50(v439, 0, 0, v37, v38, v39, v40, v41, v433, v433, v44, v45, v46, v47, v48, v49);\nL_0097:\n\tv440 = 0x6D22D0(v439, 0, 0, v37, v38, v39, v40, v41, v438, v433, v44, v45, v46, v47, v48, v49);\n\tv442 = v438 * 20f;\n\tv139 = UnityEngine.Mathf::Max(v442, -80f);\n\tthis.m_maxDB = v139;\n\tUnityEngine.AudioListener::GetSpectrumData(this.m_spectrum, 0, this.m_FFTWindow);\n\tv215 = this.m_spectrum;\nL_00B3:\n\tv156 = v199 >= v215.Length;\n\tif (v156) goto L_0115;\n\tv455 = v199 < v215.Length;\n\tv196 = ~v455;\n\tif (v196) goto L_0116;\n\tv124 = this.m_spectrumHighestValues;\n\tv456 = v199 < v124.Length;\n\tv415 = ~v456;\n\tif (v415) goto L_0116;\n\tv120 = v199 << 2;\n\tv459 = v124 + v120;\n\tv117 = v459 + 0x20;\n\tv153 = v215[v199 @ X21_v8 (System.Int32)] > *([v117 @ X23_v6]);\n\tif (v153) goto L_0101;\n\tv472 = UnityEngine.Time::get_deltaTime();\n\tgoto L_00EF;\n\tv480 = *([v476 @ X0_v25+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_00EF;\n\tv484 = \"il2cpp_codegen_runtime_class_init\"(v476, v203, v201, v128, v38, v39, v40, v41, v472, v132, v136, v45, v46, v47, v48, v49);\nL_00EF:\n\tv486 = *([v117 @ X23_v6]) * v472;\n\tv487 = v486 * -2f;\n\tv488 = *([v117 @ X23_v6]) + v487;\n\tv138 = UnityEngine.Mathf::Clamp(v488, 0f, 1f);\n\tv489 = v199 < v124.Length;\n\tv416 = ~v489;\n\tif (v416) goto L_0116;\nL_0101:\n\t*([v117 @ X23_v6]) = v138;\n\tv215 = this.m_spectrum;\n\tv199 = v199 + 1;\n\tv475 = this.m_spectrum == 0;\n\tv209 = ~v475;\n\tif (v209) goto L_00B3;\n\tthrow System.NullReferenceException;\nL_0115:\n\treturn;\nL_0116:\n\tv423 = new System.IndexOutOfRangeException();\n\tthrow v423;\n\treturn;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_03e0: Expected I, but got O
			//IL_0155: Expected O, but got I4
			//IL_041f: Expected O, but got F4
			//IL_042c: Expected O, but got F4
			//IL_0282: Expected O, but got I
			//IL_0291: Expected O, but got I
			//IL_034d: Expected O, but got F4
			float[] spectrum;
			float num;
			if (m_audioListener != null)
			{
				AudioListener.GetOutputData(Spectrum, 0);
				spectrum = Spectrum;
				if (spectrum.Length >= 1)
				{
					num = 0f;
					int num2 = 0;
					while (num2 < spectrum.Length)
					{
						int num3 = num2 + 1;
						float num4 = spectrum[num2] * spectrum[num2];
						num += num4;
						bool flag = num3 < spectrum.Length;
						num2 = num3;
						if (flag)
						{
							continue;
						}
						goto IL_03d2;
					}
					goto IL_0396;
				}
				num = 0f;
				goto IL_03d2;
			}
			bool flag2 = m_audioListener == null;
			if (flag2 && m_findAudioListenerInCameraIfNull == GraphyManager.LookForAudioListener.ALWAYS)
			{
				AudioListener audioListener = ((G_AudioMonitor)flag2).FindAudioListener();
				m_audioListener = audioListener;
			}
			return;
			IL_03d2:
			IntPtr intPtr = (IntPtr)typeof(Mathf);
			float num5 = num / (float)spectrum.Length;
			float num6 = Mathf.Sqrt(num5);
			float num7 = num6 - num6;
			object obj = num6 ^ num6;
			object obj2 = num6 ^ num7;
			int num8 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			if (num8 < 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				num6 = num5;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:log10f", "Method not found @6D22D0 (native log10f)");
			float a = num6 * 20f;
			float maxDB = Mathf.Max(a, -80f);
			m_maxDB = maxDB;
			AudioListener.GetSpectrumData(Spectrum, 0, m_FFTWindow);
			float[] spectrum2 = Spectrum;
			int num9 = 0;
			while (true)
			{
				if (num9 >= spectrum2.Length)
				{
					return;
				}
				if (num9 >= spectrum2.Length)
				{
					break;
				}
				float[] spectrumHighestValues = SpectrumHighestValues;
				if (num9 >= spectrumHighestValues.Length)
				{
					break;
				}
				int num10 = num9 << 2;
				object obj3 = (long)(IntPtr)spectrumHighestValues + (long)num10;
				object obj4 = (long)(IntPtr)obj3 + 32L;
				bool flag3 = spectrum2[num9] > (float)obj4;
				float num11 = spectrum2[num9];
				if (!flag3)
				{
					float deltaTime = Time.deltaTime;
					float num12 = (float)obj4 * deltaTime;
					float num13 = num12 * -2f;
					float value = (float)obj4 + num13;
					num11 = Mathf.Clamp(value, 0f, 1f);
					if (num9 >= spectrumHighestValues.Length)
					{
						break;
					}
				}
				obj4 = num11;
				spectrum2 = Spectrum;
				num9++;
				if (Spectrum == null)
				{
					throw new NullReferenceException();
				}
			}
			goto IL_0396;
			IL_0396:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0xB0E914", Offset = "0xB0E914", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDB4C8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022505]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
			SceneManager.sceneLoaded -= value;
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0xB0E220", Offset = "0xB0E220", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFC550]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022506]) = v38;\nL_0013:\n\tv39 = this.m_graphyManager;\n\tthis.m_findAudioListenerInCameraIfNull = v39.m_findAudioListenerInCameraIfNull;\n\tthis.m_audioListener = v39.m_audioListener;\n\tthis.m_FFTWindow = v39.m_FFTWindow;\n\tthis.m_spectrumSize = v39.m_spectrumSize;\n\tgoto L_002D;\n\tv53 = *([v47 @ X0_v4+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_002D;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv63 = UnityEngine.Object::op_Equality(v39.m_audioListener, 0);\n\tv65 = v63 == 0;\n\tif (v65) goto L_0042;\n\tv113 = this.m_findAudioListenerInCameraIfNull == 2;\n\tif (v113) goto L_0042;\n\tv119 = Tayx.Graphy.Audio.G_AudioMonitor::FindAudioListener(v63);\n\tthis.m_audioListener = v119;\nL_0042:\n\t// 66 NewArr v124 @ X0_v10 (System.Single[]), typeof(System.Single[]), this.m_spectrumSize (System.Int32)\n\tthis.m_spectrum = v124;\n\t// 70 NewArr v98 @ X0_v12 (System.Single[]), typeof(System.Single[]), this.m_spectrumSize (System.Int32)\n\tthis.m_spectrumHighestValues = v98;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateParameters()
		{
			//IL_009e: Expected O, but got I4
			GraphyManager graphyManager = m_graphyManager;
			m_findAudioListenerInCameraIfNull = graphyManager.FindAudioListenerInCameraIfNull;
			m_audioListener = graphyManager.AudioListener;
			m_FFTWindow = graphyManager.FftWindow;
			m_spectrumSize = graphyManager.SpectrumSize;
			bool flag = graphyManager.AudioListener == null;
			if (flag && m_findAudioListenerInCameraIfNull != GraphyManager.LookForAudioListener.NEVER)
			{
				AudioListener audioListener = ((G_AudioMonitor)flag).FindAudioListener();
				m_audioListener = audioListener;
			}
			float[] spectrum = new float[m_spectrumSize];
			m_spectrum = spectrum;
			float[] spectrumHighestValues = new float[m_spectrumSize];
			m_spectrumHighestValues = spectrumHighestValues;
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0xB0D248", Offset = "0xB0D248", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECD4B0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, linear, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2022507]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, linear, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv53 = 0x6D22D0(UnityEngine.Mathf, methodInfo, v22, v23, v24, v25, v26, v27, linear, v28, v29, v30, v31, v32, v33, v34);\n\tv60 = linear * 20f;\n\treturnVal1 = UnityEngine.Mathf::Clamp(v60, -160f, 0f);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float lin2dB(float linear)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:log10f", "Method not found @6D22D0 (native log10f)");
			float value = linear * 20f;
			return Mathf.Clamp(value, -160f, 0f);
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xB0D2D0", Offset = "0xB0D2D0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = db + 160f;\n\treturnVal1 = v2 / 160f;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float dBNormalized(float db)
		{
			float num = db + 160f;
			return num / 160f;
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xB0E86C", Offset = "0xB0E86C", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = *([1EDD638]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022508]) = v35;\nL_0012:\n\tv37 = UnityEngine.Camera::get_main();\n\tgoto L_0024;\n\tv45 = *([v41 @ X8_v5+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0024;\n\tv56 = v41;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0024:\n\tv55 = UnityEngine.Object::op_Inequality(v37, 0);\n\tv60 = v55 == 0;\n\tif (v60) goto L_0035;\n\treturnVal1 = UnityEngine.Component::GetComponent(v37);\nL_0035:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AudioListener FindAudioListener()
		{
			Camera main = Camera.main;
			bool flag = main != null;
			bool flag2 = !flag;
			AudioListener result = null;
			if (!flag2)
			{
				result = main.GetComponent<AudioListener>();
			}
			return result;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xB0E990", Offset = "0xB0E990", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.m_findAudioListenerInCameraIfNull != 1;\n\tif (v20) goto L_0018;\n\tv21 = Tayx.Graphy.Audio.G_AudioMonitor::FindAudioListener(this);\n\tthis.m_audioListener = v21;\nL_0018:\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
		{
			if (m_findAudioListenerInCameraIfNull == GraphyManager.LookForAudioListener.ON_SCENE_LOAD)
			{
				AudioListener audioListener = FindAudioListener();
				m_audioListener = audioListener;
			}
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xB0E544", Offset = "0xB0E544", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF30F8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022509]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_transform(this);\n\tv44 = UnityEngine.Transform::get_root(v41);\n\tv53 = UnityEngine.Component::GetComponentInChildren(v44);\n\tthis.m_graphyManager = v53;\n\tTayx.Graphy.Audio.G_AudioMonitor::UpdateParameters(this);\n\tv80 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v80, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v80);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			Transform transform = base.transform;
			Transform root = transform.root;
			GraphyManager componentInChildren = root.GetComponentInChildren<GraphyManager>();
			m_graphyManager = componentInChildren;
			UpdateParameters();
			UnityAction<Scene, LoadSceneMode> value = OnSceneLoaded;
			SceneManager.sceneLoaded += value;
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0xB0E9C0", Offset = "0xB0E9C0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_findAudioListenerInCameraIfNull = 0x400000005;\n\tthis.m_spectrumSize = 0x200;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public G_AudioMonitor()
		{
			//IL_0015: Expected I4, but got I8
			base._002Ector();
			m_findAudioListenerInCameraIfNull = (GraphyManager.LookForAudioListener)5;
			m_spectrumSize = 512;
		}
	}
}
