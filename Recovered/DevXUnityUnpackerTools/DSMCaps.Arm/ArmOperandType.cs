namespace DSMCaps.Arm
{
	public enum ArmOperandType
	{
		Invalid = 0,
		Register = 1,
		Immediate = 2,
		Memory = 3,
		FloatingPoint = 4,
		CImmediate = 0x40,
		PImmediate = 65,
		SetEndOperation = 66,
		SystemRegister = 67
	}
}
