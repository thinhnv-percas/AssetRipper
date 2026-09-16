using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using AssetRipperInjected;
using Cpp2ILInjected;
using LipingShare.LCLib.Asn1Processor;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x200000C")]
	internal class RSAKey
	{
		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x724DC8", Offset = "0x724DC8")]
		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x10")]
		private RSACryptoServiceProvider _003Crsa_003Ek__BackingField;

		[Token(Token = "0x17000016")]
		public RSACryptoServiceProvider rsa
		{
			[CompilerGenerated]
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x15D5B48", Offset = "0x15D5B48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<rsa>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return rsa;
			}
			[CompilerGenerated]
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x15D5B50", Offset = "0x15D5B50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<rsa>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003Crsa_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x15D5B58", Offset = "0x15D5B58", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv17 = UnityEngine.Purchasing.Security.RSAKey::ParseNode(this, n);\n\tthis.<rsa>k__BackingField = v17;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RSAKey(Asn1Node n)
		{
			RSACryptoServiceProvider rSACryptoServiceProvider = ParseNode(n);
			rsa = rSACryptoServiceProvider;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x15D4CBC", Offset = "0x15D4CBC", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EE5828]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, data, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2029A2F]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tv49 = new System.IO.MemoryStream();\n\tSystem.IO.MemoryStream::.ctor(v49, v108);\n\tv56 = new LipingShare.LCLib.Asn1Processor.Asn1Parser();\n\tLipingShare.LCLib.Asn1Processor.Asn1Parser::.ctor(v56);\n\tv59 = v56 == 0;\n\tif (v59) goto L_007A;\n\tLipingShare.LCLib.Asn1Processor.Asn1Parser::LoadData(v56, v49);\n\tv122 = UnityEngine.Purchasing.Security.RSAKey::ParseNode(this, v56.rootNode);\n\tthis.<rsa>k__BackingField = v122;\n\tv125 = v49 == 0;\n\tif (v125) goto L_0063;\nL_003B:\n\tgoto L_0062;\n\tv197 = *([v162 @ X8_v10+B0]);\n\tv198 = 0;\n\tv199 = v197 + 8;\n\tv201 = *([v245 @ X11_v8-8]);\n\tv251 = v201 == v165;\n\tif (v251) goto L_005B;\n\tv223 = v246 + 1;\n\tv283 = v223 < v164;\n\tv219 = ~v283;\n\tv221 = v245 + 0x10;\n\tv203 = ~v219;\n\tif (v203) goto L_FFFFFFFF;\n\tv224 = v52;\n\tv225 = 0;\n\tv226 = 0x8909C4(v224, v165, v225, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0062;\nL_005B:\n\tv284 = *([v245 @ X11_v8]);\n\tv285 = v284 << 4;\n\tv286 = v162 + v285;\n\tv287 = v286 + 0x130;\nL_0062:\n\tSystem.IDisposable::Dispose(v49);\nL_0063:\n\tv194 = v105 + 1;\n\tv84 = v194 == 0;\n\tv69 = ~v84;\n\tif (v69) goto L_0074;\n\tv227 = v115 == 0;\n\tv113 = ~v227;\n\tif (v113) goto L_FFFFFFFF;\nL_0074:\n\treturn;\n\tthrow System.TypeLoadException;\nL_007A:\n\tv119 = new System.NullReferenceException();\n\tgoto L_0087;\n\tgoto L_0087;\n\tgoto L_0087;\nL_0087:\n\tv135 = v108 != 1;\n\tif (v135) goto L_0091;\n\tv195 = 0x6D2BC0(v119, v108, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv158 = *([v195 @ X0_v15]);\n\tv155 = 0x6D2490(v195, v108, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv282 = v49 == 0;\n\tv157 = ~v282;\n\tif (v157) goto L_003B;\n\tgoto L_0063;\nL_0091:\n\tv196 = 0x6D2380(v119, v108, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RSAKey(byte[] data)
		{
			//IL_0120: Expected I4, but got O
			//IL_0176: Expected I4, but got O
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
				rsa = ParseNode(asn1Parser.RootNode);
				bool flag = memoryStream == null;
				num = 0;
				num2 = 0;
				num3 = 0;
				num4 = 0;
				if (flag)
				{
					goto IL_01a4;
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
				num2 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				bool flag2 = memoryStream != null;
				num = -1;
				if (!flag2)
				{
					num3 = -1;
					num4 = (int)obj;
					goto IL_01a4;
				}
			}
			((IDisposable)memoryStream).Dispose();
			num3 = num;
			num4 = num2;
			goto IL_01a4;
			IL_01a4:
			if (num3 + 1 != 0 || num4 == 0)
			{
				return;
			}
			array = null;
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x15D4E38", Offset = "0x15D4E38", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EB07F0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, message, signature, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029A30]) = v44;\nL_001A:\n\tv48 = new System.Security.Cryptography.SHA1Managed();\n\tSystem.Security.Cryptography.SHA1Managed::.ctor(v48);\n\tv55 = System.Security.Cryptography.HashAlgorithm::ComputeHash(v48, message);\n\treturnVal2 = System.Security.Cryptography.RSACryptoServiceProvider::VerifyHash(this.<rsa>k__BackingField, v55, 0, signature);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Verify(byte[] message, byte[] signature)
		{
			SHA1Managed sHA1Managed = new SHA1Managed();
			byte[] rgbHash = sHA1Managed.ComputeHash(message);
			return rsa.VerifyHash(rgbHash, null, signature);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x15D5B90", Offset = "0x15D5B90", Length = "0x28C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EBE098]);\n\tv21 = *([v20 @ X8_v36]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, n, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029A31]) = v40;\nL_0017:\n\tv43 = n.tag & 0x1F;\n\tv53 = v43 != 0x10;\n\tif (v53) goto L_00ED;\n\tv123 = n.childNodeList;\n\tv173 = System.Collections.ArrayList::get_Count(v123);\n\tv136 = v173 != 2;\n\tif (v136) goto L_00ED;\n\tv174 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 0);\n\tv188 = v174.tag & 0x1F;\n\tv137 = v188 != 0x10;\n\tif (v137) goto L_00ED;\n\tv223 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 0);\n\tv175 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v223, 0);\n\tv189 = v175.tag & 0x1F;\n\tv138 = v189 != 6;\n\tif (v138) goto L_00ED;\n\tv224 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 0);\n\tv225 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v224, 0);\n\tv289 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetDataStr(v225, 0);\n\tv176 = System.String::op_Equality(v289, \"1.2.840.113549.1.1.1\");\n\tv181 = v176 == 0;\n\tif (v181) goto L_00ED;\n\tv177 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 1);\n\tv191 = v177.tag & 0x1F;\n\tv139 = v191 != 3;\n\tif (v139) goto L_00ED;\n\tv226 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(n, 1);\n\tv227 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v226, 0);\n\tv228 = v227.childNodeList;\n\tv178 = System.Collections.ArrayList::get_Count(v228);\n\tv74 = v178 != 2;\n\tif (v74) goto L_00ED;\n\tv229 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v227, 0);\n\tv230 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v229);\n\tv301 = v230.Length - 1;\n\t// 172 NewArr v302 @ X0_v34 (System.Byte[]), typeof(System.Byte[]), v301 @ X1_v18\n\tv59 = v230.Length - 1;\n\tSystem.Array::Copy(v230, 1, v302, 0, v59);\n\tgoto L_00C4;\n\tv313 = *([v309 @ X0_v36+E0]);\n\tv314 = v313 == 0;\n\tv315 = ~v314;\n\tif (v315) goto L_00C4;\n\tv317 = \"il2cpp_codegen_runtime_class_init\"(v309, v305, v203, v57, v59, v55, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_00C4:\n\tv321 = System.Convert::ToBase64String(v302);\n\tv231 = LipingShare.LCLib.Asn1Processor.Asn1Node::GetChildNode(v227, 1);\n\tv323 = LipingShare.LCLib.Asn1Processor.Asn1Node::get_Data(v231);\n\tv325 = System.Convert::ToBase64String(v323);\n\tv329 = new System.Security.Cryptography.RSACryptoServiceProvider();\n\tSystem.Security.Cryptography.RSACryptoServiceProvider::.ctor(v329);\n\tv110 = UnityEngine.Purchasing.Security.RSAKey::ToXML(v329, v321, v325);\n\tv333 = System.Security.Cryptography.RSA::FromXmlString(v329, v110);\n\treturn v329;\nL_00ED:\n\tv196 = new UnityEngine.Purchasing.Security.InvalidRSAData();\n\tUnityEngine.Purchasing.Security.IAPSecurityException::.ctor(v196);\n\tthrow v196;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 185 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal RSACryptoServiceProvider ParseNode(Asn1Node n)
		{
			//IL_028f: Expected O, but got I4
			int num = n.Tag & 0x1F;
			if (num == 16)
			{
				ArrayList childNodeList = n.childNodeList;
				int count = childNodeList.Count;
				if (count == 2)
				{
					Asn1Node childNode = n.GetChildNode(0);
					int num2 = childNode.Tag & 0x1F;
					if (num2 == 16)
					{
						Asn1Node childNode2 = n.GetChildNode(0);
						Asn1Node childNode3 = childNode2.GetChildNode(0);
						int num3 = childNode3.Tag & 0x1F;
						if (num3 == 6)
						{
							Asn1Node childNode4 = n.GetChildNode(0);
							Asn1Node childNode5 = childNode4.GetChildNode(0);
							string dataStr = childNode5.GetDataStr(pureHexMode: false);
							if (dataStr == "1.2.840.113549.1.1.1")
							{
								Asn1Node childNode6 = n.GetChildNode(1);
								int num4 = childNode6.Tag & 0x1F;
								if (num4 == 3)
								{
									Asn1Node childNode7 = n.GetChildNode(1);
									Asn1Node childNode8 = childNode7.GetChildNode(0);
									ArrayList childNodeList2 = childNode8.childNodeList;
									int count2 = childNodeList2.Count;
									if (count2 == 2)
									{
										Asn1Node childNode9 = childNode8.GetChildNode(0);
										byte[] data = childNode9.Data;
										object obj = data.Length - 1;
										byte[] array = new byte[obj];
										int length = data.Length - 1;
										Array.Copy(data, 1, array, 0, length);
										string modulus = Convert.ToBase64String(array);
										Asn1Node childNode10 = childNode8.GetChildNode(1);
										byte[] data2 = childNode10.Data;
										string exponent = Convert.ToBase64String(data2);
										RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
										string xmlString = ((RSAKey)(object)rSACryptoServiceProvider).ToXML(modulus, exponent);
										rSACryptoServiceProvider.FromXmlString(xmlString);
										return rSACryptoServiceProvider;
									}
								}
							}
						}
					}
				}
			}
			InvalidRSAData invalidRSAData = (InvalidRSAData)new IAPSecurityException();
			throw invalidRSAData;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x15D5E1C", Offset = "0x15D5E1C", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F0D270]);\n\tv25 = *([v24 @ X8_v27]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, modulus, exponent, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2029A32]) = v43;\nL_001A:\n\t// 26 NewArr v48 @ X0_v3 (System.String[]), typeof(System.String[]), 5\n\tv54 = \"<RSAKeyValue><Modulus>\" == 0;\n\tif (v54) goto L_0028;\n\t// 37 IsInst v103 @ X0_v28, typeof(System.String), \"<RSAKeyValue><Modulus>\"\nL_0028:\n\tv183 = v48.Length;\n\tv110 = v48.Length == 0;\n\tif (v110) goto L_0096;\n\tv48[0] = \"<RSAKeyValue><Modulus>\";\n\tv112 = modulus == 0;\n\tif (v112) goto L_0036;\n\t// 50 IsInst v231 @ X0_v27, typeof(System.String), modulus @ X1 (System.String)\n\tv183 = v48.Length;\nL_0036:\n\tv250 = v183 < 1;\n\tv154 = ~v250;\n\tv149 = v183 - 1;\n\tv139 = v149 == 0;\n\tv251 = ~v154;\n\tv114 = v251 | v139;\n\tif (v114) goto L_0096;\n\tv48[1] = modulus;\n\tv256 = \"</Modulus><Exponent>\" == 0;\n\tif (v256) goto L_004E;\n\t// 74 IsInst v232 @ X0_v25, typeof(System.String), \"</Modulus><Exponent>\"\n\tv183 = v48.Length;\nL_004E:\n\tv258 = v183 < 2;\n\tv155 = ~v258;\n\tv150 = v183 - 2;\n\tv140 = v150 == 0;\n\tv259 = ~v155;\n\tv115 = v259 | v140;\n\tif (v115) goto L_0096;\n\tv48[2] = \"</Modulus><Exponent>\";\n\tv260 = exponent == 0;\n\tif (v260) goto L_0065;\n\t// 97 IsInst v233 @ X0_v24, typeof(System.String), exponent @ X2 (System.String)\n\tv183 = v48.Length;\nL_0065:\n\tv263 = v183 < 3;\n\tv156 = ~v263;\n\tv151 = v183 - 3;\n\tv141 = v151 == 0;\n\tv264 = ~v156;\n\tv116 = v264 | v141;\n\tif (v116) goto L_0096;\n\tv48[3] = exponent;\n\tv267 = \"</Exponent></RSAKeyValue>\" == 0;\n\tif (v267) goto L_007D;\n\t// 121 IsInst v234 @ X0_v22, typeof(System.String), \"</Exponent></RSAKeyValue>\"\n\tv183 = v48.Length;\nL_007D:\n\tv269 = v183 < 4;\n\tv157 = ~v269;\n\tv152 = v183 - 4;\n\tv142 = v152 == 0;\n\tv270 = ~v157;\n\tv117 = v270 | v142;\n\tif (v117) goto L_0096;\n\tv48[4] = \"</Exponent></RSAKeyValue>\";\n\treturnVal2 = System.String::Concat(v48);\n\treturn returnVal2;\nL_0096:\n\tv184 = new System.IndexOutOfRangeException();\n\tgoto L_009B;\n\tv247 = new System.ArrayTypeMismatchException();\nL_009B:\n\tthrow v253;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private string ToXML(string modulus, string exponent)
		{
			//IL_0040: Expected O, but got I4
			//IL_0219: Expected O, but got I
			//IL_00ab: Expected O, but got I4
			//IL_0277: Expected O, but got I
			//IL_00fd: Expected O, but got I4
			//IL_02d5: Expected O, but got I
			//IL_014e: Expected O, but got I4
			//IL_0333: Expected O, but got I
			//IL_01a0: Expected O, but got I4
			string[] array = new string[5];
			if ("<RSAKeyValue><Modulus>" != null)
			{
				object obj = "<RSAKeyValue><Modulus>" as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = "<RSAKeyValue><Modulus>";
				if (modulus != null)
				{
					object obj3 = modulus as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = modulus;
					if ("</Modulus><Exponent>" != null)
					{
						object obj5 = "</Modulus><Exponent>" as string;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "</Modulus><Exponent>";
						if (exponent != null)
						{
							object obj7 = exponent as string;
							obj2 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj2 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj2 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = exponent;
							if ("</Exponent></RSAKeyValue>" != null)
							{
								object obj9 = "</Exponent></RSAKeyValue>" as string;
								obj2 = array.Length;
							}
							bool flag13 = (long)(IntPtr)obj2 < 4L;
							bool flag14 = !flag13;
							object obj10 = (long)(IntPtr)obj2 - 4L;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = "</Exponent></RSAKeyValue>";
								return string.Concat(array);
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
