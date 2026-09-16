using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x200005F")]
	public class Compute_DT_EventArgs
	{
		[Token(Token = "0x4000412")]
		[FieldOffset(Offset = "0x10")]
		public Compute_DistanceTransform_EventTypes EventType;

		[Token(Token = "0x4000413")]
		[FieldOffset(Offset = "0x14")]
		public float ProgressPercentage;

		[Token(Token = "0x4000414")]
		[FieldOffset(Offset = "0x18")]
		public Color[] Colors;

		[Token(Token = "0x6000527")]
		[Address(RVA = "0x9173C4", Offset = "0x9173C4", Length = "0x3C")]
		public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, float progress)
		{
		}

		[Token(Token = "0x6000528")]
		[Address(RVA = "0x917400", Offset = "0x917400", Length = "0x2C8")]
		public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, Color[] colors)
		{
		}
	}
}
