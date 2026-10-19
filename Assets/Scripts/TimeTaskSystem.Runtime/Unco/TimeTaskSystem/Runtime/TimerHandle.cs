using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.TimeTaskSystem.Runtime
{
	[Token(Token = "0x200000B")]
	public readonly struct TimerHandle
	{
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x0")]
		public readonly TimeTaskController _controller;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x8")]
		public readonly int _handleId;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0xC")]
		private readonly int _generation;

		[Token(Token = "0x17000006")]
		public bool IsValid
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x8194C7C", Offset = "0x8194C7C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv2 = this._controller == 0;\n\tif (v2) goto L_0021;\n\tv4 = this._handleId & 0x80000000;\n\tv5 = v4 == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_0021;\n\tv45 = v0._timers;\n\tv8 = this._handleId >= v45.Length;\n\tif (v8) goto L_0021;\n\tv44 = v45 + 0x20;\n\tv104 = this._handleId * 0x18;\n\tv105 = v44 + v104;\n\tv106 = *([v105 @ X10_v4+10]) & 1;\n\tv107 = v106 == 0;\n\tv41 = ~v107;\n\tif (v41) goto L_0024;\nL_0021:\n\treturn 0;\nL_0024:\n\tv84 = this._handleId * 0x18;\n\tv108 = v44 + v84;\n\tv76 = *([v108 @ X8_v3+14]) - this._generation;\n\tv72 = v76 == 0;\n\treturn v72;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::get_IsValid");
				return default;
			}
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81948CC", Offset = "0x81948CC", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._controller = controller;\n\tthis._handleId = handleId;\n\tthis._generation = generation;\n\treturn;\n")]
		internal TimerHandle(TimeTaskController controller, int handleId, int generation)
		{
			_controller = controller;
			_handleId = handleId;
			_generation = generation;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000031")]
		[Address(RVA = "0x8194CE4", Offset = "0x8194CE4", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv3 = this._controller == 0;\n\treturnVal1 = 0;\n\tif (v3) goto L_0024;\n\tv5 = this._handleId & 0x80000000;\n\tv6 = v5 == 0;\n\tv7 = ~v6;\n\treturnVal1 = 0;\n\tif (v7) goto L_0024;\n\tv51 = v0._timers;\n\tv9 = this._handleId >= v51.Length;\n\treturnVal1 = 0;\n\tif (v9) goto L_0024;\n\tv50 = v51 + 0x20;\n\tv94 = this._handleId * 0x18;\n\tv95 = v50 + v94;\n\tv96 = *([v95 @ X10_v4+10]) & 1;\n\tv46 = v96 == 0;\n\treturnVal1 = 0;\n\tif (v46) goto L_0024;\n\tv44 = this._handleId * 0x18;\n\tv41 = v50 + v44;\n\treturnVal1 = *([v41 @ X8_v3+4]);\nL_0024:\n\treturn returnVal1;\n")]
		public float GetDuration()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::GetDuration");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000032")]
		[Address(RVA = "0x8194D3C", Offset = "0x8194D3C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv3 = this._controller == 0;\n\treturnVal1 = 0;\n\tif (v3) goto L_0023;\n\tv5 = this._handleId & 0x80000000;\n\tv6 = v5 == 0;\n\tv7 = ~v6;\n\treturnVal1 = 0;\n\tif (v7) goto L_0023;\n\tv50 = v0._timers;\n\tv9 = this._handleId >= v50.Length;\n\treturnVal1 = 0;\n\tif (v9) goto L_0023;\n\tv49 = v50 + 0x20;\n\tv93 = this._handleId * 0x18;\n\tv94 = v49 + v93;\n\tv95 = *([v94 @ X10_v4+10]) & 1;\n\tv44 = v95 == 0;\n\treturnVal1 = 0;\n\tif (v44) goto L_0023;\n\tv41 = this._handleId * 0x18;\n\treturnVal1 = *([v49 @ X9_v4+v41 @ X8_v3 (System.Int32)]);\nL_0023:\n\treturn returnVal1;\n")]
		public float GetElapsedTime()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::GetElapsedTime");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000033")]
		[Address(RVA = "0x8194D94", Offset = "0x8194D94", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this._controller;\n\tv20 = this._controller == 0;\n\tif (v20) goto L_0062;\n\tgoto L_0019;\n\tv71 = v18._timers;\n\tv31 = this._handleId >= v71.Length;\n\tif (v31) goto L_0062;\n\tv72 = v71 + 0x20;\n\tv151 = this._handleId * 0x18;\n\tv152 = v72 + v151;\n\tv153 = *([v152 @ X9_v4+10]) & 1;\n\tv79 = v153 == 0;\n\tif (v79) goto L_0062;\n\tv80 = this._handleId * 0x18;\n\tv73 = v72 + v80;\n\tv49 = *([v73 @ X8_v6+4]) == 0;\n\tv154 = *([v73 @ X8_v6+4]) < 0;\n\tv61 = ~v154;\n\tv155 = ~v61;\n\tv32 = v155 | v49;\n\tif (v32) goto L_0062;\n\tgoto L_004A;\nL_004A:\n\tv119 = *([v73 @ X8_v6+4]) - *([v73 @ X8_v6]);\n\treturnVal3 = System.Math::Max(0f, v119);\n\treturn returnVal3;\nL_0062:\n\treturn 0;\nL_0019:\n\tv110 = this._handleId & 0x80000000;\n\tv111 = v110 == 0;\n\tv81 = ~v111;\n\tif (v81) goto L_0062;\n")]
		public float GetRemainingTime()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::GetRemainingTime");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000034")]
		[Address(RVA = "0x8194E6C", Offset = "0x8194E6C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this._controller;\n\tv21 = this._controller == 0;\n\treturnVal1 = 0;\n\tif (v21) goto L_0064;\n\treturnVal1 = 0;\n\tgoto L_001B;\n\tv72 = v18._timers;\n\tv32 = this._handleId >= v72.Length;\n\tif (v32) goto L_0064;\n\tv73 = v72 + 0x20;\n\tv154 = this._handleId * 0x18;\n\tv155 = v73 + v154;\n\tv156 = *([v155 @ X9_v4+10]) & 1;\n\tv80 = v156 == 0;\n\tif (v80) goto L_0064;\n\tv81 = this._handleId * 0x18;\n\tv74 = v73 + v81;\n\tv50 = *([v74 @ X8_v6+4]) == 0;\n\tv157 = *([v74 @ X8_v6+4]) < 0;\n\tv62 = ~v157;\n\tv158 = ~v62;\n\tv33 = v158 | v50;\n\treturnVal1 = 1f;\n\tif (v33) goto L_0064;\n\tgoto L_004D;\nL_004D:\n\tv120 = *([v74 @ X8_v6]) / *([v74 @ X8_v6+4]);\n\treturnVal3 = System.Math::Min(1f, v120);\n\treturn returnVal3;\nL_0064:\n\treturn returnVal1;\nL_001B:\n\tv113 = this._handleId & 0x80000000;\n\tv114 = v113 == 0;\n\tv82 = ~v114;\n\tif (v82) goto L_0064;\n")]
		public float GetProgress()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::GetProgress");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000035")]
		[Address(RVA = "0x8194F4C", Offset = "0x8194F4C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv2 = this._controller == 0;\n\tif (v2) goto L_0020;\n\tv4 = this._handleId & 0x80000000;\n\tv5 = v4 == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_0020;\n\tv45 = v0._timers;\n\tv8 = this._handleId >= v45.Length;\n\tif (v8) goto L_0020;\n\tv91 = v45[v3 @ X8_v2 (System.Int32)].Flags & 1;\n\tv92 = v91 == 0;\n\tv42 = ~v92;\n\tif (v42) goto L_0021;\nL_0020:\n\treturn 0;\nL_0021:\n\tv93 = v45[v3 @ X8_v2 (System.Int32)].Flags >> 3;\n\treturnVal3 = v93 & 1;\n\treturn returnVal3;\n")]
		public bool CountsDown()
		{
			//IL_0039: Expected I4, but got I8
			TimeTaskController controller = _controller;
			if (_controller != null && (int)(_handleId & 0x80000000L) == 0)
			{
				Timer[] timers = controller._timers;
				int num = default(int);
				if (_handleId < timers.Length && (timers[num].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int num2 = (int)timers[num].Flags >> 3;
					return (byte)(num2 & 1) != 0;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000036")]
		[Address(RVA = "0x8194F9C", Offset = "0x8194F9C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv2 = this._controller == 0;\n\tif (v2) goto L_0020;\n\tv4 = this._handleId & 0x80000000;\n\tv5 = v4 == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_0020;\n\tv45 = v0._timers;\n\tv8 = this._handleId >= v45.Length;\n\tif (v8) goto L_0020;\n\tv91 = v45[v3 @ X8_v2 (System.Int32)].Flags & 1;\n\tv92 = v91 == 0;\n\tv42 = ~v92;\n\tif (v42) goto L_0021;\nL_0020:\n\treturn 0;\nL_0021:\n\tv93 = v45[v3 @ X8_v2 (System.Int32)].Flags >> 2;\n\treturnVal3 = v93 & 1;\n\treturn returnVal3;\n")]
		public bool UsesInterval()
		{
			//IL_0039: Expected I4, but got I8
			TimeTaskController controller = _controller;
			if (_controller != null && (int)(_handleId & 0x80000000L) == 0)
			{
				Timer[] timers = controller._timers;
				int num = default(int);
				if (_handleId < timers.Length && (timers[num].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int num2 = (int)timers[num].Flags >> 2;
					return (byte)(num2 & 1) != 0;
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000037")]
		[Address(RVA = "0x8194FEC", Offset = "0x8194FEC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv3 = this._controller == 0;\n\treturnVal1 = 0;\n\tif (v3) goto L_0024;\n\tv5 = this._handleId & 0x80000000;\n\tv6 = v5 == 0;\n\tv7 = ~v6;\n\treturnVal1 = 0;\n\tif (v7) goto L_0024;\n\tv51 = v0._timers;\n\tv9 = this._handleId >= v51.Length;\n\treturnVal1 = 0;\n\tif (v9) goto L_0024;\n\tv50 = v51 + 0x20;\n\tv94 = this._handleId * 0x18;\n\tv95 = v50 + v94;\n\tv96 = *([v95 @ X10_v4+10]) & 1;\n\tv46 = v96 == 0;\n\treturnVal1 = 0;\n\tif (v46) goto L_0024;\n\tv44 = this._handleId * 0x18;\n\tv41 = v50 + v44;\n\treturnVal1 = *([v41 @ X8_v3+8]);\nL_0024:\n\treturn returnVal1;\n")]
		public float GetUpdateInterval()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::GetUpdateInterval");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000038")]
		[Address(RVA = "0x8195044", Offset = "0x8195044", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv2 = this._controller == 0;\n\tif (v2) goto L_0021;\n\tv4 = this._handleId & 0x80000000;\n\tv5 = v4 == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_0021;\n\tv46 = v0._timers;\n\tv8 = this._handleId >= v46.Length;\n\tif (v8) goto L_0021;\n\tv91 = v46[v3 @ X8_v2 (System.Int32)].Flags & 1;\n\tv42 = v91 == 0;\n\tif (v42) goto L_0021;\n\tv45 = v46[v3 @ X8_v2 (System.Int32)].Flags | 2;\n\tv46[v3 @ X8_v2 (System.Int32)].Flags = v45;\nL_0021:\n\treturn;\n")]
		public void Pause()
		{
			//IL_0039: Expected I4, but got I8
			TimeTaskController controller = _controller;
			if (_controller != null && (int)(_handleId & 0x80000000L) == 0)
			{
				Timer[] timers = controller._timers;
				int num = default(int);
				if (_handleId < timers.Length && (timers[num].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int flags = (int)(timers[num].Flags | TimerFlags.Paused);
					timers[num].Flags = (TimerFlags)flags;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000039")]
		[Address(RVA = "0x8195090", Offset = "0x8195090", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._controller;\n\tv2 = this._controller == 0;\n\tif (v2) goto L_0021;\n\tv4 = this._handleId & 0x80000000;\n\tv5 = v4 == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_0021;\n\tv46 = v0._timers;\n\tv8 = this._handleId >= v46.Length;\n\tif (v8) goto L_0021;\n\tv91 = v46[v3 @ X8_v2 (System.Int32)].Flags & 1;\n\tv42 = v91 == 0;\n\tif (v42) goto L_0021;\n\tv45 = v46[v3 @ X8_v2 (System.Int32)].Flags & -3;\n\tv46[v3 @ X8_v2 (System.Int32)].Flags = v45;\nL_0021:\n\treturn;\n")]
		public void Resume()
		{
			//IL_0039: Expected I4, but got I8
			TimeTaskController controller = _controller;
			if (_controller != null && (int)(_handleId & 0x80000000L) == 0)
			{
				Timer[] timers = controller._timers;
				int num = default(int);
				if (_handleId < timers.Length && (timers[num].Flags & TimerFlags.Active) != TimerFlags.None)
				{
					int flags = (int)timers[num].Flags & -3;
					timers[num].Flags = (TimerFlags)flags;
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600003A")]
		[Address(RVA = "0x81950DC", Offset = "0x81950DC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._controller == 0;\n\tif (v3) goto L_0007;\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::StopTimer(this._controller, this._handleId);\n\treturn;\nL_0007:\n\treturn;\n")]
		public void Stop()
		{
			if (_controller != null)
			{
				_controller.StopTimer(_handleId);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81950F4", Offset = "0x81950F4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._controller == 0;\n\tif (v3) goto L_0008;\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::SubscribeToTimerUpdate(this._controller, this._handleId, callback);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void SubscribeOnUpdate(OnTimerUpdate callback)
		{
			if (_controller != null)
			{
				_controller.SubscribeToTimerUpdate(_handleId, callback);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600003C")]
		[Address(RVA = "0x8195110", Offset = "0x8195110", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._controller == 0;\n\tif (v3) goto L_0008;\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::UnsubscribeFromTimerUpdate(this._controller, this._handleId, callback);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void UnsubscribeOnUpdate(OnTimerUpdate callback)
		{
			if (_controller != null)
			{
				_controller.UnsubscribeFromTimerUpdate(_handleId, callback);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600003D")]
		[Address(RVA = "0x819512C", Offset = "0x819512C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._controller == 0;\n\tif (v3) goto L_0008;\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::SubscribeToTimerComplete(this._controller, this._handleId, callback);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void SubscribeOnComplete(OnTimerComplete callback)
		{
			if (_controller != null)
			{
				_controller.SubscribeToTimerComplete(_handleId, callback);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600003E")]
		[Address(RVA = "0x8195148", Offset = "0x8195148", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._controller == 0;\n\tif (v3) goto L_0008;\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::UnsubscribeFromTimerComplete(this._controller, this._handleId, callback);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void UnsubscribeOnComplete(OnTimerComplete callback)
		{
			if (_controller != null)
			{
				_controller.UnsubscribeFromTimerComplete(_handleId, callback);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600003F")]
		[Address(RVA = "0x8195164", Offset = "0x8195164", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this._controller == 0;\n\tif (v3) goto L_0007;\n\tUnco.TimeTaskSystem.Runtime.TimeTaskController::UnsubscribeAllFromTimer(this._controller, this._handleId);\n\treturn;\nL_0007:\n\treturn;\n")]
		public void UnsubscribeAll()
		{
			if (_controller != null)
			{
				_controller.UnsubscribeAllFromTimer(_handleId);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000040")]
		[Address(RVA = "0x819517C", Offset = "0x819517C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._controller;\n\tv8 = this._controller == 0;\n\tif (v8) goto L_0047;\n\tv9 = this._handleId;\n\tv10 = this._handleId & 0x80000000;\n\tv11 = v10 == 0;\n\tv12 = ~v11;\n\tif (v12) goto L_0047;\n\tv61 = v6._timers;\n\tv21 = this._handleId >= v61.Length;\n\tif (v21) goto L_0047;\n\tv62 = v61 + 0x20;\n\tv151 = this._handleId * 0x18;\n\tv152 = v62 + v151;\n\tv153 = *([v152 @ X11_v6+10]) & 1;\n\tv69 = v153 == 0;\n\tif (v69) goto L_0047;\n\tv155 = this._handleId * 0x18;\n\tv63 = v62 + v155;\n\tv18 = *([v63 @ X10_v6+4]) + timeToAdd;\n\t*([v63 @ X10_v6+4]) = v18;\n\tv72 = v6._updateCallbacks;\n\tv66 = v72[v9 @ X8_v2 (System.Int32)];\n\tv70 = v72[v9 @ X8_v2 (System.Int32)] == 0;\n\tif (v70) goto L_0047;\n\tUnco.TimeTaskSystem.Runtime.OnTimerUpdate::Invoke(v72[v9 @ X8_v2 (System.Int32)], v66.method, v66.invoke_impl);\n\treturn;\nL_0047:\n\treturn;\n")]
		public void AddTime(float timeToAdd)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TimerHandle::AddTime");
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x8195218", Offset = "0x8195218", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\treturn returnVal1;\nL_001A:\n\tv50 = this._handleId;\n\tv52 = 0xB7D5000 + 0x538;\n\tv55 = \"il2cpp_vm_object_box\"(*([v52 @ X23_v2 (System.Int32)+48]), &v50 @ stack_-44_v1 (System.Int32), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = this._generation;\n\tv61 = \"il2cpp_vm_object_box\"(*([v52 @ X23_v2 (System.Int32)+48]), &v58 @ stack_-48_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = System.String::Format(\"{0}_[{1}, {2}]\", this._controller, v55, v61);\n")]
		public override string ToString()
		{
			int handleId = _handleId;
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			int generation = _generation;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			object arg2 = default(object);
			return $"{_controller}_[{arg}, {arg2}]";
		}
	}
}
