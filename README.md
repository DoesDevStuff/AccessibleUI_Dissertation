# Designing an accessible UI / UX framework to enhance player experiences within games
Dissertation project for my Computer Games Technology Masters

# Summary
The purpose of this project is to create a working framework for the purpose of demonstrating a design for accessibility within games. This framework will further work as a template for developers wanting to incorporate accessibility designs within their own games, while using industry standard tools and methods. The main focal points for the project will be based on visual elements with the main design aimed towards vision impairment and colour blindness. 
<br>
The idea would be to enable players regardless of disability to enjoy a game without hampering their individual player experiences.
<br>
In recent years accessibility has become an important topic within the games industry. However, it hasn’t been applied in practice as much. This project attempts to showcase its importance for improving player experiences and why it is important for developers to incorporate it within their game designs along with a working template for them to use / learn from.
<br>


# The Game
This is a prototyped version similar to Binding of Isaac which heavily influenced the visual style and player movement.
At present it contains procedurally generated rooms, enemies and items contained in those rooms.

⚠Notice: The game is a technical verification prototype still under development, and is currently intended for author's master thesis only.

For the sake of the user test, player death is disabled to allow players to continue to fully test out the colour customisation features which forms the base of this dissertation.

# User Controls
1. WASD Keys - to move around screen
2. Arrow Keys - to shoot projectiles at enemy characters
3. Esc - Pulls up menu screen

## Files and Links
Download the latest release for playtesting:
1. WINDOWS
[Version-UserTest_WINDOWS.zip](https://github.com/CharlieTheIndieDev/AccessibleUI_Dissertation/files/9409744/Version-UserTest_WINDOWS.zip)
<br>

2. MAC
[MacBuild_2.zip](https://github.com/CharlieTheIndieDev/AccessibleUI_Dissertation/files/9438703/MacBuild_2.zip)


3. LINUX (compressed with 7zip)
[UserTest Linux_2.zip](https://github.com/CharlieTheIndieDev/AccessibleUI_Dissertation/files/9409826/UserTest.Linux_2.zip)
<br>

## For user test participants:
For the user test the following tasks are to be completed by the tester :
*sample test run through is attached in section below*
1. Load up game and go through in default colour mode
2. Open setting menu -> Select through either custom colour choice or preset option (This cycles through various colourblind colour modes)
3. In Preset Mode ideally have a run through of each setting in a different room or same room
4. Colour customisation mode - This will allow you to choose your own colour choice options for each available setting
5. To simulate colourblind filters (In windows) follow steps below and note how the colour appears differently to you
6. Lastly fill out the feedback form attached below.

### Questionnaire link: 
https://forms.office.com/r/FQyEFAf9CD
*This is an anonymous questionnaire. Your personal data, including email address, will not be collected.*

### Sample run through
<b> 1. Colour preset option <b>

https://user-images.githubusercontent.com/74312830/186148567-7d8cec54-7815-4e5c-b195-16f89b30a044.mp4


<b> 2. Custom Colour Mode <b>

https://user-images.githubusercontent.com/74312830/186149693-c82bb222-a8f9-45d7-9b1e-895db5a061d8.mp4


<b> 3. Simulate the colourblind accessibilty filter (windows) <b>

Start Screen Default |  Filter on - deuteranopia |  Filter on - protanopia |  Filter on - tritanopia |
:-------------------:|:-------------------------:|:-----------------------:|:-----------------------:|
![image](https://user-images.githubusercontent.com/74312830/186152775-55f5f089-9034-445d-9ede-d2578990f8c2.png) |  ![image](https://user-images.githubusercontent.com/74312830/186152891-c77bfc2d-8e49-4fca-94cf-2c21e07acdef.png) | ![image](https://user-images.githubusercontent.com/74312830/186152968-2b292d15-7b0a-4c0b-9be5-8d9c4be03e6c.png)  |  ![image](https://user-images.githubusercontent.com/74312830/186153099-aa9c70f2-cc8f-4d7b-9694-ef41476f1431.png)
  
## Platform and technologies

Hardware requirements for optimal performance: 

- PC, Windows, Mac, Linux
- Keyboard

#### For Simulating ColourBlindness

1. Windows Accessibility filter
  - To run Cntrl + U -> Color Filters
  - Turn on color filter
    <br> ![image](https://user-images.githubusercontent.com/74312830/186113382-86c5aa6c-9d05-4124-8be0-8205c42d0641.png)
  - Select the desired simulation mode 
    <br> ![image](https://user-images.githubusercontent.com/74312830/186113545-1595714b-c156-4a4c-8cc1-11d5dfbb0619.png)
<br>
2. For Mac OS Filter
  - Follow this guideline https://support.apple.com/en-in/guide/mac-help/mchlba06b669/mac 
<br>
3. Colour Oracle - https://colororacle.org/  [Alternative Non - Persistent] [ For Windows, Mac OS and Linux ]
<br> ⚠Note: Colour Oracle requires Java 6 or higher ; Ideal if you have dual screens
For Windows - https://www.java.com/en/download/

Instructions for running Colour Oracle
- Ensure you have Java installed
- Once Java is installed simply run the Colour Orale executable
- It will be pinned to taskbar (in the bottom right / in tray)
- right-click and select your colourblind setting option

