using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7607A0", Offset = "0x7607A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7607A0", Offset = "0x7607A0")]
	[Token(Token = "0x20003B8")]
	public class UiCanvasScalerGetScaleFactor : ComponentAction<CanvasScaler>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7CF9E4", Offset = "0x7CF9E4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF9E4", Offset = "0x7CF9E4")]
		[Token(Token = "0x4001D7D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CFA7C", Offset = "0x7CFA7C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFA7C", Offset = "0x7CFA7C")]
		[Token(Token = "0x4001D7E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat scaleFactor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFADC", Offset = "0x7CFADC")]
		[Token(Token = "0x4001D7F")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001D80")]
		[FieldOffset(Offset = "0x78")]
		private CanvasScaler component;

		[Token(Token = "0x600128F")]
		[Address(RVA = "0x9A3C30", Offset = "0x9A3C30", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			scaleFactor = null;
		}

		[Token(Token = "0x6001290")]
		[Address(RVA = "0x9A3C3C", Offset = "0x9A3C3C", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiCanvasScalerGetScaleFactor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				component = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001291")]
		[Address(RVA = "0x9A3D74", Offset = "0x9A3D74", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001292")]
		[Address(RVA = "0x9A3CDC", Offset = "0x9A3CDC", Length = "0x98")]
		private void DoGetValue()
		{
			if (component != null)
			{
				CanvasScaler canvasScaler = component;
				FsmFloat fsmFloat = scaleFactor;
				fsmFloat.Value = canvasScaler.scaleFactor;
			}
		}

		[Token(Token = "0x6001293")]
		[Address(RVA = "0x9A3D78", Offset = "0x9A3D78", Length = "0x50")]
		public UiCanvasScalerGetScaleFactor()
		{
		}
	}
}
