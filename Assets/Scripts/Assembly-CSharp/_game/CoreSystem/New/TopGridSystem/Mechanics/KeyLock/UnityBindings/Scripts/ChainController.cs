using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts
{
	[ExecuteAlways]
	[Token(Token = "0x20001DD")]
	public class ChainController : MonoBehaviour
	{
		[Token(Token = "0x20001DE")]
		private enum ShakePhase
		{
			[Token(Token = "0x40005EB")]
			None = 0,
			[Token(Token = "0x40005EC")]
			Forcing = 1,
			[Token(Token = "0x40005ED")]
			Settling = 2
		}

		[Token(Token = "0x20001DF")]
		private struct ChainAttachment
		{
			[Token(Token = "0x40005EE")]
			[FieldOffset(Offset = "0x0")]
			public Transform target;

			[Token(Token = "0x40005EF")]
			[FieldOffset(Offset = "0x8")]
			public int nodeIdxA;

			[Token(Token = "0x40005F0")]
			[FieldOffset(Offset = "0xC")]
			public int nodeIdxB;

			[Token(Token = "0x40005F1")]
			[FieldOffset(Offset = "0x10")]
			public float t;
		}

		[Header("Link Mesh")]
		[SerializeField]
		[Token(Token = "0x40005BC")]
		[FieldOffset(Offset = "0x20")]
		private Mesh _linkMesh;

		[SerializeField]
		[Token(Token = "0x40005BD")]
		[FieldOffset(Offset = "0x28")]
		private Vector3 _linkScale;

		[Token(Token = "0x40005BE")]
		[FieldOffset(Offset = "0x38")]
		private Material _linkMaterial;

		[Header("Verlet Parameters")]
		[SerializeField]
		[Range(0.8f, 1f)]
		[Token(Token = "0x40005BF")]
		[FieldOffset(Offset = "0x40")]
		private float _damping;

		[SerializeField]
		[Range(1f, 10f)]
		[Token(Token = "0x40005C0")]
		[FieldOffset(Offset = "0x44")]
		private int _constraintIterations;

		[SerializeField]
		[Token(Token = "0x40005C1")]
		[FieldOffset(Offset = "0x48")]
		private Vector3 _gravity;

		[SerializeField]
		[Token(Token = "0x40005C2")]
		[FieldOffset(Offset = "0x54")]
		private float _linkLength;

		[SerializeField]
		[Min(3f)]
		[Token(Token = "0x40005C3")]
		[FieldOffset(Offset = "0x58")]
		private int _minNodes;

		[Header("Sleep")]
		[SerializeField]
		[Token(Token = "0x40005C4")]
		[FieldOffset(Offset = "0x5C")]
		private float _sleepThreshold;

		[SerializeField]
		[Token(Token = "0x40005C5")]
		[FieldOffset(Offset = "0x60")]
		private int _sleepFrames;

		[Header("Shake")]
		[SerializeField]
		[Token(Token = "0x40005C6")]
		[FieldOffset(Offset = "0x64")]
		private float _shakeForce;

		[SerializeField]
		[Token(Token = "0x40005C7")]
		[FieldOffset(Offset = "0x68")]
		private float _shakeForceDuration;

		[SerializeField]
		[Min(0f)]
		[Token(Token = "0x40005C8")]
		[FieldOffset(Offset = "0x6C")]
		private float _shakeMaxDisplacement;

		[SerializeField]
		[Token(Token = "0x40005C9")]
		[FieldOffset(Offset = "0x70")]
		private float _shakeNoiseTimeFreq;

		[SerializeField]
		[Token(Token = "0x40005CA")]
		[FieldOffset(Offset = "0x74")]
		private float _shakeNoiseSpatialFreq;

		[SerializeField]
		[Min(0f)]
		[Token(Token = "0x40005CB")]
		[FieldOffset(Offset = "0x78")]
		private float _shakeSettleDuration;

		[SerializeField]
		[Min(0f)]
		[Token(Token = "0x40005CC")]
		[FieldOffset(Offset = "0x7C")]
		private float _shakeWaypointReturnRate;

		[Header("Debug Attach")]
		[SerializeField]
		[Token(Token = "0x40005CD")]
		[FieldOffset(Offset = "0x80")]
		private Transform _debugAttachTarget;

		[SerializeField]
		[Token(Token = "0x40005CE")]
		[FieldOffset(Offset = "0x88")]
		private Vector3 _debugAttachLocalPos;

		[Token(Token = "0x40005CF")]
		[FieldOffset(Offset = "0x94")]
		private ShakePhase _shakePhase;

		[Token(Token = "0x40005D0")]
		[FieldOffset(Offset = "0x98")]
		private float _shakeTimer;

		[Token(Token = "0x40005D1")]
		[FieldOffset(Offset = "0xA0")]
		private readonly List<int> _shakeUnpinnedWaypoints;

		[Token(Token = "0x40005D2")]
		[FieldOffset(Offset = "0xA8")]
		private float _shakeNoiseSeed;

		[Header("Plane Constraint")]
		[SerializeField]
		[Token(Token = "0x40005D3")]
		[FieldOffset(Offset = "0xAC")]
		private bool _constrainToPlane;

		[Token(Token = "0x40005D4")]
		[FieldOffset(Offset = "0xB0")]
		private Vector3[] _waypoints;

		[Token(Token = "0x40005D5")]
		[FieldOffset(Offset = "0xB8")]
		private int[] _waypointNodeIndices;

		[Token(Token = "0x40005D6")]
		[FieldOffset(Offset = "0xC0")]
		private HashSet<int> _pinnedNodes;

		[Token(Token = "0x40005D7")]
		[FieldOffset(Offset = "0xC8")]
		private Vector3 _planeUpHint;

		[Token(Token = "0x40005D8")]
		[FieldOffset(Offset = "0xD4")]
		private Vector3 _planeNormal;

		[Token(Token = "0x40005D9")]
		[FieldOffset(Offset = "0xE0")]
		private Vector3 _planePoint;

		[Token(Token = "0x40005DA")]
		[FieldOffset(Offset = "0xF0")]
		private Vector3[] _shakeDirections;

		[Token(Token = "0x40005DB")]
		[FieldOffset(Offset = "0xF8")]
		private int _nodeCount;

		[Token(Token = "0x40005DC")]
		[FieldOffset(Offset = "0xFC")]
		private int _linkCount;

		[Token(Token = "0x40005DD")]
		[FieldOffset(Offset = "0x100")]
		private Vector3[] _positions;

		[Token(Token = "0x40005DE")]
		[FieldOffset(Offset = "0x108")]
		private Vector3[] _previousPositions;

		[Token(Token = "0x40005DF")]
		[FieldOffset(Offset = "0x110")]
		private Vector3[] _accelerations;

		[Token(Token = "0x40005E0")]
		[FieldOffset(Offset = "0x118")]
		private Vector3[] _restPositions;

		[Token(Token = "0x40005E1")]
		[FieldOffset(Offset = "0x120")]
		private float[] _restLengths;

		[Token(Token = "0x40005E2")]
		[FieldOffset(Offset = "0x128")]
		private Matrix4x4[] _matrices;

		[Token(Token = "0x40005E3")]
		[FieldOffset(Offset = "0x130")]
		private readonly List<ChainAttachment> _attachments;

		[Token(Token = "0x40005E4")]
		[FieldOffset(Offset = "0x138")]
		private int _sleepCounter;

		[Token(Token = "0x40005E5")]
		[FieldOffset(Offset = "0x13C")]
		private bool _sleeping;

		[Token(Token = "0x40005E6")]
		[FieldOffset(Offset = "0x13D")]
		private bool _initialized;

		[Token(Token = "0x40005E7")]
		private const float FixedDt = 0.02f;

		[Token(Token = "0x40005E8")]
		private const int MaxStepsPerFrame = 2;

		[Token(Token = "0x40005E9")]
		[FieldOffset(Offset = "0x140")]
		private float _accumulator;

		[Token(Token = "0x600087D")]
		[Address(RVA = "0x3E7F2E8", Offset = "0x3E7F2E8", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv69 = localWaypoints.Length <= 1;\n\tif (v69) goto L_00DE;\n\tv101 = UnityEngine.Component::get_transform(this);\n\tv121 = UnityEngine.Transform::get_localToWorldMatrix(v101);\n\tv159 = v121;\n\t// 84 NewArr v390 @ X0_v14 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), localWaypoints.Length\n\tthis._waypoints = v390;\n\tv416 = localWaypoints.Length < 1;\n\tif (v416) goto L_0098;\n\tv140 = localWaypoints + 0x28;\n\tv143 = 0;\n\tv146 = 0;\n\tv453 = this._waypoints + v146;\n\t*([v453 @ X8_v18+20]) = v165;\n\t*([v453 @ X8_v18+24]) = v165.y;\n\t*([v453 @ X8_v18+28]) = v165.z;\n\tv143 = v143 + 1;\n\tv140 = v140 + 0xC;\n\tv146 = v146 + 0xC;\n\tv424 = v143 < localWaypoints.Length;\n\tif (v424) goto L_006C;\nL_0098:\n\tthis._linkMaterial = linkMaterial;\n\tv248 = UnityEngine.Component::get_transform(this);\n\tv167 = UnityEngine.Transform::get_forward(v248);\n\tthis._planeNormal.y = v167.y;\n\tthis._planeNormal.z = v167.z;\n\tv134 = -v167;\n\tv132 = -v167.y;\n\tv130 = -v167.z;\n\tthis._planeUpHint.x = v134;\n\tthis._planeUpHint.y = v132;\n\tthis._planeUpHint.z = v130;\n\tthis._planeNormal.x = v167;\n\tv256 = this._waypoints;\n\tthis._planePoint = *([v256 @ X8_v15 (UnityEngine.Vector3[])+20]);\n\tthis._planePoint.z = *([v256 @ X8_v15 (UnityEngine.Vector3[])+28]);\n\tv458 = v167 * this._gravity;\n\tv459 = v167.y * this._gravity.y;\n\tv460 = v458 + v459;\n\tv269 = v167.z * this._gravity.z;\n\tv271 = v269 + v460;\n\tv461 = v167 * v271;\n\tv462 = v167.y * v271;\n\tv463 = v167.z * v271;\n\tv309 = this._gravity - v461;\n\tv306 = this._gravity.y - v462;\n\tv286 = this._gravity.z - v463;\n\tthis._gravity.x = v309;\n\tthis._gravity.y = v306;\n\tthis._gravity.z = v286;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::BuildMultiSegmentChain(this);\n\treturn;\nL_00DE:\n\tgoto L_00EE;\nL_00EE:\n\tUnityEngine.Debug::LogError(\"[ChainController] Need at least 2 waypoints.\", this);\n\treturn;\nL_0020:\n\tv53 = localWaypoints == 0;\n\tif (v53) goto L_00DE;\nL_006C:\n\t;\n\t// 113 MakeStruct v124 @ AGG3E7F3D8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v140 @ X25_v7-8], [v140 @ X25_v7-4], [v140 @ X25_v7]\n\tv165 = UnityEngine.Matrix4x4::MultiplyPoint3x4(&v159 @ stack_-90_v3 (UnityEngine.Matrix4x4), v124);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Vector3[] localWaypoints, Material linkMaterial)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::Initialize");
		}

		[Token(Token = "0x600087E")]
		[Address(RVA = "0x3E7F520", Offset = "0x3E7F520", Length = "0xCD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv80 = v71.Length - 1;\n\t// 60 NewArr v81 @ X0_v12 (System.Int32[]), typeof(System.Int32[]), v80 @ X1_v6\nL_FFFFFFFF:\n\tv603 = 1;\nL_FFFFFFFF:\n\tv645 = 0x20;\nL_FFFFFFFF:\n\tv673 = 0;\nL_FFFFFFFF:\n\tv1062 = this._waypoints;\n\tv353 = v673 + 1;\n\tv1285 = v1062 + v645;\n\tgoto L_007E;\nL_007E:\n\tgoto L_007F;\nL_007F:\n\tv798 = this._minNodes;\n\tv298 = this._linkLength;\n\tv1313 = *([B193A8D]) & 1;\n\tv1314 = v1313 == 0;\n\tif (v1314) goto L_00E9;\n\tgoto L_008B;\nL_008B:\n\tv1363 = *([v1285 @ X8_v141+8]) - *([v1285 @ X8_v141+14]);\n\tv1364 = *([v1285 @ X8_v141+4]) - *([v1285 @ X8_v141+10]);\n\tv1365 = *([v1285 @ X8_v141]) - *([v1285 @ X8_v141+C]);\n\tv247 = v1365 * v1365;\n\tv1366 = v1364 * v1364;\n\tv1367 = v247 + v1366;\n\tv1368 = v1363 * v1363;\n\tv1369 = v1368 + v1367;\n\tv1370 = UnityEngine.Mathf::Sqrt(v1369);\n\tv1380 = v1370 / v298;\n\tv280 = UnityEngine.Mathf::Ceil(v1380);\n\tv1386 = v280 == 0x7F800000;\n\tv1393 = ~v1386;\n\tif (v1393) goto L_00A4;\nL_FFFFFFFF:\n\tv787 = 0xFFFFFFFF80000001;\n\tgoto L_00A8;\nL_00A4:\n\tv787 = v1380 + 1;\nL_FFFFFFFF:\n\tv787 = v798;\n\tgoto L_00BC;\nL_00BC:\n\tv693 = v353 - 1;\n\tv81[v673 @ X27_v7 (System.Int32)] = v787;\n\tv1420 = v603 + v787;\n\tv603 = v1420 - 1;\n\tv645 = v645 + 0xC;\n\tv673 = v693 + 1;\n\tv1421 = this._waypoints == 0;\n\tv739 = ~v1421;\nL_FFFFFFFF:\n\tv1062 = this._waypoints;\n\tif (v739) goto L_004A;\nL_FFFFFFFF:\n\tv766 = this._waypoints;\n\tgoto L_05F4;\nL_00E9:\n\t*([B193A8D]) = 1;\nL_FFFFFFFF:\n\tv298 = v298;\nL_FFFFFFFF:\n\tv798 = v798;\n\tgoto L_008B;\nL_00F3:\n\tv1218 = v603 - 1;\n\tthis._nodeCount = v603;\n\tthis._linkCount = v1218;\n\t// 250 NewArr v1222 @ X0_v15 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v603 @ X21_v7 (System.Single)\n\tthis._positions = v1222;\n\t// 257 NewArr v1292 @ X0_v19 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), this._nodeCount (System.Int32)\n\tthis._previousPositions = v1292;\n\t// 264 NewArr v1325 @ X0_v23 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), this._nodeCount (System.Int32)\n\tthis._accelerations = v1325;\n\t// 273 NewArr v1379 @ X0_v27 (System.Single[]), typeof(System.Single[]), this._linkCount (System.Int32)\n\tthis._restLengths = v1379;\n\t// 282 NewArr v1398 @ X0_v31 (UnityEngine.Matrix4x4[]), typeof(UnityEngine.Matrix4x4[]), this._linkCount (System.Int32)\n\tthis._matrices = v1398;\n\tv770 = this._waypoints;\n\t// 294 NewArr v1410 @ X0_v35 (System.Int32[]), typeof(System.Int32[]), v770.Length\n\tv352 = this + 0xB8;\n\tthis._waypointNodeIndices = v1410;\n\tv1419 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v1419);\n\tv797 = this + 0xC0;\n\tthis._pinnedNodes = v1419;\n\tv1443 = this._waypoints;\n\tv1427 = v81 == 0;\n\tif (v1427) goto L_02D5;\nL_FFFFFFFF:\n\tv355 = v352;\nL_FFFFFFFF:\n\tv1550 = 0;\nL_FFFFFFFF:\n\tv801 = 0;\n\tgoto L_0151;\nL_014A:\n\tv658 = v801 + 1;\nL_0151:\n\t;\n\tv778 = v1443.Length - 1;\n\tv203 = v801 >= v778;\n\tif (v203) goto L_02F0;\n\tv189 = v801 << 2;\n\tv1453 = *([v355 @ X22_v13]) + v189;\n\t*([v1453 @ X8_v104 (System.Single)+20]) = v1550;\n\tv723 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v797.m_value, v1550);\n\tv162 = 0xB296000 + 0x490;\n\tv213 = v81[v801 @ X20_v19 (System.Int32)] <= 0;\n\tif (v213) goto L_014A;\n\tv788 = v81[v801 @ X20_v19 (System.Int32)] - 1;\n\tv658 = v801 + 1;\n\tv1479 = v801 == 0;\n\tif (v1479) goto L_01A6;\n\tv1520 = v81[v801 @ X20_v19 (System.Int32)] == 1;\n\tif (v1520) goto L_014B;\nL_FFFFFFFF:\n\tv1592 = v1550;\n\tgoto L_FFFFFFFF;\nL_01A6:\n\tv291 = 0 / v788;\n\tv242 = v81[v801 @ X20_v19 (System.Int32)] != 1;\n\tif (v242) goto L_01CA;\nL_FFFFFFFF:\n\tv291 = 0;\n\tgoto L_01CA;\nL_01CA:\n\tv789 = this._positions;\n\tv515 = v291 < 1f;\n\tv488 = v291 == 1f;\n\tv1662 = v291 == v291;\n\tv461 = 1f == 1f;\n\tv542 = v1662 & v461;\n\tv382 = ~v542;\n\tv1663 = v515 == v382;\n\tv141 = ~v488;\n\tv204 = v1663 & v141;\n\tv234 = ~v204;\n\tif (v234) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv273 = 1f;\n\tgoto L_01EA;\nL_FFFFFFFF:\n\tv273 = v291;\nL_01EA:\n\tv1762 = this._waypoints + 0x20;\n\tv1763 = v801 * 0xC;\n\tv582 = v1762 + v1763;\n\tv1764 = v658 * 0xC;\n\tv699 = v1762 + v1764;\n\tv1768 = *([v699 @ X9_v52]) - *([v582 @ X10_v40]);\n\tv116 = v1768 * v1769;\n\tv283 = *([v582 @ X10_v40]) + v116;\n\tv127 = *([v699 @ X9_v52+8]) - *([v582 @ X10_v40+8]);\n\tv1770 = v273 * v127;\n\tv265 = *([v582 @ X10_v40+8]) + v1770;\n\tv1771 = v1550 * 0xC;\n\tv1772 = this._positions + v1771;\n\t*([v1772 @ X8_v131+20]) = v283;\n\tv789[v1550 @ X21_v14 (System.Int32)].z = v265;\n\tv775 = this._previousPositions;\n\tv1813 = v1550 * 0xC;\n\tv1814 = this._previousPositions + v1813;\n\t*([v1814 @ X8_v133+20]) = v283;\n\tv775[v1550 @ X21_v14 (System.Int32)].z = v265;\n\tv360 = this._accelerations;\n\tgoto L_022B;\nL_022B:\n\tv1872 = *([v162 @ X12_v53 (System.Int32)]);\n\tv1873 = *([v1872 @ X8_v137+B8]);\n\tv1555 = v1550 * 0xC;\n\tv1558 = this._accelerations + v1555;\n\t*([v1558 @ X8_v139 (System.Single)+20]) = *([v1873 @ X8_v138]);\n\tv360[v1550 @ X21_v14 (System.Int32)].z = *([v1873 @ X8_v138+8]);\n\tv1542 = v81[v801 @ X20_v19 (System.Int32)] == 1;\nL_FFFFFFFF:\n\tv1592 = v1550;\nL_FFFFFFFF:\n\tv355 = v352;\n\tif (v1542) goto L_014B;\nL_FFFFFFFF:\n\tv650 = 1;\nL_025B:\n\tv292 = v650 / v788;\n\tv791 = this._positions;\n\tv517 = v292 < 1f;\n\tv490 = v292 == 1f;\n\tv1681 = v292 == v292;\n\tv463 = 1f == 1f;\n\tv544 = v1681 & v463;\n\tv384 = ~v544;\n\tv1682 = v517 == v384;\n\tv143 = ~v490;\n\tv206 = v1682 & v143;\n\tv236 = ~v206;\n\tif (v236) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv274 = 1f;\n\tgoto L_0270;\nL_FFFFFFFF:\n\tv274 = v292;\nL_0270:\n\tv617 = v1592 + v650;\n\tv1787 = this._waypoints + 0x20;\n\tv1788 = v801 * 0xC;\n\tv584 = v1787 + v1788;\n\tv1789 = v658 * 0xC;\n\tv701 = v1787 + v1789;\n\tv1793 = *([v701 @ X9_v48]) - *([v584 @ X10_v38]);\n\tv118 = v1793 * v1769;\n\tv285 = *([v584 @ X10_v38]) + v118;\n\tv129 = *([v701 @ X9_v48+8]) - *([v584 @ X10_v38+8]);\n\tv1794 = v274 * v129;\n\tv267 = *([v584 @ X10_v38+8]) + v1794;\n\tv1795 = v617 * 0xC;\n\tv1796 = this._positions + v1795;\n\t*([v1796 @ X8_v119+20]) = v285;\n\tv791[v617 @ X26_v12 (System.Int32)].z = v267;\n\tv777 = this._previousPositions;\n\tv1834 = v617 * 0xC;\n\tv1835 = this._previousPositions + v1834;\n\t*([v1835 @ X8_v121+20]) = v285;\n\tv777[v617 @ X26_v12 (System.Int32)].z = v267;\n\tv631 = this._accelerations;\n\tgoto L_02BD;\nL_02BD:\n\tv1904 = *([v162 @ X12_v53 (System.Int32)]);\n\tv1905 = *([v1904 @ X8_v125+B8]);\n\tv1556 = v617 * 0xC;\n\tv1559 = this._accelerations + v1556;\n\t*([v1559 @ X8_v127 (System.Single)+20]) = *([v1905 @ X8_v126]);\n\tv631[v617 @ X26_v12 (System.Int32)].z = *([v1905 @ X8_v126+8]);\n\tv650 = v650 + 1;\n\tv1527 = v81[v801 @ X20_v19 (System.Int32)] != v650;\n\tif (v1527) goto L_025B;\nL_FFFFFFFF:\n\tv355 = v352;\nL_FFFFFFFF:\n\tv1550 = v1592;\n\tgoto L_014B;\nL_02D5:\n\tv778 = v1443.Length - 1;\n\tv198 = v778 >= 1;\nL_FFFFFFFF:\n\tv355 = v352;\n\tif (v198) goto L_05F1;\nL_02F0:\n\tv586 = this._nodeCount - 1;\n\tv192 = v778 << 2;\n\tv779 = *([v355 @ X22_v13]) + v192;\n\t*([v779 @ X8_v27 (System.Single)+20]) = v586;\n\tv687 = this._nodeCount - 1;\n\tv727 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this._pinnedNodes, v687);\n\tv1068 = this._waypoints;\n\tv753 = v81 == 0;\n\tif (v753) goto L_0416;\nL_FFFFFFFF:\n\tv627 = 0;\nL_FFFFFFFF:\n\tv1049 = 0;\n\tgoto L_030D;\nL_0309:\n\tv1068 = this._waypoints;\nL_FFFFFFFF:\n\tv1049 = v677;\nL_030D:\n\t;\n\tv1492 = v1068.Length - 1;\n\tv847 = v1049 >= v1492;\n\tif (v847) goto L_0425;\n\tv677 = v1049 + 1;\n\tv1605 = v1068 + 0x20;\n\tv1606 = v1049 * 0xC;\n\tv1607 = v1605 + v1606;\n\tv1608 = v677 * 0xC;\n\tv1609 = v1605 + v1608;\n\tgoto L_035A;\nL_035C:\n\tv1665 = *([v1607 @ X9_v26+8]) - *([v1609 @ X8_v85+8]);\n\tv1666 = *([v1607 @ X9_v26+4]) - *([v1609 @ X8_v85+4]);\n\tv1667 = *([v1607 @ X9_v26]) - *([v1609 @ X8_v85]);\n\tv254 = v1667 * v1667;\n\tv1668 = v1666 * v1666;\n\tv270 = v254 + v1668;\n\tv1670 = v1665 * v1665;\n\tv1671 = v1670 + v270;\n\tv288 = UnityEngine.Mathf::Sqrt(v1671);\n\tv782 = v81[v1049 @ X9_v25 (System.Int32)] - 1;\n\tv1696 = v81[v1049 @ X9_v25 (System.Int32)] <= 1;\n\tif (v1696) goto L_0380;\n\tv288 = v288 / v782;\nL_FFFFFFFF:\n\tv270 = v782;\n\tgoto L_0382;\nL_0380:\n\tv1724 = v782 < 1;\n\tif (v1724) goto L_0309;\nL_0382:\n\tv704 = this._restLengths;\n\tv1071 = this._restLengths + 0x20;\n\tv1775 = v704.Length < v627;\n\tv1776 = ~v1775;\n\tv1819 = v704.Length - v627;\n\tv1785 = ~v1776;\n\tv1786 = ~v1785;\n\tif (v1786) goto L_0399;\nL_FFFFFFFF:\n\tv1819 = 0;\n\tgoto L_0399;\n\tgoto L_03AA;\nL_FFFFFFFF:\n\tv1857 = v1\n// ... truncated")]
		private unsafe void BuildMultiSegmentChain()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::BuildMultiSegmentChain");
		}

		[Token(Token = "0x600087F")]
		[Address(RVA = "0x3E80468", Offset = "0x3E80468", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._sleeping = 0;\n\tthis._sleepCounter = 0;\n\treturn;\n")]
		public void Wake()
		{
			_sleeping = false;
			_sleepCounter = 0;
		}

		[Token(Token = "0x6000880")]
		[Address(RVA = "0x3E80474", Offset = "0x3E80474", Length = "0x4BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\nL_0047:\n\tv82 = UnityEngine.Object::op_Equality(target, 0);\n\tv86 = ~v82;\n\tif (v86) goto L_005E;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv161 = \"[ChainController] Attach: target is null.\";\n\tgoto L_0145;\nL_005E:\n\tv106 = this._initialized != 1;\n\tif (v106) goto L_012F;\n\tv113 = this._restPositions;\n\tv114 = this._restPositions == 0;\n\tif (v114) goto L_012F;\n\tv116 = v113.Length <= 1;\n\tif (v116) goto L_012F;\n\tv194 = UnityEngine.Component::get_transform(this);\n\tv327 = UnityEngine.Transform::TransformPoint(v194, localPosOnChain);\n\tv508 = this._restPositions;\n\tv621 = v508.Length < 1;\n\tv622 = ~v621;\n\tv623 = v508.Length - 1;\n\tv625 = v623 == 0;\n\tv630 = v508.Length - 1;\n\tv631 = ~v625;\n\tv632 = v622 & v631;\n\tv633 = ~v632;\n\tif (v633) goto L_009E;\n\tgoto L_009E;\n\tv320 = v508 + 0x34;\n\tv365 = ~v630;\n\tv312 = v630 & v365;\nL_FFFFFFFF:\n\tv702 = 0x7F800000;\nL_FFFFFFFF:\n\tv370 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_00D0;\nL_00B0:\n\tv370 = v370 + 1;\n\tv320 = v320 + 0xC;\n\tv717 = v312 == v370;\nL_FFFFFFFF:\n\t;\n\tif (v717) goto L_014A;\nL_00D0:\n\t;\n\tv787 = *([v320 @ X11_v8-8]) - *([v320 @ X11_v8-14]);\n\tv788 = *([v320 @ X11_v8-4]) - *([v320 @ X11_v8-10]);\n\tv789 = *([v320 @ X11_v8]) - *([v320 @ X11_v8-C]);\n\tv790 = v787 * v787;\n\tv791 = v788 * v788;\n\tv792 = v790 + v791;\n\tv793 = v789 * v789;\n\tv794 = v792 + v793;\n\tv796 = v794 < 0x322BCC77;\n\tif (v796) goto L_00B0;\n\tv815 = v327 - *([v320 @ X11_v8-14]);\n\tv816 = v327.y - *([v320 @ X11_v8-10]);\n\tv817 = v327.z - *([v320 @ X11_v8-C]);\n\tv818 = v815 * v787;\n\tv819 = v816 * v788;\n\tv820 = v818 + v819;\n\tv821 = v817 * v789;\n\tv822 = v821 + v820;\n\tv823 = v822 / v794;\n\tv824 = v823 < 1f;\n\tv825 = v823 == 1f;\n\tv828 = v823 == v823;\n\tv829 = 1f == 1f;\n\tv830 = v828 & v829;\n\tv831 = ~v830;\n\tv832 = v824 == v831;\n\tv833 = ~v825;\n\tv834 = v832 & v833;\n\tv835 = ~v834;\n\tif (v835) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv836 = 1f;\n\tgoto L_0102;\nL_FFFFFFFF:\n\tv836 = v823;\nL_FFFFFFFF:\n\tv840 = 0;\n\tgoto L_010E;\nL_FFFFFFFF:\n\tv840 = v836;\nL_FFFFFFFF:\n\tv702 = v843;\nL_FFFFFFFF:\n\t;\n\tgoto L_00B0;\nL_012F:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv161 = \"[ChainController] Attach: chain not initialized.\";\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv583 = 0;\n\tv864 = &v236 @ stack_-90 (UnityEngine.Object);\n\tv866 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::get_Item(v610, v583);\n\tv236 = *([v864 @ X8_v30]);\n\tgoto L_0170;\nL_0170:\n\tv881 = UnityEngine.Object::op_Equality(*([v864 @ X8_v30]), target);\n\tv884 = ~v881;\n\tv885 = ~v884;\n\tif (v885) goto L_01B9;\n\tv583 = v583 + 1;\n\tv610 = this._attachments;\n\tv896 = this._attachments == 0;\n\tv567 = ~v896;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v567) goto L_015A;\n\tthrow System.NullReferenceException;\nL_0187:\n\tv562 = this._attachments;\n\tgoto L_01DA;\nL_01B9:\n\tv236 = v408;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::set_Item(this._attachments, v583, &v236 @ stack_-90 (UnityEngine.Object));\n\tv777 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::get_Item(this._attachments, v583);\n\tv762 = v777.target;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv358 = &v762 @ stack_-B0_v5 (UnityEngine.Transform);\n\tgoto L_01E5;\nL_01DA:\n\tv236 = v407;\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::Add(v562, &v236 @ stack_-90 (UnityEngine.Object));\nL_FFFFFFFF:\n\t;\n\tv236 = v407;\nL_FFFFFFFF:\n\tv358 = &v236 @ stack_-90 (UnityEngine.Object);\nL_0040:\n\tgoto L_0047;\nL_0145:\n\tUnityEngine.Debug::LogError(v161, this);\n\treturn;\nL_009E:\n\tv651 = v630 < 1;\n\tif (v651) goto L_FFFFFFFF;\nL_014A:\n\tv610 = this._attachments;\nL_0102:\n\tv872 = v823 < 0;\n\tv847 = ~v872;\n\tif (v847) goto L_FFFFFFFF;\nL_010E:\n\tv837 = v787 * v840;\n\tv839 = v788 * v840;\n\tv838 = v789 * v840;\n\tv886 = *([v320 @ X11_v8-14]) + v837;\n\tv887 = *([v320 @ X11_v8-10]) + v839;\n\tv888 = *([v320 @ X11_v8-C]) + v838;\n\tv889 = v327 - v886;\n\tv890 = v327.y - v887;\n\tv841 = v327.z - v888;\n\tv891 = v889 * v889;\n\tv892 = v890 * v890;\n\tv893 = v891 + v892;\n\tv842 = v841 * v841;\n\tv843 = v842 + v893;\n\tv856 = v843 < v702;\n\tv848 = ~v856;\n\tif (v848) goto L_00B0;\nL_015A:\n\tv516 = v583 >= v610.Count;\n\tif (v516) goto L_0187;\nL_01E5:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::SyncAttachment(this, v358);\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Attach(Transform target, Vector3 localPosOnChain)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::Attach");
		}

		[Token(Token = "0x6000881")]
		[Address(RVA = "0x3E80A80", Offset = "0x3E80A80", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv149 = 0;\n\tv187 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::get_Item(v173, v149);\n\tgoto L_004A;\nL_004A:\n\tv179 = UnityEngine.Object::op_Equality(v187.target, target);\n\tv245 = ~v179;\n\tv181 = ~v245;\n\tif (v181) goto L_005B;\n\tv147 = v149 + 1;\n\tv173 = this._attachments;\n\tv246 = this._attachments == 0;\n\tv142 = ~v246;\n\tv149 = v147;\n\tif (v142) goto L_0034;\n\tthrow System.NullReferenceException;\nL_005B:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::RemoveAt(this._attachments, v149);\nL_005E:\n\tv218 = v149 - v173.Count;\n\tv219 = v218 < 0;\n\tv221 = v149 ^ v173.Count;\n\tv222 = v149 ^ v218;\n\tv223 = v221 & v222;\n\tv224 = v223 < 0;\n\tv225 = v219 == v224;\n\tv226 = ~v225;\n\treturn v226;\nL_0022:\n\tv173 = this._attachments;\nL_0034:\n\tv66 = v149 >= v173.Count;\n\tif (v66) goto L_005E;\n")]
		public bool Detach(Transform target)
		{
			List<ChainAttachment> attachments = _attachments;
			int num = 0;
			while (num < attachments.Count)
			{
				if (!(attachments[num].target == target))
				{
					int num2 = num + 1;
					attachments = _attachments;
					bool flag = _attachments == null;
					bool flag2 = !flag;
					num = num2;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				_attachments.RemoveAt(num);
				break;
			}
			int num3 = num - attachments.Count;
			bool flag3 = num3 < 0;
			int num4 = num ^ attachments.Count;
			int num5 = num ^ num3;
			int num6 = num4 & num5;
			bool flag4 = num6 < 0;
			bool flag5 = flag3 == flag4;
			return !flag5;
		}

		[Token(Token = "0x6000882")]
		[Address(RVA = "0x3E80B98", Offset = "0x3E80B98", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tgoto L_0025;\n\tv147 = v55.Count;\n\tv61 = v55.Count == 0;\n\tif (v61) goto L_008B;\n\tv157 = this._positions == 0;\n\tif (v157) goto L_008B;\n\tv206 = v55.Count < 1;\n\tif (v206) goto L_008B;\n\tv115 = &v103 @ stack_-88_v5 (UnityEngine.Transform);\n\tgoto L_0056;\nL_0041:\n\t*([v115 @ X22_v5+8]) = *([v115 @ X22_v5+8]);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::SyncAttachment(this, &v103 @ stack_-88_v5 (UnityEngine.Transform));\n\tv172 = v147 <= 0;\n\tif (v172) goto L_008B;\nL_0056:\n\tv147 = v147 - 1;\n\tv323 = System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::get_Item(this._attachments, v147);\n\tv103 = v323.target;\n\tgoto L_006B;\nL_006B:\n\tv329 = UnityEngine.Object::op_Equality(v323.target, 0);\n\tv331 = ~v329;\n\tif (v331) goto L_0041;\n\tgoto L_007B;\nL_007B:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::RemoveAt(this._attachments, v147);\n\tv171 = v147 > 0;\n\tif (v171) goto L_0056;\nL_008B:\n\tv224 = *([A4731E0]);\n\tv235 = *([v224 @ X9_v3]) != *([v25 @ X8_v2]);\n\tif (v235) goto L_00A5;\n\treturn;\nL_00A5:\n\tv267 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0025:\n\tv55 = this._attachments;\n")]
		private unsafe void UpdateAttachments()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::UpdateAttachments");
		}

		[Token(Token = "0x6000883")]
		[Address(RVA = "0x3E80930", Offset = "0x3E80930", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(att.target, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0033;\n\tgoto L_00A2;\nL_0033:\n\tv78 = att.nodeIdxA & 0x80000000;\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_00A2;\n\tv85 = att.nodeIdxB >= this._nodeCount;\n\tif (v85) goto L_00A2;\n\tv179 = this._positions + 0x20;\n\tv233 = att.nodeIdxA * 0xC;\n\tv195 = v179 + v233;\n\tv190 = att.nodeIdxB * 0xC;\n\tv182 = v179 + v190;\n\tv236 = *([v182 @ X9_v3+8]) - *([v195 @ X8_v5+8]);\n\tv239 = att.t < 1f;\n\tv240 = att.t == 1f;\n\tv243 = att.t == att.t;\n\tv164 = 1f == 1f;\n\tv244 = v243 & v164;\n\tv245 = ~v244;\n\tv246 = v239 == v245;\n\tv138 = ~v240;\n\tv153 = v246 & v138;\n\tv247 = ~v153;\n\tif (v247) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv141 = 1f;\n\tgoto L_007B;\nL_FFFFFFFF:\n\tv141 = att.t;\nL_FFFFFFFF:\n\tv141 = 0;\n\tgoto L_0088;\nL_00A2:\n\treturn;\nL_007B:\n\tv170 = att.t < 0;\n\tv135 = ~v170;\n\tif (v135) goto L_0088;\nL_0088:\n\tv255 = v236 * v141;\n\tv143 = *([v195 @ X8_v5+8]) + v255;\n\tv258 = *([v182 @ X9_v3]) - *([v195 @ X8_v5]);\n\tv259 = v258 * v260;\n\tv147 = *([v195 @ X8_v5]) + v259;\n\t// 152 MakeStruct v130 @ AGG3E80A64_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v147 @ V0_v3, v261 @ V0.S1, v143 @ V2_v3 (System.Single)\n\tUnityEngine.Transform::set_position(att.target, v130);\n\treturn;\n")]
		private void SyncAttachment(ChainAttachment att)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::SyncAttachment");
		}

		[Token(Token = "0x6000884")]
		[Address(RVA = "0x3E80D28", Offset = "0x3E80D28", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._debugAttachTarget, 0);\n\tv64 = ~v55;\n\tif (v64) goto L_0056;\n\tgoto L_002F;\nL_002F:\n\tUnityEngine.Debug::LogWarning(\"[ChainController] AttachDebug: _debugAttachTarget is null.\", this);\n\treturn;\nL_0056:\n\t// 86 MakeStruct v104 @ AGG3E80E20_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._debugAttachLocalPos (UnityEngine.Vector3), this._debugAttachLocalPos.y (System.Single), this._debugAttachLocalPos.z (System.Single)\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::Attach(this, this._debugAttachTarget, v104);\n\treturn;\n")]
		private void AttachDebug()
		{
			if (_debugAttachTarget == null)
			{
				Debug.LogWarning("[ChainController] AttachDebug: _debugAttachTarget is null.", this);
				return;
			}
			Vector3 localPosOnChain = default(Vector3);
			localPosOnChain.x = _debugAttachLocalPos.x;
			localPosOnChain.y = _debugAttachLocalPos.y;
			localPosOnChain.z = _debugAttachLocalPos.z;
			Attach(_debugAttachTarget, localPosOnChain);
		}

		[Token(Token = "0x6000885")]
		[Address(RVA = "0x3E80E24", Offset = "0x3E80E24", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._debugAttachTarget, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0041;\n\treturn;\nL_0041:\n\tv96 = _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::Detach(this, this._debugAttachTarget);\n\treturn;\n")]
		private void DetachDebug()
		{
			if (!(_debugAttachTarget == null))
			{
				bool flag = Detach(_debugAttachTarget);
			}
		}

		[Token(Token = "0x6000886")]
		[Address(RVA = "0x3E80ED4", Offset = "0x3E80ED4", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tthis._sleeping = 0;\n\tthis._sleepCounter = 0;\n\tv62 = this._shakePhase == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0094;\n\tv128 = this._shakeUnpinnedWaypoints;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(v128);\n\tv219 = this._waypointNodeIndices;\n\tv163 = v219.Length - 1;\n\tv139 = v163 < 2;\n\tif (v139) goto L_0094;\n\tv138 = 1 - v163;\n\tv236 = 9;\n\tgoto L_005F;\nL_0052:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v270, *([v277 @ X8_v16 (System.Int32[])+v236 @ X22_v7 (System.Int32)*4]));\nL_0053:\n\tv236 = v236 + 1;\n\tv164 = v138 + v236;\n\tv149 = v164 == 9;\n\tif (v149) goto L_0094;\nL_005F:\n\tv277 = this._waypointNodeIndices;\n\tv294 = System.Collections.Generic.HashSet`1<System.Int32>::Remove(this._pinnedNodes, *([v277 @ X8_v16 (System.Int32[])+v236 @ X22_v7 (System.Int32)*4]));\n\tv295 = ~v294;\n\tif (v295) goto L_0053;\n\tv270 = this._shakeUnpinnedWaypoints;\n\tgoto L_0052;\nL_0094:\n\tv166 = UnityEngine.Random::get_value();\n\tv67 = v166 * 0x447A0000;\n\tthis._shakeNoiseSeed = v67;\n\tthis._shakePhase = 1;\nL_0026:\n\tv57 = this._initialized != 1;\n\tif (v57) goto L_00A4;\nL_00A4:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Shake()
		{
			//IL_007e: Expected O, but got I4
			//IL_00aa: Expected O, but got I
			//IL_00ee: Expected O, but got I
			if (!_initialized)
			{
				return;
			}
			_sleeping = false;
			_sleepCounter = 0;
			if (_shakePhase == ShakePhase.None)
			{
				List<int> shakeUnpinnedWaypoints = _shakeUnpinnedWaypoints;
				shakeUnpinnedWaypoints.Clear();
				int[] waypointNodeIndices = _waypointNodeIndices;
				object obj = waypointNodeIndices.Length - 1;
				if ((nint)obj >= 2)
				{
					object obj2 = 1 - (nint)obj;
					int num = 9;
					object obj3;
					do
					{
						int[] waypointNodeIndices2 = _waypointNodeIndices;
						HashSet<int> pinnedNodes = _pinnedNodes;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X8_v16 (System.Int32[])+v236 @ X22_v7 (System.Int32)*4]");
						if (pinnedNodes.Remove(0))
						{
							List<int> shakeUnpinnedWaypoints2 = _shakeUnpinnedWaypoints;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X8_v16 (System.Int32[])+v236 @ X22_v7 (System.Int32)*4]");
							shakeUnpinnedWaypoints2.Add(0);
						}
						num++;
						obj3 = (nint)obj2 + num;
					}
					while ((nint)obj3 != 9);
				}
			}
			float value = UnityEngine.Random.value;
			float shakeNoiseSeed = value * 1000f;
			_shakeNoiseSeed = shakeNoiseSeed;
			_shakePhase = ShakePhase.Forcing;
		}

		[Token(Token = "0x6000887")]
		[Address(RVA = "0x3E81064", Offset = "0x3E81064", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this._shakePhase == 2;\n\tif (v6) goto L_0029;\n\tv20 = this._shakePhase != 1;\n\tif (v20) goto L_004C;\n\tv29 = this._shakeTimer + dt;\n\tthis._shakeTimer = v29;\n\tv31 = v29 < this._shakeForceDuration;\n\tv35 = v29 == v29;\n\tv36 = this._shakeForceDuration == this._shakeForceDuration;\n\tv37 = v35 & v36;\n\tv38 = ~v37;\n\tv39 = v31 == v38;\n\tv40 = ~v39;\n\tif (v40) goto L_004C;\n\tthis._shakePhase = 2;\n\treturn;\nL_0029:\n\tv22 = this._shakeTimer + dt;\n\tthis._shakeTimer = v22;\n\tv26 = this._sleeping == 0;\n\tv27 = ~v26;\n\tif (v27) goto L_0043;\n\tv88 = v22 < this._shakeSettleDuration;\n\tv97 = v22 == v22;\n\tv82 = this._shakeSettleDuration == this._shakeSettleDuration;\n\tv91 = v97 & v82;\n\tv77 = ~v91;\n\tv98 = v88 == v77;\n\tv74 = ~v98;\n\tif (v74) goto L_004C;\nL_0043:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::RepinShakeWaypoints(this);\n\tthis._shakePhase = 0;\n\tthis._sleeping = 0;\n\tthis._sleepCounter = 0;\nL_004C:\n\treturn;\n")]
		private void AdvanceShakeTimer(float dt)
		{
			if (_shakePhase != ShakePhase.Settling)
			{
				if (_shakePhase == ShakePhase.Forcing)
				{
					float num = (_shakeTimer += dt);
					bool flag = num < _shakeForceDuration;
					bool flag2 = num == num;
					bool flag3 = _shakeForceDuration == _shakeForceDuration;
					bool flag4 = flag2 && flag3;
					bool flag5 = !flag4;
					if (flag == flag5)
					{
						_shakePhase = ShakePhase.Settling;
					}
				}
				return;
			}
			float num2 = (_shakeTimer += dt);
			if (!_sleeping)
			{
				bool flag6 = num2 < _shakeSettleDuration;
				bool flag7 = num2 == num2;
				bool flag8 = _shakeSettleDuration == _shakeSettleDuration;
				bool flag9 = flag7 && flag8;
				bool flag10 = !flag9;
				if (flag6 != flag10)
				{
					return;
				}
			}
			RepinShakeWaypoints();
			_shakePhase = default(ShakePhase);
			_sleeping = false;
			_sleepCounter = 0;
		}

		[Token(Token = "0x6000888")]
		[Address(RVA = "0x3E81114", Offset = "0x3E81114", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv72 = this._shakeTimer * this._shakeNoiseTimeFreq;\n\tv154 = 0;\n\tv166 = 0;\n\tgoto L_0068;\nL_0032:\n\tv320 = v282 + v282;\n\tv321 = v320 + -1f;\n\tv322 = v150 + v150;\n\tv323 = v322 + -1f;\n\tv309 = this._shakeDirections + v154;\n\tv306 = v321 * *([v309 @ X9_v6+28]);\n\t// 61 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv303 = *([v309 @ X9_v6+24]) * v329;\n\t// 64 NotImplemented \"Instruction ZIP1 not yet implemented.\"\n\tv330 = *([v309 @ X9_v6+28]) * this._planeNormal.y;\n\tv331 = v303 - v330;\n\tv304 = *([v309 @ X9_v6+20]) * this._planeNormal.y;\n\tv332 = this._planeNormal * v333;\n\tv334 = v304 - v332;\n\tv335 = *([v309 @ X9_v6+20]) * v336;\n\tv337 = v331 * v338;\n\tv339 = v323 * v334;\n\tv340 = v335 + v337;\n\tv341 = v306 + v339;\n\tv313 = v272 + v154;\n\tv343 = v341 * this._shakeForce;\n\tv311 = *([v313 @ X8_v12+28]) + v343;\n\tv344 = v340 * v328;\n\tv310 = *([v313 @ X8_v12+20]) + v344;\n\t*([v313 @ X8_v12+20]) = v310;\n\t*([v313 @ X8_v12+28]) = v311;\nL_0068:\n\tv259 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(this._pinnedNodes, v166);\n\tv274 = v259 == 0;\n\tv275 = ~v274;\n\tif (v275) goto L_0055;\n\tv278 = this._shakeNoiseSpatialFreq * v166;\n\tv111 = v278 + this._shakeNoiseSeed;\n\tv282 = UnityEngine.Mathf::PerlinNoise(v111, v72);\n\tv316 = v111 + 0x43098000;\n\tv150 = UnityEngine.Mathf::PerlinNoise(v316, v72);\n\tv272 = this._accelerations;\n\tv319 = v166 < v272.Length;\n\tv301 = ~v319;\n\tv284 = ~v301;\n\tif (v284) goto L_0032;\n\tthrow System.IndexOutOfRangeException;\nL_00A7:\n\treturn;\nL_0025:\n\tv65 = this._nodeCount < 1;\n\tif (v65) goto L_00A7;\nL_0055:\n\tv166 = v166 + 1;\n\tv154 = v154 + 0xC;\n\tv78 = v166 >= this._nodeCount;\n\tif (v78) goto L_00A7;\n")]
		private void ApplyShakeForce()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::ApplyShakeForce");
		}

		[Token(Token = "0x6000889")]
		[Address(RVA = "0x3E810E8", Offset = "0x3E810E8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::RepinShakeWaypoints(this);\n\tthis._shakePhase = 0;\n\tthis._sleeping = 0;\n\tthis._sleepCounter = 0;\n\treturn;\n")]
		private void EndShake()
		{
			RepinShakeWaypoints();
			_shakePhase = default(ShakePhase);
			_sleeping = false;
			_sleepCounter = 0;
		}

		[Token(Token = "0x600088A")]
		[Address(RVA = "0x3E812CC", Offset = "0x3E812CC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv104 = 0;\n\tv96 = System.Collections.Generic.List`1<System.Int32>::get_Item(v121, v104);\n\tv156 = System.Collections.Generic.HashSet`1<System.Int32>::Add(this._pinnedNodes, v96);\n\tv104 = v104 + 1;\n\tv121 = this._shakeUnpinnedWaypoints;\n\tv157 = this._shakeUnpinnedWaypoints == 0;\n\tv98 = ~v157;\n\tif (v98) goto L_0031;\n\tv105 = new System.NullReferenceException();\n\tv121 = v105;\nL_0044:\n\tv144 = *([v121 @ X0_v6 (System.Collections.Generic.List`1<System.Int32>)+1C]) + 1;\n\t*([v121 @ X0_v6 (System.Collections.Generic.List`1<System.Int32>)+18]) = 0;\n\t*([v121 @ X0_v6 (System.Collections.Generic.List`1<System.Int32>)+1C]) = v144;\n\treturn;\nL_001F:\n\tv121 = this._shakeUnpinnedWaypoints;\nL_0031:\n\tv58 = v104 >= v121.Count;\n\tif (v58) goto L_0044;\n")]
		private void RepinShakeWaypoints()
		{
			//IL_00a6: Expected O, but got I
			List<int> shakeUnpinnedWaypoints = _shakeUnpinnedWaypoints;
			int num = 0;
			while (num < shakeUnpinnedWaypoints.Count)
			{
				int item = shakeUnpinnedWaypoints[num];
				bool flag = _pinnedNodes.Add(item);
				num++;
				shakeUnpinnedWaypoints = _shakeUnpinnedWaypoints;
				if (_shakeUnpinnedWaypoints == null)
				{
					NullReferenceException ex = new NullReferenceException();
					shakeUnpinnedWaypoints = (List<int>)(object)ex;
					break;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v6 (System.Collections.Generic.List`1<System.Int32>)+1C]");
			object obj = (nint)0 + (nint)1;
			_ = 0;
		}

		[Token(Token = "0x600088B")]
		[Address(RVA = "0x3E813A4", Offset = "0x3E813A4", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_0027;\nL_0027:\n\tv65 = UnityEngine.Application::get_isPlaying();\n\tv107 = ~v65;\n\tv108 = ~v107;\n\tif (v108) goto L_003A;\n\tgoto L_00E7;\nL_0033:\n\treturn;\nL_003A:\n\tv115 = UnityEngine.Time::get_deltaTime();\n\tv167 = this._shakePhase == 2;\n\tif (v167) goto L_0064;\n\tv181 = this._shakePhase != 1;\n\tif (v181) goto L_007E;\n\tv189 = v115 + this._shakeTimer;\n\tthis._shakeTimer = v189;\n\tv191 = v189 < this._shakeForceDuration;\n\tv195 = v189 == v189;\n\tv196 = this._shakeForceDuration == this._shakeForceDuration;\n\tv197 = v195 & v196;\n\tv198 = ~v197;\n\tv199 = v191 == v198;\n\tv200 = ~v199;\n\tif (v200) goto L_007E;\n\tthis._shakePhase = 2;\n\tgoto L_007E;\nL_0064:\n\tv183 = v115 + this._shakeTimer;\n\tthis._shakeTimer = v183;\n\tv186 = this._sleeping == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_0078;\n\tv212 = v183 < this._shakeSettleDuration;\n\tv224 = v183 == v183;\n\tv208 = this._shakeSettleDuration == this._shakeSettleDuration;\n\tv214 = v224 & v208;\n\tv206 = ~v214;\n\tv225 = v212 == v206;\n\tv204 = ~v225;\n\tif (v204) goto L_007E;\nL_0078:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::RepinShakeWaypoints(this);\n\tthis._shakePhase = 0;\n\tthis._sleeping = 0;\n\tthis._sleepCounter = 0;\n\tv226 = UnityEngine.Time::get_deltaTime();\n\tv229 = UnityEngine.Mathf::Min(v226, 0.04f);\n\tv151 = this._accumulator + v229;\n\tthis._accumulator = v151;\n\tv136 = v151 < 0x3CA3D70A;\n\tv232 = v151 == v151;\n\tv123 = ~v232;\n\tv233 = v136 == v123;\n\tv120 = ~v233;\n\tif (v120) goto L_00E7;\n\tv244 = this._shakePhase != 1;\n\tif (v244) goto L_00AB;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::ApplyShakeForce(this);\nL_00AB:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::Simulate(this, 0.02f);\n\tv255 = this._accumulator + 0xFFFFFFFFBCA3D70A;\n\tthis._accumulator = v255;\n\tv256 = v255 < 0x3CA3D70A;\n\tv260 = v255 == v255;\n\tv263 = ~v260;\n\tv264 = v256 == v263;\n\tv265 = ~v264;\n\tif (v265) goto L_00D9;\n\tv276 = this._shakePhase != 1;\n\tif (v276) goto L_00CF;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::ApplyShakeForce(this);\nL_00CF:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::Simulate(this, 0.02f);\n\tv286 = this._accumulator + 0xFFFFFFFFBCA3D70A;\n\tthis._accumulator = v286;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::UpdateMatrices(this);\nL_00E7:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::DrawLinks(this);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController::UpdateAttachments(this);\n\treturn;\nL_001E:\n\tv52 = this._initialized != 1;\n\tif (v52) goto L_0033;\nL_007E:\n\tv222 = this._sleeping == 0;\n\tv157 = ~v222;\n\tif (v157) goto L_00E7;\nL_00D9:\n\tv135 = v151 < 0x3CA3D70A;\n\tv292 = v151 == v151;\n\tv122 = ~v292;\n\tv293 = v135 == v122;\n\tv119 = ~v293;\n\tif (v119) goto L_00E7;\n")]
		private void LateUpdate()
		{
			//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ec: Expected I4, but got Unknown
			if (!_initialized)
			{
				return;
			}
			if (!Application.isPlaying)
			{
				goto IL_03aa;
			}
			float deltaTime = Time.deltaTime;
			if (_shakePhase != ShakePhase.Settling)
			{
				if (_shakePhase == ShakePhase.Forcing)
				{
					float num = (_shakeTimer = deltaTime + _shakeTimer);
					bool flag = num < _shakeForceDuration;
					bool flag2 = num == num;
					bool flag3 = _shakeForceDuration == _shakeForceDuration;
					bool flag4 = flag2 && flag3;
					bool flag5 = !flag4;
					if (flag == flag5)
					{
						_shakePhase = ShakePhase.Settling;
					}
				}
			}
			else
			{
				float num2 = (_shakeTimer = deltaTime + _shakeTimer);
				if (!_sleeping)
				{
					bool flag6 = num2 < _shakeSettleDuration;
					bool flag7 = num2 == num2;
					bool flag8 = _shakeSettleDuration == _shakeSettleDuration;
					bool flag9 = flag7 && flag8;
					bool flag10 = !flag9;
					if (flag6 != flag10)
					{
						goto IL_03de;
					}
				}
				RepinShakeWaypoints();
				_shakePhase = default(ShakePhase);
				_sleeping = false;
				_sleepCounter = 0;
			}
			goto IL_03de;
			IL_03de:
			if (!_sleeping)
			{
				float deltaTime2 = Time.deltaTime;
				float num3 = Mathf.Min(deltaTime2, 0.04f);
				float num4 = (_accumulator += num3);
				bool flag11 = num4 < 0.02f;
				bool flag12 = num4 == num4;
				bool flag13 = !flag12;
				if (flag11 == flag13)
				{
					if (_shakePhase == ShakePhase.Forcing)
					{
						ApplyShakeForce();
					}
					Simulate(0.02f);
					int num5 = (int)(_accumulator + -1130113270);
					_accumulator = num5;
					bool flag14 = num5 < 1017370378;
					bool flag15 = num5 == num5;
					bool flag16 = !flag15;
					if (flag14 == flag16)
					{
						if (_shakePhase == ShakePhase.Forcing)
						{
							ApplyShakeForce();
						}
						Simulate(0.02f);
						float accumulator = _accumulator + -0.02f;
						_accumulator = accumulator;
					}
					bool flag17 = num4 < 0.02f;
					bool flag18 = num4 == num4;
					bool flag19 = !flag18;
					if (flag17 == flag19)
					{
						UpdateMatrices();
					}
				}
			}
			goto IL_03aa;
			IL_03aa:
			DrawLinks();
			UpdateAttachments();
		}

		[Token(Token = "0x600088C")]
		[Address(RVA = "0x3E8169C", Offset = "0x3E8169C", Length = "0xA28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv74 = v64._shakeUnpinnedWaypoints;\n\tv77 = v74.Count < 1;\n\tif (v77) goto L_007C;\n\tv856 = v64._shakePhase != 2;\n\tif (v856) goto L_008C;\n\tv889 = v64._shakeWaypointReturnRate * dt;\n\tv890 = -v889;\n\tv833 = 0x8BF63B0(v64, methodInfo, v51, v52, v53, v54, v55, v56, v890, v57, v58, v59, v60, v61, v62, v63);\n\tv990 = 1f - v890;\n\tv991 = v990 < 1f;\n\tv992 = v990 == 1f;\n\tv995 = v990 == v990;\n\tv996 = 1f == 1f;\n\tv997 = v995 & v996;\n\tv998 = ~v997;\n\tv999 = v991 == v998;\n\tv797 = ~v992;\n\tv1000 = v999 & v797;\n\tv1001 = ~v1000;\n\tif (v1001) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv799 = 1f;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv799 = v990;\nL_FFFFFFFF:\n\tv986 = 0;\n\tgoto L_006C;\nL_FFFFFFFF:\n\tv986 = v799;\nL_FFFFFFFF:\n\t;\n\tgoto L_01B6;\nL_007C:\n\t;\n\tv120 = v64._nodeCount >= 1;\nL_FFFFFFFF:\n\tv372 = 1;\nL_FFFFFFFF:\n\tv986 = 0;\n\tif (v120) goto L_009B;\nL_FFFFFFFF:\n\t;\n\tgoto L_01B6;\nL_008C:\n\t;\n\tv805 = v64._nodeCount < 1;\nL_FFFFFFFF:\n\tv372 = 0;\nL_FFFFFFFF:\n\tv986 = 0;\nL_FFFFFFFF:\n\t;\n\tif (v805) goto L_01B6;\nL_009B:\n\tv839 = dt * dt;\n\tv840 = v986 < 0;\n\tv343 = ~v840;\n\tif (v343) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv986 = 0;\n\tgoto L_FFFFFFFF;\nL_00B1:\n\tv1419 = v751 + v177;\nL_00C7:\n\tv1031 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v64._pinnedNodes, v776);\n\tv1135 = v1031 == 0;\n\tv1136 = ~v1135;\n\tif (v1136) goto L_00B4;\n\tv1383 = v372 & 1;\n\tv1384 = v1383 == 0;\n\tv1385 = ~v1384;\n\tif (v1385) goto L_013F;\n\tv687 = System.Collections.Generic.List`1<System.Int32>::Contains(v64._shakeUnpinnedWaypoints, v776);\n\tv1475 = ~v687;\n\tif (v1475) goto L_013F;\n\tv400 = v64._shakePhase != 2;\n\tif (v400) goto L_01B1;\n\tgoto L_0100;\nL_0100:\n\tv1895 = v64._accelerations + v177;\n\t*([v1895 @ X8_v94]) = v1894.zero;\n\t*([v1895 @ X8_v94+8]) = v1894.zero.z;\n\tv1960 = v64._positions + v177;\n\tv655 = v64._restPositions + v177;\n\tv1965 = *([v655 @ X9_v69]) - *([v1960 @ X8_v96]);\n\tv238 = v1965 * v1922;\n\tv1396 = *([v1960 @ X8_v96]) + v238;\n\tv1966 = *([v655 @ X9_v69+8]) - *([v1960 @ X8_v96+8]);\n\tv252 = v986 * v1966;\n\tv1395 = *([v1960 @ X8_v96+8]) + v252;\n\t*([v1960 @ X8_v96]) = v1396;\n\t*([v1960 @ X8_v96+8]) = v1395;\n\tv751 = v64._previousPositions;\n\tv1972 = v776 < v751.Length;\n\tv1249 = ~v1972;\n\tv1150 = ~v1249;\n\tif (v1150) goto L_00B1;\n\tgoto L_033C;\nL_013F:\n\tv284 = v64._accelerations;\nL_FFFFFFFF:\n\tv1264 = 1;\nL_014D:\n\tv220 = v284 + v177;\n\tv210 = *([v220 @ X28_v17]);\n\tv786 = *([v220 @ X28_v17+8]);\n\tv1587 = v1264 == 0;\n\tif (v1587) goto L_016C;\n\tv210 = v210 + v64._gravity;\n\tv786 = v786 + v64._gravity.z;\n\tv1671 = *([B193A7F]) & 1;\n\tv1672 = v1671 == 0;\n\tv1673 = ~v1672;\nL_FFFFFFFF:\n\tv1141 = v210;\nL_FFFFFFFF:\n\tv1286 = v786;\n\tif (v1673) goto L_FFFFFFFF;\nL_015D:\n\t*([B193A7F]) = 1;\n\tv1795 = v776 < v284.Length;\n\tv1251 = ~v1795;\n\tv1152 = ~v1251;\n\tif (v1152) goto L_017D;\n\tgoto L_033C;\nL_016C:\n\tv1675 = *([B193A7F]) & 1;\n\tv1676 = v1675 == 0;\nL_FFFFFFFF:\n\tv1141 = *([v220 @ X28_v17]);\nL_FFFFFFFF:\n\tv1286 = *([v220 @ X28_v17+8]);\n\tif (v1676) goto L_015D;\nL_FFFFFFFF:\n\tv210 = v1141;\nL_FFFFFFFF:\n\tv786 = v1286;\nL_017D:\n\t*([v220 @ X28_v17]) = v1801.zero;\n\t*([v220 @ X28_v17+8]) = v1801.zero.z;\n\tv1419 = v64._positions + v177;\n\tv1914 = v64._previousPositions + v177;\n\tv1916 = *([v1419 @ X8_v77+8]) - *([v1914 @ X9_v60+8]);\n\tv1918 = v1916 * v64._damping;\n\t*([v1914 @ X9_v60+8]) = *([v1419 @ X8_v77+8]);\n\tv1919 = *([v1419 @ X8_v77+8]) + v1918;\n\tv1921 = v210 * v1922;\n\tv1923 = v839 * v786;\n\tv1395 = v1923 + v1919;\n\tv1926 = *([v1419 @ X8_v77]) - *([v1914 @ X9_v60]);\n\tv1927 = v1926 * v1928;\n\t*([v1914 @ X9_v60]) = *([v1419 @ X8_v77]);\n\tv1929 = *([v1419 @ X8_v77]) + v1927;\n\tv1396 = v1921 + v1929;\n\tgoto L_00B2;\nL_01B1:\n\tv284 = v64._accelerations;\n\tv1776 = v64._accelerations == 0;\n\tv717 = ~v1776;\nL_FFFFFFFF:\n\tv1264 = 0;\n\tif (v717) goto L_014D;\n\tgoto L_04EC;\nL_01B6:\n\tv1119 = v64._waypoints;\nL_FFFFFFFF:\n\tv200 = 0;\nL_FFFFFFFF:\n\tv375 = 0;\n\tgoto L_01CB;\nL_01BD:\n\tv375 = v375 + 1;\n\tv200 = v200 + 0xC;\nL_01CB:\n\tv403 = v375 >= v1119.Length;\n\tif (v403) goto L_0229;\n\tv757 = v64._waypointNodeIndices;\n\tv689 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v64._pinnedNodes, v757[v375 @ X23_v7 (System.Int32)]);\n\tv1119 = v64._waypoints;\n\tv1477 = ~v689;\n\tif (v1477) goto L_01BD;\n\tv271 = v64._positions;\n\tv665 = v64._waypoints + v200;\n\tv1802 = v757[v375 @ X23_v7 (System.Int32)] * 0xC;\n\tv1803 = v64._positions + v1802;\n\t*([v1803 @ X10_v23+20]) = *([v665 @ X9_v49+20]);\n\tv271[v778 @ X20_v25 (System.Int32)].z = *([v665 @ X9_v49+28]);\n\tv272 = v64._previousPositions;\n\tv1566 = v757[v375 @ X23_v7 (System.Int32)] * 0xC;\n\tv1564 = v64._previousPositions + v1566;\n\t*([v1564 @ X9_v50+20]) = *([v665 @ X9_v49+20]);\n\tv272[v778 @ X20_v25 (System.Int32)].z = *([v665 @ X9_v49+28]);\n\tgoto L_01BD;\nL_0229:\n\tv1030 = v64._constraintIterations < 1;\n\tif (v1030) goto L_0347;\nL_FFFFFFFF:\n\tv376 = 0;\n\tgoto L_024C;\nL_0234:\n\tv376 = v376 + 1;\n\tv1084 = v376 >= v64._constraintIterations;\n\tif (v1084) goto L_0347;\nL_024C:\n\tv1325 = v64._linkCount < 1;\n\tif (v1325) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv201 = 0;\nL_FFFFFFFF:\n\tv222 = 0x20;\n\tgoto L_0269;\nL_0251:\n\tv1860 = v761 + v222;\n\tv1848 = *([v1860 @ X8_v66+14]) - v159;\n\tv1847 = *([v1860 @ X8_v66+C]) - v214;\n\t*([v1860 @ X8_v66+C]) = v1847;\n\t*([v1860 @ X8_v66+14]) = v1848;\nL_0269:\n\tv167 = v201 + 1;\n\tv1589 = v64._positions + v222;\n\tgoto L_0287;\nL_0289:\n\tv388 = *([v1589 @ X8_v55+C]) - *([v1589 @ X8_v55]);\n\tv361 = *([v1589 @ X8_v55+14]) - *([v1589 @ X8_v55+8]);\n\tv1781 = v388 * v388;\n\t// 652 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv1782 = v361 * v361;\n\tv1783 = v1781 + v1782;\n\tv255 = UnityEngine.Mathf::Sqrt(v1783);\n\tv577 = v255 < 0x358637BD;\n\tif (v577) goto L_0259;\n\tv759 = v64._restLengths;\n\tv242 = v255 - v759[v201 @ X21_v28 (System.Int32)];\n\tv1933 = v242 / v255;\n\tv256 = v1933 * 0.5f;\n\tv214 = v388 * v1934;\n\tv159 = v361 * v256;\n\tv695 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v64._pinnedNodes, v201);\n\tv1951 = v695 == 0;\n\tv1952 = ~v1951;\n\tif (v1952) goto L_02D3;\n\tv1970 = v64._positions + v222;\n\tv1968 = v159 + *([v1970 @ X8_v68+8]);\n\tv1967 = v214 + *([v1970 @ X8_v68]);\n\t*([v1970 @ X8_v68]) = v1967;\n\t*([v1970 @ X8_v68+8]) = v1968;\nL_02D3:\n\tv301 = v201 + 1;\n\tv696 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v64._pinnedNodes, v301);\n\tv1979 = v696 == 0;\n\tv1858 = ~v1979;\n\tif (v1858) goto L_0259;\n\tv761 = v64._positions;\n\tv1988 = v167 < v761.Length;\n\tv1257 = ~v1988;\n\tv1153 = ~v1257;\n\tif (v1153) goto L_0251;\n\tgoto L_033C;\nL_02E9:\n\tv1119 = v64._waypoints;\nL_FFFFFFFF:\n\tv169 = 0;\nL_FFFFFFFF:\n\tv225 = 0;\n\tgoto L_0304;\nL_02EF:\n\tv1862 = v64._waypoints + v169;\n\tv1867 = v764[v225 @ X28_v9 (System.Int32)] * 0xC;\n\tv1865 = v674 + v1867;\n\t*([v1865 @ X9_v37+20]) = *([v1862 @ X10_v21+20]);\n\tv674[v203 @ X21_v26 (System.Int32)].z = *([v1862 @ X10_v21+28]);\nL_0304:\n\tv407 = v225 >= v1119.Length;\n\tif (v407) goto L_0234;\n\tv764 = v64._waypointNodeIndices;\n\tv698 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v64._pinnedNodes, v764[v225 @ X28_v9 (System.Int32)]);\n\tv1119 = v64._waypoints;\n\tv1806 = ~v698;\n\tif (v1806) goto L_02F6;\n\tv674 = v64._positions;\n\tv1935 = v764[v225 @ X28_v9 (System.Int32)] < v674.Length;\n\tv1248 = ~v1935;\n\tv1149 = ~v1248;\n\tif (v1149) goto L_02EF;\nL_033C:\n\tthrow System.IndexOutOfRangeException;\nL_0347:\n\tv1133 = v64._constrainToPlane != 1;\n\tif (v1133) goto L_03B5;\n\tv1337 = v64._nodeCount < 1;\n\tif (v1337) goto L_03B5;\nL_FFFFFFFF:\n\tv205 = 0;\nL_FFFFFFFF:\n\tv781 = 0;\n\tgoto L_036C;\nL_0359:\n\tv781 = v781 + 1;\n\tv205 = v205 + 0xC;\n\tv1355 = v781 >= v64._nodeCount;\n\tif (v1355) goto L_03B5;\nL_036C:\n\tv702 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v64._pinnedNodes, v781);\n\tv1596 = v702 == 0;\n\tv1597 = ~v1596;\n\tif (v1597) goto L_0359;\n\tv1807 = v64._positions + v205;\n\tv1810 = *([v1807 @ X8_v38+28]) - v64._planePoint.z;\n\tv1812 = v1810 * v64._planeNormal.z;\n\tv1815 = *([v1807 @ X8_v38+20]) - v64._planePoint;\n\tv142 = v1815 * v64._planeNormal;\n\t// 906 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv1816 = v1812 + v142;\n\tv232 = v64._planeNormal * v1817;\n\tv367 = v64._planeNormal.z * v1816;\n\tv260 = *([v1807 @ X8_v38+20]) - v232;\n\tv394 = *([v1807 @ X8_v38+28]) - v367;\n\t*([v1807 @ X8_v38+20]) = v260;\n\t*([v1807 @ X8_v38+28]) = v394;\n\tv1701 = v64._pr\n// ... truncated")]
		private void Simulate(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::Simulate");
		}

		[Token(Token = "0x600088D")]
		[Address(RVA = "0x3E801F8", Offset = "0x3E801F8", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv54 = this._linkCount < 1;\n\tif (v54) goto L_0112;\n\tv293 = 0x20;\n\tv294 = 0;\n\tv295 = 0;\nL_003D:\n\tv191 = v294 + 1;\n\tv539 = this._positions + v295;\n\tv542 = *([v539 @ X8_v7+2C]) - *([v539 @ X8_v7+20]);\n\tv543 = *([v539 @ X8_v7+30]) - *([v539 @ X8_v7+24]);\n\tv544 = *([v539 @ X8_v7+34]) - *([v539 @ X8_v7+28]);\n\tv545 = v542 * v542;\n\tv546 = v543 * v543;\n\tv547 = v545 + v546;\n\tv548 = v544 * v544;\n\tv549 = v547 + v548;\n\tv508 = v549 < 0x322BCC77;\n\tv506 = v549 == 0x322BCC77;\n\tv552 = v549 == v549;\n\tv498 = ~v552;\n\tv553 = v508 == v498;\n\tv554 = ~v553;\n\tv496 = v554 | v506;\n\tif (v496) goto L_007D;\n\t// 106 MakeStruct v559 @ AGG3E802D0_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v542 @ V0_v5, v543 @ V1_v5, v544 @ V2_v5\n\t// 107 MakeStruct v560 @ AGG3E802D0_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this._planeUpHint (UnityEngine.Vector3), this._planeUpHint.y (System.Single), this._planeUpHint.z (System.Single)\n\tv561 = UnityEngine.Quaternion::LookRotation(v559, v560);\n\tv573 = v294 & 1;\n\tv574 = v573 == 0;\n\tv575 = ~v574;\n\tv588 = v561.w;\n\tv589 = v561.z;\n\tv590 = v561.y;\n\tv591 = v561;\n\tif (v575) goto L_008E;\n\tv140 = v561.w;\n\tv142 = v561.z;\n\tv144 = v561.y;\n\tv614 = v561;\n\tgoto L_00B1;\nL_007D:\n\tgoto L_0083;\nL_008E:\n\t// 142 MakeStruct v606 @ AGG3E80324_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 1070141403\n\tv607 = UnityEngine.Quaternion::Internal_FromEulerRad(v606);\n\tv642 = v588 * v607;\n\tv643 = v591 * v607.w;\n\tv644 = v642 + v643;\n\tv645 = v590 * v607.z;\n\tv646 = v645 + v644;\n\tv647 = v589 * v607.y;\n\tv627 = v591 * v607.z;\n\tv609 = v591 * v607.y;\n\tv608 = v591 * v607;\n\tv614 = v646 - v647;\n\tv648 = v588 * v607.y;\n\tv649 = v590 * v607.w;\n\tv650 = v648 + v649;\n\tv651 = v589 * v607;\n\tv652 = v651 + v650;\n\tv653 = v590 * v607;\n\tv623 = v590 * v607.y;\n\tv144 = v652 - v627;\n\tv654 = v588 * v607.z;\n\tv629 = v589 * v607.w;\n\tv655 = v654 + v629;\n\tv617 = v609 + v655;\n\tv621 = v589 * v607.z;\n\tv142 = v617 - v653;\n\tv656 = v588 * v607.w;\n\tv657 = v656 - v608;\n\tv625 = v657 - v623;\n\tv140 = v625 - v621;\n\tv226 = v191 - 1;\n\tv659 = this._matrices + v293;\n\t*([v659 @ X9_v7+20]) = v154.m02;\n\t*([v659 @ X9_v7+30]) = v154.m03;\n\t*([v659 @ X9_v7]) = v154.m00;\n\t*([v659 @ X9_v7+10]) = v154.m01;\n\tv295 = v295 + 0xC;\n\tv293 = v293 + 0x40;\n\tv294 = v226 + 1;\n\tv208 = v294 < this._linkCount;\n\tif (v208) goto L_003D;\nL_0112:\n\treturn;\nL_00B1:\n\tv633 = *([v539 @ X8_v7+20]) + *([v539 @ X8_v7+2C]);\n\tv634 = *([v539 @ X8_v7+24]) + *([v539 @ X8_v7+30]);\n\tv635 = *([v539 @ X8_v7+28]) + *([v539 @ X8_v7+34]);\n\tv484 = v633 * 0.5f;\n\tv482 = v634 * 0.5f;\n\tv480 = v635 * 0.5f;\n\t// 195 MakeStruct v71 @ AGG3E803E4_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v484 @ V0_v8 (System.Single), v482 @ V1_v9 (System.Single), v480 @ V2_v9 (System.Single)\n\t// 196 MakeStruct v68 @ AGG3E803E4_1_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v614 @ V11_v8 (System.Single), v144 @ V10_v6 (System.Single), v142 @ V9_v6 (System.Single), v140 @ V8_v6 (System.Single)\n\tv154 = UnityEngine.Matrix4x4::TRS(v71, v68, this._linkScale);\nL_0083:\n\tv591 = v580.identity;\n\tv590 = v580.identity.y;\n\tv589 = v580.identity.z;\n\tv588 = v580.identity.w;\n\tv585 = v294 & 1;\n\tv586 = v585 == 0;\n\tv140 = v580.identity.w;\n\tv142 = v580.identity.z;\n\tv144 = v580.identity.y;\n\tv614 = v580.identity;\n\tif (v586) goto L_00B1;\n")]
		private void UpdateMatrices()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::UpdateMatrices");
		}

		[Token(Token = "0x600088E")]
		[Address(RVA = "0x3E815A0", Offset = "0x3E815A0", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this._linkMesh, 0);\n\tv65 = v55 == 0;\n\tif (v65) goto L_0035;\n\tgoto L_0058;\nL_0035:\n\tv80 = this._matrices == 0;\n\tif (v80) goto L_0058;\n\tgoto L_004F;\nL_004F:\n\tUnityEngine.Graphics::DrawMeshInstanced(this._linkMesh, 0, this._linkMaterial, this._matrices, this._linkCount);\n\treturn;\nL_0058:\n\treturn;\n")]
		private void DrawLinks()
		{
			if (!(_linkMesh == null) && _matrices != null)
			{
				Graphics.DrawMeshInstanced(_linkMesh, 0, _linkMaterial, _matrices, _linkCount);
			}
		}

		[Token(Token = "0x600088F")]
		[Address(RVA = "0x3E820C4", Offset = "0x3E820C4", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tthis._constrainToPlane = 1;\n\tv127 = new System.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.UnityBindings.Scripts.ChainController+ChainAttachment>::.ctor(v127);\n\tthis._attachments = v127;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0028:\n\tgoto L_003A;\nL_0067:\n\tthis._debugAttachLocalPos = v109.zero;\n\tthis._debugAttachLocalPos.z = v109.zero.z;\n\tv114 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v114);\n\tthis._shakeUnpinnedWaypoints = v114;\nL_003A:\n\t// 58 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv81 = v76.one.z * 0x3D4CCCCD;\n\tv83 = v76.one * v39;\n\tthis._linkScale = v83;\n\tthis._linkScale.z = v81;\n\tthis._damping = 0.98f;\n\tthis._constraintIterations = 5;\n\tthis._gravity = *([9309500]);\n\tthis._minNodes = 3;\n\tthis._sleepThreshold = 0.0001f;\n\tthis._sleepFrames = 0x1E;\n\tthis._shakeForce = *([9309510]);\n\tthis._shakeNoiseSpatialFreq = 1.1444092242740567E-06d;\n\tthis._shakeWaypointReturnRate = 12f;\n\tgoto L_0067;\n")]
		public ChainController()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainController::.ctor");
		}
	}
}
