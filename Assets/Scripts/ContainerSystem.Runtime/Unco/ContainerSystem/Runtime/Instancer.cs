using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using Reflex.Core;
using Reflex.Injectors;
using Unco.GameBootstrap.Core;
using UnityEngine;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x2000050")]
	public class Instancer
	{
		[Inject(false)]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x10")]
		internal Container _container;

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x3F3C358", Offset = "0x3F3C358", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(this, prefab, 0);\n\treturn returnVal1;\n")]
		public GameObject Instantiate(GameObject prefab)
		{
			return Instantiate(prefab, null);
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x3F38C78", Offset = "0x3F38C78", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv58 = UnityEngine.Object::op_Equality(parent, 0);\n\tv66 = ~v58;\n\tv67 = ~v66;\n\tif (v67) goto L_0054;\n\tv109 = 0xB2D1000 + 0x1B0;\n\tv112 = parent;\n\tgoto L_0028;\nL_0028:\n\tv118 = UnityEngine.Object::Instantiate /* +1 sharing this address */(prefab, v112, *([v109 @ X23_v5 (System.Int32)]));\n\tReflex.Injectors.GameObjectInjector::InjectRecursive(v118, this._container);\n\treturn v118;\nL_0054:\n\tv122 = Reflex.Core.Container::Resolve(this._container);\n\tv112 = v122.Parent;\n\tv109 = 0xB2D1000 + 0x1B0;\n\tgoto L_0028;\n")]
		public GameObject Instantiate(GameObject prefab, Transform parent = null)
		{
			if (!(parent == null))
			{
				int num = 187502592 + 432;
				Transform transform = parent;
			}
			else
			{
				ScopeContext scopeContext = _container.Resolve<ScopeContext>();
				Transform transform = scopeContext.Parent;
				int num = 187502592 + 432;
			}
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4B014AC (UnityEngine.Object::Instantiate, and 1 more at this address)");
			GameObject gameObject = default(GameObject);
			GameObjectInjector.InjectRecursive(gameObject, _container);
			return gameObject;
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x49BA21C", Offset = "0x49BA21C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = 0x220C2B8(methodInfo, v39, useContextAsParent, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001F:\n\treturnVal1 = Unco.ContainerSystem.Runtime.Instancer::Instantiate(v43, v39, 0, useContextAsParent);\n\treturn returnVal1;\n")]
		public T Instantiate<T>(T prefab, bool useContextAsParent = true) where T : Component
		{
			T prefab2 = default(T);
			return Instantiate(prefab2, null, useContextAsParent);
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x49BA274", Offset = "0x49BA274", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_0021;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv69 = UnityEngine.Object::op_Equality(parent, 0);\n\tv75 = ~v69;\n\tv76 = ~v75;\n\tif (v76) goto L_003A;\n\tv103 = parent;\n\tgoto L_004A;\n\tv82 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0025;\nL_003A:\n\tv90 = ~useContextAsParent;\n\tv103 = parent;\n\tif (v90) goto L_004A;\n\tv98 = Reflex.Core.Container::Resolve(this._container);\n\tv103 = v98.Parent;\nL_0050:\n\tv117 = UnityEngine.Object::Instantiate(prefab, v103);\n\tv130 = UnityEngine.Component::get_gameObject(v117);\n\tv156 = Unco.ContainerSystem.Runtime.Instancer::InjectGameObject(this, v130);\n\treturn v117;\nL_004A:\n\tgoto L_0050;\n")]
		public T Instantiate<T>(T prefab, Transform parent, bool useContextAsParent = true) where T : Component
		{
			Transform parent2;
			if (!(parent == null))
			{
				parent2 = parent;
			}
			else
			{
				bool flag = !useContextAsParent;
				parent2 = parent;
				if (!flag)
				{
					ScopeContext scopeContext = _container.Resolve<ScopeContext>();
					parent2 = scopeContext.Parent;
				}
			}
			Component component = UnityEngine.Object.Instantiate(prefab, parent2);
			GameObject gameObject = component.gameObject;
			GameObject gameObject2 = InjectGameObject(gameObject);
			return (T)component;
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x49B9F88", Offset = "0x49B9F88", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_001D;\nL_001D:\n\tgoto L_0021;\nL_0021:\n\tv61 = UnityEngine.Object::op_Equality(parent, 0);\n\tv66 = ~v61;\n\tv67 = ~v66;\n\tif (v67) goto L_003C;\n\tv94 = parent;\n\tgoto L_004A;\n\tv73 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0021;\nL_003C:\n\tv99 = Reflex.Core.Container::Resolve(this._container);\n\tv89 = UnityEngine.Component::get_gameObject(v99.Parent);\n\tv94 = v89;\nL_004A:\n\tv105 = UnityEngine.GameObject::AddComponent(v94);\n\tv136 = UnityEngine.Component::get_gameObject(v105);\n\tv138 = Unco.ContainerSystem.Runtime.Instancer::InjectGameObject(this, v136);\n\treturn v105;\n")]
		public T AddComponent<T>(GameObject parent = null) where T : Component
		{
			GameObject gameObject;
			if (!(parent == null))
			{
				gameObject = parent;
			}
			else
			{
				ScopeContext scopeContext = _container.Resolve<ScopeContext>();
				GameObject gameObject2 = scopeContext.Parent.gameObject;
				gameObject = gameObject2;
			}
			Component component = gameObject.AddComponent<T>();
			GameObject gameObject3 = component.gameObject;
			GameObject gameObject4 = InjectGameObject(gameObject3);
			return (T)component;
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x49BA1D4", Offset = "0x49BA1D4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.Component::get_gameObject(instance);\n\tv36 = Unco.ContainerSystem.Runtime.Instancer::InjectGameObject(this, v17);\n\treturn instance;\n")]
		public T InjectMono<T>(T instance) where T : Component
		{
			GameObject gameObject = instance.gameObject;
			GameObject gameObject2 = InjectGameObject(gameObject);
			return instance;
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x3F3C360", Offset = "0x3F3C360", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tReflex.Injectors.GameObjectInjector::InjectRecursive(instance, this._container);\n\treturn instance;\n")]
		public GameObject InjectGameObject(GameObject instance)
		{
			GameObjectInjector.InjectRecursive(instance, _container);
			return instance;
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0x49BA0A8", Offset = "0x49BA0A8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tReflex.Injectors.AttributeInjector::Inject(instance, this._container);\n\treturn instance;\n")]
		public T InjectInstance<T>(T instance)
		{
			AttributeInjector.Inject(instance, _container);
			return instance;
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0x49BA3A8", Offset = "0x49BA3A8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001E:\n\treturnVal1 = Reflex.Core.Container::TryResolve(this._container, v38);\n\treturn returnVal1;\n")]
		public bool TryResolve<T>(out T result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Instancer::TryResolve");
			result = default;
			return default;
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0x3F3AEC8", Offset = "0x3F3AEC8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Reflex.Core.Container::TryResolve(this._container, type, result);\n\treturn returnVal1;\n")]
		public bool TryResolve(Type type, out object result)
		{
			result = null;
			return _container.TryResolve(type, out result);
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x3F3A9C8", Offset = "0x3F3A9C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Instancer()
		{
		}
	}
}
