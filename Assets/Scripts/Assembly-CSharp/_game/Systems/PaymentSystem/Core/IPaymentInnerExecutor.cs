using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using _game.Systems.PaymentSystem.Data;

namespace _game.Systems.PaymentSystem.Core
{
	[Token(Token = "0x2000757")]
	internal interface IPaymentInnerExecutor
	{
		[Token(Token = "0x170002F1")]
		CostData.CostType CostType
		{
			[Token(Token = "0x6001EF2")]
			get;
		}

		[Token(Token = "0x6001EF3")]
		void Execute(Instancer instancer, PaymentContext context);

		[Token(Token = "0x6001EF4")]
		bool IsAffordable(Instancer instancer, CostData costData);
	}
}
