# Hollyhock Customization Tool

Hollyhock Customization Tool is a Windows Forms utility for modifying the Hollyhock firmware.
It extracts RCDATA_3070 from the OS update DLL, lets you patch launcher menu text, version text and launcher filename (or supply a custom decompressed binary), recompresses the firmware and replaces the resource so the OSUpdate routine can flash it.

**This project is distributed as source — you must compile it yourself.**  
I am **not** responsible if you brick your calculator. Use at your own risk, on legally owned hardware only.

---

## Quick facts

- Target device: **fx-CP400** and **fx-CG500**.
- You **must compile** the project from source to produce `HollyhockCustomizationTool.exe`.  
- Not responsible for bricked calculators, lost data, or legal issues.
- The tool expects several files(in bin/Debug) next to the compiled `.exe`:  
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
  - Version Text (max 11 bytes)
  - Launcher File Name (max 7 bytes)
- Extract → verify → decompress → modify → recompress → replace resource → call OSUpdate.  
- Operation log written to `output.txt`.  
- Quick links to the project GitHub and Discord integrated into the UI.

---

## Build / Compile

1. Open the solution in **Visual Studio**.
2. Right-click on **Form1.resx** → **Properties** → enable **“Unblock”** in the bottom right  
   *This prevents resource loading errors during compile.*
3. Go to **Build → Build Solution**.  
   The executable **HollyhockCustomizationTool.exe** will appear in `bin/Debug/`.
4. Copy all required **DLLs** and **messages.txt** into the same folder as the `.exe` before running.

---

## Usage

1. Place the compiled `HollyhockCustomizationTool.exe` and the required files (listed above) into the same folder.  
2. Run `HollyhockCustomizationTool.exe`. The program will verify checksums and exit if any file fails verification.  
3. **If you encounter issues**:  
   - It’s also possible that your antivirus or anti-cheat software could block the `LoadLibrary` and other functions, preventing the program from working correctly. You might need to temporarily disable them or whitelist the tool. 
4. Toggle **Use own firmware binary** to:  
   - Supply your own decompressed `decompressed.bin` via Browse.  
5. Click **Flash ROM** to run the full routine. Monitor the on-screen output (and `output.txt`) for progress and errors.

Constraints are enforced (text byte limits). If you exceed limits the tool will refuse to proceed.

---

## Failure modes & logs

- All important steps append human-readable lines to `output.txt`. If something fails, paste the content of that file when asking for help.  
- The tool currently lacks exhaustive exception handling in some internal calls — expect raw error messages in the output in edge cases.

---

## Legal / Liability / Safety (read this)

- You are fully responsible for the consequences of using this tool. I will not help recover damaged hardware caused by misuse.  
- Use only on your own fx-CP400 or fx-CG500 with explicit permission. Do not use this to tamper with devices you don't own.  
- This tool modifies firmware resources and invokes OS update routines.

---

## Links

- ClasspadDev: https://classpaddev.github.io
- Discord: https://discord.gg/knpcNJTzpd

---

## Short disclaimer (again)

**Must compile yourself.** **Not responsible if the calculator is bricked.** This is for the **fx-CP400** and **fx-CG500** only. Use with knowledge and care.
