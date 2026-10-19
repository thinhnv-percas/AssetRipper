using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AlmostEngine.Screenshot;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.Tracking.Tools.Logging;
using _game.CoreGameKit.Ui.UiControllers;

namespace _game.CoreGameKit.Tools.LevelScreenshot
{
	[Token(Token = "0x20005A6")]
	public class LevelScreenshotRunner : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x20005A7")]
		private sealed class _003CCaptureCoroutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001360")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001361")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001362")]
			[FieldOffset(Offset = "0x20")]
			public LevelCaptureRequest request;

			[Token(Token = "0x4001363")]
			[FieldOffset(Offset = "0x40")]
			public LevelScreenshotRunner _003C_003E4__this;

			[Token(Token = "0x1700022E")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001810")]
				[Address(RVA = "0x3D31DF0", Offset = "0x3D31DF0", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700022F")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001812")]
				[Address(RVA = "0x3D31E38", Offset = "0x3D31E38", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600180D")]
			[Address(RVA = "0x3D311B0", Offset = "0x3D311B0", Length = "0x2C")]
			public _003CCaptureCoroutine_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600180E")]
			[Address(RVA = "0x3D319F4", Offset = "0x3D319F4", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600180F")]
			[Address(RVA = "0x3D319F8", Offset = "0x3D319F8", Length = "0x3F8")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotRunner._003CCaptureCoroutine_003Ed__8::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001811")]
			[Address(RVA = "0x3D31DF8", Offset = "0x3D31DF8", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20005A8")]
		private sealed class _003CWaitCoroutine_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001364")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001365")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001366")]
			[FieldOffset(Offset = "0x20")]
			public float seconds;

			[Token(Token = "0x4001367")]
			[FieldOffset(Offset = "0x28")]
			public Action onDone;

			[Token(Token = "0x17000230")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001816")]
				[Address(RVA = "0x3D31F4C", Offset = "0x3D31F4C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000231")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001818")]
				[Address(RVA = "0x3D31F94", Offset = "0x3D31F94", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001813")]
			[Address(RVA = "0x3D31158", Offset = "0x3D31158", Length = "0x2C")]
			public _003CWaitCoroutine_003Ed__6(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6001814")]
			[Address(RVA = "0x3D31E40", Offset = "0x3D31E40", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6001815")]
			[Address(RVA = "0x3D31E44", Offset = "0x3D31E44", Length = "0x108")]
			private bool MoveNext()
			{
				int num = _003C_003E1__state - 1;
				if ((uint)num < 2u)
				{
					_003C_003E1__state = -1;
					if (onDone != null)
					{
						onDone();
					}
				}
				else if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
					bool flag = seconds < 0f;
					bool flag2 = seconds == 0f;
					bool flag3 = seconds == seconds;
					bool flag4 = !flag3;
					bool flag5 = flag == flag4;
					bool flag6 = !flag5;
					if (!(flag6 || flag2))
					{
						WaitForSeconds waitForSeconds = new WaitForSeconds(seconds);
						_003C_003E2__current = waitForSeconds;
						_003C_003E1__state = 1;
						return true;
					}
					_003C_003E2__current = null;
					_003C_003E1__state = 2;
					return true;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6001817")]
			[Address(RVA = "0x3D31F54", Offset = "0x3D31F54", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20005A9")]
		private sealed class _003CWaitFrameCoroutine_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001368")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001369")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400136A")]
			[FieldOffset(Offset = "0x20")]
			public Action onDone;

			[Token(Token = "0x17000232")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600181C")]
				[Address(RVA = "0x3D32024", Offset = "0x3D32024", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000233")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600181E")]
				[Address(RVA = "0x3D3206C", Offset = "0x3D3206C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6001819")]
			[Address(RVA = "0x3D31184", Offset = "0x3D31184", Length = "0x2C")]
			public _003CWaitFrameCoroutine_003Ed__7(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600181A")]
			[Address(RVA = "0x3D31F9C", Offset = "0x3D31F9C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600181B")]
			[Address(RVA = "0x3D31FA0", Offset = "0x3D31FA0", Length = "0x84")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotRunner._003CWaitFrameCoroutine_003Ed__7::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600181D")]
			[Address(RVA = "0x3D3202C", Offset = "0x3D3202C", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x400135E")]
		[FieldOffset(Offset = "0x20")]
		internal ULogger _logger;

		[Token(Token = "0x400135F")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<Canvas> _temporarilyDisabledCanvases;

		[Token(Token = "0x6001801")]
		[Address(RVA = "0x3D30E04", Offset = "0x3D30E04", Length = "0x8")]
		public void SetLogger(ULogger logger)
		{
			_logger = logger;
		}

		[Token(Token = "0x6001802")]
		[Address(RVA = "0x3D30E0C", Offset = "0x3D30E0C", Length = "0xA4")]
		public Coroutine RunCapture(LevelCaptureRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotRunner::RunCapture");
			return default;
		}

		[Token(Token = "0x6001803")]
		[Address(RVA = "0x3D30F40", Offset = "0x3D30F40", Length = "0x94")]
		public Coroutine Wait(float seconds, Action onDone)
		{
			_003CWaitCoroutine_003Ed__6 _003CWaitCoroutine_003Ed__7 = (_003CWaitCoroutine_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CWaitCoroutine_003Ed__6));
			_003CWaitCoroutine_003Ed__7._003C_003E1__state = 0;
			_003CWaitCoroutine_003Ed__7.seconds = seconds;
			_003CWaitCoroutine_003Ed__7.onDone = onDone;
			return StartCoroutine(_003CWaitCoroutine_003Ed__7);
		}

		[Token(Token = "0x6001804")]
		[Address(RVA = "0x3D3105C", Offset = "0x3D3105C", Length = "0x84")]
		public Coroutine WaitOneFrame(Action onDone)
		{
			_003CWaitFrameCoroutine_003Ed__7 _003CWaitFrameCoroutine_003Ed__8 = (_003CWaitFrameCoroutine_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CWaitFrameCoroutine_003Ed__7));
			_003CWaitFrameCoroutine_003Ed__8._003C_003E1__state = 0;
			_003CWaitFrameCoroutine_003Ed__8.onDone = onDone;
			return StartCoroutine(_003CWaitFrameCoroutine_003Ed__8);
		}

		[IteratorStateMachine(typeof(_003CWaitCoroutine_003Ed__6))]
		[Token(Token = "0x6001805")]
		[Address(RVA = "0x3D30FD4", Offset = "0x3D30FD4", Length = "0x88")]
		private IEnumerator WaitCoroutine(float seconds, Action onDone)
		{
			_003CWaitCoroutine_003Ed__6 _003CWaitCoroutine_003Ed__7 = (_003CWaitCoroutine_003Ed__6)FormatterServices.GetUninitializedObject(typeof(_003CWaitCoroutine_003Ed__6));
			_003CWaitCoroutine_003Ed__7._003C_003E1__state = 0;
			_003CWaitCoroutine_003Ed__7.seconds = seconds;
			_003CWaitCoroutine_003Ed__7.onDone = onDone;
			return _003CWaitCoroutine_003Ed__7;
		}

		[IteratorStateMachine(typeof(_003CWaitFrameCoroutine_003Ed__7))]
		[Token(Token = "0x6001806")]
		[Address(RVA = "0x3D310E0", Offset = "0x3D310E0", Length = "0x78")]
		private IEnumerator WaitFrameCoroutine(Action onDone)
		{
			_003CWaitFrameCoroutine_003Ed__7 _003CWaitFrameCoroutine_003Ed__8 = (_003CWaitFrameCoroutine_003Ed__7)FormatterServices.GetUninitializedObject(typeof(_003CWaitFrameCoroutine_003Ed__7));
			_003CWaitFrameCoroutine_003Ed__8._003C_003E1__state = 0;
			_003CWaitFrameCoroutine_003Ed__8.onDone = onDone;
			return _003CWaitFrameCoroutine_003Ed__8;
		}

		[IteratorStateMachine(typeof(_003CCaptureCoroutine_003Ed__8))]
		[Token(Token = "0x6001807")]
		[Address(RVA = "0x3D30EB0", Offset = "0x3D30EB0", Length = "0x90")]
		private IEnumerator CaptureCoroutine(LevelCaptureRequest request)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotRunner::CaptureCoroutine");
			return default;
		}

		[Token(Token = "0x6001808")]
		[Address(RVA = "0x3D311DC", Offset = "0x3D311DC", Length = "0x70")]
		private void HideNonHudCanvases()
		{
			List<Canvas> temporarilyDisabledCanvases = _temporarilyDisabledCanvases;
			temporarilyDisabledCanvases.Clear();
			if (temporarilyDisabledCanvases.Count >= 1)
			{
			}
			SweepHideNonHudCanvases();
		}

		[Token(Token = "0x6001809")]
		[Address(RVA = "0x3D3124C", Offset = "0x3D3124C", Length = "0x248")]
		private void SweepHideNonHudCanvases()
		{
			HashSet<Canvas> hashSet = CollectHudCanvases();
			Canvas[] array = UnityEngine.Object.FindObjectsByType<Canvas>(FindObjectsInactive.Include, default(FindObjectsSortMode));
			if (hashSet != null)
			{
				if (array.Length < 1)
				{
					return;
				}
				int num = 0;
				do
				{
					if (!(array[num] == null) && array[num].enabled && !hashSet.Contains(array[num]))
					{
						array[num].enabled = false;
						List<Canvas> temporarilyDisabledCanvases = _temporarilyDisabledCanvases;
						temporarilyDisabledCanvases.Add(array[num]);
					}
					num++;
				}
				while (num < array.Length);
			}
			else
			{
				if (array.Length < 1)
				{
					return;
				}
				int num2 = 0;
				do
				{
					if (array[num2] == null || !array[num2].enabled)
					{
						num2++;
						continue;
					}
					throw new NullReferenceException();
				}
				while (num2 < array.Length);
			}
		}

		[Token(Token = "0x600180A")]
		[Address(RVA = "0x3D31494", Offset = "0x3D31494", Length = "0x30C")]
		private static HashSet<Canvas> CollectHudCanvases()
		{
			HashSet<Canvas> hashSet = new HashSet<Canvas>();
			BaseLayerTopBarUiController[] array = UnityEngine.Object.FindObjectsByType<BaseLayerTopBarUiController>(FindObjectsInactive.Include, default(FindObjectsSortMode));
			if (array.Length >= 1)
			{
				int num = 0;
				BaseLayerTopBarUiController[] array2 = array;
				do
				{
					if (!(array[num] == null))
					{
						Canvas[] componentsInParent = array[num].GetComponentsInParent<Canvas>(includeInactive: true);
						if (componentsInParent.Length >= 1)
						{
							if (hashSet != null)
							{
								int num2 = 0;
								do
								{
									if (componentsInParent[num2] != null)
									{
										bool flag = hashSet.Add(componentsInParent[num2]);
									}
									num2++;
								}
								while (num2 < componentsInParent.Length);
							}
							else
							{
								int num3 = 0;
								do
								{
									bool flag2 = componentsInParent[num3] != null;
									num3++;
								}
								while (num3 < componentsInParent.Length);
							}
						}
						Canvas[] componentsInChildren = array[num].GetComponentsInChildren<Canvas>(includeInactive: true);
						bool flag3 = componentsInChildren.Length < 1;
						array2 = array;
						if (!flag3)
						{
							int num4 = 0;
							bool flag5;
							do
							{
								if (componentsInChildren[num4] != null)
								{
									bool flag4 = hashSet.Add(componentsInChildren[num4]);
								}
								num4++;
								flag5 = num4 >= componentsInChildren.Length;
								array2 = array;
							}
							while (!flag5);
						}
					}
					num++;
				}
				while (num < array2.Length);
			}
			return hashSet;
		}

		[Token(Token = "0x600180B")]
		[Address(RVA = "0x3D317A0", Offset = "0x3D317A0", Length = "0x1C8")]
		private unsafe void RestoreCanvases()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelScreenshotRunner::RestoreCanvases");
		}

		[Token(Token = "0x600180C")]
		[Address(RVA = "0x3D31968", Offset = "0x3D31968", Length = "0x8C")]
		public LevelScreenshotRunner()
		{
			List<Canvas> temporarilyDisabledCanvases = new List<Canvas>();
			_temporarilyDisabledCanvases = temporarilyDisabledCanvases;
		}
	}
}
