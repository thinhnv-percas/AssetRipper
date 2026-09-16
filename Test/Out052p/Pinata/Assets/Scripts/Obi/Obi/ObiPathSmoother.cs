using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744EB0", Offset = "0x744EB0")]
	[Token(Token = "0x200007A")]
	public class ObiPathSmoother : MonoBehaviour
	{
		[Token(Token = "0x4000203")]
		private static ProfilerMarker m_AllocateRawChunksPerfMarker;

		[Token(Token = "0x4000204")]
		private static ProfilerMarker m_GenerateSmoothChunksPerfMarker;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x18")]
		private Matrix4x4 w2l;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x58")]
		private Quaternion w2lRotation;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7469D4", Offset = "0x7469D4")]
		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x68")]
		public uint smoothing;

		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x6C")]
		public float twist;

		[CompilerGenerated]
		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x70")]
		private ObiActor.ActorCallback m_OnCurveGenerated;

		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x78")]
		protected float smoothLength;

		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x7C")]
		protected int smoothSections;

		[HideInInspector]
		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0x80")]
		public ObiList<ObiList<ObiPathFrame>> rawChunks;

		[HideInInspector]
		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x88")]
		public ObiList<ObiList<ObiPathFrame>> smoothChunks;

		[Token(Token = "0x170000C5")]
		public float SmoothLength
		{
			[Token(Token = "0x60004C1")]
			[Address(RVA = "0xC2ED24", Offset = "0xC2ED24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.smoothLength;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SmoothLength;
			}
		}

		[Token(Token = "0x170000C6")]
		public float SmoothSections
		{
			[Token(Token = "0x60004C2")]
			[Address(RVA = "0xC2ED2C", Offset = "0xC2ED2C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.smoothSections;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0007: Expected F4, but got I4
				return smoothSections;
			}
		}

		[Token(Token = "0x14000014")]
		public event ObiActor.ActorCallback OnCurveGenerated
		{
			[CompilerGenerated]
			[Token(Token = "0x60004BF")]
			[Address(RVA = "0xC2EBDC", Offset = "0xC2EBDC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ECE3A0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202316E]) = v43;\nL_0017:\n\tv45 = this + 0x70;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 112L;
				Delegate obj2 = this.m_OnCurveGenerated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ObiActor.ActorCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60004C0")]
			[Address(RVA = "0xC2EC80", Offset = "0xC2EC80", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBBCD8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202316F]) = v43;\nL_0017:\n\tv45 = this + 0x70;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 112L;
				Delegate obj2 = this.m_OnCurveGenerated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ObiActor.ActorCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60004C3")]
		[Address(RVA = "0xC2ED38", Offset = "0xC2ED38", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1F0EA00]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023170]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnInterpolate(v45, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			ObiRopeBase component = GetComponent<ObiRopeBase>();
			ObiActor.ActorCallback value = Actor_OnInterpolate;
			component.OnInterpolate += value;
		}

		[Token(Token = "0x60004C4")]
		[Address(RVA = "0xC2EDE0", Offset = "0xC2EDE0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EAD688]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023171]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnInterpolate(v45, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			ObiRopeBase component = GetComponent<ObiRopeBase>();
			ObiActor.ActorCallback value = Actor_OnInterpolate;
			component.OnInterpolate -= value;
		}

		[Token(Token = "0x60004C5")]
		[Address(RVA = "0xC2EE88", Offset = "0xC2EE88", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE4620]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, actor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023172]) = v41;\nL_0016:\n\tv43 = actor == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv110 = v110_asT != 0;\n\tif (v110) goto L_003D;\n\tthrow System.InvalidCastException;\nL_003D:\n\tObi.ObiPathSmoother::GenerateSmoothChunks(this, v117, this.smoothing);\n\tv135 = this.OnCurveGenerated == 0;\n\tif (v135) goto L_0051;\n\tObi.ObiActor+ActorCallback::Invoke(this.OnCurveGenerated, actor);\n\treturn;\nL_0051:\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Actor_OnInterpolate(ObiActor actor)
		{
			ObiActor actor2;
			if ((object)actor != null)
			{
				ObiRopeBase obiRopeBase = actor as ObiRopeBase;
				bool flag = (object)obiRopeBase != null;
				actor2 = actor;
				if (!flag)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				actor2 = null;
			}
			GenerateSmoothChunks((ObiRopeBase)actor2, smoothing);
			if (this.OnCurveGenerated != null)
			{
				this.OnCurveGenerated(actor);
			}
		}

		[Token(Token = "0x60004C6")]
		[Address(RVA = "0xC2F7F4", Offset = "0xC2F7F4", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv32 = *([1EA4398]);\n\tv33 = *([v32 @ X8_v27]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, sections, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2023173]) = v51;\nL_0024:\n\tv62 = sections < 2;\n\tif (v62) goto L_00C1;\n\tv151 = this.rawChunks;\n\tv92 = v151.count << 3;\n\tv255 = v151.data + v92;\n\tv89 = v255 + 0x20;\n\tv256 = *([v89 @ X25_v8]) == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_0081;\n\tv289 = new Obi.ObiList`1<Obi.ObiPathFrame>();\n\tObi.ObiList`1<Obi.ObiPathFrame>::.ctor(v289);\n\tv352 = v289 == 0;\n\tif (v352) goto L_005B;\n\t// 77 IsInst v346 @ X0_v25, typeof(Obi.ObiList`1<Obi.ObiPathFrame>), v289 @ X0_v17 (Obi.ObiList`1<Obi.ObiPathFrame>)\n\tv348 = v346 == 0;\n\tif (v348) goto L_00C8;\nL_005B:\n\t*([v89 @ X25_v8]) = v289;\n\tv149 = this.smoothChunks;\n\tv136 = v149.data;\n\tv133 = v149.count;\n\tv140 = new Obi.ObiList`1<Obi.ObiPathFrame>();\n\tObi.ObiList`1<Obi.ObiPathFrame>::.ctor(v140);\n\tv359 = v140 == 0;\n\tif (v359) goto L_007D;\n\t// 109 IsInst v347 @ X0_v23, typeof(Obi.ObiList`1<Obi.ObiPathFrame>), v140 @ X0_v20 (Obi.ObiList`1<Obi.ObiPathFrame>)\n\tv349 = v347 == 0;\n\tif (v349) goto L_00C8;\nL_007D:\n\tv136[v133 @ X23_v10 (System.Int32)] = v140;\n\tv151 = this.rawChunks;\nL_0081:\n\tv130 = v151.data;\n\tv284 = v151.count;\n\tObi.ObiList`1<Obi.ObiPathFrame>::SetCount(v130[v284 @ X8_v10 (System.Int32)], sections);\n\tv243 = this.rawChunks;\n\tv225 = v243.count + 1;\n\tObi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::SetCount(v243, v225);\n\tv196 = this.smoothChunks;\n\tv165 = v196.count + 1;\n\tObi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::SetCount(v196, v165);\n\treturn;\nL_00C1:\n\treturn;\n\tv254 = new System.NullReferenceException();\n\tv286 = new System.IndexOutOfRangeException();\nL_00C7:\n\tv339 = new System.TypeLoadException();\nL_00C8:\n\tv328 = new System.ArrayTypeMismatchException();\n\tgoto L_00C7;\n\treturn;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AllocateChunk(int sections)
		{
			//IL_003a: Expected O, but got I
			//IL_0049: Expected O, but got I
			if (sections < 2)
			{
				return;
			}
			ObiList<ObiList<ObiPathFrame>> obiList = rawChunks;
			int num = obiList.Count << 3;
			object obj = (long)(IntPtr)obiList.Data + (long)num;
			object obj2 = (long)(IntPtr)obj + 32L;
			if (obj2 == null)
			{
				ObiList<ObiPathFrame> obiList2 = new ObiList<ObiPathFrame>();
				if (obiList2 != null)
				{
					object obj3 = obiList2 as ObiList<ObiPathFrame>;
					if (obj3 == null)
					{
						goto IL_0216;
					}
				}
				obj2 = obiList2;
				ObiList<ObiList<ObiPathFrame>> obiList3 = smoothChunks;
				ObiList<ObiPathFrame>[] data = obiList3.Data;
				int count = obiList3.Count;
				ObiList<ObiPathFrame> obiList4 = new ObiList<ObiPathFrame>();
				if (obiList4 != null)
				{
					object obj4 = obiList4 as ObiList<ObiPathFrame>;
					if (obj4 == null)
					{
						goto IL_0216;
					}
				}
				data[count] = obiList4;
				obiList = rawChunks;
			}
			ObiList<ObiPathFrame>[] data2 = obiList.Data;
			int count2 = obiList.Count;
			data2[count2].SetCount(sections);
			ObiList<ObiList<ObiPathFrame>> obiList5 = rawChunks;
			int count3 = obiList5.Count + 1;
			obiList5.SetCount(count3);
			ObiList<ObiList<ObiPathFrame>> obiList6 = smoothChunks;
			int count4 = obiList6.Count + 1;
			obiList6.SetCount(count4);
			return;
			IL_0216:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x60004C7")]
		[Address(RVA = "0xC2F9D0", Offset = "0xC2F9D0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv36 = *([1EEFEB8]);\n\tv37 = *([v36 @ X8_v14]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, chunk, methodInfo, v40, v41, v42, v43, v44, returnVal2, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 0 | 1;\n\t*([2023174]) = v56;\nL_002A:\n\tv70 = chunk.count < 2;\n\tif (v70) goto L_0097;\nL_0033:\n\tv324 = &v214 @ stack_-B8;\n\tv327 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(chunk, v322);\n\tv214 = *([v324 @ X8_v6]);\n\tv406 = v322 - 1;\n\tv409 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(chunk, v406);\n\tgoto L_0076;\n\tv414 = *([v410 @ X0_v10+E0]);\n\tv415 = v414 == 0;\n\tv416 = ~v415;\n\tgoto L_0076;\n\tv418 = \"il2cpp_codegen_runtime_class_init\"(v410, v155, v163, v40, v41, v42, v43, v44, v266, v265, v264, v263, v262, v261, v51, v52);\nL_0076:\n\t// 118 MakeStruct v83 @ AGGC2FAB8_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v324 @ X8_v6], [v324 @ X8_v6+4], [v324 @ X8_v6+8]\n\tv96 = UnityEngine.Vector3::Distance(v83, v409.position);\n\tv322 = v406 + 2;\n\tv235 = v318 + v96;\n\tv218 = v322 < chunk.count;\n\tif (v218) goto L_0033;\nL_0097:\n\treturn v235;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float CalculateChunkLength(ObiList<ObiPathFrame> chunk)
		{
			//IL_0054: Expected F4, but got O
			//IL_0069: Expected F4, but got I
			//IL_007e: Expected F4, but got I
			bool flag = chunk.Count < 2;
			float num = 0f;
			if (!flag)
			{
				float num2 = 0f;
				int num3 = 1;
				object obj2 = default(object);
				Vector3 a = default(Vector3);
				bool flag2;
				do
				{
					object obj = obj2;
					ObiPathFrame obiPathFrame = chunk.get_Item(num3);
					obj2 = obj;
					int num4 = num3 - 1;
					ObiPathFrame obiPathFrame2 = chunk.get_Item(num4);
					a.x = (float)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ X8_v6+4]");
					a.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ X8_v6+8]");
					a.z = 0f;
					float num5 = Vector3.Distance(a, obiPathFrame2.position);
					num3 = num4 + 2;
					num = num2 + num5;
					flag2 = num3 < chunk.Count;
					num2 = num;
				}
				while (flag2);
			}
			return num;
		}

		[Token(Token = "0x60004C8")]
		[Address(RVA = "0xC2FB00", Offset = "0xC2FB00", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EAD8D0]);\n\tv33 = *([v32 @ X8_v27]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, actor, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2023175]) = v51;\nL_0020:\n\tgoto L_002B;\n\tv58 = *([v54 @ X0_v2 (Il2CppClass<Obi.ObiPathSmoother>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_002B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v54, actor, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv62 = Obi.ObiPathSmoother;\nL_002B:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v65.m_AllocateRawChunksPerfMarker);\n\tObi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::Clear(this.rawChunks);\n\tv127 = actor == 0;\n\tif (v127) goto L_00B7;\n\tv151 = Obi.ObiRopeBase::get_path(actor);\n\tv152 = v151 == 0;\n\tif (v152) goto L_00AD;\n\tv290 = actor.elements;\nL_003F:\n\tv221 = v115 + 1;\n\tv304 = v289 >= v290._size;\n\tif (v304) goto L_009F;\n\tv343 = v290._size - 1;\n\tv353 = v289 >= v343;\n\tif (v353) goto L_0095;\n\tv355 = v290._size < v289;\n\tv356 = ~v355;\n\tv357 = v290._size - v289;\n\tv359 = v357 == 0;\n\tv364 = ~v359;\n\tv365 = v356 & v364;\n\tif (v365) goto L_0065;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0065:\n\tv369 = v290._items;\n\tv372 = v369[v289 @ X23_v9 (System.Int32)];\n\tv375 = actor.elements;\n\tv289 = v289 + 1;\n\tv400 = v375._size < v289;\n\tv401 = ~v400;\n\tv402 = v375._size - v289;\n\tv404 = v402 == 0;\n\tv409 = ~v404;\n\tv377 = v401 & v409;\n\tif (v377) goto L_007F;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_007F:\n\tv416 = v375._items;\n\tv418 = v416[v289 @ X23_v9 (System.Int32)];\n\tv382 = v372.particle2 == v418.particle1;\n\tif (v382) goto L_0096;\n\tv390 = v115 + 2;\n\tObi.ObiPathSmoother::AllocateChunk(this, v390);\n\tgoto L_0096;\nL_0095:\n\tv289 = v289 + 1;\nL_0096:\n\tv290 = actor.elements;\n\tv396 = actor.elements == 0;\n\tv258 = ~v396;\n\tif (v258) goto L_003F;\n\tthrow System.NullReferenceException;\nL_009F:\n\tObi.ObiPathSmoother::AllocateChunk(this, v221);\nL_00AD:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v65.m_AllocateRawChunksPerfMarker);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv121 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00B7:\n\tv149 = new System.NullReferenceException();\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\n\tgoto L_00CA;\nL_00CA:\n\tv162 = v144 != 1;\n\tif (v162) goto L_00E1;\n\tv217 = 0x6D2BC0(v149, v144, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv264 = 0x6D2490(v217, v144, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v65.m_AllocateRawChunksPerfMarker);\n\tv354 = *([v217 @ X0_v13]) == 0;\n\tv270 = ~v354;\n\tif (v270) goto L_00E5;\n\treturn;\nL_00E1:\n\tv218 = 0x6D2380(v149, v144, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00E5:\n\tthrow System.TypeLoadException;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AllocateRawChunks(ObiRopeBase actor)
		{
			//IL_0315: Expected I, but got O
			//IL_0276: Expected I, but got O
			//IL_02c8: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_AllocateRawChunksPerfMarker);
			rawChunks.Clear();
			if ((object)actor != null)
			{
				ObiPath path = actor.path;
				if (path != null)
				{
					List<ObiStructuralElement> elements = actor.elements;
					int num = 0;
					int num2 = 0;
					int num3;
					while (true)
					{
						num3 = num2 + 1;
						if (num >= elements.Count)
						{
							break;
						}
						int num4 = elements.Count - 1;
						if (num < num4)
						{
							bool flag = elements.Count < num;
							bool flag2 = !flag;
							int num5 = elements.Count - num;
							bool flag3 = num5 == 0;
							bool flag4 = !flag3;
							if (!(flag2 && flag4))
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items = elements._items;
							ObiStructuralElement obiStructuralElement = items[num];
							List<ObiStructuralElement> elements2 = actor.elements;
							num++;
							bool flag5 = elements2.Count < num;
							bool flag6 = !flag5;
							int num6 = elements2.Count - num;
							bool flag7 = num6 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items2 = elements2._items;
							ObiStructuralElement obiStructuralElement2 = items2[num];
							if (obiStructuralElement.particle2 != obiStructuralElement2.particle1)
							{
								int sections = num2 + 2;
								AllocateChunk(sections);
								num3 = 0;
							}
						}
						else
						{
							num++;
						}
						elements = actor.elements;
						bool flag9 = actor.elements == null;
						bool flag10 = !flag9;
						num2 = num3;
						if (!flag10)
						{
							throw new NullReferenceException();
						}
					}
					AllocateChunk(num3);
				}
				ProfilerMarker.Internal_End((IntPtr)m_AllocateRawChunksPerfMarker);
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			if (intPtr == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				ProfilerMarker.Internal_End((IntPtr)m_AllocateRawChunksPerfMarker);
				object obj = default(object);
				if (obj == null)
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

		[Token(Token = "0x60004C9")]
		[Address(RVA = "0xC2FE00", Offset = "0xC2FE00", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tgoto L_0026;\n\tv46 = *([1EAA800]);\n\tv47 = *([v46 @ X8_v22]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, actor, frame, particleIndex, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([2023176]) = v63;\nL_0026:\n\tv68 = this + 0x18;\n\tv69 = Obi.ObiActor::GetParticlePosition(actor, particleIndex);\n\tv76 = 0x10C27FC(v68, 0, 0, particleIndex, methodInfo, v50, v51, v52, v69, v69.y, v69.z, v56, v57, v58, v59, v60);\n\t*([frame @ X2 (Obi.ObiPathFrame&)]) = v69;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+4]) = v69.y;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+8]) = v69.z;\n\tv80 = Obi.ObiActor::GetParticleMaxRadius(actor, particleIndex);\n\t*([frame @ X2 (Obi.ObiPathFrame&)+40]) = v80;\n\tv182 = Obi.ObiActor::GetParticleColor(actor, particleIndex);\n\tv187 = UnityEngine.Color::op_Implicit(v182);\n\t*([frame @ X2 (Obi.ObiPathFrame&)+30]) = v187;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+34]) = v187.y;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+38]) = v187.z;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+3C]) = v187.w;\n\tv193 = Obi.ObiActor::get_usesOrientedParticles(actor);\n\tv195 = v193 == 0;\n\tif (v195) goto L_0102;\n\t*([v30 @ X29_v1-24]) = this.w2lRotation;\n\t*([v30 @ X29_v1-28]) = this.w2lRotation.y;\n\tv205 = Obi.ObiActor::GetParticleOrientation(actor, particleIndex);\n\tgoto L_006B;\n\tv255 = *([v251 @ X0_v14+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_006B;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v251, v198, v199, particleIndex, methodInfo, v50, v51, v52, v205, v246, v247, v248, v57, v58, v59, v60);\nL_006B:\n\tv262 = particleIndex - 1;\n\tv265 = UnityEngine.Mathf::Max(0, v262);\n\tv267 = Obi.ObiActor::GetParticleOrientation(actor, v265);\n\tgoto L_0093;\n\tv281 = *([v276 @ X0_v19+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_0093;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v276, v242, v241, particleIndex, methodInfo, v50, v51, v52, v267, v268, v269, v270, v57, v58, v59, v60);\nL_0093:\n\tv298 = UnityEngine.Quaternion::SlerpUnclamped(v205, v267, 0.5f);\n\t// 160 MakeStruct v213 @ AGGC2FFC8_0_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v30 @ X29_v1-24], [v30 @ X29_v1-28], this.w2lRotation.z (System.Single), this.w2lRotation.w (System.Single)\n\tv310 = UnityEngine.Quaternion::op_Multiply(v213, v298);\n\tgoto L_00B7;\n\tv320 = *([v316 @ X0_v23+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_00B7;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v316, v242, v241, particleIndex, methodInfo, v50, v51, v52, v310, v311, v312, v313, v302, v303, v304, v217);\nL_00B7:\n\tv326 = UnityEngine.Vector3::get_up();\n\tv337 = UnityEngine.Quaternion::op_Multiply(v310, v326);\n\t*([frame @ X2 (Obi.ObiPathFrame&)+18]) = v337;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+1C]) = v337.y;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+20]) = v337.z;\n\tv341 = UnityEngine.Vector3::get_right();\n\tv352 = UnityEngine.Quaternion::op_Multiply(v310, v341);\n\t*([frame @ X2 (Obi.ObiPathFrame&)+24]) = v352;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+28]) = v352.y;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+2C]) = v352.z;\n\tv356 = UnityEngine.Vector3::get_forward();\n\tv240 = UnityEngine.Quaternion::op_Multiply(v310, v356);\n\t*([frame @ X2 (Obi.ObiPathFrame&)+C]) = v240;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+10]) = v240.y;\n\t*([frame @ X2 (Obi.ObiPathFrame&)+14]) = v240.z;\nL_0102:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 193 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void PathFrameFromParticle(ObiRopeBase actor, ref ObiPathFrame frame, int particleIndex)
		{
			//IL_0019: Expected O, but got I
			//IL_016f: Expected F4, but got I
			//IL_0184: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj3 = (long)(IntPtr)this + 24L;
			Vector3 particlePosition = actor.GetParticlePosition(particleIndex);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
			ref ObiPathFrame reference = ref *(ObiPathFrame*)particlePosition;
			_ = particlePosition.y;
			_ = particlePosition.z;
			float particleMaxRadius = actor.GetParticleMaxRadius(particleIndex);
			Color particleColor = actor.GetParticleColor(particleIndex);
			Vector4 vector = particleColor;
			_ = vector.y;
			_ = vector.z;
			_ = vector.w;
			if (actor.usesOrientedParticles)
			{
				_ = w2lRotation;
				_ = w2lRotation.y;
				Quaternion particleOrientation = actor.GetParticleOrientation(particleIndex);
				int b = particleIndex - 1;
				int solverIndex = Mathf.Max(0, b);
				Quaternion particleOrientation2 = actor.GetParticleOrientation(solverIndex);
				Quaternion quaternion = Quaternion.SlerpUnclamped(particleOrientation, particleOrientation2, 0.5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-24]");
				Quaternion quaternion2 = default(Quaternion);
				quaternion2.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X29_v1-28]");
				quaternion2.y = 0f;
				quaternion2.z = w2lRotation.z;
				quaternion2.w = w2lRotation.w;
				Quaternion quaternion3 = quaternion2 * quaternion;
				Vector3 up = Vector3.up;
				Vector3 vector2 = quaternion3 * up;
				_ = vector2.y;
				_ = vector2.z;
				Vector3 right = Vector3.right;
				Vector3 vector3 = quaternion3 * right;
				_ = vector3.y;
				_ = vector3.z;
				Vector3 forward = Vector3.forward;
				Vector3 vector4 = quaternion3 * forward;
				_ = vector4.y;
				_ = vector4.z;
			}
		}

		[Token(Token = "0x60004CA")]
		[Address(RVA = "0xC2EF4C", Offset = "0xC2EF4C", Length = "0x8A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = &v39 @ stack_-10_v2;\n\tgoto L_0028;\n\tv52 = *([1EAAC20]);\n\tv53 = *([v52 @ X8_v86]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, actor, smoothingLevels, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([2023177]) = v70;\nL_0028:\n\tv75 = 0x6D26F0(&v1016 @ stack_-178_v33 (Obi.ObiPathFrame), 0, 0x44, v1527, v56, v57, v58, v59, v60, v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tv80 = 0x6D26F0(&v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), 0, 0x44, v1527, v56, v57, v58, v59, v60, v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tv85 = 0x6D26F0(&v82 @ stack_-208_v1, 0, 0x44, v1527, v56, v57, v58, v59, v60, v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tv92 = 0x6D26F0(&v87 @ stack_-260, 0, 0x44, v1527, v56, v57, v58, v59, v60, v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tgoto L_0046;\n\tv99 = *([v95 @ X0_v10 (Il2CppClass<Obi.ObiPathSmoother>)+E0]);\n\tv100 = v99 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0046;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v95, v89, v88, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv103 = Obi.ObiPathSmoother;\nL_0046:\n\tv2828 = v106.m_GenerateSmoothChunksPerfMarker;\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v106.m_GenerateSmoothChunksPerfMarker);\n\tObi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::Clear(this.smoothChunks);\n\tthis.smoothLength = 0f;\n\tv503 = UnityEngine.Application::get_isPlaying();\n\tv649 = v503 == 0;\n\tv650 = ~v649;\n\tif (v650) goto L_005D;\n\tObi.ObiRopeBase::RebuildElementsFromConstraints(actor);\nL_005D:\n\tObi.ObiPathSmoother::AllocateRawChunks(this, actor);\n\tv787 = UnityEngine.Component::get_transform(actor);\n\tv2310 = &v478 @ stack_-2A0;\n\tv2312 = UnityEngine.Transform::get_worldToLocalMatrix(v787);\n\tv478 = *([v2310 @ X8_v24]);\n\tv2459 = &v478 @ stack_-2A0;\n\tv60 = *([v2459 @ X8_v25+30]);\n\tv2461 = this + 0x18;\n\tthis.w2l.m03 = *([v2459 @ X8_v25+30]);\n\tv60 = *([v2459 @ X8_v25+20]);\n\tthis.w2l.m02 = *([v2459 @ X8_v25+20]);\n\tv60 = *([v2459 @ X8_v25+10]);\n\tthis.w2l.m01 = *([v2459 @ X8_v25+10]);\n\tthis.w2l = *([v2459 @ X8_v25]);\n\tv2466 = 0x10C1A04(v2461, 0, 0x44, v1527, v56, v57, v58, v59, *([v2459 @ X8_v25]), v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tthis.w2lRotation = *([v2459 @ X8_v25]);\n\tthis.w2lRotation.y = v2551;\n\tthis.w2lRotation.z = v2550;\n\tthis.w2lRotation.w = v2549;\n\tv2614 = 0x6D26F0(&v1016 @ stack_-178_v33 (Obi.ObiPathFrame), 0, 0x44, v1527, v56, v57, v58, v59, *([v2459 @ X8_v25]), v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tv2619 = 0x6D26F0(&v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), 0, 0x44, v1527, v56, v57, v58, v59, *([v2459 @ X8_v25]), v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tv2625 = 0x6D26F0(&v82 @ stack_-208_v1, 0, 0x44, v1527, v56, v57, v58, v59, *([v2459 @ X8_v25]), v2551, v2550, v2549, v2548, v2547, v66, v67);\n\tv2823 = this.rawChunks;\nL_00A6:\n\tv1531 = v422 >= v2823.count;\n\tif (v1531) goto L_0296;\n\tv2953 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v2823, v422);\n\tv3115 = 0xC2DC74(&v1016 @ stack_-178_v33 (Obi.ObiPathFrame), v422, *([v3709 @ X25_v37 (Il2CppMethodInfo)]), v2561, v56, v57, v58, v59, v60, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv3237 = 0xC2DC74(&v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), v422, *([v3709 @ X25_v37 (Il2CppMethodInfo)]), v2561, v56, v57, v58, v59, v60, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv1588 = 0xC2DC74(&v82 @ stack_-208_v1, v422, *([v3709 @ X25_v37 (Il2CppMethodInfo)]), v2561, v56, v57, v58, v59, v60, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv1549 = actor.elements;\n\tv3240 = v1549._size < v424;\n\tv1917 = ~v3240;\n\tv1915 = v1549._size - v424;\n\tv1911 = v1915 == 0;\n\tv3241 = ~v1911;\n\tv1901 = v1917 & v3241;\n\tif (v1901) goto L_00C6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C6:\n\t*([v38 @ X29_v1-88]) = v2828;\n\tv3243 = v1549._items;\n\tv1953 = v3243[v424 @ X28_v19 (System.Int32)];\n\tv2561 = v1953.particle1;\n\tObi.ObiPathSmoother::PathFrameFromParticle(this, actor, &v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), v1953.particle1);\n\tv3255 = 0x6D2410(&v82 @ stack_-208_v1, &v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), 0x44, v1953.particle1, v56, v57, v58, v59, v60, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv3476 = this.rawChunks;\n\tv1056 = v2953.count - 1;\n\tv3258 = v424 + v1056;\n\tv3259 = v3258 - 1;\nL_00DF:\n\t;\n\tv3479 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v3476, v422);\n\tv1738 = v1009 > v3479.count;\n\tif (v1738) goto L_0255;\n\tv3857 = actor.elements;\n\tv3867 = v1009 >= v1056;\n\tif (v3867) goto L_011D;\n\tv4114 = v424 + v1009;\n\tv4115 = v3857._size < v4114;\n\tv4116 = ~v4115;\n\tv4117 = v3857._size - v4114;\n\tv4119 = v4117 == 0;\n\tv4124 = ~v4119;\n\tv4125 = v4116 & v4124;\n\tif (v4125) goto L_0110;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0110:\n\tv4266 = v3857._items;\n\tv4544 = v4266[v4114 @ X25_v44 (System.Int32)] + 0x10;\n\tgoto L_0132;\nL_011D:\n\tv4127 = v3857._size < v3259;\n\tv4128 = ~v4127;\n\tv4129 = v3857._size - v3259;\n\tv4131 = v4129 == 0;\n\tv4136 = ~v4131;\n\tv4137 = v4128 & v4136;\n\tif (v4137) goto L_012B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_012B:\n\tv4272 = v3857._items;\n\tv4544 = v4272[v3259 @ X8_v46 (System.Int32)] + 0x14;\nL_0132:\n\tv3696 = *([v4544 @ X8_v55]);\n\tObi.ObiPathSmoother::PathFrameFromParticle(this, actor, &v1016 @ stack_-178_v33 (Obi.ObiPathFrame), *([v4544 @ X8_v55]));\n\tv4562 = Obi.ObiActor::get_usesOrientedParticles(actor);\n\tv4564 = v4562 == 0;\n\tif (v4564) goto L_014E;\n\tv4571 = 0x6D2410(&v82 @ stack_-208_v1, &v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), 0x44, *([v4544 @ X8_v55]), v56, v57, v58, v59, v60, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tgoto L_018D;\nL_014E:\n\tgoto L_015B;\n\tv4588 = *([v4582 @ X0_v176+E0]);\n\tv4589 = v4588 == 0;\n\tv4590 = ~v4589;\n\tif (v4590) goto L_015B;\n\tv4592 = \"il2cpp_codegen_runtime_class_init\"(v4582, v4561, v4545, v987, v56, v57, v58, v59, v1764, v1716, v1714, v1712, v1710, v1708, v66, v67);\nL_015B:\n\t// 347 MakeStruct v4602 @ AGGC2F2D8_0_v31 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), v4575 @ stack_-1BC, v4578 @ stack_-1B8\n\t// 348 MakeStruct v4603 @ AGGC2F2D8_1_v31 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v82 @ stack_-208_v1, v4581 @ stack_-204, v4584 @ stack_-200\n\tv4604 = UnityEngine.Vector3::op_Subtraction(v4602, v4603);\n\t// 362 MakeStruct v4614 @ AGGC2F304_0_v31 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1016 @ stack_-178_v33 (Obi.ObiPathFrame), v4641 @ stack_-174, v4643 @ stack_-170\n\t// 363 MakeStruct v4613 @ AGGC2F304_1_v31 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), v4575 @ stack_-1BC, v4578 @ stack_-1B8\n\tv4648 = UnityEngine.Vector3::op_Subtraction(v4614, v4613);\n\tv4670 = UnityEngine.Vector3::op_Addition(v4604, v4648);\n\tv4677 = 0x158A710(&v4670 @ V0_v45 (UnityEngine.Vector3), 0, &v1016 @ stack_-178_v33 (Obi.ObiPathFrame), *([v4544 @ X8_v55]), v56, v57, v58, v59, v4670, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv4688 = 0x6D2410(&v4686 @ stack_-2E8, &v3247 @ stack_-1C0_v22 (Obi.ObiPathFrame), 0x44, *([v4544 @ X8_v55]), v56, v57, v58, v59, v4670, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv60 = this.twist;\n\tv4631 = 0xC2E3A4(&v82 @ stack_-208_v1, &v4686 @ stack_-2E8, 0x44, *([v4544 @ X8_v55]), v56, v57, v58, v59, this.twist, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\nL_018D:\n\tv937 = v424 + v1009;\n\tv991 = v937 <= actor.m_ActiveParticleCount;\n\tif (v991) goto L_022F;\n\tv4674 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(this.rawChunks, 0);\n\tv4681 = 0x6D2410(&v4680 @ stack_-378, &v82 @ stack_-208_v1, 0x44, v3696, v56, v57, v58, v59, v60, v4670.y, v4670.z, v4648, v4648.y, v4648.z, v66, v67);\n\tv1054 = &v321 @ stack_-330;\n\tv4690 = Obi.ObiPathFrame::op_Multiply(0.5f, &v4680 @ stack_-378);\n\tv321 = *([v1054 @ X8_v61]);\n\tv1048 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(this.rawChunks, 0);\n\tv4704 = &v270 @ stack_-3C0;\n\tv4706 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v1048, 0);\n\tv270 = *([v4704 @ X8_v64]);\n\tv4713 = 0x6D2410(&v4710 @ stack_-450, &v270 @ stack_-3C0, 0x44, v3696, v56, v\n// ... truncated")]
		public unsafe void GenerateSmoothChunks(ObiRopeBase actor, uint smoothingLevels)
		{
			//IL_0ab6: Expected I, but got O
			//IL_0ac0: Expected I, but got O
			//IL_00cc: Expected F4, but got I
			//IL_00d8: Expected O, but got I
			//IL_00ef: Expected F4, but got I
			//IL_00ff: Expected F4, but got I
			//IL_0116: Expected F4, but got I
			//IL_0126: Expected F4, but got I
			//IL_013d: Expected F4, but got I
			//IL_01df: Expected F4, but got O
			//IL_04d8: Unknown result type (might be due to invalid IL or missing references)
			//IL_04dd: Expected O, but got Unknown
			//IL_0acd: Expected I4, but got O
			//IL_0adf: Expected I4, but got O
			//IL_0434: Unknown result type (might be due to invalid IL or missing references)
			//IL_0439: Expected O, but got Unknown
			//IL_0503: Expected F4, but got O
			//IL_0510: Expected F4, but got O
			//IL_051d: Expected F4, but got O
			//IL_052a: Expected F4, but got O
			//IL_0537: Expected F4, but got O
			//IL_0544: Expected F4, but got O
			//IL_0562: Expected F4, but got O
			//IL_056f: Expected F4, but got O
			//IL_057c: Expected F4, but got O
			//IL_0589: Expected F4, but got O
			//IL_0596: Expected F4, but got O
			//IL_05a3: Expected F4, but got O
			//IL_07c8: Expected O, but got I
			//IL_07e6: Expected O, but got I
			//IL_080f: Expected O, but got Ref
			//IL_0667: Expected O, but got Ref
			//IL_06d9: Expected O, but got Ref
			//IL_070b: Expected O, but got Ref
			//IL_070b: Expected O, but got Ref
			//IL_0749: Expected O, but got I
			//IL_0762: Expected O, but got I
			//IL_078b: Expected O, but got I4
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			IntPtr markerPtr = (IntPtr)m_GenerateSmoothChunksPerfMarker;
			ProfilerMarker.Internal_Begin((IntPtr)m_GenerateSmoothChunksPerfMarker);
			smoothChunks.Clear();
			smoothLength = 0f;
			if (!Application.isPlaying)
			{
				actor.RebuildElementsFromConstraints();
			}
			AllocateRawChunks(actor);
			Transform transform = actor.transform;
			object obj4 = default(object);
			object obj3 = obj4;
			Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
			obj4 = obj3;
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X8_v25+30]");
			float num = 0f;
			object obj6 = (long)(IntPtr)this + 24L;
			ref Matrix4x4 reference = ref w2l;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X8_v25+30]");
			reference.m03 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X8_v25+20]");
			num = 0f;
			ref Matrix4x4 reference2 = ref w2l;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X8_v25+20]");
			reference2.m02 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X8_v25+10]");
			num = 0f;
			ref Matrix4x4 reference3 = ref w2l;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2459 @ X8_v25+10]");
			reference3.m01 = 0f;
			w2l = (Matrix4x4)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
			w2lRotation = (Quaternion)obj5;
			float y = default(float);
			w2lRotation.y = y;
			float z = default(float);
			w2lRotation.z = z;
			float w = default(float);
			w2lRotation.w = w;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			ObiList<ObiList<ObiPathFrame>> obiList = rawChunks;
			int num2 = 0;
			int num3 = 0;
			IntPtr intPtr = (IntPtr)0;
			num = (float)obj5;
			ObiPathFrame frame = default(ObiPathFrame);
			ObiPathFrame frame2 = default(ObiPathFrame);
			Vector3 vector = default(Vector3);
			object obj8 = default(object);
			object obj9 = default(object);
			Vector3 vector2 = default(Vector3);
			object obj10 = default(object);
			object obj11 = default(object);
			object obj12 = default(object);
			Vector3 vector4 = default(Vector3);
			object obj13 = default(object);
			object obj14 = default(object);
			Vector3 vector5 = default(Vector3);
			object obj16 = default(object);
			object obj17 = default(object);
			object obj19 = default(object);
			object obj21 = default(object);
			object obj22 = default(object);
			object obj23 = default(object);
			object obj24 = default(object);
			object obj26 = default(object);
			object obj29 = default(object);
			int num17;
			while (true)
			{
				if (num2 < obiList.Count)
				{
					ObiList<ObiPathFrame> obiList2 = obiList.get_Item(num2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC74 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x48)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC74 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x48)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC74 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x48)");
					List<ObiStructuralElement> elements = actor.elements;
					bool flag = elements.Count < num3;
					bool flag2 = !flag;
					int num4 = elements.Count - num3;
					bool flag3 = num4 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items = elements._items;
					ObiStructuralElement obiStructuralElement = items[num3];
					int particle = obiStructuralElement.particle1;
					PathFrameFromParticle(actor, ref frame, obiStructuralElement.particle1);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					ObiList<ObiList<ObiPathFrame>> obiList3 = rawChunks;
					int num5 = obiList2.Count - 1;
					int num6 = num3 + num5;
					int num7 = num6 - 1;
					int num8 = 1;
					while (true)
					{
						ObiList<ObiPathFrame> obiList4 = obiList3.get_Item(num2);
						if (num8 > obiList4.Count)
						{
							break;
						}
						List<ObiStructuralElement> elements2 = actor.elements;
						object obj7;
						if (num8 < num5)
						{
							int num9 = num3 + num8;
							bool flag5 = elements2.Count < num9;
							bool flag6 = !flag5;
							int num10 = elements2.Count - num9;
							bool flag7 = num10 == 0;
							bool flag8 = !flag7;
							if (!(flag6 && flag8))
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items2 = elements2._items;
							obj7 = items2[num9] + 16;
							intPtr = (IntPtr)0;
						}
						else
						{
							bool flag9 = elements2.Count < num7;
							bool flag10 = !flag9;
							int num11 = elements2.Count - num7;
							bool flag11 = num11 == 0;
							bool flag12 = !flag11;
							if (!(flag10 && flag12))
							{
								throw new ArgumentOutOfRangeException();
							}
							ObiStructuralElement[] items3 = elements2._items;
							obj7 = items3[num7] + 20;
						}
						int num12 = (int)obj7;
						PathFrameFromParticle(actor, ref frame2, (int)obj7);
						if (actor.usesOrientedParticles)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
						}
						else
						{
							vector.x = (float)frame;
							vector.y = (float)obj8;
							vector.z = (float)obj9;
							vector2.x = (float)obj10;
							vector2.y = (float)obj11;
							vector2.z = (float)obj12;
							Vector3 vector3 = vector - vector2;
							vector4.x = (float)frame2;
							vector4.y = (float)obj13;
							vector4.z = (float)obj14;
							vector5.x = (float)frame;
							vector5.y = (float)obj8;
							vector5.z = (float)obj9;
							Vector3 vector6 = vector4 - vector5;
							Vector3 vector7 = vector3 + vector6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							num = twist;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E3A4 (inside Obi.ObiPathFrame::op_Multiply +0x460)");
						}
						int num13 = num3 + num8;
						if (num13 > actor.activeParticleCount)
						{
							ObiList<ObiPathFrame> obiList5 = rawChunks.get_Item(0);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							object obj15 = obj16;
							ObiPathFrame obiPathFrame = 0.5f * (ObiPathFrame)(&obj17);
							obj16 = obj15;
							ObiList<ObiPathFrame> obiList6 = rawChunks.get_Item(0);
							object obj18 = obj19;
							ObiPathFrame obiPathFrame2 = obiList6.get_Item(0);
							obj19 = obj18;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							object obj20 = obj21;
							ObiPathFrame obiPathFrame3 = 0.5f * (ObiPathFrame)(&obj22);
							obj21 = obj20;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							Vector3 position = ((ObiPathFrame)(&obj23) + (ObiPathFrame)(&obj24)).position;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							object obj25 = (long)(IntPtr)obj2 - 216L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
							ObiPathFrame value = (ObiPathFrame)((long)(IntPtr)obj2 - 216L);
							obiList5.set_Item(0, value);
							((ObiList<ObiPathFrame>)obj10).set_Item((int)(&obj26), (ObiPathFrame)68);
							num12 = 0;
							intPtr = (IntPtr)0;
							num = 0.5f;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
						ObiList<ObiPathFrame> obiList7 = rawChunks.get_Item(num2);
						object obj27 = (long)(IntPtr)obj2 - 216L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
						object obj28 = (long)(IntPtr)obj2 - 216L;
						int num14 = num8 - 1;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
						obiList7.set_Item(num14, (ObiPathFrame)(&obj29));
						num8 = num14 + 2;
						obiList3 = rawChunks;
						bool flag13 = rawChunks == null;
						bool flag14 = !flag13;
						particle = 0;
						intPtr = (IntPtr)0;
						if (!flag14)
						{
							NullReferenceException ex = new NullReferenceException();
							NullReferenceException ex2 = new NullReferenceException();
							throw new NullReferenceException();
						}
					}
					ObiList<ObiPathFrame> input = rawChunks.get_Item(num2);
					ObiList<ObiPathFrame> output = smoothChunks.get_Item(num2);
					Chaikin(input, output, smoothingLevels);
					ObiList<ObiPathFrame> obiList8 = smoothChunks.get_Item(num2);
					int num15 = smoothSections + obiList8.Count;
					int num16 = num15 - 1;
					smoothSections = num16;
					bool flag15 = smoothChunks == null;
					num17 = num2;
					if (flag15)
					{
						break;
					}
					ObiList<ObiPathFrame> obiList9 = smoothChunks.get_Item(num2);
					num = ((ObiPathSmoother)(object)obiList9).CalculateChunkLength(obiList9);
					obiList = rawChunks;
					num3 = num5 + num3;
					num = SmoothLength + num;
					num2++;
					smoothLength = num;
					bool flag16 = rawChunks == null;
					bool flag17 = !flag16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-88]");
					markerPtr = (IntPtr)0;
					intPtr = (IntPtr)0;
					if (!flag17)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				ProfilerMarker.Internal_End(markerPtr);
				return;
			}
			NullReferenceException ex3 = new NullReferenceException();
			object obj30 = default(object);
			while (true)
			{
				if (num17 == 1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-88]");
					ProfilerMarker.Internal_End((IntPtr)0);
					if (obj30 == null)
					{
						break;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				}
				TypeLoadException ex4 = new TypeLoadException();
				num17 = 0;
				ex3 = (NullReferenceException)(object)ex4;
			}
		}

		[Token(Token = "0x60004CB")]
		[Address(RVA = "0xC30648", Offset = "0xC30648", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv40 = *([1ECEB50]);\n\tv41 = *([v40 @ X8_v23]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, mu, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2023178]) = v59;\nL_001F:\n\tv60 = &v27 @ stack_-10_v2 - 0xA8;\n\tv63 = 0x6D26F0(v60, 0, 0x44, v45, v46, v47, v48, v49, mu, v50, v51, v52, v53, v54, v55, v56);\n\tv64 = &v27 @ stack_-10_v2 - 0xF0;\n\tv67 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v64, 0);\n\tgoto L_0036;\n\tv75 = *([v71 @ X0_v6+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tgoto L_0036;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v71, v66, v65, v45, v46, v47, v48, v49, mu, v50, v51, v52, v53, v54, v55, v56);\nL_0036:\n\tv84 = UnityEngine.Mathf::Clamp01(mu);\n\tv211 = this.smoothChunks;\n\tv140 = v84 * this.smoothSections;\n\tv151 = v140 - v140;\nL_0050:\n\tv190 = v170 >= v211.count;\n\tif (v190) goto L_0086;\n\tv220 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v211, v170);\n\tv153 = v140 - v171;\n\tv256 = v220.count + v171;\n\tv126 = v256 - v140;\n\tv123 = v126 < 0;\n\tv120 = v126 == 0;\n\tv117 = v256 ^ v140;\n\tv114 = v256 ^ v126;\n\tv111 = v117 & v114;\n\tv108 = v111 < 0;\n\tv267 = v123 == v108;\n\tv268 = ~v120;\n\tv269 = v267 & v268;\n\tv270 = ~v269;\n\tif (v270) goto L_006C;\n\tgoto L_006C;\nL_006C:\n\tv536 = v123 == v108;\n\tv102 = ~v120;\n\tv105 = v536 & v102;\n\tv99 = ~v105;\n\tif (v99) goto L_0079;\n\tgoto L_0079;\nL_0079:\n\tv253 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(this.smoothChunks, v170);\n\tv211 = this.smoothChunks;\n\tv170 = v170 + 1;\n\tv171 = v253.count + v171;\n\tv568 = this.smoothChunks == 0;\n\tv150 = ~v568;\n\tif (v150) goto L_0050;\n\tv157 = new System.NullReferenceException();\nL_0086:\n\tv218 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v211, v132);\n\tv226 = &v227 @ stack_-148;\n\tv231 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v218, v216);\n\tv227 = *([v226 @ X8_v6]);\n\tv288 = &v27 @ stack_-10_v2 - 0xA8;\n\tv291 = 0x6D2410(v288, &v227 @ stack_-148, 0x44, v45, v46, v47, v48, v49, v140, v207, v51, v52, v53, v54, v55, v56);\n\tgoto L_00B1;\n\tv537 = *([v294 @ X0_v18+E0]);\n\tv538 = v537 == 0;\n\tv539 = ~v538;\n\tif (v539) goto L_00B1;\n\tv541 = \"il2cpp_codegen_runtime_class_init\"(v294, v289, v290, v45, v46, v47, v48, v49, v208, v207, v51, v52, v53, v54, v55, v56);\nL_00B1:\n\tv543 = v216 + 1;\n\tv544 = v218.count - 1;\n\tv546 = UnityEngine.Mathf::Min(v543, v544);\n\tv551 = &v455 @ stack_-190;\n\tv553 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v218, v546);\n\tv455 = *([v551 @ X8_v9]);\n\tv554 = &v27 @ stack_-10_v2 - 0xF0;\n\tv557 = 0x6D2410(v554, &v455 @ stack_-190, 0x44, v45, v46, v47, v48, v49, v140, v207, v51, v52, v53, v54, v55, v56);\n\tv560 = &v27 @ stack_-10_v2 - 0xA8;\n\tv562 = 0x6D2410(&v559 @ stack_-1D8, v560, 0x44, v45, v46, v47, v48, v49, v140, v207, v51, v52, v53, v54, v55, v56);\n\tv564 = 1f - v151;\n\tv565 = &v404 @ stack_-268;\n\tv567 = Obi.ObiPathFrame::op_Multiply(v564, &v559 @ stack_-1D8);\n\tv404 = *([v565 @ X8_v10]);\n\tv571 = &v27 @ stack_-10_v2 - 0xF0;\n\tv572 = 0x6D2410(&v570 @ stack_-220, v571, 0x44, v45, v46, v47, v48, v49, v564, v207, v51, v52, v53, v54, v55, v56);\n\tv573 = &v353 @ stack_-2B0;\n\tv575 = Obi.ObiPathFrame::op_Multiply(v151, &v570 @ stack_-220);\n\tv353 = *([v573 @ X8_v11]);\n\treturnVal2 = Obi.ObiPathFrame::op_Addition(&v404 @ stack_-268, &v353 @ stack_-2B0);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ObiPathFrame GetSectionAt(float mu)
		{
			//IL_0381: Expected O, but got I
			//IL_039a: Expected O, but got I
			//IL_0417: Expected I4, but got F4
			//IL_0244: Expected O, but got I
			//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e1: Expected I4, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected I4, but got Unknown
			//IL_02bf: Expected O, but got I
			//IL_02d8: Expected O, but got I
			//IL_030c: Expected O, but got Ref
			//IL_0327: Expected O, but got I
			//IL_034b: Expected O, but got Ref
			//IL_0364: Expected O, but got Ref
			//IL_0364: Expected O, but got Ref
			//IL_01f9: Expected I4, but got F4
			object obj2 = default(object);
			object obj = (long)(IntPtr)obj2 - 168L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			ObiList<ObiList<ObiPathFrame>> obiList = (ObiList<ObiList<ObiPathFrame>>)((long)(IntPtr)obj2 - 240L);
			ObiList<ObiPathFrame> obiList2 = obiList.get_Item(0);
			float num = Mathf.Clamp01(mu);
			ObiList<ObiList<ObiPathFrame>> obiList3 = smoothChunks;
			float num2 = num * (float)smoothSections;
			float num3 = num2 - num2;
			int num4 = -1;
			int num5 = 0;
			int num6 = 0;
			float num7 = float.NaN;
			int num9;
			while (true)
			{
				bool flag = num5 >= obiList3.Count;
				float num8 = num2;
				num9 = (int)num7;
				if (flag)
				{
					break;
				}
				ObiList<ObiPathFrame> obiList4 = obiList3.get_Item(num5);
				float num10 = num2 - (float)num6;
				int num11 = obiList4.Count + num6;
				float num12 = (float)num11 - num2;
				bool flag2 = num12 < 0f;
				bool flag3 = num12 == 0f;
				int num13 = num11 ^ num2;
				int num14 = num11 ^ num12;
				int num15 = num13 & num14;
				bool flag4 = num15 < 0;
				bool flag5 = flag2 == flag4;
				bool flag6 = !flag3;
				if (flag5 && flag6)
				{
					num7 = num10;
				}
				bool flag7 = flag2 == flag4;
				bool flag8 = !flag3;
				if (flag7 && flag8)
				{
					num4 = num5;
				}
				ObiList<ObiPathFrame> obiList5 = smoothChunks.get_Item(num5);
				obiList3 = smoothChunks;
				num5++;
				num6 = obiList5.Count + num6;
				bool flag9 = smoothChunks == null;
				bool flag10 = !flag9;
				num8 = num2;
				if (!flag10)
				{
					NullReferenceException ex = new NullReferenceException();
					num4 = num4;
					obiList3 = (ObiList<ObiList<ObiPathFrame>>)(object)ex;
					num9 = (int)num7;
					break;
				}
			}
			ObiList<ObiPathFrame> obiList6 = obiList3.get_Item(num4);
			object obj4 = default(object);
			object obj3 = obj4;
			ObiPathFrame obiPathFrame = obiList6.get_Item(num9);
			obj4 = obj3;
			object obj5 = (long)(IntPtr)obj2 - 168L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			int a = num9 + 1;
			int b = obiList6.Count - 1;
			int index = Mathf.Min(a, b);
			object obj7 = default(object);
			object obj6 = obj7;
			ObiPathFrame obiPathFrame2 = obiList6.get_Item(index);
			obj7 = obj6;
			object obj8 = (long)(IntPtr)obj2 - 240L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			object obj9 = (long)(IntPtr)obj2 - 168L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			float num16 = 1f - num3;
			object obj11 = default(object);
			object obj10 = obj11;
			object obj12 = default(object);
			ObiPathFrame obiPathFrame3 = num16 * (ObiPathFrame)(&obj12);
			obj11 = obj10;
			object obj13 = (long)(IntPtr)obj2 - 240L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			object obj15 = default(object);
			object obj14 = obj15;
			object obj16 = default(object);
			ObiPathFrame obiPathFrame4 = num3 * (ObiPathFrame)(&obj16);
			obj15 = obj14;
			return (ObiPathFrame)(&obj11) + (ObiPathFrame)(&obj15);
		}

		[Token(Token = "0x60004CC")]
		[Address(RVA = "0xC30110", Offset = "0xC30110", Length = "0x538")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv54 = *([1F04E18]);\n\tv55 = *([v54 @ X8_v56]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, output, k, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv72 = 0 | 1;\n\t*([2023179]) = v72;\nL_0026:\n\tv73 = k == 0;\n\tif (v73) goto L_02C5;\n\tv88 = input.count <= 2;\n\tif (v88) goto L_02C5;\n\tgoto L_0047;\n\tv159 = *([v150 @ X0_v13 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tif (v161) goto L_0047;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v150, output, k, methodInfo, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv162 = *([v48 @ X20_v1 (Obi.ObiList`1<Obi.ObiPathFrame>)+18]);\nL_0047:\n\tv169 = 0x6D28C0(UnityEngine.Mathf, output, k, v1377, v58, v59, v60, v61, k, v63, v64, v65, v66, v67, v68, v69);\n\tv1028 = k + 1;\n\tv1029 = 0 - v1028;\n\tv1031 = 0x6D28C0(v169, output, k, v1377, v58, v59, v60, v61, v1029, v63, v64, v65, v66, v67, v68, v69);\n\tv1374 = 0 - k;\n\tv1376 = 0x6D28C0(v1031, output, k, v1377, v58, v59, v60, v61, v1374, v63, v64, v65, v66, v67, v68, v69);\n\tv97 = k << 1;\n\tv1415 = 0 - v97;\n\tv1417 = 0x6D28C0(v1376, output, k, v1377, v58, v59, v60, v61, v1415, v63, v64, v65, v66, v67, v68, v69);\n\tv142 = -1 ^ k;\n\tv137 = 0x6D28C0(v1417, output, k, v1377, v58, v59, v60, v61, v142, v63, v64, v65, v66, v67, v68, v69);\n\tv1427 = input.count - 2;\n\tv1431 = v1427 * k;\n\tv1432 = 2 + v1431;\n\tv1433 = input.count - 1;\n\tObi.ObiList`1<Obi.ObiPathFrame>::SetCount(output, v1432);\n\tv1435 = &v1320 @ stack_-130_v3 (UnityEngine.Vector3);\n\tv1439 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, 0);\n\tv1320 = *([v1435 @ X8_v24]);\n\tv1341 = v1029 + 0.5f;\n\tv1462 = 0x6D2410(&v1459 @ stack_-178, &v1320 @ stack_-130_v3 (UnityEngine.Vector3), 0x44, v1377, v58, v59, v60, v61, v142, v63, v64, v65, v66, v67, v68, v69);\n\tv1463 = &v900 @ stack_-250;\n\tv1466 = Obi.ObiPathFrame::op_Multiply(v1341, &v1459 @ stack_-178);\n\tv900 = *([v1463 @ X8_v25]);\n\tv1468 = &v1268 @ stack_-1C0_v4 (UnityEngine.Vector3);\n\tv1472 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, 1);\n\tv1268 = *([v1468 @ X8_v26]);\n\tv1338 = 0.5f - v1029;\n\tv1494 = 0x6D2410(&v1491 @ stack_-208, &v1268 @ stack_-1C0_v4 (UnityEngine.Vector3), 0x44, v1377, v58, v59, v60, v61, v1341, v63, v64, v65, v66, v67, v68, v69);\n\tv1495 = &v798 @ stack_-298;\n\tv1498 = Obi.ObiPathFrame::op_Multiply(v1338, &v1491 @ stack_-208);\n\tv798 = *([v1495 @ X8_v27]);\n\tv1499 = &v747 @ stack_-2E0;\n\tv1502 = Obi.ObiPathFrame::op_Addition(&v900 @ stack_-250, &v798 @ stack_-298);\n\tv747 = *([v1499 @ X8_v28]);\n\tv1504 = &v41 @ stack_-10_v2 - 0xD8;\n\tv1508 = 0x6D2410(v1504, &v747 @ stack_-2E0, 0x44, v1377, v58, v59, v60, v61, v1338, v63, v64, v65, v66, v67, v68, v69);\n\tv1509 = &v41 @ stack_-10_v2 - 0xD8;\n\tObi.ObiList`1<Obi.ObiPathFrame>::set_Item(output, 0, v1509);\n\tv1514 = &v692 @ stack_-328;\n\tv1517 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v1427);\n\tv692 = *([v1514 @ X8_v29]);\n\tv1539 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(&v1536 @ stack_-370, &v692 @ stack_-328, 0x44);\n\tv1540 = &v641 @ stack_-448;\n\tv1543 = Obi.ObiPathFrame::op_Multiply(v1338, &v1536 @ stack_-370);\n\tv641 = *([v1540 @ X8_v30]);\n\tv1545 = &v590 @ stack_-3B8;\n\tv1548 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v1433);\n\tv590 = *([v1545 @ X8_v31]);\n\tv1553 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(&v1550 @ stack_-400, &v590 @ stack_-3B8, 0x44);\n\tv1554 = &v539 @ stack_-490;\n\tv1557 = Obi.ObiPathFrame::op_Multiply(v1341, &v1550 @ stack_-400);\n\tv539 = *([v1554 @ X8_v32]);\n\tv1558 = &v488 @ stack_-4D8;\n\tv1561 = Obi.ObiPathFrame::op_Addition(&v641 @ stack_-448, &v539 @ stack_-490);\n\tv488 = *([v1558 @ X8_v33]);\n\tv1563 = 1 - k;\n\tv1564 = &v41 @ stack_-10_v2 - 0xD8;\n\tv1363 = v1433 * k;\n\tv1567 = v1563 + v1363;\n\tv1568 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(v1564, &v488 @ stack_-4D8, 0x44);\n\tv1569 = &v41 @ stack_-10_v2 - 0xD8;\n\tObi.ObiList`1<Obi.ObiPathFrame>::set_Item(output, v1567, v1569);\n\tv1583 = k < 1;\n\tif (v1583) goto L_0279;\nL_0189:\n\tv1961 = v1433 < 2;\n\tif (v1961) goto L_026A;\n\tv1968 = v1947 - 1;\n\tv1969 = v142 * v1947;\n\tv1970 = v1415 * v1947;\n\tv1972 = v1968 * v1947;\n\tv1973 = v1374 - v1969;\n\tv1974 = v1374 - v1970;\n\tv1975 = v1973 * v1968;\n\tv1976 = v1974 * v1968;\n\tv1978 = v142 * v1972;\n\tv1979 = v1338 - v1975;\n\tv1980 = v1341 + v1976;\nL_019C:\n\tv2308 = v2306 - 2;\n\tv2309 = &v1320 @ stack_-130_v3 (UnityEngine.Vector3);\n\tv2311 = v2306 - 1;\n\tv2312 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v2308);\n\tv1320 = *([v2309 @ X8_v45]);\n\tv2323 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(&v2320 @ stack_-520, &v1320 @ stack_-130_v3 (UnityEngine.Vector3), 0x44);\n\tv2328 = &v426 @ stack_-5B0;\n\tv2331 = Obi.ObiPathFrame::op_Multiply(v1979, &v2320 @ stack_-520);\n\tv426 = *([v2328 @ X8_v46]);\n\tv2333 = &v1268 @ stack_-1C0_v4 (UnityEngine.Vector3);\n\tv2336 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v2311);\n\tv1268 = *([v2333 @ X8_v47]);\n\tv2341 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(&v2338 @ stack_-568, &v1268 @ stack_-1C0_v4 (UnityEngine.Vector3), 0x44);\n\tv2342 = &v375 @ stack_-5F8;\n\tv2345 = Obi.ObiPathFrame::op_Multiply(v1980, &v2338 @ stack_-568);\n\tv375 = *([v2342 @ X8_v48]);\n\tv2346 = &v324 @ stack_-688;\n\tv2349 = Obi.ObiPathFrame::op_Addition(&v426 @ stack_-5B0, &v375 @ stack_-5F8);\n\tv324 = *([v2346 @ X8_v49]);\n\tv2351 = &v692 @ stack_-328;\n\tv2354 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v2306);\n\tv692 = *([v2351 @ X8_v50]);\n\tv2359 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(&v2356 @ stack_-640, &v692 @ stack_-328, 0x44);\n\tv2360 = &v273 @ stack_-6D0;\n\tv2362 = Obi.ObiPathFrame::op_Multiply(v1978, &v2356 @ stack_-640);\n\tv273 = *([v2360 @ X8_v51]);\n\tv2365 = Obi.ObiPathFrame::op_Addition(&v324 @ stack_-688, &v273 @ stack_-6D0);\n\tv1999 = v2365.position;\n\tv2366 = &v41 @ stack_-10_v2 - 0xD8;\n\tv2369 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(v2366, &v1999 @ stack_-718_v6 (UnityEngine.Vector3), 0x44);\n\tv2122 = &v41 @ stack_-10_v2 - 0xD8;\n\tObi.ObiList`1<Obi.ObiPathFrame>::set_Item(output, v2293, v2122);\n\tv2306 = v2306 + 1;\n\tv2293 = v2293 + k;\n\tv2126 = input.count != v2306;\n\tif (v2126) goto L_019C;\nL_026A:\n\tv1947 = v1947 + 1;\n\tv1769 = v1947 <= k;\n\tif (v1769) goto L_0189;\nL_0279:\n\tv1786 = &v1320 @ stack_-130_v3 (UnityEngine.Vector3);\n\tv1789 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, 0);\n\tv1320 = *([v1786 @ X8_v36]);\n\tv1963 = &v41 @ stack_-10_v2 - 0xD8;\n\tv1966 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(v1963, &v1320 @ stack_-130_v3 (UnityEngine.Vector3), 0x44);\n\tv2149 = &v41 @ stack_-10_v2 - 0xD8;\n\tObi.ObiList`1<Obi.ObiPathFrame>::set_Item(output, 0, v2149);\n\tv2317 = input.count - 1;\n\tv2318 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v2317);\n\tv1268 = v2318.position;\n\tv2324 = &v41 @ stack_-10_v2 - 0xD8;\n\tv1368 = output.count - 1;\n\tv2327 = Obi.ObiList`1<Obi.ObiPathFrame>::set_Item(v2324, &v1268 @ stack_-1C0_v4 (UnityEngine.Vector3), 0x44);\n\tv1329 = &v41 @ stack_-10_v2 - 0xD8;\n\tObi.ObiList`1<Obi.ObiPathFrame>::set_Item(output, v1368, v1329);\n\tgoto L_031C;\nL_02C5:\n\tObi.ObiList`1<Obi.ObiPathFrame>::SetCount(output, input.count);\n\tv1027 = input.count < 1;\n\tif (v1027) goto L_031C;\nL_02DC:\n\tv1414 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(input, v1407);\n\tv1320 = v1414.position;\n\tv1418 = &v41 @ stack_-10_v2 - 0xD8;\n\tv1421 = 0x6D2410(v1418, &v1320 @ stack_-130_v3 (UnityEngine.Vector3), 0x44, Il2CppMethodInfo, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69);\n\tv1328 = &v41 @ stack_-10_v2 - 0xD8;\n\tObi.ObiList`1<Obi.ObiPathFrame>::set_Item(output, v1407, v1328);\n\tv1407 = v1407 + 1;\n\tv1342 = v1407 < input.count;\n\tif (v1342) goto L_02DC;\nL_031C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 635 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Chaikin(ObiList<ObiPathFrame> input, ObiList<ObiPathFrame> output, uint k)
		{
			//IL_085c: Expected O, but got I
			//IL_0875: Expected O, but got I
			//IL_0117: Expected O, but got Ref
			//IL_017f: Expected O, but got Ref
			//IL_01a0: Expected O, but got Ref
			//IL_01a0: Expected O, but got Ref
			//IL_01c0: Expected O, but got I
			//IL_01d9: Expected O, but got I
			//IL_0223: Expected O, but got I4
			//IL_023d: Expected O, but got Ref
			//IL_0281: Expected O, but got I4
			//IL_0296: Expected O, but got Ref
			//IL_02bc: Expected O, but got Ref
			//IL_02bc: Expected O, but got Ref
			//IL_02e5: Expected O, but got I
			//IL_0311: Expected O, but got I4
			//IL_0325: Expected O, but got I
			//IL_05fd: Expected O, but got I
			//IL_060f: Expected O, but got I4
			//IL_0623: Expected O, but got I
			//IL_067a: Expected O, but got I
			//IL_069f: Expected O, but got I4
			//IL_06ae: Expected O, but got I
			//IL_07f4: Expected O, but got I4
			//IL_0809: Expected O, but got Ref
			//IL_044e: Expected O, but got I4
			//IL_0468: Expected O, but got Ref
			//IL_0489: Expected O, but got Ref
			//IL_0489: Expected O, but got Ref
			//IL_04cd: Expected O, but got I4
			//IL_04e8: Expected O, but got Ref
			//IL_0501: Expected O, but got Ref
			//IL_0501: Expected O, but got Ref
			//IL_0526: Expected O, but got I
			//IL_0538: Expected O, but got I4
			//IL_0547: Expected O, but got I
			Vector3 vector = default(Vector3);
			object obj12 = default(object);
			if (k != 0 && input.Count > 2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				int num = (int)(k + 1);
				int num2 = -num;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				int num3 = (int)(0 - k);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				int num4 = (int)(k << 1);
				int num5 = -num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				int num6 = -1 ^ (int)k;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				int num7 = input.Count - 2;
				int num8 = num7 * (int)k;
				int count = 2 + num8;
				int num9 = input.Count - 1;
				output.SetCount(count);
				object obj = vector;
				ObiPathFrame obiPathFrame = input.get_Item(0);
				vector = (Vector3)obj;
				float num10 = (float)num2 + 0.5f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				object obj3 = default(object);
				object obj2 = obj3;
				object obj4 = default(object);
				ObiPathFrame obiPathFrame2 = num10 * (ObiPathFrame)(&obj4);
				obj3 = obj2;
				Vector3 vector2 = default(Vector3);
				object obj5 = vector2;
				ObiPathFrame obiPathFrame3 = input.get_Item(1);
				vector2 = (Vector3)obj5;
				float num11 = 0.5f - (float)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				object obj7 = default(object);
				object obj6 = obj7;
				object obj8 = default(object);
				ObiPathFrame obiPathFrame4 = num11 * (ObiPathFrame)(&obj8);
				obj7 = obj6;
				object obj10 = default(object);
				object obj9 = obj10;
				ObiPathFrame obiPathFrame5 = (ObiPathFrame)(&obj3) + (ObiPathFrame)(&obj7);
				obj10 = obj9;
				object obj11 = (long)(IntPtr)obj12 - 216L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				ObiPathFrame value = (ObiPathFrame)((long)(IntPtr)obj12 - 216L);
				output.set_Item(0, value);
				object obj14 = default(object);
				object obj13 = obj14;
				ObiPathFrame obiPathFrame6 = input.get_Item(num7);
				obj14 = obj13;
				object obj15 = default(object);
				((ObiList<ObiPathFrame>)obj15).set_Item((int)(&obj14), (ObiPathFrame)68);
				object obj17 = default(object);
				object obj16 = obj17;
				ObiPathFrame obiPathFrame7 = num11 * (ObiPathFrame)(&obj15);
				obj17 = obj16;
				object obj19 = default(object);
				object obj18 = obj19;
				ObiPathFrame obiPathFrame8 = input.get_Item(num9);
				obj19 = obj18;
				object obj20 = default(object);
				((ObiList<ObiPathFrame>)obj20).set_Item((int)(&obj19), (ObiPathFrame)68);
				object obj22 = default(object);
				object obj21 = obj22;
				ObiPathFrame obiPathFrame9 = num10 * (ObiPathFrame)(&obj20);
				obj22 = obj21;
				object obj24 = default(object);
				object obj23 = obj24;
				ObiPathFrame obiPathFrame10 = (ObiPathFrame)(&obj17) + (ObiPathFrame)(&obj22);
				obj24 = obj23;
				int num12 = (int)(1 - k);
				ObiList<ObiPathFrame> obiList = (ObiList<ObiPathFrame>)((long)(IntPtr)obj12 - 216L);
				int num13 = num9 * (int)k;
				int index = num12 + num13;
				obiList.set_Item((int)(&obj24), (ObiPathFrame)68);
				ObiPathFrame value2 = (ObiPathFrame)((long)(IntPtr)obj12 - 216L);
				output.set_Item(index, value2);
				if ((int)k >= 1)
				{
					int num14 = 1;
					object obj26 = default(object);
					object obj28 = default(object);
					object obj30 = default(object);
					object obj32 = default(object);
					object obj34 = default(object);
					object obj36 = default(object);
					object obj38 = default(object);
					do
					{
						if (num9 >= 2)
						{
							int num15 = num14 - 1;
							int num16 = num6 * num14;
							int num17 = num5 * num14;
							int num18 = num15 * num14;
							int num19 = num3 - num16;
							int num20 = num3 - num17;
							int num21 = num19 * num15;
							float num22 = (float)num20 * (float)num15;
							int num23 = num6 * num18;
							float num24 = num11 - (float)num21;
							float num25 = num10 + num22;
							int num26 = num14;
							int num27 = 2;
							do
							{
								int index2 = num27 - 2;
								object obj25 = vector;
								int index3 = num27 - 1;
								ObiPathFrame obiPathFrame11 = input.get_Item(index2);
								vector = (Vector3)obj25;
								((ObiList<ObiPathFrame>)obj26).set_Item((int)(&vector), (ObiPathFrame)68);
								object obj27 = obj28;
								ObiPathFrame obiPathFrame12 = num24 * (ObiPathFrame)(&obj26);
								obj28 = obj27;
								object obj29 = vector2;
								ObiPathFrame obiPathFrame13 = input.get_Item(index3);
								vector2 = (Vector3)obj29;
								((ObiList<ObiPathFrame>)obj30).set_Item((int)(&vector2), (ObiPathFrame)68);
								object obj31 = obj32;
								ObiPathFrame obiPathFrame14 = num25 * (ObiPathFrame)(&obj30);
								obj32 = obj31;
								object obj33 = obj34;
								ObiPathFrame obiPathFrame15 = (ObiPathFrame)(&obj28) + (ObiPathFrame)(&obj32);
								obj34 = obj33;
								object obj35 = obj14;
								ObiPathFrame obiPathFrame16 = input.get_Item(num27);
								obj14 = obj35;
								((ObiList<ObiPathFrame>)obj36).set_Item((int)(&obj14), (ObiPathFrame)68);
								object obj37 = obj38;
								ObiPathFrame obiPathFrame17 = num23 * (ObiPathFrame)(&obj36);
								obj38 = obj37;
								Vector3 position = ((ObiPathFrame)(&obj34) + (ObiPathFrame)(&obj38)).position;
								ObiList<ObiPathFrame> obiList2 = (ObiList<ObiPathFrame>)((long)(IntPtr)obj12 - 216L);
								obiList2.set_Item((int)(&position), (ObiPathFrame)68);
								ObiPathFrame value3 = (ObiPathFrame)((long)(IntPtr)obj12 - 216L);
								output.set_Item(num26, value3);
								num27++;
								num26 += (int)k;
							}
							while (input.Count != num27);
						}
						num14++;
					}
					while (num14 <= (int)k);
				}
				object obj39 = vector;
				ObiPathFrame obiPathFrame18 = input.get_Item(0);
				vector = (Vector3)obj39;
				ObiList<ObiPathFrame> obiList3 = (ObiList<ObiPathFrame>)((long)(IntPtr)obj12 - 216L);
				obiList3.set_Item((int)(&vector), (ObiPathFrame)68);
				ObiPathFrame value4 = (ObiPathFrame)((long)(IntPtr)obj12 - 216L);
				output.set_Item(0, value4);
				int index4 = input.Count - 1;
				vector2 = input.get_Item(index4).position;
				ObiList<ObiPathFrame> obiList4 = (ObiList<ObiPathFrame>)((long)(IntPtr)obj12 - 216L);
				int index5 = output.Count - 1;
				obiList4.set_Item((int)(&vector2), (ObiPathFrame)68);
				ObiPathFrame value5 = (ObiPathFrame)((long)(IntPtr)obj12 - 216L);
				output.set_Item(index5, value5);
				return;
			}
			output.SetCount(input.Count);
			if (input.Count >= 1)
			{
				int num28 = 0;
				do
				{
					vector = input.get_Item(num28).position;
					object obj40 = (long)(IntPtr)obj12 - 216L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
					ObiPathFrame value6 = (ObiPathFrame)((long)(IntPtr)obj12 - 216L);
					output.set_Item(num28, value6);
					num28++;
				}
				while (num28 < input.Count);
			}
		}

		[Token(Token = "0x60004CD")]
		[Address(RVA = "0xC30890", Offset = "0xC30890", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE7EA8]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202317A]) = v42;\nL_0018:\n\tv46 = new Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>();\n\tObi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::.ctor(v46);\n\tthis.rawChunks = v46;\n\tv52 = new Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>();\n\tObi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::.ctor(v52);\n\tthis.smoothChunks = v52;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPathSmoother()
		{
			ObiList<ObiList<ObiPathFrame>> obiList = new ObiList<ObiList<ObiPathFrame>>();
			rawChunks = obiList;
			ObiList<ObiList<ObiPathFrame>> obiList2 = new ObiList<ObiList<ObiPathFrame>>();
			smoothChunks = obiList2;
		}

		[Token(Token = "0x60004CE")]
		[Address(RVA = "0xC30920", Offset = "0xC30920", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EAB678]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202317B]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"AllocateRawChunks\", 0);\n\tv47.m_AllocateRawChunksPerfMarker = v41;\n\tv51 = Unity.Profiling.ProfilerMarker::Internal_Create(\"GenerateSmoothChunks\", 0);\n\tv53.m_GenerateSmoothChunksPerfMarker = v51;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiPathSmoother()
		{
			//IL_002a: Expected O, but got I
			//IL_004f: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("AllocateRawChunks", default(Unity.Profiling.MarkerFlags));
			m_AllocateRawChunksPerfMarker = (ProfilerMarker)(long)intPtr;
			IntPtr intPtr2 = ProfilerMarker.Internal_Create("GenerateSmoothChunks", default(Unity.Profiling.MarkerFlags));
			m_GenerateSmoothChunksPerfMarker = (ProfilerMarker)(long)intPtr2;
		}
	}
}
