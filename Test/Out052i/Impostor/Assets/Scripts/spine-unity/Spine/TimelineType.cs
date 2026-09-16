using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200000B")]
	internal enum TimelineType
	{
		[Token(Token = "0x4000029")]
		Rotate = 0,
		[Token(Token = "0x400002A")]
		Translate = 1,
		[Token(Token = "0x400002B")]
		Scale = 2,
		[Token(Token = "0x400002C")]
		Shear = 3,
		[Token(Token = "0x400002D")]
		Attachment = 4,
		[Token(Token = "0x400002E")]
		Color = 5,
		[Token(Token = "0x400002F")]
		Deform = 6,
		[Token(Token = "0x4000030")]
		Event = 7,
		[Token(Token = "0x4000031")]
		DrawOrder = 8,
		[Token(Token = "0x4000032")]
		IkConstraint = 9,
		[Token(Token = "0x4000033")]
		TransformConstraint = 10,
		[Token(Token = "0x4000034")]
		PathConstraintPosition = 11,
		[Token(Token = "0x4000035")]
		PathConstraintSpacing = 12,
		[Token(Token = "0x4000036")]
		PathConstraintMix = 13,
		[Token(Token = "0x4000037")]
		TwoColor = 14
	}
}
