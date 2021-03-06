# cs4483_individual_game_prototype

## Controls

The player can move around using W to move forward (using SHIFT to run) and A and D to rotate the camera and interact/attack by right clicking. 

## Condensed Requirements
These requirements were extracted from my game pitch and itemized. The requirements that have not been implemented are marked with "(NOT IMPLEMENTED)" after them. Please note that I followed [this](https://www.youtube.com/watch?v=S2mK6KFdv0I&ab_channel=Brackeys) tutorial for implemented the inventory and equipment system.

1. Challenges  
1.1. Periodic damage from the conditions of the frozen wasteland. (Players will lose one HP every second that they are not in shelter)
1.2. Needing to hunt creatures for food. (Players will need to loot creatures to get food and potions to heal)
1.3. Limited inventory (Players have limited inventory slots)

2. Player Actions  
2.1. Movement: walking, running, jumping.  (Did not implment jumping)   
2.2. Vehicles: Drivable vehicles and Rideable Animals (NOT IMPLEMENTED)   
2.3. Hunting (Passive mobs, the green prism, drop loot)   
2.4. Crafting (NOT IMPLEMENTED)   
2.5. Lockpicking (NOT IMPLEMENTED)   

3. Skill Trees (I did not implement any of these skill trees, currently the player will attack unarmed by right clicking the enemy)
3.1. Melee: The player can use one handed (sword and dagger or shield) or two handed weapons (two handed sword/hammer/axe). (NOT IMPLEMENTED)   
3.2. Ranged: The player player can use a variety of weapons, projectile (crossbow or longbow) and energy based (rifles). (NOT IMPLEMENTED)   
3.3. Magic: The player can use magic attacks that can be precise or AoE (are of affect) to inflict damage on groups of enemies or a single target. (NOT IMPLEMENTED)   

4. Environment  
4.1. Creatures (For my prototype I implemented three type of mob)   
4.1.1. Aggressive creatures: Will attack you if you come in proximity to them. (The red prism)   
4.1.2. Docile creatures: Will not attack you if you come in proximity. When attacked, will either retaliate or attack you. (The green prism will flee from the player and the orange prism will fight back)   
4.2. Ruins: the player can explore ruins and find chests. (NOT IMPLEMENTED)   
4.2.1. Vaults: Some ruins contain vaults where the player can absorb or release the orb’s lifeforce. (NOT IMPLEMENTED)   
4.3. Shelter: Areas where the player can set up camp, craft items and rest to heal. (The prototype has a structure that will shield the player from the elements)   
4.4. Settlements: These are areas that are populated by NPCs. There are three types of settlements:  
4.4.1. Telosian: These NPCs will not attack the player, and the player can trade and sell their items here.   (NOT IMPLEMENTED)    
4.4.2. Raider: These settlements are populated by the people responsible for the player’s vault being disturbed. These NPCs will be hostile towards the player.  (Same placeholder as the agressive creature (Red prism))   
4.4.3. Telosian (Vault): These settlements are populated by occupants of a vault where the player chooses to release the energy back into Telos. (NOT IMPLEMENTED)   

### Table of Contents
1. [Challenges](#Challenges)
2. [Player Actions](#PlayerActions)
3. [Combat Skill Trees](#CombatSkillTrees)
4. [Environment](#Environment)

# Abridged Abyss Gameplay Requirements

## 1. Challenges
**The first two elements relate to the core mechanic of time management as the player should aim to limit the amount of time that they are exposed in the wasteland.**  
### 1.1.	Periodic damage from the conditions of the frozen wasteland.  
When the player is not in a shelter (i.e. structure or cave) they will suffer debilitating effects.
### 1.2.	Needing to hunt creatures for food. 
The player will need to consume food periodically so that they do not starve.
### 1.3.	Limited inventory
The player will have a limited amount of inventory slots. The player will be able to expand their inventory capacity through the crafting skill tree.  

## 2. Player Actions 
**The actions that a player can take are determined by their skills (the player will be able to put skill points into these categories when they gain enough experience to level up).**  
### 2.1.	Movement: walking, running, jumping.  
The player will be able to walk, run, and jump around the environment. 
### 2.2.	Vehicles: 
The player can drive vehicles and ride some creatures to travel around the enviroment faster than they would be able ot otherwise. 
### 2.3.	Hunting
The creatures the populate Telos (the world of Abridged Abyss) will provide materials that can be used for consumption and/or crafting.  
### 2.4.	Crafting
The player can craft armor and food by using the items in the player’s inventory that can be obtained from hunting creatures and looting chests. 
### 2.5.	Lockpicking 
The player will be able to learn how to lockpick locked chest, and will be able to advance their skill throughout the game. This skill will be important to the player if they wish to open chests located throughout the world.  

## 3. Skill Trees
**The player will have three combat skill trees that they can progress in (the player will be able to put skill points into these categories when they gain enough experience to level up).**  
### 3.1.	Melee 
The player can use one handed (sword and dagger or shield) or two handed weapons (two handed sword/hammer/axe).  
### 3.2.	Ranged 
The player player can use a variety of weapons, projectile (crossbow or longbow) and energy based (rifles).  
### 3.3.	Magic 
The player can use magic attacks that can be precise or AoE (are of affect) to inflict damage on groups of enemies or a single target.  

## 4. Environment
### 4.1.	Creatures
The world of Telos will be open world and be populated by creatures (some passive and some aggressive, that will pursue and attack you).   
#### 4.1.1. Aggressive creatures
These creatures will attack you if you come in proximity to them. These creatures will drop items that can be used for crafting.  
#### 4.1.2.	Docile creatures
These creatures will not attack you if you come in proximity. When attacked, these creatures will either retaliate or attack you. These creatures will drop items that can be used for crafting and/or consumable items.  

### 4.2.	Ruins
In Telos the player can explore ruins and find chests that they can either use their lockpicking skills to open or force the lock open and risk damaging the contents.  
#### 4.2.1.	Vaults
Some ruins contain vaults where the player can absorb or release the orb’s lifeforce.  

### 4.3.	Shelter
Areas where the player can set up camp, craft items and rest to heal.  

### 4.4.	Settlements
These are areas that are populated by NPCs. There are three types of settlements: 
#### 4.4.1.	Telosian
These settlements are populated by the descendants of the Telosians who did not go into stasis in the vaults. These NPCs will not attack the player, and the player can trade and sell their items here.
#### 4.4.2.	Raider
These settlements are populated by the people responsible for the player’s vault being disturbed. These NPCs will be hostile towards the player.  
#### 4.4.3.	Telosian (Vault)
These settlements are populated by occupants of a vault where the player chooses to release the energy back into Telos.  

