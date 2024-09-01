using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapp.Pages;

public class AlertsModel : PageModel
{
    private readonly ILogger<AlertsModel> _logger;

    public AlertsModel(ILogger<AlertsModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

}

