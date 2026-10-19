using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TimeTaskSystem.Runtime
{
	[Token(Token = "0x2000009")]
	public class TimeTaskController
	{
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x10")]
		internal Timer[] _timers;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x18")]
		internal OnTimerUpdate[] _updateCallbacks;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x20")]
		private OnTimerComplete[] _completeCallbacks;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x28")]
		private readonly Queue<int> _freeHandles;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x30")]
		private int _nextHandle;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x38")]
		private readonly string _name;

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x819346C", Offset = "0x819346C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv44 = v38.Length;\n\tv46 = 0xB7D5000 + 0x538;\n\tv49 = \"il2cpp_vm_object_box\"(*([v46 @ X8_v6 (System.Int32)+48]), &v44 @ stack_-24_v1, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal2 = System.String::Format(\"{0} (size:{1})\", this._name, v49);\n\treturn returnVal2;\nL_0012:\n\tv38 = this._timers;\n")]
		public override string ToString()
		{
			//IL_000f: Expected O, but got I4
			Timer[] timers = _timers;
			object obj = timers.Length;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			return $"{_name} (size:{arg})";
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x81934F8", Offset = "0x81934F8", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tSystem.Object::.ctor(this);\n\tthis._name = name;\n\t// 70 NewArr v94 @ X0_v12 (Unco.TimeTaskSystem.Runtime.Timer[]), typeof(Unco.TimeTaskSystem.Runtime.Timer[]), initialBuffer @ X1 (System.Int32)\n\tthis._timers = v94;\n\t// 78 NewArr v101 @ X0_v17 (Unco.TimeTaskSystem.Runtime.OnTimerUpdate[]), typeof(Unco.TimeTaskSystem.Runtime.OnTimerUpdate[]), initialBuffer @ X1 (System.Int32)\n\tthis._updateCallbacks = v101;\n\t// 86 NewArr v108 @ X0_v22 (Unco.TimeTaskSystem.Runtime.OnTimerComplete[]), typeof(Unco.TimeTaskSystem.Runtime.OnTimerComplete[]), initialBuffer @ X1 (System.Int32)\n\tthis._completeCallbacks = v108;\n\treturn;\nL_0033:\n\tv68 = new System.Collections.Generic.Queue`1<System.Int32>();\n\tSystem.Collections.Generic.Queue`1<System.Int32>::.ctor(v68);\n\tthis._freeHandles = v68;\n")]
		public TimeTaskController(int initialBuffer, string name = "TimeTaskController")
		{
			Queue<int> freeHandles = new Queue<int>();
			_freeHandles = freeHandles;
			_name = name;
			Timer[] timers = new Timer[initialBuffer];
			_timers = timers;
			OnTimerUpdate[] updateCallbacks = new OnTimerUpdate[initialBuffer];
			_updateCallbacks = updateCallbacks;
			OnTimerComplete[] completeCallbacks = new OnTimerComplete[initialBuffer];
			_completeCallbacks = completeCallbacks;
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x8193644", Offset = "0x8193644", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tSystem.Array::Clear(this._timers, 0, *([v38 @ X0_v2 (System.Array)+18]));\n\tv53 = this._updateCallbacks;\n\tSystem.Array::Clear(this._updateCallbacks, 0, *([v53 @ X0_v5 (System.Array)+18]));\n\tv54 = this._completeCallbacks;\n\tSystem.Array::Clear(this._completeCallbacks, 0, *([v54 @ X0_v6 (System.Array)+18]));\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Clear(this._freeHandles);\n\tthis._nextHandle = 0;\n\treturn;\nL_0012:\n\tv38 = this._timers;\n")]
		public void Dispose()
		{
			Array timers = _timers;
			Timer[] timers2 = _timers;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (System.Array)+18]");
			Array.Clear(timers2, 0, 0);
			Array updateCallbacks = _updateCallbacks;
			OnTimerUpdate[] updateCallbacks2 = _updateCallbacks;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v5 (System.Array)+18]");
			Array.Clear(updateCallbacks2, 0, 0);
			Array completeCallbacks = _completeCallbacks;
			OnTimerComplete[] completeCallbacks2 = _completeCallbacks;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X0_v6 (System.Array)+18]");
			Array.Clear(completeCallbacks2, 0, 0);
			_freeHandles.Clear();
			_nextHandle = 0;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x81936E8", Offset = "0x81936E8", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tgoto L_0023;\n\tv65 = v60.Length << 0x20;\n\tv67 = v65 == 0;\n\tif (v67) goto L_01AB;\n\tv286 = v60.Length + 0xF;\n\tv287 = v286 & 0xFFFFFFFFFFFFFFF0;\n\t// 46 StackAlloc v457 @ X21_v12 (System.Byte*), v287 @ X9_v40 (System.Int32)\n\tv292 = System.Collections.Generic.Queue`1<System.Int32>::Enqueue(v457, v60.Length);\n\tv368 = v60.Length & 0x80000000;\n\tv369 = v368 == 0;\nL_FFFFFFFF:\n\tv238 = v457;\n\tif (v369) goto L_0038;\nL_0037:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_FFFFFFFF:\n\tv238 = v457;\nL_0038:\n\tv469 = v65 == 0;\nL_FFFFFFFF:\n\tv275 = v65;\n\tif (v469) goto L_0041;\n\tv471 = v60.Length + 0xF;\n\tv472 = v471 & 0xFFFFFFFFFFFFFFF0;\n\t// 61 StackAlloc v473 @ X20_v9 (System.Byte*), v472 @ X9_v37 (System.Int32)\nL_FFFFFFFF:\n\tv275 = v473;\n\tv546 = v60.Length == 0;\n\tif (v546) goto L_018C;\n\tv252 = v60.Length & 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv102 = deltaTime;\nL_FFFFFFFF:\n\tv214 = v275;\nL_FFFFFFFF:\n\tv241 = 0x20;\nL_FFFFFFFF:\n\tv277 = 0;\n\tgoto L_005E;\nL_004F:\n\tv659 = *([v207 @ X14_v7+10]) & 0xEC;\n\t*([v207 @ X14_v7+10]) = v659;\nL_FFFFFFFF:\n\tv708 = v621;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv98 = v625;\nL_005E:\n\tv210 = this._timers;\n\tv207 = this._timers + v241;\n\tv604 = *([v207 @ X14_v7+10]) & 3;\n\tv614 = v604 != 1;\n\tif (v614) goto L_0051;\n\tv102 = *([v210 @ X13_v6 (Unco.TimeTaskSystem.Runtime.Timer[])+v241 @ X9_v14 (System.Int32)]) + deltaTime;\n\t*([v210 @ X13_v6 (Unco.TimeTaskSystem.Runtime.Timer[])+v241 @ X9_v14 (System.Int32)]) = v102;\n\tv617 = *([v207 @ X14_v7+10]) & 4;\n\tv618 = v617 == 0;\n\tv619 = ~v618;\n\tif (v619) goto L_0091;\n\t*([v238 @ X21_v5 (System.Byte*)+v277 @ X8_v16 (System.Int32)]) = 1;\n\tv663 = this._timers + v241;\n\tv98 = *([v663 @ X16_v12+4]);\n\tv649 = v102 < *([v663 @ X16_v12+4]);\n\tv665 = v102 == v102;\n\tv641 = *([v663 @ X16_v12+4]) == *([v663 @ X16_v12+4]);\n\tv653 = v665 & v641;\n\tv637 = ~v653;\n\tv666 = v649 == v637;\n\tv630 = ~v666;\n\tif (v630) goto L_0051;\nL_FFFFFFFF:\n\tv712 = v214;\n\tgoto L_00B5;\nL_0091:\n\tv634 = this._timers + v241;\n\tv708 = v102 - *([v634 @ X16_v10+C]);\n\tv668 = v708 < *([v634 @ X16_v10+8]);\n\tv672 = v708 == v708;\n\tv673 = *([v634 @ X16_v10+8]) == *([v634 @ X16_v10+8]);\n\tv674 = v672 & v673;\n\tv675 = ~v674;\n\tv676 = v668 == v675;\n\tv677 = ~v676;\n\tif (v677) goto L_00A3;\n\tv680 = *([v634 @ X16_v10+C]) + *([v634 @ X16_v10+8]);\n\t*([v634 @ X16_v10+C]) = v680;\n\t*([v238 @ X21_v5 (System.Byte*)+v277 @ X8_v16 (System.Int32)]) = 1;\n\tv214.m_value = 1;\n\tv712 = v238 + v277;\n\tv722 = v712.m_value == 0;\n\tv721 = ~v722;\nL_FFFFFFFF:\n\tv621 = v708;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv625 = *([v634 @ X16_v10+4]);\n\tif (v721) goto L_00B6;\nL_00B5:\n\tv712.m_value = 1;\nL_FFFFFFFF:\n\tv621 = v708;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv625 = v98;\n\tv748 = v102 - v625;\n\tv660 = this._timers + v241;\n\t*([v660 @ X13_v8]) = v748;\n\tv102 = *([v660 @ X13_v8+C]) - v625;\n\t*([v660 @ X13_v8+C]) = v102;\nL_FFFFFFFF:\n\tv708 = v621;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv98 = v625;\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv83 = 0;\nL_FFFFFFFF:\n\tv254 = 0;\n\tgoto L_00D0;\nL_00C3:\n\tv83 = v83 + 1;\n\tv254 = v254 + 0x18;\n\tv691 = v252 == v83;\n\tif (v691) goto L_FFFFFFFF;\nL_00D0:\n\tv705 = *([v238 @ X21_v5 (System.Byte*)+v83 @ X24_v8 (System.Int32)]) == 0;\n\tif (v705) goto L_00C3;\n\tv243 = this._updateCallbacks;\n\tv736 = v243[v83 @ X24_v8 (System.Int32)];\n\tv738 = v243[v83 @ X24_v8 (System.Int32)] == 0;\n\tif (v738) goto L_00C3;\n\tv734 = this._timers + v254;\n\tv102 = *([v734 @ X10_v8+20]);\n\tv772 = this._timers + v254;\n\tv98 = *([v772 @ X8_v21+24]);\n\tUnco.TimeTaskSystem.Runtime.OnTimerUpdate::Invoke(v243[v83 @ X24_v8 (System.Int32)], v736.method, v553);\n\tgoto L_00C3;\nL_FFFFFFFF:\n\tv239 = 0;\nL_FFFFFFFF:\n\tv255 = 0;\n\tgoto L_0110;\nL_0102:\n\tv239 = v239 + 1;\n\tv255 = v255 + 0x18;\n\tv568 = v252 == v239;\n\tif (v568) goto L_018C;\nL_0110:\n\tv753 = *([v275 @ X20_v6 (System.IntPtr)+v239 @ X21_v10 (System.Int32)]) == 0;\n\tif (v753) goto L_0102;\n\tv366 = this._timers;\n\tv245 = this._completeCallbacks;\n\tv224 = this._timers + v255;\n\tv776 = v245[v239 @ X21_v10 (System.Int32)] == 0;\n\tif (v776) goto L_0147;\n\tUnco.TimeTaskSystem.Runtime.OnTimerComplete::Invoke(v245[v239 @ X21_v10 (System.Int32)]);\n\tv366 = this._timers;\nL_0147:\n\tv768 = v366 + v255;\n\tv107 = *([v768 @ X8_v28+34]) != *([v224 @ X10_v12+34]);\n\tif (v107) goto L_0102;\n\tv781 = *([v768 @ X8_v28+30]) & 1;\n\tv782 = v781 == 0;\n\tv767 = ~v782;\n\tif (v767) goto L_0102;\n\tv247 = *([v224 @ X10_v12+34]) + 1;\n\t*([v768 @ X8_v28+34]) = v247;\n\tv281 = this._updateCallbacks;\n\tv281[v239 @ X21_v10 (System.Int32)] = 0;\n\tv282 = this._completeCallbacks;\n\tv282[v239 @ X21_v10 (System.Int32)] = 0;\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(this._freeHandles, v239);\n\tgoto L_0102;\nL_018C:\n\tv586 = *([A4731E0]);\n\tv393 = *([v586 @ X9_v11]) != *([v31 @ X8_v2]);\n\tif (v393) goto L_01D2;\n\treturn;\nL_01AB:\n\tv296 = System.Collections.Generic.Queue`1<System.Int32>::Enqueue(0, v60.Length);\n\tv370 = v60.Length & 0x80000000;\n\tv371 = v370 == 0;\nL_FFFFFFFF:\n\tv238 = 0;\n\tif (v371) goto L_0038;\nL_FFFFFFFF:\n\tv457 = 0;\n\tgoto L_0037;\nL_01B2:\n\tv548 = *([A4731E0]);\n\tv394 = *([v548 @ X9_v7]) != *([v31 @ X8_v2]);\n\tif (v394) goto L_01D2;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\treturn;\nL_01D2:\n\tv454 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0023:\n\tv60 = this._timers;\nL_0041:\n\tv257 = 0x8BF5F18(v275, v60.Length, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv544 = v60.Length & 0x80000000;\n\tv545 = v544 == 0;\n\tv449 = ~v545;\n\tif (v449) goto L_01B2;\nL_0051:\n\tv277 = v277 + 1;\n\tv214 = v214 + 1;\n\tv241 = v241 + 0x18;\n\tv594 = v252 == v277;\n\tif (v594) goto L_FFFFFFFF;\nL_00A3:\n\tv98 = *([v634 @ X16_v10+4]);\n\tv650 = v102 < *([v634 @ X16_v10+4]);\n\tv683 = v102 == v102;\n\tv642 = *([v634 @ X16_v10+4]) == *([v634 @ X16_v10+4]);\n\tv654 = v683 & v642;\n\tv638 = ~v654;\n\tv684 = v650 == v638;\n\tv631 = ~v684;\n\tif (v631) goto L_0051;\nL_00B6:\n\tv742 = *([v207 @ X14_v7+10]) & 0x10;\n\tv661 = v742 == 0;\n\tif (v661) goto L_004F;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Tick(float deltaTime)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::Tick");
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x8193AD8", Offset = "0x8193AD8", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = handle & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_001E;\n\tv4 = this._timers;\n\tv8 = v4.Length <= handle;\n\tif (v8) goto L_001E;\n\tv88 = v4[handle @ X1 (System.Int32)].Flags & 1;\n\tv89 = v88 == 0;\n\tv42 = ~v89;\n\tif (v42) goto L_001F;\nL_001E:\n\treturn 0;\nL_001F:\n\tv90 = v4[handle @ X1 (System.Int32)].Flags >> 3;\n\treturnVal3 = v90 & 1;\n\treturn returnVal3;\n")]
		internal bool CountsDown(int handle)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle && (timers[handle].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int num = (int)timers[handle].Flags >> 3;
					return (byte)(num & 1) != 0;
				}
			}
			return false;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x8193B1C", Offset = "0x8193B1C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = handle & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_001E;\n\tv4 = this._timers;\n\tv8 = v4.Length <= handle;\n\tif (v8) goto L_001E;\n\tv88 = v4[handle @ X1 (System.Int32)].Flags & 1;\n\tv89 = v88 == 0;\n\tv42 = ~v89;\n\tif (v42) goto L_001F;\nL_001E:\n\treturn 0;\nL_001F:\n\tv90 = v4[handle @ X1 (System.Int32)].Flags >> 2;\n\treturnVal3 = v90 & 1;\n\treturn returnVal3;\n")]
		internal bool UsesInterval(int handle)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle && (timers[handle].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int num = (int)timers[handle].Flags >> 2;
					return (byte)(num & 1) != 0;
				}
			}
			return false;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x8193B60", Offset = "0x8193B60", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = handleId & 0x80000000;\n\tv3 = v1 == 0;\n\tv4 = ~v3;\n\treturnVal1 = 0;\n\tif (v4) goto L_0023;\n\tv5 = this._timers;\n\tv12 = v5.Length <= handleId;\n\treturnVal1 = 0;\n\tif (v12) goto L_0023;\n\tv46 = v5 + 0x20;\n\tv95 = handleId * 0x18;\n\tv96 = v46 + v95;\n\tv97 = *([v96 @ X9_v4+10]) & 1;\n\tv49 = v97 == 0;\n\treturnVal1 = 0;\n\tif (v49) goto L_0023;\n\tv48 = handleId * 0x18;\n\tv44 = v46 + v48;\n\treturnVal1 = *([v44 @ X8_v4+8]);\nL_0023:\n\treturn returnVal1;\n")]
		internal float GetUpdateInterval(int handleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::GetUpdateInterval");
			return default;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x8193BB0", Offset = "0x8193BB0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = handleId & 0x80000000;\n\tv3 = v1 == 0;\n\tv4 = ~v3;\n\treturnVal1 = 0;\n\tif (v4) goto L_0023;\n\tv5 = this._timers;\n\tv12 = v5.Length <= handleId;\n\treturnVal1 = 0;\n\tif (v12) goto L_0023;\n\tv46 = v5 + 0x20;\n\tv95 = handleId * 0x18;\n\tv96 = v46 + v95;\n\tv97 = *([v96 @ X9_v4+10]) & 1;\n\tv49 = v97 == 0;\n\treturnVal1 = 0;\n\tif (v49) goto L_0023;\n\tv48 = handleId * 0x18;\n\tv44 = v46 + v48;\n\treturnVal1 = *([v44 @ X8_v4+4]);\nL_0023:\n\treturn returnVal1;\n")]
		internal float GetDuration(int handleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::GetDuration");
			return default;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x8193C00", Offset = "0x8193C00", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = handleId & 0x80000000;\n\tv3 = v1 == 0;\n\tv4 = ~v3;\n\treturnVal1 = 0;\n\tif (v4) goto L_0022;\n\tv5 = this._timers;\n\tv12 = v5.Length <= handleId;\n\treturnVal1 = 0;\n\tif (v12) goto L_0022;\n\tv44 = v5 + 0x20;\n\tv93 = handleId * 0x18;\n\tv94 = v44 + v93;\n\tv95 = *([v94 @ X9_v4+10]) & 1;\n\tv47 = v95 == 0;\n\treturnVal1 = 0;\n\tif (v47) goto L_0022;\n\tv39 = handleId * 0x18;\n\treturnVal1 = *([v44 @ X8_v3+v39 @ X9_v7 (System.Int32)]);\nL_0022:\n\treturn returnVal1;\n")]
		public float GetElapsedTime(int handleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::GetElapsedTime");
			return default;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x8193C50", Offset = "0x8193C50", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv50 = this._timers;\n\tv58 = v50.Length <= handleId;\n\tif (v58) goto L_0063;\n\tv99 = v50 + 0x20;\n\tv152 = handleId * 0x18;\n\tv153 = v99 + v152;\n\tv154 = *([v153 @ X9_v4+10]) & 1;\n\tv96 = v154 == 0;\n\tif (v96) goto L_0063;\n\tv97 = handleId * 0x18;\n\tv100 = v99 + v97;\n\tv76 = *([v100 @ X8_v6+4]) == 0;\n\tv155 = *([v100 @ X8_v6+4]) < 0;\n\tv88 = ~v155;\n\tv156 = ~v88;\n\tv59 = v156 | v76;\n\tif (v59) goto L_0063;\n\tgoto L_004B;\nL_004B:\n\tv121 = *([v100 @ X8_v6+4]) - *([v100 @ X8_v6]);\n\treturnVal3 = System.Math::Max(0f, v121);\n\treturn returnVal3;\nL_0063:\n\treturn 0;\nL_0017:\n\tv47 = handleId & 0x80000000;\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0063;\n")]
		public float GetRemainingTime(int handleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::GetRemainingTime");
			return default;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x8193D28", Offset = "0x8193D28", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv51 = this._timers;\n\tv61 = v51.Length <= handleId;\n\treturnVal1 = 0;\n\tif (v61) goto L_0064;\n\tv102 = v51 + 0x20;\n\tv154 = handleId * 0x18;\n\tv155 = v102 + v154;\n\tv156 = *([v155 @ X9_v4+10]) & 1;\n\tv99 = v156 == 0;\n\treturnVal1 = 0;\n\tif (v99) goto L_0064;\n\tv100 = handleId * 0x18;\n\tv103 = v102 + v100;\n\tv79 = *([v103 @ X8_v6+4]) == 0;\n\tv157 = *([v103 @ X8_v6+4]) < 0;\n\tv91 = ~v157;\n\tv158 = ~v91;\n\tv62 = v158 | v79;\n\treturnVal1 = 1f;\n\tif (v62) goto L_0064;\n\tgoto L_004D;\nL_004D:\n\tv121 = *([v103 @ X8_v6]) / *([v103 @ X8_v6+4]);\n\treturnVal3 = System.Math::Min(1f, v121);\n\treturn returnVal3;\nL_0064:\n\treturn returnVal1;\nL_0018:\n\tv48 = handleId & 0x80000000;\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\treturnVal1 = 0;\n\tif (v50) goto L_0064;\n")]
		public float GetTimerProgress(int handleId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::GetTimerProgress");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001E")]
		[Address(RVA = "0x8193E04", Offset = "0x8193E04", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = handle & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_001C;\n\tv4 = this._timers;\n\tv9 = v4.Length <= handle;\n\tif (v9) goto L_001C;\n\treturnVal2 = v4[handle @ X1 (System.Int32)].Flags & 1;\n\treturn returnVal2;\nL_001C:\n\treturn 0;\n")]
		internal bool IsHandleValid(int handle)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle)
				{
					return (byte)(timers[handle].Flags & TimerFlags.Active) != 0;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001F")]
		[Address(RVA = "0x8193E44", Offset = "0x8193E44", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = handle & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_001F;\n\tv4 = this._timers;\n\tv8 = v4.Length <= handle;\n\tif (v8) goto L_001F;\n\tv39 = v4 + 0x20;\n\tv101 = handle * 0x18;\n\tv102 = v39 + v101;\n\tv103 = *([v102 @ X9_v4+10]) & 1;\n\tv104 = v103 == 0;\n\tv42 = ~v104;\n\tif (v42) goto L_0022;\nL_001F:\n\treturn 0;\nL_0022:\n\tv99 = handle * 0x18;\n\tv105 = v39 + v99;\n\tv91 = *([v105 @ X8_v4+14]) - generation;\n\tv87 = v91 == 0;\n\treturn v87;\n")]
		internal bool IsHandleValid(int handle, int generation)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::IsHandleValid");
			return default;
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x8193EA0", Offset = "0x8193EA0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = handle & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_001F;\n\tv4 = this._timers;\n\tv8 = v4.Length <= handle;\n\tif (v8) goto L_001F;\n\tv88 = v4[handle @ X1 (System.Int32)].Flags & 1;\n\tv43 = v88 == 0;\n\tif (v43) goto L_001F;\n\tv35 = v4[handle @ X1 (System.Int32)].Flags | 2;\n\tv4[handle @ X1 (System.Int32)].Flags = v35;\nL_001F:\n\treturn;\n")]
		public void PauseTimer(int handle)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle && (timers[handle].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int flags = (int)(timers[handle].Flags | TimerFlags.Paused);
					timers[handle].Flags = (TimerFlags)flags;
				}
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x8193EE0", Offset = "0x8193EE0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = handle & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_001F;\n\tv4 = this._timers;\n\tv8 = v4.Length <= handle;\n\tif (v8) goto L_001F;\n\tv88 = v4[handle @ X1 (System.Int32)].Flags & 1;\n\tv43 = v88 == 0;\n\tif (v43) goto L_001F;\n\tv35 = v4[handle @ X1 (System.Int32)].Flags & -3;\n\tv4[handle @ X1 (System.Int32)].Flags = v35;\nL_001F:\n\treturn;\n")]
		public void ResumeTimer(int handle)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle && (timers[handle].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int flags = (int)timers[handle].Flags & -3;
					timers[handle].Flags = (TimerFlags)flags;
				}
			}
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x8193F20", Offset = "0x8193F20", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv46 = this._timers;\n\tv49 = v46.Length <= handle;\n\tif (v49) goto L_003A;\n\tv205 = v46[handle @ X1 (System.Int32)].Flags & 1;\n\tv206 = v205 == 0;\n\tv80 = ~v206;\n\tif (v80) goto L_003B;\nL_003A:\n\treturn;\nL_003B:\n\tv136 = v46[handle @ X1 (System.Int32)].Flags & 0xFE;\n\tv46[handle @ X1 (System.Int32)].Flags = v136;\n\tv149 = this._timers;\n\tv137 = v149[handle @ X1 (System.Int32)].Generation + 1;\n\tv149[handle @ X1 (System.Int32)].Generation = v137;\n\tv150 = this._updateCallbacks;\n\tv150[handle @ X1 (System.Int32)] = 0;\n\tv151 = this._completeCallbacks;\n\tv151[handle @ X1 (System.Int32)] = 0;\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(this._freeHandles, handle);\n\treturn;\nL_0015:\n\tv43 = handle & 0x80000000;\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_003A;\n")]
		public void StopTimer(int handle)
		{
			//IL_014e: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle && (timers[handle].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int flags = (int)(timers[handle].Flags & ~TimerFlags.Active);
					timers[handle].Flags = (TimerFlags)flags;
					Timer[] timers2 = _timers;
					int generation = timers2[handle].Generation + 1;
					timers2[handle].Generation = generation;
					OnTimerUpdate[] updateCallbacks = _updateCallbacks;
					updateCallbacks[handle] = null;
					OnTimerComplete[] completeCallbacks = _completeCallbacks;
					completeCallbacks[handle] = null;
					_freeHandles.Enqueue(handle);
				}
			}
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x819403C", Offset = "0x819403C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv47 = this._timers;\n\tv50 = v47.Length <= handle;\n\tif (v50) goto L_007D;\n\tv81 = onUpdate == 0;\n\tif (v81) goto L_007D;\n\tv223 = v47[handle @ X1 (System.Int32)].Flags & 1;\n\tv82 = v223 == 0;\n\tif (v82) goto L_007D;\n\tv107 = this._updateCallbacks;\n\tv214 = System.Delegate::Combine(v107[handle @ X1 (System.Int32)], onUpdate);\n\tv168 = v214 == 0;\n\tif (v168) goto L_007E;\n\tv194 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerUpdate;\n\tif (v194) goto L_008C;\n\tv107[handle @ X1 (System.Int32)] = v214;\n\tv124 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerUpdate;\n\tif (v124) goto L_008C;\n\treturn;\nL_007D:\n\treturn;\nL_007E:\n\tv107[handle @ X1 (System.Int32)] = 0;\n\treturn;\nL_008C:\n\tv220 = new System.InvalidCastException();\n\tthrow System.IndexOutOfRangeException;\nL_0016:\n\tv44 = handle & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_007D;\n")]
		public void SubscribeToTimerUpdate(int handle, OnTimerUpdate onUpdate)
		{
			//IL_0165: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) != 0)
			{
				return;
			}
			Timer[] timers = _timers;
			if (timers.Length <= handle || onUpdate == null || (timers[handle].Flags & TimerFlags.Active) == 0)
			{
				return;
			}
			OnTimerUpdate[] updateCallbacks = _updateCallbacks;
			Delegate obj = Delegate.Combine(updateCallbacks[handle], onUpdate);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(OnTimerUpdate))
				{
					updateCallbacks[handle] = (OnTimerUpdate)obj;
					if ((object)obj.GetType() == typeof(OnTimerUpdate))
					{
						return;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				throw new IndexOutOfRangeException();
			}
			updateCallbacks[handle] = null;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x8194154", Offset = "0x8194154", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv47 = this._timers;\n\tv50 = v47.Length <= handle;\n\tif (v50) goto L_007D;\n\tv81 = onComplete == 0;\n\tif (v81) goto L_007D;\n\tv223 = v47[handle @ X1 (System.Int32)].Flags & 1;\n\tv82 = v223 == 0;\n\tif (v82) goto L_007D;\n\tv107 = this._completeCallbacks;\n\tv214 = System.Delegate::Combine(v107[handle @ X1 (System.Int32)], onComplete);\n\tv168 = v214 == 0;\n\tif (v168) goto L_007E;\n\tv194 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerComplete;\n\tif (v194) goto L_008C;\n\tv107[handle @ X1 (System.Int32)] = v214;\n\tv124 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerComplete;\n\tif (v124) goto L_008C;\n\treturn;\nL_007D:\n\treturn;\nL_007E:\n\tv107[handle @ X1 (System.Int32)] = 0;\n\treturn;\nL_008C:\n\tv220 = new System.InvalidCastException();\n\tthrow System.IndexOutOfRangeException;\nL_0016:\n\tv44 = handle & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_007D;\n")]
		public void SubscribeToTimerComplete(int handle, OnTimerComplete onComplete)
		{
			//IL_0165: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) != 0)
			{
				return;
			}
			Timer[] timers = _timers;
			if (timers.Length <= handle || onComplete == null || (timers[handle].Flags & TimerFlags.Active) == 0)
			{
				return;
			}
			OnTimerComplete[] completeCallbacks = _completeCallbacks;
			Delegate obj = Delegate.Combine(completeCallbacks[handle], onComplete);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(OnTimerComplete))
				{
					completeCallbacks[handle] = (OnTimerComplete)obj;
					if ((object)obj.GetType() == typeof(OnTimerComplete))
					{
						return;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				throw new IndexOutOfRangeException();
			}
			completeCallbacks[handle] = null;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x819426C", Offset = "0x819426C", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv47 = this._timers;\n\tv50 = v47.Length <= handle;\n\tif (v50) goto L_007D;\n\tv81 = onUpdate == 0;\n\tif (v81) goto L_007D;\n\tv223 = v47[handle @ X1 (System.Int32)].Flags & 1;\n\tv82 = v223 == 0;\n\tif (v82) goto L_007D;\n\tv107 = this._updateCallbacks;\n\tv214 = System.Delegate::Remove(v107[handle @ X1 (System.Int32)], onUpdate);\n\tv168 = v214 == 0;\n\tif (v168) goto L_007E;\n\tv194 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerUpdate;\n\tif (v194) goto L_008C;\n\tv107[handle @ X1 (System.Int32)] = v214;\n\tv124 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerUpdate;\n\tif (v124) goto L_008C;\n\treturn;\nL_007D:\n\treturn;\nL_007E:\n\tv107[handle @ X1 (System.Int32)] = 0;\n\treturn;\nL_008C:\n\tv220 = new System.InvalidCastException();\n\tthrow System.IndexOutOfRangeException;\nL_0016:\n\tv44 = handle & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_007D;\n")]
		public void UnsubscribeFromTimerUpdate(int handle, OnTimerUpdate onUpdate)
		{
			//IL_0165: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) != 0)
			{
				return;
			}
			Timer[] timers = _timers;
			if (timers.Length <= handle || onUpdate == null || (timers[handle].Flags & TimerFlags.Active) == 0)
			{
				return;
			}
			OnTimerUpdate[] updateCallbacks = _updateCallbacks;
			Delegate obj = Delegate.Remove(updateCallbacks[handle], onUpdate);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(OnTimerUpdate))
				{
					updateCallbacks[handle] = (OnTimerUpdate)obj;
					if ((object)obj.GetType() == typeof(OnTimerUpdate))
					{
						return;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				throw new IndexOutOfRangeException();
			}
			updateCallbacks[handle] = null;
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x8194384", Offset = "0x8194384", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv47 = this._timers;\n\tv50 = v47.Length <= handle;\n\tif (v50) goto L_007D;\n\tv81 = onComplete == 0;\n\tif (v81) goto L_007D;\n\tv223 = v47[handle @ X1 (System.Int32)].Flags & 1;\n\tv82 = v223 == 0;\n\tif (v82) goto L_007D;\n\tv107 = this._completeCallbacks;\n\tv214 = System.Delegate::Remove(v107[handle @ X1 (System.Int32)], onComplete);\n\tv168 = v214 == 0;\n\tif (v168) goto L_007E;\n\tv194 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerComplete;\n\tif (v194) goto L_008C;\n\tv107[handle @ X1 (System.Int32)] = v214;\n\tv124 = *([v214 @ X0_v9 (System.Delegate)]) != Unco.TimeTaskSystem.Runtime.OnTimerComplete;\n\tif (v124) goto L_008C;\n\treturn;\nL_007D:\n\treturn;\nL_007E:\n\tv107[handle @ X1 (System.Int32)] = 0;\n\treturn;\nL_008C:\n\tv220 = new System.InvalidCastException();\n\tthrow System.IndexOutOfRangeException;\nL_0016:\n\tv44 = handle & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_007D;\n")]
		internal void UnsubscribeFromTimerComplete(int handle, OnTimerComplete onComplete)
		{
			//IL_0165: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) != 0)
			{
				return;
			}
			Timer[] timers = _timers;
			if (timers.Length <= handle || onComplete == null || (timers[handle].Flags & TimerFlags.Active) == 0)
			{
				return;
			}
			OnTimerComplete[] completeCallbacks = _completeCallbacks;
			Delegate obj = Delegate.Remove(completeCallbacks[handle], onComplete);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(OnTimerComplete))
				{
					completeCallbacks[handle] = (OnTimerComplete)obj;
					if ((object)obj.GetType() == typeof(OnTimerComplete))
					{
						return;
					}
				}
				InvalidCastException ex = new InvalidCastException();
				throw new IndexOutOfRangeException();
			}
			completeCallbacks[handle] = null;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x819449C", Offset = "0x819449C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = handle & 0x80000000;\n\tv16 = v14 == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_002C;\n\tv18 = this._timers;\n\tv22 = v18.Length <= handle;\n\tif (v22) goto L_002C;\n\tv180 = v18[handle @ X1 (System.Int32)].Flags & 1;\n\tv181 = v180 == 0;\n\tv56 = ~v181;\n\tif (v56) goto L_002D;\nL_002C:\n\treturn;\nL_002D:\n\tv100 = this._updateCallbacks;\n\tv100[handle @ X1 (System.Int32)] = 0;\n\tv101 = this._completeCallbacks;\n\tv101[handle @ X1 (System.Int32)] = 0;\n\treturn;\n")]
		internal void UnsubscribeAllFromTimer(int handle)
		{
			//IL_0012: Expected I4, but got I8
			if ((int)(handle & 0x80000000L) == 0)
			{
				Timer[] timers = _timers;
				if (timers.Length > handle && (timers[handle].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					OnTimerUpdate[] updateCallbacks = _updateCallbacks;
					updateCallbacks[handle] = null;
					OnTimerComplete[] completeCallbacks = _completeCallbacks;
					completeCallbacks[handle] = null;
				}
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x819454C", Offset = "0x819454C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = handle & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_0048;\n\tv10 = this._timers;\n\tv27 = v10.Length <= handle;\n\tif (v27) goto L_0048;\n\tv68 = v10 + 0x20;\n\tv153 = handle * 0x18;\n\tv154 = v68 + v153;\n\tv155 = *([v154 @ X9_v6+10]) & 1;\n\tv71 = v155 == 0;\n\tif (v71) goto L_0048;\n\tv158 = handle * 0x18;\n\tv69 = v68 + v158;\n\tv21 = *([v69 @ X8_v6+4]) + timeToAdd;\n\t*([v69 @ X8_v6+4]) = v21;\n\tv24 = this._updateCallbacks;\n\tv65 = v24[handle @ X1 (System.Int32)];\n\tv72 = v24[handle @ X1 (System.Int32)] == 0;\n\tif (v72) goto L_0048;\n\tUnco.TimeTaskSystem.Runtime.OnTimerUpdate::Invoke(v24[handle @ X1 (System.Int32)], v65.method, v65.invoke_impl);\n\treturn;\nL_0048:\n\treturn;\n")]
		public void AddTime(int handle, float timeToAdd)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::AddTime");
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x81945E0", Offset = "0x81945E0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = countDown == 0;\n\tv11 = ~v5;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv31 = 9;\n\tgoto L_0011;\nL_FFFFFFFF:\n\tv31 = 1;\nL_FFFFFFFF:\n\tv31 = v16;\n\tgoto L_0022;\nL_FFFFFFFF:\n\tv47 = v32;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv47 = v31;\nL_0011:\n\tv16 = v31 | 4;\n\tv22 = hasInterval == 0;\n\tv27 = ~v22;\n\tv28 = ~v27;\n\tif (v28) goto L_0022;\nL_0022:\n\tv32 = v31 | 0x10;\n\tv38 = loops == 0;\n\tv43 = ~v38;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\nL_0033:\n\treturnVal1 = Unco.TimeTaskSystem.Runtime.TimeTaskController::CreateTimer(this, duration, v47, elapsed, updateInterval);\n\treturn returnVal1;\n")]
		public TimerHandle CreateTimer(float duration, bool countDown, bool hasInterval, bool loops, float elapsed = 0f, float updateInterval = 0f)
		{
			int num = ((!countDown) ? 1 : 9);
			int num2 = num | 4;
			if (hasInterval)
			{
				num = num2;
			}
			int num3 = num | 0x10;
			TimerFlags flags = (TimerFlags)((!loops) ? num : num3);
			return CreateTimer(duration, flags, elapsed, updateInterval);
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x8194608", Offset = "0x8194608", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv79 = v63.Count < 1;\n\tif (v79) goto L_0047;\n\tv208 = System.Collections.Generic.Queue`1<System.Int32>::Dequeue(v63);\nL_FFFFFFFF:\n\tv200 = v208;\n\tgoto L_00A1;\nL_0047:\n\tv192 = this._timers;\n\tv200 = this._nextHandle;\n\tv107 = this._nextHandle + 1;\n\tthis._nextHandle = v107;\n\tv124 = this._nextHandle < v192.Length;\n\tif (v124) goto L_00A1;\n\tv102 = v192.Length << 1;\n\t// 95 NewArr v272 @ X0_v22 (Unco.TimeTaskSystem.Runtime.Timer[]), typeof(Unco.TimeTaskSystem.Runtime.Timer[]), v102 @ X23_v6 (System.Int32)\n\tv177 = this._timers;\n\tSystem.Array::Copy(this._timers, v272, *([v177 @ X0_v23 (System.Array)+18]));\n\tthis._timers = v272;\n\t// 112 NewArr v368 @ X0_v27 (Unco.TimeTaskSystem.Runtime.OnTimerUpdate[]), typeof(Unco.TimeTaskSystem.Runtime.OnTimerUpdate[]), v102 @ X23_v6 (System.Int32)\n\t// 118 NewArr v374 @ X0_v29 (Unco.TimeTaskSystem.Runtime.OnTimerComplete[]), typeof(Unco.TimeTaskSystem.Runtime.OnTimerComplete[]), v102 @ X23_v6 (System.Int32)\n\tv178 = this._updateCallbacks;\n\tSystem.Array::Copy(this._updateCallbacks, v368, *([v178 @ X0_v30 (System.Array)+18]));\n\tv179 = this._completeCallbacks;\n\tSystem.Array::Copy(this._completeCallbacks, v374, *([v179 @ X0_v31 (System.Array)+18]));\n\tthis._updateCallbacks = v368;\n\tthis._completeCallbacks = v374;\nL_00A1:\n\tv100 = this._timers + 0x20;\n\tv335 = v200 * 0x18;\n\tv336 = v100 + v335;\n\tv337 = updateInterval < 0;\n\tv338 = updateInterval == 0;\n\tv341 = updateInterval == updateInterval;\n\tv342 = ~v341;\n\tv343 = v337 == v342;\n\tv344 = ~v343;\n\tv126 = v344 | v338;\n\tif (v126) goto L_FFFFFFFF;\n\tgoto L_00B9;\nL_FFFFFFFF:\n\tv84 = elapsed;\nL_00C9:\n\tv370 = v200 * 0x18;\n\tv371 = v100 + v370;\n\t*([v371 @ X8_v10]) = elapsed;\n\t*([v371 @ X8_v10+4]) = duration;\n\t*([v371 @ X8_v10+8]) = updateInterval;\n\t*([v371 @ X8_v10+C]) = v84;\n\t*([v371 @ X8_v10+10]) = flags;\n\t*([v371 @ X8_v10+11]) = 0;\n\t*([v371 @ X8_v10+13]) = 0;\n\t*([v371 @ X8_v10+14]) = *([v336 @ X9_v5+14]);\n\tv196 = this._updateCallbacks;\n\tv196[v200 @ X21_v4 (System.Int32)] = 0;\n\tv197 = this._completeCallbacks;\n\tv197[v200 @ X21_v4 (System.Int32)] = 0;\n\treturn v286;\nL_002F:\n\tv63 = this._freeHandles;\nL_00B9:\n\tv360 = elapsed / updateInterval;\n\tv361 = UnityEngine.Mathf::Floor(v360);\n\tv84 = v361 * updateInterval;\n\tgoto L_00C9;\n")]
		public TimerHandle CreateTimer(float duration, TimerFlags flags, float elapsed = 0f, float updateInterval = 0f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimeTaskController::CreateTimer");
			return default;
		}
	}
}
