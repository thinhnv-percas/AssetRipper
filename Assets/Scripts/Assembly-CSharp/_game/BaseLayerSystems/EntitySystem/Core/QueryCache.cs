using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.BaseLayerSystems.EntitySystem.Core
{
	[Token(Token = "0x200007A")]
	public class QueryCache
	{
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Dictionary<long, EntityQuery> _cache;

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x3C73D44", Offset = "0x3C73D44", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\nL_002B:\n\tv62 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::TryGetValue(this._cache, key, &v60 @ stack_-48_v5 (_game.BaseLayerSystems.EntitySystem.Core.EntityQuery));\n\tv99 = v62 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_005D;\n\t// 52 NewArr v75 @ X0_v18 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), typeof(_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), 1\n\tv144 = p1 == 0;\n\tif (v144) goto L_0045;\n\tv131 = 0x21C11D0(p1, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv133 = v131 == 0;\n\tif (v133) goto L_0072;\nL_0045:\n\tv75[0] = p1;\n\tv185 = new _game.BaseLayerSystems.EntitySystem.Core.EntityQuery();\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::.ctor(v185, v75);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::set_Item(this._cache, key, v185);\nL_005D:\n\tv141 = _game.BaseLayerSystems.EntitySystem.Core.EntityQuery::IsValid(v185);\n\tv146 = v141 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_006F;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::Recompute(v185, em);\nL_006F:\n\treturn v185._cachedEntities;\nL_0072:\n\tv139 = new System.ArrayTypeMismatchException();\n\tthrow v139;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IReadOnlyList<Entity> GetOrUpdate1(EntityManager em, long key, IComponentPool p1)
		{
			EntityQuery entityQuery = default(EntityQuery);
			if (!_cache.TryGetValue(key, out var _))
			{
				IComponentPool[] array = new IComponentPool[1];
				if (p1 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				array[0] = p1;
				entityQuery = new EntityQuery(array);
				_cache[key] = entityQuery;
			}
			if (!entityQuery.IsValid())
			{
				entityQuery.Recompute(em);
			}
			return entityQuery._cachedEntities;
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x3C73EB4", Offset = "0x3C73EB4", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tv63 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::TryGetValue(this._cache, key, &v61 @ stack_-48_v5 (_game.BaseLayerSystems.EntitySystem.Core.EntityQuery));\n\tv116 = v63 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0072;\n\t// 53 NewArr v92 @ X0_v18 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), typeof(_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), 2\n\tv177 = p1 == 0;\n\tif (v177) goto L_0046;\n\tv161 = 0x21C11D0(p1, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = v161 == 0;\n\tif (v164) goto L_0087;\nL_0046:\n\tv92[0] = p1;\n\tv220 = p2 == 0;\n\tif (v220) goto L_005A;\n\tv162 = 0x21C11D0(p2, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = v162 == 0;\n\tif (v165) goto L_0087;\nL_005A:\n\tv92[1] = p2;\n\tv230 = new _game.BaseLayerSystems.EntitySystem.Core.EntityQuery();\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::.ctor(v230, v92);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::set_Item(this._cache, key, v230);\nL_0072:\n\tv174 = _game.BaseLayerSystems.EntitySystem.Core.EntityQuery::IsValid(v230);\n\tv179 = v174 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0084;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::Recompute(v230, em);\nL_0084:\n\treturn v230._cachedEntities;\nL_0087:\n\tv172 = new System.ArrayTypeMismatchException();\n\tthrow v172;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IReadOnlyList<Entity> GetOrUpdate2(EntityManager em, long key, IComponentPool p1, IComponentPool p2)
		{
			EntityQuery entityQuery = default(EntityQuery);
			if (!_cache.TryGetValue(key, out var _))
			{
				IComponentPool[] array = new IComponentPool[2];
				if (p1 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						goto IL_018a;
					}
				}
				array[0] = p1;
				if (p2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						goto IL_018a;
					}
				}
				array[1] = p2;
				entityQuery = new EntityQuery(array);
				_cache[key] = entityQuery;
			}
			if (!entityQuery.IsValid())
			{
				entityQuery.Recompute(em);
			}
			return entityQuery._cachedEntities;
			IL_018a:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x3C7405C", Offset = "0x3C7405C", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\nL_002F:\n\tv68 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::TryGetValue(this._cache, key, &v66 @ stack_-58_v5 (_game.BaseLayerSystems.EntitySystem.Core.EntityQuery));\n\tv141 = v68 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_008F;\n\t// 56 NewArr v117 @ X0_v18 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), typeof(_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), 3\n\tv224 = p1 == 0;\n\tif (v224) goto L_0049;\n\tv205 = 0x21C11D0(p1, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = v205 == 0;\n\tif (v209) goto L_00A6;\nL_0049:\n\tv117[0] = p1;\n\tv276 = p2 == 0;\n\tif (v276) goto L_005D;\n\tv206 = 0x21C11D0(p2, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv210 = v206 == 0;\n\tif (v210) goto L_00A6;\nL_005D:\n\tv117[1] = p2;\n\tv284 = p3 == 0;\n\tif (v284) goto L_0077;\n\tv207 = 0x21C11D0(p3, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv211 = v207 == 0;\n\tif (v211) goto L_00A6;\nL_0077:\n\tv117[2] = p3;\n\tv295 = new _game.BaseLayerSystems.EntitySystem.Core.EntityQuery();\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::.ctor(v295, v117);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::set_Item(this._cache, key, v295);\nL_008F:\n\tv221 = _game.BaseLayerSystems.EntitySystem.Core.EntityQuery::IsValid(v295);\n\tv226 = v221 == 0;\n\tv227 = ~v226;\n\tif (v227) goto L_00A3;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::Recompute(v295, em);\nL_00A3:\n\treturn v295._cachedEntities;\nL_00A6:\n\tv219 = new System.ArrayTypeMismatchException();\n\tthrow v219;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IReadOnlyList<Entity> GetOrUpdate3(EntityManager em, long key, IComponentPool p1, IComponentPool p2, IComponentPool p3)
		{
			EntityQuery entityQuery = default(EntityQuery);
			if (!_cache.TryGetValue(key, out var _))
			{
				IComponentPool[] array = new IComponentPool[3];
				if (p1 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						goto IL_01e1;
					}
				}
				array[0] = p1;
				if (p2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						goto IL_01e1;
					}
				}
				array[1] = p2;
				if (p3 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj3 = default(object);
					if (obj3 == null)
					{
						goto IL_01e1;
					}
				}
				array[2] = p3;
				entityQuery = new EntityQuery(array);
				_cache[key] = entityQuery;
			}
			if (!entityQuery.IsValid())
			{
				entityQuery.Recompute(em);
			}
			return entityQuery._cachedEntities;
			IL_01e1:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x3C74244", Offset = "0x3C74244", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\nL_0030:\n\tv69 = System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::TryGetValue(this._cache, key, &v67 @ stack_-58_v5 (_game.BaseLayerSystems.EntitySystem.Core.EntityQuery));\n\tv142 = v69 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_00A4;\n\t// 57 NewArr v118 @ X0_v18 (_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), typeof(_game.BaseLayerSystems.EntitySystem.Core.IComponentPool[]), 4\n\tv237 = p1 == 0;\n\tif (v237) goto L_004A;\n\tv215 = 0x21C11D0(p1, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv220 = v215 == 0;\n\tif (v220) goto L_00BB;\nL_004A:\n\tv118[0] = p1;\n\tv289 = p2 == 0;\n\tif (v289) goto L_005E;\n\tv216 = 0x21C11D0(p2, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv221 = v216 == 0;\n\tif (v221) goto L_00BB;\nL_005E:\n\tv118[1] = p2;\n\tv297 = p3 == 0;\n\tif (v297) goto L_0078;\n\tv217 = 0x21C11D0(p3, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv222 = v217 == 0;\n\tif (v222) goto L_00BB;\nL_0078:\n\tv118[2] = p3;\n\tv306 = p4 == 0;\n\tif (v306) goto L_008C;\n\tv218 = 0x21C11D0(p4, _game.BaseLayerSystems.EntitySystem.Core.IComponentPool, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv223 = v218 == 0;\n\tif (v223) goto L_00BB;\nL_008C:\n\tv118[3] = p4;\n\tv316 = new _game.BaseLayerSystems.EntitySystem.Core.EntityQuery();\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::.ctor(v316, v118);\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::set_Item(this._cache, key, v316);\nL_00A4:\n\tv234 = _game.BaseLayerSystems.EntitySystem.Core.EntityQuery::IsValid(v316);\n\tv239 = v234 == 0;\n\tv240 = ~v239;\n\tif (v240) goto L_00B8;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityQuery::Recompute(v316, em);\nL_00B8:\n\treturn v316._cachedEntities;\nL_00BB:\n\tv232 = new System.ArrayTypeMismatchException();\n\tthrow v232;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IReadOnlyList<Entity> GetOrUpdate4(EntityManager em, long key, IComponentPool p1, IComponentPool p2, IComponentPool p3, IComponentPool p4)
		{
			EntityQuery entityQuery = default(EntityQuery);
			if (!_cache.TryGetValue(key, out var _))
			{
				IComponentPool[] array = new IComponentPool[4];
				if (p1 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj = default(object);
					if (obj == null)
					{
						goto IL_0238;
					}
				}
				array[0] = p1;
				if (p2 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						goto IL_0238;
					}
				}
				array[1] = p2;
				if (p3 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj3 = default(object);
					if (obj3 == null)
					{
						goto IL_0238;
					}
				}
				array[2] = p3;
				if (p4 != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj4 = default(object);
					if (obj4 == null)
					{
						goto IL_0238;
					}
				}
				array[3] = p4;
				entityQuery = new EntityQuery(array);
				_cache[key] = entityQuery;
			}
			if (!entityQuery.IsValid())
			{
				entityQuery.Recompute(em);
			}
			return entityQuery._cachedEntities;
			IL_0238:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x3C71534", Offset = "0x3C71534", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::Clear(this._cache);\n\treturn;\n")]
		public void Clear()
		{
			_cache.Clear();
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x3C74464", Offset = "0x3C74464", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = a - b;\n\tv5 = v4 < 0;\n\tv6 = v4 == 0;\n\tv7 = a ^ b;\n\tv8 = a ^ v4;\n\tv9 = v7 & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v6;\n\tv13 = v11 & v12;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv17 = a;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv17 = b;\nL_FFFFFFFF:\n\tv23 = a;\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv23 = b;\nL_0012:\n\tv18 = v5 == v10;\n\tv19 = ~v18;\n\tv20 = ~v19;\n\tif (v20) goto L_FFFFFFFF;\nL_001B:\n\treturnVal1 = v17 | v23;\n\treturn returnVal1;\n")]
		public static long MakeKey2(int a, int b)
		{
			//IL_0113: Expected I8, but got I4
			int num = a - b;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = a ^ b;
			int num3 = a ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num5 = ((!(flag4 && flag5)) ? b : a);
			int num6 = ((flag == flag3) ? b : a);
			return num5 | num6;
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x3C7447C", Offset = "0x3C7447C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = a - b;\n\tv5 = v4 < 0;\n\tv6 = v4 == 0;\n\tv7 = a ^ b;\n\tv8 = a ^ v4;\n\tv9 = v7 & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v6;\n\tv13 = v11 & v12;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv69 = a;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv69 = b;\nL_FFFFFFFF:\n\tv23 = a;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv23 = b;\nL_FFFFFFFF:\n\tv40 = v69;\n\tgoto L_002C;\nL_FFFFFFFF:\n\tv40 = c;\n\tgoto L_0036;\nL_FFFFFFFF:\n\tv69 = c;\nL_FFFFFFFF:\n\tv62 = v23;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv62 = v69;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv69 = v23;\nL_0012:\n\tv18 = v5 == v10;\n\tv19 = ~v18;\n\tv20 = ~v19;\n\tif (v20) goto L_FFFFFFFF;\nL_001C:\n\tv27 = v69 - c;\n\tv28 = v27 < 0;\n\tv29 = v27 == 0;\n\tv30 = v69 ^ c;\n\tv31 = v69 ^ v27;\n\tv32 = v30 & v31;\n\tv33 = v32 < 0;\n\tv34 = v28 == v33;\n\tv35 = ~v29;\n\tv36 = v34 & v35;\n\tv37 = ~v36;\n\tif (v37) goto L_FFFFFFFF;\nL_002C:\n\tv41 = v28 == v33;\n\tv42 = ~v41;\n\tv43 = ~v42;\n\tif (v43) goto L_FFFFFFFF;\nL_0036:\n\tv49 = v23 - c;\n\tv50 = v49 < 0;\n\tv51 = v49 == 0;\n\tv52 = v23 ^ c;\n\tv53 = v23 ^ v49;\n\tv54 = v52 & v53;\n\tv55 = v54 < 0;\n\tv56 = v50 == v55;\n\tv57 = ~v51;\n\tv58 = v56 & v57;\n\tv59 = ~v58;\n\tif (v59) goto L_FFFFFFFF;\nL_0046:\n\tv63 = v50 == v55;\n\tv64 = ~v51;\n\tv65 = v63 & v64;\n\tv66 = ~v65;\n\tif (v66) goto L_FFFFFFFF;\nL_0050:\n\tv71 = v40 | v62;\n\treturnVal1 = v71 | v69;\n\treturn returnVal1;\n")]
		public static long MakeKey3(int a, int b, int c)
		{
			//IL_0329: Expected I8, but got I4
			int num = a - b;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = a ^ b;
			int num3 = a ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num5 = ((!(flag4 && flag5)) ? b : a);
			int num6 = ((flag == flag3) ? b : a);
			int num7 = num5 - c;
			bool flag6 = num7 < 0;
			bool flag7 = num7 == 0;
			int num8 = num5 ^ c;
			int num9 = num5 ^ num7;
			int num10 = num8 & num9;
			bool flag8 = num10 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			int num11 = ((!(flag9 && flag10)) ? c : num5);
			if (flag6 == flag8)
			{
				num5 = c;
			}
			int num12 = num6 - c;
			bool flag11 = num12 < 0;
			bool flag12 = num12 == 0;
			int num13 = num6 ^ c;
			int num14 = num6 ^ num12;
			int num15 = num13 & num14;
			bool flag13 = num15 < 0;
			bool flag14 = flag11 == flag13;
			bool flag15 = !flag12;
			int num16 = ((!(flag14 && flag15)) ? num5 : num6);
			bool flag16 = flag11 == flag13;
			bool flag17 = !flag12;
			if (!(flag16 && flag17))
			{
				num5 = num6;
			}
			int num17 = num11 | num16;
			return num17 | num5;
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0x3C744B0", Offset = "0x3C744B0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = a - b;\n\tv5 = v4 < 0;\n\tv6 = v4 == 0;\n\tv7 = a ^ b;\n\tv8 = a ^ v4;\n\tv9 = v7 & v8;\n\tv10 = v9 < 0;\n\tv11 = v5 == v10;\n\tv12 = ~v6;\n\tv13 = v11 & v12;\n\tv14 = ~v13;\n\tif (v14) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv113 = a;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv113 = b;\nL_FFFFFFFF:\n\tv69 = a;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv69 = b;\nL_FFFFFFFF:\n\tv41 = c;\n\tgoto L_002C;\nL_FFFFFFFF:\n\tv41 = d;\nL_FFFFFFFF:\n\tv47 = c;\n\tgoto L_0036;\nL_FFFFFFFF:\n\tv47 = d;\nL_FFFFFFFF:\n\tv63 = v69;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv63 = v47;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv69 = v47;\nL_FFFFFFFF:\n\tv85 = v113;\n\tgoto L_0060;\nL_FFFFFFFF:\n\tv85 = v41;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv113 = v41;\nL_FFFFFFFF:\n\tv107 = v113;\n\tgoto L_007A;\nL_FFFFFFFF:\n\tv107 = v63;\n\tgoto L_0083;\nL_FFFFFFFF:\n\tv113 = v63;\nL_0012:\n\tv18 = v5 == v10;\n\tv19 = ~v18;\n\tv20 = ~v19;\n\tif (v20) goto L_FFFFFFFF;\nL_001C:\n\tv28 = c - d;\n\tv29 = v28 < 0;\n\tv30 = v28 == 0;\n\tv31 = c ^ d;\n\tv32 = c ^ v28;\n\tv33 = v31 & v32;\n\tv34 = v33 < 0;\n\tv35 = v29 == v34;\n\tv36 = ~v30;\n\tv37 = v35 & v36;\n\tv38 = ~v37;\n\tif (v38) goto L_FFFFFFFF;\nL_002C:\n\tv42 = v29 == v34;\n\tv43 = ~v42;\n\tv44 = ~v43;\n\tif (v44) goto L_FFFFFFFF;\nL_0036:\n\tv50 = v69 - v47;\n\tv51 = v50 < 0;\n\tv52 = v50 == 0;\n\tv53 = v69 ^ v47;\n\tv54 = v69 ^ v50;\n\tv55 = v53 & v54;\n\tv56 = v55 < 0;\n\tv57 = v51 == v56;\n\tv58 = ~v52;\n\tv59 = v57 & v58;\n\tv60 = ~v59;\n\tif (v60) goto L_FFFFFFFF;\nL_0046:\n\tv64 = v51 == v56;\n\tv65 = ~v64;\n\tv66 = ~v65;\n\tif (v66) goto L_FFFFFFFF;\nL_0050:\n\tv72 = v113 - v41;\n\tv73 = v72 < 0;\n\tv74 = v72 == 0;\n\tv75 = v113 ^ v41;\n\tv76 = v113 ^ v72;\n\tv77 = v75 & v76;\n\tv78 = v77 < 0;\n\tv79 = v73 == v78;\n\tv80 = ~v74;\n\tv81 = v79 & v80;\n\tv82 = ~v81;\n\tif (v82) goto L_FFFFFFFF;\nL_0060:\n\tv86 = v73 == v78;\n\tv87 = ~v86;\n\tv88 = ~v87;\n\tif (v88) goto L_FFFFFFFF;\nL_006A:\n\tv94 = v113 - v63;\n\tv95 = v94 < 0;\n\tv96 = v94 == 0;\n\tv97 = v113 ^ v63;\n\tv98 = v113 ^ v94;\n\tv99 = v97 & v98;\n\tv100 = v99 < 0;\n\tv101 = v95 == v100;\n\tv102 = ~v96;\n\tv103 = v101 & v102;\n\tv104 = ~v103;\n\tif (v104) goto L_FFFFFFFF;\nL_007A:\n\tv108 = v95 == v100;\n\tv109 = ~v108;\n\tv110 = ~v109;\n\tif (v110) goto L_FFFFFFFF;\nL_0083:\n\tv115 = v85 | v69;\n\tv116 = v115 | v113;\n\treturnVal1 = v116 | v107;\n\treturn returnVal1;\n")]
		public static long MakeKey4(int a, int b, int c, int d)
		{
			//IL_052d: Expected I8, but got I4
			int num = a - b;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = a ^ b;
			int num3 = a ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			int num5 = ((!(flag4 && flag5)) ? b : a);
			int num6 = ((flag == flag3) ? b : a);
			int num7 = c - d;
			bool flag6 = num7 < 0;
			bool flag7 = num7 == 0;
			int num8 = c ^ d;
			int num9 = c ^ num7;
			int num10 = num8 & num9;
			bool flag8 = num10 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			int num11 = ((!(flag9 && flag10)) ? d : c);
			int num12 = ((flag6 == flag8) ? d : c);
			int num13 = num6 - num12;
			bool flag11 = num13 < 0;
			bool flag12 = num13 == 0;
			int num14 = num6 ^ num12;
			int num15 = num6 ^ num13;
			int num16 = num14 & num15;
			bool flag13 = num16 < 0;
			bool flag14 = flag11 == flag13;
			bool flag15 = !flag12;
			int num17 = ((!(flag14 && flag15)) ? num12 : num6);
			if (flag11 == flag13)
			{
				num6 = num12;
			}
			int num18 = num5 - num11;
			bool flag16 = num18 < 0;
			bool flag17 = num18 == 0;
			int num19 = num5 ^ num11;
			int num20 = num5 ^ num18;
			int num21 = num19 & num20;
			bool flag18 = num21 < 0;
			bool flag19 = flag16 == flag18;
			bool flag20 = !flag17;
			int num22 = ((!(flag19 && flag20)) ? num11 : num5);
			if (flag16 == flag18)
			{
				num5 = num11;
			}
			int num23 = num5 - num17;
			bool flag21 = num23 < 0;
			bool flag22 = num23 == 0;
			int num24 = num5 ^ num17;
			int num25 = num5 ^ num23;
			int num26 = num24 & num25;
			bool flag23 = num26 < 0;
			bool flag24 = flag21 == flag23;
			bool flag25 = !flag22;
			int num27 = ((!(flag24 && flag25)) ? num17 : num5);
			if (flag21 == flag23)
			{
				num5 = num17;
			}
			int num28 = num22 | num6;
			int num29 = num28 | num5;
			return num29 | num27;
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x3C727B8", Offset = "0x3C727B8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int64, _game.BaseLayerSystems.EntitySystem.Core.EntityQuery>::.ctor(v48);\n\tthis._cache = v48;\n")]
		public QueryCache()
		{
			Dictionary<long, EntityQuery> cache = new Dictionary<long, EntityQuery>();
			_cache = cache;
		}
	}
}
