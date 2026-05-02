# Unity Slot Machine Game

## Game Overview
This is a 2D slot machine game created in Unity.  
Players press the spin button to rotate three reels.  
Matching symbols in the center row results in a win popup with sound effects.

## Instructions to Run WebGL Build

Open:

Build/index.html

OR upload to GitHub Pages to play in browser.

## Features Implemented

- Reel spin animation
- 25% controlled win probability system
- Win popup screen
- Main Menu navigation
- Retry option
- Exit option
- Sound effects (spin / stop / win)
- WebGL build included

## Thought Process / Approach

The slot reels were implemented using vertical symbol containers that loop during motion and snap into grid alignment when stopping.  
A forced-symbol system ensures controlled probability for wins while maintaining randomness for gameplay feel.
