using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x200001A")]
	public class RectTransformProgressView : ProgressView
	{
		[SerializeField]
		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_fillRect;

		[SerializeField]
		[Range(0f, 1f)]
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x28")]
		private float m_progress;

		[Token(Token = "0x17000008")]
		public override float Progress
		{
			[Token(Token = "0x600005F")]
			[Address(RVA = "0x81C26E8", Offset = "0x81C26E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Progress;\n")]
			get
			{
				return m_progress;
			}
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x81C26F0", Offset = "0x81C26F0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponent(this);\n\tthis.m_fillRect = v46;\n\treturn;\n")]
		private void Reset()
		{
			RectTransform component = GetComponent<RectTransform>();
			m_fillRect = component;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x81C2754", Offset = "0x81C2754", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.TextViewSystem.RectTransformProgressView::SetProgress(this, this.Progress);\n\treturn;\n")]
		private void OnValidate()
		{
			SetProgress(Progress);
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x81C2764", Offset = "0x81C2764", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Progress = value;\n\t// 6 MakeStruct v6 @ AGG81C2778_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), value @ V0 (System.Single), 1f\n\tUnityEngine.RectTransform::set_anchorMax(this.m_fillRect, v6);\n\treturn;\n")]
		public override void SetProgress(float value)
		{
			m_progress = value;
			Vector2 anchorMax = default(Vector2);
			anchorMax.x = value;
			anchorMax.y = 1f;
			m_fillRect.anchorMax = anchorMax;
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x81C2788", Offset = "0x81C2788", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public RectTransformProgressView()
		{
		}
	}
}
