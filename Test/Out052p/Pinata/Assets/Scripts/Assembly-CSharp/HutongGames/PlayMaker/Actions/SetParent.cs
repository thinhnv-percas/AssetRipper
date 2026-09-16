using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75672C", Offset = "0x75672C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75672C", Offset = "0x75672C")]
	[Token(Token = "0x20001F8")]
	public class SetParent : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1704", Offset = "0x7B1704")]
		[Token(Token = "0x4001482")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1750", Offset = "0x7B1750")]
		[Token(Token = "0x4001483")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject parent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B1788", Offset = "0x7B1788")]
		[Token(Token = "0x4001484")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool resetLocalPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B17C0", Offset = "0x7B17C0")]
		[Token(Token = "0x4001485")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool resetLocalRotation;

		[Token(Token = "0x6000A54")]
		[Address(RVA = "0x9980B4", Offset = "0x9980B4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.resetLocalPosition = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			resetLocalPosition = null;
		}

		[Token(Token = "0x6000A55")]
		[Address(RVA = "0x9980C0", Offset = "0x9980C0", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ECA300]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021783]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002C;\n\tv142 = *([v92 @ X8_v5+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_002C;\n\tv149 = v92;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v149, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv123 = UnityEngine.Object::op_Inequality(v47, 0);\n\tv151 = v123 == 0;\n\tif (v151) goto L_00B0;\n\tv124 = UnityEngine.GameObject::get_transform(v47);\n\tv203 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.parent);\n\tgoto L_004B;\n\tv207 = *([v85 @ X8_v8+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_004B;\n\tv216 = v85;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v216, v202, v116, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004B:\n\tv215 = UnityEngine.Object::op_Equality(v203, 0);\n\tv218 = v215 == 0;\n\tv219 = ~v218;\n\tif (v219) goto L_005F;\n\tv76 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.parent);\n\tv221 = UnityEngine.GameObject::get_transform(v76);\nL_005F:\n\tUnityEngine.Transform::set_parent(v124, v72);\n\tv226 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetLocalPosition);\n\tv228 = v226 == 0;\n\tif (v228) goto L_0087;\n\tv230 = UnityEngine.GameObject::get_transform(v47);\n\tgoto L_007A;\n\tv241 = *([v136 @ X8_v15+E0]);\n\tv242 = v241 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_007A;\n\tv248 = v136;\n\tv245 = \"il2cpp_codegen_runtime_class_init\"(v248, v120, v68, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_007A:\n\tv106 = UnityEngine.Vector3::get_zero();\n\tUnityEngine.Transform::set_localPosition(v230, v106);\nL_0087:\n\tv197 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetLocalRotation);\n\tv198 = v197 == 0;\n\tif (v198) goto L_00B0;\n\tv250 = UnityEngine.GameObject::get_transform(v47);\n\tgoto L_009D;\n\tv256 = *([v137 @ X8_v12+E0]);\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_009D;\n\tv262 = v137;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v262, v121, v68, v27, v28, v29, v30, v31, v56, v54, v52, v35, v36, v37, v38, v39);\nL_009D:\n\tv107 = UnityEngine.Quaternion::get_identity();\n\tUnityEngine.Transform::set_localRotation(v250, v107);\nL_00B0:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				Transform transform = ownerDefaultTarget.transform;
				GameObject value = parent.Value;
				bool flag = value == null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				Transform transform2 = null;
				if (!flag3)
				{
					GameObject value2 = parent.Value;
					Transform transform3 = value2.transform;
					transform2 = transform3;
				}
				transform.parent = transform2;
				if (resetLocalPosition.Value)
				{
					Transform transform4 = ownerDefaultTarget.transform;
					Vector3 zero = Vector3.zero;
					transform4.localPosition = zero;
				}
				if (resetLocalRotation.Value)
				{
					Transform transform5 = ownerDefaultTarget.transform;
					Quaternion identity = Quaternion.identity;
					transform5.localRotation = identity;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000A56")]
		[Address(RVA = "0x9982BC", Offset = "0x9982BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetParent()
		{
		}
	}
}
