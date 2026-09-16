using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A43C", Offset = "0x75A43C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A43C", Offset = "0x75A43C")]
	[Token(Token = "0x20002B4")]
	public class WakeUp : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BB604", Offset = "0x7BB604")]
		[Token(Token = "0x4001798")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x6000D7D")]
		[Address(RVA = "0x98A5EC", Offset = "0x98A5EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\treturn;\n")]
		public override void Reset()
		{
			gameObject = null;
		}

		[Token(Token = "0x6000D7E")]
		[Address(RVA = "0x98A5F4", Offset = "0x98A5F4", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.WakeUp::DoWakeUp(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoWakeUp();
			Finish();
		}

		[Token(Token = "0x6000D7F")]
		[Address(RVA = "0x98A61C", Offset = "0x98A61C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBC520]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216C7]) = v38;\nL_0013:\n\tv39 = this.gameObject;\n\tv42 = v39.ownerOption == 0;\n\tif (v42) goto L_0020;\n\tv61 = HutongGames.PlayMaker.FsmGameObject::get_Value(v39.gameObject);\n\tgoto L_0025;\nL_0020:\n\tv62 = *([this @ X0 (HutongGames.PlayMaker.Actions.WakeUp)+20]);\nL_0025:\n\tv69 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v62);\n\tv71 = v69 == 0;\n\tif (v71) goto L_003D;\n\tv54 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tUnityEngine.Rigidbody::WakeUp(v54);\n\treturn;\nL_003D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoWakeUp()
		{
			//IL_0056: Expected O, but got I
			FsmOwnerDefault fsmOwnerDefault = gameObject;
			GameObject go;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				go = value;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.WakeUp)+20]");
				go = (GameObject)0;
			}
			if (UpdateCache(go))
			{
				Rigidbody rigidbody = base.rigidbody;
				rigidbody.WakeUp();
			}
		}

		[Token(Token = "0x6000D80")]
		[Address(RVA = "0x98A6D0", Offset = "0x98A6D0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB82B0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216C8]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WakeUp()
		{
		}
	}
}
