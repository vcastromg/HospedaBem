using Application.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HexagonalArchitecture.Pages;

public class Reviews : PageModel
{
    private readonly ReviewService _reviewService;

    public Reviews(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    public void OnGet()
    {
        
    }
}