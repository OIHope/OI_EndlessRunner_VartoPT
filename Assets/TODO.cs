/*

style - lowPoly(like mega LOWPOLY)
enviroment:
	forest
	cave
	field

mechanics:

+ prefab beased

- randomly generated endless level
	if has more enviroments - make step step system

+ player is static as but level is moving

+ basic 3 roads

+ movement:
	go left\right
	jump
	slide

+ obstacles:
	big 1 line wall
	big 2 line wall
	small 3 line wall down
	small 3 line wall up

- collectables:
	+ food
	modifiers

- modifiers:
	speed boost
	collect all visible food
	destroy all visible obstacles
	additional life (+1 life)

- game loop
	run for the best score
		score sets on how long you're running
	if you hit the obstacle you have -1 life restart prompt
		when hit the obstacle - it destroys, so you cal run further
		if fall in the pit - level moves forvard to skip the pit
	you collect food to keep running
		+ if foodBar is empty you loose -1Life
		+ if continue - food bar fills half way
		+ if foodbar is full: +1Life

player:

- model:
	adventurer
	it should be black&white, so can add custom colors
	and maybe add some cloths and so on (if have time)
	
- animations:
	idle, ready to start running
	run
	jump
	slide
	hit the wall while stand
	hit the wall while slide
	resurect ?

UI:
	+ main menu
		start game
		exit game
	+ pause menu
		continue
		restart
		to menu
	+ startRunning panel
		press Move button to Start
	+ stats panel
		always on screen
	+ gameOver menu
		score show all game stats: gameScore based on time, all food collected
		compare score with devs best score XD
		restart
		menu
	+ propper Restart
		restart should reset ALL objects on the scene, just like in doodle I did
		
DONE:

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