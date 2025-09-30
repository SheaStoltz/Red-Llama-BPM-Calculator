# BPM Calculator

This is a simple yet effective desktop application built for a creative coding class. It allows users to calculate the Beats Per Minute (BPM) of a piece of music or any rhythm by simply tapping a button in time. The application is built using C# and WPF for the .NET framework.


---

## Features

* **Tap Tempo Calculation**: Tap a button to calculate BPM in real-time.
* **Averaging for Accuracy**: The BPM is calculated from the average of the last four taps to provide a more stable and accurate reading.
* **Audio Feedback**: Each tap plays a sound (`wilhelm.wav`) for audible confirmation.
* **Mute/Unmute**: A dedicated button allows you to toggle the audio feedback on and off.
* **Reset**: A button is available to clear the current calculation and start over at any time.

---

## How to Use

1.  Launch the application.
2.  Click the **"tAp"** button in time with a rhythm.
3.  After two or more taps, the calculated BPM will appear on the right side of the window.
4.  To start a new calculation, click the **"Reset"** button.
5.  To turn the tap sound off or on, click the **"Mute"** button.

---

## Technical Breakdown

This project was built using Visual Studio Community with the following technologies:

* **Framework**: .NET 8 for Windows.
* **Technology**: Windows Presentation Foundation (WPF) is used for the graphical user interface.
* **Language**: All application logic is written in C#.
* **Calculation Logic**: The application captures the `DateTime` of each tap. It then calculates the time difference in milliseconds between consecutive taps. A rolling average of the last four intervals is maintained to smooth out the result, which is then converted into BPM using the formula `BPM = 60000 / averageInterval`.
* **Assets**: The project includes an embedded audio file (`wilhelm.wav`) for sound feedback and a resource image (`Red Llama with Red Pajams.png`) for the UI.

---

## Building from Source

To build and run this project yourself, you will need:

* .NET 8 SDK
* Visual Studio 2022 or later

Then, follow these steps:
1.  Clone this repository to your local machine.
2.  Open the solution file (`.sln`) in Visual Studio.
3.  Press `F5` or click the "Start" button to build and run the application.

---

## Project File Structure

* `MainWindow.xaml`: Defines the UI layout, controls, and visual styling for the main window.
* `MainWindow.xaml.cs`: Contains the C# code-behind that handles user interactions and performs the BPM calculation.
* `BPM Calculator.csproj`: The MSBuild project file that defines project properties, dependencies, and how assets are included.

