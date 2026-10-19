using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine
{
	[Token(Token = "0x200000C")]
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		[Token(Token = "0x4000015")]
		public static T m_Instance;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x0")]
		public bool m_DontDestroyOnLoad;

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x626CF08", Offset = "0x626CF08", Length = "0x300")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0027:\n\tgoto L_002C;\nL_002C:\n\tv66 = UnityEngine.Object::op_Equality(v55.m_Instance, 0);\n\tv69 = ~v66;\n\tif (v69) goto L_0063;\n\tgoto L_003C;\n\tv121.m_Instance = v87;\n\tv122 = Il2CppClass<AlmostEngine.Singleton`1<T>>;\n\tv125 = *([v122 @ X0_v67 (Il2CppClass<AlmostEngine.Singleton`1<T>>)+135]) & 1;\n\tv126 = v125 == 0;\n\tv148 = Il2CppClass<AlmostEngine.Singleton`1<T>>;\n\tif (v126) goto L_008F;\nL_004F:\n\tv142 = Il2CppClass<T>;\n\tv145 = *([v142 @ X1_v28 (Il2CppClass<T>)+135]) & 1;\n\tv146 = v145 == 0;\n\tv179 = Il2CppClass<T>;\n\tv191 = Il2CppClass<T>;\n\tif (v146) goto L_009B;\nL_0056:\n\tv189 = 0x21C11D0(this, v179, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv301 = this == 0;\n\tv219 = ~v301;\n\tif (v219) goto L_00A6;\n\tgoto L_010B;\nL_0063:\n\tgoto L_0069;\nL_0069:\n\tgoto L_006D;\nL_006D:\n\tv113 = UnityEngine.Object::op_Inequality(this, v88.m_Instance);\n\tv128 = ~v113;\n\tif (v128) goto L_00CD;\n\tv205 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0081;\nL_0081:\n\tUnityEngine.Object::DestroyImmediate(v205);\n\treturn;\nL_0083:\n\tv127 = 0x220C238(Il2CppClass<AlmostEngine.Singleton`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv153 = *([v127 @ X0_v59+B8]);\n\t*([v153 @ X9_v11]) = v87;\n\tv136 = Il2CppClass<AlmostEngine.Singleton`1<T>>;\n\tv155 = *([v136 @ X0_v60 (Il2CppClass<AlmostEngine.Singleton`1<T>>)+135]) & 1;\n\tv156 = v155 == 0;\n\tv138 = ~v156;\n\tv148 = Il2CppClass<AlmostEngine.Singleton`1<T>>;\n\tif (v138) goto L_004F;\nL_008F:\n\tv151 = 0x220C238(v148, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv180 = Il2CppClass<T>;\n\tv201 = *([v180 @ X1_v25 (Il2CppClass<T>)+135]) & 1;\n\tv202 = v201 == 0;\n\tv183 = ~v202;\n\tv179 = Il2CppClass<T>;\n\tv191 = Il2CppClass<T>;\n\tif (v183) goto L_0056;\nL_009B:\n\tv197 = 0x220C238(v191, v191, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv300 = 0x21C11D0(this, v197, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00A6:\n\tv217 = UnityEngine.Component::get_transform(this);\n\tv311 = UnityEngine.Transform::get_parent(v217);\n\tgoto L_00B1;\nL_00B1:\n\tv317 = UnityEngine.Object::op_Equality(v311, 0);\n\tv321 = ~v317;\n\tv322 = ~v321;\n\tif (v322) goto L_00E1;\n\tgoto L_00FC;\nL_00CD:\n\treturn;\nL_00E1:\n\tv343 = this.m_DontDestroyOnLoad != 1;\n\tif (v343) goto L_00FC;\n\tv357 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00F0;\nL_00FC:\n\tv273 = AlmostEngine.Singleton`1::OnSingletonAwake(v273);\nL_00FC:\n\treturn;\nL_010B:\n\tthrow System.NullReferenceException;\nL_001F:\n\tgoto L_0027;\nL_003C:\n\tv87 = 0x21C11D0(this, Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv97 = Il2CppClass<AlmostEngine.Singleton`1<T>>;\n\tv100 = *([v97 @ X0_v31 (Il2CppClass<AlmostEngine.Singleton`1<T>>)+135]) & 1;\n\tv101 = v100 == 0;\n\tif (v101) goto L_0083;\nL_00F0:\n\tUnityEngine.Object::DontDestroyOnLoad(v357);\n")]
		private void Awake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Singleton::Awake");
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x626D208", Offset = "0x626D208", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_0024:\n\tgoto L_0028;\nL_0028:\n\tv69 = UnityEngine.Object::op_Equality(v52.m_Instance, this);\n\tv77 = ~v69;\n\tv78 = ~v77;\n\tif (v78) goto L_004B;\n\treturn;\nL_004B:\n\tgoto L_004E;\nL_004E:\n\tv120.m_Instance = 0;\n\treturn;\nL_001E:\n\tgoto L_0024;\n")]
		private void OnDestroy()
		{
			if (m_Instance == this)
			{
				m_Instance = null;
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x626D2FC", Offset = "0x626D2FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void OnSingletonAwake()
		{
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x626D300", Offset = "0x626D300", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_DontDestroyOnLoad = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		protected Singleton()
		{
			m_DontDestroyOnLoad = true;
		}
	}
}
