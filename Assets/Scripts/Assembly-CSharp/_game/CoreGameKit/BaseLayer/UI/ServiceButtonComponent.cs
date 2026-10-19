using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Token(Token = "0x200063F")]
	public abstract class ServiceButtonComponent : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000640")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001587")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001588")]
			public static Action<IServiceButtonListener> _003C_003E9__0_0;

			[Token(Token = "0x6001AA9")]
			[Address(RVA = "0x3D55D3C", Offset = "0x3D55D3C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001AAA")]
			[Address(RVA = "0x3D55DA0", Offset = "0x3D55DA0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CInvokeClick_003Eb__0_0(IServiceButtonListener x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ServiceButtonComponent._003C_003Ec::_003CInvokeClick_003Eb__0_0");
			}
		}

		[Token(Token = "0x6001AA6")]
		[Address(RVA = "0x3D540C4", Offset = "0x3D540C4", Length = "0x150")]
		public void InvokeClick()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ServiceButtonComponent::InvokeClick");
		}

		[Token(Token = "0x6001AA7")]
		protected abstract void OnInvoke();

		[Token(Token = "0x6001AA8")]
		[Address(RVA = "0x3D53E78", Offset = "0x3D53E78", Length = "0x8")]
		protected internal ServiceButtonComponent()
		{
		}
	}
}
