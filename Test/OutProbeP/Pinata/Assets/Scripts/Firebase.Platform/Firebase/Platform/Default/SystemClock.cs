using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform.Default
{
	[Token(Token = "0x2000018")]
	internal class SystemClock : IClockService
	{
		[Token(Token = "0x400003A")]
		public static readonly IClockService Instance;

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x15E5BC8", Offset = "0x15E5BC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected SystemClock()
		{
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x15E5BD0", Offset = "0x15E5BD0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EEF5D0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F54]) = v37;\nL_0015:\n\tv41 = new Firebase.Platform.Default.SystemClock();\n\tSystem.Object::.ctor(v41);\n\tv45.Instance = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static SystemClock()
		{
			SystemClock instance = new SystemClock();
			Instance = instance;
		}
	}
}
