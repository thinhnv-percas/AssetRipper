using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x2000016")]
	public class OrCondition : OperatorCondition
	{
		[Token(Token = "0x600003F")]
		[Address(RVA = "0x81AF3CC", Offset = "0x81AF3CC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public OrCondition()
		{
			_lastState = -1;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x81AD374", Offset = "0x81AD374", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\tthis.m_leftCondition = leftCondition;\n\tthis.m_rightCondition = rightCondition;\n\treturn;\n")]
		public OrCondition(ReactiveCondition leftCondition, ReactiveCondition rightCondition)
		{
			_lastState = -1;
			m_leftCondition = leftCondition;
			m_rightCondition = rightCondition;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x81AF3DC", Offset = "0x81AF3DC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = leftCondition._isInit == 0;\n\tv18 = ~v17;\n\tif (v18) goto L_001A;\n\tv80 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(leftCondition);\n\tleftCondition._isInit = 1;\n\tleftCondition._lastState = v48;\n\tv94 = leftCondition.OnConditionChanged == 0;\n\tif (v94) goto L_0032;\n\tSystem.Action::Invoke(leftCondition.OnConditionChanged);\n\treturnVal2 = 1;\nL_003F:\n\tv166 = rightCondition._isInit == 0;\n\tv163 = ~v166;\n\tif (v163) goto L_004D;\n\tv171 = Unco.GameConditions.Implementations.ReactiveCondition::Subscribe(rightCondition);\n\trightCondition._isInit = 1;\n\trightCondition._lastState = returnVal2;\n\tv152 = rightCondition.OnConditionChanged == 0;\n\tif (v152) goto L_003A;\n\tSystem.Action::Invoke(rightCondition.OnConditionChanged);\n\treturn returnVal2;\nL_001A:\n\tv48 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(leftCondition);\n\tv33 = leftCondition._lastState == v48;\n\tif (v33) goto L_0032;\nL_0032:\n\tv102 = v48 == 0;\n\tif (v102) goto L_003F;\nL_004D:\n\treturnVal2 = Unco.GameConditions.Implementations.ReactiveCondition::InnerIsConditionMet(rightCondition);\n\tv117 = rightCondition._lastState == returnVal2;\n\tif (v117) goto L_003A;\nL_003A:\n\treturn returnVal2;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			bool flag2;
			if (flag)
			{
				flag2 = true;
			}
			else
			{
				if (!rightCondition._isInit)
				{
					rightCondition.Subscribe();
					rightCondition._isInit = true;
				}
				flag2 = rightCondition.InnerIsConditionMet();
				if (rightCondition._lastState != (flag2 ? 1 : 0))
				{
					rightCondition._lastState = (flag2 ? 1 : 0);
					if (rightCondition.OnConditionChanged != null)
					{
						rightCondition.OnConditionChanged();
						return flag2;
					}
				}
			}
			return flag2;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x81AF4E4", Offset = "0x81AF4E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected internal override void Subscribe()
		{
		}
	}
}
