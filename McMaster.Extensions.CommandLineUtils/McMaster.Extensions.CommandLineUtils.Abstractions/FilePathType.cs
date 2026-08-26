using System;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

[Flags]
internal enum FilePathType
{
	Directory = 1,
	File = 2,
	Any = Directory | File
}
