using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Systems.FlowSystem.Scripts.Core
{
	[Token(Token = "0x2000007")]
	public class FlowManager
	{
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x10")]
		public Action<FlowId> OnFlowCompleted;

		[Inject(false)]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x18")]
		private FlowStorageData _flowData;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x20")]
		private bool _killFlowPref;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x28")]
		private List<FlowStep> _flowSteps;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x30")]
		private List<string> _activeFlows;

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x81AB9D0", Offset = "0x81AB9D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._killFlowPref;\n")]
		public bool IsFlowKilled()
		{
			return _killFlowPref;
		}

		[Inject(false)]
		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81AB9D8", Offset = "0x81AB9D8", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv52.instancer = instancer;\n\tv111 = this._flowData;\n\tv90 = v111.KillFlow == 0;\n\tv75 = ~v90;\n\tthis._killFlowPref = v75;\n\tv164 = System.Linq.Enumerable::ToList(flowDatabase.m_FlowSteps);\n\tthis._flowSteps = v164;\n\tv103 = new System.Action`1<Systems.FlowSystem.Scripts.Core.FlowStep>();\n\tSystem.Action`1<Systems.FlowSystem.Scripts.Core.FlowStep>::.ctor(v103, v52, Il2CppMethodInfo);\n\tSystem.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>::ForEach(this._flowSteps, v103);\n\tSystems.FlowSystem.Scripts.Core.FlowManager::CheckFlows(this);\n\treturn;\nL_0027:\n\tv52 = new Systems.FlowSystem.Scripts.Core.FlowManager+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v52);\n")]
		public void Init(Instancer instancer, FlowDatabase flowDatabase)
		{
			FlowStorageData flowData = _flowData;
			bool flag = flowData.KillFlow == 0;
			bool killFlowPref = !flag;
			_killFlowPref = killFlowPref;
			List<object> flowSteps = ((IEnumerable<object>)flowDatabase.m_FlowSteps).ToList();
			_flowSteps = (List<FlowStep>)(object)flowSteps;
			Action<FlowStep> action = delegate
			{
				FlowStep instance = default(FlowStep);
				FlowStep flowStep2 = instancer.InjectInstance(instance);
			};
			_flowSteps.ForEach(action);
			CheckFlows();
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81ABB2C", Offset = "0x81ABB2C", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv64 = System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>::GetEnumerator(this._flowSteps);\n\tv94 = v64._list;\n\tv84 = v64.Current;\n\tgoto L_0041;\nL_0039:\n\tv84.FlowCompleted = 0;\n\tv124 = Systems.FlowSystem.Scripts.Core.FlowStep::InitFlow(v64.Current);\n\tv164 = v64.Current == 0;\n\tif (v164) goto L_006F;\n\tv170 = *([v84 @ stack_-48_v4 (Systems.FlowSystem.Scripts.Core.FlowStep)]);\n\tv125 = Systems.FlowSystem.Scripts.Core.FlowStep::IsFlowCompleted(v64.Current);\n\tv128 = v125 == 0;\n\tif (v128) goto L_0039;\n\tv84.FlowCompleted = 1;\n\tv132 = v84._manager;\n\tv129 = v132.OnFlowCompleted == 0;\n\tif (v129) goto L_0041;\n\tv259 = Systems.FlowSystem.Scripts.Core.FlowStep::get_FlowId(v64.Current);\n\tSystem.Action`1<Systems.FlowSystem.Scripts.Core.FlowId>::Invoke(v132.OnFlowCompleted, v259);\n\tgoto L_0041;\nL_0064:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-58_v4 (System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>));\nL_006E:\n\treturn;\nL_006F:\n\tv173 = new System.NullReferenceException();\n\tgoto L_0072;\nL_0072:\n\t// 114 Interrupt\n\tv79 = 0;\nL_0082:\n\tv147 = *([v170 @ X8_v10 (Il2CppClass<Systems.FlowSystem.Scripts.Core.FlowStep>)+1A0]) != 1;\n\tif (v147) goto L_0091;\n\tv150 = 0x8BF5BC4(v107, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv167 = 0x8BF5BF4(v150, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v94 @ stack_-58_v4 (System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>));\n\tv158 = *([v150 @ X0_v11]) == 0;\n\tif (v158) goto L_006E;\n\tv156 = new System.OutOfMemoryException();\n\tv79 = *([v150 @ X0_v11]);\n\tv107 = v156;\nL_0091:\n\tv163 = 0x3966E50(&v79 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv169 = 0x8BF0368(v107, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv220 = 0x7C03E68(v169, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001F:\n\tv94 = 0;\n\tv51 = this._flowSteps == 0;\n\tif (v51) goto L_0073;\nL_0041:\n\tv137 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v94 @ stack_-58_v4 (System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>));\n\tv149 = v137 == 0;\n\tif (v149) goto L_0064;\nL_0073:\n\tv107 = new System.NullReferenceException();\n\tgoto L_0082;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void CheckFlows()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FlowManager::CheckFlows");
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81ABD3C", Offset = "0x81ABD3C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._flowData;\n\tv0.KillFlow = 1;\n\tthis._killFlowPref = 1;\n\treturn;\n")]
		public void Dev_KillFlow()
		{
			FlowStorageData flowData = _flowData;
			flowData.KillFlow = 1;
			_killFlowPref = true;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81ABD60", Offset = "0x81ABD60", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv47.flowId = flowId;\n\tv65 = new System.Predicate`1<Systems.FlowSystem.Scripts.Core.FlowStep>();\n\tSystem.Predicate`1<Systems.FlowSystem.Scripts.Core.FlowStep>::.ctor(v65, v47, Il2CppMethodInfo);\n\treturnVal2 = System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>::Find(this._flowSteps, v65);\n\treturn returnVal2;\nL_0021:\n\tv47 = new Systems.FlowSystem.Scripts.Core.FlowManager+<>c__DisplayClass9_0();\n\tSystem.Object::.ctor(v47);\n")]
		public FlowStep GetFlowStep(FlowId flowId)
		{
			Predicate<FlowStep> match = delegate(FlowStep x)
			{
				FlowId flowId2 = x.FlowId;
				int num = flowId2 - flowId;
				return num == 0;
			};
			return _flowSteps.Find(match);
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81ABE44", Offset = "0x81ABE44", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv51.flowId = flowId;\n\tv66 = this._killFlowPref == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0060;\n\tv87 = new System.Predicate`1<Systems.FlowSystem.Scripts.Core.FlowStep>();\n\tSystem.Predicate`1<Systems.FlowSystem.Scripts.Core.FlowStep>::.ctor(v87, v51, Il2CppMethodInfo);\n\tv173 = System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>::Find(this._flowSteps, v87);\n\tgoto L_0051;\nL_0051:\n\tv121 = UnityEngine.Object::op_Equality(v173, 0);\n\tv124 = v121 == 0;\n\tif (v124) goto L_006E;\nL_0060:\n\treturn 1;\nL_006E:\n\tv88 = new System.Predicate`1<Systems.FlowSystem.Scripts.Core.FlowStep>();\n\tSystem.Predicate`1<Systems.FlowSystem.Scripts.Core.FlowStep>::.ctor(v88, v51, Il2CppMethodInfo);\n\tv89 = System.Collections.Generic.List`1<Systems.FlowSystem.Scripts.Core.FlowStep>::Find(this._flowSteps, v88);\n\treturn v89.FlowCompleted;\nL_0029:\n\tv51 = new Systems.FlowSystem.Scripts.Core.FlowManager+<>c__DisplayClass10_0();\n\tSystem.Object::.ctor(v51);\n")]
		public bool IsFlowCompleted(FlowId flowId)
		{
			if (!_killFlowPref)
			{
				Predicate<FlowStep> match = delegate(FlowStep x)
				{
					FlowId flowId2 = x.FlowId;
					int num = flowId2 - flowId;
					return num == 0;
				};
				UnityEngine.Object obj = _flowSteps.Find(match);
				if (!(obj == null))
				{
					Predicate<FlowStep> match2 = delegate(FlowStep x)
					{
						FlowId flowId2 = x.FlowId;
						int num = flowId2 - flowId;
						return num == 0;
					};
					FlowStep flowStep = _flowSteps.Find(match2);
					return flowStep.FlowCompleted;
				}
			}
			return true;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81ABFFC", Offset = "0x81ABFFC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv44 = v38.Count < 0;\n\tv45 = v38.Count == 0;\n\tv47 = v38.Count ^ v38.Count;\n\tv48 = v38.Count & v47;\n\tv49 = v48 < 0;\n\tv50 = v44 == v49;\n\tv51 = ~v45;\n\tv52 = v50 & v51;\n\treturn v52;\nL_0012:\n\tv38 = this._activeFlows;\n")]
		public bool HasAnyFlowRunning()
		{
			List<string> activeFlows = _activeFlows;
			bool flag = activeFlows.Count < 0;
			bool flag2 = activeFlows.Count == 0;
			int num = activeFlows.Count ^ activeFlows.Count;
			int num2 = activeFlows.Count & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x81AC050", Offset = "0x81AC050", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_0047;\nL_0047:\n\tSystem.Collections.Generic.List`1<System.String>::Add(v46, v40);\n\treturn;\nL_0016:\n\tv46 = this._activeFlows;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RegisterActiveFlow(string key)
		{
			List<string> activeFlows = _activeFlows;
			string item = default(string);
			activeFlows.Add(item);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81AC104", Offset = "0x81AC104", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv57 = System.Collections.Generic.List`1<System.String>::Remove(this._activeFlows, v40);\n\treturn;\n")]
		public void UnregisterActiveFlow(string key)
		{
			string item = default(string);
			bool flag = _activeFlows.Remove(item);
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x81AC168", Offset = "0x81AC168", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v48);\n\tthis._activeFlows = v48;\n")]
		public FlowManager()
		{
			List<string> activeFlows = new List<string>();
			_activeFlows = activeFlows;
		}
	}
}
