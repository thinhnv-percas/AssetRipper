using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759E28", Offset = "0x759E28")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759E28", Offset = "0x759E28")]
	[Token(Token = "0x20002A1")]
	public class GetRaycastAllInfo : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9F3C", Offset = "0x7B9F3C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9F3C", Offset = "0x7B9F3C")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7B9F3C", Offset = "0x7B9F3C")]
		[Token(Token = "0x4001735")]
		[FieldOffset(Offset = "0x50")]
		public FsmArray storeHitObjects;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B9FC0", Offset = "0x7B9FC0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B9FC0", Offset = "0x7B9FC0")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7B9FC0", Offset = "0x7B9FC0")]
		[Token(Token = "0x4001736")]
		[FieldOffset(Offset = "0x58")]
		public FsmArray points;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BA044", Offset = "0x7BA044")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BA044", Offset = "0x7BA044")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7BA044", Offset = "0x7BA044")]
		[Token(Token = "0x4001737")]
		[FieldOffset(Offset = "0x60")]
		public FsmArray normals;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BA0C8", Offset = "0x7BA0C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BA0C8", Offset = "0x7BA0C8")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7BA0C8", Offset = "0x7BA0C8")]
		[Token(Token = "0x4001738")]
		[FieldOffset(Offset = "0x68")]
		public FsmArray distances;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BA14C", Offset = "0x7BA14C")]
		[Token(Token = "0x4001739")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000D18")]
		[Address(RVA = "0xA334F4", Offset = "0xA334F4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.storeHitObjects = 0;\n\tthis.normals = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			storeHitObjects = null;
			normals = null;
		}

		[Token(Token = "0x6000D19")]
		[Address(RVA = "0xA33504", Offset = "0xA33504", Length = "0x384")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EC86A8]);\n\tv33 = *([v32 @ X8_v63]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021E04]) = v52;\nL_001E:\n\tv57 = v56.RaycastAllHitInfo;\n\tv58 = v56.RaycastAllHitInfo == 0;\n\tif (v58) goto L_0159;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.storeHitObjects, v57.Length);\n\tv283 = v360.RaycastAllHitInfo;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.points, v283.Length);\n\tv284 = v517.RaycastAllHitInfo;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.normals, v284.Length);\n\tv285 = v519.RaycastAllHitInfo;\n\tHutongGames.PlayMaker.FsmArray::Resize(this.distances, v285.Length);\n\tv534 = v521.RaycastAllHitInfo;\nL_005D:\n\tv63 = v144 >= v534.Length;\n\tif (v63) goto L_0159;\n\tv459 = HutongGames.PlayMaker.FsmArray::get_Values(this.storeHitObjects);\n\tv481 = v537.RaycastAllHitInfo;\n\tv538 = v144 < v481.Length;\n\tv242 = ~v538;\n\tif (v242) goto L_015A;\n\tv539 = v144 * 0x2C;\n\tv286 = v481 + v539;\n\tv540 = v286 + 0x20;\n\tv269 = 0x164C7C8(v540, 0, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv460 = UnityEngine.Component::get_gameObject(v269);\n\tv553 = v460 == 0;\n\tif (v553) goto L_008B;\n\t// 135 IsInst v420 @ X0_v53, typeof(System.Object), v460 @ X0_v23 (UnityEngine.GameObject)\nL_008B:\n\tv556 = v144 < v459.Length;\n\tv243 = ~v556;\n\tif (v243) goto L_015A;\n\tv459[v144 @ X23_v8 (System.Int32)] = v460;\n\tv461 = HutongGames.PlayMaker.FsmArray::get_Values(this.points);\n\tv482 = v558.RaycastAllHitInfo;\n\tv559 = v144 < v482.Length;\n\tv404 = ~v559;\n\tif (v404) goto L_015A;\n\tv560 = v144 * 0x2C;\n\tv483 = v482 + v560;\n\tv561 = v483 + 0x20;\n\tv563 = 0x164C878(v561, 0, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t// 184 Box v462 @ X0_v30, typeof(UnityEngine.Vector3), &v42 @ V0\n\tv565 = v462 == 0;\n\tif (v565) goto L_00C5;\n\t// 193 IsInst v421 @ X0_v51, typeof(System.Object), v462 @ X0_v30\nL_00C5:\n\tv568 = v144 < v461.Length;\n\tv244 = ~v568;\n\tif (v244) goto L_015A;\n\tv461[v144 @ X23_v8 (System.Int32)] = v462;\n\tv463 = HutongGames.PlayMaker.FsmArray::get_Values(this.normals);\n\tv484 = v570.RaycastAllHitInfo;\n\tv571 = v144 < v484.Length;\n\tv405 = ~v571;\n\tif (v405) goto L_015A;\n\tv572 = v144 * 0x2C;\n\tv485 = v484 + v572;\n\tv573 = v485 + 0x20;\n\tv575 = 0x164C884(v573, 0, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t// 242 Box v464 @ X0_v37, typeof(UnityEngine.Vector3), &v42 @ V0\n\tv577 = v464 == 0;\n\tif (v577) goto L_00FF;\n\t// 251 IsInst v422 @ X0_v49, typeof(System.Object), v464 @ X0_v37\nL_00FF:\n\tv580 = v144 < v463.Length;\n\tv245 = ~v580;\n\tif (v245) goto L_015A;\n\tv463[v144 @ X23_v8 (System.Int32)] = v464;\n\tv465 = HutongGames.PlayMaker.FsmArray::get_Values(this.distances);\n\tv486 = v582.RaycastAllHitInfo;\n\tv583 = v144 < v486.Length;\n\tv406 = ~v583;\n\tif (v406) goto L_015A;\n\tv584 = v144 * 0x2C;\n\tv487 = v486 + v584;\n\tv585 = v487 + 0x20;\n\tv587 = 0x164C890(v585, 0, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\t// 298 Box v466 @ X0_v44, typeof(System.Single), &v42 @ V0\n\tv589 = v466 == 0;\n\tif (v589) goto L_0137;\n\t// 307 IsInst v423 @ X0_v47, typeof(System.Object), v466 @ X0_v44\nL_0137:\n\tv592 = v144 < v465.Length;\n\tv445 = ~v592;\n\tif (v445) goto L_015A;\n\tv465[v144 @ X23_v8 (System.Int32)] = v466;\n\tv144 = v144 + 1;\n\tv534 = v595.RaycastAllHitInfo;\n\tv596 = v595.RaycastAllHitInfo == 0;\n\tv467 = ~v596;\n\tif (v467) goto L_005D;\n\tthrow System.NullReferenceException;\nL_0159:\n\treturn;\nL_015A:\n\tv512 = new System.IndexOutOfRangeException();\n\tgoto L_0160;\n\tv294 = new System.NullReferenceException();\n\tv436 = new System.ArrayTypeMismatchException();\nL_0160:\n\tthrow v511;\n// 255 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void StoreRaycastAllInfo()
		{
			//IL_00f1: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_01f6: Expected O, but got I
			//IL_0205: Expected O, but got I
			//IL_02f6: Expected O, but got I
			//IL_0305: Expected O, but got I
			//IL_03f6: Expected O, but got I
			//IL_0405: Expected O, but got I
			//IL_041d: Expected F4, but got O
			RaycastHit[] raycastAllHitInfo = RaycastAll.RaycastAllHitInfo;
			if (RaycastAll.RaycastAllHitInfo == null)
			{
				return;
			}
			storeHitObjects.Resize(raycastAllHitInfo.Length);
			RaycastHit[] raycastAllHitInfo2 = RaycastAll.RaycastAllHitInfo;
			points.Resize(raycastAllHitInfo2.Length);
			RaycastHit[] raycastAllHitInfo3 = RaycastAll.RaycastAllHitInfo;
			normals.Resize(raycastAllHitInfo3.Length);
			RaycastHit[] raycastAllHitInfo4 = RaycastAll.RaycastAllHitInfo;
			distances.Resize(raycastAllHitInfo4.Length);
			RaycastHit[] raycastAllHitInfo5 = RaycastAll.RaycastAllHitInfo;
			int num = 0;
			Component component = default(Component);
			object obj7 = default(object);
			while (true)
			{
				if (num < raycastAllHitInfo5.Length)
				{
					object[] values = storeHitObjects.Values;
					RaycastHit[] raycastAllHitInfo6 = RaycastAll.RaycastAllHitInfo;
					if (num >= raycastAllHitInfo6.Length)
					{
						break;
					}
					int num2 = num * 44;
					object obj = (long)(IntPtr)raycastAllHitInfo6 + (long)num2;
					object obj2 = (long)(IntPtr)obj + 32L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
					GameObject gameObject = component.gameObject;
					if ((object)gameObject != null)
					{
						object obj3 = gameObject as object;
					}
					if (num >= values.Length)
					{
						break;
					}
					values[num] = gameObject;
					object[] values2 = points.Values;
					RaycastHit[] raycastAllHitInfo7 = RaycastAll.RaycastAllHitInfo;
					if (num >= raycastAllHitInfo7.Length)
					{
						break;
					}
					int num3 = num * 44;
					object obj4 = (long)(IntPtr)raycastAllHitInfo7 + (long)num3;
					object obj5 = (long)(IntPtr)obj4 + 32L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
					object obj6 = (Vector3)obj7;
					if (obj6 != null)
					{
						object obj8 = obj6 as object;
					}
					if (num >= values2.Length)
					{
						break;
					}
					values2[num] = obj6;
					object[] values3 = normals.Values;
					RaycastHit[] raycastAllHitInfo8 = RaycastAll.RaycastAllHitInfo;
					if (num >= raycastAllHitInfo8.Length)
					{
						break;
					}
					int num4 = num * 44;
					object obj9 = (long)(IntPtr)raycastAllHitInfo8 + (long)num4;
					object obj10 = (long)(IntPtr)obj9 + 32L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
					object obj11 = (Vector3)obj7;
					if (obj11 != null)
					{
						object obj12 = obj11 as object;
					}
					if (num >= values3.Length)
					{
						break;
					}
					values3[num] = obj11;
					object[] values4 = distances.Values;
					RaycastHit[] raycastAllHitInfo9 = RaycastAll.RaycastAllHitInfo;
					if (num >= raycastAllHitInfo9.Length)
					{
						break;
					}
					int num5 = num * 44;
					object obj13 = (long)(IntPtr)raycastAllHitInfo9 + (long)num5;
					object obj14 = (long)(IntPtr)obj13 + 32L;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
					object obj15 = (float)obj7;
					if (obj15 != null)
					{
						object obj16 = obj15 as object;
					}
					if (num >= values4.Length)
					{
						break;
					}
					values4[num] = obj15;
					num++;
					raycastAllHitInfo5 = RaycastAll.RaycastAllHitInfo;
					if (RaycastAll.RaycastAllHitInfo == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000D1A")]
		[Address(RVA = "0xA33888", Offset = "0xA33888", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRaycastAllInfo::StoreRaycastAllInfo(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			StoreRaycastAllInfo();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D1B")]
		[Address(RVA = "0xA338C4", Offset = "0xA338C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GetRaycastAllInfo::StoreRaycastAllInfo(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			StoreRaycastAllInfo();
		}

		[Token(Token = "0x6000D1C")]
		[Address(RVA = "0xA338C8", Offset = "0xA338C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetRaycastAllInfo()
		{
		}
	}
}
