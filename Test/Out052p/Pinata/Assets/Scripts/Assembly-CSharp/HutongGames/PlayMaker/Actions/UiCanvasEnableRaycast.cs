using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760660", Offset = "0x760660")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760660", Offset = "0x760660")]
	[Token(Token = "0x20003B4")]
	public class UiCanvasEnableRaycast : ComponentAction<PlayMakerCanvasRaycastFilterProxy>
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF630", Offset = "0x7CF630")]
		[Token(Token = "0x4001D65")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4001D66")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool enableRaycasting;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF67C", Offset = "0x7CF67C")]
		[Token(Token = "0x4001D67")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001D68")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[SerializeField]
		[Token(Token = "0x4001D69")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerCanvasRaycastFilterProxy raycastFilterProxy;

		[Token(Token = "0x4001D6A")]
		[FieldOffset(Offset = "0x88")]
		private bool originalValue;

		[Token(Token = "0x600127A")]
		[Address(RVA = "0x9A3120", Offset = "0x9A3120", Length = "0x34")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			enableRaycasting = fsmBool;
			resetOnExit = null;
			everyFrame = false;
		}

		[Token(Token = "0x600127B")]
		[Address(RVA = "0x9A3154", Offset = "0x9A3154", Length = "0xA4")]
		public override void OnPreprocess()
		{
			//IL_0040: Expected O, but got I
			FsmOwnerDefault ownerDefault = gameObject;
			if (gameObject == null)
			{
				ownerDefault = (gameObject = new FsmOwnerDefault());
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiCanvasEnableRaycast)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(ownerDefault);
			if (UpdateCacheAddComponent(ownerDefaultTarget))
			{
				raycastFilterProxy = cachedComponent;
			}
		}

		[Token(Token = "0x600127C")]
		[Address(RVA = "0x9A31F8", Offset = "0x9A31F8", Length = "0xB4")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiCanvasEnableRaycast)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCacheAddComponent(ownerDefaultTarget))
			{
				PlayMakerCanvasRaycastFilterProxy playMakerCanvasRaycastFilterProxy = cachedComponent;
				raycastFilterProxy = cachedComponent;
				originalValue = playMakerCanvasRaycastFilterProxy.RayCastingEnabled;
			}
			DoAction();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600127D")]
		[Address(RVA = "0x9A3350", Offset = "0x9A3350", Length = "0x4")]
		public override void OnUpdate()
		{
			DoAction();
		}

		[Token(Token = "0x600127E")]
		[Address(RVA = "0x9A32AC", Offset = "0x9A32AC", Length = "0xA4")]
		private void DoAction()
		{
			if (raycastFilterProxy != null)
			{
				PlayMakerCanvasRaycastFilterProxy playMakerCanvasRaycastFilterProxy = raycastFilterProxy;
				bool value = enableRaycasting.Value;
				playMakerCanvasRaycastFilterProxy.RayCastingEnabled = value;
			}
		}

		[Token(Token = "0x600127F")]
		[Address(RVA = "0x9A3354", Offset = "0x9A3354", Length = "0xA8")]
		public override void OnExit()
		{
			if (!(raycastFilterProxy == null) && resetOnExit.Value)
			{
				PlayMakerCanvasRaycastFilterProxy playMakerCanvasRaycastFilterProxy = raycastFilterProxy;
				playMakerCanvasRaycastFilterProxy.RayCastingEnabled = originalValue;
			}
		}

		[Token(Token = "0x6001280")]
		[Address(RVA = "0x9A33FC", Offset = "0x9A33FC", Length = "0x50")]
		public UiCanvasEnableRaycast()
		{
		}
	}
}
