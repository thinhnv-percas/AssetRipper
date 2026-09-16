using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;
using Sirenix.OdinInspector;
using UnityEngine;

[Token(Token = "0x2000008")]
public class UserExperienceTunnel : MonoBehaviour
{
	[Attribute(Type = typeof(TitleAttribute), RVA = "0x74A794", Offset = "0x74A794")]
	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x18")]
	public GlobalEvent OnApplicationStart;

	[Attribute(Type = typeof(TitleAttribute), RVA = "0x74A7DC", Offset = "0x74A7DC")]
	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x20")]
	public GlobalEvent OnBeforeSplashScreen;

	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x28")]
	public GlobalEvent OnAfterSplashScreen;

	[Attribute(Type = typeof(TitleAttribute), RVA = "0x74A824", Offset = "0x74A824")]
	[Token(Token = "0x4000014")]
	[FieldOffset(Offset = "0x30")]
	public GlobalEvent OnShowMainMenu;

	[Token(Token = "0x4000015")]
	[FieldOffset(Offset = "0x38")]
	public GlobalEvent OnTapToPlayLevel;

	[Token(Token = "0x4000016")]
	[FieldOffset(Offset = "0x40")]
	public GlobalEventInt OnTapToCompleteLevel;

	[Token(Token = "0x4000017")]
	[FieldOffset(Offset = "0x48")]
	public GlobalEvent OnLevelComplete;

	[Attribute(Type = typeof(TitleAttribute), RVA = "0x74A86C", Offset = "0x74A86C")]
	[Token(Token = "0x4000018")]
	[FieldOffset(Offset = "0x50")]
	public GlobalEventString SendAnalyticsEvent;

	[Token(Token = "0x600000A")]
	[Address(RVA = "0xCCC4E0", Offset = "0xCCC4E0", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tMorpeh.Globals.GlobalEvent::Publish(this.OnApplicationStart);\n\tMorpeh.Globals.GlobalEvent::Publish(this.OnBeforeSplashScreen);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		OnApplicationStart.Publish();
		OnBeforeSplashScreen.Publish();
	}

	[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x74B50C", Offset = "0x74B50C")]
	[Token(Token = "0x600000B")]
	[Address(RVA = "0xCCC51C", Offset = "0xCCC51C", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDCDF8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202379F]) = v38;\nL_0016:\n\tv42 = new UserExperienceTunnel+<Start>d__9();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IEnumerator Start()
	{
		_003CStart_003Ed__9 _003CStart_003Ed__10 = null;
		_003CStart_003Ed__10._003C_003E1__state = 0;
		_003CStart_003Ed__10._003C_003E4__this = this;
		return _003CStart_003Ed__10;
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0xCCC5BC", Offset = "0xCCC5BC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public UserExperienceTunnel()
	{
	}
}
