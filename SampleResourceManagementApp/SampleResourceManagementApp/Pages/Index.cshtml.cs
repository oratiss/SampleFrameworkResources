using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleResourceManagementApp.Localization.ResourceFiles;
using SampleResourceManagementApp.Pages.BasePageModels;

namespace SampleResourceManagementApp.Pages
{
    public class IndexModel : BasePageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            LocalizationResourceType = typeof(SampleResourceManagementAppResource);
        }

        public void OnGet()
        {

        }
    }
}
