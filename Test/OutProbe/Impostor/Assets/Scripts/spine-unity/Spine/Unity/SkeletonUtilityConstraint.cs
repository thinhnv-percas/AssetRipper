using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonUtilityConstraint")]
	[RequireComponent(typeof(SkeletonUtilityBone))]
	[ExecuteAlways]
	[Token(Token = "0x200009E")]
	public abstract class SkeletonUtilityConstraint : MonoBehaviour
	{
		[Token(Token = "0x40003E3")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonUtilityBone bone;

		[Token(Token = "0x40003E4")]
		[FieldOffset(Offset = "0x28")]
		public SkeletonUtility hierarchy;

		[Token(Token = "0x6000658")]
		[Address(RVA = "0x156CE08", Offset = "0x156CE08", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CBA]) = v38;\nL_0018:\n\tv41 = UnityEngine.Component::GetComponent(this);\n\tthis.bone = v41;\n\tv46 = UnityEngine.Component::get_transform(this);\n\tv51 = UnityEngine.Component::GetComponentInParent(v46);\n\tthis.hierarchy = v51;\n\tSpine.Unity.SkeletonUtility::RegisterConstraint(v51, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void OnEnable()
		{
			SkeletonUtilityBone component = GetComponent<SkeletonUtilityBone>();
			bone = component;
			Transform transform = base.transform;
			(hierarchy = transform.GetComponentInParent<SkeletonUtility>()).RegisterConstraint(this);
		}

		[Token(Token = "0x6000659")]
		[Address(RVA = "0x156CE94", Offset = "0x156CE94", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonUtility::UnregisterConstraint(this.hierarchy, this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void OnDisable()
		{
			hierarchy.UnregisterConstraint(this);
		}

		[Token(Token = "0x600065A")]
		public abstract void DoUpdate();

		[Token(Token = "0x600065B")]
		[Address(RVA = "0x156CEB0", Offset = "0x156CEB0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonUtilityConstraint()
		{
		}
	}
}
