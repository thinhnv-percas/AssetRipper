using ICSharpCode.SharpZipLib.Core;

namespace ICSharpCode.SharpZipLib.Zip
{
	internal interface IEntryFactory
	{
		INameTransform NameTransform
		{
			get;
			set;
		}

		_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A MakeFileEntry(string fileName);

		_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A MakeFileEntry(string fileName, bool useFileSystem);

		_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A MakeFileEntry(string fileName, string entryName, bool useFileSystem);

		_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A MakeDirectoryEntry(string directoryName);

		_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A MakeDirectoryEntry(string directoryName, bool useFileSystem);
	}
}
