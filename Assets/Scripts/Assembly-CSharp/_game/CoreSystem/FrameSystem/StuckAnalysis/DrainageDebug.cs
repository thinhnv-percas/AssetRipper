using System;
using System.Collections.Generic;
using System.Text;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.FrameSystem.MeshGen;

namespace _game.CoreSystem.FrameSystem.StuckAnalysis
{
	[Token(Token = "0x20004EF")]
	public static class DrainageDebug
	{
		[Token(Token = "0x60014B7")]
		[Address(RVA = "0x3CFDC60", Offset = "0x3CFDC60", Length = "0x1264")]
		public static string RenderAscii(FrameData frame, DrainageConfig config)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DrainageDebug::RenderAscii");
			return default;
		}

		[Token(Token = "0x60014B8")]
		[Address(RVA = "0x3CFEFA8", Offset = "0x3CFEFA8", Length = "0x114")]
		private static bool Crosses(float2 p1, float2 p2, WallSegment[] walls)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DrainageDebug::Crosses");
			return default;
		}
	}
}
