using ASPNETTask.Utility.Sorting;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETTask.Controllers;

[ApiController]
[Route("[controller]")]
public class StringModifierController : ControllerBase
{
    private readonly IConfiguration _configuration;
    
     public StringModifierController(IConfiguration configuration) 
     {
         _configuration = configuration;
     }
    
    [HttpGet]
    public IActionResult GetProcessedString(string input, SortingMode sortingMode = SortingMode.QuickSort)
    {
        AppSettings appSettings = _configuration.GetSection("Settings").Get<AppSettings>();

        if (appSettings?.BlackList?.Contains(input) == true)
        {
            return BadRequest($"HTTP ошибка 400 Bad Request. Строка находится в Чёрном списке.");
        }
        
        try
        {
            StringModifier modifier = new StringModifier(input, sortingMode);

            if (modifier.Result == null)
            {
                return BadRequest($"HTTP ошибка 400 Bad Request. Строка содержит недопустимые символы.");
            }

            var result = new
            {
                ProcessedString = modifier.Result,
                CharCount = modifier.CharCount,
                MaxVowelString = modifier.MaxVowelString,
                SortedResult = modifier.SortedResult,
                TrimmedResult = modifier.RandomRemovedString
            };

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest($"HTTP ошибка 400 Bad Request. Ошибка: {ex.Message}");
        }
    }
}