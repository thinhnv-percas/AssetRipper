using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace Hjg.Pngcs.Zlib;

internal class ZlibOutputStreamIs : AZlibOutputStream
{
	private DeflaterOutputStream ost;

	private Deflater deflater;

	public ZlibOutputStreamIs(Stream st, int compressLevel, EDeflateCompressStrategy strat, bool leaveOpen)
		: base(st, compressLevel, strat, leaveOpen)
	{
		deflater = new Deflater(compressLevel);
		setStrat(strat);
		ost = new DeflaterOutputStream(st, deflater);
		ost.IsStreamOwner = !leaveOpen;
	}

	public void setStrat(EDeflateCompressStrategy strat)
	{
		switch (strat)
		{
		case EDeflateCompressStrategy.Filtered:
			deflater.SetStrategy(DeflateStrategy.Filtered);
			break;
		case EDeflateCompressStrategy.Huffman:
			deflater.SetStrategy(DeflateStrategy.HuffmanOnly);
			break;
		default:
			deflater.SetStrategy(DeflateStrategy.Default);
			break;
		}
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		ost.Write(buffer, offset, count);
	}

	public override void WriteByte(byte value)
	{
		ost.WriteByte(value);
	}

	public override void Close()
	{
		ost.Close();
	}

	public override void Flush()
	{
		ost.Flush();
	}

	public override string getImplementationId()
	{
		return "Zlib deflater: SharpZipLib";
	}
}
