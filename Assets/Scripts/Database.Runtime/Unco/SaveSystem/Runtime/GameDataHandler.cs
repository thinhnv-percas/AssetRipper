using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.InitializationSystem.Runtime;
using Unco.SaveSystem.Core;
using Unco.SaveSystem.Core.Variables;
using UnityEngine;

namespace Unco.SaveSystem.Runtime
{
	[Token(Token = "0x2000004")]
	public class GameDataHandler : IInitializable
	{
		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003C_003Ec__DisplayClass32_0
		{
			[Token(Token = "0x4000015")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public KeyValuePair<string, object> pair;

			[Token(Token = "0x600002A")]
			[Address(RVA = "0x3F43824", Offset = "0x3F43824", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass32_0()
			{
			}

			internal bool _003CConvertToDictAndRefreshCaches_003Eb__0(IPermanentVariable variable)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameDataHandler._003C_003Ec__DisplayClass32_0::_003CConvertToDictAndRefreshCaches_003Eb__0");
				return default;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x200000C")]
		private struct _003CInitOnReady_003Ed__20 : IAsyncStateMachine
		{
			[Token(Token = "0x4000016")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4000017")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncVoidMethodBuilder _003C_003Et__builder;

			[Token(Token = "0x4000018")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public GameDataHandler _003C_003E4__this;

			[Token(Token = "0x4000019")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private Task<Dictionary<string, object>> _003CrowData_003E5__2;

			[Token(Token = "0x400001A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private TaskAwaiter<Dictionary<string, object>> _003C_003Eu__1;

			[Token(Token = "0x600002C")]
			[Address(RVA = "0x3F442D8", Offset = "0x3F442D8", Length = "0x40C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv49 = this.<>4__this;\n\tv50 = this.<>4__this == 0;\n\tif (v50) goto L_0104;\n\tv59 = v49._useLocal == 0;\n\tif (v59) goto L_0040;\n\tv129 = System.String::op_Inequality(v49._localUpToDateIdfv, \"\");\nL_0040:\n\tgoto L_0047;\nL_0047:\n\tgoto L_0050;\nL_0053:\n\tv214 = v212.<RemoteDataHandler>k__BackingField == 0;\n\tv215 = ~v214;\n\tif (v215) goto L_0066;\n\tgoto L_00E6;\nL_0059:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = -1;\n\tv97 = this.<>u__1;\n\tgoto L_00C5;\nL_0066:\n\tgoto L_006C;\nL_006C:\n\tgoto L_0076;\n\tgoto L_00AA;\n\tv425 = System.Threading.Tasks.Task`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>::GetAwaiter(this.<rowData>5__2);\n\tv109 = System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>::get_IsCompleted(&v97 @ stack_-38_v5 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>));\n\tv111 = v109 == 0;\n\tif (v111) goto L_00F5;\nL_00C5:\n\tv120 = System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>::GetResult(&v97 @ stack_-38_v5 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>));\n\tv143 = this.<rowData>5__2 == 0;\n\tif (v143) goto L_0106;\n\tv188 = System.Threading.Tasks.Task`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>::get_Result(this.<rowData>5__2);\n\tgoto L_00DF;\nL_00E6:\n\tUnco.SaveSystem.Runtime.GameDataHandler::TryCacheRemoteLastSavedTime();\n\tthis.<>1__state = -2;\n\tSystem.Runtime.CompilerServices.AsyncVoidMethodBuilder::SetResult(&this.<>t__builder (System.Runtime.CompilerServices.AsyncVoidMethodBuilder));\nL_00F4:\n\treturn;\nL_00F5:\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v97;\n\tSystem.Runtime.CompilerServices.AsyncVoidMethodBuilder::AwaitUnsafeOnCompleted(&this.<>t__builder (System.Runtime.CompilerServices.AsyncVoidMethodBuilder), &v97 @ stack_-38_v5 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Object>), this);\n\tgoto L_00F4;\nL_0104:\n\tv171 = new System.NullReferenceException();\n\tgoto L_0149;\nL_0106:\n\tv171 = new System.NullReferenceException();\n\tgoto L_0149;\nL_0108:\n\tv171 = new System.NullReferenceException();\n\tgoto L_0149;\nL_010A:\n\tv171 = new System.NullReferenceException();\n\tgoto L_0149;\nL_0149:\n\t// 329 Interrupt\n\tv184 = 0x8BF5BF4(v171, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv202 = 0x8BF0368(v171, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv217 = 0xA1B8(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_002B:\n\tv45 = this.<>1__state == 0;\n\tif (v45) goto L_0059;\nL_0050:\n\tgoto L_0053;\nL_0076:\n\tgoto L_007B;\nL_00AA:\n\tv417 = Unco.SaveSystem.Core.IDataLoader::LoadUserDataAsync(v179.<RemoteDataHandler>k__BackingField);\n\tthis.<rowData>5__2 = v417;\n\tv177 = this.<rowData>5__2 == 0;\n\tif (v177) goto L_010A;\nL_00DF:\n\tv227.<InitialUserData>k__BackingField = v188;\n\tthis.<rowData>5__2 = 0;\nL_007B:\n\tv176 = v179.<RemoteDataHandler>k__BackingField == 0;\n\tif (v176) goto L_0108;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameDataHandler._003CInitOnReady_003Ed__20::MoveNext");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x3F446E4", Offset = "0x3F446E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Runtime.CompilerServices.AsyncVoidMethodBuilder::SetStateMachine(&this.<>t__builder (System.Runtime.CompilerServices.AsyncVoidMethodBuilder), stateMachine);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Token(Token = "0x4000006")]
		public const string SAVE_TIME_KEY = "saveTime";

		[Token(Token = "0x4000007")]
		public const string LOCAL_UP_TO_DATE_IDFV_KEY = "local_up_to_date_idfv";

		[Token(Token = "0x400000A")]
		private static List<IPermanentVariable> PermanentVariables;

		[CompilerGenerated]
		[Token(Token = "0x400000B")]
		private static DateTime? _003CRemoteLastSavedDateTime_003Ek__BackingField;

		[Token(Token = "0x400000C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private string _localUpToDateIdfv;

		[Token(Token = "0x400000D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private bool _useLocal;

		[Token(Token = "0x17000001")]
		[field: Token(Token = "0x4000008")]
		private static Dictionary<string, object> InitialUserData
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x3F41478", Offset = "0x3F41478", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<InitialUserData>k__BackingField;\n")]
			get;
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x3F414C4", Offset = "0x3F414C4", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv45.<InitialUserData>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000002")]
		[field: Token(Token = "0x4000009")]
		private static Dictionary<string, object> InjectedUserData
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x3F41520", Offset = "0x3F41520", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.<InjectedUserData>k__BackingField;\n")]
			get;
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x3F4156C", Offset = "0x3F4156C", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv45.<InjectedUserData>k__BackingField = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000003")]
		private static DateTime? RemoteLastSavedDateTime
		{
			[CompilerGenerated]
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x3F415C8", Offset = "0x3F415C8", Length = "0x4C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\treturn v40.<RemoteLastSavedDateTime>k__BackingField;\n")]
			get
			{
				return _003CRemoteLastSavedDateTime_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x3F41614", Offset = "0x3F41614", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = Unco.SaveSystem.Runtime.GameDataHandler;\n\tv46 = *([v45 @ X8_v3 (Il2CppClass<Unco.SaveSystem.Runtime.GameDataHandler>)+B8]);\n\tv46.<RemoteLastSavedDateTime>k__BackingField = value;\n\t*([v46 @ X8_v4 (Il2CppStaticFields<Unco.SaveSystem.Runtime.GameDataHandler>)+20]) = v15;\n\treturn;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GameDataHandler::set_RemoteLastSavedDateTime");
			}
		}

		[Token(Token = "0x17000004")]
		private static string IDFV
		{
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x3F41670", Offset = "0x3F41670", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\treturn returnVal1;\n")]
			get
			{
				return SystemInfo.deviceUniqueIdentifier;
			}
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x3F41678", Offset = "0x3F41678", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tgoto L_0060;\n\tv126.PermanentVariables = v122;\n\tgoto L_0076;\nL_0076:\n\tv138 = Unco.SaveSystem.Core.DataHandler::GetStringLocal(\"local_up_to_date_idfv\");\n\tthis._localUpToDateIdfv = v138;\n\tv144 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\tUnco.SaveSystem.Core.DataHandler::SaveString(\"local_up_to_date_idfv\", v144, 1, 0);\n\tgoto L_0093;\n\tv213.<>1__state = -1;\n\tSystem.Runtime.CompilerServices.AsyncVoidMethodBuilder::Start(&v213.<>t__builder (System.Runtime.CompilerServices.AsyncVoidMethodBuilder), &v213 @ stack_-90_v2 (Unco.SaveSystem.Runtime.GameDataHandler+<InitOnReady>d__20));\n\treturn;\nL_0031:\n\tv58 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v58);\n\tgoto L_0048;\nL_0048:\n\tv88.<InitialUserData>k__BackingField = v58;\n\tv95 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v95);\nL_0060:\n\tv117.<InjectedUserData>k__BackingField = v95;\n\tv122 = new System.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>();\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::.ctor(v122);\nL_0093:\n\tgoto L_0098;\nL_00B0:\n\tv191 = System.Runtime.CompilerServices.AsyncVoidMethodBuilder::Create();\n\tv213.<>t__builder = v191;\n\tv213.<>4__this = this;\nL_0098:\n\tv167.<RemoteDataHandler>k__BackingField = 0;\n\tthis._useLocal = 1;\n\tgoto L_00B0;\n")]
		public void Init()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			InitialUserData = dictionary;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			InjectedUserData = dictionary2;
			List<IPermanentVariable> permanentVariables = new List<IPermanentVariable>();
			PermanentVariables = permanentVariables;
			string stringLocal = DataHandler.GetStringLocal("local_up_to_date_idfv");
			_localUpToDateIdfv = stringLocal;
			string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
			DataHandler.SaveString("local_up_to_date_idfv", deviceUniqueIdentifier, isLocal: true);
			DataHandler.RemoteDataHandler = null;
			_useLocal = true;
			AsyncVoidMethodBuilder _003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			_003CInitOnReady_003Ed__20 stateMachine = default(_003CInitOnReady_003Ed__20);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[AsyncStateMachine(typeof(_003CInitOnReady_003Ed__20))]
		[Token(Token = "0x600000B")]
		[Address(RVA = "0x3F41924", Offset = "0x3F41924", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv74.<>1__state = -1;\n\tSystem.Runtime.CompilerServices.AsyncVoidMethodBuilder::Start(&v74.<>t__builder (System.Runtime.CompilerServices.AsyncVoidMethodBuilder), &v74 @ stack_-70_v2 (Unco.SaveSystem.Runtime.GameDataHandler+<InitOnReady>d__20));\n\treturn;\nL_001D:\n\tv52 = System.Runtime.CompilerServices.AsyncVoidMethodBuilder::Create();\n\tv74.<>t__builder = v52;\n\tv74.<>4__this = this;\n")]
		private void InitOnReady()
		{
			AsyncVoidMethodBuilder _003C_003Et__builder = AsyncVoidMethodBuilder.Create();
			_003CInitOnReady_003Ed__20 stateMachine = default(_003CInitOnReady_003Ed__20);
			stateMachine._003C_003Et__builder = _003C_003Et__builder;
			stateMachine._003C_003E4__this = this;
			stateMachine._003C_003E1__state = -1;
			stateMachine._003C_003Et__builder.Start(ref stateMachine);
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x3F419D4", Offset = "0x3F419D4", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv75 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(v66.<InitialUserData>k__BackingField);\n\tv111 = v75 == 0;\n\tif (v111) goto L_009D;\n\tgoto L_0057;\nL_0057:\n\tv108 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v168.<InitialUserData>k__BackingField, \"saveTime\", &v97 @ stack_-38_v4);\n\tv112 = ~v108;\n\tif (v112) goto L_009D;\n\tv177 = v97 == 0;\n\tif (v177) goto L_009F;\n\tv179 = *([v97 @ stack_-38_v4]);\n\t*([v179 @ X8_v19+168])(v181, v97, *([v179 @ X8_v19+170]), &v97 @ stack_-38_v4, Il2CppMethodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_006B;\nL_006B:\n\tv193 = System.Globalization.CultureInfo::get_InvariantCulture();\n\tgoto L_0078;\nL_0078:\n\tv207 = System.DateTime::Parse(v181, v193);\n\tv88 = v207;\n\tv210 = System.DateTime::ToUniversalTime(&v88 @ stack_-40_v3 (System.DateTime));\n\tSystem.Nullable`1<System.DateTime>::.ctor(&v85 @ stack_-50_v3 (System.Nullable`1<System.DateTime>), v210);\n\tgoto L_0095;\nL_009F:\n\tv178 = new System.NullReferenceException();\n\tgoto L_00E1;\nL_00E1:\n\t// 225 Interrupt\n\tv189 = 0x8BF5BF4(v178, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv195 = 0x8BF0368(v178, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv144 = 0xA1B8(v195, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0031:\n\tgoto L_0039;\nL_009D:\n\treturn;\nL_0095:\n\tv114.<RemoteLastSavedDateTime>k__BackingField = v85;\nL_0039:\n\tv68 = v66.<InitialUserData>k__BackingField == 0;\n\tif (v68) goto L_009D;\n")]
		private static void TryCacheRemoteLastSavedTime()
		{
			if (InitialUserData != null && InitialUserData.Count != 0 && InitialUserData.TryGetValue("saveTime", out var value))
			{
				if (value != null)
				{
					object obj = value;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v179 @ X8_v19+168] (should have been resolved before IL gen)");
					CultureInfo invariantCulture = CultureInfo.InvariantCulture;
					string s = default(string);
					DateTime dateTime = DateTime.Parse(s, invariantCulture);
					DateTime dateTime2 = dateTime;
					DateTime value2 = dateTime2.ToUniversalTime();
					DateTime? dateTime3 = value2;
					RemoteLastSavedDateTime = dateTime3;
				}
				else
				{
					NullReferenceException ex = new NullReferenceException();
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				}
			}
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x3F41CA8", Offset = "0x3F41CA8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv82 = v61.<InitialUserData>k__BackingField;\n\tv63 = v61.<InitialUserData>k__BackingField == 0;\n\tv64 = ~v63;\n\treturnVal1 = v61.<InitialUserData>k__BackingField;\n\tif (v64) goto L_0043;\nL_0034:\n\treturn returnVal1;\nL_003A:\n\t*([B193B94]) = 1;\n\tv82 = v74.<InitialUserData>k__BackingField;\n\tv72 = v74.<InitialUserData>k__BackingField == 0;\n\treturnVal1 = v74.<InitialUserData>k__BackingField;\n\tif (v72) goto L_0034;\nL_0043:\n\tv89 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(v82);\n\tv115 = v89 == 0;\n\tif (v115) goto L_006E;\n\tgoto L_005C;\nL_005C:\n\tv143 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v118.<InitialUserData>k__BackingField, key, &v93 @ stack_-38_v2 (System.Object));\n\treturn v93;\nL_006E:\n\treturn 0;\nL_0023:\n\tv55 = *([B193B94]) != 1;\n\tif (v55) goto L_003A;\n")]
		private static object GetInitialRemoteRawValue(string key)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193B94]");
			Dictionary<string, object> dictionary;
			object result;
			if ((nint)0 == 1)
			{
				dictionary = InitialUserData;
				bool flag = InitialUserData == null;
				bool flag2 = !flag;
				result = InitialUserData;
				if (!flag2)
				{
					goto IL_003c;
				}
			}
			else
			{
				_ = 1;
				dictionary = InitialUserData;
				bool flag3 = InitialUserData == null;
				result = InitialUserData;
				if (flag3)
				{
					goto IL_003c;
				}
			}
			if (dictionary.Count != 0)
			{
				bool flag4 = InitialUserData.TryGetValue(key, out var value);
				return value;
			}
			return null;
			IL_003c:
			return result;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x3F41DE8", Offset = "0x3F41DE8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(key);\n\treturn returnVal1;\n")]
		public static object GetInitialRemoteData(string key)
		{
			return GetInitialRemoteRawValue(key);
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x3F41DEC", Offset = "0x3F41DEC", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv59.key = key;\n\tv153 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v153, v59, Il2CppMethodInfo);\n\tv245 = System.Linq.Enumerable::FirstOrDefault(v150.PermanentVariables, v153);\n\tv246 = v245 == 0;\n\tif (v246) goto L_0069;\n\tv258 = *([v245 @ X0_v11 (System.Object)]) != Unco.SaveSystem.Core.Variables.PermanentInt;\n\tif (v258) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv294 = v245;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv294 = 0;\nL_0069:\n\tv260 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(v59.key);\n\tv263 = v260 == 0;\n\tif (v263) goto L_008F;\n\tgoto L_007E;\n\tgoto L_00CF;\nL_008F:\n\tv271 = new Unco.SaveSystem.Core.Variables.PermanentInt();\n\tUnco.SaveSystem.Core.Variables.PermanentInt::.ctor(v271, v59.key, defaultValue, 0, 0);\n\tv127 = v137.PermanentVariables;\nL_FFFFFFFF:\n\tv144 = v271;\nL_00A1:\n\t;\n\tgoto L_00BF;\nL_00BF:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Add(v127, v144);\nL_FFFFFFFF:\n\tv294 = v144;\nL_00CE:\n\treturn v294;\nL_00CF:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0030:\n\tv59 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass24_0();\n\tSystem.Object::.ctor(v59);\nL_0067:\n\tgoto L_00CE;\nL_007E:\n\tv304 = new Unco.SaveSystem.Core.Variables.PermanentInt();\n\tUnco.SaveSystem.Core.Variables.PermanentInt::.ctor(v304, v59.key, defaultValue, v260, v302.<RemoteLastSavedDateTime>k__BackingField);\n\tv127 = v136.PermanentVariables;\n\tv307 = v136.PermanentVariables == 0;\n\tv129 = ~v307;\nL_FFFFFFFF:\n\tv144 = v304;\n\tif (v129) goto L_00A1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PermanentInt GetInt(string key, int defaultValue = 0)
		{
			Func<IPermanentVariable, bool> predicate = delegate(IPermanentVariable variable)
			{
				string saveKey = variable.SaveKey;
				return saveKey == key;
			};
			object obj = PermanentVariables.FirstOrDefault((Func<object, bool>)predicate);
			if (obj != null)
			{
				if ((object)obj.GetType() == typeof(PermanentInt))
				{
					return (PermanentInt)obj;
				}
				return null;
			}
			object initialRemoteRawValue = GetInitialRemoteRawValue(key);
			List<IPermanentVariable> permanentVariables;
			PermanentInt permanentInt2;
			if (initialRemoteRawValue == null)
			{
				PermanentInt permanentInt = new PermanentInt(key, defaultValue);
				permanentVariables = PermanentVariables;
				permanentInt2 = permanentInt;
			}
			else
			{
				PermanentInt permanentInt3 = new PermanentInt(key, defaultValue, initialRemoteRawValue, RemoteLastSavedDateTime);
				permanentVariables = PermanentVariables;
				bool flag = PermanentVariables == null;
				bool flag2 = !flag;
				permanentInt2 = permanentInt3;
				if (!flag2)
				{
					return (PermanentInt)(object)new NullReferenceException();
				}
			}
			permanentVariables.Add(permanentInt2);
			return permanentInt2;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x3F42064", Offset = "0x3F42064", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv59.key = key;\n\tv153 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v153, v59, Il2CppMethodInfo);\n\tv245 = System.Linq.Enumerable::FirstOrDefault(v150.PermanentVariables, v153);\n\tv246 = v245 == 0;\n\tif (v246) goto L_0069;\n\tv258 = *([v245 @ X0_v11 (System.Object)]) != Unco.SaveSystem.Core.Variables.PermanentFloat;\n\tif (v258) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv294 = v245;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv294 = 0;\nL_0069:\n\tv260 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(v59.key);\n\tv263 = v260 == 0;\n\tif (v263) goto L_008F;\n\tgoto L_007E;\n\tgoto L_00CF;\nL_008F:\n\tv271 = new Unco.SaveSystem.Core.Variables.PermanentFloat();\n\tUnco.SaveSystem.Core.Variables.PermanentFloat::.ctor(v271, v59.key, defaultValue, 0, 0);\n\tv127 = v137.PermanentVariables;\nL_FFFFFFFF:\n\tv144 = v271;\nL_00A1:\n\t;\n\tgoto L_00BF;\nL_00BF:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Add(v127, v144);\nL_FFFFFFFF:\n\tv294 = v144;\nL_00CE:\n\treturn v294;\nL_00CF:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0030:\n\tv59 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass25_0();\n\tSystem.Object::.ctor(v59);\nL_0067:\n\tgoto L_00CE;\nL_007E:\n\tv304 = new Unco.SaveSystem.Core.Variables.PermanentFloat();\n\tUnco.SaveSystem.Core.Variables.PermanentFloat::.ctor(v304, v59.key, defaultValue, v260, v302.<RemoteLastSavedDateTime>k__BackingField);\n\tv127 = v136.PermanentVariables;\n\tv307 = v136.PermanentVariables == 0;\n\tv129 = ~v307;\nL_FFFFFFFF:\n\tv144 = v304;\n\tif (v129) goto L_00A1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PermanentFloat GetFloat(string key, float defaultValue = 0f)
		{
			Func<IPermanentVariable, bool> predicate = delegate(IPermanentVariable variable)
			{
				string saveKey = variable.SaveKey;
				return saveKey == key;
			};
			object obj = PermanentVariables.FirstOrDefault((Func<object, bool>)predicate);
			if (obj != null)
			{
				if ((object)obj.GetType() == typeof(PermanentFloat))
				{
					return (PermanentFloat)obj;
				}
				return null;
			}
			object initialRemoteRawValue = GetInitialRemoteRawValue(key);
			List<IPermanentVariable> permanentVariables;
			PermanentFloat permanentFloat2;
			if (initialRemoteRawValue == null)
			{
				PermanentFloat permanentFloat = new PermanentFloat(key, defaultValue);
				permanentVariables = PermanentVariables;
				permanentFloat2 = permanentFloat;
			}
			else
			{
				PermanentFloat permanentFloat3 = new PermanentFloat(key, defaultValue, initialRemoteRawValue, RemoteLastSavedDateTime);
				permanentVariables = PermanentVariables;
				bool flag = PermanentVariables == null;
				bool flag2 = !flag;
				permanentFloat2 = permanentFloat3;
				if (!flag2)
				{
					return (PermanentFloat)(object)new NullReferenceException();
				}
			}
			permanentVariables.Add(permanentFloat2);
			return permanentFloat2;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x3F422DC", Offset = "0x3F422DC", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv59.key = key;\n\tv153 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v153, v59, Il2CppMethodInfo);\n\tv245 = System.Linq.Enumerable::FirstOrDefault(v150.PermanentVariables, v153);\n\tv246 = v245 == 0;\n\tif (v246) goto L_0067;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv300 = 0;\n\tgoto L_00E0;\nL_0067:\n\tv261 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(v59.key);\n\tv277 = v261 == 0;\n\tif (v277) goto L_00A1;\n\tgoto L_007C;\n\tgoto L_00E1;\nL_FFFFFFFF:\n\t// -1 IsInst v276_asT @ TEMPCSEL_v2 (Unco.SaveSystem.Core.Variables.PermanentBool), typeof(Unco.SaveSystem.Core.Variables.PermanentBool), v245 @ X0_v11 (System.Object)\n\tv276 = v276_asT == 0;\n\tif (v276) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv301 = v245;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv301 = 0;\nL_00A1:\n\tv310 = new Unco.SaveSystem.Core.Variables.PermanentBool();\n\tUnco.SaveSystem.Core.Variables.PermanentBool::.ctor(v310, v59.key, defaultValue, 0, 0);\n\tv127 = v137.PermanentVariables;\nL_FFFFFFFF:\n\tv300 = v310;\nL_00B3:\n\t;\n\tgoto L_00D1;\nL_00D1:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Add(v127, v300);\nL_00E0:\n\treturn v300;\nL_00E1:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0030:\n\tv59 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass26_0();\n\tSystem.Object::.ctor(v59);\nL_007C:\n\tv320 = new Unco.SaveSystem.Core.Variables.PermanentBool();\n\tUnco.SaveSystem.Core.Variables.PermanentBool::.ctor(v320, v59.key, defaultValue, v261, v318.<RemoteLastSavedDateTime>k__BackingField);\n\tv127 = v136.PermanentVariables;\n\tv323 = v136.PermanentVariables == 0;\n\tv129 = ~v323;\nL_FFFFFFFF:\n\tv300 = v320;\n\tif (v129) goto L_00B3;\nL_FFFFFFFF:\n\tv300 = v301;\n\tgoto L_00E0;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PermanentBool GetBool(string key, bool defaultValue = false)
		{
			Func<IPermanentVariable, bool> predicate = delegate(IPermanentVariable variable)
			{
				string saveKey = variable.SaveKey;
				return saveKey == key;
			};
			object obj = PermanentVariables.FirstOrDefault((Func<object, bool>)predicate);
			PermanentBool permanentBool2;
			if (obj == null)
			{
				object initialRemoteRawValue = GetInitialRemoteRawValue(key);
				List<IPermanentVariable> permanentVariables;
				if (initialRemoteRawValue == null)
				{
					PermanentBool permanentBool = new PermanentBool(key, defaultValue);
					permanentVariables = PermanentVariables;
					permanentBool2 = permanentBool;
				}
				else
				{
					PermanentBool permanentBool3 = new PermanentBool(key, defaultValue, initialRemoteRawValue, RemoteLastSavedDateTime);
					permanentVariables = PermanentVariables;
					bool flag = PermanentVariables == null;
					bool flag2 = !flag;
					permanentBool2 = permanentBool3;
					if (!flag2)
					{
						return (PermanentBool)(object)new NullReferenceException();
					}
				}
				permanentVariables.Add(permanentBool2);
			}
			else
			{
				object obj2 = ((!(obj is PermanentBool)) ? null : obj);
				permanentBool2 = (PermanentBool)obj2;
			}
			return permanentBool2;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x3F42578", Offset = "0x3F42578", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv59.key = key;\n\tv153 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v153, v59, Il2CppMethodInfo);\n\tv245 = System.Linq.Enumerable::FirstOrDefault(v150.PermanentVariables, v153);\n\tv246 = v245 == 0;\n\tif (v246) goto L_0069;\n\tv258 = *([v245 @ X0_v11 (System.Object)]) != Unco.SaveSystem.Core.Variables.PermanentString;\n\tif (v258) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv294 = v245;\n\tgoto L_0067;\nL_FFFFFFFF:\n\tv294 = 0;\nL_0069:\n\tv260 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(v59.key);\n\tv263 = v260 == 0;\n\tif (v263) goto L_008F;\n\tgoto L_007E;\n\tgoto L_00CF;\nL_008F:\n\tv271 = new Unco.SaveSystem.Core.Variables.PermanentString();\n\tUnco.SaveSystem.Core.Variables.PermanentString::.ctor(v271, v59.key, defaultValue, 0, 0);\n\tv127 = v137.PermanentVariables;\nL_FFFFFFFF:\n\tv144 = v271;\nL_00A1:\n\t;\n\tgoto L_00BF;\nL_00BF:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Add(v127, v144);\nL_FFFFFFFF:\n\tv294 = v144;\nL_00CE:\n\treturn v294;\nL_00CF:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0030:\n\tv59 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass27_0();\n\tSystem.Object::.ctor(v59);\nL_0067:\n\tgoto L_00CE;\nL_007E:\n\tv304 = new Unco.SaveSystem.Core.Variables.PermanentString();\n\tUnco.SaveSystem.Core.Variables.PermanentString::.ctor(v304, v59.key, defaultValue, v260, v302.<RemoteLastSavedDateTime>k__BackingField);\n\tv127 = v136.PermanentVariables;\n\tv307 = v136.PermanentVariables == 0;\n\tv129 = ~v307;\nL_FFFFFFFF:\n\tv144 = v304;\n\tif (v129) goto L_00A1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PermanentString GetString(string key, string defaultValue = "")
		{
			Func<IPermanentVariable, bool> predicate = delegate(IPermanentVariable variable)
			{
				string saveKey = variable.SaveKey;
				return saveKey == key;
			};
			object obj = PermanentVariables.FirstOrDefault((Func<object, bool>)predicate);
			if (obj != null)
			{
				if ((object)obj.GetType() == typeof(PermanentString))
				{
					return (PermanentString)obj;
				}
				return null;
			}
			object initialRemoteRawValue = GetInitialRemoteRawValue(key);
			List<IPermanentVariable> permanentVariables;
			PermanentString permanentString2;
			if (initialRemoteRawValue == null)
			{
				PermanentString permanentString = new PermanentString(key, defaultValue);
				permanentVariables = PermanentVariables;
				permanentString2 = permanentString;
			}
			else
			{
				PermanentString permanentString3 = new PermanentString(key, defaultValue, initialRemoteRawValue, RemoteLastSavedDateTime);
				permanentVariables = PermanentVariables;
				bool flag = PermanentVariables == null;
				bool flag2 = !flag;
				permanentString2 = permanentString3;
				if (!flag2)
				{
					return (PermanentString)(object)new NullReferenceException();
				}
			}
			permanentVariables.Add(permanentString2);
			return permanentString2;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x4981134", Offset = "0x4981134", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_001D;\nL_001D:\n\tv84 = Unco.SaveSystem.Runtime.GameDataHandler::GetVariable(key);\n\tv57 = v84 == 0;\n\tif (v57) goto L_005A;\nL_0027:\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv177 = 0;\n\tgoto L_00D0;\nL_FFFFFFFF:\n\t// -1 IsInst v119_asT @ TEMPCSEL_v2 (Unco.SaveSystem.Core.Variables.PermanentObject`1<T>), typeof(Unco.SaveSystem.Core.Variables.PermanentObject`1<T>), v84 @ X0_v27 (Unco.SaveSystem.Core.Variables.IPermanentVariable)\n\tv119 = v119_asT == 0;\n\tif (v119) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv179 = v84;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv179 = 0;\n\tv80 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = Unco.SaveSystem.Runtime.GameDataHandler::GetVariable(key);\n\tv133 = v84 == 0;\n\tv63 = ~v133;\n\tif (v63) goto L_0027;\nL_005A:\n\tv78 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(key);\n\tv103 = v78 == 0;\n\tif (v103) goto L_0090;\n\tgoto L_0076;\nL_0078:\n\tv285 = new Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentObject`1<T>>();\n\tUnco.SaveSystem.Core.Variables.PermanentObject`1<T>::.ctor(v285, key, 0, v78, v214.<RemoteLastSavedDateTime>k__BackingField);\n\tv186 = v307.PermanentVariables;\n\tv309 = v307.PermanentVariables == 0;\n\tv310 = ~v309;\nL_FFFFFFFF:\n\tv177 = v285;\n\tif (v310) goto L_00A5;\n\tgoto L_00D1;\nL_0090:\n\tgoto L_0092;\nL_0092:\n\tv226 = new Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentObject`1<T>>();\n\tUnco.SaveSystem.Core.Variables.PermanentObject`1<T>::.ctor(v226, key, 0, 0, 0);\n\tv186 = v303.PermanentVariables;\nL_FFFFFFFF:\n\tv177 = v226;\nL_00A5:\n\t;\n\tgoto L_00C3;\nL_00C3:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Add(v186, v177);\nL_00D0:\n\treturn v177;\nL_00D1:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0039:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv177 = v179;\n\tgoto L_00D0;\nL_0076:\n\tgoto L_0078;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PermanentObject<T> GetObject<T>(string key) where T : class, new()
		{
			IPermanentVariable variable = GetVariable(key);
			PermanentObject<T> permanentObject2;
			if (variable != null)
			{
				IPermanentVariable permanentVariable = ((!(variable is PermanentObject<T>)) ? null : variable);
				permanentObject2 = (PermanentObject<T>)permanentVariable;
			}
			else
			{
				object initialRemoteRawValue = GetInitialRemoteRawValue(key);
				List<IPermanentVariable> permanentVariables;
				if (initialRemoteRawValue != null)
				{
					PermanentObject<T> permanentObject3 = new PermanentObject<T>(key, null, initialRemoteRawValue, RemoteLastSavedDateTime);
					permanentVariables = PermanentVariables;
					bool flag = PermanentVariables == null;
					bool flag2 = !flag;
					permanentObject2 = permanentObject3;
					if (!flag2)
					{
						return (PermanentObject<T>)(object)new NullReferenceException();
					}
				}
				else
				{
					PermanentObject<T> permanentObject4 = new PermanentObject<T>(key);
					permanentVariables = PermanentVariables;
					permanentObject2 = permanentObject4;
				}
				permanentVariables.Add(permanentObject2);
			}
			return permanentObject2;
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x4980EFC", Offset = "0x4980EFC", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_001D;\nL_001D:\n\tv84 = Unco.SaveSystem.Runtime.GameDataHandler::GetVariable(key);\n\tv57 = v84 == 0;\n\tif (v57) goto L_005A;\nL_0027:\n\tgoto L_0039;\nL_FFFFFFFF:\n\tv175 = 0;\n\tgoto L_00D0;\nL_FFFFFFFF:\n\t// -1 IsInst v119_asT @ TEMPCSEL_v2 (Unco.SaveSystem.Core.Variables.PermanentList`1<T>), typeof(Unco.SaveSystem.Core.Variables.PermanentList`1<T>), v84 @ X0_v29 (Unco.SaveSystem.Core.Variables.IPermanentVariable)\n\tv119 = v119_asT == 0;\n\tif (v119) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv177 = v84;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv177 = 0;\n\tv80 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = Unco.SaveSystem.Runtime.GameDataHandler::GetVariable(key);\n\tv133 = v84 == 0;\n\tv63 = ~v133;\n\tif (v63) goto L_0027;\nL_005A:\n\tv78 = Unco.SaveSystem.Runtime.GameDataHandler::GetInitialRemoteRawValue(key);\n\tv103 = v78 == 0;\n\tif (v103) goto L_0090;\n\tgoto L_0076;\nL_0078:\n\tv281 = new Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentList`1<T>>();\n\tv303 = Unco.SaveSystem.Core.Variables.PermanentList`1<T>::.ctor(v281, key, v78, v212.<RemoteLastSavedDateTime>k__BackingField);\n\tv184 = v305.PermanentVariables;\n\tv307 = v305.PermanentVariables == 0;\n\tv308 = ~v307;\nL_FFFFFFFF:\n\tv175 = v281;\n\tif (v308) goto L_00A5;\n\tgoto L_00D1;\nL_0090:\n\tgoto L_0092;\nL_0092:\n\tv224 = new Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentList`1<T>>();\n\tv290 = Unco.SaveSystem.Core.Variables.PermanentList`1<T>::.ctor(v224, key, 0, 0);\n\tv184 = v292.PermanentVariables;\nL_FFFFFFFF:\n\tv175 = v224;\nL_00A5:\n\t;\n\tgoto L_00C3;\nL_00C3:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Add(v184, v175);\nL_00D0:\n\treturn v175;\nL_00D1:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0039:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv175 = v177;\n\tgoto L_00D0;\nL_0076:\n\tgoto L_0078;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PermanentList<T> GetList<T>(string key)
		{
			IPermanentVariable variable = GetVariable(key);
			PermanentList<T> permanentList2;
			if (variable != null)
			{
				IPermanentVariable permanentVariable = ((!(variable is PermanentList<T>)) ? null : variable);
				permanentList2 = (PermanentList<T>)permanentVariable;
			}
			else
			{
				object initialRemoteRawValue = GetInitialRemoteRawValue(key);
				List<IPermanentVariable> permanentVariables;
				if (initialRemoteRawValue != null)
				{
					PermanentList<T> permanentList3 = new PermanentList<T>(key, initialRemoteRawValue, RemoteLastSavedDateTime);
					permanentVariables = PermanentVariables;
					bool flag = PermanentVariables == null;
					bool flag2 = !flag;
					permanentList2 = permanentList3;
					if (!flag2)
					{
						return (PermanentList<T>)(object)new NullReferenceException();
					}
				}
				else
				{
					PermanentList<T> permanentList4 = new PermanentList<T>(key);
					permanentVariables = PermanentVariables;
					permanentList2 = permanentList4;
				}
				permanentVariables.Add(permanentList2);
			}
			return permanentList2;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x3F427F0", Offset = "0x3F427F0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv50.key = key;\n\tv82 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v82, v50, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v79.PermanentVariables, v82);\n\treturn returnVal2;\nL_0025:\n\tv50 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass30_0();\n\tSystem.Object::.ctor(v50);\n")]
		private static IPermanentVariable GetVariable(string key)
		{
			Func<IPermanentVariable, bool> predicate = delegate(IPermanentVariable variable)
			{
				string saveKey = variable.SaveKey;
				return saveKey == key;
			};
			return (IPermanentVariable)PermanentVariables.FirstOrDefault((Func<object, bool>)predicate);
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x3F428FC", Offset = "0x3F428FC", Length = "0x4F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\n\tv57.onComplete = onComplete;\n\tgoto L_005E;\nL_005E:\n\tgoto L_0062;\nL_0062:\n\tgoto L_0065;\nL_0065:\n\tv338 = v336.<RemoteDataHandler>k__BackingField == 0;\n\tif (v338) goto L_013F;\n\tgoto L_0078;\nL_0078:\n\tv311 = 0xB291000 + 0x530;\n\tv512 = System.DateTime::get_Now();\n\tv57.dateTime = v512;\n\tv584 = Unco.SaveSystem.Runtime.GameDataHandler::ConvertToDictAndRefreshCaches(v512);\n\tv590 = new System.Action`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>();\n\tSystem.Action`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>::.ctor(v590, v57, Il2CppMethodInfo);\n\tgoto L_0090;\nL_0090:\n\tUnco.SaveSystem.Core.DataHandler::SaveJson(\"\", v584, 0, v590);\n\tgoto L_0099;\nL_0099:\n\tgoto L_009B;\nL_009B:\n\tv110 = 0xB28E000 + 0x8D0;\n\tgoto L_00A1;\nL_00A1:\n\tv645.<PREF_SAVE_ENABLED>k__BackingField = 0;\n\tv646 = *([v110 @ X19_v29 (System.Int32)]);\n\tv105 = *([v646 @ X8_v55+B8]);\n\tv666 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(*([v105 @ X8_v56+10]));\n\tv558 = *([v666 @ X0_v57]);\n\tv160 = *([v666 @ X0_v57]);\n\tgoto L_00CB;\nL_00C8:\n\tUnco.SaveSystem.Core.Variables.IPermanentVariable::SaveLocalFromCurrent(*([v666 @ X0_v57+10]));\n\tv713 = *([v666 @ X0_v57+10]) == 0;\n\tif (v713) goto L_0182;\n\tgoto L_00C8;\nL_00FA:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v160 @ stack_-70_v8);\nL_00FC:\n\tv730 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\tgoto L_0109;\nL_0109:\n\tUnco.SaveSystem.Core.DataHandler::SaveString(\"local_up_to_date_idfv\", v730, 1, 0);\n\tUnityEngine.PlayerPrefs::Save();\n\tgoto L_0111;\nL_0111:\n\tv810 = *([B193B97]) & 1;\n\tv277 = v810 == 0;\n\tif (v277) goto L_0179;\n\tv413 = *([v311 @ X23_v8 (System.Int32)]);\n\tgoto L_0118;\nL_0118:\n\tv425 = *([v413 @ X0_v17+B8]);\n\t*([v425 @ X8_v12]) = 1;\nL_013F:\n\t;\n\tv453 = v57.onComplete == 0;\n\tif (v453) goto L_0126;\n\tSystem.Action::Invoke(v57.onComplete);\n\treturn;\nL_0179:\n\t*([B193B97]) = 1;\n\tv413 = *([v269 @ X23_v4 (System.Int32)]);\n\tgoto L_0118;\nL_0182:\n\tv719 = new System.NullReferenceException();\n\tgoto L_0190;\nL_0190:\n\tv530 = Il2CppMethodInfo != 1;\n\tv558 = 0;\n\tv579 = v719;\n\tif (v530) goto L_01A0;\n\tv800 = 0x8BF5BC4(v719, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv807 = 0x8BF5BF4(v800, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v160 @ stack_-70_v8);\n\tv726 = *([v800 @ X0_v79]) == 0;\n\tif (v726) goto L_00FC;\n\tv802 = new System.OutOfMemoryException();\n\tv558 = *([v800 @ X0_v79]);\n\tv579 = v802;\n\treturn;\nL_0048:\n\tv57 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass31_0();\n\tSystem.Object::.ctor(v57);\nL_00CB:\n\tv710 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v160 @ stack_-70_v8);\n\tv712 = v710 == 0;\n\tif (v712) goto L_00FA;\nL_0126:\n\treturn;\nL_01A0:\n\tv805 = 0x319348C(&v558 @ stack_-88_v10 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv809 = 0x8BF0368(v579, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv571 = 0xA1B8(v809, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void SyncToRemote(Action onComplete = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameDataHandler::SyncToRemote");
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3F42DFC", Offset = "0x3F42DFC", Length = "0xA28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0064;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v83);\n\tgoto L_008D;\n\tv123 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(v112.<InitialUserData>k__BackingField);\n\tv140 = *([v123 @ X0_v95]);\n\tv148 = v83 == 0;\n\tif (v148) goto L_0109;\nL_FFFFFFFF:\n\tv621 = 0;\nL_FFFFFFFF:\n\tv438 = 0;\n\tv801 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass32_0();\n\tSystem.Object::.ctor(v801);\n\tv750 = v801 == 0;\n\tif (v750) goto L_02C5;\n\tv801.pair = *([v123 @ X0_v95+10]);\n\tv842 = *([v526 @ X25_v18 (System.Object)]);\n\tv537 = *([v842 @ X8_v86 (Il2CppClass<System.Object>)+B8]);\n\tv845 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v845, v801, Il2CppMethodInfo);\n\tv533 = System.Linq.Enumerable::Any(*([v537 @ X8_v87 (Il2CppStaticFields<System.Object>)+10]), v845);\n\tv526 = 0xB28E000 + 0x8D0;\n\tv987 = v533 == 0;\n\tv535 = ~v987;\n\tif (v535) goto L_00B7;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v83, v801.pair, *([v801 @ X0_v98 (Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass32_0)+18]));\n\tv434 = System.String::op_Equality(v801.pair, \"saveTime\");\n\tv1033 = v434 == 0;\n\tv437 = ~v1033;\nL_FFFFFFFF:\n\tv438 = 1;\n\tif (v437) goto L_00B7;\n\tv435 = System.String::op_Equality(v801.pair, \"local_up_to_date_idfv\");\n\tv1104 = v435 | v621;\nL_FFFFFFFF:\n\tv621 = v1104;\n\tgoto L_00B7;\nL_00FB:\n\t;\nL_FFFFFFFF:\n\tv592 = v438;\n\tgoto L_0131;\nL_FFFFFFFF:\n\tv592 = v154;\nL_FFFFFFFF:\n\tv621 = 0;\nL_FFFFFFFF:\n\tv255 = v83;\n\tgoto L_0144;\n\tv801 = new Unco.SaveSystem.Runtime.GameDataHandler+<>c__DisplayClass32_0();\n\tSystem.Object::.ctor(v801);\n\tv735 = v801 == 0;\n\tif (v735) goto L_02C5;\n\tv801.pair = *([v123 @ X0_v95+10]);\n\tv802 = *([v526 @ X25_v18 (System.Object)]);\n\tv460 = *([v802 @ X8_v81 (Il2CppClass<System.Object>)+B8]);\n\tv804 = new System.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>();\n\tSystem.Func`2<Unco.SaveSystem.Core.Variables.IPermanentVariable, System.Boolean>::.ctor(v804, v801, Il2CppMethodInfo);\n\tv456 = System.Linq.Enumerable::Any(*([v460 @ X8_v82 (Il2CppStaticFields<System.Object>)+10]), v804);\n\tv526 = 0xB28E000 + 0x8D0;\n\tv892 = ~v456;\n\tv458 = ~v892;\n\tif (v458) goto L_0109;\n\tv662 = new System.NullReferenceException();\n\tgoto L_02C9;\nL_FFFFFFFF:\n\tv592 = v154;\nL_FFFFFFFF:\n\tv621 = 0;\nL_0144:\n\tv294 = &v229 @ stack_-D8_v2 (System.Int32);\n\tv295 = System.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::GetEnumerator(v257.PermanentVariables);\n\tv309 = v229.m_value;\n\tv363 = 0;\n\tgoto L_015F;\nL_015C:\n\tUnco.SaveSystem.Core.Variables.IPermanentVariable::SetRawData(*([v294 @ X8_v15+10]), v870, 0);\n\tv668 = *([v294 @ X8_v15+10]) == 0;\n\tif (v668) goto L_02BE;\n\tgoto L_0191;\n\tv870 = new Unco.SaveSystem.Core.Variables.SaveData();\n\tUnco.SaveSystem.Core.Variables.SaveData::.ctor(v870);\n\tv670 = v870 == 0;\n\tif (v670) goto L_02C2;\n\tv870.obj = v580;\n\tv870.time = now;\n\tgoto L_01CD;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v73, v1114, v580);\n\tgoto L_015C;\nL_0201:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v309 @ stack_-B0_v6 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>));\n\tv827 = &v363 @ stack_-D8_v6 (System.Int32);\n\tv828 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(v255);\n\tv140 = v363.m_value;\n\tv861 = v73 == 0;\n\tif (v861) goto L_0233;\nL_0225:\n\tv885 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v140 @ stack_-90_v9 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>));\n\tv880 = v885 == 0;\n\tif (v880) goto L_023A;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v73, *([v827 @ X8_v21+10]), v988);\n\tgoto L_0225;\nL_0233:\n\tv510 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v140 @ stack_-90_v9 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>));\nL_023A:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v140 @ stack_-90_v9 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>));\n\tv1010 = v592 & 1;\n\tv1011 = v1010 == 0;\n\tif (v1011) goto L_0251;\n\tv364 = now;\n\t// 581 Box v390 @ X0_v46 (System.Object), typeof(System.DateTime), &v364 @ stack_-D8_v13 (System.DateTime)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v73, \"saveTime\", v390);\n\tgoto L_0263;\nL_0251:\n\tv365 = now;\n\t// 598 Box v391 @ X0_v43 (System.Object), typeof(System.DateTime), &v365 @ stack_-D8_v12 (System.DateTime)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v73, \"saveTime\", v391);\nL_0263:\n\tv1122 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\tv1131 = v621 & 1;\n\tv1132 = v1131 == 0;\n\tif (v1132) goto L_0279;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v73, \"local_up_to_date_idfv\", v1122);\n\tgoto L_0274;\nL_0274:\n\tgoto L_028C;\nL_0279:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v73, \"local_up_to_date_idfv\", v1122);\n\tgoto L_028C;\nL_028C:\n\tv1226 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(v406.<InjectedUserData>k__BackingField);\n\tv140 = *([v1226 @ X0_v29]);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v73, *([v1226 @ X0_v29+10]), v988);\n\tgoto L_02A2;\nL_02AE:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v140 @ stack_-90_v9 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>));\n\treturn v73;\nL_02BE:\n\tv663 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv592 = v154;\nL_FFFFFFFF:\n\tv621 = v622;\nL_FFFFFFFF:\n\tv624 = v83;\nL_FFFFFFFF:\n\tv638 = &v140 @ stack_-90_v9 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>);\nL_FFFFFFFF:\n\tv640 = 0;\nL_FFFFFFFF:\n\tv657 = v804;\nL_FFFFFFFF:\n\tv661 = v662;\n\tgoto L_02C9;\nL_02C0:\n\tv664 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv638 = &v309 @ stack_-B0_v6 (System.Collections.Generic.KeyValuePair`2<System.String, System.Object>);\nL_FFFFFFFF:\n\tv640 = 0;\nL_FFFFFFFF:\n\tv657 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv661 = v663;\n\tgoto L_02C9;\nL_02C2:\n\tthrow v870;\nL_02C9:\n\t// 713 Interrupt\n\tgoto L_0302;\nL_0302:\n\tgoto L_0311;\n\tv743 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv757 = *([v743 @ X0_v88]);\n\tv793 = 0x8BF5BF4(v743, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(v638);\n\tv760 = *([v743 @ X0_v88]) == 0;\nL_FFFFFFFF:\n\tv229 = *([v743 @ X0_v88]);\nL_FFFFFFFF:\n\tv255 = v624;\n\tif (v760) goto L_0144;\n\tgoto L_035F;\nL_031F:\n\tv746 = 0x3173D2C(&v640 @ stack_-D8_v14 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv830 = v661;\n\tgoto L_0364;\nL_035F:\n\tv897 = new System.OutOfMemoryException();\n\tv835 = 0x319348C(&v757 @ stack_-D8_v16 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv830 = v897;\nL_0364:\n\tv838 = 0x8BF0368(v830, clobbered_X1, clobbered_X2, \n// ... truncated")]
		private unsafe static Dictionary<string, object> ConvertToDictAndRefreshCaches(DateTime now)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameDataHandler::ConvertToDictAndRefreshCaches");
			return default;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x3F4382C", Offset = "0x3F4382C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = *([B78EBF5]) & 1;\n\tv13 = v12 == 0;\n\tif (v13) goto L_0025;\n\tv40 = 0xB28E000 + 0x8D0;\n\tv18 = *([B193B94]) & 1;\n\tv19 = v18 == 0;\n\tv53 = v40;\n\tif (v19) goto L_0032;\nL_0012:\n\tv48 = *([v40 @ X20_v8 (System.Int32)]);\n\tv49 = *([v48 @ X8_v13+B8]);\n\tv64 = *([v49 @ X8_v14]);\n\tv51 = *([v49 @ X8_v14]) == 0;\n\tif (v51) goto L_003E;\nL_001F:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::Clear(v64);\n\treturn;\nL_0025:\n\t*([B193BF5]) = 1;\n\tv40 = 0xB28E000 + 0x8D0;\n\tv62 = *([B193B94]) & 1;\n\tv63 = v62 == 0;\n\tv43 = ~v63;\n\tv53 = v40;\n\tif (v43) goto L_0012;\nL_0032:\n\t*([B193B94]) = 1;\n\tv89 = *([v53 @ X20_v3 (System.Int32)]);\n\tv70 = *([v89 @ X8_v5+B8]);\n\tv64 = *([v70 @ X8_v6]);\n\tv90 = *([v70 @ X8_v6]) == 0;\n\tv68 = ~v90;\n\tif (v68) goto L_001F;\nL_003E:\n\treturn;\n")]
		public static void ResetInitialRemoteData()
		{
			//IL_0085: Expected O, but got I4
			//IL_0095: Expected O, but got I
			//IL_012d: Expected O, but got I4
			//IL_013d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78EBF5]");
			int num;
			int num3;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				num = 187228160 + 2256;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193B94]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag = num2 == 0;
				num3 = num;
				if (!flag)
				{
					goto IL_007d;
				}
			}
			else
			{
				_ = 1;
				num = 187228160 + 2256;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B193B94]");
				int num4 = (int)((nint)0 & (nint)1);
				bool flag2 = num4 == 0;
				bool flag3 = !flag2;
				num3 = num;
				if (flag3)
				{
					goto IL_007d;
				}
			}
			_ = 1;
			object obj = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ X8_v5+B8]");
			object obj2 = 0;
			object obj3 = obj2;
			if (obj2 == null)
			{
				return;
			}
			goto IL_00ba;
			IL_00ba:
			((Dictionary<object, object>)obj3).Clear();
			return;
			IL_007d:
			object obj4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v13+B8]");
			object obj5 = 0;
			obj3 = obj5;
			if (obj5 != null)
			{
				goto IL_00ba;
			}
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x3F438D8", Offset = "0x3F438D8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Clear(v42);\n\tv60 = v42.Count < 1;\n\tif (v60) goto L_0038;\nL_0038:\n\tgoto L_0041;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Clear(v102.<InitialUserData>k__BackingField);\n\treturn;\nL_0052:\n\treturn;\nL_001B:\n\tv42 = v41.PermanentVariables;\n\tv43 = v41.PermanentVariables == 0;\n\tif (v43) goto L_0038;\nL_0041:\n\tv104 = v102.<InitialUserData>k__BackingField == 0;\n\tif (v104) goto L_0052;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ClearCaches()
		{
			List<IPermanentVariable> permanentVariables = PermanentVariables;
			if (PermanentVariables != null)
			{
				permanentVariables.Clear();
				if (permanentVariables.Count < 1)
				{
				}
			}
			if (InitialUserData != null)
			{
				InitialUserData.Clear();
			}
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x3F439AC", Offset = "0x3F439AC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv56 = System.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::Remove(v46.PermanentVariables, permanentVariable);\nL_002E:\n\tgoto L_0037;\n\tgoto L_0071;\nL_0069:\n\treturn;\nL_0022:\n\tv48 = v46.PermanentVariables == 0;\n\tif (v48) goto L_002E;\nL_0037:\n\tv78 = v76.<InitialUserData>k__BackingField == 0;\n\tif (v78) goto L_0069;\nL_0071:\n\tv217 = Unco.SaveSystem.Core.Variables.IPermanentVariable::get_SaveKey(permanentVariable);\n\tv145 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Remove(v76.<InitialUserData>k__BackingField, v217);\n\treturn;\n")]
		public static void DeleteVariable(IPermanentVariable permanentVariable)
		{
			if (PermanentVariables != null)
			{
				bool flag = PermanentVariables.Remove(permanentVariable);
			}
			if (InitialUserData != null)
			{
				string saveKey = permanentVariable.SaveKey;
				bool flag2 = InitialUserData.Remove(saveKey);
			}
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x3F43AFC", Offset = "0x3F43AFC", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv207 = 0;\n\tgoto L_004B;\nL_003A:\n\tUnco.SaveSystem.Core.Variables.IPermanentVariable::SetCurrentValue(v186, v309.obj);\n\tv207 = v207 + 1;\n\tv223 = v199.PermanentVariables;\nL_004B:\n\tv106 = v207 >= v223.Count;\n\tif (v106) goto L_00FD;\n\tv186 = System.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::get_Item(v223, v207);\n\tv272 = *([v186 @ X0_v6 (Unco.SaveSystem.Core.Variables.IPermanentVariable)]);\n\tv292 = *([v272 @ X8_v8 (Il2CppClass<Unco.SaveSystem.Core.Variables.IPermanentVariable>)+12E]);\n\tv274 = *([v272 @ X8_v8 (Il2CppClass<Unco.SaveSystem.Core.Variables.IPermanentVariable>)+12E]) == 0;\n\tif (v274) goto L_0079;\n\tv91 = *([v272 @ X8_v8 (Il2CppClass<Unco.SaveSystem.Core.Variables.IPermanentVariable>)+B0]) + 8;\n\tv91 = v91 + 0x10;\n\tv278 = v292 - 1;\n\tv279 = v292 != 1;\n\tv292 = v278;\n\tif (v279) goto L_005F;\nL_0079:\n\tv309 = Unco.SaveSystem.Core.Variables.IPermanentVariable::GetRawData(v186, localToRemote);\n\tv303 = v309 == 0;\n\tv194 = ~v303;\n\tif (v194) goto L_008C;\n\tgoto L_00FE;\nL_007F:\n\tv98 = *([v91 @ X10_v19]) + 2;\n\tv84 = v98 << 4;\n\tv306 = v272 + v84;\n\tv307 = v306 + 0x138;\n\t*([v307 @ X0_v27])(v309, v186, localToRemote, *([v307 @ X0_v27+8]), 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_008C:\n\tv313 = v309.obj == 0;\n\tif (v313) goto L_00B8;\n\tgoto L_00C7;\nL_00B8:\n\tSystem.Collections.Generic.List`1<Unco.SaveSystem.Core.Variables.IPermanentVariable>::RemoveAt(v203.PermanentVariables, v207);\n\tv223 = v204.PermanentVariables;\n\tv370 = v204.PermanentVariables == 0;\n\tv197 = ~v370;\n\tif (v197) goto L_004B;\n\tgoto L_00FE;\nL_00FD:\n\treturn;\nL_00FE:\n\tthrow System.NullReferenceException;\nL_0028:\n\tv223 = v54.PermanentVariables;\nL_005F:\n\tv143 = *([v91 @ X10_v19-8]) == Unco.SaveSystem.Core.Variables.IPermanentVariable;\n\tif (v143) goto L_007F;\nL_00C7:\n\tv394 = localToRemote ^ 1;\n\tUnco.SaveSystem.Core.Variables.IPermanentVariable::SetRawData(v186, v309, v394);\n\tgoto L_003A;\n")]
		public static void TransferDataAndSetCurrentValue(bool localToRemote)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GameDataHandler::TransferDataAndSetCurrentValue");
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3F43D70", Offset = "0x3F43D70", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40.PermanentVariables;\n")]
		public static List<IPermanentVariable> GetPermanentVariables_DEV()
		{
			return PermanentVariables;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3F43DBC", Offset = "0x3F43DBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GameDataHandler()
		{
		}
	}
}
