using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x200001F")]
public class TimeInGame : IComparable<TimeInGame>
{
	[Token(Token = "0x4000063")]
	[FieldOffset(Offset = "0x10")]
	public int Day;

	[Token(Token = "0x4000064")]
	[FieldOffset(Offset = "0x14")]
	public int Month;

	[Token(Token = "0x4000065")]
	[FieldOffset(Offset = "0x18")]
	public int Year;

	[Token(Token = "0x4000066")]
	[FieldOffset(Offset = "0x1C")]
	public int Minutes;

	[Token(Token = "0x4000067")]
	[FieldOffset(Offset = "0x20")]
	public int Hours;

	[Token(Token = "0x4000068")]
	[FieldOffset(Offset = "0x24")]
	public int Second;

	[Token(Token = "0x17000010")]
	public DateTime DateTime
	{
		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xBFB8D0", Offset = "0xBFB8D0", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.DateTime::.ctor(&v13 @ stack_-18_v2 (System.DateTime), this.Year, this.Month, this.Day, this.Hours, this.Minutes, this.Second);\nL_0011:\n\treturn v13;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0040;\n\tX0 = X19;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = *([19352D8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX1 = *([X8]);\n\tX0 = 0xAD9AE8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0036;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([19352A0]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0033;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0033:\n\tX0 = 0;\n\tX0 = System.DateTime::get_Now(X0);\n\tgoto L_0011;\nL_0036:\n\tX0 = 8;\n\tX0 = 0x1854E90(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\t*([X0]) = X8;\n\tX1 = X1 + 0xF88;\n\tX2 = 0;\n\tX0 = 0x1854EA0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0040:\n\tX0 = X19;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return new DateTime(Year, Month, Day, Hours, Minutes, Second);
		}
	}

	[Token(Token = "0x600009F")]
	[Address(RVA = "0xBFB168", Offset = "0xBFB168", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = System.DateTime;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355E4]) = v37;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tgoto L_0020;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v40, v39, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv46 = System.DateTime;\nL_0020:\n\tv51 = v47.MaxValue;\n\tv52 = System.DateTime::get_Day(&v51 @ X8_v5 (System.DateTime));\n\tthis.Day = v52;\n\tv55 = System.DateTime::get_Month(&v51 @ X8_v5 (System.DateTime));\n\tthis.Month = v55;\n\tv58 = System.DateTime::get_Year(&v51 @ X8_v5 (System.DateTime));\n\tthis.Year = v58;\n\tv61 = System.DateTime::get_Minute(&v51 @ X8_v5 (System.DateTime));\n\tthis.Minutes = v61;\n\tv64 = System.DateTime::get_Hour(&v51 @ X8_v5 (System.DateTime));\n\tthis.Hours = v64;\n\tv67 = System.DateTime::get_Second(&v51 @ X8_v5 (System.DateTime));\n\tthis.Second = v67;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TimeInGame()
	{
		DateTime maxValue = DateTime.MaxValue;
		int day = maxValue.Day;
		Day = day;
		int month = maxValue.Month;
		Month = month;
		int year = maxValue.Year;
		Year = year;
		Minutes = maxValue.Minute;
		Hours = maxValue.Hour;
		Second = maxValue.Second;
	}

	[Token(Token = "0x60000A0")]
	[Address(RVA = "0xBFB23C", Offset = "0xBFB23C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = System.DateTime;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, dateTime, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A355E5]) = v38;\nL_0016:\n\tSystem.Object::.ctor(this);\n\tgoto L_001F;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, v40, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv49 = System.DateTime::get_Day(&dateTime @ X1 (System.DateTime));\n\tthis.Day = v49;\n\tv52 = System.DateTime::get_Month(&dateTime @ X1 (System.DateTime));\n\tthis.Month = v52;\n\tv55 = System.DateTime::get_Year(&dateTime @ X1 (System.DateTime));\n\tthis.Year = v55;\n\tv58 = System.DateTime::get_Minute(&dateTime @ X1 (System.DateTime));\n\tthis.Minutes = v58;\n\tv61 = System.DateTime::get_Hour(&dateTime @ X1 (System.DateTime));\n\tthis.Hours = v61;\n\tv64 = System.DateTime::get_Second(&dateTime @ X1 (System.DateTime));\n\tthis.Second = v64;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TimeInGame(DateTime dateTime)
	{
		DateTime dateTime2 = default(DateTime);
		Day = dateTime2.Day;
		Month = dateTime2.Month;
		Year = dateTime2.Year;
		Minutes = dateTime2.Minute;
		Hours = dateTime2.Hour;
		Second = dateTime2.Second;
	}

	[Token(Token = "0x60000A1")]
	[Address(RVA = "0xBFB304", Offset = "0xBFB304", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = c2.Year - c1.Year;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetYear(TimeInGame c1, TimeInGame c2)
	{
		return c2.Year - c1.Year;
	}

	[Token(Token = "0x60000A2")]
	[Address(RVA = "0xBFB328", Offset = "0xBFB328", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = TimeInGame::GetYear(c1, c2);\n\tv34 = v10 * 0xC;\n\tv35 = c2.Month + v34;\n\treturnVal1 = v35 - c1.Month;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetMonth(TimeInGame c1, TimeInGame c2)
	{
		int year = GetYear(c1, c2);
		int num = year * 12;
		int num2 = c2.Month + num;
		return num2 - c1.Month;
	}

	[Token(Token = "0x60000A3")]
	[Address(RVA = "0xBFB368", Offset = "0xBFB368", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = TimeInGame::GetMonth(c1, c2);\n\tv34 = v10 * 0x1E;\n\tv35 = c2.Day + v34;\n\treturnVal1 = v35 - c1.Day;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetDay(TimeInGame c1, TimeInGame c2)
	{
		int month = GetMonth(c1, c2);
		int num = month * 30;
		int num2 = c2.Day + num;
		return num2 - c1.Day;
	}

	[Token(Token = "0x60000A4")]
	[Address(RVA = "0xBFB3A8", Offset = "0xBFB3A8", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = TimeInGame::GetDay(c1, c2);\n\tv34 = v10 * 0x18;\n\tv35 = c2.Hours + v34;\n\treturnVal1 = v35 - c1.Hours;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetHours(TimeInGame c1, TimeInGame c2)
	{
		int day = GetDay(c1, c2);
		int num = day * 24;
		int num2 = c2.Hours + num;
		return num2 - c1.Hours;
	}

	[Token(Token = "0x60000A5")]
	[Address(RVA = "0xBFB3E8", Offset = "0xBFB3E8", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = TimeInGame::GetHours(c1, c2);\n\tv34 = v10 * 0x3C;\n\tv35 = c2.Minutes + v34;\n\treturnVal1 = v35 - c1.Minutes;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetMinutes(TimeInGame c1, TimeInGame c2)
	{
		int hours = GetHours(c1, c2);
		int num = hours * 60;
		int num2 = c2.Minutes + num;
		return num2 - c1.Minutes;
	}

	[Token(Token = "0x60000A6")]
	[Address(RVA = "0xBFB428", Offset = "0xBFB428", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = TimeInGame::GetMinutes(c1, c2);\n\tv34 = v10 * 0x3C;\n\tv35 = c2.Second + v34;\n\treturnVal1 = v35 - c1.Second;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetSecond(TimeInGame c1, TimeInGame c2)
	{
		int minutes = GetMinutes(c1, c2);
		int num = minutes * 60;
		int num2 = c2.Second + num;
		return num2 - c1.Second;
	}

	[Token(Token = "0x60000A7")]
	[Address(RVA = "0xBFB468", Offset = "0xBFB468", Length = "0x54")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Day = day;\n\tthis.Month = month;\n\tthis.Year = year;\n\tthis.Minutes = minutes;\n\tthis.Hours = hours;\n\tthis.Second = second;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public TimeInGame(int year, int month, int day, int hours, int minutes, int second)
	{
		Day = day;
		Month = month;
		Year = year;
		Minutes = minutes;
		Hours = hours;
		Second = second;
	}

	[Token(Token = "0x60000A8")]
	[Address(RVA = "0xBFB4BC", Offset = "0xBFB4BC", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Day = day;\n\tthis.Month = month;\n\tthis.Year = year;\n\tthis.Minutes = minutes;\n\tthis.Hours = hours;\n\tthis.Second = second;\n\treturn;\n")]
	public void SetTime(int day, int month, int year, int minutes = 0, int hours = 0, int second = 0)
	{
		Day = day;
		Month = month;
		Year = year;
		Minutes = minutes;
		Hours = hours;
		Second = second;
	}

	[Token(Token = "0x60000A9")]
	[Address(RVA = "0xBFB4CC", Offset = "0xBFB4CC", Length = "0xCC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = System.DateTime;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, dataTime, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A355E6]) = v44;\nL_001B:\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v45, dataTime, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_001F:\n\tv53 = System.DateTime::get_Day(&dataTime @ X1 (System.DateTime));\n\tv57 = System.DateTime::get_Month(&dataTime @ X1 (System.DateTime));\n\tv61 = System.DateTime::get_Year(&dataTime @ X1 (System.DateTime));\n\tv65 = System.DateTime::get_Minute(&dataTime @ X1 (System.DateTime));\n\tv69 = System.DateTime::get_Hour(&dataTime @ X1 (System.DateTime));\n\tv73 = System.DateTime::get_Second(&dataTime @ X1 (System.DateTime));\n\tthis.Day = v53;\n\tthis.Month = v57;\n\tthis.Year = v61;\n\tthis.Minutes = v65;\n\tthis.Hours = v69;\n\tthis.Second = v73;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetTime(DateTime dataTime)
	{
		DateTime dateTime = default(DateTime);
		int day = dateTime.Day;
		int month = dateTime.Month;
		int year = dateTime.Year;
		int minute = dateTime.Minute;
		int hour = dateTime.Hour;
		int second = dateTime.Second;
		Day = day;
		Month = month;
		Year = year;
		Minutes = minute;
		Hours = hour;
		Second = second;
	}

	[Token(Token = "0x60000AA")]
	[Address(RVA = "0xBFB598", Offset = "0xBFB598", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = System.DateTime;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, dataTime, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A355E7]) = v38;\nL_0019:\n\tgoto L_001D;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v39, dataTime, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tv48 = System.DateTime::get_Day(&dataTime @ X1 (System.DateTime));\n\tv58 = this.Day != v48;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v59, v47, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv95 = System.DateTime::get_Month(&dataTime @ X1 (System.DateTime));\n\tv65 = this.Month != v95;\n\tif (v65) goto L_FFFFFFFF;\n\tgoto L_0047;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v129, v92, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\tv96 = System.DateTime::get_Year(&dataTime @ X1 (System.DateTime));\n\tv66 = this.Year != v96;\n\tif (v66) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool IsSameDay(DateTime dataTime)
	{
		DateTime dateTime = default(DateTime);
		int day = dateTime.Day;
		if (Day == day)
		{
			int month = dateTime.Month;
			if (Month == month)
			{
				int year = dateTime.Year;
				if (Year == year)
				{
					return true;
				}
			}
		}
		return false;
	}

	[Token(Token = "0x60000AB")]
	[Address(RVA = "0xBFB668", Offset = "0xBFB668", Length = "0xCC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = System.DateTime;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = System.TimeSpan;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355E8]) = v38;\nL_001D:\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = System.DateTime::get_Now();\n\tv57 = 0;\n\tSystem.DateTime::.ctor(&v57 @ stack_-30_v1 (System.DateTime), this.Year, this.Month, this.Day);\n\tv62 = System.DateTime::op_Subtraction(v51, 0);\n\tgoto L_0037;\n\tv68 = v63;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v68, v59, v61, v54, v58, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tv73 = System.TimeSpan::get_TotalDays(&v62 @ X0_v8 (System.TimeSpan));\n\treturn v73;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public float CountDays()
	{
		DateTime now = DateTime.Now;
		DateTime dateTime = default(DateTime);
		dateTime = new DateTime(Year, Month, Day);
		double totalDays = (now - default(DateTime)).TotalDays;
		return (float)totalDays;
	}

	[Token(Token = "0x60000AC")]
	[Address(RVA = "0xBFB734", Offset = "0xBFB734", Length = "0xCC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = System.DateTime;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = System.TimeSpan;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355E9]) = v38;\nL_001D:\n\tgoto L_0020;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = System.DateTime::get_Now();\n\tv57 = 0;\n\tSystem.DateTime::.ctor(&v57 @ stack_-30_v1 (System.DateTime), this.Year, this.Month, this.Day);\n\tv62 = System.DateTime::op_Subtraction(v51, 0);\n\tgoto L_0037;\n\tv68 = v63;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v68, v59, v61, v54, v58, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0037:\n\tv73 = System.TimeSpan::get_TotalMinutes(&v62 @ X0_v8 (System.TimeSpan));\n\treturn v73;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public float CountMinutes()
	{
		DateTime now = DateTime.Now;
		DateTime dateTime = default(DateTime);
		dateTime = new DateTime(Year, Month, Day);
		double totalMinutes = (now - default(DateTime)).TotalMinutes;
		return (float)totalMinutes;
	}

	[Token(Token = "0x60000AD")]
	[Address(RVA = "0xBFB800", Offset = "0xBFB800", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = System.DateTime;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, other, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A355EA]) = v46;\nL_001A:\n\tv49 = 0;\n\tgoto L_002E;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v47, other, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002E:\n\tSystem.DateTime::.ctor(&v49 @ stack_-48_v1 (System.DateTime), this.Year, this.Month, this.Day, this.Hours, this.Minutes, this.Second);\n\tSystem.DateTime::.ctor(&v77 @ stack_-50_v2 (System.DateTime), other.Year, other.Month, other.Day, other.Hours, other.Minutes, other.Second);\n\treturnVal2 = System.DateTime::CompareTo(&v49 @ stack_-48_v1 (System.DateTime), v77);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public int CompareTo(TimeInGame other)
	{
		DateTime dateTime = default(DateTime);
		dateTime = new DateTime(Year, Month, Day, Hours, Minutes, Second);
		DateTime value = new DateTime(other.Year, other.Month, other.Day, other.Hours, other.Minutes, other.Second);
		return dateTime.CompareTo(value);
	}

	[Token(Token = "0x60000AF")]
	[Address(RVA = "0xBFB994", Offset = "0xBFB994", Length = "0xE8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = System.String[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = \"/\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355EB]) = v38;\n\t// 24 NewArr v41 @ X0_v3 (System.String[]), typeof(System.String[]), 5\nL_001A:\n\tv45 = this + 0x10;\n\tv47 = System.Int32::ToString(v45);\n\tv41[0] = v47;\n\tv132 = this + 0x14;\n\tv41[1] = \"/\";\n\tv126 = System.Int32::ToString(v132);\n\tv41[2] = v126;\n\tv161 = this + 0x18;\n\tv41[3] = \"/\";\n\tv127 = System.Int32::ToString(v161);\n\tv41[4] = v127;\n\treturnVal2 = System.String::Concat(v41);\n\treturn returnVal2;\n\tv81 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe override string ToString()
	{
		int num = (int)((nint)this + 16);
		string text = ((int*)num)->ToString();
		int num2 = (int)((nint)this + 20);
		string text2 = ((int*)num2)->ToString();
		int num3 = (int)((nint)this + 24);
		string text3 = ((int*)num3)->ToString();
		return text + "/" + text2 + "/" + text3;
	}
}
