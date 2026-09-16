using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x200002E")]
	internal class FileFilter
	{
		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x10")]
		public bool caseSensitive;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x11")]
		public bool folderRecursive;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x12")]
		public bool exactFileNameMatch;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x13")]
		public bool exactFolderMatch;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x18")]
		public string filterPath;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x20")]
		public string filterExtension;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x28")]
		public string filterFileName;

		[Token(Token = "0x6000359")]
		[Address(RVA = "0xBE9858", Offset = "0xBE9858", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = System.IO.Path;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, filePath, root, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv45 = \".\";\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, filePath, root, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A35510]) = v39;\nL_0019:\n\tv43 = this.filterExtension == 0;\n\tif (v43) goto L_0058;\n\tgoto L_0023;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v46, filePath, root, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv100 = System.IO.Path::GetExtension(filePath);\n\tv157 = System.String::IsNullOrEmpty(v100);\n\tv194 = v157 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_FFFFFFFF;\n\tv224 = System.String::op_Equality(v100, \".\");\n\tv306 = v224 == 0;\n\tv278 = ~v306;\n\tif (v278) goto L_FFFFFFFF;\n\tv225 = System.String::Remove(v100, 0, 1);\n\tif (this.caseSensitive) goto L_FFFFFFFF;\n\tv83 = 4 + 1;\n\tgoto L_0053;\nL_0053:\n\tv87 = System.String::Equals(this.filterExtension, v225, v83);\n\tv89 = v87 == 0;\n\tif (v89) goto L_FFFFFFFF;\nL_0058:\n\tv95 = this.filterFileName == 0;\n\tif (v95) goto L_00A6;\n\tgoto L_0062;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v101, v84, v82, v80, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tv162 = System.IO.Path::GetFileNameWithoutExtension(filePath);\n\tv197 = System.String::IsNullOrEmpty(v162);\n\tv281 = v197 == 0;\n\tv279 = ~v281;\n\tif (v279) goto L_FFFFFFFF;\n\tv307 = ~this.exactFileNameMatch;\n\tif (v307) goto L_0097;\n\tif (this.caseSensitive) goto L_FFFFFFFF;\n\tv139 = 4 + 1;\n\tgoto L_0084;\nL_0084:\n\tv145 = System.String::Equals(this.filterFileName, v162, v139);\n\tv327 = v145 == 0;\n\tv148 = ~v327;\n\tif (v148) goto L_00A6;\n\tgoto L_FFFFFFFF;\nL_0097:\n\tif (this.caseSensitive) goto L_FFFFFFFF;\n\tv138 = 4 + 1;\n\tgoto L_009E;\nL_009E:\n\tv144 = System.String::IndexOf(v162, this.filterFileName, v138);\n\tv147 = v144 + 1;\n\tv121 = v147 == 0;\n\tif (v121) goto L_FFFFFFFF;\nL_00A6:\n\tv155 = this.filterPath == 0;\n\tif (v155) goto L_FFFFFFFF;\n\tif (this.caseSensitive) goto L_FFFFFFFF;\n\tv185 = 4 + 1;\n\tgoto L_00BD;\nL_00BD:\n\tv187 = System.String::IndexOf(filePath, this.filterPath, v185);\n\tv189 = v187 + 1;\n\tv175 = v189 == 0;\n\tif (v175) goto L_FFFFFFFF;\n\tgoto L_00CD;\nL_00CD:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool MatchesPath(string filePath, string root = null)
		{
			if (filterExtension == null)
			{
				goto IL_00d9;
			}
			string extension = Path.GetExtension(filePath);
			if (!string.IsNullOrEmpty(extension) && !(extension == "."))
			{
				string value = extension.Remove(0, 1);
				StringComparison comparisonType = (caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
				if (filterExtension.Equals(value, comparisonType))
				{
					goto IL_00d9;
				}
			}
			goto IL_0227;
			IL_0227:
			return false;
			IL_01c8:
			if (filterPath != null)
			{
				int num = filePath.IndexOf(comparisonType: caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase, value: filterPath);
				if (num + 1 == 0)
				{
					goto IL_0227;
				}
			}
			return true;
			IL_00d9:
			if (filterFileName == null)
			{
				goto IL_01c8;
			}
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
			if (!string.IsNullOrEmpty(fileNameWithoutExtension))
			{
				if (exactFileNameMatch)
				{
					StringComparison comparisonType2 = (caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
					if (filterFileName.Equals(fileNameWithoutExtension, comparisonType2))
					{
						goto IL_01c8;
					}
				}
				else
				{
					int num2 = fileNameWithoutExtension.IndexOf(comparisonType: caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase, value: filterFileName);
					if (num2 + 1 != 0)
					{
						goto IL_01c8;
					}
				}
			}
			goto IL_0227;
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0xBE9A14", Offset = "0xBE9A14", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv22 = System.Boolean;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.String[];\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"|\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35511]) = v42;\n\t// 30 NewArr v45 @ X0_v3 (System.String[]), typeof(System.String[]), 13\nL_0021:\n\tv51 = this + 0x10;\n\tgoto L_0029;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v50, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0029:\n\tv61 = System.Boolean::ToString(v51);\n\tv45[0] = v61;\n\tv225 = this + 0x11;\n\tv45[1] = \"|\";\n\tv217 = System.Boolean::ToString(v225);\n\tv45[2] = v217;\n\tv258 = this + 0x12;\n\tv45[3] = \"|\";\n\tv218 = System.Boolean::ToString(v258);\n\tv45[4] = v218;\n\tv263 = this + 0x13;\n\tv45[5] = \"|\";\n\tv219 = System.Boolean::ToString(v263);\n\tv45[6] = v219;\n\tv45[7] = \"|\";\n\tv45[8] = this.filterPath;\n\tv45[9] = \"|\";\n\tv45[10] = this.filterExtension;\n\tv45[11] = \"|\";\n\tv45[12] = this.filterFileName;\n\treturnVal2 = System.String::Concat(v45);\n\treturn returnVal2;\n\tv98 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 190 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override string ToString()
		{
			bool flag = (byte)((nint)this + 16) != 0;
			string text = (flag ? ((bool*)1) : ((bool*)null))->ToString();
			bool flag2 = (byte)((nint)this + 17) != 0;
			string text2 = (flag2 ? ((bool*)1) : ((bool*)null))->ToString();
			bool flag3 = (byte)((nint)this + 18) != 0;
			string text3 = (flag3 ? ((bool*)1) : ((bool*)null))->ToString();
			bool flag4 = (byte)((nint)this + 19) != 0;
			string text4 = (flag4 ? ((bool*)1) : ((bool*)null))->ToString();
			return text + "|" + text2 + "|" + text3 + "|" + text4 + "|" + filterPath + "|" + filterExtension + "|" + filterFileName;
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0xBE93C0", Offset = "0xBE93C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FileFilter()
		{
		}
	}
}
