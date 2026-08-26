using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;

internal class TranslationManager
{
	private static bool _0020_000A_000A_000A_000A_0020_000A_000A;

	internal static Dictionary<int, string> _0020_000A_000A_000A_000A_0020_000A_0020;

	internal static Dictionary<int, string> _0020_000A_000A_000A_000A_0020_0020_000A;

	internal static Dictionary<int, string> _0020_000A_000A_000A_000A_0020_0020_0020;

	internal static List<Action> _0020_000A_000A_000A_0020_000A_000A_000A;

	private static Dictionary<string, string> _0020_000A_000A_000A_0020_000A_000A_0020;

	private static string _0020_000A_000A_000A_0020_000A_0020_000A;

	private static void _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020(string _0020, string _0020_000A)
	{
		if (_0020 != null)
		{
			_0020_000A_000A_000A_0020_000A_000A_0020[_0020] = _0020_000A;
		}
	}

	private static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(string _0020)
	{
		if (_0020 == null)
		{
			return null;
		}
		if (_0020_000A_000A_000A_0020_000A_000A_0020.ContainsKey(_0020))
		{
			return _0020_000A_000A_000A_0020_000A_000A_0020[_0020];
		}
		return null;
	}

	internal static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020()
	{
		string text = "EN";
		text = Thread.CurrentThread.CurrentCulture.Name.Split("-".ToCharArray())[0].ToUpper();
		if (string.IsNullOrEmpty(text))
		{
			text = "EN";
		}
		return text;
	}

