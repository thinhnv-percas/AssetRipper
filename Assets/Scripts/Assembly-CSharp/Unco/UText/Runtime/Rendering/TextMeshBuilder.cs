using System;
using System.Buffers;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.UText.Runtime.Layout;
using UnityEngine;
using UnityEngine.Pool;

namespace Unco.UText.Runtime.Rendering
{
	[Token(Token = "0x20007A8")]
	public static class TextMeshBuilder
	{
		[Token(Token = "0x20007A9")]
		public struct SubMeshRange
		{
			[Token(Token = "0x4001968")]
			[FieldOffset(Offset = "0x0")]
			public int VertexStart;

			[Token(Token = "0x4001969")]
			[FieldOffset(Offset = "0x4")]
			public int VertexCount;

			[Token(Token = "0x400196A")]
			[FieldOffset(Offset = "0x8")]
			public int IndexStart;

			[Token(Token = "0x400196B")]
			[FieldOffset(Offset = "0xC")]
			public int IndexCount;

			[Token(Token = "0x400196C")]
			[FieldOffset(Offset = "0x10")]
			public Texture Texture;

			[Token(Token = "0x400196D")]
			[FieldOffset(Offset = "0x18")]
			public UTextSpriteAsset SpriteAtlas;

			[Token(Token = "0x400196E")]
			[FieldOffset(Offset = "0x20")]
			public Material MaterialOverride;
		}

		[Token(Token = "0x20007AA")]
		public struct Result
		{
			[Token(Token = "0x400196F")]
			[FieldOffset(Offset = "0x0")]
			public Vector3[] Vertices;

			[Token(Token = "0x4001970")]
			[FieldOffset(Offset = "0x8")]
			public Vector2[] UVs;

			[Token(Token = "0x4001971")]
			[FieldOffset(Offset = "0x10")]
			public Vector2[] UV2;

			[Token(Token = "0x4001972")]
			[FieldOffset(Offset = "0x18")]
			public Color32[] Colors;

			[Token(Token = "0x4001973")]
			[FieldOffset(Offset = "0x20")]
			public int[] Triangles;

			[Token(Token = "0x4001974")]
			[FieldOffset(Offset = "0x28")]
			public SubMeshRange[] SubMeshes;

			[Token(Token = "0x4001975")]
			[FieldOffset(Offset = "0x30")]
			public Bounds Bounds;

			[Token(Token = "0x4001976")]
			[FieldOffset(Offset = "0x48")]
			public UTextSdfFontAsset Atlas;

			[Token(Token = "0x4001977")]
			[FieldOffset(Offset = "0x50")]
			public float ChosenFontSize;
		}

		[Token(Token = "0x600204B")]
		[Address(RVA = "0x3D97D1C", Offset = "0x3D97D1C", Length = "0x1DB4")]
		public unsafe static Result Build(string text, UTextFont font, LayoutSettings layout, UTextStyle componentStyle, Color? componentColorOverride = null, IRichTextStyleRegistry styleRegistry = null, IRichTextSpriteRegistry spriteRegistry = null, Rect? containerRect = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::Build");
			return default;
		}

		[Token(Token = "0x600204C")]
		[Address(RVA = "0x3D9A900", Offset = "0x3D9A900", Length = "0x328")]
		private unsafe static float ResolveAutoFontSize(LayoutSettings layout, UTextSdfFontAsset atlas, IReadOnlyList<Element> elements, IReadOnlyList<RunStyle> runStyles, IReadOnlyList<UTextSpriteAsset> resolvedSpriteAtlases, List<PlacedElement> placedScratch, Rect containerRect)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::ResolveAutoFontSize");
			return default;
		}

		[Token(Token = "0x600204D")]
		[Address(RVA = "0x3D9C464", Offset = "0x3D9C464", Length = "0x284")]
		private unsafe static void EmitShadowPass(List<PlacedElement> placed, UTextRenderParams[] resolved, int resolvedCount, float fs, List<Vector3> verts, List<Vector2> uvs, List<Vector2> uv2, List<Color32> colors, List<int> tris, ref float minX, ref float minY, ref float maxX, ref float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::EmitShadowPass");
		}

		[Token(Token = "0x600204E")]
		[Address(RVA = "0x3D9C6E8", Offset = "0x3D9C6E8", Length = "0x3D0")]
		private static void EmitEffectsPass(List<PlacedElement> placed, UTextRenderParams[] resolved, int resolvedCount, float fs, List<Vector3> verts, List<Vector2> uvs, List<Vector2> uv2, List<Color32> colors, List<int> tris, ref float minX, ref float minY, ref float maxX, ref float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::EmitEffectsPass");
		}

