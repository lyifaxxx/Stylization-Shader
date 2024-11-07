# HW 4: *3D Stylization*



https://github.com/user-attachments/assets/2fea6dea-25ec-483b-ab84-9414f805cfab



## Project Overview:
In this assignment, you will use a 2D concept art piece as inspiration to create a 3D Stylized scene in Unity. This will give you the opportunity to explore stylized graphics techniques alongside non-photo-realistic (NPR) real-time rendering workflows in Unity.

### HW Task List:
1. Picking a Piece of Concept Art
2. Interesting Shaders
3. Outlines
4. Full Screen Post Process Effect
5. Creating a Scene
6. Interactivity
7. Extra Credit


## 1. Concept Art
I want to use the toon shading effect rom concept arts at [Reference 1](https://www.artstation.com/artwork/4bo6oq) by ArtVostok Studio.

| <img src="https://github.com/user-attachments/assets/0ac2315d-552d-4a43-99f7-799c63d46e53" width="300"/> | <img src="https://github.com/user-attachments/assets/9732f05d-0cde-457e-9f21-7cae1bde5b9b" width="300"/> |
|---------------------------|---------------------------|

For the color palette I would like to use the high-contract rough sketch style in my recent favorite game Disco Elysium by zaum.

| <img src="https://github.com/user-attachments/assets/d6e5bda8-d6f8-4686-ad80-bf500351d242" width="300"/> | <img src="https://github.com/user-attachments/assets/d357989c-7e4b-4408-a7c1-9875d59299cc" width="300"/> |
|---------------------------|---------------------------|


---
## 2. Shader

Custom toon shader with several parameters. I implement the specular highlight. User can select a shadow texture. I genterated a texture with Substance Designer.

<img src="https://github.com/user-attachments/assets/c6595f21-3fee-4233-8b49-cdc75c69bfcd" width="300"/>

---
## 3. Outlines
To match my concept art, I use a rather wide outline for my character based on both depth and normal.

The outline color and thickess can be modified. I also use some toolbox functions to animate the outline.

<img src="https://github.com/user-attachments/assets/d8d0092a-8227-40d9-96c1-7da7fb05bd11" width="300"/>


---
## 4. Post Process Effect


### ACES Tone Mapping
ACES tone mapping is widely used in film industry to achieve natural looking.

| <img src="https://github.com/user-attachments/assets/a17b7b5e-dd5f-491a-903d-6c7c7bfc414f" width="400"/> | <img src="https://github.com/user-attachments/assets/5d68a703-7456-4b98-a4be-82fd9e841b83" width="400"/> |
|---------------------------|---------------------------|
| Without ACES Tone Mapping     |  With ACES Tone Mapping      |


### Border Line
One hightlighted feature for concept art is the border line around the frame. To get this effect, I take the Abs of the screen uv and compare it to some threshold. By making this threshold to an exposed parameter, we can control the width of the border.

<img src="https://github.com/user-attachments/assets/fb5aac74-9d0c-4075-9a19-904e3abe1ae5" width="400"/>

Also to make the border line less boring, I overlay an extra texture against the straight border. The Color of the border can be modified by user.

<img src="https://github.com/user-attachments/assets/794b8f1d-a369-41b2-8586-47757745c8b1" width="400"/>

### Film Grid Noise Effect
Overlay a noise texture to mimic film grid effect.


| <img src="https://github.com/user-attachments/assets/ab04786a-2016-499c-8f31-384ddf5cd149" width="400"/> | <img src="https://github.com/user-attachments/assets/1ded411d-5f63-43b0-a725-03d58e664915" width="400"/> |
|---------------------------|---------------------------|
| Without Noise     |  With Noise      |



## Credits

1. Textures: <a href="https://www.vectorstock.com/royalty-free-vector/hand-drawn-grunge-textures-vector-35144679">Vector image by VectorStock / vectorstock</a>
2. Model:
   Kim Kisuragi: https://sketchfab.com/3d-models/kim-kitsuragi-disco-elysium-8797f21bd13f4053a443b14cf4619b0b
   Street lamp: https://sketchfab.com/3d-models/street-lamp-game-ready-prop-041e5564b5224f83bcb620f551c3751b
