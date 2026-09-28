# Native cross-oracle — iteration 061

Mọi native fact mà recovery dựa vào — body của một method nằm ở đâu, một field nằm ở offset nào, một
instantiation generic dùng body nào — đến từ **một** reader duy nhất, LibCpp2IL. Trước iteration này
không có gì trong pipeline kiểm tra các fact đó với một nguồn khác, nên một lỗi của reader không phân
biệt được với một tính chất của game. Báo cáo này ghi lại lần kiểm tra chéo đầu tiên.

Nhãn dùng trong báo cáo: **PROVEN** (đối chiếu trực tiếp, không có ngoại lệ), **MEASURED** (con số đo
được, chưa giải thích hết), **INFERRED** (suy ra từ bằng chứng gián tiếp), **UNKNOWN**, **BLOCKED**.

## 1. Ba reader

| Reader | Là gì | Chia sẻ code với LibCpp2IL |
|---|---|---|
| `AR` | LibCpp2IL như AssetRipper dùng, ghi ra qua `NativeFactsDump` (`CPP2IL_DUMP_NATIVE_FACTS=<file>`) | — |
| `READER` | `Test/Scripts/il2cpp_native_reader.py`, viết mới, layout lấy từ `StructDb/` | Không. Cùng chung `StructDb` là nguồn layout duy nhất |
| `R2UNITY` | `radareorg/r2unity` commit `60267a76e8b948951d289439ddcadb7df369023f`, build trên radare2 6.2.3 | Không |

`AR` ghi hai fact riêng cho mỗi method, vì chúng là hai fact khác nhau: `module` là entry của codegen
module cho token của method, đúng như binary chứa; `pointer` là địa chỉ LibCpp2IL cuối cùng gán cho
method, sau khi đã tra `genericMethodTable`. Field offset được ghi **raw**, trước phép chuyển sang
value-type frame mà `Il2CppBinary.GetFieldOffsetFromIndex` thực hiện.

`READER` tìm registration **không dùng chuỗi nào**: `Il2CppCodeRegistration` là chỗ có
`codeGenModulesCount == số image trong metadata` và mọi tên module khớp tên image;
`Il2CppMetadataRegistration` là chỗ có `fieldOffsetsCount == typeDefinitionsSizesCount == số type`.
Method pointer được nối theo luật của runtime, `methodPointers[rid(token) - 1]`.

Lệnh:

```
CPP2IL_DUMP_NATIVE_FACTS=/tmp/nf/<game>.jsonl dotnet .../AssetRipper.Tools.SystemTester.dll ...
python3 Test/Scripts/native_cross_oracle.py --fixture <name> --game Test/Input/<game> \
  --facts /tmp/nf/<game>.jsonl --unity <version> --r2unity /tmp/r2unity/r2unity --work /tmp/nf \
  --json iterations/061/native-cross-oracle/<name>.json
python3 Test/Scripts/native_cross_oracle.py --self-test     # 8 case, mỗi case đỏ khi bỏ luật nó kiểm
```

Dump chỉ được ghi khi biến môi trường được đặt. Rip của cả bốn fixture giống từng byte với baseline
khi có và khi không có nó, 0 lỗi `Decompiling`.

## 2. Kết quả AR ↔ READER — PROVEN, không có một DISAGREE nào

