using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Morpeh
{
	[Token(Token = "0x2000015")]
	public class EntityProvider : MonoBehaviour
	{
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x18")]
		private Entity entity;

		[CanBeNull]
		[Token(Token = "0x17000009")]
		public IEntity Entity
		{
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x15F5F34", Offset = "0x15F5F34", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Morpeh.EntityProvider::IsPrefab(this);\n\tv13 = v10 == 0;\n\tif (v13) goto L_000D;\n\tgoto L_0018;\nL_000D:\n\tv16 = UnityEngine.Application::get_isPlaying();\n\tv21 = v16 == 0;\n\tif (v21) goto L_0018;\nL_0018:\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				IEntity result;
				if (IsPrefab())
				{
					result = null;
				}
				else
				{
					bool isPlaying = Application.isPlaying;
					bool flag = !isPlaying;
					result = null;
					if (!flag)
					{
						result = entity;
					}
				}
				return result;
			}
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x15F5FC4", Offset = "0x15F5FC4", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F01CD0]);\n\tv21 = *([v20 @ X8_v30]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A043]) = v40;\nL_0015:\n\tv42 = 0;\n\tv43 = UnityEngine.Application::get_isPlaying();\n\tv45 = v43 == 0;\n\tif (v45) goto L_008E;\n\tv47 = this.entity == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_0082;\n\tgoto L_002E;\n\tv175 = *([v103 @ X0_v10+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_002E;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v103, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002E:\n\tgoto L_0039;\n\tv186 = *([1EDD170]);\n\tv187 = *([v186 @ X8_v25]);\n\tv188 = \"il2cpp_codegen_initialize_method\"(v187, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv191 = 0 | 1;\n\t*([2021C3B]) = v191;\nL_0039:\n\tgoto L_0045;\n\tv196 = *([v192 @ X0_v13 (Il2CppClass<Morpeh.World>)+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\t// 61 Jump @b34\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v192, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv200 = Morpeh.World;\nL_0045:\n\tv208 = Morpeh.World::CreateEntityInternal(v203.<Default>k__BackingField, &v42 @ stack_-24_v1 (System.Int32));\n\tv124 = UnityEngine.Component::GetComponents(this);\n\tv264 = v124.Length;\n\tv242 = v124.Length < 1;\n\tif (v242) goto L_0082;\nL_005D:\n\tv269 = v227 < v264;\n\tv219 = ~v269;\n\tif (v219) goto L_008F;\n\tv271 = v124[v227 @ X8_v21 (System.Int32)];\n\tv271.entity = v208;\n\tv264 = v124.Length;\n\tv227 = v227 + 1;\n\tv247 = v227 < v124.Length;\n\tif (v247) goto L_005D;\n\tgoto L_0082;\nL_0082:\n\tv133 = Morpeh.EntityProvider::PreInitialize(this);\n\tv89 = Morpeh.EntityProvider::Initialize(this);\nL_008E:\n\treturn;\nL_008F:\n\tv272 = new System.IndexOutOfRangeException();\n\tthrow v272;\n\tv224 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private protected virtual void Awake()
		{
			int id = 0;
			if (!Application.isPlaying)
			{
				return;
			}
			if (this.entity == null)
			{
				Entity entity = World.Default.CreateEntityInternal(out id);
				EntityProvider[] components = GetComponents<EntityProvider>();
				int num = components.Length;
				if (components.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							EntityProvider entityProvider = components[num2];
							entityProvider.entity = entity;
							num = components.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < components.Length);
				}
			}
			PreInitialize();
			Initialize();
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x15F6280", Offset = "0x15F6280", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EFDC68]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A044]) = v40;\nL_0015:\n\tv42 = this.entity == 0;\n\tif (v42) goto L_0079;\n\tgoto L_0027;\n\tv98 = *([v45 @ X0_v3+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0027;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tgoto L_0032;\n\tv146 = *([1EDD170]);\n\tv147 = *([v146 @ X8_v21]);\n\tv148 = \"il2cpp_codegen_initialize_method\"(v147, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv151 = 0 | 1;\n\t*([2021C3B]) = v151;\nL_0032:\n\tgoto L_003E;\n\tv156 = *([v152 @ X0_v6 (Il2CppClass<Morpeh.World>)+E0]);\n\tv157 = v156 == 0;\n\tv158 = ~v157;\n\t// 54 Jump @b29\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v152, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv160 = Morpeh.World;\nL_003E:\n\tMorpeh.World::RemoveEntity(v163.<Default>k__BackingField, this.entity);\n\tv87 = UnityEngine.Component::GetComponents(this);\n\tv224 = v87.Length;\n\tv200 = v87.Length < 1;\n\tif (v200) goto L_0072;\nL_0054:\n\tv226 = v185 < v224;\n\tv178 = ~v226;\n\tif (v178) goto L_007A;\n\tv228 = v87[v185 @ X8_v17 (System.Int32)];\n\tv228.entity = 0;\n\tv224 = v87.Length;\n\tv185 = v185 + 1;\n\tv203 = v185 < v87.Length;\n\tif (v203) goto L_0054;\nL_0072:\n\tthis.entity = 0;\nL_0079:\n\treturn;\nL_007A:\n\tv229 = new System.IndexOutOfRangeException();\n\tthrow v229;\n\tv182 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void OnDestroy()
		{
			if (entity == null)
			{
				return;
			}
			World.Default.RemoveEntity(entity);
			EntityProvider[] components = GetComponents<EntityProvider>();
			int num = components.Length;
			if (components.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						EntityProvider entityProvider = components[num2];
						entityProvider.entity = null;
						num = components.Length;
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < components.Length);
			}
			entity = null;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x15F5F78", Offset = "0x15F5F78", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = UnityEngine.Component::get_gameObject(this);\n\tv12 = UnityEngine.GameObject::get_scene(v8);\n\tthis = 0x10D454C(&v12 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27);\n\tv38 = this == 0;\n\treturn v38;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool IsPrefab()
		{
			GameObject gameObject = base.gameObject;
			Scene scene = gameObject.scene;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
			return (object)this == null;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x15F6484", Offset = "0x15F6484", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void PreInitialize()
		{
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x15F6488", Offset = "0x15F6488", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected virtual void Initialize()
		{
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x15F648C", Offset = "0x15F648C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EntityProvider()
		{
		}
	}
}
