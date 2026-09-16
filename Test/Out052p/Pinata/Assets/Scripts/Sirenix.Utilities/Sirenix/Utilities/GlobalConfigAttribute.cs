using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.Utilities
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x741BB4", Offset = "0x741BB4")]
	[Token(Token = "0x2000007")]
	public class GlobalConfigAttribute : Attribute
	{
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x10")]
		private string assetPath;

		[CompilerGenerated]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x18")]
		private bool _003CUseAsset_003Ek__BackingField;

		[Token(Token = "0x17000004")]
		public string AssetPath
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x1658AE8", Offset = "0x1658AE8", Length = "0x138")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE2FD0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF2C]) = v38;\nL_0017:\n\tv42 = System.String::Trim(this.assetPath);\n\t// 30 NewArr v104 @ X0_v10 (System.Char[]), typeof(System.Char[]), 2\n\tv148 = v104.Length == 0;\n\tif (v148) goto L_0069;\n\tv70 = v104.Length == 1;\n\tv104[0] = 0x2F;\n\tif (v70) goto L_0069;\n\tv104[1] = 0x5C;\n\tv187 = System.String::TrimEnd(v42, v104);\n\t// 61 NewArr v105 @ X0_v17 (System.Char[]), typeof(System.Char[]), 2\n\tv183 = v105.Length == 0;\n\tif (v183) goto L_0069;\n\tv71 = v105.Length == 1;\n\tv105[0] = 0x2F;\n\tif (v71) goto L_0069;\n\tv105[1] = 0x5C;\n\tv106 = System.String::TrimStart(v187, v105);\n\tv194 = System.String::Replace(v106, 0x5C, 0x2F);\n\treturnVal2 = System.String::Concat(v194, \"/\");\n\treturn returnVal2;\nL_0069:\n\tv184 = new System.IndexOutOfRangeException();\n\tthrow v184;\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string text = assetPath.Trim();
				char[] array = new char[2];
				if (array.Length != 0)
				{
					bool flag = array.Length == 1;
					array[0] = '/';
					if (!flag)
					{
						array[1] = '\\';
						string text2 = text.TrimEnd(array);
						char[] array2 = new char[2];
						if (array2.Length != 0)
						{
							bool flag2 = array2.Length == 1;
							array2[0] = '/';
							if (!flag2)
							{
								array2[1] = '\\';
								string text3 = text2.TrimStart(array2);
								string text4 = text3.Replace('\\', '/');
								return text4 + "/";
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x17000005")]
		public string ResourcesPath
		{
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x1658C20", Offset = "0x1658C20", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EC9318]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF2D]) = v38;\nL_0014:\n\tv40 = Sirenix.Utilities.GlobalConfigAttribute::get_IsInResourcesFolder(this);\n\tv42 = v40 == 0;\n\tif (v42) goto L_003E;\n\tv44 = Sirenix.Utilities.GlobalConfigAttribute::get_AssetPath(this);\n\tv52 = System.String::LastIndexOf(v44, \"/resources/\", 3);\n\tv96 = v52 & 0x80000000;\n\tv97 = v96 == 0;\n\tv54 = ~v97;\n\tif (v54) goto L_003E;\n\tv99 = \"/resources/\";\n\tv70 = v99.m_stringLength + v52;\n\treturnVal3 = System.String::Substring(v44, v70);\n\treturn returnVal3;\nL_003E:\n\treturn \"\";\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_003d: Expected I4, but got I8
				if (IsInResourcesFolder)
				{
					string text = AssetPath;
					int num = text.LastIndexOf("/resources/", StringComparison.InvariantCultureIgnoreCase);
					if ((int)(num & 0x80000000L) == 0)
					{
						string text2 = "/resources/";
						int startIndex = text2.Length + num;
						return text.Substring(startIndex);
					}
				}
				return "";
			}
		}

		[Token(Token = "0x17000006")]
		public bool UseAsset
		{
			[CompilerGenerated]
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x1658D30", Offset = "0x1658D30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UseAsset>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UseAsset;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x1658D38", Offset = "0x1658D38", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UseAsset>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CUseAsset_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000007")]
		public bool IsInResourcesFolder
		{
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x1658CD8", Offset = "0x1658CD8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F10968]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202AF2E]) = v38;\nL_0014:\n\tv40 = Sirenix.Utilities.GlobalConfigAttribute::get_AssetPath(this);\n\treturnVal1 = Sirenix.Utilities.StringExtensions::Contains(v40, \"/resources/\", 5);\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string source = AssetPath;
				return source.Contains("/resources/", StringComparison.OrdinalIgnoreCase);
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x1658D6C", Offset = "0x1658D6C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.assetPath = assetPath;\n\tthis.<UseAsset>k__BackingField = 1;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalConfigAttribute(string assetPath)
		{
			this.assetPath = assetPath;
			UseAsset = true;
		}
	}
}
