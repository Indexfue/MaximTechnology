﻿using System.Net;
using ASPNETTask.Utility.Sorting;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETTask.Controllers;

[ApiController]
[Route("[controller]")]
public class StringModifierController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProcessedString(string? input, SortingMode sortingMode = SortingMode.QuickSort)
    {
        try
        {
            StringModifier modifier = new StringModifier(input, sortingMode);

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