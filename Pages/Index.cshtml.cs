using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ArchitectureChallange.Services;
namespace ArchitectureChallange.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private ITableStorageService _tableStorageService;

    public IndexModel(ILogger<IndexModel> logger, ITableStorageService tableStorageService)
    {
        _logger = logger;
        _tableStorageService = tableStorageService;
    }

    public void OnGet()
    {
        string result = _tableStorageService.Id().Result;
        ViewData["IdHistory"] = result;
    }
}
