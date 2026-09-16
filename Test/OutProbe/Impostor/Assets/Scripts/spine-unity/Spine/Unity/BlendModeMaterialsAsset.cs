using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[CreateAssetMenu(menuName = "Spine/SkeletonData Modifiers/Blend Mode Materials", order = 200)]
	[Token(Token = "0x20000B1")]
	public class BlendModeMaterialsAsset : SkeletonDataModifierAsset
	{
		[Token(Token = "0x20000B2")]
		private class AtlasMaterialCache : IDisposable
		{
			[Token(Token = "0x400042B")]
			[FieldOffset(Offset = "0x10")]
			private readonly Dictionary<KeyValuePair<AtlasPage, Material>, AtlasPage> cache;

			[Token(Token = "0x60006A4")]
			[Address(RVA = "0x1570670", Offset = "0x1570670", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Spine.AtlasRegion::Clone(originalRegion);\n\tv24 = Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache::GetAtlasPageWithMaterial(this, originalRegion.page, materialTemplate);\n\tv17.page = v24;\n\treturn v17;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AtlasRegion CloneAtlasRegionWithMaterial(AtlasRegion originalRegion, Material materialTemplate)
			{
				AtlasRegion atlasRegion = originalRegion.Clone();
				AtlasPage atlasPageWithMaterial = GetAtlasPageWithMaterial(originalRegion.page, materialTemplate);
				atlasRegion.page = atlasPageWithMaterial;
				return atlasRegion;
			}

			[Token(Token = "0x60006A5")]
			[Address(RVA = "0x15706D4", Offset = "0x15706D4", Length = "0x22C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, originalPage, materialTemplate, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, originalPage, materialTemplate, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv128 = Il2CppMethodInfo;\n\tv129 = \"il2cpp_codegen_initialize_runtime_metadata\"(v128, originalPage, materialTemplate, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv134 = UnityEngine.Material;\n\tv135 = \"il2cpp_codegen_initialize_runtime_metadata\"(v134, originalPage, materialTemplate, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv188 = \" \";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v188, originalPage, materialTemplate, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A37CE2]) = v44;\nL_0024:\n\tv47 = originalPage == 0;\n\tif (v47) goto L_00A8;\n\tSystem.Collections.Generic.KeyValuePair`2<System.Object, System.Object>::.ctor(&v54 @ stack_-50_v3 (System.Collections.Generic.KeyValuePair`2<System.Object, System.Object>), originalPage, materialTemplate);\n\tv143 = System.Collections.Generic.Dictionary`2::TryGetValue /* +1 sharing this address */(this.cache, v54, 0, &v141 @ stack_-38_v4 (Spine.AtlasPage));\n\tv190 = v141 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_00A3;\n\treturnVal1 = Spine.AtlasPage::Clone(originalPage);\n\tv242 = originalPage.rendererObject == 0;\n\tif (v242) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0069;\n\tv312 = v312_asT == 0;\n\tif (v312) goto L_FFFFFFFF;\n\tgoto L_0069;\nL_0069:\n\tv169 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v169, materialTemplate);\n\tv170 = UnityEngine.Object::get_name(v147);\n\tv318 = UnityEngine.Object::get_name(materialTemplate);\n\tv171 = System.String::Concat(v170, \" \", v318);\n\tUnityEngine.Object::set_name(v169, v171);\n\tv326 = UnityEngine.Material::get_mainTexture(v147);\n\tUnityEngine.Material::set_mainTexture(v169, v326);\n\treturnVal1.rendererObject = v169;\n\tSystem.Collections.Generic.Dictionary`2::Add /* +1 sharing this address */(this.cache, v54, 0, returnVal1);\nL_00A3:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_00A8:\n\tv132 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v132, \"originalPage\");\n\tthrow v132;\n\treturn returnVal2;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private AtlasPage GetAtlasPageWithMaterial(AtlasPage originalPage, Material materialTemplate)
			{
				if (originalPage != null)
				{
					KeyValuePair<object, object> keyValuePair = new KeyValuePair<object, object>(originalPage, materialTemplate);
					Il2CppRuntime.Boundary("MANAGED", "Method not found @133C218 (System.Collections.Generic.Dictionary`2::TryGetValue, and 1 more at this address)");
					AtlasPage atlasPage = default(AtlasPage);
					bool flag = atlasPage == null;
					bool flag2 = !flag;
					AtlasPage atlasPage2 = atlasPage;
					if (!flag2)
					{
						atlasPage2 = originalPage.Clone();
						UnityEngine.Object obj;
						if (originalPage.rendererObject == null)
						{
							obj = null;
						}
						else
						{
							Material material = originalPage.rendererObject as Material;
							obj = (UnityEngine.Object)(((object)material == null) ? null : originalPage.rendererObject);
						}
						Material material2 = new Material(materialTemplate);
						string name = obj.name;
						string name2 = materialTemplate.name;
						string name3 = name + " " + name2;
						material2.name = name3;
						Texture mainTexture = ((Material)obj).mainTexture;
						material2.mainTexture = mainTexture;
						atlasPage2.rendererObject = material2;
						Il2CppRuntime.Boundary("MANAGED", "Method not found @133AAF0 (System.Collections.Generic.Dictionary`2::Add, and 1 more at this address)");
					}
					return atlasPage2;
				}
				ArgumentNullException ex = new ArgumentNullException("originalPage");
				throw ex;
			}

			[Token(Token = "0x60006A6")]
			[Address(RVA = "0x1570900", Offset = "0x1570900", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CE3]) = v33;\nL_001A:\n\tSystem.Collections.Generic.Dictionary`2<System.Collections.Generic.KeyValuePair`2<Spine.AtlasPage, UnityEngine.Material>, Spine.AtlasPage>::Clear(this.cache);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Dispose()
			{
				cache.Clear();
			}

			[Token(Token = "0x60006A7")]
			[Address(RVA = "0x15705F4", Offset = "0x15705F4", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = System.Collections.Generic.Dictionary`2<System.Collections.Generic.KeyValuePair`2<Spine.AtlasPage, UnityEngine.Material>, Spine.AtlasPage>;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37CE4]) = v42;\nL_001A:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.Collections.Generic.KeyValuePair`2<Spine.AtlasPage, UnityEngine.Material>, Spine.AtlasPage>();\n\tSystem.Collections.Generic.Dictionary`2<System.Collections.Generic.KeyValuePair`2<Spine.AtlasPage, UnityEngine.Material>, Spine.AtlasPage>::.ctor(v44);\n\tthis.cache = v44;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AtlasMaterialCache()
			{
				Dictionary<KeyValuePair<AtlasPage, Material>, AtlasPage> dictionary = new Dictionary<KeyValuePair<AtlasPage, Material>, AtlasPage>();
				cache = dictionary;
			}
		}

		[Token(Token = "0x4000427")]
		[FieldOffset(Offset = "0x18")]
		public Material multiplyMaterialTemplate;

		[Token(Token = "0x4000428")]
		[FieldOffset(Offset = "0x20")]
		public Material screenMaterialTemplate;

		[Token(Token = "0x4000429")]
		[FieldOffset(Offset = "0x28")]
		public Material additiveMaterialTemplate;

		[Token(Token = "0x400042A")]
		[FieldOffset(Offset = "0x30")]
		public bool applyAdditiveMaterial;

		[Token(Token = "0x60006A1")]
		[Address(RVA = "0x156FE74", Offset = "0x156FE74", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.BlendModeMaterialsAsset::ApplyMaterials(skeletonData, this.multiplyMaterialTemplate, this.screenMaterialTemplate, this.additiveMaterialTemplate, this.applyAdditiveMaterial);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Apply(SkeletonData skeletonData)
		{
			ApplyMaterials(skeletonData, multiplyMaterialTemplate, screenMaterialTemplate, additiveMaterialTemplate, applyAdditiveMaterial);
		}

		[Token(Token = "0x60006A2")]
		[Address(RVA = "0x156FE8C", Offset = "0x156FE8C", Length = "0x768")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0052;\n\tv40 = Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv67 = Spine.AtlasRegion;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv179 = Il2CppMethodInfo;\n\tv180 = \"il2cpp_codegen_initialize_runtime_metadata\"(v179, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv184 = Il2CppMethodInfo;\n\tv185 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv193 = Il2CppMethodInfo;\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv203 = Il2CppMethodInfo;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv212 = Il2CppMethodInfo;\n\tv213 = \"il2cpp_codegen_initialize_runtime_metadata\"(v212, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv314 = Il2CppMethodInfo;\n\tv315 = \"il2cpp_codegen_initialize_runtime_metadata\"(v314, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv481 = Il2CppMethodInfo;\n\tv482 = \"il2cpp_codegen_initialize_runtime_metadata\"(v481, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv645 = System.IDisposable;\n\tv646 = \"il2cpp_codegen_initialize_runtime_metadata\"(v645, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv739 = Spine.IHasRendererObject;\n\tv740 = \"il2cpp_codegen_initialize_runtime_metadata\"(v739, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv872 = Il2CppMethodInfo;\n\tv873 = \"il2cpp_codegen_initialize_runtime_metadata\"(v872, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1028 = Il2CppMethodInfo;\n\tv1029 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1028, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1138 = Il2CppMethodInfo;\n\tv1139 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1138, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1192 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>;\n\tv1193 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1192, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv1244 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1244, multiplyTemplate, screenTemplate, additiveTemplate, includeAdditiveSlots, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37CE1]) = v56;\nL_0052:\n\tv65 = skeletonData == 0;\n\tif (v65) goto L_027B;\n\tv76 = new Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache();\n\tSpine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache::.ctor(v76);\n\tv187 = new System.Collections.Generic.List`1<Spine.Skin+SkinEntry>();\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>::.ctor(v187);\n\tv206 = skeletonData.slots;\n\tv207 = skeletonData.slots == 0;\n\tif (v207) goto L_028C;\n\tv226 = v206.Count < 1;\n\tif (v226) goto L_FFFFFFFF;\n\tv316 = v206.Items;\n\tv488 = includeAdditiveSlots ^ 1;\nL_0092:\n\tv577 = v316[v582 @ X25_v16 (System.Int32)];\n\tv877 = v577.blendMode - 1;\n\tv879 = v877 == 0;\n\tv885 = v577.blendMode == 0;\n\tif (v885) goto L_01D6;\n\tv935 = v879 & v488;\n\tv1030 = v935 & 1;\n\tv1031 = v1030 == 0;\n\tv1032 = ~v1031;\n\tif (v1032) goto L_01D6;\n\tv1195 = v187._version + 1;\n\tv187._size = 0;\n\tv187._version = v1195;\n\tv584 = v187._size < 1;\n\tif (v584) goto L_00C7;\n\tSystem.Array::Clear(v187._items, 0, v187._size);\nL_00C7:\n\tv1288 = Spine.ExposedList`1<Spine.Skin>::GetEnumerator(skeletonData.skins);\nL_00CE:\n\tv1327 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v572 @ stack_-E0_v17 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv1329 = v1327 == 0;\n\tif (v1329) goto L_00E0;\n\tv633 = v1310 == 0;\n\tif (v633) goto L_01E3;\n\tSpine.Skin::GetAttachments(v1310, v582, v187);\n\tgoto L_00CE;\nL_00E0:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v572 @ stack_-E0_v17 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0275;\n\tgoto L_00F6;\n\tgoto L_FFFFFFFF;\nL_00F6:\n\tv1340 = v577.blendMode == 1;\n\tif (v1340) goto L_FFFFFFFF;\n\tv1350 = v577.blendMode == 2;\n\tif (v1350) goto L_011B;\n\tv1361 = v577.blendMode == 3;\n\tif (v1361) goto L_011B;\n\tgoto L_011B;\nL_011B:\n\tgoto L_0120;\n\tv1372 = \"il2cpp_codegen_runtime_class_init\"(v1369, v1173, v575, v574, includeAdditiveSlots, methodInfo, v43, v44, v570, v563, v561, v48, v49, v50, v51, v52);\nL_0120:\n\tv1070 = UnityEngine.Object::op_Equality(v638, 0);\n\tv1376 = v1070 == 0;\n\tv1072 = ~v1376;\n\tif (v1072) goto L_01D6;\n\tv1382 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>::GetEnumerator(v187);\nL_0133:\n\tv1413 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::MoveNext(&v573 @ stack_-E0_v18 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv1415 = v1413 == 0;\n\tif (v1415) goto L_01C4;\n\t// 313 IsInst v1404 @ X0_v96 (Spine.IHasRendererObject), typeof(Spine.IHasRendererObject), v1383 @ stack_-C0\n\tv1407 = v1404 == 0;\n\tif (v1407) goto L_0133;\n\tgoto L_0167;\n\tv1423 = *([v1418 @ X8_v66+B0]);\n\tv1424 = v1423 + 8;\n\tv1426 = *([v1454 @ X10_v45-8]);\n\tv1469 = v1426 == v1419;\n\tif (v1469) goto L_0160;\n\tv1448 = v1464 - 1;\n\tv1428 = v1454 + 0x10;\n\tv1430 = v1464 != 1;\n\tif (v1430) goto L_FFFFFFFF;\n\tv1449 = v567;\n\tv1450 = 0;\n\tv1451 = 0xB349B4(v1449, v1419, v1450, v574, includeAdditiveSlots, methodInfo, v43, v44, v571, v564, v562, v48, v49, v50, v51, v52);\n\tgoto L_0167;\nL_0160:\n\tv1476 = *([v1454 @ X10_v45]);\n\tv1477 = v1476 << 4;\n\tv1478 = v1418 + v1477;\n\tv1479 = v1478 + 0x138;\nL_0167:\n\tv1483 = Spine.IHasRendererObject::get_RendererObject(v1404);\n\tv635 = v76 == 0;\n\tif (v635) goto L_01E8;\n\tv634 = v1483 == 0;\n\tif (v634) goto L_018E;\n\tgoto L_FFFFFFFF;\n\tv1500 = v1500_asT == 0;\n\tif (v1500) goto L_01E6;\nL_018E:\n\tv1523 = Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache::CloneAtlasRegionWithMaterial(v76, v1483, v638);\n\tgoto L_01BC;\n\tv1531 = *([v1528 @ X8_v70+B0]);\n\tv1532 = v1531 + 8;\n\tv1534 = *([v1561 @ X10_v39-8]);\n\tv1576 = v1534 == v1529;\n\tif (v1576) goto L_01B3;\n\tv1556 = v1571 - 1;\n\tv1536 = v1561 + 0x10;\n\tv1538 = v1571 != 1;\n\tif (v1538) goto L_FFFFFFFF;\n\tv1557 = 1;\n\tv1558 = v567;\n\tv1559 = 0xB349B4(v1558, v1529, v1557, v574, includeAdditiveSlots, methodInfo, v43, v44, v571, v564, v562, v48, v49, v50, v51, v52);\n\tgoto L_01BC;\nL_01B3:\n\tv1582 = *([v1561 @ X10_v39]);\n\tv1583 = v1582 + 1;\n\tv1584 = v1583 << 4;\n\tv1585 = v1528 + v1584;\n\tv1586 = v1585 + 0x138;\nL_01BC:\n\tSpine.IHasRendererObject::set_RendererObject(v1404, v1523);\n\tgoto L_0133;\nL_01C4:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v573 @ stack_-E0_v18 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tgoto L_0277;\n\tgoto L_01D6;\n\tgoto L_FFFFFFFF;\nL_01D6:\n\tv582 = v582 + 1;\n\tv673 = v582 != v206.Count;\n\tif (v673) go\n// ... truncated")]
		public static void ApplyMaterials(SkeletonData skeletonData, Material multiplyTemplate, Material screenTemplate, Material additiveTemplate, bool includeAdditiveSlots)
		{
			//IL_007e: Expected I, but got O
			//IL_0607: Expected I, but got O
			//IL_0617: Expected O, but got I
			//IL_0652: Expected O, but got I
			//IL_0666: Expected O, but got I
			//IL_0675: Expected O, but got I
			//IL_05fa: Expected I, but got O
			//IL_0210: Expected O, but got I4
			//IL_04fa: Expected O, but got I
			//IL_09f6: Expected I, but got O
			//IL_0756: Expected I4, but got O
			//IL_0a21: Expected I, but got O
			//IL_078c: Expected I, but got O
			//IL_079c: Expected O, but got I
			//IL_07d7: Expected O, but got I
			//IL_083b: Expected I4, but got O
			//IL_0849: Expected O, but got I
			//IL_0858: Expected O, but got I
			//IL_07eb: Expected O, but got I
			//IL_07fa: Expected O, but got I
			AtlasMaterialCache atlasMaterialCache;
			List<Skin.SkinEntry> list;
			nint num;
			ExposedList<object>.Enumerator enumerator3;
			Material material;
			Material material3;
			AtlasMaterialCache atlasMaterialCache2;
			int num7;
			nint num6;
			ExposedList<object>.Enumerator enumerator;
			Material material2 = default(Material);
			Material material4 = default(Material);
			Material material5;
			if (skeletonData != null)
			{
				atlasMaterialCache = new AtlasMaterialCache();
				list = new List<Skin.SkinEntry>();
				ExposedList<SlotData> slots = skeletonData.Slots;
				if (skeletonData.Slots == null)
				{
					goto IL_0735;
				}
				bool flag = slots.Count < 1;
				enumerator = default(ExposedList<object>.Enumerator);
				num = (nint)typeof(IDisposable);
				if (flag)
				{
					goto IL_08ac;
				}
				SlotData[] items = slots.Items;
				int num2 = (includeAdditiveSlots ? 1 : 0) ^ 1;
				List<Skin.SkinEntry>.Enumerator enumerator2 = default(List<Skin.SkinEntry>.Enumerator);
				enumerator3 = default(ExposedList<object>.Enumerator);
				material = material2;
				material3 = material4;
				int num3 = 0;
				while (true)
				{
					SlotData slotData = items[num3];
					int num4 = (int)(slotData.BlendMode - 1);
					bool flag2 = num4 == 0;
					if (slotData.BlendMode != BlendMode.Normal)
					{
						int num5 = (flag2 ? 1 : 0) & num2;
						if ((num5 & 1) == 0)
						{
							break;
						}
					}
					num3++;
					if (num3 != slots.Count)
					{
						continue;
					}
					goto IL_04ae;
				}
				int version = list._version + 1;
				list._size = 0;
				list._version = version;
				if (list.Count >= 1)
				{
					Array.Clear(list._items, 0, list.Count);
					material = null;
				}
				ExposedList<Skin>.Enumerator enumerator4 = skeletonData.Skins.GetEnumerator();
				material5 = (Material)list.Count;
				ExposedList<object>.Enumerator enumerator5 = default(ExposedList<object>.Enumerator);
				Skin skin = default(Skin);
				while (true)
				{
					if (enumerator5.MoveNext())
					{
						if (skin == null)
						{
							break;
						}
						skin.GetAttachments(num3, list);
						material = null;
						material5 = (Material)(object)list;
						continue;
					}
					enumerator5.Dispose();
					throw new OutOfMemoryException();
				}
				NullReferenceException ex = new NullReferenceException();
				ExposedList<object>.Enumerator enumerator6 = enumerator5;
				enumerator = enumerator5;
				object obj = 0;
				OutOfMemoryException ex2 = (OutOfMemoryException)(object)ex;
				atlasMaterialCache2 = atlasMaterialCache;
				enumerator2.Dispose();
				IHasRendererObject hasRendererObject = default(IHasRendererObject);
				bool flag3 = hasRendererObject == null;
				num6 = 0;
				num = (nint)typeof(IDisposable);
				if (!flag3)
				{
					ex2 = new OutOfMemoryException();
					enumerator6.Dispose();
					num6 = 0;
					num = (nint)typeof(IDisposable);
				}
				if ((nint)obj == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					object obj2 = default(object);
					num7 = (int)obj2;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					material2 = material;
					material4 = material5;
					goto IL_0a26;
				}
				if (atlasMaterialCache2 != null)
				{
					nint num8 = (nint)atlasMaterialCache2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ X8_v15 (Il2CppClass<Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache>)+12E]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ X8_v15 (Il2CppClass<Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache>)+12E]");
					if ((nint)0 == 0)
					{
						goto IL_0822;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1219 @ X8_v15 (Il2CppClass<Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache>)+B0]");
					object obj4 = (nint)0 + (nint)8;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1290 @ X10_v16-8]");
						if (0 == num)
						{
							break;
						}
						object obj5 = (nint)obj3 - 1;
						obj4 = (nint)obj4 + 16;
						bool flag4 = (nint)obj3 != 1;
						obj3 = obj5;
						if (flag4)
						{
							continue;
						}
						goto IL_0822;
					}
					int num9 = obj4 << 4;
					object obj6 = num8 + num9;
					object obj7 = (nint)obj6 + 312;
					goto IL_0a84;
				}
				goto IL_0871;
			}
			ArgumentNullException ex3 = new ArgumentNullException("skeletonData");
			throw ex3;
			IL_0871:
			OutOfMemoryException ex4 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			return;
			IL_0a84:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1316 @ X0_v21+8]");
			num6 = 0;
			((IDisposable)atlasMaterialCache2).Dispose();
			goto IL_0871;
			IL_0735:
			throw list;
			IL_099c:
			((IDisposable)atlasMaterialCache2).Dispose();
			goto IL_0aa2;
			IL_0a26:
			if (atlasMaterialCache2 != null)
			{
				nint num10 = (nint)atlasMaterialCache2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ X8_v6 (Il2CppClass<Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache>)+12E]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ X8_v6 (Il2CppClass<Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_069d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v711 @ X8_v6 (Il2CppClass<Spine.Unity.BlendModeMaterialsAsset+AtlasMaterialCache>)+B0]");
				object obj9 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ X10_v7-8]");
					if (0 != num)
					{
						object obj10 = (nint)obj8 - 1;
						obj9 = (nint)obj9 + 16;
						bool flag5 = (nint)obj8 != 1;
						obj8 = obj10;
						if (flag5)
						{
							continue;
						}
						goto IL_069d;
					}
					break;
				}
				goto IL_099c;
			}
			goto IL_0aa2;
			IL_069d:
			material4 = null;
			goto IL_099c;
			IL_0aa2:
			if (num7 == 0)
			{
				return;
			}
			OutOfMemoryException ex5 = new OutOfMemoryException();
			goto IL_0735;
			IL_04ae:
			object obj12 = default(object);
			object obj11 = obj12;
			Skin skin3 = default(Skin);
			Skin skin2 = skin3;
			enumerator = enumerator3;
			Material material6 = material;
			material5 = material3;
			obj12 = obj11;
			skin3 = skin2;
			material2 = material6;
			material4 = material5;
			num = (nint)typeof(IDisposable);
			goto IL_08ac;
			IL_08ac:
			num7 = 0;
			atlasMaterialCache2 = atlasMaterialCache;
			goto IL_0a26;
			IL_0822:
			material5 = null;
			goto IL_0a84;
		}

		[Token(Token = "0x60006A3")]
		[Address(RVA = "0x15706C4", Offset = "0x15706C4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.applyAdditiveMaterial = 1;\n\tSpine.Unity.SkeletonDataModifierAsset::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BlendModeMaterialsAsset()
		{
			applyAdditiveMaterial = true;
		}
	}
}
