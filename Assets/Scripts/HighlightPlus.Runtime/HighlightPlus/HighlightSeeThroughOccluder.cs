using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000038")]
	public class HighlightSeeThroughOccluder : MonoBehaviour
	{
		[Token(Token = "0x4000312")]
		[FieldOffset(Offset = "0x20")]
		public OccluderMode mode;

		[Token(Token = "0x4000313")]
		[FieldOffset(Offset = "0x24")]
		public DetectionMethod detectionMethod;

		[NonSerialized]
		[Token(Token = "0x4000314")]
		[FieldOffset(Offset = "0x28")]
		public MeshData[] meshData;

		[Token(Token = "0x4000315")]
		[FieldOffset(Offset = "0x30")]
		private List<Renderer> rr;

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x772F560", Offset = "0x772F560", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_gameObject(this);\n\tv16 = UnityEngine.GameObject::get_activeInHierarchy(v13);\n\tv32 = ~v16;\n\tif (v32) goto L_001C;\n\tHighlightPlus.HighlightSeeThroughOccluder::Init(this);\n\treturn;\nL_001C:\n\treturn;\n")]
		private void OnEnable()
		{
			GameObject gameObject = base.gameObject;
			if (gameObject.activeInHierarchy)
			{
				Init();
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x772F5A8", Offset = "0x772F5A8", Length = "0x500")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv73 = this.detectionMethod != 1;\n\tif (v73) goto L_0057;\nL_FFFFFFFF:\n\tv217 = this;\n\tgoto L_01E0;\nL_0057:\n\tv97 = this.rr;\n\tv98 = this.rr == 0;\n\tif (v98) goto L_0073;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v97);\n\tv119 = v97.Count < 1;\n\tif (v119) goto L_0080;\n\tgoto L_0080;\nL_0073:\n\tv123 = new System.Collections.Generic.List`1<UnityEngine.Renderer>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::.ctor(v123);\n\tthis.rr = v123;\nL_0080:\n\tUnityEngine.Component::GetComponentsInChildren(this, this.rr);\n\tv265 = this.rr;\n\t// 137 NewArr v358 @ X0_v13 (HighlightPlus.MeshData[]), typeof(HighlightPlus.MeshData[]), v265.Count (System.Int32)\n\tthis.meshData = v358;\n\tv314 = v265.Count < 1;\n\tif (v314) goto L_01EF;\n\tv542 = 0xB291000 + 0xB28;\nL_FFFFFFFF:\n\tv284 = 0x28;\nL_FFFFFFFF:\n\tv352 = 0;\n\tgoto L_00CB;\nL_00A8:\n\tv631 = UnityEngine.Mesh::get_subMeshCount(v775);\n\t*([v605 @ X27_v23 (HighlightPlus.MeshData[])+v284 @ X25_v8 (System.Int32)]) = v631;\n\tv542 = 0xB291000 + 0xB28;\nL_00CB:\n\tv591 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.rr, v352);\n\tv594 = this.meshData + v284;\n\tv595 = v594 + -8;\n\t*([v595 @ X0_v25]) = v591;\n\tv523 = this.meshData;\n\t*([v523 @ X8_v19 (HighlightPlus.MeshData[])+v284 @ X25_v8 (System.Int32)]) = 1;\n\tv653 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.rr, v352);\n\tv654 = v653 == 0;\n\tif (v654) goto L_0115;\n\tv526 = *([v542 @ X27_v12 (System.Int32)]);\n\tv655 = *([v653 @ X0_v28 (UnityEngine.Renderer)]);\n\tv656 = *([v655 @ X9_v22 (Il2CppClass<UnityEngine.Renderer>)+130]) < *([v526 @ X8_v30+130]);\n\tv657 = ~v656;\n\tv421 = ~v657;\n\tif (v421) goto L_0115;\n\tv360 = *([v526 @ X8_v30+130]) << 3;\n\tv666 = *([v655 @ X9_v22 (Il2CppClass<UnityEngine.Renderer>)+C8]) + v360;\n\tv459 = *([v666 @ X9_v24-8]) == v526;\n\tif (v459) goto L_0171;\nL_0115:\n\tv668 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.rr, v352);\n\tv669 = v668 == 0;\n\tif (v669) goto L_00B7;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v424_asT @ TEMPCOND_v15 (UnityEngine.SkinnedMeshRenderer), typeof(UnityEngine.SkinnedMeshRenderer), v668 @ X0_v31 (UnityEngine.Renderer)\n\tv424 = v424_asT == 0;\n\tif (v424) goto L_00B7;\n\tv498 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.rr, v352);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v425_asT @ TEMPCOND_v17 (UnityEngine.SkinnedMeshRenderer), typeof(UnityEngine.SkinnedMeshRenderer), v498 @ X0_v33 (UnityEngine.SkinnedMeshRenderer)\n\tv425 = v425_asT == 0;\n\tif (v425) goto L_01F2;\n\tv738 = UnityEngine.SkinnedMeshRenderer::get_sharedMesh(v498);\n\tgoto L_0168;\nL_0168:\n\tv704 = UnityEngine.Object::op_Inequality(v738, 0);\n\tv710 = ~v704;\n\tif (v710) goto L_00B7;\n\tgoto L_01A9;\nL_0171:\n\tv500 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.rr, v352);\n\tv723 = UnityEngine.Component::GetComponent(v500);\n\tgoto L_0182;\nL_0182:\n\tv705 = UnityEngine.Object::op_Inequality(v723, 0);\n\tv711 = ~v705;\n\tif (v711) goto L_00B7;\n\tgoto L_0191;\nL_0191:\n\tv741 = UnityEngine.MeshFilter::get_sharedMesh(v723);\n\tgoto L_019A;\nL_019A:\n\tv707 = UnityEngine.Object::op_Inequality(v741, 0);\n\tv713 = ~v707;\n\tif (v713) goto L_00B7;\n\tgoto L_01BE;\nL_01A9:\n\tv605 = this.meshData;\n\tv775 = UnityEngine.SkinnedMeshRenderer::get_sharedMesh(v498);\n\tv764 = v775 == 0;\n\tv518 = ~v764;\n\tif (v518) goto L_00A8;\n\tgoto L_01C7;\nL_01BE:\n\tv605 = this.meshData;\n\tv775 = UnityEngine.MeshFilter::get_sharedMesh(v723);\n\tv765 = v775 == 0;\n\tv506 = ~v765;\n\tif (v506) goto L_00A8;\nL_01C7:\n\tthrow System.NullReferenceException;\nL_FFFFFFFF:\n\tv217 = this;\n\tgoto L_01E0;\nL_01E0:\n\tHighlightPlus.HighlightEffect::RegisterOccluder(v217);\n\treturn;\nL_01EF:\n\treturn;\nL_01F2:\n\tthrow System.InvalidCastException;\nL_003E:\n\tv58 = this.mode == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0057;\nL_00B7:\n\tv352 = v352 + 1;\n\tv284 = v284 + 0x10;\n\tv551 = v265.Count == v352;\n\tif (v551) goto L_FFFFFFFF;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Init()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightSeeThroughOccluder::Init");
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x772FAA8", Offset = "0x772FAA8", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_001D;\nL_001D:\n\tHighlightPlus.HighlightEffect::UnregisterOccluder(this);\n\treturn;\n")]
		private void OnDisable()
		{
			HighlightEffect.UnregisterOccluder(this);
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x772FB30", Offset = "0x772FB30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HighlightSeeThroughOccluder()
		{
		}
	}
}
