# structdb — layout struct runtime IL2CPP, dạng JSON không mã hóa

368 phiên bản Unity (**5.1.0f3 → 2021.2.9f1**), mỗi bản 2 file (x32 / x64) =
**736 file + `index.json`**, tổng ~62 MB.

Đây là bản giải mã đầy đủ của `StreamingAssets/IL2CPPStructs/*.dvxil2c` trong
DevXUnity-Unpacker. Không cipher, không GZip, đọc bằng mắt và `git diff` được.
Cách dùng trong pipeline: xem [../IL2CPP-REBUILD-GUIDE.md](../IL2CPP-REBUILD-GUIDE.md) §10.

---

## Vì sao bộ này tồn tại

Khi lift mã máy về C#, bạn gặp `LDR x8, [x0, #0x18]`. Không có DB layout thì đó
chỉ là "đọc 8 byte tại offset 0x18". Có DB thì nó là `methodInfo->klass`.

DB được DevX dựng bằng cách **biên dịch header IL2CPP thật của từng bản Unity rồi
đọc `sizeof`/offset ra**, không phải đoán — nên số liệu trong đây là chính xác
cho đúng bản Unity ghi trên tên file.

---

## Độ tin cậy

Bộ này đã được kiểm chứng chứ không chỉ "chạy xong không lỗi":

* **368/368 file giải mã thành công, mỗi file dư đúng 0 byte** sau khi parse. Đây
  là bằng chứng mạnh nhất rằng model format đúng hoàn toàn — sai một field là
  lệch toàn bộ phần đuôi.
* **Đối chiếu chéo:** `MethodInfo.klass` có `arrayItemSize = 304`, đúng bằng
  `sizeof(Il2CppClass) = 304` đọc độc lập từ cùng file.
* **Bitfield:** `Il2CppType` có 6 bitfield với `bitOffset` cộng dồn ra đúng
  0, 16, 24, 29, 30, 31 — tổng tròn 32 bit.
* **Quét bất biến toàn bộ 736 file:** offset không âm, tăng dần, nằm trong
  `sizeof`, con trỏ đúng 4/8 byte theo kiến trúc. Chỉ còn đúng một dạng ngoại lệ
  và nó hợp lệ — xem "Bẫy" §3 bên dưới.

---

## Bố cục file

```
structdb/
├── index.json                 ← danh sách version + tên file
├── 5.1.0f3-x32.json
├── 5.1.0f3-x64.json
├── …
└── 2021.2.9f1-x64.json
```

Phân bố theo nhánh Unity:

| Nhánh | Số bản | Nhánh | Số bản |
|---|---|---|---|
| 5.1 – 5.6 | 43 | 2019.1 – 2019.4 | 92 |
| 2017.1 – 2017.4 | 55 | 2020.1 – 2020.3 | 55 |
| 2018.1 – 2018.4 | 85 | 2021.1 – 2021.2 | 38 |

Số struct mỗi file tăng dần theo thời gian: **25** (Unity 5.1) → **74** (Unity 2021.2).

---

## Định dạng

```jsonc
{
  "schema": 1,
  "unityVersion": "2021.2.9f1",
  "pointerSize": 8,                    // 4 cho x32
  "source": { "origin": "…", "file": "2021.2.9f1.dvxil2c", "formatVersion": 1 },

  "structs": {
    "Il2CppStringLiteral": {
      "size": 8,
      "fields": [
        { "name": "length",    "type": "uint32_t", "offset": 0, "size": 4 },
        { "name": "dataIndex", "type": "int32_t",  "offset": 4, "size": 4,
          "realType": "StringLiteralIndex" }
      ]
    }
  },

  "enums":    { "Il2CppTypeEnum": "IL2CPP_TYPE_END = 0x00,IL2CPP_TYPE_VOID = 0x01,…" },
  "defines":  { "TypeIndex": "int32_t", "IL2CPP_ZERO_LEN_ARRAY": "0" },
  "typedefs": { }
}
```

### Field trong `structs[*].fields[]`

| Khóa | Ý nghĩa |
|---|---|
| `name` | Tên field. Field trong union lồng có tên dạng `data.klass` |
| `type` | Kiểu C đã giải typedef (`int32_t`, `Il2CppClass*`, `VirtualInvokeData[0]`) |
| `realType` | Chỉ có khi khác `type` — tên typedef gốc (`MethodIndex`, `StringLiteralIndex`) |
| `offset` | Offset byte tính từ đầu struct |
| `size` | Kích thước byte. **Vắng mặt khi field là bitfield** |
| `bits` | Bề rộng bitfield (bit). Chỉ có với bitfield |
| `bitOffset` | **Vị trí bit thật** trong đơn vị lưu trữ tại `offset` — đã tính sẵn |
| `bitOrdinal` | Số thứ tự bitfield như DevX lưu. Giữ lại để truy vết, **đừng dùng** |
| `arrayItemSize` | Kích thước phần tử / kiểu được trỏ tới. Đọc kỹ bẫy §2 |
| `union` | `true` nếu field thuộc một union bên trong struct |

