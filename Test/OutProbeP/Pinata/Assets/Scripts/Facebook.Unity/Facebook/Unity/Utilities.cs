using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;

namespace Facebook.Unity
{
	[Token(Token = "0x200003C")]
	internal static class Utilities
	{
		[Token(Token = "0x200003D")]
		public delegate void Callback<T>(T obj);

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200003E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000070")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000071")]
			public static Func<object, string> _003C_003E9__18_0;

			[Token(Token = "0x600015A")]
			[Address(RVA = "0xD34DF8", Offset = "0xD34DF8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1F00F88]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023CA9]) = v37;\nL_0015:\n\tv41 = new Facebook.Unity.Utilities+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600015B")]
			[Address(RVA = "0xD34E5C", Offset = "0xD34E5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal string _003CParsePermissionFromResult_003Eb__18_0(object permission)
			{
				//IL_0071: Expected O, but got I4
				//IL_0025: Expected I, but got O
				//IL_0035: Expected O, but got I
				//IL_0045: Expected O, but got I
				if (permission != null)
				{
					IntPtr intPtr = (IntPtr)permission;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+160]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+168]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
				}
				NullReferenceException ex = new NullReferenceException();
				IntPtr intPtr2 = default(IntPtr);
				int count = default(int);
				return (string)((System.Xml.Ucs4Decoder)(object)ex).GetCharCount((byte[])permission, (int)(long)intPtr2, count);
			}
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0x11B97D8", Offset = "0x11B97D8", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1F0B508]);\n\tv31 = *([v30 @ X8_v18]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, key, value, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2027B16]) = v47;\nL_001D:\n\tv51 = dictionary->klass;\n\tv55 = *([v51 @ X8_v4 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v55) goto L_0040;\n\tv163 = *([v51 @ X8_v4 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_002B:\n\tv169 = *([v163 @ X11_v6-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v169) goto L_0043;\n\tv164 = v164 + 1;\n\tv174 = v164 < *([v51 @ X8_v4 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv89 = ~v174;\n\tv163 = v163 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_002B;\nL_0040:\n\tv181 = 0x8909C4(dictionary, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 6, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_004C;\nL_0043:\n\tv176 = *([v163 @ X11_v6]) + 6;\n\tv177 = v176 << 4;\n\tv178 = v51 + v177;\n\tv181 = v178 + 0x130;\nL_004C:\n\t*([v181 @ X0_v7])(v186, dictionary, key, &v104 @ stack_-38_v3, *([v181 @ X0_v7+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv187 = v186 & 1;\n\tv188 = v187 == 0;\n\tif (v188) goto L_0075;\n\tgoto L_005C;\n\tv249 = v230;\n\tv250 = 0x8907BC(v249, v185, v109, v100, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_005C:\n\t// 92 IsInst v240 @ X0_v15, typeof(T), v104 @ stack_-38_v3\n\tv243 = v240 == 0;\n\tif (v243) goto L_0075;\n\tgoto L_0069;\n\tv263 = v143;\n\tv264 = 0x8907BC(v263, v237, v109, v100, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0069:\n\tv266 = v104 == 0;\n\tif (v266) goto L_FFFFFFFF;\n\t// 109 IsInst v273 @ X0_v17 (System.Int32), typeof(T), v104 @ stack_-38_v3\n\tv271 = v273 == 0;\n\tv242 = ~v271;\n\tif (v242) goto L_0078;\n\tthrow System.InvalidCastException;\nL_0075:\n\t*([value @ X2 (T&)]) = 0;\n\tgoto L_0092;\nL_0078:\n\t*([value @ X2 (T&)]) = v273;\n\tgoto L_0082;\n\tv280 = v147;\n\tv281 = 0x8907BC(v280, v272, v109, v100, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0082:\n\tv283 = v104 == 0;\n\tif (v283) goto L_FFFFFFFF;\n\t// 134 IsInst v139 @ X0_v22, typeof(T), v104 @ stack_-38_v3\n\tv141 = v139 == 0;\n\tif (v141) goto L_0097;\nL_0092:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\nL_0097:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T value)
		{
			//IL_0017: Expected I, but got O
			//IL_0052: Expected O, but got I
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00f6: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_009e: Expected O, but got I
			//IL_0168: Expected I4, but got O
			//IL_021e: Expected I4, but got O
			value = default(T);
			IntPtr intPtr = (IntPtr)dictionary;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v4 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v4 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v4 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b7;
			}
			object obj2 = obj + 6;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0248;
			IL_00b7:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0248;
			IL_0248:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v181 @ X0_v7] (should have been resolved before IL gen)");
			object obj5 = default(object);
			ref T reference;
			if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
			{
				object obj7 = default(object);
				object obj6 = ((obj7 is T) ? obj7 : null);
				if (obj6 != null)
				{
					int num4;
					if (obj7 != null)
					{
						num4 = (int)((obj7 is T) ? obj7 : null);
						if (num4 == 0)
						{
							throw new InvalidCastException();
						}
					}
					else
					{
						num4 = 0;
					}
					reference = ref *(T*)num4;
					if (obj7 != null)
					{
						object obj8 = ((obj7 is T) ? obj7 : null);
						if (obj8 == null)
						{
							InvalidCastException ex = new InvalidCastException();
							return (byte)(int)ex != 0;
						}
					}
					return true;
				}
			}
			reference = ref *(T*)null;
			return false;
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0xD1B44C", Offset = "0xD1B44C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1ECDFB0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C9E]) = v38;\nL_001B:\n\tv40 = 0;\n\tdateTime = 0xE93B78(&v40 @ stack_-30_v1 (System.DateTime), 0x7B2, 1, 1, 0, 0, 0, 1, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_002E;\n\tv57 = *([v53 @ X0_v4+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002E;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, v41, v42, v43, v45, v46, v47, v44, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tv67 = System.DateTime::op_Subtraction(dateTime, 0);\n\tdateTime = 0x9BD218(&v67 @ X0_v7 (System.TimeSpan), 0, 0, 1, 0, 0, 0, 1, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn v28;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static long TotalSeconds(this DateTime dateTime)
		{
			DateTime dateTime2 = default(DateTime);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93B78 (inside System.DateTime::TimeToTicks +0xF0)");
			TimeSpan timeSpan = dateTime - default(DateTime);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD218 (inside System.TimeSpan::TimeToTicks +0x298)");
			long result = default(long);
			return result;
		}

		[Token(Token = "0x6000149")]
		[Address(RVA = "0xB88668", Offset = "0xB88668", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1F09DF8]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, key, logWarning, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022A02]) = v47;\nL_0020:\n\tv56 = Facebook.Unity.Utilities::TryGetValue(dictionary, key, &v51 @ stack_-38_v2 (T));\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0057;\n\tv61 = logWarning == 0;\n\tif (v61) goto L_0057;\n\t// 44 NewArr v86 @ X0_v7 (System.String[]), typeof(System.String[]), 1\n\tv105 = key == 0;\n\tif (v105) goto L_0039;\n\t// 53 IsInst v110 @ X0_v19, typeof(System.String), key @ X1 (System.String)\nL_0039:\n\tv117 = v86.Length == 0;\n\tif (v117) goto L_0059;\n\tv86[0] = key;\n\tgoto L_004D;\n\tv130 = *([v125 @ X0_v14+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_004D;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v125, v111, v50, v54, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004D:\n\tFacebook.Unity.FacebookLogger::Warn(\"Did not find expected value '{0}' in dictionary\", v86);\nL_0057:\n\treturn v51;\n\tv106 = new System.NullReferenceException();\nL_0059:\n\tv122 = new System.IndexOutOfRangeException();\n\tgoto L_005E;\n\tv129 = new System.ArrayTypeMismatchException();\nL_005E:\n\tthrow v138;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T GetValueOrDefault<T>(this IDictionary<string, object> dictionary, string key, bool logWarning = true)
		{
			if (!dictionary.TryGetValue<T>(key, out var value) && logWarning)
			{
				string[] array = new string[1];
				if (key != null)
				{
					object obj = key as string;
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					throw ex2;
				}
				array[0] = key;
				FacebookLogger.Warn("Did not find expected value '{0}' in dictionary", array);
			}
			return value;
		}

		[Token(Token = "0x600014A")]
		[Address(RVA = "0xD1B504", Offset = "0xD1B504", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC7520]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C9F]) = v38;\nL_0013:\n\tv39 = list == 0;\n\tif (v39) goto L_0031;\n\tv44 = System.Linq.Enumerable::ToArray(list);\n\treturnVal2 = System.String::Join(\",\", v44);\n\treturn returnVal2;\nL_0031:\n\treturn v50.Empty;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToCommaSeparateList(this IEnumerable<string> list)
		{
			if (list != null)
			{
				string[] value = list.ToArray();
				return string.Join(",", value);
			}
			return string.Empty;
		}

		[Token(Token = "0x600014B")]
		[Address(RVA = "0xD32B58", Offset = "0xD32B58", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC3890]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023CA0]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv55 = System.Uri::op_Equality(uri, 0);\n\tv57 = v55 == 0;\n\tif (v57) goto L_003A;\n\treturn v63.Empty;\nL_003A:\n\treturnVal2 = System.Uri::get_AbsoluteUri(uri);\n\treturn returnVal2;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string AbsoluteUrlOrEmptyString(this Uri uri)
		{
			if (uri == null)
			{
				return string.Empty;
			}
			return uri.AbsoluteUri;
		}

		[Token(Token = "0x600014C")]
		[Address(RVA = "0xD1E340", Offset = "0xD1E340", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF8628]);\n\tv25 = *([v24 @ X8_v25]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, productVersion, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023CA1]) = v43;\nL_001C:\n\tgoto L_0023;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0023;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, productVersion, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0023:\n\tv58 = System.Globalization.CultureInfo::get_InvariantCulture();\n\t// 42 NewArr v65 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\tv68 = productName == 0;\n\tif (v68) goto L_0036;\n\t// 51 IsInst v110 @ X0_v23, typeof(System.Object), productName @ X0 (System.String)\nL_0036:\n\tv144 = v65.Length;\n\tv117 = v65.Length == 0;\n\tif (v117) goto L_005F;\n\tv65[0] = productName;\n\tv118 = productVersion == 0;\n\tif (v118) goto L_0043;\n\t// 63 IsInst v181 @ X0_v21, typeof(System.Object), productVersion @ X1 (System.String)\n\tv144 = v65.Length;\nL_0043:\n\tv189 = v144 < 1;\n\tv136 = ~v189;\n\tv134 = v144 - 1;\n\tv130 = v134 == 0;\n\tv190 = ~v136;\n\tv120 = v190 | v130;\n\tif (v120) goto L_005F;\n\tv65[1] = productVersion;\n\treturnVal2 = System.String::Format(v58, \"{0}/{1}\", v65);\n\treturn returnVal2;\nL_005F:\n\tv145 = new System.IndexOutOfRangeException();\n\tgoto L_0064;\n\tv186 = new System.ArrayTypeMismatchException();\nL_0064:\n\tthrow v192;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetUserAgent(string productName, string productVersion)
		{
			//IL_005a: Expected O, but got I4
			//IL_0137: Expected O, but got I
			//IL_00c4: Expected O, but got I4
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			object[] array = new object[2];
			if (productName != null)
			{
				object obj = productName as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = productName;
				if (productVersion != null)
				{
					object obj3 = productVersion as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = productVersion;
					return string.Format(invariantCulture, "{0}/{1}", array);
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600014D")]
		[Address(RVA = "0xD1C324", Offset = "0xD1C324", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB10F8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023CA2]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\treturnVal1 = Facebook.MiniJSON.Json+Serializer::Serialize(dictionary);\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToJson(this IDictionary<string, object> dictionary)
		{
			return Json.Serializer.Serialize(dictionary);
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xBB3928", Offset = "0xBB3928", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF5160]);\n\tv35 = *([v34 @ X8_v50]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, source, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022C57]) = v52;\nL_001B:\n\tv53 = source == 0;\n\tif (v53) goto L_0172;\n\tgoto L_0026;\n\tv125 = v55;\n\tv126 = 0x8907BC(v125, source, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0026:\n\tv128 = source->klass;\n\tv130 = *([v128 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]) == 0;\n\tif (v130) goto L_FFFFFFFF;\n\tv219 = *([v128 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+B0]) + 8;\nL_0032:\n\tv224 = *([v219 @ X11_v48-8]) == Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>;\n\tif (v224) goto L_004B;\n\tv218 = v218 + 1;\n\tv239 = v218 < *([v128 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]);\n\tv199 = ~v239;\n\tv219 = v219 + 0x10;\n\tv183 = ~v199;\n\tif (v183) goto L_0032;\n\tgoto L_0050;\nL_004B:\n\tv241 = *([v219 @ X11_v48]) + 2;\n\tv242 = v241 << 4;\n\tv243 = v128 + v242;\n\tv246 = v243 + 0x130;\nL_0050:\n\tv264 = *([v246 @ X0_v21+8]);\n\tv169 = System.Collections.Generic.IDictionary`2<T1, T2>::get_Keys(source);\n\tv171 = v169 == 0;\n\tif (v171) goto L_0172;\n\tgoto L_005F;\n\tv313 = v306;\n\tv314 = 0x8907BC(v313, v141, v143, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005F:\n\tv316 = *([v169 @ X0_v23 (System.Collections.IEnumerator)]);\n\tv318 = *([v316 @ X8_v19 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v318) goto L_0082;\n\tv488 = *([v316 @ X8_v19 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_006B:\n\tv493 = *([v488 @ X11_v43-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<T1>>;\n\tif (v493) goto L_0084;\n\tv487 = v487 + 1;\n\tv529 = v487 < *([v316 @ X8_v19 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv387 = ~v529;\n\tv488 = v488 + 0x10;\n\tv371 = ~v387;\n\tif (v371) goto L_006B;\nL_0082:\n\tgoto L_008A;\nL_0084:\n\t;\nL_008A:\n\tv555 = System.Collections.Generic.IEnumerable`1<T1>::GetEnumerator(v169);\nL_0094:\n\tgoto L_00BB;\n\tv636 = *([v630 @ X8_v24+B0]);\n\tv637 = 0;\n\tv638 = v636 + 8;\n\tv640 = *([v698 @ X11_v38-8]);\n\tv703 = v640 == v631;\n\tif (v703) goto L_00B4;\n\tv660 = v697 + 1;\n\tv708 = v660 < v632;\n\tv658 = ~v708;\n\tv662 = v698 + 0x10;\n\tv642 = ~v658;\n\tif (v642) goto L_FFFFFFFF;\n\tv663 = v123;\n\tv664 = 0;\n\tv665 = 0x8909C4(v663, v631, v664, v61, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00BB;\nL_00B4:\n\tv709 = *([v698 @ X11_v38]);\n\tv710 = v709 << 4;\n\tv711 = v630 + v710;\n\tv712 = v711 + 0x130;\nL_00BB:\n\tv436 = System.Collections.IEnumerator::MoveNext(v555);\n\tv717 = v436 == 0;\n\tif (v717) goto L_0169;\n\tgoto L_00C8;\n\tv725 = v719;\n\tv726 = 0x8907BC(v725, v408, v410, v61, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00C8:\n\tv728 = *([v555 @ X0_v27 (System.Collections.IEnumerator)]);\n\tv730 = *([v728 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v730) goto L_FFFFFFFF;\n\tv773 = *([v728 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00D4:\n\tv778 = *([v773 @ X11_v33-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T1>>;\n\tif (v778) goto L_00ED;\n\tv772 = v772 + 1;\n\tv783 = v772 < *([v728 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv753 = ~v783;\n\tv773 = v773 + 0x10;\n\tv737 = ~v753;\n\tif (v737) goto L_00D4;\n\tgoto L_00F3;\nL_00ED:\n\t;\nL_00F3:\n\tv809 = System.Collections.Generic.IEnumerator`1<T1>::get_Current(v555);\n\tgoto L_00FE;\n\tv816 = v811;\n\tv817 = 0x8907BC(v816, v807, v791, v61, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00FE:\n\tv819 = source->klass;\n\tv821 = *([v819 @ X8_v34 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]) == 0;\n\tif (v821) goto L_FFFFFFFF;\n\tv864 = *([v819 @ X8_v34 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+B0]) + 8;\nL_010A:\n\tv869 = *([v864 @ X11_v28-8]) == Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>;\n\tif (v869) goto L_0123;\n\tv863 = v863 + 1;\n\tv874 = v863 < *([v819 @ X8_v34 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]);\n\tv844 = ~v874;\n\tv864 = v864 + 0x10;\n\tv828 = ~v844;\n\tif (v828) goto L_010A;\n\tgoto L_012A;\nL_0123:\n\t;\nL_012A:\n\tv683 = System.Collections.Generic.IDictionary`2<T1, T2>::get_Item(source, v809);\n\tgoto L_0137;\n\tv889 = v583;\n\tv890 = 0x8907BC(v889, v668, v669, v61, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0137:\n\tv892 = dest->klass;\n\tv618 = *([v892 @ X8_v39 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]) == 0;\n\tif (v618) goto L_FFFFFFFF;\n\tv936 = *([v892 @ X8_v39 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+B0]) + 8;\nL_0143:\n\tv941 = *([v936 @ X11_v23-8]) == Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>;\n\tif (v941) goto L_015C;\n\tv935 = v935 + 1;\n\tv946 = v935 < *([v892 @ X8_v39 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]);\n\tv916 = ~v946;\n\tv936 = v936 + 0x10;\n\tv900 = ~v916;\n\tif (v900) goto L_0143;\n\tgoto L_0161;\nL_015C:\n\tv948 = *([v936 @ X11_v23]) + 1;\n\tv949 = v948 << 4;\n\tv950 = v892 + v949;\n\tv954 = v950 + 0x130;\nL_0161:\n\tv396 = *([v954 @ X0_v46+8]);\n\tv616 = System.Collections.Generic.IDictionary`2<T1, T2>::set_Item(dest, v809, v683);\n\tgoto L_0094;\nL_0169:\n\tv724 = v555 == 0;\n\tv438 = ~v724;\n\tif (v438) goto L_018F;\n\tgoto L_01B7;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0172:\n\tv176 = new System.NullReferenceException();\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\nL_0181:\n\tv238 = v264 != 1;\n\tif (v238) goto L_01D1;\n\tv249 = 0x6D2BC0(v176, v264, v266, v396, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv441 = *([v249 @ X0_v4]);\n\tv312 = 0x6D2490(v249, v264, v266, v396, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv320 = v174 == 0;\n\tif (v320) goto L_01B7;\nL_018F:\n\tgoto L_01B6;\n\tv498 = *([v447 @ X8_v7+B0]);\n\tv499 = 0;\n\tv500 = v498 + 8;\n\tv502 = *([v568 @ X11_v9-8]);\n\tv573 = v502 == v450;\n\tif (v573) goto L_01AF;\n\tv522 = v567 + 1;\n\tv622 = v522 < v449;\n\tv520 = ~v622;\n\tv524 = v568 + 0x10;\n\tv504 = ~v520;\n\tif (v504) goto L_FFFFFFFF;\n\tv525 = v445;\n\tv526 = 0;\n\tv527 = 0x8909C4(v525, v450, v526, v396, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_01B6;\nL_01AF:\n\tv623 = *([v568 @ X11_v9]);\n\tv624 = v623 << 4;\n\tv625 = v447 + v624;\n\tv626 = v625 + 0x130;\nL_01B6:\n\tSystem.IDisposable::Dispose(v445);\nL_01B7:\n\tv476 = v297 + 1;\n\tv279 = v476 == 0;\n\tv269 = ~v279;\n\tif (v269) goto L_01CC;\n\tv528 = v299 == 0;\n\tv295 = ~v528;\n\tif (v295) goto L_01D0;\nL_01CC:\n\treturn;\nL_01D0:\n\tv293 = new System.TypeLoadException();\nL_01D1:\n\tv304 = 0x6D2380(v176, v264, v266, v396, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\treturn;\n// 282 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddAllKVPFrom<T1, T2>(this IDictionary<T1, T2> dest, IDictionary<T1, T2> source)
		{
			//IL_0012: Expected I, but got O
			//IL_04c8: Expected I4, but got O
			//IL_0515: Expected I4, but got O
			//IL_05e0: Expected O, but got I
			//IL_004d: Expected O, but got I
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ce: Expected O, but got Unknown
			//IL_00eb: Expected O, but got I
			//IL_00fa: Expected O, but got I
			//IL_0114: Expected I, but got O
			//IL_0099: Expected O, but got I
			//IL_056c: Expected I, but got O
			//IL_014f: Expected O, but got I
			//IL_019b: Expected O, but got I
			//IL_01d3: Expected I, but got O
			//IL_020e: Expected O, but got I
			//IL_0289: Expected I, but got O
			//IL_02c4: Expected O, but got I
			//IL_025a: Expected O, but got I
			//IL_0344: Expected I, but got O
			//IL_0310: Expected O, but got I
			//IL_071e: Expected O, but got I
			//IL_037f: Expected O, but got I
			//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_03ff: Expected O, but got Unknown
			//IL_041c: Expected O, but got I
			//IL_042b: Expected O, but got I
			//IL_03cb: Expected O, but got I
			bool flag = source == null;
			IEnumerator enumerator2 = default(IEnumerator);
			IEnumerator enumerator = enumerator2;
			IntPtr intPtr2;
			if (!flag)
			{
				IntPtr intPtr = (IntPtr)source;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00b2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X11_v48-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X8_v14 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_00b2;
				}
				object obj2 = obj + 2;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				IntPtr intPtr3 = default(IntPtr);
				intPtr2 = intPtr3;
				goto IL_05d0;
			}
			goto IL_0790;
			IL_05d0:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X0_v21+8]");
			IDictionary<T1, T2> dictionary = (IDictionary<T1, T2>)0;
			IEnumerator keys = (IEnumerator)source.Keys;
			bool flag4 = keys == null;
			object obj6 = default(object);
			object obj5 = obj6;
			enumerator = keys;
			int num13;
			int num14;
			IDisposable disposable;
			object obj15;
			int num15;
			int num16;
			if (!flag4)
			{
				IntPtr intPtr4 = (IntPtr)keys;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X8_v19 (Il2CppClass<System.Collections.IEnumerator>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X8_v19 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj7 = 0L + 8L;
					int num4 = 0;
					bool flag6;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X11_v43-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num4++;
							int num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v316 @ X8_v19 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag5 = (long)num5 < 0L;
							flag6 = !flag5;
							obj7 = (long)(IntPtr)obj7 + 16L;
							continue;
						}
						break;
					}
					while (!flag6);
				}
				enumerator2 = ((IEnumerable<T1>)keys).GetEnumerator();
				object current;
				object value;
				object obj14 = default(object);
				for (obj5 = obj6; enumerator2.MoveNext(); Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v954 @ X0_v46+8]"), obj5 = 0, dest.set_Item((T1)current, (T2)value))
				{
					IntPtr intPtr5 = (IntPtr)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj8 = 0L + 8L;
						int num6 = 0;
						bool flag8;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v773 @ X11_v33-8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								num6++;
								int num7 = num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ X8_v29 (Il2CppClass<System.Collections.IEnumerator>)+126]");
								bool flag7 = (long)num7 < 0L;
								flag8 = !flag7;
								obj8 = (long)(IntPtr)obj8 + 16L;
								continue;
							}
							break;
						}
						while (!flag8);
					}
					current = ((IEnumerator<T1>)enumerator2).Current;
					IntPtr intPtr6 = (IntPtr)source;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ X8_v34 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ X8_v34 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+B0]");
						object obj9 = 0L + 8L;
						int num8 = 0;
						bool flag10;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v864 @ X11_v28-8]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								num8++;
								int num9 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ X8_v34 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]");
								bool flag9 = (long)num9 < 0L;
								flag10 = !flag9;
								obj9 = (long)(IntPtr)obj9 + 16L;
								continue;
							}
							break;
						}
						while (!flag10);
					}
					value = source.get_Item((T1)current);
					IntPtr intPtr7 = (IntPtr)dest;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v39 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]");
					object obj13;
					if ((IntPtr)0 != (IntPtr)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v39 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+B0]");
						object obj10 = 0L + 8L;
						int num10 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v936 @ X11_v23-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num10++;
							int num11 = num10;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v892 @ X8_v39 (Il2CppClass<System.Collections.Generic.IDictionary`2<T1, T2>>)+126]");
							bool flag11 = (long)num11 < 0L;
							bool flag12 = !flag11;
							obj10 = (long)(IntPtr)obj10 + 16L;
							if (!flag12)
							{
								continue;
							}
							goto IL_03e4;
						}
						object obj11 = obj10 + 1;
						int num12 = (int)((long)(IntPtr)obj11 << 4);
						object obj12 = (long)intPtr7 + (long)num12;
						obj13 = (long)(IntPtr)obj12 + 304L;
						continue;
					}
					goto IL_03e4;
					IL_03e4:
					obj13 = obj14;
				}
				bool flag13 = enumerator2 == null;
				bool flag14 = !flag13;
				num13 = 0;
				num14 = 0;
				disposable = (IDisposable)enumerator2;
				if (!flag14)
				{
					obj15 = obj5;
					num15 = 0;
					num16 = 0;
					goto IL_0734;
				}
				goto IL_076a;
			}
			goto IL_0790;
			IL_0790:
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)dictionary != (IntPtr)1)
			{
				goto IL_0579;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj16 = default(object);
			num14 = (int)obj16;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			bool flag15 = enumerator == null;
			num13 = -1;
			disposable = (IDisposable)enumerator;
			obj15 = obj5;
			num15 = -1;
			num16 = (int)obj16;
			if (flag15)
			{
				goto IL_0734;
			}
			goto IL_076a;
			IL_076a:
			disposable.Dispose();
			obj15 = obj5;
			num15 = num13;
			num16 = num14;
			goto IL_0734;
			IL_0579:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_0734:
			if (num15 + 1 != 0 || num16 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			obj5 = obj15;
			dictionary = null;
			intPtr2 = (IntPtr)null;
			ex = (NullReferenceException)(object)ex2;
			goto IL_0579;
			IL_00b2:
			intPtr2 = (IntPtr)2;
			goto IL_05d0;
		}

		[Token(Token = "0x600014F")]
		[Address(RVA = "0xD1BCC0", Offset = "0xD1BCC0", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1ED9220]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023CA3]) = v48;\nL_001E:\n\tgoto L_002C;\n\tv55 = *([v51 @ X0_v2 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002C;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv59 = Facebook.Unity.LoginResult;\nL_002C:\n\tv69 = Facebook.Unity.Utilities::GetValueOrDefault(resultDictionary, v63.UserIdKey, 1);\n\tv78 = Facebook.Unity.Utilities::GetValueOrDefault(resultDictionary, v75.AccessTokenKey, 1);\n\tv81 = Facebook.Unity.Utilities::ParseExpirationDateFromResult(resultDictionary);\n\tv84 = Facebook.Unity.Utilities::ParsePermissionFromResult(resultDictionary);\n\tv87 = Facebook.Unity.Utilities::ParseLastRefreshFromResult(resultDictionary);\n\tv93 = new Facebook.Unity.AccessToken();\n\tFacebook.Unity.AccessToken::.ctor(v93, v78, v69, v81, v84, v87);\n\treturn v93;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AccessToken ParseAccessTokenFromResult(IDictionary<string, object> resultDictionary)
		{
			string valueOrDefault = resultDictionary.GetValueOrDefault<string>(LoginResult.UserIdKey);
			string valueOrDefault2 = resultDictionary.GetValueOrDefault<string>(LoginResult.AccessTokenKey);
			DateTime expirationTime = ParseExpirationDateFromResult(resultDictionary);
			ICollection<string> permissions = ParsePermissionFromResult(resultDictionary);
			DateTime? lastRefresh = ParseLastRefreshFromResult(resultDictionary);
			return new AccessToken(valueOrDefault2, valueOrDefault, expirationTime, permissions, lastRefresh);
		}

		[Token(Token = "0x6000150")]
		[Address(RVA = "0xD1B594", Offset = "0xD1B594", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F07CE8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023CA4]) = v38;\nL_0013:\n\tv39 = obj == 0;\n\tif (v39) goto L_0027;\n\tv40 = obj->klass;\n\tv44 = obj->klass->vtable[3];\n\tv45 = obj->klass->vtable[3];\n\t// 30 IndirectJump v44 @ X2_v1, obj @ X0 (System.Object), obj @ X0 (System.Object), v45 @ X1_v1, v44 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_0027:\n\treturn \"null\";\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToStringNullOk(this object obj)
		{
			//IL_000d: Expected I, but got O
			//IL_001d: Expected O, but got I
			//IL_002d: Expected O, but got I
			if (obj != null)
			{
				IntPtr intPtr = (IntPtr)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v5 (Il2CppClass<System.Object>)+160]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v5 (Il2CppClass<System.Object>)+168]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v44 @ X2_v1 (should have been resolved before IL gen)");
			}
			return "null";
		}

		[Token(Token = "0x6000151")]
		[Address(RVA = "0xD1B5FC", Offset = "0xD1B5FC", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F108E8]);\n\tv31 = *([v30 @ X8_v32]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, className, propertiesAndValues, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023CA5]) = v48;\nL_001C:\n\tv52 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v52);\n\tv55 = baseString == 0;\n\tif (v55) goto L_0029;\n\tv56 = v52 == 0;\n\tif (v56) goto L_00E8;\n\tv61 = System.Text.StringBuilder::Append(v52, baseString);\n\tgoto L_0031;\nL_0029:\n\tv57 = v52 == 0;\n\tif (v57) goto L_00E8;\nL_0031:\n\tv124 = System.Text.StringBuilder::AppendFormat(v52, \"\\n{0}:\", className);\n\tv127 = propertiesAndValues == 0;\n\tif (v127) goto L_00E8;\n\tgoto L_0061;\n\tv217 = *([v156 @ X8_v16+B0]);\n\tv218 = 0;\n\tv219 = v217 + 8;\n\tv221 = *([v259 @ X11_v28-8]);\n\tv265 = v221 == v159;\n\tif (v265) goto L_005A;\n\tv243 = v260 + 1;\n\tv315 = v243 < v158;\n\tv239 = ~v315;\n\tv241 = v259 + 0x10;\n\tv223 = ~v239;\n\tif (v223) goto L_FFFFFFFF;\n\tv244 = v20;\n\tv245 = 0;\n\tv246 = 0x8909C4(v244, v159, v245, v115, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0061;\nL_005A:\n\tv316 = *([v259 @ X11_v28]);\n\tv317 = v316 << 4;\n\tv318 = v156 + v317;\n\tv319 = v318 + 0x130;\nL_0061:\n\tv340 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::GetEnumerator(propertiesAndValues);\nL_0071:\n\tgoto L_0098;\n\tv509 = *([v482 @ X8_v20+B0]);\n\tv510 = 0;\n\tv511 = v509 + 8;\n\tv513 = *([v557 @ X11_v23-8]);\n\tv563 = v513 == v483;\n\tif (v563) goto L_0091;\n\tv535 = v558 + 1;\n\tv568 = v535 < v484;\n\tv531 = ~v568;\n\tv533 = v557 + 0x10;\n\tv515 = ~v531;\n\tif (v515) goto L_FFFFFFFF;\n\tv536 = v133;\n\tv537 = 0;\n\tv538 = 0x8909C4(v536, v483, v537, v114, v63, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0098;\nL_0091:\n\tv569 = *([v557 @ X11_v23]);\n\tv570 = v569 << 4;\n\tv571 = v482 + v570;\n\tv572 = v571 + 0x130;\nL_0098:\n\tv383 = System.Collections.IEnumerator::MoveNext(v340);\n\tv577 = v383 == 0;\n\tif (v577) goto L_00E1;\n\tgoto L_00C7;\n\tv582 = *([v578 @ X8_v23+B0]);\n\tv583 = 0;\n\tv584 = v582 + 8;\n\tv586 = *([v622 @ X11_v18-8]);\n\tv628 = v586 == v579;\n\tif (v628) goto L_00C0;\n\tv608 = v623 + 1;\n\tv633 = v608 < v580;\n\tv604 = ~v633;\n\tv606 = v622 + 0x10;\n\tv588 = ~v604;\n\tif (v588) goto L_FFFFFFFF;\n\tv609 = v133;\n\tv610 = 0;\n\tv611 = 0x8909C4(v609, v579, v610, v114, v63, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00C7;\nL_00C0:\n\tv634 = *([v622 @ X11_v18]);\n\tv635 = v634 << 4;\n\tv636 = v578 + v635;\n\tv637 = v636 + 0x130;\nL_00C7:\n\tv653 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<System.String, System.String>>::get_Current(v340);\n\tgoto L_FFFFFFFF;\n\tgoto L_00DD;\nL_00DD:\n\tv447 = System.Text.StringBuilder::AppendFormat(v52, \"\\n\\t{0}: {1}\", v653, v114);\n\tgoto L_0071;\nL_00E1:\n\tv581 = v340 == 0;\n\tv385 = ~v581;\n\tif (v385) goto L_0103;\n\tgoto L_012B;\n\tthrow System.NullReferenceException;\nL_00E8:\n\tv138 = new System.NullReferenceException();\n\tgoto L_00F5;\n\tgoto L_00F5;\n\tgoto L_00F5;\nL_00F5:\n\tv154 = v202 != 1;\n\tif (v154) goto L_0147;\n\tv161 = 0x6D2BC0(v138, v202, v200, v377, v345, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv388 = *([v161 @ X0_v20]);\n\tv248 = 0x6D2490(v161, v202, v200, v377, v345, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv271 = v132 == 0;\n\tif (v271) goto L_012B;\nL_0103:\n\tgoto L_012A;\n\tv451 = *([v394 @ X8_v9+B0]);\n\tv452 = 0;\n\tv453 = v451 + 8;\n\tv455 = *([v497 @ X11_v8-8]);\n\tv503 = v455 == v397;\n\tif (v503) goto L_0123;\n\tv477 = v498 + 1;\n\tv539 = v477 < v396;\n\tv473 = ~v539;\n\tv475 = v497 + 0x10;\n\tv457 = ~v473;\n\tif (v457) goto L_FFFFFFFF;\n\tv478 = v390;\n\tv479 = 0;\n\tv480 = 0x8909C4(v478, v397, v479, v377, v345, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_012A;\nL_0123:\n\tv540 = *([v497 @ X11_v8]);\n\tv541 = v540 << 4;\n\tv542 = v394 + v541;\n\tv543 = v542 + 0x130;\nL_012A:\n\tSystem.IDisposable::Dispose(v390);\nL_012B:\n\tv426 = v209 + 1;\n\tv185 = v426 == 0;\n\tv175 = ~v185;\n\tif (v175) goto L_0135;\n\tv481 = v211 == 0;\n\tv207 = ~v481;\n\tif (v207) goto L_0146;\nL_0135:\n\tv310 = *([v52 @ X0_v3 (System.Text.StringBuilder)]);\n\tv296 = *([v310 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+160]);\n\tv298 = *([v310 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+168]);\n\t// 322 IndirectJump v296 @ X2_v2, v52 @ X0_v3 (System.Text.StringBuilder), v52 @ X0_v3 (System.Text.StringBuilder), v298 @ X1_v3, v296 @ X2_v2, v199 @ X3_v1 (Il2CppMethodInfo), v163 @ X4_v1, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\nL_0146:\n\tv205 = new System.TypeLoadException();\nL_0147:\n\treturnVal1 = 0x6D2380(v138, v202, v200, v377, v345, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal1;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string FormatToString(string baseString, string className, IDictionary<string, string> propertiesAndValues)
		{
			//IL_001c: Expected I, but got O
			//IL_01c7: Expected I4, but got O
			//IL_021c: Expected I4, but got O
			//IL_025f: Expected I, but got O
			//IL_026f: Expected O, but got I
			//IL_027f: Expected O, but got I
			//IL_0133: Expected I, but got O
			//IL_016b: Expected I, but got O
			//IL_0381: Expected O, but got I4
			StringBuilder stringBuilder = new StringBuilder();
			IDictionary<string, string> dictionary2;
			object obj2 = default(object);
			IntPtr intPtr2 = default(IntPtr);
			object obj = default(object);
			IntPtr intPtr;
			IDictionary<string, string> dictionary;
			IEnumerator<KeyValuePair<string, string>> enumerator = default(IEnumerator<KeyValuePair<string, string>>);
			string text = default(string);
			KeyValuePair<string, string> keyValuePair = default(KeyValuePair<string, string>);
			string text2 = default(string);
			if (baseString != null)
			{
				bool flag = stringBuilder == null;
				intPtr = (IntPtr)text;
				dictionary = (IDictionary<string, string>)keyValuePair;
				dictionary2 = (IDictionary<string, string>)enumerator;
				if (!flag)
				{
					StringBuilder stringBuilder2 = stringBuilder.Append(baseString);
					goto IL_0092;
				}
			}
			else
			{
				bool flag2 = stringBuilder == null;
				obj = obj2;
				intPtr = intPtr2;
				dictionary = propertiesAndValues;
				text2 = null;
				dictionary2 = propertiesAndValues;
				if (!flag2)
				{
					goto IL_0092;
				}
			}
			goto IL_0182;
			IL_038f:
			int num;
			int num2;
			if (num + 1 != 0 || num2 == 0)
			{
				IntPtr intPtr3 = (IntPtr)stringBuilder;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+160]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v6 (Il2CppClass<System.Text.StringBuilder>)+168]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v296 @ X2_v2 (should have been resolved before IL gen)");
			}
			TypeLoadException ex = new TypeLoadException();
			object obj5;
			obj = obj5;
			IntPtr intPtr4;
			intPtr = intPtr4;
			dictionary = null;
			text2 = null;
			NullReferenceException ex2 = (NullReferenceException)(object)ex;
			goto IL_02b9;
			IL_02b9:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			string result = default(string);
			return result;
			IL_03c5:
			IDisposable disposable;
			disposable.Dispose();
			obj5 = obj;
			intPtr4 = intPtr;
			int num3;
			num = num3;
			int num4;
			num2 = num4;
			goto IL_038f;
			IL_0092:
			StringBuilder stringBuilder3 = stringBuilder.AppendFormat("\n{0}:", className);
			bool flag3 = propertiesAndValues == null;
			obj = obj2;
			intPtr = intPtr2;
			dictionary = propertiesAndValues;
			text2 = null;
			dictionary2 = propertiesAndValues;
			if (flag3)
			{
				goto IL_0182;
			}
			enumerator = propertiesAndValues.GetEnumerator();
			obj = obj2;
			text = null;
			keyValuePair = default(KeyValuePair<string, string>);
			text2 = null;
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, string> current = enumerator.Current;
				text = "null";
				StringBuilder stringBuilder4 = stringBuilder.AppendFormat("\n\t{0}: {1}", current, text);
				obj = 0;
				text2 = "\n\t{0}: {1}";
			}
			bool flag4 = enumerator == null;
			bool flag5 = !flag4;
			intPtr = (IntPtr)text;
			num3 = 0;
			num4 = 0;
			disposable = enumerator;
			if (!flag5)
			{
				obj5 = obj;
				intPtr4 = (IntPtr)text;
				num = 0;
				num2 = 0;
				goto IL_038f;
			}
			goto IL_03c5;
			IL_0182:
			ex2 = new NullReferenceException();
			if ((IntPtr)text2 != (IntPtr)1)
			{
				goto IL_02b9;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj6 = default(object);
			num4 = (int)obj6;
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			bool flag6 = dictionary2 == null;
			num3 = -1;
			disposable = (IDisposable)dictionary2;
			obj5 = obj;
			intPtr4 = intPtr;
			num = -1;
			num2 = (int)obj6;
			if (flag6)
			{
				goto IL_038f;
			}
			goto IL_03c5;
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0xD34864", Offset = "0xD34864", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F09D80]);\n\tv19 = *([v18 @ X8_v27]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023CA6]) = v38;\nL_0015:\n\tv41 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv55 = v41 != 3;\n\tif (v55) goto L_004F;\n\tgoto L_0036;\n\tv60 = *([v53 @ X8_v3 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0036;\n\tv94 = v53;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v94, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv68 = Facebook.Unity.LoginResult;\nL_0036:\n\tv76 = Facebook.Unity.Utilities::GetValueOrDefault(v36, v70.ExpirationTimestampKey, 1);\n\tgoto L_0046;\n\tv107 = *([v98 @ X8_v24+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tgoto L_0046;\n\tv128 = v98;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v128, v74, v72, v75, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0046:\n\tv115 = System.DateTime::get_UtcNow();\nL_004B:\n\tv176 = Facebook.Unity.Utilities::GetValueOrDefault(&v144 @ stack_-28_v2 (System.DateTime), 0, v141);\n\tgoto L_00A7;\nL_004F:\n\tgoto L_005E;\n\tv77 = *([v53 @ X8_v3 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_005E;\n\tv102 = v53;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v102, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv85 = Facebook.Unity.LoginResult;\nL_005E:\n\tv93 = Facebook.Unity.Utilities::GetValueOrDefault(v36, v87.ExpirationTimestampKey, 1);\n\tv106 = System.Int32::TryParse(v93, &v104 @ stack_-2C_v4 (System.Int32));\n\tv127 = v104 < 1;\n\tif (v127) goto L_0096;\n\tv132 = v106 == 0;\n\tif (v132) goto L_0096;\n\tv177 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv149 = v177 != 4;\n\tif (v149) goto L_00A1;\n\tgoto L_008B;\n\tv221 = *([v216 @ X0_v19+E0]);\n\tv222 = v221 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_008B;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v216, v103, v105, v92, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_008B:\n\tv168 = System.DateTime::get_UtcNow();\n\tgoto L_004B;\nL_0096:\n\tgoto L_009E;\n\tv178 = *([v136 @ X0_v11 (Il2CppClass<System.DateTime>)+E0]);\n\tv179 = v178 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_009E;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v136, v103, v105, v92, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv182 = System.DateTime;\nL_009E:\n\treturnVal1 = v185.MaxValue;\n\tgoto L_00A7;\nL_00A1:\n\treturnVal1 = Facebook.Unity.Utilities::FromTimestamp(v104);\nL_00A7:\n\treturn returnVal1;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static DateTime ParseExpirationDateFromResult(IDictionary<string, object> resultDictionary)
		{
			//IL_015a: Expected O, but got I8
			FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
			IDictionary<string, object> dictionary = default(IDictionary<string, object>);
			bool logWarning;
			DateTime dictionary2;
			if (currentPlatform != FacebookUnityPlatform.WebGL)
			{
				string valueOrDefault = dictionary.GetValueOrDefault<string>(LoginResult.ExpirationTimestampKey);
				bool flag = int.TryParse(valueOrDefault, out var result);
				if (result < 1 || !flag)
				{
					return DateTime.MaxValue;
				}
				FacebookUnityPlatform currentPlatform2 = Constants.CurrentPlatform;
				if (currentPlatform2 != FacebookUnityPlatform.Gameroom)
				{
					return FromTimestamp(result);
				}
				DateTime utcNow = DateTime.UtcNow;
				logWarning = false;
				dictionary2 = utcNow;
			}
			else
			{
				long valueOrDefault2 = dictionary.GetValueOrDefault<long>(LoginResult.ExpirationTimestampKey);
				DateTime utcNow2 = DateTime.UtcNow;
				logWarning = true;
				dictionary2 = utcNow2;
			}
			long valueOrDefault3 = ((IDictionary<string, object>)dictionary2).GetValueOrDefault<long>(null, logWarning);
			return (DateTime)valueOrDefault3;
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xD34CD8", Offset = "0xD34CD8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB0058]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023CA7]) = v38;\nL_001C:\n\tv48 = Facebook.Unity.Utilities::GetValueOrDefault(resultDictionary, \"last_refresh\", 0);\n\tv52 = System.Int32::TryParse(v48, &v50 @ stack_-34_v2 (System.Int32));\n\tv64 = v50 < 1;\n\tif (v64) goto L_FFFFFFFF;\n\tv66 = v52 == 0;\n\tif (v66) goto L_FFFFFFFF;\n\tv71 = Facebook.Unity.Utilities::FromTimestamp(v50);\n\tv74 = 0;\n\tv81 = Facebook.Unity.Utilities::GetValueOrDefault(&v74 @ stack_-30_v1 (System.Nullable`1<System.DateTime>), v71, Il2CppMethodInfo);\n\tgoto L_0044;\nL_0044:\n\treturn v74;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static DateTime? ParseLastRefreshFromResult(IDictionary<string, object> resultDictionary)
		{
			string valueOrDefault = resultDictionary.GetValueOrDefault<string>("last_refresh", logWarning: false);
			bool flag = int.TryParse(valueOrDefault, out var result);
			DateTime? result2;
			if (result >= 1 && flag)
			{
				DateTime key = FromTimestamp(result);
				string valueOrDefault2 = ((IDictionary<string, object>)(DateTime?)null).GetValueOrDefault<string>((string)key, logWarning: false);
				result2 = null;
			}
			else
			{
				result2 = null;
			}
			return result2;
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0xD34A20", Offset = "0xD34A20", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1ED2118]);\n\tv23 = *([v22 @ X8_v54]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023CA8]) = v42;\nL_001D:\n\tgoto L_002B;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002B;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv55 = Facebook.Unity.LoginResult;\nL_002B:\n\tv66 = Facebook.Unity.Utilities::TryGetValue(resultDictionary, v59.PermissionsKey, &v62 @ stack_-38_v2 (System.String));\n\tv69 = v66 == 0;\n\tif (v69) goto L_0049;\n\t// 52 NewArr v75 @ X0_v51 (System.Char[]), typeof(System.Char[]), 1\n\tv75[0] = 0x2C;\n\tv186 = System.String::Split(v62, v75);\n\tgoto L_009B;\nL_0049:\n\tgoto L_0057;\n\tv82 = *([v76 @ X0_v30 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0057;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v76, v64, v61, v65, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv86 = Facebook.Unity.LoginResult;\nL_0057:\n\tv97 = Facebook.Unity.Utilities::TryGetValue(resultDictionary, v90.PermissionsKey, &v93 @ stack_-40_v8 (System.Collections.Generic.IEnumerable`1<System.Object>));\n\tv123 = v97 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_009B;\n\t// 96 NewArr v174 @ X0_v35 (System.String[]), typeof(System.String[]), 0\n\t// 101 NewArr v212 @ X0_v37 (System.String[]), typeof(System.String[]), 1\n\tgoto L_0077;\n\tv256 = *([v224 @ X8_v34 (Il2CppClass<Facebook.Unity.LoginResult>)+E0]);\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\t// 111 ConditionalJump @b56, v258 @ TEMP_v48\n\tv277 = v224;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v277, v201, v92, v96, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv261 = Facebook.Unity.LoginResult;\nL_0077:\n\tv279 = v278.PermissionsKey == 0;\n\tif (v279) goto L_0082;\n\t// 124 IsInst v162 @ X0_v45, typeof(System.String), v278.PermissionsKey (System.String)\n\tv164 = v162 == 0;\n\tif (v164) goto L_00DC;\nL_0082:\n\tv212[0] = v278.PermissionsKey;\n\tgoto L_0093;\n\tv300 = *([v296 @ X0_v40+E0]);\n\tv301 = v300 == 0;\n\tv302 = ~v301;\n\tif (v302) goto L_0093;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v296, v139, v92, v96, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0093:\n\tFacebook.Unity.FacebookLogger::Warn(\"Failed to find parameter '{0}' in login result\", v212);\nL_009B:\n\tgoto L_00A3;\n\tv213 = *([v196 @ X0_v18 (Il2CppClass<Facebook.Unity.Utilities+<>c>)+E0]);\n\tv214 = v213 == 0;\n\tv215 = ~v214;\n\tif (v215) goto L_00A3;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v196, v181, v178, v175, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv217 = Facebook.Unity.Utilities+<>c;\nL_00A3:\n\tv248 = v220.<>9__18_0;\n\tv222 = v220.<>9__18_0 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_00C8;\n\tgoto L_00B6;\n\tv262 = *([v216 @ X0_v19 (Il2CppClass<Facebook.Unity.Utilities+<>c>)+E0]);\n\tv263 = v262 == 0;\n\tv264 = ~v263;\n\tif (v264) goto L_00B6;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v216, v181, v178, v175, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv292 = Facebook.Unity.Utilities+<>c;\n\tv269 = *([v292 @ X8_v27+B8]);\nL_00B6:\n\tv243 = new System.Func`2<System.Object, System.String>();\n\tSystem.Func`2<System.Object, System.String>::.ctor(v243, v268.<>9, Il2CppMethodInfo);\n\tv247.<>9__18_0 = v243;\nL_00C8:\n\tv255 = System.Linq.Enumerable::Select(v93, v248);\n\treturnVal1 = System.Linq.Enumerable::ToList(v255);\n\treturn returnVal1;\n\tv141 = new System.NullReferenceException();\n\tv154 = new System.IndexOutOfRangeException();\nL_00DA:\n\tv111 = new System.TypeLoadException();\n\tv120 = new System.NullReferenceException();\nL_00DC:\n\tv169 = new System.ArrayTypeMismatchException();\n\tgoto L_00DA;\n\treturn X0;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static ICollection<string> ParsePermissionFromResult(IDictionary<string, object> resultDictionary)
		{
			IEnumerable<object> value2;
			if (resultDictionary.TryGetValue<string>(LoginResult.PermissionsKey, out var value))
			{
				char[] separator = new char[1] { ',' };
				string[] array = value.Split(separator);
				value2 = array;
			}
			else if (!resultDictionary.TryGetValue<IEnumerable<object>>(LoginResult.PermissionsKey, out value2))
			{
				string[] array2 = new string[0];
				string[] array3 = new string[1];
				if (LoginResult.PermissionsKey != null)
				{
					object obj = LoginResult.PermissionsKey as string;
					if (obj == null)
					{
						while (true)
						{
							ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
							TypeLoadException ex2 = new TypeLoadException();
							NullReferenceException ex3 = new NullReferenceException();
						}
					}
				}
				array3[0] = LoginResult.PermissionsKey;
				FacebookLogger.Warn("Failed to find parameter '{0}' in login result", array3);
				value2 = array2;
			}
			Func<object, string> selector = _003C_003Ec._003C_003E9__18_0;
			if (_003C_003Ec._003C_003E9__18_0 == null)
			{
				selector = (_003C_003Ec._003C_003E9__18_0 = delegate(object permission)
				{
					//IL_0071: Expected O, but got I4
					//IL_0025: Expected I, but got O
					//IL_0035: Expected O, but got I
					//IL_0045: Expected O, but got I
					if (permission != null)
					{
						IntPtr intPtr = (IntPtr)permission;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+160]");
						object obj2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Object>)+168]");
						object obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X2_v1 (should have been resolved before IL gen)");
					}
					NullReferenceException ex4 = new NullReferenceException();
					IntPtr intPtr2 = default(IntPtr);
					int count = default(int);
					return (string)((System.Xml.Ucs4Decoder)(object)ex4).GetCharCount((byte[])permission, (int)(long)intPtr2, count);
				});
			}
			IEnumerable<string> source = value2.Select(selector);
			return source.ToList();
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0xD34D94", Offset = "0xD34D94", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = &v8 @ stack_-10_v2;\n\tv21 = 0xE93CAC(&v12 @ stack_-28_v2, 0x7B2, 1, 1, 0, 0, 0, 0, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv32 = &v8 @ stack_-10_v2 - 8;\n\t*([v7 @ X29_v1-8]) = v12;\n\treturnVal1 = 0xE94CB8(v32, 0, 1, 1, 0, 0, 0, 0, timestamp, v23, v24, v25, v26, v27, v28, v29);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static DateTime FromTimestamp(int timestamp)
		{
			//IL_0026: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93CAC (inside System.DateTime::TimeToTicks +0x224)");
			object obj3 = (long)(IntPtr)obj2 - 8L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E94CB8 (inside System.DateTime::DaysInMonth +0x170)");
			DateTime result = default(DateTime);
			return result;
		}
	}
}
