using System;
using System.Collections.Generic;
using dnlib.IO;
using dnlib.PE;

namespace dnlib.DotNet.MD;

public static class MetadataFactory
{
	private enum MetadataType
	{
		Unknown,
		Compressed,
		ENC
	}

	internal static MetadataBase Load(string fileName)
	{
		IPEImage iPEImage = null;
		try
		{
			return Load(iPEImage = new PEImage(fileName));
		}
		catch
		{
			iPEImage?.Dispose();
			throw;
		}
	}

	internal static MetadataBase Load(byte[] data)
	{
		IPEImage iPEImage = null;
		try
		{
			return Load(iPEImage = new PEImage(data));
		}
		catch
		{
			iPEImage?.Dispose();
			throw;
		}
	}

	internal static MetadataBase Load(IntPtr addr)
	{
		IPEImage iPEImage = null;
		try
		{
			return Load(iPEImage = new PEImage(addr, ImageLayout.Memory, verify: true));
		}
		catch
		{
			iPEImage?.Dispose();
			iPEImage = null;
		}
		try
		{
			return Load(iPEImage = new PEImage(addr, ImageLayout.File, verify: true));
		}
		catch
		{
			iPEImage?.Dispose();
			throw;
		}
	}

	internal static MetadataBase Load(IntPtr addr, ImageLayout imageLayout)
	{
		IPEImage iPEImage = null;
		try
		{
			return Load(iPEImage = new PEImage(addr, imageLayout, verify: true));
		}
		catch
		{
			iPEImage?.Dispose();
			throw;
		}
	}

	internal static MetadataBase Load(IPEImage peImage)
	{
		return Create(peImage, verify: true);
	}

	public static Metadata CreateMetadata(IPEImage peImage)
	{
		return Create(peImage, verify: true);
	}

	public static Metadata CreateMetadata(IPEImage peImage, bool verify)
	{
		return Create(peImage, verify);
	}

	private static MetadataBase Create(IPEImage peImage, bool verify)
	{
		MetadataBase metadataBase = null;
		try
		{
			ImageDataDirectory imageDataDirectory = peImage.ImageNTHeaders.OptionalHeader.DataDirectories[14];
			if (imageDataDirectory.VirtualAddress == (RVA)0u)
			{
				throw new BadImageFormatException(".NET data directory RVA is 0");
			}
			DataReader reader = peImage.CreateReader(imageDataDirectory.VirtualAddress, 72u);
			ImageCor20Header imageCor20Header = new ImageCor20Header(ref reader, verify);
			if (imageCor20Header.Metadata.VirtualAddress == (RVA)0u)
			{
				throw new BadImageFormatException(".NET metadata RVA is 0");
			}
			RVA virtualAddress = imageCor20Header.Metadata.VirtualAddress;
			DataReader reader2 = peImage.CreateReader(virtualAddress);
			MetadataHeader metadataHeader = new MetadataHeader(ref reader2, verify);
			if (verify)
			{
				foreach (StreamHeader streamHeader in metadataHeader.StreamHeaders)
				{
					if ((ulong)((long)streamHeader.Offset + (long)streamHeader.StreamSize) > (ulong)reader2.EndOffset)
					{
						throw new BadImageFormatException("Invalid stream header");
					}
				}
			}
			metadataBase = GetMetadataType(metadataHeader.StreamHeaders) switch
			{
				MetadataType.Compressed => new CompressedMetadata(peImage, imageCor20Header, metadataHeader), 
				MetadataType.ENC => new ENCMetadata(peImage, imageCor20Header, metadataHeader), 
				_ => throw new BadImageFormatException("No #~ or #- stream found"), 
			};
			metadataBase.Initialize(null);
			return metadataBase;
		}
		catch
		{
			metadataBase?.Dispose();
			throw;
		}
	}

	internal static MetadataBase CreateStandalonePortablePDB(DataReaderFactory mdReaderFactory, bool verify)
	{
		MetadataBase metadataBase = null;
		try
		{
			DataReader reader = mdReaderFactory.CreateReader();
			MetadataHeader metadataHeader = new MetadataHeader(ref reader, verify);
			if (verify)
			{
				foreach (StreamHeader streamHeader in metadataHeader.StreamHeaders)
				{
					if (streamHeader.Offset + streamHeader.StreamSize < streamHeader.Offset || streamHeader.Offset + streamHeader.StreamSize > reader.Length)
					{
						throw new BadImageFormatException("Invalid stream header");
					}
				}
			}
			metadataBase = GetMetadataType(metadataHeader.StreamHeaders) switch
			{
				MetadataType.Compressed => new CompressedMetadata(metadataHeader, isStandalonePortablePdb: true), 
				MetadataType.ENC => new ENCMetadata(metadataHeader, isStandalonePortablePdb: true), 
				_ => throw new BadImageFormatException("No #~ or #- stream found"), 
			};
			metadataBase.Initialize(mdReaderFactory);
			return metadataBase;
		}
		catch
		{
			metadataBase?.Dispose();
			throw;
		}
	}

	private static MetadataType GetMetadataType(IList<StreamHeader> streamHeaders)
	{
		MetadataType? metadataType = null;
		foreach (StreamHeader streamHeader in streamHeaders)
		{
			if (!metadataType.HasValue)
			{
				if (streamHeader.Name == "#~")
				{
					metadataType = MetadataType.Compressed;
				}
				else if (streamHeader.Name == "#-")
				{
					metadataType = MetadataType.ENC;
				}
			}
			if (streamHeader.Name == "#Schema")
			{
				metadataType = MetadataType.ENC;
			}
		}
		if (!metadataType.HasValue)
		{
			return MetadataType.Unknown;
		}
		return metadataType.Value;
	}
}
