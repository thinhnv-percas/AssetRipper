using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace _game.CoreSystem.CameraControl
{
	[Token(Token = "0x2000527")]
	public class CameraFlowRunner
	{
		[Token(Token = "0x2000528")]
		private class EventBinding
		{
			[Token(Token = "0x4001167")]
			[FieldOffset(Offset = "0x10")]
			private readonly Delegate _handler;

			[Token(Token = "0x4001168")]
			[FieldOffset(Offset = "0x18")]
			private readonly MethodInfo _removeMethod;

			[Token(Token = "0x6001586")]
			[Address(RVA = "0x3D12F38", Offset = "0x3D12F38", Length = "0x50")]
			private EventBinding(Delegate handler, MethodInfo removeMethod)
			{
				_handler = handler;
				_removeMethod = removeMethod;
			}

			[Token(Token = "0x6001587")]
			[Address(RVA = "0x3D12508", Offset = "0x3D12508", Length = "0x294")]
			public static EventBinding Create(CameraFlowStep step, Type eventType, CameraFlowRunner runner, EventBus eventBus)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CameraFlowRunner.EventBinding::Create");
				return default;
			}

			[Token(Token = "0x6001588")]
			[Address(RVA = "0x3D1279C", Offset = "0x3D1279C", Length = "0xDC")]
			public void Unsubscribe(EventBus eventBus)
			{
				if ((object)_handler == null)
				{
					return;
				}
				object[] array = new object[1];
				if ((object)_handler != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = _handler;
				object obj2 = _removeMethod.Invoke(eventBus, array);
			}

			[Token(Token = "0x6001589")]
			[Address(RVA = "0x42C2CB8", Offset = "0x42C2CB8", Length = "0x244")]
			private static EventBinding SubscribeHelper<T>(CameraFlowStep step, CameraFlowRunner runner, EventBus eventBus) where T : IEvent
			{
				nint num = 0;
				Delegate obj = (Action<T>)delegate
				{
					runner.ExecuteStep(step);
				};
				eventBus.ListenEvent((Action<T>)obj);
				Type typeFromHandle = typeof(EventBus);
				MethodInfo method = typeFromHandle.GetMethod("RemoveListener");
				Type[] array = new Type[1];
				Type typeFromHandle2 = typeof(T);
				if ((object)typeFromHandle2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = typeFromHandle2;
				MethodInfo removeMethod = method.MakeGenericMethod(array);
				return new EventBinding(obj, removeMethod);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200052A")]
		private sealed class _003CExecuteWithDelay_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400116B")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400116C")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400116D")]
			[FieldOffset(Offset = "0x20")]
			public CameraFlowStep step;

			[Token(Token = "0x400116E")]
			[FieldOffset(Offset = "0x28")]
			public CameraFlowRunner _003C_003E4__this;

			[Token(Token = "0x170001F0")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600158F")]
				[Address(RVA = "0x3D1305C", Offset = "0x3D1305C", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x170001F1")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6001591")]
				[Address(RVA = "0x3D130A4", Offset = "0x3D130A4", Length = "0x8")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600158C")]
			[Address(RVA = "0x3D12F0C", Offset = "0x3D12F0C", Length = "0x2C")]
			public _003CExecuteWithDelay_003Ed__15(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600158D")]
			[Address(RVA = "0x3D12F88", Offset = "0x3D12F88", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600158E")]
			[Address(RVA = "0x3D12F8C", Offset = "0x3D12F8C", Length = "0xD0")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						_003C_003E4__this.ExecuteAction(step);
					}
				}
				else
				{
					_003C_003E1__state = -1;
					CameraFlowStep cameraFlowStep = step;
					WaitForSeconds waitForSeconds = new WaitForSeconds(cameraFlowStep.DelayBeforeAction);
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
			[Token(Token = "0x6001590")]
			[Address(RVA = "0x3D13064", Offset = "0x3D13064", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4001161")]
		[FieldOffset(Offset = "0x10")]
		private readonly ICameraControlService _cameraService;

		[Token(Token = "0x4001162")]
		[FieldOffset(Offset = "0x18")]
		private readonly EventBus _eventBus;

		[Token(Token = "0x4001163")]
		[FieldOffset(Offset = "0x20")]
		private readonly MonoBehaviour _coroutineHost;

		[Token(Token = "0x4001164")]
		[FieldOffset(Offset = "0x28")]
		private CameraFlowAsset _currentFlow;

		[Token(Token = "0x4001165")]
		[FieldOffset(Offset = "0x30")]
		private readonly List<EventBinding> _activeBindings;

		[Token(Token = "0x4001166")]
		[FieldOffset(Offset = "0x38")]
		private readonly Dictionary<string, Type> _typeCache;

		[Token(Token = "0x170001EE")]
		public bool IsActive
		{
			[Token(Token = "0x600157C")]
			[Address(RVA = "0x3D11C9C", Offset = "0x3D11C9C", Length = "0x6C")]
			get
			{
				return CurrentFlow != null;
			}
		}

		[Token(Token = "0x170001EF")]
		public CameraFlowAsset CurrentFlow
		{
			[Token(Token = "0x600157D")]
			[Address(RVA = "0x3D11D08", Offset = "0x3D11D08", Length = "0x8")]
			get
			{
				return _currentFlow;
			}
		}

		[Token(Token = "0x600157E")]
		[Address(RVA = "0x3D0F71C", Offset = "0x3D0F71C", Length = "0x12C")]
		public CameraFlowRunner(ICameraControlService cameraService, EventBus eventBus, MonoBehaviour coroutineHost)
		{
			List<EventBinding> activeBindings = new List<EventBinding>();
			_activeBindings = activeBindings;
			Dictionary<string, Type> typeCache = new Dictionary<string, Type>();
			_typeCache = typeCache;
			_cameraService = cameraService;
			_eventBus = eventBus;
			_coroutineHost = coroutineHost;
		}

		[Token(Token = "0x600157F")]
		[Address(RVA = "0x3D11D10", Offset = "0x3D11D10", Length = "0x3E0")]
		public unsafe void Activate(CameraFlowAsset flow)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraFlowRunner::Activate");
		}

		[Token(Token = "0x6001580")]
		[Address(RVA = "0x3D120F0", Offset = "0x3D120F0", Length = "0x208")]
		public unsafe void Deactivate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraFlowRunner::Deactivate");
		}

		[Token(Token = "0x6001581")]
		[Address(RVA = "0x3D12878", Offset = "0x3D12878", Length = "0xCC")]
		public void ExecuteStep(CameraFlowStep step)
		{
			bool flag = step.DelayBeforeAction < 0f;
			bool flag2 = step.DelayBeforeAction == 0f;
			bool flag3 = step.DelayBeforeAction == step.DelayBeforeAction;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			if (!(flag6 || flag2))
			{
				_003CExecuteWithDelay_003Ed__15 _003CExecuteWithDelay_003Ed__16 = (_003CExecuteWithDelay_003Ed__15)FormatterServices.GetUninitializedObject(typeof(_003CExecuteWithDelay_003Ed__15));
				_003CExecuteWithDelay_003Ed__16._003C_003E1__state = 0;
				_003CExecuteWithDelay_003Ed__16._003C_003E4__this = this;
				_003CExecuteWithDelay_003Ed__16.step = step;
				Coroutine coroutine = _coroutineHost.StartCoroutine(_003CExecuteWithDelay_003Ed__16);
			}
			else
			{
				ExecuteAction(step);
			}
		}

		[Token(Token = "0x6001582")]
		[Address(RVA = "0x3D12E04", Offset = "0x3D12E04", Length = "0x108")]
		public void ExecuteStepByIndex(int index)
		{
			//IL_002c: Expected I4, but got I8
			bool flag = CurrentFlow == null;
			if ((int)(index & 0x80000000L) == 0 && !flag)
			{
				CameraFlowAsset currentFlow = CurrentFlow;
				List<CameraFlowStep> steps = currentFlow.Steps;
				if (steps.Count > index)
				{
					CameraFlowStep step = steps[index];
					ExecuteStep(step);
				}
			}
		}

		[IteratorStateMachine(typeof(_003CExecuteWithDelay_003Ed__15))]
		[Token(Token = "0x6001583")]
		[Address(RVA = "0x3D12944", Offset = "0x3D12944", Length = "0x8C")]
		private IEnumerator ExecuteWithDelay(CameraFlowStep step)
		{
			_003CExecuteWithDelay_003Ed__15 _003CExecuteWithDelay_003Ed__16 = (_003CExecuteWithDelay_003Ed__15)FormatterServices.GetUninitializedObject(typeof(_003CExecuteWithDelay_003Ed__15));
			_003CExecuteWithDelay_003Ed__16._003C_003E1__state = 0;
			_003CExecuteWithDelay_003Ed__16._003C_003E4__this = this;
			_003CExecuteWithDelay_003Ed__16.step = step;
			return _003CExecuteWithDelay_003Ed__16;
		}

		[Token(Token = "0x6001584")]
		[Address(RVA = "0x3D129D0", Offset = "0x3D129D0", Length = "0x434")]
		private void ExecuteAction(CameraFlowStep step)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CameraFlowRunner::ExecuteAction");
		}

		[Token(Token = "0x6001585")]
		[Address(RVA = "0x3D122F8", Offset = "0x3D122F8", Length = "0x210")]
		private Type ResolveType(string typeName)
		{
			Type type;
			if (_typeCache.TryGetValue(typeName, out var value))
			{
				type = value;
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1544");
				Type type2 = default(Type);
				bool flag = type2 == null;
				bool flag2 = !flag;
				type = type2;
				if (!flag2)
				{
					bool flag3 = typeName.Contains(",");
					bool flag4 = !flag3;
					string name = typeName;
					if (!flag4)
					{
						int length = typeName.IndexOf(',');
						string text = typeName.Substring(0, length);
						string text2 = text.Trim();
						name = text2;
					}
					AppDomain currentDomain = AppDomain.CurrentDomain;
					Assembly[] assemblies = currentDomain.GetAssemblies();
					bool flag5 = assemblies.Length < 1;
					type = type2;
					if (!flag5)
					{
						int num = 0;
						bool flag9;
						do
						{
							Type type3 = assemblies[num].GetType(name);
							bool flag6 = type3 != null;
							bool flag7 = !flag6;
							bool flag8 = !flag7;
							type = type3;
							if (flag8)
							{
								break;
							}
							num++;
							flag9 = num < assemblies.Length;
							type = type3;
						}
						while (flag9);
					}
				}
				_typeCache[typeName] = type;
			}
			return type;
		}
	}
}
