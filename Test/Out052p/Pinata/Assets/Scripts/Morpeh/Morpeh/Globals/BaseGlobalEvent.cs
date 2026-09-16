using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals.ECS;
using UnityEngine;

namespace Morpeh.Globals
{
	[Token(Token = "0x200001C")]
	public abstract class BaseGlobalEvent<TData> : ScriptableObject, IDisposable
	{
		[Token(Token = "0x2000040")]
		private class Unsubscriber : IDisposable
		{
			[Token(Token = "0x4000077")]
			[FieldOffset(Offset = "0x0")]
			private readonly Action unsubscribe;

			[Token(Token = "0x6000105")]
			[Address(RVA = "0x1098E1C", Offset = "0x1098E1C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.unsubscribe = unsubscribe;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Unsubscriber(Action unsubscribe)
			{
				this.unsubscribe = unsubscribe;
			}

			[Token(Token = "0x6000106")]
			[Address(RVA = "0x1098E54", Offset = "0x1098E54", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Action::Invoke(this.unsubscribe);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Dispose()
			{
				unsubscribe();
			}
		}

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x0")]
		private Entity internalEntity;

		[Token(Token = "0x17000011")]
		public IEntity Entity
		{
			[Token(Token = "0x600008C")]
			[Address(RVA = "0x1098FC0", Offset = "0x1098FC0", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\treturn this.internalEntity;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				CheckIsInitialized();
				return internalEntity;
			}
		}

		[Token(Token = "0x17000012")]
		public bool IsPublished
		{
			[Token(Token = "0x600008D")]
			[Address(RVA = "0x1099000", Offset = "0x1099000", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EC60F0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026AD3]) = v41;\nL_001C:\n\tv48 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\treturnVal1 = Morpeh.Entity::Has(this.internalEntity);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				CheckIsInitialized();
				return internalEntity.Has<GlobalEventPublished>();
			}
		}

		[Token(Token = "0x17000013")]
		public List<TData> BatchedChanges
		{
			[Token(Token = "0x600008E")]
			[Address(RVA = "0x109AA7C", Offset = "0x109AA7C", Length = "0x60")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\tv47 = Morpeh.Entity::GetComponent(this.internalEntity);\n\treturn *([v47 @ X0_v6 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)+8]);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0027: Expected O, but got I
				CheckIsInitialized();
				ref GlobalEventComponent<TData> component = ref internalEntity.GetComponent<GlobalEventComponent<TData>>();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v6 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)+8]");
				return (List<TData>)0;
			}
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x10990E4", Offset = "0x10990E4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.internalEntity = 0;\n\treturn;\n")]
		protected internal virtual void OnEnable()
		{
			internalEntity = null;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x10990EC", Offset = "0x10990EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.internalEntity = 0;\n\treturn;\n")]
		protected internal virtual void OnDisable()
		{
			internalEntity = null;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x10990F4", Offset = "0x10990F4", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB7C18]);\n\tv25 = *([v24 @ X8_v50]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026AD4]) = v43;\nL_0019:\n\tv47 = this.internalEntity == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_00BE;\n\tgoto L_002C;\n\tv96 = *([v51 @ X0_v3+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_002C;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002C:\n\tgoto L_0037;\n\tv135 = *([1EC78B0]);\n\tv136 = *([v135 @ X8_v45]);\n\tv137 = \"il2cpp_codegen_initialize_method\"(v136, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv140 = 0 | 1;\n\t*([2021C3B]) = v140;\nL_0037:\n\tgoto L_0043;\n\tv145 = *([v141 @ X0_v6 (Il2CppClass<Morpeh.World>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\t// 59 Jump @b42\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v141, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv149 = Morpeh.World;\nL_0043:\n\tv157 = Morpeh.World::CreateEntityInternal(v152.<Default>k__BackingField);\n\tthis.internalEntity = v157;\n\tv185 = Morpeh.Entity::AddComponent(v157);\n\tv67 = 0;\n\tgoto L_0059;\n\tv194 = v189;\n\tv195 = Morpeh.Entity::AddComponent(v194, v184);\nL_0059:\n\tv198 = new Il2CppClass<System.Collections.Generic.List`1<TData>>();\n\tv168 = System.Collections.Generic.List`1<TData>::.ctor(v198);\n\tv205 = Morpeh.Entity::SetComponent(this.internalEntity, &v67 @ stack_-40_v4 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>));\n\tgoto L_0076;\n\tv212 = v89;\n\tv213 = Morpeh.Entity::SetComponent(v212, v70, v63);\nL_0076:\n\tv215 = ~v214.Initialized;\n\tv79 = ~v215;\n\tif (v79) goto L_00BE;\n\tgoto L_0086;\n\tv221 = *([v217 @ X0_v23 (Il2CppClass<Morpeh.Globals.ECS.GlobalEventComponentUpdater>)+E0]);\n\tv222 = v221 == 0;\n\tv223 = ~v222;\n\tif (v223) goto L_0086;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v217, v70, v63, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv224 = Morpeh.Globals.ECS.GlobalEventComponentUpdater;\nL_0086:\n\tv178 = this.internalEntity;\n\tv176 = v178.World;\n\tgoto L_009A;\n\tv234 = v230;\n\tv235 = Morpeh.Entity::SetComponent(v234, v70, v63);\nL_009A:\n\tv238 = new Il2CppClass<Morpeh.Globals.ECS.GlobalEventComponentUpdater`1<TData>>();\n\tv170 = Morpeh.Globals.ECS.GlobalEventComponentUpdater`1<TData>::.ctor(v238, v176.Filter);\n\tSystem.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::Add(v56.Updaters, v238);\n\tgoto L_00B6;\n\tv249 = v83;\n\tv250 = System.Collections.Generic.List`1<Morpeh.Globals.ECS.GlobalEventComponentUpdater>::Add(v249, v69, v62);\nL_00B6:\n\tv85.Initialized = 1;\nL_00BE:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void CheckIsInitialized()
		{
			if (internalEntity == null)
			{
				ref GlobalEventMarker reference = ref (internalEntity = World.Default.CreateEntityInternal()).AddComponent<GlobalEventMarker>();
				GlobalEventComponent<TData> value = default(GlobalEventComponent<TData>);
				List<TData> list = new List<TData>();
				internalEntity.SetComponent(in value);
				if (!GlobalEventComponent<TData>.Initialized)
				{
					Entity entity = internalEntity;
					World world = entity.World;
					GlobalEventComponentUpdater item = new GlobalEventComponentUpdater<TData>(world.Filter);
					GlobalEventComponentUpdater.Updaters.Add(item);
					GlobalEventComponent<TData>.Initialized = true;
				}
			}
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x1099340", Offset = "0x1099340", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED2E78]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, data, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026AD5]) = v44;\nL_0017:\n\tv45 = 0;\n\tv53 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\tv62 = Morpeh.Entity::GetComponent(this.internalEntity, &v45 @ stack_-34_v1 (System.Boolean));\n\tv80 = System.Collections.Generic.List`1<TData>::Add(*([v62 @ X0_v8 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)+8]), data);\n\tv66 = 0;\n\tv85 = Morpeh.Entity::SetComponent(this.internalEntity, &v66 @ stack_-38_v3 (Morpeh.Globals.ECS.GlobalEventPublished));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Publish(TData data)
		{
			//IL_003d: Expected O, but got I
			bool exist = false;
			CheckIsInitialized();
			ref GlobalEventComponent<TData> component = ref internalEntity.GetComponent<GlobalEventComponent<TData>>(out exist);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v8 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)+8]");
			((List<TData>)0).Add(data);
			internalEntity.SetComponent<GlobalEventPublished>(default(GlobalEventPublished));
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x1099424", Offset = "0x1099424", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB2120]);\n\tv27 = *([v26 @ X8_v17]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, data, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026AD6]) = v44;\nL_0017:\n\tv45 = 0;\n\tv53 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\tv62 = Morpeh.Entity::GetComponent(this.internalEntity, &v45 @ stack_-34_v1 (System.Boolean));\n\tv80 = System.Collections.Generic.List`1<TData>::Add(*([v62 @ X0_v8 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)+8]), data);\n\tv66 = 0;\n\tv85 = Morpeh.Entity::SetComponent(this.internalEntity, &v66 @ stack_-38_v3 (Morpeh.Globals.ECS.GlobalEventNextFrame));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void NextFrame(TData data)
		{
			//IL_003d: Expected O, but got I
			bool exist = false;
			CheckIsInitialized();
			ref GlobalEventComponent<TData> component = ref internalEntity.GetComponent<GlobalEventComponent<TData>>(out exist);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X0_v8 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)+8]");
			((List<TData>)0).Add(data);
			internalEntity.SetComponent<GlobalEventNextFrame>(default(GlobalEventNextFrame));
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x1099508", Offset = "0x1099508", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F07240]);\n\tv31 = *([v30 @ X8_v32]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, callback, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2026AD7]) = v48;\nL_0019:\n\tv49 = 0;\n\tgoto L_0025;\n\tv57 = v52;\n\tv58 = 0x8907BC(v57, callback, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0025:\n\tv61 = new Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1<TData>+<>c__DisplayClass12_0<TData>>();\n\tv67 = Morpeh.Globals.BaseGlobalEvent`1<TData>+<>c__DisplayClass12_0<TData>::.ctor(v61);\n\tv61.callback = callback;\n\tv77 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\tv90 = Morpeh.Entity::GetComponent(this.internalEntity, &v49 @ stack_-44_v1 (System.Boolean));\n\tv95 = System.Delegate::Combine(*([v90 @ X0_v12 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)]), v61.callback);\n\tgoto L_0050;\n\tv132 = v99;\n\tv133 = 0x8907BC(v132, v93, v94, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0050:\n\tv135 = v95 == 0;\n\tif (v135) goto L_FFFFFFFF;\n\t// 84 IsInst v148 @ X0_v16 (System.Int32), typeof(System.Action`1<System.Collections.Generic.IEnumerable`1<TData>>), v95 @ X0_v14 (System.Delegate)\n\tv146 = v148 == 0;\n\tv144 = ~v146;\n\tif (v144) goto L_005C;\n\tthrow System.InvalidCastException;\nL_005C:\n\t*([v90 @ X0_v12 (Morpeh.Globals.ECS.GlobalEventComponent`1<TData>&)]) = v148;\n\tv61.ent = this.internalEntity;\n\tv154 = new System.Action();\n\tSystem.Action::.ctor(v154, v61, Il2CppMethodInfo);\n\tgoto L_0075;\n\tv167 = v163;\n\tv168 = 0x8907BC(v167, v157, v160, v107, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0075:\n\tv171 = new Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1<TData>+Unsubscriber<TData>>();\n\tv175 = Morpeh.Globals.BaseGlobalEvent`1<TData>+Unsubscriber<TData>::.ctor(v171, v154);\n\treturn v171;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe IDisposable Subscribe(Action<IEnumerable<TData>> callback)
		{
			//IL_008e: Expected I4, but got O
			bool exist = false;
			CheckIsInitialized();
			Delegate obj = Delegate.Combine((Delegate)internalEntity.GetComponent<GlobalEventComponent<TData>>(out exist), callback);
			int num;
			if (obj != null)
			{
				num = (int)(obj as Action<IEnumerable<TData>>);
				if (num == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				num = 0;
			}
			ref GlobalEventComponent<TData> reference = ref *(GlobalEventComponent<TData>*)num;
			Entity ent = internalEntity;
			Action unsubscribe = delegate
			{
				//IL_0082: Expected I4, but got O
				bool exist2 = false;
				if (ent != null)
				{
					Delegate obj2 = Delegate.Remove((Delegate)ent.GetComponent<GlobalEventComponent<TData>>(out exist2), callback);
					int num2;
					if (obj2 != null)
					{
						num2 = (int)(obj2 as Action<IEnumerable<TData>>);
						if (num2 == 0)
						{
							throw new InvalidCastException();
						}
					}
					else
					{
						num2 = 0;
					}
					ref GlobalEventComponent<TData> reference2 = ref *(GlobalEventComponent<TData>*)num2;
				}
			};
			return new Unsubscriber(unsubscribe);
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x10996C8", Offset = "0x10996C8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1>;\n\tgoto L_0018;\n\tv40 = v19;\n\tv41 = 0x8907BC(v40, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv44 = Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1>;\n\tv46 = *([v44 @ X20_v4 (Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1>)+12E]);\nL_0018:\n\tv48 = Il2CppMethodInfo;\n\tv50 = *([v19 @ X21_v1 (Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1>)+12E]) & 1;\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_002C;\n\tv55 = 0x8907BC(Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1>, methodInfo, *([v48 @ X9_v2 (Il2CppMethodInfo)]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\t// 44 IndirectJump [v48 @ X9_v2 (Il2CppMethodInfo)], exists @ X0 (Morpeh.Globals.BaseGlobalEvent`1<TData>), exists @ X0 (Morpeh.Globals.BaseGlobalEvent`1<TData>), methodof(Morpeh.Globals.BaseGlobalEvent`1<TData>::get_IsPublished), [v48 @ X9_v2 (Il2CppMethodInfo)], v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static implicit operator bool(BaseGlobalEvent<TData> exists)
		{
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X21_v1 (Il2CppClass<Morpeh.Globals.BaseGlobalEvent`1>)+12E]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v48 @ X9_v2 (Il2CppMethodInfo)] (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x109974C", Offset = "0x109974C", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ECD3E8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026AD8]) = v40;\nL_0015:\n\tv42 = this.internalEntity == 0;\n\tif (v42) goto L_004F;\n\tMorpeh.Entity::Dispose(this.internalEntity);\n\tgoto L_0029;\n\tv77 = *([v51 @ X0_v3+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0029;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v51, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\tgoto L_0034;\n\tv88 = *([1EC78B0]);\n\tv89 = *([v88 @ X8_v12]);\n\tv90 = \"il2cpp_codegen_initialize_method\"(v89, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv93 = 0 | 1;\n\t*([2021C3B]) = v93;\nL_0034:\n\tgoto L_0047;\n\tv98 = *([v94 @ X0_v6 (Il2CppClass<Morpeh.World>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\t// 56 Jump @b22\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v94, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv102 = Morpeh.World;\nL_0047:\n\tMorpeh.World::RemoveEntity(v72.<Default>k__BackingField, this.internalEntity);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (internalEntity != null)
			{
				internalEntity.Dispose();
				World.Default.RemoveEntity(internalEntity);
			}
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x109982C", Offset = "0x109982C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X2_v1, this @ X0 (Morpeh.Globals.BaseGlobalEvent`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalEvent`1<TData>), methodof(Morpeh.Globals.BaseGlobalEvent`1<TData>::Dispose), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x1099850", Offset = "0x1099850", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal BaseGlobalEvent()
		{
		}
	}
}
