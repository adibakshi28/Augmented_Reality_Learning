# Augmented Reality Fruit Aid

Augmented Reality Fruit Aid is an educational augmented reality app designed to help kids learn about fruits by visualizing them in a fun and interactive way. Developed using the Unity engine, this repository contains all the necessary files and resources to build, run, and modify the app.

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Dependencies](#dependencies)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)
- [Gameplay and Learning Modes](#gameplay-and-learning-modes)
- [Controls](#controls)
- [Scripts Overview](#scripts-overview)
  - [GameController.cs](#gamecontrollercs)
  - [ARController.cs](#arcontrollercs)
  - [QuizController.cs](#quizcontrollercs)
  - [UIController.cs](#uicontrollercs)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Introduction

Augmented Reality Fruit Aid is an interactive educational app that uses augmented reality to help kids learn about different fruits. The app allows users to scan fruit names and see 3D models of the fruits, making learning fun and engaging.

<div style="display: flex; justify-content: space-between;">
  <img src="Game%20Screenshot/FA1.png" alt="Game Screenshot 1" style="width: 32%;">
  <img src="Game%20Screenshot/FA2.png" alt="Game Screenshot 2" style="width: 32%;">
  <img src="Game%20Screenshot/FA3.png" alt="Game Screenshot 3" style="width: 32%;">
</div>

## Features

- **Augmented Reality Visualization:** Scan fruit names to view 3D models of the fruits.
- **Interactive Learning:** Engage with 3D fruit models and view them from all angles.
- **Quiz Mode:** Test your knowledge about fruits with a fun quiz.
- **High-Quality Graphics:** Stunning 3D graphics and animations.
- **Immersive Sound Effects:** High-quality sound effects to enhance the learning experience.
- **Cross-Platform:** Built with Unity for easy portability.

## Dependencies

To run and develop this app, you will need the following dependencies:

- **Unity 3D:** The primary development engine.
- **Vuforia SDK:** For augmented reality capabilities.
- **Android SDK:** For building and running on Android devices.

### Steps to Add Dependencies

1. **Unity 3D:** Install Unity Hub and Unity Editor (v5.4).
2. **Vuforia SDK:** Add Vuforia Engine to your Unity project via the Unity Package Manager.
3. **Android SDK:** Configure the Android SDK in Unity Editor settings.

## Installation

To set up and run the project locally, follow these steps:

### Prerequisites

- Unity Hub installed.
- Unity Editor (v5.4).
- Vuforia SDK integrated (Test Recognination enabled version).
- Android SDK configured.

### Steps

1. Clone the repository:

    ```sh
    git clone https://github.com/adibakshi28/Augmented_Reality_Fruit_Aid-Android.git
    ```

2. Open the project in Unity:
    - Open Unity Hub.
    - Click on "Add" and select the cloned project directory.
    - Open the project.

3. Configure Build Settings for Android:
    - Navigate to `File > Build Settings`.
    - Select Android and click on `Switch Platform`.
    - Adjust player settings, including package name and version.

4. Build the Project:
    - Connect your Android device or set up an emulator.
    - Click on `Build and Run` to generate the APK and install it on the device.

## Usage

After building the project, install the APK on your Android device. Launch the app and follow the on-screen instructions to start learning about fruits using augmented reality.

## Project Structure

- **Assets:** Contains all game assets, including:
    - **Scenes:** Different levels and menus.
    - **Scripts:** C# scripts for app logic.
    - **Prefabs:** Pre-configured game objects.
    - **Animations:** Animation controllers and clips.
    - **Audio:** Sound effects and music files.
    - **UI:** User interface elements.
- **QCAR:** Vuforia SDK settings and files.
- **ProjectSettings:** Project settings including input, tags, layers, and build settings.
- **.gitignore:** Specifies files and directories to be ignored by Git.
- **LICENSE:** The license under which the project is distributed.
- **README.md:** This readme file.

## Gameplay and Learning Modes

Players can use the app to learn about fruits in various interactive ways:

- **AR View:** Scan fruit names to view 3D models in augmented reality.
- **Quiz Mode:** Answer questions to test your knowledge about fruits.
- **Game Mode:** Engage in fun activities related to fruits.

<div style="display: flex; justify-content: space-between;">
  <img src="Game%20Screenshot/FA4.png" alt="Game Screenshot 4" style="width: 32%;">
  <img src="Game%20Screenshot/FA5.png" alt="Game Screenshot 5" style="width: 32%;">
  <img src="Game%20Screenshot/FA6.png" alt="Game Screenshot 6" style="width: 32%;">
</div>

## Controls

- **AR View:** Point your camera at the fruit name to see a 3D model of the fruit.
- **Quiz Mode:** Select the correct answer by tapping on the options.
- **Game Mode:** Interact with the game elements by tapping on the screen.

## Scripts Overview

The `Assets/Scripts` directory contains essential C# scripts that drive the app's functionality. Here's a detailed overview:

### GameController.cs

Manages the overall game state, including game flow, starting and ending sessions, tracking player progress, and updating the UI with scores and other information.

### ARController.cs

Handles the augmented reality features of the app using Vuforia SDK. Manages the detection and visualization of 3D fruit models.

**Key Functions:**
- `StartAR()`: Initializes the AR experience.
- `UpdateAR()`: Updates the AR content based on user interaction.
- `StopAR()`: Stops the AR experience.

### QuizController.cs

Manages the quiz functionality, including question generation, user interaction, and scoring.

**Key Functions:**
- `GenerateQuestion()`: Generates a new quiz question.
- `CheckAnswer()`: Checks if the user's answer is correct.
- `UpdateScore()`: Updates the user's score based on correct answers.

### UIController.cs

Manages the user interface, handling interactions with menus, buttons, and other UI elements.

**Key Functions:**
- `ShowMenu()`: Displays the main menu.
- `UpdateUI()`: Updates the UI elements based on the game state.
- `ShowResults()`: Displays the quiz or game results.

## Screenshots

Here are some screenshots of the app:

<div style="display: flex; justify-content: space-between;">
  <img src="Game%20Screenshot/FA7.png" alt="Game Screenshot 7" style="width: 32%;">
  <img src="Game%20Screenshot/FA8.png" alt="Game Screenshot 8" style="width: 32%;">
  <img src="Game%20Screenshot/FA1.png" alt="Game Screenshot 1" style="width: 32%;">
</div>

## Contributing

Contributions are welcome and greatly appreciated. To contribute:

1. Fork the repository:
    - Click the "Fork" button at the top right of the repository page.

2. Create a feature branch:

    ```sh
    git checkout -b feature/AmazingFeature
    ```

3. Commit your changes:

    ```sh
    git commit -m 'Add some AmazingFeature'
    ```

4. Push to the branch:

    ```sh
    git push origin feature/AmazingFeature
    ```

5. Open a pull request:
    - Navigate to your forked repository.
    - Click on the "Pull Request" button and submit your changes for review.

## License

This project is licensed under the MIT License. See the LICENSE file for more information.

## Contact

For any inquiries or support, feel free to contact:

[Adibakshi28 - GitHub Profile](https://github.com/adibakshi28)

Project Link: [Augmented Reality Fruit Aid-Android](https://github.com/adibakshi28/Augmented_Reality_Fruit_Aid-Android)
