namespace Mon3.Cecil.PE;

internal enum TextSegment
{
	ImportAddressTable,
	CLIHeader,
	Code,
	Resources,
	Data,
	StrongNameSignature,
	MetadataHeader,
	TableHeap,
	StringHeap,
	UserStringHeap,
	GuidHeap,
	BlobHeap,
	PdbHeap,
	DebugDirectory,
	ImportDirectory,
	ImportHintNameTable,
	StartupStub
}
