using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7545C0", Offset = "0x7545C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7545C0", Offset = "0x7545C0")]
	[Token(Token = "0x200018F")]
	public class SetGameVolume : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB66C", Offset = "0x7AB66C")]
		[Token(Token = "0x40012BC")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat volume;

		[Token(Token = "0x40012BD")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000889")]
		[Address(RVA = "0x994CDC", Offset = "0x994CDC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 1f;
			volume = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x600088A")]
		[Address(RVA = "0x994D0C", Offset = "0x994D0C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tUnityEngine.AudioListener::set_volume(v13);\n\tv32 = ~this.everyFrame;\n\tif (v32) goto L_001B;\n\treturn;\nL_001B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float value = volume.Value;
			AudioListener.volume = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600088B")]
		[Address(RVA = "0x994D60", Offset = "0x994D60", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\tUnityEngine.AudioListener::set_volume(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			float value = volume.Value;
			AudioListener.volume = value;
		}

		[Token(Token = "0x600088C")]
		[Address(RVA = "0x994D88", Offset = "0x994D88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGameVolume()
		{
		}
	}
}
