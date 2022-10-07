# TU856/TU857/TU858/TU984 Games Engines 1 2022-2023 

[![Video](http://img.youtube.com/vi/NMDupdv85FE/0.jpg)](http://www.youtube.com/watch?NMDupdv85FE)

## Resources
- [World Videophone](https://teams.microsoft.com/l/meetup-join/19%3ameeting_OWNkOTU5MWMtZGRkYi00ZDIxLWI3NzAtZjFjMjc3Y2NiMmVl%40thread.v2/0?context=%7b%22Tid%22%3a%22766317cb-e948-4e5f-8cec-dabc8e2fd5da%22%2c%22Oid%22%3a%2261aab78b-a857-4647-9668-83d4cca5de03%22%7d)
- [Course Notes (out of date!)](https://drive.google.com/open?id=1CeMUWjCUa1Ere2fMmtLz5TCL4O136mxj)
- [Assignment](assignment.md)
- [Unity Quick Reference](unityref.md)
- [Markdown Tutorial](assignmentreadme.md)
- [git Tutorial](gitlab.md)

## Contact me
* Email: bryan.duggan@tudublin.ie
* [My website & other ways to contact me](http://bryanduggan.org)

## Week 3 - VR Development & building a wall
- [The project we worked on in the class](https://github.com/skooter500/FormsHolograms)
- [XR Setup in Unity](https://docs.unity3d.com/Packages/com.unity.xr.interaction.toolkit@2.0/manual/general-setup.html)

## Lab
Update your fork from master branch
Create a branch called mylab3 for your work this week:

Make this procedural animation using a harmonic function :-) (click the image for video):

[![YouTube](http://img.youtube.com/vi/S8tj3v6dUbU/0.jpg)](http://www.youtube.com/watch?v=S8tj3v6dUbU)

In your solution, you will use the following API's:

```C#
Mathf.Sin
Quaternion.AngleAxis
transform.localRotation
```

- [Trigonometry Problem Set](https://1.cdn.edl.io/IDqRlI8C9dRkoqehbbdHBrcGT6m87gkCQuMKTkp0U7JvHvuG.pdf)

## Week 2 - The Unity API's
- [Recording of the class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/Ed9PpKXFtYBKtFPVdMO1E_YBnp9ur502dPKZ-LivWP2aqQ?e=GfH56n)
- [Last years class - (probably a bit better!)](https://tudublin-my.sharepoint.com/personal/bryan_duggan_tudublin_ie/_layouts/15/stream.aspx?id=%2Fpersonal%2Fbryan%5Fduggan%5Ftudublin%5Fie%2FDocuments%2FRecordings%2FGame%20Engines%201%2D20211001%5F135742%2DMeeting%20Recording%2Emp4&ga=1)

### Lab 

## Learning Outcomes
- Make a procedural system in Unity
- Use trigonometry and vectors
- Use the Unity Editor & VS Code
- Make commits on your repo
- Use the Unity API's

For assessment purposes:
- Create a branch off master called lab2
- Attempt the lab exercise below
- Make at least two commits on the branch before Thursday 6th October


Here is a video of what you can make today (click the image for the video):

[![YouTube](http://img.youtube.com/vi/tL6ux8isdgY/0.jpg)](https://www.youtube.com/watch?v=tL6ux8isdgY)


You can open the scene Lab1 and put your solution here. 
- Create a dodecahedron prefab (from the model in the project) and set the material
- Attach the RotateMe script and add code to it
- Add code to the Generator script to instantiate the dodecahedrons from the prefab you made

I suggest you try and make a single circle of dodecahedrons first and then use a nested loop to make all the circles. You will be using the following Unity API calls in your solution:

```C#
Mathf.Sin(angle)
Mathf.Cos(angle)
GameObject.Instantiate()
transform.Rotate()
```

You will also need to know about the [Unit circle](https://www.khanacademy.org/math/algebra2/x2ec2f6f830c9fb89:trig/x2ec2f6f830c9fb89:unit-circle/v/unit-circle-definition-of-trig-functions-1) and also how to [calculate the circumference of a circle](https://www.wikihow.com/Calculate-the-Circumference-of-a-Circle)

```bash
git add .
git commit -m "message"
git push
```

## Week 1 - Introduction

## Lecture

- [Introduction Slides](https://tudublin-my.sharepoint.com/:p:/g/personal/bryan_duggan_tudublin_ie/EdrNh-GMMW1Esv3VTsNExNsBY_sSMZKGPorMZMwoXr5PMg?e=kRiy2u)
- [Recording of the class](https://tudublin-my.sharepoint.com/:v:/g/personal/bryan_duggan_tudublin_ie/Efgca4KOjHFImpviNv39nBQBQl7s0fk-RUbCUKozO12_rQ?e=UlSvJX)

### Learning Outcomes
- Install Unity & git for Windows
- Get Unity running on the lab computers
- Set up the fork, clone it, merge the upstream, commit and push into your fork
- Create a little thing in Unity 

### Instructions
- Install Unity on your laptop or get Unity going on the lab computers. 
    - You will also need to go to Edit | Preferences and set the External Script Viewer to be VS Code
    - To get Unity running on the lab computers:
        Open File Explorer (Win Key + E)

        Navigate to D:\Downloads\

        In this folder you will find two files relating to unity
        Check-Unity-License.bat
        License-Unity.bat

        As the file names suggest

        File 1 (Check-Unity-License.bat) will check and display the Unity license, if it exists on the machine.  Always run this file first.  If no license exists, run file 2

        File 2 (License-Unity.bat) will license Unity on the current machine for all users.  It takes a few seconds to run and gives no feed back apart from the busy icon for a few seconds. 

        If in doubt that you ran file 2 or not; just run file 1 again to verify, as it should now display a valid license

        You can now start Unity from the Desktop.  It takes ages to start, so be patient.
- Create an account on github if you don't already have one and be sure to set up a [personal access token](https://docs.github.com/en/authentication/keeping-your-account-and-data-secure/creating-a-personal-access-token) as this is what you will have to use as a password now 
- Fork the repository for the course (click the fork button above)
- Clone the repository and cd into the folder  you cloned:

```bash
git clone http://github.com/YOUR_GIT_NAME/GE1-2022-2023
cd GE1-2022-2023
```

- Check to ensure the remotes are setup correctly. You should see both origin and upstream remotes. The origin remote should be the url to your repo and the upstream remote should be the url to my repo

```bash
git remote -v
```

- If you don't see the upstream remote, you can add it by typing:

```bash
git remote add upstream https://github.com/skooter500/GE1-2022-2023/
```

- Switch to a new branch

```bash
git checkout -b mylab1
```

- Now launch Unity and see if you can open the scene we made in class today and run it.

Make some changes and do a final commit

[Submit the link to your fork](https://forms.office.com/Pages/ResponsePage.aspx?id=yxdjdkjpX06M7Nq8ji_V2ou3qmFXqEdGlmiD1Myl3gNUMUZWTzVSQldVVVpONDBFTTdYQUtNWExNTC4u)
