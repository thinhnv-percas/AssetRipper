using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x200004E")]
	public class GlobalScopeContext
	{
		[Token(Token = "0x1700002A")]
		[field: Token(Token = "0x4000084")]
		[field: FieldOffset(Offset = "0x10")]
		public Transform Parent
		{
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x3F3C154", Offset = "0x3F3C154", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Parent;\n")]
			get;
		}

		[Token(Token = "0x1700002B")]
		[field: Token(Token = "0x4000085")]
		[field: FieldOffset(Offset = "0x18")]
		public Instancer Instancer
		{
			[Token(Token = "0x6000125")]
			[Address(RVA = "0x3F3C15C", Offset = "0x3F3C15C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Instancer;\n")]
			get;
		}

		[Token(Token = "0x1700002C")]
		[field: Token(Token = "0x4000086")]
		[field: FieldOffset(Offset = "0x20")]
		public GameObject GameObject
		{
			[Token(Token = "0x6000126")]
			[Address(RVA = "0x3F3C164", Offset = "0x3F3C164", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.GameObject;\n")]
			get;
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x3F3C16C", Offset = "0x3F3C16C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_002E;\nL_002E:\n\tv66 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv69 = ~v66;\n\tv70 = ~v69;\n\tif (v70) goto L_0040;\n\tv83 = 0;\n\tgoto L_0043;\nL_0040:\n\tv86 = UnityEngine.Component::get_gameObject(parent);\n\tv83 = v86;\nL_001C:\n\tSystem.Object::.ctor(this);\n\tthis.Parent = parent;\n\tthis.Instancer = instancer;\nL_0043:\n\tthis.GameObject = v83;\n\treturn;\n")]
		public GlobalScopeContext(Transform parent, Instancer instancer)
		{
			Parent = parent;
			Instancer = instancer;
			GameObject = ((parent != null) ? parent.gameObject : null);
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x3F3C258", Offset = "0x3F3C258", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv61 = ~v53;\n\tif (v61) goto L_0055;\n\tgoto L_0027;\nL_0027:\n\tUnityEngine.Debug::LogError(\"[GlobalScopeContext] Cannot instantiate null prefab in global scope\");\n\treturn 0;\nL_0055:\n\treturnVal2 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(this.Instancer, prefab, this.Parent);\n\treturn returnVal2;\n")]
		public GameObject InstantiatePrefab(GameObject prefab)
		{
			if (prefab == null)
			{
				Debug.LogError("[GlobalScopeContext] Cannot instantiate null prefab in global scope");
				return null;
			}
			return Instancer.Instantiate(prefab, Parent);
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x4983550", Offset = "0x4983550", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tgoto L_0020;\nL_0020:\n\tgoto L_0024;\nL_0024:\n\tv62 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv69 = ~v62;\n\tif (v69) goto L_005D;\n\tgoto L_0033;\nL_0033:\n\tUnityEngine.Debug::LogError(\"[GlobalScopeContext] Cannot instantiate null prefab in global scope\");\n\treturn 0;\n\tv95 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0024;\nL_005D:\n\treturnVal2 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(this.Instancer, prefab, this.Parent, 1);\n\treturn returnVal2;\n")]
		public T InstantiatePrefab<T>(T prefab) where T : Component
		{
			if (prefab == null)
			{
				Debug.LogError("[GlobalScopeContext] Cannot instantiate null prefab in global scope");
				return null;
			}
			return Instancer.Instantiate(prefab, Parent);
		}
	}
}
