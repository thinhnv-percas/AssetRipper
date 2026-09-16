using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[CreateAssetMenu(menuName = "Spine/Animation Reference Asset", order = 100)]
	[Token(Token = "0x2000067")]
	public class AnimationReferenceAsset : ScriptableObject, IHasSkeletonDataAsset
	{
		[Token(Token = "0x400029C")]
		private const bool QuietSkeletonData = true;

		[SerializeField]
		[Token(Token = "0x400029D")]
		[FieldOffset(Offset = "0x18")]
		protected SkeletonDataAsset skeletonDataAsset;

		[SpineAnimation(null, null, true, false)]
		[SerializeField]
		[Token(Token = "0x400029E")]
		[FieldOffset(Offset = "0x20")]
		protected string animationName;

		[Token(Token = "0x400029F")]
		[FieldOffset(Offset = "0x28")]
		private Animation animation;

		[Token(Token = "0x1700016D")]
		public SkeletonDataAsset SkeletonDataAsset
		{
			[Token(Token = "0x6000480")]
			[Address(RVA = "0x1550D20", Offset = "0x1550D20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonDataAsset;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SkeletonDataAsset;
			}
		}

		[Token(Token = "0x1700016E")]
		public Animation Animation
		{
			[Token(Token = "0x6000481")]
			[Address(RVA = "0x1550D28", Offset = "0x1550D28", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.animation;\n\tv7 = this.animation == 0;\n\tv8 = ~v7;\n\tif (v8) goto L_000E;\n\tSpine.Unity.AnimationReferenceAsset::Initialize(this);\n\treturnVal1 = this.animation;\nL_000E:\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Animation result = animation;
				if (animation == null)
				{
					Initialize();
					result = animation;
				}
				return result;
			}
		}

		[Token(Token = "0x6000482")]
		[Address(RVA = "0x1550D4C", Offset = "0x1550D4C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.Object[];\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = UnityEngine.Object;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv60 = \"Animation '{0}' not found in SkeletonData : {1}.\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37BCB]) = v38;\nL_0021:\n\tgoto L_0026;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tv52 = UnityEngine.Object::op_Equality(this.skeletonDataAsset, 0);\n\tv57 = v52 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_003D;\n\tv76 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 1);\n\tv68 = Spine.SkeletonData::FindAnimation(v76, this.animationName);\n\tthis.animation = v68;\n\tv70 = v68 == 0;\n\tif (v70) goto L_0042;\nL_003D:\n\treturn;\nL_0042:\n\t// 66 NewArr v82 @ X0_v18 (System.Object[]), typeof(System.Object[]), 2\n\tv196 = this.animationName == 0;\n\tif (v196) goto L_0052;\n\t// 76 IsInst v187 @ X0_v30, typeof(System.Object), this.animationName (System.String)\n\tv189 = v187 == 0;\n\tif (v189) goto L_0085;\nL_0052:\n\tv82[0] = this.animationName;\n\tv201 = UnityEngine.Object::get_name(this.skeletonDataAsset);\n\tv202 = v201 == 0;\n\tif (v202) goto L_006E;\n\t// 94 IsInst v188 @ X0_v28, typeof(System.Object), v201 @ X0_v21 (System.String)\n\tv190 = v188 == 0;\n\tif (v190) goto L_0085;\nL_006E:\n\tv82[1] = v201;\n\tgoto L_0081;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v209, v169, v64, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0081:\n\tUnityEngine.Debug::LogWarningFormat(\"Animation '{0}' not found in SkeletonData : {1}.\", v82);\n\treturn;\n\tv95 = new System.NullReferenceException();\n\tv182 = new System.IndexOutOfRangeException();\nL_0085:\n\tv193 = new System.ArrayTypeMismatchException();\n\tthrow v193;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			if (SkeletonDataAsset == null)
			{
				return;
			}
			SkeletonData skeletonData = SkeletonDataAsset.GetSkeletonData(quiet: true);
			if ((animation = skeletonData.FindAnimation(animationName)) != null)
			{
				return;
			}
			object[] array = new object[2];
			if (animationName != null)
			{
				object obj = animationName as object;
				if (obj == null)
				{
					goto IL_0184;
				}
			}
			array[0] = animationName;
			string text = SkeletonDataAsset.name;
			if (text != null)
			{
				object obj2 = text as object;
				if (obj2 == null)
				{
					goto IL_0184;
				}
			}
			array[1] = text;
			Debug.LogWarningFormat("Animation '{0}' not found in SkeletonData : {1}.", array);
			return;
			IL_0184:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000483")]
		[Address(RVA = "0x15513D0", Offset = "0x15513D0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = asset.animation;\n\tv8 = asset.animation == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_0010;\n\tSpine.Unity.AnimationReferenceAsset::Initialize(asset);\n\treturnVal1 = asset.animation;\nL_0010:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator Animation(AnimationReferenceAsset asset)
		{
			Animation result = asset.animation;
			if (asset.animation == null)
			{
				asset.Initialize();
				result = asset.animation;
			}
			return result;
		}

		[Token(Token = "0x6000484")]
		[Address(RVA = "0x15513FC", Offset = "0x15513FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimationReferenceAsset()
		{
		}
	}
}
