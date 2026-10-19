using Cpp2ILInjected;

namespace Unco.OverridableSystem.Runtime.OverridableSystem
{
	[Token(Token = "0x20007A0")]
	public static class OverridableValueExtensions
	{
		[Token(Token = "0x6002028")]
		[Address(RVA = "0x3D96040", Offset = "0x3D96040", Length = "0xB8")]
		public static SumOverride SumWith(this OverridableValue<float> overridableValue, float sumAmount)
		{
			SumOverride sumOverride = new SumOverride(sumAmount);
			overridableValue.AddOverride(sumOverride, 0);
			return sumOverride;
		}

		[Token(Token = "0x6002029")]
		[Address(RVA = "0x3D96160", Offset = "0x3D96160", Length = "0xB8")]
		public static MultiplyOverride MultiplyWith(this OverridableValue<float> overridableValue, float multiplyAmount)
		{
			MultiplyOverride multiplyOverride = new MultiplyOverride(multiplyAmount);
			overridableValue.AddOverride(multiplyOverride, 0);
			return multiplyOverride;
		}

		[Token(Token = "0x600202A")]
		[Address(RVA = "0x3D96218", Offset = "0x3D96218", Length = "0x58")]
		public static IOverride<bool> Override(bool value)
		{
			bool to = default(bool);
			return SetOverride<bool>.SetTo(to);
		}
	}
}
