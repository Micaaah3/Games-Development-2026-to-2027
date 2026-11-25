# Assignment 2 > All Purpose Bar

## Development Plan
	
### Goals
- [x] Create this very document
- [x] Create the testing part
- [x] Adjustable values; (Min, current, max) through setMin/setCur/setMax
- [x] Ability to set percentage or arbitrary float values (Manually set to 70% or set bar value to 70 for example) through setPercent/setCur
- [x] Display on UI
- [x] Display in world (I.e health bar above enemy/boss)
- [x] Changeable bar colors (Can indicate stamina, energy, health, etc) through setColor
- [x] Text option (Either showing values, or what the bar means) through setText

I made the text be accessible directly from the bar script so there's no reason to make 20 other functions
when doing bar.Text.blahblahblah works just as well. though we have a bar.Title variable/function so it can be saved in the bar
too.

## Testing Plan
- [x] Read this document
- [x] Read the testing part
- [ ] Test it.

Code, assets, prefabs, materials, etc,etc is in Assets/MicahEidner/AllPurposeBar/
To test it, you must set .isTesting to True.

To use the class, there are two prefabs for a situation, one prefab (Bar - Screen Overlay) is for displaying elements on
the user's screen that is NOT attached to an object, i.e a player's health bar being consistently in the bottom left rather than
the player's health bar being an object in the world which could move off of screen when looking around.

Then there's the other prefab (WorldCanvas - Bar) that is used when you want to display a bar over an enemy, i.e the enemy's
health, charge to next attack, instead of it being constantly over the player's screen. It gets blocked by objects in front
of it.

As mentioned above, you need to set .isTesting to True to get any output in the console. The code would still work without this flag enabled.
There are many get/set functions that you can use. You are not able to change the variables in the INSPECTOR without .isTesting = True.

To move a screen element, you should set .IsScreenOverlay to True to avoid any odd behaviour. This variable sets the element's local position
instead of the world position. A screen element bar will automatically load the position from the transform on game start.


The following variables have a get/set function attached.

 - current (Sets the current value)
 - currentPercent* Set Only ( Sets the value as a percentage of the max.)
 - BarMax (Sets Maximum value)
 - BarMin (Sets Minimum value)
 - MainColor (Changes the primary color)
 - BackgroundColor (Changes the background color)
 - Title (Changes the text on top of the bar)
 - Position (Changes position, world if IsScreenOverlay = False, otherwise local)
 - IsScreenOverlay (If the bar is supposed to stick to the screen or not)
 - IsTesting (Required if using inspector to change variables, or expecting a debug message)
 - Text (Used for modifying textmeshpro attributes directly. Changing text via code not recommended.)
