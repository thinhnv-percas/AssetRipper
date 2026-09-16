using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754430", Offset = "0x754430")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x754430", Offset = "0x754430")]
	[Token(Token = "0x200018A")]
	public class PlaySound : FsmStateAction
	{
		[Token(Token = "0x40012AE")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x40012AF")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 position;

		[RequiredField]
		[Attribute(Type = typeof(TitleAttribute), RVA = "0x7AB328", Offset = "0x7AB328")]
		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7AB328", Offset = "0x7AB328")]
		[Token(Token = "0x40012B0")]
		[FieldOffset(Offset = "0x60")]
		public FsmObject clip;

		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB3C0", Offset = "0x7AB3C0")]
		[Token(Token = "0x40012B1")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat volume;

		[Token(Token = "0x6000875")]
		[Address(RVA = "0xB19FD4", Offset = "0xB19FD4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED75E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022565]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tv42 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v42);\n\tv42.useVariable = 1;\n\tthis.position = v42;\n\tthis.clip = 0;\n\tv49 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v49;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			position = fsmVector;
			clip = null;
			FsmFloat fsmFloat = 1f;
			volume = fsmFloat;
		}

		[Token(Token = "0x6000876")]
		[Address(RVA = "0xB1A05C", Offset = "0xB1A05C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.PlaySound::DoPlaySound(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoPlaySound();
			Finish();
		}

		[Token(Token = "0x6000877")]
		[Address(RVA = "0xB1A084", Offset = "0xB1A084", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA4EC0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022566]) = v46;\nL_001B:\n\tv50 = HutongGames.PlayMaker.FsmObject::get_Value(this.clip);\n\tv127 = v50 == 0;\n\tif (v127) goto L_FFFFFFFF;\n\tv169 = *([v50 @ X0_v8 (UnityEngine.Object)]) != UnityEngine.AudioClip;\n\tif (v169) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\tgoto L_0039;\nL_0039:\n\tgoto L_0042;\n\tv246 = *([v176 @ X0_v9+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tgoto L_0042;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v176, v49, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0042:\n\tv253 = UnityEngine.Object::op_Equality(v125, 0);\n\tv230 = v253 == 0;\n\tif (v230) goto L_005A;\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, \"Missing Audio Clip!\");\n\treturn;\nL_005A:\n\tv256 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv258 = v256 == 0;\n\tif (v258) goto L_0085;\n\tv261 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0073;\n\tv269 = *([v122 @ X8_v9+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0073;\n\tv282 = v122;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v282, v259, v260, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0073:\n\tv149 = UnityEngine.Object::op_Equality(v261, 0);\n\tv231 = v149 == 0;\n\tif (v231) goto L_008D;\n\treturn;\nL_0085:\n\tv56 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tv54 = v56.y;\n\tv52 = v56.z;\n\tgoto L_009B;\nL_008D:\n\tv112 = UnityEngine.GameObject::get_transform(v261);\n\tv56 = UnityEngine.Transform::get_position(v112);\n\tv54 = v56.y;\n\tv52 = v56.z;\nL_009B:\n\tv285 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\t// 171 MakeStruct v182 @ AGGB1A244_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v56 @ V0_v3 (UnityEngine.Vector3), v54 @ V1_v3 (System.Single), v52 @ V2_v3 (System.Single)\n\tUnityEngine.AudioSource::PlayClipAtPoint(v125, v182, v285);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoPlaySound()
		{
			Object value = clip.Value;
			Object obj = (((object)value == null) ? null : (((object)value.GetType() != typeof(AudioClip)) ? null : value));
			if (obj == null)
			{
				LogWarning("Missing Audio Clip!");
				return;
			}
			Vector3 value2;
			float y;
			float z;
			if (position.IsNone)
			{
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				if (ownerDefaultTarget == null)
				{
					return;
				}
				Transform transform = ownerDefaultTarget.transform;
				value2 = transform.position;
				y = value2.y;
				z = value2.z;
			}
			else
			{
				value2 = position.Value;
				y = value2.y;
				z = value2.z;
			}
			float value3 = volume.Value;
			Vector3 vector = default(Vector3);
			vector.x = value2.x;
			vector.y = y;
			vector.z = z;
			AudioSource.PlayClipAtPoint((AudioClip)obj, vector, value3);
		}

		[Token(Token = "0x6000878")]
		[Address(RVA = "0xB1A254", Offset = "0xB1A254", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v12;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlaySound()
		{
			FsmFloat fsmFloat = 1f;
			volume = fsmFloat;
		}
	}
}
