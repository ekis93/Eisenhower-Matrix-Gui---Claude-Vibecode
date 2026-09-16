# Eisenhower Matrix Gui - Claude Vibecode
A repo for testing vibe coding using Claude.ai.

The gui is structured after the Eisenhower Matrix. 
You input a text string for a task and then pick if it's urgent, important, both, or neither.
The task will then be sorted into one of the four categories in the matrix.

[See full guide here.](Eisenhower_Matrix_CSharp_Linux_Guide.pdf)

<img width="1918" height="1037" alt="Eisenhower Matrix" src="https://github.com/user-attachments/assets/0c1a4eb0-b8e5-4285-a8be-fb9bb6d4745b" />

## Requirements
- [.NET SDK 8.0 or newer](https://dotnet.microsoft.com/download)

## Running the App

```bash
dotnet run
```

## Building Standalone Executables

Build a self-contained executable for your platform:

**Linux (64-bit):**
```bash
dotnet publish -c Release -r linux-x64 --self-contained
```
Output: `bin/Release/net8.0-linux/linux-x64/publish/EisenhowerMatrix`

Run with:
```bash
./EisenhowerMatrix
```

**Windows (64-bit):**
```bash
dotnet publish -c Release -r win-x64 --self-contained
```
Output: `bin/Release/net8.0-windows/win-x64/publish/EisenhowerMatrix.exe`

Double-click the `.exe` to run.

---

The `-c Release` flag optimizes the build, and `--self-contained` bundles the .NET runtime so users don't need to install it separately.
