using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using Cpp2ILInjected;
using Unco.GameBootstrap.Config;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007D6")]
	public class SceneFlow : ILoadTask
	{
		[Token(Token = "0x20007D7")]
		protected internal class SceneFlowRunner : MonoBehaviour
		{
			[Token(Token = "0x600212D")]
			[Address(RVA = "0x3DC2924", Offset = "0x3DC2924", Length = "0x8")]
			public SceneFlowRunner()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20007D8")]
		private sealed class _003CExecuteFlow_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001A36")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001A37")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001A38")]
			[FieldOffset(Offset = "0x20")]
			public SceneFlow _003C_003E4__this;

			[Token(Token = "0x17000337")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002131")]
				[Address(RVA = "0x3DC2C90", Offset = "0x3DC2C90", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000338")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002133")]
				[Address(RVA = "0x3DC2CD8", Offset = "0x3DC2CD8", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600212E")]
			[Address(RVA = "0x3DC26A4", Offset = "0x3DC26A4", Length = "0x2C")]
			public _003CExecuteFlow_003Ed__22(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600212F")]
			[Address(RVA = "0x3DC292C", Offset = "0x3DC292C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6002130")]
			[Address(RVA = "0x3DC2930", Offset = "0x3DC2930", Length = "0x2D4")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow._003CExecuteFlow_003Ed__22::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002132")]
			[Address(RVA = "0x3DC2C98", Offset = "0x3DC2C98", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20007D9")]
		private sealed class _003CFlowIntroAndMain_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001A39")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001A3A")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001A3B")]
			[FieldOffset(Offset = "0x20")]
			public SceneConfig mainConfig;

			[Token(Token = "0x4001A3C")]
			[FieldOffset(Offset = "0x28")]
			public SceneConfig introConfig;

			[Token(Token = "0x4001A3D")]
			[FieldOffset(Offset = "0x30")]
			public SceneFlow _003C_003E4__this;

			[Token(Token = "0x4001A3E")]
			[FieldOffset(Offset = "0x38")]
			private string _003CintroSceneName_003E5__2;

			[Token(Token = "0x4001A3F")]
			[FieldOffset(Offset = "0x40")]
			private string _003CmainSceneName_003E5__3;

			[Token(Token = "0x4001A40")]
			[FieldOffset(Offset = "0x48")]
			private AsyncOperation _003CmainLoadOp_003E5__4;

			[Token(Token = "0x4001A41")]
			[FieldOffset(Offset = "0x50")]
			private float _003CstartTime_003E5__5;

			[Token(Token = "0x4001A42")]
			[FieldOffset(Offset = "0x54")]
			private float _003Cdisplayed_003E5__6;

			[Token(Token = "0x4001A43")]
			[FieldOffset(Offset = "0x58")]
			private float _003CextraWaitStartTime_003E5__7;

			[Token(Token = "0x4001A44")]
			[FieldOffset(Offset = "0x60")]
			private AsyncOperation _003CintroLoadOp_003E5__8;

			[Token(Token = "0x17000339")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002137")]
				[Address(RVA = "0x3DC3490", Offset = "0x3DC3490", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700033A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002139")]
				[Address(RVA = "0x3DC34D8", Offset = "0x3DC34D8", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6002134")]
			[Address(RVA = "0x3DC2830", Offset = "0x3DC2830", Length = "0x2C")]
			public _003CFlowIntroAndMain_003Ed__24(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6002135")]
			[Address(RVA = "0x3DC2CE0", Offset = "0x3DC2CE0", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6002136")]
			[Address(RVA = "0x3DC2CE4", Offset = "0x3DC2CE4", Length = "0x7AC")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow._003CFlowIntroAndMain_003Ed__24::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002138")]
			[Address(RVA = "0x3DC3498", Offset = "0x3DC3498", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20007DA")]
		private sealed class _003CFlowSingleScene_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001A45")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001A46")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001A47")]
			[FieldOffset(Offset = "0x20")]
			public SceneConfig sceneConfig;

			[Token(Token = "0x4001A48")]
			[FieldOffset(Offset = "0x28")]
			public SceneFlow _003C_003E4__this;

			[Token(Token = "0x4001A49")]
			[FieldOffset(Offset = "0x30")]
			private AsyncOperation _003CloadOp_003E5__2;

			[Token(Token = "0x4001A4A")]
			[FieldOffset(Offset = "0x38")]
			private float _003CstartTime_003E5__3;

			[Token(Token = "0x4001A4B")]
			[FieldOffset(Offset = "0x3C")]
			private float _003Cdisplayed_003E5__4;

			[Token(Token = "0x1700033B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600213D")]
				[Address(RVA = "0x3DC38EC", Offset = "0x3DC38EC", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700033C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600213F")]
				[Address(RVA = "0x3DC3934", Offset = "0x3DC3934", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600213A")]
			[Address(RVA = "0x3DC275C", Offset = "0x3DC275C", Length = "0x2C")]
			public _003CFlowSingleScene_003Ed__23(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600213B")]
			[Address(RVA = "0x3DC34E0", Offset = "0x3DC34E0", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600213C")]
			[Address(RVA = "0x3DC34E4", Offset = "0x3DC34E4", Length = "0x408")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow._003CFlowSingleScene_003Ed__23::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600213E")]
			[Address(RVA = "0x3DC38F4", Offset = "0x3DC38F4", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20007DB")]
		private sealed class _003CSmoothFillProgress_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4001A4C")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4001A4D")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4001A4E")]
			[FieldOffset(Offset = "0x20")]
			public SceneFlow _003C_003E4__this;

			[Token(Token = "0x4001A4F")]
			[FieldOffset(Offset = "0x28")]
			public float from;

			[Token(Token = "0x4001A50")]
			[FieldOffset(Offset = "0x2C")]
			public float to;

			[Token(Token = "0x4001A51")]
			[FieldOffset(Offset = "0x30")]
			public float duration;

			[Token(Token = "0x4001A52")]
			[FieldOffset(Offset = "0x34")]
			private float _003Ct_003E5__2;

			[Token(Token = "0x1700033D")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002143")]
				[Address(RVA = "0x3DC3A8C", Offset = "0x3DC3A8C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700033E")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6002145")]
				[Address(RVA = "0x3DC3AD4", Offset = "0x3DC3AD4", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6002140")]
			[Address(RVA = "0x3DC28F8", Offset = "0x3DC28F8", Length = "0x2C")]
			public _003CSmoothFillProgress_003Ed__25(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6002141")]
			[Address(RVA = "0x3DC393C", Offset = "0x3DC393C", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6002142")]
			[Address(RVA = "0x3DC3940", Offset = "0x3DC3940", Length = "0x14C")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow._003CSmoothFillProgress_003Ed__25::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6002144")]
			[Address(RVA = "0x3DC3A94", Offset = "0x3DC3A94", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4001A2C")]
		[FieldOffset(Offset = "0x10")]
		private readonly InstallOrchestrator _installOrchestrator;

		[Token(Token = "0x4001A2D")]
		[FieldOffset(Offset = "0x18")]
		private readonly GameModeConfig _config;

		[Token(Token = "0x4001A2E")]
		[FieldOffset(Offset = "0x20")]
		private readonly MonoBehaviour _coroutineRunner;

		[Token(Token = "0x4001A2F")]
		[FieldOffset(Offset = "0x28")]
		private float _progress;

		[Token(Token = "0x4001A30")]
		[FieldOffset(Offset = "0x2C")]
		private bool _isComplete;

		[Token(Token = "0x4001A31")]
		private const float MinLoadingTime = 0.8f;

		[Token(Token = "0x4001A32")]
		private const float FinalFillTime = 0.15f;

		[Token(Token = "0x4001A33")]
		private const float ExtraIntroDisplayTime = 1.5f;

		[CompilerGenerated]
		[Token(Token = "0x4001A34")]
		[FieldOffset(Offset = "0x30")]
		private Action<float> _003COnProgressChanged_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4001A35")]
		[FieldOffset(Offset = "0x38")]
		private Action _003COnComplete_003Ek__BackingField;

		[Token(Token = "0x17000335")]
		public float Progress
		{
			[Token(Token = "0x600211F")]
			[Address(RVA = "0x3DC2300", Offset = "0x3DC2300", Length = "0x8")]
			get
			{
				return _progress;
			}
			[Token(Token = "0x6002120")]
			[Address(RVA = "0x3DC2308", Offset = "0x3DC2308", Length = "0x38")]
			private set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow::set_Progress");
			}
		}

		[Token(Token = "0x17000336")]
		public bool IsComplete
		{
			[Token(Token = "0x6002121")]
			[Address(RVA = "0x3DC2340", Offset = "0x3DC2340", Length = "0x8")]
			get
			{
				return _isComplete;
			}
			[Token(Token = "0x6002122")]
			[Address(RVA = "0x3DC2348", Offset = "0x3DC2348", Length = "0x34")]
			private set
			{
				//IL_000f: Expected O, but got I4
				object obj = (IsComplete ? 1 : 0) - (value ? 1 : 0);
				if (obj != null && value)
				{
					_isComplete = true;
					if (_003COnComplete_003Ek__BackingField != null)
					{
						_003COnComplete_003Ek__BackingField();
					}
				}
			}
		}

		[Token(Token = "0x14000032")]
		public event Action<float> OnProgressChanged
		{
			[CompilerGenerated]
			[Token(Token = "0x6002123")]
			[Address(RVA = "0x3DC237C", Offset = "0x3DC237C", Length = "0xB4")]
			add
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow::add_OnProgressChanged");
			}
			[CompilerGenerated]
			[Token(Token = "0x6002124")]
			[Address(RVA = "0x3DC2430", Offset = "0x3DC2430", Length = "0xB4")]
			remove
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow::remove_OnProgressChanged");
			}
		}

		[Token(Token = "0x14000033")]
		public event Action OnComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x6002125")]
			[Address(RVA = "0x3DC24E4", Offset = "0x3DC24E4", Length = "0xA4")]
			add
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
			[CompilerGenerated]
			[Token(Token = "0x6002126")]
			[Address(RVA = "0x3DC2588", Offset = "0x3DC2588", Length = "0xA4")]
			remove
			{
				Action action = _003COnComplete_003Ek__BackingField;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Remove(action2, value);
					action = Interlocked.CompareExchange(ref _003COnComplete_003Ek__BackingField, value2, action2);
				}
				while ((object)action != action2);
			}
		}

		[Token(Token = "0x6002127")]
		[Address(RVA = "0x3DBF180", Offset = "0x3DBF180", Length = "0x140")]
		public SceneFlow(InstallOrchestrator installOrchestrator, GameModeConfig config)
		{
			_installOrchestrator = installOrchestrator;
			_config = config;
			_coroutineRunner = new GameObject("SceneFlowRunner").AddComponent<SceneFlowRunner>();
			UnityEngine.Object.DontDestroyOnLoad(_coroutineRunner.gameObject);
			_progress = 0f;
			_isComplete = false;
		}

		[Token(Token = "0x6002128")]
		[Address(RVA = "0x3DBF2C0", Offset = "0x3DBF2C0", Length = "0xB0")]
		public void StartFlow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SceneFlow::StartFlow");
		}

		[IteratorStateMachine(typeof(_003CExecuteFlow_003Ed__22))]
		[Token(Token = "0x6002129")]
		[Address(RVA = "0x3DC262C", Offset = "0x3DC262C", Length = "0x78")]
		private IEnumerator ExecuteFlow()
		{
			_003CExecuteFlow_003Ed__22 _003CExecuteFlow_003Ed__23 = (_003CExecuteFlow_003Ed__22)FormatterServices.GetUninitializedObject(typeof(_003CExecuteFlow_003Ed__22));
			_003CExecuteFlow_003Ed__23._003C_003E1__state = 0;
			_003CExecuteFlow_003Ed__23._003C_003E4__this = this;
			return _003CExecuteFlow_003Ed__23;
		}

		[IteratorStateMachine(typeof(_003CFlowSingleScene_003Ed__23))]
		[Token(Token = "0x600212A")]
		[Address(RVA = "0x3DC26D0", Offset = "0x3DC26D0", Length = "0x8C")]
		private IEnumerator FlowSingleScene(SceneConfig sceneConfig)
		{
			_003CFlowSingleScene_003Ed__23 _003CFlowSingleScene_003Ed__24 = (_003CFlowSingleScene_003Ed__23)FormatterServices.GetUninitializedObject(typeof(_003CFlowSingleScene_003Ed__23));
			_003CFlowSingleScene_003Ed__24._003C_003E1__state = 0;
			_003CFlowSingleScene_003Ed__24._003C_003E4__this = this;
			_003CFlowSingleScene_003Ed__24.sceneConfig = sceneConfig;
			return _003CFlowSingleScene_003Ed__24;
		}

		[IteratorStateMachine(typeof(_003CFlowIntroAndMain_003Ed__24))]
		[Token(Token = "0x600212B")]
		[Address(RVA = "0x3DC2788", Offset = "0x3DC2788", Length = "0xA8")]
		private IEnumerator FlowIntroAndMain(SceneConfig introConfig, SceneConfig mainConfig)
		{
			_003CFlowIntroAndMain_003Ed__24 _003CFlowIntroAndMain_003Ed__25 = (_003CFlowIntroAndMain_003Ed__24)FormatterServices.GetUninitializedObject(typeof(_003CFlowIntroAndMain_003Ed__24));
			_003CFlowIntroAndMain_003Ed__25._003C_003E1__state = 0;
			_003CFlowIntroAndMain_003Ed__25._003C_003E4__this = this;
			_003CFlowIntroAndMain_003Ed__25.introConfig = introConfig;
			_003CFlowIntroAndMain_003Ed__25.mainConfig = mainConfig;
			return _003CFlowIntroAndMain_003Ed__25;
		}

		[IteratorStateMachine(typeof(_003CSmoothFillProgress_003Ed__25))]
		[Token(Token = "0x600212C")]
		[Address(RVA = "0x3DC285C", Offset = "0x3DC285C", Length = "0x9C")]
		private IEnumerator SmoothFillProgress(float from, float to, float duration)
		{
			_003CSmoothFillProgress_003Ed__25 _003CSmoothFillProgress_003Ed__26 = (_003CSmoothFillProgress_003Ed__25)FormatterServices.GetUninitializedObject(typeof(_003CSmoothFillProgress_003Ed__25));
			_003CSmoothFillProgress_003Ed__26._003C_003E1__state = 0;
			_003CSmoothFillProgress_003Ed__26._003C_003E4__this = this;
			_003CSmoothFillProgress_003Ed__26.from = from;
			_003CSmoothFillProgress_003Ed__26.to = to;
			_003CSmoothFillProgress_003Ed__26.duration = duration;
			return _003CSmoothFillProgress_003Ed__26;
		}
	}
}
