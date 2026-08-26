using System;
using dnlib.IO;

namespace dnlib.PE;

internal sealed class PEInfo
{
	private readonly ImageDosHeader imageDosHeader;

	private readonly ImageNTHeaders imageNTHeaders;

	private readonly ImageSectionHeader[] imageSectionHeaders;

	public ImageDosHeader ImageDosHeader => imageDosHeader;

	public ImageNTHeaders ImageNTHeaders => imageNTHeaders;

	public ImageSectionHeader[] ImageSectionHeaders => imageSectionHeaders;

	public PEInfo(ref DataReader reader, bool verify)
	{
		reader.Position = 0u;
		imageDosHeader = new ImageDosHeader(ref reader, verify);
		if (verify && imageDosHeader.NTHeadersOffset == 0)
		{
			throw new BadImageFormatException("Invalid NT headers offset");
		}
		reader.Position = imageDosHeader.NTHeadersOffset;
		imageNTHeaders = new ImageNTHeaders(ref reader, verify);
		reader.Position = (uint)(imageNTHeaders.OptionalHeader.StartOffset + imageNTHeaders.FileHeader.SizeOfOptionalHeader);
		int num = imageNTHeaders.FileHeader.NumberOfSections;
		if (num > 0)
		{
			DataReader dataReader = reader;
			dataReader.Position += 20u;
			uint num2 = dataReader.ReadUInt32();
			num = Math.Min(num, (int)((num2 - reader.Position) / 40));
		}
		imageSectionHeaders = new ImageSectionHeader[num];
		for (int i = 0; i < imageSectionHeaders.Length; i++)
		{
			imageSectionHeaders[i] = new ImageSectionHeader(ref reader, verify);
		}
	}

	public ImageSectionHeader ToImageSectionHeader(FileOffset offset)
	{
		ImageSectionHeader[] array = imageSectionHeaders;
		foreach (ImageSectionHeader imageSectionHeader in array)
		{
			if ((long)offset >= (long)imageSectionHeader.PointerToRawData && (long)offset < (long)(imageSectionHeader.PointerToRawData + imageSectionHeader.SizeOfRawData))
			{
				return imageSectionHeader;
			}
		}
		return null;
	}

	public ImageSectionHeader ToImageSectionHeader(RVA rva)
	{
		ImageSectionHeader[] array = imageSectionHeaders;
		foreach (ImageSectionHeader imageSectionHeader in array)
		{
			if (rva >= imageSectionHeader.VirtualAddress && rva < imageSectionHeader.VirtualAddress + Math.Max(imageSectionHeader.VirtualSize, imageSectionHeader.SizeOfRawData))
			{
				return imageSectionHeader;
			}
		}
		return null;
	}

	public RVA ToRVA(FileOffset offset)
	{
		ImageSectionHeader imageSectionHeader = ToImageSectionHeader(offset);
		if (imageSectionHeader != null)
		{
			return (RVA)((uint)(offset - imageSectionHeader.PointerToRawData) + (uint)imageSectionHeader.VirtualAddress);
		}
		return (RVA)offset;
	}

	public FileOffset ToFileOffset(RVA rva)
	{
		ImageSectionHeader imageSectionHeader = ToImageSectionHeader(rva);
		if (imageSectionHeader != null)
		{
			return (FileOffset)(rva - imageSectionHeader.VirtualAddress + imageSectionHeader.PointerToRawData);
		}
		return (FileOffset)rva;
	}

	private static ulong AlignUp(ulong val, uint alignment)
	{
		return (val + alignment - 1) & ~(ulong)(alignment - 1);
	}

	public uint GetImageSize()
	{
		IImageOptionalHeader optionalHeader = ImageNTHeaders.OptionalHeader;
		uint sectionAlignment = optionalHeader.SectionAlignment;
		ulong num = AlignUp(optionalHeader.SizeOfHeaders, sectionAlignment);
		ImageSectionHeader[] array = imageSectionHeaders;
		foreach (ImageSectionHeader imageSectionHeader in array)
		{
			ulong num2 = AlignUp((ulong)imageSectionHeader.VirtualAddress + (ulong)Math.Max(imageSectionHeader.VirtualSize, imageSectionHeader.SizeOfRawData), sectionAlignment);
			if (num2 > num)
			{
				num = num2;
			}
		}
		return (uint)Math.Min(num, 4294967295uL);
	}
}
