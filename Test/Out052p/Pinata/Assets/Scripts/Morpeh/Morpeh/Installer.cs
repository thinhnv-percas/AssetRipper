using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Utils;
using UnityEngine;

namespace Morpeh
{
	[Token(Token = "0x2000016")]
	public class Installer : WorldViewer
	{
		[Space]
		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x18")]
		public UpdateSystemPair[] updateSystems;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x20")]
		public FixedSystemPair[] fixedUpdateSystems;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x28")]
		public LateSystemPair[] lateUpdateSystems;

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x15F830C", Offset = "0x15F830C", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED3648]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A069]) = v38;\nL_0018:\n\tMorpeh.Installer::AddSystems(this, this.updateSystems);\n\tMorpeh.Installer::AddSystems(this, this.fixedUpdateSystems);\n\tMorpeh.Installer::AddSystems(this, this.lateUpdateSystems);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			AddSystems(updateSystems);
			AddSystems(fixedUpdateSystems);
			AddSystems(lateUpdateSystems);
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x15F8390", Offset = "0x15F8390", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA7230]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A06A]) = v38;\nL_0018:\n\tMorpeh.Installer::RemoveSystems(this, this.updateSystems);\n\tMorpeh.Installer::RemoveSystems(this, this.fixedUpdateSystems);\n\tMorpeh.Installer::RemoveSystems(this, this.lateUpdateSystems);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			RemoveSystems(updateSystems);
			RemoveSystems(fixedUpdateSystems);
			RemoveSystems(lateUpdateSystems);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x9E9BD8", Offset = "0x9E9BD8", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv36 = *([1EE0E08]);\n\tv37 = *([v36 @ X8_v29]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, pairs, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 0 | 1;\n\t*([2021AC5]) = v55;\nL_0029:\n\tv68 = pairs.Length < 1;\n\tif (v68) goto L_0099;\n\tv127 = pairs.Length == 0;\n\tif (v127) goto L_0088;\nL_003E:\n\tv286 = Morpeh.Utils.BasePair`1<T>::get_System(pairs[v125 @ X21_v8 (System.Int32)]);\n\tv290 = Morpeh.Utils.BasePair`1<T>::get_Enabled(pairs[v125 @ X21_v8 (System.Int32)]);\n\tv291 = v286 == 0;\n\tif (v291) goto L_0070;\n\tv293 = v290 == 0;\n\tif (v293) goto L_0070;\n\tgoto L_0057;\n\tv305 = *([v300 @ X0_v16+E0]);\n\tv306 = v305 == 0;\n\tv307 = ~v306;\n\tif (v307) goto L_0057;\n\tv309 = \"il2cpp_codegen_runtime_class_init\"(v300, v209, v77, v75, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0057:\n\tgoto L_005F;\n\tv315 = v85;\n\tv316 = \"il2cpp_codegen_initialize_method\"(v315, v209, v77, v75, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021C3B]) = v83;\nL_005F:\n\tgoto L_006F;\n\tv322 = *([v318 @ X0_v19 (Il2CppClass<Morpeh.World>)+E0]);\n\tv323 = v322 == 0;\n\tv324 = ~v323;\n\t// 99 Jump @b29\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v318, v209, v77, v75, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv326 = Morpeh.World;\nL_006F:\n\tv297 = Morpeh.World::AddSystem(v229.<Default>k__BackingField, v125, v286);\nL_0070:\n\tv125 = v125 + 1;\n\tv154 = v125 >= pairs.Length;\n\tif (v154) goto L_0099;\n\tv304 = v125 < pairs.Length;\n\tv246 = ~v304;\n\tv238 = ~v246;\n\tif (v238) goto L_003E;\nL_0088:\n\tv249 = new System.IndexOutOfRangeException();\n\tthrow v249;\nL_0099:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddSystems<T>(BasePair<T>[] pairs) where T : class, ISystem
		{
			if (pairs.Length < 1)
			{
				return;
			}
			if (pairs.Length != 0)
			{
				int num = 0;
				do
				{
					T system = pairs[num].System;
					bool flag = pairs[num].Enabled;
					if (system != null && flag)
					{
						bool flag2 = World.Default.AddSystem(num, system);
					}
					num++;
					if (num >= pairs.Length)
					{
						return;
					}
				}
				while (num < pairs.Length);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x9E9D4C", Offset = "0x9E9D4C", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv34 = *([1EF23D8]);\n\tv35 = *([v34 @ X8_v26]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, pairs, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 0 | 1;\n\t*([2021AC6]) = v53;\nL_0028:\n\tv66 = pairs.Length < 1;\n\tif (v66) goto L_008D;\n\tv68 = pairs.Length == 0;\n\tif (v68) goto L_007D;\nL_003C:\n\tv246 = Morpeh.Utils.BasePair`1<T>::get_System(pairs[v155 @ X24_v6 (System.Int32)]);\n\tv247 = v246 == 0;\n\tif (v247) goto L_0065;\n\tgoto L_004D;\n\tv257 = *([v248 @ X0_v13+E0]);\n\tv258 = v257 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_004D;\n\tv261 = \"il2cpp_codegen_runtime_class_init\"(v248, v151, v146, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_004D:\n\tgoto L_0055;\n\tv268 = v132;\n\tv269 = \"il2cpp_codegen_initialize_method\"(v268, v151, v146, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t*([2021C3B]) = v84;\nL_0055:\n\tgoto L_0064;\n\tv275 = *([v271 @ X0_v16 (Il2CppClass<Morpeh.World>)+E0]);\n\tv276 = v275 == 0;\n\tv277 = ~v276;\n\t// 89 Jump @b29\n\tv282 = \"il2cpp_codegen_runtime_class_init\"(v271, v151, v146, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv279 = Morpeh.World;\nL_0064:\n\tv254 = Morpeh.World::RemoveSystem(v193.<Default>k__BackingField, v246);\nL_0065:\n\tv155 = v155 + 1;\n\tv96 = v155 >= pairs.Length;\n\tif (v96) goto L_008D;\n\tv267 = v155 < pairs.Length;\n\tv210 = ~v267;\n\tv202 = ~v210;\n\tif (v202) goto L_003C;\nL_007D:\n\tv213 = new System.IndexOutOfRangeException();\n\tthrow v213;\nL_008D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveSystems<T>(BasePair<T>[] pairs) where T : class, ISystem
		{
			if (pairs.Length < 1)
			{
				return;
			}
			if (pairs.Length != 0)
			{
				int num = 0;
				do
				{
					T system = pairs[num].System;
					if (system != null)
					{
						bool flag = World.Default.RemoveSystem(system);
					}
					num++;
					if (num >= pairs.Length)
					{
						return;
					}
				}
				while (num < pairs.Length);
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x15F8414", Offset = "0x15F8414", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Installer()
		{
		}
	}
}
