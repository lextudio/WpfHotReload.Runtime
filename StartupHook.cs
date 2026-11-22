using WpfHotReload.Runtime;

// DOTNET_STARTUP_HOOKS entry point.
// The .NET runtime calls Initialize() before the app's Main() runs.
// We start a background thread that waits for the WPF Application to exist,
// then launches the named-pipe listener for hot reload.
public static class StartupHook
{
    public static void Initialize()
    {
        try
        {
            // DOTNET_STARTUP_HOOKS is inherited by child processes (dotnet watch, build hosts), and
            // they would race the app for the same pipe. Only a process that can resolve WPF is the
            // target application; loading the assembly does not touch any WPF object.
            if (!CanResolveWpf())
            {
                return;
            }

            // Avoid touching WPF objects from startup-hook threads.
            // The agent itself is resilient when Application.Current is not ready yet.
            WpfHotReloadAgent.EnsurePipeListenerStarted();
        }
        catch
        {
            // Never crash the host app because of hot reload plumbing.
        }
    }

    private static bool CanResolveWpf()
    {
        try
        {
            System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("PresentationFramework"));
            return true;
        }
        catch
        {
            return false;
        }
    }
}
