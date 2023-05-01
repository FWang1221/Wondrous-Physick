EasySoulsAI - A KVP System for Easy Creation and Modification of Enemy Behaviors

*Requires Sword Mastery to work or something adjacent to it.

How the does this work?

Well, first navigate to the easySoulsMaker/easySoulsKVPs.csv file. Don't ever rename it. Don't fuck with the headers. Or the file layout.

In the beginning, all the spEffect pairings are created, and only a few are chosen for the enemy. The first field, Enemy SpEffectID is the SpEffectID that needs to be on the enemy AT CREATION. (That is, unless you modify the c9997.hks file.) You MUST have the SpEffect on the enemy you want to affect on it AT CREATION in the NPCPARAM. For easier NPCParam massedits of the SpEffects, use https://github.com/FWang1221/NPCParam-SpEffect-Reorganizer

The Key and Value SpEffects work exactly like you think it does. If the Key SpEffect is activated for the enemy, immediately after, the Value SpEffect will be activated, at Chance%. So if I have a value of 53 for Chance, there's a 53% Chance it'll be activated. -1 and 100 are guaranteed to fail (why you would use -1 is a mystery) and succeed, respectively.

The operator is a a number. 0 is no operator, what you put in the SpEffect Conditional doesn't matter. 1 is AND, so the KVP only works if you have the SpEffect Conditional active. 2 is NOT, so the KVP only works if you don't have the SpEffect Conditional active.

How the does this enable me to create amazing creations?

Well, (for Sword Mastery at least), every enemy has SpEffects activated during its attacks, it's animations from 003000-003040. Let's say the last 2 digits of the attack, the attack number (00-40), we represent as XX, so if I'm talking about 3030, XX is 30.

After the attack has been blended, there is a 1 frame SpEffect activation of 99961XX.

During the attack, and 1 frame before it, there stretches a SpEffect activation of 99965XX.

Three frames after the last attack of an animation, there is a 1 frame SpEffect activation of 99962XX.

This tells us what is going on by indication of SpEffects. Then we can simply use 99963XX SpEffects to force other attack animations along the 30XX range along certain probabilities. 

We could also detect certain 99965XX SpEffects and use stateInfo 275-type SpEffects that reference generic bullet-creating BehaviorParams for elemental varients of enemies.

Speed Randomization is also possible as the Sword Mastery regulation.bin contains 999640X SpEffects that will delay an animation by 0.1-1.5sec.

Gimmick interactions such as Miranda Flowers being allergic to Poison or Fire Slugs exploding when hit by BlackFlame could also be created this way. The possibilities are endless.

After your finish filling out the CSV, just run the program and copy and paste the action folder in here to your mod directory. Replace the file.

For Those Unwilling To Download Sword Mastery:

You can set your own setups up using the TAE Exporter Many and TAE Importer Seed bundled in with this. While this program requires .net 4.7.2, the others requires .net 6.0 as they use SoulsFormats. The usage of those tools are pretty simple, though keep in mind that the SwordMasSeed.csv the Seed Importer draws from must be in the same directory as the anibnds being modified. The programs packed with this have some minor dialogue issues. Don't worry too much about it.

Credits to everyone listed on the Sword Mastery page, Nordgaren and GompDS and everyone else on the massively outdated TAE Importer/Exporter page for the helping with the original TAE Importer/Exporter, and Vawser and Ivi's HKS repo.

If you use this tool, please drop a link to it or to Sword Mastery on the page. If you use this tool for purely paywalled anime moveset mods, you can fuck right off.

Presets within include "Elemental Weaknesses", "DS1 Speed", "Incredibly Waterfowl Mode", and "Swordmas Bosses".

Fun Preset CSVs such as "Randomized Attack Speeds", "Eldelayed Ring", "Waterfowl Dance Begone!", "Roguelike Attack Patterns", and more coming soon!
