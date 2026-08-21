using AssetRipper.Import.Platforms;
using AssetRipper.Import.Structure.Platforms;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// An apk ships one copy of the native library per architecture, and which copy is read decides how
/// much of the game comes back.
/// </summary>
public class AndroidGameStructureTests
{
	private const string Root = "/game.apk";

	private static VirtualFileSystem CreateApk(params string[] architectures)
	{
		VirtualFileSystem fs = new();
		string dataPath = fs.Path.Join(Root, "assets", "bin", "Data");
		fs.Directory.Create(dataPath);
		fs.Directory.Create(fs.Path.Join(Root, "META-INF"));

		foreach (string architecture in architectures)
		{
			string directory = fs.Path.Join(Root, "lib", architecture);
			fs.Directory.Create(directory);
			fs.File.WriteAllBytes(fs.Path.Join(directory, "libil2cpp.so"), [0]);
			fs.File.WriteAllBytes(fs.Path.Join(directory, "libunity.so"), [0]);
		}

		return fs;
	}

	private static PlatformGameStructure? Detect(VirtualFileSystem fs)
	{
		List<string> paths = [Root];
		PlatformChecker.CheckPlatform(paths, fs, out PlatformGameStructure? platform, out _);
		return platform;
	}

	/// <summary>
	/// Cpp2IL lifts ARM64 far better than ARMv7, so on a build carrying both the 64 bit copy is the one
	/// to read. Taking whichever the file system listed first left nearly every method body empty.
	/// </summary>
	[Test]
	public void TheSixtyFourBitLibraryIsPreferredWhateverTheOrder()
	{
		using (Assert.EnterMultipleScope())
		{
			Assert.That(Detect(CreateApk("armeabi-v7a", "arm64-v8a"))?.Il2CppGameAssemblyPath, Does.Contain("arm64-v8a"));
			Assert.That(Detect(CreateApk("arm64-v8a", "armeabi-v7a"))?.Il2CppGameAssemblyPath, Does.Contain("arm64-v8a"));
			Assert.That(Detect(CreateApk("x86", "x86_64"))?.Il2CppGameAssemblyPath, Does.Contain("x86_64"));
		}
	}

	/// <summary>
	/// A build with only one architecture is read whether or not that architecture is one we rank, so an
	/// unfamiliar directory name cannot make the game unloadable.
	/// </summary>
	[Test]
	public void AnUnrankedArchitectureIsStillUsed()
	{
		Assert.That(Detect(CreateApk("riscv64"))?.Il2CppGameAssemblyPath, Does.Contain("riscv64"));
	}
}
