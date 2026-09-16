using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile;
using LunarConsolePluginInternal;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Systems
{
	[CreateAssetMenu]
	[Token(Token = "0x2000014")]
	public class AdvertisingSystem : LateUpdateSystem
	{
		[Required]
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEvent ShowInterstitial;

		[Required]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x30")]
		public GlobalEvent ShowRewarded;

		[Required]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x38")]
		public GlobalEvent InterstitialCompleted;

		[Required]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x40")]
		public GlobalEvent RewardedCompleted;

		[Required]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x48")]
		public GlobalEvent RewardedSkipped;

		[Required]
		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x50")]
		public GlobalEvent NoInternet;

		[Required]
		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x58")]
		public GlobalVariableFloat Timer;

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x1633194", Offset = "0x1633194", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EBD980]);\n\tv23 = *([v22 @ X8_v49]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A4D8]) = v42;\nL_0016:\n\tv44 = EasyMobile.EM_Settings::get_Advertising();\n\tv49 = v44.mIronSource;\n\tgoto L_0033;\n\tv75 = *([v50 @ X0_v9 (Il2CppClass<Morpeh.Hypercasual.Code.Systems.AdvertisingVariables>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\t// 37 ConditionalJump @b49, v77 @ TEMP_v44\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv79 = Morpeh.Hypercasual.Code.Systems.AdvertisingVariables;\nL_0033:\n\tv100 = EasyMobile.AdId::get_IosId(v49.mAppId);\n\tLunarConsolePluginInternal.CVarExtension::Set(v97.IronSourceiOS, v100);\n\tv135 = EasyMobile.AdId::get_AndroidId(v49.mAppId);\n\tLunarConsolePluginInternal.CVarExtension::Set(v131.IronSourceAndroid, v135);\n\tgoto L_0056;\n\tv145 = *([v141 @ X0_v17+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0056;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v136, v138, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0056:\n\tgoto L_0061;\n\tv157 = *([1EA8548]);\n\tv158 = *([v157 @ X8_v43]);\n\tv159 = \"il2cpp_codegen_initialize_method\"(v158, v136, v138, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv162 = 0 | 1;\n\t*([202A4E2]) = v162;\nL_0061:\n\tgoto L_006A;\n\tv167 = *([v163 @ X0_v20 (Il2CppClass<EasyMobile.RuntimeManager>)+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tgoto L_006A;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v163, v136, v138, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv171 = EasyMobile.RuntimeManager;\nL_006A:\n\tv176 = ~v174.mIsInitialized;\n\tv177 = ~v176;\n\tif (v177) goto L_008B;\n\tgoto L_0077;\n\tv192 = *([v170 @ X0_v21 (Il2CppClass<EasyMobile.RuntimeManager>)+E0]);\n\tv193 = v192 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_0077;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v170, v136, v138, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0077:\n\tEasyMobile.RuntimeManager::Init();\n\tgoto L_0085;\n\tv219 = *([v209 @ X0_v37+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0085;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v209, v136, v138, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0085:\n\tEasyMobile.Advertising::LoadRewardedAd();\n\tEasyMobile.Advertising::LoadInterstitialAd();\nL_008B:\n\tv191 = new System.Action`2<EasyMobile.InterstitialAdNetwork, EasyMobile.AdPlacement>();\n\tSystem.Action`2<EasyMobile.InterstitialAdNetwork, EasyMobile.AdPlacement>::.ctor(v191, this, Il2CppMethodInfo);\n\tgoto L_00A3;\n\tv225 = *([v215 @ X0_v25+E0]);\n\tv226 = v225 == 0;\n\tv227 = ~v226;\n\tif (v227) goto L_00A3;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v215, v203, v205, v206, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A3:\n\tEasyMobile.Advertising::add_InterstitialAdCompleted(v191);\n\tv236 = new System.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>();\n\tSystem.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>::.ctor(v236, this, Il2CppMethodInfo);\n\tEasyMobile.Advertising::add_RewardedAdCompleted(v236);\n\tv248 = new System.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>();\n\tSystem.Action`2<EasyMobile.RewardedAdNetwork, EasyMobile.AdPlacement>::.ctor(v248, this, Il2CppMethodInfo);\n\tEasyMobile.Advertising::add_RewardedAdSkipped(v248);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			AdSettings advertising = EM_Settings.Advertising;
			IronSourceSettings ironSource = advertising.IronSource;
			string iosId = ironSource.AppId.IosId;
			AdvertisingVariables.IronSourceiOS.Set(iosId);
			string androidId = ironSource.AppId.AndroidId;
			AdvertisingVariables.IronSourceAndroid.Set(androidId);
			if (!RuntimeManager.mIsInitialized)
			{
				RuntimeManager.Init();
				Advertising.LoadRewardedAd();
				Advertising.LoadInterstitialAd();
			}
			Action<InterstitialAdNetwork, AdPlacement> value = InterstitialAdCompletedHandler;
			Advertising.InterstitialAdCompleted += value;
			Action<RewardedAdNetwork, AdPlacement> value2 = RewardedAdCompletedHandler;
			Advertising.RewardedAdCompleted += value2;
			Action<RewardedAdNetwork, AdPlacement> value3 = RewardedAdSkippedHandler;
			Advertising.RewardedAdSkipped += value3;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x1633408", Offset = "0x1633408", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED3828]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, deltaTime, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A4D9]) = v38;\nL_0017:\n\tv43 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.ShowRewarded);\n\tv45 = v43 == 0;\n\tif (v45) goto L_0042;\n\tgoto L_0028;\n\tv55 = *([v48 @ X0_v20+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v48, v42, v22, v23, v24, v25, v26, v27, deltaTime, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tv63 = EasyMobile.Advertising::IsRewardedAdReady();\n\tv67 = v63 == 0;\n\tif (v67) goto L_008D;\n\tgoto L_0037;\n\tv164 = *([v114 @ X0_v25+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_0037;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v114, v42, v22, v23, v24, v25, v26, v27, deltaTime, v29, v30, v31, v32, v33, v34, v35);\nL_0037:\n\tEasyMobile.Advertising::ShowRewardedAd();\n\tEasyMobile.Advertising::LoadRewardedAd();\n\treturn;\nL_0042:\n\tv54 = Morpeh.Globals.BaseGlobalEvent`1<System.Int32>::op_Implicit(this.ShowInterstitial);\n\tv65 = v54 == 0;\n\tif (v65) goto L_0083;\n\tv98 = Morpeh.Globals.BaseGlobalVariable`1<System.Single>::get_Value(this.Timer);\n\tv170 = v98 < 0;\n\tv96 = ~v170;\n\tv87 = v98 == 0;\n\tv171 = ~v87;\n\tv72 = v96 & v171;\n\tif (v72) goto L_0083;\n\tgoto L_0066;\n\tv177 = *([v173 @ X0_v10+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\tif (v179) goto L_0066;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v173, v100, v22, v23, v24, v25, v26, v27, v98, v29, v30, v31, v32, v33, v34, v35);\nL_0066:\n\tv102 = EasyMobile.Advertising::IsInterstitialAdReady();\n\tv104 = v102 == 0;\n\tif (v104) goto L_0083;\n\tgoto L_0075;\n\tv189 = *([v185 @ X0_v14+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0075;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v185, v100, v22, v23, v24, v25, v26, v27, v98, v29, v30, v31, v32, v33, v34, v35);\nL_0075:\n\tEasyMobile.Advertising::ShowInterstitialAd();\n\tEasyMobile.Advertising::LoadInterstitialAd();\n\treturn;\nL_0083:\n\treturn;\nL_008D:\n\tMorpeh.Globals.GlobalEvent::NextFrame(this.NoInternet);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate(float deltaTime)
		{
			if ((bool)ShowRewarded)
			{
				if (Advertising.IsRewardedAdReady())
				{
					Advertising.ShowRewardedAd();
					Advertising.LoadRewardedAd();
				}
				else
				{
					NoInternet.NextFrame();
				}
			}
			else if ((bool)ShowInterstitial)
			{
				float value = Timer.Value;
				bool flag = value < 0f;
				bool flag2 = !flag;
				bool flag3 = value == 0f;
				bool flag4 = !flag3;
				if (!(flag2 && flag4) && Advertising.IsInterstitialAdReady())
				{
					Advertising.ShowInterstitialAd();
					Advertising.LoadInterstitialAd();
				}
			}
		}

		[Token(Token = "0x6000020")]
		[Address(RVA = "0x1633564", Offset = "0x1633564", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.InterstitialCompleted);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InterstitialAdCompletedHandler(InterstitialAdNetwork network, AdPlacement location)
		{
			InterstitialCompleted.Publish();
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x1633580", Offset = "0x1633580", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.RewardedCompleted);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RewardedAdCompletedHandler(RewardedAdNetwork network, AdPlacement location)
		{
			RewardedCompleted.Publish();
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x163359C", Offset = "0x163359C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.RewardedSkipped);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RewardedAdSkippedHandler(RewardedAdNetwork network, AdPlacement location)
		{
			RewardedSkipped.Publish();
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x16335B8", Offset = "0x16335B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.LateUpdateSystem::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdvertisingSystem()
		{
		}
	}
}
