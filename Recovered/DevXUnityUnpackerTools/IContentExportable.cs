internal interface IContentExportable : IContent
{
	string ExportFileName
	{
		get;
	}

	byte[] ExportContent
	{
		get;
	}
}
