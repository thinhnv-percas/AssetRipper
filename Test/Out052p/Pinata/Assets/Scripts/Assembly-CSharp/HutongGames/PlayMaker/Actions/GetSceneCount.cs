using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CB10", Offset = "0x75CB10")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75CB10", Offset = "0x75CB10")]
	[Token(Token = "0x2000328")]
	public class GetSceneCount : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7C60C0", Offset = "0x7C60C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C60C0", Offset = "0x7C60C0")]
		[Token(Token = "0x4001A20")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt sceneCount;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C6120", Offset = "0x7C6120")]
		[Token(Token = "0x4001A21")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000FD4")]
		[Address(RVA = "0xA34948", Offset = "0xA34948", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sceneCount = 0;\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			sceneCount = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000FD5")]
		[Address(RVA = "0xA34954", Offset = "0xA34954", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneCount::DoGetSceneCount(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSceneCount();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FD6")]
		[Address(RVA = "0xA349C4", Offset = "0xA349C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneCount::DoGetSceneCount(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneCount();
		}

		[Token(Token = "0x6000FD7")]
		[Address(RVA = "0xA34990", Offset = "0xA34990", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.sceneCount;\n\tv11 = UnityEngine.SceneManagement.SceneManager::get_sceneCount();\n\tv8.value = v11;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneCount()
		{
			FsmInt fsmInt = sceneCount;
			int value = SceneManager.sceneCount;
			fsmInt.Value = value;
		}

		[Token(Token = "0x6000FD8")]
		[Address(RVA = "0xA349C8", Offset = "0xA349C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneCount()
		{
		}
	}
}
