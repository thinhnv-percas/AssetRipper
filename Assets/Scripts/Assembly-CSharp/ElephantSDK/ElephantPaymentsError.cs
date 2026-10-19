using Cpp2ILInjected;

namespace ElephantSDK
{
	[Token(Token = "0x2000965")]
	public class ElephantPaymentsError
	{
		[Token(Token = "0x4001FBA")]
		[FieldOffset(Offset = "0x10")]
		public ElephantPaymentErrorType Type;

		[Token(Token = "0x4001FBB")]
		[FieldOffset(Offset = "0x18")]
		public string Message;

		[Token(Token = "0x4001FBC")]
		[FieldOffset(Offset = "0x20")]
		public string RawError;

		[Token(Token = "0x4001FBD")]
		[FieldOffset(Offset = "0x28")]
		public string ProductId;

		[Token(Token = "0x4001FBE")]
		[FieldOffset(Offset = "0x30")]
		public string TransactionId;

		[Token(Token = "0x6002835")]
		[Address(RVA = "0x3E4F218", Offset = "0x3E4F218", Length = "0x8")]
		public ElephantPaymentsError()
		{
		}
	}
}
