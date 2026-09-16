using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200001A")]
	public class TransformConstraintTimeline : CurveTimeline
	{
		[Token(Token = "0x4000082")]
		public const int ENTRIES = 5;

		[Token(Token = "0x4000083")]
		private const int PREV_TIME = -5;

		[Token(Token = "0x4000084")]
		private const int PREV_ROTATE = -4;

		[Token(Token = "0x4000085")]
		private const int PREV_TRANSLATE = -3;

		[Token(Token = "0x4000086")]
		private const int PREV_SCALE = -2;

		[Token(Token = "0x4000087")]
		private const int PREV_SHEAR = -1;

		[Token(Token = "0x4000088")]
		private const int ROTATE = 1;

		[Token(Token = "0x4000089")]
		private const int TRANSLATE = 2;

		[Token(Token = "0x400008A")]
		private const int SCALE = 3;

		[Token(Token = "0x400008B")]
		private const int SHEAR = 4;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x18")]
		internal int transformConstraintIndex;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x17000031")]
		public override int PropertyId
		{
			[Token(Token = "0x6000090")]
			[Address(RVA = "0x15263C0", Offset = "0x15263C0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.transformConstraintIndex + 0xA000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TransformConstraintIndex + 167772160;
			}
		}

		[Token(Token = "0x17000032")]
		public int TransformConstraintIndex
		{
			[Token(Token = "0x6000092")]
			[Address(RVA = "0x152642C", Offset = "0x152642C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.transformConstraintIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TransformConstraintIndex;
			}
			[Token(Token = "0x6000091")]
			[Address(RVA = "0x15263D0", Offset = "0x15263D0", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_000F;\n\tthis.transformConstraintIndex = value;\n\treturn;\nL_000F:\n\tv37 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v37, \"index must be >= 0.\");\n\tthrow v37;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0012: Expected I4, but got I8
				if ((int)(value & 0x80000000L) == 0)
				{
					transformConstraintIndex = value;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("index must be >= 0.");
				throw ex;
			}
		}

		[Token(Token = "0x17000033")]
		public float[] Frames
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x1526434", Offset = "0x1526434", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000094")]
			[Address(RVA = "0x152643C", Offset = "0x152643C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x1526358", Offset = "0x1526358", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37AE6]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 2;\n\tv45 = frameCount + v44;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), v45 @ X1_v2 (System.Int32)\n\tthis.frames = v46;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformConstraintTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 2;
			int num2 = frameCount + num;
			float[] array = new float[num2];
			Frames = array;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x1526444", Offset = "0x1526444", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 2;\n\tv8 = frameIndex + v6;\n\tv73 = v8 + 1;\n\tv2[v8 @ X10_v2 (System.Int32)] = time;\n\tv87 = v8 + 2;\n\tv2[v73 @ X11_v3 (System.Int32)] = rotateMix;\n\tv88 = v8 + 3;\n\tv2[v87 @ X11_v4 (System.Int32)] = translateMix;\n\tv114 = v8 + 4;\n\tv2[v88 @ X11_v5 (System.Int32)] = scaleMix;\n\tv2[v114 @ X10_v4 (System.Int32)] = shearMix;\n\treturn;\n\tv19 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix, float scaleMix, float shearMix)
		{
			float[] array = Frames;
			int num = frameIndex << 2;
			int num2 = frameIndex + num;
			int num3 = num2 + 1;
			array[num2] = time;
			int num4 = num2 + 2;
			array[num3] = rotateMix;
			int num5 = num2 + 3;
			array[num4] = translateMix;
			int num6 = num2 + 4;
			array[num5] = scaleMix;
			array[num6] = shearMix;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x15264C8", Offset = "0x15264C8", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = skeleton.transformConstraints;\n\tv143 = v24.Items;\n\tv139 = this.transformConstraintIndex;\n\tv86 = v143[v139 @ X9_v3 (System.Int32)];\n\tv411 = ~v86.active;\n\tif (v411) goto L_0179;\n\tv84 = this.frames;\n\tv73 = v84[0] <= time;\n\tif (v73) goto L_005F;\n\tv146 = v86.data;\n\tv114 = blend == 1;\n\tif (v114) goto L_0168;\n\tv475 = blend == 0;\n\tv459 = ~v475;\n\tif (v459) goto L_0179;\n\tv442 = v146.rotateMix;\n\tgoto L_016C;\nL_005F:\n\tv478 = v84.Length << 0x20;\n\tv479 = 0xFFFFFFFB00000000 + v478;\n\tv208 = v479 >> 0x1E;\n\tv312 = v84 + v208;\n\tv481 = *([v312 @ X9_v8+20]) < time;\n\tv482 = ~v481;\n\tv483 = *([v312 @ X9_v8+20]) - time;\n\tv485 = v483 == 0;\n\tv490 = ~v482;\n\tv74 = v490 | v485;\n\tif (v74) goto L_0132;\n\tv193 = Spine.Animation::BinarySearch(v84, time, 5);\n\tv318 = v193 - 4;\n\tv313 = v193 - 3;\n\tv186 = v193 - 2;\n\tv183 = v193 - 1;\n\tv181 = v193 - 5;\n\tv624 = v193 * 0x66666667;\n\tv314 = v624 >> 0x20;\n\tv625 = v624 >> 0x3F;\n\tv169 = time - v84[v193 @ X0_v10 (System.Int32)];\n\tv626 = v84[v181 @ X13_v7 (System.Int32)] - v84[v193 @ X0_v10 (System.Int32)];\n\tv209 = v314 >> 1;\n\tv319 = v625 + v209;\n\tv627 = v169 / v626;\n\tv197 = v319 - 1;\n\tv628 = 1f - v627;\n\tv204 = Spine.CurveTimeline::GetCurvePercent(this, v197, v628);\n\tv187 = v193 + 1;\n\tv310 = v193 + 2;\n\tv320 = v193 + 3;\n\tv315 = v193 + 4;\n\tv638 = v84[v310 @ X10_v14 (System.Int32)] - v84[v313 @ X9_v16 (System.Int32)];\n\tv639 = v204 * v638;\n\tv542 = v84[v313 @ X9_v16 (System.Int32)] + v639;\n\tv640 = v84[v187 @ X11_v11 (System.Int32)] - v84[v318 @ X8_v16 (System.Int32)];\n\tv641 = v84[v320 @ X8_v22 (System.Int32)] - v84[v186 @ X11_v9 (System.Int32)];\n\tv529 = v84[v315 @ X9_v21 (System.Int32)] - v84[v183 @ X12_v9 (System.Int32)];\n\tv642 = v204 * v640;\n\tv527 = v204 * v641;\n\tv643 = v204 * v529;\n\tv544 = v84[v318 @ X8_v16 (System.Int32)] + v642;\n\tv549 = v84[v186 @ X11_v9 (System.Int32)] + v527;\n\tv558 = v84[v183 @ X12_v9 (System.Int32)] + v643;\n\tv540 = blend == 0;\n\tif (v540) goto L_0148;\nL_0122:\n\tv576 = v544 - v86.rotateMix;\n\tv577 = v542 - v86.translateMix;\n\tv578 = v549 - v86.scaleMix;\n\tv579 = v558 - v86.shearMix;\n\tv580 = v576 * v545;\n\tv581 = v577 * v545;\n\tv582 = v578 * v545;\n\tv583 = v579 * v545;\n\tv584 = v86.rotateMix + v580;\n\tv585 = v86.translateMix + v581;\n\tv586 = v86.scaleMix + v582;\n\tv443 = v86.shearMix + v583;\n\tv86.rotateMix = v584;\n\tv86.translateMix = v585;\n\tv86.scaleMix = v586;\n\tgoto L_015E;\nL_0132:\n\tv504 = v84.Length << 0x20;\n\tv510 = v504 + 0xFFFFFFFC00000000;\n\tv511 = v504 + 0xFFFFFFFD00000000;\n\tv512 = v504 + 0xFFFFFFFF00000000;\n\tv513 = v504 + 0xFFFFFFFE00000000;\n\tv514 = v84 + 0x20;\n\tv515 = v510 >> 0x1E;\n\tv544 = *([v514 @ X12_v7+v515 @ X9_v13 (System.Int32)]);\n\tv517 = v511 >> 0x1E;\n\tv518 = v513 >> 0x1E;\n\tv519 = v512 >> 0x1E;\n\tv542 = *([v514 @ X12_v7+v517 @ X9_v14 (System.Int32)]);\n\tv549 = *([v514 @ X12_v7+v518 @ X8_v14 (System.Int32)]);\n\tv558 = *([v514 @ X12_v7+v519 @ X10_v10 (System.Int32)]);\n\tv523 = blend == 0;\n\tv524 = ~v523;\n\tif (v524) goto L_0122;\nL_0148:\n\tv147 = v86.data;\n\tv590 = v37 - v147.rotateMix;\n\tv591 = v590 * v40;\n\tv592 = v147.rotateMix + v591;\n\tv86.rotateMix = v592;\n\tv594 = v31 - v147.translateMix;\n\tv595 = v594 * v40;\n\tv596 = v147.translateMix + v595;\n\tv86.translateMix = v596;\n\tv598 = v49 - v147.scaleMix;\n\tv599 = v598 * v40;\n\tv600 = v147.scaleMix + v599;\n\tv86.scaleMix = v600;\n\tv602 = v82 - v147.shearMix;\n\tv603 = v602 * v40;\n\tv443 = v147.shearMix + v603;\nL_015E:\n\tv86.shearMix = v443;\n\tgoto L_0179;\nL_0168:\n\t// 360 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv499 = v146.rotateMix - v86.rotateMix;\n\tv500 = v499 * v501;\n\tv442 = v86.rotateMix + v500;\nL_016C:\n\tv86.rotateMix = v442;\nL_0179:\n\treturn;\n\tv155 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 258 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_0127: Expected I4, but got I8
			//IL_0143: Expected O, but got I
			//IL_05c1: Expected O, but got I8
			//IL_05d3: Expected I4, but got I8
			//IL_05e5: Expected O, but got I8
			//IL_05f7: Expected O, but got I8
			//IL_0606: Expected O, but got I
			//IL_0625: Expected F4, but got I
			//IL_0661: Expected F4, but got I
			//IL_0671: Expected F4, but got I
			//IL_0681: Expected F4, but got I
			//IL_06ab: Expected F4, but got I
			//IL_06bb: Expected F4, but got I
			//IL_06d3: Expected F4, but got I
			//IL_06e3: Expected F4, but got I
			ExposedList<TransformConstraint> transformConstraints = skeleton.TransformConstraints;
			TransformConstraint[] items = transformConstraints.Items;
			int num = TransformConstraintIndex;
			TransformConstraint transformConstraint = items[num];
			if (!transformConstraint.Active)
			{
				return;
			}
			float[] array = Frames;
			if (array[0] > time)
			{
				TransformConstraintData data = transformConstraint.Data;
				float rotateMix;
				switch (blend)
				{
				case MixBlend.Setup:
					rotateMix = data.RotateMix;
					break;
				case MixBlend.First:
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = data.RotateMix - transformConstraint.RotateMix;
					object obj = default(object);
					float num3 = num2 * (float)obj;
					rotateMix = transformConstraint.RotateMix + num3;
					break;
				}
				default:
					return;
				}
				transformConstraint.RotateMix = rotateMix;
				return;
			}
			int num4 = array.Length << 32;
			int num5 = (int)(-21474836480L + num4);
			int num6 = num5 >> 30;
			object obj2 = (nint)array + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ X9_v8+20]");
			bool flag = 0f < time;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ X9_v8+20]");
			float num7 = 0f - time;
			bool flag3 = num7 == 0f;
			bool flag4 = !flag2;
			float num28;
			float num35;
			float num36;
			float num37;
			float num38;
			float num39;
			float num40;
			float num41 = default(float);
			float num42;
			float num43;
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
				bool flag5 = blend == MixBlend.Setup;
				num38 = num28;
				num39 = num35;
				num40 = num41;
				num42 = num36;
				num43 = num37;
				if (!flag5)
				{
					goto IL_0497;
				}
			}
			else
			{
				int num44 = array.Length << 32;
				object obj3 = num44 + -17179869184L;
				int num45 = (int)(num44 + -12884901888L);
				object obj4 = num44 + -4294967296L;
				object obj5 = num44 + -8589934592L;
				object obj6 = (nint)array + 32;
				int num46 = (int)((nint)obj3 >> 30);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v515 @ X9_v13 (System.Int32)]");
				num35 = 0f;
				int num47 = num45 >> 30;
				int num48 = (int)((nint)obj5 >> 30);
				int num49 = (int)((nint)obj4 >> 30);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v517 @ X9_v14 (System.Int32)]");
				num28 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v518 @ X8_v14 (System.Int32)]");
				num36 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v519 @ X10_v10 (System.Int32)]");
				num37 = 0f;
				bool flag6 = blend == MixBlend.Setup;
				bool flag7 = !flag6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v517 @ X9_v14 (System.Int32)]");
				num38 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v515 @ X9_v13 (System.Int32)]");
				num39 = 0f;
				num40 = num41;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v518 @ X8_v14 (System.Int32)]");
				num42 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ X12_v7+v519 @ X10_v10 (System.Int32)]");
				num43 = 0f;
				if (flag7)
				{
					goto IL_0497;
				}
			}
			TransformConstraintData data2 = transformConstraint.Data;
			float num50 = num39 - data2.RotateMix;
			float num51 = num50 * num40;
			float rotateMix2 = data2.RotateMix + num51;
			transformConstraint.RotateMix = rotateMix2;
			float num52 = num38 - data2.TranslateMix;
			float num53 = num52 * num40;
			float translateMix = data2.TranslateMix + num53;
			transformConstraint.TranslateMix = translateMix;
			float num54 = num42 - data2.ScaleMix;
			float num55 = num54 * num40;
			float scaleMix = data2.ScaleMix + num55;
			transformConstraint.ScaleMix = scaleMix;
			float num56 = num43 - data2.ShearMix;
			float num57 = num56 * num40;
			float shearMix = data2.ShearMix + num57;
			goto IL_0869;
			IL_0497:
			float num58 = num35 - transformConstraint.RotateMix;
			float num59 = num28 - transformConstraint.TranslateMix;
			float num60 = num36 - transformConstraint.ScaleMix;
			float num61 = num37 - transformConstraint.ShearMix;
			float num62 = num58 * num41;
			float num63 = num59 * num41;
			float num64 = num60 * num41;
			float num65 = num61 * num41;
			float rotateMix3 = transformConstraint.RotateMix + num62;
			float translateMix2 = transformConstraint.TranslateMix + num63;
			float scaleMix2 = transformConstraint.ScaleMix + num64;
			shearMix = transformConstraint.ShearMix + num65;
			transformConstraint.RotateMix = rotateMix3;
			transformConstraint.TranslateMix = translateMix2;
			transformConstraint.ScaleMix = scaleMix2;
			goto IL_0869;
			IL_0869:
			transformConstraint.ShearMix = shearMix;
		}
	}
}
