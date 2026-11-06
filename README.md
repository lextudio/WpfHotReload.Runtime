# WPF Hot Reload Runtime

`WpfHotReload.Runtime` is the startup-hook agent used by OpenDevelop to apply XAML changes to a
running WPF application. It communicates with the IDE over a named pipe and supports both modern
.NET startup hooks and the .NET Framework AppDomain manager entry point.

The repository intentionally contains only the runtime agent. IDE integration, designer hosts and
test fixtures live in their respective consumers.

The source package requires a C# 10 compiler and injects that language-version requirement through
its `buildTransitive` import.

## Build

```sh
dotnet build WpfHotReload.Runtime.csproj
```

## License

MIT. See [LICENSE](LICENSE).
