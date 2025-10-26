# Hollyhock Customization Tool

Hollyhock Customization Tool is a Windows Forms utility for modifying the Hollyhock firmware and launcher resources for the **fx-CP400**.  
It extracts RCDATA_3070 from the OS update DLL, lets you patch launcher menu text, version string and launcher filename (or supply a custom decompressed binary), recompresses the firmware and replaces the resource so the OSUpdate routine can flash it.

**This project is distributed as source — you must compile it yourself.**  
I am **not** responsible if you brick your calculator or destroy any device. Use at your own risk, on legally owned hardware only.

---

## Quick facts / TL;DR

- Target device: **fx-CP400** (this tool is written specifically for that model).  
- You **must compile** the project from source to produce `HollyhockCustomizer.exe`.  
- Not responsible for bricked calculators, lost data, or legal issues. No bullshit.  
- The tool expects several files next to the compiled `.exe`:  
  - `OSupdateDLL_original.dll`  
  - `fxASPI.dll`  
  - `LanguageResource.dll`  
  - `messages.txt`

---

## Features

- Integrity checks (checksums) for required DLLs and messages file.  
- Option to use a custom decompressed firmware binary or modify the embedded resource.  
- Edit fields:
  - Launcher Menu Text (max 18 bytes)
  - Version String (max 11 bytes)
  - Launcher File Name (max 7 bytes)
- Extract → verify → decompress → modify → recompress → replace resource → call OSUpdate.  
- Operation log written to `output.txt`.  
- Quick links to the project GitHub and Discord integrated into the UI.

---

## Build / Compile (short, practical)

Assumption: project is a `.NET Framework` Windows Forms project (uses `System.Windows.Forms`). If your project file is different, adjust accordingly.

1. Open the solution in **Visual Studio** (2019/2022) or another Windows .NET-capable IDE.  
2. Target **.NET Framework 4.x** (match whatever the project file expects).  
3. Set configuration to `Release` and platform to `x86` (most firmware/DLL interop expects 32-bit; switch only if you know binary requires x64).  
4. Build → `Build Solution`. The produced `HollyhockCustomizer.exe` will be in `bin\Release\`.  
5. Copy the required DLLs and `messages.txt` next to the `.exe` before running.

If you prefer command line:
- Use `msbuild YourSolution.sln /p:Configuration=Release /p:Platform=x86` (adjust names).

---

## Usage

1. Place the compiled `HollyhockCustomizer.exe` and the required files (listed above) into the same folder.  
2. Run `HollyhockCustomizer.exe`. The app will verify checksums and exit if any file fails verification.  
3. Toggle **Custom Firmware** to either:
   - Use built-in resource modification (edit the text fields), or
   - Supply your own decompressed `decompressed.bin` via Browse.  
4. Click **Flash ROM** to run the full routine. Monitor the on-screen output (and `output.txt`) for progress and errors.

Constraints are enforced (text byte limits). If you exceed limits the tool will refuse to proceed.

---

## Failure modes & logs

- All important steps append human-readable lines to `output.txt`. If something fails, paste the content of that file when asking for help.  
- The tool currently lacks exhaustive exception handling in some internal calls — expect raw error messages in the output in edge cases.

---

## Legal / Liability / Safety (read this)

- You are fully responsible for the consequences of using this tool. I will not help recover damaged hardware caused by misuse.  
- Use only on your own fx-CP400 or with explicit permission. Do not use this to tamper with devices you don't own.  
- This tool modifies firmware resources and invokes OS update routines — that is inherently risky. Proceed only if you understand firmware flashing basics.

---

## Support / Links

- GitHub: https://www.github.com/PyCSharp/  
- Discord: https://discord.gg/knpcNJTzpd

---

## Notes for maintainers / hackers

- Checksums are hard-coded — update them if you replace the required DLLs/resources.  
- The code assumes little-endian offsets and fixed byte offsets (see `Resources.ModifyFirmware` calls). If devices differ, you'll need to trace offsets and adapt.  
- If you want safer operation: add full exception handling, make backups of original DLLs/resources before replacing, and implement dry-run + checksum snapshotting.

---

## Short disclaimer (again)

**Must compile yourself.** **Not responsible if the calculator is bricked.** This is for the **fx-CP400** only. Use with knowledge and care.
