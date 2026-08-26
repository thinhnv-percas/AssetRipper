namespace DSMCaps
{
	internal enum NativeCapstoneResultCode
	{
		Ok,
		OutOfMemory,
		UnsupportedDisassembleArchitecture,
		InvalidHandle1,
		InvalidHandle2,
		UnsupportedDisassembleMode,
		InvalidOption,
		UnsupportedInstructionDetail,
		UninitializedMemoryManagement,
		UnsupportedVersion,
		UnSupportedDietModeOperation,
		UnsupportedSkipDataModeOperation,
		UnSupportedX86AttSyntax,
		UnSupportedX86IntelSyntax,
		UnSupportedX86MasmSyntax
	}
}
