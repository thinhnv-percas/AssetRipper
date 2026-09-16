using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Utils
{
	[Token(Token = "0x2000009")]
	internal class xxHash
	{
		[Token(Token = "0x400000D")]
		private const uint PRIME32_1 = 2654435761u;

		[Token(Token = "0x400000E")]
		private const uint PRIME32_2 = 2246822519u;

		[Token(Token = "0x400000F")]
		private const uint PRIME32_3 = 3266489917u;

		[Token(Token = "0x4000010")]
		private const uint PRIME32_4 = 668265263u;

		[Token(Token = "0x4000011")]
		private const uint PRIME32_5 = 374761393u;

		[Token(Token = "0x600002A")]
		[Address(RVA = "0xBD555C", Offset = "0xBD555C", Length = "0x3A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = len - 0x10;\n\tv29 = len >= 0x10;\n\tif (v29) goto L_0026;\n\tv107 = seed + 0x165667B1;\n\tgoto L_016A;\nL_0026:\n\tv317 = seed + 0x85EBCA77;\nL_0029:\n\tv328 = v315 - 7;\n\tv388 = v328 + 1;\n\tv403 = v388 + 1;\n\tv404 = v403 + 1;\n\tv405 = v404 + 1;\n\tv406 = v405 + 1;\n\tv407 = v406 + 1;\n\tv408 = v407 + 1;\n\tv409 = v408 + 1;\n\tv410 = v409 + 1;\n\tv411 = v410 + 1;\n\tv412 = v411 + 1;\n\tv413 = v412 + 1;\n\tv414 = v413 + 1;\n\tv415 = v414 + 1;\n\tv416 = v415 + 1;\n\tv701 = v315 - 3;\n\tv702 = v315 - 2;\n\tv703 = v416 + 1;\n\tv733 = v315 - 1;\n\tv735 = buf[v702 @ X6_v5 (System.Int32)] & 0xFF;\n\tv736 = v735 << 8;\n\tv737 = buf[v701 @ X17_v19 (System.Int32)] & 0xFFFFFFFFFFFF00FF;\n\tv738 = v737 | v736;\n\tv751 = buf[v733 @ X5_v5 (System.Int32)] & 0xFF;\n\tv752 = v751 << 0x10;\n\tv753 = v738 & 0xFFFFFFFFFF00FFFF;\n\tv754 = v753 | v752;\n\tv766 = buf[v315 @ X10_v21 (System.Int32)] & 0xFF;\n\tv767 = v766 << 0x18;\n\tv768 = v754 & 0xFFFFFF;\n\tv769 = v768 | v767;\n\tv779 = v769 * 0x85EBCA77;\n\tv780 = v317 + v779;\n\tv787 = v780 >> 0x13;\n\tv788 = v780 << 0xD;\n\tv789 = v787 | v788;\n\tv317 = v789 * 0x9E3779B1;\n\tv315 = v315 + 0x10;\n\tv112 = v703 <= v27;\n\tif (v112) goto L_0029;\n\t// 354 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 355 NotImplemented \"Instruction USHL not yet implemented.\"\n\t// 356 NotImplemented \"Instruction USHL not yet implemented.\"\n\tv50 = *([407CB0]) | v317;\n\t// 358 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv426 = v315 - 7;\nL_016A:\n\tv132 = len - 4;\n\tv422 = v107 + len;\n\tv146 = v426 > v132;\n\tif (v146) goto L_01DE;\nL_0189:\n\tv418 = v426 + 1;\n\tv427 = v418 + 1;\n\tv428 = v427 + 1;\n\tv665 = v426 + 2;\n\tv667 = v426 + 3;\n\tv668 = buf[v418 @ X16_v9 (System.Int32)] & 0xFF;\n\tv669 = v668 << 8;\n\tv670 = buf[v426 @ X11_v6 (System.Int32)] & 0xFFFFFFFFFFFF00FF;\n\tv671 = v670 | v669;\n\tv426 = v428 + 1;\n\tv672 = buf[v665 @ X2_v4 (System.Int32)] & 0xFF;\n\tv673 = v672 << 0x10;\n\tv674 = v671 & 0xFFFFFFFFFF00FFFF;\n\tv675 = v674 | v673;\n\tv676 = buf[v667 @ X3_v4 (System.Int32)] & 0xFF;\n\tv677 = v676 << 0x18;\n\tv678 = v675 & 0xFFFFFF;\n\tv268 = v678 | v677;\n\tv679 = v268 * 0xC2B2AE3D;\n\tv680 = v422 + v679;\n\tv276 = v680 >> 0xF;\n\tv681 = v680 << 0x11;\n\tv682 = v276 | v681;\n\tv422 = v682 * 0x27D4EB2F;\n\tv280 = v426 <= v132;\n\tif (v280) goto L_0189;\n\tv426 = v426 + 4;\nL_01DE:\n\tv234 = v426 >= len;\n\tif (v234) goto L_020A;\n\tv639 = buf + v426;\n\tv421 = v639 + 0x20;\n\tv419 = len - v426;\nL_01F6:\n\tv421 = v421 + 1;\n\tv342 = v419 - 1;\n\tv657 = *([v421 @ X15_v6]) * 0x165667B1;\n\tv658 = v423 + v657;\n\tv352 = v658 >> 0x15;\n\tv366 = v658 << 0xB;\n\tv659 = v352 | v366;\n\tv422 = v659 * 0x9E3779B1;\n\tv358 = v419 != 1;\n\tif (v358) goto L_01F6;\nL_020A:\n\tv375 = v422 ^ v422;\n\tv376 = v375 * 0x85EBCA77;\n\tv383 = v376 ^ v376;\n\tv384 = v383 * 0xC2B2AE3D;\n\treturnVal2 = v384 ^ v384;\n\treturn returnVal2;\n\tv161 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 432 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static uint CalculateHash(byte[] buf, int len, uint seed)
		{
			//IL_005c: Expected I4, but got I8
			//IL_0617: Expected I4, but got I8
			//IL_0636: Expected I4, but got I8
			//IL_0529: Expected O, but got I
			//IL_0538: Expected O, but got I
			//IL_0561: Expected O, but got I
			//IL_0578: Unknown result type (might be due to invalid IL or missing references)
			//IL_057d: Expected O, but got Unknown
			//IL_058b: Expected O, but got I
			//IL_05c8: Expected I4, but got I8
			//IL_04a5: Expected I4, but got I8
			//IL_029a: Expected I4, but got I8
			//IL_02e2: Expected I4, but got I8
			int num = len - 16;
			int num2;
			int num3;
			if (len < 16)
			{
				num2 = (int)(seed + 374761393);
				num3 = 0;
			}
			else
			{
				int num4 = (int)((int)seed + 2246822519L);
				int num5 = 7;
				int num24;
				do
				{
					int num6 = num5 - 7;
					int num7 = num6 + 1;
					int num8 = num7 + 1;
					int num9 = num8 + 1;
					int num10 = num9 + 1;
					int num11 = num10 + 1;
					int num12 = num11 + 1;
					int num13 = num12 + 1;
					int num14 = num13 + 1;
					int num15 = num14 + 1;
					int num16 = num15 + 1;
					int num17 = num16 + 1;
					int num18 = num17 + 1;
					int num19 = num18 + 1;
					int num20 = num19 + 1;
					int num21 = num20 + 1;
					int num22 = num5 - 3;
					int num23 = num5 - 2;
					num24 = num21 + 1;
					int num25 = num5 - 1;
					int num26 = buf[num23] & 0xFF;
					int num27 = num26 << 8;
					int num28 = buf[num22] & -65281;
					int num29 = num28 | num27;
					int num30 = buf[num25] & 0xFF;
					int num31 = num30 << 16;
					int num32 = num29 & -16711681;
					int num33 = num32 | num31;
					int num34 = buf[num5] & 0xFF;
					int num35 = num34 << 24;
					int num36 = num33 & 0xFFFFFF;
					int num37 = num36 | num35;
					int num38 = (int)(num37 * 2246822519L);
					int num39 = num4 + num38;
					int num40 = num39 >> 19;
					int num41 = num39 << 13;
					int num42 = num40 | num41;
					num4 = (int)(num42 * 2654435761L);
					num5 += 16;
				}
				while (num24 <= num);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407CB0]");
				int num43 = (int)((nint)0 | (nint)num4);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				num3 = num5 - 7;
				num2 = num43;
			}
			int num44 = len - 4;
			int num45 = num2 + len;
			if (num3 <= num44)
			{
				do
				{
					int num46 = num3 + 1;
					int num47 = num46 + 1;
					int num48 = num47 + 1;
					int num49 = num3 + 2;
					int num50 = num3 + 3;
					int num51 = buf[num46] & 0xFF;
					int num52 = num51 << 8;
					int num53 = buf[num3] & -65281;
					int num54 = num53 | num52;
					num3 = num48 + 1;
					int num55 = buf[num49] & 0xFF;
					int num56 = num55 << 16;
					int num57 = num54 & -16711681;
					int num58 = num57 | num56;
					int num59 = buf[num50] & 0xFF;
					int num60 = num59 << 24;
					int num61 = num58 & 0xFFFFFF;
					int num62 = num61 | num60;
					int num63 = (int)(num62 * 3266489917L);
					int num64 = num45 + num63;
					int num65 = num64 >> 15;
					int num66 = num64 << 17;
					int num67 = num65 | num66;
					num45 = num67 * 668265263;
				}
				while (num3 <= num44);
				num3 += 4;
			}
			if (num3 < len)
			{
				object obj = (nint)buf + num3;
				object obj2 = (nint)obj + 32;
				int num68 = len - num3;
				int num69 = num45;
				bool flag;
				do
				{
					obj2 = (nint)obj2 + 1;
					int num70 = num68 - 1;
					object obj3 = obj2 * 374761393;
					object obj4 = num69 + (nint)obj3;
					int num71 = (int)((nint)obj4 >> 21);
					int num72 = (int)((nint)obj4 << 11);
					int num73 = num71 | num72;
					num45 = (int)(num73 * 2654435761L);
					flag = num68 != 1;
					num68 = num70;
					num69 = num45;
				}
				while (flag);
			}
			int num74 = num45 ^ num45;
			int num75 = (int)(num74 * 2246822519L);
			int num76 = num75 ^ num75;
			int num77 = (int)(num76 * 3266489917L);
			return (uint)(num77 ^ num77);
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0xBD58FC", Offset = "0xBD58FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public xxHash()
		{
		}
	}
}
