using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Serializable]
	[Token(Token = "0x200000D")]
	public class AnyCondition : LinqCondition
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000014")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000015")]
			public static Func<ReactiveCondition, bool> _003C_003E9__0_0;

			[Token(Token = "0x6000026")]
			[Address(RVA = "0x81AE564", Offset = "0x81AE564", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.GameConditions.Implementations.AnyCondition+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000027")]
			[Address(RVA = "0x81AE5C8", Offset = "0x81AE5C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CIsEnumerableMet_003Eb__0_0(ReactiveCondition x)
			{
				if (!x._isInit)
				{
					x.Subscribe();
					x._isInit = true;
				}
				bool flag = x.InnerIsConditionMet();
				if (x._lastState != (flag ? 1 : 0))
				{
					x._lastState = (flag ? 1 : 0);
					if (x.OnConditionChanged != null)
					{
						x.OnConditionChanged();
					}
				}
				return flag;
			}
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x81AE43C", Offset = "0x81AE43C", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\t;\n\tv56 = v54.<>9__0_0 == 0;\n\tv57 = ~v56;\n\tv88 = v54.<>9__0_0;\n\tif (v57) goto L_005F;\n\tgoto L_003D;\nL_003D:\n\tgoto L_0045;\nL_005F:\n\treturnVal1 = System.Linq.Enumerable::Any(conditions, v88);\n\treturn returnVal1;\nL_0045:\n\tv123 = new System.Func`2<Unco.GameConditions.Implementations.ReactiveCondition, System.Boolean>();\n\tSystem.Func`2<Unco.GameConditions.Implementations.ReactiveCondition, System.Boolean>::.ctor(v123, v118.<>9, Il2CppMethodInfo);\n\tv130.<>9__0_0 = v123;\n\tv88 = v123;\n")]
		protected override bool IsEnumerableMet(IEnumerable<ReactiveCondition> conditions)
		{
			bool flag = _003C_003Ec._003C_003E9__0_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__0_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__0_0 = delegate(ReactiveCondition x)
				{
					if (!x._isInit)
					{
						x.Subscribe();
						x._isInit = true;
					}
					bool flag3 = x.InnerIsConditionMet();
					if (x._lastState != (flag3 ? 1 : 0))
					{
						x._lastState = (flag3 ? 1 : 0);
						if (x.OnConditionChanged != null)
						{
							x.OnConditionChanged();
						}
					}
					return flag3;
				});
			}
			return conditions.Any(predicate);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81AD660", Offset = "0x81AD660", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._lastState = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AnyCondition()
		{
			_lastState = -1;
		}
	}
}
