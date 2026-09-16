using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200000F")]
	public class RotateTimeline : CurveTimeline, IBoneTimeline
	{
		[Token(Token = "0x400003D")]
		public const int ENTRIES = 2;

		[Token(Token = "0x400003E")]
		internal const int PREV_TIME = -2;

		[Token(Token = "0x400003F")]
		internal const int PREV_ROTATION = -1;

		[Token(Token = "0x4000040")]
		internal const int ROTATION = 1;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x18")]
		internal int boneIndex;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x1700000E")]
		public override int PropertyId
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x1522B00", Offset = "0x1522B00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.boneIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PropertyId;
			}
		}

		[Token(Token = "0x1700000F")]
		public int BoneIndex
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x1522B64", Offset = "0x1522B64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.boneIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PropertyId;
			}
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x1522B08", Offset = "0x1522B08", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_000F;\n\tthis.boneIndex = value;\n\treturn;\nL_000F:\n\tv37 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v37, \"index must be >= 0.\");\n\tthrow v37;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(value & 0x80000000L) == 0)
				{
					boneIndex = value;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index must be >= 0.");
				throw ex;
			}
		}

		[Token(Token = "0x17000010")]
		public float[] Frames
		{
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x1522B6C", Offset = "0x1522B6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x1522B74", Offset = "0x1522B74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x1522A98", Offset = "0x1522A98", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37ADA]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 1;\n\t// 26 NewArr v45 @ X0_v4 (System.Single[]), typeof(System.Single[]), v44 @ X1_v2 (System.Int32)\n\tthis.frames = v45;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RotateTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 1;
			float[] array = new float[num];
			Frames = array;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x1522B7C", Offset = "0x1522B7C", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 1;\n\tv75 = v6 | 1;\n\tv2[v6 @ X10_v2 (System.Int32)] = time;\n\tv2[v75 @ X10_v4 (System.Int32)] = degrees;\n\treturn;\n\tv18 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float degrees)
		{
			float[] array = Frames;
			int num = frameIndex << 1;
			int num2 = num | 1;
			array[num] = time;
			array[num2] = degrees;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x1522BC8", Offset = "0x1522BC8", Length = "0x3CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = skeleton.bones;\n\tv138 = v20.Items;\n\tv133 = this.boneIndex;\n\tv71 = v138[v133 @ X9_v3 (System.Int32)];\n\tv323 = ~v71.active;\n\tif (v323) goto L_01C7;\n\tv69 = this.frames;\n\tv54 = v69[0] <= time;\n\tif (v54) goto L_005D;\n\tv104 = blend == 1;\n\tif (v104) goto L_0115;\n\tv393 = blend == 0;\n\tv376 = ~v393;\n\tif (v376) goto L_01C7;\n\tv141 = v71.data;\n\tv343 = v141.rotation;\n\tgoto L_01BC;\nL_005D:\n\tv395 = v69.Length << 0x20;\n\tv396 = 0xFFFFFFFE00000000 + v395;\n\tv193 = v396 >> 0x1E;\n\tv397 = v69 + v193;\n\tv399 = *([v397 @ X9_v10+20]) < time;\n\tv400 = ~v399;\n\tv401 = *([v397 @ X9_v10+20]) - time;\n\tv403 = v401 == 0;\n\tv408 = ~v400;\n\tv183 = v408 | v403;\n\tif (v183) goto L_00F4;\n\tv178 = Spine.Animation::BinarySearch(v69, time, 2);\n\tv251 = v178 - 1;\n\tv245 = v178 - 2;\n\tv172 = time - v69[v178 @ X0_v8 (System.Int32)];\n\tv570 = v69[v245 @ X10_v6 (System.Int32)] - v69[v178 @ X0_v8 (System.Int32)];\n\tv36 = v178 >> 1;\n\tv571 = v172 / v570;\n\tv51 = v36 - 1;\n\tv572 = 1f - v571;\n\tv189 = Spine.CurveTimeline::GetCurvePercent(this, v51, v572);\n\tv252 = v178 + 1;\n\tv579 = v69[v252 @ X8_v24 (System.Int32)] - v69[v251 @ X8_v22 (System.Int32)];\n\tv580 = v579 / 0xC3B40000;\n\tv584 = v580 + 16384.499999999996d;\n\tv587 = 0x4000 - v584;\n\tv373 = v587 * 0x168;\n\tv24 = v584 != 0x7FF0000000000000;\n\tif (v24) goto L_FFFFFFFF;\n\tgoto L_00D6;\nL_00D6:\n\tv39 = v579 - v33;\n\tv135 = blend - 1;\n\tv601 = v189 * v39;\n\tv602 = v135 < 2;\n\tv124 = ~v602;\n\tv622 = v69[v251 @ X8_v22 (System.Int32)] + v601;\n\tv56 = ~v124;\n\tif (v56) goto L_0167;\n\tv377 = blend == 0;\n\tif (v377) goto L_0190;\n\tv338 = blend != 3;\n\tif (v338) goto L_01C7;\n\tv458 = v71.rotation;\n\tgoto L_0170;\nL_00F4:\n\tv440 = v69.Length << 0x20;\n\tv441 = v440 + 0xFFFFFFFF00000000;\n\tv75 = v441 >> 0x1E;\n\tv442 = v69 + v75;\n\tv562 = *([v442 @ X8_v14+20]);\n\tv374 = blend - 1;\n\tv443 = v374 < 2;\n\tv123 = ~v443;\n\tv55 = ~v123;\n\tif (v55) goto L_013C;\n\tv378 = blend == 0;\n\tif (v378) goto L_01B6;\n\tv339 = blend != 3;\n\tif (v339) goto L_01C7;\n\tv461 = v71.rotation;\n\tgoto L_0164;\nL_0115:\n\tv142 = v71.data;\n\tv461 = v71.rotation;\n\tv545 = v142.rotation - v71.rotation;\n\tv416 = v545 / 0xC3B40000;\n\tv419 = v416 + 16384.499999999996d;\n\tv423 = 0x4000 - v419;\n\tv425 = v423 * 0x168;\n\tv438 = v419 != 0x7FF0000000000000;\n\tif (v438) goto L_FFFFFFFF;\n\tgoto L_013B;\nL_013B:\n\tgoto L_0163;\nL_013C:\n\tv143 = v71.data;\n\tv461 = v71.rotation;\n\tv511 = v143.rotation - v71.rotation;\n\tv545 = *([v442 @ X8_v14+20]) + v511;\n\tv514 = v545 / 0xC3B40000;\n\tv517 = v514 + 16384.499999999996d;\n\tv521 = 0x4000 - v517;\n\tv523 = v521 * 0x168;\n\tv536 = v517 != 0x7FF0000000000000;\n\tif (v536) goto L_FFFFFFFF;\n\tgoto L_0163;\nL_0163:\n\tv562 = v545 - v540;\nL_0164:\n\tv563 = v562 * alpha;\n\tv467 = v461 + v563;\n\tgoto L_01BC;\nL_0167:\n\tv144 = v71.data;\n\tv458 = v71.rotation;\n\tv606 = v144.rotation - v71.rotation;\n\tv622 = v622 + v606;\nL_0170:\n\tv634 = v622 / 0xC3B40000;\n\tv637 = v634 + 16384.499999999996d;\n\tv640 = 0x4000 - v637;\n\tv499 = v640 * 0x168;\n\tv449 = v637 != 0x7FF0000000000000;\n\tif (v449) goto L_FFFFFFFF;\n\tgoto L_018C;\nL_018C:\n\tv650 = v622 - v462;\n\tv651 = v650 * alpha;\n\tv343 = v458 + v651;\n\tgoto L_01BC;\nL_0190:\n\tv145 = v71.data;\n\tv611 = v622 / 0xC3B40000;\n\tv614 = v611 + 16384.499999999996d;\n\tv617 = 0x4000 - v614;\n\tv500 = v617 * 0x168;\n\tv450 = v614 != 0x7FF0000000000000;\n\tif (v450) goto L_FFFFFFFF;\n\tgoto L_01B2;\nL_01B2:\n\tv648 = v622 - v463;\n\tv649 = v648 * alpha;\n\tv343 = v649 + v145.rotation;\n\tgoto L_01BC;\nL_01B6:\n\tv146 = v71.data;\n\tv561 = *([v442 @ X8_v14+20]) * alpha;\n\tv343 = v561 + v146.rotation;\nL_01BC:\n\tv71.rotation = v343;\nL_01C7:\n\treturn;\n\tv157 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 321 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_012c: Expected O, but got I8
			//IL_0149: Expected O, but got I
			//IL_03b2: Expected O, but got I8
			//IL_03cf: Expected O, but got I
			//IL_03df: Expected F8, but got I
			ExposedList<Bone> bones = skeleton.Bones;
			Bone[] items = bones.Items;
			int propertyId = PropertyId;
			Bone bone = items[propertyId];
			if (!bone.Active)
			{
				return;
			}
			float[] array = Frames;
			float rotation;
			float num;
			double num6;
			float rotation2;
			double num45;
			if (array[0] > time)
			{
				if (blend == MixBlend.First)
				{
					BoneData data = bone.Data;
					rotation = bone.Rotation;
					num = data.Rotation - bone.Rotation;
					float num2 = num / -360f;
					double num3 = (double)num2 + 16384.499999999996;
					double num4 = 8.095E-320 - num3;
					double num5 = num4 * 1.78E-321;
					num6 = ((num3 != 9.218868437227405E+18) ? num5 : 6.19217644E-315);
					goto IL_08e5;
				}
				if (blend != MixBlend.Setup)
				{
					return;
				}
				BoneData data2 = bone.Data;
				rotation2 = data2.Rotation;
			}
			else
			{
				int num7 = array.Length << 32;
				object obj = -8589934592L + num7;
				int num8 = (int)((nint)obj >> 30);
				object obj2 = (nint)array + num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X9_v10+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v397 @ X9_v10+20]");
				float num9 = 0f - time;
				bool flag3 = num9 == 0f;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num10 = Animation.BinarySearch(array, time, 2);
					int num11 = num10 - 1;
					int num12 = num10 - 2;
					float num13 = time - array[num10];
					float num14 = array[num12] - array[num10];
					int num15 = num10 >> 1;
					float num16 = num13 / num14;
					int frameIndex = num15 - 1;
					float percent = 1f - num16;
					float curvePercent = GetCurvePercent(frameIndex, percent);
					int num17 = num10 + 1;
					float num18 = array[num17] - array[num11];
					float num19 = num18 / -360f;
					double num20 = (double)num19 + 16384.499999999996;
					double num21 = 8.095E-320 - num20;
					double num22 = num21 * 1.78E-321;
					double num23 = ((num20 != 9.218868437227405E+18) ? num22 : 6.19217644E-315);
					double num24 = (double)num18 - num23;
					int num25 = (int)(blend - 1);
					float num26 = curvePercent * (float)num24;
					bool flag5 = num25 < 2;
					bool flag6 = !flag5;
					float num27 = array[num11] + num26;
					float rotation3;
					if (flag6)
					{
						if (blend == MixBlend.Setup)
						{
							BoneData data3 = bone.Data;
							float num28 = num27 / -360f;
							float num29 = num28 + 16384.5f;
							float num30 = 2.2959E-41f - num29;
							float num31 = num30 * 5.04E-43f;
							float num32 = ((num29 != 9.2188684E+18f) ? num31 : 5898240f);
							float num33 = num27 - num32;
							float num34 = num33 * alpha;
							rotation2 = num34 + data3.Rotation;
							goto IL_0759;
						}
						if (blend != MixBlend.Add)
						{
							return;
						}
						rotation3 = bone.Rotation;
					}
					else
					{
						BoneData data4 = bone.Data;
						rotation3 = bone.Rotation;
						float num35 = data4.Rotation - bone.Rotation;
						num27 += num35;
					}
					float num36 = num27 / -360f;
					float num37 = num36 + 16384.5f;
					float num38 = 2.2959E-41f - num37;
					float num39 = num38 * 5.04E-43f;
					float num40 = ((num37 != 9.2188684E+18f) ? num39 : 5898240f);
					float num41 = num27 - num40;
					float num42 = num41 * alpha;
					rotation2 = rotation3 + num42;
				}
				else
				{
					int num43 = array.Length << 32;
					object obj3 = num43 + -4294967296L;
					int num44 = (int)((nint)obj3 >> 30);
					object obj4 = (nint)array + num44;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ X8_v14+20]");
					num45 = 0.0;
					int num46 = (int)(blend - 1);
					if (num46 < 2)
					{
						BoneData data5 = bone.Data;
						rotation = bone.Rotation;
						float num47 = data5.Rotation - bone.Rotation;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ X8_v14+20]");
						num = 0f + num47;
						float num48 = num / -360f;
						double num49 = (double)num48 + 16384.499999999996;
						double num50 = 8.095E-320 - num49;
						double num51 = num50 * 1.78E-321;
						num6 = ((num49 != 9.218868437227405E+18) ? num51 : 6.19217644E-315);
						goto IL_08e5;
					}
					if (blend != MixBlend.Setup)
					{
						if (blend == MixBlend.Add)
						{
							rotation = bone.Rotation;
							goto IL_084c;
						}
						return;
					}
					BoneData data6 = bone.Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ X8_v14+20]");
					float num52 = 0f * alpha;
					rotation2 = num52 + data6.Rotation;
				}
			}
			goto IL_0759;
			IL_0759:
			bone.Rotation = rotation2;
			return;
			IL_08e5:
			num45 = (double)num - num6;
			goto IL_084c;
			IL_084c:
			double num53 = num45 * (double)alpha;
			double num54 = (double)rotation + num53;
			rotation2 = (float)num54;
			goto IL_0759;
		}
	}
}
