using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000049")]
	public class BoneLocalOverride : MonoBehaviour
	{
		[SpineBone(null, null, true, false)]
		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x20")]
		public string boneName;

		[Space]
		[Range(0f, 1f)]
		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x28")]
		public float alpha;

		[Space]
		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x2C")]
		public bool overridePosition;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x30")]
		public Vector2 localPosition;

		[Space]
		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x38")]
		public bool overrideRotation;

		[Range(0f, 360f)]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x3C")]
		public float rotation;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x40")]
		private ISkeletonAnimation spineComponent;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x48")]
		private Bone bone;

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x1514ECC", Offset = "0x1514ECC", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Spine.Unity.ISkeletonAnimation;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv124 = Spine.Unity.UpdateBonesDelegate;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v124, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A5E]) = v40;\nL_001F:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.spineComponent = v43;\n\tv47 = v43 == 0;\n\tif (v47) goto L_0070;\n\tv59 = new Spine.Unity.UpdateBonesDelegate();\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v59, this, Il2CppMethodInfo);\n\tgoto L_005C;\n\tv160 = *([v127 @ X8_v6+B0]);\n\tv161 = v160 + 8;\n\tv163 = *([v199 @ X10_v6-8]);\n\tv205 = v163 == v128;\n\tif (v205) goto L_0054;\n\tv185 = v200 - 1;\n\tv183 = v199 + 0x10;\n\tv165 = v200 != 1;\n\tif (v165) goto L_FFFFFFFF;\n\tv186 = v53;\n\tv187 = 0;\n\tv188 = 0xB349B4(v186, v128, v187, v100, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_005C;\nL_0054:\n\tv211 = *([v199 @ X10_v6]);\n\tv212 = v211 << 4;\n\tv213 = v127 + v212;\n\tv214 = v213 + 0x138;\nL_005C:\n\tSpine.Unity.ISkeletonAnimation::add_UpdateLocal(v43, v59);\n\tv109 = this.bone == 0;\n\tif (v109) goto L_0070;\n\treturn;\nL_0070:\n\tUnityEngine.Behaviour::set_enabled(this, 0);\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			ISkeletonAnimation skeletonAnimation = (spineComponent = GetComponent<ISkeletonAnimation>());
			if (skeletonAnimation != null)
			{
				UpdateBonesDelegate value = OverrideLocal;
				skeletonAnimation.UpdateLocal += value;
				if (bone != null)
				{
					return;
				}
			}
			base.enabled = false;
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x1515004", Offset = "0x1515004", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, animated, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Spine.Unity.ISkeletonAnimation;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, animated, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv55 = System.Object[];\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, animated, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv163 = \"Cannot find bone: '{0}'\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, animated, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37A5F]) = v34;\nL_0019:\n\tv35 = this.bone;\n\tv36 = this.bone == 0;\n\tif (v36) goto L_0028;\n\tv40 = v35.data;\n\tv47 = System.String::op_Inequality(v40.name, this.boneName);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0067;\nL_0028:\n\tv53 = System.String::IsNullOrEmpty(this.boneName);\n\tv160 = v53 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_00AA;\n\tgoto L_005D;\n\tv341 = *([v282 @ X8_v15+B0]);\n\tv342 = v341 + 8;\n\tv344 = *([v384 @ X10_v12-8]);\n\tv389 = v344 == v285;\n\tif (v389) goto L_0055;\n\tv364 = v383 - 1;\n\tv366 = v384 + 0x10;\n\tv346 = v383 != 1;\n\tif (v346) goto L_FFFFFFFF;\n\tv367 = 6;\n\tv368 = v156;\n\tv369 = 0xB349B4(v368, v285, v367, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_005D;\nL_0055:\n\tv400 = *([v384 @ X10_v12]);\n\tv401 = v400 + 6;\n\tv402 = v401 << 4;\n\tv403 = v282 + v402;\n\tv404 = v403 + 0x138;\nL_005D:\n\tv143 = Spine.Unity.ISkeletonAnimation::get_Skeleton(this.spineComponent);\n\tv244 = Spine.Skeleton::FindBone(v143, this.boneName);\n\tthis.bone = v244;\n\tv246 = v244 == 0;\n\tif (v246) goto L_00AF;\nL_0067:\n\tv249 = ~this.overridePosition;\n\tif (v249) goto L_0087;\n\tv151 = this.bone;\n\tv372 = UnityEngine.Mathf::Min(this.alpha, 1f);\n\tv336 = this.alpha < 0;\n\tv330 = ~v336;\n\tv324 = ~v330;\n\tif (v324) goto L_0082;\n\tgoto L_0082;\nL_0082:\n\tv326 = this.localPosition - v151.x;\n\tv412 = v326 * v413;\n\tv329 = v151.x + v412;\n\tv151.x = v329;\nL_0087:\n\tv236 = ~this.overrideRotation;\n\tif (v236) goto L_00AA;\n\tv152 = this.bone;\n\tv208 = UnityEngine.Mathf::Min(this.alpha, 1f);\n\tv225 = this.alpha < 0;\n\tv213 = ~v225;\n\tv200 = ~v213;\n\tif (v200) goto L_FFFFFFFF;\n\tgoto L_00A2;\nL_00A2:\n\tv202 = this.rotation - v152.rotation;\n\tv204 = v202 * v416;\n\tv210 = v152.rotation + v204;\n\tv152.rotation = v210;\nL_00AA:\n\treturn;\nL_00AF:\n\t// 175 NewArr v142 @ X0_v19 (System.Object[]), typeof(System.Object[]), 1\n\tv419 = this.boneName == 0;\n\tif (v419) goto L_00BF;\n\t// 185 IsInst v273 @ X0_v26, typeof(System.Object), this.boneName (System.String)\n\tv275 = v273 == 0;\n\tif (v275) goto L_00D5;\nL_00BF:\n\tv142[0] = this.boneName;\n\tgoto L_00D1;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v425, v186, v134, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_00D1:\n\tUnityEngine.Debug::LogFormat(\"Cannot find bone: '{0}'\", v142);\n\treturn;\n\tv158 = new System.NullReferenceException();\n\tv197 = new System.IndexOutOfRangeException();\nL_00D5:\n\tv280 = new System.ArrayTypeMismatchException();\n\tthrow v280;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OverrideLocal(ISkeletonAnimation animated)
		{
			Bone bone = this.bone;
			if (this.bone != null)
			{
				BoneData data = bone.Data;
				if (!(data.Name != boneName))
				{
					goto IL_00c2;
				}
			}
			if (string.IsNullOrEmpty(boneName))
			{
				return;
			}
			Skeleton skeleton = spineComponent.Skeleton;
			if ((this.bone = skeleton.FindBone(boneName)) != null)
			{
				goto IL_00c2;
			}
			object[] array = new object[1];
			if (boneName != null)
			{
				object obj = boneName as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = boneName;
			Debug.LogFormat("Cannot find bone: '{0}'", array);
			return;
			IL_00c2:
			if (overridePosition)
			{
				Bone bone2 = this.bone;
				float num = Mathf.Min(alpha, 1f);
				if (!(alpha < 0f))
				{
				}
				float num2 = localPosition.x - bone2.X;
				object obj2 = default(object);
				float num3 = num2 * (float)obj2;
				float x = bone2.X + num3;
				bone2.X = x;
			}
			if (overrideRotation)
			{
				Bone bone3 = this.bone;
				float num4 = Mathf.Min(alpha, 1f);
				float num5 = ((alpha < 0f) ? 0f : num4);
				float num6 = rotation - bone3.Rotation;
				float num7 = num6 * num5;
				float num8 = bone3.Rotation + num7;
				bone3.Rotation = num8;
			}
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x1515228", Offset = "0x1515228", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.alpha = 1f;\n\tthis.overridePosition = 1;\n\tthis.overrideRotation = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneLocalOverride()
		{
			alpha = 1f;
			overridePosition = true;
			overrideRotation = true;
		}
	}
}
