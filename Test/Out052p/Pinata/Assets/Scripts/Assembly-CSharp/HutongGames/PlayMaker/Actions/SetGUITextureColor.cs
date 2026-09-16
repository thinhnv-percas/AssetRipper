using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75704C", Offset = "0x75704C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75704C", Offset = "0x75704C")]
	[Obsolete]
	[Token(Token = "0x2000214")]
	public class SetGUITextureColor : ComponentAction<GUITexture>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B2264", Offset = "0x7B2264")]
		[Token(Token = "0x40014E0")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x40014E1")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor color;

		[Token(Token = "0x40014E2")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000AB0")]
		[Address(RVA = "0x994A94", Offset = "0x994A94", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv11 = UnityEngine.Color::get_white();\n\tv17 = HutongGames.PlayMaker.FsmColor::op_Implicit(v11);\n\tthis.color = v17;\n\tthis.everyFrame = 0;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			Color white = Color.white;
			FsmColor fsmColor = white;
			color = fsmColor;
			everyFrame = false;
		}

		[Token(Token = "0x6000AB1")]
		[Address(RVA = "0x994ACC", Offset = "0x994ACC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGUITextureColor::DoSetGUITextureColor(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoSetGUITextureColor();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000AB2")]
		[Address(RVA = "0x994BBC", Offset = "0x994BBC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGUITextureColor::DoSetGUITextureColor(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoSetGUITextureColor();
		}

		[Token(Token = "0x6000AB3")]
		[Address(RVA = "0x994B08", Offset = "0x994B08", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF9E38]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021750]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetGUITextureColor)+30]), this.gameObject);\n\tv59 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::UpdateCache(this, v43);\n\tv69 = v59 == 0;\n\tif (v69) goto L_003E;\n\tv49 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::get_guiTexture(this);\n\tv53 = this.color;\n\t// 54 MakeStruct v78 @ AGG994BA0_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), v53.value (UnityEngine.Color), v53.value.g (System.Single), v53.value.b (System.Single), v53.value.a (System.Single)\n\tUnityEngine.GUITexture::set_color(v49, v78);\n\treturn;\nL_003E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoSetGUITextureColor()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetGUITextureColor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				GUITexture gUITexture = base.guiTexture;
				FsmColor fsmColor = this.color;
				Color color = default(Color);
				color.r = fsmColor.value.r;
				color.g = fsmColor.value.g;
				color.b = fsmColor.value.b;
				color.a = fsmColor.value.a;
				gUITexture.color = color;
			}
		}

		[Token(Token = "0x6000AB4")]
		[Address(RVA = "0x994BC0", Offset = "0x994BC0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE5BD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021751]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUITextureColor()
		{
		}
	}
}
