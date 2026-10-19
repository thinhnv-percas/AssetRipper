using Cpp2ILInjected;

namespace Unco.OverridableSystem.Runtime.OverridableSystem
{
	[Token(Token = "0x20007A2")]
	public class SumOverride : IOverride<float>
	{
		[Token(Token = "0x400193F")]
		[FieldOffset(Offset = "0x10")]
		private readonly float _value;

		[Token(Token = "0x600202E")]
		[Address(RVA = "0x3D960F8", Offset = "0x3D960F8", Length = "0x68")]
		public static SumOverride SumWith(float value)
		{
			return new SumOverride(value);
		}

		[Token(Token = "0x600202F")]
		[Address(RVA = "0x3D96270", Offset = "0x3D96270", Length = "0x34")]
		public SumOverride(float value)
		{
			_value = value;
		}

		[Token(Token = "0x6002030")]
		[Address(RVA = "0x3D962A4", Offset = "0x3D962A4", Length = "0xC")]
		public float Override(float value)
		{
			return _value + value;
		}
	}
}
