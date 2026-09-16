using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x755F0C", Offset = "0x755F0C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x755F0C", Offset = "0x755F0C")]
	[Token(Token = "0x20001DE")]
	public class DestroyObjects : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7B0744", Offset = "0x7B0744")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0744", Offset = "0x7B0744")]
		[Token(Token = "0x4001432")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray gameObjects;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B07C4", Offset = "0x7B07C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B07C4", Offset = "0x7B07C4")]
		[Token(Token = "0x4001433")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat delay;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B0818", Offset = "0x7B0818")]
		[Token(Token = "0x4001434")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool detachChildren;

		[Token(Token = "0x60009E6")]
		[Address(RVA = "0xA864F0", Offset = "0xA864F0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObjects = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.delay = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObjects = null;
			FsmFloat fsmFloat = 0f;
			delay = fsmFloat;
		}

		[Token(Token = "0x60009E7")]
		[Address(RVA = "0xA86520", Offset = "0xA86520", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1ED77F8]);\n\tv29 = *([v28 @ X8_v27]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202219A]) = v48;\nL_001C:\n\tv52 = HutongGames.PlayMaker.FsmArray::get_Values(this.gameObjects);\n\tv135 = v52 == 0;\n\tif (v135) goto L_00C4;\n\tv117 = HutongGames.PlayMaker.FsmArray::get_Values(this.gameObjects);\n\tv172 = v117.Length;\n\tv188 = v117.Length < 1;\n\tif (v188) goto L_00C4;\nL_0039:\n\tv338 = v68 < v172;\n\tv164 = ~v338;\n\tif (v164) goto L_00C7;\n\tv63 = v117[v68 @ X22_v8 (System.Int32)];\n\tv267 = v117[v68 @ X22_v8 (System.Int32)] == 0;\n\tif (v267) goto L_0059;\n\tv246 = *([v63 @ X21_v8 (UnityEngine.Object)]) != UnityEngine.GameObject;\n\tif (v246) goto L_00CC;\nL_0059:\n\tgoto L_0062;\n\tv347 = *([v343 @ X0_v20+E0]);\n\tv348 = v347 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_0062;\n\tv351 = \"il2cpp_codegen_runtime_class_init\"(v343, v341, v139, v33, v34, v35, v36, v37, v57, v39, v40, v41, v42, v43, v44, v45);\nL_0062:\n\tv354 = UnityEngine.Object::op_Inequality(v117[v68 @ X22_v8 (System.Int32)], 0);\n\tv356 = v354 == 0;\n\tif (v356) goto L_00AA;\n\tv58 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tv371 = v58 < 0;\n\tv108 = ~v371;\n\tv96 = v58 == 0;\n\tv372 = ~v108;\n\tv76 = v372 | v96;\n\tif (v76) goto L_0090;\n\tv378 = HutongGames.PlayMaker.FsmFloat::get_Value(this.delay);\n\tgoto L_008A;\n\tv400 = *([v388 @ X0_v36+E0]);\n\tv401 = v400 == 0;\n\tv402 = ~v401;\n\tif (v402) goto L_008A;\n\tv404 = \"il2cpp_codegen_runtime_class_init\"(v388, v377, v61, v33, v34, v35, v36, v37, v378, v39, v40, v41, v42, v43, v44, v45);\nL_008A:\n\tUnityEngine.Object::Destroy(v117[v68 @ X22_v8 (System.Int32)], v378);\n\tgoto L_009D;\nL_0090:\n\tgoto L_0098;\n\tv379 = *([v373 @ X0_v31+E0]);\n\tv380 = v379 == 0;\n\tv381 = ~v380;\n\tif (v381) goto L_0098;\n\tv383 = \"il2cpp_codegen_runtime_class_init\"(v373, v112, v61, v33, v34, v35, v36, v37, v58, v39, v40, v41, v42, v43, v44, v45);\nL_0098:\n\tUnityEngine.Object::Destroy(v117[v68 @ X22_v8 (System.Int32)]);\nL_009D:\n\tv322 = HutongGames.PlayMaker.FsmBool::get_Value(this.detachChildren);\n\tv367 = v322 == 0;\n\tif (v367) goto L_00AA;\n\tv121 = UnityEngine.GameObject::get_transform(v117[v68 @ X22_v8 (System.Int32)]);\n\tUnityEngine.Transform::DetachChildren(v121);\nL_00AA:\n\tv172 = v117.Length;\n\tv68 = v68 + 1;\n\tv187 = v68 < v117.Length;\n\tif (v187) goto L_0039;\nL_00C4:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv134 = new System.NullReferenceException();\nL_00C7:\n\tv174 = new System.IndexOutOfRangeException();\n\tthrow v174;\nL_00CC:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			object[] values = gameObjects.Values;
			if (values != null)
			{
				object[] values2 = gameObjects.Values;
				int num = values2.Length;
				if (values2.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							UnityEngine.Object obj = (UnityEngine.Object)values2[num2];
							if (values2[num2] == null || (object)obj.GetType() == typeof(GameObject))
							{
								if ((UnityEngine.Object)values2[num2] != null)
								{
									float value = delay.Value;
									bool flag = value < 0f;
									bool flag2 = !flag;
									bool flag3 = value == 0f;
									bool flag4 = !flag2;
									if (!(flag4 || flag3))
									{
										float value2 = delay.Value;
										UnityEngine.Object.Destroy((UnityEngine.Object)values2[num2], value2);
									}
									else
									{
										UnityEngine.Object.Destroy((UnityEngine.Object)values2[num2]);
									}
									if (detachChildren.Value)
									{
										Transform transform = ((GameObject)values2[num2]).transform;
										transform.DetachChildren();
									}
								}
								num = values2.Length;
								num2++;
								continue;
							}
							throw new InvalidCastException();
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < values2.Length);
				}
			}
			Finish();
		}

		[Token(Token = "0x60009E8")]
		[Address(RVA = "0xA866FC", Offset = "0xA866FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DestroyObjects()
		{
		}
	}
}
