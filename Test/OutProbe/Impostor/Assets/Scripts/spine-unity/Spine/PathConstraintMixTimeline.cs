using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200001D")]
	public class PathConstraintMixTimeline : CurveTimeline
	{
		[Token(Token = "0x4000094")]
		public const int ENTRIES = 3;

		[Token(Token = "0x4000095")]
		private const int PREV_TIME = -3;

		[Token(Token = "0x4000096")]
		private const int PREV_ROTATE = -2;

		[Token(Token = "0x4000097")]
		private const int PREV_TRANSLATE = -1;

		[Token(Token = "0x4000098")]
		private const int ROTATE = 1;

		[Token(Token = "0x4000099")]
		private const int TRANSLATE = 2;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x18")]
		internal int pathConstraintIndex;

		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x17000038")]
		public override int PropertyId
		{
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x1526D78", Offset = "0x1526D78", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.pathConstraintIndex + 0xD000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PathConstraintIndex + 218103808;
			}
		}

		[Token(Token = "0x17000039")]
		public int PathConstraintIndex
		{
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0x1526DE4", Offset = "0x1526DE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.pathConstraintIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PathConstraintIndex;
			}
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x1526D88", Offset = "0x1526D88", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_000F;\n\tthis.pathConstraintIndex = value;\n\treturn;\nL_000F:\n\tv37 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v37, \"index must be >= 0.\");\n\tthrow v37;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(value & 0x80000000L) == 0)
				{
					pathConstraintIndex = value;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index must be >= 0.");
				throw ex;
			}
		}

		[Token(Token = "0x1700003A")]
		public float[] Frames
		{
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0x1526DEC", Offset = "0x1526DEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0x1526DF4", Offset = "0x1526DF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x1526D10", Offset = "0x1526D10", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37AE8]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 1;\n\tv45 = frameCount + v44;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), v45 @ X1_v2 (System.Int32)\n\tthis.frames = v46;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PathConstraintMixTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 1;
			int num2 = frameCount + num;
			float[] array = new float[num2];
			Frames = array;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x1526DFC", Offset = "0x1526DFC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 1;\n\tv8 = frameIndex + v6;\n\tv73 = v8 + 1;\n\tv2[v8 @ X10_v2 (System.Int32)] = time;\n\tv94 = v8 + 2;\n\tv2[v73 @ X11_v3 (System.Int32)] = rotateMix;\n\tv2[v94 @ X10_v4 (System.Int32)] = translateMix;\n\treturn;\n\tv19 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix)
		{
			float[] array = Frames;
			int num = frameIndex << 1;
			int num2 = frameIndex + num;
			int num3 = num2 + 1;
			array[num2] = time;
			int num4 = num2 + 2;
			array[num3] = rotateMix;
			array[num4] = translateMix;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x1526E58", Offset = "0x1526E58", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = skeleton.pathConstraints;\n\tv117 = v20.Items;\n\tv113 = this.pathConstraintIndex;\n\tv60 = v117[v113 @ X9_v3 (System.Int32)];\n\tv319 = ~v60.active;\n\tif (v319) goto L_0117;\n\tv58 = this.frames;\n\tv47 = v58[0] <= time;\n\tif (v47) goto L_005D;\n\tv88 = blend == 1;\n\tif (v88) goto L_0102;\n\tv371 = blend == 0;\n\tv355 = ~v371;\n\tif (v355) goto L_0117;\n\tv120 = v60.data;\n\tv337 = v120.rotateMix;\n\tgoto L_010C;\nL_005D:\n\tv374 = v58.Length << 0x20;\n\tv375 = 0xFFFFFFFD00000000 + v374;\n\tv172 = v375 >> 0x1E;\n\tv243 = v58 + v172;\n\tv377 = *([v243 @ X9_v8+20]) < time;\n\tv378 = ~v377;\n\tv379 = *([v243 @ X9_v8+20]) - time;\n\tv381 = v379 == 0;\n\tv386 = ~v378;\n\tv48 = v386 | v381;\n\tif (v48) goto L_00EB;\n\tv157 = Spine.Animation::BinarySearch(v58, time, 3);\n\tv249 = v157 - 2;\n\tv244 = v157 - 1;\n\tv151 = v157 - 3;\n\tv468 = v157 * 0x55555556;\n\tv245 = v468 >> 0x3F;\n\tv469 = v468 >> 0x20;\n\tv143 = time - v58[v157 @ X0_v10 (System.Int32)];\n\tv470 = v58[v151 @ X11_v8 (System.Int32)] - v58[v157 @ X0_v10 (System.Int32)];\n\tv471 = v469 + v245;\n\tv472 = v143 / v470;\n\tv161 = v471 - 1;\n\tv473 = 1f - v472;\n\tv168 = Spine.CurveTimeline::GetCurvePercent(this, v161, v473);\n\tv250 = v157 + 1;\n\tv246 = v157 + 2;\n\tv478 = v58[v250 @ X8_v22 (System.Int32)] - v58[v249 @ X8_v16 (System.Int32)];\n\tv479 = v58[v246 @ X9_v20 (System.Int32)] - v58[v244 @ X9_v15 (System.Int32)];\n\tv480 = v168 * v478;\n\tv481 = v168 * v479;\n\tv29 = v58[v249 @ X8_v16 (System.Int32)] + v480;\n\tv56 = v58[v244 @ X9_v15 (System.Int32)] + v481;\n\tv482 = blend == 0;\n\tv435 = ~v482;\n\tif (v435) goto L_00F9;\nL_00DE:\n\tv121 = v60.data;\n\tv450 = v29 - v121.rotateMix;\n\tv451 = v450 * v24;\n\tv452 = v121.rotateMix + v451;\n\tv60.rotateMix = v452;\n\tv453 = v56 - v121.translateMix;\n\tv454 = v453 * v24;\n\tv338 = v121.translateMix + v454;\n\tgoto L_0100;\nL_00EB:\n\tv395 = v58.Length << 0x20;\n\tv398 = v395 + 0xFFFFFFFF00000000;\n\tv399 = v395 + 0xFFFFFFFE00000000;\n\tv400 = v58 + 0x20;\n\tv401 = v399 >> 0x1E;\n\tv402 = v398 >> 0x1E;\n\tv29 = *([v400 @ X11_v6+v401 @ X8_v13 (System.Int32)]);\n\tv56 = *([v400 @ X11_v6+v402 @ X9_v13 (System.Int32)]);\n\tv405 = blend == 0;\n\tif (v405) goto L_00DE;\nL_00F9:\n\tv438 = v411 - v60.rotateMix;\n\tv439 = v419 - v60.translateMix;\n\tv440 = v438 * v408;\n\tv441 = v439 * v408;\n\tv442 = v60.rotateMix + v440;\n\tv338 = v60.translateMix + v441;\n\tv60.rotateMix = v442;\nL_0100:\n\tv60.translateMix = v338;\n\tgoto L_0117;\nL_0102:\n\tv122 = v60.data;\n\t// 264 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv390 = v122.rotateMix - v60.rotateMix;\n\tv391 = v390 * v392;\n\tv337 = v60.rotateMix + v391;\nL_010C:\n\tv60.rotateMix = v337;\nL_0117:\n\treturn;\n\tv130 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 192 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_012c: Expected I4, but got I8
			//IL_0148: Expected O, but got I
			//IL_0461: Expected O, but got I8
			//IL_0473: Expected O, but got I8
			//IL_0482: Expected O, but got I
			//IL_04b0: Expected F4, but got I
			//IL_04c0: Expected F4, but got I
			//IL_04e7: Expected F4, but got I
			//IL_04f7: Expected F4, but got I
			ExposedList<PathConstraint> pathConstraints = skeleton.PathConstraints;
			PathConstraint[] items = pathConstraints.Items;
			int num = PathConstraintIndex;
			PathConstraint pathConstraint = items[num];
			if (!pathConstraint.Active)
			{
				return;
			}
			float[] array = Frames;
			if (array[0] > time)
			{
				float rotateMix;
				switch (blend)
				{
				case MixBlend.Setup:
				{
					PathConstraintData data2 = pathConstraint.Data;
					rotateMix = data2.RotateMix;
					break;
				}
				case MixBlend.First:
				{
					PathConstraintData data = pathConstraint.Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = data.RotateMix - pathConstraint.RotateMix;
					object obj = default(object);
					float num3 = num2 * (float)obj;
					rotateMix = pathConstraint.RotateMix + num3;
					break;
				}
				default:
					return;
				}
				pathConstraint.RotateMix = rotateMix;
				return;
			}
			int num4 = array.Length << 32;
			int num5 = (int)(-12884901888L + num4);
			int num6 = num5 >> 30;
			object obj2 = (nint)array + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X9_v8+20]");
			bool flag = 0f < time;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v243 @ X9_v8+20]");
			float num7 = 0f - time;
			bool flag3 = num7 == 0f;
			bool flag4 = !flag2;
			float num25;
			float num26;
			float num27;
			float num28 = default(float);
			float num29;
			float num30;
			if (!(flag4 || flag3))
			{
				int num8 = Animation.BinarySearch(array, time, 3);
				int num9 = num8 - 2;
				int num10 = num8 - 1;
				int num11 = num8 - 3;
				int num12 = num8 * 1431655766;
				int num13 = num12 >> 63;
				int num14 = num12 >> 32;
				float num15 = time - array[num8];
				float num16 = array[num11] - array[num8];
				int num17 = num14 + num13;
				float num18 = num15 / num16;
				int frameIndex = num17 - 1;
				float percent = 1f - num18;
				float curvePercent = GetCurvePercent(frameIndex, percent);
				int num19 = num8 + 1;
				int num20 = num8 + 2;
				float num21 = array[num19] - array[num9];
				float num22 = array[num20] - array[num10];
				float num23 = curvePercent * num21;
				float num24 = curvePercent * num22;
				num25 = array[num9] + num23;
				num26 = array[num10] + num24;
				bool flag5 = blend == MixBlend.Setup;
				bool flag6 = !flag5;
				num27 = num28;
				num29 = num25;
				num30 = num26;
				if (!flag6)
				{
					goto IL_03ad;
				}
			}
			else
			{
				int num31 = array.Length << 32;
				object obj3 = num31 + -4294967296L;
				object obj4 = num31 + -8589934592L;
				object obj5 = (nint)array + 32;
				int num32 = (int)((nint)obj4 >> 30);
				int num33 = (int)((nint)obj3 >> 30);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X11_v6+v401 @ X8_v13 (System.Int32)]");
				num25 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X11_v6+v402 @ X9_v13 (System.Int32)]");
				num26 = 0f;
				bool flag7 = blend == MixBlend.Setup;
				num27 = num28;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X11_v6+v401 @ X8_v13 (System.Int32)]");
				num29 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v400 @ X11_v6+v402 @ X9_v13 (System.Int32)]");
				num30 = 0f;
				if (flag7)
				{
					goto IL_03ad;
				}
			}
			float num34 = num29 - pathConstraint.RotateMix;
			float num35 = num30 - pathConstraint.TranslateMix;
			float num36 = num34 * num27;
			float num37 = num35 * num27;
			float rotateMix2 = pathConstraint.RotateMix + num36;
			float translateMix = pathConstraint.TranslateMix + num37;
			pathConstraint.RotateMix = rotateMix2;
			goto IL_05f5;
			IL_03ad:
			PathConstraintData data3 = pathConstraint.Data;
			float num38 = num25 - data3.RotateMix;
			float num39 = num38 * num28;
			float rotateMix3 = data3.RotateMix + num39;
			pathConstraint.RotateMix = rotateMix3;
			float num40 = num26 - data3.TranslateMix;
			float num41 = num40 * num28;
			translateMix = data3.TranslateMix + num41;
			goto IL_05f5;
			IL_05f5:
			pathConstraint.TranslateMix = translateMix;
		}
	}
}
