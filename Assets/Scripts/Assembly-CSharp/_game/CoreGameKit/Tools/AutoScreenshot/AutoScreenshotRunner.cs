using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AlmostEngine.Screenshot;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.Tracking.Tools.Logging;

namespace _game.CoreGameKit.Tools.AutoScreenshot
{
	[Token(Token = "0x20005C9")]
	public class AutoScreenshotRunner : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20005CA")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400140E")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400140F")]
			public static Func<ScreenshotResolutionEntry, bool> _003C_003E9__5_0;

			[Token(Token = "0x60018DF")]
			[Address(RVA = "0x3D419DC", Offset = "0x3D419DC", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60018E0")]
			[Address(RVA = "0x3D41A40", Offset = "0x3D41A40", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CCaptureWithDelayCoroutine_003Eb__5_0(ScreenshotResolutionEntry r)
			{
				if (r != null && r.Enabled && r.Width >= 1)
				{
					bool flag = r.Height < 0;
					bool flag2 = r.Height == 0;
					int num = r.Height ^ r.Height;
					int num2 = r.Height & num;
					bool flag3 = num2 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				}
				return false;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20005CB")]
		private sealed class _003CAutoAdvanceCoroutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001410")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001411")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001412")]
			[FieldOffset(Offset = "0x20")]
			public float delay;

			[Token(Token = "0x4001413")]
			[FieldOffset(Offset = "0x28")]
			public AutoScreenshotRunner _003C_003E4__this;

			[Token(Token = "0x4001414")]
			[FieldOffset(Offset = "0x30")]
			public Action advanceAction;

			[Token(Token = "0x17000258")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60018E5")]
				[Address(RVA = "0x3D41BB4", Offset = "0x3D41BB4", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000259")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60018E7")]
				[Address(RVA = "0x3D41BFC", Offset = "0x3D41BFC", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60018E2")]
			[Address(RVA = "0x3D419A8", Offset = "0x3D419A8", Length = "0x2C")]
			public _003CAutoAdvanceCoroutine_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60018E3")]
			[Address(RVA = "0x3D41A7C", Offset = "0x3D41A7C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60018E4")]
			[Address(RVA = "0x3D41A80", Offset = "0x3D41A80", Length = "0x134")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						AutoScreenshotRunner autoScreenshotRunner = _003C_003E4__this;
						_003C_003E1__state = -1;
						if (autoScreenshotRunner._logger != null)
						{
							autoScreenshotRunner._logger.Log("[AutoScreenshot] Auto-advancing to next level", "AutoAdvanceCoroutine", "/Users/macmini/wkspaces/Unity/sout/Assets/_game/CoreGameKit/Tools/AutoScreenshot/AutoScreenshotRunner.cs", 145);
						}
						if (advanceAction != null)
						{
							advanceAction();
						}
					}
				}
				else
				{
					_003C_003E1__state = -1;
					WaitForSeconds waitForSeconds = new WaitForSeconds(delay);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
				}
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60018E6")]
			[Address(RVA = "0x3D41BBC", Offset = "0x3D41BBC", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20005CC")]
		private sealed class _003CCaptureWithDelayCoroutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001415")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001416")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001417")]
			[FieldOffset(Offset = "0x20")]
			public float delay;

			[Token(Token = "0x4001418")]
			[FieldOffset(Offset = "0x28")]
			public IReadOnlyList<ScreenshotResolutionEntry> resolutions;

			[Token(Token = "0x4001419")]
			[FieldOffset(Offset = "0x30")]
			public string fileNameWithoutExtension;

			[Token(Token = "0x400141A")]
			[FieldOffset(Offset = "0x38")]
			public AutoScreenshotRunner _003C_003E4__this;

			[Token(Token = "0x400141B")]
			[FieldOffset(Offset = "0x40")]
			public Action onCaptured;

			[Token(Token = "0x400141C")]
			[FieldOffset(Offset = "0x48")]
			private string _003CoutputDir_003E5__2;

			[Token(Token = "0x400141D")]
			[FieldOffset(Offset = "0x50")]
			private bool _003CcanUseGameViewResizing_003E5__3;

			[Token(Token = "0x400141E")]
			[FieldOffset(Offset = "0x54")]
			private int _003CoriginalWidth_003E5__4;

			[Token(Token = "0x400141F")]
			[FieldOffset(Offset = "0x58")]
			private int _003CoriginalHeight_003E5__5;

			[Token(Token = "0x4001420")]
			[FieldOffset(Offset = "0x5C")]
			private FullScreenMode _003CoriginalMode_003E5__6;

			[Token(Token = "0x4001421")]
			[FieldOffset(Offset = "0x60")]
			private List<ScreenshotResolutionEntry>.Enumerator _003C_003E7__wrap6;

			[Token(Token = "0x4001422")]
			[FieldOffset(Offset = "0x78")]
			private ScreenshotResolutionEntry _003Cresolution_003E5__8;

			[Token(Token = "0x4001423")]
			[FieldOffset(Offset = "0x80")]
			private string _003CfullPath_003E5__9;

			[Token(Token = "0x1700025A")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60018EC")]
				[Address(RVA = "0x3D4296C", Offset = "0x3D4296C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700025B")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60018EE")]
				[Address(RVA = "0x3D429B4", Offset = "0x3D429B4", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60018E8")]
			[Address(RVA = "0x3D4197C", Offset = "0x3D4197C", Length = "0x2C")]
			public _003CCaptureWithDelayCoroutine_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60018E9")]
			[Address(RVA = "0x3D41C04", Offset = "0x3D41C04", Length = "0x74")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotRunner._003CCaptureWithDelayCoroutine_003Ed__5::Dispose");
			}

			[Token(Token = "0x60018EA")]
			[Address(RVA = "0x3D41C78", Offset = "0x3D41C78", Length = "0xC98")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotRunner._003CCaptureWithDelayCoroutine_003Ed__5::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x60018EB")]
			[Address(RVA = "0x3D42910", Offset = "0x3D42910", Length = "0x5C")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AutoScreenshotRunner._003CCaptureWithDelayCoroutine_003Ed__5::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x60018ED")]
			[Address(RVA = "0x3D42974", Offset = "0x3D42974", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400140C")]
		[FieldOffset(Offset = "0x20")]
		private Coroutine _captureCoroutine;

		[Token(Token = "0x400140D")]
		[FieldOffset(Offset = "0x28")]
		internal ULogger _logger;

		[Token(Token = "0x60018D9")]
		[Address(RVA = "0x3D416D4", Offset = "0x3D416D4", Length = "0x8")]
		public void SetLogger(ULogger logger)
		{
			_logger = logger;
		}

		[Token(Token = "0x60018DA")]
		[Address(RVA = "0x3D416DC", Offset = "0x3D416DC", Length = "0x94")]
		public void CaptureScreenshots(float delay, string fileNameWithoutExtension, IReadOnlyList<ScreenshotResolutionEntry> resolutions, Action onCaptured)
		{
			if (_captureCoroutine != null)
			{
				StopCoroutine(_captureCoroutine);
			}
			float delay2 = default(float);
			string fileNameWithoutExtension2 = default(string);
			IReadOnlyList<ScreenshotResolutionEntry> resolutions2 = default(IReadOnlyList<ScreenshotResolutionEntry>);
			Action onCaptured2 = default(Action);
			IEnumerator routine = CaptureWithDelayCoroutine(delay2, fileNameWithoutExtension2, resolutions2, onCaptured2);
			Coroutine captureCoroutine = StartCoroutine(routine);
			_captureCoroutine = captureCoroutine;
		}

		[Token(Token = "0x60018DB")]
		[Address(RVA = "0x3D4183C", Offset = "0x3D4183C", Length = "0xA4")]
		public void ScheduleAutoAdvance(float delay, Action advanceAction)
		{
			_003CAutoAdvanceCoroutine_003Ed__6 _003CAutoAdvanceCoroutine_003Ed__7 = (_003CAutoAdvanceCoroutine_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CAutoAdvanceCoroutine_003Ed__6));
			_003CAutoAdvanceCoroutine_003Ed__7._003C_003E1__state = 0;
			_003CAutoAdvanceCoroutine_003Ed__7._003C_003E4__this = this;
			_003CAutoAdvanceCoroutine_003Ed__7.delay = delay;
			_003CAutoAdvanceCoroutine_003Ed__7.advanceAction = advanceAction;
			Coroutine coroutine = StartCoroutine(_003CAutoAdvanceCoroutine_003Ed__7);
		}

		[IteratorStateMachine(typeof(_003CCaptureWithDelayCoroutine_003Ed__5))]
		[Token(Token = "0x60018DC")]
		[Address(RVA = "0x3D41770", Offset = "0x3D41770", Length = "0xCC")]
		internal IEnumerator CaptureWithDelayCoroutine(float delay, string fileNameWithoutExtension, IReadOnlyList<ScreenshotResolutionEntry> resolutions, Action onCaptured)
		{
			_003CCaptureWithDelayCoroutine_003Ed__5 _003CCaptureWithDelayCoroutine_003Ed__6 = (_003CCaptureWithDelayCoroutine_003Ed__5)FormatterServices.GetUninitializedObject(typeof(_003CCaptureWithDelayCoroutine_003Ed__5));
			_003CCaptureWithDelayCoroutine_003Ed__6._003C_003E1__state = 0;
			_003CCaptureWithDelayCoroutine_003Ed__6._003C_003E4__this = this;
			_003CCaptureWithDelayCoroutine_003Ed__6.delay = delay;
			_003CCaptureWithDelayCoroutine_003Ed__6.fileNameWithoutExtension = fileNameWithoutExtension;
			_003CCaptureWithDelayCoroutine_003Ed__6.resolutions = resolutions;
			_003CCaptureWithDelayCoroutine_003Ed__6.onCaptured = onCaptured;
			return _003CCaptureWithDelayCoroutine_003Ed__6;
		}

		[IteratorStateMachine(typeof(_003CAutoAdvanceCoroutine_003Ed__6))]
		[Token(Token = "0x60018DD")]
		[Address(RVA = "0x3D418E0", Offset = "0x3D418E0", Length = "0x9C")]
		private IEnumerator AutoAdvanceCoroutine(float delay, Action advanceAction)
		{
			_003CAutoAdvanceCoroutine_003Ed__6 _003CAutoAdvanceCoroutine_003Ed__7 = (_003CAutoAdvanceCoroutine_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CAutoAdvanceCoroutine_003Ed__6));
			_003CAutoAdvanceCoroutine_003Ed__7._003C_003E1__state = 0;
			_003CAutoAdvanceCoroutine_003Ed__7._003C_003E4__this = this;
			_003CAutoAdvanceCoroutine_003Ed__7.delay = delay;
			_003CAutoAdvanceCoroutine_003Ed__7.advanceAction = advanceAction;
			return _003CAutoAdvanceCoroutine_003Ed__7;
		}

		[Token(Token = "0x60018DE")]
		[Address(RVA = "0x3D419D4", Offset = "0x3D419D4", Length = "0x8")]
		public AutoScreenshotRunner()
		{
		}
	}
}
