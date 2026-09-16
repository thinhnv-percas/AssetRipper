using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.UI.Components;
using Morpeh;
using Morpeh.Globals;
using TMPro;
using UnityEngine;

namespace GBG.Pinata.ECS.UI.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x200003E")]
	public class MetaUpgradeButtonUISystem : UpdateSystem
	{
		[SerializeField]
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x28")]
		private GlobalVariableInt metaLevel;

		[SerializeField]
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x30")]
		private string metaTypeKey;

		[SerializeField]
		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x38")]
		private string boostValueTemplate;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x40")]
		private Filter metaUIEntities;

		[Token(Token = "0x6000071")]
		[Address(RVA = "0xCC7F20", Offset = "0xCC7F20", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEC7D8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202377A]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv53 = Morpeh.Filter::With(v42, 1);\n\tthis.metaUIEntities = v53;\n\tv84 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.metaLevel);\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::Publish(this.metaLevel, v84);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			Filter all = Filter.All;
			Filter filter = all.With<MetaUpgradeButtonComponent>();
			metaUIEntities = filter;
			int value = metaLevel.Value;
			metaLevel.Publish(value);
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0xCC7FC8", Offset = "0xCC7FC8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv17 = *([1EEEED0]);\n\tv18 = *([v17 @ X8_v5]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, deltaTime, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([202377B]) = v37;\nL_0015:\n\tv40 = 0xCCDC1C(this.metaLevel, methodInfo, v21, v22, v23, v24, v25, v26, deltaTime, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n\tX1 = *([1EAD000]);\n\tX0 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0024;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 33 ShiftStack 32\n\tGBG.Pinata.ECS.UI.Systems.MetaUpgradeButtonUISystem::UpdateUI(X0, X1);\n\treturn;\nL_0024:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 40 ShiftStack 32\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CCDC1C (inside WeaponParametersProvider::.ctor +0x6C)");
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0xCC8030", Offset = "0xCC8030", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1ED6920]);\n\tv31 = *([v30 @ X8_v28]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202377C]) = v50;\nL_001E:\n\tv56 = this.metaUIEntities == 0;\n\tif (v56) goto L_00DB;\n\tv60 = Morpeh.Filter::GetEnumerator(this.metaUIEntities);\n\tv154 = v60.world;\nL_0039:\n\tv240 = 0x15F75B8(&v154 @ stack_-98_v3 (Morpeh.World), 0, v214, 0, v36, v37, v38, v39, v60.ids, v60.world, v42, v43, v44, v45, v46, v47);\n\tv251 = v240 & 1;\n\tv252 = v251 == 0;\n\tif (v252) goto L_00C8;\n\tv221 = Il2CppMethodInfo;\n\tv687 = *([v256 @ stack_-68]);\n\tv276 = *([v687 @ X8_v20 (System.Int32)+126]);\n\tv278 = *([v687 @ X8_v20 (System.Int32)+126]) == 0;\n\tif (v278) goto L_0063;\n\tv444 = *([v687 @ X8_v20 (System.Int32)+B0]) + 8;\nL_004A:\n\t;\n\tv449 = *([v444 @ X11_v18-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v449) goto L_0065;\n\tv443 = v443 + 1;\n\tv478 = v443 < v276;\n\tv304 = ~v478;\n\tv444 = v444 + 0x10;\n\tv288 = ~v304;\n\tif (v288) goto L_004A;\nL_0063:\n\tv485 = 0x8909C4(v256, Il2CppClass<Morpeh.IEntity>, *([v221 @ X21_v15 (Il2CppMethodInfo)+48]), 0, v36, v37, v38, v39, v60.ids, v60.world, v42, v43, v44, v45, v46, v47);\n\tgoto L_006A;\nL_0065:\n\tv276 = *([v444 @ X11_v18]);\n\tv276 = v276 + *([v221 @ X21_v15 (Il2CppMethodInfo)+48]);\n\tv481 = v276 << 4;\n\tv687 = v687 + v481;\n\tv485 = v687 + 0x130;\nL_006A:\n\t;\n\tv489 = Morpeh.IEntity::GetComponent(*([v485 @ X0_v47+8]));\n\tv276 = *([v489 @ X0_v49 (GBG.Pinata.ECS.UI.Components.MetaUpgradeButtonComponent&)]);\n\t*([v489 @ X0_v49 (GBG.Pinata.ECS.UI.Components.MetaUpgradeButtonComponent&)])(v517, v256, v489, *([v221 @ X21_v15 (Il2CppMethodInfo)+48]), 0, v36, v37, v38, v39, v60.ids, v60.world, v42, v43, v44, v45, v46, v47);\n\tv227 = System.String::Equals(this.metaTypeKey, *([v517 @ X0_v51+18]));\n\tv230 = v227 == 0;\n\tif (v230) goto L_0039;\n\tv622 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(this.metaLevel);\n\tv510 = GBG.Pinata.ECS.GameConfig::get_Instance();\n\tv562 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.MetaUpgradeConfig>::get_Item(v510.MetaUpgradeConfigs, this.metaTypeKey);\n\tv571 = v562.Data;\n\tv687 = v571._size;\n\tv688 = v571._size < v622;\n\tv209 = ~v688;\n\tv206 = v571._size - v622;\n\tv200 = v206 == 0;\n\tv689 = ~v200;\n\tv185 = v209 & v689;\n\tif (v185) goto L_009F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_009F:\n\tv691 = v571._items;\n\tv618 = v691[v622 @ X0_v55 (System.Int32)];\n\tv687 = v618.BoostValue;\n\tv276 = *([v687 @ X8_v20 (System.Int32)+14]);\n\tv646 = System.Collections.Generic.Dictionary`2<System.String, GBG.Pinata.ECS.MetaUpgradeConfig>::get_Item(&v687 @ X8_v20 (System.Int32), 0);\n\tv676 = System.String::Replace(this.boostValueTemplate, \"{VALUE}\", v646);\n\tTMPro.TMP_Text::SetText(*([v517 @ X0_v51+8]), v676);\n\tv685 = 0xDC3560(&v276 @ X9_v14 (System.Int32), 0, 0, 0, v36, v37, v38, v39, v60.ids, v60.world, v42, v43, v44, v45, v46, v47);\n\tTMPro.TMP_Text::SetText(*([v517 @ X0_v51+10]), v685);\n\tgoto L_0039;\nL_00C8:\n\tv260 = 0x15F7664(&v154 @ stack_-98_v3 (Morpeh.World), 0, v214, 0, v36, v37, v38, v39, v60.ids, v60.world, v42, v43, v44, v45, v46, v47);\n\tgoto L_0111;\n\tv280 = new System.NullReferenceException();\n\tv335 = new System.NullReferenceException();\n\tv477 = new System.NullReferenceException();\n\tv515 = new System.NullReferenceException();\n\tv541 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv158 = new System.NullReferenceException();\nL_00DB:\n\tv165 = new System.NullReferenceException();\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\nL_00FB:\n\tv250 = v155 != 1;\n\tif (v250) goto L_0112;\n\tv253 = 0x6D2BC0(v165, v155, v109, v64, v36, v37, v38, v39, v142, v154, v42, v43, v44, v45, v46, v47);\n\tv262 = 0x6D2490(v253, v155, v109, v64, v36, v37, v38, v39, v142, v154, v42, v43, v44, v45, v46, v47);\n\tv266 = 0x15F7664(&v120 @ stack_-70_v3 (Morpeh.World), 0, v109, v64, v36, v37, v38, v39, v142, v154, v42, v43, v44, v45, v46, v47);\n\tv388 = *([v253 @ X0_v10]) == 0;\n\tv268 = ~v388;\n\tif (v268) goto L_0116;\nL_0111:\n\treturn;\nL_0112:\n\tv254 = 0x6D2380(v165, v155, v109, v64, v36, v37, v38, v39, v142, v154, v42, v43, v44, v45, v46, v47);\nL_0116:\n\tthrow System.TypeLoadException;\n// 167 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateUI()
		{
			//IL_0034: Expected I4, but got O
			//IL_03f6: Expected O, but got I
			//IL_0407: Expected I4, but got O
			//IL_0081: Expected O, but got I
			//IL_0150: Expected O, but got I
			//IL_016c: Expected O, but got I4
			//IL_00f5: Expected I4, but got O
			//IL_0133: Expected O, but got I4
			//IL_00c5: Expected O, but got I
			//IL_028e: Expected O, but got I4
			//IL_02c9: Expected O, but got I
			//IL_02ee: Expected O, but got I
			//IL_02f7: Expected O, but got I4
			bool flag = metaUIEntities == null;
			World world2 = default(World);
			World world = world2;
			if (!flag)
			{
				world2 = metaUIEntities.GetEnumerator().world;
				object obj = default(object);
				object obj2 = default(object);
				string text3 = default(string);
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
					if ((int)((long)(IntPtr)obj & 1L) == 0)
					{
						break;
					}
					IntPtr intPtr = (IntPtr)0;
					int num = (int)obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ X8_v20 (System.Int32)+126]");
					int num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ X8_v20 (System.Int32)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00de;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ X8_v20 (System.Int32)+B0]");
					object obj3 = 0L + 8L;
					int num3 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ X11_v18-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num3++;
						bool flag2 = num3 < num2;
						bool flag3 = !flag2;
						obj3 = (long)(IntPtr)obj3 + 16L;
						if (!flag3)
						{
							continue;
						}
						goto IL_00de;
					}
					num2 = (int)obj3;
					int num4 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v221 @ X21_v15 (Il2CppMethodInfo)+48]");
					num2 = (int)((long)num4 + 0L);
					int num5 = num2 << 4;
					num += num5;
					object obj4 = num + 304;
					goto IL_03e4;
					IL_00de:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					goto IL_03e4;
					IL_03e4:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X0_v47+8]");
					num2 = (int)((IEntity)0).GetComponent<MetaUpgradeButtonComponent>();
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v489 @ X0_v49 (GBG.Pinata.ECS.UI.Components.MetaUpgradeButtonComponent&)] (should have been resolved before IL gen)");
					string text = metaTypeKey;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ X0_v51+18]");
					bool flag4 = text.Equals((string)0);
					bool flag5 = !flag4;
					object obj5 = 0;
					if (!flag5)
					{
						int value = metaLevel.Value;
						GameConfig instance = GameConfig.Instance;
						MetaUpgradeConfig metaUpgradeConfig = ((Dictionary<string, MetaUpgradeConfig>)instance.MetaUpgradeConfigs).get_Item(metaTypeKey);
						List<MetaUpgradeData> data = metaUpgradeConfig.Data;
						num = data.Count;
						bool flag6 = data.Count < value;
						bool flag7 = !flag6;
						int num6 = data.Count - value;
						bool flag8 = num6 == 0;
						bool flag9 = !flag8;
						if (!(flag7 && flag9))
						{
							throw new ArgumentOutOfRangeException();
						}
						MetaUpgradeData[] items = data._items;
						MetaUpgradeData metaUpgradeData = items[value];
						num = metaUpgradeData.BoostValue;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ X8_v20 (System.Int32)+14]");
						num2 = 0;
						MetaUpgradeConfig newValue = ((Dictionary<string, MetaUpgradeConfig>)num).get_Item((string)null);
						string text2 = boostValueTemplate.Replace("{VALUE}", (string)(object)newValue);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ X0_v51+8]");
						((TMP_Text)0).SetText(text2);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v517 @ X0_v51+10]");
						((TMP_Text)0).SetText(text3);
						obj5 = 0;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr2 = default(IntPtr);
			if (intPtr2 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15F7664 (inside Morpeh.Filter::<.ctor>b__15_1 +0x10C)");
				object obj6 = default(object);
				if (obj6 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0xCC8344", Offset = "0xCC8344", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF1278]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202377D]) = v38;\nL_0018:\n\tthis.boostValueTemplate = \"+{VALUE}%\";\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MetaUpgradeButtonUISystem()
		{
			boostValueTemplate = "+{VALUE}%";
		}
	}
}
