using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _game.Systems.UncoInput
{
	[Token(Token = "0x2000007")]
	public class CustomButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerClickHandler
	{
		[CompilerGenerated]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x20")]
		internal Action _onClick;

		[SerializeField]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x28")]
		private InputConfig m_config;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x30")]
		private bool isHolding;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x34")]
		private float holdTime;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x38")]
		internal InputConfig _runtimeConfig;

		[Token(Token = "0x17000002")]
		private InputConfig RuntimeConfig
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x81DE490", Offset = "0x81DE490", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._runtimeConfig == 0;\n\tif (v3) goto L_0006;\n\treturn this._runtimeConfig;\nL_0006:\n\treturn this.m_config;\n")]
			get
			{
				if (_runtimeConfig != null)
				{
					return _runtimeConfig;
				}
				return m_config;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81DE348", Offset = "0x81DE348", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this._onClick (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this._onClick;\n\tgoto L_002C;\n")]
		private void add__onClick(Action value)
		{
			Action action = _onClick;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref _onClick, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81DE3EC", Offset = "0x81DE3EC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this._onClick (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this._onClick;\n\tgoto L_002C;\n")]
		private void remove__onClick(Action value)
		{
			Action action = _onClick;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref _onClick, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81DE4A8", Offset = "0x81DE4A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._runtimeConfig = config;\n\treturn;\n")]
		public void SetConfig(InputConfig config)
		{
			_runtimeConfig = config;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x81DE4B0", Offset = "0x81DE4B0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this._runtimeConfig;\n\tv2 = this._runtimeConfig == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_0011;\n\tv7 = this.m_config;\nL_0011:\n\tv18 = v7.inputMode != 2;\n\tif (v18) goto L_0016;\n\tthis.isHolding = 1;\n\tthis.holdTime = 0f;\nL_0016:\n\treturn;\n")]
		public void OnPointerDown(PointerEventData eventData)
		{
			InputConfig inputConfig = _runtimeConfig;
			if (_runtimeConfig == null)
			{
				inputConfig = m_config;
			}
			if (inputConfig.inputMode == InputMode.Hold)
			{
				isHolding = true;
				holdTime = 0f;
			}
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x81DE4E8", Offset = "0x81DE4E8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this._runtimeConfig;\n\tv2 = this._runtimeConfig == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_0011;\n\tv7 = this.m_config;\nL_0011:\n\tv18 = v7.inputMode != 2;\n\tif (v18) goto L_0014;\n\tthis.isHolding = 0;\nL_0014:\n\treturn;\n")]
		public void OnPointerUp(PointerEventData eventData)
		{
			InputConfig inputConfig = _runtimeConfig;
			if (_runtimeConfig == null)
			{
				inputConfig = m_config;
			}
			if (inputConfig.inputMode == InputMode.Hold)
			{
				isHolding = false;
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x81DE518", Offset = "0x81DE518", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = this._runtimeConfig;\n\tv17 = this._runtimeConfig == 0;\n\tv18 = ~v17;\n\tif (v18) goto L_001A;\n\tv22 = this.m_config;\nL_001A:\n\tv33 = v22.inputMode != 1;\n\tif (v33) goto L_0058;\n\tgoto L_0024;\nL_0024:\n\tv65 = 0xB2ED000 + 0x728;\n\tgoto L_002B;\nL_002B:\n\tUnityEngine.Debug::Log(*([v65 @ X21_v9 (System.Int32)]));\n\tv68 = this._onClick == 0;\n\tif (v68) goto L_0058;\n\tSystem.Action::Invoke(this._onClick);\n\treturn;\nL_0058:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerClick(PointerEventData eventData)
		{
			//IL_0086: Expected O, but got I4
			InputConfig inputConfig = _runtimeConfig;
			if (_runtimeConfig == null)
			{
				inputConfig = m_config;
			}
			if (inputConfig.inputMode == InputMode.Click)
			{
				int num = 187617280 + 1832;
				Debug.Log(num);
				if (_onClick != null)
				{
					_onClick();
				}
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x81DE6C8", Offset = "0x81DE6C8", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this.isHolding != 1;\n\tif (v29) goto L_0050;\n\tv33 = UnityEngine.Time::get_deltaTime();\n\tv52 = this.holdTime + v33;\n\tthis.holdTime = v52;\n\tv74 = this._runtimeConfig;\n\tv84 = this._runtimeConfig == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0024;\n\tv74 = this.m_config;\nL_0024:\n\tv67 = v52 < v74.holdDuration;\n\tv112 = v52 == v52;\n\tv63 = v74.holdDuration == v74.holdDuration;\n\tv69 = v112 & v63;\n\tv61 = ~v69;\n\tv113 = v67 == v61;\n\tv59 = ~v113;\n\tif (v59) goto L_0050;\n\tgoto L_0037;\nL_0037:\n\tv139 = 0xB2ED000 + 0x730;\n\tgoto L_003E;\nL_003E:\n\tUnityEngine.Debug::Log(*([v139 @ X21_v9 (System.Int32)]));\n\tv158 = this._onClick == 0;\n\tif (v158) goto L_0046;\n\tSystem.Action::Invoke(this._onClick);\nL_0050:\n\treturn;\nL_0046:\n\tthis.isHolding = 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0125: Expected O, but got I4
			if (!isHolding)
			{
				return;
			}
			float deltaTime = Time.deltaTime;
			float num = (holdTime += deltaTime);
			InputConfig inputConfig = _runtimeConfig;
			if (_runtimeConfig == null)
			{
				inputConfig = m_config;
			}
			bool flag = num < inputConfig.holdDuration;
			bool flag2 = num == num;
			bool flag3 = inputConfig.holdDuration == inputConfig.holdDuration;
			bool flag4 = flag2 && flag3;
			bool flag5 = !flag4;
			if (flag == flag5)
			{
				int num2 = 187617280 + 1840;
				Debug.Log(num2);
				if (_onClick != null)
				{
					_onClick();
				}
				isHolding = false;
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x81DE600", Offset = "0x81DE600", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB2ED000 + 0x728;\n\tgoto L_0018;\nL_0018:\n\tUnityEngine.Debug::Log(*([v51 @ X21_v9 (System.Int32)]));\n\tv64 = this._onClick == 0;\n\tif (v64) goto L_0045;\n\tSystem.Action::Invoke(this._onClick);\n\treturn;\nL_0045:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleClick()
		{
			//IL_0022: Expected O, but got I4
			int num = 187617280 + 1832;
			Debug.Log(num);
			if (_onClick != null)
			{
				_onClick();
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x81DE7D4", Offset = "0x81DE7D4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB2ED000 + 0x730;\n\tgoto L_0018;\nL_0018:\n\tUnityEngine.Debug::Log(*([v51 @ X21_v9 (System.Int32)]));\n\tv64 = this._onClick == 0;\n\tif (v64) goto L_0045;\n\tSystem.Action::Invoke(this._onClick);\n\treturn;\nL_0045:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleHold()
		{
			//IL_0022: Expected O, but got I4
			int num = 187617280 + 1840;
			Debug.Log(num);
			if (_onClick != null)
			{
				_onClick();
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x81DE89C", Offset = "0x81DE89C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this._onClick (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, action);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this._onClick;\n\tgoto L_002C;\n")]
		public void AddListener(Action action)
		{
			Delegate obj = _onClick;
			bool flag;
			do
			{
				Delegate obj2 = Delegate.Combine(obj, action);
				if ((object)obj2 == null || (object)obj2.GetType() == typeof(Action))
				{
					Delegate obj3 = Interlocked.CompareExchange(ref _onClick, (Action)obj2, (Action)obj);
					flag = (object)obj3 == obj;
					obj = obj3;
					continue;
				}
				throw new InvalidCastException();
			}
			while (!flag);
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x81DE940", Offset = "0x81DE940", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this._onClick (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, action);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this._onClick;\n\tgoto L_002C;\n")]
		public void RemoveListener(Action action)
		{
			Delegate obj = _onClick;
			bool flag;
			do
			{
				Delegate obj2 = Delegate.Remove(obj, action);
				if ((object)obj2 == null || (object)obj2.GetType() == typeof(Action))
				{
					Delegate obj3 = Interlocked.CompareExchange(ref _onClick, (Action)obj2, (Action)obj);
					flag = (object)obj3 == obj;
					obj = obj3;
					continue;
				}
				throw new InvalidCastException();
			}
			while (!flag);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x81DE9E4", Offset = "0x81DE9E4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._onClick = 0;\n\treturn;\n")]
		public void RemoveAllListeners()
		{
			_onClick = null;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x81DE9F0", Offset = "0x81DE9F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public CustomButton()
		{
		}
	}
}
