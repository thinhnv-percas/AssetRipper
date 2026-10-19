using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Notifications
{
	[Token(Token = "0x2000025")]
	public abstract class SoDatabase<T, T1> : ScriptableObject where T : Object where T1 : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x0")]
		protected List<T> m_dataList;

		[Token(Token = "0x17000038")]
		public List<T> DataList
		{
			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x6271A00", Offset = "0x6271A00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.DataList;\n")]
			get
			{
				return m_dataList;
			}
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x6271A08", Offset = "0x6271A08", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void FillData()
		{
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x6271A0C", Offset = "0x6271A0C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tv42 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tSystem.Collections.Generic.List`1<T>::.ctor(v42);\n\tthis.DataList = v42;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		protected internal SoDatabase()
		{
			List<T> dataList = new List<T>();
			m_dataList = dataList;
		}
	}
}
