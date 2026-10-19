using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[CreateAssetMenu(fileName = "UTextSdfFontAsset", menuName = "UText/SDF Font Asset")]
	[Token(Token = "0x20007AF")]
	public class UTextSdfFontAsset : ScriptableObject
	{
		[Tooltip("Pixels-per-em at bake time. 1 em == this many atlas pixels of glyph extent. Higher = sharper at large render sizes; eats atlas area.")]
		[Token(Token = "0x4001991")]
		[FieldOffset(Offset = "0x18")]
		public int SamplingPointSize;

		[Tooltip("Pixel padding around each glyph in the atlas. Bounds the SDF gradient range — Expand on a UTextEffect cannot exceed Padding/SamplingPointSize em.")]
		[Token(Token = "0x4001992")]
		[FieldOffset(Offset = "0x1C")]
		public int Padding;

		[Header("Bake Outputs")]
		[Tooltip("Atlas texture. Stored as a sub-asset of this UTextSdfFontAsset — the bake button replaces it in place.")]
		[Token(Token = "0x4001993")]
		[FieldOffset(Offset = "0x20")]
		public Texture2D AtlasTexture;

		[Tooltip("Ascent above baseline in em.")]
		[Token(Token = "0x4001994")]
		[FieldOffset(Offset = "0x28")]
		public float AscentEm;

		[Tooltip("Descent below baseline in em (positive value).")]
		[Token(Token = "0x4001995")]
		[FieldOffset(Offset = "0x2C")]
		public float DescentEm;

		[Tooltip("Distance from one baseline to the next in em.")]
		[Token(Token = "0x4001996")]
		[FieldOffset(Offset = "0x30")]
		public float LineHeightEm;

		[Tooltip("Width of the space character in em.")]
		[Token(Token = "0x4001997")]
		[FieldOffset(Offset = "0x34")]
		public float SpaceAdvanceEm;

		[Tooltip("Glyph table. Built by the baker.")]
		[Token(Token = "0x4001998")]
		[FieldOffset(Offset = "0x38")]
		public SdfGlyph[] Glyphs;

		[NonSerialized]
		[Token(Token = "0x4001999")]
		[FieldOffset(Offset = "0x40")]
		internal Dictionary<uint, int> _lookup;

		[CompilerGenerated]
		[Token(Token = "0x400199A")]
		private static Action<UTextSdfFontAsset> OnChanged;

		[Token(Token = "0x1700032A")]
		public float DistanceRangeEm
		{
			[Token(Token = "0x6002065")]
			[Address(RVA = "0x3D9F120", Offset = "0x3D9F120", Length = "0x2C")]
			get
			{
				if (SamplingPointSize >= 1)
				{
					int num = Padding + Padding;
					return (float)num / (float)SamplingPointSize;
				}
				return 0f;
			}
		}

		[Token(Token = "0x1700032B")]
		public float ThresholdShiftPerEm
		{
			[Token(Token = "0x6002066")]
			[Address(RVA = "0x3D9F14C", Offset = "0x3D9F14C", Length = "0x38")]
			get
			{
				bool flag = SamplingPointSize < 1;
				float result = 0f;
				if (!flag)
				{
					int num = Padding + Padding;
					int num2 = num / SamplingPointSize;
					bool flag2 = num2 < 0;
					bool flag3 = num2 == 0;
					bool flag4 = num2 == num2;
					bool flag5 = !flag4;
					bool flag6 = flag2 == flag5;
					bool flag7 = !flag6;
					bool flag8 = flag7 || flag3;
					result = 0f;
					if (!flag8)
					{
						result = 1f / (float)num2;
					}
				}
				return result;
			}
		}

		[Token(Token = "0x6002067")]
		[Address(RVA = "0x3D9F184", Offset = "0x3D9F184", Length = "0xE4")]
		public bool TryGetGlyph(uint codepoint, out SdfGlyph glyph)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextSdfFontAsset::TryGetGlyph");
			glyph = default;
			return default;
		}

		[Token(Token = "0x6002068")]
		[Address(RVA = "0x3D9F268", Offset = "0x3D9F268", Length = "0x144")]
		internal void EnsureLookup()
		{
			if (_lookup != null)
			{
				return;
			}
			SdfGlyph[] glyphs = Glyphs;
			Dictionary<uint, int> lookup = new Dictionary<uint, int>(glyphs.Length);
			if (Glyphs != null)
			{
				_lookup = lookup;
				SdfGlyph[] glyphs2 = Glyphs;
				int num = 0;
				int num2 = 32;
				do
				{
					if (num >= glyphs2.Length)
					{
						return;
					}
					Dictionary<uint, int> lookup2 = _lookup;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X8_v13 (Unco.UText.Runtime.Rendering.SdfGlyph[])+v95 @ X22_v6 (System.Int32)]");
					lookup2[0u] = num;
					num++;
					glyphs2 = Glyphs;
					num2 += 40;
				}
				while (Glyphs != null);
				throw new NullReferenceException();
			}
			_lookup = lookup;
		}

		[CompilerGenerated]
		[Token(Token = "0x6002069")]
		[Address(RVA = "0x3D9F3AC", Offset = "0x3D9F3AC", Length = "0xD0")]
		public static void add_OnChanged(Action<UTextSdfFontAsset> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextSdfFontAsset::add_OnChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x600206A")]
		[Address(RVA = "0x3D9F47C", Offset = "0x3D9F47C", Length = "0xD0")]
		public static void remove_OnChanged(Action<UTextSdfFontAsset> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextSdfFontAsset::remove_OnChanged");
		}

		[Token(Token = "0x600206B")]
		[Address(RVA = "0x3D9F54C", Offset = "0x3D9F54C", Length = "0x8C")]
		public void RaiseChanged()
		{
			_lookup = null;
			if (OnChanged != null)
			{
				OnChanged(this);
			}
		}

		[Token(Token = "0x600206C")]
		[Address(RVA = "0x3D9F5D8", Offset = "0x3D9F5D8", Length = "0x100")]
		public UTextSdfFontAsset()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextSdfFontAsset::.ctor");
		}
	}
}
