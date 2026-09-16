using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000B4")]
	public class SpineBone : SpineAttributeBase
	{
		[Token(Token = "0x60006A9")]
		[Address(RVA = "0x15709A8", Offset = "0x15709A8", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SpineAttributeBase::.ctor(this);\n\tthis.dataField = dataField;\n\tthis.startsWith = startsWith;\n\tthis.includeNone = includeNone;\n\tthis.fallbackToTextField = fallbackToTextField;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineBone(string startsWith = "", string dataField = "", bool includeNone = true, bool fallbackToTextField = false)
		{
			base.dataField = dataField;
			base.startsWith = startsWith;
			base.includeNone = includeNone;
			base.fallbackToTextField = fallbackToTextField;
		}

		[Token(Token = "0x60006AA")]
		[Address(RVA = "0x15709E8", Offset = "0x15709E8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = renderer.skeleton == 0;\n\tif (v7) goto L_0010;\n\treturnVal3 = Spine.Skeleton::FindBone(renderer.skeleton, boneName);\n\treturn returnVal3;\nL_0010:\n\treturn renderer.skeleton;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Bone GetBone(string boneName, SkeletonRenderer renderer)
		{
			if (renderer.skeleton != null)
			{
				return renderer.skeleton.FindBone(boneName);
			}
			return (Bone)(object)renderer.skeleton;
		}

		[Token(Token = "0x60006AB")]
		[Address(RVA = "0x1570A18", Offset = "0x1570A18", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(skeletonDataAsset, 1);\n\treturnVal2 = Spine.SkeletonData::FindBone(v12, boneName);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static BoneData GetBoneData(string boneName, SkeletonDataAsset skeletonDataAsset)
		{
			SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: true);
			return skeletonData.FindBone(boneName);
		}
	}
}
