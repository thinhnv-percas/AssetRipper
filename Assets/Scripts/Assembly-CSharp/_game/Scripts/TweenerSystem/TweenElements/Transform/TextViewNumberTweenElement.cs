using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using Unco.TextViewSystem;
using UnityEngine;

namespace _game.Scripts.TweenerSystem.TweenElements.Transform
{
	[Token(Token = "0x2000707")]
	public class TextViewNumberTweenElement : TweenElement<float>
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000708")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001792")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001793")]
			public static Action<TextView, float> _003C_003E9__3_0;

			[Token(Token = "0x6001DB2")]
			[Address(RVA = "0x3D7BC98", Offset = "0x3D7BC98", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001DB3")]
			[Address(RVA = "0x3D7BCFC", Offset = "0x3D7BCFC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CGetTween_003Eb__3_0(TextView view, float x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TextViewNumberTweenElement._003C_003Ec::_003CGetTween_003Eb__3_0");
			}
		}

		[SerializeField]
		[Token(Token = "0x4001791")]
		[FieldOffset(Offset = "0x60")]
		private TextView m_textView;

		[Token(Token = "0x170002E4")]
		protected override UnityEngine.Object Target
		{
			[Token(Token = "0x6001DAE")]
			[Address(RVA = "0x3D7BAA0", Offset = "0x3D7BAA0", Length = "0x8")]
			get
			{
				return m_textView;
			}
		}

		[Token(Token = "0x6001DAF")]
		[Address(RVA = "0x3D7BAA8", Offset = "0x3D7BAA8", Length = "0x188")]
		protected override Tween GetTween()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextViewNumberTweenElement::GetTween");
			return default;
		}

		[Token(Token = "0x6001DB0")]
		[Address(RVA = "0x3D7BC30", Offset = "0x3D7BC30", Length = "0x10")]
		public void Override(int start, int end)
		{
		}

		[Token(Token = "0x6001DB1")]
		[Address(RVA = "0x3D7BC40", Offset = "0x3D7BC40", Length = "0x58")]
		public TextViewNumberTweenElement()
		{
		}
	}
}
