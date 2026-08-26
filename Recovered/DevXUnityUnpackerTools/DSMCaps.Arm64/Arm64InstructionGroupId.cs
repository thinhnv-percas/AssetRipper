namespace DSMCaps.Arm64
{
	public enum Arm64InstructionGroupId
	{
		Invalid = 0,
		ARM64_GRP_JUMP = 1,
		ARM64_GRP_CALL = 2,
		ARM64_GRP_RET = 3,
		ARM64_GRP_INT = 4,
		ARM64_GRP_PRIVILEGE = 6,
		ARM64_GRP_BRANCH_RELATIVE = 7,
		ARM64_GRP_CRYPTO = 0x80,
		ARM64_GRP_FPARMV8 = 129,
		ARM64_GRP_NEON = 130,
		ARM64_GRP_CRC = 131
	}
}
