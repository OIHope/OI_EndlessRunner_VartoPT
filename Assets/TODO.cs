/*

TODO:

UI:
  System:
	make input button selection
	+make ui prefab based, especialy buttons
	make time to show like 00:00 but not 0:0
  Visual:
	+find good font
	+draw pretty panels
	+draw pretty buttons:
		+just one size
	+draw pretty icons:
		+food, heart, clock\timer, mainScore(star?)
  New Feature:
	add prompts for control input and game mechanics (food related)
	add prompts on how you can use jump and slide (that you can interupt them)
	add prompt when food is low and when one heart is left
	add visual feedback on food and heart icons (animations made with unity (size\rotation\color))
		both play short animation when gain one, and another animation when lose one
		food start flashing when is low
MENU:
	+add settings
		+add toggleBox for GodMode
		+add toggleBox for performanceMode (it should turn on\off block decorations)
		+add speed setup (maybe slider, or maybe checkbox idk) it has to be made somehow (maybe like a dificulty setting)
	

CAMERA:
	figure out how to make distant objects to blend with background, so that clipping is not that bad
	add animation feedback on hit
	make it follow the player on horizontal axis (smooooooothly)

VISUAL:
	declutter backgrounds to improve both performance and visual
	check out blocks food positioning 
	maybe make food blocks prefabs?
	add particles to the game:
		ui particles: food\heart\setting new best score
		inGame particles: footStep, jump, slide, hit, fall, obstacleDestroy, foodCollect


SYSTEM:
	check hiding BlockPrefabs on the scene (or disabling them) to work correctly on start
	player jump animation finishes before player is on ground
		maybe add land animation?
	work on move system:
		when player is hit - the next move input should be read as movement, not just toggle to start moving
		on the begining fix that shit with "PRESS SPACE" to actualy work only on pressing SPACE
	add loadingScreen in between menu and game, gameover and restart
	add tutorial sequence (maybe like a slideShow with descriptions for basic mechanics)
	implement godMode system
	

	NEED CODE CLEANING!!!



	
DONE:

21.05
- fixed gitIgnore file, as it didn't upload .meta files so previous uploads are completely fucked up...
	but I have everyday builds huh, so I can see the progress
- planning next moves, writing everything down to have a guideline on what to do\fix next
- added gameManaged, all it does now - locks game at 60FPS so my laptod doesnt blow up
p2
- remade ui with new textures
- made prefabs of buttons and some panels
- added font and its material
- made settings menu
- implementd dificulty modes (low and high level movement speed)
- implemented performance mode (turns off all decorations on blocks, exeft fences)
- fixed somehow if pause game, go back to menu and start new game - pooled platforms move


20.05
- added player model with all animations
- hoocked up animations
- separated player collision part and render part movement, so render part remain on ground when slide action is performed
- tweaked remaining mountain prefabs. fixed spacing between obstacles and so on
p2
- prpared models for cosmetics
- linked materials to all models... i hate it
- decorated all regions, and now I see that it SUCKS!
	this visual garbage is  baaad, need to fix it
but after all - this game is ready to play, at this point
it just needs some visual UI things, level decoration tweaks, textres tweaks and it;s done, realy
and SOUND!, need to wright some melodies, I guess
p3
- a bit remade materials and textures, cleaned come detail clutters, but still looks a bit off
- added skybox
- changed camera position

19.05

- gameover panel now has menu button, that closes app (if build)
- changed some names in UI
- add main menu placeholder
- fixed block dont add to list pool
- fixed blocks dont move, after restart
- fixed restart issues in almost all systems
- fixed pause system to release pause after the menu off (it took some time to track this issue)
- fixed ActionManager sub and unsub in almost all systems
p2
- fixed obstacles and collectables dont reset
- setting up score system
- ui placeholder update to match score system
- gameplay stats ui now show +- correctly all values
- gameovr panel now receives stat data on enable
with that base UI part is DONE
until I find some bugs, lol
p3
- some minor UI adjustments
- added models for blocks, now it looks like a game
- made blocks as prefabVariants, but somehow fucked up FOREST and MOUNTAIN variantsm they inherid brom wrong prefab
- adjusted camera but idk...
p4
- fixd block pool and canBeUsed pool dont update... again
- remade all but mountain prefabs, gonna change it tomorow..

18.05

- changed a bit scene layout: 
	separated ui(main menu ui and gameplay ui)
	placed game objects into its own container
- added forest and cave blocks placeholders
- removed dificulty enum
- generation now used dictionaries to circle enviroments with step count, realy handy staff
- fixed player keep moving after gameover
	but there's a bug, the you can restart if you hit move buttons right after gameover ui popup
	somehow death don't trigger in time
- fixed newGame start panel popup (in a bad way obviously)
p2
- block pool now can have separate containers for each enviroment, it's just for beter navigation
- removed this fucking while loop as it crashed unity!
	now it works based on sorting out those blocks that have (canBeUsed false)
- tweaked a bit start trigger, but nothing happened, lol
p3
- add pause menu
- implemented pause based on timeScale
	put it on GameSpace container and hope it works only for it, but who knows
- fixed ui input deactivate after gameover restart
- fixed pause panel could show when startPanel is shown (in a VERY BAD WAY!!!)
- pressing on Menu button should close app (if build)

17.05

- player now jump and slide +- properly, but need tweaking and some remake after cosmetics done
- player can hit obstales
	on hit level stops and can be reset by move input
	on hit the obstacle deactivates and resets on block reapear
- each block now has its own obstacle list that controls obstacle state reset
p2
- added food system
	now player need to collect food to keep going
	if food = 0 - player dies (well, just stops for now)
- collectabl food now triggers action, such a good system!
p3
- added life system
	player now can lose lifes (maybe worth to change to hearts...)
- added basic UI just to see values
- added small delay after you hit the wall
- changed slife valie foum -2f to -1f, now player collects all ground collectables while sliding
p4
- added start ui panel
- added pause ui panel placeholder
- added gameOver screen
- now can restart the scene
- fixed block spawn problem after respawn
	now spawn triggers by start blocks too

16.05

- base generator that pools blocks, and eneble\disable them
- start blocks, thet get destroyed after entering levelEnd trigger
- player basic input system
- player move left\right
- basic startMove function, that must be scaled in the future
- basic jump that doesnt work as intended
	the system of jump and slide must be reconsidered to work on coroutines but not on physics



*/