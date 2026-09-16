using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75663C", Offset = "0x75663C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75663C", Offset = "0x75663C")]
	[Token(Token = "0x20001F5")]
	public class SetGameObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B1684", Offset = "0x7B1684")]
		[Token(Token = "0x400147B")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject variable;

		[Token(Token = "0x400147C")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject gameObject;

		[Token(Token = "0x400147D")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000A48")]
		[Address(RVA = "0x994C10", Offset = "0x994C10", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.variable = 0;\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			variable = null;
			gameObject = null;
		}

		[Token(Token = "0x6000A49")]
		[Address(RVA = "0x994C1C", Offset = "0x994C1C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.variable, v16);\n\tv44 = ~this.everyFrame;\n\tif (v44) goto L_0023;\n\treturn;\nL_0023:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject value = gameObject.Value;
			variable.Value = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000A4A")]
		[Address(RVA = "0x994C88", Offset = "0x994C88", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.variable, v14);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			GameObject value = gameObject.Value;
			variable.Value = value;
		}

		[Token(Token = "0x6000A4B")]
		[Address(RVA = "0x994CD4", Offset = "0x994CD4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGameObject()
		{
		}
	}
}
