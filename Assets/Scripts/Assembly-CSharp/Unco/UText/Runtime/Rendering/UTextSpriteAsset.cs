using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.UText.Runtime.Rendering
{
	[CreateAssetMenu(fileName = "UTextSpriteAsset", menuName = "UText/Sprite Asset")]
	[Token(Token = "0x20007B1")]
	public class UTextSpriteAsset : ScriptableObject
	{
		[Tooltip("Texture atlas holding all sprite entries. RGBA; alpha is composited 'over' the text submesh.")]
		[Token(Token = "0x40019A0")]
		[FieldOffset(Offset = "0x18")]
		public Texture2D Atlas;

		[Tooltip("Sprite entries. Name is looked up by <sprite=Name>; index is looked up by <sprite index=N>.")]
		[Token(Token = "0x40019A1")]
		[FieldOffset(Offset = "0x20")]
		public SpriteEntry[] Entries;

		[Tooltip("Optional material override. Null = use a per-atlas instance of UI/Default (UGUI) or Unlit/Transparent (3D), depending on the consumer.")]
		[Token(Token = "0x40019A2")]
		[FieldOffset(Offset = "0x28")]
		public Material SpriteMaterial;

		[NonSerialized]
		[Token(Token = "0x40019A3")]
		[FieldOffset(Offset = "0x30")]
		private Dictionary<string, int> _byName;

		[Token(Token = "0x600206D")]
		[Address(RVA = "0x3D96CF8", Offset = "0x3D96CF8", Length = "0xC0")]
		public static UTextSpriteAsset GetOrDefault(UTextSpriteAsset atlas)
		{
			if (atlas != null)
			{
				return atlas;
			}
			string defaultSpriteAtlasPath = UTextSettings.DefaultSpriteAtlasPath;
			return Resources.Load<UTextSpriteAsset>(defaultSpriteAtlasPath);
		}

		[Token(Token = "0x600206E")]
		[Address(RVA = "0x3D96788", Offset = "0x3D96788", Length = "0x98")]
		public bool TryGetEntryByName(string name, out int index)
		{
			index = default(int);
			EnsureLookup();
			if (_byName != null && _byName.TryGetValue(name, out index))
			{
				return true;
			}
			index = -1;
			return false;
		}

		[Token(Token = "0x600206F")]
		[Address(RVA = "0x3D96BCC", Offset = "0x3D96BCC", Length = "0x64")]
		public bool TryGetEntryByIndex(int index, out SpriteEntry entry)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextSpriteAsset::TryGetEntryByIndex");
			entry = default;
			return default;
		}

		[Token(Token = "0x6002070")]
		[Address(RVA = "0x3D9F6D8", Offset = "0x3D9F6D8", Length = "0x160")]
		internal void EnsureLookup()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UTextSpriteAsset::EnsureLookup");
		}

		[Token(Token = "0x6002071")]
		[Address(RVA = "0x3D9F838", Offset = "0x3D9F838", Length = "0xF4")]
		public UTextSpriteAsset()
		{
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DFF1]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v24 (Il2CppClass<System.EmptyArray`1<Unco.UText.Runtime.Rendering.SpriteEntry>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v5+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			Entries = Array.Empty<SpriteEntry>();
		}
	}
}
