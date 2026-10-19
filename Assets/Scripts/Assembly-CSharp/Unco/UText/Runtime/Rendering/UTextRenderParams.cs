using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[Token(Token = "0x20007AE")]
	public struct UTextRenderParams
	{
		[Token(Token = "0x400198D")]
		[FieldOffset(Offset = "0x0")]
		public Color FillColor;

		[Token(Token = "0x400198E")]
		[FieldOffset(Offset = "0x10")]
		public float FillDilate;

		[Token(Token = "0x400198F")]
		[FieldOffset(Offset = "0x18")]
		public UTextEffect[] Effects;

		[Token(Token = "0x4001990")]
		[FieldOffset(Offset = "0x20")]
		public BlurredShadow Shadow;

		[Token(Token = "0x6002063")]
		[Address(RVA = "0x3D9C328", Offset = "0x3D9C328", Length = "0x13C")]
		public static UTextRenderParams Build(UTextStyle style)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextRenderParams::Build");
			return default;
		}

		[Token(Token = "0x6002064")]
		[Address(RVA = "0x3D9EF30", Offset = "0x3D9EF30", Length = "0x1F0")]
		public bool Equals(UTextRenderParams o)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextRenderParams::Equals");
			return default;
		}
	}
}
