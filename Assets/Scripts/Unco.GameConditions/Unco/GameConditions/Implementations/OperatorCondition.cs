using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x2000015")]
	public abstract class OperatorCondition : ReactiveCondition
	{
		[SerializeReference]
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x20")]
		internal ReactiveCondition m_leftCondition;

		[SerializeReference]
		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x28")]
		internal ReactiveCondition m_rightCondition;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x30")]
		private bool _isInitialized;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x31")]
		private bool _conditionCache;

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x81AE2D8", Offset = "0x81AE2D8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public OperatorCondition()
		{
			_lastState = -1;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x81AE2E8", Offset = "0x81AE2E8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\tthis.m_leftCondition = leftCondition;\n\tthis.m_rightCondition = rightCondition;\n\treturn;\n")]
		public OperatorCondition(ReactiveCondition leftCondition, ReactiveCondition rightCondition)
		{
			_lastState = -1;
			m_leftCondition = leftCondition;
			m_rightCondition = rightCondition;
		}

		[Token(Token = "0x600003A")]
		protected abstract bool OperatorConditionMet(ReactiveCondition leftCondition, ReactiveCondition rightCondition);

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x81AEF20", Offset = "0x81AEF20", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.GameConditions.Implementations.OperatorCondition::OperatorConditionMet(this, this.m_leftCondition, this.m_rightCondition);\n\treturn this;\n")]
		protected internal override bool InnerIsConditionMet()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OperatorCondition::InnerIsConditionMet");
			return default;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81AEF30", Offset = "0x81AEF30", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv62 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v95;\n\tv88 = this.OnConditionChanged == 0;\n\tif (v88) goto L_0047;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\tgoto L_005D;\nL_0063:\n\tv178 = 0x220BDA0(v161, v185, v163, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv128 = v178 == v163;\n\tv163 = v178;\n\tif (v128) goto L_0083;\nL_0072:\n\tv185 = System.Delegate::Combine(v163, v104);\n\tv180 = v185 == 0;\n\tif (v180) goto L_0063;\n\tv242 = *([v185 @ X0_v13 (System.Delegate)]) == System.Action;\n\tif (v242) goto L_0063;\n\tgoto L_00BD;\nL_0083:\n\tv153 = this.m_rightCondition;\n\tv147 = new System.Action();\n\tSystem.Action::.ctor(v147, this, Il2CppMethodInfo);\n\tgoto L_0097;\nL_009D:\n\tv309 = 0x220BDA0(v290, v284, v292, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv301 = v309 == v292;\n\tv292 = v309;\n\tif (v301) goto L_00C9;\nL_00AC:\n\tv284 = System.Delegate::Combine(v292, v147);\n\tv286 = v284 == 0;\n\tif (v286) goto L_009D;\n\tv268 = *([v284 @ X0_v25 (System.Delegate)]) == System.Action;\n\tif (v268) goto L_009D;\nL_00BD:\n\tthrow System.InvalidCastException;\nL_00C9:\n\treturn;\nL_001C:\n\tthis._isInitialized = 1;\n\tv54 = this._isInit == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0030;\nL_0047:\n\tthis._conditionCache = v95;\n\tv102 = this.m_leftCondition;\n\tv104 = new System.Action();\n\tSystem.Action::.ctor(v104, this, Il2CppMethodInfo);\nL_005D:\n\tv161 = this.m_leftCondition + 0x18;\n\tv163 = v102.OnConditionChanged;\n\tgoto L_0072;\nL_0097:\n\tv290 = this.m_rightCondition + 0x18;\n\tv292 = v153.OnConditionChanged;\n\tgoto L_00AC;\nL_0030:\n\tv95 = Unco.GameConditions.Implementations.OperatorCondition::InnerIsConditionMet(this);\n\tv82 = this._lastState == v95;\n\tif (v82) goto L_0047;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OperatorCondition::Initialize");
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81AF138", Offset = "0x81AF138", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tgoto L_0034;\nL_003A:\n\tv140 = 0x220BDA0(v123, v147, v126, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv89 = v140 == v126;\n\tv126 = v140;\n\tif (v89) goto L_005A;\nL_0049:\n\tv147 = System.Delegate::Remove(v126, v57);\n\tv142 = v147 == 0;\n\tif (v142) goto L_003A;\n\tv204 = *([v147 @ X0_v9 (System.Delegate)]) == System.Action;\n\tif (v204) goto L_003A;\n\tgoto L_0094;\nL_005A:\n\tv115 = this.m_rightCondition;\n\tv109 = new System.Action();\n\tSystem.Action::.ctor(v109, this, Il2CppMethodInfo);\n\tgoto L_006E;\nL_0074:\n\tv271 = 0x220BDA0(v253, v247, v223, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv264 = v271 == v223;\n\tv223 = v271;\n\tif (v264) goto L_0095;\nL_0083:\n\tv247 = System.Delegate::Remove(v223, v109);\n\tv249 = v247 == 0;\n\tif (v249) goto L_0074;\n\tv233 = *([v247 @ X0_v21 (System.Delegate)]) == System.Action;\n\tif (v233) goto L_0074;\nL_0094:\n\tthrow System.InvalidCastException;\nL_0095:\n\tthis._isInitialized = 0;\n\treturn;\nL_001F:\n\tv55 = this.m_leftCondition;\n\tv57 = new System.Action();\n\tSystem.Action::.ctor(v57, this, Il2CppMethodInfo);\nL_0034:\n\tv123 = this.m_leftCondition + 0x18;\n\tv126 = v55.OnConditionChanged;\n\tgoto L_0049;\nL_006E:\n\tv253 = this.m_rightCondition + 0x18;\n\tv223 = v115.OnConditionChanged;\n\tgoto L_0083;\n")]
		protected override void InnerDispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OperatorCondition::InnerDispose");
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x81AF2D8", Offset = "0x81AF2D8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._isInit == 0;\n\tv15 = ~v14;\n\tif (v15) goto L_0017;\n\tv20 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v64;\n\tv58 = this.OnConditionChanged == 0;\n\tif (v58) goto L_0033;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\tv84 = this._conditionCache ^ 1;\n\tthis._conditionCache = v84;\n\tv87 = this._isInit == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_004B;\n\tv124 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(this);\n\tthis._isInit = 1;\n\tthis._lastState = v106;\n\tv112 = this.OnConditionChanged == 0;\n\tif (v112) goto L_0069;\n\tSystem.Action::Invoke(this.OnConditionChanged);\n\treturn;\nL_0069:\n\treturn;\nL_0017:\n\tv64 = Unco.GameConditions.Implementations.OperatorCondition::InnerIsConditionMet(this);\n\tv52 = this._lastState == v64;\n\tif (v52) goto L_0033;\nL_0033:\n\tv77 = this._conditionCache == v64;\n\tif (v77) goto L_0069;\nL_004B:\n\tv106 = Unco.GameConditions.Implementations.OperatorCondition::InnerIsConditionMet(this);\n\tv98 = this._lastState == v106;\n\tif (v98) goto L_0069;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
	}
}
