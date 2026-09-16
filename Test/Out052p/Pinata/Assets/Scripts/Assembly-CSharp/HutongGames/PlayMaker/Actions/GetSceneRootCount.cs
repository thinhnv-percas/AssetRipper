using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CDE0", Offset = "0x75CDE0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CDE0", Offset = "0x75CDE0")]
	[Token(Token = "0x2000331")]
	public class GetSceneRootCount : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C6C3C", Offset = "0x7C6C3C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6C3C", Offset = "0x7C6C3C")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6C3C", Offset = "0x7C6C3C")]
		[Token(Token = "0x4001A43")]
		[FieldOffset(Offset = "0x90")]
		public FsmInt rootCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6CC0", Offset = "0x7C6CC0")]
		[Token(Token = "0x4001A44")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x6000FFB")]
		[Address(RVA = "0xA354C0", Offset = "0xA354C0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootCount)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootCount)+84]) = 0;\n\tthis.rootCount = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootCount)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootCount)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			rootCount = null;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			everyFrame = false;
		}

		[Token(Token = "0x6000FFC")]
		[Address(RVA = "0xA35504", Offset = "0xA35504", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneRootCount::DoGetSceneRootCount(this);\n\tv13 = ~this.everyFrame;\n\tif (v13) goto L_0017;\n\treturn;\nL_0017:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneRootCount();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FFD")]
		[Address(RVA = "0xA355C0", Offset = "0xA355C0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneRootCount::DoGetSceneRootCount(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneRootCount();
		}

		[Token(Token = "0x6000FFE")]
		[Address(RVA = "0xA35548", Offset = "0xA35548", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002B;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootCount);\n\tv65 = v21 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0024;\n\tv67 = this.rootCount;\n\tv73 = this + 0x88;\n\tv70 = 0x10D464C(v73, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv67.value = v70;\nL_0024:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneRootCount()
		{
			//IL_0068: Expected O, but got I
			if (_sceneFound)
			{
				if (!rootCount.IsNone)
				{
					FsmInt fsmInt = rootCount;
					object obj = (long)(IntPtr)this + 136L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D464C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x1D8)");
					int value = default(int);
					fsmInt.Value = value;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FFF")]
		[Address(RVA = "0xA355C4", Offset = "0xA355C4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneRootCount()
		{
		}
	}
}
