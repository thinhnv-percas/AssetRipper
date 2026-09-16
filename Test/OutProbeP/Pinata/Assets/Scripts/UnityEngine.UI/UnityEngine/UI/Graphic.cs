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
	[DisallowMultipleComponent]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727034", Offset = "0x727034")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727034", Offset = "0x727034")]
	[ExecuteAlways]
	[Token(Token = "0x2000011")]
	public abstract class Graphic : UIBehaviour, ICanvasElement
	{
		[Token(Token = "0x400004A")]
		protected static Material s_DefaultUI;

		[Token(Token = "0x400004B")]
		protected static Texture2D s_WhiteTexture;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728784", Offset = "0x728784")]
		[SerializeField]
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x18")]
		protected Material m_Material;

		[SerializeField]
		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x20")]
		private Color m_Color;

		[NonSerialized]
		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x30")]
		protected bool m_SkipLayoutUpdate;

		[NonSerialized]
		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x31")]
		protected bool m_SkipMaterialUpdate;

		[SerializeField]
		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x32")]
		private bool m_RaycastTarget;

		[NonSerialized]
		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x38")]
		private RectTransform m_RectTransform;

		[NonSerialized]
		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x40")]
		private CanvasRenderer m_CanvasRenderer;

		[NonSerialized]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x48")]
		private Canvas m_Canvas;

		[NonSerialized]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x50")]
		private bool m_VertsDirty;

		[NonSerialized]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x51")]
		private bool m_MaterialDirty;

		[NonSerialized]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x58")]
		protected UnityAction m_OnDirtyLayoutCallback;

		[NonSerialized]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x60")]
		protected UnityAction m_OnDirtyVertsCallback;

		[NonSerialized]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x68")]
		protected UnityAction m_OnDirtyMaterialCallback;

		[NonSerialized]
		[Token(Token = "0x4000059")]
		protected static Mesh s_Mesh;

		[NonSerialized]
		[Token(Token = "0x400005A")]
		private static readonly VertexHelper s_VertexHelper;

		[NonSerialized]
		[Token(Token = "0x400005B")]
		[FieldOffset(Offset = "0x70")]
		protected Mesh m_CachedMesh;

		[NonSerialized]
		[Token(Token = "0x400005C")]
		[FieldOffset(Offset = "0x78")]
		protected Vector2[] m_CachedUvs;

		[NonSerialized]
		[Token(Token = "0x400005D")]
		[FieldOffset(Offset = "0x80")]
		private readonly TweenRunner<ColorTween> m_ColorTweenRunner;

		[Token(Token = "0x1700002B")]
		public static Material defaultGraphicMaterial
		{
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0xF451D4", Offset = "0xF451D4", Length = "0xF8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700002C")]
		public virtual Color color
		{
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0xF452CC", Offset = "0xF452CC", Length = "0xC")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60000B4")]
			[Address(RVA = "0xF452D8", Offset = "0xF452D8", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x1700002D")]
		public virtual bool raycastTarget
		{
			[Token(Token = "0x60000B5")]
			[Address(RVA = "0xF45320", Offset = "0xF45320", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000B6")]
			[Address(RVA = "0xF45328", Offset = "0xF45328", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700002E")]
		[field: Token(Token = "0x400005E")]
		[field: FieldOffset(Offset = "0x88")]
		protected bool useLegacyMeshGeneration
		{
			[Token(Token = "0x60000B7")]
			[Address(RVA = "0xF45334", Offset = "0xF45334", Length = "0x8")]
			get;
			[Token(Token = "0x60000B8")]
			[Address(RVA = "0xF4533C", Offset = "0xF4533C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x1700002F")]
		public int depth
		{
			[Token(Token = "0x60000C1")]
			[Address(RVA = "0xF45D98", Offset = "0xF45D98", Length = "0x20")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000030")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x60000C2")]
			[Address(RVA = "0xF45514", Offset = "0xF45514", Length = "0x60")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000031")]
		public Canvas canvas
		{
			[Token(Token = "0x60000C3")]
			[Address(RVA = "0xF45828", Offset = "0xF45828", Length = "0x84")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000032")]
		public CanvasRenderer canvasRenderer
		{
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0xF45DB8", Offset = "0xF45DB8", Length = "0x60")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000033")]
		public virtual Material defaultMaterial
		{
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0xF45E18", Offset = "0xF45E18", Length = "0x5C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000034")]
		public virtual Material material
		{
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0xF45E74", Offset = "0xF45E74", Length = "0x98")]
			get
			{
				return null;
			}
			[Token(Token = "0x60000C8")]
			[Address(RVA = "0xF45F0C", Offset = "0xF45F0C", Length = "0xA8")]
			set
			{
			}
		}

		[Token(Token = "0x17000035")]
		public virtual Material materialForRendering
		{
			[Token(Token = "0x60000C9")]
			[Address(RVA = "0xF45FB4", Offset = "0xF45FB4", Length = "0x204")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000036")]
		public virtual Texture mainTexture
		{
			[Token(Token = "0x60000CA")]
			[Address(RVA = "0xF461B8", Offset = "0xF461B8", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000037")]
		protected static Mesh workerMesh
		{
			[Token(Token = "0x60000D7")]
			[Address(RVA = "0xF47060", Offset = "0xF47060", Length = "0x144")]
			get
			{
				return null;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60000EB")]
			[Address(RVA = "0xF481C0", Offset = "0xF481C0", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0xF45348", Offset = "0xF45348", Length = "0xB0")]
		protected internal Graphic()
		{
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0xF453F8", Offset = "0xF453F8", Length = "0x74")]
		public virtual void SetAllDirty()
		{
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0xF4546C", Offset = "0xF4546C", Length = "0xA8")]
		public virtual void SetLayoutDirty()
		{
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0xF45574", Offset = "0xF45574", Length = "0xA0")]
		public virtual void SetVerticesDirty()
		{
		}

		[Token(Token = "0x60000BD")]
		[Address(RVA = "0xF45614", Offset = "0xF45614", Length = "0xA0")]
		public virtual void SetMaterialDirty()
		{
		}

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0xF456B4", Offset = "0xF456B4", Length = "0xC0")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0xF45774", Offset = "0xF45774", Length = "0xB4")]
		protected override void OnBeforeTransformParentChanged()
		{
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0xF459F4", Offset = "0xF459F4", Length = "0xC4")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0xF45AB8", Offset = "0xF45AB8", Length = "0x15C")]
		private void CacheCanvas()
		{
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0xF46220", Offset = "0xF46220", Length = "0x140")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0xF46360", Offset = "0xF46360", Length = "0x148")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0xF464A8", Offset = "0xF464A8", Length = "0xB0")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xF46558", Offset = "0xF46558", Length = "0x124")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xF4667C", Offset = "0xF4667C", Length = "0xA0")]
		public virtual void OnCullingChanged()
		{
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xF4671C", Offset = "0xF4671C", Length = "0xF4")]
		public virtual void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xF46810", Offset = "0xF46810", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xF46814", Offset = "0xF46814", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xF46818", Offset = "0xF46818", Length = "0xC4")]
		protected virtual void UpdateMaterial()
		{
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xF468DC", Offset = "0xF468DC", Length = "0x10")]
		protected virtual void UpdateGeometry()
		{
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xF46C8C", Offset = "0xF46C8C", Length = "0x3D4")]
		private void DoMeshGeneration()
		{
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xF468EC", Offset = "0xF468EC", Length = "0x3A0")]
		private void DoLegacyMeshGeneration()
		{
		}

		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x72A008", Offset = "0x72A008")]
		[Obsolete]
		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xF471A4", Offset = "0xF471A4", Length = "0x4")]
		protected virtual void OnFillVBO(List<UIVertex> vbo)
		{
		}

		[Obsolete]
		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xF471A8", Offset = "0xF471A8", Length = "0xA8")]
		protected virtual void OnPopulateMesh(Mesh m)
		{
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xF47250", Offset = "0xF47250", Length = "0x26C")]
		protected virtual void OnPopulateMesh(VertexHelper vh)
		{
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xF475F4", Offset = "0xF475F4", Length = "0x10")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xF47604", Offset = "0xF47604", Length = "0x4")]
		public virtual void SetNativeSize()
		{
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xF47608", Offset = "0xF47608", Length = "0x3B0")]
		public virtual bool Raycast(Vector2 sp, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xF479B8", Offset = "0xF479B8", Length = "0x14C")]
		public Vector2 PixelAdjustPoint(Vector2 point)
		{
			return default(Vector2);
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xF474BC", Offset = "0xF474BC", Length = "0x138")]
		public Rect GetPixelAdjustedRect()
		{
			return default(Rect);
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xF47B04", Offset = "0xF47B04", Length = "0x1C")]
		public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha)
		{
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xF47B20", Offset = "0xF47B20", Length = "0x24C")]
		public virtual void CrossFadeColor(Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha, bool useRGB)
		{
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xF47D6C", Offset = "0xF47D6C", Length = "0x28")]
		private static Color CreateColorFromAlpha(float alpha)
		{
			return default(Color);
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0xF47D94", Offset = "0xF47D94", Length = "0xA8")]
		public virtual void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale)
		{
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xF47E3C", Offset = "0xF47E3C", Length = "0x80")]
		public void RegisterDirtyLayoutCallback(UnityAction action)
		{
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xF47EBC", Offset = "0xF47EBC", Length = "0x80")]
		public void UnregisterDirtyLayoutCallback(UnityAction action)
		{
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xF47F3C", Offset = "0xF47F3C", Length = "0x80")]
		public void RegisterDirtyVerticesCallback(UnityAction action)
		{
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xF47FBC", Offset = "0xF47FBC", Length = "0x80")]
		public void UnregisterDirtyVerticesCallback(UnityAction action)
		{
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xF4803C", Offset = "0xF4803C", Length = "0x80")]
		public void RegisterDirtyMaterialCallback(UnityAction action)
		{
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xF480BC", Offset = "0xF480BC", Length = "0x80")]
		public void UnregisterDirtyMaterialCallback(UnityAction action)
		{
		}
	}
}
