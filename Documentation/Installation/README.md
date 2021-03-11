[Unity]: https://unity3d.com/
[Unity Package Manager]: https://docs.unity3d.com/Manual/upm-ui.html
[Project-Manifest]: https://docs.unity3d.com/Manual/upm-manifestPrj.html

# Installing the package

> * Level: Beginner
>
> * Reading Time: 2 minutes
>
> * Checked with: Unity 2019.3

## Introduction

When developing XR applications, most of the times we want to represent somehow the users' body parts, especially the tracked ones such as the hands. Usually the hands are represented either by the controllers or by virtual human-like hands (sometimes even both).

In this pakcage we provide an easy way to incorporate hand and controller representation in your XR application when developing using [Unity]. In the future more options will become available for adding full body user avatar.

## Get started

### Step 1: Creating a Unity project

> You may skip this step if you already have a Unity project to import the package into.

* Create a new project in the Unity software version `2019.3` (or above) using `3D Template` or open an existing project.

### Step 2: Adding the package to the Unity project manifest

* Navigate to the `Packages` directory of your project.
* Adjust the [project manifest file][Project-Manifest] `manifest.json` in a text editor.
  * Add `di.uoa.realitylab.unity.xr.avatar` to `dependencies`, stating the url of this repository `https://github.com/DI-UOA-RealityLab/Unity.XR.Avatar.git`.

  You should have the following on your manifest file.
  ```json
  {
    "dependencies": {
      "di.uoa.realitylab.unity.xr.avatar": "https://github.com/DI-UOA-RealityLab/Unity.XR.Avatar.git",
      ...
    }
  }
  ```
* Switch back to the Unity software and wait for it to finish importing the added package.

### Done

The `Unity XR Avatar` package will now be available in your Unity project `Packages` directory ready for use in your project.

The package will now also show up in the Unity Package Manager UI. From then on the package can be updated by selecting the package in the Unity Package Manager and clicking on the `Update` button or using the version selection UI.
