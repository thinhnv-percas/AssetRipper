using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public class AndCondition : OperatorCondition
	{
		[Token(Token = "0x6000020")]
		[Address(RVA = "0x81AE2C8", Offset = "0x81AE2C8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AndCondition()
		{
			_lastState = -1;
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x81AD31C", Offset = "0x81AD31C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\tthis.m_leftCondition = leftCondition;\n\tthis.m_rightCondition = rightCondition;\n\treturn;\n")]
		public AndCondition(ReactiveCondition leftCondition, ReactiveCondition rightCondition)
		{
			_lastState = -1;
			m_leftCondition = leftCondition;
			m_rightCondition = rightCondition;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x81AE340", Offset = "0x81AE340", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = leftCondition._isInit == 0;\n\tv18 = ~v17;\n\tif (v18) goto L_001A;\n\tv80 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(leftCondition);\n\tleftCondition._isInit = 1;\n\tleftCondition._lastState = returnVal2;\n\tv94 = leftCondition.OnConditionChanged == 0;\n\tif (v94) goto L_0031;\n\tSystem.Action::Invoke(leftCondition.OnConditionChanged);\n\tv163 = rightCondition._isInit == 0;\n\tv160 = ~v163;\n\tif (v160) goto L_0045;\n\tv168 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(rightCondition);\n\trightCondition._isInit = 1;\n\trightCondition._lastState = returnVal2;\n\tv159 = rightCondition.OnConditionChanged == 0;\n\tif (v159) goto L_0061;\n\tSystem.Action::Invoke(rightCondition.OnConditionChanged);\nL_001A:\n\treturnVal2 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(leftCondition);\n\tv33 = leftCondition._lastState == returnVal2;\n\tif (v33) goto L_0031;\nL_0031:\n\tv101 = ~returnVal2;\n\tif (v101) goto L_0061;\nL_0045:\n\treturnVal2 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(rightCondition);\n\tv144 = rightCondition._lastState == returnVal2;\n\tif (v144) goto L_0061;\nL_0061:\n\treturn returnVal2;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			if (flag)
			{
				if (!rightCondition._isInit)
				{
					rightCondition.Subscribe();
					rightCondition._isInit = true;
				}
				flag = rightCondition.InnerIsConditionMet();
				if (rightCondition._lastState != (flag ? 1 : 0))
				{
					rightCondition._lastState = (flag ? 1 : 0);
					if (rightCondition.OnConditionChanged != null)
					{
						rightCondition.OnConditionChanged();
					}
				}
			}
			return flag;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x81AE438", Offset = "0x81AE438", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected internal override void Subscribe()
		{
		}
	}
}
