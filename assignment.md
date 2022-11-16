# Games Engines 1 Assignment 2022-2023 - The Six Million Dollar Man's Lava Lamp

Your task is to create a hologram of an appliance or artwork from a futuristic home of the future as imagined from 1970's sci-fi. Some examples:

- The six million dollar mans lava lamp
- A self playing guitar or piano
- A volcano
- A fire place with futuristic effects
- A harry potter style book or picture that comes to life
- An alien in a jar
- AN R2D2 type robot
- An abstract audio responsive artwork
- An octopus in a tank
- A futuristic machine with lots of lights and moving parts

You can use [ProBuilder](https://unity.com/features/probuilder) or Blender to make your models, or like me, create everything from primitives. We will deploy the holograms to the Quest. You can use any of built in stuff in Unity, such as particle effects, shaders, sound, the animation system and C# scripts. Your hologram should move or have some sort of behaviour or interaction. You can use source code and assets from other projects, but you must reference these in your documentation (see here for a template).
 
Some ideas:

- This thing for holding the Medusan Ambassador:

[![YouTube](http://img.youtube.com/vi/Ljhqz6pF_Uo/0.jpg)](https://www.youtube.com/watch?v=Ljhqz6pF_Uo)

- This cool thing from Joe 90:

[![YouTube](http://img.youtube.com/vi/oaINLn4OKGE/0.jpg)](https://www.youtube.com/watch?v=oaINLn4OKGE)

- The teleporter from the movie "the Fly"

[![YouTube](http://img.youtube.com/vi/sTq2Im2YUOk/0.jpg)](https://www.youtube.com/watch?v=sTq2Im2YUOk)

Please include a detailed readme.md in your git repo. Here is [a template](assignmentreadme.md)

# Due dates:
- Week 5 - Proposal & git repo
- Week 11 - Final submission & in-class demos

 You should use good OO practices aligned with the GameObject/MonoBehavior model that Unity uses. In other words, use inheritance, polymorphism, abstract classes and interfaces to implement game components. 
 
 # Marking Scheme

 - Complexity - 30%
 - Groovyness - 30%
 - Project Management - 30%
 - Lecturers discression - 10%
 
 | Category | 1 | 2.1 | 2.2 | Pass | Fail | %|
 |----------|---|---|---|---|---|---|
 | Complexity | 15-20 hours work. A complex system that has lots of interactivity. 5 or 6 MonoBehaviors that interact and work together to implement the system. A complex algorithm such as a generative system. Several hundred lines of self written C# code. Nice gizmos on all the MonoBehaviors and ranges on public fields, where appropriate. Code will be separated into appropriate methods and classes, following SOLID principles. Code demonstrates techniques we have learned on the course including: coroutines, transforms, vectors, quaternions, physics, lerping and slerping, sound. Advanced use (such as scripting) of Unity systems including animation, shaders, particle systems. Deployed and demoed on the quest or in AR on a phone. | 10-15 hours work. A less complex system that has some simple interactivity. 2 or 3 new MonoBehaviors required to implement the system. No gizmos. Long methods. Around 100 lines of C#. Using some of the techniques we learned on the course such as manipulating the transform. Working on PC, not VR. | 5-10 hours work. A simple system with a script or two based on modifying the transform or. Something very basic implemented like a spiral or a simple voxel world. Most of the functionality is derived from tutorials. Little interactivity. Works in Unity editor, but not tested as a build or on device. No use of other Unity systems. There might be random colours no audio or inappropriate audio. | < 5 hours work. A single C# script. Compiles and runs | Doesnt compile or run. No commits | Around 10 commits   | 30% |
 | Groovyness | Project is deployed to the Quest and has great framerate. It looks amazing with a high level of polish on the visuals. Good use of color and form. The object is fully usable in VR and AR. Lots of interactivity and novelty. Use of visual effects such as particle system, post-processing or custom shaders. Has a clear visual style. Models made in Blender. Has great sound effects. Is very cool indeed. Super cool in fact. Special gold star just like Joe 90. | Maybe deployed to the Quest but has some glitches or runs just on PC not in AR. Looks pretty good with decent but simple self made models made in ProBuilder or Blender. No visual effects. Maybe a particle system. Sound effects grabbed from online sources. Some simple interactivity and button presses. Less coherent visual style. Good novelty value.  | One or two simple models made in Probuilder or imported from online sources. No interactivity, just an animated visual. Running in the Unity editor. Little or no sound | Model from online source or primitive that doesnt do anything | Doesnt compile or no submission, nothing works. | 
 | 30% |
 | Project management | Detailed initial proposal and plan. 30-40 commits. Feature branches. For team projects, an equal distribution of the commits. Commits all commented. All sections of the template filled out. Reflective - What did I learn? Sources properly referenced. Embedded, public, listed youtube video (DO NOT CHECK THIS VIDEO IS MADE FOR KIDS). The video is made from a build, not from the Unity Editor and demonstrates all the features of your project | 20-30 commits. One or two branches. All sections of the template filled out. Sources properly referenced. Issues with the video. |  30% | 10-20 commits, terse comments. No branches. Documentation incomplete, Evidence of reflective learning missing. missing references. Issues with the video | < 10 commits. , terse comments. No branches. Documentation incomplete. No video
 | Discretionary mark       | 10% | |
 
 # Rubric
 
 | Grade | Profile |
 |-------|---------|
 | First | . You have made cool assets in Probuilder or elsewhere and they fit the theme of your assignment very well with appropriate shape and color.  The sound is appropriate. There is a high degree of novelty or nostalgia. There is lots of functionality and interactivity - for example buttons to press, levers to turn, colors changing, movement, animation etc. The project will be managed through a git repo. There will be 40+ git check-ins and feature branches. The readme.md will be detailed and comprehensive and will include all the required elements including an embedded youtube demo made from a build of the project. The six million dollar man loves your hologram. |
 | 2.1   | You will have spend 10-16 hours on the assignment with around 30-70 check-ins. For example, long methods here and there without enough granularity. | 
 | 2.2   | You will spend around a day on the assignment and will have implemented a simple system based on sine waves or similar. You might have around 30 check-ins or less. Your solutions is one or two game components in complexity. There might be random colours no audio or inappropriate audio. Your system might glitch a bit and would need a fair bit of future work to make it publishable or useful|
 | Pass  | You will spend less than a day on the assignment and get something very basic implemented like a spiral or a simple voxel world. No git use or evidence of many check-ins|
 | Fail  | Nothing works, and no git. Looks like it took a few hours to make | 
 