using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x2000014")]
	public class NotCondition : ReactiveCondition
	{
		[SerializeReference]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x20")]
		private ReactiveCondition m_condition;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x28")]
		private bool _isInitialized;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x29")]
		private bool _conditionCache;

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x81AEB24", Offset = "0x81AEB24", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv58 = Unco.GameConditions.Implementations.NotCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v91;\n\tv84 = this.OnConditionChanged == 0;\n\tif (v84) goto L_0045;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\tgoto L_005B;\nL_0061:\n\tv145 = 0x220BDA0(v120, v155, v150, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv131 = v145 == v150;\n\tv150 = v145;\n\tif (v131) goto L_008B;\nL_0070:\n\tv155 = System.Delegate::Combine(v150, v100);\n\tv147 = v155 == 0;\n\tif (v147) goto L_0061;\n\tv204 = *([v155 @ X0_v12 (System.Delegate)]) == System.Action;\n\tif (v204) goto L_0061;\n\tthrow System.InvalidCastException;\nL_008B:\n\treturn;\nL_001A:\n\tthis._isInitialized = 1;\n\tv50 = this._isInit == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002E;\nL_0045:\n\tthis._conditionCache = v91;\n\tv98 = this.m_condition;\n\tv100 = new System.Action();\n\tSystem.Action::.ctor(v100, this, Il2CppMethodInfo);\nL_005B:\n\tv120 = this.m_condition + 0x18;\n\tv150 = v98.OnConditionChanged;\n\tgoto L_0070;\nL_002E:\n\tv91 = Unco.GameConditions.Implementations.NotCondition::InnerIsConditionMet(this);\n\tv78 = this._lastState == v91;\n\tif (v78) goto L_0045;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotCondition::Initialize");
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x81AEC94", Offset = "0x81AEC94", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.m_condition;\n\tv15 = v10._isInit == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0019;\n\tv37 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(v10);\n\tv10._isInit = 1;\n\tv10._lastState = v64;\n\tv60 = v10.OnConditionChanged == 0;\n\tif (v60) goto L_0030;\n\tSystem.Action::Invoke(v10.OnConditionChanged);\nL_0019:\n\tv64 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(v10);\n\tv54 = v10._lastState == v64;\n\tif (v54) goto L_0030;\nL_0030:\n\treturnVal2 = v64 ^ 1;\n\treturn returnVal2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal override bool InnerIsConditionMet()
		{
			ReactiveCondition condition = m_condition;
			if (!condition._isInit)
			{
				condition.Subscribe();
				condition._isInit = true;
			}
			bool flag = condition.InnerIsConditionMet();
			if (condition._lastState != (flag ? 1 : 0))
			{
				condition._lastState = (flag ? 1 : 0);
				if (condition.OnConditionChanged != null)
				{
					condition.OnConditionChanged();
				}
			}
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x81AED20", Offset = "0x81AED20", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected internal override void Subscribe()
		{
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x81AED24", Offset = "0x81AED24", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_0032;\nL_0038:\n\tv107 = 0x220BDA0(v73, v117, v110, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv91 = v107 == v110;\n\tv110 = v107;\n\tif (v91) goto L_0059;\nL_0047:\n\tv117 = System.Delegate::Remove(v110, v53);\n\tv109 = v117 == 0;\n\tif (v109) goto L_0038;\n\tv166 = *([v117 @ X0_v8 (System.Delegate)]) == System.Action;\n\tif (v166) goto L_0038;\n\tthrow System.InvalidCastException;\nL_0059:\n\tthis._isInitialized = 0;\n\treturn;\nL_001D:\n\tv51 = this.m_condition;\n\tv53 = new System.Action();\n\tSystem.Action::.ctor(v53, this, Il2CppMethodInfo);\nL_0032:\n\tv73 = this.m_condition + 0x18;\n\tv110 = v51.OnConditionChanged;\n\tgoto L_0047;\n")]
		protected override void InnerDispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotCondition::InnerDispose");
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x81AEE2C", Offset = "0x81AEE2C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._isInit == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0017;\n\tv20 = Unco.GameConditions.Implementations.NotCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v64;\n\tv58 = this.OnConditionChanged == 0;\n\tif (v58) goto L_0033;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\tv84 = this._conditionCache ^ 1;\n\tthis._conditionCache = v84;\n\tv87 = this._isInit == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_004B;\n\tv124 = Unco.GameConditions.Implementations.NotCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v106;\n\tv112 = this.OnConditionChanged == 0;\n\tif (v112) goto L_0069;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\treturn;\nL_0069:\n\treturn;\nL_0017:\n\tv64 = Unco.GameConditions.Implementations.NotCondition::InnerIsConditionMet(this);\n\tv52 = this._lastState == v64;\n\tif (v52) goto L_0033;\nL_0033:\n\tv77 = this._conditionCache == v64;\n\tif (v77) goto L_0069;\nL_004B:\n\tv106 = Unco.GameConditions.Implementations.NotCondition::InnerIsConditionMet(this);\n\tv98 = this._lastState == v106;\n\tif (v98) goto L_0069;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CheckConditionState()
		{
			if (!_isInit)
			{
				Subscribe();
				_isInit = true;
			}
			bool flag = InnerIsConditionMet();
			if (_lastState != (flag ? 1 : 0))
			{
				_lastState = (flag ? 1 : 0);
				if (OnConditionChanged != null)
				{
					OnConditionChanged();
				}
			}
			if (_conditionCache == flag)
			{
				return;
			}
			int conditionCache = (_conditionCache ? 1 : 0) ^ 1;
			_conditionCache = (byte)conditionCache != 0;
			if (!_isInit)
			{
				Subscribe();
				_isInit = true;
			}
			bool flag2 = InnerIsConditionMet();
			if (_lastState != (flag2 ? 1 : 0))
			{
				_lastState = (flag2 ? 1 : 0);
				if (OnConditionChanged != null)
				{
					OnConditionChanged();
				}
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x81AD184", Offset = "0x81AD184", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NotCondition()
		{
			_lastState = -1;
		}
	}
}
