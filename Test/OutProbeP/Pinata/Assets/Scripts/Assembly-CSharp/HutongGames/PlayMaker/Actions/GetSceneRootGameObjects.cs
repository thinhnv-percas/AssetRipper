using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75CE30", Offset = "0x75CE30")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75CE30", Offset = "0x75CE30")]
	[Token(Token = "0x2000332")]
	public class GetSceneRootGameObjects : GetSceneActionBase
	{
		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C6CF8", Offset = "0x7C6CF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6CF8", Offset = "0x7C6CF8")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C6CF8", Offset = "0x7C6CF8")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7C6CF8", Offset = "0x7C6CF8")]
		[Token(Token = "0x4001A45")]
		[FieldOffset(Offset = "0x90")]
		public FsmArray rootGameObjects;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C6DB0", Offset = "0x7C6DB0")]
		[Token(Token = "0x4001A46")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x6001000")]
		[Address(RVA = "0xA355CC", Offset = "0xA355CC", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootGameObjects)+7C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootGameObjects)+84]) = 0;\n\tthis.rootGameObjects = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootGameObjects)+6C]) = 0;\n\t*([this @ X0 (HutongGames.PlayMaker.Actions.GetSceneRootGameObjects)+5C]) = 0;\n\tthis.sceneReference = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			((FsmStateAction)this).Reset();
			_ = 0;
			_ = 0;
			rootGameObjects = null;
			_ = 0;
			_ = 0;
			sceneReference = default(SceneAllReferenceOptions);
			everyFrame = false;
		}

		[Token(Token = "0x6001001")]
		[Address(RVA = "0xA35610", Offset = "0xA35610", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneActionBase::OnEnter(this);\n\tHutongGames.PlayMaker.Actions.GetSceneRootGameObjects::DoGetSceneRootGameObjects(this);\n\tv13 = ~this.everyFrame;\n\tif (v13) goto L_0017;\n\treturn;\nL_0017:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			DoGetSceneRootGameObjects();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001002")]
		[Address(RVA = "0xA356D8", Offset = "0xA356D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSceneRootGameObjects::DoGetSceneRootGameObjects(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSceneRootGameObjects();
		}

		[Token(Token = "0x6001003")]
		[Address(RVA = "0xA35654", Offset = "0xA35654", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this._sceneFound;\n\tif (v13) goto L_002E;\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.rootGameObjects);\n\tv68 = v21 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0027;\n\tv76 = this + 0x88;\n\tv73 = 0x10D468C(v76, 0, v23, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.rootGameObjects, v73);\nL_0027:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.sceneFoundEvent);\n\treturn;\nL_002E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSceneRootGameObjects()
		{
			//IL_005e: Expected O, but got I
			if (_sceneFound)
			{
				if (!rootGameObjects.IsNone)
				{
					object obj = (long)(IntPtr)this + 136L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D468C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x218)");
					object[] values = default(object[]);
					rootGameObjects.Values = values;
				}
				Fsm.Event(sceneFoundEvent);
			}
		}

		[Token(Token = "0x6001004")]
		[Address(RVA = "0xA356DC", Offset = "0xA356DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSceneRootGameObjects()
		{
		}
	}
}
