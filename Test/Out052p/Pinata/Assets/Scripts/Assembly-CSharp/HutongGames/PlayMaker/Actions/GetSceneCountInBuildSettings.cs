using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CB60", Offset = "0x75CB60")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75CB60", Offset = "0x75CB60")]
	[Token(Token = "0x2000329")]
	public class GetSceneCountInBuildSettings : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C6158", Offset = "0x7C6158")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C6158", Offset = "0x7C6158")]
		[Token(Token = "0x4001A22")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt sceneCountInBuildSettings;

		[Token(Token = "0x6000FD9")]
		[Address(RVA = "0xA349D0", Offset = "0xA349D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneCountInBuildSettings = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sceneCountInBuildSettings = null;
		}

		[Token(Token = "0x6000FDA")]
		[Address(RVA = "0xA349D8", Offset = "0xA349D8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneCountInBuildSettings::DoGetSceneCountInBuildSettings(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSceneCountInBuildSettings();
			Finish();
		}

		[Token(Token = "0x6000FDB")]
		[Address(RVA = "0xA34A00", Offset = "0xA34A00", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.sceneCountInBuildSettings;\n\tv11 = UnityEngine.SceneManagement.SceneManager::get_sceneCountInBuildSettings();\n\tv8.value = v11;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneCountInBuildSettings()
		{
			FsmInt fsmInt = sceneCountInBuildSettings;
			int value = SceneManager.sceneCountInBuildSettings;
			fsmInt.Value = value;
		}

		[Token(Token = "0x6000FDC")]
		[Address(RVA = "0xA34A34", Offset = "0xA34A34", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneCountInBuildSettings()
		{
		}
	}
}
