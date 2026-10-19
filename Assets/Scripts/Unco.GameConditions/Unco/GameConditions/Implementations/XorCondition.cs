using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x2000018")]
	public class XorCondition : OperatorCondition
	{
		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81AF53C", Offset = "0x81AF53C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public XorCondition()
		{
			_lastState = -1;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x81AD3CC", Offset = "0x81AD3CC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\tthis.m_leftCondition = leftCondition;\n\tthis.m_rightCondition = rightCondition;\n\treturn;\n")]
		public XorCondition(ReactiveCondition leftCondition, ReactiveCondition rightCondition)
		{
			_lastState = -1;
			m_leftCondition = leftCondition;
			m_rightCondition = rightCondition;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x81AF54C", Offset = "0x81AF54C", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = leftCondition._isInit == 0;\n\tv22 = ~v21;\n\tif (v22) goto L_001C;\n\tv82 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(leftCondition);\n\tleftCondition._isInit = 1;\n\tleftCondition._lastState = v92;\n\tv96 = leftCondition.OnConditionChanged == 0;\n\tif (v96) goto L_0035;\n\tSystem.Action::Invoke(leftCondition.OnConditionChanged);\nL_0035:\n\tv145 = rightCondition._isInit == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0043;\n\tv151 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(rightCondition);\n\trightCondition._isInit = 1;\n\trightCondition._lastState = v167;\n\tv165 = rightCondition.OnConditionChanged == 0;\n\tif (v165) goto L_005A;\n\tSystem.Action::Invoke(rightCondition.OnConditionChanged);\nL_001C:\n\tv92 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(leftCondition);\n\tv37 = leftCondition._lastState == v92;\n\tif (v37) goto L_0035;\nL_0043:\n\tv167 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(rightCondition);\n\tv114 = rightCondition._lastState == v167;\n\tif (v114) goto L_005A;\nL_005A:\n\treturnVal2 = v92 ^ v167;\n\treturn returnVal2;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool OperatorConditionMet(ReactiveCondition leftCondition, ReactiveCondition rightCondition)
		{
			if (!leftCondition._isInit)
			{
				leftCondition.Subscribe();
				leftCondition._isInit = true;
			}
			bool flag = leftCondition.InnerIsConditionMet();
			if (leftCondition._lastState != (flag ? 1 : 0))
			{
				leftCondition._lastState = (flag ? 1 : 0);
				if (leftCondition.OnConditionChanged != null)
				{
					leftCondition.OnConditionChanged();
				}
			}
			if (!rightCondition._isInit)
			{
				rightCondition.Subscribe();
				rightCondition._isInit = true;
			}
			bool flag2 = rightCondition.InnerIsConditionMet();
			if (rightCondition._lastState != (flag2 ? 1 : 0))
			{
				rightCondition._lastState = (flag2 ? 1 : 0);
				if (rightCondition.OnConditionChanged != null)
				{
					rightCondition.OnConditionChanged();
				}
			}
			return flag ^ flag2;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x81AF644", Offset = "0x81AF644", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected internal override void Subscribe()
		{
		}
	}
}
