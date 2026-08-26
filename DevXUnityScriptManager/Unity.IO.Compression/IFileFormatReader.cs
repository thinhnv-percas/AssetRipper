namespace Unity.IO.Compression;

internal interface IFileFormatReader
{
	bool ReadHeader(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 input);

	bool ReadFooter(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 input);

	void UpdateWithBytesRead(byte[] buffer, int offset, int bytesToCopy);

	void Validate();
}
