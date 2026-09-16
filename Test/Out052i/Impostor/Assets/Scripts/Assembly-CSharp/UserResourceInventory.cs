using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000036")]
public class UserResourceInventory<T> : UserResource where T : ItemInventory
{
	[SerializeField]
	[Token(Token = "0x40000CB")]
	[FieldOffset(Offset = "0x0")]
	protected List<T> itemCollections;

	[Token(Token = "0x1700001D")]
	public virtual List<T> CollectionsValue
	{
		[Token(Token = "0x6000164")]
		[Address(RVA = "0x11FA5EC", Offset = "0x11FA5EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.itemCollections;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return CollectionsValue;
		}
	}

	[Token(Token = "0x6000165")]
	[Address(RVA = "0x11FA5F4", Offset = "0x11FA5F4", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v25);\n\tthrow v25;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void AddValue(int idAdd, long valueAdd)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	[Token(Token = "0x6000166")]
	[Address(RVA = "0x11FA628", Offset = "0x11FA628", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v25);\n\tthrow v25;\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override long GetValue(int id)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	[Token(Token = "0x6000167")]
	[Address(RVA = "0x11FA65C", Offset = "0x11FA65C", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v25);\n\tthrow v25;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SetValue(object valueSet)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	[Token(Token = "0x6000168")]
	[Address(RVA = "0x11FA690", Offset = "0x11FA690", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = new System.NotImplementedException();\n\tSystem.NotImplementedException::.ctor(v25);\n\tthrow v25;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override void SubValue(int idSub, long valueSub)
	{
		NotImplementedException ex = new NotImplementedException();
		throw ex;
	}

	[Token(Token = "0x6000169")]
	[Address(RVA = "0x11FA6C4", Offset = "0x11FA6C4", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv17 = v12;\n\tv18 = 0xB348B0(v17, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = v18;\nL_0012:\n\tv37 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tSystem.Collections.Generic.List`1<T>::.ctor(v37);\n\tthis.itemCollections = v37;\n\tUserResource::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UserResourceInventory()
	{
		List<T> list = new List<T>();
		itemCollections = list;
	}
}
