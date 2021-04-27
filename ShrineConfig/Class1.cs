using BepInEx;
using BepInEx.Configuration;
using EntityStates.Toolbot;
using R2API;
using R2API.Utils;
using RoR2;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ShrineConfig
{
    [BepInDependency("com.bepis.r2api")]
    [BepInPlugin("com.Moffein.ShrineConfig", "ShrineConfig", "0.0.1")]
    [R2API.Utils.R2APISubmoduleDependency(nameof(DirectorAPI))]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    public class ShrineConfig : BaseUnityPlugin
    {
        public struct StageShrineWeights
        {
            public int blood, chance, combat, order, mountain, woods, cleanse;
        }

        public void Awake()
        {
            int costChance = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Shrine of Chance"), 20, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;
            int costBlood = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Shrine of Blood"), 20, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;
            int costCombat = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Shrine of Combat"), 20, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;
            int costOrder = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Shrine of Order"), 30, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;
            int costMountain = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Shrine of the Mountain"), 20, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;
            int costWoods = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Shrine of the Woods"), 15, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;
            int costCleanse = base.Config.Bind<int>(new ConfigDefinition("00 - Credit Costs", "Cleansing Pool"), 5, new ConfigDescription("How many director credits the shrine costs to spawn.")).Value;

            #region stage1
            StageShrineWeights titanicPlains = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine of Blood Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine of Combat Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("10 - Titanic Plains", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };

            StageShrineWeights distantRoost = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine of Blood Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine of Combat Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Shrine of the Woods Weight"), 2, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("11 - Distant Roost", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };
            #endregion
            #region stage2
            StageShrineWeights wetlandAspect = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine of Blood Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine of Combat Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("20 - Wetland Aspect", "Cleansing Pool Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };

            StageShrineWeights abandonedAqueduct = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine Category Weight"), 8, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine of Blood Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine of Combat Weight"), 2, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("21 - Abandoned Aqueduct", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };
            #endregion
            #region stage3
            StageShrineWeights rallypointDelta = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine Category Weight"), 7, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine of Blood Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine of Combat Weight"), 2, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine of Order Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine of the Mountain Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("30 - Rallypoint Delta", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };

            StageShrineWeights scorchedAcres = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine Category Weight"), 7, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine of Blood Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine of Combat Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine of the Mountain Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Shrine of the Woods Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("31 - Scorched Acres", "Cleansing Pool Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };
            #endregion
            #region stage4
            StageShrineWeights abyssalDepths = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine of Blood Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine of Combat Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("40 - Abyssal Depths", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };

            StageShrineWeights sirensCall = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine of Chance Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine of Blood Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine of Combat Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Shrine of the Woods Weight"), 2, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("41 - Sirens Call", "Cleansing Pool Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };

            StageShrineWeights sunderedGrove = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine of Blood Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine of Combat Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("42 - Sundered Grove", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };
            #endregion

            StageShrineWeights skyMeadow = new StageShrineWeights
            {
                //overall = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine Category Weight"), 10, new ConfigDescription("How likely it is for shrines to spawn on this map.")).Value,
                chance = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine of Chance Weight"), 4, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                blood = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine of Blood Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                combat = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine of Combat Weight"), 3, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                order = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine of Order Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                mountain = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine of the Mountain Weight"), 1, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                woods = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Shrine of the Woods Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value,
                cleanse = base.Config.Bind<int>(new ConfigDefinition("50 - Sky Meadow", "Cleansing Pool Weight"), 0, new ConfigDescription("How likely it is for the shrine to be spawned.")).Value
            };

            SpawnCard chanceSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineChance");
            SpawnCard bloodSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineBlood");
            SpawnCard combatSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineCombat");
            SpawnCard orderSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineRestack");
            SpawnCard mountainSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineBoss");
            SpawnCard woodsSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineHealing");
            SpawnCard cleanseSC = Resources.Load<SpawnCard>("SpawnCards/InteractableSpawnCard/iscShrineCleanse");

            Debug.Log("chance: " + chanceSC.directorCreditCost);
            Debug.Log("blood: " + bloodSC.directorCreditCost);
            Debug.Log("combat: " + combatSC.directorCreditCost);
            Debug.Log("order: " + orderSC.directorCreditCost);
            Debug.Log("mountain: " + mountainSC.directorCreditCost);
            Debug.Log("woods: " + woodsSC.directorCreditCost);
            Debug.Log("cleanse: " + cleanseSC.directorCreditCost);

            chanceSC.directorCreditCost = costChance;
            bloodSC.directorCreditCost = costBlood;
            combatSC.directorCreditCost = costCombat;
            orderSC.directorCreditCost = costOrder;
            mountainSC.directorCreditCost = costMountain;
            woodsSC.directorCreditCost = costWoods;
            cleanseSC.directorCreditCost = costCleanse;

            DirectorAPI.InteractableActions += delegate (List<DirectorAPI.DirectorCardHolder> cardList, DirectorAPI.StageInfo stage)
            {
                bool foundStage = true;
                StageShrineWeights ssw = titanicPlains;
                switch(stage.stage)
                {
                    case DirectorAPI.Stage.TitanicPlains:
                        ssw = titanicPlains;
                        break;
                    case DirectorAPI.Stage.DistantRoost:
                        ssw = distantRoost;
                        break;
                    case DirectorAPI.Stage.WetlandAspect:
                        ssw = wetlandAspect;
                        break;
                    case DirectorAPI.Stage.AbandonedAqueduct:
                        ssw = abandonedAqueduct;
                        break;
                    case DirectorAPI.Stage.RallypointDelta:
                        ssw = rallypointDelta;
                        break;
                    case DirectorAPI.Stage.ScorchedAcres:
                        ssw = scorchedAcres;
                        break;
                    case DirectorAPI.Stage.AbyssalDepths:
                        ssw = abyssalDepths;
                        break;
                    case DirectorAPI.Stage.SirensCall:
                        ssw = sirensCall;
                        break;
                    case DirectorAPI.Stage.SkyMeadow:
                        ssw = skyMeadow;
                        break;
                    case DirectorAPI.Stage.Custom:
                        if (stage.CustomStageName == "rootjungle")
                        {
                            ssw = sunderedGrove;
                        }
                        else
                        {
                            foundStage = false;
                        }
                        break;
                    default:
                        foundStage = false;
                        break;
                }

                if (foundStage)
                {
                    bool handledChance = false;
                    bool handledBlood = false;
                    bool handledCombat = false;
                    bool handledOrder = false;
                    bool handledMountain = false;
                    bool handledWoods = false;
                    bool handledCleanse = false;

                    List<DirectorAPI.DirectorCardHolder> toRemove = new List<DirectorAPI.DirectorCardHolder>();
                    foreach (DirectorAPI.DirectorCardHolder dc in cardList)
                    {
                       if (dc.InteractableCategory == DirectorAPI.InteractableCategory.Shrines)
                       {
                            /*Debug.Log("\n\n\ncard: " + dc.Card.spawnCard);
                            Debug.Log("weight: " + dc.Card.selectionWeight);
                            Debug.Log("preventoverhead: " + dc.Card.preventOverhead);
                            Debug.Log("spawndistance: " + dc.Card.spawnDistance);*/

                            //Debug.Log("\nold selection weight: " + dc.Card.selectionWeight);
                            if (dc.Card.spawnCard == chanceSC)
                            {
                                handledChance = true;
                                dc.Card.selectionWeight = ssw.chance;
                            }
                            else if (!handledBlood && dc.Card.spawnCard == bloodSC)
                            {
                                handledBlood = true;
                                dc.Card.selectionWeight = ssw.blood;
                            }
                            else if (dc.Card.spawnCard == combatSC)
                            {
                                handledCombat = true;
                                dc.Card.selectionWeight = ssw.combat;
                            }
                            else if (dc.Card.spawnCard == orderSC)
                            {
                                handledOrder = true;
                                dc.Card.selectionWeight = ssw.order;
                            }
                            else if (dc.Card.spawnCard == mountainSC)
                            {
                                handledMountain = true;
                                dc.Card.selectionWeight = ssw.mountain;
                            }
                            else if (dc.Card.spawnCard == woodsSC)
                            {
                                handledWoods = true;
                                dc.Card.selectionWeight = ssw.woods;
                            }
                            else if (dc.Card.spawnCard == cleanseSC)
                            {
                                handledCleanse = true;
                                dc.Card.selectionWeight = ssw.cleanse;
                            }
                            //Debug.Log("new selection weight: " + dc.Card.selectionWeight);

                            if (dc.Card.selectionWeight == 0)
                            {
                                //Debug.Log("removing from pool: " + dc.Card.spawnCard);
                                toRemove.Add(dc);
                            }
                        
                        }
                    }

                    foreach(DirectorAPI.DirectorCardHolder dc in toRemove)
                    {
                        cardList.Remove(dc);
                    }

                    if (!handledChance && ssw.chance > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = chanceSC,
                            selectionWeight = ssw.chance,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                    if (!handledBlood && ssw.blood > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = bloodSC,
                            selectionWeight = ssw.blood,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                    if (!handledCombat && ssw.combat > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = combatSC,
                            selectionWeight = ssw.combat,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                    if (!handledOrder && ssw.order > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = orderSC,
                            selectionWeight = ssw.order,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                    if (!handledMountain && ssw.mountain > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = mountainSC,
                            selectionWeight = ssw.mountain,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                    if (!handledWoods && ssw.woods > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = woodsSC,
                            selectionWeight = ssw.woods,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                    if (!handledCleanse && ssw.cleanse > 0)
                    {
                        DirectorCard newDC = new DirectorCard
                        {
                            spawnCard = cleanseSC,
                            selectionWeight = ssw.cleanse,
                            allowAmbushSpawn = false,
                            preventOverhead = false,
                            minimumStageCompletions = 0,
                            requiredUnlockable = "",
                            forbiddenUnlockable = "",
                            spawnDistance = DirectorCore.MonsterSpawnDistance.Standard
                        };
                        DirectorAPI.DirectorCardHolder newCard = new DirectorAPI.DirectorCardHolder
                        {
                            Card = newDC,
                            MonsterCategory = DirectorAPI.MonsterCategory.None,
                            InteractableCategory = DirectorAPI.InteractableCategory.Shrines
                        };
                        cardList.Add(newCard);
                    }
                
                }
            };
        }
    }
}
