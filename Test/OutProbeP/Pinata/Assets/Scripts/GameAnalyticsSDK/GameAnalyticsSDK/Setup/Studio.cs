using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GameAnalyticsSDK.Setup
{
	[Token(Token = "0x200000E")]
	public class Studio
	{
		[CompilerGenerated]
		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x10")]
		private string _003CName_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x18")]
		private string _003CID_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x20")]
		private List<Game> _003CGames_003Ek__BackingField;

		[Token(Token = "0x17000002")]
		public string Name
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x15A5E3C", Offset = "0x15A5E3C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Name>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0x15A5E44", Offset = "0x15A5E44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Name>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000003")]
		public string ID
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x15A5E4C", Offset = "0x15A5E4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ID;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0x15A5E54", Offset = "0x15A5E54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ID>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CID_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000004")]
		public List<Game> Games
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0x15A5E5C", Offset = "0x15A5E5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Games>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Games;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0x15A5E64", Offset = "0x15A5E64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Games>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CGames_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x15A5E6C", Offset = "0x15A5E6C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<Name>k__BackingField = name;\n\tthis.<ID>k__BackingField = id;\n\tthis.<Games>k__BackingField = games;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Studio(string name, string id, List<Game> games)
		{
			Name = name;
			ID = id;
			Games = games;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x15A5EAC", Offset = "0x15A5EAC", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EE4500]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, addFirstEmpty, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2029820]) = v47;\nL_0018:\n\tv48 = studios == 0;\n\tif (v48) goto L_008F;\n\tv54 = addFirstEmpty == 0;\n\tif (v54) goto L_00A3;\n\tv60 = studios._size + 1;\n\t// 34 NewArr v61 @ X0_v32 (System.String[]), typeof(System.String[]), v60 @ X1_v17 (System.Int32)\n\tv143 = \"-\" == 0;\n\tif (v143) goto L_0031;\n\t// 45 IsInst v245 @ X0_v45, typeof(System.String), \"-\"\nL_0031:\n\tv214 = v61.Length == 0;\n\tif (v214) goto L_010A;\n\tv61[0] = \"-\";\n\tv455 = studios._size;\n\tv168 = studios._size < 1;\n\tif (v168) goto L_0107;\nL_0048:\n\tv456 = v455 < v388;\n\tv407 = ~v456;\n\tv405 = v455 - v388;\n\tv401 = v405 == 0;\n\tv457 = ~v401;\n\tv321 = v407 & v457;\n\tif (v321) goto L_0056;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0056:\n\tv459 = studios._items;\n\tv438 = v459[v388 @ X23_v12 (System.Int32)];\n\tv464 = System.String::Concat(v438.<Name>k__BackingField, v373);\n\tv468 = v464 == 0;\n\tif (v468) goto L_006A;\n\t// 102 IsInst v412 @ X0_v43, typeof(System.String), v464 @ X0_v38 (System.String)\nL_006A:\n\tv388 = v388 + 1;\n\tv474 = v388 < v61.Length;\n\tv352 = ~v474;\n\tif (v352) goto L_010A;\n\tv61[v388 @ X23_v12 (System.Int32)] = v464;\n\tv210 = System.String::Concat(v373, \" \");\n\tv455 = studios._size;\n\tv169 = v388 < studios._size;\n\tif (v169) goto L_0048;\n\tgoto L_0107;\nL_008F:\n\t// 143 NewArr v59 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv83 = \"-\" == 0;\n\tif (v83) goto L_009E;\n\t// 154 IsInst v238 @ X0_v16, typeof(System.String), \"-\"\nL_009E:\n\tv216 = v59.Length == 0;\n\tif (v216) goto L_010A;\n\tv59[0] = \"-\";\n\tgoto L_0107;\nL_00A3:\n\t// 163 NewArr v62 @ X0_v21 (System.String[]), typeof(System.String[]), studios._size (System.Int32)\n\tv266 = studios._size;\n\tv79 = studios._size < 1;\n\tif (v79) goto L_0107;\nL_00B8:\n\tv268 = v266 < v253;\n\tv269 = ~v268;\n\tv270 = v266 - v253;\n\tv272 = v270 == 0;\n\tv277 = ~v272;\n\tv278 = v269 & v277;\n\tif (v278) goto L_00C6;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C6:\n\tv380 = studios._items;\n\tv382 = v380[v253 @ X23_v9 (System.Int32)];\n\tv430 = System.String::Concat(v382.<Name>k__BackingField, v267);\n\tv461 = v430 == 0;\n\tif (v461) goto L_00DC;\n\t// 216 IsInst v413 @ X0_v30, typeof(System.String), v430 @ X0_v25 (System.String)\nL_00DC:\n\tv467 = v253 < v62.Length;\n\tv353 = ~v467;\n\tif (v353) goto L_010A;\n\tv62[v253 @ X23_v9 (System.Int32)] = v430;\n\tv208 = System.String::Concat(v267, \" \");\n\tv266 = studios._size;\n\tv253 = v253 + 1;\n\tv167 = v253 < studios._size;\n\tif (v167) goto L_00B8;\nL_0107:\n\treturn v218;\n\tv359 = new System.NullReferenceException();\nL_010A:\n\tv374 = new System.IndexOutOfRangeException();\n\tgoto L_010F;\n\tv423 = new System.ArrayTypeMismatchException();\nL_010F:\n\tthrow v442;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string[] GetStudioNames(List<Studio> studios, bool addFirstEmpty = true)
		{
			string[] array;
			string[] result;
			if (studios != null)
			{
				if (addFirstEmpty)
				{
					int num = studios.Count + 1;
					array = new string[num];
					if ("-" != null)
					{
						object obj = "-" as string;
					}
					if (array.Length != 0)
					{
						array[0] = "-";
						int count = studios.Count;
						bool flag = studios.Count < 1;
						result = array;
						if (flag)
						{
							goto IL_03fb;
						}
						int num2 = 0;
						string text = "";
						while (true)
						{
							bool flag2 = count < num2;
							bool flag3 = !flag2;
							int num3 = count - num2;
							bool flag4 = num3 == 0;
							bool flag5 = !flag4;
							if (!(flag3 && flag5))
							{
								throw new ArgumentOutOfRangeException();
							}
							Studio[] items = studios._items;
							Studio studio = items[num2];
							string text2 = studio.Name + text;
							if (text2 != null)
							{
								object obj2 = text2 as string;
							}
							num2++;
							if (num2 >= array.Length)
							{
								break;
							}
							array[num2] = text2;
							string text3 = text + " ";
							count = studios.Count;
							bool flag6 = num2 < studios.Count;
							text = text3;
							if (flag6)
							{
								continue;
							}
							goto IL_01fb;
						}
					}
				}
				else
				{
					string[] array2 = new string[studios.Count];
					int count2 = studios.Count;
					bool flag7 = studios.Count < 1;
					result = array2;
					if (flag7)
					{
						goto IL_03fb;
					}
					int num4 = 0;
					string text4 = "";
					while (true)
					{
						bool flag8 = count2 < num4;
						bool flag9 = !flag8;
						int num5 = count2 - num4;
						bool flag10 = num5 == 0;
						bool flag11 = !flag10;
						if (!(flag9 && flag11))
						{
							throw new ArgumentOutOfRangeException();
						}
						Studio[] items2 = studios._items;
						Studio studio2 = items2[num4];
						string text5 = studio2.Name + text4;
						if (text5 != null)
						{
							object obj3 = text5 as string;
						}
						if (num4 >= array2.Length)
						{
							break;
						}
						array2[num4] = text5;
						string text6 = text4 + " ";
						count2 = studios.Count;
						num4++;
						bool flag12 = num4 < studios.Count;
						result = array2;
						text4 = text6;
						if (flag12)
						{
							continue;
						}
						goto IL_03fb;
					}
				}
			}
			else
			{
				string[] array3 = new string[1];
				if ("-" != null)
				{
					object obj4 = "-" as string;
				}
				if (array3.Length != 0)
				{
					array3[0] = "-";
					result = array3;
					goto IL_03fb;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_01fb:
			result = array;
			goto IL_03fb;
			IL_03fb:
			return result;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x15A6134", Offset = "0x15A6134", Length = "0x288")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1ED2630]);\n\tv35 = *([v34 @ X8_v51]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, studios, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2029821]) = v53;\nL_001B:\n\tv54 = studios == 0;\n\tif (v54) goto L_00E6;\n\tv56 = studios._size < index;\n\tv57 = ~v56;\n\tv58 = studios._size - index;\n\tv60 = v58 == 0;\n\tv65 = ~v60;\n\tv66 = v57 & v65;\n\tif (v66) goto L_002C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_002C:\n\tv103 = studios._items;\n\tv96 = v103[index @ X0 (System.Int32)];\n\tv94 = v96.<Games>k__BackingField == 0;\n\tif (v94) goto L_00E6;\n\tv241 = studios._size < index;\n\tv179 = ~v241;\n\tv174 = studios._size - index;\n\tv164 = v174 == 0;\n\tv242 = ~v164;\n\tv139 = v179 & v242;\n\tif (v139) goto L_004B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv300 = studios._items;\nL_004B:\n\tv200 = v298.<Games>k__BackingField;\n\tv219 = v200._size + 1;\n\t// 83 NewArr v234 @ X0_v23 (System.String[]), typeof(System.String[]), v219 @ X1_v11 (System.Int32)\n\tv439 = \"-\" == 0;\n\tif (v439) goto L_0062;\n\t// 94 IsInst v326 @ X0_v40, typeof(System.String), \"-\"\nL_0062:\n\tv289 = v234.Length == 0;\n\tif (v289) goto L_0109;\n\tv234[0] = \"-\";\n\tgoto L_00BC;\nL_006E:\n\tv476 = studios._size < index;\n\tv180 = ~v476;\n\tv175 = studios._size - index;\n\tv165 = v175 == 0;\n\tv477 = ~v165;\n\tv140 = v180 & v477;\n\tif (v140) goto L_0082;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv479 = studios._items;\nL_0082:\n\tv115 = v202.<Games>k__BackingField;\n\tv482 = v115._size < v109;\n\tv181 = ~v482;\n\tv176 = v115._size - v109;\n\tv166 = v176 == 0;\n\tv483 = ~v166;\n\tv141 = v181 & v483;\n\tif (v141) goto L_0094;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0094:\n\tv485 = v115._items;\n\tv203 = v485[v109 @ X23_v9 (System.Int32)];\n\tv489 = System.String::Concat(v203.<Name>k__BackingField, v121);\n\tv490 = v489 == 0;\n\tif (v490) goto L_00A8;\n\t// 164 IsInst v327 @ X0_v36, typeof(System.String), v489 @ X0_v31 (System.String)\nL_00A8:\n\tv493 = v117 < v234.Length;\n\tv284 = ~v493;\n\tif (v284) goto L_0109;\n\tv234[v117 @ X25_v9 (System.Int32)] = v489;\n\tv464 = System.String::Concat(v121, \" \");\n\tv117 = v117 + 1;\nL_00BC:\n\tv469 = studios._size < index;\n\tv182 = ~v469;\n\tv177 = studios._size - index;\n\tv167 = v177 == 0;\n\tv470 = ~v167;\n\tv142 = v182 & v470;\n\tif (v142) goto L_00CA;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00CA:\n\tv472 = studios._items;\n\tv204 = v472[index @ X0 (System.Int32)];\n\tv130 = v204.<Games>k__BackingField;\n\tv109 = v117 - 1;\n\tv349 = v109 < v130._size;\n\tif (v349) goto L_006E;\n\tgoto L_0106;\nL_00E6:\n\t// 230 NewArr v101 @ X0_v14 (System.String[]), typeof(System.String[]), 1\n\tv211 = \"-\" == 0;\n\tif (v211) goto L_00F5;\n\t// 241 IsInst v245 @ X0_v17, typeof(System.String), \"-\"\nL_00F5:\n\tv252 = v101.Length == 0;\n\tif (v252) goto L_0109;\n\tv101[0] = \"-\";\nL_0106:\n\treturn v370;\n\tv240 = new System.NullReferenceException();\nL_0109:\n\tv296 = new System.IndexOutOfRangeException();\n\tgoto L_010E;\n\tv336 = new System.ArrayTypeMismatchException();\nL_010E:\n\tthrow v402;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string[] GetGameNames(int index, List<Studio> studios)
		{
			if (studios != null)
			{
				bool flag = studios.Count < index;
				bool flag2 = !flag;
				int num = studios.Count - index;
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				Studio[] items = studios._items;
				Studio studio = items[index];
				if (studio.Games != null)
				{
					bool flag5 = studios.Count < index;
					bool flag6 = !flag5;
					int num2 = studios.Count - index;
					bool flag7 = num2 == 0;
					bool flag8 = !flag7;
					bool flag9 = flag6 && flag8;
					Studio studio2 = items[index];
					if (!flag9)
					{
						throw new ArgumentOutOfRangeException();
					}
					List<Game> games = studio2.Games;
					int num3 = games.Count + 1;
					string[] array = new string[num3];
					if ("-" != null)
					{
						object obj = "-" as string;
					}
					if (array.Length != 0)
					{
						array[0] = "-";
						int num4 = 1;
						string text = "";
						while (true)
						{
							bool flag10 = studios.Count < index;
							bool flag11 = !flag10;
							int num5 = studios.Count - index;
							bool flag12 = num5 == 0;
							bool flag13 = !flag12;
							if (!(flag11 && flag13))
							{
								throw new ArgumentOutOfRangeException();
							}
							Studio[] items2 = studios._items;
							Studio studio3 = items2[index];
							List<Game> games2 = studio3.Games;
							int num6 = num4 - 1;
							if (num6 < games2.Count)
							{
								bool flag14 = studios.Count < index;
								bool flag15 = !flag14;
								int num7 = studios.Count - index;
								bool flag16 = num7 == 0;
								bool flag17 = !flag16;
								bool flag18 = flag15 && flag17;
								Studio studio4 = items2[index];
								if (!flag18)
								{
									throw new ArgumentOutOfRangeException();
								}
								List<Game> games3 = studio4.Games;
								bool flag19 = games3.Count < num6;
								bool flag20 = !flag19;
								int num8 = games3.Count - num6;
								bool flag21 = num8 == 0;
								bool flag22 = !flag21;
								if (!(flag20 && flag22))
								{
									throw new ArgumentOutOfRangeException();
								}
								Game[] items3 = games3._items;
								Game game = items3[num6];
								string text2 = game.Name + text;
								if (text2 != null)
								{
									object obj2 = text2 as string;
								}
								if (num4 >= array.Length)
								{
									break;
								}
								array[num4] = text2;
								string text3 = text + " ";
								num4++;
								text = text3;
								continue;
							}
							return array;
						}
					}
					goto IL_04f9;
				}
			}
			string[] array2 = new string[1];
			if ("-" != null)
			{
				object obj3 = "-" as string;
			}
			if (array2.Length != 0)
			{
				array2[0] = "-";
				return array2;
			}
			goto IL_04f9;
			IL_04f9:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
