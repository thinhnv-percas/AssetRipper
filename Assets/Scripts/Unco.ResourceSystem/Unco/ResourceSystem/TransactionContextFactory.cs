using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Token(Token = "0x2000011")]
	public class TransactionContextFactory
	{
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x10")]
		private readonly ITransactionContextProvider _provider;

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81D23BC", Offset = "0x81D23BC", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._provider = provider;\n\treturn;\n")]
		public TransactionContextFactory(ITransactionContextProvider provider)
		{
			_provider = provider;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x81D23F0", Offset = "0x81D23F0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tgoto L_0048;\nL_0048:\n\tv197 = Unco.ResourceSystem.ITransactionContextProvider::get_CurrentLevel(this._provider);\n\treturnBuffer.Source = v121;\n\treturnBuffer.SuppressEvents = 0;\n\treturn returnBuffer;\n")]
		public TransactionContext Create(string source, string customData = "")
		{
			int currentLevel = _provider.CurrentLevel;
			TransactionContext result = default(TransactionContext);
			string source2 = default(string);
			result.Source = source2;
			result.SuppressEvents = false;
			return result;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x81D256C", Offset = "0x81D256C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tgoto L_0045;\nL_0045:\n\tv188 = Unco.ResourceSystem.ITransactionContextProvider::get_CurrentLevel(this._provider);\n\treturnBuffer.Source = v116;\n\treturnBuffer.SuppressEvents = 0x101;\n\treturn returnBuffer;\n")]
		public TransactionContext Silent(string source)
		{
			int currentLevel = _provider.CurrentLevel;
			TransactionContext result = default(TransactionContext);
			string source2 = default(string);
			result.Source = source2;
			result.SuppressEvents = true;
			return result;
		}
	}
}
