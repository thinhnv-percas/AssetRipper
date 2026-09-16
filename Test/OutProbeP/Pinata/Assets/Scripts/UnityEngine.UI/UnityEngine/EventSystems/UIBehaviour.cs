using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000071")]
	public abstract class UIBehaviour : MonoBehaviour
	{
		[Token(Token = "0x6000607")]
		[Address(RVA = "0xC4BE34", Offset = "0xC4BE34", Length = "0x4")]
		protected virtual void Awake()
		{
		}

		[Token(Token = "0x6000608")]
		[Address(RVA = "0xC41340", Offset = "0xC41340", Length = "0x4")]
		protected virtual void OnEnable()
		{
		}

		[Token(Token = "0x6000609")]
		[Address(RVA = "0xC4BE38", Offset = "0xC4BE38", Length = "0x4")]
		protected virtual void Start()
		{
		}

		[Token(Token = "0x600060A")]
		[Address(RVA = "0xC414AC", Offset = "0xC414AC", Length = "0x4")]
		protected virtual void OnDisable()
		{
		}

		[Token(Token = "0x600060B")]
		[Address(RVA = "0xC4BE3C", Offset = "0xC4BE3C", Length = "0x4")]
		protected virtual void OnDestroy()
		{
		}

		[Token(Token = "0x600060C")]
		[Address(RVA = "0xC4BE40", Offset = "0xC4BE40", Length = "0x8")]
		public virtual bool IsActive()
		{
			return false;
		}

		[Token(Token = "0x600060D")]
		[Address(RVA = "0xC4BE48", Offset = "0xC4BE48", Length = "0x4")]
		protected virtual void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x600060E")]
		[Address(RVA = "0xC4BE4C", Offset = "0xC4BE4C", Length = "0x4")]
		protected virtual void OnBeforeTransformParentChanged()
		{
		}

		[Token(Token = "0x600060F")]
		[Address(RVA = "0xC42684", Offset = "0xC42684", Length = "0x4")]
		protected virtual void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x6000610")]
		[Address(RVA = "0xC4BE50", Offset = "0xC4BE50", Length = "0x4")]
		protected virtual void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000611")]
		[Address(RVA = "0xC4BE54", Offset = "0xC4BE54", Length = "0x4")]
		protected virtual void OnCanvasGroupChanged()
		{
		}

		[Token(Token = "0x6000612")]
		[Address(RVA = "0xC42678", Offset = "0xC42678", Length = "0x4")]
		protected virtual void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x6000613")]
		[Address(RVA = "0xC4BE58", Offset = "0xC4BE58", Length = "0x6C")]
		public bool IsDestroyed()
		{
			return false;
		}

		[Token(Token = "0x6000614")]
		[Address(RVA = "0xC4109C", Offset = "0xC4109C", Length = "0x8")]
		protected internal UIBehaviour()
		{
		}
	}
}
