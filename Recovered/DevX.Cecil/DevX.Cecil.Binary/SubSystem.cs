namespace DevX.Cecil.Binary
{
	public enum SubSystem : ushort
	{
		Unknown = 0,
		Native = 1,
		WindowsGui = 2,
		WindowsCui = 3,
		PosixCui = 7,
		WindowsCeGui = 9,
		EfiApplication = 0x10,
		EfiBootServiceDriver = 17,
		EfiRuntimeDriver = 18,
		EfiRom = 19,
		Xbox = 20,
		NexusAgent = 21
	}
}
