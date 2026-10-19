using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000375")]
	public sealed class GenerationWorkspace : IDisposable
	{
		[Token(Token = "0x4000A7A")]
		[FieldOffset(Offset = "0x20")]
		private bool _disposed;

		[Token(Token = "0x4000A7B")]
		[FieldOffset(Offset = "0x28")]
		private long _lastUnparseableDoneLen;

		[Token(Token = "0x17000113")]
		[field: Token(Token = "0x4000A78")]
		[field: FieldOffset(Offset = "0x10")]
		public string RunId
		{
			[Token(Token = "0x6000E41")]
			[Address(RVA = "0x3F085C0", Offset = "0x3F085C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.RunId;\n")]
			get;
		}

		[Token(Token = "0x17000114")]
		[field: Token(Token = "0x4000A79")]
		[field: FieldOffset(Offset = "0x18")]
		public string Root
		{
			[Token(Token = "0x6000E42")]
			[Address(RVA = "0x3F085C8", Offset = "0x3F085C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Root;\n")]
			get;
		}

		[Token(Token = "0x17000115")]
		public string CallsDir
		{
			[Token(Token = "0x6000E43")]
			[Address(RVA = "0x3F085D0", Offset = "0x3F085D0", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"calls\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "calls");
			}
		}

		[Token(Token = "0x17000116")]
		public string ResultsDir
		{
			[Token(Token = "0x6000E44")]
			[Address(RVA = "0x3F08650", Offset = "0x3F08650", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"results\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "results");
			}
		}

		[Token(Token = "0x17000117")]
		public string DonePath
		{
			[Token(Token = "0x6000E45")]
			[Address(RVA = "0x3F086D0", Offset = "0x3F086D0", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"done.json\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "done.json");
			}
		}

		[Token(Token = "0x17000118")]
		public string InputPath
		{
			[Token(Token = "0x6000E46")]
			[Address(RVA = "0x3F08750", Offset = "0x3F08750", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"input.json\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "input.json");
			}
		}

		[Token(Token = "0x17000119")]
		public string ManifestPath
		{
			[Token(Token = "0x6000E47")]
			[Address(RVA = "0x3F087D0", Offset = "0x3F087D0", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"manifest.json\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "manifest.json");
			}
		}

		[Token(Token = "0x1700011A")]
		public string LogPath
		{
			[Token(Token = "0x6000E48")]
			[Address(RVA = "0x3F08850", Offset = "0x3F08850", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"log.txt\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "log.txt");
			}
		}

		[Token(Token = "0x1700011B")]
		public string MetaPath
		{
			[Token(Token = "0x6000E49")]
			[Address(RVA = "0x3F088D0", Offset = "0x3F088D0", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_002C:\n\treturnVal1 = System.IO.Path::Combine(this.Root, \"meta.json\");\n\treturn returnVal1;\nL_0020:\n\tgoto L_002C;\n")]
			get
			{
				return Path.Combine(Root, "meta.json");
			}
		}

		[Token(Token = "0x6000E4A")]
		[Address(RVA = "0x3F08950", Offset = "0x3F08950", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastUnparseableDoneLen = -1;\n\tSystem.Object::.ctor(this);\n\tthis.RunId = runId;\n\tthis.Root = root;\n\treturn;\n")]
		private GenerationWorkspace(string runId, string root)
		{
			_lastUnparseableDoneLen = -1L;
			RunId = runId;
			Root = root;
		}

		[Token(Token = "0x6000E4B")]
		[Address(RVA = "0x3F089A8", Offset = "0x3F089A8", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\nL_0040:\n\tv83 = System.IO.Path::GetTempPath();\n\tv90 = System.IO.Path::Combine(v83, \"sand-out-gen\", v68);\n\tv96 = System.IO.Path::Combine(v90, \"calls\");\n\tv98 = System.IO.Directory::CreateDirectory(v96);\n\tv102 = System.IO.Path::Combine(v90, \"results\");\n\tv104 = System.IO.Directory::CreateDirectory(v102);\n\tv106 = new _game.CoreSystem.New.LevelGeneratorSystem.Driver.GenerationWorkspace();\n\tv106._lastUnparseableDoneLen = -1;\n\tSystem.Object::.ctor(v106);\n\tv106.RunId = v68;\n\tv106.Root = v90;\n\treturn v106;\nL_0031:\n\tv59 = System.Guid::NewGuid();\n\tv63 = v59;\n\tv68 = System.Guid::ToString(&v63 @ stack_-50_v1 (System.Guid), \"N\");\n\tgoto L_0040;\n")]
		public static GenerationWorkspace Create()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenerationWorkspace::Create");
			return default;
		}

		[Token(Token = "0x6000E4C")]
		[Address(RVA = "0x3F08B1C", Offset = "0x3F08B1C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0026:\n\tv60 = System.IO.Path::Combine(this.Root, \"input.json\");\n\tSystem.IO.File::WriteAllText(v60, json);\n\treturn;\nL_0021:\n\tgoto L_0026;\n")]
		public void WriteInput(string json)
		{
			string path = Path.Combine(Root, "input.json");
			File.WriteAllText(path, json);
		}

		[Token(Token = "0x6000E4D")]
		[Address(RVA = "0x3F08BAC", Offset = "0x3F08BAC", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv98 = \"cardId\";\n\tv102 = cardId;\n\tgoto L_0049;\nL_003C:\n\tv80 = 0xB7D5000 + 0x538;\n\tv81 = *([v80 @ X9_v18 (System.Int32)+90]);\n\tv82 = *([v81 @ X9_v19+B8]);\n\tv102 = *([v82 @ X9_v20]);\n\tv98 = \"cardId\";\n\tgoto L_0049;\nL_0049:\n\tv106 = Newtonsoft.Json.Linq.JToken::op_Implicit(v102);\n\tv108 = v57 == 0;\n\tif (v108) goto L_00C2;\n\tNewtonsoft.Json.Linq.JObject::set_Item(v57, v98, v106);\n\tv116 = displayName == 0;\n\tif (v116) goto L_005D;\n\tv142 = \"displayName\";\n\tv144 = displayName;\n\tgoto L_006A;\nL_005D:\n\tv123 = 0xB7D5000 + 0x538;\n\tv124 = *([v123 @ X9_v12 (System.Int32)+90]);\n\tv125 = *([v124 @ X9_v13+B8]);\n\tv144 = *([v125 @ X9_v14]);\n\tv142 = \"displayName\";\n\tgoto L_006A;\nL_006A:\n\tv148 = Newtonsoft.Json.Linq.JToken::op_Implicit(v144);\n\tNewtonsoft.Json.Linq.JObject::set_Item(v57, v142, v148);\n\tv159 = startedUtcIso == 0;\n\tif (v159) goto L_007C;\n\tv217 = \"startedUtc\";\n\tv219 = startedUtcIso;\n\tgoto L_0089;\nL_007C:\n\tv166 = 0xB7D5000 + 0x538;\n\tv167 = *([v166 @ X9_v7 (System.Int32)+90]);\n\tv168 = *([v167 @ X9_v8+B8]);\n\tv219 = *([v168 @ X9_v9]);\n\tv217 = \"startedUtc\";\n\tgoto L_0089;\nL_0089:\n\tv223 = Newtonsoft.Json.Linq.JToken::op_Implicit(v219);\n\tNewtonsoft.Json.Linq.JObject::set_Item(v57, v217, v223);\n\tgoto L_00A4;\nL_00AB:\n\tv255 = System.IO.Path::Combine(this.Root, \"meta.json\");\n\tv259 = Newtonsoft.Json.Linq.JToken::ToString(v57);\n\tSystem.IO.File::WriteAllText(v255, v259);\n\treturn;\nL_00C2:\n\tv113 = new System.NullReferenceException();\n\tgoto L_00F6;\nL_00F6:\n\t// 246 Interrupt\n\tv133 = 0x8BF5BF4(v113, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv151 = 0x8BF0368(v113, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv156 = 0xA1B8(v151, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_002A:\n\tv57 = new Newtonsoft.Json.Linq.JObject();\n\tNewtonsoft.Json.Linq.JObject::.ctor(v57);\n\tv70 = cardId == 0;\n\tif (v70) goto L_003C;\nL_00A4:\n\tgoto L_00AB;\n")]
		public void WriteCardMeta(string cardId, string displayName, string startedUtcIso)
		{
			//IL_003a: Expected O, but got I
			//IL_004a: Expected O, but got I
			//IL_00e5: Expected O, but got I
			//IL_00f5: Expected O, but got I
			//IL_017c: Expected O, but got I
			//IL_018c: Expected O, but got I
			JObject jObject = new JObject();
			string propertyName;
			string text;
			if (cardId != null)
			{
				propertyName = "cardId";
				text = cardId;
			}
			else
			{
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X9_v18 (System.Int32)+90]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X9_v19+B8]");
				object obj2 = 0;
				text = (string)obj2;
				propertyName = "cardId";
			}
			JToken value = text;
			if (jObject != null)
			{
				jObject[propertyName] = value;
				string propertyName2;
				string text2;
				if (displayName != null)
				{
					propertyName2 = "displayName";
					text2 = displayName;
				}
				else
				{
					int num2 = 192761856 + 1336;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X9_v12 (System.Int32)+90]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X9_v13+B8]");
					object obj4 = 0;
					text2 = (string)obj4;
					propertyName2 = "displayName";
				}
				JToken value2 = text2;
				jObject[propertyName2] = value2;
				string propertyName3;
				string text3;
				if (startedUtcIso != null)
				{
					propertyName3 = "startedUtc";
					text3 = startedUtcIso;
				}
				else
				{
					int num3 = 192761856 + 1336;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X9_v7 (System.Int32)+90]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X9_v8+B8]");
					object obj6 = 0;
					text3 = (string)obj6;
					propertyName3 = "startedUtc";
				}
				JToken value3 = text3;
				jObject[propertyName3] = value3;
				string path = Path.Combine(Root, "meta.json");
				string contents = jObject.ToString();
				File.WriteAllText(path, contents);
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
			}
		}

		[Token(Token = "0x6000E4E")]
		[Address(RVA = "0x3F08EC4", Offset = "0x3F08EC4", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_003A:\n\tv81 = System.IO.Path::Combine(this.Root, \"done.json\");\n\tv83 = System.IO.File::Exists(v81);\n\tv85 = ~v83;\n\tif (v85) goto L_007F;\n\tgoto L_0052;\nL_0057:\n\tv146 = System.IO.Path::Combine(this.Root, \"done.json\");\n\tv148 = System.IO.File::ReadAllText(v146);\n\tv149 = Newtonsoft.Json.Linq.JObject::Parse(v148);\n\tv133 = v149 == 0;\n\tif (v133) goto L_0080;\n\tv153 = Newtonsoft.Json.Linq.JObject::get_Item(v149, \"reason\");\n\tv155 = v153 == 0;\n\tif (v155) goto L_006E;\n\tv159 = Newtonsoft.Json.Linq.Extensions::Value(v153);\n\tv172 = v159 == 0;\n\tv164 = ~v172;\n\tv93 = v159;\n\tif (v164) goto L_0072;\nL_006E:\n\tv167 = 0xB7D5000 + 0x538;\n\tv168 = *([v167 @ X8_v15 (System.Int32)+90]);\n\tv169 = *([v168 @ X8_v16+B8]);\n\tv93 = *([v169 @ X8_v17]);\nL_007F:\n\treturn v83;\nL_0080:\n\tv154 = new System.NullReferenceException();\n\tgoto L_00BD;\nL_00BD:\n\t// 189 Interrupt\n\tv171 = 0x8BF5BF4(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv176 = 0x8BF0368(v154, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v176, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_001A:\n\t*([reason @ X1 (System.String&)]) = 0;\n\tgoto L_0035;\nL_0035:\n\tgoto L_003A;\nL_0052:\n\tgoto L_0057;\nL_0072:\n\t*([reason @ X1 (System.String&)]) = v93;\n")]
		public bool TryReadDone(out string reason)
		{
			//IL_0122: Expected O, but got I
			//IL_0132: Expected O, but got I
			reason = null;
			reason = null;
			string path = Path.Combine(Root, "done.json");
			bool flag = File.Exists(path);
			if (!flag)
			{
				goto IL_013f;
			}
			string path2 = Path.Combine(Root, "done.json");
			string json = File.ReadAllText(path2);
			JObject jObject = JObject.Parse(json);
			object obj2;
			if (jObject != null)
			{
				JToken jToken = jObject["reason"];
				if (jToken != null)
				{
					object obj = jToken.Value<object>();
					bool flag2 = obj == null;
					bool flag3 = !flag2;
					obj2 = obj;
					if (flag3)
					{
						goto IL_01a3;
					}
				}
				int num = 192761856 + 1336;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ X8_v15 (System.Int32)+90]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v16+B8]");
				object obj4 = 0;
				obj2 = obj4;
				goto IL_01a3;
			}
			NullReferenceException ex = new NullReferenceException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
			bool result = default(bool);
			return result;
			IL_013f:
			return flag;
			IL_01a3:
			reason = (string)obj2;
			goto IL_013f;
		}

		[Token(Token = "0x6000E4F")]
		[Address(RVA = "0x3F09124", Offset = "0x3F09124", Length = "0x9D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004D;\nL_0055:\n\tv76 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv79 = *([v76 @ X0_v160 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv80 = v79 == 0;\n\tv81 = ~v80;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v81) goto L_0075;\nL_005C:\n\tv93 = 0x220C238(v87, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv106 = *([v93 @ X0_v159+E4]) == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_007D;\n\tgoto L_0069;\nL_0069:\n\tgoto L_0083;\n\tv83 = 0x220C2B8(Il2CppMethodInfo, 0, reason, bypassedWarnings, rawJson, archiveSuffix, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv88 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tv101 = *([v88 @ X0_v154 (Il2CppClass<System.EmptyArray`1<System.String>>)+135]) & 1;\n\tv90 = v101 == 0;\nL_FFFFFFFF:\n\tv87 = Il2CppClass<System.EmptyArray`1<System.String>>;\n\tif (v90) goto L_005C;\nL_0075:\n\tgoto L_007D;\nL_007D:\n\tgoto L_0083;\nL_0083:\n\t*([bypassedWarnings @ X3 (System.String[]&)]) = v137.Value;\n\t*([rawJson @ X4 (System.String&)]) = 0;\n\tgoto L_0090;\nL_0090:\n\tv220 = 0xB309000 + 0xC78;\n\tgoto L_0098;\nL_0098:\n\tv184 = System.IO.Path::Combine(this.Root, *([v220 @ X20_v4 (System.Int32)]));\n\tv200 = System.IO.File::Exists(v184);\n\tv211 = ~v200;\n\tv212 = ~v211;\n\tif (v212) goto L_00BE;\n\tgoto L_FFFFFFFF;\nL_00BE:\n\tgoto L_00CC;\nL_00D1:\n\tv411 = System.IO.Path::Combine(this.Root, *([v220 @ X20_v4 (System.Int32)]));\n\tv477 = System.IO.File::ReadAllText(v411);\n\tv241 = System.String::IsNullOrWhiteSpace(v477);\n\tv243 = v241 == 0;\n\tif (v243) goto L_00DE;\nL_FFFFFFFF:\n\tv371 = 0;\n\tgoto L_02A1;\nL_00DE:\n\tv481 = Newtonsoft.Json.Linq.JObject::Parse(v477);\n\tv483 = v481 == 0;\nL_FFFFFFFF:\n\tv370 = v477;\n\tif (v483) goto L_0258;\n\t*([rawJson @ X4 (System.String&)]) = v477;\n\tv521 = Newtonsoft.Json.Linq.JObject::get_Item(v481, \"reason\");\n\tv554 = v521 == 0;\n\tif (v554) goto L_00F7;\n\tv595 = Newtonsoft.Json.Linq.Extensions::Value(v521);\n\tv613 = v595 == 0;\n\tv600 = ~v613;\nL_FFFFFFFF:\n\tv614 = v595;\n\tif (v600) goto L_00FB;\nL_00F7:\n\tv603 = 0xB7D5000 + 0x538;\n\tv604 = *([v603 @ X8_v84 (System.Int32)+90]);\n\tv605 = *([v604 @ X8_v85+B8]);\n\tv614 = *([v605 @ X8_v86]);\nL_FFFFFFFF:\n\tv389 = v220;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v623_asT @ TEMPCOND_v10 (Newtonsoft.Json.Linq.JArray), typeof(Newtonsoft.Json.Linq.JArray), v650 @ X0_v70 (Newtonsoft.Json.Linq.JToken)\n\tv623 = v623_asT == 0;\nL_FFFFFFFF:\n\tv389 = v220;\n\tif (v623) goto L_0262;\n\tv791 = Newtonsoft.Json.Linq.JContainer::get_Count(v650);\n\tv798 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v798, v791);\n\tv823 = Newtonsoft.Json.Linq.JArray::GetEnumerator(v650);\n\tv833 = v823 == 0;\n\tif (v833) goto L_0228;\nL_FFFFFFFF:\n\tv874 = v823;\n\tgoto L_0151;\nL_0149:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v798, v761);\nL_014B:\n\tv853 = v283 == 0;\nL_FFFFFFFF:\n\tv874 = v283;\n\tif (v853) goto L_0228;\nL_0151:\n\tgoto L_0177;\n\tv746 = v283 == 0;\n\tif (v746) goto L_022C;\n\tgoto L_01A8;\n\tv1115 = Newtonsoft.Json.Linq.Extensions::Value(v1096);\nL_FFFFFFFF:\n\tv761 = v1115;\n\tgoto L_01B4;\nL_FFFFFFFF:\n\tv761 = 0;\n\tv1129 = v798 == 0;\n\tif (v1129) goto L_022A;\n\tv1155 = v798._version + 1;\n\tv798._version = v1155;\n\tv1148 = v798._items == 0;\n\tif (v1148) goto L_022A;\n\tgoto L_0149;\nL_01DA:\n\tv941 = &v283 @ stack_-68_v10 (System.Collections.Generic.IEnumerator`1<Newtonsoft.Json.Linq.JToken>);\n\tv942 = *([v941 @ X8_v52 (System.Int32)]) == 0;\nL_FFFFFFFF:\n\tv357 = 0;\nL_FFFFFFFF:\n\tv371 = &v283 @ stack_-68_v10 (System.Collections.Generic.IEnumerator`1<Newtonsoft.Json.Linq.JToken>);\n\tif (v942) goto L_020D;\n\tgoto L_020A;\n\tgoto L_0222;\n\tgoto L_02A1;\nL_0222:\n\tv1109 = System.Collections.Generic.List`1<System.String>::ToArray(v798);\n\t*([bypassedWarnings @ X3 (System.String[]&)]) = v1109;\nL_FFFFFFFF:\n\tv389 = v220;\n\tgoto L_0262;\nL_0228:\n\tv739 = new System.NullReferenceException();\n\tgoto L_035C;\nL_022A:\n\tv739 = new System.NullReferenceException();\n\tgoto L_035C;\nL_022C:\n\tv739 = new System.NullReferenceException();\n\tgoto L_035C;\nL_022F:\n\tv771 = new System.OutOfMemoryException();\n\tv490 = v357 != 1;\nL_FFFFFFFF:\n\tv474 = v771;\n\tif (v490) goto L_0360;\n\tv1111 = 0x8BF5BC4(v771, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1119 = 0xB7D5000 + 0x538;\n\tv585 = *([v1111 @ X0_v86]);\n\tv581 = \"il2cpp_vm_class_is_assignable_from\"(*([v1119 @ X8_v55 (System.Int32)+10]), *([v585 @ X8_v56]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv511 = v581 == 0;\n\tif (v511) goto L_02B5;\n\tv509 = 0x8BF5BF4(v581, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv370 = *([v941 @ X8_v52 (System.Int32)]);\nL_0258:\n\tv294 = this._lastUnparseableDoneLen != v370.Length;\n\tif (v294) goto L_02B1;\n\t*([v384 @ X23_v7 (System.String&)]) = \"<unparseable>\";\nL_FFFFFFFF:\n\tv389 = v220;\nL_027B:\n\tv783 = System.IO.Path::Combine(this.Root, v673);\n\tv788 = System.IO.File::Exists(v783);\n\tv793 = v788 == 0;\n\tif (v793) goto L_0289;\n\tSystem.IO.File::Delete(v783);\nL_0289:\n\tgoto L_0297;\nL_029C:\n\tv360 = System.IO.Path::Combine(this.Root, *([v389 @ X24_v4 (System.Int32)]));\n\tSystem.IO.File::Move(v360, v783);\nL_FFFFFFFF:\n\tv371 = 1;\nL_02B1:\n\tthis._lastUnparseableDoneLen = v370.Length;\nL_FFFFFFFF:\n\tv371 = 0;\n\tgoto L_02A1;\nL_02B5:\n\tv591 = 0x8BF5BAC(8, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v591 @ X0_v58 (System.Collections.Generic.List`1<System.String>)]) = *([v588 @ X22_v9]);\n\tv610 = 0xA67A000 + 0x440;\n\tv739 = System.Collections.Generic.List`1<System.String>::.ctor(v591, v610);\n\tgoto L_035C;\nL_035C:\n\t// 860 Interrupt\n\tv764 = 0x8BF5BF4(v739, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv474 = v739;\nL_0360:\n\tv774 = 0x8BF0368(v474, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v774, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_004D:\n\t*([reason @ X2 (System.String&)]) = 0;\n\tgoto L_0055;\nL_00CC:\n\tgoto L_00D1;\nL_02A1:\n\treturnVal1 = v371 & 1;\n\treturn returnVal1;\nL_00FB:\n\t*([reason @ X2 (System.String&)]) = v614;\n\tv650 = Newtonsoft.Json.Linq.JObject::get_Item(v481, \"bypassedWarnings\");\n\tv653 = v650 == 0;\nL_FFFFFFFF:\n\tv389 = v220;\n\tif (v653) goto L_0262;\nL_0262:\n\tthis._lastUnparseableDoneLen = -1;\n\tv277 = attempt;\n\tv382 = 0xB7D5000 + 0x538;\n\tv665 = \"il2cpp_vm_object_box\"(*([v382 @ X23_v6 (System.Int32)+48]), &v277 @ stack_-90_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv673 = System.String::Format(\"done-{0}{1}.json\", v665, archiveSuffix);\n\tgoto L_027B;\nL_0177:\n\tv937 = System.Collections.IEnumerator::MoveNext(v874);\n\tv939 = v937 == 0;\n\tif (v939) goto L_01DA;\nL_01A8:\n\tv1096 = System.Collections.Generic.IEnumerator`1<Newtonsoft.Json.Linq.JToken>::get_Current(v283);\n\tv1097 = v1096 == 0;\n\tif (v1097) goto L_FFFFFFFF;\nL_01B4:\n\n// ... truncated")]
		public unsafe bool TryConsumeDone(int attempt, out string reason, out string[] bypassedWarnings, out string rawJson, string archiveSuffix = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenerationWorkspace::TryConsumeDone");
			reason = default;
			bypassedWarnings = default;
			rawJson = default;
			return default;
		}

		[Token(Token = "0x6000E50")]
		[Address(RVA = "0x3F09AFC", Offset = "0x3F09AFC", Length = "0xC4")]
		public string FeedbackPath(int attempt)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string path = $"feedback-{arg}.md";
			return Path.Combine(Root, path);
		}

		[Token(Token = "0x6000E51")]
		[Address(RVA = "0x3F09BC0", Offset = "0x3F09BC0", Length = "0x28")]
		public void WriteFeedback(int attempt, string content)
		{
			string path = FeedbackPath(attempt);
			File.WriteAllText(path, content);
		}

		[Token(Token = "0x6000E52")]
		[Address(RVA = "0x3F09BE8", Offset = "0x3F09BE8", Length = "0x7C")]
		public string FeedbackFileName(int attempt)
		{
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"feedback-{arg}.md";
		}

		[Token(Token = "0x6000E53")]
		[Address(RVA = "0x3F09C64", Offset = "0x3F09C64", Length = "0x14")]
		public void Dispose()
		{
			if (!_disposed)
			{
				_disposed = true;
			}
		}
	}
}
