using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757878", Offset = "0x757878")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757878", Offset = "0x757878")]
	[Token(Token = "0x200022E")]
	public class GUILayoutSpace : FsmStateAction
	{
		[Token(Token = "0x4001538")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat space;

		[Token(Token = "0x6000B00")]
		[Address(RVA = "0xB7B644", Offset = "0xB7B644", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(10f);\n\tthis.space = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 10f;
			space = fsmFloat;
		}

		[Token(Token = "0x6000B01")]
		[Address(RVA = "0xB7B670", Offset = "0xB7B670", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = HutongGames.PlayMaker.FsmFloat::get_Value(this.space);\n\tUnityEngine.GUILayout::Space(v10);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			float value = space.Value;
			GUILayout.Space(value);
		}

		[Token(Token = "0x6000B02")]
		[Address(RVA = "0xB7B698", Offset = "0xB7B698", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutSpace()
		{
		}
	}
}
