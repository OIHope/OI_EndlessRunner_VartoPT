/*

style - lowPoly(like mega LOWPOLY)
enviroment:
	forest
	cave
	field

mechanics:

-prefab beased

- randomly generated endless level
	if has more enviroments - make step step system

- player is static as but level is moving

- basic 3 roads

- movement:
	go left\right
	jump
	slide

- obstacles:
	big 1 line wall
	big 2 line wall
	small 3 line wall down
	small 3 line wall up

- collectables:
	coins
	modifiers

- modifiers:
	speed boost
	collect all visible coins at once
	destroy all visible obstacles (exept pits) at once
	double jump (+5 times)
	additional life (+1 life)

- game loop
	run for the best score
		score gets on coins
	if you hit the obstacle you have -1 life restart prompt
		when hit the obstacle - it destroys, so you cal run further
		if fall in the pit - level moves forvard to skip the pit

player:

- model:
	adventurer
	it should be black&white, so can add custom colors
	and maybe add some cloths and so on (if have time)
	
- animations:
	idle, ready to start running
	run
	jump
	fall
	slide
	hit the wall while stand
	hit the wall while slide
	resurect


DONE:

17.05

- player now jump and slide +- properly, but need tweaking and some remake after cosmetics done
- player can hit obstales
	on hit level stops and can be reset by move input
	on hit the obstacle deactivates and resets on block reapear
- each block now has its own obstacle list that controls obstacle state reset


16.05

- base generator that pools blocks, and eneble\disable them
- start blocks, thet get destroyed after entering levelEnd trigger
- player basic input system
- player move left\right
- basic startMove function, that must be scaled in the future
- basic jump that doesnt work as intended
	the system of jump and slide must be reconsidered to work on coroutines but not on physics














*/