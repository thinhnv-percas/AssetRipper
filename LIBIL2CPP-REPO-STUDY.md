# Nghiên cứu: sinh `structdb/` và `typetreedb/` từ repo MlgmXyysd/libil2cpp

Nguồn khảo sát: <https://github.com/MlgmXyysd/libil2cpp> (`master`, `df0b514`).

## Kết luận ngắn

| Bộ DB | Sinh được từ repo này? | Ghi chú |
|---|---|---|
| `structdb/` | **Được**, 1218/1221 phiên bản | Đã dựng thử 5 bản trải 4 thời kỳ, đối chiếu với DB của DevX: **0 sai lệch `sizeof`, 0 sai lệch vị trí bit** |
| `typetreedb/` | **Không** | Repo có **0 file** liên quan type-tree/serialization — sai tầng dữ liệu, xem §5 |

Giá trị chính không phải là "thêm phiên bản mới": repo cho phép **tái sinh độc lập
368/370 file `structdb/` hiện có mà không cần bất kỳ dữ liệu nào của
DevXUnity-Unpacker**, đồng thời lấp khoảng trống 2021.2.10f1 → 6000.0.5f1 mà không
phải cài một bản Unity Editor nào.

---

## 1. Repo có gì

Không phải một cây source theo nhánh/tag. Toàn bộ 1222 commit được đẩy trong cùng
ngày **2024-06-11**; cây `HEAD` chứa **mọi phiên bản cạnh nhau**:

```
libil2cpp/Unity_<nhánh>/<phiên bản>/…      ví dụ  libil2cpp/Unity_2021.2/2021.2.9f1/
```

* **1221** thư mục phiên bản, từ `4.6.2f1` tới `6000.0.5f1`; **1218** có source thật
  (3 bản 4.6.2f1–4.6.4f1 là placeholder, Unity chưa ship source il2cpp).
* **587** trong số đó là bản release (`fN`), phần còn lại là alpha/beta/patch.
* **528** cây khác nhau về nội dung → chỉ cần 528 lượt chạy clang, phần còn lại là
  bản sao (khử trùng lặp qua `index.json` giống cách `typetreedb/` đang làm).
* Repo **dừng ở 6000.0.5f1** (tháng 6/2024) và từ đó không cập nhật.

### Bốn thời kỳ bố cục header

`tools/structdb_gen.py` đang hard-code một danh sách `HEADERS` duy nhất, chỉ đúng
với thời kỳ 3. Đây là lý do duy nhất khiến các bản cũ không dựng được:

| Thời kỳ | Phạm vi | Số dir | Header đặc trưng |
|---|---|---|---|
| 1 — tên cũ | 4.6.2f1 → 2017.2.5f1 | 342 | `class-internals.h`, `blob.h`, `object-internals.h`, `tabledefs.h`, `metadata.h` (không có tiền tố `il2cpp-`) |
| 2 — tên mới | 2017.3.0b1 → 2020.1.17f1 | 395 | `il2cpp-class-internals.h` … nhưng **chưa** có `vm/GlobalMetadataFileInternals.h` |
| 3 — tách global metadata | 2020.2.0a10 → 6000.0.5f1 | 484 | thêm `vm/GlobalMetadataFileInternals.h` + `vm/GlobalMetadata.cpp` + `pch/` |

Ở thời kỳ 1–2, `Il2CppGlobalMetadataHeader` nằm trong `il2cpp-metadata.h` (hoặc
`metadata.h`), và số metadata version nằm ở `vm/MetadataCache.cpp`
(`IL2CPP_ASSERT(s_GlobalMetadataHeader->version == 24);`) chứ không phải
`vm/GlobalMetadata.cpp`.

---

## 2. Bằng chứng: structdb sinh được, và số liệu khớp

Chạy thẳng `build_one()` của `tools/structdb_gen.py` với `lib` trỏ vào thư mục
phiên bản trong repo, clang 18 của hệ thống, target `x86_64-linux-gnu`. Thay đổi
duy nhất: lọc `HEADERS` theo file có thật.

