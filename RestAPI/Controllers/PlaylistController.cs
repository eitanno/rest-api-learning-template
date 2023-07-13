using System;
using Microsoft.AspNetCore.Mvc;
using RestAPI.Services;
using RestAPI.Models;

namespace RestAPI.Controllers;



public class PlaylistController : ControllerBase
{
    private readonly ILogger<PlaylistController> _logger;
    private readonly PlaylistService _playListService;

    public PlaylistController(PlaylistService playListService, ILogger<PlaylistController> logger)
    {
        _playListService = playListService;
        _logger = logger;
    }




}