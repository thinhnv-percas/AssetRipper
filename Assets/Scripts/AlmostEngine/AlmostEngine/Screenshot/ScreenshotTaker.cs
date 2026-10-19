using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000032")]
	public class ScreenshotTaker : MonoBehaviour
	{
		[Token(Token = "0x2000033")]
		public enum ColorFormat
		{
			[Token(Token = "0x4000143")]
			RGB = 0,
			[Token(Token = "0x4000144")]
			RGBA = 1
		}

		[Token(Token = "0x2000034")]
		public enum CaptureMode
		{
			[Token(Token = "0x4000146")]
			GAMEVIEW_RESIZING = 0,
			[Token(Token = "0x4000147")]
			RENDER_TO_TEXTURE = 1,
			[Token(Token = "0x4000148")]
			FIXED_GAME_VIEW = 2,
			[Token(Token = "0x4000149")]
			FIXED_SCENE_VIEW_EXPERIMENTAL = 3,
			[Token(Token = "0x400014A")]
			FIXED_SCENE_VIEW_WITH_GIZMOS_EXPERIMENTAL = 4
		}

		[Token(Token = "0x2000035")]
		public enum GameViewResizingWaitingMode
		{
			[Token(Token = "0x400014C")]
			FRAMES = 0,
			[Token(Token = "0x400014D")]
			TIME = 1
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000036")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400014E")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400014F")]
			public static Func<ScreenshotCamera, bool> _003C_003E9__28_0;

			[Token(Token = "0x4000150")]
			public static Func<ScreenshotCamera, Camera> _003C_003E9__28_1;

			[Token(Token = "0x4000151")]
			public static Func<ScreenshotOverlay, bool> _003C_003E9__43_0;

			[Token(Token = "0x6000102")]
			[Address(RVA = "0x3C3DE94", Offset = "0x3C3DE94", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new AlmostEngine.Screenshot.ScreenshotTaker+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000103")]
			[Address(RVA = "0x3C3DEF8", Offset = "0x3C3DEF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CCaptureCamerasToTexture_003Eb__28_0(ScreenshotCamera x)
			{
				if (x.m_Active && x.m_Camera != null)
				{
					return x.m_Camera.enabled;
				}
				return false;
			}

			internal Camera _003CCaptureCamerasToTexture_003Eb__28_1(ScreenshotCamera x)
			{
				return x.m_Camera;
			}

			internal bool _003CApplySettings_003Eb__43_0(ScreenshotOverlay x)
			{
				return x.m_Active;
			}

			internal void _003C_002Ecctor_003Eb__57_0(ScreenshotResolution res)
			{
			}

			internal void _003C_002Ecctor_003Eb__57_1(ScreenshotResolution res)
			{
			}

			internal void _003C_002Ecctor_003Eb__57_2(ScreenshotResolution res)
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003A")]
		private sealed class _003CCaptureAllCoroutine_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000159")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400015A")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400015B")]
			[FieldOffset(Offset = "0x20")]
			public List<ScreenshotResolution> resolutions;

			[Token(Token = "0x400015C")]
			[FieldOffset(Offset = "0x28")]
			public List<ScreenshotCamera> cameras;

			[Token(Token = "0x400015D")]
			[FieldOffset(Offset = "0x30")]
			public CaptureMode captureMode;

			[Token(Token = "0x400015E")]
			[FieldOffset(Offset = "0x38")]
			public List<ScreenshotOverlay> overlays;

			[Token(Token = "0x400015F")]
			[FieldOffset(Offset = "0x40")]
			public bool stopTime;

			[Token(Token = "0x4000160")]
			[FieldOffset(Offset = "0x48")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x4000161")]
			[FieldOffset(Offset = "0x50")]
			public bool captureGameUI;

			[Token(Token = "0x4000162")]
			[FieldOffset(Offset = "0x51")]
			public bool forceUICullingLayer;

			[Token(Token = "0x4000163")]
			[FieldOffset(Offset = "0x54")]
			public ColorFormat colorFormat;

			[Token(Token = "0x4000164")]
			[FieldOffset(Offset = "0x58")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x4000165")]
			[FieldOffset(Offset = "0x5C")]
			public int antiAliasing;

			[Token(Token = "0x4000166")]
			[FieldOffset(Offset = "0x60")]
			public bool disableHDRPFX;

			[Token(Token = "0x4000167")]
			[FieldOffset(Offset = "0x61")]
			public bool restore;

			[Token(Token = "0x4000168")]
			[FieldOffset(Offset = "0x68")]
			private List<ScreenshotResolution>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x4000169")]
			[FieldOffset(Offset = "0x80")]
			private ScreenshotResolution _003Cresolution_003E5__3;

			[Token(Token = "0x17000015")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000114")]
				[Address(RVA = "0x3C3EB5C", Offset = "0x3C3EB5C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000016")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000116")]
				[Address(RVA = "0x3C3EBA4", Offset = "0x3C3EBA4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000110")]
			[Address(RVA = "0x3C3B6B4", Offset = "0x3C3B6B4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureAllCoroutine_003Ed__25(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000111")]
			[Address(RVA = "0x3C3E144", Offset = "0x3C3E144", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.<>1__state + 3;\n\tv3 = v2 < 6;\n\tv4 = ~v3;\n\tv5 = v2 - 6;\n\tv7 = v5 == 0;\n\tv13 = 1 << v2;\n\tv15 = v13 & 0x61;\n\tv16 = ~v4;\n\tv17 = v16 | v7;\n\tv18 = ~v17;\n\tif (v18) goto L_FFFFFFFF;\n\tv36 = v15 == 0;\n\tgoto L_0022;\nL_FFFFFFFF:\n\tv36 = 1;\n\tgoto L_003A;\nL_0046:\n\treturn;\nL_0022:\n\tif (v36) goto L_0046;\nL_003A:\n\tthis.<>1__state = -1;\n\tv85 = this + 0x68;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v85);\n\treturn;\n")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CCaptureAllCoroutine_003Ed__25::Dispose");
			}

			[Token(Token = "0x6000112")]
			[Address(RVA = "0x3C3E1C8", Offset = "0x3C3E1C8", Length = "0x938")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tv72 = this.<>1__state == 1;\n\tif (v72) goto L_01D3;\n\tv87 = this.<>1__state == 0;\n\tv88 = ~v87;\nL_FFFFFFFF:\n\tv102 = 0;\n\tif (v88) goto L_FFFFFFFF;\n\tthis.<>1__state = -1;\n\tv101 = this.resolutions == 0;\n\tif (v101) goto L_024D;\n\tv211 = this.cameras;\n\tv328 = this.cameras == 0;\n\tif (v328) goto L_0258;\n\tv411 = v211.Count == 0;\n\tv412 = ~v411;\nL_FFFFFFFF:\n\tv589 = this;\n\tif (v412) goto L_0089;\n\tv572 = this.captureMode != 1;\nL_FFFFFFFF:\n\tv589 = this;\n\tif (v572) goto L_0089;\n\tv688 = UnityEngine.Camera::get_main();\n\tv724 = new AlmostEngine.Screenshot.ScreenshotCamera();\n\tAlmostEngine.Screenshot.ScreenshotCamera::.ctor(v724, v688);\n\tv586 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::Add(this.cameras, v724);\nL_FFFFFFFF:\n\tv152 = v724;\nL_FFFFFFFF:\n\tv589 = v49;\n\tv598 = v589.captureMode != 1;\n\tif (v598) goto L_00A2;\n\tv726 = AlmostEngine.UnityVersion::HasPro();\n\tv729 = v726 == 0;\n\tif (v729) goto L_02C0;\nL_00A2:\n\tgoto L_00B0;\n\tgoto L_00BE;\nL_00BE:\n\tUnityEngine.Debug::LogWarning(\"A capture process is already running.\");\nL_FFFFFFFF:\n\tv152 = 0;\n\tgoto L_01D9;\nL_00C1:\n\tthis.<>1__state = -3;\n\tgoto L_00CC;\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::Invoke(v93.onResolutionUpdateEndDelegate, v49.<resolution>5__3);\n\tv49.<resolution>5__3 = 0;\nL_FFFFFFFF:\n\tv678 = v49;\n\tv49.<resolution>5__3 = *([v49 @ stack_-48_v2 (AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25)+78]);\n\tv493 = v49.<resolution>5__3;\n\tv540 = v49.<resolution>5__3 == 0;\n\tif (v540) goto L_02D6;\n\tv666 = v493.m_Width < 1;\nL_FFFFFFFF:\n\tv678 = v49;\n\tif (v666) goto L_00DE;\n\tv504 = v493.m_Height <= 0;\nL_FFFFFFFF:\n\tv678 = v49;\n\tif (v504) goto L_00DE;\n\tgoto L_0112;\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::Invoke(v864.onResolutionUpdateStartDelegate, v49.<resolution>5__3);\n\tv363 = v49.colorFormat != 1;\n\tif (v363) goto L_01E9;\n\tv927 = ~v49.recomputeAlphaMask;\n\tif (v927) goto L_01E9;\n\tv544 = this.<>4__this == 0;\n\tif (v544) goto L_02E5;\n\tgoto L_013E;\n\tv971.resolution = v49.<resolution>5__3;\n\tv971.captureMode = v49.captureMode;\n\tv971.antiAliasing = v49.antiAliasing;\n\tv971.colorFormat = 1;\n\tv1005 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v971);\n\tv49.<>2__current = v1005;\nL_FFFFFFFF:\n\tv354 = 2;\nL_FFFFFFFF:\n\tv359 = v1005;\nL_FFFFFFFF:\n\tv393 = v49;\n\tgoto L_0216;\nL_0162:\n\tgoto L_016B;\n\tv811 = v49.captureMode == 0;\n\tv812 = ~v811;\nL_FFFFFFFF:\n\tv360 = Il2CppMethodInfo;\n\tif (v812) goto L_01A4;\n\tgoto L_0197;\nL_019D:\n\tUnityEngine.Debug::LogError(\"GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.\");\nL_FFFFFFFF:\n\tv360 = 0;\nL_01A4:\n\tgoto L_01A7;\nL_01A7:\n\tv845 = UnityEngine.Application::get_isPlaying();\n\tv552 = v845 & v49.stopTime;\n\tv879 = v552 & 1;\n\tv880 = v879 == 0;\n\tif (v880) goto L_01B7;\n\tv543 = this.<>4__this == 0;\n\tif (v543) goto L_02E3;\n\tUnityEngine.Time::set_timeScale(v53.m_PreviousTimeScale);\nL_01B7:\n\tgoto L_01BA;\nL_01BA:\n\tv932 = UnityEngine.Application::get_isEditor();\n\tv550 = v49.restore | v932;\n\tv940 = v550 == 0;\n\tif (v940) goto L_01CA;\n\tv541 = this.<>4__this == 0;\n\tif (v541) goto L_02DF;\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreSettings(this.<>4__this);\nL_01CA:\n\tgoto L_01D0;\nL_01D3:\n\tthis.<>1__state = -1;\nL_01DE:\n\tv404 = v400.m_IsRunning == 0;\n\tif (v404) goto L_0223;\n\tv49.<>2__current = 0;\n\tv49.<>1__state = 1;\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_02C9;\nL_01E9:\n\tv545 = this.<>4__this == 0;\n\tif (v545) goto L_02E7;\n\tgoto L_01F9;\n\tv955.resolution = v49.<resolution>5__3;\n\tv955.captureMode = v49.captureMode;\n\tv955.antiAliasing = v49.antiAliasing;\n\tv955.colorFormat = v49.colorFormat;\n\tv1000 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v955);\n\tv49.<>2__current = v1000;\nL_FFFFFFFF:\n\tv354 = 3;\nL_FFFFFFFF:\n\tv359 = v1000;\nL_FFFFFFFF:\n\tv393 = v49;\nL_0223:\n\tv449 = v49.captureMode == 0;\n\tif (v449) goto L_0263;\n\tgoto L_022D;\nL_0237:\n\tv739 = UnityEngine.Application::get_isPlaying();\n\tv548 = v739 & v49.stopTime;\n\tv758 = v548 & 1;\n\tv759 = v758 == 0;\n\tif (v759) goto L_0271;\n\tv546 = this.<>4__this == 0;\n\tif (v546) goto L_02EB;\n\tv799 = UnityEngine.Time::get_timeScale();\n\tv53.m_PreviousTimeScale = v799;\n\tUnityEngine.Time::set_timeScale(0f);\n\tgoto L_0271;\nL_024D:\n\tgoto L_0250;\nL_0250:\n\tv193 = 0xB2FB000 + 0x5A0;\n\tgoto L_02C6;\nL_0258:\n\tgoto L_025B;\nL_025B:\n\tv193 = 0xB2ED000 + 0xC08;\n\tgoto L_02C6;\nL_0263:\n\tgoto L_0266;\nL_0266:\n\tv193 = 0xB2F3000 + 0x7F8;\n\tgoto L_02C6;\nL_0271:\n\tAlmostEngine.Screenshot.ScreenshotTaker::ApplySettings(this.<>4__this, v49.cameras, v49.overlays, v49.captureMode, v49.captureGameUI, v49.forceUICullingLayer);\n\tv831 = v49.captureMode == 0;\n\tv832 = ~v831;\nL_FFFFFFFF:\n\tv555 = v49;\n\tif (v832) goto L_0294;\n\tgoto L_028B;\nL_0291:\n\tUnityEngine.Debug::LogError(\"GAMEVIEW_RESIZING capture mode is only available  for Editor and Windows Standalone.\");\nL_FFFFFFFF:\n\tv501 = 0;\nL_FFFFFFFF:\n\tv555 = v49;\n\tv899 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(v555.resolutions);\n\tv899.<>7__wrap1 = *([v899 @ X0_v136 (AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25)]);\n\t*([v899 @ X0_v136 (AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25)+78]) = v899.<>1__state;\n\tv899.<>1__state = -3;\nL_FFFFFFFF:\n\tv678 = v899;\n\tgoto L_00DE;\nL_02B5:\n\tgoto L_02B8;\nL_02B8:\n\tv193 = 0xB2F9000 + 0x9D0;\n\tgoto L_02C6;\nL_02C0:\n\tgoto L_02C3;\nL_02C3:\n\tv193 = 0xB2FA000 + 0xAE0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\treturn returnVal1;\nL_02D6:\n\tv531 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\n\tgoto L_02EE;\nL_02D8:\n\tv319 = &v49 @ stack_-48_v2 (AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25);\n\tv432 = 0x3177514(*([v319 @ X8_v57]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv315 = new System.OutOfMemoryException();\nL_02DD:\n\tv324 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = *([v49 @ stack_-48_v2 (AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25)+78]);\nL_FFFFFFFF:\n\tv529 = v531;\n\tgoto L_02EE;\nL_02DF:\n\tv529 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv152 = v152;\nL_FFFFFFFF:\n\tv529 = v324;\n\tgoto L_02EE;\nL_02E1:\n\tv533 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = v360;\n\tgoto L_02EE;\nL_02E3:\n\tv534 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = *([v49 @ stack_-48_v2 (AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25)+78]);\nL_FFFFFFFF:\n\tv529 = v533;\n\tgoto L_02EE;\nL_02E5:\n\tv529 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = v360;\nL_FFFFFFFF:\n\tv529 = v534;\n\tgoto L_02EE;\nL_02E7:\n\tv536 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = v49.<resolution>5__3;\n\tgoto L_02EE;\nL_02E9:\n\tv529 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = v500;\nL_FFFFFFFF:\n\tv529 = v536;\n\tgoto L_02EE;\nL_02EB:\n\tv538 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv102 = 0;\nL_FFFFFFFF:\n\tv152 = v501;\n\tgoto L_02EE;\nL_02EE:\n\t// 750 Interrupt\n\tgoto L_0311;\nL_0311:\n\tv158 = v152 != 1;\n\tif (v158) goto L_031B;\n\tv714 = 0x8BF5BC4(v529, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = 0x8BF5BF4(v714, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv102 = *([v714 @ X0_v103]);\n\tgoto L_FFFFFFFF;\n\treturn returnVal2;\nL_0045:\n\tv53 = this.<>4__this;\n\tv54 = this.<>1__state - 2;\n\tv55 = v54 < 2;\n\tv56 = ~v55;\n\tv64 = ~v56;\n\tif (v64) goto L_00C1;\nL_0089:\n\tv592 = v589.overlays == 0;\n\tif (v592) goto L_02B5;\nL_00B0:\n\tv209 = v754.m_IsRunning != 1;\n\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CCaptureAllCoroutine_003Ed__25::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000113")]
			[Address(RVA = "0x3C3EB00", Offset = "0x3C3EB00", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -1;\n\tv46 = this + 0x68;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CCaptureAllCoroutine_003Ed__25::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000115")]
			[Address(RVA = "0x3C3EB64", Offset = "0x3C3EB64", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003B")]
		private sealed class _003CCaptureAlphaMaskCoroutine_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400016A")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400016B")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400016C")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x400016D")]
			[FieldOffset(Offset = "0x28")]
			public ScreenshotResolution resolution;

			[Token(Token = "0x400016E")]
			[FieldOffset(Offset = "0x30")]
			public CaptureMode captureMode;

			[Token(Token = "0x400016F")]
			[FieldOffset(Offset = "0x34")]
			public int antiAliasing;

			[Token(Token = "0x4000170")]
			[FieldOffset(Offset = "0x38")]
			public ColorFormat colorFormat;

			[Token(Token = "0x4000171")]
			[FieldOffset(Offset = "0x40")]
			private Texture2D _003CdefaultTexture_003E5__2;

			[Token(Token = "0x4000172")]
			[FieldOffset(Offset = "0x48")]
			private Camera _003CfirstCamera_003E5__3;

			[Token(Token = "0x4000173")]
			[FieldOffset(Offset = "0x50")]
			private CameraClearFlags _003CclearMode_003E5__4;

			[Token(Token = "0x4000174")]
			[FieldOffset(Offset = "0x54")]
			private Color _003CclearColor_003E5__5;

			[Token(Token = "0x4000175")]
			[FieldOffset(Offset = "0x68")]
			private Texture2D _003CwhiteTexture_003E5__6;

			[Token(Token = "0x17000017")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600011A")]
				[Address(RVA = "0x3C3F4E0", Offset = "0x3C3F4E0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000018")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600011C")]
				[Address(RVA = "0x3C3F528", Offset = "0x3C3F528", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000117")]
			[Address(RVA = "0x3C3BB10", Offset = "0x3C3BB10", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureAlphaMaskCoroutine_003Ed__30(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000118")]
			[Address(RVA = "0x3C3EBAC", Offset = "0x3C3EBAC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000119")]
			[Address(RVA = "0x3C3EBB0", Offset = "0x3C3EBB0", Length = "0x930")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv69 = this.<>1__state == 0;\n\tif (v69) goto L_021F;\n\tv90 = this.<>1__state != 1;\n\treturnVal1 = 0;\n\tif (v90) goto L_021D;\n\tthis.<>1__state = -1;\n\tv107 = this.resolution;\n\tv501 = UnityEngine.Texture::get_width(v107.m_Texture);\n\tv591 = this.resolution;\n\tv503 = UnityEngine.Texture::get_height(v591.m_Texture);\n\tv592 = this.resolution;\n\tv771 = UnityEngine.Texture2D::get_format(v592.m_Texture);\n\tv786 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v786, v501, v503, v771, 0, 0);\n\tthis.<defaultTexture>5__2 = v786;\n\tv593 = this.resolution;\n\tgoto L_007D;\nL_007D:\n\tgoto L_0083;\nL_0083:\n\tgoto L_008B;\nL_008B:\n\tUnityEngine.Graphics::CopyTexture(v593.m_Texture, 0, 0, this.<defaultTexture>5__2, 0, 0);\n\tv953 = AlmostEngine.Screenshot.ScreenshotTaker::GetFirstActiveCamera(this.<>4__this);\n\tthis.<firstCamera>5__3 = v953;\n\tv960 = UnityEngine.Camera::get_clearFlags(this.<firstCamera>5__3);\n\tthis.<clearMode>5__4 = v960;\n\tv261 = UnityEngine.Camera::get_backgroundColor(this.<firstCamera>5__3);\n\tthis.<clearColor>5__5.r = v261;\n\tthis.<clearColor>5__5.g = v261.g;\n\tthis.<clearColor>5__5.b = v261.b;\n\tthis.<clearColor>5__5.a = v261.a;\n\tUnityEngine.Camera::set_clearFlags(this.<firstCamera>5__3, 2);\n\t// 182 MakeStruct v1006 @ AGG3C3EDAC_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 1f, 1f, 1f, 1f\n\tUnityEngine.Camera::set_backgroundColor(this.<firstCamera>5__3, v1006);\n\tgoto L_00C9;\n\tv1035.resolution = this.resolution;\n\tv1035.captureMode = this.captureMode;\n\tv1035.colorFormat = this.colorFormat;\n\tv1064 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v1035);\n\tv1048 = this + 0x18;\n\tthis.<>2__current = v1064;\n\tv709 = 2;\n\tgoto L_02EA;\nL_00E9:\n\tv74 = this.<>1__state == 2;\n\tif (v74) goto L_025C;\n\tv102 = this.<>1__state != 3;\n\treturnVal1 = 0;\n\tif (v102) goto L_021D;\n\tthis.<>1__state = -1;\n\tv595 = this.resolution;\n\tv512 = UnityEngine.Texture::get_width(v595.m_Texture);\n\tv596 = this.resolution;\n\tv514 = UnityEngine.Texture::get_height(v596.m_Texture);\n\tv597 = this.resolution;\n\tv778 = UnityEngine.Texture2D::get_format(v597.m_Texture);\n\tv516 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v516, v512, v514, v778, 0, 0);\n\tv598 = this.resolution;\n\tgoto L_0137;\nL_0137:\n\tgoto L_013B;\nL_013B:\n\tgoto L_0143;\nL_0143:\n\tUnityEngine.Graphics::CopyTexture(v598.m_Texture, 0, 0, v516, 0, 0);\n\tv601 = this.resolution;\n\tv767 = v516 == 0;\n\tv366 = 0;\n\tv619 = v516;\n\tif (v767) goto L_01DA;\n\tv369 = 0;\n\tgoto L_0156;\nL_014C:\n\tv369 = v369 + 1;\n\tv601 = this.resolution;\nL_0156:\n\tv520 = UnityEngine.Texture::get_width(v601.m_Texture);\n\tv424 = v369 >= v520;\n\tv180 = v516;\n\tif (v424) goto L_01E7;\n\tv603 = this.resolution;\n\tv351 = 0;\nL_016C:\n\tv518 = UnityEngine.Texture::get_height(v603.m_Texture);\n\tv422 = v351 >= v518;\n\tif (v422) goto L_014C;\n\tv996 = UnityEngine.Texture2D::GetPixel(this.<whiteTexture>5__6, v369, v351);\n\tv1011 = UnityEngine.Texture2D::GetPixel(v516, v369, v351);\n\tv265 = v1011 - v996;\n\tv218 = v265 + 1f;\n\tv463 = v218 == 0;\n\tv421 = ~v463;\n\tif (v421) goto L_01A3;\n\tv607 = this.resolution;\n\tv1036 = this.resolution == 0;\n\tv568 = ~v1036;\n\tv236 = 0;\n\tv248 = 0;\n\tv260 = 0;\n\tif (v568) goto L_01B1;\n\tv366 = v11;\n\tv619 = this.<>4__this;\n\tgoto L_01B8;\nL_01A3:\n\tv260 = UnityEngine.Texture2D::GetPixel(this.<defaultTexture>5__2, v369, v351);\n\tv248 = v260.g;\n\tv236 = v260.b;\n\tv607 = this.resolution;\nL_01B1:\n\t// 433 MakeStruct v208 @ AGG3C3F048_3_v8 (UnityEngine.Color), typeof(UnityEngine.Color), v260 @ V0_v15 (UnityEngine.Color), v248 @ V1_v14 (System.Single), v236 @ V2_v14 (System.Single), v218 @ V8_v13 (System.Single)\n\tUnityEngine.Texture2D::SetPixel(v607.m_Texture, v369, v351, v208);\n\tv351 = v351 + 1;\n\tv603 = this.resolution;\n\tv1061 = this.resolution == 0;\n\tv543 = ~v1061;\n\tv366 = v369;\n\tv619 = v516;\n\tif (v543) goto L_016C;\nL_01B8:\n\tv621 = new System.NullReferenceException();\nL_01B9:\n\tv608 = this.resolution;\n\tv527 = UnityEngine.Texture::get_height(v608.m_Texture);\n\tv427 = v527 > 0;\n\tif (v427) goto L_033D;\n\tv366 = v366 + 1;\n\tv601 = this.resolution;\nL_01DA:\n\tv739 = UnityEngine.Texture::get_width(v601.m_Texture);\n\tv730 = v366 < v739;\n\tv180 = v619;\n\tif (v730) goto L_01B9;\nL_01E7:\n\tv611 = this.resolution;\n\tUnityEngine.Texture2D::Apply(v611.m_Texture);\n\tgoto L_01FA;\nL_01FA:\n\tUnityEngine.Object::DestroyImmediate(this.<whiteTexture>5__6);\n\tUnityEngine.Object::DestroyImmediate(v180);\n\tUnityEngine.Object::DestroyImmediate(this.<defaultTexture>5__2);\n\tUnityEngine.Camera::set_clearFlags(this.<firstCamera>5__3, this.<clearMode>5__4);\n\t// 527 MakeStruct v113 @ AGG3C3F128_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), this.<clearColor>5__5 (UnityEngine.Color), this.<clearColor>5__5.g (System.Single), this.<clearColor>5__5.b (System.Single), this.<clearColor>5__5.a (System.Single)\n\tUnityEngine.Camera::set_backgroundColor(this.<firstCamera>5__3, v113);\n\treturnVal1 = 0;\nL_021F:\n\tthis.<>1__state = -1;\n\tgoto L_0233;\n\tv727.resolution = this.resolution;\n\tv727.captureMode = this.captureMode;\n\tv727.colorFormat = this.colorFormat;\n\tv763 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v727);\n\tthis.<>2__current = v763;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_025C:\n\tthis.<>1__state = -1;\n\tv104 = this.resolution;\n\tv534 = UnityEngine.Texture::get_width(v104.m_Texture);\n\tv612 = this.resolution;\n\tv536 = UnityEngine.Texture::get_height(v612.m_Texture);\n\tv613 = this.resolution;\n\tv769 = UnityEngine.Texture2D::get_format(v613.m_Texture);\n\tv782 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v782, v534, v536, v769, 0, 0);\n\tthis.<whiteTexture>5__6 = v782;\n\tv614 = this.resolution;\n\tgoto L_029D;\nL_029D:\n\tgoto L_02A3;\nL_02A3:\n\tgoto L_02AB;\nL_02AB:\n\tUnityEngine.Graphics::CopyTexture(v614.m_Texture, 0, 0, this.<whiteTexture>5__6, 0, 0);\n\tUnityEngine.Camera::set_clearFlags(this.<firstCamera>5__3, 2);\n\t// 698 MakeStruct v202 @ AGG3C3F344_1_v7 (UnityEngine.Color), typeof(UnityEngine.Color), 0, 0, 0, 1f\n\tUnityEngine.Camera::set_backgroundColor(this.<firstCamera>5__3, v202);\n\tgoto L_02CF;\n\tv979.resolution = this.resolution;\n\tv979.captureMode = this.captureMode;\n\tv979.colorFormat = this.colorFormat;\n\tv1000 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v979);\n\tv1048 = this + 0x18;\n\tthis.<>2__current = v1000;\n\tv709 = 3;\nL_033D:\n\tv651 = UnityEngine.Texture2D::GetPixel(this.<whiteTexture>5__6, v366, 0);\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\nL_002C:\n\tv65 = this.<>1__state > 1;\n\tif (v65) goto L_00E9;\nL_021D:\n\treturn returnVal1;\nL_00C9:\n\tv1035 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureResolutionTextureCoroutine>d__26();\n\tSystem.Object::.ctor(v1035);\n\tv1035.<>1__state = 0;\n\tv1035.<>4__this = this.<>4__this;\nL_02EA:\n\t*([v1048 @ X19_v2-8]) = v709;\n\treturn 1;\nL_0233:\n\tv727 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureResolutionTextureCoroutine>d__26();\n\tSystem.Object::.ctor(v727);\n\tv727.<>1__state = 0;\n\tv727.<>4__this = this.<>4__this;\nL_02CF:\n\tv979 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureResolutionTextureCoroutine>d__26();\n\tSystem.Object::.ctor(v979);\n\tv979.<>1__state = 0;\n\tv979.<>4__this = this.<>4__this;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CCaptureAlphaMaskCoroutine_003Ed__30::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600011B")]
			[Address(RVA = "0x3C3F4E8", Offset = "0x3C3F4E8", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003C")]
		private sealed class _003CCaptureCamerasToTextureCoroutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000176")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000177")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000178")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x4000179")]
			[FieldOffset(Offset = "0x28")]
			public Texture2D texture;

			[Token(Token = "0x400017A")]
			[FieldOffset(Offset = "0x30")]
			public int width;

			[Token(Token = "0x400017B")]
			[FieldOffset(Offset = "0x34")]
			public int height;

			[Token(Token = "0x400017C")]
			[FieldOffset(Offset = "0x38")]
			public List<Camera> cameras;

			[Token(Token = "0x400017D")]
			[FieldOffset(Offset = "0x40")]
			public int antiAliasing;

			[Token(Token = "0x400017E")]
			[FieldOffset(Offset = "0x44")]
			public ColorFormat colorFormat;

			[Token(Token = "0x400017F")]
			[FieldOffset(Offset = "0x48")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x17000019")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000120")]
				[Address(RVA = "0x3C3F5EC", Offset = "0x3C3F5EC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000122")]
				[Address(RVA = "0x3C3F634", Offset = "0x3C3F634", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600011D")]
			[Address(RVA = "0x3C3B524", Offset = "0x3C3B524", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureCamerasToTextureCoroutine_003Ed__22(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600011E")]
			[Address(RVA = "0x3C3F530", Offset = "0x3C3F530", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600011F")]
			[Address(RVA = "0x3C3F534", Offset = "0x3C3F534", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this.<>1__state == 0;\n\tif (v17) goto L_001B;\n\tv27 = this.<>1__state != 1;\n\tif (v27) goto L_003B;\n\tv73 = -1;\n\tgoto L_0036;\nL_001B:\n\tthis.<>1__state = -1;\n\tv124 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureToTextureCoroutine(this.<>4__this, this.texture, this.width, this.height, this.cameras, 0, 1, this.antiAliasing, 1, this.colorFormat, this.recomputeAlphaMask);\n\tv178 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v124);\n\tthis.<>2__current = v178;\n\tv73 = 1;\nL_0036:\n\tthis.<>1__state = v73;\nL_003B:\n\tv98 = this.<>1__state == 0;\n\treturn v98;\n")]
			private bool MoveNext()
			{
				bool flag;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_00e2;
					}
					flag = true;
				}
				else
				{
					_003C_003E1__state = -1;
					IEnumerator routine = _003C_003E4__this.CaptureToTextureCoroutine(texture, width, height, cameras, null, CaptureMode.RENDER_TO_TEXTURE, antiAliasing, captureGameUI: true, colorFormat, recomputeAlphaMask);
					Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
					_003C_003E2__current = coroutine;
					flag = true;
				}
				_003C_003E1__state = (flag ? 1 : 0);
				goto IL_00e2;
				IL_00e2:
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x3C3F5F4", Offset = "0x3C3F5F4", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003D")]
		private sealed class _003CCaptureResolutionCoroutine_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000180")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000181")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000182")]
			[FieldOffset(Offset = "0x20")]
			public List<Camera> cameras;

			[Token(Token = "0x4000183")]
			[FieldOffset(Offset = "0x28")]
			public List<Canvas> canvas;

			[Token(Token = "0x4000184")]
			[FieldOffset(Offset = "0x30")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x4000185")]
			[FieldOffset(Offset = "0x38")]
			public ScreenshotResolution captureResolution;

			[Token(Token = "0x4000186")]
			[FieldOffset(Offset = "0x40")]
			public CaptureMode captureMode;

			[Token(Token = "0x4000187")]
			[FieldOffset(Offset = "0x44")]
			public int antiAliasing;

			[Token(Token = "0x4000188")]
			[FieldOffset(Offset = "0x48")]
			public bool captureGameUI;

			[Token(Token = "0x4000189")]
			[FieldOffset(Offset = "0x4C")]
			public ColorFormat colorFormat;

			[Token(Token = "0x400018A")]
			[FieldOffset(Offset = "0x50")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x1700001B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000126")]
				[Address(RVA = "0x3C3FC08", Offset = "0x3C3FC08", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000128")]
				[Address(RVA = "0x3C3FC50", Offset = "0x3C3FC50", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000123")]
			[Address(RVA = "0x3C3B688", Offset = "0x3C3B688", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureResolutionCoroutine_003Ed__24(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x3C3F63C", Offset = "0x3C3F63C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000125")]
			[Address(RVA = "0x3C3F640", Offset = "0x3C3F640", Length = "0x5C8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005C;\n\tv75 = this.<>1__state == 0;\n\tv76 = ~v75;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v76) goto L_0184;\n\tthis.<>1__state = -1;\n\tv86 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v86);\n\tv336 = this.cameras == 0;\nL_FFFFFFFF:\n\t;\n\tif (v336) goto L_00CF;\n\tv344 = System.Collections.Generic.List`1<UnityEngine.Camera>::GetEnumerator(this.cameras);\n\tv384 = v344._list;\n\tv418 = v86 == 0;\n\tif (v418) goto L_00C3;\n\tgoto L_0097;\nL_0094:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::Add(v86, v680);\nL_FFFFFFFF:\n\t;\nL_0097:\n\tv485 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v384 @ stack_-80_v9 (System.Collections.Generic.List`1<UnityEngine.Camera>));\n\tv556 = v485 == 0;\n\tif (v556) goto L_00CB;\n\tv680 = new AlmostEngine.Screenshot.ScreenshotCamera();\n\tAlmostEngine.Screenshot.ScreenshotCamera::.ctor(v680, v344.Current);\n\tv747 = v86._version + 1;\n\tv86._version = v747;\n\tv479 = v86._items == 0;\n\tif (v479) goto L_018D;\n\tgoto L_0094;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_FFFFFFFF:\n\tv185 = -1;\n\tgoto L_0176;\nL_00C3:\n\tv436 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v384 @ stack_-80_v9 (System.Collections.Generic.List`1<UnityEngine.Camera>));\n\tv486 = ~v436;\n\tv487 = ~v486;\n\tif (v487) goto L_018A;\nL_00CB:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v384 @ stack_-80_v9 (System.Collections.Generic.List`1<UnityEngine.Camera>));\nL_FFFFFFFF:\n\t;\nL_00CF:\n\tv410 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v410);\n\tv438 = this.canvas == 0;\nL_FFFFFFFF:\n\tv223 = v410;\n\tif (v438) goto L_0131;\n\tv492 = System.Collections.Generic.List`1<UnityEngine.Canvas>::GetEnumerator(this.canvas);\n\tv495 = v492._list;\n\tv622 = v410 == 0;\n\tif (v622) goto L_0125;\n\tgoto L_00FB;\nL_00F8:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Add(v410, v822);\nL_FFFFFFFF:\n\t;\nL_00FB:\n\tv728 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v495 @ stack_-A0_v8 (System.Collections.Generic.List`1<UnityEngine.Canvas>));\n\tv749 = v728 == 0;\n\tif (v749) goto L_012D;\n\tv822 = new AlmostEngine.Screenshot.ScreenshotOverlay();\n\tAlmostEngine.Screenshot.ScreenshotOverlay::.ctor(v822, v492.Current);\n\tv835 = v410._version + 1;\n\tv410._version = v835;\n\tv722 = v410._items == 0;\n\tif (v722) goto L_0196;\n\tgoto L_00F8;\nL_0125:\n\tv642 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v495 @ stack_-A0_v8 (System.Collections.Generic.List`1<UnityEngine.Canvas>));\n\tv729 = ~v642;\n\tv730 = ~v729;\n\tif (v730) goto L_0193;\nL_012D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v495 @ stack_-A0_v8 (System.Collections.Generic.List`1<UnityEngine.Canvas>));\nL_FFFFFFFF:\n\tv223 = v410;\nL_0131:\n\tv551 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v551);\n\tgoto L_015B;\nL_015B:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Add(v551, this.captureResolution);\n\tv840 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureAllCoroutine(this.<>4__this, v551, v86, v223, this.captureMode, this.antiAliasing, this.captureGameUI, this.colorFormat, this.recomputeAlphaMask, 0x1000100, v841, v842, v843);\n\tv852 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v840);\n\tthis.<>2__current = v852;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_FFFFFFFF:\n\tv185 = 1;\nL_018A:\n\tv680 = new AlmostEngine.Screenshot.ScreenshotCamera();\n\tAlmostEngine.Screenshot.ScreenshotCamera::.ctor(v680, v596);\nL_018D:\n\tthrow v680;\nL_0193:\n\tv822 = new AlmostEngine.Screenshot.ScreenshotOverlay();\n\tAlmostEngine.Screenshot.ScreenshotOverlay::.ctor(v822, v492.Current);\nL_0196:\n\tthrow v822;\nL_005C:\n\tv67 = this.<>1__state == 1;\n\tif (v67) goto L_FFFFFFFF;\nL_0184:\n\treturn returnVal1;\nL_0176:\n\tthis.<>1__state = v185;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CCaptureResolutionCoroutine_003Ed__24::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000127")]
			[Address(RVA = "0x3C3FC10", Offset = "0x3C3FC10", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003E")]
		private sealed class _003CCaptureResolutionTextureCoroutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400018B")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400018C")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400018D")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x400018E")]
			[FieldOffset(Offset = "0x28")]
			public ScreenshotResolution resolution;

			[Token(Token = "0x400018F")]
			[FieldOffset(Offset = "0x30")]
			public ColorFormat colorFormat;

			[Token(Token = "0x4000190")]
			[FieldOffset(Offset = "0x34")]
			public CaptureMode captureMode;

			[Token(Token = "0x4000191")]
			[FieldOffset(Offset = "0x38")]
			public int antiAliasing;

			[Token(Token = "0x4000192")]
			[FieldOffset(Offset = "0x40")]
			private Stopwatch _003CcaptureScreenWatch_003E5__2;

			[Token(Token = "0x4000193")]
			[FieldOffset(Offset = "0x48")]
			private Stopwatch _003CcaptureResolutionTextureWatch_003E5__3;

			[Token(Token = "0x4000194")]
			[FieldOffset(Offset = "0x50")]
			private Stopwatch _003CgameviewCaptureWatch_003E5__4;

			[Token(Token = "0x4000195")]
			[FieldOffset(Offset = "0x58")]
			private Stopwatch _003CgameviewWaitWatch_003E5__5;

			[Token(Token = "0x4000196")]
			[FieldOffset(Offset = "0x60")]
			private int _003Ci_003E5__6;

			[Token(Token = "0x1700001D")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600012C")]
				[Address(RVA = "0x3C40654", Offset = "0x3C40654", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001E")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600012E")]
				[Address(RVA = "0x3C4069C", Offset = "0x3C4069C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000129")]
			[Address(RVA = "0x3C3B790", Offset = "0x3C3B790", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureResolutionTextureCoroutine_003Ed__26(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600012A")]
			[Address(RVA = "0x3C3FC58", Offset = "0x3C3FC58", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600012B")]
			[Address(RVA = "0x3C3FC5C", Offset = "0x3C3FC5C", Length = "0x9F8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv84 = this.<>1__state <= 1;\n\tif (v84) goto L_00B3;\n\tv104 = this.<>1__state == 2;\n\tif (v104) goto L_016F;\n\tv135 = this.<>1__state == 3;\n\tif (v135) goto L_01B5;\n\tv190 = this.<>1__state != 4;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v190) goto L_03A9;\n\tthis.<>1__state = -1;\n\tv659 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v659);\n\tthis.<>2__current = v659;\n\tthis.<>1__state = 5;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_03A9;\nL_008B:\n\tv96 = this.<>1__state <= 6;\n\tif (v96) goto L_00D3;\n\tv114 = this.<>1__state == 7;\n\tif (v114) goto L_01A3;\n\tv160 = this.<>1__state == 8;\n\tif (v160) goto L_01D6;\n\tv326 = this.<>1__state != 9;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v326) goto L_03A9;\n\tthis.<>1__state = -1;\n\tv752 = this.<captureScreenWatch>5__2;\n\tv710 = this.<captureScreenWatch>5__2 == 0;\n\tv578 = ~v710;\n\tif (v578) goto L_0253;\n\tgoto L_03AA;\nL_00B3:\n\tv109 = this.<>1__state == 0;\n\tif (v109) goto L_00EC;\n\tv150 = this.<>1__state != 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v150) goto L_03A9;\n\tthis.<>1__state = -1;\n\tgoto L_00C9;\nL_00C9:\n\tv229 = UnityEngine.Application::get_isPlaying();\n\tv747 = v229 == 0;\n\tv233 = ~v747;\n\tif (v233) goto L_0176;\n\tgoto L_02D4;\nL_00D3:\n\tv123 = this.<>1__state == 5;\n\tif (v123) goto L_016C;\n\tv176 = this.<>1__state != 6;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v176) goto L_03A9;\n\tthis.<>1__state = -1;\n\tv712 = this.<captureResolutionTextureWatch>5__3;\n\tv625 = this.<captureResolutionTextureWatch>5__3 == 0;\n\tv579 = ~v625;\n\tif (v579) goto L_039A;\n\tgoto L_03AA;\nL_00EC:\n\tthis.<>1__state = -1;\n\tv155 = new System.Diagnostics.Stopwatch();\n\tSystem.Diagnostics.Stopwatch::.ctor(v155);\n\tthis.<captureScreenWatch>5__2 = v155;\n\tv750 = new System.Diagnostics.Stopwatch();\n\tSystem.Diagnostics.Stopwatch::.ctor(v750);\n\tthis.<captureResolutionTextureWatch>5__3 = v750;\n\tv822 = new System.Diagnostics.Stopwatch();\n\tSystem.Diagnostics.Stopwatch::.ctor(v822);\n\tthis.<gameviewCaptureWatch>5__4 = v822;\n\tv943 = new System.Diagnostics.Stopwatch();\n\tSystem.Diagnostics.Stopwatch::.ctor(v943);\n\tv985 = new System.Diagnostics.Stopwatch();\n\tSystem.Diagnostics.Stopwatch::.ctor(v985);\n\tthis.<gameviewWaitWatch>5__5 = v985;\n\tSystem.Diagnostics.Stopwatch::Start(this.<captureResolutionTextureWatch>5__3);\n\tgoto L_0130;\nL_0130:\n\tv542 = this.captureMode - 2;\n\tv530 = v542 == 0;\n\tv557 = AlmostEngine.Screenshot.ScreenshotTaker::GetOrCreateTexture(this.resolution, this.colorFormat, v530);\n\tv57.m_Texture = v557;\n\tv327 = this.captureMode > 2;\n\tif (v327) goto L_0210;\n\tv867 = this.captureMode == 0;\n\tif (v867) goto L_0343;\n\tv851 = this.captureMode != 1;\n\tif (v851) goto L_0329;\n\tv1049 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v1049);\n\tv390 = this + 0x18;\n\tthis.<>2__current = v1049;\nL_FFFFFFFF:\n\tv382 = 7;\n\tgoto L_029E;\nL_016C:\n\tthis.<>1__state = -1;\n\tgoto L_0275;\nL_016F:\n\tthis.<>1__state = -1;\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::Invoke(v663.onResolutionScreenResizedDelegate, this.resolution);\n\tv764 = v57.m_GameViewResizingWaitingMode == 0;\n\tif (v764) goto L_0266;\n\tgoto L_018E;\nL_018E:\n\tv792 = UnityEngine.Application::get_isPlaying();\n\tv794 = v792 == 0;\n\tif (v794) goto L_0266;\n\tv899 = new UnityEngine.WaitForSecondsRealtime();\n\tUnityEngine.WaitForSecondsRealtime::.ctor(v899, v57.m_GameViewResizingWaitingTime);\n\tv390 = this + 0x18;\n\tthis.<>2__current = v899;\nL_FFFFFFFF:\n\tv382 = 4;\n\tgoto L_029E;\nL_01A3:\n\tthis.<>1__state = -1;\n\tv413 = AlmostEngine.Screenshot.ScreenshotTaker::GetOrCreateRenderTexture(0, this.resolution, this.antiAliasing, 0x20, 2);\n\tAlmostEngine.Screenshot.ScreenshotTaker::CaptureCamerasToTexture(v413, v57.m_Cameras, v57.m_Texture, v413);\n\tv712 = this.<captureResolutionTextureWatch>5__3;\n\tv754 = this.<captureResolutionTextureWatch>5__3 == 0;\n\tv584 = ~v754;\n\tif (v584) goto L_039A;\n\tgoto L_03AA;\nL_01B5:\n\tthis.<>1__state = -1;\n\tv193 = this.<i>5__6 + 1;\n\tthis.<i>5__6 = v193;\n\tv629 = v193 >= v57.m_GameViewResizingWaitingFrames;\n\tif (v629) goto L_0275;\nL_01CA:\n\tv744 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v744);\n\tv390 = this + 0x18;\n\tthis.<>2__current = v744;\nL_FFFFFFFF:\n\tv382 = 3;\n\tgoto L_029E;\nL_01D6:\n\tthis.<>1__state = -1;\n\tSystem.Diagnostics.Stopwatch::Stop(this.<gameviewWaitWatch>5__5);\n\tSystem.Diagnostics.Stopwatch::Start(this.<captureScreenWatch>5__2);\n\tv562 = AlmostEngine.MultiDisplayUtils::IsMultiDisplay();\n\tv824 = ~v562;\n\tif (v824) goto L_0232;\n\tgoto L_01F6;\n\tv951.targetTexture = v57.m_Texture;\n\tv390 = this + 0x18;\n\tthis.<>2__current = v951;\nL_FFFFFFFF:\n\tv382 = 9;\n\tgoto L_029E;\nL_0210:\n\tv1023 = this.captureMode == 3;\n\tif (v1023) goto L_FFFFFFFF;\n\tv1038 = this.captureMode != 4;\n\tif (v1038) goto L_0329;\nL_FFFFFFFF:\n\tv441 = AlmostEngine.Screenshot.ScreenshotTaker+CaptureMode;\n\tgoto L_037F;\nL_0232:\n\tgoto L_023A;\nL_023A:\n\tv973 = UnityEngine.Texture::get_width(v57.m_Texture);\n\tv976 = UnityEngine.Texture::get_height(v57.m_Texture);\n\t// 585 MakeStruct v421 @ AGG3C401FC_1_v5 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v973 @ X0_v50 (System.Int32), v976 @ X0_v52 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(v57.m_Texture, v421, 0, 0);\n\tUnityEngine.Texture2D::Apply(v57.m_Texture, 0);\n\tv752 = this.<captureScreenWatch>5__2;\nL_0253:\n\tSystem.Diagnostics.Stopwatch::Stop(v752);\n\tSystem.Diagnostics.Stopwatch::Stop(this.<gameviewCaptureWatch>5__4);\n\tv712 = this.<captureResolutionTextureWatch>5__3;\n\tv823 = this.<captureResolutionTextureWatch>5__3 == 0;\n\tv591 = ~v823;\n\tif (v591) goto L_039A;\n\tgoto L_03AA;\nL_0266:\n\tthis.<i>5__6 = 0;\n\tv628 = 0 < v57.m_GameViewResizingWaitingFrames;\n\tif (v628) goto L_01CA;\nL_0275:\n\tv567 = AlmostEngine.MultiDisplayUtils::IsMultiDisplay();\n\tv713 = ~v567;\n\tif (v713) goto L_02AA;\n\tgoto L_0289;\n\tv815.targetTexture = v57.m_Texture;\n\tv390 = this + 0x18;\n\tthis.<>2__current = v815;\nL_FFFFFFFF:\n\tv382 = 6;\nL_02AA:\n\tgoto L_02B2;\nL_02B2:\n\tv831 = UnityEngine.Texture::get_width(v57.m_Texture);\n\tv834 = UnityEngine.Texture::get_height(v57.m_Texture);\n\t// 705 MakeStruct v419 @ AGG3C4035C_1_v4 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v831 @ X0_v16 (System.Int32), v834 @ X0_v18 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(v57.m_Texture, v419, 0, 0);\n\tUnityEngine.Texture2D::Apply(v57.m_Texture, 0);\n\tv712 = this.<captureResolutionTextureWatch>5__3;\n\tv929 = this.<captureResolutionTextureWatch>5__3 == 0;\n\tv595 = ~v929;\n\tif (v595) goto L_039A;\n\tgoto L_03AA;\nL_02D4:\n\tv570 = AlmostEngine.MultiDisplayUtils::IsMultiDisplay();\n\tv820 = ~v570;\n\tif (v820) goto L_0307;\n\tgoto L_02E8;\n\tv940.targetTexture = v57.m_Texture;\n\tv390 = this + 0x18;\n\tthis.<>2__current = v940;\nL_FFFFFFFF:\n\tv382 = 2;\n\tgoto L_029E;\nL_0307:\n\tgoto L_030F;\nL_030F:\n\tv960 = UnityEngine.Texture::get_width(v57.m_Texture);\n\tv963 = UnityEngine.Texture::get_height(v57.m_Texture);\n\t// 798 MakeStruct v197 @ AGG3C40480_1_v8 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v960 @ X0_v169 (System.Int32), v963 @ X0_v171 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(v57.m_Texture, v197, 0, 0);\n\tUnityEngine.Texture2D::Apply(v57.m_Texture, 0);\n\tgoto L_0176;\nL_0329:\n\tSystem.Diagnostics.Stopwatch::Start(this.<gameviewCaptureWatch>5__4);\n\tSystem.Diagnostics.Stopwatch::Start(this.<gameviewWaitWatch>5__5);\n\tv1114 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v1114);\n\tv390 = this + 0x18;\n\tthis.<>2__current = v1114;\nL_FFFFFFFF:\n\tv382 = 8;\n\tgoto L_029E;\nL_0343:\n\tv1051 = UnityEngine.Texture::get_width(v57.m_Texture);\n\tv1067 = UnityEngine.Texture::get_height(v57.m_Texture);\n\tgoto L_0361;\nL_0365:\n\tUnityEngine.Debug::LogError(\"GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.\");\n\tv1117 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v1117);\n\tthis.<>2__current = v1117;\n\tthis.<>1__state = 1;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_03A9;\nL_FFFFFFFF:\n\tv441 = AlmostEngine.Screenshot.ScreenshotTaker+CaptureMode;\nL_039A:\n\tSystem.Diagnostics.Stopwatch::Stop(v712);\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_03AA:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0034:\n\tv57 = this.<>4__this;\n\tv69 = this.<>1__state > \n// ... truncated")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CCaptureResolutionTextureCoroutine_003Ed__26::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600012D")]
			[Address(RVA = "0x3C4065C", Offset = "0x3C4065C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003F")]
		private sealed class _003CCaptureScreenToTextureCoroutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000197")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000198")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000199")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x400019A")]
			[FieldOffset(Offset = "0x28")]
			public Texture2D texture;

			[Token(Token = "0x400019B")]
			[FieldOffset(Offset = "0x30")]
			public bool captureGameUI;

			[Token(Token = "0x400019C")]
			[FieldOffset(Offset = "0x34")]
			public ColorFormat colorFormat;

			[Token(Token = "0x400019D")]
			[FieldOffset(Offset = "0x38")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x1700001F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000132")]
				[Address(RVA = "0x3C40788", Offset = "0x3C40788", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000020")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000134")]
				[Address(RVA = "0x3C407D0", Offset = "0x3C407D0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600012F")]
			[Address(RVA = "0x3C3B420", Offset = "0x3C3B420", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureScreenToTextureCoroutine_003Ed__21(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000130")]
			[Address(RVA = "0x3C406A4", Offset = "0x3C406A4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000131")]
			[Address(RVA = "0x3C406A8", Offset = "0x3C406A8", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this.<>1__state == 0;\n\tif (v17) goto L_001B;\n\tv27 = this.<>1__state != 1;\n\tif (v27) goto L_0043;\n\tv82 = -1;\n\tgoto L_003E;\nL_001B:\n\tthis.<>1__state = -1;\n\tv31 = UnityEngine.Screen::get_width();\n\tv122 = UnityEngine.Screen::get_height();\n\tv186 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureToTextureCoroutine(this.<>4__this, this.texture, v31, v122, 0, 0, 2, 8, this.captureGameUI, this.colorFormat, this.recomputeAlphaMask);\n\tv196 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v186);\n\tthis.<>2__current = v196;\n\tv82 = 1;\nL_0043:\n\tv108 = this.<>1__state == 0;\n\treturn v108;\nL_003E:\n\tthis.<>1__state = v82;\n")]
			private bool MoveNext()
			{
				int num;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_00dc;
					}
					num = -1;
				}
				else
				{
					_003C_003E1__state = -1;
					int width = Screen.width;
					int height = Screen.height;
					IEnumerator routine = _003C_003E4__this.CaptureToTextureCoroutine(texture, width, height, null, null, CaptureMode.FIXED_GAME_VIEW, 8, captureGameUI, colorFormat, recomputeAlphaMask);
					Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
					_003C_003E2__current = coroutine;
					num = 1;
				}
				_003C_003E1__state = num;
				goto IL_00dc;
				IL_00dc:
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000133")]
			[Address(RVA = "0x3C40790", Offset = "0x3C40790", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000040")]
		private sealed class _003CCaptureToTextureCoroutine_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400019E")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400019F")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001A0")]
			[FieldOffset(Offset = "0x20")]
			public Texture2D texture;

			[Token(Token = "0x40001A1")]
			[FieldOffset(Offset = "0x28")]
			public int width;

			[Token(Token = "0x40001A2")]
			[FieldOffset(Offset = "0x2C")]
			public int height;

			[Token(Token = "0x40001A3")]
			[FieldOffset(Offset = "0x30")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x40001A4")]
			[FieldOffset(Offset = "0x38")]
			public List<Camera> cameras;

			[Token(Token = "0x40001A5")]
			[FieldOffset(Offset = "0x40")]
			public List<Canvas> canvas;

			[Token(Token = "0x40001A6")]
			[FieldOffset(Offset = "0x48")]
			public CaptureMode captureMode;

			[Token(Token = "0x40001A7")]
			[FieldOffset(Offset = "0x4C")]
			public int antiAliasing;

			[Token(Token = "0x40001A8")]
			[FieldOffset(Offset = "0x50")]
			public bool captureGameUI;

			[Token(Token = "0x40001A9")]
			[FieldOffset(Offset = "0x54")]
			public ColorFormat colorFormat;

			[Token(Token = "0x40001AA")]
			[FieldOffset(Offset = "0x58")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x17000021")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000138")]
				[Address(RVA = "0x3C409AC", Offset = "0x3C409AC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000022")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600013A")]
				[Address(RVA = "0x3C409F4", Offset = "0x3C409F4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000135")]
			[Address(RVA = "0x3C3B65C", Offset = "0x3C3B65C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureToTextureCoroutine_003Ed__23(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000136")]
			[Address(RVA = "0x3C407D8", Offset = "0x3C407D8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000137")]
			[Address(RVA = "0x3C407DC", Offset = "0x3C407DC", Length = "0x1D0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv60 = this.<>1__state == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0054;\n\tthis.<>1__state = -1;\n\tgoto L_003A;\nL_003A:\n\tv156 = UnityEngine.Object::op_Equality(this.texture, 0);\n\tv158 = ~v156;\n\tif (v158) goto L_006F;\n\tgoto L_0049;\nL_0049:\n\tUnityEngine.Debug::LogError(\"The texture can not be null. You must provide a texture initialized with any width and height.\");\nL_0054:\n\treturn 0;\nL_0057:\n\tthis.<>1__state = -1;\n\treturn 0;\nL_006F:\n\tv178 = new AlmostEngine.Screenshot.ScreenshotResolution();\n\tAlmostEngine.Screenshot.ScreenshotResolution::.ctor(v178, this.width, this.height);\n\tv178.m_Texture = this.texture;\n\tv193 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureResolutionCoroutine(this.<>4__this, v178, this.cameras, this.canvas, this.captureMode, this.antiAliasing, this.captureGameUI, this.colorFormat, this.recomputeAlphaMask);\n\tv197 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v193);\n\tthis.<>2__current = v197;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_0024:\n\tv52 = this.<>1__state == 1;\n\tif (v52) goto L_0057;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						if (!(texture == null))
						{
							ScreenshotResolution captureResolution = new ScreenshotResolution(width, height)
							{
								m_Texture = texture
							};
							IEnumerator routine = _003C_003E4__this.CaptureResolutionCoroutine(captureResolution, cameras, canvas, captureMode, antiAliasing, captureGameUI, colorFormat, recomputeAlphaMask);
							Coroutine coroutine = _003C_003E4__this.StartCoroutine(routine);
							_003C_003E2__current = coroutine;
							_003C_003E1__state = 1;
							return true;
						}
						Debug.LogError("The texture can not be null. You must provide a texture initialized with any width and height.");
					}
					return false;
				}
				_003C_003E1__state = -1;
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000139")]
			[Address(RVA = "0x3C409B4", Offset = "0x3C409B4", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000041")]
		private sealed class _003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001AB")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001AC")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001AD")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotTaker _003C_003E4__this;

			[Token(Token = "0x40001AE")]
			[FieldOffset(Offset = "0x28")]
			public Texture2D targetTexture;

			[Token(Token = "0x40001AF")]
			[FieldOffset(Offset = "0x30")]
			private MultiDisplayCameraCapture _003CcaptureMultiCam_003E5__2;

			[Token(Token = "0x40001B0")]
			[FieldOffset(Offset = "0x38")]
			private bool _003CwasCreated_003E5__3;

			[Token(Token = "0x17000023")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600013E")]
				[Address(RVA = "0x3C40D90", Offset = "0x3C40D90", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000024")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000140")]
				[Address(RVA = "0x3C40DD8", Offset = "0x3C40DD8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600013B")]
			[Address(RVA = "0x3C3C334", Offset = "0x3C3C334", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600013C")]
			[Address(RVA = "0x3C409FC", Offset = "0x3C409FC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600013D")]
			[Address(RVA = "0x3C40A00", Offset = "0x3C40A00", Length = "0x390")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv56 = this.<>1__state == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0128;\n\tthis.<>1__state = -1;\n\tgoto L_0044;\n\tv127 = v271.Count < 1;\n\tif (v127) goto L_009D;\n\tgoto L_0063;\nL_0063:\n\tv259 = System.Collections.Generic.List`1<AlmostEngine.MultiDisplayCameraCapture>::get_Item(v271, 0);\n\tv333 = UnityEngine.Component::GetComponent(v259);\n\tv239 = 0xB292000 + 0x5A0;\n\tv275 = v333;\n\tgoto L_0074;\nL_0074:\n\tv359 = UnityEngine.Object::op_Inequality(v275, 0);\n\tv365 = ~v359;\n\tif (v365) goto L_00B5;\n\tv381 = UnityEngine.Component::GetComponent(v275);\n\tthis.<captureMultiCam>5__2 = v381;\n\tthis.<wasCreated>5__3 = 0;\n\tv274 = *([v239 @ X22_v11 (System.Int32)]);\n\tv400 = *([v274 @ X8_v28+E4]) == 0;\n\tif (v400) goto L_00E1;\n\tv404 = UnityEngine.Object::op_Equality(this.<captureMultiCam>5__2, 0);\n\tv408 = ~v404;\n\tv409 = ~v408;\n\tif (v409) goto L_00E6;\n\tgoto L_00F8;\nL_0092:\n\tthis.<>1__state = -1;\n\tv112 = this + 0x30;\n\tv147 = this.<captureMultiCam>5__2;\n\tv62 = this.<captureMultiCam>5__2 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_00FF;\n\tgoto L_0138;\nL_009D:\n\tv314 = AlmostEngine.Screenshot.ScreenshotTaker::GetLastActiveCamera(this.<>4__this);\n\tv239 = 0xB292000 + 0x5A0;\n\tv275 = v314;\n\tgoto L_0074;\nL_00B5:\n\tgoto L_00BD;\nL_00BD:\n\tv391 = UnityEngine.Texture::get_width(this.targetTexture);\n\tv395 = UnityEngine.Texture::get_height(this.targetTexture);\n\t// 204 MakeStruct v169 @ AGG3C40C58_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v391 @ X0_v26 (System.Int32), v395 @ X0_v28 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(this.targetTexture, v169, 0, 0);\n\tUnityEngine.Texture2D::Apply(this.targetTexture, 0);\n\treturn 0;\nL_00E1:\n\tv413 = UnityEngine.Object::op_Equality(this.<captureMultiCam>5__2, 0);\n\tv417 = ~v413;\n\tif (v417) goto L_00F8;\nL_00E6:\n\tv262 = UnityEngine.Component::get_gameObject(v275);\n\tv427 = UnityEngine.GameObject::AddComponent(v262);\n\tthis.<captureMultiCam>5__2 = v427;\n\tthis.<wasCreated>5__3 = 1;\nL_00F8:\n\tAlmostEngine.MultiDisplayCameraCapture::WaitRenderingAndCopyCameraToTexture(this.<captureMultiCam>5__2, this.targetTexture);\n\tv112 = this + 0x30;\n\tv147 = this.<captureMultiCam>5__2;\nL_00FF:\n\tv155 = AlmostEngine.MultiDisplayCameraCapture::CopyIsOver(v147);\n\tv223 = ~v155;\n\tif (v223) goto L_012A;\n\tv82 = this.<wasCreated>5__3 != 1;\n\tif (v82) goto L_011C;\n\tgoto L_011B;\nL_011C:\n\t*([v112 @ X20_v5]) = 0;\nL_0128:\n\treturn 0;\nL_012A:\n\tthis.<>2__current = 0;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_0138:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_002E:\n\tv48 = this.<>1__state == 1;\n\tif (v48) goto L_0092;\nL_0044:\n\tv271 = v162.m_MultiDisplayCamera;\nL_011B:\n\tUnityEngine.Object::DestroyImmediate(*([v112 @ X20_v5]));\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker._003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600013F")]
			[Address(RVA = "0x3C40D98", Offset = "0x3C40D98", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x20")]
		public Texture2D m_Texture;

		[HideInInspector]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x28")]
		public GameViewResizingWaitingMode m_GameViewResizingWaitingMode;

		[HideInInspector]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x2C")]
		public float m_GameViewResizingWaitingTime;

		[HideInInspector]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x30")]
		public int m_GameViewResizingWaitingFrames;

		[HideInInspector]
		[Token(Token = "0x4000136")]
		public static bool m_IsRunning = false;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x38")]
		private List<ScreenshotCamera> m_Cameras;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x40")]
		private List<ScreenshotCamera> m_SceneCameras;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x48")]
		private List<ScreenshotOverlay> m_Overlays;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x50")]
		private List<ScreenshotOverlay> m_DisabledOverlays;

		[Token(Token = "0x400013B")]
		public static UnityAction<ScreenshotResolution> onResolutionUpdateStartDelegate;

		[Token(Token = "0x400013C")]
		public static UnityAction<ScreenshotResolution> onResolutionUpdateEndDelegate;

		[Token(Token = "0x400013D")]
		public static UnityAction<ScreenshotResolution> onResolutionScreenResizedDelegate;

		[Token(Token = "0x400013E")]
		private static List<RenderTexture> m_RenderTextureCache;

		[Token(Token = "0x400013F")]
		private static int m_MaxRenderTextureCache;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x58")]
		private List<RectTransform> disabledUIElements;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x60")]
		private float m_PreviousTimeScale;

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x3C3AC38", Offset = "0x3C3AC38", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void Update()
		{
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x3C3AC3C", Offset = "0x3C3AC3C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0023;\nL_0023:\n\tv52.m_IsRunning = 0;\n\treturn;\nL_0018:\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tUnityEngine.Time::set_timeScale(this.m_PreviousTimeScale);\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreSettings(this);\n")]
		public void Reset()
		{
			StopAllCoroutines();
			Time.timeScale = m_PreviousTimeScale;
			RestoreSettings();
			m_IsRunning = false;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x3C3ACE8", Offset = "0x3C3ACE8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0023;\nL_0023:\n\tv52.m_IsRunning = 0;\n\treturn;\nL_0018:\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tUnityEngine.Time::set_timeScale(this.m_PreviousTimeScale);\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreSettings(this);\n")]
		private void OnDestroy()
		{
			StopAllCoroutines();
			Time.timeScale = m_PreviousTimeScale;
			RestoreSettings();
			m_IsRunning = false;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x3C34660", Offset = "0x3C34660", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = 0;\n\tgoto L_001A;\nL_001A:\n\tv62 = v60.m_RenderTextureCache == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_004A;\n\tgoto L_0096;\nL_004A:\n\tv144 = 0xB2A7000 + 0x128;\n\tv94 = System.Collections.Generic.List`1<UnityEngine.RenderTexture>::GetEnumerator(v60.m_RenderTextureCache);\n\tv164 = v94._list;\n\tgoto L_005D;\nL_005A:\n\tUnityEngine.Object::DestroyImmediate(v94.Current);\nL_005D:\n\tv187 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v164 @ stack_-58_v4 (System.Collections.Generic.List`1<UnityEngine.RenderTexture>));\n\tv203 = v187 == 0;\n\tif (v203) goto L_006B;\n\tgoto L_005A;\nL_006B:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v164 @ stack_-58_v4 (System.Collections.Generic.List`1<UnityEngine.RenderTexture>));\nL_FFFFFFFF:\n\tv130 = 0;\nL_FFFFFFFF:\n\tv141 = Il2CppMethodInfo;\nL_0070:\n\tgoto L_0074;\n\tSystem.Collections.Generic.List`1<UnityEngine.RenderTexture>::Clear(v160);\n\tv261 = v160.Count < 1;\n\tif (v261) goto L_0095;\nL_0095:\n\treturn;\nL_0096:\n\tv163 = new System.NullReferenceException();\n\tgoto L_00A2;\nL_00A2:\n\tv201 = v141 != 1;\nL_FFFFFFFF:\n\tv217 = v163;\n\tif (v201) goto L_00B2;\n\tv208 = 0x8BF5BC4(v163, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv229 = 0x8BF5BF4(v208, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv141 = *([v144 @ X21_v2 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v54 @ stack_-58_v7 (System.Int32));\n\tv216 = *([v208 @ X0_v10]) == 0;\nL_FFFFFFFF:\n\tv130 = *([v208 @ X0_v10]);\n\tif (v216) goto L_0070;\n\tv214 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv130 = *([v208 @ X0_v10]);\nL_FFFFFFFF:\n\tv217 = v214;\n\treturn;\nL_0074:\n\tv160 = v247.m_RenderTextureCache;\n\tv158 = v247.m_RenderTextureCache == 0;\n\tif (v158) goto L_0096;\nL_00B2:\n\tv220 = 0x3177214(&v130 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv231 = 0x8BF0368(v217, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv244 = 0xA1B8(v231, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ClearRenderTextureCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::ClearRenderTextureCache");
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x3C3AD88", Offset = "0x3C3AD88", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0027:\n\tAlmostEngine.Screenshot.ScreenshotTaker::GetOrCreateTexture(&v58 @ stack_-38_v2 (UnityEngine.Texture2D), v45, v48, colorFormat);\n\tv68 = UnityEngine.Texture::get_width(v58);\n\tv74 = UnityEngine.Texture::get_height(v58);\n\t// 62 MakeStruct v83 @ AGG3C3AE54_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v68 @ X0_v11 (System.Int32), v74 @ X0_v13 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(v58, v83, 0, 0);\n\tUnityEngine.Texture2D::Apply(v58, 0);\n\treturn v58;\nL_0017:\n\tv45 = UnityEngine.Screen::get_width();\n\tv48 = UnityEngine.Screen::get_height();\n\tgoto L_0027;\n")]
		public static Texture2D CaptureScreenToTexture(ColorFormat colorFormat = ColorFormat.RGB)
		{
			int width = Screen.width;
			int height = Screen.height;
			Texture2D texture = default(Texture2D);
			GetOrCreateTexture(ref texture, width, height, colorFormat);
			int width2 = texture.width;
			int height2 = texture.height;
			Rect source = default(Rect);
			source.x = 0f;
			source.y = 0f;
			source.width = width2;
			source.height = height2;
			texture.ReadPixels(source, 0, 0);
			texture.Apply(updateMipmaps: false);
			return texture;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x3C3B080", Offset = "0x3C3B080", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_002B:\n\tAlmostEngine.Screenshot.ScreenshotTaker::GetOrCreateTexture(&v64 @ stack_-48_v2 (UnityEngine.Texture2D), width, height, colorFormat);\n\tv69 = new UnityEngine.RenderTexture();\n\tUnityEngine.RenderTexture::.ctor(v69, width, height, 0x18);\n\tAlmostEngine.Screenshot.ScreenshotTaker::CaptureCamerasToTexture(cameras, v64, v69);\n\treturn v64;\nL_0025:\n\tgoto L_002B;\n")]
		public static Texture2D CaptureCamerasToTexture(int width, int height, List<Camera> cameras, ColorFormat colorFormat = ColorFormat.RGB)
		{
			Texture2D texture = default(Texture2D);
			GetOrCreateTexture(ref texture, width, height, colorFormat);
			RenderTexture renderTexture = new RenderTexture(width, height, 24);
			CaptureCamerasToTexture(cameras, texture, renderTexture);
			return texture;
		}

		[IteratorStateMachine(typeof(_003CCaptureScreenToTextureCoroutine_003Ed__21))]
		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x3C3B36C", Offset = "0x3C3B36C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv57.texture = texture;\n\tv57.captureGameUI = captureGameUI;\n\tv57.colorFormat = colorFormat;\n\tv57.recomputeAlphaMask = recomputeAlphaMask;\n\treturn v57;\nL_001F:\n\tv57 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureScreenToTextureCoroutine>d__21();\n\tSystem.Object::.ctor(v57);\n\tv57.<>1__state = 0;\n\tv57.<>4__this = this;\n")]
		public IEnumerator CaptureScreenToTextureCoroutine(Texture2D texture, bool captureGameUI = true, ColorFormat colorFormat = ColorFormat.RGB, bool recomputeAlphaMask = false)
		{
			_003CCaptureScreenToTextureCoroutine_003Ed__21 _003CCaptureScreenToTextureCoroutine_003Ed__22 = (_003CCaptureScreenToTextureCoroutine_003Ed__21)FormatterServices.GetUninitializedObject(typeof(_003CCaptureScreenToTextureCoroutine_003Ed__21));
			_003CCaptureScreenToTextureCoroutine_003Ed__22._003C_003E1__state = 0;
			_003CCaptureScreenToTextureCoroutine_003Ed__22._003C_003E4__this = this;
			_003CCaptureScreenToTextureCoroutine_003Ed__22.texture = texture;
			_003CCaptureScreenToTextureCoroutine_003Ed__22.captureGameUI = captureGameUI;
			_003CCaptureScreenToTextureCoroutine_003Ed__22.colorFormat = colorFormat;
			_003CCaptureScreenToTextureCoroutine_003Ed__22.recomputeAlphaMask = recomputeAlphaMask;
			return _003CCaptureScreenToTextureCoroutine_003Ed__22;
		}

		[IteratorStateMachine(typeof(_003CCaptureCamerasToTextureCoroutine_003Ed__22))]
		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x3C3B44C", Offset = "0x3C3B44C", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv64.texture = texture;\n\tv64.width = width;\n\tv64.height = height;\n\tv64.cameras = cameras;\n\tv64.antiAliasing = antiAliasing;\n\tv64.colorFormat = colorFormat;\n\tv64.recomputeAlphaMask = recomputeAlphaMask;\n\treturn v64;\nL_0024:\n\tv64 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureCamerasToTextureCoroutine>d__22();\n\tSystem.Object::.ctor(v64);\n\tv64.<>1__state = 0;\n\tv64.<>4__this = this;\n")]
		public IEnumerator CaptureCamerasToTextureCoroutine(Texture2D texture, int width, int height, List<Camera> cameras, int antiAliasing = 8, ColorFormat colorFormat = ColorFormat.RGB, bool recomputeAlphaMask = false)
		{
			_003CCaptureCamerasToTextureCoroutine_003Ed__22 _003CCaptureCamerasToTextureCoroutine_003Ed__23 = (_003CCaptureCamerasToTextureCoroutine_003Ed__22)FormatterServices.GetUninitializedObject(typeof(_003CCaptureCamerasToTextureCoroutine_003Ed__22));
			_003CCaptureCamerasToTextureCoroutine_003Ed__23._003C_003E1__state = 0;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23._003C_003E4__this = this;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.texture = texture;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.width = width;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.height = height;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.cameras = cameras;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.antiAliasing = antiAliasing;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.colorFormat = colorFormat;
			_003CCaptureCamerasToTextureCoroutine_003Ed__23.recomputeAlphaMask = recomputeAlphaMask;
			return _003CCaptureCamerasToTextureCoroutine_003Ed__23;
		}

		[IteratorStateMachine(typeof(_003CCaptureToTextureCoroutine_003Ed__23))]
		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x3C3B550", Offset = "0x3C3B550", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv71.texture = texture;\n\tv71.width = width;\n\tv71.height = height;\n\tv71.cameras = cameras;\n\tv71.canvas = canvas;\n\tv71.captureMode = captureMode;\n\tv71.antiAliasing = antiAliasing;\n\tv71.captureGameUI = captureGameUI;\n\tv71.colorFormat = colorFormat;\n\tv71.recomputeAlphaMask = recomputeAlphaMask;\n\treturn v71;\nL_0028:\n\tv71 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureToTextureCoroutine>d__23();\n\tSystem.Object::.ctor(v71);\n\tv71.<>1__state = 0;\n\tv71.<>4__this = this;\n")]
		public IEnumerator CaptureToTextureCoroutine(Texture2D texture, int width, int height, List<Camera> cameras = null, List<Canvas> canvas = null, CaptureMode captureMode = CaptureMode.RENDER_TO_TEXTURE, int antiAliasing = 8, bool captureGameUI = true, ColorFormat colorFormat = ColorFormat.RGB, bool recomputeAlphaMask = false)
		{
			_003CCaptureToTextureCoroutine_003Ed__23 _003CCaptureToTextureCoroutine_003Ed__24 = (_003CCaptureToTextureCoroutine_003Ed__23)FormatterServices.GetUninitializedObject(typeof(_003CCaptureToTextureCoroutine_003Ed__23));
			_003CCaptureToTextureCoroutine_003Ed__24._003C_003E1__state = 0;
			_003CCaptureToTextureCoroutine_003Ed__24._003C_003E4__this = this;
			_003CCaptureToTextureCoroutine_003Ed__24.texture = texture;
			_003CCaptureToTextureCoroutine_003Ed__24.width = width;
			_003CCaptureToTextureCoroutine_003Ed__24.height = height;
			_003CCaptureToTextureCoroutine_003Ed__24.cameras = cameras;
			_003CCaptureToTextureCoroutine_003Ed__24.canvas = canvas;
			_003CCaptureToTextureCoroutine_003Ed__24.captureMode = captureMode;
			_003CCaptureToTextureCoroutine_003Ed__24.antiAliasing = antiAliasing;
			_003CCaptureToTextureCoroutine_003Ed__24.captureGameUI = captureGameUI;
			_003CCaptureToTextureCoroutine_003Ed__24.colorFormat = colorFormat;
			_003CCaptureToTextureCoroutine_003Ed__24.recomputeAlphaMask = recomputeAlphaMask;
			return _003CCaptureToTextureCoroutine_003Ed__24;
		}

		[IteratorStateMachine(typeof(_003CCaptureResolutionCoroutine_003Ed__24))]
		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x3C2FC68", Offset = "0x3C2FC68", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv66.captureResolution = captureResolution;\n\tv66.cameras = cameras;\n\tv66.canvas = canvas;\n\tv66.captureMode = captureMode;\n\tv66.antiAliasing = antiAliasing;\n\tv66.captureGameUI = captureGameUI;\n\tv66.colorFormat = colorFormat;\n\tv66.recomputeAlphaMask = recomputeAlphaMask;\n\treturn v66;\nL_0025:\n\tv66 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureResolutionCoroutine>d__24();\n\tSystem.Object::.ctor(v66);\n\tv66.<>1__state = 0;\n\tv66.<>4__this = this;\n")]
		public IEnumerator CaptureResolutionCoroutine(ScreenshotResolution captureResolution, List<Camera> cameras = null, List<Canvas> canvas = null, CaptureMode captureMode = CaptureMode.RENDER_TO_TEXTURE, int antiAliasing = 8, bool captureGameUI = true, ColorFormat colorFormat = ColorFormat.RGB, bool recomputeAlphaMask = false)
		{
			_003CCaptureResolutionCoroutine_003Ed__24 _003CCaptureResolutionCoroutine_003Ed__25 = (_003CCaptureResolutionCoroutine_003Ed__24)FormatterServices.GetUninitializedObject(typeof(_003CCaptureResolutionCoroutine_003Ed__24));
			_003CCaptureResolutionCoroutine_003Ed__25._003C_003E1__state = 0;
			_003CCaptureResolutionCoroutine_003Ed__25._003C_003E4__this = this;
			_003CCaptureResolutionCoroutine_003Ed__25.captureResolution = captureResolution;
			_003CCaptureResolutionCoroutine_003Ed__25.cameras = cameras;
			_003CCaptureResolutionCoroutine_003Ed__25.canvas = canvas;
			_003CCaptureResolutionCoroutine_003Ed__25.captureMode = captureMode;
			_003CCaptureResolutionCoroutine_003Ed__25.antiAliasing = antiAliasing;
			_003CCaptureResolutionCoroutine_003Ed__25.captureGameUI = captureGameUI;
			_003CCaptureResolutionCoroutine_003Ed__25.colorFormat = colorFormat;
			_003CCaptureResolutionCoroutine_003Ed__25.recomputeAlphaMask = recomputeAlphaMask;
			return _003CCaptureResolutionCoroutine_003Ed__25;
		}

		[IteratorStateMachine(typeof(_003CCaptureAllCoroutine_003Ed__25))]
		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x3C306D8", Offset = "0x3C306D8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv76.resolutions = resolutions;\n\tv76.cameras = cameras;\n\tv76.overlays = overlays;\n\tv76.captureMode = captureMode;\n\tv76.antiAliasing = antiAliasing;\n\tv76.captureGameUI = captureGameUI;\n\tv76.colorFormat = colorFormat;\n\tv76.recomputeAlphaMask = recomputeAlphaMask;\n\tv76.stopTime = stopTime;\n\tv76.restore = restore;\n\tv76.forceUICullingLayer = forceUICullingLayer;\n\tv76.disableHDRPFX = disableHDRPFX;\n\treturn v76;\nL_002B:\n\tv76 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAllCoroutine>d__25();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv76.<>4__this = this;\n")]
		public IEnumerator CaptureAllCoroutine(List<ScreenshotResolution> resolutions, List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, CaptureMode captureMode, int antiAliasing = 8, bool captureGameUI = true, ColorFormat colorFormat = ColorFormat.RGB, bool recomputeAlphaMask = false, bool stopTime = false, bool restore = true, bool forceUICullingLayer = false, bool disableHDRPFX = true)
		{
			_003CCaptureAllCoroutine_003Ed__25 _003CCaptureAllCoroutine_003Ed__26 = (_003CCaptureAllCoroutine_003Ed__25)FormatterServices.GetUninitializedObject(typeof(_003CCaptureAllCoroutine_003Ed__25));
			_003CCaptureAllCoroutine_003Ed__26._003C_003E1__state = 0;
			_003CCaptureAllCoroutine_003Ed__26._003C_003E4__this = this;
			_003CCaptureAllCoroutine_003Ed__26.resolutions = resolutions;
			_003CCaptureAllCoroutine_003Ed__26.cameras = cameras;
			_003CCaptureAllCoroutine_003Ed__26.overlays = overlays;
			_003CCaptureAllCoroutine_003Ed__26.captureMode = captureMode;
			_003CCaptureAllCoroutine_003Ed__26.antiAliasing = antiAliasing;
			_003CCaptureAllCoroutine_003Ed__26.captureGameUI = captureGameUI;
			_003CCaptureAllCoroutine_003Ed__26.colorFormat = colorFormat;
			_003CCaptureAllCoroutine_003Ed__26.recomputeAlphaMask = recomputeAlphaMask;
			_003CCaptureAllCoroutine_003Ed__26.stopTime = stopTime;
			_003CCaptureAllCoroutine_003Ed__26.restore = restore;
			_003CCaptureAllCoroutine_003Ed__26.forceUICullingLayer = forceUICullingLayer;
			_003CCaptureAllCoroutine_003Ed__26.disableHDRPFX = disableHDRPFX;
			return _003CCaptureAllCoroutine_003Ed__26;
		}

		[IteratorStateMachine(typeof(_003CCaptureResolutionTextureCoroutine_003Ed__26))]
		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x3C3B6E0", Offset = "0x3C3B6E0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv57.resolution = resolution;\n\tv57.captureMode = captureMode;\n\tv57.antiAliasing = antiAliasing;\n\tv57.colorFormat = colorFormat;\n\treturn v57;\nL_001F:\n\tv57 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureResolutionTextureCoroutine>d__26();\n\tSystem.Object::.ctor(v57);\n\tv57.<>1__state = 0;\n\tv57.<>4__this = this;\n")]
		private IEnumerator CaptureResolutionTextureCoroutine(ScreenshotResolution resolution, CaptureMode captureMode, int antiAliasing, ColorFormat colorFormat)
		{
			_003CCaptureResolutionTextureCoroutine_003Ed__26 _003CCaptureResolutionTextureCoroutine_003Ed__27 = (_003CCaptureResolutionTextureCoroutine_003Ed__26)FormatterServices.GetUninitializedObject(typeof(_003CCaptureResolutionTextureCoroutine_003Ed__26));
			_003CCaptureResolutionTextureCoroutine_003Ed__27._003C_003E1__state = 0;
			_003CCaptureResolutionTextureCoroutine_003Ed__27._003C_003E4__this = this;
			_003CCaptureResolutionTextureCoroutine_003Ed__27.resolution = resolution;
			_003CCaptureResolutionTextureCoroutine_003Ed__27.captureMode = captureMode;
			_003CCaptureResolutionTextureCoroutine_003Ed__27.antiAliasing = antiAliasing;
			_003CCaptureResolutionTextureCoroutine_003Ed__27.colorFormat = colorFormat;
			return _003CCaptureResolutionTextureCoroutine_003Ed__27;
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x3C3B00C", Offset = "0x3C3B00C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = UnityEngine.Texture::get_width(targetTexture);\n\tv36 = UnityEngine.Texture::get_height(targetTexture);\n\t// 27 MakeStruct v45 @ AGG3C3B060_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v16 @ X0_v2 (System.Int32), v36 @ X0_v4 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(targetTexture, v45, 0, 0);\n\tUnityEngine.Texture2D::Apply(targetTexture, 0);\n\treturn;\n")]
		private static void CaptureScreenToTexture(Texture2D targetTexture)
		{
			int width = targetTexture.width;
			int height = targetTexture.height;
			Rect source = default(Rect);
			source.x = 0f;
			source.y = 0f;
			source.width = width;
			source.height = height;
			targetTexture.ReadPixels(source, 0, 0);
			targetTexture.Apply(updateMipmaps: false);
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x3C3B7BC", Offset = "0x3C3B7BC", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tgoto L_0043;\nL_0043:\n\t;\n\tv79 = v77.<>9__28_0 == 0;\n\tv80 = ~v79;\n\tv126 = v77.<>9__28_0;\n\tif (v80) goto L_008A;\n\tgoto L_0071;\nL_0050:\n\tgoto L_0063;\nL_0063:\n\tUnityEngine.Debug::LogError(\"Cameras is null\");\n\treturn;\nL_0071:\n\tgoto L_0079;\nL_008A:\n\tv132 = System.Linq.Enumerable::Where(cameras, v126);\n\tgoto L_009B;\n\tgoto L_00A9;\nL_00BA:\n\tv238 = System.Linq.Enumerable::Select(v132, v233);\n\tv253 = System.Linq.Enumerable::ToList(v238);\n\tgoto L_00D5;\nL_003A:\n\tv57 = cameras == 0;\n\tif (v57) goto L_0050;\nL_0079:\n\tv196 = new System.Func`2<AlmostEngine.Screenshot.ScreenshotCamera, System.Boolean>();\n\tSystem.Func`2<AlmostEngine.Screenshot.ScreenshotCamera, System.Boolean>::.ctor(v196, v191.<>9, Il2CppMethodInfo);\n\tv242.<>9__28_0 = v196;\n\tv126 = v196;\nL_009B:\n\tv208 = v206.<>9__28_1 == 0;\n\tv209 = ~v208;\n\tv233 = v206.<>9__28_1;\n\tif (v209) goto L_00BA;\nL_00A9:\n\tv251 = new System.Func`2<AlmostEngine.Screenshot.ScreenshotCamera, UnityEngine.Camera>();\n\tSystem.Func`2<AlmostEngine.Screenshot.ScreenshotCamera, UnityEngine.Camera>::.ctor(v251, v246.<>9, Il2CppMethodInfo);\n\tv265.<>9__28_1 = v251;\n\tv233 = v251;\nL_00D5:\n\tAlmostEngine.Screenshot.ScreenshotTaker::CaptureCamerasToTexture(v253, targetTexture, renderTexture);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CaptureCamerasToTexture(List<ScreenshotCamera> cameras, Texture2D targetTexture, RenderTexture renderTexture)
		{
			if (cameras != null)
			{
				bool flag = _003C_003Ec._003C_003E9__28_0 == null;
				bool flag2 = !flag;
				Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__28_0;
				if (!flag2)
				{
					predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__28_0 = (ScreenshotCamera x) => x.m_Active && x.m_Camera != null && x.m_Camera.enabled);
				}
				IEnumerable<object> source = cameras.Where(predicate);
				bool flag3 = _003C_003Ec._003C_003E9__28_1 == null;
				bool flag4 = !flag3;
				Func<object, object> selector = (Func<object, object>)_003C_003Ec._003C_003E9__28_1;
				if (!flag4)
				{
					selector = (Func<object, object>)(_003C_003Ec._003C_003E9__28_1 = (ScreenshotCamera x) => x.m_Camera);
				}
				IEnumerable<object> source2 = source.Select(selector);
				List<object> cameras2 = source2.ToList();
				CaptureCamerasToTexture((List<Camera>)(object)cameras2, targetTexture, renderTexture);
			}
			else
			{
				Debug.LogError("Cameras is null");
			}
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x3C3B158", Offset = "0x3C3B158", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv147 = 0xB2A5000 + 0xEA8;\n\tv80 = System.Collections.Generic.List`1<UnityEngine.Camera>::GetEnumerator(cameras);\n\tv142 = v80._list;\n\tv214 = UnityEngine.Camera::get_targetTexture(v80.Current);\n\tUnityEngine.Camera::set_targetTexture(v80.Current, renderTexture);\n\tUnityEngine.Camera::Render(v80.Current);\n\tUnityEngine.Camera::set_targetTexture(v80.Current, v214);\n\tgoto L_0043;\nL_005C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v142 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.Camera>));\n\tv118 = &v142 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.Camera>);\n\tv119 = 0;\n\tv148 = v147;\n\tv153 = Il2CppMethodInfo;\nL_005D:\n\tv161 = renderTexture == 0;\n\tv115 = v117;\n\tv147 = v5;\n\tv151 = 0;\n\tif (v161) goto L_008B;\n\tv225 = UnityEngine.RenderTexture::get_width(renderTexture);\n\tv158 = UnityEngine.RenderTexture::get_height(renderTexture);\n\tv162 = targetTexture == 0;\n\tv115 = v118;\n\tv147 = v148;\n\tv151 = v153;\n\tif (v162) goto L_008B;\n\t// 116 MakeStruct v237 @ AGG3C3B2C8_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, 0, v225 @ X0_v20 (System.Int32), v158 @ X0_v22 (System.Int32)\n\tUnityEngine.Texture2D::ReadPixels(targetTexture, v237, 0, 0);\n\tUnityEngine.Texture2D::Apply(targetTexture, 0);\n\tUnityEngine.RenderTexture::set_active(v57);\n\treturn;\nL_009A:\n\tv190 = v151 != 1;\n\tif (v190) goto L_00A9;\n\tv193 = 0x8BF5BC4(v170, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = 0x8BF5BF4(v193, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv153 = *([v147 @ X24_v1 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v115);\n\tv201 = *([v193 @ X0_v13]) == 0;\n\tv118 = v115;\n\tv119 = *([v193 @ X0_v13]);\n\tv148 = v147;\n\tif (v201) goto L_005D;\n\tv199 = new System.OutOfMemoryException();\n\tv119 = *([v193 @ X0_v13]);\n\tv170 = v199;\nL_00A9:\n\tv206 = 0x3177254(&v119 @ stack_-78_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv211 = 0x8BF0368(v170, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv217 = 0xA1B8(v211, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0023:\n\tv142 = 0;\n\tv57 = UnityEngine.RenderTexture::get_active();\n\tUnityEngine.RenderTexture::set_active(renderTexture);\n\tv67 = cameras == 0;\n\tv115 = &v142 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.Camera>);\n\tv119 = 0;\n\tv151 = Il2CppMethodInfo;\n\tif (v67) goto L_008B;\nL_008B:\n\tv170 = new System.NullReferenceException();\n\tgoto L_009A;\nL_0043:\n\tv180 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v142 @ stack_-68_v4 (System.Collections.Generic.List`1<UnityEngine.Camera>));\n\tv192 = v180 == 0;\n\tif (v192) goto L_005C;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void CaptureCamerasToTexture(List<Camera> cameras, Texture2D targetTexture, RenderTexture renderTexture)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::CaptureCamerasToTexture");
		}

		[IteratorStateMachine(typeof(_003CCaptureAlphaMaskCoroutine_003Ed__30))]
		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x3C3BA60", Offset = "0x3C3BA60", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv57.resolution = resolution;\n\tv57.captureMode = captureMode;\n\tv57.antiAliasing = antiAliasing;\n\tv57.colorFormat = colorFormat;\n\treturn v57;\nL_001F:\n\tv57 = new AlmostEngine.Screenshot.ScreenshotTaker+<CaptureAlphaMaskCoroutine>d__30();\n\tSystem.Object::.ctor(v57);\n\tv57.<>1__state = 0;\n\tv57.<>4__this = this;\n")]
		private IEnumerator CaptureAlphaMaskCoroutine(ScreenshotResolution resolution, CaptureMode captureMode, int antiAliasing, ColorFormat colorFormat, bool disableHDRPFX = true)
		{
			_003CCaptureAlphaMaskCoroutine_003Ed__30 _003CCaptureAlphaMaskCoroutine_003Ed__31 = (_003CCaptureAlphaMaskCoroutine_003Ed__30)FormatterServices.GetUninitializedObject(typeof(_003CCaptureAlphaMaskCoroutine_003Ed__30));
			_003CCaptureAlphaMaskCoroutine_003Ed__31._003C_003E1__state = 0;
			_003CCaptureAlphaMaskCoroutine_003Ed__31._003C_003E4__this = this;
			_003CCaptureAlphaMaskCoroutine_003Ed__31.resolution = resolution;
			_003CCaptureAlphaMaskCoroutine_003Ed__31.captureMode = captureMode;
			_003CCaptureAlphaMaskCoroutine_003Ed__31.antiAliasing = antiAliasing;
			_003CCaptureAlphaMaskCoroutine_003Ed__31.colorFormat = colorFormat;
			return _003CCaptureAlphaMaskCoroutine_003Ed__31;
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x3C3BB3C", Offset = "0x3C3BB3C", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv62 = UnityEngine.Texture::get_width(src);\n\tv68 = UnityEngine.Texture::get_height(src);\n\tv72 = UnityEngine.Texture2D::get_format(src);\n\tv77 = UnityEngine.Texture::get_mipmapCount(src);\n\tv80 = new UnityEngine.Texture2D();\n\tv117 = v77 < 0;\n\tv114 = v77 == 0;\n\tv108 = v77 ^ v77;\n\tv105 = v77 & v108;\n\tv102 = v105 < 0;\n\tv153 = v117 == v102;\n\tv96 = ~v114;\n\tv99 = v153 & v96;\n\tUnityEngine.Texture2D::.ctor(v80, v62, v68, v72, v99);\n\tgoto L_0054;\nL_0054:\n\tgoto L_0058;\nL_0058:\n\tgoto L_0060;\nL_0060:\n\tUnityEngine.Graphics::CopyTexture(src, 0, 0, v80, 0, 0);\n\treturn v80;\n")]
		public static Texture2D CloneTexture(Texture2D src)
		{
			int width = src.width;
			int height = src.height;
			TextureFormat format = src.format;
			int mipmapCount = src.mipmapCount;
			bool mipChain = default(bool);
			Texture2D texture2D = new Texture2D(width, height, format, mipChain);
			bool flag = mipmapCount < 0;
			bool flag2 = mipmapCount == 0;
			int num = mipmapCount ^ mipmapCount;
			int num2 = mipmapCount & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			mipChain = flag4 && flag5;
			Graphics.CopyTexture(src, 0, 0, texture2D, 0, 0);
			return texture2D;
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x3C3BCB4", Offset = "0x3C3BCB4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_002B:\n\tUnityEngine.Graphics::CopyTexture(src, 0, 0, dest, 0, 0);\n\treturn;\nL_001B:\n\tgoto L_002B;\n")]
		public static void CloneTexture(Texture2D src, Texture2D dest)
		{
			Graphics.CopyTexture(src, 0, 0, dest, 0, 0);
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x3C3BD30", Offset = "0x3C3BD30", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv185 = 0;\n\tgoto L_003A;\nL_002C:\n\tv185 = v185 + 1;\n\tv202 = this.m_Cameras;\nL_003A:\n\tv101 = v185 >= v202.Count;\n\tif (v101) goto L_0086;\n\tv151 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(v202, v185);\n\tv100 = v151.m_Active != 1;\n\tif (v100) goto L_002C;\n\tv153 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v185);\n\tgoto L_005C;\nL_005C:\n\tv298 = UnityEngine.Object::op_Inequality(v153.m_Camera, 0);\n\tv302 = ~v298;\n\tif (v302) goto L_002C;\n\tgoto L_006E;\nL_006E:\n\tv155 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v185);\n\tv300 = UnityEngine.Behaviour::get_enabled(v155.m_Camera);\n\tv304 = ~v300;\n\tif (v304) goto L_002C;\n\tv158 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v185);\nL_FFFFFFFF:\n\tv414 = v158.m_Camera;\n\tgoto L_00FB;\nL_0086:\n\tgoto L_0089;\nL_0089:\n\tv159 = UnityEngine.Object::FindObjectsOfType();\n\tv316 = v159.Length < 1;\n\tif (v316) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv148 = 0;\nL_FFFFFFFF:\n\tv339 = 0;\n\tgoto L_00B1;\nL_FFFFFFFF:\n\tv339 = v159[v148 @ X23_v9 (System.Int32)];\nL_00B1:\n\tv356 = UnityEngine.Behaviour::get_enabled(v159[v148 @ X23_v9 (System.Int32)]);\n\tv364 = ~v356;\n\tif (v364) goto L_00A0;\n\tv374 = UnityEngine.Camera::get_targetDisplay(v159[v148 @ X23_v9 (System.Int32)]);\n\tv420 = v374 == 0;\n\tv403 = ~v420;\n\tif (v403) goto L_00A0;\n\tgoto L_00C1;\nL_00C1:\n\tv428 = UnityEngine.Object::op_Equality(v339, 0);\n\tv431 = v428 == 0;\n\tv432 = ~v431;\n\tif (v432) goto L_FFFFFFFF;\n\tgoto L_00D2;\nL_00D2:\n\tv67 = UnityEngine.Camera::get_depth(v159[v148 @ X23_v9 (System.Int32)]);\n\tv378 = UnityEngine.Camera::get_depth(v339);\n\tv393 = v67 < v378;\n\tif (v393) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_FFFFFFFF:\n\tv414 = 0;\nL_00EB:\n\tv360 = UnityEngine.Object::op_Inequality(v414, 0);\n\tv366 = v360 == 0;\n\tif (v366) goto L_0111;\nL_00FB:\n\treturn v414;\nL_0111:\n\treturnVal3 = UnityEngine.Camera::get_main();\n\treturn returnVal3;\nL_0021:\n\tv202 = this.m_Cameras;\nL_00E7:\n\tgoto L_00EB;\nL_00A0:\n\tv148 = v148 + 1;\n\tv324 = v148 >= v159.Length;\nL_FFFFFFFF:\n\tv414 = v339;\n\tif (v324) goto L_00E7;\n")]
		private Camera GetFirstActiveCamera()
		{
			List<ScreenshotCamera> cameras = m_Cameras;
			int num = 0;
			while (true)
			{
				UnityEngine.Object obj;
				if (num < cameras.Count)
				{
					ScreenshotCamera screenshotCamera = cameras[num];
					if (!screenshotCamera.m_Active)
					{
						goto IL_0013;
					}
					ScreenshotCamera screenshotCamera2 = m_Cameras[num];
					if (!(screenshotCamera2.m_Camera != null))
					{
						goto IL_0013;
					}
					ScreenshotCamera screenshotCamera3 = m_Cameras[num];
					if (!screenshotCamera3.m_Camera.enabled)
					{
						goto IL_0013;
					}
					ScreenshotCamera screenshotCamera4 = m_Cameras[num];
					obj = screenshotCamera4.m_Camera;
				}
				else
				{
					Camera[] array = UnityEngine.Object.FindObjectsOfType<Camera>();
					if (array.Length >= 1)
					{
						int num2 = 0;
						UnityEngine.Object obj2 = null;
						bool flag;
						do
						{
							if (array[num2].enabled && array[num2].targetDisplay == 0)
							{
								if (!(obj2 == null))
								{
									float depth = array[num2].depth;
									float depth2 = ((Camera)obj2).depth;
									if (!(depth < depth2))
									{
										goto IL_02f9;
									}
								}
								obj2 = array[num2];
							}
							goto IL_02f9;
							IL_02f9:
							num2++;
							flag = num2 >= array.Length;
							obj = obj2;
						}
						while (!flag);
					}
					else
					{
						obj = null;
					}
					if (!(obj != null))
					{
						break;
					}
				}
				return (Camera)obj;
				IL_0013:
				num++;
				cameras = m_Cameras;
			}
			return Camera.main;
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x3C3BFEC", Offset = "0x3C3BFEC", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv197 = v51.Count;\n\tv62 = v51.Count < 1;\n\tif (v62) goto L_0090;\n\tgoto L_0044;\nL_003F:\n\tv212 = v197 <= 0;\n\tif (v212) goto L_0090;\nL_0044:\n\tv197 = v197 - 1;\n\tv165 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v197);\n\tv106 = v165.m_Active != 1;\n\tif (v106) goto L_003F;\n\tv167 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v197);\n\tgoto L_0066;\nL_0066:\n\tv336 = UnityEngine.Object::op_Inequality(v167.m_Camera, 0);\n\tv339 = ~v336;\n\tif (v339) goto L_003F;\n\tgoto L_0076;\nL_0076:\n\tv169 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v197);\n\tv338 = UnityEngine.Behaviour::get_enabled(v169.m_Camera);\n\tv341 = ~v338;\n\tif (v341) goto L_003F;\n\tv172 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(this.m_Cameras, v197);\nL_FFFFFFFF:\n\tv442 = v172.m_Camera;\n\tgoto L_0108;\nL_0090:\n\tgoto L_0093;\nL_0093:\n\tv173 = UnityEngine.Object::FindObjectsOfType();\n\tv327 = v173.Length < 1;\n\tif (v327) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv113 = 0;\nL_FFFFFFFF:\n\tv365 = 0;\n\tgoto L_00BB;\nL_FFFFFFFF:\n\tv365 = v173[v113 @ X23_v8 (System.Int32)];\nL_00BB:\n\tv380 = UnityEngine.Behaviour::get_enabled(v173[v113 @ X23_v8 (System.Int32)]);\n\tv386 = ~v380;\n\tif (v386) goto L_00AA;\n\tv397 = UnityEngine.Camera::get_targetDisplay(v173[v113 @ X23_v8 (System.Int32)]);\n\tv450 = v397 == 0;\n\tv431 = ~v450;\n\tif (v431) goto L_00AA;\n\tgoto L_00CB;\nL_00CB:\n\tv457 = UnityEngine.Object::op_Equality(v365, 0);\n\tv462 = v457 == 0;\n\tv463 = ~v462;\n\tif (v463) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tv75 = UnityEngine.Camera::get_depth(v173[v113 @ X23_v8 (System.Int32)]);\n\tv403 = UnityEngine.Camera::get_depth(v365);\n\tv421 = v75 < v403;\n\tv418 = v75 == v403;\n\tv475 = v75 == v75;\n\tv415 = v403 == v403;\n\tv424 = v475 & v415;\n\tv412 = ~v424;\n\tv476 = v421 == v412;\n\tv399 = ~v418;\n\tv409 = v476 & v399;\n\tif (v409) goto L_FFFFFFFF;\n\tgoto L_00AA;\nL_FFFFFFFF:\n\tv442 = 0;\nL_00F8:\n\tv384 = UnityEngine.Object::op_Inequality(v442, 0);\n\tv388 = v384 == 0;\n\tif (v388) goto L_011E;\nL_0108:\n\treturn v442;\nL_011E:\n\treturnVal3 = UnityEngine.Camera::get_main();\n\treturn returnVal3;\nL_0021:\n\tv51 = this.m_Cameras;\nL_00F4:\n\tgoto L_00F8;\nL_00AA:\n\tv113 = v113 + 1;\n\tv351 = v113 >= v173.Length;\nL_FFFFFFFF:\n\tv442 = v365;\n\tif (v351) goto L_00F4;\n")]
		private Camera GetLastActiveCamera()
		{
			List<ScreenshotCamera> cameras = m_Cameras;
			int num = cameras.Count;
			UnityEngine.Object obj;
			if (cameras.Count >= 1)
			{
				while (true)
				{
					num--;
					ScreenshotCamera screenshotCamera = m_Cameras[num];
					if (screenshotCamera.m_Active)
					{
						ScreenshotCamera screenshotCamera2 = m_Cameras[num];
						if (screenshotCamera2.m_Camera != null)
						{
							ScreenshotCamera screenshotCamera3 = m_Cameras[num];
							if (screenshotCamera3.m_Camera.enabled)
							{
								break;
							}
						}
					}
					if (num > 0)
					{
						continue;
					}
					goto IL_0164;
				}
				ScreenshotCamera screenshotCamera4 = m_Cameras[num];
				obj = screenshotCamera4.m_Camera;
				goto IL_0355;
			}
			goto IL_0164;
			IL_0355:
			return (Camera)obj;
			IL_0164:
			Camera[] array = UnityEngine.Object.FindObjectsOfType<Camera>();
			if (array.Length >= 1)
			{
				int num2 = 0;
				UnityEngine.Object obj2 = null;
				bool flag9;
				do
				{
					if (array[num2].enabled && array[num2].targetDisplay == 0)
					{
						if (!(obj2 == null))
						{
							float depth = array[num2].depth;
							float depth2 = ((Camera)obj2).depth;
							bool flag = depth < depth2;
							bool flag2 = depth == depth2;
							bool flag3 = depth == depth;
							bool flag4 = depth2 == depth2;
							bool flag5 = flag3 && flag4;
							bool flag6 = !flag5;
							bool flag7 = flag == flag6;
							bool flag8 = !flag2;
							if (!(flag7 && flag8))
							{
								goto IL_037c;
							}
						}
						obj2 = array[num2];
					}
					goto IL_037c;
					IL_037c:
					num2++;
					flag9 = num2 >= array.Length;
					obj = obj2;
				}
				while (!flag9);
			}
			else
			{
				obj = null;
			}
			if (obj != null)
			{
				goto IL_0355;
			}
			return Camera.main;
		}

		[IteratorStateMachine(typeof(_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35))]
		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x3C3C2A8", Offset = "0x3C3C2A8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.targetTexture = targetTexture;\n\treturn v46;\nL_0018:\n\tv46 = new AlmostEngine.Screenshot.ScreenshotTaker+<MultiDisplayCopyRenderBufferToTextureCoroutine>d__35();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		private IEnumerator MultiDisplayCopyRenderBufferToTextureCoroutine(Texture2D targetTexture)
		{
			_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35 _003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__36 = (_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35)FormatterServices.GetUninitializedObject(typeof(_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__35));
			_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__36._003C_003E1__state = 0;
			_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__36._003C_003E4__this = this;
			_003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__36.targetTexture = targetTexture;
			return _003CMultiDisplayCopyRenderBufferToTextureCoroutine_003Ed__36;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x3C3C360", Offset = "0x3C3C360", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv134 = resolution.m_Width;\n\tv131 = resolution.m_Height;\n\tgoto L_009A;\nL_0029:\n\tv60 = resolution.m_IgnoreOrientation == 0;\n\tif (v60) goto L_002E;\nL_FFFFFFFF:\n\tv203 = 0x14;\n\tgoto L_0042;\nL_002E:\n\tv143 = resolution.m_Orientation < 2;\n\tv144 = ~v143;\n\tv154 = ~v144;\n\tv155 = ~v154;\n\tif (v155) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv203 = 0x14;\n\tgoto L_0042;\nL_FFFFFFFF:\n\tv203 = 0x18;\n\tgoto L_0053;\nL_FFFFFFFF:\n\tv221 = 1f;\nL_FFFFFFFF:\n\tv136 = 0xFFFFFFFF80000000;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv136 = v222;\nL_FFFFFFFF:\n\tv261 = 0x18;\n\tgoto L_0080;\nL_006C:\n\tv240 = resolution.m_Orientation < 2;\n\tv241 = ~v240;\n\tv251 = ~v241;\n\tv252 = ~v251;\n\tif (v252) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv261 = 0x18;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv261 = 0x14;\nL_FFFFFFFF:\n\tv133 = 0xFFFFFFFF80000000;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv133 = v73;\nL_009A:\n\t;\n\tAlmostEngine.Screenshot.ScreenshotTaker::GetOrCreateTexture(&resolution.m_Texture (UnityEngine.Texture2D), v134, v131, colorFormat);\n\treturn resolution.m_Texture;\nL_0017:\n\tv45 = noScale == 0;\n\tif (v45) goto L_0029;\nL_0042:\n\tv221 = resolution.m_Scale;\n\tv209 = resolution.m_Scale < 0;\n\tv210 = resolution.m_Scale == 0;\n\tv213 = resolution.m_Scale == resolution.m_Scale;\n\tv214 = ~v213;\n\tv216 = v209 == v214;\n\tv64 = ~v210;\n\tv217 = v216 & v64;\n\tv218 = ~v217;\n\tif (v218) goto L_FFFFFFFF;\nL_0053:\n\tv222 = v221 * *([resolution @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v203 @ X9_v3 (System.Int32)]);\n\tv226 = v222 == 0x7F800000;\n\tv233 = ~v226;\n\tif (v233) goto L_FFFFFFFF;\nL_0067:\n\tv237 = resolution.m_IgnoreOrientation == 0;\n\tif (v237) goto L_006C;\nL_0080:\n\tv73 = v221 * *([resolution @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v261 @ X8_v6 (System.Int32)]);\n\tv105 = v73 == 0x7F800000;\n\tv77 = ~v105;\n\tif (v77) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv131 = v133;\nL_FFFFFFFF:\n\tv134 = v136;\n\tgoto L_009A;\n")]
		public static Texture2D GetOrCreateTexture(ScreenshotResolution resolution, ColorFormat colorFormat, bool noScale = false)
		{
			//IL_02f4: Expected I4, but got F4
			//IL_02fc: Expected I4, but got F4
			int width;
			int height;
			if (noScale)
			{
				width = resolution.m_Width;
				height = resolution.m_Height;
			}
			else
			{
				if (resolution.m_IgnoreOrientation)
				{
					int num = 20;
				}
				else if ((uint)resolution.m_Orientation < 2u)
				{
					int num = 20;
				}
				else
				{
					int num = 24;
				}
				float num2 = resolution.m_Scale;
				bool flag = resolution.m_Scale < 0f;
				bool flag2 = resolution.m_Scale == 0f;
				bool flag3 = resolution.m_Scale == resolution.m_Scale;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				if (!(flag5 && flag6))
				{
					num2 = 1f;
				}
				float num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [resolution @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v203 @ X9_v3 (System.Int32)]");
				float num4 = num3 * 0f;
				float num5 = ((num4 != 1f / 0f) ? num4 : -0f);
				if (resolution.m_IgnoreOrientation)
				{
					int num6 = 24;
				}
				else if ((uint)resolution.m_Orientation < 2u)
				{
					int num6 = 24;
				}
				else
				{
					int num6 = 20;
				}
				float num7 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [resolution @ X0 (AlmostEngine.Screenshot.ScreenshotResolution)+v261 @ X8_v6 (System.Int32)]");
				float num8 = num7 * 0f;
				float num9 = ((num8 != 1f / 0f) ? num8 : -0f);
				height = (int)num9;
				width = (int)num5;
			}
			GetOrCreateTexture(ref resolution.m_Texture, width, height, colorFormat);
			return resolution.m_Texture;
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x3C3AE84", Offset = "0x3C3AE84", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_FFFFFFFF:\n\tv68 = 5;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv68 = 3;\nL_0037:\n\tv76 = UnityEngine.Object::op_Equality(*([texture @ X0 (UnityEngine.Texture2D&)]), 0);\n\tv78 = ~v76;\n\tif (v78) goto L_0061;\n\tv91 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v91, width, height, v68, 0);\n\t*([texture @ X0 (UnityEngine.Texture2D&)]) = v91;\n\treturn;\nL_0061:\n\tv108 = UnityEngine.Texture::get_width(*([texture @ X0 (UnityEngine.Texture2D&)]));\n\tv118 = v108 != width;\n\tif (v118) goto L_00AA;\n\tv187 = UnityEngine.Texture::get_height(*([texture @ X0 (UnityEngine.Texture2D&)]));\n\tv121 = v187 != height;\n\tif (v121) goto L_00AA;\n\tv188 = UnityEngine.Texture2D::get_format(*([texture @ X0 (UnityEngine.Texture2D&)]));\n\tv176 = v188 != v68;\n\tif (v176) goto L_00AA;\n\treturn;\nL_00AA:\n\tv204 = UnityEngine.Texture2D::Reinitialize(*([texture @ X0 (UnityEngine.Texture2D&)]), width, height, v68, 0);\n\treturn;\nL_0029:\n\tv63 = colorFormat != 1;\n\tif (v63) goto L_FFFFFFFF;\nL_0033:\n\tgoto L_0037;\n")]
		public static void GetOrCreateTexture(ref Texture2D texture, int width, int height, ColorFormat colorFormat)
		{
			TextureFormat textureFormat = ((colorFormat != ColorFormat.RGBA) ? TextureFormat.RGB24 : TextureFormat.ARGB32);
			if (texture == null)
			{
				Texture2D texture2D = new Texture2D(width, height, textureFormat, mipChain: false);
				texture = texture2D;
				return;
			}
			int width2 = texture.width;
			if (width2 == width)
			{
				int height2 = texture.height;
				if (height2 == height)
				{
					TextureFormat format = texture.format;
					if (format == textureFormat)
					{
						return;
					}
				}
			}
			bool flag = texture.Reinitialize(width, height, textureFormat, hasMipMap: false);
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x3C3C4A0", Offset = "0x3C3C4A0", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0029:\n\tv66 = resolution.m_IgnoreOrientation != 1;\n\tif (v66) goto L_0037;\n\tv69 = 0x18;\n\tv135 = resolution.m_Width;\n\tv98 = resolution.m_Scale;\n\tv138 = resolution->klass;\n\tgoto L_005A;\nL_0037:\n\tv78 = resolution.m_Orientation < 2;\n\tv79 = ~v78;\n\tv89 = ~v79;\n\tv90 = ~v89;\n\tif (v90) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv230 = 0x14;\n\tgoto L_0049;\nL_FFFFFFFF:\n\tv230 = 0x18;\nL_FFFFFFFF:\n\tv103 = 0x18;\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv103 = 0x14;\nL_005A:\n\tv141 = v98 < 0;\n\tv142 = v98 == 0;\n\tv145 = v98 == v98;\n\tv146 = ~v145;\n\tv148 = v141 == v146;\n\tv149 = ~v142;\n\tv150 = v148 & v149;\n\tv151 = ~v150;\n\tif (v151) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv231 = v98;\n\tgoto L_006B;\nL_FFFFFFFF:\n\tv231 = 1f;\nL_FFFFFFFF:\n\tv171 = 0xFFFFFFFF80000000;\n\tgoto L_007F;\nL_FFFFFFFF:\n\tv171 = v233;\nL_FFFFFFFF:\n\tv254 = 0xFFFFFFFF80000000;\n\tgoto L_009D;\nL_FFFFFFFF:\n\tv254 = v175;\nL_0049:\n\tv125 = resolution + v230;\n\tv106 = ~v79;\n\tv94 = ~v106;\n\tif (v94) goto L_FFFFFFFF;\nL_0051:\n\tv135 = *([v125 @ X9_v8]);\n\tv98 = resolution.m_Scale;\n\tv138 = resolution->klass;\n\tgoto L_005A;\nL_006B:\n\tv233 = v231 * v138;\n\tv237 = v233 == 0x7F800000;\n\tv244 = ~v237;\n\tif (v244) goto L_FFFFFFFF;\nL_007F:\n\tv175 = v231 * v135;\n\tv196 = v175 == 0x7F800000;\n\tv177 = ~v196;\n\tif (v177) goto L_FFFFFFFF;\nL_009D:\n\treturnVal2 = AlmostEngine.Screenshot.ScreenshotTaker::GetOrCreateRenderTexture(v254, v171, antiAliasing, depth, format);\n\treturn returnVal2;\n")]
		private RenderTexture GetOrCreateRenderTexture(ScreenshotResolution resolution, int antiAliasing = 0, int depth = 32, RenderTextureFormat format = RenderTextureFormat.ARGBHalf)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::GetOrCreateRenderTexture");
			return default;
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x3C3C5C4", Offset = "0x3C3C5C4", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv62.width = width;\n\tv62.height = height;\n\tv62.antiAliasing = antiAliasing;\n\tv62.depth = depth;\n\tv62.format = format;\n\tgoto L_005A;\n\tv283 = System.Collections.Generic.List`1<UnityEngine.RenderTexture>::FindIndex(v181.m_RenderTextureCache, v162);\n\tv287 = v283 & 0x80000000;\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_0090;\n\tgoto L_007E;\nL_007E:\n\tv305 = System.Collections.Generic.List`1<UnityEngine.RenderTexture>::get_Item(v187.m_RenderTextureCache, v283);\n\tSystem.Collections.Generic.List`1<UnityEngine.RenderTexture>::RemoveAt(v182.m_RenderTextureCache, v283);\n\tv210 = v305;\n\tgoto L_00A4;\nL_0090:\n\tv164 = new UnityEngine.RenderTexture();\n\tUnityEngine.RenderTexture::.ctor(v164, v62.width, v62.height, v62.depth, v62.format);\n\tv306 = v62.antiAliasing == 0;\n\tv210 = v164;\n\tif (v306) goto L_00A4;\n\tUnityEngine.RenderTexture::set_antiAliasing(v164, v62.antiAliasing);\n\tv210 = v164;\nL_00A4:\n\tgoto L_00AC;\nL_00A7:\n\tUnityEngine.Object::DestroyImmediate(v351);\nL_00AC:\n\tgoto L_00B1;\n\tv87 = v354.Count <= v132.m_MaxRenderTextureCache;\n\tif (v87) goto L_00E5;\n\tgoto L_00CF;\nL_00CF:\n\tv159 = v354.Count - 1;\n\tv351 = System.Collections.Generic.List`1<UnityEngine.RenderTexture>::get_Item(v354, v159);\n\tv166 = v185.m_RenderTextureCache;\n\tv359 = v166.Count - 1;\n\tSystem.Collections.Generic.List`1<UnityEngine.RenderTexture>::RemoveAt(v166, v359);\n\tgoto L_00A7;\nL_00E5:\n\tgoto L_00F0;\nL_00F0:\n\tSystem.Collections.Generic.List`1<UnityEngine.RenderTexture>::Insert(v354, 0, v210);\n\treturn v210;\nL_003F:\n\tv62 = new AlmostEngine.Screenshot.ScreenshotTaker+<>c__DisplayClass41_0();\n\tSystem.Object::.ctor(v62);\nL_005A:\n\tv162 = new System.Predicate`1<UnityEngine.RenderTexture>();\n\tSystem.Predicate`1<UnityEngine.RenderTexture>::.ctor(v162, v62, Il2CppMethodInfo);\nL_00B1:\n\tv354 = v132.m_RenderTextureCache;\n")]
		public static RenderTexture GetOrCreateRenderTexture(int width, int height, int antiAliasing = 0, int depth = 32, RenderTextureFormat format = RenderTextureFormat.ARGBHalf)
		{
			//IL_006f: Expected I4, but got I8
			Predicate<RenderTexture> match = delegate(RenderTexture x)
			{
				int width2 = x.width;
				if (width2 == width)
				{
					int height2 = x.height;
					if (height2 == height)
					{
						if (antiAliasing != 0)
						{
							int antiAliasing2 = x.antiAliasing;
							if (antiAliasing2 != antiAliasing)
							{
								goto IL_0107;
							}
						}
						int depth2 = x.depth;
						if (depth2 == depth)
						{
							RenderTextureFormat format2 = x.format;
							int num2 = format2 - format;
							return num2 == 0;
						}
					}
				}
				goto IL_0107;
				IL_0107:
				return false;
			};
			int num = m_RenderTextureCache.FindIndex(match);
			RenderTexture renderTexture2;
			if ((int)(num & 0x80000000L) == 0)
			{
				RenderTexture renderTexture = m_RenderTextureCache[num];
				m_RenderTextureCache.RemoveAt(num);
				renderTexture2 = renderTexture;
			}
			else
			{
				RenderTexture renderTexture3 = new RenderTexture(width, height, depth, format);
				bool flag = antiAliasing == 0;
				renderTexture2 = renderTexture3;
				if (!flag)
				{
					renderTexture3.antiAliasing = antiAliasing;
					renderTexture2 = renderTexture3;
				}
			}
			List<RenderTexture> renderTextureCache;
			while (true)
			{
				renderTextureCache = m_RenderTextureCache;
				if (renderTextureCache.Count > m_MaxRenderTextureCache)
				{
					int index = renderTextureCache.Count - 1;
					UnityEngine.Object obj = renderTextureCache[index];
					List<RenderTexture> renderTextureCache2 = m_RenderTextureCache;
					int index2 = renderTextureCache2.Count - 1;
					renderTextureCache2.RemoveAt(index2);
					UnityEngine.Object.DestroyImmediate(obj);
					continue;
				}
				break;
			}
			renderTextureCache.Insert(0, renderTexture2);
			return renderTexture2;
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x3C355E8", Offset = "0x3C355E8", Length = "0x504")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0053;\n\tv86 = captureMode < 4;\n\tv87 = ~v86;\n\tv88 = captureMode - 4;\n\tv90 = v88 == 0;\n\tv95 = ~v90;\n\tv96 = v87 & v95;\n\tif (v96) goto L_0172;\n\tv101 = 1 << captureMode;\n\tv103 = v101 & 0x1A;\n\tv105 = v103 == 0;\n\tif (v105) goto L_0172;\nL_007C:\n\tAlmostEngine.Screenshot.ScreenshotTaker::ApplyCameraSettings(v82, this.m_Cameras, captureMode);\n\tgoto L_0087;\n\tgoto L_0099;\n\tv312 = v350;\n\tv540 = renderUI;\n\tv251 = this.m_DisabledOverlays;\n\tv245 = this.m_DisabledOverlays == 0;\n\tv229 = v352;\n\tif (v245) goto L_019C;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Clear(v251);\n\tv195 = v251.Count < 1;\n\tv229 = v352;\n\tif (v195) goto L_00D0;\n\tv229 = 0;\n\tv241 = v251._items;\nL_00D0:\n\tv478 = ~forceUICullingLayer;\n\tif (v478) goto L_00FF;\n\tv252 = this.m_Cameras;\n\tv246 = this.m_Cameras == 0;\n\tif (v246) goto L_019C;\n\tv483 = v252.Count < 1;\n\tif (v483) goto L_00FF;\n\tv501 = ~v540;\n\tif (v501) goto L_00FF;\n\tv550 = AlmostEngine.Screenshot.ScreenshotTaker::FindAllOtherCanvas(v241, this.m_Overlays);\n\tv565 = new System.Func`2<AlmostEngine.Screenshot.ScreenshotOverlay, System.Boolean>();\n\tSystem.Func`2<AlmostEngine.Screenshot.ScreenshotOverlay, System.Boolean>::.ctor(v565, this, Il2CppMethodInfo);\n\tv574 = System.Linq.Enumerable::Where(v550, v565);\n\tv557 = System.Linq.Enumerable::ToList(v574);\n\tv556 = v557;\n\tgoto L_010C;\nL_00FF:\n\tv508 = captureMode == 1;\n\tif (v508) goto L_0110;\n\tv519 = v540 == 0;\n\tv520 = ~v519;\n\tif (v520) goto L_0110;\n\tv556 = AlmostEngine.Screenshot.ScreenshotTaker::FindAllOtherCanvas(v241, this.m_Overlays);\nL_010C:\n\tthis.m_DisabledOverlays = v556;\n\tv241 = v535;\nL_0110:\n\tAlmostEngine.Screenshot.ScreenshotTaker::DisableCanvas(v241, this.m_DisabledOverlays);\n\tAlmostEngine.Screenshot.ScreenshotTaker::ApplyOverlaySettings(v241, this.m_Overlays);\n\tv413 = ~forceUICullingLayer;\n\tif (v413) goto L_0197;\n\tv253 = this.m_Cameras;\n\tv247 = this.m_Cameras == 0;\n\tv229 = this.m_Overlays;\n\tif (v247) goto L_019C;\n\tv194 = v253.Count < 1;\n\tif (v194) goto L_0197;\n\tv414 = ~v540;\n\tif (v414) goto L_0197;\n\tgoto L_0132;\nL_0132:\n\tv586 = UnityEngine.Object::FindObjectsOfType();\n\tv590 = new System.Func`2<UnityEngine.RectTransform, System.Boolean>();\n\tSystem.Func`2<UnityEngine.RectTransform, System.Boolean>::.ctor(v590, this, Il2CppMethodInfo);\n\tv599 = System.Linq.Enumerable::Where(v586, v590);\n\tv602 = System.Linq.Enumerable::ToList(v599);\n\tthis.disabledUIElements = v602;\n\tv248 = this.disabledUIElements == 0;\n\tv229 = v602;\n\tif (v248) goto L_019C;\n\tv609 = System.Collections.Generic.List`1<UnityEngine.RectTransform>::GetEnumerator(this.disabledUIElements);\n\tv173 = v609._list;\n\tv623 = v609.Current == 0;\n\tif (v623) goto L_0198;\n\tv615 = UnityEngine.Component::get_gameObject(v609.Current);\n\tUnityEngine.GameObject::SetActive(v615, 0);\n\tgoto L_0163;\nL_0172:\n\tv116 = this.m_Cameras;\n\tv117 = this.m_Cameras == 0;\n\tv229 = v74;\n\tif (v117) goto L_019C;\n\tv123 = v116.Count < 1;\n\tif (v123) goto L_007C;\n\tAlmostEngine.Screenshot.ScreenshotTaker::DisableCameras(v82, this.m_SceneCameras);\n\tgoto L_007C;\nL_0189:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v173 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\nL_0197:\n\treturn;\nL_0198:\n\tv626 = new System.NullReferenceException();\n\tv229 = 0;\n\tgoto L_019B;\nL_019B:\n\t// 411 Interrupt\n\tv158 = 0;\nL_01AA:\n\tv298 = v229 != 1;\n\tv335 = v267;\n\tif (v298) goto L_01BC;\n\tv324 = 0x8BF5BC4(v267, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv354 = 0x8BF5BF4(v324, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v173 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\n\tv332 = *([v324 @ X0_v16]) == 0;\n\tif (v332) goto L_0197;\n\tv330 = new System.OutOfMemoryException();\n\tv158 = *([v324 @ X0_v16]);\n\tv335 = v330;\n\treturn;\nL_0053:\n\tv173 = 0;\n\tthis.m_Cameras = v56;\n\tv74 = AlmostEngine.Screenshot.ScreenshotTaker::FindAllOtherCameras(v69, this.m_Cameras);\n\tthis.m_SceneCameras = v74;\nL_0087:\n\t;\n\tv286 = v284.<>9__43_0 == 0;\n\tv287 = ~v286;\n\tv312 = v284.<>9__43_0;\n\tv540 = renderUI;\n\tif (v287) goto L_00AD;\nL_0099:\n\tv350 = new System.Func`2<AlmostEngine.Screenshot.ScreenshotOverlay, System.Boolean>();\n\tSystem.Func`2<AlmostEngine.Screenshot.ScreenshotOverlay, System.Boolean>::.ctor(v350, v344.<>9, Il2CppMethodInfo);\n\tv372.<>9__43_0 = v350;\nL_019C:\n\tv267 = new System.NullReferenceException();\n\tgoto L_01AA;\nL_0163:\n\tv620 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v173 @ stack_-78_v4 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\n\tv412 = v620 == 0;\n\tif (v412) goto L_0189;\nL_01BC:\n\tv338 = 0x3177294(&v158 @ stack_-88 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv356 = 0x8BF0368(v335, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv368 = 0xA1B8(v356, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00AD:\n\tv322 = System.Linq.Enumerable::Where(overlays, v312);\n\tv352 = System.Linq.Enumerable::ToList(v322);\n\tthis.m_Overlays = v352;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ApplySettings(List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, CaptureMode captureMode, bool renderUI, bool forceUICullingLayer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::ApplySettings");
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x3C37110", Offset = "0x3C37110", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv149 = v43.m_DisabledOverlays;\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreOverlaySettings(v43, v43.m_DisabledOverlays);\n\tv64 = v43.disabledUIElements == 0;\n\tif (v64) goto L_0090;\n\tv143 = 0xB2A7000 + 0xE0;\n\tv78 = System.Collections.Generic.List`1<UnityEngine.RectTransform>::GetEnumerator(v43.disabledUIElements);\n\tv114 = v78._list;\n\tgoto L_0058;\nL_0058:\n\tv175 = UnityEngine.Object::op_Inequality(v78.Current, 0);\n\tv178 = v175 == 0;\n\tif (v178) goto L_004A;\n\tv241 = v78.Current == 0;\n\tif (v241) goto L_008C;\n\tv176 = UnityEngine.Component::get_gameObject(v78.Current);\n\tUnityEngine.GameObject::SetActive(v176, 1);\n\tgoto L_004A;\nL_0069:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v114 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\n\tv132 = &v114 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.RectTransform>);\n\tv77 = 0;\n\tv151 = Il2CppMethodInfo;\nL_006A:\n\tv160 = v43.disabledUIElements;\n\tv157 = v43.disabledUIElements == 0;\n\tv149 = v151;\n\tif (v157) goto L_0090;\n\tSystem.Collections.Generic.List`1<UnityEngine.RectTransform>::Clear(v160);\n\tv240 = v160.Count < 1;\n\tif (v240) goto L_008B;\nL_008B:\n\treturn;\nL_008C:\n\tv293 = new System.NullReferenceException();\n\tgoto L_008F;\nL_008F:\n\t// 143 Interrupt\n\tv132 = &v114 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.RectTransform>);\n\tv77 = 0;\n\tv149 = 0;\nL_009F:\n\tv194 = v149 != 1;\n\tif (v194) goto L_00AE;\n\tv197 = 0x8BF5BC4(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = 0x8BF5BF4(v197, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v132);\n\tv205 = *([v197 @ X0_v11]) == 0;\n\tv77 = *([v197 @ X0_v11]);\n\tv151 = *([v143 @ X21_v1 (System.Int32)]);\n\tif (v205) goto L_006A;\n\tv203 = new System.OutOfMemoryException();\n\tv77 = *([v197 @ X0_v11]);\n\tv164 = v203;\nL_00AE:\n\tv210 = 0x3177294(&v77 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv218 = 0x8BF0368(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv225 = 0xA1B8(v218, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0026:\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreCameraSettings(v43, v43.m_Cameras);\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreCameraSettings(v43, v43.m_SceneCameras);\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreOverlaySettings(v43, v43.m_Overlays);\nL_0090:\n\tv164 = new System.NullReferenceException();\n\tgoto L_009F;\nL_004A:\n\tv184 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v114 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.RectTransform>));\n\tv196 = v184 == 0;\n\tif (v196) goto L_0069;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RestoreSettings()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::RestoreSettings");
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x3C3D7E4", Offset = "0x3C3D7E4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_timeScale();\n\tthis.m_PreviousTimeScale = v13;\n\tUnityEngine.Time::set_timeScale(0f);\n\treturn;\n")]
		private void StopTime()
		{
			float timeScale = Time.timeScale;
			m_PreviousTimeScale = timeScale;
			Time.timeScale = 0f;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x3C3ACDC", Offset = "0x3C3ACDC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Time::set_timeScale(this.m_PreviousTimeScale);\n\treturn;\n")]
		private void RestoreTime()
		{
			Time.timeScale = m_PreviousTimeScale;
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x3C3CEA8", Offset = "0x3C3CEA8", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\nL_004C:\n\tv86 = UnityEngine.Object::FindObjectsOfType();\n\tv98 = overlays == 0;\n\tif (v98) goto L_010E;\n\tv244 = v86.Length < 1;\n\tif (v244) goto L_0140;\n\tv157 = 0;\n\tgoto L_007D;\nL_006A:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Add(v67, v210);\nL_006B:\n\tv157 = v157 + 1;\n\tv292 = v157 >= v86.Length;\n\tif (v292) goto L_0140;\nL_007D:\n\tv209 = UnityEngine.Component::get_gameObject(v86[v157 @ X26_v5 (System.Int32)]);\n\tv412 = UnityEngine.GameObject::get_activeInHierarchy(v209);\n\tv415 = ~v412;\n\tif (v415) goto L_006B;\n\tv419 = UnityEngine.Behaviour::get_enabled(v86[v157 @ X26_v5 (System.Int32)]);\n\tv446 = ~v419;\n\tif (v446) goto L_006B;\n\tv461 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::GetEnumerator(overlays);\n\tv462 = v461._list;\n\tv134 = v461.Current;\n\tv120 = v461._list;\n\tv462 = 0;\n\tv126 = 0;\n\tv392 = v461.Current == 0;\n\tif (v392) goto L_00E7;\n\tgoto L_00B0;\nL_00B0:\n\tv474 = UnityEngine.Object::op_Equality(v134.m_Canvas, v86[v157 @ X26_v5 (System.Int32)]);\n\tv476 = v474 == 0;\n\tif (v476) goto L_009F;\n\tv126 = v134.m_Active | v126;\n\tgoto L_009F;\nL_00BB:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v120 @ stack_-80_v5 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\n\tv488 = v126 & 1;\n\tv489 = v488 == 0;\n\tv447 = ~v489;\n\tif (v447) goto L_006B;\n\tv210 = new AlmostEngine.Screenshot.ScreenshotOverlay();\n\tAlmostEngine.Screenshot.ScreenshotOverlay::.ctor(v210, v86[v157 @ X26_v5 (System.Int32)]);\n\tgoto L_006A;\nL_00E7:\n\tv487 = new System.NullReferenceException();\n\tgoto L_0141;\nL_010E:\n\tv255 = v86.Length < 1;\n\tif (v255) goto L_0140;\n\tv228 = 0;\n\tgoto L_0124;\nL_0113:\n\tv228 = v228 + 1;\n\tv293 = v228 >= v86.Length;\n\tif (v293) goto L_0140;\nL_0124:\n\tv212 = UnityEngine.Component::get_gameObject(v86[v228 @ X22_v6 (System.Int32)]);\n\tv414 = UnityEngine.GameObject::get_activeInHierarchy(v212);\n\tv416 = ~v414;\n\tif (v416) goto L_0113;\n\tv207 = UnityEngine.Behaviour::get_enabled(v86[v228 @ X22_v6 (System.Int32)]);\n\tv214 = v207 == 0;\n\tif (v214) goto L_0113;\n\tthrow System.NullReferenceException;\nL_0140:\n\treturn v67;\nL_0141:\n\t// 321 Interrupt\n\treturn returnVal2;\nL_0041:\n\tv67 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v67);\n\tgoto L_004C;\nL_009F:\n\tv480 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v120 @ stack_-80_v5 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\n\tv482 = v480 == 0;\n\tif (v482) goto L_00BB;\n\tv497 = 0x31772D4(&v462 @ stack_-98_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv499 = 0x8BF0368(v487, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v499, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe List<ScreenshotOverlay> FindAllOtherCanvas(List<ScreenshotOverlay> overlays)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::FindAllOtherCanvas");
			return default;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x3C3D220", Offset = "0x3C3D220", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::GetEnumerator(overlays);\n\tv81 = v60._list;\n\tv108 = v60.Current == 0;\n\tif (v108) goto L_0037;\n\tAlmostEngine.Screenshot.ScreenshotOverlay::Disable(v60.Current);\n\tgoto L_0037;\nL_0042:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\nL_004A:\n\treturn;\nL_0020:\n\tv46 = overlays == 0;\n\tif (v46) goto L_004A;\nL_0037:\n\tv110 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\n\tv89 = v110 == 0;\n\tif (v89) goto L_0042;\n")]
		private unsafe void DisableCanvas(List<ScreenshotOverlay> overlays)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::DisableCanvas");
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x3C3D34C", Offset = "0x3C3D34C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv66 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::GetEnumerator(overlays);\n\tv116 = v66._list;\n\tv106 = v66.Current;\n\tv164 = v66.Current == 0;\n\tif (v164) goto L_003E;\n\tv147 = v106.m_Active != 1;\n\tif (v147) goto L_003E;\n\tgoto L_005B;\nL_005B:\n\tv161 = UnityEngine.Object::op_Inequality(v106.m_Canvas, 0);\n\tv165 = v161 == 0;\n\tif (v165) goto L_003E;\n\tAlmostEngine.Screenshot.ScreenshotOverlay::ApplySettings(v66.Current);\n\tgoto L_003E;\nL_0064:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v116 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\nL_006E:\n\treturn;\nL_0025:\n\tv50 = overlays == 0;\n\tif (v50) goto L_006E;\nL_003E:\n\tv160 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v116 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\n\tv125 = v160 == 0;\n\tif (v125) goto L_0064;\n")]
		private unsafe void ApplyOverlaySettings(List<ScreenshotOverlay> overlays)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::ApplyOverlaySettings");
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x3C3D65C", Offset = "0x3C3D65C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv66 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::GetEnumerator(overlays);\n\tv116 = v66._list;\n\tv106 = v66.Current;\n\tv164 = v66.Current == 0;\n\tif (v164) goto L_003E;\n\tv147 = v106.m_Active != 1;\n\tif (v147) goto L_003E;\n\tgoto L_005B;\nL_005B:\n\tv161 = UnityEngine.Object::op_Inequality(v106.m_Canvas, 0);\n\tv165 = v161 == 0;\n\tif (v165) goto L_003E;\n\tAlmostEngine.Screenshot.ScreenshotOverlay::RestoreSettings(v66.Current);\n\tgoto L_003E;\nL_0064:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v116 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\nL_006E:\n\treturn;\nL_0025:\n\tv50 = overlays == 0;\n\tif (v50) goto L_006E;\nL_003E:\n\tv160 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v116 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>));\n\tv125 = v160 == 0;\n\tif (v125) goto L_0064;\n")]
		public unsafe void RestoreOverlaySettings(List<ScreenshotOverlay> overlays)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::RestoreOverlaySettings");
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x3C3C8EC", Offset = "0x3C3C8EC", Length = "0x2FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\nL_004C:\n\tv86 = UnityEngine.Object::FindObjectsOfType();\n\tv97 = cameras == 0;\n\tif (v97) goto L_00FD;\n\tv212 = v86.Length < 1;\n\tif (v212) goto L_010D;\n\tv144 = 0;\n\tgoto L_007E;\nL_006A:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::Add(v67, v188);\nL_006B:\n\tv144 = v144 + 1;\n\tv286 = v144 >= v86.Length;\n\tif (v286) goto L_010D;\nL_007E:\n\tv356 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::GetEnumerator(cameras);\n\tv124 = v356.Current;\n\tv114 = v356._list;\n\tv118 = 0;\n\tv250 = v356.Current == 0;\n\tif (v250) goto L_00D7;\n\tgoto L_00A0;\nL_00A0:\n\tv412 = UnityEngine.Object::op_Equality(v124.m_Camera, v86[v144 @ X25_v6 (System.Int32)]);\n\tv414 = v412 == 0;\n\tif (v414) goto L_008F;\n\tv118 = v124.m_Active | v118;\n\tgoto L_008F;\nL_00AB:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v114 @ stack_-80_v6 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv428 = v118 & 1;\n\tv429 = v428 == 0;\n\tv430 = ~v429;\n\tif (v430) goto L_006B;\n\tv188 = new AlmostEngine.Screenshot.ScreenshotCamera();\n\tAlmostEngine.Screenshot.ScreenshotCamera::.ctor(v188, v86[v144 @ X25_v6 (System.Int32)]);\n\tgoto L_006A;\nL_00D7:\n\tv247 = new System.NullReferenceException();\n\tv135 = 0;\n\tgoto L_010F;\nL_00FD:\n\tv148 = v86.Length >= 1;\n\tif (v148) goto L_010E;\nL_010D:\n\treturn v67;\nL_010E:\n\tv247 = new System.NullReferenceException();\nL_010F:\n\t// 271 Interrupt\n\treturn returnVal2;\nL_0041:\n\tv67 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v67);\n\tgoto L_004C;\nL_008F:\n\tv418 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v114 @ stack_-80_v6 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv420 = v418 == 0;\n\tif (v420) goto L_00AB;\n\tv329 = 0x3176E88(&v135 @ stack_-98 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv398 = 0x8BF0368(v247, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v398, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe List<ScreenshotCamera> FindAllOtherCameras(List<ScreenshotCamera> cameras)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::FindAllOtherCameras");
			return default;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x3C3CBE8", Offset = "0x3C3CBE8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::GetEnumerator(cameras);\n\tv81 = v60._list;\n\tv108 = v60.Current == 0;\n\tif (v108) goto L_0037;\n\tAlmostEngine.Screenshot.ScreenshotCamera::Disable(v60.Current);\n\tgoto L_0037;\nL_0042:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\nL_004A:\n\treturn;\nL_0020:\n\tv46 = cameras == 0;\n\tif (v46) goto L_004A;\nL_0037:\n\tv110 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv89 = v110 == 0;\n\tif (v89) goto L_0042;\n")]
		private unsafe void DisableCameras(List<ScreenshotCamera> cameras)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::DisableCameras");
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x3C3D4D4", Offset = "0x3C3D4D4", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv66 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::GetEnumerator(cameras);\n\tv116 = v66._list;\n\tv106 = v66.Current;\n\tv164 = v66.Current == 0;\n\tif (v164) goto L_003E;\n\tv147 = v106.m_Active != 1;\n\tif (v147) goto L_003E;\n\tgoto L_005B;\nL_005B:\n\tv161 = UnityEngine.Object::op_Equality(v106.m_Camera, 0);\n\tv182 = v161 == 0;\n\tv165 = ~v182;\n\tif (v165) goto L_003E;\n\tAlmostEngine.Screenshot.ScreenshotCamera::RestoreSettings(v66.Current);\n\tgoto L_003E;\nL_0065:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v116 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\nL_006F:\n\treturn;\nL_0025:\n\tv50 = cameras == 0;\n\tif (v50) goto L_006F;\nL_003E:\n\tv160 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v116 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv125 = v160 == 0;\n\tif (v125) goto L_0065;\n")]
		public unsafe void RestoreCameraSettings(List<ScreenshotCamera> cameras)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::RestoreCameraSettings");
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x3C3CD14", Offset = "0x3C3CD14", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv67 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::GetEnumerator(cameras);\n\tv117 = v67._list;\n\tv107 = v67.Current;\n\tv174 = v67.Current == 0;\n\tif (v174) goto L_003F;\n\tv148 = v107.m_Active != 1;\n\tif (v148) goto L_003F;\n\tgoto L_005C;\nL_005C:\n\tv171 = UnityEngine.Object::op_Equality(v107.m_Camera, 0);\n\tv192 = v171 == 0;\n\tv175 = ~v192;\n\tif (v175) goto L_003F;\n\tv162 = captureMode - 1;\n\tv158 = v162 == 0;\n\tAlmostEngine.Screenshot.ScreenshotCamera::ApplySettings(v67.Current, v158);\n\tgoto L_003F;\nL_0070:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v117 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\nL_007A:\n\treturn;\nL_0026:\n\tv51 = cameras == 0;\n\tif (v51) goto L_007A;\nL_003F:\n\tv170 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v117 @ stack_-58_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv126 = v170 == 0;\n\tif (v126) goto L_0070;\n")]
		private unsafe void ApplyCameraSettings(List<ScreenshotCamera> cameras, CaptureMode captureMode)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotTaker::ApplyCameraSettings");
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x3C3D814", Offset = "0x3C3D814", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv83 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v83);\n\tthis.m_SceneCameras = v83;\n\tv96 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v96);\n\tthis.m_Overlays = v96;\n\tv104 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v104);\n\tthis.m_DisabledOverlays = v104;\n\tv112 = new System.Collections.Generic.List`1<UnityEngine.RectTransform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.RectTransform>::.ctor(v112);\n\tthis.disabledUIElements = v112;\n\tthis.m_PreviousTimeScale = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0035:\n\tthis.m_GameViewResizingWaitingTime = 1f;\n\tv66 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v66);\n\tthis.m_Cameras = v66;\n")]
		public ScreenshotTaker()
		{
			m_GameViewResizingWaitingTime = 1f;
			List<ScreenshotCamera> cameras = new List<ScreenshotCamera>();
			m_Cameras = cameras;
			List<ScreenshotCamera> sceneCameras = new List<ScreenshotCamera>();
			m_SceneCameras = sceneCameras;
			List<ScreenshotOverlay> overlays = new List<ScreenshotOverlay>();
			m_Overlays = overlays;
			List<ScreenshotOverlay> disabledOverlays = new List<ScreenshotOverlay>();
			m_DisabledOverlays = disabledOverlays;
			List<RectTransform> list = new List<RectTransform>();
			disabledUIElements = list;
			m_PreviousTimeScale = 1f;
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x3C3D9A4", Offset = "0x3C3D9A4", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv108 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v108, v105.<>9, Il2CppMethodInfo);\n\tv120.onResolutionUpdateEndDelegate = v108;\n\tv130 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v130, v127.<>9, Il2CppMethodInfo);\n\tv136.onResolutionScreenResizedDelegate = v130;\n\tv141 = new System.Collections.Generic.List`1<UnityEngine.RenderTexture>();\n\tSystem.Collections.Generic.List`1<UnityEngine.RenderTexture>::.ctor(v141);\n\tv145.m_RenderTextureCache = v141;\n\tv150.m_MaxRenderTextureCache = 2;\n\treturn;\nL_0040:\n\tv71.m_IsRunning = 0;\n\tgoto L_004B;\nL_004B:\n\tv85 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v85, v82.<>9, Il2CppMethodInfo);\n\tv97.onResolutionUpdateStartDelegate = v85;\n")]
		static ScreenshotTaker()
		{
			UnityAction<ScreenshotResolution> unityAction = delegate
			{
			};
			onResolutionUpdateStartDelegate = unityAction;
			UnityAction<ScreenshotResolution> unityAction2 = delegate
			{
			};
			onResolutionUpdateEndDelegate = unityAction2;
			UnityAction<ScreenshotResolution> unityAction3 = delegate
			{
			};
			onResolutionScreenResizedDelegate = unityAction3;
			List<RenderTexture> renderTextureCache = new List<RenderTexture>();
			m_RenderTextureCache = renderTextureCache;
			m_MaxRenderTextureCache = 2;
		}
	}
}
