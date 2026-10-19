using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.GridEcsBinding.Components;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[Token(Token = "0x20001EE")]
	public static class VisualHandlerUtility
	{
		[Token(Token = "0x60008D7")]
		[Address(RVA = "0x42AE41C", Offset = "0x42AE41C", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tgoto L_002F;\nL_002F:\n\tgoto L_003E;\nL_003E:\n\tv96 = UnityEngine.Object::Instantiate(prefab, position, rotation, parent);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::ApplyEditorHideFlags(v96);\n\treturn v96;\n\tv98 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_003E;\n")]
		public static T Instantiate<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent) where T : Object
		{
			Object obj = Object.Instantiate(prefab, position, rotation, parent);
			ApplyEditorHideFlags(obj);
			return (T)obj;
		}

		[Token(Token = "0x60008D8")]
		[Address(RVA = "0x42AE378", Offset = "0x42AE378", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tgoto L_001B;\nL_001B:\n\tgoto L_0021;\nL_0021:\n\tv64 = UnityEngine.Object::Instantiate(prefab, parent);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.VisualHandlerUtility::ApplyEditorHideFlags(v64);\n\treturn v64;\n\tv66 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0021;\n")]
		public static T Instantiate<T>(T prefab, Transform parent) where T : Object
		{
			Object obj = Object.Instantiate(prefab, parent);
			ApplyEditorHideFlags(obj);
			return (T)obj;
		}

		[Token(Token = "0x60008D9")]
		[Address(RVA = "0x3E88D5C", Offset = "0x3E88D5C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void ApplyEditorHideFlags(Object instance)
		{
		}

		[Token(Token = "0x60008DA")]
		[Address(RVA = "0x3E83114", Offset = "0x3E83114", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv51 = 0xB292000 + 0x5A0;\n\tgoto L_0017;\nL_0017:\n\tv54 = UnityEngine.Application::get_isPlaying();\n\tv64 = *([v51 @ X21_v11 (System.Int32)]);\n\tv66 = ~v54;\n\tif (v66) goto L_0042;\n\tv81 = *([v64 @ X0_v24+E4]) == 0;\n\tif (v81) goto L_0059;\n\tUnityEngine.Object::Destroy(go);\n\treturn;\nL_0042:\n\tv87 = *([v64 @ X0_v24+E4]) == 0;\n\tif (v87) goto L_0065;\n\tUnityEngine.Object::DestroyImmediate(go);\n\treturn;\nL_0059:\n\tUnityEngine.Object::Destroy(go);\n\treturn;\nL_0065:\n\tUnityEngine.Object::DestroyImmediate(go);\n\treturn;\n")]
		public static void DestroyGo(GameObject go)
		{
			//IL_002a: Expected O, but got I4
			int num = 187244544 + 1440;
			bool isPlaying = Application.isPlaying;
			object obj = num;
			if (isPlaying)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v24+E4]");
				if ((nint)0 != 0)
				{
					Object.Destroy(go);
				}
				else
				{
					Object.Destroy(go);
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v24+E4]");
				if ((nint)0 != 0)
				{
					Object.DestroyImmediate(go);
				}
				else
				{
					Object.DestroyImmediate(go);
				}
			}
		}

		[Token(Token = "0x60008DB")]
		[Address(RVA = "0x3E83E00", Offset = "0x3E83E00", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv76 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv88 = v76 >> 0x20;\n\tv86 = v76;\n\tv83 = 0xB7D5000 + 0x538;\n\tv108 = \"il2cpp_vm_object_box\"(*([v83 @ X25_v3 (System.Int32)+48]), &v86 @ stack_-58_v2 (_game.CoreSystem.New.GridEcsBinding.Components.GridPositionComponent), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = v88;\n\tv113 = \"il2cpp_vm_object_box\"(*([v83 @ X25_v3 (System.Int32)+48]), &v81 @ stack_-5C_v2 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv95 = System.String::Format(\"{0}_{1}\", v108, v113);\n\tv157 = System.Text.StringBuilder::Append(v56, v95);\n\tv161 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::TryGetComponent(em, entity, &v119 @ stack_-54_v2 (_game.CoreSystem.New.Shared.Components.ColorComponent));\n\tv138 = ~v161;\n\tif (v138) goto L_0077;\n\tv163 = v119;\n\t// 96 Box v168 @ X0_v21 (System.Object), typeof(_game.CoreSystem.GameColor), &v163 @ stack_-58_v4 (_game.CoreSystem.New.Shared.Components.ColorComponent)\n\tv178 = System.String::Format(\"_{0}\", v168);\n\tv172 = System.Text.StringBuilder::Append(v56, v178);\nL_0077:\n\treturn v56;\nL_002C:\n\tv56 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v56);\n")]
		public static StringBuilder GenerateName(EntityManager em, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualHandlerUtility::GenerateName");
			return default;
		}

		[Token(Token = "0x60008DC")]
		[Address(RVA = "0x3E88D60", Offset = "0x3E88D60", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv58 = UnityEngine.Component::get_gameObject(v55);\n\tv92 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::GetComponent(em, entity);\n\tv93 = UnityEngine.GameObject::get_transform(v58);\n\tUnityEngine.Transform::SetParent(v93, parent, 0);\n\tv94 = UnityEngine.GameObject::get_transform(v58);\n\tv74 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::GridToWorld(visualGrid, v92);\n\tUnityEngine.Transform::set_position(v94, v74);\n\tv75 = _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts.TopGridVisualGridController::get_EffectiveCubeSize(visualGrid);\n\tv96 = UnityEngine.GameObject::get_transform(v58);\n\t// 88 MakeStruct v61 @ AGG3E88E74_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v75 @ V0_v3 (System.Single), v75 @ V0_v3 (System.Single), v75 @ V0_v3 (System.Single)\n\tUnityEngine.Transform::set_localScale(v96, v61);\n\tv97 = UnityEngine.GameObject::get_transform(v58);\n\tgoto L_0075;\nL_0075:\n\t// 117 MakeStruct v130 @ AGG3E88ED0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v150.zero (UnityEngine.Vector3), v150.zero.y (System.Single), v150.zero.z (System.Single)\n\tUnityEngine.Transform::set_localEulerAngles(v97, v130);\n\treturn v58;\nL_001D:\n\tv55 = _game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::GetMonoBinding(entity);\n")]
		private static GameObject ApplyState(Entity entity, Transform parent, TopGridVisualGridController visualGrid, EntityManager em)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualHandlerUtility::ApplyState");
			return default;
		}

		[Token(Token = "0x60008DD")]
		[Address(RVA = "0x3E83FA4", Offset = "0x3E83FA4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv54 = UnityEngine.GameObject::GetComponent(go);\n\tgoto L_002C;\nL_002C:\n\tv65 = UnityEngine.Object::op_Equality(v54, 0);\n\tv89 = ~v65;\n\tv107 = v54;\n\tif (v89) goto L_003F;\n\tv103 = UnityEngine.GameObject::AddComponent(go);\n\tv107 = v103;\nL_003F:\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityExtensions::BindMono(entity, v107);\n\treturn;\n")]
		public static void BindEntityMono(GameObject go, Entity entity)
		{
			EntityMono component = go.GetComponent<EntityMono>();
			bool flag = component == null;
			bool flag2 = !flag;
			EntityMono mono = component;
			if (!flag2)
			{
				EntityMono entityMono = go.AddComponent<EntityMono>();
				mono = entityMono;
			}
			entity.BindMono(mono);
		}
	}
}
