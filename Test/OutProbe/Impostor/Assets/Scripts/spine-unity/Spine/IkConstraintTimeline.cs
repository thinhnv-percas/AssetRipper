using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000019")]
	public class IkConstraintTimeline : CurveTimeline
	{
		[Token(Token = "0x4000074")]
		public const int ENTRIES = 6;

		[Token(Token = "0x4000075")]
		private const int PREV_TIME = -6;

		[Token(Token = "0x4000076")]
		private const int PREV_MIX = -5;

		[Token(Token = "0x4000077")]
		private const int PREV_SOFTNESS = -4;

		[Token(Token = "0x4000078")]
		private const int PREV_BEND_DIRECTION = -3;

		[Token(Token = "0x4000079")]
		private const int PREV_COMPRESS = -2;

		[Token(Token = "0x400007A")]
		private const int PREV_STRETCH = -1;

		[Token(Token = "0x400007B")]
		private const int MIX = 1;

		[Token(Token = "0x400007C")]
		private const int SOFTNESS = 2;

		[Token(Token = "0x400007D")]
		private const int BEND_DIRECTION = 3;

		[Token(Token = "0x400007E")]
		private const int COMPRESS = 4;

		[Token(Token = "0x400007F")]
		private const int STRETCH = 5;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x18")]
		internal int ikConstraintIndex;

		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x1700002E")]
		public override int PropertyId
		{
			[Token(Token = "0x6000088")]
			[Address(RVA = "0x1525D98", Offset = "0x1525D98", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.ikConstraintIndex + 0x9000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IkConstraintIndex + 150994944;
			}
		}

		[Token(Token = "0x1700002F")]
		public int IkConstraintIndex
		{
			[Token(Token = "0x600008A")]
			[Address(RVA = "0x1525E04", Offset = "0x1525E04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ikConstraintIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IkConstraintIndex;
			}
			[Token(Token = "0x6000089")]
			[Address(RVA = "0x1525DA8", Offset = "0x1525DA8", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_000F;\n\tthis.ikConstraintIndex = value;\n\treturn;\nL_000F:\n\tv37 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v37, \"index must be >= 0.\");\n\tthrow v37;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(value & 0x80000000L) == 0)
				{
					ikConstraintIndex = value;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index must be >= 0.");
				throw ex;
			}
		}

		[Token(Token = "0x17000030")]
		public float[] Frames
		{
			[Token(Token = "0x600008B")]
			[Address(RVA = "0x1525E0C", Offset = "0x1525E0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x600008C")]
			[Address(RVA = "0x1525E14", Offset = "0x1525E14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x1525D2C", Offset = "0x1525D2C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37AE5]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 1;\n\tv45 = frameCount + v44;\n\tv46 = v45 << 1;\n\t// 28 NewArr v47 @ X0_v4 (System.Single[]), typeof(System.Single[]), v46 @ X1_v2 (System.Int32)\n\tthis.frames = v47;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IkConstraintTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 1;
			int num2 = frameCount + num;
			int num3 = num2 << 1;
			float[] array = new float[num3];
			Frames = array;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x1525E1C", Offset = "0x1525E1C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 1;\n\tv8 = frameIndex + v6;\n\tv9 = v8 << 1;\n\tv89 = v9 | 1;\n\tv2[v9 @ X10_v3 (System.Int32)] = time;\n\tv110 = v9 + 2;\n\tv2[v89 @ X11_v4 (System.Int32)] = mix;\n\tv111 = v9 + 3;\n\tv2[v110 @ X11_v5 (System.Int32)] = softness;\n\tv112 = v9 + 4;\n\tv2[v111 @ X11_v6 (System.Int32)] = bendDirection;\n\tv189 = compress == 0;\n\tv146 = v9 + 5;\n\tv103 = ~v189;\n\tv102 = ~v103;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_0067;\nL_0067:\n\tv2[v112 @ X11_v7 (System.Int32)] = v101;\n\tv172 = stretch == 0;\n\tv160 = ~v172;\n\tv158 = ~v160;\n\tif (v158) goto L_FFFFFFFF;\n\tgoto L_0077;\nL_0077:\n\tv2[v146 @ X10_v5 (System.Int32)] = v163;\n\treturn;\n\tv20 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float mix, float softness, int bendDirection, bool compress, bool stretch)
		{
			float[] array = Frames;
			int num = frameIndex << 1;
			int num2 = frameIndex + num;
			int num3 = num2 << 1;
			int num4 = num3 | 1;
			array[num3] = time;
			int num5 = num3 + 2;
			array[num4] = mix;
			int num6 = num3 + 3;
			array[num5] = softness;
			int num7 = num3 + 4;
			array[num6] = bendDirection;
			bool flag = !compress;
			int num8 = num3 + 5;
			float num9 = (flag ? 0f : 1f);
			array[num7] = num9;
			float num10 = ((!stretch) ? 0f : 1f);
			array[num8] = num10;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x1525ED8", Offset = "0x1525ED8", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = skeleton.ikConstraints;\n\tv133 = v22.Items;\n\tv128 = this.ikConstraintIndex;\n\tv65 = v133[v128 @ X9_v3 (System.Int32)];\n\tv395 = ~v65.active;\n\tif (v395) goto L_0215;\n\tv63 = this.frames;\n\tv51 = v63[0] <= time;\n\tif (v51) goto L_005E;\n\tv98 = blend == 1;\n\tif (v98) goto L_010B;\n\tv457 = blend == 0;\n\tv440 = ~v457;\n\tif (v440) goto L_0215;\n\tv477 = v65.data;\n\tv475 = v477.mix;\n\tgoto L_0115;\nL_005E:\n\tv460 = v63.Length << 0x20;\n\tv461 = 0xFFFFFFFA00000000 + v460;\n\tv70 = v461 >> 0x1E;\n\tv130 = v63 + v70;\n\tv462 = *([v130 @ X9_v9+20]) < time;\n\tv118 = ~v462;\n\tv112 = *([v130 @ X9_v9+20]) - time;\n\tv100 = v112 == 0;\n\tv463 = ~v118;\n\tv52 = v463 | v100;\n\tif (v52) goto L_00F0;\n\tv183 = Spine.Animation::BinarySearch(v63, time, 6);\n\tv319 = v183 - 5;\n\tv311 = v183 - 4;\n\tv36 = v183 - 6;\n\tv619 = v183 * 0x2AAAAAAB;\n\tv620 = v619 >> 0x3F;\n\tv621 = v619 >> 0x20;\n\tv26 = time - v63[v183 @ X0_v9 (System.Int32)];\n\tv622 = v63[v36 @ X11_v18 (System.Int32)] - v63[v183 @ X0_v9 (System.Int32)];\n\tv138 = v621 + v620;\n\tv623 = v26 / v622;\n\tv46 = v138 - 1;\n\tv624 = 1f - v623;\n\tv60 = Spine.CurveTimeline::GetCurvePercent(this, v46, v624);\n\tv325 = blend == 0;\n\tif (v325) goto L_011C;\n\tv312 = v183 + 1;\n\tv313 = v183 + 2;\n\tv662 = v63[v312 @ X9_v26 (System.Int32)] - v63[v319 @ X8_v18 (System.Int32)];\n\tv663 = v60 * v662;\n\tv664 = v63[v319 @ X8_v18 (System.Int32)] + v663;\n\tv665 = v664 - v65.mix;\n\tv666 = v665 * alpha;\n\tv173 = v65.mix + v666;\n\tv65.mix = v173;\n\tv404 = v63[v313 @ X9_v28 (System.Int32)] - v63[v311 @ X9_v14 (System.Int32)];\n\tv670 = v60 * v404;\n\tv671 = v63[v311 @ X9_v14 (System.Int32)] + v670;\n\tv672 = v671 - v65.softness;\n\tv673 = v672 * alpha;\n\tv420 = v65.softness + v673;\n\tv65.softness = v420;\n\tv674 = direction == 0;\n\tv441 = ~v674;\n\tif (v441) goto L_0215;\n\tgoto L_015E;\nL_00F0:\n\tv139 = v63.Length << 0x20;\n\tv472 = blend == 0;\n\tif (v472) goto L_01A9;\n\tv485 = v139 + 0xFFFFFFFB00000000;\n\tv583 = v63 + 0x20;\n\tv486 = v485 >> 0x1E;\n\tv489 = v139 + 0xFFFFFFFC00000000;\n\tv434 = v489 >> 0x1E;\n\tv490 = *([v583 @ X9_v11+v486 @ X10_v23 (System.Int32)]) - v65.mix;\n\tv491 = v490 * alpha;\n\tv492 = v65.mix + v491;\n\tv65.mix = v492;\n\tv494 = *([v583 @ X9_v11+v434 @ X10_v26 (System.Int32)]) - v65.softness;\n\tv495 = v494 * alpha;\n\tv421 = v65.softness + v495;\n\tv65.softness = v421;\n\tv496 = direction == 0;\n\tv442 = ~v496;\n\tif (v442) goto L_0215;\n\tgoto L_01D3;\nL_010B:\n\tv477 = v65.data;\n\t// 273 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv467 = v477.mix - v65.mix;\n\tv468 = v467 * v469;\n\tv475 = v65.mix + v468;\nL_0115:\n\tv65.mix = v475;\n\tv65.bendDirection = v477.bendDirection;\n\tv65.compress = v477.compress;\n\tv438 = v477.stretch;\n\tgoto L_0209;\nL_011C:\n\tv129 = v65.data;\n\tv305 = v183 + 1;\n\tv306 = v183 + 2;\n\tv677 = v63[v305 @ X10_v36 (System.Int32)] - v63[v319 @ X8_v18 (System.Int32)];\n\tv678 = v60 * v677;\n\tv679 = v63[v319 @ X8_v18 (System.Int32)] + v678;\n\tv680 = v679 - v129.mix;\n\tv681 = v680 * alpha;\n\tv174 = v129.mix + v681;\n\tv65.mix = v174;\n\tv503 = v63[v306 @ X10_v38 (System.Int32)] - v63[v311 @ X9_v14 (System.Int32)];\n\tv685 = v60 * v503;\n\tv686 = v63[v311 @ X9_v14 (System.Int32)] + v685;\n\tv687 = v686 - v129.softness;\n\tv688 = v687 * alpha;\n\tv516 = v129.softness + v688;\n\tv65.softness = v516;\n\tv513 = direction != 1;\n\tif (v513) goto L_015E;\n\tv65.bendDirection = v129.bendDirection;\n\tv65.compress = v129.compress;\n\tv438 = v129.stretch;\n\tgoto L_0209;\nL_015E:\n\tv314 = v183 - 3;\n\tv316 = v183 - 2;\n\tv162 = v63[v314 @ X9_v20 (System.Int32)] != 0x7F800000;\n\tif (v162) goto L_FFFFFFFF;\n\tgoto L_0189;\nL_0189:\n\tv65.bendDirection = v309;\n\tv315 = v183 - 1;\n\tv721 = v63[v316 @ X9_v22 (System.Int32)] == 0;\n\tv190 = ~v721;\n\tv65.compress = v190;\n\tgoto L_0202;\nL_01A9:\n\tv125 = v65.data;\n\tv555 = v139 + 0xFFFFFFFB00000000;\n\tv583 = v63 + 0x20;\n\tv556 = v555 >> 0x1E;\n\tv560 = v139 + 0xFFFFFFFC00000000;\n\tv507 = v560 >> 0x1E;\n\tv561 = *([v583 @ X9_v11+v556 @ X11_v14 (System.Int32)]) - v125.mix;\n\tv562 = v561 * alpha;\n\tv563 = v125.mix + v562;\n\tv65.mix = v563;\n\tv567 = *([v583 @ X9_v11+v507 @ X11_v17 (System.Int32)]) - v125.softness;\n\tv504 = v567 * alpha;\n\tv517 = v125.softness + v504;\n\tv65.softness = v517;\n\tv514 = direction != 1;\n\tif (v514) goto L_01D3;\n\tv65.bendDirection = v125.bendDirection;\n\tv65.compress = v125.compress;\n\tv438 = v125.stretch;\n\tgoto L_0209;\nL_01D3:\n\tv587 = v139 + 0xFFFFFFFD00000000;\n\tv588 = v587 >> 0x1E;\n\tv603 = *([v583 @ X9_v11+v588 @ X10_v11 (System.Int32)]) != 0x7F800000;\n\tif (v603) goto L_FFFFFFFF;\n\tgoto L_01EA;\nL_01EA:\n\tv627 = v139 + 0xFFFFFFFE00000000;\n\tv628 = v627 >> 0x1E;\n\tv65.bendDirection = v625;\n\tv631 = v139 + 0xFFFFFFFF00000000;\n\tv632 = v631 >> 0x1E;\n\tv637 = *([v583 @ X9_v11+v628 @ X11_v10 (System.Int32)]) == 0;\n\tv642 = ~v637;\n\tv65.compress = v642;\n\tv515 = *([v583 @ X9_v11+v632 @ X8_v14 (System.Int32)]);\nL_0202:\n\tv532 = v515 == 0;\n\tv512 = ~v532;\nL_0209:\n\tv65.stretch = v438;\nL_0215:\n\treturn;\n\tv148 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 368 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_012c: Expected I4, but got I8
			//IL_0148: Expected O, but got I
			//IL_0873: Expected I4, but got I8
			//IL_0882: Expected O, but got I
			//IL_08a2: Expected O, but got I8
			//IL_047e: Expected I4, but got I8
			//IL_048d: Expected O, but got I
			//IL_04ad: Expected O, but got I8
			//IL_09b1: Expected I4, but got I8
			//IL_0aad: Expected O, but got I8
			//IL_0adb: Expected O, but got I8
			//IL_0b29: Expected F4, but got I
			//IL_0a6d: Expected I4, but got F4
			ExposedList<IkConstraint> ikConstraints = skeleton.IkConstraints;
			IkConstraint[] items = ikConstraints.Items;
			int num = IkConstraintIndex;
			IkConstraint ikConstraint = items[num];
			if (!ikConstraint.Active)
			{
				return;
			}
			float[] array = Frames;
			bool stretch;
			if (array[0] > time)
			{
				IkConstraintData data;
				float mix;
				switch (blend)
				{
				case MixBlend.Setup:
					data = ikConstraint.Data;
					mix = data.Mix;
					break;
				case MixBlend.First:
				{
					data = ikConstraint.Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = data.Mix - ikConstraint.Mix;
					object obj = default(object);
					float num3 = num2 * (float)obj;
					mix = ikConstraint.Mix + num3;
					break;
				}
				default:
					return;
				}
				ikConstraint.Mix = mix;
				ikConstraint.BendDirection = data.BendDirection;
				ikConstraint.compress = data.Compress;
				stretch = data.Stretch;
			}
			else
			{
				int num4 = array.Length << 32;
				int num5 = (int)(-25769803776L + num4);
				int num6 = num5 >> 30;
				object obj2 = (nint)array + num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X9_v9+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v130 @ X9_v9+20]");
				float num7 = 0f - time;
				bool flag3 = num7 == 0f;
				bool flag4 = !flag2;
				float num47;
				if (!(flag4 || flag3))
				{
					int num8 = Animation.BinarySearch(array, time, 6);
					int num9 = num8 - 5;
					int num10 = num8 - 4;
					int num11 = num8 - 6;
					int num12 = num8 * 715827883;
					int num13 = num12 >> 63;
					int num14 = num12 >> 32;
					float num15 = time - array[num8];
					float num16 = array[num11] - array[num8];
					int num17 = num14 + num13;
					float num18 = num15 / num16;
					int frameIndex = num17 - 1;
					float percent = 1f - num18;
					float curvePercent = GetCurvePercent(frameIndex, percent);
					if (blend != MixBlend.Setup)
					{
						int num19 = num8 + 1;
						int num20 = num8 + 2;
						float num21 = array[num19] - array[num9];
						float num22 = curvePercent * num21;
						float num23 = array[num9] + num22;
						float num24 = num23 - ikConstraint.Mix;
						float num25 = num24 * alpha;
						float mix2 = ikConstraint.Mix + num25;
						ikConstraint.Mix = mix2;
						float num26 = array[num20] - array[num10];
						float num27 = curvePercent * num26;
						float num28 = array[num10] + num27;
						float num29 = num28 - ikConstraint.Softness;
						float num30 = num29 * alpha;
						float softness = ikConstraint.Softness + num30;
						ikConstraint.Softness = softness;
						if (direction != MixDirection.In)
						{
							return;
						}
					}
					else
					{
						IkConstraintData data2 = ikConstraint.Data;
						int num31 = num8 + 1;
						int num32 = num8 + 2;
						float num33 = array[num31] - array[num9];
						float num34 = curvePercent * num33;
						float num35 = array[num9] + num34;
						float num36 = num35 - data2.Mix;
						float num37 = num36 * alpha;
						float mix3 = data2.Mix + num37;
						ikConstraint.Mix = mix3;
						float num38 = array[num32] - array[num10];
						float num39 = curvePercent * num38;
						float num40 = array[num10] + num39;
						float num41 = num40 - data2.Softness;
						float num42 = num41 * alpha;
						float softness2 = data2.Softness + num42;
						ikConstraint.Softness = softness2;
						if (direction == MixDirection.Out)
						{
							ikConstraint.BendDirection = data2.BendDirection;
							ikConstraint.compress = data2.Compress;
							stretch = data2.Stretch;
							goto IL_0a4e;
						}
					}
					int num43 = num8 - 3;
					int num44 = num8 - 2;
					float num45 = ((array[num43] != float.PositiveInfinity) ? array[num43] : -0f);
					ikConstraint.BendDirection = (int)num45;
					int num46 = num8 - 1;
					bool flag5 = array[num44] == 0f;
					bool compress = !flag5;
					ikConstraint.compress = compress;
					num47 = array[num46];
				}
				else
				{
					int num48 = array.Length << 32;
					if (blend != MixBlend.Setup)
					{
						int num49 = (int)(num48 + -21474836480L);
						object obj3 = (nint)array + 32;
						int num50 = num49 >> 30;
						object obj4 = num48 + -17179869184L;
						int num51 = (int)((nint)obj4 >> 30);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v486 @ X10_v23 (System.Int32)]");
						float num52 = 0f - ikConstraint.Mix;
						float num53 = num52 * alpha;
						float mix4 = ikConstraint.Mix + num53;
						ikConstraint.Mix = mix4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v434 @ X10_v26 (System.Int32)]");
						float num54 = 0f - ikConstraint.Softness;
						float num55 = num54 * alpha;
						float softness3 = ikConstraint.Softness + num55;
						ikConstraint.Softness = softness3;
						if (direction != MixDirection.In)
						{
							return;
						}
					}
					else
					{
						IkConstraintData data3 = ikConstraint.Data;
						int num56 = (int)(num48 + -21474836480L);
						object obj3 = (nint)array + 32;
						int num57 = num56 >> 30;
						object obj5 = num48 + -17179869184L;
						int num58 = (int)((nint)obj5 >> 30);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v556 @ X11_v14 (System.Int32)]");
						float num59 = 0f - data3.Mix;
						float num60 = num59 * alpha;
						float mix5 = data3.Mix + num60;
						ikConstraint.Mix = mix5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v507 @ X11_v17 (System.Int32)]");
						float num61 = 0f - data3.Softness;
						float num62 = num61 * alpha;
						float softness4 = data3.Softness + num62;
						ikConstraint.Softness = softness4;
						if (direction == MixDirection.Out)
						{
							ikConstraint.BendDirection = data3.BendDirection;
							ikConstraint.compress = data3.Compress;
							stretch = data3.Stretch;
							goto IL_0a4e;
						}
					}
					int num63 = (int)(num48 + -12884901888L);
					int num64 = num63 >> 30;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v588 @ X10_v11 (System.Int32)]");
					int bendDirection;
					if ((nint)0 == 2139095040)
					{
						bendDirection = int.MinValue;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v588 @ X10_v11 (System.Int32)]");
						bendDirection = 0;
					}
					object obj6 = num48 + -8589934592L;
					int num65 = (int)((nint)obj6 >> 30);
					ikConstraint.BendDirection = bendDirection;
					object obj7 = num48 + -4294967296L;
					int num66 = (int)((nint)obj7 >> 30);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v628 @ X11_v10 (System.Int32)]");
					bool flag6 = (nint)0 == 0;
					bool compress2 = !flag6;
					ikConstraint.compress = compress2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X9_v11+v632 @ X8_v14 (System.Int32)]");
					num47 = 0f;
				}
				bool flag7 = num47 == 0f;
				bool flag8 = !flag7;
				stretch = flag8;
			}
			goto IL_0a4e;
			IL_0a4e:
			ikConstraint.stretch = stretch;
		}
	}
}
