using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Generics;
using Reflex.Resolvers;
using Unco.ContainerSystem.Runtime;

namespace Reflex.Core
{
	[Token(Token = "0x2000037")]
	public sealed class ContainerBuilder
	{
		[CompilerGenerated]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x30")]
		private Action<Container> OnContainerBuilt;

		[Token(Token = "0x1700001B")]
		[field: Token(Token = "0x400004E")]
		[field: FieldOffset(Offset = "0x10")]
		internal string Name
		{
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x3F3747C", Offset = "0x3F3747C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Name>k__BackingField;\n")]
			get;
			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x3F37484", Offset = "0x3F37484", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Name>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001C")]
		[field: Token(Token = "0x400004F")]
		[field: FieldOffset(Offset = "0x18")]
		internal Container Parent
		{
			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x3F3748C", Offset = "0x3F3748C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Parent>k__BackingField;\n")]
			get;
			[Token(Token = "0x60000AF")]
			[Address(RVA = "0x3F37494", Offset = "0x3F37494", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Parent>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001D")]
		[field: Token(Token = "0x4000050")]
		[field: FieldOffset(Offset = "0x20")]
		internal List<Binding> Bindings
		{
			[Token(Token = "0x60000B0")]
			[Address(RVA = "0x3F3749C", Offset = "0x3F3749C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Bindings>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x1700001E")]
		[field: Token(Token = "0x4000051")]
		[field: FieldOffset(Offset = "0x28")]
		internal Dictionary<Type, Type> OpenGenericBindings
		{
			[Token(Token = "0x60000B1")]
			[Address(RVA = "0x3F374A4", Offset = "0x3F374A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<OpenGenericBindings>k__BackingField;\n")]
			get;
		}

		[CompilerGenerated]
		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x3F374AC", Offset = "0x3F374AC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Reflex.Core.Container>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnContainerBuilt;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnContainerBuilt (System.Action`1<Reflex.Core.Container>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnContainerBuilt(Action<Container> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerBuilder::add_OnContainerBuilt");
		}

		[CompilerGenerated]
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x3F37560", Offset = "0x3F37560", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Reflex.Core.Container>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\t;\nL_FFFFFFFF:\n\tv87 = this.OnContainerBuilt;\n\tgoto L_002E;\nL_001F:\n\tv84 = System.Threading.Interlocked::CompareExchange(&this.OnContainerBuilt (System.Action`1<Reflex.Core.Container>), v82, v87);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnContainerBuilt(Action<Container> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerBuilder::remove_OnContainerBuilt");
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x3F36134", Offset = "0x3F36134", Length = "0x964")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v29 @ stack_-B0;\n\tgoto L_007A;\n\tSystem.Object::.ctor(v77);\n\tv127 = new System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::.ctor(v127);\n\tv136 = this.<Parent>k__BackingField;\n\tv139 = this.<Parent>k__BackingField == 0;\nL_FFFFFFFF:\n\tv250 = v77;\nL_FFFFFFFF:\n\tv264 = this;\n\tif (v139) goto L_010B;\n\tv275 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::GetEnumerator(v136.<ResolversByContract>k__BackingField);\n\t*([v28 @ X26_v1+10]) = v275._dictionary;\n\t*([v28 @ X26_v1+20]) = *([v275 @ X0_v98 (System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>+Enumerator<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>)+10]);\n\tv422 = v127 == 0;\n\tif (v422) goto L_00FA;\n\t*([v28 @ X26_v1]) = *([v28 @ X26_v1+20]);\n\tSystem.Collections.Generic.KeyValuePair`2<System.Object, System.Object>::Deconstruct(&v29 @ stack_-B0, &v656 @ stack_-B8_v11 (System.Type), &v757 @ stack_-C0_v10 (System.Collections.Generic.IEnumerable`1<Reflex.Resolvers.IResolver>));\n\tv911 = new System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>();\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::.ctor(v911, v757);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::set_Item(v127, v656, v911);\n\tgoto L_00DD;\nL_00FA:\n\tv508 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v419 @ stack_-A0);\n\tv676 = ~v508;\n\tv677 = ~v676;\n\tif (v677) goto L_027F;\nL_0102:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v419 @ stack_-A0);\nL_FFFFFFFF:\n\tv245 = 0;\nL_FFFFFFFF:\n\tv250 = v77;\nL_FFFFFFFF:\n\tv264 = this;\nL_010B:\n\tv399 = &v245 @ stack_-138 (System.Int32);\n\tv400 = System.Collections.Generic.List`1<Reflex.Core.Binding>::GetEnumerator(v264.<Bindings>k__BackingField);\n\tv460 = *([v399 @ X8_v9+10]);\n\tv316 = v245.m_value;\n\tv490 = v250 == 0;\n\tif (v490) goto L_01A8;\n\tgoto L_0129;\nL_0123:\n\tv699 = *([v716 @ X19_v16+18]) >= 1;\n\tif (v699) goto L_0271;\nL_0129:\n\tv574 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v316 @ stack_-E0_v3 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\n\tv863 = v574 == 0;\n\tif (v863) goto L_01B0;\n\tv576 = *([v399 @ X8_v9+10]) == 0;\nL_FFFFFFFF:\n\tv823 = &v316 @ stack_-E0_v3 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>);\nL_FFFFFFFF:\n\tv245 = 0;\nL_FFFFFFFF:\n\tv829 = Il2CppMethodInfo;\n\tif (v576) goto L_0278;\n\tgoto L_013E;\n\tSystem.Collections.Generic.Stack`1<System.Object>::Push(*([v114 @ X0_v8]), *([v460 @ stack_-128_v2+10]));\n\tv716 = *([v460 @ stack_-128_v2+18]);\n\tv848 = *([v460 @ stack_-128_v2+18]) == 0;\n\tif (v848) goto L_026F;\n\tv714 = v127 == 0;\n\tif (v714) goto L_0123;\n\tv700 = *([v716 @ X19_v16+18]) < 1;\n\tif (v700) goto L_0129;\n\tv705 = *([v460 @ stack_-128_v2+18]) + 0x20;\nL_FFFFFFFF:\n\tv859 = 0;\n\tgoto L_016C;\nL_015E:\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::Add(v1172, *([v460 @ stack_-128_v2+10]));\n\tv859 = v859 + 1;\n\tv701 = v859 >= *([v716 @ X19_v16+18]);\n\tif (v701) goto L_0129;\nL_016C:\n\t;\n\tv1121 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(v127, *([v705 @ X22_v8+v859 @ X20_v18 (System.Int32)*8]), &v1118 @ stack_-E8_v6 (System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>));\n\tv1156 = v1121 == 0;\n\tv1157 = ~v1156;\nL_FFFFFFFF:\n\tv831 = *([v705 @ X22_v8+v859 @ X20_v18 (System.Int32)*8]);\n\tif (v1157) goto L_0186;\n\tv1172 = new System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>();\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::.ctor(v1172);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::Add(v127, *([v705 @ X22_v8+v859 @ X20_v18 (System.Int32)*8]), v1172);\nL_FFFFFFFF:\n\tv1118 = v1172;\nL_FFFFFFFF:\n\tv831 = *([v705 @ X22_v8+v859 @ X20_v18 (System.Int32)*8]);\nL_0186:\n\tv1184 = v1172 == 0;\n\tif (v1184) goto L_026D;\n\tv1193 = v1172._version + 1;\n\tv1172._version = v1193;\n\tv715 = v1172._items == 0;\nL_FFFFFFFF:\n\tv831 = *([v460 @ stack_-128_v2+10]);\n\tif (v715) goto L_026D;\n\tgoto L_015E;\nL_01A8:\n\tv474 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v316 @ stack_-E0_v3 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\n\tv724 = ~v474;\n\tv476 = ~v724;\n\tif (v476) goto L_0275;\nL_01B0:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v316 @ stack_-E0_v3 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\n\tv965 = v958.<OpenGenericImplementations>k__BackingField == 0;\n\tif (v965) goto L_01FE;\n\tv983 = System.Collections.Generic.Dictionary`2<System.Type, System.Type>::GetEnumerator(v958.<OpenGenericImplementations>k__BackingField);\n\tv763 = v983._dictionary;\n\tv1079 = v936 == 0;\n\tif (v1079) goto L_01F1;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::set_Item(v936, *([v983 @ X0_v41 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>+Enumerator<System.Type, System.Type>)+10]), v1185);\n\tgoto L_01E3;\nL_01F1:\n\tv1095 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v763 @ stack_-110_v5 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\nL_01F8:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v763 @ stack_-110_v5 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\nL_01FE:\n\tv986 = System.Collections.Generic.Dictionary`2<System.Type, System.Type>::GetEnumerator(this.<OpenGenericBindings>k__BackingField);\n\tv763 = v986._dictionary;\n\tv1084 = v936 == 0;\n\tif (v1084) goto L_0229;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::set_Item(v936, *([v986 @ X0_v22 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>+Enumerator<System.Type, System.Type>)+10]), v1185);\n\tgoto L_021B;\nL_0229:\n\tv1102 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v763 @ stack_-110_v5 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\n\tv1151 = v1102 == 0;\n\tv849 = ~v1151;\n\tif (v849) goto L_027C;\nL_0230:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v763 @ stack_-110_v5 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>));\n\tv387 = this.<Bindings>k__BackingField;\n\tSystem.Collections.Generic.List`1<Reflex.Core.Binding>::Clear(v387);\n\tv1022 = v387.Count < 1;\n\tif (v1022) goto L_024E;\nL_024E:\n\tv1222 = new Reflex.Core.Container();\n\tReflex.Core.Container::.ctor(v1222, this.<Name>k__BackingField, this.<Parent>k__BackingField, v127, v77, v936);\n\tv1061 = this.OnContainerBuilt == 0;\n\tif (v1061) goto L_026C;\n\tSystem.Action`1<Reflex.Core.Container>::Invoke(this.OnContainerBuilt, v1222);\nL_026D:\n\tv840 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv823 = &v763 @ stack_-110_v5 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>);\nL_FFFFFFFF:\n\tv245 = 0;\nL_FFFFFFFF:\n\tv829 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv838 = v839;\n\tgoto L_0294;\nL_026F:\n\tv841 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv823 = &v316 @ stack_-E0_v3 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>);\nL_FFFFFFFF:\n\tv245 = 0;\nL_FFFFFFFF:\n\tv829 = v831;\nL_FFFFFFFF:\n\tv838 = v840;\n\tgoto L_0294;\nL_0271:\n\tv842 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv823 = &v316 @ stack_-E0_v3 (System.Collections.Generic.Dictionary`2<System.Type, System.Type>);\nL_FFFFFFFF:\n\tv245 = 0;\nL_FFFFFFFF:\n\tv829 = *([v460 @ stac\n// ... truncated")]
		internal unsafe Container Build()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerBuilder::Build");
			return default;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x3F37614", Offset = "0x3F37614", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Name>k__BackingField = name;\n\treturn this;\n")]
		internal ContainerBuilder SetName(string name)
		{
			Name = name;
			return this;
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x3F3610C", Offset = "0x3F3610C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Parent>k__BackingField = parent;\n\treturn this;\n")]
		internal ContainerBuilder SetParent(Container parent)
		{
			Parent = parent;
			return this;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x3F3763C", Offset = "0x3F3763C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv53 = System.Object::GetType(instance);\n\tv57 = new Reflex.Resolvers.SingletonValueResolver();\n\tReflex.Resolvers.SingletonValueResolver::.ctor(v57, instance);\n\treturnVal2 = Reflex.Core.ContainerBuilder::Add(this, v53, contracts, v57);\n\treturn returnVal2;\n")]
		internal ContainerBuilder AddSingleton(object instance, params Type[] contracts)
		{
			Type type = instance.GetType();
			SingletonValueResolver resolver = new SingletonValueResolver(instance);
			return Add(type, contracts, resolver);
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x3F377BC", Offset = "0x3F377BC", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv56 = System.Object::GetType(instance);\n\tv75 = v56 == 0;\n\tif (v75) goto L_0032;\n\tv79 = 0x21C11D0(v56, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = v79 == 0;\n\tif (v81) goto L_005C;\nL_0032:\n\tv51[0] = v56;\n\tgoto L_0044;\n\treturnVal2 = Reflex.Core.ContainerBuilder::Add(this, v137, v51, v140);\n\treturn returnVal2;\nL_005C:\n\tv86 = new System.ArrayTypeMismatchException();\n\tthrow v86;\nL_001B:\n\t// 27 NewArr v51 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\nL_0044:\n\tv137 = System.Object::GetType(instance);\n\tv140 = new Reflex.Resolvers.SingletonValueResolver();\n\tReflex.Resolvers.SingletonValueResolver::.ctor(v140, instance);\n")]
		internal ContainerBuilder AddSingleton(object instance)
		{
			Type[] array = new Type[1];
			Type type = instance.GetType();
			if ((object)type != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = type;
			Type type2 = instance.GetType();
			SingletonValueResolver resolver = new SingletonValueResolver(instance);
			return Add(type2, array, resolver);
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x486625C", Offset = "0x486625C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv45 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\tv53 = new Reflex.Resolvers.SingletonFactoryResolver();\n\tReflex.Resolvers.SingletonFactoryResolver::.ctor(v53, factory);\n\tgoto L_002F;\nL_002F:\n\tv71 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\treturnVal1 = Reflex.Core.ContainerBuilder::Add(this, v71, contracts, v53);\n\treturn returnVal1;\n")]
		internal ContainerBuilder AddSingleton<T>(Func<Instancer, T> factory, params Type[] contracts) where T : class
		{
			SingletonFactoryResolver resolver = new SingletonFactoryResolver(factory);
			Type typeFromHandle = typeof(T);
			return Add(typeFromHandle, contracts, resolver);
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x4866160", Offset = "0x4866160", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv44 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\t// 30 NewArr v53 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_002C;\nL_002C:\n\tv69 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv72 = v69 == 0;\n\tif (v72) goto L_003D;\n\tv77 = 0x21C11D0(v69, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = v77 == 0;\n\tif (v81) goto L_0052;\nL_003D:\n\tv53[0] = v69;\n\treturnVal1 = Reflex.Core.ContainerBuilder::AddSingleton(this, factory, v53);\n\treturn returnVal1;\nL_0052:\n\tv100 = new System.ArrayTypeMismatchException();\n\tthrow v100;\n")]
		internal ContainerBuilder AddSingleton<T>(Func<Instancer, T> factory) where T : class
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
			return AddSingleton(factory, array);
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x3F378DC", Offset = "0x3F378DC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tSystem.Object::.ctor(v56);\n\tv56._factory = factory;\n\treturnVal1 = Reflex.Core.ContainerBuilder::Add(this, type, contracts, v56);\n\treturn returnVal1;\nL_001E:\n\tv56 = new Reflex.Resolvers.SingletonFactoryResolver();\n\tgoto L_002E;\nL_002E:\n\tv72 = new System.Object();\n\tSystem.Object::.ctor(v72);\n\tv56._lock = v72;\n")]
		internal ContainerBuilder AddSingleton(Type type, Func<Instancer, object> factory, params Type[] contracts)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ContainerBuilder::AddSingleton");
			return default;
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x3F379C8", Offset = "0x3F379C8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv55 = type == 0;\n\tif (v55) goto L_002D;\n\tv60 = 0x21C11D0(type, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv64 = v60 == 0;\n\tif (v64) goto L_0041;\nL_002D:\n\tv52[0] = type;\n\treturnVal1 = Reflex.Core.ContainerBuilder::AddSingleton(this, type, factory, v52);\n\treturn returnVal1;\nL_0041:\n\tv83 = new System.ArrayTypeMismatchException();\n\tthrow v83;\nL_001C:\n\t// 28 NewArr v52 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n")]
		internal ContainerBuilder AddSingleton(Type type, Func<Instancer, object> factory)
		{
			Type[] array = new Type[1];
			if ((object)type != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj = default(object);
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			array[0] = type;
			return AddSingleton(type, factory, array);
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x4866414", Offset = "0x4866414", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv45 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\tv53 = new Reflex.Resolvers.TransientFactoryResolver();\n\tReflex.Resolvers.TransientFactoryResolver::.ctor(v53, factory);\n\tgoto L_002F;\nL_002F:\n\tv71 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\treturnVal1 = Reflex.Core.ContainerBuilder::Add(this, v71, contracts, v53);\n\treturn returnVal1;\n")]
		internal ContainerBuilder AddTransient<T>(Func<Instancer, T> factory, params Type[] contracts) where T : class
		{
			TransientFactoryResolver resolver = new TransientFactoryResolver(factory);
			Type typeFromHandle = typeof(T);
			return Add(typeFromHandle, contracts, resolver);
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x4866318", Offset = "0x4866318", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv44 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\t// 30 NewArr v53 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_002C;\nL_002C:\n\tv69 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv72 = v69 == 0;\n\tif (v72) goto L_003D;\n\tv77 = 0x21C11D0(v69, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = v77 == 0;\n\tif (v81) goto L_0052;\nL_003D:\n\tv53[0] = v69;\n\treturnVal1 = Reflex.Core.ContainerBuilder::AddTransient(this, factory, v53);\n\treturn returnVal1;\nL_0052:\n\tv100 = new System.ArrayTypeMismatchException();\n\tthrow v100;\n")]
		internal ContainerBuilder AddTransient<T>(Func<Instancer, T> factory) where T : class
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
			return AddTransient(factory, array);
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x48660A4", Offset = "0x48660A4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv45 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\tv53 = new Reflex.Resolvers.ScopedFactoryResolver();\n\tReflex.Resolvers.ScopedFactoryResolver::.ctor(v53, factory);\n\tgoto L_002F;\nL_002F:\n\tv71 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\treturnVal1 = Reflex.Core.ContainerBuilder::Add(this, v71, contracts, v53);\n\treturn returnVal1;\n")]
		public ContainerBuilder AddScoped<T>(Func<Instancer, T> factory, params Type[] contracts) where T : class
		{
			ScopedFactoryResolver resolver = new ScopedFactoryResolver(factory);
			Type typeFromHandle = typeof(T);
			return Add(typeFromHandle, contracts, resolver);
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x4865FA8", Offset = "0x4865FA8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv44 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001E:\n\t// 30 NewArr v53 @ X0_v3 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_002C;\nL_002C:\n\tv69 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv72 = v69 == 0;\n\tif (v72) goto L_003D;\n\tv77 = 0x21C11D0(v69, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = v77 == 0;\n\tif (v81) goto L_0052;\nL_003D:\n\tv53[0] = v69;\n\treturnVal1 = Reflex.Core.ContainerBuilder::AddScoped(this, factory, v53);\n\treturn returnVal1;\nL_0052:\n\tv100 = new System.ArrayTypeMismatchException();\n\tthrow v100;\n")]
		public ContainerBuilder AddScoped<T>(Func<Instancer, T> factory) where T : class
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
			return AddScoped(factory, array);
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x3F37A8C", Offset = "0x3F37A8C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::set_Item(this.<OpenGenericBindings>k__BackingField, v43, v41);\n\treturn this;\n")]
		internal ContainerBuilder AddOpenGenericTransient(Type openContract, Type openImplementation)
		{
			Type key = default(Type);
			Type value = default(Type);
			OpenGenericBindings[key] = value;
			return this;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x3F37B00", Offset = "0x3F37B00", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.type = type;\n\tv76 = new System.Func`2<Reflex.Core.Binding, System.Boolean>();\n\tSystem.Func`2<Reflex.Core.Binding, System.Boolean>::.ctor(v76, v51, Il2CppMethodInfo);\n\treturnVal2 = System.Linq.Enumerable::Any(this.<Bindings>k__BackingField, v76);\n\treturn returnVal2;\nL_0023:\n\tv51 = new Reflex.Core.ContainerBuilder+<>c__DisplayClass31_0();\n\tSystem.Object::.ctor(v51);\n")]
		internal bool HasBinding(Type type)
		{
			Func<Binding, bool> predicate = (Binding binding) => ((IEnumerable<object>)binding.Contracts).Contains((object)type);
			return Bindings.Any((Func<object, bool>)predicate);
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x3F376D4", Offset = "0x3F376D4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_004B;\nL_004B:\n\tSystem.Collections.Generic.List`1<Reflex.Core.Binding>::Add(v58, v56);\n\treturn this;\nL_001C:\n\tv56 = Reflex.Core.Binding::Validated(resolver, v48, v46);\n\tv58 = this.<Bindings>k__BackingField;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal ContainerBuilder Add(Type concrete, Type[] contracts, IResolver resolver)
		{
			Type concrete2 = default(Type);
			Type[] contracts2 = default(Type[]);
			Binding item = Binding.Validated(resolver, concrete2, contracts2);
			List<Binding> list = Bindings;
			list.Add(item);
			return this;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x3F3602C", Offset = "0x3F3602C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.Dictionary`2<System.Type, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::.ctor(v72);\n\tthis.<OpenGenericBindings>k__BackingField = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<Reflex.Core.Binding>();\n\tSystem.Collections.Generic.List`1<Reflex.Core.Binding>::.ctor(v56);\n\tthis.<Bindings>k__BackingField = v56;\n")]
		public ContainerBuilder()
		{
			List<Binding> list = new List<Binding>();
			Bindings = list;
			Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();
			OpenGenericBindings = dictionary;
		}
	}
}