		[Token(Token = "0x600204F")]
		[Address(RVA = "0x3D9CAB8", Offset = "0x3D9CAB8", Length = "0x3F4")]
		private unsafe static void EmitFillPass(List<PlacedElement> placed, UTextRenderParams[] resolved, IReadOnlyList<RunStyle> runStyles, int resolvedCount, float fs, List<Vector3> verts, List<Vector2> uvs, List<Vector2> uv2, List<Color32> colors, List<int> tris, ref float minX, ref float minY, ref float maxX, ref float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::EmitFillPass");
		}

		[Token(Token = "0x6002050")]
		[Address(RVA = "0x3D9CEAC", Offset = "0x3D9CEAC", Length = "0x430")]
		private unsafe static void EmitSpritePass(List<PlacedElement> placed, int targetAtlasIndex, IReadOnlyList<UTextSpriteAsset> resolvedSpriteAtlases, IReadOnlyList<RunStyle> runStyles, UTextRenderParams[] resolved, int resolvedCount, float fs, List<Vector3> verts, List<Vector2> uvs, List<Vector2> uv2, List<Color32> colors, List<int> tris, ref float minX, ref float minY, ref float maxX, ref float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::EmitSpritePass");
		}

		[Token(Token = "0x6002051")]
		[Address(RVA = "0x3D9D51C", Offset = "0x3D9D51C", Length = "0xA3C")]
		private unsafe static void EmitGlyphQuad(PlacedElement pe, float fs, Vector2 layerOffsetEm, float expand01, float blurSdf, Color32 color, List<Vector3> verts, List<Vector2> uvs, List<Vector2> uv2, List<Color32> colors, List<int> tris, ref float minX, ref float minY, ref float maxX, ref float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::EmitGlyphQuad");
		}

		[Token(Token = "0x6002052")]
		[Address(RVA = "0x3D9DF9C", Offset = "0x3D9DF9C", Length = "0xA34")]
		private unsafe static void EmitSpriteQuad(PlacedElement pe, SpriteEntry entry, float fs, Color32 color, List<Vector3> verts, List<Vector2> uvs, List<Vector2> uv2, List<Color32> colors, List<int> tris, ref float minX, ref float minY, ref float maxX, ref float maxY)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::EmitSpriteQuad");
		}

		[Token(Token = "0x6002053")]
		[Address(RVA = "0x3D9D2DC", Offset = "0x3D9D2DC", Length = "0x150")]
		private unsafe static Vector2 ComputeAlignmentOffset(float minX, float minY, float maxX, float maxY, Rect? containerRect, HorizontalAlignment h, VerticalAlignment v)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TextMeshBuilder::ComputeAlignmentOffset");
			return default;
		}

		[Token(Token = "0x6002054")]
		[Address(RVA = "0x3D99B90", Offset = "0x3D99B90", Length = "0x42C")]
		private static Result Empty()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v97 (Il2CppClass<System.EmptyArray`1<UnityEngine.Vector3>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X0_v94 (Il2CppClass<System.EmptyArray`1<UnityEngine.Vector2>>)+135]");
			int num5 = (int)((nint)0 & (nint)1);
			bool flag2 = num5 == 0;
			nint num6 = 0;
			if (flag2)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X0_v18+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X0_v88 (Il2CppClass<System.EmptyArray`1<UnityEngine.Vector2>>)+135]");
			int num8 = (int)((nint)0 & (nint)1);
			bool flag3 = num8 == 0;
			nint num9 = 0;
			if (flag3)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v237 @ X0_v85 (Il2CppClass<System.EmptyArray`1<UnityEngine.Color32>>)+135]");
			int num11 = (int)((nint)0 & (nint)1);
			bool flag4 = num11 == 0;
			nint num12 = 0;
			if (flag4)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X0_v82 (Il2CppClass<System.EmptyArray`1<System.Int32>>)+135]");
			int num14 = (int)((nint)0 & (nint)1);
			bool flag5 = num14 == 0;
			nint num15 = 0;
			if (flag5)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ X0_v79 (Il2CppClass<System.EmptyArray`1<Unco.UText.Runtime.Rendering.TextMeshBuilder+SubMeshRange>>)+135]");
			int num17 = (int)((nint)0 & (nint)1);
			bool flag6 = num17 == 0;
			nint num18 = 0;
			if (flag6)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ X0_v65+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			Result result = default(Result);
			result.Triangles = Array.Empty<int>();
			result.Bounds = default(Bounds);
			_ = 0;
			Vector3[] vertices = default(Vector3[]);
			result.Vertices = vertices;
			result.UV2 = Array.Empty<Vector2>();
			result.ChosenFontSize = 0f;
			return result;
		}
	}
}
