using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000013")]
	public static class Obfuscator
	{
		[Token(Token = "0x6000071")]
		[Address(RVA = "0x15D4F4C", Offset = "0x15D4F4C", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv38 = *([1ED7B08]);\n\tv39 = *([v38 @ X8_v35]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, order, key, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2029A2B]) = v56;\nL_0020:\n\tv60 = new UnityEngine.Purchasing.Security.Obfuscator+<>c__DisplayClass1_0();\n\tSystem.Object::.ctor(v60);\n\tv60.key = key;\n\t// 46 NewArr v92 @ X0_v8 (System.Byte[]), typeof(System.Byte[]), data.Length\n\tSystem.Array::Copy(data, v92, data.Length);\n\tv178 = order.Length - 1;\n\tv179 = v178 & 0x80000000;\n\tv180 = v179 == 0;\n\tv181 = ~v180;\n\tif (v181) goto L_00B1;\n\tv182 = order.Length & 0xFFFFFFFF;\n\tv183 = v182 < v178;\n\tv184 = ~v183;\n\tv185 = v182 - v178;\n\tv187 = v185 == 0;\n\tv192 = ~v184;\n\tv193 = v192 | v187;\n\tif (v193) goto L_00AA;\n\tv275 = data.Length * 0x66666667;\n\tv276 = v275 >> 0x3F;\n\tv277 = v275 >> 0x23;\n\tv211 = order.Length - 2;\n\tv267 = v277 + v276;\n\tv279 = order.Length * 0x14;\n\tv208 = v279 - 0x14;\n\tv281 = v267 * 0x14;\nL_005E:\n\tv332 = data.Length == v281;\n\tif (v332) goto L_007B;\n\tv347 = order[v218 @ X27_v5 (System.Int32)] != v267;\n\tif (v347) goto L_007B;\n\tv365 = data.Length * 0x66666667;\n\tv366 = v365 >> 0x3F;\n\tv367 = v365 >> 0x23;\n\tv349 = v367 + v366;\n\tv352 = v349 * 0x14;\n\tv250 = data.Length - v352;\nL_007B:\n\tv360 = System.Linq.Enumerable::Skip(v92, v208);\n\tv372 = System.Linq.Enumerable::Take(v360, v250);\n\tv376 = System.Linq.Enumerable::ToArray(v372);\n\tv205 = order[v218 @ X27_v5 (System.Int32)] << 2;\n\tv264 = order[v218 @ X27_v5 (System.Int32)] + v205;\n\tv203 = v264 << 2;\n\tSystem.Array::Copy(v92, v203, v92, v208, v250);\n\tSystem.Array::Copy(v376, 0, v92, v203, v250);\n\tv383 = v211 & 0x80000000;\n\tv384 = v383 == 0;\n\tv258 = ~v384;\n\tif (v258) goto L_00B1;\n\tv218 = v218 - 1;\n\tv211 = v211 - 1;\n\tv208 = v208 - 0x14;\n\tv385 = v218 < order.Length;\n\tv293 = ~v385;\n\tv285 = ~v293;\n\tif (v285) goto L_005E;\nL_00AA:\n\tv298 = new System.IndexOutOfRangeException();\n\tthrow v298;\nL_00B1:\n\tv271 = new System.Func`2<System.Byte, System.Byte>();\n\tSystem.Func`2<System.Byte, System.Byte>::.ctor(v271, v60, Il2CppMethodInfo);\n\tv337 = System.Linq.Enumerable::Select(v92, v271);\n\treturnVal2 = System.Linq.Enumerable::ToArray(v337);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] DeObfuscate(byte[] data, int[] order, int key)
		{
			//IL_0060: Expected I4, but got I8
			//IL_009c: Expected I4, but got I8
			//IL_0133: Expected O, but got I4
			//IL_0150: Expected O, but got I4
			//IL_028e: Expected I4, but got I8
			//IL_01bb: Expected O, but got I4
			//IL_02d3: Expected O, but got I
			byte[] array = new byte[data.Length];
			Array.Copy(data, array, data.Length);
			int num = order.Length - 1;
			if ((int)(num & 0x80000000L) == 0)
			{
				int num2 = (int)(order.Length & 0xFFFFFFFFL);
				bool flag = num2 < num;
				bool flag2 = !flag;
				int num3 = num2 - num;
				bool flag3 = num3 == 0;
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					goto IL_0315;
				}
				int num4 = data.Length * 1717986919;
				int num5 = num4 >> 63;
				int num6 = num4 >> 35;
				object obj = order.Length - 2;
				int num7 = num6 + num5;
				object obj2 = order.Length * 20;
				int num8 = (int)((long)(IntPtr)obj2 - 20L);
				int num9 = num7 * 20;
				int num10 = num;
				while (true)
				{
					bool flag5 = data.Length == num9;
					int num11 = 20;
					if (!flag5)
					{
						bool flag6 = order[num10] != num7;
						num11 = 20;
						if (!flag6)
						{
							object obj3 = data.Length * 1717986919;
							int num12 = (int)((long)(IntPtr)obj3 >> 63);
							int num13 = (int)((long)(IntPtr)obj3 >> 35);
							int num14 = num13 + num12;
							int num15 = num14 * 20;
							num11 = data.Length - num15;
						}
					}
					IEnumerable<byte> source = array.Skip(num8);
					IEnumerable<byte> source2 = source.Take(num11);
					byte[] sourceArray = source2.ToArray();
					int num16 = order[num10] << 2;
					int num17 = order[num10] + num16;
					int num18 = num17 << 2;
					Array.Copy(array, num18, array, num8, num11);
					Array.Copy(sourceArray, 0, array, num18, num11);
					if ((int)((long)(IntPtr)obj & 0x80000000L) != 0)
					{
						break;
					}
					num10--;
					obj = (long)(IntPtr)obj - 1L;
					num8 -= 20;
					if (num10 < order.Length)
					{
						continue;
					}
					goto IL_0315;
				}
			}
			Func<byte, byte> selector = delegate(byte x)
			{
				int num19 = x & 0xFF;
				return (byte)(key ^ num19);
			};
			IEnumerable<byte> source3 = array.Select(selector);
			return source3.ToArray();
			IL_0315:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}
	}
}
