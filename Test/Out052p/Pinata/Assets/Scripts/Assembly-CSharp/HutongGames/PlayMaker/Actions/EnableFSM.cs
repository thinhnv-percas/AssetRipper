using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D628", Offset = "0x75D628")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75D628", Offset = "0x75D628")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D628", Offset = "0x75D628")]
	[Token(Token = "0x200034A")]
	public class EnableFSM : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C939C", Offset = "0x7C939C")]
		[Token(Token = "0x4001B03")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C93E8", Offset = "0x7C93E8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C93E8", Offset = "0x7C93E8")]
		[Token(Token = "0x4001B04")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9438", Offset = "0x7C9438")]
		[Token(Token = "0x4001B05")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool enable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9470", Offset = "0x7C9470")]
		[Token(Token = "0x4001B06")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001B07")]
		[FieldOffset(Offset = "0x70")]
		private PlayMakerFSM fsmComponent;

		[Token(Token = "0x6001076")]
		[Address(RVA = "0xB74318", Offset = "0xB74318", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF3BC8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022918]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.fsmName = v43;\n\tv46 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.enable = v46;\n\tv49 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.resetOnExit = v49;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmBool fsmBool = true;
			enable = fsmBool;
			FsmBool fsmBool2 = true;
			resetOnExit = fsmBool2;
		}

		[Token(Token = "0x6001077")]
		[Address(RVA = "0xB74394", Offset = "0xB74394", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EnableFSM::DoEnableFSM(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoEnableFSM();
			Finish();
		}

		[Token(Token = "0x6001078")]
		[Address(RVA = "0xB743BC", Offset = "0xB743BC", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EEAEE8]);\n\tv27 = *([v26 @ X8_v29]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022919]) = v46;\nL_0017:\n\tv47 = this.gameObject;\n\tv50 = v47.ownerOption == 0;\n\tif (v50) goto L_0024;\n\tv173 = HutongGames.PlayMaker.FsmGameObject::get_Value(v47.gameObject);\n\tgoto L_002B;\nL_0024:\n\tv132 = this.owner;\nL_002B:\n\tgoto L_0034;\n\tv210 = *([v179 @ X0_v10+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tgoto L_0034;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v179, v174, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0034:\n\tv217 = UnityEngine.Object::op_Equality(v132, 0);\n\tv222 = v217 == 0;\n\tif (v222) goto L_0046;\n\treturn;\nL_0046:\n\tv280 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv115 = System.String::IsNullOrEmpty(v280);\n\tv282 = v115 == 0;\n\tif (v282) goto L_0059;\n\tv287 = UnityEngine.GameObject::GetComponent(v132);\n\tgoto L_009C;\nL_0059:\n\tv161 = UnityEngine.GameObject::GetComponents(v132);\n\tv207 = v161.Length;\n\tv325 = v161.Length < 1;\n\tif (v325) goto L_009A;\nL_006B:\n\tv382 = v94 < v207;\n\tv89 = ~v382;\n\tif (v89) goto L_00D6;\n\tv117 = PlayMakerFSM::get_FsmName(v161[v94 @ X24_v10 (System.Int32)]);\n\tv388 = HutongGames.PlayMaker.FsmString::get_Value(this.fsmName);\n\tv309 = System.String::op_Equality(v117, v388);\n\tv391 = v309 == 0;\n\tv311 = ~v391;\n\tif (v311) goto L_009C;\n\tv207 = v161.Length;\n\tv94 = v94 + 1;\n\tv354 = v94 < v161.Length;\n\tif (v354) goto L_006B;\nL_009A:\n\tv98 = this.fsmComponent;\n\tgoto L_00A1;\nL_009C:\n\tthis.fsmComponent = v98;\nL_00A1:\n\tgoto L_00AA;\n\tv366 = *([v349 @ X0_v18+E0]);\n\tv367 = v366 == 0;\n\tv368 = ~v367;\n\tgoto L_00AA;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v349, v341, v339, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00AA:\n\tv373 = UnityEngine.Object::op_Equality(v98, 0);\n\tv267 = v373 == 0;\n\tif (v267) goto L_00C3;\n\tHutongGames.PlayMaker.FsmStateAction::LogError(this, \"Missing FsmComponent!\");\n\treturn;\nL_00C3:\n\tv118 = HutongGames.PlayMaker.FsmBool::get_Value(this.enable);\n\tUnityEngine.Behaviour::set_enabled(this.fsmComponent, v118);\n\treturn;\n\tv171 = new System.NullReferenceException();\nL_00D6:\n\tv209 = new System.IndexOutOfRangeException();\n\tthrow v209;\n\treturn;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoEnableFSM()
		{
			FsmOwnerDefault fsmOwnerDefault = this.gameObject;
			GameObject gameObject;
			if (fsmOwnerDefault.OwnerOption != OwnerDefaultOption.UseOwner)
			{
				GameObject value = fsmOwnerDefault.GameObject.Value;
				gameObject = value;
			}
			else
			{
				gameObject = Owner;
			}
			if (gameObject == null)
			{
				return;
			}
			string value2 = fsmName.Value;
			PlayMakerFSM playMakerFSM;
			if (string.IsNullOrEmpty(value2))
			{
				PlayMakerFSM component = gameObject.GetComponent<PlayMakerFSM>();
				playMakerFSM = component;
			}
			else
			{
				PlayMakerFSM[] components = gameObject.GetComponents<PlayMakerFSM>();
				int num = components.Length;
				if (components.Length < 1)
				{
					goto IL_01d1;
				}
				int num2 = 0;
				while (true)
				{
					if (num2 < num)
					{
						string text = components[num2].FsmName;
						string value3 = fsmName.Value;
						bool flag = text == value3;
						bool flag2 = !flag;
						bool flag3 = !flag2;
						playMakerFSM = components[num2];
						if (flag3)
						{
							break;
						}
						num = components.Length;
						num2++;
						if (num2 < components.Length)
						{
							continue;
						}
						goto IL_01d1;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			fsmComponent = playMakerFSM;
			goto IL_01ef;
			IL_01ef:
			if (playMakerFSM == null)
			{
				LogError("Missing FsmComponent!");
				return;
			}
			bool value4 = enable.Value;
			fsmComponent.enabled = value4;
			return;
			IL_01d1:
			playMakerFSM = fsmComponent;
			goto IL_01ef;
		}

		[Token(Token = "0x6001079")]
		[Address(RVA = "0xB745E0", Offset = "0xB745E0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EFB308]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202291A]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.fsmComponent, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0049;\n\tv65 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetOnExit);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0049;\n\tv103 = HutongGames.PlayMaker.FsmBool::get_Value(this.enable);\n\tv89 = ~v103;\n\tUnityEngine.Behaviour::set_enabled(this.fsmComponent, v89);\n\treturn;\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			if (!(fsmComponent == null) && resetOnExit.Value)
			{
				bool value = enable.Value;
				bool flag = !value;
				fsmComponent.enabled = flag;
			}
		}

		[Token(Token = "0x600107A")]
		[Address(RVA = "0xB746AC", Offset = "0xB746AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnableFSM()
		{
		}
	}
}
