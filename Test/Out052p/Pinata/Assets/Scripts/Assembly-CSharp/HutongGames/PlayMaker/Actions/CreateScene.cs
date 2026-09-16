using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CA20", Offset = "0x75CA20")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75CA20", Offset = "0x75CA20")]
	[Token(Token = "0x2000325")]
	public class CreateScene : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C5A40", Offset = "0x7C5A40")]
		[Token(Token = "0x4001A0D")]
		[FieldOffset(Offset = "0x50")]
		public FsmString sceneName;

		[Token(Token = "0x6000FC8")]
		[Address(RVA = "0xA93800", Offset = "0xA93800", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneName = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sceneName = null;
		}

		[Token(Token = "0x6000FC9")]
		[Address(RVA = "0xA93808", Offset = "0xA93808", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmString::get_Value(this.sceneName);\n\tv31 = UnityEngine.SceneManagement.SceneManager::CreateScene(v13);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			string value = sceneName.Value;
			Scene scene = SceneManager.CreateScene(value);
			Finish();
		}

		[Token(Token = "0x6000FCA")]
		[Address(RVA = "0xA93848", Offset = "0xA93848", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CreateScene()
		{
		}
	}
}
