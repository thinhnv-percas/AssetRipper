using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.UISystem.UiObject
{
	[Token(Token = "0x2000004")]
	public class IdObject : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private ObjectId m_ObjectId;

		[Token(Token = "0x17000001")]
		public ObjectId ObjectId
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x81BE7A8", Offset = "0x81BE7A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ObjectId;\n")]
			get
			{
				return m_ObjectId;
			}
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81BE7B0", Offset = "0x81BE7B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public IdObject()
		{
		}
	}
}
