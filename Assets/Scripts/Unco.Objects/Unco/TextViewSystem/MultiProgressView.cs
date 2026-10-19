using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x2000015")]
	public class MultiProgressView : ProgressView
	{
		[SerializeField]
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x20")]
		private ProgressView[] m_progressViews;

		[SerializeField]
		[Range(0f, 1f)]
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x28")]
		private float m_progress;

		[Token(Token = "0x17000006")]
		public override float Progress
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x81C1E74", Offset = "0x81C1E74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Progress;\n")]
			get
			{
				return m_progress;
			}
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x81C1E7C", Offset = "0x81C1E7C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv84 = System.Linq.Enumerable::Where(v64, v70);\n\tv88 = System.Linq.Enumerable::ToArray(v84);\n\tthis.m_progressViews = v88;\n\treturn;\nL_0031:\n\tv64 = UnityEngine.Component::GetComponentsInChildren(this, 1);\n\tv70 = new System.Func`2<Unco.TextViewSystem.ProgressView, System.Boolean>();\n\tSystem.Func`2<Unco.TextViewSystem.ProgressView, System.Boolean>::.ctor(v70, this, Il2CppMethodInfo);\n")]
		private void Reset()
		{
			ProgressView[] componentsInChildren = GetComponentsInChildren<ProgressView>(includeInactive: true);
			Func<ProgressView, bool> predicate = (ProgressView x) => x != this;
			IEnumerable<object> source = componentsInChildren.Where((Func<object, bool>)predicate);
			object[] progressViews = source.ToArray();
			m_progressViews = (ProgressView[])progressViews;
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x81C1F7C", Offset = "0x81C1F7C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.TextViewSystem.MultiProgressView::SetProgress(this, this.Progress);\n\treturn;\n")]
		private void OnValidate()
		{
			SetProgress(Progress);
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x81C1F8C", Offset = "0x81C1F8C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Progress = value;\n\tv20 = this.m_progressViews;\n\tv33 = v20.Length < 1;\n\tif (v33) goto L_003D;\n\tv47 = 0;\nL_0025:\n\tv98 = Unco.TextViewSystem.ProgressView::SetProgress(v20[v47 @ X20_v5 (System.Int32)], value);\n\tv47 = v47 + 1;\n\tv110 = v47 < v20.Length;\n\tif (v110) goto L_0025;\nL_003D:\n\treturn;\n")]
		public override void SetProgress(float value)
		{
			m_progress = value;
			ProgressView[] progressViews = m_progressViews;
			if (progressViews.Length >= 1)
			{
				int num = 0;
				do
				{
					progressViews[num].SetProgress(value);
					num++;
				}
				while (num < progressViews.Length);
			}
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x81C2004", Offset = "0x81C2004", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public MultiProgressView()
		{
		}
	}
}
