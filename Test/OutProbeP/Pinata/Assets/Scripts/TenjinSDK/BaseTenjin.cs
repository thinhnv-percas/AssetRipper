using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000003")]
public abstract class BaseTenjin : MonoBehaviour
{
	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x18")]
	protected string apiKey;

	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x20")]
	protected string sharedSecret;

	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x28")]
	protected internal bool optIn;

	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x29")]
	protected internal bool optOut;

	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x2C")]
	protected int appSubversion;

	[Token(Token = "0x17000001")]
	public string ApiKey
	{
		[Token(Token = "0x6000013")]
		[Address(RVA = "0x165F1B8", Offset = "0x165F1B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.apiKey;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return ApiKey;
		}
		[Token(Token = "0x6000014")]
		[Address(RVA = "0x165F1C0", Offset = "0x165F1C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.apiKey = value;\n\treturn;\n")]
		set
		{
			ApiKey = value;
		}
	}

	[Token(Token = "0x17000002")]
	public string SharedSecret
	{
		[Token(Token = "0x6000015")]
		[Address(RVA = "0x165F1C8", Offset = "0x165F1C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sharedSecret;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return SharedSecret;
		}
		[Token(Token = "0x6000016")]
		[Address(RVA = "0x165F1D0", Offset = "0x165F1D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sharedSecret = value;\n\treturn;\n")]
		set
		{
			SharedSecret = value;
		}
	}

	[Token(Token = "0x17000003")]
	public int AppSubversion
	{
		[Token(Token = "0x6000017")]
		[Address(RVA = "0x165F1D8", Offset = "0x165F1D8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.appSubversion;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return AppSubversion;
		}
		[Token(Token = "0x6000018")]
		[Address(RVA = "0x165F1E0", Offset = "0x165F1E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.appSubversion = value;\n\treturn;\n")]
		set
		{
			AppSubversion = value;
		}
	}

	[Token(Token = "0x6000019")]
	public abstract void Init(string apiKey);

	[Token(Token = "0x600001A")]
	public abstract void InitWithSharedSecret(string apiKey, string sharedSecret);

	[Token(Token = "0x600001B")]
	public abstract void InitWithAppSubversion(string apiKey, int appSubversion);

	[Token(Token = "0x600001C")]
	public abstract void InitWithSharedSecretAppSubversion(string apiKey, string sharedSecret, int appSubversion);

	[Token(Token = "0x600001D")]
	public abstract void Connect();

	[Token(Token = "0x600001E")]
	public abstract void Connect(string deferredDeeplink);

	[Token(Token = "0x600001F")]
	public abstract void OptIn();

	[Token(Token = "0x6000020")]
	public abstract void OptOut();

	[Token(Token = "0x6000021")]
	public abstract void OptInParams(List<string> parameters);

	[Token(Token = "0x6000022")]
	public abstract void OptOutParams(List<string> parameters);

	[Token(Token = "0x6000023")]
	public abstract void AppendAppSubversion(int subversion);

	[Token(Token = "0x6000024")]
	public abstract void SendEvent(string eventName);

	[Token(Token = "0x6000025")]
	public abstract void SendEvent(string eventName, string eventValue);

	[Token(Token = "0x6000026")]
	public abstract void Transaction(string productId, string currencyCode, int quantity, double unitPrice, string transactionId, string receipt, string signature);

	[Token(Token = "0x6000027")]
	public abstract void GetDeeplink(Tenjin.DeferredDeeplinkDelegate deferredDeeplinkDelegate);

	[Token(Token = "0x6000028")]
	[Address(RVA = "0x165EA38", Offset = "0x165EA38", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected internal BaseTenjin()
	{
	}
}
