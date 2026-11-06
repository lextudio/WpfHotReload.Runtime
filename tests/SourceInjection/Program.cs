using System;
using System.Reflection;

if (typeof(StartupHook).GetMethod(nameof(StartupHook.Initialize), BindingFlags.Public | BindingFlags.Static) is null)
{
    throw new InvalidOperationException("DOTNET_STARTUP_HOOKS requires public static StartupHook.Initialize().");
}
