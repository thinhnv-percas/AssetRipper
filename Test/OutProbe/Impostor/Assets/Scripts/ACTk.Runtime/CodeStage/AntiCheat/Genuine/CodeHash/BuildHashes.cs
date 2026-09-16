using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using AssetRipperInjected;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x200002A")]
	public class BuildHashes
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200002B")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000D1")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000D2")]
			public static Comparison<FileHash> _003C_003E9__9_0;

			[Token(Token = "0x6000340")]
			[Address(RVA = "0xBE8ACC", Offset = "0xBE8ACC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35503]) = v34;\nL_0012:\n\tv36 = new CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000341")]
			[Address(RVA = "0xBE8B28", Offset = "0xBE8B28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal int _003C_002Ector_003Eb__9_0(FileHash x, FileHash y)
			{
				return string.Compare(x.Hash, y.Hash, StringComparison.Ordinal);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x10")]
		internal readonly string _003CBuildPath_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x18")]
		internal readonly FileHash[] _003CFileHashes_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x20")]
		internal readonly string _003CSummaryHash_003Ek__BackingField;

		[Token(Token = "0x1700001A")]
		public string BuildPath
		{
			[CompilerGenerated]
			[Token(Token = "0x6000338")]
			[Address(RVA = "0xBE84D0", Offset = "0xBE84D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BuildPath>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BuildPath;
			}
		}

		[Token(Token = "0x1700001B")]
		public FileHash[] FileHashes
		{
			[CompilerGenerated]
			[Token(Token = "0x6000339")]
			[Address(RVA = "0xBE84D8", Offset = "0xBE84D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<FileHashes>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FileHashes;
			}
		}

		[Token(Token = "0x1700001C")]
		public string SummaryHash
		{
			[CompilerGenerated]
			[Token(Token = "0x600033A")]
			[Address(RVA = "0xBE84E0", Offset = "0xBE84E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SummaryHash>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SummaryHash;
			}
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0xBE84E8", Offset = "0xBE84E8", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv32 = System.Comparison`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, buildPath, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, buildPath, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, buildPath, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, buildPath, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv95 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes+<>c;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, buildPath, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A35500]) = v49;\nL_0028:\n\tSystem.Object::.ctor(this);\n\tgoto L_0032;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v55, v51, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv64 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes+<>c;\nL_0032:\n\tv67 = v65.<>9__9_0 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_0054;\n\tgoto L_0040;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v63, v51, fileHashes, sha1, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv98 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes+<>c;\nL_0040:\n\tv87 = new System.Comparison`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>();\n\tSystem.Comparison`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>::.ctor(v87, v100.<>9, Il2CppMethodInfo);\n\tv90.<>9__9_0 = v87;\nL_0054:\n\tSystem.Collections.Generic.List`1<System.Object>::Sort(fileHashes, v91);\n\tthis.<BuildPath>k__BackingField = buildPath;\n\tv114 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes::CalculateSummaryCodeHash(fileHashes, fileHashes, sha1);\n\tthis.<SummaryHash>k__BackingField = v114;\n\tv118 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>::ToArray(fileHashes);\n\tthis.<FileHashes>k__BackingField = v118;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal BuildHashes(string buildPath, List<FileHash> fileHashes, SHA1Managed sha1)
		{
			bool flag = _003C_003Ec._003C_003E9__9_0 == null;
			bool flag2 = !flag;
			Comparison<object> comparison = (Comparison<object>)_003C_003Ec._003C_003E9__9_0;
			if (!flag2)
			{
				comparison = (Comparison<object>)(_003C_003Ec._003C_003E9__9_0 = (FileHash x, FileHash y) => string.Compare(x.Hash, y.Hash, StringComparison.Ordinal));
			}
			fileHashes.Sort(comparison);
			BuildPath = buildPath;
			SummaryHash = ((BuildHashes)(object)fileHashes).CalculateSummaryCodeHash(fileHashes, sha1);
			FileHashes = fileHashes.ToArray();
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0xBE8810", Offset = "0xBE8810", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<FileHashes>k__BackingField = fileHashes;\n\tthis.<SummaryHash>k__BackingField = summaryHash;\n\tthis.<BuildPath>k__BackingField = buildPath;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal BuildHashes(string buildPath, FileHash[] fileHashes, string summaryHash)
		{
			FileHashes = fileHashes;
			SummaryHash = summaryHash;
			BuildPath = buildPath;
		}

		[Token(Token = "0x600033D")]
		[Address(RVA = "0xBE884C", Offset = "0xBE884C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.<FileHashes>k__BackingField;\n\tv17 = v10.Length < 0;\n\tv18 = v10.Length == 0;\n\tv20 = v10.Length ^ v10.Length;\n\tv21 = v10.Length & v20;\n\tv22 = v21 < 0;\n\tv23 = v17 == v22;\n\tv24 = ~v18;\n\tv25 = v23 & v24;\n\tv37 = v10.Length < 1;\n\tif (v37) goto L_0054;\nL_0031:\n\tv89 = v10[v52 @ X22_v5 (System.Int32)];\n\tv113 = System.String::op_Equality(v89.<Hash>k__BackingField, hash);\n\tv181 = v113 == 0;\n\tv141 = ~v181;\n\tif (v141) goto L_0054;\n\tv52 = v52 + 1;\n\tv135 = v52 - v10.Length;\n\tv133 = v135 < 0;\n\tv129 = v52 ^ v10.Length;\n\tv127 = v52 ^ v135;\n\tv125 = v129 & v127;\n\tv123 = v125 < 0;\n\tv183 = v133 == v123;\n\tv184 = ~v183;\n\tv121 = v52 < v10.Length;\n\tif (v121) goto L_0031;\nL_0054:\n\treturn v118;\n\tv45 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasFileHash(string hash)
		{
			FileHash[] fileHashes = FileHashes;
			bool flag = fileHashes.Length < 0;
			bool flag2 = fileHashes.Length == 0;
			int num = fileHashes.Length ^ fileHashes.Length;
			int num2 = fileHashes.Length & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			bool flag6 = flag4 && flag5;
			bool flag7 = fileHashes.Length < 1;
			bool result = flag6;
			if (!flag7)
			{
				int num3 = 0;
				bool flag8 = flag6;
				bool flag16;
				do
				{
					FileHash fileHash = fileHashes[num3];
					bool flag9 = fileHash.Hash == hash;
					bool flag10 = !flag9;
					bool flag11 = !flag10;
					result = flag8;
					if (flag11)
					{
						break;
					}
					num3++;
					int num4 = num3 - fileHashes.Length;
					bool flag12 = num4 < 0;
					int num5 = num3 ^ fileHashes.Length;
					int num6 = num3 ^ num4;
					int num7 = num5 & num6;
					bool flag13 = num7 < 0;
					bool flag14 = flag12 == flag13;
					bool flag15 = !flag14;
					flag16 = num3 < fileHashes.Length;
					result = flag15;
					flag8 = flag15;
				}
				while (flag16);
			}
			return result;
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0xBE88D4", Offset = "0xBE88D4", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv26 = UnityEngine.Debug;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = System.String[];\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv55 = \"\\n\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv160 = \" : \";\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv230 = \"[ACTk] Build hashed: \";\n\tv231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv281 = \"\\nFiles:\";\n\tv282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv287 = \"\\nSummary hash: \";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v287, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35501]) = v46;\nL_002B:\n\t// 43 NewArr v49 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv49[0] = \"[ACTk] Build hashed: \";\n\tv49[1] = this.<BuildPath>k__BackingField;\n\tv49[2] = \"\\nSummary hash: \";\n\tv49[3] = this.<SummaryHash>k__BackingField;\n\tv49[4] = \"\\nFiles:\";\n\tv140 = System.String::Concat(v49);\n\tv157 = this.<FileHashes>k__BackingField;\n\tv304 = v157.Length < 1;\n\tif (v304) goto L_00E8;\nL_0092:\n\tv61 = v157[v68 @ X22_v6 (System.Int32)];\n\t// 148 NewArr v141 @ X0_v16 (System.String[]), typeof(System.String[]), 5\n\tv141[0] = v149;\n\tv141[1] = \"\\n\";\n\tv141[2] = v61.<Path>k__BackingField;\n\tv141[3] = \" : \";\n\tv141[4] = v61.<Hash>k__BackingField;\n\tv325 = System.String::Concat(v141);\n\tv68 = v68 + 1;\n\tv315 = v68 < v157.Length;\n\tif (v315) goto L_0092;\nL_00E8:\n\tgoto L_00F5;\n\tv344 = \"il2cpp_codegen_runtime_class_init\"(v333, v313, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00F5:\n\tUnityEngine.Debug::Log(v327);\n\treturn;\n\tv139 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PrintToConsole()
		{
			string text = "[ACTk] Build hashed: " + BuildPath + "\nSummary hash: " + SummaryHash + "\nFiles:";
			FileHash[] fileHashes = FileHashes;
			bool flag = fileHashes.Length < 1;
			string message = text;
			if (!flag)
			{
				int num = 0;
				string text2 = text;
				bool flag2;
				do
				{
					FileHash fileHash = fileHashes[num];
					string text3 = text2 + "\n" + fileHash.Path + " : " + fileHash.Hash;
					num++;
					flag2 = num < fileHashes.Length;
					message = text3;
					text2 = text3;
				}
				while (flag2);
			}
			Debug.Log(message);
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0xBE863C", Offset = "0xBE863C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, fileHashes, sha1, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, fileHashes, sha1, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv127 = Il2CppMethodInfo;\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, fileHashes, sha1, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv141 = Il2CppMethodInfo;\n\tv142 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, fileHashes, sha1, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv157 = CodeStage.AntiCheat.Utils.StringUtils;\n\tv158 = \"il2cpp_codegen_initialize_runtime_metadata\"(v157, fileHashes, sha1, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv175 = System.String;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, fileHashes, sha1, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A35502]) = v43;\nL_0024:\n\tv44 = 0;\n\tv47 = fileHashes == 0;\n\tif (v47) goto L_0066;\n\tv123 = v59.Empty;\n\tv67 = System.Collections.Generic.List`1<CodeStage.AntiCheat.Genuine.CodeHash.FileHash>::GetEnumerator(fileHashes);\nL_003D:\n\tv139 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v44 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv144 = v139 == 0;\n\tif (v144) goto L_004C;\n\tv120 = 0;\n\tv133 = System.String::Concat(v123, *([v120 @ X8_v17 (System.Int32)+18]));\n\tgoto L_003D;\nL_004C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v44 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_0051:\n\tgoto L_0054;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v181, v100, v97, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0054:\n\tv112 = CodeStage.AntiCheat.Utils.StringUtils::StringToBytes(v118);\n\tv115 = sha1 == 0;\n\tif (v115) goto L_0066;\n\tv203 = System.Security.Cryptography.HashAlgorithm::ComputeHash(sha1, v112);\n\treturnVal2 = CodeStage.AntiCheat.Utils.StringUtils::HashBytesToHexString(v203);\n\treturn returnVal2;\n\tv111 = new System.NullReferenceException();\nL_0066:\n\tv125 = new System.NullReferenceException();\n\tgoto L_0073;\n\tgoto L_0073;\nL_0073:\n\tv155 = v100 != 1;\n\tif (v155) goto L_0083;\n\tv162 = 0x1854E70(v125, v100, v95, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv184 = 0x1854E80(v162, v100, v95, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v44 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv170 = *([v162 @ X0_v13]) == 0;\n\tif (v170) goto L_0051;\n\tthrow System.OutOfMemoryException;\nL_0083:\n\tgoto L_0089;\n\tX21 = X0;\nL_0089:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v44 @ stack_-58_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0090;\n\tv196 = 0xBD3CD0(v125, Il2CppMethodInfo, v95, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0090:\n\tv199 = new System.OutOfMemoryException();\n\treturnVal1 = 0x9DACB4(v199, Il2CppMethodInfo, v95, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string CalculateSummaryCodeHash(List<FileHash> fileHashes, SHA1Managed sha1)
		{
			//IL_0075: Expected O, but got I
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			bool flag = fileHashes == null;
			string text = default(string);
			List<FileHash> list = (List<FileHash>)(object)text;
			string text2 = default(string);
			SHA1Managed sHA1Managed = default(SHA1Managed);
			nint num2 = default(nint);
			SHA1Managed sHA1Managed2;
			if (!flag)
			{
				text2 = string.Empty;
				List<FileHash>.Enumerator enumerator2 = fileHashes.GetEnumerator();
				sHA1Managed = sha1;
				while (enumerator.MoveNext())
				{
					int num = 0;
					string text3 = text2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v17 (System.Int32)+18]");
					string text4 = text3 + (string)0;
					sHA1Managed = null;
					text2 = text4;
				}
				enumerator.Dispose();
				sHA1Managed2 = sHA1Managed;
				num2 = 0;
				text = text2;
				goto IL_00b4;
			}
			goto IL_011c;
			IL_011c:
			NullReferenceException ex = new NullReferenceException();
			if (num2 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				bool flag2 = obj == null;
				num2 = 0;
				text = (string)(object)list;
				if (flag2)
				{
					goto IL_00b4;
				}
				throw new OutOfMemoryException();
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			string result = default(string);
			return result;
			IL_00b4:
			byte[] buffer = StringUtils.StringToBytes(text);
			bool flag3 = sha1 == null;
			sHA1Managed2 = sHA1Managed;
			num2 = 0;
			list = (List<FileHash>)(object)text2;
			if (!flag3)
			{
				byte[] input = sha1.ComputeHash(buffer);
				return StringUtils.HashBytesToHexString(input);
			}
			goto IL_011c;
		}
	}
}
