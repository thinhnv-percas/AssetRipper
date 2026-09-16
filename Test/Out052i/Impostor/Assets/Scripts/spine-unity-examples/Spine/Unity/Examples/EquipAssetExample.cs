using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000037")]
	public class EquipAssetExample : ScriptableObject
	{
		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x18")]
		public EquipSystemExample.EquipType equipType;

		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x20")]
		public Sprite sprite;

		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x28")]
		public string description;

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x30")]
		public int yourStats;

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x15112AC", Offset = "0x15112AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EquipAssetExample()
		{
		}
	}
}
