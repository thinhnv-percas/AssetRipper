using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;
using TMPro;
using UnityEngine;

[CreateAssetMenu]
[Token(Token = "0x2000027")]
public class SetTextFromVariableSystem : UpdateSystem
{
	[Token(Token = "0x4000083")]
	[FieldOffset(Offset = "0x28")]
	public Filter filter;

	[Token(Token = "0x6000043")]
	[Address(RVA = "0xCCA5DC", Offset = "0xCCA5DC", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0AEC0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202378E]) = v38;\nL_0017:\n\tv42 = Morpeh.FilterProvider::get_All(this.filter);\n\tv52 = Morpeh.Filter::With(v42, 1);\n\tthis.filter = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnAwake()
	{
		Filter all = Filter.All;
		Filter filter = all.With<SetTextFromIntVariableComponent>();
		this.filter = filter;
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0xCCA64C", Offset = "0xCCA64C", Length = "0x2A8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1F04F20]);\n\tv35 = *([v34 @ X8_v40]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202378F]) = v54;\nL_001C:\n\tv370 = this.filter;\n\tv69 = v370.Length < 1;\n\tif (v69) goto L_0134;\nL_0031:\n\tv372 = v370.world;\n\tv118 = v372.Entities;\n\tv285 = v118[v373[v142 @ X23_v6 (System.Int32)]];\n\tv379 = Il2CppMethodInfo;\n\tv380 = *([v285 @ X20_v7 (Morpeh.Entity)]);\n\tv115 = *([v379 @ X21_v6 (Il2CppMethodInfo)+48]);\n\tv383 = *([v380 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v383) goto L_0061;\n\tv415 = *([v380 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_004D:\n\tv429 = *([v415 @ X11_v9-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v429) goto L_0064;\n\tv414 = v414 + 1;\n\tv434 = v414 < *([v380 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv410 = ~v434;\n\tv415 = v415 + 0x10;\n\tv394 = ~v410;\n\tif (v394) goto L_004D;\nL_0061:\n\tthis = 0x8909C4(v118[v373[v142 @ X23_v6 (System.Int32)]], Il2CppClass<Morpeh.IEntity>, v115, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_006A;\nL_0064:\n\tv436 = *([v415 @ X11_v9]) + v115;\n\tv437 = v436 << 4;\n\tv438 = v380 + v437;\n\tthis = v438 + 0x130;\nL_006A:\n\tv445 = Morpeh.IEntity::GetComponent(*([this @ X0 (SetTextFromVariableSystem)+8]));\n\t*([v445 @ X0_v10 (SetTextFromIntVariableComponent&)])(this, v118[v373[v142 @ X23_v6 (System.Int32)]], v445, v115, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv133 = *([this @ X0 (SetTextFromVariableSystem)]);\nL_007F:\n\tv467 = v90 >= *([v133 @ X21_v8+18]);\n\tif (v467) goto L_0115;\n\tv468 = *([v133 @ X21_v8+18]) < v90;\n\tv238 = ~v468;\n\tv227 = *([v133 @ X21_v8+18]) - v90;\n\tv205 = v227 == 0;\n\tv469 = ~v205;\n\tv151 = v238 & v469;\n\tif (v151) goto L_0090;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0090:\n\tv97 = v90 << 3;\n\tv473 = *([v133 @ X21_v8+10]) + v97;\n\tv276 = *([v473 @ X8_v21+20]);\n\tv277 = *([v276 @ X8_v22+10]);\n\tgoto L_00A5;\n\tv479 = *([v475 @ X0_v15+E0]);\n\tv480 = v479 == 0;\n\tv481 = ~v480;\n\tif (v481) goto L_00A5;\n\tv483 = \"il2cpp_codegen_runtime_class_init\"(v475, v125, v112, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\nL_00A5:\n\tv251 = System.Convert::ToInt32(*([v277 @ X8_v23+C0]));\n\tv86 = *([this @ X0 (SetTextFromVariableSystem)]);\n\tv487 = *([v86 @ X24_v7+18]) < v90;\n\tv239 = ~v487;\n\tv228 = *([v86 @ X24_v7+18]) - v90;\n\tv206 = v228 == 0;\n\tv488 = ~v206;\n\tv152 = v239 & v488;\n\tif (v152) goto L_00BB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00BB:\n\tv98 = v90 << 3;\n\tv491 = *([v86 @ X24_v7+10]) + v98;\n\tv279 = *([v491 @ X8_v27+20]);\n\tv253 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(*([v279 @ X8_v28+18]));\n\tv207 = v251 == v253;\n\tif (v207) goto L_010F;\n\tv137 = *([this @ X0 (SetTextFromVariableSystem)]);\n\tv499 = *([v137 @ X21_v13+18]) < v90;\n\tv241 = ~v499;\n\tv230 = *([v137 @ X21_v13+18]) - v90;\n\tv208 = v230 == 0;\n\tv500 = ~v208;\n\tv153 = v241 & v500;\n\tif (v153) goto L_00E2;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00E2:\n\tv99 = v90 << 3;\n\tv503 = *([v137 @ X21_v13+10]) + v99;\n\tv280 = *([v503 @ X8_v32+20]);\n\tv87 = *([this @ X0 (SetTextFromVariableSystem)]);\n\tv504 = *([v87 @ X24_v9+18]) < v90;\n\tv242 = ~v504;\n\tv231 = *([v87 @ X24_v9+18]) - v90;\n\tv209 = v231 == 0;\n\tv505 = ~v209;\n\tv154 = v242 & v505;\n\tif (v154) goto L_00FB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00FB:\n\tv100 = v90 << 3;\n\tv508 = *([v87 @ X24_v9+10]) + v100;\n\tv281 = *([v508 @ X8_v35+20]);\n\tv510 = Morpeh.Globals.BaseGlobalVariable`1<System.Int32>::get_Value(*([v281 @ X8_v36+18]));\n\tv256 = 0xDC3560(&v510 @ X0_v26 (System.Int32), 0, v115, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tTMPro.TMP_Text::set_text(*([v280 @ X8_v33+10]), v256);\nL_010F:\n\tv133 = *([this @ X0 (SetTextFromVariableSystem)]);\n\tv90 = v90 + 1;\n\tv497 = *([this @ X0 (SetTextFromVariableSystem)]) == 0;\n\tv271 = ~v497;\n\tif (v271) goto L_007F;\n\tgoto L_0126;\nL_0115:\n\tv142 = v142 + 1;\n\tv148 = v142 >= v370.Length;\n\tif (v148) goto L_0134;\n\tv370 = this.filter;\n\tv474 = this.filter == 0;\n\tv259 = ~v474;\n\tif (v259) goto L_0031;\nL_0126:\n\tthrow System.NullReferenceException;\nL_0134:\n\treturn;\n// 196 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void OnUpdate(float deltaTime)
	{
		//IL_0043: Expected I, but got O
		//IL_0053: Expected O, but got I
		//IL_05bc: Expected O, but got I
		//IL_008e: Expected O, but got I
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_0132: Expected O, but got I
		//IL_0141: Expected O, but got I
		//IL_00da: Expected O, but got I
		//IL_01ed: Expected O, but got I
		//IL_01fd: Expected O, but got I
		//IL_0212: Expected O, but got I
		//IL_022d: Expected O, but got I
		//IL_02d4: Expected O, but got I
		//IL_02e4: Expected O, but got I
		//IL_02fa: Expected O, but got I
		//IL_03bd: Expected O, but got I
		//IL_03cd: Expected O, but got I
		//IL_0475: Expected O, but got I
		//IL_0485: Expected O, but got I
		//IL_049b: Expected O, but got I
		//IL_04c8: Expected O, but got I
		//IL_04d1: Expected O, but got I4
		Filter filter = this.filter;
		if (filter.Length < 1)
		{
			return;
		}
		int num = 0;
		int[] array = default(int[]);
		string text = default(string);
		while (true)
		{
			World world = filter.world;
			Entity[] entities = world.Entities;
			Entity entity = entities[array[num]];
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)entity;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v379 @ X21_v6 (Il2CppMethodInfo)+48]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+B0]");
			object obj2 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v415 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v380 @ X8_v14 (Il2CppClass<Morpeh.Entity>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f3;
			}
			object obj3 = obj2 + (long)(IntPtr)obj;
			int num4 = (int)((long)(IntPtr)obj3 << 4);
			object obj4 = (long)intPtr2 + (long)num4;
			SetTextFromVariableSystem setTextFromVariableSystem = (SetTextFromVariableSystem)((long)(IntPtr)obj4 + 304L);
			goto IL_05ab;
			IL_05ab:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (SetTextFromVariableSystem)+8]");
			ref SetTextFromIntVariableComponent component = ref ((IEntity)0).GetComponent<SetTextFromIntVariableComponent>();
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v445 @ X0_v10 (SetTextFromIntVariableComponent&)] (should have been resolved before IL gen)");
			object obj5 = this;
			int num5 = 0;
			while (true)
			{
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X21_v8+18]");
				if ((long)num6 < 0L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X21_v8+18]");
					bool flag3 = 0L < (long)num5;
					bool flag4 = !flag3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X21_v8+18]");
					int num7 = (int)(-num5);
					bool flag5 = num7 == 0;
					bool flag6 = !flag5;
					if (!(flag4 && flag6))
					{
						throw new ArgumentOutOfRangeException();
					}
					int num8 = num5 << 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X21_v8+10]");
					object obj6 = 0L + (long)num8;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v473 @ X8_v21+20]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v22+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X8_v23+C0]");
					int num9 = Convert.ToInt32((string)0);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X24_v7+18]");
					bool flag7 = 0L < (long)num5;
					bool flag8 = !flag7;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X24_v7+18]");
					int num10 = (int)(-num5);
					bool flag9 = num10 == 0;
					bool flag10 = !flag9;
					if (!(flag8 && flag10))
					{
						throw new ArgumentOutOfRangeException();
					}
					int num11 = num5 << 3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X24_v7+10]");
					object obj9 = 0L + (long)num11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v491 @ X8_v27+20]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v279 @ X8_v28+18]");
					int value = ((BaseGlobalVariable<int>)0).Value;
					if (num9 != value)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v13+18]");
						bool flag11 = 0L < (long)num5;
						bool flag12 = !flag11;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v13+18]");
						int num12 = (int)(-num5);
						bool flag13 = num12 == 0;
						bool flag14 = !flag13;
						if (!(flag12 && flag14))
						{
							throw new ArgumentOutOfRangeException();
						}
						int num13 = num5 << 3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v13+10]");
						object obj11 = 0L + (long)num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v32+20]");
						object obj12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X24_v9+18]");
						bool flag15 = 0L < (long)num5;
						bool flag16 = !flag15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X24_v9+18]");
						int num14 = (int)(-num5);
						bool flag17 = num14 == 0;
						bool flag18 = !flag17;
						if (!(flag16 && flag18))
						{
							throw new ArgumentOutOfRangeException();
						}
						int num15 = num5 << 3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v87 @ X24_v9+10]");
						object obj13 = 0L + (long)num15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ X8_v35+20]");
						object obj14 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X8_v36+18]");
						int value2 = ((BaseGlobalVariable<int>)0).Value;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ X8_v33+10]");
						((TMP_Text)0).text = text;
						obj = 0;
					}
					obj5 = this;
					num5++;
					if ((object)this != null)
					{
						continue;
					}
				}
				else
				{
					num++;
					if (num >= filter.Length)
					{
						return;
					}
					filter = this.filter;
					if (this.filter != null)
					{
						break;
					}
				}
				throw new NullReferenceException();
			}
			continue;
			IL_00f3:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_05ab;
		}
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0xCCA8F4", Offset = "0xCCA8F4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.UpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SetTextFromVariableSystem()
	{
	}
}
