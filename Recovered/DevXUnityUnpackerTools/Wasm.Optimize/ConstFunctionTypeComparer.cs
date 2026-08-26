using System.Collections.Generic;
using System.Linq;

namespace Wasm.Optimize
{
	public sealed class ConstFunctionTypeComparer : IEqualityComparer<FunctionType>
	{
		public static readonly ConstFunctionTypeComparer Instance = new ConstFunctionTypeComparer();

		internal ConstFunctionTypeComparer()
		{
		}

		public bool Equals(FunctionType x, FunctionType y)
		{
			if (x.ParameterTypes.SequenceEqual(y.ParameterTypes))
			{
				return x.ReturnTypes.SequenceEqual(y.ReturnTypes);
			}
			return false;
		}

		internal static int _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(IEnumerable<WasmValueType> _0020, int _0020_000A)
		{
			int num = _0020_000A;
			foreach (WasmValueType item in _0020)
			{
				num = ((num * 31) ^ (int)item);
			}
			return num;
		}

		public int GetHashCode(FunctionType obj)
		{
			return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(obj.ReturnTypes, _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(obj.ParameterTypes, 0));
		}
	}
}
