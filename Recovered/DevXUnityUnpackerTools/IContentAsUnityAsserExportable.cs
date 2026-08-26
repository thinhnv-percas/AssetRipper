using System.Collections.Generic;

internal interface IContentAsUnityAsserExportable : IContent
{
	bool ExportUnityAssetEx(string path, Queue<IContentAsUnityAsserExportable> links);
}
