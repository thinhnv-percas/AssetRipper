using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.RewardSystem;
using _game.CoreSystem.HealthSystem;

namespace _game.Systems.PaymentSystem.PurchaseHandlers
{
	[Token(Token = "0x2000741")]
	public class HealthPurchaseHandler : IPurchaseHandler
	{
		[Inject(false)]
		[Token(Token = "0x400184B")]
		[FieldOffset(Offset = "0x10")]
		private HealthController _healthController;

		[Token(Token = "0x6001E93")]
		[Address(RVA = "0x3D86EE4", Offset = "0x3D86EE4", Length = "0x104")]
		public void Handle(ShopItemData item)
		{
			//IL_00ed: Expected I4, but got F8
			if (item is HealthShopItemData)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [item @ X1 (Unco.RewardSystem.ShopItemData)+40]");
				if ((nint)0 != 2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [item @ X1 (Unco.RewardSystem.ShopItemData)+40]");
					if ((nint)0 == 1)
					{
						float duration = ((HealthShopItemData)item).Duration;
						_healthController.GrantInfiniteHealth(duration);
					}
				}
				else
				{
					int amount = ((item.Amount != 9.218868437227405E+18) ? ((int)item.Amount) : (-2147483648));
					_healthController.AddHealth(amount);
				}
				return;
			}
			InvalidCastException ex = new InvalidCastException();
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001E94")]
		[Address(RVA = "0x3D86C1C", Offset = "0x3D86C1C", Length = "0x8")]
		public HealthPurchaseHandler()
		{
		}
	}
}
