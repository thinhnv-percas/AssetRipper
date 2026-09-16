using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000007")]
	public class Animation
	{
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x10")]
		internal string name;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x18")]
		internal ExposedList<Timeline> timelines;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x20")]
		internal HashSet<int> timelineIds;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x28")]
		internal float duration;

		[Token(Token = "0x17000006")]
		public ExposedList<Timeline> Timelines
		{
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x1522258", Offset = "0x1522258", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.timelines;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Timelines;
			}
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x1522260", Offset = "0x1522260", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timelines = value;\n\treturn;\n")]
			set
			{
				Timelines = value;
			}
		}

		[Token(Token = "0x17000007")]
		public float Duration
		{
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x1522268", Offset = "0x1522268", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.duration;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Duration;
			}
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x1522270", Offset = "0x1522270", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.duration = value;\n\treturn;\n")]
			set
			{
				Duration = value;
			}
		}

		[Token(Token = "0x17000008")]
		public string Name
		{
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x1522278", Offset = "0x1522278", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x152201C", Offset = "0x152201C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, name, timelines, methodInfo, v37, v38, v39, v40, duration, v41, v42, v43, v44, v45, v46, v47);\n\tv55 = System.Collections.Generic.HashSet`1<System.Int32>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, name, timelines, methodInfo, v37, v38, v39, v40, duration, v41, v42, v43, v44, v45, v46, v47);\n\tv59 = System.Int32[];\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, name, timelines, methodInfo, v37, v38, v39, v40, duration, v41, v42, v43, v44, v45, v46, v47);\n\tv125 = Spine.Timeline;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, name, timelines, methodInfo, v37, v38, v39, v40, duration, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37AD5]) = v51;\nL_0025:\n\tSystem.Object::.ctor(this);\n\tv57 = name == 0;\n\tif (v57) goto L_00BD;\n\tv61 = timelines == 0;\n\tif (v61) goto L_00C9;\n\t// 46 NewArr v130 @ X0_v31 (System.Int32[]), typeof(System.Int32[]), timelines.Count (System.Int32)\n\tv146 = timelines.Count < 1;\n\tif (v146) goto L_00A3;\nL_0040:\n\tv230 = timelines.Items;\n\tgoto L_007F;\n\tv372 = *([v367 @ X8_v16+B0]);\n\tv373 = v372 + 8;\n\tv375 = *([v402 @ X10_v11-8]);\n\tv417 = v375 == v368;\n\tif (v417) goto L_0077;\n\tv379 = v403 - 1;\n\tv377 = v402 + 0x10;\n\tv381 = v403 != 1;\n\tif (v381) goto L_FFFFFFFF;\n\tv398 = 1;\n\tv399 = v161;\n\tv400 = 0xB349B4(v399, v368, v398, methodInfo, v37, v38, v39, v40, duration, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_007F;\nL_0077:\n\tv423 = *([v402 @ X10_v11]);\n\tv424 = v423 + 1;\n\tv425 = v424 << 4;\n\tv426 = v367 + v425;\n\tv427 = v426 + 0x138;\nL_007F:\n\tv192 = Spine.Timeline::get_PropertyId(v230[v81 @ X24_v6 (System.Int32)]);\n\tv130[v81 @ X24_v6 (System.Int32)] = v192;\n\tv81 = v81 + 1;\n\tv172 = v81 < timelines.Count;\n\tif (v172) goto L_0040;\nL_00A3:\n\tv202 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v202, v130);\n\tthis.timelines = timelines;\n\tthis.timelineIds = v202;\n\tthis.name = name;\n\tthis.duration = duration;\n\treturn;\n\tv308 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_00BD:\n\tv134 = new System.ArgumentNullException();\n\tgoto L_00D6;\nL_00C9:\n\tv147 = new System.ArgumentNullException();\nL_00D6:\n\tSystem.ArgumentNullException::.ctor(v260, v259, v257);\n\tthrow v260;\n// 164 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Animation(string name, ExposedList<Timeline> timelines, float duration)
		{
			ArgumentNullException ex2;
			if (name != null)
			{
				if (timelines != null)
				{
					int[] array = new int[timelines.Count];
					if (timelines.Count >= 1)
					{
						int num = 0;
						do
						{
							Timeline[] items = timelines.Items;
							int propertyId = items[num].PropertyId;
							array[num] = propertyId;
							num++;
						}
						while (num < timelines.Count);
					}
					HashSet<int> hashSet = new HashSet<int>((IEqualityComparer<int>)(object)array);
					Timelines = timelines;
					timelineIds = hashSet;
					this.name = name;
					Duration = duration;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "timelines cannot be null.";
				string text2 = "timelines";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "name cannot be null.";
				string text2 = "name";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x1522280", Offset = "0x1522280", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, id, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37AD6]) = v36;\nL_001E:\n\treturnVal1 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(this.timelineIds, id);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasTimeline(int id)
		{
			return timelineIds.Contains(id);
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x15222D8", Offset = "0x15222D8", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv52 = Spine.Timeline;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, skeleton, loop, events, blend, direction, methodInfo, v55, lastTime, time, alpha, v56, v57, v58, v59, v60);\n\tv63 = 1;\n\t*([1A37AD7]) = v63;\nL_0023:\n\tv64 = skeleton == 0;\n\tif (v64) goto L_00C1;\n\tv66 = loop == 0;\n\tif (v66) goto L_0048;\n\tv152 = v61.duration == 0;\n\tif (v152) goto L_0048;\n\tv183 = 0x1854EF0(v61, skeleton, loop, events, blend, direction, methodInfo, v55, time, v61.duration, alpha, v56, v57, v58, v59, v60);\n\tv158 = lastTime <= 0;\n\tif (v158) goto L_0048;\n\tv182 = 0x1854EF0(v183, skeleton, loop, events, blend, direction, methodInfo, v55, lastTime, v61.duration, alpha, v56, v57, v58, v59, v60);\nL_0048:\n\tv139 = v61.timelines;\n\tv199 = v139.Count < 1;\n\tif (v199) goto L_00BB;\nL_005B:\n\tv265 = v139.Items;\n\tgoto L_009F;\n\tv403 = *([v400 @ X8_v10+B0]);\n\tv404 = v403 + 8;\n\tv406 = *([v433 @ X10_v10-8]);\n\tv448 = v406 == v401;\n\tif (v448) goto L_0091;\n\tv410 = v434 - 1;\n\tv408 = v433 + 0x10;\n\tv412 = v434 != 1;\n\tif (v412) goto L_FFFFFFFF;\n\tv429 = v263;\n\tv430 = 0;\n\tv431 = 0xB349B4(v429, v401, v430, v209, v201, v205, methodInfo, v55, v231, v229, v203, v56, v57, v58, v59, v60);\n\tgoto L_009F;\nL_0091:\n\tv454 = *([v433 @ X10_v10]);\n\tv455 = v454 << 4;\n\tv456 = v400 + v455;\n\tv457 = v456 + 0x138;\nL_009F:\n\tSpine.Timeline::Apply(v265[v223 @ X26_v7 (System.Int32)], skeleton, v135, v137, events, alpha, blend, direction);\n\tv223 = v223 + 1;\n\tv302 = v223 != v139.Count;\n\tif (v302) goto L_005B;\nL_00BB:\n\treturn;\n\tv268 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_00C1:\n\tv187 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v187, \"skeleton\", \"skeleton cannot be null.\");\n\tthrow v187;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Apply(Skeleton skeleton, float lastTime, float time, bool loop, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_0072: Expected O, but got F4
			//IL_00b3: Expected O, but got F4
			if (skeleton != null)
			{
				bool flag = !loop;
				float lastTime2 = lastTime;
				float time2 = time;
				if (!flag)
				{
					bool flag2 = Duration == 0f;
					lastTime2 = lastTime;
					time2 = time;
					if (!flag2)
					{
						object obj = time % Duration;
						bool flag3 = !(lastTime > 0f);
						lastTime2 = lastTime;
						time2 = time;
						if (!flag3)
						{
							object obj2 = lastTime % Duration;
							lastTime2 = lastTime;
							time2 = time;
						}
					}
				}
				ExposedList<Timeline> exposedList = Timelines;
				if (exposedList.Count >= 1)
				{
					int num = 0;
					do
					{
						Timeline[] items = exposedList.Items;
						items[num].Apply(skeleton, lastTime2, time2, events, alpha, blend, direction);
						num++;
					}
					while (num != exposedList.Count);
				}
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("skeleton", "skeleton cannot be null.");
			throw ex;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x15224B8", Offset = "0x15224B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15224C0", Offset = "0x15224C0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = values.Length / v52;\n\tv11 = v5 == 2;\n\tv88 = v5 - 2;\n\tif (v11) goto L_005A;\n\tv167 = v88 >> 1;\n\tv166 = v167 + 1;\n\tv165 = v166 * v52;\nL_0022:\n\tv178 = values[v165 @ X13_v5 (System.Int32)] < target;\n\tv179 = ~v178;\n\tv180 = values[v165 @ X13_v5 (System.Int32)] - target;\n\tv182 = v180 == 0;\n\tv187 = ~v182;\n\tv188 = v179 & v187;\n\tv189 = ~v188;\n\tif (v189) goto L_0033;\n\tgoto L_0033;\nL_0033:\n\tv201 = ~v182;\n\tv190 = v179 & v201;\n\tv99 = ~v190;\n\tif (v99) goto L_FFFFFFFF;\n\tgoto L_003F;\nL_003F:\n\tv195 = v103 == v88;\n\tif (v195) goto L_0055;\n\tv205 = v88 + v103;\n\tv167 = v205 >> 1;\n\tv166 = v167 + 1;\n\tv165 = v166 * v52;\n\tv206 = v165 < values.Length;\n\tv125 = ~v206;\n\tv101 = ~v125;\n\tif (v101) goto L_0022;\n\tthrow System.IndexOutOfRangeException;\nL_0055:\n\tv90 = v88 + 1;\n\tv52 = v90 * v52;\nL_005A:\n\treturn v52;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int BinarySearch(float[] values, float target, int step)
		{
			int num2 = default(int);
			int num = values.Length / num2;
			bool flag = num == 2;
			int num3 = num - 2;
			if (!flag)
			{
				int num4 = num3 >> 1;
				int num5 = num4 + 1;
				int num6 = num5 * num2;
				int num7 = 0;
				while (true)
				{
					bool flag2 = values[num6] < target;
					bool flag3 = !flag2;
					float num8 = values[num6] - target;
					bool flag4 = num8 == 0f;
					bool flag5 = !flag4;
					if (flag3 && flag5)
					{
						num3 = num4;
					}
					bool flag6 = !flag4;
					if (!(flag3 && flag6))
					{
						num7 = num5;
					}
					if (num7 == num3)
					{
						break;
					}
					int num9 = num3 + num7;
					num4 = num9 >> 1;
					num5 = num4 + 1;
					num6 = num5 * num2;
					if (num6 >= values.Length)
					{
						throw new IndexOutOfRangeException();
					}
				}
				int num10 = num3 + 1;
				return num10 * num2;
			}
			return num2;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x1522540", Offset = "0x1522540", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = values.Length == 2;\n\tv105 = values.Length - 2;\n\tif (v9) goto L_FFFFFFFF;\n\tv160 = v105 >> 1;\n\tv159 = v160 + 1;\nL_0020:\n\tv170 = values[v159 @ X11_v5 (System.Int32)] < target;\n\tv171 = ~v170;\n\tv172 = values[v159 @ X11_v5 (System.Int32)] - target;\n\tv174 = v172 == 0;\n\tv179 = ~v174;\n\tv180 = v171 & v179;\n\tv181 = ~v180;\n\tif (v181) goto L_0031;\n\tgoto L_0031;\nL_0031:\n\tv194 = ~v174;\n\tv183 = v171 & v194;\n\tv53 = ~v183;\n\tif (v53) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv188 = v59 == v105;\n\tif (v188) goto L_0052;\n\tv198 = v105 + v59;\n\tv160 = v198 >> 1;\n\tv159 = v160 + 1;\n\tv199 = v159 < values.Length;\n\tv82 = ~v199;\n\tv56 = ~v82;\n\tif (v56) goto L_0020;\n\tthrow System.IndexOutOfRangeException;\nL_0052:\n\treturnVal2 = v105 + 1;\n\tgoto L_0057;\nL_0057:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int BinarySearch(float[] values, float target)
		{
			bool flag = values.Length == 2;
			int num = values.Length - 2;
			if (!flag)
			{
				int num2 = num >> 1;
				int num3 = num2 + 1;
				int num4 = 0;
				while (true)
				{
					bool flag2 = values[num3] < target;
					bool flag3 = !flag2;
					float num5 = values[num3] - target;
					bool flag4 = num5 == 0f;
					bool flag5 = !flag4;
					if (flag3 && flag5)
					{
						num = num2;
					}
					bool flag6 = !flag4;
					if (!(flag3 && flag6))
					{
						num4 = num3;
					}
					if (num4 == num)
					{
						break;
					}
					int num6 = num + num4;
					num2 = num6 >> 1;
					num3 = num2 + 1;
					if (num3 >= values.Length)
					{
						throw new IndexOutOfRangeException();
					}
				}
				return num + 1;
			}
			return 1;
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15225B4", Offset = "0x15225B4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = values.Length < step;\n\tv16 = values.Length - step;\n\tif (v10) goto L_FFFFFFFF;\nL_002A:\n\tv120 = values[returnVal2 @ X0_v3 (System.Int32)] > target;\n\tif (v120) goto L_003D;\n\treturnVal2 = returnVal2 + step;\n\tv82 = returnVal2 <= v16;\n\tif (v82) goto L_002A;\nL_003D:\n\treturn returnVal2;\n\tv33 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static int LinearSearch(float[] values, float target, int step)
		{
			bool flag = values.Length < step;
			int num = values.Length - step;
			if (flag)
			{
				goto IL_008e;
			}
			int num2 = 0;
			while (!(values[num2] > target))
			{
				num2 += step;
				if (num2 <= num)
				{
					continue;
				}
				goto IL_008e;
			}
			goto IL_009c;
			IL_009c:
			return num2;
			IL_008e:
			num2 = -1;
			goto IL_009c;
		}
	}
}
