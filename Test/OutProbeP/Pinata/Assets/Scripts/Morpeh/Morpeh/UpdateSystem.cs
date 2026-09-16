using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh
{
	[Token(Token = "0x200001A")]
	public abstract class UpdateSystem : ScriptableObject, ISystem, IInitializer, IDisposable
	{
		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x18")]
		private World world;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x20")]
		private FilterProvider filter;

		[Token(Token = "0x1700000F")]
		public World World
		{
			[Token(Token = "0x6000082")]
			[Address(RVA = "0x15F8454", Offset = "0x15F8454", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.world;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return World;
			}
			[Token(Token = "0x6000083")]
			[Address(RVA = "0x15F845C", Offset = "0x15F845C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.world = value;\n\treturn;\n")]
			set
			{
				World = value;
			}
		}

		[Token(Token = "0x17000010")]
		public FilterProvider Filter
		{
			[Token(Token = "0x6000084")]
			[Address(RVA = "0x15F8464", Offset = "0x15F8464", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.filter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Filter;
			}
			[Token(Token = "0x6000085")]
			[Address(RVA = "0x15F846C", Offset = "0x15F846C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.filter = value;\n\treturn;\n")]
			set
			{
				Filter = value;
			}
		}

		[Token(Token = "0x6000086")]
		public abstract void OnAwake();

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x15F8474", Offset = "0x15F8474", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStart()
		{
		}

		[Token(Token = "0x6000088")]
		public abstract void OnUpdate(float deltaTime);

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x15F8478", Offset = "0x15F8478", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Dispose()
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x15F847C", Offset = "0x15F847C", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n\tV0 = 0;\n\tX8 = X0;\n\tX9 = X0;\n\tX8 = X8 + 0x10;\n\t*([X8]) = V0;\n\t*([X9]) = V0;\n\tX9 = X9 + 0x18;\n\tX11 = *([X1+18]);\n\tC = X11 < 1;\n\tC = ~C;\n\tTEMP1 = X11 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ 1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_003E;\n\tX10 = X0 + 8;\n\tX11 = X11 & 0xFFFFFFFF;\n\tX12 = X1 + 0x20;\n\tX13 = 0 | 1;\n\tX14 = X14 + 0x870;\nL_001D:\n\tX15 = *([X12]);\n\tX16 = X15 >> 6;\n\tC = X16 < 3;\n\tC = ~C;\n\tTEMP1 = X16 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X16 ^ 3;\n\tTEMP3 = X16 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0039;\n\tX16 = *([X14+X16*4]);\n\tX15 = X15 & 0x3F;\n\tX15 = X13 << X15;\n\tX17 = X16 + X14;\n\tX16 = X10;\n\t// 48 IndirectJump X17, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX16 = X0;\n\tgoto L_0036;\n\tX16 = X8;\n\tgoto L_0036;\n\tX16 = X9;\nL_0036:\n\tX17 = *([X16]);\n\tX15 = X17 | X15;\n\t*([X16]) = X15;\nL_0039:\n\tX11 = X11 - 1;\n\tX12 = X12 + 4;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_001D;\nL_003E:\n\treturn;\n\tX8 = *([X1]);\n\tX9 = X8 >> 6;\n\tC = X9 < 3;\n\tC = ~C;\n\tTEMP1 = X9 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 3;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0054;\n\tX10 = X10 + 0x880;\n\tX9 = *([X10+X9*4]);\n\tX9 = X9 + X10;\n\t// 81 IndirectJump X9, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX0 = X0 + 8;\n\tgoto L_0059;\nL_0054:\n\tX0 = 0;\n\treturn;\n\tX0 = X0 + 0x10;\n\tgoto L_0059;\n\tX0 = X0 + 0x18;\nL_0059:\n\tX9 = *([X0]);\n\tX8 = X8 & 0x3F;\n\tX10 = 0 | 1;\n\tX8 = X10 << X8;\n\tTEMP = X9 & X8;\n\tN = TEMP < 0;\n\tC = 0;\n\tV = 0;\n\tTEMPCOND = ~Z;\n\tX0 = TEMPCOND;\n\treturn;\n\tX8 = *([X1]);\n\tX9 = X8 >> 6;\n\tC = X9 < 3;\n\tC = ~C;\n\tTEMP1 = X9 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 3;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_0083;\n\tX10 = X10 + 0x8A0;\n\tX9 = *([X10+X9*4]);\n\tX9 = X9 + X10;\n\t// 119 IndirectJump X9, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX0 = X0 + 8;\n\tgoto L_007D;\n\tX0 = X0 + 0x10;\n\tgoto L_007D;\n\tX0 = X0 + 0x18;\nL_007D:\n\tX9 = *([X0]);\n\tX8 = X8 & 0x3F;\n\tX10 = 0 | 1;\n\tX8 = X10 << X8;\n\tX8 = X9 | X8;\n\t*([X0]) = X8;\nL_0083:\n\treturn;\n\tX8 = *([X1]);\n\tX9 = X8 >> 6;\n\tC = X9 < 3;\n\tC = ~C;\n\tTEMP1 = X9 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 3;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_00A2;\n\tX10 = X10 + 0x8C0;\n\tX9 = *([X10+X9*4]);\n\tX9 = X9 + X10;\n\t// 150 IndirectJump X9, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX0 = X0 + 8;\n\tgoto L_009C;\n\tX0 = X0 + 0x10;\n\tgoto L_009C;\n\tX0 = X0 + 0x18;\nL_009C:\n\tX9 = *([X0]);\n\tX8 = X8 & 0x3F;\n\tX10 = 0 | 1;\n\tX8 = X10 << X8;\n\tX8 = X9 ^ X8;\n\t*([X0]) = X8;\nL_00A2:\n\treturn;\n\tX8 = *([X1]);\n\tX9 = X8 >> 6;\n\tC = X9 < 3;\n\tC = ~C;\n\tTEMP1 = X9 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 3;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCOND = C & TEMPCOND;\n\tif (TEMPCOND) goto L_00C2;\n\tX10 = X10 + 0x8E0;\n\tX9 = *([X10+X9*4]);\n\tX9 = X9 + X10;\n\t// 181 IndirectJump X9, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\tX0 = X0 + 8;\n\tgoto L_00BB;\n\tX0 = X0 + 0x10;\n\tgoto L_00BB;\n\tX0 = X0 + 0x18;\nL_00BB:\n\tX9 = *([X0]);\n\tX8 = X8 & 0x3F;\n\tX10 = 0 | 1;\n\tX8 = X10 << X8;\n\tTEMP = ~X8;\n\tX8 = X9 & TEMP;\n\t*([X0]) = X8;\nL_00C2:\n\treturn;\n\tV0 = 0xFFFFFFFF;\n\t*([X0]) = V0;\n\t*([X0+10]) = V0;\n\treturn;\n\tV0 = 0;\n\t*([X0]) = V0;\n\t*([X0+10]) = V0;\n\treturn;\n\tX8 = *([X0]);\n\tX9 = *([X1]);\n\tC = X8 < X9;\n\tC = ~C;\n\tTEMP1 = X8 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X9;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FC;\n\tX9 = *([X0+8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FC;\n\tX9 = *([X0+10]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00FC;\n\tX9 = *([X0+18]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX0 = Z;\n\treturn;\nL_00FC:\n\tX0 = 0;\n\treturn;\n\t// 254 ShiftStack -80\n\tstack[20] = X21;\n\tstack[30] = X20;\n\tstack[38] = X19;\n\tstack[40] = X29;\n\tstack[48] = X30;\n\tX29 = &stack[40];\n\tX8 = *([202A06B]);\n\tX20 = X1;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0113;\n\tX8 = *([1EA63D0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202A06B]) = X8;\nL_0113:\n\tX8 = 0x1EFC000;\n\tX8 = *([1EFCB80]);\n\tX0 = *([X8]);\n\tif (TEMP) goto L_0123;\n\tX8 = *([X20]);\n\tC = X8 < X0;\n\tC = ~C;\n\tTEMP1 = X8 - X0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ X0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_012D;\nL_0123:\n\tV0 = *([X19+10]);\n\tX1 = &stack[0];\n\tstack[10] = V0;\n\tV0 = *([X19]);\n\tstack[0] = V0;\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X20;\n\tX2 = 0;\n\tX0 = System.ValueType::Equals(X0, X1, X2);\n\tgoto L_0161;\nL_012D:\n\tX0 = X20;\n\tX0 = 0x8D82AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0]);\n\tX9 = *([X19]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0160;\n\tX9 = *([X19+8]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0160;\n\tX9 = *([X19+10]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0160;\n\tX9 = *([X19+18]);\n\tC = X9 < X8;\n\tC = ~C;\n\tTEMP1 = X9 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X8;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX0 = Z;\n\tgoto L_0161;\nL_0160:\n\tX0 = 0;\nL_0161:\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX21 = stack[20];\n\tX0 = X0 & 1;\n\t// 359 ShiftStack 80\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UpdateSystem()
		{
		}
	}
}
