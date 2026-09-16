using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000054")]
	public class SkeletonBinary
	{
		[Token(Token = "0x2000055")]
		internal class Vertices
		{
			[Token(Token = "0x4000222")]
			[FieldOffset(Offset = "0x10")]
			public int[] bones;

			[Token(Token = "0x4000223")]
			[FieldOffset(Offset = "0x18")]
			public float[] vertices;

			[Token(Token = "0x6000370")]
			[Address(RVA = "0x153CF6C", Offset = "0x153CF6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Vertices()
			{
			}
		}

		[Token(Token = "0x2000056")]
		internal class SkeletonInput
		{
			[Token(Token = "0x4000224")]
			[FieldOffset(Offset = "0x10")]
			private byte[] chars;

			[Token(Token = "0x4000225")]
			[FieldOffset(Offset = "0x18")]
			private byte[] bytesBigEndian;

			[Token(Token = "0x4000226")]
			[FieldOffset(Offset = "0x20")]
			internal ExposedList<string> strings;

			[Token(Token = "0x4000227")]
			[FieldOffset(Offset = "0x28")]
			private Stream input;

			[Token(Token = "0x6000371")]
			[Address(RVA = "0x153CF74", Offset = "0x153CF74", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = System.Byte[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, input, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B8C]) = v40;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Byte[]), typeof(System.Byte[]), 32\n\tthis.chars = v43;\n\t// 27 NewArr v46 @ X0_v5 (System.Byte[]), typeof(System.Byte[]), 4\n\tthis.bytesBigEndian = v46;\n\tSystem.Object::.ctor(this);\n\tthis.input = input;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SkeletonInput(Stream input)
			{
				byte[] array = new byte[32];
				chars = array;
				byte[] array2 = new byte[4];
				bytesBigEndian = array2;
				this.input = input;
			}

			[Token(Token = "0x6000372")]
			[Address(RVA = "0x153CFF0", Offset = "0x153CFF0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.IO.Stream::ReadByte(this.input);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public byte ReadByte()
			{
				return (byte)input.ReadByte();
			}

			[Token(Token = "0x6000373")]
			[Address(RVA = "0x153D018", Offset = "0x153D018", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.IO.Stream::ReadByte(this.input);\n\tv25 = returnVal1 + 1;\n\tv27 = v25 == 0;\n\tif (v27) goto L_0018;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0018:\n\tv66 = new System.IO.EndOfStreamException();\n\tSystem.IO.EndOfStreamException::.ctor(v66);\n\tthrow v66;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public sbyte ReadSByte()
			{
				sbyte b = (sbyte)input.ReadByte();
				if (b + 1 != 0)
				{
					return b;
				}
				EndOfStreamException ex = new EndOfStreamException();
				throw ex;
			}

			[Token(Token = "0x6000374")]
			[Address(RVA = "0x153D07C", Offset = "0x153D07C", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = System.IO.Stream::ReadByte(this.input);\n\tv27 = v8 == 0;\n\tv32 = ~v27;\n\treturn v32;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public bool ReadBoolean()
			{
				int num = input.ReadByte();
				bool flag = num == 0;
				return !flag;
			}

			[Token(Token = "0x6000375")]
			[Address(RVA = "0x153D0AC", Offset = "0x153D0AC", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.IO.Stream::Read(this.input, this.bytesBigEndian, 0, 4);\n\tv26 = this.bytesBigEndian;\n\tv109 = this.chars;\n\tv109[3] = v26[0];\n\tv121 = this.bytesBigEndian;\n\tv110 = this.chars;\n\tv110[2] = v121[1];\n\tv122 = this.bytesBigEndian;\n\tv111 = this.chars;\n\tv111[1] = v122[2];\n\tv123 = this.bytesBigEndian;\n\tv112 = this.chars;\n\tv112[0] = v123[3];\n\treturnVal2 = System.BitConverter::ToSingle(this.chars, 0);\n\treturn returnVal2;\n\tv133 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn returnVal1;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public float ReadFloat()
			{
				int num = input.Read(bytesBigEndian, 0, 4);
				byte[] array = bytesBigEndian;
				byte[] array2 = chars;
				array2[3] = array[0];
				byte[] array3 = bytesBigEndian;
				byte[] array4 = chars;
				array4[2] = array3[1];
				byte[] array5 = bytesBigEndian;
				byte[] array6 = chars;
				array6[1] = array5[2];
				byte[] array7 = bytesBigEndian;
				byte[] array8 = chars;
				array8[0] = array7[3];
				return BitConverter.ToSingle(chars, 0);
			}

			[Token(Token = "0x6000376")]
			[Address(RVA = "0x153D1AC", Offset = "0x153D1AC", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = System.IO.Stream::Read(this.input, this.bytesBigEndian, 0, 4);\n\tv26 = this.bytesBigEndian;\n\tv134 = v26[0] << 0x18;\n\tv135 = v26[1] & 0xFF;\n\tv136 = v135 << 0x10;\n\tv137 = v134 & 0xFFFFFFFFFF00FFFF;\n\tv138 = v137 | v136;\n\tv139 = v26[2] & 0xFF;\n\tv125 = v139 << 8;\n\tv140 = v138 & 0xFFFFFFFFFFFF00FF;\n\tv118 = v140 | v125;\n\treturnVal2 = v118 | v26[3];\n\treturn returnVal2;\n\tv71 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public int ReadInt()
			{
				int num = input.Read(bytesBigEndian, 0, 4);
				byte[] array = bytesBigEndian;
				int num2 = array[0] << 24;
				int num3 = array[1] & 0xFF;
				int num4 = num3 << 16;
				int num5 = num2 & -16711681;
				int num6 = num5 | num4;
				int num7 = array[2] & 0xFF;
				int num8 = num7 << 8;
				int num9 = num6 & -65281;
				int num10 = num9 | num8;
				return num10 | array[3];
			}

			[Token(Token = "0x6000377")]
			[Address(RVA = "0x153D230", Offset = "0x153D230", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.IO.Stream::ReadByte(this.input);\n\tv65 = v17 & 0x7F;\n\tv33 = v17 & 0x80;\n\tv34 = v33 == 0;\n\tif (v34) goto L_0047;\n\tv80 = System.IO.Stream::ReadByte(this.input);\n\tv95 = v80 & 0x7F;\n\tv96 = v95 << 7;\n\tv97 = v65 & 0xFFFFFFFFFFFFC07F;\n\tv65 = v97 | v96;\n\tv98 = v80 & 0x80;\n\tv75 = v98 == 0;\n\tif (v75) goto L_0047;\n\tv81 = System.IO.Stream::ReadByte(this.input);\n\tv125 = v81 & 0x7F;\n\tv126 = v125 << 0xE;\n\tv127 = v65 & 0xFFFFFFFFFFE03FFF;\n\tv65 = v127 | v126;\n\tv128 = v81 & 0x80;\n\tv76 = v128 == 0;\n\tif (v76) goto L_0047;\n\tv82 = System.IO.Stream::ReadByte(this.input);\n\tv129 = v82 & 0x7F;\n\tv130 = v129 << 0x15;\n\tv131 = v65 & 0xFFFFFFFFF01FFFFF;\n\tv65 = v131 | v130;\n\tv132 = v82 & 0x80;\n\tv77 = v132 == 0;\n\tif (v77) goto L_0047;\n\tv79 = System.IO.Stream::ReadByte(this.input);\n\tv133 = v79 & 0xF;\n\tv74 = v133 << 0x1C;\n\tv134 = v65 & 0xFFFFFFF;\n\tv65 = v134 | v74;\nL_0047:\n\tv83 = v65 & 1;\n\tv86 = optimizePositive == 0;\n\tv91 = 0 - v83;\n\tv92 = v91 ^ v65;\n\tv93 = ~v86;\n\tv94 = ~v93;\n\tif (v94) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public int ReadInt(bool optimizePositive)
			{
				int num = input.ReadByte();
				int num2 = num & 0x7F;
				if ((num & 0x80) != 0)
				{
					int num3 = input.ReadByte();
					int num4 = num3 & 0x7F;
					int num5 = num4 << 7;
					int num6 = num2 & -16257;
					num2 = num6 | num5;
					if ((num3 & 0x80) != 0)
					{
						int num7 = input.ReadByte();
						int num8 = num7 & 0x7F;
						int num9 = num8 << 14;
						int num10 = num2 & -2080769;
						num2 = num10 | num9;
						if ((num7 & 0x80) != 0)
						{
							int num11 = input.ReadByte();
							int num12 = num11 & 0x7F;
							int num13 = num12 << 21;
							int num14 = num2 & -266338305;
							num2 = num14 | num13;
							if ((num11 & 0x80) != 0)
							{
								int num15 = input.ReadByte();
								int num16 = num15 & 0xF;
								int num17 = num16 << 28;
								int num18 = num2 & 0xFFFFFFF;
								num2 = num18 | num17;
							}
						}
					}
				}
				int num19 = num2 & 1;
				bool flag = !optimizePositive;
				int num20 = -num19;
				int result = num20 ^ num2;
				if (!flag)
				{
					return num2;
				}
				return result;
			}

			[Token(Token = "0x6000378")]
			[Address(RVA = "0x153D300", Offset = "0x153D300", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = System.Byte[];\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv41 = \"\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A37B8D]) = v36;\nL_0016:\n\tv39 = Spine.SkeletonBinary+SkeletonInput::ReadInt(this, 1);\n\tv42 = v39 == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv52 = v39 - 1;\n\tv53 = v39 != 1;\n\tif (v53) goto L_0030;\n\tgoto L_002F;\nL_002F:\n\treturn returnVal1;\nL_0030:\n\tv105 = this.chars;\n\tv97 = v52 <= v105.Length;\n\tif (v97) goto L_004B;\n\t// 69 NewArr v157 @ X0_v13 (System.Byte[]), typeof(System.Byte[]), v52 @ X20_v4 (System.Int32)\nL_004B:\n\tSpine.SkeletonBinary+SkeletonInput::ReadFully(this, v105, 0, v52);\n\tv116 = System.Text.Encoding::get_UTF8();\n\tv150 = *([v116 @ X0_v11 (System.Text.Encoding)]);\n\tv129 = *([v150 @ X8_v7 (Il2CppClass<System.Text.Encoding>)+378]);\n\tv127 = *([v150 @ X8_v7 (Il2CppClass<System.Text.Encoding>)+380]);\n\t// 91 IndirectJump v129 @ X5_v1, v116 @ X0_v11 (System.Text.Encoding), v116 @ X0_v11 (System.Text.Encoding), v105 @ X21_v4 (System.Byte[]), 0, v52 @ X20_v4 (System.Int32), v127 @ X4_v1, v129 @ X5_v1, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public string ReadString()
			{
				//IL_009d: Expected I, but got O
				//IL_00ad: Expected O, but got I
				//IL_00bd: Expected O, but got I
				while (true)
				{
					int num = ReadInt(optimizePositive: true);
					if (num == 0)
					{
						break;
					}
					int num2 = num - 1;
					if (num == 1)
					{
						return "";
					}
					byte[] array = chars;
					if (num2 > array.Length)
					{
						byte[] array2 = new byte[num2];
						array = array2;
					}
					ReadFully(array, 0, num2);
					Encoding uTF = Encoding.UTF8;
					nint num3 = (nint)uTF;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v7 (Il2CppClass<System.Text.Encoding>)+378]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v7 (Il2CppClass<System.Text.Encoding>)+380]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X5_v1 (should have been resolved before IL gen)");
				}
				return null;
			}

			[Token(Token = "0x6000379")]
			[Address(RVA = "0x153D48C", Offset = "0x153D48C", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = Spine.SkeletonBinary+SkeletonInput::ReadInt(this, 1);\n\tv9 = v7 == 0;\n\tif (v9) goto L_FFFFFFFF;\n\tv10 = this.strings;\n\tv13 = v10.Items;\n\tv60 = v7 - 1;\n\tgoto L_0022;\nL_0022:\n\treturn returnVal1;\n\tv17 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public string ReadStringRef()
			{
				int num = ReadInt(optimizePositive: true);
				if (num != 0)
				{
					ExposedList<string> exposedList = strings;
					string[] items = exposedList.Items;
					int num2 = num - 1;
					return items[num2];
				}
				return null;
			}

			[Token(Token = "0x600037A")]
			[Address(RVA = "0x153D3E4", Offset = "0x153D3E4", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = length < 1;\n\tif (v21) goto L_0042;\nL_001F:\n\tv36 = System.IO.Stream::Read(this.input, buffer, v90, v91);\n\tv164 = v36 <= 0;\n\tif (v164) goto L_0047;\n\tv91 = v91 - v36;\n\tv90 = v36 + v90;\n\tv59 = v91 > 0;\n\tif (v59) goto L_001F;\nL_0042:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0047:\n\tv173 = new System.IO.EndOfStreamException();\n\tSystem.IO.EndOfStreamException::.ctor(v173);\n\tthrow v173;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void ReadFully(byte[] buffer, int offset, int length)
			{
				if (length < 1)
				{
					return;
				}
				int num = offset;
				int num2 = length;
				while (true)
				{
					int num3 = input.Read(buffer, num, num2);
					if (num3 <= 0)
					{
						break;
					}
					num2 -= num3;
					num = num3 + num;
					if (num2 <= 0)
					{
						return;
					}
				}
				EndOfStreamException ex = new EndOfStreamException();
				throw ex;
			}

			[Token(Token = "0x600037B")]
			[Address(RVA = "0x153D4E0", Offset = "0x153D4E0", Length = "0x278")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv16 = System.Byte[];\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A37B8E]) = v35;\nL_0013:\n\tv38 = Spine.SkeletonBinary+SkeletonInput::ReadInt(this, 1);\n\tv50 = v38 < 2;\n\tif (v50) goto L_0032;\n\tv51 = this.input;\n\tv52 = this.input == 0;\n\tif (v52) goto L_0075;\n\tv73 = System.IO.Stream::get_Position(this.input);\n\tv74 = *([v51 @ X21_v6 (System.IO.Stream)]);\n\tv244 = *([v74 @ X8_v17 (Il2CppClass<System.IO.Stream>)+200]);\n\tv65 = v38 - 1;\n\tv56 = v73 + v65;\n\tv62 = System.IO.Stream::set_Position(this.input, v56);\nL_0032:\n\tv68 = Spine.SkeletonBinary+SkeletonInput::ReadInt(this, 1);\n\tv86 = v68 < 2;\n\tif (v86) goto L_0060;\n\tv118 = v68 - 1;\n\t// 69 NewArr v122 @ X0_v26 (System.Byte[]), typeof(System.Byte[]), v118 @ X20_v5 (System.Int32)\n\tSpine.SkeletonBinary+SkeletonInput::ReadFully(this, v122, 0, v118);\n\tv166 = System.Text.Encoding::get_UTF8();\n\treturnVal2 = System.Text.Encoding::GetString(v166, v122, 0, v118);\n\treturn returnVal2;\nL_0060:\n\tv142 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v142, \"Stream does not contain a valid binary Skeleton Data.\", \"input\");\n\tthrow v142;\n\tv104 = new System.NullReferenceException();\nL_0075:\n\tv113 = new System.NullReferenceException();\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\n\tgoto L_008A;\nL_008A:\n\tv136 = 1 != 1;\n\tif (v136) goto L_00CB;\n\tv144 = 0x1854E70(v113, 1, v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv181 = *([v144 @ X0_v38 (System.String)]);\n\tv183 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v181 @ X8_v11 (Il2CppClass<System.String>)]), v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv202 = v183 & 1;\n\tv203 = v202 == 0;\n\tif (v203) goto L_00A4;\n\tv250 = *([v144 @ X0_v38 (System.String)]);\n\tv229 = 0x1854E80(v183, *([v181 @ X8_v11 (Il2CppClass<System.String>)]), v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv242 = *([v144 @ X0_v38 (System.String)]) == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_00AB;\n\tgoto L_00B3;\nL_00A4:\n\tv231 = 0x1854E90(8, *([v181 @ X8_v11 (Il2CppClass<System.String>)]), v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\t*([v231 @ X0_v64]) = *([v144 @ X0_v38 (System.String)]);\n\tv238 = 0x185A000 + 0xF88;\n\tv240 = 0x1854EA0(v231, v238, 0, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_00AB:\n\tv251 = v250.m_value;\n\t*([v251 @ X8_v14 (System.Int32)+168])(v255, v250, *([v251 @ X8_v14 (System.Int32)+170]), v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_00B3:\n\tv265 = System.String::Concat(v261, v259);\n\tv270 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v270, v265, \"input\");\n\tthrow v270;\n\tv154 = 0x1854E80(v280, Il2CppMethodInfo, \"input\", 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_00CB:\n\tv164 = 0xBD3CD0(v113, 1, v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\treturnVal1 = 0x9DACB4(v164, 1, v244, v145, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\treturn returnVal1;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe string GetVersionString()
			{
				//IL_004d: Expected I, but got O
				//IL_005d: Expected O, but got I
				//IL_015a: Expected I, but got O
				//IL_019d: Expected I4, but got O
				int num = ReadInt(optimizePositive: true);
				string text2;
				string text3;
				if (num >= 2)
				{
					Stream stream = input;
					bool flag = input == null;
					int num2 = num;
					string text4;
					if (flag)
					{
						NullReferenceException ex = new NullReferenceException();
						if (1 == 1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
							string text = default(string);
							nint num3 = (nint)text;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj = default(object);
							if ((int)((nint)obj & 1) != 0)
							{
								num2 = (int)text;
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
								bool flag2 = text == null;
								bool flag3 = !flag2;
								text2 = "Stream does not contain a valid binary Skeleton Data.\n";
								if (!flag3)
								{
									text3 = null;
									text2 = "Stream does not contain a valid binary Skeleton Data.\n";
									goto IL_02ea;
								}
							}
							else
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
								object obj2 = text;
								int num4 = 25534464 + 3976;
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
								text4 = null;
								text2 = text;
							}
							int value = ((int*)num2)->m_value;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v251 @ X8_v14 (System.Int32)+168] (should have been resolved before IL gen)");
							string text5 = default(string);
							text3 = text5;
							goto IL_02ea;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
						string result = default(string);
						return result;
					}
					long position = input.Position;
					nint num5 = (nint)stream;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v17 (Il2CppClass<System.IO.Stream>)+200]");
					text4 = (string)0;
					int num6 = num - 1;
					long position2 = position + num6;
					input.Position = position2;
				}
				int num7 = ReadInt(optimizePositive: true);
				if (num7 >= 2)
				{
					int num8 = num7 - 1;
					byte[] array = new byte[num8];
					ReadFully(array, 0, num8);
					Encoding uTF = Encoding.UTF8;
					return uTF.GetString(array, 0, num8);
				}
				ArgumentException ex2 = new ArgumentException("Stream does not contain a valid binary Skeleton Data.", "input");
				throw ex2;
				IL_02ea:
				string message = text2 + text3;
				ArgumentException ex3 = new ArgumentException(message, "input");
				throw ex3;
			}
		}

		[Token(Token = "0x4000211")]
		public const int BONE_ROTATE = 0;

		[Token(Token = "0x4000212")]
		public const int BONE_TRANSLATE = 1;

		[Token(Token = "0x4000213")]
		public const int BONE_SCALE = 2;

		[Token(Token = "0x4000214")]
		public const int BONE_SHEAR = 3;

		[Token(Token = "0x4000215")]
		public const int SLOT_ATTACHMENT = 0;

		[Token(Token = "0x4000216")]
		public const int SLOT_COLOR = 1;

		[Token(Token = "0x4000217")]
		public const int SLOT_TWO_COLOR = 2;

		[Token(Token = "0x4000218")]
		public const int PATH_POSITION = 0;

		[Token(Token = "0x4000219")]
		public const int PATH_SPACING = 1;

		[Token(Token = "0x400021A")]
		public const int PATH_MIX = 2;

		[Token(Token = "0x400021B")]
		public const int CURVE_LINEAR = 0;

		[Token(Token = "0x400021C")]
		public const int CURVE_STEPPED = 1;

		[Token(Token = "0x400021D")]
		public const int CURVE_BEZIER = 2;

		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x18")]
		private AttachmentLoader attachmentLoader;

		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x20")]
		private List<SkeletonJson.LinkedMesh> linkedMeshes;

		[Token(Token = "0x4000221")]
		public static readonly TransformMode[] TransformModeValues = new TransformMode[5]
		{
			TransformMode.Normal,
			TransformMode.OnlyTranslation,
			TransformMode.NoRotationOrReflection,
			TransformMode.NoScale,
			TransformMode.NoScaleOrReflection
		};

		[Token(Token = "0x17000112")]
		public float Scale
		{
			[CompilerGenerated]
			[Token(Token = "0x6000361")]
			[Address(RVA = "0x153891C", Offset = "0x153891C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Scale>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Scale;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000362")]
			[Address(RVA = "0x1538924", Offset = "0x1538924", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Scale>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Scale = value;
			}
		}

		[Token(Token = "0x6000363")]
		[Address(RVA = "0x153892C", Offset = "0x153892C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Spine.AtlasAttachmentLoader;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, atlasArray, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37B80]) = v40;\nL_0016:\n\tv42 = new Spine.AtlasAttachmentLoader();\n\tSpine.AtlasAttachmentLoader::.ctor(v42, atlasArray);\n\tSpine.SkeletonBinary::.ctor(this, v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonBinary(params Atlas[] atlasArray)
			: this(new AtlasAttachmentLoader(atlasArray))
		{
		}

		[Token(Token = "0x6000364")]
		[Address(RVA = "0x1538998", Offset = "0x1538998", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, attachmentLoader, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = System.Collections.Generic.List`1<Spine.SkeletonJson+LinkedMesh>;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, attachmentLoader, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37B81]) = v45;\nL_001C:\n\tv47 = new System.Collections.Generic.List`1<Spine.SkeletonJson+LinkedMesh>();\n\tSystem.Collections.Generic.List`1<Spine.SkeletonJson+LinkedMesh>::.ctor(v47);\n\tthis.linkedMeshes = v47;\n\tSystem.Object::.ctor(this);\n\tv54 = attachmentLoader == 0;\n\tif (v54) goto L_0034;\n\tthis.attachmentLoader = attachmentLoader;\n\tthis.<Scale>k__BackingField = 1f;\n\treturn;\nL_0034:\n\tv79 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v79, \"attachmentLoader\");\n\tthrow v79;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonBinary(AttachmentLoader attachmentLoader)
		{
			List<SkeletonJson.LinkedMesh> list = new List<SkeletonJson.LinkedMesh>();
			linkedMeshes = list;
			if (attachmentLoader != null)
			{
				this.attachmentLoader = attachmentLoader;
				Scale = 1f;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("attachmentLoader");
			throw ex;
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0x1538A74", Offset = "0x1538A74", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = System.IO.FileStream;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, path, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = System.IDisposable;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, path, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = System.IO.Path;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, path, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37B82]) = v41;\nL_001E:\n\tv45 = new System.IO.FileStream();\n\tSystem.IO.FileStream::.ctor(v45, path, 3, 1, 1);\n\tv59 = Spine.SkeletonBinary::ReadSkeletonData(this, v45);\n\tgoto L_0034;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v63, v58, v49, v50, v51, v53, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv71 = System.IO.Path::GetFileNameWithoutExtension(path);\n\tv72 = v59 == 0;\n\tif (v72) goto L_0073;\n\tv59.name = v71;\n\tv74 = v45 == 0;\n\tif (v74) goto L_0066;\nL_003F:\n\tgoto L_0065;\n\tv186 = *([v162 @ X8_v14+B0]);\n\tv187 = v186 + 8;\n\tv189 = *([v234 @ X10_v15-8]);\n\tv240 = v189 == v163;\n\tif (v240) goto L_005E;\n\tv211 = v235 - 1;\n\tv209 = v234 + 0x10;\n\tv191 = v235 != 1;\n\tif (v191) goto L_FFFFFFFF;\n\tv212 = v54;\n\tv213 = 0;\n\tv214 = 0xB349B4(v212, v163, v213, v50, v51, v53, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0065;\nL_005E:\n\tv290 = *([v234 @ X10_v15]);\n\tv291 = v290 << 4;\n\tv292 = v162 + v291;\n\tv293 = v292 + 0x138;\nL_0065:\n\tSystem.IDisposable::Dispose(v45);\nL_0066:\n\tv185 = v125 == 0;\n\tv121 = ~v185;\n\tif (v121) goto L_0072;\n\treturn v123;\nL_0072:\n\tv119 = new System.OutOfMemoryException();\nL_0073:\n\tv128 = new System.NullReferenceException();\n\tgoto L_0080;\n\tgoto L_0080;\nL_0080:\n\tv132 = v273 != 1;\n\tif (v132) goto L_008C;\n\tv288 = 0x1854E70(v128, v273, v275, 1, 1, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv159 = *([v288 @ X0_v30]);\n\tv154 = 0x1854E80(v288, v273, v275, 1, 1, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv298 = v45 == 0;\n\tv156 = ~v298;\n\tif (v156) goto L_003F;\n\tgoto L_0066;\nL_008C:\n\tgoto L_008E;\n\tX21 = X0;\nL_008E:\n\tv297 = v45 == 0;\n\tif (v297) goto L_00BD;\n\tgoto L_00BA;\n\tv323 = *([v299 @ X8_v9+B0]);\n\tv324 = v323 + 8;\n\tv326 = *([v367 @ X10_v8-8]);\n\tv373 = v326 == v300;\n\tif (v373) goto L_00B3;\n\tv348 = v368 - 1;\n\tv346 = v367 + 0x10;\n\tv328 = v368 != 1;\n\tif (v328) goto L_FFFFFFFF;\n\tv349 = v54;\n\tv350 = 0;\n\tv351 = 0xB349B4(v349, v300, v350, v50, v51, v53, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00BA;\nL_00B3:\n\tv379 = *([v367 @ X10_v8]);\n\tv380 = v379 << 4;\n\tv381 = v299 + v380;\n\tv382 = v381 + 0x138;\nL_00BA:\n\tSystem.IDisposable::Dispose(v45);\nL_00BD:\n\tgoto L_00C1;\n\tv353 = 0xBD3CD0(v128, v273, v275, 1, 1, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00C1:\n\tv356 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v356, v273, v275, 1, 1, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonData ReadSkeletonData(string path)
		{
			//IL_0101: Expected I4, but got O
			//IL_014f: Expected I4, but got O
			FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
			SkeletonData skeletonData = ReadSkeletonData(fileStream);
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
			bool flag = skeletonData == null;
			int num = 0;
			FileMode fileMode = FileMode.Open;
			if (flag)
			{
				goto IL_00bc;
			}
			skeletonData.Name = fileNameWithoutExtension;
			bool flag2 = fileStream == null;
			SkeletonData skeletonData2 = skeletonData;
			int num2 = 0;
			num = 0;
			fileMode = FileMode.Open;
			SkeletonData result = skeletonData;
			int num3 = 0;
			if (flag2)
			{
				goto IL_01c4;
			}
			goto IL_01ec;
			IL_00bc:
			NullReferenceException ex = new NullReferenceException();
			if (num == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				object obj = default(object);
				num2 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				bool flag3 = fileStream == null;
				bool flag4 = !flag3;
				skeletonData2 = null;
				if (flag4)
				{
					goto IL_01ec;
				}
				result = null;
				num3 = (int)obj;
				goto IL_01c4;
			}
			if (fileStream != null)
			{
				((IDisposable)fileStream).Dispose();
				num = 0;
				fileMode = default(FileMode);
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			SkeletonData result2 = default(SkeletonData);
			return result2;
			IL_01ec:
			((IDisposable)fileStream).Dispose();
			num = 0;
			fileMode = default(FileMode);
			result = skeletonData2;
			num3 = num2;
			goto IL_01c4;
			IL_01c4:
			if (num3 == 0)
			{
				return result;
			}
			OutOfMemoryException ex3 = new OutOfMemoryException();
			goto IL_00bc;
		}

		[Token(Token = "0x6000366")]
		[Address(RVA = "0x153A1F4", Offset = "0x153A1F4", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = Spine.SkeletonBinary+SkeletonInput;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B83]) = v33;\nL_0010:\n\tv34 = file == 0;\n\tif (v34) goto L_0027;\n\tv38 = new Spine.SkeletonBinary+SkeletonInput();\n\tSpine.SkeletonBinary+SkeletonInput::.ctor(v38, file);\n\treturnVal1 = Spine.SkeletonBinary+SkeletonInput::GetVersionString(v38);\n\treturn returnVal1;\nL_0027:\n\tv45 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v45, \"file\");\n\tthrow v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetVersionString(Stream file)
		{
			if (file != null)
			{
				SkeletonInput skeletonInput = new SkeletonInput(file);
				return skeletonInput.GetVersionString();
			}
			ArgumentNullException ex = new ArgumentNullException("file");
			throw ex;
		}

		[Token(Token = "0x6000367")]
		[Address(RVA = "0x1538C64", Offset = "0x1538C64", Length = "0x1590")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0084;\n\tv42 = Spine.BoneData;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv64 = System.Enum;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv175 = Spine.EventData;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv181 = Il2CppMethodInfo;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv190 = Il2CppMethodInfo;\n\tv191 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv198 = Il2CppMethodInfo;\n\tv199 = \"il2cpp_codegen_initialize_runtime_metadata\"(v198, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv202 = Il2CppMethodInfo;\n\tv203 = \"il2cpp_codegen_initialize_runtime_metadata\"(v202, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1287 = Il2CppMethodInfo;\n\tv1288 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1287, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1318 = Il2CppMethodInfo;\n\tv1319 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1318, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1327 = Il2CppMethodInfo;\n\tv1328 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1327, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1407 = Il2CppMethodInfo;\n\tv1408 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1407, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1413 = Il2CppMethodInfo;\n\tv1414 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1413, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1416 = Il2CppMethodInfo;\n\tv1417 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1416, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1434 = Il2CppMethodInfo;\n\tv1435 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1434, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1463 = Spine.ExposedList`1<System.String>;\n\tv1464 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1463, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1478 = Spine.IkConstraintData;\n\tv1479 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1478, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1493 = Il2CppMethodInfo;\n\tv1494 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1493, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1501 = Il2CppMethodInfo;\n\tv1502 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1501, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1522 = Il2CppMethodInfo;\n\tv1523 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1522, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1550 = Spine.MeshAttachment;\n\tv1551 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1550, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1567 = Spine.PathConstraintData;\n\tv1568 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1567, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1576 = Spine.PositionMode;\n\tv1577 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1576, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1595 = Spine.PositionMode;\n\tv1596 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1595, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1604 = Spine.RotateMode;\n\tv1605 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1604, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1630 = Spine.RotateMode;\n\tv1631 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1630, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1819 = Spine.SkeletonBinary;\n\tv1820 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1819, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1891 = Spine.SkeletonData;\n\tv1892 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1891, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1897 = Spine.SkeletonBinary+SkeletonInput;\n\tv1898 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1897, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv1988 = Spine.SlotData;\n\tv1989 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1988, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv2061 = Spine.SpacingMode;\n\tv2062 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2061, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv2110 = Spine.SpacingMode;\n\tv2111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2110, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv2124 = Spine.TransformConstraintData;\n\tv2125 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2124, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv2131 = System.Type;\n\tv2132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2131, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv2151 = Spine.VertexAttachment;\n\tv2152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2151, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv2175 = \"3.8.75\";\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2175, file, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A37B84]) = v61;\nL_0084:\n\tv62 = file == 0;\n\tif (v62) goto L_07DC;\n\tv72 = new Spine.SkeletonData();\n\tSpine.SkeletonData::.ctor(v72);\n\tv184 = new Spine.SkeletonBinary+SkeletonInput();\n\tSpine.SkeletonBinary+SkeletonInput::.ctor(v184, file);\n\tv206 = Spine.SkeletonBinary+SkeletonInput::ReadString(v184);\n\tv72.hash = v206;\n\tv1329 = v206._stringLength == 0;\n\tv1330 = ~v1329;\n\tif (v1330) goto L_00A7;\n\tv72.hash = 0;\nL_00A7:\n\tv963 = Spine.SkeletonBinary+SkeletonInput::ReadString(v184);\n\tv72.version = v963;\n\tv1420 = v963._stringLength == 0;\n\tv1421 = ~v1420;\n\tif (v1421) goto L_00B6;\n\tv72.version = 0;\nL_00B6:\n\tv1440 = System.String::op_Equality(\"3.8.75\", v1437);\n\tv1466 = v1440 == 0;\n\tv1276 = ~v1466;\n\tif (v1276) goto L_07E9;\n\tv1484 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(v184);\n\tv72.x = v1484;\n\tv1497 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(v184);\n\tv72.y = v1497;\n\tv1505 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(v184);\n\tv72.width = v1505;\n\tv814 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(v184);\n\tv72.height = v814;\n\tv1554 = Spine.SkeletonBinary+SkeletonInput::ReadBoolean(v184);\n\tv1570 = v1554 == 0;\n\tif (v1570) goto L_00F1;\n\tv814 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(v184);\n\tv72.fps = v814;\n\tv1599 = Spine.SkeletonBinary+SkeletonInput::ReadString(v184);\n\tv72.imagesPath = v1599;\n\tv1607 = System.String::IsNullOrEmpty(v1599);\n\tv1633 = v1607 == 0;\n\tif (v1633) goto L_00E6;\n\tv72.imagesPath = 0;\nL_00E6:\n\tv1823 = Spine.SkeletonBinary+SkeletonInput::ReadString(v184);\n\tv72.audioPath = v1823;\n\tv1584 = System.String::IsNullOrEmpty(v1823);\n\tv1586 = v1584 == 0;\n\tif (v1586) goto L_00F1;\n\tv72.audioPath = 0;\nL_00F1:\n\tv1590 = Spine.SkeletonBinary+SkeletonInput::ReadInt(v184, 1);\n\tv964 = new Spine.ExposedList`1<System.String>();\n\tSpine.ExposedList`1<System.String>::.ctor(v964, v1590);\n\tv184.strings = v964;\n\tv965 = Spine.ExposedList`1<System.String>::Resize(v964, v1590);\n\tv1910 = v1590 < 1;\n\tif (v1910) goto L_013F;\n\tv1120 = v965.Items;\nL_0117:\n\tv966 = Spine.SkeletonBinary+SkeletonInput::ReadString(v184\n// ... truncated")]
		public SkeletonData ReadSkeletonData(Stream file)
		{
			//IL_1f0e: Expected O, but got I4
			//IL_06b9: Expected I4, but got I8
			//IL_04b9: Expected O, but got I
			//IL_0804: Expected O, but got I4
			//IL_0791: Expected I4, but got I8
			//IL_17c3: Expected O, but got I
			//IL_17d2: Expected O, but got I
			//IL_223c: Expected I, but got O
			//IL_1af6: Expected O, but got I
			//IL_0a68: Expected O, but got I4
			//IL_183d: Expected O, but got I
			//IL_0b50: Expected I, but got O
			//IL_1b43: Expected I4, but got O
			//IL_0f79: Expected I, but got O
			//IL_1413: Expected I4, but got O
			//IL_1e00: Expected O, but got I
			//IL_1455: Expected I4, but got O
			//IL_14af: Expected I4, but got O
			//IL_14f1: Expected I4, but got O
			//IL_1abc: Expected I, but got O
			//IL_154b: Expected I4, but got O
			//IL_158d: Expected I4, but got O
			SkeletonData skeletonData;
			SkeletonInput skeletonInput;
			bool flag3;
			string text8 = default(string);
			if (file != null)
			{
				skeletonData = new SkeletonData();
				skeletonInput = new SkeletonInput(file);
				string text = (skeletonData.Hash = skeletonInput.ReadString());
				if (text.Length == 0)
				{
					skeletonData.Hash = null;
				}
				string text3 = (skeletonData.Version = skeletonInput.ReadString());
				bool flag = text3.Length == 0;
				bool flag2 = !flag;
				string text5 = text3;
				if (!flag2)
				{
					skeletonData.Version = null;
					text5 = null;
				}
				if (!("3.8.75" == text5))
				{
					float x = skeletonInput.ReadFloat();
					skeletonData.X = x;
					float y = skeletonInput.ReadFloat();
					skeletonData.Y = y;
					float width = skeletonInput.ReadFloat();
					skeletonData.Width = width;
					float height = skeletonInput.ReadFloat();
					skeletonData.Height = height;
					flag3 = skeletonInput.ReadBoolean();
					if (flag3)
					{
						height = skeletonInput.ReadFloat();
						skeletonData.Fps = height;
						string value = (skeletonData.ImagesPath = skeletonInput.ReadString());
						if (string.IsNullOrEmpty(value))
						{
							skeletonData.ImagesPath = null;
						}
						string value2 = (skeletonData.AudioPath = skeletonInput.ReadString());
						if (string.IsNullOrEmpty(value2))
						{
							skeletonData.AudioPath = null;
						}
					}
					int num = skeletonInput.ReadInt(optimizePositive: true);
					ExposedList<string> exposedList = (skeletonInput.strings = new ExposedList<string>((IEnumerable<string>)num)).Resize(num);
					if (num < 1)
					{
						goto IL_02d2;
					}
					string[] items = exposedList.Items;
					int num2 = 0;
					while (true)
					{
						text8 = skeletonInput.ReadString();
						if (text8 != null)
						{
							object obj = text8 as string;
							if (obj == null)
							{
								break;
							}
						}
						items[num2] = text8;
						num2++;
						if (num != num2)
						{
							continue;
						}
						goto IL_02d2;
					}
					goto IL_1de2;
				}
				Exception ex = new Exception("Unsupported skeleton data, please export with a newer version of Spine.");
			}
			else
			{
				ArgumentNullException ex2 = new ArgumentNullException("file");
			}
			ArgumentNullException ex3 = default(ArgumentNullException);
			throw ex3;
			IL_1ad2:
			NullReferenceException ex4 = new NullReferenceException();
			goto IL_1ae0;
			IL_1ae0:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ X0_v45 (System.NullReferenceException)+1C]");
			object obj2 = (nint)0 + (nint)1;
			((Exception)ex4)._message = null;
			if ((nint)((Exception)ex4)._message >= 1)
			{
				Array.Clear((Array)(object)((Exception)ex4)._className, 0, (int)((Exception)ex4)._message);
			}
			int num3 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<EventData> exposedList2 = skeletonData.Events.Resize(num3);
			if (num3 < 1)
			{
				goto IL_1cee;
			}
			EventData[] items2 = exposedList2.Items;
			int num4 = 0;
			while (true)
			{
				string name = skeletonInput.ReadStringRef();
				EventData eventData = new EventData(name);
				int num5 = skeletonInput.ReadInt(optimizePositive: false);
				eventData.Int = num5;
				float num6 = skeletonInput.ReadFloat();
				eventData.Float = num6;
				string text9 = skeletonInput.ReadString();
				eventData.String = text9;
				string text10 = (eventData.AudioPath = skeletonInput.ReadString());
				if (text10 != null)
				{
					float volume = skeletonInput.ReadFloat();
					eventData.Volume = volume;
					float balance = skeletonInput.ReadFloat();
					eventData.Balance = balance;
				}
				object obj3 = eventData as EventData;
				if (obj3 == null)
				{
					break;
				}
				items2[num4] = eventData;
				num4++;
				if (num3 != num4)
				{
					continue;
				}
				goto IL_1cee;
			}
			goto IL_1de2;
			IL_16b2:
			Skin skin = ReadSkin(skeletonInput, skeletonData, defaultSkin: true, flag3);
			if (skin != null)
			{
				skeletonData.DefaultSkin = skin;
				skeletonData.Skins.Add(skin);
			}
			ExposedList<Skin> skins = skeletonData.Skins;
			int num7 = skeletonInput.ReadInt(optimizePositive: true);
			int num8 = num7 + skins.Count;
			ExposedList<Skin> exposedList3 = skins.Resize(num8);
			bool flag4 = skins.Count >= num8;
			bool flag5 = flag3;
			if (flag4)
			{
				goto IL_187b;
			}
			int num9 = num8 - skins.Count;
			int num10 = skins.Count << 3;
			object obj4 = (nint)exposedList3.Items + num10;
			object obj5 = (nint)obj4 + 32;
			PathConstraintData pathConstraintData = default(PathConstraintData);
			while (true)
			{
				Skin skin2 = ReadSkin(skeletonInput, skeletonData, defaultSkin: false, flag3);
				if (skin2 != null)
				{
					object obj6 = skin2 as Skin;
					bool flag6 = obj6 == null;
					string text12 = (string)(object)pathConstraintData;
					if (flag6)
					{
						break;
					}
				}
				obj5 = skin2;
				obj5 = (nint)obj5 + 8;
				int num11 = num9 - 1;
				bool flag7 = num9 != 1;
				flag5 = flag3;
				num9 = num11;
				if (flag7)
				{
					continue;
				}
				goto IL_187b;
			}
			goto IL_1de2;
			IL_02d2:
			int num12 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<BoneData> exposedList4 = skeletonData.Bones.Resize(num12);
			if (num12 < 1)
			{
				goto IL_058f;
			}
			BoneData[] items3 = exposedList4.Items;
			int num13 = 0;
			while (true)
			{
				string name2 = skeletonInput.ReadString();
				BoneData boneData;
				if (num13 != 0)
				{
					ExposedList<BoneData> bones = skeletonData.Bones;
					BoneData[] items4 = bones.Items;
					int num14 = skeletonInput.ReadInt(optimizePositive: true);
					boneData = items4[num14];
				}
				else
				{
					boneData = null;
				}
				BoneData boneData2 = new BoneData(num13, name2, boneData);
				float rotation = skeletonInput.ReadFloat();
				boneData2.Rotation = rotation;
				float num15 = skeletonInput.ReadFloat();
				float x2 = Scale * num15;
				boneData2.X = x2;
				float num16 = skeletonInput.ReadFloat();
				float y2 = Scale * num16;
				boneData2.Y = y2;
				float scaleX = skeletonInput.ReadFloat();
				boneData2.ScaleX = scaleX;
				float scaleY = skeletonInput.ReadFloat();
				boneData2.ScaleY = scaleY;
				float shearX = skeletonInput.ReadFloat();
				boneData2.ShearX = shearX;
				float shearY = skeletonInput.ReadFloat();
				boneData2.ShearY = shearY;
				float num17 = skeletonInput.ReadFloat();
				float height = Scale * num17;
				boneData2.Length = height;
				int num18 = skeletonInput.ReadInt(optimizePositive: true);
				int num19 = num18 << 2;
				object obj7 = (nint)TransformModeValues + num19;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2402 @ X8_v171+20]");
				boneData2.TransformMode = TransformMode.Normal;
				bool skinRequired = skeletonInput.ReadBoolean();
				boneData2.skinRequired = skinRequired;
				if (flag3)
				{
					int num20 = skeletonInput.ReadInt();
				}
				object obj8 = boneData2 as BoneData;
				bool flag8 = obj8 == null;
				string text12 = text8;
				if (flag8)
				{
					break;
				}
				items3[num13] = boneData2;
				num13++;
				bool flag9 = num12 != num13;
				BoneData boneData3 = boneData;
				if (flag9)
				{
					continue;
				}
				goto IL_058f;
			}
			goto IL_1de2;
			IL_187b:
			List<SkeletonJson.LinkedMesh> list = linkedMeshes;
			int num21 = ~list.Count;
			int num22 = list.Count & num21;
			Skin skin3 = null;
			int num23 = 0;
			SkeletonBinary skeletonBinary = default(SkeletonBinary);
			nint num24;
			while (true)
			{
				bool flag10 = num22 == num23;
				skeletonBinary = this;
				ex4 = (NullReferenceException)(object)list;
				num24 = (nint)typeof(EventData);
				if (flag10)
				{
					break;
				}
				SkeletonJson.LinkedMesh linkedMesh = list[num23];
				Skin skin5;
				if (linkedMesh.skin != null)
				{
					Skin skin4 = skeletonData.FindSkin(linkedMesh.skin);
					skin5 = skin4;
				}
				else
				{
					skin5 = skeletonData.DefaultSkin;
				}
				Skin skin6 = ((skin5 != null) ? skin5 : skin3);
				bool flag11 = skin5 == null;
				string text12 = (string)(object)linkedMesh;
				string text13;
				string text14;
				if (!flag11)
				{
					Attachment attachment = skin6.GetAttachment(linkedMesh.slotIndex, linkedMesh.parent);
					if (attachment != null)
					{
						MeshAttachment mesh = linkedMesh.mesh;
						bool flag12 = !linkedMesh.inheritDeform;
						MeshAttachment deformAttachment = linkedMesh.mesh;
						if (!flag12)
						{
							text12 = (string)(object)linkedMesh;
							VertexAttachment vertexAttachment = attachment as VertexAttachment;
							bool flag13 = vertexAttachment == null;
							text12 = (string)(object)linkedMesh;
							if (flag13)
							{
								goto IL_20ce;
							}
							deformAttachment = (MeshAttachment)attachment;
						}
						mesh.DeformAttachment = deformAttachment;
						text12 = (string)(object)linkedMesh;
						MeshAttachment meshAttachment = attachment as MeshAttachment;
						bool flag14 = meshAttachment == null;
						text12 = (string)(object)linkedMesh;
						if (!flag14)
						{
							linkedMesh.mesh.ParentMesh = (MeshAttachment)attachment;
							linkedMesh.mesh.UpdateUVs();
							num23++;
							list = linkedMeshes;
							bool flag15 = linkedMeshes == null;
							bool flag16 = !flag15;
							skeletonBinary = this;
							num24 = (nint)typeof(EventData);
							skin3 = skin5;
							if (flag16)
							{
								continue;
							}
							goto IL_1ad2;
						}
						goto IL_20ce;
					}
					text13 = linkedMesh.parent;
					text14 = "Parent mesh not found: ";
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2093 @ X23_v5 (System.String)+18]");
					text13 = (string)0;
					text14 = "Skin not found: ";
				}
				string message = text14 + text13;
				Exception ex5 = new Exception(message);
				throw ex5;
			}
			goto IL_1ae0;
			IL_1de2:
			ArrayTypeMismatchException ex6 = new ArrayTypeMismatchException();
			throw ex6;
			IL_0ca5:
			int num25 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<TransformConstraintData> exposedList5 = skeletonData.TransformConstraints.Resize(num25);
			if (num25 < 1)
			{
				goto IL_1189;
			}
			TransformConstraintData[] items5 = exposedList5.Items;
			int num26 = 0;
			TransformConstraintData transformConstraintData = default(TransformConstraintData);
			IkConstraintData ikConstraintData = default(IkConstraintData);
			while (true)
			{
				string name3 = skeletonInput.ReadString();
				transformConstraintData = new TransformConstraintData(name3);
				int order = skeletonInput.ReadInt(optimizePositive: true);
				transformConstraintData.Order = order;
				bool skinRequired2 = skeletonInput.ReadBoolean();
				transformConstraintData.skinRequired = skinRequired2;
				int num27 = skeletonInput.ReadInt(optimizePositive: true);
				ExposedList<BoneData> exposedList6 = transformConstraintData.Bones.Resize(num27);
				ExposedList<BoneData> bones2 = skeletonData.Bones;
				BoneData[] items6 = exposedList6.Items;
				bool flag17 = num27 < 0;
				bool flag18 = num27 == 0;
				int num28 = num27 ^ num27;
				int num29 = num27 & num28;
				bool flag19 = num29 < 0;
				bool flag20 = flag17 == flag19;
				bool flag21 = !flag18;
				bool flag22 = flag20 && flag21;
				bool flag23 = flag22;
				int num30 = 0;
				BoneData[] items7;
				int num31;
				string text12;
				while (true)
				{
					items7 = bones2.Items;
					num31 = skeletonInput.ReadInt(optimizePositive: true);
					if (!flag23)
					{
						break;
					}
					if (items7[num31] != null)
					{
						object obj9 = items7[num31] as BoneData;
						bool flag24 = obj9 == null;
						text12 = (string)(object)ikConstraintData;
						if (flag24)
						{
							goto end_IL_209c;
						}
					}
					items6[num30] = items7[num31];
					bones2 = skeletonData.Bones;
					num30++;
					int num32 = num30 - num27;
					bool flag25 = num32 < 0;
					int num33 = num30 ^ num27;
					int num34 = num30 ^ num32;
					int num35 = num33 & num34;
					bool flag26 = num35 < 0;
					bool flag27 = flag25 == flag26;
					bool flag28 = !flag27;
					bool flag29 = skeletonData.Bones == null;
					bool flag30 = !flag29;
					flag23 = flag28;
					if (flag30)
					{
						continue;
					}
					goto IL_0f74;
				}
				transformConstraintData.Target = items7[num31];
				bool local = skeletonInput.ReadBoolean();
				transformConstraintData.local = local;
				bool relative = skeletonInput.ReadBoolean();
				transformConstraintData.relative = relative;
				float offsetRotation = skeletonInput.ReadFloat();
				transformConstraintData.OffsetRotation = offsetRotation;
				float num36 = skeletonInput.ReadFloat();
				float offsetX = Scale * num36;
				transformConstraintData.OffsetX = offsetX;
				float num37 = skeletonInput.ReadFloat();
				float offsetY = Scale * num37;
				transformConstraintData.OffsetY = offsetY;
				float offsetScaleX = skeletonInput.ReadFloat();
				transformConstraintData.OffsetScaleX = offsetScaleX;
				float offsetScaleY = skeletonInput.ReadFloat();
				transformConstraintData.OffsetScaleY = offsetScaleY;
				float offsetShearY = skeletonInput.ReadFloat();
				transformConstraintData.OffsetShearY = offsetShearY;
				float rotateMix = skeletonInput.ReadFloat();
				transformConstraintData.RotateMix = rotateMix;
				float translateMix = skeletonInput.ReadFloat();
				transformConstraintData.TranslateMix = translateMix;
				float scaleMix = skeletonInput.ReadFloat();
				transformConstraintData.ScaleMix = scaleMix;
				float height = skeletonInput.ReadFloat();
				transformConstraintData.ShearMix = height;
				object obj10 = transformConstraintData as TransformConstraintData;
				bool flag31 = obj10 == null;
				text12 = (string)(object)transformConstraintData;
				if (flag31)
				{
					break;
				}
				int num38 = num26 + 1;
				items5[num26] = transformConstraintData;
				bool flag32 = num38 != num25;
				num26 = num38;
				if (flag32)
				{
					continue;
				}
				goto IL_1189;
				continue;
				end_IL_209c:
				break;
			}
			goto IL_1de2;
			IL_1cee:
			int num39 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<Animation> exposedList7 = skeletonData.Animations.Resize(num39);
			if (num39 < 1)
			{
				goto IL_1ddd;
			}
			Animation[] items8 = exposedList7.Items;
			int num40 = 0;
			while (true)
			{
				string name4 = skeletonInput.ReadString();
				Animation animation = skeletonBinary.ReadAnimation(name4, skeletonInput, skeletonData);
				if (animation != null)
				{
					object obj11 = animation as Animation;
					if (obj11 == null)
					{
						break;
					}
				}
				items8[num40] = animation;
				num40++;
				if (num39 != num40)
				{
					continue;
				}
				goto IL_1ddd;
			}
			goto IL_1de2;
			IL_20ce:
			throw new InvalidCastException();
			IL_0f74:
			num24 = (nint)this;
			goto IL_1ad2;
			IL_058f:
			int num41 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<SlotData> exposedList8 = skeletonData.Slots.Resize(num41);
			bool flag33 = num41 < 1;
			bool flag34 = flag5;
			if (flag33)
			{
				goto IL_087b;
			}
			SlotData[] items9 = exposedList8.Items;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			int num43 = default(int);
			int num42 = num43;
			int num44 = 0;
			object obj12 = default(object);
			while (true)
			{
				string name5 = skeletonInput.ReadString();
				ExposedList<BoneData> bones3 = skeletonData.Bones;
				BoneData[] items10 = bones3.Items;
				int num45 = skeletonInput.ReadInt(optimizePositive: true);
				SlotData slotData = new SlotData(num44, name5, items10[num45]);
				int num46 = skeletonInput.ReadInt();
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
				int num47 = num46 >> 24;
				int num48 = num46 & 0xFF;
				int num49 = (int)(num42 & 0xFF000000FFL);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
				int num50 = num47 / 1132396544;
				int num51 = num48 / 1132396544;
				num43 = (int)(num49 / (nint)obj12);
				slotData.R = num50;
				slotData.G = num43;
				slotData.A = num51;
				int num52 = skeletonInput.ReadInt();
				if (num52 + 1 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction USHL not yet implemented.\"");
					slotData.hasSecondColor = true;
					int num53 = num52 & 0xFF;
					int num54 = (int)(num51 & 0xFF000000FFL);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
					num43 = num53 / 1132396544;
					num51 = (int)(num54 / (nint)obj12);
					slotData.R2 = num51;
					slotData.B2 = num43;
					num50 = num53;
				}
				string attachmentName = skeletonInput.ReadStringRef();
				slotData.AttachmentName = attachmentName;
				int blendMode = skeletonInput.ReadInt(optimizePositive: true);
				slotData.BlendMode = (BlendMode)blendMode;
				object obj13 = slotData as SlotData;
				bool flag35 = obj13 == null;
				string text12 = (string)num13;
				if (flag35)
				{
					break;
				}
				items9[num44] = slotData;
				num44++;
				bool flag36 = num41 != num44;
				flag34 = false;
				BoneData boneData3 = items10[num45];
				float height = num51;
				num42 = num43;
				if (flag36)
				{
					continue;
				}
				goto IL_087b;
			}
			goto IL_1de2;
			IL_0b4b:
			num24 = (nint)this;
			goto IL_1ad2;
			IL_087b:
			int num55 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<IkConstraintData> exposedList9 = skeletonData.IkConstraints.Resize(num55);
			if (num55 < 1)
			{
				goto IL_0ca5;
			}
			IkConstraintData[] items11 = exposedList9.Items;
			int num56 = 0;
			while (true)
			{
				string name6 = skeletonInput.ReadString();
				ikConstraintData = new IkConstraintData(name6);
				int order2 = skeletonInput.ReadInt(optimizePositive: true);
				ikConstraintData.Order = order2;
				bool skinRequired3 = skeletonInput.ReadBoolean();
				ikConstraintData.skinRequired = skinRequired3;
				int num57 = skeletonInput.ReadInt(optimizePositive: true);
				ExposedList<BoneData> exposedList10 = ikConstraintData.Bones.Resize(num57);
				ExposedList<BoneData> bones4 = skeletonData.Bones;
				BoneData[] items12 = exposedList10.Items;
				bool flag37 = num57 < 0;
				bool flag38 = num57 == 0;
				int num58 = num57 ^ num57;
				int num59 = num57 & num58;
				bool flag39 = num59 < 0;
				bool flag40 = flag37 == flag39;
				bool flag41 = !flag38;
				bool flag42 = flag40 && flag41;
				bool flag43 = flag42;
				int num60 = 0;
				BoneData[] items13;
				int num61;
				string text12;
				while (true)
				{
					items13 = bones4.Items;
					num61 = skeletonInput.ReadInt(optimizePositive: true);
					if (!flag43)
					{
						break;
					}
					if (items13[num61] != null)
					{
						object obj14 = items13[num61] as BoneData;
						bool flag44 = obj14 == null;
						text12 = (string)num44;
						if (flag44)
						{
							goto end_IL_2058;
						}
					}
					items12[num60] = items13[num61];
					bones4 = skeletonData.Bones;
					num60++;
					int num62 = num60 - num57;
					bool flag45 = num62 < 0;
					int num63 = num60 ^ num57;
					int num64 = num60 ^ num62;
					int num65 = num63 & num64;
					bool flag46 = num65 < 0;
					bool flag47 = flag45 == flag46;
					bool flag48 = !flag47;
					bool flag49 = skeletonData.Bones == null;
					bool flag50 = !flag49;
					flag43 = flag48;
					if (flag50)
					{
						continue;
					}
					goto IL_0b4b;
				}
				ikConstraintData.Target = items13[num61];
				float mix = skeletonInput.ReadFloat();
				ikConstraintData.Mix = mix;
				float num66 = skeletonInput.ReadFloat();
				float height = Scale * num66;
				ikConstraintData.Softness = height;
				sbyte bendDirection = skeletonInput.ReadSByte();
				ikConstraintData.BendDirection = bendDirection;
				bool compress = skeletonInput.ReadBoolean();
				ikConstraintData.compress = compress;
				bool stretch = skeletonInput.ReadBoolean();
				ikConstraintData.stretch = stretch;
				bool uniform = skeletonInput.ReadBoolean();
				ikConstraintData.uniform = uniform;
				object obj15 = ikConstraintData as IkConstraintData;
				bool flag51 = obj15 == null;
				text12 = (string)(object)ikConstraintData;
				if (flag51)
				{
					break;
				}
				int num67 = num56 + 1;
				items11[num56] = ikConstraintData;
				bool flag52 = num67 != num55;
				num56 = num67;
				if (flag52)
				{
					continue;
				}
				goto IL_0ca5;
				continue;
				end_IL_2058:
				break;
			}
			goto IL_1de2;
			IL_1ddd:
			return skeletonData;
			IL_1189:
			int num68 = skeletonInput.ReadInt(optimizePositive: true);
			ExposedList<PathConstraintData> exposedList11 = skeletonData.PathConstraints.Resize(num68);
			if (num68 < 1)
			{
				goto IL_16b2;
			}
			PathConstraintData[] items14 = exposedList11.Items;
			int num69 = 0;
			object obj17 = default(object);
			object obj18 = default(object);
			object obj19 = default(object);
			while (true)
			{
				string name7 = skeletonInput.ReadString();
				pathConstraintData = new PathConstraintData(name7);
				int order3 = skeletonInput.ReadInt(optimizePositive: true);
				pathConstraintData.Order = order3;
				bool skinRequired4 = skeletonInput.ReadBoolean();
				pathConstraintData.skinRequired = skinRequired4;
				int num70 = skeletonInput.ReadInt(optimizePositive: true);
				ExposedList<BoneData> exposedList12 = pathConstraintData.Bones.Resize(num70);
				string text12;
				if (num70 >= 1)
				{
					BoneData[] items15 = exposedList12.Items;
					int num71 = 0;
					while (true)
					{
						ExposedList<BoneData> bones5 = skeletonData.Bones;
						BoneData[] items16 = bones5.Items;
						int num72 = skeletonInput.ReadInt(optimizePositive: true);
						if (items16[num72] != null)
						{
							object obj16 = items16[num72] as BoneData;
							bool flag53 = obj16 == null;
							text12 = (string)(object)transformConstraintData;
							if (flag53)
							{
								break;
							}
						}
						items15[num71] = items16[num72];
						num71++;
						if (num70 != num71)
						{
							continue;
						}
						goto IL_1368;
					}
					break;
				}
				goto IL_1368;
				IL_1368:
				ExposedList<SlotData> slots = skeletonData.Slots;
				SlotData[] items17 = slots.Items;
				int num73 = skeletonInput.ReadInt(optimizePositive: true);
				pathConstraintData.Target = items17[num73];
				Type typeFromHandle = typeof(PositionMode);
				Array values = Enum.GetValues(typeFromHandle);
				int index = skeletonInput.ReadInt(optimizePositive: true);
				object value3 = values.GetValue(index);
				PositionMode positionMode = (PositionMode)((value3 is PositionMode) ? value3 : null);
				bool flag54 = positionMode == PositionMode.Fixed;
				text12 = (string)(object)pathConstraintData;
				if (!flag54)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					pathConstraintData.PositionMode = (PositionMode)obj17;
					Type typeFromHandle2 = typeof(SpacingMode);
					Array values2 = Enum.GetValues(typeFromHandle2);
					int index2 = skeletonInput.ReadInt(optimizePositive: true);
					object value4 = values2.GetValue(index2);
					SpacingMode spacingMode = (SpacingMode)((value4 is SpacingMode) ? value4 : null);
					bool flag55 = spacingMode == SpacingMode.Length;
					text12 = (string)(object)pathConstraintData;
					if (!flag55)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						pathConstraintData.SpacingMode = (SpacingMode)obj18;
						Type typeFromHandle3 = typeof(RotateMode);
						Array values3 = Enum.GetValues(typeFromHandle3);
						int index3 = skeletonInput.ReadInt(optimizePositive: true);
						object value5 = values3.GetValue(index3);
						RotateMode rotateMode = (RotateMode)((value5 is RotateMode) ? value5 : null);
						bool flag56 = rotateMode == RotateMode.Tangent;
						text12 = (string)(object)pathConstraintData;
						if (!flag56)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							pathConstraintData.RotateMode = (RotateMode)obj19;
							float offsetRotation2 = skeletonInput.ReadFloat();
							pathConstraintData.OffsetRotation = offsetRotation2;
							float num74 = (pathConstraintData.Position = skeletonInput.ReadFloat());
							if (pathConstraintData.PositionMode == PositionMode.Fixed)
							{
								float position = Scale * num74;
								pathConstraintData.Position = position;
							}
							float num76 = (pathConstraintData.Spacing = skeletonInput.ReadFloat());
							bool flag57 = pathConstraintData.SpacingMode < SpacingMode.Fixed;
							bool flag58 = !flag57;
							int num78 = (int)(pathConstraintData.SpacingMode - 1);
							bool flag59 = num78 == 0;
							bool flag60 = !flag59;
							if (!(flag58 && flag60))
							{
								float spacing = Scale * num76;
								pathConstraintData.Spacing = spacing;
							}
							float rotateMix2 = skeletonInput.ReadFloat();
							pathConstraintData.RotateMix = rotateMix2;
							float height = skeletonInput.ReadFloat();
							pathConstraintData.TranslateMix = height;
							object obj20 = pathConstraintData as PathConstraintData;
							bool flag61 = obj20 == null;
							text12 = (string)(object)pathConstraintData;
							if (flag61)
							{
								break;
							}
							int num79 = num69 + 1;
							items14[num69] = pathConstraintData;
							bool flag62 = num79 != num68;
							num69 = num79;
							if (flag62)
							{
								continue;
							}
							goto IL_16b2;
						}
					}
				}
				goto IL_20ce;
			}
			goto IL_1de2;
		}

		[Token(Token = "0x6000368")]
		[Address(RVA = "0x153A2A8", Offset = "0x153A2A8", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, input, skeletonData, defaultSkin, nonessential, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, input, skeletonData, defaultSkin, nonessential, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv369 = Il2CppMethodInfo;\n\tv370 = \"il2cpp_codegen_initialize_runtime_metadata\"(v369, input, skeletonData, defaultSkin, nonessential, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv420 = Spine.Skin;\n\tv421 = \"il2cpp_codegen_initialize_runtime_metadata\"(v420, input, skeletonData, defaultSkin, nonessential, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv458 = \"default\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v458, input, skeletonData, defaultSkin, nonessential, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37B85]) = v54;\nL_002B:\n\tv60 = defaultSkin == 0;\n\tif (v60) goto L_0041;\n\tv374 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv422 = v374 == 0;\n\tif (v422) goto L_FFFFFFFF;\n\tv463 = new Spine.Skin();\n\tSpine.Skin::.ctor(v463, \"default\");\n\tgoto L_0180;\nL_0041:\n\tv377 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(input);\n\tv293 = new Spine.Skin();\n\tSpine.Skin::.ctor(v293, v377);\n\tv294 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv295 = Spine.ExposedList`1<Spine.BoneData>::Resize(v293.bones, v294);\n\tv340 = v293.bones;\n\tv109 = v340.Count < 1;\n\tif (v109) goto L_00AF;\n\tv95 = v295.Items;\nL_0072:\n\tv341 = skeletonData.bones;\n\tv358 = v341.Items;\n\tv297 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv806 = v358[v297 @ X0_v60 (System.Int32)] == 0;\n\tif (v806) goto L_009F;\n\t// 145 IsInst v448 @ X0_v63, typeof(Spine.BoneData), v358[v297 @ X0_v60 (System.Int32)]\n\tv450 = v448 == 0;\n\tif (v450) goto L_01DA;\nL_009F:\n\tv95[v85 @ X26_v23 (System.Int32)] = v358[v297 @ X0_v60 (System.Int32)];\n\tv85 = v85 + 1;\n\tv667 = v340.Count != v85;\n\tif (v667) goto L_0072;\nL_00AF:\n\tv298 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv111 = v298 < 1;\n\tif (v111) goto L_00EE;\nL_00C1:\n\tv344 = skeletonData.ikConstraints;\n\tv98 = v344.Items;\n\tv300 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tSpine.ExposedList`1<Spine.ConstraintData>::Add(v293.constraints, v98[v300 @ X0_v56 (System.Int32)]);\n\tv734 = v360 - 1;\n\tv709 = v360 != 1;\n\tif (v709) goto L_00C1;\nL_00EE:\n\tv301 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv113 = v301 < 1;\n\tif (v113) goto L_012D;\nL_0100:\n\tv347 = skeletonData.transformConstraints;\n\tv101 = v347.Items;\n\tv303 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tSpine.ExposedList`1<Spine.ConstraintData>::Add(v293.constraints, v101[v303 @ X0_v52 (System.Int32)]);\n\tv778 = v362 - 1;\n\tv752 = v362 != 1;\n\tif (v752) goto L_0100;\nL_012D:\n\tv304 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv365 = v293.constraints;\n\tv115 = v304 < 1;\n\tif (v115) goto L_0170;\nL_0140:\n\tv350 = skeletonData.pathConstraints;\n\tv104 = v350.Items;\n\tv306 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tSpine.ExposedList`1<Spine.ConstraintData>::Add(v364, v104[v306 @ X0_v48 (System.Int32)]);\n\tv365 = v293.constraints;\n\tv798 = v255 - 1;\n\tv789 = v255 != 1;\n\tif (v789) goto L_0140;\nL_0170:\n\tSpine.ExposedList`1<Spine.ConstraintData>::TrimExcess(v365);\n\tv589 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\nL_0180:\n\tv492 = v366 < 1;\n\tif (v492) goto L_01D7;\nL_0187:\n\tv620 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv624 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv635 = v624 < 1;\n\tif (v635) goto L_01BC;\nL_019C:\n\tv700 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(input);\n\tv308 = Spine.SkeletonBinary::ReadAttachment(this, input, skeletonData, v531, v620, v700, nonessential);\n\tv736 = v308 == 0;\n\tif (v736) goto L_01B9;\n\tSpine.Skin::SetAttachment(v531, v620, v700, v308);\nL_01B9:\n\tv641 = v93 - 1;\n\tv643 = v93 != 1;\n\tif (v643) goto L_019C;\nL_01BC:\n\tv83 = v83 + 1;\n\tv491 = v83 != v366;\n\tif (v491) goto L_0187;\n\tgoto L_01D7;\nL_01D7:\n\treturn v531;\n\tv367 = new System.NullReferenceException();\n\tv418 = new System.IndexOutOfRangeException();\nL_01DA:\n\tv456 = new System.ArrayTypeMismatchException();\n\tthrow v456;\n\treturn returnVal2;\n// 378 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Skin ReadSkin(SkeletonInput input, SkeletonData skeletonData, bool defaultSkin, bool nonessential)
		{
			Skin skin;
			int num2;
			if (defaultSkin)
			{
				int num = input.ReadInt(optimizePositive: true);
				if (num == 0)
				{
					skin = null;
					goto IL_0607;
				}
				Skin skin2 = new Skin("default");
				skin = skin2;
				num2 = num;
			}
			else
			{
				string name = input.ReadStringRef();
				Skin skin3 = new Skin(name);
				int newSize = input.ReadInt(optimizePositive: true);
				ExposedList<BoneData> exposedList = skin3.Bones.Resize(newSize);
				ExposedList<BoneData> bones = skin3.Bones;
				if (bones.Count >= 1)
				{
					BoneData[] items = exposedList.Items;
					int num3 = 0;
					do
					{
						ExposedList<BoneData> bones2 = skeletonData.Bones;
						BoneData[] items2 = bones2.Items;
						int num4 = input.ReadInt(optimizePositive: true);
						if (items2[num4] != null)
						{
							object obj = items2[num4] as BoneData;
							if (obj == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
						items[num3] = items2[num4];
						num3++;
					}
					while (bones.Count != num3);
				}
				int num5 = input.ReadInt(optimizePositive: true);
				if (num5 >= 1)
				{
					int num6 = num5;
					bool flag;
					do
					{
						ExposedList<IkConstraintData> ikConstraints = skeletonData.IkConstraints;
						IkConstraintData[] items3 = ikConstraints.Items;
						int num7 = input.ReadInt(optimizePositive: true);
						skin3.Constraints.Add(items3[num7]);
						int num8 = num6 - 1;
						flag = num6 != 1;
						num6 = num8;
					}
					while (flag);
				}
				int num9 = input.ReadInt(optimizePositive: true);
				if (num9 >= 1)
				{
					int num10 = num9;
					bool flag2;
					do
					{
						ExposedList<TransformConstraintData> transformConstraints = skeletonData.TransformConstraints;
						TransformConstraintData[] items4 = transformConstraints.Items;
						int num11 = input.ReadInt(optimizePositive: true);
						skin3.Constraints.Add(items4[num11]);
						int num12 = num10 - 1;
						flag2 = num10 != 1;
						num10 = num12;
					}
					while (flag2);
				}
				int num13 = input.ReadInt(optimizePositive: true);
				ExposedList<ConstraintData> constraints = skin3.Constraints;
				if (num13 >= 1)
				{
					int num14 = num13;
					ExposedList<ConstraintData> constraints2 = skin3.Constraints;
					bool flag3;
					do
					{
						ExposedList<PathConstraintData> pathConstraints = skeletonData.PathConstraints;
						PathConstraintData[] items5 = pathConstraints.Items;
						int num15 = input.ReadInt(optimizePositive: true);
						constraints2.Add(items5[num15]);
						constraints = skin3.Constraints;
						int num16 = num14 - 1;
						flag3 = num14 != 1;
						num14 = num16;
						constraints2 = skin3.Constraints;
					}
					while (flag3);
				}
				constraints.TrimExcess();
				int num17 = input.ReadInt(optimizePositive: true);
				skin = skin3;
				num2 = num17;
			}
			if (num2 >= 1)
			{
				int num18 = 0;
				do
				{
					int slotIndex = input.ReadInt(optimizePositive: true);
					int num19 = input.ReadInt(optimizePositive: true);
					if (num19 >= 1)
					{
						int num20 = num19;
						bool flag4;
						do
						{
							string text = input.ReadStringRef();
							Attachment attachment = ReadAttachment(input, skeletonData, skin, slotIndex, text, nonessential);
							if (attachment != null)
							{
								skin.SetAttachment(slotIndex, text, attachment);
							}
							int num21 = num20 - 1;
							flag4 = num20 != 1;
							num20 = num21;
						}
						while (flag4);
					}
					num18++;
				}
				while (num18 != num2);
			}
			goto IL_0607;
			IL_0607:
			return skin;
		}

		[Token(Token = "0x6000369")]
		[Address(RVA = "0x153BE98", Offset = "0x153BE98", Length = "0xADC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv60 = Spine.AttachmentLoader;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, input, skeletonData, skin, slotIndex, attachmentName, nonessential, methodInfo, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv77 = Spine.SkeletonJson+LinkedMesh;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, input, skeletonData, skin, slotIndex, attachmentName, nonessential, methodInfo, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, input, skeletonData, skin, slotIndex, attachmentName, nonessential, methodInfo, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv98 = System.Single[];\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, input, skeletonData, skin, slotIndex, attachmentName, nonessential, methodInfo, v63, v64, v65, v66, v67, v68, v69, v70);\n\tv74 = 1;\n\t*([1A37B86]) = v74;\nL_0035:\n\tv82 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(input);\n\tv96 = v82 != 0;\n\tif (v96) goto L_0047;\n\tgoto L_0047;\nL_0047:\n\tv169 = Spine.SkeletonBinary+SkeletonInput::ReadByte(input);\n\tv188 = v169 & 0xFF;\n\tv192 = v188 < 6;\n\tv162 = ~v192;\n\tv159 = v188 - 6;\n\tv153 = v159 == 0;\n\tv193 = ~v153;\n\tv136 = v162 & v193;\n\tif (v136) goto L_00B9;\n\tv187 = v169 & 0xFF;\n\tv133 = 0x44C000 + 0xD2E;\n\tv124 = *([v133 @ X9_v2 (System.Int32)+v187 @ X8_v4 (System.Int32)*2]) << 2;\n\tv130 = 0x153FF74 + v124;\n\t// 92 IndirectJump v130 @ X10_v2 (System.Int32), v169 @ X0_v6 (System.Byte), v169 @ X0_v6 (System.Byte), 0, skeletonData @ X2 (Spine.SkeletonData), skin @ X3 (Spine.Skin), slotIndex @ X4 (System.Int32), attachmentName @ X5 (System.String), nonessential @ X6 (System.Boolean), methodInfo @ X7 (Il2CppMethodInfo), v63 @ V0, v64 @ V1, v65 @ V2, v66 @ V3, v67 @ V4, v68 @ V5, v69 @ V6, v70 @ V7\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(X0, X1);\n\tX24 = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV8 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV10 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV11 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV12 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV9 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV13 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV14 = V0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1);\n\tX23 = *([X22+18]);\n\tC = X24 < 0;\n\tC = ~C;\n\tTEMP1 = X24 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X24 ^ 0;\n\tTEMP3 = X24 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_008E;\n\tX22 = X20;\n\tgoto L_008F;\nL_008E:\n\tX22 = X24;\nL_008F:\n\t;\n\tif (TEMP) goto L_03FC;\n\tX8 = *([X23]);\n\tX10 = *([1946F58]);\n\tX21 = X0;\n\tX9 = *([X8+12E]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_00B4;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_009C:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_02A3;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_009C;\nL_00B4:\n\tX0 = X23;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_02A7;\nL_00B9:\n\tgoto L_03F3;\n\tX1 = 1;\n\tX0 = X23;\n\tX2 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1, X2);\n\tX24 = X0;\n\tX0 = X22;\n\tX1 = X23;\n\tX2 = X24;\n\tX0 = Spine.SkeletonBinary::ReadVertices(X0, X1, X2, X3);\n\tX25 = X0;\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_00CA;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1);\nL_00CA:\n\tX21 = *([X22+18]);\n\tif (TEMP) goto L_03FC;\n\tX8 = *([X21]);\n\tX10 = *([1946F58]);\n\tX9 = *([X8+12E]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_00EE;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_00D6:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_02D5;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00D6;\nL_00EE:\n\tX2 = 2;\n\tX0 = X21;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_02DA;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(X0, X1);\n\tX26 = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1);\n\tX25 = X0;\n\tX1 = 1;\n\tX0 = X23;\n\tX2 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1, X2);\n\tX24 = X0 << 1;\n\tV0 = 1f;\n\tX1 = X23;\n\tX2 = X24;\n\tX28 = X0;\n\tX0 = Spine.SkeletonBinary::ReadFloatArray(X0, X1, X2, V0, X3);\n\tX1 = X23;\n\tstack[8] = X0;\n\tX0 = Spine.SkeletonBinary::ReadShortArray(X0, X1, X2);\n\tX27 = X0;\n\tX0 = X22;\n\tX1 = X23;\n\tX2 = X28;\n\tX0 = Spine.SkeletonBinary::ReadVertices(X0, X1, X2, X3);\n\tX29 = X0;\n\tX1 = 1;\n\tX0 = X23;\n\tX2 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1, X2);\n\tX28 = X0;\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_0269;\n\tX1 = X23;\n\tX0 = Spine.SkeletonBinary::ReadShortArray(X0, X1, X2);\n\tstack[0] = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV8 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tV9 = V0;\n\tgoto L_026C;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(X0, X1);\n\tX25 = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1);\n\tX28 = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(X0, X1);\n\tstack[8] = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(X0, X1);\n\tX26 = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadBoolean(X0, X1);\n\tX27 = X0;\n\tV9 = 0;\n\tV8 = 0;\n\tTEMP = X21 & 1;\n\tif (TEMP) goto L_0142;\n\tX0 = X23;\n\tX1 = 0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tX0 = X23;\n\tX1 = 0;\n\tV8 = V0;\n\tV0 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(X0, X1);\n\tV9 = V0;\nL_0142:\n\tX29 = *([X22+18]);\n\tC = X25 < 0;\n\tC = ~C;\n\tTEMP1 = X25 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X25 ^ 0;\n\tTEMP3 = X25 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0150;\n\tX23 = X20;\n\tgoto L_0151;\nL_0150:\n\tX23 = X25;\nL_0151:\n\t;\n\tif (TEMP) goto L_03FC;\n\tX8 = *([X29]);\n\tX10 = *([1946F58]);\n\tX9 = *([X8+12E]);\n\tX1 = *([X10]);\n\tif (TEMP) goto L_0175;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_015D:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_02EB;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_015D;\nL_0175:\n\tX2 = 1;\n\tX0 = X29;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_02F0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadBoolean(X0, X1);\n\tstack[8] = X0;\n\tX0 = X23;\n\tX1 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadBoolean(X0, X1);\n\tstack[0] = X0;\n\tX1 = 1;\n\tX0 = X23;\n\tX2 = 0;\n\tX0 = Spine.SkeletonBinary+SkeletonInput::ReadInt(X0, X1, X2);\n\tX26 = X0;\n\tX0 = X22;\n\tX1 = X23;\n\tX2 = X26;\n\tX0 = Spine.SkeletonBinary::ReadVertices(X0, X1, X2, X3);\n\tX8 = *([1936A98]);\n\tX9 = 0x5556;\n\tX27 = X0;\n\tX9 = X9 | 0x55550000;\n\tX0 = *([X8]);\n\tX8 = X26 * X9;\n\tX9 = X8 >> 0x3F;\n\tX8 = X8 >> 0x20;\n\tX1 = X8 + X9;\n\tX0 = 0xAD9510(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_03FC;\n\tX8 = *([X0+18]);\n\tX28 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEM\n// ... truncated")]
		private Attachment ReadAttachment(SkeletonInput input, SkeletonData skeletonData, Skin skin, int slotIndex, string attachmentName, bool nonessential)
		{
			string text = input.ReadStringRef();
			if (text == null)
			{
			}
			byte b = input.ReadByte();
			int num = b & 0xFF;
			bool flag = num < 6;
			bool flag2 = !flag;
			int num2 = num - 6;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = b & 0xFF;
				int num4 = 4505600 + 3374;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X9_v2 (System.Int32)+v187 @ X8_v4 (System.Int32)*2]");
				int num5 = (int)((nint)0 << 2);
				int num6 = 22282100 + num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v130 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x600036A")]
		[Address(RVA = "0x153C974", Offset = "0x153C974", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv175 = Il2CppMethodInfo;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv180 = Il2CppMethodInfo;\n\tv181 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv243 = Spine.ExposedList`1<System.Int32>;\n\tv244 = \"il2cpp_codegen_initialize_runtime_metadata\"(v243, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv253 = Spine.ExposedList`1<System.Single>;\n\tv254 = \"il2cpp_codegen_initialize_runtime_metadata\"(v253, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv260 = Spine.SkeletonBinary+Vertices;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v260, input, vertexCount, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37B87]) = v54;\nL_0036:\n\tv57 = new Spine.SkeletonBinary+Vertices();\n\tSpine.SkeletonBinary+Vertices::.ctor(v57);\n\tv72 = Spine.SkeletonBinary+SkeletonInput::ReadBoolean(input);\n\tv178 = v72 == 0;\n\tif (v178) goto L_00CC;\n\tv185 = new Spine.ExposedList`1<System.Single>();\n\tv246 = vertexCount << 1;\n\tv247 = vertexCount + v246;\n\tv248 = v247 << 1;\n\tv143 = vertexCount << 3;\n\tv249 = vertexCount + v143;\n\tv251 = v249 << 1;\n\tSpine.ExposedList`1<System.Single>::.ctor(v185, v251);\n\tv258 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v258, v248);\n\tv284 = vertexCount < 1;\n\tif (v284) goto L_00BF;\nL_006F:\n\tv154 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tSpine.ExposedList`1<System.Int32>::Add(v258, v154);\n\tv326 = v154 < 1;\n\tif (v326) goto L_00AD;\nL_0086:\n\tv350 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tSpine.ExposedList`1<System.Int32>::Add(v258, v350);\n\tv75 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv364 = this.<Scale>k__BackingField * v75;\n\tSpine.ExposedList`1<System.Single>::Add(v185, v364);\n\tv368 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv370 = this.<Scale>k__BackingField * v368;\n\tSpine.ExposedList`1<System.Single>::Add(v185, v370);\n\tv330 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tSpine.ExposedList`1<System.Single>::Add(v185, v330);\n\tv341 = v139 - 1;\n\tv331 = v139 != 1;\n\tif (v331) goto L_0086;\nL_00AD:\n\tv79 = v79 + 1;\n\tv290 = v79 != vertexCount;\n\tif (v290) goto L_006F;\nL_00BF:\n\tv157 = Spine.ExposedList`1<System.Single>::ToArray(v185);\n\tv57.vertices = v157;\n\tv270 = Spine.ExposedList`1<System.Int32>::ToArray(v258);\n\tv57.bones = v270;\n\tgoto L_00E0;\nL_00CC:\n\tv136 = vertexCount << 1;\n\tv158 = Spine.SkeletonBinary::ReadFloatArray(v72, input, v136, this.<Scale>k__BackingField);\n\tv57.vertices = v158;\nL_00E0:\n\treturn v57;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vertices ReadVertices(SkeletonInput input, int vertexCount)
		{
			//IL_0272: Expected O, but got I4
			//IL_0038: Expected O, but got I4
			//IL_009d: Expected O, but got I4
			Vertices vertices = new Vertices();
			bool flag = input.ReadBoolean();
			if (flag)
			{
				int num = default(int);
				ExposedList<float> exposedList = new ExposedList<float>((IEnumerable<float>)num);
				int num2 = vertexCount << 1;
				int num3 = vertexCount + num2;
				int num4 = num3 << 1;
				int num5 = vertexCount << 3;
				int num6 = vertexCount + num5;
				num = num6 << 1;
				ExposedList<int> exposedList2 = new ExposedList<int>((IEnumerable<int>)num4);
				if (vertexCount >= 1)
				{
					int num7 = 0;
					do
					{
						int num8 = input.ReadInt(optimizePositive: true);
						exposedList2.Add(num8);
						bool flag2 = num8 < 1;
						int num9 = num8;
						if (!flag2)
						{
							bool flag3;
							do
							{
								int item = input.ReadInt(optimizePositive: true);
								exposedList2.Add(item);
								float num10 = input.ReadFloat();
								float item2 = Scale * num10;
								exposedList.Add(item2);
								float num11 = input.ReadFloat();
								float item3 = Scale * num11;
								exposedList.Add(item3);
								float item4 = input.ReadFloat();
								exposedList.Add(item4);
								int num12 = num9 - 1;
								flag3 = num9 != 1;
								num9 = num12;
							}
							while (flag3);
						}
						num7++;
					}
					while (num7 != vertexCount);
				}
				float[] vertices2 = exposedList.ToArray();
				vertices.vertices = vertices2;
				int[] bones = exposedList2.ToArray();
				vertices.bones = bones;
			}
			else
			{
				int n = vertexCount << 1;
				float[] vertices3 = ((SkeletonBinary)flag).ReadFloatArray(input, n, Scale);
				vertices.vertices = vertices3;
			}
			return vertices;
		}

		[Token(Token = "0x600036B")]
		[Address(RVA = "0x153CBF8", Offset = "0x153CBF8", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.Single[];\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, input, n, methodInfo, v31, v32, v33, v34, scale, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37B88]) = v45;\nL_001A:\n\t// 26 NewArr v48 @ X0_v3 (System.Single[]), typeof(System.Single[]), n @ X2 (System.Int32)\n\tv60 = scale != 1f;\n\tif (v60) goto L_0061;\n\tv71 = n < 1;\n\tif (v71) goto L_008F;\nL_003B:\n\tv119 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv48[v183 @ X22_v11 (System.Int32)] = v119;\n\tv183 = v183 + 1;\n\tv92 = n != v183;\n\tif (v92) goto L_003B;\n\tgoto L_008F;\nL_0061:\n\tv82 = n < 1;\n\tif (v82) goto L_008F;\nL_006A:\n\tv175 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv118 = v175 * scale;\n\tv48[v184 @ X22_v8 (System.Int32)] = v118;\n\tv184 = v184 + 1;\n\tv91 = n != v184;\n\tif (v91) goto L_006A;\nL_008F:\n\treturn v48;\n\tv185 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float[] ReadFloatArray(SkeletonInput input, int n, float scale)
		{
			float[] array = new float[n];
			if (scale == 1f)
			{
				if (n >= 1)
				{
					int num = 0;
					do
					{
						float num2 = input.ReadFloat();
						array[num] = num2;
						num++;
					}
					while (n != num);
				}
			}
			else if (n >= 1)
			{
				int num3 = 0;
				do
				{
					float num4 = input.ReadFloat();
					float num5 = num4 * scale;
					array[num3] = num5;
					num3++;
				}
				while (n != num3);
			}
			return array;
		}

		[Token(Token = "0x600036C")]
		[Address(RVA = "0x153CD08", Offset = "0x153CD08", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = System.Int32[];\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, input, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37B89]) = v41;\nL_001B:\n\tv48 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\t// 32 NewArr v103 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), v48 @ X0_v7 (System.Int32)\n\tv144 = v48 < 1;\n\tif (v144) goto L_0061;\nL_0033:\n\tv213 = Spine.SkeletonBinary+SkeletonInput::ReadByte(input);\n\tv91 = Spine.SkeletonBinary+SkeletonInput::ReadByte(input);\n\tv176 = v213 & 0xFF;\n\tv216 = v91 & 0xFF;\n\tv217 = v176 & 0xFF;\n\tv174 = v217 << 8;\n\tv218 = v216 & 0xFFFFFFFFFFFF00FF;\n\tv147 = v218 | v174;\n\tv103[v57 @ X22_v6 (System.Int32)] = v147;\n\tv57 = v57 + 1;\n\tv153 = v48 != v57;\n\tif (v153) goto L_0033;\nL_0061:\n\treturn v103;\n\tv98 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private int[] ReadShortArray(SkeletonInput input)
		{
			int num = input.ReadInt(optimizePositive: true);
			int[] array = new int[num];
			if (num >= 1)
			{
				int num2 = 0;
				do
				{
					byte b = input.ReadByte();
					byte b2 = input.ReadByte();
					int num3 = b & 0xFF;
					int num4 = b2 & 0xFF;
					int num5 = num3 & 0xFF;
					int num6 = num5 << 8;
					int num7 = num4 & -65281;
					int num8 = num7 | num6;
					array[num2] = num8;
					num2++;
				}
				while (num != num2);
			}
			return array;
		}

		[Token(Token = "0x600036D")]
		[Address(RVA = "0x153A6E4", Offset = "0x153A6E4", Length = "0x17B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0071;\n\tv58 = Spine.Animation;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv79 = Spine.AttachmentTimeline;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv85 = Spine.ColorTimeline;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv89 = Spine.DeformTimeline;\n\tv90 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1445 = Spine.DrawOrderTimeline;\n\tv1446 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1445, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1526 = Spine.EventTimeline;\n\tv1527 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1526, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1541 = Spine.Event;\n\tv1542 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1541, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1674 = Il2CppMethodInfo;\n\tv1675 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1674, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1801 = Il2CppMethodInfo;\n\tv1802 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1801, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1827 = Il2CppMethodInfo;\n\tv1828 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1827, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv1955 = Spine.ExposedList`1<Spine.Timeline>;\n\tv1956 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1955, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2024 = Spine.IkConstraintTimeline;\n\tv2025 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2024, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2102 = System.Int32[];\n\tv2103 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2102, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2172 = System.Math;\n\tv2173 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2172, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2230 = Spine.PathConstraintMixTimeline;\n\tv2231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2230, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2255 = Spine.PathConstraintPositionTimeline;\n\tv2256 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2255, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2309 = Spine.PathConstraintSpacingTimeline;\n\tv2310 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2309, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2392 = Spine.RotateTimeline;\n\tv2393 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2392, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2578 = Spine.ScaleTimeline;\n\tv2579 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2578, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2704 = Spine.ShearTimeline;\n\tv2705 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2704, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv2867 = System.Single[];\n\tv2868 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2867, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv3291 = Spine.TransformConstraintTimeline;\n\tv3292 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3291, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv3398 = Spine.TranslateTimeline;\n\tv3399 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3398, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv3548 = Spine.TwoColorTimeline;\n\tv3549 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3548, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv3647 = Spine.VertexAttachment;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v3647, name, input, skeletonData, methodInfo, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71);\n\tv75 = 1;\n\t*([1A37B8A]) = v75;\nL_0071:\n\tv77 = new Spine.ExposedList`1<Spine.Timeline>();\n\tSpine.ExposedList`1<Spine.Timeline>::.ctor(v77, 0x20);\n\tv95 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv1451 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv1539 = v95 < 1;\n\tif (v1539) goto L_FFFFFFFF;\nL_0098:\n\tv1761 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv1813 = v1761 < 1;\n\tif (v1813) goto L_020B;\nL_00A9:\n\tv1974 = Spine.SkeletonBinary+SkeletonInput::ReadByte(input);\n\tv2030 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input, 1);\n\tv1315 = v1974 & 0xFF;\n\tv887 = v1315 == 2;\n\tif (v887) goto L_0117;\n\tv885 = v1315 == 1;\n\tif (v885) goto L_0187;\n\tv2232 = v1315 == 0;\n\tv2233 = ~v2232;\n\tif (v2233) goto L_01FC;\n\tv1177 = new Spine.AttachmentTimeline();\n\tSpine.AttachmentTimeline::.ctor(v1177, v2030);\n\tv517 = v2030 - 1;\n\tv1177.slotIndex = v1399;\n\tv2590 = v2030 < 1;\n\tif (v2590) goto L_00FF;\nL_00E1:\n\tv2887 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv3295 = Spine.SkeletonBinary+SkeletonInput::ReadStringRef(input);\n\tSpine.AttachmentTimeline::SetFrame(v1177, v2884, v2887, v3295);\n\tv2884 = v2884 + 1;\n\tv2710 = v2030 != v2884;\n\tif (v2710) goto L_00E1;\nL_00FF:\n\tSpine.ExposedList`1<Spine.Timeline>::Add(v77, v1177);\n\tv3553 = v517 << 2;\n\tv2302 = v1177.frames + v3553;\n\tgoto L_01F2;\nL_0117:\n\tv1179 = new Spine.TwoColorTimeline();\n\tSpine.TwoColorTimeline::.ctor(v1179, v2030);\n\tv518 = v2030 - 1;\n\tv1179.slotIndex = v1399;\n\tv2321 = v2030 < 1;\n\tif (v2321) goto L_017C;\nL_012F:\n\tv2651 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv2755 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input);\n\tv2893 = v2755 >> 0x18;\n\tv2894 = v2755 >> 0x10;\n\tv2895 = v2894 & 0xFF;\n\tv2896 = v2755 >> 8;\n\tv2897 = v2896 & 0xFF;\n\tv2418 = v2755 & 0xFF;\n\tv2413 = v2893 / 0x437F0000;\n\tv2412 = v2895 / 0x437F0000;\n\tv2411 = v2897 / 0x437F0000;\n\tv2410 = v2418 / 0x437F0000;\n\tv2904 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input);\n\tv3309 = v2904 >> 0x10;\n\tv2437 = v3309 & 0xFF;\n\tv3310 = v2904 >> 8;\n\tv2420 = v3310 & 0xFF;\n\tv2419 = v2904 & 0xFF;\n\tv2261 = v2437 / 0x437F0000;\n\tv2260 = v2420 / 0x437F0000;\n\tv2259 = v2419 / 0x437F0000;\n\tSpine.TwoColorTimeline::SetFrame(v1179, v2648, v2651, v2413, v2412, v2411, v2410, v2261, v2260, v2259);\n\tv3420 = v2648 >= v518;\n\tif (v3420) goto L_0169;\n\tSpine.SkeletonBinary::ReadCurve(v1179, input, v2648, v1179);\nL_0169:\n\tv2648 = v2648 + 1;\n\tv2424 = v2030 != v2648;\n\tif (v2424) goto L_012F;\nL_017C:\n\tSpine.ExposedList`1<Spine.Timeline>::Add(v77, v1179);\n\tv3267 = v1179.frames;\n\tv2906 = v2030 << 3;\n\tv3064 = v2906 - 8;\n\tgoto L_01EE;\nL_0187:\n\tv1181 = new Spine.ColorTimeline();\n\tSpine.ColorTimeline::.ctor(v1181, v2030);\n\tv519 = v2030 - 1;\n\tv1181.slotIndex = v1399;\n\tv2404 = v2030 < 1;\n\tif (v2404) goto L_01DA;\nL_019F:\n\tv2750 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv2892 = Spine.SkeletonBinary+SkeletonInput::ReadInt(input);\n\tv2615 = v2892 >> 0x18;\n\tv3296 = v2892 >> 0x10;\n\tv2598 = v3296 & 0xFF;\n\tv3297 = v2892 >> 8;\n\tv2597 = v3297 & 0xFF;\n\tv2596 = v2892 & 0xFF;\n\tv2595 = v2615 / 0x437F0000;\n\tv2267 = v2598 / 0x437F0000;\n\tv2266 = v2597 / 0x437F0000;\n\tv2258 = v2596 / 0x437F0000;\n\tSpine.ColorTimeline::SetFrame(v1181, v2747, v2750, v2595, v2267, v2266, v2258);\n\tv3410 = v2747 >= v519;\n\tif (v3410) goto L_01C7;\n\tSpine.SkeletonBinary::ReadCurve(v1181, input, v2747, v1181);\nL_01C7:\n\tv2747 = v2747 + 1;\n\tv2602 = v2030 != v2747;\n\tif (v2602) g\n// ... truncated")]
		private Animation ReadAnimation(string name, SkeletonInput input, SkeletonData skeletonData)
		{
			//IL_21e0: Expected O, but got I4
			//IL_04ec: Expected O, but got I
			//IL_1bd5: Expected I, but got O
			//IL_0b94: Expected O, but got I4
			//IL_0506: Expected F4, but got I
			//IL_051a: Expected F4, but got I
			//IL_1bec: Expected I4, but got I8
			//IL_0bec: Expected O, but got I4
			//IL_01cb: Expected O, but got I
			//IL_28a7: Expected I4, but got I8
			//IL_1e00: Expected O, but got I
			//IL_1cfd: Expected O, but got I
			//IL_153f: Expected O, but got I
			//IL_1ec6: Expected O, but got I
			//IL_17be: Expected O, but got I
			//IL_17cd: Expected O, but got I
			//IL_16c9: Expected O, but got I
			//IL_16d8: Expected O, but got I
			//IL_1806: Expected O, but got F4
			//IL_1815: Expected O, but got I
			//IL_18d1: Expected I4, but got I8
			//IL_16f2: Expected O, but got F4
			//IL_1701: Expected O, but got I
			ExposedList<Timeline> exposedList = new ExposedList<Timeline>((IEnumerable<Timeline>)32);
			int num = input.ReadInt(optimizePositive: true);
			int num2 = input.ReadInt(optimizePositive: true);
			float num3;
			float num14 = default(float);
			int num59;
			float num7 = default(float);
			float num12 = default(float);
			float num16 = default(float);
			SkeletonData skeletonData2;
			if (num >= 1)
			{
				skeletonData2 = skeletonData;
				num3 = 0f;
				int slotIndex = num2;
				int num4 = 0;
				float num8 = default(float);
				float num9 = default(float);
				float num10 = default(float);
				int num58;
				bool flag5;
				do
				{
					int num5 = input.ReadInt(optimizePositive: true);
					if (num5 >= 1)
					{
						float num6 = num7;
						num8 = num8;
						num9 = num9;
						num10 = num10;
						float num11 = num12;
						float num13 = num14;
						float num15 = num16;
						SkeletonData skeletonData3 = skeletonData2;
						int num17 = 0;
						float num18 = num3;
						bool flag4;
						do
						{
							byte b = input.ReadByte();
							int num19 = input.ReadInt(optimizePositive: true);
							int num20 = b & 0xFF;
							float[] frames;
							int num35;
							object obj;
							if (num20 != 2)
							{
								if (num20 != 1)
								{
									if (num20 == 0)
									{
										AttachmentTimeline attachmentTimeline = new AttachmentTimeline(num19);
										int num21 = num19 - 1;
										attachmentTimeline.slotIndex = slotIndex;
										if (num19 >= 1)
										{
											int num22 = 0;
											bool flag;
											do
											{
												float time = input.ReadFloat();
												string attachmentName = input.ReadStringRef();
												attachmentTimeline.SetFrame(num22, time, attachmentName);
												num22++;
												flag = num19 != num22;
												skeletonData3 = null;
											}
											while (flag);
										}
										exposedList.Add(attachmentTimeline);
										int num23 = num21 << 2;
										obj = (nint)attachmentTimeline.Frames + num23;
										goto IL_04f1;
									}
									goto IL_21ea;
								}
								ColorTimeline colorTimeline = new ColorTimeline(num19);
								int num24 = num19 - 1;
								colorTimeline.slotIndex = slotIndex;
								if (num19 >= 1)
								{
									SkeletonData skeletonData4 = skeletonData3;
									int num25 = 0;
									bool flag2;
									do
									{
										float time2 = input.ReadFloat();
										int num26 = input.ReadInt();
										int num27 = num26 >> 24;
										int num28 = num26 >> 16;
										int num29 = num28 & 0xFF;
										int num30 = num26 >> 8;
										int num31 = num30 & 0xFF;
										int num32 = num26 & 0xFF;
										float r = (float)num27 / 255f;
										num13 = (float)num29 / 255f;
										num11 = (float)num31 / 255f;
										num6 = (float)num32 / 255f;
										colorTimeline.SetFrame(num25, time2, r, num13, num11, num6);
										if (num25 < num24)
										{
											((SkeletonBinary)(object)colorTimeline).ReadCurve(input, num25, (CurveTimeline)colorTimeline);
											skeletonData4 = (SkeletonData)(object)colorTimeline;
										}
										num25++;
										flag2 = num19 != num25;
										skeletonData3 = skeletonData4;
									}
									while (flag2);
								}
								exposedList.Add(colorTimeline);
								frames = colorTimeline.Frames;
								int num33 = num19 << 2;
								int num34 = num19 + num33;
								num35 = num34 - 5;
							}
							else
							{
								TwoColorTimeline twoColorTimeline = new TwoColorTimeline(num19);
								int num36 = num19 - 1;
								twoColorTimeline.slotIndex = slotIndex;
								if (num19 >= 1)
								{
									SkeletonData skeletonData5 = skeletonData3;
									int num37 = 0;
									bool flag3;
									do
									{
										float time3 = input.ReadFloat();
										int num38 = input.ReadInt();
										int num39 = num38 >> 24;
										int num40 = num38 >> 16;
										int num41 = num40 & 0xFF;
										int num42 = num38 >> 8;
										int num43 = num42 & 0xFF;
										int num44 = num38 & 0xFF;
										int num45 = num39 / 1132396544;
										int num46 = num41 / 1132396544;
										int num47 = num43 / 1132396544;
										int num48 = num44 / 1132396544;
										int num49 = input.ReadInt();
										int num50 = num49 >> 16;
										int num51 = num50 & 0xFF;
										int num52 = num49 >> 8;
										int num53 = num52 & 0xFF;
										int num54 = num49 & 0xFF;
										num10 = (float)num51 / 255f;
										num9 = (float)num53 / 255f;
										num8 = (float)num54 / 255f;
										twoColorTimeline.SetFrame(num37, time3, num45, num46, num47, num48, num10, num9, num8);
										if (num37 < num36)
										{
											((SkeletonBinary)(object)twoColorTimeline).ReadCurve(input, num37, (CurveTimeline)twoColorTimeline);
											skeletonData5 = (SkeletonData)(object)twoColorTimeline;
										}
										num37++;
										flag3 = num19 != num37;
										num6 = num48;
										num11 = num47;
										num13 = num46;
										skeletonData3 = skeletonData5;
									}
									while (flag3);
								}
								exposedList.Add(twoColorTimeline);
								frames = twoColorTimeline.Frames;
								int num55 = num19 << 3;
								num35 = num55 - 8;
							}
							int num56 = num35 << 2;
							obj = (nint)frames + num56;
							goto IL_04f1;
							IL_04f1:
							float val = num18;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2302 @ X8_v178+20]");
							float num57 = Math.Max(val, 0f);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2302 @ X8_v178+20]");
							num15 = 0f;
							num18 = num57;
							goto IL_21ea;
							IL_21ea:
							num17++;
							flag4 = num17 != num5;
							num7 = num6;
							num12 = num11;
							num14 = num13;
							num16 = num15;
							skeletonData2 = skeletonData3;
							num3 = num18;
						}
						while (flag4);
					}
					num4++;
					num58 = input.ReadInt(optimizePositive: true);
					flag5 = num4 != num;
					slotIndex = num58;
				}
				while (flag5);
				num59 = num58;
			}
			else
			{
				skeletonData2 = skeletonData;
				num3 = 0f;
				num59 = num2;
			}
			int num60 = input.ReadInt(optimizePositive: true);
			bool flag6 = num59 < 1;
			int num61 = num60;
			if (!flag6)
			{
				float num62 = num14;
				float num63 = num16;
				SkeletonData skeletonData6 = skeletonData2;
				int boneIndex = num60;
				float num64 = num3;
				int num65 = 0;
				bool flag16;
				do
				{
					int num66 = input.ReadInt(optimizePositive: true);
					if (num66 >= 1)
					{
						float num67 = num62;
						float num68 = num63;
						SkeletonData skeletonData7 = skeletonData6;
						float num69 = num64;
						int num70 = 0;
						bool flag15;
						do
						{
							byte b2 = input.ReadByte();
							int num71 = b2 & 0xFF;
							int num72 = input.ReadInt(optimizePositive: true);
							float num76;
							TranslateTimeline translateTimeline2;
							if (num71 != 0)
							{
								int num73 = num71 - 1;
								bool flag7 = num73 < 2;
								bool flag8 = !flag7;
								int num74 = num73 - 2;
								bool flag9 = num74 == 0;
								bool flag10 = !flag9;
								if (!(flag8 && flag10))
								{
									int num75 = b2 & 0xFF;
									if (num75 != 3)
									{
										if (num75 != 2)
										{
											TranslateTimeline translateTimeline = new TranslateTimeline(num72);
											num76 = Scale;
											translateTimeline2 = translateTimeline;
											goto IL_0865;
										}
										ScaleTimeline scaleTimeline = new ScaleTimeline(num72);
										translateTimeline2 = scaleTimeline;
									}
									else
									{
										ShearTimeline shearTimeline = new ShearTimeline(num72);
										translateTimeline2 = shearTimeline;
									}
									bool flag11 = translateTimeline2 == null;
									bool flag12 = !flag11;
									num76 = 1f;
									if (!flag12)
									{
										throw new NullReferenceException();
									}
									goto IL_0865;
								}
								goto IL_2477;
							}
							RotateTimeline rotateTimeline = new RotateTimeline(num72);
							int num77 = num72 - 1;
							rotateTimeline.boneIndex = boneIndex;
							if (num72 >= 1)
							{
								SkeletonData skeletonData8 = skeletonData7;
								int num78 = 0;
								bool flag13;
								do
								{
									float time4 = input.ReadFloat();
									float degrees = input.ReadFloat();
									rotateTimeline.SetFrame(num78, time4, degrees);
									if (num78 < num77)
									{
										((SkeletonBinary)(object)rotateTimeline).ReadCurve(input, num78, (CurveTimeline)rotateTimeline);
										skeletonData8 = (SkeletonData)(object)rotateTimeline;
									}
									num78++;
									flag13 = num72 != num78;
									skeletonData7 = skeletonData8;
								}
								while (flag13);
							}
							exposedList.Add(rotateTimeline);
							float[] frames2 = rotateTimeline.Frames;
							int num79 = num72 << 1;
							int num80 = num79 - 2;
							goto IL_09b2;
							IL_09b2:
							float num81 = Math.Max(num69, frames2[num80]);
							num68 = frames2[num80];
							num69 = num81;
							goto IL_2477;
							IL_0865:
							int num82 = num72 - 1;
							translateTimeline2.boneIndex = boneIndex;
							if (num72 >= 1)
							{
								SkeletonData skeletonData9 = skeletonData7;
								int num83 = 0;
								bool flag14;
								do
								{
									float time5 = input.ReadFloat();
									float num84 = input.ReadFloat();
									float num85 = input.ReadFloat();
									float x = num76 * num84;
									num67 = num76 * num85;
									translateTimeline2.SetFrame(num83, time5, x, num67);
									if (num83 < num82)
									{
										((SkeletonBinary)(object)translateTimeline2).ReadCurve(input, num83, (CurveTimeline)translateTimeline2);
										skeletonData9 = (SkeletonData)(object)translateTimeline2;
									}
									num83++;
									flag14 = num72 != num83;
									skeletonData7 = skeletonData9;
								}
								while (flag14);
							}
							exposedList.Add(translateTimeline2);
							frames2 = translateTimeline2.Frames;
							int num86 = num72 << 1;
							int num87 = num72 + num86;
							num80 = num87 - 3;
							goto IL_09b2;
							IL_2477:
							num70++;
							flag15 = num70 != num66;
							num62 = num67;
							num63 = num68;
							skeletonData6 = skeletonData7;
							num64 = num69;
						}
						while (flag15);
					}
					num65++;
					int num88 = input.ReadInt(optimizePositive: true);
					flag16 = num65 != num59;
					num14 = num62;
					num16 = num63;
					skeletonData2 = skeletonData6;
					num61 = num88;
					num3 = num64;
					boneIndex = num88;
				}
				while (flag16);
			}
			int num89 = input.ReadInt(optimizePositive: true);
			bool flag17 = num61 < 1;
			int num90 = num89;
			if (!flag17)
			{
				object obj3 = default(object);
				object obj2 = obj3;
				IntPtr intPtr = default(IntPtr);
				nint num91 = intPtr;
				float num92 = num14;
				SkeletonData skeletonData10 = skeletonData2;
				int num93 = 0;
				float val2 = num3;
				int ikConstraintIndex = num89;
				bool flag22;
				do
				{
					int num94 = input.ReadInt(optimizePositive: true);
					IkConstraintTimeline ikConstraintTimeline = new IkConstraintTimeline(num94);
					int num95 = num94 - 1;
					ikConstraintTimeline.ikConstraintIndex = ikConstraintIndex;
					if (num94 >= 1)
					{
						int num96 = 0;
						bool flag21;
						do
						{
							float time6 = input.ReadFloat();
							float mix = input.ReadFloat();
							float num97 = input.ReadFloat();
							sbyte bendDirection = input.ReadSByte();
							bool flag18 = input.ReadBoolean();
							bool flag19 = input.ReadBoolean();
							num92 = Scale * num97;
							ikConstraintTimeline.SetFrame(num96, time6, mix, num92, bendDirection, flag18, flag19);
							bool flag20 = num96 >= num95;
							skeletonData10 = (SkeletonData)flag18;
							if (!flag20)
							{
								((SkeletonBinary)(object)ikConstraintTimeline).ReadCurve(input, num96, (CurveTimeline)ikConstraintTimeline);
								skeletonData10 = (SkeletonData)(object)ikConstraintTimeline;
							}
							num96++;
							flag21 = num94 != num96;
							obj2 = 0;
							num91 = (flag19 ? 1 : 0);
						}
						while (flag21);
					}
					exposedList.Add(ikConstraintTimeline);
					float[] frames3 = ikConstraintTimeline.Frames;
					int num98 = num94 * 6;
					int num99 = num98 - 6;
					float num100 = Math.Max(val2, frames3[num99]);
					num93++;
					int num101 = input.ReadInt(optimizePositive: true);
					flag22 = num93 != num61;
					num14 = num92;
					num16 = frames3[num99];
					skeletonData2 = skeletonData10;
					num3 = num100;
					num90 = num101;
					val2 = num100;
					ikConstraintIndex = num101;
				}
				while (flag22);
			}
			int num102 = input.ReadInt(optimizePositive: true);
			bool flag23 = num90 < 1;
			int num103 = num102;
			if (!flag23)
			{
				float num104 = num7;
				float num105 = num12;
				float num106 = num14;
				SkeletonData skeletonData11 = skeletonData2;
				int transformConstraintIndex = num102;
				float val3 = num3;
				int num107 = 0;
				bool flag25;
				do
				{
					int num108 = input.ReadInt(optimizePositive: true);
					TransformConstraintTimeline transformConstraintTimeline = new TransformConstraintTimeline(num108);
					int num109 = num108 - 1;
					transformConstraintTimeline.transformConstraintIndex = transformConstraintIndex;
					if (num108 >= 1)
					{
						SkeletonData skeletonData12 = skeletonData11;
						int num110 = 0;
						bool flag24;
						do
						{
							float time7 = input.ReadFloat();
							float rotateMix = input.ReadFloat();
							float num111 = input.ReadFloat();
							float num112 = input.ReadFloat();
							float num113 = input.ReadFloat();
							transformConstraintTimeline.SetFrame(num110, time7, rotateMix, num111, num112, num113);
							if (num110 < num109)
							{
								((SkeletonBinary)(object)transformConstraintTimeline).ReadCurve(input, num110, (CurveTimeline)transformConstraintTimeline);
								skeletonData12 = (SkeletonData)(object)transformConstraintTimeline;
							}
							num110++;
							flag24 = num108 != num110;
							num104 = num113;
							num105 = num112;
							num106 = num111;
							skeletonData11 = skeletonData12;
						}
						while (flag24);
					}
					exposedList.Add(transformConstraintTimeline);
					float[] frames4 = transformConstraintTimeline.Frames;
					int num114 = num108 << 2;
					int num115 = num108 + num114;
					int num116 = num115 - 5;
					float num117 = Math.Max(val3, frames4[num116]);
					num107++;
					int num118 = input.ReadInt(optimizePositive: true);
					flag25 = num107 != num90;
					num7 = num104;
					num12 = num105;
					num14 = num106;
					num16 = frames4[num116];
					skeletonData2 = skeletonData11;
					num103 = num118;
					num3 = num117;
					transformConstraintIndex = num118;
					val3 = num117;
				}
				while (flag25);
			}
			int num119 = input.ReadInt(optimizePositive: true);
			SkeletonData skeletonData17;
			if (num103 >= 1)
			{
				SkeletonData skeletonData13 = skeletonData;
				int num120 = 0;
				bool flag34;
				do
				{
					ExposedList<PathConstraintData> pathConstraints = skeletonData13.PathConstraints;
					PathConstraintData[] items = pathConstraints.Items;
					PathConstraintData pathConstraintData = items[num119];
					int num121 = input.ReadInt(optimizePositive: true);
					if (num121 >= 1)
					{
						float num122 = num14;
						float num123 = num16;
						SkeletonData skeletonData14 = skeletonData2;
						int num124 = 0;
						float num125 = num3;
						bool flag33;
						do
						{
							sbyte b3 = input.ReadSByte();
							int num126 = b3 & 0xFF;
							int num127 = input.ReadInt(optimizePositive: true);
							float[] frames5;
							int num133;
							if (num126 >= 2)
							{
								if (num126 != 2)
								{
									goto IL_25f5;
								}
								PathConstraintMixTimeline pathConstraintMixTimeline = new PathConstraintMixTimeline(num127);
								int num128 = num127 - 1;
								pathConstraintMixTimeline.pathConstraintIndex = num119;
								if (num127 >= 1)
								{
									SkeletonData skeletonData15 = skeletonData14;
									int num129 = 0;
									bool flag26;
									do
									{
										float time8 = input.ReadFloat();
										float rotateMix2 = input.ReadFloat();
										float num130 = input.ReadFloat();
										pathConstraintMixTimeline.SetFrame(num129, time8, rotateMix2, num130);
										if (num129 < num128)
										{
											((SkeletonBinary)(object)pathConstraintMixTimeline).ReadCurve(input, num129, (CurveTimeline)pathConstraintMixTimeline);
											skeletonData15 = (SkeletonData)(object)pathConstraintMixTimeline;
										}
										num129++;
										flag26 = num127 != num129;
										num122 = num130;
										skeletonData14 = skeletonData15;
									}
									while (flag26);
								}
								exposedList.Add(pathConstraintMixTimeline);
								frames5 = pathConstraintMixTimeline.Frames;
								int num131 = num127 << 1;
								int num132 = num127 + num131;
								num133 = num132 - 3;
							}
							else
							{
								bool flag30;
								PathConstraintPositionTimeline pathConstraintPositionTimeline;
								if (num126 == 1)
								{
									PathConstraintSpacingTimeline pathConstraintSpacingTimeline = new PathConstraintSpacingTimeline(num127);
									bool flag27 = pathConstraintData.SpacingMode < SpacingMode.Percent;
									bool flag28 = !flag27;
									bool flag29 = !flag28;
									flag30 = flag29;
									pathConstraintPositionTimeline = pathConstraintSpacingTimeline;
								}
								else
								{
									PathConstraintPositionTimeline pathConstraintPositionTimeline2 = new PathConstraintPositionTimeline(num127);
									bool flag31 = pathConstraintData.PositionMode == PositionMode.Fixed;
									flag30 = flag31;
									pathConstraintPositionTimeline = pathConstraintPositionTimeline2;
								}
								float num134 = ((!flag30) ? 1f : Scale);
								int num135 = num127 - 1;
								pathConstraintPositionTimeline.pathConstraintIndex = num119;
								if (num127 >= 1)
								{
									SkeletonData skeletonData16 = skeletonData14;
									int num136 = 0;
									bool flag32;
									do
									{
										float time9 = input.ReadFloat();
										float num137 = input.ReadFloat();
										float position = num134 * num137;
										pathConstraintPositionTimeline.SetFrame(num136, time9, position);
										if (num136 < num135)
										{
											((SkeletonBinary)(object)pathConstraintPositionTimeline).ReadCurve(input, num136, (CurveTimeline)pathConstraintPositionTimeline);
											skeletonData16 = (SkeletonData)(object)pathConstraintPositionTimeline;
										}
										num136++;
										flag32 = num127 != num136;
										skeletonData14 = skeletonData16;
									}
									while (flag32);
								}
								exposedList.Add(pathConstraintPositionTimeline);
								frames5 = pathConstraintPositionTimeline.Frames;
								int num138 = num127 << 1;
								num133 = num138 - 2;
							}
							float num139 = Math.Max(num125, frames5[num133]);
							num123 = frames5[num133];
							num125 = num139;
							goto IL_25f5;
							IL_25f5:
							num124++;
							flag33 = num124 != num121;
							num14 = num122;
							num16 = num123;
							skeletonData2 = skeletonData14;
							num3 = num125;
						}
						while (flag33);
					}
					num120++;
					num119 = input.ReadInt(optimizePositive: true);
					flag34 = num120 != num103;
					skeletonData13 = skeletonData;
				}
				while (flag34);
				skeletonData17 = skeletonData;
			}
			else
			{
				skeletonData17 = skeletonData;
			}
			if (num119 >= 1)
			{
				float num140 = num16;
				int num141 = 0;
				SkeletonData skeletonData18 = skeletonData2;
				float num142 = num3;
				bool flag47;
				do
				{
					ExposedList<Skin> skins = skeletonData17.Skins;
					Skin[] items2 = skins.Items;
					int num143 = input.ReadInt(optimizePositive: true);
					int num144 = input.ReadInt(optimizePositive: true);
					if (num144 >= 1)
					{
						float num145 = num140;
						int num146 = 0;
						SkeletonData skeletonData19 = skeletonData18;
						float num147 = num142;
						Skin skin = items2[num143];
						bool flag46;
						do
						{
							int num148 = input.ReadInt(optimizePositive: true);
							int num149 = input.ReadInt(optimizePositive: true);
							if (num149 >= 1)
							{
								int num150 = 0;
								float val4 = num147;
								int slotIndex2 = num148;
								Skin skin2 = skin;
								bool flag45;
								do
								{
									string name2 = input.ReadStringRef();
									Attachment attachment = skin2.GetAttachment(slotIndex2, name2);
									VertexAttachment vertexAttachment = attachment as VertexAttachment;
									if (vertexAttachment != null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1203 @ X0_v97 (Spine.Attachment)+28]");
										float[] array = (float[])0;
										int num151 = array.Length;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1203 @ X0_v97 (Spine.Attachment)+20]");
										if ((nint)0 != 0)
										{
											int num152 = array.Length * 1431655766;
											int num153 = num152 >> 63;
											int num154 = num152 >> 32;
											int num155 = num154 + num153;
											num151 = num155 << 1;
										}
										int num156 = input.ReadInt(optimizePositive: true);
										DeformTimeline deformTimeline = new DeformTimeline(num156);
										deformTimeline.slotIndex = slotIndex2;
										int num157 = num156 - 1;
										deformTimeline.Attachment = (VertexAttachment)attachment;
										bool flag35 = num156 < 1;
										CurveTimeline curveTimeline = null;
										DeformTimeline deformTimeline2 = deformTimeline;
										int num158 = num157;
										if (!flag35)
										{
											int num159 = num156;
											int num160 = 0;
											int num161 = num157;
											bool flag44;
											do
											{
												float time10 = input.ReadFloat();
												int num162 = input.ReadInt(optimizePositive: true);
												float[] vertices;
												if (num162 != 0)
												{
													float[] array2 = new float[num151];
													int num163 = input.ReadInt(optimizePositive: true);
													int num164 = num163 + num162;
													if (Scale == 1f)
													{
														if (num163 < num164)
														{
															int num165 = num163 << 2;
															object obj4 = (nint)array2 + num165;
															object obj5 = (nint)obj4 + 32;
															int num166 = num164 - num163;
															bool flag36;
															do
															{
																float num167 = input.ReadFloat();
																obj5 = num167;
																obj5 = (nint)obj5 + 4;
																int num168 = num166 - 1;
																flag36 = num166 != 1;
																num166 = num168;
															}
															while (flag36);
														}
													}
													else if (num163 < num164)
													{
														int num169 = num163 << 2;
														object obj6 = (nint)array2 + num169;
														object obj7 = (nint)obj6 + 32;
														int num170 = num164 - num163;
														bool flag37;
														do
														{
															float num171 = input.ReadFloat();
															float num172 = Scale * num171;
															int num173 = num170 - 1;
															obj7 = num172;
															obj7 = (nint)obj7 + 4;
															flag37 = num170 != 1;
															num170 = num173;
														}
														while (flag37);
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1203 @ X0_v97 (Spine.Attachment)+20]");
													bool flag38 = (nint)0 == 0;
													bool flag39 = !flag38;
													vertices = array2;
													num159 = num156;
													num161 = num157;
													if (!flag39)
													{
														bool flag40 = array2.Length < 1;
														vertices = array2;
														num159 = num156;
														num161 = num157;
														if (!flag40)
														{
															int num174 = (int)(array2.Length & 0xFFFFFFFFL);
															int num175 = 0;
															bool flag41;
															do
															{
																float num176 = array2[num175] + array[num175];
																array2[num175] = num176;
																int num177 = num175 + 1;
																flag41 = num174 != num177;
																vertices = array2;
																num159 = num156;
																num161 = num157;
																num175 = num177;
															}
															while (flag41);
														}
													}
												}
												else
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1203 @ X0_v97 (Spine.Attachment)+20]");
													bool flag42 = (nint)0 == 0;
													vertices = array;
													if (!flag42)
													{
														float[] array3 = new float[num151];
														vertices = array3;
													}
												}
												deformTimeline.SetFrame(num160, time10, vertices);
												bool flag43 = num160 >= num161;
												curveTimeline = null;
												if (!flag43)
												{
													((SkeletonBinary)(object)deformTimeline).ReadCurve(input, num160, (CurveTimeline)deformTimeline);
													curveTimeline = deformTimeline;
												}
												num160++;
												flag44 = num160 != num159;
												deformTimeline2 = deformTimeline;
												num158 = num161;
											}
											while (flag44);
										}
										exposedList.Add(deformTimeline2);
										float[] frames6 = deformTimeline2.Frames;
										float num178 = Math.Max(val4, frames6[num158]);
										num150++;
										flag45 = num150 != num149;
										num145 = frames6[num158];
										skeletonData19 = (SkeletonData)(object)curveTimeline;
										num147 = num178;
										skin = items2[num143];
										val4 = num178;
										slotIndex2 = num148;
										skin2 = items2[num143];
										continue;
									}
									return (Animation)(object)new InvalidCastException();
								}
								while (flag45);
							}
							num146++;
							flag46 = num146 != num144;
							num140 = num145;
							skeletonData18 = skeletonData19;
							num142 = num147;
						}
						while (flag46);
					}
					num141++;
					flag47 = num141 != num119;
					num16 = num140;
					skeletonData2 = skeletonData18;
					num3 = num142;
					skeletonData17 = skeletonData;
				}
				while (flag47);
			}
			int num179 = input.ReadInt(optimizePositive: true);
			int num180 = num179 - 1;
			if (num179 >= 1)
			{
				DrawOrderTimeline drawOrderTimeline = new DrawOrderTimeline(num179);
				ExposedList<SlotData> slots = skeletonData.Slots;
				int num181 = slots.Count - 1;
				int num182 = 0;
				nint num183 = (nint)typeof(int[]);
				int[] array4 = default(int[]);
				object obj9 = default(object);
				bool flag53;
				do
				{
					float time11 = input.ReadFloat();
					int num184 = input.ReadInt(optimizePositive: true);
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					if ((int)(num181 & 0x80000000L) == 0)
					{
						int num185 = num181;
						bool flag48;
						do
						{
							int num186 = num185 - 1;
							array4[num185] = -1;
							flag48 = num185 > 0;
							num185 = num186;
						}
						while (flag48);
					}
					int num187 = slots.Count - num184;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"SzArrayNew\"");
					int num188;
					int num197;
					if (num184 >= 1)
					{
						num188 = 0;
						int num189 = 0;
						int num190 = 0;
						bool flag50;
						do
						{
							int num191 = input.ReadInt(optimizePositive: true);
							if (num190 != num191)
							{
								int num192;
								bool flag49;
								do
								{
									num192 = num188 + 1;
									int num193 = num190 + 1;
									int num194 = num188 << 2;
									object obj8 = (nint)obj9 + num194;
									flag49 = num191 != num193;
									num188 = num192;
									num190 = num193;
								}
								while (flag49);
								num188 = num192;
								num190 = num191;
							}
							int num195 = input.ReadInt(optimizePositive: true);
							int num196 = num195 + num190;
							num197 = num190 + 1;
							num189++;
							array4[num196] = num190;
							flag50 = num189 != num184;
							num190 = num197;
						}
						while (flag50);
					}
					else
					{
						num197 = 0;
						num188 = 0;
					}
					int num198;
					if (num197 < slots.Count)
					{
						bool flag51;
						do
						{
							num198 = num188 + 1;
							int num199 = num197 + 1;
							int num200 = num188 << 2;
							object obj10 = (nint)obj9 + num200;
							flag51 = slots.Count != num199;
							num197 = num199;
							num188 = num198;
						}
						while (flag51);
					}
					else
					{
						num198 = num188;
					}
					if ((int)(num181 & 0x80000000L) == 0)
					{
						int num201 = num181;
						bool flag52;
						do
						{
							if (array4[num201] + 1 == 0)
							{
								num198--;
								int num202 = num198 << 2;
								object obj11 = (nint)obj9 + num202;
								int num203 = num201;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4420 @ X12_v11+20]");
								array4[num203] = 0;
							}
							int num204 = num201 - 1;
							flag52 = num201 > 0;
							num201 = num204;
						}
						while (flag52);
					}
					drawOrderTimeline.SetFrame(num182, time11, array4);
					num182++;
					flag53 = num182 != num179;
					skeletonData2 = null;
				}
				while (flag53);
				exposedList.Add(drawOrderTimeline);
				float[] frames7 = drawOrderTimeline.Frames;
				float num205 = Math.Max(num3, frames7[num180]);
				num3 = num205;
			}
			int num206 = input.ReadInt(optimizePositive: true);
			float duration = default(float);
			ExposedList<Timeline> exposedList2;
			if (num206 >= 1)
			{
				EventTimeline eventTimeline = new EventTimeline(num206);
				int num207 = 0;
				do
				{
					float time12 = input.ReadFloat();
					ExposedList<EventData> events = skeletonData.Events;
					EventData[] items3 = events.Items;
					int num208 = input.ReadInt(optimizePositive: true);
					EventData eventData = items3[num208];
					Event obj12 = new Event(time12, items3[num208]);
					int num209 = input.ReadInt(optimizePositive: false);
					obj12.Int = num209;
					float num210 = input.ReadFloat();
					obj12.Float = num210;
					string text = ((!input.ReadBoolean()) ? eventData.String : input.ReadString());
					EventData data = obj12.Data;
					obj12.String = text;
					if (data.AudioPath != null)
					{
						float volume = input.ReadFloat();
						obj12.Volume = volume;
						float balance = input.ReadFloat();
						obj12.Balance = balance;
					}
					eventTimeline.SetFrame(num207, obj12);
					num207++;
				}
				while (num206 != num207);
				exposedList.Add(eventTimeline);
				float[] frames8 = eventTimeline.Frames;
				int num211 = num206 - 1;
				duration = Math.Max(num3, frames8[num211]);
				exposedList2 = exposedList;
			}
			else
			{
				exposedList2 = exposedList;
			}
			exposedList2.TrimExcess();
			return new Animation(name, exposedList2, duration);
		}

		[Token(Token = "0x600036E")]
		[Address(RVA = "0x153CDEC", Offset = "0x153CDEC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Spine.SkeletonBinary+SkeletonInput::ReadByte(input);\n\tv70 = v23 & 0xFF;\n\tv55 = v70 == 2;\n\tif (v55) goto L_0037;\n\tv35 = v70 != 1;\n\tif (v35) goto L_005F;\n\tSpine.CurveTimeline::SetStepped(timeline, frameIndex);\n\treturn;\nL_0037:\n\tv98 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv157 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv160 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tv26 = Spine.SkeletonBinary+SkeletonInput::ReadFloat(input);\n\tSpine.CurveTimeline::SetCurve(timeline, frameIndex, v98, v157, v160, v26);\n\treturn;\nL_005F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ReadCurve(SkeletonInput input, int frameIndex, CurveTimeline timeline)
		{
			byte b = input.ReadByte();
			switch (b & 0xFF)
			{
			case 1:
				timeline.SetStepped(frameIndex);
				break;
			case 2:
			{
				float cx = input.ReadFloat();
				float cy = input.ReadFloat();
				float cx2 = input.ReadFloat();
				float cy2 = input.ReadFloat();
				timeline.SetCurve(frameIndex, cx, cy, cx2, cy2);
				break;
			}
			}
		}
	}
}
