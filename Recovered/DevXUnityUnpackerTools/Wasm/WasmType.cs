namespace Wasm
{
	public enum WasmType : sbyte
	{
		Int32 = -1,
		Int64 = -2,
		Float32 = -3,
		Float64 = -4,
		AnyFunc = -16,
		Func = -32,
		Empty = -64
	}
}
