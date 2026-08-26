namespace DecompTools.Decompiler.IL;

public enum PrimitiveType : byte
{
	None = 0,
	I1 = 4,
	I2 = 6,
	I4 = 8,
	I8 = 10,
	R4 = 12,
	R8 = 13,
	U1 = 5,
	U2 = 7,
	U4 = 9,
	U8 = 11,
	I = 24,
	U = 25,
	Ref = 16,
	Unknown = byte.MaxValue
}
