using System.IO;
using Cpp2ILInjected;
using Newtonsoft.Json;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000380")]
	public static class ManifestWriter
	{
		[Token(Token = "0x6000EAC")]
		[Address(RVA = "0x3F167C8", Offset = "0x3F167C8", Length = "0x7C")]
		public static void Write(string path, GenerationManifest manifest)
		{
			string contents = JsonConvert.SerializeObject(manifest, Formatting.Indented);
			File.WriteAllText(path, contents);
		}

		[Token(Token = "0x6000EAD")]
		[Address(RVA = "0x3F16844", Offset = "0x3F16844", Length = "0xC4")]
		public static GenerationManifest Read(string path)
		{
			if (File.Exists(path))
			{
				string value = File.ReadAllText(path);
				return JsonConvert.DeserializeObject<GenerationManifest>(value);
			}
			return null;
		}
	}
}
