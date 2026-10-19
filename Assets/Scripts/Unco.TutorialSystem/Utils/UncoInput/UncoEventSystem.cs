using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.UncoInput
{
	[Serializable]
	[Token(Token = "0x2000004")]
	public class UncoEventSystem
	{
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		private EventSystem m_eventSystem;

		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		private UncoStandaloneInputModule m_inputModule;

		[Inject(false)]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		private EventBus _eventBus;

		[Token(Token = "0x17000001")]
		public EventSystem Current
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x81DDC94", Offset = "0x81DDC94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Current;\n")]
			get
			{
				return m_eventSystem;
			}
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81DDC9C", Offset = "0x81DDC9C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tUnityEngine.Behaviour::set_enabled(this.Current, state);\n\tv57 = ~state;\n\tif (v57) goto L_003F;\n\tgoto L_0030;\nL_0030:\n\tUnityEngine.EventSystems.EventSystem::set_current(this.Current);\n\treturn;\nL_003F:\n\tUnco.EventBusSystem.Runtime.EventBus::InvokeEvent(this._eventBus);\n\treturn;\n")]
		public void SetInputState(bool state)
		{
			Current.enabled = state;
			if (state)
			{
				EventSystem.current = Current;
			}
			else
			{
				_eventBus.InvokeEvent<UventInputSystemDisabled>();
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x81DDD6C", Offset = "0x81DDD6C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Input::set_simulateMouseWithTouches(1);\n\tv37 = 0;\n\tUnityEngine.Touch::set_position(&v45 @ stack_-80_v2 (UnityEngine.Touch), data);\n\tv58 = v45;\n\tv66 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this.m_inputModule, &v58 @ stack_-D0_v1 (UnityEngine.Touch), &v62 @ stack_-31 (System.Boolean), &v37 @ stack_-32_v1 (System.Boolean));\n\tv37 = 0;\n\tUnityEngine.Touch::set_position(&v45 @ stack_-80_v2 (UnityEngine.Touch), data);\n\tv58 = v45;\n\tv147 = UnityEngine.EventSystems.PointerInputModule::GetTouchPointerEventData(this.m_inputModule, &v58 @ stack_-D0_v1 (UnityEngine.Touch), &v62 @ stack_-31 (System.Boolean), &v37 @ stack_-32_v1 (System.Boolean));\n\tUnityEngine.EventSystems.StandaloneInputModule::ProcessTouchPress(this.m_inputModule, v147, 1, 1);\n\treturn;\n")]
		public void Click(Vector2 data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UncoEventSystem::Click");
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x81DDF84", Offset = "0x81DDF84", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Input::set_simulateMouseWithTouches(1);\n\tUnityEngine.EventSystems.StandaloneInputModule::ProcessTouchPress(this.m_inputModule, data, pressed, released);\n\treturn;\n")]
		public void ProcessTouchPress(PointerEventData data, bool pressed, bool released)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UncoEventSystem::ProcessTouchPress");
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x81DE02C", Offset = "0x81DE02C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Behaviour::get_enabled(this.Current);\n\treturn returnVal1;\n")]
		public bool GetInputState()
		{
			return Current.enabled;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x81DE048", Offset = "0x81DE048", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UncoEventSystem()
		{
		}
	}
}
