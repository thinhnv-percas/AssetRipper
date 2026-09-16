using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757C98", Offset = "0x757C98")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757C98", Offset = "0x757C98")]
	[Token(Token = "0x200023B")]
	public class GetKey : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3700", Offset = "0x7B3700")]
		[Token(Token = "0x4001568")]
		[FieldOffset(Offset = "0x4C")]
		public KeyCode key;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B374C", Offset = "0x7B374C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B374C", Offset = "0x7B374C")]
		[Token(Token = "0x4001569")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B37AC", Offset = "0x7B37AC")]
		[Token(Token = "0x400156A")]
		[FieldOffset(Offset = "0x58")]
		public bool everyFrame;

		[Token(Token = "0x6000B2F")]
		[Address(RVA = "0xA2EFC4", Offset = "0xA2EFC4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.key = 0;\n\tthis.storeResult = 0;\n\tthis.everyFrame = 0;\n\treturn;\n")]
		public override void Reset()
		{
			key = default(KeyCode);
			storeResult = null;
			everyFrame = false;
		}

		[Token(Token = "0x6000B30")]
		[Address(RVA = "0xA2EFD4", Offset = "0xA2EFD4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetKey::DoGetKey(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetKey();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000B31")]
		[Address(RVA = "0xA2F04C", Offset = "0xA2F04C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetKey::DoGetKey(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetKey();
		}

		[Token(Token = "0x6000B32")]
		[Address(RVA = "0xA2F010", Offset = "0xA2F010", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.storeResult;\n\tv12 = UnityEngine.Input::GetKey(this.key);\n\tv8.value = v12;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetKey()
		{
			FsmBool fsmBool = storeResult;
			bool value = Input.GetKey(key);
			fsmBool.value = value;
		}

		[Token(Token = "0x6000B33")]
		[Address(RVA = "0xA2F050", Offset = "0xA2F050", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetKey()
		{
		}
	}
}
