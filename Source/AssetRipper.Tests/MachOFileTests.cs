using LibCpp2IL.MachO;

namespace AssetRipper.Tests;

public class MachOFileTests
{
	private const ulong TextAddress = 0x8000;
	private const ulong Il2CppAddress = 0x9000;

	private static readonly byte[] textBytes = [0x00, 0x01, 0x02, 0x03];
	private static readonly byte[] il2cppBytes = [0x10, 0x11, 0x12, 0x13, 0x14, 0x15];

	private static MachOFile Load(byte[] raw) => new(new MemoryStream(raw, 0, raw.Length, writable: true, publiclyVisible: true));

	private static byte[] BuildTwoExecutableSections()
		=> new MachOBinaryBuilder()
			.AddSection("__text", TextAddress, textBytes)
			.AddSection("il2cpp", Il2CppAddress, il2cppBytes)
			.Build();

	/// <summary>
	/// The generated method bodies are in the section named <c>il2cpp</c>, not in <c>__text</c>, so
	/// anything that counts how often a runtime helper is called has to see both. Returning only the
	/// primary section is what made an ELF helper called thousands of times read as called once.
	/// </summary>
	[Test]
	public void ExecutableSectionsIncludeTheIl2CppSection()
	{
		MachOFile file = Load(BuildTwoExecutableSections());

		Dictionary<ulong, byte[]> sections = file.GetExecutableSections().ToDictionary(s => s.VirtualAddress, s => s.Data.ToArray());

		using (Assert.EnterMultipleScope())
		{
			Assert.That(sections, Has.Count.EqualTo(2));
			Assert.That(sections[TextAddress], Is.EqualTo(textBytes));
			Assert.That(sections[Il2CppAddress], Is.EqualTo(il2cppBytes));
		}
	}

	/// <summary>The primary section stays <c>__text</c> alone, which is what the ELF reader does too.</summary>
	[Test]
	public void PrimaryExecutableSectionIsTextAlone()
	{
		MachOFile file = Load(BuildTwoExecutableSections());

		using (Assert.EnterMultipleScope())
		{
			Assert.That(file.GetVirtualAddressOfPrimaryExecutableSection(), Is.EqualTo(TextAddress));
			Assert.That(file.GetEntirePrimaryExecutableSection().ToArray(), Is.EqualTo(textBytes));
		}
	}

	[Test]
	public void SectionsWithoutInstructionsAreNotExecutable()
	{
		byte[] raw = new MachOBinaryBuilder()
			.AddSection("__text", TextAddress, textBytes)
			.AddSection("__cstring", Il2CppAddress, il2cppBytes, MachOSectionFlags.TYPE_CSTRING_LITERALS)
			.Build();

		MachOFile file = Load(raw);

		Assert.That(file.GetExecutableSections().Select(s => s.VirtualAddress), Is.EqualTo(new[] { TextAddress }));
	}

	[Test]
	public void UnencryptedBinaryReportsNoEncryption()
	{
		MachOFile file = Load(BuildTwoExecutableSections());

		Assert.That(file.EncryptionInfo, Is.Null);
	}

	/// <summary>An App Store build declares this, and its native code cannot be read at all.</summary>
	[Test]
	public void EncryptedBinaryReportsItsEncryptedRange()
	{
		byte[] raw = new MachOBinaryBuilder()
			.AddSection("__text", TextAddress, textBytes)
			.AddSection("il2cpp", Il2CppAddress, il2cppBytes)
			.WithEncryption(offset: 0x8000, size: 0x1000, id: 1)
			.Build();

		MachOFile file = Load(raw);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(file.EncryptionInfo, Is.Not.Null);
			Assert.That(file.EncryptionInfo!.Value.CryptId, Is.EqualTo(1u));
			Assert.That(file.EncryptionInfo!.Value.CryptOffset, Is.EqualTo(0x8000u));
			Assert.That(file.EncryptionInfo!.Value.CryptSize, Is.EqualTo(0x1000u));
			Assert.That(file.EncryptionInfo!.Value.Covers(0x8100), Is.True);
			Assert.That(file.EncryptionInfo!.Value.Covers(0x9000), Is.False);
		}
	}

	/// <summary>A command with cryptid zero is present on plenty of builds and means nothing is encrypted.</summary>
	[Test]
	public void EncryptionCommandWithZeroCryptIdIsNotEncryption()
	{
		byte[] raw = new MachOBinaryBuilder()
			.AddSection("__text", TextAddress, textBytes)
			.WithEncryption(offset: 0x8000, size: 0x1000, id: 0)
			.Build();

		Assert.That(Load(raw).EncryptionInfo, Is.Null);
	}

	/// <summary>
	/// The same answer has to be available without loading the binary, because the caller wants it
	/// before deciding to read fifty megabytes — and because on an encrypted binary the load is what
	/// fails.
	/// </summary>
	[Test]
	public void EncryptionIsReadableFromTheHeaderAlone()
	{
		byte[] raw = new MachOBinaryBuilder()
			.AddSection("__text", TextAddress, textBytes)
			.WithEncryption(offset: 0x4000, size: 0x2000, id: 1)
			.Build();

		MachOEncryptionInfo? info = MachOEncryptionInfo.ReadFrom(new MemoryStream(raw));

		using (Assert.EnterMultipleScope())
		{
			Assert.That(info, Is.Not.Null);
			Assert.That(info!.Value.CryptOffset, Is.EqualTo(0x4000u));
			Assert.That(info!.Value.CryptSize, Is.EqualTo(0x2000u));
		}
	}

	[Test]
	public void HeaderReadOfANonMachOFileIsNotAFailure()
	{
		Assert.That(MachOEncryptionInfo.ReadFrom(new MemoryStream([.. Enumerable.Repeat((byte)0x7F, 256)])), Is.Null);
	}
}
