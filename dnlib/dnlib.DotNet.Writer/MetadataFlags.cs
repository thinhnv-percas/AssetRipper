using System;

namespace dnlib.DotNet.Writer;

[Flags]
public enum MetadataFlags : uint
{
	PreserveTypeRefRids = 1u,
	PreserveTypeDefRids = 2u,
	PreserveFieldRids = 4u,
	PreserveMethodRids = 8u,
	PreserveParamRids = 0x10u,
	PreserveMemberRefRids = 0x20u,
	PreserveStandAloneSigRids = 0x40u,
	PreserveEventRids = 0x80u,
	PreservePropertyRids = 0x100u,
	PreserveTypeSpecRids = 0x200u,
	PreserveMethodSpecRids = 0x400u,
	PreserveAllMethodRids = PreserveMethodRids | PreserveMemberRefRids | PreserveMethodSpecRids,
	PreserveRids = PreserveAllMethodRids | PreserveTypeRefRids | PreserveTypeDefRids | PreserveFieldRids | PreserveParamRids | PreserveStandAloneSigRids | PreserveEventRids | PreservePropertyRids | PreserveTypeSpecRids,
	PreserveStringsOffsets = 0x800u,
	PreserveUSOffsets = 0x1000u,
	PreserveBlobOffsets = 0x2000u,
	PreserveExtraSignatureData = 0x4000u,
	PreserveAll = PreserveRids | PreserveStringsOffsets | PreserveUSOffsets | PreserveBlobOffsets | PreserveExtraSignatureData,
	KeepOldMaxStack = 0x8000u,
	AlwaysCreateGuidHeap = 0x10000u,
	AlwaysCreateStringsHeap = 0x20000u,
	AlwaysCreateUSHeap = 0x40000u,
	AlwaysCreateBlobHeap = 0x80000u,
	RoslynSortInterfaceImpl = 0x100000u
}
