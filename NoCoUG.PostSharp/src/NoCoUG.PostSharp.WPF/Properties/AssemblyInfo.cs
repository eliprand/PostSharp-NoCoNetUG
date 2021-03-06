﻿using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows;
using NoCoUG.PostSharp.WPF;
using PostSharp.Patterns.Model;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NoCoUG.PostSharp.WPF")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NoCoUG.PostSharp.WPF")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

//In order to begin building localizable applications, set 
//<UICulture>CultureYouAreCodingWith</UICulture> in your .csproj file
//inside a <PropertyGroup>.  For example, if you are using US english
//in your source files, set the <UICulture> to en-US.  Then uncomment
//the NeutralResourceLanguage attribute below.  Update the "en-US" in
//the line below to match the UICulture setting in the project file.

//[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.Satellite)]


[assembly: ThemeInfo(
    ResourceDictionaryLocation.None, //where theme specific resource dictionaries are located
    //(used if a resource is not found in the page, 
    // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly //where the generic resource dictionary is located
    //(used if a resource is not found in the page, 
    // app, or any theme specific resource dictionaries)
)]


// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// following 2 lines should assign NotifyPropertyChanged to all ViewModels (first line), except MainViewModel2 (2nd line)
//[assembly: NotifyPropertyChanged(AttributeTargetTypes = "NoCoUG.PostSharp.WPF.ViewModels.*", AttributePriority = 1)]
//[assembly: NotifyPropertyChanged(AttributeTargetTypes = "NoCoUG.PostSharp.WPF.ViewModels.MainViewModel2", AttributePriority = 2, AttributeExclude = true)]

[assembly: NotifyPropertyChanged(AttributeTargetTypes = "NoCoUG.PostSharp.WPF.ViewModels.*")]
[assembly: Retry(AttributeTargetTypes = "NoCoUG.PostSharp.WPF.MainWindow", AttributeTargetMembers = "CalculateAge", MaxRetries = 3)]
