using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000C9")]
	public abstract class UIBehaviour : MonoBehaviour
	{
		[Token(Token = "0x600075F")]
		[Address(RVA = "0x184E724", Offset = "0x184E724", Length = "0x4")]
		protected virtual void Awake()
		{
		}

		[Token(Token = "0x6000760")]
		[Address(RVA = "0x183F75C", Offset = "0x183F75C", Length = "0x4")]
		protected virtual void OnEnable()
		{
		}

		[Token(Token = "0x6000761")]
		[Address(RVA = "0x1844E2C", Offset = "0x1844E2C", Length = "0x4")]
		protected virtual void Start()
		{
		}

		[Token(Token = "0x6000762")]
		[Address(RVA = "0x183F764", Offset = "0x183F764", Length = "0x4")]
		protected virtual void OnDisable()
		{
		}

		[Token(Token = "0x6000763")]
		[Address(RVA = "0x184E728", Offset = "0x184E728", Length = "0x4")]
		protected virtual void OnDestroy()
		{
		}

		[Token(Token = "0x6000764")]
		[Address(RVA = "0x184E72C", Offset = "0x184E72C", Length = "0x8")]
		public virtual bool IsActive()
		{
			return false;
		}

		[Token(Token = "0x6000765")]
		[Address(RVA = "0x184E734", Offset = "0x184E734", Length = "0x4")]
		protected virtual void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000766")]
		[Address(RVA = "0x184E738", Offset = "0x184E738", Length = "0x4")]
		protected virtual void OnBeforeTransformParentChanged()
		{
		}

		[Token(Token = "0x6000767")]
		[Address(RVA = "0x184D478", Offset = "0x184D478", Length = "0x4")]
		protected virtual void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x6000768")]
		[Address(RVA = "0x184E73C", Offset = "0x184E73C", Length = "0x4")]
		protected virtual void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000769")]
		[Address(RVA = "0x184E740", Offset = "0x184E740", Length = "0x4")]
		protected virtual void OnCanvasGroupChanged()
		{
		}

		[Token(Token = "0x600076A")]
		[Address(RVA = "0x184D46C", Offset = "0x184D46C", Length = "0x4")]
		protected virtual void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x600076B")]
		[Address(RVA = "0x184E744", Offset = "0x184E744", Length = "0x5C")]
		public bool IsDestroyed()
		{
			return false;
		}

		[Token(Token = "0x600076C")]
		[Address(RVA = "0x1841B00", Offset = "0x1841B00", Length = "0x8")]
		protected internal UIBehaviour()
		{
		}
	}
}
