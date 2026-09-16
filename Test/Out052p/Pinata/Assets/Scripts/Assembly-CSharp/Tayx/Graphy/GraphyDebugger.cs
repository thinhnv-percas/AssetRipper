using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Tayx.Graphy.Audio;
using Tayx.Graphy.Fps;
using Tayx.Graphy.Ram;
using Tayx.Graphy.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace Tayx.Graphy
{
	[Token(Token = "0x200002C")]
	public class GraphyDebugger : G_Singleton<GraphyDebugger>
	{
		[Token(Token = "0x2000459")]
		public enum DebugVariable
		{
			[Token(Token = "0x400206B")]
			Fps = 0,
			[Token(Token = "0x400206C")]
			Fps_Min = 1,
			[Token(Token = "0x400206D")]
			Fps_Max = 2,
			[Token(Token = "0x400206E")]
			Fps_Avg = 3,
			[Token(Token = "0x400206F")]
			Ram_Allocated = 4,
			[Token(Token = "0x4002070")]
			Ram_Reserved = 5,
			[Token(Token = "0x4002071")]
			Ram_Mono = 6,
			[Token(Token = "0x4002072")]
			Audio_DB = 7
		}

		[Token(Token = "0x200045A")]
		public enum DebugComparer
		{
			[Token(Token = "0x4002074")]
			Less_than = 0,
			[Token(Token = "0x4002075")]
			Equals_or_less_than = 1,
			[Token(Token = "0x4002076")]
			Equals = 2,
			[Token(Token = "0x4002077")]
			Equals_or_greater_than = 3,
			[Token(Token = "0x4002078")]
			Greater_than = 4
		}

		[Token(Token = "0x200045B")]
		public enum ConditionEvaluation
		{
			[Token(Token = "0x400207A")]
			All_conditions_must_be_met = 0,
			[Token(Token = "0x400207B")]
			Only_one_condition_has_to_be_met = 1
		}

		[Token(Token = "0x200045C")]
		public enum MessageType
		{
			[Token(Token = "0x400207D")]
			Log = 0,
			[Token(Token = "0x400207E")]
			Warning = 1,
			[Token(Token = "0x400207F")]
			Error = 2
		}

		[Serializable]
		[StructLayout((LayoutKind)0, Size = 12)]
		[Token(Token = "0x200045D")]
		public struct DebugCondition
		{
			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB1E8", Offset = "0x7DB1E8")]
			[Token(Token = "0x4002080")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public DebugVariable Variable;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB220", Offset = "0x7DB220")]
			[Token(Token = "0x4002081")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public DebugComparer Comparer;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB258", Offset = "0x7DB258")]
			[Token(Token = "0x4002082")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float Value;
		}

		[Serializable]
		[Token(Token = "0x200045E")]
		public class DebugPacket
		{
			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB290", Offset = "0x7DB290")]
			[Token(Token = "0x4002083")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public bool Active;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB2C8", Offset = "0x7DB2C8")]
			[Token(Token = "0x4002084")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
			public int Id;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB300", Offset = "0x7DB300")]
			[Token(Token = "0x4002085")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public bool ExecuteOnce;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB338", Offset = "0x7DB338")]
			[Token(Token = "0x4002086")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
			public float InitSleepTime;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB370", Offset = "0x7DB370")]
			[Token(Token = "0x4002087")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public float ExecuteSleepTime;

			[Token(Token = "0x4002088")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public ConditionEvaluation ConditionEvaluation;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB3A8", Offset = "0x7DB3A8")]
			[Token(Token = "0x4002089")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public List<DebugCondition> DebugConditions;

			[Token(Token = "0x400208A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public MessageType MessageType;

			[Multiline]
			[Token(Token = "0x400208B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public string Message;

			[Token(Token = "0x400208C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public bool TakeScreenshot;

			[Token(Token = "0x400208D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			public string ScreenshotFileName;

			[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7DB3F0", Offset = "0x7DB3F0")]
			[Token(Token = "0x400208E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public bool DebugBreak;

			[Token(Token = "0x400208F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			public UnityEvent UnityEvents;

			[Token(Token = "0x4002090")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public List<Action> Callbacks;

			[Token(Token = "0x4002091")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
			internal bool canBeChecked;

			[Token(Token = "0x4002092")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x69")]
			internal bool executed;

			[Token(Token = "0x4002093")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x6C")]
			private float timePassed;

			[Token(Token = "0x1700006B")]
			public bool Check
			{
				[Token(Token = "0x6001563")]
				[Address(RVA = "0xB15BE0", Offset = "0xB15BE0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.canBeChecked;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return Check;
				}
			}

			[Token(Token = "0x6001564")]
			[Address(RVA = "0xB15240", Offset = "0xB15240", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this.canBeChecked;\n\tv14 = ~v13;\n\tif (v14) goto L_002A;\n\tv17 = UnityEngine.Time::get_deltaTime();\n\tv49 = this.timePassed + v17;\n\tthis.timePassed = v49;\n\tv54 = ~this.executed;\n\tif (v54) goto L_0015;\n\tv46 = this.ExecuteSleepTime;\n\tgoto L_0020;\nL_0015:\n\tv46 = this.InitSleepTime;\nL_0020:\n\tv19 = v49 < v46;\n\tif (v19) goto L_002A;\n\tthis.canBeChecked = 1;\n\tthis.timePassed = 0f;\nL_002A:\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Update()
			{
				if (!Check)
				{
					float deltaTime = Time.deltaTime;
					float num = (timePassed += deltaTime);
					float num2 = ((!executed) ? InitSleepTime : ExecuteSleepTime);
					if (!(num < num2))
					{
						canBeChecked = true;
						timePassed = 0f;
					}
				}
			}

			[Token(Token = "0x6001565")]
			[Address(RVA = "0xB15AE4", Offset = "0xB15AE4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.canBeChecked = 0x100;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Executed()
			{
				canBeChecked = false;
				executed = true;
			}

			[Token(Token = "0x6001566")]
			[Address(RVA = "0xB149FC", Offset = "0xB149FC", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F06C20]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022550]) = v38;\nL_0015:\n\tthis.Active = 1;\n\tthis.ExecuteOnce = 1;\n\tthis.InitSleepTime = 2f;\n\tv44 = new System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>();\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>::.ctor(v44);\n\tthis.DebugConditions = v44;\n\tthis.Message = v53.Empty;\n\tthis.ScreenshotFileName = \"Graphy_Screenshot\";\n\tv60 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v60);\n\tthis.Callbacks = v60;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public DebugPacket()
			{
				Active = true;
				ExecuteOnce = true;
				InitSleepTime = 2f;
				List<DebugCondition> debugConditions = new List<DebugCondition>();
				DebugConditions = debugConditions;
				Message = string.Empty;
				ScreenshotFileName = "Graphy_Screenshot";
				List<Action> callbacks = new List<Action>();
				Callbacks = callbacks;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000462")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4002097")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4002098")]
			public static Predicate<DebugPacket> _003C_003E9__24_0;

			[Token(Token = "0x600156D")]
			[Address(RVA = "0xB15AF0", Offset = "0xB15AF0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EF3B20]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([202254F]) = v37;\nL_0015:\n\tv41 = new Tayx.Graphy.GraphyDebugger+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600156E")]
			[Address(RVA = "0xB15B54", Offset = "0xB15B54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CCheckDebugPackets_003Eb__24_0(DebugPacket packet)
			{
				return packet == null;
			}
		}

		[SerializeField]
		[Token(Token = "0x4000107")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		private List<DebugPacket> m_debugPackets;

		[Token(Token = "0x4000108")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private G_FpsMonitor m_fpsMonitor;

		[Token(Token = "0x4000109")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private G_RamMonitor m_ramMonitor;

		[Token(Token = "0x400010A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		private G_AudioMonitor m_audioMonitor;

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xB14390", Offset = "0xB14390", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF5500]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202253E]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>();\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::.ctor(v42);\n\tthis.m_debugPackets = v42;\n\tgoto L_0032;\n\tv53 = *([v49 @ X0_v4+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0032;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v46, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tTayx.Graphy.Utils.G_Singleton`1<Tayx.Graphy.GraphyDebugger>::.ctor(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected GraphyDebugger()
		{
			List<DebugPacket> debugPackets = new List<DebugPacket>();
			m_debugPackets = debugPackets;
			base._002Ector();
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xB14428", Offset = "0xB14428", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC3240]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202253F]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponentInChildren(this);\n\tthis.m_fpsMonitor = v43;\n\tv48 = UnityEngine.Component::GetComponentInChildren(this);\n\tthis.m_ramMonitor = v48;\n\tv53 = UnityEngine.Component::GetComponentInChildren(this);\n\tthis.m_audioMonitor = v53;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			G_FpsMonitor componentInChildren = GetComponentInChildren<G_FpsMonitor>();
			m_fpsMonitor = componentInChildren;
			G_RamMonitor componentInChildren2 = GetComponentInChildren<G_RamMonitor>();
			m_ramMonitor = componentInChildren2;
			G_AudioMonitor componentInChildren3 = GetComponentInChildren<G_AudioMonitor>();
			m_audioMonitor = componentInChildren3;
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xB144B0", Offset = "0xB144B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tTayx.Graphy.GraphyDebugger::CheckDebugPackets(this);\n\treturn;\n")]
		private void Update()
		{
			CheckDebugPackets();
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xB14890", Offset = "0xB14890", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F06720]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, newDebugPacket, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022540]) = v41;\nL_0016:\n\tv43 = this.m_debugPackets == 0;\n\tif (v43) goto L_002A;\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::Add(this.m_debugPackets, newDebugPacket);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNewDebugPacket(DebugPacket newDebugPacket)
		{
			if (m_debugPackets != null)
			{
				m_debugPackets.Add(newDebugPacket);
			}
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0xB14904", Offset = "0xB14904", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = *([1ED4260]);\n\tv47 = *([v46 @ X8_v13]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, newId, newDebugCondition, newMessageType, newMessage, newDebugBreak, newCallback, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2022541]) = v59;\nL_0024:\n\tv63 = new Tayx.Graphy.GraphyDebugger+DebugPacket();\n\tTayx.Graphy.GraphyDebugger+DebugPacket::.ctor(v63);\n\tv63.Id = newId;\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>::Add(v63.DebugConditions, newDebugCondition);\n\tv82 = newCallback & 1;\n\tv63.MessageType = newMessage;\n\tv63.Message = newDebugBreak;\n\tv63.DebugBreak = v82;\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v63.Callbacks, methodInfo);\n\tTayx.Graphy.GraphyDebugger::AddNewDebugPacket(this, v63);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNewDebugPacket(int newId, DebugCondition newDebugCondition, MessageType newMessageType, string newMessage, bool newDebugBreak, Action newCallback)
		{
			//IL_0046: Expected I4, but got O
			//IL_0053: Expected O, but got I4
			//IL_0077: Expected O, but got I
			DebugPacket debugPacket = new DebugPacket();
			debugPacket.Id = newId;
			debugPacket.DebugConditions.Add(newDebugCondition);
			int debugBreak = (int)((long)(IntPtr)newCallback & 1L);
			debugPacket.MessageType = (MessageType)newMessage;
			debugPacket.Message = (string)newDebugBreak;
			debugPacket.DebugBreak = (byte)debugBreak != 0;
			IntPtr intPtr = default(IntPtr);
			debugPacket.Callbacks.Add((Action)(long)intPtr);
			AddNewDebugPacket(debugPacket);
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0xB14AD0", Offset = "0xB14AD0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv42 = *([1EC2C30]);\n\tv43 = *([v42 @ X8_v11]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, newId, newDebugConditions, newMessageType, newMessage, newDebugBreak, newCallback, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022542]) = v56;\nL_0022:\n\tv60 = new Tayx.Graphy.GraphyDebugger+DebugPacket();\n\tTayx.Graphy.GraphyDebugger+DebugPacket::.ctor(v60);\n\tv60.Id = newId;\n\tv60.DebugConditions = newDebugConditions;\n\tv60.MessageType = newMessageType;\n\tv60.Message = newMessage;\n\tv60.DebugBreak = newDebugBreak;\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v60.Callbacks, newCallback);\n\tTayx.Graphy.GraphyDebugger::AddNewDebugPacket(this, v60);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNewDebugPacket(int newId, List<DebugCondition> newDebugConditions, MessageType newMessageType, string newMessage, bool newDebugBreak, Action newCallback)
		{
			DebugPacket debugPacket = new DebugPacket();
			debugPacket.Id = newId;
			debugPacket.DebugConditions = newDebugConditions;
			debugPacket.MessageType = newMessageType;
			debugPacket.Message = newMessage;
			debugPacket.DebugBreak = newDebugBreak;
			debugPacket.Callbacks.Add(newCallback);
			AddNewDebugPacket(debugPacket);
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0xB14BA0", Offset = "0xB14BA0", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = *([1EC1150]);\n\tv47 = *([v46 @ X8_v10]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, newId, newDebugCondition, newMessageType, newMessage, newDebugBreak, newCallbacks, methodInfo, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2022543]) = v59;\nL_0024:\n\tv63 = new Tayx.Graphy.GraphyDebugger+DebugPacket();\n\tTayx.Graphy.GraphyDebugger+DebugPacket::.ctor(v63);\n\tv63.Id = newId;\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>::Add(v63.DebugConditions, newDebugCondition);\n\tv77 = newCallbacks & 1;\n\tv63.MessageType = newMessage;\n\tv63.Message = newDebugBreak;\n\tv63.DebugBreak = v77;\n\tv63.Callbacks = methodInfo;\n\tTayx.Graphy.GraphyDebugger::AddNewDebugPacket(this, v63);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNewDebugPacket(int newId, DebugCondition newDebugCondition, MessageType newMessageType, string newMessage, bool newDebugBreak, List<Action> newCallbacks)
		{
			//IL_0046: Expected I4, but got O
			//IL_0053: Expected O, but got I4
			//IL_006d: Expected O, but got I
			DebugPacket debugPacket = new DebugPacket();
			debugPacket.Id = newId;
			debugPacket.DebugConditions.Add(newDebugCondition);
			int debugBreak = (int)((long)(IntPtr)newCallbacks & 1L);
			debugPacket.MessageType = (MessageType)newMessage;
			debugPacket.Message = (string)newDebugBreak;
			debugPacket.DebugBreak = (byte)debugBreak != 0;
			IntPtr intPtr = default(IntPtr);
			debugPacket.Callbacks = (List<Action>)(long)intPtr;
			AddNewDebugPacket(debugPacket);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0xB14C80", Offset = "0xB14C80", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv42 = *([1EA7268]);\n\tv43 = *([v42 @ X8_v8]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, newId, newDebugConditions, newMessageType, newMessage, newDebugBreak, newCallbacks, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022544]) = v56;\nL_0022:\n\tv60 = new Tayx.Graphy.GraphyDebugger+DebugPacket();\n\tTayx.Graphy.GraphyDebugger+DebugPacket::.ctor(v60);\n\tv60.Id = newId;\n\tv60.DebugConditions = newDebugConditions;\n\tv60.MessageType = newMessageType;\n\tv60.Message = newMessage;\n\tv60.DebugBreak = newDebugBreak;\n\tv60.Callbacks = newCallbacks;\n\tTayx.Graphy.GraphyDebugger::AddNewDebugPacket(this, v60);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddNewDebugPacket(int newId, List<DebugCondition> newDebugConditions, MessageType newMessageType, string newMessage, bool newDebugBreak, List<Action> newCallbacks)
		{
			DebugPacket debugPacket = new DebugPacket();
			debugPacket.Id = newId;
			debugPacket.DebugConditions = newDebugConditions;
			debugPacket.MessageType = newMessageType;
			debugPacket.Message = newMessage;
			debugPacket.DebugBreak = newDebugBreak;
			debugPacket.Callbacks = newCallbacks;
			AddNewDebugPacket(debugPacket);
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xB14D38", Offset = "0xB14D38", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F0E820]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, packetId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022545]) = v41;\nL_0018:\n\tv45 = new Tayx.Graphy.GraphyDebugger+<>c__DisplayClass18_0();\n\tSystem.Object::.ctor(v45);\n\tv45.packetId = packetId;\n\tv53 = new System.Func`2<Tayx.Graphy.GraphyDebugger+DebugPacket, System.Boolean>();\n\tSystem.Func`2<Tayx.Graphy.GraphyDebugger+DebugPacket, System.Boolean>::.ctor(v53, v45, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::First(this.m_debugPackets, v53);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DebugPacket GetFirstDebugPacketWithId(int packetId)
		{
			Func<DebugPacket, bool> predicate = delegate(DebugPacket x)
			{
				int num = x.Id - packetId;
				return num == 0;
			};
			return m_debugPackets.First(predicate);
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xB14E04", Offset = "0xB14E04", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EAC6E8]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, packetId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022546]) = v41;\nL_0018:\n\tv45 = new Tayx.Graphy.GraphyDebugger+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v45);\n\tv45.packetId = packetId;\n\tv53 = new System.Predicate`1<Tayx.Graphy.GraphyDebugger+DebugPacket>();\n\tSystem.Predicate`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::.ctor(v53, v45, Il2CppMethodInfo);\n\treturnVal2 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::FindAll(this.m_debugPackets, v53);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<DebugPacket> GetAllDebugPacketsWithId(int packetId)
		{
			Predicate<DebugPacket> match = delegate(DebugPacket x)
			{
				int num = x.Id - packetId;
				return num == 0;
			};
			return m_debugPackets.FindAll(match);
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0xB14ED4", Offset = "0xB14ED4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EAAD50]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, packetId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022547]) = v41;\nL_0016:\n\tv43 = this.m_debugPackets == 0;\n\tif (v43) goto L_0036;\n\tv46 = Tayx.Graphy.GraphyDebugger::GetFirstDebugPacketWithId(this, packetId);\n\tv50 = v46 == 0;\n\tif (v50) goto L_0036;\n\tv80 = Tayx.Graphy.GraphyDebugger::GetFirstDebugPacketWithId(this, packetId);\n\tv63 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::Remove(this.m_debugPackets, v80);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveFirstDebugPacketWithId(int packetId)
		{
			if (m_debugPackets != null)
			{
				DebugPacket firstDebugPacketWithId = GetFirstDebugPacketWithId(packetId);
				if (firstDebugPacketWithId != null)
				{
					DebugPacket firstDebugPacketWithId2 = GetFirstDebugPacketWithId(packetId);
					bool flag = m_debugPackets.Remove(firstDebugPacketWithId2);
				}
			}
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xB14F78", Offset = "0xB14F78", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED3C88]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, packetId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022548]) = v41;\nL_0018:\n\tv45 = new Tayx.Graphy.GraphyDebugger+<>c__DisplayClass21_0();\n\tSystem.Object::.ctor(v45);\n\tv45.packetId = packetId;\n\tv50 = this.m_debugPackets == 0;\n\tif (v50) goto L_0042;\n\tv56 = new System.Predicate`1<Tayx.Graphy.GraphyDebugger+DebugPacket>();\n\tSystem.Predicate`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::.ctor(v56, v45, Il2CppMethodInfo);\n\tv80 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::RemoveAll(this.m_debugPackets, v56);\n\treturn;\nL_0042:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAllDebugPacketsWithId(int packetId)
		{
			if (m_debugPackets != null)
			{
				Predicate<DebugPacket> match = delegate(DebugPacket x)
				{
					int num2 = x.Id - packetId;
					return num2 == 0;
				};
				int num = m_debugPackets.RemoveAll(match);
			}
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0xB15058", Offset = "0xB15058", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE7248]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, id, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022549]) = v44;\nL_0019:\n\tv47 = Tayx.Graphy.GraphyDebugger::GetFirstDebugPacketWithId(this, id);\n\tv48 = v47 == 0;\n\tif (v48) goto L_0038;\n\tv51 = Tayx.Graphy.GraphyDebugger::GetFirstDebugPacketWithId(this, id);\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v51.Callbacks, callback);\n\treturn;\nL_0038:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddCallbackToFirstDebugPacketWithId(Action callback, int id)
		{
			DebugPacket firstDebugPacketWithId = GetFirstDebugPacketWithId(id);
			if (firstDebugPacketWithId != null)
			{
				DebugPacket firstDebugPacketWithId2 = GetFirstDebugPacketWithId(id);
				firstDebugPacketWithId2.Callbacks.Add(callback);
			}
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xB150F4", Offset = "0xB150F4", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EF4FB8]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, callback, id, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202254A]) = v44;\nL_001B:\n\tv49 = 0;\n\tv50 = Tayx.Graphy.GraphyDebugger::GetAllDebugPacketsWithId(this, id);\n\tv51 = v50 == 0;\n\tif (v51) goto L_0069;\n\tv54 = Tayx.Graphy.GraphyDebugger::GetAllDebugPacketsWithId(this, id);\n\tv111 = v54 == 0;\n\tif (v111) goto L_0048;\n\tv142 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::GetEnumerator(v54);\nL_002F:\n\tv158 = 0xEF9AB0(&v49 @ stack_-48_v1, Il2CppMethodInfo, v83, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv166 = v158 & 1;\n\tv93 = v166 == 0;\n\tif (v93) goto L_0043;\n\tv161 = callback == 0;\n\tif (v161) goto L_002F;\n\tv150 = 0;\n\tSystem.Collections.Generic.List`1<System.Action>::Add(*([v150 @ X8_v14 (System.Int32)+60]), callback);\n\tgoto L_002F;\nL_0043:\n\tv90 = 0xEF9AAC(&v49 @ stack_-48_v1, Il2CppMethodInfo, v83, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0069;\n\tv179 = new System.NullReferenceException();\n\tv146 = new System.NullReferenceException();\nL_0048:\n\tv151 = new System.NullReferenceException();\n\tgoto L_0055;\n\tgoto L_0055;\n\tgoto L_0055;\nL_0055:\n\tv56 = Il2CppMethodInfo != 1;\n\tif (v56) goto L_006A;\n\tv167 = 0x6D2BC0(v151, Il2CppMethodInfo, v83, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv171 = 0x6D2490(v167, Il2CppMethodInfo, v83, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv89 = 0xEF9AAC(&v49 @ stack_-48_v1, Il2CppMethodInfo, v83, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv180 = *([v167 @ X0_v13]) == 0;\n\tv92 = ~v180;\n\tif (v92) goto L_006E;\nL_0069:\n\treturn;\nL_006A:\n\tv168 = 0x6D2380(v151, Il2CppMethodInfo, v83, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006E:\n\tthrow System.TypeLoadException;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddCallbackToAllDebugPacketWithId(Action callback, int id)
		{
			//IL_013a: Expected O, but got I4
			//IL_008a: Expected O, but got I
			object obj = 0;
			List<DebugPacket> allDebugPacketsWithId = GetAllDebugPacketsWithId(id);
			if (allDebugPacketsWithId == null)
			{
				return;
			}
			List<DebugPacket> allDebugPacketsWithId2 = GetAllDebugPacketsWithId(id);
			if (allDebugPacketsWithId2 != null)
			{
				List<DebugPacket>.Enumerator enumerator = allDebugPacketsWithId2.GetEnumerator();
				int num = id;
				object obj2 = default(object);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					if (callback != null)
					{
						int num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v14 (System.Int32)+60]");
						((List<Action>)0).Add(callback);
						num = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
				object obj3 = default(object);
				if (obj3 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xB144B4", Offset = "0xB144B4", Length = "0x3DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001E;\n\tv33 = *([1EC87E0]);\n\tv34 = *([v33 @ X8_v68]);\n\tv35 = \"il2cpp_codegen_initialize_method\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202254B]) = v53;\nL_001E:\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-98]) = &v56 @ stack_-C0;\n\tv87 = this.m_debugPackets;\n\tv59 = this.m_debugPackets == 0;\n\tif (v59) goto L_017B;\nL_0036:\n\tv219 = v207 >= v87._size;\n\tif (v219) goto L_013F;\n\tv293 = v87._size < v207;\n\tv294 = ~v293;\n\tv295 = v87._size - v207;\n\tv297 = v295 == 0;\n\tv302 = ~v297;\n\tv249 = v294 & v302;\n\tif (v249) goto L_0046;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0046:\n\tv344 = v87._items;\n\tv246 = v344[v207 @ X20_v5 (System.Int32)];\n\tv346 = v344[v207 @ X20_v5 (System.Int32)] == 0;\n\tif (v346) goto L_0132;\n\tv359 = ~v246.Active;\n\tif (v359) goto L_0132;\n\tTayx.Graphy.GraphyDebugger+DebugPacket::Update(v344[v207 @ X20_v5 (System.Int32)]);\n\tv414 = ~v246.canBeChecked;\n\tif (v414) goto L_0132;\n\tv264 = v246.ConditionEvaluation == 1;\n\tif (v264) goto L_0087;\n\tv477 = v246.ConditionEvaluation == 0;\n\tv415 = ~v477;\n\tif (v415) goto L_0132;\n\tv509 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>::GetEnumerator(v246.DebugConditions);\n\t*([v21 @ X29-70]) = *([v21 @ X29-90]);\n\t*([v21 @ X29-60]) = *([v21 @ X29-80]);\n\tgoto L_0079;\nL_006F:\n\t;\n\tv550 = Tayx.Graphy.GraphyDebugger::CheckIfConditionIsMet(this, *([v21 @ X29-60]));\n\tv456 = v456 + v550;\nL_0079:\n\tv556 = &v21 @ X29 - 0x70;\n\tv557 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>+Enumerator<Tayx.Graphy.GraphyDebugger+DebugCondition>::MoveNext(v556);\n\tv561 = v557 == 0;\n\tv552 = ~v561;\n\tif (v552) goto L_006F;\n\tv575 = *([v21 @ X29-98]);\n\tv198 = v198 + 1;\n\t*([v575 @ X8_v50+v198 @ X27_v7*4]) = 0x93;\n\tgoto L_00F5;\nL_0087:\n\t;\n\tv484 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>::GetEnumerator(v246.DebugConditions);\n\t*([v21 @ X29-70]) = *([v21 @ X29-90]);\n\t*([v21 @ X29-60]) = *([v21 @ X29-80]);\nL_008F:\n\tv540 = &v21 @ X29 - 0x70;\n\tv541 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>+Enumerator<Tayx.Graphy.GraphyDebugger+DebugCondition>::MoveNext(v540);\n\tv559 = v541 == 0;\n\tif (v559) goto L_00AC;\n\tv534 = Tayx.Graphy.GraphyDebugger::CheckIfConditionIsMet(this, *([v21 @ X29-60]));\n\tv536 = v534 == 0;\n\tif (v536) goto L_008F;\n\tTayx.Graphy.GraphyDebugger::ExecuteOperationsInDebugPacket(v534, v344[v207 @ X20_v5 (System.Int32)]);\n\tv571 = ~v246.ExecuteOnce;\n\tif (v571) goto L_00AC;\n\tv285 = this.m_debugPackets == 0;\n\tif (v285) goto L_00B1;\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::set_Item(this.m_debugPackets, v207, 0);\nL_00AC:\n\tv574 = *([v21 @ X29-98]);\n\tv198 = v198 + 1;\n\t*([v574 @ X8_v36+v198 @ X27_v7*4]) = 0x118;\n\tgoto L_00C7;\nL_00B1:\n\tv282 = new System.NullReferenceException();\n\tTayx.Graphy.GraphyDebugger::AddNewDebugPacket(v282, v344[v207 @ X20_v5 (System.Int32)]);\n\treturn;\n\tgoto L_00B7;\n\tgoto L_00B7;\n\tgoto L_00B7;\nL_00B7:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0181;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C7:\n\tv581 = &v21 @ X29 - 0x70;\n\tv410 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>+Enumerator<Tayx.Graphy.GraphyDebugger+DebugCondition>::Dispose(v581);\n\tv416 = v198 + 1;\n\tv586 = v416 == 0;\n\tif (v586) goto L_FFFFFFFF;\n\tv594 = *([v21 @ X29-98]);\n\tv377 = *([v594 @ X8_v40+v198 @ X27_v7*4]) != 0x118;\n\tif (v377) goto L_FFFFFFFF;\n\tv423 = 0xFFFFFFFF ^ v198;\n\tv198 = v198 + v423;\n\tgoto L_0132;\n\tgoto L_0132;\n\tgoto L_0180;\n\tgoto L_00E5;\nL_00E5:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0181;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00F5:\n\tv584 = &v21 @ X29 - 0x70;\n\tv411 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugCondition>+Enumerator<Tayx.Graphy.GraphyDebugger+DebugCondition>::Dispose(v584);\n\tv589 = v198 + 1;\n\tv591 = v589 == 0;\n\tif (v591) goto L_0111;\n\tv597 = *([v21 @ X29-98]);\n\tv608 = *([v597 @ X8_v60+v198 @ X27_v7*4]) != 0x93;\n\tif (v608) goto L_0111;\n\tv612 = 0xFFFFFFFF ^ v198;\n\tv198 = v198 + v612;\n\tgoto L_0112;\nL_0111:\n\tgoto L_0180;\nL_0112:\n\tv458 = v246.DebugConditions;\n\tv376 = v456 >= v458._size;\n\tif (v376) goto L_0124;\n\tgoto L_0132;\nL_0124:\n\tTayx.Graphy.GraphyDebugger::ExecuteOperationsInDebugPacket(v411, v344[v207 @ X20_v5 (System.Int32)]);\n\tv419 = ~v246.ExecuteOnce;\n\tif (v419) goto L_0132;\n\tSystem.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::set_Item(this.m_debugPackets, v207, 0);\nL_0132:\n\tv87 = this.m_debugPackets;\n\tv207 = v207 + 1;\n\tv427 = this.m_debugPackets == 0;\n\tv204 = ~v427;\n\tif (v204) goto L_0036;\n\tthrow System.NullReferenceException;\nL_013F:\n\tgoto L_0147;\n\tv347 = *([v338 @ X0_v5 (Il2CppClass<Tayx.Graphy.GraphyDebugger+<>c>)+E0]);\n\tv348 = v347 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_0147;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v338, v315, v306, v303, v39, v40, v41, v42, v79, v81, v45, v46, v47, v48, v49, v50);\n\tv351 = Tayx.Graphy.GraphyDebugger+<>c;\nL_0147:\n\tv129 = v354.<>9__24_0;\n\tv356 = v354.<>9__24_0 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_016C;\n\tgoto L_015A;\n\tv460 = *([v350 @ X0_v6 (Il2CppClass<Tayx.Graphy.GraphyDebugger+<>c>)+E0]);\n\tv461 = v460 == 0;\n\tv462 = ~v461;\n\tif (v462) goto L_015A;\n\tv465 = \"il2cpp_codegen_runtime_class_init\"(v350, v315, v306, v303, v39, v40, v41, v42, v79, v81, v45, v46, v47, v48, v49, v50);\n\tv475 = Tayx.Graphy.GraphyDebugger+<>c;\n\tv467 = *([v475 @ X8_v21+B8]);\nL_015A:\n\tv439 = new System.Predicate`1<Tayx.Graphy.GraphyDebugger+DebugPacket>();\n\tSystem.Predicate`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::.ctor(v439, v466.<>9, Il2CppMethodInfo);\n\tv443.<>9__24_0 = v439;\nL_016C:\n\tv125 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::RemoveAll(v87, v129);\nL_017B:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0180:\n\tv526 = new System.TypeLoadException();\nL_0181:\n\tv283 = System.Collections.Generic.List`1<Tayx.Graphy.GraphyDebugger+DebugPacket>::set_Item(v526, 0, 0);\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void CheckDebugPackets()
		{
			//IL_001a: Expected O, but got I8
			//IL_061c: Expected O, but got I
			//IL_02fa: Expected O, but got I
			//IL_0309: Expected O, but got I
			//IL_0348: Expected O, but got I
			//IL_0360: Expected O, but got I
			//IL_025c: Expected O, but got I
			//IL_05d8: Expected O, but got I
			//IL_038d: Expected O, but got I
			//IL_0294: Expected O, but got I4
			//IL_01d1: Expected O, but got I
			//IL_01f8: Expected O, but got I
			//IL_0207: Expected O, but got I
			//IL_03c9: Expected I4, but got I8
			//IL_03d7: Expected O, but got I
			//IL_03fa: Expected O, but got I
			//IL_0412: Expected O, but got I
			//IL_043f: Expected O, but got I
			//IL_047b: Expected I4, but got I8
			//IL_0489: Expected O, but got I
			object obj = obj;
			_ = 0;
			_ = 0;
			List<DebugPacket> debugPackets = m_debugPackets;
			if (m_debugPackets == null)
			{
				return;
			}
			object obj2 = 4294967295L;
			int num = 0;
			GraphyDebugger graphyDebugger = default(GraphyDebugger);
			while (num < debugPackets.Count)
			{
				bool flag = debugPackets.Count < num;
				bool flag2 = !flag;
				int num2 = debugPackets.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				DebugPacket[] items = debugPackets._items;
				DebugPacket debugPacket = items[num];
				if (items[num] != null && debugPacket.Active)
				{
					items[num].Update();
					if (debugPacket.Check)
					{
						if (debugPacket.ConditionEvaluation != ConditionEvaluation.Only_one_condition_has_to_be_met)
						{
							if (debugPacket.ConditionEvaluation == ConditionEvaluation.All_conditions_must_be_met)
							{
								List<DebugCondition>.Enumerator enumerator = debugPacket.DebugConditions.GetEnumerator();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
								_ = 0;
								int num3 = 0;
								while (true)
								{
									List<DebugCondition>.Enumerator enumerator2 = (List<DebugCondition>.Enumerator)((long)(IntPtr)obj - 112L);
									if (((List<DebugCondition>.Enumerator*)enumerator2)->MoveNext())
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
										bool flag5 = CheckIfConditionIsMet((DebugCondition)0);
										num3 += (flag5 ? 1 : 0);
										continue;
									}
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
								object obj3 = 0;
								obj2 = (long)(IntPtr)obj2 + 1L;
								_ = 147;
								List<DebugCondition>.Enumerator enumerator3 = (List<DebugCondition>.Enumerator)((long)(IntPtr)obj - 112L);
								((List<DebugCondition>.Enumerator*)enumerator3)->Dispose();
								object obj4 = (long)(IntPtr)obj2 + 1L;
								if (obj4 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
									object obj5 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ X8_v60+v198 @ X27_v7*4]");
									if ((IntPtr)0 == (IntPtr)147)
									{
										int num4 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj2);
										obj2 = (long)(IntPtr)obj2 + (long)num4;
										List<DebugCondition> debugConditions = debugPacket.DebugConditions;
										if (num3 >= debugConditions.Count)
										{
											graphyDebugger.ExecuteOperationsInDebugPacket(items[num]);
											if (debugPacket.ExecuteOnce)
											{
												m_debugPackets.set_Item(num, (DebugPacket)null);
											}
										}
										goto IL_051e;
									}
								}
								TypeLoadException ex = new TypeLoadException();
								((List<DebugPacket>)(object)ex).set_Item(0, (DebugPacket)null);
								return;
							}
						}
						else
						{
							List<DebugCondition>.Enumerator enumerator4 = debugPacket.DebugConditions.GetEnumerator();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							_ = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
							_ = 0;
							while (true)
							{
								List<DebugCondition>.Enumerator enumerator5 = (List<DebugCondition>.Enumerator)((long)(IntPtr)obj - 112L);
								if (!((List<DebugCondition>.Enumerator*)enumerator5)->MoveNext())
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
								bool flag6 = CheckIfConditionIsMet((DebugCondition)0);
								if (flag6)
								{
									((GraphyDebugger)flag6).ExecuteOperationsInDebugPacket(items[num]);
									if (!debugPacket.ExecuteOnce)
									{
										break;
									}
									if (m_debugPackets != null)
									{
										m_debugPackets.set_Item(num, (DebugPacket)null);
										break;
									}
									NullReferenceException ex2 = new NullReferenceException();
									((GraphyDebugger)(object)ex2).AddNewDebugPacket(items[num]);
									return;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
							object obj6 = 0;
							obj2 = (long)(IntPtr)obj2 + 1L;
							_ = 280;
							List<DebugCondition>.Enumerator enumerator6 = (List<DebugCondition>.Enumerator)((long)(IntPtr)obj - 112L);
							((List<DebugCondition>.Enumerator*)enumerator6)->Dispose();
							object obj7 = (long)(IntPtr)obj2 + 1L;
							if (obj7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ X8_v40+v198 @ X27_v7*4]");
								if ((IntPtr)0 == (IntPtr)280)
								{
									int num5 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj2);
									obj2 = (long)(IntPtr)obj2 + (long)num5;
								}
							}
						}
					}
				}
				goto IL_051e;
				IL_051e:
				debugPackets = m_debugPackets;
				num++;
				if (m_debugPackets == null)
				{
					throw new NullReferenceException();
				}
			}
			Predicate<DebugPacket> match = _003C_003Ec._003C_003E9__24_0;
			if (_003C_003Ec._003C_003E9__24_0 == null)
			{
				match = (_003C_003Ec._003C_003E9__24_0 = (DebugPacket packet) => packet == null);
			}
			int num6 = debugPackets.RemoveAll(match);
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xB152A8", Offset = "0xB152A8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE9780]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, debugCondition, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202254C]) = v48;\nL_0019:\n\tv49 = debugCondition >> 0x20;\n\tv50 = v49 < 4;\n\tv51 = ~v50;\n\tv52 = v49 - 4;\n\tv54 = v52 == 0;\n\tv59 = ~v54;\n\tv60 = v51 & v59;\n\tif (v60) goto L_003B;\n\tv62 = 0x1819000 + 0x2C8;\n\tv64 = *([v62 @ X9_v2 (System.Int32)+v49 @ X8_v3 (System.Int32)*4]) + v62;\n\t// 42 IndirectJump v64 @ X8_v5, v46 @ X0_v1 (Tayx.Graphy.GraphyDebugger), v46 @ X0_v1 (Tayx.Graphy.GraphyDebugger), debugCondition @ X1 (Tayx.Graphy.GraphyDebugger+DebugCondition), methodInfo @ X2 (Il2CppMethodInfo), v33 @ X3, v34 @ X4, v35 @ X5, v36 @ X6, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tX0 = X21;\n\tX1 = X20;\n\tV0 = Tayx.Graphy.GraphyDebugger::GetRequestedValueFromDebugVariable(X0, X1, X2);\n\tV1 = X19;\n\tC = V0 < V1;\n\tC = ~C;\n\tTEMP1 = V0 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V1;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX0 = N;\n\tgoto L_0096;\nL_003B:\n\tgoto L_0096;\n\tX0 = X21;\n\tX1 = X20;\n\tV0 = Tayx.Graphy.GraphyDebugger::GetRequestedValueFromDebugVariable(X0, X1, X2);\n\tV1 = X19;\n\tC = V0 < V1;\n\tC = ~C;\n\tTEMP1 = V0 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V1;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tX0 = TEMPCOND;\n\tgoto L_0096;\n\tX0 = X21;\n\tX1 = X20;\n\tV0 = Tayx.Graphy.GraphyDebugger::GetRequestedValueFromDebugVariable(X0, X1, X2);\n\tX8 = *([1EEBFB8]);\n\tV8 = V0;\n\tV9 = X19;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_005E;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005E;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005E:\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tV0 = V8;\n\tV1 = V9;\n\tX0 = 0;\n\tV9 = stack[0];\n\tV8 = stack[8];\n\t// 105 ShiftStack 64\n\tX0 = UnityEngine.Mathf::Approximately(V0, V1, X0);\n\treturn X0;\n\tX0 = X21;\n\tX1 = X20;\n\tV0 = Tayx.Graphy.GraphyDebugger::GetRequestedValueFromDebugVariable(X0, X1, X2);\n\tV1 = X19;\n\tC = V0 < V1;\n\tC = ~C;\n\tTEMP1 = V0 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V1;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tX0 = TEMPCOND;\n\tgoto L_0096;\n\tX0 = X21;\n\tX1 = X20;\n\tV0 = Tayx.Graphy.GraphyDebugger::GetRequestedValueFromDebugVariable(X0, X1, X2);\n\tV1 = X19;\n\tC = V0 < V1;\n\tC = ~C;\n\tTEMP1 = V0 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V1;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND2 = ~Z;\n\tTEMPCOND = TEMPCOND & TEMPCOND2;\n\tX0 = TEMPCOND;\nL_0096:\n\treturn 0;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CheckIfConditionIsMet(DebugCondition debugCondition)
		{
			//IL_0046: Expected I4, but got O
			//IL_0029: Expected O, but got I
			int num = (object)debugCondition >> 32;
			bool flag = num < 4;
			bool flag2 = !flag;
			int num2 = num - 4;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25268224 + 712;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X9_v2 (System.Int32)+v49 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v64 @ X8_v5 (should have been resolved before IL gen)");
			}
			return false;
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0xB158B4", Offset = "0xB158B4", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EA6E20]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, debugVariable, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202254D]) = v43;\nL_0016:\n\tv44 = debugVariable < 7;\n\tv45 = ~v44;\n\tv46 = debugVariable - 7;\n\tv48 = v46 == 0;\n\tv54 = ~v48;\n\tv55 = v45 & v54;\n\tif (v55) goto L_00C6;\n\tv58 = 0x1819000 + 0x2DC;\n\tv60 = *([v58 @ X9_v2 (System.Int32)+debugVariable @ X1 (Tayx.Graphy.GraphyDebugger+DebugVariable)*4]) + v58;\n\t// 40 IndirectJump v60 @ X8_v5, v41 @ X0_v1 (Tayx.Graphy.GraphyDebugger), v41 @ X0_v1 (Tayx.Graphy.GraphyDebugger), debugVariable @ X1 (Tayx.Graphy.GraphyDebugger+DebugVariable), methodInfo @ X2 (Il2CppMethodInfo), v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+28]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0036;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0036;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0036:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+28]);\n\tif (TEMP) goto L_00C7;\n\tV8 = *([X8+18]);\n\tgoto L_00C6;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+20]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_004F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004F:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_00C7;\n\tV8 = *([X8+28]);\n\tgoto L_00C6;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+20]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0068;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0068;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0068:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_00C7;\n\tV8 = *([X8+30]);\n\tgoto L_00C6;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+20]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0081;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0081;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0081:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_00C7;\n\tV8 = *([X8+34]);\n\tgoto L_00C6;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+20]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_009A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009A:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+20]);\n\tif (TEMP) goto L_00C7;\n\tV8 = *([X8+2C]);\n\tgoto L_00C6;\n\tX8 = *([1EAB010]);\n\tX20 = *([X19+30]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00B3;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B3;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00B3:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = UnityEngine.Object::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X19+30]);\n\tif (TEMP) goto L_00C7;\n\tV8 = *([X8+48]);\nL_00C6:\n\treturn 0;\nL_00C7:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn V0;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float GetRequestedValueFromDebugVariable(DebugVariable debugVariable)
		{
			//IL_0029: Expected O, but got I
			while (true)
			{
				bool flag = debugVariable < DebugVariable.Audio_DB;
				bool flag2 = !flag;
				int num = (int)(debugVariable - 7);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25268224 + 732;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X9_v2 (System.Int32)+debugVariable @ X1 (Tayx.Graphy.GraphyDebugger+DebugVariable)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v60 @ X8_v5 (should have been resolved before IL gen)");
			}
			return 0f;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xB153E8", Offset = "0xB153E8", Length = "0x4CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EF9490]);\n\tv23 = *([v22 @ X8_v92]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, debugPacket, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([202254E]) = v42;\nL_0017:\n\tv45 = 0;\n\tv46 = debugPacket == 0;\n\tif (v46) goto L_01CB;\n\tv48 = ~debugPacket.DebugBreak;\n\tif (v48) goto L_002C;\n\tgoto L_002A;\n\tv124 = *([v108 @ X0_v94+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_002A;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v108, debugPacket, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tUnityEngine.Debug::Break();\nL_002C:\n\tv119 = debugPacket.Message;\n\tv123 = System.String::op_Inequality(debugPacket.Message, \"\");\n\tv130 = v123 == 0;\n\tif (v130) goto L_00F1;\n\t// 56 NewArr v135 @ X0_v60 (System.Object[]), typeof(System.Object[]), 4\n\tv251 = \"[Graphy] (\" == 0;\n\tif (v251) goto L_0047;\n\t// 67 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), \"[Graphy] (\"\nL_0047:\n\tv302 = v135.Length == 0;\n\tif (v302) goto L_01A5;\n\tv135[0] = \"[Graphy] (\";\n\tgoto L_0058;\n\tv455 = *([v396 @ X0_v63+E0]);\n\tv456 = v455 == 0;\n\tv457 = ~v456;\n\tif (v457) goto L_0058;\n\tv459 = \"il2cpp_codegen_runtime_class_init\"(v396, v296, v121, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0058:\n\tv463 = System.DateTime::get_Now();\n\t// 93 Box v119 @ X0_v4 (System.String), typeof(System.DateTime), &v463 @ X0_v66 (System.DateTime)\n\tv522 = v119 == 0;\n\tif (v522) goto L_0067;\n\t// 100 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), v119 @ X0_v4 (System.String)\nL_0067:\n\tv387 = v135.Length;\n\tv535 = v135.Length < 1;\n\tv347 = ~v535;\n\tv342 = v135.Length - 1;\n\tv332 = v342 == 0;\n\tv536 = ~v347;\n\tv307 = v536 | v332;\n\tif (v307) goto L_01A5;\n\tv135[1] = v119;\n\tv555 = \"): \" == 0;\n\tif (v555) goto L_0080;\n\t// 124 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), \"): \"\n\tv387 = v135.Length;\nL_0080:\n\tv568 = v387 < 2;\n\tv349 = ~v568;\n\tv344 = v387 - 2;\n\tv334 = v344 == 0;\n\tv569 = ~v349;\n\tv309 = v569 | v334;\n\tif (v309) goto L_01A5;\n\tv135[2] = \"): \";\n\tv574 = debugPacket.Message == 0;\n\tif (v574) goto L_0098;\n\t// 148 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), debugPacket.Message (System.String)\n\tv387 = v135.Length;\nL_0098:\n\tv582 = v387 < 3;\n\tv172 = ~v582;\n\tv168 = v387 - 3;\n\tv160 = v168 == 0;\n\tv583 = ~v172;\n\tv139 = v583 | v160;\n\tif (v139) goto L_01A5;\n\tv135[3] = debugPacket.Message;\n\tv119 = System.String::Concat(v135);\n\tv189 = debugPacket.MessageType == 0;\n\tif (v189) goto L_00D7;\n\tv158 = debugPacket.MessageType == 1;\n\tif (v158) goto L_00E7;\n\tv140 = debugPacket.MessageType != 2;\n\tif (v140) goto L_00F1;\n\tgoto L_00CF;\n\tv624 = *([v615 @ X0_v83+E0]);\n\tv625 = v624 == 0;\n\tv626 = ~v625;\n\tif (v626) goto L_00CF;\n\tv628 = \"il2cpp_codegen_runtime_class_init\"(v615, v179, v121, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00CF:\n\tUnityEngine.Debug::LogError(v119);\n\tgoto L_00F1;\nL_00D7:\n\tgoto L_00DF;\n\tv606 = *([v595 @ X0_v75+E0]);\n\tv607 = v606 == 0;\n\tv608 = ~v607;\n\tif (v608) goto L_00DF;\n\tv610 = \"il2cpp_codegen_runtime_class_init\"(v595, v179, v121, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00DF:\n\tUnityEngine.Debug::Log(v119);\n\tgoto L_00F1;\nL_00E7:\n\tgoto L_00EF;\n\tv619 = *([v602 @ X0_v79+E0]);\n\tv620 = v619 == 0;\n\tv621 = ~v620;\n\tif (v621) goto L_00EF;\n\tv623 = \"il2cpp_codegen_runtime_class_init\"(v602, v179, v121, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00EF:\n\tUnityEngine.Debug::LogWarning(v119);\nL_00F1:\n\tv200 = ~debugPacket.TakeScreenshot;\n\tif (v200) goto L_0187;\n\t// 247 NewArr v207 @ X0_v34 (System.Object[]), typeof(System.Object[]), 4\n\tv392 = debugPacket.ScreenshotFileName == 0;\n\tif (v392) goto L_0104;\n\t// 257 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), debugPacket.ScreenshotFileName (System.String)\nL_0104:\n\tv388 = v207.Length;\n\tv376 = v207.Length == 0;\n\tif (v376) goto L_01A5;\n\tv207[0] = debugPacket.ScreenshotFileName;\n\tv503 = \"_\" == 0;\n\tif (v503) goto L_0113;\n\t// 271 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), \"_\"\n\tv388 = v207.Length;\nL_0113:\n\tv511 = v388 < 1;\n\tv350 = ~v511;\n\tv345 = v388 - 1;\n\tv335 = v345 == 0;\n\tv512 = ~v350;\n\tv310 = v512 | v335;\n\tif (v310) goto L_01A5;\n\tv207[1] = \"_\";\n\tgoto L_012E;\n\tv539 = *([v527 @ X0_v38+E0]);\n\tv540 = v539 == 0;\n\tv541 = ~v540;\n\tif (v541) goto L_012E;\n\tv543 = \"il2cpp_codegen_runtime_class_init\"(v527, v363, v121, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_012E:\n\tv547 = System.DateTime::get_Now();\n\t// 307 Box v119 @ X0_v4 (System.String), typeof(System.DateTime), &v547 @ X0_v41 (System.DateTime)\n\tv572 = v119 == 0;\n\tif (v572) goto L_013D;\n\t// 314 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), v119 @ X0_v4 (System.String)\nL_013D:\n\tv389 = v207.Length;\n\tv578 = v207.Length < 2;\n\tv348 = ~v578;\n\tv343 = v207.Length - 2;\n\tv333 = v343 == 0;\n\tv579 = ~v348;\n\tv308 = v579 | v333;\n\tif (v308) goto L_01A5;\n\tv207[2] = v119;\n\tv586 = \".png\" == 0;\n\tif (v586) goto L_0156;\n\t// 338 IsInst v119 @ X0_v4 (System.String), typeof(System.Object), \".png\"\n\tv389 = v207.Length;\nL_0156:\n\tv589 = v389 < 3;\n\tv229 = ~v589;\n\tv227 = v389 - 3;\n\tv223 = v227 == 0;\n\tv590 = ~v229;\n\tv213 = v590 | v223;\n\tif (v213) goto L_01A5;\n\tv207[3] = \".png\";\n\tv119 = System.String::Concat(v207);\n\tv119 = System.String::Replace(v119, \"/\", \"-\");\n\tv119 = System.String::Replace(v119, \" \", \"_\");\n\tv119 = System.String::Replace(v119, \":\", \"-\");\n\tUnityEngine.ScreenCapture::CaptureScreenshot(v119);\nL_0187:\n\tUnityEngine.Events.UnityEvent::Invoke(debugPacket.UnityEvents);\n\tv411 = System.Collections.Generic.List`1<System.Action>::GetEnumerator(debugPacket.Callbacks);\nL_0194:\n\tv521 = System.Collections.Generic.List`1<System.Action>+Enumerator<System.Action>::MoveNext(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Action>+Enumerator<System.Action>));\n\tv532 = v521 == 0;\n\tif (v532) goto L_01A2;\n\tgoto L_0194;\n\tSystem.Action::Invoke(0);\n\tgoto L_0194;\nL_01A2:\n\tv119 = System.Collections.Generic.List`1<System.Action>+Enumerator<System.Action>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Action>+Enumerator<System.Action>));\n\tgoto L_01C3;\n\tv292 = new System.NullReferenceException();\nL_01A5:\n\tv391 = new System.IndexOutOfRangeException();\n\tgoto L_01AA;\n\tv454 = new System.ArrayTypeMismatchException();\nL_01AA:\n\tv500 = new System.TypeLoadException();\n\tgoto L_01B6;\nL_01B6:\n\tgoto L_01CC;\n\tv119 = 0x6D2BC0(v500, 0, 0, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv119 = 0x6D2490(v119, 0, 0, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv119 = System.Collections.Generic.List`1<System.Action>+Enumerator<System.Action>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<System.Action>+Enumerator<System.Action>));\n\tv575 = *([v119 @ X0_v4 (System.String)]) == 0;\n\tv561 = ~v575;\n\tif (v561) goto L_01CE;\nL_01C3:\n\tdebugPacket.canBeChecked = 0x100;\nL_01CB:\n\treturn;\nL_01CC:\n\tv119 = 0x6D2380(v500, 0, 0, v303, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_01CE:\n\tgoto L_01AA;\n\treturn;\n// 274 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ExecuteOperationsInDebugPacket(DebugPacket debugPacket)
		{
			//IL_0392: Expected O, but got I4
			//IL_07be: Expected O, but got I
			//IL_0142: Expected O, but got I4
			//IL_016e: Expected O, but got I4
			//IL_040b: Expected O, but got I4
			//IL_06f2: Expected O, but got I
			//IL_047c: Expected O, but got I4
			//IL_04a8: Expected O, but got I4
			//IL_01f8: Expected O, but got I4
			//IL_0758: Expected O, but got I
			//IL_0824: Expected O, but got I
			//IL_0253: Expected O, but got I4
			//IL_0532: Expected O, but got I4
			List<Action>.Enumerator enumerator = default(List<Action>.Enumerator);
			if (debugPacket == null)
			{
				return;
			}
			if (debugPacket.DebugBreak)
			{
				Debug.Break();
			}
			string message = debugPacket.Message;
			if (!(debugPacket.Message != ""))
			{
				goto IL_031e;
			}
			object[] array = new object[4];
			if ("[Graphy] (" != null)
			{
				message = (string)("[Graphy] (" as object);
			}
			object obj4 = default(object);
			object obj3;
			if (array.Length != 0)
			{
				array[0] = "[Graphy] (";
				DateTime now = DateTime.Now;
				message = (string)(object)now;
				if (message != null)
				{
					message = (string)(message as object);
				}
				object obj = array.Length;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj2 = array.Length - 1;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				bool flag5 = flag4 || flag3;
				obj3 = obj4;
				if (!flag5)
				{
					array[1] = message;
					if ("): " != null)
					{
						message = (string)("): " as object);
						obj = array.Length;
					}
					bool flag6 = (long)(IntPtr)obj < 2L;
					bool flag7 = !flag6;
					object obj5 = (long)(IntPtr)obj - 2L;
					bool flag8 = obj5 == null;
					bool flag9 = !flag7;
					bool flag10 = flag9 || flag8;
					obj3 = obj4;
					if (!flag10)
					{
						array[2] = "): ";
						if (debugPacket.Message != null)
						{
							message = (string)(debugPacket.Message as object);
							obj = array.Length;
						}
						bool flag11 = (long)(IntPtr)obj < 3L;
						bool flag12 = !flag11;
						object obj6 = (long)(IntPtr)obj - 3L;
						bool flag13 = obj6 == null;
						bool flag14 = !flag12;
						bool flag15 = flag14 || flag13;
						obj3 = obj4;
						if (!flag15)
						{
							array[3] = debugPacket.Message;
							message = string.Concat(array);
							if (debugPacket.MessageType != MessageType.Log)
							{
								if (debugPacket.MessageType != MessageType.Warning)
								{
									if (debugPacket.MessageType == MessageType.Error)
									{
										Debug.LogError(message);
									}
								}
								else
								{
									Debug.LogWarning(message);
								}
							}
							else
							{
								Debug.Log(message);
							}
							goto IL_031e;
						}
					}
				}
			}
			goto IL_0601;
			IL_0601:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			while (true)
			{
				TypeLoadException ex2 = new TypeLoadException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			IL_031e:
			if (!debugPacket.TakeScreenshot)
			{
				goto IL_05b9;
			}
			object[] array2 = new object[4];
			if (debugPacket.ScreenshotFileName != null)
			{
				message = (string)(debugPacket.ScreenshotFileName as object);
			}
			object obj7 = array2.Length;
			bool flag16 = array2.Length == 0;
			obj3 = obj4;
			if (!flag16)
			{
				array2[0] = debugPacket.ScreenshotFileName;
				if ("_" != null)
				{
					message = (string)("_" as object);
					obj7 = array2.Length;
				}
				bool flag17 = (long)(IntPtr)obj7 < 1L;
				bool flag18 = !flag17;
				object obj8 = (long)(IntPtr)obj7 - 1L;
				bool flag19 = obj8 == null;
				bool flag20 = !flag18;
				bool flag21 = flag20 || flag19;
				obj3 = obj4;
				if (!flag21)
				{
					array2[1] = "_";
					DateTime now2 = DateTime.Now;
					message = (string)(object)now2;
					if (message != null)
					{
						message = (string)(message as object);
					}
					object obj9 = array2.Length;
					bool flag22 = array2.Length < 2;
					bool flag23 = !flag22;
					object obj10 = array2.Length - 2;
					bool flag24 = obj10 == null;
					bool flag25 = !flag23;
					bool flag26 = flag25 || flag24;
					obj3 = obj4;
					if (!flag26)
					{
						array2[2] = message;
						if (".png" != null)
						{
							message = (string)(".png" as object);
							obj9 = array2.Length;
						}
						bool flag27 = (long)(IntPtr)obj9 < 3L;
						bool flag28 = !flag27;
						object obj11 = (long)(IntPtr)obj9 - 3L;
						bool flag29 = obj11 == null;
						bool flag30 = !flag28;
						bool flag31 = flag30 || flag29;
						obj3 = obj4;
						if (!flag31)
						{
							array2[3] = ".png";
							message = string.Concat(array2);
							message = message.Replace("/", "-");
							message = message.Replace(" ", "_");
							message = message.Replace(":", "-");
							ScreenCapture.CaptureScreenshot(message);
							goto IL_05b9;
						}
					}
				}
			}
			goto IL_0601;
			IL_05b9:
			debugPacket.UnityEvents.Invoke();
			List<Action>.Enumerator enumerator2 = debugPacket.Callbacks.GetEnumerator();
			while (enumerator.MoveNext())
			{
			}
			enumerator.Dispose();
			debugPacket.canBeChecked = false;
			debugPacket.executed = true;
		}
	}
}
