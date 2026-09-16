using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75502C", Offset = "0x75502C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75502C", Offset = "0x75502C")]
	[Token(Token = "0x20001B1")]
	public class ConvertMaterialToObject : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ADD04", Offset = "0x7ADD04")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADD04", Offset = "0x7ADD04")]
		[Token(Token = "0x4001361")]
		[FieldOffset(Offset = "0x50")]
		public FsmMaterial materialVariable;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7ADD64", Offset = "0x7ADD64")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADD64", Offset = "0x7ADD64")]
		[Token(Token = "0x4001362")]
		[FieldOffset(Offset = "0x58")]
		public FsmObject objectVariable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7ADDC4", Offset = "0x7ADDC4")]
		[Token(Token = "0x4001363")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6000933")]
		[Address(RVA = "0xA92958", Offset = "0xA92958", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.materialVariable = 0;\n\tthis.objectVariable = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			materialVariable = null;
			objectVariable = null;
		}

		[Token(Token = "0x6000934")]
		[Address(RVA = "0xA92964", Offset = "0xA92964", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertMaterialToObject::DoConvertMaterialToObject(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoConvertMaterialToObject();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000935")]
		[Address(RVA = "0xA929E4", Offset = "0xA929E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ConvertMaterialToObject::DoConvertMaterialToObject(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoConvertMaterialToObject();
		}

		[Token(Token = "0x6000936")]
		[Address(RVA = "0xA929A0", Offset = "0xA929A0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.objectVariable;\n\tv14 = HutongGames.PlayMaker.FsmMaterial::get_Value(this.materialVariable);\n\tv12.value = v14;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoConvertMaterialToObject()
		{
			FsmObject fsmObject = objectVariable;
			Material value = materialVariable.Value;
			fsmObject.Value = value;
		}

		[Token(Token = "0x6000937")]
		[Address(RVA = "0xA929E8", Offset = "0xA929E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConvertMaterialToObject()
		{
		}
	}
}