| Phiên bản | Thời kỳ | Kết quả | Round-trip `static_assert` |
|---|---|---|---|
| 5.6.7f1 | 1 | 65 struct, 11 enum | PASS (65 sizeof + 573 offsetof) |
| 2017.4.40f1 | 1 | 64 struct, 12 enum | PASS (64 sizeof + 579 offsetof) |
| 2019.4.40f1 | 2 | 82 struct, 12 enum | PASS (82 sizeof + 769 offsetof) |
| 2021.2.9f1 | 3 | 88 struct, 13 enum | PASS (88 sizeof + 802 offsetof) |
| 6000.0.5f1 | 3 | 88 struct, 13 enum | PASS (88 sizeof + 805 offsetof) |

### Đối chiếu với DB của DevXUnity (nguồn `dvxil2c`)

Ba phiên bản có sẵn file DevX để so:

| Phiên bản | Struct chung | Sai lệch `size` | Sai lệch offset | Sai lệch **vị trí bit tuyệt đối** |
|---|---|---|---|---|
| 5.6.7f1 | 50 | **0** | 4 | **0** |
| 2017.4.40f1 | 50 | **0** | 4 | **0** |
| 2021.2.9f1 | 72 | **0** | 7 | **0** |

Toàn bộ "sai lệch offset" đều là bitfield của `Il2CppClass` và **không phải sai
số liệu** — chỉ là khác quy ước chọn byte mở đầu cụm bitfield (DevX ghi 307, clang
ghi 306). Tính `offset*8 + bitOffset` thì cả 15/12/12 bitfield khớp tuyệt đối, và
`bits` giống hệt. Khác biệt này **đã tồn tại sẵn** giữa hai nguồn của `structdb/`:
file `2022.3.62f2-x64.json` (nguồn `clang`) cũng ghi theo đúng quy ước 306, cũng
làm phẳng struct lồng (`byval_arg.attrs` thay vì `byval_arg`). Nói cách khác, output
sinh từ repo **trùng khít với output mà `structdb_gen.py` vốn đã sinh từ Unity Editor**.

Bản sinh từ repo còn dư 15–16 struct so với DevX (`Il2CppObject`, `Il2CppString`,
`Il2CppArray`, `Il2CppDelegate`, `Il2CppThread`, …) — DevX không lưu nhóm này.
Ngược lại chỉ mất đúng một struct: `Il2CppGenericMethodIndices`.

### Độ phủ

| | Số lượng |
|---|---|
| Phiên bản trong `structdb/` hiện tại | 370 |
| Trong đó tái sinh được từ repo | **368** |
| Không có trong repo | 2 — `2022.3.62f2`, `6000.3.18f1` (đúng hai bản nguồn `clang`, mới hơn mốc 6/2024 của repo) |
| Phiên bản repo có mà `structdb/` chưa có | 850 (222 bản release `fN`) |

Nghĩa là repo lấp trọn khoảng **2021.2.10f1 → 6000.0.5f1** đang trống.

---

## 3. Cần sửa gì trong `tools/structdb_gen.py`

Bốn thay đổi, không cái nào lớn:

1. **`HEADERS` theo phiên bản.** Lọc theo file có thật, cộng thêm tên thời kỳ 1
   (`class-internals.h`, `blob.h`, `object-internals.h`, `tabledefs.h`, `metadata.h`).
   Đây là thay đổi duy nhất bắt buộc — có nó là cả 4 thời kỳ dựng sạch.
2. **`metadata_version()` fallback.** Không thấy `vm/GlobalMetadata.cpp` thì đọc
   `vm/MetadataCache.cpp`, regex `s_GlobalMetadataHeader->version\s*==\s*(\d+)`.
3. **Nguồn thứ hai bên cạnh Unity Hub.** Thêm `--libil2cpp-repo <path>`;
   `find_unity_installs()` hiện chỉ quét `Editor/Data/il2cpp/libil2cpp`, cần một
   hàm liệt kê song song quét `libil2cpp/Unity_*/*/`.
4. **Khử trùng lặp.** 1221 dir chỉ có 528 cây khác nhau; nên gộp như `typetreedb/`
   (đặt tên file theo bản cũ nhất trong nhóm, `index.json` ánh xạ đủ mọi version)
   thay vì ghi 2442 file JSON gần như trùng nhau.

---

## 4. Giới hạn phải biết trước

