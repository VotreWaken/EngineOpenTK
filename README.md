# OpenTK3DEngine

**OpenTK3DEngine** is a simple and versatile 3D engine built on top of OpenTK, designed to simplify 3D and 2D graphics development in C#. It provides easy-to-use functions for rendering and manipulating 3D objects and 2D graphics, making it perfect for simple game development and graphical applications.

## Features

- **Simplified 3D Rendering**: Create and manipulate 3D objects such as cubes, spheres, toruses, and cylinders with ease.
- **2D Graphics Functions**: Draw 2D shapes, lines, ellipses, text, and textured quads and rectangles.
- **Texture and Font Support**: Load and apply textures to objects and draw text with built-in font support.
- **Configurable Rendering**: Easily control depth testing, alpha blending, and input handling.

## Table of Contents

- [Overview](#overview)
- [Basic Setup Instructions](#basic-setup-instructions)
- [Example Code](#example-code)
- [Current Available Functions](#current-available-functions)
  - [On OnLoad](#on-onload)
  - [On OnRenderFrame](#on-onrenderframe)
- [3D Functions](#3d-functions)
- [2D Functions](#2d-functions)
- [Fonts Class](#fonts-class)
- [Settings Class](#settings-class)

## Overview

This library wraps the OpenTK library with easy-to-use functions tailored for C# and VB, simplifying 3D and 2D graphics development.

## Basic Setup Instructions

1. Add the library to your solution from NuGet.
2. Add a new `.cs` file to your console app as your main code file.
3. Include the example code provided in your `Program.cs` file.
4. If you prefer a Windows application instead of a console app, adjust your project properties accordingly.

## Example Code

Here's a basic example to get you started:

```csharp
using System;
using OpenTK;
using OpenTK.Graphics;
using Program;

namespace YourNamespace
{
    public class YourClass : MainRenderWindow
    {
        public YourClass(int width, int height, string title, double fps) : base(width, height, title, fps)
        {
        }

        protected override void OnLoad()
        {
            setClearColor(new Color4(0.0f, 0.0f, 0.0f, 1.0f)); // Sets Background Color
            UseDepthTest = false; // Enables Depth Testing for 3D
            UseAlpha = true; // Enables alpha use
            KeyboardAndMouseInput = false; // Disables default keyboard and mouse input
            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            Clear();
            DrawEllipse(500, 500, 10f, 10f, new Color4(1.0f, 1.0f, 1.0f, 1.0f)); // Draws a circle
            base.OnRenderFrame(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
    }
}

namespace YourNamespace
{
    static class Program
    {
        static void Main(string[] args)
        {
            using YourClass game = new YourClass(1000, 1000, "Test App", 60.0);
            game.Run();
        }
    }
}

```

## Current Available Functions

### On OnLoad

**Before Base.OnLoad:**

- `Boolean UseDepthTest (*Default = false*)`: Specifies if the rendering engine will use depth test.
- `Boolean UseAlpha (*Default = true*)`: Specifies if the rendering engine will use alpha blending.
- `Boolean KeyboardAndMouseInput (*Default = true*)`: Specifies if the rendering engine will handle default keyboard and mouse input.
- `Boolean showSet (*Default = false*)`: Specifies if the rendering engine opens settings on escape.

**After Base.OnLoad:**

- `CreateMainLight(Vector3 pos, Color4 color)`: Creates your main light.
- `CreateCube(Color4 color)`: Creates a 3D cube with the specified color.
- `CreateSphere(Color4 color)`: Creates a 3D sphere with the specified color.
- `CreateTorus(Color4 color)`: Creates a 3D torus with the specified color.
- `CreateCylinder(Color4 color)`: Creates a 3D cylinder with the specified color.
- `CreatePlane(...)`: Creates a 3D plane with the specified parameters.
- `OpenTexturedObj(string obj, string texture)`: Opens an .obj file with an attached .png texture.
- `OpenObj(string obj, Color4 color)`: Opens an .obj file with the specified color.

### On OnRenderFrame

**3D Functions:**

- `Render3DObjects()`: Renders the 3D objects to the screen.
- `RotateObject(float x, float y, float z, int handle)`: Rotates the object by the specified amounts in each direction.
- `ScaleObject(float scale, int handle)`: Scales the object by the specified amount.
- `TranslateObject(float x, float y, float z, int handle)`: Translates the object by the specified vector.

**2D Functions:**

- `DrawRectangle(float x1, float y1, float x2, float y2, Color4 color)`: Draws a rectangle.
- `DrawLine(float x1, float y1, float x2, float y2, Color4 color)`: Draws a line.
- `DrawEllipse(float x, float y, float radiusX, float radiusY, Color4 color)`: Draws an ellipse.
- `DrawTexturedLine(...)`: Draws a textured line.
- `DrawQuad(...)`: Draws a textured quad.
- `DrawTriangle(float x1, float y1, float x2, float y2, float x3, float y3, Color4 color)`: Draws a triangle.
- `DrawText(string text, float x, float y, Font f, Color4 col, int TextAlign)`: Draws text with the specified font, color, and alignment.

**drawTexturedRectangle() Overloads:**

- `DrawTexturedRectangle(...)`: Draws a textured rectangle with various parameters.

**drawTexturedQuad() Overloads:**

- `DrawTexturedQuad(...)`: Draws a textured quad with various parameters.

### Fonts Class

- Provides functionality for handling fonts.

### Settings Class

- Allows configuration of engine settings.

## Todo

- Implement `drawPolygon` function (p5.js Triangle Strip style).
- Add internal font support using Microsoft Font class to create bitmap and font data.
- Enhance support for 3D objects (cylinders, toruses) to function without .obj files.