`enums` và `defines` là chuỗi C thô, giữ nguyên như DevX lưu — hữu ích khi cần
tái sinh header C++ để kiểm chứng.

---

## Bốn cái bẫy (đã kiểm chứng, không phải suy đoán)

### 1. `bitOrdinal` không phải vị trí bit

DevX lưu **số thứ tự** của bitfield trong đơn vị lưu trữ, không phải vị trí bit.
`Il2CppType` có `attrs` (16 bit) rồi `type` (8 bit); DevX ghi `bitOrdinal` = 0 và 1,
trong khi vị trí bit thật là 0 và 16.

**`bitOffset` đã được tính sẵn khi sinh JSON này** bằng cách cộng dồn bề rộng.
Dùng `bitOffset`, bỏ qua `bitOrdinal`:

```csharp
uint raw = ReadUInt32(baseAddr + field.Offset);
uint value = (raw >> field.BitOffset) & ((1u << field.Bits) - 1);
```

### 2. `arrayItemSize` là **dsize**, không phải `sizeof`

Với con trỏ, `arrayItemSize` là kích thước dữ liệu của kiểu được trỏ tới **không
tính padding đuôi**. Trong 168 cặp kiểm tra được ở bản 2021.2.9f1: **155 khớp
`sizeof`, 13 lệch** — và cả 13 đều là những kiểu có padding đuôi.

Ví dụ cụ thể: `Il2CppType` có `size = 16` nhưng field cuối kết thúc ở byte 12,
nên mọi `Il2CppType*` đều mang `arrayItemSize = 12`.

> **Hệ quả:** đừng dùng `arrayItemSize` làm stride khi duyệt mảng. Duyệt mảng
> `Il2CppType[]` với bước 12 sẽ lệch ngay từ phần tử thứ hai. Luôn dùng
> `structs["Il2CppType"].size`.

`arrayItemSize` chỉ nên dùng để **nhận dạng** kiểu khi truy vết chuỗi dereference.

### 3. `Il2CppClass.vtable` nằm **tại** `sizeof`

```json
{ "name": "vtable", "type": "VirtualInvokeData[0]", "offset": 312, "size": 0,
  "arrayItemSize": 16 }
```

Với `sizeof(Il2CppClass) = 312`. Đây **không phải lỗi dữ liệu** — đó là flexible
array member ở cuối struct (`IL2CPP_ZERO_LEN_ARRAY`, thấy trong `defines`). Trình
kiểm tra bất biến của bạn phải cho phép trường hợp `offset == size && size_of_field == 0`,
nếu không nó sẽ báo 680 lỗi giả trên toàn bộ bộ DB.

Truy cập đúng: `vtable[i]` ở địa chỉ `klass + 312 + i * 16`.

### 4. Union được làm phẳng

Field trong union mang `"union": true` và **nhiều field cùng `offset`**. Ví dụ
`Il2CppType` có 8 field khác nhau đều ở `offset: 0`. Khi giải một lần đọc bộ nhớ,
bạn phải chọn nhánh union dựa vào ngữ cảnh (thường là field `type`), hoặc trả về
cả danh sách ứng viên và để bước sau quyết định.

---

## Loader C#

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;

public sealed class StructDb
{
    [JsonPropertyName("unityVersion")] public string UnityVersion { get; set; } = "";
    [JsonPropertyName("pointerSize")]  public int PointerSize { get; set; }
    [JsonPropertyName("structs")]      public Dictionary<string, StructInfo> Structs { get; set; } = new();
    [JsonPropertyName("defines")]      public Dictionary<string, string> Defines { get; set; } = new();

    public static StructDb Load(string path) =>
        JsonSerializer.Deserialize<StructDb>(File.ReadAllText(path))!;

    /// <summary>Chọn bản gần nhất khi không có bản khớp chính xác.</summary>
    public static StructDb LoadNearest(string dir, string unityVersion, bool is32Bit, out bool exact)
    {
        string tag = is32Bit ? "x32" : "x64";
        string p = Path.Combine(dir, $"{unityVersion}-{tag}.json");
        if (File.Exists(p)) { exact = true; return Load(p); }

        exact = false;
        var target = UnityVer.Parse(unityVersion);
        var best = Directory.EnumerateFiles(dir, $"*-{tag}.json")
            .Select(f => (File: f, Ver: UnityVer.Parse(Path.GetFileNameWithoutExtension(f)[..^4])))
            .Where(x => x.Ver is not null)
            .OrderBy(x => x.Ver!.Distance(target))
            .First();

        // Im lặng khi fallback là nguồn bug tệ nhất — luôn báo ra.
        Console.Error.WriteLine(
            $"[structdb] Không có DB cho Unity {unityVersion}; dùng {Path.GetFileName(best.File)}. " +
            "Offset field có thể sai nếu layout runtime đã đổi giữa hai bản.");
        return Load(best.File);
    }

