using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace AlmostEngine.Screenshot.Extra
{
	[RequireComponent(typeof(Button))]
	[Token(Token = "0x2000070")]
	public class TakeScreenshotButton : MonoBehaviour
	{
		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x20")]
		private Button m_Button;

		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x28")]
		private ScreenshotManager m_ScreenshotManager;

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x3C4B2A0", Offset = "0x3C4B2A0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\nL_002D:\n\tv59 = UnityEngine.Object::FindObjectOfType();\n\tthis.m_ScreenshotManager = v59;\n\tv72 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Button = v72;\n\tv80 = this.m_Button;\n\tv88 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v88, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v80.onClick, v88);\n\treturn;\nL_002A:\n\tgoto L_002D;\n")]
		private void Start()
		{
			ScreenshotManager screenshotManager = Object.FindObjectOfType<ScreenshotManager>();
			m_ScreenshotManager = screenshotManager;
			Button component = GetComponent<Button>();
			m_Button = component;
			Button button = m_Button;
			UnityAction call = OnClickCallback;
			button.onClick.AddListener(call);
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0x3C4B3C0", Offset = "0x3C4B3C0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0017;\nL_0017:\n\tv54 = UnityEngine.Object::op_Implicit(this.m_ScreenshotManager);\n\tv62 = ~v54;\n\tif (v62) goto L_0040;\n\tAlmostEngine.Screenshot.ScreenshotManager::Capture(this.m_ScreenshotManager);\n\treturn;\nL_0040:\n\treturn;\n")]
		private void OnClickCallback()
		{
			if ((bool)m_ScreenshotManager)
			{
				m_ScreenshotManager.Capture();
			}
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x3C4B470", Offset = "0x3C4B470", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TakeScreenshotButton()
		{
		}
	}
}
