using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x72DD88", Offset = "0x72DD88")]
	[Token(Token = "0x2000007")]
	internal class JSONLazyCreator : JSONNode
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x10")]
		internal JSONNode m_Node;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x18")]
		internal string m_Key;

		[Token(Token = "0x17000016")]
		public override JSONNode Item
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x1573248", Offset = "0x1573248", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F09548]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, aIndex, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202910C]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONLazyCreator();\n\tSystem.Object::.ctor(v42);\n\tv42.m_Node = this;\n\tv42.m_Key = 0;\n\treturn v42;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONLazyCreator jSONLazyCreator = null;
				jSONLazyCreator.m_Node = this;
				jSONLazyCreator.m_Key = null;
				return jSONLazyCreator;
			}
			[Token(Token = "0x600005A")]
			[Address(RVA = "0x15732AC", Offset = "0x15732AC", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EABE60]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aIndex, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202910D]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONArray();\n\tcom.adjust.sdk.JSONArray::.ctor(v45);\n\tv53 = com.adjust.sdk.JSONNode::Add(v45, value);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				JSONArray jSONArray = new JSONArray();
				jSONArray.Add(value);
				Set(jSONArray);
			}
		}

		[Token(Token = "0x17000017")]
		public override JSONNode Item
		{
			[Token(Token = "0x600005B")]
			[Address(RVA = "0x1573338", Offset = "0x1573338", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F07BF8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202910E]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONLazyCreator();\n\tSystem.Object::.ctor(v45);\n\tv45.m_Node = this;\n\tv45.m_Key = aKey;\n\treturn v45;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONLazyCreator jSONLazyCreator = null;
				jSONLazyCreator.m_Node = this;
				jSONLazyCreator.m_Key = aKey;
				return jSONLazyCreator;
			}
			[Token(Token = "0x600005C")]
			[Address(RVA = "0x15733A8", Offset = "0x15733A8", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC0358]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aKey, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202910F]) = v44;\nL_001A:\n\tv48 = new com.adjust.sdk.JSONClass();\n\tcom.adjust.sdk.JSONClass::.ctor(v48);\n\tv57 = com.adjust.sdk.JSONClass::Add(v48, aKey, value);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v48);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				JSONClass jSONClass = new JSONClass();
				jSONClass.Add(aKey, value);
				Set(jSONClass);
			}
		}

		[Token(Token = "0x17000018")]
		public override int AsInt
		{
			[Token(Token = "0x6000065")]
			[Address(RVA = "0x1573644", Offset = "0x1573644", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDBA38]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029114]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v42);\n\tv50 = com.adjust.sdk.JSONNode::set_AsInt(v42, 0);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v42);\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONData jSONData = null;
				jSONData.AsInt = 0;
				Set(jSONData);
				return 0;
			}
			[Token(Token = "0x6000066")]
			[Address(RVA = "0x15736C8", Offset = "0x15736C8", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F06A00]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029115]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v45);\n\tv53 = com.adjust.sdk.JSONNode::set_AsInt(v45, value);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v45);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				JSONData jSONData = null;
				jSONData.AsInt = value;
				Set(jSONData);
			}
		}

		[Token(Token = "0x17000019")]
		public override float AsFloat
		{
			[Token(Token = "0x6000067")]
			[Address(RVA = "0x1573750", Offset = "0x1573750", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EEFCD8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029116]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v42);\n\tv50 = com.adjust.sdk.JSONNode::set_AsFloat(v42, 0f);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v42);\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONData jSONData = null;
				jSONData.AsFloat = 0f;
				Set(jSONData);
				return 0f;
			}
			[Token(Token = "0x6000068")]
			[Address(RVA = "0x15737D4", Offset = "0x15737D4", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED00F8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, value, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029117]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v45);\n\tv53 = com.adjust.sdk.JSONNode::set_AsFloat(v45, value);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v45);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				JSONData jSONData = null;
				jSONData.AsFloat = value;
				Set(jSONData);
			}
		}

		[Token(Token = "0x1700001A")]
		public override double AsDouble
		{
			[Token(Token = "0x6000069")]
			[Address(RVA = "0x157385C", Offset = "0x157385C", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EA69D0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029118]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v42);\n\tv50 = com.adjust.sdk.JSONNode::set_AsDouble(v42, 0d);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v42);\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONData jSONData = null;
				jSONData.AsDouble = 0.0;
				Set(jSONData);
				return 0.0;
			}
			[Token(Token = "0x600006A")]
			[Address(RVA = "0x15738E0", Offset = "0x15738E0", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF0EA0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, value, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029119]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v45);\n\tv53 = com.adjust.sdk.JSONNode::set_AsDouble(v45, value);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v45);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				JSONData jSONData = null;
				jSONData.AsDouble = value;
				Set(jSONData);
			}
		}

		[Token(Token = "0x1700001B")]
		public override bool AsBool
		{
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x1573968", Offset = "0x1573968", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE19A8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202911A]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v42);\n\tv50 = com.adjust.sdk.JSONNode::set_AsBool(v42, 0);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v42);\n\treturn 0;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONData jSONData = null;
				jSONData.AsBool = false;
				Set(jSONData);
				return false;
			}
			[Token(Token = "0x600006C")]
			[Address(RVA = "0x15739EC", Offset = "0x15739EC", Length = "0x88")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF4968]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202911B]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONData();\n\tSystem.Object::.ctor(v45);\n\tv53 = com.adjust.sdk.JSONNode::set_AsBool(v45, value);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v45);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				JSONData jSONData = null;
				jSONData.AsBool = value;
				Set(jSONData);
			}
		}

		[Token(Token = "0x1700001C")]
		public override JSONArray AsArray
		{
			[Token(Token = "0x600006D")]
			[Address(RVA = "0x1573A74", Offset = "0x1573A74", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE1090]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202911C]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONArray();\n\tcom.adjust.sdk.JSONArray::.ctor(v42);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v42);\n\treturn v42;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONArray jSONArray = new JSONArray();
				Set(jSONArray);
				return jSONArray;
			}
		}

		[Token(Token = "0x1700001D")]
		public override JSONClass AsObject
		{
			[Token(Token = "0x600006E")]
			[Address(RVA = "0x1573ADC", Offset = "0x1573ADC", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED3F78]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202911D]) = v38;\nL_0016:\n\tv42 = new com.adjust.sdk.JSONClass();\n\tcom.adjust.sdk.JSONClass::.ctor(v42);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v42);\n\treturn v42;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				JSONClass jSONClass = new JSONClass();
				Set(jSONClass);
				return jSONClass;
			}
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x1570508", Offset = "0x1570508", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_Node = aNode;\n\tthis.m_Key = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONLazyCreator(JSONNode aNode)
		{
			m_Node = aNode;
			m_Key = null;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x157145C", Offset = "0x157145C", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_Node = aNode;\n\tthis.m_Key = aKey;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public JSONLazyCreator(JSONNode aNode, string aKey)
		{
			m_Node = aNode;
			m_Key = aKey;
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x15731E8", Offset = "0x15731E8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.m_Key == 0;\n\tif (v14) goto L_001A;\n\tv22 = com.adjust.sdk.JSONNode::Add(this.m_Node, this.m_Key, aVal);\n\tgoto L_001B;\nL_001A:\n\tv43 = com.adjust.sdk.JSONNode::Add(this.m_Node, aVal);\nL_001B:\n\tthis.m_Node = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Set(JSONNode aVal)
		{
			if (m_Key != null)
			{
				m_Node.Add(m_Key, aVal);
			}
			else
			{
				m_Node.Add(aVal);
			}
			m_Node = null;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x157343C", Offset = "0x157343C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBBB38]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, aItem, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029110]) = v41;\nL_0018:\n\tv45 = new com.adjust.sdk.JSONArray();\n\tcom.adjust.sdk.JSONArray::.ctor(v45);\n\tv53 = com.adjust.sdk.JSONNode::Add(v45, aItem);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Add(JSONNode aItem)
		{
			JSONArray jSONArray = new JSONArray();
			jSONArray.Add(aItem);
			Set(jSONArray);
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x15734C8", Offset = "0x15734C8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EEB170]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, aKey, aItem, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029111]) = v44;\nL_001A:\n\tv48 = new com.adjust.sdk.JSONClass();\n\tcom.adjust.sdk.JSONClass::.ctor(v48);\n\tv57 = com.adjust.sdk.JSONClass::Add(v48, aKey, aItem);\n\tcom.adjust.sdk.JSONLazyCreator::Set(this, v48);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Add(string aKey, JSONNode aItem)
		{
			JSONClass jSONClass = new JSONClass();
			jSONClass.Add(aKey, aItem);
			Set(jSONClass);
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x157355C", Offset = "0x157355C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = b == 0;\n\tv14 = a - b;\n\tv16 = v14 == 0;\n\treturnVal1 = v5 | v16;\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(JSONLazyCreator a, object b)
		{
			//IL_001e: Expected O, but got I
			bool flag = b == null;
			object obj = (long)(IntPtr)a - (long)(IntPtr)b;
			bool flag2 = obj == null;
			return flag || flag2;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x1573574", Offset = "0x1573574", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = b == 0;\n\tv10 = ~v5;\n\tv15 = a - b;\n\tv17 = v15 == 0;\n\tv22 = ~v17;\n\treturnVal1 = v22 & v10;\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(JSONLazyCreator a, object b)
		{
			//IL_0029: Expected O, but got I
			bool flag = b == null;
			bool flag2 = !flag;
			object obj = (long)(IntPtr)a - (long)(IntPtr)b;
			bool flag3 = obj == null;
			bool flag4 = !flag3;
			return flag4 && flag2;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x157358C", Offset = "0x157358C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = obj == 0;\n\tv14 = this - obj;\n\tv16 = v14 == 0;\n\treturnVal1 = v5 | v16;\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_001b: Expected O, but got I
			bool flag = obj == null;
			object obj2 = (long)(IntPtr)this - (long)(IntPtr)obj;
			bool flag2 = obj2 == null;
			return flag || flag2;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x15735A4", Offset = "0x15735A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.Object::GetHashCode(this);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			return ((object)this).GetHashCode();
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x15735B4", Offset = "0x15735B4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EF3AA0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029112]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return "";
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x15735FC", Offset = "0x15735FC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EDC9C8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, aPrefix, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029113]) = v35;\nL_0018:\n\treturn \"\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString(string aPrefix)
		{
			return "";
		}
	}
}
