﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Luis;
using Microsoft.Bot.Builder;

namespace ToDoSkill.Tests.Flow.Utterances
{
    public class GeneralTestUtterances : Dictionary<string, General>
    {
        public GeneralTestUtterances()
        {
            this.Add(ShowNext, GetGeneralIntent(
                ShowNext,
                General.Intent.ShowNext));

            this.Add(ShowPrevious, GetGeneralIntent(
                ShowPrevious,
                General.Intent.ShowPrevious));

            this.Add(ReadMore, GetGeneralIntent(
                ReadMore,
                General.Intent.ShowNext));

            this.Add(Logout, GetGeneralIntent(
                ReadMore,
                General.Intent.Logout));
        }

        public static double TopIntentScore { get; } = 0.9;

        public static string ShowNext { get; } = "show next";

        public static string ShowPrevious { get; } = "show previous";

        public static string ReadMore { get; } = "read more";

        public static string Logout { get; } = "log out";

        public static string UnknownIntent { get; } = "what's the weather?";

        public General GetBaseNoneIntent()
        {
            return GetGeneralIntent();
        }

        public General GetGeneralIntent(
            string userInput = null,
            General.Intent intents = General.Intent.None)
        {
            var intent = new General();
            intent.Text = userInput;
            intent.Intents = new Dictionary<General.Intent, IntentScore>();
            intent.Intents.Add(intents, new IntentScore() { Score = TopIntentScore });
            return intent;
        }
    }
}
