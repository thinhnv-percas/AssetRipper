using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CAC0", Offset = "0x75CAC0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CAC0", Offset = "0x75CAC0")]
	[Token(Token = "0x2000327")]
	public class GetSceneBuildIndex : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C603C", Offset = "0x7C603C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C603C", Offset = "0x7C603C")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C603C", Offset = "0x7C603C")]
		[Token(Token = "0x4001A1F")]
		[FieldOffset(Offset = "0x90")]
		public FsmInt buildIndex;

		[Token(Token = "0x6000FD0")]
		[Address(RVA = "0xA34858", Offset = "0xA34858", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneBuildIndex)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneBuildIndex)+84]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneBuildIndex)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneBuildIndex)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.buildIndex = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			buildIndex = null;
		}

		[Token(Token = "0x6000FD1")]
		[Address(RVA = "0xA34898", Offset = "0xA34898", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneBuildIndex::DoGetSceneBuildIndex(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneBuildIndex();
			Finish();
		}

		[Token(Token = "0x6000FD2")]
		[Address(RVA = "0xA348C8", Offset = "0xA348C8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002B;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.buildIndex);\n\tv65 = v21 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0024;\n\tv67 = this.buildIndex;\n\tv73 = this + 0x88;\n\tv70 = 0x10D45CC(v73, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv67.value = v70;\nL_0024:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneBuildIndex()
		{
			//IL_0068: Expected O, but got I
			if (_sceneFound)
			{
				if (!buildIndex.IsNone)
				{
					FsmInt fsmInt = buildIndex;
					object obj = (long)(IntPtr)this + 136L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D45CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x158)");
					int value = default(int);
					fsmInt.Value = value;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FD3")]
		[Address(RVA = "0xA34940", Offset = "0xA34940", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneBuildIndex()
		{
		}
	}
}
