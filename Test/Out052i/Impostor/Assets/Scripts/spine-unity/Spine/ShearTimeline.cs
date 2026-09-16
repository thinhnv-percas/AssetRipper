using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000012")]
	public class ShearTimeline : TranslateTimeline, IBoneTimeline
	{
		[Token(Token = "0x17000015")]
		public override int PropertyId
		{
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x1523948", Offset = "0x1523948", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.boneIndex + 0x3000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BoneIndex + 50331648;
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x1523944", Offset = "0x1523944", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.TranslateTimeline::.ctor(this, frameCount);\n\treturn;\n")]
		public ShearTimeline(int frameCount)
			: base(frameCount)
		{
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x1523958", Offset = "0x1523958", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = skeleton.bones;\n\tv125 = v20.Items;\n\tv121 = this.boneIndex;\n\tv60 = v125[v121 @ X9_v3 (System.Int32)];\n\tv330 = ~v60.active;\n\tif (v330) goto L_0139;\n\tv58 = this.frames;\n\tv47 = v58[0] <= time;\n\tif (v47) goto L_005D;\n\tv92 = blend == 1;\n\tif (v92) goto L_011B;\n\tv373 = blend == 0;\n\tv356 = ~v373;\n\tif (v356) goto L_0139;\n\tv128 = v60.data;\n\tv341 = v128.shearX;\n\tgoto L_0125;\nL_005D:\n\tv376 = v58.Length << 0x20;\n\tv377 = 0xFFFFFFFD00000000 + v376;\n\tv183 = v377 >> 0x1E;\n\tv254 = v58 + v183;\n\tv379 = *([v254 @ X9_v8+20]) < time;\n\tv380 = ~v379;\n\tv381 = *([v254 @ X9_v8+20]) - time;\n\tv383 = v381 == 0;\n\tv388 = ~v380;\n\tv174 = v388 | v383;\n\tif (v174) goto L_00DC;\n\tv167 = Spine.Animation::BinarySearch(v58, time, 3);\n\tv260 = v167 - 2;\n\tv255 = v167 - 1;\n\tv161 = v167 - 3;\n\tv460 = v167 * 0x55555556;\n\tv256 = v460 >> 0x3F;\n\tv461 = v460 >> 0x20;\n\tv153 = time - v58[v167 @ X0_v8 (System.Int32)];\n\tv462 = v58[v161 @ X11_v6 (System.Int32)] - v58[v167 @ X0_v8 (System.Int32)];\n\tv463 = v461 + v256;\n\tv464 = v153 / v462;\n\tv171 = v463 - 1;\n\tv465 = 1f - v464;\n\tv179 = Spine.CurveTimeline::GetCurvePercent(this, v171, v465);\n\tv261 = v167 + 1;\n\tv257 = v167 + 2;\n\tv473 = v58[v261 @ X8_v23 (System.Int32)] - v58[v260 @ X8_v17 (System.Int32)];\n\tv474 = v58[v257 @ X9_v18 (System.Int32)] - v58[v255 @ X9_v13 (System.Int32)];\n\tv475 = v179 * v473;\n\tv476 = v179 * v474;\n\tv29 = v58[v260 @ X8_v17 (System.Int32)] + v475;\n\tv56 = v58[v255 @ X9_v13 (System.Int32)] + v476;\n\tgoto L_00E6;\nL_00DC:\n\tv397 = v58.Length << 0x20;\n\tv400 = v397 + 0xFFFFFFFF00000000;\n\tv401 = v397 + 0xFFFFFFFE00000000;\n\tv402 = v58 + 0x20;\n\tv403 = v401 >> 0x1E;\n\tv404 = v400 >> 0x1E;\n\tv29 = *([v402 @ X11_v5+v403 @ X8_v16 (System.Int32)]);\n\tv56 = *([v402 @ X11_v5+v404 @ X9_v12 (System.Int32)]);\nL_00E6:\n\tv353 = blend - 1;\n\tv422 = v353 < 2;\n\tv112 = ~v422;\n\tv48 = ~v112;\n\tif (v48) goto L_010A;\n\tv93 = blend == 3;\n\tif (v93) goto L_0129;\n\tv426 = blend == 0;\n\tv357 = ~v426;\n\tif (v357) goto L_0139;\n\tv129 = v60.data;\n\tv466 = v29 * v24;\n\tv467 = v56 * v24;\n\tv468 = v466 + v129.shearX;\n\tv60.shearX = v468;\n\tv340 = v467 + v129.shearY;\n\tgoto L_012E;\nL_010A:\n\tv130 = v60.data;\n\tv434 = v29 + v130.shearX;\n\tv437 = v434 - v60.shearX;\n\tv438 = v437 * v24;\n\tv439 = v60.shearX + v438;\n\tv60.shearX = v439;\n\tv441 = v56 + v130.shearY;\n\tv442 = v441 - v60.shearY;\n\tv443 = v442 * v24;\n\tv340 = v60.shearY + v443;\n\tgoto L_012E;\nL_011B:\n\tv131 = v60.data;\n\t// 289 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv392 = v131.shearX - v60.shearX;\n\tv393 = v392 * v394;\n\tv341 = v60.shearX + v393;\nL_0125:\n\tv60.shearX = v341;\n\tgoto L_0139;\nL_0129:\n\tv429 = v29 * v24;\n\tv430 = v56 * v24;\n\tv431 = v429 + v60.shearX;\n\tv340 = v430 + v60.shearY;\n\tv60.shearX = v431;\nL_012E:\n\tv60.shearY = v340;\nL_0139:\n\treturn;\n\tv140 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				float shearX;
				switch (blend)
				{
				case MixBlend.Setup:
				{
					BoneData data2 = bone.Data;
					shearX = data2.ShearX;
					break;
				}
				case MixBlend.First:
				{
					BoneData data = bone.Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = data.ShearX - bone.ShearX;
					object obj = default(object);
					float num3 = num2 * (float)obj;
					shearX = bone.ShearX + num3;
					break;
				}
				default:
					return;
				}
				bone.ShearX = shearX;
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
			float shearY;
			if (num30 >= 2)
			{
				switch (blend)
				{
				case MixBlend.Setup:
				{
					BoneData data3 = bone.Data;
					float num34 = num25 * num32;
					float num35 = num26 * num32;
					float shearX3 = num34 + data3.ShearX;
					bone.ShearX = shearX3;
					shearY = num35 + data3.ShearY;
					break;
				}
				case MixBlend.Add:
				{
					float num31 = num25 * num32;
					float num33 = num26 * num32;
					float shearX2 = num31 + bone.ShearX;
					shearY = num33 + bone.ShearY;
					bone.ShearX = shearX2;
					break;
				}
				default:
					return;
				}
			}
			else
			{
				BoneData data4 = bone.Data;
				float num36 = num25 + data4.ShearX;
				float num37 = num36 - bone.ShearX;
				float num38 = num37 * num32;
				float shearX4 = bone.ShearX + num38;
				bone.ShearX = shearX4;
				float num39 = num26 + data4.ShearY;
				float num40 = num39 - bone.ShearY;
				float num41 = num40 * num32;
				shearY = bone.ShearY + num41;
			}
			bone.ShearY = shearY;
		}
	}
}
