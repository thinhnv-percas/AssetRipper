using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000C")]
public class IronSourcePlacement
{
	[Token(Token = "0x4000054")]
	[FieldOffset(Offset = "0x10")]
	private string rewardName;

	[Token(Token = "0x4000055")]
	[FieldOffset(Offset = "0x18")]
	private int rewardAmount;

	[Token(Token = "0x4000056")]
	[FieldOffset(Offset = "0x20")]
	private string placementName;

	[Token(Token = "0x6000179")]
	[Address(RVA = "0x158F604", Offset = "0x158F604", Length = "0x44")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.placementName = placementName;\n\tthis.rewardName = rewardName;\n\tthis.rewardAmount = rewardAmount;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourcePlacement(string placementName, string rewardName, int rewardAmount)
	{
		this.placementName = placementName;
		this.rewardName = rewardName;
		this.rewardAmount = rewardAmount;
	}

	[Token(Token = "0x600017A")]
	[Address(RVA = "0x159E290", Offset = "0x159E290", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rewardName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string getRewardName()
	{
		return rewardName;
	}

	[Token(Token = "0x600017B")]
	[Address(RVA = "0x159E298", Offset = "0x159E298", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rewardAmount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public int getRewardAmount()
	{
		return rewardAmount;
	}

	[Token(Token = "0x600017C")]
	[Address(RVA = "0x159E2A0", Offset = "0x159E2A0", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.placementName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string getPlacementName()
	{
		return placementName;
	}

	[Token(Token = "0x600017D")]
	[Address(RVA = "0x159E2A8", Offset = "0x159E2A8", Length = "0x190")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ED20C8]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297B9]) = v42;\nL_0019:\n\t// 25 NewArr v47 @ X0_v3 (System.Object[]), typeof(System.Object[]), 5\n\tv51 = this.placementName == 0;\n\tif (v51) goto L_0026;\n\t// 35 IsInst v105 @ X0_v30, typeof(System.Object), this.placementName (System.String)\nL_0026:\n\tv276 = v47.Length;\n\tv112 = v47.Length == 0;\n\tif (v112) goto L_009A;\n\tv47[0] = this.placementName;\n\tv116 = \" : \" == 0;\n\tif (v116) goto L_0035;\n\t// 49 IsInst v242 @ X0_v28, typeof(System.Object), \" : \"\n\tv276 = v47.Length;\nL_0035:\n\tv259 = v276 < 1;\n\tv159 = ~v259;\n\tv154 = v276 - 1;\n\tv144 = v154 == 0;\n\tv260 = ~v159;\n\tv119 = v260 | v144;\n\tif (v119) goto L_009A;\n\tv47[1] = \" : \";\n\tv263 = this.rewardName == 0;\n\tif (v263) goto L_004D;\n\t// 73 IsInst v243 @ X0_v27, typeof(System.Object), this.rewardName (System.String)\n\tv276 = v47.Length;\nL_004D:\n\tv266 = v276 < 2;\n\tv160 = ~v266;\n\tv155 = v276 - 2;\n\tv145 = v155 == 0;\n\tv267 = ~v160;\n\tv120 = v267 | v145;\n\tif (v120) goto L_009A;\n\tv47[2] = this.rewardName;\n\tv269 = \" : \" == 0;\n\tif (v269) goto L_0063;\n\t// 95 IsInst v244 @ X0_v25, typeof(System.Object), \" : \"\n\tv276 = v47.Length;\nL_0063:\n\tv271 = v276 < 3;\n\tv161 = ~v271;\n\tv156 = v276 - 3;\n\tv146 = v156 == 0;\n\tv272 = ~v161;\n\tv121 = v272 | v146;\n\tif (v121) goto L_009A;\n\tv47[3] = \" : \";\n\tv276 = this.rewardAmount;\n\t// 119 Box v278 @ X0_v19, typeof(System.Int32), &v276 @ X8_v15 (System.Int32)\n\tv279 = v278 == 0;\n\tif (v279) goto L_0082;\n\t// 126 IsInst v245 @ X0_v24, typeof(System.Object), v278 @ X0_v19\nL_0082:\n\tv282 = v47.Length < 4;\n\tv158 = ~v282;\n\tv153 = v47.Length - 4;\n\tv143 = v153 == 0;\n\tv283 = ~v158;\n\tv118 = v283 | v143;\n\tif (v118) goto L_009A;\n\tv47[4] = v278;\n\treturnVal2 = System.String::Concat(v47);\n\treturn returnVal2;\nL_009A:\n\tv192 = new System.IndexOutOfRangeException();\n\tgoto L_009F;\n\tv257 = new System.ArrayTypeMismatchException();\nL_009F:\n\tthrow v262;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override string ToString()
	{
		//IL_028a: Expected O, but got I4
		//IL_02e7: Expected O, but got I4
		//IL_0344: Expected O, but got I4
		//IL_01e3: Expected O, but got I4
		object[] array = new object[5];
		if (placementName != null)
		{
			object obj = placementName as object;
		}
		int num = array.Length;
		if (array.Length != 0)
		{
			array[0] = placementName;
			if (" : " != null)
			{
				object obj2 = " : " as object;
				num = array.Length;
			}
			bool flag = num < 1;
			bool flag2 = !flag;
			object obj3 = num - 1;
			bool flag3 = obj3 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				array[1] = " : ";
				if (rewardName != null)
				{
					object obj4 = rewardName as object;
					num = array.Length;
				}
				bool flag5 = num < 2;
				bool flag6 = !flag5;
				object obj5 = num - 2;
				bool flag7 = obj5 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					array[2] = rewardName;
					if (" : " != null)
					{
						object obj6 = " : " as object;
						num = array.Length;
					}
					bool flag9 = num < 3;
					bool flag10 = !flag9;
					object obj7 = num - 3;
					bool flag11 = obj7 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						array[3] = " : ";
						num = rewardAmount;
						object obj8 = num;
						if (obj8 != null)
						{
							object obj9 = obj8 as object;
						}
						bool flag13 = array.Length < 4;
						bool flag14 = !flag13;
						object obj10 = array.Length - 4;
						bool flag15 = obj10 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							array[4] = obj8;
							return string.Concat(array);
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}
}
