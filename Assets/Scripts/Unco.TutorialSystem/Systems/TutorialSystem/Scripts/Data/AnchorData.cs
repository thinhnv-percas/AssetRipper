using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.TutorialSystem.Scripts.Data
{
	[Serializable]
	[Token(Token = "0x200001E")]
	public class AnchorData
	{
		[SerializeField]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x10")]
		internal Vector2 m_Min;

		[SerializeField]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x18")]
		internal Vector2 m_Max;

		[Token(Token = "0x17000012")]
		public static AnchorData Zero
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x81E2E8C", Offset = "0x81E2E8C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv40 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv40.m_Min = 0x3F;\n\tSystem.Object::.ctor(v40);\n\tv40.m_Min = 0;\n\tv40.m_Max = 0;\n\treturn v40;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AnchorData::get_Zero");
				return default;
			}
		}

		[Token(Token = "0x17000013")]
		public static AnchorData Center
		{
			[Token(Token = "0x6000094")]
			[Address(RVA = "0x81E2F44", Offset = "0x81E2F44", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv40 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv40.m_Min = 0x3F;\n\tSystem.Object::.ctor(v40);\n\tv40.m_Min = 0x3F;\n\treturn v40;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AnchorData::get_Center");
				return default;
			}
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x81E187C", Offset = "0x81E187C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 14 MakeStruct v19 @ AGG81E18A0_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.m_Min (UnityEngine.Vector2), this.m_Min.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(rectTransform, v19);\n\t// 25 MakeStruct v43 @ AGG81E18B8_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.m_Max (UnityEngine.Vector2), this.m_Max.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(rectTransform, v43);\n\treturn;\n")]
		public void SetAnchor(RectTransform rectTransform)
		{
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = m_Min.x;
			anchorMin.y = m_Min.y;
			rectTransform.anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = m_Max.x;
			anchorMax.y = m_Max.y;
			rectTransform.anchorMax = anchorMax;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x81E2FAC", Offset = "0x81E2FAC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Min = 0x3F;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public AnchorData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AnchorData::.ctor");
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x81E2EF0", Offset = "0x81E2EF0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Min = 0x3F;\n\tSystem.Object::.ctor(this);\n\tthis.m_Min.x = min;\n\tthis.m_Min.y = min.y;\n\tthis.m_Max.x = max;\n\tthis.m_Max.y = max.y;\n\treturn;\n")]
		public AnchorData(Vector2 min, Vector2 max)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AnchorData::.ctor");
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x81E2FBC", Offset = "0x81E2FBC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv47.m_Min = 0x3F;\n\tSystem.Object::.ctor(v47);\n\tv47.m_Min = this.m_Min;\n\treturn v47;\n")]
		public AnchorData Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AnchorData::Clone");
			return default;
		}
	}
}
