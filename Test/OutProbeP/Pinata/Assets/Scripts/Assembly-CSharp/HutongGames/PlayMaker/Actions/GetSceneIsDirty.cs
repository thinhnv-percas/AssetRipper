using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CBB0", Offset = "0x75CBB0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CBB0", Offset = "0x75CBB0")]
	[Token(Token = "0x200032A")]
	public class GetSceneIsDirty : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C61B8", Offset = "0x7C61B8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C61B8", Offset = "0x7C61B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C61B8", Offset = "0x7C61B8")]
		[Token(Token = "0x4001A23")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool isDirty;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C622C", Offset = "0x7C622C")]
		[Token(Token = "0x4001A24")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent isDirtyEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6264", Offset = "0x7C6264")]
		[Token(Token = "0x4001A25")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent isNotDirtyEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C629C", Offset = "0x7C629C")]
		[Token(Token = "0x4001A26")]
		[FieldOffset(Offset = "0xA8")]
		public bool everyFrame;

		[Token(Token = "0x6000FDD")]
		[Address(RVA = "0xA34A3C", Offset = "0xA34A3C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsDirty)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsDirty)+84]) = 0;\n\tthis.isDirty = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsDirty)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsDirty)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			isDirty = null;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			everyFrame = false;
		}

		[Token(Token = "0x6000FDE")]
		[Address(RVA = "0xA34A80", Offset = "0xA34A80", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneIsDirty::DoGetSceneIsDirty(this);\n\tv13 = ~this.everyFrame;\n\tif (v13) goto L_0017;\n\treturn;\nL_0017:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneIsDirty();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FDF")]
		[Address(RVA = "0xA34B40", Offset = "0xA34B40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneIsDirty::DoGetSceneIsDirty(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneIsDirty();
		}

		[Token(Token = "0x6000FE0")]
		[Address(RVA = "0xA34AC4", Offset = "0xA34AC4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002C;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isDirty);\n\tv69 = v21 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0025;\n\tv71 = this.isDirty;\n\tv77 = this + 0x88;\n\tv74 = 0x10D460C(v77, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv80 = v74 & 1;\n\tv71.value = v80;\nL_0025:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneIsDirty()
		{
			//IL_0068: Expected O, but got I
			if (_sceneFound)
			{
				if (!isDirty.IsNone)
				{
					FsmBool fsmBool = isDirty;
					object obj = (long)(IntPtr)this + 136L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D460C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x198)");
					object obj2 = default(object);
					int value = (int)((long)(IntPtr)obj2 & 1L);
					fsmBool.value = (byte)value != 0;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FE1")]
		[Address(RVA = "0xA34B44", Offset = "0xA34B44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneIsDirty()
		{
		}
	}
}
