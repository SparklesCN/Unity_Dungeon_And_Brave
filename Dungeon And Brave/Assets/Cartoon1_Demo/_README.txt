
                '      .'
           |   '|    .'
          . \_/  \_.',
    ..,_.' _____    (
     `.   |  __ \   '..o    o    o    o    o    o    o    o    o    o    o    o   o
       :  | |__) | ,' ___    _ __     ___    ___    _ __   _ __     _____  __   __
   ._-'   |  ___/ /  / _ \  | '_ \   / __/  / _ \  | '__| | '_ \   |  ___| \ \ / /
     `.   | |     ( | (_) | | |_) | | (_   | (_) | | |    | | | |  | |_     \ V /
     ,'   |_|    _`. \___/  | .__/   \___\  \___/  |_|    |_| |_|  |  _|     ) (
    ,.'"\  _.._ (  `'       |_|                                    | |      / ' \
   :'   | /    `' o    o    o    o    o    o    o    o    o    o   |_|     /_/ \_\
 ,"     ',
'       '
                                                      Realtime Particle FX Solution


    PopcornFX
        http://www.popcornfx.com
        http://www.facebook.com/3D.PopcornFX
        http://www.twitter.com/popcornfx

================================================================================

PopcornFX is a 3D realtime VFX middleware for PC Windows/Linux/MacOSX, PS4, XBox
One, PS3, XBox 360, PS Vita, Wii-U, Android and iOS.
 - High performance and flexibility with powerful scripting system.
 - Designed for the video game industry.
 - Easy to integrate, efficient authoring, ready to run.
 - Highly optimized for each target platform.

PopcornFX's Unity Plugin is an integration of the PopcornFX runtime libraries
into Unity's rendering pipeline using Unity's native plugin interface. Due to the
public API limitations, some specific features are not implemented in Unity yet.
Free discovery packs will be regularly updated to highlight the supported
features.

The plugin requires Unity Pro.

Online Documentation : http://wiki.popcornfx.com/index.php/Unity

Contact us at contact@popcornfx.com
For bug reports/support, use support@popcornfx.com

================================================================================

HOW TO IMPORT THIS PACKAGE IN UNITY?

This package contains several effects along with scenes to showcase their use in
Unity and a packaged version for use in the PopcornFX Editor.

You will need the PopcornFX Plugin for this package to work in Unity!
The included assemblies are dummies.

To properly import the package, proceed as follows:

   0. Since the plugin is composed of dynamic libraries loaded at runtime, make
   sure you either start with a fresh empty project or at least restart Unity
   before importing anything. Also, don't try to play the demo scenes between
   points 1. and 2.

   1. Import the FX Pack package (the package containing this README file).

   2. Import the PopcornFX Desktop Plugin for Unity, you may discard the
   following directories:
        - Editor/
        - StreamingAssets/
        - Standard Assets/
        - PopcornFX_Samples/
   All other files are mandatory.
   This will overwrite the dummy assemblies provided with the pack with
   functionnal ones.

   3. In your player settings make sure to set the color space to linear.

   4. Load a demo scene, hit play, enjoy the demo.

================================================================================

HOW TO FIX DllNotFoundException/EntryPointNotFoundException

Make sure the native library for your system (and architecture) is actually
present in the Assets/Plugins directory (see our online doc for the paths).

If it is but the problem persists, verify you have the Microsoft Visual C++ 2010
Redistributable Package suitable for your version of the Unity editor.
=> 32 bits : http://www.microsoft.com/en-us/download/details.aspx?id=5555
=> 64 bits : http://www.microsoft.com/en-us/download/details.aspx?id=14632

You may also have a missing dependency on the DirectX runtime, please install the
runtime: http://www.microsoft.com/en-us/download/details.aspx?id=8109

If you followed all the steps above but the problem persists, you may be tricked
by Unity's cache system...
/!\ if you already created a project and tried to build without following the
right steps first, you may have to start a new project from scratch to get your
build properly working.

================================================================================

HOW TO IMPORT THIS PACKAGE IN THE PopcornFX EDITOR?

There is a pkkg file in the StreamingAssets directory which contains the editor-
usable pack. To use it, proceed as follows:

	1. In the PopcornFX editor, on the project screen on startup, create a
	new project at your Unity project's root folder.

	2. Select the project and click Settings. Under "General", set the Axis
	System to LeftHand_Y_Up. Under Baking, add a new baking platform (protip:
	name it "Unity"), set the path to "../Assets/StreamingAssets/PackFx".

	3. Open your newly created project. In the main window right click and
	select import package. In the pop up explorer, select the pkkg file
	located in StreamingAssets.

	4. You need to manually rebuild the testArea backdrop mesh. To do so,
	locate the file under "Meshes", double click and then click "Ok" when
	asked if you want to rebuild it.

	5. To apply your modifications/additions to the package imported in
	Unity, select the appropriate effect(s) and right click -> Bake. Make
	sure you tick "Unity" and "Bake dependencies".

	6. To make sure the newly baked are correctly imported in Unity, reopen
	the project.
