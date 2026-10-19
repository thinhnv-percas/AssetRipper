using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;

namespace Systems.ResourceSystem.IAPSystem.Scripts.Data
{
	[Token(Token = "0x2000038")]
	public struct UventPurchaseRestoreFailed : IEvent
	{
		[Token(Token = "0x1700002F")]
		[field: Token(Token = "0x4000081")]
		[field: FieldOffset(Offset = "0x0")]
		public string Message
		{
			[Token(Token = "0x60000C9")]
			[Address(RVA = "0x3C678E4", Offset = "0x3C678E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Message;\n")]
			get;
			[Token(Token = "0x60000CA")]
			[Address(RVA = "0x3C678EC", Offset = "0x3C678EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Message = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x3C678F4", Offset = "0x3C678F4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn v10;\n")]
		public static UventPurchaseRestoreFailed Create(string message)
		{
			UventPurchaseRestoreFailed result = default(UventPurchaseRestoreFailed);
			return result;
		}
	}
}
