namespace DSMCaps.Arm64
{
	public enum Arm64OperandType
	{
		Invalid = 0,
		Register = 1,
		Immediate = 2,
		Memory = 3,
		FloatingPoint = 4,
		CImmediate = 0x40,
		MrsSystemRegister = 65,
		MsrSystemRegister = 66,
		PStateField = 67,
		SystemOperation = 68,
		PrefetchOperation = 69,
		BarrierOperation = 70,
		AtOperation = -2147483647,
		DcOperation = -2147483646,
		IcOperation = -2147483645,
		TlbiOperation = -2147483644
	}
}
