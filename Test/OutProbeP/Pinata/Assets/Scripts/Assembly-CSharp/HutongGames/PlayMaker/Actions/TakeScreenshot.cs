using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7538C4", Offset = "0x7538C4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7538C4", Offset = "0x7538C4")]
	[Token(Token = "0x200016E")]
	public class TakeScreenshot : FsmStateAction
	{
		[Token(Token = "0x200047F")]
		public enum Destination
		{
			[Token(Token = "0x4002148")]
			MyPictures = 0,
			[Token(Token = "0x4002149")]
			PersistentDataPath = 1,
			[Token(Token = "0x400214A")]
			CustomPath = 2
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8F68", Offset = "0x7A8F68")]
		[Token(Token = "0x4001233")]
		[FieldOffset(Offset = "0x4C")]
		public Destination destination;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8FA0", Offset = "0x7A8FA0")]
		[Token(Token = "0x4001234")]
		[FieldOffset(Offset = "0x50")]
		public FsmString customPath;

		[RequiredField]
		[Token(Token = "0x4001235")]
		[FieldOffset(Offset = "0x58")]
		public FsmString filename;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A8FE8", Offset = "0x7A8FE8")]
		[Token(Token = "0x4001236")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool autoNumber;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9020", Offset = "0x7A9020")]
		[Token(Token = "0x4001237")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt superSize;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A9058", Offset = "0x7A9058")]
		[Token(Token = "0x4001238")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool debugLog;

		[Token(Token = "0x4001239")]
		[FieldOffset(Offset = "0x78")]
		private int screenshotCount;

		[Token(Token = "0x6000801")]
		[Address(RVA = "0x99F328", Offset = "0x99F328", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EED150]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217C2]) = v38;\nL_0013:\n\tthis.destination = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.superSize = 0;\n\tthis.debugLog = 0;\n\tthis.filename = v43;\n\tthis.autoNumber = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			destination = default(Destination);
			FsmString fsmString = "";
			superSize = null;
			debugLog = null;
			filename = fsmString;
			autoNumber = null;
		}

		[Token(Token = "0x6000802")]
		[Address(RVA = "0x99F388", Offset = "0x99F388", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1ED1008]);\n\tv29 = *([v28 @ X8_v43]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20217C3]) = v48;\nL_001C:\n\tv52 = HutongGames.PlayMaker.FsmString::get_Value(this.filename);\n\tv170 = System.String::IsNullOrEmpty(v52);\n\tv233 = v170 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_0126;\n\tv160 = this.destination;\n\tv109 = this.destination == 2;\n\tif (v109) goto L_0046;\n\tv108 = this.destination == 1;\n\tif (v108) goto L_004C;\n\tv383 = this.destination == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_FFFFFFFF;\n\tv392 = System.Environment::GetFolderPath(0x27);\n\tv390 = v392 == 0;\n\tv150 = ~v390;\n\tif (v150) goto L_005D;\n\tgoto L_0129;\nL_0046:\n\tv392 = HutongGames.PlayMaker.FsmString::get_Value(this.customPath);\n\tv389 = v392 == 0;\n\tv152 = ~v389;\n\tif (v152) goto L_005D;\n\tgoto L_0129;\nL_004C:\n\tv392 = UnityEngine.Application::get_persistentDataPath();\n\tv388 = v392 == 0;\n\tv153 = ~v388;\n\tif (v153) goto L_005D;\n\tgoto L_0129;\nL_005D:\n\tv401 = System.String::Replace(v392, \"\\\\\", \"/\");\n\tv345 = System.String::Concat(v401, \"/\");\n\tv404 = HutongGames.PlayMaker.FsmString::get_Value(this.filename);\n\tv346 = System.String::Concat(v345, v404, \".png\");\n\tv409 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoNumber);\n\tv411 = v409 == 0;\n\tif (v411) goto L_00F5;\n\tv414 = System.IO.File::Exists(v346);\n\tv430 = v414 == 0;\n\tif (v430) goto L_00F5;\nL_0085:\n\tv162 = this.screenshotCount + 1;\n\tthis.screenshotCount = v162;\n\t// 136 NewArr v145 @ X0_v42 (System.Object[]), typeof(System.Object[]), 4\n\tv467 = v345 == 0;\n\tif (v467) goto L_0094;\n\t// 145 IsInst v216 @ X0_v63, typeof(System.Object), v345 @ X0_v17 (System.String)\nL_0094:\n\tv160 = v145.Length;\n\tv479 = v145.Length == 0;\n\tif (v479) goto L_0127;\n\tv145[0] = v345;\n\tv495 = HutongGames.PlayMaker.FsmString::get_Value(this.filename);\n\tv496 = v495 == 0;\n\tif (v496) goto L_00A6;\n\t// 163 IsInst v217 @ X0_v61, typeof(System.Object), v495 @ X0_v47 (System.String)\nL_00A6:\n\tv160 = v145.Length;\n\tv499 = v145.Length < 1;\n\tv208 = ~v499;\n\tv205 = v145.Length - 1;\n\tv199 = v205 == 0;\n\tv500 = ~v208;\n\tv175 = v500 | v199;\n\tif (v175) goto L_0127;\n\tv145[1] = v495;\n\tv501 = this.screenshotCount;\n\t// 184 Box v504 @ X0_v50, typeof(System.Int32), &v501 @ X8_v29 (System.Int32)\n\tv505 = v504 == 0;\n\tif (v505) goto L_00C2;\n\t// 191 IsInst v218 @ X0_v59, typeof(System.Object), v504 @ X0_v50\nL_00C2:\n\tv160 = v145.Length;\n\tv508 = v145.Length < 2;\n\tv209 = ~v508;\n\tv206 = v145.Length - 2;\n\tv200 = v206 == 0;\n\tv509 = ~v209;\n\tv176 = v509 | v200;\n\tif (v176) goto L_0127;\n\tv145[2] = v504;\n\tv511 = \".png\" == 0;\n\tif (v511) goto L_00D9;\n\t// 213 IsInst v219 @ X0_v57, typeof(System.Object), \".png\"\n\tv160 = v145.Length;\nL_00D9:\n\tv513 = v160 < 3;\n\tv424 = ~v513;\n\tv423 = v160 - 3;\n\tv421 = v423 == 0;\n\tv514 = ~v424;\n\tv415 = v514 | v421;\n\tif (v415) goto L_0127;\n\tv145[3] = \".png\";\n\tv517 = System.String::Concat(v145);\n\tv427 = System.IO.File::Exists(v517);\n\tv519 = v427 == 0;\n\tv429 = ~v519;\n\tif (v429) goto L_0085;\nL_00F5:\n\tv434 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugLog);\n\tv438 = v434 == 0;\n\tif (v438) goto L_0114;\n\tv451 = System.String::Concat(\"TakeScreenshot: \", v75);\n\tgoto L_010F;\n\tv468 = *([v458 @ X8_v20+E0]);\n\tv469 = v468 == 0;\n\tv470 = ~v469;\n\tif (v470) goto L_010F;\n\tv480 = v458;\n\tv472 = \"il2cpp_codegen_runtime_class_init\"(v480, v448, v449, v82, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_010F:\n\tUnityEngine.Debug::Log(v451);\nL_0114:\n\tv466 = HutongGames.PlayMaker.FsmInt::get_Value(this.superSize);\n\tUnityEngine.ScreenCapture::CaptureScreenshot(v75, v466);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0126:\n\treturn;\nL_0127:\n\tv267 = new System.IndexOutOfRangeException();\n\tgoto L_012D;\nL_0129:\n\tv169 = new System.NullReferenceException();\n\tv231 = new System.ArrayTypeMismatchException();\nL_012D:\n\tthrow v231;\n\tthrow System.NullReferenceException;\n// 185 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_031c: Expected O, but got I4
			//IL_03df: Expected O, but got I4
			//IL_059d: Expected O, but got I4
			string value = filename.Value;
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			Destination destination = this.destination;
			string text;
			if (this.destination != Destination.CustomPath)
			{
				if (this.destination != Destination.PersistentDataPath)
				{
					if (this.destination == Destination.MyPictures)
					{
						text = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
						if (text == null)
						{
							goto IL_0554;
						}
					}
					else
					{
						text = "";
					}
				}
				else
				{
					text = Application.persistentDataPath;
					if (text == null)
					{
						goto IL_0554;
					}
				}
			}
			else
			{
				text = customPath.Value;
				if (text == null)
				{
					goto IL_0554;
				}
			}
			string text2 = text.Replace("\\", "/");
			string text3 = text2 + "/";
			string value2 = filename.Value;
			string text4 = text3 + value2 + ".png";
			bool value3 = autoNumber.Value;
			bool flag = !value3;
			string text5 = text4;
			if (!flag)
			{
				bool flag2 = File.Exists(text4);
				bool flag3 = !flag2;
				text5 = text4;
				if (!flag3)
				{
					while (true)
					{
						int num = screenshotCount + 1;
						screenshotCount = num;
						object[] array = new object[4];
						if (text3 != null)
						{
							object obj = text3 as object;
						}
						destination = (Destination)array.Length;
						if (array.Length == 0)
						{
							break;
						}
						array[0] = text3;
						string value4 = filename.Value;
						if (value4 != null)
						{
							object obj2 = value4 as object;
						}
						destination = (Destination)array.Length;
						bool flag4 = array.Length < 1;
						bool flag5 = !flag4;
						object obj3 = array.Length - 1;
						bool flag6 = obj3 == null;
						bool flag7 = !flag5;
						if (flag7 || flag6)
						{
							break;
						}
						array[1] = value4;
						int num2 = screenshotCount;
						object obj4 = num2;
						if (obj4 != null)
						{
							object obj5 = obj4 as object;
						}
						destination = (Destination)array.Length;
						bool flag8 = array.Length < 2;
						bool flag9 = !flag8;
						object obj6 = array.Length - 2;
						bool flag10 = obj6 == null;
						bool flag11 = !flag9;
						if (flag11 || flag10)
						{
							break;
						}
						array[2] = obj4;
						if (".png" != null)
						{
							object obj7 = ".png" as object;
							destination = (Destination)array.Length;
						}
						bool flag12 = destination < (Destination)3;
						bool flag13 = !flag12;
						object obj8 = destination - 3;
						bool flag14 = obj8 == null;
						bool flag15 = !flag13;
						if (flag15 || flag14)
						{
							break;
						}
						array[3] = ".png";
						string text6 = string.Concat(array);
						bool flag16 = File.Exists(text6);
						bool flag17 = !flag16;
						bool flag18 = !flag17;
						text5 = text6;
						if (flag18)
						{
							continue;
						}
						goto IL_04c8;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					goto IL_0570;
				}
			}
			goto IL_04c8;
			IL_0554:
			NullReferenceException ex2 = new NullReferenceException();
			ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
			goto IL_0570;
			IL_04c8:
			if (debugLog.Value)
			{
				string message = "TakeScreenshot: " + text5;
				Debug.Log(message);
			}
			int value5 = superSize.Value;
			ScreenCapture.CaptureScreenshot(text5, value5);
			Finish();
			return;
			IL_0570:
			throw ex3;
		}

		[Token(Token = "0x6000803")]
		[Address(RVA = "0x99F6B4", Offset = "0x99F6B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TakeScreenshot()
		{
		}
	}
}
