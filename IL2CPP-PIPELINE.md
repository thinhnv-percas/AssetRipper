# IL2CPP → C#: pipeline phục hồi script của DevXUnity-Unpacker

Tài liệu này mô tả **đường đi đầy đủ** từ một game Unity IL2CPP (APK / thư mục
build) đến các file `.cs` nằm trong project Unity mà tool xuất ra: từng bước,
từng file dữ liệu cần có, và chỗ nào trong source đã recover thực hiện việc đó.

Phân tích lớp bảo vệ/đóng gói của chính tool nằm ở [FINDINGS.md](FINDINGS.md);
trạng thái build ở [ROADMAP.md](ROADMAP.md); phần crack ở
[CrackSettings.cs](Recovered/DevXUnityUnpackerTools/CrackSettings.cs).

> **Lưu ý về nguồn.** Mọi tham chiếu file:line trỏ vào `Recovered/` — bản
> decompile đã dựng lại và chạy được. Các lời gọi `DbgLog.*` xuất hiện trong
> trích dẫn **không phải của sản phẩm gốc**: chúng do phiên phân tích trước chèn
> vào để trace runtime (xem [DbgLog.cs](Recovered/DevXUnityUnpackerTools/DbgLog.cs)).
> Tên định danh dạng `_0020_000A_...` là ký tự khoảng trắng/xuống dòng bị obfuscate,
> không phải lỗi decompile.

---

## 0. Tóm tắt trong 10 dòng

IL2CPP biên dịch C# → C++ → mã máy, nên **IL đã biến mất**. Không thể "decompile
ngược về IL" như game Mono. Cái còn lại là hai thứ:

1. `global-metadata.dat` — giữ nguyên **toàn bộ phần khai báo**: tên type, tên
   field, tên method, chữ ký, token, attribute, string literal, quan hệ kế thừa.
2. Binary gốc (`libil2cpp.so` / `GameAssembly.dll` / …) — giữ **mã máy** của thân
   hàm, cộng hai bảng `CodeRegistration` + `MetadataRegistration` để ánh xạ
   `methodIndex → con trỏ hàm`.

Tool ghép hai nguồn đó lại: metadata dựng lại khung class hoàn chỉnh (chính xác
100%), rồi disassemble mã máy của từng method và **lift** nó thành câu lệnh C#
gần đúng. Đó là lý do khung class luôn đúng còn thân hàm thì "gần giống".

---

## 1. Input: cần những file gì

### 1.1 Phía game (bắt buộc)

| File | Vai trò | Bắt buộc |
|---|---|---|
| `global-metadata.dat` | Toàn bộ khai báo. Không có file này → **nhánh IL2CPP bị bỏ qua hoàn toàn** | ✅ |
| `libil2cpp.so` / `GameAssembly.dll` / `code.unityweb` | Mã máy + bảng đăng ký | ✅ (thiếu thì chỉ ra được khung rỗng) |
| Unity version | Chọn DB struct + DB class đúng phiên bản | ✅ (tool tự dò từ assets) |

Chỗ dò file: [ManyCodeCls.cs:4058-4118](Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L4058).
Nếu `FindItemByName("global-metadata.dat")` trả về null, log ghi
`global-metadata.dat entry = NOT FOUND -> IL2CPP branch will be skipped` và dừng ở đó.

Thứ tự ưu tiên chọn binary khi trong APK có nhiều ABI
([ManyCodeCls.cs:4120-4133](Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L4120)):

```
arm64-v8a  →  armeabi-v7a  →  x86  →  GameAssembly.dll  →  code.unityweb  →  (còn lại)
```

Mỗi ứng viên được thử **lần lượt** trong một vòng lặp; ứng viên nào ném exception
thì `continue` sang cái kế tiếp ([ManyCodeCls.cs:4148](Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L4148)).

### 1.2 Phía tool (`StreamingAssets/`)

| Đường dẫn | Nội dung | Dùng để |
|---|---|---|
| `structdb/*.json` | **736 file** (368 version × x32/x64). DB layout struct C của runtime IL2CPP. Thay thế `IL2CPPStructs/*.dvxil2c` — xem [structdb/README.md](structdb/README.md) | Dịch `LDR x0,[x1,#0x18]` thành truy cập field có tên |
| `ArmCP/x64/arm_cp.dll`, `ArmCP/x86/arm_cp.dll` | **Capstone** đổi tên (3.8 MB) | Disassemble ARM32/ARM64/x86/x64 |
| `ClassAll.zip` (81 MB, 718 XML) | Type-tree của Unity built-in classes | Parse asset (không thuộc pipeline IL2CPP, xem mục 14) |
| `UnityDLL/Unity-*.zip` | DLL engine theo version | Reference khi decompile / dựng project |
| `DecompilerFi/DecompilerFi.exe` | ILSpy CLI | **Nhánh Mono**, không dùng cho IL2CPP |
| `dnSpy/` | dnSpy CLI | Nhánh Mono (lựa chọn thay thế) |
| `DevXUnityScriptManager.dll` | EditorWindow xem script trong Unity | Copy vào `Assets/Editor/` của project xuất ra |

