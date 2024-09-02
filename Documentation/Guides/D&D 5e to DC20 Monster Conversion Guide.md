# Updated D&D 5e to DC20 Monster Conversion Guide (0.20)

## Step 1: Determine Level and Type

- CR 0 (very weak): Novice
- CR 0 (weak): Level 0
- CR 1/8 to 1/4: Level 1
- CR 1/2 to 1: Level 2
- CR 2: Level 3
- For higher CRs, continue increasing the level accordingly.

Determine the monster type: Minion, Low, Mid, High, Boss, or Solo for Level 1 and above. For Novice and Level 0, use Easy, Medium, or Hard.

## Step 2: Set Base Statistics

Use the following baseline for Novice through Level 3 monsters:

| Statistic | 🟢Novice | 🟢Level 0 | 🟢Level 1 | 🟢Level 2 | 🟡Level 3 |
| --- | --- | --- | --- | --- | --- |
| HP | 4 | 6 | 10 | 15 | 22 |
| PD | 9 | 10 | 12 | 12 | 14 |
| MD | 7 | 8 | 8 | 8 | 10 |
| DR | 0 | 0 | 0 | 0 | 0 |
| Attack | +2 | +3 | +4 | +4 | +5 |
| Damage | 1* | 1 | 1 | 1 | 2 |
| Speed | 5 | 5 | 5 | 5 | 5 |
| AP | 4 | 4 | 4 | 4 | 4 |

*An Attack with a Base Damage of 0 can only deal damage if the attack gains more damage from Heavy Hits and above, or other possible features that increase damage dealt (such as Power Attacks).

## Difficulty Modifications Table

Apply these modifications to the base statistics based on the monster's intended difficulty:

| Level | Type | HP | PD | MD | DR | Damage | AP | LAP | Speed |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 🟢Novice | Easy | -1 | -1 | -2 | 0 | -1* | 0 | 0 | 0 |
|  | Medium | 0 | 0 | -1 to 0 | 0 | 0 | 0 | 0 | 0 |
|  | Hard | +1 | +1 | +1 | 0 | 0 | 0 | 0 | 0 |
| 🟢Level 0 | Easy | -1 | -1 | -2 | 0 | 0 | 0 | 0 | 0 |
|  | Medium | 0 | 0 | -1 to 0 | 0 | 0 | 0 | 0 | 0 |
|  | Hard | +1 | +1 | +1 | 0 | 0 | 0 | 0 | 0 |
| 🟢Level 1 | Minion | -9 | -2 | 0 | 0 | 0 | -2 | 0 | 0 |
|  | Low | -5 | -4 | 0 | 0 | 0 | 0 | 0 | 0 |
|  | Mid | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
|  | High | +5 | +2 | +2 | 0 | +1 | 0 | 0 | 0 |
|  | Boss | +10 | +4 | +4 | +1 | +2 | 0 | 2 | 0 |
|  | Solo | +15 | +4 | +4 | +1 | +2 | +4 | 4 | +2 |
| 🟢Level 2 | Minion | -13 | -2 | 0 | 0 | 0 | -2 | 0 | 0 |
|  | Low | -8 | -4 | 0 | 0 | 0 | 0 | 0 | 0 |
|  | Mid | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
|  | High | +5 | +2 | +2 | 0 | +1 | 0 | 0 | 0 |
|  | Boss | +10 | +4 | +4 | +1 | +2 | 0 | 2 | 0 |
|  | Solo | +20 | +4 | +4 | +1 | +2 | +4 | 4 | +2 |
| 🟡Level 3 | Minion | -16 | -2 | 0 | 0 | 0 | -2 | 0 | 0 |
|  | Low | -10 | -4 | 0 | 0 | 0 | 0 | 0 | 0 |
|  | Mid | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
|  | High | +5 | +2 | +2 | 0 | +1 | 0 | 0 | 0 |
|  | Boss | +10 | +4 | +4 | +1 | +2 | 0 | 2 | 0 |
|  | Solo | +15 | +4 | +4 | +1 | +2 | +4 | 4 | +2 |

*Reduce to 0 base damage for Novice Easy monsters.

## Step 3: Determine Attributes

Convert 5e attributes to DC20 attributes:

- Might: (STR + CON) / 2, rounded down
- Agility: DEX
- Charisma: CHA
- Intelligence: (INT + WIS) / 2, rounded down

Attribute scale in DC20:
-3 (Extremely low), -2 (Very low), -1 (Low), 0 (Average), 1 (Above average), 2 (High), 3 (Very high)

## Step 4: Adjust Health

Adjust the base HP using the Difficulty Modifications Table, considering the monster's Might score and its role in combat.

## Step 5: Calculate Defenses

PD = 8 + Combat Mastery + Agility + Armor Bonus
MD = 8 + Combat Mastery + Charisma + Intelligence
Combat Mastery (CM):

- Novice: 0
- Level 0: 1
- Level 1: 1
- Level 2: 1
- Level 3: 2

## Step 6: Set Damage

Adjust the base damage using the Difficulty Modifications Table, based on the monster's role and abilities.

## Step 7: Adjust Speed

Default is 5, but adjust based on the 5e monster's speed:

- 20 ft or less: 3-4
- 25-35 ft: 4-5
- 40-45 ft: 6
- 50 ft or more: 7+

For flying speeds, generally add 1-2 to the ground speed.

## Step 8: Add Features

Convert 5e special abilities to DC20 Features. Consider using Quick Features from the Monster Starter Pack or adapting class features. Adjust complexity based on the monster's level and type.

For Level 2 and 3 monsters, consider adding more complex features or combining multiple features to create more challenging encounters.

## Step 9: Set Skills

Give the monster skill bonuses based on its attributes and role. Remember:

- Prime Modifier = Highest Attribute score
- Skill bonus = Prime Modifier + Skill Mastery (usually +2 for one level of mastery)
- Adjust number and level of skills based on the monster's level and type
- Level 2 and 3 monsters may have more skills or higher skill bonuses

## Step 10: Finalize Actions

Most monsters should have 1-2 main actions. Use the following format:
(AP Cost) Action Name: Range, Damage Type, additional effects

Add Attack Enhancements as needed, costing 1 AP each. Adjust complexity based on the monster's level and type.

For Level 2 and 3 monsters, consider adding more complex actions or additional options:

- Level 2: May have 2-3 main actions or more versatile attack options
- Level 3: Could have 3-4 main actions, more powerful abilities, or unique combat features

## Step 11: Review and Adjust

Compare your converted monster to the DC20 examples and the Monster Stat Ranges. Adjust as needed to ensure balance.

Remember:

- Monsters can use all Maneuvers (Attack, Save, Defense, Grapple) that PCs can.
- Consider adding Passive effects to make the monster more interesting.
- Use the Monster Difficulties as a guide for creating varied encounters.
- Adjust complexity and power level based on the monster's level and intended role in encounters.
- Level 2 monsters should be noticeably more challenging than Level 1, with improved stats and abilities.
- Level 3 monsters should be significantly more challenging than Level 2, with more complex abilities and higher stats, despite having only a +1 increase to their attack bonus.