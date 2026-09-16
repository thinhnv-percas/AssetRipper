using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756EF0", Offset = "0x756EF0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756EF0", Offset = "0x756EF0")]
	[Obsolete]
	[Token(Token = "0x2000211")]
	public class SetGUIText : ComponentAction<GUIText>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B2088", Offset = "0x7B2088")]
		[Token(Token = "0x40014D8")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B20FC", Offset = "0x7B20FC")]
		[Token(Token = "0x40014D9")]
		[FieldOffset(Offset = "0x68")]
		public FsmString text;

		[Token(Token = "0x40014DA")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000AA3")]
		[Address(RVA = "0x9945E8", Offset = "0x9945E8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F08148]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021749]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.text = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			text = fsmString;
		}

		[Token(Token = "0x6000AA4")]
		[Address(RVA = "0x994644", Offset = "0x994644", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGUIText::DoSetGUIText(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetGUIText();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000AA5")]
		[Address(RVA = "0x994744", Offset = "0x994744", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGUIText::DoSetGUIText(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetGUIText();
		}

		[Token(Token = "0x6000AA6")]
		[Address(RVA = "0x994680", Offset = "0x994680", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC95C8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202174A]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetGUIText)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUIText>::UpdateCache(this, v43);\n\tv68 = v50 == 0;\n\tif (v68) goto L_003F;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUIText>::get_guiText(this);\n\tv57 = HutongGames.PlayMaker.FsmString::get_Value(this.text);\n\tUnityEngine.GUIText::set_text(v56, v57);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetGUIText()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetGUIText)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				GUIText gUIText = base.guiText;
				string value = text.Value;
				gUIText.text = value;
			}
		}

		[Token(Token = "0x6000AA7")]
		[Address(RVA = "0x994748", Offset = "0x994748", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC0F90]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202174B]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUIText>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUIText()
		{
		}
	}
}
