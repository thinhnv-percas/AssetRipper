using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200001C")]
	public class PathConstraintSpacingTimeline : PathConstraintPositionTimeline
	{
		[Token(Token = "0x17000037")]
		public override int PropertyId
		{
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x1526B2C", Offset = "0x1526B2C", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.pathConstraintIndex + 0xC000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PathConstraintIndex + 201326592;
			}
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x1526B28", Offset = "0x1526B28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.PathConstraintPositionTimeline::.ctor(this, frameCount);\n\treturn;\n")]
		public PathConstraintSpacingTimeline(int frameCount)
			: base(frameCount)
		{
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x1526B3C", Offset = "0x1526B3C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = skeleton.pathConstraints;\n\tv114 = v20.Items;\n\tv110 = this.pathConstraintIndex;\n\tv57 = v114[v110 @ X9_v3 (System.Int32)];\n\tv291 = ~v57.active;\n\tif (v291) goto L_00F1;\n\tv55 = this.frames;\n\tv42 = v55[0] <= time;\n\tif (v42) goto L_005D;\n\tv85 = blend == 1;\n\tif (v85) goto L_00DE;\n\tv335 = blend == 0;\n\tv320 = ~v335;\n\tif (v320) goto L_00F1;\n\tv117 = v57.data;\n\tv305 = v117.spacing;\n\tgoto L_00E6;\nL_005D:\n\tv337 = v55.Length << 0x20;\n\tv338 = 0xFFFFFFFE00000000 + v337;\n\tv168 = v338 >> 0x1E;\n\tv339 = v55 + v168;\n\tv341 = *([v339 @ X9_v8+20]) < time;\n\tv342 = ~v341;\n\tv343 = *([v339 @ X9_v8+20]) - time;\n\tv345 = v343 == 0;\n\tv350 = ~v342;\n\tv157 = v350 | v345;\n\tif (v157) goto L_00CD;\n\tv150 = Spine.Animation::BinarySearch(v55, time, 2);\n\tv227 = v150 - 1;\n\tv220 = v150 - 2;\n\tv434 = v150 < 0;\n\tv437 = v150 ^ v150;\n\tv438 = v150 & v437;\n\tv439 = v438 < 0;\n\tv440 = v434 == v439;\n\tv158 = ~v440;\n\tv142 = ~v158;\n\tif (v142) goto L_FFFFFFFF;\n\tv443 = v150 + 1;\n\tgoto L_00AE;\nL_00AE:\n\tv140 = time - v55[v150 @ X0_v11 (System.Int32)];\n\tv444 = v55[v220 @ X10_v9 (System.Int32)] - v55[v150 @ X0_v11 (System.Int32)];\n\tv445 = v443 >> 1;\n\tv446 = v140 / v444;\n\tv154 = v445 - 1;\n\tv447 = 1f - v446;\n\tv164 = Spine.CurveTimeline::GetCurvePercent(this, v154, v447);\n\tv228 = v150 + 1;\n\tv389 = v55[v228 @ X8_v21 (System.Int32)] - v55[v227 @ X8_v17 (System.Int32)];\n\tv450 = v164 * v389;\n\tv421 = v55[v227 @ X8_v17 (System.Int32)] + v450;\n\tv395 = blend == 0;\n\tif (v395) goto L_00D6;\nL_00CB:\n\tv369 = v57.spacing;\n\tgoto L_00DA;\nL_00CD:\n\tv357 = v55.Length << 0x20;\n\tv359 = v357 + 0xFFFFFFFF00000000;\n\tv360 = v359 >> 0x1E;\n\tv361 = v55 + v360;\n\tv421 = *([v361 @ X8_v15+20]);\n\tv363 = blend == 0;\n\tv364 = ~v363;\n\tif (v364) goto L_00CB;\nL_00D6:\n\tv118 = v57.data;\n\tv369 = v118.spacing;\nL_00DA:\n\tv422 = v421 - v369;\n\tv423 = v422 * alpha;\n\tv305 = v369 + v423;\n\tgoto L_00E6;\nL_00DE:\n\tv119 = v57.data;\n\tv353 = v119.spacing - v57.spacing;\n\tv354 = v353 * alpha;\n\tv305 = v57.spacing + v354;\nL_00E6:\n\tv57.spacing = v305;\nL_00F1:\n\treturn;\n\tv127 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> events, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_012c: Expected O, but got I8
			//IL_0149: Expected O, but got I
			//IL_0321: Expected O, but got I8
			//IL_033e: Expected O, but got I
			//IL_034e: Expected F4, but got I
			//IL_0378: Expected F4, but got I
			ExposedList<PathConstraint> pathConstraints = skeleton.PathConstraints;
			PathConstraint[] items = pathConstraints.Items;
			int num = PathConstraintIndex;
			PathConstraint pathConstraint = items[num];
			if (!pathConstraint.Active)
			{
				return;
			}
			float[] array = Frames;
			float spacing;
			if (array[0] > time)
			{
				switch (blend)
				{
				case MixBlend.Setup:
				{
					PathConstraintData data2 = pathConstraint.Data;
					spacing = data2.Spacing;
					break;
				}
				case MixBlend.First:
				{
					PathConstraintData data = pathConstraint.Data;
					float num2 = data.Spacing - pathConstraint.Spacing;
					float num3 = num2 * alpha;
					spacing = pathConstraint.Spacing + num3;
					break;
				}
				default:
					return;
				}
				goto IL_0406;
			}
			int num4 = array.Length << 32;
			object obj = -8589934592L + num4;
			int num5 = (int)((nint)obj >> 30);
			object obj2 = (nint)array + num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X9_v8+20]");
			bool flag = 0f < time;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X9_v8+20]");
			float num6 = 0f - time;
			bool flag3 = num6 == 0f;
			bool flag4 = !flag2;
			float num20;
			float num21;
			if (!(flag4 || flag3))
			{
				int num7 = Animation.BinarySearch(array, time, 2);
				int num8 = num7 - 1;
				int num9 = num7 - 2;
				bool flag5 = num7 < 0;
				int num10 = num7 ^ num7;
				int num11 = num7 & num10;
				bool flag6 = num11 < 0;
				int num12 = ((flag5 == flag6) ? num7 : (num7 + 1));
				float num13 = time - array[num7];
				float num14 = array[num9] - array[num7];
				int num15 = num12 >> 1;
				float num16 = num13 / num14;
				int frameIndex = num15 - 1;
				float percent = 1f - num16;
				float curvePercent = GetCurvePercent(frameIndex, percent);
				int num17 = num7 + 1;
				float num18 = array[num17] - array[num8];
				float num19 = curvePercent * num18;
				num20 = array[num8] + num19;
				bool flag7 = blend == MixBlend.Setup;
				num21 = num20;
				if (!flag7)
				{
					goto IL_02ed;
				}
			}
			else
			{
				int num22 = array.Length << 32;
				object obj3 = num22 + -4294967296L;
				int num23 = (int)((nint)obj3 >> 30);
				object obj4 = (nint)array + num23;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ X8_v15+20]");
				num20 = 0f;
				bool flag8 = blend == MixBlend.Setup;
				bool flag9 = !flag8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v361 @ X8_v15+20]");
				num21 = 0f;
				if (flag9)
				{
					goto IL_02ed;
				}
			}
			PathConstraintData data3 = pathConstraint.Data;
			float spacing2 = data3.Spacing;
			num20 = num21;
			goto IL_04b1;
			IL_04b1:
			float num24 = num20 - spacing2;
			float num25 = num24 * alpha;
			spacing = spacing2 + num25;
			goto IL_0406;
			IL_0406:
			pathConstraint.Spacing = spacing;
			return;
			IL_02ed:
			spacing2 = pathConstraint.Spacing;
			goto IL_04b1;
		}
	}
}
