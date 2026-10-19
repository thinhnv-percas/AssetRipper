using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[CreateAssetMenu(fileName = "UTextStyle", menuName = "UText/Style")]
	[Token(Token = "0x20007B3")]
	public class UTextStyle : ScriptableObject
	{
		[Tooltip("Fill colour used for the glyph body.")]
		[Token(Token = "0x40019AA")]
		[FieldOffset(Offset = "0x18")]
		public Color FillColor;

		[Range(-1f, 1f)]
		[Tooltip("Fill dilate, normalised the same way as UTextEffect.Expand. 0 = source contour; +1 = max outward (Padding/SamplingPointSize em); -1 = shrunk to nothing. Useful for thickening or thinning the visible glyph weight without re-baking the font.")]
		[Token(Token = "0x40019AB")]
		[FieldOffset(Offset = "0x28")]
		public float FillDilate;

		[Tooltip("Hard-edged decorative layers (strokes / non-blurred drop shadows) rendered behind the fill, in order. Index 0 is drawn first (furthest back).")]
		[Token(Token = "0x40019AC")]
		[FieldOffset(Offset = "0x30")]
		public UTextEffect[] Effects;

		[Tooltip("Optional single blurred drop shadow rendered behind every other layer. Leave Color alpha at 0 to disable.")]
		[Token(Token = "0x40019AD")]
		[FieldOffset(Offset = "0x38")]
		public BlurredShadow Shadow;

		[CompilerGenerated]
		[Token(Token = "0x40019AE")]
		private static Action<UTextStyle> OnChanged;

		[CompilerGenerated]
		[Token(Token = "0x6002072")]
		[Address(RVA = "0x3D9F92C", Offset = "0x3D9F92C", Length = "0xD0")]
		public static void add_OnChanged(Action<UTextStyle> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextStyle::add_OnChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6002073")]
		[Address(RVA = "0x3D9F9FC", Offset = "0x3D9F9FC", Length = "0xD0")]
		public static void remove_OnChanged(Action<UTextStyle> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextStyle::remove_OnChanged");
		}

		[Token(Token = "0x6002074")]
		[Address(RVA = "0x3D9FACC", Offset = "0x3D9FACC", Length = "0x7C")]
		public void RaiseChanged()
		{
			if (OnChanged != null)
			{
				OnChanged(this);
			}
		}

		[Token(Token = "0x6002075")]
		[Address(RVA = "0x3D9EE70", Offset = "0x3D9EE70", Length = "0xC0")]
		public static UTextStyle GetOrDefault(UTextStyle style)
		{
			if (style != null)
			{
				return style;
			}
			string defaultStylePath = UTextSettings.DefaultStylePath;
			return Resources.Load<UTextStyle>(defaultStylePath);
		}

		[Token(Token = "0x6002076")]
		[Address(RVA = "0x3D9FB48", Offset = "0x3D9FB48", Length = "0x104")]
		public UTextStyle()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFF6]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				FillColor = default(Color);
			}
			else
			{
				_ = 1;
				FillColor = default(Color);
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v24 (Il2CppClass<System.EmptyArray`1<Unco.UText.Runtime.Rendering.UTextEffect>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			Effects = Array.Empty<UTextEffect>();
		}
	}
}
