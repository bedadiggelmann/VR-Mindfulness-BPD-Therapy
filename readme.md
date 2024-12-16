# VR-Mindfulness-BPD-Therapy

A virtual reality meditation application designed to support Dialectical Behavior Therapy (DBT) for young adults with Borderline Personality Disorder (BPD). The application provides an immersive forest environment for guided mindfulness exercises and breathing techniques.

## Overview

This VR application offers a therapeutic environment where users can practice mindfulness exercises in a calming forest setting. The experience includes:

- Immersive forest environment with natural sounds
- Guided breathing exercise
- Interactive elements for engagement

## Technical Requirements

### Hardware
- Meta Quest 3 (recommended) or Meta Quest 2

### Software
- Unity 2022.3
- Android Build Support Module
- OpenJDK
- Meta XR SDK

## Installation

1. Clone this repository
2. Open Unity Hub 2022.3
3. Add the project through Unity Hub
4. Ensure Android Build Support is installed
5. Open the project in Unity Editor
6. Navigate to `Assets/MeditationMVPAssets/Scenes/`
7. Open `MainScene.unity`

## Development Setup

1. Install Unity 2022.3 via Unity Hub
2. Enable Android Build Support during installation
3. Install the following packages via Package Manager:
   - Oculus XR Plugin (v4.1.2)
   - XR Plugin Management (v4.5.0)
   - XR Legacy Input Helpers (v2.1.10)
4. Configure project settings using Meta Project Setup Tool
5. Enable Developer Mode on your Quest device through the Meta Horizon app

## Building and Deployment

### Development Testing
1. Connect Quest headset via USB-C cable
2. Enable Developer Mode
3. Use Meta Link for direct streaming from Unity Editor

### Production Build
1. Switch platform to Android in Build Settings
2. Configure appropriate Android settings
3. Use "Build And Run" to deploy directly to the headset
4. The application will appear under "Unknown Sources" on the Quest

## Usage

1. Launch the application on the Quest headset
2. Follow the initial tutorial for navigation instructions
3. Use controllers for movement and interaction
4. Find treasure chests to initiate mindfulness exercise
5. Complete exercise