using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal.NativeAPIs.Media
{
	[Token(Token = "0x20000F4")]
	internal class AndroidMediaResultBridge
	{
		[Token(Token = "0x4000459")]
		private const string NativeTypeName = "getType";

		[Token(Token = "0x400045A")]
		private const string NativeContentUriName = "getContentUri";

		[Token(Token = "0x400045B")]
		private const string NativeAbsoluteUriName = "getAbsoluteUri";

		[Token(Token = "0x400045C")]
		[FieldOffset(Offset = "0x10")]
		internal AndroidJavaObject nativeObject;

		[Token(Token = "0x17000249")]
		public MediaType Type
		{
			[Token(Token = "0x60008C1")]
			[Address(RVA = "0xC02458", Offset = "0xC02458", Length = "0x10C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F03B20]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022FAA]) = v40;\nL_0015:\n\tv42 = this.nativeObject == 0;\n\tif (v42) goto L_0060;\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv58 = v47;\n\tv59 = 0x8907BC(v58, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv62 = *([v47 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv63 = *([v47 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv64 = v63 == 0;\n\tif (v64) goto L_0045;\n\tv94 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv115 = v94;\n\tv116 = 0x8907BC(v115, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv117 = *([v94 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv104 = ~v117;\n\tif (v104) goto L_0045;\n\tgoto L_0045;\n\tv127 = v109;\n\tv128 = 0x8907BC(v127, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_0057;\n\tv118 = v111;\n\tv119 = 0x8907BC(v118, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\treturnVal2 = UnityEngine.AndroidJavaObject::Call(this.nativeObject, \"getType\", v88.Value);\n\treturn returnVal2;\nL_0060:\n\treturn 0;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (nativeObject != null)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v3 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					return (MediaType)nativeObject.Call<int>("getType", Array.Empty<object>());
				}
				return default(MediaType);
			}
		}

		[Token(Token = "0x1700024A")]
		public string ContentUri
		{
			[Token(Token = "0x60008C2")]
			[Address(RVA = "0xC02564", Offset = "0xC02564", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F034D8]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022FAB]) = v40;\nL_0015:\n\tv42 = this.nativeObject == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv53 = v47;\n\tv54 = 0x8907BC(v53, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv57 = *([v47 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv58 = *([v47 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0045;\n\tv87 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv107 = v87;\n\tv108 = 0x8907BC(v107, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv109 = *([v87 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv97 = ~v109;\n\tif (v97) goto L_0045;\n\tgoto L_0045;\n\tv119 = v102;\n\tv120 = 0x8907BC(v119, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_0051;\n\tv110 = v80;\n\tv111 = 0x8907BC(v110, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.nativeObject, \"getContentUri\", v78.Value);\n\tgoto L_005A;\nL_005A:\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (nativeObject != null)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					return nativeObject.Call<string>("getContentUri", Array.Empty<object>());
				}
				return null;
			}
		}

		[Token(Token = "0x1700024B")]
		public string AbsoluteUri
		{
			[Token(Token = "0x60008C3")]
			[Address(RVA = "0xC02668", Offset = "0xC02668", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF8750]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022FAC]) = v40;\nL_0015:\n\tv42 = this.nativeObject == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tv47 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0024;\n\tv53 = v47;\n\tv54 = 0x8907BC(v53, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv57 = *([v47 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]);\nL_0024:\n\tv58 = *([v47 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0045;\n\tv87 = Il2CppClass<System.EmptyArray`1<System.Object>>;\n\tgoto L_0031;\n\tv107 = v87;\n\tv108 = 0x8907BC(v107, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0031:\n\tv109 = *([v87 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]) == 0;\n\tv97 = ~v109;\n\tif (v97) goto L_0045;\n\tgoto L_0045;\n\tv119 = v102;\n\tv120 = 0x8907BC(v119, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tgoto L_0051;\n\tv110 = v80;\n\tv111 = 0x8907BC(v110, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\treturnVal1 = UnityEngine.AndroidJavaObject::Call(this.nativeObject, \"getAbsoluteUri\", v78.Value);\n\tgoto L_005A;\nL_005A:\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (nativeObject != null)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X20_v4 (Il2CppClass<System.EmptyArray`1<System.Object>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X20_v7 (Il2CppClass<System.EmptyArray`1<System.Object>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					return nativeObject.Call<string>("getAbsoluteUri", Array.Empty<object>());
				}
				return null;
			}
		}

		[Token(Token = "0x60008C4")]
		[Address(RVA = "0xC0238C", Offset = "0xC0238C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.nativeObject = nativeObject;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AndroidMediaResultBridge(AndroidJavaObject nativeObject)
		{
			this.nativeObject = nativeObject;
		}

		[Token(Token = "0x60008C5")]
		[Address(RVA = "0xC023B8", Offset = "0xC023B8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0B670]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022FAD]) = v42;\nL_0015:\n\tv43 = result == 0;\n\tif (v43) goto L_0033;\n\tv45 = EasyMobile.Internal.NativeAPIs.Media.AndroidMediaResultBridge::get_Type(result);\n\tv74 = EasyMobile.Internal.NativeAPIs.Media.AndroidMediaResultBridge::get_ContentUri(result);\n\tv76 = EasyMobile.Internal.NativeAPIs.Media.AndroidMediaResultBridge::get_AbsoluteUri(result);\n\tv59 = new EasyMobile.MediaResult();\n\tEasyMobile.MediaResult::.ctor(v59, v45, v74, v76);\nL_0033:\n\treturn v60;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static explicit operator MediaResult(AndroidMediaResultBridge result)
		{
			bool flag = result == null;
			AndroidMediaResultBridge result2 = result;
			if (!flag)
			{
				MediaType type = result.Type;
				string contentUri = result.ContentUri;
				string absoluteUri = result.AbsoluteUri;
				MediaResult mediaResult = new MediaResult(type, contentUri, absoluteUri);
				result2 = (AndroidMediaResultBridge)(object)mediaResult;
			}
			return (MediaResult)result2;
		}
	}
}
