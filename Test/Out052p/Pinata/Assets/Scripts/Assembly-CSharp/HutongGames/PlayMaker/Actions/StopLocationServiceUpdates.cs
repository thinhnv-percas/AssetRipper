using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7559B0", Offset = "0x7559B0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7559B0", Offset = "0x7559B0")]
	[Token(Token = "0x20001D0")]
	public class StopLocationServiceUpdates : FsmStateAction
	{
		[Token(Token = "0x60009A9")]
		[Address(RVA = "0x99E4DC", Offset = "0x99E4DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x60009AA")]
		[Address(RVA = "0x99E4E0", Offset = "0x99E4E0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_location();\n\tUnityEngine.LocationService::Stop(v11);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			LocationService location = Input.location;
			location.Stop();
			Finish();
		}

		[Token(Token = "0x60009AB")]
		[Address(RVA = "0x99E51C", Offset = "0x99E51C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StopLocationServiceUpdates()
		{
		}
	}
}
