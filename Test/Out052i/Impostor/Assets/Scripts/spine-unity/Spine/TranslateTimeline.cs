using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000010")]
	public class TranslateTimeline : CurveTimeline, IBoneTimeline
	{
		[Token(Token = "0x4000043")]
		public const int ENTRIES = 3;

		[Token(Token = "0x4000044")]
		protected const int PREV_TIME = -3;

		[Token(Token = "0x4000045")]
		protected const int PREV_X = -2;

		[Token(Token = "0x4000046")]
		protected const int PREV_Y = -1;

		[Token(Token = "0x4000047")]
		protected const int X = 1;

		[Token(Token = "0x4000048")]
		protected const int Y = 2;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x18")]
		internal int boneIndex;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x20")]
		internal float[] frames;

		[Token(Token = "0x17000011")]
		public override int PropertyId
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x1522FFC", Offset = "0x1522FFC", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.boneIndex + 0x1000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BoneIndex + 16777216;
			}
		}

		[Token(Token = "0x17000012")]
		public int BoneIndex
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x1523068", Offset = "0x1523068", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.boneIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BoneIndex;
			}
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x152300C", Offset = "0x152300C", Length = "0x5C")]
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

		[Token(Token = "0x17000013")]
		public float[] Frames
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x1523070", Offset = "0x1523070", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.frames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Frames;
			}
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x1523078", Offset = "0x1523078", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frames = value;\n\treturn;\n")]
			set
			{
				Frames = value;
			}
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x1522F94", Offset = "0x1522F94", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Single[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, frameCount, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37ADB]) = v40;\nL_0017:\n\tSpine.CurveTimeline::.ctor(this, frameCount);\n\tv44 = frameCount << 1;\n\tv45 = frameCount + v44;\n\t// 27 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), v45 @ X1_v2 (System.Int32)\n\tthis.frames = v46;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TranslateTimeline(int frameCount)
			: base(frameCount)
		{
			int num = frameCount << 1;
			int num2 = frameCount + num;
			float[] array = new float[num2];
			Frames = array;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x1523080", Offset = "0x1523080", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.frames;\n\tv6 = frameIndex << 1;\n\tv8 = frameIndex + v6;\n\tv73 = v8 + 1;\n\tv2[v8 @ X10_v2 (System.Int32)] = time;\n\tv94 = v8 + 2;\n\tv2[v73 @ X11_v3 (System.Int32)] = x;\n\tv2[v94 @ X10_v4 (System.Int32)] = y;\n\treturn;\n\tv19 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetFrame(int frameIndex, float time, float x, float y)
		{
			float[] array = Frames;
			int num = frameIndex << 1;
			int num2 = frameIndex + num;
			int num3 = num2 + 1;
			array[num2] = time;
			int num4 = num2 + 2;
			array[num3] = x;
			array[num4] = y;
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15230DC", Offset = "0x15230DC", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = skeleton.bones;\n\tv125 = v20.Items;\n\tv121 = this.boneIndex;\n\tv60 = v125[v121 @ X9_v3 (System.Int32)];\n\tv330 = ~v60.active;\n\tif (v330) goto L_0139;\n\tv58 = this.frames;\n\tv47 = v58[0] <= time;\n\tif (v47) goto L_005D;\n\tv92 = blend == 1;\n\tif (v92) goto L_011B;\n\tv373 = blend == 0;\n\tv356 = ~v373;\n\tif (v356) goto L_0139;\n\tv128 = v60.data;\n\tv341 = v128.x;\n\tgoto L_0125;\nL_005D:\n\tv376 = v58.Length << 0x20;\n\tv377 = 0xFFFFFFFD00000000 + v376;\n\tv183 = v377 >> 0x1E;\n\tv254 = v58 + v183;\n\tv379 = *([v254 @ X9_v8+20]) < time;\n\tv380 = ~v379;\n\tv381 = *([v254 @ X9_v8+20]) - time;\n\tv383 = v381 == 0;\n\tv388 = ~v380;\n\tv174 = v388 | v383;\n\tif (v174) goto L_00DC;\n\tv167 = Spine.Animation::BinarySearch(v58, time, 3);\n\tv260 = v167 - 2;\n\tv255 = v167 - 1;\n\tv161 = v167 - 3;\n\tv460 = v167 * 0x55555556;\n\tv256 = v460 >> 0x3F;\n\tv461 = v460 >> 0x20;\n\tv153 = time - v58[v167 @ X0_v8 (System.Int32)];\n\tv462 = v58[v161 @ X11_v6 (System.Int32)] - v58[v167 @ X0_v8 (System.Int32)];\n\tv463 = v461 + v256;\n\tv464 = v153 / v462;\n\tv171 = v463 - 1;\n\tv465 = 1f - v464;\n\tv179 = Spine.CurveTimeline::GetCurvePercent(this, v171, v465);\n\tv261 = v167 + 1;\n\tv257 = v167 + 2;\n\tv473 = v58[v261 @ X8_v23 (System.Int32)] - v58[v260 @ X8_v17 (System.Int32)];\n\tv474 = v58[v257 @ X9_v18 (System.Int32)] - v58[v255 @ X9_v13 (System.Int32)];\n\tv475 = v179 * v473;\n\tv476 = v179 * v474;\n\tv29 = v58[v260 @ X8_v17 (System.Int32)] + v475;\n\tv56 = v58[v255 @ X9_v13 (System.Int32)] + v476;\n\tgoto L_00E6;\nL_00DC:\n\tv397 = v58.Length << 0x20;\n\tv400 = v397 + 0xFFFFFFFF00000000;\n\tv401 = v397 + 0xFFFFFFFE00000000;\n\tv402 = v58 + 0x20;\n\tv403 = v401 >> 0x1E;\n\tv404 = v400 >> 0x1E;\n\tv29 = *([v402 @ X11_v5+v403 @ X8_v16 (System.Int32)]);\n\tv56 = *([v402 @ X11_v5+v404 @ X9_v12 (System.Int32)]);\nL_00E6:\n\tv353 = blend - 1;\n\tv422 = v353 < 2;\n\tv112 = ~v422;\n\tv48 = ~v112;\n\tif (v48) goto L_010A;\n\tv93 = blend == 3;\n\tif (v93) goto L_0129;\n\tv426 = blend == 0;\n\tv357 = ~v426;\n\tif (v357) goto L_0139;\n\tv129 = v60.data;\n\tv466 = v29 * v24;\n\tv467 = v56 * v24;\n\tv468 = v466 + v129.x;\n\tv60.x = v468;\n\tv340 = v467 + v129.y;\n\tgoto L_012E;\nL_010A:\n\tv130 = v60.data;\n\tv434 = v29 + v130.x;\n\tv437 = v434 - v60.x;\n\tv438 = v437 * v24;\n\tv439 = v60.x + v438;\n\tv60.x = v439;\n\tv441 = v56 + v130.y;\n\tv442 = v441 - v60.y;\n\tv443 = v442 * v24;\n\tv340 = v60.y + v443;\n\tgoto L_012E;\nL_011B:\n\tv131 = v60.data;\n\t// 289 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv392 = v131.x - v60.x;\n\tv393 = v392 * v394;\n\tv341 = v60.x + v393;\nL_0125:\n\tv60.x = v341;\n\tgoto L_0139;\nL_0129:\n\tv429 = v29 * v24;\n\tv430 = v56 * v24;\n\tv431 = v429 + v60.x;\n\tv340 = v430 + v60.y;\n\tv60.x = v431;\nL_012E:\n\tv60.y = v340;\nL_0139:\n\treturn;\n\tv140 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_012c: Expected I4, but got I8
			//IL_0148: Expected O, but got I
			//IL_0394: Expected O, but got I8
			//IL_03a6: Expected O, but got I8
			//IL_03b5: Expected O, but got I
			//IL_03e3: Expected F4, but got I
			//IL_03f3: Expected F4, but got I
			ExposedList<Bone> bones = skeleton.Bones;
			Bone[] items = bones.Items;
			int num = BoneIndex;
			Bone bone = items[num];
			if (!bone.Active)
			{
				return;
			}
			float[] array = Frames;
			if (array[0] > time)
			{
				float x;
				switch (blend)
				{
				case MixBlend.Setup:
				{
					BoneData data2 = bone.Data;
					x = data2.X;
					break;
				}
				case MixBlend.First:
				{
					BoneData data = bone.Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = data.X - bone.X;
					object obj = default(object);
					float num3 = num2 * (float)obj;
					x = bone.X + num3;
					break;
				}
				default:
					return;
				}
				bone.X = x;
				return;
			}
			int num4 = array.Length << 32;
			int num5 = (int)(-12884901888L + num4);
			int num6 = num5 >> 30;
			object obj2 = (nint)array + num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X9_v8+20]");
			bool flag = 0f < time;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X9_v8+20]");
			float num7 = 0f - time;
			bool flag3 = num7 == 0f;
			bool flag4 = !flag2;
			float num25;
			float num26;
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
			}
			else
			{
				int num27 = array.Length << 32;
				object obj3 = num27 + -4294967296L;
				object obj4 = num27 + -8589934592L;
				object obj5 = (nint)array + 32;
				int num28 = (int)((nint)obj4 >> 30);
				int num29 = (int)((nint)obj3 >> 30);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X11_v5+v403 @ X8_v16 (System.Int32)]");
				num25 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X11_v5+v404 @ X9_v12 (System.Int32)]");
				num26 = 0f;
			}
			int num30 = (int)(blend - 1);
			float num32 = default(float);
			float y;
			if (num30 >= 2)
			{
				switch (blend)
				{
				case MixBlend.Setup:
				{
					BoneData data3 = bone.Data;
					float num34 = num25 * num32;
					float num35 = num26 * num32;
					float x3 = num34 + data3.X;
					bone.X = x3;
					y = num35 + data3.Y;
					break;
				}
				case MixBlend.Add:
				{
					float num31 = num25 * num32;
					float num33 = num26 * num32;
					float x2 = num31 + bone.X;
					y = num33 + bone.Y;
					bone.X = x2;
					break;
				}
				default:
					return;
				}
			}
			else
			{
				BoneData data4 = bone.Data;
				float num36 = num25 + data4.X;
				float num37 = num36 - bone.X;
				float num38 = num37 * num32;
				float x4 = bone.X + num38;
				bone.X = x4;
				float num39 = num26 + data4.Y;
				float num40 = num39 - bone.Y;
				float num41 = num40 * num32;
				y = bone.Y + num41;
			}
			bone.Y = y;
		}
	}
}
