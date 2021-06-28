#  Shape Creator Drawing Console 

This program is intended to provide a console based interface where an end user will be able to create different types of shapes with key board characters.

## Problem Statement

You're given the task of writing a simple console version of a program. 
At this time, the functionality of the program is quite limited but this might change in the future. 
In a nutshell, the program should work as follows:

1. Hello World
2. Quit

For details please check [here](drawing_program.txt).

## Build, Run and Test Instructions

* The source code has been implemented using Visual Studio 2019 with .NET Core 3.1.
* All the tests run on top of xUnit test framework. Using ReSharper xUnit adapter will provide visually better test case execution.

### Running the Program

* Run from Visual Studio: 
	* After opening the solution using Visual Studio 2019, make sure CodeBox.Console is set as start up project.
	* Press ctrl + F5 to run directly from Editor.
* Run from Command Prompt: To run the program from command prompt, we'll need to build the solution either by Visual Studio or MSBuild command. After the 
	* Build using Visual Studio: 
		* Press ctrl + shift + F5 to build the solution.
	* Build using MSBuild: 
		* Open "Developer Command Prompt for VS 2019" and navigate to the source code directory where the solution is located (i.e. using CD command).
		* Run the following command: msbuild CodeBox.sln
	* Run the program: after the build is successful, perform the following steps
		* From command prompt, navigate to the following location (relative from source code root directory): cd .\ShapeCreator.Console\bin\Debug
		* Run the following command: CodeBox.Console

### Running the Tests

* Run using Visual Studio with ReSharper (recommended)
	* Open the solution in visual studio. Make sure Resharper and related xUnit Test adapters are installed.
	* Navigate to following Visual Studio menu: ReSharper -> Unit Tests -> Run All Tests from Solution.
* Run using Visual Studio Test Explorer
	* Open the solution in visual studio. Make sure required xUnit Test adapters are installed.
	* Navigate to following Visual Studio menu: Test -> Windows -> Test Explorer
	* Click 'Run All' button from Test Explorer.

## Notes on Design, Implementation:

* Command arguments are case sensitive.
* Command line can have leading or trailing white spaces, however only one space has been considered as arguments separator. 
* The application has been designed to run not only on top of consoles, but also any other interfaces that implements IInput and IOutput interface as provided in the source.
* The command processor currently only handles CommandException. It's the caller application which is responsible to provide other system level exception mechasim. In our console application, a simpler approach is considered.

## Notes on Tests:

* Most of the test cases has taken the advantage of the application design to read/write data, where user input is simulated using test data files and visual output has been rendered in test console.
* Visual components as rendered by the application algorithms can be matched against test data files, where test cases can be designed more precisely. 
* The default test naming convension: TestMethod/Goal_StateUnderTest_ExpectedBehaviour
* As the core application components uses in memory object ( i.e. no external physical components are dependent ), mocking objects were not considered. For I/O fake or test console intefaces has been provided as required. Mocking objects are usually considered for faster test execution, where external physical dependencies are involved.

## Further Improvements:

* The core application logic (as contained in ShapeCreator.Core) contains 90% test coverages, which can be improved further. 
* The algorithm for drawing rectangle can be further refactored to be used to draw rectangle for canvas border.
* For the sake of simplicity application logging capabilities are not provided. For real world scenarios, we can add these support.
* The application can also provide command to generate help related texts, along with relevant command errors can provide additional details. 
* For testing command stream, quit logic has not been covered, as the quit command executes Environment.Exit(0), which causes tests to be shown as abroted. We can write corresoding test adapter or utilies to provide support in this.
* Having a stress test will provide additional details of the program capacities, specially maximum canvas boundaries regarding the memory limit.

=================================================================================
