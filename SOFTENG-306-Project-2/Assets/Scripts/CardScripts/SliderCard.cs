﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace SunnyTown
{
    /// <summary>
    /// A SliderCard represents an interactable decision in which the user 
    /// can selected from a range of numeric values.
    /// </summary>
    public class SliderCard : Card
    {
        public new List<SliderTransition> Options { get; private set; }
        public int MaxValue { get; private set; }
        public int MinValue { get; private set; }

        public SliderCard(string[] precedingDialogue, string name, string question, List<SliderTransition> options,
            int maxValue, int minValue)
        {
            PrecedingDialogue = precedingDialogue;
            NPCName = name;
            Question = question;
            Options = options;
            MaxValue = maxValue;
            MinValue = minValue;
        }

        public override void HandleDecision(int valueSelected, string additionalState = "")
        {
            if (Options.Count >= 1)
            {
                SliderTransition optionChosen;
                var optionsAboveThreshold = Options.Where(option => valueSelected > option.Threshold);

                // if none were found to be above the thresholds
                if (optionsAboveThreshold.ToList().Count == 0)
                {
                    // Retrieve the minimum
                    optionChosen = Options.OrderByDescending(x => x.Threshold).Last();
                }
                else
                {
                    // Otherwise select the max one above the thresholds
                    optionChosen = optionsAboveThreshold.OrderByDescending(x => x.Threshold).First();
                }

                optionChosen.MetricsModifier.Modify();
                Feedback = optionChosen.Feedback;
                FeedbackNPCName = optionChosen.FeedbackNPCName;
                ShouldAnimate = optionChosen.HasAnimation;
                BuildingName = optionChosen.BuildingName;
            }
        }
    }
}