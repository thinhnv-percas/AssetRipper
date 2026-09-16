using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh
{
	[Token(Token = "0x2000017")]
	public abstract class MonoProvider<T> : EntityProvider where T : struct, IComponent
	{
		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x0")]
		private T serializedData;

		[Token(Token = "0x1700000A")]
		private T Data
		{
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x109EE54", Offset = "0x109EE54", Length = "0x114")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0;\n\tv22 = Morpeh.EntityProvider::get_Entity(this);\n\tv46 = v22 == 0;\n\tif (v46) goto L_0040;\n\tv26 = Morpeh.EntityProvider::get_Entity(this);\n\tv140 = *([v26 @ X0_v7 (Morpeh.IEntity)]);\n\tv137 = Il2CppMethodInfo;\n\tv134 = *([v140 @ X8_v4 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v134) goto L_003D;\n\tv184 = *([v140 @ X8_v4 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0029:\n\tv189 = *([v184 @ X11_v6-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v189) goto L_0046;\n\tv183 = v183 + 1;\n\tv194 = v183 < *([v140 @ X8_v4 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv166 = ~v194;\n\tv184 = v184 + 0x10;\n\tv150 = ~v166;\n\tif (v150) goto L_0029;\nL_003D:\n\tv202 = 0x8909C4(v26, Il2CppClass<Morpeh.IEntity>, *([v137 @ X21_v4 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_004C;\nL_0040:\n\t*([v17 @ X8+20]) = *([this @ X0 (Morpeh.MonoProvider`1<T>)+40]);\n\t*([v17 @ X8+10]) = *([this @ X0 (Morpeh.MonoProvider`1<T>)+30]);\n\tv60 = this.serializedData;\n\tgoto L_0058;\nL_0046:\n\tv196 = *([v184 @ X11_v6]) + *([v137 @ X21_v4 (Il2CppMethodInfo)+48]);\n\tv197 = v196 << 4;\n\tv198 = v140 + v197;\n\tv202 = v198 + 0x130;\nL_004C:\n\tv205 = 0x8D8294(*([v202 @ X0_v8+8]), Il2CppMethodInfo, *([v137 @ X21_v4 (Il2CppMethodInfo)+48]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v205 @ X0_v10])(returnVal2, v26, &v18 @ stack_-24_v1, v205, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v17 @ X8+20]) = *([returnVal2 @ X0_v5 (T)+20]);\n\t*([v17 @ X8+10]) = *([returnVal2 @ X0_v5 (T)+10]);\n\tv60 = *([returnVal2 @ X0_v5 (T)]);\nL_0058:\n\t*([v17 @ X8]) = v60;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0009: Expected O, but got I4
				//IL_004c: Expected I, but got O
				//IL_008d: Expected O, but got I
				//IL_0142: Unknown result type (might be due to invalid IL or missing references)
				//IL_0147: Expected O, but got Unknown
				//IL_0164: Expected O, but got I
				//IL_0173: Expected O, but got I
				//IL_00d9: Expected O, but got I
				object obj = 0;
				IEntity entity = base.Entity;
				if (entity != null)
				{
					IEntity entity2 = base.Entity;
					IntPtr intPtr = (IntPtr)entity2;
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v4 (Il2CppClass<Morpeh.IEntity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00f2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v4 (Il2CppClass<Morpeh.IEntity>)+B0]");
					object obj2 = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X11_v6-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v4 (Il2CppClass<Morpeh.IEntity>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00f2;
					}
					object obj3 = obj2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X21_v4 (Il2CppMethodInfo)+48]");
					object obj4 = obj3 + 0;
					int num3 = (int)((long)(IntPtr)obj4 << 4);
					object obj5 = (long)intPtr + (long)num3;
					object obj6 = (long)(IntPtr)obj5 + 304L;
					goto IL_019a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Morpeh.MonoProvider`1<T>)+40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Morpeh.MonoProvider`1<T>)+30]");
				_ = 0;
				T val = serializedData;
				T val2 = (T)entity;
				goto IL_01d5;
				IL_019a:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v205 @ X0_v10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ X0_v5 (T)+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal2 @ X0_v5 (T)+10]");
				_ = 0;
				val = val2;
				goto IL_01d5;
				IL_00f2:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_019a;
				IL_01d5:
				object obj7 = val;
				return val2;
			}
			[Token(Token = "0x600006C")]
			[Address(RVA = "0x109EF68", Offset = "0x109EF68", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = Morpeh.EntityProvider::get_Entity(this);\n\tv44 = v21 == 0;\n\tif (v44) goto L_0041;\n\tv25 = Morpeh.EntityProvider::get_Entity(this);\n\tv123 = *([v25 @ X0_v6 (Morpeh.IEntity)]);\n\tv124 = Il2CppMethodInfo;\n\tv112 = *([v123 @ X8_v3 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v112) goto L_003C;\n\tv168 = *([v123 @ X8_v3 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0028:\n\tv173 = *([v168 @ X11_v5-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v173) goto L_004C;\n\tv167 = v167 + 1;\n\tv178 = v167 < *([v123 @ X8_v3 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv150 = ~v178;\n\tv168 = v168 + 0x10;\n\tv134 = ~v150;\n\tif (v134) goto L_0028;\nL_003C:\n\tv185 = 0x8909C4(v25, Il2CppClass<Morpeh.IEntity>, *([v124 @ X21_v3 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0052;\nL_0041:\n\t*([this @ X0 (Morpeh.MonoProvider`1<T>)+40]) = *([value @ X1 (T)+20]);\n\tthis.serializedData = value->klass;\n\t*([this @ X0 (Morpeh.MonoProvider`1<T>)+30]) = *([value @ X1 (T)+10]);\n\treturn;\nL_004C:\n\tv180 = *([v168 @ X11_v5]) + *([v124 @ X21_v3 (Il2CppMethodInfo)+48]);\n\tv181 = v180 << 4;\n\tv182 = v123 + v181;\n\tv185 = v182 + 0x130;\nL_0052:\n\tv188 = 0x8D8294(*([v185 @ X0_v7+8]), Il2CppMethodInfo, *([v124 @ X21_v3 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv58 = *([v188 @ X0_v9]);\n\t// 94 IndirectJump v58 @ X3_v1, v25 @ X0_v6 (Morpeh.IEntity), v25 @ X0_v6 (Morpeh.IEntity), value @ X1 (T), v188 @ X0_v9, v58 @ X3_v1, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_003e: Expected I, but got O
				//IL_007f: Expected O, but got I
				//IL_0128: Unknown result type (might be due to invalid IL or missing references)
				//IL_012d: Expected O, but got Unknown
				//IL_014a: Expected O, but got I
				//IL_0159: Expected O, but got I
				//IL_00cb: Expected O, but got I
				IEntity entity = base.Entity;
				if (entity != null)
				{
					IEntity entity2 = base.Entity;
					IntPtr intPtr = (IntPtr)entity2;
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X8_v3 (Il2CppClass<Morpeh.IEntity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00e4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X8_v3 (Il2CppClass<Morpeh.IEntity>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ X8_v3 (Il2CppClass<Morpeh.IEntity>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_00e4;
					}
					object obj2 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X21_v3 (Il2CppMethodInfo)+48]");
					object obj3 = obj2 + 0;
					int num3 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num3;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					goto IL_0180;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X1 (T)+20]");
				_ = 0;
				serializedData = value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X1 (T)+10]");
				_ = 0;
				return;
				IL_0180:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
				object obj7 = default(object);
				object obj6 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v58 @ X3_v1 (should have been resolved before IL gen)");
				return;
				IL_00e4:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0180;
			}
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x109F064", Offset = "0x109F064", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = Morpeh.EntityProvider::get_Entity(this);\n\tv44 = v21 == 0;\n\tif (v44) goto L_003E;\n\tv25 = Morpeh.EntityProvider::get_Entity(this);\n\tv119 = *([v25 @ X0_v7 (Morpeh.IEntity)]);\n\tv120 = Il2CppMethodInfo;\n\tv108 = *([v119 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v108) goto L_003C;\n\tv164 = *([v119 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0028:\n\tv169 = *([v164 @ X11_v5-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v169) goto L_0048;\n\tv163 = v163 + 1;\n\tv174 = v163 < *([v119 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv146 = ~v174;\n\tv164 = v164 + 0x10;\n\tv130 = ~v146;\n\tif (v130) goto L_0028;\nL_003C:\n\tv181 = 0x8909C4(v25, Il2CppClass<Morpeh.IEntity>, *([v120 @ X21_v3 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_004E;\nL_003E:\n\t*([existOnEntity @ X1 (System.Boolean&)]) = 0;\n\treturnVal2 = this + 0x20;\n\treturn returnVal2;\nL_0048:\n\tv176 = *([v164 @ X11_v5]) + *([v120 @ X21_v3 (Il2CppMethodInfo)+48]);\n\tv177 = v176 << 4;\n\tv178 = v119 + v177;\n\tv181 = v178 + 0x130;\nL_004E:\n\tv184 = 0x8D8294(*([v181 @ X0_v8+8]), Il2CppMethodInfo, *([v120 @ X21_v3 (Il2CppMethodInfo)+48]), v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv56 = *([v184 @ X0_v10]);\n\t// 90 IndirectJump v56 @ X3_v1, v25 @ X0_v7 (Morpeh.IEntity), v25 @ X0_v7 (Morpeh.IEntity), existOnEntity @ X1 (System.Boolean&), v184 @ X0_v10, v56 @ X3_v1, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ref T GetData(out bool existOnEntity)
		{
			//IL_0048: Expected I, but got O
			//IL_0089: Expected O, but got I
			//IL_0127: Unknown result type (might be due to invalid IL or missing references)
			//IL_012c: Expected O, but got Unknown
			//IL_0149: Expected O, but got I
			//IL_0158: Expected O, but got I
			//IL_00d5: Expected O, but got I
			existOnEntity = default(bool);
			IEntity entity = base.Entity;
			if (entity != null)
			{
				IEntity entity2 = base.Entity;
				IntPtr intPtr = (IntPtr)entity2;
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ee;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ee;
				}
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X21_v3 (Il2CppMethodInfo)+48]");
				object obj3 = obj2 + 0;
				int num3 = (int)((long)(IntPtr)obj3 << 4);
				object obj4 = (long)intPtr + (long)num3;
				object obj5 = (long)(IntPtr)obj4 + 304L;
				goto IL_017f;
			}
			ref bool reference = ref *(bool*)null;
			return ref *(T*)((long)(IntPtr)this + 32L);
			IL_017f:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
			object obj7 = default(object);
			object obj6 = obj7;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X3_v1 (should have been resolved before IL gen)");
			return ref *(T*)null;
			IL_00ee:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_017f;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x109F158", Offset = "0x109F158", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Morpeh.EntityProvider::get_Entity(this);\n\tv42 = this + 0x20;\n\tv44 = *([v19 @ X0_v4 (Morpeh.IEntity)]);\n\tv45 = Il2CppMethodInfo;\n\tv49 = *([v44 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]) == 0;\n\tif (v49) goto L_0037;\n\tv154 = *([v44 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+B0]) + 8;\nL_0023:\n\tv159 = *([v154 @ X11_v5-8]) == Il2CppClass<Morpeh.IEntity>;\n\tif (v159) goto L_003A;\n\tv153 = v153 + 1;\n\tv164 = v153 < *([v44 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]);\n\tv136 = ~v164;\n\tv154 = v154 + 0x10;\n\tv120 = ~v136;\n\tif (v120) goto L_0023;\nL_0037:\n\tv171 = 0x8909C4(v19, Il2CppClass<Morpeh.IEntity>, *([v45 @ X21_v2 (Il2CppMethodInfo)+48]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0040;\nL_003A:\n\tv166 = *([v154 @ X11_v5]) + *([v45 @ X21_v2 (Il2CppMethodInfo)+48]);\n\tv167 = v166 << 4;\n\tv168 = v44 + v167;\n\tv171 = v168 + 0x130;\nL_0040:\n\tv174 = 0x8D8294(*([v171 @ X0_v5+8]), Il2CppMethodInfo, *([v45 @ X21_v2 (Il2CppMethodInfo)+48]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv56 = *([v174 @ X0_v7]);\n\t// 76 IndirectJump v56 @ X3_v1, v19 @ X0_v4 (Morpeh.IEntity), v19 @ X0_v4 (Morpeh.IEntity), v42 @ X20_v2, v174 @ X0_v7, v56 @ X3_v1, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void PreInitialize()
		{
			//IL_001b: Expected O, but got I
			//IL_0023: Expected I, but got O
			//IL_0064: Expected O, but got I
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_010a: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_00b0: Expected O, but got I
			IEntity entity = base.Entity;
			object obj = (long)(IntPtr)this + 32L;
			IntPtr intPtr = (IntPtr)entity;
			IntPtr intPtr2 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c9;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+B0]");
			object obj2 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v2 (Il2CppClass<Morpeh.IEntity>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c9;
			}
			object obj3 = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X21_v2 (Il2CppMethodInfo)+48]");
			object obj4 = obj3 + 0;
			int num3 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)intPtr + (long)num3;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			goto IL_0140;
			IL_00c9:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0140;
			IL_0140:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8294");
			object obj8 = default(object);
			object obj7 = obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x109F224", Offset = "0x109F224", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.EntityProvider::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MonoProvider()
		{
		}
	}
}
