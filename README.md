# Musopia

Make a simple one screen app with Unity, using basic Unity UI (i.e. not for example NGUI).

Important: Please use one of the following Unity versions to avoid problems evaluating your app:
* 2019.3.4f1
* 2018.3.10f1

The app is a simple "music looper", that allows user to create 3 different 1 second loops and select which one is currently playing. Attached, there’s a screenshot of the app.

On the top you have 3 empty buttons. Those are used to select loop 1, 2 or 3. The currently active loop is indicated with a white outline.

In the middle you have a 8x8 grid with cells that you can toggle on/off by clicking at them. If a cell is on, it will produce a sound. The bottom row will produce the lowest sound and the top row the highest. There are 8 rows in total and the sound assets s1.wav -> s8.wav correspond to the rows in the grid.

The player runs through the grid from left to right in 1 second. When it gets to the end, it starts again from the left. So, for example, if you turn on the bottom left corner cell only, the player will play sound sample s1.wav once a second.

The text field on the bottom displays the current column for the player, so that it will continuously loop through 1/8 -> 8/8 in one second.

There is no play/stop button. The player runs continuously and plays the sounds immediately according to the logic described above.

Clicking on the loop buttons on the top will immediately display active cells for that loop and switch to playing that. Player will not start from column 0 when the loop is changed. It will instead always continue from the current column. User can toggle cells on/off at any time.

Here's a link to the graphics and audio assets needed to develop this "demo":
http://www.musopia.net/randd/grid8x8assets.zip

P.S. The layout does not need to be pixel perfect compared to the screenshot above, but it should be close to it.<br/>
P.S.S. As an extra, what would be the first thing you would add to the simple demo app to make it better/more interesting?
