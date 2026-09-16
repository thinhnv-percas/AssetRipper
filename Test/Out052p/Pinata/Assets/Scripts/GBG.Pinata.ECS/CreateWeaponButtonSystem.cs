using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS;
using Morpeh;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x2000026")]
public class CreateWeaponButtonSystem : UpdateSystem
{
	[Token(Token = "0x4000081")]
	[FieldOffset(Offset = "0x28")]
	private Filter filter;

	[Token(Token = "0x4000082")]
	[FieldOffset(Offset = "0x30")]
	private GameConfig config;

	[Token(Token = "0x6000040")]
	[Address(RVA = "0xCBEA00", Offset = "0xCBEA00", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F09850]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023710]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\tv58 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tthis.config = v58;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<CreateWeaponButtonComponent>();
		this.filter = filter;
		GameConfig instance = GameConfig.Instance;
		config = instance;
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0xCBEA78", Offset = "0xCBEA78", Length = "0x318")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1F0ABF0]);\n\tv35 = *([v34 @ X8_v38]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023711]) = v54;\nL_001F:\n\tv59 = this.filter == 0;\n\tif (v59) goto L_00FC;\n\tv63 = Morpeh.Filter::GetEnumerator(this.filter);\n\tv154 = v63.world;\n\tgoto L_00E7;\nL_003C:\n\tv281 = Il2CppMethodInfo;\n\tv282 = *([v266 @ stack_-78 (UnityEngine.GameObject)]);\n\tv219 = *([v281 @ X21_v12 (Il2CppMethodInfo)+48]);\n\tv285 = *([v282 @ X8_v14 (Il2CppClass<UnityEngine.GameObject>)+126]) == 0;\n\tif (v285) goto L_005F;\n\tv461 = *([v282 @ X8_v14 (Il2CppClass<UnityEngine.GameObject>)+B0]) + 8;\nL_0046:\n\t;\n\tv466 = *([v461 @ X11_v15-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v466) goto L_0061;\n\tv460 = v460 + 1;\n\tv499 = v460 < *([v282 @ X8_v14 (Il2CppClass<UnityEngine.GameObject>)+126]);\n\tv364 = ~v499;\n\tv461 = v461 + 0x10;\n\tv348 = ~v364;\n\tif (v348) goto L_0046;\nL_005F:\n\tv506 = UnityEngine.Object::Instantiate(v266, Il2CppClass<Morpeh.IEntity>);\n\tgoto L_0066;\nL_0061:\n\t;\n\tv501 = *([v461 @ X11_v15]) + v219;\n\tv502 = v501 << 4;\n\tv503 = v282 + v502;\n\tv506 = v503 + 0x130;\nL_0066:\n\t;\n\tv510 = Morpeh.IEntity::GetComponent(*([v506 @ X0_v39 (UnityEngine.GameObject)+8]));\n\t*([v510 @ X0_v41 (CreateWeaponButtonComponent&)])(v398, v266, v510, v219, v39, v40, v41, v42, v43, v63.ids, v154, v46, v47, v48, v49, v50, v51);\n\tv491 = UnityEngine.Transform::get_childCount(*([v398 @ X0_v43]));\n\tv495 = this.config;\n\tv232 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v495.Weapon.Data);\n\tv201 = v491 == *([v232 @ X0_v47 (GBG.Pinata.ECS.WeaponSetup)+18]);\n\tif (v201) goto L_00E7;\n\tv241 = this.config;\n\tv233 = Morpeh.Globals.BaseGlobalVariable`1<GBG.Pinata.ECS.WeaponSetup>::get_Value(v241.Weapon.Data);\n\tv182 = *([v233 @ X0_v49 (GBG.Pinata.ECS.WeaponSetup)+18]) < 1;\n\tif (v182) goto L_00E7;\nL_00A7:\n\tgoto L_00B0;\n\tv636 = *([v632 @ X0_v51+E0]);\n\tv637 = v636 == 0;\n\tv638 = ~v637;\n\tgoto L_00B0;\n\tv640 = \"il2cpp_codegen_runtime_class_init\"(v632, v628, v627, v39, v40, v41, v42, v43, v129, v131, v46, v47, v48, v49, v50, v51);\nL_00B0:\n\tv646 = UnityEngine.Object::op_Inequality(*([v398 @ X0_v43+8]), 0);\n\tv648 = v646 == 0;\n\tif (v648) goto L_00CD;\n\tv651 = UnityEngine.Component::get_transform(*([v398 @ X0_v43]));\n\tgoto L_00C7;\n\tv672 = *([v657 @ X0_v62+E0]);\n\tv673 = v672 == 0;\n\tv674 = ~v673;\n\tif (v674) goto L_00C7;\n\tv676 = \"il2cpp_codegen_runtime_class_init\"(v657, v650, v645, v39, v40, v41, v42, v43, v129, v131, v46, v47, v48, v49, v50, v51);\nL_00C7:\n\tv684 = UnityEngine.Object::Instantiate(*([v398 @ X0_v43+8]), v651);\n\tgoto L_00D8;\nL_00CD:\n\tgoto L_00D7;\n\tv661 = *([v652 @ X0_v56+E0]);\n\tv662 = v661 == 0;\n\tv663 = ~v662;\n\tif (v663) goto L_00D7;\n\tv665 = \"il2cpp_codegen_runtime_class_init\"(v652, v644, v645, v39, v40, v41, v42, v43, v129, v131, v46, v47, v48, v49, v50, v51);\nL_00D7:\n\tUnityEngine.Debug::LogWarning(\"WEAPON BUTTON PREFAB IS NULL\");\nL_00D8:\n\tv616 = v616 + 1;\n\tv180 = v616 < *([v233 @ X0_v49 (GBG.Pinata.ECS.WeaponSetup)+18]);\n\tif (v180) goto L_00A7;\nL_00E7:\n\tv246 = UnityEngine.Object::Instantiate(&v154 @ stack_-A0_v3 (Morpeh.World), 0);\n\tv257 = v246 & 1;\n\tv258 = v257 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_003C;\n\tv264 = UnityEngine.Object::Instantiate(&v154 @ stack_-A0_v3 (Morpeh.World), 0);\n\tgoto L_012E;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv498 = new System.NullReferenceException();\n\tv535 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv585 = new System.NullReferenceException();\n\tv610 = new System.NullReferenceException();\n\tv158 = new System.NullReferenceException();\nL_00FC:\n\tv165 = new System.NullReferenceException();\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\n\tgoto L_0116;\nL_0116:\n\tv256 = v155 != 1;\n\tif (v256) goto L_012F;\n\tv260 = UnityEngine.Object::Instantiate(v165, v155);\n\tv269 = UnityEngine.Object::Instantiate(v260, v155);\n\tv273 = UnityEngine.Object::Instantiate(&v118 @ stack_-80_v3 (Morpeh.World), 0);\n\tv406 = *([v260 @ X0_v10 (UnityEngine.GameObject)]) == 0;\n\tv275 = ~v406;\n\tif (v275) goto L_0133;\nL_012E:\n\treturn;\nL_012F:\n\tv261 = UnityEngine.Object::Instantiate(v165, v155);\nL_0133:\n\tthrow System.TypeLoadException;\n// 193 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_039c: Expected O, but got I
		//IL_033e: Expected O, but got I
		//IL_034f: Expected O, but got I
		//IL_0034: Expected I, but got O
		//IL_00f1: Expected O, but got I
		//IL_0407: Expected O, but got I
		//IL_0081: Expected O, but got I
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected O, but got Unknown
		//IL_0126: Expected O, but got I
		//IL_0135: Expected O, but got I
		//IL_00cd: Expected O, but got I
		//IL_0209: Expected O, but got I
		//IL_0274: Expected I, but got O
		//IL_0251: Expected O, but got I
		bool flag = filter == null;
		World world = default(World);
		World original = world;
		if (!flag)
		{
			world = filter.GetEnumerator().world;
			GameObject gameObject2 = default(GameObject);
			object obj4 = default(object);
			while (true)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate((GameObject)(object)world, null);
				if ((int)((long)(IntPtr)gameObject & 1L) == 0)
				{
					break;
				}
				IntPtr intPtr = (IntPtr)0;
				IntPtr intPtr2 = (IntPtr)gameObject2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X21_v12 (Il2CppMethodInfo)+48]");
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X8_v14 (Il2CppClass<UnityEngine.GameObject>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00e6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X8_v14 (Il2CppClass<UnityEngine.GameObject>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ X11_v15-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v282 @ X8_v14 (Il2CppClass<UnityEngine.GameObject>)+126]");
					bool flag2 = (long)num2 < 0L;
					bool flag3 = !flag2;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag3)
					{
						continue;
					}
					goto IL_00e6;
				}
				object obj2 = obj + (long)intPtr3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr2 + (long)num3;
				GameObject gameObject3 = (GameObject)((long)(IntPtr)obj3 + 304L);
				goto IL_03f5;
				IL_00e6:
				gameObject3 = UnityEngine.Object.Instantiate(gameObject2, (Transform)0);
				goto IL_03f5;
				IL_03f5:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ X0_v39 (UnityEngine.GameObject)+8]");
				ref CreateWeaponButtonComponent component = ref ((IEntity)0).GetComponent<CreateWeaponButtonComponent>();
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v510 @ X0_v41 (CreateWeaponButtonComponent&)] (should have been resolved before IL gen)");
				int childCount = ((Transform)obj4).childCount;
				GameConfig gameConfig = config;
				WeaponSetup value = gameConfig.Weapon.Data.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ X0_v47 (GBG.Pinata.ECS.WeaponSetup)+18]");
				if ((IntPtr)childCount == (IntPtr)0)
				{
					continue;
				}
				GameConfig gameConfig2 = config;
				WeaponSetup value2 = gameConfig2.Weapon.Data.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X0_v49 (GBG.Pinata.ECS.WeaponSetup)+18]");
				if (0L < 1L)
				{
					continue;
				}
				int num4 = 0;
				int num5;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X0_v43+8]");
					if ((UnityEngine.Object)0 != null)
					{
						Transform transform = ((Component)obj4).transform;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X0_v43+8]");
						GameObject gameObject4 = UnityEngine.Object.Instantiate((GameObject)0, transform);
						intPtr3 = (IntPtr)0;
					}
					else
					{
						Debug.LogWarning("WEAPON BUTTON PREFAB IS NULL");
						intPtr3 = (IntPtr)null;
					}
					num4++;
					num5 = num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X0_v49 (GBG.Pinata.ECS.WeaponSetup)+18]");
				}
				while ((long)num5 < 0L);
			}
			GameObject gameObject5 = UnityEngine.Object.Instantiate((GameObject)(object)world, null);
			return;
		}
		NullReferenceException original2 = new NullReferenceException();
		IntPtr intPtr4 = default(IntPtr);
		if (intPtr4 == (IntPtr)1)
		{
			GameObject gameObject6 = UnityEngine.Object.Instantiate((GameObject)(object)original2, (Transform)(long)intPtr4);
			GameObject gameObject7 = UnityEngine.Object.Instantiate(gameObject6, (Transform)(long)intPtr4);
			GameObject gameObject8 = UnityEngine.Object.Instantiate((GameObject)(object)original, null);
			if ((object)gameObject6 == null)
			{
				return;
			}
		}
		else
		{
			GameObject gameObject9 = UnityEngine.Object.Instantiate((GameObject)(object)original2, (Transform)(long)intPtr4);
		}
		throw new TypeLoadException();
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0xCBED90", Offset = "0xCBED90", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CreateWeaponButtonSystem()
	{
	}
}
