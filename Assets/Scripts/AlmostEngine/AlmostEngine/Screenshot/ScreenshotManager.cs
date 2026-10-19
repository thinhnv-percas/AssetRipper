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
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(AudioSource))]
	[Token(Token = "0x2000020")]
	public class ScreenshotManager : MonoBehaviour
	{
		[Token(Token = "0x2000021")]
		public delegate void ExportDelegate(ScreenshotResolution res);

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000022")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000E0")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000E1")]
			public static Func<ScreenshotBatch.ActiveItem, bool> _003C_003E9__37_0;

			[Token(Token = "0x40000E2")]
			public static Func<ScreenshotBatch.ActiveItem, bool> _003C_003E9__37_2;

			[Token(Token = "0x600008B")]
			[Address(RVA = "0x3C365B0", Offset = "0x3C365B0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new AlmostEngine.Screenshot.ScreenshotManager+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600008C")]
			[Address(RVA = "0x3C36614", Offset = "0x3C36614", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CUpdateCoroutine_003Eb__37_0(ScreenshotBatch.ActiveItem x)
			{
				return x.m_Active;
			}

			internal bool _003CUpdateCoroutine_003Eb__37_2(ScreenshotBatch.ActiveItem x)
			{
				return x.m_Active;
			}

			internal void _003C_002Ecctor_003Eb__56_0()
			{
			}

			internal void _003C_002Ecctor_003Eb__56_1()
			{
			}

			internal void _003C_002Ecctor_003Eb__56_2(ScreenshotResolution res)
			{
			}

			internal void _003C_002Ecctor_003Eb__56_3(ScreenshotResolution res)
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000023")]
		private sealed class _003C_003Ec__DisplayClass37_0
		{
			[Token(Token = "0x40000E3")]
			[FieldOffset(Offset = "0x10")]
			public ScreenshotResolution resolution;

			[Token(Token = "0x6000093")]
			[Address(RVA = "0x3C3665C", Offset = "0x3C3665C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass37_0()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000024")]
		private sealed class _003C_003Ec__DisplayClass37_1
		{
			[Token(Token = "0x40000E4")]
			[FieldOffset(Offset = "0x10")]
			public string filename;

			[Token(Token = "0x40000E5")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass37_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x6000094")]
			[Address(RVA = "0x3C36664", Offset = "0x3C36664", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass37_1()
			{
			}

			internal void _003CUpdateCoroutine_003Eb__4()
			{
				string message = "Screenshot created : " + filename;
				Debug.Log(message);
				_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_2 = CS_0024_003C_003E8__locals1;
				ScreenshotResolution screenshotResolution = _003C_003Ec__DisplayClass37_2.resolution;
				screenshotResolution.m_FileName = filename;
				_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_3 = CS_0024_003C_003E8__locals1;
				onResolutionExportSuccessDelegate(_003C_003Ec__DisplayClass37_3.resolution);
			}

			internal void _003CUpdateCoroutine_003Eb__5()
			{
				string message = "Failed to create : " + filename;
				Debug.LogError(message);
				_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_2 = CS_0024_003C_003E8__locals1;
				ScreenshotResolution screenshotResolution = _003C_003Ec__DisplayClass37_2.resolution;
				screenshotResolution.m_FileName = filename;
				_003C_003Ec__DisplayClass37_0 _003C_003Ec__DisplayClass37_3 = CS_0024_003C_003E8__locals1;
				onResolutionExportFailureDelegate(_003C_003Ec__DisplayClass37_3.resolution);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000025")]
		private sealed class _003CCaptureAllCoroutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000E6")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000E7")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000E8")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotManager _003C_003E4__this;

			[Token(Token = "0x17000009")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600009A")]
				[Address(RVA = "0x3C3697C", Offset = "0x3C3697C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600009C")]
				[Address(RVA = "0x3C369C4", Offset = "0x3C369C4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000097")]
			[Address(RVA = "0x3C34DA8", Offset = "0x3C34DA8", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureAllCoroutine_003Ed__22(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000098")]
			[Address(RVA = "0x3C3686C", Offset = "0x3C3686C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000099")]
			[Address(RVA = "0x3C36870", Offset = "0x3C36870", Length = "0x10C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.<>1__state == 0;\n\tif (v21) goto L_001B;\n\tv31 = this.<>1__state != 1;\n\tif (v31) goto L_0057;\n\tv53 = -1;\n\tgoto L_0052;\nL_001B:\n\tv32 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv153 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(*([v32 @ X20_v4 (UnityEngine.MonoBehaviour)+20]));\n\tAlmostEngine.Screenshot.ScreenshotConfig::UpdateGameviewResolution(*([v32 @ X20_v4 (UnityEngine.MonoBehaviour)+20]));\n\tgoto L_0037;\n\tv166.resolutions = v153;\n\tv166.export = 0x101;\n\tv179 = UnityEngine.MonoBehaviour::StartCoroutine(v32, v166);\n\tthis.<>2__current = v179;\n\tv53 = 1;\nL_0057:\n\tv79 = this.<>1__state == 0;\n\treturn v79;\nL_0052:\n\tthis.<>1__state = v53;\nL_0037:\n\tv166 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureCoroutine>d__31();\n\tSystem.Object::.ctor(v166);\n\tv166.<>1__state = 0;\n\tv166.<>4__this = v32;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CCaptureAllCoroutine_003Ed__22::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x3C36984", Offset = "0x3C36984", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000026")]
		private sealed class _003CCaptureCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000E9")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000EA")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000EB")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotManager _003C_003E4__this;

			[Token(Token = "0x40000EC")]
			[FieldOffset(Offset = "0x28")]
			public List<ScreenshotResolution> resolutions;

			[Token(Token = "0x40000ED")]
			[FieldOffset(Offset = "0x30")]
			public bool export;

			[Token(Token = "0x40000EE")]
			[FieldOffset(Offset = "0x31")]
			public bool playSoundMask;

			[Token(Token = "0x40000EF")]
			[FieldOffset(Offset = "0x38")]
			private Stopwatch _003CwatchTotal_003E5__2;

			[Token(Token = "0x40000F0")]
			[FieldOffset(Offset = "0x40")]
			private int _003Ci_003E5__3;

			[Token(Token = "0x1700000B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000A0")]
				[Address(RVA = "0x3C37310", Offset = "0x3C37310", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000A2")]
				[Address(RVA = "0x3C37358", Offset = "0x3C37358", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x3C35000", Offset = "0x3C35000", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureCoroutine_003Ed__31(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x3C369CC", Offset = "0x3C369CC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600009F")]
			[Address(RVA = "0x3C369D0", Offset = "0x3C369D0", Length = "0x740")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv66 = this.<>1__state == 2;\n\tif (v66) goto L_011F;\n\tv79 = this.<>1__state == 3;\n\tif (v79) goto L_013E;\n\tv114 = this.<>1__state != 4;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v114) goto L_022A;\n\tthis.<>1__state = -1;\n\tv632 = this.<i>5__3 + 1;\n\tthis.<i>5__3 = v632;\n\tv681 = v46.m_Config;\nL_0073:\n\tv290 = v632 >= v681.m_MaxBurstShotsNumber;\n\tif (v290) goto L_0199;\n\tv661 = v46.m_IsBurstActive == 0;\n\tif (v661) goto L_0199;\n\tv611 = System.Int32::ToString(&this.<i>5__3 (System.Int32));\n\tv863 = UnityEngine.Time::get_frameCount();\n\tv202 = v863;\n\tv613 = System.Int32::ToString(&v202 @ stack_-34_v7 (System.Int32));\n\tv246 = UnityEngine.Time::get_time();\n\tv198 = v246;\n\tv615 = System.Single::ToString(&v198 @ stack_-38_v8 (System.Single));\n\t// 125 NewArr v379 @ X0_v107 (System.String[]), typeof(System.String[]), 6\n\tv379[0] = \"Capture BURST i \";\n\tv379[1] = v611;\n\tv379[2] = \" Frame \";\n\tv379[3] = v613;\n\tv379[4] = \" time \";\n\tv379[5] = v615;\n\tv924 = System.String::Concat(v379);\n\tgoto L_0100;\n\tv927 = v648.m_FixedFrameRate == 0;\n\tv234 = ~v927;\nL_FFFFFFFF:\n\t;\n\tif (v234) goto L_020B;\n\tv199 = UnityEngine.Time::get_time();\nL_FFFFFFFF:\n\t;\n\tgoto L_0124;\nL_010E:\n\tv71 = this.<>1__state == 0;\n\tif (v71) goto L_0148;\n\tv96 = this.<>1__state != 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v96) goto L_022A;\n\tthis.<>1__state = -1;\n\tgoto L_01BC;\nL_011F:\n\tthis.<>1__state = -1;\n\tv199 = UnityEngine.Time::get_time();\nL_0124:\n\tv648 = v46.m_Config;\n\tv552 = v199 - v46.m_LastShotTime;\n\tv551 = 1f / v648.m_MaxShotPerSeconds;\n\tv559 = v552 < v551;\n\tv555 = ~v559;\n\tif (v555) goto L_020B;\n\tv180 = this + 0x18;\n\tthis.<>2__current = 0;\nL_FFFFFFFF:\n\tv178 = 2;\n\tgoto L_0221;\nL_013E:\n\tv180 = this + 0x18;\n\tthis.<>2__current = 0;\n\tthis.<>1__state = -1;\nL_FFFFFFFF:\n\tv178 = 4;\n\tgoto L_0221;\nL_0148:\n\tthis.<>1__state = -1;\n\tv101 = new System.Diagnostics.Stopwatch();\n\tSystem.Diagnostics.Stopwatch::.ctor(v101);\n\tthis.<watchTotal>5__2 = v101;\n\tSystem.Diagnostics.Stopwatch::Start(this.<watchTotal>5__2);\n\tv46.m_CurrentBurstFrame = 0;\n\tv420 = v46.m_Config;\n\tv714 = v420.m_ShotMode != 1;\n\tif (v714) goto L_0182;\n\tgoto L_0174;\nL_0174:\n\tv756 = UnityEngine.Application::get_isPlaying();\n\tv759 = v756 == 0;\n\tif (v759) goto L_02A5;\nL_0182:\n\tv295 = v46.m_IsCapturing != 1;\n\tif (v295) goto L_022C;\n\tgoto L_018D;\nL_018D:\n\tv525 = 0xB2EB000 + 0x788;\n\tgoto L_02AB;\nL_0199:\n\tv291 = v681.m_FixedFrameRate != 1;\n\tif (v291) goto L_01AE;\n\tgoto L_01A6;\nL_01A6:\n\tUnityEngine.Application::set_targetFrameRate(v46.m_PreviousFrameRate);\n\tUnityEngine.QualitySettings::set_vSyncCount(v46.m_PreviousVSync);\n\tv681 = v46.m_Config;\nL_FFFFFFFF:\n\t;\nL_01AE:\n\tv682 = v681.m_CaptureMode == 0;\n\tv683 = ~v682;\n\tif (v683) goto L_01B5;\n\tAlmostEngine.Screenshot.ScreenshotTaker::RestoreSettings(v46.m_ScreenshotTaker);\nL_01B5:\n\tv46.m_IsBurstActive = 0;\n\tUnityEngine.Events.UnityAction::Invoke(v627.onCaptureEndDelegate);\n\tgoto L_01CE;\nL_01CE:\n\tv666 = UnityEngine.Application::get_isPlaying();\n\tv688 = ~v666;\n\tif (v688) goto L_01FA;\n\tv425 = v46.m_Config;\n\tv719 = v425.m_PreviewInGameViewWhilePlaying != 1;\n\tif (v719) goto L_01FA;\n\tv720 = v425.m_ShowGuidesInPreview != 1;\n\tif (v720) goto L_01FA;\n\tAlmostEngine.Screenshot.ScreenshotManager::ShowGuides(v46);\n\tgoto L_01FB;\nL_01FA:\n\tAlmostEngine.Screenshot.ScreenshotManager::HideGuides(v46);\nL_01FB:\n\tv46.m_IsCapturing = 0;\n\tSystem.Diagnostics.Stopwatch::Stop(this.<watchTotal>5__2);\n\treturn 0;\nL_020B:\n\tv388 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveCameras(v648);\n\tv427 = v46.m_Config;\n\tv687 = AlmostEngine.Screenshot.ScreenshotManager::UpdateCoroutine(v46, this.resolutions, v388, v427.m_Overlays, this.export, this.playSoundMask, 0);\n\tv699 = UnityEngine.MonoBehaviour::StartCoroutine(v46, v687);\n\tv180 = this + 0x18;\n\tthis.<>2__current = v699;\nL_FFFFFFFF:\n\tv178 = 3;\nL_022C:\n\tv46.m_IsCapturing = 1;\n\tgoto L_0236;\nL_0236:\n\tv389 = UnityEngine.Application::get_isPlaying();\n\tv813 = ~v389;\n\tif (v813) goto L_025C;\n\tv428 = v46.m_Config;\n\tv820 = v428.m_PreviewInGameViewWhilePlaying != 1;\n\tif (v820) goto L_025C;\n\tv819 = v428.m_ShowGuidesInPreview != 1;\n\tif (v819) goto L_025C;\n\tAlmostEngine.Screenshot.ScreenshotManager::HideGuides(v46);\nL_025C:\n\tgoto L_0260;\n\tUnityEngine.Events.UnityAction::Invoke(v429);\n\tv390 = v46.m_Config;\n\tv346 = v390.m_ShotMode == 1;\n\tif (v346) goto L_02B5;\n\tv866 = v390.m_ShotMode == 0;\n\tv438 = ~v866;\n\tif (v438) goto L_01BC;\n\tv391 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveCameras(v390);\n\tv430 = v46.m_Config;\n\tv889 = AlmostEngine.Screenshot.ScreenshotManager::UpdateCoroutine(v46, this.resolutions, v391, v430.m_Overlays, this.export, this.playSoundMask, 0);\n\tv899 = UnityEngine.MonoBehaviour::StartCoroutine(v46, v889);\n\tthis.<>2__current = v899;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_02A5:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv525 = \"In burst mode the application needs to be playing.\";\nL_02B5:\n\tv46.m_IsBurstActive = v390.m_ShotMode;\n\tv289 = v390.m_FixedFrameRate != 1;\n\tif (v289) goto L_02D8;\n\tgoto L_02C9;\nL_02C9:\n\tv883 = UnityEngine.Application::get_targetFrameRate();\n\tv46.m_PreviousFrameRate = v883;\n\tv392 = UnityEngine.QualitySettings::get_vSyncCount();\n\tv46.m_PreviousVSync = v392;\n\tv431 = v46.m_Config;\n\tUnityEngine.Application::set_targetFrameRate(v431.m_MaxShotPerSeconds);\n\tUnityEngine.QualitySettings::set_vSyncCount(0);\nL_FFFFFFFF:\n\t;\nL_02D8:\n\tthis.<i>5__3 = 0;\n\tv681 = v46.m_Config;\n\tv877 = v46.m_Config == 0;\n\tv395 = ~v877;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv632 = 0;\n\tif (v395) goto L_0073;\n\tv432 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\nL_0032:\n\tv46 = this.<>4__this;\n\tv58 = this.<>1__state <= 1;\n\tif (v58) goto L_010E;\nL_022A:\n\treturn returnVal1;\nL_0100:\n\tUnityEngine.Debug::Log(v924);\n\tv46.m_CurrentBurstFrame = this.<i>5__3;\n\tv648 = v46.m_Config;\nL_01BC:\n\tgoto L_01C0;\nL_0221:\n\t*([v180 @ X19_v2-8]) = v178;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_02AB:\n\tUnityEngine.Debug::LogError(*([v525 @ X8_v29 (System.Int32)]));\n\treturn 0;\nL_0260:\n\tv429 = v852.onCaptureBeginDelegate;\nL_01C0:\n\t;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CCaptureCoroutine_003Ed__31::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x3C37318", Offset = "0x3C37318", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000027")]
		private sealed class _003CUpdateAllCoroutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000F1")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000F2")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000F3")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotManager _003C_003E4__this;

			[Token(Token = "0x1700000D")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000A6")]
				[Address(RVA = "0x3C3746C", Offset = "0x3C3746C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700000E")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000A8")]
				[Address(RVA = "0x3C374B4", Offset = "0x3C374B4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x3C34D7C", Offset = "0x3C34D7C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CUpdateAllCoroutine_003Ed__21(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x3C37360", Offset = "0x3C37360", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000A5")]
			[Address(RVA = "0x3C37364", Offset = "0x3C37364", Length = "0x108")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = this.<>1__state == 0;\n\tif (v21) goto L_001B;\n\tv31 = this.<>1__state != 1;\n\tif (v31) goto L_0056;\n\tv53 = -1;\n\tgoto L_0051;\nL_001B:\n\tv32 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv153 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(*([v32 @ X20_v4 (UnityEngine.MonoBehaviour)+20]));\n\tAlmostEngine.Screenshot.ScreenshotConfig::UpdateGameviewResolution(*([v32 @ X20_v4 (UnityEngine.MonoBehaviour)+20]));\n\tgoto L_0037;\n\tv166.resolutions = v153;\n\tv166.export = 0;\n\tv178 = UnityEngine.MonoBehaviour::StartCoroutine(v32, v166);\n\tthis.<>2__current = v178;\n\tv53 = 1;\nL_0056:\n\tv79 = this.<>1__state == 0;\n\treturn v79;\nL_0051:\n\tthis.<>1__state = v53;\nL_0037:\n\tv166 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureCoroutine>d__31();\n\tSystem.Object::.ctor(v166);\n\tv166.<>1__state = 0;\n\tv166.<>4__this = v32;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdateAllCoroutine_003Ed__21::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0x3C37474", Offset = "0x3C37474", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000028")]
		private sealed class _003CUpdateCoroutine_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40000F4")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40000F5")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40000F6")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotManager _003C_003E4__this;

			[Token(Token = "0x40000F7")]
			[FieldOffset(Offset = "0x28")]
			public bool isPreview;

			[Token(Token = "0x40000F8")]
			[FieldOffset(Offset = "0x30")]
			public List<ScreenshotResolution> resolutions;

			[Token(Token = "0x40000F9")]
			[FieldOffset(Offset = "0x38")]
			public List<ScreenshotCamera> cameras;

			[Token(Token = "0x40000FA")]
			[FieldOffset(Offset = "0x40")]
			private _003C_003Ec__DisplayClass37_0 _003C_003E8__1;

			[Token(Token = "0x40000FB")]
			[FieldOffset(Offset = "0x48")]
			public bool playSoundMask;

			[Token(Token = "0x40000FC")]
			[FieldOffset(Offset = "0x50")]
			public List<ScreenshotOverlay> overlays;

			[Token(Token = "0x40000FD")]
			[FieldOffset(Offset = "0x58")]
			public bool export;

			[Token(Token = "0x40000FE")]
			[FieldOffset(Offset = "0x60")]
			private DateTime _003CstartTime_003E5__2;

			[Token(Token = "0x40000FF")]
			[FieldOffset(Offset = "0x68")]
			private List<ScreenshotBatch> _003Cbatches_003E5__3;

			[Token(Token = "0x4000100")]
			[FieldOffset(Offset = "0x70")]
			private int _003Cb_003E5__4;

			[Token(Token = "0x4000101")]
			[FieldOffset(Offset = "0x78")]
			private List<ScreenshotResolution> _003CresToCapture_003E5__5;

			[Token(Token = "0x4000102")]
			[FieldOffset(Offset = "0x80")]
			private List<ScreenshotComposition> _003CcompositionsToCapture_003E5__6;

			[Token(Token = "0x4000103")]
			[FieldOffset(Offset = "0x88")]
			private int _003Cc_003E5__7;

			[Token(Token = "0x4000104")]
			[FieldOffset(Offset = "0x90")]
			private ScreenshotComposition _003CcurrentComposition_003E5__8;

			[Token(Token = "0x4000105")]
			[FieldOffset(Offset = "0x98")]
			private List<ScreenshotResolution>.Enumerator _003C_003E7__wrap8;

			[Token(Token = "0x4000106")]
			[FieldOffset(Offset = "0xB0")]
			private int _003Cl_003E5__10;

			[Token(Token = "0x4000107")]
			[FieldOffset(Offset = "0xB8")]
			private ScreenshotCamera _003CseparatedLayerCamera_003E5__11;

			[Token(Token = "0x4000108")]
			[FieldOffset(Offset = "0xC0")]
			private List<ScreenshotCamera> _003CcurrentCameras_003E5__12;

			[Token(Token = "0x4000109")]
			[FieldOffset(Offset = "0xC8")]
			private List<ScreenshotProcess>.Enumerator _003C_003E7__wrap12;

			[Token(Token = "0x1700000F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000AF")]
				[Address(RVA = "0x3C39098", Offset = "0x3C39098", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000010")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000B1")]
				[Address(RVA = "0x3C390E0", Offset = "0x3C390E0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A9")]
			[Address(RVA = "0x3C35110", Offset = "0x3C35110", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CUpdateCoroutine_003Ed__37(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0x3C374BC", Offset = "0x3C374BC", Length = "0x1AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this;\n\tv17 = this.<>1__state + 5;\n\tv18 = v17 < 0xA;\n\tv19 = ~v18;\n\tv20 = v17 - 0xA;\n\tv22 = v20 == 0;\n\tv28 = 1 << v17;\n\tv30 = v28 & 0x787;\n\tv31 = ~v19;\n\tv32 = v31 | v22;\n\tv33 = ~v32;\n\tif (v33) goto L_FFFFFFFF;\n\tv51 = v30 == 0;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv51 = 1;\n\tv71 = this.<>1__state <= -4;\n\tif (v71) goto L_005D;\n\tv125 = this.<>1__state == 5;\n\tif (v125) goto L_0064;\n\tv178 = this.<>1__state == 2;\n\tif (v178) goto L_0077;\n\tgoto L_0085;\nL_005D:\n\tv140 = this.<>1__state != -5;\n\tif (v140) goto L_0077;\nL_0064:\n\tgoto L_006B;\nL_0077:\n\tgoto L_0080;\nL_0085:\n\tv264 = &v14 @ stack_-38_v1 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37);\n\tv82 = *([v264 @ X8_v4]);\n\tv76 = 0xB2A7000 + 0x2A8;\nL_FFFFFFFF:\n\tv89 = 0;\nL_FFFFFFFF:\n\tv92 = 0;\n\tgoto L_0095;\nL_00A3:\n\treturn;\nL_00A5:\n\tv309 = new System.OutOfMemoryException();\n\tgoto L_00B1;\nL_00B1:\n\tv154 = *([v76 @ X21_v5 (System.Int32)]) != 1;\n\tif (v154) goto L_00C4;\n\tv312 = 0x8BF5BC4(v309, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv92 = *([v312 @ X0_v13]);\n\tv279 = 0x8BF5BF4(v312, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv317 = &v14 @ stack_-38_v1 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37);\n\tv82 = *([v317 @ X8_v8]);\n\tv76 = 0xB2A7000 + 0x2A8;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv89 = *([v312 @ X0_v13]);\n\tgoto L_0095;\n\treturn;\nL_002B:\n\tif (v51) goto L_00A3;\nL_006B:\n\tthis.<>1__state = -3;\n\tv237 = this + 0xC8;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v237);\n\tgoto L_0085;\nL_0080:\n\tthis.<>1__state = -3;\n\tv248 = this + 0xC8;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v248);\nL_0095:\n\t*([v82 @ X20_v5+10]) = -1;\n\tv80 = v82 + 0x98;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v80);\n\tv307 = v92 == 0;\n\tv84 = ~v307;\n\tif (v84) goto L_00A5;\nL_00C4:\n\tv314 = 0x3177168(&v89 @ stack_-48_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv316 = 0x8BF0368(v309, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv146 = 0xA1B8(v316, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdateCoroutine_003Ed__37::Dispose");
			}

			[Token(Token = "0x60000AB")]
			[Address(RVA = "0x3C37668", Offset = "0x3C37668", Length = "0x191C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00A6;\n\tv94 = this.<>1__state - 3;\n\tv95 = v94 < 2;\n\tv96 = ~v95;\n\tv104 = ~v96;\n\tif (v104) goto L_0118;\n\tv113 = this.<>1__state == 5;\n\tif (v113) goto L_0167;\n\tv148 = this.<>1__state != 6;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v148) goto L_FFFFFFFF;\n\tthis.<>1__state = -1;\n\tv172 = this.<>4__this == 0;\n\tif (v172) goto L_02B0;\n\tv417 = v78.m_TimeStopped != 1;\nL_FFFFFFFF:\n\tv542 = 0;\n\tif (v417) goto L_087C;\n\tUnityEngine.Time::set_timeScale(v78.m_PreviousTimeScale);\n\tv78.m_TimeStopped = 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0823;\nL_FFFFFFFF:\n\tv542 = 0;\n\tgoto L_087E;\nL_00FD:\n\tv105 = this.<>1__state == 0;\n\tif (v105) goto L_013B;\n\tv124 = this.<>1__state == 1;\n\tif (v124) goto L_0273;\n\tv162 = this.<>1__state != 2;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v162) goto L_FFFFFFFF;\n\tthis.<>1__state = -4;\nL_FFFFFFFF:\n\tv693 = v47;\nL_FFFFFFFF:\n\tv820 = v45;\nL_FFFFFFFF:\n\tv831 = v44;\nL_FFFFFFFF:\n\tv2470 = v43;\nL_FFFFFFFF:\n\tv1079 = v48;\n\tgoto L_02F6;\nL_0118:\n\tthis.<>1__state = -3;\n\tv119 = this.<>4__this == 0;\n\tif (v119) goto L_02A0;\n\tv150 = v78.m_CurrentBatch;\n\tv151 = v78.m_CurrentBatch == 0;\nL_FFFFFFFF:\n\tv683 = this;\n\tif (v151) goto L_01CA;\n\tv332 = v150.m_PostProcess == 0;\n\tif (v332) goto L_02A6;\n\tv617 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotProcess>::GetEnumerator(v150.m_PostProcess);\n\tv74.<>7__wrap12 = v617._list;\n\t*([v74 @ stack_-78_v2 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37)+D8]) = v617.Current;\n\tv74.<>1__state = -5;\nL_FFFFFFFF:\n\tv317 = v617._list;\n\tgoto L_016C;\nL_013B:\n\tthis.<>1__state = -1;\n\tgoto L_0145;\nL_0145:\n\tv167 = UnityEngine.Application::get_isPlaying();\n\tv393 = v167 == 0;\n\tif (v393) goto L_027A;\n\tv1444 = this.<>4__this == 0;\n\tif (v1444) goto L_02C4;\n\tv1501 = v78.m_Config;\n\tv1445 = v78.m_Config == 0;\n\tif (v1445) goto L_02C6;\n\tv394 = v1501.m_StopTimeOnCapture == 0;\n\tif (v394) goto L_027A;\n\tv1804 = UnityEngine.Time::get_timeScale();\n\tv78.m_PreviousTimeScale = v1804;\n\tUnityEngine.Time::set_timeScale(0f);\n\tv78.m_TimeStopped = 1;\n\tv74.<>2__current = 0;\n\tv74.<>1__state = 1;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_0823;\nL_FFFFFFFF:\n\tv542 = 0;\nL_FFFFFFFF:\n\tv486 = 0;\n\tgoto L_087E;\nL_0167:\n\tthis.<>1__state = -5;\nL_FFFFFFFF:\n\tv317 = v48;\n\tv608 = *([v74 @ stack_-78_v2 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37)+D8]);\n\tgoto L_017C;\nL_017C:\n\tv602 = UnityEngine.Object::op_Equality(*([v74 @ stack_-78_v2 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37)+D8]), 0);\n\tv1809 = v602 == 0;\n\tv604 = ~v1809;\n\tif (v604) goto L_016C;\n\tv1432 = this.<>4__this == 0;\n\tif (v1432) goto L_02A8;\n\tv1433 = *([v74 @ stack_-78_v2 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37)+D8]) == 0;\n\tif (v1433) goto L_02AA;\n\t*([v608 @ X20_v47 (UnityEngine.Object)+20]) = v78.m_CurrentBatch;\n\tv1492 = v74.<>8__1;\n\tv1434 = v74.<>8__1 == 0;\n\tif (v1434) goto L_02AC;\n\tv486 = v1492.resolution;\n\tv2007 = *([v608 @ X20_v47 (UnityEngine.Object)]);\n\t*([v2007 @ X8_v250 (Il2CppClass<UnityEngine.Object>)+178])(v2009, *([v74 @ stack_-78_v2 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37)+D8]), v1492.resolution, *([v2007 @ X8_v250 (Il2CppClass<UnityEngine.Object>)+180]), v43, v44, v45, v704, v47, v317, v49, v50, v51, v52, v53, v54, v55);\n\tv1493 = v74.<>8__1;\n\tv1435 = v74.<>8__1 == 0;\n\tif (v1435) goto L_02AE;\n\tv2071 = *([v608 @ X20_v47 (UnityEngine.Object)]);\n\t*([v2071 @ X8_v253 (Il2CppClass<UnityEngine.Object>)+188])(v2075, *([v74 @ stack_-78_v2 (AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37)+D8]), v1493.resolution, *([v2071 @ X8_v253 (Il2CppClass<UnityEngine.Object>)+190]), v43, v44, v45, v704, v47, v317, v49, v50, v51, v52, v53, v54, v55);\n\tv2079 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v2075);\n\tv74.<>2__current = v2079;\nL_FFFFFFFF:\n\tv264 = v2079;\nL_FFFFFFFF:\n\tv286 = 5;\nL_FFFFFFFF:\n\tv293 = v74;\n\tgoto L_080E;\nL_01AF:\n\tgoto L_01B8;\n\tv622 = new AlmostEngine.Screenshot.ScreenshotManager+<>c__DisplayClass37_1();\n\tSystem.Object::.ctor(v622);\n\tv1436 = v622 == 0;\n\tif (v1436) goto L_02B2;\n\tv1040 = v74.<>8__1;\n\tv622.CS$<>8__locals1 = v74.<>8__1;\n\tv650 = v74.<currentComposition>5__8 + 0x18;\n\tv873 = v74.<currentComposition>5__8 != 0;\n\tif (v873) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1332 = v2469;\n\tgoto L_01EF;\nL_FFFFFFFF:\n\tv1332 = v650;\n\tv1443 = v1500.m_Camera == 0;\n\tif (v1443) goto L_02C2;\n\tv1934 = UnityEngine.Object::get_name(v1500.m_Camera);\n\tv1494 = v622.CS$<>8__locals1;\n\tv1937 = v622.CS$<>8__locals1 == 0;\nL_FFFFFFFF:\n\tv859 = v1934;\nL_FFFFFFFF:\n\tv1040 = 0;\nL_FFFFFFFF:\n\tv1036 = 0;\n\tif (v1937) goto L_029E;\nL_01FB:\n\tv1437 = this.<>4__this == 0;\n\tif (v1437) goto L_02B4;\n\tv842 = v1494.resolution;\n\tv2013 = AlmostEngine.Screenshot.ScreenshotManager::ParseFileName(this.<>4__this, v1494.resolution, v74.<startTime>5__2, v859, v78.m_CurrentBatchName, *([v1332 @ X9_v100 (System.Int32)]), v704);\n\tv1438 = v1494.resolution == 0;\n\tif (v1438) goto L_02B6;\n\tv842.m_FileName = v2013;\n\tv1496 = v622.CS$<>8__locals1;\n\tv1439 = v622.CS$<>8__locals1 == 0;\n\tif (v1439) goto L_02B8;\n\tv1497 = v1496.resolution;\n\tv1440 = v1496.resolution == 0;\n\tif (v1440) goto L_02BA;\n\tv622.filename = v1497.m_FileName;\n\tv1498 = v622.CS$<>8__locals1;\n\tv1441 = v622.CS$<>8__locals1 == 0;\n\tif (v1441) goto L_02BC;\n\tv1334 = v1498.resolution;\n\tv1442 = v1498.resolution == 0;\n\tif (v1442) goto L_02BE;\n\tv1499 = v78.m_Config;\n\tv680 = v78.m_Config == 0;\n\tif (v680) goto L_02C0;\n\tv2516 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v2516, v622, Il2CppMethodInfo);\n\tv2593 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v2593, v622, Il2CppMethodInfo);\n\tv668 = v1499.m_JPGQuality == 0x7F800000;\n\tv648 = ~v668;\n\tif (v648) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv2470 = 0xFFFFFFFF80000000;\n\tgoto L_0255;\nL_FFFFFFFF:\n\tv2470 = v1499.m_JPGQuality;\nL_0270:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_0273:\n\tthis.<>1__state = -1;\nL_027D:\n\tv1585 = System.DateTime::get_Now();\n\tv74.<startTime>5__2 = v1585;\n\tv1078 = UnityEngine.Time::get_time();\n\tv1430 = this.<>4__this == 0;\n\tif (v1430) goto L_02A2;\n\tv78.m_LastShotTime = v1078;\n\tAlmostEngine.Screenshot.ScreenshotManager::InitScreenshotTaker(this.<>4__this);\n\tv1431 = v78.m_Config == 0;\n\tif (v1431) goto L_02A4;\n\tv1840 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveBatches(v78.m_Config);\n\tv74.<batches>5__3 = v1840;\n\tv74.<b>5__4 = 0;\n\tv1990 = v78.m_Config;\n\tv1927 = v78.m_Config == 0;\n\tv1928 = ~v1927;\nL_FFFFFFFF:\n\tv1035 = v1840;\nL_FFFFFFFF:\n\tv693 = v47;\nL_FFFFFFFF:\n\tv820 = v45;\nL_FFFFFFFF:\n\tv831 = v44;\nL_FFFFFFFF:\n\tv2470 = v43;\nL_FFFFFFFF:\n\tv1048 = v1840;\nL_FFFFFFFF:\n\tv2000 = v74;\nL_FFFFFFFF:\n\tv1507 = 0;\n\tif (v1928) goto L_057F;\nL_0297:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v1035;\n\tgoto L_0362;\nL_029A:\n\tv1494 = v622.CS$<>8__locals1;\n\tv1906 = v622.CS$<>8__locals1 == 0;\n\tv1907 = ~v1906;\nL_FFFFFFFF:\n\tv859 = \"\";\nL_FFFFFFFF:\n\tv1036 = v1040;\n\tif (v1907) goto L_01FB;\nL_029E:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v1036;\n\tgoto L_0362;\nL_02A0:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_02A2:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_02A4:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_02A6:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_02A8:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = 0;\n\tgoto L_0362;\nL_02AA:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = 0;\n\tgoto L_0362;\nL_02AC:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v78.m_CurrentBatch;\n\tgoto L_0362;\nL_02AE:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_02B0:\n\tv1364 = new System.NullReferenceException();\n\tgoto L_0362;\nL_02B2:\n\tthrow v622;\nL_02B4:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v1040;\n\tgoto L_0362;\nL_02B6:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v2013;\n\tgoto L_0362;\nL_02B8:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v2013;\n\tgoto L_0362;\nL_02BA:\n\tv1364 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv486 = v2013;\n\tgoto L_0\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdateCoroutine_003Ed__37::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x3C3903C", Offset = "0x3C3903C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -1;\n\tv46 = this + 0x98;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdateCoroutine_003Ed__37::_003C_003Em__Finally1");
			}

			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x3C38F84", Offset = "0x3C38F84", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -3;\n\tv46 = this + 0xC8;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally2()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdateCoroutine_003Ed__37::_003C_003Em__Finally2");
			}

			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x3C38FE0", Offset = "0x3C38FE0", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -3;\n\tv46 = this + 0xC8;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally3()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdateCoroutine_003Ed__37::_003C_003Em__Finally3");
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x3C390A0", Offset = "0x3C390A0", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000029")]
		private sealed class _003CUpdatePreviewCoroutine_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400010A")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400010B")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400010C")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotManager _003C_003E4__this;

			[Token(Token = "0x17000011")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000B5")]
				[Address(RVA = "0x3C3960C", Offset = "0x3C3960C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000012")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000B7")]
				[Address(RVA = "0x3C39654", Offset = "0x3C39654", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0x3C355BC", Offset = "0x3C355BC", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CUpdatePreviewCoroutine_003Ed__49(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0x3C390E8", Offset = "0x3C390E8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000B4")]
			[Address(RVA = "0x3C390EC", Offset = "0x3C390EC", Length = "0x470")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv61 = this.<>1__state == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_004C;\n\tthis.<>1__state = -1;\n\tv75 = v48.m_IsCapturing == 0;\n\tif (v75) goto L_0081;\nL_004C:\n\treturn 0;\nL_004E:\n\tthis.<>1__state = -1;\n\tgoto L_0056;\nL_0056:\n\tv88 = UnityEngine.Application::get_isPlaying();\n\tv329 = ~v88;\n\tif (v329) goto L_00E1;\n\tv242 = v48.m_Config;\n\tv352 = v242.m_PreviewInGameViewWhilePlaying != 1;\n\tif (v352) goto L_00E1;\n\tv353 = v242.m_ShowGuidesInPreview != 1;\n\tif (v353) goto L_00E1;\n\tAlmostEngine.Screenshot.ScreenshotManager::ShowGuides(this.<>4__this);\n\tgoto L_00EC;\nL_0081:\n\tv48.m_IsCapturing = 1;\n\tgoto L_008C;\n\tUnityEngine.Events.UnityAction::Invoke(v350.onCaptureBeginDelegate);\n\tv199 = v48.m_PreviewResolutions;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Clear(v199);\n\tv129 = v199.Count < 1;\n\tif (v129) goto L_00AC;\n\tv199 = v48.m_PreviewResolutions;\n\tgoto L_00BE;\n\tv130 = v208.Count < 1;\n\tif (v130) goto L_00FF;\n\tv209 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::get_Item(v208, 0);\n\tv451 = v199 == 0;\n\tv226 = ~v451;\n\tv122 = v209;\n\tif (v226) goto L_0106;\n\tgoto L_01AC;\nL_00E1:\n\tAlmostEngine.Screenshot.ScreenshotManager::HideGuides(this.<>4__this);\n\tgoto L_00EC;\n\tUnityEngine.Events.UnityAction::Invoke(v424.onCaptureEndDelegate);\n\tv48.m_IsCapturing = 0;\n\treturn 0;\nL_00FF:\n\tv122 = v203.m_GameViewResolution;\nL_0106:\n\t;\n\tgoto L_0123;\nL_0123:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Add(v199, v122);\n\tAlmostEngine.Screenshot.ScreenshotConfig::UpdateGameviewResolution(v48.m_Config);\n\tv214 = v48.m_PreviewOverlayList;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Clear(v214);\n\tv131 = v214.Count < 1;\n\tif (v131) goto L_0141;\n\tv214 = v48.m_PreviewOverlayList;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::AddRange(v214, v249.m_Overlays);\n\tv490 = v48.m_Config;\n\tv480 = v490.m_ShowGuidesInPreview == 0;\n\tif (v480) goto L_0181;\n\tv484 = new AlmostEngine.Screenshot.ScreenshotOverlay();\n\tAlmostEngine.Screenshot.ScreenshotOverlay::.ctor(v484, v490.m_GuideCanvas);\n\tv48.m_GuidesOverlay = v484;\n\tv216 = v48.m_PreviewOverlayList;\n\tgoto L_0186;\nL_0181:\n\tv48.m_CurrentBurstFrame = 0;\n\tgoto L_018E;\nL_0186:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Add(v216, v48.m_GuidesOverlay);\n\tAlmostEngine.Screenshot.ScreenshotManager::ShowGuides(this.<>4__this);\n\tv490 = v48.m_Config;\n\tv48.m_CurrentBurstFrame = 0;\nL_018E:\n\tv492 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveCameras(v490);\n\tv499 = AlmostEngine.Screenshot.ScreenshotManager::UpdateCoroutine(this.<>4__this, v48.m_PreviewResolutions, v492, v48.m_PreviewOverlayList, 0, 0, 1);\n\tv502 = UnityEngine.MonoBehaviour::StartCoroutine(this.<>4__this, v499);\n\tthis.<>2__current = v502;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_01AC:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_002C:\n\tv48 = this.<>4__this;\n\tv53 = this.<>1__state == 1;\n\tif (v53) goto L_004E;\nL_00EC:\n\t;\nL_008C:\n\t;\nL_00AC:\n\tv203 = v48.m_Config;\nL_00BE:\n\tv208 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(v48.m_Config);\nL_0141:\n\tv249 = v48.m_Config;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager._003CUpdatePreviewCoroutine_003Ed__49::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000B6")]
			[Address(RVA = "0x3C39614", Offset = "0x3C39614", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotConfig m_Config;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x28")]
		protected ScreenshotTaker m_ScreenshotTaker;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x30")]
		public bool m_IsBurstActive;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x31")]
		private bool m_IsCapturing;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x34")]
		private int m_PreviousFrameRate;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x38")]
		private int m_PreviousVSync;

		[Token(Token = "0x40000D1")]
		public static UnityAction onCaptureBeginDelegate;

		[Token(Token = "0x40000D2")]
		public static UnityAction onCaptureEndDelegate;

		[Token(Token = "0x40000D3")]
		public static ExportDelegate onResolutionExportSuccessDelegate;

		[Token(Token = "0x40000D4")]
		public static ExportDelegate onResolutionExportFailureDelegate;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x3C")]
		private int m_CurrentBurstFrame;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x40")]
		private ScreenshotComposer m_CurrentComposerInstance;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x48")]
		public float m_LastShotTime;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x50")]
		public ScreenshotBatch m_CurrentBatch;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x58")]
		public string m_CurrentBatchName;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x60")]
		private float m_PreviousTimeScale;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x64")]
		private bool m_TimeStopped;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x68")]
		private List<ScreenshotResolution> m_PreviewResolutions;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x70")]
		private List<ScreenshotOverlay> m_PreviewOverlayList;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x78")]
		private ScreenshotOverlay m_GuidesOverlay;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x80")]
		private GameObject m_GuideInstance;

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x3C33F9C", Offset = "0x3C33F9C", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_0020:\n\tv54 = UnityEngine.Application::get_targetFrameRate();\n\tthis.m_PreviousFrameRate = v54;\n\tv56 = UnityEngine.QualitySettings::get_vSyncCount();\n\tthis.m_PreviousVSync = v56;\n\tthis.m_LastShotTime = -Infinityf;\n\tAlmostEngine.Screenshot.ScreenshotManager::Reset(this);\n\tAlmostEngine.Screenshot.ScreenshotManager::ClearCache(this);\n\tv60 = this.m_Config;\n\tv72 = v60.m_DontDestroyOnLoad != 1;\n\tif (v72) goto L_0046;\n\tgoto L_003F;\nL_003F:\n\tv109 = UnityEngine.Application::get_isPlaying();\n\tv202 = ~v109;\n\tv112 = ~v202;\n\tif (v112) goto L_0054;\nL_0046:\n\tgoto L_0048;\nL_0048:\n\tv137 = UnityEngine.Application::get_isPlaying();\n\tv204 = ~v137;\n\tv205 = ~v204;\n\tif (v205) goto L_0073;\n\tgoto L_0093;\nL_0054:\n\tv212 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_005C;\nL_005C:\n\tUnityEngine.Object::DontDestroyOnLoad(v212);\n\tgoto L_0048;\nL_0073:\n\tv101 = this.m_Config;\n\tv156 = v101.m_PreviewInGameViewWhilePlaying != 1;\n\tif (v156) goto L_0093;\n\tAlmostEngine.Screenshot.ScreenshotManager::InitIngamePreview(this);\n\treturn;\nL_0093:\n\treturn;\nL_001D:\n\tgoto L_0020;\n")]
		public void Awake()
		{
			int targetFrameRate = Application.targetFrameRate;
			m_PreviousFrameRate = targetFrameRate;
			int vSyncCount = QualitySettings.vSyncCount;
			m_PreviousVSync = vSyncCount;
			m_LastShotTime = -1f / 0f;
			Reset();
			ClearCache();
			ScreenshotConfig config = m_Config;
			if (config.m_DontDestroyOnLoad && Application.isPlaying)
			{
				GameObject target = base.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
			if (Application.isPlaying)
			{
				ScreenshotConfig config2 = m_Config;
				if (config2.m_PreviewInGameViewWhilePlaying)
				{
					InitIngamePreview();
				}
			}
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x3C34440", Offset = "0x3C34440", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnDestroy()
		{
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x3C34124", Offset = "0x3C34124", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0022:\n\tUnityEngine.Object::DestroyImmediate(this.m_CurrentComposerInstance);\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tthis.m_IsCapturing = 0;\n\tv68 = this.m_IsBurstActive != 1;\n\tif (v68) goto L_005A;\n\tthis.m_IsBurstActive = 0;\n\tv69 = this.m_Config;\n\tv72 = v69.m_FixedFrameRate != 1;\n\tif (v72) goto L_005A;\n\tgoto L_004E;\nL_004E:\n\tUnityEngine.Application::set_targetFrameRate(this.m_PreviousFrameRate);\n\tUnityEngine.QualitySettings::set_vSyncCount(this.m_PreviousVSync);\nL_005A:\n\tAlmostEngine.Screenshot.ScreenshotManager::InitScreenshotTaker(this);\n\treturn;\nL_001E:\n\tgoto L_0022;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			UnityEngine.Object.DestroyImmediate(m_CurrentComposerInstance);
			StopAllCoroutines();
			m_IsCapturing = false;
			if (m_IsBurstActive)
			{
				m_IsBurstActive = false;
				ScreenshotConfig config = m_Config;
				if (config.m_FixedFrameRate)
				{
					Application.targetFrameRate = m_PreviousFrameRate;
					QualitySettings.vSyncCount = m_PreviousVSync;
				}
			}
			InitScreenshotTaker();
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x3C3420C", Offset = "0x3C3420C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tAlmostEngine.Screenshot.ScreenshotConfig::ClearCache(this.m_Config);\n\tgoto L_0022;\nL_0022:\n\tv66 = UnityEngine.Object::op_Inequality(this.m_ScreenshotTaker, 0);\n\tv95 = ~v66;\n\tif (v95) goto L_0040;\n\tAlmostEngine.Screenshot.ScreenshotTaker::ClearRenderTextureCache(v66);\n\treturn;\nL_0040:\n\treturn;\n")]
		public void ClearCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager::ClearCache");
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x3C34860", Offset = "0x3C34860", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv50 = UnityEngine.Application::get_isPlaying();\n\tv57 = ~v50;\n\tif (v57) goto L_0039;\n\tAlmostEngine.Screenshot.ScreenshotManager::HandleHotkeys(this);\n\treturn;\nL_0039:\n\treturn;\n")]
		private void Update()
		{
			if (Application.isPlaying)
			{
				HandleHotkeys();
			}
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x3C34444", Offset = "0x3C34444", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv226 = this + 0x28;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_ScreenshotTaker, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_005A;\n\tv111 = this.m_ScreenshotTaker;\n\tgoto L_0026;\nL_0026:\n\tv121 = UnityEngine.Object::op_Equality(v111, 0);\n\tv137 = ~v121;\n\tv138 = ~v137;\n\tif (v138) goto L_0071;\n\tv173 = this.m_ScreenshotTaker;\n\tgoto L_0032;\nL_0032:\n\tv183 = UnityEngine.Object::op_Equality(v173, 0);\n\tv193 = ~v183;\n\tv194 = ~v193;\n\tif (v194) goto L_008B;\n\tgoto L_0096;\nL_005A:\n\tgoto L_005D;\nL_005D:\n\tv133 = UnityEngine.Object::FindObjectOfType();\n\t*([v226 @ X20_v5]) = v133;\n\tv111 = this.m_ScreenshotTaker;\n\tv226 = v226;\n\tgoto L_0026;\nL_0071:\n\tv166 = UnityEngine.Component::get_gameObject(this);\n\tv202 = UnityEngine.GameObject::GetComponent(v166);\n\t*([v226 @ X20_v5]) = v202;\n\tv173 = this.m_ScreenshotTaker;\n\tv226 = v226;\n\tgoto L_0032;\nL_008B:\n\tv213 = UnityEngine.Component::get_gameObject(this);\n\tv267 = UnityEngine.GameObject::AddComponent(v213);\n\t*([v226 @ X20_v5]) = v267;\nL_0096:\n\tv224 = this.m_Config;\n\tv205 = this.m_ScreenshotTaker;\n\tv205.m_GameViewResizingWaitingMode = v224.m_GameViewResizingWaitingMode;\n\tv205.m_GameViewResizingWaitingFrames = v224.m_ResizingWaitingFrames;\n\tv205.m_GameViewResizingWaitingTime = v224.m_ResizingWaitingTime;\n\treturn;\n")]
		protected void InitScreenshotTaker()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager::InitScreenshotTaker");
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x3C348F4", Offset = "0x3C348F4", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_Config;\n\tv65 = AlmostEngine.HotKey::IsPressed(v14.m_AlignHotkey);\n\tv82 = this.m_Config;\n\tv67 = AlmostEngine.HotKey::IsPressed(v82.m_PauseHotkey);\n\tv84 = this.m_Config;\n\tv164 = ~v67;\n\tif (v164) goto L_003D;\n\tv178 = v84.m_Time == 0;\n\tv167 = ~v178;\n\tif (v167) goto L_FFFFFFFF;\n\tv188 = v84.m_Time == 1f;\n\tif (v188) goto L_003D;\nL_FFFFFFFF:\n\tv166 = 1f;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv166 = 0;\nL_003D:\n\tv196 = AlmostEngine.HotKey::IsPressed(v84.m_UpdatePreviewHotkey);\n\tv197 = ~v196;\n\tif (v197) goto L_0045;\n\tv202 = AlmostEngine.Screenshot.ScreenshotManager::UpdatePreview(this);\n\tv150 = AlmostEngine.HotKey::IsPressed(v85.m_CaptureHotkey);\n\tv156 = ~v150;\n\tif (v156) goto L_0063;\n\tv129 = this.m_IsBurstActive != 1;\n\tif (v129) goto L_006B;\n\tthis.m_IsBurstActive = 0;\nL_006B:\n\tgoto L_0072;\n\tv151 = UnityEngine.MonoBehaviour::StartCoroutine(this, v218);\n\treturn;\nL_0033:\n\tv84.m_Time = v166;\n\tUnityEngine.Time::set_timeScale(v166);\n\tv84 = this.m_Config;\nL_0045:\n\tv85 = this.m_Config;\nL_0063:\n\treturn;\nL_0072:\n\tv218 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureAllCoroutine>d__22();\n\tSystem.Object::.ctor(v218);\n\tv218.<>1__state = 0;\n\tv218.<>4__this = this;\n")]
		protected void HandleHotkeys()
		{
			ScreenshotConfig config = m_Config;
			bool flag = config.m_AlignHotkey.IsPressed();
			ScreenshotConfig config2 = m_Config;
			bool flag2 = config2.m_PauseHotkey.IsPressed();
			ScreenshotConfig config3 = m_Config;
			if (flag2)
			{
				float num;
				if (config3.m_Time == 0f)
				{
					if (config3.m_Time == 1f)
					{
						goto IL_00d4;
					}
					num = 1f;
				}
				else
				{
					num = 0f;
				}
				config3.m_Time = num;
				Time.timeScale = num;
				config3 = m_Config;
			}
			goto IL_00d4;
			IL_00d4:
			if (config3.m_UpdatePreviewHotkey.IsPressed())
			{
				UpdatePreview();
			}
			ScreenshotConfig config4 = m_Config;
			if (config4.m_CaptureHotkey.IsPressed())
			{
				if (m_IsBurstActive)
				{
					m_IsBurstActive = false;
					return;
				}
				_003CCaptureAllCoroutine_003Ed__22 _003CCaptureAllCoroutine_003Ed__23 = (_003CCaptureAllCoroutine_003Ed__22)FormatterServices.GetUninitializedObject(typeof(_003CCaptureAllCoroutine_003Ed__22));
				_003CCaptureAllCoroutine_003Ed__23._003C_003E1__state = 0;
				_003CCaptureAllCoroutine_003Ed__23._003C_003E4__this = this;
				Coroutine coroutine = StartCoroutine(_003CCaptureAllCoroutine_003Ed__23);
			}
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x3C34A50", Offset = "0x3C34A50", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureAllCoroutine>d__22();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public void Capture()
		{
			_003CCaptureAllCoroutine_003Ed__22 _003CCaptureAllCoroutine_003Ed__23 = (_003CCaptureAllCoroutine_003Ed__22)FormatterServices.GetUninitializedObject(typeof(_003CCaptureAllCoroutine_003Ed__22));
			_003CCaptureAllCoroutine_003Ed__23._003C_003E1__state = 0;
			_003CCaptureAllCoroutine_003Ed__23._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CCaptureAllCoroutine_003Ed__23);
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x3C34B48", Offset = "0x3C34B48", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotManager+<UpdateAllCoroutine>d__21();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public void UpdateAll()
		{
			_003CUpdateAllCoroutine_003Ed__21 _003CUpdateAllCoroutine_003Ed__22 = (_003CUpdateAllCoroutine_003Ed__21)FormatterServices.GetUninitializedObject(typeof(_003CUpdateAllCoroutine_003Ed__21));
			_003CUpdateAllCoroutine_003Ed__22._003C_003E1__state = 0;
			_003CUpdateAllCoroutine_003Ed__22._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CUpdateAllCoroutine_003Ed__22);
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x3C34C40", Offset = "0x3C34C40", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.resolutions = resolutions;\n\tv46.export = 0;\n\tv66 = UnityEngine.MonoBehaviour::StartCoroutine(this, v46);\n\treturn;\nL_0018:\n\tv46 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureCoroutine>d__31();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		public void UpdateResolutions(List<ScreenshotResolution> resolutions)
		{
			_003CCaptureCoroutine_003Ed__31 _003CCaptureCoroutine_003Ed__32 = (_003CCaptureCoroutine_003Ed__31)FormatterServices.GetUninitializedObject(typeof(_003CCaptureCoroutine_003Ed__31));
			_003CCaptureCoroutine_003Ed__32._003C_003E1__state = 0;
			_003CCaptureCoroutine_003Ed__32._003C_003E4__this = this;
			_003CCaptureCoroutine_003Ed__32.resolutions = resolutions;
			_003CCaptureCoroutine_003Ed__32.export = false;
			_003CCaptureCoroutine_003Ed__32.playSoundMask = false;
			Coroutine coroutine = StartCoroutine(_003CCaptureCoroutine_003Ed__32);
		}

		[IteratorStateMachine(typeof(_003CUpdateAllCoroutine_003Ed__21))]
		[Token(Token = "0x600006C")]
		[Address(RVA = "0x3C34BC8", Offset = "0x3C34BC8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotManager+<UpdateAllCoroutine>d__21();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator UpdateAllCoroutine()
		{
			_003CUpdateAllCoroutine_003Ed__21 _003CUpdateAllCoroutine_003Ed__22 = (_003CUpdateAllCoroutine_003Ed__21)FormatterServices.GetUninitializedObject(typeof(_003CUpdateAllCoroutine_003Ed__21));
			_003CUpdateAllCoroutine_003Ed__22._003C_003E1__state = 0;
			_003CUpdateAllCoroutine_003Ed__22._003C_003E4__this = this;
			return _003CUpdateAllCoroutine_003Ed__22;
		}

		[IteratorStateMachine(typeof(_003CCaptureAllCoroutine_003Ed__22))]
		[Token(Token = "0x600006D")]
		[Address(RVA = "0x3C34AD0", Offset = "0x3C34AD0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureAllCoroutine>d__22();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator CaptureAllCoroutine()
		{
			_003CCaptureAllCoroutine_003Ed__22 _003CCaptureAllCoroutine_003Ed__23 = (_003CCaptureAllCoroutine_003Ed__22)FormatterServices.GetUninitializedObject(typeof(_003CCaptureAllCoroutine_003Ed__22));
			_003CCaptureAllCoroutine_003Ed__23._003C_003E1__state = 0;
			_003CCaptureAllCoroutine_003Ed__23._003C_003E4__this = this;
			return _003CCaptureAllCoroutine_003Ed__23;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x3C34DD4", Offset = "0x3C34DD4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_Config;\n\tgoto L_0018;\n\tv58 = v19.Count < 1;\n\tif (v58) goto L_0036;\n\tv110 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::get_Item(v19, 0);\n\tv107 = v110 == 0;\n\treturnVal2 = v110;\n\tif (v107) goto L_0035;\nL_002F:\n\treturnVal2 = v110.m_Texture;\nL_0036:\n\tv110 = v10.m_GameViewResolution;\n\tv105 = v10.m_GameViewResolution == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_002F;\n\treturnVal2 = v10.m_GameViewResolution;\n\tgoto L_0035;\nL_0018:\n\tv19 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this.m_Config);\nL_0035:\n\treturn returnVal2;\n")]
		public Texture2D GetLastScreenshotTexture()
		{
			ScreenshotConfig config = m_Config;
			List<ScreenshotResolution> activeResolutions = m_Config.GetActiveResolutions();
			ScreenshotResolution screenshotResolution;
			Texture2D result;
			if (activeResolutions.Count >= 1)
			{
				screenshotResolution = activeResolutions[0];
				bool flag = screenshotResolution == null;
				result = (Texture2D)(object)screenshotResolution;
				if (!flag)
				{
					goto IL_0069;
				}
			}
			else
			{
				screenshotResolution = config.m_GameViewResolution;
				if (config.m_GameViewResolution != null)
				{
					goto IL_0069;
				}
				result = (Texture2D)(object)config.m_GameViewResolution;
			}
			goto IL_00d7;
			IL_0069:
			result = screenshotResolution.m_Texture;
			goto IL_00d7;
			IL_00d7:
			return result;
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x3C2EB4C", Offset = "0x3C2EB4C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_Config;\n\tv15 = v0.m_DestinationFolder != 0;\n\tif (v15) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv39 = 0x20;\n\tgoto L_0016;\nL_FFFFFFFF:\n\tv39 = 0x18;\nL_0016:\n\treturnVal2 = AlmostEngine.Screenshot.ScreenshotNameParser::ParsePath(this, *([v0 @ X8_v1 (AlmostEngine.Screenshot.ScreenshotConfig)+v39 @ X9_v3 (System.Int32)]));\n\treturn returnVal2;\n")]
		public string GetExportPath()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager::GetExportPath");
			return default;
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x3C34E64", Offset = "0x3C34E64", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_Config;\n\tgoto L_0018;\n\tv59 = v19.Count < 1;\n\tif (v59) goto L_0039;\n\treturnVal3 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::get_Item(v19, 0);\n\treturn returnVal3;\nL_0039:\n\treturn v10.m_GameViewResolution;\nL_0018:\n\tv19 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this.m_Config);\n")]
		public ScreenshotResolution GetLastScreenshot()
		{
			ScreenshotConfig config = m_Config;
			List<ScreenshotResolution> activeResolutions = m_Config.GetActiveResolutions();
			if (activeResolutions.Count >= 1)
			{
				return activeResolutions[0];
			}
			return config.m_GameViewResolution;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x3C34EEC", Offset = "0x3C34EEC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tgoto L_0024;\n\tv110 = 0xB2E5000 + 0x208;\n\tv72 = v46.Count < 1;\n\tif (v72) goto L_003C;\n\tv128 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::get_Item(v46, 0);\n\tgoto L_003D;\nL_003C:\n\tv128 = v38.m_GameViewResolution;\n\tv102 = v110;\n\tgoto L_0053;\nL_0012:\n\tv38 = this.m_Config;\nL_0024:\n\tv46 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this.m_Config);\nL_003D:\n\tv102 = v128 + 0x58;\n\tv65 = v128 != 0;\n\tif (v65) goto L_0053;\nL_0053:\n\treturn *([v102 @ X8_v9 (System.Int32)]);\n")]
		public string GetLastScreenshotFilename()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager::GetLastScreenshotFilename");
			return default;
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x3C34FAC", Offset = "0x3C34FAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Config;\n")]
		public ScreenshotConfig GetConfig()
		{
			return m_Config;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x3C34FB4", Offset = "0x3C34FB4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this.m_Config);\n\treturn;\n")]
		public void ShareAll()
		{
			List<ScreenshotResolution> activeResolutions = m_Config.GetActiveResolutions();
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x3C34FCC", Offset = "0x3C34FCC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this.m_Config);\n\tAlmostEngine.Screenshot.ScreenshotConfig::ExportToFiles(this.m_Config, v14);\n\treturn;\n")]
		public void ExportAllToFiles()
		{
			List<ScreenshotResolution> activeResolutions = m_Config.GetActiveResolutions();
			m_Config.ExportToFiles(activeResolutions);
		}

		[IteratorStateMachine(typeof(_003CCaptureCoroutine_003Ed__31))]
		[Token(Token = "0x6000075")]
		[Address(RVA = "0x3C34CD8", Offset = "0x3C34CD8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv52.resolutions = resolutions;\n\tv52.export = export;\n\tv52.playSoundMask = playSoundMask;\n\treturn v52;\nL_001C:\n\tv52 = new AlmostEngine.Screenshot.ScreenshotManager+<CaptureCoroutine>d__31();\n\tSystem.Object::.ctor(v52);\n\tv52.<>1__state = 0;\n\tv52.<>4__this = this;\n")]
		public IEnumerator CaptureCoroutine(List<ScreenshotResolution> resolutions, bool export = true, bool playSoundMask = true)
		{
			_003CCaptureCoroutine_003Ed__31 _003CCaptureCoroutine_003Ed__32 = (_003CCaptureCoroutine_003Ed__31)FormatterServices.GetUninitializedObject(typeof(_003CCaptureCoroutine_003Ed__31));
			_003CCaptureCoroutine_003Ed__32._003C_003E1__state = 0;
			_003CCaptureCoroutine_003Ed__32._003C_003E4__this = this;
			_003CCaptureCoroutine_003Ed__32.resolutions = resolutions;
			_003CCaptureCoroutine_003Ed__32.export = export;
			_003CCaptureCoroutine_003Ed__32.playSoundMask = playSoundMask;
			return _003CCaptureCoroutine_003Ed__32;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x3C34A48", Offset = "0x3C34A48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_IsBurstActive = 0;\n\treturn;\n")]
		public void StopBurst()
		{
			m_IsBurstActive = false;
		}

		[IteratorStateMachine(typeof(_003CUpdateCoroutine_003Ed__37))]
		[Token(Token = "0x6000077")]
		[Address(RVA = "0x3C3502C", Offset = "0x3C3502C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv63.resolutions = resolutions;\n\tv63.cameras = cameras;\n\tv63.overlays = overlays;\n\tv63.export = export;\n\tv63.playSoundMask = playSoundMask;\n\tv63.isPreview = isPreview;\n\treturn v63;\nL_0023:\n\tv63 = new AlmostEngine.Screenshot.ScreenshotManager+<UpdateCoroutine>d__37();\n\tSystem.Object::.ctor(v63);\n\tv63.<>1__state = 0;\n\tv63.<>4__this = this;\n")]
		protected IEnumerator UpdateCoroutine(List<ScreenshotResolution> resolutions, List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, bool export = true, bool playSoundMask = true, bool isPreview = false)
		{
			_003CUpdateCoroutine_003Ed__37 _003CUpdateCoroutine_003Ed__38 = (_003CUpdateCoroutine_003Ed__37)FormatterServices.GetUninitializedObject(typeof(_003CUpdateCoroutine_003Ed__37));
			_003CUpdateCoroutine_003Ed__38._003C_003E1__state = 0;
			_003CUpdateCoroutine_003Ed__38._003C_003E4__this = this;
			_003CUpdateCoroutine_003Ed__38.resolutions = resolutions;
			_003CUpdateCoroutine_003Ed__38.cameras = cameras;
			_003CUpdateCoroutine_003Ed__38.overlays = overlays;
			_003CUpdateCoroutine_003Ed__38.export = export;
			_003CUpdateCoroutine_003Ed__38.playSoundMask = playSoundMask;
			_003CUpdateCoroutine_003Ed__38.isPreview = isPreview;
			return _003CUpdateCoroutine_003Ed__38;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x3C3513C", Offset = "0x3C3513C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Time::get_timeScale();\n\tthis.m_PreviousTimeScale = v13;\n\tUnityEngine.Time::set_timeScale(0f);\n\tthis.m_TimeStopped = 1;\n\treturn;\n")]
		private void StopTime()
		{
			float timeScale = Time.timeScale;
			m_PreviousTimeScale = timeScale;
			Time.timeScale = 0f;
			m_TimeStopped = true;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x3C35178", Offset = "0x3C35178", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.m_TimeStopped != 1;\n\tif (v11) goto L_001C;\n\tUnityEngine.Time::set_timeScale(this.m_PreviousTimeScale);\n\tthis.m_TimeStopped = 0;\nL_001C:\n\treturn;\n")]
		private void RestoreTime()
		{
			if (m_TimeStopped)
			{
				Time.timeScale = m_PreviousTimeScale;
				m_TimeStopped = false;
			}
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x3C351B0", Offset = "0x3C351B0", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv76 = v59.m_DestinationFolder != 0;\n\tif (v76) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv119 = 0x20;\n\tgoto L_0042;\nL_FFFFFFFF:\n\tv119 = 0x18;\n\tv129 = System.String::Replace(v128, \"{layer}\", currentCamera);\n\tv130 = System.String::Replace(v129, \"{batch}\", currentBatch);\n\tv220 = System.String::Replace(v130, \"{composer}\", currentComposer);\n\tv131 = System.Int32::ToString(&this.m_CurrentBurstFrame (System.Int32));\n\tv145 = this.m_Config;\n\tv132 = System.String::PadLeft(v131, v145.m_NumberLeftPadding, 0x30);\n\treturnVal2 = System.String::Replace(v220, \"{burstFrameCount}\", v132);\n\tv146 = this.m_Config;\n\tv192 = v146.m_OverwriteFiles == 0;\n\tif (v192) goto L_0091;\n\treturn returnVal2;\nL_0091:\n\treturnVal3 = AlmostEngine.PathUtils::PreventOverwrite(returnVal2, v146.m_NumberLeftPadding);\n\treturn returnVal3;\nL_0027:\n\tv59 = this.m_Config;\nL_0042:\n\tv128 = AlmostEngine.Screenshot.ScreenshotNameParser::ParseFileName(v59.m_FileName, v52, time, *([v59 @ X8_v3 (AlmostEngine.Screenshot.ScreenshotConfig)+v119 @ X9_v4 (System.Int32)]), v59.m_FileFormat, v59.m_OverwriteFiles, time, v59.m_NumberLeftPadding);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string ParseFileName(ScreenshotResolution resolution, DateTime time, string currentCamera = "", string currentBatch = "", string currentComposer = "", int currentBurstFrame = 0)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotManager::ParseFileName");
			return default;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x3C35354", Offset = "0x3C35354", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = AlmostEngine.Screenshot.ScreenshotManager::ParseFileName(this, resolution, time, currentCamera, currentBatch, currentComposer, currentBurstFrame);\n\tresolution.m_FileName = v12;\n\treturn;\n")]
		public void UpdateFileName(ScreenshotResolution resolution, DateTime time, string currentCamera = "", string currentBatch = "", string currentComposer = "", int currentBurstFrame = 0)
		{
			string fileName = ParseFileName(resolution, time, currentCamera, currentBatch, currentComposer, currentBurstFrame);
			resolution.m_FileName = fileName;
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x3C35388", Offset = "0x3C35388", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([B78D43C]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0027;\n\tv26 = UnityEngine.Component::GetComponent(this);\n\tv53 = v26;\n\tgoto L_001B;\nL_001B:\n\tv63 = UnityEngine.Object::op_Equality(v53, 0);\n\tv75 = v63 == 0;\n\tif (v75) goto L_003B;\n\tgoto L_0051;\nL_0027:\n\t*([B78D43C]) = 1;\n\tv54 = UnityEngine.Component::GetComponent(this);\n\tv53 = v54;\n\tgoto L_001B;\nL_003B:\n\tv89 = this.m_Config;\n\tgoto L_0046;\nL_0046:\n\tv98 = UnityEngine.Object::op_Equality(v89.m_ShotSound, 0);\n\tv104 = v98 == 0;\n\tif (v104) goto L_005D;\nL_0051:\n\treturn;\nL_005D:\n\tv121 = UnityEngine.Component::GetComponent(this);\n\tv128 = this.m_Config;\n\tUnityEngine.AudioSource::PlayOneShot(v121, v128.m_ShotSound);\n\treturn;\n")]
		private void PlaySound()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78D43C]");
			UnityEngine.Object obj;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				AudioSource component = GetComponent<AudioSource>();
				obj = component;
			}
			else
			{
				_ = 1;
				AudioSource component2 = GetComponent<AudioSource>();
				obj = component2;
			}
			if (!(obj == null))
			{
				ScreenshotConfig config = m_Config;
				if (!(config.m_ShotSound == null))
				{
					AudioSource component3 = GetComponent<AudioSource>();
					ScreenshotConfig config2 = m_Config;
					component3.PlayOneShot(config2.m_ShotSound);
				}
			}
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x3C354C4", Offset = "0x3C354C4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotManager+<UpdatePreviewCoroutine>d__49();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public virtual void UpdatePreview()
		{
			_003CUpdatePreviewCoroutine_003Ed__49 _003CUpdatePreviewCoroutine_003Ed__50 = (_003CUpdatePreviewCoroutine_003Ed__49)FormatterServices.GetUninitializedObject(typeof(_003CUpdatePreviewCoroutine_003Ed__49));
			_003CUpdatePreviewCoroutine_003Ed__50._003C_003E1__state = 0;
			_003CUpdatePreviewCoroutine_003Ed__50._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CUpdatePreviewCoroutine_003Ed__50);
		}

		[IteratorStateMachine(typeof(_003CUpdatePreviewCoroutine_003Ed__49))]
		[Token(Token = "0x600007E")]
		[Address(RVA = "0x3C35544", Offset = "0x3C35544", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new AlmostEngine.Screenshot.ScreenshotManager+<UpdatePreviewCoroutine>d__49();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		public IEnumerator UpdatePreviewCoroutine()
		{
			_003CUpdatePreviewCoroutine_003Ed__49 _003CUpdatePreviewCoroutine_003Ed__50 = (_003CUpdatePreviewCoroutine_003Ed__49)FormatterServices.GetUninitializedObject(typeof(_003CUpdatePreviewCoroutine_003Ed__49));
			_003CUpdatePreviewCoroutine_003Ed__50._003C_003E1__state = 0;
			_003CUpdatePreviewCoroutine_003Ed__50._003C_003E4__this = this;
			return _003CUpdatePreviewCoroutine_003Ed__50;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x3C342BC", Offset = "0x3C342BC", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Clear(v104);\n\tv57 = v104.Count < 1;\n\tif (v57) goto L_0034;\n\tv104 = this.m_PreviewOverlayList;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::AddRange(v104, v121.m_Overlays);\n\tv122 = this.m_Config;\n\tv73 = v122.m_ShowGuidesInPreview != 1;\n\tif (v73) goto L_0074;\n\tv189 = UnityEngine.Component::get_gameObject(v122.m_GuideCanvas);\n\tgoto L_0060;\n\tUnityEngine.Object::set_hideFlags(this.m_GuideInstance, 0x34);\n\tUnityEngine.GameObject::SetActive(this.m_GuideInstance, 1);\nL_0074:\n\tAlmostEngine.Screenshot.ScreenshotManager::InitScreenshotTaker(this);\n\tv109 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveCameras(this.m_Config);\n\tv125 = this.m_Config;\n\tAlmostEngine.Screenshot.ScreenshotTaker::ApplySettings(this.m_ScreenshotTaker, v109, this.m_PreviewOverlayList, v125.m_CaptureMode, v125.m_CaptureActiveUICanvas, v125.m_ForceUICullingLayer);\n\treturn;\nL_001B:\n\tv104 = this.m_PreviewOverlayList;\nL_0034:\n\tv121 = this.m_Config;\nL_0060:\n\tv194 = UnityEngine.Object::Instantiate(v189);\n\tthis.m_GuideInstance = v194;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void InitIngamePreview()
		{
			List<ScreenshotOverlay> previewOverlayList = m_PreviewOverlayList;
			previewOverlayList.Clear();
			if (previewOverlayList.Count >= 1)
			{
				previewOverlayList = m_PreviewOverlayList;
			}
			ScreenshotConfig config = m_Config;
			previewOverlayList.AddRange(config.m_Overlays);
			ScreenshotConfig config2 = m_Config;
			if (config2.m_ShowGuidesInPreview)
			{
				GameObject original = config2.m_GuideCanvas.gameObject;
				GameObject guideInstance = UnityEngine.Object.Instantiate(original);
				m_GuideInstance = guideInstance;
				m_GuideInstance.hideFlags = HideFlags.DontSave;
				m_GuideInstance.SetActive(value: true);
			}
			InitScreenshotTaker();
			List<ScreenshotCamera> activeCameras = m_Config.GetActiveCameras();
			ScreenshotConfig config3 = m_Config;
			m_ScreenshotTaker.ApplySettings(activeCameras, m_PreviewOverlayList, config3.m_CaptureMode, config3.m_CaptureActiveUICanvas, config3.m_ForceUICullingLayer);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x3C35AEC", Offset = "0x3C35AEC", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv73 = v59.m_ShowGuidesInPreview != 1;\n\tif (v73) goto L_0112;\n\tgoto L_0038;\nL_0038:\n\tv296 = UnityEngine.Object::op_Inequality(v59.m_GuideCanvas, 0);\n\tv360 = ~v296;\n\tv301 = ~v360;\n\tif (v301) goto L_0044;\n\tgoto L_0112;\nL_0044:\n\tv214 = this.m_Config;\n\tv186 = UnityEngine.Component::get_gameObject(v214.m_GuideCanvas);\n\tUnityEngine.GameObject::SetActive(v186, 1);\n\tv215 = this.m_Config;\n\tUnityEngine.Behaviour::set_enabled(v215.m_GuideCanvas, 1);\n\tv216 = this.m_Config;\n\tgoto L_0073;\nL_0073:\n\tv188 = UnityEngine.Component::GetComponentsInChildren(v216.m_GuideCanvas);\n\tv384 = v188.Length < 1;\n\tif (v384) goto L_00A3;\nL_FFFFFFFF:\n\tv94 = 0;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v7 (UnityEngine.Color), typeof(UnityEngine.Color), v216.m_GuidesColor (UnityEngine.Color), v216.m_GuidesColor.g (System.Single), v216.m_GuidesColor.b (System.Single), v216.m_GuidesColor.a (System.Single)\n\tv404 = UnityEngine.UI.Graphic::set_color(v188[v94 @ X24_v6 (System.Int32)], Color_arg);\n\tv94 = v94 + 1;\n\tv393 = v94 < v188.Length;\n\tif (v393) goto L_FFFFFFFF;\nL_00A3:\n\tgoto L_00A7;\nL_00A7:\n\tv298 = UnityEngine.Object::op_Inequality(this.m_GuideInstance, 0);\n\tv417 = ~v298;\n\tv303 = ~v417;\n\tif (v303) goto L_00B8;\n\tgoto L_0112;\nL_00B8:\n\tUnityEngine.GameObject::SetActive(this.m_GuideInstance, 1);\n\tv192 = UnityEngine.GameObject::GetComponent(this.m_GuideInstance);\n\tv220 = this.m_Config;\n\tgoto L_00D7;\nL_00D7:\n\tv193 = UnityEngine.Component::GetComponentsInChildren(v192);\n\tv267 = v193.Length < 1;\n\tif (v267) goto L_0112;\nL_FFFFFFFF:\n\tv228 = 0;\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v220.m_GuidesColor (UnityEngine.Color), v220.m_GuidesColor.g (System.Single), v220.m_GuidesColor.b (System.Single), v220.m_GuidesColor.a (System.Single)\n\tv295 = UnityEngine.UI.Graphic::set_color(v193[v228 @ X20_v10 (System.Int32)], Color_arg);\n\tv228 = v228 + 1;\n\tv266 = v228 < v193.Length;\n\tif (v266) goto L_FFFFFFFF;\nL_0112:\n\treturn;\nL_001F:\n\tv59 = this.m_Config;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ShowGuides()
		{
			ScreenshotConfig config = m_Config;
			if (!config.m_ShowGuidesInPreview || !(config.m_GuideCanvas != null))
			{
				return;
			}
			ScreenshotConfig config2 = m_Config;
			GameObject gameObject = config2.m_GuideCanvas.gameObject;
			gameObject.SetActive(value: true);
			ScreenshotConfig config3 = m_Config;
			config3.m_GuideCanvas.enabled = true;
			ScreenshotConfig config4 = m_Config;
			Image[] componentsInChildren = config4.m_GuideCanvas.GetComponentsInChildren<Image>();
			if (componentsInChildren.Length >= 1)
			{
				int num = 0;
				Color color = default(Color);
				do
				{
					color.r = config4.m_GuidesColor.r;
					color.g = config4.m_GuidesColor.g;
					color.b = config4.m_GuidesColor.b;
					color.a = config4.m_GuidesColor.a;
					componentsInChildren[num].color = color;
					num++;
				}
				while (num < componentsInChildren.Length);
			}
			if (!(m_GuideInstance != null))
			{
				return;
			}
			m_GuideInstance.SetActive(value: true);
			Canvas component = m_GuideInstance.GetComponent<Canvas>();
			ScreenshotConfig config5 = m_Config;
			Image[] componentsInChildren2 = component.GetComponentsInChildren<Image>();
			if (componentsInChildren2.Length >= 1)
			{
				int num2 = 0;
				Color color2 = default(Color);
				do
				{
					color2.r = config5.m_GuidesColor.r;
					color2.g = config5.m_GuidesColor.g;
					color2.b = config5.m_GuidesColor.b;
					color2.a = config5.m_GuidesColor.a;
					componentsInChildren2[num2].color = color2;
					num2++;
				}
				while (num2 < componentsInChildren2.Length);
			}
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x3C35DA4", Offset = "0x3C35DA4", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv59 = UnityEngine.Component::GetComponentsInChildren(canvas);\n\tv125 = v59.Length < 1;\n\tif (v125) goto L_005C;\n\tv104 = 0;\nL_0042:\n\tv196 = UnityEngine.UI.Graphic::set_color(v59[v104 @ X20_v6 (System.Int32)], Color_arg);\n\tv104 = v104 + 1;\n\tv186 = v104 < v59.Length;\n\tif (v186) goto L_0042;\nL_005C:\n\treturn;\n")]
		protected void SetColorRecursive(Canvas canvas, Color color)
		{
			Image[] componentsInChildren = canvas.GetComponentsInChildren<Image>();
			if (componentsInChildren.Length >= 1)
			{
				int num = 0;
				Color color2 = default(Color);
				do
				{
					componentsInChildren[num].color = color2;
					num++;
				}
				while (num < componentsInChildren.Length);
			}
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x3C35E78", Offset = "0x3C35E78", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv57 = v140.m_PreviewInGameViewWhilePlaying != 1;\n\tif (v57) goto L_0054;\n\tgoto L_002D;\nL_002D:\n\tv146 = UnityEngine.Application::get_isPlaying();\n\tv113 = this.m_Config;\n\tv204 = ~v146;\n\tv140 = this.m_Config;\n\tif (v204) goto L_0054;\n\tv126 = v113.m_ShowGuidesInPreview != 1;\n\tv140 = this.m_Config;\n\tif (v126) goto L_0054;\n\tv254 = this.m_IsCapturing == 0;\n\tv139 = ~v254;\n\tv140 = this.m_Config;\n\tif (v139) goto L_0054;\n\tgoto L_009F;\nL_0054:\n\tgoto L_0058;\nL_0058:\n\tv151 = UnityEngine.Object::op_Inequality(v140.m_GuideCanvas, 0);\n\tv207 = ~v151;\n\tv208 = ~v207;\n\tif (v208) goto L_007B;\n\tv235 = this.m_GuideInstance;\n\tgoto L_0063;\nL_0063:\n\tv243 = UnityEngine.Object::op_Inequality(v235, 0);\n\tv255 = ~v243;\n\tif (v255) goto L_009F;\n\tUnityEngine.GameObject::SetActive(this.m_GuideInstance, 0);\n\treturn;\nL_007B:\n\tv116 = this.m_Config;\n\tv104 = UnityEngine.Component::get_gameObject(v116.m_GuideCanvas);\n\tUnityEngine.GameObject::SetActive(v104, 0);\n\tv235 = this.m_GuideInstance;\n\tgoto L_0063;\nL_009F:\n\treturn;\nL_0017:\n\tv140 = this.m_Config;\n")]
		protected void HideGuides()
		{
			ScreenshotConfig config = m_Config;
			if (config.m_PreviewInGameViewWhilePlaying)
			{
				bool isPlaying = Application.isPlaying;
				ScreenshotConfig config2 = m_Config;
				bool flag = !isPlaying;
				config = m_Config;
				if (!flag)
				{
					bool flag2 = !config2.m_ShowGuidesInPreview;
					config = m_Config;
					if (!flag2)
					{
						bool flag3 = !m_IsCapturing;
						bool flag4 = !flag3;
						config = m_Config;
						if (!flag4)
						{
							return;
						}
					}
				}
			}
			UnityEngine.Object guideInstance;
			if (!(config.m_GuideCanvas != null))
			{
				guideInstance = m_GuideInstance;
			}
			else
			{
				ScreenshotConfig config3 = m_Config;
				GameObject gameObject = config3.m_GuideCanvas.gameObject;
				gameObject.SetActive(value: false);
				guideInstance = m_GuideInstance;
			}
			if (guideInstance != null)
			{
				m_GuideInstance.SetActive(value: false);
			}
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x3C36014", Offset = "0x3C36014", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tthis.m_PreviousFrameRate = -1;\n\tthis.m_CurrentBatchName = \"\";\n\tv88 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v88);\n\tthis.m_PreviewResolutions = v88;\n\tv98 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v98);\n\tthis.m_PreviewOverlayList = v98;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0034:\n\tv64 = new AlmostEngine.Screenshot.ScreenshotConfig();\n\tAlmostEngine.Screenshot.ScreenshotConfig::.ctor(v64);\n\tthis.m_Config = v64;\n")]
		public ScreenshotManager()
		{
			ScreenshotConfig config = new ScreenshotConfig();
			m_Config = config;
			m_PreviousFrameRate = -1;
			m_PreviousVSync = -1;
			m_CurrentBatchName = "";
			List<ScreenshotResolution> previewResolutions = new List<ScreenshotResolution>();
			m_PreviewResolutions = previewResolutions;
			List<ScreenshotOverlay> previewOverlayList = new List<ScreenshotOverlay>();
			m_PreviewOverlayList = previewOverlayList;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x3C3615C", Offset = "0x3C3615C", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0042;\n\tv105 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v105, v102.<>9, Il2CppMethodInfo);\n\tv117.onCaptureEndDelegate = v105;\n\tv127 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v127, v124.<>9, Il2CppMethodInfo);\n\tv132.onResolutionExportSuccessDelegate = v127;\n\tv140 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v140, v137.<>9, Il2CppMethodInfo);\n\tv145.onResolutionExportFailureDelegate = v140;\n\treturn;\nL_0042:\n\tgoto L_0048;\nL_0048:\n\tv83 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v83, v80.<>9, Il2CppMethodInfo);\n\tv95.onCaptureBeginDelegate = v83;\n")]
		static ScreenshotManager()
		{
			UnityAction unityAction = delegate
			{
			};
			onCaptureBeginDelegate = unityAction;
			UnityAction unityAction2 = delegate
			{
			};
			onCaptureEndDelegate = unityAction2;
			ExportDelegate exportDelegate = delegate
			{
			};
			onResolutionExportSuccessDelegate = exportDelegate;
			ExportDelegate exportDelegate2 = delegate
			{
			};
			onResolutionExportFailureDelegate = exportDelegate2;
		}
	}
}
