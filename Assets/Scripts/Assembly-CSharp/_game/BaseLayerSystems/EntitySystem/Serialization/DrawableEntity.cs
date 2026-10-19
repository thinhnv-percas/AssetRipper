using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.BaseLayerSystems.EntitySystem.Serialization
{
	[Serializable]
	[Token(Token = "0x2000067")]
	public class DrawableEntity
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000068")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000FD")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000FE")]
			public static Func<object, IEntityData> _003C_003E9__5_0;

			[Token(Token = "0x6000175")]
			[Address(RVA = "0x3C6EA98", Offset = "0x3C6EA98", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000176")]
			[Address(RVA = "0x3C6EAFC", Offset = "0x3C6EAFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal IEntityData _003CFromEntityFiltered_003Eb__5_0(object o)
			{
				if (o != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					IEntityData entityData = default(IEntityData);
					if (entityData != null)
					{
						return entityData;
					}
					return (IEntityData)new InvalidCastException();
				}
				return null;
			}
		}

		[SerializeReference]
		[JsonProperty]
		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x10")]
		internal List<IEntityData> m_components;

		[JsonIgnore]
		[Token(Token = "0x17000038")]
		public IList<IEntityData> Components
		{
			[Token(Token = "0x6000170")]
			[Address(RVA = "0x3C6E428", Offset = "0x3C6E428", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_components;\n")]
			get
			{
				return m_components;
			}
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x3C6E430", Offset = "0x3C6E430", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv155 = 0xB2A6000 + 0x6B8;\n\tv76 = System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>::GetEnumerator(this.m_components);\n\tv161 = v76._list;\nL_FFFFFFFF:\n\tv139 = v50;\n\tgoto L_0051;\nL_004E:\n\t_game.BaseLayerSystems.EntitySystem.IEntityData::Apply(v76.Current, &v139 @ stack_-38_v2 (_game.BaseLayerSystems.EntitySystem.EntityBuilder));\n\tv217 = v76.Current == 0;\n\tif (v217) goto L_0051;\n\tgoto L_004E;\nL_007F:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v161 @ stack_-50_v4 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>));\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv142 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv147 = v139;\n\treturn v147.Entity;\nL_008C:\n\tv176 = new System.NullReferenceException();\n\tgoto L_0098;\nL_0098:\n\tv225 = v142 != 1;\nL_FFFFFFFF:\n\tv253 = v176;\n\tif (v225) goto L_00A8;\n\tv263 = 0x8BF5BC4(v176, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv278 = 0x8BF5BF4(v263, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v161 @ stack_-50_v4 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>));\n\tv268 = *([v263 @ X0_v14]) == 0;\nL_FFFFFFFF:\n\tv123 = *([v263 @ X0_v14]);\nL_FFFFFFFF:\n\tv142 = *([v155 @ X20_v2 (_game.BaseLayerSystems.EntitySystem.Core.EntityManager)]);\n\tif (v268) goto L_FFFFFFFF;\n\tv267 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv123 = *([v263 @ X0_v14]);\nL_FFFFFFFF:\n\tv253 = v267;\n\treturn returnVal2;\nL_0026:\n\tv161 = 0;\n\tv50 = new _game.BaseLayerSystems.EntitySystem.EntityBuilder();\n\t_game.BaseLayerSystems.EntitySystem.EntityBuilder::.ctor(v50, v141);\n\tv61 = this.m_components == 0;\nL_FFFFFFFF:\n\tv139 = v50;\nL_FFFFFFFF:\n\tv147 = v50;\nL_FFFFFFFF:\n\tv155 = v141;\n\tif (v61) goto L_0081;\nL_0081:\n\tv157 = v147 == 0;\n\tif (v157) goto L_008C;\nL_0051:\n\tv214 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v161 @ stack_-50_v4 (System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>));\n\tv257 = v214 == 0;\n\tif (v257) goto L_007F;\nL_00A8:\n\tv271 = 0x3179AF0(&v123 @ stack_-60 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv280 = 0x8BF0368(v253, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v280, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Entity ToEntity(EntityManager em)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DrawableEntity::ToEntity");
			return default;
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x3C6E60C", Offset = "0x3C6E60C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity::FromEntityFiltered(entity, em, 0);\n\treturn returnVal1;\n")]
		public static DrawableEntity FromEntity(Entity entity, EntityManager em)
		{
			return FromEntityFiltered(entity, em, null);
		}

		[Token(Token = "0x6000173")]
		[Address(RVA = "0x3C6E614", Offset = "0x3C6E614", Length = "0x360")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv60.exclude = exclude;\n\tv126 = new _game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity();\n\tgoto L_0064;\n\tSystem.Object::.ctor(v126);\n\tgoto L_0083;\n\tv218.<>l__initialThreadId = v223;\n\tv218.<>4__this = em;\n\tv218.<>3__entity = entity;\n\tv229 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>::.ctor(v229);\n\tv126.m_components = v229;\n\tgoto L_00A3;\nL_00A3:\n\t;\n\tv244 = v242.<>9__5_0 == 0;\n\tv245 = ~v244;\n\tv252 = v242.<>9__5_0;\n\tif (v245) goto L_00CF;\n\tgoto L_00B6;\nL_00B6:\n\tgoto L_00BE;\nL_00CF:\n\tv273 = System.Linq.Enumerable::Select(v218, v252);\n\tv283 = v60.exclude == 0;\n\tv92 = v273;\n\tif (v283) goto L_00ED;\n\tv299 = new System.Func`2<_game.BaseLayerSystems.EntitySystem.IEntityData, System.Boolean>();\n\tSystem.Func`2<_game.BaseLayerSystems.EntitySystem.IEntityData, System.Boolean>::.ctor(v299, v60, Il2CppMethodInfo);\n\tv305 = System.Linq.Enumerable::Where(v273, v299);\n\tv92 = v305;\nL_00ED:\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>::AddRange(v126.m_components, v92);\n\treturn v126;\nL_0040:\n\tv60 = new _game.BaseLayerSystems.EntitySystem.Serialization.DrawableEntity+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v60);\nL_0064:\n\tv180 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>::.ctor(v180);\n\tv126.m_components = v180;\nL_0083:\n\tv218 = new _game.BaseLayerSystems.EntitySystem.Core.EntityManager+<GetAllComponents>d__38();\n\tSystem.Object::.ctor(v218);\n\tv218.<>1__state = -2;\n\tv223 = System.Environment::get_CurrentManagedThreadId();\nL_00BE:\n\tv291 = new System.Func`2<System.Object, _game.BaseLayerSystems.EntitySystem.IEntityData>();\n\tSystem.Func`2<System.Object, _game.BaseLayerSystems.EntitySystem.IEntityData>::.ctor(v291, v286.<>9, Il2CppMethodInfo);\n\tv314.<>9__5_0 = v291;\n\tv252 = v291;\n")]
		public static DrawableEntity FromEntityFiltered(Entity entity, EntityManager em, Func<IEntityData, bool> exclude)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DrawableEntity::FromEntityFiltered");
			return default;
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0x3C6E97C", Offset = "0x3C6E97C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>();\n\tSystem.Collections.Generic.List`1<_game.BaseLayerSystems.EntitySystem.IEntityData>::.ctor(v48);\n\tthis.m_components = v48;\n")]
		public DrawableEntity()
		{
			List<IEntityData> components = new List<IEntityData>();
			m_components = components;
		}
	}
}
