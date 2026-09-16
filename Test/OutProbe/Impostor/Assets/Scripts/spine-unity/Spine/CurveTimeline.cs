using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200000E")]
	public abstract class CurveTimeline : Timeline
	{
		[Token(Token = "0x4000038")]
		protected const float LINEAR = 0f;

		[Token(Token = "0x4000039")]
		protected const float STEPPED = 1f;

		[Token(Token = "0x400003A")]
		protected const float BEZIER = 2f;

		[Token(Token = "0x400003B")]
		protected const int BEZIER_SIZE = 19;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x10")]
		internal float[] curves;

		[Token(Token = "0x1700000C")]
		public int FrameCount
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x1522608", Offset = "0x1522608", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.curves;\n\tv8 = v2.Length * 0x6BCA1AF3;\n\tv9 = v8 >> 0x3F;\n\tv10 = v8 >> 0x23;\n\tv11 = v10 + v9;\n\treturnVal1 = v11 + 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001f: Expected O, but got I4
				float[] array = curves;
				object obj = array.Length * 1808407283;
				int num = (int)((nint)obj >> 63);
				int num2 = (int)((nint)obj >> 35);
				int num3 = num2 + num;
				return num3 + 1;
			}
		}

		[Token(Token = "0x1700000D")]
		public abstract int PropertyId
		{
			[Token(Token = "0x6000032")]
			get;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x1522640", Offset = "0x1522640", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = System.Single[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, frameCount, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37AD8]) = v36;\nL_0014:\n\tSystem.Object::.ctor(this);\n\tv50 = frameCount <= 0;\n\tif (v50) goto L_0033;\n\tv55 = frameCount * 0x13;\n\tv56 = v55 - 0x13;\n\t// 40 NewArr v57 @ X0_v17 (System.Single[]), typeof(System.Single[]), v56 @ X1_v4 (System.Int32)\n\tthis.curves = v57;\n\treturn;\nL_0033:\n\tv65 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v65, \"frameCount must be > 0: \");\n\tthrow v65;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CurveTimeline(int frameCount)
		{
			if (frameCount > 0)
			{
				curves = new float[frameCount * 19 - 19];
				return;
			}
			throw new ArgumentOutOfRangeException("frameCount must be > 0: ");
		}

		[Token(Token = "0x6000031")]
		public abstract void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixBlend blend, MixDirection direction);

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x15226F8", Offset = "0x15226F8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.curves;\n\tv7 = frameIndex * 0x13;\n\tv2[v7 @ X9_v3 (System.Int32)] = 0;\n\treturn;\n\tv18 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetLinear(int frameIndex)
		{
			float[] array = curves;
			int num = frameIndex * 19;
			array[num] = 0f;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x1522730", Offset = "0x1522730", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.curves;\n\tv7 = frameIndex * 0x13;\n\tv2[v7 @ X9_v3 (System.Int32)] = 0x3F800000;\n\treturn;\n\tv18 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetStepped(int frameIndex)
		{
			float[] array = curves;
			int num = frameIndex * 19;
			array[num] = 1f;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x152276C", Offset = "0x152276C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.curves;\n\tv7 = frameIndex * 0x13;\n\tv13 = v7 == v2.Length;\n\tif (v13) goto L_FFFFFFFF;\n\tv47 = v2[v7 @ X9_v3 (System.Int32)] == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv104 = v2[v7 @ X9_v3 (System.Int32)] - 1f;\n\tv100 = v104 == 0;\n\tv85 = ~v100;\n\tv82 = ~v85;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\tgoto L_0036;\nL_0036:\n\treturn returnVal1;\n\tv18 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn returnVal2;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetCurveType(int frameIndex)
		{
			float[] array = curves;
			int num = frameIndex * 19;
			if (num != array.Length && array[num] != 0f)
			{
				float num2 = array[num] - 1f;
				if (num2 != 0f)
				{
					return 2f;
				}
				return 1f;
			}
			return 0f;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x15227C8", Offset = "0x15227C8", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.curves;\n\tv7 = frameIndex * 0x13;\n\tv147 = v7 + 1;\n\tv103 = v7 + 0x13;\n\tv2[v7 @ X11_v2 (System.Int32)] = 0x40000000;\n\tv114 = v147 >= v103;\n\tif (v114) goto L_0073;\n\t// 39 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv156 = cx1 * cx2;\n\tv158 = cy1 - cy2;\n\t// 48 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v158 * 0;\n\t// 54 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 59 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv118 = v123 * 0;\n\t// 61 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv168 = v118 * v98;\n\t// 64 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv116 = v156 + v168;\nL_005A:\n\tv2[v147 @ X10_v6 (System.Int32)] = v115;\n\t// 95 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv147 = v147 + 2;\n\tv116 = v116 + v123;\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv115 = v115 + v116;\n\tv185 = v147 < v103;\n\tif (v185) goto L_005A;\nL_0073:\n\treturn;\n\tv19 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetCurve(int frameIndex, float cx1, float cy1, float cx2, float cy2)
		{
			float[] array = curves;
			int num = frameIndex * 19;
			int num2 = num + 1;
			int num3 = num + 19;
			array[num] = 2f;
			if (num2 < num3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				float num4 = cx1 * cx2;
				float num5 = cy1 - cy2;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				float num6 = num5 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				float num7 = num6 * 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				object obj = default(object);
				float num8 = num7 * (float)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				float num9 = num4 + num8;
				float num10 = num9;
				do
				{
					array[num2] = num10;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					num2 += 2;
					num9 += num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					num10 += num9;
				}
				while (num2 < num3);
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x15228DC", Offset = "0x15228DC", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = Spine.MathUtils;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, frameIndex, methodInfo, v29, v30, v31, v32, v33, percent, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37AD9]) = v43;\nL_001B:\n\tgoto L_0021;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v44, frameIndex, methodInfo, v29, v30, v31, v32, v33, percent, v34, v35, v36, v37, v38, v39, v40);\nL_0021:\n\treturnVal2 = Spine.MathUtils::Clamp(percent, 0f, 1f);\n\tv55 = this.curves;\n\tv59 = frameIndex * 0x13;\n\tv132 = v55[v59 @ X10_v3 (System.Int32)] == 0;\n\tif (v132) goto L_00A3;\n\tv212 = v55[v59 @ X10_v3 (System.Int32)] == 1f;\n\tif (v212) goto L_FFFFFFFF;\n\tv148 = v59 + 1;\n\tv145 = v59 + 0x13;\n\tv314 = v148 >= v145;\n\tif (v314) goto L_FFFFFFFF;\nL_0059:\n\tv137 = v147 + 1;\n\tv143 = v55[v137 @ X14_v7 (System.Int32)] >= returnVal2;\n\tif (v143) goto L_00A4;\n\tv319 = v147 + 2;\n\tv367 = v147 + 3;\n\tv140 = v140 - 2;\n\tv321 = v367 < v145;\n\tif (v321) goto L_0059;\n\tv148 = v319 + 1;\n\tgoto L_0087;\n\tgoto L_00A3;\nL_0087:\n\tv202 = v148 - 1;\n\tv363 = returnVal2 - v206;\n\tv262 = 1f - v206;\n\tv365 = 1f - v55[v202 @ X10_v7 (System.Int32)];\n\tv375 = v363 * v365;\nL_009A:\n\tv380 = v375 / v262;\n\treturnVal2 = v259 + v380;\nL_00A3:\n\treturn returnVal2;\nL_00A4:\n\tv207 = v140 == 0;\n\tif (v207) goto L_00D4;\n\tv200 = v147 - 1;\n\tv146 = v147 + 2;\n\tv371 = v55[v146 @ X12_v6 (System.Int32)] - v55[v147 @ X11_v9 (System.Int32)];\n\tv389 = returnVal2 - v55[v200 @ X10_v9 (System.Int32)];\n\tv375 = v389 * v371;\n\tv262 = v55[v137 @ X14_v7 (System.Int32)] - v55[v200 @ X10_v9 (System.Int32)];\n\tgoto L_009A;\nL_00D4:\n\tv201 = v59 + 2;\n\tv384 = returnVal2 * v55[v201 @ X10_v8 (System.Int32)];\n\treturnVal2 = v384 / v55[v137 @ X14_v7 (System.Int32)];\n\tgoto L_00A3;\n\tv121 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 179 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetCurvePercent(int frameIndex, float percent)
		{
			float num = MathUtils.Clamp(percent, 0f, 1f);
			float[] array = curves;
			int num2 = frameIndex * 19;
			int num3;
			float num5;
			int num8;
			int num9;
			float num15;
			float num16;
			float num17;
			if (array[num2] != 0f)
			{
				if (array[num2] != 1f)
				{
					num3 = num2 + 1;
					int num4 = num2 + 19;
					if (num3 >= num4)
					{
						num5 = 0f;
						goto IL_031b;
					}
					int num6 = 0;
					int num7 = num2;
					while (true)
					{
						num8 = num7 + 1;
						if (!(array[num8] < num))
						{
							break;
						}
						num9 = num7 + 2;
						int num10 = num7 + 3;
						num6 -= 2;
						bool flag = num10 < num4;
						num7 = num9;
						if (flag)
						{
							continue;
						}
						goto IL_0157;
					}
					if (num6 != 0)
					{
						int num11 = num7 - 1;
						int num12 = num7 + 2;
						float num13 = array[num12] - array[num7];
						float num14 = num - array[num11];
						num15 = num14 * num13;
						num16 = array[num8] - array[num11];
						num17 = array[num7];
						goto IL_032e;
					}
					int num18 = num2 + 2;
					float num19 = num * array[num18];
					num = num19 / array[num8];
				}
				else
				{
					num = 0f;
				}
			}
			goto IL_0303;
			IL_032e:
			float num20 = num15 / num16;
			num = num17 + num20;
			goto IL_0303;
			IL_0157:
			num3 = num9 + 1;
			num5 = array[num8];
			goto IL_031b;
			IL_0303:
			return num;
			IL_031b:
			int num21 = num3 - 1;
			float num22 = num - num5;
			num16 = 1f - num5;
			float num23 = 1f - array[num21];
			num15 = num22 * num23;
			num17 = array[num21];
			goto IL_032e;
		}
	}
}
