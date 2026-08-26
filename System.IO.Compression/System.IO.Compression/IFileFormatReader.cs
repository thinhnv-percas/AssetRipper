namespace System.IO.Compression;

internal interface IFileFormatReader
{
	int ZLibWindowSize { get; }

	bool ReadHeader(System.IO.Compression.InputBuffer input);

	bool ReadFooter(System.IO.Compression.InputBuffer input);

	void UpdateWithBytesRead(byte[] buffer, int offset, int bytesToCopy);

	void Validate();
}
