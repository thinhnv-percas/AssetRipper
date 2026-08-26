namespace ImageMagick;

public sealed class PixelStorageSettings
{
	public string Mapping { get; set; }

	public StorageType StorageType { get; set; }

	public PixelStorageSettings()
	{
	}

	public PixelStorageSettings(StorageType storageType, string mapping)
	{
		Mapping = mapping;
		StorageType = storageType;
	}

	internal PixelStorageSettings Clone()
	{
		return new PixelStorageSettings
		{
			Mapping = Mapping,
			StorageType = StorageType
		};
	}
}
