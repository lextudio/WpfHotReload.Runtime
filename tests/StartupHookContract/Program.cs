using System;
using System.Reflection;

var initialize = typeof(StartupHook).GetMethod(nameof(StartupHook.Initialize), BindingFlags.Public | BindingFlags.Static);
if (initialize is null || initialize.GetParameters().Length != 0)
{
    throw new InvalidOperationException("DOTNET_STARTUP_HOOKS requires public static StartupHook.Initialize().");
}
