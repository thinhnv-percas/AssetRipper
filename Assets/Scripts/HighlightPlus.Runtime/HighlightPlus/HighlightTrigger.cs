using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace HighlightPlus
{
	[RequireComponent(typeof(HighlightEffect))]
	[ExecuteInEditMode]
	[HelpURL("https://kronnect.com/docs/highlight-plus/")]
	[Token(Token = "0x200003B")]
	public class HighlightTrigger : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x200003C")]
		private sealed class _003CDoRayCast_003Ed__56 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400033D")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400033E")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400033F")]
			[FieldOffset(Offset = "0x20")]
			public HighlightTrigger _003C_003E4__this;

			[Token(Token = "0x4000340")]
			[FieldOffset(Offset = "0x28")]
			private WaitForEndOfFrame _003Cw_003E5__2;

			[Token(Token = "0x17000011")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600012D")]
				[Address(RVA = "0x7732AEC", Offset = "0x7732AEC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000012")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600012F")]
				[Address(RVA = "0x7732B34", Offset = "0x7732B34", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600012A")]
			[Address(RVA = "0x7730A5C", Offset = "0x7730A5C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CDoRayCast_003Ed__56(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600012B")]
			[Address(RVA = "0x7731F44", Offset = "0x7731F44", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600012C")]
			[Address(RVA = "0x7731F48", Offset = "0x7731F48", Length = "0xBA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv89 = this.<>1__state == 0;\n\tif (v89) goto L_007F;\n\tv106 = this.<>1__state == 1;\n\tif (v106) goto L_0087;\n\tv141 = this.<>1__state == 2;\n\tif (v141) goto L_0078;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0186;\nL_005C:\n\tv94 = this.<>1__state == 3;\n\tif (v94) goto L_0078;\n\tv120 = this.<>1__state == 4;\n\tif (v120) goto L_00B4;\n\tv126 = this.<>1__state != 5;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v126) goto L_0186;\nL_0078:\n\tthis.<>1__state = -1;\n\tv153 = this.<>4__this == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_00A0;\n\tgoto L_051D;\nL_007F:\n\tthis.<>2__current = 0;\n\tthis.<>1__state = -1;\nL_FFFFFFFF:\n\tv420 = 1;\n\tgoto L_016F;\nL_0087:\n\tthis.<>1__state = -1;\n\tv163 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v163);\n\tthis.<w>5__2 = v163;\nL_00A0:\n\tv200 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+24]) != 1;\n\tif (v200) goto L_FFFFFFFF;\n\tgoto L_00AC;\nL_00AC:\n\tv1084 = UnityEngine.Object::op_Equality(*([v73 @ X20_v2 (UnityEngine.Behaviour)+28]), 0);\n\tv1097 = v1084 == 0;\n\tif (v1097) goto L_00D7;\n\tgoto L_013F;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0186;\nL_00B4:\n\tthis.<>1__state = -1;\n\tgoto L_00BE;\nL_00BE:\n\tv508 = UnityEngine.Time::get_frameCount();\n\tv1044 = v505.lastTriggerFrame < v508;\n\tif (v1044) goto L_0157;\n\tgoto L_016B;\nL_00D7:\n\tv1125 = UnityEngine.Behaviour::get_isActiveAndEnabled(this.<>4__this);\n\tv1141 = v1125 == 0;\n\tif (v1141) goto L_013F;\n\tv1147 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+30]) == 0;\n\tif (v1147) goto L_0188;\n\tv1150 = UnityEngine.Camera::get_pixelWidth(*([v73 @ X20_v2 (UnityEngine.Behaviour)+28]));\n\tv1160 = UnityEngine.Camera::get_pixelHeight(*([v73 @ X20_v2 (UnityEngine.Behaviour)+28]));\n\t// 236 MakeStruct v1161 @ AGG7732160_1_v8 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v1150 @ X0_v154 (System.Int32), v1160 @ X0_v156 (System.Int32)\n\tv1165 = HighlightPlus.HighlightTrigger::CanInteractAt(this.<>4__this, v1161);\n\tv1167 = v1165 == 0;\n\tif (v1167) goto L_019C;\nL_00F3:\n\tv1171 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+30]) == 0;\n\tif (v1171) goto L_01B8;\n\tv847 = UnityEngine.Component::get_transform(*([v73 @ X20_v2 (UnityEngine.Behaviour)+28]));\n\tv667 = UnityEngine.Transform::get_position(v847);\n\tv849 = UnityEngine.Component::get_transform(*([v73 @ X20_v2 (UnityEngine.Behaviour)+28]));\n\tv1282 = UnityEngine.Transform::get_forward(v849);\n\tgoto L_0122;\nL_0124:\n\tv1314 = v1282 * v1282;\n\tv1315 = v1282.y * v1282.y;\n\tv1316 = v1314 + v1315;\n\tv1317 = v1282.z * v1282.z;\n\tv1318 = v1317 + v1316;\n\tv1233 = UnityEngine.Mathf::Sqrt(v1318);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1227 = v667.z;\nL_FFFFFFFF:\n\tv335 = v667.y;\nL_FFFFFFFF:\n\tv338 = v667;\nL_FFFFFFFF:\n\t;\n\tgoto L_01E2;\nL_013F:\n\tthis.<>2__current = 0;\nL_FFFFFFFF:\n\tv420 = 2;\n\tgoto L_016F;\nL_0157:\n\tv1103 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+90]);\n\tv1119 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+90]) == 0;\n\tif (v1119) goto L_0166;\n\tv1130 = UnityEngine.Component::get_gameObject(this.<>4__this);\n\t*([v1103 @ X22_v29+18])(v1134, *([v1103 @ X22_v29+40]), v1130, *([v1103 @ X22_v29+28]), v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_0168:\n\tHighlightPlus.HighlightManager::DeselectAll();\nL_016B:\n\tthis.<>2__current = 0;\nL_FFFFFFFF:\n\tv420 = 5;\nL_0188:\n\tv1149 = UnityEngine.Input::get_mousePosition();\n\t// 396 MakeStruct v1154 @ AGG7732308_1_v7 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v1149 @ V0_v7 (UnityEngine.Vector3), v1149.y (System.Single)\n\tv1155 = HighlightPlus.HighlightTrigger::CanInteractAt(this.<>4__this, v1154);\n\tv1157 = v1155 == 0;\n\tv1158 = ~v1157;\n\tif (v1158) goto L_00F3;\nL_019C:\n\tv716 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+45]) != 1;\n\tif (v716) goto L_01B2;\n\tv851 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+80]);\n\tv1176 = v851.highlighted != 1;\n\tif (v1176) goto L_01B2;\n\tHighlightPlus.HighlightEffect::SetHighlighted(v851, 0);\nL_01B2:\n\tthis.<>2__current = 0;\nL_FFFFFFFF:\n\tv420 = 3;\n\tgoto L_016F;\nL_01B8:\n\tv668 = UnityEngine.Input::get_mousePosition();\n\tv1197 = UnityEngine.Camera::ScreenPointToRay(*([v73 @ X20_v2 (UnityEngine.Behaviour)+28]), v668);\n\tv1198 = v1197.origin;\nL_FFFFFFFF:\n\tv1227 = v1197.m_Origin.z;\nL_FFFFFFFF:\n\tv335 = v1197.m_Origin.y;\nL_FFFFFFFF:\n\tv338 = v1197.origin;\nL_FFFFFFFF:\n\t;\n\tgoto L_01E2;\n\tgoto L_01F9;\nL_FFFFFFFF:\n\tv1292 = 0x7F7FFFFF;\n\tv1320 = *([v1311 @ X8_v24+18]) == 0;\n\tif (v1320) goto L_FFFFFFFF;\n\tv1378 = UnityEngine.LayerMask::op_Implicit(*([v73 @ X20_v2 (UnityEngine.Behaviour)+34]));\n\tv1462 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]) < 0;\n\tv1463 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]) == 0;\n\tv1466 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]) == *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]);\n\tv1467 = ~v1466;\n\tv1468 = v1462 == v1467;\n\tv1469 = ~v1468;\n\tv1470 = v1469 | v1463;\n\tif (v1470) goto L_0234;\n\tgoto L_0227;\nL_0227:\n\tv1198 = v338;\nL_FFFFFFFF:\n\tv1335 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]);\nL_FFFFFFFF:\n\tv1341 = v1375.hits2D;\nL_FFFFFFFF:\n\tv1624 = &v1198 @ stack_-B8_v17 (UnityEngine.Vector3);\n\tgoto L_0243;\nL_0234:\n\tgoto L_0236;\nL_0236:\n\tv1198 = v338;\nL_FFFFFFFF:\n\tv1335 = 0x7F7FFFFF;\nL_FFFFFFFF:\n\tv1341 = v1375.hits2D;\nL_FFFFFFFF:\n\tv1624 = &v1198 @ stack_-B8_v17 (UnityEngine.Vector3);\n\tv1667 = 0 - v1227;\n\tv641 = v1667 * v1667;\nL_FFFFFFFF:\n\tv1946 = 0;\nL_FFFFFFFF:\n\tv1402 = v1361;\nL_FFFFFFFF:\n\tv1861 = 0;\n\tgoto L_02B1;\nL_FFFFFFFF:\n\tv260 = 0;\n\tv1472 = *([v1452 @ X8_v26+18]) == 0;\n\tif (v1472) goto L_04DF;\n\tv1558 = UnityEngine.LayerMask::op_Implicit(*([v73 @ X20_v2 (UnityEngine.Behaviour)+34]));\n\tv1596 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]) < 0;\n\tv1597 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]) == 0;\n\tv1600 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]) == *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]);\n\tv1601 = ~v1600;\n\tv1602 = v1596 == v1601;\n\tv1603 = ~v1602;\n\tv1604 = v1603 | v1597;\n\tif (v1604) goto L_03B4;\n\tgoto L_0280;\nL_0280:\n\tv1198 = v338;\nL_FFFFFFFF:\n\tv1492 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+40]);\nL_FFFFFFFF:\n\tv1501 = v1555.hits;\nL_FFFFFFFF:\n\tv1671 = &v1198 @ stack_-B8_v17 (UnityEngine.Vector3);\n\tgoto L_03C3;\nL_028C:\n\tHighlightPlus.HighlightTrigger::ToggleSelection(this.<>4__this);\nL_FFFFFFFF:\n\tv1854 = 1;\nL_02B1:\n\tv1686 = v1861 * 0x24;\n\tv1687 = v1679.hits2D + v1686;\n\tv1688 = v1687 + 0x20;\n\tv1689 = UnityEngine.RaycastHit2D::get_point(v1688);\n\tgoto L_02C6;\nL_02C8:\n\tv1714 = v1689.y - v335;\n\tv1715 = v1689 - v338;\n\tv1716 = v1715 * v1715;\n\tv1717 = v1714 * v1714;\n\tv1718 = v1716 + v1717;\n\tv1719 = v641 + v1718;\n\tv670 = UnityEngine.Mathf::Sqrt(v1719);\n\tv1729 = v670 < *([v73 @ X20_v2 (UnityEngine.Behaviour)+3C]);\n\tv1737 = ~v1729;\n\tv597 = ~v1737;\n\tif (v597) goto L_FFFFFFFF;\n\tv802 = v670 < v1301;\n\tv787 = v670 == v1301;\n\tv1754 = v670 == v670;\n\tv1755 = v1301 == v1301;\n\tv1756 = v1754 & v1755;\n\tv727 = ~v1756;\n\tgoto L_02E9;\nL_FFFFFFFF:\n\tv727 = 0;\nL_FFFFFFFF:\n\tv787 = 0;\nL_FFFFFFFF:\n\tv802 = 0;\n\tv1901 = v1861 * 0x24;\n\tv1902 = v1845.hits2D + v1901;\n\tv1903 = v1902 + 0x20;\n\tv855 = UnityEngine.RaycastHit2D::get_collider(v1903);\n\tv894 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+70]);\n\tv1866 = *([v894 @ X8_v118+18]) < 1;\n\tif (v1866) goto L_0292;\n\tv572 = *([v894 @ X8_v118+18]) & 0x7FFFFFFF;\nL_FFFFFFFF:\n\tv576 = 0;\n\tgoto L_0323;\nL_0318:\n\tv576 = v576 + 1;\n\tv1959 = v572 == v576;\nL_FFFFFFFF:\n\tv1854 = v1946;\n\tif (v1959) goto L_FFFFFFFF;\nL_0323:\n\t;\n\tv544 = v576 << 3;\n\tv1976 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+70]) + v544;\n\tgoto L_033D;\nL_033D:\n\tv1990 = UnityEngine.Object::op_Equality(*([v1976 @ X8_v122+20]), v855);\n\tv1997 = ~v1990;\n\tif (v1997) goto L_0318;\n\tgoto L_035A;\nL_035A:\n\tv2114 = v1861 * 0x24;\n\tv2115 = v2067.hits2D + v2114;\n\tv2116 = v2115 + 0x20;\n\tv858 = UnityEngine.RaycastHit2D::get_transform(v2116);\n\tv2131 = v1861 * 0x24;\n\tv2132 = v2124.hits2D + v2131;\n\tv2133 = v2132 + 0x20;\n\tv2026 = UnityEngine.RaycastHit2D::get_point(v2133);\n\t// 894 MakeStruct v2017 @ AGG7732770_2_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v2026 @ V0_v42 (UnityEngine.Vector2), v2026.y (System.Single), 0\n\t// 895 MakeStruct v2016 @ AGG7732770_3_v12 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 0\n\tHighlightPlus.HighlightTrigger::UpdateHitPosition(this.<>4__this, v858, v2017, v2016);\n\tv2039 = *([v73 @ X20_v2 (UnityEngine.Behaviour)+4C]) == 0;\n\tv21\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger._003CDoRayCast_003Ed__56::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600012E")]
			[Address(RVA = "0x7732AF4", Offset = "0x7732AF4", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Tooltip("Enables highlight when pointer is over this object.")]
		[Token(Token = "0x400031D")]
		[FieldOffset(Offset = "0x20")]
		public bool highlightOnHover;

		[Tooltip("Used to trigger automatic highlighting including children objects.")]
		[Token(Token = "0x400031E")]
		[FieldOffset(Offset = "0x24")]
		public TriggerMode triggerMode;

		[Token(Token = "0x400031F")]
		[FieldOffset(Offset = "0x28")]
		public Camera raycastCamera;

		[Token(Token = "0x4000320")]
		[FieldOffset(Offset = "0x30")]
		public RayCastSource raycastSource;

		[Token(Token = "0x4000321")]
		[FieldOffset(Offset = "0x34")]
		public LayerMask raycastLayerMask;

		[Tooltip("Objects in this layer mask will block the highlight if they are between the camera and the target.")]
		[Token(Token = "0x4000322")]
		[FieldOffset(Offset = "0x38")]
		public LayerMask blockingLayerMask;

		[Tooltip("Minimum distance for target.")]
		[Token(Token = "0x4000323")]
		[FieldOffset(Offset = "0x3C")]
		public float minDistance;

		[Tooltip("Maximum distance for target. 0 = infinity")]
		[Token(Token = "0x4000324")]
		[FieldOffset(Offset = "0x40")]
		public float maxDistance;

		[Tooltip("Blocks interaction if pointer is over an UI element")]
		[Token(Token = "0x4000325")]
		[FieldOffset(Offset = "0x44")]
		public bool respectUI;

		[Tooltip("Unhighlights the object when the pointer is over a UI element")]
		[Token(Token = "0x4000326")]
		[FieldOffset(Offset = "0x45")]
		public bool unhighlightOnUI;

		[Token(Token = "0x4000327")]
		[FieldOffset(Offset = "0x48")]
		public LayerMask volumeLayerMask;

		[Token(Token = "0x4000328")]
		private const int MAX_RAYCAST_HITS = 100;

		[Tooltip("If the object will be selected by clicking with mouse or tapping on it.")]
		[Token(Token = "0x4000329")]
		[FieldOffset(Offset = "0x4C")]
		public bool selectOnClick;

		[Tooltip("Profile to use when object is selected by clicking on it.")]
		[Token(Token = "0x400032A")]
		[FieldOffset(Offset = "0x50")]
		public HighlightProfile selectedProfile;

		[Tooltip("Profile to use whtn object is selected and highlighted.")]
		[Token(Token = "0x400032B")]
		[FieldOffset(Offset = "0x58")]
		public HighlightProfile selectedAndHighlightedProfile;

		[Tooltip("Automatically deselects any other selected object prior selecting this one")]
		[Token(Token = "0x400032C")]
		[FieldOffset(Offset = "0x60")]
		public bool singleSelection;

		[Tooltip("Toggles selection on/off when clicking object")]
		[Token(Token = "0x400032D")]
		[FieldOffset(Offset = "0x61")]
		public bool toggle;

		[Tooltip("Keeps current selection when clicking outside of any selectable object")]
		[Token(Token = "0x400032E")]
		[FieldOffset(Offset = "0x62")]
		public bool keepSelection;

		[NonSerialized]
		[Token(Token = "0x400032F")]
		[FieldOffset(Offset = "0x68")]
		public Collider[] colliders;

		[NonSerialized]
		[Token(Token = "0x4000330")]
		[FieldOffset(Offset = "0x70")]
		public Collider2D[] colliders2D;

		[Token(Token = "0x4000331")]
		[FieldOffset(Offset = "0x78")]
		private UnityEngine.Object currentCollider;

		[Token(Token = "0x4000332")]
		private static RaycastHit[] hits;

		[Token(Token = "0x4000333")]
		private static RaycastHit2D[] hits2D;

		[Token(Token = "0x4000334")]
		private static RaycastHit blockingHit;

		[Token(Token = "0x4000335")]
		[FieldOffset(Offset = "0x80")]
		private HighlightEffect hb;

		[CompilerGenerated]
		[Token(Token = "0x4000336")]
		[FieldOffset(Offset = "0x88")]
		private OnObjectSelectionEvent OnObjectSelected;

		[CompilerGenerated]
		[Token(Token = "0x4000337")]
		[FieldOffset(Offset = "0x90")]
		private OnObjectSelectionEvent OnObjectUnSelected;

		[CompilerGenerated]
		[Token(Token = "0x4000338")]
		[FieldOffset(Offset = "0x98")]
		private OnObjectHighlightEvent OnObjectHighlightStart;

		[CompilerGenerated]
		[Token(Token = "0x4000339")]
		[FieldOffset(Offset = "0xA0")]
		private OnObjectHighlightEvent OnObjectHighlightStay;

		[CompilerGenerated]
		[Token(Token = "0x400033A")]
		[FieldOffset(Offset = "0xA8")]
		private OnObjectHighlightEvent OnObjectHighlightEnd;

		[CompilerGenerated]
		[Token(Token = "0x400033B")]
		[FieldOffset(Offset = "0xB0")]
		private OnObjectClickEvent OnObjectClicked;

		[Token(Token = "0x400033C")]
		[FieldOffset(Offset = "0xB8")]
		private TriggerMode currentTriggerMode;

		[Token(Token = "0x1700000E")]
		public bool hasColliders
		{
			[Token(Token = "0x6000104")]
			[Address(RVA = "0x772FB38", Offset = "0x772FB38", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.colliders;\n\tv2 = this.colliders == 0;\n\tif (v2) goto L_0011;\n\tv8 = v0.Length == 0;\n\tv13 = ~v8;\n\treturn v13;\nL_0011:\n\treturn 0;\n")]
			get
			{
				Collider[] array = colliders;
				if (colliders != null)
				{
					bool flag = array.Length == 0;
					return !flag;
				}
				return false;
			}
		}

		[Token(Token = "0x1700000F")]
		public bool hasColliders2D
		{
			[Token(Token = "0x6000105")]
			[Address(RVA = "0x772FB58", Offset = "0x772FB58", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.colliders2D;\n\tv2 = this.colliders2D == 0;\n\tif (v2) goto L_0011;\n\tv8 = v0.Length == 0;\n\tv13 = ~v8;\n\treturn v13;\nL_0011:\n\treturn 0;\n")]
			get
			{
				Collider2D[] array = colliders2D;
				if (colliders2D != null)
				{
					bool flag = array.Length == 0;
					return !flag;
				}
				return false;
			}
		}

		[Token(Token = "0x17000010")]
		public HighlightEffect highlightEffect
		{
			[Token(Token = "0x6000106")]
			[Address(RVA = "0x772FB78", Offset = "0x772FB78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.highlightEffect;\n")]
			get
			{
				return hb;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6000107")]
		[Address(RVA = "0x772FB80", Offset = "0x772FB80", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectSelected;\n\tgoto L_002C;\n")]
		public void add_OnObjectSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Combine(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000108")]
		[Address(RVA = "0x772FC24", Offset = "0x772FC24", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectSelected;\n\tgoto L_002C;\n")]
		public void remove_OnObjectSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Remove(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000109")]
		[Address(RVA = "0x772FCC8", Offset = "0x772FCC8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectUnSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectUnSelected;\n\tgoto L_002C;\n")]
		public void add_OnObjectUnSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectUnSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Combine(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectUnSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010A")]
		[Address(RVA = "0x772FD6C", Offset = "0x772FD6C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectUnSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectUnSelected;\n\tgoto L_002C;\n")]
		public void remove_OnObjectUnSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectUnSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Remove(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectUnSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010B")]
		[Address(RVA = "0x772FE10", Offset = "0x772FE10", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStart (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStart;\n\tgoto L_002C;\n")]
		public void add_OnObjectHighlightStart(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStart;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStart, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010C")]
		[Address(RVA = "0x772FEB4", Offset = "0x772FEB4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStart (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStart;\n\tgoto L_002C;\n")]
		public void remove_OnObjectHighlightStart(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStart;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStart, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010D")]
		[Address(RVA = "0x772FF58", Offset = "0x772FF58", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStay (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStay;\n\tgoto L_002C;\n")]
		public void add_OnObjectHighlightStay(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStay;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStay, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010E")]
		[Address(RVA = "0x772FFFC", Offset = "0x772FFFC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStay (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStay;\n\tgoto L_002C;\n")]
		public void remove_OnObjectHighlightStay(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStay;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStay, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600010F")]
		[Address(RVA = "0x77300A0", Offset = "0x77300A0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightEnd (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightEnd;\n\tgoto L_002C;\n")]
		public void add_OnObjectHighlightEnd(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightEnd;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightEnd, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000110")]
		[Address(RVA = "0x7730144", Offset = "0x7730144", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightEnd (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightEnd;\n\tgoto L_002C;\n")]
		public void remove_OnObjectHighlightEnd(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightEnd;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightEnd, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000111")]
		[Address(RVA = "0x77301E8", Offset = "0x77301E8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectClicked (HighlightPlus.OnObjectClickEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectClickEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectClicked;\n\tgoto L_002C;\n")]
		public void add_OnObjectClicked(OnObjectClickEvent value)
		{
			OnObjectClickEvent onObjectClickEvent = OnObjectClicked;
			OnObjectClickEvent onObjectClickEvent2;
			do
			{
				onObjectClickEvent2 = onObjectClickEvent;
				OnObjectClickEvent value2 = (OnObjectClickEvent)Delegate.Combine(onObjectClickEvent2, value);
				onObjectClickEvent = Interlocked.CompareExchange(ref OnObjectClicked, value2, onObjectClickEvent2);
			}
			while ((object)onObjectClickEvent != onObjectClickEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000112")]
		[Address(RVA = "0x773028C", Offset = "0x773028C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectClicked (HighlightPlus.OnObjectClickEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectClickEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectClicked;\n\tgoto L_002C;\n")]
		public void remove_OnObjectClicked(OnObjectClickEvent value)
		{
			OnObjectClickEvent onObjectClickEvent = OnObjectClicked;
			OnObjectClickEvent onObjectClickEvent2;
			do
			{
				onObjectClickEvent2 = onObjectClickEvent;
				OnObjectClickEvent value2 = (OnObjectClickEvent)Delegate.Remove(onObjectClickEvent2, value);
				onObjectClickEvent = Interlocked.CompareExchange(ref OnObjectClicked, value2, onObjectClickEvent2);
			}
			while ((object)onObjectClickEvent != onObjectClickEvent2);
		}

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x6000113")]
		[Address(RVA = "0x7730330", Offset = "0x7730330", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv57 = v43.selectedObjects;\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Clear(v57);\n\tv72 = v57.Count < 1;\n\tif (v72) goto L_004A;\n\treturn;\nL_004A:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DomainReloadDisabledSupport()
		{
			List<HighlightEffect> selectedObjects = HighlightManager.selectedObjects;
			selectedObjects.Clear();
			if (selectedObjects.Count < 1)
			{
			}
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x77303E4", Offset = "0x77303E4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightTrigger::Init(this);\n\treturn;\n")]
		private void OnEnable()
		{
			Init();
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x7730548", Offset = "0x7730548", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.currentTriggerMode != this.triggerMode;\n\tif (v12) goto L_000E;\n\treturn;\nL_000E:\n\tHighlightPlus.HighlightTrigger::UpdateTriggers(this);\n\treturn;\n")]
		private void OnValidate()
		{
			if (currentTriggerMode != triggerMode)
			{
				UpdateTriggers();
			}
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x7730560", Offset = "0x7730560", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv65 = UnityEngine.Component::GetComponentsInChildren(this);\n\tthis.colliders = v65;\n\tv174 = UnityEngine.Component::GetComponentsInChildren(this);\n\tthis.colliders2D = v174;\n\tv186 = v185.hits;\n\tv187 = v185.hits == 0;\n\tif (v187) goto L_005A;\n\tv193 = v186.Length == 0x64;\n\tif (v193) goto L_0064;\nL_005A:\n\t// 90 NewArr v211 @ X0_v44 (UnityEngine.RaycastHit[]), typeof(UnityEngine.RaycastHit[]), 100\n\tv230.hits = v211;\n\tv241 = v227.Length != 0x64;\n\tif (v241) goto L_0081;\n\tgoto L_0078;\nL_0078:\n\tv112 = UnityEngine.Application::get_isPlaying();\n\tv276 = ~v112;\n\tv116 = ~v276;\n\tif (v116) goto L_0094;\n\tgoto L_00C5;\nL_0081:\n\t// 129 NewArr v256 @ X0_v34 (UnityEngine.RaycastHit2D[]), typeof(UnityEngine.RaycastHit2D[]), 100\n\tv263.hits2D = v256;\n\tgoto L_0078;\nL_0094:\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tv114 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv118 = ~v114;\n\tif (v118) goto L_00C5;\n\tgoto L_00A8;\n\tv158 = UnityEngine.MonoBehaviour::StartCoroutine(this, v296);\n\treturn;\nL_00C5:\n\treturn;\nL_0024:\n\tthis.currentTriggerMode = this.triggerMode;\n\tv53 = this.triggerMode != 1;\n\tif (v53) goto L_00C5;\nL_0064:\n\tv227 = v224.hits2D;\n\tv228 = v224.hits2D == 0;\n\tif (v228) goto L_0081;\nL_00A8:\n\tv296 = new HighlightPlus.HighlightTrigger+<DoRayCast>d__56();\n\tSystem.Object::.ctor(v296);\n\tv296.<>1__state = 0;\n\tv296.<>4__this = this;\n")]
		private void UpdateTriggers()
		{
			currentTriggerMode = triggerMode;
			if (triggerMode != TriggerMode.RaycastOnThisObjectAndChildren)
			{
				return;
			}
			Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
			colliders = componentsInChildren;
			Collider2D[] componentsInChildren2 = GetComponentsInChildren<Collider2D>();
			colliders2D = componentsInChildren2;
			RaycastHit[] array = hits;
			if (hits == null || array.Length != 100)
			{
				RaycastHit[] array2 = new RaycastHit[100];
				hits = array2;
			}
			RaycastHit2D[] array3 = hits2D;
			if (hits2D == null || array3.Length != 100)
			{
				RaycastHit2D[] array4 = new RaycastHit2D[100];
				hits2D = array4;
			}
			if (Application.isPlaying)
			{
				StopAllCoroutines();
				if (base.isActiveAndEnabled)
				{
					_003CDoRayCast_003Ed__56 _003CDoRayCast_003Ed__57 = (_003CDoRayCast_003Ed__56)FormatterServices.GetUninitializedObject(typeof(_003CDoRayCast_003Ed__56));
					_003CDoRayCast_003Ed__57._003C_003E1__state = 0;
					_003CDoRayCast_003Ed__57._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(_003CDoRayCast_003Ed__57);
				}
			}
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x77303E8", Offset = "0x77303E8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv85 = this + 0x28;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.raycastCamera, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_003F;\n\tgoto L_0047;\nL_003F:\n\tgoto L_0041;\nL_0041:\n\tv107 = HighlightPlus.HighlightManager::GetCamera();\n\t*([v85 @ X20_v8]) = v107;\nL_0047:\n\tHighlightPlus.HighlightTrigger::UpdateTriggers(this);\n\tgoto L_0052;\nL_0052:\n\tv118 = UnityEngine.Object::op_Equality(this.highlightEffect, 0);\n\tv120 = ~v118;\n\tif (v120) goto L_0075;\n\tv134 = UnityEngine.Component::GetComponent(this);\n\tthis.highlightEffect = v134;\n\treturn;\nL_0075:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Init()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::Init");
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x7730808", Offset = "0x7730808", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0045;\nL_0045:\n\tv83 = UnityEngine.Object::op_Equality(this.raycastCamera, 0);\n\tv91 = ~v83;\n\tv92 = ~v91;\n\tif (v92) goto L_0081;\nL_0050:\n\treturn;\nL_0056:\n\tv76 = UnityEngine.Component::TryGetComponent(this, &v44 @ stack_-38_v1 (UnityEngine.Collider));\n\tv86 = v76 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0050;\n\tv102 = UnityEngine.Component::TryGetComponent(this, &v43 @ stack_-40_v1 (UnityEngine.MeshFilter));\n\tv112 = ~v102;\n\tif (v112) goto L_0050;\n\tv199 = UnityEngine.Component::get_gameObject(this);\n\tv166 = UnityEngine.GameObject::AddComponent(v199);\n\treturn;\nL_0081:\n\tgoto L_0083;\nL_0083:\n\tv196 = HighlightPlus.HighlightManager::GetCamera();\n\tthis.raycastCamera = v196;\n\tgoto L_0092;\nL_0092:\n\tv110 = UnityEngine.Object::op_Equality(this.raycastCamera, 0);\n\tv114 = ~v110;\n\tif (v114) goto L_0050;\n\tv211 = UnityEngine.Component::get_gameObject(this);\n\tv218 = UnityEngine.Object::get_name(v211);\n\tv167 = System.String::Concat(\"Highlight Trigger on \", v218, \": no camera found!\");\n\tgoto L_00B3;\nL_00B3:\n\tUnityEngine.Debug::LogError(v167);\n\treturn;\nL_0029:\n\tv43 = 0;\n\tv44 = 0;\n\tHighlightPlus.HighlightTrigger::UpdateTriggers(this);\n\tv59 = this.triggerMode != 1;\n\tif (v59) goto L_0056;\n")]
		private void Start()
		{
			MeshFilter component = null;
			Collider component2 = null;
			UpdateTriggers();
			if (triggerMode == TriggerMode.RaycastOnThisObjectAndChildren)
			{
				if (raycastCamera == null)
				{
					Camera camera = HighlightManager.GetCamera();
					raycastCamera = camera;
					if (raycastCamera == null)
					{
						GameObject gameObject = base.gameObject;
						string text = gameObject.name;
						string message = "Highlight Trigger on " + text + ": no camera found!";
						Debug.LogError(message);
					}
				}
			}
			else if (!TryGetComponent<Collider>(out component2) && TryGetComponent<MeshFilter>(out component))
			{
				GameObject gameObject2 = base.gameObject;
				MeshCollider meshCollider = gameObject2.AddComponent<MeshCollider>();
			}
		}

		[IteratorStateMachine(typeof(_003CDoRayCast_003Ed__56))]
		[Token(Token = "0x6000119")]
		[Address(RVA = "0x7730790", Offset = "0x7730790", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new HighlightPlus.HighlightTrigger+<DoRayCast>d__56();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator DoRayCast()
		{
			_003CDoRayCast_003Ed__56 _003CDoRayCast_003Ed__57 = (_003CDoRayCast_003Ed__56)FormatterServices.GetUninitializedObject(typeof(_003CDoRayCast_003Ed__56));
			_003CDoRayCast_003Ed__57._003C_003E1__state = 0;
			_003CDoRayCast_003Ed__57._003C_003E4__this = this;
			return _003CDoRayCast_003Ed__57;
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x7730A88", Offset = "0x7730A88", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.highlightEffect, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0031;\n\tgoto L_0054;\nL_0031:\n\tv76 = this.highlightEffect;\n\tv81 = *([v76 @ X0_v3 (UnityEngine.Component)+85]) != 1;\n\tif (v81) goto L_0054;\n\tv115 = this.OnObjectHighlightStay == 0;\n\tif (v115) goto L_0054;\n\tv158 = UnityEngine.Component::get_gameObject(v76);\n\tv112 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightStay, v158);\n\tv160 = v112 & 1;\n\tv114 = v160 == 0;\n\tif (v114) goto L_005E;\nL_0054:\n\treturn;\nL_005E:\n\tHighlightPlus.HighlightTrigger::SwitchCollider(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void VerifyHighlightStay()
		{
			//IL_00af: Expected O, but got I4
			if (highlightEffect == null)
			{
				return;
			}
			Component component = highlightEffect;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v3 (UnityEngine.Component)+85]");
			if ((nint)0 == 1 && OnObjectHighlightStay != null)
			{
				GameObject obj = component.gameObject;
				object obj2 = OnObjectHighlightStay(obj);
				if ((int)((nint)obj2 & 1) == 0)
				{
					SwitchCollider(null);
				}
			}
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x7730B7C", Offset = "0x7730B7C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv50 = this.highlightEffect;\n\tv53 = v50.isSelected != 1;\n\tif (v53) goto L_004E;\nL_002E:\n\tthis.currentCollider = v40;\n\tgoto L_003B;\nL_003B:\n\tv106 = UnityEngine.Object::op_Inequality(this.currentCollider, 0);\n\tHighlightPlus.HighlightTrigger::Highlight(this, v106);\n\treturn;\nL_004E:\n\treturn;\nL_0018:\n\tv48 = this.highlightOnHover == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_002E;\n")]
		private void SwitchCollider(UnityEngine.Object newCollider)
		{
			if (!highlightOnHover)
			{
				HighlightEffect highlightEffect = this.highlightEffect;
				if (!highlightEffect.isSelected)
				{
					return;
				}
			}
			UnityEngine.Object obj = default(UnityEngine.Object);
			currentCollider = obj;
			bool state = currentCollider != null;
			Highlight(state);
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x7730F78", Offset = "0x7730F78", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Input::get_mousePosition();\n\t// 17 MakeStruct v21 @ AGG7730F9C_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v13 @ V0_v1 (UnityEngine.Vector3), v13.y (System.Single)\n\treturnVal1 = HighlightPlus.HighlightTrigger::CanInteractAt(this, v21);\n\treturn returnVal1;\n")]
		private bool CanInteract()
		{
			Vector3 mousePosition = Input.mousePosition;
			Vector2 screenPosition = default(Vector2);
			screenPosition.x = mousePosition.x;
			screenPosition.y = mousePosition.y;
			return CanInteractAt(screenPosition);
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x7730FA0", Offset = "0x7730FA0", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0034;\nL_0034:\n\tv195 = UnityEngine.EventSystems.EventSystem::get_current();\n\tgoto L_003D;\nL_003D:\n\tv167 = UnityEngine.Object::op_Equality(v195, 0);\n\tv171 = v167 == 0;\n\tif (v171) goto L_0063;\n\tgoto L_005D;\nL_005D:\n\treturn 1;\nL_0063:\n\tgoto L_0065;\nL_0065:\n\tv379 = UnityEngine.Application::get_isMobilePlatform();\n\tv381 = ~v379;\n\tv382 = ~v381;\n\tif (v382) goto L_0070;\n\tv439 = v379;\n\tgoto L_00B4;\nL_0070:\n\tv389 = UnityEngine.Input::get_touchCount();\n\tv270 = v389 < 1;\n\tv439 = v389;\n\tif (v270) goto L_00B4;\n\tv452 = UnityEngine.Input::GetTouch(0);\n\tv75 = v452;\n\tv459 = UnityEngine.Touch::get_fingerId(&v75 @ stack_-90_v5 (UnityEngine.Touch));\n\tv168 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v195, v459);\n\tv172 = v168 == 0;\n\tif (v172) goto L_00D7;\n\treturn 0;\nL_00B4:\n\tv402 = this.raycastSource == 0;\n\tif (v402) goto L_00C1;\nL_00BA:\n\tv464 = HighlightPlus.HighlightTrigger::IsUIAtScreenPosition(v439, v195, screenPosition);\n\tgoto L_00C2;\nL_00C1:\n\tv464 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v195, -1);\nL_00C2:\n\treturnVal2 = v464 ^ 1;\n\treturn returnVal2;\nL_00D7:\n\tv139 = this.raycastSource != 1;\n\tif (v139) goto L_005D;\n\tv439 = v168;\n\tgoto L_00BA;\nL_0029:\n\tv59 = this.respectUI != 1;\n\tif (v59) goto L_005D;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CanInteractAt(Vector2 screenPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::CanInteractAt");
			return default;
		}

		[Token(Token = "0x600011E")]
		[Address(RVA = "0x77311B8", Offset = "0x77311B8", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tUnityEngine.EventSystems.PointerEventData::.ctor(v70, es);\n\tv70.<position>k__BackingField.x = screenPosition;\n\tv70.<position>k__BackingField.y = screenPosition.y;\n\tUnityEngine.EventSystems.EventSystem::RaycastAll(es, v70, v60);\n\tv236 = v60.Count < 1;\n\tif (v236) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv292 = 1;\nL_FFFFFFFF:\n\tv322 = 0;\n\tgoto L_0077;\nL_005C:\n\tv322 = v322 + 1;\n\tv368 = v322 - v60.Count;\n\tv369 = v368 < 0;\n\tv371 = v322 ^ v60.Count;\n\tv372 = v322 ^ v368;\n\tv373 = v371 & v372;\n\tv374 = v373 < 0;\n\tv375 = v369 == v374;\n\tv295 = ~v375;\n\tv305 = v60.Count == v322;\nL_FFFFFFFF:\n\tv292 = v295;\nL_FFFFFFFF:\n\tv330 = v295;\n\tif (v305) goto L_00BB;\nL_0077:\n\tv317 = System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::get_Item(v60, v322);\n\tv319 = v317.module == 0;\n\tif (v319) goto L_005C;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v331_asT @ TEMPCOND_v6 (UnityEngine.UI.GraphicRaycaster), typeof(UnityEngine.UI.GraphicRaycaster), v317.module (UnityEngine.EventSystems.BaseRaycaster)\n\tv331 = v331_asT == 0;\n\tif (v331) goto L_005C;\nL_FFFFFFFF:\n\tv330 = v292;\n\tgoto L_00BB;\nL_FFFFFFFF:\n\tv330 = 0;\nL_0031:\n\tv60 = new System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>();\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::.ctor(v60);\n\tv70 = new UnityEngine.EventSystems.PointerEventData();\nL_00BB:\n\treturn v330;\n")]
		private bool IsUIAtScreenPosition(EventSystem es, Vector2 screenPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::IsUIAtScreenPosition");
			return default;
		}

		[Token(Token = "0x600011F")]
		[Address(RVA = "0x7731358", Offset = "0x7731358", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv71 = this.colliders2D;\n\tv72 = this.colliders2D == 0;\n\tif (v72) goto L_0085;\n\tv162 = v71.Length == 0;\n\tif (v162) goto L_0085;\n\tv318 = UnityEngine.LayerMask::op_Implicit(this.blockingLayerMask);\n\tgoto L_004D;\nL_006A:\n\tv198 = UnityEngine.Object::op_Inequality(v328, 0);\n\tv201 = ~v198;\n\tif (v201) goto L_0085;\n\tv339 = UnityEngine.RaycastHit2D::get_distance(&v173 @ stack_-90_v6 (UnityEngine.RaycastHit2D));\n\tgoto L_00A3;\nL_0085:\n\tv213 = UnityEngine.LayerMask::op_Implicit(this.blockingLayerMask);\n\tgoto L_008E;\nL_008E:\n\tv92 = ray.origin;\n\tv148 = UnityEngine.Physics::Raycast(&v92 @ stack_-E0_v4 (UnityEngine.Vector3), &v313.blockingHit (UnityEngine.RaycastHit), maxRayDistance, v213);\n\tv150 = ~v148;\n\tif (v150) goto L_FFFFFFFF;\n\tv339 = UnityEngine.RaycastHit::get_distance(&v329.blockingHit (UnityEngine.RaycastHit));\nL_00A3:\n\treturnVal1 = v339 + 0x3C23D70A;\n\tgoto L_00B4;\nL_FFFFFFFF:\n\treturnVal1 = 0x7F7FFFFF;\nL_002B:\n\tv63 = UnityEngine.LayerMask::op_Implicit(this.blockingLayerMask);\n\tv67 = v63 == 0;\n\tif (v67) goto L_FFFFFFFF;\nL_004D:\n\t// 77 MakeStruct v164 @ AGG7731448_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), ray.origin (UnityEngine.Vector3), ray.m_Origin.y (System.Single)\n\t// 78 MakeStruct v163 @ AGG7731448_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), ray.direction (UnityEngine.Vector3), ray.m_Direction.y (System.Single)\n\tv324 = UnityEngine.Physics2D::Raycast(v164, v163, maxRayDistance, v318);\n\tv173 = v324;\n\tv328 = UnityEngine.RaycastHit2D::get_collider(&v173 @ stack_-90_v6 (UnityEngine.RaycastHit2D));\n\tgoto L_006A;\nL_00B4:\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe float GetBlockingDistance(Ray ray, float maxRayDistance)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::GetBlockingDistance");
			return default;
		}

		[Token(Token = "0x6000120")]
		[Address(RVA = "0x7731580", Offset = "0x7731580", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv14 = ~v13;\n\tif (v14) goto L_0036;\n\tv16 = this.triggerMode == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0036;\n\tv29 = UnityEngine.Input::get_mousePosition();\n\t// 20 MakeStruct v20 @ AGG77315B0_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v29 @ V0_v2 (UnityEngine.Vector3), v29.y (System.Single)\n\tv35 = HighlightPlus.HighlightTrigger::CanInteractAt(this, v20);\n\tv33 = ~v35;\n\tif (v33) goto L_0036;\n\tv48 = this.selectOnClick != 1;\n\tif (v48) goto L_003E;\n\tv98 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv81 = ~v98;\n\tif (v81) goto L_003E;\n\tHighlightPlus.HighlightTrigger::ToggleSelection(this);\n\treturn;\nL_0036:\n\treturn;\nL_003E:\n\tHighlightPlus.HighlightTrigger::Highlight(this, 1);\n\treturn;\n")]
		private void OnMouseDown()
		{
			if (!base.isActiveAndEnabled || triggerMode != TriggerMode.ColliderEventsOnlyOnThisObject)
			{
				return;
			}
			Vector3 mousePosition = Input.mousePosition;
			Vector2 screenPosition = default(Vector2);
			screenPosition.x = mousePosition.x;
			screenPosition.y = mousePosition.y;
			if (CanInteractAt(screenPosition))
			{
				if (selectOnClick && Input.GetMouseButtonDown(0))
				{
					ToggleSelection();
				}
				else
				{
					Highlight(state: true);
				}
			}
		}

		[Token(Token = "0x6000121")]
		[Address(RVA = "0x7731998", Offset = "0x7731998", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv14 = ~v13;\n\tif (v14) goto L_0026;\n\tv16 = this.triggerMode == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0026;\n\tv29 = UnityEngine.Input::get_mousePosition();\n\t// 20 MakeStruct v20 @ AGG77319C8_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v29 @ V0_v2 (UnityEngine.Vector3), v29.y (System.Single)\n\tv35 = HighlightPlus.HighlightTrigger::CanInteractAt(this, v20);\n\tv33 = ~v35;\n\tif (v33) goto L_0026;\n\tHighlightPlus.HighlightTrigger::Highlight(this, 1);\n\treturn;\nL_0026:\n\treturn;\n")]
		private void OnMouseEnter()
		{
			if (base.isActiveAndEnabled && triggerMode == TriggerMode.ColliderEventsOnlyOnThisObject)
			{
				Vector3 mousePosition = Input.mousePosition;
				Vector2 screenPosition = default(Vector2);
				screenPosition.x = mousePosition.x;
				screenPosition.y = mousePosition.y;
				if (CanInteractAt(screenPosition))
				{
					Highlight(state: true);
				}
			}
		}

		[Token(Token = "0x6000122")]
		[Address(RVA = "0x77319F0", Offset = "0x77319F0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv14 = ~v13;\n\tif (v14) goto L_0026;\n\tv16 = this.triggerMode == 0;\n\tv17 = ~v16;\n\tif (v17) goto L_0026;\n\tv29 = UnityEngine.Input::get_mousePosition();\n\t// 20 MakeStruct v20 @ AGG7731A20_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v29 @ V0_v2 (UnityEngine.Vector3), v29.y (System.Single)\n\tv35 = HighlightPlus.HighlightTrigger::CanInteractAt(this, v20);\n\tv33 = ~v35;\n\tif (v33) goto L_0026;\n\tHighlightPlus.HighlightTrigger::Highlight(this, 0);\n\treturn;\nL_0026:\n\treturn;\n")]
		private void OnMouseExit()
		{
			if (base.isActiveAndEnabled && triggerMode == TriggerMode.ColliderEventsOnlyOnThisObject)
			{
				Vector3 mousePosition = Input.mousePosition;
				Vector2 screenPosition = default(Vector2);
				screenPosition.x = mousePosition.x;
				screenPosition.y = mousePosition.y;
				if (CanInteractAt(screenPosition))
				{
					Highlight(state: false);
				}
			}
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0x7731A48", Offset = "0x7731A48", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_0025:\n\tv58 = UnityEngine.Object::op_Equality(this.highlightEffect, 0);\n\tv61 = v58 == 0;\n\tif (v61) goto L_003A;\nL_0030:\n\treturn;\nL_003A:\n\tv111 = this.highlightEffect;\n\tv68 = v111.labelEnabled != 1;\n\tif (v68) goto L_0030;\n\tv220 = UnityEngine.Input::get_mousePosition();\n\tv233 = UnityEngine.Camera::ScreenPointToRay(this.raycastCamera, v220);\n\tgoto L_0064;\nL_0064:\n\tv132 = v233.origin;\n\tv244 = UnityEngine.Physics::Raycast(&v132 @ stack_-90_v2 (UnityEngine.Vector3), &v47 @ stack_-60_v1 (UnityEngine.RaycastHit));\n\tv245 = ~v244;\n\tif (v245) goto L_0079;\n\tv248 = UnityEngine.RaycastHit::get_transform(&v47 @ stack_-60_v1 (UnityEngine.RaycastHit));\n\tv169 = UnityEngine.RaycastHit::get_point(&v47 @ stack_-60_v1 (UnityEngine.RaycastHit));\n\tv166 = v169.y;\n\tv163 = v169.z;\n\tv265 = v248;\n\tgoto L_0089;\nL_0079:\n\tv251 = UnityEngine.Component::get_transform(this);\n\tv225 = UnityEngine.Component::get_transform(this);\n\tv169 = UnityEngine.Transform::get_position(v225);\n\tv166 = v169.y;\n\tv163 = v169.z;\n\tv265 = v251;\nL_001B:\n\tv47 = 0;\n\tgoto L_0025;\nL_0089:\n\t// 137 MakeStruct v119 @ AGG7731BBC_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v169 @ V0_v5 (UnityEngine.Vector3), v166 @ V1_v3 (System.Single), v163 @ V2_v3 (System.Single)\n\t// 138 MakeStruct v116 @ AGG7731BBC_3_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, 0\n\tHighlightPlus.HighlightTrigger::UpdateHitPosition(this, v265, v119, v116);\n\treturn;\n")]
		private unsafe void OnMouseOver()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::OnMouseOver");
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0x7730C3C", Offset = "0x7730C3C", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv49 = v43.highlighted == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0091;\n\tv179 = this.OnObjectHighlightStart == 0;\n\tif (v179) goto L_0091;\n\tgoto L_002C;\nL_002C:\n\tv194 = UnityEngine.Object::op_Inequality(v43.target, 0);\n\tv317 = ~v194;\n\tv200 = ~v317;\n\tif (v200) goto L_0058;\n\tgoto L_0091;\nL_003D:\n\tv53 = v43.highlighted != 1;\n\tif (v53) goto L_0091;\n\tv201 = this.OnObjectHighlightEnd == 0;\n\tif (v201) goto L_0091;\n\tgoto L_004C;\nL_004C:\n\tv195 = UnityEngine.Object::op_Inequality(v43.target, 0);\n\tv321 = ~v195;\n\tv202 = ~v321;\n\tif (v202) goto L_0080;\n\tgoto L_0091;\nL_0058:\n\tv154 = this.highlightEffect;\n\tv127 = UnityEngine.Component::get_gameObject(v154.target);\n\tv197 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightStart, v127);\n\tv372 = v197 & 1;\n\tv373 = v372 == 0;\n\tv204 = ~v373;\n\tif (v204) goto L_0091;\n\tthis.currentCollider = 0;\n\treturn;\nL_0080:\n\tv155 = this.highlightEffect;\n\tv130 = UnityEngine.Component::get_gameObject(v155.target);\n\tv193 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightEnd, v130);\n\tv217 = v131 == 0;\n\tv145 = ~v217;\n\tif (v145) goto L_00A9;\n\tgoto L_0140;\nL_009D:\n\tv309 = v131.isSelected == 0;\n\tif (v309) goto L_00CB;\nL_00A9:\n\tv55 = v131.isSelected != 1;\n\tif (v55) goto L_00C0;\n\tv319 = ~state;\n\tif (v319) goto L_00E8;\n\tgoto L_00B6;\nL_00B6:\n\tv337 = UnityEngine.Object::op_Inequality(this.selectedAndHighlightedProfile, 0);\n\tv340 = ~v337;\n\tif (v340) goto L_00E8;\n\tv391 = this.selectedAndHighlightedProfile;\n\tv364 = this.selectedAndHighlightedProfile == 0;\n\tv147 = ~v364;\n\tif (v147) goto L_00F1;\n\tgoto L_0140;\nL_00C0:\n\tv273 = this.highlightOnHover == 0;\n\tif (v273) goto L_00D6;\nL_00CB:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v131, state);\n\treturn;\nL_00D6:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v131, 0);\n\treturn;\nL_00E8:\n\tgoto L_00EB;\nL_00EB:\n\tv352 = UnityEngine.Object::op_Inequality(this.selectedProfile, 0);\n\tv357 = ~v352;\n\tif (v357) goto L_00FD;\n\tv391 = this.selectedProfile;\nL_00F1:\n\tv389 = this.highlightEffect;\n\tgoto L_011A;\nL_00FD:\n\tv159 = this.highlightEffect;\n\tgoto L_0108;\nL_0108:\n\tv399 = UnityEngine.Object::op_Inequality(v159.previousSettings, 0);\n\tv408 = ~v399;\n\tv406 = ~v408;\n\tif (v406) goto L_0114;\n\tgoto L_011B;\nL_0114:\n\tv389 = this.highlightEffect;\n\tv391 = v389.previousSettings;\nL_011A:\n\tHighlightPlus.HighlightProfile::Load(v391, v389);\nL_011B:\n\tv137 = this.highlightEffect;\n\tv232 = v137.highlighted != 1;\n\tif (v232) goto L_013E;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(v137, 0);\n\treturn;\nL_013E:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v137, 1);\n\treturn;\nL_0140:\n\tthrow System.NullReferenceException;\nL_0015:\n\tv43 = this.highlightEffect;\n\tv44 = ~state;\n\tif (v44) goto L_003D;\nL_0091:\n\tv131 = this.highlightEffect;\n\tv212 = this.selectOnClick == 0;\n\tif (v212) goto L_009D;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Highlight(bool state)
		{
			//IL_01c2: Expected O, but got I4
			//IL_0149: Expected O, but got I4
			HighlightEffect highlightEffect = this.highlightEffect;
			if (state)
			{
				if (!highlightEffect.highlighted && OnObjectHighlightStart != null && highlightEffect.target != null)
				{
					HighlightEffect highlightEffect2 = this.highlightEffect;
					GameObject obj = highlightEffect2.target.gameObject;
					object obj2 = OnObjectHighlightStart(obj);
					if ((int)((nint)obj2 & 1) == 0)
					{
						currentCollider = null;
						return;
					}
				}
			}
			else if (highlightEffect.highlighted && OnObjectHighlightEnd != null && highlightEffect.target != null)
			{
				HighlightEffect highlightEffect3 = this.highlightEffect;
				GameObject obj3 = highlightEffect3.target.gameObject;
				object obj4 = OnObjectHighlightEnd(obj3);
			}
			HighlightEffect highlightEffect4 = this.highlightEffect;
			if (selectOnClick)
			{
				if ((object)highlightEffect4 == null)
				{
					goto IL_0413;
				}
			}
			else if (!highlightEffect4.isSelected)
			{
				goto IL_02d3;
			}
			HighlightProfile previousSettings;
			HighlightEffect highlightEffect6;
			if (highlightEffect4.isSelected)
			{
				if (state && selectedAndHighlightedProfile != null)
				{
					previousSettings = selectedAndHighlightedProfile;
					if ((object)selectedAndHighlightedProfile == null)
					{
						goto IL_0413;
					}
				}
				else
				{
					if (!(selectedProfile != null))
					{
						HighlightEffect highlightEffect5 = this.highlightEffect;
						if (!(highlightEffect5.previousSettings != null))
						{
							goto IL_03c1;
						}
						highlightEffect6 = this.highlightEffect;
						previousSettings = highlightEffect6.previousSettings;
						goto IL_03af;
					}
					previousSettings = selectedProfile;
				}
				highlightEffect6 = this.highlightEffect;
				goto IL_03af;
			}
			if (highlightOnHover)
			{
				goto IL_02d3;
			}
			highlightEffect4.SetHighlighted(state: false);
			return;
			IL_03af:
			previousSettings.Load(highlightEffect6);
			goto IL_03c1;
			IL_02d3:
			highlightEffect4.SetHighlighted(state);
			return;
			IL_0413:
			throw new NullReferenceException();
			IL_03c1:
			HighlightEffect highlightEffect7 = this.highlightEffect;
			if (highlightEffect7.highlighted)
			{
				highlightEffect7.UpdateMaterialProperties();
			}
			else
			{
				highlightEffect7.SetHighlighted(state: true);
			}
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0x7731BD8", Offset = "0x7731BD8", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tgoto L_002B;\nL_002B:\n\tv78 = UnityEngine.Object::op_Equality(this.highlightEffect, 0);\n\tv88 = v78 == 0;\n\tif (v88) goto L_004F;\n\tgoto L_00B1;\nL_004F:\n\tv133 = UnityEngine.Transform::InverseTransformPoint(target, positionWS);\n\tgoto L_007A;\nL_007A:\n\t// 122 MakeStruct v110 @ AGG7731D48_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v133 @ V0_v5 (UnityEngine.Vector3), v133.y (System.Single), v133.z (System.Single)\n\t// 123 MakeStruct v107 @ AGG7731D48_3_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v146.vector3Zero (UnityEngine.Vector3), v146.vector3Zero.y (System.Single), v146.vector3Zero.z (System.Single)\n\tHighlightPlus.HighlightEffect::SetHitPosition(this.highlightEffect, target, v110, v107, normalWS);\n\tv139 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv141 = ~v139;\n\tif (v141) goto L_00B1;\n\tv150 = this.OnObjectClicked;\n\tv142 = this.OnObjectClicked == 0;\n\tif (v142) goto L_00B1;\n\tv302 = UnityEngine.Component::get_gameObject(target);\n\tHighlightPlus.OnObjectClickEvent::Invoke(this.OnObjectClicked, v302, v150.method, v150.invoke_impl);\n\treturn;\nL_00B1:\n\treturn;\n")]
		private void UpdateHitPosition(Transform target, Vector3 positionWS = default(Vector3), Vector3 normalWS = default(Vector3))
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::UpdateHitPosition");
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0x7731604", Offset = "0x7731604", Length = "0x394")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0xB795000;\n\tv20 = Il2CppMethodInfo & 1;\n\tv21 = v20 == 0;\n\tif (v21) goto L_0038;\n\tv23 = UnityEngine.Time::get_frameCount();\nL_FFFFFFFF:\n\tv55 = v23;\n\tgoto L_0018;\nL_0018:\n\tv57.lastTriggerFrame = v55;\n\tv63 = this.toggle == 1;\n\tif (v63) goto L_0051;\n\tgoto L_0068;\nL_0038:\n\t*([v16 @ X20_v1+232]) = 1;\n\tv348 = UnityEngine.Time::get_frameCount();\nL_FFFFFFFF:\n\tv55 = v348;\n\tgoto L_0018;\nL_0051:\n\tv101 = this.highlightEffect;\n\tv119 = v101.isSelected == 0;\n\tif (v119) goto L_0068;\n\tv256 = this.OnObjectUnSelected == 0;\nL_FFFFFFFF:\n\tv233 = this.OnObjectUnSelected;\n\tif (v256) goto L_0086;\n\tv273 = UnityEngine.Component::get_gameObject(this);\n\tv277 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectUnSelected, v273);\n\tv352 = v277 & 1;\n\tv279 = v352 == 0;\n\tif (v279) goto L_011B;\nL_FFFFFFFF:\n\tv233 = 0;\n\tgoto L_0086;\nL_0068:\n\t;\n\tv124 = this.OnObjectSelected == 0;\n\tif (v124) goto L_0077;\n\tv242 = UnityEngine.Component::get_gameObject(this);\n\tv248 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectSelected, v242);\n\tv261 = v248 & 1;\n\tv250 = v261 == 0;\n\tif (v250) goto L_011B;\nL_0077:\n\tv254 = ~this.singleSelection;\n\tif (v254) goto L_FFFFFFFF;\n\tgoto L_007F;\nL_007F:\n\tHighlightPlus.HighlightManager::DeselectAll();\nL_FFFFFFFF:\n\tv233 = 1;\nL_0086:\n\tHighlightPlus.HighlightEffect::set_isSelected(this.highlightEffect, v233);\n\tv356 = ~v233;\n\tif (v356) goto L_00CC;\n\tgoto L_0098;\nL_0098:\n\tv369 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Contains(v228.selectedObjects, this.highlightEffect);\n\tv374 = v369 == 0;\n\tv375 = ~v374;\nL_FFFFFFFF:\n\t;\n\tif (v375) goto L_00EA;\n\tgoto L_00A5;\n\tgoto L_0145;\nL_00CC:\n\tgoto L_00D7;\nL_00D7:\n\tv372 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Contains(v230.selectedObjects, this.highlightEffect);\n\tv376 = ~v372;\nL_FFFFFFFF:\n\t;\n\tif (v376) goto L_00EA;\n\tgoto L_00E9;\nL_00E9:\n\tv384 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Remove(v231.selectedObjects, this.highlightEffect);\nL_FFFFFFFF:\n\t;\nL_00EA:\n\tv403 = this.highlightEffect;\nL_00F7:\n\tv162 = v403.isSelected != 1;\n\tif (v162) goto L_0108;\n\tgoto L_0102;\nL_0102:\n\tv423 = UnityEngine.Object::op_Equality(v403.previousSettings, 0);\n\tv431 = ~v423;\n\tv432 = ~v431;\nL_FFFFFFFF:\n\t;\n\tif (v432) goto L_0125;\nL_FFFFFFFF:\n\t;\n\tgoto L_0130;\nL_0108:\n\tHighlightPlus.HighlightEffect::RestorePreviousHighlightEffectSettings(v403);\n\tHighlightPlus.HighlightTrigger::Highlight(this, 1);\n\treturn;\nL_011B:\n\treturn;\nL_0125:\n\tv234 = this.highlightEffect;\n\tv200 = UnityEngine.ScriptableObject::CreateInstance();\n\tv234.previousSettings = v200;\nL_0130:\n\tv155 = this.highlightEffect;\n\tHighlightPlus.HighlightProfile::Save(v155.previousSettings, this.highlightEffect);\n\tHighlightPlus.HighlightTrigger::Highlight(this, 1);\n\treturn;\nL_0145:\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Add(v197, this.highlightEffect);\n\tv403 = this.highlightEffect;\n\tv438 = this.highlightEffect == 0;\n\tv208 = ~v438;\nL_FFFFFFFF:\n\t;\n\tif (v208) goto L_00F7;\n\tthrow System.NullReferenceException;\nL_00A5:\n\tv197 = v229.selectedObjects;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ToggleSelection()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightTrigger::ToggleSelection");
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x7731DE4", Offset = "0x7731DE4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = this.triggerMode != 2;\n\tif (v25) goto L_0039;\n\tv31 = UnityEngine.LayerMask::op_Implicit(this.volumeLayerMask);\n\tv76 = UnityEngine.Component::get_gameObject(other);\n\tv40 = UnityEngine.GameObject::get_layer(v76);\n\tv44 = v31 >> v40;\n\tv93 = v44 & 1;\n\tv36 = v93 == 0;\n\tif (v36) goto L_0039;\n\tHighlightPlus.HighlightTrigger::Highlight(this, 1);\n\treturn;\nL_0039:\n\treturn;\n")]
		public void OnTriggerEnter(Collider other)
		{
			if (triggerMode == TriggerMode.Volume)
			{
				int num = volumeLayerMask;
				GameObject gameObject = other.gameObject;
				int layer = gameObject.layer;
				int num2 = num >> layer;
				if ((num2 & 1) != 0)
				{
					Highlight(state: true);
				}
			}
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x7731E68", Offset = "0x7731E68", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = this.triggerMode != 2;\n\tif (v25) goto L_0039;\n\tv31 = UnityEngine.LayerMask::op_Implicit(this.volumeLayerMask);\n\tv76 = UnityEngine.Component::get_gameObject(other);\n\tv40 = UnityEngine.GameObject::get_layer(v76);\n\tv44 = v31 >> v40;\n\tv93 = v44 & 1;\n\tv36 = v93 == 0;\n\tif (v36) goto L_0039;\n\tHighlightPlus.HighlightTrigger::Highlight(this, 0);\n\treturn;\nL_0039:\n\treturn;\n")]
		public void OnTriggerExit(Collider other)
		{
			if (triggerMode == TriggerMode.Volume)
			{
				int num = volumeLayerMask;
				GameObject gameObject = other.gameObject;
				int layer = gameObject.layer;
				int num2 = num >> layer;
				if ((num2 & 1) != 0)
				{
					Highlight(state: false);
				}
			}
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x7731EEC", Offset = "0x7731EEC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.highlightOnHover = 1;\n\tthis.triggerMode = 1;\n\tv15 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.raycastLayerMask = v15;\n\tv18 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.blockingLayerMask = v18;\n\tthis.respectUI = 1;\n\tthis.keepSelection = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HighlightTrigger()
		{
			highlightOnHover = true;
			triggerMode = TriggerMode.RaycastOnThisObjectAndChildren;
			LayerMask layerMask = -1;
			raycastLayerMask = layerMask;
			LayerMask layerMask2 = -1;
			blockingLayerMask = layerMask2;
			respectUI = true;
			keepSelection = true;
		}
	}
}
