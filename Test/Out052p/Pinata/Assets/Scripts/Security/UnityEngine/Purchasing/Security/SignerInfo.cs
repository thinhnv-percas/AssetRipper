using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using LipingShare.LCLib.Asn1Processor;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000006")]
	internal class SignerInfo
	{
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724D14", Offset = "0x724D14")]
		[CompilerGenerated]
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x10")]
		private int _003CVersion_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724D50", Offset = "0x724D50")]
		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x18")]
		private string _003CIssuerSerialNumber_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724D8C", Offset = "0x724D8C")]
		[CompilerGenerated]
		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x20")]
		private byte[] _003CEncryptedDigest_003Ek__BackingField;

		[Token(Token = "0x17000013")]
		public int Version
		{
			[CompilerGenerated]
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x15D5F90", Offset = "0x15D5F90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Version>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Version;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x15D5F98", Offset = "0x15D5F98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Version>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CVersion_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000014")]
		public string IssuerSerialNumber
		{
			[CompilerGenerated]
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x15D5FA0", Offset = "0x15D5FA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IssuerSerialNumber>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IssuerSerialNumber;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000034")]
			[Address(RVA = "0x15D5FA8", Offset = "0x15D5FA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IssuerSerialNumber>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CIssuerSerialNumber_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000015")]
		public byte[] EncryptedDigest
		{
			[CompilerGenerated]
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x15D5FB0", Offset = "0x15D5FB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<EncryptedDigest>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EncryptedDigest;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x15D5FB8", Offset = "0x15D5FB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<EncryptedDigest>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CEncryptedDigest_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x15D5954", Offset = "0x15D5954", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB7728]);\n\tv23 = *([v22 @ X8_v33]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, n, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029A33]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tv45 = n.childNodeList;\n\tv95 = System.Collections.ArrayList::get_Count(v45);\n\tv105 = v95 != 5;\n\tif (v105) goto L_FFFFFFFF;\n\tv179 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 0);\n\tv196 = v179.tag & 0x1F;\n\tv108 = v196 != 2;\n\tif (v108) goto L_FFFFFFFF;\n\tv180 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v179);\n\tv252 = v180.Length == 0;\n\tif (v252) goto L_00D8;\n\tthis.<Version>k__BackingField = v180[0];\n\tv109 = v180[0] != 1;\n\tif (v109) goto L_FFFFFFFF;\n\tv181 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v179);\n\tv110 = v181.Length != 1;\n\tif (v110) goto L_FFFFFFFF;\n\tv182 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 1);\n\tv199 = v182.tag & 0x1F;\n\tv111 = v199 != 0x10;\n\tif (v111) goto L_FFFFFFFF;\n\tv183 = v182.childNodeList;\n\tv230 = System.Collections.ArrayList::get_Count(v183);\n\tv112 = v230 != 2;\n\tif (v112) goto L_FFFFFFFF;\n\tv184 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v182, 1);\n\tv233 = v184.tag & 0x1F;\n\tv113 = v233 != 2;\n\tif (v113) goto L_FFFFFFFF;\n\tv321 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v184);\n\tgoto L_00AA;\n\tv327 = *([v201 @ X8_v28+E0]);\n\tv328 = v327 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_00AA;\n\tv335 = v201;\n\tv331 = \"il2cpp_codegen_runtime_class_init\"(v335, v173, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00AA:\n\tv334 = LipingShare.LCLib.Asn1Processor.Asn1Util::ToHexString(v321);\n\tthis.<IssuerSerialNumber>k__BackingField = v334;\n\tv185 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 4);\n\tv234 = v185.tag & 0x1F;\n\tv209 = v234 != 4;\n\tif (v209) goto L_FFFFFFFF;\n\tv298 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v185);\n\tthis.<EncryptedDigest>k__BackingField = v298;\n\treturn;\n\tgoto L_00CD;\nL_00CD:\n\tv274 = new *([v271 @ X8_v7])();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v274);\n\tthrow System.TypeLoadException;\n\tv206 = new System.NullReferenceException();\nL_00D8:\n\tv257 = new System.IndexOutOfRangeException();\n\tthrow v257;\n\treturn;\n// 160 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SignerInfo(Asn1Node n)
		{
			object typeFromHandle;
			if (n.childNodeList.Count == 5)
			{
				Asn1Node childNode = n.GetChildNode(0);
				if ((childNode.Tag & 0x1F) == 2)
				{
					byte[] data = childNode.Data;
					if (data.Length == 0)
					{
						throw new IndexOutOfRangeException();
					}
					Version = data[0];
					if (data[0] != 1 || childNode.Data.Length != 1)
					{
						typeFromHandle = typeof(UnsupportedSignerInfoVersion);
						goto IL_02d7;
					}
					Asn1Node childNode2 = n.GetChildNode(1);
					if ((childNode2.Tag & 0x1F) == 16 && childNode2.childNodeList.Count == 2)
					{
						Asn1Node childNode3 = childNode2.GetChildNode(1);
						if ((childNode3.Tag & 0x1F) == 2)
						{
							IssuerSerialNumber = Asn1Util.ToHexString(childNode3.Data);
							Asn1Node childNode4 = n.GetChildNode(4);
							if ((childNode4.Tag & 0x1F) == 4)
							{
								EncryptedDigest = childNode4.Data;
								return;
							}
						}
					}
				}
			}
			typeFromHandle = typeof(InvalidPKCS7Data);
			goto IL_02d7;
			IL_02d7:
			IAPSecurityException ex = new IAPSecurityException();
			throw new TypeLoadException();
		}
	}
}
