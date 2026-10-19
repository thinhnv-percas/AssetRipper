using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.Extensions;
using Unco.TextViewSystem;
using Unco.UncoButtonSystem;
using Unco.Utils;
using UnityEngine;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x2000544")]
	public class HealthLostWarningUiController : UIController
	{
		[CompilerGenerated]
		[Token(Token = "0x2000545")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x40011D2")]
			[FieldOffset(Offset = "0x10")]
			public ButtonColor color;

			[Token(Token = "0x40011D3")]
			[FieldOffset(Offset = "0x18")]
			public HealthLostWarningUiController _003C_003E4__this;

			[Token(Token = "0x6001616")]
			[Address(RVA = "0x3D18BE0", Offset = "0x3D18BE0", Length = "0x8")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal bool _003CInitialize_003Eb__0(Pair<ButtonColor, UncoButton> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HealthLostWarningUiController._003C_003Ec__DisplayClass4_0::_003CInitialize_003Eb__0");
				return default;
			}

			internal void _003CInitialize_003Eb__1()
			{
				HealthLostWarningUiController healthLostWarningUiController = _003C_003E4__this;
				if (healthLostWarningUiController._onContinue != null)
				{
					healthLostWarningUiController._onContinue();
				}
				HealthLostWarningUiController healthLostWarningUiController2 = default(HealthLostWarningUiController);
				healthLostWarningUiController2.Hide();
			}
		}

		[SerializeField]
		[Token(Token = "0x40011CE")]
		[FieldOffset(Offset = "0x48")]
		private Pair<ButtonColor, UncoButton>[] m_buttons;

		[SerializeField]
		[Token(Token = "0x40011CF")]
		[FieldOffset(Offset = "0x50")]
		private TextView m_titleText;

		[SerializeField]
		[Token(Token = "0x40011D0")]
		[FieldOffset(Offset = "0x58")]
		private TextView m_buttonText;

		[Token(Token = "0x40011D1")]
		[FieldOffset(Offset = "0x60")]
		private Action _onContinue;

		[Token(Token = "0x6001614")]
		[Address(RVA = "0x3D189CC", Offset = "0x3D189CC", Length = "0x214")]
		public void Initialize(Action onContinue, string titleText, string buttonText, ButtonColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HealthLostWarningUiController::Initialize");
		}

		[Token(Token = "0x6001615")]
		[Address(RVA = "0x3D18BE8", Offset = "0x3D18BE8", Length = "0x8")]
		public HealthLostWarningUiController()
		{
		}
	}
}
