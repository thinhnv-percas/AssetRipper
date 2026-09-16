using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Token(Token = "0x2000014")]
	public class Compute_DT_EventArgs
	{
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x10")]
		public Compute_DistanceTransform_EventTypes EventType;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x14")]
		public float ProgressPercentage;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x18")]
		public Color[] Colors;

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x15CEDC4", Offset = "0x15CEDC4", Length = "0x38")]
		public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, float progress)
		{
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x15CEDFC", Offset = "0x15CEDFC", Length = "0x30")]
		public Compute_DT_EventArgs(Compute_DistanceTransform_EventTypes type, Color[] colors)
		{
		}
	}
}
