# Building Reactive User Interfaces
### (SkillsMatter Progressive .NET Tutorials 2014)

# Introduction

This is the repository for the excercises for the "Building Reactive User Interfaces" session at the 2014 Progressive .NET Tutorials hosted at SkillsMatter. We are using a ReactiveUI 5.5.1 from NuGet, which is the current stable released version. Reactive UI 6 will hit soon, at which point I'll go through and update this repository accordingly.

# Set Up

There are few steps which are optional but may considerably improve your experience when developing using WPF and ReactiveUI in Visual Studio.

- Install the snippets from the `snippets` directory. This significantly reduces the amount of boilerplate code you have to write. You could also use ReSharper snippets instead of native Visual Studio ones, which may work even better.
	1. Select *Tools -> Code Snippets Manager* from the main menu
	1. Ensure "Visual C#" is selected from the *Language* combo box
	1. Click the Add button and navigate to the `snippets` directory in this repository
	1. Click *OK* to close the dialog

- Ensure Visual Studio is set up to use the Source Code Editor for XAML files. This has been observed on a number of machines to signficantly reduce the number of crashes during editing, especially if ReSharper is installed. To change this:
	1. Right-click a XAML file in the solution explorer and select *Open With*
	1. Select *Source Code (Text) Editor* from the list, and click *Set as Default*
	1. Click *OK* to close the dialog

# Adding the Reactive UI packages to a project

### Using the package manager console

1. Open the package manager console window
1. Issue the following command:<br />
	`Install-Package reactiveui`

# Exercise 1 - `ReactiveObject` basics

This exercise will take you through completing the implementation of a basic ViewModel deriving from `ReactiveObject`. It will have two properties `FirstName` and `LastName`, and update a read-only property named `FullName` when either of these change.

1. Open the solution `ex1-readonlyproperties.sln` in Visual Studio. Note that the solution does not build at this stage, as there are several definitions missing.
1. Read through the tests in `PersonViewModelTests.cs`.
1. Write code in `PersonViewModel.cs` to add a read-write property `LastName`.<br />*Hint: the `rasprop` snippet may be useful here!*
1. Write code in `PersonViewModel.cs` to add a read-only property `FullName`.<br />*Hint: the `roprop` snippet may be useful here!* 
1. Build the project and run the tests. Notice that the tests currently fail.
1. Add code to the constructor of `PersonViewModel` to set up the `FullName` property to make the tests pass.

# Exercise 2 - `ReactiveCommand` and `CanExecute`

This excercise will take you through adding an `IReactiveCommand` to the ViewModel from exercise 1, and ensuring that the command can only be executed if both `FirstName` and `LastName`. 