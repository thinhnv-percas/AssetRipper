using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x20004FC")]
	public static class EarClipTriangulator
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20004FD")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40010C0")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40010C1")]
			public static Comparison<float2[]> _003C_003E9__0_0;

			[Token(Token = "0x60014E0")]
			[Address(RVA = "0x3D05F68", Offset = "0x3D05F68", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x60014E1")]
			[Address(RVA = "0x3D05FCC", Offset = "0x3D05FCC", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal int _003CTriangulate_003Eb__0_0(float2[] a, float2[] b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EarClipTriangulator._003C_003Ec::_003CTriangulate_003Eb__0_0");
				return default;
			}
		}

		[Token(Token = "0x60014DA")]
		[Address(RVA = "0x3D04BAC", Offset = "0x3D04BAC", Length = "0x474")]
		public unsafe static int[] Triangulate(float2[] outerCCW, List<float2[]> holesCW, out float2[] mergedVertices)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EarClipTriangulator::Triangulate");
			mergedVertices = default;
			return default;
		}

		[Token(Token = "0x60014DB")]
		[Address(RVA = "0x3D05020", Offset = "0x3D05020", Length = "0x720")]
		private static List<float2> MergeHole(List<float2> outerPoly, float2[] hole)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EarClipTriangulator::MergeHole");
			return default;
		}

		[Token(Token = "0x60014DC")]
		[Address(RVA = "0x3D05740", Offset = "0x3D05740", Length = "0x76C")]
		private static int[] EarClip(float2[] vertices)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EarClipTriangulator::EarClip");
			return default;
		}

		[Token(Token = "0x60014DD")]
		[Address(RVA = "0x3D05F24", Offset = "0x3D05F24", Length = "0x34")]
		private static bool IsConvex(float2 a, float2 b, float2 c)
		{
			float num = b.x - a.x;
			float num2 = b.y - a.y;
			float num3 = c.x - b.x;
			float num4 = c.y - b.y;
			float num5 = num * num4;
			float num6 = num2 * num3;
			float num7 = num5 - num6;
			bool flag = num7 < -1E-06f;
			bool flag2 = num7 == num7;
			bool flag3 = !flag2;
			return flag == flag3;
		}

		[Token(Token = "0x60014DE")]
		[Address(RVA = "0x3D05EAC", Offset = "0x3D05EAC", Length = "0x78")]
		private static bool IsPointInTriangle(float2 p, float2 a, float2 b, float2 c)
		{
			float num = b.x - a.x;
			float num2 = b.y - a.y;
			float num3 = p.x - a.x;
			float num4 = p.y - a.y;
			float num5 = num4 * num;
			float num6 = num3 * num2;
			float a2 = num5 - num6;
			float num7 = c.x - b.x;
			float num8 = c.y - b.y;
			float num9 = p.x - b.x;
			float num10 = p.y - b.y;
			float num11 = num10 * num7;
			float num12 = num9 * num8;
			float b2 = num11 - num12;
			float num13 = a.x - c.x;
			float num14 = a.y - c.y;
			float num15 = p.x - c.x;
			float num16 = p.y - c.y;
			float num17 = num13 * num16;
			float num18 = num14 * num15;
			float b3 = num17 - num18;
			float a3 = Mathf.Min(a2, b2);
			float num19 = Mathf.Min(a3, b3);
			float a4 = Mathf.Max(a2, b2);
			float num20 = Mathf.Max(a4, b3);
			bool flag = num20 < 0f;
			bool flag2 = num20 == 0f;
			bool flag3 = num20 == num20;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			bool result = flag6 || flag2;
			if (num19 < 0f)
			{
				return result;
			}
			return true;
		}

		[Token(Token = "0x60014DF")]
		[Address(RVA = "0x3D05F58", Offset = "0x3D05F58", Length = "0x10")]
		private static float Cross(float2 a, float2 b)
		{
			float num = a.x * b.y;
			float num2 = a.y * b.x;
			return num - num2;
		}
	}
}
