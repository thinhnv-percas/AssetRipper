using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Reflex.Injectors;
using Reflex.Resolvers;
using UnityEngine;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x2000048")]
	public readonly ref struct ContainerInstanceBuilder
	{
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<object> _registeredInstances;

		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x8")]
		private readonly List<Type> _factoryInstanceTypes;

		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x10")]
		private readonly Action<Container> _onReferenceReady;

		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x18")]
		public readonly ContainerBuilder _builder;

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x3F3A870", Offset = "0x3F3A870", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tSystem.Collections.Generic.List`1<System.Type>::.ctor(v78);\n\tthis._factoryInstanceTypes = v78;\n\tv88 = new Reflex.Core.ContainerBuilder();\n\tReflex.Core.ContainerBuilder::.ctor(v88);\n\tthis._builder = v88;\n\tv92 = v88 == 0;\n\tif (v92) goto L_0069;\n\tv88.<Parent>k__BackingField = parent->klass;\n\tv102 = new Unco.ContainerSystem.Runtime.Instancer();\n\tSystem.Object::.ctor(v102);\n\tv104 = this._builder == 0;\n\tif (v104) goto L_0069;\n\tv118 = Reflex.Core.ContainerBuilder::AddSingleton(this._builder, v102);\n\tthis._onReferenceReady = onReferenceReady;\n\treturn;\nL_0069:\n\tthrow v88;\nL_0036:\n\tv68 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v68);\n\tthis._registeredInstances = v68;\n\tv78 = new System.Collections.Generic.List`1<System.Type>();\n")]
		internal ContainerInstanceBuilder(ref Container parent, Action<Container> onReferenceReady)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInstanceBuilder::.ctor");
			this = default;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x3F3A9D0", Offset = "0x3F3A9D0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._builder;\n\tv0.<Name>k__BackingField = name;\n\treturn;\n")]
		public void SetName(string name)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInstanceBuilder::SetName");
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x3F3A9EC", Offset = "0x3F3A9EC", Length = "0x4DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0044;\n\tv67 = Reflex.Core.ContainerBuilder::Build(this._builder);\n\tSystem.Action`1<Reflex.Core.Container>::Invoke(this._onReferenceReady, v67);\n\tv304 = Reflex.Core.Container::Resolve(v67);\n\tReflex.Injectors.AttributeInjector::Inject(v304, v67);\n\tv398 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(this._registeredInstances);\n\tv147 = *([v398 @ X0_v52]);\n\tv217 = *([v398 @ X0_v52]);\n\tv407 = v304 == 0;\n\tif (v407) goto L_00BA;\n\tgoto L_0084;\nL_0081:\n\tUnco.ContainerSystem.Runtime.ContainerInitializationManager::RegisterListener(*([v398 @ X0_v52+10]));\nL_0084:\n\tv465 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v217 @ stack_-80_v7);\n\tv496 = v465 == 0;\n\tif (v496) goto L_00C0;\n\tv573 = *([v398 @ X0_v52+10]) == 0;\n\tif (v573) goto L_00AB;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v604_asT @ Z_v14 (UnityEngine.MonoBehaviour), typeof(UnityEngine.MonoBehaviour), [v398 @ X0_v52+10]\n\tv604 = v604_asT != 0;\n\tif (v604) goto L_00B6;\nL_00AB:\n\tv619 = Unco.ContainerSystem.Runtime.Instancer::InjectInstance(v304, *([v398 @ X0_v52+10]));\nL_FFFFFFFF:\n\t;\nL_00B0:\n\tgoto L_0081;\nL_00B6:\n\tv630 = Unco.ContainerSystem.Runtime.Instancer::InjectMono(v304, *([v398 @ X0_v52+10]));\nL_FFFFFFFF:\n\t;\n\tgoto L_00B0;\nL_00BA:\n\tv244 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v217 @ stack_-80_v7);\n\tv466 = ~v244;\n\tv246 = ~v466;\n\tif (v246) goto L_0142;\nL_00C0:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v217 @ stack_-80_v7);\nL_FFFFFFFF:\n\tv147 = 0;\nL_00C9:\n\tv503 = &v147 @ stack_-C0_v5 (System.Int32);\n\tv504 = System.Collections.Generic.List`1<System.Type>::GetEnumerator(this._factoryInstanceTypes);\n\tv147 = v147.m_value;\n\tv73 = v147.m_value;\n\tv577 = v304 == 0;\n\tif (v577) goto L_00ED;\n\tv351 = v304._container == 0;\n\tif (v351) goto L_012C;\n\tv638 = Reflex.Core.Container::TryResolve(v304._container, *([v503 @ X8_v13+10]), &v61 @ stack_-A8_v1 (System.Object));\n\tgoto L_00DE;\nL_00ED:\n\tv623 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v73 @ stack_-A0_v6);\n\tv642 = ~v623;\n\tv352 = ~v642;\n\tif (v352) goto L_0154;\nL_00F3:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v73 @ stack_-A0_v6);\n\tv657 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(this._registeredInstances);\n\tv217 = *([v657 @ X0_v27]);\n\tgoto L_010C;\nL_010B:\n\tUnco.ContainerSystem.Runtime.ContainerInitializationManager::NotifyInstanceAdded(*([v657 @ X0_v27+10]));\nL_010C:\n\t;\n\tv672 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v217 @ stack_-80_v7);\n\tv562 = v672 == 0;\n\tif (v562) goto L_011C;\n\tgoto L_010B;\nL_011C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v217 @ stack_-80_v7);\n\treturn v67;\nL_012C:\n\tv346 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv333 = &v73 @ stack_-A0_v6;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv340 = Il2CppMethodInfo;\n\tgoto L_0157;\nL_0142:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v275_asT @ TEMPCOND_v6 (UnityEngine.MonoBehaviour), typeof(UnityEngine.MonoBehaviour), v214 @ stack_-70_v3 (UnityEngine.MonoBehaviour)\n\tv346 = new System.NullReferenceException();\n\tgoto L_0157;\nL_0154:\n\tv346 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv333 = &v73 @ stack_-A0_v6;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv340 = Il2CppMethodInfo;\n\tgoto L_0157;\n\tv346 = new System.NullReferenceException();\nL_0157:\n\t// 343 Interrupt\n\tgoto L_0188;\nL_0188:\n\tv370 = v340 != 1;\nL_FFFFFFFF:\n\tv376 = v346;\n\tif (v370) goto L_0198;\n\tv375 = 0x8BF5BC4(v346, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv400 = 0x8BF5BF4(v375, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v333);\n\tv385 = *([v375 @ X0_v11]) == 0;\nL_FFFFFFFF:\n\tv147 = *([v375 @ X0_v11]);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v385) goto L_00C9;\n\tv383 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv376 = v383;\nL_FFFFFFFF:\n\tv147 = *([v375 @ X0_v11]);\nL_01B7:\n\tv410 = 0x8BF0368(v376, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v410, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0044:\n\tv61 = 0;\nL_00DE:\n\tv641 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v73 @ stack_-A0_v6);\n\tv647 = v641 == 0;\n\tif (v647) goto L_00F3;\nL_0198:\n\tv387 = 0x3193000(&v147 @ stack_-C0_v5 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_01B7;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe Container Build()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerInstanceBuilder::Build");
			return default;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x3F3AEE0", Offset = "0x3F3AEE0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv46 = Reflex.Core.ContainerBuilder::AddSingleton(this._builder, instance);\n\tv52 = this._registeredInstances;\n\tgoto L_004D;\nL_004D:\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v52, instance);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddSingleton(object instance)
		{
			ContainerBuilder containerBuilder = _builder.AddSingleton(instance);
			List<object> registeredInstances = _registeredInstances;
			registeredInstances.Add(instance);
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x3F3AFA8", Offset = "0x3F3AFA8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tgoto L_002C;\nL_002C:\n\tv87 = System.Object::GetType(instance);\n\tv159 = new Reflex.Resolvers.SingletonValueResolver();\n\tReflex.Resolvers.SingletonValueResolver::.ctor(v159, instance);\n\tv162 = Reflex.Core.ContainerBuilder::Add(this._builder, v87, contracts, v159);\n\tv69 = this._registeredInstances;\n\tgoto L_006F;\nL_006F:\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v69, instance);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddSingleton(object instance, params Type[] contracts)
		{
			Type type = instance.GetType();
			SingletonValueResolver resolver = new SingletonValueResolver(instance);
			ContainerBuilder containerBuilder = _builder.Add(type, contracts, resolver);
			List<object> registeredInstances = _registeredInstances;
			registeredInstances.Add(instance);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000107")]
		[Address(RVA = "0x4866C20", Offset = "0x4866C20", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv44 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\t// 30 NewArr v53 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_002C;\nL_002C:\n\tv69 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv72 = v69 == 0;\n\tif (v72) goto L_003D;\n\tv77 = 0x21C11D0(v69, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = v77 == 0;\n\tif (v81) goto L_0052;\nL_003D:\n\tv53[0] = v69;\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::AddSingleton(this, factory, v53);\n\treturn;\nL_0052:\n\tv100 = new System.ArrayTypeMismatchException();\n\tthrow v100;\n")]
		public void AddSingleton<T>(Func<Instancer, T> factory) where T : class
		{
			Type[] array = new Type[1];
			Type typeFromHandle = typeof(T);
			if ((object)typeFromHandle != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = typeFromHandle;
			AddSingleton(factory, array);
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x4866D1C", Offset = "0x4866D1C", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_0022;\n\tv49 = 0x220C2B8(methodInfo, v43, v40, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0022:\n\tv59 = Reflex.Core.ContainerBuilder::AddSingleton(this._builder, v43, v40);\n\tv75 = this._factoryInstanceTypes;\n\tgoto L_0030;\nL_0030:\n\tv67 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_0063;\nL_0063:\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v75, v67);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddSingleton<T>(Func<Instancer, T> factory, params Type[] contracts) where T : class
		{
			Func<Instancer, T> factory2 = default(Func<Instancer, T>);
			Type[] contracts2 = default(Type[]);
			ContainerBuilder containerBuilder = _builder.AddSingleton(factory2, contracts2);
			List<Type> factoryInstanceTypes = _factoryInstanceTypes;
			Type typeFromHandle = typeof(T);
			factoryInstanceTypes.Add(typeFromHandle);
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x3F3B0DC", Offset = "0x3F3B0DC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv50 = Reflex.Core.ContainerBuilder::AddSingleton(this._builder, type, v41);\n\tv56 = this._factoryInstanceTypes;\n\tgoto L_004F;\nL_004F:\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v56, type);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddSingletonFactory(Type type, Func<Instancer, object> factory)
		{
			Func<Instancer, object> factory2 = default(Func<Instancer, object>);
			ContainerBuilder containerBuilder = _builder.AddSingleton(type, factory2);
			List<Type> factoryInstanceTypes = _factoryInstanceTypes;
			factoryInstanceTypes.Add(type);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600010A")]
		[Address(RVA = "0x4866E30", Offset = "0x4866E30", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001E:\n\tv52 = Reflex.Core.ContainerBuilder::AddTransient(this._builder, v38);\n\treturn;\n")]
		public void AddTransient<T>(Func<Instancer, T> factory) where T : class
		{
			Func<Instancer, T> factory2 = default(Func<Instancer, T>);
			ContainerBuilder containerBuilder = _builder.AddTransient(factory2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600010B")]
		[Address(RVA = "0x4866E84", Offset = "0x4866E84", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = 0x220C2B8(methodInfo, v41, v39, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0020:\n\tv56 = Reflex.Core.ContainerBuilder::AddTransient(this._builder, v41, v39);\n\treturn;\n")]
		public void AddTransient<T>(Func<Instancer, T> factory, params Type[] contracts) where T : class
		{
			Func<Instancer, T> factory2 = default(Func<Instancer, T>);
			Type[] contracts2 = default(Type[]);
			ContainerBuilder containerBuilder = _builder.AddTransient(factory2, contracts2);
		}

		[Token(Token = "0x600010C")]
		[Address(RVA = "0x3F3B1AC", Offset = "0x3F3B1AC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._builder;\n\tgoto L_0027;\nL_0027:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::set_Item(v14.<OpenGenericBindings>k__BackingField, v27, v24);\n\treturn;\n")]
		public void AddOpenGenericTransient(Type openContract, Type openImplementation)
		{
			ContainerBuilder builder = _builder;
			Type key = default(Type);
			Type value = default(Type);
			builder.OpenGenericBindings[key] = value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600010D")]
		[Address(RVA = "0x4866B70", Offset = "0x4866B70", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001E:\n\tv52 = Reflex.Core.ContainerBuilder::AddScoped(this._builder, v38);\n\treturn;\n")]
		public void AddScoped<T>(Func<Instancer, T> factory) where T : class
		{
			Func<Instancer, T> factory2 = default(Func<Instancer, T>);
			ContainerBuilder containerBuilder = _builder.AddScoped(factory2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600010E")]
		[Address(RVA = "0x4866BC4", Offset = "0x4866BC4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = 0x220C2B8(methodInfo, v41, v39, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0020:\n\tv56 = Reflex.Core.ContainerBuilder::AddScoped(this._builder, v41, v39);\n\treturn;\n")]
		public void AddScoped<T>(Func<Instancer, T> factory, params Type[] contracts) where T : class
		{
			Func<Instancer, T> factory2 = default(Func<Instancer, T>);
			Type[] contracts2 = default(Type[]);
			ContainerBuilder containerBuilder = _builder.AddScoped(factory2, contracts2);
		}
	}
}