Bản đồ vị trí các đường dẫn này: [Loader.cs:113-127](Recovered/DevXUnityUnpackerTools/Loader.cs#L113).

---

## 2. Sơ đồ pipeline

```
  APK / build folder
        │
        │  ManyCodeCls: quét cây file, tìm metadata + binary
        ▼
  RunIl2CppPipeline(metadataPath, binaryPath)          -.cs:48602      ← cổng bật/tắt theo IL2CPP_DecompileType
        │
        ▼
  ExportIl2CppScripts(...)                             DMP4/-.cs:9838  ← orchestrator, mốc "0".."9"
        │
        ├─(1)─ Il2CppMetadata(stream)                  DMP4/-.cs:3234  sanity 0xFAB11BAF, version ≥ 16
        │
        ├─(2)─ nhận dạng binary theo magic 4 byte      DMP4/-.cs:6595  ELF/PE/Mach-O/FAT/NSO/WASM
        │
        ├─(3)─ PlusSearch → PE loader → Search →       DMP4/-.cs:6672  tìm CodeRegistration +
        │      SymbolSearch                                            MetadataRegistration
        │
        ├─(4)─ CreateDummyDlls → Mono.Cecil            DMP4/-.cs:6747  ghi *.dll "rỗng" ra thư mục temp
        │
        ├─(5)─ bảng offset method (VA/RVA/file off/len)DMP4/-.cs:6793
        │
        ├─(6)─ metadataUsage → string literal, type,   DMP4/-.cs:10032
        │      method ref
        │
        ├─(7)─ nạp DB struct .dvxil2c theo Unity ver   -.cs:36095 / 36127
        │
        ├─(8)─ với MỖI type: sinh khung C#             DMP4/-.cs:10230-11700
        │        attribute, field + offset, property,
        │        method signature, generic instance
        │
        ├─(9)─ với MỖI method: disassemble + lift      ARMD/-.cs:6032   (WASD/-.cs cho WebAssembly)
        │        thân hàm thành câu lệnh C#
        │
        └─(10)─ nối bằng //#DECOMPILER_SEPARATOR#      DMP4/-.cs:10299
                 │
                 ▼
           tách + ghi từng class ra file               as/-.cs:33941 / 34081
                 │
                 ▼
        Assets/Scripts/<Namespace>/<Class>.cs  +  .cs.meta (GUID cố định)
```

---

## 3. Bước 1 — Đọc `global-metadata.dat`

[`Il2CppMetadata`](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L3132), constructor ở
[DMP4/-.cs:3234](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L3234):

```csharp
uint num = ReadUInt32();
if (num != 4205910959u)          // 0xFAB11BAF — "sanity"
    throw new InvalidDataException("ERROR: Metadata file supplied is not valid metadata file.");
int num2 = ReadInt32();
if (num2 < 16)
    throw new NotSupportedException($"...not a supported version[{num2}].");
Version = num2;
```

* **Phạm vi hỗ trợ: metadata version 16 → 27.x.** Trong toàn bộ `DMP4/` chỉ có các
  nhánh `Version >= 22.0`, `>= 24.0`, `>= 24.2`, `>= 27.0` — **không có nhánh cho
  v29** (Unity 2022+). Đây là trần thực tế của tool, khớp với DB struct dừng ở
  Unity 2021.
* v24 phải phân biệt 24.0 / 24.1 / 24.2 bằng heuristic (Unity 2018.3 vs 2019.x dùng
  chung số 24) — [DMP4/-.cs:3259-3268](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L3259).
* Nếu `Version >= 27` và binary là ELF **đã bị dump từ RAM** (`IsDumped`), tool đặt
  `il2CppMetadata.Address = 0` và ghi `Input global-metadata.dat dump address:`
  ([DMP4/-.cs:6680](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6680)) — từ v27 string
  literal được lưu theo địa chỉ tuyệt đối nên cần base address.

Sau bước này ta có các mảng (đúng tên gốc của IL2CPP, xem thư mục
[DMP4/](Recovered/DevXUnityUnpackerTools/DMP4/)): `imageDefs`, `typeDefs`,
`methodDefs`, `fieldDefs`, `parameterDefs`, `propertyDefs`, `eventDefs`,
`stringLiterals`, `attributeTypeRanges`, `metadataUsageDic`, `genericContainers`, …

---

## 4. Bước 2 — Nhận dạng và nạp binary

[DMP4/-.cs:6595](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6595) — switch trên 4 byte đầu:

| Magic (LE) | Bytes | Định dạng | Reader |
|---|---|---|---|
| `0x00905A4D` | `MZ\x90\0` | **PE** (Windows / GameAssembly.dll) | `DMP4/-.cs:2415` |
| `0x464C457F` | `\x7fELF` | **ELF32 / ELF64** (Android, Linux) | `DMP4/-.cs:87` / `:604`, base `ElfBase` |
| `0x6D736100` | `\0asm` | **WebAssembly** (WebGL) | `DMP4/-.cs:2860` → `.CreateMemory()` |
| `0x304F534E` | `NSO0` | **Nintendo Switch NSO** (nén) | `.UnCompress()` |
| `0xCAFEBABE` / `0xBEBAFECA` | | **Mach-O FAT** — chọn slice 64-bit nếu có | duyệt, `magic == 0xFEEDFACF` |
| `0xFEEDFACE` / `0xFEEDFACF` | | **Mach-O 32 / 64** (iOS, macOS) | `DMP4/-.cs:1278` |
| khác | | | `throw new NotSupportedException("ERROR: Not supported - IL2CPP file .")` |

Với FAT binary, code in ra danh sách slice rồi lấy slice có `magic == 0xFEEDFACF`
(64-bit) nếu tồn tại — [DMP4/-.cs:6637-6650](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6637).

Cuối bước: `il2Cpp.SetProperties(metadata.Version, metadata.maxMetadataUsages)` —
binary reader phải biết version metadata vì layout của `Il2CppCodeRegistration`
và `Il2CppMetadataRegistration` đổi theo version.

---

## 5. Bước 3 — Tìm `CodeRegistration` / `MetadataRegistration`

Đây là bước hay hỏng nhất trong mọi tool IL2CPP. Hai struct này không được export
symbol; phải **tìm bằng heuristic** trong dữ liệu. Chuỗi 4 chiến lược, dừng ở cái
đầu tiên thành công ([DMP4/-.cs:6683-6730](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6683)):

```csharp
flag = il2Cpp.PlusSearch(methodCount, typeDefsCount, imageDefsCount);   // 1
if (IsWin_OS && !flag && il2Cpp is PE) {                                // 2
    // ghi binary ra file tạm rồi nạp lại bằng "custom PE loader"
    ConsoleManager.WriteInfo("Use custom PE loader");
    il2Cpp = LoadPeViaCustomLoader(tempDll);
    flag = il2Cpp.PlusSearch(...);
}
if (!flag) flag = il2Cpp.Search();                                      // 3
if (!flag) flag = il2Cpp.SymbolSearch();                                // 4
if (!flag) return false;                                                // bó tay
```

* **PlusSearch** — quét section dữ liệu tìm cụm con trỏ có số lượng khớp *chính
  xác* với `methodDefs.Count(m => m.methodIndex >= 0)`, `typeDefs.Length`,
  `imageDefs.Length`. Đây là cách chuẩn (giống Il2CppDumper).
* **Custom PE loader** — với PE bị pack/section bất thường, tool map lại file như
  loader Windows thật rồi quét trên ảnh đã map.
* **Search** — quét brute-force toàn file.
* **SymbolSearch** — dùng symbol table nếu binary chưa strip (hiếm với build release).

Thất bại cả 4 → `ExportIl2CppScripts` vẫn chạy tiếp nhưng binary reader là `null`,
và log ghi `binary reader = NULL (binary not recognised / search failed)`.
Kết quả: **chỉ ra được khung class, mọi thân hàm rỗng.**

---

## 6. Bước 4 — `CreateDummyDlls`: dựng assembly rỗng bằng Cecil

[DMP4/-.cs:6747](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6747)

```csharp
Directory.SetCurrentDirectory(outDir);
arg2 = new Il2CppExecutor(il2CppMetadata, il2Cpp);
var dummy = new DummyAssemblyGenerator(arg2);
foreach (AssemblyDefinition item in dummy.Assemblies)
{
    using (MemoryStream ms = new MemoryStream())
    {
        item.Write(ms);
        File.WriteAllBytes(item.MainModule.Name, ms.ToArray());   // Assembly-CSharp.dll, mscorlib.dll, ...
    }
}
```

Mỗi `Il2CppImageDefinition` trong metadata → một `AssemblyDefinition` của Mono.Cecil,
chứa **đầy đủ type/field/method/property/attribute nhưng thân method rỗng**. Đây là
"xương sống" để:

* Bộ giải tên type có một assembly resolver thật (`ReaderParameters.AssemblyResolver`
  được set ở [DMP4/-.cs:10080](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10080)).
* Ánh xạ `imageDef ↔ AssemblyDefinition` theo tên module
  ([DMP4/-.cs:10059-10070](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10059)).
* Các module con của tool (viewer, export) có thứ để hiển thị ngay cả khi lift thất bại.

Thư mục temp lấy từ `TempManager`; log `DUMMY.write <name> types=<n> <bytes> bytes`
rồi `DUMMY.end <n> dummy assemblies written to <dir>`.

---

## 7. Bước 5 — Bảng offset method

[DMP4/-.cs:6793](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6793) duyệt
image → type → method và với mỗi method có `methodIndex >= 0` tính:

| Đại lượng | Nguồn |
|---|---|
| `VA` (virtual address) | `il2Cpp.GetMethodPointer(imageName, methodDef)` |
| `fileOffset` | `il2Cpp.MapVATR(VA)` |
| `RVA` | `il2Cpp.GetRVA(VA)` |
| **`len` (độ dài hàm)** | `GetSortedAllPointersWithIndexToNextPointer()[VA] - VA` |

Điểm cần chú ý: **độ dài hàm được suy ra bằng khoảng cách tới con trỏ hàm kế tiếp**
([Il2Cpp.cs:536](Recovered/DevXUnityUnpackerTools/DMP4/Il2Cpp.cs#L536)). Không có
thông tin độ dài thật trong metadata. Hệ quả trực tiếp:

* Hàm cuối cùng của một section, hoặc hàm có padding / hàm bị compiler gộp, sẽ ra
  `len` sai.
* Có clamp cứng: `if (num21 > 50000) num21 = 256;`
  ([DMP4/-.cs:11487](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11487)) — `len` vô lý
  thì chỉ đọc 256 byte.
* Sau khi lift, nếu bộ lift phát hiện hàm kết thúc sớm, nó **ghi ngược** `len` đúng
  vào bảng để các hàm sau dùng
  ([DMP4/-.cs:11893](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11893)).

Bảng này cũng được export ra UI dưới dạng node **"<binary> - Offset table"** dạng
`0x00123456: Namespace.Class::Method  rva: 0x...`
([ManyCodeCls.cs:4160-4180](Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L4160)).

---

## 8. Bước 6 — `metadataUsage`: nguồn của string literal

```csharp
foreach (var kv in metadata.metadataUsageDic)              // Il2CppMetadataUsage -> {slot, index}
    foreach (var pair in kv.Value)
        RegisterUsage((long)il2Cpp.metadataUsages[pair.Key], kv.Key, pair.Value);
```
[DMP4/-.cs:10032-10046](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10032), handler ở
[DMP4/-.cs:10417](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10417).

IL2CPP không nhúng chuỗi vào mã máy. Thay vào đó mã máy **load một con trỏ từ bảng
`metadataUsages`**. Bảng trên biến `địa chỉ slot → ý nghĩa` (string literal nào,
type nào, method nào, field nào). Nhờ nó, khi bộ lift thấy

```asm
ADRP x0, #0x1234000
LDR  x0, [x0, #0x678]
```

nó tra địa chỉ `0x1234678` trong bảng và in ra `"Player died"` thay vì một con số.
**Đây là lý do chuỗi trong output IL2CPP thường đúng nguyên văn** trong khi biểu
thức số học xung quanh thì chỉ gần đúng.

Từ metadata v27 có thêm bước xử lý riêng
(`if (metadata.header.version >= 27) ...` —
[DMP4/-.cs:9880](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L9880)) vì layout bảng đổi.

---

## 9. Bước 7 — DB struct runtime `.dvxil2c`

> **Đã thay thế trong repo này.** Mục dưới mô tả cơ chế **gốc** của DevX, giữ lại
> làm tài liệu tham chiếu. Mã nguồn trong `Recovered/` **không còn đọc `.dvxil2c`**:
> lớp cipher + GZip + `BinaryWriter` đã bị gỡ, thay bằng
> [`Il2CppStructDbJson.cs`](Recovered/DevXUnityUnpackerTools/Il2CppStructDbJson.cs)
> đọc thẳng JSON trong [structdb/](structdb/). Xem [structdb/README.md](structdb/README.md).

### 9.1 Nó là gì

Mỗi file `StreamingAssets/IL2CPPStructs/<UnityVersion>.dvxil2c` chứa **layout của
toàn bộ struct C trong runtime IL2CPP** cho đúng phiên bản Unity đó, cả bản 32-bit
lẫn 64-bit: tên struct, `sizeof`, và từng field kèm **kiểu C + offset**.

Đây là thứ cho phép bộ lift dịch một lệnh truy cập bộ nhớ thành tên có nghĩa:
`LDR x8, [x0, #0x10]` trên một `Il2CppObject*` → `obj->klass`, chứ không phải
`*(long*)(x0 + 16)`.

### 9.2 Định dạng (đã verify bằng cách giải mã thật)

```
file .dvxil2c
   └─ stream cipher (khóa chuỗi "sdf3$wGSDGEh%$SdF2")     -.cs:40059
        └─ GZip
             └─ BinaryWriter
                  magic "DVXSTI" (6 byte) + int version
                  ├─ DB cho x32   (name, sizeof, align, unityVersion, is32bit, ticks,
                  │                structs[], enums[], defines[], typedefs[])
                  └─ DB cho x64   (như trên)
```

Cipher ([-.cs:40059-40195](Recovered/DevXUnityUnpackerTools/-.cs#L40059)): sinh 2 bảng
1027 byte từ password bằng LCG kiểu `java.util.Random`
(`seed = seed*25214903917 + 11 mod 2^48`), rồi mỗi byte ở vị trí tuyệt đối `n`:

```
decrypt:  b = (b - tableB[n % 1027]) ^ tableA[n % 1027]
encrypt:  b = (b ^ tableA[n % 1027]) + tableB[n % 1027]
```

**Đã kiểm chứng:** giải mã `2019.4.0f1.dvxil2c` (16 KB) → GZip hợp lệ → 80 010 byte,
6 byte đầu đúng `DVXSTI`, bên trong có **173 struct `Il2Cpp*`** — `Il2CppClass`,
`Il2CppObject`, `Il2CppAssembly`, `Il2CppAppDomain`, `Il2CppRGCTXDefinition`,
`VirtualInvokeData`, `Il2CppCatchPoint`, … kèm tên field (`rgctxDataDummy`,
`methodIndex`, `typeIndex`, `interfaceTypeIndex`, …) và kiểu (`int32_t`,
`Il2CppClass*`, `Il2CppRGCTXDataType`).

DB này còn **sinh ngược ra được một chương trình C++ kiểm chứng**
([-.cs:37500-37548](Recovered/DevXUnityUnpackerTools/-.cs#L37500)): file `.cpp` gồm
đủ `typedef`, `#define`, `enum`, định nghĩa struct, và một `main()` in
`sizeof(...)` từng struct rồi so với giá trị đã lưu:

```cpp
if( sizeof(Il2CppClass) != 328 ) std::cout << "ERROR: sizeof(Il2CppClass): " << sizeof(Il2CppClass) << " != 328 !!!\n";
```

Tức là DevX dựng bộ DB này bằng cách **biên dịch header IL2CPP thật của từng bản
Unity rồi đọc `sizeof`/offset ra** — không phải đoán.

### 9.3 Cách chọn file

[-.cs:36095](Recovered/DevXUnityUnpackerTools/-.cs#L36095) index toàn bộ thư mục theo
tên không phần mở rộng; [-.cs:36127](Recovered/DevXUnityUnpackerTools/-.cs#L36127) tra
theo `VerFormat` của game. Nếu **không có file khớp chính xác**,
`GetNearUnityVersionList()` ([-.cs:36172](Recovered/DevXUnityUnpackerTools/-.cs#L36172))
sinh danh sách version lân cận (lùi rồi tiến, quét cả hậu tố `p/f/b/a` + số) và lấy
cái gần nhất tồn tại. Không có gì khớp → trả `null` → lift vẫn chạy nhưng mọi truy
cập field thành offset thô.

Phạm vi ship: **368 file, từ 5.6.x đến 2021.x.** Unity 2022 / 6.x sẽ rơi vào
fallback (và thường cũng đã bị chặn từ bước metadata v29).

---

## 10. Bước 8 — Sinh khung C# cho từng type

Vòng lặp chính: mốc `"8"` trong `ExportIl2CppScripts`
([DMP4/-.cs:10230-10330](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10230)) →
gọi hàm ghi type ([DMP4/-.cs:11258](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11258)).

Thứ tự sinh cho mỗi `Il2CppTypeDefinition`:

1. **Header comment** — `// Decompiled from IL2CPP#4: <đường dẫn binary>`
   (đường dẫn bị cắt bỏ phần `~unpack-*` để không lộ thư mục tạm —
   [DMP4/-.cs:10270](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10270)).
2. **Custom attributes** — dựng lại từ `attributeTypeRanges`.
3. **Khai báo class** — namespace, access modifier, base type, interface, generic
   parameter, `sealed`/`abstract`/`static`.
4. **Fields** — kiểu + tên + **offset trong object** (`// 0x18`), giá trị mặc định
   từ `fieldDefaultValues`. Ở chế độ *Script fields only* thì dừng tại đây.
5. **Properties** — ghép getter/setter từ `propertyDefs.get/.set` (là chỉ số
   **tương đối so với `typeDef.methodStart`** —
   [DMP4/-.cs:11463](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11463)).
6. **Methods** — chữ ký đầy đủ: `ref`/`out`/`in` suy từ `il2CppType.byref` + `attrs`
   ([DMP4/-.cs:11570-11590](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11570)), tham số
   mặc định từ `GetParameterDefaultValueFromIndex`.
7. **Comment địa chỉ** cho từng method (trừ chế độ `Scripts`):
   ```
   // Offset in libil2cpp.so: 0x004A31C0 (4862400), len: 148  VirtAddr: 0x004A31C0 RVA: 0x004A31C0
   //   token: 100663512 methodIndex: 21877 delegateWrapperIndex: -1 methodInvoker: 8394752
   ```
   Với WebAssembly thì thay bằng `TableIndex` / `FunctionNumber` / `f_type`.
8. **Generic instance methods** — mỗi `Il2CppMethodSpec` được liệt kê kèm địa chỉ
   riêng (`// Generic instance method:` → `// -Namespace.Class.Method`), vì IL2CPP
   sinh **một bản mã máy cho mỗi instantiation** của generic
   ([DMP4/-.cs:11429-11470](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11429)).
9. **Thân hàm** — mục 11.

Kết thúc mỗi type: ghi dấu phân cách kèm checksum
([DMP4/-.cs:10299](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10299)):

```csharp
long num4 = Hash(sw.ToString());
outerWriter.Write("//#DECOMPILER_SEPARATOR#CLASS_NAME{" + fullTypeName + "}&" + num4);
```

---

## 11. Bước 9 — Lift thân hàm: mã máy → câu lệnh C#

Đây là phần "độc quyền" của DevX so với Il2CppDumper (vốn chỉ dừng ở mục 10).

### 11.1 Điều kiện chạy

[DMP4/-.cs:11875-11885](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11875):

```csharp
if (!flag6 || (num21 < 2048 && !flag6) || num21 < 1024)   // flag6 = chế độ "with ASM"
{
    long num32 = Math.Min(num21, 100000L);                // cắt ở 100 KB mã máy
    ...lift...
    if (num32 < num21)
        w.WriteLine("// finction code trimed, for full decompile code - set flag: "
                  + "Import Settings->IL2CPP to decompile into ARM ASM && C# (experemental, slow)");
}
else
    w.WriteLine("// Is big finction, for decompile code - set flag: ...");
```

Nghĩa là: ở chế độ mặc định, **hàm dài hơn ~1 KB mã máy bị bỏ qua** với một comment.
Muốn lift hết phải bật chế độ `Script with ASM` (chậm hơn nhiều). Hai typo
`finction`/`experemental` là của bản gốc.

### 11.2 Tầng disassembler

[ARMD/-.cs:27-84](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L27) dispatch theo kiến trúc:

| `ProcessorTypeEnum` | Backend |
|---|---|
| `ARM32` | Capstone (`CreateArmDisassembler(ArmDisassembleMode.Arm)`), **fallback sang bộ disassembler ARM32 viết bằng C#** ở [ARMD/Disassembler.cs](Recovered/DevXUnityUnpackerTools/ARMD/Disassembler.cs) nếu Capstone ném lỗi |
| `ARM64` | Capstone |
| `X86_32` / `X86_64` | Capstone |
| `WebAssembly` | [WASD/-.cs](Recovered/DevXUnityUnpackerTools/WASD/-.cs) — dùng `Wasm.Interpret`, không phải Capstone |
| khác | không có → `DbgLog "no disassembler for processor type"` → thân hàm rỗng |

Kiến trúc được suy ra từ chính loại reader binary
([DMP4/-.cs:9975-10000](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L9975)).

**Chi tiết vận hành quan trọng:** Capstone được P/Invoke bằng tên trần `"arm_cp"`,
không kèm đường dẫn. Vì thế trước mỗi lần disassemble tool phải
`Directory.SetCurrentDirectory(StreamingAssets/ArmCP/{x64|x86})` rồi trả lại chỗ cũ
khi xong ([DSMCaps/-.cs:88-108](Recovered/DevXUnityUnpackerTools/DSMCaps/-.cs#L88)).
Nếu `arm_cp.dll` không tồn tại, exception bị nuốt và **kết quả là thân hàm rỗng, không
phải thông báo lỗi** — đúng như comment ở
[ARMD/-.cs:72](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L72).

### 11.3 Hai lượt lift

[ARMD/-.cs:6032](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L6032):

```csharp
list = Lift(start, ref end, va, ctx, ..., flag14: true);   // lượt 1: phân tích
CollectBranchTargetsAndTypes(ctx..., list);                // gom nhãn nhảy, suy kiểu
return Lift(start, ref end, va, ctx, ..., flag14: false);  // lượt 2: sinh câu lệnh thật
```

Lượt 1 dựng đồ thị luồng điều khiển — nhận diện `TBZ/TBNZ/CBZ/CBNZ` và giải địa chỉ
đích ra từ toán hạng thứ hai ([ARMD/-.cs:6100-6125](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L6100))
— để biết đâu là nhãn cần đặt, đâu là biến cục bộ. Lượt 2 mới in ra C#.

### 11.4 Nhận dạng hàm runtime IL2CPP

Vấn đề: một `BL 0x4C2100` chỉ là "gọi địa chỉ". Tool giải bằng ba cách:

1. **Tra bảng offset** (mục 7): nếu địa chỉ đích là một method có trong metadata →
   in thẳng tên `Namespace.Class::Method(...)`.
2. **Pattern matching cho helper của runtime** — các hàm nội bộ IL2CPP không nằm
   trong metadata, nên tool nhận diện chúng bằng ngữ cảnh. Ví dụ có thật ở
   [ARMD/-.cs:10410-10460](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L10410):

   > Nếu đang lift `System.Reflection.Assembly` trong `mscorlib.dll`, method là
   > `Assembly` hoặc `.ctor`, kiến trúc ARM64 → thì `BL` **cuối cùng** trong hàm đó
   > chính là `il2cpp_codegen_object_new`.

   Tương tự cho `il2cpp_runtime_class_init` và
   `System.Collections.Generic.List<T>::Add(this, T*, RuntimeMethod)`. Một khi
   một địa chỉ đã được gán tên theo cách này, **mọi hàm khác gọi cùng địa chỉ đó
   đều được đặt tên đúng** — đây là mẹo bootstrap chính của bộ lift.
3. **Slot `metadataUsage`** (mục 8) cho string literal / type / method reference.

### 11.5 Cổng "demo"

[ARMD/-.cs:10505-10520](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L10505):

```csharp
if (HiddenCalls.CallObjectSafe1(null, "1834582700")?.ToString() != "0012")
{
    counter++;
    if ((counter & 1) == 0)      // cứ 2 hàm thì bỏ 1
    {
        w.WriteLine("// Hide for demo version!");
        list.Clear();
        return;
    }
}
```

Hàm ẩn `"1834582700"` phải trả về `"0012"` (giá trị đúng nằm ở
[ARMD/-.cs:10497](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L10497)); nếu không, **một
nửa số thân hàm bị vứt bỏ** và thay bằng comment. Đây là chỗ license kiểm soát tính
năng đắt giá nhất của sản phẩm. Bản crack đặt `AllowActivation = true` nên cổng này
luôn mở. Log `EXPORT.done` sẽ kèm `*** contains demo placeholders ***` nếu bị dính.

### 11.6 Ổn định / bộ nhớ

`ExportIl2CppScripts` gọi `GC.Collect(); Thread.Sleep(10);` **mỗi 30 giây** trong cả
hai vòng lặp type ([DMP4/-.cs:10186](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10186)
và [:10296](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L10296)), và bắt exception ở
**từng type một** (`DbgLog.Lim("EXPORT.type.fail", ...)`) để một type hỏng không giết
cả run. Với game 20k type, một run đầy đủ ở chế độ `Script with ASM` mất hàng giờ.

---

## 12. Bước 10 — Ghi ra project Unity

### 12.1 Tách theo dấu phân cách

Toàn bộ output của một assembly là **một chuỗi khổng lồ** nối bằng
`//#DECOMPILER_SEPARATOR#CLASS_NAME{...}&<hash>`. Bộ tách:
[as/-.cs:33941](Recovered/DevXUnityUnpackerTools/as/-.cs#L33941) →
`List<(string name, string code)>`.

Điểm đáng chú ý: **nhánh Mono cũng dùng đúng format này**
([-.cs:39961](Recovered/DevXUnityUnpackerTools/-.cs#L39961) — sau khi chạy
`DecompilerFi.exe`/dnSpy, output được cắt bằng cùng hàm). Nhờ vậy hai nhánh
IL2CPP và Mono hội tụ về một đường ghi file duy nhất.

### 12.2 Ghi file + `.meta`

[as/-.cs:34040-34095](Recovered/DevXUnityUnpackerTools/as/-.cs#L34040):

```
Assets/Scripts/<Namespace>/<Class>.cs            ← namespace chuyển thành cây thư mục
Assets/Scripts/<Namespace>/<Class>.cs.meta       ← MonoImporter + guid
```

* Namespace `A.B.C` → thư mục `A/B/`, tên file `C.cs`. Nếu đường dẫn > 200 ký tự thì
  các dấu `/` bị thay bằng `_` để tránh giới hạn MAX_PATH.
* Trùng tên → thêm hậu tố số và đẩy xuống thư mục con (`Foo1/Foo.cs`).
* Bỏ qua: `<Module>`, `AssemblyInfo`, `PrivateImplementationDetails`, type có
  `Size=` trong tên.

**GUID trong `.meta` không ngẫu nhiên** — nó là hash của
`"<tên assembly>\<tên class đầy đủ>"` ([as/-.cs:33993](Recovered/DevXUnityUnpackerTools/as/-.cs#L33993)):

```csharp
return Hash(assemblyNameWithoutExt + "\\" + fullClassName);
```

Đây là mắt xích quyết định để project mở được: prefab/scene mà tool xuất ra tham
chiếu script qua `m_Script: {fileID: 11500000, guid: <...>}`, và guid đó phải bằng
đúng guid tool tự sinh cho file `.cs` tương ứng. Deterministic nên hai lần export
khác nhau vẫn khớp.

### 12.3 Phụ trợ

* `DevXScripDB.devxsbxml` — DB ánh xạ script, ghi vào project khi Unity ≥ 2018.3.
* `Assets/Editor/DevXUnityScriptManager.dll` — copy từ `StreamingAssets`
  ([ManyCodeCls.cs:7898](Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L7898)); đây là
  một `EditorWindow` ([DevXShowScript.cs](DevXUnityScriptManager/DevXShowScript.cs)) để
  xem script ngay trong Unity Editor.
* TextMesh Pro được bung từ `StreamingAssets/Templates/TextMesh Pro.zip` nếu game có dùng.

---

## 13. Năm chế độ `IL2CPP_DecompileType`

Enum: [IL2CPP_DecompileType.cs](Recovered/DevXUnityUnpackerTools/IL2CPP_DecompileType.cs).
Nhãn UI: [ImportSettings.cs:547](Recovered/DevXUnityUnpackerTools/DevXUnityUnpackerTools._WinForm/ImportSettings.cs#L547).

| # | Enum | Nhãn UI | Sinh ra | Tốc độ |
|---|---|---|---|---|
| 0 | `None` | none | Không chạy pipeline IL2CPP chút nào | — |
| 1 | `ScriptsStructureFieldsOnly` | Script fields only | Chỉ class + field (đủ để Unity bind MonoBehaviour và giữ giá trị inspector) | Rất nhanh |
| 2 | `ScriptsStructure` | Script structure only | Class + field + property + chữ ký method, thân rỗng | Nhanh |
| 3 | `ScriptsWithASM` | Script with ASM | Như trên + thân hàm C# **kèm comment ASM gốc**, không giới hạn 1 KB | Rất chậm |
| 4 | `Scripts` | Script | Thân hàm C# "sạch", **bỏ hết comment offset/ASM/generic-instance** | Chậm |

Khác biệt giữa 3 và 4 nằm rải khắp bộ ghi dưới dạng `if (mode != IL2CPP_DecompileType.Scripts)`
— tức mode `Scripts` là mode duy nhất *không* in comment kỹ thuật, cho output gần
"code người viết" nhất nhưng mất hết thông tin truy vết.

Chế độ 1 và 2 vẫn hữu ích thực tế: nếu mục tiêu chỉ là **mở được project và xem
được dữ liệu scene/prefab**, khung field là đủ, và nhanh hơn hàng chục lần.

---

## 14. Đối chiếu: hai pipeline khác trong cùng tool

Để tránh nhầm lẫn — hai thứ sau **không phải** IL2CPP → C#:

**Nhánh Mono.** Game Mono còn nguyên IL:

```
Assembly-CSharp.dll  →  DecompilerFi.exe (ILSpy CLI) hoặc dnSpy CLI  →  C# thật
                        [-.cs:39900-39985]
```

Output là **C# đúng, biên dịch lại được**. Tool chỉ chạy thêm bước "SourcesFix"
([-.cs:39970](Recovered/DevXUnityUnpackerTools/-.cs#L39970)) để vá các construct
ILSpy sinh ra mà Unity không nuốt được. Lựa chọn decompiler nằm ở `ImportSettings`
→ `DecompillerType` (`dnSpy` | `DecompilerFi`). Đừng kỳ vọng chất lượng nhánh
IL2CPP ngang nhánh này — bản chất bài toán khác nhau.

**Parse asset.** `ClassAll.zip` / `UnityType.zip` là type-tree của **Unity built-in
classes**, dùng để đọc `.assets`/`AssetBundle`, hoàn toàn độc lập với
`IL2CPPStructs/*.dvxil2c` (là layout struct **runtime C**). Hai DB dễ bị nhầm vì cùng
được chọn theo Unity version bằng cùng thuật toán fallback.

---

## 15. Giới hạn thực tế (đọc trước khi kỳ vọng)

| Giới hạn | Nguyên nhân | Biểu hiện |
|---|---|---|
| **Unity ≤ 2021** | Metadata reader dừng ở v27; `.dvxil2c` dừng ở 2021.x; ClassAll dừng ở 2021.2.7f1 | Game 2022/6.x: hoặc `NotSupportedException`, hoặc chạy với DB sai version |
| **Thân hàm chỉ gần đúng** | Lift từ mã máy đã tối ưu; không có IL | Biến tạm vô nghĩa, biểu thức tách rời, control flow phẳng |
| **Hàm > ~1 KB bị cắt** | Ngưỡng ở [DMP4/-.cs:11875](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11875) | `// finction code trimed` |
| **`len` hàm là ước lượng** | Suy từ con trỏ kế tiếp | Lift lấn sang hàm kế, hoặc dừng sớm |
| **Không có tên biến cục bộ** | Bị xóa lúc compile, metadata không giữ | `num1`, `num2`, `flag3`… |
| **Generic bị nhân bản** | IL2CPP sinh mã riêng cho mỗi instantiation | Nhiều địa chỉ cho "một" method |
| **Thiếu `arm_cp.dll` → im lặng** | Exception bị nuốt ở [ARMD/-.cs:72](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L72) | Thân hàm rỗng, **không báo lỗi** |
| **Search thất bại → im lặng** | 4 chiến lược đều fail | Chỉ có khung class, mọi thân rỗng |
| **Game có anti-tamper** | Metadata bị mã hóa / binary bị pack | `sanity != 0xFAB11BAF` ngay bước 1 |

---

## 16. Debug một run hỏng

`DbgLog` (do phiên phân tích trước thêm vào, **không có trong bản gốc**) ghi ra
`<thư mục exe>\il2cpp-debug.log`, fallback `%TEMP%\il2cpp-debug.log`. Grep theo tag,
đúng thứ tự pipeline:

| Tag | Trả lời câu hỏi |
|---|---|
| `ENV` | `StreamingAssets`, `IL2CPPStructs`, `ArmCP` có tồn tại không |
| `SCAN.il2cpp` | Tìm thấy `global-metadata.dat` chưa |
| `DETECT` | Đang thử ứng viên binary nào (`candidate 2/5: binary=... metadata=...`) |
| `IL2CPP.gate` | Mode có phải `None` không |
| `IL2CPP.begin` | Đường dẫn metadata/binary thực tế |
| `IL2CPP.load` | **Quan trọng nhất**: `binary reader = NULL` nghĩa là bước 3 fail; `metadata = v27, images=..., types=...` nghĩa là bước 1 OK |
| `DUMMY.write` / `DUMMY.end` | Sinh được bao nhiêu assembly rỗng |
| `CAP.cwd` | `dllExists=False` → Capstone không nạp được |
| `ASM.arch` / `ASM.fail` | Không có disassembler cho kiến trúc này, hoặc disassemble ném lỗi |
| `ARMD.gate` / `ARMD.demo` | Cổng demo có bị kích hoạt không |
| `EXPORT.image` | Mỗi assembly: `typeCount=…` |
| `EXPORT.type.fail` | Type nào lỗi (giới hạn 15 dòng + 2 stack trace đầy đủ) |
| `EXPORT.done` | `generated N chars of C#` — và cảnh báo `*** contains demo placeholders ***` |

Chuỗi triệu chứng hay gặp nhất: `IL2CPP.load` báo `binary reader = NULL` → mọi
`EXPORT.done` vẫn có số chars lớn (vì khung class vẫn sinh) nhưng file `.cs` không
có thân hàm nào. Nguyên nhân gần như luôn là bước 3 (mục 5).

---

## 17. Bảng tra nhanh source

| Chức năng | File:line |
|---|---|
| Quét file, chọn binary, gọi pipeline | [ManyCodeCls.cs:4058-4160](Recovered/DevXUnityUnpackerTools/ManyCodeCls.cs#L4058) |
| Cổng bật/tắt pipeline | [-.cs:48602](Recovered/DevXUnityUnpackerTools/-.cs#L48602) |
| **Orchestrator** | [DMP4/-.cs:9838](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L9838) |
| Reset state giữa hai run (`DeCompile_2`) | [DMP4/-.cs:9800](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L9800) |
| Đọc metadata | [DMP4/-.cs:3132](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L3132) |
| Nhận dạng binary + Search | [DMP4/-.cs:6576](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6576) |
| `CreateDummyDlls` | [DMP4/-.cs:6747](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6747) |
| Bảng offset method | [DMP4/-.cs:6793](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L6793) |
| Ghi type ra C# | [DMP4/-.cs:11258](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11258) |
| Gọi lift + emit thân hàm | [DMP4/-.cs:11885-11902](Recovered/DevXUnityUnpackerTools/DMP4/-.cs#L11885) |
| Lift ARM/x86 (2 lượt) | [ARMD/-.cs:6032](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L6032) |
| Dispatch kiến trúc | [ARMD/-.cs:27](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L27) |
| Emit + cổng demo | [ARMD/-.cs:10505](Recovered/DevXUnityUnpackerTools/ARMD/-.cs#L10505) |
| Lift WebAssembly | [WASD/-.cs:7322](Recovered/DevXUnityUnpackerTools/WASD/-.cs#L7322) |
| Binding Capstone | [DSMCaps/-.cs:308-450](Recovered/DevXUnityUnpackerTools/DSMCaps/-.cs#L308) |
| Disassembler ARM32 dự phòng | [ARMD/Disassembler.cs](Recovered/DevXUnityUnpackerTools/ARMD/Disassembler.cs) |
| Nạp/chọn `.dvxil2c` | [-.cs:36095](Recovered/DevXUnityUnpackerTools/-.cs#L36095), [-.cs:36127](Recovered/DevXUnityUnpackerTools/-.cs#L36127) |
| Serialize/deserialize `.dvxil2c` | [-.cs:37637-37720](Recovered/DevXUnityUnpackerTools/-.cs#L37637) |
| Cipher của `.dvxil2c` | [-.cs:40059](Recovered/DevXUnityUnpackerTools/-.cs#L40059) |
| Sinh `.cpp` kiểm chứng struct | [-.cs:37500](Recovered/DevXUnityUnpackerTools/-.cs#L37500) |
| Tách theo separator | [as/-.cs:33941](Recovered/DevXUnityUnpackerTools/as/-.cs#L33941) |
| Ghi `.cs` + `.meta` | [as/-.cs:34040](Recovered/DevXUnityUnpackerTools/as/-.cs#L34040) |
| Sinh GUID script | [as/-.cs:33993](Recovered/DevXUnityUnpackerTools/as/-.cs#L33993) |
| Nhánh Mono (ILSpy/dnSpy) | [-.cs:39900](Recovered/DevXUnityUnpackerTools/-.cs#L39900) |
| Cấu hình chế độ trong UI | [ImportSettings.cs:547](Recovered/DevXUnityUnpackerTools/DevXUnityUnpackerTools._WinForm/ImportSettings.cs#L547) |

---

## 18. So sánh với công cụ công khai

| | Il2CppDumper | **DevX (tài liệu này)** | Il2CppInspector |
|---|---|---|---|
| Metadata → khung class | ✅ | ✅ (cùng thuật toán, cùng tên struct) | ✅ |
| Dummy DLL bằng Cecil | ✅ | ✅ | ✅ |
| Bảng offset method | ✅ | ✅ | ✅ |
| **Lift thân hàm → C#** | ❌ | ✅ (ARM32/64, x86/64, WASM) | ❌ |
| **DB layout struct runtime theo từng Unity version** | ❌ | ✅ (368 file `.dvxil2c`) | một phần (C++ header) |
| Xuất thẳng ra project Unity mở được | ❌ | ✅ (GUID + meta + scene/prefab) | ❌ |

Thư mục [DMP4/](Recovered/DevXUnityUnpackerTools/DMP4/) gần như là một bản port của
Il2CppDumper (trùng tên struct, trùng chiến lược `PlusSearch`/`Search`/`SymbolSearch`).
Giá trị riêng của DevX nằm ở **mục 9 (DB struct) + mục 11 (bộ lift) + mục 12 (xuất
project)** — đó cũng đúng là những phần bị khóa sau license (cổng demo ở 11.5).
