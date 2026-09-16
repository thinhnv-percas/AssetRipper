using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7622D0", Offset = "0x7622D0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7622D0", Offset = "0x7622D0")]
	[Token(Token = "0x2000410")]
	public class UiScrollRectSetNormalizedPosition : ComponentAction<ScrollRect>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7A80", Offset = "0x7D7A80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7A80", Offset = "0x7D7A80")]
		[Token(Token = "0x4001F33")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7B18", Offset = "0x7D7B18")]
		[Token(Token = "0x4001F34")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 normalizedPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7B50", Offset = "0x7D7B50")]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D7B50", Offset = "0x7D7B50")]
		[Token(Token = "0x4001F35")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat horizontalPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7BA4", Offset = "0x7D7BA4")]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D7BA4", Offset = "0x7D7BA4")]
		[Token(Token = "0x4001F36")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat verticalPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7BF8", Offset = "0x7D7BF8")]
		[Token(Token = "0x4001F37")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool resetOnExit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7C30", Offset = "0x7D7C30")]
		[Token(Token = "0x4001F38")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x4001F39")]
		[FieldOffset(Offset = "0x90")]
		private ScrollRect scrollRect;

		[Token(Token = "0x4001F3A")]
		[FieldOffset(Offset = "0x98")]
		private Vector2 originalValue;

		[Token(Token = "0x600142C")]
		[Address(RVA = "0x980B84", Offset = "0x980B84", Length = "0xA4")]
		public override void Reset()
		{
			gameObject = null;
			normalizedPosition = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			horizontalPosition = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			verticalPosition = fsmFloat2;
			resetOnExit = null;
			everyFrame = false;
		}

		[Token(Token = "0x600142D")]
		[Address(RVA = "0x980C28", Offset = "0x980C28", Length = "0xBC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollRectSetNormalizedPosition)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			ScrollRect scrollRect;
			if (UpdateCache(ownerDefaultTarget))
			{
				scrollRect = cachedComponent;
				this.scrollRect = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				scrollRect = this.scrollRect;
			}
			Vector2 vector = (originalValue = scrollRect.normalizedPosition);
			originalValue.y = vector.y;
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600142E")]
		[Address(RVA = "0x980E1C", Offset = "0x980E1C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x600142F")]
		[Address(RVA = "0x980CE4", Offset = "0x980CE4", Length = "0x138")]
		private void DoSetValue()
		{
			//IL_0114: Expected O, but got F4
			if (!(scrollRect == null))
			{
				Vector2 vector = scrollRect.normalizedPosition;
				bool isNone = normalizedPosition.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				Vector2 vector2 = vector;
				float y = vector.y;
				if (!flag2)
				{
					FsmVector2 fsmVector = normalizedPosition;
					vector2 = fsmVector.value;
					y = fsmVector.value.y;
				}
				if (!horizontalPosition.IsNone)
				{
					float value = horizontalPosition.Value;
					vector2 = (Vector2)value;
				}
				if (!verticalPosition.IsNone)
				{
					float value2 = verticalPosition.Value;
					y = value2;
				}
				Vector2 vector3 = default(Vector2);
				vector3.x = vector2.x;
				vector3.y = y;
				scrollRect.normalizedPosition = vector3;
			}
		}

		[Token(Token = "0x6001430")]
		[Address(RVA = "0x980E20", Offset = "0x980E20", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(scrollRect == null) && resetOnExit.Value)
			{
				Vector2 vector = default(Vector2);
				vector.x = originalValue.x;
				vector.y = originalValue.y;
				scrollRect.normalizedPosition = vector;
			}
		}

		[Token(Token = "0x6001431")]
		[Address(RVA = "0x980ECC", Offset = "0x980ECC", Length = "0x50")]
		public UiScrollRectSetNormalizedPosition()
		{
		}
	}
}
