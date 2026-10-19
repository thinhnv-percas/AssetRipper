using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200005B")]
	public static class TapPermutation
	{
		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x3C1BC60", Offset = "0x3C1BC60", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v74);\n\tv88 = v63 == 0;\n\tif (v88) goto L_00AB;\n\tv215 = graph.MaxLayer & 0x80000000;\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tv320 = v74;\n\tif (v217) goto L_00F1;\n\tv192 = 0;\n\tv433 = v180.Count;\n\tv391 = v180.Count - 1;\n\tv402 = v391 < 1;\n\tif (v402) goto L_009A;\nL_0069:\n\tv440 = v433 - 1;\n\tv443 = System.Random::Next(v63, v433);\n\tv447 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::get_Item(v180, v443);\n\tv455 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::get_Item(v180, v440);\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::set_Item(v180, v440, v447);\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::set_Item(v180, v443, v455);\n\tv469 = v440 < 1;\n\tv430 = ~v469;\n\tv428 = v440 - 1;\n\tv424 = v428 == 0;\n\tv470 = ~v424;\n\tv414 = v430 & v470;\n\tv433 = v440;\n\tif (v414) goto L_0069;\nL_009A:\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::AddRange(v74, v180);\n\tv192 = v192 + 1;\n\tv271 = v192 <= graph.MaxLayer;\n\tif (v271) goto L_0052;\n\tv320 = v74;\n\tgoto L_00F1;\nL_00AB:\n\tv218 = v74 == 0;\n\tif (v218) goto L_00E0;\n\tv334 = graph.MaxLayer & 0x80000000;\n\tv335 = v334 == 0;\n\tv309 = ~v335;\n\tv320 = v74;\n\tif (v309) goto L_00F1;\n\tv204 = 0;\n\tv202 = v182.Count - 1;\n\tv114 = v202 > 0;\n\tif (v114) goto L_00FC;\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::AddRange(v74, v182);\n\tv204 = v204 + 1;\n\tv272 = v204 <= graph.MaxLayer;\n\tif (v272) goto L_00B8;\n\tv320 = v74;\n\tgoto L_00F1;\nL_00E0:\n\tv336 = graph.MaxLayer & 0x80000000;\n\tv308 = v336 == 0;\n\tv320 = v74;\n\tif (v308) goto L_00F4;\nL_00F1:\n\treturn v320;\nL_00F4:\n\tv379 = _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph::CubesInLayer(graph, 0);\n\tv179 = System.Linq.Enumerable::ToList(v379);\nL_00FC:\n\tv211 = new System.NullReferenceException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0037:\n\tv63 = new System.Random();\n\tSystem.Random::.ctor(v63, seed);\n\tv74 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>();\nL_0052:\n\tv343 = _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph::CubesInLayer(graph, v192);\n\tv180 = System.Linq.Enumerable::ToList(v343);\nL_00B8:\n\tv386 = _game.Tools.AlgorithmicLevelGenerator.Generator.DependencyGraph::CubesInLayer(graph, v204);\n\tv182 = System.Linq.Enumerable::ToList(v386);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<(int, int)> Permute(DependencyGraph graph, int seed)
		{
			//IL_02d8: Expected I4, but got I8
			//IL_003a: Expected I4, but got I8
			//IL_0205: Expected I4, but got I8
			Random random = new Random(seed);
			List<(int, int)> list = new List<(int, int)>();
			List<(int, int)> result;
			if (random != null)
			{
				int num = (int)(graph.MaxLayer & 0x80000000L);
				bool flag = num == 0;
				bool flag2 = !flag;
				result = list;
				if (!flag2)
				{
					int num2 = 0;
					do
					{
						IEnumerable<(int, int)> source = graph.CubesInLayer(num2);
						List<(int, int)> list2 = source.ToList();
						int num3 = list2.Count;
						int num4 = list2.Count - 1;
						if (num4 >= 1)
						{
							bool flag7;
							do
							{
								int num5 = num3 - 1;
								int index = random.Next(num3);
								(int, int) value = list2[index];
								(int, int) value2 = list2[num5];
								list2[num5] = value;
								list2[index] = value2;
								bool flag3 = (uint)num5 < 1u;
								bool flag4 = !flag3;
								int num6 = num5 - 1;
								bool flag5 = num6 == 0;
								bool flag6 = !flag5;
								flag7 = flag4 && flag6;
								num3 = num5;
							}
							while (flag7);
						}
						list.AddRange(list2);
						num2++;
					}
					while (num2 <= graph.MaxLayer);
					result = list;
				}
				goto IL_02fd;
			}
			if (list != null)
			{
				int num7 = (int)(graph.MaxLayer & 0x80000000L);
				bool flag8 = num7 == 0;
				bool flag9 = !flag8;
				result = list;
				if (flag9)
				{
					goto IL_02fd;
				}
				int num8 = 0;
				while (true)
				{
					IEnumerable<(int, int)> source2 = graph.CubesInLayer(num8);
					List<(int, int)> list3 = source2.ToList();
					int num9 = list3.Count - 1;
					if (num9 > 0)
					{
						break;
					}
					list.AddRange(list3);
					num8++;
					if (num8 <= graph.MaxLayer)
					{
						continue;
					}
					goto IL_02b4;
				}
			}
			else
			{
				int num10 = (int)(graph.MaxLayer & 0x80000000L);
				bool flag10 = num10 == 0;
				result = list;
				if (!flag10)
				{
					goto IL_02fd;
				}
				IEnumerable<(int, int)> source3 = graph.CubesInLayer(0);
				List<(int, int)> list4 = source3.ToList();
			}
			NullReferenceException ex = new NullReferenceException();
			return (List<(int, int)>)(object)new NullReferenceException();
			IL_02b4:
			result = list;
			goto IL_02fd;
			IL_02fd:
			return result;
		}
	}
}
