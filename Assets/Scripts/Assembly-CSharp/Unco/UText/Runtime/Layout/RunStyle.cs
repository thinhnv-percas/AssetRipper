using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007B6")]
	public struct RunStyle : IEquatable<RunStyle>
	{
		[Token(Token = "0x40019B7")]
		[FieldOffset(Offset = "0x0")]
		public float SizeMultiplier;

		[Token(Token = "0x40019B8")]
		[FieldOffset(Offset = "0x4")]
		public float SizeAbsolute;

		[Token(Token = "0x40019B9")]
		[FieldOffset(Offset = "0x8")]
		public Color? FillOverride;

		[Token(Token = "0x40019BA")]
		[FieldOffset(Offset = "0x1C")]
		public int StyleAssetIndex;

		[Token(Token = "0x40019BB")]
		[FieldOffset(Offset = "0x20")]
		public bool SpriteTintRun;

		[Token(Token = "0x1700032C")]
		public static RunStyle Default
		{
			[Token(Token = "0x6002077")]
			[Address(RVA = "0x3D9FC4C", Offset = "0x3D9FC4C", Length = "0x24")]
			get
			{
				RunStyle result = default(RunStyle);
				result.SizeMultiplier = 1f;
				result.SizeAbsolute = 0f;
				_ = 0;
				result.StyleAssetIndex = -1;
				return result;
			}
		}

		[Token(Token = "0x6002078")]
		[Address(RVA = "0x3D9FC70", Offset = "0x3D9FC70", Length = "0x14C")]
		public unsafe bool Equals(RunStyle other)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RunStyle::Equals");
			return default;
		}

		[Token(Token = "0x6002079")]
		[Address(RVA = "0x3D9FDBC", Offset = "0x3D9FDBC", Length = "0xC4")]
		public unsafe override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RunStyle::Equals");
			return default;
		}

		[Token(Token = "0x600207A")]
		[Address(RVA = "0x3D9FE80", Offset = "0x3D9FE80", Length = "0x130")]
		public unsafe override int GetHashCode()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RunStyle::GetHashCode");
			return default;
		}
	}
}
