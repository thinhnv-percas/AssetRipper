using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.LowLevel;
using UnityEngine.Experimental.PlayerLoop;

namespace Morpeh
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D108", Offset = "0x73D108")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D108", Offset = "0x73D108")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D108", Offset = "0x73D108")]
	[Token(Token = "0x200000E")]
	public sealed class World : IDisposable
	{
		[Token(Token = "0x200003A")]
		private class FixedUpdateWorkaround : MonoBehaviour
		{
			[Token(Token = "0x60000F1")]
			[Address(RVA = "0x15FA4FC", Offset = "0x15FA4FC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC8B90]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A084]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tMorpeh.World::PlayerLoopFixedUpdate();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void FixedUpdate()
			{
				PlayerLoopFixedUpdate();
			}

			[Token(Token = "0x60000F2")]
			[Address(RVA = "0x15FA558", Offset = "0x15FA558", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public FixedUpdateWorkaround()
			{
			}
		}

		[Token(Token = "0x4000014")]
		private static readonly List<World> Worlds;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x10")]
		internal Filter Filter;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x18")]
		private SortedList<int, ISystem> systems;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x20")]
		private SortedList<int, ISystem> fixedSystems;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x28")]
		private SortedList<int, ISystem> lateSystems;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x30")]
		private SortedList<int, ISystem> disabledSystems;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x38")]
		private SortedList<int, ISystem> disabledFixedSystems;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x40")]
		private SortedList<int, ISystem> disabledLateSystems;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x48")]
		private List<IInitializer> newInitializers;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x50")]
		private List<IDisposable> disposables;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x58")]
		public Entity[] Entities;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x60")]
		internal int EntitiesCount;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x64")]
		internal int EntitiesLength;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x68")]
		internal int EntitiesCapacity;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x70")]
		private Queue<int> freeEntityIDs;

		[Token(Token = "0x17000007")]
		[field: Token(Token = "0x4000013")]
		public static World Default
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x15F8BC4", Offset = "0x15F8BC4", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC1C70]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A072]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Morpeh.World;\nL_0024:\n\treturn v49.<Default>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x15F8C2C", Offset = "0x15F8C2C", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBF808]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A073]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Morpeh.World;\nL_0021:\n\tv52.<Default>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x15F8C98", Offset = "0x15F8C98", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EFFAF8]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A074]) = v42;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv48 = new System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>();\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::.ctor(v48);\n\tthis.systems = v48;\n\tv54 = new System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>();\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::.ctor(v54);\n\tthis.fixedSystems = v54;\n\tv58 = new System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>();\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::.ctor(v58);\n\tthis.lateSystems = v58;\n\tv62 = new System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>();\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::.ctor(v62);\n\tthis.disabledSystems = v62;\n\tv66 = new System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>();\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::.ctor(v66);\n\tthis.disabledFixedSystems = v66;\n\tv70 = new System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>();\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::.ctor(v70);\n\tthis.disabledLateSystems = v70;\n\tv76 = new System.Collections.Generic.List`1<Morpeh.IInitializer>();\n\tSystem.Collections.Generic.List`1<Morpeh.IInitializer>::.ctor(v76);\n\tthis.newInitializers = v76;\n\tv84 = new System.Collections.Generic.List`1<System.IDisposable>();\n\tSystem.Collections.Generic.List`1<System.IDisposable>::.ctor(v84);\n\tthis.disposables = v84;\n\tthis.EntitiesLength = 0x1000000000000;\n\t// 90 NewArr v94 @ X0_v20 (Morpeh.Entity[]), typeof(Morpeh.Entity[]), 65536\n\tthis.Entities = v94;\n\tv98 = new System.Collections.Generic.Queue`1<System.Int32>();\n\tSystem.Collections.Generic.Queue`1<System.Int32>::.ctor(v98);\n\tthis.freeEntityIDs = v98;\n\tv106 = new Morpeh.Filter();\n\tMorpeh.Filter::.ctor(v106, this);\n\tthis.Filter = v106;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public World()
		{
			SortedList<int, ISystem> sortedList = new SortedList<int, ISystem>();
			systems = sortedList;
			fixedSystems = new SortedList<int, ISystem>();
			lateSystems = new SortedList<int, ISystem>();
			disabledSystems = new SortedList<int, ISystem>();
			disabledFixedSystems = new SortedList<int, ISystem>();
			disabledLateSystems = new SortedList<int, ISystem>();
			newInitializers = new List<IInitializer>();
			disposables = new List<IDisposable>();
			EntitiesLength = 0;
			EntitiesCapacity = 65536;
			Entities = new Entity[65536];
			freeEntityIDs = new Queue<int>();
			Filter = new Filter(this);
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15F8E44", Offset = "0x15F8E44", Length = "0x35C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EE1180]);\n\tv23 = *([v22 @ X8_v42]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A075]) = v42;\nL_001C:\n\tv50 = 0;\n\tgoto L_0029;\n\tv56 = *([v52 @ X0_v2+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0029;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0029:\n\tMorpeh.World::<Dispose>g__DisposeSystems|20_0(this.systems);\n\tthis.systems = 0;\n\tMorpeh.World::<Dispose>g__DisposeSystems|20_0(this.fixedSystems);\n\tthis.fixedSystems = 0;\n\tMorpeh.World::<Dispose>g__DisposeSystems|20_0(this.lateSystems);\n\tthis.lateSystems = 0;\n\tMorpeh.World::<Dispose>g__DisposeSystems|20_0(this.disabledSystems);\n\tthis.disabledSystems = 0;\n\tMorpeh.World::<Dispose>g__DisposeSystems|20_0(this.disabledFixedSystems);\n\tthis.disabledFixedSystems = 0;\n\tMorpeh.World::<Dispose>g__DisposeSystems|20_0(this.disabledLateSystems);\n\tthis.disabledLateSystems = 0;\n\tv75 = System.Collections.Generic.List`1<Morpeh.IInitializer>::GetEnumerator(this.newInitializers);\nL_004A:\n\tv141 = System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>::MoveNext(&v74 @ stack_-80_v1 (System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>));\n\tv143 = v141 == 0;\n\tif (v143) goto L_0080;\n\tgoto L_007A;\n\tv152 = *([v145 @ X8_v36+B0]);\n\tv153 = 0;\n\tv154 = v152 + 8;\n\tv156 = *([v193 @ X11_v13-8]);\n\tv198 = v156 == v144;\n\tif (v198) goto L_0073;\n\tv176 = v192 + 1;\n\tv207 = v176 < v146;\n\tv174 = ~v207;\n\tv178 = v193 + 0x10;\n\tv158 = ~v174;\n\tif (v158) goto L_FFFFFFFF;\n\tv179 = v138;\n\tv180 = 0;\n\tv181 = 0x8909C4(v179, v144, v180, v27, v28, v29, v30, v31, v78, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_007A;\nL_0073:\n\tv208 = *([v193 @ X11_v13]);\n\tv209 = v208 << 4;\n\tv210 = v145 + v209;\n\tv211 = v210 + 0x130;\nL_007A:\n\tSystem.IDisposable::Dispose(v77);\n\tgoto L_004A;\nL_0080:\n\tv151 = System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>::Dispose(&v74 @ stack_-80_v1 (System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>));\n\tgoto L_009D;\n\tgoto L_0083;\nL_0083:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0146;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB2E30]);\n\tX0 = &stack[30];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0147;\nL_009D:\n\tSystem.Collections.Generic.List`1<Morpeh.IInitializer>::Clear(this.newInitializers);\n\tthis.newInitializers = 0;\n\tv220 = System.Collections.Generic.List`1<System.IDisposable>::GetEnumerator(this.disposables);\nL_00A9:\n\tv265 = System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>::MoveNext(&v50 @ stack_-68_v1 (System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>));\n\tv267 = v265 == 0;\n\tif (v267) goto L_00DF;\n\tgoto L_00D9;\n\tv276 = *([v269 @ X8_v32+B0]);\n\tv277 = 0;\n\tv278 = v276 + 8;\n\tv280 = *([v317 @ X11_v7-8]);\n\tv322 = v280 == v268;\n\tif (v322) goto L_00D2;\n\tv300 = v316 + 1;\n\tv331 = v300 < v270;\n\tv298 = ~v331;\n\tv302 = v317 + 0x10;\n\tv282 = ~v298;\n\tif (v282) goto L_FFFFFFFF;\n\tv303 = v262;\n\tv304 = 0;\n\tv305 = 0x8909C4(v303, v268, v304, v27, v28, v29, v30, v31, v78, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00D9;\nL_00D2:\n\tv332 = *([v317 @ X11_v7]);\n\tv333 = v332 << 4;\n\tv334 = v269 + v333;\n\tv335 = v334 + 0x130;\nL_00D9:\n\tSystem.IDisposable::Dispose(0);\n\tgoto L_00A9;\nL_00DF:\n\tv275 = System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>::Dispose(&v50 @ stack_-68_v1 (System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>));\n\tgoto L_00FC;\n\tgoto L_00E2;\nL_00E2:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0146;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F06770]);\n\tX0 = &stack[18];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0147;\nL_00FC:\n\tSystem.Collections.Generic.List`1<System.IDisposable>::Clear(this.disposables);\n\tv339 = this.Entities;\n\tthis.disposables = 0;\n\tv386 = v339.Length;\n\tv351 = v339.Length < 1;\n\tif (v351) goto L_0133;\nL_011A:\n\tv355 = v339[v406 @ X22_v8 (System.Int32)] != 0;\n\tif (v355) goto L_FFFFFFFF;\n\tgoto L_0120;\nL_0120:\n\tv384 = v339[v406 @ X22_v8 (System.Int32)] == 0;\n\tif (v384) goto L_0125;\n\tMorpeh.Entity::Dispose(v388);\n\tv386 = v339.Length;\nL_0125:\n\tv406 = v406 + 1;\n\tv360 = v406 < v386;\n\tif (v360) goto L_011A;\nL_0133:\n\tthis.Entities = 0;\n\tthis.EntitiesLength = -1;\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Clear(this.freeEntityIDs);\n\tthis.freeEntityIDs = 0;\n\tMorpeh.Filter::Dispose(this.Filter);\n\tthis.Filter = 0;\n\treturn;\nL_0146:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0147:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			List<IDisposable>.Enumerator enumerator = default(List<IDisposable>.Enumerator);
			DisposeSystems(systems);
			systems = null;
			DisposeSystems(fixedSystems);
			fixedSystems = null;
			DisposeSystems(lateSystems);
			lateSystems = null;
			DisposeSystems(disabledSystems);
			disabledSystems = null;
			DisposeSystems(disabledFixedSystems);
			disabledFixedSystems = null;
			DisposeSystems(disabledLateSystems);
			disabledLateSystems = null;
			List<IInitializer>.Enumerator enumerator2 = newInitializers.GetEnumerator();
			List<IInitializer>.Enumerator enumerator3 = default(List<IInitializer>.Enumerator);
			IDisposable disposable = default(IDisposable);
			while (enumerator3.MoveNext())
			{
				disposable.Dispose();
			}
			enumerator3.Dispose();
			newInitializers.Clear();
			newInitializers = null;
			List<IDisposable>.Enumerator enumerator4 = disposables.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((IDisposable)null).Dispose();
			}
			enumerator.Dispose();
			disposables.Clear();
			Entity[] entities = Entities;
			disposables = null;
			int num = entities.Length;
			if (entities.Length >= 1)
			{
				int num2 = 0;
				Entity entity = null;
				do
				{
					if (entities[num2] != null)
					{
						entity = entities[num2];
					}
					if (entities[num2] != null)
					{
						entity.Dispose();
						num = entities.Length;
					}
					num2++;
				}
				while (num2 < num);
			}
			Entities = null;
			EntitiesLength = -1;
			EntitiesCapacity = -1;
			freeEntityIDs.Clear();
			freeEntityIDs = null;
			Filter.Dispose();
			Filter = null;
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x15F91A0", Offset = "0x15F91A0", Length = "0x2DC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1F00D58]);\n\tv27 = *([v26 @ X8_v31]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202A083]) = v46;\nL_001B:\n\tv51 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Values(systemsToDispose);\n\tgoto L_004A;\n\tv59 = *([v54 @ X8_v5+B0]);\n\tv60 = 0;\n\tv61 = v59 + 8;\n\tv63 = *([v110 @ X11_v31-8]);\n\tv116 = v63 == v57;\n\tif (v116) goto L_0043;\n\tv96 = v111 + 1;\n\tv121 = v96 < v56;\n\tv90 = ~v121;\n\tv93 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_FFFFFFFF;\n\tv97 = v52;\n\tv98 = 0;\n\tv99 = 0x8909C4(v97, v57, v98, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_004A;\nL_0043:\n\tv122 = *([v110 @ X11_v31]);\n\tv123 = v122 << 4;\n\tv124 = v54 + v123;\n\tv125 = v124 + 0x130;\nL_004A:\n\tv147 = System.Collections.Generic.IEnumerable`1<Morpeh.ISystem>::GetEnumerator(v51);\nL_0056:\n\tgoto L_007D;\n\tv199 = *([v195 @ X8_v9+B0]);\n\tv200 = 0;\n\tv201 = v199 + 8;\n\tv203 = *([v239 @ X11_v26-8]);\n\tv245 = v203 == v196;\n\tif (v245) goto L_0076;\n\tv225 = v240 + 1;\n\tv250 = v225 < v197;\n\tv221 = ~v250;\n\tv223 = v239 + 0x10;\n\tv205 = ~v221;\n\tif (v205) goto L_FFFFFFFF;\n\tv226 = v154;\n\tv227 = 0;\n\tv228 = 0x8909C4(v226, v196, v227, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_007D;\nL_0076:\n\tv251 = *([v239 @ X11_v26]);\n\tv252 = v251 << 4;\n\tv253 = v195 + v252;\n\tv254 = v253 + 0x130;\nL_007D:\n\tv275 = System.Collections.IEnumerator::MoveNext(v147);\n\tv277 = v275 == 0;\n\tif (v277) goto L_00DD;\n\tgoto L_00AC;\n\tv286 = *([v278 @ X8_v20+B0]);\n\tv287 = 0;\n\tv288 = v286 + 8;\n\tv290 = *([v330 @ X11_v21-8]);\n\tv336 = v290 == v279;\n\tif (v336) goto L_00A5;\n\tv312 = v331 + 1;\n\tv414 = v312 < v280;\n\tv308 = ~v414;\n\tv310 = v330 + 0x10;\n\tv292 = ~v308;\n\tif (v292) goto L_FFFFFFFF;\n\tv313 = v154;\n\tv314 = 0;\n\tv315 = 0x8909C4(v313, v279, v314, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00AC;\nL_00A5:\n\tv415 = *([v330 @ X11_v21]);\n\tv416 = v415 << 4;\n\tv417 = v278 + v416;\n\tv418 = v417 + 0x130;\nL_00AC:\n\tv439 = System.Collections.Generic.IEnumerator`1<Morpeh.ISystem>::get_Current(v147);\n\tgoto L_00D9;\n\tv479 = *([v440 @ X8_v23+B0]);\n\tv480 = 0;\n\tv481 = v479 + 8;\n\tv483 = *([v531 @ X11_v16-8]);\n\tv537 = v483 == v441;\n\tif (v537) goto L_00D2;\n\tv505 = v532 + 1;\n\tv556 = v505 < v442;\n\tv501 = ~v556;\n\tv503 = v531 + 0x10;\n\tv485 = ~v501;\n\tif (v485) goto L_FFFFFFFF;\n\tv506 = v158;\n\tv507 = 0;\n\tv508 = 0x8909C4(v506, v441, v507, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00D9;\nL_00D2:\n\tv557 = *([v531 @ X11_v16]);\n\tv558 = v557 << 4;\n\tv559 = v440 + v558;\n\tv560 = v559 + 0x130;\nL_00D9:\n\tSystem.IDisposable::Dispose(v439);\n\tgoto L_0056;\nL_00DD:\n\tv284 = v147 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_00F8;\n\tgoto L_0126;\n\tgoto L_00E3;\n\tgoto L_00E3;\nL_00E3:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_013D;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = 0xFFFFFFFF;\n\tif (TEMP) goto L_0126;\nL_00F8:\n\tgoto L_011F;\n\tv384 = *([v316 @ X8_v16+B0]);\n\tv385 = 0;\n\tv386 = v384 + 8;\n\tv388 = *([v468 @ X11_v9-8]);\n\tv474 = v388 == v317;\n\tif (v474) goto L_0118;\n\tv410 = v469 + 1;\n\tv513 = v410 < v318;\n\tv406 = ~v513;\n\tv408 = v468 + 0x10;\n\tv390 = ~v406;\n\tif (v390) goto L_FFFFFFFF;\n\tv411 = v154;\n\tv412 = 0;\n\tv413 = 0x8909C4(v411, v317, v412, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_011F;\nL_0118:\n\tv514 = *([v468 @ X11_v9]);\n\tv515 = v514 << 4;\n\tv516 = v316 + v515;\n\tv517 = v516 + 0x130;\nL_011F:\n\tSystem.IDisposable::Dispose(v147);\nL_0126:\n\tgoto L_0137;\n\tgoto L_013C;\nL_0137:\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Clear(systemsToDispose);\n\treturn;\nL_013C:\n\tv512 = new System.TypeLoadException();\nL_013D:\n\tv542 = 0x6D2380(v512, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void DisposeSystems(SortedList<int, ISystem> systemsToDispose)
			{
				IList<ISystem> values = systemsToDispose.Values;
				IEnumerator<ISystem> enumerator5 = values.GetEnumerator();
				while (enumerator5.MoveNext())
				{
					ISystem current = enumerator5.Current;
					current.Dispose();
				}
				enumerator5?.Dispose();
				systemsToDispose.Clear();
			}
		}

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15F947C", Offset = "0x15F947C", Length = "0x3A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EA63D8]);\n\tv33 = *([v32 @ X8_v60]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([202A076]) = v53;\nL_0020:\n\tv60 = new Morpeh.World();\n\tMorpeh.World::.ctor(v60);\n\tgoto L_0031;\n\tv66 = *([v62 @ X0_v4+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0031;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0031:\n\tgoto L_003C;\n\tv78 = *([1F03C60]);\n\tv79 = *([v78 @ X8_v56]);\n\tv80 = \"il2cpp_codegen_initialize_method\"(v79, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv83 = 0 | 1;\n\t*([202A085]) = v83;\nL_003C:\n\tgoto L_0044;\n\tv88 = *([v84 @ X0_v7 (Il2CppClass<Morpeh.World>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tgoto L_0044;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v84, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv92 = Morpeh.World;\nL_0044:\n\tv95.<Default>k__BackingField = v60;\n\tgoto L_0054;\n\tv102 = *([1EDD170]);\n\tv103 = *([v102 @ X8_v52]);\n\tv104 = \"il2cpp_codegen_initialize_method\"(v103, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv107 = 0 | 1;\n\t*([2021C3B]) = v107;\nL_0054:\n\tgoto L_005D;\n\tv112 = *([v108 @ X0_v10 (Il2CppClass<Morpeh.World>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tgoto L_005D;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v108, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv116 = Morpeh.World;\nL_005D:\n\tMorpeh.World::RegisterInDefaultPlayerLoop(v119.<Default>k__BackingField);\n\tv125 = UnityEngine.Experimental.LowLevel.PlayerLoop::GetDefaultPlayerLoop();\n\tv126 = v125.type;\n\tv128 = v125.subSystemList;\n\tv155 = v128.Length < 1;\n\tif (v155) goto L_013F;\n\tv230 = v128 + 0x30;\nL_0094:\n\tgoto L_009C;\n\tv264 = *([v246 @ X0_v18+E0]);\n\tv265 = v264 == 0;\n\tv266 = ~v265;\n\tgoto L_009C;\n\tv268 = \"il2cpp_codegen_runtime_class_init\"(v246, v229, v228, v226, v38, v39, v40, v41, v137, v43, v44, v45, v46, v47, v48, v49);\nL_009C:\n\tv273 = System.Type::GetTypeFromHandle(UnityEngine.Experimental.PlayerLoop.PreLateUpdate);\n\tv332 = System.Type::op_Equality(*([v230 @ X25_v4-10]), v273);\n\tv334 = v332 == 0;\n\tif (v334) goto L_00D2;\n\tv327 = *([v230 @ X25_v4]);\n\tv361 = new UnityEngine.Experimental.LowLevel.PlayerLoopSystem+UpdateFunction();\nL_00AB:\n\tUnityEngine.Experimental.LowLevel.PlayerLoopSystem+UpdateFunction::.ctor(v361, 0, v356);\n\tv375 = System.Delegate::Combine(v327, v361);\n\tv323 = v375 == 0;\n\tif (v323) goto L_0126;\n\tv299 = *([v375 @ X0_v26 (System.Delegate)]) != UnityEngine.Experimental.LowLevel.PlayerLoopSystem+UpdateFunction;\n\tif (v299) goto L_014E;\n\t*([v230 @ X25_v4]) = v375;\n\tv416 = *([v375 @ X0_v26 (System.Delegate)]) == UnityEngine.Experimental.LowLevel.PlayerLoopSystem+UpdateFunction;\n\tif (v416) goto L_0127;\n\tgoto L_014E;\nL_00D2:\n\tgoto L_00DA;\n\tv344 = *([v338 @ X0_v29+E0]);\n\tv345 = v344 == 0;\n\tv346 = ~v345;\n\tif (v346) goto L_00DA;\n\tv348 = \"il2cpp_codegen_runtime_class_init\"(v338, v329, v331, v226, v38, v39, v40, v41, v137, v43, v44, v45, v46, v47, v48, v49);\nL_00DA:\n\tv353 = System.Type::GetTypeFromHandle(UnityEngine.Experimental.PlayerLoop.FixedUpdate);\n\tv372 = System.Type::op_Equality(*([v230 @ X25_v4-10]), v353);\n\tv377 = v372 == 0;\n\tif (v377) goto L_010F;\n\tv381 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v381);\n\tUnityEngine.Object::set_name(v381, \"MORPEH_FIXED_UPDATE_WORKAROUND\");\n\tUnityEngine.Object::set_hideFlags(v381, 0x3D);\n\tv452 = UnityEngine.GameObject::AddComponent(v381);\n\tgoto L_0106;\n\tv461 = *([v456 @ X0_v50+E0]);\n\tv462 = v461 == 0;\n\tv463 = ~v462;\n\tif (v463) goto L_0106;\n\tv465 = \"il2cpp_codegen_runtime_class_init\"(v456, v451, v421, v226, v38, v39, v40, v41, v137, v43, v44, v45, v46, v47, v48, v49);\nL_0106:\n\tUnityEngine.Object::DontDestroyOnLoad(v381);\n\tgoto L_0127;\nL_010F:\n\tgoto L_0117;\n\tv400 = *([v382 @ X0_v35+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_0117;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v382, v369, v371, v226, v38, v39, v40, v41, v137, v43, v44, v45, v46, v47, v48, v49);\nL_0117:\n\tv409 = System.Type::GetTypeFromHandle(UnityEngine.Experimental.PlayerLoop.PostLateUpdate);\n\tv434 = System.Type::op_Equality(*([v230 @ X25_v4-10]), v409);\n\tv364 = v434 == 0;\n\tif (v364) goto L_0127;\n\tv327 = *([v230 @ X25_v4]);\n\tv361 = new UnityEngine.Experimental.LowLevel.PlayerLoopSystem+UpdateFunction();\n\tgoto L_00AB;\nL_0126:\n\t*([v230 @ X25_v4]) = 0;\nL_0127:\n\tv231 = v231 + 1;\n\tv230 = v230 + 0x28;\n\tv188 = v231 < v128.Length;\n\tif (v188) goto L_0094;\nL_013F:\n\tUnityEngine.Experimental.LowLevel.PlayerLoop::SetPlayerLoop(&v126 @ stack_-A8_v1 (System.Type));\n\treturn;\nL_014E:\n\tthrow System.InvalidCastException;\n// 222 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void InitializationWithPlayerLoop()
		{
			//IL_0213: Expected O, but got Ref
			//IL_0019: Expected O, but got I
			//IL_004a: Expected O, but got I
			//IL_011c: Expected O, but got I
			//IL_0205: Expected O, but got I4
			//IL_01ba: Expected O, but got I
			//IL_02a5: Expected O, but got I
			World world = new World();
			Default = world;
			Default.RegisterInDefaultPlayerLoop();
			PlayerLoopSystem defaultPlayerLoop = PlayerLoop.GetDefaultPlayerLoop();
			Type type = defaultPlayerLoop.type;
			PlayerLoopSystem[] subSystemList = defaultPlayerLoop.subSystemList;
			if (subSystemList.Length >= 1)
			{
				object obj = (long)(IntPtr)subSystemList + 48L;
				int num = 0;
				do
				{
					Type typeFromHandle = typeof(PreLateUpdate);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X25_v4-10]");
					Delegate a;
					PlayerLoopSystem.UpdateFunction b;
					if ((Type)0 == typeFromHandle)
					{
						a = (Delegate)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: UpdateFunction");
						b = null;
						IntPtr intPtr = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<void>*/)(&PlayerLoopUpdate);
						goto IL_02c3;
					}
					Type typeFromHandle2 = typeof(FixedUpdate);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X25_v4-10]");
					if ((Type)0 == typeFromHandle2)
					{
						GameObject gameObject = new GameObject();
						gameObject.name = "MORPEH_FIXED_UPDATE_WORKAROUND";
						gameObject.hideFlags = HideFlags.HideAndDontSave;
						FixedUpdateWorkaround fixedUpdateWorkaround = gameObject.AddComponent<FixedUpdateWorkaround>();
						UnityEngine.Object.DontDestroyOnLoad(gameObject);
					}
					else
					{
						Type typeFromHandle3 = typeof(PostLateUpdate);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X25_v4-10]");
						if ((Type)0 == typeFromHandle3)
						{
							a = (Delegate)obj;
							b = null;
							IntPtr intPtr = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<void>*/)(&PlayerLoopLateUpdate);
							goto IL_02c3;
						}
					}
					goto IL_0288;
					IL_0288:
					num++;
					obj = (long)(IntPtr)obj + 40L;
					continue;
					IL_02c3:
					Delegate obj2 = Delegate.Combine(a, b);
					if (obj2 != null)
					{
						if ((object)obj2.GetType() == typeof(PlayerLoopSystem.UpdateFunction))
						{
							obj = obj2;
							if ((object)obj2.GetType() == typeof(PlayerLoopSystem.UpdateFunction))
							{
								goto IL_0288;
							}
						}
						throw new InvalidCastException();
					}
					obj = 0;
					goto IL_0288;
				}
				while (num < subSystemList.Length);
			}
			PlayerLoop.SetPlayerLoop((PlayerLoopSystem)(&type));
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15F989C", Offset = "0x15F989C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EC2D80]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A077]) = v35;\nL_0015:\n\tv40 = 0;\n\tgoto L_0027;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v41, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv49 = Morpeh.World;\nL_0027:\n\tv58 = System.Collections.Generic.List`1<Morpeh.World>::GetEnumerator(v53.Worlds);\nL_002C:\n\tv69 = System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>::MoveNext(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>));\n\tv67 = v69 == 0;\n\tif (v67) goto L_0037;\n\tMorpeh.World::Update(0);\n\tgoto L_002C;\nL_0037:\n\tv75 = System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>));\n\tgoto L_0054;\n\tgoto L_003A;\nL_003A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0055;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDC710]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0056;\nL_0054:\n\treturn;\nL_0055:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0056:\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PlayerLoopUpdate()
		{
			List<World>.Enumerator enumerator = default(List<World>.Enumerator);
			List<World>.Enumerator enumerator2 = Worlds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((World)null).Update();
			}
			enumerator.Dispose();
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15F9D90", Offset = "0x15F9D90", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EC6380]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A078]) = v35;\nL_0015:\n\tv40 = 0;\n\tgoto L_0027;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v41, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv49 = Morpeh.World;\nL_0027:\n\tv58 = System.Collections.Generic.List`1<Morpeh.World>::GetEnumerator(v53.Worlds);\nL_002C:\n\tv69 = System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>::MoveNext(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>));\n\tv67 = v69 == 0;\n\tif (v67) goto L_0037;\n\tMorpeh.World::FixedUpdate(0);\n\tgoto L_002C;\nL_0037:\n\tv75 = System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>));\n\tgoto L_0054;\n\tgoto L_003A;\nL_003A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0055;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDC710]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0056;\nL_0054:\n\treturn;\nL_0055:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0056:\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PlayerLoopFixedUpdate()
		{
			List<World>.Enumerator enumerator = default(List<World>.Enumerator);
			List<World>.Enumerator enumerator2 = Worlds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((World)null).FixedUpdate();
			}
			enumerator.Dispose();
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15FA030", Offset = "0x15FA030", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F056F8]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A079]) = v35;\nL_0015:\n\tv40 = 0;\n\tgoto L_0027;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v41, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv49 = Morpeh.World;\nL_0027:\n\tv58 = System.Collections.Generic.List`1<Morpeh.World>::GetEnumerator(v53.Worlds);\nL_002C:\n\tv69 = System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>::MoveNext(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>));\n\tv67 = v69 == 0;\n\tif (v67) goto L_0037;\n\tMorpeh.World::LateUpdate(0);\n\tgoto L_002C;\nL_0037:\n\tv75 = System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>::Dispose(&v40 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.World>+Enumerator<Morpeh.World>));\n\tgoto L_0054;\n\tgoto L_003A;\nL_003A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0055;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDC710]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0056;\nL_0054:\n\treturn;\nL_0055:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0056:\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PlayerLoopLateUpdate()
		{
			List<World>.Enumerator enumerator = default(List<World>.Enumerator);
			List<World>.Enumerator enumerator2 = Worlds.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((World)null).LateUpdate();
			}
			enumerator.Dispose();
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x15F9820", Offset = "0x15F9820", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0FB80]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A07A]) = v38;\nL_0019:\n\tgoto L_002B;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_002B;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Morpeh.World;\nL_002B:\n\tSystem.Collections.Generic.List`1<Morpeh.World>::Add(v53.Worlds, this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RegisterInDefaultPlayerLoop()
		{
			Worlds.Add(this);
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x15FA2D0", Offset = "0x15FA2D0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC0AE0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A07B]) = v38;\nL_0019:\n\tgoto L_002B;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Morpeh.World>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_002B;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Morpeh.World;\nL_002B:\n\tv62 = System.Collections.Generic.List`1<Morpeh.World>::Remove(v53.Worlds, this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UnregisterInDefaultPlayerLoop()
		{
			bool flag = Worlds.Remove(this);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x15F99A8", Offset = "0x15F99A8", Length = "0x3E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv30 = *([1EFA968]);\n\tv31 = *([v30 @ X8_v40]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202A07C]) = v50;\nL_0024:\n\tv63 = System.Collections.Generic.List`1<System.IDisposable>::GetEnumerator(this.disposables);\nL_002F:\n\tv129 = System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>::MoveNext(&v62 @ stack_-A8_v1 (System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>));\n\tv131 = v129 == 0;\n\tif (v131) goto L_0065;\n\tgoto L_005F;\n\tv140 = *([v133 @ X8_v35+B0]);\n\tv141 = 0;\n\tv142 = v140 + 8;\n\tv144 = *([v181 @ X11_v27-8]);\n\tv186 = v144 == v132;\n\tif (v186) goto L_0058;\n\tv164 = v180 + 1;\n\tv195 = v164 < v134;\n\tv162 = ~v195;\n\tv166 = v181 + 0x10;\n\tv146 = ~v162;\n\tif (v146) goto L_FFFFFFFF;\n\tv167 = v126;\n\tv168 = 0;\n\tv169 = 0x8909C4(v167, v132, v168, v35, v36, v37, v38, v39, v66, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_005F;\nL_0058:\n\tv196 = *([v181 @ X11_v27]);\n\tv197 = v196 << 4;\n\tv198 = v133 + v197;\n\tv199 = v198 + 0x130;\nL_005F:\n\tSystem.IDisposable::Dispose(v65);\n\tgoto L_002F;\nL_0065:\n\tv139 = System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>::Dispose(&v62 @ stack_-A8_v1 (System.Collections.Generic.List`1<System.IDisposable>+Enumerator<System.IDisposable>));\n\tgoto L_0082;\n\tgoto L_0068;\nL_0068:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_017F;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F06770]);\n\tX0 = &stack[40];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0180;\nL_0082:\n\tSystem.Collections.Generic.List`1<System.IDisposable>::Clear(this.disposables);\n\tMorpeh.Filter::Update(this.Filter);\n\tv210 = System.Collections.Generic.List`1<Morpeh.IInitializer>::GetEnumerator(this.newInitializers);\nL_0095:\n\tv261 = System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>::MoveNext(&v209 @ stack_-A8_v2 (System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>));\n\tv263 = v261 == 0;\n\tif (v263) goto L_00CE;\n\tgoto L_00C6;\n\tv272 = *([v265 @ X8_v31+B0]);\n\tv273 = 0;\n\tv274 = v272 + 8;\n\tv276 = *([v313 @ X11_v21-8]);\n\tv318 = v276 == v264;\n\tif (v318) goto L_00BE;\n\tv296 = v312 + 1;\n\tv327 = v296 < v266;\n\tv294 = ~v327;\n\tv298 = v313 + 0x10;\n\tv278 = ~v294;\n\tif (v278) goto L_FFFFFFFF;\n\tv299 = 5;\n\tv300 = v258;\n\tv301 = 0x8909C4(v300, v264, v299, v35, v36, v37, v38, v39, v212, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_00C6;\nL_00BE:\n\tv328 = *([v313 @ X11_v21]);\n\tv329 = v328 + 5;\n\tv330 = v329 << 4;\n\tv331 = v265 + v330;\n\tv332 = v331 + 0x130;\nL_00C6:\n\tMorpeh.IInitializer::OnStart(v65);\n\tMorpeh.Filter::Update(this.Filter);\n\tgoto L_0095;\nL_00CE:\n\tv271 = System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>::Dispose(&v209 @ stack_-A8_v2 (System.Collections.Generic.List`1<Morpeh.IInitializer>+Enumerator<Morpeh.IInitializer>));\n\tgoto L_00EC;\n\tgoto L_00D2;\n\tgoto L_00D2;\nL_00D2:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_017F;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB2E30]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0180;\nL_00EC:\n\tSystem.Collections.Generic.List`1<Morpeh.IInitializer>::Clear(this.newInitializers);\n\tv338 = UnityEngine.Time::get_deltaTime();\n\tv435 = this.systems;\n\tv352 = v435._size < 1;\n\tif (v352) goto L_017E;\n\tgoto L_0108;\nL_0106:\n\tv435 = this.systems;\nL_0108:\n\tv441 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Values(v435);\n\tgoto L_0136;\n\tv447 = *([v443 @ X8_v23+B0]);\n\tv448 = 0;\n\tv449 = v447 + 8;\n\tv451 = *([v488 @ X11_v15-8]);\n\tv493 = v451 == v444;\n\tif (v493) goto L_012E;\n\tv471 = v487 + 1;\n\tv498 = v471 < v445;\n\tv469 = ~v498;\n\tv473 = v488 + 0x10;\n\tv453 = ~v469;\n\tif (v453) goto L_FFFFFFFF;\n\tv474 = v442;\n\tv475 = 0;\n\tv476 = 0x8909C4(v474, v444, v475, v35, v36, v37, v38, v39, v434, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0136;\nL_012E:\n\tv499 = *([v488 @ X11_v15]);\n\tv500 = v499 << 4;\n\tv501 = v443 + v500;\n\tv502 = v501 + 0x130;\nL_0136:\n\tv524 = System.Collections.Generic.IList`1<Morpeh.ISystem>::get_Item(v441, v439);\n\tgoto L_0164;\n\tv528 = *([v525 @ X8_v26+B0]);\n\tv529 = 0;\n\tv530 = v528 + 8;\n\tv532 = *([v569 @ X11_v10-8]);\n\tv574 = v532 == v526;\n\tif (v574) goto L_015C;\n\tv552 = v568 + 1;\n\tv579 = v552 < v527;\n\tv550 = ~v579;\n\tv554 = v569 + 0x10;\n\tv534 = ~v550;\n\tif (v534) goto L_FFFFFFFF;\n\tv555 = v396;\n\tv556 = 0;\n\tv557 = 0x8909C4(v555, v526, v556, v35, v36, v37, v38, v39, v434, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0164;\nL_015C:\n\tv580 = *([v569 @ X11_v10]);\n\tv581 = v580 << 4;\n\tv582 = v525 + v581;\n\tv583 = v582 + 0x130;\nL_0164:\n\tMorpeh.ISystem::OnUpdate(v524, v338);\n\tMorpeh.Filter::Update(this.Filter);\n\tv439 = v439 + 1;\n\tv370 = v439 != v435._size;\n\tif (v370) goto L_0106;\nL_017E:\n\treturn;\nL_017F:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0180:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 217 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			List<IDisposable>.Enumerator enumerator = disposables.GetEnumerator();
			List<IDisposable>.Enumerator enumerator2 = default(List<IDisposable>.Enumerator);
			IDisposable disposable = default(IDisposable);
			while (enumerator2.MoveNext())
			{
				disposable.Dispose();
			}
			enumerator2.Dispose();
			disposables.Clear();
			Filter.Update();
			List<IInitializer>.Enumerator enumerator3 = newInitializers.GetEnumerator();
			List<IInitializer>.Enumerator enumerator4 = default(List<IInitializer>.Enumerator);
			while (enumerator4.MoveNext())
			{
				((IInitializer)disposable).OnStart();
				Filter.Update();
			}
			enumerator4.Dispose();
			newInitializers.Clear();
			float deltaTime = Time.deltaTime;
			SortedList<int, ISystem> sortedList = systems;
			if (sortedList.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				IList<ISystem> values = sortedList.Values;
				ISystem system = values.get_Item(num);
				system.OnUpdate(deltaTime);
				Filter.Update();
				num++;
				if (num != sortedList.Count)
				{
					sortedList = systems;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x15F9E9C", Offset = "0x15F9E9C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EAD9C8]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202A07D]) = v50;\nL_001A:\n\tMorpeh.Filter::Update(this.Filter);\n\tv53 = UnityEngine.Time::get_fixedDeltaTime();\n\tv155 = this.fixedSystems;\n\tv67 = v155._size < 1;\n\tif (v67) goto L_00AC;\n\tgoto L_0036;\nL_0034:\n\tv155 = this.fixedSystems;\nL_0036:\n\tv161 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Values(v155);\n\tgoto L_0064;\n\tv167 = *([v163 @ X8_v5+B0]);\n\tv168 = 0;\n\tv169 = v167 + 8;\n\tv171 = *([v199 @ X11_v13-8]);\n\tv213 = v171 == v164;\n\tif (v213) goto L_005C;\n\tv173 = v198 + 1;\n\tv218 = v173 < v165;\n\tv193 = ~v218;\n\tv175 = v199 + 0x10;\n\tv177 = ~v193;\n\tif (v177) goto L_FFFFFFFF;\n\tv194 = v162;\n\tv195 = 0;\n\tv196 = 0x8909C4(v194, v164, v195, v35, v36, v37, v38, v39, v154, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0064;\nL_005C:\n\tv219 = *([v199 @ X11_v13]);\n\tv220 = v219 << 4;\n\tv221 = v163 + v220;\n\tv222 = v221 + 0x130;\nL_0064:\n\tv244 = System.Collections.Generic.IList`1<Morpeh.ISystem>::get_Item(v161, v159);\n\tgoto L_0092;\n\tv248 = *([v245 @ X8_v8+B0]);\n\tv249 = 0;\n\tv250 = v248 + 8;\n\tv252 = *([v280 @ X11_v8-8]);\n\tv294 = v252 == v246;\n\tif (v294) goto L_008A;\n\tv254 = v279 + 1;\n\tv299 = v254 < v247;\n\tv274 = ~v299;\n\tv256 = v280 + 0x10;\n\tv258 = ~v274;\n\tif (v258) goto L_FFFFFFFF;\n\tv275 = v95;\n\tv276 = 0;\n\tv277 = 0x8909C4(v275, v246, v276, v35, v36, v37, v38, v39, v154, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0092;\nL_008A:\n\tv300 = *([v280 @ X11_v8]);\n\tv301 = v300 << 4;\n\tv302 = v245 + v301;\n\tv303 = v302 + 0x130;\nL_0092:\n\tMorpeh.ISystem::OnUpdate(v244, v53);\n\tMorpeh.Filter::Update(this.Filter);\n\tv159 = v159 + 1;\n\tv100 = v159 != v155._size;\n\tif (v100) goto L_0034;\nL_00AC:\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FixedUpdate()
		{
			Filter.Update();
			float fixedDeltaTime = Time.fixedDeltaTime;
			SortedList<int, ISystem> sortedList = fixedSystems;
			if (sortedList.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				IList<ISystem> values = sortedList.Values;
				ISystem system = values.get_Item(num);
				system.OnUpdate(fixedDeltaTime);
				Filter.Update();
				num++;
				if (num != sortedList.Count)
				{
					sortedList = fixedSystems;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x15FA13C", Offset = "0x15FA13C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1F0F418]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202A07E]) = v50;\nL_001A:\n\tMorpeh.Filter::Update(this.Filter);\n\tv53 = UnityEngine.Time::get_deltaTime();\n\tv155 = this.lateSystems;\n\tv67 = v155._size < 1;\n\tif (v67) goto L_00AC;\n\tgoto L_0036;\nL_0034:\n\tv155 = this.lateSystems;\nL_0036:\n\tv161 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Values(v155);\n\tgoto L_0064;\n\tv167 = *([v163 @ X8_v5+B0]);\n\tv168 = 0;\n\tv169 = v167 + 8;\n\tv171 = *([v199 @ X11_v13-8]);\n\tv213 = v171 == v164;\n\tif (v213) goto L_005C;\n\tv173 = v198 + 1;\n\tv218 = v173 < v165;\n\tv193 = ~v218;\n\tv175 = v199 + 0x10;\n\tv177 = ~v193;\n\tif (v177) goto L_FFFFFFFF;\n\tv194 = v162;\n\tv195 = 0;\n\tv196 = 0x8909C4(v194, v164, v195, v35, v36, v37, v38, v39, v154, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0064;\nL_005C:\n\tv219 = *([v199 @ X11_v13]);\n\tv220 = v219 << 4;\n\tv221 = v163 + v220;\n\tv222 = v221 + 0x130;\nL_0064:\n\tv244 = System.Collections.Generic.IList`1<Morpeh.ISystem>::get_Item(v161, v159);\n\tgoto L_0092;\n\tv248 = *([v245 @ X8_v8+B0]);\n\tv249 = 0;\n\tv250 = v248 + 8;\n\tv252 = *([v280 @ X11_v8-8]);\n\tv294 = v252 == v246;\n\tif (v294) goto L_008A;\n\tv254 = v279 + 1;\n\tv299 = v254 < v247;\n\tv274 = ~v299;\n\tv256 = v280 + 0x10;\n\tv258 = ~v274;\n\tif (v258) goto L_FFFFFFFF;\n\tv275 = v95;\n\tv276 = 0;\n\tv277 = 0x8909C4(v275, v246, v276, v35, v36, v37, v38, v39, v154, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_0092;\nL_008A:\n\tv300 = *([v280 @ X11_v8]);\n\tv301 = v300 << 4;\n\tv302 = v245 + v301;\n\tv303 = v302 + 0x130;\nL_0092:\n\tMorpeh.ISystem::OnUpdate(v244, v53);\n\tMorpeh.Filter::Update(this.Filter);\n\tv159 = v159 + 1;\n\tv100 = v159 != v155._size;\n\tif (v100) goto L_0034;\nL_00AC:\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			Filter.Update();
			float deltaTime = Time.deltaTime;
			SortedList<int, ISystem> sortedList = lateSystems;
			if (sortedList.Count < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				IList<ISystem> values = sortedList.Values;
				ISystem system = values.get_Item(num);
				system.OnUpdate(deltaTime);
				Filter.Update();
				num++;
				if (num != sortedList.Count)
				{
					sortedList = lateSystems;
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x9EA5C0", Offset = "0x9EA5C0", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDE1F0]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, initializer, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021AC7]) = v43;\nL_0017:\n\tv45 = initializer->klass;\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<T>)+126]) == 0;\n\tif (v49) goto L_003A;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<T>)+B0]) + 8;\nL_0025:\n\tv108 = *([v103 @ X11_v17-8]) == Morpeh.IInitializer;\n\tif (v108) goto L_003D;\n\tv102 = v102 + 1;\n\tv113 = v102 < *([v45 @ X8_v3 (Il2CppClass<T>)+126]);\n\tv81 = ~v113;\n\tv103 = v103 + 0x10;\n\tv57 = ~v81;\n\tif (v57) goto L_0025;\nL_003A:\n\tv135 = 0x8909C4(initializer, Morpeh.IInitializer, 1, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0045;\nL_003D:\n\tv115 = *([v103 @ X11_v17]) + 1;\n\tv116 = v115 << 4;\n\tv117 = v45 + v116;\n\tv135 = v117 + 0x130;\nL_0045:\n\t*([v135 @ X0_v2])(v141, initializer, this, *([v135 @ X0_v2+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv145 = new Morpeh.FilterProvider();\n\tMorpeh.FilterProvider::.ctor(v145);\n\tv145.World = this;\n\tv148 = initializer->klass;\n\tv151 = *([v148 @ X8_v8 (Il2CppClass<T>)+126]) == 0;\n\tif (v151) goto L_0070;\n\tv193 = *([v148 @ X8_v8 (Il2CppClass<T>)+B0]) + 8;\nL_005B:\n\tv198 = *([v193 @ X11_v12-8]) == Morpeh.IInitializer;\n\tif (v198) goto L_0073;\n\tv192 = v192 + 1;\n\tv203 = v192 < *([v148 @ X8_v8 (Il2CppClass<T>)+126]);\n\tv174 = ~v203;\n\tv193 = v193 + 0x10;\n\tv158 = ~v174;\n\tif (v158) goto L_005B;\nL_0070:\n\tv224 = 0x8909C4(initializer, Morpeh.IInitializer, 3, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0078;\nL_0073:\n\tv205 = *([v193 @ X11_v12]) + 3;\n\tv206 = v205 << 4;\n\tv207 = v148 + v206;\n\tv224 = v207 + 0x130;\nL_0078:\n\tv295 = *([v224 @ X0_v7+8]);\n\t*([v224 @ X0_v7])(v230, initializer, v145, *([v224 @ X0_v7+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv231 = initializer->klass;\n\tv234 = *([v231 @ X8_v11 (Il2CppClass<T>)+126]) == 0;\n\tif (v234) goto L_009E;\n\tv276 = *([v231 @ X8_v11 (Il2CppClass<T>)+B0]) + 8;\nL_0089:\n\tv281 = *([v276 @ X11_v7-8]) == Morpeh.IInitializer;\n\tif (v281) goto L_00A1;\n\tv275 = v275 + 1;\n\tv286 = v275 < *([v231 @ X8_v11 (Il2CppClass<T>)+126]);\n\tv257 = ~v286;\n\tv276 = v276 + 0x10;\n\tv241 = ~v257;\n\tif (v241) goto L_0089;\nL_009E:\n\tv307 = 0x8909C4(initializer, Morpeh.IInitializer, 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00A8;\nL_00A1:\n\tv288 = *([v276 @ X11_v7]) + 4;\n\tv289 = v288 << 4;\n\tv290 = v231 + v289;\n\tv307 = v290 + 0x130;\nL_00A8:\n\t*([v307 @ X0_v10])(v312, initializer, *([v307 @ X0_v10+8]), v295, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tSystem.Collections.Generic.List`1<Morpeh.IInitializer>::Add(this.newInitializers, initializer);\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddInitializer<T>(T initializer) where T : class, IInitializer
		{
			//IL_0271: Expected I, but got O
			//IL_02e6: Expected I, but got O
			//IL_001b: Expected O, but got I
			//IL_0357: Expected I, but got O
			//IL_00e4: Expected O, but got I
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Expected O, but got Unknown
			//IL_00ba: Expected O, but got I
			//IL_00c9: Expected O, but got I
			//IL_0067: Expected O, but got I
			//IL_01ad: Expected O, but got I
			//IL_0161: Unknown result type (might be due to invalid IL or missing references)
			//IL_0166: Expected O, but got Unknown
			//IL_0183: Expected O, but got I
			//IL_0192: Expected O, but got I
			//IL_0130: Expected O, but got I
			//IL_0233: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Expected O, but got Unknown
			//IL_0255: Expected O, but got I
			//IL_0264: Expected O, but got I
			//IL_01f9: Expected O, but got I
			IntPtr intPtr = (IntPtr)initializer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<T>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0080;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<T>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v17-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IInitializer))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<T>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0080;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_02c0;
			IL_0212:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			int num4 = 4;
			goto IL_03a6;
			IL_0149:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0335;
			IL_0335:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v224 @ X0_v7+8]");
			num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v224 @ X0_v7] (should have been resolved before IL gen)");
			IntPtr intPtr2 = (IntPtr)initializer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v11 (Il2CppClass<T>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0212;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v11 (Il2CppClass<T>)+B0]");
			object obj5 = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IInitializer))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v231 @ X8_v11 (Il2CppClass<T>)+126]");
				bool flag3 = (long)num6 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0212;
			}
			object obj6 = obj5 + 4;
			int num7 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num7;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_03a6;
			IL_03a6:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v307 @ X0_v10] (should have been resolved before IL gen)");
			newInitializers.Add(initializer);
			return;
			IL_0080:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_02c0;
			IL_02c0:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v135 @ X0_v2] (should have been resolved before IL gen)");
			FilterProvider filterProvider = new FilterProvider();
			filterProvider.World = this;
			IntPtr intPtr3 = (IntPtr)initializer;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v8 (Il2CppClass<T>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0149;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v8 (Il2CppClass<T>)+B0]");
			object obj9 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IInitializer))
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v8 (Il2CppClass<T>)+126]");
				bool flag5 = (long)num9 < 0L;
				bool flag6 = !flag5;
				obj9 = (long)(IntPtr)obj9 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_0149;
			}
			object obj10 = obj9 + 3;
			int num10 = (int)((long)(IntPtr)obj10 << 4);
			object obj11 = (long)intPtr3 + (long)num10;
			object obj12 = (long)(IntPtr)obj11 + 304L;
			goto IL_0335;
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x9EA77C", Offset = "0x9EA77C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EBECF8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, initializer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021AC8]) = v41;\nL_0020:\n\tv52 = System.Collections.Generic.List`1<Morpeh.IInitializer>::Remove(this.newInitializers, initializer);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveInitializer<T>(T initializer) where T : class, IInitializer
		{
			bool flag = newInitializers.Remove(initializer);
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x11BE2D0", Offset = "0x11BE2D0", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EC9E10]);\n\tv35 = *([v34 @ X8_v17]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, order, system, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2027B21]) = v51;\nL_001C:\n\tv84 = this.systems;\n\tv77 = this.disabledSystems;\n\t// 33 IsInst v58 @ X0_v3, typeof(Morpeh.IFixedSystem), system @ X2 (T)\n\tv59 = v58 == 0;\n\tif (v59) goto L_002B;\n\tv73 = this + 0x20;\n\tv68 = this + 0x38;\n\tgoto L_0030;\nL_002B:\n\t// 43 IsInst v66 @ X0_v18, typeof(Morpeh.ILateSystem), system @ X2 (T)\n\tv72 = v66 == 0;\n\tif (v72) goto L_0037;\n\tv73 = this + 0x28;\n\tv68 = this + 0x40;\nL_0030:\n\tv84 = this.lateSystems;\n\tv77 = this.disabledLateSystems;\nL_0037:\n\tv90 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::ContainsValue(v84, system);\n\tv92 = v90 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::ContainsValue(v77, system);\n\tv102 = v97 == 0;\n\tif (v102) goto L_004B;\n\tgoto L_005D;\nL_004B:\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Add(v84, order, system);\n\tv132 = Morpeh.World::AddInitializer(this, system);\nL_005D:\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AddSystem<T>(int order, T system) where T : class, ISystem
		{
			//IL_0011: Expected O, but got I
			//IL_001d: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_0064: Expected O, but got I
			SortedList<int, ISystem> sortedList = systems;
			SortedList<int, ISystem> sortedList2 = disabledSystems;
			object obj = system as IFixedSystem;
			object obj2;
			object obj3;
			if (obj != null)
			{
				obj2 = (long)(IntPtr)this + 32L;
				obj3 = (long)(IntPtr)this + 56L;
			}
			else
			{
				object obj4 = system as ILateSystem;
				if (obj4 == null)
				{
					goto IL_0121;
				}
				obj2 = (long)(IntPtr)this + 40L;
				obj3 = (long)(IntPtr)this + 64L;
			}
			sortedList = (SortedList<int, ISystem>)obj2;
			sortedList2 = (SortedList<int, ISystem>)obj3;
			goto IL_0121;
			IL_0121:
			if (sortedList.ContainsValue(system) || sortedList2.ContainsValue(system))
			{
				return false;
			}
			sortedList.Add(order, system);
			AddInitializer(system);
			return true;
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x11BE5A0", Offset = "0x11BE5A0", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EE8290]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, system, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2027B23]) = v45;\nL_0018:\n\tv71 = this.systems;\n\tv78 = this.disabledSystems;\n\t// 29 IsInst v52 @ X0_v3, typeof(Morpeh.IFixedSystem), system @ X1 (T)\n\tv53 = v52 == 0;\n\tif (v53) goto L_0027;\n\tv67 = this + 0x20;\n\tv62 = this + 0x38;\n\tgoto L_002C;\nL_0027:\n\t// 39 IsInst v60 @ X0_v25, typeof(Morpeh.ILateSystem), system @ X1 (T)\n\tv66 = v60 == 0;\n\tif (v66) goto L_0033;\n\tv67 = this + 0x28;\n\tv62 = this + 0x40;\nL_002C:\n\tv71 = this.lateSystems;\n\tv78 = this.disabledLateSystems;\nL_0033:\n\tv84 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::ContainsValue(v78, system);\n\tv86 = v84 == 0;\n\tif (v86) goto L_FFFFFFFF;\n\tv91 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Keys(v78);\n\tv99 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::IndexOfValue(v78, system);\n\tgoto L_0074;\n\tv169 = *([v165 @ X8_v13+B0]);\n\tv170 = 0;\n\tv171 = v169 + 8;\n\tv173 = *([v209 @ X11_v6-8]);\n\tv215 = v173 == v168;\n\tif (v215) goto L_006C;\n\tv195 = v210 + 1;\n\tv220 = v195 < v167;\n\tv191 = ~v220;\n\tv193 = v209 + 0x10;\n\tv175 = ~v191;\n\tif (v175) goto L_FFFFFFFF;\n\tv196 = v95;\n\tv197 = 0;\n\tv198 = 0x8909C4(v196, v168, v197, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0074;\n\tgoto L_008C;\nL_006C:\n\tv221 = *([v209 @ X11_v6]);\n\tv222 = v221 << 4;\n\tv223 = v165 + v222;\n\tv224 = v223 + 0x130;\nL_0074:\n\tv232 = System.Collections.Generic.IList`1<System.Int32>::get_Item(v91, v99);\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Add(v71, v232, system);\n\tv240 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Remove(v78, v232);\nL_008C:\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool EnableSystem<T>(T system) where T : class, ISystem
		{
			//IL_0011: Expected O, but got I
			//IL_001d: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_0064: Expected O, but got I
			SortedList<int, ISystem> sortedList = systems;
			SortedList<int, ISystem> sortedList2 = disabledSystems;
			object obj = system as IFixedSystem;
			object obj2;
			object obj3;
			if (obj != null)
			{
				obj2 = (long)(IntPtr)this + 32L;
				obj3 = (long)(IntPtr)this + 56L;
			}
			else
			{
				object obj4 = system as ILateSystem;
				if (obj4 == null)
				{
					goto IL_00f2;
				}
				obj2 = (long)(IntPtr)this + 40L;
				obj3 = (long)(IntPtr)this + 64L;
			}
			sortedList = (SortedList<int, ISystem>)obj2;
			sortedList2 = (SortedList<int, ISystem>)obj3;
			goto IL_00f2;
			IL_00f2:
			if (sortedList2.ContainsValue(system))
			{
				IList<int> keys = sortedList2.Keys;
				int index = sortedList2.IndexOfValue(system);
				int key = keys.get_Item(index);
				sortedList.Add(key, system);
				bool flag = sortedList2.Remove(key);
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x11BE3F8", Offset = "0x11BE3F8", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EF1B80]);\n\tv27 = *([v26 @ X8_v27]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, system, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2027B22]) = v45;\nL_0018:\n\tv78 = this.systems;\n\tv71 = this.disabledSystems;\n\t// 29 IsInst v52 @ X0_v3, typeof(Morpeh.IFixedSystem), system @ X1 (T)\n\tv53 = v52 == 0;\n\tif (v53) goto L_0027;\n\tv67 = this + 0x20;\n\tv62 = this + 0x38;\n\tgoto L_002C;\nL_0027:\n\t// 39 IsInst v60 @ X0_v25, typeof(Morpeh.ILateSystem), system @ X1 (T)\n\tv66 = v60 == 0;\n\tif (v66) goto L_0033;\n\tv67 = this + 0x28;\n\tv62 = this + 0x40;\nL_002C:\n\tv78 = this.lateSystems;\n\tv71 = this.disabledLateSystems;\nL_0033:\n\tv84 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::ContainsValue(v78, system);\n\tv86 = v84 == 0;\n\tif (v86) goto L_FFFFFFFF;\n\tv91 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Keys(v78);\n\tv99 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::IndexOfValue(v78, system);\n\tgoto L_0074;\n\tv169 = *([v165 @ X8_v13+B0]);\n\tv170 = 0;\n\tv171 = v169 + 8;\n\tv173 = *([v209 @ X11_v6-8]);\n\tv215 = v173 == v168;\n\tif (v215) goto L_006C;\n\tv195 = v210 + 1;\n\tv220 = v195 < v167;\n\tv191 = ~v220;\n\tv193 = v209 + 0x10;\n\tv175 = ~v191;\n\tif (v175) goto L_FFFFFFFF;\n\tv196 = v95;\n\tv197 = 0;\n\tv198 = 0x8909C4(v196, v168, v197, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0074;\n\tgoto L_008C;\nL_006C:\n\tv221 = *([v209 @ X11_v6]);\n\tv222 = v221 << 4;\n\tv223 = v165 + v222;\n\tv224 = v223 + 0x130;\nL_0074:\n\tv232 = System.Collections.Generic.IList`1<System.Int32>::get_Item(v91, v99);\n\tSystem.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Add(v71, v232, system);\n\tv240 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Remove(v78, v232);\nL_008C:\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool DisableSystem<T>(T system) where T : class, ISystem
		{
			//IL_0011: Expected O, but got I
			//IL_001d: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_0064: Expected O, but got I
			SortedList<int, ISystem> sortedList = systems;
			SortedList<int, ISystem> sortedList2 = disabledSystems;
			object obj = system as IFixedSystem;
			object obj2;
			object obj3;
			if (obj != null)
			{
				obj2 = (long)(IntPtr)this + 32L;
				obj3 = (long)(IntPtr)this + 56L;
			}
			else
			{
				object obj4 = system as ILateSystem;
				if (obj4 == null)
				{
					goto IL_00f2;
				}
				obj2 = (long)(IntPtr)this + 40L;
				obj3 = (long)(IntPtr)this + 64L;
			}
			sortedList = (SortedList<int, ISystem>)obj2;
			sortedList2 = (SortedList<int, ISystem>)obj3;
			goto IL_00f2;
			IL_00f2:
			if (sortedList.ContainsValue(system))
			{
				IList<int> keys = sortedList.Keys;
				int index = sortedList.IndexOfValue(system);
				int key = keys.get_Item(index);
				sortedList2.Add(key, system);
				bool flag = sortedList.Remove(key);
				return true;
			}
			return false;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x11BE748", Offset = "0x11BE748", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EF7020]);\n\tv31 = *([v30 @ X8_v39]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, system, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2027B24]) = v48;\nL_001A:\n\tv74 = this.systems;\n\tv81 = this.disabledSystems;\n\t// 31 IsInst v55 @ X0_v3, typeof(Morpeh.IFixedSystem), system @ X1 (T)\n\tv56 = v55 == 0;\n\tif (v56) goto L_0029;\n\tv70 = this + 0x20;\n\tv65 = this + 0x38;\n\tgoto L_002E;\nL_0029:\n\t// 41 IsInst v63 @ X0_v42, typeof(Morpeh.ILateSystem), system @ X1 (T)\n\tv69 = v63 == 0;\n\tif (v69) goto L_0035;\n\tv70 = this + 0x28;\n\tv65 = this + 0x40;\nL_002E:\n\tv74 = this.lateSystems;\n\tv81 = this.disabledLateSystems;\nL_0035:\n\tv87 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::ContainsValue(v74, system);\n\tv89 = v87 == 0;\n\tif (v89) goto L_006F;\n\tv94 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Keys(v74);\n\tv105 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::IndexOfValue(v74, system);\n\tgoto L_00AE;\n\tv178 = *([v109 @ X8_v27+B0]);\n\tv179 = 0;\n\tv180 = v178 + 8;\n\tv182 = *([v259 @ X11_v14-8]);\n\tv265 = v182 == v113;\n\tif (v265) goto L_00A6;\n\tv204 = v260 + 1;\n\tv277 = v204 < v112;\n\tv200 = ~v277;\n\tv202 = v259 + 0x10;\n\tv184 = ~v200;\n\tif (v184) goto L_FFFFFFFF;\n\tv205 = v101;\n\tv206 = 0;\n\tv207 = 0x8909C4(v205, v113, v206, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00AE;\nL_006F:\n\tv98 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::ContainsValue(v81, system);\n\tv107 = v98 == 0;\n\tif (v107) goto L_FFFFFFFF;\n\tv119 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::get_Keys(v81);\n\tv214 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::IndexOfValue(v81, system);\n\tgoto L_00BC;\n\tv308 = *([v271 @ X8_v17+B0]);\n\tv309 = 0;\n\tv310 = v308 + 8;\n\tv312 = *([v369 @ X11_v8-8]);\n\tv375 = v312 == v275;\n\tif (v375) goto L_00B4;\n\tv334 = v370 + 1;\n\tv381 = v334 < v274;\n\tv330 = ~v381;\n\tv332 = v369 + 0x10;\n\tv314 = ~v330;\n\tif (v314) goto L_FFFFFFFF;\n\tv335 = v210;\n\tv336 = 0;\n\tv337 = 0x8909C4(v335, v275, v336, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00BC;\nL_00A6:\n\tv278 = *([v259 @ X11_v14]);\n\tv279 = v278 << 4;\n\tv280 = v109 + v279;\n\tv281 = v280 + 0x130;\nL_00AE:\n\tv303 = System.Collections.Generic.IList`1<System.Int32>::get_Item(v94, v105);\n\tgoto L_00C2;\nL_00B4:\n\tv382 = *([v369 @ X11_v8]);\n\tv383 = v382 << 4;\n\tv384 = v271 + v383;\n\tv385 = v384 + 0x130;\nL_00BC:\n\tv392 = System.Collections.Generic.IList`1<System.Int32>::get_Item(v119, v214);\nL_00C2:\n\tv170 = System.Collections.Generic.SortedList`2<System.Int32, Morpeh.ISystem>::Remove(v355, v166);\n\tv172 = v170 == 0;\n\tif (v172) goto L_FFFFFFFF;\n\tSystem.Collections.Generic.List`1<System.IDisposable>::Add(this.disposables, system);\n\tv401 = Morpeh.World::RemoveInitializer(this, system);\n\tgoto L_00DE;\nL_00DE:\n\treturn returnVal1;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool RemoveSystem<T>(T system) where T : class, ISystem
		{
			//IL_0011: Expected O, but got I
			//IL_001d: Expected O, but got I
			//IL_0058: Expected O, but got I
			//IL_0064: Expected O, but got I
			SortedList<int, ISystem> sortedList = systems;
			SortedList<int, ISystem> sortedList2 = disabledSystems;
			object obj = system as IFixedSystem;
			object obj2;
			object obj3;
			if (obj != null)
			{
				obj2 = (long)(IntPtr)this + 32L;
				obj3 = (long)(IntPtr)this + 56L;
			}
			else
			{
				object obj4 = system as ILateSystem;
				if (obj4 == null)
				{
					goto IL_016f;
				}
				obj2 = (long)(IntPtr)this + 40L;
				obj3 = (long)(IntPtr)this + 64L;
			}
			sortedList = (SortedList<int, ISystem>)obj2;
			sortedList2 = (SortedList<int, ISystem>)obj3;
			goto IL_016f;
			IL_016f:
			int key;
			SortedList<int, ISystem> sortedList3;
			if (sortedList.ContainsValue(system))
			{
				IList<int> keys = sortedList.Keys;
				int index = sortedList.IndexOfValue(system);
				int num = keys.get_Item(index);
				key = num;
				sortedList3 = sortedList;
			}
			else
			{
				if (!sortedList2.ContainsValue(system))
				{
					goto IL_010e;
				}
				IList<int> keys2 = sortedList2.Keys;
				int index2 = sortedList2.IndexOfValue(system);
				int num2 = keys2.get_Item(index2);
				key = num2;
				sortedList3 = sortedList2;
			}
			if (sortedList3.Remove(key))
			{
				disposables.Add(system);
				RemoveInitializer(system);
				return true;
			}
			goto IL_010e;
			IL_010e:
			return false;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x15FA34C", Offset = "0x15FA34C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Morpeh.World::CreateEntityInternal(this);\n\treturn returnVal1;\n")]
		public IEntity CreateEntity()
		{
			return CreateEntityInternal();
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x15FA350", Offset = "0x15FA350", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE3298]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A07F]) = v42;\nL_0015:\n\tv43 = this.freeEntityIDs;\n\tv55 = v43._size < 1;\n\tif (v55) goto L_002A;\n\tv59 = System.Collections.Generic.Queue`1<System.Int32>::Dequeue(v43);\n\tv66 = this.EntitiesLength;\n\tgoto L_0038;\nL_002A:\n\tv67 = this.EntitiesLength;\n\tv66 = this.EntitiesLength + 1;\n\tthis.EntitiesLength = v66;\nL_0038:\n\tv79 = v66 < this.EntitiesCapacity;\n\tif (v79) goto L_0043;\n\tv82 = this.EntitiesCapacity << 1;\n\tv83 = this + 0x58;\n\tSystem.Array::Resize(v83, v82);\n\tthis.EntitiesCapacity = v82;\nL_0043:\n\tv92 = this.Entities;\n\tv95 = new Morpeh.Entity();\n\tMorpeh.Entity::.ctor(v95, v67);\n\tv95.World = this;\n\tv98 = v95 == 0;\n\tif (v98) goto L_0055;\n\t// 80 IsInst v102 @ X0_v12, typeof(Morpeh.Entity), v95 @ X0_v6 (Morpeh.Entity)\n\tv106 = v102 == 0;\n\tif (v106) goto L_006C;\nL_0055:\n\tv92[v67 @ X20_v2 (System.Int32)] = v95;\n\tv111 = this.Filter;\n\tv116 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(v111.Entities, v67);\n\tv118 = this.Entities;\n\tv119 = this.EntitiesCount + 1;\n\tthis.EntitiesCount = v119;\n\treturn v118[v67 @ X20_v2 (System.Int32)];\nL_006C:\n\tv129 = new System.ArrayTypeMismatchException();\n\tthrow v129;\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe Entity CreateEntityInternal()
		{
			Queue<int> queue = freeEntityIDs;
			int num2;
			int num3;
			if (queue.Count >= 1)
			{
				int num = queue.Dequeue();
				num2 = EntitiesLength;
				num3 = num;
			}
			else
			{
				num3 = EntitiesLength;
				num2 = ++EntitiesLength;
			}
			if (num2 >= EntitiesCapacity)
			{
				int num4 = EntitiesCapacity << 1;
				Array.Resize(ref *(Entity[]*)((long)(IntPtr)this + 88L), num4);
				EntitiesCapacity = num4;
			}
			Entity[] entities = Entities;
			Entity entity = new Entity(num3);
			entity.World = this;
			if (entity != null)
			{
				object obj = entity as Entity;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			entities[num3] = entity;
			Filter filter = Filter;
			bool flag = filter.Entities.Add(num3);
			Entity[] entities2 = Entities;
			int entitiesCount = EntitiesCount + 1;
			EntitiesCount = entitiesCount;
			return entities2[num3];
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x15FA484", Offset = "0x15FA484", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Morpeh.World::CreateEntityInternal(this, id);\n\treturn returnVal1;\n")]
		public IEntity CreateEntity(out int id)
		{
			id = default(int);
			return CreateEntityInternal(out id);
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x15F6138", Offset = "0x15F6138", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE2050]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, id, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202A080]) = v45;\nL_0017:\n\tv46 = this.freeEntityIDs;\n\tv58 = v46._size < 1;\n\tif (v58) goto L_002B;\n\tv62 = System.Collections.Generic.Queue`1<System.Int32>::Dequeue(v46);\n\tgoto L_002E;\nL_002B:\n\tv93 = this.EntitiesLength;\n\tv64 = this.EntitiesLength + 1;\n\tthis.EntitiesLength = v64;\nL_002E:\n\t*([id @ X1 (System.Int32&)]) = v93;\n\tv82 = this.EntitiesLength < this.EntitiesCapacity;\n\tif (v82) goto L_0047;\n\tv85 = this.EntitiesCapacity << 1;\n\tv86 = this + 0x58;\n\tSystem.Array::Resize(v86, v85);\n\tthis.EntitiesCapacity = v85;\n\tv93 = id->klass;\nL_0047:\n\tv96 = this.Entities;\n\tv99 = new Morpeh.Entity();\n\tMorpeh.Entity::.ctor(v99, v93);\n\tv99.World = this;\n\tv102 = v99 == 0;\n\tif (v102) goto L_0059;\n\t// 84 IsInst v106 @ X0_v12, typeof(Morpeh.Entity), v99 @ X0_v6 (Morpeh.Entity)\n\tv110 = v106 == 0;\n\tif (v110) goto L_0072;\nL_0059:\n\tv96[v93 @ X21_v3 (System.Int32)] = v99;\n\tv115 = this.Filter;\n\tv120 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(v115.Entities, *([id @ X1 (System.Int32&)]));\n\tv122 = this.EntitiesCount + 1;\n\tthis.EntitiesCount = v122;\n\tv123 = this.Entities;\n\tv124 = id->klass;\n\treturn v123[v124 @ X9_v5];\nL_0072:\n\tv135 = new System.ArrayTypeMismatchException();\n\tthrow v135;\n\treturn returnVal2;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe Entity CreateEntityInternal(out int id)
		{
			//IL_0128: Expected O, but got I4
			id = default(int);
			Queue<int> queue = freeEntityIDs;
			int num2;
			if (queue.Count >= 1)
			{
				int num = queue.Dequeue();
				num2 = num;
			}
			else
			{
				num2 = EntitiesLength;
				int entitiesLength = EntitiesLength + 1;
				EntitiesLength = entitiesLength;
			}
			ref int reference = ref *(int*)num2;
			if (EntitiesLength >= EntitiesCapacity)
			{
				int num3 = EntitiesCapacity << 1;
				Array.Resize(ref *(Entity[]*)((long)(IntPtr)this + 88L), num3);
				EntitiesCapacity = num3;
				num2 = id;
			}
			Entity[] entities = Entities;
			Entity entity = new Entity(num2);
			entity.World = this;
			if (entity != null)
			{
				object obj = entity as Entity;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			entities[num2] = entity;
			Filter filter = Filter;
			bool flag = filter.Entities.Add(id);
			int entitiesCount = EntitiesCount + 1;
			EntitiesCount = entitiesCount;
			Entity[] entities2 = Entities;
			object obj2 = id;
			return entities2[obj2];
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x15F69F0", Offset = "0x15F69F0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.Entities;\n\tv2 = id->klass;\n\treturn v0[v2 @ X9_v1];\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEntity GetEntity(in int id)
		{
			//IL_0017: Expected O, but got I4
			Entity[] entities = Entities;
			object obj = id;
			return entities[obj];
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x15F63B4", Offset = "0x15F63B4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA66B0]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, entity, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A081]) = v41;\nL_0015:\n\tv42 = entity == 0;\n\tif (v42) goto L_0056;\n\tv56 = *([entity @ X1 (Morpeh.IEntity)]) != Morpeh.Entity;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_002A;\nL_002A:\n\tv64 = *([entity @ X1 (Morpeh.IEntity)]) != Morpeh.Entity;\n\tif (v64) goto L_0056;\n\tv113 = this.Entities;\n\tv102 = *([v105 @ X8_v7 (Morpeh.IEntity)+10]);\n\tv62 = v113[v102 @ X20_v4 (System.Int32)] != v105;\n\tif (v62) goto L_0056;\n\tSystem.Collections.Generic.Queue`1<System.Int32>::Enqueue(this.freeEntityIDs, v102);\n\tv122 = this.Filter;\n\tv100 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Remove(v122.Entities, v102);\n\tv124 = this.Entities;\n\tv124[v102 @ X20_v4 (System.Int32)] = 0;\n\tv104 = this.EntitiesCount - 1;\n\tthis.EntitiesCount = v104;\nL_0056:\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveEntity(IEntity entity)
		{
			if (entity == null)
			{
				return;
			}
			IEntity entity2 = (((object)entity.GetType() != typeof(Entity)) ? null : entity);
			if ((object)entity.GetType() == typeof(Entity))
			{
				Entity[] entities = Entities;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v7 (Morpeh.IEntity)+10]");
				int num = 0;
				if (entities[num] == entity2)
				{
					freeEntityIDs.Enqueue(num);
					Filter filter = Filter;
					bool flag = filter.Entities.Remove(num);
					Entity[] entities2 = Entities;
					entities2[num] = null;
					int entitiesCount = EntitiesCount - 1;
					EntitiesCount = entitiesCount;
				}
			}
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x15FA488", Offset = "0x15FA488", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1F0A0C0]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A082]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.List`1<Morpeh.World>();\n\tSystem.Collections.Generic.List`1<Morpeh.World>::.ctor(v39);\n\tv47.Worlds = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static World()
		{
			List<World> worlds = new List<World>();
			Worlds = worlds;
		}
	}
}
