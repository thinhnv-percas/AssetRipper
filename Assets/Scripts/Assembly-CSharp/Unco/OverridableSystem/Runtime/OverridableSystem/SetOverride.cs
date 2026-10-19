using Cpp2ILInjected;

namespace Unco.OverridableSystem.Runtime.OverridableSystem
{
	[Token(Token = "0x20007A1")]
	public class SetOverride<T> : IOverride<T> where T : struct
	{
		[Token(Token = "0x400193E")]
		[FieldOffset(Offset = "0x0")]
		private readonly T _value;

		[Token(Token = "0x600202B")]
		[Address(RVA = "0x6258970", Offset = "0x6258970", Length = "0xB4")]
		public static SetOverride<T> SetTo(T value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SetOverride::SetTo");
			return default;
		}

		[Token(Token = "0x600202C")]
		[Address(RVA = "0x6258A24", Offset = "0x6258A24", Length = "0x2C")]
		public SetOverride(T value)
		{
			_value = value;
		}

		[Token(Token = "0x600202D")]
		[Address(RVA = "0x6258A50", Offset = "0x6258A50", Length = "0x8")]
		public T Override(T value)
		{
			return _value;
		}
	}
}
