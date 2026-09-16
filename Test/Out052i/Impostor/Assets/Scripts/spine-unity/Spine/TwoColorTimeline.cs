using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000014")]
	public class TwoColorTimeline : CurveTimeline, ISlotTimeline
	{
		[Token(Token = "0x4000057")]
		public const int ENTRIES = 8;

		[Token(Token = "0x4000058")]
		protected const int PREV_TIME = -8;

		[Token(Token = "0x4000059")]
		protected const int PREV_R = -7;

		[Token(Token = "0x400005A")]
		protected const int PREV_G = -6;

		[Token(Token = "0x400005B")]
		protected const int PREV_B = -5;

		[Token(Token = "0x400005C")]
		protected const int PREV_A = -4;

		[Token(Token = "0x400005D")]
		protected const int PREV_R2 = -3;

		[Token(Token = "0x400005E")]
		protected const int PREV_G2 = -2;

		[Token(Token = "0x400005F")]
		protected const int PREV_B2 = -1;

		[Token(Token = "0x4000060")]
		protected const int R = 1;

		[Token(Token = "0x4000061")]
		protected const int G = 2;

		[Token(Token = "0x4000062")]
		protected const int B = 3;

		[Token(Token = "0x4000063")]
		protected const int A = 4;

		[Token(Token = "0x4000064")]
		protected const int R2 = 5;

		[Token(Token = "0x4000065")]
		protected const int G2 = 6;

		[Token(Token = "0x4000066")]
		protected const int B2 = 7;

		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x18")]
		internal int slotIndex;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x17000019")]
		public override int PropertyId
		{
			[Token(Token = "0x6000057")]
			[Address(RVA = "0x1524150", Offset = "0x1524150", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.slotIndex + 0xE000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex + 234881024;
			}
		}

		[Token(Token = "0x1700001A")]
		public int SlotIndex
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x15241BC", Offset = "0x15241BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slotIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SlotIndex;
			}
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x1524160", Offset = "0x1524160", Length = "0x5C")]
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

		[Token(Token = "0x1700001B")]
		public float[] Frames
		{
			[Token(Token = "0x600005A")]
			[Address(RVA = "0x15241C4", Offset = "0x15241C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x15240E8", Offset = "0x15240E8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37ADE]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 3;\n\t// 26 NewArr v45 @ X0_v4 (System.Single[]), typeof(System.Single[]), v44 @ X1_v2 (System.Int32)\n\tthis.frames = v45;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TwoColorTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 3;
			float[] array = new float[num];
			frames = array;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x15241CC", Offset = "0x15241CC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 3;\n\tv75 = v6 | 1;\n\tv2[v6 @ X11_v2 (System.Int32)] = time;\n\tv145 = v6 | 2;\n\tv2[v75 @ X11_v4 (System.Int32)] = r;\n\tv146 = v6 | 3;\n\tv2[v145 @ X11_v5 (System.Int32)] = g;\n\tv147 = v6 | 4;\n\tv2[v146 @ X11_v6 (System.Int32)] = b;\n\tv148 = v6 | 5;\n\tv2[v147 @ X11_v7 (System.Int32)] = a;\n\tv149 = v6 | 6;\n\tv2[v148 @ X11_v9 (System.Int32)] = r2;\n\tv96 = v6 | 7;\n\tv2[v149 @ X11_v10 (System.Int32)] = g2;\n\tv2[v96 @ X10_v4 (System.Int32)] = b2;\n\treturn;\n\tv18 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float r, float g, float b, float a, float r2, float g2, float b2)
		{
			float[] array = Frames;
			int num = frameIndex << 3;
			int num2 = num | 1;
			array[num] = time;
			int num3 = num | 2;
			array[num2] = r;
			int num4 = num | 3;
			array[num3] = g;
			int num5 = num | 4;
			array[num4] = b;
			int num6 = num | 5;
			array[num5] = a;
			int num7 = num | 6;
			array[num6] = r2;
			int num8 = num | 7;
			array[num7] = g2;
			array[num8] = b2;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x1524294", Offset = "0x1524294", Length = "0x524")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = skeleton.slots;\n\tv178 = v30.Items;\n\tv174 = this.slotIndex;\n\tv121 = v178[v174 @ X9_v3 (System.Int32)];\n\tv180 = v121.bone;\n\tv560 = ~v180.active;\n\tif (v560) goto L_006D;\n\tv118 = this.frames;\n\tv106 = v118[0] <= time;\n\tif (v106) goto L_007B;\n\tv119 = v121.data;\n\tv149 = blend == 1;\n\tif (v149) goto L_01EE;\n\tv579 = blend == 0;\n\tv564 = ~v579;\n\tif (v564) goto L_006D;\n\tv121.r = v119.r;\n\tSpine.Slot::ClampColor(v178[v174 @ X9_v3 (System.Int32)]);\n\tv121.r2 = v119.r2;\n\tv701 = v119.b2;\n\tgoto L_0202;\nL_006D:\n\treturn;\nL_007B:\n\tv581 = v118.Length << 0x20;\n\tv582 = 0xFFFFFFF800000000 + v581;\n\tv268 = v582 >> 0x1E;\n\tv420 = v118 + v268;\n\tv584 = *([v420 @ X9_v7+20]) < time;\n\tv585 = ~v584;\n\tv586 = *([v420 @ X9_v7+20]) - time;\n\tv588 = v586 == 0;\n\tv593 = ~v585;\n\tv258 = v593 | v588;\n\tif (v258) goto L_01A3;\n\tv254 = Spine.Animation::BinarySearch(v118, time, 8);\n\tv425 = v254 - 7;\n\tv421 = v254 - 6;\n\tv229 = v254 - 5;\n\tv225 = v254 - 4;\n\tv221 = v254 - 3;\n\tv218 = v254 - 2;\n\tv215 = v254 - 1;\n\tv213 = v254 - 8;\n\tv422 = v254 + 7;\n\tv799 = v254 < 0;\n\tv802 = v254 ^ v254;\n\tv803 = v254 & v802;\n\tv804 = v803 < 0;\n\tv805 = v799 == v804;\n\tv259 = ~v805;\n\tv209 = ~v259;\n\tif (v209) goto L_FFFFFFFF;\n\tgoto L_0122;\nL_0122:\n\tv207 = time - v118[v254 @ X0_v11 (System.Int32)];\n\tv809 = v118[v213 @ X16_v5 (System.Int32)] - v118[v254 @ X0_v11 (System.Int32)];\n\tv426 = v808 >> 3;\n\tv810 = v207 / v809;\n\tv252 = v426 - 1;\n\tv811 = 1f - v810;\n\tv264 = Spine.CurveTimeline::GetCurvePercent(this, v252, v811);\n\tv219 = v254 + 1;\n\tv418 = v254 + 2;\n\tv231 = v254 + 3;\n\tv227 = v254 + 4;\n\tv223 = v254 + 5;\n\tv427 = v254 + 6;\n\tv423 = v254 + 7;\n\tv830 = v118[v418 @ X10_v15 (System.Int32)] - v118[v421 @ X9_v20 (System.Int32)];\n\tv831 = v264 * v830;\n\tv37 = v118[v421 @ X9_v20 (System.Int32)] + v831;\n\tv832 = v118[v219 @ X14_v13 (System.Int32)] - v118[v425 @ X8_v18 (System.Int32)];\n\tv833 = v118[v231 @ X11_v13 (System.Int32)] - v118[v229 @ X11_v11 (System.Int32)];\n\tv834 = v118[v227 @ X12_v12 (System.Int32)] - v118[v225 @ X12_v10 (System.Int32)];\n\tv835 = v118[v223 @ X13_v13 (System.Int32)] - v118[v221 @ X13_v11 (System.Int32)];\n\tv836 = v118[v427 @ X8_v23 (System.Int32)] - v118[v218 @ X14_v11 (System.Int32)];\n\tv837 = v118[v423 @ X9_v23 (System.Int32)] - v118[v215 @ X15_v7 (System.Int32)];\n\tv838 = v264 * v832;\n\tv659 = v264 * v833;\n\tv665 = v264 * v834;\n\tv663 = v264 * v835;\n\tv662 = v264 * v836;\n\tv661 = v264 * v837;\n\tv52 = v118[v425 @ X8_v18 (System.Int32)] + v838;\n\tv61 = v118[v229 @ X11_v11 (System.Int32)] + v659;\n\tv116 = v118[v225 @ X12_v10 (System.Int32)] + v665;\n\tv92 = v118[v221 @ X13_v11 (System.Int32)] + v663;\n\tv96 = v118[v218 @ X14_v11 (System.Int32)] + v662;\n\tv110 = v118[v215 @ X15_v7 (System.Int32)] + v661;\n\tgoto L_01CE;\nL_01A3:\n\tv611 = v118.Length << 0x20;\n\tv622 = v611 + 0xFFFFFFF900000000;\n\tv623 = v611 + 0xFFFFFFFA00000000;\n\tv624 = v611 + 0xFFFFFFFB00000000;\n\tv625 = v611 + 0xFFFFFFFC00000000;\n\tv626 = v611 + 0xFFFFFFFD00000000;\n\tv627 = v611 + 0xFFFFFFFF00000000;\n\tv628 = v611 + 0xFFFFFFFE00000000;\n\tv629 = v118 + 0x20;\n\tv630 = v622 >> 0x1E;\n\tv52 = *([v629 @ X15_v6+v630 @ X9_v15 (System.Int32)]);\n\tv632 = v623 >> 0x1E;\n\tv37 = *([v629 @ X15_v6+v632 @ X9_v16 (System.Int32)]);\n\tv634 = v624 >> 0x1E;\n\tv61 = *([v629 @ X15_v6+v634 @ X9_v17 (System.Int32)]);\n\tv636 = v625 >> 0x1E;\n\tv116 = *([v629 @ X15_v6+v636 @ X9_v18 (System.Int32)]);\n\tv638 = v626 >> 0x1E;\n\tv639 = v628 >> 0x1E;\n\tv640 = v627 >> 0x1E;\n\tv92 = *([v629 @ X15_v6+v638 @ X9_v19 (System.Int32)]);\n\tv96 = *([v629 @ X15_v6+v639 @ X8_v17 (System.Int32)]);\n\tv110 = *([v629 @ X15_v6+v640 @ X10_v12 (System.Int32)]);\nL_01CE:\n\tv107 = v55 != 1f;\n\tif (v107) goto L_01DB;\n\tv121.r = v52;\n\tv121.g = v37;\n\tv121.b = v61;\n\tv121.a = v116;\n\tSpine.Slot::ClampColor(v178[v174 @ X9_v3 (System.Int32)]);\n\tv121.r2 = v92;\n\tv121.g2 = v96;\n\tv121.b2 = v110;\n\tgoto L_0247;\nL_01DB:\n\tv707 = blend == 0;\n\tif (v707) goto L_0207;\n\tv741 = v178[v174 @ X9_v3 (System.Int32)] + 0x20;\n\tv740 = v178[v174 @ X9_v3 (System.Int32)] + 0x24;\n\tv739 = v178[v174 @ X9_v3 (System.Int32)] + 0x28;\n\tv719 = v178[v174 @ X9_v3 (System.Int32)] + 0x2C;\n\tv718 = v178[v174 @ X9_v3 (System.Int32)] + 0x30;\n\tv717 = v178[v174 @ X9_v3 (System.Int32)] + 0x34;\n\tv716 = v178[v174 @ X9_v3 (System.Int32)] + 0x38;\n\tgoto L_0215;\nL_01EE:\n\t// 494 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv605 = v121.r - v119.r;\n\tv606 = v605 * v607;\n\tv608 = v121.r + v606;\n\tv121.r = v608;\n\tSpine.Slot::ClampColor(v178[v174 @ X9_v3 (System.Int32)]);\n\tv650 = v121.r2 - v119.r2;\n\tv651 = v650 * v607;\n\tv652 = v121.r2 + v651;\n\tv121.r2 = v652;\n\tv655 = v121.b2 - v119.b2;\n\tv656 = v655 * v55;\n\tv701 = v121.b2 + v656;\nL_0202:\n\tv121.b2 = v701;\n\tgoto L_0247;\nL_0207:\n\tv741 = v121.data + 0x28;\n\tv740 = v121.data + 0x2C;\n\tv739 = v121.data + 0x30;\n\tv719 = v121.data + 0x34;\n\tv718 = v121.data + 0x38;\n\tv717 = v121.data + 0x3C;\n\tv716 = v121.data + 0x40;\nL_0215:\n\tv760 = v52 - *([v741 @ X8_v12]);\n\tv761 = v37 - *([v740 @ X9_v9]);\n\tv762 = v61 - *([v739 @ X10_v6]);\n\tv763 = v116 - *([v719 @ X11_v5]);\n\tv764 = v760 * v55;\n\tv708 = v761 * v55;\n\tv765 = v762 * v55;\n\tv766 = v763 * v55;\n\tv767 = *([v741 @ X8_v12]) + v764;\n\tv712 = *([v740 @ X9_v9]) + v708;\n\tv768 = *([v739 @ X10_v6]) + v765;\n\tv769 = *([v719 @ X11_v5]) + v766;\n\tv121.r = v767;\n\tv121.g = v712;\n\tv121.b = v768;\n\tv121.a = v769;\n\tSpine.Slot::ClampColor(v178[v174 @ X9_v3 (System.Int32)]);\n\tv771 = v92 - *([v718 @ X12_v5]);\n\tv772 = v96 - *([v717 @ X13_v5]);\n\tv773 = v110 - *([v716 @ X14_v5]);\n\tv774 = v771 * v55;\n\tv775 = v772 * v55;\n\tv776 = v773 * v55;\n\tv737 = *([v718 @ X12_v5]) + v774;\n\tv715 = *([v717 @ X13_v5]) + v775;\n\tv714 = *([v716 @ X14_v5]) + v776;\n\tv121.r2 = v737;\n\tv121.g2 = v715;\n\tv121.b2 = v714;\nL_0247:\n\tSpine.Slot::ClampSecondColor(v178[v174 @ X9_v3 (System.Int32)]);\n\treturn;\n\tv192 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 400 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_0170: Expected O, but got I8
			//IL_018d: Expected O, but got I
			//IL_05cf: Expected I4, but got I8
			//IL_05e1: Expected I4, but got I8
			//IL_05f3: Expected I4, but got I8
			//IL_0605: Expected O, but got I8
			//IL_0617: Expected I4, but got I8
			//IL_0629: Expected O, but got I8
			//IL_063b: Expected O, but got I8
			//IL_064a: Expected O, but got I
			//IL_0668: Expected F4, but got I
			//IL_0686: Expected F4, but got I
			//IL_06a4: Expected F4, but got I
			//IL_06c3: Expected F4, but got I
			//IL_06ff: Expected F4, but got I
			//IL_070f: Expected F4, but got I
			//IL_071f: Expected F4, but got I
			//IL_095c: Expected O, but got I
			//IL_0970: Expected O, but got I
			//IL_0984: Expected O, but got I
			//IL_0998: Expected O, but got I
			//IL_09ac: Expected O, but got I
			//IL_09c0: Expected O, but got I
			//IL_09d4: Expected O, but got I
			//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_07ca: Expected O, but got Unknown
			//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_07e1: Expected O, but got Unknown
			//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_07f8: Expected O, but got Unknown
			//IL_080a: Unknown result type (might be due to invalid IL or missing references)
			//IL_080f: Expected O, but got Unknown
			//IL_0821: Unknown result type (might be due to invalid IL or missing references)
			//IL_0826: Expected O, but got Unknown
			//IL_0838: Unknown result type (might be due to invalid IL or missing references)
			//IL_083d: Expected O, but got Unknown
			//IL_084f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0854: Expected O, but got Unknown
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
			float num8 = default(float);
			if (array[0] > time)
			{
				SlotData data = slot.Data;
				float b;
				switch (blend)
				{
				case MixBlend.Setup:
					slot.R = data.R;
					items[num].ClampColor();
					slot.R2 = data.R2;
					b = data.B2;
					break;
				default:
					return;
				case MixBlend.First:
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = slot.R - data.R;
					object obj = default(object);
					float num3 = num2 * (float)obj;
					float r = slot.R + num3;
					slot.R = r;
					items[num].ClampColor();
					float num4 = slot.R2 - data.R2;
					float num5 = num4 * (float)obj;
					float r2 = slot.R2 + num5;
					slot.R2 = r2;
					float num6 = slot.B2 - data.B2;
					float num7 = num6 * num8;
					b = slot.B2 + num7;
					break;
				}
				}
				slot.B2 = b;
			}
			else
			{
				int num9 = array.Length << 32;
				object obj2 = -34359738368L + num9;
				int num10 = (int)((nint)obj2 >> 30);
				object obj3 = (nint)array + num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X9_v7+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X9_v7+20]");
				float num11 = 0f - time;
				bool flag3 = num11 == 0f;
				bool flag4 = !flag2;
				float num38;
				float num51;
				float num52;
				float num53;
				float num54;
				float num55;
				float num56;
				if (!(flag4 || flag3))
				{
					int num12 = Animation.BinarySearch(array, time, 8);
					int num13 = num12 - 7;
					int num14 = num12 - 6;
					int num15 = num12 - 5;
					int num16 = num12 - 4;
					int num17 = num12 - 3;
					int num18 = num12 - 2;
					int num19 = num12 - 1;
					int num20 = num12 - 8;
					int num21 = num12 + 7;
					bool flag5 = num12 < 0;
					int num22 = num12 ^ num12;
					int num23 = num12 & num22;
					bool flag6 = num23 < 0;
					int num24 = ((flag5 == flag6) ? num12 : num21);
					float num25 = time - array[num12];
					float num26 = array[num20] - array[num12];
					int num27 = num24 >> 3;
					float num28 = num25 / num26;
					int frameIndex = num27 - 1;
					float percent = 1f - num28;
					float curvePercent = GetCurvePercent(frameIndex, percent);
					int num29 = num12 + 1;
					int num30 = num12 + 2;
					int num31 = num12 + 3;
					int num32 = num12 + 4;
					int num33 = num12 + 5;
					int num34 = num12 + 6;
					int num35 = num12 + 7;
					float num36 = array[num30] - array[num14];
					float num37 = curvePercent * num36;
					num38 = array[num14] + num37;
					float num39 = array[num29] - array[num13];
					float num40 = array[num31] - array[num15];
					float num41 = array[num32] - array[num16];
					float num42 = array[num33] - array[num17];
					float num43 = array[num34] - array[num18];
					float num44 = array[num35] - array[num19];
					float num45 = curvePercent * num39;
					float num46 = curvePercent * num40;
					float num47 = curvePercent * num41;
					float num48 = curvePercent * num42;
					float num49 = curvePercent * num43;
					float num50 = curvePercent * num44;
					num51 = array[num13] + num45;
					num52 = array[num15] + num46;
					num53 = array[num16] + num47;
					num54 = array[num17] + num48;
					num55 = array[num18] + num49;
					num56 = array[num19] + num50;
				}
				else
				{
					int num57 = array.Length << 32;
					int num58 = (int)(num57 + -30064771072L);
					int num59 = (int)(num57 + -25769803776L);
					int num60 = (int)(num57 + -21474836480L);
					object obj4 = num57 + -17179869184L;
					int num61 = (int)(num57 + -12884901888L);
					object obj5 = num57 + -4294967296L;
					object obj6 = num57 + -8589934592L;
					object obj7 = (nint)array + 32;
					int num62 = num58 >> 30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v630 @ X9_v15 (System.Int32)]");
					num51 = 0f;
					int num63 = num59 >> 30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v632 @ X9_v16 (System.Int32)]");
					num38 = 0f;
					int num64 = num60 >> 30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v634 @ X9_v17 (System.Int32)]");
					num52 = 0f;
					int num65 = (int)((nint)obj4 >> 30);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v636 @ X9_v18 (System.Int32)]");
					num53 = 0f;
					int num66 = num61 >> 30;
					int num67 = (int)((nint)obj6 >> 30);
					int num68 = (int)((nint)obj5 >> 30);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v638 @ X9_v19 (System.Int32)]");
					num54 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v639 @ X8_v17 (System.Int32)]");
					num55 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v629 @ X15_v6+v640 @ X10_v12 (System.Int32)]");
					num56 = 0f;
				}
				if (num8 == 1f)
				{
					slot.R = num51;
					slot.G = num38;
					slot.B = num52;
					slot.A = num53;
					items[num].ClampColor();
					slot.R2 = num54;
					slot.G2 = num55;
					slot.B2 = num56;
				}
				else
				{
					object obj8;
					object obj9;
					object obj10;
					object obj11;
					object obj12;
					object obj13;
					object obj14;
					if (blend != MixBlend.Setup)
					{
						obj8 = items[num] + 32;
						obj9 = items[num] + 36;
						obj10 = items[num] + 40;
						obj11 = items[num] + 44;
						obj12 = items[num] + 48;
						obj13 = items[num] + 52;
						obj14 = items[num] + 56;
					}
					else
					{
						obj8 = (nint)slot.Data + 40;
						obj9 = (nint)slot.Data + 44;
						obj10 = (nint)slot.Data + 48;
						obj11 = (nint)slot.Data + 52;
						obj12 = (nint)slot.Data + 56;
						obj13 = (nint)slot.Data + 60;
						obj14 = (nint)slot.Data + 64;
					}
					float num69 = num51 - (float)obj8;
					float num70 = num38 - (float)obj9;
					float num71 = num52 - (float)obj10;
					float num72 = num53 - (float)obj11;
					float num73 = num69 * num8;
					float num74 = num70 * num8;
					float num75 = num71 * num8;
					float num76 = num72 * num8;
					float r3 = (float)obj8 + num73;
					float g = (float)obj9 + num74;
					float b2 = (float)obj10 + num75;
					float a = (float)obj11 + num76;
					slot.R = r3;
					slot.G = g;
					slot.B = b2;
					slot.A = a;
					items[num].ClampColor();
					float num77 = num54 - (float)obj12;
					float num78 = num55 - (float)obj13;
					float num79 = num56 - (float)obj14;
					float num80 = num77 * num8;
					float num81 = num78 * num8;
					float num82 = num79 * num8;
					float r4 = (float)obj12 + num80;
					float g2 = (float)obj13 + num81;
					float b3 = (float)obj14 + num82;
					slot.R2 = r4;
					slot.G2 = g2;
					slot.B2 = b3;
				}
			}
			items[num].ClampSecondColor();
		}
	}
}
