using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.FrameSystem.MeshGen;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004ED")]
	public static class RegionPropertyPresetSync
	{
		[Token(Token = "0x60014B4")]
		[Address(RVA = "0x3CFCF48", Offset = "0x3CFCF48", Length = "0x950")]
		public unsafe static RegionSyncResult Apply(ref FrameData frame, FrameData preset, RegionSyncOptions opts, Action<string> verboseLog = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RegionPropertyPresetSync::Apply");
			return default;
		}

		[Token(Token = "0x60014B5")]
		[Address(RVA = "0x3CFD9B4", Offset = "0x3CFD9B4", Length = "0x188")]
		private static int FindMatchingPresetLoop(float2 levelInterior, float levelArea, List<List<float2>> presetLoops, float[] presetAreas, float relEpsilon)
		{
			int result;
			if (presetAreas != null)
			{
				if (presetLoops.Count >= 1)
				{
					float num = 3.4028235E+38f;
					int num2 = 0;
					int num3 = -1;
					bool flag11;
					do
					{
						List<float2> polygon = presetLoops[num2];
						if (MeshGenUtils.IsPointInPolygon(levelInterior, polygon))
						{
							float num4 = Mathf.Max(presetAreas[num2], 0.0001f);
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
							float num5 = levelArea / num4;
							bool flag = num5 < relEpsilon;
							bool flag2 = num5 == num5;
							bool flag3 = relEpsilon == relEpsilon;
							bool flag4 = flag2 && flag3;
							bool flag5 = !flag4;
							bool flag6 = flag == flag5;
							bool flag7 = !flag6;
							bool flag8 = presetAreas[num2] < num;
							bool flag9 = flag7 && flag8;
							bool flag10 = !flag9;
							if (!flag10)
							{
								num = presetAreas[num2];
							}
							if (!flag10)
							{
								num3 = num2;
							}
						}
						num2++;
						flag11 = num2 >= presetLoops.Count;
						result = num3;
					}
					while (!flag11);
					goto IL_0254;
				}
			}
			else if (presetLoops.Count >= 1)
			{
				int num6 = 0;
				do
				{
					List<float2> polygon2 = presetLoops[num6];
					bool flag12 = MeshGenUtils.IsPointInPolygon(levelInterior, polygon2);
					num6++;
				}
				while (num6 < presetLoops.Count);
			}
			result = -1;
			goto IL_0254;
			IL_0254:
			return result;
		}
	}
}
