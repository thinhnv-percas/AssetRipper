using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AllIn1SpriteShader
{
	[ExecuteInEditMode]
	[Token(Token = "0x2000013")]
	public class All1CreateUnifiedOutline : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x20")]
		private Material outlineMaterial;

		[SerializeField]
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x28")]
		private Transform outlineParentTransform;

		[Space]
		[Header("Only needed if Sprite (ignored if UI)")]
		[SerializeField]
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x30")]
		private int duplicateOrderInLayer;

		[SerializeField]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x38")]
		private string duplicateSortingLayer;

		[Space]
		[Header("This operation will delete the component")]
		[SerializeField]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x40")]
		private bool createUnifiedOutline;

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3C20A88", Offset = "0x3C20A88", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tgoto L_003F;\nL_003F:\n\tv89 = UnityEngine.Object::op_Equality(this.outlineMaterial, 0);\n\tv180 = ~v89;\n\tif (v180) goto L_0056;\n\tthis.createUnifiedOutline = 0;\nL_0056:\n\tv196 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v196);\n\tv153 = v196;\n\tv209 = UnityEngine.Component::get_transform(this);\n\tAllIn1SpriteShader.All1CreateUnifiedOutline::GetAllChildren(this, v209, &v153 @ stack_-38_v1 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv212 = v196 == 0;\n\tv221 = 0;\n\tif (v212) goto L_00A4;\n\tv219 = System.Collections.Generic.List`1<UnityEngine.Transform>::GetEnumerator(v196);\n\tv228 = v219._list;\n\tv272 = UnityEngine.Component::get_gameObject(v219.Current);\n\tAllIn1SpriteShader.All1CreateUnifiedOutline::CreateOutlineSpriteDuplicate(this, v272);\n\tgoto L_0079;\nL_008A:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v228 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.Transform>));\nL_008D:\n\tv281 = UnityEngine.Component::get_gameObject(this);\n\tAllIn1SpriteShader.All1CreateUnifiedOutline::CreateOutlineSpriteDuplicate(this, v281);\n\tgoto L_0099;\nL_0099:\n\tUnityEngine.Object::DestroyImmediate(this);\n\treturn;\nL_00B1:\n\tv93 = Il2CppMethodInfo != 1;\n\tv172 = v238;\n\tif (v93) goto L_00C3;\n\tv252 = 0x8BF5BC4(v238, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv268 = 0x8BF5BF4(v252, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v228 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv257 = *([v252 @ X0_v19]) == 0;\n\tif (v257) goto L_008D;\n\tv256 = new System.OutOfMemoryException();\n\tv221 = *([v252 @ X0_v19]);\n\tv172 = v256;\n\treturn;\nL_0026:\n\tv228 = 0;\n\tv56 = this.createUnifiedOutline != 1;\n\tif (v56) goto L_004A;\nL_00A4:\n\tv238 = new System.NullReferenceException();\n\tgoto L_00B1;\nL_0079:\n\tv246 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v228 @ stack_-50_v4 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv250 = v246 == 0;\n\tif (v250) goto L_008A;\nL_00C3:\n\tv261 = 0x3176910(&v221 @ stack_-60_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv270 = 0x8BF0368(v172, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = 0xA1B8(v270, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\treturn;\n")]
		private unsafe void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("All1CreateUnifiedOutline::Update");
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3C2103C", Offset = "0x3C2103C", Length = "0x480")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv64 = UnityEngine.GameObject::GetComponent(target);\n\tv171 = UnityEngine.GameObject::GetComponent(target);\n\tgoto L_0042;\nL_0042:\n\tv252 = UnityEngine.Object::op_Inequality(v64, 0);\n\tv258 = v252 == 0;\n\tif (v258) goto L_0053;\n\tgoto L_FFFFFFFF;\nL_0053:\n\tgoto L_0057;\nL_0057:\n\tv302 = UnityEngine.Object::op_Inequality(v171, 0);\n\tv319 = v302 == 0;\n\tif (v319) goto L_0069;\nL_FFFFFFFF:\n\tv104 = 1;\n\tgoto L_009E;\nL_0069:\n\tgoto L_006D;\nL_006D:\n\tv287 = UnityEngine.Object::op_Equality(v64, 0);\n\tv339 = ~v287;\n\tv292 = ~v339;\n\tif (v292) goto L_007C;\n\tgoto L_FFFFFFFF;\nL_007C:\n\tgoto L_0080;\nL_0080:\n\tv289 = UnityEngine.Object::op_Equality(v171, 0);\n\tv354 = ~v289;\n\tv294 = ~v354;\n\tif (v294) goto L_008E;\n\tgoto L_FFFFFFFF;\nL_008E:\n\tv130 = UnityEngine.Component::get_transform(this);\n\tv224 = UnityEngine.Object::Equals(v130, this.outlineParentTransform);\n\tv226 = ~v224;\n\tif (v226) goto L_0171;\nL_FFFFFFFF:\n\tv104 = 0;\n\tv131 = System.String::Concat(v336, \"Outline\");\n\tUnityEngine.Object::set_name(v317, v131);\n\tv353 = UnityEngine.GameObject::get_transform(v317);\n\tv132 = UnityEngine.GameObject::get_transform(target);\n\tv85 = UnityEngine.Transform::get_position(v132);\n\tUnityEngine.Transform::set_position(v353, v85);\n\tv365 = UnityEngine.GameObject::get_transform(v317);\n\tv133 = UnityEngine.GameObject::get_transform(target);\n\tv86 = UnityEngine.Transform::get_rotation(v133);\n\tUnityEngine.Transform::set_rotation(v365, v86);\n\tv371 = UnityEngine.GameObject::get_transform(v317);\n\tv134 = UnityEngine.GameObject::get_transform(target);\n\tv87 = UnityEngine.Transform::get_lossyScale(v134);\n\tUnityEngine.Transform::set_localScale(v371, v87);\n\tgoto L_00F4;\n\tv135 = UnityEngine.GameObject::get_transform(target);\n\tUnityEngine.Transform::set_parent(v138, v135);\n\tv396 = v104 & 1;\n\tv397 = v396 == 0;\n\tv398 = ~v397;\n\tif (v398) goto L_014C;\nL_010D:\n\tv136 = UnityEngine.GameObject::AddComponent(v317);\n\tv137 = UnityEngine.SpriteRenderer::get_sprite(v64);\n\tUnityEngine.SpriteRenderer::set_sprite(v136, v137);\n\tUnityEngine.Renderer::set_sortingOrder(v136, this.duplicateOrderInLayer);\n\tUnityEngine.Renderer::set_sortingLayerName(v136, this.duplicateSortingLayer);\n\tUnityEngine.Renderer::set_material(v136, this.outlineMaterial);\n\tv427 = UnityEngine.SpriteRenderer::get_flipX(v64);\n\tUnityEngine.SpriteRenderer::set_flipX(v136, v427);\n\tv433 = UnityEngine.SpriteRenderer::get_flipY(v64);\n\tUnityEngine.SpriteRenderer::set_flipY(v136, v433);\n\treturn;\nL_0144:\n\tUnityEngine.Transform::set_parent(v138, this.outlineParentTransform);\n\tv394 = v104 & 1;\n\tv395 = v394 == 0;\n\tif (v395) goto L_010D;\nL_014C:\n\tv139 = UnityEngine.GameObject::AddComponent(v317);\n\tUnityEngine.UI.Image::set_sprite(v139, v171.sprite);\n\tv223 = UnityEngine.UI.Image::set_material(v223, this.outlineMaterial);\n\treturn;\nL_0171:\n\treturn;\nL_009E:\n\tv317 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v317);\n\tv336 = UnityEngine.Object::get_name(target);\nL_00F4:\n\tv385 = UnityEngine.Object::op_Equality(this.outlineParentTransform, 0);\n\tv138 = UnityEngine.GameObject::get_transform(v317);\n\tv387 = ~v385;\n\tif (v387) goto L_0144;\n")]
		private void CreateOutlineSpriteDuplicate(GameObject target)
		{
			SpriteRenderer component = target.GetComponent<SpriteRenderer>();
			Image component2 = target.GetComponent<Image>();
			int num;
			if (!(component != null))
			{
				if (component2 != null)
				{
					num = 1;
					goto IL_03b5;
				}
				if (component == null && component2 == null)
				{
					Transform transform = base.transform;
					if (!transform.Equals(outlineParentTransform))
					{
						return;
					}
				}
			}
			num = 0;
			goto IL_03b5;
			IL_029f:
			GameObject gameObject;
			SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
			Sprite sprite = component.sprite;
			spriteRenderer.sprite = sprite;
			spriteRenderer.sortingOrder = duplicateOrderInLayer;
			spriteRenderer.sortingLayerName = duplicateSortingLayer;
			spriteRenderer.material = outlineMaterial;
			bool flipX = component.flipX;
			spriteRenderer.flipX = flipX;
			bool flipY = component.flipY;
			spriteRenderer.flipY = flipY;
			return;
			IL_03b5:
			gameObject = new GameObject();
			string text = target.name;
			string text2 = text + "Outline";
			gameObject.name = text2;
			Transform transform2 = gameObject.transform;
			Transform transform3 = target.transform;
			Vector3 position = transform3.position;
			transform2.position = position;
			Transform transform4 = gameObject.transform;
			Transform transform5 = target.transform;
			Quaternion rotation = transform5.rotation;
			transform4.rotation = rotation;
			Transform transform6 = gameObject.transform;
			Transform transform7 = target.transform;
			Vector3 lossyScale = transform7.lossyScale;
			transform6.localScale = lossyScale;
			bool flag = outlineParentTransform == null;
			Transform transform8 = gameObject.transform;
			if (flag)
			{
				Transform parent = target.transform;
				transform8.parent = parent;
				if ((num & 1) == 0)
				{
					goto IL_029f;
				}
			}
			else
			{
				transform8.parent = outlineParentTransform;
				if ((num & 1) == 0)
				{
					goto IL_029f;
				}
			}
			Image image = gameObject.AddComponent<Image>();
			image.sprite = component2.sprite;
			Image image2 = default(Image);
			image2.material = outlineMaterial;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3C20CE0", Offset = "0x3C20CE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void MissingMaterial()
		{
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3C20CE4", Offset = "0x3C20CE4", Length = "0x358")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv193 = 0xB28F000 + 0x8D0;\n\tv68 = UnityEngine.Transform::GetEnumerator(parent);\n\tgoto L_0042;\nL_003C:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::AddWithResize(*([transforms @ X2 (System.Collections.Generic.List`1<UnityEngine.Transform>&)]), v621);\nL_0040:\n\tAllIn1SpriteShader.All1CreateUnifiedOutline::GetAllChildren(this, v621, transforms);\nL_0042:\n\tv244 = v120 == 0;\n\tif (v244) goto L_012A;\n\tgoto L_006E;\n\tgoto L_00A0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v641_asT @ TEMPCOND_v17 (UnityEngine.Transform), typeof(UnityEngine.Transform), v621 @ X0_v35 (System.Object)\n\tv641 = v641_asT == 0;\nL_FFFFFFFF:\n\t;\n\tif (v641) goto L_0128;\nL_00C2:\n\tv653 = transforms->klass;\n\tv654 = *([transforms @ X2 (System.Collections.Generic.List`1<UnityEngine.Transform>&)]) == 0;\n\tif (v654) goto L_0125;\n\tv661 = v653._version + 1;\n\tv653._version = v661;\n\tv230 = v653._items;\n\tv238 = v653._items == 0;\n\tif (v238) goto L_0125;\n\tv228 = v653.Count;\n\tv662 = v653.Count < v230.Length;\n\tv226 = ~v662;\n\tif (v226) goto L_003C;\n\tv663 = v653.Count + 1;\n\tv653.Count = v663;\n\tv230[v228 @ X10_v16 (System.Int32)] = v621;\n\tgoto L_0040;\nL_00E2:\n\tv389 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\n\tv390 = &v53 @ stack_-60_v1;\n\tv628 = 0x21C11D0(*([v389 @ X8_v20]), System.IDisposable, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v390 @ X20_v9]) = v628;\n\tv400 = v628 == 0;\nL_FFFFFFFF:\n\tv414 = 0;\nL_FFFFFFFF:\n\tv415 = &v53 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv416 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv116 = 0;\nL_FFFFFFFF:\n\tv429 = 0;\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\tv171 = &v53 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv173 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv116 = 0;\nL_FFFFFFFF:\n\tv180 = System.IDisposable;\nL_FFFFFFFF:\n\tv194 = v193;\nL_FFFFFFFF:\n\tv200 = 0;\n\tif (v400) goto L_0116;\nL_00EB:\n\tv431 = *([v628 @ X0_v18]);\n\tv586 = *([v431 @ X8_v8+12E]);\n\tv433 = *([v431 @ X8_v8+12E]) == 0;\n\tif (v433) goto L_010B;\n\tv585 = *([v431 @ X8_v8+B0]) + 8;\n\tv585 = v585 + 0x10;\n\tv550 = v586 - 1;\n\tv530 = v586 != 1;\nL_FFFFFFFF:\n\tv586 = v550;\n\tif (v530) goto L_00F6;\nL_010B:\n\tv553 = 0x220C5E0(v628, *([v193 @ X22_v5 (System.Int32)]), 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\tv522 = v553;\n\tgoto L_0114;\nL_0110:\n\tv624 = *([v585 @ X10_v9]) << 4;\n\tv625 = v431 + v624;\n\tv522 = v625 + 0x138;\nL_FFFFFFFF:\n\tv169 = v414;\n\treturn;\nL_0125:\n\tv357 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_012D;\nL_0128:\n\tv358 = new System.InvalidCastException();\nL_FFFFFFFF:\n\tv169 = 0;\n\tgoto L_012D;\nL_012A:\n\tv249 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_012D;\nL_012D:\n\t// 301 Interrupt\nL_FFFFFFFF:\n\tv171 = &v53 @ stack_-60_v1;\nL_FFFFFFFF:\n\tv173 = &v120 @ stack_-58_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv116 = 0;\nL_0130:\n\tv202 = new System.OutOfMemoryException();\n\tgoto L_0141;\nL_0141:\n\tv259 = v180 != 1;\n\tif (v259) goto L_0153;\n\tv289 = 0x8BF5BC4(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv429 = *([v289 @ X0_v13]);\n\tv368 = 0x8BF5BF4(v289, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv180 = *([v194 @ X22_v3 (System.Int32)]);\n\tv628 = 0x21C11D0(*([v173 @ stack_-70_v3]), *([v194 @ X22_v3 (System.Int32)]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v171 @ stack_-68_v3]) = v628;\n\tv394 = v628 == 0;\n\tv395 = ~v394;\nL_FFFFFFFF:\n\tv414 = v169;\nL_FFFFFFFF:\n\tv415 = v171;\nL_FFFFFFFF:\n\tv416 = v173;\nL_FFFFFFFF:\n\tv116 = *([v289 @ X0_v13]);\n\tif (v395) goto L_00EB;\nL_FFFFFFFF:\n\tv116 = *([v289 @ X0_v13]);\nL_FFFFFFFF:\n\tv194 = v194;\nL_FFFFFFFF:\n\tv200 = *([v289 @ X0_v13]);\n\tgoto L_0116;\nL_0153:\n\tv292 = 0x3173D6C(&v116 @ stack_-78_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv370 = 0x8BF0368(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv387 = 0xA1B8(v370, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0023:\n\tv53 = 0;\nL_006E:\n\tv379 = System.Collections.IEnumerator::MoveNext(v120);\n\tv381 = v379 == 0;\n\tif (v381) goto L_00E2;\nL_00A0:\n\tv621 = System.Collections.IEnumerator::get_Current(v120);\n\tv361 = v621 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v361) goto L_00C2;\nL_0116:\n\tv524 = v200 == 0;\n\tv190 = ~v524;\nL_FFFFFFFF:\n\tv193 = v194;\n\tif (v190) goto L_0130;\nL_00F6:\n\tv591 = *([v585 @ X10_v9-8]) == *([v193 @ X22_v5 (System.Int32)]);\n\tif (v591) goto L_0110;\nL_0114:\n\tv180 = *([v522 @ X8_v9+8]);\n\t*([v522 @ X8_v9])(v520, v628, *([v522 @ X8_v9+8]), v169, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_FFFFFFFF:\n\tv171 = v415;\nL_FFFFFFFF:\n\tv173 = v416;\nL_FFFFFFFF:\n\tv194 = v193;\nL_FFFFFFFF:\n\tv200 = v429;\n\tthrow System.NullReferenceException;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void GetAllChildren(Transform parent, ref List<Transform> transforms)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("All1CreateUnifiedOutline::GetAllChildren");
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3C214BC", Offset = "0x3C214BC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.duplicateOrderInLayer = 0xFFFFFFFFFFFFFF9C;\n\tthis.duplicateSortingLayer = \"Default\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public All1CreateUnifiedOutline()
		{
			duplicateOrderInLayer = -100;
			duplicateSortingLayer = "Default";
		}
	}
}
