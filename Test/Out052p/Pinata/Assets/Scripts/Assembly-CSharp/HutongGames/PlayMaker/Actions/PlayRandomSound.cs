using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7543E0", Offset = "0x7543E0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7543E0", Offset = "0x7543E0")]
	[Token(Token = "0x2000189")]
	public class PlayRandomSound : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AB198", Offset = "0x7AB198")]
		[Token(Token = "0x40012A6")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AB1D0", Offset = "0x7AB1D0")]
		[Token(Token = "0x40012A7")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 position;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7AB208", Offset = "0x7AB208")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7AB208", Offset = "0x7AB208")]
		[Token(Token = "0x40012A8")]
		[FieldOffset(Offset = "0x60")]
		public FsmObject[] audioClips;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB2C0", Offset = "0x7AB2C0")]
		[Token(Token = "0x40012A9")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat[] weights;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7AB2D8", Offset = "0x7AB2D8")]
		[Token(Token = "0x40012AA")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat volume;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7AB2F0", Offset = "0x7AB2F0")]
		[Token(Token = "0x40012AB")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool noRepeat;

		[Token(Token = "0x40012AC")]
		[FieldOffset(Offset = "0x80")]
		private int randomIndex;

		[Token(Token = "0x40012AD")]
		[FieldOffset(Offset = "0x84")]
		private int lastIndex;

		[Token(Token = "0x6000871")]
		[Address(RVA = "0xB19B8C", Offset = "0xB19B8C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE6C88]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022563]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.position = v44;\n\t// 37 NewArr v53 @ X0_v12 (HutongGames.PlayMaker.FsmObject[]), typeof(HutongGames.PlayMaker.FsmObject[]), 3\n\tthis.audioClips = v53;\n\t// 43 NewArr v72 @ X0_v14 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), 3\n\tv61 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tv159 = v61 == 0;\n\tif (v159) goto L_003C;\n\t// 56 IsInst v111 @ X0_v35, typeof(HutongGames.PlayMaker.FsmFloat), v61 @ X0_v16 (HutongGames.PlayMaker.FsmFloat)\nL_003C:\n\tv205 = v72.Length == 0;\n\tif (v205) goto L_0083;\n\tv72[0] = v61;\n\tv207 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tv215 = v207 == 0;\n\tif (v215) goto L_004C;\n\t// 72 IsInst v112 @ X0_v33, typeof(HutongGames.PlayMaker.FsmFloat), v207 @ X0_v21 (HutongGames.PlayMaker.FsmFloat)\nL_004C:\n\tv218 = v72.Length < 1;\n\tv99 = ~v218;\n\tv96 = v72.Length - 1;\n\tv90 = v96 == 0;\n\tv219 = ~v99;\n\tv75 = v219 | v90;\n\tif (v75) goto L_0083;\n\tv72[1] = v207;\n\tv221 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tv222 = v221 == 0;\n\tif (v222) goto L_0066;\n\t// 98 IsInst v113 @ X0_v31, typeof(HutongGames.PlayMaker.FsmFloat), v221 @ X0_v24 (HutongGames.PlayMaker.FsmFloat)\nL_0066:\n\tv225 = v72.Length < 2;\n\tv180 = ~v225;\n\tv178 = v72.Length - 2;\n\tv174 = v178 == 0;\n\tv226 = ~v180;\n\tv164 = v226 | v174;\n\tif (v164) goto L_0083;\n\tv72[2] = v221;\n\tthis.weights = v72;\n\tv228 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v228;\n\tv188 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.noRepeat = v188;\n\treturn;\nL_0083:\n\tv150 = new System.IndexOutOfRangeException();\n\tgoto L_008A;\n\tv69 = new System.NullReferenceException();\n\tv123 = new System.ArrayTypeMismatchException();\nL_008A:\n\tthrow v149;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0124: Expected O, but got I4
			//IL_01d4: Expected O, but got I4
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			position = fsmVector;
			FsmObject[] array = new FsmObject[3];
			audioClips = array;
			FsmFloat[] array2 = new FsmFloat[3];
			FsmFloat fsmFloat = 1f;
			if (fsmFloat != null)
			{
				object obj = fsmFloat as FsmFloat;
			}
			if (array2.Length != 0)
			{
				array2[0] = fsmFloat;
				FsmFloat fsmFloat2 = 1f;
				if (fsmFloat2 != null)
				{
					object obj2 = fsmFloat2 as FsmFloat;
				}
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj3 = array2.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = fsmFloat2;
					FsmFloat fsmFloat3 = 1f;
					if (fsmFloat3 != null)
					{
						object obj4 = fsmFloat3 as FsmFloat;
					}
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj5 = array2.Length - 2;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[2] = fsmFloat3;
						weights = array2;
						FsmFloat fsmFloat4 = 1f;
						volume = fsmFloat4;
						FsmBool fsmBool = false;
						noRepeat = fsmBool;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000872")]
		[Address(RVA = "0xB19D20", Offset = "0xB19D20", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.PlayRandomSound::DoPlayRandomClip(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoPlayRandomClip();
			Finish();
		}

		[Token(Token = "0x6000873")]
		[Address(RVA = "0xB19D48", Offset = "0xB19D48", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC1CE0]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022564]) = v46;\nL_0017:\n\tv47 = this.audioClips;\n\tv50 = v47.Length == 0;\n\tif (v50) goto L_00C2;\n\tv105 = HutongGames.PlayMaker.FsmBool::get_Value(this.noRepeat);\n\tv113 = this.weights;\n\tv296 = v105 == 0;\n\tif (v296) goto L_0036;\n\tv298 = v113.Length != 1;\n\tif (v298) goto L_FFFFFFFF;\nL_0036:\n\tv106 = HutongGames.PlayMaker.ActionHelpers::GetRandomWeightedIndex(v113);\n\tthis.randomIndex = v106;\n\tgoto L_0053;\n\tgoto L_0049;\nL_0045:\n\tv342 = v106 != this.lastIndex;\n\tif (v342) goto L_0052;\n\tv360 = this.weights;\nL_0049:\n\tv106 = HutongGames.PlayMaker.ActionHelpers::GetRandomWeightedIndex(v360);\n\tv339 = v106 + 1;\n\tv366 = v339 == 0;\n\tthis.randomIndex = v106;\n\tv369 = ~v366;\n\tif (v369) goto L_0045;\nL_0052:\n\tthis.lastIndex = v106;\nL_0053:\n\tv146 = v106 + 1;\n\tv82 = v146 == 0;\n\tif (v82) goto L_00C2;\n\tv114 = this.audioClips;\n\tv370 = v106 < v114.Length;\n\tv193 = ~v370;\n\tif (v193) goto L_00F3;\n\tv373 = HutongGames.PlayMaker.FsmObject::get_Value(v114[v106 @ X0_v13 (System.Int32)]);\n\tv374 = v373 == 0;\n\tif (v374) goto L_FFFFFFFF;\n\tv388 = *([v373 @ X0_v15 (UnityEngine.Object)]) != UnityEngine.AudioClip;\n\tif (v388) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_0083:\n\tgoto L_008B;\nL_008B:\n\tgoto L_0094;\n\tv399 = *([v395 @ X0_v16+E0]);\n\tv400 = v399 == 0;\n\tv401 = ~v400;\n\tgoto L_0094;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v395, v372, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0094:\n\tv142 = UnityEngine.Object::op_Inequality(v117, 0);\n\tv145 = v142 == 0;\n\tif (v145) goto L_00C2;\n\tv407 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.position);\n\tv409 = v407 == 0;\n\tif (v409) goto L_00C7;\n\tv412 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_00B5;\n\tv420 = *([v115 @ X8_v17+E0]);\n\tv421 = v420 == 0;\n\tv422 = ~v421;\n\tif (v422) goto L_00B5;\n\tv433 = v115;\n\tv424 = \"il2cpp_codegen_runtime_class_init\"(v433, v410, v411, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B5:\n\tv107 = UnityEngine.Object::op_Equality(v412, 0);\n\tv144 = v107 == 0;\n\tif (v144) goto L_00CF;\nL_00C2:\n\treturn;\nL_00C7:\n\tv164 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tv162 = v164.y;\n\tv160 = v164.z;\n\tgoto L_00DD;\nL_00CF:\n\tv206 = UnityEngine.GameObject::get_transform(v412);\n\tv164 = UnityEngine.Transform::get_position(v206);\n\tv162 = v164.y;\n\tv160 = v164.z;\nL_00DD:\n\tv436 = HutongGames.PlayMaker.FsmFloat::get_Value(this.volume);\n\t// 237 MakeStruct v222 @ AGGB19F78_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v164 @ V0_v3 (UnityEngine.Vector3), v162 @ V1_v3 (System.Single), v160 @ V2_v3 (System.Single)\n\tUnityEngine.AudioSource::PlayClipAtPoint(v117, v222, v436);\n\treturn;\n\tv119 = new System.NullReferenceException();\n\tv219 = new System.NullReferenceException();\nL_00F3:\n\tv294 = new System.IndexOutOfRangeException();\n\tthrow v294;\n\treturn;\n// 164 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoPlayRandomClip()
		{
			FsmObject[] array = audioClips;
			if (array.Length == 0)
			{
				return;
			}
			bool value = noRepeat.Value;
			FsmFloat[] array2 = weights;
			int num;
			if (!value || array2.Length == 1)
			{
				num = (randomIndex = ActionHelpers.GetRandomWeightedIndex(array2));
			}
			else
			{
				FsmFloat[] array3 = array2;
				while (true)
				{
					num = ActionHelpers.GetRandomWeightedIndex(array3);
					int num2 = num + 1;
					bool flag = num2 == 0;
					randomIndex = num;
					if (flag || num != lastIndex)
					{
						break;
					}
					array3 = weights;
				}
				lastIndex = num;
			}
			if (num + 1 == 0)
			{
				return;
			}
			FsmObject[] array4 = audioClips;
			if (num < array4.Length)
			{
				UnityEngine.Object value2 = array4[num].Value;
				UnityEngine.Object obj = (((object)value2 == null) ? null : (((object)value2.GetType() != typeof(AudioClip)) ? null : value2));
				if (!(obj != null))
				{
					return;
				}
				Vector3 value3;
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
					value3 = transform.position;
					y = value3.y;
					z = value3.z;
				}
				else
				{
					value3 = position.Value;
					y = value3.y;
					z = value3.z;
				}
				float value4 = volume.Value;
				Vector3 vector = default(Vector3);
				vector.x = value3.x;
				vector.y = y;
				vector.z = z;
				AudioSource.PlayClipAtPoint((AudioClip)obj, vector, value4);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000874")]
		[Address(RVA = "0xB19F98", Offset = "0xB19F98", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.volume = v12;\n\tthis.lastIndex = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayRandomSound()
		{
			FsmFloat fsmFloat = 1f;
			volume = fsmFloat;
			lastIndex = -1;
		}
	}
}
