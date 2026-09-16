using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74B798", Offset = "0x74B798")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74B798", Offset = "0x74B798")]
	[Token(Token = "0x2000002")]
	public class GAInitialize : FsmStateAction
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x167A948", Offset = "0x167A948", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x167A94C", Offset = "0x167A94C", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.GameAnalytics::Initialize();\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameAnalytics.Initialize();
			Finish();
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x167A978", Offset = "0x167A978", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GAInitialize()
		{
		}
	}
}
