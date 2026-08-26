namespace DecompTools.Decompiler.IL;

public enum ConversionKind : byte
{
	Invalid,
	Nop,
	IntToFloat,
	FloatToInt,
	FloatPrecisionChange,
	SignExtend,
	ZeroExtend,
	Truncate,
	StopGCTracking,
	StartGCTracking,
	ObjectInterior
}
