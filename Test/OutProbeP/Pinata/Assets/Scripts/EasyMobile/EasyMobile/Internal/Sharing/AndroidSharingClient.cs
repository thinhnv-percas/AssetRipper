using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal.Sharing
{
	[Token(Token = "0x20000D3")]
	internal class AndroidSharingClient : ISharingClient
	{
		[Token(Token = "0x40003C1")]
		private const string NATIVE_SHARING_CLASS = "com.sglib.easymobile.androidnative.sharing.Sharing";

		[Token(Token = "0x40003C2")]
		private const string NATIVE_SHARE_TEXT_OR_URL_METHOD = "shareTextOrURL";

		[Token(Token = "0x40003C3")]
		private const string NATIVE_SHARE_IMAGE_METHOD = "shareImage";

		[Token(Token = "0x600079C")]
		[Address(RVA = "0xB5244C", Offset = "0xB5244C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EFE330]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, imagePath, message, subject, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([202279A]) = v44;\nL_001B:\n\t// 27 NewArr v49 @ X0_v3 (System.Object[]), typeof(System.Object[]), 3\n\tv52 = imagePath == 0;\n\tif (v52) goto L_0027;\n\t// 36 IsInst v94 @ X0_v22, typeof(System.Object), imagePath @ X1 (System.String)\nL_0027:\n\tv141 = v49.Length;\n\tv101 = v49.Length == 0;\n\tif (v101) goto L_006A;\n\tv49[0] = imagePath;\n\tv102 = message == 0;\n\tif (v102) goto L_0034;\n\t// 48 IsInst v194 @ X0_v20, typeof(System.Object), message @ X2 (System.String)\n\tv141 = v49.Length;\nL_0034:\n\tv205 = v141 < 1;\n\tv128 = ~v205;\n\tv125 = v141 - 1;\n\tv119 = v125 == 0;\n\tv206 = ~v128;\n\tv104 = v206 | v119;\n\tif (v104) goto L_006A;\n\tv49[1] = message;\n\tv209 = subject == 0;\n\tif (v209) goto L_004A;\n\t// 70 IsInst v195 @ X0_v18, typeof(System.Object), subject @ X3 (System.String)\n\tv141 = v49.Length;\nL_004A:\n\tv212 = v141 < 2;\n\tv129 = ~v212;\n\tv126 = v141 - 2;\n\tv120 = v126 == 0;\n\tv213 = ~v129;\n\tv105 = v213 | v120;\n\tif (v105) goto L_006A;\n\tv49[2] = subject;\n\tv167 = EasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.sharing.Sharing\", \"shareImage\", v49);\n\treturn;\nL_006A:\n\tv142 = new System.IndexOutOfRangeException();\n\tgoto L_006F;\n\tv202 = new System.ArrayTypeMismatchException();\nL_006F:\n\tthrow v208;\n\tthrow System.NullReferenceException;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShareImage(string imagePath, string message, string subject = "")
		{
			//IL_003e: Expected O, but got I4
			//IL_0176: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			//IL_01d4: Expected O, but got I
			//IL_00f8: Expected O, but got I4
			object[] array = new object[3];
			if (imagePath != null)
			{
				object obj = imagePath as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = imagePath;
				if (message != null)
				{
					object obj3 = message as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = message;
					if (subject != null)
					{
						object obj5 = subject as object;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = subject;
						string text = AndroidUtil.CallJavaStaticMethod<string>("com.sglib.easymobile.androidnative.sharing.Sharing", "shareImage", array);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600079D")]
		[Address(RVA = "0xB52570", Offset = "0xB52570", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF4230]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, text, subject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202279B]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv49 = text == 0;\n\tif (v49) goto L_0025;\n\t// 34 IsInst v91 @ X0_v19, typeof(System.Object), text @ X1 (System.String)\nL_0025:\n\tv125 = v46.Length;\n\tv98 = v46.Length == 0;\n\tif (v98) goto L_0051;\n\tv46[0] = text;\n\tv99 = subject == 0;\n\tif (v99) goto L_0032;\n\t// 46 IsInst v166 @ X0_v17, typeof(System.Object), subject @ X2 (System.String)\n\tv125 = v46.Length;\nL_0032:\n\tv174 = v125 < 1;\n\tv117 = ~v174;\n\tv115 = v125 - 1;\n\tv111 = v115 == 0;\n\tv175 = ~v117;\n\tv101 = v175 | v111;\n\tif (v101) goto L_0051;\n\tv46[1] = subject;\n\tv151 = EasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.sharing.Sharing\", \"shareTextOrURL\", v46);\n\treturn;\nL_0051:\n\tv126 = new System.IndexOutOfRangeException();\n\tgoto L_0056;\n\tv171 = new System.ArrayTypeMismatchException();\nL_0056:\n\tthrow v177;\n\tthrow System.NullReferenceException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShareText(string text, string subject = "")
		{
			//IL_003e: Expected O, but got I4
			//IL_0126: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (text != null)
			{
				object obj = text as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = text;
				if (subject != null)
				{
					object obj3 = subject as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = subject;
					string text2 = AndroidUtil.CallJavaStaticMethod<string>("com.sglib.easymobile.androidnative.sharing.Sharing", "shareTextOrURL", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600079E")]
		[Address(RVA = "0xB52668", Offset = "0xB52668", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EBE090]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, url, subject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([202279C]) = v41;\nL_0019:\n\t// 25 NewArr v46 @ X0_v3 (System.Object[]), typeof(System.Object[]), 2\n\tv49 = url == 0;\n\tif (v49) goto L_0025;\n\t// 34 IsInst v91 @ X0_v19, typeof(System.Object), url @ X1 (System.String)\nL_0025:\n\tv125 = v46.Length;\n\tv98 = v46.Length == 0;\n\tif (v98) goto L_0051;\n\tv46[0] = url;\n\tv99 = subject == 0;\n\tif (v99) goto L_0032;\n\t// 46 IsInst v166 @ X0_v17, typeof(System.Object), subject @ X2 (System.String)\n\tv125 = v46.Length;\nL_0032:\n\tv174 = v125 < 1;\n\tv117 = ~v174;\n\tv115 = v125 - 1;\n\tv111 = v115 == 0;\n\tv175 = ~v117;\n\tv101 = v175 | v111;\n\tif (v101) goto L_0051;\n\tv46[1] = subject;\n\tv151 = EasyMobile.Internal.AndroidUtil::CallJavaStaticMethod(\"com.sglib.easymobile.androidnative.sharing.Sharing\", \"shareTextOrURL\", v46);\n\treturn;\nL_0051:\n\tv126 = new System.IndexOutOfRangeException();\n\tgoto L_0056;\n\tv171 = new System.ArrayTypeMismatchException();\nL_0056:\n\tthrow v177;\n\tthrow System.NullReferenceException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShareURL(string url, string subject = "")
		{
			//IL_003e: Expected O, but got I4
			//IL_0126: Expected O, but got I
			//IL_00a8: Expected O, but got I4
			object[] array = new object[2];
			if (url != null)
			{
				object obj = url as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = url;
				if (subject != null)
				{
					object obj3 = subject as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = subject;
					string text = AndroidUtil.CallJavaStaticMethod<string>("com.sglib.easymobile.androidnative.sharing.Sharing", "shareTextOrURL", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600079F")]
		[Address(RVA = "0xB52760", Offset = "0xB52760", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidSharingClient()
		{
		}
	}
}
