# Giant Talking Head

Name: Michael Noonan

Student Number: C20334611

Class Group: DT508

Video:

[![YouTube](http://img.youtube.com/vi/2FH_GQgePbU/1.jpg)](https://www.youtube.com/watch?v=2FH_GQgePbU)

# Description of the project

This is a simple project that involves interacting and conversing with two floating heads. The left controller interacts with the left floating head, and the right controller interacts with the right floating head. The conversation with one head cannot be interrupted until the end, and then the player can interact with the other, afterwards.

# Instructions for use

The left and right controllers' grip buttons select the corresponding head and starts its dialogue. The controllers' trigger buttons continue the conversation taking place from the selected head.

# How it works

How the project works is, the player can interact with each one of the two heads, one at a time. The player can witness the head they have chosen speak with their mouths moving, and hear them make unique sounds as the dialogue continues. After the conversation with the first selected head is over, the player can either choose to select the other head for another new conversation, or reselect the first head to restart the first conversation.

# List of classes/assets in the project

| Class/asset | Source |
|-----------|-----------|
| FloatingHeadSript.cs | Self written |
| FloatingHeadSript2.cs | Self written |
| DialogueManager.cs | Modified from [Coco Code](https://www.youtube.com/watch?v=PswC-HlKZqA) |
| DialogueManager2.cs | Modified from [Coco Code](https://www.youtube.com/watch?v=PswC-HlKZqA) |
| DialogueTrigger.cs | Modified from [Coco Code](https://www.youtube.com/watch?v=PswC-HlKZqA) |
| DialogueTrigger2.cs | Modified from [Coco Code](https://www.youtube.com/watch?v=PswC-HlKZqA) |
| Minecraft.ttf | From [dafont.com](https://www.dafont.com/minecraft.font) |
| Human_Good_00.mp3 | From [OpenGameArt.org](https://opengameart.org/content/voices-sound-effects-library) |
| Human_Good_01.mp3 | From [OpenGameArt.org](https://opengameart.org/content/voices-sound-effects-library) |

# References
* [Coco Code](https://www.youtube.com/c/cococode)
* [dafont.com](https://www.dafont.com)
* [OpenGameArt.org](https://opengameart.org)

# What I am most proud of in the assignment

What I am most proud of in the assignment was using ProBuilder for the first time to construct the giant head GameObjects, which was not an easy task to accomplish. In fact, another thing I am proud of was how the dialogue turned out, as it came out as smooth and unique, font-wise, as it is supposed to be. It could have been more impressive, if I was able to animate the mouths of the heads more like actual human mouths, only to find it proved impossible.

# What I learned

I learned how to use ProBuilder to construct my own GameObjects like the giant floating heads, one piece at a time. I also added ProGrids to ensure that the ProBuilder shape I create is constructed more smoothly. I have also learned how to create dialogue and use LeanTween to make transitions for the dialogue from each head.

# Proposal submitted earlier can go here:

[My project work](https://github.com/MN-Cool/michael-noonan-giant-talking-head)

## This is how to markdown text:

This is *emphasis*

This is a bulleted list

- Item
- Item

This is a numbered list

1. Item
1. Item

This is a [hyperlink](http://bryanduggan.org)

# Headings
## Headings
#### Headings
##### Headings

This is code:

```Java
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

So is this without specifying the language:

```
public void render()
{
	ui.noFill();
	ui.stroke(255);
	ui.rect(x, y, width, height);
	ui.textAlign(PApplet.CENTER, PApplet.CENTER);
	ui.text(text, x + width * 0.5f, y + height * 0.5f);
}
```

This is an image using a relative URL:

![An image](images/p8.png)

This is an image using an absolute URL:

![A different image](https://bryanduggandotorg.files.wordpress.com/2019/02/infinite-forms-00045.png?w=595&h=&zoom=2)

This is a youtube video:

[![YouTube](http://img.youtube.com/vi/J2kHSSFA4NU/0.jpg)](https://www.youtube.com/watch?v=J2kHSSFA4NU)

This is a table:

| Heading 1 | Heading 2 |
|-----------|-----------|
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |
|Some stuff | Some more stuff in this column |