    /// <summary>"MethodInfo", 24 -> "klass". Đệ quy vào struct lồng.</summary>
    public bool TryResolveField(string structName, long offset, out string path, out string type)
    {
        path = ""; type = "";
        if (!Structs.TryGetValue(Strip(structName), out var s)) return false;

        foreach (var f in s.Fields)
        {
            if (f.Bits > 0) continue;                       // bitfield xử lý riêng
            long end = f.Offset + (f.Size ?? 0);
            if (offset < f.Offset || offset >= end) continue;

            long inner = offset - f.Offset;
            string pointee = Strip(f.Type);
            if (inner > 0 && Structs.ContainsKey(pointee) && !f.Type.EndsWith("*")
                && TryResolveField(pointee, inner, out var sub, out var subT))
            {
                path = f.Name + "." + sub; type = subT; return true;
            }
            path = f.Name; type = f.Type; return true;
        }
        // Flexible array member ở cuối struct (bẫy §3)
        var flex = s.Fields.LastOrDefault(f => f.Offset == s.Size && (f.Size ?? 0) == 0);
        if (flex is not null && offset >= s.Size && flex.ArrayItemSize > 0)
        {
            long i = (offset - s.Size) / flex.ArrayItemSize;
            path = $"{flex.Name}[{i}]"; type = flex.Type;
            return true;
        }
        return false;
    }

    private static string Strip(string t) =>
        t.Replace("const ", "").Replace("struct ", "").TrimEnd('*', ' ').Split('[')[0];
}

public sealed class StructInfo
{
    [JsonPropertyName("size")]   public int Size { get; set; }
    [JsonPropertyName("union")]  public bool Union { get; set; }
    [JsonPropertyName("fields")] public List<FieldInfo> Fields { get; set; } = new();
}

public sealed class FieldInfo
{
    [JsonPropertyName("name")]          public string Name { get; set; } = "";
    [JsonPropertyName("type")]          public string Type { get; set; } = "";
    [JsonPropertyName("realType")]      public string? RealType { get; set; }
    [JsonPropertyName("offset")]        public int Offset { get; set; }
    [JsonPropertyName("size")]          public int? Size { get; set; }
    [JsonPropertyName("bits")]          public int Bits { get; set; }
    [JsonPropertyName("bitOffset")]     public int BitOffset { get; set; }
    [JsonPropertyName("arrayItemSize")] public int ArrayItemSize { get; set; }
    [JsonPropertyName("union")]         public bool Union { get; set; }
}
```

---

## Giới hạn

* **Dừng ở Unity 2021.2.9f1.** Unity 2022 / 6.x không có trong bộ này. Cách bổ
  sung: [../IL2CPP-REBUILD-GUIDE.md](../IL2CPP-REBUILD-GUIDE.md) §10.2 — cài
  Editor, chạy `clang -Xclang -fdump-record-layouts` trên header trong
  `Editor/Data/il2cpp/libil2cpp/`, sinh JSON đúng schema này. Không cần tải bản cũ.
* **Chỉ có struct DevX cần**, không phải toàn bộ runtime. Bản 2021.2 có 74 struct;
  thiếu ví dụ `Il2CppObject`, `Il2CppString`, `Il2CppArray` — nếu bộ lift của bạn
  cần chúng thì phải tự sinh bổ sung.
* **Chỉ phân biệt 32/64-bit**, không phân biệt ABI. Trên thực tế layout
  ARM64 và x86-64 giống nhau với các struct này, nhưng ARM32 và x86-32 có thể
  khác về alignment ở vài trường hợp hiếm.
* Số liệu kế thừa từ DevX. Đã kiểm chứng nội bộ nhất quán (§"Độ tin cậy") nhưng
  **chưa đối chiếu với header Unity gốc** vì các bản Unity đó không có trên máy.

---

## Tái tạo

Script giải mã: `scratchpad/dvx2json.py` + `batch.py`. Thuật toán cipher (LCG kiểu
`java.util.Random`, khóa `sdf3$wGSDGEh%$SdF2`, 2 bảng 1027 byte) được mô tả trong
[../IL2CPP-PIPELINE.md](../IL2CPP-PIPELINE.md) §9.2.
