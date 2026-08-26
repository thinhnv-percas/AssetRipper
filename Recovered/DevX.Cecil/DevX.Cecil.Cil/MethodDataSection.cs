namespace DevX.Cecil.Cil
{
	internal enum MethodDataSection : ushort
	{
		EHTable = 1,
		OptILTable = 2,
		FatFormat = 0x40,
		MoreSects = 0x80
	}
}
