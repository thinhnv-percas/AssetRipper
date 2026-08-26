namespace Unreal
{
	internal enum BULKDATA
	{
		BULKDATA_StoreInSeparateFile = 1,
		BULKDATA_CompressedZlib = 2,
		BULKDATA_CompressedLzo = 0x10,
		BULKDATA_Unused = 0x20,
		BULKDATA_SeparateData = 0x40,
		BULKDATA_CompressedLzx = 0x80,
		BULKDATA_CompressedLzoEncr = 0x100,
		BULKDATA_PayloadAtEndOfFile = 1,
		BULKDATA_ForceInlinePayload = 0x40,
		BULKDATA_PayloadInSeperateFile = 0x100,
		BULKDATA_SerializeCompressedBitWindow = 0x200,
		BULKDATA_OptionalPayload = 0x800
	}
}
