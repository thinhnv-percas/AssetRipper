using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Utilities;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.BaseLayer.Controller
{
	[Token(Token = "0x20006C5")]
	public class TouchInputProvider : IRawInputProvider, IDisposable
	{
		[Token(Token = "0x40016E5")]
		[FieldOffset(Offset = "0x10")]
		private readonly UiManager _uiManager;

		[Token(Token = "0x40016E6")]
		[FieldOffset(Offset = "0x18")]
		private readonly List<ScreenPointInput> _screenPoints;

		[Token(Token = "0x6001CBE")]
		[Address(RVA = "0x3D711B4", Offset = "0x3D711B4", Length = "0xBC")]
		public TouchInputProvider(UiManager uiManager)
		{
			List<ScreenPointInput> screenPoints = new List<ScreenPointInput>();
			_screenPoints = screenPoints;
			_uiManager = uiManager;
			Input.multiTouchEnabled = false;
			EnhancedTouchSupport.Enable();
		}

		[Token(Token = "0x6001CBF")]
		[Address(RVA = "0x3D71270", Offset = "0x3D71270", Length = "0x8")]
		public void Dispose()
		{
			EnhancedTouchSupport.Disable();
		}

		[Token(Token = "0x6001CC0")]
		[Address(RVA = "0x3D71278", Offset = "0x3D71278", Length = "0x134")]
		public IReadOnlyList<ScreenPointInput> GetScreenPoints()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TouchInputProvider::GetScreenPoints");
			return default;
		}

		[Token(Token = "0x6001CC1")]
		[Address(RVA = "0x3D713AC", Offset = "0x3D713AC", Length = "0x260")]
		private bool TryGetTouchPoint(out ScreenPointInput point)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TouchInputProvider::TryGetTouchPoint");
			point = default;
			return default;
		}

		[Token(Token = "0x6001CC2")]
		[Address(RVA = "0x3D7160C", Offset = "0x3D7160C", Length = "0x14C")]
		private bool TryGetPenPoint(out ScreenPointInput point)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TouchInputProvider::TryGetPenPoint");
			point = default;
			return default;
		}
	}
}
