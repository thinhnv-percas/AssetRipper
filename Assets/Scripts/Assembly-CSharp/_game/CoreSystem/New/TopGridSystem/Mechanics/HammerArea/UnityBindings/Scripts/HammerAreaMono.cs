using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts
{
	[Token(Token = "0x2000205")]
	public class HammerAreaMono : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000666")]
		[FieldOffset(Offset = "0x20")]
		internal TextMeshPro m_counterText;

		[Token(Token = "0x4000667")]
		[FieldOffset(Offset = "0x28")]
		private readonly List<GameObject> _indicators;

		[Token(Token = "0x4000668")]
		[FieldOffset(Offset = "0x30")]
		private bool _collected;

		[Token(Token = "0x600091C")]
		[Address(RVA = "0x3E8D45C", Offset = "0x3E8D45C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = count;\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this.m_counterText, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_003C;\n\treturn;\nL_003C:\n\tv92 = System.Int32::ToString(&v16 @ stack_-34_v1 (System.Int32));\n\tv107 = TMPro.TMP_Text::set_text(this.m_counterText, v92);\n\treturn;\n")]
		public void SetCounter(int count)
		{
			int num = count;
			if (!(m_counterText == null))
			{
				string text = num.ToString();
				m_counterText.text = text;
			}
		}

		[Token(Token = "0x600091D")]
		[Address(RVA = "0x3E8D544", Offset = "0x3E8D544", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv59 = v56.Count == 0;\n\tif (v59) goto L_0123;\n\tv139 = max < 1;\n\tif (v139) goto L_005F;\n\tv222 = current / max;\n\tgoto L_003C;\nL_003C:\n\tv279 = v222 * v56.Count;\n\tgoto L_0044;\nL_0044:\n\tv291 = 0x8BF6AF4(&v289 @ stack_-58_v9 (System.Double), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v279, max, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv300 = v279 < 0;\n\tv304 = v279 == v279;\n\tv305 = ~v304;\n\tv306 = v300 == v305;\n\tif (v306) goto L_0095;\n\tv347 = v279 == -0.5d;\n\tv354 = ~v347;\n\tif (v354) goto L_00AE;\nL_FFFFFFFF:\n\tv395 = -1d;\nL_FFFFFFFF:\n\tv161 = v289;\nL_FFFFFFFF:\n\tv406 = v289;\n\tgoto L_00A1;\nL_005F:\n\tv232 = current < 0;\n\tv233 = current == 0;\n\tv235 = current ^ current;\n\tv236 = current & v235;\n\tv237 = v236 < 0;\n\tv238 = v232 == v237;\n\tv151 = ~v233;\n\tv239 = v238 & v151;\n\tv148 = ~v239;\n\tif (v148) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv125 = v56.Count;\n\tgoto L_0077;\nL_FFFFFFFF:\n\tv125 = 0;\n\tgoto L_0123;\nL_0095:\n\tv370 = v279 == 0.5d;\n\tv377 = ~v370;\n\tif (v377) goto L_00B1;\nL_FFFFFFFF:\n\tv395 = 1d;\nL_FFFFFFFF:\n\tv161 = v289;\nL_FFFFFFFF:\n\tv406 = v289;\n\tgoto L_00AD;\nL_FFFFFFFF:\n\tv161 = v407;\nL_00AE:\n\tv385 = v279 + -0.5d;\n\tv161 = System.Math::Ceiling(v385);\n\tgoto L_00B7;\nL_00B1:\n\tv390 = v279 + 0.5d;\n\tv161 = System.Math::Floor(v390);\nL_00B7:\n\tv428 = v161 == 0x7FF0000000000000;\n\tv436 = ~v428;\n\tif (v436) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv203 = 0xFFFFFFFF80000000;\n\tgoto L_00C7;\nL_FFFFFFFF:\n\tv203 = v161;\nL_FFFFFFFF:\n\tv146 = v203;\n\tgoto L_00D9;\nL_FFFFFFFF:\n\tv146 = v56.Count;\nL_FFFFFFFF:\n\tv125 = 0;\n\tgoto L_00F1;\nL_FFFFFFFF:\n\tv125 = v146;\nL_FFFFFFFF:\n\tv127 = 0;\nL_00FB:\n\tv117 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(this._indicators, v127);\n\tv443 = v127 - v125;\n\tv444 = v443 < 0;\n\tv446 = v127 ^ v125;\n\tv447 = v127 ^ v443;\n\tv448 = v446 & v447;\n\tv449 = v448 < 0;\n\tv450 = v444 == v449;\n\tv451 = ~v450;\n\tUnityEngine.GameObject::SetActive(v117, v451);\n\tv127 = v127 + 1;\n\tv163 = v56.Count != v127;\n\tif (v163) goto L_00FB;\nL_0123:\n\treturn;\nL_001E:\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.UnityBindings.Scripts.HammerAreaMono::CollectIndicators(this);\n\tv56 = this._indicators;\nL_00A1:\n\tv407 = v161 + v395;\n\tv408 = v406 & 1;\n\tv410 = v408 == 0;\n\tv413 = ~v410;\n\tif (v413) goto L_FFFFFFFF;\nL_0077:\n\tv164 = v56.Count >= 1;\n\tif (v164) goto L_FFFFFFFF;\nL_00AD:\n\tgoto L_00B7;\nL_00C7:\n\tv454 = v203 - v56.Count;\n\tv455 = v454 < 0;\n\tv457 = v203 ^ v56.Count;\n\tv458 = v203 ^ v454;\n\tv459 = v457 & v458;\n\tv460 = v459 < 0;\n\tv461 = v455 == v460;\n\tv462 = ~v461;\n\tv463 = ~v462;\n\tif (v463) goto L_FFFFFFFF;\nL_00D9:\n\tv470 = v203 < 0;\n\tv473 = v203 ^ v203;\n\tv474 = v203 & v473;\n\tv475 = v474 < 0;\n\tv476 = v470 == v475;\n\tv477 = ~v476;\n\tv149 = ~v477;\n\tif (v149) goto L_FFFFFFFF;\nL_00F1:\n\tv165 = v56.Count < 1;\n\tif (v165) goto L_0123;\n")]
		public void SetFill(int current, int max)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaMono::SetFill");
		}

		[Token(Token = "0x600091E")]
		[Address(RVA = "0x3E8D740", Offset = "0x3E8D740", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv53 = this._indicators;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Clear(v53);\n\tv135 = v53.Count < 1;\n\tif (v135) goto L_0038;\nL_0038:\n\tv179 = UnityEngine.Component::get_transform(this);\n\tv180 = UnityEngine.Transform::GetChild(v179, 1);\n\tv228 = UnityEngine.Transform::get_childCount(v180);\n\tv239 = v228 < 2;\n\tif (v239) goto L_009E;\n\tv147 = 1;\n\tgoto L_0067;\nL_0057:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(v143, v182);\n\tv147 = v147 + 1;\n\tv269 = UnityEngine.Transform::get_childCount(v180);\n\tv250 = v147 >= v269;\n\tif (v250) goto L_009E;\nL_0067:\n\tv143 = this._indicators;\n\tv181 = UnityEngine.Transform::GetChild(v180, v147);\n\tv182 = UnityEngine.Component::get_gameObject(v181);\n\tgoto L_0057;\nL_009E:\n\tthis._collected = 1;\nL_001B:\n\tv49 = this._collected == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_00A8;\nL_00A8:\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CollectIndicators()
		{
			if (_collected)
			{
				return;
			}
			List<GameObject> indicators = _indicators;
			indicators.Clear();
			if (indicators.Count >= 1)
			{
			}
			Transform transform = base.transform;
			Transform child = transform.GetChild(1);
			int childCount = child.childCount;
			if (childCount >= 2)
			{
				int num = 1;
				int childCount2;
				do
				{
					List<GameObject> indicators2 = _indicators;
					Transform child2 = child.GetChild(num);
					GameObject item = child2.gameObject;
					indicators2.Add(item);
					num++;
					childCount2 = child.childCount;
				}
				while (num < childCount2);
			}
			_collected = true;
		}

		[Token(Token = "0x600091F")]
		[Address(RVA = "0x3E8D8C4", Offset = "0x3E8D8C4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v48);\n\tthis._indicators = v48;\n")]
		public HammerAreaMono()
		{
			List<GameObject> indicators = new List<GameObject>();
			_indicators = indicators;
		}
	}
}
