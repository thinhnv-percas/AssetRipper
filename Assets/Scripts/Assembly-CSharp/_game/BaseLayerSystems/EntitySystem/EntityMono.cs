using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.BaseLayerSystems.EntitySystem
{
	[SelectionBase]
	[Token(Token = "0x2000060")]
	public class EntityMono : MonoBehaviour
	{
		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x20")]
		private Entity _entity;

		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x28")]
		private bool _isBound;

		[Token(Token = "0x17000035")]
		public Entity Entity
		{
			[Token(Token = "0x6000158")]
			[Address(RVA = "0x3C6D2BC", Offset = "0x3C6D2BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Entity;\n")]
			get
			{
				return _entity;
			}
		}

		[Token(Token = "0x17000036")]
		public EntityId EntityId
		{
			[Token(Token = "0x6000159")]
			[Address(RVA = "0x3C6D2C4", Offset = "0x3C6D2C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Entity;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EntityMono::get_EntityId");
				return default;
			}
		}

		[Token(Token = "0x17000037")]
		public bool IsBound
		{
			[Token(Token = "0x600015A")]
			[Address(RVA = "0x3C6D2CC", Offset = "0x3C6D2CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsBound;\n")]
			get
			{
				return _isBound;
			}
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x3C6D2D4", Offset = "0x3C6D2D4", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv118 = v53.Length;\n\tv69 = v53.Length < 1;\n\tif (v69) goto L_007D;\n\tv148 = 0;\n\tgoto L_004D;\nL_003E:\n\t_game.BaseLayerSystems.EntitySystem.IEntityComponentMono::Init(v53[v148 @ X22_v5 (System.Int32)], this);\n\tv118 = v53.Length;\nL_004D:\n\tv149 = v53[v148 @ X22_v5 (System.Int32)] == 0;\n\tif (v149) goto L_0040;\n\tgoto L_003E;\nL_007D:\n\treturn;\nL_001C:\n\tthis.Entity = entity;\n\tthis.IsBound = 1;\n\tv53 = UnityEngine.Component::GetComponents(this);\nL_0040:\n\tv148 = v148 + 1;\n\tv94 = v148 >= v118;\n\tif (v94) goto L_007D;\n")]
		public void OnBind(Entity entity)
		{
			_entity = entity;
			_isBound = true;
			IEntityComponentMono[] components = GetComponents<IEntityComponentMono>();
			int num = components.Length;
			if (components.Length < 1)
			{
				return;
			}
			int num2 = 0;
			do
			{
				if (components[num2] != null)
				{
					components[num2].Init(this);
					num = components.Length;
				}
				num2++;
			}
			while (num2 < num);
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x3C6D3F4", Offset = "0x3C6D3F4", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0047;\n\treturn;\nL_0047:\n\tv96 = UnityEngine.Component::GetComponents(this);\n\tv219 = v96.Length;\n\tv186 = v96.Length < 1;\n\tif (v186) goto L_00B1;\nL_FFFFFFFF:\n\tv239 = 0;\nL_FFFFFFFF:\n\tv217 = 0;\n\tgoto L_007D;\nL_0065:\n\t_game.BaseLayerSystems.EntitySystem.IEntityComponentMono::DeInit(v217, this);\n\tv219 = v96.Length;\nL_007D:\n\tv195 = v96[v239 @ X22_v4 (System.Int32)] != 0;\n\tif (v195) goto L_FFFFFFFF;\n\tgoto L_0083;\nL_FFFFFFFF:\n\tv217 = v96[v239 @ X22_v4 (System.Int32)];\n\tgoto L_0065;\nL_00B1:\n\tgoto L_00B6;\nL_0083:\n\tv261 = v96[v239 @ X22_v4 (System.Int32)] == 0;\n\tif (v261) goto L_0067;\nL_00B6:\n\tthis.Entity = v258.Invalid;\n\tthis.IsBound = 0;\n\treturn;\nL_0067:\n\tv239 = v239 + 1;\n\tv197 = v239 >= v219;\n\tif (v197) goto L_00B1;\n")]
		public void OnUnbind()
		{
			if (this == null)
			{
				return;
			}
			IEntityComponentMono[] components = GetComponents<IEntityComponentMono>();
			int num = components.Length;
			if (components.Length >= 1)
			{
				int num2 = 0;
				IEntityComponentMono entityComponentMono = null;
				do
				{
					if (components[num2] != null)
					{
						entityComponentMono = components[num2];
					}
					if (components[num2] != null)
					{
						entityComponentMono.DeInit(this);
						num = components.Length;
					}
					num2++;
				}
				while (num2 < num);
			}
			_entity = Entity.Invalid;
			_isBound = false;
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x3C6D5B8", Offset = "0x3C6D5B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void OnDestroy()
		{
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x3C6D5BC", Offset = "0x3C6D5BC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = this.IsBound != 1;\n\tif (v25) goto L_004C;\n\tgoto L_0026;\n\t_game.BaseLayerSystems.EntitySystem.Core.EntityManager::DestroyEntity(v78._entityManager, this.Entity);\nL_0030:\n\tgoto L_0039;\n\t_game.BaseLayerSystems.EntitySystem.Core.MonoBindingManager::Unbind(v50._monoBindingManager, this.Entity);\n\treturn;\nL_004C:\n\treturn;\nL_0026:\n\tv80 = v78._entityManager == 0;\n\tif (v80) goto L_0030;\nL_0039:\n\tv42 = v50._monoBindingManager == 0;\n\tif (v42) goto L_004C;\n")]
		public void OnDestroy_Custom()
		{
			if (IsBound)
			{
				if (EntityExtensions._entityManager != null)
				{
					EntityExtensions._entityManager.DestroyEntity(Entity);
				}
				if (EntityExtensions._monoBindingManager != null)
				{
					EntityExtensions._monoBindingManager.Unbind(Entity);
				}
			}
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x3C6D758", Offset = "0x3C6D758", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public EntityMono()
		{
		}
	}
}
