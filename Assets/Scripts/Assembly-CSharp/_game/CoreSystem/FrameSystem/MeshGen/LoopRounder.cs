using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x2000500")]
	public static class LoopRounder
	{
		[Token(Token = "0x60014EE")]
		[Address(RVA = "0x3D07CC8", Offset = "0x3D07CC8", Length = "0x818")]
		public static float2[] RoundCorners(float2[] loop, float radius, int segments, HashSet<long> outerBoundaryKeys = null, float epsilon = 0.001f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopRounder::RoundCorners");
			return default;
		}
	}
}
