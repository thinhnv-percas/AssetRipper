using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756F64", Offset = "0x756F64")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756F64", Offset = "0x756F64")]
	[Obsolete]
	[Token(Token = "0x2000212")]
	public class SetGUITexture : ComponentAction<GUITexture>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B2110", Offset = "0x7B2110")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B2110", Offset = "0x7B2110")]
		[Token(Token = "0x40014DB")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B21A8", Offset = "0x7B21A8")]
		[Token(Token = "0x40014DC")]
		[FieldOffset(Offset = "0x68")]
		public FsmTexture texture;

		[Token(Token = "0x6000AA8")]
		[Address(RVA = "0x994798", Offset = "0x994798", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.texture = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
			texture = null;
		}

		[Token(Token = "0x6000AA9")]
		[Address(RVA = "0x9947A0", Offset = "0x9947A0", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA7488]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202174C]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetGUITexture)+30]), this.gameObject);\n\tv50 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::UpdateCache(this, v43);\n\tv68 = v50 == 0;\n\tif (v68) goto L_003B;\n\tv56 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::get_guiTexture(this);\n\tv57 = HutongGames.PlayMaker.FsmTexture::get_Value(this.texture);\n\tUnityEngine.GUITexture::set_texture(v56, v57);\nL_003B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetGUITexture)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				GUITexture gUITexture = base.guiTexture;
				Texture value = texture.Value;
				gUITexture.texture = value;
			}
			Finish();
		}

		[Token(Token = "0x6000AAA")]
		[Address(RVA = "0x994864", Offset = "0x994864", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED7900]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202174D]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUITexture()
		{
		}
	}
}
