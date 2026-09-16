using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using CodeStage.AntiCheat.Common;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace CodeStage.AntiCheat.Detectors
{
	[AddComponentMenu(null)]
	[Token(Token = "0x2000037")]
	public abstract class ACTkDetectorBase<T> : KeepAliveBehaviour<T> where T : ACTkDetectorBase<T>
	{
		[Token(Token = "0x40000E9")]
		protected const string MenuPath = "Code Stage/Anti-Cheat Toolkit/";

		[Tooltip("Automatically start detector. Detection Event will be called on detection.")]
		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x0")]
		public bool autoStart;

		[Tooltip("Automatically dispose Detector after firing callback.")]
		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x0")]
		public bool autoDispose;

		[SerializeField]
		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x0")]
		protected UnityEvent detectionEvent;

		[SerializeField]
		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x0")]
		protected internal bool detectionEventHasListener;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x0")]
		protected internal bool started;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x0")]
		protected bool isRunning;

		[Token(Token = "0x1700002C")]
		public bool IsCheatDetected
		{
			[CompilerGenerated]
			[Token(Token = "0x6000383")]
			[Address(RVA = "0xDD0518", Offset = "0xDD0518", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsCheatDetected>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsCheatDetected;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000384")]
			[Address(RVA = "0xDD0520", Offset = "0xDD0520", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsCheatDetected>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected set
			{
				_003CIsCheatDetected_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002D")]
		public bool IsStarted
		{
			[Token(Token = "0x6000385")]
			[Address(RVA = "0xDD052C", Offset = "0xDD052C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.started;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsStarted;
			}
		}

		[Token(Token = "0x1700002E")]
		public bool IsRunning
		{
			[Token(Token = "0x6000386")]
			[Address(RVA = "0xDD0534", Offset = "0xDD0534", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isRunning;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsRunning;
			}
		}

		[Token(Token = "0x14000004")]
		public event Action CheatDetected
		{
			[CompilerGenerated]
			[Token(Token = "0x6000381")]
			[Address(RVA = "0xDD03E0", Offset = "0xDD03E0", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35894]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.CheatDetected;
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
			[Token(Token = "0x6000382")]
			[Address(RVA = "0xDD047C", Offset = "0xDD047C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = System.Action;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A35895]) = v38;\nL_0014:\n\tv40 = this + 0x30;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 48;
				Delegate obj2 = this.CheatDetected;
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

		[Token(Token = "0x6000387")]
		[Address(RVA = "0xDD053C", Offset = "0xDD053C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>::Start(this);\n\tv27 = ~this.autoStart;\n\tif (v27) goto L_0013;\n\tv29 = ~this.started;\n\tif (v29) goto L_0014;\nL_0013:\n\treturn;\nL_0014:\n\tv45 = this->klass;\n\tv35 = this->klass->vtable[16];\n\tv41 = this->klass->vtable[16];\n\t// 27 IndirectJump v35 @ X2_v1, this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), v41 @ X1_v2, v35 @ X2_v1, v13 @ X3, v14 @ X4, v15 @ X5, v16 @ X6, v17 @ X7, v18 @ V0, v19 @ V1, v20 @ V2, v21 @ V3, v22 @ V4, v23 @ V5, v24 @ V6, v25 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Start()
		{
			//IL_0042: Expected I, but got O
			//IL_0052: Expected O, but got I
			//IL_0062: Expected O, but got I
			base.Start();
			if (autoStart && !IsStarted)
			{
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v6 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+238]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v6 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+240]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v35 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0xDD058C", Offset = "0xDD058C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[15];\n\tv3 = this->klass->vtable[15];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void OnEnable()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+228]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+230]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000389")]
		[Address(RVA = "0xDD059C", Offset = "0xDD059C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv2 = this->klass->vtable[14];\n\tv3 = this->klass->vtable[14];\n\t// 3 IndirectJump v2 @ X2_v1, this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), v3 @ X1_v1, v2 @ X2_v1, v4 @ X3, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n")]
		private void OnDisable()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+218]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+220]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v2 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600038A")]
		[Address(RVA = "0xDD05AC", Offset = "0xDD05AC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this->klass;\n\tv5 = this->klass->vtable[9];\n\tv6 = this->klass->vtable[9];\n\t// 9 IndirectJump v5 @ X2_v1, this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), v6 @ X1_v1, v5 @ X2_v1, v8 @ X3, v9 @ X4, v10 @ X5, v11 @ X6, v12 @ X7, v13 @ V0, v14 @ V1, v15 @ V2, v16 @ V3, v17 @ V4, v18 @ V5, v19 @ V6, v20 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationQuit()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v1 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+1C8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X8_v1 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+1D0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v5 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600038B")]
		[Address(RVA = "0xDD05C8", Offset = "0xDD05C8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1::StopDetectionInternal(this);\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>::OnDestroy(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal override void OnDestroy()
		{
			((ACTkDetectorBase<>)(object)this).StopDetectionInternal();
			base.OnDestroy();
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0xDD0608", Offset = "0xDD0608", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsCheatDetected>k__BackingField = 1;\n\tv8 = this.CheatDetected == 0;\n\tif (v8) goto L_000E;\n\tSystem.Action::Invoke(this.CheatDetected);\nL_000E:\n\tv32 = ~this.detectionEventHasListener;\n\tif (v32) goto L_0016;\n\tUnityEngine.Events.UnityEvent::Invoke(this.detectionEvent);\nL_0016:\n\tv40 = this->klass;\n\tv41 = ~this.autoDispose;\n\tif (v41) goto L_001C;\n\tv47 = this->klass->vtable[9];\n\tv48 = this->klass->vtable[9];\n\tgoto L_0022;\nL_001C:\n\tv47 = this->klass->vtable[13];\n\tv48 = this->klass->vtable[13];\nL_0022:\n\t// 34 IndirectJump v47 @ X2_v1, this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), this @ X0 (CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>), v48 @ X1_v3, v47 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal virtual void OnCheatingDetected()
		{
			//IL_0050: Expected I, but got O
			//IL_00a0: Expected O, but got I
			//IL_00b0: Expected O, but got I
			//IL_007b: Expected O, but got I
			//IL_008b: Expected O, but got I
			IsCheatDetected = true;
			if (this.CheatDetected != null)
			{
				this.CheatDetected();
			}
			if (detectionEventHasListener)
			{
				detectionEvent.Invoke();
			}
			nint num = (nint)this;
			if (autoDispose)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+1C8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+1D0]");
				object obj2 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+208]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v3 (Il2CppClass<CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1<T>>)+210]");
				object obj2 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v47 @ X2_v1 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-10), the output could be wrong!");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-10), the output could be wrong!");
		}

		[Token(Token = "0x600038D")]
		[Address(RVA = "0xDD0674", Offset = "0xDD0674", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.CheatDetected == 0;\n\tif (v2) goto L_000A;\n\treturn 1;\nL_000A:\n\tv9 = this.detectionEventHasListener == 0;\n\tv14 = ~v9;\n\treturn v14;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual bool DetectorHasCallbacks()
		{
			if (this.CheatDetected != null)
			{
				return true;
			}
			bool flag = !detectionEventHasListener;
			return !flag;
		}

		[Token(Token = "0x600038E")]
		[Address(RVA = "0xDD0694", Offset = "0xDD0694", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CheatDetected = 0;\n\tthis.started = 0;\n\treturn;\n")]
		protected internal virtual void StopDetectionInternal()
		{
			this.CheatDetected = null;
			started = false;
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0xDD06A0", Offset = "0xDD06A0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.started;\n\tif (v2) goto L_0004;\n\tthis.isRunning = 0;\nL_0004:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void PauseDetector()
		{
			if (IsStarted)
			{
				isRunning = false;
			}
		}

		[Token(Token = "0x6000390")]
		[Address(RVA = "0xDD06B0", Offset = "0xDD06B0", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = ~this.started;\n\tif (v6) goto L_FFFFFFFF;\n\tv11 = CodeStage.AntiCheat.Detectors.ACTkDetectorBase`1::DetectorHasCallbacks(this);\n\tv27 = v11 == 0;\n\tif (v27) goto L_FFFFFFFF;\n\tthis.isRunning = 1;\n\tgoto L_0015;\nL_0015:\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual bool ResumeDetector()
		{
			if (IsStarted && ((ACTkDetectorBase<>)(object)this).DetectorHasCallbacks())
			{
				isRunning = true;
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000391")]
		protected abstract void StartDetectionAutomatically();

		[Token(Token = "0x6000392")]
		[Address(RVA = "0xDD06E8", Offset = "0xDD06E8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.autoStart = 0x101;\n\tCodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ACTkDetectorBase()
		{
			autoStart = true;
		}
	}
}
