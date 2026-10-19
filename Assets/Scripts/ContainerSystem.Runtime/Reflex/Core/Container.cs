using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Exceptions;
using Reflex.Extensions;
using Reflex.Generics;
using Reflex.Logging;
using Reflex.Resolvers;
using Unco.ContainerSystem.Runtime;
using UnityEngine;

namespace Reflex.Core
{
	[Token(Token = "0x2000035")]
	public sealed class Container : IDisposable
	{
		[Token(Token = "0x17000015")]
		[field: Token(Token = "0x4000047")]
		[field: FieldOffset(Offset = "0x10")]
		public string Name
		{
			[Token(Token = "0x6000091")]
			[Address(RVA = "0x3F359E8", Offset = "0x3F359E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Name;\n")]
			get;
		}

		[Token(Token = "0x17000016")]
		[field: Token(Token = "0x4000048")]
		[field: FieldOffset(Offset = "0x18")]
		public Container Parent
		{
			[Token(Token = "0x6000092")]
			[Address(RVA = "0x3F359F0", Offset = "0x3F359F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Parent;\n")]
			get;
		}

		[Token(Token = "0x17000017")]
		[field: Token(Token = "0x4000049")]
		[field: FieldOffset(Offset = "0x20")]
		internal List<Container> Children
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0x3F359F8", Offset = "0x3F359F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Children>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x17000018")]
		[field: Token(Token = "0x400004A")]
		[field: FieldOffset(Offset = "0x28")]
		internal Dictionary<Type, List<IResolver>> ResolversByContract
		{
			[Token(Token = "0x6000094")]
			[Address(RVA = "0x3F35A00", Offset = "0x3F35A00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ResolversByContract>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x17000019")]
		[field: Token(Token = "0x400004B")]
		[field: FieldOffset(Offset = "0x30")]
		internal Dictionary<Type, Type> OpenGenericImplementations
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0x3F35A08", Offset = "0x3F35A08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<OpenGenericImplementations>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x1700001A")]
		[field: Token(Token = "0x400004C")]
		[field: FieldOffset(Offset = "0x38")]
		internal DisposableCollection Disposables
		{
			[Token(Token = "0x6000096")]
			[Address(RVA = "0x3F35A10", Offset = "0x3F35A10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Disposables>k__BackingField;\n")]
			get;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x3F35A18", Offset = "0x3F35A18", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tSystem.Object::.ctor(this);\n\tthis.Name = name;\n\tthis.Parent = parent;\n\tv94 = this.Parent;\n\tv95 = this.Parent == 0;\n\tif (v95) goto L_006C;\n\tv96 = v94.<Children>k__BackingField;\n\tgoto L_0099;\nL_006C:\n\tthis.<ResolversByContract>k__BackingField = resolversByContract;\n\tv155 = openGenericImplementations == 0;\n\tv156 = ~v155;\n\tv203 = openGenericImplementations;\n\tif (v156) goto L_007D;\nL_0075:\n\tv183 = new System.Collections.Generic.Dictionary`2<System.Type, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Type>::.ctor(v183);\n\tv203 = v183;\nL_007D:\n\tthis.<OpenGenericImplementations>k__BackingField = v203;\n\tthis.<Disposables>k__BackingField = disposables;\n\tReflex.Core.Container::OverrideSelfInjection(this);\n\treturn;\nL_0099:\n\tSystem.Collections.Generic.List`1<Reflex.Core.Container>::Add(v96, this);\n\tthis.<ResolversByContract>k__BackingField = resolversByContract;\n\tv262 = openGenericImplementations == 0;\n\tv177 = ~v262;\n\tv203 = openGenericImplementations;\n\tif (v177) goto L_007D;\n\tgoto L_0075;\nL_0030:\n\tv65 = new System.Collections.Generic.List`1<Reflex.Core.Container>();\n\tSystem.Collections.Generic.List`1<Reflex.Core.Container>::.ctor(v65);\n\tthis.<Children>k__BackingField = v65;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Container(string name, Container parent, Dictionary<Type, List<IResolver>> resolversByContract, DisposableCollection disposables, Dictionary<Type, Type> openGenericImplementations = null)
		{
			List<Container> list = new List<Container>();
			Children = list;
			Name = name;
			Parent = parent;
			Container parent2 = Parent;
			Dictionary<Type, Type> dictionary;
			if (Parent != null)
			{
				List<Container> list2 = parent2.Children;
				list2.Add(this);
				ResolversByContract = resolversByContract;
				bool flag = openGenericImplementations == null;
				bool flag2 = !flag;
				dictionary = openGenericImplementations;
				if (!flag2)
				{
					goto IL_00a1;
				}
			}
			else
			{
				ResolversByContract = resolversByContract;
				bool flag3 = openGenericImplementations == null;
				bool flag4 = !flag3;
				dictionary = openGenericImplementations;
				if (!flag4)
				{
					goto IL_00a1;
				}
			}
			goto IL_00b8;
			IL_00b8:
			OpenGenericImplementations = dictionary;
			Disposables = disposables;
			OverrideSelfInjection();
			return;
			IL_00a1:
			Dictionary<Type, Type> dictionary2 = new Dictionary<Type, Type>();
			dictionary = dictionary2;
			goto IL_00b8;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x48658A8", Offset = "0x48658A8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\nL_0013:\n\tv52 = System.Type::GetTypeFromHandle(v41);\n\treturnVal1 = Reflex.Core.Container::HasBinding(this, v52);\n\treturn returnVal1;\n\tv23 = 0x220C2B8(methodInfo, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv41 = Il2CppClass<T>;\n\tgoto L_0013;\n")]
		internal bool HasBinding<T>()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Container::HasBinding");
			return default;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x3F35D88", Offset = "0x3F35D88", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::ContainsKey(this.<ResolversByContract>k__BackingField, v40);\n\treturn returnVal1;\n")]
		internal bool HasBinding(Type type)
		{
			Type key = default(Type);
			return ResolversByContract.ContainsKey(key);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x3F35DEC", Offset = "0x3F35DEC", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv55 = System.Collections.Generic.List`1<Reflex.Core.Container>::Remove(v43.<Children>k__BackingField, this);\nL_0031:\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::Clear(this.<ResolversByContract>k__BackingField);\n\tReflex.Generics.DisposableCollection::Dispose(this.<Disposables>k__BackingField);\n\tv163 = System.String::Concat(\"Container \", this.Name, \" disposed\");\n\tgoto L_004A;\nL_004A:\n\tgoto L_004E;\nL_004E:\n\tgoto L_005C;\nL_005C:\n\tv212 = v199._logLevel <= 0;\n\tif (v212) goto L_0091;\n\treturn;\nL_0091:\n\tgoto L_009D;\nL_009D:\n\tUnityEngine.Debug::Log(v163, 0);\n\treturn;\nL_0020:\n\tv43 = this.Parent;\n\tv44 = this.Parent == 0;\n\tif (v44) goto L_0031;\n")]
		public void Dispose()
		{
			Container parent = Parent;
			if (Parent != null)
			{
				bool flag = parent.Children.Remove(this);
			}
			ResolversByContract.Clear();
			Disposables.Dispose();
			string message = "Container " + Name + " disposed";
			if (ReflexLogger._logLevel <= LogLevel.Info)
			{
				Debug.Log(message, null);
			}
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x3F35F98", Offset = "0x3F35F98", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.<Parent>k__BackingField = this;\n\tv54 = extend == 0;\n\tif (v54) goto L_0031;\n\tSystem.Action`1<Reflex.Core.ContainerBuilder>::Invoke(extend, v46);\nL_0018:\n\tv46 = new Reflex.Core.ContainerBuilder();\n\tReflex.Core.ContainerBuilder::.ctor(v46);\nL_0031:\n\treturnVal2 = Reflex.Core.ContainerBuilder::Build(v46);\n\treturn returnVal2;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Container Scope(Action<ContainerBuilder> extend = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Container::Scope");
			return default;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x3F32B08", Offset = "0x3F32B08", Length = "0x1E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv57 = Reflex.Core.Container::All(this, v46);\n\tgoto L_0032;\nL_0040:\n\tgoto L_004F;\nL_004F:\n\tv96 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(this.<ResolversByContract>k__BackingField, type, &v94 @ stack_-38_v3 (System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>));\n\tv104 = ~v96;\n\tif (v104) goto L_0056;\n\tv192 = v94;\n\tgoto L_005A;\nL_0056:\n\tv192 = Reflex.Core.Container::TryCreateOpenGenericResolver(this, type);\nL_005A:\n\tv111 = System.Linq.Enumerable::LastOrDefault(v192);\n\tv113 = v111 == 0;\n\tif (v113) goto L_0097;\n\tgoto L_008C;\nL_0097:\n\tv117 = 0xB296000 + 0x98;\n\tv190 = new v117();\n\tReflex.Exceptions.UnknownContractException::.ctor(v190, type);\n\tthrow v190;\nL_001E:\n\tv48 = Reflex.Extensions.TypeExtensions::IsEnumerable(type, &v46 @ stack_-40_v2 (System.Type));\n\tv52 = ~v48;\n\tif (v52) goto L_0040;\nL_0032:\n\treturnVal1 = Reflex.Extensions.EnumerableExtensions::CastDynamic(v57, v46);\n\treturn returnVal1;\nL_008C:\n\treturnVal3 = Reflex.Resolvers.IResolver::Resolve(0, this);\n\treturn returnVal3;\n")]
		public object Resolve(Type type)
		{
			if (type.IsEnumerable(out var elementType))
			{
				IEnumerable<object> source = All(elementType);
				return source.CastDynamic(elementType);
			}
			IEnumerable<IResolver> source2 = ((!ResolversByContract.TryGetValue(type, out var value)) ? TryCreateOpenGenericResolver(type) : value);
			IResolver resolver = source2.LastOrDefault();
			if (resolver == null)
			{
				int num = 187260928 + 152;
				UnknownContractException ex = new UnknownContractException(type);
				throw ex;
			}
			return ((IResolver)null).Resolve(this);
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x3F32D78", Offset = "0x3F32D78", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv63 = Reflex.Core.Container::All(this, v53);\n\tgoto L_0036;\nL_003D:\n\tgoto L_004C;\nL_004C:\n\tv97 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(this.<ResolversByContract>k__BackingField, type, &v95 @ stack_-38_v3 (System.Collections.Generic.IEnumerable`1<Reflex.Resolvers.IResolver>));\n\tv99 = ~v97;\n\tif (v99) goto L_0061;\n\tv162 = System.Linq.Enumerable::LastOrDefault(v95);\n\tv210 = v162 == 0;\n\tv211 = ~v210;\n\treturnVal3 = v162;\n\tif (v211) goto L_006E;\nL_005E:\n\treturn returnVal3;\nL_0061:\n\tv165 = Reflex.Core.Container::TryCreateOpenGenericResolver(this, type);\n\tv215 = System.Linq.Enumerable::LastOrDefault(v165);\n\tv216 = v215 == 0;\n\treturnVal3 = v215;\n\tif (v216) goto L_005E;\nL_006E:\n\tgoto L_0097;\nL_001D:\n\t*([result @ X2 (System.Object&)]) = 0;\n\tv55 = Reflex.Extensions.TypeExtensions::IsEnumerable(type, &v53 @ stack_-40_v2 (System.Type));\n\tv58 = ~v55;\n\tif (v58) goto L_003D;\nL_0036:\n\tv145 = Reflex.Extensions.EnumerableExtensions::CastDynamic(v63, v53);\n\tgoto L_0099;\nL_0099:\n\t*([result @ X2 (System.Object&)]) = v145;\n\treturn 1;\nL_0097:\n\tv145 = Reflex.Resolvers.IResolver::Resolve(0, this);\n")]
		public unsafe bool TryResolve(Type type, out object result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Container::TryResolve");
			result = default;
			return default;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x486592C", Offset = "0x486592C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv45 = Il2CppClass<TContract>;\n\tgoto L_0016;\nL_0016:\n\tv56 = System.Type::GetTypeFromHandle(v45);\n\tv65 = Reflex.Core.Container::Resolve(this, v56);\n\tgoto L_0027;\n\treturnVal2 = 0x21C11D0(v65, Il2CppClass<TContract>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = returnVal2 == 0;\n\tif (v90) goto L_004E;\n\treturn returnVal2;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_FFFFFFFF:\n\tv45 = Il2CppClass<TContract>;\n\tgoto L_0016;\nL_004B:\n\treturn 0;\nL_004E:\n\treturnVal3 = new System.InvalidCastException();\n\treturn returnVal3;\nL_0027:\n\tv79 = v65 == 0;\n\tif (v79) goto L_004B;\n")]
		public TContract Resolve<TContract>()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Container::Resolve");
			return default;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x4865C2C", Offset = "0x4865C2C", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = 0x220C2B8(methodInfo, result, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0020:\n\tv57 = System.Type::GetTypeFromHandle(Il2CppClass<TContract>);\n\tv63 = Reflex.Core.Container::TryResolve(this, v57, &v60 @ stack_-48_v2 (System.Object));\n\tgoto L_0033;\n\tv81 = 0x21C11D0(v60, Il2CppClass<TContract>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = v81 == 0;\n\tif (v99) goto L_006C;\n\t*([result @ X1 (TContract&)]) = v81;\nL_FFFFFFFF:\n\tv91 = Il2CppClass<TContract>;\n\tgoto L_0046;\n\tv124 = 0x21C11D0(v60, v91, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv150 = v124 == 0;\n\tv87 = ~v150;\n\tif (v87) goto L_0069;\n\tthrow System.InvalidCastException;\nL_0053:\n\t*([result @ X1 (TContract&)]) = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv91 = Il2CppClass<TContract>;\n\tgoto L_0046;\nL_006C:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\nL_001C:\n\tgoto L_0020;\nL_0033:\n\tv78 = v60 == 0;\n\tif (v78) goto L_0053;\nL_0046:\n\tv121 = v60 == 0;\n\tif (v121) goto L_0069;\nL_0069:\n\treturn v63;\n")]
		public bool TryResolve<TContract>(out TContract result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Container::TryResolve");
			result = default;
			return default;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x3F36D8C", Offset = "0x3F36D8C", Length = "0x268")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([B78EB78]) & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0027;\n\tv24 = *([B78EB79]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0032;\nL_0015:\n\tv65 = this.<ResolversByContract>k__BackingField;\n\tv53 = this.<ResolversByContract>k__BackingField == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_003E;\n\tgoto L_0097;\nL_0027:\n\t*([B78EB78]) = 1;\n\tv160 = *([B78EB79]) & 1;\n\tv161 = v160 == 0;\n\tv46 = ~v161;\n\tif (v46) goto L_0015;\nL_0032:\n\t*([B78EB79]) = 1;\n\tv65 = this.<ResolversByContract>k__BackingField;\nL_003E:\n\tv82 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(v65, type, &v80 @ stack_-38_v5 (System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>));\n\tv130 = ~v82;\n\tif (v130) goto L_0045;\n\tv164 = v80;\n\tgoto L_0047;\nL_0045:\n\tv158 = Reflex.Core.Container::TryCreateOpenGenericResolver(this, type);\n\tv164 = v158;\nL_0047:\n\tv186 = System.Linq.Enumerable::ToList(v164);\n\tv148 = v186.Count == 0;\n\tif (v148) goto L_0099;\n\tv88 = v186.Count >= 2;\n\tif (v88) goto L_00A7;\n\tv121 = System.Collections.Generic.List`1<System.Object>::get_Item(v186, 0);\n\tgoto L_008E;\nL_0097:\n\tthrow System.NullReferenceException;\nL_0099:\n\tv153 = 0xB296000 + 0x98;\n\tv162 = new v153();\n\tReflex.Exceptions.UnknownContractException::.ctor(v162, type);\n\tthrow v162;\nL_00A7:\n\tv194 = Reflex.Extensions.TypeExtensions::GetFullName(type);\n\tv198 = 0x3175AC4(v186, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = v186.Count;\n\tv211 = 0xB7D5000 + 0x538;\n\tv214 = \"il2cpp_vm_object_box\"(*([v211 @ X8_v5 (System.Int32)+48]), &v209 @ stack_-3C_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv248 = 0xB2F2000 + 0x5A0;\n\tv276 = System.String::Format(v248, v194, v214);\n\tv313 = 0xB290000 + 0xB18;\n\tv348 = new v313();\n\tSystem.InvalidOperationException::.ctor(v348, v276);\n\tthrow v348;\nL_008E:\n\treturnVal1 = Reflex.Resolvers.IResolver::Resolve(0, this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public object Single(Type type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Container::Single");
			return default;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x4865B20", Offset = "0x4865B20", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tgoto L_001A;\n\tv32 = 0x220C2B8(methodInfo, il2cppRetVal, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_002B:\n\tv68 = System.Type::GetTypeFromHandle(Il2CppClass<TContract>);\n\tv85 = Reflex.Core.Container::Single(this, v68);\n\tgoto L_003E;\n\treturn returnVal1;\nL_005D:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_001A:\n\tv50 = Il2CppClass<TContract>;\n\tv54 = *([v50 @ X9_v1 (Il2CppClass<TContract>)+FC]) + 0xF;\n\tv55 = v54 & 0x1FFFFFFF0;\n\t// 31 StackAlloc v56 @ X22_v1 (System.Byte*), v55 @ X10_v2 (System.Int32)\n\tgoto L_002B;\nL_003E:\n\tv89 = 0x21C11E0(v85, Il2CppClass<TContract>, v56, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x8BF6A1C(il2cppRetVal, v89, *([v50 @ X9_v1 (Il2CppClass<TContract>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = *([A4731E0]);\n\tv107 = *([v96 @ X9_v4]) != *([v25 @ X8_v2]);\n\tif (v107) goto L_005D;\n")]
		public unsafe TContract Single<TContract>()
		{
			//IL_0010: Expected O, but got I
			//IL_0084: Expected O, but got I
			//IL_0097: Expected I4, but got I8
			//IL_00d5: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X9_v1 (Il2CppClass<TContract>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			Type typeFromHandle = typeof(TContract);
			object obj3 = Single(typeFromHandle);
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11E0");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj4 = 0;
			TContract result = default(TContract);
			if (obj4 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			TContract result2 = default(TContract);
			return result2;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x3F36A98", Offset = "0x3F36A98", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_002D:\n\tv58 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(this.<ResolversByContract>k__BackingField, v40, &v57 @ stack_-38_v2 (System.Collections.Generic.IEnumerable`1<System.Object>));\n\tv64 = v58 == 0;\n\tif (v64) goto L_0054;\n\tv72 = new System.Func`2<Reflex.Resolvers.IResolver, System.Object>();\n\tSystem.Func`2<Reflex.Resolvers.IResolver, System.Object>::.ctor(v72, this, Il2CppMethodInfo);\n\tv132 = System.Linq.Enumerable::Select(v57, v72);\n\treturnVal2 = System.Linq.Enumerable::ToArray(v132);\n\treturn returnVal2;\nL_0054:\n\tgoto L_0055;\nL_0055:\n\tv119 = Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>;\n\tv122 = *([v119 @ X0_v20 (Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>)+135]) & 1;\n\tv123 = v122 == 0;\n\tv141 = Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>;\n\tif (v123) goto L_007B;\nL_005D:\n\tgoto L_0065;\nL_0065:\n\tgoto L_0070;\nL_0070:\n\treturn v101.Instance;\n\tv125 = System.Linq.Enumerable::Empty();\n\tv134 = Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>;\n\tv147 = *([v134 @ X0_v12 (Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>)+135]) & 1;\n\tv148 = v147 == 0;\n\tv136 = ~v148;\n\tv141 = Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>;\n\tif (v136) goto L_005D;\nL_007B:\n\tv144 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv166 = *([v144 @ X0_v9+E4]) == 0;\n\tv152 = ~v166;\n\tif (v152) goto L_0065;\n\tgoto L_0088;\nL_0088:\n\tgoto L_0070;\n")]
		public unsafe IEnumerable<object> All(Type contract)
		{
			Type key = default(Type);
			IEnumerable<object> value;
			if (ResolversByContract.TryGetValue(key, out *(List<IResolver>*)(&value)))
			{
				Func<IResolver, object> selector = (IResolver resolver) => resolver.Resolve(this);
				IEnumerable<object> source = value.Select((Func<object, object>)selector);
				return source.ToArray();
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X0_v20 (Il2CppClass<System.Linq.EmptyEnumerable`1<System.Object>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X0_v9+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return global::System.Linq.Enumerable.Empty<object>();
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x4865770", Offset = "0x4865770", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tgoto L_0021;\n\tv39 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<TContract>);\n\tv69 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(this.<ResolversByContract>k__BackingField, v59, &v67 @ stack_-38_v2 (System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>));\n\tv72 = v69 == 0;\n\tif (v72) goto L_0059;\n\tgoto L_003C;\nL_003C:\n\tv120 = new Il2CppClass<System.Func`2<Reflex.Resolvers.IResolver, TContract>>();\n\tv125 = System.Func`2<Reflex.Resolvers.IResolver, TContract>::.ctor(v120, this, Il2CppMethodInfo);\n\tv130 = System.Linq.Enumerable::Select(v67, v120);\n\treturnVal3 = System.Linq.Enumerable::ToArray(v130);\n\treturn returnVal3;\nL_0059:\n\treturnVal2 = System.Linq.Enumerable::Empty();\n\treturn returnVal2;\nL_0021:\n\tgoto L_0025;\n")]
		public unsafe IEnumerable<TContract> All<TContract>()
		{
			Type typeFromHandle = typeof(TContract);
			if (ResolversByContract.TryGetValue(typeFromHandle, out var value))
			{
				Func<IResolver, TContract> selector = delegate(IResolver resolver)
				{
					//IL_0010: Expected O, but got I
					//IL_0068: Expected O, but got I
					//IL_007b: Expected I4, but got I8
					//IL_00cc: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj = 0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v55 @ X8_v6 (Il2CppClass<TContract>)+FC]");
					object obj2 = (nint)0 + (nint)15;
					int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
					byte* ptr = stackalloc byte[(int)(uint)num2];
					object obj3 = resolver.Resolve(this);
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11E0");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj4 = 0;
					TContract result = default(TContract);
					if (obj4 == obj)
					{
						return result;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
					TContract result2 = default(TContract);
					return result2;
				};
				IEnumerable<TContract> source = value.Select(selector);
				return source.ToArray();
			}
			return Enumerable.Empty<TContract>();
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x3F36C4C", Offset = "0x3F36C4C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv52 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(this.<ResolversByContract>k__BackingField, contract, &v50 @ stack_-38_v2 (System.Collections.Generic.IEnumerable`1<Reflex.Resolvers.IResolver>));\n\tv54 = ~v52;\n\tif (v54) goto L_002C;\n\treturn v50;\nL_002C:\n\treturnVal3 = Reflex.Core.Container::TryCreateOpenGenericResolver(this, contract);\n\treturn returnVal3;\n")]
		private unsafe IEnumerable<IResolver> GetResolvers(Type contract)
		{
			IEnumerable<IResolver> value;
			if (ResolversByContract.TryGetValue(contract, out *(List<IResolver>*)(&value)))
			{
				return value;
			}
			return TryCreateOpenGenericResolver(contract);
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x3F36CEC", Offset = "0x3F36CEC", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_001E:\n\tv52 = System.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::TryGetValue(this.<ResolversByContract>k__BackingField, contract, &v50 @ stack_-38_v2 (System.Collections.Generic.IEnumerable`1<Reflex.Resolvers.IResolver>));\n\tv54 = ~v52;\n\tif (v54) goto L_002C;\n\treturn v50;\nL_002C:\n\treturnVal3 = Reflex.Core.Container::TryCreateOpenGenericResolver(this, contract);\n\treturn returnVal3;\n")]
		private unsafe IEnumerable<IResolver> TryGetResolvers(Type contract)
		{
			IEnumerable<IResolver> value;
			if (ResolversByContract.TryGetValue(contract, out *(List<IResolver>*)(&value)))
			{
				return value;
			}
			return TryCreateOpenGenericResolver(contract);
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x3F36FF4", Offset = "0x3F36FF4", Length = "0x350")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv71 = System.Type::get_IsGenericType(contract);\n\tv72 = ~v71;\n\tif (v72) goto L_00B6;\n\tv161 = System.Type::get_IsGenericTypeDefinition(contract);\n\tv162 = ~v161;\n\tv163 = ~v162;\n\tif (v163) goto L_00B6;\n\tv183 = System.Type::GetGenericTypeDefinition(contract);\n\tv170 = System.Collections.Generic.Dictionary`2<System.Type, System.Type>::TryGetValue(this.<OpenGenericImplementations>k__BackingField, v183, &v109 @ stack_-48_v4 (System.Type));\n\tv172 = v170 == 0;\n\tif (v172) goto L_00B6;\n\tv288 = System.Type::GetGenericArguments(contract);\n\tv132 = System.Type::MakeGenericType(v109, v288);\n\tv52.closedImplType = v132;\n\tv310 = new System.Func`2<Unco.ContainerSystem.Runtime.Instancer, System.Object>();\n\tSystem.Func`2<Unco.ContainerSystem.Runtime.Instancer, System.Object>::.ctor(v310, v52, Il2CppMethodInfo);\n\tv318 = new Reflex.Resolvers.TransientFactoryResolver();\n\tSystem.Object::.ctor(v318);\n\tv318._factory = v310;\n\tv133 = new System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>();\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::.ctor(v133);\n\tgoto L_00F3;\nL_00B6:\n\tgoto L_00B7;\nL_00B7:\n\tv184 = Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>;\n\tv187 = *([v184 @ X0_v24 (Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>)+135]) & 1;\n\tv188 = v187 == 0;\n\tv254 = Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>;\n\tif (v188) goto L_00DF;\nL_00BF:\n\tgoto L_00C7;\nL_00C7:\n\tgoto L_00D4;\nL_00D4:\n\treturn v228.Value;\n\tv190 = System.Array::Empty();\n\tv247 = Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>;\n\tv260 = *([v247 @ X0_v16 (Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>)+135]) & 1;\n\tv261 = v260 == 0;\n\tv249 = ~v261;\n\tv254 = Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>;\n\tif (v249) goto L_00BF;\nL_00DF:\n\tv257 = 0x220C238(v254, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv282 = *([v257 @ X0_v13+E4]) == 0;\n\tv268 = ~v282;\n\tif (v268) goto L_00C7;\n\tgoto L_00EC;\nL_00EC:\n\tgoto L_00D4;\nL_00F3:\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::Add(v133, v318);\n\tv77 = v133;\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::set_Item(this.<ResolversByContract>k__BackingField, contract, v77);\n\treturn v77;\nL_0036:\n\tv52 = new Reflex.Core.Container+<>c__DisplayClass33_0();\n\tSystem.Object::.ctor(v52);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerable<IResolver> TryCreateOpenGenericResolver(Type contract)
		{
			if (contract.IsGenericType && !contract.IsGenericTypeDefinition)
			{
				Type genericTypeDefinition = contract.GetGenericTypeDefinition();
				if (OpenGenericImplementations.TryGetValue(genericTypeDefinition, out var value))
				{
					Type[] genericArguments = contract.GetGenericArguments();
					Type type = value.MakeGenericType(genericArguments);
					Type closedImplType = type;
					Func<Instancer, object> factory = delegate(Instancer instancer)
					{
						object obj = Activator.CreateInstance(closedImplType);
						object obj2 = instancer.InjectInstance(obj);
						return obj;
					};
					TransientFactoryResolver item = new TransientFactoryResolver(factory);
					List<IResolver> list = new List<IResolver>();
					list.Add(item);
					List<IResolver> list2 = list;
					ResolversByContract[contract] = list2;
					return list2;
				}
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v24 (Il2CppClass<System.EmptyArray`1<Reflex.Resolvers.IResolver>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X0_v13+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			return Array.Empty<IResolver>();
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x3F35C00", Offset = "0x3F35C00", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0039:\n\tv70 = System.Type::GetTypeFromHandle(Reflex.Core.Container);\n\tv76 = new System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>();\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::.ctor(v76);\n\tv86 = new Reflex.Resolvers.SingletonValueResolver();\n\tReflex.Resolvers.SingletonValueResolver::.ctor(v86, this);\n\tgoto L_006A;\nL_006A:\n\tSystem.Collections.Generic.List`1<Reflex.Resolvers.IResolver>::Add(v76, v86);\n\tSystem.Collections.Generic.Dictionary`2<System.Type, System.Collections.Generic.List`1<Reflex.Resolvers.IResolver>>::set_Item(this.<ResolversByContract>k__BackingField, v70, v76);\n\treturn;\nL_0035:\n\tgoto L_0039;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OverrideSelfInjection()
		{
			Type typeFromHandle = typeof(Container);
			List<IResolver> list = new List<IResolver>();
			SingletonValueResolver item = new SingletonValueResolver(this);
			list.Add(item);
			ResolversByContract[typeFromHandle] = list;
		}
	}
}
