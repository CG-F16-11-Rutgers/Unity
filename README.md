# Unity
General Unity Playground with all needed assets

GROUP MEMBERS:
Vineet Sepaha - vs381
Albert Stein - avs80
Michael Shur - mas868
Quzhi Li - ql80

B1: 
In this assignment, we had to create a simple crowd simulator.
The requirements that we had to meet were:
- Creating a free look camera
- Creating a complex environment
- A NavMesh for the whole environment
- Agent prefab with NavMeshAgent component
- Agent Navigation with a mouse
- A NavMeshObstacle which could move when selected
- Refine agent navigation (collision with each other)
- Dynamic obstacles
- Different weight Planes

Although there were a few small bugs in our assignments, we were able to meet most of these requirements. 
The only problem with our project was that we were unable to finish creating dynamic obstacles.
This was due to the communication problems we had in our group.

B2: 
In this assignment we worked with animation. This project was broken down into several parts.

Part 1- Animation
For this assignment, the goal was to create a character which would be able to perform actions generally performed by video game characters. The animation was made possible by creating a finite state machine along with the 2D blend trees to transition between the animations. The blend trees were created for Idle, Walking and Running and Boolean variables were used to transition between these states.

Part 2- Animated Navigation
For this assignment, the goal was to create a character using animations which would move to the clicked area while using the assignned animations. Using what we learned from the previous Unity assignment (B1), we were able to implement this part of the assignment. The only difference was having to animate the character while moving. This was implemented by changing the state in which the character was by the use of Booleans.

Part 3- Crowd
When the play button is pressed the characters are assigned in groups of 5 to two different locations. Once all of the agents reach their respective locations, they all move to one common final destination. Here, they all stop once they reach a certain distance from the destination to keep them from constantly running into each other.
