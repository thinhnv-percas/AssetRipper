using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200001B")]
	internal class TransactionLog
	{
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x10")]
		private readonly ILogger logger;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x18")]
		private readonly string persistentDataPath;

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x1610FB8", Offset = "0x1610FB8", Length = "0xC0")]
		public TransactionLog(ILogger logger, string persistentDataPath)
		{
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x1610880", Offset = "0x1610880", Length = "0x60")]
		public bool HasRecordOf(string transactionID)
		{
			return false;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x160F8DC", Offset = "0x160F8DC", Length = "0x190")]
		public void Record(string transactionID)
		{
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x1611078", Offset = "0x1611078", Length = "0x8C")]
		private string GetRecordPath(string transactionID)
		{
			return null;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x1611104", Offset = "0x1611104", Length = "0x1A8")]
		internal static string ComputeHash(string transactionID)
		{
			return null;
		}
	}
}
