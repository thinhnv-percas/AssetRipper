using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Utils
{
	[Serializable]
	[Token(Token = "0x200001F")]
	public class ComponentState
	{
		[SerializeField]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x10")]
		private string m_stateKey;

		[SerializeField]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x18")]
		protected List<GameObject> m_stateObjects;

		[SerializeField]
		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x20")]
		protected List<GameObject> m_deactivedObjects;

		[Token(Token = "0x17000009")]
		public string StateKey
		{
			[Token(Token = "0x6000078")]
			[Address(RVA = "0x81C2BB4", Offset = "0x81C2BB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.StateKey;\n")]
			get
			{
				return m_stateKey;
			}
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x81C2BBC", Offset = "0x81C2BBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n")]
		public virtual bool ShouldInvoke()
		{
			return true;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x81C2BC4", Offset = "0x81C2BC4", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv58 = &v59 @ stack_-68 (System.Int32);\n\tv60 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this.m_stateObjects);\n\tv69 = v59.m_value;\n\tv157 = *([v58 @ X8_v5+10]) == 0;\n\tif (v157) goto L_007C;\n\tv124 = UnityEngine.GameObject::get_gameObject(*([v58 @ X8_v5+10]));\n\tv126 = v124 == 0;\n\tif (v126) goto L_007E;\n\tUnityEngine.GameObject::SetActive(v124, 1);\n\tgoto L_003B;\nL_004C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv106 = this.m_deactivedObjects == 0;\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = Il2CppMethodInfo;\n\tif (v106) goto L_0084;\n\tv167 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this.m_deactivedObjects);\n\tv69 = v167._list;\n\tv185 = v167.Current == 0;\n\tif (v185) goto L_0080;\n\tv240 = UnityEngine.GameObject::get_gameObject(v167.Current);\n\tUnityEngine.GameObject::SetActive(v240, 0);\n\tgoto L_0062;\nL_0073:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\nL_007B:\n\treturn;\nL_007C:\n\tv161 = new System.NullReferenceException();\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = 0;\n\tgoto L_0083;\nL_007E:\n\tv169 = new System.NullReferenceException();\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = Il2CppMethodInfo;\n\tgoto L_0083;\nL_0080:\n\tv183 = new System.NullReferenceException();\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = 0;\n\tgoto L_0083;\nL_0083:\n\t// 131 Interrupt\nL_0094:\n\tv139 = v96 != 1;\n\tif (v139) goto L_00A3;\n\tv142 = 0x8BF5BC4(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv159 = 0x8BF5BF4(v142, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v85);\n\tv150 = *([v142 @ X0_v11]) == 0;\n\tif (v150) goto L_007B;\n\tv148 = new System.OutOfMemoryException();\n\tv59 = *([v142 @ X0_v11]);\n\tv111 = v148;\nL_00A3:\n\tv155 = 0x31776C4(&v59 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00C0;\nL_00C0:\n\tv164 = 0x8BF0368(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv168 = 0x7C03E68(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0021:\n\tv47 = this.m_stateObjects == 0;\n\tif (v47) goto L_0084;\nL_003B:\n\tv129 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv141 = v129 == 0;\n\tif (v141) goto L_004C;\nL_0084:\n\tv111 = new System.NullReferenceException();\n\tgoto L_0094;\nL_0062:\n\tv243 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv226 = v243 == 0;\n\tif (v226) goto L_0073;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe virtual void Activate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentState::Activate");
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x81C2DF0", Offset = "0x81C2DF0", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv58 = &v59 @ stack_-68 (System.Int32);\n\tv60 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this.m_stateObjects);\n\tv69 = v59.m_value;\n\tv157 = *([v58 @ X8_v5+10]) == 0;\n\tif (v157) goto L_007C;\n\tv124 = UnityEngine.GameObject::get_gameObject(*([v58 @ X8_v5+10]));\n\tv126 = v124 == 0;\n\tif (v126) goto L_007E;\n\tUnityEngine.GameObject::SetActive(v124, 0);\n\tgoto L_003B;\nL_004C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv106 = this.m_deactivedObjects == 0;\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = Il2CppMethodInfo;\n\tif (v106) goto L_0084;\n\tv167 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this.m_deactivedObjects);\n\tv69 = v167._list;\n\tv185 = v167.Current == 0;\n\tif (v185) goto L_0080;\n\tv240 = UnityEngine.GameObject::get_gameObject(v167.Current);\n\tUnityEngine.GameObject::SetActive(v240, 1);\n\tgoto L_0062;\nL_0073:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\nL_007B:\n\treturn;\nL_007C:\n\tv161 = new System.NullReferenceException();\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = 0;\n\tgoto L_0083;\nL_007E:\n\tv169 = new System.NullReferenceException();\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = Il2CppMethodInfo;\n\tgoto L_0083;\nL_0080:\n\tv183 = new System.NullReferenceException();\n\tv85 = &v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>);\n\tv59 = 0;\n\tv96 = 0;\n\tgoto L_0083;\nL_0083:\n\t// 131 Interrupt\nL_0094:\n\tv139 = v96 != 1;\n\tif (v139) goto L_00A3;\n\tv142 = 0x8BF5BC4(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv159 = 0x8BF5BF4(v142, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v85);\n\tv150 = *([v142 @ X0_v11]) == 0;\n\tif (v150) goto L_007B;\n\tv148 = new System.OutOfMemoryException();\n\tv59 = *([v142 @ X0_v11]);\n\tv111 = v148;\nL_00A3:\n\tv155 = 0x31776C4(&v59 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00C0;\nL_00C0:\n\tv164 = 0x8BF0368(v111, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv168 = 0x7C03E68(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0021:\n\tv47 = this.m_stateObjects == 0;\n\tif (v47) goto L_0084;\nL_003B:\n\tv129 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv141 = v129 == 0;\n\tif (v141) goto L_004C;\nL_0084:\n\tv111 = new System.NullReferenceException();\n\tgoto L_0094;\nL_0062:\n\tv243 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v69 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv226 = v243 == 0;\n\tif (v226) goto L_0073;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe virtual void DeActivate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ComponentState::DeActivate");
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x81C301C", Offset = "0x81C301C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnDisable()
		{
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x81C3020", Offset = "0x81C3020", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ComponentState()
		{
		}
	}
}
