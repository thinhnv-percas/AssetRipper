using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using Unity.Mathematics;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x200000A")]
	public class VertexGrid<T> : IDisposable where T : struct
	{
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x0")]
		private readonly VoxelGrid<T> _voxelGrid;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x0")]
		private readonly ConnectedVoxelMeshConfig<T> _meshConfig;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x0")]
		private readonly Dictionary<int3, VertexView<T>> _vertexViews;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x0")]
		private readonly HashSet<int3> _dirtyVertices;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x0")]
		private readonly float3 _gridOffset;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x0")]
		private readonly Transform _parent;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x0")]
		private bool _autoRebuild;

		[Token(Token = "0x1700000E")]
		public Transform Parent
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x6BAB904", Offset = "0x6BAB904", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Parent;\n")]
			get
			{
				return _parent;
			}
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x6BAB90C", Offset = "0x6BAB90C", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv99 = UnityEngine.GameObject::get_transform(v84);\n\tUnityEngine.Transform::SetParent(v99, transform);\n\tgoto L_0066;\n\tthis.Parent = v99;\n\tthis._gridOffset.x = offset;\n\tthis._gridOffset.y = offset.y;\n\tthis._gridOffset.z = offset.z;\n\tgoto L_00B0;\nL_00B0:\n\tv289 = new Il2CppClass<System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>>();\n\tSystem.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>::.ctor(v289);\n\tthis._vertexViews = v289;\n\tv299 = new System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>();\n\tSystem.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::.ctor(v299);\n\tthis._dirtyVertices = v299;\n\tv134 = new System.Action`1<Unity.Mathematics.int3>();\n\tSystem.Action`1<Unity.Mathematics.int3>::.ctor(v134, this, Il2CppMethodInfo);\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::add_OnVoxelChanged(this._voxelGrid, v134);\n\tthis._autoRebuild = 1;\n\treturn;\nL_003B:\n\tSystem.Object::.ctor(this);\n\tv84 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v84, \"VoxelParent\");\nL_0066:\n\tgoto L_0077;\nL_0092:\n\t// 146 MakeStruct v116 @ AGG6BABAD4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v264.one (UnityEngine.Vector3), v264.one.y (System.Single), v264.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v99, v116);\n\tthis._voxelGrid = voxelGrid;\n\tthis._meshConfig = meshConfig;\nL_0077:\n\t// 119 MakeStruct v105 @ AGG6BABA80_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v228.zero (UnityEngine.Vector3), v228.zero.y (System.Single), v228.zero.z (System.Single)\n\t// 120 MakeStruct v102 @ AGG6BABA80_2_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v243.identity (UnityEngine.Quaternion), v243.identity.y (System.Single), v243.identity.z (System.Single), v243.identity.w (System.Single)\n\tUnityEngine.Transform::SetLocalPositionAndRotation(v99, v105, v102);\n\tgoto L_0092;\n")]
		public VertexGrid(VoxelGrid<T> voxelGrid, ConnectedVoxelMeshConfig<T> meshConfig, float3 offset, Transform transform)
		{
			GameObject gameObject = new GameObject("VoxelParent");
			Transform transform2 = gameObject.transform;
			transform2.SetParent(transform);
			Vector3 localPosition = default(Vector3);
			localPosition.x = Vector3.zero.x;
			localPosition.y = Vector3.zero.y;
			localPosition.z = Vector3.zero.z;
			Quaternion localRotation = default(Quaternion);
			localRotation.x = Quaternion.identity.x;
			localRotation.y = Quaternion.identity.y;
			localRotation.z = Quaternion.identity.z;
			localRotation.w = Quaternion.identity.w;
			transform2.SetLocalPositionAndRotation(localPosition, localRotation);
			Vector3 localScale = default(Vector3);
			localScale.x = Vector3.one.x;
			localScale.y = Vector3.one.y;
			localScale.z = Vector3.one.z;
			transform2.localScale = localScale;
			_voxelGrid = voxelGrid;
			_meshConfig = meshConfig;
			_parent = transform2;
			_gridOffset.x = offset.x;
			_gridOffset.y = offset.y;
			_gridOffset.z = offset.z;
			_vertexViews = new Dictionary<int3, VertexView<T>>();
			_dirtyVertices = new HashSet<int3>();
			Action<int3> value = OnVoxelChanged;
			_voxelGrid.add_OnVoxelChanged(value);
			_autoRebuild = true;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x6BABBF0", Offset = "0x6BABBF0", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::remove_OnVoxelChanged(this._voxelGrid, v52);\n\tv70 = this._vertexViews == 0;\n\tv65 = v52;\n\tif (v70) goto L_0068;\n\tv78 = System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>::GetEnumerator(this._vertexViews);\n\tv90 = v78._dictionary;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1::DestroyObject /* +1 sharing this address */(*([v78 @ X0_v23 (System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>+Enumerator<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>)+20]), *([v192 @ X8_v22+90]));\n\tgoto L_0048;\nL_0055:\n\tv212 = &v105 @ stack_-38_v5;\n\tv213 = *([v212 @ X8_v23]);\n\tv214 = *([v213 @ X8_v24+20]);\n\tv215 = *([v214 @ X8_v25+C0]);\n\tv256 = *([v215 @ X8_v26+98]);\n\tSystem.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, System.Object>+Enumerator<Unity.Mathematics.int3, System.Object>::Dispose(&v90 @ stack_-70_v5 (System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>));\n\tv135 = 0;\n\tgoto L_0085;\nL_005F:\n\tConnectedVoxelSystem.Runtime.VertexGrid`1::DestroyObject /* +1 sharing this address */(this.Parent, v256);\n\treturn;\nL_0068:\n\tv72 = new System.NullReferenceException();\n\tgoto L_0074;\nL_0074:\n\tv89 = v65 != 1;\n\tv181 = v72;\n\tif (v89) goto L_0088;\n\tv108 = 0x8BF5BC4(v72, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv199 = 0x8BF5BF4(v108, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv205 = *([v129 @ stack_-78]);\n\tv206 = *([v205 @ X8_v9+20]);\n\tv207 = *([v206 @ X8_v10+C0]);\n\tv256 = *([v207 @ X8_v11+98]);\n\tSystem.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, System.Object>+Enumerator<Unity.Mathematics.int3, System.Object>::Dispose(v132);\n\tv217 = *([v108 @ X0_v16]) == 0;\n\tv135 = *([v108 @ X0_v16]);\n\tif (v217) goto L_005F;\nL_0085:\n\tv174 = new System.OutOfMemoryException();\n\tv181 = v174;\n\treturn;\nL_001E:\n\tv52 = new System.Action`1<Unity.Mathematics.int3>();\n\tSystem.Action`1<Unity.Mathematics.int3>::.ctor(v52, this, Il2CppMethodInfo);\n\tv59 = this._voxelGrid == 0;\n\tv65 = this;\n\tif (v59) goto L_0068;\nL_0048:\n\tv194 = *([v105 @ stack_-38_v5+20]);\n\tv192 = *([v194 @ X8_v21+C0]);\n\tv196 = System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, System.Object>+Enumerator<Unity.Mathematics.int3, System.Object>::MoveNext(&v90 @ stack_-70_v5 (System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>));\n\tv190 = v196 == 0;\n\tif (v190) goto L_0055;\nL_0088:\n\tv184 = 0x34BB0B0(&v135 @ stack_-88 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv201 = 0x8BF0368(v181, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv209 = 0xA1B8(v201, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public unsafe void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VertexGrid::Dispose");
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x6BABD80", Offset = "0x6BABD80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._autoRebuild = 0;\n\treturn;\n")]
		public void BeginBatch()
		{
			_autoRebuild = false;
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x6BABD88", Offset = "0x6BABD88", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._autoRebuild = 1;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::RebuildDirtyVertices(this);\n\treturn;\n")]
		public void EndBatch()
		{
			_autoRebuild = true;
			RebuildDirtyVertices();
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x6BABDA0", Offset = "0x6BABDA0", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv61 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, obj);\n\tv88 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, obj);\n\tv63 = obj & 0xFFFFFFFF00000000;\n\tv81 = obj + 1;\n\tv66 = v63 | v81;\n\tv160 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, v66);\n\tv127 = v63 | v81;\n\tv135 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, v127);\n\tv96 = this._autoRebuild != 1;\n\tif (v96) goto L_0066;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::RebuildDirtyVertices(this);\n\treturn;\nL_0066:\n\treturn;\n")]
		private void OnVoxelChanged(int3 obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VertexGrid::OnVoxelChanged");
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x6BABEB0", Offset = "0x6BABEB0", Length = "0x58C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv86 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::GetEnumerator(this._dirtyVertices);\n\tv235 = v86;\nL_FFFFFFFF:\n\tv409 = this;\n\tv450 = v409._vertexViews == 0;\n\tif (v450) goto L_0195;\n\tv392 = v86._current;\n\tv465 = System.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>::Remove(v409._vertexViews, v86._current, &v381 @ stack_-C8_v6 (ConnectedVoxelSystem.Runtime.VertexView`1<T>));\n\tv474 = v465 == 0;\n\tif (v474) goto L_006A;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1::DestroyObject /* +1 sharing this address */(v381, v86._current);\nL_006A:\n\tv481 = v409._voxelGrid == 0;\n\tif (v481) goto L_0197;\n\tv639 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(v409._voxelGrid, v86._current, v392.y, v458);\n\tv541 = v409._voxelGrid == 0;\n\tif (v541) goto L_0191;\n\tv499 = v86._current - 1;\n\tv642 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(v409._voxelGrid, v499, v392.y, v458);\n\tv542 = v409._voxelGrid == 0;\n\tif (v542) goto L_0193;\n\tv496 = v458 - 1;\n\tv645 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(v409._voxelGrid, v499, v392.y, v496);\n\tv540 = v409._voxelGrid == 0;\n\tif (v540) goto L_018F;\n\tv649 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(v409._voxelGrid, v86._current, v392.y, v496);\n\tv543 = v409._meshConfig == 0;\n\tif (v543) goto L_0199;\n\tv371 = v639 & 0xFFFF;\n\tv366 = v642 & 0xFFFF;\n\tv364 = v645 & 0xFFFF;\n\tv368 = v649 & 0xFFFF;\n\tv401 = ConnectedVoxelSystem.Runtime.ConnectedVoxelMeshConfig`1<T>::GetMatchingVertexMesh(v409._meshConfig, v371, v366, v364, v368, &v354 @ stack_-DC_v6 (ConnectedVoxelSystem.Runtime.VertexRotation));\n\tv352 = v401;\n\tv652 = v401 & 1;\n\tv404 = v652 == 0;\n\tif (v404) goto L_0054;\n\tv657 = Unco.OptionalValueSystem.Optional`1<System.Object>::get_Value(&v352 @ stack_-D8_v6 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>));\n\tgoto L_00C1;\nL_00C1:\n\tv669 = UnityEngine.Object::Instantiate(v657, v409.Parent);\n\tv552 = this._meshConfig;\n\tv545 = this._meshConfig == 0;\n\tif (v545) goto L_019D;\n\tv546 = v669 == 0;\n\tif (v546) goto L_019F;\n\tv674 = UnityEngine.Component::get_transform(v669);\n\tv676 = v458 + -0.5f;\n\tv679 = v86._current + -0.5f;\n\tv680 = v679 * v552.VoxelSize;\n\tv681 = v552.VoxelSize * v392.y;\n\tv682 = v676 * v552.VoxelSize;\n\tv683 = this._gridOffset + v680;\n\tv684 = this._gridOffset.y + v681;\n\tv685 = this._gridOffset.z + v682;\n\t// 220 MakeStruct v336 @ AGG6BAC170_0_v5 (Unity.Mathematics.float3), typeof(Unity.Mathematics.float3), v683 @ V0_v9 (System.Single), v684 @ V1_v8 (System.Single), v685 @ V2_v8 (System.Single)\n\tv687 = Unity.Mathematics.float3::op_Implicit(v336);\n\tgoto L_00F9;\n\tUnityEngine.Transform::SetLocalPositionAndRotation(v674, v687, v520);\n\tv725 = v354 > 1;\n\tif (v725) goto L_0138;\n\tv726 = v354 == 0;\n\tif (v726) goto L_0154;\n\tv745 = v354 != 1;\nL_FFFFFFFF:\n\tv528 = 0;\n\tif (v745) goto L_0164;\n\tv770 = v669 == 0;\n\tv771 = ~v770;\nL_FFFFFFFF:\n\tv783 = v371;\nL_FFFFFFFF:\n\tv784 = v364;\nL_FFFFFFFF:\n\tv785 = v368;\nL_FFFFFFFF:\n\tv528 = v366;\n\tif (v771) goto L_015E;\nL_FFFFFFFF:\n\tv521 = v366;\n\tgoto L_01A3;\nL_0138:\n\tv731 = v354 == 2;\n\tif (v731) goto L_FFFFFFFF;\n\tv760 = v354 != 3;\nL_FFFFFFFF:\n\tv528 = 0;\n\tif (v760) goto L_0164;\n\tv798 = v669 == 0;\n\tv797 = ~v798;\nL_FFFFFFFF:\n\tv783 = v364;\nL_FFFFFFFF:\n\tv784 = v371;\nL_FFFFFFFF:\n\tv785 = v366;\nL_FFFFFFFF:\n\tv528 = v368;\n\tif (v797) goto L_015E;\nL_FFFFFFFF:\n\tv521 = v368;\n\tgoto L_01A3;\nL_0154:\n\tv749 = v669 == 0;\n\tv750 = ~v749;\nL_FFFFFFFF:\n\tv783 = v368;\nL_FFFFFFFF:\n\tv784 = v366;\nL_FFFFFFFF:\n\tv785 = v364;\nL_FFFFFFFF:\n\tv528 = v371;\n\tif (v750) goto L_015E;\nL_FFFFFFFF:\n\tv521 = v371;\n\tgoto L_01A3;\nL_FFFFFFFF:\n\tv783 = v366;\nL_FFFFFFFF:\n\tv784 = v368;\nL_FFFFFFFF:\n\tv785 = v371;\nL_FFFFFFFF:\n\tv528 = v364;\nL_015E:\n\tv792 = *([v669 @ X0_v48 (UnityEngine.Component)]);\n\t*([v792 @ X8_v51 (Il2CppClass<UnityEngine.Component>)+178])(v789, v669, v528, v784, v785, v783, *([v792 @ X8_v51 (Il2CppClass<UnityEngine.Component>)+180]), Il2CppMethodInfo, v55, v687, v687.y, v687.z, v520, v520.y, v520.z, v520.w, v520.z);\n\tSystem.Collections.Generic.Dictionary`2<Unity.Mathematics.int3, ConnectedVoxelSystem.Runtime.VertexView`1<T>>::set_Item(this._vertexViews, v86._current, v669);\nL_FFFFFFFF:\n\tv409 = this;\n\tgoto L_0054;\nL_0172:\n\tSystem.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>::Dispose(&v235 @ stack_-C0_v4 (System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>));\nL_FFFFFFFF:\n\tv263 = &v235 @ stack_-C0_v4 (System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>);\nL_FFFFFFFF:\n\tv85 = 0;\nL_FFFFFFFF:\n\tv274 = Il2CppMethodInfo;\nL_0175:\n\tv282 = this._dirtyVertices == 0;\n\tif (v282) goto L_01A5;\n\tSystem.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Clear(this._dirtyVertices);\n\treturn;\nL_018F:\n\tv530 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v499;\n\tgoto L_01A4;\nL_0191:\n\tv531 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v86._current;\n\tgoto L_01A4;\nL_0193:\n\tv532 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v499;\n\tgoto L_01A4;\nL_0195:\n\tv466 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = Il2CppMethodInfo;\n\tgoto L_01A4;\nL_0197:\n\tv533 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v86._current;\n\tgoto L_01A4;\nL_0199:\n\tv534 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v86._current;\n\tgoto L_01A4;\nL_019B:\n\tv535 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = 0;\n\tgoto L_01A4;\nL_019D:\n\tv536 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v409.Parent;\n\tgoto L_01A4;\nL_019F:\n\tv537 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v409.Parent;\n\tgoto L_01A4;\nL_01A1:\n\tv538 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v528;\n\tgoto L_01A4;\nL_01A3:\n\tv529 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv274 = v521;\nL_01A4:\n\t// 420 Interrupt\nL_FFFFFFFF:\n\tv263 = &v235 @ stack_-C0_v4 (System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>);\nL_FFFFFFFF:\n\tv85 = 0;\nL_01CB:\n\tv425 = v274 != 1;\n\tif (v425) goto L_01DC;\n\tv431 = 0x8BF5BC4(v289, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv455 = 0x8BF5BF4(v431, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>::Dispose(v263);\n\tv439 = *([v431 @ X0_v11]) == 0;\nL_FFFFFFFF:\n\tv85 = *([v431 @ X0_v11]);\nL_FFFFFFFF:\n\tv274 = Il2CppMethodInfo;\n\tif (v439) goto L_0175;\n\tv437 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv85 = *([v431 @ X0_v11]);\nL_FFFFFFFF:\n\tv289 = v437;\nL_01DC:\n\tv446 = 0x34BB0F8(&v85 @ stack_-100 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv457 = 0x8BF0368(v289, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv472 = 0xA1B8(v457, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0039:\n\tv77 = this._dirtyVertices == 0;\n\tif (v77) goto L_01A5;\nL_0054:\n\tv415 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>::MoveNext(&v235 @ stack_-C0_v4 (System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>+Enumerator<Unity.Mathematics.int3>));\n\tv430 = v415 == 0;\n\tif (v430) goto L_0172;\nL_00F9:\n\t// 249 MakeStruct v302 @ AGG6BAC1C8_1_v5 (UnityEngine\n// ... truncated")]
		public unsafe void RebuildDirtyVertices()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VertexGrid::RebuildDirtyVertices");
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x6BAC43C", Offset = "0x6BAC43C", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._autoRebuild = 0;\n\tv300 = this._voxelGrid;\nL_FFFFFFFF:\n\tv169 = 0;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv169 = v90;\nL_001E:\n\tv218 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::get_Size(v300);\n\tv99 = v169 >= v218;\n\tif (v99) goto L_00AC;\n\tv282 = this._voxelGrid;\n\tv90 = v169 + 1;\nL_FFFFFFFF:\n\tv93 = 0;\n\tgoto L_0037;\nL_0030:\n\tv93 = v93 + 1;\n\tv282 = this._voxelGrid;\nL_0037:\n\tv285 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::get_Size(v282);\n\tv300 = this._voxelGrid;\n\tv98 = v93 >= v285;\n\tif (v98) goto L_FFFFFFFF;\n\tv83 = v93 << 0x20;\nL_FFFFFFFF:\n\tv87 = 0;\n\tgoto L_0052;\nL_004A:\n\tv78 = v87 + 1;\nL_0052:\n\tv302 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::get_Size(v300);\n\tv100 = v87 >= Il2CppMethodInfo;\n\tif (v100) goto L_0030;\n\tv306 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(this._voxelGrid, v169, v93, v87);\n\tv307 = v306 & 1;\n\tv308 = v307 == 0;\n\tif (v308) goto L_004A;\n\tgoto L_007D;\nL_007D:\n\tv155 = v83 | v169;\n\tv341 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, v155);\n\tv78 = v87 + 1;\n\tv156 = v83 | v169;\n\tv342 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, v156);\n\tv157 = v83 | v90;\n\tv343 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, v157);\n\tv333 = v83 | v90;\n\tv339 = System.Collections.Generic.HashSet`1<Unity.Mathematics.int3>::Add(this._dirtyVertices, v333);\n\tv324 = this._autoRebuild != 1;\n\tif (v324) goto L_004B;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::RebuildDirtyVertices(this);\n\tgoto L_004B;\nL_00AC:\n\tthis._autoRebuild = 1;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::RebuildDirtyVertices(this);\n\treturn;\nL_004B:\n\tv300 = this._voxelGrid;\nL_FFFFFFFF:\n\tv87 = v78;\n")]
		public void RebuildAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VertexGrid::RebuildAll");
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x6BAC634", Offset = "0x6BAC634", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = rotation > 1;\n\tif (v20) goto L_002B;\n\tv21 = rotation == 0;\n\tif (v21) goto L_0054;\n\tv40 = rotation != 1;\n\tif (v40) goto L_0050;\n\tv104 = vertexView == 0;\n\tv105 = ~v104;\n\tv133 = frontRight;\n\tv134 = v60;\n\tv135 = rearLeft;\n\tv136 = frontLeft;\n\tv147 = vertexView;\n\tif (v105) goto L_0042;\n\tv60 = frontRight;\n\tgoto L_0057;\nL_002B:\n\tv26 = rotation == 2;\n\tv147 = vertexView;\n\tif (v26) goto L_005C;\n\tv58 = rotation != 3;\n\tif (v58) goto L_0050;\n\tv133 = rearLeft;\n\tv134 = frontLeft;\n\tv135 = frontRight;\n\tv136 = v60;\n\tv147 = vertexView;\nL_0042:\n\tv148 = *([v147 @ X0_v5 (ConnectedVoxelSystem.Runtime.VertexView`1<T>)]);\n\tv149 = *([v148 @ X11_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.VertexView`1<T>>)+178]);\n\tv150 = *([v148 @ X11_v1 (Il2CppClass<ConnectedVoxelSystem.Runtime.VertexView`1<T>>)+180]);\n\tv151 = v136 & 0xFFFF;\n\tv152 = v135 & 0xFFFF;\n\tv153 = v134 & 0xFFFF;\n\tv154 = v133 & 0xFFFF;\n\t// 76 IndirectJump v149 @ X7_v1, v147 @ X0_v5 (ConnectedVoxelSystem.Runtime.VertexView`1<T>), v147 @ X0_v5 (ConnectedVoxelSystem.Runtime.VertexView`1<T>), v151 @ X1_v1 (System.Int32), v152 @ X2_v1 (System.Int32), v153 @ X3_v1 (System.Int32), v154 @ X4_v1 (System.Int32), v150 @ X5_v1, v133 @ X6_v4 (ConnectedVoxelSystem.Runtime.Voxel`1<T>), v149 @ X7_v1, v125 @ V0, v126 @ V1, v127 @ V2, v128 @ V3, v129 @ V4, v130 @ V5, v131 @ V6, v132 @ V7\nL_0050:\n\treturn;\nL_0054:\n\tv47 = vertexView == 0;\n\tv48 = ~v47;\n\tv133 = v60;\n\tv134 = rearLeft;\n\tv135 = frontLeft;\n\tv136 = frontRight;\n\tv147 = vertexView;\n\tif (v48) goto L_0042;\nL_0057:\n\tv93 = new System.NullReferenceException();\n\tv147 = v93;\nL_005C:\n\tv98 = v147 == 0;\n\tv99 = ~v98;\n\tv133 = frontLeft;\n\tv134 = frontRight;\n\tv135 = v60;\n\tv136 = rearLeft;\n\tif (v99) goto L_0042;\n\tv60 = rearLeft;\n\tgoto L_0057;\n")]
		private void InitializeVertexViewWithRotation(VertexView<T> vertexView, VertexRotation rotation, Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VertexGrid::InitializeVertexViewWithRotation");
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x6BAC6E4", Offset = "0x6BAC6E4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv52 = UnityEngine.Object::op_Equality(component, 0);\n\tv60 = v52 == 0;\n\tif (v60) goto L_003A;\n\treturn;\nL_003A:\n\tv99 = UnityEngine.Component::get_gameObject(component);\n\tgoto L_0047;\nL_0047:\n\tUnityEngine.Object::Destroy(v99);\n\treturn;\n")]
		private static void DestroyObject(Component component)
		{
			if (!(component == null))
			{
				GameObject gameObject = component.gameObject;
				UnityEngine.Object.Destroy(gameObject);
			}
		}
	}
}
