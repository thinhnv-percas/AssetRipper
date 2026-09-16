using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CCF0", Offset = "0x75CCF0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CCF0", Offset = "0x75CCF0")]
	[Token(Token = "0x200032E")]
	public class GetSceneName : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C6824", Offset = "0x7C6824")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6824", Offset = "0x7C6824")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6824", Offset = "0x7C6824")]
		[Token(Token = "0x4001A38")]
		[FieldOffset(Offset = "0x90")]
		public FsmString name;

		[Token(Token = "0x6000FEF")]
		[Address(RVA = "0xA3504C", Offset = "0xA3504C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneName)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneName)+84]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneName)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneName)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.name = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			name = null;
		}

		[Token(Token = "0x6000FF0")]
		[Address(RVA = "0xA3508C", Offset = "0xA3508C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneName::DoGetSceneName(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneName();
			Finish();
		}

		[Token(Token = "0x6000FF1")]
		[Address(RVA = "0xA350BC", Offset = "0xA350BC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002B;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.name);\n\tv65 = v21 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0024;\n\tv67 = this.name;\n\tv73 = this + 0x88;\n\tv70 = 0x10D454C(v73, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv67.value = v70;\nL_0024:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneName()
		{
			//IL_0068: Expected O, but got I
			if (_sceneFound)
			{
				if (!name.IsNone)
				{
					FsmString fsmString = name;
					object obj = (long)(IntPtr)this + 136L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
					string value = default(string);
					fsmString.Value = value;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FF2")]
		[Address(RVA = "0xA35134", Offset = "0xA35134", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneName()
		{
		}
	}
}
