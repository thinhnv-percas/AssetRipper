namespace DSMCaps
{
	internal enum NativeQueryOption
	{
		QueryArmArchitecture = 0,
		QueryArm64Architecture = 1,
		QueryMipsArchitecture = 2,
		QueryX86Architecture = 3,
		QueryPowerPcArchitecture = 4,
		QuerySparcArchitecture = 5,
		QuerySystemZArchitecture = 6,
		QueryXCoreArchitecture = 7,
		QueryM68KArchitecture = 8,
		QueryTms320C64XArchitecture = 9,
		QueryM680XArchitecture = 10,
		QueryEvmArchitecture = 11,
		QueryAllArchitectures = 0xFFFF,
		QueryDietMode = 0x10000,
		QueryX86ReduceMode = 65537
	}
}
