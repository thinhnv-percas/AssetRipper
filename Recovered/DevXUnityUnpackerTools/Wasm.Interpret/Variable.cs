using System.Runtime.CompilerServices;

namespace Wasm.Interpret
{
	public sealed class Variable
	{
		private object _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private WasmValueType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		private bool _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020;

		public WasmValueType Type
		{
			get;
			private set;
		}

		public bool IsMutable
		{
			get;
			private set;
		}

		private Variable(object value, WasmValueType type, bool isMutable)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A = value;
			Type = type;
			IsMutable = isMutable;
		}

		public T Get<T>()
		{
			return (T)_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;
		}

		public void Set<T>(T Value)
		{
			if (!IsMutable)
			{
				throw new WasmException("Cannot assign a value to an immutable variable.");
			}
			if (!IsInstanceOf(Value, Type))
			{
				throw new WasmException("Cannot assign a value of type '" + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A(Value) + "' to a variable of type '" + Type.ToString() + "'.");
			}
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A = Value;
		}

		public static Variable Create<T>(WasmValueType type, bool isMutable, T value)
		{
			if (!IsInstanceOf(value, type))
			{
				throw new WasmException("Cannot create a variable of type '" + type.ToString() + "' with an initial value of type '" + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A(value) + "'.");
			}
			return new Variable(value, type, isMutable);
		}

		public static Variable CreateDefault(WasmValueType type, bool isMutable)
		{
			return Create(type, isMutable, GetDefaultValue(type));
		}

		public static object GetDefaultValue(WasmValueType type)
		{
			switch (type)
			{
			case WasmValueType.Int32:
				return 0;
			case WasmValueType.Int64:
				return 0L;
			case WasmValueType.Float32:
				return 0f;
			case WasmValueType.Float64:
				return 0.0;
			default:
				throw new WasmException("Unknown value type: " + type);
			}
		}

		public static bool IsInstanceOf<T>(T value, WasmValueType type)
		{
			switch (type)
			{
			case WasmValueType.Int32:
				return value is int;
			case WasmValueType.Int64:
				return value is long;
			case WasmValueType.Float32:
				return value is float;
			case WasmValueType.Float64:
				return value is double;
			default:
				throw new WasmException("Unknown value type: " + type);
			}
		}

		private static string _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A(object _0020)
		{
			return _0020.GetType().Name;
		}
	}
}
