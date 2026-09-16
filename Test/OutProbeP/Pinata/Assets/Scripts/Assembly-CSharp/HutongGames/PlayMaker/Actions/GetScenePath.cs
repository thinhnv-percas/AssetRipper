using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CD40", Offset = "0x75CD40")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CD40", Offset = "0x75CD40")]
	[Token(Token = "0x200032F")]
	public class GetScenePath : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C68A8", Offset = "0x7C68A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C68A8", Offset = "0x7C68A8")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C68A8", Offset = "0x7C68A8")]
		[Token(Token = "0x4001A39")]
		[FieldOffset(Offset = "0x90")]
		public FsmString path;

		[Token(Token = "0x6000FF3")]
		[Address(RVA = "0xA3513C", Offset = "0xA3513C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetScenePath)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetScenePath)+84]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetScenePath)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetScenePath)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.path = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			path = null;
		}

		[Token(Token = "0x6000FF4")]
		[Address(RVA = "0xA3517C", Offset = "0xA3517C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetScenePath::DoGetScenePath(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetScenePath();
			Finish();
		}

		[Token(Token = "0x6000FF5")]
		[Address(RVA = "0xA351AC", Offset = "0xA351AC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002B;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.path);\n\tv65 = v21 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0024;\n\tv67 = this.path;\n\tv73 = this + 0x88;\n\tv70 = 0x10D450C(v73, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv67.value = v70;\nL_0024:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetScenePath()
		{
			//IL_0068: Expected O, but got I
			if (_sceneFound)
			{
				if (!path.IsNone)
				{
					FsmString fsmString = path;
					object obj = (long)(IntPtr)this + 136L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D450C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x98)");
					string value = default(string);
					fsmString.Value = value;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FF6")]
		[Address(RVA = "0xA35224", Offset = "0xA35224", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetScenePath()
		{
		}
	}
}