	static TranslationManager()
	{
		AddDefLoc("Run DevXC file - only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("Run DevXC file - only available for 'DevX-GameRecovery' or 'DevX-GameModing' or 'DevX-MagicStudio' license type.");
		AddDefLoc("Run DevXC file - only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("Wait.. Making Unitypackage..");
		AddDefLoc("Open unity GameDir - end");
		AddDefLoc("Waiting...  open unity GameDir..");
		AddDefLoc("read end");
		AddDefLoc("Error:");
		AddDefLoc("Waiting... open pak: ");
		AddDefLoc("read end");
		AddDefLoc("Error:");
		AddDefLoc("Waiting... open uasset: ");
		AddDefLoc("Waiting.. Parsing asset item: ");
		AddDefLoc(" - Sometimes the primary decompilation can take several minutes (depends on the size of the assembly)..");
		AddDefLoc("Waiting.. Parsing script: ");
		AddDefLoc("Waiting.. Parsing item: ");
		AddDefLoc("Make obb - ok");
		AddDefLoc("Error on create obb: ");
		AddDefLoc("Wait... make obb ");
		AddDefLoc("Make apk - ok");
		AddDefLoc("Error on create APK: ");
		AddDefLoc("Wait... make apk ");
		AddDefLoc("Wait... Save Bundle");
		AddDefLoc("Wait... Save Bundle");
		AddDefLoc("Make zip - end");
		AddDefLoc("Error on create zip: ");
		AddDefLoc("read end");
		AddDefLoc("Error:");
		AddDefLoc("Impoer Ok:");
		AddDefLoc("Waiting... open webGL: ");
		AddDefLoc("read end");
		AddDefLoc("Error:");
		AddDefLoc("Waiting... open webGL: ");
		AddDefLoc("Error:");
		AddDefLoc("Waiting.. Open Unitypackage begin...");
		AddDefLoc("Error:");
		AddDefLoc("Waiting.. Open IPA begin...");
		AddDefLoc("Error:");
		AddDefLoc("Waiting.. Open apk begin...");
		AddDefLoc("APK:");
		AddDefLoc("read end");
		AddDefLoc("Error:");
		AddDefLoc("Export to:");
		AddDefLoc("Waiting... open bundle: ");
		AddDefLoc("Error");
		AddDefLoc("Open OK, Items count: ");
		AddDefLoc(" - init objects ..");
		AddDefLoc("Waiting.. Import Asset: ");
		AddDefLoc(" - read structure..");
		AddDefLoc("Waiting.. Import Asset:");
		AddDefLoc("Waiting.. Import Asset: ");
		AddDefLoc("ExportUassetsFromUnrealEnginePAK ok, count: ");
		AddDefLoc("Export error: ");
		AddDefLoc("Export asset:");
		AddDefLoc("ExportUassetsFromUnrealEnginePAK to:");
		AddDefLoc("Generate Scripts - ok");
		AddDefLoc("Wait.. Generate scripts.. ");
		AddDefLoc("Wait.. Generate Scripts..");
		AddDefLoc("Make parfab asset:");
		AddDefLoc("Wait.. Making Prefab..");
		AddDefLoc("Make prefab - break");
		AddDefLoc("Make prefab - error");
		AddDefLoc("Make prefab - ok");
		AddDefLoc("Unitypackage - end with error");
		AddDefLoc("Unitypackage - ok");
		AddDefLoc("Wait.. Making Unitypackage..");
		AddDefLoc("Wait.. Export Scripts..");
		AddDefLoc("Wait.. Making Unitypackage..");
		AddDefLoc("Wait.. Making Unitypackage..");
		AddDefLoc(" make asset: ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc("MakePrefabs - ok");
		AddDefLoc("Wait.. Making Prefabs.. ");
		AddDefLoc("Wait.. Making Prefabs..");
		AddDefLoc("TestAssets - end");
		AddDefLoc("Wait.. TestAssets.. ");
		AddDefLoc("Wait.. TestAssets.. ");
		AddDefLoc("Wait.. TestAssets..");
		AddDefLoc("MakeUnityProject - ok");
		AddDefLoc("Wait.. Making Unity Project.. Make scripts for ");
		AddDefLoc("Wait.. Making Unity Project.. ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc(" export asset: ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc(" export asset: ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc("Wait.. Making UnityProject.. ");
		AddDefLoc("Wait.. Making UnityProject..");
		AddDefLoc("Import ok, count: ");
		AddDefLoc("Import from:");
		AddDefLoc("Export ok, count: ");
		AddDefLoc("Export error: ");
		AddDefLoc("Export asset:");
		AddDefLoc("Export make asset:");
		AddDefLoc("Export to:");
		AddDefLoc("Export ok, count: ");
		AddDefLoc("Export to:");
		AddDefLoc("Export error: ");
		AddDefLoc("Export asset:");
		AddDefLoc("Export make asset:");
		AddDefLoc("Export error: ");
		AddDefLoc("Export :");
		AddDefLoc("Export to:");
		AddDefLoc("Waiting.. make tree - end");
		AddDefLoc("Waiting.. m_AssetToPrefab.. items: ");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting.. AssetBundle.. Resources path update, items: ");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting.. ScriptMapper.. Resources path update, items: ");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting.. Resource manager.. Resources path update, items: ");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting.. make tree...");
		AddDefLoc("Waiting.. parsing content...");
		AddDefLoc("Waiting.. make tree structure - ok");
		AddDefLoc("Waiting.. make tree structure.. for ");
		AddDefLoc("Waiting.. ");
		AddDefLoc("Make asset");
		AddDefLoc("Waiting.. ");
		AddDefLoc("Waiting.. MakePreview-end");
		AddDefLoc("Waiting.. MakePreview..");
		AddDefLoc("Ok");
		AddDefLoc("Waiting.. Update all..");
		AddDefLoc("Waiting.. Recreate all assets..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting..");
		AddDefLoc("Decompile libil2cpp.so (IL2CPP) to C# code");
		AddDefLoc("Waiting..");
		AddDefLoc("Waiting.. ");
		AddDefLoc("parsing");
		AddDefLoc("Waiting.. ");
		AddDefLoc("Waiting.. open");
		AddDefLoc("Connection - ok");
		AddDefLoc(" No Internet connection!!!");
		AddDefLoc(" No Internet connection!!!");
		AddDefLoc("There is no connection to devxdevelopment.com\nFor the correct operation of the program - you need a network connection.");
		AddDefLoc("Connection - not tested");
		AddDefLoc("error");
		AddDefLoc("Play.. ");
		AddDefLoc("Unsupported format");
		AddDefLoc("Unsupported format");
		AddDefLoc("Wait... Extract audio..");
		AddDefLoc("Apply changes - end");
		AddDefLoc("DevXUnity-Unpacker Magic Tools");
		AddDefLoc("Updates\r\nOpen download web site");
		AddDefLoc("License (registration)");
		AddDefLoc("Buy and support a project");
		AddDefLoc("Video lessons");
		AddDefLoc("UI Language");
		AddDefLoc("Game Database");
		AddDefLoc("Break");
		AddDefLoc("Debug console");
		AddDefLoc("Search by id, name");
		AddDefLoc("Select next:");
		AddDefLoc("Search form..");
		AddDefLoc("Search result:");
		AddDefLoc("Rows limit:");
		AddDefLoc("Group resources");
		AddDefLoc("Show tree items id");
		AddDefLoc("Assets only");
		AddDefLoc("Material");
		AddDefLoc("Shader");
		AddDefLoc("Primitive models");
		AddDefLoc("Animation models");
		AddDefLoc("Prefab");
		AddDefLoc("GameObject");
		AddDefLoc("Script");
		AddDefLoc("Animation Clip");
		AddDefLoc("Script files");
		AddDefLoc("Mesh");
		AddDefLoc("Text");
		AddDefLoc("Sounds");
		AddDefLoc("Images");
		AddDefLoc("Sprites");
		AddDefLoc("Texture2D");
		AddDefLoc("Cubemap");
		AddDefLoc("Search now");
		AddDefLoc("By name:");
		AddDefLoc("Reset filter");
		AddDefLoc("Filter");
		AddDefLoc("FlipY on Replace image");
		AddDefLoc("Replace sound");
		AddDefLoc("Edit and replace text");
		AddDefLoc("Replace image");
		AddDefLoc("Replace binary content (binary, png, wav, etc)");
		AddDefLoc("Save asset binary content");
		AddDefLoc("Save asset headers");
		AddDefLoc("Import resources for Repack");
		AddDefLoc("Export resources for Repack");
		AddDefLoc("Asset (selected):");
		AddDefLoc("Apply all changes (repack bundle, make APK, etc)");
		AddDefLoc("Repack");
		AddDefLoc("Test Assets");
		AddDefLoc("Export uassets from Unreal Engine PAK");
		AddDefLoc("Export All Prefabs");
		AddDefLoc("Generate Project Scripts");
		AddDefLoc("Export resources to directory (png, wav, avi, obj...)");
		AddDefLoc("Generate Unity Project");
		AddDefLoc("Export");
		AddDefLoc("Unpack LZMA");
		AddDefLoc("Unpack LZ4");
		AddDefLoc("Unpack Brotli");
		AddDefLoc("Unpack GZIP");
		AddDefLoc("Tools");
		AddDefLoc("Project generate settings");
		AddDefLoc("Import settings");
		AddDefLoc("APK Sign settings");
		AddDefLoc("Proxy Settings");
		AddDefLoc("Girl");
		AddDefLoc("Classic");
		AddDefLoc("None");
		AddDefLoc("Wait animation type");
		AddDefLoc("Disable dialog: For save changes to assets: press 'Apply Changes'");
		AddDefLoc("Show fast menu");
		AddDefLoc("Disable auto open result files");
		AddDefLoc("Settings");
		AddDefLoc("Clear");
		AddDefLoc("Open Binary Analyzer tools");
		AddDefLoc("DevXC Console");
		AddDefLoc("Open current action history");
		AddDefLoc("DevXC-Scripts");
		AddDefLoc("Open DDS Texture");
		AddDefLoc("Open as binary");
		AddDefLoc("Open as Asset file");
		AddDefLoc("Open UnrealEngine PAK");
		AddDefLoc("Open UnrealEngine uasset");
		AddDefLoc("Open as SketchFab.com model by URL");
		AddDefLoc("Open as Unity WebGL Game by URL");
		AddDefLoc("Open as Unity WebGL file (.unityweb)");
		AddDefLoc("Open as Bundle (WebPlayer) file");
		AddDefLoc("Open as IPA file (iOS)");
		AddDefLoc("Open as APK, OBB, XAPK file (android)");
		AddDefLoc("Open Unity3D/Unreal game directory");
		AddDefLoc("Open");
		AddDefLoc("toolStripMain");
		AddDefLoc("Tag:");
		AddDefLoc("ID:");
		AddDefLoc("Layer:");
		AddDefLoc("File:");
		AddDefLoc("PropertyGridToolBar");
		AddDefLoc("Inspector");
		AddDefLoc("Edit selected");
		AddDefLoc("toolStrip1");
		AddDefLoc("Lenght");
		AddDefLoc("Name");
		AddDefLoc("Bundle content");
		AddDefLoc("Info");
		AddDefLoc("Version Info");
		AddDefLoc("Generate GUISkin");
		AddDefLoc("Generate ScriptableObject");
		AddDefLoc("Generate RenderTexture");
		AddDefLoc("Generate Text Assets");
		AddDefLoc("Generate VideoClip");
		AddDefLoc("Generate Font");
		AddDefLoc("Generate Prefabs");
		AddDefLoc("Generate PhysicsMaterial2D Asset");
		AddDefLoc("Generate PhysicMaterial Asset");
		AddDefLoc("Generate AudioClip Asset");
		AddDefLoc("Generate Mesh Asset");
		AddDefLoc("Generate AnimationController");
		AddDefLoc("Generate Humanoid Animations");
		AddDefLoc("Generate AnimationClip\r\n");
		AddDefLoc("Generate Sprite");
		AddDefLoc("Generate Texture2D");
		AddDefLoc("Generate Materials");
		AddDefLoc("GameObject Transform RectTransform  \r\nMonoBehavior Renderer MeshRenderer \r\nMeshFilter MeshCollider Canvas \r\nCameraAsset AudioListener AudioSources \r\nColliders Animator and other");
		AddDefLoc("Generate animated model (to .unitypackage)");
		AddDefLoc("Generate Unitypackage (.unitypackage)");
		AddDefLoc("Generate Prefab (.prefab)");
		AddDefLoc("Generate Scenes (.unity Levels)");
		AddDefLoc("Generate Scripts (simple) for Android IL2CPP  (C#) ");
		AddDefLoc("Generate Scripts (C#) ");
		AddDefLoc("Repack Bundles (.unity3d)");
		AddDefLoc("Make APK (with signature)");
		AddDefLoc("Generate Unity Project:");
		AddDefLoc("Binary replace for any resources");
		AddDefLoc("Replace Images (with encoding)");
		AddDefLoc("Edit Header Values");
		AddDefLoc("Edit Text");
		AddDefLoc("Replace resources for assets:");
		AddDefLoc("Export Terrain Height-Map");
		AddDefLoc("Export/Create Prefab");
		AddDefLoc("Export Shader (for text shader mode)");
		AddDefLoc("Export Fonts");
		AddDefLoc("Export Text assets");
		AddDefLoc("Export Video (avi, mp4,..)");
		AddDefLoc("Export Scene elements (to FBX, Prefab)");
		AddDefLoc("Export Mesh (OBJ with sub-mesh, FBX)");
		AddDefLoc("Export AudioClip (Sounds to .wav)");
		AddDefLoc("Export Sprites (png)");
		AddDefLoc("Export Texture2D (png, pvr, dds)");
		AddDefLoc("Export:");
		AddDefLoc("Unreal Engine Assets");
		AddDefLoc("Unreal Engine PAK");
		AddDefLoc("WebGL (.unityweb)");
		AddDefLoc("Asset files");
		AddDefLoc("iOS Package (.ipa)");
		AddDefLoc("Standalone (WIN, MAC, LINUX)");
		AddDefLoc("Bundles (.unity3d and other)");
		AddDefLoc("APK (apk, obb, xapk)");
		AddDefLoc("Support formats:");
		AddDefLoc("Implementation..");
		AddDefLoc("Support");
		AddDefLoc("Save descriptions to file");
		AddDefLoc("toolStrip11");
		AddDefLoc("Metadata");
		AddDefLoc("Errors:");
		AddDefLoc("Errors");
		AddDefLoc("Save assembly");
		AddDefLoc("Method name filter:");
		AddDefLoc("Value Filter:");
		AddDefLoc("Edit selected");
		AddDefLoc("toolStrip6");
		AddDefLoc("Destanation method");
		AddDefLoc("Method");
		AddDefLoc("Value");
		AddDefLoc("Assembly code strings");
		AddDefLoc("Clear item");
		AddDefLoc("Paste link to asset");
		AddDefLoc("Replace selected value from file");
		AddDefLoc("Save selected item to file");
		AddDefLoc("Edit selected");
		AddDefLoc("toolStrip8");
		AddDefLoc("Length (bytes)");
		AddDefLoc("Type");
		AddDefLoc("Name");
		AddDefLoc("Value");
		AddDefLoc("Asset header edit");
		AddDefLoc("Font test");
		AddDefLoc("Font");
		AddDefLoc("Hex RAW");
		AddDefLoc("Replace sound");
		AddDefLoc("Stop play");
		AddDefLoc("Play sound");
		AddDefLoc("Save as FSB5");
		AddDefLoc("Save as (wav, mp3,ogg)");
		AddDefLoc("toolStrip1");
		AddDefLoc("label22");
		AddDefLoc("Audio clip");
		AddDefLoc("Reset of camera");
		AddDefLoc("Clear scene");
		AddDefLoc("Stop of process");
		AddDefLoc("Making 3D scene (without materials)");
		AddDefLoc("Making 3D scene");
		AddDefLoc("Export as \".Prefab\"");
		AddDefLoc("Export model as \".FBX\"");
		AddDefLoc("Export as \".Unitypackage\"");
		AddDefLoc("toolStrip9");
		AddDefLoc("3DScene");
		AddDefLoc("Reset camera");
		AddDefLoc("Export as Asset");
		AddDefLoc("Export as FBX");
		AddDefLoc("Export as STL");
		AddDefLoc("Export as OBJ");
		AddDefLoc("toolStrip10");
		AddDefLoc("3DView");
		AddDefLoc("Without alpha channel");
		AddDefLoc("Black");
		AddDefLoc("White");
		AddDefLoc("Chessboard");
		AddDefLoc("Background:");
		AddDefLoc("Replace image");
		AddDefLoc("Save as PNG");
		AddDefLoc("Save all Sprites");
		AddDefLoc("toolStrip4");
		AddDefLoc("w,h,format");
		AddDefLoc("Information:");
		AddDefLoc("toolStrip7");
		AddDefLoc("Image");
		AddDefLoc("Save as Text");
		AddDefLoc("toolStrip11");
		AddDefLoc("Shader UnityLab");
		AddDefLoc("Open on new window");
		AddDefLoc("Edit and replace text");
		AddDefLoc("Replace text");
		AddDefLoc("Save as Text");
		AddDefLoc("toolStrip5");
		AddDefLoc("label21");
		AddDefLoc("Text/Script");
		AddDefLoc("Save descriptions to file");
		AddDefLoc("toolStrip3");
		AddDefLoc("Test\n123\n456");
		AddDefLoc("Common");
		AddDefLoc("Export All Prefabs");
		AddDefLoc("Generate Project Scripts");
		AddDefLoc("Export resources to directory");
		AddDefLoc("Generate Unity Project");
		AddDefLoc("toolStrip1");
		AddDefLoc("Next");
		AddDefLoc("Back");
		AddDefLoc("toolStrip1");
		AddDefLoc("multiSelectTreeView21");
		AddDefLoc("Drag the game here and I'll show what's inside)");
		AddDefLoc("Interesting..");
		AddDefLoc("Delete asset");
		AddDefLoc("Add child asset with dublicate by selection dialog");
		AddDefLoc("Paste asset");
		AddDefLoc("Copy asset");
		AddDefLoc("Dublicate asset");
		AddDefLoc("Add GameObject");
		AddDefLoc("Add new asset");
		AddDefLoc("Find All references");
		AddDefLoc("Replace binary content (binary, png, wav, etc)");
		AddDefLoc("Export all Sprites (for Texture2D)");
		AddDefLoc("Export content (with convert format: png, wav, etc)");
		AddDefLoc("Save content (without contertaion)");
		AddDefLoc("Save asset header");
		AddDefLoc("Make node dump");
		AddDefLoc("Export model as FBX");
		AddDefLoc("Export as Prefab");
		AddDefLoc("Export as ZIP archive");
		AddDefLoc("Export as multiple Unitypackage (separate files)");
		AddDefLoc("Export as Unitypackage");
		AddDefLoc("Load custom metadatas");
		AddDefLoc("Optimize Metadata for file");
		AddDefLoc("Join and save all assets metadata");
		AddDefLoc("Save metadata from packed");
		AddDefLoc("Save packed version metadata");
		AddDefLoc("Save class metadata");
		AddDefLoc("Metadata");
		AddDefLoc("Status");
		AddDefLoc("statusStrip2");
		AddDefLoc("License for 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Not selected asset to copy (Copy asset)");
		AddDefLoc("Dont select header edit item");
		AddDefLoc("Dont select header edit item");
		AddDefLoc("Dont select header edit item");
		AddDefLoc("License for 'RePacker Tools' or 'Game Modding' or 'Unpacker Studio' not activated!");
		AddDefLoc("License for 'Unpacker Studio' not activated!");
		AddDefLoc("License for 'Unpacker Studio' not activated!");
		AddDefLoc("License for 'Unpacker Studio' not activated!");
		AddDefLoc("License for 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("Saving is possible 1 time in 2 minutes");
		AddDefLoc("License for 'Unpacker tools' or 'RePacker Tools' or 'Game Modding' or 'Unpacker Studio' or 'Android Unpacker' not activated!");
		AddDefLoc("Is Demo Version");
		AddDefLoc(" DEMO-CONSOLE!");
		AddDefLoc("Wait... Check internet connection.. https://devxdevelopment.com...");
		AddDefLoc("The version is obsolete. Need to install a new version.");
		AddDefLoc(" (Internal!)");
		AddDefLoc("For save changes to assets: press to button 'Apply changes'");
		AddDefLoc("License for 'RePacker Tools' or 'Game Modding' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("Items: \n");
		AddDefLoc("Assets Bundle\n");
		AddDefLoc("IL2CPP-Code");
		AddDefLoc("License for 'RePacker Tools' or 'Game Modding' or 'Unpacker Studio' not activated!");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Dont select GameObject!");
		AddDefLoc("Dont select MeshAsset");
		AddDefLoc("License for 'Unpacker tools' or 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Dont select MeshAsset");
		AddDefLoc("License for 'Unpacker tools' or 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for  'Unpacker Tools' or 'Repacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for  'Unpacker Tools' or 'Repacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Dont select MeshAsset");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Project protected by");
		AddDefLoc("Unsupported format");
		AddDefLoc("Exported to ");
		AddDefLoc("Wait... Extract audio..");
		AddDefLoc("You can save with conversion no more than once every two minutes.");
		AddDefLoc("Exported to ");
		AddDefLoc("Unsupported format");
		AddDefLoc("Unsupported format");
		AddDefLoc("Wait... Extract audio..");
		AddDefLoc("Exported to ");
		AddDefLoc("Unsupported format");
		AddDefLoc("Unsupported format");
		AddDefLoc("Wait... Extract audio..");
		AddDefLoc("Exported to ");
		AddDefLoc("Unsupported format");
		AddDefLoc("Unsupported format");
		AddDefLoc("You can save with conversion no more than once every two minutes.");
		AddDefLoc("You can save with conversion no more than once every two minutes.");
		AddDefLoc("You can save with conversion no more than once every two minutes.");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for 'Unpacker tools' or 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for 'Unpacker tools' or 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for 'Unpacker tools' or 'Android Unpacker' or 'RePacker Tools' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("An error occurred while connecting to the server,\r\nplease check the network status and website availability of devxdevelopment.com\r\nand try again later.");
		AddDefLoc("License for  'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Not selected owner asset to create GameObjext");
		AddDefLoc("Only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("Only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("Only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("Not selected asset to copy (Copy asset)");
		AddDefLoc("Selected items are not supported for copying.");
		AddDefLoc("Not support for add child component.");
		AddDefLoc("Only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("Only available for 'DevX-GameRecovery' or 'DevX-GameModing' license type.");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Not supported for this asset type");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Not supported for this asset type");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("The file extension must match");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Object - not supported replace");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Item not support export");
		AddDefLoc("You can save with conversion no more than once every two minutes.");
		AddDefLoc("Item not support export");
		AddDefLoc("Item not support export");
		AddDefLoc("License for 'RePacker Tools' or 'Android Unpacker' or 'Unpacker Studio' or 'GameRecovery' not activated!");
		AddDefLoc("License for  'GameRecovery' not activated!");
		AddDefLoc("Error on Parse assembly ");
		AddDefLoc("Parse - ok");
		AddDefLoc("Wait... Parse assembly ");
		AddDefLoc("Wait... Image compression... This may take a few minutes");
		AddDefLoc("Search result count:");
		AddDefLoc(" sec");
		AddDefLoc("Examples");
		AddDefLoc("Functions");
		AddDefLoc("Help:");
		AddDefLoc("toolStrip3");
		AddDefLoc("Execute time:");
		AddDefLoc("Break");
		AddDefLoc("Save result");
		AddDefLoc("Result:");
		AddDefLoc("toolStrip2");
		AddDefLoc("Help");
		AddDefLoc("Save code");
		AddDefLoc("Open");
		AddDefLoc("Execute");
		AddDefLoc("DevXC code: ");
		AddDefLoc("toolStrip1");
		AddDefLoc(" sec");
		AddDefLoc(" sec");
		AddDefLoc("Save rules");
		AddDefLoc("label2");
		AddDefLoc("Break");
		AddDefLoc("Show offset");
		AddDefLoc("Save result");
		AddDefLoc("Result:");
		AddDefLoc("toolStrip2");
		AddDefLoc("Auto apply");
		AddDefLoc("Open rules file");
		AddDefLoc("Apply");
		AddDefLoc("Parce rules: ");
		AddDefLoc("toolStrip1");
		AddDefLoc("label1");
		AddDefLoc("Open binary analyzer");
		AddDefLoc("Col:");
		AddDefLoc("Line:");
		AddDefLoc("statusStrip1");
		AddDefLoc("Save to HEX dump");
		AddDefLoc("Save selection");
		AddDefLoc("Find");
		AddDefLoc("Go");
		AddDefLoc("Position");
		AddDefLoc("toolStrip2");
		AddDefLoc("DevXC Control");
		AddDefLoc("Binary Analyzer Tools");
		AddDefLoc("Open binary file");
		AddDefLoc("toolStrip1");
		AddDefLoc("Make temp key...");
		AddDefLoc("Proxy settings");
		AddDefLoc("Proxy Authentication");
		AddDefLoc("Cancel");
		AddDefLoc("OK");
		AddDefLoc("Password:");
		AddDefLoc("User:");
		AddDefLoc("port:");
		AddDefLoc("Proxy address:");
		AddDefLoc("Proxy connection");
		AddDefLoc("License Information");
		AddDefLoc("Open buy page");
		AddDefLoc("Activate license..");
		AddDefLoc("License Number");
		AddDefLoc("License State");
		AddDefLoc("License key:");
		AddDefLoc("Not activated!");
		AddDefLoc("Activation - ok");
		AddDefLoc("License - valid.");
		AddDefLoc("License - not valid!");
		AddDefLoc("PropertyDialog");
		AddDefLoc("OK");
		AddDefLoc("Cancel");
		AddDefLoc("label1");
		AddDefLoc("FbxExportSettings");
		AddDefLoc("Export textures");
		AddDefLoc("Export animations");
		AddDefLoc("Binary");
		AddDefLoc("ASCII");
		AddDefLoc("Export models");
		AddDefLoc("Options");
		AddDefLoc("OK");
		AddDefLoc("Export format");
		AddDefLoc("Select object");
		AddDefLoc("FullName");
		AddDefLoc("Asset class name");
		AddDefLoc("Status");
		AddDefLoc("statusStrip1");
		AddDefLoc("Type");
		AddDefLoc("Name");
		AddDefLoc("ID");
		AddDefLoc("label1");
		AddDefLoc("Double click of item - for apply select");
		AddDefLoc("Name");
		AddDefLoc("ID");
		AddDefLoc("Filter");
		AddDefLoc("Filter (show/hide)");
		AddDefLoc("Break");
		AddDefLoc("Clear");
		AddDefLoc("Find");
		AddDefLoc("toolStrip5");
		AddDefLoc("Begin search...");
		AddDefLoc("Game database search form (Full access by subscription)");
		AddDefLoc("Descriptions");
		AddDefLoc("Open game web page");
		AddDefLoc("Open game structure preview");
		AddDefLoc("Download and open game (WebGL, OSGJS)");
		AddDefLoc("Всего 0");
		AddDefLoc("Status");
		AddDefLoc("statusStrip1");
		AddDefLoc("Set free acess");
		AddDefLoc("Hide item");
		AddDefLoc("Game size");
		AddDefLoc("Category");
		AddDefLoc("Company");
		AddDefLoc("Preview size");
		AddDefLoc("Engine version");
		AddDefLoc("Game version");
		AddDefLoc("Engine");
		AddDefLoc("Platform");
		AddDefLoc("Name");
		AddDefLoc("label1");
		AddDefLoc("Double click of item - for show on main tree view");
		AddDefLoc("Name");
		AddDefLoc("Platform type");
		AddDefLoc("Free access");
		AddDefLoc("Engine type");
		AddDefLoc("Engine version");
		AddDefLoc("Company");
		AddDefLoc("Category");
		AddDefLoc("AppId");
		AddDefLoc("Only IL2CPP");
		AddDefLoc("Only .NET Assembly");
		AddDefLoc("Filter");
		AddDefLoc("Subscription expiration:");
		AddDefLoc("Subscription payment");
		AddDefLoc("Filter (show/hide)");
		AddDefLoc("Clear");
		AddDefLoc("Find");
		AddDefLoc("toolStrip5");
		AddDefLoc("Begin download game information...");
		AddDefLoc("You do not have a subscription to access to the Games database.");
		AddDefLoc("License not activated! Subscription available only with license!");
		AddDefLoc("Begin request...");
		AddDefLoc("Begin search...");
		AddDefLoc("End search");
		AddDefLoc("Unity project generate options");
		AddDefLoc("OK");
		AddDefLoc("This option enables automatic conversion of compiled shaders to Unity format (ShaderLab)");
		AddDefLoc("Restore shaders as raw (with out convert, nead manualy correct, manual fix required)");
		AddDefLoc("Restore shader as Unity ShaderLab format (for GameRecovery license type)");
		AddDefLoc("Replace with Unity build-in shaders");
		AddDefLoc("Shader options");
		AddDefLoc("Filter by shader name:");
		AddDefLoc("Use right click on tree for change export type:");
		AddDefLoc("Replace with Unity build-in shaders");
		AddDefLoc("Restore shader as RAW (manual fix required)\"");
		AddDefLoc("Restore with convert to Unity ShaderLab");
		AddDefLoc("Reset");
		AddDefLoc("Shader list");
		AddDefLoc("Shader export options");
		AddDefLoc("Project options");
		AddDefLoc("Disable header information for scripts (header on .cs files)");
		AddDefLoc("Script generate options");
		AddDefLoc("Allow delayed extraction of scripts");
		AddDefLoc("Remove script class (for exported to .cs) from plugin");
		AddDefLoc("Filter by class name:");
		AddDefLoc("Remove from decompilation");
		AddDefLoc("Class to script");
		AddDefLoc("Exclude");
		AddDefLoc("As Plugin (.dll)");
		AddDefLoc("As Scripts (.cs)");
		AddDefLoc("Reset");
		AddDefLoc("toolStrip1");
		AddDefLoc("Remove from decompilation scripts");
		AddDefLoc("Mark class to decompilation (.cs)");
		AddDefLoc("Exclude from project");
		AddDefLoc("Set as Plugin (.dll)");
		AddDefLoc("Set as Script assembly (.cs)");
		AddDefLoc("Reset");
		AddDefLoc("multiSelectTreeView21");
		AddDefLoc("Scripts");
		AddDefLoc("Override Unity version:");
		AddDefLoc("Unity Project Version");
		AddDefLoc("Make direct MeshAsset (else Mesh by .obj file)");
		AddDefLoc("Make all GameObjects as Active (override)");
		AddDefLoc("Allow async export");
		AddDefLoc("When you enable async options, it will be faster, but errors are possible!");
		AddDefLoc("Export multi sprite texture as separate sprite files");
		AddDefLoc("Disable append bundle path to asset");
		AddDefLoc("Scene params");
		AddDefLoc("Path to executable file, parameters on run: \"assembly_name.dll\" -p -o \"output_dir\"");
		AddDefLoc("Decompiler type");
		AddDefLoc(".NET assembly script decompilation");
		AddDefLoc("CompillerTypeGenerated_Clear");
		AddDefLoc("Script decompilation options");
		AddDefLoc("UsingDeclarations");
		AddDefLoc("QueryExpressions");
		AddDefLoc("ObjectOrCollectionInitializers");
		AddDefLoc("MakeAssignmentExpressions");
		AddDefLoc("FullyQualifyAmbiguousTypeNames");
		AddDefLoc("ExpressionTrees");
		AddDefLoc("AutomaticProperties");
		AddDefLoc("AutomaticEvents");
		AddDefLoc("SwitchStatementOnString");
		AddDefLoc("YieldReturn");
		AddDefLoc("AnonymousMethods");
		AddDefLoc("Only available for DevX GameRecovery license type.");
		AddDefLoc("Only available for DevX GameRecovery license type.");
		AddDefLoc("as plugin (.dll)");
		AddDefLoc("as plugin (.dll)");
		AddDefLoc(" make plugin (.dll)");
		AddDefLoc("Partial recovery of scripts is available only with the 'Allow delayed extraction of scripts'.");
		AddDefLoc("Partial recovery of scripts is available only with the 'Allow delayed extraction of scripts'.");
		AddDefLoc("Only available for DevX GameRecovery license type.");
		AddDefLoc("Built in shaders (fixed):");
		AddDefLoc("Built in shaders (recommendation):");
		AddDefLoc("Raw Shader:");
		AddDefLoc("ShaderLab:");
		AddDefLoc("Search form");
		AddDefLoc("Status");
		AddDefLoc("statusStrip1");
		AddDefLoc("Offset in asset");
		AddDefLoc("Type");
		AddDefLoc("Name");
		AddDefLoc("ID");
		AddDefLoc("label1");
		AddDefLoc("Double click of item - for show on main tree view");
		AddDefLoc("Content Value");
		AddDefLoc("Search as text");
		AddDefLoc("Search as HEX");
		AddDefLoc("Name");
		AddDefLoc("Asset class name");
		AddDefLoc("ID");
		AddDefLoc("Include Search in Scripts (c# script content)");
		AddDefLoc("Reference for asset");
		AddDefLoc("Filter");
		AddDefLoc("Filter (show/hide)");
		AddDefLoc("Break");
		AddDefLoc("Clear");
		AddDefLoc("Find");
		AddDefLoc("toolStrip5");
		AddDefLoc("Begin search...");
		AddDefLoc("APKSigner Dialog - required JDK");
		AddDefLoc("Make apk");
		AddDefLoc("keytool path");
		AddDefLoc("jarsigner path");
		AddDefLoc("zipalign path");
		AddDefLoc("JDK installer link");
		AddDefLoc("Paths");
		AddDefLoc("Create temp key");
		AddDefLoc("Select custom key");
		AddDefLoc("Keystore file");
		AddDefLoc("Key alias");
		AddDefLoc("Key password");
		AddDefLoc("NDName");
		AddDefLoc("Store password");
		AddDefLoc("Without signature (apk without signature - can not be installed on the device)");
		AddDefLoc("Keystore ");
		AddDefLoc("zipalign.exe");
		AddDefLoc("C:\\Program Files\\Java\\jdk1.8.0_65\\bin\\jarsigner.exe");
		AddDefLoc("C:\\Program Files\\Java\\jdk1.8.0_65\\bin\\keytool.exe");
		AddDefLoc("Enter text");
		AddDefLoc("OK");
		AddDefLoc("ImportSettings");
		AddDefLoc("Additional Log");
		AddDefLoc("When you enable async options, it will be faster, but errors are possible!");
		AddDefLoc("Speed options");
		AddDefLoc("With export resources");
		AddDefLoc("With generate project");
		AddDefLoc("Disable сustom swap file (in file stream)");
		AddDefLoc("Temp directory");
		AddDefLoc("Disable auto-fix sources");
		AddDefLoc("Allow to de-obfuscate assembly");
		AddDefLoc("Path to executable file, parameters on run: \"assembly_name.dll\" -p -o \"output_dir\"");
		AddDefLoc("Decompiler type:");
		AddDefLoc(".NET assembly script decompilation");
		AddDefLoc("With debug windows");
		AddDefLoc("Show debug log");
		AddDefLoc("OK");
		AddDefLoc("Decompiler type:");
		AddDefLoc("IL2CPP Restore Script settings");
		AddDefLoc("Fast open (fast generate project)");
		AddDefLoc("Async parse of Bundle");
		AddDefLoc("Async parse of Assets");
		AddDefLoc("Async make of Assets");
		AddDefLoc("Bundle auto extract");
		AddDefLoc("Saving RAM (export slower)");
		AddDefLoc("Cache time in seconds:");
		AddDefLoc("Import bundle as Level");
		AddDefLoc("Ignore scenes");
		AddDefLoc("Ignore StreamingAssets directory");
		AddDefLoc("Memory limit (Mb):");
		AddDefLoc("Allow restore shader as UnityLab format (for GameRecovery license type)");
		AddDefLoc("This option enables automatic conversion of compiled shaders to Unity format (UnityLab)");
		AddDefLoc("Asset settings");
		AddDefLoc("Only available for DevX GameRecovery license type.");
		AddDefLoc("Only available for DevX GameRecovery license type.");
		AddDefLoc("Debug log form");
		AddDefLoc("Break");
		AddDefLoc("Clear");
		AddDefLoc("Save as RTF");
		AddDefLoc("Save as txt");
		AddDefLoc("toolStrip5");
		AddDefLoc("test");
		AddDefLoc("EditText");
		AddDefLoc("Save text");
		AddDefLoc("None");
		AddDefLoc("\n// This project used IL2CPP, assembly converted to native code.");
		_0020_000A_000A_000A_000A_0020_000A_000A = false;
		_0020_000A_000A_000A_0020_000A_000A_000A = new List<Action>();
		_0020_000A_000A_000A_0020_000A_000A_0020 = new Dictionary<string, string>();
		_0020_000A_000A_000A_000A_0020_0020_0020 = new Dictionary<int, string>();
		_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-def");
		_0020_000A_000A_000A_000A_0020_0020_000A = _0020_000A_000A_000A_000A_0020_0020_0020;
		_0020_000A_000A_000A_000A_0020_0020_0020 = new Dictionary<int, string>();
		_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A();
	}

	internal static void AddDefLoc(string _0020)
	{
		if (_0020_000A_000A_000A_000A_0020_000A_0020 == null)
		{
			_0020_000A_000A_000A_000A_0020_000A_0020 = new Dictionary<int, string>();
		}
		_0020_000A_000A_000A_000A_0020_000A_0020[(int)_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020)] = _0020;
	}

	internal static string CalcHash(string _0020)
	{
		return TryGetTranslated((int)_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020));
	}

	internal static int _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A(string _0020)
	{
		return (int)_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(_0020);
	}

	internal static string TryGetTranslated(int _0020)
	{
		if (_0020 == 0)
		{
			return null;
		}
		if (_0020_000A_000A_000A_000A_0020_0020_0020 != null && _0020_000A_000A_000A_000A_0020_0020_0020.ContainsKey(_0020))
		{
			return _0020_000A_000A_000A_000A_0020_0020_0020[_0020];
		}
		if (_0020_000A_000A_000A_000A_0020_0020_000A != null && _0020_000A_000A_000A_000A_0020_0020_000A.ContainsKey(_0020))
		{
			return _0020_000A_000A_000A_000A_0020_0020_000A[_0020];
		}
		if (_0020_000A_000A_000A_000A_0020_000A_0020 != null && _0020_000A_000A_000A_000A_0020_000A_0020.ContainsKey(_0020))
		{
			return _0020_000A_000A_000A_000A_0020_000A_0020[_0020];
		}
		return null;
	}

	internal static bool _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A(string _0020)
	{
		_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020("LocalizationTools.localization_name", _0020);
		_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A();
		for (int num = _0020_000A_000A_000A_0020_000A_000A_000A.Count - 1; num >= 0; num--)
		{
			_0020_000A_000A_000A_0020_000A_000A_000A[num]();
		}
		return true;
	}

	internal static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020()
	{
		string text = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A("LocalizationTools.localization_name");
		if (string.IsNullOrEmpty(text))
		{
			text = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020();
		}
		return text;
	}

	internal static string[] _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A()
	{
		List<string> list = new List<string>();
		try
		{
			if (_0020_000A_000A_000A_000A_0020_000A_000A)
			{
				string[] array = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020();
				foreach (string item in array)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}
			else
			{
				try
				{
					string[] array = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A();
					foreach (string item2 in array)
					{
						if (!list.Contains(item2))
						{
							list.Add(item2);
						}
					}
				}
				catch
				{
				}
				try
				{
					string[] array = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020();
					foreach (string item3 in array)
					{
						if (!list.Contains(item3))
						{
							list.Add(item3);
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		list.Sort();
		list.Insert(0, "def");
		return list.ToArray();
	}

	internal static string[] _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020()
	{
		List<string> list = new List<string>();
		try
		{
			string[] array = _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A(null);
			if (array != null)
			{
				string[] array2 = array;
				foreach (string text in array2)
				{
					int num = text.LastIndexOf("Localization-");
					if (num >= 0 && text.EndsWith(".txt"))
					{
						string text2 = text.Substring(num + "Localization-".Length);
						if (text2.EndsWith(".txt"))
						{
							text2 = text2.Substring(0, text2.Length - ".txt".Length);
						}
						if (!list.Contains(text2) && text2 != "def")
						{
							list.Add(text2);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list.ToArray();
	}

	internal static string[] _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A()
	{
		List<string> list = new List<string>();
		try
		{
			string text = null;
			try
			{
				text = (text ?? _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A());
			}
			catch
			{
			}
			try
			{
				text = (text ?? _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020());
			}
			catch
			{
			}
			try
			{
				text = (text ?? _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A());
			}
			catch
			{
			}
			if (!string.IsNullOrEmpty(text))
			{
				List<string> list2 = new List<string>();
				if (Directory.Exists(text))
				{
					string[] files = Directory.GetFiles(text, "Localization-*.txt", SearchOption.TopDirectoryOnly);
					foreach (string item in files)
					{
						list2.Add(item);
					}
				}
				string path = Path.Combine(text, "Localization");
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path, "Localization-*.txt", SearchOption.TopDirectoryOnly);
					foreach (string item2 in files)
					{
						list2.Add(item2);
					}
				}
				path = Path.Combine(text, "Language");
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path, "Localization-*.txt", SearchOption.TopDirectoryOnly);
					foreach (string item3 in files)
					{
						list2.Add(item3);
					}
				}
				foreach (string item4 in list2)
				{
					int num = item4.LastIndexOf("Localization-");
					if (num >= 0 && item4.EndsWith(".txt"))
					{
						string text2 = item4.Substring(num + "Localization-".Length);
						if (text2.EndsWith(".txt"))
						{
							text2 = text2.Substring(0, text2.Length - ".txt".Length);
						}
						if (!list.Contains(text2) && text2 != "def")
						{
							list.Add(text2);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list.ToArray();
	}

	internal static void _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020(Action _0020)
	{
		if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A(_0020) == null)
		{
			_0020_000A_000A_000A_0020_000A_000A_000A.Add(_0020);
		}
	}

	internal static void _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A(Action _0020)
	{
		Action action = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A(_0020);
		if (action != null)
		{
			_0020_000A_000A_000A_0020_000A_000A_000A.Remove(action);
		}
	}

	internal static bool _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020(string _0020)
	{
		if (_0020_000A_000A_000A_000A_0020_0020_0020 == null)
		{
			_0020_000A_000A_000A_000A_0020_0020_0020 = new Dictionary<int, string>();
		}
		else
		{
			_0020_000A_000A_000A_000A_0020_0020_0020.Clear();
		}
		if (_0020 != null)
		{
			string[] array = _0020.Split('\r', '\n');
			foreach (string text in array)
			{
				if (string.IsNullOrEmpty(text) || text.StartsWith("//"))
				{
					continue;
				}
				int num = -1;
				for (int j = 1; j < text.Length; j++)
				{
					if (text[j] == '|' && text[j - 1] != '\\')
					{
						num = j;
						break;
					}
				}
				if (num > 0 && num != text.Length)
				{
					string text2 = text.Substring(0, num);
					string value = text.Substring(num + 1).Replace("\\r", "\r").Replace("\\n", "\n")
						.Replace("\\t", "\t");
					int result = 0;
					if (int.TryParse(text2, NumberStyles.HexNumber, null, out result))
					{
						_0020_000A_000A_000A_000A_0020_0020_0020[result] = value;
						continue;
					}
					result = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A(text2.Replace("\\|", "|"));
					_0020_000A_000A_000A_000A_0020_0020_0020[result] = value;
				}
			}
			return true;
		}
		return false;
	}

	internal static void _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A()
	{
		if (_0020_000A_000A_000A_000A_0020_0020_0020 == null)
		{
			_0020_000A_000A_000A_000A_0020_0020_0020 = new Dictionary<int, string>();
		}
		else
		{
			_0020_000A_000A_000A_000A_0020_0020_0020.Clear();
		}
		string text = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A("LocalizationTools.localization_name");
		if (!string.IsNullOrEmpty(text))
		{
			if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + text))
			{
				return;
			}
			if (text.Contains("-"))
			{
				string str = text.Split('-')[0].Trim();
				if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + str))
				{
					return;
				}
			}
			if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + text + "-auto"))
			{
				return;
			}
			if (text.Contains("-"))
			{
				string str2 = text.Split('-')[0].Trim();
				if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Default/Localization-" + str2 + "-auto"))
				{
					return;
				}
			}
		}
		else
		{
			if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020()) || _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020() + "-auto"))
			{
				return;
			}
			string str3 = Thread.CurrentThread.CurrentCulture.Name.Split("-".ToCharArray())[0].ToUpper();
			if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + str3) || _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-" + str3 + "-auto"))
			{
				return;
			}
		}
		if (!_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-EN"))
		{
			_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020("Localization-EN-auto");
		}
	}

	internal static bool _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020(string _0020)
	{
		string text = null;
		if (_0020_000A_000A_000A_000A_0020_000A_000A)
		{
			try
			{
				if (text == null)
				{
					text = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
				}
			}
			catch
			{
			}
		}
		else
		{
			try
			{
				if (text == null)
				{
					text = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020(_0020);
				}
			}
			catch
			{
			}
			try
			{
				if (text == null)
				{
					text = _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A(_0020);
				}
			}
			catch
			{
			}
		}
		if (text == null)
		{
			return false;
		}
		if (_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020(text))
		{
			text = _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A(text, null);
		}
		return _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020(text);
	}

	internal static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A(string _0020)
	{
		string resourceStreamString = _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A.GetResourceStreamString(null, _0020);
		if (resourceStreamString == null)
		{
			resourceStreamString = _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A.GetResourceStreamString(null, _0020 + ".txt");
		}
		return resourceStreamString;
	}

	internal static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020(string _0020)
	{
		string text = null;
		try
		{
			text = (text ?? _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A());
		}
		catch
		{
		}
		try
		{
			text = (text ?? _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020());
		}
		catch
		{
		}
		try
		{
			text = (text ?? _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A());
		}
		catch
		{
		}
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string text2 = Path.Combine(text, _0020);
			if (File.Exists(text2))
			{
				return File.ReadAllText(text2);
			}
			if (File.Exists(text2 + ".txt"))
			{
				return File.ReadAllText(text2 + ".txt");
			}
			text2 = Path.Combine(text, Path.Combine("Localization", _0020));
			if (File.Exists(text2))
			{
				return File.ReadAllText(text2);
			}
			if (File.Exists(text2 + ".txt"))
			{
				return File.ReadAllText(text2 + ".txt");
			}
			text2 = Path.Combine(text, Path.Combine("Language", _0020));
			if (File.Exists(text2))
			{
				return File.ReadAllText(text2);
			}
			if (File.Exists(text2 + ".txt"))
			{
				return File.ReadAllText(text2 + ".txt");
			}
		}
		catch
		{
		}
		return null;
	}

	private static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A()
	{
		try
		{
			if (_0020_000A_000A_000A_0020_000A_0020_000A != null)
			{
				return _0020_000A_000A_000A_0020_000A_0020_000A;
			}
			_0020_000A_000A_000A_0020_000A_0020_000A = Path.GetDirectoryName(Assembly.Load("System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089").GetType("System.Windows.Forms.Application").GetProperty("ExecutablePath", BindingFlags.Static | BindingFlags.Public)
				.GetValue(null, null)?.ToString());
			return _0020_000A_000A_000A_0020_000A_0020_000A;
		}
		catch
		{
		}
		return null;
	}

	private static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020()
	{
		try
		{
			return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
		}
		catch
		{
		}
		return null;
	}

	private static string _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A()
	{
		try
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			if (string.IsNullOrEmpty(codeBase) || (codeBase.Contains("GAC") && codeBase.Contains("mscorlib") && codeBase.Contains("Microsoft.Net")))
			{
				return null;
			}
			if (!string.IsNullOrEmpty(codeBase))
			{
				return Path.GetDirectoryName(codeBase.Replace("file:///", ""));
			}
		}
		catch
		{
		}
		return null;
	}

	internal static uint _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(string _0020)
	{
		if (string.IsNullOrEmpty(_0020))
		{
			return 123u;
		}
		int num = 0;
		int num2 = 352654597;
		int num3 = num2;
		for (int num4 = _0020.Length; num4 > 0; num4 -= 4)
		{
			num2 = ((num + 1 < _0020.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(_0020[num] | ((uint)_0020[num + 1] << 16))) : ((num >= _0020.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ _0020[num])));
			if (num4 <= 2)
			{
				break;
			}
			num += 2;
			num3 = ((num + 1 >= _0020.Length) ? ((num >= _0020.Length) ? (((num3 << 5) + num3 + (num3 >> 27)) ^ 0) : (((num3 << 5) + num3 + (num3 >> 27)) ^ _0020[num])) : (((num3 << 5) + num3 + (num3 >> 27)) ^ (int)(_0020[num] | ((uint)_0020[num + 1] << 16))));
			num += 2;
		}
		return (uint)(num2 + num3 * 1566083941);
	}

	internal static Action _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A(Action _0020)
	{
		for (int num = _0020_000A_000A_000A_0020_000A_000A_000A.Count - 1; num >= 0; num--)
		{
			Action action = _0020_000A_000A_000A_0020_000A_000A_000A[num];
			if (action.Target == _0020.Target)
			{
				return action;
			}
		}
		return null;
	}
}
