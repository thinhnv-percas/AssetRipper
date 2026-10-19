using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using Unco.RewardSystem;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x2000759")]
	public class PaymentExecutor
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200075A")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001896")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001897")]
			public static Func<IPaymentInnerExecutor, CostData.CostType> _003C_003E9__1_0;

			[Token(Token = "0x6001EFD")]
			[Address(RVA = "0x3D8A8E4", Offset = "0x3D8A8E4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001EFE")]
			[Address(RVA = "0x3D8A948", Offset = "0x3D8A948", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal CostData.CostType _003C_002Ector_003Eb__1_0(IPaymentInnerExecutor e)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PaymentExecutor._003C_003Ec::_003C_002Ector_003Eb__1_0");
				return default;
			}
		}

		[Token(Token = "0x4001895")]
		[FieldOffset(Offset = "0x10")]
		private readonly Dictionary<CostData.CostType, IPaymentInnerExecutor> _executors;

		[Token(Token = "0x6001EFA")]
		[Address(RVA = "0x3D8A4C0", Offset = "0x3D8A4C0", Length = "0x16C")]
		internal PaymentExecutor(params IPaymentInnerExecutor[] executors)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentExecutor::.ctor");
		}

		[Token(Token = "0x6001EFB")]
		[Address(RVA = "0x3D8A62C", Offset = "0x3D8A62C", Length = "0x1B4")]
		public void Pay(Instancer instancer, ShopItemData itemData, CostData costData, Action onSuccess = null, Action onFailed = null, Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PaymentExecutor::Pay");
		}

		[Token(Token = "0x6001EFC")]
		[Address(RVA = "0x3D8A7E0", Offset = "0x3D8A7E0", Length = "0x104")]
		public bool IsAffordable(Instancer instancer, CostData costData)
		{
			bool flag = _executors.TryGetValue(costData.costType, out var value);
			if (flag)
			{
				flag = value.IsAffordable(instancer, costData);
			}
			return flag;
		}
	}
}
