// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class FeatureLearning : ModuleRules
{
	public FeatureLearning(ReadOnlyTargetRules Target) : base(Target)
	{
		//PublicIncludePaths.Add("Runtime/Launch/Public");

		string EngineDirectory = "D:/UnrealEngine-4.26/Engine";
        PublicIncludePaths.Add(System.IO.Path.Combine(EngineDirectory, "Source/Runtime/Launch/Public"));
        // PrivateIncludePaths.Add("Runtime/Launch/Private");      
        PrivateIncludePaths.Add(System.IO.Path.Combine(EngineDirectory, "Source/Runtime/Launch/Private"));
        // ...


        PrivateDependencyModuleNames.AddRange(
			new string[] {
				"Core", "CoreUObject",
				"AppFramework",
				"RenderCore",
				"ApplicationCore",
				"Projects",
				"Slate",
				"SlateCore",
				"StandaloneRenderer",
				"SourceCodeAccess",
				"WebBrowser"
			}
		);

		PrivateIncludePathModuleNames.AddRange(
			new string[] {
				"SlateReflector",
			}
		);

		DynamicallyLoadedModuleNames.AddRange(
			new string[] {
				"SlateReflector",
			}
		);

		if (Target.Platform == UnrealTargetPlatform.Mac)
		{
			PrivateDependencyModuleNames.Add("XCodeSourceCodeAccess");
			AddEngineThirdPartyPrivateStaticDependencies(Target, "CEF3");
		}
		else if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			PrivateDependencyModuleNames.Add("VisualStudioSourceCodeAccess");
		}

		PrivateIncludePaths.Add("Runtime/Launch/Private");		// For LaunchEngineLoop.cpp include

		if (Target.Platform == UnrealTargetPlatform.IOS || Target.Platform == UnrealTargetPlatform.TVOS)
		{
			PrivateDependencyModuleNames.AddRange(
                new string [] {
                    "NetworkFile",
                    "StreamingFile"
                }
            );
		}

		if (Target.IsInPlatformGroup(UnrealPlatformGroup.Linux))
		{
			PrivateDependencyModuleNames.AddRange(
				new string[] {
					"UnixCommonStartup"
				}
			);
		}
	}
}
