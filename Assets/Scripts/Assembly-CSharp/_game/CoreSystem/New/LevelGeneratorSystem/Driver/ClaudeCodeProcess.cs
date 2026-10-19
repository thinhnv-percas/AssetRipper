using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000371")]
	public sealed class ClaudeCodeProcess : IDisposable
	{
		[Token(Token = "0x4000A63")]
		public const string DefaultClaudeBinary = "claude";

		[Token(Token = "0x4000A64")]
		[FieldOffset(Offset = "0x10")]
		private readonly Process _process;

		[Token(Token = "0x4000A65")]
		[FieldOffset(Offset = "0x18")]
		private readonly ConcurrentQueue<string> _stdoutLines;

		[Token(Token = "0x4000A66")]
		[FieldOffset(Offset = "0x20")]
		private readonly ConcurrentQueue<string> _stderrLines;

		[Token(Token = "0x4000A68")]
		[FieldOffset(Offset = "0x30")]
		private DateTime? _finishedUtc;

		[Token(Token = "0x1700010F")]
		public bool HasExited
		{
			[Token(Token = "0x6000E28")]
			[Address(RVA = "0x3F05164", Offset = "0x3F05164", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.Diagnostics.Process::get_HasExited(this._process);\n\treturn returnVal1;\n")]
			get
			{
				return _process.HasExited;
			}
		}

		[Token(Token = "0x17000110")]
		public int ExitCode
		{
			[Token(Token = "0x6000E29")]
			[Address(RVA = "0x3F05180", Offset = "0x3F05180", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.Diagnostics.Process::get_ExitCode(this._process);\n\treturn returnVal1;\n")]
			get
			{
				return _process.ExitCode;
			}
		}

		[Token(Token = "0x17000111")]
		[field: Token(Token = "0x4000A67")]
		[field: FieldOffset(Offset = "0x28")]
		public DateTime StartedUtc
		{
			[Token(Token = "0x6000E2A")]
			[Address(RVA = "0x3F0519C", Offset = "0x3F0519C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.StartedUtc;\n")]
			get;
			[Token(Token = "0x6000E2B")]
			[Address(RVA = "0x3F051A4", Offset = "0x3F051A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.StartedUtc = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000112")]
		public double ElapsedSeconds
		{
			[Token(Token = "0x6000E2C")]
			[Address(RVA = "0x3F051AC", Offset = "0x3F051AC", Length = "0x178")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv71 = System.Diagnostics.Process::get_HasExited(this._process);\n\tv74 = ~v71;\n\tif (v74) goto L_0043;\n\tgoto L_0037;\nL_0037:\n\tv168 = System.DateTime::get_UtcNow();\n\tSystem.Nullable`1<System.DateTime>::.ctor(&v64 @ stack_-40_v4 (System.Nullable`1<System.DateTime>), v168);\n\tthis._finishedUtc = v64;\n\tv105 = *([this @ X0 (_game.CoreSystem.New.LevelGeneratorSystem.Driver.ClaudeCodeProcess)+38]);\n\tv116 = this.StartedUtc;\n\tgoto L_0066;\nL_0054:\n\tgoto L_0057;\nL_0057:\n\tv105 = System.DateTime::get_UtcNow();\n\tv116 = this.StartedUtc;\n\tgoto L_0066;\nL_0070:\n\treturnVal2 = System.TimeSpan::get_TotalSeconds(&v143 @ stack_-40_v2 (System.TimeSpan));\n\treturn returnVal2;\nL_0025:\n\tv48 = this._finishedUtc & 1;\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0043;\nL_0043:\n\tv78 = this._finishedUtc & 1;\n\tv79 = v78 == 0;\n\tif (v79) goto L_0054;\nL_0066:\n\tv121 = System.DateTime::op_Subtraction(v105, v116);\n\tv143 = v121;\n\tgoto L_0070;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::get_ElapsedSeconds");
				return default;
			}
		}

		[Token(Token = "0x6000E2D")]
		[Address(RVA = "0x3F05324", Offset = "0x3F05324", Length = "0x970")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0057;\n\tgoto L_0083;\nL_0083:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--print\");\n\tgoto L_00A6;\nL_00A6:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--output-format\");\n\tgoto L_00C9;\nL_00C9:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"stream-json\");\n\tgoto L_00EC;\nL_00EC:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--verbose\");\n\tgoto L_010D;\nL_010D:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--model\");\n\tgoto L_0131;\nL_0131:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, model);\n\tgoto L_0154;\nL_0154:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--allowedTools\");\n\tgoto L_0177;\nL_0177:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"Bash,Read,Write\");\n\tgoto L_019A;\nL_019A:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--permission-mode\");\n\tgoto L_01BD;\nL_01BD:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"acceptEdits\");\n\tgoto L_01E0;\nL_01E0:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--setting-sources\");\n\tgoto L_0207;\nL_0207:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"project,local\");\n\tv734 = System.String::IsNullOrEmpty(effort);\n\tv738 = v734 == 0;\n\tv739 = ~v738;\n\tif (v739) goto L_024D;\n\tgoto L_0231;\nL_0231:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--effort\");\n\tgoto L_0293;\nL_024D:\n\tv778 = ~resume;\n\tif (v778) goto L_0299;\nL_0254:\n\t;\n\tgoto L_0271;\nL_0271:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--resume\");\n\tv858 = v937._version + 1;\n\tv937._version = v858;\n\tv367 = v937._items;\n\tv864 = v937.Count;\n\tv866 = v937.Count < v367.Length;\n\tv867 = ~v866;\n\tif (v867) goto L_FFFFFFFF;\n\tv894 = v937.Count + 1;\n\tv937.Count = v894;\n\tv367[v864 @ X10_v25 (System.Int32)] = sessionId;\n\tgoto L_0330;\nL_0293:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, effort);\n\tv893 = ~resume;\n\tv786 = ~v893;\n\tif (v786) goto L_0254;\nL_0299:\n\tv405 = System.String::IsNullOrEmpty(sessionId);\n\tv811 = v405 == 0;\n\tv812 = ~v811;\n\tif (v812) goto L_02EE;\n\tgoto L_02C6;\nL_FFFFFFFF:\n\t;\n\tgoto L_032D;\nL_02C6:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--session-id\");\n\tgoto L_02E8;\nL_02E8:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, sessionId);\nL_02EE:\n\t;\n\tgoto L_030B;\nL_030B:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, \"--append-system-prompt\");\n\tv910 = v937._version + 1;\n\tv937._version = v910;\n\tv371 = v937._items;\n\tv933 = v937.Count;\n\tv943 = v937.Count < v371.Length;\n\tv929 = ~v943;\n\tif (v929) goto L_FFFFFFFF;\n\tv950 = v937.Count + 1;\n\tv937.Count = v950;\n\tv371[v933 @ X10_v20 (System.Int32)] = v935;\n\tgoto L_0330;\nL_FFFFFFFF:\n\t;\nL_0330:\n\t;\n\tgoto L_034F;\nL_034F:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v937, userPrompt);\n\treturn v937;\nL_0057:\n\tv937 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v937);\nL_032D:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v937, sessionId);\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<string> BuildArguments(string model, string systemPromptAppend, string userPrompt, string sessionId, bool resume, string effort = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::BuildArguments");
			return default;
		}

		[Token(Token = "0x6000E2E")]
		[Address(RVA = "0x3F05C94", Offset = "0x3F05C94", Length = "0xA38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_008C;\n\tv90 = new System.Collections.Concurrent.ConcurrentQueue`1<System.String>();\n\tSystem.Collections.Concurrent.ConcurrentQueue`1<System.String>::.ctor(v90);\n\tthis._stderrLines = v90;\n\tSystem.Object::.ctor(this);\n\tv112 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.ClaudeCodeProcess::ResolveBinaryPath(claudeBinary);\n\tv118 = new System.Diagnostics.Process();\n\tSystem.Diagnostics.Process::.ctor(v118);\n\tv130 = new System.Diagnostics.ProcessStartInfo();\n\tSystem.Diagnostics.ProcessStartInfo::.ctor(v130);\n\tv130.fileName = v112;\n\tv130.directory = workingDirectory;\n\tv130.RedirectStandardError = 1;\n\tv130.RedirectStandardInput = 0x100;\n\tv130.UseShellExecute = 0;\n\tv130.createNoWindow = 1;\n\tv534 = new System.Text.UTF8Encoding();\n\tSystem.Text.UTF8Encoding::.ctor(v534, 0);\n\tv130.StandardOutputEncoding = v534;\n\tv698 = new System.Text.UTF8Encoding();\n\tSystem.Text.UTF8Encoding::.ctor(v698, 0);\n\tv130.StandardErrorEncoding = v698;\n\tSystem.Diagnostics.Process::set_StartInfo(v118, v130);\n\tSystem.Diagnostics.Process::set_EnableRaisingEvents(v118, 1);\n\tv453 = this + 0x10;\n\tthis._process = v118;\n\tv343 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.ClaudeCodeProcess::BuildArguments(model, systemPromptAppend, userPrompt, sessionId, resume, effort);\n\tv398 = 0xB2F9000 + 0xA58;\n\tv401 = 0xB2E5000 + 0x208;\n\tv527 = 0xB2A7000 + 0x530;\n\tv850 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v343);\n\tv483 = v850._list;\n\tv577 = this._process == 0;\n\tif (v577) goto L_0346;\n\tv891 = System.Diagnostics.Process::get_StartInfo(this._process);\n\tv507 = System.Diagnostics.ProcessStartInfo::get_ArgumentList(v891);\n\tv509 = v507 == 0;\n\tif (v509) goto L_0344;\n\tSystem.Collections.ObjectModel.Collection`1<System.String>::Add(v507, v850.Current);\n\tgoto L_0117;\nL_012D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v483 @ stack_-80_v7 (System.Collections.Generic.List`1<System.String>));\nL_FFFFFFFF:\n\tv265 = &v483 @ stack_-80_v7 (System.Collections.Generic.List`1<System.String>);\nL_FFFFFFFF:\n\tv720 = 0;\nL_FFFFFFFF:\n\tv428 = timeoutSec;\nL_FFFFFFFF:\n\tv432 = workingDirectory;\n\tv345 = System.Diagnostics.Process::get_StartInfo(*([v453 @ X20_v3]));\n\tv346 = System.Diagnostics.ProcessStartInfo::get_EnvironmentVariables(v345);\n\tv870 = System.Collections.Specialized.StringDictionary::set_Item(v346, \"LG_WORKSPACE\", workspaceRoot);\n\tv871 = v428 & 1;\n\tv872 = v871 == 0;\n\tif (v872) goto L_0165;\n\tv348 = System.Diagnostics.Process::get_StartInfo(*([v453 @ X20_v3]));\n\tv893 = System.Diagnostics.ProcessStartInfo::get_EnvironmentVariables(v348);\n\tv897 = System.Nullable`1<System.Int32>::get_Value(&v428 @ stack_-68_v2 (System.Nullable`1<System.Int32>));\n\tv243 = v897;\n\tv349 = System.Int32::ToString(&v243 @ stack_-84_v10 (System.Int32));\n\tv882 = System.Collections.Specialized.StringDictionary::set_Item(v893, \"LG_TIMEOUT_SEC\", v349);\n\tv350 = System.Diagnostics.Process::get_StartInfo(*([v453 @ X20_v3]));\n\tv351 = System.Diagnostics.ProcessStartInfo::get_EnvironmentVariables(v350);\n\tv899 = System.Collections.Specialized.StringDictionary::ContainsKey(v351, *([v398 @ X27_v4 (System.Int32)]));\n\tv901 = v899 == 0;\n\tif (v901) goto L_018A;\n\tv353 = System.Diagnostics.Process::get_StartInfo(*([v453 @ X20_v3]));\n\tv354 = System.Diagnostics.ProcessStartInfo::get_EnvironmentVariables(v353);\n\tv936 = System.Collections.Specialized.StringDictionary::get_Item(v354, *([v398 @ X27_v4 (System.Int32)]));\nL_FFFFFFFF:\n\tv676 = v936;\n\tgoto L_01A1;\nL_018A:\n\t;\n\tv904 = System.Environment::GetEnvironmentVariable(*([v398 @ X27_v4 (System.Int32)]));\n\tv918 = v904 != 0;\n\tif (v918) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv676 = *([v401 @ X22_v3 (System.String)]);\n\tgoto L_01A1;\nL_FFFFFFFF:\n\tv676 = v904;\nL_FFFFFFFF:\n\tv443 = *([v401 @ X22_v3 (System.String)]);\n\tgoto L_01B6;\nL_FFFFFFFF:\n\tv443 = v945;\nL_01BD:\n\tv960 = System.IO.Path::Combine(v432, \"Assets/LevelGenerator/scripts\");\n\tv962 = System.IO.Path::GetFullPath(v960);\n\t// 453 NewArr v355 @ X0_v38 (System.String[]), typeof(System.String[]), 5\n\tv668 = v355.Length == 0;\nL_FFFFFFFF:\n\tv653 = 5;\nL_FFFFFFFF:\n\tv675 = v398;\nL_FFFFFFFF:\n\tv432 = v355;\nL_FFFFFFFF:\n\tv689 = v962;\nL_FFFFFFFF:\n\tv692 = v453;\n\tif (v668) goto L_034A;\n\tv355[0] = v962;\n\tv669 = v355.Length & -2;\n\tv619 = v669 == 0;\nL_FFFFFFFF:\n\tv653 = v962;\nL_FFFFFFFF:\n\tv675 = v398;\nL_FFFFFFFF:\n\tv432 = v355;\nL_FFFFFFFF:\n\tv689 = v962;\nL_FFFFFFFF:\n\tv692 = v453;\n\tif (v619) goto L_034A;\n\tv689 = v355 + 0x28;\n\t*([v689 @ X25_v12 (System.String)]) = \"/usr/local/bin\";\n\tv971 = *([v689 @ X25_v12 (System.String)-10]) < 2;\n\tv633 = ~v971;\n\tv629 = *([v689 @ X25_v12 (System.String)-10]) - 2;\n\tv620 = v629 == 0;\n\tv972 = ~v633;\n\tv601 = v972 | v620;\nL_FFFFFFFF:\n\tv653 = \"/usr/local/bin\";\nL_FFFFFFFF:\n\tv675 = v398;\nL_FFFFFFFF:\n\tv432 = v355;\nL_FFFFFFFF:\n\tv692 = v453;\n\tif (v601) goto L_034A;\n\tv355[2] = \"/opt/homebrew/bin\";\n\tv981 = System.String::IsNullOrEmpty(v443);\n\tv984 = v981 == 0;\n\tv985 = ~v984;\nL_FFFFFFFF:\n\tv658 = 0;\n\tif (v985) goto L_020A;\n\tgoto L_0208;\nL_0208:\n\tv992 = System.IO.Path::Combine(v443, \".local/bin\");\nL_FFFFFFFF:\n\tv658 = v992;\n\tv355[3] = v658;\n\tv1006 = System.String::IsNullOrEmpty(v443);\n\tv1009 = v1006 == 0;\n\tv1010 = ~v1009;\nL_FFFFFFFF:\n\tv659 = 0;\n\tif (v1010) goto L_022A;\n\tgoto L_0228;\nL_0228:\n\tv1017 = System.IO.Path::Combine(v443, \"bin\");\nL_FFFFFFFF:\n\tv659 = v1017;\n\tv689 = v355 + 0x40;\n\t*([v689 @ X25_v12 (System.String)]) = v659;\n\tv1033 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v1033);\n\tv681 = *([v689 @ X25_v12 (System.String)-28]);\n\tv1049 = *([v689 @ X25_v12 (System.String)-28]) < 1;\n\tif (v1049) goto L_027A;\n\tv1051 = v1033 == 0;\nL_FFFFFFFF:\n\tv243 = 0;\nL_FFFFFFFF:\n\tv310 = 0;\nL_FFFFFFFF:\n\tv656 = Il2CppMethodInfo;\n\tif (v1051) goto L_0259;\nL_FFFFFFFF:\n\tv243 = 0;\nL_FFFFFFFF:\n\tv652 = 0;\nL_FFFFFFFF:\n\tv657 = Il2CppMethodInfo;\n\tgoto L_02B4;\nL_0259:\n\tv1096 = v310 < v681;\n\tv237 = ~v1096;\nL_FFFFFFFF:\n\tv653 = v656;\nL_FFFFFFFF:\n\tv675 = v398;\nL_FFFFFFFF:\n\tv432 = v355;\nL_FFFFFFFF:\n\tv692 = v453;\n\tif (v237) goto L_034A;\n\tv356 = System.String::IsNullOrEmpty(v355[v310 @ X9_v13 (System.Int32)]);\n\tv310 = v243 + 1;\n\tv681 = v355.Length;\n\tv1055 = v310 < v355.Length;\nL_FFFFFFFF:\n\tv243 = v310;\nL_FFFFFFFF:\n\tv656 = 0;\n\tif (v1055) goto L_0259;\nL_027A:\n\tv357 = System.String::IsNullOrEmpty(v676);\n\tv1098 = v357 == 0;\n\tv1099 = ~v1098;\n\tif (v1099) goto L_02EC;\n\tgoto L_02E7;\nL_02A4:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v1033, v355[v652 @ X9_v15 (System.Int32)]);\nL_FFFFFFFF:\n\tv1079 = v355[v652 @ X9_v15 (System.Int32)];\nL_02A6:\n\tv652 = v243 + 1;\n\tv681 = v355.Length;\n\tv1056 = v652 >= v355.Length;\nL_FFFFFFFF:\n\tv243 = v652;\nL_FFFFFFFF:\n\tv657 = v1079;\n\tif (v1056) goto L_027A;\nL_02B4:\n\tv1108 = v652 < v681;\n\tv239 = ~v1108;\nL_FFFFFFFF:\n\tv653 = v657;\nL_FFFFFFFF:\n\tv675 = v398;\nL_FFFFFFFF:\n\tv432 = v355;\nL_FFFFFFFF:\n\tv692 = v453;\n\tif (v239) goto L_034A;\n\tv689 = v355[v652 @ X9_v15 (System.Int32)];\n\tv358 = System.String::IsNullOrEmpty(v355[v652 @ X9_v15 (System.Int32)]);\n\tv1136 = v358 == 0;\n\tv1137 = ~v1136;\nL_FFFFFFFF:\n\tv1079 = 0;\n\tif (v1137) goto L_02A6;\n\tgoto L_02A4;\nL_02E7:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v1033, v676);\nL_02EC:\n\tv360 = System.Diagnostics.Process::get_StartInfo(*([v453 @ X20_v3]));\n\tv1178 = System.Diagnostics.ProcessStartInfo::get_EnvironmentVariables(v360);\n\tv361 = System.String::Join(\":\", v1033);\n\tv1190 = System.Collections.Specialized.StringDictionary::set_Item(v1178, *([v398 @ X27_v4 (System.Int32)]), v361);\n\tv362 = new System.Diagnostics.DataReceivedEventHandler();\n\tSystem.Diagnostics.DataReceivedEventHandler::.ctor(v362, this, Il2CppMethodInfo);\n\tSystem.Diagnostics.Process::add_OutputDataReceived(this._process, v362);\n\tv363 = new System.Diagnostics.DataReceivedEventHandler();\n\tSystem.Diagnostics.DataReceivedEventHandler::.ctor(v363, this, Il2CppMethodInfo);\n\tSystem.Diagnostics.Process::add_ErrorDataReceived(this._process, v363);\n\tv364 = new System.EventHandler();\n\tSystem.EventHandler::.ctor(v364, this, Il2CppMethodInfo);\n\tSystem.Diagnostics.Process::add_Exited(this._process, v364);\n\treturn;\nL_0344:\n\tv529 = new System.NullReferenceException();\nL\n// ... truncated")]
		public unsafe ClaudeCodeProcess(string workingDirectory, string workspaceRoot, string userPrompt, string systemPromptAppend, string model = "opus", string claudeBinary = null, int? timeoutSec = null, string sessionId = null, bool resume = false, string effort = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::.ctor");
		}

		[Token(Token = "0x6000E2F")]
		[Address(RVA = "0x3F06EF4", Offset = "0x3F06EF4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0015;\nL_0015:\n\tv50 = System.DateTime::get_UtcNow();\n\tthis.StartedUtc = v50;\n\tv58 = this._process == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002E;\n\tgoto L_0041;\nL_002E:\n\tv68 = System.Diagnostics.Process::Start(this._process);\n\tSystem.Diagnostics.Process::BeginOutputReadLine(this._process);\n\tSystem.Diagnostics.Process::BeginErrorReadLine(this._process);\n\treturn;\nL_0041:\n\tthrow System.NullReferenceException;\n")]
		public void Start()
		{
			DateTime utcNow = DateTime.UtcNow;
			StartedUtc = utcNow;
			if (_process != null)
			{
				bool flag = _process.Start();
				_process.BeginOutputReadLine();
				_process.BeginErrorReadLine();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000E30")]
		[Address(RVA = "0x3F06FB0", Offset = "0x3F06FB0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Concurrent.ConcurrentQueue`1<System.String>::TryDequeue(this._stdoutLines, v40);\n\treturn returnVal1;\n")]
		public bool TryDequeueStdout(out string line)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::TryDequeueStdout");
			line = default;
			return default;
		}

		[Token(Token = "0x6000E31")]
		[Address(RVA = "0x3F07014", Offset = "0x3F07014", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Concurrent.ConcurrentQueue`1<System.String>::TryDequeue(this._stderrLines, v40);\n\treturn returnVal1;\n")]
		public bool TryDequeueStderr(out string line)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::TryDequeueStderr");
			line = default;
			return default;
		}

		[Token(Token = "0x6000E32")]
		[Address(RVA = "0x3F07078", Offset = "0x3F07078", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this._process == 0;\n\tif (v13) goto L_0036;\n\tv15 = System.Diagnostics.Process::get_HasExited(this._process);\n\tv33 = v15 == 0;\n\tv34 = ~v33;\n\tif (v34) goto L_0023;\n\tv36 = this._process == 0;\n\tif (v36) goto L_0038;\n\tv68 = System.Diagnostics.Process::get_Id(this._process);\n\tv38 = v68 < 1;\n\tif (v38) goto L_0023;\n\t_game.CoreSystem.New.LevelGeneratorSystem.Driver.ClaudeCodeProcess::TryKillProcessTree(v68);\nL_0023:\n\tv70 = this._process == 0;\n\tif (v70) goto L_005D;\n\tv90 = System.Diagnostics.Process::get_HasExited(this._process);\n\tv96 = v90 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0035;\n\tv83 = this._process == 0;\n\tif (v83) goto L_003A;\n\tSystem.Diagnostics.Process::Kill(this._process);\nL_0035:\n\treturn;\nL_0036:\n\tv84 = new System.NullReferenceException();\n\tgoto L_0091;\nL_0038:\n\tv84 = new System.NullReferenceException();\n\tgoto L_0091;\nL_003A:\n\tv84 = new System.NullReferenceException();\n\tgoto L_0091;\nL_005D:\n\tv84 = new System.NullReferenceException();\n\tgoto L_0091;\nL_0091:\n\t// 145 Interrupt\n\tv89 = 0x8BF5BF4(v84, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv92 = 0x8BF0368(v84, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv98 = 0xA1B8(v92, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public void Kill()
		{
			if (_process != null)
			{
				if (!_process.HasExited)
				{
					if (_process == null)
					{
						NullReferenceException ex = new NullReferenceException();
						goto IL_015d;
					}
					int id = _process.Id;
					if (id >= 1)
					{
						TryKillProcessTree(id);
					}
				}
				if (_process != null)
				{
					if (_process.HasExited)
					{
						return;
					}
					if (_process != null)
					{
						_process.Kill();
						return;
					}
					NullReferenceException ex = new NullReferenceException();
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
			}
			goto IL_015d;
			IL_015d:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
		}

		[Token(Token = "0x6000E33")]
		[Address(RVA = "0x3F07204", Offset = "0x3F07204", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = rootPid;\n\tgoto L_0029;\n\tv59 = System.Int32::ToString(&v14 @ stack_-34_v1 (System.Int32));\n\tv137 = System.String::Concat(\"kt() { local p=\\\"$1\\\"; local k; for k in $(/usr/bin/pgrep -P \\\"$p\\\" 2>/dev/null); do kt \\\"$k\\\"; done; kill -9 \\\"$p\\\" 2>/dev/null; }; kt \", v59);\n\tv195 = new System.Diagnostics.ProcessStartInfo();\n\tSystem.Diagnostics.ProcessStartInfo::.ctor(v195);\n\tv199 = v195 == 0;\n\tif (v199) goto L_00AF;\n\tv195.fileName = \"/bin/bash\";\n\tv195.UseShellExecute = 0;\n\tv195.createNoWindow = 1;\n\tv195.RedirectStandardOutput = 0x101;\n\tv209 = System.Diagnostics.ProcessStartInfo::get_ArgumentList(v195);\n\tv210 = v209 == 0;\n\tif (v210) goto L_00B1;\n\tSystem.Collections.ObjectModel.Collection`1<System.String>::Add(v209, \"-c\");\n\tv232 = System.Diagnostics.ProcessStartInfo::get_ArgumentList(v195);\n\tv220 = v232 == 0;\n\tif (v220) goto L_00B3;\n\tSystem.Collections.ObjectModel.Collection`1<System.String>::Add(v232, v137);\n\tv237 = System.Diagnostics.Process::Start(v195);\n\tv239 = v237 == 0;\n\tif (v239) goto L_0072;\n\tv240 = System.Diagnostics.Process::WaitForExit(v237, 0xBB8);\n\tv251 = v240 == 0;\n\tv247 = ~v251;\n\tif (v247) goto L_0072;\n\tv221 = v106 == 0;\n\tif (v221) goto L_00B7;\n\tSystem.Diagnostics.Process::Kill(v106);\nL_0072:\n\tv248 = &v106 @ stack_-40_v5 (System.Diagnostics.Process);\n\tv249 = *([v248 @ X8_v14]) == 0;\n\tif (v249) goto L_00A6;\n\tgoto L_00A2;\nL_00AE:\n\treturn;\nL_00AF:\n\tthrow v195;\nL_00B1:\n\tv216 = new System.NullReferenceException();\n\tgoto L_0131;\nL_00B3:\n\tv216 = new System.NullReferenceException();\n\tgoto L_0131;\nL_00B5:\n\tv218 = new System.OutOfMemoryException();\n\tv216 = v218;\n\tgoto L_0131;\nL_00B7:\n\tv216 = new System.NullReferenceException();\n\tgoto L_0131;\nL_0131:\n\t// 305 Interrupt\n\tv225 = 0x8BF5BF4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv230 = 0x8BF0368(v216, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv178 = 0xA1B8(v230, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0029:\n\tv49 = System.IO.File::Exists(\"/bin/bash\");\n\tv53 = ~v49;\n\tif (v53) goto L_00AE;\nL_00A6:\n\tgoto L_00B5;\nL_00A2:\n\tSystem.IDisposable::Dispose(*([v248 @ X8_v14]));\n")]
		private static void TryKillProcessTree(int rootPid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::TryKillProcessTree");
		}

		[Token(Token = "0x6000E34")]
		[Address(RVA = "0x3F075B0", Offset = "0x3F075B0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.LevelGeneratorSystem.Driver.ClaudeCodeProcess::Kill(this);\n\tSystem.ComponentModel.Component::Dispose(this._process);\n\treturn;\n")]
		public void Dispose()
		{
			Kill();
			_process.Dispose();
		}

		[Token(Token = "0x6000E35")]
		[Address(RVA = "0x3F066CC", Offset = "0x3F066CC", Length = "0x828")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv87 = \"claude\";\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv87 = nameOrPath;\nL_006D:\n\tv96 = System.IO.Path::IsPathRooted(v87);\n\tv101 = ~v96;\n\tv102 = ~v101;\n\tif (v102) goto L_007A;\n\tgoto L_0087;\nL_007A:\n\tv115 = System.IO.File::Exists(v87);\n\tv133 = v115 == 0;\n\tv122 = ~v133;\n\tif (v122) goto L_FFFFFFFF;\nL_0087:\n\tv131 = System.Environment::GetEnvironmentVariable(\"HOME\");\n\tv147 = v131 != 0;\n\tif (v147) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv368 = \"\";\n\tgoto L_009A;\nL_FFFFFFFF:\n\tv368 = v131;\n\tv191 = v371 + 0x20;\n\t*([v191 @ X22_v8]) = \"/usr/local/bin\";\n\tv565 = v371 + 0x28;\n\t*([v565 @ X0_v25]) = \"/opt/homebrew/bin\";\n\tv574 = System.String::IsNullOrEmpty(v368);\n\tv580 = v574 == 0;\n\tv581 = ~v580;\nL_FFFFFFFF:\n\tv486 = 0;\n\tif (v581) goto L_00DA;\n\tgoto L_00CA;\nL_00CA:\n\tv588 = System.IO.Path::Combine(v368, \".local/bin\");\nL_FFFFFFFF:\n\tv486 = v588;\nL_00DA:\n\tv599 = v371 + 0x30;\n\t*([v599 @ X0_v31]) = v486;\n\tv603 = System.String::IsNullOrEmpty(v368);\n\tv606 = v603 == 0;\n\tv607 = ~v606;\nL_FFFFFFFF:\n\tv487 = 0;\n\tif (v607) goto L_00FA;\n\tgoto L_00F0;\nL_00F0:\n\tv614 = System.IO.Path::Combine(v368, \"bin\");\nL_FFFFFFFF:\n\tv487 = v614;\nL_00FA:\n\tv624 = v371 + 0x38;\n\t*([v624 @ X0_v37]) = v487;\n\tv628 = System.String::IsNullOrEmpty(v368);\n\tv631 = v628 == 0;\n\tv632 = ~v631;\nL_FFFFFFFF:\n\tv488 = 0;\n\tif (v632) goto L_0120;\n\tgoto L_0110;\nL_0110:\n\tv639 = System.IO.Path::Combine(v368, \".claude/local\");\nL_FFFFFFFF:\n\tv488 = v639;\nL_0120:\n\tv650 = v371 + 0x40;\n\t*([v650 @ X21_v10]) = v488;\n\tv664 = *([v650 @ X21_v10-28]) < 1;\n\tif (v664) goto L_015E;\nL_FFFFFFFF:\n\tv298 = 0;\n\tgoto L_014E;\nL_0136:\n\tv726 = System.IO.Path::Combine(v371[v298 @ X25_v9 (System.Int32)], v87);\n\tv337 = System.IO.File::Exists(v726);\n\tv730 = v337 == 0;\n\tv340 = ~v730;\nL_FFFFFFFF:\n\tv349 = v726;\n\tif (v340) goto L_0303;\nL_013E:\n\tv298 = v298 + 1;\n\tv670 = v298 >= v371.Length;\n\tif (v670) goto L_015E;\nL_014E:\n\tv700 = System.String::IsNullOrEmpty(v371[v298 @ X25_v9 (System.Int32)]);\n\tv704 = v700 == 0;\n\tv705 = ~v704;\n\tif (v705) goto L_013E;\n\tgoto L_0136;\nL_015E:\n\tv690 = System.Environment::GetEnvironmentVariable(\"SHELL\");\n\tv702 = System.String::IsNullOrEmpty(v690);\n\tv707 = v702 == 0;\n\tv708 = ~v707;\n\tif (v708) goto L_01AD;\n\tv716 = System.IO.File::Exists(v690);\n\tv720 = v716 == 0;\n\tif (v720) goto L_01AD;\n\t// 366 NewArr v460 @ X0_v106 (System.String[]), typeof(System.String[]), 3\n\tv463 = v460 == 0;\n\tif (v463) goto L_0305;\n\tv190 = v460 + 0x20;\n\t*([v190 @ X22_v20]) = v690;\n\tv271 = v460 + 0x28;\n\t*([v271 @ X21_v24]) = \"/bin/zsh\";\n\tv799 = v460 + 0x30;\n\t*([v799 @ X0_v112]) = \"/bin/bash\";\n\tv204 = v460.Length >= 1;\nL_FFFFFFFF:\n\tv261 = v460;\n\tif (v204) goto L_01D9;\n\tgoto L_FFFFFFFF;\nL_01AD:\n\t// 429 NewArr v461 @ X0_v97 (System.String[]), typeof(System.String[]), 2\n\tv464 = v461 == 0;\n\tif (v464) goto L_0305;\n\tv272 = v461 + 0x20;\n\t*([v272 @ X21_v22]) = \"/bin/zsh\";\n\tv740 = v461 + 0x28;\n\t*([v740 @ X0_v101]) = \"/bin/bash\";\n\tv205 = v461.Length < 1;\nL_FFFFFFFF:\n\tv261 = v461;\n\tif (v205) goto L_FFFFFFFF;\nL_01D9:\n\tv182 = v261 + 0x20;\nL_FFFFFFFF:\n\tv194 = 0;\nL_FFFFFFFF:\n\tv911 = 0;\n\tgoto L_01F6;\nL_01F6:\n\tv795 = System.IO.File::Exists(*([v182 @ X25_v7+v194 @ X24_v7 (System.Int32)*8]));\n\tv800 = ~v795;\n\tif (v800) goto L_01E6;\n\tv805 = new System.Diagnostics.ProcessStartInfo();\n\tSystem.Diagnostics.ProcessStartInfo::.ctor(v805);\n\tv827 = v805 == 0;\n\tif (v827) goto L_0297;\n\tv805.fileName = *([v182 @ X25_v7+v194 @ X24_v7 (System.Int32)*8]);\n\tv805.RedirectStandardOutput = 0x101;\n\tv805.UseShellExecute = 0;\n\tv805.createNoWindow = 1;\n\tv837 = System.Diagnostics.ProcessStartInfo::get_ArgumentList(v805);\n\tv838 = v837 == 0;\n\tif (v838) goto L_0299;\n\tSystem.Collections.ObjectModel.Collection`1<System.String>::Add(v837, \"-lc\");\n\tv869 = System.Diagnostics.ProcessStartInfo::get_ArgumentList(v805);\n\tv872 = System.String::Concat(\"command -v \", v87);\n\tv855 = v869 == 0;\n\tif (v855) goto L_029B;\n\tSystem.Collections.ObjectModel.Collection`1<System.String>::Add(v869, v872);\n\tv875 = System.Diagnostics.Process::Start(v805);\n\tv856 = v875 == 0;\n\tif (v856) goto L_029D;\n\tv876 = System.Diagnostics.Process::get_StandardOutput(v875);\n\tv857 = v876 == 0;\n\tif (v857) goto L_029F;\n\tv877 = System.IO.StreamReader::ReadToEnd(v876);\n\tv858 = v877 == 0;\n\tif (v858) goto L_02A1;\n\tv878 = System.String::Trim(v877);\n\tv860 = v875 == 0;\n\tif (v860) goto L_02A5;\n\tv882 = System.Diagnostics.Process::WaitForExit(v875, 0x7D0);\n\tv885 = System.String::IsNullOrEmpty(v878);\n\tv887 = v885 == 0;\n\tv888 = ~v887;\n\tif (v888) goto L_0255;\n\tv891 = System.IO.File::Exists(v878);\n\tv895 = v891 == 0;\n\tif (v895) goto L_0255;\n\tv910 = &v59 @ stack_-68_v1;\n\tv901 = *([v910 @ X8_v49]);\n\tv939 = *([v910 @ X8_v49]) == 0;\n\tv906 = ~v939;\nL_FFFFFFFF:\n\tv907 = 0x15;\nL_FFFFFFFF:\n\tv911 = v878;\n\tif (v906) goto L_025F;\nL_FFFFFFFF:\n\tv343 = 0x15;\nL_FFFFFFFF:\n\tv349 = v878;\n\tgoto L_0289;\nL_0255:\n\tv897 = &v59 @ stack_-68_v1;\n\tv901 = *([v897 @ X8_v48]);\n\tv899 = *([v897 @ X8_v48]) == 0;\nL_FFFFFFFF:\n\tv907 = 0x16;\nL_FFFFFFFF:\n\tv343 = 0x16;\nL_FFFFFFFF:\n\tv349 = v911;\n\tif (v899) goto L_0289;\nL_025F:\n\tgoto L_0285;\n\tv341 = v343 == 0;\nL_FFFFFFFF:\n\tv911 = v349;\n\tif (v341) goto L_01E6;\n\tv326 = v343 == 0x16;\nL_FFFFFFFF:\n\tv911 = v349;\n\tif (v326) goto L_01E6;\n\tgoto L_0303;\nL_0297:\n\tthrow v805;\nL_0299:\n\tthrow System.NullReferenceException;\nL_029B:\n\tthrow System.NullReferenceException;\nL_029D:\n\tthrow System.NullReferenceException;\nL_029F:\n\tthrow System.NullReferenceException;\nL_02A1:\n\tthrow System.NullReferenceException;\nL_02A3:\n\tthrow System.OutOfMemoryException;\nL_02A5:\n\tthrow System.NullReferenceException;\nL_0305:\n\tv470 = new System.NullReferenceException();\n\tgoto L_0308;\nL_0308:\n\tv557 = 0x8BF5BF4(v470, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv568 = 0x8BF0368(v470, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv575 = 0xA1B8(v568, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v575, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0051:\n\tv59 = 0;\n\tv63 = System.String::IsNullOrEmpty(nameOrPath);\n\tv72 = v63 == 0;\n\tv77 = ~v72;\n\tv78 = ~v77;\n\tif (v78) goto L_FFFFFFFF;\nL_006A:\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv349 = v87;\nL_009A:\n\t// 154 NewArr v371 @ X0_v12 (System.String[]), typeof(System.String[]), 5\n\tv427 = v371 == 0;\n\tif (v427) goto L_0305;\nL_0303:\n\treturn v349;\nL_01E6:\n\tv194 = v194 + 1;\n\tv206 = v194 >= *([v261 @ X20_v11+18]);\n\tif (v206) goto L_FFFFFFFF;\nL_0289:\n\tgoto L_02A3;\nL_0285:\n\tSystem.IDisposable::Dispose(v901);\nL_FFFFFFFF:\n\tv343 = v907;\nL_FFFFFFFF:\n\tv349 = v911;\n")]
		public static string ResolveBinaryPath(string nameOrPath)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ClaudeCodeProcess::ResolveBinaryPath");
			return default;
		}
	}
}
