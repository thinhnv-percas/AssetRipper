using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762550", Offset = "0x762550")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762550", Offset = "0x762550")]
	[Token(Token = "0x2000418")]
	public class UiSliderSetDirection : ComponentAction<Slider>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D856C", Offset = "0x7D856C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D856C", Offset = "0x7D856C")]
		[Token(Token = "0x4001F5B")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D8604", Offset = "0x7D8604")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D8604", Offset = "0x7D8604")]
		[Token(Token = "0x4001F5C")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D869C", Offset = "0x7D869C")]
		[Token(Token = "0x4001F5D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool includeRectLayouts;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D86D4", Offset = "0x7D86D4")]
		[Token(Token = "0x4001F5E")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001F5F")]
		[FieldOffset(Offset = "0x80")]
		private Slider slider;

		[Token(Token = "0x4001F60")]
		[FieldOffset(Offset = "0x88")]
		private Slider.Direction originalValue;

		[Token(Token = "0x6001454")]
		[Address(RVA = "0x983D20", Offset = "0x983D20", Length = "0xA4")]
		public override void Reset()
		{
			//IL_003a: Expected O, but got I4
			//IL_0043: Expected I4, but got O
			gameObject = null;
			object obj = 0;
			Enum obj2 = (Slider.Direction)obj;
			FsmEnum fsmEnum = obj2;
			direction = fsmEnum;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			includeRectLayouts = fsmBool;
			resetOnExit = null;
		}

		[Token(Token = "0x6001455")]
		[Address(RVA = "0x983DC4", Offset = "0x983DC4", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiSliderSetDirection)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Slider slider;
			if (UpdateCache(ownerDefaultTarget))
			{
				slider = cachedComponent;
				this.slider = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				slider = this.slider;
			}
			originalValue = slider.direction;
			DoSetValue();
		}

		[Token(Token = "0x6001456")]
		[Address(RVA = "0x983E64", Offset = "0x983E64", Length = "0x178")]
		private void DoSetValue()
		{
			//IL_00e2: Expected I4, but got O
			//IL_0080: Expected I4, but got O
			//IL_0121: Expected I4, but got O
			//IL_00bb: Expected I4, but got O
			if (slider == null)
			{
				return;
			}
			bool isNone = includeRectLayouts.IsNone;
			Enum value = direction.Value;
			if (isNone)
			{
				if ((int)((value is Slider.Direction) ? value : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj = default(object);
					slider.direction = (Slider.Direction)obj;
					return;
				}
			}
			else
			{
				bool value2 = includeRectLayouts.Value;
				if ((int)((value is Slider.Direction) ? value : null) != 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					slider.SetDirection((Slider.Direction)obj2, value2);
					return;
				}
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x6001457")]
		[Address(RVA = "0x983FDC", Offset = "0x983FDC", Length = "0x110")]
		public override void OnExit()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2021669]");
			if (0 == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @98F778 (inside PEButtonScript::.ctor +0x1C)");
			}
			else if (!(slider == null) && resetOnExit.Value)
			{
				if (includeRectLayouts.IsNone)
				{
					slider.direction = originalValue;
					return;
				}
				bool value = includeRectLayouts.Value;
				slider.SetDirection(originalValue, value);
			}
		}

		[Token(Token = "0x6001458")]
		[Address(RVA = "0x9840EC", Offset = "0x9840EC", Length = "0x50")]
		public UiSliderSetDirection()
		{
		}
	}
}