* **32-bit vẫn cần sysroot.** `ARCHS` dùng `armv7a-linux-androideabi21`; clang trần
  của hệ thống không có sysroot nên `#include <string.h>` là fail. Cách đúng vẫn là
  clang trong **Android NDK** (tải rời được, không cần cài Unity Editor). Đừng thay
  bằng `i386-linux-gnu`: i386 canh `int64_t` theo 4 byte còn ARM theo 8 byte, layout
  x32 sẽ sai ở struct nào có field 64-bit lệch cụm. (Với 2021.2.9f1 thì hai ABI trùng
  nhau — chỉ có `Il2CppPerfCounters` chứa `uint64_t`, và nó rơi đúng mốc 8 byte —
  nhưng đó là may, không phải bảo đảm.)
* **Repo đứng yên từ 6/2024.** Mọi bản từ `6000.0.6f1` trở đi (gồm cả 6000.1/6000.2/
  6000.3 và `2022.3.62f2`) vẫn phải sinh từ Unity Editor cài trên máy — đúng con
  đường đã dùng cho 2 file `clang` hiện có. Repo không thay thế đường đó, nó chỉ
  xử lý phần lịch sử.
* **Nguồn không chính thức.** Đây là bản dump lại từ Unity installer do bên thứ ba
  đẩy lên, không phải kênh của Unity. Chấp nhận được vì mọi file sinh ra đều đi kèm
  round-trip `static_assert` tự kiểm chứng, nhưng nên ghi rõ `source.origin` trong
  JSON để phân biệt với đường Unity Editor.

---

## 5. Vì sao `typetreedb/` không thể lấy từ đây

Hai bộ DB dễ bị nhầm vì cùng chọn theo Unity version, nhưng chúng ở **hai tầng khác
hẳn nhau**:

* `structdb/` = layout struct C của **runtime IL2CPP** (`Il2CppClass`, `MethodInfo`…)
  → nằm trong `libil2cpp/`, tức đúng thứ repo này chứa.
* `typetreedb/` = **type-tree của Unity built-in classes** (`GameObject`, `Transform`,
  `AnimationCurve`… kèm `classID`, `metaFlag`, `serializedVersion`) → thuộc engine
  C++ và trình serialize của Unity, **không thuộc `libil2cpp/`**.

Quét toàn bộ 988.256 đường dẫn của repo: **0 file** khớp `typetree`, `ClassID`,
`SerializedFile`, `UnityType`, hay bất kỳ basename nào chứa `serial`. Không có gì
để trích.

Ba đường sinh `typetreedb/` trong `tools/typetreedb_gen.py` vẫn là đường đúng và
không có gì thay thế: `from-zip` (bootstrap từ DB cũ), `from-dumps`
(AssetRipper/TypeTreeDumps, `InfoJson/`), `from-serialized` (AssetBundle tự build
bằng đúng bản Unity đó).

---

## 6. Tái lập thí nghiệm

```bash
# repo rất lớn — clone blobless rồi sparse-checkout đúng version cần
git clone --filter=blob:none https://github.com/MlgmXyysd/libil2cpp.git
cd libil2cpp
git sparse-checkout init --cone
git sparse-checkout set libil2cpp/Unity_2021.2/2021.2.9f1
```

```python
# lọc HEADERS theo file có thật rồi gọi thẳng build_one()
import os, sys, tempfile, json
sys.path.insert(0, "tools"); import structdb_gen as G
CAND = ["il2cpp-config.h", "il2cpp-api-types.h", "il2cpp-blob.h", "il2cpp-metadata.h",
        "il2cpp-runtime-metadata.h", "il2cpp-class-internals.h", "il2cpp-object-internals.h",
        "il2cpp-tabledefs.h", "vm/GlobalMetadataFileInternals.h",
        "blob.h", "metadata.h", "class-internals.h", "object-internals.h", "tabledefs.h"]
lib = "…/libil2cpp/Unity_2021.2/2021.2.9f1"
G.HEADERS = [h for h in CAND if os.path.isfile(os.path.join(lib, h))]
doc, dropped = G.build_one("/usr/bin/clang", lib, "2021.2.9f1", 0,
                           "x64", "x86_64-linux-gnu", 8, 8, tempfile.mkdtemp(), True)
```

Đối chiếu: so `structs[*].size` và `offset*8 + bitOffset` với file tương ứng trong
`structdb/`. Round-trip: `G.verify_file(clang, lib, target, workdir, path)`.
