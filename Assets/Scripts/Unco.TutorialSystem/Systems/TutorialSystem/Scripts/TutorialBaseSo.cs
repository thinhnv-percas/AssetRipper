using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;

namespace Systems.TutorialSystem.Scripts
{
	[CreateAssetMenu(fileName = "TutorialBaseSo", menuName = "UFC/Tutorial/TutorialBaseSo", order = 0)]
	[Token(Token = "0x200000E")]
	public sealed class TutorialBaseSo : ScriptableObject
	{
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x18")]
		public List<TutorialData> m_TutorialStepList;

		[SerializeField]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x20")]
		private TutorialType m_TutorialType;

		[Inject(false)]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x28")]
		private TutorialStorageData _tutorialData;

		[Token(Token = "0x17000008")]
		private string PrefName
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x81DF7B4", Offset = "0x81DF7B4", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv49 = Systems.TutorialSystem.Scripts.TutorialType;\n\tv55 = System.Enum::ToString(&v49 @ stack_-48_v1 (Il2CppClass<Systems.TutorialSystem.Scripts.TutorialType>));\n\treturnVal1 = System.String::Concat(v55, \"Index\");\n\treturn returnVal1;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("TutorialBaseSo::get_PrefName");
				return default;
			}
		}

		[Token(Token = "0x17000009")]
		public TutorialData CurrentData
		{
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x81DF848", Offset = "0x81DF848", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetActiveTutorialData(this);\n\treturn returnVal1;\n")]
			get
			{
				return GetActiveTutorialData();
			}
		}

		[Token(Token = "0x1700000A")]
		public TutorialType TutorialType
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x81DF8E8", Offset = "0x81DF8E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.TutorialType;\n")]
			get
			{
				return m_TutorialType;
			}
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x81DF84C", Offset = "0x81DF84C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv45 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this);\n\tv47 = v39.Count <= v45;\n\tif (v47) goto L_003F;\n\tv74 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this);\n\treturnVal3 = System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialData>::get_Item(this.m_TutorialStepList, v74);\n\treturn returnVal3;\nL_003F:\n\treturn 0;\nL_0015:\n\tv39 = this.m_TutorialStepList;\n")]
		public TutorialData GetActiveTutorialData()
		{
			List<TutorialData> tutorialStepList = m_TutorialStepList;
			int index = GetIndex();
			if (tutorialStepList.Count > index)
			{
				int index2 = GetIndex();
				return m_TutorialStepList[index2];
			}
			return null;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x81DF9F8", Offset = "0x81DF9F8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv50 = Systems.TutorialSystem.Scripts.TutorialType;\n\tv55 = System.Enum::ToString(&v50 @ stack_-48_v1 (Il2CppClass<Systems.TutorialSystem.Scripts.TutorialType>));\n\treturnVal1 = System.String::Concat(v55, \"Index\");\n\treturn returnVal1;\n")]
		private string GetPrefName()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialBaseSo::GetPrefName");
			return default;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x81DF8F0", Offset = "0x81DF8F0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv90 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::TryGetValue(v73.Indices, v72, &v89 @ stack_-4C_v2 (System.Int32));\n\tv117 = v90 == 0;\n\tv102 = ~v117;\n\tv99 = ~v102;\n\tif (v99) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal3 = v89;\n\tgoto L_0057;\nL_FFFFFFFF:\n\treturnVal3 = 0;\nL_0060:\n\treturn 0;\nL_001E:\n\tgoto L_002A;\nL_0057:\n\treturn returnVal3;\nL_002A:\n\tv62 = Systems.TutorialSystem.Scripts.TutorialType;\n\tv67 = System.Enum::ToString(&v62 @ stack_-48_v1 (Il2CppClass<Systems.TutorialSystem.Scripts.TutorialType>));\n\tv72 = System.String::Concat(v67, \"Index\");\n\tv73 = this._tutorialData;\n\tv74 = this._tutorialData == 0;\n\tif (v74) goto L_0060;\n")]
		public int GetIndex()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialBaseSo::GetIndex");
			return default;
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x81DFA8C", Offset = "0x81DFA8C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this);\n\tv14 = v12 + 1;\n\tSystems.TutorialSystem.Scripts.TutorialBaseSo::SetActiveIndex(this, v14);\n\treturn;\n")]
		public void TutorialStepCompleted()
		{
			int index = GetIndex();
			int activeIndex = index + 1;
			SetActiveIndex(activeIndex);
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x81DFBA4", Offset = "0x81DFBA4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv45 = v39 - v40.Count;\n\tv46 = v45 < 0;\n\tv48 = v39 ^ v40.Count;\n\tv49 = v39 ^ v45;\n\tv50 = v48 & v49;\n\tv51 = v50 < 0;\n\tv52 = v46 == v51;\n\treturn v52;\nL_0013:\n\tv39 = Systems.TutorialSystem.Scripts.TutorialBaseSo::GetIndex(this);\n\tv40 = this.m_TutorialStepList;\n")]
		public bool IsCompleted()
		{
			int index = GetIndex();
			List<TutorialData> tutorialStepList = m_TutorialStepList;
			int num = index - tutorialStepList.Count;
			bool flag = num < 0;
			int num2 = index ^ tutorialStepList.Count;
			int num3 = index ^ num;
			int num4 = num2 & num3;
			bool flag2 = num4 < 0;
			return flag == flag2;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x81DFAB4", Offset = "0x81DFAB4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_002F;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::set_Item(v47.Indices, v130, index);\nL_004B:\n\treturn;\nL_0017:\n\tv47 = this._tutorialData;\n\tv48 = this._tutorialData == 0;\n\tif (v48) goto L_004B;\nL_002F:\n\tv66 = Systems.TutorialSystem.Scripts.TutorialType;\n\tv106 = System.Enum::ToString(&v66 @ stack_-58_v2 (Il2CppClass<Systems.TutorialSystem.Scripts.TutorialType>));\n\tv130 = System.String::Concat(v106, \"Index\");\n")]
		public void SetActiveIndex(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TutorialBaseSo::SetActiveIndex");
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x81DFC00", Offset = "0x81DFC00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystems.TutorialSystem.Scripts.TutorialBaseSo::SetActiveIndex(this, 0);\n\treturn;\n")]
		public void ResetTutorial()
		{
			SetActiveIndex(0);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x81DFC08", Offset = "0x81DFC08", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tSystems.TutorialSystem.Scripts.TutorialBaseSo::SetActiveIndex(v36, v41.Count);\n\treturn;\nL_0014:\n\tv41 = v36.m_TutorialStepList;\n")]
		public void ForceCompleted()
		{
			List<TutorialData> tutorialStepList = m_TutorialStepList;
			SetActiveIndex(tutorialStepList.Count);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x81DFC5C", Offset = "0x81DFC5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialData>();\n\tSystem.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.TutorialData>::.ctor(v48);\n\tthis.m_TutorialStepList = v48;\n")]
		public TutorialBaseSo()
		{
			List<TutorialData> tutorialStepList = new List<TutorialData>();
			m_TutorialStepList = tutorialStepList;
		}
	}
}
