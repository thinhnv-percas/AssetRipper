using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x2000006")]
	public class InitializableHub
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000007")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000008")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000009")]
			public static Predicate<ListenerMethod> _003C_003E9__8_0;

			[Token(Token = "0x400000A")]
			public static Predicate<IInitializable> _003C_003E9__8_1;

			[Token(Token = "0x6000013")]
			[Address(RVA = "0x81B0BF0", Offset = "0x81B0BF0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new Unco.InitializationSystem.Runtime.InitializableHub+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000014")]
			[Address(RVA = "0x81B0C54", Offset = "0x81B0C54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CClearNulls_003Eb__8_0(ListenerMethod method)
			{
				//IL_0020: Expected O, but got I4
				//IL_0025: Expected I4, but got O
				object owner = method.owner;
				owner = owner.Equals(null);
				return (byte)(int)owner != 0;
			}

			internal bool _003CClearNulls_003Eb__8_1(IInitializable i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("InitializableHub._003C_003Ec::_003CClearNulls_003Eb__8_1");
				return default;
			}
		}

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		public readonly List<IInitializable> Instances;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		internal readonly List<ListenerMethod> Listeners;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x81B03DC", Offset = "0x81B03DC", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv70 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::GetEnumerator(this.Instances);\n\tv95 = v70._list;\n\tv164 = System.Object::GetType(v70.Current);\n\tgoto L_0053;\nL_0053:\n\tv121 = System.Type::op_Inequality(v164, type);\n\tv288 = v121 == 0;\n\tv123 = ~v288;\n\tv71 = 0;\n\tif (v123) goto L_003F;\n\t*([async @ X2 (Unco.InitializationSystem.Runtime.IInitializable&)]) = v70.Current;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v95 @ stack_-68_v5 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>));\n\treturnVal2 = 1;\n\tgoto L_0074;\nL_0063:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v95 @ stack_-68_v5 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>));\nL_0064:\n\t*([async @ X2 (Unco.InitializationSystem.Runtime.IInitializable&)]) = 0;\n\treturnVal2 = 0;\nL_0087:\n\tv139 = Il2CppMethodInfo != 1;\n\tv152 = v110;\n\tif (v139) goto L_0097;\n\tv143 = 0x8BF5BC4(v110, Il2CppMethodInfo, v71, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv159 = 0x8BF5BF4(v143, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v95 @ stack_-68_v5 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>));\n\tv151 = *([v143 @ X0_v12]) == 0;\n\tif (v151) goto L_0064;\n\tv149 = new System.OutOfMemoryException();\n\tv78 = *([v143 @ X0_v12]);\n\tv152 = v149;\n\treturn returnVal1;\nL_0023:\n\tv95 = 0;\n\tv57 = this.Instances == 0;\n\tv78 = 0;\n\tif (v57) goto L_0077;\nL_003F:\n\tv128 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v95 @ stack_-68_v5 (System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>));\n\tv141 = v128 == 0;\n\tif (v141) goto L_0063;\nL_0074:\n\treturn returnVal2;\nL_0097:\n\tv155 = 0x39670E8(&v78 @ stack_-78_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv161 = 0x8BF0368(v152, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0x7C03E68(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0077:\n\tv110 = new System.NullReferenceException();\n\tgoto L_0087;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe bool TryGetInstance(Type type, out IInitializable async)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializableHub::TryGetInstance");
			async = default;
			return default;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x81B05A8", Offset = "0x81B05A8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tUnco.InitializationSystem.Runtime.Extensions::AddIfNotContains(this.Instances, v42);\n\treturn;\n")]
		internal void Add(IInitializable initializable)
		{
			IInitializable obj = default(IInitializable);
			Instances.AddIfNotContains(obj);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x81B0604", Offset = "0x81B0604", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv57 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::Remove(this.Instances, v40);\n\treturn;\n")]
		internal void Remove(IInitializable initializable)
		{
			IInitializable item = default(IInitializable);
			bool flag = Instances.Remove(item);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x81B0668", Offset = "0x81B0668", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::Clear(v39);\n\tv56 = v39.Count < 1;\n\tif (v56) goto L_002D;\nL_002D:\n\tv87 = this.Listeners;\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::Clear(v87);\n\tv105 = v87.Count < 1;\n\tif (v105) goto L_0050;\n\treturn;\nL_0050:\n\treturn;\nL_0015:\n\tv39 = this.Instances;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Clear()
		{
			List<IInitializable> instances = Instances;
			instances.Clear();
			if (instances.Count >= 1)
			{
			}
			List<ListenerMethod> listeners = Listeners;
			listeners.Clear();
			if (listeners.Count < 1)
			{
			}
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x81B0714", Offset = "0x81B0714", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_004B;\nL_004B:\n\tv97 = listener.dependencies;\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::Add(v44, &v97 @ stack_-50_v1 (System.Type[]));\n\treturn;\nL_0016:\n\tUnco.InitializationSystem.Runtime.InitializableHub::ClearNulls(this);\n\tv44 = this.Listeners;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void AddListener(ListenerMethod listener)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializableHub::AddListener");
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x81B0A18", Offset = "0x81B0A18", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv51.o = o;\n\tv79 = new System.Predicate`1<Unco.InitializationSystem.Runtime.ListenerMethod>();\n\tSystem.Predicate`1<Unco.InitializationSystem.Runtime.ListenerMethod>::.ctor(v79, v51, Il2CppMethodInfo);\n\tv101 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::RemoveAll(this.Listeners, v79);\n\treturn;\nL_0023:\n\tv51 = new Unco.InitializationSystem.Runtime.InitializableHub+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v51);\n")]
		internal void KillListeners(object o)
		{
			Predicate<ListenerMethod> match = delegate(ListenerMethod method)
			{
				//IL_003e: Expected O, but got I4
				//IL_0043: Expected I4, but got O
				object owner = method.owner;
				if (method.owner != o)
				{
					owner = owner.Equals(null);
					return (byte)(int)owner != 0;
				}
				return true;
			};
			int num = Listeners.RemoveAll(match);
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x81B0818", Offset = "0x81B0818", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv108 = this.Listeners;\n\tgoto L_0018;\nL_0018:\n\tv100 = v56.<>9__8_0;\n\tv58 = v56.<>9__8_0 == 0;\n\tif (v58) goto L_0046;\n\tv76 = v108 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0063;\n\tgoto L_00A2;\nL_0046:\n\tgoto L_004E;\n\tv100 = v122;\n\tv108 = v108;\nL_0063:\n\tv114 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::RemoveAll(v108, v100);\n\tgoto L_006B;\nL_006B:\n\tv164 = v162.<>9__8_1 == 0;\n\tif (v164) goto L_0089;\n\tv221 = v162.<>9__8_1;\nL_007D:\n\tv188 = System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::RemoveAll(this.Instances, v221);\n\treturn;\nL_0089:\n\tgoto L_0091;\n\tv240 = this.Instances == 0;\n\tv141 = ~v240;\n\tv221 = v231;\n\tif (v141) goto L_007D;\nL_00A2:\n\tthrow System.NullReferenceException;\nL_004E:\n\tv122 = new System.Predicate`1<Unco.InitializationSystem.Runtime.ListenerMethod>();\n\tSystem.Predicate`1<Unco.InitializationSystem.Runtime.ListenerMethod>::.ctor(v122, v117.<>9, Il2CppMethodInfo);\n\tv166.<>9__8_0 = v122;\nL_0091:\n\tv231 = new System.Predicate`1<Unco.InitializationSystem.Runtime.IInitializable>();\n\tSystem.Predicate`1<Unco.InitializationSystem.Runtime.IInitializable>::.ctor(v231, v226.<>9, Il2CppMethodInfo);\n\tv238.<>9__8_1 = v231;\n")]
		private void ClearNulls()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InitializableHub::ClearNulls");
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x81B0B10", Offset = "0x81B0B10", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>();\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.ListenerMethod>::.ctor(v72);\n\tthis.Listeners = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>();\n\tSystem.Collections.Generic.List`1<Unco.InitializationSystem.Runtime.IInitializable>::.ctor(v56);\n\tthis.Instances = v56;\n")]
		public InitializableHub()
		{
			List<IInitializable> instances = new List<IInitializable>();
			Instances = instances;
			List<ListenerMethod> listeners = new List<ListenerMethod>();
			Listeners = listeners;
		}
	}
}
