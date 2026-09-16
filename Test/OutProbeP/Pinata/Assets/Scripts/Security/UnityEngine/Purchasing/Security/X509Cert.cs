using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using LipingShare.LCLib.Asn1Processor;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000003")]
	internal class X509Cert
	{
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724A80", Offset = "0x724A80")]
		[CompilerGenerated]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x10")]
		private string _003CSerialNumber_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724ABC", Offset = "0x724ABC")]
		[CompilerGenerated]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x18")]
		private DateTime _003CValidAfter_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724AF8", Offset = "0x724AF8")]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x20")]
		private DateTime _003CValidBefore_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724B34", Offset = "0x724B34")]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x28")]
		private RSAKey _003CPubKey_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724B70", Offset = "0x724B70")]
		[CompilerGenerated]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x30")]
		private bool _003CSelfSigned_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724BAC", Offset = "0x724BAC")]
		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x38")]
		private DistinguishedName _003CSubject_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724BE8", Offset = "0x724BE8")]
		[CompilerGenerated]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x40")]
		private DistinguishedName _003CIssuer_003Ek__BackingField;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x48")]
		private Asn1Node TbsCertificate;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724C24", Offset = "0x724C24")]
		[CompilerGenerated]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x50")]
		private Asn1Node _003CSignature_003Ek__BackingField;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x58")]
		public byte[] rawTBSCertificate;

		[Token(Token = "0x17000008")]
		public string SerialNumber
		{
			[CompilerGenerated]
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x15D5FC4", Offset = "0x15D5FC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SerialNumber>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SerialNumber;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x15D5FCC", Offset = "0x15D5FCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SerialNumber>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CSerialNumber_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000009")]
		public DateTime ValidAfter
		{
			[CompilerGenerated]
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x15D5FD4", Offset = "0x15D5FD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ValidAfter>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ValidAfter;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x15D5FDC", Offset = "0x15D5FDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ValidAfter>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CValidAfter_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000A")]
		public DateTime ValidBefore
		{
			[CompilerGenerated]
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x15D5FE4", Offset = "0x15D5FE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ValidBefore>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ValidBefore;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x15D5FEC", Offset = "0x15D5FEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ValidBefore>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CValidBefore_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000B")]
		public RSAKey PubKey
		{
			[CompilerGenerated]
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x15D5FF4", Offset = "0x15D5FF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<PubKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PubKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x15D5FFC", Offset = "0x15D5FFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PubKey>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPubKey_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000C")]
		private bool SelfSigned
		{
			[CompilerGenerated]
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x15D6004", Offset = "0x15D6004", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SelfSigned>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CSelfSigned_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000D")]
		public DistinguishedName Subject
		{
			[CompilerGenerated]
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x15D6010", Offset = "0x15D6010", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Subject>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Subject;
			}
			[CompilerGenerated]
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x15D6018", Offset = "0x15D6018", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Subject>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CSubject_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000E")]
		public DistinguishedName Issuer
		{
			[CompilerGenerated]
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x15D6020", Offset = "0x15D6020", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Issuer>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Issuer;
			}
			[CompilerGenerated]
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x15D6028", Offset = "0x15D6028", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Issuer>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CIssuer_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000F")]
		public Asn1Node Signature
		{
			[CompilerGenerated]
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x15D6030", Offset = "0x15D6030", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Signature>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Signature;
			}
			[CompilerGenerated]
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x15D6038", Offset = "0x15D6038", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Signature>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CSignature_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x15D5924", Offset = "0x15D5924", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tUnityEngine.Purchasing.Security.X509Cert::ParseNode(this, n);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public X509Cert(Asn1Node n)
		{
			ParseNode(n);
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x15D31EC", Offset = "0x15D31EC", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB00D8]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, data, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A34]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv47 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v47, v104);\n\tv54 = new LipingShare.LCLib.Asn1Processor.Asn1Parser();\n\tLipingShare.LCLib.Asn1Processor.Asn1Parser::.ctor(v54);\n\tv57 = v54 == 0;\n\tif (v57) goto L_0077;\n\tLipingShare.LCLib.Asn1Processor.Asn1Parser::LoadData(v54, v47);\n\tUnityEngine.Purchasing.Security.X509Cert::ParseNode(this, v54.rootNode);\n\tv122 = v47 == 0;\n\tif (v122) goto L_0061;\nL_0039:\n\tgoto L_0060;\n\tv194 = *([v159 @ X8_v10+B0]);\n\tv195 = 0;\n\tv196 = v194 + 8;\n\tv198 = *([v241 @ X11_v8-8]);\n\tv247 = v198 == v162;\n\tif (v247) goto L_0059;\n\tv220 = v242 + 1;\n\tv278 = v220 < v161;\n\tv216 = ~v278;\n\tv218 = v241 + 0x10;\n\tv200 = ~v216;\n\tif (v200) goto L_FFFFFFFF;\n\tv221 = v50;\n\tv222 = 0;\n\tv223 = 0x8909C4(v221, v162, v222, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0060;\nL_0059:\n\tv279 = *([v241 @ X11_v8]);\n\tv280 = v279 << 4;\n\tv281 = v159 + v280;\n\tv282 = v281 + 0x130;\nL_0060:\n\tSystem.IDisposable::Dispose(v47);\nL_0061:\n\tv191 = v113 + 1;\n\tv82 = v191 == 0;\n\tv67 = ~v82;\n\tif (v67) goto L_0071;\n\tv224 = v111 == 0;\n\tv109 = ~v224;\n\tif (v109) goto L_FFFFFFFF;\nL_0071:\n\treturn;\n\tthrow System.TypeLoadException;\nL_0077:\n\tv117 = new System.NullReferenceException();\n\tgoto L_0084;\n\tgoto L_0084;\n\tgoto L_0084;\nL_0084:\n\tv132 = v104 != 1;\n\tif (v132) goto L_008E;\n\tv192 = 0x6D2BC0(v117, v104, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv153 = *([v192 @ X0_v15]);\n\tv150 = 0x6D2490(v192, v104, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv277 = v47 == 0;\n\tv152 = ~v277;\n\tif (v152) goto L_0039;\n\tgoto L_0061;\nL_008E:\n\tv193 = 0x6D2380(v117, v104, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public X509Cert(byte[] data)
		{
			//IL_0112: Expected I4, but got O
			//IL_015f: Expected I4, but got O
			base._002Ector();
			byte[] array = default(byte[]);
			MemoryStream memoryStream = new MemoryStream(array);
			Asn1Parser asn1Parser = new Asn1Parser();
			int num;
			int num2;
			int num3;
			int num4;
			if (asn1Parser != null)
			{
				asn1Parser.LoadData(memoryStream);
				ParseNode(asn1Parser.RootNode);
				bool flag = memoryStream == null;
				num = 0;
				num2 = 0;
				num3 = 0;
				num4 = 0;
				if (flag)
				{
					goto IL_0196;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)array != (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					return;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag2 = memoryStream != null;
				num2 = -1;
				if (!flag2)
				{
					num3 = (int)obj;
					num4 = -1;
					goto IL_0196;
				}
			}
			((IDisposable)memoryStream).Dispose();
			num3 = num;
			num4 = num2;
			goto IL_0196;
			IL_0196:
			if (num4 + 1 != 0 || num3 == 0)
			{
				return;
			}
			array = null;
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15D5634", Offset = "0x15D5634", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<ValidAfter>k__BackingField;\n\tv15 = 0xE94E94(&v12 @ X1_v1 (System.DateTime), this.<ValidAfter>k__BackingField, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv29 = v15 & 0x80000000;\n\tv30 = v29 == 0;\n\tv31 = ~v30;\n\tif (v31) goto L_FFFFFFFF;\n\tv12 = this.<ValidBefore>k__BackingField;\n\tv35 = 0xE94E94(&v12 @ X1_v1 (System.DateTime), this.<ValidBefore>k__BackingField, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv39 = v35 - 1;\n\tv40 = v39 < 0;\n\tv42 = v35 ^ 1;\n\tv43 = v35 ^ v39;\n\tv44 = v42 & v43;\n\tv45 = v44 < 0;\n\tv46 = v40 == v45;\n\tv47 = ~v46;\n\tgoto L_0025;\nL_0025:\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool CheckCertTime(DateTime time)
		{
			//IL_002c: Expected I4, but got I8
			//IL_007c: Expected O, but got I
			DateTime validAfter = ValidAfter;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
			object obj = default(object);
			if ((int)((long)(IntPtr)obj & 0x80000000L) == 0)
			{
				validAfter = ValidBefore;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E94E94 (inside System.DateTime::Compare +0x108)");
				object obj3 = default(object);
				object obj2 = (long)(IntPtr)obj3 - 1L;
				bool flag = (long)(IntPtr)obj2 < 0L;
				int num = (int)((long)(IntPtr)obj3 ^ 1L);
				int num2 = (int)((long)(IntPtr)obj3 ^ (long)(IntPtr)obj2);
				int num3 = num & num2;
				bool flag2 = num3 < 0;
				bool flag3 = flag == flag2;
				return !flag3;
			}
			return false;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x15D58B0", Offset = "0x15D58B0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = UnityEngine.Purchasing.Security.DistinguishedName::Equals(this.<Issuer>k__BackingField, signer.<Subject>k__BackingField);\n\tv55 = v31 == 0;\n\tif (v55) goto L_002A;\n\tv23 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(this.<Signature>k__BackingField);\n\treturnVal3 = UnityEngine.Purchasing.Security.RSAKey::Verify(signer.<PubKey>k__BackingField, this.rawTBSCertificate, v23);\n\treturn returnVal3;\nL_002A:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool CheckSignature(X509Cert signer)
		{
			if (Issuer.Equals(signer.Subject))
			{
				byte[] data = Signature.Data;
				return signer.PubKey.Verify(rawTBSCertificate, data);
			}
			return false;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15D6040", Offset = "0x15D6040", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1ED3988]);\n\tv27 = *([v26 @ X8_v34]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, root, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2029A35]) = v45;\nL_001A:\n\tv48 = root.tag & 0x1F;\n\tv58 = v48 != 0x10;\n\tif (v58) goto L_0108;\n\tv174 = root.childNodeList;\n\tv201 = System.Collections.ArrayList::get_Count(v174);\n\tv182 = v201 != 3;\n\tif (v182) goto L_0108;\n\tv242 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(root, 0);\n\tthis.TbsCertificate = v242;\n\tv243 = v242.childNodeList;\n\tv148 = System.Collections.ArrayList::get_Count(v243);\n\tv94 = v148 <= 6;\n\tif (v94) goto L_0108;\n\tv164 = this.TbsCertificate;\n\tv80 = v164.dataLength + 4;\n\t// 90 NewArr v305 @ X0_v18 (System.Byte[]), typeof(System.Byte[]), v80 @ X1_v8 (System.Int64)\n\tthis.rawTBSCertificate = v305;\n\tv149 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(root);\n\tv76 = this.rawTBSCertificate;\n\tSystem.Array::Copy(v149, 0, this.rawTBSCertificate, 0, *([v76 @ X2_v5 (System.Array)+18]));\n\tv202 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.TbsCertificate, 1);\n\tv212 = v202.tag & 0x1F;\n\tv95 = v212 != 2;\n\tif (v95) goto L_0108;\n\tv309 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v202);\n\tgoto L_008A;\n\tv316 = *([v312 @ X8_v20+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_008A;\n\tv323 = v312;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v323, v81, v76, v70, v73, v67, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_008A:\n\tv150 = LipingShare.LCLib.Asn1Processor.Asn1Util::ToHexString(v309);\n\tthis.<SerialNumber>k__BackingField = v150;\n\tv326 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.TbsCertificate, 3);\n\tv329 = new UnityEngine.Purchasing.Security.DistinguishedName();\n\tUnityEngine.Purchasing.Security.DistinguishedName::.ctor(v329, v326);\n\tthis.<Issuer>k__BackingField = v329;\n\tv331 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.TbsCertificate, 5);\n\tv333 = new UnityEngine.Purchasing.Security.DistinguishedName();\n\tUnityEngine.Purchasing.Security.DistinguishedName::.ctor(v333, v331);\n\tthis.<Subject>k__BackingField = v333;\n\tv203 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.TbsCertificate, 4);\n\tv213 = v203.tag & 0x1F;\n\tv183 = v213 != 0x10;\n\tif (v183) goto L_0108;\n\tv247 = v203.childNodeList;\n\tv204 = System.Collections.ArrayList::get_Count(v247);\n\tv96 = v204 != 2;\n\tif (v96) goto L_0108;\n\tv339 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v203, 0);\n\tv341 = UnityEngine.Purchasing.Security.X509Cert::ParseTime(v339, v339);\n\tthis.<ValidAfter>k__BackingField = v341;\n\tv344 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v203, 1);\n\tv151 = UnityEngine.Purchasing.Security.X509Cert::ParseTime(v344, v344);\n\tthis.<ValidBefore>k__BackingField = v151;\n\tv152 = UnityEngine.Purchasing.Security.DistinguishedName::Equals(this.<Subject>k__BackingField, this.<Issuer>k__BackingField);\n\tthis.<SelfSigned>k__BackingField = v152;\n\tv348 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.TbsCertificate, 6);\n\tv353 = new UnityEngine.Purchasing.Security.RSAKey();\n\tSystem.Object::.ctor(v353);\n\tv358 = UnityEngine.Purchasing.Security.RSAKey::ParseNode(v353, v348);\n\t*([v353 @ X0_v50 (System.Object)+10]) = v358;\n\tthis.<PubKey>k__BackingField = v353;\n\tv288 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(root, 2);\n\tthis.<Signature>k__BackingField = v288;\n\treturn;\nL_0108:\n\tv218 = new UnityEngine.Purchasing.Security.InvalidX509Data();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v218);\n\tthrow v218;\n\tthrow System.NullReferenceException;\n// 199 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void ParseNode(Asn1Node root)
		{
			int num = root.Tag & 0x1F;
			if (num == 16)
			{
				ArrayList childNodeList = root.childNodeList;
				int count = childNodeList.Count;
				if (count == 3)
				{
					ArrayList childNodeList2 = (TbsCertificate = root.GetChildNode(0)).childNodeList;
					int count2 = childNodeList2.Count;
					if (count2 > 6)
					{
						Asn1Node tbsCertificate = TbsCertificate;
						long num2 = tbsCertificate.DataLength + 4;
						byte[] array = new byte[num2];
						rawTBSCertificate = array;
						byte[] data = root.Data;
						Array array2 = rawTBSCertificate;
						byte[] destinationArray = rawTBSCertificate;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X2_v5 (System.Array)+18]");
						Array.Copy(data, 0, destinationArray, 0, 0);
						Asn1Node childNode = TbsCertificate.GetChildNode(1);
						int num3 = childNode.Tag & 0x1F;
						if (num3 == 2)
						{
							byte[] data2 = childNode.Data;
							string text = Asn1Util.ToHexString(data2);
							SerialNumber = text;
							Asn1Node childNode2 = TbsCertificate.GetChildNode(3);
							DistinguishedName distinguishedName = new DistinguishedName(childNode2);
							Issuer = distinguishedName;
							Asn1Node childNode3 = TbsCertificate.GetChildNode(5);
							DistinguishedName distinguishedName2 = new DistinguishedName(childNode3);
							Subject = distinguishedName2;
							Asn1Node childNode4 = TbsCertificate.GetChildNode(4);
							int num4 = childNode4.Tag & 0x1F;
							if (num4 == 16)
							{
								ArrayList childNodeList3 = childNode4.childNodeList;
								int count3 = childNodeList3.Count;
								if (count3 == 2)
								{
									Asn1Node childNode5 = childNode4.GetChildNode(0);
									DateTime dateTime = ((X509Cert)(object)childNode5).ParseTime(childNode5);
									ValidAfter = dateTime;
									Asn1Node childNode6 = childNode4.GetChildNode(1);
									DateTime dateTime2 = ((X509Cert)(object)childNode6).ParseTime(childNode6);
									ValidBefore = dateTime2;
									bool flag = Subject.Equals(Issuer);
									_003CSelfSigned_003Ek__BackingField = flag;
									Asn1Node childNode7 = TbsCertificate.GetChildNode(6);
									object obj = null;
									RSACryptoServiceProvider rSACryptoServiceProvider = ((RSAKey)obj).ParseNode(childNode7);
									PubKey = (RSAKey)obj;
									Asn1Node childNode8 = root.GetChildNode(2);
									Signature = childNode8;
									return;
								}
							}
						}
					}
				}
			}
			InvalidX509Data invalidX509Data = (InvalidX509Data)new IAPSecurityException();
			throw invalidX509Data;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x15D6334", Offset = "0x15D6334", Length = "0x1240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1EDDD88]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, n, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([2029A36]) = v48;\nL_001B:\n\tv52 = new System.Text.UTF8Encoding();\n\tSystem.Text.UTF8Encoding::.ctor(v52);\n\tv57 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(n);\n\tv71 = System.Text.Encoding::GetString(v52, v57);\n\tv119 = v71.m_stringLength | 2;\n\tv82 = v119 != 0xF;\n\tif (v82) goto L_00C0;\n\tv121 = v71.m_stringLength - 1;\n\tv123 = System.String::get_Chars(v71, v121);\n\tv128 = v123 & 0xFFFF;\n\tv83 = v128 != 0x5A;\n\tif (v83) goto L_00C0;\n\tv154 = v71.m_stringLength != 0xD;\n\tif (v154) goto L_0079;\n\tv160 = System.String::Substring(v71, 0, 2);\n\tv234 = System.Int32::Parse(v160);\n\tv239 = v234 - 0x32;\n\tv240 = v239 < 0;\n\tv242 = v234 ^ 0x32;\n\tv243 = v234 ^ v239;\n\tv244 = v242 & v243;\n\tv245 = v244 < 0;\n\tv248 = v240 == v245;\n\tv249 = ~v248;\n\tv250 = ~v249;\n\tif (v250) goto L_FFFFFFFF;\n\tgoto L_0072;\nL_0072:\n\tv260 = v259 + v234;\n\tgoto L_0081;\nL_0079:\n\tv166 = System.String::Substring(v71, 0, 4);\n\tv236 = System.Int32::Parse(v166);\nL_0081:\n\tv266 = System.String::Substring(v71, v254, 2);\n\tv268 = System.Int32::Parse(v266);\n\tv270 = v254 + 2;\n\tv274 = System.String::Substring(v71, v270, 2);\n\tv276 = System.Int32::Parse(v274);\n\tv278 = v254 + 4;\n\tv282 = System.String::Substring(v71, v278, 2);\n\tv284 = System.Int32::Parse(v282);\n\tv286 = v254 + 6;\n\tv290 = System.String::Substring(v71, v286, 2);\n\tv292 = System.Int32::Parse(v290);\n\tv294 = v254 | 8;\n\tv298 = System.String::Substring(v71, v294, 2);\n\tv300 = System.Int32::Parse(v298);\n\tv173 = 0;\n\tv302 = 0xE93B78(&v173 @ stack_-48_v1 (System.DateTime), v260, v268, v276, v284, v292, v300, 1, v37, v38, v39, v40, v41, v42, v43, v44);\n\treturn 0;\n\tthrow System.NullReferenceException;\nL_00C0:\n\tv132 = new UnityEngine.Purchasing.Security.InvalidTimeFormat();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v132);\n\tthrow v132;\n\treturn returnVal1;\n\tX8 = *([X8+AB8]);\n\tX0 = 0x15D0004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n\treturn X0;\n// 1165 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private DateTime ParseTime(Asn1Node n)
		{
			UTF8Encoding uTF8Encoding = new UTF8Encoding();
			byte[] data = n.Data;
			string text = uTF8Encoding.GetString(data);
			int num = text.Length | 2;
			if (num == 15)
			{
				int index = text.Length - 1;
				char c = text.get_Chars(index);
				int num2 = c & 0xFFFF;
				if (num2 == 90)
				{
					int num10;
					if (text.Length == 13)
					{
						string s = text.Substring(0, 2);
						int num3 = int.Parse(s);
						int num4 = num3 - 50;
						bool flag = num4 < 0;
						int num5 = num3 ^ 0x32;
						int num6 = num3 ^ num4;
						int num7 = num5 & num6;
						bool flag2 = num7 < 0;
						int num8 = ((flag == flag2) ? 1900 : 2000);
						int num9 = num8 + num3;
						num10 = 2;
					}
					else
					{
						string s2 = text.Substring(0, 4);
						int num11 = int.Parse(s2);
						num10 = 4;
						int num9 = num11;
					}
					string s3 = text.Substring(num10, 2);
					int num12 = int.Parse(s3);
					int startIndex = num10 + 2;
					string s4 = text.Substring(startIndex, 2);
					int num13 = int.Parse(s4);
					int startIndex2 = num10 + 4;
					string s5 = text.Substring(startIndex2, 2);
					int num14 = int.Parse(s5);
					int startIndex3 = num10 + 6;
					string s6 = text.Substring(startIndex3, 2);
					int num15 = int.Parse(s6);
					int startIndex4 = num10 | 8;
					string s7 = text.Substring(startIndex4, 2);
					int num16 = int.Parse(s7);
					DateTime dateTime = default(DateTime);
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @E93B78 (inside System.DateTime::TimeToTicks +0xF0)");
					return default(DateTime);
				}
			}
			InvalidTimeFormat invalidTimeFormat = (InvalidTimeFormat)new IAPSecurityException();
			throw invalidTimeFormat;
		}
	}
}
