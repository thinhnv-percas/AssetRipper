using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace AlmostEngine.Screenshot.Extra
{
	[Token(Token = "0x2000060")]
	public class MessageCanvas : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000061")]
		private sealed class _003CDestroyMessageCoroutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000238")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000239")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400023A")]
			[FieldOffset(Offset = "0x20")]
			public MessageCanvas _003C_003E4__this;

			[Token(Token = "0x400023B")]
			[FieldOffset(Offset = "0x28")]
			public GameObject message;

			[Token(Token = "0x1700002F")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001D3")]
				[Address(RVA = "0x3C48E54", Offset = "0x3C48E54", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000030")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001D5")]
				[Address(RVA = "0x3C48E9C", Offset = "0x3C48E9C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D0")]
			[Address(RVA = "0x3C48C70", Offset = "0x3C48C70", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CDestroyMessageCoroutine_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D1")]
			[Address(RVA = "0x3C48D30", Offset = "0x3C48D30", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001D2")]
			[Address(RVA = "0x3C48D34", Offset = "0x3C48D34", Length = "0x120")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv62 = this.<>1__state != 1;\n\tif (v62) goto L_005C;\n\tthis.<>1__state = -1;\n\tv176 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(v48.m_Messages, this.message);\n\tgoto L_0042;\nL_0042:\n\tUnityEngine.Object::DestroyImmediate(this.message);\n\tgoto L_005C;\nL_0045:\n\tthis.<>1__state = -1;\n\tv132 = new UnityEngine.WaitForSeconds();\n\tUnityEngine.WaitForSeconds::.ctor(v132, v48.m_DisplayTime);\n\tthis.<>2__current = v132;\n\tthis.<>1__state = 1;\nL_001D:\n\tv48 = this.<>4__this;\n\tv49 = this.<>1__state == 0;\n\tif (v49) goto L_0045;\nL_005C:\n\tv115 = this.<>1__state == 0;\n\treturn v115;\n")]
			private bool MoveNext()
			{
				MessageCanvas messageCanvas = _003C_003E4__this;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						bool flag = messageCanvas.m_Messages.Remove(message);
						UnityEngine.Object.DestroyImmediate(message);
					}
				}
				else
				{
					_003C_003E1__state = -1;
					WaitForSeconds waitForSeconds = new WaitForSeconds(messageCanvas.m_DisplayTime);
					_003C_003E2__current = waitForSeconds;
					_003C_003E1__state = 1;
				}
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D4")]
			[Address(RVA = "0x3C48E5C", Offset = "0x3C48E5C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0x20")]
		public RectTransform m_MessagePanel;

		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x28")]
		public GameObject m_MessagePrefab;

		[Token(Token = "0x4000236")]
		[FieldOffset(Offset = "0x30")]
		public float m_DisplayTime = 5f;

		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x38")]
		private List<GameObject> m_Messages;

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0x3C48264", Offset = "0x3C48264", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv82 = v80 == 0;\n\tif (v82) goto L_005E;\n\tv94 = *([v80 @ X0_v8 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v94) goto L_0116;\n\tv99.onResolutionExportSuccessDelegate = v80;\n\tv106 = *([v80 @ X0_v8 (System.Delegate)]) == AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v106) goto L_0065;\n\tgoto L_0116;\nL_005E:\n\tv96.onResolutionExportSuccessDelegate = 0;\n\tv198 = System.Delegate::Combine(v242.onResolutionExportSuccessDelegate, v244);\n\tv205 = v198 == 0;\n\tif (v205) goto L_0092;\n\tv114 = *([v198 @ X0_v14 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v114) goto L_0116;\n\tv308.onResolutionExportSuccessDelegate = v198;\n\tv148 = *([v198 @ X0_v14 (System.Delegate)]) == AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v148) goto L_009B;\n\tgoto L_0116;\nL_0092:\n\tv305.onResolutionExportSuccessDelegate = 0;\n\tv200 = System.Delegate::Remove(v326.onResolutionExportFailureDelegate, v328);\n\tv206 = v200 == 0;\n\tif (v206) goto L_00C8;\n\tv115 = *([v200 @ X0_v20 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v115) goto L_0116;\n\tv338.onResolutionExportFailureDelegate = v200;\n\tv150 = *([v200 @ X0_v20 (System.Delegate)]) == AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v150) goto L_00CF;\n\tgoto L_0116;\nL_00C8:\n\tv335.onResolutionExportFailureDelegate = 0;\n\tv202 = System.Delegate::Combine(v346.onResolutionExportFailureDelegate, v348);\n\tv207 = v202 == 0;\n\tif (v207) goto L_0108;\n\tv116 = *([v202 @ X0_v26 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v116) goto L_0116;\n\tv357.onResolutionExportFailureDelegate = v202;\n\tv117 = *([v202 @ X0_v26 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v117) goto L_0116;\n\treturn;\nL_0108:\n\tv354.onResolutionExportFailureDelegate = 0;\n\treturn;\nL_0116:\n\tthrow System.InvalidCastException;\nL_0026:\n\tAlmostEngine.Screenshot.Extra.MessageCanvas::Clear(this);\n\tgoto L_0031;\nL_0031:\n\tv70 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v70, this, Il2CppMethodInfo);\n\tv80 = System.Delegate::Remove(v67.onResolutionExportSuccessDelegate, v70);\nL_0065:\n\tv244 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v244, this, Il2CppMethodInfo);\nL_009B:\n\tv328 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v328, this, Il2CppMethodInfo);\nL_00CF:\n\tv348 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v348, this, Il2CppMethodInfo);\n")]
		private void OnEnable()
		{
			Clear();
			ScreenshotManager.ExportDelegate value = ExportSuccessCallback;
			Delegate obj = Delegate.Remove(ScreenshotManager.onResolutionExportSuccessDelegate, value);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(ScreenshotManager.ExportDelegate))
				{
					ScreenshotManager.onResolutionExportSuccessDelegate = (ScreenshotManager.ExportDelegate)obj;
					if ((object)obj.GetType() == typeof(ScreenshotManager.ExportDelegate))
					{
						goto IL_027b;
					}
				}
				goto IL_0242;
			}
			ScreenshotManager.onResolutionExportSuccessDelegate = null;
			goto IL_027b;
			IL_0291:
			ScreenshotManager.ExportDelegate value2 = ExportFailureCallback;
			Delegate obj2 = Delegate.Remove(ScreenshotManager.onResolutionExportFailureDelegate, value2);
			if ((object)obj2 != null)
			{
				if ((object)obj2.GetType() == typeof(ScreenshotManager.ExportDelegate))
				{
					ScreenshotManager.onResolutionExportFailureDelegate = (ScreenshotManager.ExportDelegate)obj2;
					if ((object)obj2.GetType() == typeof(ScreenshotManager.ExportDelegate))
					{
						goto IL_02a7;
					}
				}
				goto IL_0242;
			}
			ScreenshotManager.onResolutionExportFailureDelegate = null;
			goto IL_02a7;
			IL_02a7:
			ScreenshotManager.ExportDelegate b = ExportFailureCallback;
			Delegate obj3 = Delegate.Combine(ScreenshotManager.onResolutionExportFailureDelegate, b);
			if ((object)obj3 != null)
			{
				if ((object)obj3.GetType() == typeof(ScreenshotManager.ExportDelegate))
				{
					ScreenshotManager.onResolutionExportFailureDelegate = (ScreenshotManager.ExportDelegate)obj3;
					if ((object)obj3.GetType() == typeof(ScreenshotManager.ExportDelegate))
					{
						return;
					}
				}
				goto IL_0242;
			}
			ScreenshotManager.onResolutionExportFailureDelegate = null;
			return;
			IL_0242:
			throw new InvalidCastException();
			IL_027b:
			ScreenshotManager.ExportDelegate b2 = ExportSuccessCallback;
			Delegate obj4 = Delegate.Combine(ScreenshotManager.onResolutionExportSuccessDelegate, b2);
			if ((object)obj4 != null)
			{
				if ((object)obj4.GetType() == typeof(ScreenshotManager.ExportDelegate))
				{
					ScreenshotManager.onResolutionExportSuccessDelegate = (ScreenshotManager.ExportDelegate)obj4;
					if ((object)obj4.GetType() == typeof(ScreenshotManager.ExportDelegate))
					{
						goto IL_0291;
					}
				}
				goto IL_0242;
			}
			ScreenshotManager.onResolutionExportSuccessDelegate = null;
			goto IL_0291;
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0x3C486D0", Offset = "0x3C486D0", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv81 = v79 == 0;\n\tif (v81) goto L_005C;\n\tv93 = *([v79 @ X0_v7 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v93) goto L_00AC;\n\tv98.onResolutionExportSuccessDelegate = v79;\n\tv105 = *([v79 @ X0_v7 (System.Delegate)]) == AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v105) goto L_0065;\n\tgoto L_00AC;\nL_005C:\n\tv95.onResolutionExportSuccessDelegate = 0;\n\tv151 = System.Delegate::Remove(v186.onResolutionExportFailureDelegate, v188);\n\tv154 = v151 == 0;\n\tif (v154) goto L_009E;\n\tv113 = *([v151 @ X0_v13 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v113) goto L_00AC;\n\tv242.onResolutionExportFailureDelegate = v151;\n\tv114 = *([v151 @ X0_v13 (System.Delegate)]) != AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate;\n\tif (v114) goto L_00AC;\n\treturn;\nL_009E:\n\tv239.onResolutionExportFailureDelegate = 0;\n\treturn;\nL_00AC:\n\tthrow System.InvalidCastException;\nL_0029:\n\tgoto L_002F;\nL_0065:\n\tv188 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v188, this, Il2CppMethodInfo);\nL_002F:\n\tv66 = new AlmostEngine.Screenshot.ScreenshotManager+ExportDelegate();\n\tAlmostEngine.Screenshot.ScreenshotManager+ExportDelegate::.ctor(v66, this, Il2CppMethodInfo);\n\tv79 = System.Delegate::Remove(v63.onResolutionExportSuccessDelegate, v66);\n")]
		private void OnDisable()
		{
			ScreenshotManager.ExportDelegate value = ExportSuccessCallback;
			Delegate obj = Delegate.Remove(ScreenshotManager.onResolutionExportSuccessDelegate, value);
			if ((object)obj != null)
			{
				if ((object)obj.GetType() == typeof(ScreenshotManager.ExportDelegate))
				{
					ScreenshotManager.onResolutionExportSuccessDelegate = (ScreenshotManager.ExportDelegate)obj;
					if ((object)obj.GetType() == typeof(ScreenshotManager.ExportDelegate))
					{
						goto IL_0123;
					}
				}
				goto IL_0118;
			}
			ScreenshotManager.onResolutionExportSuccessDelegate = null;
			goto IL_0123;
			IL_0123:
			ScreenshotManager.ExportDelegate value2 = ExportFailureCallback;
			Delegate obj2 = Delegate.Remove(ScreenshotManager.onResolutionExportFailureDelegate, value2);
			if ((object)obj2 != null)
			{
				if ((object)obj2.GetType() == typeof(ScreenshotManager.ExportDelegate))
				{
					ScreenshotManager.onResolutionExportFailureDelegate = (ScreenshotManager.ExportDelegate)obj2;
					if ((object)obj2.GetType() == typeof(ScreenshotManager.ExportDelegate))
					{
						return;
					}
				}
				goto IL_0118;
			}
			ScreenshotManager.onResolutionExportFailureDelegate = null;
			return;
			IL_0118:
			throw new InvalidCastException();
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0x3C48888", Offset = "0x3C48888", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = System.String::Concat(\"Screenshot created : \", resolution.m_FileName);\n\tAlmostEngine.Screenshot.Extra.MessageCanvas::DisplayMessage(this, v49);\n\treturn;\n")]
		public void ExportSuccessCallback(ScreenshotResolution resolution)
		{
			string text = "Screenshot created : " + resolution.m_FileName;
			DisplayMessage(text);
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0x3C48B74", Offset = "0x3C48B74", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = System.String::Concat(\"FAILED to create : \", resolution.m_FileName);\n\tAlmostEngine.Screenshot.Extra.MessageCanvas::DisplayMessage(this, v49);\n\treturn;\n")]
		public void ExportFailureCallback(ScreenshotResolution resolution)
		{
			string text = "FAILED to create : " + resolution.m_FileName;
			DisplayMessage(text);
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0x3C48524", Offset = "0x3C48524", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv73 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(this.m_Messages);\n\tv77 = v73._list;\n\tgoto L_0050;\n\tv144.message = v73.Current;\n\tv98 = UnityEngine.MonoBehaviour::StartCoroutine(this, v144);\n\tgoto L_0042;\nL_0066:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v77 @ stack_-68_v3 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\nL_0072:\n\treturn;\nL_0073:\n\tv74 = new System.NullReferenceException();\n\tgoto L_0080;\nL_0080:\n\tgoto L_008E;\n\tv118 = 0x8BF5BC4(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = 0x8BF5BF4(v118, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v169);\n\tv127 = *([v118 @ X0_v11]) == 0;\n\tif (v127) goto L_0072;\n\tv125 = new System.OutOfMemoryException();\n\tv121 = *([v118 @ X0_v11]);\n\tv74 = v125;\nL_008E:\n\tv132 = 0x31776C4(&v121 @ stack_-78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x8BF0368(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv199 = 0xA1B8(v139, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0026:\n\tUnityEngine.MonoBehaviour::StopAllCoroutines(this);\n\tv60 = this.m_Messages == 0;\n\tif (v60) goto L_0073;\nL_0050:\n\tv144 = new AlmostEngine.Screenshot.Extra.MessageCanvas+<DestroyMessageCoroutine>d__10();\n\tSystem.Object::.ctor(v144);\n\tv144.<>4__this = this;\n\tv144.<>1__state = 0;\nL_0042:\n\tv105 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v77 @ stack_-68_v3 (System.Collections.Generic.List`1<UnityEngine.GameObject>));\n\tv117 = v105 == 0;\n\tif (v117) goto L_0066;\n")]
		private unsafe void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MessageCanvas::Clear");
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0x3C488F8", Offset = "0x3C488F8", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv53 = 0xB2D1000 + 0x110;\n\tgoto L_001C;\nL_001C:\n\tv82 = UnityEngine.Object::Instantiate /* +1 sharing this address */(this.m_MessagePrefab, *([v53 @ X23_v9 (System.Int32)]));\n\tv73 = v82 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_003F;\n\tgoto L_00CD;\nL_003F:\n\tv90 = UnityEngine.GameObject::get_transform(v82);\n\tv117 = UnityEngine.Component::get_transform(this.m_MessagePanel);\n\tUnityEngine.Transform::SetParent(v90, v117);\n\tv120 = UnityEngine.GameObject::get_transform(v82);\n\tgoto L_0069;\nL_0069:\n\t// 105 MakeStruct v100 @ AGG3C48A4C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v135.one (UnityEngine.Vector3), v135.one.y (System.Single), v135.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v120, v100);\n\tv118 = UnityEngine.GameObject::GetComponent(v82);\n\tv229 = UnityEngine.UI.Text::set_text(v118, text);\n\tv119 = this.m_Messages;\n\tgoto L_00A1;\nL_00A1:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::Add(v119, v82);\n\tv272 = 0xB29A000 + 0x600;\n\tgoto L_00B0;\n\t*([v276 @ X0_v17 (System.Object)+28]) = v82;\n\tv191 = UnityEngine.MonoBehaviour::StartCoroutine(this, v276);\n\treturn;\nL_00CD:\n\tthrow System.NullReferenceException;\nL_00B0:\n\tv276 = new *([v272 @ X22_v8 (System.Int32)])();\n\tSystem.Object::.ctor(v276);\n\t*([v276 @ X0_v17 (System.Object)+10]) = 0;\n\t*([v276 @ X0_v17 (System.Object)+20]) = this;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DisplayMessage(string text)
		{
			int num = 187502592 + 272;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4B0134C (UnityEngine.Object::Instantiate, and 1 more at this address)");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				Transform transform = gameObject.transform;
				Transform parent = m_MessagePanel.transform;
				transform.SetParent(parent);
				Transform transform2 = gameObject.transform;
				Vector3 localScale = default(Vector3);
				localScale.x = Vector3.one.x;
				localScale.y = Vector3.one.y;
				localScale.z = Vector3.one.z;
				transform2.localScale = localScale;
				Text component = gameObject.GetComponent<Text>();
				component.text = text;
				List<GameObject> messages = m_Messages;
				messages.Add(gameObject);
				int num2 = 187277312 + 1536;
				object routine = new object();
				_ = 0;
				Coroutine coroutine = StartCoroutine((IEnumerator)routine);
				return;
			}
			throw new NullReferenceException();
		}

		[IteratorStateMachine(typeof(_003CDestroyMessageCoroutine_003Ed__10))]
		[Token(Token = "0x60001CE")]
		[Address(RVA = "0x3C48BE4", Offset = "0x3C48BE4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.message = message;\n\treturn v46;\nL_0018:\n\tv46 = new AlmostEngine.Screenshot.Extra.MessageCanvas+<DestroyMessageCoroutine>d__10();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		private IEnumerator DestroyMessageCoroutine(GameObject message)
		{
			_003CDestroyMessageCoroutine_003Ed__10 _003CDestroyMessageCoroutine_003Ed__11 = (_003CDestroyMessageCoroutine_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CDestroyMessageCoroutine_003Ed__10));
			_003CDestroyMessageCoroutine_003Ed__11._003C_003E1__state = 0;
			_003CDestroyMessageCoroutine_003Ed__11._003C_003E4__this = this;
			_003CDestroyMessageCoroutine_003Ed__11.message = message;
			return _003CDestroyMessageCoroutine_003Ed__11;
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0x3C48C9C", Offset = "0x3C48C9C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tthis.m_DisplayTime = 5f;\n\tv49 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v49);\n\tthis.m_Messages = v49;\n")]
		public MessageCanvas()
		{
			List<GameObject> messages = new List<GameObject>();
			m_Messages = messages;
		}
	}
}
