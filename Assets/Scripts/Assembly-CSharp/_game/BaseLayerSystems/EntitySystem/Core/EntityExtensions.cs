using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.CommonComponents;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x2000074")]
	public static class EntityExtensions
	{
		[Token(Token = "0x4000117")]
		internal static EntityManager _entityManager;

		[Token(Token = "0x4000118")]
		internal static MonoBindingManager _monoBindingManager;

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0x3C6F8DC", Offset = "0x3C6F8DC", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv58._monoBindingManager = v54;\n\treturn;\nL_001D:\n\tv48._entityManager = entityManager;\n\tv54 = new _game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager();\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::.ctor(v54, entityManager);\n")]
		public static void Initialize(EntityManager entityManager)
		{
			_entityManager = entityManager;
			MonoBindingManager monoBindingManager = new MonoBindingManager(entityManager);
			_monoBindingManager = monoBindingManager;
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0x3C6FAF8", Offset = "0x3C6FAF8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40._entityManager;\n")]
		public static EntityManager GetManager()
		{
			return _entityManager;
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0x3C6FB44", Offset = "0x3C6FB44", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\treturn v40._monoBindingManager;\n")]
		public static MonoBindingManager GetMonoBindingManager()
		{
			return _monoBindingManager;
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0x3C6FB90", Offset = "0x3C6FB90", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_002F;\nL_002F:\n\tv128 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(v46._bindings, entity, &v106 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.EntityMono));\n\tv92 = v128 == 0;\n\tv77 = ~v92;\n\tv74 = ~v77;\n\tif (v74) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal3 = v106;\n\tgoto L_0048;\nL_FFFFFFFF:\n\treturnVal3 = 0;\nL_0051:\n\treturn 0;\nL_0018:\n\tv46 = v45._monoBindingManager;\n\tv47 = v45._monoBindingManager == 0;\n\tif (v47) goto L_0051;\nL_0048:\n\treturn returnVal3;\n")]
		public static EntityMono GetMonoBinding(this Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityExtensions::GetMonoBinding");
			return default;
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0x3C6FCE4", Offset = "0x3C6FCE4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tgoto L_0036;\nL_0036:\n\tv64 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::TryGetValue(v50._bindings, entity, mono);\n\tv66 = ~v64;\n\tif (v66) goto L_0056;\n\tgoto L_004C;\nL_004C:\n\treturnVal3 = UnityEngine.Object::op_Inequality(*([mono @ X1 (_game.BaseLayerSystems.EntitySystem.EntityMono&)]), 0);\n\treturn returnVal3;\nL_0056:\n\treturn 0;\nL_0017:\n\t*([mono @ X1 (_game.BaseLayerSystems.EntitySystem.EntityMono&)]) = 0;\n\tv50 = v49._monoBindingManager;\n\tv51 = v49._monoBindingManager == 0;\n\tif (v51) goto L_0056;\n")]
		public static bool TryGetMonoBinding(this Entity entity, out EntityMono mono)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityExtensions::TryGetMonoBinding");
			mono = default;
			return default;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0x3C6FE9C", Offset = "0x3C6FE9C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tgoto L_0034;\nL_0034:\n\treturnVal2 = System.Collections.Generic.Dictionary`2<_game.BaseLayerSystems.EntitySystem.Core.EntityId, _game.BaseLayerSystems.EntitySystem.EntityMono>::ContainsKey(v46._bindings, entity);\n\treturn returnVal2;\nL_003E:\n\treturn 0;\nL_0018:\n\tv46 = v45._monoBindingManager;\n\tv47 = v45._monoBindingManager == 0;\n\tif (v47) goto L_003E;\n")]
		public static bool HasMonoBinding(this Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityExtensions::HasMonoBinding");
			return default;
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0x3C6FFAC", Offset = "0x3C6FFAC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::Bind(v46._monoBindingManager, entity, mono);\n\treturn;\nL_002E:\n\treturn;\nL_001A:\n\tv48 = v46._monoBindingManager == 0;\n\tif (v48) goto L_002E;\n")]
		public static void BindMono(this Entity entity, EntityMono mono)
		{
			if (_monoBindingManager != null)
			{
				_monoBindingManager.Bind(entity, mono);
			}
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0x3C70218", Offset = "0x3C70218", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::Bind(v46._monoBindingManager, entity, mono);\n\treturn;\nL_002E:\n\treturn;\nL_001A:\n\tv48 = v46._monoBindingManager == 0;\n\tif (v48) goto L_002E;\n")]
		public static void BindMono_Editor(this Entity entity, EntityMono mono)
		{
			if (_monoBindingManager != null)
			{
				_monoBindingManager.Bind(entity, mono);
			}
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0x3C6D6E8", Offset = "0x3C6D6E8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::Unbind(v45._monoBindingManager, entity);\n\treturn;\nL_002C:\n\treturn;\nL_0019:\n\tv47 = v45._monoBindingManager == 0;\n\tif (v47) goto L_002C;\n")]
		public static void UnbindMono(this Entity entity)
		{
			if (_monoBindingManager != null)
			{
				_monoBindingManager.Unbind(entity);
			}
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0x3C6D678", Offset = "0x3C6D678", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(v45._entityManager, entity);\n\treturn;\nL_002C:\n\treturn;\nL_0019:\n\tv47 = v45._entityManager == 0;\n\tif (v47) goto L_002C;\n")]
		public static void Destroy(this Entity entity)
		{
			if (_entityManager != null)
			{
				_entityManager.DestroyEntity(entity);
			}
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0x3C70520", Offset = "0x3C70520", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\treturnVal2 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::IsValid(v45._entityManager, entity);\n\treturn returnVal2;\nL_002C:\n\treturn v45._entityManager;\nL_0019:\n\tv47 = ~v45._entityManager;\n\tif (v47) goto L_002C;\n")]
		public static bool IsValid(this Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityExtensions::IsValid");
			return default;
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x3C706A4", Offset = "0x3C706A4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = UnityEngine.Transform::get_position(transform);\n\tv52 = UnityEngine.Transform::get_eulerAngles(transform);\n\tv60 = UnityEngine.Transform::get_localScale(transform);\n\treturnBuffer.pos = v28;\n\t*([returnBuffer @ X8 (_game.BaseLayerSystems.EntitySystem.CommonComponents.TransformComponent)+4]) = v28.y;\n\t*([returnBuffer @ X8 (_game.BaseLayerSystems.EntitySystem.CommonComponents.TransformComponent)+8]) = v28.z;\n\treturnBuffer.euler = v52;\n\t*([returnBuffer @ X8 (_game.BaseLayerSystems.EntitySystem.CommonComponents.TransformComponent)+10]) = v52.y;\n\t*([returnBuffer @ X8 (_game.BaseLayerSystems.EntitySystem.CommonComponents.TransformComponent)+14]) = v52.z;\n\treturnBuffer.scale = v60;\n\t*([returnBuffer @ X8 (_game.BaseLayerSystems.EntitySystem.CommonComponents.TransformComponent)+1C]) = v60.y;\n\t*([returnBuffer @ X8 (_game.BaseLayerSystems.EntitySystem.CommonComponents.TransformComponent)+20]) = v60.z;\n\treturn returnBuffer;\n")]
		public static TransformComponent ToComponent(this Transform transform)
		{
			Vector3 position = transform.position;
			Vector3 eulerAngles = transform.eulerAngles;
			Vector3 localScale = transform.localScale;
			TransformComponent result = default(TransformComponent);
			result.pos = position;
			_ = position.y;
			_ = position.z;
			result.euler = eulerAngles;
			_ = eulerAngles.y;
			_ = eulerAngles.z;
			result.scale = localScale;
			_ = localScale.y;
			_ = localScale.z;
			return result;
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0x3C70730", Offset = "0x3C70730", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 14 MakeStruct v19 @ AGG3C70754_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), transformComponent.pos (UnityEngine.Vector3), transformComponent.pos.y (System.Single), transformComponent.pos.z (System.Single)\n\tUnityEngine.Transform::set_position(transform, v19);\n\t// 21 MakeStruct v40 @ AGG3C70768_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), transformComponent.euler (UnityEngine.Vector3), transformComponent.euler.y (System.Single), transformComponent.euler.z (System.Single)\n\tUnityEngine.Transform::set_eulerAngles(transform, v40);\n\t// 33 MakeStruct v50 @ AGG3C70784_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), transformComponent.scale (UnityEngine.Vector3), transformComponent.scale.y (System.Single), transformComponent.scale.z (System.Single)\n\tUnityEngine.Transform::set_localScale(transform, v50);\n\treturn;\n")]
		public static void FromComponent(this Transform transform, TransformComponent transformComponent)
		{
			Vector3 position = default(Vector3);
			position.x = transformComponent.pos.x;
			position.y = transformComponent.pos.y;
			position.z = transformComponent.pos.z;
			transform.position = position;
			Vector3 eulerAngles = default(Vector3);
			eulerAngles.x = transformComponent.euler.x;
			eulerAngles.y = transformComponent.euler.y;
			eulerAngles.z = transformComponent.euler.z;
			transform.eulerAngles = eulerAngles;
			Vector3 localScale = default(Vector3);
			localScale.x = transformComponent.scale.x;
			localScale.y = transformComponent.scale.y;
			localScale.z = transformComponent.scale.z;
			transform.localScale = localScale;
		}
	}
}
