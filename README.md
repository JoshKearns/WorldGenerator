# Labyrinth

----------------------------------------------------------

# Name:
Josh Kearns
# Student Number:
C18709205
# Class Group:
DT508

----------------------------------------------------------

(https://youtu.be/q081wLEeaHM)

----------------------------------------------------------

# Description of the project / How it works
My final submission is a randomly generated maze.
The maze size is determined by a set of options in the main menu and is built by placing a grid of walls and procederly winding a path through each unvisited cell until the path has gone through each cell to ensure no areas are cut off from the rest.

The player is giving a map with a render texture of the maze from above to assist with navigation. The camera's placement is determined by the x and z size of the maze to ensure its height and offset is in a way that will always include the full view of the maze.

The goal of the game is to simply navigate the maze collecting all the coins.

----------------------------------------------------------

# Instructions for use
To play you use the wasd keys to walk around and the mouse to look.

In the game you can press the escape key to return to the menu.

----------------------------------------------------------

# What I am most proud of in the assignment

I am most proud of how all the systems are working together with no issues or bugs. 

The spawn room, coin placement, map camera position and more or all working together for each variation of the mazes size.

I also really like how the map works.

----------------------------------------------------------

# Initial Idea

I am building a random world generator.

Currently I'm following Sebastian Lague's planet generator playlist (https://www.youtube.com/playlist?list=PLFt_AvWsXl0cONs3T0By4puYy6GM22ko8) to generate terrain but am not entirely happy with the quality. It cannot generate enough faces to look seamless and lower face counts leave jagged edges. I will probably restart with a custom generator to go for a low poly aesthetic.

I'm looking to add everything randomly through code including trees/ bushes, rocks, ruins, animals, resources, etc. by spawning them above the surface and ray casting down to check for available/ suitable placements.

Ideally I want multiple planets you can travel to and explore like a discount No Man's Sky.

----------------------------------------------------------

# Reflection
After going through multiple different iterations of my planet generator idea, I was never happy with the flexibility or fidelity of each attempt.

I spent a lot of time focusing on trying to get this idea to work and would have liked if I decided to scrap the idea earlier. This would have given me more time to polish my maze idea.
