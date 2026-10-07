# Khả năng build và chạy — iteration 068 (§2, §17, §18, §19, §23)

Bản rip: `Test/Out68z-*`, cùng một bản build. Biến thể:
- `68zk-i`: `--package-cache Test/Input/PackageCache/JellyBlastV2`;
- `68zn-j`: `--no-cpp2il-injected-attributes --keep-global-qualification`.

Số liệu nằm ở `iterations/068/metrics` và `iterations/068/artifacts`.

## 1. Cổng Unity (§23) — UNITY_NOT_AVAILABLE

`UNITY_PATH` không đặt, và không có editor trong container. Mọi cổng runtime là `UNITY_NOT_AVAILABLE`. Không fixture nào
được gọi là `RUNTIME_VALIDATED` hay `FULLY_RECOVERED`.

## 2. Các cổng A–F (§2)

| Fixture | A Native | B Semantic (EXACT) | C Project A–C | D Compile (lỗi thân) | E Runtime | F Behaviour (tĩnh) |
|---|---|---|---|---|---|---|
| Impostor | PASS | 0.8253 | FAIL (refs 0.9942) | FAIL (156) | UNITY_NOT_AVAILABLE | 0.7587 |
| Merge-Room | PASS | 0.7431 | FAIL (refs 0.9998) | FAIL (275) | UNITY_NOT_AVAILABLE | 0.8338 |
| JellyBlastV2 | PASS | 0.7052 | FAIL (refs 1.0) | FAIL (1693) | UNITY_NOT_AVAILABLE | 0.7849 (độc lập) |
| RunFromZombies | PASS | 0.7539 | PASS (refs 1.0) | FAIL (7) | UNITY_NOT_AVAILABLE | 1.0000 |
| Pinata | PASS | 0.8006 | FAIL (refs 1.0) | FAIL (1074) | UNITY_NOT_AVAILABLE | NOT_MEASURED |

Trạng thái cao nhất đạt được: `NATIVE_RECOVERED` trên cả năm. RunFromZombies thêm qua stage A–C. Không fixture nào
compile sạch.

## 3. Package và native (§17)

- **Package.** `68zk-i` ghi manifest gồm 31 built-in module và ba package UPSTREAM_EXACT đã chứng minh: mathematics
  1.2.6, textmeshpro 3.0.9, visualscripting 1.9.11. Giống 067; 068 không thêm package nào vì không có bằng chứng mới.
- **`packages-lock.json` vẫn BLOCKED.** Không có nguồn nào để dựng hash, nên không ghi.
- **Native.** Đọc từ `iterations/068/artifacts`:
  - JellyBlastV2: sáu Facebook SDK `.framework` vào `Plugins/iOS`;
  - Merge-Room: `liblofelt_sdk.so` cho `arm64-v8a` và `armeabi-v7a` (2 file);
  - Pinata: 7 file `arm64-v8a`;
  - Impostor và RunFromZombies: không có plugin của game, đúng như 055 đã đo.

  Không thay đổi so với 067.

## 4. Shader (§18)

| Fixture | STRUCTURE_ONLY | SOURCE_RECOVERED (pass có program) | VARIANT / MATERIAL_BINDING_RECOVERED | BUILDABLE | RUNTIME_VALIDATED |
|---|---|---|---|---|---|
| Impostor | 0 | 3/3 | 7 exact + 2 modulo engine, rate 1.0 trên 9 | BLOCKED | BLOCKED |
| Merge-Room | 6 | 28/34 | 29 + 1, rate 1.0 trên 30; 5 PROGRAM_NOT_RECOVERED | BLOCKED | BLOCKED |
| JellyBlastV2 | 30 (MSL không vào ShaderLab) | 0/30 GLSL; chương trình Metal tách ra `.metal` | external program 37 + 2, rate 1.0 trên 39; 4 PROGRAM_NOT_RECOVERED | BLOCKED | BLOCKED |
| RunFromZombies | 6 | 18/24 | không có material nào trỏ tới shader không phải built-in | BLOCKED | BLOCKED |
| Pinata | 1 | 21/22 | 53 KEYWORDS_NOT_RECORDED (2019.2 không có `KeywordNames`) | BLOCKED | BLOCKED |

`shader_exact` là `NOT_MEASURED_HERE`, vì nó chỉ được quyết định khi so với ShaderLab nguồn. Code shader không đổi ở 068.
`BUILDABLE` cần Unity.

## 5. Tuỳ chọn output (§19)

| RunFromZombies | Mặc định (`68z-j`) | `--no-cpp2il-injected-attributes --keep-global-qualification` (`68zn-j`) |
|---|---|---|
| File `.cs` | 796 | 751 |
| Attribute Cpp2ILInjected (`Address`/`Token`/`FieldOffset`) | 22504 | 0 |
| `[NativeSource]` (attribute phục hồi của AssetRipper) | 3926 | 3926 |
| `global::` | 0 | 1 |
| Lỗi Roslyn Assembly-CSharp | 7 (23 file) | 7 (20 file) |

- Mặc định giữ nguyên hành vi trước 068.
- Cờ mới của `SystemTester`: `--emit-cpp2il-injected-attributes` và `--simplify-global-qualification` bật tường minh;
  `--keep-global-qualification` là bí danh của `--no-simplify-global`.
- 45 file chênh nhau là các type attribute được inject.

## 6. Sẵn sàng runtime

Project mở được trong Unity chưa được kiểm, vì không có Unity. Những gì đã biết:
- trên mọi fixture, stage A–C chỉ PASS trên RunFromZombies;
- lỗi thân còn lại ở cả năm;
- `packages-lock.json` BLOCKED;
- native plugin đủ cho JellyBlastV2.

Trạng thái: `PROJECT_GENERATED_COMPILE_IMPROVED`. Không phải `RUNTIME_VALIDATED`, không phải `FULLY_RECOVERED`.
