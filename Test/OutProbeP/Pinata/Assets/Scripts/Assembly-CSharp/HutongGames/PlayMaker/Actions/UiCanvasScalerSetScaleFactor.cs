using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7607F0", Offset = "0x7607F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7607F0", Offset = "0x7607F0")]
	[Token(Token = "0x20003B9")]
	public class UiCanvasScalerSetScaleFactor : ComponentAction<CanvasScaler>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7CFB14", Offset = "0x7CFB14")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFB14", Offset = "0x7CFB14")]
		[Token(Token = "0x4001D81")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFBAC", Offset = "0x7CFBAC")]
		[Token(Token = "0x4001D82")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat scaleFactor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CFBF8", Offset = "0x7CFBF8")]
		[Token(Token = "0x4001D83")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001D84")]
		[FieldOffset(Offset = "0x78")]
		private CanvasScaler component;

		[Token(Token = "0x6001294")]
		[Address(RVA = "0x9A3DC8", Offset = "0x9A3DC8", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			scaleFactor = null;
		}

		[Token(Token = "0x6001295")]
		[Address(RVA = "0x9A3DD4", Offset = "0x9A3DD4", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiCanvasScalerSetScaleFactor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				component = cachedComponent;
			}
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001296")]
		[Address(RVA = "0x9A3F24", Offset = "0x9A3F24", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x6001297")]
		[Address(RVA = "0x9A3E74", Offset = "0x9A3E74", Length = "0xB0")]
		private void DoSetValue()
		{
			if (component != null)
			{
				float value = scaleFactor.Value;
				component.scaleFactor = value;
			}
		}

		[Token(Token = "0x6001298")]
		[Address(RVA = "0x9A3F28", Offset = "0x9A3F28", Length = "0x50")]
		public UiCanvasScalerSetScaleFactor()
		{
		}
	}
}
