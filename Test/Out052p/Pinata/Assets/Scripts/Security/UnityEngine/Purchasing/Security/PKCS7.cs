using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using LipingShare.LCLib.Asn1Processor;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000005")]
	internal class PKCS7
	{
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x10")]
		internal Asn1Node root;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724C60", Offset = "0x724C60")]
		[CompilerGenerated]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x18")]
		private Asn1Node _003Cdata_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724C9C", Offset = "0x724C9C")]
		[CompilerGenerated]
		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x20")]
		private List<SignerInfo> _003Csinfos_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724CD8", Offset = "0x724CD8")]
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x28")]
		private List<X509Cert> _003CcertChain_003Ek__BackingField;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x30")]
		private bool validStructure;

		[Token(Token = "0x17000010")]
		public Asn1Node data
		{
			[CompilerGenerated]
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x15D51D0", Offset = "0x15D51D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<data>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return data;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x15D51D8", Offset = "0x15D51D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<data>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003Cdata_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000011")]
		public List<SignerInfo> sinfos
		{
			[CompilerGenerated]
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x15D51E0", Offset = "0x15D51E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<sinfos>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return sinfos;
			}
			[CompilerGenerated]
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x15D51E8", Offset = "0x15D51E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<sinfos>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003Csinfos_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000012")]
		public List<X509Cert> certChain
		{
			[CompilerGenerated]
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x15D51F0", Offset = "0x15D51F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<certChain>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return certChain;
			}
			[CompilerGenerated]
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x15D51F8", Offset = "0x15D51F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<certChain>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CcertChain_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x15D2730", Offset = "0x15D2730", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.root = node;\n\tUnityEngine.Purchasing.Security.PKCS7::CheckStructure(this);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PKCS7(Asn1Node node)
		{
			root = node;
			CheckStructure();
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x15D3420", Offset = "0x15D3420", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tgoto L_001E;\n\tv37 = *([1EB7400]);\n\tv38 = *([v37 @ X8_v45]);\n\tv39 = \"il2cpp_codegen_initialize_method\"(v38, cert, certificateCreationTime, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029A2C]) = v55;\nL_001E:\n\tv56 = &v57 @ stack_-E0;\n\t*([v21 @ X29-68]) = 0;\n\t*([v21 @ X29-60]) = 0;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-88]) = 0;\n\t*([v21 @ X29-80]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\tv60 = ~this.validStructure;\n\tif (v60) goto L_FFFFFFFF;\n\t*([v21 @ X29-C0]) = cert;\n\t*([v21 @ X29-B8]) = v465;\n\tv128 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.SignerInfo>::GetEnumerator(this.<sinfos>k__BackingField);\n\t*([v21 @ X29-B0]) = 1;\n\t*([v21 @ X29-60]) = *([v21 @ X29-98]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-A8]);\n\tgoto L_00D2;\nL_0047:\n\tv198 = *([v21 @ X29-60]);\n\tv522 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>::GetEnumerator(this.<certChain>k__BackingField);\n\t*([v21 @ X29-80]) = *([v21 @ X29-98]);\n\t*([v21 @ X29-90]) = *([v21 @ X29-A8]);\nL_0050:\n\tv572 = &v21 @ X29 - 0x90;\n\tv573 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>+Enumerator<UnityEngine.Purchasing.Security.X509Cert>::MoveNext(v572);\n\tv593 = v573 == 0;\n\tif (v593) goto L_FFFFFFFF;\n\tv294 = *([v21 @ X29-80]);\n\tv187 = *([v21 @ X29-80]) == 0;\n\tif (v187) goto L_0068;\n\tv188 = *([v21 @ X29-60]) == 0;\n\tif (v188) goto L_006B;\n\tv569 = System.String::op_Equality(v294.<SerialNumber>k__BackingField, *([v198 @ X20_v15+18]));\n\tv571 = v569 == 0;\n\tif (v571) goto L_0050;\n\tgoto L_0063;\nL_0063:\n\tv97 = v166 + 1;\n\t*([v56 @ X25_v1+v97 @ X26_v5*4]) = 0x83;\n\tgoto L_0080;\nL_0068:\n\tv183 = new System.NullReferenceException();\n\tgoto L_00E2;\nL_006B:\n\tv184 = new System.NullReferenceException();\n\tgoto L_00E2;\n\tgoto L_0070;\n\tgoto L_0070;\n\tgoto L_0070;\nL_0070:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00F2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX23 = 0;\nL_0080:\n\tv607 = &v21 @ X29 - 0x90;\n\tv408 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>+Enumerator<UnityEngine.Purchasing.Security.X509Cert>::Dispose(v607);\n\tv609 = v97 + 1;\n\tv611 = v609 == 0;\n\tif (v611) goto L_009C;\n\tv371 = *([v56 @ X25_v1+v97 @ X26_v5*4]) != 0x83;\n\tif (v371) goto L_009C;\n\tv416 = 0xFFFFFFFF ^ v97;\n\tv166 = v97 + v416;\n\tv411 = v294 == 0;\n\tif (v411) goto L_00D2;\n\tgoto L_00A0;\nL_009C:\n\tgoto L_00E1;\n\tv412 = v294 == 0;\n\tif (v412) goto L_00D2;\nL_00A0:\n\tv413 = v294.<PubKey>k__BackingField == 0;\n\tif (v413) goto L_00D2;\n\tv620 = *([v21 @ X29-B0]) & 1;\n\tv621 = v620 == 0;\n\tif (v621) goto L_FFFFFFFF;\n\tv623 = UnityEngine.Purchasing.Security.X509Cert::CheckCertTime(v294, *([v21 @ X29-B8]));\n\tv630 = v623 == 0;\n\tif (v630) goto L_FFFFFFFF;\n\tv478 = this.<data>k__BackingField == 0;\n\tif (v478) goto L_00E6;\n\t*([v21 @ X29-B0]) = v294.<PubKey>k__BackingField;\n\tv443 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(this.<data>k__BackingField);\n\tv628 = UnityEngine.Purchasing.Security.RSAKey::Verify(*([v21 @ X29-B0]), v443, *([v198 @ X20_v15+20]));\n\tv631 = v628 == 0;\n\tif (v631) goto L_FFFFFFFF;\n\tv638 = UnityEngine.Purchasing.Security.PKCS7::ValidateChain(this, *([v21 @ X29-C0]), v294, *([v21 @ X29-B8]));\n\tgoto L_00C9;\nL_00C9:\n\tv391 = v639 == 0;\n\tv370 = ~v391;\n\t*([v21 @ X29-B0]) = v370;\nL_00D2:\n\tv421 = &v21 @ X29 - 0x70;\n\tv422 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.SignerInfo>+Enumerator<UnityEngine.Purchasing.Security.SignerInfo>::MoveNext(v421);\n\tv453 = v422 == 0;\n\tv454 = ~v453;\n\tif (v454) goto L_0047;\n\tv122 = *([v21 @ X29-B0]);\n\tv97 = v166 + 1;\n\t*([v56 @ X25_v1+v97 @ X26_v5*4]) = 0xFE;\n\tgoto L_0103;\n\tthrow System.NullReferenceException;\nL_00E1:\n\tv182 = new System.TypeLoadException();\nL_00E2:\n\tv199 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv451 = new System.NullReferenceException();\nL_00E6:\n\tv484 = new System.NullReferenceException();\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F2;\n\tgoto L_00F2;\n\tgoto L_00F0;\n\tgoto L_00F0;\n\tgoto L_00F0;\nL_00F0:\n\tgoto L_00FC;\n\tgoto L_00F2;\nL_00F2:\n\tX20 = *([X29-B0]);\nL_00FC:\n\tv490 = *([v21 @ X29-B8]) != 1;\n\tif (v490) goto L_0145;\n\tv574 = 0x6D2BC0(v484, *([v21 @ X29-B8]), v465, *([v21 @ X29-B8]), v41, v42, v43, v44, *([v21 @ X29-A8]), v46, v47, v48, v49, v50, v51, v52);\n\tv116 = *([v574 @ X0_v21]);\n\tv510 = 0x6D2490(v574, *([v21 @ X29-B8]), v465, *([v21 @ X29-B8]), v41, v42, v43, v44, *([v21 @ X29-A8]), v46, v47, v48, v49, v50, v51, v52);\nL_0103:\n\tv517 = &v21 @ X29 - 0x70;\n\tv519 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.SignerInfo>+Enumerator<UnityEngine.Purchasing.Security.SignerInfo>::Dispose(v517);\n\tv524 = v97 + 1;\n\tv526 = v524 == 0;\n\tif (v526) goto L_011D;\n\tv535 = v116 == 0;\n\tif (v535) goto L_0120;\n\tv581 = *([v56 @ X25_v1+v97 @ X26_v5*4]) == 0xFE;\n\tif (v581) goto L_0120;\nL_011C:\n\tthrow System.TypeLoadException;\nL_011D:\n\tv562 = v116 == 0;\n\tv563 = ~v562;\n\tif (v563) goto L_011C;\nL_0120:\n\tv587 = v122 & 1;\n\tv114 = v587 == 0;\n\tif (v114) goto L_FFFFFFFF;\n\tv595 = this.<sinfos>k__BackingField;\n\tv221 = v595._size < 0;\n\tv219 = v595._size == 0;\n\tv209 = v595._size ^ v595._size;\n\tv207 = v595._size & v209;\n\tv215 = v207 < 0;\n\tv599 = v221 == v215;\n\tv202 = ~v219;\n\tv205 = v599 & v202;\n\tgoto L_0144;\nL_0144:\n\treturn returnVal1;\nL_0145:\n\tv575 = 0x6D2380(v484, *([v21 @ X29-B8]), v465, *([v21 @ X29-B8]), v41, v42, v43, v44, *([v21 @ X29-A8]), v46, v47, v48, v49, v50, v51, v52);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Verify(X509Cert cert, DateTime certificateCreationTime)
		{
			//IL_0058: Expected O, but got I8
			//IL_062a: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_066e: Expected O, but got I
			//IL_03b5: Expected O, but got I
			//IL_0437: Expected O, but got I
			//IL_044f: Expected O, but got I
			//IL_06a7: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_0722: Expected O, but got I
			//IL_073a: Expected O, but got I
			//IL_0112: Expected O, but got I
			//IL_01ae: Expected I4, but got I8
			//IL_01bc: Expected O, but got I
			//IL_028c: Expected O, but got I
			//IL_031a: Expected O, but got I
			//IL_031a: Expected O, but got I
			//IL_033d: Expected O, but got I
			//IL_05d4: Expected I4, but got O
			//IL_0410: Expected I4, but got O
			//IL_036f: Expected O, but got I
			//IL_036f: Expected O, but got I
			object obj = obj;
			object obj3 = default(object);
			object obj2 = obj3;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (validStructure)
			{
				List<SignerInfo>.Enumerator enumerator = sinfos.GetEnumerator();
				_ = 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
				_ = 0;
				object obj4 = 4294967295L;
				DateTime dateTime = default(DateTime);
				object obj6;
				int num3;
				object obj8 = default(object);
				int num4;
				while (true)
				{
					List<SignerInfo>.Enumerator enumerator2 = (List<SignerInfo>.Enumerator)((long)(IntPtr)obj - 112L);
					X509Cert x509Cert2;
					int num5;
					if (((List<SignerInfo>.Enumerator*)enumerator2)->MoveNext())
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
						object obj5 = 0;
						List<X509Cert>.Enumerator enumerator3 = certChain.GetEnumerator();
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
						_ = 0;
						X509Cert x509Cert;
						while (true)
						{
							List<X509Cert>.Enumerator enumerator4 = (List<X509Cert>.Enumerator)((long)(IntPtr)obj - 144L);
							if (((List<X509Cert>.Enumerator*)enumerator4)->MoveNext())
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
								x509Cert = (X509Cert)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-80]");
								if ((IntPtr)0 != (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-60]");
									if ((IntPtr)0 != (IntPtr)0)
									{
										string serialNumber = x509Cert.SerialNumber;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X20_v15+18]");
										bool flag = serialNumber == (string)0;
										bool flag2 = !flag;
										dateTime = default(DateTime);
										if (flag2)
										{
											continue;
										}
										dateTime = default(DateTime);
										goto IL_0698;
									}
									NullReferenceException ex = new NullReferenceException();
								}
								else
								{
									NullReferenceException ex2 = new NullReferenceException();
								}
								goto IL_03d7;
							}
							x509Cert = null;
							goto IL_0698;
							IL_03d7:
							NullReferenceException ex3 = new NullReferenceException();
							throw new NullReferenceException();
							IL_0698:
							obj6 = (long)(IntPtr)obj4 + 1L;
							_ = 131;
							List<X509Cert>.Enumerator enumerator5 = (List<X509Cert>.Enumerator)((long)(IntPtr)obj - 144L);
							((List<X509Cert>.Enumerator*)enumerator5)->Dispose();
							object obj7 = (long)(IntPtr)obj6 + 1L;
							if (obj7 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X25_v1+v97 @ X26_v5*4]");
								if ((IntPtr)0 == (IntPtr)131)
								{
									break;
								}
							}
							TypeLoadException ex4 = new TypeLoadException();
							goto IL_03d7;
						}
						int num = (int)(0xFFFFFFFFL ^ (long)(IntPtr)obj6);
						obj4 = (long)(IntPtr)obj6 + (long)num;
						if (x509Cert == null)
						{
							continue;
						}
						obj6 = obj4;
						bool flag3 = x509Cert.PubKey == null;
						obj4 = obj6;
						if (flag3)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
						int num2 = 0;
						bool flag4 = num2 == 0;
						x509Cert2 = (X509Cert)dateTime;
						if (!flag4)
						{
							X509Cert x509Cert3 = x509Cert;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
							bool flag5 = x509Cert3.CheckCertTime((DateTime)0);
							bool flag6 = !flag5;
							x509Cert2 = (X509Cert)dateTime;
							if (!flag6)
							{
								if (data == null)
								{
									NullReferenceException ex5 = new NullReferenceException();
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
									if ((IntPtr)0 == (IntPtr)1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
										num3 = (int)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
										num4 = 1;
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
									NullReferenceException ex6 = new NullReferenceException();
									return (byte)(int)ex6 != 0;
								}
								_ = x509Cert.PubKey;
								byte[] message = data.Data;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
								IntPtr intPtr = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X20_v15+20]");
								bool flag7 = ((RSAKey)(long)intPtr).Verify(message, (byte[])0);
								bool flag8 = !flag7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X20_v15+20]");
								x509Cert2 = (X509Cert)0;
								if (!flag8)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C0]");
									IntPtr intPtr2 = (IntPtr)0;
									X509Cert cert2 = x509Cert;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B8]");
									bool flag9 = ValidateChain((X509Cert)(long)intPtr2, cert2, (DateTime)0);
									x509Cert2 = x509Cert;
									num5 = (flag9 ? 1 : 0);
									goto IL_06b2;
								}
							}
						}
						num5 = 0;
						goto IL_06b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
					num4 = 0;
					obj6 = (long)(IntPtr)obj4 + 1L;
					_ = 254;
					num3 = 0;
					break;
					IL_06b2:
					bool flag10 = num5 == 0;
					bool flag11 = !flag10;
					dateTime = (DateTime)x509Cert2;
					obj4 = obj6;
				}
				List<SignerInfo>.Enumerator enumerator6 = (List<SignerInfo>.Enumerator)((long)(IntPtr)obj - 112L);
				((List<SignerInfo>.Enumerator*)enumerator6)->Dispose();
				object obj9 = (long)(IntPtr)obj6 + 1L;
				if (obj9 != null)
				{
					if (num3 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X25_v1+v97 @ X26_v5*4]");
						if ((IntPtr)0 != (IntPtr)254)
						{
							goto IL_04ae;
						}
					}
				}
				else if (num3 != 0)
				{
					goto IL_04ae;
				}
				if ((num4 & 1) != 0)
				{
					List<SignerInfo> list = sinfos;
					bool flag12 = list.Count < 0;
					bool flag13 = list.Count == 0;
					int num6 = list.Count ^ list.Count;
					int num7 = list.Count & num6;
					bool flag14 = num7 < 0;
					bool flag15 = flag12 == flag14;
					bool flag16 = !flag13;
					return flag15 && flag16;
				}
			}
			return false;
			IL_04ae:
			throw new TypeLoadException();
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x15D5688", Offset = "0x15D5688", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv32 = *([1EEB480]);\n\tv33 = *([v32 @ X8_v18]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, root, cert, certificateCreationTime, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2029A2D]) = v49;\nL_0025:\n\tv128 = UnityEngine.Purchasing.Security.DistinguishedName::Equals(cert.<Issuer>k__BackingField, root.<Subject>k__BackingField);\n\tv153 = v128 == 0;\n\tif (v153) goto L_0034;\n\tv204 = UnityEngine.Purchasing.Security.X509Cert::CheckSignature(cert, root);\n\tgoto L_00B9;\nL_0034:\n\tv171 = System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>::GetEnumerator(this.<certChain>k__BackingField);\nL_003D:\n\tv282 = 0xEF9AB0(&v90 @ stack_-78_v5, Il2CppMethodInfo, v269, v301, methodInfo, v36, v37, v38, v90, v40, v41, v42, v43, v44, v45, v46);\n\tv295 = v282 & 1;\n\tv287 = v295 == 0;\n\tif (v287) goto L_FFFFFFFF;\n\tv70 = v229 == cert;\n\tif (v70) goto L_003D;\n\tv283 = UnityEngine.Purchasing.Security.DistinguishedName::Equals(v229.<Subject>k__BackingField, cert.<Issuer>k__BackingField);\n\tv288 = v283 == 0;\n\tif (v288) goto L_003D;\n\tv284 = UnityEngine.Purchasing.Security.X509Cert::CheckCertTime(v229, v301);\n\tv289 = v284 == 0;\n\tif (v289) goto L_003D;\n\tv148 = v229.<Issuer>k__BackingField == 0;\n\tif (v148) goto L_008D;\n\tv322 = UnityEngine.Purchasing.Security.DistinguishedName::Equals(v229.<Issuer>k__BackingField, root.<Subject>k__BackingField);\n\tv324 = v322 == 0;\n\tif (v324) goto L_006E;\n\tv328 = System.String::op_Equality(v229.<SerialNumber>k__BackingField, root.<SerialNumber>k__BackingField);\n\tv335 = v328 == 0;\n\tv332 = ~v335;\n\tif (v332) goto L_0084;\nL_006E:\n\tv285 = UnityEngine.Purchasing.Security.X509Cert::CheckSignature(cert, v229);\n\tv290 = v285 == 0;\n\tif (v290) goto L_003D;\n\tv344 = UnityEngine.Purchasing.Security.PKCS7::ValidateChain(this, root, v229, v301);\n\tgoto L_FFFFFFFF;\nL_007F:\n\tv312 = 0xEF9AAC(&v90 @ stack_-78_v5, Il2CppMethodInfo, v269, v301, methodInfo, v36, v37, v38, v90, v40, v41, v42, v43, v44, v45, v46);\n\tv206 = v214 & v212;\n\tgoto L_00B9;\nL_0084:\n\tv339 = UnityEngine.Purchasing.Security.X509Cert::CheckSignature(v229, root);\n\tgoto L_007F;\n\tv316 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tv127 = new System.NullReferenceException();\nL_008D:\n\tv151 = new System.NullReferenceException();\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\n\tgoto L_00A1;\nL_00A1:\n\tv166 = v143 != 1;\n\tif (v166) goto L_00BA;\n\tv172 = 0x6D2BC0(v151, v143, v129, v301, methodInfo, v36, v37, v38, v141, v40, v41, v42, v43, v44, v45, v46);\n\tv231 = 0x6D2490(v172, v143, v129, v301, methodInfo, v36, v37, v38, v141, v40, v41, v42, v43, v44, v45, v46);\n\tv234 = 0xEF9AAC(&v114 @ stack_-60_v3, Il2CppMethodInfo, v129, v301, methodInfo, v36, v37, v38, v141, v40, v41, v42, v43, v44, v45, v46);\n\tv296 = *([v172 @ X0_v12]) == 0;\n\tv208 = ~v296;\n\tif (v208) goto L_00BE;\nL_00B9:\n\treturn v204;\nL_00BA:\n\tv173 = 0x6D2380(v151, v143, v129, v301, methodInfo, v36, v37, v38, v141, v40, v41, v42, v43, v44, v45, v46);\nL_00BE:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ValidateChain(X509Cert root, X509Cert cert, DateTime certificateCreationTime)
		{
			//IL_02ca: Expected I4, but got O
			if (cert.Issuer.Equals(root.Subject))
			{
				return cert.CheckSignature(root);
			}
			List<X509Cert>.Enumerator enumerator = certChain.GetEnumerator();
			X509Cert x509Cert = cert;
			object obj = default(object);
			X509Cert x509Cert2 = default(X509Cert);
			DateTime dateTime = default(DateTime);
			bool flag5;
			DateTime dateTime2 = default(DateTime);
			object obj2 = default(object);
			int num;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					if (x509Cert2 == cert || !x509Cert2.Subject.Equals(cert.Issuer) || !x509Cert2.CheckCertTime(dateTime))
					{
						continue;
					}
					if (x509Cert2.Issuer != null)
					{
						if (x509Cert2.Issuer.Equals(root.Subject))
						{
							bool flag = x509Cert2.SerialNumber == root.SerialNumber;
							bool flag2 = !flag;
							bool flag3 = !flag2;
							x509Cert = null;
							if (flag3)
							{
								bool flag4 = x509Cert2.CheckSignature(root);
								x509Cert = null;
								flag5 = flag4;
								goto IL_0305;
							}
						}
						if (!cert.CheckSignature(x509Cert2))
						{
							continue;
						}
						bool flag6 = ValidateChain(root, x509Cert2, dateTime);
						x509Cert = x509Cert2;
						flag5 = flag6;
						goto IL_0305;
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)dateTime2 == (IntPtr)1)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
						if (obj2 == null)
						{
							return false;
						}
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					}
					TypeLoadException ex2 = new TypeLoadException();
					return (byte)(int)ex2 != 0;
				}
				flag5 = false;
				num = 0;
				break;
				IL_0305:
				num = 1;
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AAC");
			return (byte)((uint)num & (flag5 ? 1u : 0u)) != 0;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x15D5200", Offset = "0x15D5200", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1EB3648]);\n\tv33 = *([v32 @ X8_v53]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2029A2E]) = v52;\nL_001A:\n\tv53 = this.root;\n\tthis.validStructure = 0;\n\tv56 = v53.tag & 0x1F;\n\tv66 = v56 != 0x10;\n\tif (v66) goto L_01B1;\n\tv246 = System.Collections.ArrayList::get_Count(v53.childNodeList);\n\tv216 = v246 != 2;\n\tif (v216) goto L_01B1;\n\tv375 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.root, 0);\n\tv483 = v375.tag & 0x1F;\n\tv288 = v483 != 6;\n\tif (v288) goto L_01B5;\n\tv486 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetDataStr(v375, 0);\n\tv513 = System.String::op_Inequality(v486, \"1.2.840.113549.1.7.2\");\n\tv532 = v513 == 0;\n\tv519 = ~v532;\n\tif (v519) goto L_01B5;\n\tv377 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(this.root, 1);\n\tv378 = v377.childNodeList;\n\tv411 = *([v378 @ X0_v21 (System.Collections.ArrayList)]);\n\tv286 = *([v411 @ X8_v19 (Il2CppClass<System.Collections.ArrayList>)+268]);\n\tv514 = System.Collections.ArrayList::get_Count(v378);\n\tv289 = v514 != 1;\n\tif (v289) goto L_01B5;\n\tv379 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v377, 0);\n\tv380 = v379.childNodeList;\n\tv523 = *([v380 @ X0_v25 (System.Collections.ArrayList)]);\n\tv286 = *([v523 @ X8_v20 (Il2CppClass<System.Collections.ArrayList>)+268]);\n\tv515 = System.Collections.ArrayList::get_Count(v380);\n\tv493 = v515 < 4;\n\tif (v493) goto L_01B5;\n\tv412 = v379.tag & 0x1F;\n\tv290 = v412 != 0x10;\n\tif (v290) goto L_01B5;\n\tv381 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v379, 0);\n\tv413 = v381.tag & 0x1F;\n\tv291 = v413 != 2;\n\tif (v291) goto L_01B5;\n\tv382 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v379, 1);\n\tv414 = v382.tag & 0x1F;\n\tv292 = v414 != 0x11;\n\tif (v292) goto L_01B5;\n\tv383 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v379, 2);\n\tv415 = v383.tag & 0x1F;\n\tv337 = v415 == 0x10;\n\tif (v337) goto L_00E6;\n\tv384 = v383.childNodeList;\n\tv524 = *([v384 @ X0_v71 (System.Collections.ArrayList)]);\n\tv286 = *([v524 @ X8_v50 (Il2CppClass<System.Collections.ArrayList>)+268]);\n\tv516 = System.Collections.ArrayList::get_Count(v384);\n\tv494 = v516 != 2;\n\tif (v494) goto L_01B5;\nL_00E6:\n\tv385 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v383, 1);\n\tv555 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v385, 0);\n\tthis.<data>k__BackingField = v555;\n\tv558 = System.Collections.ArrayList::get_Count(v379.childNodeList);\n\tv112 = v558 != 5;\n\tif (v112) goto L_FFFFFFFF;\n\tv563 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>::.ctor(v563);\n\tthis.<certChain>k__BackingField = v563;\n\tv387 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v379, 3);\n\tv388 = v387.childNodeList;\n\tv186 = *([v388 @ X0_v59 (System.Collections.ArrayList)]);\n\tv286 = *([v186 @ X8_v46 (Il2CppClass<System.Collections.ArrayList>)+268]);\n\tv517 = System.Collections.ArrayList::get_Count(v388);\n\tv520 = v517 == 0;\n\tif (v520) goto L_01B5;\n\tv600 = v387.childNodeList;\nL_0122:\n\tv573 = System.Collections.ArrayList::get_Count(v600);\n\tv113 = v573 <= v81;\n\tif (v113) goto L_FFFFFFFF;\n\tv608 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v387, v81);\n\tv613 = new UnityEngine.Purchasing.Security.X509Cert();\n\tSystem.Object::.ctor(v613);\n\tUnityEngine.Purchasing.Security.X509Cert::ParseNode(v613, v608);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.X509Cert>::Add(this.<certChain>k__BackingField, v613);\n\tv600 = v387.childNodeList;\n\tv81 = v81 + 1;\n\tv636 = v387.childNodeList == 0;\n\tv181 = ~v636;\n\tif (v181) goto L_0122;\n\tgoto L_01A2;\n\tgoto L_014E;\nL_014E:\n\tv389 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v379, v286);\n\tv419 = v389.tag & 0x1F;\n\tv114 = v419 != 0x11;\n\tif (v114) goto L_01B5;\n\tv390 = v389.childNodeList;\n\tv525 = *([v390 @ X0_v42 (System.Collections.ArrayList)]);\n\tv286 = *([v525 @ X8_v34 (Il2CppClass<System.Collections.ArrayList>)+268]);\n\tv518 = System.Collections.ArrayList::get_Count(v390);\n\tv521 = v518 == 0;\n\tif (v521) goto L_01B5;\n\tv584 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.Security.SignerInfo>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.SignerInfo>::.ctor(v584);\n\tthis.<sinfos>k__BackingField = v584;\n\tv625 = v389.childNodeList;\nL_017D:\n\tv478 = System.Collections.ArrayList::get_Count(v625);\n\tv111 = v478 <= v95;\n\tif (v111) goto L_01A4;\n\tv633 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v389, v95);\n\tv176 = new UnityEngine.Purchasing.Security.SignerInfo();\n\tUnityEngine.Purchasing.Security.SignerInfo::.ctor(v176, v633);\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.Security.SignerInfo>::Add(this.<sinfos>k__BackingField, v176);\n\tv625 = v389.childNodeList;\n\tv95 = v95 + 1;\n\tv638 = v389.childNodeList == 0;\n\tv178 = ~v638;\n\tif (v178) goto L_017D;\nL_01A2:\n\tthrow System.NullReferenceException;\nL_01A4:\n\tthis.validStructure = 1;\nL_01B1:\n\treturn;\nL_01B5:\n\tv529 = new UnityEngine.Purchasing.Security.InvalidPKCS7Data();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v529);\n\tthrow v529;\n// 325 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void CheckStructure()
		{
			//IL_010b: Expected I4, but got O
			//IL_014c: Expected I, but got O
			//IL_01ba: Expected I, but got O
			//IL_032e: Expected I, but got O
			//IL_041f: Expected I, but got O
			//IL_056e: Expected I, but got O
			Asn1Node asn1Node = root;
			validStructure = false;
			int num = asn1Node.Tag & 0x1F;
			if (num != 16)
			{
				return;
			}
			int count = asn1Node.childNodeList.Count;
			if (count != 2)
			{
				return;
			}
			Asn1Node childNode = root.GetChildNode(0);
			int num2 = childNode.Tag & 0x1F;
			bool flag = num2 != 6;
			int num3 = 0;
			if (!flag)
			{
				string dataStr = childNode.GetDataStr(pureHexMode: false);
				bool flag2 = dataStr != "1.2.840.113549.1.7.2";
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				num3 = (int)"1.2.840.113549.1.7.2";
				if (!flag4)
				{
					Asn1Node childNode2 = root.GetChildNode(1);
					ArrayList childNodeList = childNode2.childNodeList;
					IntPtr intPtr = (IntPtr)childNodeList;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v411 @ X8_v19 (Il2CppClass<System.Collections.ArrayList>)+268]");
					num3 = 0;
					int count2 = childNodeList.Count;
					if (count2 == 1)
					{
						Asn1Node childNode3 = childNode2.GetChildNode(0);
						ArrayList childNodeList2 = childNode3.childNodeList;
						IntPtr intPtr2 = (IntPtr)childNodeList2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v523 @ X8_v20 (Il2CppClass<System.Collections.ArrayList>)+268]");
						num3 = 0;
						int count3 = childNodeList2.Count;
						if (count3 >= 4)
						{
							int num4 = childNode3.Tag & 0x1F;
							if (num4 == 16)
							{
								Asn1Node childNode4 = childNode3.GetChildNode(0);
								int num5 = childNode4.Tag & 0x1F;
								bool flag5 = num5 != 2;
								num3 = 0;
								if (!flag5)
								{
									Asn1Node childNode5 = childNode3.GetChildNode(1);
									int num6 = childNode5.Tag & 0x1F;
									bool flag6 = num6 != 17;
									num3 = 1;
									if (!flag6)
									{
										Asn1Node childNode6 = childNode3.GetChildNode(2);
										int num7 = childNode6.Tag & 0x1F;
										if (num7 != 16)
										{
											ArrayList childNodeList3 = childNode6.childNodeList;
											IntPtr intPtr3 = (IntPtr)childNodeList3;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ X8_v50 (Il2CppClass<System.Collections.ArrayList>)+268]");
											num3 = 0;
											int count4 = childNodeList3.Count;
											if (count4 != 2)
											{
												goto IL_0672;
											}
										}
										Asn1Node childNode7 = childNode6.GetChildNode(1);
										Asn1Node childNode8 = childNode7.GetChildNode(0);
										data = childNode8;
										int count5 = childNode3.childNodeList.Count;
										if (count5 == 5)
										{
											List<X509Cert> list = new List<X509Cert>();
											certChain = list;
											Asn1Node childNode9 = childNode3.GetChildNode(3);
											ArrayList childNodeList4 = childNode9.childNodeList;
											IntPtr intPtr4 = (IntPtr)childNodeList4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X8_v46 (Il2CppClass<System.Collections.ArrayList>)+268]");
											num3 = 0;
											if (childNodeList4.Count == 0)
											{
												goto IL_0672;
											}
											ArrayList childNodeList5 = childNode9.childNodeList;
											int num8 = 0;
											while (true)
											{
												int count6 = childNodeList5.Count;
												if (count6 <= num8)
												{
													break;
												}
												Asn1Node childNode10 = childNode9.GetChildNode(num8);
												object obj = null;
												((X509Cert)obj).ParseNode(childNode10);
												certChain.Add((X509Cert)obj);
												childNodeList5 = childNode9.childNodeList;
												num8++;
												if (childNode9.childNodeList != null)
												{
													continue;
												}
												goto IL_06a1;
											}
											num3 = 4;
										}
										else
										{
											num3 = 3;
										}
										Asn1Node childNode11 = childNode3.GetChildNode(num3);
										int num9 = childNode11.Tag & 0x1F;
										if (num9 == 17)
										{
											ArrayList childNodeList6 = childNode11.childNodeList;
											IntPtr intPtr5 = (IntPtr)childNodeList6;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v525 @ X8_v34 (Il2CppClass<System.Collections.ArrayList>)+268]");
											num3 = 0;
											if (childNodeList6.Count != 0)
											{
												List<SignerInfo> list2 = new List<SignerInfo>();
												sinfos = list2;
												ArrayList childNodeList7 = childNode11.childNodeList;
												int num10 = 0;
												do
												{
													int count7 = childNodeList7.Count;
													if (count7 > num10)
													{
														Asn1Node childNode12 = childNode11.GetChildNode(num10);
														SignerInfo item = new SignerInfo(childNode12);
														sinfos.Add(item);
														childNodeList7 = childNode11.childNodeList;
														num10++;
														continue;
													}
													validStructure = true;
													return;
												}
												while (childNode11.childNodeList != null);
												goto IL_06a1;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0672;
			IL_0672:
			InvalidPKCS7Data invalidPKCS7Data = (InvalidPKCS7Data)new IAPSecurityException();
			throw invalidPKCS7Data;
			IL_06a1:
			throw new NullReferenceException();
		}
	}
}
