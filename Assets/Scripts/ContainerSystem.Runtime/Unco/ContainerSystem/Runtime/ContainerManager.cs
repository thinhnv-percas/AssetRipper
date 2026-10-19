using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Core;
using Sirenix.Utilities;

namespace Unco.ContainerSystem.Runtime
{
	[Token(Token = "0x200004B")]
	public class ContainerManager
	{
		[CompilerGenerated]
		[Token(Token = "0x200004C")]
		private sealed class _003C_003Ec__DisplayClass19_0
		{
			[Token(Token = "0x4000081")]
			[FieldOffset(Offset = "0x10")]
			public ContainerManager _003C_003E4__this;

			[Token(Token = "0x4000082")]
			[FieldOffset(Offset = "0x18")]
			public Type containerType;

			[Token(Token = "0x6000120")]
			[Address(RVA = "0x3F3C0CC", Offset = "0x3F3C0CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass19_0()
			{
			}

			internal void _003CScope_Internal_003Eb__0(Container container)
			{
				ContainerManager containerManager = _003C_003E4__this;
				containerManager._containers[containerType] = container;
			}
		}

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x10")]
		private readonly Dictionary<Type, Container> _containers;

		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<Type, List<Type>> _childLists;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<Type, Type> _parentPairs;

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x3F3B21C", Offset = "0x3F3B21C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tv47 = System.Linq.Enumerable::AsEnumerable(globalInstallers);\n\tUnco.ContainerSystem.Runtime.ContainerManager::.ctor(this, v47);\n\treturn;\n")]
		public ContainerManager(params IContainerInstaller[] globalInstallers)
			: this(globalInstallers.AsEnumerable())
		{
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x3F3B280", Offset = "0x3F3B280", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0046;\n\tthis._containers = v76;\n\tv93 = new System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::.ctor(v93);\n\tthis._childLists = v93;\n\tv110 = new System.Collections.Generic.Dictionary`2<System.Type, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::.ctor(v110);\n\tthis._parentPairs = v110;\n\tv123 = new Unco.ContainerSystem.Runtime.ContainerManagerInstaller();\n\tSystem.Object::.ctor(v123);\n\tv123.Manager = this;\n\tv135 = System.Linq.Enumerable::Append(globalInstallers, v123);\n\tv139 = System.Linq.Enumerable::ToArray(v135);\n\tgoto L_0087;\nL_0087:\n\tv154 = System.Type::GetTypeFromHandle(Unco.ContainerSystem.Runtime.GlobalContainer);\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope_Internal(this, v154, v139, 0);\n\treturn;\nL_0046:\n\tSystem.Object::.ctor(this);\n\tv76 = new System.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>::.ctor(v76);\n")]
		public ContainerManager(IEnumerable<IContainerInstaller> globalInstallers)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::.ctor");
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x4867384", Offset = "0x4867384", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\treturnVal1 = Unco.ContainerSystem.Runtime.ContainerManager::Get(this, v52);\n\treturn returnVal1;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public ContainerInstance Get<T>() where T : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Get");
			return default;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x3F3B924", Offset = "0x3F3B924", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>::get_Item(this._containers, v40);\n\treturn returnVal1;\n")]
		public ContainerInstance Get(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Get");
			return default;
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x4867174", Offset = "0x4867174", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\treturnVal1 = Unco.ContainerSystem.Runtime.ContainerManager::Exists(this, v52);\n\treturn returnVal1;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public bool Exists<T>() where T : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Exists");
			return default;
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x3F3B988", Offset = "0x3F3B988", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>::ContainsKey(this._containers, v40);\n\treturn returnVal1;\n")]
		public bool Exists(Type type)
		{
			Type key = default(Type);
			return _containers.ContainsKey(key);
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x4867B5C", Offset = "0x4867B5C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv46 = Il2CppClass<T>;\n\tgoto L_0016;\nL_0016:\n\tv57 = System.Type::GetTypeFromHandle(v46);\n\treturnVal1 = Unco.ContainerSystem.Runtime.ContainerManager::TryGet(this, v57, containerInstance);\n\treturn returnVal1;\n\tv29 = 0x220C2B8(methodInfo, containerInstance, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_FFFFFFFF:\n\tv46 = Il2CppClass<T>;\n\tgoto L_0016;\n")]
		public bool TryGet<T>(out ContainerInstance containerInstance) where T : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::TryGet");
			containerInstance = default;
			return default;
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x3F3B9EC", Offset = "0x3F3B9EC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\treturnVal2 = System.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>::TryGetValue(this._containers, v41, &v54 @ stack_-38_v2 (Reflex.Core.Container));\n\tv57 = ~returnVal2;\n\tif (v57) goto L_0031;\n\tcontainerInstance.Container = v54;\nL_0018:\n\tcontainerInstance.Container = 0;\nL_0031:\n\treturn returnVal2;\n")]
		public bool TryGet(Type type, out ContainerInstance containerInstance)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::TryGet");
			containerInstance = default;
			return default;
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x4867800", Offset = "0x4867800", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv46 = Il2CppClass<TChild>;\n\tgoto L_0017;\nL_0017:\n\tv57 = System.Type::GetTypeFromHandle(v46);\n\tv67 = System.Type::GetTypeFromHandle(Il2CppClass<TParent>);\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope(this, v57, v67, installers);\n\treturn;\n\tv29 = 0x220C2B8(methodInfo, installers, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_FFFFFFFF:\n\tv46 = Il2CppClass<TChild>;\n\tgoto L_0017;\n")]
		public void Scope<TChild, TParent>(params IContainerInstaller[] installers) where TChild : IContainerType where TParent : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Scope");
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x48678AC", Offset = "0x48678AC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv46 = Il2CppClass<TChild>;\n\tgoto L_0017;\nL_0017:\n\tv57 = System.Type::GetTypeFromHandle(v46);\n\tv67 = System.Type::GetTypeFromHandle(Il2CppClass<TParent>);\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope(this, v57, v67, installers);\n\treturn;\n\tv29 = 0x220C2B8(methodInfo, installers, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_FFFFFFFF:\n\tv46 = Il2CppClass<TChild>;\n\tgoto L_0017;\n")]
		public void Scope<TChild, TParent>(IEnumerable<IContainerInstaller> installers) where TChild : IContainerType where TParent : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Scope");
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x3F3BA8C", Offset = "0x3F3BA8C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\nL_0034:\n\tv62 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::TryGetValue(this._childLists, parentType, &v60 @ stack_-48_v3 (System.Collections.Generic.List`1<System.Type>));\n\tv139 = v62 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0053;\n\tv147 = new System.Collections.Generic.List`1<System.Type>();\n\tSystem.Collections.Generic.List`1<System.Type>::.ctor(v147);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::set_Item(this._childLists, parentType, v147);\nL_0053:\n\t;\n\tgoto L_0071;\nL_0071:\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v147, childType);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::Add(this._parentPairs, childType, parentType);\n\tv224 = System.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>::get_Item(this._containers, parentType);\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope_Internal(this, childType, installers, v224);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Scope(Type childType, Type parentType, IEnumerable<IContainerInstaller> installers)
		{
			List<Type> list = default(List<Type>);
			if (!_childLists.TryGetValue(parentType, out var _))
			{
				list = new List<Type>();
				_childLists[parentType] = list;
			}
			list.Add(childType);
			_parentPairs.Add(childType, parentType);
			Container parent = _containers[parentType];
			Scope_Internal(childType, installers, parent);
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x4867740", Offset = "0x4867740", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv62 = Il2CppClass<TChild>;\n\tgoto L_0020;\nL_0020:\n\tv67 = System.Type::GetTypeFromHandle(v62);\n\tv75 = System.Linq.Enumerable::AsEnumerable(installers);\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope(this, v67, v75);\n\treturn;\n\tv69 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv62 = Il2CppClass<TChild>;\n\tgoto L_0020;\n")]
		public void Scope<TChild>(params IContainerInstaller[] installers) where TChild : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Scope");
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x4867618", Offset = "0x4867618", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv46 = Il2CppClass<TChild>;\n\tgoto L_0016;\nL_0016:\n\tv57 = System.Type::GetTypeFromHandle(v46);\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope(this, v57, installers);\n\treturn;\n\tv29 = 0x220C2B8(methodInfo, installers, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_FFFFFFFF:\n\tv46 = Il2CppClass<TChild>;\n\tgoto L_0016;\n")]
		public void Scope<TChild>(IEnumerable<IContainerInstaller> installers) where TChild : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Scope");
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x3F3BC60", Offset = "0x3F3BC60", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnco.ContainerSystem.Runtime.ContainerManager::Scope_Internal(this, childType, installers, 0);\n\treturn;\n")]
		public void Scope(Type childType, IEnumerable<IContainerInstaller> installers)
		{
			Scope_Internal(childType, installers);
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x4866EE0", Offset = "0x4866EE0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\tUnco.ContainerSystem.Runtime.ContainerManager::DisposeContainer(this, v52);\n\treturn;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		public void DisposeContainer<T>() where T : IContainerType
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::DisposeContainer");
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x3F3BC68", Offset = "0x3F3BC68", Length = "0x464")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0048;\nL_0048:\n\tv64 = System.Collections.Generic.Dictionary`2<System.Type, Reflex.Core.Container>::Remove(this._containers, v177, &v62 @ stack_-48_v8 (Reflex.Core.Container));\n\tv233 = ~v64;\n\tif (v233) goto L_017B;\n\tv323 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::TryGetValue(this._childLists, v177, &v162 @ stack_-50_v8 (System.Collections.Generic.IEnumerable`1<System.Object>));\n\tv373 = ~v323;\n\tif (v373) goto L_0151;\n\tv385 = System.Linq.Enumerable::ToList(v162);\n\tv403 = System.Linq.Enumerable::AsEnumerable(v385);\n\tv657 = System.Linq.Enumerable::Reverse(v403);\n\tv537 = *([v657 @ X0_v46 (System.Collections.Generic.IEnumerable`1<System.Type>)]);\n\tv619 = *([v537 @ X8_v36 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Type>>)+12E]);\n\tv539 = *([v537 @ X8_v36 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Type>>)+12E]) == 0;\n\tif (v539) goto L_0088;\n\tv618 = *([v537 @ X8_v36 (Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Type>>)+B0]) + 8;\n\tv618 = v618 + 0x10;\n\tv591 = v619 - 1;\n\tv571 = v619 != 1;\n\tv619 = v591;\n\tif (v571) goto L_0073;\nL_0088:\n\tv594 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::Remove(v657, System.Collections.Generic.IEnumerable`1<System.Type>);\n\tv656 = 0;\n\tv658 = v594;\n\tgoto L_0092;\nL_008D:\n\tv640 = *([v618 @ X10_v31]) << 4;\n\tv641 = v537 + v640;\n\tv658 = v641 + 0x138;\n\tv656 = &v162 @ stack_-50_v8 (System.Collections.Generic.IEnumerable`1<System.Object>);\n\tgoto L_00C8;\n\tgoto L_00F9;\nL_0100:\n\tv465 = &v76 @ stack_-60_v9 (System.Collections.IEnumerator);\n\tv424 = *([v465 @ X8_v44]);\n\tv463 = *([v465 @ X8_v44]) == 0;\n\tv417 = &v76 @ stack_-60_v9 (System.Collections.IEnumerator);\n\tv79 = 0;\n\tv426 = 6;\n\tv466 = 0;\n\tv234 = &v76 @ stack_-60_v9 (System.Collections.IEnumerator);\n\tv79 = 0;\n\tv99 = 6;\n\tv264 = 0;\n\tv227 = 0;\n\tif (v463) goto L_0131;\nL_010A:\n\tgoto L_0130;\n\tv134 = v99 == 6;\n\tif (v134) goto L_0148;\n\tv596 = v99 == 0;\n\tv307 = ~v596;\n\tif (v307) goto L_017B;\nL_0148:\n\tv389 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::Remove(this._childLists, v177);\nL_0151:\n\tv405 = System.Collections.Generic.Dictionary`2<System.Type, System.Type>::TryGetValue(this._parentPairs, v177, &v92 @ stack_-58_v7 (System.Type));\n\tv416 = v405 == 0;\n\tif (v416) goto L_0171;\n\tv540 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<System.Type>>::TryGetValue(this._childLists, v92, &v87 @ stack_-68_v8 (System.Collections.Generic.List`1<System.Type>));\n\tv595 = ~v540;\n\tif (v595) goto L_016D;\n\tv634 = System.Collections.Generic.List`1<System.Type>::Remove(v87, v177);\nL_016D:\n\tv480 = System.Collections.Generic.Dictionary`2<System.Type, System.Type>::Remove(this._parentPairs, v177);\nL_0171:\n\tReflex.Core.Container::Dispose(v62);\nL_017B:\n\treturn;\nL_017C:\n\tv713 = new System.NullReferenceException();\n\tv264 = 0;\n\tgoto L_017F;\nL_017F:\n\t// 383 Interrupt\n\tv234 = &v76 @ stack_-60_v9 (System.Collections.IEnumerator);\n\tv79 = 0;\nL_0182:\n\tv275 = new System.OutOfMemoryException();\n\tgoto L_0191;\nL_0191:\n\tv335 = v264 != 1;\n\tif (v335) goto L_01A1;\n\tv375 = 0x8BF5BC4(v275, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv466 = *([v375 @ X0_v17]);\n\tv394 = 0x8BF5BF4(v375, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv424 = *([v234 @ stack_-70_v3]);\n\tv409 = *([v234 @ stack_-70_v3]) == 0;\n\tv410 = ~v409;\n\tv417 = v234;\n\tv79 = *([v375 @ X0_v17]);\n\tv426 = 0;\n\tif (v410) goto L_010A;\n\tv79 = *([v375 @ X0_v17]);\n\tv99 = 0;\n\tv227 = *([v375 @ X0_v17]);\n\tgoto L_0131;\n\treturn;\n\tthrow System.NullReferenceException;\nL_0073:\n\tv624 = *([v618 @ X10_v31-8]) == System.Collections.Generic.IEnumerable`1<System.Type>;\n\tif (v624) goto L_008D;\nL_0092:\n\tv658.m_value(v662, v657, *([v658 @ X8_v37 (System.Boolean)+8]), v656, Il2CppMethodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00C8:\n\tv461 = System.Collections.IEnumerator::MoveNext(v76);\n\tv776 = v461 == 0;\n\tif (v776) goto L_0100;\nL_00F9:\n\tv839 = System.Collections.Generic.IEnumerator`1<System.Type>::get_Current(v76);\n\tUnco.ContainerSystem.Runtime.ContainerManager::DisposeContainer(this, v839);\n\tgoto L_009C;\nL_009C:\n\tv708 = v76 == 0;\n\tif (v708) goto L_017C;\nL_0131:\n\tv501 = v227 == 0;\n\tv271 = ~v501;\n\tif (v271) goto L_0182;\nL_0130:\n\tSystem.IDisposable::Dispose(v424);\n\tv234 = v417;\n\tv99 = v426;\n\tv264 = 0;\n\tv227 = v466;\nL_01A1:\n\tv377 = 0x3175484(&v79 @ stack_-78_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv396 = 0x8BF0368(v275, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv361 = 0xA1B8(v396, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void DisposeContainer(Type containerType)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::DisposeContainer");
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x3F3B4C0", Offset = "0x3F3B4C0", Length = "0x464")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = parent;\n\tgoto L_0038;\n\tv59.<>4__this = this;\n\tv59.containerType = containerType;\n\tv261 = new System.Action`1<Reflex.Core.Container>();\n\tSystem.Action`1<Reflex.Core.Container>::.ctor(v261, v59, Il2CppMethodInfo);\n\tUnco.ContainerSystem.Runtime.ContainerInstanceBuilder::.ctor(&v159 @ stack_-B0_v7 (Unco.ContainerSystem.Runtime.ContainerInstanceBuilder), &v28 @ stack_-58_v1 (Reflex.Core.Container), v261);\n\tv146 = v159;\n\tgoto L_006D;\nL_006D:\n\tv306 = Sirenix.Utilities.TypeExtensions::GetNiceName(v59.containerType);\n\tv371 = v312 + 0x10;\n\t*([v371 @ X0_v40]) = v306;\n\tgoto L_00A7;\n\tgoto L_00E9;\n\tv701 = v91 == 0;\n\tif (v701) goto L_018A;\n\tgoto L_011A;\n\tgoto L_00B9;\nL_0143:\n\tv360 = &v91 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv363 = *([v360 @ X8_v24]);\n\tv357 = *([v360 @ X8_v24]) == 0;\n\tv313 = &v91 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv146 = v159;\n\tv343 = v159;\n\tv159 = 0;\n\tv346 = 0;\n\tv347 = 0;\n\tv348 = 0;\n\tv365 = 0;\n\tv219 = &v91 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv146 = 0;\n\tv236 = 0;\n\tv159 = 0;\n\tv239 = 0;\n\tv240 = 0;\n\tv241 = 0;\n\tv244 = 0;\n\tv192 = v249;\n\tv203 = v252;\n\tv210 = 0;\n\tif (v357) goto L_0172;\nL_0147:\n\t;\n\tv368 = *([v363 @ X20_v7]);\n\tv482 = *([v368 @ X8_v8+12E]);\n\tv370 = *([v368 @ X8_v8+12E]) == 0;\n\tif (v370) goto L_0168;\n\tv481 = *([v368 @ X8_v8+B0]) + 8;\n\tv481 = v481 + 0x10;\n\tv416 = v482 - 1;\n\tv396 = v482 != 1;\n\tv482 = v416;\n\tif (v396) goto L_014E;\nL_0168:\n\tv503 = 0x220C5E0(v363, *([v249 @ X22_v7 (Unco.ContainerSystem.Runtime.ContainerManager+<>c__DisplayClass19_0)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv241 = 0;\n\tgoto L_016E;\nL_016A:\n\t;\n\tv500 = *([v481 @ X10_v9]) << 4;\n\tv501 = v368 + v500;\n\tv503 = v501 + 0x138;\n\tv241 = v348;\n\tv184 = Unco.ContainerSystem.Runtime.ContainerInstanceBuilder::Build(&v146 @ stack_-80_v5 (Unco.ContainerSystem.Runtime.ContainerInstanceBuilder));\n\tv455 = Reflex.Core.Container::TryResolve /* +1 sharing this address */(v184, &v56 @ stack_-90_v1, *([v203 @ X21_v2 (Unco.ContainerSystem.Runtime.ContainerManager)]));\n\treturn;\nL_0188:\n\tv632 = new System.NullReferenceException();\n\tv241 = 0;\n\tv244 = 0;\n\tgoto L_018D;\nL_018A:\n\tv699 = new System.NullReferenceException();\n\tgoto L_018D;\nL_018D:\n\t// 397 Interrupt\n\tv219 = &v91 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv159 = 0;\n\tv239 = 0;\n\tv240 = 0;\nL_0190:\n\tv256 = new System.OutOfMemoryException();\n\tgoto L_019E;\nL_019E:\n\tv277 = v244 != 1;\n\tif (v277) goto L_01AC;\n\tv285 = 0x8BF5BC4(v256, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv365 = *([v285 @ X0_v18]);\n\tv297 = 0x8BF5BF4(v285, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv363 = *([v219 @ stack_-A8_v3]);\n\tv309 = *([v219 @ stack_-A8_v3]) == 0;\n\tv310 = ~v309;\n\tv313 = v219;\n\tv343 = v236;\n\tv159 = *([v285 @ X0_v18]);\n\tv346 = v239;\n\tv347 = v240;\n\tv348 = v241;\n\tif (v310) goto L_0147;\n\tv159 = *([v285 @ X0_v18]);\n\tv192 = v192;\n\tv203 = v203;\n\tv210 = *([v285 @ X0_v18]);\n\tgoto L_0172;\nL_01AC:\n\tv288 = 0x3175484(&v159 @ stack_-B0_v7 (Unco.ContainerSystem.Runtime.ContainerInstanceBuilder), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = 0x8BF0368(v256, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv311 = 0xA1B8(v299, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0038:\n\tv56 = 0;\n\tv59 = new Unco.ContainerSystem.Runtime.ContainerManager+<>c__DisplayClass19_0();\n\tSystem.Object::.ctor(v59);\n\tthrow System.NullReferenceException;\nL_00A7:\n\tv249 = 0xB28F000 + 0x8D0;\n\tv252 = 0xB2C2000 + 0x930;\n\tv585 = System.Collections.Generic.IEnumerable`1<Unco.ContainerSystem.Runtime.IContainerInstaller>::GetEnumerator(installers);\n\tv241 = 0;\n\tv244 = 0;\n\tgoto L_00BD;\nL_00E9:\n\tv355 = System.Collections.IEnumerator::MoveNext(v91);\n\tv714 = v355 == 0;\n\tif (v714) goto L_0143;\nL_011A:\n\tv777 = System.Collections.Generic.IEnumerator`1<Unco.ContainerSystem.Runtime.IContainerInstaller>::get_Current(v91);\nL_00B9:\n\tv241 = 0;\n\tv619 = Unco.ContainerSystem.Runtime.IContainerInstaller::InstallBindings(0, &v146 @ stack_-80_v5 (Unco.ContainerSystem.Runtime.ContainerInstanceBuilder));\n\tv244 = &v146 @ stack_-80_v5 (Unco.ContainerSystem.Runtime.ContainerInstanceBuilder);\nL_0172:\n\tv390 = v210 == 0;\n\tv248 = ~v390;\n\tv249 = v192;\n\tv252 = v203;\n\tif (v248) goto L_0190;\nL_014E:\n\t;\n\tv487 = *([v481 @ X10_v9-8]) == *([v249 @ X22_v7 (Unco.ContainerSystem.Runtime.ContainerManager+<>c__DisplayClass19_0)]);\n\tif (v487) goto L_016A;\nL_016E:\n\t;\n\tv244 = *([v503 @ X0_v21+8]);\n\t*([v503 @ X0_v21])(v387, v363, *([v503 @ X0_v21+8]), v241, v347, methodInfo, v41, v42, v43, v346, v343, v46, v47, v48, v49, v50, v51);\n\tv219 = v313;\n\tv236 = v343;\n\tv239 = v346;\n\tv240 = v347;\n\tv192 = v249;\n\tv203 = v252;\n\tv210 = v365;\nL_00BD:\n\tv627 = v91 == 0;\n\tif (v627) goto L_0188;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Scope_Internal(Type containerType, IEnumerable<IContainerInstaller> installers, Container parent = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerManager::Scope_Internal");
		}
	}
}
