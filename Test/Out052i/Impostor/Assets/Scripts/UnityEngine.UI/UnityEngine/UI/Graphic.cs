using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI.CoroutineTween;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[DisallowMultipleComponent]
	[Token(Token = "0x200001E")]
	public abstract class Graphic : UIBehaviour, ICanvasElement
	{
		[Token(Token = "0x400006D")]
		protected static Material s_DefaultUI;

		[Token(Token = "0x400006E")]
		protected static Texture2D s_WhiteTexture;

		[SerializeField]
		[FormerlySerializedAs("m_Mat")]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x20")]
		protected Material m_Material;

		[SerializeField]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x28")]
		private Color m_Color;

		[NonSerialized]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x38")]
		protected bool m_SkipLayoutUpdate;

		[NonSerialized]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x39")]
		protected bool m_SkipMaterialUpdate;

		[SerializeField]
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x3A")]
		private bool m_RaycastTarget;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x3B")]
		private bool m_RaycastTargetCache;

		[SerializeField]
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x3C")]
		private Vector4 m_RaycastPadding;

		[NonSerialized]
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x50")]
		private RectTransform m_RectTransform;

		[NonSerialized]
		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x58")]
		private CanvasRenderer m_CanvasRenderer;

		[NonSerialized]
		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x60")]
		private Canvas m_Canvas;

		[NonSerialized]
		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x68")]
		private bool m_VertsDirty;

		[NonSerialized]
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x69")]
		private bool m_MaterialDirty;

		[NonSerialized]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x70")]
		protected UnityAction m_OnDirtyLayoutCallback;

		[NonSerialized]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x78")]
		protected UnityAction m_OnDirtyVertsCallback;

		[NonSerialized]
		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x80")]
		protected UnityAction m_OnDirtyMaterialCallback;

		[NonSerialized]
		[Token(Token = "0x400007E")]
		protected static Mesh s_Mesh;

		[NonSerialized]
		[Token(Token = "0x400007F")]
		private static readonly VertexHelper s_VertexHelper;

		[NonSerialized]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x88")]
		protected Mesh m_CachedMesh;

		[NonSerialized]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x90")]
		protected Vector2[] m_CachedUvs;

		[NonSerialized]
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x98")]
		private readonly TweenRunner<ColorTween> m_ColorTweenRunner;

		[Token(Token = "0x17000035")]
		public static Material defaultGraphicMaterial
		{
			[Token(Token = "0x60000E3")]
			[Address(RVA = "0x16CB980", Offset = "0x16CB980", Length = "0xDC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000036")]
		public virtual Color color
		{
			[Token(Token = "0x60000E4")]
			[Address(RVA = "0x16CBA5C", Offset = "0x16CBA5C", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60000E5")]
			[Address(RVA = "0x16CBA68", Offset = "0x16CBA68", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x17000037")]
		public virtual bool raycastTarget
		{
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x16CBAA0", Offset = "0x16CBAA0", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000E7")]
			[Address(RVA = "0x16CBAA8", Offset = "0x16CBAA8", Length = "0xDC")]
			set
			{
			}
		}

		[Token(Token = "0x17000038")]
		public Vector4 raycastPadding
		{
			[Token(Token = "0x60000E8")]
			[Address(RVA = "0x16CBF60", Offset = "0x16CBF60", Length = "0xC")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x60000E9")]
			[Address(RVA = "0x16CBF6C", Offset = "0x16CBF6C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000039")]
		[field: Token(Token = "0x4000083")]
		[field: FieldOffset(Offset = "0xA0")]
		protected bool useLegacyMeshGeneration
		{
			[Token(Token = "0x60000EA")]
			[Address(RVA = "0x16CBF78", Offset = "0x16CBF78", Length = "0x8")]
			get;
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0x16CBF80", Offset = "0x16CBF80", Length = "0xC")]
			set;
		}

		[Token(Token = "0x1700003A")]
		public int depth
		{
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0x16CCAAC", Offset = "0x16CCAAC", Length = "0x1C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700003B")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x60000F6")]
			[Address(RVA = "0x16CC224", Offset = "0x16CC224", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003C")]
		public Canvas canvas
		{
			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x16CBB84", Offset = "0x16CBB84", Length = "0x74")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003D")]
		public CanvasRenderer canvasRenderer
		{
			[Token(Token = "0x60000F9")]
			[Address(RVA = "0x16CCAC8", Offset = "0x16CCAC8", Length = "0x90")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003E")]
		public virtual Material defaultMaterial
		{
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x16CCB58", Offset = "0x16CCB58", Length = "0x4C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700003F")]
		public virtual Material material
		{
			[Token(Token = "0x60000FB")]
			[Address(RVA = "0x16CCBA4", Offset = "0x16CCBA4", Length = "0x88")]
			get
			{
				return null;
			}
			[Token(Token = "0x60000FC")]
			[Address(RVA = "0x16CCC2C", Offset = "0x16CCC2C", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x17000040")]
		public virtual Material materialForRendering
		{
			[Token(Token = "0x60000FD")]
			[Address(RVA = "0x16CCCC4", Offset = "0x16CCCC4", Length = "0x1C4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000041")]
		public virtual Texture mainTexture
		{
			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x16CCE88", Offset = "0x16CCE88", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000042")]
		protected static Mesh workerMesh
		{
			[Token(Token = "0x600010B")]
			[Address(RVA = "0x16CDE58", Offset = "0x16CDE58", Length = "0x120")]
			get
			{
				return null;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x600011F")]
			[Address(RVA = "0x16CEF5C", Offset = "0x16CEF5C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x16CBF8C", Offset = "0x16CBF8C", Length = "0xB0")]
		protected internal Graphic()
		{
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x16CC03C", Offset = "0x16CC03C", Length = "0x70")]
		public virtual void SetAllDirty()
		{
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x16CC184", Offset = "0x16CC184", Length = "0xA0")]
		public virtual void SetLayoutDirty()
		{
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x16CC27C", Offset = "0x16CC27C", Length = "0x94")]
		public virtual void SetVerticesDirty()
		{
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x16CC310", Offset = "0x16CC310", Length = "0x94")]
		public virtual void SetMaterialDirty()
		{
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x16CC0AC", Offset = "0x16CC0AC", Length = "0xD8")]
		public void SetRaycastDirty()
		{
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x16CC3A4", Offset = "0x16CC3A4", Length = "0xAC")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x16CC450", Offset = "0x16CC450", Length = "0xA8")]
		protected override void OnBeforeTransformParentChanged()
		{
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x16CC69C", Offset = "0x16CC69C", Length = "0xB4")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x16CC750", Offset = "0x16CC750", Length = "0x170")]
		private void CacheCanvas()
		{
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x16CCEE0", Offset = "0x16CCEE0", Length = "0x130")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x16CD010", Offset = "0x16CD010", Length = "0x148")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x16CD2D8", Offset = "0x16CD2D8", Length = "0x104")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x16CD3DC", Offset = "0x16CD3DC", Length = "0x138")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x16CD514", Offset = "0x16CD514", Length = "0x8C")]
		public virtual void OnCullingChanged()
		{
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0x16CD5A0", Offset = "0x16CD5A0", Length = "0xE4")]
		public virtual void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x16CD684", Offset = "0x16CD684", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000106")]
		[Address(RVA = "0x16CD688", Offset = "0x16CD688", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000107")]
		[Address(RVA = "0x16CD68C", Offset = "0x16CD68C", Length = "0xB8")]
		protected virtual void UpdateMaterial()
		{
		}

		[Token(Token = "0x6000108")]
		[Address(RVA = "0x16CD744", Offset = "0x16CD744", Length = "0x10")]
		protected virtual void UpdateGeometry()
		{
		}

		[Token(Token = "0x6000109")]
		[Address(RVA = "0x16CDABC", Offset = "0x16CDABC", Length = "0x39C")]
		private void DoMeshGeneration()
		{
		}

		[Token(Token = "0x600010A")]
		[Address(RVA = "0x16CD754", Offset = "0x16CD754", Length = "0x368")]
		private void DoLegacyMeshGeneration()
		{
		}

		[Obsolete("Use OnPopulateMesh instead.", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Token(Token = "0x600010C")]
		[Address(RVA = "0x16CDF78", Offset = "0x16CDF78", Length = "0x4")]
		protected virtual void OnFillVBO(List<UIVertex> vbo)
		{
		}

		[Obsolete("Use OnPopulateMesh(VertexHelper vh) instead.", false)]
		[Token(Token = "0x600010D")]
		[Address(RVA = "0x16CDF7C", Offset = "0x16CDF7C", Length = "0x98")]
		protected virtual void OnPopulateMesh(Mesh m)
		{
		}

		[Token(Token = "0x600010E")]
		[Address(RVA = "0x16CE014", Offset = "0x16CE014", Length = "0x15C")]
		protected virtual void OnPopulateMesh(VertexHelper vh)
		{
		}

		[Token(Token = "0x600010F")]
		[Address(RVA = "0x16CE29C", Offset = "0x16CE29C", Length = "0x10")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000110")]
		[Address(RVA = "0x16CE2AC", Offset = "0x16CE2AC", Length = "0x4")]
		public virtual void SetNativeSize()
		{
		}

		[Token(Token = "0x6000111")]
		[Address(RVA = "0x16CE2B0", Offset = "0x16CE2B0", Length = "0x48C")]
		public virtual bool Raycast(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x6000112")]
		[Address(RVA = "0x16CE73C", Offset = "0x16CE73C", Length = "0x140")]
		public Vector2 PixelAdjustPoint(Vector2 point)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000113")]
		[Address(RVA = "0x16CE170", Offset = "0x16CE170", Length = "0x12C")]
		public Rect GetPixelAdjustedRect()
		{
			return default(Rect);
		}

		[Token(Token = "0x6000114")]
		[Address(RVA = "0x16CE87C", Offset = "0x16CE87C", Length = "0x1C")]
		public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x6000115")]
		[Address(RVA = "0x16CE898", Offset = "0x16CE898", Length = "0x28C")]
		public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB)
		{
		}

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x16CEB24", Offset = "0x16CEB24", Length = "0x14")]
		private static Color CreateColorFromAlpha(float alpha)
		{
			return default(Color);
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x16CEB38", Offset = "0x16CEB38", Length = "0x9C")]
		public virtual void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x16CEBD4", Offset = "0x16CEBD4", Length = "0x80")]
		public void RegisterDirtyLayoutCallback(UnityAction action)
		{
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x16CEC54", Offset = "0x16CEC54", Length = "0x80")]
		public void UnregisterDirtyLayoutCallback(UnityAction action)
		{
		}

		[Token(Token = "0x600011A")]
		[Address(RVA = "0x16CECD4", Offset = "0x16CECD4", Length = "0x80")]
		public void RegisterDirtyVerticesCallback(UnityAction action)
		{
		}

		[Token(Token = "0x600011B")]
		[Address(RVA = "0x16CED54", Offset = "0x16CED54", Length = "0x80")]
		public void UnregisterDirtyVerticesCallback(UnityAction action)
		{
		}

		[Token(Token = "0x600011C")]
		[Address(RVA = "0x16CEDD4", Offset = "0x16CEDD4", Length = "0x80")]
		public void RegisterDirtyMaterialCallback(UnityAction action)
		{
		}

		[Token(Token = "0x600011D")]
		[Address(RVA = "0x16CEE54", Offset = "0x16CEE54", Length = "0x80")]
		public void UnregisterDirtyMaterialCallback(UnityAction action)
		{
		}
	}
}
