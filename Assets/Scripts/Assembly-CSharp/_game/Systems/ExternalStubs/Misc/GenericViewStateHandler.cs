using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;
using _game.Scripts.Shop.View.Components;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.ExternalStubs.Misc
{
	[Token(Token = "0x200077D")]
	public class GenericViewStateHandler : MonoBehaviour
	{
		[Token(Token = "0x200077E")]
		private class DefaultView : ComponentState
		{
			[Token(Token = "0x6001F96")]
			[Address(RVA = "0x3D92520", Offset = "0x3D92520", Length = "0x8")]
			public DefaultView()
			{
			}
		}

		[Token(Token = "0x200077F")]
		private class ResourceView : ComponentState, IPurchaseButtonState
		{
			[Token(Token = "0x6001F97")]
			[Address(RVA = "0x3D92528", Offset = "0x3D92528", Length = "0x8")]
			public override void Activate()
			{
				base.Activate();
			}

			[Token(Token = "0x6001F98")]
			[Address(RVA = "0x3D92530", Offset = "0x3D92530", Length = "0x4")]
			public void Init(PurchaseButton purchaseBtn, CostData costData)
			{
			}

			[Token(Token = "0x6001F99")]
			[Address(RVA = "0x3D92534", Offset = "0x3D92534", Length = "0x8")]
			public ResourceView()
			{
			}
		}

		[Token(Token = "0x2000780")]
		public interface IPurchaseButtonState
		{
			[Token(Token = "0x6001F9A")]
			void Init(PurchaseButton purchaseBtn, CostData costData);
		}

		[Token(Token = "0x6001F95")]
		[Address(RVA = "0x3D92518", Offset = "0x3D92518", Length = "0x8")]
		public GenericViewStateHandler()
		{
		}
	}
}
