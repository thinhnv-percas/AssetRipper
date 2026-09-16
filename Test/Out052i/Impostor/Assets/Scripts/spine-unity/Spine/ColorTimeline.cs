using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000013")]
	public class ColorTimeline : CurveTimeline, ISlotTimeline
	{
		[Token(Token = "0x400004B")]
		public const int ENTRIES = 5;

		[Token(Token = "0x400004C")]
		protected const int PREV_TIME = -5;

		[Token(Token = "0x400004D")]
		protected const int PREV_R = -4;

		[Token(Token = "0x400004E")]
		protected const int PREV_G = -3;

		[Token(Token = "0x400004F")]
		protected const int PREV_B = -2;

		[Token(Token = "0x4000050")]
		protected const int PREV_A = -1;

		[Token(Token = "0x4000051")]
		protected const int R = 1;

		[Token(Token = "0x4000052")]
		protected const int G = 2;

		[Token(Token = "0x4000053")]
		protected const int B = 3;

		[Token(Token = "0x4000054")]
		protected const int A = 4;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x18")]
		internal int slotIndex;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x17000016")]
		public override int PropertyId
		{
			[Token(Token = "0x600004F")]
			[Address(RVA = "0x1523C70", Offset = "0x1523C70", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.slotIndex + 0x5000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex + 83886080;
			}
		}

		[Token(Token = "0x17000017")]
		public int SlotIndex
		{
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x1523CDC", Offset = "0x1523CDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slotIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex;
			}
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x1523C80", Offset = "0x1523C80", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_000F;\n\tthis.slotIndex = value;\n\treturn;\nL_000F:\n\tv37 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v37, \"index must be >= 0.\");\n\tthrow v37;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(value & 0x80000000L) == 0)
				{
					slotIndex = value;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index must be >= 0.");
				throw ex;
			}
		}

		[Token(Token = "0x17000018")]
		public float[] Frames
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x1523CE4", Offset = "0x1523CE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x1523CEC", Offset = "0x1523CEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x1523C08", Offset = "0x1523C08", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37ADD]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 2;\n\tv45 = frameCount + v44;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), v45 @ X1_v2 (System.Int32)\n\tthis.frames = v46;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 2;
			int num2 = frameCount + num;
			float[] array = new float[num2];
			Frames = array;
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x1523CF4", Offset = "0x1523CF4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 2;\n\tv8 = frameIndex + v6;\n\tv73 = v8 + 1;\n\tv2[v8 @ X10_v2 (System.Int32)] = time;\n\tv87 = v8 + 2;\n\tv2[v73 @ X11_v3 (System.Int32)] = r;\n\tv88 = v8 + 3;\n\tv2[v87 @ X11_v4 (System.Int32)] = g;\n\tv114 = v8 + 4;\n\tv2[v88 @ X11_v5 (System.Int32)] = b;\n\tv2[v114 @ X10_v4 (System.Int32)] = a;\n\treturn;\n\tv19 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float r, float g, float b, float a)
		{
			float[] array = Frames;
			int num = frameIndex << 2;
			int num2 = frameIndex + num;
			int num3 = num2 + 1;
			array[num2] = time;
			int num4 = num2 + 2;
			array[num3] = r;
			int num5 = num2 + 3;
			array[num4] = g;
			int num6 = num2 + 4;
			array[num5] = b;
			array[num6] = a;
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x1523D78", Offset = "0x1523D78", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = skeleton.slots;\n\tv143 = v24.Items;\n\tv139 = this.slotIndex;\n\tv86 = v143[v139 @ X9_v3 (System.Int32)];\n\tv145 = v86.bone;\n\tv437 = ~v145.active;\n\tif (v437) goto L_0060;\n\tv84 = this.frames;\n\tv73 = v84[0] <= time;\n\tif (v73) goto L_006F;\n\tv147 = v86.data;\n\tv114 = blend == 1;\n\tif (v114) goto L_015E;\n\tv457 = blend == 0;\n\tv442 = ~v457;\n\tif (v442) goto L_0060;\n\tv86.r = v147.r;\nL_0060:\n\treturn;\nL_006F:\n\tv460 = v84.Length << 0x20;\n\tv461 = 0xFFFFFFFB00000000 + v460;\n\tv211 = v461 >> 0x1E;\n\tv315 = v84 + v211;\n\tv463 = *([v315 @ X9_v8+20]) < time;\n\tv464 = ~v463;\n\tv465 = *([v315 @ X9_v8+20]) - time;\n\tv467 = v465 == 0;\n\tv472 = ~v464;\n\tv202 = v472 | v467;\n\tif (v202) goto L_012D;\n\tv195 = Spine.Animation::BinarySearch(v84, time, 5);\n\tv321 = v195 - 4;\n\tv316 = v195 - 3;\n\tv188 = v195 - 2;\n\tv185 = v195 - 1;\n\tv183 = v195 - 5;\n\tv599 = v195 * 0x66666667;\n\tv317 = v599 >> 0x20;\n\tv600 = v599 >> 0x3F;\n\tv171 = time - v84[v195 @ X0_v9 (System.Int32)];\n\tv601 = v84[v183 @ X13_v5 (System.Int32)] - v84[v195 @ X0_v9 (System.Int32)];\n\tv212 = v317 >> 1;\n\tv322 = v600 + v212;\n\tv602 = v171 / v601;\n\tv199 = v322 - 1;\n\tv603 = 1f - v602;\n\tv207 = Spine.CurveTimeline::GetCurvePercent(this, v199, v603);\n\tv189 = v195 + 1;\n\tv313 = v195 + 2;\n\tv323 = v195 + 3;\n\tv318 = v195 + 4;\n\tv613 = v84[v313 @ X10_v16 (System.Int32)] - v84[v316 @ X9_v18 (System.Int32)];\n\tv614 = v207 * v613;\n\tv31 = v84[v316 @ X9_v18 (System.Int32)] + v614;\n\tv615 = v84[v189 @ X11_v14 (System.Int32)] - v84[v321 @ X8_v19 (System.Int32)];\n\tv616 = v84[v323 @ X8_v25 (System.Int32)] - v84[v188 @ X11_v12 (System.Int32)];\n\tv530 = v84[v318 @ X9_v23 (System.Int32)] - v84[v185 @ X12_v7 (System.Int32)];\n\tv617 = v207 * v615;\n\tv527 = v207 * v616;\n\tv618 = v207 * v530;\n\tv37 = v84[v321 @ X8_v19 (System.Int32)] + v617;\n\tv515 = v84[v188 @ X11_v12 (System.Int32)] + v527;\n\tv521 = v84[v185 @ X12_v7 (System.Int32)] + v618;\n\tgoto L_014A;\nL_012D:\n\tv486 = v84.Length << 0x20;\n\tv492 = v486 + 0xFFFFFFFC00000000;\n\tv493 = v486 + 0xFFFFFFFD00000000;\n\tv494 = v486 + 0xFFFFFFFF00000000;\n\tv495 = v486 + 0xFFFFFFFE00000000;\n\tv496 = v84 + 0x20;\n\tv497 = v492 >> 0x1E;\n\tv37 = *([v496 @ X12_v6+v497 @ X9_v16 (System.Int32)]);\n\tv499 = v493 >> 0x1E;\n\tv500 = v495 >> 0x1E;\n\tv501 = v494 >> 0x1E;\n\tv31 = *([v496 @ X12_v6+v499 @ X9_v17 (System.Int32)]);\n\tv515 = *([v496 @ X12_v6+v500 @ X8_v18 (System.Int32)]);\n\tv521 = *([v496 @ X12_v6+v501 @ X10_v13 (System.Int32)]);\nL_014A:\n\tv74 = v40 != 1f;\n\tif (v74) goto L_014F;\n\tv86.r = v37;\n\tv86.g = v31;\n\tgoto L_017D;\nL_014F:\n\tv550 = blend == 0;\n\tif (v550) goto L_0167;\n\tv564 = v143[v139 @ X9_v3 (System.Int32)] + 0x20;\n\tv563 = v143[v139 @ X9_v3 (System.Int32)] + 0x24;\n\tv562 = v143[v139 @ X9_v3 (System.Int32)] + 0x28;\n\tv560 = v143[v139 @ X9_v3 (System.Int32)] + 0x2C;\n\tgoto L_016F;\nL_015E:\n\t// 350 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv481 = v147.r - v86.r;\n\tv482 = v481 * v483;\n\tv484 = v86.r + v482;\n\tv86.r = v484;\n\tgoto L_018D;\nL_0167:\n\tv564 = v86.data + 0x28;\n\tv563 = v86.data + 0x2C;\n\tv562 = v86.data + 0x30;\n\tv560 = v86.data + 0x34;\nL_016F:\n\tv575 = v37 - *([v564 @ X8_v13]);\n\tv576 = v31 - *([v563 @ X9_v11]);\n\tv577 = v515 - *([v562 @ X10_v7]);\n\tv578 = v521 - *([v560 @ X11_v6]);\n\tv579 = v575 * v40;\n\tv555 = v576 * v40;\n\tv580 = v577 * v40;\n\tv581 = v578 * v40;\n\tv557 = *([v564 @ X8_v13]) + v579;\n\tv558 = *([v563 @ X9_v11]) + v555;\n\tv515 = *([v562 @ X10_v7]) + v580;\n\tv521 = *([v560 @ X11_v6]) + v581;\n\tv86.r = v557;\n\tv86.g = v558;\nL_017D:\n\tv86.b = v515;\n\tv86.a = v521;\nL_018D:\n\tSpine.Slot::ClampColor(v143[v139 @ X9_v3 (System.Int32)]);\n\treturn;\n\tv157 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 282 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_013e: Expected I4, but got I8
			//IL_015a: Expected O, but got I
			//IL_0490: Expected O, but got I8
			//IL_04a2: Expected I4, but got I8
			//IL_04b4: Expected O, but got I8
			//IL_04c6: Expected O, but got I8
			//IL_04d5: Expected O, but got I
			//IL_04f4: Expected F4, but got I
			//IL_0530: Expected F4, but got I
			//IL_0540: Expected F4, but got I
			//IL_0550: Expected F4, but got I
			//IL_065e: Expected O, but got I
			//IL_0672: Expected O, but got I
			//IL_0686: Expected O, but got I
			//IL_069a: Expected O, but got I
			//IL_05a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_05a8: Expected O, but got Unknown
			//IL_05ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_05bf: Expected O, but got Unknown
			//IL_05d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_05d6: Expected O, but got Unknown
			//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_05ed: Expected O, but got Unknown
			ExposedList<Slot> slots = skeleton.Slots;
			Slot[] items = slots.Items;
			int num = SlotIndex;
			Slot slot = items[num];
			Bone bone = slot.Bone;
			if (!bone.Active)
			{
				return;
			}
			float[] array = Frames;
			if (array[0] > time)
			{
				SlotData data = slot.Data;
				switch (blend)
				{
				case MixBlend.Setup:
					slot.R = data.R;
					return;
				case MixBlend.First:
					break;
				default:
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				float num2 = data.R - slot.R;
				object obj = default(object);
				float num3 = num2 * (float)obj;
				float r = slot.R + num3;
				slot.R = r;
			}
			else
			{
				int num4 = array.Length << 32;
				int num5 = (int)(-21474836480L + num4);
				int num6 = num5 >> 30;
				object obj2 = (nint)array + num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X9_v8+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ X9_v8+20]");
				float num7 = 0f - time;
				bool flag3 = num7 == 0f;
				bool flag4 = !flag2;
				float num28;
				float num35;
				float num36;
				float num37;
				if (!(flag4 || flag3))
				{
					int num8 = Animation.BinarySearch(array, time, 5);
					int num9 = num8 - 4;
					int num10 = num8 - 3;
					int num11 = num8 - 2;
					int num12 = num8 - 1;
					int num13 = num8 - 5;
					int num14 = num8 * 1717986919;
					int num15 = num14 >> 32;
					int num16 = num14 >> 63;
					float num17 = time - array[num8];
					float num18 = array[num13] - array[num8];
					int num19 = num15 >> 1;
					int num20 = num16 + num19;
					float num21 = num17 / num18;
					int frameIndex = num20 - 1;
					float percent = 1f - num21;
					float curvePercent = GetCurvePercent(frameIndex, percent);
					int num22 = num8 + 1;
					int num23 = num8 + 2;
					int num24 = num8 + 3;
					int num25 = num8 + 4;
					float num26 = array[num23] - array[num10];
					float num27 = curvePercent * num26;
					num28 = array[num10] + num27;
					float num29 = array[num22] - array[num9];
					float num30 = array[num24] - array[num11];
					float num31 = array[num25] - array[num12];
					float num32 = curvePercent * num29;
					float num33 = curvePercent * num30;
					float num34 = curvePercent * num31;
					num35 = array[num9] + num32;
					num36 = array[num11] + num33;
					num37 = array[num12] + num34;
				}
				else
				{
					int num38 = array.Length << 32;
					object obj3 = num38 + -17179869184L;
					int num39 = (int)(num38 + -12884901888L);
					object obj4 = num38 + -4294967296L;
					object obj5 = num38 + -8589934592L;
					object obj6 = (nint)array + 32;
					int num40 = (int)((nint)obj3 >> 30);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X12_v6+v497 @ X9_v16 (System.Int32)]");
					num35 = 0f;
					int num41 = num39 >> 30;
					int num42 = (int)((nint)obj5 >> 30);
					int num43 = (int)((nint)obj4 >> 30);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X12_v6+v499 @ X9_v17 (System.Int32)]");
					num28 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X12_v6+v500 @ X8_v18 (System.Int32)]");
					num36 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X12_v6+v501 @ X10_v13 (System.Int32)]");
					num37 = 0f;
				}
				float num44 = default(float);
				if (num44 == 1f)
				{
					slot.R = num35;
					slot.G = num28;
				}
				else
				{
					object obj7;
					object obj8;
					object obj9;
					object obj10;
					if (blend != MixBlend.Setup)
					{
						obj7 = items[num] + 32;
						obj8 = items[num] + 36;
						obj9 = items[num] + 40;
						obj10 = items[num] + 44;
					}
					else
					{
						obj7 = (nint)slot.Data + 40;
						obj8 = (nint)slot.Data + 44;
						obj9 = (nint)slot.Data + 48;
						obj10 = (nint)slot.Data + 52;
					}
					float num45 = num35 - (float)obj7;
					float num46 = num28 - (float)obj8;
					float num47 = num36 - (float)obj9;
					float num48 = num37 - (float)obj10;
					float num49 = num45 * num44;
					float num50 = num46 * num44;
					float num51 = num47 * num44;
					float num52 = num48 * num44;
					float r2 = (float)obj7 + num49;
					float g = (float)obj8 + num50;
					num36 = (float)obj9 + num51;
					num37 = (float)obj10 + num52;
					slot.R = r2;
					slot.G = g;
				}
				slot.B = num36;
				slot.A = num37;
			}
			items[num].ClampColor();
		}
	}
}