| Fact | RunFromZombies | Impostor | Merge-Room | JellyBlastV2 |
|---|---:|---:|---:|---:|
| Định dạng | ELF, 225108 reloc | ELF, 164579 reloc | ELF, 381496 reloc | Mach-O, không reloc |
| CodeRegistration | `0x20C56F8` AGREE | `0x185AF98` AGREE | `0x37FD758` AGREE | `0x2C723A8` AGREE |
| MetadataRegistration | `0x2169A70` AGREE | `0x18E3608` AGREE | `0x3929688` AGREE | `0x2D234B8` AGREE |
| Codegen module entry | 51393 AGREE | 33436 AGREE | 83496 AGREE | 58890 AGREE |
| Địa chỉ cuối cùng | 47457 AGREE + 3936 AR_INTERPRETATION | 30392 + 3044 | 76926 + 6570 | 54524 + 4366 |
| Field offset raw | 30189 AGREE | 21208 AGREE | 55733 AGREE | 36003 AGREE |
| `Il2CppTypeDefinitionSizes` | 7486 AGREE | 5012 AGREE | 12895 AGREE | 8702 AGREE |
| `genericMethodTable` | 44205 AGREE | 36577 AGREE | 82828 AGREE | 45952 AGREE |
| `genericMethodPointersCount` | 44058 (cả ba) | 36473 (cả ba) | 82624 (cả ba) | 45816 (cả ba) |
| `List`1::Add` / `get_Item` | 92 / 92 AGREE | 80 / 80 | 173 / 173 | 99 / 99 |

Generic được đối chiếu theo từng hình dạng instantiation (Impostor): class-only 30039, class+method 99,
method-only 6439, tất cả AGREE. Một entry gồm `methodSpec`, method definition, class inst, method inst,
chỉ số con trỏ, con trỏ, invoker và adjustor thunk.

**AR_INTERPRETATION** (MEASURED, giải thích được): trong mọi trường hợp entry codegen module của
method là `0x0` — definition không có body của riêng nó — và LibCpp2IL gán cho nó body của một
instantiation, vì `GetMethodPointer` tra `_genericMethodDictionary` trước. Ví dụ Impostor:
`IsCachedInvalidHandle`, `Create`, cặp `.ctor`/`Invoke` của delegate generic. Đây là một diễn giải
có chủ đích, không phải lỗi đọc, và không có gì bị sửa vì nó. Nó được giữ tách riêng để một kết luận
"method X có body ở Y" có thể biết đó là body của chính X hay của một instantiation.

JellyBlastV2 là bản đã giải mã: không có `LC_ENCRYPTION_INFO_64` với `cryptid` khác 0, nên mọi field
offset và mọi type size đều đọc được (0 giá trị null trong 36003 và 8702).

## 3. Value-type frame — PROVEN trên cả bốn fixture

CLAUDE.md ghi từ iteration 043 rằng offset của field value type trong metadata đã bao gồm object
header. Phép đo độc lập xác nhận và tách ba trường hợp mà trước đây bị gộp:

| | RunFromZombies | Impostor | Merge-Room | JellyBlastV2 |
|---|---:|---:|---:|---:|
| Instance field của value type, raw ≥ header | 4773 | 3558 | 8104 | 5530 |
| Static field của value type (raw là offset trong static storage) | 8788 | 5833 | 13614 | 9725 |
| Generic definition mở, không có layout | 278 | 239 | 412 | 398 |
| Instance field raw < header | 0 | 0 | 0 | 0 |

Hai nhóm sau từng đọc như "value type field raw dưới header" ở lần đo đầu tiên, và cả hai đều không
phải ngoại lệ: static field không ở trong object nên không có header, và một generic definition mở
không có layout tĩnh. Sau khi tách, **không có một instance field value type nào có raw offset nhỏ hơn
header** — phép trừ 16 của `GetFieldOffsetFromIndex` đúng ở mọi nơi nó được áp dụng.

## 4. R2UNITY — hai lỗ hổng của r2unity, không phải của AssetRipper

### 4.1 r2unity không áp relocation của ELF — PROVEN

r2unity đọc binary qua `r_bin` của radare2, và `r_bin` không áp `R_AARCH64_RELATIVE` (log: `Reloc
type 1027 not used for imports`). Mọi con trỏ trong `.data.rel.ro` của một `libil2cpp.so` đọc ra 0,
nên r2unity không đi được bảng nào. Discovery của chính nó trả về kết quả heuristic vô nghĩa trên cả ba
fixture ELF (RunFromZombies 45526, Impostor 29149, Merge-Room 76863 DISAGREE).

Để vẫn có một kiểm tra độc lập, r2unity được chạy trên một bản sao đã được `READER` áp relocation, với
anchor từ `READER` (`-O g_CodeRegistration=...`). Nhãn đầu vào ghi rõ điều đó:
`RELOCATED_BY_READER + ANCHOR_FROM_READER`. Như vậy trên ELF, r2unity độc lập ở **phép join**, không
độc lập ở việc tìm bảng.

Trên JellyBlastV2 (Mach-O, con trỏ đã nằm sẵn trong `__DATA`) discovery của r2unity tự tìm được
codegen modules và cho kết quả **giống hệt** bản có anchor. Đây là fixture duy nhất r2unity độc lập
hoàn toàn với `READER`.

### 4.2 r2unity nối method theo thứ tự hàng, không theo token — PROVEN

| | RunFromZombies | Impostor | Merge-Room | JellyBlastV2 |
|---|---:|---:|---:|---:|
| R2UNITY AGREE | 33578 | 21590 | 52389 | 37640 |
| R2UNITY DISAGREE | 17815 | 11846 | 31107 | 21250 |
| trong đó `R2UNITY_SEQUENTIAL_SCATTER` | 17815 | 11846 | 31107 | 21250 |
| trong đó chưa giải thích | 0 | 0 | 0 | 0 |

r2unity lấy entry thứ *k* của bảng method của module cho method thứ *k* của image. Runtime của il2cpp
lấy `methodPointers[rid(token) - 1]`. Hai cách trùng nhau chừng nào thứ tự method trong metadata trùng
thứ tự token, và lệch ngay khi không. `READER` dựng lại đúng phép join tuần tự đó (`sequential_join`)
và nó giải thích **toàn bộ** các DISAGREE trên cả bốn fixture, không còn một cái nào.

Trọng tài độc lập với cả hai phép join: một getter của auto-property có body là
`ldr <reg>, [x0, #offset của backing field]; ret`, và offset đó là fact mà cả ba reader đồng ý. Giải
mã lệnh đầu ở mỗi địa chỉ ứng viên:

| | RunFromZombies | Impostor | Merge-Room | JellyBlastV2 |
|---|---:|---:|---:|---:|
| Chỉ địa chỉ của `READER` load đúng field | 238 | 148 | 359 | 201 |
| Chỉ địa chỉ của `R2UNITY` | **0** | **0** | **0** | **0** |
| Cả hai (hai getter có body giống nhau) | 4 | 13 | 4 | 3 |
| Không cái nào (getter đọc static storage, không đọc `x0`) | 27 | 25 | 91 | 39 |

Máy tự trả lời phép join nào đúng: rid của token.

## 5. Những gì chưa kiểm tra được

- **Field offset, type size, generic table qua r2unity — R2UNITY_UNAVAILABLE.** r2unity chỉ khôi phục
  method pointer; nó không đọc `fieldOffsets`, `typeDefinitionsSizes`, `genericMethodTable` hay
  `methodSpecs`. Với các bảng đó chỉ có hai reader, và `READER` dùng chung `StructDb` với phép patch
  offset của AssetRipper. Một lỗi *trong StructDb* sẽ không bị lộ ra ở đây — UNKNOWN.
- **Một App Store build còn mã hoá** (JellyBlast v1): không có trong ma trận này, vì `__TEXT` không đọc
  được với bất kỳ reader nào. `READER` đánh dấu vùng mã hoá qua segment và trả `null` ở đó, cùng luật
  với `IsVirtualAddressEncrypted`.
- **Chained fixups**: không fixture nào có `LC_DYLD_CHAINED_FIXUPS`, nên `READER` chỉ ghi cờ và không
  áp. BLOCKED do thiếu fixture.
- **PE** (Windows `GameAssembly.dll`): `READER` không đọc PE. BLOCKED do thiếu fixture.
- `unity_range` của r2unity báo `2023.x-6000.x` cho cả bốn build 2022.3 — nhãn của r2unity, không ảnh
  hưởng gì đến phép so sánh.

## 6. Hệ quả cho recovery

Không có gì trong recovery được sửa vì báo cáo này, và đó là kết luận: trên 4 fixture, 227215 method
entry, 143133 field offset, 34095 type size và 209562 generic entry, LibCpp2IL và một reader độc lập
đồng ý tuyệt đối. Những chỗ hai tool khác nhau đều là lỗi của r2unity, được xác định nguyên nhân và
được một trọng tài thứ ba — máy — phân xử. Mọi lỗi native mapping còn lại trong recovery phải được tìm
ở tầng sau registration: CFG, SSA, provenance hoặc typing.

Nguyên liệu: `iterations/061/native-cross-oracle/<fixture>.json` và `.txt`.
