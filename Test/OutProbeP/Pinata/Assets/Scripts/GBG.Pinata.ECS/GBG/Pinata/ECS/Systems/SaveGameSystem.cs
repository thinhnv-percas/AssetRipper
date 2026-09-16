using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using Morpeh.Hypercasual;
using UnityEngine;

namespace GBG.Pinata.ECS.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000070")]
	public class SaveGameSystem : UpdateSystem
	{
		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x28")]
		private IEntity levelEntity;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x30")]
		private GameConfig config;

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xCC69C0", Offset = "0xCC69C0", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v10;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			GameConfig instance = GameConfig.Instance;
			config = instance;
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xCC69E4", Offset = "0xCC69E4", Length = "0x3F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EB9E30]);\n\tv27 = *([v26 @ X8_v53]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, deltaTime, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202376D]) = v46;\nL_001C:\n\tv52 = this.config;\n\tv171 = System.Collections.Generic.Dictionary`2<System.String, Morpeh.Globals.GlobalVariableInt>::get_Item(v52.GlobalIntegers, \"Level\");\n\tv257 = this.levelEntity == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_00E7;\n\tv242 = Morpeh.FilterProvider::get_All(this.filter);\n\tv243 = Morpeh.Filter::With(v242, 1);\n\tv488 = Morpeh.Filter::GetEnumerator(v243);\n\tv495 = v488.world;\nL_004F:\n\tv547 = Morpeh.Filter::With(&v495 @ stack_-90_v8 (Morpeh.World), 0);\n\tv556 = v547 & 1;\n\tv557 = v556 == 0;\n\tif (v557) goto L_00B8;\n\tv597 = Il2CppMethodInfo;\n\tv598 = *([v562 @ stack_-58 (Morpeh.IEntity)]);\n\tv602 = *([v598 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v602) goto L_0079;\n\tv698 = *([v598 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0065:\n\tv703 = *([v698 @ X11_v21-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v703) goto L_007C;\n\tv697 = v697 + 1;\n\tv729 = v697 < *([v598 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv633 = ~v729;\n\tv698 = v698 + 0x10;\n\tv617 = ~v633;\n\tif (v617) goto L_0065;\nL_0079:\n\tthis = 0x8909C4(v562, Il2CppClass<Morpeh.IEntity>, *([v597 @ X22_v14 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v488.ids, v495, v38, v39, v40, v41, v42, v43);\n\tgoto L_0082;\nL_007C:\n\tv731 = *([v698 @ X11_v21]) + *([v597 @ X22_v14 (Il2CppMethodInfo)+48]);\n\tv732 = v731 << 4;\n\tv52 = v598 + v732;\n\tthis = v52 + 0x130;\nL_0082:\n\tv740 = Morpeh.IEntity::GetComponent(*([this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]));\n\t*([v740 @ X0_v61 (Morpeh.Hypercasual.SaveIntComponent&)])(this, v562, v740, *([v597 @ X22_v14 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v488.ids, v495, v38, v39, v40, v41, v42, v43);\n\tv540 = System.String::op_Equality(*([this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)]), \"Level\");\n\tv542 = v540 == 0;\n\tif (v542) goto L_004F;\n\tthis.levelEntity = v562;\n\tv52 = *([this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]);\n\t// 151 Box v766 @ X0_v67 (System.Object), typeof(System.Int32), &v52 @ X8_v3 (GBG.Pinata.ECS.GameConfig)\n\tv772 = System.String::Concat(\"LOAD \", v766);\n\tgoto L_00AD;\n\tv780 = *([v776 @ X0_v70+E0]);\n\tv781 = v780 == 0;\n\tv782 = ~v781;\n\tif (v782) goto L_00AD;\n\tv784 = \"il2cpp_codegen_runtime_class_init\"(v776, v768, v649, v31, v32, v33, v34, v35, v213, v215, v38, v39, v40, v41, v42, v43);\nL_00AD:\n\tUnityEngine.Debug::Log(v772);\n\tv591 = v171 == 0;\n\tif (v591) goto L_00BD;\n\tMorpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(v171, *([this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]));\nL_00B8:\n\tthis = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::set_Value(&v495 @ stack_-90_v8 (Morpeh.World), 0);\n\tgoto L_00DA;\n\tthrow System.NullReferenceException;\nL_00BD:\n\tv313 = new System.NullReferenceException();\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\n\tgoto L_00CE;\nL_00CE:\n\tv266 = 0 != 1;\n\tif (v266) goto L_015D;\n\tv758 = Morpeh.Filter::With(v313, 0);\n\tv761 = Morpeh.Filter::With(v758, 0);\n\tv368 = Morpeh.Filter::With(&v495 @ stack_-90_v8 (Morpeh.World), 0);\n\tv773 = *([v758 @ X0_v53 (Morpeh.Filter)]) == 0;\n\tv370 = ~v773;\n\tif (v370) goto L_0161;\nL_00DA:\n\tv657 = this.levelEntity == 0;\n\tv327 = ~v657;\n\tif (v327) goto L_00E7;\n\tv324 = Morpeh.World::CreateEntity(this.world);\n\tthis.levelEntity = v324;\nL_00E7:\n\tv153 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(v171);\n\tv379 = v153 == 0;\n\tif (v379) goto L_015A;\n\tv479 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v171);\n\t// 248 Box v485 @ X0_v20 (System.Object), typeof(System.Int32), &v479 @ X0_v18 (System.Int32)\n\tv494 = System.String::Concat(\"SAVE \", v485);\n\tgoto L_0110;\n\tv548 = *([v499 @ X8_v23+E0]);\n\tv549 = v548 == 0;\n\tv550 = ~v549;\n\tif (v550) goto L_0110;\n\tv558 = v499;\n\tv552 = \"il2cpp_codegen_runtime_class_init\"(v558, v491, v146, v31, v32, v33, v34, v35, v116, v118, v38, v39, v40, v41, v42, v43);\nL_0110:\n\tUnityEngine.Debug::Log(v494);\n\tv159 = this.levelEntity;\n\tv62 = \"Level\";\n\tv154 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(v171);\n\tv607 = *([v159 @ X19_v8 (Morpeh.IEntity)]);\n\tv425 = Il2CppMethodInfo;\n\tv420 = *([v607 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v420) goto L_0141;\n\tv719 = *([v607 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_012D:\n\tv724 = *([v719 @ X11_v11-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v724) goto L_0144;\n\tv718 = v718 + 1;\n\tv742 = v718 < *([v607 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv680 = ~v742;\n\tv719 = v719 + 0x10;\n\tv664 = ~v680;\n\tif (v664) goto L_012D;\nL_0141:\n\tthis = 0x8909C4(v159, Il2CppClass<Morpeh.IEntity>, *([v425 @ X20_v9 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v116, v118, v38, v39, v40, v41, v42, v43);\n\tgoto L_0148;\nL_0144:\n\tv744 = *([v719 @ X11_v11]) + *([v425 @ X20_v9 (Il2CppMethodInfo)+48]);\n\tv745 = v744 << 4;\n\tv52 = v607 + v745;\n\tthis = v52 + 0x130;\nL_0148:\n\tthis = *([this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]);\n\tthis = 0x8D8294(this, Il2CppMethodInfo, *([v425 @ X20_v9 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v116, v118, v38, v39, v40, v41, v42, v43);\n\t*([this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)])(this, v159, &v62 @ stack_-70_v8 (System.String), this, v31, v32, v33, v34, v35, v116, v118, v38, v39, v40, v41, v42, v43);\nL_015A:\n\treturn;\n\tv256 = new System.NullReferenceException();\nL_015D:\n\tv320 = Morpeh.Filter::With(v312, v309);\nL_0161:\n\tthrow System.TypeLoadException;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			//IL_03a5: Expected I, but got O
			//IL_00a4: Expected I, but got O
			//IL_05d9: Expected O, but got I
			//IL_03e6: Expected O, but got I
			//IL_052d: Expected O, but got I
			//IL_00df: Expected O, but got I
			//IL_046f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0474: Expected O, but got Unknown
			//IL_0491: Expected O, but got I
			//IL_04a0: Expected O, but got I
			//IL_0432: Expected O, but got I
			//IL_01b8: Expected O, but got I
			//IL_01c1: Expected I4, but got O
			//IL_0168: Unknown result type (might be due to invalid IL or missing references)
			//IL_016d: Expected O, but got Unknown
			//IL_018a: Expected O, but got I
			//IL_0199: Expected O, but got I
			//IL_012b: Expected O, but got I
			GameConfig gameConfig = config;
			GlobalVariableInt globalVariableInt = ((Dictionary<string, GlobalVariableInt>)gameConfig.GlobalIntegers).get_Item("Level");
			bool flag = levelEntity == null;
			bool flag2 = !flag;
			int[] array = null;
			SaveGameSystem saveGameSystem;
			if (!flag2)
			{
				Filter all = Filter.All;
				Filter filter = all.With<SaveIntComponent>();
				Filter.EntityEnumerator enumerator = filter.GetEnumerator();
				World world = enumerator.world;
				IEntity entity = default(IEntity);
				NullReferenceException ex2 = default(NullReferenceException);
				bool fillWithPreviousEntities = default(bool);
				while (true)
				{
					Filter filter2 = ((Filter)(object)world).With<SaveIntComponent>(false);
					if ((int)((long)(IntPtr)filter2 & 1L) == 0)
					{
						goto IL_0222;
					}
					IntPtr intPtr = (IntPtr)0;
					IntPtr intPtr2 = (IntPtr)entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0144;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X11_v21-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v598 @ X8_v37 (Il2CppClass<Morpeh.IEntity>)+126]");
						bool flag3 = (long)num2 < 0L;
						bool flag4 = !flag3;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_0144;
					}
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v597 @ X22_v14 (Il2CppMethodInfo)+48]");
					object obj3 = obj2 + 0;
					int num3 = (int)((long)(IntPtr)obj3 << 4);
					gameConfig = (GameConfig)((long)intPtr2 + (long)num3);
					saveGameSystem = (SaveGameSystem)((long)(IntPtr)gameConfig + 304L);
					goto IL_051c;
					IL_0222:
					((BaseGlobalVariable<int>)(object)world).Value = 0;
					break;
					IL_0144:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_051c;
					IL_051c:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]");
					ref SaveIntComponent component = ref ((IEntity)0).GetComponent<SaveIntComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v740 @ X0_v61 (Morpeh.Hypercasual.SaveIntComponent&)] (should have been resolved before IL gen)");
					if (!((string)(object)this == "Level"))
					{
						continue;
					}
					levelEntity = entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]");
					gameConfig = (GameConfig)0;
					object obj4 = (int)gameConfig;
					string message = "LOAD " + obj4;
					Debug.Log(message);
					if ((object)globalVariableInt != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]");
						globalVariableInt.Value = 0;
						goto IL_0222;
					}
					NullReferenceException ex = new NullReferenceException();
					if (0 == 1)
					{
						Filter filter3 = ((Filter)(object)ex).With<SaveIntComponent>(false);
						Filter filter4 = filter3.With<SaveIntComponent>(fillWithPreviousEntities: false);
						Filter filter5 = ((Filter)(object)world).With<SaveIntComponent>(false);
						if (filter3 == null)
						{
							break;
						}
					}
					else
					{
						Filter filter6 = ((Filter)(object)ex2).With<SaveIntComponent>(fillWithPreviousEntities);
					}
					throw new TypeLoadException();
				}
				bool flag5 = levelEntity == null;
				bool flag6 = !flag5;
				array = enumerator.ids;
				World world2 = world;
				if (!flag6)
				{
					IEntity entity2 = World.CreateEntity();
					levelEntity = entity2;
					array = enumerator.ids;
					world2 = world;
				}
			}
			if (!globalVariableInt)
			{
				return;
			}
			int value = globalVariableInt.Value;
			object obj5 = value;
			string message2 = "SAVE " + obj5;
			Debug.Log(message2);
			IEntity entity3 = levelEntity;
			string text = "Level";
			int value2 = globalVariableInt.Value;
			IntPtr intPtr3 = (IntPtr)entity3;
			IntPtr intPtr4 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_044b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+B0]");
			object obj6 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v719 @ X11_v11-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v607 @ X8_v25 (Il2CppClass<Morpeh.IEntity>)+126]");
				bool flag7 = (long)num5 < 0L;
				bool flag8 = !flag7;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_044b;
			}
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v425 @ X20_v9 (Il2CppMethodInfo)+48]");
			object obj8 = obj7 + 0;
			int num6 = (int)((long)(IntPtr)obj8 << 4);
			gameConfig = (GameConfig)((long)intPtr3 + (long)num6);
			saveGameSystem = (SaveGameSystem)((long)(IntPtr)gameConfig + 304L);
			goto IL_05c9;
			IL_05c9:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)+8]");
			saveGameSystem = (SaveGameSystem)0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D8294");
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (GBG.Pinata.ECS.Systems.SaveGameSystem)] (should have been resolved before IL gen)");
			return;
			IL_044b:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_05c9;
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xCC6DD8", Offset = "0xCC6DD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SaveGameSystem()
		{
		}
	}
}
