# GDIM32-Final
## Check-In
### Group Devlog
Prompt A: While working on the final project, we encounter a large merge conflict. We initially tried to resolve the conflict, but this caused many of our files and prefabs to get deleted. In order to restore these files and prefabs, we used the version control techniques that were taught in week 6. We used "discard changes" to discard current changes that were made to the scene. These were changes that Unity automatically created upon entering the scene, and thus, we simply discarded them. We then used "revert changes in commit" to revert the changes made in the merge commit that caused the errors to occur. We chose to uyse this method because the errors that were caused by the merge caused several key prefabs and files to get deleted, creating errors that made the game uplayable. So, the best choice was to revert the changes that caused these errors. After performing the revert, we were able to restore the version without all the missing assets. However, now, the new commits (the ones that caused the merge conflict problem) were gone. So, we needed a way to restore these files without causing the errors again. To do this, we used "create branch from commit" to create a temporary branch from the commit that caused the errors. We then copied and pasted the dialogue and NPC related files from the temporary branch into the real branch. After this process, we were able to restore the final project repo and also add in the new code.

### Leo Abe
I worked on the NPC scripts and dialogue system scripts. These include the DialogueManager, DialogueObject, DialogueUI, DialogueTyper, DialogueUILocator, NPC, FrogmanNPC, and FrogmanLocator scripts. I also set up the UI for the dialogue and came up with the dialogue lines. I did not really use the proposal and break-down for building my project. This is because I already had a good idea on how to build the NPC and dialogue system, and the idea I had in my mind was more complex and detailed than what was in the proposal or break-down. Since this is a small and simple game, not using the proposal and break-down didn't really affect my productivity. However, for future games (which will be larger in scale), I think creating a more detailed planning process would help me keep track of my progress.

### Jing Chen
I worked on the Inventory and Player Controller Systems, These include the PlayerController, Inventory, ItemPool, PoolObject, Inventory UI, I made some prefabs and object pool to store used
objects. I put in MonoSingleton as tool,added ui for inventory, and ensured each code only manage their own parts, make sure they are object-oriented. In the future I want to fix some bugs on my object pool so
the game would run smoother.
### Han Yang
I made the 3D models, animations, item interaction system, audio system, some UI, and scene building. These include all the 3D mesh and texture used in this project, InteractorManager, AudioManager, Locator, IInteractable interface, Item, child class of Item, and UIManager. For UI, I worked on the crosshair, interaction hint that appears when the raycast of crosshair hits an interactable item, and UI formatting to fit in any sized window. I pretty much followed the breakdown for the item system, and the proposal helped me remember which parts of the project to work on, and to keep hands off other members' field of work. 


## Final Submission
### Group Devlog
For the project, we used three design pattenrs: singleton pattern, model view controller pattern, and inheritance/polymorphism. 

For our Singleton pattern, we have a MonoSingleton Script for singleton 
classes to inherit from. This automatically turns them into a singleton with monobehavior, like the Inventory script we have. Since there should only be one inventory in the scene and we want it to be global accessible so we know what's in the player's inventory, using the Singleton pattern ensures we get these results.

Another pattern we used was Inheritance with Polymorphism. This pattern can be found in our npc related scripts. Since we have two different npc, Eric Frogman and Giga Toad, we use this pattern to better organize our code and prevent the need to repeat redundant code. Eric Frogman and Giga Toad have different behaviors and serve different purposes in the game. Frogman assigns fetch quests while Giga Toad is an item trader. However, there are certain features that are present in both npcs. For example, both npcs have two states: Idle and Talking, and they both start in Idle. Thus, certain methods like Start() and certain variables like saidIntro and NpcState enum are included in the parent NPC class. Thus, these things don't need to be rewritten in the FrogmanNPC and GigaToadNPC child class. This pattern helps reduce redundant code and make the project more scalable because we only need to include in the child npc classes methods that will be unique to those npcs. Additonally, some methods in the parent NPC class are virtual, like TalkTo() and OnCollisionEnter(), because these methods are present in both child npcs but the code inside them are different between the two.

We also used the MVC pattern to help organize our code and making working in a team of three easier. We did this by separating the various manager scripts (model), the UI scripts (view), and the player scripts (controller). Separating our scripts with the MVC pattern enabled each team member to work individually without having to worry about potential merge conflicts or having to wait for one another to finish certain scripts in order to run individual tests. This pattern also made it easy to modify, add, and delete code without the risk of causing game-wide errors. 

### Leo Abe
I worked on the dialogue and response system scripts, NPC scripts, and Frogman shooter scripts. These inclde the Response, ResponseEvent, ResponseManager, FrogmanDialogueManager, GigaToadDialogueManager, FrogmanNPC, GigaToadNPC, NameTagChanger, QuestManager, FrogmanBullets, and FrogmanShooter scripts. I also set up the dialogue box UI, response options UI, and quest UI. To summarize, the parts I worked on mainly regard the NPC behaviors, quest system, and branching dialogue system. Since the last update, the player can now not only trigger dialogue from both npcs but can also select response options when speaking to Giga Toad and accept and complete quests assigned by Frogman. The Quest UI updates based on the status of the quest assigned by Frogman. Frogman also will shoot projectiles at the player if they give him the wrong item. 

### Jing Chen
Since last update, I improved and finished UI for Inventory, now, everytime when player scroll their mouse, "Inventory" will record the current selected grid and use event to trigger the function "UISlotUpdate(int slot)" 
in "Inventory UI" to highlight it and dehighlight other grids. I also added the ability for player to throw items, it takes a similar step like drop item, however, I reconstructed the "OnDrop()" function from void to GameObject type
so it can return the item that's dropped and I can set it's physical motion for throwing.
### Han Yang
I made more 3D models for Gigatoad NPC, water puddle amd lotus paddles in the environment, and several new items, then updated some item collisions and rigidbody properties (including drag, mass, and lock rotate) to work better with the new inventory and NPC's item detection. Added new script MoveToTargets on the EricFrogman NPC so it wonders around the map instead of standing still. Fixed NPC's interaction system to adapt from item's interaction system using raycast. Visually reworked UI.

## Open-Source Assets
Cite any open-source assets here. Put them in a LIST, and use correctly formatted LINKS.

Sound:
- https://pixabay.com/sound-effects/search/frog%20nature/
- https://pixabay.com/sound-effects/people-burp-90749/
- https://pixabay.com/sound-effects/film-special-effects-dry-grass-rustling-478361/
- https://pixabay.com/sound-effects/nature-giant-frog-383181/
- https://pixabay.com/sound-effects/nature-animals-duck-64800/
- https://pixabay.com/sound-effects/film-special-effects-book-drop-30016/
- https://pixabay.com/sound-effects/nature-cricket-sound-212751/
