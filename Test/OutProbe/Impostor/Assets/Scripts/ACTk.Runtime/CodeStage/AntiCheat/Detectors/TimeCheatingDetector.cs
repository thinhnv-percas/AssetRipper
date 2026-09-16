using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Utils;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

namespace CodeStage.AntiCheat.Detectors
{
	[AddComponentMenu("Code Stage/Anti-Cheat Toolkit/Time Cheating Detector")]
	[DisallowMultipleComponent]
	[HelpURL("http://codestage.net/uas_files/actk/api/class_code_stage_1_1_anti_cheat_1_1_detectors_1_1_time_cheating_detector.html")]
	[Token(Token = "0x200003C")]
	public class TimeCheatingDetector : ACTkDetectorBase<TimeCheatingDetector>
	{
		[Token(Token = "0x200003D")]
		public delegate void OnlineTimeCallback(OnlineTimeResult result);

		[Token(Token = "0x200003E")]
		public delegate void TimeCheatingDetectorEventHandler(CheckResult result, ErrorKind error);

		[Token(Token = "0x200003F")]
		public struct OnlineTimeResult
		{
			[Token(Token = "0x4000121")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public bool success;

			[Token(Token = "0x4000122")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public string error;

			[Token(Token = "0x4000123")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public long errorResponseCode;

			[Token(Token = "0x4000124")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public double onlineSecondsUtc;

			[Token(Token = "0x60003F3")]
			[Address(RVA = "0xBEE35C", Offset = "0xBEE35C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.success = 1;\n\tthis.error = 0;\n\tthis.errorResponseCode = -1;\n\tthis.onlineSecondsUtc = secondsUtc;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal void SetTime(double secondsUtc)
			{
				//IL_001d: Expected I8, but got I4
				success = true;
				error = null;
				errorResponseCode = -1L;
				onlineSecondsUtc = secondsUtc;
			}

			[Token(Token = "0x60003F4")]
			[Address(RVA = "0xBEE000", Offset = "0xBEE000", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.success = 0;\n\tthis.error = errorText;\n\tthis.errorResponseCode = responseCode;\n\tthis.onlineSecondsUtc = -1d;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal void SetError(string errorText, long responseCode = -1L)
			{
				success = false;
				error = errorText;
				errorResponseCode = responseCode;
				onlineSecondsUtc = -1.0;
			}

			[Token(Token = "0x60003F5")]
			[Address(RVA = "0xBEE374", Offset = "0xBEE374", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = \"Error response code: \";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = \"\\nError: \";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv49 = \"onlineSecondsUtc: \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35567]) = v34;\nL_0017:\n\tv36 = ~this.success;\n\tif (v36) goto L_0028;\n\tv42 = this + 0x18;\n\tv44 = System.Double::ToString(v42);\n\treturnVal1 = System.String::Concat(\"onlineSecondsUtc: \", v44);\n\treturn returnVal1;\nL_0028:\n\tv45 = this + 0x10;\n\tv47 = System.Int64::ToString(v45);\n\treturnVal2 = System.String::Concat(\"Error response code: \", v47, \"\\nError: \", this.error);\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe override string ToString()
			{
				//IL_001f: Expected Ref, but got F8
				if (success)
				{
					double num = (double)(ref this) + 1.2E-322;
					string text = ((double*)num)->ToString();
					return "onlineSecondsUtc: " + text;
				}
				long num2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				string text2 = ((long*)num2)->ToString();
				return "Error response code: " + text2 + "\nError: " + error;
			}
		}

		[Token(Token = "0x2000040")]
		public enum CheckResult
		{
			[Token(Token = "0x4000126")]
			Unknown = 0,
			[Token(Token = "0x4000127")]
			CheckPassed = 5,
			[Token(Token = "0x4000128")]
			WrongTimeDetected = 10,
			[Token(Token = "0x4000129")]
			CheatDetected = 15,
			[Token(Token = "0x400012A")]
			Error = 100
		}

		[Token(Token = "0x2000041")]
		public enum ErrorKind
		{
			[Token(Token = "0x400012C")]
			NoError = 0,
			[Token(Token = "0x400012D")]
			IncorrectUri = 3,
			[Token(Token = "0x400012E")]
			OnlineTimeError = 5,
			[Token(Token = "0x400012F")]
			NotStarted = 10,
			[Token(Token = "0x4000130")]
			AlreadyCheckingForCheat = 15,
			[Token(Token = "0x4000131")]
			Unknown = 100
		}

		[Token(Token = "0x2000042")]
		public enum RequestMethod
		{
			[Token(Token = "0x4000133")]
			Head = 0,
			[Token(Token = "0x4000134")]
			Get = 1
		}

		[CompilerGenerated]
		[Token(Token = "0x2000043")]
		private sealed class _003CCheckForCheat_003Ed__68 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000135")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000136")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000137")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TimeCheatingDetector _003C_003E4__this;

			[Token(Token = "0x17000034")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60003F9")]
				[Address(RVA = "0xBEF3FC", Offset = "0xBEF3FC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000035")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60003FB")]
				[Address(RVA = "0xBEF43C", Offset = "0xBEF43C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60003F6")]
			[Address(RVA = "0xBEE884", Offset = "0xBEE884", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CCheckForCheat_003Ed__68(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60003F7")]
			[Address(RVA = "0xBEF0E8", Offset = "0xBEF0E8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60003F8")]
			[Address(RVA = "0xBEF0EC", Offset = "0xBEF0EC", Length = "0x310")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv55 = System.Math;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv62 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeCallback;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv149 = Il2CppMethodInfo;\n\tv150 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv213 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv214 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv259 = System.Uri;\n\tv260 = \"il2cpp_codegen_initialize_runtime_metadata\"(v259, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv273 = \"[ACTk] Time Cheating Detector: Please consider increasing realCheatThreshold to reduce false positives chance!\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v273, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35568]) = v42;\nL_0027:\n\tv44 = v39.<>4__this;\n\tv49 = v39.<>1__state == 1;\n\tif (v49) goto L_0058;\n\tv57 = v39.<>1__state == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_FFFFFFFF;\n\tv39.<>1__state = 0xFFFFFFFF;\n\tv120 = ~v44.isRunning;\n\tif (v120) goto L_FFFFFFFF;\n\tv215 = ~v44.<IsCheckingForCheat>k__BackingField;\n\tv121 = ~v215;\n\tif (v121) goto L_FFFFFFFF;\n\tv44.<LastError>k__BackingField = 0;\n\tv44.<IsCheckingForCheat>k__BackingField = 1;\n\tgoto L_004F;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v264, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004F:\n\tv138 = System.Uri::op_Equality(v44.cachedUri, 0);\n\tv140 = v138 == 0;\n\tif (v140) goto L_0132;\n\tv44.<LastError>k__BackingField = 2.12199579098E-312d;\n\tgoto L_005C;\nL_0058:\n\tv39.<>1__state = 0xFFFFFFFF;\nL_005C:\n\tv144 = ~v44.started;\n\tif (v144) goto L_0063;\n\tv207 = ~v44.isRunning;\n\tv208 = ~v207;\n\tif (v208) goto L_0066;\nL_0063:\n\tv44.<LastError>k__BackingField = 0x64;\nL_0066:\n\tv247 = v44.lastOnlineSecondsUtc < 0;\n\tv248 = ~v247;\n\tv251 = v44.lastOnlineSecondsUtc == 0;\n\tv256 = ~v251;\n\tv257 = v248 & v256;\n\tif (v257) goto L_0078;\n\tv268 = v44.<LastError>k__BackingField == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_0078;\n\tv44.<LastError>k__BackingField = 0x64;\n\tgoto L_0121;\nL_0078:\n\tv271 = v44.<LastError>k__BackingField == 0;\n\tif (v271) goto L_0085;\n\tv287 = v44.<LastError>k__BackingField != 0xF;\n\tif (v287) goto L_0121;\nL_0085:\n\tv44.<LastError>k__BackingField = 0;\n\tv109 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetLocalSecondsUtc(v137);\n\tgoto L_0093;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v301, v133, v131, v26, v27, v28, v29, v30, v109, v32, v33, v34, v35, v36, v37, v38);\nL_0093:\n\t// 147 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv326 = v109 != 0x7FF0000000000000;\n\tif (v326) goto L_FFFFFFFF;\n\tgoto L_00A8;\nL_00A8:\n\tv337 = v44.wrongTimeThreshold * 0x3C;\n\tv341 = v115 - v337;\n\tv342 = v341 < 0;\n\tv343 = v341 == 0;\n\tv344 = v115 ^ v337;\n\tv345 = v115 ^ v341;\n\tv346 = v344 & v345;\n\tv347 = v346 < 0;\n\tv349 = v342 == v347;\n\tv350 = ~v343;\n\tv351 = v349 & v350;\n\tv352 = ~v351;\n\tif (v352) goto L_FFFFFFFF;\n\tgoto L_00BF;\nL_00BF:\n\tv44.<LastResult>k__BackingField = v359;\n\tv362 = UnityEngine.PlayerPrefs::GetInt(v44.onlineOfflineDifferencePrefsKey, 0);\n\tv363 = v362 == 0;\n\tif (v363) goto L_0117;\n\tgoto L_00CA;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v365, v360, v361, v26, v27, v28, v29, v30, v109, v79, v33, v34, v35, v36, v37, v38);\nL_00CA:\n\tv435 = v44.realCheatThreshold;\n\tv406 = v115 + v362;\n\tv373 = v406 + 0x80000001;\n\tv408 = v373 < 0;\n\tv412 = 0x7FFFFFFF - v406;\n\tv413 = ~v408;\n\tv370 = ~v413;\n\tif (v370) goto L_FFFFFFFF;\n\tgoto L_00E6;\nL_00E6:\n\tv426 = v435 > 9;\n\tif (v426) goto L_00F7;\n\tgoto L_00F4;\n\tv440 = \"il2cpp_codegen_runtime_class_init\"(v429, v360, v361, v26, v27, v28, v29, v30, v109, v79, v33, v34, v35, v36, v37, v38);\nL_00F4:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Please consider increasing realCheatThreshold to reduce false positives chance!\");\n\tv435 = v44.realCheatThreshold;\nL_00F7:\n\tv400 = v435 * 0x3C;\n\tv374 = v398 <= v400;\n\tif (v374) goto L_0117;\n\tv383 = v44.<LastResult>k__BackingField == 0xA;\n\tif (v383) goto L_0115;\n\tv446 = ~v44.ignoreSetCorrectTime;\n\tv397 = ~v446;\n\tif (v397) goto L_0117;\nL_0115:\n\tv44.<LastResult>k__BackingField = 0xF;\nL_0117:\n\tv113 = v115 ^ 0x7FFFFFFF;\n\tUnityEngine.PlayerPrefs::SetInt(v44.onlineOfflineDifferencePrefsKey, v113);\n\tv44.<IsCheckingForCheat>k__BackingField = 0;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector::ReportCheckResult(v44);\n\tgoto L_012D;\nL_0121:\n\tv44.<LastResult>k__BackingField = 0x64;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector::ReportCheckResult(v44);\n\tv44.<IsCheckingForCheat>k__BackingField = 0;\nL_012D:\n\treturn returnVal1;\nL_0132:\n\tv308 = new CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeCallback();\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeCallback::.ctor(v308, v44, Il2CppMethodInfo);\n\tgoto L_0145;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v335, v329, v330, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0145:\n\tv356 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetOnlineTimeCoroutine(v44.cachedUri, v308, v44.requestMethod);\n\tv39.<>2__current = v356;\n\tv39.<>1__state = 1;\n\tgoto L_012D;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_0529: Unknown result type (might be due to invalid IL or missing references)
				//IL_052e: Expected I4, but got Unknown
				//IL_053b: Expected O, but got F8
				//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
				//IL_05e6: Expected I4, but got Unknown
				//IL_00f2: Expected I4, but got F8
				//IL_00fa: Expected O, but got I4
				TimeCheatingDetector timeCheatingDetector = _003C_003E4__this;
				TimeCheatingDetector timeCheatingDetector2;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						if (timeCheatingDetector.IsRunning && !timeCheatingDetector.IsCheckingForCheat)
						{
							timeCheatingDetector.LastError = default(ErrorKind);
							timeCheatingDetector.IsCheckingForCheat = true;
							bool flag = timeCheatingDetector.cachedUri == null;
							if (flag)
							{
								timeCheatingDetector.LastError = ErrorKind.NoError;
								timeCheatingDetector2 = (TimeCheatingDetector)flag;
								goto IL_0114;
							}
							OnlineTimeCallback callback = timeCheatingDetector.OnOnlineTimeReceived;
							IEnumerator onlineTimeCoroutine = GetOnlineTimeCoroutine(timeCheatingDetector.cachedUri, callback, timeCheatingDetector.requestMethod);
							_003C_003E2__current = onlineTimeCoroutine;
							_003C_003E1__state = 1;
							return true;
						}
					}
					goto IL_03a5;
				}
				_003C_003E1__state = -1;
				timeCheatingDetector2 = (TimeCheatingDetector)(object)this;
				goto IL_0114;
				IL_03a5:
				return false;
				IL_0114:
				if (!timeCheatingDetector.IsStarted || !timeCheatingDetector.IsRunning)
				{
					timeCheatingDetector.LastError = ErrorKind.Unknown;
				}
				bool flag2 = timeCheatingDetector.lastOnlineSecondsUtc < 0.0;
				bool flag3 = !flag2;
				bool flag4 = timeCheatingDetector.lastOnlineSecondsUtc == 0.0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5) && timeCheatingDetector.LastError == ErrorKind.NoError)
				{
					timeCheatingDetector.LastError = ErrorKind.Unknown;
				}
				else if (timeCheatingDetector.LastError == ErrorKind.NoError || timeCheatingDetector.LastError == ErrorKind.AlreadyCheckingForCheat)
				{
					timeCheatingDetector.LastError = default(ErrorKind);
					double localSecondsUtc = timeCheatingDetector2.GetLocalSecondsUtc();
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					double num = ((localSecondsUtc != 9.218868437227405E+18) ? localSecondsUtc : 1.0609978955E-314);
					int num2 = timeCheatingDetector.wrongTimeThreshold * 60;
					double num3 = num - (double)num2;
					bool flag6 = num3 < 0.0;
					bool flag7 = num3 == 0.0;
					int num4 = num ^ num2;
					object obj = num ^ num3;
					int num5 = (int)(num4 & (nint)obj);
					bool flag8 = num5 < 0;
					bool flag9 = flag6 == flag8;
					bool flag10 = !flag7;
					CheckResult _003CLastResult_003Ek__BackingField = ((!(flag9 && flag10)) ? CheckResult.CheckPassed : CheckResult.WrongTimeDetected);
					timeCheatingDetector.LastResult = _003CLastResult_003Ek__BackingField;
					int num6 = PlayerPrefs.GetInt(timeCheatingDetector.onlineOfflineDifferencePrefsKey, 0);
					if (num6 != 0)
					{
						int realCheatThreshold = timeCheatingDetector.realCheatThreshold;
						double num7 = num + (double)num6;
						double num8 = num7 + 1.060997896E-314;
						bool flag11 = num8 < 0.0;
						double num9 = 1.060997895E-314 - num7;
						double num10 = (flag11 ? num9 : num8);
						if (realCheatThreshold <= 9)
						{
							Debug.LogWarning("[ACTk] Time Cheating Detector: Please consider increasing realCheatThreshold to reduce false positives chance!");
							realCheatThreshold = timeCheatingDetector.realCheatThreshold;
						}
						int num11 = realCheatThreshold * 60;
						if (num10 > (double)num11 && (timeCheatingDetector.LastResult == CheckResult.WrongTimeDetected || !timeCheatingDetector.ignoreSetCorrectTime))
						{
							timeCheatingDetector.LastResult = CheckResult.CheatDetected;
						}
					}
					int value = num ^ 0x7FFFFFFF;
					PlayerPrefs.SetInt(timeCheatingDetector.onlineOfflineDifferencePrefsKey, value);
					timeCheatingDetector.IsCheckingForCheat = false;
					timeCheatingDetector.ReportCheckResult();
					goto IL_03a5;
				}
				timeCheatingDetector.LastResult = CheckResult.Error;
				timeCheatingDetector.ReportCheckResult();
				timeCheatingDetector.IsCheckingForCheat = false;
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60003FA")]
			[Address(RVA = "0xBEF404", Offset = "0xBEF404", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000044")]
		private sealed class _003CForceCheckEnumerator_003Ed__60 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000138")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000139")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400013A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TimeCheatingDetector _003C_003E4__this;

			[Token(Token = "0x17000036")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60003FF")]
				[Address(RVA = "0xBEF5C8", Offset = "0xBEF5C8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000037")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000401")]
				[Address(RVA = "0xBEF608", Offset = "0xBEF608", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0xBEE588", Offset = "0xBEE588", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CForceCheckEnumerator_003Ed__60(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0xBEF444", Offset = "0xBEF444", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60003FE")]
			[Address(RVA = "0xBEF448", Offset = "0xBEF448", Length = "0x180")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv55 = \"[ACTk] Time Cheating Detector: Detector should be started to use ForceCheckEnumerator().\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv68 = \"[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35569]) = v34;\nL_001A:\n\tv36 = this.<>4__this;\n\tv37 = this.<>1__state - 1;\n\tv38 = v37 < 2;\n\tv39 = ~v38;\n\tif (v39) goto L_003D;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv58 = ~v36.<IsCheckingForCheat>k__BackingField;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_003A;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv100 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_003A:\n\tthis.<>1__state = 2;\n\tthis.<>2__current = v101.CachedEndOfFrame;\n\tgoto L_0074;\nL_003D:\n\tv52 = this.<>1__state == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv76 = ~v36.started;\n\tif (v76) goto L_0065;\n\tv112 = ~v36.isRunning;\n\tif (v112) goto L_0065;\n\tv89 = ~v36.<IsCheckingForCheat>k__BackingField;\n\tif (v89) goto L_0076;\n\tgoto L_0059;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v129, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0059:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.\");\n\tgoto L_006F;\n\tgoto L_0074;\nL_0065:\n\tgoto L_006B;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v117, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_006B:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Detector should be started to use ForceCheckEnumerator().\");\nL_006F:\n\tv36.<LastError>k__BackingField = v80;\nL_0074:\n\treturn returnVal2;\nL_0076:\n\tv36.timeElapsed = 0f;\n\tv134 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::CheckForCheat(v36);\n\tthis.<>2__current = v134;\n\tthis.<>1__state = 1;\n\tgoto L_0074;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_01cd: Expected I4, but got F8
				TimeCheatingDetector timeCheatingDetector = _003C_003E4__this;
				int num = _003C_003E1__state - 1;
				if (num < 2)
				{
					_003C_003E1__state = -1;
					if (timeCheatingDetector.IsCheckingForCheat)
					{
						_003C_003E1__state = 2;
						_003C_003E2__current = CachedEndOfFrame;
						return true;
					}
				}
				else if (_003C_003E1__state == 0)
				{
					_003C_003E1__state = -1;
					double num2;
					if (timeCheatingDetector.IsStarted && timeCheatingDetector.IsRunning)
					{
						if (!timeCheatingDetector.IsCheckingForCheat)
						{
							timeCheatingDetector.timeElapsed = 0f;
							IEnumerator enumerator = timeCheatingDetector.CheckForCheat();
							_003C_003E2__current = enumerator;
							_003C_003E1__state = 1;
							return true;
						}
						Debug.LogWarning("[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.");
						num2 = 2.12199579104E-312;
					}
					else
					{
						Debug.LogWarning("[ACTk] Time Cheating Detector: Detector should be started to use ForceCheckEnumerator().");
						num2 = 2.121995791015E-312;
					}
					timeCheatingDetector.LastError = (ErrorKind)num2;
					return false;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000400")]
			[Address(RVA = "0xBEF5D0", Offset = "0xBEF5D0", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000045")]
		private struct _003CForceCheckTask_003Ed__61 : IAsyncStateMachine
		{
			[Token(Token = "0x400013B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x400013C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<CheckResult> _003C_003Et__builder;

			[Token(Token = "0x400013D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public TimeCheatingDetector _003C_003E4__this;

			[Token(Token = "0x400013E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x6000402")]
			[Address(RVA = "0xBEF610", Offset = "0xBEF610", Length = "0x3E4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv64 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+CheckResult>;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv105 = UnityEngine.Debug;\n\tv106 = \"il2cpp_codegen_initialize_runtime_metadata\"(v105, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv163 = System.Threading.Tasks.Task;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv206 = \"[ACTk] Time Cheating Detector: Detector should be started to use ForceCheckTask().\";\n\tv207 = \"il2cpp_codegen_initialize_runtime_metadata\"(v206, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv220 = \"[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v220, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3556A]) = v38;\nL_0028:\n\tv43 = this.<>4__this;\n\tv46 = this.<>1__state == 0;\n\tif (v46) goto L_0041;\n\tv59 = this.<>1__state != 1;\n\tif (v59) goto L_0050;\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_00D3;\nL_0041:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0045:\n\tSystem.Runtime.CompilerServices.TaskAwaiter::GetResult(&v74 @ stack_-28_v3 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv204 = ~v43.<IsCheckingForCheat>k__BackingField;\n\tv169 = ~v204;\n\tif (v169) goto L_00D4;\n\tgoto L_FFFFFFFF;\nL_0050:\n\tv142 = ~v43.started;\n\tif (v142) goto L_006E;\n\tv175 = ~v43.isRunning;\n\tif (v175) goto L_006E;\n\tv212 = ~v43.<IsCheckingForCheat>k__BackingField;\n\tif (v212) goto L_007A;\n\tgoto L_0064;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v243, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0064:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.\");\n\tgoto L_0077;\nL_006E:\n\tgoto L_0074;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v180, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0074:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Detector should be started to use ForceCheckTask().\");\nL_0077:\n\tv43.<LastError>k__BackingField = v283;\n\tgoto L_00DA;\nL_007A:\n\tv43.timeElapsed = 0f;\n\tv248 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::CheckForCheat(v43);\n\tv325 = UnityEngine.MonoBehaviour::StartCoroutine(v43, v248);\n\tgoto L_0089;\n\tv359 = \"il2cpp_codegen_runtime_class_init\"(v349, v323, v71, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0089:\n\tv199 = System.Threading.Tasks.Task::Delay(0x32);\n\tv201 = v199 == 0;\n\tif (v201) goto L_00A9;\n\tv438 = System.Threading.Tasks.Task::GetAwaiter(v199);\n\tv97 = System.Runtime.CompilerServices.TaskAwaiter::get_IsCompleted(&v74 @ stack_-28_v3 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv459 = v97 == 0;\n\tv99 = ~v459;\n\tif (v99) goto L_0045;\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v74;\n\tgoto L_00A1;\n\tv470 = \"il2cpp_codegen_runtime_class_init\"(v462, v73, v71, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00A1:\n\tv390 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::AwaitUnsafeOnCompleted(v390, &v74 @ stack_-28_v3 (System.Runtime.CompilerServices.TaskAwaiter), this);\n\tgoto L_00B9;\n\tv157 = new System.NullReferenceException();\n\tv161 = new System.NullReferenceException();\nL_00A9:\n\tv265 = new System.NullReferenceException();\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\nL_00B9:\n\treturn;\nL_00BB:\n\tv210 = ~v43.<IsCheckingForCheat>k__BackingField;\n\tif (v210) goto L_FFFFFFFF;\n\tgoto L_00C5;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v238, v165, v108, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00C5:\n\tv316 = System.Threading.Tasks.Task::Delay(0x32);\n\tv268 = v316 == 0;\n\tif (v268) goto L_00FB;\n\tv358 = System.Threading.Tasks.Task::GetAwaiter(v316);\n\tv134 = System.Runtime.CompilerServices.TaskAwaiter::get_IsCompleted(&v74 @ stack_-28_v3 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv136 = v134 == 0;\n\tif (v136) goto L_00EA;\nL_00D3:\n\tSystem.Runtime.CompilerServices.TaskAwaiter::GetResult(&v74 @ stack_-28_v3 (System.Runtime.CompilerServices.TaskAwaiter));\nL_00D4:\n\tv172 = v43 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_00BB;\n\tthrow System.NullReferenceException;\nL_00DA:\n\tthis.<>1__state = 0xFFFFFFFE;\n\tv306 = this + 8;\n\tgoto L_00E7;\n\tv344 = \"il2cpp_codegen_runtime_class_init\"(v307, v284, v281, v22, v23, v24, v25, v26, v282, v28, v29, v30, v31, v32, v33, v34);\nL_00E7:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::SetResult(v306, v303);\n\tgoto L_00B9;\nL_00EA:\n\tthis.<>1__state = 1;\n\tthis.<>u__1 = v74;\n\tgoto L_00F5;\n\tv455 = \"il2cpp_codegen_runtime_class_init\"(v444, v110, v108, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00F5:\n\tv391 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::AwaitUnsafeOnCompleted(v391, &v74 @ stack_-28_v3 (System.Runtime.CompilerServices.TaskAwaiter), this);\n\tgoto L_00B9;\nL_00FB:\n\tv265 = new System.NullReferenceException();\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\n\tgoto L_010A;\nL_010A:\n\tv280 = v332 != 1;\n\tif (v280) goto L_0138;\n\tv329 = 0x1854E70(v265, v332, v330, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv362 = *([v329 @ X0_v16]);\n\tv364 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v362 @ X8_v11]), v330, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv412 = v364 & 1;\n\tv337 = v412 == 0;\n\tif (v337) goto L_012E;\n\tv439 = 0x1854E80(v364, *([v362 @ X8_v11]), v330, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tthis.<>1__state = 0xFFFFFFFE;\n\tv398 = this + 8;\n\tgoto L_012B;\n\tv465 = \"il2cpp_codegen_runtime_class_init\"(v452, v363, v251, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_012B:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::SetException(v398, *([v329 @ X0_v16]));\n\tgoto L_00B9;\nL_012E:\n\tv441 = 0x1854E90(8, *([v362 @ X8_v11]), v330, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\t*([v441 @ X0_v22]) = *([v329 @ X0_v16]);\n\tv332 = 0x185A000 + 0xF88;\n\tv454 = 0x1854EA0(v441, v332, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv335 = 0x1854E80(v454, v332, 0, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0138:\n\tv343 = 0xBD3CD0(v340, v332, v330, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv356 = 0x9DACB4(v343, v332, v330, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void MoveNext()
			{
				//IL_04fc: Expected I4, but got F8
				//IL_052e: Expected O, but got Ref
				//IL_0354: Expected O, but got Ref
				//IL_01f0: Expected O, but got I4
				//IL_0495: Expected O, but got I4
				//IL_0422: Expected O, but got Ref
				//IL_0223: Expected O, but got Ref
				TimeCheatingDetector timeCheatingDetector = _003C_003E4__this;
				TaskAwaiter awaiter = default(TaskAwaiter);
				NullReferenceException ex;
				System.Int32Enum result;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003Eu__1 = default(TaskAwaiter);
						_003C_003E1__state = -1;
						awaiter = _003C_003Eu__1;
						goto IL_02cf;
					}
					double num;
					if (timeCheatingDetector.IsStarted && timeCheatingDetector.IsRunning)
					{
						if (!timeCheatingDetector.IsCheckingForCheat)
						{
							timeCheatingDetector.timeElapsed = 0f;
							IEnumerator routine = timeCheatingDetector.CheckForCheat();
							Coroutine coroutine = timeCheatingDetector.StartCoroutine(routine);
							Task task = Task.Delay(50);
							if (task != null)
							{
								TaskAwaiter awaiter2 = task.GetAwaiter();
								bool isCompleted = awaiter.IsCompleted;
								bool flag = !isCompleted;
								bool flag2 = !flag;
								object obj = 0;
								if (!flag2)
								{
									_003C_003E1__state = 0;
									_003C_003Eu__1 = awaiter;
									object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
									((AsyncTaskMethodBuilder<System.Int32Enum>*)obj2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
									return;
								}
								goto IL_050a;
							}
							ex = new NullReferenceException();
							goto IL_037e;
						}
						Debug.LogWarning("[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.");
						num = 2.12199579104E-312;
					}
					else
					{
						Debug.LogWarning("[ACTk] Time Cheating Detector: Detector should be started to use ForceCheckTask().");
						num = 2.121995791015E-312;
					}
					timeCheatingDetector.LastError = (ErrorKind)num;
					result = (System.Int32Enum)100;
					goto IL_0518;
				}
				_003C_003Eu__1 = default(TaskAwaiter);
				_003C_003E1__state = -1;
				awaiter = _003C_003Eu__1;
				goto IL_050a;
				IL_030b:
				result = (System.Int32Enum)timeCheatingDetector.LastResult;
				goto IL_0518;
				IL_02dd:
				int num2 = default(int);
				if ((object)timeCheatingDetector != null)
				{
					if (!timeCheatingDetector.IsCheckingForCheat)
					{
						goto IL_030b;
					}
					Task task2 = Task.Delay(50);
					if (task2 != null)
					{
						TaskAwaiter awaiter3 = task2.GetAwaiter();
						if (awaiter.IsCompleted)
						{
							goto IL_02cf;
						}
						_003C_003E1__state = 1;
						_003C_003Eu__1 = awaiter;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						((AsyncTaskMethodBuilder<System.Int32Enum>*)obj3)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					ex = new NullReferenceException();
					num2 = 0;
					goto IL_037e;
				}
				throw new NullReferenceException();
				IL_050a:
				awaiter.GetResult();
				if (timeCheatingDetector.IsCheckingForCheat)
				{
					goto IL_02dd;
				}
				goto IL_030b;
				IL_0518:
				_003C_003E1__state = -2;
				object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder<System.Int32Enum>*)obj4)->SetResult(result);
				return;
				IL_02cf:
				awaiter.GetResult();
				goto IL_02dd;
				IL_037e:
				bool flag3 = num2 != 1;
				NullReferenceException ex2 = ex;
				if (!flag3)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					object obj6 = default(object);
					object obj5 = obj6;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj7 = default(object);
					if ((int)((nint)obj7 & 1) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
						_003C_003E1__state = -2;
						object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						((AsyncTaskMethodBuilder<System.Int32Enum>*)obj8)->SetException((Exception)obj6);
						return;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
					object obj9 = obj6;
					num2 = 25534464 + 3976;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					object obj = 0;
					NullReferenceException ex3 = default(NullReferenceException);
					ex2 = ex3;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000403")]
			[Address(RVA = "0xBEF9F4", Offset = "0xBEF9F4", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+CheckResult>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3556B]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::SetStateMachine(v53, stateMachine);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//IL_0010: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder<System.Int32Enum>*)obj)->SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000046")]
		private sealed class _003CGetOnlineTimeCoroutine_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400013F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000140")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000141")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string url;

			[Token(Token = "0x4000142")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public OnlineTimeCallback callback;

			[Token(Token = "0x4000143")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public RequestMethod method;

			[Token(Token = "0x17000038")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000407")]
				[Address(RVA = "0xBEFB10", Offset = "0xBEFB10", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000039")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000409")]
				[Address(RVA = "0xBEFB50", Offset = "0xBEFB50", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000404")]
			[Address(RVA = "0xBED750", Offset = "0xBED750", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetOnlineTimeCoroutine_003Ed__51(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000405")]
			[Address(RVA = "0xBEFA70", Offset = "0xBEFA70", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000406")]
			[Address(RVA = "0xBEFA74", Offset = "0xBEFA74", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3556C]) = v33;\nL_0016:\n\tv40 = this.<>1__state == 1;\n\tif (v40) goto L_FFFFFFFF;\n\tv45 = this.<>1__state == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0039;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_002B;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tv78 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::UrlToUri(this.url);\n\tv79 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetOnlineTimeCoroutine(v78, this.callback, this.method);\n\tthis.<>2__current = v79;\n\tgoto L_0034;\nL_0034:\n\tthis.<>1__state = v65;\nL_0039:\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				bool result;
				int num;
				if (_003C_003E1__state != 1)
				{
					bool flag = _003C_003E1__state == 0;
					bool flag2 = !flag;
					result = false;
					if (flag2)
					{
						goto IL_00cc;
					}
					_003C_003E1__state = -1;
					Uri uri = UrlToUri(url);
					IEnumerator onlineTimeCoroutine = GetOnlineTimeCoroutine(uri, callback, method);
					_003C_003E2__current = onlineTimeCoroutine;
					result = true;
					num = 1;
				}
				else
				{
					result = false;
					num = -1;
				}
				_003C_003E1__state = num;
				goto IL_00cc;
				IL_00cc:
				return result;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000408")]
			[Address(RVA = "0xBEFB18", Offset = "0xBEFB18", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000047")]
		private sealed class _003CGetOnlineTimeCoroutine_003Ed__52 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000144")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000145")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000146")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public Uri uri;

			[Token(Token = "0x4000147")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public RequestMethod method;

			[Token(Token = "0x4000148")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public OnlineTimeCallback callback;

			[Token(Token = "0x4000149")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private OnlineTimeResult _003Cresult_003E5__2;

			[Token(Token = "0x400014A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private UnityWebRequest _003Cwr_003E5__3;

			[Token(Token = "0x1700003A")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600040E")]
				[Address(RVA = "0xBEFE88", Offset = "0xBEFE88", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700003B")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000410")]
				[Address(RVA = "0xBEFEC8", Offset = "0xBEFEC8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600040A")]
			[Address(RVA = "0xBED7F0", Offset = "0xBED7F0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003CGetOnlineTimeCoroutine_003Ed__52(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600040B")]
			[Address(RVA = "0xBEFB58", Offset = "0xBEFB58", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<>1__state == 2;\n\tif (v6) goto L_0012;\n\tv11 = this.<>1__state + 3;\n\tv13 = v11 == 0;\n\tv16 = ~v13;\n\tif (v16) goto L_0014;\nL_0012:\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__52::<>m__Finally1(this);\n\treturn;\nL_0014:\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				if (_003C_003E1__state == 2 || _003C_003E1__state + 3 == 0)
				{
					_003C_003Em__Finally1();
				}
			}

			[Token(Token = "0x600040C")]
			[Address(RVA = "0xBEFB74", Offset = "0xBEFB74", Length = "0x264")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv17 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv18 = \"il2cpp_codegen_initialize_runtime_metadata\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A3556D]) = v36;\nL_001A:\n\tv46 = this.<>1__state == 2;\n\tif (v46) goto L_0072;\n\tv55 = this.<>1__state == 1;\n\tif (v55) goto L_004C;\n\tv68 = this.<>1__state == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_FFFFFFFF;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_003B;\n\tv135 = v81;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v135, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv137 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_003B:\n\tv127 = ~v138.gettingOnlineTime;\n\tif (v127) goto L_0053;\n\tgoto L_0048;\n\tv265 = v130;\n\tv266 = \"il2cpp_codegen_runtime_class_init\"(v265, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv269 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_0048:\n\tv38.<>1__state = 1;\n\tv38.<>2__current = v270.CachedEndOfFrame;\n\tgoto L_00BB;\nL_004C:\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0053:\n\tgoto L_005C;\n\tv193 = v129;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v193, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv197 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_005C:\n\tv198.gettingOnlineTime = 1;\n\tv38.<result>5__2.errorResponseCode = 0;\n\tv38.<result>5__2 = 0;\n\tv202 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetWebRequest(v38.uri, v38.method);\n\tv38.<wr>5__3 = v202;\n\tv38.<>1__state = 0xFFFFFFFD;\n\tv180 = v202 == 0;\n\tif (v180) goto L_009D;\n\tv271 = UnityEngine.Networking.UnityWebRequest::SendWebRequest(v202);\n\tv38.<>2__current = v271;\n\tv38.<>1__state = 2;\n\tgoto L_00BB;\nL_0072:\n\tthis.<>1__state = 0xFFFFFFFD;\n\tgoto L_007C;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v64, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_007C:\n\tv76 = this + 0x38;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector::FillRequestResult(this.<wr>5__3, v76);\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__52::<>m__Finally1(v38);\n\tv38.<wr>5__3 = 0;\n\tv205 = v38.callback == 0;\n\tif (v205) goto L_0095;\n\tv251 = v38.<result>5__2;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeCallback::Invoke(v38.callback, &v251 @ V1_v3 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult));\nL_0095:\n\tgoto L_009B;\n\tv273 = v263;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v273, v162, v142, v21, v22, v23, v24, v25, v158, v156, v28, v29, v30, v31, v32, v33);\n\tv277 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_009B:\n\tv186.gettingOnlineTime = 0;\n\tgoto L_00BB;\nL_009D:\n\tv272 = new System.NullReferenceException();\n\tgoto L_00AC;\n\tgoto L_00AC;\n\tgoto L_00AC;\n\tgoto L_00AC;\n\tgoto L_00AC;\nL_00AC:\n\tv88 = v38.method != 1;\n\tif (v88) goto L_00C4;\n\tv279 = 0x1854E70(v272, v38.method, v20, v21, v22, v23, v24, v25, 0, v251, v28, v29, v30, v31, v32, v33);\n\tv118 = *([v279 @ X0_v27]);\n\tv114 = 0x1854E80(v279, v38.method, v20, v21, v22, v23, v24, v25, 0, v251, v28, v29, v30, v31, v32, v33);\n\tv298 = *([v279 @ X0_v27]) == 0;\n\tv116 = ~v298;\n\tif (v116) goto L_00BD;\nL_00BB:\n\treturn returnVal1;\nL_00BD:\n\tv311 = &v118 @ X19_v7 + 8;\n\tv312 = 0x9DD83C(v311, v38.method, v20, v21, v22, v23, v24, v25, 0, v251, v28, v29, v30, v31, v32, v33);\n\tv282 = new System.OutOfMemoryException();\n\tv316 = *([v279 @ X0_v27]) == 0;\n\tv284 = ~v316;\n\tif (v284) goto L_00CB;\nL_00C4:\n\tv288 = 0xBD3CD0(v272, v38.method, v20, v21, v22, v23, v24, v25, 0, v251, v28, v29, v30, v31, v32, v33);\nL_00CB:\n\tv296 = v38.<>1__state == 2;\n\tif (v296) goto L_00D8;\n\tv299 = v38.<>1__state + 3;\n\tv301 = v299 == 0;\n\tv304 = ~v301;\n\tif (v304) goto L_00DA;\nL_00D8:\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__52::<>m__Finally1(v38);\nL_00DA:\n\tv314 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v314, v38.method, v20, v21, v22, v23, v24, v25, 0, v251, v28, v29, v30, v31, v32, v33);\n\treturn returnVal2;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				//IL_012e: Expected O, but got Ref
				//IL_0344: Expected I8, but got I4
				//IL_01d6: Expected O, but got I
				_003CGetOnlineTimeCoroutine_003Ed__52 _003CGetOnlineTimeCoroutine_003Ed__53 = default(_003CGetOnlineTimeCoroutine_003Ed__52);
				if (_003C_003E1__state != 2)
				{
					if (_003C_003E1__state != 1)
					{
						if (_003C_003E1__state != 0)
						{
							goto IL_01b9;
						}
						_003C_003E1__state = -1;
						if (gettingOnlineTime)
						{
							_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state = 1;
							_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E2__current = CachedEndOfFrame;
							return true;
						}
					}
					else
					{
						_003C_003E1__state = -1;
					}
					gettingOnlineTime = true;
					_003CGetOnlineTimeCoroutine_003Ed__53._003Cresult_003E5__2.errorResponseCode = 0L;
					_003CGetOnlineTimeCoroutine_003Ed__53._003Cresult_003E5__2 = default(OnlineTimeResult);
					UnityWebRequest unityWebRequest = (_003CGetOnlineTimeCoroutine_003Ed__53._003Cwr_003E5__3 = GetWebRequest(_003CGetOnlineTimeCoroutine_003Ed__53.uri, _003CGetOnlineTimeCoroutine_003Ed__53.method));
					_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state = -3;
					if (unityWebRequest != null)
					{
						UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = unityWebRequest.SendWebRequest();
						_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E2__current = unityWebRequestAsyncOperation;
						_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state = 2;
						return true;
					}
					NullReferenceException ex = new NullReferenceException();
					if (_003CGetOnlineTimeCoroutine_003Ed__53.method == RequestMethod.Get)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
						object obj2 = default(object);
						object obj = obj2;
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
						if (obj2 == null)
						{
							goto IL_01b9;
						}
						object obj3 = (nint)obj + 8;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DD83C");
						OutOfMemoryException ex2 = new OutOfMemoryException();
						bool flag = obj2 == null;
						bool flag2 = !flag;
						ex = (NullReferenceException)(object)ex2;
						if (flag2)
						{
							goto IL_0237;
						}
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
					goto IL_0237;
				}
				_003C_003E1__state = -3;
				FillRequestResult(_003Cwr_003E5__3, ref *(OnlineTimeResult*)((nint)this + 56));
				_003CGetOnlineTimeCoroutine_003Ed__53._003C_003Em__Finally1();
				_003CGetOnlineTimeCoroutine_003Ed__53._003Cwr_003E5__3 = null;
				if (_003CGetOnlineTimeCoroutine_003Ed__53.callback != null)
				{
					OnlineTimeResult onlineTimeResult = _003CGetOnlineTimeCoroutine_003Ed__53._003Cresult_003E5__2;
					_003CGetOnlineTimeCoroutine_003Ed__53.callback((OnlineTimeResult)(&onlineTimeResult));
				}
				gettingOnlineTime = false;
				return false;
				IL_0237:
				if (_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state == 2 || _003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state + 3 == 0)
				{
					_003CGetOnlineTimeCoroutine_003Ed__53._003C_003Em__Finally1();
				}
				OutOfMemoryException ex3 = new OutOfMemoryException();
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
				bool result = default(bool);
				return result;
				IL_01b9:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x600040D")]
			[Address(RVA = "0xBEFDD8", Offset = "0xBEFDD8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = System.IDisposable;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3556E]) = v33;\nL_0012:\n\tthis.<>1__state = 0xFFFFFFFF;\n\tv36 = this.<wr>5__3 == 0;\n\tif (v36) goto L_003E;\n\tgoto L_004A;\n\tv46 = *([v38 @ X8_v4+B0]);\n\tv47 = v46 + 8;\n\tv49 = *([v140 @ X10_v7-8]);\n\tv145 = v49 == v41;\n\tif (v145) goto L_003F;\n\tv79 = v139 - 1;\n\tv81 = v140 + 0x10;\n\tv52 = v139 != 1;\n\tif (v52) goto L_FFFFFFFF;\n\tv82 = v34;\n\tv83 = 0;\n\tv84 = 0xB349B4(v82, v41, v83, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_004A;\nL_003E:\n\treturn;\nL_003F:\n\tv151 = *([v140 @ X10_v7]);\n\tv152 = v151 << 4;\n\tv153 = v38 + v152;\n\tv154 = v153 + 0x138;\nL_004A:\n\tSystem.IDisposable::Dispose(this.<wr>5__3);\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void _003C_003Em__Finally1()
			{
				_003C_003E1__state = -1;
				if (_003Cwr_003E5__3 != null)
				{
					((IDisposable)_003Cwr_003E5__3).Dispose();
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600040F")]
			[Address(RVA = "0xBEFE90", Offset = "0xBEFE90", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v22);\n\tthrow v22;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IEnumerator.Reset()
			{
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000048")]
		private struct _003CGetOnlineTimeTask_003Ed__53 : IAsyncStateMachine
		{
			[Token(Token = "0x400014B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x400014C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<OnlineTimeResult> _003C_003Et__builder;

			[Token(Token = "0x400014D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public string url;

			[Token(Token = "0x400014E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public RequestMethod method;

			[Token(Token = "0x400014F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private TaskAwaiter<OnlineTimeResult> _003C_003Eu__1;

			[Token(Token = "0x6000411")]
			[Address(RVA = "0xBEFED0", Offset = "0xBEFED0", Length = "0x274")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv56 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv112 = Il2CppMethodInfo;\n\tv113 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv212 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v212, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A3556F]) = v36;\nL_0027:\n\tv41 = this.<>1__state == 0;\n\tif (v41) goto L_005A;\n\tgoto L_0033;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0033:\n\tv61 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::UrlToUri(this.url);\n\tv247 = this.method;\n\tv86 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetOnlineTimeTask(v61, this.method);\n\tv114 = v86 == 0;\n\tif (v114) goto L_008B;\n\tv130 = System.Threading.Tasks.Task`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::GetAwaiter(v86);\n\tv69 = System.Runtime.CompilerServices.TaskAwaiter`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::get_IsCompleted(&v64 @ stack_-68_v2 (System.Runtime.CompilerServices.TaskAwaiter`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>));\n\tv258 = v69 == 0;\n\tv71 = ~v258;\n\tif (v71) goto L_0061;\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v64;\n\tgoto L_0051;\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v262, v67, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0051:\n\tv195 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::AwaitUnsafeOnCompleted(v195, &v64 @ stack_-68_v2 (System.Runtime.CompilerServices.TaskAwaiter`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>), this);\n\tgoto L_008A;\nL_005A:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0061:\n\tv81 = System.Runtime.CompilerServices.TaskAwaiter`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::GetResult(&v64 @ stack_-68_v2 (System.Runtime.CompilerServices.TaskAwaiter`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>));\n\tv87 = v81.success;\n\tthis.<>1__state = 0xFFFFFFFE;\n\tv101 = this + 8;\n\tgoto L_0084;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v104, v77, v19, v20, v21, v22, v23, v24, v102, v103, v27, v28, v29, v30, v31, v32);\nL_0084:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::SetResult(v101, &v87 @ stack_-40_v1 (System.Boolean));\nL_008A:\n\treturn;\nL_008B:\n\tv131 = new System.NullReferenceException();\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\n\tgoto L_009C;\nL_009C:\n\tv134 = this.method != 1;\n\tif (v134) goto L_00CA;\n\tv266 = 0x1854E70(v131, this.method, v243, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv283 = *([v266 @ X0_v21]);\n\tv285 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v283 @ X8_v16]), v243, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv286 = v285 & 1;\n\tv271 = v286 == 0;\n\tif (v271) goto L_00C0;\n\tv287 = 0x1854E80(v285, *([v283 @ X8_v16]), v243, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tthis.<>1__state = 0xFFFFFFFE;\n\tv201 = this + 8;\n\tgoto L_00BD;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v293, v284, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_00BD:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::SetException(v201, *([v266 @ X0_v21]));\n\tgoto L_008A;\nL_00C0:\n\tv289 = 0x1854E90(8, *([v283 @ X8_v16]), v243, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\t*([v289 @ X0_v27]) = *([v266 @ X0_v21]);\n\tv247 = 0x185A000 + 0xF88;\n\tv295 = 0x1854EA0(v289, v247, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv270 = 0x1854E80(v295, v247, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_00CA:\n\tv275 = 0xBD3CD0(v256, v247, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv249 = 0x9DACB4(v275, v247, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void MoveNext()
			{
				//IL_02b6: Expected O, but got Ref
				//IL_0112: Expected O, but got Ref
				//IL_00c4: Expected O, but got Ref
				//IL_01cc: Expected O, but got Ref
				TaskAwaiter<OnlineTimeResult> awaiter2 = default(TaskAwaiter<OnlineTimeResult>);
				if (_003C_003E1__state != 0)
				{
					Uri uri = UrlToUri(url);
					RequestMethod requestMethod = method;
					Task<OnlineTimeResult> onlineTimeTask = GetOnlineTimeTask(uri, method);
					if (onlineTimeTask == null)
					{
						NullReferenceException ex = new NullReferenceException();
						bool flag = method != RequestMethod.Get;
						NullReferenceException ex2 = ex;
						if (!flag)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
							object obj2 = default(object);
							object obj = obj2;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj3 = default(object);
							if ((int)((nint)obj3 & 1) != 0)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
								_003C_003E1__state = -2;
								AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
								((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder)->SetException((Exception)obj2);
								return;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
							object obj4 = obj2;
							requestMethod = (RequestMethod)25538440;
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							NullReferenceException ex3 = default(NullReferenceException);
							ex2 = ex3;
						}
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
						return;
					}
					TaskAwaiter<OnlineTimeResult> awaiter = onlineTimeTask.GetAwaiter();
					if (!awaiter2.IsCompleted)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = awaiter2;
						AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
						return;
					}
				}
				else
				{
					_003C_003Eu__1 = default(TaskAwaiter<OnlineTimeResult>);
					_003C_003E1__state = -1;
					awaiter2 = _003C_003Eu__1;
				}
				bool success = awaiter2.GetResult().success;
				_003C_003E1__state = -2;
				AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder3)->SetResult((OnlineTimeResult)(&success));
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000412")]
			[Address(RVA = "0xBF0144", Offset = "0xBF0144", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35570]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::SetStateMachine(v53, stateMachine);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//IL_0010: Expected O, but got Ref
				AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000049")]
		private struct _003CGetOnlineTimeTask_003Ed__54 : IAsyncStateMachine
		{
			[Token(Token = "0x4000150")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int _003C_003E1__state;

			[Token(Token = "0x4000151")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public AsyncTaskMethodBuilder<OnlineTimeResult> _003C_003Et__builder;

			[Token(Token = "0x4000152")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public Uri uri;

			[Token(Token = "0x4000153")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public RequestMethod method;

			[Token(Token = "0x4000154")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private OnlineTimeResult _003Cresult_003E5__2;

			[Token(Token = "0x4000155")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private TaskAwaiter _003C_003Eu__1;

			[Token(Token = "0x4000156")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			private UnityWebRequest _003Cwr_003E5__3;

			[Token(Token = "0x4000157")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			private UnityWebRequestAsyncOperation _003CasyncOperation_003E5__4;

			[Token(Token = "0x6000413")]
			[Address(RVA = "0xBF01C0", Offset = "0xBF01C0", Length = "0x580")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv148 = System.IDisposable;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv195 = System.Threading.Tasks.Task;\n\tv196 = \"il2cpp_codegen_initialize_runtime_metadata\"(v195, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv206 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v206, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35571]) = v42;\nL_0029:\n\tv375 = this.<>1__state;\n\tv52 = this.<>1__state == 0;\n\tif (v52) goto L_003C;\n\tv60 = v375 == 1;\n\tif (v60) goto L_0042;\n\tgoto L_011C;\nL_003C:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = 0xFFFFFFFF;\n\tgoto L_0117;\nL_0042:\n\tthis.<>u__1 = 0;\n\tthis.<>1__state = 0xFFFFFFFF;\nL_0046:\n\tSystem.Runtime.CompilerServices.TaskAwaiter::GetResult(&v79 @ stack_-38_v9 (System.Runtime.CompilerServices.TaskAwaiter));\nL_004B:\n\tv221 = UnityEngine.AsyncOperation::get_isDone(v215);\n\tv249 = v221 == 0;\n\tv250 = ~v249;\n\tif (v250) goto L_007E;\n\tgoto L_0058;\n\tv297 = \"il2cpp_codegen_runtime_class_init\"(v277, v220, v25, v26, v27, v28, v29, v30, v160, v32, v33, v34, v35, v36, v37, v38);\nL_0058:\n\tv301 = System.Threading.Tasks.Task::Delay(0x64);\n\tv497 = System.Threading.Tasks.Task::GetAwaiter(v301);\n\tv186 = System.Runtime.CompilerServices.TaskAwaiter::get_IsCompleted(&v79 @ stack_-38_v9 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv627 = v186 == 0;\n\tv188 = ~v627;\n\tif (v188) goto L_0046;\n\tthis.<>1__state = 1;\n\tthis.<>u__1 = v79;\n\tgoto L_0073;\n\tv770 = \"il2cpp_codegen_runtime_class_init\"(v672, v164, v25, v26, v27, v28, v29, v30, v160, v32, v33, v34, v35, v36, v37, v38);\nL_0073:\n\tv401 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::AwaitUnsafeOnCompleted(v401, &v79 @ stack_-38_v9 (System.Runtime.CompilerServices.TaskAwaiter), this);\n\tgoto L_0161;\nL_007E:\n\tgoto L_0080;\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v280, v220, v25, v26, v27, v28, v29, v30, v160, v32, v33, v34, v35, v36, v37, v38);\nL_0080:\n\tv304 = this + 0x30;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector::FillRequestResult(this.<wr>5__3, v304);\n\tthis.<asyncOperation>5__4 = 0;\n\tv448 = v375 & 0x80000000;\n\tv449 = v448 == 0;\n\tif (v449) goto L_00B9;\nL_008A:\n\tv545 = this.<wr>5__3 == 0;\n\tif (v545) goto L_00B9;\n\tgoto L_00B8;\n\tv628 = *([v605 @ X8_v43+B0]);\n\tv629 = v628 + 8;\n\tv631 = *([v678 @ X10_v22-8]);\n\tv691 = v631 == v608;\n\tif (v691) goto L_00B1;\n\tv635 = v677 - 1;\n\tv637 = v678 + 0x10;\n\tv633 = v677 != 1;\n\tif (v633) goto L_FFFFFFFF;\n\tv654 = v544;\n\tv655 = 0;\n\tv656 = 0xB349B4(v654, v608, v655, v26, v27, v28, v29, v30, v501, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00B8;\nL_00B1:\n\tv774 = *([v678 @ X10_v22]);\n\tv775 = v774 << 4;\n\tv776 = v605 + v775;\n\tv777 = v776 + 0x138;\nL_00B8:\n\tSystem.IDisposable::Dispose(this.<wr>5__3);\nL_00B9:\n\tv573 = v356 == 0;\n\tv574 = ~v573;\n\tif (v574) goto L_00F6;\n\tv389 = v353 == 0xC;\n\tif (v389) goto L_00C9;\n\tv657 = v353 == 0;\n\tv407 = ~v657;\n\tif (v407) goto L_0161;\nL_00C9:\n\tthis.<wr>5__3 = 0;\n\tgoto L_00D4;\n\tv696 = \"il2cpp_codegen_runtime_class_init\"(v659, v367, v360, v26, v27, v28, v29, v30, v333, v32, v33, v34, v35, v36, v37, v38);\n\tv698 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_00D4:\n\tv699.gettingOnlineTime = 0;\n\tv71 = this.<result>5__2;\n\tthis.<>1__state = 0xFFFFFFFE;\n\tthis.<result>5__2 = 0;\n\t*([this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeTask>d__54)+40]) = 0;\n\tv411 = this + 8;\n\tgoto L_00F2;\n\tv781 = \"il2cpp_codegen_runtime_class_init\"(v706, v367, v360, v26, v27, v28, v29, v30, v704, v705, v313, v34, v35, v36, v37, v38);\nL_00F2:\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::SetResult(v411, &v71 @ V0_v17 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult));\n\tgoto L_0161;\n\tthrow System.NullReferenceException;\nL_00F6:\n\tv603 = new System.OutOfMemoryException();\n\tgoto L_0174;\n\tgoto L_FFFFFFFF;\n\tgoto L_01BF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0105:\n\tgoto L_0109;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v209, v151, v25, v26, v27, v28, v29, v30, v43, v32, v33, v34, v35, v36, v37, v38);\nL_0109:\n\tv247 = System.Threading.Tasks.Task::Delay(0x64);\n\tv295 = System.Threading.Tasks.Task::GetAwaiter(v247);\n\tv139 = System.Runtime.CompilerServices.TaskAwaiter::get_IsCompleted(&v79 @ stack_-38_v9 (System.Runtime.CompilerServices.TaskAwaiter));\n\tv141 = v139 == 0;\n\tif (v141) goto L_0147;\nL_0117:\n\tSystem.Runtime.CompilerServices.TaskAwaiter::GetResult(&v79 @ stack_-38_v9 (System.Runtime.CompilerServices.TaskAwaiter));\nL_011C:\n\tgoto L_0121;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v155, v151, v25, v26, v27, v28, v29, v30, v43, v32, v33, v34, v35, v36, v37, v38);\n\tv199 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_0121:\n\tv201 = ~v200.gettingOnlineTime;\n\tv202 = ~v201;\n\tif (v202) goto L_0105;\n\tgoto L_012C;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v198, v151, v25, v26, v27, v28, v29, v30, v43, v32, v33, v34, v35, v36, v37, v38);\n\tv274 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv241 = *([v274 @ X8_v37+B8]);\nL_012C:\n\tv103.gettingOnlineTime = 1;\n\tthis.<result>5__2 = 0;\n\t*([this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeTask>d__54)+40]) = 0;\n\tv99 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetWebRequest(this.uri, this.method);\n\tv91 = v375 == 1;\n\tthis.<wr>5__3 = v99;\n\tif (v91) goto L_0042;\n\tv293 = v99 == 0;\n\tif (v293) goto L_0163;\n\tv216 = UnityEngine.Networking.UnityWebRequest::SendWebRequest(v99);\n\tthis.<asyncOperation>5__4 = v216;\n\tv494 = v216 == 0;\n\tv218 = ~v494;\n\tif (v218) goto L_004B;\n\tthrow System.NullReferenceException;\nL_0147:\n\tthis.<>1__state = 0;\n\tthis.<>u__1 = v79;\n\tgoto L_0154;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v270, v253, v25, v26, v27, v28, v29, v30, v251, v32, v33, v34, v35, v36, v37, v38);\nL_0154:\n\tv289 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::AwaitUnsafeOnCompleted(v289, &v79 @ stack_-38_v9 (System.Runtime.CompilerServices.TaskAwaiter), this);\nL_0161:\n\treturn;\n\tv296 = new System.NullReferenceException();\nL_0163:\n\tv442 = new System.NullReferenceException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_01BF;\n\tgoto L_01BF;\n\tgoto L_01BF;\n\tgoto L_01BF;\nL_0174:\n\tv505 = v720 != 1;\n\tif (v505) goto L_0181;\n\tv664 = 0x1854E70(v716, v720, v718, v26, v27, v28, v29, v30, v71, v32, v33, v34, v35, v36, v37, v38);\n\tv356 = *([v664 @ X0_v38]);\n\tv537 = 0x1854E80(v664, v720, v718, v26, v27, v28, v29, v30, v71, v32, v33, v34, v35, v36, v37, v38);\n\tv784 = v375 & 0x80000000;\n\tv539 = v784 == 0;\n\tif (v539) goto L_00B9;\n\tgoto L_008A;\nL_0181:\n\tv666 = v375 & 0x80000000;\n\tv667 = v666 == 0;\n\tif (v667) goto L_01B5;\nL_0185:\n\tv747 = this.<wr>5__3 == 0;\n\tif (v747) goto L_01B5;\n\tgoto L_01B3;\n\tv792 = *([v786 @ X8_v11+B0]);\n\tv793 = v792 + 8;\n\tv795 = *([v837 @ X10_v10-8]);\n\tv850 = v795 == v789;\n\tif (v850) goto L_01AC;\n\tv799 = v836 - 1;\n\tv801 = v837 + 0x10;\n\tv797 = v836 != 1;\n\tif (v797) goto L_FFFFFFFF;\n\tv818 = v746;\n\tv819 = 0;\n\tv820 = 0xB349B4(v818, v789, v819, v26, v27, v28, v29, v30, v462, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_01B3;\nL_01AC:\n\tv859 = *([v837 @ X10_v10]);\n\tv860 = v859 << 4;\n\tv861 = v786 + v860;\n\tv862 = v86\n// ... truncated")]
			private unsafe void MoveNext()
			{
				//IL_0199: Expected I4, but got I8
				//IL_03a7: Expected O, but got Ref
				//IL_046e: Expected I4, but got I8
				//IL_03fa: Expected I4, but got O
				//IL_0770: Expected O, but got Ref
				//IL_0420: Expected I4, but got I8
				//IL_026c: Expected O, but got Ref
				//IL_014e: Expected O, but got Ref
				//IL_0457: Expected I4, but got O
				//IL_05fa: Expected O, but got Ref
				int num = _003C_003E1__state;
				OnlineTimeResult onlineTimeResult;
				TaskAwaiter awaiter = default(TaskAwaiter);
				if (_003C_003E1__state != 0)
				{
					bool flag = num == 1;
					onlineTimeResult = default(OnlineTimeResult);
					if (flag)
					{
						goto IL_0068;
					}
					awaiter = default(TaskAwaiter);
					goto IL_0795;
				}
				_003C_003Eu__1 = default(TaskAwaiter);
				_003C_003E1__state = -1;
				num = -1;
				goto IL_02ec;
				IL_06c7:
				awaiter.GetResult();
				AsyncOperation asyncOperation = _003CasyncOperation_003E5__4;
				goto IL_0095;
				IL_0068:
				_003C_003Eu__1 = default(TaskAwaiter);
				_003C_003E1__state = -1;
				num = -1;
				goto IL_06c7;
				IL_06df:
				int num2;
				bool flag2 = num2 == 0;
				bool flag3 = !flag2;
				ref OnlineTimeResult reference = ref *(OnlineTimeResult*)null;
				int num3;
				if (!flag3)
				{
					if (num3 == 12 || num3 == 0)
					{
						_003Cwr_003E5__3 = null;
						gettingOnlineTime = false;
						onlineTimeResult = _003Cresult_003E5__2;
						_003C_003E1__state = -2;
						_003Cresult_003E5__2 = default(OnlineTimeResult);
						_ = 0;
						AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder)->SetResult((OnlineTimeResult)(&onlineTimeResult));
					}
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				OutOfMemoryException ex2 = ex;
				int num5 = default(int);
				int num4 = num5;
				num = 1;
				goto IL_0775;
				IL_0795:
				if (gettingOnlineTime)
				{
					Task task = Task.Delay(100);
					TaskAwaiter awaiter2 = task.GetAwaiter();
					if (awaiter.IsCompleted)
					{
						goto IL_02ec;
					}
					_003C_003E1__state = 0;
					_003C_003Eu__1 = awaiter;
					AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
				gettingOnlineTime = true;
				_003Cresult_003E5__2 = default(OnlineTimeResult);
				_ = 0;
				UnityWebRequest webRequest = GetWebRequest(uri, method);
				bool flag4 = num == 1;
				_003Cwr_003E5__3 = webRequest;
				onlineTimeResult = default(OnlineTimeResult);
				if (flag4)
				{
					goto IL_0068;
				}
				bool flag5 = webRequest == null;
				onlineTimeResult = default(OnlineTimeResult);
				if (!flag5)
				{
					UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = (_003CasyncOperation_003E5__4 = webRequest.SendWebRequest());
					bool flag6 = unityWebRequestAsyncOperation == null;
					bool flag7 = !flag6;
					onlineTimeResult = default(OnlineTimeResult);
					asyncOperation = unityWebRequestAsyncOperation;
					if (!flag7)
					{
						throw new NullReferenceException();
					}
					goto IL_0095;
				}
				NullReferenceException ex3 = new NullReferenceException();
				ex2 = (OutOfMemoryException)(object)ex3;
				num4 = num5;
				reference = ref *(OnlineTimeResult*)null;
				goto IL_0775;
				IL_0095:
				if (!asyncOperation.isDone)
				{
					Task task2 = Task.Delay(100);
					TaskAwaiter awaiter3 = task2.GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						_003C_003E1__state = 1;
						_003C_003Eu__1 = awaiter;
						AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_06c7;
				}
				FillRequestResult(_003Cwr_003E5__3, ref System.Runtime.CompilerServices.Unsafe.As<_003CGetOnlineTimeTask_003Ed__54, OnlineTimeResult>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 48)));
				_003CasyncOperation_003E5__4 = null;
				int num6 = (int)(num & 0x80000000L);
				bool flag8 = num6 == 0;
				int num7 = 12;
				int num8 = 0;
				num3 = 12;
				num2 = 0;
				if (!flag8)
				{
					goto IL_01da;
				}
				goto IL_06df;
				IL_0775:
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) == (void*)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					object obj = default(object);
					num2 = (int)obj;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					int num9 = (int)(num & 0x80000000L);
					bool flag9 = num9 == 0;
					num3 = 0;
					if (!flag9)
					{
						num7 = 0;
						num8 = (int)obj;
						goto IL_01da;
					}
					goto IL_06df;
				}
				int num10 = (int)(num & 0x80000000L);
				bool flag10 = num10 == 0;
				ref OnlineTimeResult reference2 = ref reference;
				OutOfMemoryException ex4 = ex2;
				int num11 = num4;
				ref OnlineTimeResult reference3 = ref reference;
				ref OnlineTimeResult reference4 = ref reference;
				if (!flag10)
				{
					bool flag11 = _003Cwr_003E5__3 == null;
					ex4 = ex2;
					num11 = num4;
					reference3 = ref reference;
					reference4 = ref reference2;
					if (!flag11)
					{
						((IDisposable)_003Cwr_003E5__3).Dispose();
						ex4 = ex2;
						num11 = 0;
						reference3 = ref *(OnlineTimeResult*)null;
						reference4 = ref reference2;
					}
				}
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference4) == (void*)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					object obj3 = default(object);
					object obj2 = obj3;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj4 = default(object);
					if ((int)((nint)obj4 & 1) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
						_003C_003E1__state = -2;
						_003Cresult_003E5__2 = default(OnlineTimeResult);
						_ = 0;
						AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder4)->SetException((Exception)obj3);
						return;
					}
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
					object obj5 = obj3;
					reference3 = ref *(OnlineTimeResult*)(25534464 + 3976);
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					OutOfMemoryException ex5 = default(OutOfMemoryException);
					ex4 = ex5;
					num11 = 0;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
				return;
				IL_02ec:
				awaiter.GetResult();
				goto IL_0795;
				IL_01da:
				bool flag12 = _003Cwr_003E5__3 == null;
				num3 = num7;
				num2 = num8;
				if (!flag12)
				{
					((IDisposable)_003Cwr_003E5__3).Dispose();
					num3 = num7;
					num2 = num8;
				}
				goto IL_06df;
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000414")]
			[Address(RVA = "0xBF0740", Offset = "0xBF0740", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35572]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, stateMachine, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = this + 8;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::SetStateMachine(v53, stateMachine);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//IL_0010: Expected O, but got Ref
				AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<OnlineTimeResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder<OnlineTimeResult>*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Token(Token = "0x4000106")]
		public const string ComponentName = "Time Cheating Detector";

		[Token(Token = "0x4000107")]
		private const string FinalLogPrefix = "[ACTk] Time Cheating Detector: ";

		[Token(Token = "0x4000108")]
		private const int DefaultTimeoutSeconds = 10;

		[Token(Token = "0x4000109")]
		private static readonly WaitForEndOfFrame CachedEndOfFrame;

		[Token(Token = "0x400010A")]
		private static bool gettingOnlineTime;

		[Token(Token = "0x400010B")]
		private static int sdkLevel;

		[CompilerGenerated]
		[Token(Token = "0x400010C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		private TimeCheatingDetectorEventHandler m_CheatChecked;

		[Tooltip("Absolute URL which will return correct datetime in response headers (you may use popular web servers like google.com, microsoft.com etc.).")]
		[SerializeField]
		[Header("Request settings")]
		[Token(Token = "0x400010D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		private string requestUrl;

		[Tooltip("Method to use for url request. Use Head method if possible and fall back to get if server does not reply or block head requests.")]
		[Token(Token = "0x400010E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public RequestMethod requestMethod;

		[Tooltip("Online time request timeout in seconds.")]
		[Token(Token = "0x400010F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x64")]
		public int timeoutSeconds;

		[Tooltip("Time (in minutes) between detector checks.")]
		[Header("Settings in minutes")]
		[Range(0f, 60f)]
		[Token(Token = "0x4000110")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		public float interval;

		[Tooltip("Maximum allowed difference between subsequent measurements, in minutes.")]
		[Range(10f, 180f)]
		[FormerlySerializedAs("threshold")]
		[Token(Token = "0x4000111")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x6C")]
		public int realCheatThreshold;

		[Range(1f, 180f)]
		[Tooltip("Maximum allowed difference between local and online time, in minutes.")]
		[Token(Token = "0x4000112")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		public int wrongTimeThreshold;

		[Tooltip("Ignore case when time changes to be in sync with online correct time. Wrong time threshold is taken into account.")]
		[Token(Token = "0x4000113")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x74")]
		public bool ignoreSetCorrectTime;

		[CompilerGenerated]
		[Token(Token = "0x4000114")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
		private ErrorKind _003CLastError_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000115")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x7C")]
		private CheckResult _003CLastResult_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000116")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
		private bool _003CIsCheckingForCheat_003Ek__BackingField;

		[Token(Token = "0x4000117")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
		private readonly string onlineOfflineDifferencePrefsKey;

		[Token(Token = "0x4000118")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x90")]
		private Uri cachedUri;

		[Token(Token = "0x4000119")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x98")]
		private TimeCheatingDetectorEventHandler cheatChecked;

		[Token(Token = "0x400011A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
		private float timeElapsed;

		[Token(Token = "0x400011B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA4")]
		private bool updateAfterPause;

		[Token(Token = "0x400011C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xA8")]
		private double lastOnlineSecondsUtc;

		[CompilerGenerated]
		[Token(Token = "0x400011D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB0")]
		private Action<ErrorKind> m_Error;

		[CompilerGenerated]
		[Token(Token = "0x400011E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xB8")]
		private Action m_CheckPassed;

		[NonSerialized]
		[Obsolete("Use wrongTimeThreshold instead.", true)]
		[Token(Token = "0x400011F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC0")]
		public int threshold;

		[NonSerialized]
		[Obsolete("Use requestUrl instead", true)]
		[Token(Token = "0x4000120")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
		public string timeServer;

		[Token(Token = "0x17000030")]
		public string RequestUrl
		{
			[Token(Token = "0x60003BB")]
			[Address(RVA = "0xBECE78", Offset = "0xBECE78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.requestUrl;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RequestUrl;
			}
			[Token(Token = "0x60003BC")]
			[Address(RVA = "0xBECE80", Offset = "0xBECE80", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv43 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, value, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35547]) = v37;\nL_0018:\n\tv41 = System.String::op_Equality(this.requestUrl, value);\n\tv45 = v41 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_003B;\n\tgoto L_0026;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v49, v39, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0026:\n\tv55 = UnityEngine.Application::get_isPlaying();\n\tv58 = v55 == 0;\n\tif (v58) goto L_003B;\n\tthis.requestUrl = value;\n\tgoto L_0034;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v71, v39, v40, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0034:\n\tv54 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::UrlToUri(value);\n\tthis.cachedUri = v54;\nL_003B:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (!(RequestUrl == value) && Application.isPlaying)
				{
					requestUrl = value;
					Uri uri = UrlToUri(value);
					cachedUri = uri;
				}
			}
		}

		[Token(Token = "0x17000031")]
		public ErrorKind LastError
		{
			[CompilerGenerated]
			[Token(Token = "0x60003BD")]
			[Address(RVA = "0xBECFFC", Offset = "0xBECFFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastError>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LastError;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003BE")]
			[Address(RVA = "0xBED004", Offset = "0xBED004", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastError>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLastError_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000032")]
		public CheckResult LastResult
		{
			[CompilerGenerated]
			[Token(Token = "0x60003BF")]
			[Address(RVA = "0xBED00C", Offset = "0xBED00C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LastResult>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LastResult;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003C0")]
			[Address(RVA = "0xBED014", Offset = "0xBED014", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LastResult>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CLastResult_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000033")]
		public bool IsCheckingForCheat
		{
			[CompilerGenerated]
			[Token(Token = "0x60003C1")]
			[Address(RVA = "0xBED01C", Offset = "0xBED01C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsCheckingForCheat>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsCheckingForCheat;
			}
			[CompilerGenerated]
			[Token(Token = "0x60003C2")]
			[Address(RVA = "0xBED024", Offset = "0xBED024", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsCheckingForCheat>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CIsCheckingForCheat_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x14000005")]
		public event TimeCheatingDetectorEventHandler CheatChecked
		{
			[CompilerGenerated]
			[Token(Token = "0x60003B9")]
			[Address(RVA = "0xBECD40", Offset = "0xBECD40", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+TimeCheatingDetectorEventHandler;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35545]) = v38;\nL_0014:\n\tv40 = this + 0x50;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != CodeStage.AntiCheat.Detectors.TimeCheatingDetector+TimeCheatingDetectorEventHandler;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_CheatChecked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TimeCheatingDetectorEventHandler))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60003BA")]
			[Address(RVA = "0xBECDDC", Offset = "0xBECDDC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+TimeCheatingDetectorEventHandler;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35546]) = v38;\nL_0014:\n\tv40 = this + 0x50;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != CodeStage.AntiCheat.Detectors.TimeCheatingDetector+TimeCheatingDetectorEventHandler;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_CheatChecked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(TimeCheatingDetectorEventHandler))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Obsolete("Please use CheatChecked event instead", true)]
		[Token(Token = "0x14000006")]
		public event Action<ErrorKind> Error
		{
			[CompilerGenerated]
			[Token(Token = "0x60003E0")]
			[Address(RVA = "0xBEEA04", Offset = "0xBEEA04", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.Action`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+ErrorKind>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3555F]) = v42;\nL_0016:\n\tv44 = this + 0xB0;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.Action`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+ErrorKind>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 176;
				Delegate obj2 = this.m_Error;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as Action<ErrorKind>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60003E1")]
			[Address(RVA = "0xBEEAB4", Offset = "0xBEEAB4", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.Action`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+ErrorKind>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A35560]) = v42;\nL_0016:\n\tv44 = this + 0xB0;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.Action`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+ErrorKind>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 176;
				Delegate obj2 = this.m_Error;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as Action<ErrorKind>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Obsolete("Please use CheatChecked event instead", true)]
		[Token(Token = "0x14000007")]
		public event Action CheckPassed
		{
			[CompilerGenerated]
			[Token(Token = "0x60003E2")]
			[Address(RVA = "0xBEEB64", Offset = "0xBEEB64", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35561]) = v38;\nL_0014:\n\tv40 = this + 0xB8;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 184;
				Delegate obj2 = this.m_CheckPassed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60003E3")]
			[Address(RVA = "0xBEEC00", Offset = "0xBEEC00", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35562]) = v38;\nL_0014:\n\tv40 = this + 0xB8;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 184;
				Delegate obj2 = this.m_CheckPassed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(Action))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60003B8")]
		[Address(RVA = "0xBECD00", Offset = "0xBECD00", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = \"Time Cheating Detector\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35544]) = v34;\nL_0016:\n\treturn \"Time Cheating Detector\";\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override string GetComponentName()
		{
			return "Time Cheating Detector";
		}

		[Token(Token = "0x60003C3")]
		[Address(RVA = "0xBED030", Offset = "0xBED030", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.started;\n\tif (v2) goto L_000A;\n\tv3 = this->klass;\n\tv6 = pauseStatus == 0;\n\tif (v6) goto L_000B;\n\tv7 = this->klass->vtable[14];\n\tv8 = this->klass->vtable[14];\n\t// 9 IndirectJump v7 @ X2_v2, this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v8 @ X1_v2, v7 @ X2_v2, v9 @ X3, v10 @ X4, v11 @ X5, v12 @ X6, v13 @ X7, v14 @ V0, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\nL_000A:\n\treturn;\nL_000B:\n\tv22 = this->klass->vtable[15];\n\tv23 = this->klass->vtable[15];\n\t// 13 IndirectJump v22 @ X2_v1, this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v23 @ X1_v1, v22 @ X2_v1, v9 @ X3, v10 @ X4, v11 @ X5, v12 @ X6, v13 @ X7, v14 @ V0, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool pauseStatus)
		{
			//IL_0020: Expected I, but got O
			//IL_0078: Expected O, but got I
			//IL_0088: Expected O, but got I
			//IL_004d: Expected O, but got I
			//IL_005d: Expected O, but got I
			if (IsStarted)
			{
				nint num = (nint)this;
				if (pauseStatus)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v2 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+218]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v2 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+220]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X2_v2 (should have been resolved before IL gen)");
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v2 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+228]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3 @ X8_v2 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+230]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X2_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x60003C4")]
		[Address(RVA = "0xBED05C", Offset = "0xBED05C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~this.started;\n\tif (v8) goto L_0036;\n\tv11 = ~this.isRunning;\n\tif (v11) goto L_0036;\n\tv25 = this.interval <= 0;\n\tif (v25) goto L_0036;\n\tv64 = ~this.updateAfterPause;\n\tif (v64) goto L_0020;\n\tthis.updateAfterPause = 0;\n\tgoto L_0036;\nL_0020:\n\tv102 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv59 = this.timeElapsed + v102;\n\tv16 = this.interval * 0x42700000;\n\tthis.timeElapsed = v59;\n\tv23 = v59 >= v16;\n\tif (v23) goto L_0038;\nL_0036:\n\treturn;\nL_0038:\n\tthis.timeElapsed = 0f;\n\tv106 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::CheckForCheat(this);\n\tv85 = UnityEngine.MonoBehaviour::StartCoroutine(this, v106);\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (!IsStarted || !IsRunning || !(interval > 0f))
			{
				return;
			}
			if (updateAfterPause)
			{
				updateAfterPause = false;
				return;
			}
			float unscaledDeltaTime = UnityEngine.Time.unscaledDeltaTime;
			float num = timeElapsed + unscaledDeltaTime;
			float num2 = interval * 60f;
			timeElapsed = num;
			if (!(num < num2))
			{
				timeElapsed = 0f;
				IEnumerator routine = CheckForCheat();
				Coroutine coroutine = StartCoroutine(routine);
			}
		}

		[Token(Token = "0x60003C5")]
		[Address(RVA = "0xBED150", Offset = "0xBED150", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35548]) = v34;\nL_0016:\n\treturnVal1 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::get_GetOrCreateInstance();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TimeCheatingDetector AddToSceneOrGetExisting()
		{
			return KeepAliveBehaviour<TimeCheatingDetector>.GetOrCreateInstance;
		}

		[Token(Token = "0x60003C6")]
		[Address(RVA = "0xBED190", Offset = "0xBED190", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv60 = UnityEngine.Object;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv72 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35549]) = v40;\nL_0020:\n\tv45 = v130 == 0;\n\tif (v45) goto L_0039;\n\tv50 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::get_GetOrCreateInstance();\n\tgoto L_FFFFFFFF;\n\tv111 = v73;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v111, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_00A0;\nL_0039:\n\tgoto L_0041;\n\tv63 = 0xB348B0(v54, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0041:\n\tgoto L_004B;\n\tv105 = 0xB348B0(v66, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004B:\n\tgoto L_0051;\n\tv116 = v102;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v116, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0051:\n\tv120 = UnityEngine.Object::op_Inequality(v89.<Instance>k__BackingField, 0);\n\tv169 = v120 == 0;\n\tif (v169) goto L_008C;\n\tgoto L_0063;\n\tv177 = 0xB348B0(v171, v81, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0063:\n\tgoto L_006D;\n\tv185 = 0xB348B0(v180, v81, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_006D:\n\tgoto L_0077;\n\tv193 = v188;\n\tv194 = 0xB348B0(v193, v81, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv197 = v194;\nL_0077:\n\tgoto L_007A;\n\tv207 = 0xB348B0(v199, v81, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_007A:\n\tv101 = v208.<Instance>k__BackingField;\n\treturnVal3 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::StartDetectionInternal(v88.<Instance>k__BackingField, v101.interval, 0);\n\treturn returnVal3;\nL_008C:\n\tv92 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::get_GetOrCreateInstance();\n\tgoto L_FFFFFFFF;\n\tv204 = v136;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v204, v81, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00A0:\n\treturnVal2 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::StartDetection(v124, 0);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TimeCheatingDetector StartDetection(TimeCheatingDetectorEventHandler cheatCheckedEventHandler = null)
		{
			TimeCheatingDetectorEventHandler timeCheatingDetectorEventHandler = default(TimeCheatingDetectorEventHandler);
			float intervalMinutes;
			if (timeCheatingDetectorEventHandler != null)
			{
				TimeCheatingDetector getOrCreateInstance = KeepAliveBehaviour<TimeCheatingDetector>.GetOrCreateInstance;
				intervalMinutes = getOrCreateInstance.interval;
			}
			else
			{
				if (KeepAliveBehaviour<TimeCheatingDetector>.Instance != null)
				{
					TimeCheatingDetector timeCheatingDetector = KeepAliveBehaviour<TimeCheatingDetector>.Instance;
					return KeepAliveBehaviour<TimeCheatingDetector>.Instance.StartDetectionInternal(timeCheatingDetector.interval);
				}
				TimeCheatingDetector getOrCreateInstance2 = KeepAliveBehaviour<TimeCheatingDetector>.GetOrCreateInstance;
				intervalMinutes = getOrCreateInstance2.interval;
			}
			return StartDetection(intervalMinutes);
		}

		[Token(Token = "0x60003C7")]
		[Address(RVA = "0xBED48C", Offset = "0xBED48C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, intervalMinutes, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A3554A]) = v40;\nL_0016:\n\tv42 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::get_GetOrCreateInstance();\n\treturnVal1 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::StartDetectionInternal(v42, intervalMinutes, cheatCheckedEventHandler);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TimeCheatingDetector StartDetection(float intervalMinutes, TimeCheatingDetectorEventHandler cheatCheckedEventHandler = null)
		{
			TimeCheatingDetector getOrCreateInstance = KeepAliveBehaviour<TimeCheatingDetector>.GetOrCreateInstance;
			return getOrCreateInstance.StartDetectionInternal(intervalMinutes, cheatCheckedEventHandler);
		}

		[Token(Token = "0x60003C8")]
		[Address(RVA = "0xBED4F0", Offset = "0xBED4F0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3554B]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+208]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+210]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopDetection()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<TimeCheatingDetector>.Instance != null)
			{
				TimeCheatingDetector timeCheatingDetector = KeepAliveBehaviour<TimeCheatingDetector>.Instance;
				nint num = (nint)timeCheatingDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+208]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+210]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60003C9")]
		[Address(RVA = "0xBED5E8", Offset = "0xBED5E8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3554C]) = v35;\nL_001A:\n\tgoto L_0024;\n\tv44 = 0xB348B0(v37, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0024:\n\tgoto L_002C;\n\tv54 = 0xB348B0(v48, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002C:\n\tgoto L_0032;\n\tv62 = v56;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v62, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0032:\n\tv68 = UnityEngine.Object::op_Inequality(v57.<Instance>k__BackingField, 0);\n\tv70 = v68 == 0;\n\tif (v70) goto L_0056;\n\tgoto L_0044;\n\tv80 = 0xB348B0(v72, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0044:\n\tgoto L_0047;\n\tv106 = 0xB348B0(v83, v66, v67, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0047:\n\tv95 = v101.<Instance>k__BackingField;\n\tv100 = *([v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector)]);\n\tv91 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+1C8]);\n\tv93 = *([v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+1D0]);\n\t// 81 IndirectJump v91 @ X2_v2, v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v95 @ X0_v13 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v93 @ X1_v2, v91 @ X2_v2, v18 @ X3, v19 @ X4, v20 @ X5, v21 @ X6, v22 @ X7, v23 @ V0, v24 @ V1, v25 @ V2, v26 @ V3, v27 @ V4, v28 @ V5, v29 @ V6, v30 @ V7\nL_0056:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Dispose()
		{
			//IL_005b: Expected I, but got O
			//IL_006b: Expected O, but got I
			//IL_007b: Expected O, but got I
			if (KeepAliveBehaviour<TimeCheatingDetector>.Instance != null)
			{
				TimeCheatingDetector timeCheatingDetector = KeepAliveBehaviour<TimeCheatingDetector>.Instance;
				nint num = (nint)timeCheatingDetector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+1C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X8_v13 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+1D0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v91 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[IteratorStateMachine(typeof(_003CGetOnlineTimeCoroutine_003Ed__51))]
		[Token(Token = "0x60003CA")]
		[Address(RVA = "0xBED6DC", Offset = "0xBED6DC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__51;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, callback, method, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A3554D]) = v43;\nL_0018:\n\tv45 = new CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__51();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.url = url;\n\tv45.callback = callback;\n\tv45.method = method;\n\treturn v45;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerator GetOnlineTimeCoroutine(string url, OnlineTimeCallback callback, RequestMethod method = RequestMethod.Head)
		{
			_003CGetOnlineTimeCoroutine_003Ed__51 _003CGetOnlineTimeCoroutine_003Ed__53 = null;
			_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state = 0;
			_003CGetOnlineTimeCoroutine_003Ed__53.url = url;
			_003CGetOnlineTimeCoroutine_003Ed__53.callback = callback;
			_003CGetOnlineTimeCoroutine_003Ed__53.method = method;
			return _003CGetOnlineTimeCoroutine_003Ed__53;
		}

		[IteratorStateMachine(typeof(_003CGetOnlineTimeCoroutine_003Ed__52))]
		[Token(Token = "0x60003CB")]
		[Address(RVA = "0xBED778", Offset = "0xBED778", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__52;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, callback, method, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A3554E]) = v43;\nL_0018:\n\tv45 = new CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeCoroutine>d__52();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.uri = uri;\n\tv45.callback = callback;\n\tv45.method = method;\n\treturn v45;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IEnumerator GetOnlineTimeCoroutine(Uri uri, OnlineTimeCallback callback, RequestMethod method = RequestMethod.Head)
		{
			_003CGetOnlineTimeCoroutine_003Ed__52 _003CGetOnlineTimeCoroutine_003Ed__53 = null;
			_003CGetOnlineTimeCoroutine_003Ed__53._003C_003E1__state = 0;
			_003CGetOnlineTimeCoroutine_003Ed__53.uri = uri;
			_003CGetOnlineTimeCoroutine_003Ed__53.callback = callback;
			_003CGetOnlineTimeCoroutine_003Ed__53.method = method;
			return _003CGetOnlineTimeCoroutine_003Ed__53;
		}

		[AsyncStateMachine(typeof(_003CGetOnlineTimeTask_003Ed__53))]
		[Token(Token = "0x60003CC")]
		[Address(RVA = "0xBED818", Offset = "0xBED818", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv86 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A3554F]) = v43;\nL_0024:\n\tv49 = 0;\n\tgoto L_0032;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v44, method, methodInfo, v27, v28, v29, v30, v31, v45, v33, v34, v35, v36, v37, v38, v39);\nL_0032:\n\tv67 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::Create();\n\tv77 = &v49 @ stack_-70_v1 (System.Int32) | 8;\n\tv80 = 0xFFFFFFFF;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::Start(v77, &v80 @ stack_-70_v2 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeTask>d__53));\n\treturnVal1 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::get_Task(v77);\n\treturn returnVal1;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Task<OnlineTimeResult> GetOnlineTimeTask(string url, RequestMethod method = RequestMethod.Head)
		{
			//IL_002a: Expected O, but got I8
			int num = 0;
			AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder = AsyncTaskMethodBuilder<OnlineTimeResult>.Create();
			int num2 = (int)((nint)num | (nint)8);
			_003CGetOnlineTimeTask_003Ed__53 stateMachine = (_003CGetOnlineTimeTask_003Ed__53)4294967295L;
			((AsyncTaskMethodBuilder<OnlineTimeResult>*)num2)->Start(ref stateMachine);
			return ((AsyncTaskMethodBuilder<OnlineTimeResult>*)num2)->Task;
		}

		[AsyncStateMachine(typeof(_003CGetOnlineTimeTask_003Ed__54))]
		[Token(Token = "0x60003CD")]
		[Address(RVA = "0xBED914", Offset = "0xBED914", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv89 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, method, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A35550]) = v43;\nL_0026:\n\tv51 = 0;\n\tgoto L_0035;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v44, method, methodInfo, v27, v28, v29, v30, v31, v45, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tv70 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::Create();\n\tv80 = &v51 @ stack_-A0_v1 (System.Int32) | 8;\n\tv83 = 0xFFFFFFFF;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::Start(v80, &v83 @ stack_-A0_v2 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<GetOnlineTimeTask>d__54));\n\treturnVal1 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult>::get_Task(v80);\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static Task<OnlineTimeResult> GetOnlineTimeTask(Uri uri, RequestMethod method = RequestMethod.Head)
		{
			//IL_002a: Expected O, but got I8
			int num = 0;
			AsyncTaskMethodBuilder<OnlineTimeResult> asyncTaskMethodBuilder = AsyncTaskMethodBuilder<OnlineTimeResult>.Create();
			int num2 = (int)((nint)num | (nint)8);
			_003CGetOnlineTimeTask_003Ed__54 stateMachine = (_003CGetOnlineTimeTask_003Ed__54)4294967295L;
			((AsyncTaskMethodBuilder<OnlineTimeResult>*)num2)->Start(ref stateMachine);
			return ((AsyncTaskMethodBuilder<OnlineTimeResult>*)num2)->Task;
		}

		[Token(Token = "0x60003CE")]
		[Address(RVA = "0xBEDA14", Offset = "0xBEDA14", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv61 = UnityEngine.Object;\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv66 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv73 = UnityEngine.Networking.UnityWebRequest;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv80 = \"Accept-Encoding\";\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv84 = \"GET\";\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv111 = \"HEAD\";\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv120 = \"\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, method, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A35551]) = v49;\nL_0039:\n\tv59 = method != 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0041;\nL_0041:\n\tv305 = new UnityEngine.Networking.UnityWebRequest();\n\tUnityEngine.Networking.UnityWebRequest::.ctor(v305, uri, *([v68 @ X8_v3 (System.String)]));\n\tv82 = v305 == 0;\n\tif (v82) goto L_00D1;\n\tUnityEngine.Networking.UnityWebRequest::set_useHttpContinue(v305, 0);\n\tgoto L_005F;\n\tv121 = 0xB348B0(v114, v89, v90, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_005F:\n\tgoto L_0067;\n\tv142 = 0xB348B0(v125, v89, v90, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0067:\n\tgoto L_006C;\n\tv163 = v144;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v163, v89, v90, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_006C:\n\tv167 = UnityEngine.Object::op_Implicit(v96.<Instance>k__BackingField);\n\tv174 = v167 == 0;\n\tif (v174) goto L_FFFFFFFF;\n\tgoto L_007E;\n\tv234 = 0xB348B0(v179, v99, v90, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_007E:\n\tgoto L_0081;\n\tv252 = 0xB348B0(v237, v99, v90, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0081:\n\tv107 = v253.<Instance>k__BackingField;\n\tv103 = v253.<Instance>k__BackingField == 0;\n\tif (v103) goto L_00D1;\n\tv242 = v107.timeoutSeconds;\n\tgoto L_0089;\nL_0089:\n\tUnityEngine.Networking.UnityWebRequest::set_timeout(v305, v242);\n\tUnityEngine.Networking.UnityWebRequest::set_certificateHandler(v305, 0);\n\tv262 = method == 0;\n\tv263 = ~v262;\n\tif (v263) goto L_00D0;\n\tgoto L_009D;\n\tv303 = v269;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v303, v255, v256, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv307 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_009D:\n\tv310 = v308.sdkLevel == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_00AD;\n\tgoto L_00A6;\n\tv323 = v306;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v323, v255, v256, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00A6:\n\tv318 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::GetAndroidSDKLevel();\n\tv316.sdkLevel = v318;\nL_00AD:\n\tgoto L_00BC;\n\tv326 = v320;\n\tv327 = \"il2cpp_codegen_runtime_class_init\"(v326, v255, v256, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv329 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\nL_00BC:\n\tv273 = v330.sdkLevel >= 0x12;\n\tif (v273) goto L_00D0;\n\tUnityEngine.Networking.UnityWebRequest::SetRequestHeader(v305, \"Accept-Encoding\", \"\");\nL_00D0:\n\treturn v305;\nL_00D1:\n\tv109 = new System.NullReferenceException();\n\tgoto L_00DE;\n\tgoto L_00DE;\nL_00DE:\n\tv141 = v151 != 1;\n\tif (v141) goto L_0106;\n\tv148 = 0x1854E70(v109, v151, v149, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv175 = *([v148 @ X0_v11]);\n\tv177 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v175 @ X8_v6]), v149, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv185 = v177 & 1;\n\tv156 = v185 == 0;\n\tif (v156) goto L_00FC;\n\tv249 = 0x1854E80(v177, *([v175 @ X8_v6]), v149, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00F9;\n\tv299 = \"il2cpp_codegen_runtime_class_init\"(v259, v176, v97, v77, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00F9:\n\tUnityEngine.Debug::LogError(\"[ACTk] Time Cheating Detector: Couldn't get SDK version or set Accept-Encoding header.\");\n\tgoto L_00D0;\nL_00FC:\n\tv251 = 0x1854E90(8, *([v175 @ X8_v6]), v149, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v251 @ X0_v17]) = *([v148 @ X0_v11]);\n\tv151 = 0x185A000 + 0xF88;\n\tv261 = 0x1854EA0(v251, v151, 0, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv154 = 0x1854E80(v261, v151, 0, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0106:\n\tv162 = 0xBD3CD0(v157, v151, v149, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturnVal1 = 0x9DACB4(v162, v151, v149, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal1;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static UnityWebRequest GetWebRequest(Uri uri, RequestMethod method)
		{
			//IL_01e2: Expected O, but got I4
			string text = ((method != RequestMethod.Head) ? "GET" : "HEAD");
			UnityWebRequest unityWebRequest = new UnityWebRequest(uri, text);
			bool flag = unityWebRequest == null;
			string text2 = text;
			Uri uri2 = uri;
			if (!flag)
			{
				unityWebRequest.useHttpContinue = false;
				int timeout;
				if ((bool)KeepAliveBehaviour<TimeCheatingDetector>.Instance)
				{
					TimeCheatingDetector timeCheatingDetector = KeepAliveBehaviour<TimeCheatingDetector>.Instance;
					bool flag2 = (object)KeepAliveBehaviour<TimeCheatingDetector>.Instance == null;
					text2 = null;
					uri2 = null;
					if (flag2)
					{
						goto IL_0102;
					}
					timeout = timeCheatingDetector.timeoutSeconds;
				}
				else
				{
					timeout = 10;
				}
				unityWebRequest.timeout = timeout;
				unityWebRequest.certificateHandler = null;
				if (method == RequestMethod.Head)
				{
					if (sdkLevel == 0)
					{
						int androidSDKLevel = GetAndroidSDKLevel();
						sdkLevel = androidSDKLevel;
					}
					if (sdkLevel < 18)
					{
						unityWebRequest.SetRequestHeader("Accept-Encoding", "");
					}
				}
				goto IL_00fd;
			}
			goto IL_0102;
			IL_00fd:
			return unityWebRequest;
			IL_0102:
			NullReferenceException ex = new NullReferenceException();
			bool flag3 = (nint)uri2 != 1;
			NullReferenceException ex2 = ex;
			if (!flag3)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if ((int)((nint)obj3 & 1) != 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					Debug.LogError("[ACTk] Time Cheating Detector: Couldn't get SDK version or set Accept-Encoding header.");
					goto IL_00fd;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
				object obj4 = obj2;
				uri2 = (Uri)(25534464 + 3976);
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				text2 = null;
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			UnityWebRequest result = default(UnityWebRequest);
			return result;
		}

		[Token(Token = "0x60003CF")]
		[Address(RVA = "0xBEDDE0", Offset = "0xBEDDE0", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv18 = System.DateTime;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv45 = UnityEngine.Debug;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv52 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv57 = \"Date\";\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv93 = \"Couldn't parse 'Date' response header value\\n \";\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv105 = \"Couldn't find 'Date' response header value!\";\n\tv106 = \"il2cpp_codegen_initialize_runtime_metadata\"(v105, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv111 = \"[ACTk] Time Cheating Detector: Online Time Retrieve error:\\n\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, result, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A35552]) = v37;\nL_0026:\n\tv40 = 0;\n\tv49 = UnityEngine.Networking.UnityWebRequest::get_error(request);\n\tv55 = System.String::IsNullOrEmpty(v49);\n\tv60 = v55 == 0;\n\tif (v60) goto L_0048;\n\tv100 = UnityEngine.Networking.UnityWebRequest::GetResponseHeader(request, \"Date\");\n\tv109 = System.String::IsNullOrEmpty(v100);\n\tv113 = v109 == 0;\n\tif (v113) goto L_0050;\n\tv140 = UnityEngine.Networking.UnityWebRequest::get_responseCode(request);\n\tgoto L_007D;\nL_0048:\n\tv118 = UnityEngine.Networking.UnityWebRequest::get_error(request);\n\tgoto L_007B;\nL_0050:\n\tgoto L_0054;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v134, v107, v98, v21, v22, v23, v24, v25, v38, v27, v28, v29, v30, v31, v32, v33);\nL_0054:\n\tv162 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::TryGetDate(v100, &v40 @ stack_-28_v1 (System.DateTime));\n\tv121 = v162 == 0;\n\tif (v121) goto L_0077;\n\tgoto L_0062;\n\tv187 = \"il2cpp_codegen_runtime_class_init\"(v176, v160, v98, v21, v22, v23, v24, v25, v38, v27, v28, v29, v30, v31, v32, v33);\nL_0062:\n\tv191 = System.DateTime::ToUniversalTime(&v40 @ stack_-28_v1 (System.DateTime));\n\tv197 = System.DateTime::get_Ticks(&v191 @ X0_v33 (System.DateTime));\n\tv193 = v197 / 10000000d;\n\t*([result @ X1 (OnlineTimeResult&)]) = 1;\n\t*([result @ X1 (OnlineTimeResult&)+8]) = 0;\n\t*([result @ X1 (OnlineTimeResult&)+10]) = -1;\n\t*([result @ X1 (OnlineTimeResult&)+18]) = v193;\n\tgoto L_00A0;\nL_0077:\n\tv118 = System.String::Concat(\"Couldn't parse 'Date' response header value\\n \", v100);\nL_007B:\n\tv140 = UnityEngine.Networking.UnityWebRequest::get_responseCode(request);\nL_007D:\n\t*([result @ X1 (OnlineTimeResult&)]) = 0;\n\t*([result @ X1 (OnlineTimeResult&)+8]) = v144;\n\t*([result @ X1 (OnlineTimeResult&)+10]) = v140;\n\t*([result @ X1 (OnlineTimeResult&)+18]) = 0xBFF0000000000000;\n\tv147 = result->klass;\n\tv156 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult::ToString(&v147 @ V1_v2 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+OnlineTimeResult));\n\tv167 = System.String::Concat(\"[ACTk] Time Cheating Detector: Online Time Retrieve error:\\n\", v156);\n\tgoto L_009A;\n\tv182 = v169;\n\tv183 = \"il2cpp_codegen_runtime_class_init\"(v182, v164, v165, v21, v22, v23, v24, v25, v148, v147, v28, v29, v30, v31, v32, v33);\nL_009A:\n\tUnityEngine.Debug::Log(v167);\nL_00A0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void FillRequestResult(UnityWebRequest request, ref OnlineTimeResult result)
		{
			DateTime date = default(DateTime);
			string error = request.error;
			string text2;
			long responseCode;
			string text;
			ref OnlineTimeResult reference;
			if (string.IsNullOrEmpty(error))
			{
				string responseHeader = request.GetResponseHeader("Date");
				if (string.IsNullOrEmpty(responseHeader))
				{
					responseCode = request.responseCode;
					text = "Couldn't find 'Date' response header value!";
					goto IL_016d;
				}
				if (TryGetDate(responseHeader, out date))
				{
					long ticks = date.ToUniversalTime().Ticks;
					double num = (double)ticks / 10000000.0;
					reference = ref *(OnlineTimeResult*)1;
					_ = 0;
					_ = -1;
					return;
				}
				text2 = "Couldn't parse 'Date' response header value\n " + responseHeader;
			}
			else
			{
				text2 = request.error;
			}
			responseCode = request.responseCode;
			text = text2;
			goto IL_016d;
			IL_016d:
			reference = ref *(OnlineTimeResult*)null;
			_ = -4616189618054758400L;
			OnlineTimeResult onlineTimeResult = result;
			string text3 = onlineTimeResult.ToString();
			string message = "[ACTk] Time Cheating Detector: Online Time Retrieve error:\n" + text3;
			Debug.Log(message);
		}

		[Token(Token = "0x60003D0")]
		[Address(RVA = "0xBECF28", Offset = "0xBECF28", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Uri;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv56 = \"[ACTk] Time Cheating Detector: Could not create URI from URL: \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35553]) = v38;\nL_001E:\n\tgoto L_0024;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0024:\n\tv54 = System.Uri::TryCreate(url, 1, &v50 @ stack_-28_v2 (System.Uri));\n\tv58 = v54 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0042;\n\tv67 = System.String::Concat(\"[ACTk] Time Cheating Detector: Could not create URI from URL: \", url);\n\tgoto L_003B;\n\tv89 = v81;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v89, v63, v64, v53, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003B:\n\tUnityEngine.Debug::LogError(v67);\nL_0042:\n\treturn v50;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Uri UrlToUri(string url)
		{
			if (!Uri.TryCreate(url, UriKind.Absolute, out var result))
			{
				string message = "[ACTk] Time Cheating Detector: Could not create URI from URL: " + url;
				Debug.LogError(message);
			}
			return result;
		}

		[Token(Token = "0x60003D1")]
		[Address(RVA = "0xBEE014", Offset = "0xBEE014", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = System.String::ToCharArray(source, 5, 0x14);\n\tv150 = v15[5] + v15[4];\n\tv151 = v150 < 0xCF;\n\tv152 = ~v151;\n\tv153 = v150 - 0xCF;\n\tv155 = v153 == 0;\n\tv160 = ~v152;\n\tv161 = v160 | v155;\n\tif (v161) goto L_0060;\n\tv195 = v150 < 0xDA;\n\tv196 = ~v195;\n\tv197 = v150 - 0xDA;\n\tv199 = v197 == 0;\n\tv204 = ~v196;\n\tv205 = v204 | v199;\n\tif (v205) goto L_007A;\n\tv327 = v150 - 0xDC;\n\tv244 = v327 < 0xA;\n\tv245 = ~v244;\n\tif (v245) goto L_FFFFFFFF;\n\tv326 = 0x424000 + 0x144;\n\tgoto L_0087;\nL_0060:\n\tv210 = v150 == 0xC7;\n\tif (v210) goto L_FFFFFFFF;\n\tv267 = v150 == 0xC8;\n\tif (v267) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_007A:\n\tv327 = v150 - 0xD3;\n\tv254 = v327 < 8;\n\tv255 = ~v254;\n\tif (v255) goto L_FFFFFFFF;\n\tv326 = 0x424000 + 0xA4;\nL_0087:\n\tv191 = *([v326 @ X11_v21 (System.Int32)+v327 @ X10_v22 (System.Int32)*4]);\n\tgoto L_00F2;\nL_00F2:\n\tv534 = v15.Length == 0x13;\n\tif (v534) goto L_0146;\n\tv585 = v15[0] & 0xF;\n\tv586 = v15[1] & 0xF;\n\tv589 = v585 * 0xA;\n\tv590 = v586 + v589;\n\tv592 = v15[12] & 0xF;\n\tv593 = v15[13] & 0xF;\n\tv594 = v592 * 0xA;\n\tv595 = v593 + v594;\n\tv600 = v15[15] & 0xF;\n\tv601 = v15[16] & 0xF;\n\tv602 = v600 * 0xA;\n\tv603 = v601 + v602;\n\tv606 = v15[18] & 0xF;\n\tv607 = v15[19] & 0xF;\n\tv608 = v606 * 0xA;\n\tv609 = v607 + v608;\n\tv613 = v15[7] & 0xF;\n\tv614 = v613 * 0x3E8;\n\tv616 = v15[8] & 0xF;\n\tv617 = v616 * 0x64;\n\tv618 = v614 + v617;\n\tv620 = v15[9] & 0xF;\n\tv621 = v620 * 0xA;\n\tv622 = v618 + v621;\n\tv623 = v15[10] & 0xF;\n\tv624 = v622 + v623;\n\tSystem.DateTime::.ctor(&v628 @ stack_-28_v3 (System.DateTime), v624, v191, v590, v595, v603, v609, 1);\n\t*([date @ X1 (System.DateTime&)]) = v628;\nL_0132:\n\treturn returnVal2;\n\tgoto L_00F2;\n\tgoto L_00F2;\n\tv16 = new System.NullReferenceException();\n\tv40 = new System.NullReferenceException();\n\tv75 = new System.IndexOutOfRangeException();\n\tv92 = new System.IndexOutOfRangeException();\n\tv121 = new System.IndexOutOfRangeException();\n\tv147 = new System.IndexOutOfRangeException();\n\tv194 = new System.IndexOutOfRangeException();\n\tv241 = new System.IndexOutOfRangeException();\n\tv300 = new System.IndexOutOfRangeException();\n\tv374 = new System.IndexOutOfRangeException();\n\tv403 = new System.IndexOutOfRangeException();\n\tv432 = new System.IndexOutOfRangeException();\n\tv461 = new System.IndexOutOfRangeException();\n\tv490 = new System.IndexOutOfRangeException();\n\tv519 = new System.IndexOutOfRangeException();\nL_0146:\n\tv548 = new System.IndexOutOfRangeException();\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\n\tgoto L_0162;\nL_0162:\n\tv562 = v574 != 1;\n\tif (v562) goto L_019D;\n\tv565 = 0x1854E70(v548, v574, v572, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv637 = *([v565 @ X0_v9]);\n\tv639 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v637 @ X8_v4]), v572, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv690 = v639 & 1;\n\tv577 = v690 == 0;\n\tif (v577) goto L_0193;\n\tv641 = *([v565 @ X0_v9]);\n\tv724 = 0x1854E80(v639, *([v637 @ X8_v4]), v572, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv733 = *([v565 @ X0_v9]) == 0;\n\tif (v733) goto L_FFFFFFFF;\n\tv734 = *([v641 @ X21_v3]);\n\t*([v734 @ X8_v8+168])(v738, *([v565 @ X0_v9]), *([v734 @ X8_v8+170]), v572, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0182;\nL_0182:\n\tv745 = System.String::Concat(\"[ACTk] Time Cheating Detector: Error while parsing date: \", v743);\n\tgoto L_018E;\n\tv750 = \"il2cpp_codegen_runtime_class_init\"(v748, v743, v681, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_018E:\n\tUnityEngine.Debug::LogError(v745);\n\t*([date @ X1 (System.DateTime&)]) = 0;\n\tgoto L_0132;\nL_0193:\n\tv726 = 0x1854E90(8, *([v637 @ X8_v4]), v572, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\t*([v726 @ X0_v15]) = *([v565 @ X0_v9]);\n\tv574 = 0x185A000 + 0xF88;\n\tv731 = 0x1854EA0(v726, v574, 0, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv571 = 0x1854E80(v731, v574, 0, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_019D:\n\tv579 = 0xBD3CD0(v566, v574, 0, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturnVal1 = 0x9DACB4(v579, v574, 0, v544, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturn returnVal1;\n// 287 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool TryGetDate(string source, out DateTime date)
		{
			date = default(DateTime);
			char[] array = source.ToCharArray(5, 20);
			int num = array[5] + array[4];
			bool flag = num < 207;
			bool flag2 = !flag;
			int num2 = num - 207;
			bool flag3 = num2 == 0;
			bool flag4 = !flag2;
			int month;
			if (!(flag4 || flag3))
			{
				bool flag5 = num < 218;
				bool flag6 = !flag5;
				int num3 = num - 218;
				bool flag7 = num3 == 0;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					int num4 = num - 220;
					if (num4 >= 10)
					{
						goto IL_01d4;
					}
					int num5 = 4341760 + 324;
				}
				else
				{
					int num4 = num - 211;
					if (num4 >= 8)
					{
						goto IL_01d4;
					}
					int num5 = 4341760 + 164;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X11_v21 (System.Int32)+v327 @ X10_v22 (System.Int32)*4]");
				month = 0;
			}
			else if (num != 199)
			{
				if (num != 200)
				{
					goto IL_01d4;
				}
				month = 12;
			}
			else
			{
				month = 2;
			}
			goto IL_01e2;
			IL_01e2:
			if (array.Length != 19)
			{
				int num6 = array[0] & 0xF;
				int num7 = array[1] & 0xF;
				int num8 = num6 * 10;
				int day = num7 + num8;
				int num9 = array[12] & 0xF;
				int num10 = array[13] & 0xF;
				int num11 = num9 * 10;
				int hour = num10 + num11;
				int num12 = array[15] & 0xF;
				int num13 = array[16] & 0xF;
				int num14 = num12 * 10;
				int minute = num13 + num14;
				int num15 = array[18] & 0xF;
				int num16 = array[19] & 0xF;
				int num17 = num15 * 10;
				int second = num16 + num17;
				int num18 = array[7] & 0xF;
				int num19 = num18 * 1000;
				int num20 = array[8] & 0xF;
				int num21 = num20 * 100;
				int num22 = num19 + num21;
				int num23 = array[9] & 0xF;
				int num24 = num23 * 10;
				int num25 = num22 + num24;
				int num26 = array[10] & 0xF;
				int year = num25 + num26;
				DateTime dateTime = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Utc);
				ref DateTime reference = ref *(DateTime*)dateTime;
				return true;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			int num27 = default(int);
			bool flag9 = num27 != 1;
			IndexOutOfRangeException ex2 = ex;
			if (!flag9)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				object obj2 = default(object);
				object obj = obj2;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj3 = default(object);
				if ((int)((nint)obj3 & 1) != 0)
				{
					object obj4 = obj2;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					string text;
					if (obj2 != null)
					{
						object obj5 = obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v734 @ X8_v8+168] (should have been resolved before IL gen)");
						string text2 = default(string);
						text = text2;
					}
					else
					{
						text = null;
					}
					string message = "[ACTk] Time Cheating Detector: Error while parsing date: " + text;
					Debug.LogError(message);
					ref DateTime reference = ref *(DateTime*)null;
					return false;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
				object obj6 = obj2;
				num27 = 25534464 + 3976;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
				ex2 = ex3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			bool result = default(bool);
			return result;
			IL_01d4:
			month = 1;
			goto IL_01e2;
		}

		[Token(Token = "0x60003D2")]
		[Address(RVA = "0xBEE430", Offset = "0xBEE430", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv40 = \"[ACTk] Time Cheating Detector: Detector should be started to use ForceCheck().\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv53 = \"[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35554]) = v34;\nL_0019:\n\tv38 = ~this.started;\n\tif (v38) goto L_0035;\n\tv43 = ~this.isRunning;\n\tif (v43) goto L_0035;\n\tv55 = ~this.<IsCheckingForCheat>k__BackingField;\n\tif (v55) goto L_0044;\n\tgoto L_002B;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002B:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.\");\n\tgoto L_003D;\nL_0035:\n\tgoto L_0039;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0039:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: Detector should be started to use ForceCheck().\");\nL_003D:\n\tthis.<LastError>k__BackingField = v78;\nL_0042:\n\treturn returnVal1;\nL_0044:\n\tthis.timeElapsed = 0f;\n\tv65 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::CheckForCheat(this);\n\tv77 = UnityEngine.MonoBehaviour::StartCoroutine(this, v65);\n\tgoto L_0042;\n\treturn X0;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ForceCheck()
		{
			//IL_00d8: Expected I4, but got F8
			double num;
			if (IsStarted && IsRunning)
			{
				if (!IsCheckingForCheat)
				{
					timeElapsed = 0f;
					IEnumerator routine = CheckForCheat();
					Coroutine coroutine = StartCoroutine(routine);
					return true;
				}
				Debug.LogWarning("[ACTk] Time Cheating Detector: Can't force cheating check since another check is already in progress.");
				num = 2.12199579104E-312;
			}
			else
			{
				Debug.LogWarning("[ACTk] Time Cheating Detector: Detector should be started to use ForceCheck().");
				num = 2.121995791015E-312;
			}
			LastError = (ErrorKind)num;
			return false;
		}

		[IteratorStateMachine(typeof(_003CForceCheckEnumerator_003Ed__60))]
		[Token(Token = "0x60003D3")]
		[Address(RVA = "0xBEE528", Offset = "0xBEE528", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<ForceCheckEnumerator>d__60;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35555]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<ForceCheckEnumerator>d__60();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator ForceCheckEnumerator()
		{
			_003CForceCheckEnumerator_003Ed__60 _003CForceCheckEnumerator_003Ed__61 = null;
			_003CForceCheckEnumerator_003Ed__61._003C_003E1__state = 0;
			_003CForceCheckEnumerator_003Ed__61._003C_003E4__this = this;
			return _003CForceCheckEnumerator_003Ed__61;
		}

		[AsyncStateMachine(typeof(_003CForceCheckTask_003Ed__61))]
		[Token(Token = "0x60003D4")]
		[Address(RVA = "0xBEE5B0", Offset = "0xBEE5B0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv75 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector+CheckResult>;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35556]) = v40;\nL_0021:\n\tv45 = 0;\n\tgoto L_002F;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v23, v24, v25, v26, v27, v28, v42, v30, v31, v32, v33, v34, v35, v36);\nL_002F:\n\tv62 = &v45 @ stack_-60_v1 (System.Int32) | 8;\n\tv64 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::Create();\n\tv71 = 0xFFFFFFFF;\n\tSystem.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::Start(v62, &v71 @ stack_-60_v2 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<ForceCheckTask>d__61));\n\treturnVal1 = System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Int32Enum>::get_Task(v62);\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Task<CheckResult> ForceCheckTask()
		{
			//IL_002a: Expected O, but got I8
			int num = 0;
			int num2 = (int)((nint)num | (nint)8);
			object obj = AsyncTaskMethodBuilder<System.Int32Enum>.Create();
			_003CForceCheckTask_003Ed__61 stateMachine = (_003CForceCheckTask_003Ed__61)4294967295L;
			((AsyncTaskMethodBuilder<System.Int32Enum>*)num2)->Start(ref stateMachine);
			return (Task<CheckResult>)(object)((AsyncTaskMethodBuilder<System.Int32Enum>*)num2)->Task;
		}

		[Token(Token = "0x60003D5")]
		[Address(RVA = "0xBED368", Offset = "0xBED368", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, cheatCheckedEventHandler, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = \"[ACTk] Time Cheating Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!\";\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, cheatCheckedEventHandler, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = \"[ACTk] Time Cheating Detector: already running!\";\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, cheatCheckedEventHandler, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\n\tv66 = \"[ACTk] Time Cheating Detector: has properly configured Detection Event in the inspector, but still get started with TimeCheatingDetectorCallback callback. Both TimeCheatingDetectorCallback and Detection Event will be called on detection. Are you sure you wish to do this?\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, cheatCheckedEventHandler, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A35557]) = v40;\nL_0020:\n\tv44 = ~this.isRunning;\n\tif (v44) goto L_002E;\n\tgoto L_FFFFFFFF;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v48, cheatCheckedEventHandler, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0054;\nL_002E:\n\tv56 = UnityEngine.Behaviour::get_enabled(this);\n\tv64 = v56 == 0;\n\tif (v64) goto L_004D;\n\tv77 = cheatCheckedEventHandler == 0;\n\tif (v77) goto L_0044;\n\tv99 = ~this.detectionEventHasListener;\n\tif (v99) goto L_0044;\n\tgoto L_0042;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v109, v55, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\nL_0042:\n\tUnityEngine.Debug::LogWarning(\"[ACTk] Time Cheating Detector: has properly configured Detection Event in the inspector, but still get started with TimeCheatingDetectorCallback callback. Both TimeCheatingDetectorCallback and Detection Event will be called on detection. Are you sure you wish to do this?\", this);\nL_0044:\n\tthis.timeElapsed = 0f;\n\tthis.cheatChecked = cheatCheckedEventHandler;\n\tthis.interval = checkInterval;\n\tthis.started = 0x101;\n\tgoto L_005C;\nL_004D:\n\tgoto L_FFFFFFFF;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v78, v55, methodInfo, v25, v26, v27, v28, v29, checkInterval, v30, v31, v32, v33, v34, v35, v36);\nL_0054:\n\tUnityEngine.Debug::LogWarning(v68, this);\nL_005C:\n\treturn this;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private TimeCheatingDetector StartDetectionInternal(float checkInterval, TimeCheatingDetectorEventHandler cheatCheckedEventHandler = null)
		{
			string message;
			if (IsRunning)
			{
				message = "[ACTk] Time Cheating Detector: already running!";
			}
			else
			{
				if (base.enabled)
				{
					if (cheatCheckedEventHandler != null && detectionEventHasListener)
					{
						Debug.LogWarning("[ACTk] Time Cheating Detector: has properly configured Detection Event in the inspector, but still get started with TimeCheatingDetectorCallback callback. Both TimeCheatingDetectorCallback and Detection Event will be called on detection. Are you sure you wish to do this?", this);
					}
					timeElapsed = 0f;
					cheatChecked = cheatCheckedEventHandler;
					interval = checkInterval;
					started = true;
					goto IL_00ce;
				}
				message = "[ACTk] Time Cheating Detector: disabled but StartDetection still called from somewhere (see stack trace for this message)!";
			}
			Debug.LogWarning(message, this);
			goto IL_00ce;
			IL_00ce:
			return this;
		}

		[Token(Token = "0x60003D6")]
		[Address(RVA = "0xBEE694", Offset = "0xBEE694", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, instance, detectorName, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv51 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, instance, detectorName, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv62 = System.Uri;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, instance, detectorName, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35558]) = v44;\nL_0022:\n\tgoto L_0029;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, instance, detectorName, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0029:\n\tv60 = System.Uri::op_Equality(this.cachedUri, 0);\n\tv64 = v60 == 0;\n\tif (v64) goto L_0044;\n\tgoto L_0037;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v68, v58, v59, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0037:\n\tv73 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::UrlToUri(this.requestUrl);\n\tthis.cachedUri = v73;\nL_0044:\n\treturnVal1 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::Init(this, instance, detectorName);\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool Init(TimeCheatingDetector instance, string detectorName)
		{
			if (cachedUri == null)
			{
				Uri uri = UrlToUri(RequestUrl);
				cachedUri = uri;
			}
			return base.Init(instance, detectorName);
		}

		[Token(Token = "0x60003D7")]
		[Address(RVA = "0xBEE764", Offset = "0xBEE764", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector::StartDetectionInternal(this, this.interval, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StartDetectionAutomatically()
		{
			TimeCheatingDetector timeCheatingDetector = StartDetectionInternal(interval);
		}

		[Token(Token = "0x60003D8")]
		[Address(RVA = "0xBEE770", Offset = "0xBEE770", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35559]) = v37;\nL_0015:\n\tv40 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::DetectorHasCallbacks(this);\n\tv42 = v40 == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = this.CheatChecked == 0;\n\tif (v45) goto L_0024;\n\tgoto L_0030;\nL_0024:\n\tv54 = this.cheatChecked == 0;\n\tv59 = ~v54;\nL_0030:\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool DetectorHasCallbacks()
		{
			if (base.DetectorHasCallbacks() || this.CheatChecked != null)
			{
				return true;
			}
			bool flag = cheatChecked == null;
			return !flag;
		}

		[Token(Token = "0x60003D9")]
		[Address(RVA = "0xBEE7DC", Offset = "0xBEE7DC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3555A]) = v37;\nL_0015:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::PauseDetector(this);\n\tthis.updateAfterPause = 1;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void PauseDetector()
		{
			base.PauseDetector();
			updateAfterPause = true;
		}

		[Token(Token = "0x60003DA")]
		[Address(RVA = "0xBEE830", Offset = "0xBEE830", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3555B]) = v37;\nL_0015:\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::StopDetectionInternal(this);\n\tthis.cheatChecked = 0;\n\tthis.CheatChecked = 0;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void StopDetectionInternal()
		{
			base.StopDetectionInternal();
			cheatChecked = null;
			this.CheatChecked = null;
		}

		[IteratorStateMachine(typeof(_003CCheckForCheat_003Ed__68))]
		[Token(Token = "0x60003DB")]
		[Address(RVA = "0xBED0F0", Offset = "0xBED0F0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<CheckForCheat>d__68;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A3555C]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Detectors.TimeCheatingDetector+<CheckForCheat>d__68();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\tv39.<>4__this = this;\n\treturn v39;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CheckForCheat()
		{
			_003CCheckForCheat_003Ed__68 _003CCheckForCheat_003Ed__69 = null;
			_003CCheckForCheat_003Ed__69._003C_003E1__state = 0;
			_003CCheckForCheat_003Ed__69._003C_003E4__this = this;
			return _003CCheckForCheat_003Ed__69;
		}

		[Token(Token = "0x60003DC")]
		[Address(RVA = "0xBEE8AC", Offset = "0xBEE8AC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.cheatChecked;\n\tv7 = this.cheatChecked == 0;\n\tif (v7) goto L_000D;\n\tv43 = v4.method;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+TimeCheatingDetectorEventHandler::Invoke(this.cheatChecked, this.<LastResult>k__BackingField, this.<LastError>k__BackingField);\nL_000D:\n\t;\n\tv36 = this.CheatChecked == 0;\n\tif (v36) goto L_0022;\n\tCodeStage.AntiCheat.Detectors.TimeCheatingDetector+TimeCheatingDetectorEventHandler::Invoke(this.CheatChecked, this.<LastResult>k__BackingField, this.<LastError>k__BackingField);\nL_0022:\n\tv60 = this.<LastResult>k__BackingField <= 5;\n\tif (v60) goto L_004B;\n\tv65 = this.<LastResult>k__BackingField == 0xA;\n\tif (v65) goto L_005B;\n\tv75 = this.<LastResult>k__BackingField == 0x64;\n\tif (v75) goto L_005B;\n\tv111 = this.<LastResult>k__BackingField != 0xF;\n\tif (v111) goto L_005F;\n\tv146 = this->klass;\n\tv139 = this->klass->vtable[11];\n\tv136 = this->klass->vtable[11];\n\t// 74 IndirectJump v139 @ X2_v3, this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), this @ X0 (CodeStage.AntiCheat.Detectors.TimeCheatingDetector), v136 @ X1_v5, v139 @ X2_v3, v43 @ X3_v2 (System.IntPtr), v14 @ X4, v15 @ X5, v16 @ X6, v17 @ X7, v18 @ V0, v19 @ V1, v20 @ V2, v21 @ V3, v22 @ V4, v23 @ V5, v24 @ V6, v25 @ V7\nL_004B:\n\tv70 = this.<LastResult>k__BackingField == 0;\n\tif (v70) goto L_005B;\n\tv81 = this.<LastResult>k__BackingField != 5;\n\tif (v81) goto L_005F;\nL_005B:\n\treturn;\nL_005F:\n\tv150 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v150);\n\tthrow v150;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ReportCheckResult()
		{
			//IL_00d3: Expected I, but got O
			//IL_00e3: Expected O, but got I
			//IL_00f3: Expected O, but got I
			TimeCheatingDetectorEventHandler timeCheatingDetectorEventHandler = cheatChecked;
			if (cheatChecked != null)
			{
				IntPtr method = ((Delegate)timeCheatingDetectorEventHandler).method;
				cheatChecked(LastResult, LastError);
			}
			if (this.CheatChecked != null)
			{
				this.CheatChecked(LastResult, LastError);
			}
			if (LastResult > CheckResult.CheckPassed)
			{
				if (LastResult == CheckResult.WrongTimeDetected || LastResult == CheckResult.Error)
				{
					return;
				}
				if (LastResult != CheckResult.CheatDetected)
				{
					goto IL_013f;
				}
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v4 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+1E8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v4 (Il2CppClass<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>)+1F0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v139 @ X2_v3 (should have been resolved before IL gen)");
			}
			if (LastResult == CheckResult.Unknown || LastResult == CheckResult.CheckPassed)
			{
				return;
			}
			goto IL_013f;
			IL_013f:
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60003DD")]
		[Address(RVA = "0xBEE96C", Offset = "0xBEE96C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = result.success == 0;\n\tv4 = ~v3;\n\tif (v4) goto L_0009;\n\tthis.<LastError>k__BackingField = 5;\n\tgoto L_000A;\nL_0009:\n\tv9 = result.onlineSecondsUtc;\nL_000A:\n\tthis.lastOnlineSecondsUtc = v9;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnOnlineTimeReceived(OnlineTimeResult result)
		{
			double num;
			if (!result.success)
			{
				LastError = ErrorKind.OnlineTimeError;
				num = -1.0;
			}
			else
			{
				num = result.onlineSecondsUtc;
			}
			lastOnlineSecondsUtc = num;
		}

		[Token(Token = "0x60003DE")]
		[Address(RVA = "0xBEE990", Offset = "0xBEE990", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = System.DateTime;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A3555D]) = v34;\nL_0015:\n\tgoto L_0018;\n\tv39 = \"il2cpp_codegen_runtime_class_init\"(v35, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0018:\n\tv42 = System.DateTime::get_UtcNow();\n\tv46 = System.DateTime::get_Ticks(&v42 @ X0_v5 (System.DateTime));\n\treturnVal1 = v46 / 10000000d;\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private double GetLocalSecondsUtc()
		{
			long ticks = DateTime.UtcNow.Ticks;
			return (double)ticks / 10000000.0;
		}

		[Token(Token = "0x60003DF")]
		[Address(RVA = "0xBEDD0C", Offset = "0xBEDD0C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv10 = \"-\";\n\tv11 = \"il2cpp_codegen_initialize_runtime_metadata\"(v10, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26);\n\tv30 = 1;\n\t*([1A3555E]) = v30;\nL_0010:\n\tv33 = UnityEngine.SystemInfo::get_operatingSystem();\n\tv36 = System.String::IsNullOrEmpty(v33);\n\tv38 = v36 == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_FFFFFFFF;\n\tv91 = System.String::IndexOf(v33, \"-\", 4);\n\tv47 = v91 < 1;\n\tif (v47) goto L_FFFFFFFF;\n\tv42 = v91 + 3;\n\tv45 = v33._stringLength < v42;\n\tif (v45) goto L_FFFFFFFF;\n\tv161 = v91 + 1;\n\tv163 = System.String::Substring(v33, v161, 2);\n\tv90 = System.String::IsNullOrEmpty(v163);\n\tv93 = v90 == 0;\n\tif (v93) goto L_004E;\nL_004A:\n\treturn returnVal1;\nL_004E:\n\tv166 = System.Int32::TryParse(v163, &v107 @ stack_-14_v3 (System.Int32));\n\tv117 = v166 == 0;\n\tv110 = ~v117;\n\tv105 = ~v110;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_005C;\nL_005C:\n\tgoto L_004A;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetAndroidSDKLevel()
		{
			string operatingSystem = SystemInfo.operatingSystem;
			if (!string.IsNullOrEmpty(operatingSystem))
			{
				int num = operatingSystem.IndexOf("-", StringComparison.Ordinal);
				if (num >= 1)
				{
					int num2 = num + 3;
					if (operatingSystem.Length >= num2)
					{
						int startIndex = num + 1;
						string text = operatingSystem.Substring(startIndex, 2);
						if (!string.IsNullOrEmpty(text))
						{
							if (int.TryParse(text, out var result))
							{
								return result;
							}
							return -1;
						}
					}
				}
			}
			return -1;
		}

		[Obsolete("Please use GetOnlineTimeCoroutine or GetOnlineTimeTask instead", true)]
		[Token(Token = "0x60003E4")]
		[Address(RVA = "0xBEEC9C", Offset = "0xBEEC9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn -1d;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static double GetOnlineTime(string server)
		{
			return -1.0;
		}

		[Obsolete("Please use Instance.Error event instead.", true)]
		[Token(Token = "0x60003E5")]
		[Address(RVA = "0xBEECA4", Offset = "0xBEECA4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void SetErrorCallback(Action<ErrorKind> errorCallback)
		{
		}

		[Obsolete("Please use StartDetection(int, ...) instead.", true)]
		[Token(Token = "0x60003E6")]
		[Address(RVA = "0xBEECA8", Offset = "0xBEECA8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void StartDetection(Action detectionCallback, int interval)
		{
		}

		[Obsolete("Please use StartDetection(int, ...) instead.", true)]
		[Token(Token = "0x60003E7")]
		[Address(RVA = "0xBEECAC", Offset = "0xBEECAC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void StartDetection(Action detectionCallback, Action<ErrorKind> errorCallback, int interval)
		{
		}

		[Obsolete("Please use other overloads of this method instead", true)]
		[Token(Token = "0x60003E8")]
		[Address(RVA = "0xBEECB0", Offset = "0xBEECB0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void StartDetection(float interval, Action detectionCallback, Action<ErrorKind> errorCallback, Action checkPassedCallback)
		{
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0xBEECB4", Offset = "0xBEECB4", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = \"onlineOfflineSecondsDifference\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = \"TeslaOnMars\";\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv71 = \"google.com\";\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv93 = \"https://google.com\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35563]) = v42;\nL_0027:\n\tthis.timeoutSeconds = 0x40A000000000000A;\n\tthis.realCheatThreshold = 0x41;\n\tthis.requestUrl = \"https://google.com\";\n\tthis.ignoreSetCorrectTime = 1;\n\tv60 = System.String::ToCharArray(\"TeslaOnMars\");\n\tv69 = CodeStage.AntiCheat.ObscuredTypes.ObscuredString::Encrypt(\"onlineOfflineSecondsDifference\", v60);\n\tv74 = CodeStage.AntiCheat.Utils.Base64Utils::ToBase64(v69);\n\tthis.onlineOfflineDifferencePrefsKey = v74;\n\tthis.threshold = 0x41;\n\tthis.timeServer = \"google.com\";\n\tCodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<CodeStage.AntiCheat.Detectors.TimeCheatingDetector>::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TimeCheatingDetector()
		{
			//IL_0072: Expected I4, but got I8
			base._002Ector();
			timeoutSeconds = 10;
			realCheatThreshold = 65;
			wrongTimeThreshold = 0;
			requestUrl = "https://google.com";
			ignoreSetCorrectTime = true;
			char[] key = "TeslaOnMars".ToCharArray();
			char[] value = ObscuredString.Encrypt("onlineOfflineSecondsDifference", key);
			string text = Base64Utils.ToBase64(value);
			onlineOfflineDifferencePrefsKey = text;
			threshold = 65;
			timeServer = "google.com";
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0xBEEDBC", Offset = "0xBEEDBC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = CodeStage.AntiCheat.Detectors.TimeCheatingDetector;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = UnityEngine.WaitForEndOfFrame;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A35564]) = v39;\nL_0018:\n\tv41 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v41);\n\tv47.CachedEndOfFrame = v41;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static TimeCheatingDetector()
		{
			WaitForEndOfFrame cachedEndOfFrame = new WaitForEndOfFrame();
			CachedEndOfFrame = cachedEndOfFrame;
		}
	}
}
