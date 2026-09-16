using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CC00", Offset = "0x75CC00")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CC00", Offset = "0x75CC00")]
	[Token(Token = "0x200032B")]
	public class GetSceneIsLoaded : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C62D4", Offset = "0x7C62D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C62D4", Offset = "0x7C62D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C62D4", Offset = "0x7C62D4")]
		[Token(Token = "0x4001A27")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool isLoaded;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6348", Offset = "0x7C6348")]
		[Token(Token = "0x4001A28")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent isLoadedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6380", Offset = "0x7C6380")]
		[Token(Token = "0x4001A29")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent isNotLoadedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C63B8", Offset = "0x7C63B8")]
		[Token(Token = "0x4001A2A")]
		[FieldOffset(Offset = "0xA8")]
		public bool everyFrame;

		[Token(Token = "0x6000FE2")]
		[Address(RVA = "0xA34B4C", Offset = "0xA34B4C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsLoaded)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsLoaded)+84]) = 0;\n\tthis.isLoaded = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsLoaded)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneIsLoaded)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			isLoaded = null;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			everyFrame = false;
		}

		[Token(Token = "0x6000FE3")]
		[Address(RVA = "0xA34B90", Offset = "0xA34B90", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneIsLoaded::DoGetSceneIsLoaded(this);\n\tv13 = ~this.everyFrame;\n\tif (v13) goto L_0017;\n\treturn;\nL_0017:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneIsLoaded();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000FE4")]
		[Address(RVA = "0xA34C50", Offset = "0xA34C50", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneIsLoaded::DoGetSceneIsLoaded(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneIsLoaded();
		}

		[Token(Token = "0x6000FE5")]
		[Address(RVA = "0xA34BD4", Offset = "0xA34BD4", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002C;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.isLoaded);\n\tv69 = v21 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0025;\n\tv71 = this.isLoaded;\n\tv77 = this + 0x88;\n\tv74 = 0x10D458C(v77, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv80 = v74 & 1;\n\tv71.value = v80;\nL_0025:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneIsLoaded()
		{
			//IL_0068: Expected O, but got I
			if (_sceneFound)
			{
				if (!isLoaded.IsNone)
				{
					FsmBool fsmBool = isLoaded;
					object obj = (long)(IntPtr)this + 136L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D458C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x118)");
					object obj2 = default(object);
					int value = (int)((long)(IntPtr)obj2 & 1L);
					fsmBool.value = (byte)value != 0;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6000FE6")]
		[Address(RVA = "0xA34C54", Offset = "0xA34C54", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneIsLoaded()
		{
		}
	}
}
