using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x2000011")]
	public class ScaleTimeline : TranslateTimeline, IBoneTimeline
	{
		[Token(Token = "0x17000014")]
		public override int PropertyId
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x1523390", Offset = "0x1523390", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.boneIndex + 0x2000000;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BoneIndex + 33554432;
			}
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x152338C", Offset = "0x152338C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.TranslateTimeline::.ctor(this, frameCount);\n\treturn;\n")]
		public ScaleTimeline(int frameCount)
			: base(frameCount)
		{
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15233A0", Offset = "0x15233A0", Length = "0x5A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = System.Math;\n\tv37 = alpha;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, skeleton, firedEvents, blend, direction, methodInfo, v42, v43, lastTime, time, alpha, v45, v46, v47, v48, v49);\n\tv51 = v37;\n\tv56 = 1;\n\t*([1A37ADC]) = v56;\nL_001F:\n\tv58 = skeleton.bones;\n\tv227 = v58.Items;\n\tv189 = this.boneIndex;\n\tv111 = v227[v189 @ X9_v3 (System.Int32)];\n\tv418 = ~v111.active;\n\tif (v418) goto L_021E;\n\tv221 = this.frames;\n\tv98 = v221[0] <= time;\n\tif (v98) goto L_006D;\n\tv153 = blend == 1;\n\tif (v153) goto L_0162;\n\tv531 = blend == 0;\n\tv498 = ~v531;\n\tif (v498) goto L_021E;\n\tv230 = v111.data;\n\tv450 = v230.scaleX;\n\tgoto L_016C;\nL_006D:\n\tv534 = v221.Length << 0x20;\n\tv535 = 0xFFFFFFFD00000000 + v534;\n\tv116 = v535 >> 0x1E;\n\tv321 = v221 + v116;\n\tv536 = *([v321 @ X9_v9+20]) < time;\n\tv179 = ~v536;\n\tv171 = *([v321 @ X9_v9+20]) - time;\n\tv155 = v171 == 0;\n\tv537 = ~v179;\n\tv99 = v537 | v155;\n\tif (v99) goto L_00F5;\n\tv328 = Spine.Animation::BinarySearch(v221, time, 3);\n\tv335 = v328 - 2;\n\tv252 = v328 - 3;\n\tv639 = v328 * 0x55555556;\n\tv323 = v639 >> 0x3F;\n\tv640 = v639 >> 0x20;\n\tv325 = time - v221[v328 @ X0_v51 (System.Int32)];\n\tv641 = v221[v252 @ X11_v9 (System.Int32)] - v221[v328 @ X0_v51 (System.Int32)];\n\tv642 = v640 + v323;\n\tv643 = v325 / v641;\n\tv94 = v642 - 1;\n\tv644 = 1f - v643;\n\tv104 = Spine.CurveTimeline::GetCurvePercent(this, v94, v644);\n\tv231 = v328 + 1;\n\tv190 = v111.data;\n\tv722 = v190.scaleX;\n\t// 238 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv573 = v221[v231 @ X8_v48 (System.Int32)] - v221[v335 @ X8_v42 (System.Int32)];\n\tv749 = v573 * v750;\n\tv751 = v221[v335 @ X8_v42 (System.Int32)] + v749;\n\tv106 = v190.scaleX * v751;\n\tgoto L_010F;\nL_00F5:\n\tv191 = v111.data;\n\tv555 = v221.Length << 0x20;\n\tv557 = v555 + 0xFFFFFFFE00000000;\n\tv558 = v557 >> 0x1E;\n\tv559 = v221 + 0x20;\n\tv722 = v191.scaleX;\n\t// 259 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv106 = *([v559 @ X12_v6+v558 @ X11_v8 (System.Int32)]) * v191.scaleX;\nL_010F:\n\tv595 = v195 != 1f;\n\tif (v595) goto L_0120;\n\tv445 = blend != 3;\n\tif (v445) goto L_016E;\n\tv548 = v106 - v722;\n\tv450 = v111.scaleX + v548;\n\tgoto L_016C;\nL_0120:\n\tv511 = blend - 1;\n\tv607 = direction != 1;\n\tif (v607) goto L_0170;\n\tv609 = v511 < 2;\n\tv610 = ~v609;\n\tv101 = ~v610;\n\tif (v101) goto L_01A3;\n\tv157 = blend == 3;\n\tif (v157) goto L_01EB;\n\tv667 = blend == 0;\n\tv499 = ~v667;\n\tif (v499) goto L_021E;\n\tgoto L_0151;\n\tv721 = \"il2cpp_codegen_runtime_class_init\"(v697, v95, firedEvents, blend, direction, methodInfo, v42, v43, v448, v87, v195, v69, v71, v73, v48, v49);\n\tv723 = v695;\n\tv725 = v696;\nL_0151:\n\tv727 = UnityEngine.Mathf::Abs(v106);\n\tv754 = System.Math::Sign(v722);\n\tv771 = v727 * v754;\n\tv779 = UnityEngine.Mathf::Abs(v734);\n\tv816 = v771 - v722;\n\tv817 = v816 * v195;\n\tv786 = v722 + v817;\n\tv111.scaleX = v786;\n\tgoto L_01BC;\nL_0162:\n\tv233 = v111.data;\n\t// 360 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv541 = v233.scaleX - v111.scaleX;\n\tv542 = v541 * v543;\n\tv450 = v111.scaleX + v542;\nL_016C:\n\tv111.scaleX = v450;\n\tgoto L_021E;\nL_016E:\n\tv111.scaleX = v106;\n\tgoto L_021E;\nL_0170:\n\tv618 = v511 < 2;\n\tv619 = ~v618;\n\tv100 = ~v619;\n\tif (v100) goto L_01CA;\n\tv156 = blend == 3;\n\tif (v156) goto L_0227;\n\tv679 = blend == 0;\n\tv501 = ~v679;\n\tif (v501) goto L_021E;\n\tgoto L_0195;\n\tv738 = \"il2cpp_codegen_runtime_class_init\"(v709, v95, firedEvents, blend, direction, methodInfo, v42, v43, v448, v87, v195, v69, v71, v73, v48, v49);\n\tv739 = v77;\nL_0195:\n\tv204 = System.Math::Sign(v106);\n\tv234 = v111.data;\n\tv762 = v234.scaleY;\n\tv761 = UnityEngine.Mathf::Abs(v722);\n\tv425 = v761 * v204;\n\tgoto L_01D3;\nL_01A3:\n\tv506 = v111.scaleY;\n\tgoto L_01AC;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v652, v95, firedEvents, blend, direction, methodInfo, v42, v43, v448, v87, v195, v69, v71, v73, v48, v49);\n\tv676 = v651;\nL_01AC:\n\tv678 = UnityEngine.Mathf::Abs(v106);\n\tv706 = System.Math::Sign(v111.scaleX);\n\tv731 = v678 * v706;\n\tv732 = v731 - v111.scaleX;\n\tv735 = v732 * v195;\n\tv736 = v111.scaleX + v735;\n\tv779 = UnityEngine.Mathf::Abs(v734);\n\tv111.scaleX = v736;\nL_01BC:\n\tv804 = System.Math::Sign(v506);\n\tv819 = v779 * v804;\n\tv833 = v819 - v506;\n\tgoto L_0210;\nL_01CA:\n\tgoto L_01CE;\n\tv686 = \"il2cpp_codegen_runtime_class_init\"(v662, v95, firedEvents, blend, direction, methodInfo, v42, v43, v448, v87, v195, v69, v71, v73, v48, v49);\n\tv688 = v661;\nL_01CE:\n\tv691 = UnityEngine.Mathf::Abs(v111.scaleX);\n\tv719 = System.Math::Sign(v106);\n\tv762 = v111.scaleY;\n\tv425 = v691 * v719;\nL_01D3:\n\tv421 = UnityEngine.Mathf::Abs(v762);\n\tv495 = System.Math::Sign(v345);\n\tv823 = v421 * v495;\n\tv824 = v345 - v823;\n\tv825 = v435 - v425;\n\tv826 = v825 * v491;\n\tv487 = v824 * v491;\n\tv441 = v425 + v826;\n\tv449 = v823 + v487;\n\tv111.scaleX = v441;\n\tv111.scaleY = v449;\n\tgoto L_021E;\nL_01EB:\n\tv506 = v111.scaleY;\n\tgoto L_01F4;\n\tv701 = \"il2cpp_codegen_runtime_class_init\"(v670, v95, firedEvents, blend, direction, methodInfo, v42, v43, v448, v87, v195, v69, v71, v73, v48, v49);\nL_01F4:\n\tv205 = System.Math::Sign(v111.scaleX);\n\tv235 = v111.data;\n\tv758 = UnityEngine.Mathf::Abs(v106);\n\tv774 = v758 * v205;\n\tv775 = v774 - v235.scaleX;\n\tv776 = v775 * v195;\n\tv777 = v111.scaleX + v776;\n\tv111.scaleX = v777;\n\tv206 = System.Math::Sign(v111.scaleY);\n\tv236 = v111.data;\n\tv831 = UnityEngine.Mathf::Abs(v345);\n\tv836 = v831 * v206;\n\tv833 = v836 - v236.scaleY;\nL_0210:\n\tv835 = v833 * v489;\n\tv447 = v506 + v835;\n\tv111.scaleY = v447;\nL_021E:\n\treturn;\nL_0227:\n\tgoto L_022B;\n\tv713 = \"il2cpp_codegen_runtime_class_init\"(v682, v95, firedEvents, blend, direction, methodInfo, v42, v43, v448, v87, v195, v69, v71, v73, v48, v49);\n\tv715 = v79;\nL_022B:\n\tv718 = System.Math::Sign(v106);\n\tv207 = System.Math::Sign(v345);\n\tv237 = v111.data;\n\t// 568 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 569 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 570 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv549 = v111.scaleX * v718;\n\tv809 = v237.scaleX * v718;\n\tv811 = v106 - v809;\n\tv812 = v811 * v543;\n\tv450 = v549 + v812;\n\tgoto L_016C;\n\tv241 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 385 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction)
		{
			//IL_0131: Expected I4, but got I8
			//IL_014d: Expected O, but got I
			//IL_037a: Expected O, but got I8
			//IL_0398: Expected O, but got I
			ExposedList<Bone> bones = skeleton.Bones;
			Bone[] items = bones.Items;
			int num = BoneIndex;
			Bone bone = items[num];
			if (!bone.Active)
			{
				return;
			}
			float[] array = Frames;
			float scaleX;
			object obj = default(object);
			float num27;
			float num37;
			float num38;
			if (array[0] > time)
			{
				switch (blend)
				{
				case MixBlend.Setup:
				{
					BoneData data2 = bone.Data;
					scaleX = data2.ScaleX;
					break;
				}
				case MixBlend.First:
				{
					BoneData data = bone.Data;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num2 = data.ScaleX - bone.ScaleX;
					float num3 = num2 * (float)obj;
					scaleX = bone.ScaleX + num3;
					break;
				}
				default:
					return;
				}
			}
			else
			{
				int num4 = array.Length << 32;
				int num5 = (int)(-12884901888L + num4);
				int num6 = num5 >> 30;
				object obj2 = (nint)array + num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ X9_v9+20]");
				bool flag = 0f < time;
				bool flag2 = !flag;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ X9_v9+20]");
				float num7 = 0f - time;
				bool flag3 = num7 == 0f;
				bool flag4 = !flag2;
				float scaleX2;
				float num22;
				if (!(flag4 || flag3))
				{
					int num8 = Animation.BinarySearch(array, time, 3);
					int num9 = num8 - 2;
					int num10 = num8 - 3;
					int num11 = num8 * 1431655766;
					int num12 = num11 >> 63;
					int num13 = num11 >> 32;
					float num14 = time - array[num8];
					float num15 = array[num10] - array[num8];
					int num16 = num13 + num12;
					float num17 = num14 / num15;
					int frameIndex = num16 - 1;
					float percent = 1f - num17;
					float curvePercent = GetCurvePercent(frameIndex, percent);
					int num18 = num8 + 1;
					BoneData data3 = bone.Data;
					scaleX2 = data3.ScaleX;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					float num19 = array[num18] - array[num9];
					object obj3 = default(object);
					float num20 = num19 * (float)obj3;
					float num21 = array[num9] + num20;
					num22 = data3.ScaleX * num21;
				}
				else
				{
					BoneData data4 = bone.Data;
					int num23 = array.Length << 32;
					object obj4 = num23 + -8589934592L;
					int num24 = (int)((nint)obj4 >> 30);
					object obj5 = (nint)array + 32;
					scaleX2 = data4.ScaleX;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v559 @ X12_v6+v558 @ X11_v8 (System.Int32)]");
					num22 = 0f * data4.ScaleX;
				}
				float num25 = default(float);
				if (num25 != 1f)
				{
					int num26 = (int)(blend - 1);
					float num35 = default(float);
					if (direction == MixDirection.Out)
					{
						float num42;
						float num43 = default(float);
						if (num26 >= 2)
						{
							if (blend == MixBlend.Add)
							{
								num27 = bone.ScaleY;
								int num28 = Math.Sign(bone.ScaleX);
								BoneData data5 = bone.Data;
								float num29 = Mathf.Abs(num22);
								float num30 = num29 * (float)num28;
								float num31 = num30 - data5.ScaleX;
								float num32 = num31 * num25;
								float scaleX3 = bone.ScaleX + num32;
								bone.ScaleX = scaleX3;
								int num33 = Math.Sign(bone.ScaleY);
								BoneData data6 = bone.Data;
								float num34 = Mathf.Abs(num35);
								float num36 = num34 * (float)num33;
								num37 = num36 - data6.ScaleY;
								num38 = num25;
								goto IL_09c7;
							}
							if (blend != MixBlend.Setup)
							{
								return;
							}
							float num39 = Mathf.Abs(num22);
							int num40 = Math.Sign(scaleX2);
							float num41 = num39 * (float)num40;
							num42 = Mathf.Abs(num43);
							float num44 = num41 - scaleX2;
							float num45 = num44 * num25;
							float scaleX4 = scaleX2 + num45;
							bone.ScaleX = scaleX4;
							num38 = num25;
							num27 = num43;
						}
						else
						{
							num27 = bone.ScaleY;
							float num46 = Mathf.Abs(num22);
							int num47 = Math.Sign(bone.ScaleX);
							float num48 = num46 * (float)num47;
							float num49 = num48 - bone.ScaleX;
							float num50 = num49 * num25;
							float scaleX5 = bone.ScaleX + num50;
							num42 = Mathf.Abs(num43);
							bone.ScaleX = scaleX5;
							num38 = num25;
						}
						int num51 = Math.Sign(num27);
						float num52 = num42 * (float)num51;
						num37 = num52 - num27;
						goto IL_09c7;
					}
					float scaleY;
					float num61;
					float num62;
					float num63;
					if (num26 >= 2)
					{
						if (blend == MixBlend.Add)
						{
							int num53 = Math.Sign(num22);
							int num54 = Math.Sign(num35);
							BoneData data7 = bone.Data;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
							float num55 = bone.ScaleX * (float)num53;
							float num56 = data7.ScaleX * (float)num53;
							float num57 = num22 - num56;
							float num58 = num57 * (float)obj;
							scaleX = num55 + num58;
							goto IL_07ec;
						}
						if (blend != MixBlend.Setup)
						{
							return;
						}
						int num59 = Math.Sign(num22);
						BoneData data8 = bone.Data;
						scaleY = data8.ScaleY;
						float num60 = Mathf.Abs(scaleX2);
						num61 = num60 * (float)num59;
						num62 = num22;
						num63 = num25;
					}
					else
					{
						float num64 = Mathf.Abs(bone.ScaleX);
						int num65 = Math.Sign(num22);
						scaleY = bone.ScaleY;
						num61 = num64 * (float)num65;
						num62 = num22;
						num63 = num25;
					}
					float num66 = Mathf.Abs(scaleY);
					int num67 = Math.Sign(num35);
					float num68 = num66 * (float)num67;
					float num69 = num35 - num68;
					float num70 = num62 - num61;
					float num71 = num70 * num63;
					float num72 = num69 * num63;
					float scaleX6 = num61 + num71;
					float scaleY2 = num68 + num72;
					bone.ScaleX = scaleX6;
					bone.ScaleY = scaleY2;
					return;
				}
				if (blend != MixBlend.Add)
				{
					bone.ScaleX = num22;
					return;
				}
				float num73 = num22 - scaleX2;
				scaleX = bone.ScaleX + num73;
			}
			goto IL_07ec;
			IL_07ec:
			bone.ScaleX = scaleX;
			return;
			IL_09c7:
			float num74 = num37 * num38;
			float scaleY3 = num27 + num74;
			bone.ScaleY = scaleY3;
		}
	}
}
