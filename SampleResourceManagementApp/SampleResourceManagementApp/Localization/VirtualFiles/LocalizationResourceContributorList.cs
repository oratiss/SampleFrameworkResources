﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Localization;

namespace SampleResourceManagementApp.Localization.VirtualFiles
{
    public class LocalizationResourceContributorList: List<ILocalizationResourceContributor>
    {
        public LocalizedString GetOrNull(string cultureName, string name)
        {
            foreach (var contributor in this.AsQueryable().Reverse())
            {
                var localString = contributor.GetOrNull(cultureName, name);
                if (localString !=null)
                    return localString;
            }

            throw new Exception("there is no contributor!");
        }

        public void Fill(string cultureName, Dictionary<string, LocalizedString> dictionary)
        {
            foreach (var contributor in this)
                contributor.Fill(cultureName, dictionary);
        }
    }
}