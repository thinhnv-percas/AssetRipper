using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using LipingShare.LCLib.Asn1Processor;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000002")]
	internal class DistinguishedName
	{
		[Token(Token = "0x17000001")]
		public string Country
		{
			[CompilerGenerated]
			[Token(Token = "0x6000001")]
			[Address(RVA = "0x15D43C4", Offset = "0x15D43C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Country>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Country;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000002")]
			[Address(RVA = "0x15D43CC", Offset = "0x15D43CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Country>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Country = value;
			}
		}

		[Token(Token = "0x17000002")]
		public string Organization
		{
			[CompilerGenerated]
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x15D43D4", Offset = "0x15D43D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Organization>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Organization;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x15D43DC", Offset = "0x15D43DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Organization>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Organization = value;
			}
		}

		[Token(Token = "0x17000003")]
		public string OrganizationalUnit
		{
			[CompilerGenerated]
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x15D43E4", Offset = "0x15D43E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<OrganizationalUnit>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OrganizationalUnit;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x15D43EC", Offset = "0x15D43EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<OrganizationalUnit>k__BackingField = value;\n\treturn;\n")]
			set
			{
				OrganizationalUnit = value;
			}
		}

		[Token(Token = "0x17000004")]
		public string Dnq
		{
			[CompilerGenerated]
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x15D43F4", Offset = "0x15D43F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Dnq>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Dnq;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x15D43FC", Offset = "0x15D43FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Dnq>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Dnq = value;
			}
		}

		[Token(Token = "0x17000005")]
		public string State
		{
			[CompilerGenerated]
			[Token(Token = "0x6000009")]
			[Address(RVA = "0x15D4404", Offset = "0x15D4404", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<State>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return State;
			}
			[CompilerGenerated]
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x15D440C", Offset = "0x15D440C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<State>k__BackingField = value;\n\treturn;\n")]
			set
			{
				State = value;
			}
		}

		[Token(Token = "0x17000006")]
		public string CommonName
		{
			[CompilerGenerated]
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x15D4414", Offset = "0x15D4414", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CommonName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CommonName;
			}
			[CompilerGenerated]
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x15D441C", Offset = "0x15D441C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CommonName>k__BackingField = value;\n\treturn;\n")]
			set
			{
				CommonName = value;
			}
		}

		[Token(Token = "0x17000007")]
		public string SerialNumber
		{
			[CompilerGenerated]
			[Token(Token = "0x600000D")]
			[Address(RVA = "0x15D4424", Offset = "0x15D4424", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SerialNumber>k__BackingField = value;\n\treturn;\n")]
			set
			{
				SerialNumber = value;
			}
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x15D442C", Offset = "0x15D442C", Length = "0x4B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv36 = *([1EDF938]);\n\tv37 = *([v36 @ X8_v62]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, n, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2029A25]) = v55;\nL_001E:\n\tSystem.Object::.ctor(this);\n\tv60 = n.tag & 0x1F;\n\tv70 = v60 != 0x10;\n\tif (v70) goto L_01F5;\n\tv436 = n.childNodeList;\nL_003D:\n\tv310 = System.Collections.ArrayList::get_Count(v436);\n\tv283 = v310 <= v255;\n\tif (v283) goto L_01F5;\n\tv364 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, v255);\n\tv372 = v364.tag & 0x1F;\n\tv336 = v372 != 0x11;\n\tif (v336) goto L_01F9;\n\tv365 = v364.childNodeList;\n\tv457 = System.Collections.ArrayList::get_Count(v365);\n\tv337 = v457 != 1;\n\tif (v337) goto L_01F9;\n\tv366 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v364, 0);\n\tv374 = v366.tag & 0x1F;\n\tv338 = v374 != 0x10;\n\tif (v338) goto L_01F9;\n\tv367 = v366.childNodeList;\n\tv458 = System.Collections.ArrayList::get_Count(v367);\n\tv115 = v458 != 2;\n\tif (v115) goto L_01F9;\n\tv473 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v366, 0);\n\tv222 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v366, 1);\n\tv245 = v473.tag & 0x1F;\n\tv116 = v245 != 6;\n\tif (v116) goto L_01F9;\n\tv246 = v222.tag & 0x1F;\n\tv482 = v246 == 0xC;\n\tif (v482) goto L_00C6;\n\tv447 = v246 != 0x13;\n\tif (v447) goto L_01F9;\nL_00C6:\n\tv489 = new LipingShare.LCLib.Asn1Processor.Oid();\n\tSystem.Object::.ctor(v489);\n\tv223 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v473);\n\tv493 = LipingShare.LCLib.Asn1Processor.Oid::Decode(v489, v223);\n\tv496 = new System.Text.UTF8Encoding();\n\tSystem.Text.UTF8Encoding::.ctor(v496);\n\tv498 = v493 == 0;\n\tif (v498) goto L_01E1;\n\tv500 = <PrivateImplementationDetails>::ComputeStringHash(v493);\n\tv567 = v500 < 0xAFCDDCA;\n\tv568 = ~v567;\n\tv569 = v500 - 0xAFCDDCA;\n\tv571 = v569 == 0;\n\tv576 = ~v571;\n\tv121 = v568 & v576;\n\tif (v121) goto L_0120;\n\tv180 = v500 == 0x7FCD911;\n\tif (v180) goto L_018B;\n\tv527 = v500 == 0x9FCDC37;\n\tif (v527) goto L_01A0;\n\tv118 = v500 != 0xAFCDDCA;\n\tif (v118) goto L_01E1;\n\tv533 = System.String::op_Equality(v493, \"2.5.4.6\");\n\tv547 = v533 == 0;\n\tif (v547) goto L_01E1;\n\tv224 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tv534 = System.Text.Encoding::GetString(v496, v224);\n\tthis.<Country>k__BackingField = v534;\n\tgoto L_01E1;\nL_0120:\n\tv580 = v500 < 0x4804A7C1;\n\tv581 = ~v580;\n\tv582 = v500 - 0x4804A7C1;\n\tv584 = v582 == 0;\n\tv589 = ~v584;\n\tv122 = v581 & v589;\n\tif (v122) goto L_015E;\n\tv181 = v500 == 0x4704A62E;\n\tif (v181) goto L_01BD;\n\tv119 = v500 != 0x4804A7C1;\n\tif (v119) goto L_01E1;\n\tv535 = System.String::op_Equality(v493, \"2.5.4.10\");\n\tv548 = v535 == 0;\n\tif (v548) goto L_01E1;\n\tv225 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tv536 = System.Text.Encoding::GetString(v496, v225);\n\tthis.<Organization>k__BackingField = v536;\n\tgoto L_01E1;\nL_015E:\n\tv182 = v500 == 0xB80C13D6;\n\tif (v182) goto L_01D2;\n\tv120 = v500 != 0xFCFCC7C0;\n\tif (v120) goto L_01E1;\n\tv537 = System.String::op_Equality(v493, \"2.5.4.8\");\n\tv549 = v537 == 0;\n\tif (v549) goto L_01E1;\n\tv226 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tv538 = System.Text.Encoding::GetString(v496, v226);\n\tthis.<State>k__BackingField = v538;\n\tgoto L_01E1;\nL_018B:\n\tv539 = System.String::op_Equality(v493, \"2.5.4.3\");\n\tv550 = v539 == 0;\n\tif (v550) goto L_01E1;\n\tv227 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tv540 = System.Text.Encoding::GetString(v496, v227);\n\tthis.<CommonName>k__BackingField = v540;\n\tgoto L_01E1;\nL_01A0:\n\tv541 = System.String::op_Equality(v493, \"2.5.4.5\");\n\tv551 = v541 == 0;\n\tif (v551) goto L_01E1;\n\tv622 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tgoto L_01B5;\n\tv636 = *([v564 @ X8_v56+E0]);\n\tv637 = v636 == 0;\n\tv638 = ~v637;\n\tif (v638) goto L_01B5;\n\tv645 = v564;\n\tv640 = \"il2cpp_codegen_runtime_class_init\"(v645, v520, v506, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_01B5:\n\tv542 = LipingShare.LCLib.Asn1Processor.Asn1Util::ToHexString(v622);\n\tthis.<SerialNumber>k__BackingField = v542;\n\tgoto L_01E1;\nL_01BD:\n\tv543 = System.String::op_Equality(v493, \"2.5.4.11\");\n\tv553 = v543 == 0;\n\tif (v553) goto L_01E1;\n\tv228 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tv544 = System.Text.Encoding::GetString(v496, v228);\n\tthis.<OrganizationalUnit>k__BackingField = v544;\n\tgoto L_01E1;\nL_01D2:\n\tv545 = System.String::op_Equality(v493, \"2.5.4.46\");\n\tv554 = v545 == 0;\n\tif (v554) goto L_01E1;\n\tv229 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v222);\n\tv532 = System.Text.Encoding::GetString(v496, v229);\n\tthis.<Dnq>k__BackingField = v532;\nL_01E1:\n\tv436 = n.childNodeList;\n\tv255 = v255 + 1;\n\tv566 = n.childNodeList == 0;\n\tv231 = ~v566;\n\tif (v231) goto L_003D;\n\tthrow System.NullReferenceException;\nL_01F5:\n\treturn;\nL_01F9:\n\tv463 = new UnityEngine.Purchasing.Security.InvalidX509Data();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v463);\n\tthrow v463;\n// 373 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DistinguishedName(Asn1Node n)
		{
			if ((n.Tag & 0x1F) != 16)
			{
				return;
			}
			ArrayList childNodeList = n.childNodeList;
			int num = 0;
			while (true)
			{
				int count = childNodeList.Count;
				if (count <= num)
				{
					return;
				}
				Asn1Node childNode = n.GetChildNode(num);
				int num2 = childNode.Tag & 0x1F;
				if (num2 == 17)
				{
					ArrayList childNodeList2 = childNode.childNodeList;
					int count2 = childNodeList2.Count;
					if (count2 == 1)
					{
						Asn1Node childNode2 = childNode.GetChildNode(0);
						int num3 = childNode2.Tag & 0x1F;
						if (num3 == 16)
						{
							ArrayList childNodeList3 = childNode2.childNodeList;
							int count3 = childNodeList3.Count;
							if (count3 == 2)
							{
								Asn1Node childNode3 = childNode2.GetChildNode(0);
								Asn1Node childNode4 = childNode2.GetChildNode(1);
								int num4 = childNode3.Tag & 0x1F;
								if (num4 == 6)
								{
									int num5 = childNode4.Tag & 0x1F;
									if (num5 == 12 || num5 == 19)
									{
										Oid oid = new Oid();
										byte[] data = childNode3.Data;
										string text = oid.Decode(data);
										UTF8Encoding uTF8Encoding = new UTF8Encoding();
										if (text != null)
										{
											uint num6 = global::_003CPrivateImplementationDetails_003E.ComputeStringHash(text);
											bool flag = (int)num6 < 184344010;
											bool flag2 = !flag;
											int num7 = (int)(num6 - 184344010);
											bool flag3 = num7 == 0;
											bool flag4 = !flag3;
											if (!(flag2 && flag4))
											{
												switch (num6)
												{
												case 184344010u:
													if (text == "2.5.4.6")
													{
														byte[] data3 = childNode4.Data;
														string country = uTF8Encoding.GetString(data3);
														Country = country;
													}
													break;
												case 134011153u:
													if (text == "2.5.4.3")
													{
														byte[] data4 = childNode4.Data;
														string commonName = uTF8Encoding.GetString(data4);
														CommonName = commonName;
													}
													break;
												case 167566391u:
													if (text == "2.5.4.5")
													{
														byte[] data2 = childNode4.Data;
														string serialNumber = Asn1Util.ToHexString(data2);
														SerialNumber = serialNumber;
													}
													break;
												}
											}
											else
											{
												bool flag5 = (int)num6 < 1208264641;
												bool flag6 = !flag5;
												int num8 = (int)(num6 - 1208264641);
												bool flag7 = num8 == 0;
												bool flag8 = !flag7;
												if (!(flag6 && flag8))
												{
													switch (num6)
													{
													case 1208264641u:
														if (text == "2.5.4.10")
														{
															byte[] data6 = childNode4.Data;
															string organization = uTF8Encoding.GetString(data6);
															Organization = organization;
														}
														break;
													case 1191487022u:
														if (text == "2.5.4.11")
														{
															byte[] data5 = childNode4.Data;
															string organizationalUnit = uTF8Encoding.GetString(data5);
															OrganizationalUnit = organizationalUnit;
														}
														break;
													}
												}
												else if ((int)num6 != 3087799254L)
												{
													if ((int)num6 == 4244424640L && text == "2.5.4.8")
													{
														byte[] data7 = childNode4.Data;
														string state = uTF8Encoding.GetString(data7);
														State = state;
													}
												}
												else if (text == "2.5.4.46")
												{
													byte[] data8 = childNode4.Data;
													string dnq = uTF8Encoding.GetString(data8);
													Dnq = dnq;
												}
											}
										}
										childNodeList = n.childNodeList;
										num++;
										if (n.childNodeList == null)
										{
											break;
										}
										continue;
									}
								}
							}
						}
					}
				}
				InvalidX509Data invalidX509Data = (InvalidX509Data)new IAPSecurityException();
				throw invalidX509Data;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x15D48E0", Offset = "0x15D48E0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = System.String::op_Equality(this.<Organization>k__BackingField, n2.<Organization>k__BackingField);\n\tv36 = v18 == 0;\n\tif (v36) goto L_003D;\n\tv40 = System.String::op_Equality(this.<OrganizationalUnit>k__BackingField, n2.<OrganizationalUnit>k__BackingField);\n\tv54 = v40 == 0;\n\tif (v54) goto L_003D;\n\tv50 = System.String::op_Equality(this.<Dnq>k__BackingField, n2.<Dnq>k__BackingField);\n\tv55 = v50 == 0;\n\tif (v55) goto L_003D;\n\tv51 = System.String::op_Equality(this.<Country>k__BackingField, n2.<Country>k__BackingField);\n\tv56 = v51 == 0;\n\tif (v56) goto L_003D;\n\tv52 = System.String::op_Equality(this.<State>k__BackingField, n2.<State>k__BackingField);\n\tv57 = v52 == 0;\n\tif (v57) goto L_003D;\n\treturnVal3 = System.String::op_Equality(this.<CommonName>k__BackingField, n2.<CommonName>k__BackingField);\n\treturn returnVal3;\nL_003D:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Equals(DistinguishedName n2)
		{
			if (Organization == n2.Organization && OrganizationalUnit == n2.OrganizationalUnit && Dnq == n2.Dnq && Country == n2.Country && State == n2.State)
			{
				return CommonName == n2.CommonName;
			}
			return false;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x15D498C", Offset = "0x15D498C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EBE0E8]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029A26]) = v40;\nL_0018:\n\t// 24 NewArr v45 @ X0_v3 (System.String[]), typeof(System.String[]), 8\n\tv51 = \"CN: \" == 0;\n\tif (v51) goto L_0026;\n\t// 35 IsInst v99 @ X0_v37, typeof(System.String), \"CN: \"\nL_0026:\n\tv225 = v45.Length;\n\tv106 = v45.Length == 0;\n\tif (v106) goto L_00DC;\n\tv45[0] = \"CN: \";\n\tv109 = this.<CommonName>k__BackingField == 0;\n\tif (v109) goto L_0035;\n\t// 49 IsInst v274 @ X0_v36, typeof(System.String), this.<CommonName>k__BackingField (System.String)\n\tv225 = v45.Length;\nL_0035:\n\tv301 = v225 < 1;\n\tv175 = ~v301;\n\tv167 = v225 - 1;\n\tv151 = v167 == 0;\n\tv302 = ~v175;\n\tv111 = v302 | v151;\n\tif (v111) goto L_00DC;\n\tv45[1] = this.<CommonName>k__BackingField;\n\tv307 = \"\\nON: \" == 0;\n\tif (v307) goto L_004D;\n\t// 73 IsInst v275 @ X0_v34, typeof(System.String), \"\nON: \"\n\tv225 = v45.Length;\nL_004D:\n\tv309 = v225 < 2;\n\tv176 = ~v309;\n\tv168 = v225 - 2;\n\tv152 = v168 == 0;\n\tv310 = ~v176;\n\tv112 = v310 | v152;\n\tif (v112) goto L_00DC;\n\tv45[2] = \"\\nON: \";\n\tv311 = this.<Organization>k__BackingField == 0;\n\tif (v311) goto L_0065;\n\t// 97 IsInst v276 @ X0_v33, typeof(System.String), this.<Organization>k__BackingField (System.String)\n\tv225 = v45.Length;\nL_0065:\n\tv314 = v225 < 3;\n\tv177 = ~v314;\n\tv169 = v225 - 3;\n\tv153 = v169 == 0;\n\tv315 = ~v177;\n\tv113 = v315 | v153;\n\tif (v113) goto L_00DC;\n\tv45[3] = this.<Organization>k__BackingField;\n\tv318 = \"\\nUnit Name: \" == 0;\n\tif (v318) goto L_007D;\n\t// 121 IsInst v277 @ X0_v31, typeof(System.String), \"\nUnit Name: \"\n\tv225 = v45.Length;\nL_007D:\n\tv320 = v225 < 4;\n\tv178 = ~v320;\n\tv170 = v225 - 4;\n\tv154 = v170 == 0;\n\tv321 = ~v178;\n\tv114 = v321 | v154;\n\tif (v114) goto L_00DC;\n\tv45[4] = \"\\nUnit Name: \";\n\tv322 = this.<OrganizationalUnit>k__BackingField == 0;\n\tif (v322) goto L_0095;\n\t// 145 IsInst v278 @ X0_v30, typeof(System.String), this.<OrganizationalUnit>k__BackingField (System.String)\n\tv225 = v45.Length;\nL_0095:\n\tv325 = v225 < 5;\n\tv179 = ~v325;\n\tv171 = v225 - 5;\n\tv155 = v171 == 0;\n\tv326 = ~v179;\n\tv115 = v326 | v155;\n\tif (v115) goto L_00DC;\n\tv45[5] = this.<OrganizationalUnit>k__BackingField;\n\tv329 = \"\\nCountry: \" == 0;\n\tif (v329) goto L_00AD;\n\t// 169 IsInst v279 @ X0_v28, typeof(System.String), \"\nCountry: \"\n\tv225 = v45.Length;\nL_00AD:\n\tv331 = v225 < 6;\n\tv180 = ~v331;\n\tv172 = v225 - 6;\n\tv156 = v172 == 0;\n\tv332 = ~v180;\n\tv116 = v332 | v156;\n\tif (v116) goto L_00DC;\n\tv45[6] = \"\\nCountry: \";\n\tv333 = this.<Country>k__BackingField == 0;\n\tif (v333) goto L_00C5;\n\t// 193 IsInst v280 @ X0_v27, typeof(System.String), this.<Country>k__BackingField (System.String)\n\tv225 = v45.Length;\nL_00C5:\n\tv336 = v225 < 7;\n\tv181 = ~v336;\n\tv173 = v225 - 7;\n\tv157 = v173 == 0;\n\tv337 = ~v181;\n\tv117 = v337 | v157;\n\tif (v117) goto L_00DC;\n\tv45[7] = this.<Country>k__BackingField;\n\treturnVal2 = System.String::Concat(v45);\n\treturn returnVal2;\nL_00DC:\n\tv226 = new System.IndexOutOfRangeException();\n\tgoto L_00E1;\n\tv298 = new System.ArrayTypeMismatchException();\nL_00E1:\n\tthrow v304;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 122 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			//IL_0040: Expected O, but got I4
			//IL_0324: Expected O, but got I
			//IL_00af: Expected O, but got I4
			//IL_0382: Expected O, but got I
			//IL_0103: Expected O, but got I4
			//IL_03e0: Expected O, but got I
			//IL_0158: Expected O, but got I4
			//IL_043e: Expected O, but got I
			//IL_01ac: Expected O, but got I4
			//IL_049c: Expected O, but got I
			//IL_0201: Expected O, but got I4
			//IL_04fa: Expected O, but got I
			//IL_0255: Expected O, but got I4
			//IL_0558: Expected O, but got I
			//IL_02aa: Expected O, but got I4
			string[] array = new string[8];
			if ("CN: " != null)
			{
				object obj = "CN: " as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = "CN: ";
				if (CommonName != null)
				{
					object obj3 = CommonName as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = CommonName;
					if ("\nON: " != null)
					{
						object obj5 = "\nON: " as string;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "\nON: ";
						if (Organization != null)
						{
							object obj7 = Organization as string;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = Organization;
							if ("\nUnit Name: " != null)
							{
								object obj9 = "\nUnit Name: " as string;
								obj2 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj2 < 4L;
							bool flag14 = !flag13;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "\nUnit Name: ";
								if (OrganizationalUnit != null)
								{
									object obj11 = OrganizationalUnit as string;
									obj2 = array.Length;
								}
								bool flag17 = (long)(IntPtr)obj2 < 5L;
								bool flag18 = !flag17;
								object obj12 = (long)(IntPtr)obj2 - 5L;
								bool flag19 = obj12 == null;
								bool flag20 = !flag18;
								if (!(flag20 || flag19))
								{
									array[5] = OrganizationalUnit;
									if ("\nCountry: " != null)
									{
										object obj13 = "\nCountry: " as string;
										obj2 = array.Length;
									}
									bool flag21 = (long)(IntPtr)obj2 < 6L;
									bool flag22 = !flag21;
									object obj14 = (long)(IntPtr)obj2 - 6L;
									bool flag23 = obj14 == null;
									bool flag24 = !flag22;
									if (!(flag24 || flag23))
									{
										array[6] = "\nCountry: ";
										if (Country != null)
										{
											object obj15 = Country as string;
											obj2 = array.Length;
										}
										bool flag25 = (long)(IntPtr)obj2 < 7L;
										bool flag26 = !flag25;
										object obj16 = (long)(IntPtr)obj2 - 7L;
										bool flag27 = obj16 == null;
										bool flag28 = !flag26;
										if (!(flag28 || flag27))
										{
											array[7] = Country;
											return string.Concat(array);
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
