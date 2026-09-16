using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Serializable]
	[Token(Token = "0x2000002")]
	public class AppStoreSettings : ScriptableObject
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x18")]
		public string UnityProjectID;

		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x20")]
		public string UnityClientID;

		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x28")]
		public string UnityClientKey;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x30")]
		public string UnityClientRSAPublicKey;

		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x38")]
		public string AppName;

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x40")]
		public string AppSlug;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x48")]
		public string AppItemId;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x50")]
		public string Permission;

		[Token(Token = "0x4000009")]
		internal const string resourceFileName = "UDP Settings";

		[Token(Token = "0x400000A")]
		public const string appStoreSettingsAssetFolder = "Assets/Plugins/UDP/Resources";

		[Token(Token = "0x400000B")]
		public const string appStoreSettingsAssetPath = "Assets/Plugins/UDP/Resources/UDP Settings.asset";

		[Token(Token = "0x400000C")]
		public const string appStoreSettingsPropFolder = "Assets/Plugins/Android/assets";

		[Token(Token = "0x400000D")]
		public const string appStoreSettingsPropPath = "Assets/Plugins/Android/assets/GameSettings.prop";

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x15C6DD8", Offset = "0x15C6DD8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDE3D0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299AB]) = v38;\nL_0018:\n\tthis.UnityProjectID = \"\";\n\tthis.UnityClientID = \"\";\n\tthis.UnityClientKey = \"\";\n\tthis.UnityClientRSAPublicKey = \"\";\n\tthis.AppName = \"\";\n\tthis.AppSlug = \"\";\n\tthis.AppItemId = \"\";\n\tthis.Permission = \"\";\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppStoreSettings()
		{
			UnityProjectID = "";
			UnityClientID = "";
			UnityClientKey = "";
			UnityClientRSAPublicKey = "";
			AppName = "";
			AppSlug = "";
			AppItemId = "";
			Permission = "";
		}
	}
}
