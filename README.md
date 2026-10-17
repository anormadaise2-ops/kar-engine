# ⚡ KAR ENGINE

### The open-source command-line toolkit by Zercraft

**KAR ENGINE** is a command-line interface (CLI) project designed to simplify diagnostics, file integrity checks, software packaging and build workflows on Windows.

Developed by **Zercraft**, KAR ENGINE aims to provide developers with a unified command-line toolkit that is easy to use, extend and automate.

> 🚧 **Current status: Early development — v0.1.0**
>
> This project is a prototype. Some commands are implemented, while package management, installation, uninstallation and signature verification are still under development.

---

## ✨ Features

* 🖥️ **Command-line interface** — Simple commands for everyday development tasks.
* 🔍 **Environment diagnostics** — Check the .NET environment.
* 🔐 **File integrity** — Calculate SHA-256 hashes.
* 🛠️ **Build system** — Restore dependencies, compile and publish the application.
* 📦 **Package management** — Planned package creation and installation workflows.
* 📋 **Logging** — Build logs and diagnostic reports.
* ⚙️ **Automation** — Designed for PowerShell and development workflows.
* 🌍 **Open source** — Public development on GitHub.

## 📋 Requirements

To build KAR ENGINE from source:

* Windows 10 or Windows 11
* Git
* .NET 8 SDK
* PowerShell

The published standalone executable is intended for Windows x64.

## 🚀 Getting Started

### Download

Visit the GitHub repository:

**https://github.com/anormadaise2-ops/kar-engine**

Published binaries will be available under **Releases** when a release has been published.

### Build from source

Clone the repository:

```powershell
git clone https://github.com/anormadaise2-ops/kar-engine.git
cd kar-engine
```

Build the project:

```powershell
dotnet restore .\src\KarEngine\KarEngine.csproj

dotnet build .\src\KarEngine\KarEngine.csproj -c Release
```

Publish a standalone Windows executable:

```powershell
dotnet publish .\src\KarEngine\KarEngine.csproj `
  -c Release `
  -r win-x64 `
  --self-contained true `
  -p:PublishSingleFile=true `
  -o .\release
```

The executable should be generated at:

```text
release\kar.exe
```

## 💻 Commands

Run these commands from the project directory:

| Command                     | Description                 | Status            |
| --------------------------- | --------------------------- | ----------------- |
| `kar help`                  | Display available commands  | Implemented       |
| `kar --version`             | Display the version         | Implemented       |
| `kar doctor`                | Check the .NET environment  | Implemented       |
| `kar status`                | Display application status  | Implemented       |
| `kar hash <file>`           | Calculate a SHA-256 hash    | Implemented       |
| `kar sign hash <file>`      | Calculate a SHA-256 hash    | Implemented       |
| `kar sign verify <file>`    | Verify a digital signature  | Planned           |
| `kar fix --scan`            | Scan for potential problems | Under development |
| `kar fix force --scan`      | Run an extended diagnostic  | Under development |
| `kar install <package.zip>` | Install a package           | Planned           |
| `kar uninstall <name>`      | Uninstall a managed package | Planned           |
| `kar package <folder>`      | Package a directory         | Planned           |
| `kar logs`                  | Display application logs    | Under development |

**Note:** The command list reflects the early prototype. Commands marked as planned or under development should not be considered production-ready.

## 🔐 File Integrity

Calculate the SHA-256 hash of a file:

```powershell
.\release\kar.exe hash ".\release\kar.exe"
```

You can also use Windows PowerShell:

```powershell
Get-FileHash ".\release\kar.exe" -Algorithm SHA256
```

SHA-256 hashes can help compare files and detect unexpected changes. A hash alone does not prove that a file is authentic or safe.

## 🛠️ Build Automation

KAR ENGINE includes a PowerShell build script in development.

When available, it will help automate:

* Dependency restoration
* Release compilation
* Standalone executable publishing
* Build error reporting
* Basic post-build tests
* Build log generation

Build automation should report failures clearly rather than silently modifying source files.

## 🗺️ Roadmap

### Phase 1 — Core CLI

* [x] Command-line entry point
* [x] Version information
* [x] Basic environment diagnostics
* [x] SHA-256 hashing
* [ ] Consistent argument parsing
* [ ] Automated CLI tests

### Phase 2 — Diagnostics and Fix

* [ ] Project and dependency scanning
* [ ] Detailed diagnostic reports
* [ ] Build error analysis
* [ ] Proposed fixes with previews
* [ ] Explicit confirmation before applying changes

### Phase 3 — Package Management

* [ ] Package format specification
* [ ] ZIP package creation
* [ ] Package integrity validation
* [ ] Installation and uninstallation
* [ ] Installation directory selection

### Phase 4 — Distribution

* [ ] Customizable Windows installer
* [ ] Versioned GitHub Releases
* [ ] Automated release builds
* [ ] Checksums for published binaries
* [ ] Installation and upgrade documentation

### Phase 5 — Expanded CLI

* [ ] Modular command architecture
* [ ] More than 200 documented commands and subcommands
* [ ] Shell automation support
* [ ] Comprehensive tests and documentation

Roadmap items are goals, not promises that the features are already implemented.

## 🏗️ Project Structure

```text
KAR-ENGINE/
├── src/
│   └── KarEngine/
│       ├── KarEngine.csproj
│       └── Program.cs
├── scripts/
│   └── build.ps1
├── release/
├── logs/
├── packages/
├── installer/
├── .gitignore
└── README.md
```

Some directories may remain empty until their associated features are implemented.

## 🤝 Contributing

Contributions, bug reports and feature suggestions are welcome.

1. Fork the repository.
2. Create a feature branch.
3. Make your changes.
4. Test your changes.
5. Submit a pull request describing the changes.

Please report reproducible bugs and include relevant error messages.

## 🔒 Security

Do not run untrusted packages or executables.

Before package installation features are released, KAR ENGINE should validate package contents and paths, prevent path traversal, and provide clear installation and removal behavior.

Never commit passwords, API tokens, private keys or other secrets to the repository.

To report a security issue, contact the project maintainers privately before publishing exploit details.

## 📄 License

A license has not yet been selected.

Until a license is added to the repository, do not assume that the source code is available for unrestricted redistribution or reuse.

## 🏢 About

**KAR ENGINE** is developed by **Zercraft**.

GitHub: https://github.com/anormadaise2-ops

Repository: https://github.com/anormadaise2-ops/kar-engine

---

*Built for developers. Designed to grow.*
