using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x200003E")]
	public class ScopeContext
	{
		[Token(Token = "0x17000021")]
		[field: Token(Token = "0x4000060")]
		[field: FieldOffset(Offset = "0x10")]
		public Transform Parent
		{
			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x3F38A28", Offset = "0x3F38A28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Parent;\n")]
			get;
		}

		[Token(Token = "0x17000022")]
		[field: Token(Token = "0x4000061")]
		[field: FieldOffset(Offset = "0x18")]
		public Instancer Instancer
		{
			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x3F38A30", Offset = "0x3F38A30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Instancer;\n")]
			get;
		}

		[Token(Token = "0x17000023")]
		[field: Token(Token = "0x4000062")]
		[field: FieldOffset(Offset = "0x20")]
		public string ScopeName
		{
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x3F38A38", Offset = "0x3F38A38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ScopeName;\n")]
			get;
		}

		[Token(Token = "0x17000024")]
		[field: Token(Token = "0x4000063")]
		[field: FieldOffset(Offset = "0x28")]
		public GameObject GameObject
		{
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x3F38A40", Offset = "0x3F38A40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.GameObject;\n")]
			get;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x3F38A48", Offset = "0x3F38A48", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis.ScopeName = scopeName;\n\tgoto L_0034;\nL_0034:\n\tv71 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv74 = ~v71;\n\tv75 = ~v74;\n\tif (v75) goto L_0046;\n\tv88 = 0;\n\tgoto L_0049;\nL_0046:\n\tv91 = UnityEngine.Component::get_gameObject(parent);\n\tv88 = v91;\nL_001D:\n\tSystem.Object::.ctor(this);\n\tthis.Parent = parent;\n\tthis.Instancer = instancer;\nL_0049:\n\tthis.GameObject = v88;\n\treturn;\n")]
		public ScopeContext(Transform parent, Instancer instancer, string scopeName)
		{
			Parent = parent;
			Instancer = instancer;
			ScopeName = scopeName;
			GameObject = ((parent != null) ? parent.gameObject : null);
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x3F38B48", Offset = "0x3F38B48", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv61 = ~v53;\n\tif (v61) goto L_0061;\n\tv116 = System.String::Concat(\"[ScopeContext] Cannot instantiate null prefab in scope '\", this.ScopeName, \"'\");\n\tgoto L_0030;\nL_0061:\n\treturnVal1 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(this.Instancer, prefab, this.Parent);\n\treturn returnVal1;\nL_0030:\n\tUnityEngine.Debug::LogError(v116);\n\treturn 0;\n")]
		public GameObject InstantiatePrefab(GameObject prefab)
		{
			if (prefab == null)
			{
				string message = "[ScopeContext] Cannot instantiate null prefab in scope '" + ScopeName + "'";
				Debug.LogError(message);
				return null;
			}
			return Instancer.Instantiate(prefab, Parent);
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x4C929F0", Offset = "0x4C929F0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tgoto L_0023;\nL_0023:\n\tgoto L_0027;\nL_0027:\n\tv62 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv70 = ~v62;\n\tif (v70) goto L_0069;\n\tv124 = System.String::Concat(\"[ScopeContext] Cannot instantiate null prefab in scope '\", this.ScopeName, \"'\");\n\tgoto L_003F;\n\tv120 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0027;\nL_0069:\n\treturnVal1 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(this.Instancer, prefab, this.Parent, 1);\n\treturn returnVal1;\nL_003F:\n\tUnityEngine.Debug::LogError(v124);\n\treturn 0;\n")]
		public T InstantiatePrefab<T>(T prefab) where T : Component
		{
			if (prefab == null)
			{
				string message = "[ScopeContext] Cannot instantiate null prefab in scope '" + ScopeName + "'";
				Debug.LogError(message);
				return null;
			}
			return Instancer.Instantiate(prefab, Parent);
		}
	}
}
