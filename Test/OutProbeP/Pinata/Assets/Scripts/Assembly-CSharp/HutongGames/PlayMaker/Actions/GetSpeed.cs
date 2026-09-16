using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759EC8", Offset = "0x759EC8")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x759EC8", Offset = "0x759EC8")]
	[Token(Token = "0x20002A3")]
	public class GetSpeed : ComponentAction<Rigidbody>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BA320", Offset = "0x7BA320")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA320", Offset = "0x7BA320")]
		[Token(Token = "0x400173F")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA3B8", Offset = "0x7BA3B8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA3B8", Offset = "0x7BA3B8")]
		[Token(Token = "0x4001740")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA418", Offset = "0x7BA418")]
		[Token(Token = "0x4001741")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000D22")]
		[Address(RVA = "0xA35B40", Offset = "0xA35B40", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.storeResult = 0;\n\treturn;\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			storeResult = null;
		}

		[Token(Token = "0x6000D23")]
		[Address(RVA = "0xA35B4C", Offset = "0xA35B4C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSpeed::DoGetSpeed(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoGetSpeed();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D24")]
		[Address(RVA = "0xA35C6C", Offset = "0xA35C6C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetSpeed::DoGetSpeed(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoGetSpeed();
		}

		[Token(Token = "0x6000D25")]
		[Address(RVA = "0xA35B88", Offset = "0xA35B88", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDE2F0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E0E]) = v38;\nL_0016:\n\tv42 = this.storeResult == 0;\n\tif (v42) goto L_0048;\n\tv43 = this.gameObject;\n\tv81 = v43.ownerOption == 0;\n\tif (v81) goto L_0025;\n\tv133 = HutongGames.PlayMaker.FsmGameObject::get_Value(v43.gameObject);\n\tgoto L_002A;\nL_0025:\n\tv62 = *([this @ X0 (HutongGames.PlayMaker.Actions.GetSpeed)+20]);\nL_002A:\n\tv68 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v62);\n\tv71 = v68 == 0;\n\tif (v71) goto L_0048;\n\tv130 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tv59 = UnityEngine.Rigidbody::get_velocity(v130);\n\tv73 = this.storeResult;\n\tv67 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(&v59 @ V0_v4 (UnityEngine.Vector3), 0);\n\tv73.value = v59;\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetSpeed()
		{
			//IL_0065: Expected O, but got I
			if (storeResult != null)
			{
				FsmOwnerDefault fsmOwnerDefault = gameObject;
				GameObject go;
				if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
				{
					GameObject value = fsmOwnerDefault.GameObject.Value;
					go = value;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.GetSpeed)+20]");
					go = (GameObject)0;
				}
				if (UpdateCache(go))
				{
					Rigidbody rigidbody = base.rigidbody;
					Vector3 velocity = rigidbody.velocity;
					FsmFloat fsmFloat = storeResult;
					bool flag = ((ComponentAction<Rigidbody>)velocity).UpdateCache((GameObject)null);
					fsmFloat.Value = velocity.x;
				}
			}
		}

		[Token(Token = "0x6000D26")]
		[Address(RVA = "0xA35C70", Offset = "0xA35C70", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBC850]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E0F]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetSpeed()
		{
		}
	}
}
