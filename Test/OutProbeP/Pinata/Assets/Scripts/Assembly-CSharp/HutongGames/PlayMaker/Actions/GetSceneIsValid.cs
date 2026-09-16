using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CC50", Offset = "0x75CC50")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CC50", Offset = "0x75CC50")]
	[Token(Token = "0x200032C")]
	public class GetSceneIsValid : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C63F0", Offset = "0x7C63F0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C63F0", Offset = "0x7C63F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C63F0", Offset = "0x7C63F0")]
		[Token(Token = "0x4001A2B")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool isValid;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6464", Offset = "0x7C6464")]
		[Token(Token = "0x4001A2C")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent isValidEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C649C", Offset = "0x7C649C")]
		[Token(Token = "0x4001A2D")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent isNotValidEvent;

		[Token(Token = "0x6000FE7")]
		[Address(RVA = "0xA34C5C", Offset = "0xA34C5C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsValid)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsValid)+84]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsValid)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsValid)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.isValid = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			isValid = null;
		}

		[Token(Token = "0x6000FE8")]
		[Address(RVA = "0xA34C9C", Offset = "0xA34C9C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneIsValid::DoGetSceneIsValid(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneIsValid();
			Finish();
		}

		[Token(Token = "0x6000FE9")]
		[Address(RVA = "0xA34CCC", Offset = "0xA34CCC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ~this._sceneFound;\n\tif (v15) goto L_001B;\n\tv24 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isValid);\n\tv80 = v24 == 0;\n\tif (v80) goto L_001C;\n\tv31 = this + 0x88;\n\tgoto L_0027;\nL_001B:\n\treturn;\nL_001C:\n\tv81 = this.isValid;\n\tv31 = this + 0x88;\n\tv86 = 0x10D44CC(v31, 0, v26, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv98 = v86 & 1;\n\tv81.value = v98;\nL_0027:\n\tv87 = 0x10D44CC(v31, 0, v26, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv100 = v87 & 1;\n\tv101 = v100 == 0;\n\tif (v101) goto L_0032;\n\tv34 = this.isValidEvent;\n\tgoto L_0035;\nL_0032:\n\tv34 = this.isNotValidEvent;\nL_0035:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v34);\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneIsValid()
		{
			//IL_006f: Expected O, but got I
			//IL_0053: Expected O, but got I
			if (_sceneFound)
			{
				if (isValid.IsNone)
				{
					object obj = (long)(IntPtr)this + 136L;
				}
				else
				{
					FsmBool fsmBool = isValid;
					object obj = (long)(IntPtr)this + 136L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
					object obj2 = default(object);
					int value = (int)((long)(IntPtr)obj2 & 1L);
					fsmBool.value = (byte)value != 0;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D44CC (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x58)");
				object obj3 = default(object);
				FsmEvent fsmEvent = (((int)((long)(IntPtr)obj3 & 1L) == 0) ? isNotValidEvent : isValidEvent);
				Fsm.Event(fsmEvent);
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FEA")]
		[Address(RVA = "0xA34D94", Offset = "0xA34D94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneIsValid()
		{
		}
	}
}
