using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using MoreMountains.NiceVibrations;
using Morpeh.Globals;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000012")]
	public class VibrationSystem : LateUpdateSystem
	{
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEventInt[] events;

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x16336A4", Offset = "0x16336A4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnAwake()
		{
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x16336A8", Offset = "0x16336A8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC3440]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, deltaTime, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A4DB]) = v42;\nL_0015:\n\tv148 = this.events;\n\tv56 = v148.Length < 1;\n\tif (v56) goto L_0056;\nL_002A:\n\tv150 = v149 < v148.Length;\n\tv151 = ~v150;\n\tif (v151) goto L_006F;\n\tv97 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(v148[v149 @ X20_v6 (System.Int32)]);\n\tv198 = v97 == 0;\n\tv124 = ~v198;\n\tif (v124) goto L_005D;\n\tv149 = v149 + 1;\n\tv67 = v149 >= v148.Length;\n\tif (v67) goto L_0056;\n\tv148 = this.events;\n\tv206 = this.events == 0;\n\tv99 = ~v206;\n\tif (v99) goto L_002A;\n\tthrow System.NullReferenceException;\nL_0056:\n\treturn;\nL_005D:\n\tgoto L_006D;\n\tv207 = *([v202 @ X0_v11+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_006D;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v202, v58, v26, v27, v28, v29, v30, v31, deltaTime, v33, v34, v35, v36, v37, v38, v39);\nL_006D:\n\tMoreMountains.NiceVibrations.MMVibrationManager::Haptic(5, 0);\n\treturn;\nL_006F:\n\tv196 = new System.IndexOutOfRangeException();\n\tthrow v196;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			GlobalEventInt[] array = events;
			if (array.Length < 1)
			{
				return;
			}
			int num = 0;
			while (num < array.Length)
			{
				if (!array[num])
				{
					num++;
					if (num < array.Length)
					{
						array = events;
						if (events == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					return;
				}
				MMVibrationManager.Haptic(HapticTypes.MediumImpact);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x163379C", Offset = "0x163379C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.LateUpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VibrationSystem()
		{
		}
	}
}
