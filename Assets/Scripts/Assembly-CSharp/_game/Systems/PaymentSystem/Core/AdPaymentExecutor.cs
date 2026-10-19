using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unco.AdSystem;
using Unco.ContainerSystem.Runtime;
using UnityEngine;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x2000751")]
	internal class AdPaymentExecutor : IPaymentInnerExecutor
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000752")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001888")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001889")]
			public static Action _003C_003E9__3_0;

			[Token(Token = "0x6001EDC")]
			[Address(RVA = "0x3D89864", Offset = "0x3D89864", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001EDD")]
			[Address(RVA = "0x3D898C8", Offset = "0x3D898C8", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CExecute_003Eb__3_0()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000753")]
		private sealed class _003C_003Ec__DisplayClass3_0
		{
			[Token(Token = "0x400188A")]
			[FieldOffset(Offset = "0x10")]
			public PaymentContext context;

			[Token(Token = "0x400188B")]
			[FieldOffset(Offset = "0x18")]
			public CostData costData;

			[Token(Token = "0x6001EDF")]
			[Address(RVA = "0x3D898D4", Offset = "0x3D898D4", Length = "0x8")]
			public _003C_003Ec__DisplayClass3_0()
			{
			}

			internal void _003CExecute_003Eb__1()
			{
				PaymentContext paymentContext = context;
				if (paymentContext._onFailed != null)
				{
					paymentContext._onFailed();
				}
				if (paymentContext._onComplete != null)
				{
					paymentContext._onComplete();
				}
			}

			internal void _003CExecute_003Eb__2()
			{
				PaymentContext paymentContext = context;
				if (paymentContext._onFailed != null)
				{
					paymentContext._onFailed();
				}
				if (paymentContext._onComplete != null)
				{
					paymentContext._onComplete();
				}
			}

			internal void _003CExecute_003Eb__3()
			{
				PaymentContext paymentContext = context;
				if (paymentContext._onFailed != null)
				{
					paymentContext._onFailed();
				}
				if (paymentContext._onComplete != null)
				{
					paymentContext._onComplete();
				}
			}

			internal void _003CExecute_003Eb__4()
			{
				CostData costData = this.costData;
				string message = "Ad watched " + costData.bundleId + " " + costData.sourceType;
				Debug.LogWarning(message);
				context.CompletePayment();
			}
		}

		[Token(Token = "0x4001887")]
		private static readonly Dictionary<string, RewardedAdCategory> CategoryMap = new Dictionary<string, RewardedAdCategory>
		{
			{
				"RefillHeart",
				RewardedAdCategory.refil_health
			},
			{
				"RewardedLevelWin",
				RewardedAdCategory.coin_multiplier
			}
		};

		[Token(Token = "0x170002EE")]
		public CostData.CostType CostType
		{
			[Token(Token = "0x6001ED6")]
			[Address(RVA = "0x3D89224", Offset = "0x3D89224", Length = "0x8")]
			get
			{
				return CostData.CostType.Rewarded;
			}
		}

		[Token(Token = "0x6001ED7")]
		[Address(RVA = "0x3D8922C", Offset = "0x3D8922C", Length = "0x468")]
		public void Execute(Instancer instancer, PaymentContext context)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AdPaymentExecutor::Execute");
		}

		[Token(Token = "0x6001ED8")]
		[Address(RVA = "0x3D8975C", Offset = "0x3D8975C", Length = "0x8")]
		public bool IsAffordable(Instancer instancer, CostData costData)
		{
			return true;
		}

		[Token(Token = "0x6001ED9")]
		[Address(RVA = "0x3D89694", Offset = "0x3D89694", Length = "0xC8")]
		private static RewardedAdCategory ResolveCategory(string sourceType)
		{
			if (CategoryMap.TryGetValue(sourceType, out var value))
			{
				return value;
			}
			return default(RewardedAdCategory);
		}

		[Token(Token = "0x6001EDA")]
		[Address(RVA = "0x3D86C04", Offset = "0x3D86C04", Length = "0x8")]
		public AdPaymentExecutor()
		{
		}
	}
}
