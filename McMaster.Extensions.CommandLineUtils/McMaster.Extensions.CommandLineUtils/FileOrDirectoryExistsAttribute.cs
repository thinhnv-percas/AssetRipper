using System;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Property)]
public sealed class FileOrDirectoryExistsAttribute : FilePathExistsAttributeBase
{
	public FileOrDirectoryExistsAttribute()
		: base(FilePathType.Any)
	{
	}
}
