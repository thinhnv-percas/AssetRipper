using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePluginInternal;

namespace LunarConsolePlugin
{
	[Token(Token = "0x200000B")]
	internal class CVarChangedDelegateList : BaseList<CVarChangedDelegate>
	{
		[Token(Token = "0x600003A")]
		[Address(RVA = "0x13D458C", Offset = "0x13D458C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE5FC8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, capacity, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028A56]) = v41;\nL_0018:\n\tv45 = new LunarConsolePlugin.CVarChangedDelegate();\n\tv51 = Il2CppMethodInfo;\n\tv45.m_target = 0;\n\tv45.method = Il2CppMethodInfo;\n\tv45.method_ptr = *([v51 @ X9_v3 (Il2CppMethodInfo)]);\n\tLunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::.ctor(this, v45, capacity);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe CVarChangedDelegateList(int capacity)
		{
			CVarChangedDelegate cVarChangedDelegate = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)cVarChangedDelegate).m_target = null;
			((Delegate)cVarChangedDelegate).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<CVar, void>*/)(&NullCVarChangedDelegate);
			((Delegate)cVarChangedDelegate).method_ptr = method_ptr;
			base._002Ector(cVarChangedDelegate, capacity);
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x13D477C", Offset = "0x13D477C", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EF7D98]);\n\tv37 = *([v36 @ X8_v20]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, cvar, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2028A57]) = v55;\nL_0020:\n\tLunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::Lock(this);\n\tv115 = this.list;\n\tv73 = v115._size < 1;\n\tif (v73) goto L_00B6;\n\tv85 = v115 == 0;\n\tif (v85) goto L_0063;\nL_003D:\n\tv215 = v146 < v115._size;\n\tv185 = ~v215;\n\tv153 = ~v185;\n\tif (v153) goto L_004A;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_004A:\n\tv225 = v115._items;\n\tv119 = v225[v146 @ X25_v7 (System.Int32)] == 0;\n\tif (v119) goto L_0065;\n\tLunarConsolePlugin.CVarChangedDelegate::Invoke(v225[v146 @ X25_v7 (System.Int32)], cvar);\nL_0052:\n\tv146 = v146 + 1;\n\tv97 = v146 >= v115._size;\n\tif (v97) goto L_00B6;\n\tv115 = this.list;\n\tv294 = this.list == 0;\n\tv212 = ~v294;\n\tif (v212) goto L_003D;\nL_0063:\n\tthrow System.NullReferenceException;\nL_0065:\n\tthrow System.NullReferenceException;\n\tgoto L_0068;\nL_0068:\n\tX22 = X0;\n\tX23 = X1;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00E6;\n\tX0 = X22;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tX8 = *([X22]);\n\tX0 = *([X26]);\n\tstack[8] = X8;\n\tX1 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BB;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X27]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tif (TEMP) goto L_00C7;\n\tif (TEMP) goto L_00C8;\n\tX23 = *([X20+18]);\n\tif (TEMP) goto L_0092;\n\tX8 = *([X22]);\n\tX1 = *([X8+40]);\n\tX0 = X23;\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00C2;\nL_0092:\n\tX8 = *([X22+18]);\n\tif (TEMP) goto L_00CA;\n\t*([X22+20]) = X23;\n\tX0 = *([X28]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A0;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A0;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A0:\n\tX1 = *([X21]);\n\tX0 = stack[8];\n\tX2 = X22;\n\tLunarConsolePluginInternal.Log::e(X0, X1, X2, X3);\n\tgoto L_0052;\nL_00B6:\n\tLunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::Unlock(this);\n\treturn;\n\tthrow System.NullReferenceException;\nL_00BB:\n\tv198 = 0x6D1E60(8, v139, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv218 = *([v187 @ X22_v2 (System.Collections.Generic.List`1<LunarConsolePlugin.CVarChangedDelegate>)]);\n\t*([v198 @ X0_v5]) = v218;\n\tv220 = 0x1E8A000 + 0x870;\n\tv222 = 0x6D2A00(v198, v220, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00C2:\n\tv287 = new System.ArrayTypeMismatchException();\n\tthrow v287;\nL_00C7:\n\tthrow System.NullReferenceException;\nL_00C8:\n\t;\nL_00CA:\n\tv297 = new System.IndexOutOfRangeException();\n\tthrow v297;\n\tgoto L_00E6;\n\tgoto L_00D3;\n\t// 208 Jump @b56\n\t// 209 Jump @b56\n\t// 210 Jump @b56\nL_00D3:\n\tX23 = X1;\n\tX22 = X0;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00E6;\n\tX0 = 0x846AA4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 216 Jump @b56\nL_00E6:\n\tif (1) goto L_0100;\n\tv302 = 0x6D2BC0(v299, 0, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv304 = *([v302 @ X0_v20]);\n\tv305 = 0x6D2490(v302, 0, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tLunarConsolePluginInternal.BaseList`1<LunarConsolePlugin.CVarChangedDelegate>::Unlock(this, Il2CppMethodInfo);\n\tv310 = v304 == 0;\n\tv273 = ~v310;\n\tif (v273) goto L_0104;\n\treturn;\nL_0100:\n\tv303 = 0x6D2380(v299, 0, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0104:\n\tthrow System.TypeLoadException;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void NotifyValueChanged(CVar cvar)
		{
			Lock();
			List<CVarChangedDelegate> list = base.list;
			if (list.Count >= 1)
			{
				bool flag = list == null;
				int num = 0;
				if (flag)
				{
					goto IL_013e;
				}
				while (true)
				{
					if (num >= list.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					CVarChangedDelegate[] items = list._items;
					if (items[num] != null)
					{
						items[num](cvar);
						num++;
						if (num >= list.Count)
						{
							break;
						}
						list = base.list;
						if (base.list != null)
						{
							continue;
						}
						goto IL_013e;
					}
					throw new NullReferenceException();
				}
			}
			Unlock();
			return;
			IL_013e:
			throw new NullReferenceException();
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x13D52D0", Offset = "0x13D52D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void NullCVarChangedDelegate(CVar cvar)
		{
		}
	}
}
