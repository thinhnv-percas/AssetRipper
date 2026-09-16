using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Obsolete]
	[Token(Token = "0x2000015")]
	public class AdLocation
	{
		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x10")]
		private readonly string name;

		[Token(Token = "0x4000094")]
		private static Hashtable map;

		[Token(Token = "0x4000095")]
		public static readonly AdLocation Default;

		[Token(Token = "0x4000096")]
		public static readonly AdLocation Startup;

		[Token(Token = "0x4000097")]
		public static readonly AdLocation HomeScreen;

		[Token(Token = "0x4000098")]
		public static readonly AdLocation MainMenu;

		[Token(Token = "0x4000099")]
		public static readonly AdLocation GameScreen;

		[Token(Token = "0x400009A")]
		public static readonly AdLocation Achievements;

		[Token(Token = "0x400009B")]
		public static readonly AdLocation Quests;

		[Token(Token = "0x400009C")]
		public static readonly AdLocation Pause;

		[Token(Token = "0x400009D")]
		public static readonly AdLocation LevelStart;

		[Token(Token = "0x400009E")]
		public static readonly AdLocation LevelComplete;

		[Token(Token = "0x400009F")]
		public static readonly AdLocation TurnComplete;

		[Token(Token = "0x40000A0")]
		public static readonly AdLocation IAPStore;

		[Token(Token = "0x40000A1")]
		public static readonly AdLocation ItemStore;

		[Token(Token = "0x40000A2")]
		public static readonly AdLocation GameOver;

		[Token(Token = "0x40000A3")]
		public static readonly AdLocation LeaderBoard;

		[Token(Token = "0x40000A4")]
		public static readonly AdLocation Settings;

		[Token(Token = "0x40000A5")]
		public static readonly AdLocation Quit;

		[Token(Token = "0x6000077")]
		[Address(RVA = "0xA456D4", Offset = "0xA456D4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal AdLocation()
		{
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0xA456DC", Offset = "0xA456DC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F007D0]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, addToMap, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021EB6]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.name = name;\n\tv48 = addToMap == 0;\n\tif (v48) goto L_0043;\n\tgoto L_002C;\n\tv61 = *([v51 @ X0_v3 (Il2CppClass<EasyMobile.AdLocation>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_002C;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v51, v46, addToMap, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv65 = EasyMobile.AdLocation;\nL_002C:\n\tv69 = v68.map;\n\tv91 = *([v69 @ X0_v5 (System.Collections.Hashtable)]);\n\tv74 = *([v91 @ X8_v6 (Il2CppClass<System.Collections.Hashtable>)+210]);\n\tv72 = *([v91 @ X8_v6 (Il2CppClass<System.Collections.Hashtable>)+218]);\n\t// 59 IndirectJump v74 @ X4_v1, v69 @ X0_v5 (System.Collections.Hashtable), v69 @ X0_v5 (System.Collections.Hashtable), name @ X1 (System.String), this @ X0 (EasyMobile.AdLocation), v72 @ X3_v1, v74 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\nL_0043:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal AdLocation(string name, bool addToMap = true)
		{
			//IL_0012: Expected I, but got O
			//IL_0022: Expected O, but got I
			//IL_0032: Expected O, but got I
			base._002Ector();
			this.name = name;
			if (addToMap)
			{
				Hashtable hashtable = map;
				IntPtr intPtr = (IntPtr)hashtable;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v6 (Il2CppClass<System.Collections.Hashtable>)+210]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v6 (Il2CppClass<System.Collections.Hashtable>)+218]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v74 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0xA45798", Offset = "0xA45798", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return name;
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0xA457A0", Offset = "0xA457A0", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EA9140]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021EB7]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(name);\n\tv47 = v41 == 0;\n\tif (v47) goto L_002C;\n\tgoto L_0028;\n\tv52 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.AdLocation>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0028;\n\tv75 = v44;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v75, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv60 = EasyMobile.AdLocation;\nL_0028:\n\tv142 = v61.Default;\n\tgoto L_0086;\nL_002C:\n\tgoto L_003C;\n\tv63 = *([v44 @ X8_v3 (Il2CppClass<EasyMobile.AdLocation>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\t// 48 ConditionalJump @b32, v65 @ TEMP_v21\n\tv152 = v44;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v152, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv71 = EasyMobile.AdLocation;\nL_003C:\n\tv156 = System.Collections.Hashtable::get_Item(v72.map, name);\n\tv137 = v156 == 0;\n\tif (v137) goto L_0067;\n\tgoto L_0053;\n\tv194 = *([v140 @ X8_v9 (Il2CppClass<EasyMobile.AdLocation>)+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\t// 71 ConditionalJump @b33, v196 @ TEMP_v19\n\tv202 = v140;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v202, v154, v155, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv201 = EasyMobile.AdLocation;\nL_0053:\n\tv133 = System.Collections.Hashtable::get_Item(v166.map, name);\n\tv136 = v133 == 0;\n\tif (v136) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0086;\nL_0067:\n\tv134 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v134, name, 1);\n\tgoto L_0086;\n\tv78 = v78_asT == 0;\n\tif (v78) goto L_FFFFFFFF;\n\tgoto L_0086;\nL_0086:\n\treturn v142;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AdLocation LocationFromName(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				object obj = map.get_Item((object)name);
				if (obj != null)
				{
					object obj2 = map.get_Item((object)name);
					if (obj2 == null)
					{
						return null;
					}
					AdLocation adLocation = obj2 as AdLocation;
					if (adLocation != null)
					{
						return (AdLocation)obj2;
					}
					return null;
				}
				return new AdLocation(name);
			}
			return Default;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0xA458FC", Offset = "0xA458FC", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EFE668]);\n\tv17 = *([v16 @ X8_v60]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2021EB8]) = v37;\nL_0015:\n\tv41 = new System.Collections.Hashtable();\n\tSystem.Collections.Hashtable::.ctor(v41);\n\tv47.map = v41;\n\tv49 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v49, \"Default\", 1);\n\tv56.Default = v49;\n\tv57 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v57, \"Startup\", 1);\n\tv64.Startup = v57;\n\tv65 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v65, \"Home Screen\", 1);\n\tv72.HomeScreen = v65;\n\tv73 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v73, \"Main Menu\", 1);\n\tv80.MainMenu = v73;\n\tv81 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v81, \"Game Screen\", 1);\n\tv88.GameScreen = v81;\n\tv89 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v89, \"Achievements\", 1);\n\tv96.Achievements = v89;\n\tv97 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v97, \"Quests\", 1);\n\tv104.Quests = v97;\n\tv105 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v105, \"Pause\", 1);\n\tv112.Pause = v105;\n\tv113 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v113, \"Level Start\", 1);\n\tv120.LevelStart = v113;\n\tv121 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v121, \"Level Complete\", 1);\n\tv128.LevelComplete = v121;\n\tv129 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v129, \"Turn Complete\", 1);\n\tv136.TurnComplete = v129;\n\tv137 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v137, \"IAP Store\", 1);\n\tv144.IAPStore = v137;\n\tv145 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v145, \"Item Store\", 1);\n\tv152.ItemStore = v145;\n\tv153 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v153, \"Game Over\", 1);\n\tv160.GameOver = v153;\n\tv161 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v161, \"Leaderboard\", 1);\n\tv168.LeaderBoard = v161;\n\tv169 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v169, \"Settings\", 1);\n\tv176.Settings = v169;\n\tv177 = new EasyMobile.AdLocation();\n\tEasyMobile.AdLocation::.ctor(v177, \"Quit\", 1);\n\tv184.Quit = v177;\n\treturn;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AdLocation()
		{
			Hashtable hashtable = new Hashtable();
			map = hashtable;
			AdLocation adLocation = new AdLocation("Default");
			Default = adLocation;
			AdLocation startup = new AdLocation("Startup");
			Startup = startup;
			AdLocation homeScreen = new AdLocation("Home Screen");
			HomeScreen = homeScreen;
			AdLocation mainMenu = new AdLocation("Main Menu");
			MainMenu = mainMenu;
			AdLocation gameScreen = new AdLocation("Game Screen");
			GameScreen = gameScreen;
			AdLocation achievements = new AdLocation("Achievements");
			Achievements = achievements;
			AdLocation quests = new AdLocation("Quests");
			Quests = quests;
			AdLocation pause = new AdLocation("Pause");
			Pause = pause;
			AdLocation levelStart = new AdLocation("Level Start");
			LevelStart = levelStart;
			AdLocation levelComplete = new AdLocation("Level Complete");
			LevelComplete = levelComplete;
			AdLocation turnComplete = new AdLocation("Turn Complete");
			TurnComplete = turnComplete;
			AdLocation iAPStore = new AdLocation("IAP Store");
			IAPStore = iAPStore;
			AdLocation itemStore = new AdLocation("Item Store");
			ItemStore = itemStore;
			AdLocation gameOver = new AdLocation("Game Over");
			GameOver = gameOver;
			AdLocation leaderBoard = new AdLocation("Leaderboard");
			LeaderBoard = leaderBoard;
			AdLocation settings = new AdLocation("Settings");
			Settings = settings;
			AdLocation quit = new AdLocation("Quit");
			Quit = quit;
		}
	}
}
