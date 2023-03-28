#!/bin/sh

clang sample.c -o sample libSampleLib.a \
    ~/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/7.0.0-rc.2.22472.3/sdk/libbootstrapperdll.a \
    ~/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/7.0.0-rc.2.22472.3/sdk/libRuntime.WorkstationGC.a \
    ~/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/7.0.0-rc.2.22472.3/framework/libSystem.Native.a \
    ~/.nuget/packages/runtime.linux-x64.microsoft.dotnet.ilcompiler/7.0.0-rc.2.22472.3/framework/libSystem.Globalization.Native.a \
    -Wall -pthread -lstdc++ -ldl -lm -Wl,--require-defined,NativeAOT_StaticInitialization
