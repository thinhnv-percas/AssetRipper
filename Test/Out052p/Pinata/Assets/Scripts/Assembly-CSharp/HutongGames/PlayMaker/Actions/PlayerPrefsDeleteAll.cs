using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B180", Offset = "0x75B180")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75B180", Offset = "0x75B180")]
	[Token(Token = "0x20002DE")]
	public class PlayerPrefsDeleteAll : FsmStateAction
	{
		[Token(Token = "0x6000E62")]
		[Address(RVA = "0xB1A288", Offset = "0xB1A288", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000E63")]
		[Address(RVA = "0xB1A28C", Offset = "0xB1A28C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PlayerPrefs::DeleteAll();\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			PlayerPrefs.DeleteAll();
			Finish();
		}

		[Token(Token = "0x6000E64")]
		[Address(RVA = "0xB1A2B8", Offset = "0xB1A2B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsDeleteAll()
		{
		}
	}
}
