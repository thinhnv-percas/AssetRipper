using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[RequireComponent(typeof(MeshRenderer))]
	[ExecuteAlways]
	[Token(Token = "0x2000085")]
	public class TMP_SubMesh : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000441")]
		[FieldOffset(Offset = "0x20")]
		private TMP_FontAsset m_fontAsset;

		[SerializeField]
		[Token(Token = "0x4000442")]
		[FieldOffset(Offset = "0x28")]
		private TMP_SpriteAsset m_spriteAsset;

		[SerializeField]
		[Token(Token = "0x4000443")]
		[FieldOffset(Offset = "0x30")]
		private Material m_material;

		[SerializeField]
		[Token(Token = "0x4000444")]
		[FieldOffset(Offset = "0x38")]
		private Material m_sharedMaterial;

		[Token(Token = "0x4000445")]
		[FieldOffset(Offset = "0x40")]
		private Material m_fallbackMaterial;

		[Token(Token = "0x4000446")]
		[FieldOffset(Offset = "0x48")]
		private Material m_fallbackSourceMaterial;

		[SerializeField]
		[Token(Token = "0x4000447")]
		[FieldOffset(Offset = "0x50")]
		private bool m_isDefaultMaterial;

		[SerializeField]
		[Token(Token = "0x4000448")]
		[FieldOffset(Offset = "0x54")]
		private float m_padding;

		[SerializeField]
		[Token(Token = "0x4000449")]
		[FieldOffset(Offset = "0x58")]
		private Renderer m_renderer;

		[Token(Token = "0x400044A")]
		[FieldOffset(Offset = "0x60")]
		private MeshFilter m_meshFilter;

		[Token(Token = "0x400044B")]
		[FieldOffset(Offset = "0x68")]
		private Mesh m_mesh;

		[SerializeField]
		[Token(Token = "0x400044C")]
		[FieldOffset(Offset = "0x70")]
		private TextMeshPro m_TextComponent;

		[NonSerialized]
		[Token(Token = "0x400044D")]
		[FieldOffset(Offset = "0x78")]
		private bool m_isRegisteredForEvents;

		[Token(Token = "0x170000F1")]
		public TMP_FontAsset fontAsset
		{
			[Token(Token = "0x600044E")]
			[Address(RVA = "0x160DAC0", Offset = "0x160DAC0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600044F")]
			[Address(RVA = "0x160DAC8", Offset = "0x160DAC8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000F2")]
		public TMP_SpriteAsset spriteAsset
		{
			[Token(Token = "0x6000450")]
			[Address(RVA = "0x160DAD0", Offset = "0x160DAD0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000451")]
			[Address(RVA = "0x160DAD8", Offset = "0x160DAD8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000F3")]
		public Material material
		{
			[Token(Token = "0x6000452")]
			[Address(RVA = "0x160DAE0", Offset = "0x160DAE0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000453")]
			[Address(RVA = "0x160DC10", Offset = "0x160DC10", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000F4")]
		public Material sharedMaterial
		{
			[Token(Token = "0x6000454")]
			[Address(RVA = "0x160DDAC", Offset = "0x160DDAC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000455")]
			[Address(RVA = "0x160DDB4", Offset = "0x160DDB4", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x170000F5")]
		public Material fallbackMaterial
		{
			[Token(Token = "0x6000456")]
			[Address(RVA = "0x160DDF4", Offset = "0x160DDF4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000457")]
			[Address(RVA = "0x160DDFC", Offset = "0x160DDFC", Length = "0x138")]
			set
			{
			}
		}

		[Token(Token = "0x170000F6")]
		public Material fallbackSourceMaterial
		{
			[Token(Token = "0x6000458")]
			[Address(RVA = "0x160DF34", Offset = "0x160DF34", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000459")]
			[Address(RVA = "0x160DF3C", Offset = "0x160DF3C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000F7")]
		public bool isDefaultMaterial
		{
			[Token(Token = "0x600045A")]
			[Address(RVA = "0x160DF44", Offset = "0x160DF44", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600045B")]
			[Address(RVA = "0x160DF4C", Offset = "0x160DF4C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000F8")]
		public float padding
		{
			[Token(Token = "0x600045C")]
			[Address(RVA = "0x160DF58", Offset = "0x160DF58", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600045D")]
			[Address(RVA = "0x160DF60", Offset = "0x160DF60", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000F9")]
		public Renderer renderer
		{
			[Token(Token = "0x600045E")]
			[Address(RVA = "0x160DF68", Offset = "0x160DF68", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000FA")]
		public MeshFilter meshFilter
		{
			[Token(Token = "0x600045F")]
			[Address(RVA = "0x160DFFC", Offset = "0x160DFFC", Length = "0xFC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000FB")]
		public Mesh mesh
		{
			[Token(Token = "0x6000460")]
			[Address(RVA = "0x160E0F8", Offset = "0x160E0F8", Length = "0xB0")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000461")]
			[Address(RVA = "0x160E1A8", Offset = "0x160E1A8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FC")]
		public TMP_Text textComponent
		{
			[Token(Token = "0x6000462")]
			[Address(RVA = "0x160E1B0", Offset = "0x160E1B0", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000463")]
		[Address(RVA = "0x160E244", Offset = "0x160E244", Length = "0x3C4")]
		public static TMP_SubMesh AddSubTextObject(TextMeshPro textComponent, MaterialReference materialReference)
		{
			return null;
		}

		[Token(Token = "0x6000464")]
		[Address(RVA = "0x160E608", Offset = "0x160E608", Length = "0x12C")]
		private void OnEnable()
		{
		}

		[Token(Token = "0x6000465")]
		[Address(RVA = "0x160E734", Offset = "0x160E734", Length = "0xB4")]
		private void OnDisable()
		{
		}

		[Token(Token = "0x6000466")]
		[Address(RVA = "0x160E7E8", Offset = "0x160E7E8", Length = "0x148")]
		private void OnDestroy()
		{
		}

		[Token(Token = "0x6000467")]
		[Address(RVA = "0x160E930", Offset = "0x160E930", Length = "0x70")]
		public void DestroySelf()
		{
		}

		[Token(Token = "0x6000468")]
		[Address(RVA = "0x160DAE8", Offset = "0x160DAE8", Length = "0x128")]
		private Material GetMaterial(Material mat)
		{
			return null;
		}

		[Token(Token = "0x6000469")]
		[Address(RVA = "0x160E9A0", Offset = "0x160E9A0", Length = "0xC0")]
		private Material CreateMaterialInstance(Material source)
		{
			return null;
		}

		[Token(Token = "0x600046A")]
		[Address(RVA = "0x160EA60", Offset = "0x160EA60", Length = "0xA0")]
		private Material GetSharedMaterial()
		{
			return null;
		}

		[Token(Token = "0x600046B")]
		[Address(RVA = "0x160DDD4", Offset = "0x160DDD4", Length = "0x20")]
		private void SetSharedMaterial(Material mat)
		{
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0x160DC84", Offset = "0x160DC84", Length = "0x74")]
		public float GetPaddingForMaterial()
		{
			return 0f;
		}

		[Token(Token = "0x600046D")]
		[Address(RVA = "0x160EB00", Offset = "0x160EB00", Length = "0x74")]
		public void UpdateMeshPadding(bool isExtraPadding, bool isUsingBold)
		{
		}

		[Token(Token = "0x600046E")]
		[Address(RVA = "0x160DCF8", Offset = "0x160DCF8", Length = "0xB0")]
		public void SetVerticesDirty()
		{
		}

		[Token(Token = "0x600046F")]
		[Address(RVA = "0x160DDA8", Offset = "0x160DDA8", Length = "0x4")]
		public void SetMaterialDirty()
		{
		}

		[Token(Token = "0x6000470")]
		[Address(RVA = "0x160EB74", Offset = "0x160EB74", Length = "0x170")]
		protected void UpdateMaterial()
		{
		}

		[Token(Token = "0x6000471")]
		[Address(RVA = "0x160ECE4", Offset = "0x160ECE4", Length = "0x8")]
		public TMP_SubMesh()
		{
		}
	}
}
