using Cpp2ILInjected;

namespace Unco.OverridableSystem.Runtime.OverridableSystem
{
	[Token(Token = "0x200079C")]
	public class MultiplyOverride : IOverride<float>
	{
		[Token(Token = "0x4001936")]
		[FieldOffset(Offset = "0x10")]
		private readonly float _value;

		[Token(Token = "0x6002015")]
		[Address(RVA = "0x3D95F98", Offset = "0x3D95F98", Length = "0x68")]
		public static MultiplyOverride MultiplyWith(float value)
		{
			return new MultiplyOverride(value);
		}

		[Token(Token = "0x6002016")]
		[Address(RVA = "0x3D96000", Offset = "0x3D96000", Length = "0x34")]
		public MultiplyOverride(float value)
		{
			_value = value;
		}

		[Token(Token = "0x6002017")]
		[Address(RVA = "0x3D96034", Offset = "0x3D96034", Length = "0xC")]
		public float Override(float value)
		{
			return _value * value;
		}
	}
}
