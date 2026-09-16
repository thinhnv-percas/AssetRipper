using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744F24", Offset = "0x744F24")]
	[ExecuteInEditMode]
	[Token(Token = "0x200007C")]
	public class ObiRopeChainRenderer : MonoBehaviour
	{
		[Token(Token = "0x4000212")]
		private static ProfilerMarker m_UpdateChainRopeRendererChunksPerfMarker;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x18")]
		public List<GameObject> linkInstances;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x746A54", Offset = "0x746A54")]
		[SerializeField]
		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x20")]
		private bool randomizeLinks;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x24")]
		public Vector3 linkScale;

		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x30")]
		public List<GameObject> linkPrefabs;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746AA0", Offset = "0x746AA0")]
		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x38")]
		public float twistAnchor;

		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x3C")]
		public float sectionTwist;

		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x40")]
		private ObiPathFrame frame;

		[Token(Token = "0x170000C9")]
		public bool RandomizeLinks
		{
			[Token(Token = "0x60004D6")]
			[Address(RVA = "0xC3AD98", Offset = "0xC3AD98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.randomizeLinks;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RandomizeLinks;
			}
			[Token(Token = "0x60004D7")]
			[Address(RVA = "0xC3ADA0", Offset = "0xC3ADA0", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EF9F68]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20231D1]) = v41;\nL_001A:\n\tv47 = this.randomizeLinks == 0;\n\tv52 = ~v47;\n\tv54 = v52 ^ value;\n\tv56 = v54 == 0;\n\tif (v56) goto L_003C;\n\tthis.randomizeLinks = value;\n\tv62 = UnityEngine.Component::GetComponent(this);\n\tObi.ObiRopeChainRenderer::CreateChainLinkInstances(this, v62);\n\treturn;\nL_003C:\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				bool flag = !RandomizeLinks;
				bool flag2 = !flag;
				if (flag2 ^ value)
				{
					randomizeLinks = value;
					ObiRopeBase component = GetComponent<ObiRopeBase>();
					CreateChainLinkInstances(component);
				}
			}
		}

		[Token(Token = "0x60004D5")]
		[Address(RVA = "0xC3AC54", Offset = "0xC3AC54", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiRopeChainRenderer::ClearChainLinkInstances(this);\n\treturn;\n")]
		private void Awake()
		{
			ClearChainLinkInstances();
		}

		[Token(Token = "0x60004D8")]
		[Address(RVA = "0xC3B048", Offset = "0xC3B048", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ECEF38]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231D2]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnInterpolate(v45, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			ObiRopeBase component = GetComponent<ObiRopeBase>();
			ObiActor.ActorCallback value = UpdateRenderer;
			component.OnInterpolate += value;
		}

		[Token(Token = "0x60004D9")]
		[Address(RVA = "0xC3B0F0", Offset = "0xC3B0F0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF88A8]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231D3]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnInterpolate(v45, v51);\n\tObi.ObiRopeChainRenderer::ClearChainLinkInstances(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			ObiRopeBase component = GetComponent<ObiRopeBase>();
			ObiActor.ActorCallback value = UpdateRenderer;
			component.OnInterpolate -= value;
			ClearChainLinkInstances();
		}

		[Token(Token = "0x60004DA")]
		[Address(RVA = "0xC3AC58", Offset = "0xC3AC58", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EE6818]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20231D4]) = v44;\nL_0016:\n\tv196 = this.linkInstances;\n\tv46 = this.linkInstances == 0;\n\tif (v46) goto L_008C;\nL_0026:\n\tv116 = v96 >= v196._size;\n\tif (v116) goto L_0082;\n\tv163 = v196._size < v96;\n\tv164 = ~v163;\n\tv165 = v196._size - v96;\n\tv167 = v165 == 0;\n\tv172 = ~v167;\n\tv173 = v164 & v172;\n\tif (v173) goto L_0036;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0036:\n\tv201 = v196._items;\n\tgoto L_0047;\n\tv209 = *([v202 @ X0_v6+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0047;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v202, v61, v59, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0047:\n\tv218 = UnityEngine.Object::op_Inequality(v201[v96 @ X21_v3 (System.Int32)], 0);\n\tv220 = v218 == 0;\n\tif (v220) goto L_0070;\n\tv221 = this.linkInstances;\n\tv244 = v221._size < v96;\n\tv235 = ~v244;\n\tv234 = v221._size - v96;\n\tv232 = v234 == 0;\n\tv245 = ~v232;\n\tv227 = v235 & v245;\n\tif (v227) goto L_005E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005E:\n\tv250 = v221._items;\n\tgoto L_006E;\n\tv255 = *([v251 @ X0_v15+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_006E;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v251, v217, v60, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006E:\n\tUnityEngine.Object::DestroyImmediate(v250[v96 @ X21_v3 (System.Int32)]);\nL_0070:\n\tv96 = v96 + 1;\n\tv242 = this.linkInstances == 0;\n\tv101 = ~v242;\n\tif (v101) goto L_0026;\n\tthrow System.NullReferenceException;\nL_0082:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Clear(v196);\n\treturn;\nL_008C:\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearChainLinkInstances()
		{
			List<GameObject> list = linkInstances;
			if (linkInstances == null)
			{
				return;
			}
			int num = 0;
			while (num < list.Count)
			{
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				GameObject[] items = list._items;
				if (items[num] != null)
				{
					List<GameObject> list2 = linkInstances;
					bool flag5 = list2.Count < num;
					bool flag6 = !flag5;
					int num3 = list2.Count - num;
					bool flag7 = num3 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					GameObject[] items2 = list2._items;
					UnityEngine.Object.DestroyImmediate(items2[num]);
				}
				num++;
				bool flag9 = linkInstances == null;
				bool flag10 = !flag9;
				list = linkInstances;
				if (!flag10)
				{
					throw new NullReferenceException();
				}
			}
			list.Clear();
		}

		[Token(Token = "0x60004DB")]
		[Address(RVA = "0xC3AE34", Offset = "0xC3AE34", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv32 = *([1ECDBB8]);\n\tv33 = *([v32 @ X8_v25]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, rope, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20231D5]) = v51;\nL_001B:\n\tObi.ObiRopeChainRenderer::ClearChainLinkInstances(this);\n\tv53 = this.linkPrefabs;\n\tv66 = v53._size < 1;\n\tif (v66) goto L_00DA;\n\tv215 = Obi.ObiActor::get_particleCount(rope);\n\tv188 = v215 < 1;\n\tif (v188) goto L_00DA;\nL_0044:\n\tv314 = this.linkPrefabs;\n\tv308 = ~this.randomizeLinks;\n\tif (v308) goto L_0054;\n\tv148 = UnityEngine.Random::Range(0, v314._size);\n\tv314 = this.linkPrefabs;\n\tv313 = this.linkPrefabs == 0;\n\tv154 = ~v313;\n\tif (v154) goto L_0058;\n\tgoto L_00DC;\nL_0054:\n\tv310 = v89 / v314._size;\n\tv311 = v310 * v314._size;\n\tv165 = v89 - v311;\nL_0058:\n\tv320 = v314._size < v165;\n\tv144 = ~v320;\n\tv139 = v314._size - v165;\n\tv129 = v139 == 0;\n\tv321 = ~v129;\n\tv104 = v144 & v321;\n\tif (v104) goto L_0066;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0066:\n\tv324 = v314._items;\n\tgoto L_0077;\n\tv330 = *([v325 @ X0_v13+E0]);\n\tv331 = v330 == 0;\n\tv332 = ~v331;\n\tif (v332) goto L_0077;\n\tv334 = \"il2cpp_codegen_runtime_class_init\"(v325, v98, v315, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0077:\n\tv149 = UnityEngine.Object::op_Inequality(v324[v165 @ X21_v7 (System.Int32)], 0);\n\tv339 = v149 == 0;\n\tif (v339) goto L_00BE;\n\tv82 = this.linkPrefabs;\n\tv347 = v82._size < v165;\n\tv145 = ~v347;\n\tv140 = v82._size - v165;\n\tv130 = v140 == 0;\n\tv349 = ~v130;\n\tv105 = v145 & v349;\n\tif (v105) goto L_008F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008F:\n\tv353 = v82._items;\n\tgoto L_009F;\n\tv359 = *([v354 @ X0_v22+E0]);\n\tv360 = v359 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_009F;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v354, v99, v87, v68, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_009F:\n\tv264 = UnityEngine.Object::Instantiate(v353[v165 @ X21_v7 (System.Int32)]);\n\tv370 = UnityEngine.GameObject::get_transform(v264);\n\tv150 = UnityEngine.Component::get_transform(rope);\n\tUnityEngine.Transform::SetParent(v370, v150, 0);\n\tUnityEngine.Object::set_hideFlags(v264, 0x3D);\n\tUnityEngine.GameObject::SetActive(v264, 0);\nL_00BE:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(this.linkInstances, v175);\n\tv89 = v89 + 1;\n\tv214 = Obi.ObiActor::get_particleCount(rope);\n\tv187 = v89 < v214;\n\tif (v187) goto L_0044;\nL_00DA:\n\treturn;\nL_00DC:\n\tthrow System.NullReferenceException;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateChainLinkInstances(ObiRopeBase rope)
		{
			ClearChainLinkInstances();
			List<GameObject> list = linkPrefabs;
			if (list.Count < 1)
			{
				return;
			}
			int particleCount = rope.particleCount;
			if (particleCount < 1)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				List<GameObject> list2 = linkPrefabs;
				int num3;
				if (RandomizeLinks)
				{
					int num2 = UnityEngine.Random.Range(0, list2.Count);
					list2 = linkPrefabs;
					bool flag = linkPrefabs == null;
					bool flag2 = !flag;
					num3 = num2;
					if (!flag2)
					{
						break;
					}
				}
				else
				{
					int num4 = num / list2.Count;
					int num5 = num4 * list2.Count;
					num3 = num - num5;
				}
				bool flag3 = list2.Count < num3;
				bool flag4 = !flag3;
				int num6 = list2.Count - num3;
				bool flag5 = num6 == 0;
				bool flag6 = !flag5;
				if (!(flag4 && flag6))
				{
					throw new ArgumentOutOfRangeException();
				}
				GameObject[] items = list2._items;
				bool flag7 = items[num3] != null;
				bool flag8 = !flag7;
				GameObject item = null;
				if (!flag8)
				{
					List<GameObject> list3 = linkPrefabs;
					bool flag9 = list3.Count < num3;
					bool flag10 = !flag9;
					int num7 = list3.Count - num3;
					bool flag11 = num7 == 0;
					bool flag12 = !flag11;
					if (!(flag10 && flag12))
					{
						throw new ArgumentOutOfRangeException();
					}
					GameObject[] items2 = list3._items;
					GameObject gameObject = UnityEngine.Object.Instantiate(items2[num3]);
					Transform transform = gameObject.transform;
					Transform parent = rope.transform;
					transform.SetParent(parent, worldPositionStays: false);
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					gameObject.SetActive(value: false);
					item = gameObject;
				}
				linkInstances.Add(item);
				num++;
				int particleCount2 = rope.particleCount;
				if (num >= particleCount2)
				{
					return;
				}
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60004DC")]
		[Address(RVA = "0xC3B1A0", Offset = "0xC3B1A0", Length = "0x77C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv52 = *([1ED4D68]);\n\tv53 = *([v52 @ X8_v83]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([20231D6]) = v71;\nL_002C:\n\tgoto L_0037;\n\tv80 = *([v76 @ X0_v2 (Il2CppClass<Obi.ObiRopeChainRenderer>)+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_0037;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v76, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv84 = Obi.ObiRopeChainRenderer;\nL_0037:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v87.m_UpdateChainRopeRendererChunksPerfMarker);\n\tv92 = actor == 0;\n\tif (v92) goto L_005F;\n\tgoto L_FFFFFFFF;\n\tgoto L_005F;\n\tv110 = v110_asT == 0;\n\tif (v110) goto L_FFFFFFFF;\n\tgoto L_005F;\nL_005F:\n\tv150 = this.linkPrefabs;\n\tv156 = v150._size == 0;\n\tif (v156) goto L_0267;\n\tv326 = this.linkInstances;\n\tv327 = this.linkInstances == 0;\n\tif (v327) goto L_007B;\n\tv597 = Obi.ObiActor::get_particleCount(v145);\n\tv575 = v326._size >= v597;\n\tif (v575) goto L_007E;\nL_007B:\n\tObi.ObiRopeChainRenderer::CreateChainLinkInstances(this, v145);\nL_007E:\n\tv1210 = *([v145 @ X21_v2 (Obi.ObiActor)]);\n\tv1214 = Obi.ObiActor::get_blueprint(v145);\n\tv1215 = *([v145 @ X21_v2 (Obi.ObiActor)+88]);\n\tv288 = *([v1215 @ X8_v26+18]);\n\tv544 = this + 0x40;\n\tv1528 = 0xC2DC74(v544, *([v1210 @ X8_v25 (Il2CppClass<Obi.ObiActor>)+228]), methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v468, v68);\n\tv1607 = this.sectionTwist * *([v1215 @ X8_v26+18]);\n\tv1608 = v1607 * this.twistAnchor;\n\tv1609 = -v1608;\n\tv1612 = 0xC2E118(v544, *([v1210 @ X8_v25 (Il2CppClass<Obi.ObiActor>)+228]), methodInfo, v56, v57, v58, v59, v60, v1609, v62, v63, v64, v65, v66, v468, v68);\n\tv1705 = *([v1215 @ X8_v26+18]) < 1;\n\tif (v1705) goto L_020E;\nL_00A4:\n\tv454 = *([v145 @ X21_v2 (Obi.ObiActor)+88]);\n\tv646 = v524 - 4;\n\tv1817 = v646 < *([v454 @ X23_v19+18]);\n\tv675 = ~v1817;\n\tv656 = ~v675;\n\tif (v656) goto L_00B6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00B6:\n\tv683 = *([v454 @ X23_v19+10]);\n\tv644 = *([v683 @ X8_v43+v524 @ X26_v19 (System.Int32)*8]);\n\tv1850 = Obi.ObiActor::GetParticlePosition(v145, *([v644 @ X28_v19+10]));\n\tv1867 = Obi.ObiActor::GetParticlePosition(v145, *([v644 @ X28_v19+14]));\n\tgoto L_00DF;\n\tv1886 = *([v1880 @ X0_v82+E0]);\n\tv1887 = v1886 == 0;\n\tv1888 = ~v1887;\n\tif (v1888) goto L_00DF;\n\tv1890 = \"il2cpp_codegen_runtime_class_init\"(v1880, v1865, v1047, v56, v57, v58, v59, v60, v1867, v1878, v1879, v504, v502, v500, v468, v68);\nL_00DF:\n\tv1055 = UnityEngine.Vector3::op_Subtraction(v1867, v1850);\n\tv1920 = 0x158A710(&v1019 @ stack_-B0_v20, 0, 0, v56, v57, v58, v59, v60, v1055, v1055.y, v1055.z, v1850, v1850.y, v1850.z, v468, v68);\n\tv1077 = Obi.ObiActor::get_blueprint(v145);\n\tv1932 = Obi.ObiActorBlueprint::get_usesOrientedParticles(v1077);\n\tv1934 = v1932 == 0;\n\tif (v1934) goto L_0147;\n\tv1940 = Obi.ObiActor::GetParticleOrientation(v145, *([v644 @ X28_v19+10]));\n\tgoto L_0114;\n\tv1986 = *([v1955 @ X0_v123+E0]);\n\tv1987 = v1986 == 0;\n\tv1988 = ~v1987;\n\tif (v1988) goto L_0114;\n\tv1990 = \"il2cpp_codegen_runtime_class_init\"(v1955, v1937, v1939, v56, v57, v58, v59, v60, v1940, v1950, v1951, v1952, v1031, v1029, v468, v68);\nL_0114:\n\tv1994 = UnityEngine.Vector3::get_up();\n\tgoto L_0130;\n\tv2017 = *([v2004 @ X0_v126+E0]);\n\tv2018 = v2017 == 0;\n\tv2019 = ~v2018;\n\tif (v2019) goto L_0130;\n\tv2021 = \"il2cpp_codegen_runtime_class_init\"(v2004, v1937, v1939, v56, v57, v58, v59, v60, v1994, v1997, v1998, v1952, v1031, v1029, v468, v68);\nL_0130:\n\tv2029 = UnityEngine.Quaternion::op_Multiply(v1940, v1994);\n\tv1982 = 0xC2E6A8(v544, *([v644 @ X28_v19+10]), 0, v56, v57, v58, v59, v60, v1867, v1867.y, v1867.z, v1055, v1055.y, v1055.z, v1994.z, v68);\n\tgoto L_0150;\nL_0147:\n\tv468 = this.sectionTwist;\n\tv1949 = 0xC2E534(v544, 0, 0, v56, v57, v58, v59, v60, v1867, v1867.y, v1867.z, v1055, v1055.y, v1055.z, this.sectionTwist, v68);\nL_0150:\n\tv1376 = this.linkInstances;\n\tv1996 = v646 < v1376._size;\n\tv1185 = ~v1996;\n\tv1165 = ~v1185;\n\tif (v1165) goto L_0164;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0164:\n\tv2013 = v1376._items;\n\tgoto L_0172;\n\tv2030 = *([v2012 @ X0_v92+E0]);\n\tv2031 = v2030 == 0;\n\tv2032 = ~v2031;\n\tif (v2032) goto L_0172;\n\tv2034 = \"il2cpp_codegen_runtime_class_init\"(v2012, v1422, v1409, v56, v57, v58, v59, v60, v1160, v1149, v1147, v1138, v1136, v1134, v1109, v68);\nL_0172:\n\tv1189 = UnityEngine.Object::op_Inequality(*([v2013 @ X8_v51 (UnityEngine.GameObject[])+v524 @ X26_v19 (System.Int32)*8]), 0);\n\tv2043 = v1189 == 0;\n\tif (v2043) goto L_0200;\n\tv1095 = this.linkInstances;\n\tv2077 = v646 < v1095._size;\n\tv1515 = ~v2077;\n\tv1496 = ~v1515;\n\tif (v1496) goto L_0187;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0187:\n\tv1523 = v1095._items;\n\tUnityEngine.GameObject::SetActive(*([v1523 @ X8_v56 (UnityEngine.GameObject[])+v524 @ X26_v19 (System.Int32)*8]), 1);\n\tv1541 = this.linkInstances;\n\tv2081 = v646 < v1541._size;\n\tv1685 = ~v2081;\n\tv1666 = ~v1685;\n\tif (v1666) goto L_019F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_019F:\n\tv1693 = v1541._items;\n\tv2084 = UnityEngine.GameObject::get_transform(*([v1693 @ X8_v58 (UnityEngine.GameObject[])+v524 @ X26_v19 (System.Int32)*8]));\n\tgoto L_01B8;\n\tv2089 = *([v2085 @ X0_v102+E0]);\n\tv2090 = v2089 == 0;\n\tv2091 = ~v2090;\n\tif (v2091) goto L_01B8;\n\tv2093 = \"il2cpp_codegen_runtime_class_init\"(v2085, v1721, v1574, v56, v57, v58, v59, v60, v1160, v1149, v1147, v1138, v1136, v1134, v1109, v68);\nL_01B8:\n\t// 440 MakeStruct v1708 @ AGGC3B600_0_v19 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1019 @ stack_-B0_v20, v1055.y (System.Single), v1055.z (System.Single)\n\tv2100 = UnityEngine.Vector3::op_Multiply(v1708, 0.5f);\n\t// 451 MakeStruct v1707 @ AGGC3B61C_0_v19 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1145 @ V14_v20 (UnityEngine.Vector3), v1850.y (System.Single), v1850.z (System.Single)\n\tv1716 = UnityEngine.Vector3::op_Addition(v1707, v2100);\n\tv1733 = v2084 == 0;\n\tif (v1733) goto L_0282;\n\tUnityEngine.Transform::set_position(v2084, v1716);\n\tv2110 = Obi.ObiActor::GetParticleMaxRadius(v145, *([v644 @ X28_v19+10]));\n\tv2114 = v2110 + v2110;\n\t// 471 MakeStruct v2048 @ AGGC3B650_1_v19 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.linkScale (UnityEngine.Vector3), this.linkScale.y (System.Single), this.linkScale.z (System.Single)\n\tv2116 = UnityEngine.Vector3::op_Multiply(v2114, v2048);\n\tUnityEngine.Transform::set_localScale(v2084, v2116);\n\tgoto L_01F5;\n\tv2127 = *([v2123 @ X0_v110+E0]);\n\tv2128 = v2127 == 0;\n\tv2129 = ~v2128;\n\tif (v2129) goto L_01F5;\n\tv2131 = \"il2cpp_codegen_runtime_class_init\"(v2123, v2120, v2056, v56, v57, v58, v59, v60, v2116, v2117, v2118, v2113, v1711, v1710, v1109, v68);\nL_01F5:\n\t// 501 MakeStruct v2046 @ AGGC3B6A4_0_v19 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1143 @ V12_v21 (UnityEngine.Vector3), v1125 @ V15_v20 (System.Single), v1141 @ V13_v21 (System.Single)\n\t// 502 MakeStruct v2045 @ AGGC3B6A4_1_v19 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.frame.normal (UnityEngine.Vector3), this.frame.normal.y (System.Single), this.frame.normal.z (System.Single)\n\tv2057 = UnityEngine.Quaternion::LookRotation(v2046, v2045);\n\tUnityEngine.Transform::set_rotation(v2084, v2057);\nL_0200:\n\tv1789 = v524 - 3;\n\tv524 = v524 + 1;\n\tv1763 = v1789 < v288;\n\tif (v1763) goto L_00A4;\nL_020E:\n\tv429 = this.linkInstances;\nL_021D:\n\tv385 = v288 >= v429._size;\n\tif (v385) goto L_0267;\n\tv1832 = v429._size < v288;\n\tv1833 = ~v1832;\n\tv1834 = v429._size - v288;\n\tv1836 = v1834 == 0;\n\tv1841 = ~v1836;\n\tv1842 = v1833 & v1841;\n\tif (v1842) goto L_022D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_022D:\n\tv1853 = v429._items;\n\tgoto L_023E;\n\tv1868 = *([v1854 @ X0_v64+E0]);\n\tv1869 = v1868 == 0;\n\tv1870 = ~v1869;\n\tif (v1870) goto L_023E;\n\tv1872 = \"il2cpp_codegen_runtime_class_init\"(v1854, v388, v371, v56, v57, v58, v59, v60, v282, v265, v263, v253, v251, v249, v205, v68);\nL_023E:\n\tv1876 = UnityEngine.Object::op_Inequality(v1853[v288 @ X24_v19 (System.Int32)], 0);\n\tv1885 = v1876 == 0;\n\tif (v1885) goto L_025E;\n\tv321 = this.linkInstances;\n\tv1922 = v321._size < v288;\n\tv1909 = \n// ... truncated")]
		public void UpdateRenderer(ObiActor actor)
		{
			//IL_0997: Expected I, but got O
			//IL_08f4: Expected I, but got O
			//IL_00e8: Expected I, but got O
			//IL_0105: Expected O, but got I
			//IL_0126: Expected O, but got I
			//IL_0163: Expected O, but got F4
			//IL_09db: Expected O, but got I
			//IL_0209: Expected O, but got I
			//IL_0219: Expected O, but got I
			//IL_03fa: Expected O, but got I
			//IL_0495: Expected O, but got I
			//IL_050a: Expected O, but got I
			//IL_0520: Expected F4, but got O
			//IL_094a: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateChainRopeRendererChunksPerfMarker);
			bool flag = (object)actor == null;
			ObiActor obiActor = actor;
			if (!flag)
			{
				ObiRopeBase obiRopeBase = actor as ObiRopeBase;
				obiActor = (((object)obiRopeBase == null) ? null : actor);
			}
			List<GameObject> list = linkPrefabs;
			if (list.Count != 0)
			{
				List<GameObject> list2 = linkInstances;
				if (linkInstances != null)
				{
					int particleCount = obiActor.particleCount;
					if (list2.Count >= particleCount)
					{
						goto IL_00e0;
					}
				}
				CreateChainLinkInstances((ObiRopeBase)obiActor);
				goto IL_00e0;
			}
			goto IL_08ea;
			IL_00e0:
			IntPtr intPtr = (IntPtr)obiActor;
			ObiActorBlueprint blueprint = obiActor.blueprint;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X21_v2 (Obi.ObiActor)+88]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ X8_v26+18]");
			int num = 0;
			object obj2 = (long)(IntPtr)this + 64L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC74 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x48)");
			float num2 = sectionTwist;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ X8_v26+18]");
			float num3 = num2 * 0f;
			float num4 = num3 * twistAnchor;
			object obj3 = 0f - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E118 (inside Obi.ObiPathFrame::op_Multiply +0x1D4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1215 @ X8_v26+18]");
			if (0L >= 1L)
			{
				int num5 = 4;
				Vector3 vector5 = default(Vector3);
				object obj7 = default(object);
				Vector3 vector7 = default(Vector3);
				object obj8 = default(object);
				object obj9 = default(object);
				Vector3 vector8 = default(Vector3);
				Vector3 forward = default(Vector3);
				Vector3 upwards = default(Vector3);
				int num8;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X21_v2 (Obi.ObiActor)+88]");
					object obj4 = 0;
					int num6 = num5 - 4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X23_v19+18]");
					if ((long)num6 >= 0L)
					{
						throw new ArgumentOutOfRangeException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v454 @ X23_v19+10]");
					object obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v683 @ X8_v43+v524 @ X26_v19 (System.Int32)*8]");
					object obj6 = 0;
					ObiActor obiActor2 = obiActor;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X28_v19+10]");
					Vector3 particlePosition = obiActor2.GetParticlePosition(0);
					ObiActor obiActor3 = obiActor;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X28_v19+14]");
					Vector3 particlePosition2 = obiActor3.GetParticlePosition(0);
					Vector3 vector = particlePosition2 - particlePosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
					ObiActorBlueprint blueprint2 = obiActor.blueprint;
					float y;
					float z2;
					Vector3 vector3;
					Vector3 vector4;
					if (blueprint2.usesOrientedParticles)
					{
						ObiActor obiActor4 = obiActor;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X28_v19+10]");
						Quaternion particleOrientation = obiActor4.GetParticleOrientation(0);
						Vector3 up = Vector3.up;
						Vector3 vector2 = particleOrientation * up;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E6A8 (inside Obi.ObiPathFrame::op_Multiply +0x764)");
						float z = up.z;
						y = vector.y;
						z2 = vector.z;
						vector3 = vector;
						vector4 = particlePosition;
					}
					else
					{
						float z = sectionTwist;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E534 (inside Obi.ObiPathFrame::op_Multiply +0x5F0)");
						y = vector.y;
						z2 = vector.z;
						vector3 = vector;
						vector4 = particlePosition;
					}
					List<GameObject> list3 = linkInstances;
					if (num6 >= list3.Count)
					{
						throw new ArgumentOutOfRangeException();
					}
					GameObject[] items = list3._items;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2013 @ X8_v51 (UnityEngine.GameObject[])+v524 @ X26_v19 (System.Int32)*8]");
					if ((UnityEngine.Object)0 != null)
					{
						List<GameObject> list4 = linkInstances;
						if (num6 >= list4.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						GameObject[] items2 = list4._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1523 @ X8_v56 (UnityEngine.GameObject[])+v524 @ X26_v19 (System.Int32)*8]");
						((GameObject)0).SetActive(value: true);
						List<GameObject> list5 = linkInstances;
						if (num6 >= list5.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						GameObject[] items3 = list5._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1693 @ X8_v58 (UnityEngine.GameObject[])+v524 @ X26_v19 (System.Int32)*8]");
						Transform transform = ((GameObject)0).transform;
						vector5.x = (float)obj7;
						vector5.y = vector.y;
						vector5.z = vector.z;
						Vector3 vector6 = vector5 * 0.5f;
						vector7.x = vector4.x;
						vector7.y = particlePosition.y;
						vector7.z = particlePosition.z;
						Vector3 position = vector7 + vector6;
						if ((object)transform == null)
						{
							NullReferenceException ex = new NullReferenceException();
							if ((IntPtr)obj8 == (IntPtr)1)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
								ProfilerMarker.Internal_End((IntPtr)m_UpdateChainRopeRendererChunksPerfMarker);
								if (obj9 == null)
								{
									return;
								}
							}
							else
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
							}
							throw new TypeLoadException();
						}
						transform.position = position;
						ObiActor obiActor5 = obiActor;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v644 @ X28_v19+10]");
						float particleMaxRadius = obiActor5.GetParticleMaxRadius(0);
						float num7 = particleMaxRadius + particleMaxRadius;
						vector8.x = linkScale.x;
						vector8.y = linkScale.y;
						vector8.z = linkScale.z;
						Vector3 localScale = num7 * vector8;
						transform.localScale = localScale;
						forward.x = vector3.x;
						forward.y = y;
						forward.z = z2;
						upwards.x = frame.normal.x;
						upwards.y = frame.normal.y;
						upwards.z = frame.normal.z;
						Quaternion rotation = Quaternion.LookRotation(forward, upwards);
						transform.rotation = rotation;
					}
					num8 = num5 - 3;
					num5++;
				}
				while (num8 < num);
			}
			List<GameObject> list6 = linkInstances;
			while (num < list6.Count)
			{
				bool flag2 = list6.Count < num;
				bool flag3 = !flag2;
				int num9 = list6.Count - num;
				bool flag4 = num9 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					throw new ArgumentOutOfRangeException();
				}
				GameObject[] items4 = list6._items;
				if (items4[num] != null)
				{
					List<GameObject> list7 = linkInstances;
					bool flag6 = list7.Count < num;
					bool flag7 = !flag6;
					int num10 = list7.Count - num;
					bool flag8 = num10 == 0;
					bool flag9 = !flag8;
					if (!(flag7 && flag9))
					{
						throw new ArgumentOutOfRangeException();
					}
					GameObject[] items5 = list7._items;
					items5[num].SetActive(value: false);
				}
				list6 = linkInstances;
				num++;
				if (linkInstances == null)
				{
					throw new NullReferenceException();
				}
			}
			goto IL_08ea;
			IL_08ea:
			ProfilerMarker.Internal_End((IntPtr)m_UpdateChainRopeRendererChunksPerfMarker);
		}

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0xC3B91C", Offset = "0xC3B91C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA8818]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231D7]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = UnityEngine.Vector3::get_one();\n\tthis.linkScale = v53;\n\tthis.linkScale.y = v53.y;\n\tthis.linkScale.z = v53.z;\n\tv59 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v59);\n\tthis.linkPrefabs = v59;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeChainRenderer()
		{
			Vector3 vector = (linkScale = Vector3.one);
			linkScale.y = vector.y;
			linkScale.z = vector.z;
			List<GameObject> list = new List<GameObject>();
			linkPrefabs = list;
		}

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0xC3B9BC", Offset = "0xC3B9BC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EFDF60]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20231D8]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateChainRopeRenderer\", 0);\n\tv45.m_UpdateChainRopeRendererChunksPerfMarker = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiRopeChainRenderer()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("UpdateChainRopeRenderer", default(Unity.Profiling.MarkerFlags));
			m_UpdateChainRopeRendererChunksPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
