using System.Text;
using dnlib.IO;
using dnlib.PE;

namespace dnlib.DotNet.Writer;

public sealed class ImportDirectory : IChunk
{
	private readonly bool is64bit;

	private FileOffset offset;

	private RVA rva;

	private bool isExeFile;

	private uint length;

	private RVA importLookupTableRVA;

	private RVA corXxxMainRVA;

	private RVA mscoreeDllRVA;

	private int stringsPadding;

	private const uint STRINGS_ALIGNMENT = 16u;

	public ImportAddressTable ImportAddressTable { get; set; }

	public RVA CorXxxMainRVA => corXxxMainRVA;

	public RVA IatCorXxxMainRVA => ImportAddressTable.RVA;

	public bool IsExeFile
	{
		get
		{
			return isExeFile;
		}
		set
		{
			isExeFile = value;
		}
	}

	public FileOffset FileOffset => offset;

	public RVA RVA => rva;

	internal bool Enable { get; set; }

	public ImportDirectory(bool is64bit)
	{
		this.is64bit = is64bit;
	}

	public void SetOffset(FileOffset offset, RVA rva)
	{
		this.offset = offset;
		this.rva = rva;
		length = 40u;
		importLookupTableRVA = rva + length;
		length += (uint)(is64bit ? 16 : 8);
		stringsPadding = (int)(rva.AlignUp(16u) - rva);
		length += (uint)stringsPadding;
		corXxxMainRVA = rva + length;
		length += 14u;
		mscoreeDllRVA = rva + length;
		length += 12u;
		length++;
	}

	public uint GetFileLength()
	{
		if (!Enable)
		{
			return 0u;
		}
		return length;
	}

	public uint GetVirtualSize()
	{
		return GetFileLength();
	}

	public void WriteTo(DataWriter writer)
	{
		if (Enable)
		{
			writer.WriteUInt32((uint)importLookupTableRVA);
			writer.WriteInt32(0);
			writer.WriteInt32(0);
			writer.WriteUInt32((uint)mscoreeDllRVA);
			writer.WriteUInt32((uint)ImportAddressTable.RVA);
			writer.WriteUInt64(0uL);
			writer.WriteUInt64(0uL);
			writer.WriteInt32(0);
			if (is64bit)
			{
				writer.WriteUInt64((ulong)corXxxMainRVA);
				writer.WriteUInt64(0uL);
			}
			else
			{
				writer.WriteUInt32((uint)corXxxMainRVA);
				writer.WriteInt32(0);
			}
			writer.WriteZeroes(stringsPadding);
			writer.WriteUInt16(0);
			writer.WriteBytes(Encoding.UTF8.GetBytes(IsExeFile ? "_CorExeMain\0" : "_CorDllMain\0"));
			writer.WriteBytes(Encoding.UTF8.GetBytes("mscoree.dll\0"));
			writer.WriteByte(0);
		}
	}
}
