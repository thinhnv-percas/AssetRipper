using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.BaseLayerSystems.EntitySystem
{
	[Token(Token = "0x200005F")]
	public class EntityBuilder
	{
		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _manager;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x18")]
		private Entity _entity;

		[Token(Token = "0x17000034")]
		public Entity Entity
		{
			[Token(Token = "0x6000154")]
			[Address(RVA = "0x3C6D294", Offset = "0x3C6D294", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Entity;\n")]
			get
			{
				return _entity;
			}
		}

		[Token(Token = "0x6000152")]
		[Address(RVA = "0x3C6CEA8", Offset = "0x3C6CEA8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = manager == 0;\n\tif (v15) goto L_001D;\n\tthis._manager = manager;\n\tv50 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::CreateEntity(manager);\n\tthis.Entity = v50;\n\treturn;\nL_001D:\n\tv18 = 0xB28B000 + 0x600;\n\tv48 = new v18();\n\tv52 = 0xB30D000 + 0x388;\n\tSystem.ArgumentNullException::.ctor(v48, v52);\n\tthrow v48;\n")]
		public EntityBuilder(EntityManager manager)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityBuilder::.ctor");
		}

		[Token(Token = "0x6000153")]
		[Address(RVA = "0x3C6D0C4", Offset = "0x3C6D0C4", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tthis._manager = manager;\n\tgoto L_002D;\nL_002D:\n\tv169 = 0xB28D000 + 0xE20;\n\tv82 = *([B78D6F1]) & 1;\n\tv83 = v82 == 0;\n\tif (v83) goto L_005A;\n\tv171 = *([v169 @ X22_v13 (System.Int32)]);\n\tv173 = *([v171 @ X0_v36+E4]) == 0;\n\tif (v173) goto L_006C;\nL_0040:\n\tv207 = entity <= 0;\n\tif (v207) goto L_006F;\nL_0042:\n\tthis.Entity = entity;\n\treturn;\nL_005A:\n\t*([B78D6F1]) = 1;\n\tv190 = *([v169 @ X22_v13 (System.Int32)]);\n\tv215 = *([v190 @ X0_v31+E4]) == 0;\n\tv192 = ~v215;\n\tif (v192) goto L_0040;\nL_006C:\n\tv218 = entity > 0;\n\tif (v218) goto L_0042;\nL_006F:\n\tv138 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::CreateEntity(manager);\n\tthis.Entity = v138;\n\treturn;\nL_007C:\n\tv53 = 0xB28B000 + 0x600;\n\tv71 = new v53();\n\tv76 = 0xB30D000 + 0x388;\n\tSystem.ArgumentNullException::.ctor(v71, v76);\n\tthrow v71;\nL_001A:\n\tSystem.Object::.ctor(this);\n\tv50 = manager == 0;\n\tif (v50) goto L_007C;\n")]
		public EntityBuilder(EntityManager manager, Entity entity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityBuilder::.ctor");
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0x48C343C", Offset = "0x48C343C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = 0x220C2B8(methodInfo, component, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0017:\n\tv44 = component & 0xFF;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::AddComponent(this._manager, this.Entity, v44);\n\treturn this;\n")]
		public EntityBuilder With<T>(T component) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EntityBuilder::With");
			return default;
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0x3C6D29C", Offset = "0x3C6D29C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Entity;\n")]
		public Entity Build()
		{
			return Entity;
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x3C6D2A4", Offset = "0x3C6D2A4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn builder.Entity;\n")]
		public static implicit operator Entity(EntityBuilder builder)
		{
			return builder.Entity;
		}
	}
}
