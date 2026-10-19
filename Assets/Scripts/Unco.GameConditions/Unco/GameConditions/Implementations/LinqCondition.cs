using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x2000013")]
	public abstract class LinqCondition : ReactiveCondition, IDisposable
	{
		[SerializeReference]
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x20")]
		private ReactiveCondition[] m_conditions;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x28")]
		private bool _conditionCache;

		[Token(Token = "0x600002C")]
		protected abstract bool IsEnumerableMet(IEnumerable<ReactiveCondition> conditions);

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x81AE658", Offset = "0x81AE658", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.GameConditions.Implementations.LinqCondition::IsEnumerableMet(this, this.m_conditions);\n\treturn this;\n")]
		protected internal override bool InnerIsConditionMet()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinqCondition::InnerIsConditionMet");
			return default;
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x81AE668", Offset = "0x81AE668", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv70 = v55.Length < 1;\n\tif (v70) goto L_0089;\n\tv93 = 0;\n\tgoto L_0042;\nL_0035:\n\tv93 = v93 + 1;\n\tv155 = v93 >= v55.Length;\n\tif (v155) goto L_0089;\nL_0042:\n\tv85 = v55[v93 @ X25_v5 (System.Int32)];\n\tv122 = new System.Action();\n\tSystem.Action::.ctor(v122, this, Il2CppMethodInfo);\n\tgoto L_0055;\nL_005B:\n\tv182 = 0x220BDA0(v148, v271, v137, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv259 = v182 == v137;\n\tv137 = v182;\n\tif (v259) goto L_0035;\nL_006A:\n\tv271 = System.Delegate::Combine(v137, v122);\n\tv184 = v271 == 0;\n\tif (v184) goto L_005B;\n\tv169 = *([v271 @ X0_v11 (System.Delegate)]) == System.Action;\n\tif (v169) goto L_005B;\n\tthrow System.InvalidCastException;\nL_0089:\n\treturn;\nL_001D:\n\tv55 = this.m_conditions;\nL_0055:\n\tv148 = v55[v93 @ X25_v5 (System.Int32)] + 0x18;\n\tv137 = v85.OnConditionChanged;\n\tgoto L_006A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal override void Subscribe()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinqCondition::Subscribe");
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x81AE84C", Offset = "0x81AE84C", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv70 = v55.Length < 1;\n\tif (v70) goto L_0089;\n\tv93 = 0;\n\tgoto L_0042;\nL_0035:\n\tv93 = v93 + 1;\n\tv155 = v93 >= v55.Length;\n\tif (v155) goto L_0089;\nL_0042:\n\tv85 = v55[v93 @ X25_v5 (System.Int32)];\n\tv122 = new System.Action();\n\tSystem.Action::.ctor(v122, this, Il2CppMethodInfo);\n\tgoto L_0055;\nL_005B:\n\tv182 = 0x220BDA0(v148, v271, v137, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv259 = v182 == v137;\n\tv137 = v182;\n\tif (v259) goto L_0035;\nL_006A:\n\tv271 = System.Delegate::Remove(v137, v122);\n\tv184 = v271 == 0;\n\tif (v184) goto L_005B;\n\tv169 = *([v271 @ X0_v11 (System.Delegate)]) == System.Action;\n\tif (v169) goto L_005B;\n\tthrow System.InvalidCastException;\nL_0089:\n\treturn;\nL_001D:\n\tv55 = this.m_conditions;\nL_0055:\n\tv148 = v55[v93 @ X25_v5 (System.Int32)] + 0x18;\n\tv137 = v85.OnConditionChanged;\n\tgoto L_006A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void InnerDispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinqCondition::InnerDispose");
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x81AEA30", Offset = "0x81AEA30", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._isInit == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0017;\n\tv20 = Unco.GameConditions.Implementations.LinqCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v64;\n\tv58 = this.OnConditionChanged == 0;\n\tif (v58) goto L_0033;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\tv84 = this._conditionCache ^ 1;\n\tthis._conditionCache = v84;\n\tv87 = this._isInit == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_004B;\n\tv124 = Unco.GameConditions.Implementations.LinqCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v106;\n\tv112 = this.OnConditionChanged == 0;\n\tif (v112) goto L_0069;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\treturn;\nL_0069:\n\treturn;\nL_0017:\n\tv64 = Unco.GameConditions.Implementations.LinqCondition::InnerIsConditionMet(this);\n\tv52 = this._lastState == v64;\n\tif (v52) goto L_0033;\nL_0033:\n\tv77 = this._conditionCache == v64;\n\tif (v77) goto L_0069;\nL_004B:\n\tv106 = Unco.GameConditions.Implementations.LinqCondition::InnerIsConditionMet(this);\n\tv98 = this._lastState == v106;\n\tif (v98) goto L_0069;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81AE114", Offset = "0x81AE114", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal LinqCondition()
		{
			_lastState = -1;
		}
	}
}
