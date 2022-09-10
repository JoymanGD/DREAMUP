####################INTRO:
I spent ~4.5 working days on it.

I used a few scripts (few managers from Scripts/Managers folder) from my common Unity template "WaldemGame" (written fully by me) but most part of it was modified during this project.

All files in Content folder (except Fonts folder) were made during this project.
All scripts in DREAMUP folder were written by me from scratch during this project.

The UI layout is flexible and can be rendered pretty good on different devices.
####################

####################INPUT:
Movement: WASD
Use: E
Talk: F

Input is mostly configurable through InputManager.

Mouse input is included in the project but is not using.
####################

####################DIALOGUES:
Dialogues system is pretty flexible and can be evolved through abstraction I wrote.
####################

####################QUESTS:
Quest system is also pretty flexible so there may be a few quests at the same time and it will work ok.
####################

####################INVENTORY:
Only picked items can be selected in HUD inventory. That means you cannot select empty cells.

HUD inventory is configurable and can be expanded or shrink to required amount of cells.
####################

####################ECONOMICS:
Economics system is managable so you can add more resources then just gold.
####################

####################INTERACTABLE:
All NPC, quest items and any other interactable objects can be extended since the UsableObject abstraction allows it.
####################

####################SYSTEM:
Game loading is faked since it wasn't in the task requirements but may be changed to async loading if needed (there is an instrument in IInitable I wrote during this project).
####################
