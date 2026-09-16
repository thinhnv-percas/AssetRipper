using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75FC8C", Offset = "0x75FC8C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75FC8C", Offset = "0x75FC8C")]
	[Token(Token = "0x2000395")]
	public class ScaleTime : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CD2FC", Offset = "0x7CD2FC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD2FC", Offset = "0x7CD2FC")]
		[Token(Token = "0x4001C9B")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat timeScale;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD360", Offset = "0x7CD360")]
		[Token(Token = "0x4001C9C")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool adjustFixedDeltaTime;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CD398", Offset = "0x7CD398")]
		[Token(Token = "0x4001C9D")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x60011CE")]
		[Address(RVA = "0xB25500", Offset = "0xB25500", Length = "0x40")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 1f;
			timeScale = fsmFloat;
			FsmBool fsmBool = true;
			adjustFixedDeltaTime = fsmBool;
			everyFrame = false;
		}

		[Token(Token = "0x60011CF")]
		[Address(RVA = "0xB25540", Offset = "0xB25540", Length = "0x3C")]
		public override void OnEnter()
		{
			DoTimeScale();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60011D0")]
		[Address(RVA = "0xB255EC", Offset = "0xB255EC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoTimeScale();
		}

		[Token(Token = "0x60011D1")]
		[Address(RVA = "0xB2557C", Offset = "0xB2557C", Length = "0x70")]
		private void DoTimeScale()
		{
			float value = timeScale.Value;
			Time.timeScale = value;
			if (adjustFixedDeltaTime.Value)
			{
				float num = Time.timeScale;
				float fixedDeltaTime = num * 0.02f;
				Time.fixedDeltaTime = fixedDeltaTime;
			}
		}

		[Token(Token = "0x60011D2")]
		[Address(RVA = "0xB255F0", Offset = "0xB255F0", Length = "0x8")]
		public ScaleTime()
		{
		}
	}
}
