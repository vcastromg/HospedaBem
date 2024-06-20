﻿using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace HexagonalArchitecture.Controllers;

[ApiController]
[Route("/api/review")]
public class ReviewController : ControllerBase
{
    private readonly ReviewService _reviewService;

    public ReviewController(ReviewService reviewService)
    {
        _reviewService = reviewService;
    }

    [HttpPost]
    public CreatedResult CreateReview(Review review)
    {
        _reviewService.CreateReview(review);
        return Created();
    }

    [HttpGet("{id}")]
    public IActionResult ListReviewsById([FromRoute] string id)
    {
        return Ok(_reviewService.GetReviewsByUser(id));
    }

    [HttpPost("/update")]
    public IActionResult UpdateReview(Review review)
    {
        return Ok(_reviewService.UpdateReview(review));
    }

}