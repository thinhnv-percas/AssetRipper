using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756FD8", Offset = "0x756FD8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756FD8", Offset = "0x756FD8")]
	[Obsolete]
	[Token(Token = "0x2000213")]
	public class SetGUITextureAlpha : ComponentAction<GUITexture>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7B21E0", Offset = "0x7B21E0")]
		[Token(Token = "0x40014DD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x40014DE")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat alpha;

		[Token(Token = "0x40014DF")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000AAB")]
		[Address(RVA = "0x9948B4", Offset = "0x9948B4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.alpha = v12;\n\tthis.everyFrame = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = 1f;
			alpha = fsmFloat;
			everyFrame = false;
		}

		[Token(Token = "0x6000AAC")]
		[Address(RVA = "0x9948E8", Offset = "0x9948E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGUITextureAlpha::DoGUITextureAlpha(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGUITextureAlpha();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000AAD")]
		[Address(RVA = "0x994A40", Offset = "0x994A40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetGUITextureAlpha::DoGUITextureAlpha(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGUITextureAlpha();
		}

		[Token(Token = "0x6000AAE")]
		[Address(RVA = "0x994924", Offset = "0x994924", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EB4580]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202174E]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.SetGUITextureAlpha)+30]), this.gameObject);\n\tv66 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::UpdateCache(this, v49);\n\tv109 = v66 == 0;\n\tif (v109) goto L_0059;\n\tv55 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::get_guiTexture(this);\n\tv89 = UnityEngine.GUITexture::get_color(v55);\n\tv96 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::get_guiTexture(this);\n\tv166 = HutongGames.PlayMaker.FsmFloat::get_Value(this.alpha);\n\tv72 = 0;\n\tv97 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::UpdateCache(&v72 @ stack_-50_v3, 0);\n\t// 79 MakeStruct v113 @ AGG994A18_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v168 @ stack_-4C, 0, v169 @ stack_-44\n\tUnityEngine.GUITexture::set_color(v96, v113);\nL_0059:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGUITextureAlpha()
		{
			//IL_001c: Expected O, but got I
			//IL_0093: Expected O, but got I4
			//IL_00c1: Expected F4, but got O
			//IL_00dc: Expected F4, but got O
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.SetGUITextureAlpha)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				GUITexture gUITexture = base.guiTexture;
				Color color = gUITexture.color;
				GUITexture gUITexture2 = base.guiTexture;
				float value = alpha.Value;
				object obj = 0;
				bool flag = ((ComponentAction<GUITexture>)obj).UpdateCache((GameObject)null);
				Color color2 = default(Color);
				color2.r = 0f;
				object obj2 = default(object);
				color2.g = (float)obj2;
				color2.b = 0f;
				object obj3 = default(object);
				color2.a = (float)obj3;
				gUITexture2.color = color2;
			}
		}

		[Token(Token = "0x6000AAF")]
		[Address(RVA = "0x994A44", Offset = "0x994A44", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F08200]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202174F]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.GUITexture>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUITextureAlpha()
		{
		}
	}
}
