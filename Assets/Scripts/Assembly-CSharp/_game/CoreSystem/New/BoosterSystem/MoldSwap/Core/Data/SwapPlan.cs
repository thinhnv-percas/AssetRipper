using System;
using System.Collections.Generic;
using System.Text;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Core.Data
{
	[Token(Token = "0x200048C")]
	public class SwapPlan
	{
		[Token(Token = "0x4000ED5")]
		[FieldOffset(Offset = "0x10")]
		public readonly List<SwapEntry> Swaps;

		[Token(Token = "0x4000ED6")]
		[FieldOffset(Offset = "0x18")]
		public string Diagnostics;

		[Token(Token = "0x170001A0")]
		public bool IsEmpty
		{
			[Token(Token = "0x60012E9")]
			[Address(RVA = "0x3CDA2A8", Offset = "0x3CDA2A8", Length = "0x54")]
			get
			{
				List<SwapEntry> swaps = Swaps;
				return swaps.Count == 0;
			}
		}

		[Token(Token = "0x60012EA")]
		[Address(RVA = "0x3CE1470", Offset = "0x3CE1470", Length = "0x2C0")]
		public unsafe override string ToString()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SwapPlan::ToString");
			return default;
		}

		[Token(Token = "0x60012EB")]
		[Address(RVA = "0x3CDD9AC", Offset = "0x3CDD9AC", Length = "0x8C")]
		public SwapPlan()
		{
			List<SwapEntry> swaps = new List<SwapEntry>();
			Swaps = swaps;
		}
	}
}
