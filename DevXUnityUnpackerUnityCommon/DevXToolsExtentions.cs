using System;

public class DevXToolsExtentions
{
	public delegate byte[] CompressTexture(object texture, int textureFormat, int textureCompressionQuality);

	public delegate string CreateAsset(object asset, string path);

	public delegate void ImportAsset(string path);

	public delegate void StartAssetEditing();

	public delegate void StopAssetEditing();

	public delegate object LoadAssetAtPath(string assetPath, Type type);

	public static bool IsEditor;

	public static string EditorVersion;

	public static string AssetsDirectory;

	public static CompressTexture OnCompressTexture;

	public static CreateAsset OnCreateAsset;

	public static ImportAsset OnImportAsset;

	public static StartAssetEditing OnStartAssetEditing;

	public static StopAssetEditing OnStopAssetEditing;

	public static LoadAssetAtPath OnLoadAssetAtPath;
}
