using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.UiControllers;
using _game.CoreGameKit.UiControllers.ScriptableObjects;

namespace Systems.TutorialSystem.Scripts.Data
{
	[Serializable]
	[Token(Token = "0x2000020")]
	public class RectData
	{
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x10")]
		public Vector3 m_Position;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x1C")]
		public Vector3 m_Rotation;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x28")]
		public Vector2 m_SizeDelta;

		[Inject(false)]
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x30")]
		private UiManager _uiManager;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x38")]
		public bool m_IsAnchoredPosition;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x40")]
		public AnchorData m_AnchorData;

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x81E3144", Offset = "0x81E3144", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv57 = UnityEngine.Transform::get_position(baseRect);\n\tv71 = v57.z + offset.m_Position.z;\n\tv75 = v57 + offset.m_Position;\n\tthis.m_Position = v75;\n\tthis.m_Position.z = v71;\n\tv78 = UnityEngine.Transform::get_rotation(baseRect);\n\tv127 = UnityEngine.Quaternion::Internal_ToEulerRad(v78);\n\tv132 = v127 * 0x42652EE1;\n\tv133 = v127.y * 0x42652EE1;\n\tv134 = v127.z * 0x42652EE1;\n\t// 65 MakeStruct v90 @ AGG81E31FC_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v132 @ V0_v6 (System.Single), v133 @ V1_v5 (System.Single), v134 @ V2_v6 (System.Single)\n\tv136 = UnityEngine.Quaternion::Internal_MakePositive(v90);\n\tv140 = v136.z + offset.m_Rotation.z;\n\tv142 = v136 + offset.m_Rotation;\n\tthis.m_Rotation = v142;\n\tthis.m_Rotation.z = v140;\n\tv145 = UnityEngine.RectTransform::get_sizeDelta(baseRect);\n\tv147 = v145 + offset.m_SizeDelta;\n\tthis.m_SizeDelta = v147;\n\tv150 = UnityEngine.RectTransform::get_anchorMin(baseRect);\n\tv156 = UnityEngine.RectTransform::get_anchorMax(baseRect);\n\tv160 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv160.m_Min = 0x3F;\n\tSystem.Object::.ctor(v160);\n\tv160.m_Min.x = v150;\n\tv160.m_Min.y = v150.y;\n\tv160.m_Max.x = v156;\n\tv160.m_Max.y = v156.y;\n\tthis.m_AnchorData = v160;\n\treturn;\nL_001C:\n\tSystem.Object::.ctor(this);\n")]
		public RectData(RectTransform baseRect, RectData offset)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RectData::.ctor");
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x81E32AC", Offset = "0x81E32AC", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv64 = UnityEngine.Transform::get_position(baseTransform);\n\tv131 = UnityEngine.Camera::WorldToScreenPoint(v59, v64);\n\tv139 = _game.CoreGameKit.UiControllers.UiManager::GetFactory(this._uiManager, 0);\n\tv209 = *([v139 @ X0_v10 (_game.CoreGameKit.UiControllers.IUiFactory)]);\n\tv252 = *([v209 @ X8_v6 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]);\n\tv211 = *([v209 @ X8_v6 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+12E]) == 0;\n\tif (v211) goto L_0067;\n\tv251 = *([v209 @ X8_v6 (Il2CppClass<_game.CoreGameKit.UiControllers.IUiFactory>)+B0]) + 8;\n\tv251 = v251 + 0x10;\n\tv237 = v252 - 1;\n\tv217 = v252 != 1;\n\tv252 = v237;\n\tif (v217) goto L_0048;\nL_0067:\n\tv307 = _game.CoreGameKit.UiControllers.IUiFactory::get_RectTransform(v139);\n\tgoto L_0076;\n\tv184 = offset.m_Position + v74;\n\tthis.m_Position = v184;\n\tthis.m_Position.z = offset.m_Position.z;\n\tthis.m_IsAnchoredPosition = 1;\n\tthis.m_SizeDelta = offset.m_SizeDelta;\n\tgoto L_0093;\n\treturn;\nL_00AD:\n\tv273 = *([v251 @ X10_v7]) << 4;\n\tv274 = v209 + v273;\n\tv275 = v274 + 0x138;\n\t*([v275 @ X8_v14])(v307, v139, *([v275 @ X8_v14+8]), 0, methodInfo, v37, v38, v39, v40, v131, v131.y, v131.z, v44, v45, v46, v47, v48);\n\tgoto L_0076;\nL_0020:\n\tSystem.Object::.ctor(this);\n\tv59 = UnityEngine.Camera::get_main();\nL_0048:\n\t;\n\tv257 = *([v251 @ X10_v7-8]) == _game.CoreGameKit.UiControllers.IUiFactory;\n\tif (v257) goto L_00AD;\nL_0076:\n\t// 118 MakeStruct v67 @ AGG81E33E8_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v131 @ V0_v3 (UnityEngine.Vector3), v131.y (System.Single)\n\tv140 = UnityEngine.RectTransformUtility::ScreenPointToLocalPointInRectangle(v307, v67, v59, &v74 @ stack_-58_v3 (UnityEngine.Vector2));\nL_0093:\n\tv326 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv326.m_Min = 0x3F;\n\tSystem.Object::.ctor(v326);\n\tv326.m_Min = 0x3F;\n\tthis.m_AnchorData = v326;\n")]
		public RectData(Transform baseTransform, RectData offset)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RectData::.ctor");
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x81E34B8", Offset = "0x81E34B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RectData()
		{
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x81E34C0", Offset = "0x81E34C0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\treturn this;\nL_001B:\n\tgoto L_0027;\nL_0035:\n\tthis.m_Rotation = v66.zero;\n\tthis.m_Rotation.z = v66.zero.z;\n\t// 56 NotImplemented \"Instruction DUP not yet implemented.\"\n\tthis.m_SizeDelta = v66.zero.z;\n\tv75 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv75.m_Min = 0x3F;\n\tSystem.Object::.ctor(v75);\n\tv75.m_Min = 0x3F;\n\tthis.m_AnchorData = v75;\nL_0027:\n\tthis.m_Position = v58.zero;\n\tthis.m_Position.z = v58.zero.z;\n\tgoto L_0035;\n")]
		public RectData Default()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RectData::Default");
			return default;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x81E107C", Offset = "0x81E107C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_AnchorData;\n\t// 19 MakeStruct v42 @ AGG81E10AC_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v14.m_Min (UnityEngine.Vector2), v14.m_Min.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(rectTransform, v42);\n\t// 25 MakeStruct v47 @ AGG81E10BC_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v14.m_Max (UnityEngine.Vector2), v14.m_Max.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(rectTransform, v47);\n\tv70 = this.m_IsAnchoredPosition != 1;\n\tif (v70) goto L_0030;\n\t// 44 MakeStruct v129 @ AGG81E10DC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Position (UnityEngine.Vector3), this.m_Position.y (System.Single), this.m_Position.z (System.Single)\n\tUnityEngine.RectTransform::set_anchoredPosition3D(rectTransform, v129);\n\tgoto L_0036;\nL_0030:\n\t// 48 MakeStruct v131 @ AGG81E10E8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Position (UnityEngine.Vector3), this.m_Position.y (System.Single), this.m_Position.z (System.Single)\n\tUnityEngine.Transform::set_position(rectTransform, v131);\nL_0036:\n\t// 54 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv136 = this.m_Rotation * this.m_Position.z;\n\tv138 = this.m_Rotation.z * 0x3C8EFA35;\n\t// 60 MakeStruct v61 @ AGG81E1114_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v136 @ V0_v5 (System.Single), v140 @ V0.S1, v138 @ V2_v3 (System.Single)\n\tv142 = UnityEngine.Quaternion::Internal_FromEulerRad(v61);\n\tUnityEngine.Transform::set_localRotation(rectTransform, v142);\n\t// 73 MakeStruct v53 @ AGG81E1130_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.m_SizeDelta (UnityEngine.Vector2), this.m_SizeDelta.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(rectTransform, v53);\n\treturn rectTransform;\n")]
		public RectTransform ApplyData(RectTransform rectTransform)
		{
			//IL_01a0: Expected F4, but got O
			AnchorData anchorData = m_AnchorData;
			Vector2 anchorMin = default(Vector2);
			anchorMin.x = anchorData.m_Min.x;
			anchorMin.y = anchorData.m_Min.y;
			rectTransform.anchorMin = anchorMin;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = anchorData.m_Max.x;
			anchorMax.y = anchorData.m_Max.y;
			rectTransform.anchorMax = anchorMax;
			if (m_IsAnchoredPosition)
			{
				Vector3 anchoredPosition3D = default(Vector3);
				anchoredPosition3D.x = m_Position.x;
				anchoredPosition3D.y = m_Position.y;
				anchoredPosition3D.z = m_Position.z;
				rectTransform.anchoredPosition3D = anchoredPosition3D;
			}
			else
			{
				Vector3 position = default(Vector3);
				position.x = m_Position.x;
				position.y = m_Position.y;
				position.z = m_Position.z;
				rectTransform.position = position;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			float x = m_Rotation.x * m_Position.z;
			float z = m_Rotation.z * ((float)Math.PI / 180f);
			Vector3 vector = default(Vector3);
			vector.x = x;
			object obj = default(object);
			vector.y = (float)obj;
			vector.z = z;
			Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
			rectTransform.localRotation = localRotation;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = m_SizeDelta.x;
			sizeDelta.y = m_SizeDelta.y;
			rectTransform.sizeDelta = sizeDelta;
			return rectTransform;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x81E35BC", Offset = "0x81E35BC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv49.m_Position.z = this.m_Position.z;\n\tv49.m_Position = this.m_Position;\n\tv49.m_Rotation.z = this.m_Rotation.z;\n\tv49.m_Rotation = this.m_Rotation;\n\tv49.m_SizeDelta = this.m_SizeDelta;\n\tv58 = this.m_AnchorData;\n\tgoto L_003C;\n\tv49.m_IsAnchoredPosition = this.m_IsAnchoredPosition;\n\treturn v49;\nL_0019:\n\tv49 = new Systems.TutorialSystem.Scripts.Data.RectData();\n\tSystem.Object::.ctor(v49);\nL_003C:\n\tv82 = new Systems.TutorialSystem.Scripts.Data.AnchorData();\n\tv82.m_Min = 0x3F;\n\tSystem.Object::.ctor(v82);\n\tv82.m_Min = v58.m_Min;\n\tv49.m_AnchorData = v82;\n")]
		public RectData Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RectData::Clone");
			return default;
		}
	}
}
