# LightPOS (.NET Framework 4.0)
A simple Point-Of-Sale app made in C# with WinForms.

Using ModernUIDoneRight by NickAc.

**Please don't use this in a real environment! The laws in your country may not allow it!**

## Compiling
After you've downloaded/cloned this repo, open the solution on Visual Studio (preferably VS 2017).

Then get LibZ (used to compress dependencies) in [this](https://github.com/MiloszKrajewski/LibZ/releases) link (get the one that contains tool on the file name).

After doing that, let NuGet download the dependencies. When completed, place the libz.exe file on the Release folder(bin\Release).

Change the configuration to Release and ask Visual Studio to compile.

The final files you should copy:
- LightPOS.exe
- LightPOS.exe.config
- dependencies.libz
- x86 ($project-root$\packages\System.Data.SQLite.Core.$version$\build\net40)
- x64 ($project-root$\packages\System.Data.SQLite.Core.$version$\build\net40)
