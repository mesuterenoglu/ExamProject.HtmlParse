﻿using ExamProject.Application.DTOs;
using ExamProject.Application.ServiceInterfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;

namespace ExamProject.MVC.GetPosts
{
    public class GetPostsFromWired
    {
        private readonly IPostService _postService;

        public GetPostsFromWired(IPostService postService)
        {
            _postService = postService;
        }
        private List<string> _Links { get; set; }
        private void _GetLinks()
        {
            try
            {
                HtmlWeb web = new HtmlWeb();

                HtmlDocument document = web.Load("https://www.wired.com/");
                var recents = document.DocumentNode.SelectNodes("//a[@class='SummaryItemHedLink-cgPsOZ cnoEIb summary-item-tracking__hed-link summary-item__hed-link']");
                if (recents != null)
                {
                    _Links = new List<string>();
                    for (int i = 0; i < 5; i++)
                    {
                        var link = recents[i].Attributes["href"].Value;
                        _Links.Add(link);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        public void GetPosts()
        {
            try
            {
                _GetLinks();
                foreach (var link in _Links)
                {
                    HtmlWeb web = new HtmlWeb();

                    HtmlDocument document = web.Load("https://www.wired.com/" + link);

                    HtmlNodeCollection Content = document.DocumentNode.SelectNodes("//article[@class='article-body-component article-body-component--null']/div");

                    if (Content != null)
                    {
                        var postContent = Content[0].InnerHtml;
                        var title = document.DocumentNode.SelectSingleNode("//h1[@class='title']").InnerText;
                        var fullDate = document.DocumentNode.SelectSingleNode("//time[@class='date-mdy']").InnerText;
                        var author = document.DocumentNode.SelectSingleNode("//a[@class='byline-component__link']").InnerText;
                        var date = fullDate.Split(".");
                        AddPost(title, postContent, author, date);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        private async void AddPost(string title, string postContent,string author, string[] date)
        {
            var result = await _postService.AnybyHeaderandAuthor(title, author);
            if (!result)
            {
                PostDto postDto = new PostDto();
                postDto.Id = Guid.NewGuid();
                postDto.Header = title;
                postDto.Content = postContent;
                postDto.AuthorName = author;
                postDto.PostedDate = new DateTime(Convert.ToInt32("20" + date[2]), Convert.ToInt32(date[0]), Convert.ToInt32(date[1]));
                await _postService.AddAsync(postDto);
            }
        }
    }
}
