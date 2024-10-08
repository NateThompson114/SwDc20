using SwDc20.Core.Domain.Entities.GameInfo.V0._8;
using SwDc20.Core.Domain.Entities.Variable.V0._8;
using SwDc20.Core.Domain.Enums;

namespace SwDc20.Core.Application.Constants.Dc20;

public static class Dc20StandardConditions
{
	public static CurrentCharacterCondition Bleeding = new()
	{
		Name = nameof(Bleeding),
		Description = "You take 1 True damage at the start of each of your turns.",

		HealConditions = new List<HealConditioKeyed>
		{
		 	new (0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Blinded = new()
	{
		Name = nameof(Blinded),
		Description = "You automatically fail Checks that require Sight and all other creatures are considered Unseen. "
					  + "You are Exposed (Attacks against you have ADV) and Hindered (You have DisADV on Attacks). "
					  + "Additionally, while you are not guided by another creature, all terrain is Difficult Terrain to you (moving 1 Space costs 2 Spaces).",
		HealConditions = new List<HealConditioKeyed>
		{
			new (0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Burning = new()
	{
		Name = nameof(Burning),
		Description = "You take 1 Fire damage at the start of each of your turns.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.SpendAnActionPointFromYouOrAlly)
		}
	};
	public static CurrentCharacterCondition Charmed = new()
	{
		Name = nameof(Charmed),
		Description = "Your Charmer has ADV on Charisma Checks made against you. Additionally, you can’t target your Charmer with harmful Attacks, abilities, or magic effects.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Dazed = new()
	{
		Name = nameof(Dazed),
		Description = "You have DisADV on all Checks and Attacks.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new List<Variable>
		{
			ConditionVariables.DisAdvantageOnMentalChecks
		}
	};
	public static CurrentCharacterCondition Deafened = new()
	{
		Name = nameof(Deafened),
		Description = "You automatically fail Checks that require Hearing, and all creatures are considered Unheard by you. Additionally, you have Resistance (Half) to Sonic damage.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0,Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Doomed = new()
	{
		Name = nameof(Doomed),
		Description = "The HP threshold of Death’s Door for determining death is decreased by an amount equal to the value of X. "
			+"If your Doomed value is ever equal to or higher than your Deaths Door threshold, you instantly die upon reaching 0 HP.",
		HelperDescription = "Example: If your Deaths Door threshold is -3 and you have Doomed 1, "
			+"the HP threshold of Death’s Door changes from -3 HP to -2 HP, causing you to die if your HP is ever reduced to -2 HP or lower.",
		PerStackVariables = new List<Variable>() { ConditionVariables.LowerDeathThreshold },
		MaxStackHealConditions = new List<HealCondition> { Dc20StandardHealConditions.Dead }
	};
	public static CurrentCharacterCondition Exhaustion = new()
	{
		Name = nameof(Exhaustion),
		Description = "You gain a penalty equal to X on all Checks and Saves you make. "
			+"Additionally your Speed and Save DC is reduced by X as well. If a creature ever reaches Exhaustion 6, they immediately die.",
		HelperDescription = "Example: If you have Exhaustion 3, then you would have a -3 penalty on Checks and Saves, your Speed would be reduced by 3 Spaces, and your Save DC would be reduced by 3.",
		StackMax = 6,
		PerStackVariables = new List<Variable>() { ConditionVariables.Exhaustion },
		MaxStackHealConditions = new List<HealCondition> { Dc20StandardHealConditions.Dead }
	};
	public static CurrentCharacterCondition Exposed = new()
	{
		Name = nameof(Exposed),
		Description = "Attacks against you have ADV.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Frightened = new()
	{
		Name = nameof(Frightened),
		Description = "You must spend your turns trying to move as far away as you can from the source of your fear as possible. "
			+"The only Action you can take is the Move Action to try to run away, or the Dodge Action if you are prevented from moving or there’s nowhere farther to move. "
			+"You are also considered Rattled (you cannot move closer to the source) and Intimidated (DisADV on all Checks while it’s within your line of sight).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Grappled = new()
	{
		Name = nameof(Grappled),
		Description = "Your Speed is becomes 0 and you have DisADV on Agility Saves.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, new HealCondition("Escape Grapple","You can spend 1 AP to attempt to free yourself from a Grapple. "
				+"Make a Martial Check contested by the Grappler’s Athletics Check. Success: The Grapple immediately ends.")
			),
			new(0, new HealCondition("Incapacitated Grappler","If the Grappler becomes Incapacitated, the Grapple immediately ends.")),
			new(0, new HealCondition("Forced Movement","If an effect attempts to forcibly move you beyond the Grappler’s reach, the Grappler makes the Check or Save instead of you. "
				+"If the effect targets both you and the Grappler, the Grappler makes 1 Check or Save for both of you. Success: The targets of the effect are not moved. "
				+"Failure: The Grapple immediately ends, and the targets of the effect are moved.")
			),
			new(0, new HealCondition("Falling","If you begin falling while Grappled, and your Grappler isn't falling with you, your Grappler holds you in the air if they can carry your weight.")),
		},
		PerStackVariables = new List<Variable>{ ConditionVariables.DisadvantageOnAgilitySaves }
	};
	public static CurrentCharacterCondition Hindered = new()
	{
		Name = nameof(Hindered),
		Description = "You have DisADV on Attacks.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new List<Variable> { ConditionVariables.DisAdvantageOnAttacks }
	};
	public static CurrentCharacterCondition Impaired = new()
	{
		Name = nameof(Impaired),
		Description = "You have DisADV on Physical Checks.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new List<Variable> { ConditionVariables.DisAdvantageOnPhysicalChecks }
	};
	public static CurrentCharacterCondition Incapacitated = new()
	{
		Name = nameof(Incapacitated),
		Description = "You can not Speak, Concentrate, or spend Action Points.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new List<Variable> { ConditionVariables.CanNotSpendActionPoints }
	};
	public static CurrentCharacterCondition Intimidated = new()
	{
		Name = nameof(Intimidated),
		Description = "You have DisADV on all Checks while your source of intimidation is within your line of sight.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new List<Variable> { ConditionVariables.SituationalDisAdvantageOnAllChecks }
	};
	public static CurrentCharacterCondition Invisible = new()
	{
		Name = nameof(Invisible),
		Description = "You are Unseen, making creatures that can’t see you Exposed (your Attacks against them have ADV) and Hindered against you (they have DisADV on Attacks against you).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Paralyzed = new()
	{
		Name = nameof(Paralyzed),
		Description = "Attacks made from within 1 Space that Hit you are considered Critical Hits. "
			+"You are also Stunned (automatically fail Agility, Might and Physical Saves), Exposed (Attacks against you have ADV), and Incapacitated (you can’t Speak, Concentrate, or spend Action Points).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Petrified = new()
	{
		Name = nameof(Petrified),
		Description = "You and your mundane belongings are turned into stone and you are no longer aware of your surroundings. "
			+"You become 10 times heavier and have Resistance (Half) (take half damage) to all damage. "
			+"Any Poisons or Diseases already effecting you are suspended and you are immune to any additional Poison and Disease while Petrified. "
			+"You are also **Paralyzed** (Attacks that Hit you are considered Critical Hits if the Attacker is within 1 Space of you), **Stunned** (automatically fail Agility, Might and Physical Saves), "
			+"**Exposed** (Attacks against you have ADV), and **Incapacitated** (you can’t Speak, Concentrate, or spend Action Points).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Poisoned = new()
	{
		Name = nameof(Poisoned),
		Description = "You are Impaired (DisADV on Physical Checks) and take 1 Poison damage at the start of each of your turns. "
			+"A creature can spend 1 AP to make a Medicine Check (against the DC of the Poison) on itself or another creature within 1 Space. "
			+"Success: Remove the Poisoned Condition.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Prone = new()
	{
		Name = nameof(Prone),
		Description = "You are Hindered (You have DisADV on Attacks). Ranged Attacks are Hindered against you. You are Exposed (Attacks against you have ADV) against Melee Attacks.",
		HelperDescription = "***Crawling:*** Your only movement option it to Crawl, which counts as **Slowed** (every 1 Space you move costs an extra 1 Space of movement)."
			+ "***Standing Up:*** You can spend 2 Spaces of movement to stand up, ending the **Prone** Condition on yourself. Standing up from **Prone** provokes Opportunity Attacks.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.SpendAnActionPointFromYouOrAlly)
		}
	};
	public static CurrentCharacterCondition Rattled = new()
	{
		Name = nameof(Rattled),
		Description = "You can’t willingly move closer to your source of fear, and you are **Intimidated** (DisADV on all Checks while it’s within your line of sight).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Restrained = new()
	{
		Name = nameof(Restrained),
		Description = "You are **Hindered** (You have DisADV on Attacks), **Exposed** (Attacks against you have ADV), and **Grappled** (your Speed is reduced to 0 and you have DisADV on Agility Saves).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	public static CurrentCharacterCondition Slowed = new()
	{
		Name = nameof(Slowed),
		Description = "Every 1 Space you move costs an extra 1 Space of movement.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new()
		{
			ConditionVariables.MovementHalfed
		}
	};
	public static CurrentCharacterCondition Stunned = new()
	{
		Name = nameof(Stunned),
		Description = "You automatically fail Agility, Might and Physical Saves. You are also **Exposed** (Attacks against you have ADV), and **Incapacitated** (you can’t Speak, Concentrate, or spend Action Points).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new()
		{
			ConditionVariables.AutoFailPhysicalSaves
		}
	};
	public static CurrentCharacterCondition Surprised = new()
	{
		Name = nameof(Surprised),
		Description = "You can’t spend Action Points and are **Exposed** (Attacks against you have ADV).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new()
		{
			ConditionVariables.CanNotSpendActionPoints
		}
	};
	public static CurrentCharacterCondition Taunted = new()
	{
		Name = nameof(Taunted),
		Description = "You have DisADV on Attacks against creatures other than the one that Taunted you.",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		},
		PerStackVariables = new()
		{
			ConditionVariables.SituationalDisAdvantageOnAllAttacks
		}
	};
	public static CurrentCharacterCondition Unconscious = new()
	{
		Name = nameof(Unconscious),
		Description = "You are no longer aware of your surroundings, you drop whatever you are holding and fall **Prone**. "
			+"You are also **Paralyzed** (Attacks made from within 1 Space that Hit you are considered Critical Hits), "
			+"**Stunned** (automatically fail Agility, Might and Physical Saves), **Exposed** (Attacks against you have ADV), and **Incapacitated** (you can’t Speak, Concentrate, or spend Action Points).",
		HealConditions = new List<HealConditioKeyed>
		{
			new(0, Dc20StandardHealConditions.Healed)
		}
	};
	
	public static List<CurrentCharacterCondition> ToList()
	{
		Bleeding.HealConditions.Add(new (0, Dc20StandardHealConditions.MedicineAction().AppendedDescription(ConditionalExtensions.SuccessRemoveThe(Bleeding.Name).SuccessGainOneTempHpByFives_Append())));

		SetupDazed();

		Doomed.HealConditions.Add(new(0, Doomed.StackLongRest()));
		Exhaustion.HealConditions.Add(new(0, Exhaustion.StackOnePerLongRest()));
		Blinded.SubConditions = new List<CurrentCharacterCondition>
		{
			Exposed,
			Hindered
		};
		Frightened.SubConditions = new List<CurrentCharacterCondition>
		{
			Rattled,
			Intimidated
		};
		SetupImpaired();
		Paralyzed.SubConditions = new List<CurrentCharacterCondition>
		{
			Stunned,
			Exposed,
			Incapacitated
		};
		Petrified.SubConditions = new List<CurrentCharacterCondition>
		{
			Paralyzed,
			Stunned,
			Exposed,
			Incapacitated
		};
		Poisoned.HealConditions.Add(new(0, Dc20StandardHealConditions.Healed.ChangeDescription(Poisoned.Description.MedicineCheckWithDc().SuccessRemoveThe_Append(Poisoned.Name))));
		Poisoned.SubConditions = new()
		{
			Impaired
		};
		Prone.SubConditions = new()
		{
			Hindered,
			Exposed
		};
		Rattled.SubConditions = new()
		{
			Intimidated
		};
		Restrained.SubConditions = new()
		{
			Hindered,
			Exposed,
			Grappled
		};
		Stunned.SubConditions = new()
		{
			Exposed,
			Incapacitated
		};
		Surprised.SubConditions = new()
		{
			Exposed
		};
		Unconscious.SubConditions = new()
		{
			Paralyzed,
			Stunned,
			Exposed,
			Incapacitated
		};
		
		return typeof(Dc20StandardConditions)
			.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
			.Where(f => f.FieldType == typeof(CurrentCharacterCondition))
			.Select(f => (CurrentCharacterCondition)f.GetValue(null))
			.ToList();
	}
	
	private static void SetupDazed()
	{
		var heavilyDazed = new CurrentCharacterCondition
		{
			Name = $"Heavily {Dazed.Name}",
			Description = $"{Dazed.Description} You also have DisADV on Mental Saves",
			HealConditions = Dazed.HealConditions,
		};
		heavilyDazed.PerStackVariables.AddRange(Dazed.PerStackVariables);
		heavilyDazed.PerStackVariables.Add(ConditionVariables.DisAdvantageOnMentalSaves);

		Dazed.TransformationConditions.Add(heavilyDazed);
	}
	private static void SetupImpaired()
	{
		var heavilyImpaired = new CurrentCharacterCondition
		{
			Name = $"Heavily {Impaired.Name}",
			Description = $"{Impaired.Description}  You also have DisADV on Physical Saves.",
			HealConditions = Impaired.HealConditions,
		};
		heavilyImpaired.PerStackVariables.AddRange(Impaired.PerStackVariables);
		heavilyImpaired.PerStackVariables.Add(ConditionVariables.DisAdvantageOnPhysicalSaves);

		Impaired.TransformationConditions.Add(heavilyImpaired);
	}
}

public static class Dc20StandardHealConditions
{
	public static HealCondition Healed = new()
	{
		Name = nameof(Healed),
		Description = "You are subjected to an effect that restores your HP."
	};
	public static HealCondition MedicineAction(string difficultyCheck = "10") => new()
	{
		Name = nameof(MedicineAction),
		Description = $"A creature can spend 1 AP to make a DC {difficultyCheck} Medicine Check on itself or another creature within 1 Space."
	};
	public static HealCondition SpendAnActionPointFromYouOrAlly = new()
	{
		Name = nameof(SpendAnActionPointFromYouOrAlly),
		Description = "You or another creature within 1 Space can spend 1 AP to remove."
	};
	public static HealCondition LongRest = new()
	{
		Name = nameof(LongRest),
		Description = "You can remove this Condition by taking a Long Rest."
	};
	public static HealCondition StackLongRest(this CurrentCharacterCondition condition) => new()
	{
		Name = $"{condition.Name} {nameof(LongRest)}",
		Description = condition.Description.LongRestToRemoveStacks()
	};
	public static HealCondition StackOnePerLongRest(this CurrentCharacterCondition condition) => new()
	{
		Name = $"{condition.Name} {nameof(LongRest)}",
		Description = condition.Description.LongRestToRemoveOneStack()
	};
	public static HealCondition Dead = new()
	{
		Name = nameof(Dead),
		Description = "You need a extremely powerful resurrection"
	};
}

public static class ConditionalExtensions
{
	public static HealCondition AppendedDescription(this HealCondition condition, string description) => new()
	{
		Name = condition.Name,
		Description = $"{condition.Description} {description}"
	};
	
	public static HealCondition ChangeDescription(this HealCondition condition, string description) => new()
	{
		Name = condition.Name,
		Description = description
	};

	public static string Space(this string value) => $"{value} ";
	public static string SuccessRemoveThe(this string condition) => $"Success: Remove the {condition} Condition.";
	public static string SuccessRemoveThe_Append(this string value, string condition) => $"{value} Success: Remove the {condition} Condition.";
	public static string SuccessGainOneTempHpByFives_Append(this string value) => $"{value} Success (each 5): The creature gains +1 Temp HP.";
	public static string LongRestToRemoveStacks(this string condition) => $"You lose all stacks of {condition} when you complete a Long Rest.";
	public static string LongRestToRemoveOneStack(this string condition) => $"You lose one stack of {condition} when you complete a Long Rest.";
	public static string MedicineCheckWithConditionsDc(this string condition) => $"A creature can spend 1 AP to make a Medicine Check (against the DC of the {condition}) on itself or another creature within 1 Space.";
	public static string MedicineCheckWithDc(this string difficultyCheck) => $"A creature can spend 1 AP to make a DC {difficultyCheck} Medicine Check on itself or another creature within 1 Space. ";
}

public static class ConditionVariables
{
	public static Variable LowerDeathThreshold = new()
	{
		Id = Guid.Parse("30ca034a-53fb-4b4a-9188-4609379d33b9"),
		Version = Variable.CurrentVersion,
		Name = nameof(LowerDeathThreshold),
		Properties = [VariableProperty.Condition],
		DeathModification = new() { 
			DeathDoorThresholdChange = -1
		}
	};
	public static Variable Exhaustion = new()
	{
		Id = Guid.Parse("828bde53-85f8-4531-835f-d0652398f1d3"),
		Version = Variable.CurrentVersion,
		Name = nameof(Exhaustion),
		Properties = [VariableProperty.Condition],

		AllChecksModification = -1,
		AllSavesModification = -1,
		SpeedModification = -1,
		SaveDifficultyCheckModification = -1
	};
	public static Variable DisAdvantageOnAttacks = new()
	{
		Id = Guid.Parse("aafbbbf1-ae2c-45bd-9c8f-8cd1c3ca9d47"),
		Version = Variable.CurrentVersion,
		Name = nameof(DisAdvantageOnAttacks),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			Attack = 1
		}
	};
	public static Variable DisAdvantageOnMentalChecks = new()
	{
		Id = Guid.Parse("c67f1791-5605-43c5-a470-ef5354e7080d"),
		Version = Variable.CurrentVersion,
		Name = nameof(DisAdvantageOnMentalChecks),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			MentalChecks = 1
		}
	};
	public static Variable DisAdvantageOnMentalSaves = new()
	{
		Id = Guid.Parse("4b7be7c7-ce56-4f7c-9a3f-10a109846a20"),
		Version = Variable.CurrentVersion,
		Name = nameof(DisAdvantageOnMentalSaves),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			MentalSaves = 1
		}
	};
	public static Variable DisadvantageOnAgilitySaves = new()
	{
		Id = Guid.Parse("cf718362-6ef3-46bd-9d6e-47d60887528e"),
		Version = Variable.CurrentVersion,
		Name = nameof(DisadvantageOnAgilitySaves),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			Agility = 1
		}
	};
	public static Variable DisAdvantageOnPhysicalChecks = new()
	{
		Id = Guid.Parse("30d52647-69ed-4d84-8998-d19e1013ccc8"),
		Version = Variable.CurrentVersion,
		Name = nameof(DisAdvantageOnPhysicalChecks),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			PhysicalChecks = 1
		}
	};
	public static Variable DisAdvantageOnPhysicalSaves = new()
	{
		Id = Guid.Parse("a2fdcbfa-6dbe-416a-81c4-3db70815a93e"),
		Version = Variable.CurrentVersion,
		Name = nameof(DisAdvantageOnPhysicalSaves),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			PhysicalSaves = 1
		}
	};
	public static Variable SituationalDisAdvantageOnAllChecks = new()
	{
		Id = Guid.Parse("e2826d7d-27cc-44c2-9b04-a1d28aaf0831"),
		Version = Variable.CurrentVersion,
		Name = nameof(SituationalDisAdvantageOnAllChecks),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			Situational = true,
			AllChecks = 1
		}
	};
	public static Variable CanNotSpendActionPoints = new()
	{
		Id = Guid.Parse("d36a9018-5d11-4b06-990b-b3ba6ac41387"),
		Version = Variable.CurrentVersion,
		Name = nameof(CanNotSpendActionPoints),
		Properties = [VariableProperty.Condition],
		CanNotSpendActionPoints = true
	};
	public static Variable SlowedMovement = new()
	{
		Id = Guid.Parse("f1f3b1b4-4b3b-4b3b-8b3b-4b3b4b3b4b3b"),
		Version = Variable.CurrentVersion,
		Name = nameof(SlowedMovement),
		Properties = [VariableProperty.Condition],
		SpeedModification = -1
	};
	public static Variable MovementHalfed = new()
	{
		Id = Guid.Parse("2fd141e8-8bd4-40fe-8aee-f86c1f900919"),
		Version = Variable.CurrentVersion,
		Name = nameof(MovementHalfed),
		Properties = [VariableProperty.Condition],
		SpeedHalfed = true
	};
	public static Variable AutoFailPhysicalSaves = new()
	{
		Id = Guid.Parse("04925c01-3cdd-406c-8a92-731c7caaea8f"),		
		Version = Variable.CurrentVersion,
		Name = nameof(AutoFailPhysicalSaves),
		Properties = [VariableProperty.Condition],
		AutoFailure = new()
		{
			PhysicalSaves = 1
		}
	};
	public static Variable SituationalDisAdvantageOnAllAttacks = new()
	{
		Id = Guid.Parse("7bf6548f-25ab-4e82-90d0-846a0bb9400e"),
		Version = Variable.CurrentVersion,
		Name = nameof(SituationalDisAdvantageOnAllAttacks),
		Properties = [VariableProperty.Condition],
		Disadvantages = new()
		{
			Situational = true,
			Attack = 1
		}
	};
	
	public static List<Variable> ToList()
	{
		return typeof(ConditionVariables)
			.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
			.Where(f => f.FieldType == typeof(Variable))
			.Select(f => (Variable)f.GetValue(null))
			.ToList();
	}
}
