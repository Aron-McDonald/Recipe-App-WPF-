# Recipe Management Application

## Project Overview

The Recipe Management Application is a user-friendly Windows desktop application designed to help users manage their recipes efficiently. It provides a digital platform for storing, viewing, and modifying recipes.

Key features and functionalities:
- Create and store new recipes with ingredients and steps
- View a list of all stored recipes
- Scale recipe ingredients up or down
- Filter recipes by ingredient, food group, or maximum calories
- Reset ingredient quantities to their original values
- Calorie warning system for high-calorie recipes
- User-friendly graphical interface for easy navigation and use

## Technologies Used

- Programming Language: C# 8.0
- Framework: .NET Framework 4.7.2
- UI Framework: Windows Presentation Foundation (WPF)
- IDE: Visual Studio 2019 or later
- Version Control: Git

Key Dependencies:
- System.Windows.Controls (part of WPF)
- System.Collections.Generic
- System.Linq

## Key files and folders:
- `MainWindow.xaml/.cs`: Defines the main application window and navigation logic.
- `Models/`: Contains the data models for Recipe and Ingredient.
- `Pages/`: Contains user controls for different functionalities of the app.
- `Dialogs/`: Contains dialog windows for input of ingredients and steps.

## How to Compile and Run

1. System Requirements:
   - Windows 10 or later
   - Visual Studio 2019 or later (Community, Professional, or Enterprise edition)
   - .NET Framework 4.7.2 or later
   - At least 4GB of RAM and 10GB of free disk space

2. Installation:
   - If not already installed, download and install Visual Studio from https://visualstudio.microsoft.com/
   - During installation, ensure you select the ".NET desktop development" workload

3. Obtaining the Source Code:
   - Clone this repository to your local machine using Git:
     ```
     git clone https://github.com/yourusername/RecipeAppWPF2024.git
     ```
   - Alternatively, download the ZIP file of the repository and extract it to your preferred location

4. Opening the Project:
   - Launch Visual Studio
   - Click on "File" > "Open" > "Project/Solution"
   - Navigate to the directory where you cloned/extracted the repository
   - Select the `RecipeAppWPF(2024).sln` file and click "Open"

5. Configuring the Project:
   - Once the solution is loaded, right-click on the solution in the Solution Explorer
   - Select "Restore NuGet Packages" to ensure all dependencies are properly installed

6. Building the Solution:
   - In Visual Studio, click on "Build" > "Build Solution" or press F6
   - Ensure that the build completes successfully without any errors

7. Running the Application:
   - To run the application with debugging, click on "Debug" > "Start Debugging" or press F5
   - To run without debugging, use "Debug" > "Start Without Debugging" or press Ctrl+F5
   - The application window should appear, allowing you to interact with the recipe management system

8. Troubleshooting:
   - If you encounter any build errors, ensure all NuGet packages are properly restored
   - Verify that your Visual Studio installation includes all necessary components for .NET desktop development
   - Check that your system meets the minimum requirements for running the application

9. Deployment:
   - To create a standalone executable, right-click on the project in Solution Explorer
   - Select "Publish" and follow the wizard to create a deployment package

By following these steps, you should be able to successfully compile and run the Recipe Management Application on your local machine.

## Changes Based on Lecturer's Feedback

Based on the lecturer's feedback, I have made several improvements to enhance the code quality and readability:

1. Added comprehensive code comments throughout all files, explaining the purpose of classes, methods, and important code blocks. This improves understanding of the code's structure and functionality.

2. Restructured the code to make it more logical and easier to follow. This included reorganizing methods within classes and ensuring consistent naming conventions.

3. Improved error handling and input validation, particularly in the Recipe and Ingredient classes.

4. Enhanced the user interface by adding more informative messages and improving the layout of controls in XAML files.

5. Implemented additional features such as the calorie warning system and the ability to scale recipes, making the application more useful for end-users.

These changes have significantly improved the overall quality of the code, making it more maintainable and easier for other developers to understand and modify.
